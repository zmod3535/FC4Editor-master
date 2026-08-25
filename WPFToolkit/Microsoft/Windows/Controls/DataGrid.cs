using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Windows.Automation.Peers;
using Microsoft.Windows.Controls.Primitives;
using MS.Internal;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000038 RID: 56
	public class DataGrid : MultiSelector
	{
		// Token: 0x06000312 RID: 786 RVA: 0x0000B880 File Offset: 0x00009A80
		static DataGrid()
		{
			Type typeFromHandle = typeof(DataGrid);
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(typeof(DataGrid)));
			FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(Microsoft.Windows.Controls.Primitives.DataGridRowsPresenter));
			frameworkElementFactory.SetValue(FrameworkElement.NameProperty, "PART_RowsPresenter");
			ItemsControl.ItemsPanelProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(new ItemsPanelTemplate(frameworkElementFactory)));
			VirtualizingStackPanel.IsVirtualizingProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(true, null, new CoerceValueCallback(DataGrid.OnCoerceIsVirtualizingProperty)));
			VirtualizingStackPanel.VirtualizationModeProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(VirtualizationMode.Recycling));
			ItemsControl.ItemContainerStyleProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGrid.OnCoerceItemContainerStyle)));
			ItemsControl.ItemContainerStyleSelectorProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGrid.OnCoerceItemContainerStyleSelector)));
			ItemsControl.ItemsSourceProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGrid.OnCoerceItemsSourceProperty)));
			ItemsControl.AlternationCountProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(0, null, new CoerceValueCallback(DataGrid.OnCoerceAlternationCount)));
			UIElement.IsEnabledProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGrid.OnIsEnabledChanged)));
			Selector.IsSynchronizedWithCurrentItemProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGrid.OnCoerceIsSynchronizedWithCurrentItem)));
			Control.IsTabStopProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(false));
			KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(KeyboardNavigationMode.Contained));
			KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(KeyboardNavigationMode.Once));
			CommandManager.RegisterClassInputBinding(typeFromHandle, new InputBinding(DataGrid.BeginEditCommand, new KeyGesture(Key.F2)));
			CommandManager.RegisterClassCommandBinding(typeFromHandle, new CommandBinding(DataGrid.BeginEditCommand, new ExecutedRoutedEventHandler(DataGrid.OnExecutedBeginEdit), new CanExecuteRoutedEventHandler(DataGrid.OnCanExecuteBeginEdit)));
			CommandManager.RegisterClassCommandBinding(typeFromHandle, new CommandBinding(DataGrid.CommitEditCommand, new ExecutedRoutedEventHandler(DataGrid.OnExecutedCommitEdit), new CanExecuteRoutedEventHandler(DataGrid.OnCanExecuteCommitEdit)));
			CommandManager.RegisterClassInputBinding(typeFromHandle, new InputBinding(DataGrid.CancelEditCommand, new KeyGesture(Key.Escape)));
			CommandManager.RegisterClassCommandBinding(typeFromHandle, new CommandBinding(DataGrid.CancelEditCommand, new ExecutedRoutedEventHandler(DataGrid.OnExecutedCancelEdit), new CanExecuteRoutedEventHandler(DataGrid.OnCanExecuteCancelEdit)));
			CommandManager.RegisterClassCommandBinding(typeFromHandle, new CommandBinding(DataGrid.SelectAllCommand, new ExecutedRoutedEventHandler(DataGrid.OnExecutedSelectAll), new CanExecuteRoutedEventHandler(DataGrid.OnCanExecuteSelectAll)));
			CommandManager.RegisterClassCommandBinding(typeFromHandle, new CommandBinding(DataGrid.DeleteCommand, new ExecutedRoutedEventHandler(DataGrid.OnExecutedDelete), new CanExecuteRoutedEventHandler(DataGrid.OnCanExecuteDelete)));
			CommandManager.RegisterClassCommandBinding(typeof(DataGrid), new CommandBinding(ApplicationCommands.Copy, new ExecutedRoutedEventHandler(DataGrid.OnExecutedCopy), new CanExecuteRoutedEventHandler(DataGrid.OnCanExecuteCopy)));
			EventManager.RegisterClassHandler(typeof(DataGrid), UIElement.MouseUpEvent, new MouseButtonEventHandler(DataGrid.OnAnyMouseUpThunk), true);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0000C768 File Offset: 0x0000A968
		public DataGrid()
		{
			this._columns = new DataGridColumnCollection(this);
			this._columns.CollectionChanged += this.OnColumnsChanged;
			this._rowValidationRules = new ObservableCollection<ValidationRule>();
			this._rowValidationRules.CollectionChanged += this.OnRowValidationRulesChanged;
			this._selectedCells = new SelectedCellsCollection(this);
			((INotifyCollectionChanged)base.Items).CollectionChanged += this.OnItemsCollectionChanged;
			((INotifyCollectionChanged)base.Items.SortDescriptions).CollectionChanged += this.OnItemsSortDescriptionsChanged;
			base.Items.GroupDescriptions.CollectionChanged += this.OnItemsGroupDescriptionsChanged;
			this.InternalColumns.InvalidateColumnWidthsComputation();
			this.CellsPanelHorizontalOffsetComputationPending = false;
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0000C84D File Offset: 0x0000AA4D
		public ObservableCollection<DataGridColumn> Columns
		{
			get
			{
				return this._columns;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0000C855 File Offset: 0x0000AA55
		internal DataGridColumnCollection InternalColumns
		{
			get
			{
				return this._columns;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000316 RID: 790 RVA: 0x0000C85D File Offset: 0x0000AA5D
		// (set) Token: 0x06000317 RID: 791 RVA: 0x0000C86F File Offset: 0x0000AA6F
		public bool CanUserResizeColumns
		{
			get
			{
				return (bool)base.GetValue(DataGrid.CanUserResizeColumnsProperty);
			}
			set
			{
				base.SetValue(DataGrid.CanUserResizeColumnsProperty, value);
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000318 RID: 792 RVA: 0x0000C882 File Offset: 0x0000AA82
		// (set) Token: 0x06000319 RID: 793 RVA: 0x0000C894 File Offset: 0x0000AA94
		public DataGridLength ColumnWidth
		{
			get
			{
				return (DataGridLength)base.GetValue(DataGrid.ColumnWidthProperty);
			}
			set
			{
				base.SetValue(DataGrid.ColumnWidthProperty, value);
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0000C8A7 File Offset: 0x0000AAA7
		// (set) Token: 0x0600031B RID: 795 RVA: 0x0000C8B9 File Offset: 0x0000AAB9
		public double MinColumnWidth
		{
			get
			{
				return (double)base.GetValue(DataGrid.MinColumnWidthProperty);
			}
			set
			{
				base.SetValue(DataGrid.MinColumnWidthProperty, value);
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0000C8CC File Offset: 0x0000AACC
		// (set) Token: 0x0600031D RID: 797 RVA: 0x0000C8DE File Offset: 0x0000AADE
		public double MaxColumnWidth
		{
			get
			{
				return (double)base.GetValue(DataGrid.MaxColumnWidthProperty);
			}
			set
			{
				base.SetValue(DataGrid.MaxColumnWidthProperty, value);
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000C8F1 File Offset: 0x0000AAF1
		private static void OnColumnSizeConstraintChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.Columns);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000C904 File Offset: 0x0000AB04
		private static bool ValidateMinColumnWidth(object v)
		{
			double num = (double)v;
			return num >= 0.0 && !DoubleUtil.IsNaN(num) && !double.IsPositiveInfinity(num);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000C938 File Offset: 0x0000AB38
		private static bool ValidateMaxColumnWidth(object v)
		{
			double num = (double)v;
			return num >= 0.0 && !DoubleUtil.IsNaN(num);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000C964 File Offset: 0x0000AB64
		private void OnColumnsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				this.UpdateDataGridReference(e.NewItems, false);
				DataGrid.UpdateColumnSizeConstraints(e.NewItems);
				break;
			case NotifyCollectionChangedAction.Remove:
				this.UpdateDataGridReference(e.OldItems, true);
				break;
			case NotifyCollectionChangedAction.Replace:
				this.UpdateDataGridReference(e.OldItems, true);
				this.UpdateDataGridReference(e.NewItems, false);
				DataGrid.UpdateColumnSizeConstraints(e.NewItems);
				break;
			case NotifyCollectionChangedAction.Reset:
				this._selectedCells.Clear();
				break;
			}
			if (this.InternalColumns.DisplayIndexMapInitialized)
			{
				base.CoerceValue(DataGrid.FrozenColumnCountProperty);
			}
			bool flag = DataGrid.HasVisibleColumns(e.OldItems);
			flag |= DataGrid.HasVisibleColumns(e.NewItems);
			flag |= (e.Action == NotifyCollectionChangedAction.Reset);
			if (flag)
			{
				this.InternalColumns.InvalidateColumnRealization(true);
			}
			this.UpdateColumnsOnRows(e);
			if (flag && e.Action != NotifyCollectionChangedAction.Move)
			{
				this.InternalColumns.InvalidateColumnWidthsComputation();
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000CA5C File Offset: 0x0000AC5C
		internal void UpdateDataGridReference(IList list, bool clear)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridColumn dataGridColumn = (DataGridColumn)list[i];
				if (clear)
				{
					if (dataGridColumn.DataGridOwner == this)
					{
						dataGridColumn.DataGridOwner = null;
					}
				}
				else
				{
					if (dataGridColumn.DataGridOwner != null && dataGridColumn.DataGridOwner != this)
					{
						dataGridColumn.DataGridOwner.Columns.Remove(dataGridColumn);
					}
					dataGridColumn.DataGridOwner = this;
				}
			}
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000CAC8 File Offset: 0x0000ACC8
		private static void UpdateColumnSizeConstraints(IList list)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridColumn dataGridColumn = (DataGridColumn)list[i];
				dataGridColumn.SyncProperties();
			}
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000CAFC File Offset: 0x0000ACFC
		private static bool HasVisibleColumns(IList columns)
		{
			if (columns != null && columns.Count > 0)
			{
				foreach (object obj in columns)
				{
					DataGridColumn dataGridColumn = (DataGridColumn)obj;
					if (dataGridColumn.IsVisible)
					{
						return true;
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000CB64 File Offset: 0x0000AD64
		public DataGridColumn ColumnFromDisplayIndex(int displayIndex)
		{
			if (displayIndex < 0 || displayIndex >= this.Columns.Count)
			{
				throw new ArgumentOutOfRangeException("displayIndex", displayIndex, SR.Get(SRID.DataGrid_DisplayIndexOutOfRange));
			}
			return this.InternalColumns.ColumnFromDisplayIndex(displayIndex);
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000326 RID: 806 RVA: 0x0000CB9F File Offset: 0x0000AD9F
		// (remove) Token: 0x06000327 RID: 807 RVA: 0x0000CBB8 File Offset: 0x0000ADB8
		public event EventHandler<DataGridColumnEventArgs> ColumnDisplayIndexChanged;

		// Token: 0x06000328 RID: 808 RVA: 0x0000CBD1 File Offset: 0x0000ADD1
		protected internal virtual void OnColumnDisplayIndexChanged(DataGridColumnEventArgs e)
		{
			if (this.ColumnDisplayIndexChanged != null)
			{
				this.ColumnDisplayIndexChanged(this, e);
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000329 RID: 809 RVA: 0x0000CBE8 File Offset: 0x0000ADE8
		internal List<int> DisplayIndexMap
		{
			get
			{
				return this.InternalColumns.DisplayIndexMap;
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000CBF5 File Offset: 0x0000ADF5
		internal void ValidateDisplayIndex(DataGridColumn column, int displayIndex)
		{
			this.InternalColumns.ValidateDisplayIndex(column, displayIndex);
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0000CC04 File Offset: 0x0000AE04
		internal int ColumnIndexFromDisplayIndex(int displayIndex)
		{
			if (displayIndex >= 0 && displayIndex < this.DisplayIndexMap.Count)
			{
				return this.DisplayIndexMap[displayIndex];
			}
			return -1;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0000CC28 File Offset: 0x0000AE28
		internal Microsoft.Windows.Controls.Primitives.DataGridColumnHeader ColumnHeaderFromDisplayIndex(int displayIndex)
		{
			int num = this.ColumnIndexFromDisplayIndex(displayIndex);
			if (num != -1 && this.ColumnHeadersPresenter != null && this.ColumnHeadersPresenter.ItemContainerGenerator != null)
			{
				return (Microsoft.Windows.Controls.Primitives.DataGridColumnHeader)this.ColumnHeadersPresenter.ItemContainerGenerator.ContainerFromIndex(num);
			}
			return null;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0000CC6E File Offset: 0x0000AE6E
		private static void OnNotifyCellsPresenterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.CellsPresenter);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0000CC7E File Offset: 0x0000AE7E
		private static void OnNotifyColumnAndCellPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.Cells | NotificationTarget.Columns);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000CC8E File Offset: 0x0000AE8E
		private static void OnNotifyColumnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.Columns);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000CC9E File Offset: 0x0000AE9E
		private static void OnNotifyColumnAndColumnHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.Columns | NotificationTarget.ColumnHeaders);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000CCAF File Offset: 0x0000AEAF
		private static void OnNotifyColumnHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.ColumnHeaders);
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000CCC0 File Offset: 0x0000AEC0
		private static void OnNotifyHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.ColumnHeaders | NotificationTarget.RowHeaders);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000CCD4 File Offset: 0x0000AED4
		private static void OnNotifyDataGridAndRowPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.DataGrid | NotificationTarget.Rows);
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000CCE8 File Offset: 0x0000AEE8
		private static void OnNotifyGridLinePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.OldValue != e.NewValue)
			{
				((DataGrid)d).OnItemTemplateChanged(null, null);
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000CD07 File Offset: 0x0000AF07
		private static void OnNotifyRowPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.Rows);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000CD1B File Offset: 0x0000AF1B
		private static void OnNotifyRowHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.RowHeaders);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000CD2F File Offset: 0x0000AF2F
		private static void OnNotifyRowAndRowHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.RowHeaders | NotificationTarget.Rows);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000CD43 File Offset: 0x0000AF43
		private static void OnNotifyRowAndDetailsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.DetailsPresenter | NotificationTarget.Rows);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000CD57 File Offset: 0x0000AF57
		private static void OnNotifyHorizontalOffsetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.CellsPresenter | NotificationTarget.ColumnCollection | NotificationTarget.ColumnHeadersPresenter);
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000CD68 File Offset: 0x0000AF68
		internal void NotifyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e, NotificationTarget target)
		{
			this.NotifyPropertyChanged(d, string.Empty, e, target);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000CD78 File Offset: 0x0000AF78
		internal void NotifyPropertyChanged(DependencyObject d, string propertyName, DependencyPropertyChangedEventArgs e, NotificationTarget target)
		{
			if (DataGridHelper.ShouldNotifyDataGrid(target) && e.Property == DataGrid.AlternatingRowBackgroundProperty)
			{
				base.CoerceValue(ItemsControl.AlternationCountProperty);
			}
			if (DataGridHelper.ShouldNotifyRowSubtree(target))
			{
				for (ContainerTracking<DataGridRow> containerTracking = this._rowTrackingRoot; containerTracking != null; containerTracking = containerTracking.Next)
				{
					containerTracking.Container.NotifyPropertyChanged(d, propertyName, e, target);
				}
			}
			if (DataGridHelper.ShouldNotifyColumnCollection(target) || DataGridHelper.ShouldNotifyColumns(target))
			{
				this.InternalColumns.NotifyPropertyChanged(d, propertyName, e, target);
			}
			if ((DataGridHelper.ShouldNotifyColumnHeadersPresenter(target) || DataGridHelper.ShouldNotifyColumnHeaders(target)) && this.ColumnHeadersPresenter != null)
			{
				this.ColumnHeadersPresenter.NotifyPropertyChanged(d, propertyName, e, target);
			}
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000CE20 File Offset: 0x0000B020
		internal void UpdateColumnsOnVirtualizedCellInfoCollections(NotifyCollectionChangedAction action, int oldDisplayIndex, DataGridColumn oldColumn, int newDisplayIndex)
		{
			using (this.UpdateSelectedCells())
			{
				this._selectedCells.OnColumnsChanged(action, oldDisplayIndex, oldColumn, newDisplayIndex, base.SelectedItems);
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600033D RID: 829 RVA: 0x0000CE68 File Offset: 0x0000B068
		// (set) Token: 0x0600033E RID: 830 RVA: 0x0000CE70 File Offset: 0x0000B070
		internal Microsoft.Windows.Controls.Primitives.DataGridColumnHeadersPresenter ColumnHeadersPresenter
		{
			get
			{
				return this._columnHeadersPresenter;
			}
			set
			{
				this._columnHeadersPresenter = value;
			}
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0000CE79 File Offset: 0x0000B079
		protected override void OnTemplateChanged(ControlTemplate oldTemplate, ControlTemplate newTemplate)
		{
			base.OnTemplateChanged(oldTemplate, newTemplate);
			this.ColumnHeadersPresenter = null;
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000340 RID: 832 RVA: 0x0000CE8A File Offset: 0x0000B08A
		// (set) Token: 0x06000341 RID: 833 RVA: 0x0000CE9C File Offset: 0x0000B09C
		public DataGridGridLinesVisibility GridLinesVisibility
		{
			get
			{
				return (DataGridGridLinesVisibility)base.GetValue(DataGrid.GridLinesVisibilityProperty);
			}
			set
			{
				base.SetValue(DataGrid.GridLinesVisibilityProperty, value);
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000342 RID: 834 RVA: 0x0000CEAF File Offset: 0x0000B0AF
		// (set) Token: 0x06000343 RID: 835 RVA: 0x0000CEC1 File Offset: 0x0000B0C1
		public Brush HorizontalGridLinesBrush
		{
			get
			{
				return (Brush)base.GetValue(DataGrid.HorizontalGridLinesBrushProperty);
			}
			set
			{
				base.SetValue(DataGrid.HorizontalGridLinesBrushProperty, value);
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0000CECF File Offset: 0x0000B0CF
		// (set) Token: 0x06000345 RID: 837 RVA: 0x0000CEE1 File Offset: 0x0000B0E1
		public Brush VerticalGridLinesBrush
		{
			get
			{
				return (Brush)base.GetValue(DataGrid.VerticalGridLinesBrushProperty);
			}
			set
			{
				base.SetValue(DataGrid.VerticalGridLinesBrushProperty, value);
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000346 RID: 838 RVA: 0x0000CEEF File Offset: 0x0000B0EF
		internal double HorizontalGridLineThickness
		{
			get
			{
				return 1.0;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000347 RID: 839 RVA: 0x0000CEFA File Offset: 0x0000B0FA
		internal double VerticalGridLineThickness
		{
			get
			{
				return 1.0;
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000CF05 File Offset: 0x0000B105
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is DataGridRow;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000CF10 File Offset: 0x0000B110
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new DataGridRow();
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000CF18 File Offset: 0x0000B118
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			base.PrepareContainerForItemOverride(element, item);
			DataGridRow dataGridRow = (DataGridRow)element;
			if (dataGridRow.DataGridOwner != this)
			{
				dataGridRow.Tracker.StartTracking(ref this._rowTrackingRoot);
				this.EnsureInternalScrollControls();
			}
			dataGridRow.PrepareRow(item, this);
			this.OnLoadingRow(new DataGridRowEventArgs(dataGridRow));
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0000CF68 File Offset: 0x0000B168
		protected override void ClearContainerForItemOverride(DependencyObject element, object item)
		{
			base.ClearContainerForItemOverride(element, item);
			DataGridRow dataGridRow = (DataGridRow)element;
			if (dataGridRow.DataGridOwner == this)
			{
				dataGridRow.Tracker.StopTracking(ref this._rowTrackingRoot);
			}
			this.OnUnloadingRow(new DataGridRowEventArgs(dataGridRow));
			dataGridRow.ClearRow(this);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000CFB4 File Offset: 0x0000B1B4
		private void UpdateColumnsOnRows(NotifyCollectionChangedEventArgs e)
		{
			for (ContainerTracking<DataGridRow> containerTracking = this._rowTrackingRoot; containerTracking != null; containerTracking = containerTracking.Next)
			{
				containerTracking.Container.OnColumnsChanged(this._columns, e);
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x0600034D RID: 845 RVA: 0x0000CFE6 File Offset: 0x0000B1E6
		// (set) Token: 0x0600034E RID: 846 RVA: 0x0000CFF8 File Offset: 0x0000B1F8
		public Style RowStyle
		{
			get
			{
				return (Style)base.GetValue(DataGrid.RowStyleProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowStyleProperty, value);
			}
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000D006 File Offset: 0x0000B206
		private static void OnRowStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			d.CoerceValue(ItemsControl.ItemContainerStyleProperty);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000D013 File Offset: 0x0000B213
		private static object OnCoerceItemContainerStyle(DependencyObject d, object baseValue)
		{
			if (!DataGridHelper.IsDefaultValue(d, DataGrid.RowStyleProperty))
			{
				return d.GetValue(DataGrid.RowStyleProperty);
			}
			return baseValue;
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000351 RID: 849 RVA: 0x0000D02F File Offset: 0x0000B22F
		// (set) Token: 0x06000352 RID: 850 RVA: 0x0000D041 File Offset: 0x0000B241
		public ControlTemplate RowValidationErrorTemplate
		{
			get
			{
				return (ControlTemplate)base.GetValue(DataGrid.RowValidationErrorTemplateProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowValidationErrorTemplateProperty, value);
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000D04F File Offset: 0x0000B24F
		public ObservableCollection<ValidationRule> RowValidationRules
		{
			get
			{
				return this._rowValidationRules;
			}
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000D058 File Offset: 0x0000B258
		private void OnRowValidationRulesChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			BindingGroup bindingGroup = base.ItemBindingGroup;
			if (bindingGroup == null)
			{
				bindingGroup = (base.ItemBindingGroup = new BindingGroup());
				this._rowValidationBindingGroup = bindingGroup;
			}
			if (this._rowValidationBindingGroup != null)
			{
				if (object.ReferenceEquals(bindingGroup, this._rowValidationBindingGroup))
				{
					switch (e.Action)
					{
					case NotifyCollectionChangedAction.Add:
						using (IEnumerator enumerator = e.NewItems.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								ValidationRule item = (ValidationRule)obj;
								this._rowValidationBindingGroup.ValidationRules.Add(item);
							}
							return;
						}
						break;
					case NotifyCollectionChangedAction.Remove:
						break;
					case NotifyCollectionChangedAction.Replace:
						goto IL_FF;
					case NotifyCollectionChangedAction.Move:
						return;
					case NotifyCollectionChangedAction.Reset:
						goto IL_19C;
					default:
						return;
					}
					using (IEnumerator enumerator2 = e.OldItems.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj2 = enumerator2.Current;
							ValidationRule item2 = (ValidationRule)obj2;
							this._rowValidationBindingGroup.ValidationRules.Remove(item2);
						}
						return;
					}
					IL_FF:
					foreach (object obj3 in e.OldItems)
					{
						ValidationRule item3 = (ValidationRule)obj3;
						this._rowValidationBindingGroup.ValidationRules.Remove(item3);
					}
					using (IEnumerator enumerator4 = e.NewItems.GetEnumerator())
					{
						while (enumerator4.MoveNext())
						{
							object obj4 = enumerator4.Current;
							ValidationRule item4 = (ValidationRule)obj4;
							this._rowValidationBindingGroup.ValidationRules.Add(item4);
						}
						return;
					}
					IL_19C:
					this._rowValidationBindingGroup.ValidationRules.Clear();
					return;
				}
				this._rowValidationBindingGroup = null;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0000D250 File Offset: 0x0000B450
		// (set) Token: 0x06000356 RID: 854 RVA: 0x0000D262 File Offset: 0x0000B462
		public StyleSelector RowStyleSelector
		{
			get
			{
				return (StyleSelector)base.GetValue(DataGrid.RowStyleSelectorProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowStyleSelectorProperty, value);
			}
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000D270 File Offset: 0x0000B470
		private static void OnRowStyleSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			d.CoerceValue(ItemsControl.ItemContainerStyleSelectorProperty);
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000D27D File Offset: 0x0000B47D
		private static object OnCoerceItemContainerStyleSelector(DependencyObject d, object baseValue)
		{
			if (!DataGridHelper.IsDefaultValue(d, DataGrid.RowStyleSelectorProperty))
			{
				return d.GetValue(DataGrid.RowStyleSelectorProperty);
			}
			return baseValue;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000D29C File Offset: 0x0000B49C
		private static object OnCoerceIsSynchronizedWithCurrentItem(DependencyObject d, object baseValue)
		{
			DataGrid dataGrid = (DataGrid)d;
			if (dataGrid.SelectionUnit == DataGridSelectionUnit.Cell)
			{
				return false;
			}
			return baseValue;
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600035A RID: 858 RVA: 0x0000D2C0 File Offset: 0x0000B4C0
		// (set) Token: 0x0600035B RID: 859 RVA: 0x0000D2D2 File Offset: 0x0000B4D2
		public Brush RowBackground
		{
			get
			{
				return (Brush)base.GetValue(DataGrid.RowBackgroundProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowBackgroundProperty, value);
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600035C RID: 860 RVA: 0x0000D2E0 File Offset: 0x0000B4E0
		// (set) Token: 0x0600035D RID: 861 RVA: 0x0000D2F2 File Offset: 0x0000B4F2
		public Brush AlternatingRowBackground
		{
			get
			{
				return (Brush)base.GetValue(DataGrid.AlternatingRowBackgroundProperty);
			}
			set
			{
				base.SetValue(DataGrid.AlternatingRowBackgroundProperty, value);
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000D300 File Offset: 0x0000B500
		private static object OnCoerceAlternationCount(DependencyObject d, object baseValue)
		{
			if ((int)baseValue < 2)
			{
				DataGrid dataGrid = (DataGrid)d;
				if (dataGrid.AlternatingRowBackground != null)
				{
					return 2;
				}
			}
			return baseValue;
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600035F RID: 863 RVA: 0x0000D32D File Offset: 0x0000B52D
		// (set) Token: 0x06000360 RID: 864 RVA: 0x0000D33F File Offset: 0x0000B53F
		public double RowHeight
		{
			get
			{
				return (double)base.GetValue(DataGrid.RowHeightProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowHeightProperty, value);
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000361 RID: 865 RVA: 0x0000D352 File Offset: 0x0000B552
		// (set) Token: 0x06000362 RID: 866 RVA: 0x0000D364 File Offset: 0x0000B564
		public double MinRowHeight
		{
			get
			{
				return (double)base.GetValue(DataGrid.MinRowHeightProperty);
			}
			set
			{
				base.SetValue(DataGrid.MinRowHeightProperty, value);
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0000D377 File Offset: 0x0000B577
		internal Visibility PlaceholderVisibility
		{
			get
			{
				return this._placeholderVisibility;
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000364 RID: 868 RVA: 0x0000D37F File Offset: 0x0000B57F
		// (remove) Token: 0x06000365 RID: 869 RVA: 0x0000D398 File Offset: 0x0000B598
		public event EventHandler<DataGridRowEventArgs> LoadingRow;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000366 RID: 870 RVA: 0x0000D3B1 File Offset: 0x0000B5B1
		// (remove) Token: 0x06000367 RID: 871 RVA: 0x0000D3CA File Offset: 0x0000B5CA
		public event EventHandler<DataGridRowEventArgs> UnloadingRow;

		// Token: 0x06000368 RID: 872 RVA: 0x0000D3E4 File Offset: 0x0000B5E4
		protected virtual void OnLoadingRow(DataGridRowEventArgs e)
		{
			if (this.LoadingRow != null)
			{
				this.LoadingRow(this, e);
			}
			DataGridRow row = e.Row;
			if (row.DetailsVisibility == Visibility.Visible && row.DetailsPresenter != null)
			{
				Dispatcher.CurrentDispatcher.BeginInvoke(new DispatcherOperationCallback(DataGrid.DelayedOnLoadingRowDetails), DispatcherPriority.Loaded, new object[]
				{
					row
				});
			}
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000D444 File Offset: 0x0000B644
		internal static object DelayedOnLoadingRowDetails(object arg)
		{
			DataGridRow dataGridRow = (DataGridRow)arg;
			DataGrid dataGridOwner = dataGridRow.DataGridOwner;
			if (dataGridOwner != null)
			{
				dataGridOwner.OnLoadingRowDetailsWrapper(dataGridRow);
			}
			return null;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000D46C File Offset: 0x0000B66C
		protected virtual void OnUnloadingRow(DataGridRowEventArgs e)
		{
			if (this.UnloadingRow != null)
			{
				this.UnloadingRow(this, e);
			}
			DataGridRow row = e.Row;
			this.OnUnloadingRowDetailsWrapper(row);
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600036B RID: 875 RVA: 0x0000D49C File Offset: 0x0000B69C
		// (set) Token: 0x0600036C RID: 876 RVA: 0x0000D4AE File Offset: 0x0000B6AE
		public double RowHeaderWidth
		{
			get
			{
				return (double)base.GetValue(DataGrid.RowHeaderWidthProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowHeaderWidthProperty, value);
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600036D RID: 877 RVA: 0x0000D4C1 File Offset: 0x0000B6C1
		// (set) Token: 0x0600036E RID: 878 RVA: 0x0000D4D3 File Offset: 0x0000B6D3
		public double RowHeaderActualWidth
		{
			get
			{
				return (double)base.GetValue(DataGrid.RowHeaderActualWidthProperty);
			}
			internal set
			{
				base.SetValue(DataGrid.RowHeaderActualWidthPropertyKey, value);
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600036F RID: 879 RVA: 0x0000D4E6 File Offset: 0x0000B6E6
		// (set) Token: 0x06000370 RID: 880 RVA: 0x0000D4F8 File Offset: 0x0000B6F8
		public double ColumnHeaderHeight
		{
			get
			{
				return (double)base.GetValue(DataGrid.ColumnHeaderHeightProperty);
			}
			set
			{
				base.SetValue(DataGrid.ColumnHeaderHeightProperty, value);
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000371 RID: 881 RVA: 0x0000D50B File Offset: 0x0000B70B
		// (set) Token: 0x06000372 RID: 882 RVA: 0x0000D51D File Offset: 0x0000B71D
		public DataGridHeadersVisibility HeadersVisibility
		{
			get
			{
				return (DataGridHeadersVisibility)base.GetValue(DataGrid.HeadersVisibilityProperty);
			}
			set
			{
				base.SetValue(DataGrid.HeadersVisibilityProperty, value);
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000D530 File Offset: 0x0000B730
		private static void OnNotifyRowHeaderWidthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)d;
			double num = (double)e.NewValue;
			if (!DoubleUtil.IsNaN(num))
			{
				dataGrid.RowHeaderActualWidth = num;
			}
			else
			{
				dataGrid.RowHeaderActualWidth = 0.0;
			}
			DataGrid.OnNotifyRowHeaderPropertyChanged(d, e);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000D578 File Offset: 0x0000B778
		private void ResetRowHeaderActualWidth()
		{
			if (DoubleUtil.IsNaN(this.RowHeaderWidth))
			{
				this.RowHeaderActualWidth = 0.0;
			}
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000D598 File Offset: 0x0000B798
		public void SetDetailsVisibilityForItem(object item, Visibility detailsVisibility)
		{
			this._itemAttachedStorage.SetValue(item, DataGridRow.DetailsVisibilityProperty, detailsVisibility);
			DataGridRow dataGridRow = (DataGridRow)base.ItemContainerGenerator.ContainerFromItem(item);
			if (dataGridRow != null)
			{
				dataGridRow.DetailsVisibility = detailsVisibility;
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000D5D8 File Offset: 0x0000B7D8
		public Visibility GetDetailsVisibilityForItem(object item)
		{
			object obj;
			if (this._itemAttachedStorage.TryGetValue(item, DataGridRow.DetailsVisibilityProperty, out obj))
			{
				return (Visibility)obj;
			}
			DataGridRow dataGridRow = (DataGridRow)base.ItemContainerGenerator.ContainerFromItem(item);
			if (dataGridRow != null)
			{
				return dataGridRow.DetailsVisibility;
			}
			switch (this.RowDetailsVisibilityMode)
			{
			case DataGridRowDetailsVisibilityMode.Visible:
				return Visibility.Visible;
			case DataGridRowDetailsVisibilityMode.VisibleWhenSelected:
				if (!base.SelectedItems.Contains(item))
				{
					return Visibility.Collapsed;
				}
				return Visibility.Visible;
			default:
				return Visibility.Collapsed;
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000D64C File Offset: 0x0000B84C
		public void ClearDetailsVisibilityForItem(object item)
		{
			this._itemAttachedStorage.ClearValue(item, DataGridRow.DetailsVisibilityProperty);
			DataGridRow dataGridRow = (DataGridRow)base.ItemContainerGenerator.ContainerFromItem(item);
			if (dataGridRow != null)
			{
				dataGridRow.ClearValue(DataGridRow.DetailsVisibilityProperty);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0000D68A File Offset: 0x0000B88A
		internal DataGridItemAttachedStorage ItemAttachedStorage
		{
			get
			{
				return this._itemAttachedStorage;
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000379 RID: 889 RVA: 0x0000D694 File Offset: 0x0000B894
		private bool ShouldSelectRowHeader
		{
			get
			{
				return this._selectionAnchor != null && base.SelectedItems.Contains(this._selectionAnchor.Value.Item) && this.SelectionUnit == DataGridSelectionUnit.CellOrRowHeader && (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600037A RID: 890 RVA: 0x0000D6E3 File Offset: 0x0000B8E3
		// (set) Token: 0x0600037B RID: 891 RVA: 0x0000D6F5 File Offset: 0x0000B8F5
		public Style CellStyle
		{
			get
			{
				return (Style)base.GetValue(DataGrid.CellStyleProperty);
			}
			set
			{
				base.SetValue(DataGrid.CellStyleProperty, value);
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600037C RID: 892 RVA: 0x0000D703 File Offset: 0x0000B903
		// (set) Token: 0x0600037D RID: 893 RVA: 0x0000D715 File Offset: 0x0000B915
		public Style ColumnHeaderStyle
		{
			get
			{
				return (Style)base.GetValue(DataGrid.ColumnHeaderStyleProperty);
			}
			set
			{
				base.SetValue(DataGrid.ColumnHeaderStyleProperty, value);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600037E RID: 894 RVA: 0x0000D723 File Offset: 0x0000B923
		// (set) Token: 0x0600037F RID: 895 RVA: 0x0000D735 File Offset: 0x0000B935
		public Style RowHeaderStyle
		{
			get
			{
				return (Style)base.GetValue(DataGrid.RowHeaderStyleProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowHeaderStyleProperty, value);
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000380 RID: 896 RVA: 0x0000D743 File Offset: 0x0000B943
		// (set) Token: 0x06000381 RID: 897 RVA: 0x0000D755 File Offset: 0x0000B955
		public DataTemplate RowHeaderTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(DataGrid.RowHeaderTemplateProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowHeaderTemplateProperty, value);
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000382 RID: 898 RVA: 0x0000D763 File Offset: 0x0000B963
		// (set) Token: 0x06000383 RID: 899 RVA: 0x0000D775 File Offset: 0x0000B975
		public DataTemplateSelector RowHeaderTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(DataGrid.RowHeaderTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowHeaderTemplateSelectorProperty, value);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000384 RID: 900 RVA: 0x0000D783 File Offset: 0x0000B983
		public static ComponentResourceKey FocusBorderBrushKey
		{
			get
			{
				if (DataGrid._focusBorderBrushKey == null)
				{
					DataGrid._focusBorderBrushKey = new ComponentResourceKey(typeof(DataGrid), "FocusBorderBrushKey");
				}
				return DataGrid._focusBorderBrushKey;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0000D7AA File Offset: 0x0000B9AA
		public static IValueConverter HeadersVisibilityConverter
		{
			get
			{
				if (DataGrid._headersVisibilityConverter == null)
				{
					DataGrid._headersVisibilityConverter = new DataGridHeadersVisibilityToVisibilityConverter();
				}
				return DataGrid._headersVisibilityConverter;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000386 RID: 902 RVA: 0x0000D7C2 File Offset: 0x0000B9C2
		public static IValueConverter RowDetailsScrollingConverter
		{
			get
			{
				if (DataGrid._rowDetailsScrollingConverter == null)
				{
					DataGrid._rowDetailsScrollingConverter = new BooleanToSelectiveScrollingOrientationConverter();
				}
				return DataGrid._rowDetailsScrollingConverter;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000387 RID: 903 RVA: 0x0000D7DA File Offset: 0x0000B9DA
		// (set) Token: 0x06000388 RID: 904 RVA: 0x0000D7EC File Offset: 0x0000B9EC
		public ScrollBarVisibility HorizontalScrollBarVisibility
		{
			get
			{
				return (ScrollBarVisibility)base.GetValue(DataGrid.HorizontalScrollBarVisibilityProperty);
			}
			set
			{
				base.SetValue(DataGrid.HorizontalScrollBarVisibilityProperty, value);
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000389 RID: 905 RVA: 0x0000D7FF File Offset: 0x0000B9FF
		// (set) Token: 0x0600038A RID: 906 RVA: 0x0000D811 File Offset: 0x0000BA11
		public ScrollBarVisibility VerticalScrollBarVisibility
		{
			get
			{
				return (ScrollBarVisibility)base.GetValue(DataGrid.VerticalScrollBarVisibilityProperty);
			}
			set
			{
				base.SetValue(DataGrid.VerticalScrollBarVisibilityProperty, value);
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000D824 File Offset: 0x0000BA24
		public void ScrollIntoView(object item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			if (base.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
			{
				this.ScrollRowIntoView(item);
				return;
			}
			base.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new DispatcherOperationCallback(this.OnScrollIntoView), item);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000D864 File Offset: 0x0000BA64
		public void ScrollIntoView(object item, DataGridColumn column)
		{
			if (column == null)
			{
				this.ScrollIntoView(item);
				return;
			}
			if (!column.IsVisible)
			{
				return;
			}
			if (base.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
			{
				base.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new DispatcherOperationCallback(this.OnScrollIntoView), new object[]
				{
					item,
					column
				});
				return;
			}
			if (item == null)
			{
				this.ScrollColumnIntoView(column);
				return;
			}
			this.ScrollCellIntoView(item, column);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000D8D0 File Offset: 0x0000BAD0
		private object OnScrollIntoView(object arg)
		{
			object[] array = arg as object[];
			if (array != null)
			{
				if (array[0] != null)
				{
					this.ScrollCellIntoView(array[0], (DataGridColumn)array[1]);
				}
				else
				{
					this.ScrollColumnIntoView((DataGridColumn)array[1]);
				}
			}
			else
			{
				this.ScrollRowIntoView(arg);
			}
			return null;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000D918 File Offset: 0x0000BB18
		private void ScrollColumnIntoView(DataGridColumn column)
		{
			if (this._rowTrackingRoot != null)
			{
				DataGridRow container = this._rowTrackingRoot.Container;
				if (container != null)
				{
					int index = this._columns.IndexOf(column);
					container.ScrollCellIntoView(index);
				}
			}
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000D950 File Offset: 0x0000BB50
		private void ScrollRowIntoView(object item)
		{
			FrameworkElement frameworkElement = base.ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
			if (frameworkElement != null)
			{
				frameworkElement.BringIntoView();
				return;
			}
			if (!base.IsGrouping)
			{
				int num = base.Items.IndexOf(item);
				if (num >= 0)
				{
					Microsoft.Windows.Controls.Primitives.DataGridRowsPresenter dataGridRowsPresenter = this.InternalItemsHost as Microsoft.Windows.Controls.Primitives.DataGridRowsPresenter;
					if (dataGridRowsPresenter != null)
					{
						dataGridRowsPresenter.InternalBringIndexIntoView(num);
					}
				}
			}
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000D9A8 File Offset: 0x0000BBA8
		private void ScrollCellIntoView(object item, DataGridColumn column)
		{
			if (!column.IsVisible)
			{
				return;
			}
			DataGridRow dataGridRow = base.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
			if (dataGridRow == null)
			{
				this.ScrollRowIntoView(item);
				base.UpdateLayout();
				dataGridRow = (base.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow);
			}
			else
			{
				dataGridRow.BringIntoView();
			}
			if (dataGridRow != null)
			{
				int index = this._columns.IndexOf(column);
				dataGridRow.ScrollCellIntoView(index);
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0000DA11 File Offset: 0x0000BC11
		protected override void OnIsMouseCapturedChanged(DependencyPropertyChangedEventArgs e)
		{
			if (!base.IsMouseCaptured)
			{
				this.StopAutoScroll();
			}
			base.OnIsMouseCapturedChanged(e);
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000392 RID: 914 RVA: 0x0000DA28 File Offset: 0x0000BC28
		private static TimeSpan AutoScrollTimeout
		{
			get
			{
				return TimeSpan.FromMilliseconds((double)NativeMethods.GetDoubleClickTime() * 0.8);
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000DA40 File Offset: 0x0000BC40
		private void StartAutoScroll()
		{
			if (this._autoScrollTimer == null)
			{
				this._hasAutoScrolled = false;
				this._autoScrollTimer = new DispatcherTimer(DispatcherPriority.SystemIdle);
				this._autoScrollTimer.Interval = DataGrid.AutoScrollTimeout;
				this._autoScrollTimer.Tick += this.OnAutoScrollTimeout;
				this._autoScrollTimer.Start();
			}
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0000DA9A File Offset: 0x0000BC9A
		private void StopAutoScroll()
		{
			if (this._autoScrollTimer != null)
			{
				this._autoScrollTimer.Stop();
				this._autoScrollTimer = null;
				this._hasAutoScrolled = false;
			}
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000DABD File Offset: 0x0000BCBD
		private void OnAutoScrollTimeout(object sender, EventArgs e)
		{
			if (Mouse.LeftButton == MouseButtonState.Pressed)
			{
				this.DoAutoScroll();
				return;
			}
			this.StopAutoScroll();
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0000DAD8 File Offset: 0x0000BCD8
		private bool DoAutoScroll()
		{
			DataGrid.RelativeMousePositions relativeMousePosition = this.RelativeMousePosition;
			if (relativeMousePosition != DataGrid.RelativeMousePositions.Over)
			{
				DataGridCell dataGridCell = this.GetCellNearMouse();
				if (dataGridCell != null)
				{
					DataGridColumn dataGridColumn = dataGridCell.Column;
					object obj = dataGridCell.RowDataItem;
					if (DataGrid.IsMouseToLeft(relativeMousePosition))
					{
						int displayIndex = dataGridColumn.DisplayIndex;
						if (displayIndex > 0)
						{
							dataGridColumn = this.ColumnFromDisplayIndex(displayIndex - 1);
						}
					}
					else if (DataGrid.IsMouseToRight(relativeMousePosition))
					{
						int displayIndex2 = dataGridColumn.DisplayIndex;
						if (displayIndex2 < this._columns.Count - 1)
						{
							dataGridColumn = this.ColumnFromDisplayIndex(displayIndex2 + 1);
						}
					}
					if (DataGrid.IsMouseAbove(relativeMousePosition))
					{
						int num = base.Items.IndexOf(obj);
						if (num > 0)
						{
							obj = base.Items[num - 1];
						}
					}
					else if (DataGrid.IsMouseBelow(relativeMousePosition))
					{
						int num2 = base.Items.IndexOf(obj);
						if (num2 < base.Items.Count - 1)
						{
							obj = base.Items[num2 + 1];
						}
					}
					if (this._isRowDragging)
					{
						this.ScrollRowIntoView(obj);
						DataGridRow dataGridRow = (DataGridRow)base.ItemContainerGenerator.ContainerFromItem(obj);
						if (dataGridRow != null)
						{
							this._hasAutoScrolled = true;
							this.HandleSelectionForRowHeaderAndDetailsInput(dataGridRow, false);
							this.CurrentItem = obj;
							return true;
						}
					}
					else
					{
						this.ScrollCellIntoView(obj, dataGridColumn);
						dataGridCell = this.TryFindCell(obj, dataGridColumn);
						if (dataGridCell != null)
						{
							this._hasAutoScrolled = true;
							this.HandleSelectionForCellInput(dataGridCell, false, true, true);
							dataGridCell.Focus();
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000397 RID: 919 RVA: 0x0000DC2D File Offset: 0x0000BE2D
		protected override bool HandlesScrolling
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000398 RID: 920 RVA: 0x0000DC30 File Offset: 0x0000BE30
		// (set) Token: 0x06000399 RID: 921 RVA: 0x0000DC38 File Offset: 0x0000BE38
		internal Panel InternalItemsHost
		{
			get
			{
				return this._internalItemsHost;
			}
			set
			{
				if (this._internalItemsHost != value)
				{
					this._internalItemsHost = value;
					if (this._internalItemsHost != null)
					{
						this.EnsureInternalScrollControls();
					}
				}
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600039A RID: 922 RVA: 0x0000DC58 File Offset: 0x0000BE58
		internal ScrollViewer InternalScrollHost
		{
			get
			{
				this.EnsureInternalScrollControls();
				return this._internalScrollHost;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600039B RID: 923 RVA: 0x0000DC66 File Offset: 0x0000BE66
		internal ScrollContentPresenter InternalScrollContentPresenter
		{
			get
			{
				this.EnsureInternalScrollControls();
				return this._internalScrollContentPresenter;
			}
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0000DC74 File Offset: 0x0000BE74
		private void EnsureInternalScrollControls()
		{
			if (this._internalScrollContentPresenter == null)
			{
				if (this._internalItemsHost != null)
				{
					this._internalScrollContentPresenter = DataGridHelper.FindVisualParent<ScrollContentPresenter>(this._internalItemsHost);
				}
				else if (this._rowTrackingRoot != null)
				{
					DataGridRow container = this._rowTrackingRoot.Container;
					this._internalScrollContentPresenter = DataGridHelper.FindVisualParent<ScrollContentPresenter>(container);
				}
				if (this._internalScrollContentPresenter != null)
				{
					this._internalScrollContentPresenter.SizeChanged += this.OnInternalScrollContentPresenterSizeChanged;
				}
			}
			if (this._internalScrollHost == null)
			{
				if (this._internalItemsHost != null)
				{
					this._internalScrollHost = DataGridHelper.FindVisualParent<ScrollViewer>(this._internalItemsHost);
				}
				else if (this._rowTrackingRoot != null)
				{
					DataGridRow container2 = this._rowTrackingRoot.Container;
					this._internalScrollHost = DataGridHelper.FindVisualParent<ScrollViewer>(container2);
				}
				if (this._internalScrollHost != null)
				{
					Binding binding = new Binding("ContentHorizontalOffset");
					binding.Source = this._internalScrollHost;
					base.SetBinding(DataGrid.HorizontalScrollOffsetProperty, binding);
				}
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0000DD52 File Offset: 0x0000BF52
		private void CleanUpInternalScrollControls()
		{
			BindingOperations.ClearBinding(this, DataGrid.HorizontalScrollOffsetProperty);
			this._internalScrollHost = null;
			if (this._internalScrollContentPresenter != null)
			{
				this._internalScrollContentPresenter.SizeChanged -= this.OnInternalScrollContentPresenterSizeChanged;
				this._internalScrollContentPresenter = null;
			}
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0000DD8C File Offset: 0x0000BF8C
		private void OnInternalScrollContentPresenterSizeChanged(object sender, SizeChangedEventArgs e)
		{
			if (this._internalScrollContentPresenter != null && !this._internalScrollContentPresenter.CanContentScroll)
			{
				this.OnViewportSizeChanged(e.PreviousSize, e.NewSize);
			}
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0000DDB8 File Offset: 0x0000BFB8
		internal void OnViewportSizeChanged(Size oldSize, Size newSize)
		{
			if (!this.InternalColumns.ColumnWidthsComputationPending)
			{
				double value = newSize.Width - oldSize.Width;
				if (!DoubleUtil.AreClose(value, 0.0))
				{
					this._finalViewportWidth = newSize.Width;
					if (!this._viewportWidthChangeNotificationPending)
					{
						this._originalViewportWidth = oldSize.Width;
						base.Dispatcher.BeginInvoke(new DispatcherOperationCallback(this.OnDelayedViewportWidthChanged), DispatcherPriority.Loaded, new object[]
						{
							this
						});
						this._viewportWidthChangeNotificationPending = true;
					}
				}
			}
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0000DE44 File Offset: 0x0000C044
		private object OnDelayedViewportWidthChanged(object args)
		{
			if (!this._viewportWidthChangeNotificationPending)
			{
				return null;
			}
			double num = this._finalViewportWidth - this._originalViewportWidth;
			if (!DoubleUtil.AreClose(num, 0.0))
			{
				this.NotifyPropertyChanged(this, "ViewportWidth", default(DependencyPropertyChangedEventArgs), NotificationTarget.CellsPresenter | NotificationTarget.ColumnCollection | NotificationTarget.ColumnHeadersPresenter);
				double num2 = this._finalViewportWidth;
				num2 -= this.CellsPanelHorizontalOffset;
				this.InternalColumns.RedistributeColumnWidthsOnAvailableSpaceChange(num, num2);
			}
			this._viewportWidthChangeNotificationPending = false;
			return null;
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x0000DEB6 File Offset: 0x0000C0B6
		internal double HorizontalScrollOffset
		{
			get
			{
				return (double)base.GetValue(DataGrid.HorizontalScrollOffsetProperty);
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x0000DEC8 File Offset: 0x0000C0C8
		public static RoutedUICommand DeleteCommand
		{
			get
			{
				return ApplicationCommands.Delete;
			}
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0000DECF File Offset: 0x0000C0CF
		private static void OnCanExecuteBeginEdit(object sender, CanExecuteRoutedEventArgs e)
		{
			((DataGrid)sender).OnCanExecuteBeginEdit(e);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0000DEDD File Offset: 0x0000C0DD
		private static void OnExecutedBeginEdit(object sender, ExecutedRoutedEventArgs e)
		{
			((DataGrid)sender).OnExecutedBeginEdit(e);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0000DEEC File Offset: 0x0000C0EC
		protected virtual void OnCanExecuteBeginEdit(CanExecuteRoutedEventArgs e)
		{
			bool flag = !this.IsReadOnly && this.CurrentCellContainer != null && !this.IsEditingCurrentCell && !this.IsCurrentCellReadOnly && !this.HasCellValidationError;
			if (flag && this.HasRowValidationError)
			{
				DataGridCell eventCellOrCurrentCell = this.GetEventCellOrCurrentCell(e);
				if (eventCellOrCurrentCell != null)
				{
					object rowDataItem = eventCellOrCurrentCell.RowDataItem;
					flag = this.IsAddingOrEditingRowItem(rowDataItem);
				}
				else
				{
					flag = false;
				}
			}
			if (flag)
			{
				e.CanExecute = true;
				e.Handled = true;
				return;
			}
			e.ContinueRouting = true;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000DF68 File Offset: 0x0000C168
		protected virtual void OnExecutedBeginEdit(ExecutedRoutedEventArgs e)
		{
			DataGridCell currentCellContainer = this.CurrentCellContainer;
			if (currentCellContainer != null && !currentCellContainer.IsReadOnly && !currentCellContainer.IsEditing)
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				List<int> list = null;
				int num = -1;
				object obj = null;
				bool flag4 = this.EditableItems.NewItemPlaceholderPosition == NewItemPlaceholderPosition.AtBeginning;
				if (this.IsNewItemPlaceholder(currentCellContainer.RowDataItem))
				{
					if (base.SelectedItems.Contains(CollectionView.NewItemPlaceholder))
					{
						this.UnselectItem(CollectionView.NewItemPlaceholder);
						flag2 = true;
					}
					else
					{
						num = base.Items.IndexOf(currentCellContainer.RowDataItem);
						flag3 = (num >= 0 && this._selectedCells.Intersects(num, out list));
					}
					obj = this.AddNewItem();
					this.CurrentItem = obj;
					currentCellContainer = this.CurrentCellContainer;
					if (this.CurrentCellContainer == null)
					{
						base.UpdateLayout();
						currentCellContainer = this.CurrentCellContainer;
						if (currentCellContainer != null && !currentCellContainer.IsKeyboardFocusWithin)
						{
							currentCellContainer.Focus();
						}
					}
					if (flag2)
					{
						this.SelectItem(obj);
					}
					else if (flag3)
					{
						using (this.UpdateSelectedCells())
						{
							int num2 = num;
							if (flag4)
							{
								this._selectedCells.RemoveRegion(num, 0, 1, this.Columns.Count);
								num2++;
							}
							int i = 0;
							int count = list.Count;
							while (i < count)
							{
								this._selectedCells.AddRegion(num2, list[i], 1, list[i + 1]);
								i += 2;
							}
						}
					}
					flag = true;
				}
				RoutedEventArgs routedEventArgs = e.Parameter as RoutedEventArgs;
				DataGridBeginningEditEventArgs dataGridBeginningEditEventArgs = null;
				if (currentCellContainer != null)
				{
					dataGridBeginningEditEventArgs = new DataGridBeginningEditEventArgs(currentCellContainer.Column, currentCellContainer.RowOwner, routedEventArgs);
					this.OnBeginningEdit(dataGridBeginningEditEventArgs);
				}
				if (currentCellContainer == null || dataGridBeginningEditEventArgs.Cancel)
				{
					if (flag2)
					{
						this.UnselectItem(obj);
					}
					else if (flag3 && flag4)
					{
						this._selectedCells.RemoveRegion(num + 1, 0, 1, this.Columns.Count);
					}
					if (flag)
					{
						this.CancelRowItem();
						this.UpdateNewItemPlaceholder(false);
						this.SetCurrentItemToPlaceholder();
					}
					if (flag2)
					{
						this.SelectItem(CollectionView.NewItemPlaceholder);
					}
					else if (flag3)
					{
						int j = 0;
						int count2 = list.Count;
						while (j < count2)
						{
							this._selectedCells.AddRegion(num, list[j], 1, list[j + 1]);
							j += 2;
						}
					}
				}
				else
				{
					if (!flag && !this.IsEditingRowItem)
					{
						this.EditRowItem(currentCellContainer.RowDataItem);
						BindingGroup bindingGroup = currentCellContainer.RowOwner.BindingGroup;
						if (bindingGroup != null)
						{
							bindingGroup.BeginEdit();
						}
						this._editingRowItem = currentCellContainer.RowDataItem;
						this._editingRowIndex = base.Items.IndexOf(this._editingRowItem);
					}
					currentCellContainer.BeginEdit(routedEventArgs);
					currentCellContainer.RowOwner.IsEditing = true;
				}
			}
			CommandManager.InvalidateRequerySuggested();
			e.Handled = true;
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000E23C File Offset: 0x0000C43C
		private static void OnCanExecuteCommitEdit(object sender, CanExecuteRoutedEventArgs e)
		{
			((DataGrid)sender).OnCanExecuteCommitEdit(e);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000E24A File Offset: 0x0000C44A
		private static void OnExecutedCommitEdit(object sender, ExecutedRoutedEventArgs e)
		{
			((DataGrid)sender).OnExecutedCommitEdit(e);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0000E258 File Offset: 0x0000C458
		private DataGridCell GetEventCellOrCurrentCell(RoutedEventArgs e)
		{
			UIElement uielement = e.OriginalSource as UIElement;
			if (uielement != this && uielement != null)
			{
				return DataGridHelper.FindVisualParent<DataGridCell>(uielement);
			}
			return this.CurrentCellContainer;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000E288 File Offset: 0x0000C488
		private bool CanEndEdit(CanExecuteRoutedEventArgs e, bool commit)
		{
			DataGridCell eventCellOrCurrentCell = this.GetEventCellOrCurrentCell(e);
			if (eventCellOrCurrentCell == null)
			{
				return false;
			}
			DataGridEditingUnit editingUnit = this.GetEditingUnit(e.Parameter);
			IEditableCollectionView editableItems = this.EditableItems;
			object rowDataItem = eventCellOrCurrentCell.RowDataItem;
			return eventCellOrCurrentCell.IsEditing || (editingUnit == DataGridEditingUnit.Row && !this.HasCellValidationError && ((editableItems.IsAddingNew && editableItems.CurrentAddItem == rowDataItem) || (editableItems.IsEditingItem && (commit || editableItems.CanCancelEdit || this.HasRowValidationError) && editableItems.CurrentEditItem == rowDataItem)));
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000E30E File Offset: 0x0000C50E
		protected virtual void OnCanExecuteCommitEdit(CanExecuteRoutedEventArgs e)
		{
			if (this.CanEndEdit(e, true))
			{
				e.CanExecute = true;
				e.Handled = true;
				return;
			}
			e.ContinueRouting = true;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000E330 File Offset: 0x0000C530
		protected virtual void OnExecutedCommitEdit(ExecutedRoutedEventArgs e)
		{
			DataGridCell currentCellContainer = this.CurrentCellContainer;
			bool flag = true;
			if (currentCellContainer != null)
			{
				DataGridEditingUnit editingUnit = this.GetEditingUnit(e.Parameter);
				bool flag2 = false;
				if (currentCellContainer.IsEditing)
				{
					DataGridCellEditEndingEventArgs dataGridCellEditEndingEventArgs = new DataGridCellEditEndingEventArgs(currentCellContainer.Column, currentCellContainer.RowOwner, currentCellContainer.EditingElement, DataGridEditAction.Commit);
					this.OnCellEditEnding(dataGridCellEditEndingEventArgs);
					flag2 = dataGridCellEditEndingEventArgs.Cancel;
					if (!flag2)
					{
						flag = currentCellContainer.CommitEdit();
						this.HasCellValidationError = !flag;
					}
				}
				if (flag && !flag2 && ((editingUnit == DataGridEditingUnit.Row && this.IsAddingOrEditingRowItem(currentCellContainer.RowDataItem)) || (!this.EditableItems.CanCancelEdit && this.IsEditingItem(currentCellContainer.RowDataItem))))
				{
					DataGridRowEditEndingEventArgs dataGridRowEditEndingEventArgs = new DataGridRowEditEndingEventArgs(currentCellContainer.RowOwner, DataGridEditAction.Commit);
					this.OnRowEditEnding(dataGridRowEditEndingEventArgs);
					if (!dataGridRowEditEndingEventArgs.Cancel)
					{
						BindingGroup bindingGroup = currentCellContainer.RowOwner.BindingGroup;
						if (bindingGroup != null)
						{
							base.Dispatcher.Invoke(new DispatcherOperationCallback(DataGrid.DoNothing), DispatcherPriority.DataBind, new object[]
							{
								bindingGroup
							});
							flag = bindingGroup.CommitEdit();
						}
						this.HasRowValidationError = !flag;
						if (flag)
						{
							this.CommitRowItem();
						}
					}
				}
				if (flag)
				{
					this.UpdateRowEditing(currentCellContainer);
				}
				CommandManager.InvalidateRequerySuggested();
			}
			e.Handled = true;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0000E467 File Offset: 0x0000C667
		private static object DoNothing(object arg)
		{
			return null;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000E46A File Offset: 0x0000C66A
		private DataGridEditingUnit GetEditingUnit(object parameter)
		{
			if (parameter != null && parameter is DataGridEditingUnit)
			{
				return (DataGridEditingUnit)parameter;
			}
			if (!this.IsEditingCurrentCell)
			{
				return DataGridEditingUnit.Row;
			}
			return DataGridEditingUnit.Cell;
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060003AF RID: 943 RVA: 0x0000E489 File Offset: 0x0000C689
		// (remove) Token: 0x060003B0 RID: 944 RVA: 0x0000E4A2 File Offset: 0x0000C6A2
		public event EventHandler<DataGridRowEditEndingEventArgs> RowEditEnding;

		// Token: 0x060003B1 RID: 945 RVA: 0x0000E4BC File Offset: 0x0000C6BC
		protected virtual void OnRowEditEnding(DataGridRowEditEndingEventArgs e)
		{
			if (this.RowEditEnding != null)
			{
				this.RowEditEnding(this, e);
			}
			if (AutomationPeer.ListenerExists(AutomationEvents.InvokePatternOnInvoked))
			{
				Microsoft.Windows.Automation.Peers.DataGridAutomationPeer dataGridAutomationPeer = UIElementAutomationPeer.FromElement(this) as Microsoft.Windows.Automation.Peers.DataGridAutomationPeer;
				if (dataGridAutomationPeer != null)
				{
					dataGridAutomationPeer.RaiseAutomationRowInvokeEvents(e.Row);
				}
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060003B2 RID: 946 RVA: 0x0000E501 File Offset: 0x0000C701
		// (remove) Token: 0x060003B3 RID: 947 RVA: 0x0000E51A File Offset: 0x0000C71A
		public event EventHandler<DataGridCellEditEndingEventArgs> CellEditEnding;

		// Token: 0x060003B4 RID: 948 RVA: 0x0000E534 File Offset: 0x0000C734
		protected virtual void OnCellEditEnding(DataGridCellEditEndingEventArgs e)
		{
			if (this.CellEditEnding != null)
			{
				this.CellEditEnding(this, e);
			}
			if (AutomationPeer.ListenerExists(AutomationEvents.InvokePatternOnInvoked))
			{
				Microsoft.Windows.Automation.Peers.DataGridAutomationPeer dataGridAutomationPeer = UIElementAutomationPeer.FromElement(this) as Microsoft.Windows.Automation.Peers.DataGridAutomationPeer;
				if (dataGridAutomationPeer != null)
				{
					dataGridAutomationPeer.RaiseAutomationCellInvokeEvents(e.Column, e.Row);
				}
			}
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000E57F File Offset: 0x0000C77F
		private static void OnCanExecuteCancelEdit(object sender, CanExecuteRoutedEventArgs e)
		{
			((DataGrid)sender).OnCanExecuteCancelEdit(e);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000E58D File Offset: 0x0000C78D
		private static void OnExecutedCancelEdit(object sender, ExecutedRoutedEventArgs e)
		{
			((DataGrid)sender).OnExecutedCancelEdit(e);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000E59B File Offset: 0x0000C79B
		protected virtual void OnCanExecuteCancelEdit(CanExecuteRoutedEventArgs e)
		{
			if (this.CanEndEdit(e, false))
			{
				e.CanExecute = true;
				e.Handled = true;
				return;
			}
			e.ContinueRouting = true;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000E5C0 File Offset: 0x0000C7C0
		protected virtual void OnExecutedCancelEdit(ExecutedRoutedEventArgs e)
		{
			DataGridCell currentCellContainer = this.CurrentCellContainer;
			if (currentCellContainer != null)
			{
				DataGridEditingUnit editingUnit = this.GetEditingUnit(e.Parameter);
				bool flag = false;
				if (currentCellContainer.IsEditing)
				{
					DataGridCellEditEndingEventArgs dataGridCellEditEndingEventArgs = new DataGridCellEditEndingEventArgs(currentCellContainer.Column, currentCellContainer.RowOwner, currentCellContainer.EditingElement, DataGridEditAction.Cancel);
					this.OnCellEditEnding(dataGridCellEditEndingEventArgs);
					flag = dataGridCellEditEndingEventArgs.Cancel;
					if (!flag)
					{
						currentCellContainer.CancelEdit();
						this.HasCellValidationError = false;
					}
				}
				IEditableCollectionView editableItems = this.EditableItems;
				bool flag2 = this.IsEditingItem(currentCellContainer.RowDataItem) && !editableItems.CanCancelEdit;
				if (!flag && (this.CanCancelAddingOrEditingRowItem(editingUnit, currentCellContainer.RowDataItem) || flag2))
				{
					bool flag3 = true;
					if (!flag2)
					{
						DataGridRowEditEndingEventArgs dataGridRowEditEndingEventArgs = new DataGridRowEditEndingEventArgs(currentCellContainer.RowOwner, DataGridEditAction.Cancel);
						this.OnRowEditEnding(dataGridRowEditEndingEventArgs);
						flag3 = !dataGridRowEditEndingEventArgs.Cancel;
					}
					if (flag3)
					{
						if (flag2)
						{
							editableItems.CommitEdit();
						}
						else
						{
							this.CancelRowItem();
						}
						BindingGroup bindingGroup = currentCellContainer.RowOwner.BindingGroup;
						if (bindingGroup != null)
						{
							bindingGroup.CancelEdit();
							bindingGroup.UpdateSources();
						}
					}
				}
				this.UpdateRowEditing(currentCellContainer);
				if (!currentCellContainer.RowOwner.IsEditing)
				{
					this.HasRowValidationError = false;
				}
				CommandManager.InvalidateRequerySuggested();
			}
			e.Handled = true;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0000E6EA File Offset: 0x0000C8EA
		private static void OnCanExecuteDelete(object sender, CanExecuteRoutedEventArgs e)
		{
			((DataGrid)sender).OnCanExecuteDelete(e);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0000E6F8 File Offset: 0x0000C8F8
		private static void OnExecutedDelete(object sender, ExecutedRoutedEventArgs e)
		{
			((DataGrid)sender).OnExecutedDelete(e);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000E706 File Offset: 0x0000C906
		protected virtual void OnCanExecuteDelete(CanExecuteRoutedEventArgs e)
		{
			e.CanExecute = (this.CanUserDeleteRows && this.DataItemsSelected > 0 && (this._currentCellContainer == null || !this._currentCellContainer.IsEditing));
			e.Handled = true;
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0000E744 File Offset: 0x0000C944
		protected virtual void OnExecutedDelete(ExecutedRoutedEventArgs e)
		{
			if (this.DataItemsSelected > 0)
			{
				bool flag = false;
				bool isEditingRowItem = this.IsEditingRowItem;
				if (isEditingRowItem || this.IsAddingNewItem)
				{
					if (this.CancelEdit(DataGridEditingUnit.Row) && isEditingRowItem)
					{
						flag = true;
					}
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					int count = base.SelectedItems.Count;
					int num = -1;
					object currentItem = this.CurrentItem;
					if (base.SelectedItems.Contains(currentItem))
					{
						num = base.Items.IndexOf(currentItem);
						if (this._selectionAnchor != null)
						{
							int num2 = base.Items.IndexOf(this._selectionAnchor.Value.Item);
							if (num2 >= 0 && num2 < num)
							{
								num = num2;
							}
						}
						num = Math.Min(base.Items.Count - count - 1, num);
					}
					ArrayList arrayList = new ArrayList(base.SelectedItems);
					using (this.UpdateSelectedCells())
					{
						bool isUpdatingSelectedItems = base.IsUpdatingSelectedItems;
						if (!isUpdatingSelectedItems)
						{
							base.BeginUpdateSelectedItems();
						}
						try
						{
							this._selectedCells.ClearFullRows(base.SelectedItems);
							base.SelectedItems.Clear();
						}
						finally
						{
							if (!isUpdatingSelectedItems)
							{
								base.EndUpdateSelectedItems();
							}
						}
					}
					for (int i = 0; i < count; i++)
					{
						object obj = arrayList[i];
						if (obj != CollectionView.NewItemPlaceholder)
						{
							this.EditableItems.Remove(obj);
						}
					}
					if (num >= 0)
					{
						object currentItem2 = base.Items[num];
						this.CurrentItem = currentItem2;
						DataGridCell currentCellContainer = this.CurrentCellContainer;
						if (currentCellContainer != null)
						{
							this._selectionAnchor = null;
							this.HandleSelectionForCellInput(currentCellContainer, false, false, false);
						}
					}
				}
			}
			e.Handled = true;
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060003BD RID: 957 RVA: 0x0000E8FC File Offset: 0x0000CAFC
		// (set) Token: 0x060003BE RID: 958 RVA: 0x0000E90E File Offset: 0x0000CB0E
		public bool IsReadOnly
		{
			get
			{
				return (bool)base.GetValue(DataGrid.IsReadOnlyProperty);
			}
			set
			{
				base.SetValue(DataGrid.IsReadOnlyProperty, value);
			}
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000E921 File Offset: 0x0000CB21
		private static void OnIsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue)
			{
				((DataGrid)d).CancelAnyEdit();
			}
			CommandManager.InvalidateRequerySuggested();
			d.CoerceValue(DataGrid.CanUserAddRowsProperty);
			d.CoerceValue(DataGrid.CanUserDeleteRowsProperty);
			DataGrid.OnNotifyColumnAndCellPropertyChanged(d, e);
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x0000E95E File Offset: 0x0000CB5E
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x0000E96B File Offset: 0x0000CB6B
		public object CurrentItem
		{
			get
			{
				return base.GetValue(DataGrid.CurrentItemProperty);
			}
			set
			{
				base.SetValue(DataGrid.CurrentItemProperty, value);
			}
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0000E97C File Offset: 0x0000CB7C
		private static void OnCurrentItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)d;
			DataGridCellInfo currentCell = dataGrid.CurrentCell;
			object newValue = e.NewValue;
			if (currentCell.Item != newValue)
			{
				dataGrid.CurrentCell = DataGridCellInfo.CreatePossiblyPartialCellInfo(newValue, currentCell.Column, dataGrid);
			}
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000E9BD File Offset: 0x0000CBBD
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x0000E9CF File Offset: 0x0000CBCF
		public DataGridColumn CurrentColumn
		{
			get
			{
				return (DataGridColumn)base.GetValue(DataGrid.CurrentColumnProperty);
			}
			set
			{
				base.SetValue(DataGrid.CurrentColumnProperty, value);
			}
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x0000E9E0 File Offset: 0x0000CBE0
		private static void OnCurrentColumnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)d;
			DataGridCellInfo currentCell = dataGrid.CurrentCell;
			DataGridColumn dataGridColumn = (DataGridColumn)e.NewValue;
			if (currentCell.Column != dataGridColumn)
			{
				dataGrid.CurrentCell = DataGridCellInfo.CreatePossiblyPartialCellInfo(currentCell.Item, dataGridColumn, dataGrid);
			}
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000EA26 File Offset: 0x0000CC26
		// (set) Token: 0x060003C7 RID: 967 RVA: 0x0000EA38 File Offset: 0x0000CC38
		public DataGridCellInfo CurrentCell
		{
			get
			{
				return (DataGridCellInfo)base.GetValue(DataGrid.CurrentCellProperty);
			}
			set
			{
				base.SetValue(DataGrid.CurrentCellProperty, value);
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0000EA4C File Offset: 0x0000CC4C
		private static void OnCurrentCellChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)d;
			DataGridCellInfo dataGridCellInfo = (DataGridCellInfo)e.OldValue;
			DataGridCellInfo dataGridCellInfo2 = (DataGridCellInfo)e.NewValue;
			if (dataGrid.CurrentItem != dataGridCellInfo2.Item)
			{
				dataGrid.CurrentItem = dataGridCellInfo2.Item;
			}
			if (dataGrid.CurrentColumn != dataGridCellInfo2.Column)
			{
				dataGrid.CurrentColumn = dataGridCellInfo2.Column;
			}
			if (dataGrid._currentCellContainer != null)
			{
				if ((dataGrid.IsAddingNewItem || dataGrid.IsEditingRowItem) && dataGridCellInfo.Item != dataGridCellInfo2.Item)
				{
					dataGrid.EndEdit(DataGrid.CommitEditCommand, dataGrid._currentCellContainer, DataGridEditingUnit.Row, true);
				}
				else if (dataGrid._currentCellContainer.IsEditing)
				{
					dataGrid.EndEdit(DataGrid.CommitEditCommand, dataGrid._currentCellContainer, DataGridEditingUnit.Cell, true);
				}
			}
			dataGrid._currentCellContainer = null;
			if (dataGridCellInfo2.IsValid && dataGrid.IsKeyboardFocusWithin)
			{
				DataGridCell dataGridCell = dataGrid._pendingCurrentCellContainer;
				if (dataGridCell == null)
				{
					dataGridCell = dataGrid.CurrentCellContainer;
					if (dataGridCell == null)
					{
						dataGrid.ScrollCellIntoView(dataGridCellInfo2.Item, dataGridCellInfo2.Column);
						dataGridCell = dataGrid.CurrentCellContainer;
					}
				}
				if (dataGridCell != null && !dataGridCell.IsKeyboardFocusWithin)
				{
					dataGridCell.Focus();
				}
			}
			dataGrid.OnCurrentCellChanged(EventArgs.Empty);
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x060003C9 RID: 969 RVA: 0x0000EB75 File Offset: 0x0000CD75
		// (remove) Token: 0x060003CA RID: 970 RVA: 0x0000EB8E File Offset: 0x0000CD8E
		public event EventHandler<EventArgs> CurrentCellChanged;

		// Token: 0x060003CB RID: 971 RVA: 0x0000EBA7 File Offset: 0x0000CDA7
		protected virtual void OnCurrentCellChanged(EventArgs e)
		{
			if (this.CurrentCellChanged != null)
			{
				this.CurrentCellChanged(this, e);
			}
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000EBBE File Offset: 0x0000CDBE
		private void UpdateCurrentCell(DataGridCell cell, bool isFocusWithinCell)
		{
			if (isFocusWithinCell)
			{
				this.CurrentCellContainer = cell;
				return;
			}
			if (!base.IsKeyboardFocusWithin)
			{
				this.CurrentCellContainer = null;
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003CD RID: 973 RVA: 0x0000EBDC File Offset: 0x0000CDDC
		// (set) Token: 0x060003CE RID: 974 RVA: 0x0000EC14 File Offset: 0x0000CE14
		private DataGridCell CurrentCellContainer
		{
			get
			{
				if (this._currentCellContainer == null)
				{
					DataGridCellInfo currentCell = this.CurrentCell;
					if (currentCell.IsValid)
					{
						this._currentCellContainer = this.TryFindCell(currentCell);
					}
				}
				return this._currentCellContainer;
			}
			set
			{
				if (this._currentCellContainer != value && (value == null || value != this._pendingCurrentCellContainer))
				{
					this._pendingCurrentCellContainer = value;
					if (value == null)
					{
						base.ClearValue(DataGrid.CurrentCellProperty);
					}
					else
					{
						this.CurrentCell = new DataGridCellInfo(value);
					}
					this._pendingCurrentCellContainer = null;
					this._currentCellContainer = value;
					CommandManager.InvalidateRequerySuggested();
				}
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003CF RID: 975 RVA: 0x0000EC6C File Offset: 0x0000CE6C
		private bool IsEditingCurrentCell
		{
			get
			{
				DataGridCell currentCellContainer = this.CurrentCellContainer;
				return currentCellContainer != null && currentCellContainer.IsEditing;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000EC8C File Offset: 0x0000CE8C
		private bool IsCurrentCellReadOnly
		{
			get
			{
				DataGridCell currentCellContainer = this.CurrentCellContainer;
				return currentCellContainer != null && currentCellContainer.IsReadOnly;
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060003D1 RID: 977 RVA: 0x0000ECAB File Offset: 0x0000CEAB
		// (remove) Token: 0x060003D2 RID: 978 RVA: 0x0000ECC4 File Offset: 0x0000CEC4
		public event EventHandler<DataGridBeginningEditEventArgs> BeginningEdit;

		// Token: 0x060003D3 RID: 979 RVA: 0x0000ECE0 File Offset: 0x0000CEE0
		protected virtual void OnBeginningEdit(DataGridBeginningEditEventArgs e)
		{
			if (this.BeginningEdit != null)
			{
				this.BeginningEdit(this, e);
			}
			if (AutomationPeer.ListenerExists(AutomationEvents.InvokePatternOnInvoked))
			{
				Microsoft.Windows.Automation.Peers.DataGridAutomationPeer dataGridAutomationPeer = UIElementAutomationPeer.FromElement(this) as Microsoft.Windows.Automation.Peers.DataGridAutomationPeer;
				if (dataGridAutomationPeer != null)
				{
					dataGridAutomationPeer.RaiseAutomationCellInvokeEvents(e.Column, e.Row);
				}
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060003D4 RID: 980 RVA: 0x0000ED2B File Offset: 0x0000CF2B
		// (remove) Token: 0x060003D5 RID: 981 RVA: 0x0000ED44 File Offset: 0x0000CF44
		public event EventHandler<DataGridPreparingCellForEditEventArgs> PreparingCellForEdit;

		// Token: 0x060003D6 RID: 982 RVA: 0x0000ED5D File Offset: 0x0000CF5D
		protected internal virtual void OnPreparingCellForEdit(DataGridPreparingCellForEditEventArgs e)
		{
			if (this.PreparingCellForEdit != null)
			{
				this.PreparingCellForEdit(this, e);
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000ED74 File Offset: 0x0000CF74
		public bool BeginEdit()
		{
			return this.BeginEdit(null);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000ED80 File Offset: 0x0000CF80
		public bool BeginEdit(RoutedEventArgs editingEventArgs)
		{
			if (!this.IsReadOnly)
			{
				DataGridCell currentCellContainer = this.CurrentCellContainer;
				if (currentCellContainer != null)
				{
					if (!currentCellContainer.IsEditing && DataGrid.BeginEditCommand.CanExecute(editingEventArgs, currentCellContainer))
					{
						DataGrid.BeginEditCommand.Execute(editingEventArgs, currentCellContainer);
					}
					return currentCellContainer.IsEditing;
				}
			}
			return false;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000EDC9 File Offset: 0x0000CFC9
		public bool CancelEdit()
		{
			if (this.IsEditingCurrentCell)
			{
				return this.CancelEdit(DataGridEditingUnit.Cell);
			}
			return (!this.IsEditingRowItem && !this.IsAddingNewItem) || this.CancelEdit(DataGridEditingUnit.Row);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0000EDF4 File Offset: 0x0000CFF4
		internal bool CancelEdit(DataGridCell cell)
		{
			DataGridCell currentCellContainer = this.CurrentCellContainer;
			return currentCellContainer == null || currentCellContainer != cell || !currentCellContainer.IsEditing || this.CancelEdit(DataGridEditingUnit.Cell);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0000EE20 File Offset: 0x0000D020
		public bool CancelEdit(DataGridEditingUnit editingUnit)
		{
			return this.EndEdit(DataGrid.CancelEditCommand, this.CurrentCellContainer, editingUnit, true);
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0000EE35 File Offset: 0x0000D035
		private void CancelAnyEdit()
		{
			if (this.IsAddingNewItem || this.IsEditingRowItem)
			{
				this.CancelEdit(DataGridEditingUnit.Row);
				return;
			}
			if (this.IsEditingCurrentCell)
			{
				this.CancelEdit(DataGridEditingUnit.Cell);
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0000EE60 File Offset: 0x0000D060
		public bool CommitEdit()
		{
			if (this.IsEditingCurrentCell)
			{
				return this.CommitEdit(DataGridEditingUnit.Cell, true);
			}
			return (!this.IsEditingRowItem && !this.IsAddingNewItem) || this.CommitEdit(DataGridEditingUnit.Row, true);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000EE8D File Offset: 0x0000D08D
		public bool CommitEdit(DataGridEditingUnit editingUnit, bool exitEditingMode)
		{
			return this.EndEdit(DataGrid.CommitEditCommand, this.CurrentCellContainer, editingUnit, exitEditingMode);
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000EEA2 File Offset: 0x0000D0A2
		private bool CommitAnyEdit()
		{
			if (this.IsAddingNewItem || this.IsEditingRowItem)
			{
				return this.CommitEdit(DataGridEditingUnit.Row, true);
			}
			return !this.IsEditingCurrentCell || this.CommitEdit(DataGridEditingUnit.Cell, true);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0000EED0 File Offset: 0x0000D0D0
		private bool EndEdit(RoutedCommand command, DataGridCell cellContainer, DataGridEditingUnit editingUnit, bool exitEditMode)
		{
			bool flag = true;
			bool flag2 = true;
			if (cellContainer != null)
			{
				if (command.CanExecute(editingUnit, cellContainer))
				{
					command.Execute(editingUnit, cellContainer);
				}
				flag = !cellContainer.IsEditing;
				flag2 = (!this.IsEditingRowItem && !this.IsAddingNewItem);
			}
			if (!exitEditMode)
			{
				if (editingUnit != DataGridEditingUnit.Cell)
				{
					if (flag2)
					{
						object rowDataItem = cellContainer.RowDataItem;
						if (rowDataItem != null)
						{
							this.EditRowItem(rowDataItem);
							return this.IsEditingRowItem;
						}
					}
					return false;
				}
				if (cellContainer == null)
				{
					return false;
				}
				if (flag)
				{
					return this.BeginEdit(null);
				}
			}
			return flag && (editingUnit == DataGridEditingUnit.Cell || flag2);
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x0000EF5E File Offset: 0x0000D15E
		// (set) Token: 0x060003E2 RID: 994 RVA: 0x0000EF66 File Offset: 0x0000D166
		private bool HasCellValidationError
		{
			get
			{
				return this._hasCellValidationError;
			}
			set
			{
				if (this._hasCellValidationError != value)
				{
					this._hasCellValidationError = value;
					CommandManager.InvalidateRequerySuggested();
				}
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x0000EF7D File Offset: 0x0000D17D
		// (set) Token: 0x060003E4 RID: 996 RVA: 0x0000EF85 File Offset: 0x0000D185
		private bool HasRowValidationError
		{
			get
			{
				return this._hasRowValidationError;
			}
			set
			{
				if (this._hasRowValidationError != value)
				{
					this._hasRowValidationError = value;
					CommandManager.InvalidateRequerySuggested();
				}
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000EF9C File Offset: 0x0000D19C
		// (set) Token: 0x060003E6 RID: 998 RVA: 0x0000EFA4 File Offset: 0x0000D1A4
		internal DataGridCell FocusedCell
		{
			get
			{
				return this._focusedCell;
			}
			set
			{
				if (this._focusedCell != value)
				{
					if (this._focusedCell != null)
					{
						this.UpdateCurrentCell(this._focusedCell, false);
					}
					this._focusedCell = value;
					if (this._focusedCell != null)
					{
						this.UpdateCurrentCell(this._focusedCell, true);
					}
				}
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x0000EFE0 File Offset: 0x0000D1E0
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x0000EFF2 File Offset: 0x0000D1F2
		public bool CanUserAddRows
		{
			get
			{
				return (bool)base.GetValue(DataGrid.CanUserAddRowsProperty);
			}
			set
			{
				base.SetValue(DataGrid.CanUserAddRowsProperty, value);
			}
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000F005 File Offset: 0x0000D205
		private static void OnCanUserAddRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).UpdateNewItemPlaceholder(false);
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x0000F013 File Offset: 0x0000D213
		private static object OnCoerceCanUserAddRows(DependencyObject d, object baseValue)
		{
			return DataGrid.OnCoerceCanUserAddOrDeleteRows((DataGrid)d, (bool)baseValue, true);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x0000F02C File Offset: 0x0000D22C
		private static bool OnCoerceCanUserAddOrDeleteRows(DataGrid dataGrid, bool baseValue, bool canUserAddRowsProperty)
		{
			if (baseValue)
			{
				if (dataGrid.IsReadOnly || !dataGrid.IsEnabled)
				{
					return false;
				}
				if ((canUserAddRowsProperty && !dataGrid.EditableItems.CanAddNew) || (!canUserAddRowsProperty && !dataGrid.EditableItems.CanRemove))
				{
					return false;
				}
			}
			return baseValue;
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x0000F066 File Offset: 0x0000D266
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x0000F078 File Offset: 0x0000D278
		public bool CanUserDeleteRows
		{
			get
			{
				return (bool)base.GetValue(DataGrid.CanUserDeleteRowsProperty);
			}
			set
			{
				base.SetValue(DataGrid.CanUserDeleteRowsProperty, value);
			}
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x0000F08B File Offset: 0x0000D28B
		private static void OnCanUserDeleteRowsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			CommandManager.InvalidateRequerySuggested();
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x0000F092 File Offset: 0x0000D292
		private static object OnCoerceCanUserDeleteRows(DependencyObject d, object baseValue)
		{
			return DataGrid.OnCoerceCanUserAddOrDeleteRows((DataGrid)d, (bool)baseValue, false);
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x060003F0 RID: 1008 RVA: 0x0000F0AB File Offset: 0x0000D2AB
		// (remove) Token: 0x060003F1 RID: 1009 RVA: 0x0000F0C4 File Offset: 0x0000D2C4
		public event InitializingNewItemEventHandler InitializingNewItem;

		// Token: 0x060003F2 RID: 1010 RVA: 0x0000F0DD File Offset: 0x0000D2DD
		protected virtual void OnInitializingNewItem(InitializingNewItemEventArgs e)
		{
			if (this.InitializingNewItem != null)
			{
				this.InitializingNewItem(this, e);
			}
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000F0F4 File Offset: 0x0000D2F4
		private object AddNewItem()
		{
			this.UpdateNewItemPlaceholder(true);
			object obj = this.EditableItems.AddNew();
			if (obj != null)
			{
				InitializingNewItemEventArgs e = new InitializingNewItemEventArgs(obj);
				this.OnInitializingNewItem(e);
			}
			CommandManager.InvalidateRequerySuggested();
			return obj;
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x0000F12B File Offset: 0x0000D32B
		private void EditRowItem(object rowItem)
		{
			this.EditableItems.EditItem(rowItem);
			CommandManager.InvalidateRequerySuggested();
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0000F13E File Offset: 0x0000D33E
		private void CommitRowItem()
		{
			if (this.IsEditingRowItem)
			{
				this.EditableItems.CommitEdit();
				return;
			}
			this.EditableItems.CommitNew();
			this.UpdateNewItemPlaceholder(false);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000F168 File Offset: 0x0000D368
		private void CancelRowItem()
		{
			if (this.IsEditingRowItem)
			{
				this.EditableItems.CancelEdit();
				return;
			}
			object currentAddItem = this.EditableItems.CurrentAddItem;
			bool flag = currentAddItem == this.CurrentItem;
			bool flag2 = base.SelectedItems.Contains(currentAddItem);
			bool flag3 = false;
			List<int> list = null;
			int num = -1;
			if (flag2)
			{
				this.UnselectItem(currentAddItem);
			}
			else
			{
				num = base.Items.IndexOf(currentAddItem);
				flag3 = (num >= 0 && this._selectedCells.Intersects(num, out list));
			}
			this.EditableItems.CancelNew();
			this.UpdateNewItemPlaceholder(false);
			if (flag)
			{
				this.CurrentItem = CollectionView.NewItemPlaceholder;
			}
			if (flag2)
			{
				this.SelectItem(CollectionView.NewItemPlaceholder);
				return;
			}
			if (flag3)
			{
				using (this.UpdateSelectedCells())
				{
					int num2 = num;
					bool flag4 = this.EditableItems.NewItemPlaceholderPosition == NewItemPlaceholderPosition.AtBeginning;
					if (flag4)
					{
						this._selectedCells.RemoveRegion(num, 0, 1, this.Columns.Count);
						num2--;
					}
					int i = 0;
					int count = list.Count;
					while (i < count)
					{
						this._selectedCells.AddRegion(num2, list[i], 1, list[i + 1]);
						i += 2;
					}
				}
			}
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000F2B8 File Offset: 0x0000D4B8
		private void UpdateRowEditing(DataGridCell cell)
		{
			object rowDataItem = cell.RowDataItem;
			if (!this.IsAddingOrEditingRowItem(rowDataItem))
			{
				cell.RowOwner.IsEditing = false;
				this._editingRowItem = null;
				this._editingRowIndex = -1;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x0000F2EF File Offset: 0x0000D4EF
		private IEditableCollectionView EditableItems
		{
			get
			{
				return base.Items;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x0000F2F7 File Offset: 0x0000D4F7
		private bool IsAddingNewItem
		{
			get
			{
				return this.EditableItems.IsAddingNew;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060003FA RID: 1018 RVA: 0x0000F304 File Offset: 0x0000D504
		private bool IsEditingRowItem
		{
			get
			{
				return this.EditableItems.IsEditingItem;
			}
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000F311 File Offset: 0x0000D511
		private bool IsAddingOrEditingRowItem(object item)
		{
			return this.IsEditingItem(item) || (this.IsAddingNewItem && this.EditableItems.CurrentAddItem == item);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x0000F336 File Offset: 0x0000D536
		private bool CanCancelAddingOrEditingRowItem(DataGridEditingUnit editingUnit, object item)
		{
			return editingUnit == DataGridEditingUnit.Row && ((this.IsEditingItem(item) && this.EditableItems.CanCancelEdit) || (this.IsAddingNewItem && this.EditableItems.CurrentAddItem == item));
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x0000F36E File Offset: 0x0000D56E
		private bool IsEditingItem(object item)
		{
			return this.IsEditingRowItem && this.EditableItems.CurrentEditItem == item;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0000F388 File Offset: 0x0000D588
		private void UpdateNewItemPlaceholder(bool isAddingNewItem)
		{
			IEditableCollectionView editableItems = this.EditableItems;
			bool flag = this.CanUserAddRows;
			if (DataGridHelper.IsDefaultValue(this, DataGrid.CanUserAddRowsProperty))
			{
				flag = DataGrid.OnCoerceCanUserAddOrDeleteRows(this, flag, true);
			}
			if (!isAddingNewItem)
			{
				if (flag)
				{
					if (editableItems.NewItemPlaceholderPosition == NewItemPlaceholderPosition.None)
					{
						editableItems.NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtEnd;
					}
					this._placeholderVisibility = Visibility.Visible;
				}
				else
				{
					if (editableItems.NewItemPlaceholderPosition != NewItemPlaceholderPosition.None)
					{
						editableItems.NewItemPlaceholderPosition = NewItemPlaceholderPosition.None;
					}
					this._placeholderVisibility = Visibility.Collapsed;
				}
			}
			else
			{
				this._placeholderVisibility = Visibility.Collapsed;
			}
			DataGridRow dataGridRow = (DataGridRow)base.ItemContainerGenerator.ContainerFromItem(CollectionView.NewItemPlaceholder);
			if (dataGridRow != null)
			{
				dataGridRow.CoerceValue(UIElement.VisibilityProperty);
			}
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x0000F41C File Offset: 0x0000D61C
		private void SetCurrentItemToPlaceholder()
		{
			NewItemPlaceholderPosition newItemPlaceholderPosition = this.EditableItems.NewItemPlaceholderPosition;
			if (newItemPlaceholderPosition == NewItemPlaceholderPosition.AtEnd)
			{
				int count = base.Items.Count;
				if (count > 0)
				{
					this.CurrentItem = base.Items[count - 1];
					return;
				}
			}
			else if (newItemPlaceholderPosition == NewItemPlaceholderPosition.AtBeginning && base.Items.Count > 0)
			{
				this.CurrentItem = base.Items[0];
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x0000F484 File Offset: 0x0000D684
		private int DataItemsCount
		{
			get
			{
				int num = base.Items.Count;
				if (this.HasNewItemPlaceholder)
				{
					num--;
				}
				return num;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x0000F4AC File Offset: 0x0000D6AC
		private int DataItemsSelected
		{
			get
			{
				int num = base.SelectedItems.Count;
				if (this.HasNewItemPlaceholder && base.SelectedItems.Contains(CollectionView.NewItemPlaceholder))
				{
					num--;
				}
				return num;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x0000F4E4 File Offset: 0x0000D6E4
		private bool HasNewItemPlaceholder
		{
			get
			{
				IEditableCollectionView editableItems = this.EditableItems;
				return editableItems.NewItemPlaceholderPosition != NewItemPlaceholderPosition.None;
			}
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x0000F504 File Offset: 0x0000D704
		private bool IsNewItemPlaceholder(object item)
		{
			return item == CollectionView.NewItemPlaceholder || item == DataGrid.NewItemPlaceholder;
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x0000F518 File Offset: 0x0000D718
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x0000F52A File Offset: 0x0000D72A
		public DataGridRowDetailsVisibilityMode RowDetailsVisibilityMode
		{
			get
			{
				return (DataGridRowDetailsVisibilityMode)base.GetValue(DataGrid.RowDetailsVisibilityModeProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowDetailsVisibilityModeProperty, value);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x0000F53D File Offset: 0x0000D73D
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x0000F54F File Offset: 0x0000D74F
		public bool AreRowDetailsFrozen
		{
			get
			{
				return (bool)base.GetValue(DataGrid.AreRowDetailsFrozenProperty);
			}
			set
			{
				base.SetValue(DataGrid.AreRowDetailsFrozenProperty, value);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x0000F562 File Offset: 0x0000D762
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x0000F574 File Offset: 0x0000D774
		public DataTemplate RowDetailsTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(DataGrid.RowDetailsTemplateProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowDetailsTemplateProperty, value);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x0000F582 File Offset: 0x0000D782
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x0000F594 File Offset: 0x0000D794
		public DataTemplateSelector RowDetailsTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(DataGrid.RowDetailsTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(DataGrid.RowDetailsTemplateSelectorProperty, value);
			}
		}

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x0600040C RID: 1036 RVA: 0x0000F5A2 File Offset: 0x0000D7A2
		// (remove) Token: 0x0600040D RID: 1037 RVA: 0x0000F5BB File Offset: 0x0000D7BB
		public event EventHandler<DataGridRowDetailsEventArgs> LoadingRowDetails;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600040E RID: 1038 RVA: 0x0000F5D4 File Offset: 0x0000D7D4
		// (remove) Token: 0x0600040F RID: 1039 RVA: 0x0000F5ED File Offset: 0x0000D7ED
		public event EventHandler<DataGridRowDetailsEventArgs> UnloadingRowDetails;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000410 RID: 1040 RVA: 0x0000F606 File Offset: 0x0000D806
		// (remove) Token: 0x06000411 RID: 1041 RVA: 0x0000F61F File Offset: 0x0000D81F
		public event EventHandler<DataGridRowDetailsEventArgs> RowDetailsVisibilityChanged;

		// Token: 0x06000412 RID: 1042 RVA: 0x0000F638 File Offset: 0x0000D838
		internal void OnLoadingRowDetailsWrapper(DataGridRow row)
		{
			if (row != null && !row.DetailsLoaded && row.DetailsVisibility == Visibility.Visible && row.DetailsPresenter != null)
			{
				DataGridRowDetailsEventArgs e = new DataGridRowDetailsEventArgs(row, row.DetailsPresenter.DetailsElement);
				this.OnLoadingRowDetails(e);
				row.DetailsLoaded = true;
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x0000F680 File Offset: 0x0000D880
		internal void OnUnloadingRowDetailsWrapper(DataGridRow row)
		{
			if (row != null && row.DetailsLoaded && row.DetailsPresenter != null)
			{
				DataGridRowDetailsEventArgs e = new DataGridRowDetailsEventArgs(row, row.DetailsPresenter.DetailsElement);
				this.OnUnloadingRowDetails(e);
				row.DetailsLoaded = false;
			}
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x0000F6C0 File Offset: 0x0000D8C0
		protected virtual void OnLoadingRowDetails(DataGridRowDetailsEventArgs e)
		{
			if (this.LoadingRowDetails != null)
			{
				this.LoadingRowDetails(this, e);
			}
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x0000F6D7 File Offset: 0x0000D8D7
		protected virtual void OnUnloadingRowDetails(DataGridRowDetailsEventArgs e)
		{
			if (this.UnloadingRowDetails != null)
			{
				this.UnloadingRowDetails(this, e);
			}
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x0000F6F0 File Offset: 0x0000D8F0
		protected internal virtual void OnRowDetailsVisibilityChanged(DataGridRowDetailsEventArgs e)
		{
			if (this.RowDetailsVisibilityChanged != null)
			{
				this.RowDetailsVisibilityChanged(this, e);
			}
			DataGridRow row = e.Row;
			this.OnLoadingRowDetailsWrapper(row);
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000F720 File Offset: 0x0000D920
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000F732 File Offset: 0x0000D932
		public bool CanUserResizeRows
		{
			get
			{
				return (bool)base.GetValue(DataGrid.CanUserResizeRowsProperty);
			}
			set
			{
				base.SetValue(DataGrid.CanUserResizeRowsProperty, value);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000F745 File Offset: 0x0000D945
		public IList<DataGridCellInfo> SelectedCells
		{
			get
			{
				return this._selectedCells;
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000F74D File Offset: 0x0000D94D
		internal SelectedCellsCollection SelectedCellsInternal
		{
			get
			{
				return this._selectedCells;
			}
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x0600041B RID: 1051 RVA: 0x0000F755 File Offset: 0x0000D955
		// (remove) Token: 0x0600041C RID: 1052 RVA: 0x0000F76E File Offset: 0x0000D96E
		public event SelectedCellsChangedEventHandler SelectedCellsChanged;

		// Token: 0x0600041D RID: 1053 RVA: 0x0000F788 File Offset: 0x0000D988
		internal void OnSelectedCellsChanged(NotifyCollectionChangedAction action, VirtualizedCellInfoCollection oldItems, VirtualizedCellInfoCollection newItems)
		{
			DataGridSelectionMode selectionMode = this.SelectionMode;
			DataGridSelectionUnit selectionUnit = this.SelectionUnit;
			if (!this.IsUpdatingSelectedCells && selectionUnit == DataGridSelectionUnit.FullRow)
			{
				throw new InvalidOperationException(SR.Get(SRID.DataGrid_CannotSelectCell));
			}
			if (oldItems != null)
			{
				if (this._pendingSelectedCells != null)
				{
					VirtualizedCellInfoCollection.Xor(this._pendingSelectedCells, oldItems);
				}
				if (this._pendingUnselectedCells == null)
				{
					this._pendingUnselectedCells = oldItems;
				}
				else
				{
					this._pendingUnselectedCells.Union(oldItems);
				}
			}
			if (newItems != null)
			{
				if (this._pendingUnselectedCells != null)
				{
					VirtualizedCellInfoCollection.Xor(this._pendingUnselectedCells, newItems);
				}
				if (this._pendingSelectedCells == null)
				{
					this._pendingSelectedCells = newItems;
				}
				else
				{
					this._pendingSelectedCells.Union(newItems);
				}
			}
			if (!this.IsUpdatingSelectedCells)
			{
				using (this.UpdateSelectedCells())
				{
					if (selectionMode == DataGridSelectionMode.Single && action == NotifyCollectionChangedAction.Add && this._selectedCells.Count > 1)
					{
						this._selectedCells.RemoveAllButOne(newItems[0]);
					}
					else if (action == NotifyCollectionChangedAction.Remove && oldItems != null && selectionUnit == DataGridSelectionUnit.CellOrRowHeader)
					{
						bool isUpdatingSelectedItems = base.IsUpdatingSelectedItems;
						if (!isUpdatingSelectedItems)
						{
							base.BeginUpdateSelectedItems();
						}
						try
						{
							object obj = null;
							foreach (DataGridCellInfo dataGridCellInfo in oldItems)
							{
								object item = dataGridCellInfo.Item;
								if (item != obj)
								{
									obj = item;
									if (base.SelectedItems.Contains(item))
									{
										base.SelectedItems.Remove(item);
									}
								}
							}
						}
						finally
						{
							if (!isUpdatingSelectedItems)
							{
								base.EndUpdateSelectedItems();
							}
						}
					}
				}
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0000F91C File Offset: 0x0000DB1C
		private void NotifySelectedCellsChanged()
		{
			if ((this._pendingSelectedCells != null && this._pendingSelectedCells.Count > 0) || (this._pendingUnselectedCells != null && this._pendingUnselectedCells.Count > 0))
			{
				SelectedCellsChangedEventArgs e = new SelectedCellsChangedEventArgs(this, this._pendingSelectedCells, this._pendingUnselectedCells);
				int count = this._selectedCells.Count;
				int num = (this._pendingUnselectedCells != null) ? this._pendingUnselectedCells.Count : 0;
				int num2 = (this._pendingSelectedCells != null) ? this._pendingSelectedCells.Count : 0;
				int num3 = count - num2 + num;
				this._pendingSelectedCells = null;
				this._pendingUnselectedCells = null;
				this.OnSelectedCellsChanged(e);
				if (num3 == 0 || count == 0)
				{
					CommandManager.InvalidateRequerySuggested();
				}
			}
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0000F9D0 File Offset: 0x0000DBD0
		protected virtual void OnSelectedCellsChanged(SelectedCellsChangedEventArgs e)
		{
			if (this.SelectedCellsChanged != null)
			{
				this.SelectedCellsChanged(this, e);
			}
			if (AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementSelected) || AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementAddedToSelection) || AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection))
			{
				Microsoft.Windows.Automation.Peers.DataGridAutomationPeer dataGridAutomationPeer = UIElementAutomationPeer.FromElement(this) as Microsoft.Windows.Automation.Peers.DataGridAutomationPeer;
				if (dataGridAutomationPeer != null)
				{
					dataGridAutomationPeer.RaiseAutomationCellSelectedEvent(e);
				}
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000420 RID: 1056 RVA: 0x0000FA20 File Offset: 0x0000DC20
		public static RoutedUICommand SelectAllCommand
		{
			get
			{
				return ApplicationCommands.SelectAll;
			}
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x0000FA28 File Offset: 0x0000DC28
		private static void OnCanExecuteSelectAll(object sender, CanExecuteRoutedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)sender;
			e.CanExecute = (dataGrid.SelectionMode == DataGridSelectionMode.Extended && dataGrid.IsEnabled);
			e.Handled = true;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x0000FA5C File Offset: 0x0000DC5C
		private static void OnExecutedSelectAll(object sender, ExecutedRoutedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)sender;
			if (dataGrid.SelectionUnit == DataGridSelectionUnit.Cell)
			{
				dataGrid.SelectAllCells();
			}
			else
			{
				dataGrid.SelectAllRows();
			}
			e.Handled = true;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x0000FA90 File Offset: 0x0000DC90
		private void SelectAllRows()
		{
			int count = base.Items.Count;
			int count2 = this._columns.Count;
			if (count2 > 0 && count > 0)
			{
				using (this.UpdateSelectedCells())
				{
					this._selectedCells.AddRegion(0, 0, count, count2);
					base.SelectAll();
				}
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x0000FAF8 File Offset: 0x0000DCF8
		internal void SelectOnlyThisCell(DataGridCellInfo currentCellInfo)
		{
			using (this.UpdateSelectedCells())
			{
				this._selectedCells.Clear();
				this._selectedCells.Add(currentCellInfo);
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0000FB40 File Offset: 0x0000DD40
		public void SelectAllCells()
		{
			if (this.SelectionUnit == DataGridSelectionUnit.FullRow)
			{
				this.SelectAllRows();
				return;
			}
			int count = base.Items.Count;
			int count2 = this._columns.Count;
			if (count > 0 && count2 > 0)
			{
				using (this.UpdateSelectedCells())
				{
					if (this._selectedCells.Count > 0)
					{
						this._selectedCells.Clear();
					}
					this._selectedCells.AddRegion(0, 0, count, count2);
				}
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000FBC8 File Offset: 0x0000DDC8
		public void UnselectAllCells()
		{
			using (this.UpdateSelectedCells())
			{
				this._selectedCells.Clear();
				if (this.SelectionUnit != DataGridSelectionUnit.Cell)
				{
					base.UnselectAll();
				}
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0000FC14 File Offset: 0x0000DE14
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x0000FC26 File Offset: 0x0000DE26
		public DataGridSelectionMode SelectionMode
		{
			get
			{
				return (DataGridSelectionMode)base.GetValue(DataGrid.SelectionModeProperty);
			}
			set
			{
				base.SetValue(DataGrid.SelectionModeProperty, value);
			}
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000FC3C File Offset: 0x0000DE3C
		private static void OnSelectionModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)d;
			DataGridSelectionMode dataGridSelectionMode = (DataGridSelectionMode)e.NewValue;
			bool flag = dataGridSelectionMode == DataGridSelectionMode.Single;
			DataGridSelectionUnit selectionUnit = dataGrid.SelectionUnit;
			if (flag && selectionUnit == DataGridSelectionUnit.Cell)
			{
				using (dataGrid.UpdateSelectedCells())
				{
					dataGrid._selectedCells.RemoveAllButOne();
				}
			}
			dataGrid.CanSelectMultipleItems = (dataGridSelectionMode != DataGridSelectionMode.Single);
			if (flag && selectionUnit == DataGridSelectionUnit.CellOrRowHeader)
			{
				if (dataGrid.SelectedItems.Count > 0)
				{
					using (dataGrid.UpdateSelectedCells())
					{
						dataGrid._selectedCells.RemoveAllButOneRow(dataGrid.Items.IndexOf(dataGrid.SelectedItems[0]));
						return;
					}
				}
				using (dataGrid.UpdateSelectedCells())
				{
					dataGrid._selectedCells.RemoveAllButOne();
				}
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0000FD34 File Offset: 0x0000DF34
		// (set) Token: 0x0600042B RID: 1067 RVA: 0x0000FD46 File Offset: 0x0000DF46
		public DataGridSelectionUnit SelectionUnit
		{
			get
			{
				return (DataGridSelectionUnit)base.GetValue(DataGrid.SelectionUnitProperty);
			}
			set
			{
				base.SetValue(DataGrid.SelectionUnitProperty, value);
			}
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0000FD5C File Offset: 0x0000DF5C
		private static void OnSelectionUnitChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)d;
			DataGridSelectionUnit dataGridSelectionUnit = (DataGridSelectionUnit)e.OldValue;
			if (dataGridSelectionUnit != DataGridSelectionUnit.Cell)
			{
				dataGrid.UnselectAll();
			}
			if (dataGridSelectionUnit != DataGridSelectionUnit.FullRow)
			{
				using (dataGrid.UpdateSelectedCells())
				{
					dataGrid._selectedCells.Clear();
				}
			}
			dataGrid.CoerceValue(Selector.IsSynchronizedWithCurrentItemProperty);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000FDC4 File Offset: 0x0000DFC4
		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			if (!this.IsUpdatingSelectedCells)
			{
				using (this.UpdateSelectedCells())
				{
					int count = e.RemovedItems.Count;
					for (int i = 0; i < count; i++)
					{
						object rowItem = e.RemovedItems[i];
						this.UpdateSelectionOfCellsInRow(rowItem, false);
					}
					count = e.AddedItems.Count;
					for (int j = 0; j < count; j++)
					{
						object rowItem2 = e.AddedItems[j];
						this.UpdateSelectionOfCellsInRow(rowItem2, true);
					}
				}
			}
			CommandManager.InvalidateRequerySuggested();
			if (AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementSelected) || AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementAddedToSelection) || AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection))
			{
				Microsoft.Windows.Automation.Peers.DataGridAutomationPeer dataGridAutomationPeer = UIElementAutomationPeer.FromElement(this) as Microsoft.Windows.Automation.Peers.DataGridAutomationPeer;
				if (dataGridAutomationPeer != null)
				{
					dataGridAutomationPeer.RaiseAutomationSelectionEvents(e);
				}
			}
			base.OnSelectionChanged(e);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000FE98 File Offset: 0x0000E098
		private void UpdateIsSelected()
		{
			this.UpdateIsSelected(this._pendingUnselectedCells, false);
			this.UpdateIsSelected(this._pendingSelectedCells, true);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000FEB4 File Offset: 0x0000E0B4
		private void UpdateIsSelected(VirtualizedCellInfoCollection cells, bool isSelected)
		{
			if (cells != null)
			{
				int count = cells.Count;
				if (count > 0)
				{
					bool flag = false;
					if (count > 750)
					{
						int num = 0;
						int count2 = this._columns.Count;
						for (ContainerTracking<DataGridRow> containerTracking = this._rowTrackingRoot; containerTracking != null; containerTracking = containerTracking.Next)
						{
							num += count2;
							if (num >= count)
							{
								break;
							}
						}
						flag = (count > num);
					}
					if (flag)
					{
						for (ContainerTracking<DataGridRow> containerTracking2 = this._rowTrackingRoot; containerTracking2 != null; containerTracking2 = containerTracking2.Next)
						{
							DataGridRow container = containerTracking2.Container;
							Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = container.CellsPresenter;
							if (cellsPresenter != null)
							{
								for (ContainerTracking<DataGridCell> containerTracking3 = cellsPresenter.CellTrackingRoot; containerTracking3 != null; containerTracking3 = containerTracking3.Next)
								{
									DataGridCell container2 = containerTracking3.Container;
									DataGridCellInfo cell = new DataGridCellInfo(container2);
									if (cells.Contains(cell))
									{
										container2.SyncIsSelected(isSelected);
									}
								}
							}
						}
						return;
					}
					foreach (DataGridCellInfo info in cells)
					{
						DataGridCell dataGridCell = this.TryFindCell(info);
						if (dataGridCell != null)
						{
							dataGridCell.SyncIsSelected(isSelected);
						}
					}
				}
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0000FFD0 File Offset: 0x0000E1D0
		private void UpdateSelectionOfCellsInRow(object rowItem, bool isSelected)
		{
			int num = base.Items.IndexOf(rowItem);
			if (num >= 0)
			{
				int count = this._columns.Count;
				if (count > 0)
				{
					if (isSelected)
					{
						this._selectedCells.AddRegion(num, 0, 1, count);
						return;
					}
					this._selectedCells.RemoveRegion(num, 0, 1, count);
				}
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00010020 File Offset: 0x0000E220
		internal void CellIsSelectedChanged(DataGridCell cell, bool isSelected)
		{
			if (!this.IsUpdatingSelectedCells)
			{
				DataGridCellInfo cell2 = new DataGridCellInfo(cell);
				if (isSelected)
				{
					this._selectedCells.AddValidatedCell(cell2);
					return;
				}
				if (this._selectedCells.Contains(cell2))
				{
					this._selectedCells.Remove(cell2);
				}
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00010068 File Offset: 0x0000E268
		internal void HandleSelectionForCellInput(DataGridCell cell, bool startDragging, bool allowsExtendSelect, bool allowsMinimalSelect)
		{
			DataGridSelectionUnit selectionUnit = this.SelectionUnit;
			if (selectionUnit == DataGridSelectionUnit.FullRow)
			{
				this.MakeFullRowSelection(cell.RowDataItem, allowsExtendSelect, allowsMinimalSelect);
			}
			else
			{
				this.MakeCellSelection(new DataGridCellInfo(cell), allowsExtendSelect, allowsMinimalSelect);
			}
			if (startDragging)
			{
				this.BeginDragging();
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000100AC File Offset: 0x0000E2AC
		internal void HandleSelectionForRowHeaderAndDetailsInput(DataGridRow row, bool startDragging)
		{
			object item = row.Item;
			if (!this._isDraggingSelection && this._columns.Count > 0)
			{
				if (!base.IsKeyboardFocusWithin)
				{
					base.Focus();
				}
				if (this.CurrentCell.Item != item)
				{
					this.CurrentCell = new DataGridCellInfo(item, this.ColumnFromDisplayIndex(0), this);
				}
				else if (this._currentCellContainer != null && this._currentCellContainer.IsEditing)
				{
					this.EndEdit(DataGrid.CommitEditCommand, this._currentCellContainer, DataGridEditingUnit.Cell, true);
				}
			}
			if (this.CanSelectRows)
			{
				this.MakeFullRowSelection(item, true, true);
				if (startDragging)
				{
					this.BeginRowDragging();
				}
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0001014F File Offset: 0x0000E34F
		private void BeginRowDragging()
		{
			this.BeginDragging();
			this._isRowDragging = true;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0001015E File Offset: 0x0000E35E
		private void BeginDragging()
		{
			if (Mouse.Capture(this, CaptureMode.SubTree))
			{
				this._isDraggingSelection = true;
				this._dragPoint = Mouse.GetPosition(this);
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0001017C File Offset: 0x0000E37C
		private void EndDragging()
		{
			this.StopAutoScroll();
			if (Mouse.Captured == this)
			{
				base.ReleaseMouseCapture();
			}
			this._isDraggingSelection = false;
			this._isRowDragging = false;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x000101A0 File Offset: 0x0000E3A0
		private void MakeFullRowSelection(object dataItem, bool allowsExtendSelect, bool allowsMinimalSelect)
		{
			bool flag = allowsExtendSelect && this.ShouldExtendSelection;
			bool flag2 = allowsMinimalSelect && DataGrid.ShouldMinimallyModifySelection;
			using (this.UpdateSelectedCells())
			{
				bool isUpdatingSelectedItems = base.IsUpdatingSelectedItems;
				if (!isUpdatingSelectedItems)
				{
					base.BeginUpdateSelectedItems();
				}
				try
				{
					if (flag)
					{
						int count = this._columns.Count;
						if (count > 0)
						{
							ItemCollection items = base.Items;
							int num = items.IndexOf(this._selectionAnchor.Value.Item);
							int num2 = items.IndexOf(dataItem);
							if (num > num2)
							{
								int num3 = num;
								num = num2;
								num2 = num3;
							}
							if (num >= 0 && num2 >= 0)
							{
								IList selectedItems = base.SelectedItems;
								int count2 = selectedItems.Count;
								if (!flag2)
								{
									bool flag3 = false;
									for (int i = 0; i < count2; i++)
									{
										object item = selectedItems[i];
										int num4 = items.IndexOf(item);
										if (num4 < num || num2 < num4)
										{
											selectedItems.RemoveAt(i);
											if (!flag3)
											{
												this._selectedCells.Clear();
												flag3 = true;
											}
										}
									}
								}
								else
								{
									int num5 = items.IndexOf(this.CurrentCell.Item);
									int num6 = -1;
									int num7 = -1;
									if (num5 < num)
									{
										num6 = num5;
										num7 = num - 1;
									}
									else if (num5 > num2)
									{
										num6 = num2 + 1;
										num7 = num5;
									}
									if (num6 >= 0 && num7 >= 0)
									{
										for (int j = 0; j < count2; j++)
										{
											object item2 = selectedItems[j];
											int num8 = items.IndexOf(item2);
											if (num6 <= num8 && num8 <= num7)
											{
												selectedItems.RemoveAt(j);
											}
										}
										this._selectedCells.RemoveRegion(num6, 0, num7 - num6 + 1, this.Columns.Count);
									}
								}
								IEnumerator enumerator = ((IEnumerable)items).GetEnumerator();
								int num9 = 0;
								while (num9 <= num2 && enumerator.MoveNext())
								{
									if (num9 >= num)
									{
										selectedItems.Add(enumerator.Current);
									}
									num9++;
								}
								this._selectedCells.AddRegion(num, 0, num2 - num + 1, this._columns.Count);
							}
						}
					}
					else
					{
						if (flag2 && base.SelectedItems.Contains(dataItem))
						{
							this.UnselectItem(dataItem);
						}
						else
						{
							if (!flag2 || !base.CanSelectMultipleItems)
							{
								if (this._selectedCells.Count > 0)
								{
									this._selectedCells.Clear();
								}
								if (base.SelectedItems.Count > 0)
								{
									base.SelectedItems.Clear();
								}
							}
							if (this._editingRowIndex >= 0 && this._editingRowItem == dataItem)
							{
								int count3 = this._columns.Count;
								if (count3 > 0)
								{
									this._selectedCells.AddRegion(this._editingRowIndex, 0, 1, count3);
								}
								this.SelectItem(dataItem, false);
							}
							else
							{
								this.SelectItem(dataItem);
							}
						}
						this._selectionAnchor = new DataGridCellInfo?(new DataGridCellInfo(dataItem, this.ColumnFromDisplayIndex(0), this));
					}
				}
				finally
				{
					if (!isUpdatingSelectedItems)
					{
						base.EndUpdateSelectedItems();
					}
				}
			}
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x000104C0 File Offset: 0x0000E6C0
		private void MakeCellSelection(DataGridCellInfo cellInfo, bool allowsExtendSelect, bool allowsMinimalSelect)
		{
			bool flag = allowsExtendSelect && this.ShouldExtendSelection;
			bool flag2 = allowsMinimalSelect && DataGrid.ShouldMinimallyModifySelection;
			using (this.UpdateSelectedCells())
			{
				int displayIndex = cellInfo.Column.DisplayIndex;
				if (flag)
				{
					ItemCollection items = base.Items;
					int num = items.IndexOf(this._selectionAnchor.Value.Item);
					int num2 = items.IndexOf(cellInfo.Item);
					if (this._editingRowIndex >= 0)
					{
						if (this._selectionAnchor.Value.Item == this._editingRowItem)
						{
							num = this._editingRowIndex;
						}
						if (cellInfo.Item == this._editingRowItem)
						{
							num2 = this._editingRowIndex;
						}
					}
					DataGridColumn column = this._selectionAnchor.Value.Column;
					int displayIndex2 = column.DisplayIndex;
					int num3 = displayIndex;
					if (num >= 0 && num2 >= 0 && displayIndex2 >= 0 && num3 >= 0)
					{
						int num4 = Math.Abs(num2 - num) + 1;
						int num5 = Math.Abs(num3 - displayIndex2) + 1;
						if (!flag2)
						{
							if (base.SelectedItems.Count > 0)
							{
								base.UnselectAll();
							}
							this._selectedCells.Clear();
						}
						else
						{
							int num6 = items.IndexOf(this.CurrentCell.Item);
							if (this._editingRowIndex >= 0 && this._editingRowItem == this.CurrentCell.Item)
							{
								num6 = this._editingRowIndex;
							}
							int displayIndex3 = this.CurrentCell.Column.DisplayIndex;
							int num7 = Math.Min(num, num6);
							int num8 = Math.Abs(num6 - num) + 1;
							int columnIndex = Math.Min(displayIndex2, displayIndex3);
							int num9 = Math.Abs(displayIndex3 - displayIndex2) + 1;
							this._selectedCells.RemoveRegion(num7, columnIndex, num8, num9);
							if (this.SelectionUnit == DataGridSelectionUnit.CellOrRowHeader)
							{
								int num10 = num7;
								int num11 = num7 + num8 - 1;
								if (num9 <= num5)
								{
									if (num8 > num4)
									{
										int num12 = num8 - num4;
										num10 = ((num7 == num6) ? num6 : (num6 - num12 + 1));
										num11 = num10 + num12 - 1;
									}
									else
									{
										num11 = num10 - 1;
									}
								}
								for (int i = num10; i <= num11; i++)
								{
									object value = base.Items[i];
									if (base.SelectedItems.Contains(value))
									{
										base.SelectedItems.Remove(value);
									}
								}
							}
						}
						this._selectedCells.AddRegion(Math.Min(num, num2), Math.Min(displayIndex2, num3), num4, num5);
					}
				}
				else
				{
					bool flag3 = this._selectedCells.Contains(cellInfo);
					bool flag4 = this._editingRowIndex >= 0 && this._editingRowItem == cellInfo.Item;
					if (!flag3 && flag4)
					{
						flag3 = this._selectedCells.Contains(this._editingRowIndex, displayIndex);
					}
					if (flag2 && flag3)
					{
						if (flag4)
						{
							this._selectedCells.RemoveRegion(this._editingRowIndex, displayIndex, 1, 1);
						}
						else
						{
							this._selectedCells.Remove(cellInfo);
						}
						if (this.SelectionUnit == DataGridSelectionUnit.CellOrRowHeader && base.SelectedItems.Contains(cellInfo.Item))
						{
							base.SelectedItems.Remove(cellInfo.Item);
						}
					}
					else
					{
						if (!flag2 || !base.CanSelectMultipleItems)
						{
							if (base.SelectedItems.Count > 0)
							{
								base.UnselectAll();
							}
							this._selectedCells.Clear();
						}
						if (flag4)
						{
							this._selectedCells.AddRegion(this._editingRowIndex, displayIndex, 1, 1);
						}
						else
						{
							this._selectedCells.AddValidatedCell(cellInfo);
						}
					}
					this._selectionAnchor = new DataGridCellInfo?(cellInfo);
				}
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00010878 File Offset: 0x0000EA78
		private void SelectItem(object item)
		{
			this.SelectItem(item, true);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00010884 File Offset: 0x0000EA84
		private void SelectItem(object item, bool selectCells)
		{
			if (selectCells)
			{
				using (this.UpdateSelectedCells())
				{
					int num = base.Items.IndexOf(item);
					int count = this._columns.Count;
					if (num >= 0 && count > 0)
					{
						this._selectedCells.AddRegion(num, 0, 1, count);
					}
				}
			}
			this.UpdateSelectedItems(item, true);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000108F0 File Offset: 0x0000EAF0
		private void UnselectItem(object item)
		{
			using (this.UpdateSelectedCells())
			{
				int num = base.Items.IndexOf(item);
				int count = this._columns.Count;
				if (num >= 0 && count > 0)
				{
					this._selectedCells.RemoveRegion(num, 0, 1, count);
				}
			}
			this.UpdateSelectedItems(item, false);
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00010958 File Offset: 0x0000EB58
		private void UpdateSelectedItems(object item, bool add)
		{
			bool isUpdatingSelectedItems = base.IsUpdatingSelectedItems;
			if (!isUpdatingSelectedItems)
			{
				base.BeginUpdateSelectedItems();
			}
			try
			{
				if (add)
				{
					base.SelectedItems.Add(item);
				}
				else
				{
					base.SelectedItems.Remove(item);
				}
			}
			finally
			{
				if (!isUpdatingSelectedItems)
				{
					base.EndUpdateSelectedItems();
				}
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x000109B0 File Offset: 0x0000EBB0
		private IDisposable UpdateSelectedCells()
		{
			return new DataGrid.ChangingSelectedCellsHelper(this);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000109B8 File Offset: 0x0000EBB8
		private void BeginUpdateSelectedCells()
		{
			this._updatingSelectedCells = true;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x000109C1 File Offset: 0x0000EBC1
		private void EndUpdateSelectedCells()
		{
			this.UpdateIsSelected();
			this._updatingSelectedCells = false;
			this.NotifySelectedCellsChanged();
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x000109D6 File Offset: 0x0000EBD6
		private bool IsUpdatingSelectedCells
		{
			get
			{
				return this._updatingSelectedCells;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x000109DE File Offset: 0x0000EBDE
		private bool ShouldExtendSelection
		{
			get
			{
				return base.CanSelectMultipleItems && this._selectionAnchor != null && (this._isDraggingSelection || (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift);
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x00010A0B File Offset: 0x0000EC0B
		private static bool ShouldMinimallyModifySelection
		{
			get
			{
				return (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control;
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x00010A18 File Offset: 0x0000EC18
		private bool CanSelectRows
		{
			get
			{
				switch (this.SelectionUnit)
				{
				case DataGridSelectionUnit.Cell:
					return false;
				case DataGridSelectionUnit.FullRow:
				case DataGridSelectionUnit.CellOrRowHeader:
					return true;
				default:
					return false;
				}
			}
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00010A48 File Offset: 0x0000EC48
		private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this._currentCellContainer = null;
			using (this.UpdateSelectedCells())
			{
				this._selectedCells.OnItemsCollectionChanged(e, base.SelectedItems);
			}
			if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
			{
				using (IEnumerator enumerator = e.OldItems.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object item = enumerator.Current;
						this._itemAttachedStorage.ClearItem(item);
					}
					return;
				}
			}
			if (e.Action == NotifyCollectionChangedAction.Reset)
			{
				this._itemAttachedStorage.Clear();
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00010B00 File Offset: 0x0000ED00
		private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			d.CoerceValue(DataGrid.CanUserAddRowsProperty);
			d.CoerceValue(DataGrid.CanUserDeleteRowsProperty);
			if (!(bool)e.NewValue)
			{
				((DataGrid)d).UnselectAllCells();
			}
			CommandManager.InvalidateRequerySuggested();
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00010B38 File Offset: 0x0000ED38
		protected override void OnKeyDown(KeyEventArgs e)
		{
			Key key = e.Key;
			if (key != Key.Tab)
			{
				if (key != Key.Return)
				{
					switch (key)
					{
					case Key.Prior:
					case Key.Next:
						this.OnPageUpOrDownKeyDown(e);
						break;
					case Key.End:
					case Key.Home:
						this.OnHomeOrEndKeyDown(e);
						break;
					case Key.Left:
					case Key.Up:
					case Key.Right:
					case Key.Down:
						this.OnArrowKeyDown(e);
						break;
					}
				}
				else
				{
					this.OnEnterKeyDown(e);
				}
			}
			else
			{
				this.OnTabKeyDown(e);
			}
			if (!e.Handled)
			{
				base.OnKeyDown(e);
			}
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00010BBC File Offset: 0x0000EDBC
		private static FocusNavigationDirection KeyToTraversalDirection(Key key)
		{
			switch (key)
			{
			case Key.Left:
				return FocusNavigationDirection.Left;
			case Key.Up:
				return FocusNavigationDirection.Up;
			case Key.Right:
				return FocusNavigationDirection.Right;
			}
			return FocusNavigationDirection.Down;
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00010BF0 File Offset: 0x0000EDF0
		private void OnArrowKeyDown(KeyEventArgs e)
		{
			DataGridCell currentCellContainer = this.CurrentCellContainer;
			if (currentCellContainer != null)
			{
				e.Handled = true;
				bool isEditing = currentCellContainer.IsEditing;
				UIElement uielement = Keyboard.FocusedElement as UIElement;
				ContentElement contentElement = (uielement == null) ? (Keyboard.FocusedElement as ContentElement) : null;
				if (uielement != null || contentElement != null)
				{
					bool flag = e.OriginalSource == currentCellContainer;
					if (flag)
					{
						KeyboardNavigationMode directionalNavigation = KeyboardNavigation.GetDirectionalNavigation(this);
						if (directionalNavigation == KeyboardNavigationMode.Once)
						{
							DependencyObject dependencyObject = this.PredictFocus(DataGrid.KeyToTraversalDirection(e.Key));
							if (dependencyObject != null && !base.IsAncestorOf(dependencyObject))
							{
								Keyboard.Focus(dependencyObject as IInputElement);
							}
							return;
						}
						int displayIndex = this.CurrentColumn.DisplayIndex;
						object currentItem = this.CurrentItem;
						int num = base.Items.IndexOf(currentItem);
						if (this._editingRowIndex >= 0 && currentItem == this._editingRowItem)
						{
							num = this._editingRowIndex;
						}
						int i = displayIndex;
						int num2 = num;
						bool flag2 = (e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control;
						Key key = e.Key;
						if (base.FlowDirection == FlowDirection.RightToLeft)
						{
							if (key == Key.Left)
							{
								key = Key.Right;
							}
							else if (key == Key.Right)
							{
								key = Key.Left;
							}
						}
						switch (key)
						{
						case Key.Left:
							if (flag2)
							{
								i = this.InternalColumns.FirstVisibleDisplayIndex;
								goto IL_2D6;
							}
							for (i--; i >= 0; i--)
							{
								DataGridColumn dataGridColumn = this.ColumnFromDisplayIndex(i);
								if (dataGridColumn.IsVisible)
								{
									break;
								}
							}
							if (i >= 0)
							{
								goto IL_2D6;
							}
							if (directionalNavigation == KeyboardNavigationMode.Cycle)
							{
								i = this.InternalColumns.LastVisibleDisplayIndex;
								goto IL_2D6;
							}
							if (directionalNavigation == KeyboardNavigationMode.Contained)
							{
								return;
							}
							this.MoveFocus(new TraversalRequest((e.Key == Key.Left) ? FocusNavigationDirection.Left : FocusNavigationDirection.Right));
							return;
						case Key.Up:
							if (flag2)
							{
								num2 = 0;
								goto IL_2D6;
							}
							num2--;
							if (num2 >= 0)
							{
								goto IL_2D6;
							}
							if (directionalNavigation == KeyboardNavigationMode.Cycle)
							{
								num2 = base.Items.Count - 1;
								goto IL_2D6;
							}
							if (directionalNavigation == KeyboardNavigationMode.Contained)
							{
								return;
							}
							this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Up));
							return;
						case Key.Right:
						{
							if (flag2)
							{
								i = Math.Max(0, this.InternalColumns.LastVisibleDisplayIndex);
								goto IL_2D6;
							}
							i++;
							int count = this.Columns.Count;
							while (i < count)
							{
								DataGridColumn dataGridColumn2 = this.ColumnFromDisplayIndex(i);
								if (dataGridColumn2.IsVisible)
								{
									break;
								}
								i++;
							}
							if (i < this.Columns.Count)
							{
								goto IL_2D6;
							}
							if (directionalNavigation == KeyboardNavigationMode.Cycle)
							{
								i = this.InternalColumns.FirstVisibleDisplayIndex;
								goto IL_2D6;
							}
							if (directionalNavigation == KeyboardNavigationMode.Contained)
							{
								return;
							}
							this.MoveFocus(new TraversalRequest((e.Key == Key.Left) ? FocusNavigationDirection.Left : FocusNavigationDirection.Right));
							return;
						}
						}
						if (flag2)
						{
							num2 = Math.Max(0, base.Items.Count - 1);
						}
						else
						{
							num2++;
							if (num2 >= base.Items.Count)
							{
								if (directionalNavigation == KeyboardNavigationMode.Cycle)
								{
									num2 = 0;
								}
								else
								{
									if (directionalNavigation == KeyboardNavigationMode.Contained)
									{
										return;
									}
									this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
									return;
								}
							}
						}
						IL_2D6:
						DataGridColumn column = this.ColumnFromDisplayIndex(i);
						object item = base.Items[num2];
						this.ScrollCellIntoView(item, column);
						DataGridCell dataGridCell = this.TryFindCell(item, column);
						if (dataGridCell == null || dataGridCell == currentCellContainer || !dataGridCell.Focus())
						{
							return;
						}
					}
					TraversalRequest request = new TraversalRequest(DataGrid.KeyToTraversalDirection(e.Key));
					if (flag || (uielement != null && uielement.MoveFocus(request)) || (contentElement != null && contentElement.MoveFocus(request)))
					{
						this.SelectAndEditOnFocusMove(e, currentCellContainer, isEditing, true, true);
					}
				}
			}
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00010F50 File Offset: 0x0000F150
		private void OnTabKeyDown(KeyEventArgs e)
		{
			DataGridCell currentCellContainer = this.CurrentCellContainer;
			if (currentCellContainer != null)
			{
				bool isEditing = currentCellContainer.IsEditing;
				bool flag = (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
				UIElement uielement = Keyboard.FocusedElement as UIElement;
				ContentElement contentElement = (uielement == null) ? (Keyboard.FocusedElement as ContentElement) : null;
				if (uielement != null || contentElement != null)
				{
					e.Handled = true;
					FocusNavigationDirection focusNavigationDirection = flag ? FocusNavigationDirection.Previous : FocusNavigationDirection.Next;
					TraversalRequest traversalRequest = new TraversalRequest(focusNavigationDirection);
					traversalRequest.Wrapped = true;
					if ((uielement != null && uielement.MoveFocus(traversalRequest)) || (contentElement != null && contentElement.MoveFocus(traversalRequest)))
					{
						if (isEditing && flag && Keyboard.FocusedElement == currentCellContainer)
						{
							currentCellContainer.MoveFocus(traversalRequest);
						}
						if (base.IsGrouping && isEditing)
						{
							DataGridCell cellForSelectAndEditOnFocusMove = this.GetCellForSelectAndEditOnFocusMove();
							if (cellForSelectAndEditOnFocusMove != null && cellForSelectAndEditOnFocusMove.RowDataItem == currentCellContainer.RowDataItem)
							{
								DataGridCell dataGridCell = this.TryFindCell(cellForSelectAndEditOnFocusMove.RowDataItem, cellForSelectAndEditOnFocusMove.Column);
								if (dataGridCell == null)
								{
									base.UpdateLayout();
									dataGridCell = this.TryFindCell(cellForSelectAndEditOnFocusMove.RowDataItem, cellForSelectAndEditOnFocusMove.Column);
								}
								if (dataGridCell != null && dataGridCell != cellForSelectAndEditOnFocusMove)
								{
									dataGridCell.Focus();
								}
							}
						}
						this.SelectAndEditOnFocusMove(e, currentCellContainer, isEditing, false, true);
					}
				}
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x0001107C File Offset: 0x0000F27C
		private void OnEnterKeyDown(KeyEventArgs e)
		{
			DataGridCell currentCellContainer = this.CurrentCellContainer;
			if (currentCellContainer != null && this._columns.Count > 0)
			{
				e.Handled = true;
				DataGridColumn column = currentCellContainer.Column;
				if (this.CommitAnyEdit() && (e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.None)
				{
					bool flag = (e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift;
					int count = base.Items.Count;
					int num = Math.Max(0, Math.Min(count - 1, base.Items.IndexOf(currentCellContainer.RowDataItem) + (flag ? -1 : 1)));
					if (num < count)
					{
						object obj = base.Items[num];
						this.ScrollIntoView(obj, column);
						if (this.CurrentCell.Item != obj)
						{
							this.CurrentCell = new DataGridCellInfo(obj, column, this);
							this.SelectAndEditOnFocusMove(e, currentCellContainer, false, false, true);
							return;
						}
						currentCellContainer = this.CurrentCellContainer;
						if (currentCellContainer != null)
						{
							currentCellContainer.Focus();
						}
					}
				}
			}
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00011174 File Offset: 0x0000F374
		private DataGridCell GetCellForSelectAndEditOnFocusMove()
		{
			DataGridCell dataGridCell = Keyboard.FocusedElement as DataGridCell;
			if (dataGridCell == null && this.CurrentCellContainer != null && this.CurrentCellContainer.IsKeyboardFocusWithin)
			{
				dataGridCell = this.CurrentCellContainer;
			}
			return dataGridCell;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x000111AC File Offset: 0x0000F3AC
		private void SelectAndEditOnFocusMove(KeyEventArgs e, DataGridCell oldCell, bool wasEditing, bool allowsExtendSelect, bool ignoreControlKey)
		{
			DataGridCell cellForSelectAndEditOnFocusMove = this.GetCellForSelectAndEditOnFocusMove();
			if (cellForSelectAndEditOnFocusMove != null && cellForSelectAndEditOnFocusMove.DataGridOwner == this)
			{
				if (ignoreControlKey || (e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.None)
				{
					if (this.ShouldSelectRowHeader && allowsExtendSelect)
					{
						this.HandleSelectionForRowHeaderAndDetailsInput(cellForSelectAndEditOnFocusMove.RowOwner, false);
					}
					else
					{
						this.HandleSelectionForCellInput(cellForSelectAndEditOnFocusMove, false, allowsExtendSelect, false);
					}
				}
				if (wasEditing && !cellForSelectAndEditOnFocusMove.IsEditing && oldCell.RowDataItem == cellForSelectAndEditOnFocusMove.RowDataItem)
				{
					this.BeginEdit(e);
				}
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00011228 File Offset: 0x0000F428
		private void OnHomeOrEndKeyDown(KeyEventArgs e)
		{
			if (this._columns.Count > 0 && base.Items.Count > 0)
			{
				e.Handled = true;
				bool flag = e.Key == Key.Home;
				object item = ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) ? base.Items[flag ? 0 : (base.Items.Count - 1)] : this.CurrentItem;
				DataGridColumn column = this.ColumnFromDisplayIndex(flag ? this.InternalColumns.FirstVisibleDisplayIndex : this.InternalColumns.LastVisibleDisplayIndex);
				this.ScrollCellIntoView(item, column);
				DataGridCell dataGridCell = this.TryFindCell(item, column);
				if (dataGridCell != null)
				{
					dataGridCell.Focus();
					if (this.ShouldSelectRowHeader)
					{
						this.HandleSelectionForRowHeaderAndDetailsInput(dataGridCell.RowOwner, false);
						return;
					}
					this.HandleSelectionForCellInput(dataGridCell, false, true, false);
				}
			}
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00011308 File Offset: 0x0000F508
		private void OnPageUpOrDownKeyDown(KeyEventArgs e)
		{
			ScrollViewer internalScrollHost = this.InternalScrollHost;
			if (internalScrollHost != null)
			{
				object currentItem = this.CurrentItem;
				DataGridColumn currentColumn = this.CurrentColumn;
				int num = base.Items.IndexOf(currentItem);
				if (num >= 0)
				{
					int num2 = Math.Max(1, (int)internalScrollHost.ViewportHeight - 1);
					int num3 = (e.Key == Key.Prior) ? (num - num2) : (num + num2);
					num3 = Math.Max(0, Math.Min(num3, base.Items.Count - 1));
					object obj = base.Items[num3];
					if (currentColumn == null)
					{
						this.ScrollRowIntoView(obj);
						this.CurrentItem = obj;
						return;
					}
					this.ScrollCellIntoView(obj, currentColumn);
					DataGridCell dataGridCell = this.TryFindCell(obj, currentColumn);
					if (dataGridCell != null)
					{
						dataGridCell.Focus();
						if (this.ShouldSelectRowHeader)
						{
							this.HandleSelectionForRowHeaderAndDetailsInput(dataGridCell.RowOwner, false);
							return;
						}
						this.HandleSelectionForCellInput(dataGridCell, false, true, false);
					}
				}
			}
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x000113EC File Offset: 0x0000F5EC
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (this._isDraggingSelection)
			{
				if (e.LeftButton == MouseButtonState.Pressed)
				{
					Point position = Mouse.GetPosition(this);
					if (!DoubleUtil.AreClose(position, this._dragPoint))
					{
						this._dragPoint = position;
						DataGrid.RelativeMousePositions relativeMousePosition = this.RelativeMousePosition;
						if (relativeMousePosition == DataGrid.RelativeMousePositions.Over)
						{
							if (this._isRowDragging)
							{
								DataGridRow mouseOverRow = DataGrid.MouseOverRow;
								if (mouseOverRow != null && mouseOverRow.Item != this.CurrentItem)
								{
									this.HandleSelectionForRowHeaderAndDetailsInput(mouseOverRow, false);
									this.CurrentItem = mouseOverRow.Item;
									e.Handled = true;
									return;
								}
							}
							else
							{
								DataGridCell dataGridCell = DataGrid.MouseOverCell;
								if (dataGridCell == null)
								{
									DataGridRow mouseOverRow2 = DataGrid.MouseOverRow;
									if (mouseOverRow2 != null)
									{
										dataGridCell = this.GetCellNearMouse();
									}
								}
								if (dataGridCell != null && dataGridCell != this.CurrentCellContainer)
								{
									this.HandleSelectionForCellInput(dataGridCell, false, true, true);
									dataGridCell.Focus();
									e.Handled = true;
									return;
								}
							}
						}
						else if (this._isRowDragging && DataGrid.IsMouseToLeftOrRightOnly(relativeMousePosition))
						{
							DataGridRow rowNearMouse = this.GetRowNearMouse();
							if (rowNearMouse != null && rowNearMouse.Item != this.CurrentItem)
							{
								this.HandleSelectionForRowHeaderAndDetailsInput(rowNearMouse, false);
								this.CurrentItem = rowNearMouse.Item;
								e.Handled = true;
								return;
							}
						}
						else
						{
							if (!this._hasAutoScrolled)
							{
								this.StartAutoScroll();
								return;
							}
							if (this.DoAutoScroll())
							{
								e.Handled = true;
								return;
							}
						}
					}
				}
				else
				{
					this.EndDragging();
				}
			}
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00011531 File Offset: 0x0000F731
		private static void OnAnyMouseUpThunk(object sender, MouseButtonEventArgs e)
		{
			((DataGrid)sender).OnAnyMouseUp(e);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0001153F File Offset: 0x0000F73F
		private void OnAnyMouseUp(MouseButtonEventArgs e)
		{
			this.EndDragging();
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00011548 File Offset: 0x0000F748
		protected override void OnContextMenuOpening(ContextMenuEventArgs e)
		{
			DataGridCell dataGridCell = null;
			Microsoft.Windows.Controls.Primitives.DataGridRowHeader dataGridRowHeader = null;
			for (UIElement uielement = e.OriginalSource as UIElement; uielement != null; uielement = (VisualTreeHelper.GetParent(uielement) as UIElement))
			{
				dataGridCell = (uielement as DataGridCell);
				if (dataGridCell != null)
				{
					break;
				}
				dataGridRowHeader = (uielement as Microsoft.Windows.Controls.Primitives.DataGridRowHeader);
				if (dataGridRowHeader != null)
				{
					break;
				}
			}
			if (dataGridCell != null && !dataGridCell.IsSelected && !dataGridCell.IsKeyboardFocusWithin)
			{
				dataGridCell.Focus();
				this.HandleSelectionForCellInput(dataGridCell, false, true, true);
			}
			if (dataGridRowHeader != null)
			{
				DataGridRow parentRow = dataGridRowHeader.ParentRow;
				if (parentRow != null)
				{
					this.HandleSelectionForRowHeaderAndDetailsInput(parentRow, false);
				}
			}
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x000115C4 File Offset: 0x0000F7C4
		private DataGridRow GetRowNearMouse()
		{
			Panel internalItemsHost = this.InternalItemsHost;
			if (internalItemsHost != null)
			{
				int count = internalItemsHost.Children.Count;
				for (int i = count - 1; i >= 0; i--)
				{
					DataGridRow dataGridRow = internalItemsHost.Children[i] as DataGridRow;
					if (dataGridRow != null)
					{
						Point position = Mouse.GetPosition(dataGridRow);
						Rect rect = new Rect(default(Point), dataGridRow.RenderSize);
						if (position.Y >= rect.Top && position.Y <= rect.Bottom)
						{
							return dataGridRow;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x0001164C File Offset: 0x0000F84C
		private DataGridCell GetCellNearMouse()
		{
			Panel internalItemsHost = this.InternalItemsHost;
			if (internalItemsHost != null)
			{
				Rect itemsHostBounds = new Rect(default(Point), internalItemsHost.RenderSize);
				double num = double.PositiveInfinity;
				DataGridCell dataGridCell = null;
				bool isMouseInCorner = DataGrid.IsMouseInCorner(this.RelativeMousePosition);
				int count = internalItemsHost.Children.Count;
				for (int i = count - 1; i >= 0; i--)
				{
					DataGridRow dataGridRow = internalItemsHost.Children[i] as DataGridRow;
					if (dataGridRow != null)
					{
						Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = dataGridRow.CellsPresenter;
						if (cellsPresenter != null)
						{
							for (ContainerTracking<DataGridCell> containerTracking = cellsPresenter.CellTrackingRoot; containerTracking != null; containerTracking = containerTracking.Next)
							{
								DataGridCell container = containerTracking.Container;
								double num2;
								if (DataGrid.CalculateCellDistance(container, dataGridRow, internalItemsHost, itemsHostBounds, isMouseInCorner, out num2) && (dataGridCell == null || num2 < num))
								{
									num = num2;
									dataGridCell = container;
								}
							}
							Microsoft.Windows.Controls.Primitives.DataGridRowHeader rowHeader = dataGridRow.RowHeader;
							double num3;
							if (rowHeader != null && DataGrid.CalculateCellDistance(rowHeader, dataGridRow, internalItemsHost, itemsHostBounds, isMouseInCorner, out num3) && (dataGridCell == null || num3 < num))
							{
								DataGridCell dataGridCell2 = dataGridRow.TryGetCell(this.DisplayIndexMap[0]);
								if (dataGridCell2 != null)
								{
									num = num3;
									dataGridCell = dataGridCell2;
								}
							}
						}
					}
				}
				return dataGridCell;
			}
			return null;
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00011770 File Offset: 0x0000F970
		private static bool CalculateCellDistance(FrameworkElement cell, DataGridRow rowOwner, Panel itemsHost, Rect itemsHostBounds, bool isMouseInCorner, out double distance)
		{
			GeneralTransform generalTransform = cell.TransformToAncestor(itemsHost);
			Rect rect = new Rect(default(Point), cell.RenderSize);
			if (itemsHostBounds.Contains(generalTransform.TransformBounds(rect)))
			{
				Point position = Mouse.GetPosition(cell);
				if (isMouseInCorner)
				{
					Vector vector = new Vector(position.X - rect.Width * 0.5, position.Y - rect.Height * 0.5);
					distance = vector.Length;
					return true;
				}
				Point position2 = Mouse.GetPosition(rowOwner);
				Rect rect2 = new Rect(default(Point), rowOwner.RenderSize);
				if (position.X >= rect.Left && position.X <= rect.Right)
				{
					if (position2.Y >= rect2.Top && position2.Y <= rect2.Bottom)
					{
						distance = 0.0;
					}
					else
					{
						distance = Math.Abs(position.Y - rect.Top);
					}
					return true;
				}
				if (position2.Y >= rect2.Top && position2.Y <= rect2.Bottom)
				{
					distance = Math.Abs(position.X - rect.Left);
					return true;
				}
			}
			distance = double.PositiveInfinity;
			return false;
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000456 RID: 1110 RVA: 0x000118CB File Offset: 0x0000FACB
		private static DataGridRow MouseOverRow
		{
			get
			{
				return DataGridHelper.FindVisualParent<DataGridRow>(Mouse.DirectlyOver as UIElement);
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x000118DC File Offset: 0x0000FADC
		private static DataGridCell MouseOverCell
		{
			get
			{
				return DataGridHelper.FindVisualParent<DataGridCell>(Mouse.DirectlyOver as UIElement);
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000458 RID: 1112 RVA: 0x000118F0 File Offset: 0x0000FAF0
		private DataGrid.RelativeMousePositions RelativeMousePosition
		{
			get
			{
				DataGrid.RelativeMousePositions relativeMousePositions = DataGrid.RelativeMousePositions.Over;
				Panel internalItemsHost = this.InternalItemsHost;
				if (internalItemsHost != null)
				{
					Point position = Mouse.GetPosition(internalItemsHost);
					Rect rect = new Rect(default(Point), internalItemsHost.RenderSize);
					if (position.X < rect.Left)
					{
						relativeMousePositions |= DataGrid.RelativeMousePositions.Left;
					}
					else if (position.X > rect.Right)
					{
						relativeMousePositions |= DataGrid.RelativeMousePositions.Right;
					}
					if (position.Y < rect.Top)
					{
						relativeMousePositions |= DataGrid.RelativeMousePositions.Above;
					}
					else if (position.Y > rect.Bottom)
					{
						relativeMousePositions |= DataGrid.RelativeMousePositions.Below;
					}
				}
				return relativeMousePositions;
			}
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0001197C File Offset: 0x0000FB7C
		private static bool IsMouseToLeft(DataGrid.RelativeMousePositions position)
		{
			return (position & DataGrid.RelativeMousePositions.Left) == DataGrid.RelativeMousePositions.Left;
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x00011984 File Offset: 0x0000FB84
		private static bool IsMouseToRight(DataGrid.RelativeMousePositions position)
		{
			return (position & DataGrid.RelativeMousePositions.Right) == DataGrid.RelativeMousePositions.Right;
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0001198C File Offset: 0x0000FB8C
		private static bool IsMouseAbove(DataGrid.RelativeMousePositions position)
		{
			return (position & DataGrid.RelativeMousePositions.Above) == DataGrid.RelativeMousePositions.Above;
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x00011994 File Offset: 0x0000FB94
		private static bool IsMouseBelow(DataGrid.RelativeMousePositions position)
		{
			return (position & DataGrid.RelativeMousePositions.Below) == DataGrid.RelativeMousePositions.Below;
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0001199C File Offset: 0x0000FB9C
		private static bool IsMouseToLeftOrRightOnly(DataGrid.RelativeMousePositions position)
		{
			return position == DataGrid.RelativeMousePositions.Left || position == DataGrid.RelativeMousePositions.Right;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x000119A8 File Offset: 0x0000FBA8
		private static bool IsMouseInCorner(DataGrid.RelativeMousePositions position)
		{
			return position != DataGrid.RelativeMousePositions.Over && position != DataGrid.RelativeMousePositions.Above && position != DataGrid.RelativeMousePositions.Below && position != DataGrid.RelativeMousePositions.Left && position != DataGrid.RelativeMousePositions.Right;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x000119C2 File Offset: 0x0000FBC2
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new Microsoft.Windows.Automation.Peers.DataGridAutomationPeer(this);
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x000119CA File Offset: 0x0000FBCA
		private DataGridCell TryFindCell(DataGridCellInfo info)
		{
			return this.TryFindCell(info.Item, info.Column);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x000119E0 File Offset: 0x0000FBE0
		internal DataGridCell TryFindCell(object item, DataGridColumn column)
		{
			DataGridRow dataGridRow = (DataGridRow)base.ItemContainerGenerator.ContainerFromItem(item);
			int num = this._columns.IndexOf(column);
			if (dataGridRow != null && num >= 0)
			{
				return dataGridRow.TryGetCell(num);
			}
			return null;
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000462 RID: 1122 RVA: 0x00011A1C File Offset: 0x0000FC1C
		// (set) Token: 0x06000463 RID: 1123 RVA: 0x00011A2E File Offset: 0x0000FC2E
		public bool CanUserSortColumns
		{
			get
			{
				return (bool)base.GetValue(DataGrid.CanUserSortColumnsProperty);
			}
			set
			{
				base.SetValue(DataGrid.CanUserSortColumnsProperty, value);
			}
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00011A44 File Offset: 0x0000FC44
		private static object OnCoerceCanUserSortColumns(DependencyObject d, object baseValue)
		{
			DataGrid dataGrid = (DataGrid)d;
			if (DataGridHelper.IsPropertyTransferEnabled(dataGrid, DataGrid.CanUserSortColumnsProperty) && DataGridHelper.IsDefaultValue(dataGrid, DataGrid.CanUserSortColumnsProperty) && !dataGrid.Items.CanSort)
			{
				return false;
			}
			return baseValue;
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00011A88 File Offset: 0x0000FC88
		private static void OnCanUserSortColumnsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid d2 = (DataGrid)d;
			DataGridHelper.TransferProperty(d2, DataGrid.CanUserSortColumnsProperty);
			DataGrid.OnNotifyColumnPropertyChanged(d, e);
		}

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x06000466 RID: 1126 RVA: 0x00011AAE File Offset: 0x0000FCAE
		// (remove) Token: 0x06000467 RID: 1127 RVA: 0x00011AC7 File Offset: 0x0000FCC7
		public event DataGridSortingEventHandler Sorting;

		// Token: 0x06000468 RID: 1128 RVA: 0x00011AE0 File Offset: 0x0000FCE0
		protected virtual void OnSorting(DataGridSortingEventArgs eventArgs)
		{
			eventArgs.Handled = false;
			if (this.Sorting != null)
			{
				this.Sorting(this, eventArgs);
			}
			if (!eventArgs.Handled)
			{
				this.DefaultSort(eventArgs.Column, (Keyboard.Modifiers & ModifierKeys.Shift) != ModifierKeys.Shift);
			}
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00011B20 File Offset: 0x0000FD20
		internal void PerformSort(DataGridColumn sortColumn)
		{
			if (!this.CanUserSortColumns || !sortColumn.CanUserSort)
			{
				return;
			}
			if (this.CommitAnyEdit())
			{
				this.PrepareForSort(sortColumn);
				DataGridSortingEventArgs eventArgs = new DataGridSortingEventArgs(sortColumn);
				this.OnSorting(eventArgs);
				if (base.Items.NeedsRefresh)
				{
					try
					{
						base.Items.Refresh();
					}
					catch (InvalidOperationException innerException)
					{
						base.Items.SortDescriptions.Clear();
						throw new InvalidOperationException(SR.Get(SRID.DataGrid_ProbableInvalidSortDescription), innerException);
					}
				}
			}
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00011BA8 File Offset: 0x0000FDA8
		private void PrepareForSort(DataGridColumn sortColumn)
		{
			if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
			{
				return;
			}
			if (this.Columns != null)
			{
				foreach (DataGridColumn dataGridColumn in this.Columns)
				{
					if (dataGridColumn != sortColumn)
					{
						dataGridColumn.SortDirection = null;
					}
				}
			}
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00011C14 File Offset: 0x0000FE14
		private void DefaultSort(DataGridColumn column, bool clearExistingSortDescriptions)
		{
			ListSortDirection listSortDirection = ListSortDirection.Ascending;
			ListSortDirection? sortDirection = column.SortDirection;
			if (sortDirection != null && sortDirection.Value == ListSortDirection.Ascending)
			{
				listSortDirection = ListSortDirection.Descending;
			}
			string sortMemberPath = column.SortMemberPath;
			if (!string.IsNullOrEmpty(sortMemberPath))
			{
				int num = -1;
				if (clearExistingSortDescriptions)
				{
					base.Items.SortDescriptions.Clear();
				}
				else
				{
					for (int i = 0; i < base.Items.SortDescriptions.Count; i++)
					{
						if (string.Compare(base.Items.SortDescriptions[i].PropertyName, sortMemberPath, StringComparison.Ordinal) == 0 && (this.GroupingSortDescriptionIndices == null || !this.GroupingSortDescriptionIndices.Contains(i)))
						{
							num = i;
							break;
						}
					}
				}
				SortDescription sortDescription = new SortDescription(sortMemberPath, listSortDirection);
				try
				{
					if (num >= 0)
					{
						base.Items.SortDescriptions[num] = sortDescription;
					}
					else
					{
						base.Items.SortDescriptions.Add(sortDescription);
					}
					if (clearExistingSortDescriptions || !this._sortingStarted)
					{
						this.RegenerateGroupingSortDescriptions();
						this._sortingStarted = true;
					}
				}
				catch (InvalidOperationException innerException)
				{
					base.Items.SortDescriptions.Clear();
					throw new InvalidOperationException(SR.Get(SRID.DataGrid_InvalidSortDescription), innerException);
				}
				column.SortDirection = new ListSortDirection?(listSortDirection);
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x00011D54 File Offset: 0x0000FF54
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x00011D5C File Offset: 0x0000FF5C
		private List<int> GroupingSortDescriptionIndices
		{
			get
			{
				return this._groupingSortDescriptionIndices;
			}
			set
			{
				this._groupingSortDescriptionIndices = value;
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00011D68 File Offset: 0x0000FF68
		private void OnItemsSortDescriptionsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (this._ignoreSortDescriptionsChange || this.GroupingSortDescriptionIndices == null)
			{
				return;
			}
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
			{
				int i = 0;
				int count = this.GroupingSortDescriptionIndices.Count;
				while (i < count)
				{
					if (this.GroupingSortDescriptionIndices[i] >= e.NewStartingIndex)
					{
						List<int> groupingSortDescriptionIndices;
						int index;
						(groupingSortDescriptionIndices = this.GroupingSortDescriptionIndices)[index = i] = groupingSortDescriptionIndices[index] + 1;
					}
					i++;
				}
				return;
			}
			case NotifyCollectionChangedAction.Remove:
			{
				int j = 0;
				int num = this.GroupingSortDescriptionIndices.Count;
				while (j < num)
				{
					if (this.GroupingSortDescriptionIndices[j] > e.OldStartingIndex)
					{
						List<int> groupingSortDescriptionIndices2;
						int index2;
						(groupingSortDescriptionIndices2 = this.GroupingSortDescriptionIndices)[index2 = j] = groupingSortDescriptionIndices2[index2] - 1;
					}
					else if (this.GroupingSortDescriptionIndices[j] == e.OldStartingIndex)
					{
						this.GroupingSortDescriptionIndices.RemoveAt(j);
						j--;
						num--;
					}
					j++;
				}
				return;
			}
			case NotifyCollectionChangedAction.Replace:
				this.GroupingSortDescriptionIndices.Remove(e.OldStartingIndex);
				return;
			case NotifyCollectionChangedAction.Move:
				break;
			case NotifyCollectionChangedAction.Reset:
				this.GroupingSortDescriptionIndices.Clear();
				break;
			default:
				return;
			}
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00011E88 File Offset: 0x00010088
		private void RemoveGroupingSortDescriptions()
		{
			if (this.GroupingSortDescriptionIndices == null)
			{
				return;
			}
			bool ignoreSortDescriptionsChange = this._ignoreSortDescriptionsChange;
			this._ignoreSortDescriptionsChange = true;
			try
			{
				int i = 0;
				int count = this.GroupingSortDescriptionIndices.Count;
				while (i < count)
				{
					base.Items.SortDescriptions.RemoveAt(this.GroupingSortDescriptionIndices[i] - i);
					i++;
				}
				this.GroupingSortDescriptionIndices.Clear();
			}
			finally
			{
				this._ignoreSortDescriptionsChange = ignoreSortDescriptionsChange;
			}
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00011F08 File Offset: 0x00010108
		private static bool CanConvertToSortDescription(PropertyGroupDescription propertyGroupDescription)
		{
			return propertyGroupDescription != null && propertyGroupDescription.Converter == null && propertyGroupDescription.StringComparison == StringComparison.Ordinal;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00011F24 File Offset: 0x00010124
		private void AddGroupingSortDescriptions()
		{
			bool ignoreSortDescriptionsChange = this._ignoreSortDescriptionsChange;
			this._ignoreSortDescriptionsChange = true;
			try
			{
				int index = 0;
				foreach (GroupDescription groupDescription in base.Items.GroupDescriptions)
				{
					PropertyGroupDescription propertyGroupDescription = groupDescription as PropertyGroupDescription;
					if (DataGrid.CanConvertToSortDescription(propertyGroupDescription))
					{
						SortDescription item = new SortDescription(propertyGroupDescription.PropertyName, ListSortDirection.Ascending);
						base.Items.SortDescriptions.Insert(index, item);
						if (this.GroupingSortDescriptionIndices == null)
						{
							this.GroupingSortDescriptionIndices = new List<int>();
						}
						this.GroupingSortDescriptionIndices.Add(index++);
					}
				}
			}
			finally
			{
				this._ignoreSortDescriptionsChange = ignoreSortDescriptionsChange;
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00011FF0 File Offset: 0x000101F0
		private void RegenerateGroupingSortDescriptions()
		{
			this.RemoveGroupingSortDescriptions();
			this.AddGroupingSortDescriptions();
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00012000 File Offset: 0x00010200
		private void OnItemsGroupDescriptionsChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (!this._sortingStarted)
			{
				return;
			}
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				if (DataGrid.CanConvertToSortDescription(e.NewItems[0] as PropertyGroupDescription))
				{
					this.RegenerateGroupingSortDescriptions();
					return;
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				if (DataGrid.CanConvertToSortDescription(e.OldItems[0] as PropertyGroupDescription))
				{
					this.RegenerateGroupingSortDescriptions();
					return;
				}
				break;
			case NotifyCollectionChangedAction.Replace:
				if (DataGrid.CanConvertToSortDescription(e.OldItems[0] as PropertyGroupDescription) || DataGrid.CanConvertToSortDescription(e.NewItems[0] as PropertyGroupDescription))
				{
					this.RegenerateGroupingSortDescriptions();
					return;
				}
				break;
			case NotifyCollectionChangedAction.Move:
				break;
			case NotifyCollectionChangedAction.Reset:
				this.RemoveGroupingSortDescriptions();
				break;
			default:
				return;
			}
		}

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000474 RID: 1140 RVA: 0x000120B3 File Offset: 0x000102B3
		// (remove) Token: 0x06000475 RID: 1141 RVA: 0x000120CC File Offset: 0x000102CC
		public event EventHandler AutoGeneratedColumns;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000476 RID: 1142 RVA: 0x000120E5 File Offset: 0x000102E5
		// (remove) Token: 0x06000477 RID: 1143 RVA: 0x000120FE File Offset: 0x000102FE
		public event EventHandler<DataGridAutoGeneratingColumnEventArgs> AutoGeneratingColumn;

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x00012117 File Offset: 0x00010317
		// (set) Token: 0x06000479 RID: 1145 RVA: 0x00012129 File Offset: 0x00010329
		public bool AutoGenerateColumns
		{
			get
			{
				return (bool)base.GetValue(DataGrid.AutoGenerateColumnsProperty);
			}
			set
			{
				base.SetValue(DataGrid.AutoGenerateColumnsProperty, value);
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0001213C File Offset: 0x0001033C
		protected virtual void OnAutoGeneratedColumns(EventArgs e)
		{
			if (this.AutoGeneratedColumns != null)
			{
				this.AutoGeneratedColumns(this, e);
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x00012153 File Offset: 0x00010353
		protected virtual void OnAutoGeneratingColumn(DataGridAutoGeneratingColumnEventArgs e)
		{
			if (this.AutoGeneratingColumn != null)
			{
				this.AutoGeneratingColumn(this, e);
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0001216C File Offset: 0x0001036C
		protected override Size MeasureOverride(Size availableSize)
		{
			if (this._measureNeverInvoked)
			{
				this._measureNeverInvoked = false;
				if (this.AutoGenerateColumns)
				{
					this.AddAutoColumns();
				}
				this.InternalColumns.InitializeDisplayIndexMap();
				base.CoerceValue(DataGrid.FrozenColumnCountProperty);
				base.CoerceValue(DataGrid.CanUserAddRowsProperty);
				base.CoerceValue(DataGrid.CanUserDeleteRowsProperty);
				this.UpdateNewItemPlaceholder(false);
			}
			else if (this.DeferAutoGeneration && this.AutoGenerateColumns)
			{
				this.AddAutoColumns();
			}
			return base.MeasureOverride(availableSize);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x000121E8 File Offset: 0x000103E8
		private void ClearSortDescriptionsOnItemsSourceChange()
		{
			base.Items.SortDescriptions.Clear();
			this._sortingStarted = false;
			List<int> groupingSortDescriptionIndices = this.GroupingSortDescriptionIndices;
			if (groupingSortDescriptionIndices != null)
			{
				groupingSortDescriptionIndices.Clear();
			}
			foreach (DataGridColumn dataGridColumn in this.Columns)
			{
				dataGridColumn.SortDirection = null;
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00012264 File Offset: 0x00010464
		private static object OnCoerceItemsSourceProperty(DependencyObject d, object baseValue)
		{
			DataGrid dataGrid = (DataGrid)d;
			if (baseValue != dataGrid._cachedItemsSource && dataGrid._cachedItemsSource != null)
			{
				dataGrid.ClearSortDescriptionsOnItemsSourceChange();
			}
			return baseValue;
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x00012290 File Offset: 0x00010490
		protected override void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
		{
			base.OnItemsSourceChanged(oldValue, newValue);
			if (newValue == null)
			{
				this.ClearSortDescriptionsOnItemsSourceChange();
			}
			this._cachedItemsSource = newValue;
			using (this.UpdateSelectedCells())
			{
				this._selectedCells.RestoreOnlyFullRows(base.SelectedItems);
			}
			if (this.AutoGenerateColumns)
			{
				this.RegenerateAutoColumns();
			}
			this.InternalColumns.RefreshAutoWidthColumns = true;
			this.InternalColumns.InvalidateColumnWidthsComputation();
			base.CoerceValue(DataGrid.CanUserAddRowsProperty);
			base.CoerceValue(DataGrid.CanUserDeleteRowsProperty);
			DataGridHelper.TransferProperty(this, DataGrid.CanUserSortColumnsProperty);
			this.ResetRowHeaderActualWidth();
			this.UpdateNewItemPlaceholder(false);
			this.HasCellValidationError = false;
			this.HasRowValidationError = false;
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0001234C File Offset: 0x0001054C
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x00012354 File Offset: 0x00010554
		private bool DeferAutoGeneration { get; set; }

		// Token: 0x06000482 RID: 1154 RVA: 0x00012360 File Offset: 0x00010560
		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnItemsChanged(e);
			if (e.Action == NotifyCollectionChangedAction.Add)
			{
				if (this.DeferAutoGeneration)
				{
					this.AddAutoColumns();
					return;
				}
			}
			else
			{
				if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
				{
					if (!this.HasRowValidationError && !this.HasCellValidationError)
					{
						return;
					}
					using (IEnumerator enumerator = e.OldItems.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object item = enumerator.Current;
							if (this.IsAddingOrEditingRowItem(item))
							{
								this.HasRowValidationError = false;
								this.HasCellValidationError = false;
								break;
							}
						}
						return;
					}
				}
				if (e.Action == NotifyCollectionChangedAction.Reset)
				{
					this.ResetRowHeaderActualWidth();
					this.HasRowValidationError = false;
					this.HasCellValidationError = false;
				}
			}
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00012428 File Offset: 0x00010628
		private void AddAutoColumns()
		{
			if (this.DataItemsCount == 0)
			{
				this.DeferAutoGeneration = true;
				return;
			}
			if (!this._measureNeverInvoked)
			{
				DataGrid.GenerateColumns(base.Items, this, null);
				this.DeferAutoGeneration = false;
				this.OnAutoGeneratedColumns(EventArgs.Empty);
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00012464 File Offset: 0x00010664
		private void DeleteAutoColumns()
		{
			if (!this.DeferAutoGeneration && !this._measureNeverInvoked)
			{
				for (int i = this.Columns.Count - 1; i >= 0; i--)
				{
					if (this.Columns[i].IsAutoGenerated)
					{
						this.Columns.RemoveAt(i);
					}
				}
				return;
			}
			this.DeferAutoGeneration = false;
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x000124C0 File Offset: 0x000106C0
		private void RegenerateAutoColumns()
		{
			this.DeleteAutoColumns();
			this.AddAutoColumns();
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x000124D0 File Offset: 0x000106D0
		public static Collection<DataGridColumn> GenerateColumns(IItemProperties itemProperties)
		{
			if (itemProperties == null)
			{
				throw new ArgumentNullException("itemProperties");
			}
			Collection<DataGridColumn> collection = new Collection<DataGridColumn>();
			DataGrid.GenerateColumns(itemProperties, null, collection);
			return collection;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x000124FC File Offset: 0x000106FC
		private static void GenerateColumns(IItemProperties iItemProperties, DataGrid dataGrid, Collection<DataGridColumn> columnCollection)
		{
			ReadOnlyCollection<ItemPropertyInfo> itemProperties = iItemProperties.ItemProperties;
			if (itemProperties != null && itemProperties.Count > 0)
			{
				foreach (ItemPropertyInfo itemPropertyInfo in itemProperties)
				{
					DataGridColumn dataGridColumn = DataGridColumn.CreateDefaultColumn(itemPropertyInfo);
					if (dataGrid != null)
					{
						DataGridAutoGeneratingColumnEventArgs dataGridAutoGeneratingColumnEventArgs = new DataGridAutoGeneratingColumnEventArgs(dataGridColumn, itemPropertyInfo);
						dataGrid.OnAutoGeneratingColumn(dataGridAutoGeneratingColumnEventArgs);
						if (!dataGridAutoGeneratingColumnEventArgs.Cancel && dataGridAutoGeneratingColumnEventArgs.Column != null)
						{
							dataGridAutoGeneratingColumnEventArgs.Column.IsAutoGenerated = true;
							dataGrid.Columns.Add(dataGridAutoGeneratingColumnEventArgs.Column);
						}
					}
					else
					{
						columnCollection.Add(dataGridColumn);
					}
				}
			}
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x000125A8 File Offset: 0x000107A8
		private static void OnAutoGenerateColumnsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			bool flag = (bool)e.NewValue;
			DataGrid dataGrid = (DataGrid)d;
			if (flag)
			{
				dataGrid.AddAutoColumns();
				return;
			}
			dataGrid.DeleteAutoColumns();
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x000125D9 File Offset: 0x000107D9
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x000125EB File Offset: 0x000107EB
		public int FrozenColumnCount
		{
			get
			{
				return (int)base.GetValue(DataGrid.FrozenColumnCountProperty);
			}
			set
			{
				base.SetValue(DataGrid.FrozenColumnCountProperty, value);
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00012600 File Offset: 0x00010800
		private static object OnCoerceFrozenColumnCount(DependencyObject d, object baseValue)
		{
			DataGrid dataGrid = (DataGrid)d;
			int num = (int)baseValue;
			if (num > dataGrid.Columns.Count)
			{
				return dataGrid.Columns.Count;
			}
			return baseValue;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0001263B File Offset: 0x0001083B
		private static void OnFrozenColumnCountPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.CellsPresenter | NotificationTarget.ColumnCollection | NotificationTarget.ColumnHeadersPresenter);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0001264C File Offset: 0x0001084C
		private static bool ValidateFrozenColumnCount(object value)
		{
			int num = (int)value;
			return num >= 0;
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x00012667 File Offset: 0x00010867
		// (set) Token: 0x0600048F RID: 1167 RVA: 0x00012679 File Offset: 0x00010879
		public double NonFrozenColumnsViewportHorizontalOffset
		{
			get
			{
				return (double)base.GetValue(DataGrid.NonFrozenColumnsViewportHorizontalOffsetProperty);
			}
			internal set
			{
				base.SetValue(DataGrid.NonFrozenColumnsViewportHorizontalOffsetPropertyKey, value);
			}
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0001268C File Offset: 0x0001088C
		public override void OnApplyTemplate()
		{
			this.CleanUpInternalScrollControls();
			base.OnApplyTemplate();
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x0001269A File Offset: 0x0001089A
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x000126AC File Offset: 0x000108AC
		public bool EnableRowVirtualization
		{
			get
			{
				return (bool)base.GetValue(DataGrid.EnableRowVirtualizationProperty);
			}
			set
			{
				base.SetValue(DataGrid.EnableRowVirtualizationProperty, value);
			}
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x000126C0 File Offset: 0x000108C0
		private static void OnEnableRowVirtualizationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGrid dataGrid = (DataGrid)d;
			dataGrid.CoerceValue(VirtualizingStackPanel.IsVirtualizingProperty);
			Panel internalItemsHost = dataGrid.InternalItemsHost;
			if (internalItemsHost != null)
			{
				internalItemsHost.InvalidateMeasure();
				internalItemsHost.InvalidateArrange();
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000126F5 File Offset: 0x000108F5
		private static object OnCoerceIsVirtualizingProperty(DependencyObject d, object baseValue)
		{
			if (!DataGridHelper.IsDefaultValue(d, DataGrid.EnableRowVirtualizationProperty))
			{
				return d.GetValue(DataGrid.EnableRowVirtualizationProperty);
			}
			return baseValue;
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x00012711 File Offset: 0x00010911
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x00012723 File Offset: 0x00010923
		public bool EnableColumnVirtualization
		{
			get
			{
				return (bool)base.GetValue(DataGrid.EnableColumnVirtualizationProperty);
			}
			set
			{
				base.SetValue(DataGrid.EnableColumnVirtualizationProperty, value);
			}
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x00012736 File Offset: 0x00010936
		private static void OnEnableColumnVirtualizationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.CellsPresenter | NotificationTarget.ColumnCollection | NotificationTarget.ColumnHeadersPresenter);
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x00012747 File Offset: 0x00010947
		// (set) Token: 0x06000499 RID: 1177 RVA: 0x00012759 File Offset: 0x00010959
		public bool CanUserReorderColumns
		{
			get
			{
				return (bool)base.GetValue(DataGrid.CanUserReorderColumnsProperty);
			}
			set
			{
				base.SetValue(DataGrid.CanUserReorderColumnsProperty, value);
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x0001276C File Offset: 0x0001096C
		// (set) Token: 0x0600049B RID: 1179 RVA: 0x0001277E File Offset: 0x0001097E
		public Style DragIndicatorStyle
		{
			get
			{
				return (Style)base.GetValue(DataGrid.DragIndicatorStyleProperty);
			}
			set
			{
				base.SetValue(DataGrid.DragIndicatorStyleProperty, value);
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x0001278C File Offset: 0x0001098C
		// (set) Token: 0x0600049D RID: 1181 RVA: 0x0001279E File Offset: 0x0001099E
		public Style DropLocationIndicatorStyle
		{
			get
			{
				return (Style)base.GetValue(DataGrid.DropLocationIndicatorStyleProperty);
			}
			set
			{
				base.SetValue(DataGrid.DropLocationIndicatorStyleProperty, value);
			}
		}

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x0600049E RID: 1182 RVA: 0x000127AC File Offset: 0x000109AC
		// (remove) Token: 0x0600049F RID: 1183 RVA: 0x000127C5 File Offset: 0x000109C5
		public event EventHandler<DataGridColumnReorderingEventArgs> ColumnReordering;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060004A0 RID: 1184 RVA: 0x000127DE File Offset: 0x000109DE
		// (remove) Token: 0x060004A1 RID: 1185 RVA: 0x000127F7 File Offset: 0x000109F7
		public event EventHandler<DragStartedEventArgs> ColumnHeaderDragStarted;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060004A2 RID: 1186 RVA: 0x00012810 File Offset: 0x00010A10
		// (remove) Token: 0x060004A3 RID: 1187 RVA: 0x00012829 File Offset: 0x00010A29
		public event EventHandler<DragDeltaEventArgs> ColumnHeaderDragDelta;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060004A4 RID: 1188 RVA: 0x00012842 File Offset: 0x00010A42
		// (remove) Token: 0x060004A5 RID: 1189 RVA: 0x0001285B File Offset: 0x00010A5B
		public event EventHandler<DragCompletedEventArgs> ColumnHeaderDragCompleted;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060004A6 RID: 1190 RVA: 0x00012874 File Offset: 0x00010A74
		// (remove) Token: 0x060004A7 RID: 1191 RVA: 0x0001288D File Offset: 0x00010A8D
		public event EventHandler<DataGridColumnEventArgs> ColumnReordered;

		// Token: 0x060004A8 RID: 1192 RVA: 0x000128A6 File Offset: 0x00010AA6
		protected internal virtual void OnColumnHeaderDragStarted(DragStartedEventArgs e)
		{
			if (this.ColumnHeaderDragStarted != null)
			{
				this.ColumnHeaderDragStarted(this, e);
			}
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x000128BD File Offset: 0x00010ABD
		protected internal virtual void OnColumnReordering(DataGridColumnReorderingEventArgs e)
		{
			if (this.ColumnReordering != null)
			{
				this.ColumnReordering(this, e);
			}
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x000128D4 File Offset: 0x00010AD4
		protected internal virtual void OnColumnHeaderDragDelta(DragDeltaEventArgs e)
		{
			if (this.ColumnHeaderDragDelta != null)
			{
				this.ColumnHeaderDragDelta(this, e);
			}
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x000128EB File Offset: 0x00010AEB
		protected internal virtual void OnColumnHeaderDragCompleted(DragCompletedEventArgs e)
		{
			if (this.ColumnHeaderDragCompleted != null)
			{
				this.ColumnHeaderDragCompleted(this, e);
			}
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00012902 File Offset: 0x00010B02
		protected internal virtual void OnColumnReordered(DataGridColumnEventArgs e)
		{
			if (this.ColumnReordered != null)
			{
				this.ColumnReordered(this, e);
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00012919 File Offset: 0x00010B19
		private static void OnClipboardCopyModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			CommandManager.InvalidateRequerySuggested();
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x00012920 File Offset: 0x00010B20
		// (set) Token: 0x060004AF RID: 1199 RVA: 0x00012932 File Offset: 0x00010B32
		public DataGridClipboardCopyMode ClipboardCopyMode
		{
			get
			{
				return (DataGridClipboardCopyMode)base.GetValue(DataGrid.ClipboardCopyModeProperty);
			}
			set
			{
				base.SetValue(DataGrid.ClipboardCopyModeProperty, value);
			}
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00012945 File Offset: 0x00010B45
		private static void OnCanExecuteCopy(object target, CanExecuteRoutedEventArgs args)
		{
			((DataGrid)target).OnCanExecuteCopy(args);
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00012953 File Offset: 0x00010B53
		protected virtual void OnCanExecuteCopy(CanExecuteRoutedEventArgs args)
		{
			args.CanExecute = (this.ClipboardCopyMode != DataGridClipboardCopyMode.None && this._selectedCells.Count > 0);
			args.Handled = true;
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x0001297B File Offset: 0x00010B7B
		private static void OnExecutedCopy(object target, ExecutedRoutedEventArgs args)
		{
			((DataGrid)target).OnExecutedCopy(args);
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x0001298C File Offset: 0x00010B8C
		protected virtual void OnExecutedCopy(ExecutedRoutedEventArgs args)
		{
			if (this.ClipboardCopyMode == DataGridClipboardCopyMode.None)
			{
				throw new NotSupportedException(SR.Get(SRID.ClipboardCopyMode_Disabled));
			}
			args.Handled = true;
			Collection<string> collection = new Collection<string>(new string[]
			{
				DataFormats.Html,
				DataFormats.Text,
				DataFormats.UnicodeText,
				DataFormats.CommaSeparatedValue
			});
			Dictionary<string, StringBuilder> dictionary = new Dictionary<string, StringBuilder>(collection.Count);
			foreach (string key in collection)
			{
				dictionary[key] = new StringBuilder();
			}
			int startColumnDisplayIndex;
			int endColumnDisplayIndex;
			int num;
			int num2;
			if (this._selectedCells.GetSelectionRange(out startColumnDisplayIndex, out endColumnDisplayIndex, out num, out num2))
			{
				if (this.ClipboardCopyMode == DataGridClipboardCopyMode.IncludeHeader)
				{
					DataGridRowClipboardEventArgs dataGridRowClipboardEventArgs = new DataGridRowClipboardEventArgs(null, startColumnDisplayIndex, endColumnDisplayIndex, true);
					this.OnCopyingRowClipboardContent(dataGridRowClipboardEventArgs);
					foreach (string text in collection)
					{
						dictionary[text].Append(dataGridRowClipboardEventArgs.FormatClipboardCellValues(text));
					}
				}
				for (int i = num; i <= num2; i++)
				{
					object item = base.Items[i];
					if (this._selectedCells.Intersects(i))
					{
						DataGridRowClipboardEventArgs dataGridRowClipboardEventArgs2 = new DataGridRowClipboardEventArgs(item, startColumnDisplayIndex, endColumnDisplayIndex, false, i);
						this.OnCopyingRowClipboardContent(dataGridRowClipboardEventArgs2);
						foreach (string text2 in collection)
						{
							dictionary[text2].Append(dataGridRowClipboardEventArgs2.FormatClipboardCellValues(text2));
						}
					}
				}
			}
			ClipboardHelper.GetClipboardContentForHtml(dictionary[DataFormats.Html]);
			try
			{
				DataObject dataObject = new DataObject();
				foreach (string text3 in collection)
				{
					dataObject.SetData(text3, dictionary[text3].ToString(), false);
				}
				Clipboard.SetDataObject(dataObject);
			}
			catch (SecurityException)
			{
				TextBox textBox = new TextBox();
				textBox.Text = dictionary[DataFormats.Text].ToString();
				textBox.SelectAll();
				textBox.Copy();
			}
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x00012C00 File Offset: 0x00010E00
		protected virtual void OnCopyingRowClipboardContent(DataGridRowClipboardEventArgs args)
		{
			if (args.IsColumnHeadersRow)
			{
				for (int i = args.StartColumnDisplayIndex; i <= args.EndColumnDisplayIndex; i++)
				{
					DataGridColumn dataGridColumn = this.ColumnFromDisplayIndex(i);
					if (dataGridColumn.IsVisible)
					{
						args.ClipboardRowContent.Add(new DataGridClipboardCellContent(args.Item, dataGridColumn, dataGridColumn.Header));
					}
				}
			}
			else
			{
				int num = args.RowIndexHint;
				if (num < 0)
				{
					num = base.Items.IndexOf(args.Item);
				}
				if (this._selectedCells.Intersects(num))
				{
					for (int j = args.StartColumnDisplayIndex; j <= args.EndColumnDisplayIndex; j++)
					{
						DataGridColumn dataGridColumn2 = this.ColumnFromDisplayIndex(j);
						if (dataGridColumn2.IsVisible)
						{
							object content = null;
							if (this._selectedCells.Contains(num, j))
							{
								content = dataGridColumn2.OnCopyingCellClipboardContent(args.Item);
							}
							args.ClipboardRowContent.Add(new DataGridClipboardCellContent(args.Item, dataGridColumn2, content));
						}
					}
				}
			}
			if (this.CopyingRowClipboardContent != null)
			{
				this.CopyingRowClipboardContent(this, args);
			}
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060004B5 RID: 1205 RVA: 0x00012D00 File Offset: 0x00010F00
		// (remove) Token: 0x060004B6 RID: 1206 RVA: 0x00012D19 File Offset: 0x00010F19
		public event EventHandler<DataGridRowClipboardEventArgs> CopyingRowClipboardContent;

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x00012D32 File Offset: 0x00010F32
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x00012D44 File Offset: 0x00010F44
		internal double CellsPanelActualWidth
		{
			get
			{
				return (double)base.GetValue(DataGrid.CellsPanelActualWidthProperty);
			}
			set
			{
				base.SetValue(DataGrid.CellsPanelActualWidthProperty, value);
			}
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00012D58 File Offset: 0x00010F58
		private static void CellsPanelActualWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			double value = (double)e.OldValue;
			double value2 = (double)e.NewValue;
			if (!DoubleUtil.AreClose(value, value2))
			{
				((DataGrid)d).NotifyPropertyChanged(d, e, NotificationTarget.ColumnHeadersPresenter);
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x00012D97 File Offset: 0x00010F97
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x00012DA9 File Offset: 0x00010FA9
		public double CellsPanelHorizontalOffset
		{
			get
			{
				return (double)base.GetValue(DataGrid.CellsPanelHorizontalOffsetProperty);
			}
			private set
			{
				base.SetValue(DataGrid.CellsPanelHorizontalOffsetPropertyKey, value);
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x00012DBC File Offset: 0x00010FBC
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x00012DC4 File Offset: 0x00010FC4
		private bool CellsPanelHorizontalOffsetComputationPending { get; set; }

		// Token: 0x060004BE RID: 1214 RVA: 0x00012DD0 File Offset: 0x00010FD0
		internal void QueueInvalidateCellsPanelHorizontalOffset()
		{
			if (!this.CellsPanelHorizontalOffsetComputationPending)
			{
				base.Dispatcher.BeginInvoke(new DispatcherOperationCallback(this.InvalidateCellsPanelHorizontalOffset), DispatcherPriority.Loaded, new object[]
				{
					this
				});
				this.CellsPanelHorizontalOffsetComputationPending = true;
			}
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00012E14 File Offset: 0x00011014
		private object InvalidateCellsPanelHorizontalOffset(object args)
		{
			if (!this.CellsPanelHorizontalOffsetComputationPending)
			{
				return null;
			}
			IProvideDataGridColumn anyCellOrColumnHeader = this.GetAnyCellOrColumnHeader();
			if (anyCellOrColumnHeader != null)
			{
				this.CellsPanelHorizontalOffset = DataGridHelper.GetParentCellsPanelHorizontalOffset(anyCellOrColumnHeader);
			}
			else if (!double.IsNaN(this.RowHeaderWidth))
			{
				this.CellsPanelHorizontalOffset = this.RowHeaderWidth;
			}
			else
			{
				this.CellsPanelHorizontalOffset = 0.0;
			}
			this.CellsPanelHorizontalOffsetComputationPending = false;
			return null;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00012E78 File Offset: 0x00011078
		internal IProvideDataGridColumn GetAnyCellOrColumnHeader()
		{
			if (this._rowTrackingRoot != null)
			{
				for (ContainerTracking<DataGridRow> containerTracking = this._rowTrackingRoot; containerTracking != null; containerTracking = containerTracking.Next)
				{
					if (containerTracking.Container.IsVisible)
					{
						Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = containerTracking.Container.CellsPresenter;
						if (cellsPresenter != null)
						{
							for (ContainerTracking<DataGridCell> containerTracking2 = cellsPresenter.CellTrackingRoot; containerTracking2 != null; containerTracking2 = containerTracking2.Next)
							{
								if (containerTracking2.Container.IsVisible)
								{
									return containerTracking2.Container;
								}
							}
						}
					}
				}
			}
			if (this.ColumnHeadersPresenter != null)
			{
				for (ContainerTracking<Microsoft.Windows.Controls.Primitives.DataGridColumnHeader> containerTracking3 = this.ColumnHeadersPresenter.HeaderTrackingRoot; containerTracking3 != null; containerTracking3 = containerTracking3.Next)
				{
					if (containerTracking3.Container.IsVisible)
					{
						return containerTracking3.Container;
					}
				}
			}
			return null;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00012F18 File Offset: 0x00011118
		internal double GetViewportWidthForColumns()
		{
			if (this.InternalScrollHost == null)
			{
				return 0.0;
			}
			double viewportWidth = this.InternalScrollHost.ViewportWidth;
			return viewportWidth - this.CellsPanelHorizontalOffset;
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x00012F4D File Offset: 0x0001114D
		internal static object NewItemPlaceholder
		{
			get
			{
				return DataGrid._newItemPlaceholder;
			}
		}

		// Token: 0x040000D5 RID: 213
		private const string ItemsPanelPartName = "PART_RowsPresenter";

		// Token: 0x040000D6 RID: 214
		public static readonly DependencyProperty CanUserResizeColumnsProperty = DependencyProperty.Register("CanUserResizeColumns", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(DataGrid.OnNotifyColumnAndColumnHeaderPropertyChanged)));

		// Token: 0x040000D7 RID: 215
		public static readonly DependencyProperty ColumnWidthProperty = DependencyProperty.Register("ColumnWidth", typeof(DataGridLength), typeof(DataGrid), new FrameworkPropertyMetadata(DataGridLength.SizeToHeader));

		// Token: 0x040000D8 RID: 216
		public static readonly DependencyProperty MinColumnWidthProperty = DependencyProperty.Register("MinColumnWidth", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(20.0, new PropertyChangedCallback(DataGrid.OnColumnSizeConstraintChanged)), new ValidateValueCallback(DataGrid.ValidateMinColumnWidth));

		// Token: 0x040000D9 RID: 217
		public static readonly DependencyProperty MaxColumnWidthProperty = DependencyProperty.Register("MaxColumnWidth", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(double.PositiveInfinity, new PropertyChangedCallback(DataGrid.OnColumnSizeConstraintChanged)), new ValidateValueCallback(DataGrid.ValidateMaxColumnWidth));

		// Token: 0x040000DB RID: 219
		public static readonly DependencyProperty GridLinesVisibilityProperty = DependencyProperty.Register("GridLinesVisibility", typeof(DataGridGridLinesVisibility), typeof(DataGrid), new FrameworkPropertyMetadata(DataGridGridLinesVisibility.All, new PropertyChangedCallback(DataGrid.OnNotifyGridLinePropertyChanged)));

		// Token: 0x040000DC RID: 220
		public static readonly DependencyProperty HorizontalGridLinesBrushProperty = DependencyProperty.Register("HorizontalGridLinesBrush", typeof(Brush), typeof(DataGrid), new FrameworkPropertyMetadata(Brushes.Black, new PropertyChangedCallback(DataGrid.OnNotifyGridLinePropertyChanged)));

		// Token: 0x040000DD RID: 221
		public static readonly DependencyProperty VerticalGridLinesBrushProperty = DependencyProperty.Register("VerticalGridLinesBrush", typeof(Brush), typeof(DataGrid), new FrameworkPropertyMetadata(Brushes.Black, new PropertyChangedCallback(DataGrid.OnNotifyGridLinePropertyChanged)));

		// Token: 0x040000DE RID: 222
		public static readonly DependencyProperty RowStyleProperty = DependencyProperty.Register("RowStyle", typeof(Style), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnRowStyleChanged)));

		// Token: 0x040000DF RID: 223
		public static readonly DependencyProperty RowValidationErrorTemplateProperty = DependencyProperty.Register("RowValidationErrorTemplate", typeof(ControlTemplate), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyRowPropertyChanged)));

		// Token: 0x040000E0 RID: 224
		public static readonly DependencyProperty RowStyleSelectorProperty = DependencyProperty.Register("RowStyleSelector", typeof(StyleSelector), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnRowStyleSelectorChanged)));

		// Token: 0x040000E1 RID: 225
		public static readonly DependencyProperty RowBackgroundProperty = DependencyProperty.Register("RowBackground", typeof(Brush), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyRowPropertyChanged)));

		// Token: 0x040000E2 RID: 226
		public static readonly DependencyProperty AlternatingRowBackgroundProperty = DependencyProperty.Register("AlternatingRowBackground", typeof(Brush), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyDataGridAndRowPropertyChanged)));

		// Token: 0x040000E3 RID: 227
		public static readonly DependencyProperty RowHeightProperty = DependencyProperty.Register("RowHeight", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(double.NaN, new PropertyChangedCallback(DataGrid.OnNotifyCellsPresenterPropertyChanged)));

		// Token: 0x040000E4 RID: 228
		public static readonly DependencyProperty MinRowHeightProperty = DependencyProperty.Register("MinRowHeight", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(DataGrid.OnNotifyCellsPresenterPropertyChanged)));

		// Token: 0x040000E7 RID: 231
		public static readonly DependencyProperty RowHeaderWidthProperty = DependencyProperty.Register("RowHeaderWidth", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(double.NaN, new PropertyChangedCallback(DataGrid.OnNotifyRowHeaderWidthPropertyChanged)));

		// Token: 0x040000E8 RID: 232
		private static readonly DependencyPropertyKey RowHeaderActualWidthPropertyKey = DependencyProperty.RegisterReadOnly("RowHeaderActualWidth", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(DataGrid.OnNotifyRowHeaderPropertyChanged)));

		// Token: 0x040000E9 RID: 233
		public static readonly DependencyProperty RowHeaderActualWidthProperty = DataGrid.RowHeaderActualWidthPropertyKey.DependencyProperty;

		// Token: 0x040000EA RID: 234
		public static readonly DependencyProperty ColumnHeaderHeightProperty = DependencyProperty.Register("ColumnHeaderHeight", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(double.NaN, new PropertyChangedCallback(DataGrid.OnNotifyColumnHeaderPropertyChanged)));

		// Token: 0x040000EB RID: 235
		public static readonly DependencyProperty HeadersVisibilityProperty = DependencyProperty.Register("HeadersVisibility", typeof(DataGridHeadersVisibility), typeof(DataGrid), new FrameworkPropertyMetadata(DataGridHeadersVisibility.All));

		// Token: 0x040000EC RID: 236
		public static readonly DependencyProperty CellStyleProperty = DependencyProperty.Register("CellStyle", typeof(Style), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyColumnAndCellPropertyChanged)));

		// Token: 0x040000ED RID: 237
		public static readonly DependencyProperty ColumnHeaderStyleProperty = DependencyProperty.Register("ColumnHeaderStyle", typeof(Style), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyColumnAndColumnHeaderPropertyChanged)));

		// Token: 0x040000EE RID: 238
		public static readonly DependencyProperty RowHeaderStyleProperty = DependencyProperty.Register("RowHeaderStyle", typeof(Style), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyRowAndRowHeaderPropertyChanged)));

		// Token: 0x040000EF RID: 239
		public static readonly DependencyProperty RowHeaderTemplateProperty = DependencyProperty.Register("RowHeaderTemplate", typeof(DataTemplate), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyRowAndRowHeaderPropertyChanged)));

		// Token: 0x040000F0 RID: 240
		public static readonly DependencyProperty RowHeaderTemplateSelectorProperty = DependencyProperty.Register("RowHeaderTemplateSelector", typeof(DataTemplateSelector), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyRowAndRowHeaderPropertyChanged)));

		// Token: 0x040000F1 RID: 241
		public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty = ScrollViewer.HorizontalScrollBarVisibilityProperty.AddOwner(typeof(DataGrid), new FrameworkPropertyMetadata(ScrollBarVisibility.Auto));

		// Token: 0x040000F2 RID: 242
		public static readonly DependencyProperty VerticalScrollBarVisibilityProperty = ScrollViewer.VerticalScrollBarVisibilityProperty.AddOwner(typeof(DataGrid), new FrameworkPropertyMetadata(ScrollBarVisibility.Auto));

		// Token: 0x040000F3 RID: 243
		internal static readonly DependencyProperty HorizontalScrollOffsetProperty = DependencyProperty.Register("HorizontalScrollOffset", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(DataGrid.OnNotifyHorizontalOffsetPropertyChanged)));

		// Token: 0x040000F4 RID: 244
		public static readonly RoutedCommand BeginEditCommand = new RoutedCommand("BeginEdit", typeof(DataGrid));

		// Token: 0x040000F5 RID: 245
		public static readonly RoutedCommand CommitEditCommand = new RoutedCommand("CommitEdit", typeof(DataGrid));

		// Token: 0x040000F6 RID: 246
		public static readonly RoutedCommand CancelEditCommand = new RoutedCommand("CancelEdit", typeof(DataGrid));

		// Token: 0x040000F9 RID: 249
		public static readonly DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DataGrid.OnIsReadOnlyChanged)));

		// Token: 0x040000FA RID: 250
		public static readonly DependencyProperty CurrentItemProperty = DependencyProperty.Register("CurrentItem", typeof(object), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnCurrentItemChanged)));

		// Token: 0x040000FB RID: 251
		public static readonly DependencyProperty CurrentColumnProperty = DependencyProperty.Register("CurrentColumn", typeof(DataGridColumn), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnCurrentColumnChanged)));

		// Token: 0x040000FC RID: 252
		public static readonly DependencyProperty CurrentCellProperty = DependencyProperty.Register("CurrentCell", typeof(DataGridCellInfo), typeof(DataGrid), new FrameworkPropertyMetadata(DataGridCellInfo.Unset, new PropertyChangedCallback(DataGrid.OnCurrentCellChanged)));

		// Token: 0x04000100 RID: 256
		public static readonly DependencyProperty CanUserAddRowsProperty = DependencyProperty.Register("CanUserAddRows", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(DataGrid.OnCanUserAddRowsChanged), new CoerceValueCallback(DataGrid.OnCoerceCanUserAddRows)));

		// Token: 0x04000101 RID: 257
		public static readonly DependencyProperty CanUserDeleteRowsProperty = DependencyProperty.Register("CanUserDeleteRows", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(DataGrid.OnCanUserDeleteRowsChanged), new CoerceValueCallback(DataGrid.OnCoerceCanUserDeleteRows)));

		// Token: 0x04000103 RID: 259
		public static readonly DependencyProperty RowDetailsVisibilityModeProperty = DependencyProperty.Register("RowDetailsVisibilityMode", typeof(DataGridRowDetailsVisibilityMode), typeof(DataGrid), new FrameworkPropertyMetadata(DataGridRowDetailsVisibilityMode.VisibleWhenSelected, new PropertyChangedCallback(DataGrid.OnNotifyRowAndDetailsPropertyChanged)));

		// Token: 0x04000104 RID: 260
		public static readonly DependencyProperty AreRowDetailsFrozenProperty = DependencyProperty.Register("AreRowDetailsFrozen", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(false));

		// Token: 0x04000105 RID: 261
		public static readonly DependencyProperty RowDetailsTemplateProperty = DependencyProperty.Register("RowDetailsTemplate", typeof(DataTemplate), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyRowAndDetailsPropertyChanged)));

		// Token: 0x04000106 RID: 262
		public static readonly DependencyProperty RowDetailsTemplateSelectorProperty = DependencyProperty.Register("RowDetailsTemplateSelector", typeof(DataTemplateSelector), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyRowAndDetailsPropertyChanged)));

		// Token: 0x0400010A RID: 266
		public static readonly DependencyProperty CanUserResizeRowsProperty = DependencyProperty.Register("CanUserResizeRows", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(DataGrid.OnNotifyRowHeaderPropertyChanged)));

		// Token: 0x0400010C RID: 268
		public static readonly DependencyProperty SelectionModeProperty = DependencyProperty.Register("SelectionMode", typeof(DataGridSelectionMode), typeof(DataGrid), new FrameworkPropertyMetadata(DataGridSelectionMode.Extended, new PropertyChangedCallback(DataGrid.OnSelectionModeChanged)));

		// Token: 0x0400010D RID: 269
		public static readonly DependencyProperty SelectionUnitProperty = DependencyProperty.Register("SelectionUnit", typeof(DataGridSelectionUnit), typeof(DataGrid), new FrameworkPropertyMetadata(DataGridSelectionUnit.FullRow, new PropertyChangedCallback(DataGrid.OnSelectionUnitChanged)));

		// Token: 0x0400010E RID: 270
		public static readonly DependencyProperty CanUserSortColumnsProperty = DependencyProperty.Register("CanUserSortColumns", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(DataGrid.OnCanUserSortColumnsPropertyChanged), new CoerceValueCallback(DataGrid.OnCoerceCanUserSortColumns)));

		// Token: 0x04000112 RID: 274
		public static readonly DependencyProperty AutoGenerateColumnsProperty = DependencyProperty.Register("AutoGenerateColumns", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(DataGrid.OnAutoGenerateColumnsPropertyChanged)));

		// Token: 0x04000113 RID: 275
		public static readonly DependencyProperty FrozenColumnCountProperty = DependencyProperty.Register("FrozenColumnCount", typeof(int), typeof(DataGrid), new FrameworkPropertyMetadata(0, new PropertyChangedCallback(DataGrid.OnFrozenColumnCountPropertyChanged), new CoerceValueCallback(DataGrid.OnCoerceFrozenColumnCount)), new ValidateValueCallback(DataGrid.ValidateFrozenColumnCount));

		// Token: 0x04000114 RID: 276
		private static readonly DependencyPropertyKey NonFrozenColumnsViewportHorizontalOffsetPropertyKey = DependencyProperty.RegisterReadOnly("NonFrozenColumnsViewportHorizontalOffset", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(0.0));

		// Token: 0x04000115 RID: 277
		public static readonly DependencyProperty NonFrozenColumnsViewportHorizontalOffsetProperty = DataGrid.NonFrozenColumnsViewportHorizontalOffsetPropertyKey.DependencyProperty;

		// Token: 0x04000116 RID: 278
		public static readonly DependencyProperty EnableRowVirtualizationProperty = DependencyProperty.Register("EnableRowVirtualization", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(DataGrid.OnEnableRowVirtualizationChanged)));

		// Token: 0x04000117 RID: 279
		public static readonly DependencyProperty EnableColumnVirtualizationProperty = DependencyProperty.Register("EnableColumnVirtualization", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DataGrid.OnEnableColumnVirtualizationChanged)));

		// Token: 0x04000118 RID: 280
		public static readonly DependencyProperty CanUserReorderColumnsProperty = DependencyProperty.Register("CanUserReorderColumns", typeof(bool), typeof(DataGrid), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(DataGrid.OnNotifyColumnPropertyChanged)));

		// Token: 0x04000119 RID: 281
		public static readonly DependencyProperty DragIndicatorStyleProperty = DependencyProperty.Register("DragIndicatorStyle", typeof(Style), typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGrid.OnNotifyColumnPropertyChanged)));

		// Token: 0x0400011A RID: 282
		public static readonly DependencyProperty DropLocationIndicatorStyleProperty = DependencyProperty.Register("DropLocationIndicatorStyle", typeof(Style), typeof(DataGrid), new FrameworkPropertyMetadata(null));

		// Token: 0x04000120 RID: 288
		public static readonly DependencyProperty ClipboardCopyModeProperty = DependencyProperty.Register("ClipboardCopyMode", typeof(DataGridClipboardCopyMode), typeof(DataGrid), new FrameworkPropertyMetadata(DataGridClipboardCopyMode.ExcludeHeader, new PropertyChangedCallback(DataGrid.OnClipboardCopyModeChanged)));

		// Token: 0x04000122 RID: 290
		internal static readonly DependencyProperty CellsPanelActualWidthProperty = DependencyProperty.Register("CellsPanelActualWidth", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(DataGrid.CellsPanelActualWidthChanged)));

		// Token: 0x04000123 RID: 291
		private static readonly DependencyPropertyKey CellsPanelHorizontalOffsetPropertyKey = DependencyProperty.RegisterReadOnly("CellsPanelHorizontalOffset", typeof(double), typeof(DataGrid), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(DataGrid.OnNotifyHorizontalOffsetPropertyChanged)));

		// Token: 0x04000124 RID: 292
		public static readonly DependencyProperty CellsPanelHorizontalOffsetProperty = DataGrid.CellsPanelHorizontalOffsetPropertyKey.DependencyProperty;

		// Token: 0x04000125 RID: 293
		private static ComponentResourceKey _focusBorderBrushKey;

		// Token: 0x04000126 RID: 294
		private static IValueConverter _headersVisibilityConverter;

		// Token: 0x04000127 RID: 295
		private static IValueConverter _rowDetailsScrollingConverter;

		// Token: 0x04000128 RID: 296
		private static object _newItemPlaceholder = new object();

		// Token: 0x04000129 RID: 297
		private DataGridColumnCollection _columns;

		// Token: 0x0400012A RID: 298
		private ContainerTracking<DataGridRow> _rowTrackingRoot;

		// Token: 0x0400012B RID: 299
		private Microsoft.Windows.Controls.Primitives.DataGridColumnHeadersPresenter _columnHeadersPresenter;

		// Token: 0x0400012C RID: 300
		private DataGridCell _currentCellContainer;

		// Token: 0x0400012D RID: 301
		private DataGridCell _pendingCurrentCellContainer;

		// Token: 0x0400012E RID: 302
		private SelectedCellsCollection _selectedCells;

		// Token: 0x0400012F RID: 303
		private DataGridCellInfo? _selectionAnchor;

		// Token: 0x04000130 RID: 304
		private bool _isDraggingSelection;

		// Token: 0x04000131 RID: 305
		private bool _isRowDragging;

		// Token: 0x04000132 RID: 306
		private Panel _internalItemsHost;

		// Token: 0x04000133 RID: 307
		private ScrollViewer _internalScrollHost;

		// Token: 0x04000134 RID: 308
		private ScrollContentPresenter _internalScrollContentPresenter;

		// Token: 0x04000135 RID: 309
		private DispatcherTimer _autoScrollTimer;

		// Token: 0x04000136 RID: 310
		private bool _hasAutoScrolled;

		// Token: 0x04000137 RID: 311
		private VirtualizedCellInfoCollection _pendingSelectedCells;

		// Token: 0x04000138 RID: 312
		private VirtualizedCellInfoCollection _pendingUnselectedCells;

		// Token: 0x04000139 RID: 313
		private bool _measureNeverInvoked = true;

		// Token: 0x0400013A RID: 314
		private bool _updatingSelectedCells;

		// Token: 0x0400013B RID: 315
		private Visibility _placeholderVisibility = Visibility.Collapsed;

		// Token: 0x0400013C RID: 316
		private Point _dragPoint;

		// Token: 0x0400013D RID: 317
		private List<int> _groupingSortDescriptionIndices;

		// Token: 0x0400013E RID: 318
		private bool _ignoreSortDescriptionsChange;

		// Token: 0x0400013F RID: 319
		private bool _sortingStarted;

		// Token: 0x04000140 RID: 320
		private ObservableCollection<ValidationRule> _rowValidationRules;

		// Token: 0x04000141 RID: 321
		private BindingGroup _rowValidationBindingGroup;

		// Token: 0x04000142 RID: 322
		private object _editingRowItem;

		// Token: 0x04000143 RID: 323
		private int _editingRowIndex = -1;

		// Token: 0x04000144 RID: 324
		private bool _hasCellValidationError;

		// Token: 0x04000145 RID: 325
		private bool _hasRowValidationError;

		// Token: 0x04000146 RID: 326
		private IEnumerable _cachedItemsSource;

		// Token: 0x04000147 RID: 327
		private DataGridItemAttachedStorage _itemAttachedStorage = new DataGridItemAttachedStorage();

		// Token: 0x04000148 RID: 328
		private bool _viewportWidthChangeNotificationPending;

		// Token: 0x04000149 RID: 329
		private double _originalViewportWidth;

		// Token: 0x0400014A RID: 330
		private double _finalViewportWidth;

		// Token: 0x0400014B RID: 331
		private DataGridCell _focusedCell;

		// Token: 0x02000039 RID: 57
		private class ChangingSelectedCellsHelper : IDisposable
		{
			// Token: 0x060004C3 RID: 1219 RVA: 0x00012F54 File Offset: 0x00011154
			internal ChangingSelectedCellsHelper(DataGrid dataGrid)
			{
				this._dataGrid = dataGrid;
				this._wasUpdatingSelectedCells = this._dataGrid.IsUpdatingSelectedCells;
				if (!this._wasUpdatingSelectedCells)
				{
					this._dataGrid.BeginUpdateSelectedCells();
				}
			}

			// Token: 0x060004C4 RID: 1220 RVA: 0x00012F87 File Offset: 0x00011187
			public void Dispose()
			{
				GC.SuppressFinalize(this);
				if (!this._wasUpdatingSelectedCells)
				{
					this._dataGrid.EndUpdateSelectedCells();
				}
			}

			// Token: 0x0400014E RID: 334
			private DataGrid _dataGrid;

			// Token: 0x0400014F RID: 335
			private bool _wasUpdatingSelectedCells;
		}

		// Token: 0x0200003A RID: 58
		[Flags]
		private enum RelativeMousePositions
		{
			// Token: 0x04000151 RID: 337
			Over = 0,
			// Token: 0x04000152 RID: 338
			Above = 1,
			// Token: 0x04000153 RID: 339
			Below = 2,
			// Token: 0x04000154 RID: 340
			Left = 4,
			// Token: 0x04000155 RID: 341
			Right = 8
		}
	}
}

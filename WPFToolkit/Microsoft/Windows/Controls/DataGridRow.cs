using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Threading;
using Microsoft.Windows.Automation.Peers;
using Microsoft.Windows.Controls.Primitives;
using MS.Internal;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000084 RID: 132
	public class DataGridRow : Control
	{
		// Token: 0x0600092F RID: 2351 RVA: 0x00028F98 File Offset: 0x00027198
		static DataGridRow()
		{
			DataGridRow.SelectedEvent = Selector.SelectedEvent.AddOwner(typeof(DataGridRow));
			DataGridRow.UnselectedEvent = Selector.UnselectedEvent.AddOwner(typeof(DataGridRow));
			DataGridRow.IsEditingPropertyKey = DependencyProperty.RegisterReadOnly("IsEditing", typeof(bool), typeof(DataGridRow), new FrameworkPropertyMetadata(false));
			DataGridRow.IsEditingProperty = DataGridRow.IsEditingPropertyKey.DependencyProperty;
			UIElement.VisibilityProperty.OverrideMetadata(typeof(DataGridRow), new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGridRow.OnCoerceVisibility)));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridRow), new FrameworkPropertyMetadata(typeof(DataGridRow)));
			DataGridRow.ItemsPanelProperty.OverrideMetadata(typeof(DataGridRow), new FrameworkPropertyMetadata(new ItemsPanelTemplate(new FrameworkElementFactory(typeof(DataGridCellsPanel)))));
			UIElement.FocusableProperty.OverrideMetadata(typeof(DataGridRow), new FrameworkPropertyMetadata(false));
			Control.BackgroundProperty.OverrideMetadata(typeof(DataGridRow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridRow.OnNotifyRowPropertyChanged), new CoerceValueCallback(DataGridRow.OnCoerceBackground)));
			FrameworkElement.BindingGroupProperty.OverrideMetadata(typeof(DataGridRow), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridRow.OnNotifyRowPropertyChanged)));
			UIElement.SnapsToDevicePixelsProperty.OverrideMetadata(typeof(DataGridRow), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsArrange));
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x000293BD File Offset: 0x000275BD
		public DataGridRow()
		{
			this._tracker = new ContainerTracking<DataGridRow>(this);
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000931 RID: 2353 RVA: 0x000293D1 File Offset: 0x000275D1
		// (set) Token: 0x06000932 RID: 2354 RVA: 0x000293DE File Offset: 0x000275DE
		public object Item
		{
			get
			{
				return base.GetValue(DataGridRow.ItemProperty);
			}
			set
			{
				base.SetValue(DataGridRow.ItemProperty, value);
			}
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x000293EC File Offset: 0x000275EC
		protected virtual void OnItemChanged(object oldItem, object newItem)
		{
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null)
			{
				cellsPresenter.Item = newItem;
			}
			Microsoft.Windows.Automation.Peers.DataGridRowAutomationPeer dataGridRowAutomationPeer = UIElementAutomationPeer.FromElement(this) as Microsoft.Windows.Automation.Peers.DataGridRowAutomationPeer;
			if (dataGridRowAutomationPeer != null)
			{
				dataGridRowAutomationPeer.UpdateEventSource();
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x0002941F File Offset: 0x0002761F
		// (set) Token: 0x06000935 RID: 2357 RVA: 0x00029431 File Offset: 0x00027631
		public ItemsPanelTemplate ItemsPanel
		{
			get
			{
				return (ItemsPanelTemplate)base.GetValue(DataGridRow.ItemsPanelProperty);
			}
			set
			{
				base.SetValue(DataGridRow.ItemsPanelProperty, value);
			}
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x0002943F File Offset: 0x0002763F
		protected override void OnTemplateChanged(ControlTemplate oldTemplate, ControlTemplate newTemplate)
		{
			base.OnTemplateChanged(oldTemplate, newTemplate);
			this.CellsPresenter = null;
			this.DetailsPresenter = null;
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x00029457 File Offset: 0x00027657
		// (set) Token: 0x06000938 RID: 2360 RVA: 0x00029464 File Offset: 0x00027664
		public object Header
		{
			get
			{
				return base.GetValue(DataGridRow.HeaderProperty);
			}
			set
			{
				base.SetValue(DataGridRow.HeaderProperty, value);
			}
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x00029472 File Offset: 0x00027672
		protected virtual void OnHeaderChanged(object oldHeader, object newHeader)
		{
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x00029474 File Offset: 0x00027674
		// (set) Token: 0x0600093B RID: 2363 RVA: 0x00029486 File Offset: 0x00027686
		public Style HeaderStyle
		{
			get
			{
				return (Style)base.GetValue(DataGridRow.HeaderStyleProperty);
			}
			set
			{
				base.SetValue(DataGridRow.HeaderStyleProperty, value);
			}
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x00029494 File Offset: 0x00027694
		// (set) Token: 0x0600093D RID: 2365 RVA: 0x000294A6 File Offset: 0x000276A6
		public DataTemplate HeaderTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(DataGridRow.HeaderTemplateProperty);
			}
			set
			{
				base.SetValue(DataGridRow.HeaderTemplateProperty, value);
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x000294B4 File Offset: 0x000276B4
		// (set) Token: 0x0600093F RID: 2367 RVA: 0x000294C6 File Offset: 0x000276C6
		public DataTemplateSelector HeaderTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(DataGridRow.HeaderTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(DataGridRow.HeaderTemplateSelectorProperty, value);
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x000294D4 File Offset: 0x000276D4
		// (set) Token: 0x06000941 RID: 2369 RVA: 0x000294E6 File Offset: 0x000276E6
		public ControlTemplate ValidationErrorTemplate
		{
			get
			{
				return (ControlTemplate)base.GetValue(DataGridRow.ValidationErrorTemplateProperty);
			}
			set
			{
				base.SetValue(DataGridRow.ValidationErrorTemplateProperty, value);
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x000294F4 File Offset: 0x000276F4
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x00029506 File Offset: 0x00027706
		public DataTemplate DetailsTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(DataGridRow.DetailsTemplateProperty);
			}
			set
			{
				base.SetValue(DataGridRow.DetailsTemplateProperty, value);
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x00029514 File Offset: 0x00027714
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x00029526 File Offset: 0x00027726
		public DataTemplateSelector DetailsTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(DataGridRow.DetailsTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(DataGridRow.DetailsTemplateSelectorProperty, value);
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000946 RID: 2374 RVA: 0x00029534 File Offset: 0x00027734
		// (set) Token: 0x06000947 RID: 2375 RVA: 0x00029546 File Offset: 0x00027746
		public Visibility DetailsVisibility
		{
			get
			{
				return (Visibility)base.GetValue(DataGridRow.DetailsVisibilityProperty);
			}
			set
			{
				base.SetValue(DataGridRow.DetailsVisibilityProperty, value);
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000948 RID: 2376 RVA: 0x00029559 File Offset: 0x00027759
		// (set) Token: 0x06000949 RID: 2377 RVA: 0x00029561 File Offset: 0x00027761
		internal bool DetailsLoaded
		{
			get
			{
				return this._detailsLoaded;
			}
			set
			{
				this._detailsLoaded = value;
			}
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x0002956A File Offset: 0x0002776A
		protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(e);
			if (e.Property == DataGridRow.AlternationIndexProperty)
			{
				this.NotifyPropertyChanged(this, e, NotificationTarget.Rows);
			}
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00029590 File Offset: 0x00027790
		internal void PrepareRow(object item, DataGrid owningDataGrid)
		{
			bool flag = this._owner != owningDataGrid;
			bool forcePrepareCells = false;
			this._owner = owningDataGrid;
			if (this != item)
			{
				if (this.Item != item)
				{
					this.Item = item;
				}
				else
				{
					forcePrepareCells = true;
				}
			}
			if (this.IsEditing)
			{
				this.IsEditing = false;
			}
			if (flag)
			{
				this.SyncProperties(forcePrepareCells);
			}
			base.Dispatcher.BeginInvoke(new DispatcherOperationCallback(this.DelayedValidateWithoutUpdate), DispatcherPriority.DataBind, new object[]
			{
				base.BindingGroup
			});
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00029610 File Offset: 0x00027810
		internal void ClearRow(DataGrid owningDataGrid)
		{
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null)
			{
				this.PersistAttachedItemValue(cellsPresenter, FrameworkElement.HeightProperty);
			}
			this.PersistAttachedItemValue(this, DataGridRow.DetailsVisibilityProperty);
			this._owner = null;
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00029648 File Offset: 0x00027848
		private void PersistAttachedItemValue(DependencyObject objectWithProperty, DependencyProperty property)
		{
			if (DependencyPropertyHelper.GetValueSource(objectWithProperty, property).BaseValueSource == BaseValueSource.Local)
			{
				this._owner.ItemAttachedStorage.SetValue(this.Item, property, objectWithProperty.GetValue(property));
				objectWithProperty.ClearValue(property);
			}
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00029690 File Offset: 0x00027890
		private void RestoreAttachedItemValue(DependencyObject objectWithProperty, DependencyProperty property)
		{
			object value;
			if (this._owner.ItemAttachedStorage.TryGetValue(this.Item, property, out value))
			{
				objectWithProperty.SetValue(property, value);
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x0600094F RID: 2383 RVA: 0x000296C0 File Offset: 0x000278C0
		internal ContainerTracking<DataGridRow> Tracker
		{
			get
			{
				return this._tracker;
			}
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x000296C8 File Offset: 0x000278C8
		internal void OnRowResizeStarted()
		{
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null)
			{
				this._cellsPresenterResizeHeight = cellsPresenter.Height;
			}
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x000296EC File Offset: 0x000278EC
		internal void OnRowResize(double changeAmount)
		{
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null)
			{
				double num = cellsPresenter.ActualHeight + changeAmount;
				double num2 = Math.Max(this.RowHeader.DesiredSize.Height, base.MinHeight);
				if (DoubleUtil.LessThan(num, num2))
				{
					num = num2;
				}
				double maxHeight = base.MaxHeight;
				if (DoubleUtil.GreaterThan(num, maxHeight))
				{
					num = maxHeight;
				}
				cellsPresenter.Height = num;
			}
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00029750 File Offset: 0x00027950
		internal void OnRowResizeCompleted(bool canceled)
		{
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null && canceled)
			{
				cellsPresenter.Height = this._cellsPresenterResizeHeight;
			}
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00029778 File Offset: 0x00027978
		internal void OnRowResizeReset()
		{
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null)
			{
				cellsPresenter.ClearValue(FrameworkElement.HeightProperty);
				if (this._owner != null)
				{
					this._owner.ItemAttachedStorage.ClearValue(this.Item, FrameworkElement.HeightProperty);
				}
			}
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x000297C0 File Offset: 0x000279C0
		protected internal virtual void OnColumnsChanged(ObservableCollection<DataGridColumn> columns, NotifyCollectionChangedEventArgs e)
		{
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null)
			{
				cellsPresenter.OnColumnsChanged(columns, e);
			}
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x000297E0 File Offset: 0x000279E0
		private static object OnCoerceHeaderStyle(DependencyObject d, object baseValue)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRow, baseValue, DataGridRow.HeaderStyleProperty, dataGridRow.DataGridOwner, DataGrid.RowHeaderStyleProperty);
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x0002980C File Offset: 0x00027A0C
		private static object OnCoerceHeaderTemplate(DependencyObject d, object baseValue)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRow, baseValue, DataGridRow.HeaderTemplateProperty, dataGridRow.DataGridOwner, DataGrid.RowHeaderTemplateProperty);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00029838 File Offset: 0x00027A38
		private static object OnCoerceHeaderTemplateSelector(DependencyObject d, object baseValue)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRow, baseValue, DataGridRow.HeaderTemplateSelectorProperty, dataGridRow.DataGridOwner, DataGrid.RowHeaderTemplateSelectorProperty);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00029864 File Offset: 0x00027A64
		private static object OnCoerceBackground(DependencyObject d, object baseValue)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			object result = baseValue;
			switch (dataGridRow.AlternationIndex)
			{
			case 0:
				result = DataGridHelper.GetCoercedTransferPropertyValue(dataGridRow, baseValue, Control.BackgroundProperty, dataGridRow.DataGridOwner, DataGrid.RowBackgroundProperty);
				break;
			case 1:
				result = DataGridHelper.GetCoercedTransferPropertyValue(dataGridRow, baseValue, Control.BackgroundProperty, dataGridRow.DataGridOwner, DataGrid.AlternatingRowBackgroundProperty);
				break;
			}
			return result;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x000298C4 File Offset: 0x00027AC4
		private static object OnCoerceValidationErrorTemplate(DependencyObject d, object baseValue)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRow, baseValue, DataGridRow.ValidationErrorTemplateProperty, dataGridRow.DataGridOwner, DataGrid.RowValidationErrorTemplateProperty);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x000298F0 File Offset: 0x00027AF0
		private static object OnCoerceDetailsTemplate(DependencyObject d, object baseValue)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRow, baseValue, DataGridRow.DetailsTemplateProperty, dataGridRow.DataGridOwner, DataGrid.RowDetailsTemplateProperty);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0002991C File Offset: 0x00027B1C
		private static object OnCoerceDetailsTemplateSelector(DependencyObject d, object baseValue)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRow, baseValue, DataGridRow.DetailsTemplateSelectorProperty, dataGridRow.DataGridOwner, DataGrid.RowDetailsTemplateSelectorProperty);
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00029948 File Offset: 0x00027B48
		private static object OnCoerceDetailsVisibility(DependencyObject d, object baseValue)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			object obj = DataGridHelper.GetCoercedTransferPropertyValue(dataGridRow, baseValue, DataGridRow.DetailsVisibilityProperty, dataGridRow.DataGridOwner, DataGrid.RowDetailsVisibilityModeProperty);
			if (obj is DataGridRowDetailsVisibilityMode)
			{
				DataGridRowDetailsVisibilityMode dataGridRowDetailsVisibilityMode = (DataGridRowDetailsVisibilityMode)obj;
				bool flag = dataGridRow.DetailsTemplate != null || dataGridRow.DetailsTemplateSelector != null;
				bool flag2 = dataGridRow.Item != CollectionView.NewItemPlaceholder;
				switch (dataGridRowDetailsVisibilityMode)
				{
				case DataGridRowDetailsVisibilityMode.Collapsed:
					obj = Visibility.Collapsed;
					break;
				case DataGridRowDetailsVisibilityMode.Visible:
					obj = ((flag && flag2) ? Visibility.Visible : Visibility.Collapsed);
					break;
				case DataGridRowDetailsVisibilityMode.VisibleWhenSelected:
					obj = ((dataGridRow.IsSelected && flag && flag2) ? Visibility.Visible : Visibility.Collapsed);
					break;
				default:
					obj = Visibility.Collapsed;
					break;
				}
			}
			return obj;
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00029A08 File Offset: 0x00027C08
		private static object OnCoerceVisibility(DependencyObject d, object baseValue)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			DataGrid dataGridOwner = dataGridRow.DataGridOwner;
			if (dataGridRow.Item == CollectionView.NewItemPlaceholder && dataGridOwner != null)
			{
				return dataGridOwner.PlaceholderVisibility;
			}
			return baseValue;
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00029A40 File Offset: 0x00027C40
		private static void OnNotifyRowPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as DataGridRow).NotifyPropertyChanged(d, e, NotificationTarget.Rows);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00029A54 File Offset: 0x00027C54
		private static void OnNotifyRowAndRowHeaderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as DataGridRow).NotifyPropertyChanged(d, e, NotificationTarget.RowHeaders | NotificationTarget.Rows);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00029A68 File Offset: 0x00027C68
		private static void OnNotifyDetailsTemplatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			dataGridRow.NotifyPropertyChanged(dataGridRow, e, NotificationTarget.DetailsPresenter | NotificationTarget.Rows);
			if (dataGridRow.DetailsLoaded && d.GetValue(e.Property) == e.NewValue)
			{
				if (dataGridRow.DataGridOwner != null)
				{
					dataGridRow.DataGridOwner.OnUnloadingRowDetailsWrapper(dataGridRow);
				}
				if (e.NewValue != null)
				{
					Dispatcher.CurrentDispatcher.BeginInvoke(new DispatcherOperationCallback(DataGrid.DelayedOnLoadingRowDetails), DispatcherPriority.Loaded, new object[]
					{
						dataGridRow
					});
				}
			}
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00029AE8 File Offset: 0x00027CE8
		private static void OnNotifyDetailsVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGridRow dataGridRow = (DataGridRow)d;
			Dispatcher.CurrentDispatcher.BeginInvoke(new DispatcherOperationCallback(DataGridRow.DelayedRowDetailsVisibilityChanged), DispatcherPriority.Loaded, new object[]
			{
				dataGridRow
			});
			dataGridRow.NotifyPropertyChanged(d, e, NotificationTarget.DetailsPresenter | NotificationTarget.Rows);
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00029B30 File Offset: 0x00027D30
		private static object DelayedRowDetailsVisibilityChanged(object arg)
		{
			DataGridRow dataGridRow = (DataGridRow)arg;
			DataGrid dataGridOwner = dataGridRow.DataGridOwner;
			FrameworkElement detailsElement = (dataGridRow.DetailsPresenter != null) ? dataGridRow.DetailsPresenter.DetailsElement : null;
			if (dataGridOwner != null)
			{
				DataGridRowDetailsEventArgs e = new DataGridRowDetailsEventArgs(dataGridRow, detailsElement);
				dataGridOwner.OnRowDetailsVisibilityChanged(e);
			}
			return null;
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000963 RID: 2403 RVA: 0x00029B75 File Offset: 0x00027D75
		// (set) Token: 0x06000964 RID: 2404 RVA: 0x00029B7D File Offset: 0x00027D7D
		internal Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter CellsPresenter
		{
			get
			{
				return this._cellsPresenter;
			}
			set
			{
				this._cellsPresenter = value;
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000965 RID: 2405 RVA: 0x00029B86 File Offset: 0x00027D86
		// (set) Token: 0x06000966 RID: 2406 RVA: 0x00029B8E File Offset: 0x00027D8E
		internal Microsoft.Windows.Controls.Primitives.DataGridDetailsPresenter DetailsPresenter
		{
			get
			{
				return this._detailsPresenter;
			}
			set
			{
				this._detailsPresenter = value;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000967 RID: 2407 RVA: 0x00029B97 File Offset: 0x00027D97
		// (set) Token: 0x06000968 RID: 2408 RVA: 0x00029B9F File Offset: 0x00027D9F
		internal Microsoft.Windows.Controls.Primitives.DataGridRowHeader RowHeader
		{
			get
			{
				return this._rowHeader;
			}
			set
			{
				this._rowHeader = value;
			}
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x00029BA8 File Offset: 0x00027DA8
		internal void NotifyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e, NotificationTarget target)
		{
			this.NotifyPropertyChanged(d, string.Empty, e, target);
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00029BB8 File Offset: 0x00027DB8
		internal void NotifyPropertyChanged(DependencyObject d, string propertyName, DependencyPropertyChangedEventArgs e, NotificationTarget target)
		{
			if (DataGridHelper.ShouldNotifyRows(target))
			{
				if (e.Property == DataGrid.RowBackgroundProperty || e.Property == DataGrid.AlternatingRowBackgroundProperty || e.Property == Control.BackgroundProperty || e.Property == DataGridRow.AlternationIndexProperty)
				{
					DataGridHelper.TransferProperty(this, Control.BackgroundProperty);
				}
				else if (e.Property == DataGrid.RowHeaderStyleProperty || e.Property == DataGridRow.HeaderStyleProperty)
				{
					DataGridHelper.TransferProperty(this, DataGridRow.HeaderStyleProperty);
				}
				else if (e.Property == DataGrid.RowHeaderTemplateProperty || e.Property == DataGridRow.HeaderTemplateProperty)
				{
					DataGridHelper.TransferProperty(this, DataGridRow.HeaderTemplateProperty);
				}
				else if (e.Property == DataGrid.RowHeaderTemplateSelectorProperty || e.Property == DataGridRow.HeaderTemplateSelectorProperty)
				{
					DataGridHelper.TransferProperty(this, DataGridRow.HeaderTemplateSelectorProperty);
				}
				else if (e.Property == DataGrid.RowValidationErrorTemplateProperty || e.Property == DataGridRow.ValidationErrorTemplateProperty)
				{
					DataGridHelper.TransferProperty(this, DataGridRow.ValidationErrorTemplateProperty);
				}
				else if (e.Property == DataGrid.RowDetailsTemplateProperty || e.Property == DataGridRow.DetailsTemplateProperty)
				{
					DataGridHelper.TransferProperty(this, DataGridRow.DetailsTemplateProperty);
					DataGridHelper.TransferProperty(this, DataGridRow.DetailsVisibilityProperty);
				}
				else if (e.Property == DataGrid.RowDetailsTemplateSelectorProperty || e.Property == DataGridRow.DetailsTemplateSelectorProperty)
				{
					DataGridHelper.TransferProperty(this, DataGridRow.DetailsTemplateSelectorProperty);
					DataGridHelper.TransferProperty(this, DataGridRow.DetailsVisibilityProperty);
				}
				else if (e.Property == DataGrid.RowDetailsVisibilityModeProperty || e.Property == DataGridRow.DetailsVisibilityProperty || e.Property == DataGridRow.IsSelectedProperty)
				{
					DataGridHelper.TransferProperty(this, DataGridRow.DetailsVisibilityProperty);
				}
				else if (e.Property == DataGridRow.ItemProperty)
				{
					this.OnItemChanged(e.OldValue, e.NewValue);
				}
				else if (e.Property == DataGridRow.HeaderProperty)
				{
					this.OnHeaderChanged(e.OldValue, e.NewValue);
				}
				else if (e.Property == FrameworkElement.BindingGroupProperty)
				{
					base.Dispatcher.BeginInvoke(new DispatcherOperationCallback(this.DelayedValidateWithoutUpdate), DispatcherPriority.DataBind, new object[]
					{
						e.NewValue
					});
				}
			}
			if (DataGridHelper.ShouldNotifyDetailsPresenter(target) && this.DetailsPresenter != null)
			{
				this.DetailsPresenter.NotifyPropertyChanged(d, e);
			}
			if (DataGridHelper.ShouldNotifyCellsPresenter(target) || DataGridHelper.ShouldNotifyCells(target) || DataGridHelper.ShouldRefreshCellContent(target))
			{
				Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
				if (cellsPresenter != null)
				{
					cellsPresenter.NotifyPropertyChanged(d, propertyName, e, target);
				}
			}
			if (DataGridHelper.ShouldNotifyRowHeaders(target) && this.RowHeader != null)
			{
				this.RowHeader.NotifyPropertyChanged(d, e);
			}
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x00029E60 File Offset: 0x00028060
		private object DelayedValidateWithoutUpdate(object arg)
		{
			BindingGroup bindingGroup = (BindingGroup)arg;
			if (bindingGroup != null && bindingGroup.Items.Count > 0)
			{
				bindingGroup.ValidateWithoutUpdate();
			}
			return null;
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00029E90 File Offset: 0x00028090
		private void SyncProperties(bool forcePrepareCells)
		{
			DataGridHelper.TransferProperty(this, Control.BackgroundProperty);
			DataGridHelper.TransferProperty(this, DataGridRow.HeaderStyleProperty);
			DataGridHelper.TransferProperty(this, DataGridRow.HeaderTemplateProperty);
			DataGridHelper.TransferProperty(this, DataGridRow.HeaderTemplateSelectorProperty);
			DataGridHelper.TransferProperty(this, DataGridRow.ValidationErrorTemplateProperty);
			DataGridHelper.TransferProperty(this, DataGridRow.DetailsTemplateProperty);
			DataGridHelper.TransferProperty(this, DataGridRow.DetailsTemplateSelectorProperty);
			DataGridHelper.TransferProperty(this, DataGridRow.DetailsVisibilityProperty);
			base.CoerceValue(UIElement.VisibilityProperty);
			this.RestoreAttachedItemValue(this, DataGridRow.DetailsVisibilityProperty);
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null)
			{
				cellsPresenter.SyncProperties(forcePrepareCells);
				this.RestoreAttachedItemValue(cellsPresenter, FrameworkElement.HeightProperty);
			}
			if (this.DetailsPresenter != null)
			{
				this.DetailsPresenter.SyncProperties();
			}
			if (this.RowHeader != null)
			{
				this.RowHeader.SyncProperties();
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x0600096D RID: 2413 RVA: 0x00029F4F File Offset: 0x0002814F
		public int AlternationIndex
		{
			get
			{
				return (int)base.GetValue(DataGridRow.AlternationIndexProperty);
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x0600096E RID: 2414 RVA: 0x00029F61 File Offset: 0x00028161
		// (set) Token: 0x0600096F RID: 2415 RVA: 0x00029F73 File Offset: 0x00028173
		[Bindable(true)]
		[Category("Appearance")]
		public bool IsSelected
		{
			get
			{
				return (bool)base.GetValue(DataGridRow.IsSelectedProperty);
			}
			set
			{
				base.SetValue(DataGridRow.IsSelectedProperty, value);
			}
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x00029F88 File Offset: 0x00028188
		private static void OnIsSelectedChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DataGridRow dataGridRow = (DataGridRow)sender;
			bool flag = (bool)e.NewValue;
			if (flag && !dataGridRow.IsSelectable)
			{
				throw new InvalidOperationException(SR.Get(SRID.DataGridRow_CannotSelectRowWhenCells));
			}
			DataGrid dataGridOwner = dataGridRow.DataGridOwner;
			if (dataGridOwner != null && dataGridRow.DataContext != null)
			{
				Microsoft.Windows.Automation.Peers.DataGridAutomationPeer dataGridAutomationPeer = UIElementAutomationPeer.FromElement(dataGridOwner) as Microsoft.Windows.Automation.Peers.DataGridAutomationPeer;
				if (dataGridAutomationPeer != null)
				{
					Microsoft.Windows.Automation.Peers.DataGridItemAutomationPeer orCreateItemPeer = dataGridAutomationPeer.GetOrCreateItemPeer(dataGridRow.DataContext);
					if (orCreateItemPeer != null)
					{
						orCreateItemPeer.RaisePropertyChangedEvent(SelectionItemPatternIdentifiers.IsSelectedProperty, (bool)e.OldValue, flag);
					}
				}
			}
			dataGridRow.NotifyPropertyChanged(dataGridRow, e, NotificationTarget.RowHeaders | NotificationTarget.Rows);
			dataGridRow.RaiseSelectionChangedEvent(flag);
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0002A02E File Offset: 0x0002822E
		private void RaiseSelectionChangedEvent(bool isSelected)
		{
			if (isSelected)
			{
				this.OnSelected(new RoutedEventArgs(DataGridRow.SelectedEvent, this));
				return;
			}
			this.OnUnselected(new RoutedEventArgs(DataGridRow.UnselectedEvent, this));
		}

		// Token: 0x1400002B RID: 43
		// (add) Token: 0x06000972 RID: 2418 RVA: 0x0002A056 File Offset: 0x00028256
		// (remove) Token: 0x06000973 RID: 2419 RVA: 0x0002A064 File Offset: 0x00028264
		public event RoutedEventHandler Selected
		{
			add
			{
				base.AddHandler(DataGridRow.SelectedEvent, value);
			}
			remove
			{
				base.RemoveHandler(DataGridRow.SelectedEvent, value);
			}
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x0002A072 File Offset: 0x00028272
		protected virtual void OnSelected(RoutedEventArgs e)
		{
			base.RaiseEvent(e);
		}

		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000975 RID: 2421 RVA: 0x0002A07B File Offset: 0x0002827B
		// (remove) Token: 0x06000976 RID: 2422 RVA: 0x0002A089 File Offset: 0x00028289
		public event RoutedEventHandler Unselected
		{
			add
			{
				base.AddHandler(DataGridRow.UnselectedEvent, value);
			}
			remove
			{
				base.RemoveHandler(DataGridRow.UnselectedEvent, value);
			}
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0002A097 File Offset: 0x00028297
		protected virtual void OnUnselected(RoutedEventArgs e)
		{
			base.RaiseEvent(e);
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x0002A0A0 File Offset: 0x000282A0
		private bool IsSelectable
		{
			get
			{
				DataGrid dataGridOwner = this.DataGridOwner;
				if (dataGridOwner != null)
				{
					DataGridSelectionUnit selectionUnit = dataGridOwner.SelectionUnit;
					return selectionUnit == DataGridSelectionUnit.FullRow || selectionUnit == DataGridSelectionUnit.CellOrRowHeader;
				}
				return true;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000979 RID: 2425 RVA: 0x0002A0CA File Offset: 0x000282CA
		// (set) Token: 0x0600097A RID: 2426 RVA: 0x0002A0DC File Offset: 0x000282DC
		public bool IsEditing
		{
			get
			{
				return (bool)base.GetValue(DataGridRow.IsEditingProperty);
			}
			internal set
			{
				base.SetValue(DataGridRow.IsEditingPropertyKey, value);
			}
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x0002A0EF File Offset: 0x000282EF
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new Microsoft.Windows.Automation.Peers.DataGridRowAutomationPeer(this);
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0002A0F8 File Offset: 0x000282F8
		internal void ScrollCellIntoView(int index)
		{
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null)
			{
				cellsPresenter.ScrollCellIntoView(index);
			}
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0002A118 File Offset: 0x00028318
		protected override Size ArrangeOverride(Size arrangeBounds)
		{
			DataGrid dataGridOwner = this.DataGridOwner;
			if (dataGridOwner != null)
			{
				dataGridOwner.QueueInvalidateCellsPanelHorizontalOffset();
			}
			return base.ArrangeOverride(arrangeBounds);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0002A13C File Offset: 0x0002833C
		public int GetIndex()
		{
			DataGrid dataGridOwner = this.DataGridOwner;
			if (dataGridOwner != null)
			{
				return dataGridOwner.ItemContainerGenerator.IndexFromContainer(this);
			}
			return -1;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0002A161 File Offset: 0x00028361
		public static DataGridRow GetRowContainingElement(FrameworkElement element)
		{
			return DataGridHelper.FindVisualParent<DataGridRow>(element);
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000980 RID: 2432 RVA: 0x0002A169 File Offset: 0x00028369
		internal DataGrid DataGridOwner
		{
			get
			{
				return this._owner;
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000981 RID: 2433 RVA: 0x0002A171 File Offset: 0x00028371
		internal bool DetailsPresenterDrawsGridLines
		{
			get
			{
				return this._detailsPresenter != null && this._detailsPresenter.Visibility == Visibility.Visible;
			}
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0002A18C File Offset: 0x0002838C
		internal DataGridCell TryGetCell(int index)
		{
			Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter cellsPresenter = this.CellsPresenter;
			if (cellsPresenter != null)
			{
				return cellsPresenter.ItemContainerGenerator.ContainerFromIndex(index) as DataGridCell;
			}
			return null;
		}

		// Token: 0x040002CD RID: 717
		public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(object), typeof(DataGridRow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridRow.OnNotifyRowPropertyChanged)));

		// Token: 0x040002CE RID: 718
		public static readonly DependencyProperty ItemsPanelProperty = ItemsControl.ItemsPanelProperty.AddOwner(typeof(DataGridRow));

		// Token: 0x040002CF RID: 719
		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(object), typeof(DataGridRow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridRow.OnNotifyRowPropertyChanged)));

		// Token: 0x040002D0 RID: 720
		public static readonly DependencyProperty HeaderStyleProperty = DependencyProperty.Register("HeaderStyle", typeof(Style), typeof(DataGridRow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridRow.OnNotifyRowAndRowHeaderPropertyChanged), new CoerceValueCallback(DataGridRow.OnCoerceHeaderStyle)));

		// Token: 0x040002D1 RID: 721
		public static readonly DependencyProperty HeaderTemplateProperty = DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(DataGridRow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridRow.OnNotifyRowAndRowHeaderPropertyChanged), new CoerceValueCallback(DataGridRow.OnCoerceHeaderTemplate)));

		// Token: 0x040002D2 RID: 722
		public static readonly DependencyProperty HeaderTemplateSelectorProperty = DependencyProperty.Register("HeaderTemplateSelector", typeof(DataTemplateSelector), typeof(DataGridRow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridRow.OnNotifyRowAndRowHeaderPropertyChanged), new CoerceValueCallback(DataGridRow.OnCoerceHeaderTemplateSelector)));

		// Token: 0x040002D3 RID: 723
		public static readonly DependencyProperty ValidationErrorTemplateProperty = DependencyProperty.Register("ValidationErrorTemplate", typeof(ControlTemplate), typeof(DataGridRow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridRow.OnNotifyRowPropertyChanged), new CoerceValueCallback(DataGridRow.OnCoerceValidationErrorTemplate)));

		// Token: 0x040002D4 RID: 724
		public static readonly DependencyProperty DetailsTemplateProperty = DependencyProperty.Register("DetailsTemplate", typeof(DataTemplate), typeof(DataGridRow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridRow.OnNotifyDetailsTemplatePropertyChanged), new CoerceValueCallback(DataGridRow.OnCoerceDetailsTemplate)));

		// Token: 0x040002D5 RID: 725
		public static readonly DependencyProperty DetailsTemplateSelectorProperty = DependencyProperty.Register("DetailsTemplateSelector", typeof(DataTemplateSelector), typeof(DataGridRow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridRow.OnNotifyDetailsTemplatePropertyChanged), new CoerceValueCallback(DataGridRow.OnCoerceDetailsTemplateSelector)));

		// Token: 0x040002D6 RID: 726
		public static readonly DependencyProperty DetailsVisibilityProperty = DependencyProperty.Register("DetailsVisibility", typeof(Visibility), typeof(DataGridRow), new FrameworkPropertyMetadata(Visibility.Collapsed, new PropertyChangedCallback(DataGridRow.OnNotifyDetailsVisibilityChanged), new CoerceValueCallback(DataGridRow.OnCoerceDetailsVisibility)));

		// Token: 0x040002D7 RID: 727
		public static readonly DependencyProperty AlternationIndexProperty = ItemsControl.AlternationIndexProperty.AddOwner(typeof(DataGridRow));

		// Token: 0x040002D8 RID: 728
		public static readonly DependencyProperty IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof(DataGridRow), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(DataGridRow.OnIsSelectedChanged)));

		// Token: 0x040002DB RID: 731
		private static readonly DependencyPropertyKey IsEditingPropertyKey;

		// Token: 0x040002DC RID: 732
		public static readonly DependencyProperty IsEditingProperty;

		// Token: 0x040002DD RID: 733
		internal bool _detailsLoaded;

		// Token: 0x040002DE RID: 734
		private DataGrid _owner;

		// Token: 0x040002DF RID: 735
		private Microsoft.Windows.Controls.Primitives.DataGridCellsPresenter _cellsPresenter;

		// Token: 0x040002E0 RID: 736
		private Microsoft.Windows.Controls.Primitives.DataGridDetailsPresenter _detailsPresenter;

		// Token: 0x040002E1 RID: 737
		private Microsoft.Windows.Controls.Primitives.DataGridRowHeader _rowHeader;

		// Token: 0x040002E2 RID: 738
		private ContainerTracking<DataGridRow> _tracker;

		// Token: 0x040002E3 RID: 739
		private double _cellsPresenterResizeHeight;
	}
}

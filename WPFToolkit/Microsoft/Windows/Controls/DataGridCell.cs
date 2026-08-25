using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Windows.Automation.Peers;
using Microsoft.Windows.Controls.Primitives;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000032 RID: 50
	public class DataGridCell : ContentControl, IProvideDataGridColumn
	{
		// Token: 0x06000284 RID: 644 RVA: 0x00009B88 File Offset: 0x00007D88
		static DataGridCell()
		{
			DataGridCell.SelectedEvent = EventManager.RegisterRoutedEvent("Selected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DataGridCell));
			DataGridCell.UnselectedEvent = EventManager.RegisterRoutedEvent("Unselected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DataGridCell));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridCell), new FrameworkPropertyMetadata(typeof(DataGridCell)));
			FrameworkElement.StyleProperty.OverrideMetadata(typeof(DataGridCell), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridCell.OnNotifyPropertyChanged), new CoerceValueCallback(DataGridCell.OnCoerceStyle)));
			UIElement.ClipProperty.OverrideMetadata(typeof(DataGridCell), new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGridCell.OnCoerceClip)));
			KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(DataGridCell), new FrameworkPropertyMetadata(KeyboardNavigationMode.Local));
			UIElement.SnapsToDevicePixelsProperty.OverrideMetadata(typeof(DataGridCell), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsArrange));
			EventManager.RegisterClassHandler(typeof(DataGridCell), UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(DataGridCell.OnAnyMouseLeftButtonDownThunk), true);
			EventManager.RegisterClassHandler(typeof(DataGridCell), UIElement.LostFocusEvent, new RoutedEventHandler(DataGridCell.OnAnyLostFocus), true);
			EventManager.RegisterClassHandler(typeof(DataGridCell), UIElement.GotFocusEvent, new RoutedEventHandler(DataGridCell.OnAnyGotFocus), true);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x00009E07 File Offset: 0x00008007
		public DataGridCell()
		{
			this._tracker = new ContainerTracking<DataGridCell>(this);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00009E1B File Offset: 0x0000801B
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new Microsoft.Windows.Automation.Peers.DataGridCellAutomationPeer(this);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00009E23 File Offset: 0x00008023
		internal void PrepareCell(object item, ItemsControl cellsPresenter, DataGridRow ownerRow)
		{
			this.PrepareCell(item, ownerRow, cellsPresenter.ItemContainerGenerator.IndexFromContainer(this));
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00009E3C File Offset: 0x0000803C
		internal void PrepareCell(object item, DataGridRow ownerRow, int index)
		{
			this._owner = ownerRow;
			DataGrid dataGridOwner = this._owner.DataGridOwner;
			if (dataGridOwner != null)
			{
				if (index >= 0 && index < dataGridOwner.Columns.Count)
				{
					DataGridColumn dataGridColumn = dataGridOwner.Columns[index];
					this.Column = dataGridColumn;
					base.TabIndex = dataGridColumn.DisplayIndex;
				}
				if (this.IsEditing)
				{
					this.IsEditing = false;
				}
				else if (!(base.Content is FrameworkElement))
				{
					this.BuildVisualTree();
					if (!this.NeedsVisualTree)
					{
						base.Content = item;
					}
				}
				bool isSelected = dataGridOwner.SelectedCellsInternal.Contains(this);
				this.SyncIsSelected(isSelected);
			}
			DataGridHelper.TransferProperty(this, FrameworkElement.StyleProperty);
			DataGridHelper.TransferProperty(this, DataGridCell.IsReadOnlyProperty);
			base.CoerceValue(UIElement.ClipProperty);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00009EF9 File Offset: 0x000080F9
		internal void ClearCell(DataGridRow ownerRow)
		{
			this._owner = null;
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600028A RID: 650 RVA: 0x00009F02 File Offset: 0x00008102
		internal ContainerTracking<DataGridCell> Tracker
		{
			get
			{
				return this._tracker;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600028B RID: 651 RVA: 0x00009F0A File Offset: 0x0000810A
		// (set) Token: 0x0600028C RID: 652 RVA: 0x00009F1C File Offset: 0x0000811C
		public DataGridColumn Column
		{
			get
			{
				return (DataGridColumn)base.GetValue(DataGridCell.ColumnProperty);
			}
			internal set
			{
				base.SetValue(DataGridCell.ColumnPropertyKey, value);
			}
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00009F2C File Offset: 0x0000812C
		private static void OnColumnChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DataGridCell dataGridCell = sender as DataGridCell;
			if (dataGridCell != null)
			{
				dataGridCell.OnColumnChanged((DataGridColumn)e.OldValue, (DataGridColumn)e.NewValue);
			}
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00009F61 File Offset: 0x00008161
		protected virtual void OnColumnChanged(DataGridColumn oldColumn, DataGridColumn newColumn)
		{
			base.Content = null;
			DataGridHelper.TransferProperty(this, FrameworkElement.StyleProperty);
			DataGridHelper.TransferProperty(this, DataGridCell.IsReadOnlyProperty);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00009F80 File Offset: 0x00008180
		private static void OnNotifyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGridCell)d).NotifyPropertyChanged(d, string.Empty, e, NotificationTarget.Cells);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00009F98 File Offset: 0x00008198
		private static void OnNotifyIsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGridCell dataGridCell = (DataGridCell)d;
			DataGrid dataGridOwner = dataGridCell.DataGridOwner;
			if ((bool)e.NewValue && dataGridOwner != null)
			{
				dataGridOwner.CancelEdit(dataGridCell);
			}
			CommandManager.InvalidateRequerySuggested();
			dataGridCell.NotifyPropertyChanged(d, string.Empty, e, NotificationTarget.Cells);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00009FE0 File Offset: 0x000081E0
		internal void NotifyPropertyChanged(DependencyObject d, string propertyName, DependencyPropertyChangedEventArgs e, NotificationTarget target)
		{
			DataGridColumn dataGridColumn = d as DataGridColumn;
			if (dataGridColumn != null && dataGridColumn != this.Column)
			{
				return;
			}
			if (DataGridHelper.ShouldNotifyCells(target))
			{
				if (e.Property == DataGridColumn.WidthProperty)
				{
					DataGridHelper.OnColumnWidthChanged(this, e);
				}
				else if (e.Property == DataGrid.CellStyleProperty || e.Property == DataGridColumn.CellStyleProperty || e.Property == FrameworkElement.StyleProperty)
				{
					DataGridHelper.TransferProperty(this, FrameworkElement.StyleProperty);
				}
				else if (e.Property == DataGrid.IsReadOnlyProperty || e.Property == DataGridColumn.IsReadOnlyProperty || e.Property == DataGridCell.IsReadOnlyProperty)
				{
					DataGridHelper.TransferProperty(this, DataGridCell.IsReadOnlyProperty);
				}
				else if (e.Property == DataGridColumn.DisplayIndexProperty)
				{
					base.TabIndex = dataGridColumn.DisplayIndex;
				}
			}
			if (DataGridHelper.ShouldRefreshCellContent(target) && dataGridColumn != null && this.NeedsVisualTree)
			{
				if (!string.IsNullOrEmpty(propertyName))
				{
					dataGridColumn.RefreshCellContent(this, propertyName);
					return;
				}
				if (e.Property != null)
				{
					dataGridColumn.RefreshCellContent(this, e.Property.Name);
				}
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000A0F0 File Offset: 0x000082F0
		private static object OnCoerceStyle(DependencyObject d, object baseValue)
		{
			DataGridCell dataGridCell = d as DataGridCell;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridCell, baseValue, FrameworkElement.StyleProperty, dataGridCell.Column, DataGridColumn.CellStyleProperty, dataGridCell.DataGridOwner, DataGrid.CellStyleProperty);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000A128 File Offset: 0x00008328
		internal void BuildVisualTree()
		{
			if (this.NeedsVisualTree)
			{
				DataGridColumn column = this.Column;
				if (column != null)
				{
					DataGridRow rowOwner = this.RowOwner;
					if (rowOwner != null)
					{
						BindingGroup bindingGroup = rowOwner.BindingGroup;
						if (bindingGroup != null)
						{
							this.RemoveBindingExpressions(bindingGroup, base.Content as DependencyObject);
						}
					}
					base.Content = column.BuildVisualTree(this.IsEditing, this.RowDataItem, this);
				}
			}
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000A188 File Offset: 0x00008388
		private void RemoveBindingExpressions(BindingGroup bindingGroup, DependencyObject element)
		{
			if (element != null)
			{
				Collection<BindingExpressionBase> bindingExpressions = bindingGroup.BindingExpressions;
				LocalValueEnumerator localValueEnumerator = element.GetLocalValueEnumerator();
				while (localValueEnumerator.MoveNext())
				{
					LocalValueEntry localValueEntry = localValueEnumerator.Current;
					BindingExpression bindingExpression = localValueEntry.Value as BindingExpression;
					if (bindingExpression != null)
					{
						for (int i = 0; i < bindingExpressions.Count; i++)
						{
							if (object.ReferenceEquals(bindingExpression, bindingExpressions[i]))
							{
								bindingExpressions.RemoveAt(i--);
							}
						}
					}
				}
				foreach (object obj in LogicalTreeHelper.GetChildren(element))
				{
					this.RemoveBindingExpressions(bindingGroup, obj as DependencyObject);
				}
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000295 RID: 661 RVA: 0x0000A250 File Offset: 0x00008450
		// (set) Token: 0x06000296 RID: 662 RVA: 0x0000A262 File Offset: 0x00008462
		public bool IsEditing
		{
			get
			{
				return (bool)base.GetValue(DataGridCell.IsEditingProperty);
			}
			set
			{
				base.SetValue(DataGridCell.IsEditingProperty, value);
			}
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000A275 File Offset: 0x00008475
		private static void OnIsEditingChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			((DataGridCell)sender).OnIsEditingChanged((bool)e.NewValue);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000A28E File Offset: 0x0000848E
		protected virtual void OnIsEditingChanged(bool isEditing)
		{
			if (base.IsKeyboardFocusWithin && !base.IsKeyboardFocused)
			{
				base.Focus();
			}
			this.BuildVisualTree();
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000A2AD File Offset: 0x000084AD
		public bool IsReadOnly
		{
			get
			{
				return (bool)base.GetValue(DataGridCell.IsReadOnlyProperty);
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000A2C0 File Offset: 0x000084C0
		private static object OnCoerceIsReadOnly(DependencyObject d, object baseValue)
		{
			DataGridCell dataGridCell = d as DataGridCell;
			DataGridColumn column = dataGridCell.Column;
			DataGrid dataGridOwner = dataGridCell.DataGridOwner;
			return DataGridHelper.GetCoercedTransferPropertyValue(column, column.IsReadOnly, DataGridColumn.IsReadOnlyProperty, dataGridOwner, DataGrid.IsReadOnlyProperty);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000A300 File Offset: 0x00008500
		private static void OnAnyLostFocus(object sender, RoutedEventArgs e)
		{
			DataGridCell dataGridCell = DataGridHelper.FindVisualParent<DataGridCell>(e.OriginalSource as UIElement);
			if (dataGridCell != null && dataGridCell == sender)
			{
				DataGrid dataGridOwner = dataGridCell.DataGridOwner;
				if (dataGridOwner != null && !dataGridCell.IsKeyboardFocusWithin && dataGridOwner.FocusedCell == dataGridCell)
				{
					dataGridOwner.FocusedCell = null;
				}
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000A348 File Offset: 0x00008548
		private static void OnAnyGotFocus(object sender, RoutedEventArgs e)
		{
			DataGridCell dataGridCell = DataGridHelper.FindVisualParent<DataGridCell>(e.OriginalSource as UIElement);
			if (dataGridCell != null && dataGridCell == sender)
			{
				DataGrid dataGridOwner = dataGridCell.DataGridOwner;
				if (dataGridOwner != null)
				{
					dataGridOwner.FocusedCell = dataGridCell;
				}
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000A380 File Offset: 0x00008580
		internal void BeginEdit(RoutedEventArgs e)
		{
			this.IsEditing = true;
			DataGridColumn column = this.Column;
			if (column != null)
			{
				column.BeginEdit(base.Content as FrameworkElement, e);
			}
			this.RaisePreparingCellForEdit(e);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000A3B8 File Offset: 0x000085B8
		internal void CancelEdit()
		{
			DataGridColumn column = this.Column;
			if (column != null)
			{
				column.CancelEdit(base.Content as FrameworkElement);
			}
			this.IsEditing = false;
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000A3E8 File Offset: 0x000085E8
		internal bool CommitEdit()
		{
			bool flag = true;
			DataGridColumn column = this.Column;
			if (column != null)
			{
				flag = column.CommitEdit(base.Content as FrameworkElement);
			}
			if (flag)
			{
				this.IsEditing = false;
			}
			return flag;
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000A420 File Offset: 0x00008620
		private void RaisePreparingCellForEdit(RoutedEventArgs editingEventArgs)
		{
			DataGrid dataGridOwner = this.DataGridOwner;
			if (dataGridOwner != null)
			{
				FrameworkElement editingElement = this.EditingElement;
				DataGridPreparingCellForEditEventArgs e = new DataGridPreparingCellForEditEventArgs(this.Column, this.RowOwner, editingEventArgs, editingElement);
				dataGridOwner.OnPreparingCellForEdit(e);
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x0000A459 File Offset: 0x00008659
		internal FrameworkElement EditingElement
		{
			get
			{
				return base.Content as FrameworkElement;
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000A466 File Offset: 0x00008666
		// (set) Token: 0x060002A3 RID: 675 RVA: 0x0000A478 File Offset: 0x00008678
		public bool IsSelected
		{
			get
			{
				return (bool)base.GetValue(DataGridCell.IsSelectedProperty);
			}
			set
			{
				base.SetValue(DataGridCell.IsSelectedProperty, value);
			}
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x0000A48C File Offset: 0x0000868C
		private static void OnIsSelectedChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			DataGridCell dataGridCell = (DataGridCell)sender;
			bool isSelected = (bool)e.NewValue;
			if (!dataGridCell._syncingIsSelected)
			{
				DataGrid dataGridOwner = dataGridCell.DataGridOwner;
				if (dataGridOwner != null)
				{
					dataGridOwner.CellIsSelectedChanged(dataGridCell, isSelected);
				}
			}
			dataGridCell.RaiseSelectionChangedEvent(isSelected);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000A4D0 File Offset: 0x000086D0
		internal void SyncIsSelected(bool isSelected)
		{
			bool syncingIsSelected = this._syncingIsSelected;
			this._syncingIsSelected = true;
			try
			{
				this.IsSelected = isSelected;
			}
			finally
			{
				this._syncingIsSelected = syncingIsSelected;
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0000A50C File Offset: 0x0000870C
		private void RaiseSelectionChangedEvent(bool isSelected)
		{
			if (isSelected)
			{
				this.OnSelected(new RoutedEventArgs(DataGridCell.SelectedEvent, this));
				return;
			}
			this.OnUnselected(new RoutedEventArgs(DataGridCell.UnselectedEvent, this));
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060002A7 RID: 679 RVA: 0x0000A534 File Offset: 0x00008734
		// (remove) Token: 0x060002A8 RID: 680 RVA: 0x0000A542 File Offset: 0x00008742
		public event RoutedEventHandler Selected
		{
			add
			{
				base.AddHandler(DataGridCell.SelectedEvent, value);
			}
			remove
			{
				base.RemoveHandler(DataGridCell.SelectedEvent, value);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x0000A550 File Offset: 0x00008750
		protected virtual void OnSelected(RoutedEventArgs e)
		{
			base.RaiseEvent(e);
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060002AA RID: 682 RVA: 0x0000A559 File Offset: 0x00008759
		// (remove) Token: 0x060002AB RID: 683 RVA: 0x0000A567 File Offset: 0x00008767
		public event RoutedEventHandler Unselected
		{
			add
			{
				base.AddHandler(DataGridCell.UnselectedEvent, value);
			}
			remove
			{
				base.RemoveHandler(DataGridCell.UnselectedEvent, value);
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000A575 File Offset: 0x00008775
		protected virtual void OnUnselected(RoutedEventArgs e)
		{
			base.RaiseEvent(e);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000A580 File Offset: 0x00008780
		protected override Size MeasureOverride(Size constraint)
		{
			if (DataGridHelper.IsGridLineVisible(this.DataGridOwner, false))
			{
				double verticalGridLineThickness = this.DataGridOwner.VerticalGridLineThickness;
				Size result = base.MeasureOverride(DataGridHelper.SubtractFromSize(constraint, verticalGridLineThickness, false));
				result.Width += verticalGridLineThickness;
				return result;
			}
			return base.MeasureOverride(constraint);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000A5D0 File Offset: 0x000087D0
		protected override Size ArrangeOverride(Size arrangeSize)
		{
			if (DataGridHelper.IsGridLineVisible(this.DataGridOwner, false))
			{
				double verticalGridLineThickness = this.DataGridOwner.VerticalGridLineThickness;
				Size result = base.ArrangeOverride(DataGridHelper.SubtractFromSize(arrangeSize, verticalGridLineThickness, false));
				result.Width += verticalGridLineThickness;
				return result;
			}
			return base.ArrangeOverride(arrangeSize);
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000A620 File Offset: 0x00008820
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			if (DataGridHelper.IsGridLineVisible(this.DataGridOwner, false))
			{
				double verticalGridLineThickness = this.DataGridOwner.VerticalGridLineThickness;
				Rect rectangle = new Rect(new Size(verticalGridLineThickness, base.RenderSize.Height));
				rectangle.X = base.RenderSize.Width - verticalGridLineThickness;
				drawingContext.DrawRectangle(this.DataGridOwner.VerticalGridLinesBrush, null, rectangle);
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000A693 File Offset: 0x00008893
		private static void OnAnyMouseLeftButtonDownThunk(object sender, MouseButtonEventArgs e)
		{
			((DataGridCell)sender).OnAnyMouseLeftButtonDown(e);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000A6A4 File Offset: 0x000088A4
		private void OnAnyMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			bool isKeyboardFocusWithin = base.IsKeyboardFocusWithin;
			bool flag = (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control;
			if (isKeyboardFocusWithin && !flag && !e.Handled && !this.IsEditing && !this.IsReadOnly && this.IsSelected)
			{
				DataGrid dataGridOwner = this.DataGridOwner;
				if (dataGridOwner != null)
				{
					dataGridOwner.HandleSelectionForCellInput(this, false, true, false);
					dataGridOwner.BeginEdit(e);
					e.Handled = true;
					return;
				}
			}
			else if (!isKeyboardFocusWithin || !this.IsSelected || flag)
			{
				if (!isKeyboardFocusWithin)
				{
					base.Focus();
				}
				DataGrid dataGridOwner2 = this.DataGridOwner;
				if (dataGridOwner2 != null)
				{
					dataGridOwner2.HandleSelectionForCellInput(this, Mouse.Captured == null, true, true);
				}
				e.Handled = true;
			}
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000A747 File Offset: 0x00008947
		protected override void OnTextInput(TextCompositionEventArgs e)
		{
			this.SendInputToColumn(e);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000A750 File Offset: 0x00008950
		protected override void OnKeyDown(KeyEventArgs e)
		{
			this.SendInputToColumn(e);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000A75C File Offset: 0x0000895C
		private void SendInputToColumn(InputEventArgs e)
		{
			DataGridColumn column = this.Column;
			if (column != null)
			{
				column.OnInput(e);
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000A77C File Offset: 0x0000897C
		private static object OnCoerceClip(DependencyObject d, object baseValue)
		{
			DataGridCell cell = (DataGridCell)d;
			Geometry geometry = baseValue as Geometry;
			Geometry frozenClipForCell = DataGridHelper.GetFrozenClipForCell(cell);
			if (frozenClipForCell != null)
			{
				if (geometry == null)
				{
					return frozenClipForCell;
				}
				geometry = new CombinedGeometry(GeometryCombineMode.Intersect, geometry, frozenClipForCell);
			}
			return geometry;
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x0000A7B0 File Offset: 0x000089B0
		internal DataGrid DataGridOwner
		{
			get
			{
				if (this._owner != null)
				{
					DataGrid dataGrid = this._owner.DataGridOwner;
					if (dataGrid == null)
					{
						dataGrid = (ItemsControl.ItemsControlFromItemContainer(this._owner) as DataGrid);
					}
					return dataGrid;
				}
				return null;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x0000A7E8 File Offset: 0x000089E8
		private Panel ParentPanel
		{
			get
			{
				return base.VisualParent as Panel;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x0000A7F5 File Offset: 0x000089F5
		internal DataGridRow RowOwner
		{
			get
			{
				return this._owner;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x0000A800 File Offset: 0x00008A00
		internal object RowDataItem
		{
			get
			{
				DataGridRow rowOwner = this.RowOwner;
				if (rowOwner != null)
				{
					return rowOwner.Item;
				}
				return base.DataContext;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002BA RID: 698 RVA: 0x0000A824 File Offset: 0x00008A24
		private DataGridCellsPresenter CellsPresenter
		{
			get
			{
				return ItemsControl.ItemsControlFromItemContainer(this) as DataGridCellsPresenter;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060002BB RID: 699 RVA: 0x0000A831 File Offset: 0x00008A31
		private bool NeedsVisualTree
		{
			get
			{
				return base.ContentTemplate == null && base.ContentTemplateSelector == null;
			}
		}

		// Token: 0x040000AE RID: 174
		private static readonly DependencyPropertyKey ColumnPropertyKey = DependencyProperty.RegisterReadOnly("Column", typeof(DataGridColumn), typeof(DataGridCell), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridCell.OnColumnChanged)));

		// Token: 0x040000AF RID: 175
		public static readonly DependencyProperty ColumnProperty = DataGridCell.ColumnPropertyKey.DependencyProperty;

		// Token: 0x040000B0 RID: 176
		public static readonly DependencyProperty IsEditingProperty = DependencyProperty.Register("IsEditing", typeof(bool), typeof(DataGridCell), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DataGridCell.OnIsEditingChanged)));

		// Token: 0x040000B1 RID: 177
		private static readonly DependencyPropertyKey IsReadOnlyPropertyKey = DependencyProperty.RegisterReadOnly("IsReadOnly", typeof(bool), typeof(DataGridCell), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DataGridCell.OnNotifyIsReadOnlyChanged), new CoerceValueCallback(DataGridCell.OnCoerceIsReadOnly)));

		// Token: 0x040000B2 RID: 178
		public static readonly DependencyProperty IsReadOnlyProperty = DataGridCell.IsReadOnlyPropertyKey.DependencyProperty;

		// Token: 0x040000B3 RID: 179
		public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(DataGridCell), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DataGridCell.OnIsSelectedChanged)));

		// Token: 0x040000B6 RID: 182
		private DataGridRow _owner;

		// Token: 0x040000B7 RID: 183
		private ContainerTracking<DataGridCell> _tracker;

		// Token: 0x040000B8 RID: 184
		private bool _syncingIsSelected;
	}
}

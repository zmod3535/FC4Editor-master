using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MS.Internal;

namespace Microsoft.Windows.Controls.Primitives
{
	// Token: 0x02000048 RID: 72
	public class DataGridCellsPresenter : ItemsControl
	{
		// Token: 0x0600057F RID: 1407 RVA: 0x00015A14 File Offset: 0x00013C14
		static DataGridCellsPresenter()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridCellsPresenter), new FrameworkPropertyMetadata(typeof(DataGridCellsPresenter)));
			ItemsControl.ItemsPanelProperty.OverrideMetadata(typeof(DataGridCellsPresenter), new FrameworkPropertyMetadata(new ItemsPanelTemplate(new FrameworkElementFactory(typeof(DataGridCellsPanel)))));
			UIElement.FocusableProperty.OverrideMetadata(typeof(DataGridCellsPresenter), new FrameworkPropertyMetadata(false));
			FrameworkElement.HeightProperty.OverrideMetadata(typeof(DataGridCellsPresenter), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridCellsPresenter.OnNotifyHeightPropertyChanged), new CoerceValueCallback(DataGridCellsPresenter.OnCoerceHeight)));
			FrameworkElement.MinHeightProperty.OverrideMetadata(typeof(DataGridCellsPresenter), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridCellsPresenter.OnNotifyHeightPropertyChanged), new CoerceValueCallback(DataGridCellsPresenter.OnCoerceMinHeight)));
			VirtualizingStackPanel.IsVirtualizingProperty.OverrideMetadata(typeof(DataGridCellsPresenter), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DataGridCellsPresenter.OnIsVirtualizingPropertyChanged), new CoerceValueCallback(DataGridCellsPresenter.OnCoerceIsVirtualizingProperty)));
			VirtualizingStackPanel.VirtualizationModeProperty.OverrideMetadata(typeof(DataGridCellsPresenter), new FrameworkPropertyMetadata(VirtualizationMode.Recycling));
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00015B50 File Offset: 0x00013D50
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			if (dataGridRowOwner != null)
			{
				dataGridRowOwner.CellsPresenter = this;
				this.Item = dataGridRowOwner.Item;
			}
			this.SyncProperties(false);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00015B88 File Offset: 0x00013D88
		internal void SyncProperties(bool forcePrepareCells)
		{
			DataGrid dataGridOwner = this.DataGridOwner;
			if (dataGridOwner == null)
			{
				return;
			}
			DataGridHelper.TransferProperty(this, FrameworkElement.HeightProperty);
			DataGridHelper.TransferProperty(this, FrameworkElement.MinHeightProperty);
			DataGridHelper.TransferProperty(this, VirtualizingStackPanel.IsVirtualizingProperty);
			this.NotifyPropertyChanged(this, new DependencyPropertyChangedEventArgs(DataGrid.CellStyleProperty, null, null), NotificationTarget.Cells);
			MultipleCopiesCollection multipleCopiesCollection = base.ItemsSource as MultipleCopiesCollection;
			if (multipleCopiesCollection != null)
			{
				ObservableCollection<DataGridColumn> columns = dataGridOwner.Columns;
				int count = columns.Count;
				int count2 = multipleCopiesCollection.Count;
				int num = 0;
				if (count != count2)
				{
					multipleCopiesCollection.SyncToCount(count);
					num = Math.Min(count, count2);
				}
				else if (forcePrepareCells)
				{
					num = count;
				}
				DataGridRow dataGridRowOwner = this.DataGridRowOwner;
				bool flag = false;
				for (int i = 0; i < num; i++)
				{
					DataGridCell dataGridCell = (DataGridCell)base.ItemContainerGenerator.ContainerFromIndex(i);
					if (dataGridCell != null)
					{
						dataGridCell.PrepareCell(dataGridRowOwner.Item, this, dataGridRowOwner);
						if (!flag && !DoubleUtil.AreClose(dataGridCell.ActualWidth, columns[i].Width.DisplayValue))
						{
							this.InvalidateDataGridCellsPanelMeasureAndArrange();
							flag = true;
						}
					}
				}
				if (!flag)
				{
					for (int j = num; j < count; j++)
					{
						DataGridCell dataGridCell = (DataGridCell)base.ItemContainerGenerator.ContainerFromIndex(j);
						if (dataGridCell != null && !DoubleUtil.AreClose(dataGridCell.ActualWidth, columns[j].Width.DisplayValue))
						{
							this.InvalidateDataGridCellsPanelMeasureAndArrange();
							flag = true;
							break;
						}
					}
				}
				if (!flag && this.InvalidateCellsPanelOnColumnChange())
				{
					this.InvalidateDataGridCellsPanelMeasureAndArrange();
				}
			}
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00015D04 File Offset: 0x00013F04
		private bool InvalidateCellsPanelOnColumnChange()
		{
			if (this.InternalItemsHost == null)
			{
				return false;
			}
			bool isVirtualizing = VirtualizingStackPanel.GetIsVirtualizing(this);
			List<RealizedColumnsBlock> list = null;
			if (isVirtualizing && !this.DataGridOwner.InternalColumns.RebuildRealizedColumnsBlockListForVirtualizedRows)
			{
				list = this.DataGridOwner.InternalColumns.RealizedColumnsBlockListForVirtualizedRows;
			}
			else if (!isVirtualizing && !this.DataGridOwner.InternalColumns.RebuildRealizedColumnsBlockListForNonVirtualizedRows)
			{
				list = this.DataGridOwner.InternalColumns.RealizedColumnsBlockListForNonVirtualizedRows;
			}
			if (list == null)
			{
				return true;
			}
			IList children = this.InternalItemsHost.Children;
			int num = 0;
			int num2 = 0;
			int count = children.Count;
			int count2 = list.Count;
			int count3 = this.DataGridOwner.Columns.Count;
			for (int i = 0; i < count3; i++)
			{
				bool flag = false;
				bool flag2 = false;
				if (num < count2)
				{
					RealizedColumnsBlock realizedColumnsBlock = list[num];
					if (realizedColumnsBlock.StartIndex <= i && i <= realizedColumnsBlock.EndIndex)
					{
						flag = true;
						if (i == realizedColumnsBlock.EndIndex)
						{
							num++;
						}
					}
				}
				if (num2 < count)
				{
					DataGridCell dataGridCell = children[num2] as DataGridCell;
					if (this.DataGridOwner.Columns[i] == dataGridCell.Column)
					{
						flag2 = true;
						num2++;
					}
				}
				bool flag3 = num == count2;
				bool flag4 = num2 == count;
				if (flag2 != flag || flag3 != flag4)
				{
					return true;
				}
				if (flag3)
				{
					break;
				}
			}
			return false;
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00015E58 File Offset: 0x00014058
		private static object OnCoerceHeight(DependencyObject d, object baseValue)
		{
			DataGridCellsPresenter dataGridCellsPresenter = d as DataGridCellsPresenter;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridCellsPresenter, baseValue, FrameworkElement.HeightProperty, dataGridCellsPresenter.DataGridOwner, DataGrid.RowHeightProperty);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00015E84 File Offset: 0x00014084
		private static object OnCoerceMinHeight(DependencyObject d, object baseValue)
		{
			DataGridCellsPresenter dataGridCellsPresenter = d as DataGridCellsPresenter;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridCellsPresenter, baseValue, FrameworkElement.MinHeightProperty, dataGridCellsPresenter.DataGridOwner, DataGrid.MinRowHeightProperty);
		}

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x00015EAF File Offset: 0x000140AF
		// (set) Token: 0x06000587 RID: 1415 RVA: 0x00015EB8 File Offset: 0x000140B8
		public object Item
		{
			get
			{
				return this._item;
			}
			internal set
			{
				if (this._item != value)
				{
					object item = this._item;
					this._item = value;
					this.OnItemChanged(item, this._item);
				}
			}
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00015EEC File Offset: 0x000140EC
		protected virtual void OnItemChanged(object oldItem, object newItem)
		{
			ObservableCollection<DataGridColumn> columns = this.Columns;
			if (columns != null)
			{
				MultipleCopiesCollection multipleCopiesCollection = base.ItemsSource as MultipleCopiesCollection;
				if (multipleCopiesCollection == null)
				{
					multipleCopiesCollection = new MultipleCopiesCollection(newItem, columns.Count);
					base.ItemsSource = multipleCopiesCollection;
					return;
				}
				multipleCopiesCollection.CopiedItem = newItem;
			}
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00015F2E File Offset: 0x0001412E
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is DataGridCell;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00015F39 File Offset: 0x00014139
		internal bool IsItemItsOwnContainerInternal(object item)
		{
			return this.IsItemItsOwnContainerOverride(item);
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00015F42 File Offset: 0x00014142
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new DataGridCell();
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00015F4C File Offset: 0x0001414C
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			DataGridCell dataGridCell = (DataGridCell)element;
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			if (dataGridCell.RowOwner != dataGridRowOwner)
			{
				dataGridCell.Tracker.StartTracking(ref this._cellTrackingRoot);
			}
			dataGridCell.PrepareCell(item, this, dataGridRowOwner);
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00015F8C File Offset: 0x0001418C
		protected override void ClearContainerForItemOverride(DependencyObject element, object item)
		{
			DataGridCell dataGridCell = (DataGridCell)element;
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			if (dataGridCell.RowOwner == dataGridRowOwner)
			{
				dataGridCell.Tracker.StopTracking(ref this._cellTrackingRoot);
			}
			dataGridCell.ClearCell(dataGridRowOwner);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00015FC8 File Offset: 0x000141C8
		protected internal virtual void OnColumnsChanged(ObservableCollection<DataGridColumn> columns, NotifyCollectionChangedEventArgs e)
		{
			MultipleCopiesCollection multipleCopiesCollection = base.ItemsSource as MultipleCopiesCollection;
			if (multipleCopiesCollection != null)
			{
				multipleCopiesCollection.MirrorCollectionChange(e);
			}
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00015FEB File Offset: 0x000141EB
		private static void OnNotifyHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGridCellsPresenter)d).NotifyPropertyChanged(d, e, NotificationTarget.CellsPresenter);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00015FFB File Offset: 0x000141FB
		internal void NotifyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e, NotificationTarget target)
		{
			this.NotifyPropertyChanged(d, string.Empty, e, target);
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0001600C File Offset: 0x0001420C
		internal void NotifyPropertyChanged(DependencyObject d, string propertyName, DependencyPropertyChangedEventArgs e, NotificationTarget target)
		{
			if (DataGridHelper.ShouldNotifyCellsPresenter(target))
			{
				if (e.Property == DataGridColumn.WidthProperty || e.Property == DataGridColumn.DisplayIndexProperty)
				{
					if (((DataGridColumn)d).IsVisible)
					{
						this.InvalidateDataGridCellsPanelMeasureAndArrange();
					}
				}
				else if (e.Property == DataGrid.FrozenColumnCountProperty || e.Property == DataGridColumn.VisibilityProperty || e.Property == DataGrid.CellsPanelHorizontalOffsetProperty || e.Property == DataGrid.HorizontalScrollOffsetProperty || string.Compare(propertyName, "ViewportWidth", StringComparison.Ordinal) == 0 || string.Compare(propertyName, "DelayedColumnWidthComputation", StringComparison.Ordinal) == 0)
				{
					this.InvalidateDataGridCellsPanelMeasureAndArrange();
				}
				else if (string.Compare(propertyName, "RealizedColumnsBlockListForNonVirtualizedRows", StringComparison.Ordinal) == 0)
				{
					this.InvalidateDataGridCellsPanelMeasureAndArrange(false);
				}
				else if (string.Compare(propertyName, "RealizedColumnsBlockListForVirtualizedRows", StringComparison.Ordinal) == 0)
				{
					this.InvalidateDataGridCellsPanelMeasureAndArrange(true);
				}
				else if (e.Property == DataGrid.RowHeightProperty || e.Property == FrameworkElement.HeightProperty)
				{
					DataGridHelper.TransferProperty(this, FrameworkElement.HeightProperty);
				}
				else if (e.Property == DataGrid.MinRowHeightProperty || e.Property == FrameworkElement.MinHeightProperty)
				{
					DataGridHelper.TransferProperty(this, FrameworkElement.MinHeightProperty);
				}
				else if (e.Property == DataGrid.EnableColumnVirtualizationProperty)
				{
					DataGridHelper.TransferProperty(this, VirtualizingStackPanel.IsVirtualizingProperty);
				}
			}
			if (DataGridHelper.ShouldNotifyCells(target) || DataGridHelper.ShouldRefreshCellContent(target))
			{
				for (ContainerTracking<DataGridCell> containerTracking = this._cellTrackingRoot; containerTracking != null; containerTracking = containerTracking.Next)
				{
					containerTracking.Container.NotifyPropertyChanged(d, propertyName, e, target);
				}
			}
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0001618C File Offset: 0x0001438C
		protected override Size MeasureOverride(Size availableSize)
		{
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			if (dataGridRowOwner == null)
			{
				return base.MeasureOverride(availableSize);
			}
			DataGrid dataGridOwner = dataGridRowOwner.DataGridOwner;
			if (dataGridOwner == null)
			{
				return base.MeasureOverride(availableSize);
			}
			if (DataGridHelper.IsGridLineVisible(dataGridOwner, true))
			{
				double horizontalGridLineThickness = dataGridOwner.HorizontalGridLineThickness;
				Size result = base.MeasureOverride(DataGridHelper.SubtractFromSize(availableSize, horizontalGridLineThickness, true));
				result.Height += horizontalGridLineThickness;
				return result;
			}
			return base.MeasureOverride(availableSize);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x000161F4 File Offset: 0x000143F4
		protected override Size ArrangeOverride(Size finalSize)
		{
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			if (dataGridRowOwner == null)
			{
				return base.ArrangeOverride(finalSize);
			}
			DataGrid dataGridOwner = dataGridRowOwner.DataGridOwner;
			if (dataGridOwner == null)
			{
				return base.ArrangeOverride(finalSize);
			}
			if (DataGridHelper.IsGridLineVisible(dataGridOwner, true))
			{
				double horizontalGridLineThickness = dataGridOwner.HorizontalGridLineThickness;
				Size result = base.ArrangeOverride(DataGridHelper.SubtractFromSize(finalSize, horizontalGridLineThickness, true));
				result.Height += horizontalGridLineThickness;
				return result;
			}
			return base.ArrangeOverride(finalSize);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x0001625C File Offset: 0x0001445C
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			if (dataGridRowOwner == null)
			{
				return;
			}
			DataGrid dataGridOwner = dataGridRowOwner.DataGridOwner;
			if (dataGridOwner == null)
			{
				return;
			}
			if (DataGridHelper.IsGridLineVisible(dataGridOwner, true))
			{
				double horizontalGridLineThickness = dataGridOwner.HorizontalGridLineThickness;
				Rect rectangle = new Rect(new Size(base.RenderSize.Width, horizontalGridLineThickness));
				rectangle.Y = base.RenderSize.Height - horizontalGridLineThickness;
				drawingContext.DrawRectangle(dataGridOwner.HorizontalGridLinesBrush, null, rectangle);
			}
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x000162D8 File Offset: 0x000144D8
		private static void OnIsVirtualizingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGridCellsPresenter dataGridCellsPresenter = (DataGridCellsPresenter)d;
			DataGridHelper.TransferProperty(dataGridCellsPresenter, VirtualizingStackPanel.IsVirtualizingProperty);
			if (e.OldValue != dataGridCellsPresenter.GetValue(VirtualizingStackPanel.IsVirtualizingProperty))
			{
				dataGridCellsPresenter.InvalidateDataGridCellsPanelMeasureAndArrange();
			}
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00016314 File Offset: 0x00014514
		private static object OnCoerceIsVirtualizingProperty(DependencyObject d, object baseValue)
		{
			DataGridCellsPresenter dataGridCellsPresenter = d as DataGridCellsPresenter;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridCellsPresenter, baseValue, VirtualizingStackPanel.IsVirtualizingProperty, dataGridCellsPresenter.DataGridOwner, DataGrid.EnableColumnVirtualizationProperty);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x0001633F File Offset: 0x0001453F
		private void InvalidateDataGridCellsPanelMeasureAndArrange()
		{
			if (this._internalItemsHost != null)
			{
				this._internalItemsHost.InvalidateMeasure();
				this._internalItemsHost.InvalidateArrange();
			}
		}

		// Token: 0x06000598 RID: 1432 RVA: 0x0001635F File Offset: 0x0001455F
		private void InvalidateDataGridCellsPanelMeasureAndArrange(bool withColumnVirtualization)
		{
			if (withColumnVirtualization == VirtualizingStackPanel.GetIsVirtualizing(this))
			{
				this.InvalidateDataGridCellsPanelMeasureAndArrange();
			}
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x00016370 File Offset: 0x00014570
		// (set) Token: 0x0600059A RID: 1434 RVA: 0x00016378 File Offset: 0x00014578
		internal Panel InternalItemsHost
		{
			get
			{
				return this._internalItemsHost;
			}
			set
			{
				this._internalItemsHost = value;
			}
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00016384 File Offset: 0x00014584
		internal void ScrollCellIntoView(int index)
		{
			DataGridCellsPanel dataGridCellsPanel = this.InternalItemsHost as DataGridCellsPanel;
			if (dataGridCellsPanel != null)
			{
				dataGridCellsPanel.InternalBringIndexIntoView(index);
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x000163A8 File Offset: 0x000145A8
		private DataGrid DataGridOwner
		{
			get
			{
				DataGridRow dataGridRowOwner = this.DataGridRowOwner;
				if (dataGridRowOwner != null)
				{
					return dataGridRowOwner.DataGridOwner;
				}
				return null;
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x0600059D RID: 1437 RVA: 0x000163C7 File Offset: 0x000145C7
		internal DataGridRow DataGridRowOwner
		{
			get
			{
				return DataGridHelper.FindParent<DataGridRow>(this);
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x000163D0 File Offset: 0x000145D0
		private ObservableCollection<DataGridColumn> Columns
		{
			get
			{
				DataGridRow dataGridRowOwner = this.DataGridRowOwner;
				DataGrid dataGrid = (dataGridRowOwner != null) ? dataGridRowOwner.DataGridOwner : null;
				if (dataGrid == null)
				{
					return null;
				}
				return dataGrid.Columns;
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x000163FC File Offset: 0x000145FC
		internal ContainerTracking<DataGridCell> CellTrackingRoot
		{
			get
			{
				return this._cellTrackingRoot;
			}
		}

		// Token: 0x0400018D RID: 397
		private object _item;

		// Token: 0x0400018E RID: 398
		private ContainerTracking<DataGridCell> _cellTrackingRoot;

		// Token: 0x0400018F RID: 399
		private Panel _internalItemsHost;
	}
}

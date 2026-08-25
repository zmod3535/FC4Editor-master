using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Windows.Automation.Peers;
using MS.Internal;

namespace Microsoft.Windows.Controls.Primitives
{
	// Token: 0x02000063 RID: 99
	[TemplatePart(Name = "PART_FillerColumnHeader", Type = typeof(DataGridColumnHeader))]
	public class DataGridColumnHeadersPresenter : ItemsControl
	{
		// Token: 0x06000759 RID: 1881 RVA: 0x000212B0 File Offset: 0x0001F4B0
		static DataGridColumnHeadersPresenter()
		{
			Type typeFromHandle = typeof(DataGridColumnHeadersPresenter);
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(typeFromHandle));
			UIElement.FocusableProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(false));
			FrameworkElementFactory root = new FrameworkElementFactory(typeof(DataGridCellsPanel));
			ItemsControl.ItemsPanelProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(new ItemsPanelTemplate(root)));
			VirtualizingStackPanel.IsVirtualizingProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DataGridColumnHeadersPresenter.OnIsVirtualizingPropertyChanged), new CoerceValueCallback(DataGridColumnHeadersPresenter.OnCoerceIsVirtualizingProperty)));
			VirtualizingStackPanel.VirtualizationModeProperty.OverrideMetadata(typeFromHandle, new FrameworkPropertyMetadata(VirtualizationMode.Recycling));
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0002135C File Offset: 0x0001F55C
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			DataGrid parentDataGrid = this.ParentDataGrid;
			if (parentDataGrid != null)
			{
				base.ItemsSource = new ColumnHeaderCollection(parentDataGrid.Columns);
				parentDataGrid.ColumnHeadersPresenter = this;
				DataGridHelper.TransferProperty(this, VirtualizingStackPanel.IsVirtualizingProperty);
				DataGridColumnHeader dataGridColumnHeader = base.GetTemplateChild("PART_FillerColumnHeader") as DataGridColumnHeader;
				if (dataGridColumnHeader != null)
				{
					DataGridHelper.TransferProperty(dataGridColumnHeader, FrameworkElement.StyleProperty);
					DataGridHelper.TransferProperty(dataGridColumnHeader, FrameworkElement.HeightProperty);
					return;
				}
			}
			else
			{
				base.ItemsSource = null;
			}
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x000213CE File Offset: 0x0001F5CE
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new Microsoft.Windows.Automation.Peers.DataGridColumnHeadersPresenterAutomationPeer(this);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x000213D8 File Offset: 0x0001F5D8
		protected override Size MeasureOverride(Size availableSize)
		{
			Size size = availableSize;
			size.Width = double.PositiveInfinity;
			Size result = base.MeasureOverride(size);
			if (this._columnHeaderDragIndicator != null && this._isColumnHeaderDragging)
			{
				this._columnHeaderDragIndicator.Measure(size);
				Size desiredSize = this._columnHeaderDragIndicator.DesiredSize;
				result.Width = Math.Max(result.Width, desiredSize.Width);
				result.Height = Math.Max(result.Height, desiredSize.Height);
			}
			if (this._columnHeaderDropLocationIndicator != null && this._isColumnHeaderDragging)
			{
				this._columnHeaderDropLocationIndicator.Measure(availableSize);
				Size desiredSize = this._columnHeaderDropLocationIndicator.DesiredSize;
				result.Width = Math.Max(result.Width, desiredSize.Width);
				result.Height = Math.Max(result.Height, desiredSize.Height);
			}
			result.Width = Math.Min(availableSize.Width, result.Width);
			return result;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x000214D4 File Offset: 0x0001F6D4
		protected override Size ArrangeOverride(Size finalSize)
		{
			UIElement uielement = (VisualTreeHelper.GetChildrenCount(this) > 0) ? (VisualTreeHelper.GetChild(this, 0) as UIElement) : null;
			if (uielement != null)
			{
				Rect finalRect = new Rect(finalSize);
				DataGrid parentDataGrid = this.ParentDataGrid;
				if (parentDataGrid != null)
				{
					finalRect.X = -parentDataGrid.HorizontalScrollOffset;
					finalRect.Width = Math.Max(finalSize.Width, parentDataGrid.CellsPanelActualWidth);
				}
				uielement.Arrange(finalRect);
			}
			if (this._columnHeaderDragIndicator != null && this._isColumnHeaderDragging)
			{
				this._columnHeaderDragIndicator.Arrange(new Rect(new Point(this._columnHeaderDragCurrentPosition.X - this._columnHeaderDragStartRelativePosition.X, 0.0), new Size(this._columnHeaderDragIndicator.Width, this._columnHeaderDragIndicator.Height)));
			}
			if (this._columnHeaderDropLocationIndicator != null && this._isColumnHeaderDragging)
			{
				Point location = this.FindColumnHeaderPositionByCurrentPosition(this._columnHeaderDragCurrentPosition, true);
				double width = this._columnHeaderDropLocationIndicator.Width;
				location.X -= width * 0.5;
				this._columnHeaderDropLocationIndicator.Arrange(new Rect(location, new Size(width, this._columnHeaderDropLocationIndicator.Height)));
			}
			return finalSize;
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00021608 File Offset: 0x0001F808
		protected override Geometry GetLayoutClip(Size layoutSlotSize)
		{
			RectangleGeometry rectangleGeometry = new RectangleGeometry(new Rect(base.RenderSize));
			rectangleGeometry.Freeze();
			return rectangleGeometry;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x0002162D File Offset: 0x0001F82D
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new DataGridColumnHeader();
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00021634 File Offset: 0x0001F834
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is DataGridColumnHeader;
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x0002163F File Offset: 0x0001F83F
		internal bool IsItemItsOwnContainerInternal(object item)
		{
			return this.IsItemItsOwnContainerOverride(item);
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x00021648 File Offset: 0x0001F848
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			DataGridColumnHeader dataGridColumnHeader = element as DataGridColumnHeader;
			if (dataGridColumnHeader != null)
			{
				DataGridColumn column = this.ColumnFromContainer(dataGridColumnHeader);
				if (dataGridColumnHeader.Column == null)
				{
					dataGridColumnHeader.Tracker.StartTracking(ref this._headerTrackingRoot);
				}
				dataGridColumnHeader.PrepareColumnHeader(item, column);
			}
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00021688 File Offset: 0x0001F888
		protected override void ClearContainerForItemOverride(DependencyObject element, object item)
		{
			DataGridColumnHeader dataGridColumnHeader = element as DataGridColumnHeader;
			base.ClearContainerForItemOverride(element, item);
			if (dataGridColumnHeader != null)
			{
				dataGridColumnHeader.Tracker.StopTracking(ref this._headerTrackingRoot);
				dataGridColumnHeader.ClearHeader();
			}
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x000216C0 File Offset: 0x0001F8C0
		private DataGridColumn ColumnFromContainer(DataGridColumnHeader container)
		{
			int index = base.ItemContainerGenerator.IndexFromContainer(container);
			return this.HeaderCollection.ColumnFromIndex(index);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x000216E6 File Offset: 0x0001F8E6
		internal void NotifyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e, NotificationTarget target)
		{
			this.NotifyPropertyChanged(d, string.Empty, e, target);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x000216F8 File Offset: 0x0001F8F8
		internal void NotifyPropertyChanged(DependencyObject d, string propertyName, DependencyPropertyChangedEventArgs e, NotificationTarget target)
		{
			DataGridColumn dataGridColumn = d as DataGridColumn;
			if (DataGridHelper.ShouldNotifyColumnHeadersPresenter(target))
			{
				if (e.Property == DataGridColumn.WidthProperty || e.Property == DataGridColumn.DisplayIndexProperty)
				{
					if (dataGridColumn.IsVisible)
					{
						this.InvalidateDataGridCellsPanelMeasureAndArrange();
					}
				}
				else if (e.Property == DataGrid.FrozenColumnCountProperty || e.Property == DataGridColumn.VisibilityProperty || e.Property == DataGrid.CellsPanelHorizontalOffsetProperty || string.Compare(propertyName, "ViewportWidth", StringComparison.Ordinal) == 0 || string.Compare(propertyName, "DelayedColumnWidthComputation", StringComparison.Ordinal) == 0)
				{
					this.InvalidateDataGridCellsPanelMeasureAndArrange();
				}
				else if (e.Property == DataGrid.HorizontalScrollOffsetProperty)
				{
					base.InvalidateArrange();
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
				else if (e.Property == DataGrid.CellsPanelActualWidthProperty)
				{
					base.InvalidateArrange();
				}
				else if (e.Property == DataGrid.EnableColumnVirtualizationProperty)
				{
					DataGridHelper.TransferProperty(this, VirtualizingStackPanel.IsVirtualizingProperty);
				}
			}
			if (DataGridHelper.ShouldNotifyColumnHeaders(target))
			{
				if (e.Property == DataGridColumn.HeaderProperty)
				{
					if (this.HeaderCollection != null)
					{
						this.HeaderCollection.NotifyHeaderPropertyChanged(dataGridColumn, e);
						return;
					}
				}
				else
				{
					for (ContainerTracking<DataGridColumnHeader> containerTracking = this._headerTrackingRoot; containerTracking != null; containerTracking = containerTracking.Next)
					{
						containerTracking.Container.NotifyPropertyChanged(d, e);
					}
					if (d is DataGrid && (e.Property == DataGrid.ColumnHeaderStyleProperty || e.Property == DataGrid.ColumnHeaderHeightProperty))
					{
						DataGridColumnHeader dataGridColumnHeader = base.GetTemplateChild("PART_FillerColumnHeader") as DataGridColumnHeader;
						if (dataGridColumnHeader != null)
						{
							dataGridColumnHeader.NotifyPropertyChanged(d, e);
						}
					}
				}
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x000218A4 File Offset: 0x0001FAA4
		private static void OnIsVirtualizingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGridColumnHeadersPresenter dataGridColumnHeadersPresenter = (DataGridColumnHeadersPresenter)d;
			DataGridHelper.TransferProperty(dataGridColumnHeadersPresenter, VirtualizingStackPanel.IsVirtualizingProperty);
			if (e.OldValue != dataGridColumnHeadersPresenter.GetValue(VirtualizingStackPanel.IsVirtualizingProperty))
			{
				dataGridColumnHeadersPresenter.InvalidateDataGridCellsPanelMeasureAndArrange();
			}
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x000218E0 File Offset: 0x0001FAE0
		private static object OnCoerceIsVirtualizingProperty(DependencyObject d, object baseValue)
		{
			DataGridColumnHeadersPresenter dataGridColumnHeadersPresenter = d as DataGridColumnHeadersPresenter;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridColumnHeadersPresenter, baseValue, VirtualizingStackPanel.IsVirtualizingProperty, dataGridColumnHeadersPresenter.ParentDataGrid, DataGrid.EnableColumnVirtualizationProperty);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x0002190B File Offset: 0x0001FB0B
		private void InvalidateDataGridCellsPanelMeasureAndArrange()
		{
			if (this._internalItemsHost != null)
			{
				this._internalItemsHost.InvalidateMeasure();
				this._internalItemsHost.InvalidateArrange();
			}
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x0002192B File Offset: 0x0001FB2B
		private void InvalidateDataGridCellsPanelMeasureAndArrange(bool withColumnVirtualization)
		{
			if (withColumnVirtualization == VirtualizingStackPanel.GetIsVirtualizing(this))
			{
				this.InvalidateDataGridCellsPanelMeasureAndArrange();
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x0002193C File Offset: 0x0001FB3C
		// (set) Token: 0x0600076C RID: 1900 RVA: 0x00021944 File Offset: 0x0001FB44
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

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x0600076D RID: 1901 RVA: 0x00021950 File Offset: 0x0001FB50
		protected override int VisualChildrenCount
		{
			get
			{
				int num = base.VisualChildrenCount;
				if (this._columnHeaderDragIndicator != null)
				{
					num++;
				}
				if (this._columnHeaderDropLocationIndicator != null)
				{
					num++;
				}
				return num;
			}
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x00021980 File Offset: 0x0001FB80
		protected override Visual GetVisualChild(int index)
		{
			int visualChildrenCount = base.VisualChildrenCount;
			if (index == visualChildrenCount)
			{
				if (this._columnHeaderDragIndicator != null)
				{
					return this._columnHeaderDragIndicator;
				}
				if (this._columnHeaderDropLocationIndicator != null)
				{
					return this._columnHeaderDropLocationIndicator;
				}
			}
			if (index == visualChildrenCount + 1 && this._columnHeaderDragIndicator != null && this._columnHeaderDropLocationIndicator != null)
			{
				return this._columnHeaderDropLocationIndicator;
			}
			return base.GetVisualChild(index);
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x000219DC File Offset: 0x0001FBDC
		internal void OnHeaderMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			if (this.ParentDataGrid == null)
			{
				return;
			}
			if (this._columnHeaderDragIndicator != null)
			{
				base.RemoveVisualChild(this._columnHeaderDragIndicator);
				this._columnHeaderDragIndicator = null;
			}
			if (this._columnHeaderDropLocationIndicator != null)
			{
				base.RemoveVisualChild(this._columnHeaderDropLocationIndicator);
				this._columnHeaderDropLocationIndicator = null;
			}
			Point position = e.GetPosition(this);
			DataGridColumnHeader dataGridColumnHeader = this.FindColumnHeaderByPosition(position);
			if (dataGridColumnHeader != null)
			{
				DataGridColumn column = dataGridColumnHeader.Column;
				if (this.ParentDataGrid.CanUserReorderColumns && column.CanUserReorder)
				{
					this.PrepareColumnHeaderDrag(dataGridColumnHeader, e.GetPosition(this), e.GetPosition(dataGridColumnHeader));
					return;
				}
			}
			else
			{
				this._isColumnHeaderDragging = false;
				this._prepareColumnHeaderDragging = false;
				this._draggingSrcColumnHeader = null;
				base.InvalidateArrange();
			}
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x00021A88 File Offset: 0x0001FC88
		internal void OnHeaderMouseMove(MouseEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed && this._prepareColumnHeaderDragging)
			{
				this._columnHeaderDragCurrentPosition = e.GetPosition(this);
				if (!this._isColumnHeaderDragging)
				{
					if (DataGridColumnHeadersPresenter.CheckStartColumnHeaderDrag(this._columnHeaderDragCurrentPosition, this._columnHeaderDragStartPosition))
					{
						this.StartColumnHeaderDrag();
						return;
					}
				}
				else
				{
					Visibility visibility = this.IsMousePositionValidForColumnDrag(2.0) ? Visibility.Visible : Visibility.Collapsed;
					if (this._columnHeaderDragIndicator != null)
					{
						this._columnHeaderDragIndicator.Visibility = visibility;
					}
					if (this._columnHeaderDropLocationIndicator != null)
					{
						this._columnHeaderDropLocationIndicator.Visibility = visibility;
					}
					base.InvalidateArrange();
					DragDeltaEventArgs e2 = new DragDeltaEventArgs(this._columnHeaderDragCurrentPosition.X - this._columnHeaderDragStartPosition.X, this._columnHeaderDragCurrentPosition.Y - this._columnHeaderDragStartPosition.Y);
					this._columnHeaderDragStartPosition = this._columnHeaderDragCurrentPosition;
					this.ParentDataGrid.OnColumnHeaderDragDelta(e2);
				}
			}
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00021B70 File Offset: 0x0001FD70
		internal void OnHeaderMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			if (this._isColumnHeaderDragging)
			{
				this._columnHeaderDragCurrentPosition = e.GetPosition(this);
				this.FinishColumnHeaderDrag(false);
				return;
			}
			this.ClearColumnHeaderDragInfo();
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x00021B95 File Offset: 0x0001FD95
		internal void OnHeaderLostMouseCapture(MouseEventArgs e)
		{
			if (this._isColumnHeaderDragging && Mouse.LeftButton == MouseButtonState.Pressed)
			{
				this.FinishColumnHeaderDrag(true);
			}
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x00021BB0 File Offset: 0x0001FDB0
		private void ClearColumnHeaderDragInfo()
		{
			this._isColumnHeaderDragging = false;
			this._prepareColumnHeaderDragging = false;
			this._draggingSrcColumnHeader = null;
			if (this._columnHeaderDragIndicator != null)
			{
				base.RemoveVisualChild(this._columnHeaderDragIndicator);
				this._columnHeaderDragIndicator = null;
			}
			if (this._columnHeaderDropLocationIndicator != null)
			{
				base.RemoveVisualChild(this._columnHeaderDropLocationIndicator);
				this._columnHeaderDropLocationIndicator = null;
			}
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x00021C08 File Offset: 0x0001FE08
		private void PrepareColumnHeaderDrag(DataGridColumnHeader header, Point pos, Point relativePos)
		{
			this._prepareColumnHeaderDragging = true;
			this._isColumnHeaderDragging = false;
			this._draggingSrcColumnHeader = header;
			this._columnHeaderDragStartPosition = pos;
			this._columnHeaderDragStartRelativePosition = relativePos;
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00021C2D File Offset: 0x0001FE2D
		private static bool CheckStartColumnHeaderDrag(Point currentPos, Point originalPos)
		{
			return DoubleUtil.GreaterThan(Math.Abs(currentPos.X - originalPos.X), SystemParameters.MinimumHorizontalDragDistance);
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00021C50 File Offset: 0x0001FE50
		private bool IsMousePositionValidForColumnDrag(double dragFactor)
		{
			int num = -1;
			return this.IsMousePositionValidForColumnDrag(dragFactor, out num);
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00021C68 File Offset: 0x0001FE68
		private bool IsMousePositionValidForColumnDrag(double dragFactor, out int nearestDisplayIndex)
		{
			nearestDisplayIndex = -1;
			bool flag = false;
			if (this._draggingSrcColumnHeader.Column != null)
			{
				flag = this._draggingSrcColumnHeader.Column.IsFrozen;
			}
			int num = 0;
			if (this.ParentDataGrid != null)
			{
				num = this.ParentDataGrid.FrozenColumnCount;
			}
			nearestDisplayIndex = this.FindDisplayIndexByPosition(this._columnHeaderDragCurrentPosition, true);
			if (flag && nearestDisplayIndex >= num)
			{
				return false;
			}
			if (!flag && nearestDisplayIndex < num)
			{
				return false;
			}
			double num2;
			if (this._columnHeaderDragIndicator == null)
			{
				num2 = this._draggingSrcColumnHeader.RenderSize.Height;
			}
			else
			{
				num2 = Math.Max(this._draggingSrcColumnHeader.RenderSize.Height, this._columnHeaderDragIndicator.Height);
			}
			return DoubleUtil.LessThanOrClose(-num2 * dragFactor, this._columnHeaderDragCurrentPosition.Y) && DoubleUtil.LessThanOrClose(this._columnHeaderDragCurrentPosition.Y, num2 * (dragFactor + 1.0));
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x00021D54 File Offset: 0x0001FF54
		private void StartColumnHeaderDrag()
		{
			this._columnHeaderDragStartPosition = this._columnHeaderDragCurrentPosition;
			DragStartedEventArgs e = new DragStartedEventArgs(this._columnHeaderDragStartPosition.X, this._columnHeaderDragStartPosition.Y);
			this.ParentDataGrid.OnColumnHeaderDragStarted(e);
			DataGridColumnReorderingEventArgs dataGridColumnReorderingEventArgs = new DataGridColumnReorderingEventArgs(this._draggingSrcColumnHeader.Column);
			this._columnHeaderDragIndicator = this.CreateColumnHeaderDragIndicator();
			this._columnHeaderDropLocationIndicator = this.CreateColumnHeaderDropIndicator();
			dataGridColumnReorderingEventArgs.DragIndicator = this._columnHeaderDragIndicator;
			dataGridColumnReorderingEventArgs.DropLocationIndicator = this._columnHeaderDropLocationIndicator;
			this.ParentDataGrid.OnColumnReordering(dataGridColumnReorderingEventArgs);
			if (!dataGridColumnReorderingEventArgs.Cancel)
			{
				this._isColumnHeaderDragging = true;
				this._columnHeaderDragIndicator = dataGridColumnReorderingEventArgs.DragIndicator;
				this._columnHeaderDropLocationIndicator = dataGridColumnReorderingEventArgs.DropLocationIndicator;
				if (this._columnHeaderDragIndicator != null)
				{
					this.SetDefaultsOnDragIndicator();
					base.AddVisualChild(this._columnHeaderDragIndicator);
				}
				if (this._columnHeaderDropLocationIndicator != null)
				{
					this.SetDefaultsOnDropIndicator();
					base.AddVisualChild(this._columnHeaderDropLocationIndicator);
				}
				this._draggingSrcColumnHeader.SuppressClickEvent = true;
				base.InvalidateMeasure();
				return;
			}
			this.FinishColumnHeaderDrag(true);
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x00021E58 File Offset: 0x00020058
		private Control CreateColumnHeaderDragIndicator()
		{
			return new DataGridColumnFloatingHeader
			{
				ReferenceHeader = this._draggingSrcColumnHeader
			};
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x00021E78 File Offset: 0x00020078
		private void SetDefaultsOnDragIndicator()
		{
			DataGridColumn column = this._draggingSrcColumnHeader.Column;
			Style style = null;
			if (column != null)
			{
				style = column.DragIndicatorStyle;
			}
			this._columnHeaderDragIndicator.Style = style;
			this._columnHeaderDragIndicator.CoerceValue(FrameworkElement.WidthProperty);
			this._columnHeaderDragIndicator.CoerceValue(FrameworkElement.HeightProperty);
		}

		// Token: 0x0600077B RID: 1915 RVA: 0x00021ECC File Offset: 0x000200CC
		private Control CreateColumnHeaderDropIndicator()
		{
			return new DataGridColumnDropSeparator
			{
				ReferenceHeader = this._draggingSrcColumnHeader
			};
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00021EEC File Offset: 0x000200EC
		private void SetDefaultsOnDropIndicator()
		{
			Style style = null;
			if (this.ParentDataGrid != null)
			{
				style = this.ParentDataGrid.DropLocationIndicatorStyle;
			}
			this._columnHeaderDropLocationIndicator.Style = style;
			this._columnHeaderDropLocationIndicator.CoerceValue(FrameworkElement.WidthProperty);
			this._columnHeaderDropLocationIndicator.CoerceValue(FrameworkElement.HeightProperty);
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00021F3C File Offset: 0x0002013C
		private void FinishColumnHeaderDrag(bool isCancel)
		{
			this._prepareColumnHeaderDragging = false;
			this._isColumnHeaderDragging = false;
			this._draggingSrcColumnHeader.SuppressClickEvent = false;
			if (this._columnHeaderDragIndicator != null)
			{
				this._columnHeaderDragIndicator.Visibility = Visibility.Collapsed;
				DataGridColumnFloatingHeader dataGridColumnFloatingHeader = this._columnHeaderDragIndicator as DataGridColumnFloatingHeader;
				if (dataGridColumnFloatingHeader != null)
				{
					dataGridColumnFloatingHeader.ClearHeader();
				}
				base.RemoveVisualChild(this._columnHeaderDragIndicator);
			}
			if (this._columnHeaderDropLocationIndicator != null)
			{
				this._columnHeaderDropLocationIndicator.Visibility = Visibility.Collapsed;
				DataGridColumnDropSeparator dataGridColumnDropSeparator = this._columnHeaderDropLocationIndicator as DataGridColumnDropSeparator;
				if (dataGridColumnDropSeparator != null)
				{
					dataGridColumnDropSeparator.ReferenceHeader = null;
				}
				base.RemoveVisualChild(this._columnHeaderDropLocationIndicator);
			}
			DragCompletedEventArgs e = new DragCompletedEventArgs(this._columnHeaderDragCurrentPosition.X - this._columnHeaderDragStartPosition.X, this._columnHeaderDragCurrentPosition.Y - this._columnHeaderDragStartPosition.Y, isCancel);
			this.ParentDataGrid.OnColumnHeaderDragCompleted(e);
			this._draggingSrcColumnHeader.InvalidateArrange();
			if (!isCancel)
			{
				int num = -1;
				bool flag = this.IsMousePositionValidForColumnDrag(2.0, out num);
				DataGridColumn column = this._draggingSrcColumnHeader.Column;
				if (column != null && flag && num != column.DisplayIndex)
				{
					column.DisplayIndex = num;
					DataGridColumnEventArgs e2 = new DataGridColumnEventArgs(this._draggingSrcColumnHeader.Column);
					this.ParentDataGrid.OnColumnReordered(e2);
				}
			}
			this._draggingSrcColumnHeader = null;
			this._columnHeaderDragIndicator = null;
			this._columnHeaderDropLocationIndicator = null;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x00022090 File Offset: 0x00020290
		private int FindDisplayIndexByPosition(Point startPos, bool findNearestColumn)
		{
			int result;
			Point point;
			DataGridColumnHeader dataGridColumnHeader;
			this.FindDisplayIndexAndHeaderPosition(startPos, findNearestColumn, out result, out point, out dataGridColumnHeader);
			return result;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x000220AC File Offset: 0x000202AC
		private DataGridColumnHeader FindColumnHeaderByPosition(Point startPos)
		{
			int num;
			Point point;
			DataGridColumnHeader result;
			this.FindDisplayIndexAndHeaderPosition(startPos, false, out num, out point, out result);
			return result;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x000220C8 File Offset: 0x000202C8
		private Point FindColumnHeaderPositionByCurrentPosition(Point startPos, bool findNearestColumn)
		{
			int num;
			Point result;
			DataGridColumnHeader dataGridColumnHeader;
			this.FindDisplayIndexAndHeaderPosition(startPos, findNearestColumn, out num, out result, out dataGridColumnHeader);
			return result;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x000220E4 File Offset: 0x000202E4
		private static double GetColumnEstimatedWidth(DataGridColumn column, double averageColumnWidth)
		{
			double num = column.Width.DisplayValue;
			if (DoubleUtil.IsNaN(num))
			{
				num = Math.Max(averageColumnWidth, column.MinWidth);
				num = Math.Min(num, column.MaxWidth);
			}
			return num;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x00022124 File Offset: 0x00020324
		private void FindDisplayIndexAndHeaderPosition(Point startPos, bool findNearestColumn, out int displayIndex, out Point headerPos, out DataGridColumnHeader header)
		{
			Point point = new Point(0.0, 0.0);
			headerPos = point;
			displayIndex = -1;
			header = null;
			if (startPos.X < 0.0)
			{
				if (findNearestColumn)
				{
					displayIndex = 0;
				}
				return;
			}
			double num = 0.0;
			double num2 = 0.0;
			DataGrid parentDataGrid = this.ParentDataGrid;
			double averageColumnWidth = parentDataGrid.InternalColumns.AverageColumnWidth;
			bool flag = false;
			int i = 0;
			while (i < parentDataGrid.Columns.Count)
			{
				displayIndex++;
				DataGridColumnHeader dataGridColumnHeader = parentDataGrid.ColumnHeaderFromDisplayIndex(i);
				if (dataGridColumnHeader != null)
				{
					GeneralTransform generalTransform = dataGridColumnHeader.TransformToAncestor(this);
					num = generalTransform.Transform(point).X;
					num2 = num + dataGridColumnHeader.RenderSize.Width;
					goto IL_FB;
				}
				DataGridColumn dataGridColumn = parentDataGrid.ColumnFromDisplayIndex(i);
				if (dataGridColumn.IsVisible)
				{
					num = num2;
					if (i >= parentDataGrid.FrozenColumnCount && !flag)
					{
						num -= parentDataGrid.HorizontalScrollOffset;
						flag = true;
					}
					num2 = num + DataGridColumnHeadersPresenter.GetColumnEstimatedWidth(dataGridColumn, averageColumnWidth);
					goto IL_FB;
				}
				IL_18D:
				i++;
				continue;
				IL_FB:
				if (DoubleUtil.LessThanOrClose(startPos.X, num))
				{
					break;
				}
				if (!DoubleUtil.GreaterThanOrClose(startPos.X, num) || !DoubleUtil.LessThanOrClose(startPos.X, num2))
				{
					goto IL_18D;
				}
				if (!findNearestColumn)
				{
					header = dataGridColumnHeader;
					break;
				}
				double value = (num + num2) * 0.5;
				if (DoubleUtil.GreaterThanOrClose(startPos.X, value))
				{
					num = num2;
					displayIndex++;
				}
				if (this._draggingSrcColumnHeader != null && this._draggingSrcColumnHeader.Column != null && this._draggingSrcColumnHeader.Column.DisplayIndex < displayIndex)
				{
					displayIndex--;
					break;
				}
				break;
			}
			if (i == parentDataGrid.Columns.Count)
			{
				displayIndex = parentDataGrid.Columns.Count - 1;
				num = num2;
			}
			headerPos.X = num;
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x000222FD File Offset: 0x000204FD
		private ColumnHeaderCollection HeaderCollection
		{
			get
			{
				return base.ItemsSource as ColumnHeaderCollection;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x0002230A File Offset: 0x0002050A
		internal DataGrid ParentDataGrid
		{
			get
			{
				if (this._parentDataGrid == null)
				{
					this._parentDataGrid = DataGridHelper.FindParent<DataGrid>(this);
				}
				return this._parentDataGrid;
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x00022326 File Offset: 0x00020526
		internal ContainerTracking<DataGridColumnHeader> HeaderTrackingRoot
		{
			get
			{
				return this._headerTrackingRoot;
			}
		}

		// Token: 0x04000259 RID: 601
		private const string ElementFillerColumnHeader = "PART_FillerColumnHeader";

		// Token: 0x0400025A RID: 602
		private ContainerTracking<DataGridColumnHeader> _headerTrackingRoot;

		// Token: 0x0400025B RID: 603
		private DataGrid _parentDataGrid;

		// Token: 0x0400025C RID: 604
		private bool _prepareColumnHeaderDragging;

		// Token: 0x0400025D RID: 605
		private bool _isColumnHeaderDragging;

		// Token: 0x0400025E RID: 606
		private DataGridColumnHeader _draggingSrcColumnHeader;

		// Token: 0x0400025F RID: 607
		private Point _columnHeaderDragStartPosition;

		// Token: 0x04000260 RID: 608
		private Point _columnHeaderDragStartRelativePosition;

		// Token: 0x04000261 RID: 609
		private Point _columnHeaderDragCurrentPosition;

		// Token: 0x04000262 RID: 610
		private Control _columnHeaderDropLocationIndicator;

		// Token: 0x04000263 RID: 611
		private Control _columnHeaderDragIndicator;

		// Token: 0x04000264 RID: 612
		private Panel _internalItemsHost;
	}
}

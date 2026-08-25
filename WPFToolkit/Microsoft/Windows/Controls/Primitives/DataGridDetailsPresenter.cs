using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Windows.Automation.Peers;

namespace Microsoft.Windows.Controls.Primitives
{
	// Token: 0x0200000B RID: 11
	public class DataGridDetailsPresenter : ContentPresenter
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00004794 File Offset: 0x00002994
		static DataGridDetailsPresenter()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridDetailsPresenter), new FrameworkPropertyMetadata(typeof(DataGridDetailsPresenter)));
			ContentPresenter.ContentTemplateProperty.OverrideMetadata(typeof(DataGridDetailsPresenter), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridDetailsPresenter.OnNotifyPropertyChanged), new CoerceValueCallback(DataGridDetailsPresenter.OnCoerceContentTemplate)));
			ContentPresenter.ContentTemplateSelectorProperty.OverrideMetadata(typeof(DataGridDetailsPresenter), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridDetailsPresenter.OnNotifyPropertyChanged), new CoerceValueCallback(DataGridDetailsPresenter.OnCoerceContentTemplateSelector)));
			EventManager.RegisterClassHandler(typeof(DataGridDetailsPresenter), UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(DataGridDetailsPresenter.OnAnyMouseLeftButtonDownThunk), true);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000484F File Offset: 0x00002A4F
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new Microsoft.Windows.Automation.Peers.DataGridDetailsPresenterAutomationPeer(this);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004858 File Offset: 0x00002A58
		private static object OnCoerceContentTemplate(DependencyObject d, object baseValue)
		{
			DataGridDetailsPresenter dataGridDetailsPresenter = d as DataGridDetailsPresenter;
			DataGridRow dataGridRowOwner = dataGridDetailsPresenter.DataGridRowOwner;
			DataGrid grandParentObject = (dataGridRowOwner != null) ? dataGridRowOwner.DataGridOwner : null;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridDetailsPresenter, baseValue, ContentPresenter.ContentTemplateProperty, dataGridRowOwner, DataGridRow.DetailsTemplateProperty, grandParentObject, DataGrid.RowDetailsTemplateProperty);
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00004898 File Offset: 0x00002A98
		private static object OnCoerceContentTemplateSelector(DependencyObject d, object baseValue)
		{
			DataGridDetailsPresenter dataGridDetailsPresenter = d as DataGridDetailsPresenter;
			DataGridRow dataGridRowOwner = dataGridDetailsPresenter.DataGridRowOwner;
			DataGrid grandParentObject = (dataGridRowOwner != null) ? dataGridRowOwner.DataGridOwner : null;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridDetailsPresenter, baseValue, ContentPresenter.ContentTemplateSelectorProperty, dataGridRowOwner, DataGridRow.DetailsTemplateSelectorProperty, grandParentObject, DataGrid.RowDetailsTemplateSelectorProperty);
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000048D8 File Offset: 0x00002AD8
		protected override void OnVisualParentChanged(DependencyObject oldParent)
		{
			base.OnVisualParentChanged(oldParent);
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			if (dataGridRowOwner != null)
			{
				dataGridRowOwner.DetailsPresenter = this;
				this.SyncProperties();
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00004903 File Offset: 0x00002B03
		private bool IsInVisualSubTree(DependencyObject visual)
		{
			while (visual != null)
			{
				if (visual == this)
				{
					return true;
				}
				visual = VisualTreeHelper.GetParent(visual);
			}
			return false;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00004919 File Offset: 0x00002B19
		private static void OnAnyMouseLeftButtonDownThunk(object sender, MouseButtonEventArgs e)
		{
			((DataGridDetailsPresenter)sender).OnAnyMouseLeftButtonDown(e);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004928 File Offset: 0x00002B28
		private void OnAnyMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			if (!this.IsInVisualSubTree(e.OriginalSource as DependencyObject))
			{
				return;
			}
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			DataGrid dataGrid = (dataGridRowOwner != null) ? dataGridRowOwner.DataGridOwner : null;
			if (dataGrid != null && dataGridRowOwner != null)
			{
				if (dataGrid.CurrentCell.Item != dataGridRowOwner.Item)
				{
					dataGrid.ScrollIntoView(dataGridRowOwner.Item, dataGrid.ColumnFromDisplayIndex(0));
				}
				dataGrid.HandleSelectionForRowHeaderAndDetailsInput(dataGridRowOwner, Mouse.Captured == null);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x0000499C File Offset: 0x00002B9C
		internal FrameworkElement DetailsElement
		{
			get
			{
				int childrenCount = VisualTreeHelper.GetChildrenCount(this);
				if (childrenCount > 0)
				{
					return VisualTreeHelper.GetChild(this, 0) as FrameworkElement;
				}
				return null;
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000049C4 File Offset: 0x00002BC4
		internal void SyncProperties()
		{
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			base.Content = ((dataGridRowOwner != null) ? dataGridRowOwner.Item : null);
			DataGridHelper.TransferProperty(this, ContentPresenter.ContentTemplateProperty);
			DataGridHelper.TransferProperty(this, ContentPresenter.ContentTemplateSelectorProperty);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004A00 File Offset: 0x00002C00
		private static void OnNotifyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGridDetailsPresenter)d).NotifyPropertyChanged(d, e);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00004A10 File Offset: 0x00002C10
		internal void NotifyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.Property == DataGrid.RowDetailsTemplateProperty || e.Property == DataGridRow.DetailsTemplateProperty || e.Property == ContentPresenter.ContentTemplateProperty)
			{
				DataGridHelper.TransferProperty(this, ContentPresenter.ContentTemplateProperty);
				return;
			}
			if (e.Property == DataGrid.RowDetailsTemplateSelectorProperty || e.Property == DataGridRow.DetailsTemplateSelectorProperty || e.Property == ContentPresenter.ContentTemplateSelectorProperty)
			{
				DataGridHelper.TransferProperty(this, ContentPresenter.ContentTemplateSelectorProperty);
			}
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004A88 File Offset: 0x00002C88
		protected override Size MeasureOverride(Size availableSize)
		{
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			DataGrid dataGridOwner = dataGridRowOwner.DataGridOwner;
			if (dataGridRowOwner.DetailsPresenterDrawsGridLines && DataGridHelper.IsGridLineVisible(dataGridOwner, true))
			{
				double horizontalGridLineThickness = dataGridOwner.HorizontalGridLineThickness;
				Size result = base.MeasureOverride(DataGridHelper.SubtractFromSize(availableSize, horizontalGridLineThickness, true));
				result.Height += horizontalGridLineThickness;
				return result;
			}
			return base.MeasureOverride(availableSize);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004AE4 File Offset: 0x00002CE4
		protected override Size ArrangeOverride(Size finalSize)
		{
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			DataGrid dataGridOwner = dataGridRowOwner.DataGridOwner;
			if (dataGridRowOwner.DetailsPresenterDrawsGridLines && DataGridHelper.IsGridLineVisible(dataGridOwner, true))
			{
				double horizontalGridLineThickness = dataGridOwner.HorizontalGridLineThickness;
				Size result = base.ArrangeOverride(DataGridHelper.SubtractFromSize(finalSize, horizontalGridLineThickness, true));
				result.Height += horizontalGridLineThickness;
				return result;
			}
			return base.ArrangeOverride(finalSize);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004B40 File Offset: 0x00002D40
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			DataGridRow dataGridRowOwner = this.DataGridRowOwner;
			DataGrid dataGridOwner = dataGridRowOwner.DataGridOwner;
			if (dataGridRowOwner.DetailsPresenterDrawsGridLines && DataGridHelper.IsGridLineVisible(dataGridOwner, true))
			{
				double horizontalGridLineThickness = dataGridOwner.HorizontalGridLineThickness;
				Rect rectangle = new Rect(new Size(base.RenderSize.Width, horizontalGridLineThickness));
				rectangle.Y = base.RenderSize.Height - horizontalGridLineThickness;
				drawingContext.DrawRectangle(dataGridOwner.HorizontalGridLinesBrush, null, rectangle);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00004BBC File Offset: 0x00002DBC
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

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00004BDB File Offset: 0x00002DDB
		internal DataGridRow DataGridRowOwner
		{
			get
			{
				return DataGridHelper.FindParent<DataGridRow>(this);
			}
		}
	}
}

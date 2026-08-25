using System;
using System.ComponentModel;
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
	// Token: 0x02000083 RID: 131
	[TemplatePart(Name = "PART_TopHeaderGripper", Type = typeof(Thumb))]
	[TemplatePart(Name = "PART_BottomHeaderGripper", Type = typeof(Thumb))]
	public class DataGridRowHeader : ButtonBase
	{
		// Token: 0x0600090E RID: 2318 RVA: 0x00028570 File Offset: 0x00026770
		static DataGridRowHeader()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridRowHeader), new FrameworkPropertyMetadata(typeof(DataGridRowHeader)));
			ContentControl.ContentProperty.OverrideMetadata(typeof(DataGridRowHeader), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridRowHeader.OnNotifyPropertyChanged), new CoerceValueCallback(DataGridRowHeader.OnCoerceContent)));
			ContentControl.ContentTemplateProperty.OverrideMetadata(typeof(DataGridRowHeader), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridRowHeader.OnNotifyPropertyChanged), new CoerceValueCallback(DataGridRowHeader.OnCoerceContentTemplate)));
			ContentControl.ContentTemplateSelectorProperty.OverrideMetadata(typeof(DataGridRowHeader), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridRowHeader.OnNotifyPropertyChanged), new CoerceValueCallback(DataGridRowHeader.OnCoerceContentTemplateSelector)));
			FrameworkElement.StyleProperty.OverrideMetadata(typeof(DataGridRowHeader), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridRowHeader.OnNotifyPropertyChanged), new CoerceValueCallback(DataGridRowHeader.OnCoerceStyle)));
			FrameworkElement.WidthProperty.OverrideMetadata(typeof(DataGridRowHeader), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridRowHeader.OnNotifyPropertyChanged), new CoerceValueCallback(DataGridRowHeader.OnCoerceWidth)));
			ButtonBase.ClickModeProperty.OverrideMetadata(typeof(DataGridRowHeader), new FrameworkPropertyMetadata(ClickMode.Press));
			UIElement.FocusableProperty.OverrideMetadata(typeof(DataGridRowHeader), new FrameworkPropertyMetadata(false));
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00028774 File Offset: 0x00026974
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new Microsoft.Windows.Automation.Peers.DataGridRowHeaderAutomationPeer(this);
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x0002877C File Offset: 0x0002697C
		// (set) Token: 0x06000911 RID: 2321 RVA: 0x0002878E File Offset: 0x0002698E
		public Brush SeparatorBrush
		{
			get
			{
				return (Brush)base.GetValue(DataGridRowHeader.SeparatorBrushProperty);
			}
			set
			{
				base.SetValue(DataGridRowHeader.SeparatorBrushProperty, value);
			}
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x0002879C File Offset: 0x0002699C
		// (set) Token: 0x06000913 RID: 2323 RVA: 0x000287AE File Offset: 0x000269AE
		public Visibility SeparatorVisibility
		{
			get
			{
				return (Visibility)base.GetValue(DataGridRowHeader.SeparatorVisibilityProperty);
			}
			set
			{
				base.SetValue(DataGridRowHeader.SeparatorVisibilityProperty, value);
			}
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x000287C4 File Offset: 0x000269C4
		protected override Size MeasureOverride(Size availableSize)
		{
			Size result = base.MeasureOverride(availableSize);
			DataGrid dataGridOwner = this.DataGridOwner;
			if (dataGridOwner == null)
			{
				return result;
			}
			if (DoubleUtil.IsNaN(dataGridOwner.RowHeaderWidth) && result.Width > dataGridOwner.RowHeaderActualWidth)
			{
				dataGridOwner.RowHeaderActualWidth = result.Width;
			}
			return new Size(dataGridOwner.RowHeaderActualWidth, result.Height);
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00028820 File Offset: 0x00026A20
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			DataGridRow parentRow = this.ParentRow;
			if (parentRow != null)
			{
				parentRow.RowHeader = this;
				this.SyncProperties();
			}
			this.HookupGripperEvents();
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00028850 File Offset: 0x00026A50
		internal void SyncProperties()
		{
			DataGridHelper.TransferProperty(this, ContentControl.ContentProperty);
			DataGridHelper.TransferProperty(this, FrameworkElement.StyleProperty);
			DataGridHelper.TransferProperty(this, ContentControl.ContentTemplateProperty);
			DataGridHelper.TransferProperty(this, ContentControl.ContentTemplateSelectorProperty);
			DataGridHelper.TransferProperty(this, FrameworkElement.WidthProperty);
			base.CoerceValue(DataGridRowHeader.IsRowSelectedProperty);
			this.OnCanUserResizeRowsChanged();
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x000288A5 File Offset: 0x00026AA5
		private static void OnNotifyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((DataGridRowHeader)d).NotifyPropertyChanged(d, e);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x000288B4 File Offset: 0x00026AB4
		internal void NotifyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (e.Property == DataGridRow.HeaderProperty || e.Property == ContentControl.ContentProperty)
			{
				DataGridHelper.TransferProperty(this, ContentControl.ContentProperty);
				return;
			}
			if (e.Property == DataGrid.RowHeaderStyleProperty || e.Property == DataGridRow.HeaderStyleProperty || e.Property == FrameworkElement.StyleProperty)
			{
				DataGridHelper.TransferProperty(this, FrameworkElement.StyleProperty);
				return;
			}
			if (e.Property == DataGrid.RowHeaderTemplateProperty || e.Property == DataGridRow.HeaderTemplateProperty || e.Property == ContentControl.ContentTemplateProperty)
			{
				DataGridHelper.TransferProperty(this, ContentControl.ContentTemplateProperty);
				return;
			}
			if (e.Property == DataGrid.RowHeaderTemplateSelectorProperty || e.Property == DataGridRow.HeaderTemplateSelectorProperty || e.Property == ContentControl.ContentTemplateSelectorProperty)
			{
				DataGridHelper.TransferProperty(this, ContentControl.ContentTemplateSelectorProperty);
				return;
			}
			if (e.Property == DataGrid.RowHeaderWidthProperty || e.Property == FrameworkElement.WidthProperty)
			{
				DataGridHelper.TransferProperty(this, FrameworkElement.WidthProperty);
				return;
			}
			if (e.Property == DataGridRow.IsSelectedProperty)
			{
				base.CoerceValue(DataGridRowHeader.IsRowSelectedProperty);
				return;
			}
			if (e.Property == DataGrid.CanUserResizeRowsProperty)
			{
				this.OnCanUserResizeRowsChanged();
				return;
			}
			if (e.Property == DataGrid.RowHeaderActualWidthProperty)
			{
				base.InvalidateMeasure();
				base.InvalidateArrange();
				UIElement uielement = base.Parent as UIElement;
				if (uielement != null)
				{
					uielement.InvalidateMeasure();
					uielement.InvalidateArrange();
				}
			}
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00028A18 File Offset: 0x00026C18
		private static object OnCoerceContent(DependencyObject d, object baseValue)
		{
			DataGridRowHeader dataGridRowHeader = d as DataGridRowHeader;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRowHeader, baseValue, ContentControl.ContentProperty, dataGridRowHeader.ParentRow, DataGridRow.HeaderProperty);
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00028A44 File Offset: 0x00026C44
		private static object OnCoerceContentTemplate(DependencyObject d, object baseValue)
		{
			DataGridRowHeader dataGridRowHeader = d as DataGridRowHeader;
			DataGridRow parentRow = dataGridRowHeader.ParentRow;
			DataGrid grandParentObject = (parentRow != null) ? parentRow.DataGridOwner : null;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRowHeader, baseValue, ContentControl.ContentTemplateProperty, parentRow, DataGridRow.HeaderTemplateProperty, grandParentObject, DataGrid.RowHeaderTemplateProperty);
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00028A84 File Offset: 0x00026C84
		private static object OnCoerceContentTemplateSelector(DependencyObject d, object baseValue)
		{
			DataGridRowHeader dataGridRowHeader = d as DataGridRowHeader;
			DataGridRow parentRow = dataGridRowHeader.ParentRow;
			DataGrid grandParentObject = (parentRow != null) ? parentRow.DataGridOwner : null;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRowHeader, baseValue, ContentControl.ContentTemplateSelectorProperty, parentRow, DataGridRow.HeaderTemplateSelectorProperty, grandParentObject, DataGrid.RowHeaderTemplateSelectorProperty);
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00028AC4 File Offset: 0x00026CC4
		private static object OnCoerceStyle(DependencyObject d, object baseValue)
		{
			DataGridRowHeader dataGridRowHeader = d as DataGridRowHeader;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRowHeader, baseValue, FrameworkElement.StyleProperty, dataGridRowHeader.ParentRow, DataGridRow.HeaderStyleProperty, dataGridRowHeader.DataGridOwner, DataGrid.RowHeaderStyleProperty);
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00028AFC File Offset: 0x00026CFC
		private static object OnCoerceWidth(DependencyObject d, object baseValue)
		{
			DataGridRowHeader dataGridRowHeader = d as DataGridRowHeader;
			return DataGridHelper.GetCoercedTransferPropertyValue(dataGridRowHeader, baseValue, FrameworkElement.WidthProperty, dataGridRowHeader.DataGridOwner, DataGrid.RowHeaderWidthProperty);
		}

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x0600091E RID: 2334 RVA: 0x00028B27 File Offset: 0x00026D27
		[Bindable(true)]
		[Category("Appearance")]
		public bool IsRowSelected
		{
			get
			{
				return (bool)base.GetValue(DataGridRowHeader.IsRowSelectedProperty);
			}
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00028B3C File Offset: 0x00026D3C
		private static object OnCoerceIsRowSelected(DependencyObject d, object baseValue)
		{
			DataGridRowHeader dataGridRowHeader = (DataGridRowHeader)d;
			DataGridRow parentRow = dataGridRowHeader.ParentRow;
			if (parentRow != null)
			{
				return parentRow.IsSelected;
			}
			return baseValue;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00028B68 File Offset: 0x00026D68
		protected override void OnClick()
		{
			base.OnClick();
			if (Mouse.Captured == this)
			{
				base.ReleaseMouseCapture();
			}
			DataGrid dataGridOwner = this.DataGridOwner;
			DataGridRow parentRow = this.ParentRow;
			if (dataGridOwner != null && parentRow != null)
			{
				dataGridOwner.HandleSelectionForRowHeaderAndDetailsInput(parentRow, true);
			}
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00028BA8 File Offset: 0x00026DA8
		private void HookupGripperEvents()
		{
			this.UnhookGripperEvents();
			this._topGripper = (base.GetTemplateChild("PART_TopHeaderGripper") as Thumb);
			this._bottomGripper = (base.GetTemplateChild("PART_BottomHeaderGripper") as Thumb);
			if (this._topGripper != null)
			{
				this._topGripper.DragStarted += this.OnRowHeaderGripperDragStarted;
				this._topGripper.DragDelta += this.OnRowHeaderResize;
				this._topGripper.DragCompleted += this.OnRowHeaderGripperDragCompleted;
				this._topGripper.MouseDoubleClick += this.OnGripperDoubleClicked;
				this.SetTopGripperVisibility();
			}
			if (this._bottomGripper != null)
			{
				this._bottomGripper.DragStarted += this.OnRowHeaderGripperDragStarted;
				this._bottomGripper.DragDelta += this.OnRowHeaderResize;
				this._bottomGripper.DragCompleted += this.OnRowHeaderGripperDragCompleted;
				this._bottomGripper.MouseDoubleClick += this.OnGripperDoubleClicked;
				this.SetBottomGripperVisibility();
			}
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00028CBC File Offset: 0x00026EBC
		private void UnhookGripperEvents()
		{
			if (this._topGripper != null)
			{
				this._topGripper.DragStarted -= this.OnRowHeaderGripperDragStarted;
				this._topGripper.DragDelta -= this.OnRowHeaderResize;
				this._topGripper.DragCompleted -= this.OnRowHeaderGripperDragCompleted;
				this._topGripper.MouseDoubleClick -= this.OnGripperDoubleClicked;
				this._topGripper = null;
			}
			if (this._bottomGripper != null)
			{
				this._bottomGripper.DragStarted -= this.OnRowHeaderGripperDragStarted;
				this._bottomGripper.DragDelta -= this.OnRowHeaderResize;
				this._bottomGripper.DragCompleted -= this.OnRowHeaderGripperDragCompleted;
				this._bottomGripper.MouseDoubleClick -= this.OnGripperDoubleClicked;
				this._bottomGripper = null;
			}
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00028DA0 File Offset: 0x00026FA0
		private void SetTopGripperVisibility()
		{
			if (this._topGripper != null)
			{
				DataGrid dataGridOwner = this.DataGridOwner;
				DataGridRow parentRow = this.ParentRow;
				if (dataGridOwner != null && parentRow != null && dataGridOwner.CanUserResizeRows && dataGridOwner.Items.Count > 1 && !object.ReferenceEquals(parentRow.Item, dataGridOwner.Items[0]))
				{
					this._topGripper.Visibility = Visibility.Visible;
					return;
				}
				this._topGripper.Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00028E14 File Offset: 0x00027014
		private void SetBottomGripperVisibility()
		{
			if (this._bottomGripper != null)
			{
				DataGrid dataGridOwner = this.DataGridOwner;
				if (dataGridOwner != null && dataGridOwner.CanUserResizeRows)
				{
					this._bottomGripper.Visibility = Visibility.Visible;
					return;
				}
				this._bottomGripper.Visibility = Visibility.Collapsed;
			}
		}

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x00028E54 File Offset: 0x00027054
		private DataGridRow PreviousRow
		{
			get
			{
				DataGridRow parentRow = this.ParentRow;
				if (parentRow != null)
				{
					DataGrid dataGridOwner = parentRow.DataGridOwner;
					if (dataGridOwner != null)
					{
						int num = dataGridOwner.ItemContainerGenerator.IndexFromContainer(parentRow);
						if (num > 0)
						{
							return (DataGridRow)dataGridOwner.ItemContainerGenerator.ContainerFromIndex(num - 1);
						}
					}
				}
				return null;
			}
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00028E9B File Offset: 0x0002709B
		private DataGridRow RowToResize(object gripper)
		{
			if (gripper != this._bottomGripper)
			{
				return this.PreviousRow;
			}
			return this.ParentRow;
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00028EB4 File Offset: 0x000270B4
		private void OnRowHeaderGripperDragStarted(object sender, DragStartedEventArgs e)
		{
			DataGridRow dataGridRow = this.RowToResize(sender);
			if (dataGridRow != null)
			{
				dataGridRow.OnRowResizeStarted();
				e.Handled = true;
			}
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00028EDC File Offset: 0x000270DC
		private void OnRowHeaderResize(object sender, DragDeltaEventArgs e)
		{
			DataGridRow dataGridRow = this.RowToResize(sender);
			if (dataGridRow != null)
			{
				dataGridRow.OnRowResize(e.VerticalChange);
				e.Handled = true;
			}
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00028F08 File Offset: 0x00027108
		private void OnRowHeaderGripperDragCompleted(object sender, DragCompletedEventArgs e)
		{
			DataGridRow dataGridRow = this.RowToResize(sender);
			if (dataGridRow != null)
			{
				dataGridRow.OnRowResizeCompleted(e.Canceled);
				e.Handled = true;
			}
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00028F34 File Offset: 0x00027134
		private void OnGripperDoubleClicked(object sender, MouseButtonEventArgs e)
		{
			DataGridRow dataGridRow = this.RowToResize(sender);
			if (dataGridRow != null)
			{
				dataGridRow.OnRowResizeReset();
				e.Handled = true;
			}
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00028F59 File Offset: 0x00027159
		private void OnCanUserResizeRowsChanged()
		{
			this.SetTopGripperVisibility();
			this.SetBottomGripperVisibility();
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x00028F67 File Offset: 0x00027167
		internal DataGridRow ParentRow
		{
			get
			{
				return DataGridHelper.FindParent<DataGridRow>(this);
			}
		}

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x00028F70 File Offset: 0x00027170
		private DataGrid DataGridOwner
		{
			get
			{
				DataGridRow parentRow = this.ParentRow;
				if (parentRow != null)
				{
					return parentRow.DataGridOwner;
				}
				return null;
			}
		}

		// Token: 0x040002C5 RID: 709
		private const string TopHeaderGripperTemplateName = "PART_TopHeaderGripper";

		// Token: 0x040002C6 RID: 710
		private const string BottomHeaderGripperTemplateName = "PART_BottomHeaderGripper";

		// Token: 0x040002C7 RID: 711
		public static readonly DependencyProperty SeparatorBrushProperty = DependencyProperty.Register("SeparatorBrush", typeof(Brush), typeof(DataGridRowHeader), new FrameworkPropertyMetadata(null));

		// Token: 0x040002C8 RID: 712
		public static readonly DependencyProperty SeparatorVisibilityProperty = DependencyProperty.Register("SeparatorVisibility", typeof(Visibility), typeof(DataGridRowHeader), new FrameworkPropertyMetadata(Visibility.Visible));

		// Token: 0x040002C9 RID: 713
		private static readonly DependencyPropertyKey IsRowSelectedPropertyKey = DependencyProperty.RegisterReadOnly("IsRowSelected", typeof(bool), typeof(DataGridRowHeader), new FrameworkPropertyMetadata(false, null, new CoerceValueCallback(DataGridRowHeader.OnCoerceIsRowSelected)));

		// Token: 0x040002CA RID: 714
		public static readonly DependencyProperty IsRowSelectedProperty = DataGridRowHeader.IsRowSelectedPropertyKey.DependencyProperty;

		// Token: 0x040002CB RID: 715
		private Thumb _topGripper;

		// Token: 0x040002CC RID: 716
		private Thumb _bottomGripper;
	}
}

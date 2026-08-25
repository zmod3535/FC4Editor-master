using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x0200001B RID: 27
	public class ResizeControlSplitter : Thumb
	{
		// Token: 0x06000219 RID: 537 RVA: 0x00038E60 File Offset: 0x00037260
		static ResizeControlSplitter()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(ResizeControlSplitter), new FrameworkPropertyMetadata(typeof(ResizeControlSplitter)));
			EventManager.RegisterClassHandler(typeof(ResizeControlSplitter), Thumb.DragStartedEvent, new DragStartedEventHandler(ResizeControlSplitter.OnDragStarted));
			EventManager.RegisterClassHandler(typeof(ResizeControlSplitter), Thumb.DragDeltaEvent, new DragDeltaEventHandler(ResizeControlSplitter.OnDragDelta));
			EventManager.RegisterClassHandler(typeof(ResizeControlSplitter), Thumb.DragCompletedEvent, new DragCompletedEventHandler(ResizeControlSplitter.OnDragCompleted));
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00038F34 File Offset: 0x00037334
		internal ResizeControlSplitter(DockSite dockSite, SplitContainer resizeControl)
		{
			this.dockSite = dockSite;
			this.resizeControl = resizeControl;
			if (resizeControl != null)
			{
				this.UpdateCursor();
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x0600021B RID: 539 RVA: 0x00038F54 File Offset: 0x00037354
		// (set) Token: 0x0600021C RID: 540 RVA: 0x00038F68 File Offset: 0x00037368
		public double Size
		{
			get
			{
				return (double)base.GetValue(ResizeControlSplitter.SizeProperty);
			}
			set
			{
				base.SetValue(ResizeControlSplitter.SizeProperty, value);
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00038F7C File Offset: 0x0003737C
		private static bool OnValidateSize(object value)
		{
			return (double)value >= 0.0;
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x0600021E RID: 542 RVA: 0x00038F94 File Offset: 0x00037394
		public SplitContainer ResizeControl
		{
			get
			{
				return this.resizeControl;
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00038F9C File Offset: 0x0003739C
		internal void UpdateCursor()
		{
			switch (DockSite.GetDock(this.resizeControl))
			{
			case Dock.Left:
			case Dock.Right:
				base.Cursor = Cursors.SizeWE;
				return;
			case Dock.Top:
			case Dock.Bottom:
				base.Cursor = Cursors.SizeNS;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00038FE4 File Offset: 0x000373E4
		protected override Size MeasureOverride(Size constraint)
		{
			return new Size(this.Size, this.Size);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00038FF8 File Offset: 0x000373F8
		private static void OnDragStarted(object sender, DragStartedEventArgs e)
		{
			(sender as ResizeControlSplitter).OnDragStarted(e);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00039008 File Offset: 0x00037408
		private static void OnDragDelta(object sender, DragDeltaEventArgs e)
		{
			(sender as ResizeControlSplitter).OnDragDelta(e);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00039018 File Offset: 0x00037418
		private static void OnDragCompleted(object sender, DragCompletedEventArgs e)
		{
			(sender as ResizeControlSplitter).OnDragCompleted(e);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00039028 File Offset: 0x00037428
		private void OnDragCompleted(DragCompletedEventArgs e)
		{
			if (this.resizeData != null)
			{
				if (!e.Canceled)
				{
					if (this.resizeData.x0c6349882676bcd6 == Dock.Right)
					{
						this.resizeData.xb424e41094667807.ContentSize = Math.Max(this.resizeData.xb424e41094667807.ContentSize - this.resizeData.xb4186eb3ba442529.OffsetX, 15.0);
					}
					else if (this.resizeData.x0c6349882676bcd6 == Dock.Left)
					{
						this.resizeData.xb424e41094667807.ContentSize = Math.Max(this.resizeData.xb424e41094667807.ContentSize + this.resizeData.xb4186eb3ba442529.OffsetX, 15.0);
					}
					else if (this.resizeData.x0c6349882676bcd6 == Dock.Top)
					{
						this.resizeData.xb424e41094667807.ContentSize = Math.Max(this.resizeData.xb424e41094667807.ContentSize + this.resizeData.xb4186eb3ba442529.OffsetY, 15.0);
					}
					else if (this.resizeData.x0c6349882676bcd6 == Dock.Bottom)
					{
						this.resizeData.xb424e41094667807.ContentSize = Math.Max(this.resizeData.xb424e41094667807.ContentSize - this.resizeData.xb4186eb3ba442529.OffsetY, 15.0);
					}
				}
				(VisualTreeHelper.GetParent(this.resizeData.xb4186eb3ba442529) as AdornerLayer).Remove(this.resizeData.xb4186eb3ba442529);
				this.resizeData = null;
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000391B8 File Offset: 0x000375B8
		private void OnDragDelta(DragDeltaEventArgs e)
		{
			if (this.resizeData != null)
			{
				double horizontalChange = e.HorizontalChange;
				double verticalChange = e.VerticalChange;
				if (this.resizeData.x0c6349882676bcd6 == Dock.Right || this.resizeData.x0c6349882676bcd6 == Dock.Left)
				{
					this.resizeData.xb4186eb3ba442529.OffsetX = Math.Max(Math.Min(horizontalChange, this.resizeData.xbf668cc6cab48980), this.resizeData.x65922b505b5cb658);
					return;
				}
				this.resizeData.xb4186eb3ba442529.OffsetY = Math.Max(Math.Min(verticalChange, this.resizeData.xbf668cc6cab48980), this.resizeData.x65922b505b5cb658);
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0003925C File Offset: 0x0003765C
		private void OnDragStarted(DragStartedEventArgs e)
		{
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.resizeControl);
			if (adornerLayer != null)
			{
				this.resizeData = new ResizeControlSplitter.xb03ec0ad616d13fe();
				this.resizeData.x0c6349882676bcd6 = DockSite.GetDock(this.resizeControl);
				this.resizeData.xb424e41094667807 = this.resizeControl;
				switch (this.resizeData.x0c6349882676bcd6)
				{
				case Dock.Left:
					this.resizeData.x65922b505b5cb658 = 15.0 - this.resizeControl.ContentSize;
					this.resizeData.xbf668cc6cab48980 = this.dockSite.ClientBounds.Width - 32.0;
					break;
				case Dock.Top:
					this.resizeData.x65922b505b5cb658 = 15.0 - this.resizeControl.ContentSize;
					this.resizeData.xbf668cc6cab48980 = this.dockSite.ClientBounds.Height - 32.0;
					break;
				case Dock.Right:
					this.resizeData.xbf668cc6cab48980 = this.resizeControl.ContentSize - 15.0;
					this.resizeData.x65922b505b5cb658 = 32.0 - this.dockSite.ClientBounds.Width;
					break;
				case Dock.Bottom:
					this.resizeData.xbf668cc6cab48980 = this.resizeControl.ContentSize - 15.0;
					this.resizeData.x65922b505b5cb658 = 32.0 - this.dockSite.ClientBounds.Height;
					break;
				}
				this.resizeData.xb4186eb3ba442529 = new SplitPreviewAdorner(this, null);
				adornerLayer.Add(this.resizeData.xb4186eb3ba442529);
			}
		}

		// Token: 0x040000AC RID: 172
		public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(double), typeof(ResizeControlSplitter), new FrameworkPropertyMetadata(4.0, FrameworkPropertyMetadataOptions.AffectsMeasure), new ValidateValueCallback(ResizeControlSplitter.OnValidateSize));

		// Token: 0x040000AD RID: 173
		private DockSite dockSite;

		// Token: 0x040000AE RID: 174
		private SplitContainer resizeControl;

		// Token: 0x040000AF RID: 175
		private ResizeControlSplitter.xb03ec0ad616d13fe resizeData;

		// Token: 0x0200001C RID: 28
		private class xb03ec0ad616d13fe
		{
			// Token: 0x040000B0 RID: 176
			public Dock x0c6349882676bcd6;

			// Token: 0x040000B1 RID: 177
			public SplitContainer xb424e41094667807;

			// Token: 0x040000B2 RID: 178
			public SplitPreviewAdorner xb4186eb3ba442529;

			// Token: 0x040000B3 RID: 179
			public double xbf668cc6cab48980;

			// Token: 0x040000B4 RID: 180
			public double x65922b505b5cb658;
		}
	}
}

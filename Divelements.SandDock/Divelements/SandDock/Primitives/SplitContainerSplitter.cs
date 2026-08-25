using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x0200002C RID: 44
	public class SplitContainerSplitter : Thumb
	{
		// Token: 0x060002D2 RID: 722 RVA: 0x0003CC48 File Offset: 0x0003B048
		static SplitContainerSplitter()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitContainerSplitter), new FrameworkPropertyMetadata(typeof(SplitContainerSplitter)));
			EventManager.RegisterClassHandler(typeof(SplitContainerSplitter), Thumb.DragStartedEvent, new DragStartedEventHandler(SplitContainerSplitter.OnDragStarted));
			EventManager.RegisterClassHandler(typeof(SplitContainerSplitter), Thumb.DragDeltaEvent, new DragDeltaEventHandler(SplitContainerSplitter.OnDragDelta));
			EventManager.RegisterClassHandler(typeof(SplitContainerSplitter), Thumb.DragCompletedEvent, new DragCompletedEventHandler(SplitContainerSplitter.OnDragCompleted));
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0003CD1C File Offset: 0x0003B11C
		internal SplitContainerSplitter(FrameworkElement beforeElement, FrameworkElement afterElement, Orientation splitterOrientation)
		{
			this.beforeElement = beforeElement;
			this.afterElement = afterElement;
			this.splitterOrientation = splitterOrientation;
			base.Cursor = ((splitterOrientation == Orientation.Horizontal) ? Cursors.SizeNS : Cursors.SizeWE);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0003CD50 File Offset: 0x0003B150
		protected override Size MeasureOverride(Size constraint)
		{
			return new Size(this.Size, this.Size);
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002D5 RID: 725 RVA: 0x0003CD64 File Offset: 0x0003B164
		public Orientation Orientation
		{
			get
			{
				return this.splitterOrientation;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002D6 RID: 726 RVA: 0x0003CD6C File Offset: 0x0003B16C
		public FrameworkElement BeforeElement
		{
			get
			{
				return this.beforeElement;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002D7 RID: 727 RVA: 0x0003CD74 File Offset: 0x0003B174
		public FrameworkElement AfterElement
		{
			get
			{
				return this.afterElement;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002D8 RID: 728 RVA: 0x0003CD7C File Offset: 0x0003B17C
		// (set) Token: 0x060002D9 RID: 729 RVA: 0x0003CD90 File Offset: 0x0003B190
		internal double Size
		{
			get
			{
				return (double)base.GetValue(SplitContainerSplitter.SizeProperty);
			}
			set
			{
				base.SetValue(SplitContainerSplitter.SizeProperty, value);
			}
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0003CDA4 File Offset: 0x0003B1A4
		private static bool OnValidateSize(object value)
		{
			return (double)value >= 0.0;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0003CDBC File Offset: 0x0003B1BC
		private static void OnDragStarted(object sender, DragStartedEventArgs e)
		{
			(sender as SplitContainerSplitter).OnDragStarted(e);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0003CDCC File Offset: 0x0003B1CC
		private static void OnDragDelta(object sender, DragDeltaEventArgs e)
		{
			(sender as SplitContainerSplitter).OnDragDelta(e);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0003CDDC File Offset: 0x0003B1DC
		private static void OnDragCompleted(object sender, DragCompletedEventArgs e)
		{
			(sender as SplitContainerSplitter).OnDragCompleted(e);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0003CDEC File Offset: 0x0003B1EC
		private void OnDragCompleted(DragCompletedEventArgs e)
		{
			if (this.resizeData != null)
			{
				if (!e.Canceled)
				{
					Size workingSize = SplitContainer.GetWorkingSize(this.beforeElement);
					Size workingSize2 = SplitContainer.GetWorkingSize(this.afterElement);
					double num = this.resizeData.xfe230f2edec87929 + this.resizeData.x6e45ae9f762efa5e;
					if (this.splitterOrientation == Orientation.Horizontal)
					{
						double num2 = workingSize.Height + workingSize2.Height;
						double num3 = this.resizeData.xb4186eb3ba442529.OffsetY / num * num2;
						SplitContainer.SetWorkingSize(this.beforeElement, new Size(workingSize.Width, workingSize.Height + num3));
						SplitContainer.SetWorkingSize(this.afterElement, new Size(workingSize2.Width, workingSize2.Height - num3));
					}
					else
					{
						double num4 = workingSize.Width + workingSize2.Width;
						double num5 = this.resizeData.xb4186eb3ba442529.OffsetX / num * num4;
						SplitContainer.SetWorkingSize(this.beforeElement, new Size(workingSize.Width + num5, workingSize.Height));
						SplitContainer.SetWorkingSize(this.afterElement, new Size(workingSize2.Width - num5, workingSize2.Height));
					}
				}
				(VisualTreeHelper.GetParent(this.resizeData.xb4186eb3ba442529) as AdornerLayer).Remove(this.resizeData.xb4186eb3ba442529);
				this.resizeData = null;
			}
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0003CF48 File Offset: 0x0003B348
		private void OnDragDelta(DragDeltaEventArgs e)
		{
			if (this.resizeData != null)
			{
				double horizontalChange = e.HorizontalChange;
				double verticalChange = e.VerticalChange;
				if (this.splitterOrientation == Orientation.Vertical)
				{
					this.resizeData.xb4186eb3ba442529.OffsetX = Math.Min(Math.Max(horizontalChange, -this.resizeData.x562d346851b5beb3), this.resizeData.x3f29d5a2b3794a3b);
					return;
				}
				this.resizeData.xb4186eb3ba442529.OffsetY = Math.Min(Math.Max(verticalChange, -this.resizeData.x562d346851b5beb3), this.resizeData.x3f29d5a2b3794a3b);
			}
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0003CFDC File Offset: 0x0003B3DC
		private void OnDragStarted(DragStartedEventArgs e)
		{
			SplitContainer splitContainer = base.VisualParent as SplitContainer;
			AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(splitContainer);
			if (splitContainer != null && adornerLayer != null)
			{
				this.resizeData = new SplitContainerSplitter.xb03ec0ad616d13fe();
				this.resizeData.xd301f1060b3751dc = splitContainer;
				this.resizeData.xfe230f2edec87929 = ((this.splitterOrientation == Orientation.Horizontal) ? LayoutInformation.GetLayoutSlot(this.beforeElement).Height : LayoutInformation.GetLayoutSlot(this.beforeElement).Width);
				this.resizeData.x6e45ae9f762efa5e = ((this.splitterOrientation == Orientation.Horizontal) ? LayoutInformation.GetLayoutSlot(this.afterElement).Height : LayoutInformation.GetLayoutSlot(this.afterElement).Width);
				this.resizeData.x562d346851b5beb3 = this.resizeData.xfe230f2edec87929 - 22.0;
				this.resizeData.x3f29d5a2b3794a3b = this.resizeData.x6e45ae9f762efa5e - 22.0;
				this.resizeData.xb4186eb3ba442529 = new SplitPreviewAdorner(this, null);
				adornerLayer.Add(this.resizeData.xb4186eb3ba442529);
			}
		}

		// Token: 0x040000FE RID: 254
		internal static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(double), typeof(SplitContainerSplitter), new FrameworkPropertyMetadata(4.0, FrameworkPropertyMetadataOptions.AffectsMeasure), new ValidateValueCallback(SplitContainerSplitter.OnValidateSize));

		// Token: 0x040000FF RID: 255
		private FrameworkElement beforeElement;

		// Token: 0x04000100 RID: 256
		private FrameworkElement afterElement;

		// Token: 0x04000101 RID: 257
		private Orientation splitterOrientation;

		// Token: 0x04000102 RID: 258
		private SplitContainerSplitter.xb03ec0ad616d13fe resizeData;

		// Token: 0x0200002D RID: 45
		private class xb03ec0ad616d13fe
		{
			// Token: 0x04000103 RID: 259
			public SplitContainer xd301f1060b3751dc;

			// Token: 0x04000104 RID: 260
			public SplitPreviewAdorner xb4186eb3ba442529;

			// Token: 0x04000105 RID: 261
			public double x562d346851b5beb3;

			// Token: 0x04000106 RID: 262
			public double x3f29d5a2b3794a3b;

			// Token: 0x04000107 RID: 263
			public double xfe230f2edec87929;

			// Token: 0x04000108 RID: 264
			public double x6e45ae9f762efa5e;
		}
	}
}

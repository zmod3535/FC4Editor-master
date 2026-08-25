using System;
using System.Windows;
using System.Windows.Media;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x0200003E RID: 62
	internal class PositionPreview : FrameworkElement
	{
		// Token: 0x06000387 RID: 903 RVA: 0x00040454 File Offset: 0x0003E854
		public PositionPreview()
		{
		}

		// Token: 0x06000388 RID: 904 RVA: 0x00040464 File Offset: 0x0003E864
		public PositionPreview(WindowGroup sourceWindowGroup)
		{
			this.elementGhost = new x702c550d0cd841b4(sourceWindowGroup);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00040480 File Offset: 0x0003E880
		public PositionPreview(DockableWindow sourceWindow)
		{
			this.elementGhost = new x702c550d0cd841b4(sourceWindow);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0004049C File Offset: 0x0003E89C
		public PositionPreview(SplitContainer sourceSplitContainer)
		{
			this.elementGhost = new x702c550d0cd841b4(sourceSplitContainer);
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x0600038B RID: 907 RVA: 0x000404B8 File Offset: 0x0003E8B8
		// (set) Token: 0x0600038C RID: 908 RVA: 0x000404C0 File Offset: 0x0003E8C0
		public x4025ca48d3c65c4e PreviewType
		{
			get
			{
				return this.previewType;
			}
			set
			{
				if (value != this.previewType)
				{
					this.previewType = value;
					if (this.elementGhost != null)
					{
						this.elementGhost.x6f6877b222ed4153 = (value == x4025ca48d3c65c4e.x0c60a6a0825c8336);
					}
					base.InvalidateVisual();
				}
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x000404F0 File Offset: 0x0003E8F0
		protected override Size ArrangeOverride(Size finalSize)
		{
			if (this.elementGhost != null)
			{
				this.elementGhost.x437e3b626c0fdd43 = finalSize;
			}
			return base.ArrangeOverride(finalSize);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00040510 File Offset: 0x0003E910
		protected override void OnRender(DrawingContext drawingContext)
		{
			Brush brush = base.TryFindResource(new ComponentResourceKey(typeof(RenderingElement), RenderingElement.DockPreviewBackgroundBrush)) as Brush;
			Rect rect;
			if (true)
			{
				Brush brush2 = base.TryFindResource(new ComponentResourceKey(typeof(RenderingElement), RenderingElement.DockPreviewBorderBrush)) as Brush;
				if (brush != null && brush2 != null)
				{
					Pen pen = new Pen(brush2, 2.0);
					rect = new Rect(0.0, 0.0, base.RenderSize.Width, base.RenderSize.Height);
					rect.Inflate(-pen.Thickness / 2.0, -pen.Thickness / 2.0);
					switch (this.PreviewType)
					{
					case x4025ca48d3c65c4e.x0c60a6a0825c8336:
					case x4025ca48d3c65c4e.xa86c909b890c3d62:
						if (this.elementGhost != null)
						{
							goto IL_29;
						}
						drawingContext.DrawRectangle(brush, pen, rect);
						return;
					case x4025ca48d3c65c4e.xa2111e6282321fd1:
						drawingContext.DrawRectangle(brush, pen, rect);
						break;
					case x4025ca48d3c65c4e.x52cffb079963bcb2:
						if (base.RenderSize.Width >= 80.0 && base.RenderSize.Height >= 24.0 && true)
						{
							this.RenderTabGeometry(drawingContext, rect, brush, pen);
							return;
						}
						drawingContext.DrawRectangle(brush, pen, rect);
						return;
					default:
						return;
					}
				}
				return;
			}
			IL_29:
			drawingContext.PushOpacity(0.9);
			drawingContext.DrawRectangle(this.elementGhost.x60465f602599d327, null, rect);
			drawingContext.Pop();
		}

		// Token: 0x0600038F RID: 911 RVA: 0x000406A8 File Offset: 0x0003EAA8
		private void RenderTabGeometry(DrawingContext drawingContext, Rect bounds, Brush backgroundBrush, Pen borderPen)
		{
			PathGeometry geometry = new PathGeometry(new PathFigure[]
			{
				new PathFigure(new Point(bounds.Left, bounds.Top), new PathSegment[]
				{
					new LineSegment(new Point(bounds.Right, bounds.Top), true),
					new LineSegment(new Point(bounds.Right, bounds.Bottom - 24.0), true),
					new LineSegment(new Point(70.0, bounds.Bottom - 24.0), true),
					new LineSegment(new Point(70.0, bounds.Bottom), true),
					new LineSegment(new Point(10.0, bounds.Bottom), true),
					new LineSegment(new Point(10.0, bounds.Bottom - 24.0), true),
					new LineSegment(new Point(bounds.Left, bounds.Bottom - 24.0), true)
				}, true)
			});
			drawingContext.DrawGeometry(backgroundBrush, borderPen, geometry);
		}

		// Token: 0x0400015B RID: 347
		private x4025ca48d3c65c4e previewType = x4025ca48d3c65c4e.xa86c909b890c3d62;

		// Token: 0x0400015C RID: 348
		private x702c550d0cd841b4 elementGhost;
	}
}

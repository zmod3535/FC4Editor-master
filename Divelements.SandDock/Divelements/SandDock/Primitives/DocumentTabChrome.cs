using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000075 RID: 117
	public class DocumentTabChrome : Decorator
	{
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x00047D60 File Offset: 0x00046160
		// (set) Token: 0x060004CA RID: 1226 RVA: 0x00047D74 File Offset: 0x00046174
		public Thickness Padding
		{
			get
			{
				return (Thickness)base.GetValue(DocumentTabChrome.PaddingProperty);
			}
			set
			{
				base.SetValue(DocumentTabChrome.PaddingProperty, value);
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x00047D88 File Offset: 0x00046188
		// (set) Token: 0x060004CC RID: 1228 RVA: 0x00047D9C File Offset: 0x0004619C
		public Brush Background
		{
			get
			{
				return (Brush)base.GetValue(DocumentTabChrome.BackgroundProperty);
			}
			set
			{
				base.SetValue(DocumentTabChrome.BackgroundProperty, value);
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x00047DAC File Offset: 0x000461AC
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x00047DC0 File Offset: 0x000461C0
		public Brush BorderBrush
		{
			get
			{
				return (Brush)base.GetValue(DocumentTabChrome.BorderBrushProperty);
			}
			set
			{
				base.SetValue(DocumentTabChrome.BorderBrushProperty, value);
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00047DD0 File Offset: 0x000461D0
		// (set) Token: 0x060004D0 RID: 1232 RVA: 0x00047DE4 File Offset: 0x000461E4
		public Brush InnerBorderBrush
		{
			get
			{
				return (Brush)base.GetValue(DocumentTabChrome.InnerBorderBrushProperty);
			}
			set
			{
				base.SetValue(DocumentTabChrome.InnerBorderBrushProperty, value);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x00047DF4 File Offset: 0x000461F4
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x00047E08 File Offset: 0x00046208
		public bool IsSelected
		{
			get
			{
				return (bool)base.GetValue(DocumentTabChrome.IsSelectedProperty);
			}
			set
			{
				base.SetValue(DocumentTabChrome.IsSelectedProperty, value);
			}
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00047E1C File Offset: 0x0004621C
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			if (base.ActualWidth < base.ActualHeight + 7.0)
			{
				return;
			}
			if (this.IsSelected)
			{
				drawingContext.PushClip(new RectangleGeometry(new Rect(0.0, 0.0, base.RenderSize.Width, base.RenderSize.Height)));
			}
			else
			{
				drawingContext.PushClip(new RectangleGeometry(new Rect(0.0, 0.0, base.RenderSize.Width, base.RenderSize.Height - 1.0)));
			}
			Rect bounds = new Rect(0.0, 0.0, base.RenderSize.Width, base.RenderSize.Height);
			drawingContext.DrawGeometry(this.Background, null, this.CreatePath(bounds, true, this.IsSelected));
			if (this.BorderBrush != null)
			{
				Pen pen = new Pen(this.BorderBrush, 1.0);
				drawingContext.DrawGeometry(null, pen, this.CreatePath(bounds, false, false));
			}
			if (this.InnerBorderBrush != null)
			{
				bounds.X += 1.0;
				bounds.Y += 1.0;
				bounds.Width -= 2.0;
				bounds.Height -= 1.0;
				Pen pen2 = new Pen(this.InnerBorderBrush, 1.0);
				drawingContext.DrawGeometry(null, pen2, this.CreatePath(bounds, false, false));
			}
			drawingContext.Pop();
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00047FF0 File Offset: 0x000463F0
		private PathGeometry CreatePath(Rect bounds, bool forFilling, bool selected)
		{
			PathGeometry pathGeometry = new PathGeometry();
			double num = selected ? (bounds.Bottom + 1.0) : bounds.Bottom;
			if (forFilling)
			{
				pathGeometry.Figures.Add(new PathFigure(new Point(bounds.Left, num), new PathSegment[]
				{
					new LineSegment(new Point(Math.Min(bounds.Left + bounds.Height - 3.0, bounds.Right), bounds.Top + 3.0), true),
					new LineSegment(new Point(Math.Min(bounds.Left + bounds.Height, bounds.Right), bounds.Top + 1.5), true),
					new LineSegment(new Point(Math.Min(bounds.Left + bounds.Height + 3.0, bounds.Right), bounds.Top), true),
					new LineSegment(new Point(Math.Max(bounds.Right - 4.0, 0.0), bounds.Top), true),
					new ArcSegment(new Point(bounds.Right, bounds.Top + 4.0), new Size(3.5, 3.5), 0.0, false, SweepDirection.Clockwise, true),
					new LineSegment(new Point(bounds.Right, num), true)
				}, false));
			}
			else
			{
				pathGeometry.Figures.Add(new PathFigure(new Point(bounds.Left + 0.5, num - 0.5), new PathSegment[]
				{
					new LineSegment(new Point(Math.Min(bounds.Left + 0.5 + bounds.Height - 3.0, bounds.Right), bounds.Top + 3.5), true),
					new LineSegment(new Point(Math.Min(bounds.Left + 0.5 + bounds.Height, bounds.Right), bounds.Top + 1.5), true),
					new LineSegment(new Point(Math.Min(bounds.Left + bounds.Height + 3.0, bounds.Right), bounds.Top + 0.5), true),
					new LineSegment(new Point(Math.Max(bounds.Right - 4.0, 0.0), bounds.Top + 0.5), true),
					new ArcSegment(new Point(bounds.Right - 0.5, bounds.Top + 4.0), new Size(3.5, 3.5), 0.0, false, SweepDirection.Clockwise, true),
					new LineSegment(new Point(bounds.Right - 0.5, num - 0.5), true)
				}, false));
			}
			return pathGeometry;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00048368 File Offset: 0x00046768
		protected override Size ArrangeOverride(Size arrangeSize)
		{
			Rect finalRect = default(Rect);
			finalRect.X = Math.Min(arrangeSize.Height, arrangeSize.Width);
			finalRect.Y = Math.Min(this.Padding.Top, arrangeSize.Height);
			finalRect.Width = Math.Max(0.0, arrangeSize.Width - (this.Padding.Left + this.Padding.Right) - arrangeSize.Height);
			finalRect.Height = Math.Max(0.0, arrangeSize.Height - (this.Padding.Top + this.Padding.Bottom));
			if (this.Child != null)
			{
				this.Child.Arrange(finalRect);
			}
			return arrangeSize;
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x0004844C File Offset: 0x0004684C
		protected override Size MeasureOverride(Size constraint)
		{
			if (this.Child != null)
			{
				Size availableSize = constraint;
				availableSize.Width = Math.Max(0.0, availableSize.Width - (this.Padding.Left + this.Padding.Right));
				availableSize.Height = Math.Max(0.0, availableSize.Height - (this.Padding.Top + this.Padding.Bottom));
				this.Child.Measure(availableSize);
				Size desiredSize = this.Child.DesiredSize;
				desiredSize.Width += this.Padding.Left + this.Padding.Right;
				desiredSize.Height += this.Padding.Top + this.Padding.Bottom;
				desiredSize.Width += desiredSize.Height - this.Padding.Left;
				return desiredSize;
			}
			return base.MeasureOverride(constraint);
		}

		// Token: 0x0400028E RID: 654
		public static readonly DependencyProperty BackgroundProperty = Border.BackgroundProperty.AddOwner(typeof(DocumentTabChrome), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x0400028F RID: 655
		public static readonly DependencyProperty BorderBrushProperty = Border.BorderBrushProperty.AddOwner(typeof(DocumentTabChrome), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000290 RID: 656
		public static readonly DependencyProperty InnerBorderBrushProperty = DependencyProperty.Register("InnerBorderBrush", typeof(Brush), typeof(DocumentTabChrome), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000291 RID: 657
		public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(DocumentTabChrome), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

		// Token: 0x04000292 RID: 658
		public static readonly DependencyProperty PaddingProperty = Block.PaddingProperty.AddOwner(typeof(DocumentTabChrome), new FrameworkPropertyMetadata(new Thickness(2.0)));
	}
}

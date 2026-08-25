using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Divelements.SandDock
{
	// Token: 0x0200001D RID: 29
	internal class SplitPreviewAdorner : Adorner
	{
		// Token: 0x06000228 RID: 552 RVA: 0x00039430 File Offset: 0x00037830
		public SplitPreviewAdorner(UIElement element, Style style) : base(element)
		{
			base.SnapsToDevicePixels = true;
			SolidColorBrush solidColorBrush = new SolidColorBrush(Colors.Black);
			solidColorBrush.Opacity = 0.4;
			this.bar = new Rectangle();
			this.bar.Fill = solidColorBrush;
			this.translation = new TranslateTransform();
			this.bar.RenderTransform = this.translation;
			base.AddVisualChild(this.bar);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x000394A4 File Offset: 0x000378A4
		protected override Size ArrangeOverride(Size finalSize)
		{
			this.bar.Arrange(new Rect(default(Point), finalSize));
			return finalSize;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000394CC File Offset: 0x000378CC
		protected override Visual GetVisualChild(int index)
		{
			if (index == 0)
			{
				return this.bar;
			}
			throw new ArgumentOutOfRangeException("index");
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600022B RID: 555 RVA: 0x000394E4 File Offset: 0x000378E4
		protected override int VisualChildrenCount
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600022C RID: 556 RVA: 0x000394E8 File Offset: 0x000378E8
		// (set) Token: 0x0600022D RID: 557 RVA: 0x000394F8 File Offset: 0x000378F8
		public double OffsetX
		{
			get
			{
				return this.translation.X;
			}
			set
			{
				this.translation.X = value;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00039508 File Offset: 0x00037908
		// (set) Token: 0x0600022F RID: 559 RVA: 0x00039518 File Offset: 0x00037918
		public double OffsetY
		{
			get
			{
				return this.translation.Y;
			}
			set
			{
				this.translation.Y = value;
			}
		}

		// Token: 0x040000B5 RID: 181
		private TranslateTransform translation;

		// Token: 0x040000B6 RID: 182
		private Rectangle bar;
	}
}

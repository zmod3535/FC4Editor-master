using System;
using System.Globalization;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Divelements.Util.Registration
{
	// Token: 0x02000005 RID: 5
	internal class EvaluationWatermarkAdorner : Adorner
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00030E74 File Offset: 0x0002F274
		static EvaluationWatermarkAdorner()
		{
			UIElement.IsHitTestVisibleProperty.OverrideMetadata(typeof(EvaluationWatermarkAdorner), new FrameworkPropertyMetadata(false));
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00030E98 File Offset: 0x0002F298
		public EvaluationWatermarkAdorner(UIElement adornedElement, double fontSize) : base(adornedElement)
		{
			this.fontSize = fontSize;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00030EA8 File Offset: 0x0002F2A8
		public EvaluationWatermarkAdorner(UIElement adornedElement) : this(adornedElement, 64.0)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00030EBC File Offset: 0x0002F2BC
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			Typeface typeface = new Typeface(new FontFamily("Calibri"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
			Brush foreground = new SolidColorBrush(Color.FromArgb(20, 128, 128, 128));
			FormattedText formattedText = new FormattedText("evaluation", CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, this.fontSize, foreground);
			drawingContext.DrawText(formattedText, new Point(base.RenderSize.Width - formattedText.Width, base.RenderSize.Height - formattedText.Height));
		}

		// Token: 0x04000003 RID: 3
		private double fontSize;
	}
}

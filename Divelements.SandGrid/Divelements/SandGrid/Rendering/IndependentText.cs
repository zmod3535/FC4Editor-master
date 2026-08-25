using System;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x0200004D RID: 77
	public class IndependentText
	{
		// Token: 0x0600051C RID: 1308 RVA: 0x0001AD84 File Offset: 0x00019D84
		public static void DrawText(Graphics graphics, string text, Font font, Rectangle bounds, TextFormattingInformation textFormat, Color foreColor)
		{
			if (!IndependentText.xc50a22da327d908e)
			{
				xf4604fd5d5aa5ebd.xc9f808b2238be32a(graphics, text, font, bounds, textFormat.TextFormatFlags, foreColor);
				return;
			}
			using (SolidBrush solidBrush = new SolidBrush(foreColor))
			{
				graphics.DrawString(text, font, solidBrush, bounds, textFormat.StringFormat);
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0001ADF4 File Offset: 0x00019DF4
		public static void DrawText(Graphics graphics, string text, Font font, Rectangle bounds, TextFormattingInformation textFormat, Color foreColor, Brush brush)
		{
			if (!IndependentText.xc50a22da327d908e)
			{
				xf4604fd5d5aa5ebd.xc9f808b2238be32a(graphics, text, font, bounds, textFormat.TextFormatFlags, foreColor);
				return;
			}
			graphics.DrawString(text, font, brush, bounds, textFormat.StringFormat);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0001AE28 File Offset: 0x00019E28
		public static Size MeasureText(Graphics graphics, string text, Font font, TextFormattingInformation textFormat)
		{
			if (!IndependentText.xc50a22da327d908e)
			{
				return TextRenderer.MeasureText(graphics, text, font, new Size(int.MaxValue, int.MaxValue), textFormat.TextFormatFlags);
			}
			return Size.Ceiling(graphics.MeasureString(text, font, int.MaxValue, textFormat.StringFormat));
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0001AE74 File Offset: 0x00019E74
		public static Size MeasureText(Graphics graphics, string text, Font font, int width, TextFormattingInformation textFormat)
		{
			if (!IndependentText.xc50a22da327d908e)
			{
				return TextRenderer.MeasureText(graphics, text, font, new Size(width, int.MaxValue), textFormat.TextFormatFlags);
			}
			return Size.Ceiling(graphics.MeasureString(text, font, width, textFormat.StringFormat));
		}

		// Token: 0x040001C2 RID: 450
		internal static bool xc50a22da327d908e;
	}
}

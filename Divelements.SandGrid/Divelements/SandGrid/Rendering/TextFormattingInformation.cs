using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x0200003C RID: 60
	public struct TextFormattingInformation : IDisposable
	{
		// Token: 0x060004DD RID: 1245 RVA: 0x0001A9D0 File Offset: 0x000199D0
		public static TextFormattingInformation CreateFormattingInformation(bool rtl, bool allowWrap, StringAlignment horizontalAlignment, StringAlignment verticalAlignment, bool clipText)
		{
			TextFormattingInformation result = default(TextFormattingInformation);
			TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.NoPadding;
			if (rtl)
			{
				textFormatFlags |= TextFormatFlags.RightToLeft;
			}
			if (allowWrap)
			{
				bool flag = (rtl ? 1U : 0U) + (allowWrap ? 1U : 0U) > uint.MaxValue;
				if (flag)
				{
					return result;
				}
				textFormatFlags |= TextFormatFlags.WordBreak;
			}
			else
			{
				textFormatFlags |= TextFormatFlags.SingleLine;
			}
			if (!clipText)
			{
				textFormatFlags |= TextFormatFlags.NoClipping;
			}
			switch (horizontalAlignment)
			{
			case StringAlignment.Near:
				if (rtl)
				{
					textFormatFlags |= TextFormatFlags.Right;
				}
				else
				{
					textFormatFlags = textFormatFlags;
				}
				break;
			case StringAlignment.Center:
				textFormatFlags |= TextFormatFlags.HorizontalCenter;
				break;
			case StringAlignment.Far:
				if (rtl)
				{
					textFormatFlags = textFormatFlags;
				}
				else
				{
					textFormatFlags |= TextFormatFlags.Right;
				}
				break;
			}
			switch (verticalAlignment)
			{
			case StringAlignment.Near:
				textFormatFlags = textFormatFlags;
				break;
			case StringAlignment.Center:
				textFormatFlags |= TextFormatFlags.VerticalCenter;
				break;
			case StringAlignment.Far:
				textFormatFlags |= TextFormatFlags.Bottom;
				break;
			}
			result.TextFormatFlags = textFormatFlags;
			StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic);
			if (rtl)
			{
				stringFormat.FormatFlags |= StringFormatFlags.DirectionRightToLeft;
			}
			if (!allowWrap)
			{
				stringFormat.FormatFlags = StringFormatFlags.NoWrap;
			}
			stringFormat.Trimming = StringTrimming.EllipsisCharacter;
			stringFormat.LineAlignment = StringAlignment.Center;
			stringFormat.Alignment = horizontalAlignment;
			stringFormat.HotkeyPrefix = HotkeyPrefix.None;
			if (!clipText)
			{
				stringFormat.FormatFlags |= StringFormatFlags.NoClip;
			}
			result.StringFormat = stringFormat;
			return result;
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0001AB04 File Offset: 0x00019B04
		public void Dispose()
		{
			if (this.StringFormat != null)
			{
				this.StringFormat.Dispose();
			}
		}

		// Token: 0x0400019B RID: 411
		public TextFormatFlags TextFormatFlags;

		// Token: 0x0400019C RID: 412
		public StringFormat StringFormat;
	}
}

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200002A RID: 42
	internal class x3ddece31da445155
	{
		// Token: 0x06000259 RID: 601 RVA: 0x0000B6E0 File Offset: 0x0000A6E0
		public static int x37affa25095b1846(ICollection xa73e17ae29927ab0, ImageList x6ec0d1228599f9ae)
		{
			int num = 0;
			foreach (object obj in xa73e17ae29927ab0)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
				if (menuButtonItem.Icon != null && menuButtonItem.IconSize.Width > num)
				{
					num = menuButtonItem.IconSize.Width;
				}
				else if (menuButtonItem.Image != null && menuButtonItem.Image.Width > num)
				{
					num = menuButtonItem.Image.Width;
				}
			}
			if (x6ec0d1228599f9ae != null && x6ec0d1228599f9ae.ImageSize.Width > num)
			{
				foreach (object obj2 in xa73e17ae29927ab0)
				{
					MenuButtonItem menuButtonItem2 = (MenuButtonItem)obj2;
					if (menuButtonItem2.ImageIndex >= 0 && menuButtonItem2.ImageIndex < x6ec0d1228599f9ae.Images.Count)
					{
						num = x6ec0d1228599f9ae.ImageSize.Width;
						break;
					}
				}
			}
			if (num < 16)
			{
				num = 16;
			}
			return num + 16;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000B830 File Offset: 0x0000A830
		public static Size x92a98ee313cca646(Graphics x41347a961b838962, MenuButtonItem xccb63ca5f63dc470, ImageList x6ec0d1228599f9ae, IPopupMenuHost x64f259306803411c)
		{
			SizeF sizeF = Size.Empty;
			Size empty = Size.Empty;
			int num;
			do
			{
				num = 0;
				SizeF sizeF2 = TextRenderer.MeasureText(x41347a961b838962, xccb63ca5f63dc470.Text, xccb63ca5f63dc470.Font, new Size(int.MaxValue, int.MaxValue), x64f259306803411c.Renderer.MenuTextFormatFlags);
				if (xccb63ca5f63dc470.ShortcutDisplayString.Length != 0)
				{
					sizeF = TextRenderer.MeasureText(x41347a961b838962, xccb63ca5f63dc470.ShortcutDisplayString, xccb63ca5f63dc470.Font, new Size(int.MaxValue, int.MaxValue), x64f259306803411c.Renderer.MenuTextFormatFlags);
				}
				empty.Width = (int)Math.Ceiling((double)(sizeF2.Width + sizeF.Width));
				if (xccb63ca5f63dc470.Shortcut != Shortcut.None)
				{
					empty.Width += 6;
				}
				empty.Width += 20;
				empty.Height = xccb63ca5f63dc470.Font.Height;
				if (empty.Height < 16)
				{
					empty.Height = 16;
				}
				if (xccb63ca5f63dc470.Icon != null)
				{
					goto Block_6;
				}
				if (xccb63ca5f63dc470.Image == null)
				{
					goto IL_18E;
				}
				num = xccb63ca5f63dc470.Image.Height;
			}
			while ((uint)num - (uint)num < 0U);
			IL_1D:
			if (num > empty.Height)
			{
				empty.Height = num;
			}
			empty.Height += 6;
			if (empty.Width < 32)
			{
				empty.Width = 32;
			}
			return empty;
			Block_6:
			num = xccb63ca5f63dc470.IconSize.Height;
			goto IL_1D;
			IL_18E:
			if (x6ec0d1228599f9ae != null)
			{
				num = x6ec0d1228599f9ae.ImageSize.Height;
				goto IL_1D;
			}
			goto IL_1D;
		}
	}
}

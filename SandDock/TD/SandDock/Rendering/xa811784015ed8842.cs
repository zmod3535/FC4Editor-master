using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
	// Token: 0x0200002C RID: 44
	internal class xa811784015ed8842
	{
		// Token: 0x060003AC RID: 940 RVA: 0x0001D048 File Offset: 0x0001C048
		internal static void x91433b5e99eb7cac(Graphics x41347a961b838962, Color x6c50a99faab7d741)
		{
			try
			{
				x41347a961b838962.Clear(x6c50a99faab7d741);
			}
			catch
			{
			}
		}

		// Token: 0x060003AD RID: 941 RVA: 0x0001D080 File Offset: 0x0001C080
		public static void xf8aac789a7846004(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Rectangle x0bd0d09521a6c8ef, Image xe058541ca798c059, Size x95dac044246123ac, string xb41faee6912a2313, Font x26094932cf7a9139, Color x477e9d1180ece053, Color x3421b2dea6733873, Brush x4fe4e32776bbc2b0, Color xa1359fb73f86c7a4, Color xfca0e3085d5a7f42, Color x228f9881a1be0e5d, bool x9f93ebd2ca5601a2, int x6843d1739e949b3a, int xbd5e294caed74c4d, TextFormatFlags xae3b2752a89e7464, bool xb0f87b71823b1d4e)
		{
			if (xda73fcb97c77d998.Width > 0)
			{
				IL_622:
				while (xda73fcb97c77d998.Height > 0)
				{
					Rectangle rectangle;
					for (;;)
					{
						IL_3B9:
						bool flag;
						using (Pen pen = new Pen(xa1359fb73f86c7a4))
						{
							x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + 1, xda73fcb97c77d998.Bottom - 2);
							x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + 1, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2);
							x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 2);
							flag = ((uint)xbd5e294caed74c4d < 0U);
							if (!flag)
							{
								x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 1);
								do
								{
									x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top);
									x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2);
									x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 2);
									flag = (((xb0f87b71823b1d4e ? 1U : 0U) & 0U) == 0U);
								}
								while (!flag);
							}
						}
						using (Pen pen2 = new Pen(xfca0e3085d5a7f42))
						{
							x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3);
							x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 3);
							x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 2);
							x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 4, xda73fcb97c77d998.Top + 1);
							goto IL_336;
						}
						goto IL_622;
						IL_336:
						using (Pen pen3 = new Pen(x228f9881a1be0e5d))
						{
							x41347a961b838962.DrawLine(pen3, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
							x41347a961b838962.DrawLine(pen3, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 2);
						}
						Point[] array = new Point[5];
						array[0] = new Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 1);
						array[1] = new Point(xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 4);
						if (false)
						{
							goto IL_AE;
						}
						array[2] = new Point(xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 2);
						for (;;)
						{
							array[3] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
							array[4] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 1);
							using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, x477e9d1180ece053, x3421b2dea6733873, LinearGradientMode.Vertical))
							{
								x41347a961b838962.FillPolygon(linearGradientBrush, array);
							}
							if (!x9f93ebd2ca5601a2)
							{
								goto IL_1A6;
							}
							if ((x9f93ebd2ca5601a2 ? 1U : 0U) + (xb0f87b71823b1d4e ? 1U : 0U) > 4294967295U)
							{
								goto IL_4E;
							}
							using (Pen pen4 = new Pen(x3421b2dea6733873))
							{
								x41347a961b838962.DrawLine(pen4, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1);
								goto IL_1A6;
							}
							IL_280:
							flag = ((uint)x6843d1739e949b3a + (x9f93ebd2ca5601a2 ? 1U : 0U) < 0U);
							if (flag)
							{
								break;
							}
							xda73fcb97c77d998.X += xbd5e294caed74c4d;
							xda73fcb97c77d998.Width -= xbd5e294caed74c4d;
							if (15 == 0)
							{
								continue;
							}
							break;
							IL_1A6:
							xda73fcb97c77d998 = x0bd0d09521a6c8ef;
							goto IL_280;
						}
						do
						{
							if (xe058541ca798c059 == null)
							{
								flag = ((uint)x6843d1739e949b3a - (uint)xbd5e294caed74c4d < 0U);
								if (flag)
								{
									break;
								}
							}
							else
							{
								x41347a961b838962.DrawImage(xe058541ca798c059, xda73fcb97c77d998.X + 4, xda73fcb97c77d998.Y + 2, x95dac044246123ac.Width, x95dac044246123ac.Height);
								xda73fcb97c77d998.X += x95dac044246123ac.Width + 4;
								xda73fcb97c77d998.Width -= x95dac044246123ac.Width + 4;
							}
							if (xda73fcb97c77d998.Width <= 8)
							{
								goto IL_12;
							}
							flag = ((xb0f87b71823b1d4e ? 1U : 0U) > uint.MaxValue);
						}
						while (flag);
						if (-2 == 0)
						{
							break;
						}
						goto IL_A2;
						IL_12:
						while (xb0f87b71823b1d4e)
						{
							rectangle = xda73fcb97c77d998;
							rectangle.Inflate(-2, -2);
							rectangle.Height += 2;
							flag = ((xb0f87b71823b1d4e ? 1U : 0U) + (uint)x6843d1739e949b3a < 0U);
							if (flag)
							{
								flag = ((uint)xbd5e294caed74c4d < 0U);
								if (flag)
								{
									goto IL_A2;
								}
							}
							else
							{
								if ((uint)xbd5e294caed74c4d <= 4294967295U)
								{
									goto Block_3;
								}
								goto IL_3B9;
							}
						}
						break;
						IL_AE:
						TextRenderer.DrawText(x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, xda73fcb97c77d998, SystemColors.ControlText, xae3b2752a89e7464);
						goto IL_12;
						IL_A2:
						xae3b2752a89e7464 |= TextFormatFlags.HorizontalCenter;
						xae3b2752a89e7464 &= (TextFormatFlags)(-1);
						goto IL_AE;
					}
					return;
					Block_3:
					rectangle.X++;
					rectangle.Width--;
					IL_4E:
					ControlPaint.DrawFocusRectangle(x41347a961b838962, rectangle);
					return;
				}
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0001D740 File Offset: 0x0001C740
		public static Size xcdfce0e0f2641503(Graphics x41347a961b838962, Image xe058541ca798c059, Size x95dac044246123ac, string xb41faee6912a2313, Font x26094932cf7a9139, TextFormatFlags xae3b2752a89e7464)
		{
			int num = TextRenderer.MeasureText(x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, new Size(int.MaxValue, int.MaxValue), xae3b2752a89e7464).Width + 3;
			num += 6;
			num += x95dac044246123ac.Width + 4;
			return new Size(num, x95dac044246123ac.Height);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0001D794 File Offset: 0x0001C794
		public static void x272eca3f5ebfa9fc(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Image xe058541ca798c059, Size x95dac044246123ac, string xb41faee6912a2313, Font x26094932cf7a9139, Color x477e9d1180ece053, Color x3421b2dea6733873, Color x93532ca0ace0c1ae, Color xa1359fb73f86c7a4, DrawItemState x01b557925841ae51, TextFormatFlags xae3b2752a89e7464)
		{
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, x477e9d1180ece053, x3421b2dea6733873, LinearGradientMode.Vertical))
			{
				xa811784015ed8842.x272eca3f5ebfa9fc(x41347a961b838962, xda73fcb97c77d998, xe058541ca798c059, x95dac044246123ac, xb41faee6912a2313, x26094932cf7a9139, linearGradientBrush, x93532ca0ace0c1ae, xa1359fb73f86c7a4, x01b557925841ae51, xae3b2752a89e7464);
			}
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0001D7EC File Offset: 0x0001C7EC
		public static void x272eca3f5ebfa9fc(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Image xe058541ca798c059, Size x95dac044246123ac, string xb41faee6912a2313, Font x26094932cf7a9139, Brush x6f967439eb9e4ffb, Color x93532ca0ace0c1ae, Color xa1359fb73f86c7a4, DrawItemState x01b557925841ae51, TextFormatFlags xae3b2752a89e7464)
		{
			Rectangle rect;
			if ((x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected)
			{
				rect = xda73fcb97c77d998;
				goto IL_1F9;
			}
			IL_114:
			xda73fcb97c77d998.Inflate(-3, 0);
			if (!true || xda73fcb97c77d998.Width >= x95dac044246123ac.Width + 4)
			{
				x41347a961b838962.DrawImage(xe058541ca798c059, new Rectangle(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y + 2, x95dac044246123ac.Width, x95dac044246123ac.Height));
				xda73fcb97c77d998.X += x95dac044246123ac.Width + 4;
				xda73fcb97c77d998.Width -= x95dac044246123ac.Width + 4;
			}
			if (xda73fcb97c77d998.Width < 8)
			{
				if (!false)
				{
					return;
				}
				if (false)
				{
					goto IL_15B;
				}
			}
			xda73fcb97c77d998.Y--;
			if (4 != 0)
			{
				xae3b2752a89e7464 = xae3b2752a89e7464;
				xae3b2752a89e7464 &= ~TextFormatFlags.HorizontalCenter;
			}
			TextRenderer.DrawText(x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, xda73fcb97c77d998, x93532ca0ace0c1ae, xae3b2752a89e7464);
			if (-2147483648 == 0)
			{
				goto IL_1CF;
			}
			return;
			IL_15B:
			Point[] array;
			array[3] = new Point(xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Bottom - 1);
			array[4] = new Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 3);
			array[5] = new Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
			using (Pen pen = new Pen(xa1359fb73f86c7a4))
			{
				x41347a961b838962.DrawLines(pen, array);
			}
			goto IL_114;
			IL_1CF:
			array[2] = new Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 1);
			if (4 != 0)
			{
				goto IL_15B;
			}
			IL_1F9:
			if (true)
			{
				rect.Inflate(-1, 0);
			}
			rect.Height--;
			x41347a961b838962.FillRectangle(x6f967439eb9e4ffb, rect);
			array = new Point[6];
			array[0] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top);
			array[1] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 3);
			goto IL_1CF;
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0001DA48 File Offset: 0x0001CA48
		public static void x36c79cea8e98cf3c(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DockSide xf33779c598cac695, Image xe058541ca798c059, string xb41faee6912a2313, Font x26094932cf7a9139, Brush x4fe4e32776bbc2b0, Color xa1359fb73f86c7a4, bool x96c7dce50f0f3286)
		{
			xa811784015ed8842.x36c79cea8e98cf3c(x41347a961b838962, xda73fcb97c77d998, xf33779c598cac695, xe058541ca798c059, xb41faee6912a2313, x26094932cf7a9139, null, x4fe4e32776bbc2b0, xa1359fb73f86c7a4, x96c7dce50f0f3286);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0001DA6C File Offset: 0x0001CA6C
		public static void x36c79cea8e98cf3c(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DockSide xf33779c598cac695, Image xe058541ca798c059, string xb41faee6912a2313, Font x26094932cf7a9139, Brush x6f967439eb9e4ffb, Brush x4fe4e32776bbc2b0, Color xa1359fb73f86c7a4, bool x96c7dce50f0f3286)
		{
			bool flag = false;
			int num;
			for (;;)
			{
				Point[] array = new Point[6];
				if ((flag ? 1U : 0U) + (uint)num <= 4294967295U)
				{
					goto IL_5A5;
				}
				goto IL_21A;
				IL_4D2:
				if (((flag ? 1U : 0U) & 0U) != 0U)
				{
					continue;
				}
				goto IL_14A;
				IL_413:
				array[5] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top + 2);
				flag = true;
				bool flag2 = (x96c7dce50f0f3286 ? 1U : 0U) + (x96c7dce50f0f3286 ? 1U : 0U) < 0U;
				if (flag2)
				{
					goto IL_451;
				}
				goto IL_4D2;
				IL_5A5:
				switch (xf33779c598cac695)
				{
				case DockSide.Top:
					array[0] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top);
					array[1] = new Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top);
					goto IL_346;
				case DockSide.Bottom:
					array[0] = new Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Top);
					array[1] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top);
					array[2] = new Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top + 2);
					goto IL_1A4;
				case DockSide.Left:
					array[0] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top);
					array[1] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top);
					break;
				case DockSide.Right:
					array[0] = new Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Top);
					array[1] = new Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top);
					flag2 = ((flag ? 1U : 0U) + (uint)num < 0U);
					if (flag2)
					{
						goto IL_4D2;
					}
					array[2] = new Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom);
					array[3] = new Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom);
					goto IL_3F2;
				default:
					goto IL_14A;
				}
				IL_559:
				if (!false)
				{
					array[2] = new Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top + 2);
				}
				array[3] = new Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom - 2);
				if (2 == 0)
				{
					goto IL_5A5;
				}
				array[4] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom);
				goto IL_451;
				IL_3F2:
				array[4] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 2);
				goto IL_413;
				IL_21A:
				if ((x96c7dce50f0f3286 ? 1U : 0U) + (x96c7dce50f0f3286 ? 1U : 0U) > 4294967295U)
				{
					goto IL_3F2;
				}
				if ((flag ? 1U : 0U) <= 4294967295U)
				{
					goto IL_1A2;
				}
				goto IL_346;
				IL_1A4:
				array[3] = new Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom);
				flag2 = (((uint)num & 0U) == 0U);
				if (flag2)
				{
					array[4] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom);
					array[5] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top + 2);
					goto IL_21A;
				}
				break;
				IL_14A:
				if (x6f967439eb9e4ffb != null)
				{
					x41347a961b838962.FillPolygon(x6f967439eb9e4ffb, array);
				}
				using (Pen pen = new Pen(xa1359fb73f86c7a4))
				{
					x41347a961b838962.DrawPolygon(pen, array);
				}
				xda73fcb97c77d998.Inflate(-2, -2);
				flag2 = ((uint)num > uint.MaxValue);
				if (flag2)
				{
					flag2 = ((uint)num - (x96c7dce50f0f3286 ? 1U : 0U) < 0U);
					if (flag2)
					{
						goto IL_1A2;
					}
					goto IL_1A4;
				}
				else
				{
					for (;;)
					{
						if (flag)
						{
							xda73fcb97c77d998.Offset(0, 1);
						}
						else
						{
							xda73fcb97c77d998.Offset(1, 0);
						}
						x41347a961b838962.DrawImage(xe058541ca798c059, new Rectangle(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xe058541ca798c059.Width, xe058541ca798c059.Height));
						if (false)
						{
							if (((uint)num & 0U) != 0U)
							{
								goto IL_AA;
							}
							goto IL_AE;
						}
						else
						{
							if (xb41faee6912a2313.Length == 0)
							{
								goto Block_1;
							}
							goto IL_AE;
						}
						IL_B4:
						int num2;
						num = num2;
						if (!flag)
						{
							goto IL_08;
						}
						flag2 = (((x96c7dce50f0f3286 ? 1U : 0U) | 2147483648U) == 0U);
						if (!flag2)
						{
							if ((uint)num - (uint)num > 4294967295U)
							{
								goto IL_413;
							}
							if ((uint)num + (uint)num > 4294967295U)
							{
								goto IL_559;
							}
							xda73fcb97c77d998.Offset(0, num);
							x41347a961b838962.DrawString(xb41faee6912a2313, x26094932cf7a9139, x4fe4e32776bbc2b0, xda73fcb97c77d998, EverettRenderer.xc351c68a86733972);
						}
						flag2 = ((uint)num > uint.MaxValue);
						if (flag2)
						{
							continue;
						}
						goto IL_135;
						IL_AE:
						if (x96c7dce50f0f3286)
						{
							num2 = 21;
							goto IL_B4;
						}
						IL_AA:
						num2 = 23;
						goto IL_B4;
					}
				}
				IL_346:
				array[2] = new Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom - 2);
				array[3] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom);
				if ((uint)num + (flag ? 1U : 0U) <= 4294967295U)
				{
					array[4] = new Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom);
					array[5] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 2);
				}
				IL_1A2:
				goto IL_14A;
				IL_451:
				array[5] = new Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom);
				flag = true;
				goto IL_14A;
			}
			return;
			IL_08:
			xda73fcb97c77d998.Offset(num, 0);
			x41347a961b838962.DrawString(xb41faee6912a2313, x26094932cf7a9139, x4fe4e32776bbc2b0, xda73fcb97c77d998, EverettRenderer.x27e1c82c97265861);
			Block_1:
			return;
			IL_135:;
		}
	}
}

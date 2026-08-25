using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
	// Token: 0x02000065 RID: 101
	[TypeConverter(typeof(xdc4dfd9427bbb983))]
	public class MilborneRenderer : ITabControlRenderer
	{
		// Token: 0x060005C4 RID: 1476 RVA: 0x0002AC8C File Offset: 0x00029C8C
		public override string ToString()
		{
			return "Milborne";
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x0002AC94 File Offset: 0x00029C94
		// (set) Token: 0x060005C6 RID: 1478 RVA: 0x0002AC9C File Offset: 0x00029C9C
		public double PageColorBlend
		{
			get
			{
				return this.x6093764f4f59f8ca;
			}
			set
			{
				if (value >= 0.0 && value <= 1.0)
				{
					if (255 != 0)
					{
						this.x6093764f4f59f8ca = value;
					}
					return;
				}
				throw new ArgumentException("Value must lie between 0 and 1.");
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060005C7 RID: 1479 RVA: 0x0002ACD4 File Offset: 0x00029CD4
		// (set) Token: 0x060005C8 RID: 1480 RVA: 0x0002ACDC File Offset: 0x00029CDC
		public double TabColorBlend
		{
			get
			{
				return this.x567d5545e28c9c83;
			}
			set
			{
				if (value >= 0.0 && value <= 1.0)
				{
					this.x567d5545e28c9c83 = value;
					return;
				}
				throw new ArgumentException("Value must lie between 0 and 1.");
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0002AD14 File Offset: 0x00029D14
		public virtual bool ShouldDrawControlBorder
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x0002AD18 File Offset: 0x00029D18
		public virtual void DrawFakeTabControlBackgroundExtension(Graphics graphics, Rectangle bounds, Color backColor)
		{
			using (SolidBrush solidBrush = new SolidBrush(this.xb9bbdee8e645fa7b))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			using (Pen pen = new Pen(this.x68e7227781326461))
			{
				graphics.DrawLine(pen, bounds.Right - 1, bounds.Y, bounds.Right - 1, bounds.Bottom - 1);
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0002ADBC File Offset: 0x00029DBC
		public void DrawTabControlButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
		{
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				bounds.Offset(1, 1);
			}
			if (-2147483648 != 0)
			{
			}
			switch (buttonType)
			{
			case SandDockButtonType.ScrollLeft:
				x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
				return;
			case SandDockButtonType.ScrollRight:
				x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
				return;
			default:
				return;
			}
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0002AE24 File Offset: 0x00029E24
		public Size MeasureTabControlTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			int num;
			using (new Font(font, FontStyle.Bold))
			{
				num = TextRenderer.MeasureText(graphics, text, font, new Size(int.MaxValue, int.MaxValue), this.xae3b2752a89e7464).Width;
			}
			num += 24;
			if (image != null)
			{
				num += image.Width + 4;
			}
			num += this.TabControlTabExtra;
			return new Size(num, 0);
		}

		// Token: 0x060005CD RID: 1485 RVA: 0x0002AEAC File Offset: 0x00029EAC
		public void FinishRenderSession()
		{
		}

		// Token: 0x060005CE RID: 1486 RVA: 0x0002AEB0 File Offset: 0x00029EB0
		public void StartRenderSession(HotkeyPrefix tabHotKeys)
		{
			this.xae3b2752a89e7464 = (TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPadding);
			if (!false)
			{
				if (tabHotKeys == HotkeyPrefix.None)
				{
					this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
					return;
				}
				if (!false)
				{
					goto IL_29;
				}
			}
			IL_0E:
			if (!false)
			{
				return;
			}
			IL_29:
			if (tabHotKeys == HotkeyPrefix.Hide)
			{
				this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
				goto IL_0E;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x0002AF0C File Offset: 0x00029F0C
		public int TabControlTabStripHeight
		{
			get
			{
				return Control.DefaultFont.Height + 8;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0002AF1C File Offset: 0x00029F1C
		public int TabControlTabExtra
		{
			get
			{
				return this.TabControlTabStripHeight - 7;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x0002AF28 File Offset: 0x00029F28
		public virtual Size TabControlPadding
		{
			get
			{
				return new Size(4, 4);
			}
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0002AF34 File Offset: 0x00029F34
		public void DrawTabControlTabStripBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
			if (backColor != Color.Transparent)
			{
				xa811784015ed8842.x91433b5e99eb7cac(graphics, backColor);
			}
			using (Pen pen = new Pen(this.x68e7227781326461))
			{
				graphics.DrawLine(pen, bounds.X, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
			}
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x0002AFB4 File Offset: 0x00029FB4
		public int TabControlTabHeight
		{
			get
			{
				return this.TabControlTabStripHeight;
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060005D4 RID: 1492 RVA: 0x0002AFBC File Offset: 0x00029FBC
		public bool ShouldDrawTabControlBackground
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060005D5 RID: 1493 RVA: 0x0002AFC0 File Offset: 0x00029FC0
		private Point[] x23c99552401d90a0(Rectangle xda73fcb97c77d998, bool xb35f79a43e184314)
		{
			int num = Math.Min(xda73fcb97c77d998.Width, xda73fcb97c77d998.Height);
			Point[] array;
			for (;;)
			{
				bool flag = (xb35f79a43e184314 ? 1U : 0U) < 0U;
				if (!flag && !xb35f79a43e184314)
				{
					flag = ((xb35f79a43e184314 ? 1U : 0U) > uint.MaxValue);
					if (flag)
					{
						goto IL_1AC;
					}
				}
				else
				{
					array = new Point[6];
					array[0] = new Point(xda73fcb97c77d998.X + 2, xda73fcb97c77d998.Bottom - 2);
					array[1] = new Point(xda73fcb97c77d998.X + num - 3, xda73fcb97c77d998.Y + 3);
					if ((xb35f79a43e184314 ? 1U : 0U) <= 4294967295U)
					{
						goto IL_1AC;
					}
					goto IL_172;
				}
				IL_1EC:
				if (false)
				{
					goto IL_1F2;
				}
				flag = (((uint)num & 0U) == 0U);
				if (flag)
				{
					goto IL_1F2;
				}
				IL_64:
				Point[] array2 = new Point[6];
				do
				{
					array2[0] = new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Bottom - 1);
				}
				while (2 == 0);
				array2[1] = new Point(xda73fcb97c77d998.X + num - 4, xda73fcb97c77d998.Y + 3);
				array2[2] = new Point(xda73fcb97c77d998.X + num + 1, xda73fcb97c77d998.Y);
				array2[3] = new Point(xda73fcb97c77d998.Right - 4, xda73fcb97c77d998.Y);
				array2[4] = new Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Y + 3);
				array2[5] = new Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1);
				if (2 == 0)
				{
					continue;
				}
				return array2;
				IL_1F2:
				flag = ((uint)num < 0U);
				if (flag)
				{
					return array2;
				}
				goto IL_64;
				IL_1AC:
				array[2] = new Point(xda73fcb97c77d998.X + num + 1, xda73fcb97c77d998.Y + 1);
				flag = ((uint)num + (uint)num > uint.MaxValue);
				if (flag)
				{
					goto IL_1EC;
				}
				break;
			}
			array[3] = new Point(xda73fcb97c77d998.Right - 4, xda73fcb97c77d998.Y + 1);
			array[4] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Y + 3);
			IL_172:
			array[5] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 2);
			return array;
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x0002B254 File Offset: 0x0002A254
		public void DrawTabControlTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			int height = bounds.Height;
			bool flag = ((drawSeparator ? 1U : 0U) & 0U) == 0U;
			if (!flag)
			{
				goto IL_F8;
			}
			bool flag2;
			if ((flag2 ? 1U : 0U) - (drawSeparator ? 1U : 0U) < 0U)
			{
				goto IL_3BA;
			}
			flag2 = ((state & DrawItemState.Selected) == DrawItemState.Selected);
			if (!false)
			{
				if (255 != 0)
				{
					goto IL_53C;
				}
			}
			else
			{
				if (3 == 0)
				{
					goto IL_4C6;
				}
				goto IL_4C9;
			}
			IL_EE:
			bounds.Inflate(-2, 0);
			IL_F8:
			flag = ((flag2 ? 1U : 0U) < 0U);
			if (flag)
			{
				if ((drawSeparator ? 1U : 0U) + (flag2 ? 1U : 0U) > 4294967295U)
				{
					goto IL_389;
				}
				flag = ((drawSeparator ? 1U : 0U) - (flag2 ? 1U : 0U) > uint.MaxValue);
				if (flag)
				{
					goto IL_422;
				}
				goto IL_98;
			}
			else if (image != null)
			{
				goto IL_98;
			}
			IL_56:
			if (bounds.Width <= 4)
			{
				goto IL_494;
			}
			if (flag2)
			{
				using (Font font2 = new Font(font, FontStyle.Bold))
				{
					TextRenderer.DrawText(graphics, text, font2, bounds, foreColor, this.xae3b2752a89e7464);
					return;
				}
			}
			TextRenderer.DrawText(graphics, text, font, bounds, foreColor, this.xae3b2752a89e7464);
			return;
			IL_98:
			Rectangle destRect = new Rectangle(bounds.X, bounds.Y + bounds.Height / 2 - image.Height / 2, image.Width, image.Height);
			graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
			bounds.X += image.Width + 4;
			bounds.Width -= image.Width + 4;
			goto IL_56;
			IL_217:
			Color color = this.x62b1822fa10e8658;
			IL_21D:
			using (Pen pen = new Pen(color))
			{
				graphics.DrawLines(pen, this.x23c99552401d90a0(bounds, true));
				for (;;)
				{
					while (!flag2)
					{
						Color color2 = RendererBase.InterpolateColors(this.x31d8d8063d8f3c74, this.x68e7227781326461, 0.5f);
						if (((flag2 ? 1U : 0U) | 2147483648U) != 0U)
						{
							using (Pen pen2 = new Pen(color2))
							{
								graphics.DrawLines(pen2, new Point[]
								{
									new Point(bounds.Right - 4, bounds.Y + 1),
									new Point(bounds.Right - 2, bounds.Y + 3),
									new Point(bounds.Right - 2, bounds.Bottom - 2)
								});
								break;
							}
						}
					}
					break;
				}
				goto IL_36A;
			}
			IL_326:
			Color color3;
			using (Pen pen3 = new Pen(color3))
			{
				graphics.DrawLine(pen3, bounds.X + 1, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
				goto IL_36D;
			}
			IL_36A:
			if (flag2)
			{
				goto IL_326;
			}
			IL_36D:
			SmoothingMode smoothingMode;
			graphics.SmoothingMode = smoothingMode;
			if ((state & DrawItemState.Checked) == DrawItemState.Checked)
			{
				Rectangle rectangle = bounds;
				if (4 != 0)
				{
					rectangle.X += this.TabControlTabExtra;
					rectangle.Width -= this.TabControlTabExtra;
					rectangle.Inflate(-4, -3);
					rectangle.X++;
					rectangle.Height++;
					if ((flag2 ? 1U : 0U) < 0U)
					{
						goto IL_F8;
					}
					ControlPaint.DrawFocusRectangle(graphics, rectangle);
				}
				else
				{
					if (false)
					{
						goto IL_37F;
					}
					flag = (((flag2 ? 1U : 0U) & 0U) == 0U);
					if (flag)
					{
						goto IL_217;
					}
					goto IL_37F;
				}
			}
			bounds.X += this.TabControlTabExtra + 6;
			bounds.Width -= this.TabControlTabExtra + 6;
			goto IL_EE;
			IL_37F:
			if (flag2)
			{
				goto IL_217;
			}
			IL_389:
			color = this.x31d8d8063d8f3c74;
			goto IL_21D;
			IL_3BA:
			using (Pen pen4 = new Pen((!flag2) ? this.x68e7227781326461 : this.xd9caa88fffee2844))
			{
				graphics.DrawLines(pen4, this.x23c99552401d90a0(bounds, false));
				goto IL_37F;
			}
			IL_414:
			graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if ((flag2 ? 1U : 0U) - (drawSeparator ? 1U : 0U) <= 4294967295U)
			{
				goto IL_3BA;
			}
			goto IL_53C;
			IL_422:
			Color color4;
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, color4, color3, LinearGradientMode.Vertical))
			{
				graphics.FillPolygon(linearGradientBrush, this.x23c99552401d90a0(bounds, false));
			}
			smoothingMode = graphics.SmoothingMode;
			goto IL_414;
			IL_494:
			return;
			IL_4C6:
			Color color5;
			if (!flag2)
			{
				color5 = this.x51e4f0f96f7fc653;
				goto IL_4CF;
			}
			IL_4C9:
			color5 = this.x6cefc7bb40cf5d76;
			IL_4CF:
			color4 = color5;
			flag = ((drawSeparator ? 1U : 0U) - (drawSeparator ? 1U : 0U) < 0U);
			color3 = ((flag || !flag2) ? this.xb9bbdee8e645fa7b : this.x05d7ee48911d8dba);
			if (this.TabColorBlend > 0.0)
			{
				color4 = RendererBase.InterpolateColors(color4, backColor, (float)this.TabColorBlend);
				color3 = RendererBase.InterpolateColors(color3, backColor, (float)this.TabColorBlend);
				goto IL_422;
			}
			if (8 == 0)
			{
				goto IL_494;
			}
			goto IL_422;
			IL_53C:
			goto IL_4C6;
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x0002B83C File Offset: 0x0002A83C
		public void DrawTabControlBackground(Graphics graphics, Rectangle bounds, Color backColor, bool client)
		{
			if (bounds.Width > 0)
			{
				bool flag = ((client ? 1U : 0U) | uint.MaxValue) == 0U;
				if (!flag)
				{
					goto IL_3ED;
				}
				IL_157:
				Rectangle rect;
				Color color;
				Color color2;
				if (rect.Height > 0)
				{
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, color, color2, LinearGradientMode.Vertical))
					{
						graphics.FillRectangle(linearGradientBrush, rect);
						goto IL_164;
					}
					goto IL_212;
				}
				IL_164:
				Rectangle rect2 = bounds;
				rect2.Y = rect2.Bottom - this.TabControlPadding.Height;
				rect2.Height = this.TabControlPadding.Height;
				IL_19B:
				using (SolidBrush solidBrush = new SolidBrush(color2))
				{
					graphics.FillRectangle(solidBrush, rect2);
					goto IL_2D;
				}
				goto IL_1C9;
				IL_2D:
				using (Pen pen = new Pen(this.x68e7227781326461))
				{
					graphics.DrawLine(pen, bounds.X, bounds.Y, bounds.X, bounds.Bottom - 2);
					graphics.DrawLine(pen, bounds.X, bounds.Bottom - 2, bounds.Right - 2, bounds.Bottom - 2);
					graphics.DrawLine(pen, bounds.Right - 2, bounds.Bottom - 2, bounds.Right - 2, bounds.Y);
				}
				using (Pen pen2 = new Pen(RendererBase.InterpolateColors(this.x68e7227781326461, SystemColors.Control, 0.8f)))
				{
					graphics.DrawLine(pen2, bounds.X, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
					graphics.DrawLine(pen2, bounds.Right - 1, bounds.Bottom - 1, bounds.Right - 1, bounds.Y);
					return;
				}
				goto IL_157;
				IL_1C9:
				goto IL_164;
				IL_212:
				rect.Y += this.TabControlPadding.Height;
				rect.Height -= this.TabControlPadding.Height * 2;
				goto IL_2D5;
				IL_281:
				Rectangle rect3 = bounds;
				if ((client ? 1U : 0U) + (client ? 1U : 0U) < 0U)
				{
					goto IL_19B;
				}
				if ((client ? 1U : 0U) < 0U)
				{
					goto IL_36E;
				}
				rect3.Height = this.TabControlPadding.Height;
				if (!false)
				{
					using (SolidBrush solidBrush2 = new SolidBrush(color))
					{
						graphics.FillRectangle(solidBrush2, rect3);
					}
					rect = bounds;
				}
				if (!false)
				{
					goto IL_212;
				}
				IL_2D5:
				if (!false)
				{
					goto IL_2FD;
				}
				IL_2D8:
				if (!false)
				{
					goto IL_281;
				}
				IL_2DB:
				if ((client ? 1U : 0U) - (client ? 1U : 0U) > 4294967295U)
				{
					goto IL_31B;
				}
				if (15 != 0)
				{
					goto IL_281;
				}
				IL_2FD:
				if (!true)
				{
					flag = ((client ? 1U : 0U) > uint.MaxValue);
					if (flag)
					{
						goto IL_2DB;
					}
					goto IL_337;
				}
				else
				{
					if (rect.Width <= 0)
					{
						goto IL_164;
					}
					goto IL_157;
				}
				IL_31B:
				if (client)
				{
					goto IL_33C;
				}
				flag = ((client ? 1U : 0U) - (client ? 1U : 0U) < 0U);
				if (!flag)
				{
					goto IL_2D8;
				}
				IL_337:
				goto IL_1C9;
				IL_33C:
				using (LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(bounds, color, color2, LinearGradientMode.Vertical))
				{
					graphics.FillRectangle(linearGradientBrush2, bounds);
					return;
				}
				IL_362:
				if (8 == 0)
				{
					goto IL_33C;
				}
				goto IL_31B;
				IL_36E:
				color = RendererBase.InterpolateColors(color, backColor, (float)this.PageColorBlend);
				color2 = RendererBase.InterpolateColors(color2, backColor, (float)this.PageColorBlend);
				if ((client ? 1U : 0U) - (client ? 1U : 0U) < 0U)
				{
					goto IL_164;
				}
				if (!false)
				{
					goto IL_362;
				}
				if (!false)
				{
					goto IL_3ED;
				}
				IL_3AD:
				color = Color.FromArgb(252, 252, 254);
				color2 = Color.FromArgb(244, 243, 238);
				if (this.PageColorBlend > 0.0)
				{
					goto IL_36E;
				}
				goto IL_31B;
				IL_3ED:
				if (bounds.Height > 0)
				{
					goto IL_3AD;
				}
				return;
			}
		}

		// Token: 0x0400021F RID: 543
		private TextFormatFlags xae3b2752a89e7464;

		// Token: 0x04000220 RID: 544
		private Color xd9caa88fffee2844 = Color.FromArgb(124, 124, 148);

		// Token: 0x04000221 RID: 545
		private Color x62b1822fa10e8658 = SystemColors.ControlLight;

		// Token: 0x04000222 RID: 546
		private Color x68e7227781326461 = Color.FromArgb(117, 116, 147);

		// Token: 0x04000223 RID: 547
		private Color x31d8d8063d8f3c74 = Color.FromArgb(255, 255, 255);

		// Token: 0x04000224 RID: 548
		private Color x6cefc7bb40cf5d76 = Color.FromArgb(255, 255, 255);

		// Token: 0x04000225 RID: 549
		private Color x05d7ee48911d8dba = Color.FromArgb(252, 252, 254);

		// Token: 0x04000226 RID: 550
		private Color x51e4f0f96f7fc653 = Color.FromArgb(244, 243, 248);

		// Token: 0x04000227 RID: 551
		private Color xb9bbdee8e645fa7b = Color.FromArgb(216, 216, 228);

		// Token: 0x04000228 RID: 552
		private Color xd96ec9f38c2f034d = Color.FromArgb(243, 242, 247);

		// Token: 0x04000229 RID: 553
		private Color x1b76e612db274a07 = Color.FromArgb(255, 255, 255);

		// Token: 0x0400022A RID: 554
		private double x567d5545e28c9c83 = 0.05;

		// Token: 0x0400022B RID: 555
		private double x6093764f4f59f8ca;
	}
}

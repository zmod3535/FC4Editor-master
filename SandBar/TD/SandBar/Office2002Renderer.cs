using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200005C RID: 92
	public class Office2002Renderer : OfficeRendererBase, IMenuRenderer, IToolBarRenderer, IComboBoxRenderer, IContainerBarRenderer, IDisposable
	{
		// Token: 0x0600045F RID: 1119 RVA: 0x00017C24 File Offset: 0x00016C24
		public Office2002Renderer()
		{
			if (-1 != 0)
			{
				goto IL_161;
			}
			IL_147:
			ColorMatrix colorMatrix = new ColorMatrix();
			colorMatrix.Matrix33 = 0.7f;
			this._xd650f36d665a23d6 = new ImageAttributes();
			this._xd650f36d665a23d6.SetColorMatrix(colorMatrix);
			colorMatrix = new ColorMatrix();
			colorMatrix.Matrix00 = 0.3f;
			colorMatrix.Matrix01 = 0.3f;
			colorMatrix.Matrix02 = 0.3f;
			if (!false)
			{
				colorMatrix.Matrix10 = 0.59f;
				colorMatrix.Matrix11 = 0.59f;
				colorMatrix.Matrix12 = 0.59f;
				colorMatrix.Matrix20 = 0.11f;
				colorMatrix.Matrix21 = 0.11f;
				colorMatrix.Matrix22 = 0.11f;
				colorMatrix.Matrix33 = 0.3f;
				this._x2d1501e8851d3685 = new ImageAttributes();
				this._x2d1501e8851d3685.SetColorMatrix(colorMatrix);
				colorMatrix = new ColorMatrix();
				colorMatrix.Matrix33 = 0.25f;
				this._xd8ae0b91d1e031da = new ImageAttributes();
				ColorMap colorMap = new ColorMap();
				colorMap.OldColor = Color.White;
				colorMap.NewColor = Color.Black;
				this._xd8ae0b91d1e031da.SetRemapTable(new ColorMap[]
				{
					colorMap
				});
				this._xd8ae0b91d1e031da.SetGamma(10f);
				this._xd8ae0b91d1e031da.SetColorMatrix(colorMatrix);
				if (-2147483648 == 0)
				{
					return;
				}
				this.CalculateBaseColors();
			}
			if (!true)
			{
				goto IL_161;
			}
			return;
			IL_161:
			this.xf0bf99734d2ade46 = (TextFormatFlags.NoClipping | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping);
			this.xf0bf99734d2ade46 = this.xf0bf99734d2ade46;
			this.x2b2bc697a2d44a49 = (TextFormatFlags.NoClipping | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping);
			this.x2b2bc697a2d44a49 |= (TextFormatFlags.NoPrefix | TextFormatFlags.Right);
			goto IL_147;
		}

		// Token: 0x06000460 RID: 1120
		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x06000461 RID: 1121
		[DllImport("user32.dll")]
		private static extern bool GetIconInfo(IntPtr hIcon, out Office2002Renderer.x427414780a515181 piconinfo);

		// Token: 0x06000462 RID: 1122 RVA: 0x00017DC8 File Offset: 0x00016DC8
		internal static Bitmap x9507a49742823ba9(Icon xd96f9d23046d8705)
		{
			Office2003Renderer.x7fb2e1ce54a27086();
			return xd96f9d23046d8705.ToBitmap();
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x00017DD8 File Offset: 0x00016DD8
		internal ImageAttributes x45a4d3ef4697069b
		{
			get
			{
				return this._x2d1501e8851d3685;
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x00017DE0 File Offset: 0x00016DE0
		internal ImageAttributes x5680416382e412a2
		{
			get
			{
				return this.x173a6504bf720fa2;
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00017DE8 File Offset: 0x00016DE8
		public virtual void DrawSystemButton(Graphics graphics, Rectangle bounds, ToolBarGlyphType glyphType, DrawItemState state, bool floating)
		{
			this.DrawButtonHighlight(graphics, bounds, state, false);
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				base.xc64a3464af8e94fb(graphics, bounds, glyphType, SystemColors.ControlDarkDark);
				return;
			}
			base.xc64a3464af8e94fb(graphics, bounds, glyphType, SystemColors.ControlText);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x00017E1C File Offset: 0x00016E1C
		public override void Dispose()
		{
			base.Dispose();
			this._xd650f36d665a23d6.Dispose();
			this._x2d1501e8851d3685.Dispose();
			this._xd8ae0b91d1e031da.Dispose();
			this.x173a6504bf720fa2.Dispose();
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00017E50 File Offset: 0x00016E50
		protected override void CalculateBaseColors()
		{
			if (this.x173a6504bf720fa2 != null)
			{
				this.x173a6504bf720fa2.Dispose();
			}
			this.x173a6504bf720fa2 = this.xc80ec29a20ea84d0();
			if (SystemInformation.HighContrast)
			{
				this._x824bfb65f06865bd = SystemColors.Control;
				this._xfca0e3085d5a7f42 = SystemColors.Highlight;
				this._xace53b20b987446c = SystemColors.Menu;
			}
			else
			{
				this._x824bfb65f06865bd = Office2002Renderer.InterpolateColors(SystemColors.Control, SystemColors.Window, 0.15f);
				this._xfca0e3085d5a7f42 = SystemColors.Highlight;
				this._xace53b20b987446c = Office2002Renderer.InterpolateColors(SystemColors.Window, SystemColors.Control, 0.15f);
			}
			this.CalculateDerivedColors();
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00017EEC File Offset: 0x00016EEC
		private ImageAttributes xc80ec29a20ea84d0()
		{
			ImageAttributes imageAttributes = new ImageAttributes();
			imageAttributes.SetRemapTable(new ColorMap[]
			{
				new ColorMap
				{
					OldColor = SystemColors.Control,
					NewColor = SystemColors.ControlText
				},
				new ColorMap
				{
					OldColor = SystemColors.ControlText,
					NewColor = SystemColors.Control
				}
			});
			return imageAttributes;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00017F50 File Offset: 0x00016F50
		protected virtual void CalculateDerivedColors()
		{
			if (SystemInformation.HighContrast)
			{
				this.xa3df428879b91e08 = SystemColors.InactiveBorder;
				this.x97c76c2a1eb3d2d4 = SystemColors.InactiveCaption;
				this.x89c045cb3c3c914f = SystemColors.InactiveCaptionText;
			}
			else
			{
				this.xa3df428879b91e08 = Office2002Renderer.InterpolateColors(SystemColors.ControlDark, SystemColors.ControlDarkDark, 0.48f);
				this.x97c76c2a1eb3d2d4 = SystemColors.ControlDark;
				this.x89c045cb3c3c914f = Office2002Renderer.InterpolateColors(SystemColors.ControlDarkDark, SystemColors.ControlText, 0.4f);
			}
			this._x342ecbecb7467fe7 = Office2002Renderer.InterpolateColors(SystemColors.ControlDark, SystemColors.Control, 0.39f);
			if (SystemInformation.HighContrast)
			{
				this._x06caab8f6342de8c = SystemColors.Menu;
				this._x20c63f79cff12f42 = SystemColors.MenuText;
			}
			else
			{
				this._x06caab8f6342de8c = Office2002Renderer.InterpolateColors(SystemColors.Window, SystemColors.Control, 0.8f);
				this._x20c63f79cff12f42 = Office2002Renderer.InterpolateColors(SystemColors.Control, Color.Black, 0.42f);
			}
			this.x06bf8ce3d272cd4e(this._xfca0e3085d5a7f42);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00018040 File Offset: 0x00017040
		private void x06bf8ce3d272cd4e(Color x6f860ed2fc55db9e)
		{
			if (SystemInformation.HighContrast)
			{
				this._x7d13b39488471a38 = SystemColors.Highlight;
				this._x42a72bd7ef3c55b5 = SystemColors.Highlight;
				this._x7481c5feb85f6b85 = SystemColors.Highlight;
				this._x5bdc84993d5749e9 = SystemColors.HighlightText;
				return;
			}
			Color color = Office2002Renderer.InterpolateColors(x6f860ed2fc55db9e, SystemColors.Window, 0.7f);
			color = this.x240e5f2e4511bffa(this._x824bfb65f06865bd, color, 0.05f);
			this._x7d13b39488471a38 = color;
			this._x42a72bd7ef3c55b5 = Office2002Renderer.InterpolateColors(x6f860ed2fc55db9e, SystemColors.Window, 0.5f);
			this._x7481c5feb85f6b85 = Office2002Renderer.InterpolateColors(x6f860ed2fc55db9e, SystemColors.Window, 0.85f);
			this._x5bdc84993d5749e9 = x6f860ed2fc55db9e;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x000180E0 File Offset: 0x000170E0
		private Color x240e5f2e4511bffa(Color x6852981817631d8f, Color x6465bafcd43ff115, float x1bbdf4759107fd4a)
		{
			float brightness = x6852981817631d8f.GetBrightness();
			float brightness2 = x6465bafcd43ff115.GetBrightness();
			if (brightness2 > brightness - x1bbdf4759107fd4a)
			{
				x6465bafcd43ff115 = Office2002Renderer.InterpolateColors(x6465bafcd43ff115, Color.Black, 0.14f);
			}
			return x6465bafcd43ff115;
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00018118 File Offset: 0x00017118
		protected internal static Color InterpolateColors(Color color1, Color color2, float percentage)
		{
			int r = (int)color1.R;
			int g = (int)color1.G;
			int b = (int)color1.B;
			int r2 = (int)color2.R;
			int g2 = (int)color2.G;
			int b2 = (int)color2.B;
			byte red = Convert.ToByte((float)r + (float)(r2 - r) * percentage);
			byte green = Convert.ToByte((float)g + (float)(g2 - g) * percentage);
			byte blue = Convert.ToByte((float)b + (float)(b2 - b) * percentage);
			return Color.FromArgb((int)red, (int)green, (int)blue);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x00018194 File Offset: 0x00017194
		protected internal static Color IncreaseBrightness(Color color1, int level)
		{
			int r = (int)color1.R;
			int g = (int)color1.G;
			int b = (int)color1.B;
			int num = r + level;
			int num2 = g + level;
			int num3 = b + level;
			if (num > 255)
			{
				num = 255;
			}
			if (num2 > 255)
			{
				num2 = 255;
			}
			if (num3 > 255)
			{
				num3 = 255;
			}
			byte red = Convert.ToByte(num);
			byte green = Convert.ToByte(num2);
			byte blue = Convert.ToByte(num3);
			return Color.FromArgb((int)red, (int)green, (int)blue);
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x0001821C File Offset: 0x0001721C
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00018224 File Offset: 0x00017224
		public Color StatusBarBackgroundColor
		{
			get
			{
				return this.x0940580a12ab050f;
			}
			set
			{
				this.x0940580a12ab050f = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x00018234 File Offset: 0x00017234
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x0001823C File Offset: 0x0001723C
		public virtual Color HighlightBorderColor
		{
			get
			{
				return this._xfca0e3085d5a7f42;
			}
			set
			{
				this._xfca0e3085d5a7f42 = value;
				base.CustomColors = true;
				this.x06bf8ce3d272cd4e(this._xfca0e3085d5a7f42);
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x00018258 File Offset: 0x00017258
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x00018260 File Offset: 0x00017260
		public Color BackgroundColor
		{
			get
			{
				return this._x824bfb65f06865bd;
			}
			set
			{
				this._x824bfb65f06865bd = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00018270 File Offset: 0x00017270
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x00018278 File Offset: 0x00017278
		public Color MenuBackgroundColor
		{
			get
			{
				return this._xace53b20b987446c;
			}
			set
			{
				this._xace53b20b987446c = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00018288 File Offset: 0x00017288
		private void x68147b43ffdf95d9(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, bool x2fef7d841879a711)
		{
			Pen pen = SystemPens.ControlText;
			Brush brush = SystemBrushes.ControlText;
			if (!x2fef7d841879a711)
			{
				pen = SystemPens.ControlDark;
				brush = SystemBrushes.ControlDark;
			}
			int num = xda73fcb97c77d998.Y + xda73fcb97c77d998.Height / 2 - 1;
			int num2 = xda73fcb97c77d998.X + xda73fcb97c77d998.Width - 5;
			x41347a961b838962.DrawLine(pen, num2, num, num2 + 4, num);
			x41347a961b838962.DrawLine(pen, num2 + 1, num + 1, num2 + 3, num + 1);
			x41347a961b838962.FillRectangle(brush, num2 + 2, num + 2, 1, 1);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00018308 File Offset: 0x00017308
		internal void x0e69010b63cb0f9b(Graphics x41347a961b838962, int x08db3aeabb253cb1, int x1e218ceaee1bb583, Color x6c50a99faab7d741)
		{
			using (Pen pen = new Pen(x6c50a99faab7d741))
			{
				x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1, x1e218ceaee1bb583, x08db3aeabb253cb1, x1e218ceaee1bb583 + 4);
				x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1 - 1, x1e218ceaee1bb583 + 1, x08db3aeabb253cb1 - 1, x1e218ceaee1bb583 + 3);
				x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1 - 2, x1e218ceaee1bb583 + 2, x08db3aeabb253cb1, x1e218ceaee1bb583 + 2);
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00018378 File Offset: 0x00017378
		internal void x68147b43ffdf95d9(Graphics x41347a961b838962, int x08db3aeabb253cb1, int x1e218ceaee1bb583, Color x6c50a99faab7d741)
		{
			using (Pen pen = new Pen(x6c50a99faab7d741))
			{
				x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1, x1e218ceaee1bb583, x08db3aeabb253cb1 + 4, x1e218ceaee1bb583);
				x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583 + 1, x08db3aeabb253cb1 + 3, x1e218ceaee1bb583 + 1);
				x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1 + 2, x1e218ceaee1bb583 + 2, x08db3aeabb253cb1 + 2, x1e218ceaee1bb583);
			}
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x000183E8 File Offset: 0x000173E8
		internal void xc856767407074e62(Graphics x41347a961b838962, int x08db3aeabb253cb1, int x1e218ceaee1bb583, Color x6c50a99faab7d741)
		{
			using (Pen pen = new Pen(x6c50a99faab7d741))
			{
				x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1, x1e218ceaee1bb583, x08db3aeabb253cb1, x1e218ceaee1bb583 + 4);
				x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583 + 1, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583 + 3);
				x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1 + 2, x1e218ceaee1bb583 + 2, x08db3aeabb253cb1, x1e218ceaee1bb583 + 2);
			}
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x00018458 File Offset: 0x00017458
		public override void DrawButtonHighlight(Graphics graphics, Rectangle bounds, DrawItemState state, bool dropDown)
		{
			bool flag = (state & DrawItemState.HotLight) == DrawItemState.HotLight || (state & DrawItemState.Selected) == DrawItemState.Selected || (state & DrawItemState.Checked) == DrawItemState.Checked;
			if (flag)
			{
				using (Pen pen = new Pen(this._x5bdc84993d5749e9))
				{
					if ((state & DrawItemState.Selected) == DrawItemState.Selected)
					{
						using (SolidBrush solidBrush = new SolidBrush(this._x42a72bd7ef3c55b5))
						{
							graphics.FillRectangle(solidBrush, bounds);
							goto IL_A2;
						}
					}
					if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
					{
						using (SolidBrush solidBrush2 = new SolidBrush(this._x7d13b39488471a38))
						{
							graphics.FillRectangle(solidBrush2, bounds);
							goto IL_A2;
						}
					}
					if ((state & DrawItemState.Checked) == DrawItemState.Checked)
					{
						using (SolidBrush solidBrush3 = new SolidBrush(this._x7481c5feb85f6b85))
						{
							graphics.FillRectangle(solidBrush3, bounds);
						}
					}
					IL_A2:
					graphics.DrawRectangle(pen, bounds);
				}
			}
			if (dropDown && flag)
			{
				bounds.Offset(bounds.Width - 11, 0);
				bounds.Width -= bounds.Width - 11;
				using (SolidBrush solidBrush4 = new SolidBrush(this._x7d13b39488471a38))
				{
					graphics.FillRectangle(solidBrush4, bounds);
				}
				using (Pen pen2 = new Pen(this._x5bdc84993d5749e9))
				{
					graphics.DrawRectangle(pen2, bounds);
				}
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0001862C File Offset: 0x0001762C
		protected override void DrawTextCore(string text, Graphics graphics, Font font, Color color, DrawItemState state, Rectangle bounds, TextFormatFlags textFormat)
		{
			if ((state & DrawItemState.Disabled) == DrawItemState.Disabled)
			{
				TextRenderer.DrawText(graphics, text, font, bounds, SystemColors.GrayText, textFormat);
				return;
			}
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				TextRenderer.DrawText(graphics, text, font, bounds, SystemColors.ControlDarkDark, textFormat);
				return;
			}
			TextRenderer.DrawText(graphics, text, font, bounds, color, textFormat);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0001867C File Offset: 0x0001767C
		public override void DrawIconCore(Icon icon, Graphics graphics, DrawItemState state, Rectangle bounds)
		{
			if ((state & DrawItemState.Disabled) == DrawItemState.Disabled)
			{
				using (Bitmap bitmap = Office2002Renderer.x9507a49742823ba9(icon))
				{
					graphics.DrawImage(bitmap, bounds, 0, 0, bounds.Width, bounds.Height, GraphicsUnit.Pixel, this.x45a4d3ef4697069b);
					return;
				}
			}
			if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				if ((state & DrawItemState.Selected) != DrawItemState.Selected && (state & DrawItemState.Checked) != DrawItemState.Checked)
				{
					bounds.Offset(1, 1);
					using (Bitmap bitmap2 = Bitmap.FromHicon(icon.Handle))
					{
						graphics.DrawImage(bitmap2, bounds, 0, 0, bounds.Width, bounds.Height, GraphicsUnit.Pixel, this.x45a4d3ef4697069b);
					}
					bounds.Offset(-2, -2);
				}
				graphics.DrawIconUnstretched(icon, bounds);
				return;
			}
			graphics.DrawIconUnstretched(icon, bounds);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0001876C File Offset: 0x0001776C
		public override void DrawImageCore(ImageList imageList, int imageIndex, Graphics graphics, DrawItemState state, Rectangle bounds)
		{
			using (Image image = imageList.Images[imageIndex])
			{
				this.DrawImageCore(image, graphics, state, bounds);
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x000187BC File Offset: 0x000177BC
		public override void DrawImageCore(Image image, Graphics graphics, DrawItemState state, Rectangle bounds)
		{
			if ((state & DrawItemState.Disabled) == DrawItemState.Disabled)
			{
				graphics.DrawImage(image, bounds, 0, 0, bounds.Width, bounds.Height, GraphicsUnit.Pixel, this.x45a4d3ef4697069b);
				return;
			}
			if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				if ((state & DrawItemState.Selected) != DrawItemState.Selected && (state & DrawItemState.Checked) != DrawItemState.Checked)
				{
					bounds.Offset(1, 1);
					graphics.DrawImage(image, bounds, 0, 0, bounds.Width, bounds.Height, GraphicsUnit.Pixel, this._xd8ae0b91d1e031da);
					bounds.Offset(-2, -2);
				}
				graphics.DrawImage(image, bounds);
				return;
			}
			if (SystemInformation.HighContrast)
			{
				graphics.DrawImage(image, bounds, 0, 0, bounds.Width, bounds.Height, GraphicsUnit.Pixel, this.x5680416382e412a2);
				return;
			}
			graphics.DrawImage(image, bounds, 0, 0, bounds.Width, bounds.Height, GraphicsUnit.Pixel, this._xd650f36d665a23d6);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0001888C File Offset: 0x0001788C
		public virtual void StartToolBarRender(ToolBar toolbar, bool vertical, bool rightToLeft)
		{
			this.xae3b2752a89e7464 = TextFormatFlags.Default;
			this.xae3b2752a89e7464 |= TextFormatFlags.NoPadding;
			if (!toolbar.x1a3934a4b789f2c3 && (!(toolbar is MenuBar) || !((MenuBar)toolbar).AlwaysShowMnemonics))
			{
				this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
			}
			this.xae3b2752a89e7464 |= TextFormatFlags.VerticalCenter;
			if (rightToLeft)
			{
				this.xae3b2752a89e7464 |= TextFormatFlags.RightToLeft;
			}
			this.xb052478c0b88955a = new Pen(this._x342ecbecb7467fe7);
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x00018920 File Offset: 0x00017920
		public virtual void FinishToolBarRender()
		{
			this.xb052478c0b88955a.Dispose();
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00018930 File Offset: 0x00017930
		public virtual void DrawMenuBarBackground(MenuBar menubar, Graphics graphics, Rectangle bounds, bool vertical)
		{
			if (menubar.Situation == ToolBarSituation.Contained)
			{
				Rectangle screenBounds = ((ToolBarContainer)menubar.Parent).Manager.GetScreenBounds();
				screenBounds = new Rectangle(menubar.PointToClient(new Point(screenBounds.X, screenBounds.Y)), screenBounds.Size);
				this.DrawContainerBackground(graphics, bounds, screenBounds);
				return;
			}
			this.DrawContainerBackground(graphics, menubar.ClientRectangle, menubar.ClientRectangle);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x000189A0 File Offset: 0x000179A0
		public virtual void DrawToolBarBackground(ToolBar toolbar, Graphics graphics, Rectangle bounds, bool vertical)
		{
			graphics.Clear(SystemColors.Control);
			bounds.Inflate(0, -1);
			using (SolidBrush solidBrush = new SolidBrush(this._x824bfb65f06865bd))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			graphics.FillRectangle(SystemBrushes.Control, new Rectangle(bounds.Right - 1, bounds.Top, 1, 1));
			graphics.FillRectangle(SystemBrushes.Control, new Rectangle(bounds.Right - 1, bounds.Bottom - 1, 1, 1));
			graphics.FillRectangle(SystemBrushes.Control, new Rectangle(bounds.X, bounds.Top, 1, 1));
			graphics.FillRectangle(SystemBrushes.Control, new Rectangle(bounds.X, bounds.Bottom - 1, 1, 1));
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x00018A88 File Offset: 0x00017A88
		public virtual void DrawToolBarGrabHandle(Graphics graphics, Rectangle bounds, bool vertical)
		{
			if (vertical)
			{
				for (int i = bounds.X; i <= bounds.Width; i += 2)
				{
					graphics.DrawLine(this.xb052478c0b88955a, i, 3, i, 5);
				}
				return;
			}
			for (int j = bounds.Y; j <= bounds.Bottom - 2; j += 2)
			{
				graphics.DrawLine(this.xb052478c0b88955a, 3, j, 5, j);
			}
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00018AEC File Offset: 0x00017AEC
		protected override void DrawOpenDropDownItem(Graphics graphics, TopLevelMenuItemBase item)
		{
			Rectangle buttonBounds = item.ButtonBounds;
			using (Pen pen = new Pen(this._x20c63f79cff12f42))
			{
				if (item.MenuDirection != MenuProjection.Left)
				{
					graphics.DrawLine(pen, buttonBounds.X, buttonBounds.Y, buttonBounds.X, buttonBounds.Y + buttonBounds.Height - 1);
				}
				if (item.MenuDirection != MenuProjection.Right)
				{
					graphics.DrawLine(pen, buttonBounds.X + buttonBounds.Width, buttonBounds.Y, buttonBounds.X + buttonBounds.Width, buttonBounds.Y + buttonBounds.Height - 1);
				}
				if (item.MenuDirection != MenuProjection.Bottom)
				{
					graphics.DrawLine(pen, buttonBounds.X, buttonBounds.Bottom, buttonBounds.X + buttonBounds.Width, buttonBounds.Bottom);
				}
				if (item.MenuDirection != MenuProjection.Top)
				{
					graphics.DrawLine(pen, buttonBounds.X, buttonBounds.Y, buttonBounds.X + buttonBounds.Width, buttonBounds.Y);
				}
			}
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00018C18 File Offset: 0x00017C18
		protected internal override void DrawButtonItem(ButtonItemBase item, Graphics graphics, Font font, bool vertical, DrawItemState state, ToolBarTextAlign textAlign)
		{
			if (item is DropDownMenuItem)
			{
				Rectangle buttonBounds = item.ButtonBounds;
				buttonBounds.Y++;
				buttonBounds.Width -= 3;
				this.x68147b43ffdf95d9(graphics, buttonBounds, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
			}
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x00018C64 File Offset: 0x00017C64
		public virtual void DrawToolBarSeparator(Graphics graphics, Rectangle bounds, bool vertical)
		{
			if (vertical)
			{
				graphics.DrawLine(this.xb052478c0b88955a, bounds.Left, bounds.Top + 1, bounds.Right - 1, bounds.Top + 1);
				return;
			}
			graphics.DrawLine(this.xb052478c0b88955a, bounds.Left + 1, bounds.Top, bounds.Left + 1, bounds.Bottom - 1);
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00018CD4 File Offset: 0x00017CD4
		private void xdd737923572c4311(Graphics x41347a961b838962, int x08db3aeabb253cb1, int x1e218ceaee1bb583)
		{
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1, x1e218ceaee1bb583, x08db3aeabb253cb1 + 2, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583, x08db3aeabb253cb1 + 3, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1, x1e218ceaee1bb583 + 4, x08db3aeabb253cb1 + 2, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583 + 4, x08db3aeabb253cb1 + 3, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1 + 4, x1e218ceaee1bb583, x08db3aeabb253cb1 + 6, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1 + 5, x1e218ceaee1bb583, x08db3aeabb253cb1 + 7, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1 + 4, x1e218ceaee1bb583 + 4, x08db3aeabb253cb1 + 6, x1e218ceaee1bb583 + 2);
			x41347a961b838962.DrawLine(Pens.Black, x08db3aeabb253cb1 + 5, x1e218ceaee1bb583 + 4, x08db3aeabb253cb1 + 7, x1e218ceaee1bb583 + 2);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00018D90 File Offset: 0x00017D90
		public virtual void DrawToolBarActionsButton(Graphics graphics, Rectangle bounds, bool vertical, bool chevron, DrawItemState state, bool designMode)
		{
			int num;
			if (vertical)
			{
				bounds.Height -= 2;
				if ((state & DrawItemState.Selected) == DrawItemState.Selected)
				{
					using (Pen pen = new Pen(this._x20c63f79cff12f42))
					{
						graphics.DrawLine(pen, bounds.X, bounds.Y, bounds.X, bounds.Y + bounds.Height - 1);
						graphics.DrawLine(pen, bounds.X, bounds.Y, bounds.X + bounds.Width, bounds.Y);
						graphics.DrawLine(pen, bounds.X, bounds.Bottom, bounds.X + bounds.Width, bounds.Bottom);
						goto IL_251;
					}
				}
				if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
				{
					this.DrawButtonHighlight(graphics, bounds, state, false);
				}
				IL_251:
				if (designMode)
				{
					num = bounds.X + bounds.Width / 2 + 4;
					int num2 = bounds.Y + bounds.Height / 2;
					graphics.DrawLine(Pens.Black, num - 2, num2, num + 2, num2);
					graphics.DrawLine(Pens.Black, num, num2 - 2, num, num2 + 2);
				}
				this.x0e69010b63cb0f9b(graphics, bounds.X + 6, bounds.Bottom - 8, Color.Black);
				return;
			}
			bounds.X++;
			bounds.Y += 2;
			bounds.Height -= 5;
			bounds.Width -= 3;
			if ((state & DrawItemState.Selected) == DrawItemState.Selected && (uint)num + (vertical ? 1U : 0U) <= 4294967295U)
			{
				using (Pen pen2 = new Pen(this._x20c63f79cff12f42))
				{
					graphics.DrawLine(pen2, bounds.X, bounds.Y, bounds.X, bounds.Y + bounds.Height - 1);
					graphics.DrawLine(pen2, bounds.X + bounds.Width, bounds.Y, bounds.X + bounds.Width, bounds.Y + bounds.Height - 1);
					graphics.DrawLine(pen2, bounds.X, bounds.Y, bounds.X + bounds.Width, bounds.Y);
					goto IL_13E;
				}
			}
			if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				this.DrawButtonHighlight(graphics, bounds, state, false);
			}
			IL_13E:
			if (designMode)
			{
				int num3 = bounds.X + bounds.Width / 2;
				int num4 = bounds.Y + bounds.Height / 2 - 4;
				graphics.DrawLine(Pens.Black, num3 - 2, num4, num3 + 2, num4);
				graphics.DrawLine(Pens.Black, num3, num4 - 2, num3, num4 + 2);
			}
			if (chevron)
			{
				this.xdd737923572c4311(graphics, bounds.X + 2, bounds.Y + 5);
			}
			this.x68147b43ffdf95d9(graphics, bounds.X + 3, bounds.Bottom - 6, Color.Black);
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x000190E4 File Offset: 0x000180E4
		public virtual void DrawContainerBackground(Graphics graphics, Rectangle bounds, Rectangle layoutBounds)
		{
			graphics.Clear(SystemColors.Control);
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x000190F4 File Offset: 0x000180F4
		public virtual void DrawFloatingFormBackground(Graphics graphics, Rectangle bounds)
		{
			using (SolidBrush solidBrush = new SolidBrush(this.xa3df428879b91e08))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			bounds.Inflate(-SystemInformation.FixedFrameBorderSize.Width, -SystemInformation.FixedFrameBorderSize.Height);
			graphics.DrawLine(SystemPens.Control, bounds.X, bounds.Y - 1, bounds.Right - 1, bounds.Y - 1);
			graphics.DrawLine(SystemPens.Control, bounds.X, bounds.Bottom, bounds.Right - 1, bounds.Bottom);
			graphics.DrawLine(SystemPens.Control, bounds.X - 1, bounds.Y, bounds.X - 1, bounds.Bottom - 1);
			graphics.DrawLine(SystemPens.Control, bounds.Right, bounds.Y, bounds.Right, bounds.Bottom - 1);
			bounds.Height = SystemInformation.ToolWindowCaptionButtonSize.Height;
			using (SolidBrush solidBrush2 = new SolidBrush(this.x97c76c2a1eb3d2d4))
			{
				graphics.FillRectangle(solidBrush2, bounds);
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0001925C File Offset: 0x0001825C
		public virtual void DrawFloatingFormText(string text, Graphics graphics, Font font, Rectangle bounds)
		{
			bounds.Inflate(-2, 0);
			using (Font font2 = new Font(font, FontStyle.Bold))
			{
				base.DrawText(text, graphics, font2, this.x89c045cb3c3c914f, DrawItemState.Default, bounds, this.ItemTextFormatFlags, false);
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x000192C0 File Offset: 0x000182C0
		// (set) Token: 0x0600048D RID: 1165 RVA: 0x000192C8 File Offset: 0x000182C8
		public override TextFormatFlags ItemTextFormatFlags
		{
			get
			{
				return this.xae3b2752a89e7464;
			}
			set
			{
				this.xae3b2752a89e7464 = value;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600048E RID: 1166 RVA: 0x000192D4 File Offset: 0x000182D4
		public override Color ShadowColor
		{
			get
			{
				return Color.Black;
			}
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x000192DC File Offset: 0x000182DC
		public override void DrawMenuActionsButton(Graphics graphics, Rectangle bounds, int marginWidth, DrawItemState state, bool designMode)
		{
			bounds = new Rectangle(bounds.X + bounds.Width / 2 - 8, bounds.Y + bounds.Height / 2 - 7, 16, 16);
			if (designMode)
			{
				graphics.DrawLine(SystemPens.ControlText, bounds.X + 8, bounds.Y + 6, bounds.X + 8, bounds.Y + 10);
				graphics.DrawLine(SystemPens.ControlText, bounds.X + 6, bounds.Y + 8, bounds.X + 10, bounds.Y + 8);
				return;
			}
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 5, bounds.Y + 4, bounds.X + 7, bounds.Y + 6);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 5, bounds.Y + 5, bounds.X + 7, bounds.Y + 7);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 5, bounds.Y + 8, bounds.X + 7, bounds.Y + 10);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 5, bounds.Y + 9, bounds.X + 7, bounds.Y + 11);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 7, bounds.Y + 6, bounds.X + 9, bounds.Y + 4);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 7, bounds.Y + 7, bounds.X + 9, bounds.Y + 5);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 7, bounds.Y + 10, bounds.X + 9, bounds.Y + 8);
			graphics.DrawLine(SystemPens.ControlText, bounds.X + 7, bounds.Y + 11, bounds.X + 9, bounds.Y + 9);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00019504 File Offset: 0x00018504
		internal void xca828f6f883d0151(Rectangle xda73fcb97c77d998, int x4c9b7a18395fc053, int x030d4163f566f83d, MenuProjection x82ae84eb9a8e4234, bool xcb35b7c43d7acd61, out int x6650a9a61c6142e3, out int xe75e43d266eef799, out int xaa76c33ed453ba57, out int x9b9be9a08b5115a8)
		{
			x6650a9a61c6142e3 = 0;
			int num;
			bool flag = (uint)num < 0U;
			if (!flag)
			{
				xe75e43d266eef799 = 0;
				xaa76c33ed453ba57 = 0;
				x9b9be9a08b5115a8 = 0;
				if (x82ae84eb9a8e4234 == MenuProjection.Left || x82ae84eb9a8e4234 == MenuProjection.Right)
				{
					xaa76c33ed453ba57 = x4c9b7a18395fc053 + 1;
					x9b9be9a08b5115a8 = xaa76c33ed453ba57 + x030d4163f566f83d - 2;
				}
				else if (xcb35b7c43d7acd61)
				{
					x6650a9a61c6142e3 = xda73fcb97c77d998.Right - x4c9b7a18395fc053 - 1;
					xe75e43d266eef799 = x6650a9a61c6142e3 - x030d4163f566f83d + 2;
				}
				else
				{
					x6650a9a61c6142e3 = x4c9b7a18395fc053 + 1;
					xe75e43d266eef799 = x6650a9a61c6142e3 + x030d4163f566f83d - 2;
				}
			}
			switch (x82ae84eb9a8e4234)
			{
			case MenuProjection.Top:
				xaa76c33ed453ba57 = (x9b9be9a08b5115a8 = xda73fcb97c77d998.Bottom);
				return;
			case MenuProjection.Bottom:
				xaa76c33ed453ba57 = (x9b9be9a08b5115a8 = xda73fcb97c77d998.Top);
				return;
			case MenuProjection.Left:
				num = (xe75e43d266eef799 = xda73fcb97c77d998.Right);
				x6650a9a61c6142e3 = num;
				return;
			case MenuProjection.Right:
				x6650a9a61c6142e3 = (xe75e43d266eef799 = xda73fcb97c77d998.Left);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x000195EC File Offset: 0x000185EC
		public override void DrawMenuBackground(Graphics graphics, Rectangle bounds, int marginWidth, int breakOffset, int breakSize, MenuProjection menuDirection, bool rightToLeft, bool rightAligned)
		{
			graphics.Clear(this._xace53b20b987446c);
			using (Pen pen = new Pen(this._x20c63f79cff12f42))
			{
				graphics.DrawRectangle(pen, bounds);
			}
			if (breakSize != 0)
			{
				int x;
				int x2;
				int y;
				int y2;
				this.xca828f6f883d0151(bounds, breakOffset, breakSize, menuDirection, rightToLeft || rightAligned, out x, out x2, out y, out y2);
				graphics.DrawLine(SystemPens.Control, x, y, x2, y2);
			}
			bounds.Inflate(-1, -1);
			bounds.Y++;
			bounds.Height--;
			if (rightToLeft)
			{
				bounds.X = bounds.Right - (marginWidth - 8) + 1;
			}
			bounds.Width = marginWidth - 8;
			using (SolidBrush solidBrush = new SolidBrush(this._x06caab8f6342de8c))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x000196F8 File Offset: 0x000186F8
		public virtual void DrawMenuItemHighlight(Graphics graphics, MenuButtonItem item, Rectangle bounds)
		{
			if (item.Enabled)
			{
				using (SolidBrush solidBrush = new SolidBrush(this._x7d13b39488471a38))
				{
					graphics.FillRectangle(solidBrush, bounds);
				}
			}
			using (Pen pen = new Pen(this._x5bdc84993d5749e9))
			{
				graphics.DrawRectangle(pen, bounds);
			}
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x00019784 File Offset: 0x00018784
		public virtual void DrawMenuItemCheck(Graphics graphics, MenuButtonItem item, bool drawCheckMark, Rectangle bounds)
		{
			Pen pen;
			if (item.Enabled)
			{
				pen = SystemPens.ControlText;
			}
			else
			{
				pen = SystemPens.ControlDark;
			}
			if (item.Enabled)
			{
				using (SolidBrush solidBrush = new SolidBrush(this._x7481c5feb85f6b85))
				{
					graphics.FillRectangle(solidBrush, bounds);
				}
				using (Pen pen2 = new Pen(this._x5bdc84993d5749e9))
				{
					graphics.DrawRectangle(pen2, bounds);
					goto IL_69;
				}
			}
			graphics.DrawRectangle(pen, bounds);
			IL_69:
			if (drawCheckMark)
			{
				int num = bounds.X + bounds.Width / 2;
				int num2 = bounds.Y + bounds.Height / 2;
				graphics.DrawLine(pen, num - 3, num2, num - 1, num2 + 2);
				graphics.DrawLine(pen, num - 3, num2 + 1, num - 1, num2 + 3);
				graphics.DrawLine(pen, num - 1, num2 + 2, num + 3, num2 - 2);
				graphics.DrawLine(pen, num - 1, num2 + 3, num + 3, num2 - 1);
			}
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000198A8 File Offset: 0x000188A8
		public override void DrawMenuItem(Graphics graphics, MenuButtonItem item, IPopupMenuHost host, int marginWidth, DrawItemState state, bool drawSpecial)
		{
			if (item.ItemImportance != ItemImportance.Low)
			{
				goto IL_68C;
			}
			bool flag2;
			bool flag = (flag2 ? 1U : 0U) < 0U;
			if (!flag)
			{
				goto IL_638;
			}
			flag = ((flag2 ? 1U : 0U) - (uint)marginWidth < 0U);
			if (!flag)
			{
				goto IL_E7;
			}
			IL_3C:
			Point[] array;
			Rectangle rectangle;
			array[0] = new Point(rectangle.X, rectangle.Y);
			array[1] = new Point(rectangle.X + 4, rectangle.Y + 4);
			array[2] = new Point(rectangle.X, rectangle.Y + 8);
			IL_A2:
			Brush brush = ((state & DrawItemState.Disabled) == DrawItemState.Disabled) ? SystemBrushes.ControlDark : SystemBrushes.ControlText;
			if (false)
			{
				goto IL_565;
			}
			if ((uint)marginWidth + (drawSpecial ? 1U : 0U) >= 0U)
			{
				graphics.FillPolygon(brush, array);
				return;
			}
			goto IL_38D;
			IL_E7:
			this.x2b2bc697a2d44a49 &= (TextFormatFlags)(-1);
			IL_F5:
			string shortcutDisplayString = item.ShortcutDisplayString;
			Rectangle bounds = rectangle;
			bounds.Y--;
			base.DrawText(item.Text, graphics, item.Font, item.ForeColor, state, bounds, this.xf0bf99734d2ade46, false);
			if (shortcutDisplayString.Length != 0)
			{
				base.DrawText(shortcutDisplayString, graphics, item.Font, item.ForeColor, state, bounds, this.x2b2bc697a2d44a49, false);
			}
			if (!item.HasVisibleSubitems())
			{
				return;
			}
			array = new Point[3];
			rectangle = item.ButtonBounds;
			rectangle.Y += rectangle.Height / 2;
			rectangle.Y -= 5;
			if (!host.RightToLeft)
			{
				rectangle.X = rectangle.Right - 12;
				goto IL_3C;
			}
			rectangle.X = 12;
			array[0] = new Point(rectangle.X, rectangle.Y);
			if ((drawSpecial ? 1U : 0U) + (drawSpecial ? 1U : 0U) >= 0U)
			{
				array[1] = new Point(rectangle.X, rectangle.Y + 8);
				array[2] = new Point(rectangle.X - 4, rectangle.Y + 4);
				goto IL_A2;
			}
			goto IL_38F;
			IL_2D3:
			rectangle = item.ButtonBounds;
			rectangle.Width -= marginWidth;
			rectangle.Width -= 16;
			if (host.RightToLeft)
			{
				rectangle.X += 18;
				this.xf0bf99734d2ade46 |= TextFormatFlags.RightToLeft;
				this.xf0bf99734d2ade46 |= TextFormatFlags.Right;
				this.xf0bf99734d2ade46 &= (TextFormatFlags)(-1);
			}
			else
			{
				rectangle.X += marginWidth - 2;
				this.xf0bf99734d2ade46 &= ~TextFormatFlags.RightToLeft;
				this.xf0bf99734d2ade46 = this.xf0bf99734d2ade46;
				this.xf0bf99734d2ade46 &= ~TextFormatFlags.Right;
				this.x2b2bc697a2d44a49 &= ~TextFormatFlags.RightToLeft;
				this.x2b2bc697a2d44a49 |= TextFormatFlags.Right;
				if (-1 == 0)
				{
					goto IL_4B4;
				}
				goto IL_61D;
			}
			IL_343:
			this.x2b2bc697a2d44a49 |= TextFormatFlags.RightToLeft;
			this.x2b2bc697a2d44a49 = this.x2b2bc697a2d44a49;
			goto IL_602;
			IL_38D:
			goto IL_3A7;
			IL_38F:
			rectangle.X = marginWidth - item.Image.Width - 11;
			IL_3A7:
			rectangle.Y -= item.Image.Height / 2 - 1;
			rectangle.Size = item.Image.Size;
			this.DrawImageCore(item.Image, graphics, state, rectangle);
			goto IL_2D3;
			IL_4B4:
			if (drawSpecial)
			{
				rectangle = new Rectangle(rectangle.X + 1, rectangle.Y + rectangle.Height / 2 - 9, 19, 19);
			}
			else
			{
				rectangle = new Rectangle(rectangle.X + 1, rectangle.Y + 1, rectangle.Height - 2, rectangle.Height - 2);
			}
			this.DrawMenuItemCheck(graphics, item, flag2 || drawSpecial, rectangle);
			IL_51E:
			Rectangle rectangle2;
			rectangle = rectangle2;
			rectangle.Y += rectangle.Height / 2;
			if ((uint)marginWidth + (uint)marginWidth < 0U)
			{
				goto IL_343;
			}
			if (item.Icon != null)
			{
				if (!host.RightToLeft)
				{
					rectangle.X = marginWidth - item.IconSize.Width - 11;
					goto IL_597;
				}
			}
			else if (item.Image != null)
			{
				if (host.RightToLeft)
				{
					rectangle.X = rectangle.Right - marginWidth + 14;
					goto IL_38D;
				}
				goto IL_38F;
			}
			else
			{
				if (host.MenuImageList != null && item.ImageIndex >= 0 && item.ImageIndex < host.MenuImageList.Images.Count)
				{
					if (host.RightToLeft)
					{
						rectangle.X = rectangle.Right - marginWidth + 14;
					}
					else
					{
						rectangle.X = marginWidth - host.MenuImageList.ImageSize.Width - 11;
					}
					rectangle.Y -= host.MenuImageList.ImageSize.Height / 2 - 1;
					rectangle.Size = host.MenuImageList.ImageSize;
					this.DrawImageCore(host.MenuImageList, item.ImageIndex, graphics, state, rectangle);
					goto IL_2D3;
				}
				goto IL_2D3;
			}
			IL_565:
			rectangle.X = rectangle.Right - marginWidth + 14;
			IL_597:
			rectangle.Y -= item.IconSize.Height / 2 - 1;
			rectangle.Size = item.IconSize;
			try
			{
				using (Icon icon = new Icon(item.Icon, item.IconSize))
				{
					this.DrawIconCore(icon, graphics, state, rectangle);
				}
				goto IL_2D3;
			}
			catch
			{
				goto IL_2D3;
			}
			IL_602:
			flag = ((drawSpecial ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U);
			if (!flag)
			{
				this.x2b2bc697a2d44a49 &= ~TextFormatFlags.Right;
				goto IL_F5;
			}
			IL_61D:
			flag = ((flag2 ? 1U : 0U) - (uint)marginWidth < 0U);
			if (!flag)
			{
				goto IL_E7;
			}
			IL_638:
			rectangle = item.ButtonBounds;
			if (host.RightToLeft)
			{
				rectangle.X = rectangle.Right - (marginWidth - 8);
			}
			rectangle.Width = marginWidth - 8;
			using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(30, this.ShadowColor)))
			{
				graphics.FillRectangle(solidBrush, rectangle);
			}
			IL_68C:
			rectangle = item.ButtonBounds;
			rectangle.X++;
			rectangle.Width -= 3;
			rectangle.Height -= 2;
			if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				this.DrawMenuItemHighlight(graphics, item, rectangle);
			}
			rectangle2 = rectangle;
			if (!item.Checked)
			{
				goto IL_51E;
			}
			flag2 = (item.Icon == null && item.Image == null && (host.MenuImageList == null || item.ImageIndex < 0 || item.ImageIndex > host.MenuImageList.Images.Count - 1));
			if (host.RightToLeft)
			{
				rectangle.X = rectangle.Right - (rectangle.Height - 2) - 2;
				goto IL_4B4;
			}
			goto IL_4B4;
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0001A054 File Offset: 0x00019054
		public override void DrawMenuSeparator(Graphics graphics, Rectangle bounds, int marginWidth, bool rightToLeft)
		{
			using (Pen pen = new Pen(this._x342ecbecb7467fe7))
			{
				if (rightToLeft)
				{
					graphics.DrawLine(pen, bounds.Left, bounds.Y + 1, bounds.Right - marginWidth - 1, bounds.Y + 1);
				}
				else
				{
					graphics.DrawLine(pen, marginWidth + 1, bounds.Y + 1, bounds.Right - 1, bounds.Y + 1);
				}
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x0001A0EC File Offset: 0x000190EC
		public override TextFormatFlags MenuTextFormatFlags
		{
			get
			{
				return this.xf0bf99734d2ade46;
			}
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0001A0F4 File Offset: 0x000190F4
		internal virtual void x7f54571e6ebdb187(ComboBox xcb72be8a310acf66, Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51)
		{
			if ((x01b557925841ae51 & DrawItemState.Disabled) == DrawItemState.Disabled)
			{
				x41347a961b838962.DrawRectangle(SystemPens.ControlDark, xda73fcb97c77d998);
				return;
			}
			if ((x01b557925841ae51 & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				using (Pen pen = new Pen(this.HighlightBorderColor))
				{
					x41347a961b838962.DrawRectangle(pen, xda73fcb97c77d998);
					return;
				}
			}
			x41347a961b838962.DrawRectangle(SystemPens.Control, xda73fcb97c77d998);
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001A168 File Offset: 0x00019168
		public override void DrawComboBox(ComboBox comboBox, Graphics graphics, Rectangle bounds, DrawItemState state, bool rightToLeft)
		{
			Pen pen = new Pen(this.HighlightBorderColor);
			Rectangle rectangle;
			do
			{
				rectangle = bounds;
				rectangle.Width--;
				rectangle.Height--;
				this.x7f54571e6ebdb187(comboBox, graphics, rectangle, state);
				rectangle.Inflate(-1, -1);
				rectangle.Width -= 13;
				if (rightToLeft)
				{
					rectangle.X += 13;
				}
				if ((state & DrawItemState.Disabled) == DrawItemState.Disabled)
				{
					graphics.DrawRectangle(SystemPens.Control, rectangle);
				}
				else
				{
					using (Pen pen2 = new Pen(SystemColors.Window))
					{
						graphics.DrawRectangle(pen2, rectangle);
					}
				}
				rectangle = bounds;
				rectangle.Inflate(-1, -1);
				if (rightToLeft)
				{
					if (255 != 0)
					{
					}
					rectangle.X = SystemInformation.HorizontalScrollBarArrowWidth - (SystemInformation.HorizontalScrollBarArrowWidth - 13) + 1;
				}
				else
				{
					rectangle.X = rectangle.Right - SystemInformation.HorizontalScrollBarArrowWidth - 2;
				}
				rectangle.Width = SystemInformation.HorizontalScrollBarArrowWidth - 13 + 2;
				if ((state & DrawItemState.Disabled) == DrawItemState.Disabled)
				{
					graphics.FillRectangle(SystemBrushes.Control, rectangle);
				}
				else
				{
					graphics.FillRectangle(SystemBrushes.Window, rectangle);
				}
				rectangle = bounds;
				if (false)
				{
					return;
				}
				if (rightToLeft)
				{
					rectangle.X = 1;
				}
				else
				{
					rectangle.X = rectangle.Right - 13 - 1;
				}
				rectangle.Width = 13;
				rectangle.Inflate(0, -1);
				if ((state & DrawItemState.Disabled) == DrawItemState.Disabled)
				{
					graphics.FillRectangle(SystemBrushes.Control, rectangle);
				}
				else
				{
					if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
					{
						graphics.DrawLine(pen, rectangle.X - 1, rectangle.Y, rectangle.X - 1, rectangle.Bottom);
					}
					if ((state & DrawItemState.Selected) == DrawItemState.Selected)
					{
						this.x201cde0ed3e8c66d(graphics, rectangle, state);
					}
					else if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
					{
						this.x201cde0ed3e8c66d(graphics, rectangle, state);
					}
					else
					{
						this.x201cde0ed3e8c66d(graphics, rectangle, state);
					}
				}
				if (state != DrawItemState.Default || !(this is Office2003Renderer))
				{
					goto IL_C1;
				}
			}
			while ((rightToLeft ? 1U : 0U) + (rightToLeft ? 1U : 0U) > 4294967295U);
			rectangle.Height--;
			using (Pen pen3 = new Pen(SystemColors.Window))
			{
				graphics.DrawRectangle(pen3, rectangle);
			}
			IL_C1:
			this.xe8a798658bbfe047(graphics, rectangle, state);
			pen.Dispose();
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0001A3F4 File Offset: 0x000193F4
		internal virtual void x201cde0ed3e8c66d(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51)
		{
			if ((x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected)
			{
				using (SolidBrush solidBrush = new SolidBrush(this._x42a72bd7ef3c55b5))
				{
					x41347a961b838962.FillRectangle(solidBrush, xda73fcb97c77d998);
					return;
				}
			}
			if ((x01b557925841ae51 & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				using (SolidBrush solidBrush2 = new SolidBrush(this._x7d13b39488471a38))
				{
					x41347a961b838962.FillRectangle(solidBrush2, xda73fcb97c77d998);
					return;
				}
			}
			x41347a961b838962.FillRectangle(SystemBrushes.Window, xda73fcb97c77d998);
			xda73fcb97c77d998.Inflate(-1, -1);
			x41347a961b838962.FillRectangle(SystemBrushes.Control, xda73fcb97c77d998);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0001A4A4 File Offset: 0x000194A4
		internal virtual void xe8a798658bbfe047(Graphics x4b101060f4767186, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51)
		{
			int num = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - 2;
			int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2 - 1;
			Pen pen;
			Brush brush;
			if ((x01b557925841ae51 & DrawItemState.Disabled) == DrawItemState.Disabled)
			{
				pen = SystemPens.ControlDark;
				brush = SystemBrushes.ControlDark;
			}
			else
			{
				pen = SystemPens.ControlText;
				brush = SystemBrushes.ControlText;
			}
			x4b101060f4767186.DrawLine(pen, num, num2, num + 4, num2);
			num++;
			num2++;
			x4b101060f4767186.DrawLine(pen, num, num2, num + 2, num2);
			num++;
			num2++;
			x4b101060f4767186.FillRectangle(brush, new Rectangle(num, num2, 1, 1));
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x0001A534 File Offset: 0x00019534
		public override void DrawContainerBarText(string text, Graphics graphics, Font font, Rectangle bounds)
		{
			using (Font font2 = new Font(font, FontStyle.Bold))
			{
				base.DrawText(text, graphics, font2, SystemColors.ControlText, DrawItemState.Default, bounds, this.ItemTextFormatFlags, false);
			}
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x0001A58C File Offset: 0x0001958C
		public override void DrawContainerBarClientBackground(Graphics graphics, Rectangle bounds)
		{
			using (SolidBrush solidBrush = new SolidBrush(this._xace53b20b987446c))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x0600049D RID: 1181 RVA: 0x0001A5D8 File Offset: 0x000195D8
		public override void DrawContainerBarBackground(ContainerBar containerBar, Graphics graphics, Rectangle bounds, Rectangle clientBounds)
		{
			graphics.Clear(SystemColors.Control);
			bounds.Inflate(-2, -2);
			graphics.DrawLine(SystemPens.ControlLightLight, bounds.X + 1, bounds.Y, bounds.Right - 2, bounds.Y);
			graphics.DrawLine(SystemPens.ControlLightLight, bounds.X, bounds.Y + 1, bounds.X, bounds.Bottom - 2);
			graphics.DrawLine(SystemPens.ControlLightLight, bounds.Right - 1, bounds.Y + 1, bounds.Right - 1, bounds.Bottom - 2);
			graphics.DrawLine(SystemPens.ControlLightLight, bounds.X + 1, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
			bounds.Inflate(-1, -1);
			using (SolidBrush solidBrush = new SolidBrush(this._xace53b20b987446c))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x0001A6F4 File Offset: 0x000196F4
		public override void DrawContainerBarTitleBarBackground(Graphics graphics, Rectangle bounds, bool active)
		{
			if (active)
			{
				using (SolidBrush solidBrush = new SolidBrush(this._x7d13b39488471a38))
				{
					graphics.FillRectangle(solidBrush, bounds);
					return;
				}
			}
			graphics.FillRectangle(SystemBrushes.Control, bounds);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x0001A74C File Offset: 0x0001974C
		internal void xaa6185ac058231c2(Rectangle xda73fcb97c77d998, Size xafc895301c3c68ee, int x15010dfcc250b42a, int xce4841aa88acc125, out Rectangle xb48529af1739dd06, out Rectangle x4bc955bd8cfefd39, out Rectangle x21ed2ecc088ef4e4, out Rectangle x446b42c2caf105ce)
		{
			xda73fcb97c77d998.Inflate(-xce4841aa88acc125, -xce4841aa88acc125);
			xb48529af1739dd06 = xda73fcb97c77d998;
			xb48529af1739dd06.Height = x15010dfcc250b42a;
			x4bc955bd8cfefd39 = xda73fcb97c77d998;
			x4bc955bd8cfefd39.Y += x15010dfcc250b42a;
			x4bc955bd8cfefd39.Height -= x15010dfcc250b42a;
			x21ed2ecc088ef4e4 = x4bc955bd8cfefd39;
			x4bc955bd8cfefd39.Height = xafc895301c3c68ee.Height;
			if (xafc895301c3c68ee.Width < x4bc955bd8cfefd39.Width)
			{
				x4bc955bd8cfefd39.Width = xafc895301c3c68ee.Width;
			}
			x446b42c2caf105ce = Rectangle.Empty;
			x21ed2ecc088ef4e4.Y += xafc895301c3c68ee.Height;
			x21ed2ecc088ef4e4.Height -= xafc895301c3c68ee.Height;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x0001A80C File Offset: 0x0001980C
		public override void DrawContainerBarToolBarBackground(Graphics graphics, Rectangle bounds)
		{
			using (SolidBrush solidBrush = new SolidBrush(this._x824bfb65f06865bd))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x0001A858 File Offset: 0x00019858
		public override void LayoutContainerBar(Rectangle bounds, Size toolbarSize, out Rectangle titlebarBounds, out Rectangle toolbarBounds, out Rectangle clientBounds, out Rectangle gripperBounds)
		{
			this.xaa6185ac058231c2(bounds, toolbarSize, SystemInformation.ToolWindowCaptionHeight, 2, out titlebarBounds, out toolbarBounds, out clientBounds, out gripperBounds);
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x0001A87C File Offset: 0x0001987C
		public virtual void DrawStatusBarBackground(StatusBar statusBar, Graphics graphics, Rectangle bounds, bool vertical)
		{
			graphics.Clear(this.x0940580a12ab050f);
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x0001A88C File Offset: 0x0001988C
		protected internal override void DrawStatusBarItem(StatusBarItem item, Graphics graphics, Font font, bool vertical, DrawItemState state)
		{
			if (item.ShowBorder)
			{
				Rectangle buttonInnerBounds = item.ButtonInnerBounds;
				buttonInnerBounds.Width--;
				buttonInnerBounds.Height--;
				graphics.DrawRectangle(SystemPens.ControlDark, buttonInnerBounds);
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x0001A8D4 File Offset: 0x000198D4
		public virtual void DrawStatusBarGripper(StatusBar statusBar, Graphics graphics, Rectangle bounds, bool vertical)
		{
			ControlPaint.DrawSizeGrip(graphics, SystemColors.Control, bounds);
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0001A8E4 File Offset: 0x000198E4
		public override string ToString()
		{
			return "Office 2002";
		}

		// Token: 0x040001F0 RID: 496
		private const int xaf8885a4dc0e45e7 = 13;

		// Token: 0x040001F1 RID: 497
		internal TextFormatFlags xae3b2752a89e7464;

		// Token: 0x040001F2 RID: 498
		private TextFormatFlags xf0bf99734d2ade46;

		// Token: 0x040001F3 RID: 499
		private TextFormatFlags x2b2bc697a2d44a49;

		// Token: 0x040001F4 RID: 500
		private Color xa3df428879b91e08;

		// Token: 0x040001F5 RID: 501
		private Color x97c76c2a1eb3d2d4;

		// Token: 0x040001F6 RID: 502
		private Color x89c045cb3c3c914f;

		// Token: 0x040001F7 RID: 503
		private Color _x342ecbecb7467fe7;

		// Token: 0x040001F8 RID: 504
		private Color _x824bfb65f06865bd;

		// Token: 0x040001F9 RID: 505
		private Color x0940580a12ab050f = SystemColors.Control;

		// Token: 0x040001FA RID: 506
		internal Color _xace53b20b987446c;

		// Token: 0x040001FB RID: 507
		private Color _x20c63f79cff12f42;

		// Token: 0x040001FC RID: 508
		private Color _x06caab8f6342de8c;

		// Token: 0x040001FD RID: 509
		private Color _xfca0e3085d5a7f42;

		// Token: 0x040001FE RID: 510
		private Color _x5bdc84993d5749e9;

		// Token: 0x040001FF RID: 511
		internal Color _x7d13b39488471a38;

		// Token: 0x04000200 RID: 512
		private Color _x7481c5feb85f6b85;

		// Token: 0x04000201 RID: 513
		private Color _x42a72bd7ef3c55b5;

		// Token: 0x04000202 RID: 514
		private Pen xb052478c0b88955a;

		// Token: 0x04000203 RID: 515
		private ImageAttributes _xd650f36d665a23d6;

		// Token: 0x04000204 RID: 516
		private ImageAttributes _x2d1501e8851d3685;

		// Token: 0x04000205 RID: 517
		private ImageAttributes _xd8ae0b91d1e031da;

		// Token: 0x04000206 RID: 518
		private ImageAttributes x173a6504bf720fa2;

		// Token: 0x0200005E RID: 94
		private struct x427414780a515181
		{
			// Token: 0x0400020B RID: 523
			public bool x1c962f245a4cc107;

			// Token: 0x0400020C RID: 524
			public int x2949b6f2ca095d22;

			// Token: 0x0400020D RID: 525
			public int x1ee4efc1758e7a60;

			// Token: 0x0400020E RID: 526
			public IntPtr x497cac8750df2865;

			// Token: 0x0400020F RID: 527
			public IntPtr xff73e9350ab314ad;
		}
	}
}

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000073 RID: 115
	public class Office2007Renderer : Office2003Renderer
	{
		// Token: 0x06000579 RID: 1401 RVA: 0x0001E3BC File Offset: 0x0001D3BC
		public Office2007Renderer()
		{
			this.ColorScheme = Office2007ColorScheme.Blue;
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0001E3D4 File Offset: 0x0001D3D4
		// (set) Token: 0x0600057B RID: 1403 RVA: 0x0001E3DC File Offset: 0x0001D3DC
		public new Office2007ColorScheme ColorScheme
		{
			get
			{
				return this.x62a65b2c0f145432;
			}
			set
			{
				if (value != this.x62a65b2c0f145432)
				{
					this.x62a65b2c0f145432 = value;
					this.CalculateBaseColors();
					this.OnRedrawRequired();
				}
			}
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0001E3FC File Offset: 0x0001D3FC
		protected override void CalculateBaseColors()
		{
			base.CalculateBaseColors();
			if (SystemInformation.HighContrast)
			{
				return;
			}
			switch (this.ColorScheme)
			{
			default:
				this.ApplyBlueColors();
				break;
			case Office2007ColorScheme.Silver:
				this.ApplySilverColors();
				break;
			case Office2007ColorScheme.Black:
				this.ApplyBlackColors();
				break;
			}
			this.CalculateDerivedColors();
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0001E44C File Offset: 0x0001D44C
		protected override Color GetAppropriateForeColor(ToolbarItemBase item, DrawItemState state)
		{
			if (SystemInformation.HighContrast)
			{
				return SystemColors.ControlText;
			}
			if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				return Color.Black;
			}
			if (item.ToolBar is MenuBar)
			{
				return this.xcfe3794d4cdeecf0;
			}
			if (item.ToolBar is StatusBar)
			{
				return this.xbfe441c7c09e8237;
			}
			return this.x4a3c7de8198d9bd2;
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0001E4A4 File Offset: 0x0001D4A4
		public override void LayoutContainerBar(Rectangle bounds, Size toolbarSize, out Rectangle titlebarBounds, out Rectangle toolbarBounds, out Rectangle clientBounds, out Rectangle gripperBounds)
		{
			base.xaa6185ac058231c2(bounds, toolbarSize, 17, 3, out titlebarBounds, out toolbarBounds, out clientBounds, out gripperBounds);
			gripperBounds = titlebarBounds;
			gripperBounds.X++;
			gripperBounds.Inflate(0, -3);
			gripperBounds.Width = 6;
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x0001E4F4 File Offset: 0x0001D4F4
		public override void DrawContainerBarTitleBarBackground(Graphics graphics, Rectangle bounds, bool active)
		{
			using (SolidBrush solidBrush = new SolidBrush(active ? this.x228685f29c2ed324 : this.x40188c0697062cee))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x0001E548 File Offset: 0x0001D548
		public override void DrawContainerBarBackground(ContainerBar containerBar, Graphics graphics, Rectangle bounds, Rectangle clientBounds)
		{
			graphics.Clear(this.x19e881e30853d890);
			bounds.Inflate(-2, -2);
			using (Pen pen = new Pen(this.x0480aedab3d89fb1))
			{
				graphics.DrawLine(pen, bounds.X + 1, bounds.Y, bounds.Right - 2, bounds.Y);
				graphics.DrawLine(pen, bounds.X, bounds.Y + 1, bounds.X, bounds.Bottom - 2);
				graphics.DrawLine(pen, bounds.Right - 1, bounds.Y + 1, bounds.Right - 1, bounds.Bottom - 2);
				graphics.DrawLine(pen, bounds.X + 1, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
			}
			bounds.Inflate(-1, -1);
			using (SolidBrush solidBrush = new SolidBrush(this.xbee96e4f5bf8ff70))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x0001E688 File Offset: 0x0001D688
		public override void DrawContainerBarClientBackground(Graphics graphics, Rectangle bounds)
		{
			graphics.Clear(this.xbee96e4f5bf8ff70);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x0001E698 File Offset: 0x0001D698
		protected virtual void ApplyBlueColors()
		{
			this.x0ea41556e91b8cce = Color.FromArgb(191, 219, 255);
			if (-2147483648 != 0)
			{
				this.xaab0a0f66214f237 = Color.FromArgb(191, 219, 255);
				this.xaaaf059eaea34d20 = Color.FromArgb(227, 239, 255);
				this.x8bb53ee85f70380e = Color.FromArgb(177, 211, 255);
				this._x273909d58eb80850 = Color.FromArgb(111, 157, 217);
				this.xa94aca0885c7a27e = Color.FromArgb(215, 232, 255);
				this.x70d4b2922d9dda6a = Color.FromArgb(111, 157, 217);
				this._xa1359fb73f86c7a4 = Color.FromArgb(111, 157, 217);
				this.xca2b1cd1d862168f = Color.FromArgb(55, 100, 160);
				this.x7f9d9df7414c77ae = Color.White;
				this.x342ecbecb7467fe7 = Color.FromArgb(154, 198, 255);
				do
				{
					this.x963e6753ab680aa3 = Color.Transparent;
				}
				while (-2147483648 == 0);
				this.x89f2076276dd61f9 = this.xaab0a0f66214f237;
				this.x1b9c0c9f53901c0e = this.x0ea41556e91b8cce;
				this.xf1bce6e83ae00185 = this.x8bb53ee85f70380e;
				this.x5f8540e2e750d7a9 = Color.Black;
				this._xace53b20b987446c = Color.FromArgb(246, 246, 246);
				this.x20a65cc0ee9cf34f = Color.FromArgb(233, 238, 238);
				this.x4a3c7de8198d9bd2 = Color.Black;
				this.xcfe3794d4cdeecf0 = Color.Black;
				this.xbee96e4f5bf8ff70 = Color.FromArgb(213, 228, 242);
				this.x19e881e30853d890 = Color.FromArgb(118, 153, 199);
				this.x0480aedab3d89fb1 = Color.FromArgb(213, 228, 242);
				this.x40188c0697062cee = Color.FromArgb(184, 207, 233);
				this.x597d93e41196fe7e = Color.FromArgb(21, 74, 147);
				this.xf1bce6e83ae00185 = this.x40188c0697062cee;
				this.xa7c0516f2bca7d2b = Color.White;
				this.x9182cf21b8e631c6 = Color.FromArgb(227, 239, 255);
				this.x9a3a348079d716bf = Color.FromArgb(173, 209, 255);
				this.xbfe441c7c09e8237 = Color.FromArgb(9, 32, 97);
				this._x5bdc84993d5749e9 = Color.FromArgb(255, 189, 105);
				this.x228685f29c2ed324 = Color.FromArgb(255, 245, 204);
				this.x2b5af2e4edc60a47 = Color.FromArgb(255, 219, 117);
				this.x59bf7e25a95a2780 = Color.FromArgb(252, 151, 61);
				this.xf3f219013bfbc916 = Color.FromArgb(255, 184, 94);
				if (false)
				{
					return;
				}
			}
			this.x546109961b6ba7ce = Color.FromArgb(255, 189, 105);
			this.x1a50e46d85acd88d = this.x546109961b6ba7ce;
			this.x154e298f2834a9ad = Color.FromArgb(255, 231, 162);
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0001E9E4 File Offset: 0x0001D9E4
		protected virtual void ApplySilverColors()
		{
			this.x0ea41556e91b8cce = Color.FromArgb(215, 215, 229);
			this.xaab0a0f66214f237 = Color.FromArgb(243, 243, 247);
			this.xaaaf059eaea34d20 = Color.FromArgb(243, 244, 250);
			this.x8bb53ee85f70380e = Color.FromArgb(153, 151, 181);
			this._x273909d58eb80850 = Color.FromArgb(84, 84, 117);
			this.xa94aca0885c7a27e = Color.FromArgb(179, 178, 200);
			this.x70d4b2922d9dda6a = Color.FromArgb(118, 116, 146);
			this._xa1359fb73f86c7a4 = Color.FromArgb(124, 124, 148);
			this.xca2b1cd1d862168f = Color.FromArgb(122, 121, 153);
			this.x7f9d9df7414c77ae = Color.White;
			this.x342ecbecb7467fe7 = Color.FromArgb(110, 109, 143);
			this.x963e6753ab680aa3 = Color.Transparent;
			this.x89f2076276dd61f9 = this.xaab0a0f66214f237;
			this.x1b9c0c9f53901c0e = this.x0ea41556e91b8cce;
			this.xf1bce6e83ae00185 = this.x8bb53ee85f70380e;
			this.x5f8540e2e750d7a9 = Color.Black;
			this._xace53b20b987446c = Color.FromArgb(253, 250, 255);
			this.x20a65cc0ee9cf34f = Color.FromArgb(239, 239, 239);
			this.x4a3c7de8198d9bd2 = Color.Black;
			this.xcfe3794d4cdeecf0 = Color.Black;
			do
			{
				this.xbee96e4f5bf8ff70 = Color.FromArgb(238, 238, 244);
				this.x19e881e30853d890 = Color.FromArgb(158, 160, 160);
				this.x0480aedab3d89fb1 = Color.FromArgb(255, 255, 255);
				this.x40188c0697062cee = Color.FromArgb(178, 183, 194);
				this.x597d93e41196fe7e = Color.FromArgb(76, 83, 92);
				this.xf1bce6e83ae00185 = this.x40188c0697062cee;
				this.xa7c0516f2bca7d2b = Color.FromArgb(97, 106, 118);
				this.x9182cf21b8e631c6 = Color.FromArgb(235, 238, 250);
				this.x9a3a348079d716bf = Color.FromArgb(197, 199, 209);
				this.xbfe441c7c09e8237 = Color.FromArgb(35, 38, 42);
				this._x5bdc84993d5749e9 = Color.FromArgb(255, 189, 105);
				this.x228685f29c2ed324 = Color.FromArgb(255, 245, 204);
				this.x2b5af2e4edc60a47 = Color.FromArgb(255, 219, 117);
				this.x59bf7e25a95a2780 = Color.FromArgb(252, 151, 61);
				this.xf3f219013bfbc916 = Color.FromArgb(255, 184, 94);
			}
			while (-1 == 0);
			this.x546109961b6ba7ce = Color.FromArgb(255, 189, 105);
			this.x1a50e46d85acd88d = this.x546109961b6ba7ce;
			this.x154e298f2834a9ad = Color.FromArgb(255, 231, 162);
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0001ED14 File Offset: 0x0001DD14
		protected virtual void ApplyBlackColors()
		{
			this.x0ea41556e91b8cce = Color.FromArgb(83, 83, 83);
			for (;;)
			{
				this.xaab0a0f66214f237 = Color.FromArgb(83, 83, 83);
				this.xaaaf059eaea34d20 = Color.FromArgb(205, 208, 213);
				this.x8bb53ee85f70380e = Color.FromArgb(148, 156, 166);
				this._x273909d58eb80850 = Color.FromArgb(55, 60, 67);
				this.xa94aca0885c7a27e = Color.FromArgb(178, 183, 191);
				this.x70d4b2922d9dda6a = Color.FromArgb(76, 83, 92);
				this._xa1359fb73f86c7a4 = Color.FromArgb(76, 83, 92);
				this.xca2b1cd1d862168f = Color.FromArgb(83, 83, 83);
				this.x7f9d9df7414c77ae = Color.White;
				this.x342ecbecb7467fe7 = Color.FromArgb(145, 153, 164);
				this.x963e6753ab680aa3 = Color.Transparent;
				this.x89f2076276dd61f9 = this.xaab0a0f66214f237;
				this.x1b9c0c9f53901c0e = this.x0ea41556e91b8cce;
				this.xf1bce6e83ae00185 = this.x8bb53ee85f70380e;
				this.x5f8540e2e750d7a9 = Color.Black;
				this._xace53b20b987446c = Color.FromArgb(246, 246, 246);
				if (-2 == 0)
				{
					break;
				}
				this.x20a65cc0ee9cf34f = Color.FromArgb(239, 239, 239);
				this.x4a3c7de8198d9bd2 = Color.Black;
				this.xcfe3794d4cdeecf0 = Color.White;
				this.xbee96e4f5bf8ff70 = Color.FromArgb(235, 235, 235);
				this.x19e881e30853d890 = Color.FromArgb(70, 70, 70);
				this.x0480aedab3d89fb1 = Color.FromArgb(213, 228, 242);
				this.x40188c0697062cee = Color.FromArgb(158, 160, 160);
				this.x597d93e41196fe7e = Color.FromArgb(70, 70, 70);
				if (!false)
				{
					goto IL_2EE;
				}
			}
			IL_107:
			this.xa7c0516f2bca7d2b = Color.FromArgb(97, 106, 118);
			goto IL_2F8;
			IL_2EE:
			if (4 != 0)
			{
				this.xf1bce6e83ae00185 = this.x40188c0697062cee;
				goto IL_107;
			}
			IL_2F8:
			if (!false)
			{
				this.x9182cf21b8e631c6 = Color.FromArgb(76, 83, 92);
				this.x9a3a348079d716bf = Color.FromArgb(35, 38, 42);
				this.xbfe441c7c09e8237 = Color.White;
				this._x5bdc84993d5749e9 = Color.FromArgb(255, 189, 105);
				this.x228685f29c2ed324 = Color.FromArgb(255, 245, 204);
				this.x2b5af2e4edc60a47 = Color.FromArgb(255, 219, 117);
				this.x59bf7e25a95a2780 = Color.FromArgb(252, 151, 61);
				this.xf3f219013bfbc916 = Color.FromArgb(255, 184, 94);
				this.x546109961b6ba7ce = Color.FromArgb(255, 189, 105);
				this.x1a50e46d85acd88d = this.x546109961b6ba7ce;
				this.x154e298f2834a9ad = Color.FromArgb(255, 231, 162);
			}
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0001F020 File Offset: 0x0001E020
		protected internal override void DrawStatusBarItem(StatusBarItem item, Graphics graphics, Font font, bool vertical, DrawItemState state)
		{
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0001F024 File Offset: 0x0001E024
		public override void DrawStatusBarBackground(StatusBar statusBar, Graphics graphics, Rectangle bounds, bool vertical)
		{
			if (SystemInformation.HighContrast)
			{
				base.DrawStatusBarBackground(statusBar, graphics, bounds, vertical);
				return;
			}
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, this.x9182cf21b8e631c6, this.x9a3a348079d716bf, LinearGradientMode.Vertical))
			{
				Blend blend = new Blend(4);
				blend.Positions[0] = 0f;
				blend.Factors[0] = 0f;
				blend.Positions[1] = 0.35f;
				blend.Factors[1] = 0.5f;
				blend.Positions[2] = 0.35f;
				blend.Factors[2] = 1f;
				blend.Positions[3] = 1f;
				blend.Factors[3] = 0.6f;
				linearGradientBrush.Blend = blend;
				graphics.FillRectangle(linearGradientBrush, bounds);
			}
			using (Pen pen = new Pen(this.xa7c0516f2bca7d2b))
			{
				graphics.DrawLine(pen, bounds.X, bounds.Y, bounds.Right - 1, bounds.Y);
			}
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0001F154 File Offset: 0x0001E154
		protected override void DrawMenuMargin(Graphics graphics, Rectangle bounds)
		{
			using (SolidBrush solidBrush = new SolidBrush(this.x20a65cc0ee9cf34f))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x0001F1A0 File Offset: 0x0001E1A0
		public override string ToString()
		{
			return "Office 2007";
		}

		// Token: 0x0400024E RID: 590
		private Office2007ColorScheme x62a65b2c0f145432 = (Office2007ColorScheme)(-1);

		// Token: 0x0400024F RID: 591
		private Color x20a65cc0ee9cf34f;

		// Token: 0x04000250 RID: 592
		private Color xa7c0516f2bca7d2b;

		// Token: 0x04000251 RID: 593
		private Color x9182cf21b8e631c6;

		// Token: 0x04000252 RID: 594
		private Color x9a3a348079d716bf;

		// Token: 0x04000253 RID: 595
		private Color xbfe441c7c09e8237;

		// Token: 0x04000254 RID: 596
		private Color x4a3c7de8198d9bd2;

		// Token: 0x04000255 RID: 597
		private Color xcfe3794d4cdeecf0;

		// Token: 0x04000256 RID: 598
		private Color xbee96e4f5bf8ff70;

		// Token: 0x04000257 RID: 599
		private Color x40188c0697062cee;

		// Token: 0x04000258 RID: 600
		private Color x597d93e41196fe7e;

		// Token: 0x04000259 RID: 601
		private Color x19e881e30853d890;

		// Token: 0x0400025A RID: 602
		private Color x0480aedab3d89fb1;
	}
}

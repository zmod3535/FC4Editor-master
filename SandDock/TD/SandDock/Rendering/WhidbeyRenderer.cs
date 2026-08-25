using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
	// Token: 0x02000027 RID: 39
	public class WhidbeyRenderer : ThemeAwareRendererBase
	{
		// Token: 0x06000342 RID: 834 RVA: 0x0001B0A0 File Offset: 0x0001A0A0
		public WhidbeyRenderer()
		{
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0001B0A8 File Offset: 0x0001A0A8
		public WhidbeyRenderer(WindowsColorScheme colorScheme)
		{
			base.ColorScheme = colorScheme;
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0001B0B8 File Offset: 0x0001A0B8
		// (set) Token: 0x06000345 RID: 837 RVA: 0x0001B0C0 File Offset: 0x0001A0C0
		public Color ActiveDocumentBorderColor
		{
			get
			{
				return this.x994b52371e1ca7a9;
			}
			set
			{
				this.x994b52371e1ca7a9 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000346 RID: 838 RVA: 0x0001B0D0 File Offset: 0x0001A0D0
		// (set) Token: 0x06000347 RID: 839 RVA: 0x0001B0D8 File Offset: 0x0001A0D8
		public Color InactiveDocumentBorderColor
		{
			get
			{
				return this.xcee7f670c3cc8729;
			}
			set
			{
				this.xcee7f670c3cc8729 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000348 RID: 840 RVA: 0x0001B0E8 File Offset: 0x0001A0E8
		// (set) Token: 0x06000349 RID: 841 RVA: 0x0001B0F0 File Offset: 0x0001A0F0
		public Color DocumentStripBackgroundColor1
		{
			get
			{
				return this.xd1edc46cbe592968;
			}
			set
			{
				this.xd1edc46cbe592968 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600034A RID: 842 RVA: 0x0001B100 File Offset: 0x0001A100
		// (set) Token: 0x0600034B RID: 843 RVA: 0x0001B108 File Offset: 0x0001A108
		public Color DocumentStripBackgroundColor2
		{
			get
			{
				return this.x43b04232fee73e15;
			}
			set
			{
				this.x43b04232fee73e15 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x0600034C RID: 844 RVA: 0x0001B118 File Offset: 0x0001A118
		// (set) Token: 0x0600034D RID: 845 RVA: 0x0001B120 File Offset: 0x0001A120
		public Color ActiveHotButtonBorderColor
		{
			get
			{
				return this.x4dea88af4363a77b;
			}
			set
			{
				this.x4dea88af4363a77b = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600034E RID: 846 RVA: 0x0001B130 File Offset: 0x0001A130
		// (set) Token: 0x0600034F RID: 847 RVA: 0x0001B138 File Offset: 0x0001A138
		public Color ActiveHotButtonBackgroundColor
		{
			get
			{
				return this.x2e1ef9b84f7ac14b;
			}
			set
			{
				this.x2e1ef9b84f7ac14b = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000350 RID: 848 RVA: 0x0001B148 File Offset: 0x0001A148
		// (set) Token: 0x06000351 RID: 849 RVA: 0x0001B150 File Offset: 0x0001A150
		public Color ActiveButtonBorderColor
		{
			get
			{
				return this.x4056384aa48da1d1;
			}
			set
			{
				this.x4056384aa48da1d1 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000352 RID: 850 RVA: 0x0001B160 File Offset: 0x0001A160
		// (set) Token: 0x06000353 RID: 851 RVA: 0x0001B168 File Offset: 0x0001A168
		public Color ActiveButtonBackgroundColor
		{
			get
			{
				return this.xb2b9c364e92661dd;
			}
			set
			{
				this.xb2b9c364e92661dd = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000354 RID: 852 RVA: 0x0001B178 File Offset: 0x0001A178
		// (set) Token: 0x06000355 RID: 853 RVA: 0x0001B180 File Offset: 0x0001A180
		public Color InactiveButtonBorderColor
		{
			get
			{
				return this.x503b1fd8602da9a9;
			}
			set
			{
				this.x503b1fd8602da9a9 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000356 RID: 854 RVA: 0x0001B190 File Offset: 0x0001A190
		// (set) Token: 0x06000357 RID: 855 RVA: 0x0001B198 File Offset: 0x0001A198
		public Color InactiveButtonBackgroundColor
		{
			get
			{
				return this.x693536a88ebe8191;
			}
			set
			{
				this.x693536a88ebe8191 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000358 RID: 856 RVA: 0x0001B1A8 File Offset: 0x0001A1A8
		// (set) Token: 0x06000359 RID: 857 RVA: 0x0001B1B0 File Offset: 0x0001A1B0
		public Color ActiveTitleBarForegroundColor
		{
			get
			{
				return this.x6b97fa649c9b3a44;
			}
			set
			{
				this.x6b97fa649c9b3a44 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600035A RID: 858 RVA: 0x0001B1C0 File Offset: 0x0001A1C0
		// (set) Token: 0x0600035B RID: 859 RVA: 0x0001B1C8 File Offset: 0x0001A1C8
		public Color ActiveTitleBarBackgroundColor2
		{
			get
			{
				return this.xebb7eaf00d600976;
			}
			set
			{
				this.xebb7eaf00d600976 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600035C RID: 860 RVA: 0x0001B1D8 File Offset: 0x0001A1D8
		// (set) Token: 0x0600035D RID: 861 RVA: 0x0001B1E0 File Offset: 0x0001A1E0
		public Color ActiveTitleBarBackgroundColor1
		{
			get
			{
				return this.x2d5bde28a1e8ae90;
			}
			set
			{
				this.x2d5bde28a1e8ae90 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600035E RID: 862 RVA: 0x0001B1F0 File Offset: 0x0001A1F0
		// (set) Token: 0x0600035F RID: 863 RVA: 0x0001B1F8 File Offset: 0x0001A1F8
		public Color InactiveTitleBarForegroundColor
		{
			get
			{
				return this.x9a7470f809ffee0d;
			}
			set
			{
				this.x9a7470f809ffee0d = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000360 RID: 864 RVA: 0x0001B208 File Offset: 0x0001A208
		// (set) Token: 0x06000361 RID: 865 RVA: 0x0001B210 File Offset: 0x0001A210
		public Color InactiveTitleBarBackgroundColor
		{
			get
			{
				return this.x8e2e7f87608d5b3b;
			}
			set
			{
				this.x8e2e7f87608d5b3b = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000362 RID: 866 RVA: 0x0001B220 File Offset: 0x0001A220
		// (set) Token: 0x06000363 RID: 867 RVA: 0x0001B228 File Offset: 0x0001A228
		public Color ActiveDocumentShadowColor
		{
			get
			{
				return this.x9196c174a89a4ce4;
			}
			set
			{
				this.x9196c174a89a4ce4 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000364 RID: 868 RVA: 0x0001B238 File Offset: 0x0001A238
		// (set) Token: 0x06000365 RID: 869 RVA: 0x0001B240 File Offset: 0x0001A240
		public Color InactiveDocumentShadowColor
		{
			get
			{
				return this.x0e8b6412ec502dbf;
			}
			set
			{
				this.x0e8b6412ec502dbf = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0001B250 File Offset: 0x0001A250
		// (set) Token: 0x06000367 RID: 871 RVA: 0x0001B258 File Offset: 0x0001A258
		public Color InactiveDocumentHighlightColor
		{
			get
			{
				return this.x0b2889b8ff5ec580;
			}
			set
			{
				this.x0b2889b8ff5ec580 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000368 RID: 872 RVA: 0x0001B268 File Offset: 0x0001A268
		// (set) Token: 0x06000369 RID: 873 RVA: 0x0001B270 File Offset: 0x0001A270
		public Color ActiveDocumentHighlightColor
		{
			get
			{
				return this.x80caa5727f6ffe52;
			}
			set
			{
				this.x80caa5727f6ffe52 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0001B280 File Offset: 0x0001A280
		protected override void GetColorsFromSystem()
		{
			base.GetColorsFromSystem();
			if (!SystemInformation.HighContrast)
			{
				if (3 == 0)
				{
					return;
				}
				this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
				this.x0b2889b8ff5ec580 = SystemColors.ControlLightLight;
				this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
				this.x0e8b6412ec502dbf = SystemColors.Control;
				if (!false)
				{
					return;
				}
			}
			else
			{
				this.x80caa5727f6ffe52 = SystemColors.Control;
				this.x0b2889b8ff5ec580 = SystemColors.Control;
				if (false)
				{
					return;
				}
			}
			this.x9196c174a89a4ce4 = SystemColors.Control;
			this.x0e8b6412ec502dbf = SystemColors.Control;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0001B310 File Offset: 0x0001A310
		protected override void ApplyStandardColors()
		{
			if (SystemInformation.HighContrast)
			{
				goto IL_14A;
			}
			base.LayoutBackgroundColor1 = SystemColors.Control;
			base.LayoutBackgroundColor2 = RendererBase.InterpolateColors(SystemColors.Control, SystemColors.Window, 0.8f);
			this.ActiveDocumentBorderColor = SystemColors.AppWorkspace;
			this.InactiveDocumentBorderColor = SystemColors.ControlDark;
			if (!false)
			{
				goto IL_A2;
			}
			IL_0F:
			this.xb2b9c364e92661dd = Color.Transparent;
			this.x4056384aa48da1d1 = SystemColors.ControlLightLight;
			this.x2e1ef9b84f7ac14b = (SystemInformation.HighContrast ? Color.Transparent : Color.FromArgb(100, SystemColors.Control));
			this.x4dea88af4363a77b = SystemColors.ControlLightLight;
			if (2 != 0)
			{
				return;
			}
			goto IL_155;
			IL_A2:
			this.xd1edc46cbe592968 = SystemColors.Control;
			this.x43b04232fee73e15 = this.xd1edc46cbe592968;
			this.x2d5bde28a1e8ae90 = SystemColors.ActiveCaption;
			IL_C4:
			this.xebb7eaf00d600976 = SystemColors.ActiveCaption;
			this.x6b97fa649c9b3a44 = SystemColors.ActiveCaptionText;
			if (!false)
			{
				this.x8e2e7f87608d5b3b = SystemColors.InactiveCaption;
				this.x9a7470f809ffee0d = SystemColors.InactiveCaptionText;
				if (-1 == 0)
				{
					if (!false)
					{
						goto IL_126;
					}
					if (false)
					{
						goto IL_A2;
					}
					goto IL_DC;
				}
			}
			if (false)
			{
				goto IL_14A;
			}
			this.x693536a88ebe8191 = Color.Transparent;
			this.x503b1fd8602da9a9 = SystemColors.ControlLightLight;
			goto IL_0F;
			IL_DC:
			goto IL_A2;
			IL_126:
			this.ActiveDocumentBorderColor = SystemColors.ActiveCaption;
			if (!false)
			{
				this.InactiveDocumentBorderColor = SystemColors.ControlDark;
				goto IL_DC;
			}
			goto IL_C4;
			IL_14A:
			base.LayoutBackgroundColor1 = SystemColors.Control;
			IL_155:
			base.LayoutBackgroundColor2 = SystemColors.Control;
			goto IL_126;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0001B484 File Offset: 0x0001A484
		protected override void ApplyLunaBlueColors()
		{
			base.LayoutBackgroundColor1 = Color.FromArgb(229, 229, 215);
			base.LayoutBackgroundColor2 = Color.FromArgb(243, 242, 231);
			this.xd1edc46cbe592968 = Color.FromArgb(228, 226, 213);
			this.x43b04232fee73e15 = this.xd1edc46cbe592968;
			if (!false)
			{
				this.ActiveDocumentBorderColor = Color.FromArgb(127, 157, 185);
				this.InactiveDocumentBorderColor = SystemColors.ControlDark;
				this.x2d5bde28a1e8ae90 = Color.FromArgb(59, 128, 237);
				this.xebb7eaf00d600976 = Color.FromArgb(49, 106, 197);
				this.x6b97fa649c9b3a44 = Color.White;
				this.x8e2e7f87608d5b3b = Color.FromArgb(204, 199, 186);
				if (!false)
				{
					this.x9a7470f809ffee0d = Color.Black;
					if (!true)
					{
						goto IL_74;
					}
				}
				this.x693536a88ebe8191 = SystemColors.Control;
				this.x503b1fd8602da9a9 = Color.FromArgb(140, 134, 123);
				this.xb2b9c364e92661dd = Color.FromArgb(156, 182, 231);
				IL_74:
				this.x4056384aa48da1d1 = Color.FromArgb(60, 90, 170);
				this.x2e1ef9b84f7ac14b = Color.FromArgb(120, 150, 210);
				this.x4dea88af4363a77b = Color.FromArgb(60, 90, 170);
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0001B620 File Offset: 0x0001A620
		protected override void ApplyLunaOliveColors()
		{
			base.LayoutBackgroundColor1 = Color.FromArgb(229, 229, 215);
			if (-2 != 0)
			{
				goto IL_111;
			}
			IL_24:
			this.x693536a88ebe8191 = SystemColors.Control;
			this.x503b1fd8602da9a9 = Color.FromArgb(140, 134, 123);
			this.xb2b9c364e92661dd = Color.FromArgb(181, 199, 140);
			this.x4056384aa48da1d1 = Color.FromArgb(118, 128, 95);
			this.x2e1ef9b84f7ac14b = Color.FromArgb(148, 162, 115);
			this.x4dea88af4363a77b = Color.FromArgb(118, 128, 95);
			if (4 != 0)
			{
				return;
			}
			IL_111:
			base.LayoutBackgroundColor2 = Color.FromArgb(243, 242, 231);
			this.xd1edc46cbe592968 = Color.FromArgb(228, 226, 213);
			this.x43b04232fee73e15 = this.xd1edc46cbe592968;
			do
			{
				this.ActiveDocumentBorderColor = Color.FromArgb(127, 157, 185);
				this.InactiveDocumentBorderColor = SystemColors.ControlDark;
				if (false)
				{
					break;
				}
				if (false)
				{
					goto IL_17F;
				}
				this.x2d5bde28a1e8ae90 = Color.FromArgb(182, 195, 146);
				this.xebb7eaf00d600976 = Color.FromArgb(145, 160, 117);
				this.x6b97fa649c9b3a44 = Color.White;
			}
			while (false);
			this.x8e2e7f87608d5b3b = Color.FromArgb(204, 199, 186);
			this.x9a7470f809ffee0d = Color.Black;
			IL_17F:
			goto IL_24;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0001B7B4 File Offset: 0x0001A7B4
		protected override void ApplyLunaSilverColors()
		{
			base.LayoutBackgroundColor1 = Color.FromArgb(215, 215, 229);
			base.LayoutBackgroundColor2 = Color.FromArgb(243, 243, 247);
			this.xd1edc46cbe592968 = Color.FromArgb(238, 238, 238);
			if (-2 != 0)
			{
				this.x43b04232fee73e15 = this.xd1edc46cbe592968;
				this.ActiveDocumentBorderColor = Color.FromArgb(127, 157, 185);
				this.InactiveDocumentBorderColor = SystemColors.ControlDark;
				this.x2d5bde28a1e8ae90 = Color.FromArgb(211, 212, 221);
				this.xebb7eaf00d600976 = Color.FromArgb(166, 165, 191);
				this.x6b97fa649c9b3a44 = Color.Black;
				this.x8e2e7f87608d5b3b = Color.FromArgb(240, 240, 245);
				if (255 != 0)
				{
					goto IL_B3;
				}
				IL_33:
				if (true)
				{
					this.xb2b9c364e92661dd = Color.FromArgb(255, 227, 173);
					this.x4056384aa48da1d1 = Color.FromArgb(74, 73, 107);
					this.x2e1ef9b84f7ac14b = Color.FromArgb(255, 182, 115);
					this.x4dea88af4363a77b = Color.FromArgb(74, 73, 107);
					return;
				}
				IL_B3:
				this.x9a7470f809ffee0d = Color.Black;
				this.x693536a88ebe8191 = Color.FromArgb(214, 215, 222);
				this.x503b1fd8602da9a9 = Color.FromArgb(123, 125, 148);
				goto IL_33;
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0001B954 File Offset: 0x0001A954
		private void x50aa48875b838a15()
		{
			this._x066f993679e36022 = null;
			this._x3a1fa93b40743331 = null;
			this._x6defba3d5d846e0d = null;
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000370 RID: 880 RVA: 0x0001B96C File Offset: 0x0001A96C
		// (set) Token: 0x06000371 RID: 881 RVA: 0x0001B974 File Offset: 0x0001A974
		public override Size ImageSize
		{
			get
			{
				return base.ImageSize;
			}
			set
			{
				this.x50aa48875b838a15();
				base.ImageSize = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000372 RID: 882 RVA: 0x0001B984 File Offset: 0x0001A984
		public override Size TabControlPadding
		{
			get
			{
				return new Size(3, 3);
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0001B990 File Offset: 0x0001A990
		protected internal override void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds)
		{
			if (bounds.Width > 0 && 255 != 0)
			{
				while (bounds.Height > 0)
				{
					using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(bounds.X, bounds.Y - 1), new Point(bounds.X, bounds.Bottom), this.xd1edc46cbe592968, this.x43b04232fee73e15))
					{
						graphics.FillRectangle(linearGradientBrush, bounds);
					}
					using (Pen pen = new Pen(this.x994b52371e1ca7a9))
					{
						graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
						return;
					}
				}
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0001BA90 File Offset: 0x0001AA90
		internal virtual void x9271fbf5eef553db(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51, bool xb0f87b71823b1d4e)
		{
			if ((x01b557925841ae51 & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				if (xb0f87b71823b1d4e)
				{
					goto IL_18B;
				}
				if (((xb0f87b71823b1d4e ? 1U : 0U) & 0U) != 0U)
				{
					goto IL_1AE;
				}
				IL_E4:
				Color color = this.x503b1fd8602da9a9;
				Color color2 = this.x503b1fd8602da9a9;
				if (-2 == 0)
				{
					goto IL_1AE;
				}
				Color color3 = this.x693536a88ebe8191;
				IL_103:
				using (SolidBrush solidBrush = new SolidBrush(color3))
				{
					x41347a961b838962.FillRectangle(solidBrush, xda73fcb97c77d998);
					goto IL_10;
				}
				goto IL_15F;
				IL_10:
				using (Pen pen = new Pen(color))
				{
					x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
					x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
				}
				using (Pen pen2 = new Pen(color2))
				{
					x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
					x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
					return;
				}
				IL_15F:
				goto IL_E4;
				IL_18B:
				if ((x01b557925841ae51 & DrawItemState.Selected) != DrawItemState.Selected)
				{
					do
					{
						color = this.x4056384aa48da1d1;
					}
					while (8 == 0);
					color2 = this.x4056384aa48da1d1;
					color3 = this.xb2b9c364e92661dd;
					goto IL_103;
				}
				color = this.x4dea88af4363a77b;
				color2 = this.x4dea88af4363a77b;
				color3 = this.x2e1ef9b84f7ac14b;
				if (!true)
				{
					goto IL_1CC;
				}
				goto IL_103;
				IL_1AE:
				goto IL_18B;
				IL_1CC:
				goto IL_15F;
			}
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0001BCC0 File Offset: 0x0001ACC0
		protected internal override void DrawControlClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
			graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
			graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
			graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0001BD50 File Offset: 0x0001AD50
		protected internal override void DrawDocumentClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
			using (SolidBrush solidBrush = new SolidBrush(backColor))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0001BD94 File Offset: 0x0001AD94
		protected internal override void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
		{
			this.x9271fbf5eef553db(graphics, bounds, state, true);
			for (;;)
			{
				switch (buttonType)
				{
				case SandDockButtonType.Close:
					goto IL_20;
				case SandDockButtonType.Pin:
				case SandDockButtonType.WindowPosition:
					return;
				case SandDockButtonType.ScrollLeft:
					goto IL_73;
				case SandDockButtonType.ScrollRight:
					goto IL_8A;
				case SandDockButtonType.ActiveFiles:
					bounds.Inflate(1, 1);
					bounds.X--;
					if (!false)
					{
						if (!false)
						{
						}
						x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, SystemPens.ControlText);
						if (false)
						{
							return;
						}
					}
					if (false)
					{
						continue;
					}
					return;
				}
				return;
			}
			return;
			IL_20:
			x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, SystemPens.ControlText);
			if (3 != 0)
			{
				return;
			}
			return;
			IL_73:
			x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
			return;
			IL_8A:
			x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0001BE48 File Offset: 0x0001AE48
		protected internal override Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			return xa811784015ed8842.xcdfce0e0f2641503(graphics, image, this.ImageSize, text, font, base.TextFormat);
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0001BE60 File Offset: 0x0001AE60
		protected internal override Size MeasureDocumentStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			TextFormatFlags textFormatFlags = base.TextFormat;
			textFormatFlags &= ~TextFormatFlags.NoPrefix;
			int num;
			using (Font font2 = new Font(font, FontStyle.Bold))
			{
				num = TextRenderer.MeasureText(graphics, text, font2, new Size(int.MaxValue, int.MaxValue), textFormatFlags).Width;
				goto IL_17;
			}
			goto IL_96;
			IL_17:
			num += 14;
			bool flag = ((uint)num | 4U) == 0U;
			if (flag || image != null)
			{
				num += 20;
			}
			num += this.DocumentTabExtra;
			IL_96:
			return new Size(num, 0);
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600037A RID: 890 RVA: 0x0001BF28 File Offset: 0x0001AF28
		protected internal override int DocumentTabSize
		{
			get
			{
				int num = Math.Max(Control.DefaultFont.Height, this.ImageSize.Height);
				return num + 4;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x0600037B RID: 891 RVA: 0x0001BF58 File Offset: 0x0001AF58
		protected internal override int DocumentTabStripSize
		{
			get
			{
				int num = Math.Max(Control.DefaultFont.Height, this.ImageSize.Height);
				return num + 5;
			}
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0001BF88 File Offset: 0x0001AF88
		protected internal override void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds)
		{
			xa811784015ed8842.x91433b5e99eb7cac(graphics, container.BackColor);
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600037D RID: 893 RVA: 0x0001BF98 File Offset: 0x0001AF98
		protected internal override int DocumentTabExtra
		{
			get
			{
				return this.ImageSize.Width - 4;
			}
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0001BFB8 File Offset: 0x0001AFB8
		protected internal override void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			bool xb0f87b71823b1d4e = (state & DrawItemState.Checked) == DrawItemState.Checked;
			if (!false)
			{
				if ((state & DrawItemState.Selected) == DrawItemState.Selected)
				{
					xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemBrushes.ControlText, this.ActiveDocumentBorderColor, this.x80caa5727f6ffe52, this.x9196c174a89a4ce4, true, this.DocumentTabSize, this.DocumentTabExtra, base.TextFormat, xb0f87b71823b1d4e);
					return;
				}
			}
			xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemBrushes.ControlText, this.InactiveDocumentBorderColor, this.x0b2889b8ff5ec580, this.x0e8b6412ec502dbf, false, this.DocumentTabSize, this.DocumentTabExtra, base.TextFormat, xb0f87b71823b1d4e);
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0001C0B0 File Offset: 0x0001B0B0
		internal static bool x7fb2e1ce54a27086()
		{
			bool result = false;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				result = (Environment.OSVersion.Version >= new Version(5, 1, 0, 0));
			}
			return result;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0001C0EC File Offset: 0x0001B0EC
		public override void StartRenderSession(HotkeyPrefix hotKeys)
		{
			base.StartRenderSession(hotKeys);
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0001C0F8 File Offset: 0x0001B0F8
		protected internal override void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset)
		{
			base.DrawTabStripBackground(container, control, graphics, bounds, selectedTabOffset);
			graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top + 2, bounds.Right - 1, bounds.Top + 2);
			while (!SystemInformation.HighContrast)
			{
				using (Pen pen = new Pen(SystemColors.ControlLightLight))
				{
					graphics.DrawLine(pen, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
					graphics.DrawLine(pen, bounds.Left, bounds.Top + 1, bounds.Right - 1, bounds.Top + 1);
					break;
				}
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0001C1E8 File Offset: 0x0001B1E8
		protected internal override void DrawTabStripTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			bounds.Y += 2;
			if (-1 != 0)
			{
				if ((drawSeparator ? 1U : 0U) - (drawSeparator ? 1U : 0U) <= 4294967295U)
				{
				}
				bounds.Height -= 2;
				if ((state & DrawItemState.Selected) == DrawItemState.Selected)
				{
					xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemColors.ControlText, SystemColors.ControlDark, state, base.TextFormat);
				}
				else
				{
					xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemColors.ControlDarkDark, SystemColors.ControlDark, state, base.TextFormat);
				}
				if ((state & DrawItemState.Selected) != DrawItemState.Selected)
				{
					goto IL_60;
				}
				return;
			}
			IL_16:
			graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 2, bounds.Top + 3, bounds.Right - 2, bounds.Bottom - 4);
			bool flag = ((drawSeparator ? 1U : 0U) | 15U) == 0U;
			if (!flag)
			{
				return;
			}
			IL_60:
			if (drawSeparator)
			{
				goto IL_16;
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000383 RID: 899 RVA: 0x0001C334 File Offset: 0x0001B334
		protected internal override BoxModel TitleBarMetrics
		{
			get
			{
				if (this._x6defba3d5d846e0d == null)
				{
					this._x6defba3d5d846e0d = new BoxModel(0, SystemInformation.ToolWindowCaptionHeight, 0, 0, 0, 0, 0, 0, 0, 0);
				}
				return this._x6defba3d5d846e0d;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000384 RID: 900 RVA: 0x0001C368 File Offset: 0x0001B368
		protected internal override BoxModel TabMetrics
		{
			get
			{
				if (this._x3a1fa93b40743331 == null)
				{
					this._x3a1fa93b40743331 = new BoxModel(0, 0, 0, 0, 0, 0, 0, 0, -1, 0);
				}
				return this._x3a1fa93b40743331;
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0001C398 File Offset: 0x0001B398
		protected internal override BoxModel TabStripMetrics
		{
			get
			{
				if (this._x066f993679e36022 == null)
				{
					int height = Control.DefaultFont.Height;
					int num = Math.Max(height, this.ImageSize.Height);
					this._x066f993679e36022 = new BoxModel(0, num + 8, 0, 0, 0, 1, 0, 0, 0, 0);
				}
				return this._x066f993679e36022;
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000386 RID: 902 RVA: 0x0001C3EC File Offset: 0x0001B3EC
		protected internal override TabTextDisplayMode TabTextDisplay
		{
			get
			{
				return TabTextDisplayMode.AllTabs;
			}
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0001C3F0 File Offset: 0x0001B3F0
		protected internal override void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool vertical)
		{
			if (dockSide == DockSide.Left)
			{
				goto IL_07;
			}
			IL_04:
			if (!false)
			{
				goto IL_44;
			}
			IL_07:
			using (Image image2 = new Bitmap(image))
			{
				image2.RotateFlip(RotateFlipType.Rotate90FlipNone);
				xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image2, text, font, SystemBrushes.ControlDarkDark, SystemColors.ControlDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
				return;
			}
			IL_44:
			if (dockSide == DockSide.Right)
			{
				goto IL_07;
			}
			xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, SystemBrushes.ControlDarkDark, SystemColors.ControlDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
			if ((vertical ? 1U : 0U) + (vertical ? 1U : 0U) > 4294967295U)
			{
				goto IL_04;
			}
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0001C4A0 File Offset: 0x0001B4A0
		protected internal override void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled)
		{
			this.x9271fbf5eef553db(graphics, bounds, state, focused);
			using (Pen pen = (!focused) ? new Pen(this.x9a7470f809ffee0d) : new Pen(this.x6b97fa649c9b3a44))
			{
				switch (buttonType)
				{
				case SandDockButtonType.Close:
					x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, pen);
					break;
				case SandDockButtonType.Pin:
					x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, pen, toggled);
					break;
				case SandDockButtonType.WindowPosition:
					x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, pen);
					break;
				}
			}
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0001C544 File Offset: 0x0001B544
		protected internal override void DrawTitleBarBackground(Graphics graphics, Rectangle bounds, bool focused)
		{
			if (!focused)
			{
				goto IL_51;
			}
			IL_03:
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(bounds.X, bounds.Y - 1), new Point(bounds.X, bounds.Bottom), this.x2d5bde28a1e8ae90, this.xebb7eaf00d600976))
			{
				graphics.FillRectangle(linearGradientBrush, bounds);
				goto IL_71;
			}
			IL_51:
			using (SolidBrush solidBrush = new SolidBrush(this.x8e2e7f87608d5b3b))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			IL_71:
			graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
			if ((focused ? 1U : 0U) + (focused ? 1U : 0U) >= 0U)
			{
				graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
				graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
				return;
			}
			goto IL_03;
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0001C690 File Offset: 0x0001B690
		protected internal override void DrawTitleBarText(Graphics graphics, Rectangle bounds, bool focused, string text, Font font)
		{
			bounds.Inflate(-3, 0);
			TextFormatFlags textFormatFlags = base.TextFormat;
			textFormatFlags |= TextFormatFlags.NoPrefix;
			bounds.X += 3;
			TextRenderer.DrawText(graphics, text, font, bounds, focused ? this.x6b97fa649c9b3a44 : this.x9a7470f809ffee0d, textFormatFlags);
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0001C6E4 File Offset: 0x0001B6E4
		public override string ToString()
		{
			return "Whidbey";
		}

		// Token: 0x04000115 RID: 277
		private Color x994b52371e1ca7a9;

		// Token: 0x04000116 RID: 278
		private Color xcee7f670c3cc8729;

		// Token: 0x04000117 RID: 279
		private Color x80caa5727f6ffe52;

		// Token: 0x04000118 RID: 280
		private Color x0b2889b8ff5ec580;

		// Token: 0x04000119 RID: 281
		private Color x9196c174a89a4ce4;

		// Token: 0x0400011A RID: 282
		private Color x0e8b6412ec502dbf;

		// Token: 0x0400011B RID: 283
		private Color xd1edc46cbe592968;

		// Token: 0x0400011C RID: 284
		private Color x43b04232fee73e15;

		// Token: 0x0400011D RID: 285
		private Color x8e2e7f87608d5b3b;

		// Token: 0x0400011E RID: 286
		private Color x9a7470f809ffee0d;

		// Token: 0x0400011F RID: 287
		private Color x2d5bde28a1e8ae90;

		// Token: 0x04000120 RID: 288
		private Color xebb7eaf00d600976;

		// Token: 0x04000121 RID: 289
		private Color x6b97fa649c9b3a44;

		// Token: 0x04000122 RID: 290
		private Color x693536a88ebe8191;

		// Token: 0x04000123 RID: 291
		private Color x503b1fd8602da9a9;

		// Token: 0x04000124 RID: 292
		private Color xb2b9c364e92661dd;

		// Token: 0x04000125 RID: 293
		private Color x4056384aa48da1d1;

		// Token: 0x04000126 RID: 294
		private Color x2e1ef9b84f7ac14b;

		// Token: 0x04000127 RID: 295
		private Color x4dea88af4363a77b;

		// Token: 0x04000128 RID: 296
		private BoxModel _x066f993679e36022;

		// Token: 0x04000129 RID: 297
		private BoxModel _x3a1fa93b40743331;

		// Token: 0x0400012A RID: 298
		private BoxModel _x6defba3d5d846e0d;
	}
}

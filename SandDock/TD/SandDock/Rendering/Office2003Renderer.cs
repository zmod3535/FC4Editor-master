using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
	// Token: 0x0200006C RID: 108
	public class Office2003Renderer : ThemeAwareRendererBase
	{
		// Token: 0x060005E4 RID: 1508 RVA: 0x0002C1C0 File Offset: 0x0002B1C0
		public Office2003Renderer()
		{
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0002C1D8 File Offset: 0x0002B1D8
		public Office2003Renderer(WindowsColorScheme colorScheme)
		{
			base.ColorScheme = colorScheme;
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x0002C1F8 File Offset: 0x0002B1F8
		// (set) Token: 0x060005E7 RID: 1511 RVA: 0x0002C200 File Offset: 0x0002B200
		public Color HighlightBorderColor
		{
			get
			{
				return this.x5bdc84993d5749e9;
			}
			set
			{
				this.x5bdc84993d5749e9 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x0002C210 File Offset: 0x0002B210
		// (set) Token: 0x060005E9 RID: 1513 RVA: 0x0002C218 File Offset: 0x0002B218
		public Color HighlightBackgroundColor1
		{
			get
			{
				return this.xf6500c4730a3d95a;
			}
			set
			{
				this.xf6500c4730a3d95a = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x0002C228 File Offset: 0x0002B228
		// (set) Token: 0x060005EB RID: 1515 RVA: 0x0002C230 File Offset: 0x0002B230
		public Color HighlightBackgroundColor2
		{
			get
			{
				return this.xfc7b03fc2744e317;
			}
			set
			{
				this.xfc7b03fc2744e317 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x0002C240 File Offset: 0x0002B240
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x0002C248 File Offset: 0x0002B248
		public Color InactiveTitleBarColor1
		{
			get
			{
				return this.x39abd2ac7b4ba43a;
			}
			set
			{
				this.x39abd2ac7b4ba43a = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x0002C258 File Offset: 0x0002B258
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x0002C260 File Offset: 0x0002B260
		public Color InactiveTitleBarColor2
		{
			get
			{
				return this.x5ab33f59f391d4a9;
			}
			set
			{
				this.x5ab33f59f391d4a9 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x0002C270 File Offset: 0x0002B270
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x0002C278 File Offset: 0x0002B278
		public Color ActiveTitleBarColor1
		{
			get
			{
				return this.x6ea95002bd1a98a3;
			}
			set
			{
				this.x6ea95002bd1a98a3 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x0002C288 File Offset: 0x0002B288
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x0002C290 File Offset: 0x0002B290
		public Color ActiveTitleBarColor2
		{
			get
			{
				return this.xef5a1f47abc9b7b1;
			}
			set
			{
				this.xef5a1f47abc9b7b1 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x0002C2A0 File Offset: 0x0002B2A0
		// (set) Token: 0x060005F5 RID: 1525 RVA: 0x0002C2A8 File Offset: 0x0002B2A8
		public Color GripperColor
		{
			get
			{
				return this._x273909d58eb80850;
			}
			set
			{
				this._x273909d58eb80850 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x0002C2B8 File Offset: 0x0002B2B8
		// (set) Token: 0x060005F7 RID: 1527 RVA: 0x0002C2C0 File Offset: 0x0002B2C0
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

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x0002C2D0 File Offset: 0x0002B2D0
		// (set) Token: 0x060005F9 RID: 1529 RVA: 0x0002C2D8 File Offset: 0x0002B2D8
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

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x0002C2E8 File Offset: 0x0002B2E8
		// (set) Token: 0x060005FB RID: 1531 RVA: 0x0002C2F0 File Offset: 0x0002B2F0
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

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x0002C300 File Offset: 0x0002B300
		// (set) Token: 0x060005FD RID: 1533 RVA: 0x0002C308 File Offset: 0x0002B308
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

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x0002C318 File Offset: 0x0002B318
		// (set) Token: 0x060005FF RID: 1535 RVA: 0x0002C320 File Offset: 0x0002B320
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

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x0002C330 File Offset: 0x0002B330
		// (set) Token: 0x06000601 RID: 1537 RVA: 0x0002C338 File Offset: 0x0002B338
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

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x0002C348 File Offset: 0x0002B348
		// (set) Token: 0x06000603 RID: 1539 RVA: 0x0002C350 File Offset: 0x0002B350
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

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x0002C360 File Offset: 0x0002B360
		// (set) Token: 0x06000605 RID: 1541 RVA: 0x0002C368 File Offset: 0x0002B368
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

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000606 RID: 1542 RVA: 0x0002C378 File Offset: 0x0002B378
		// (set) Token: 0x06000607 RID: 1543 RVA: 0x0002C380 File Offset: 0x0002B380
		public Color WidgetColor
		{
			get
			{
				return this.x488edc060a6f4707;
			}
			set
			{
				this.x488edc060a6f4707 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0002C390 File Offset: 0x0002B390
		protected override void ApplyStandardColors()
		{
			if (SystemInformation.HighContrast)
			{
				if (false)
				{
					if (-2 == 0)
					{
						goto IL_1A;
					}
					goto IL_101;
				}
				else
				{
					do
					{
						base.LayoutBackgroundColor1 = SystemColors.Control;
						base.LayoutBackgroundColor2 = SystemColors.Control;
						this.x994b52371e1ca7a9 = SystemColors.ActiveCaption;
						do
						{
							this.xcee7f670c3cc8729 = SystemColors.ControlDark;
						}
						while (3 == 0);
						if (255 == 0)
						{
							goto IL_B7;
						}
						this.x80caa5727f6ffe52 = SystemColors.Control;
						this.x0b2889b8ff5ec580 = SystemColors.Control;
					}
					while (2 == 0);
					if (3 == 0)
					{
						goto IL_21A;
					}
					goto IL_195;
				}
			}
			else
			{
				base.LayoutBackgroundColor1 = SystemColors.Control;
				if (2147483647 != 0)
				{
					base.LayoutBackgroundColor2 = RendererBase.InterpolateColors(SystemColors.Control, SystemColors.Window, 0.8f);
					this.x994b52371e1ca7a9 = SystemColors.ControlDark;
					this.xcee7f670c3cc8729 = SystemColors.ControlDark;
					if (255 == 0)
					{
						goto IL_195;
					}
					this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
					if (255 != 0)
					{
						this.x0b2889b8ff5ec580 = SystemColors.Control;
						goto IL_21A;
					}
					goto IL_1A0;
				}
			}
			for (;;)
			{
				IL_B7:
				this.x5bdc84993d5749e9 = SystemColors.Highlight;
				this.xf6500c4730a3d95a = RendererBase.InterpolateColors(this.x5bdc84993d5749e9, SystemColors.Window, 0.7f);
				this.xfc7b03fc2744e317 = this.xf6500c4730a3d95a;
				this.x39abd2ac7b4ba43a = base.LayoutBackgroundColor2;
				if (3 != 0)
				{
					this.x5ab33f59f391d4a9 = RendererBase.InterpolateColors(SystemColors.Control, Color.Black, 0.03f);
					this.x6ea95002bd1a98a3 = Color.FromArgb(212, 213, 216);
					this.xef5a1f47abc9b7b1 = Color.FromArgb(212, 213, 216);
					this._x273909d58eb80850 = SystemColors.ControlDark;
				}
				this.xd1edc46cbe592968 = SystemColors.Control;
				this.x43b04232fee73e15 = SystemColors.ControlLightLight;
				if (4 != 0)
				{
					break;
				}
				if (!false)
				{
					goto IL_101;
				}
			}
			IL_1A:
			this.x488edc060a6f4707 = SystemColors.ControlText;
			if (-2147483648 != 0)
			{
				return;
			}
			IL_101:
			this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
			this.x0e8b6412ec502dbf = SystemColors.Control;
			IL_147:
			goto IL_B7;
			IL_195:
			this.x9196c174a89a4ce4 = SystemColors.Control;
			IL_1A0:
			this.x0e8b6412ec502dbf = SystemColors.Control;
			goto IL_147;
			IL_21A:
			if (!false)
			{
				goto IL_101;
			}
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0002C5C0 File Offset: 0x0002B5C0
		protected override void ApplyLunaBlueColors()
		{
			base.LayoutBackgroundColor1 = Color.FromArgb(158, 190, 245);
			for (;;)
			{
				base.LayoutBackgroundColor2 = Color.FromArgb(195, 218, 249);
				if (false)
				{
					goto IL_ED;
				}
				IL_13E:
				this.x5bdc84993d5749e9 = Color.FromArgb(0, 0, 128);
				if (!false)
				{
					goto IL_153;
				}
				continue;
				IL_ED:
				this.x43b04232fee73e15 = SystemColors.ControlLightLight;
				this.x994b52371e1ca7a9 = Color.FromArgb(59, 97, 156);
				this.xcee7f670c3cc8729 = Color.FromArgb(0, 53, 154);
				this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
				this.x0b2889b8ff5ec580 = SystemColors.ControlLightLight;
				this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
				this.x0e8b6412ec502dbf = Color.FromArgb(117, 166, 241);
				if (false)
				{
					goto IL_153;
				}
				if (4 != 0)
				{
					if (3 == 0)
					{
						goto IL_13E;
					}
					break;
				}
				IL_91:
				this.x6ea95002bd1a98a3 = Color.FromArgb(255, 211, 142);
				this.xef5a1f47abc9b7b1 = Color.FromArgb(254, 145, 78);
				this._x273909d58eb80850 = Color.FromArgb(39, 65, 118);
				this.xd1edc46cbe592968 = Color.FromArgb(196, 218, 250);
				goto IL_ED;
				IL_153:
				this.xf6500c4730a3d95a = Color.FromArgb(255, 244, 204);
				this.xfc7b03fc2744e317 = Color.FromArgb(255, 211, 142);
				this.x39abd2ac7b4ba43a = Color.FromArgb(221, 236, 254);
				this.x5ab33f59f391d4a9 = Color.FromArgb(129, 169, 226);
				goto IL_91;
			}
			this.x488edc060a6f4707 = SystemColors.ControlText;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0002C7A0 File Offset: 0x0002B7A0
		protected override void ApplyLunaOliveColors()
		{
			base.LayoutBackgroundColor1 = Color.FromArgb(217, 217, 167);
			if (!false && 8 != 0)
			{
				base.LayoutBackgroundColor2 = Color.FromArgb(242, 240, 228);
				this.x5bdc84993d5749e9 = Color.FromArgb(63, 93, 56);
				this.xf6500c4730a3d95a = Color.FromArgb(255, 244, 204);
				do
				{
					this.xfc7b03fc2744e317 = Color.FromArgb(255, 211, 142);
					if (false)
					{
						goto IL_1B7;
					}
				}
				while (2 == 0);
				this.x39abd2ac7b4ba43a = Color.FromArgb(244, 247, 222);
				this.x5ab33f59f391d4a9 = Color.FromArgb(183, 198, 145);
				this.x6ea95002bd1a98a3 = Color.FromArgb(255, 211, 142);
				goto IL_12A;
			}
			IL_20:
			this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
			if (3 != 0)
			{
				this.x0b2889b8ff5ec580 = SystemColors.ControlLightLight;
				this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
				this.x0e8b6412ec502dbf = Color.FromArgb(176, 194, 140);
				this.x488edc060a6f4707 = SystemColors.ControlText;
				return;
			}
			IL_12A:
			this.xef5a1f47abc9b7b1 = Color.FromArgb(254, 145, 78);
			this._x273909d58eb80850 = Color.FromArgb(81, 94, 51);
			this.xd1edc46cbe592968 = Color.FromArgb(242, 241, 228);
			this.x43b04232fee73e15 = SystemColors.ControlLightLight;
			this.x994b52371e1ca7a9 = Color.FromArgb(96, 128, 88);
			this.xcee7f670c3cc8729 = Color.FromArgb(96, 119, 107);
			IL_1B7:
			if (!false)
			{
				goto IL_20;
			}
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0002C96C File Offset: 0x0002B96C
		protected override void ApplyLunaSilverColors()
		{
			base.LayoutBackgroundColor1 = Color.FromArgb(215, 215, 229);
			if (!false)
			{
				base.LayoutBackgroundColor2 = Color.FromArgb(243, 243, 247);
				this.x5bdc84993d5749e9 = Color.FromArgb(75, 75, 111);
				this.xf6500c4730a3d95a = Color.FromArgb(255, 244, 204);
				this.xfc7b03fc2744e317 = Color.FromArgb(255, 211, 142);
				for (;;)
				{
					this.x39abd2ac7b4ba43a = Color.FromArgb(243, 244, 250);
					this.x5ab33f59f391d4a9 = Color.FromArgb(140, 138, 172);
					do
					{
						this.x6ea95002bd1a98a3 = Color.FromArgb(255, 211, 142);
						this.xef5a1f47abc9b7b1 = Color.FromArgb(254, 145, 78);
						this._x273909d58eb80850 = Color.FromArgb(84, 84, 117);
						if (!false)
						{
							this.xd1edc46cbe592968 = Color.FromArgb(243, 243, 247);
							this.x43b04232fee73e15 = SystemColors.ControlLightLight;
							if (false)
							{
								continue;
							}
							if (-1 != 0)
							{
							}
							this.x994b52371e1ca7a9 = Color.FromArgb(124, 124, 148);
							if (2 == 0)
							{
								continue;
							}
						}
						if (false)
						{
							break;
						}
						if (!false)
						{
							this.xcee7f670c3cc8729 = Color.FromArgb(118, 116, 146);
							this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
							this.x0b2889b8ff5ec580 = SystemColors.ControlLightLight;
							this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
						}
						this.x0e8b6412ec502dbf = Color.FromArgb(186, 185, 206);
						if (!false)
						{
							goto IL_163;
						}
					}
					while (false);
				}
				IL_163:
				if (3 == 0)
				{
					return;
				}
			}
			this.x488edc060a6f4707 = SystemColors.ControlText;
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x0002CB4C File Offset: 0x0002BB4C
		private void x9271fbf5eef553db(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51)
		{
			if ((x01b557925841ae51 & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, this.xf6500c4730a3d95a, this.xfc7b03fc2744e317, LinearGradientMode.Vertical))
				{
					x41347a961b838962.FillRectangle(linearGradientBrush, xda73fcb97c77d998);
				}
				using (Pen pen = new Pen(this.x5bdc84993d5749e9))
				{
					x41347a961b838962.DrawRectangle(pen, xda73fcb97c77d998);
				}
			}
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0002CBE0 File Offset: 0x0002BBE0
		protected internal override void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled)
		{
			bounds.Width--;
			if (!false)
			{
				goto IL_F7;
			}
			bool flag = (toggled ? 1U : 0U) - (toggled ? 1U : 0U) < 0U;
			if (flag)
			{
				goto IL_30;
			}
			for (;;)
			{
				IL_A5:
				switch (buttonType)
				{
				case SandDockButtonType.Close:
					x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, focused ? SystemPens.ControlText : SystemPens.ControlText);
					if ((focused ? 1U : 0U) - (toggled ? 1U : 0U) <= 4294967295U)
					{
						return;
					}
					continue;
				case SandDockButtonType.Pin:
					goto IL_30;
				case SandDockButtonType.ScrollLeft:
				case SandDockButtonType.ScrollRight:
					return;
				case SandDockButtonType.WindowPosition:
					x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, focused ? SystemPens.ControlText : SystemPens.ControlText);
					if (((focused ? 1U : 0U) & 0U) != 0U)
					{
						continue;
					}
					return;
				}
				goto Block_6;
			}
			return;
			Block_6:
			if ((toggled ? 1U : 0U) - (focused ? 1U : 0U) >= 0U)
			{
				return;
			}
			goto IL_E5;
			IL_30:
			x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, focused ? SystemPens.ControlText : SystemPens.ControlText, toggled);
			return;
			IL_E5:
			IL_EE:
			if (true)
			{
				goto IL_128;
			}
			IL_F7:
			bounds.Height--;
			this.x9271fbf5eef553db(graphics, bounds, state);
			flag = ((toggled ? 1U : 0U) + (toggled ? 1U : 0U) < 0U);
			if (!flag)
			{
				if ((state & DrawItemState.Selected) != DrawItemState.Selected)
				{
					goto IL_EE;
				}
				bounds.Offset(1, 1);
				goto IL_E5;
			}
			IL_128:
			goto IL_A5;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0002CD1C File Offset: 0x0002BD1C
		private Brush xe70d5b03e620fb01(Rectangle xda73fcb97c77d998, LinearGradientMode x23e85093ba3a7d1d, Color x6d9a095d183b6b50, Color x60a2487f840b534c)
		{
			Color color = RendererBase.InterpolateColors(x6d9a095d183b6b50, x60a2487f840b534c, 0.25f);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, x6d9a095d183b6b50, x60a2487f840b534c, x23e85093ba3a7d1d);
			ColorBlend colorBlend;
			do
			{
				colorBlend = new ColorBlend(3);
				colorBlend.Colors = new Color[]
				{
					x6d9a095d183b6b50,
					color,
					x60a2487f840b534c
				};
			}
			while (false);
			colorBlend.Positions = new float[]
			{
				0f,
				0.5f,
				1f
			};
			linearGradientBrush.InterpolationColors = colorBlend;
			return linearGradientBrush;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0002CDAC File Offset: 0x0002BDAC
		protected internal override void DrawTitleBarText(Graphics graphics, Rectangle bounds, bool focused, string text, Font font)
		{
			bounds.Inflate(-3, 0);
			using (Font font2 = new Font(font, FontStyle.Bold))
			{
				TextFormatFlags textFormatFlags = base.TextFormat;
				textFormatFlags |= TextFormatFlags.NoPrefix;
				bounds.X += 3;
				TextRenderer.DrawText(graphics, text, font2, bounds, SystemColors.ControlText, textFormatFlags);
			}
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0002CE24 File Offset: 0x0002BE24
		protected internal override void DrawTitleBarBackground(Graphics graphics, Rectangle bounds, bool focused)
		{
			if (focused)
			{
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, this.x6ea95002bd1a98a3, this.xef5a1f47abc9b7b1, LinearGradientMode.Vertical))
				{
					graphics.FillRectangle(linearGradientBrush, bounds);
					goto IL_54;
				}
			}
			using (Brush brush = this.xe70d5b03e620fb01(bounds, LinearGradientMode.Vertical, this.x39abd2ac7b4ba43a, this.x5ab33f59f391d4a9))
			{
				graphics.FillRectangle(brush, bounds);
			}
			IL_54:
			bounds.Inflate(0, -2);
			using (SolidBrush solidBrush = new SolidBrush(this._x273909d58eb80850))
			{
				int num = (bounds.Height - 2) / 4;
				int num2 = num * 4 - 2;
				int num3;
				int num4;
				if (2 != 0)
				{
					num3 = bounds.X + 3;
					num4 = bounds.Y + bounds.Height / 2 - num2 / 2;
				}
				int i = num4;
				bool flag = (uint)i - (uint)num2 > uint.MaxValue;
				if (!flag)
				{
					while (i <= num4 + num2)
					{
						graphics.FillRectangle(SystemBrushes.ControlLightLight, new Rectangle(num3 + 1, i + 1, 2, 2));
						graphics.FillRectangle(solidBrush, new Rectangle(num3, i, 2, 2));
						i += 4;
					}
				}
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x0002CF94 File Offset: 0x0002BF94
		protected internal override BoxModel TitleBarMetrics
		{
			get
			{
				return new BoxModel(0, 25, 4, 0, 0, 0, 0, 0, 0, 0);
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000612 RID: 1554 RVA: 0x0002CFB4 File Offset: 0x0002BFB4
		protected internal override TabTextDisplayMode TabTextDisplay
		{
			get
			{
				return TabTextDisplayMode.SelectedTab;
			}
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0002CFB8 File Offset: 0x0002BFB8
		protected internal override void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool vertical)
		{
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, SystemBrushes.ControlText, SystemColors.ControlDarkDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
				return;
			}
			xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, SystemBrushes.ControlText, SystemColors.ControlDarkDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000614 RID: 1556 RVA: 0x0002D010 File Offset: 0x0002C010
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

		// Token: 0x06000615 RID: 1557 RVA: 0x0002D040 File Offset: 0x0002C040
		protected internal override void DrawTabStripTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.x95dac044246123ac, text, font, this.xf6500c4730a3d95a, this.xfc7b03fc2744e317, SystemColors.ControlText, SystemColors.ControlDark, state, base.TextFormat);
				return;
			}
			xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.x95dac044246123ac, text, font, backColor, SystemColors.ControlLightLight, SystemColors.ControlText, SystemColors.ControlDark, state, base.TextFormat);
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000616 RID: 1558 RVA: 0x0002D0B0 File Offset: 0x0002C0B0
		protected internal override BoxModel TabStripMetrics
		{
			get
			{
				if (this._x066f993679e36022 == null)
				{
					this._x066f993679e36022 = new BoxModel(0, Control.DefaultFont.Height + 10, 0, 0, 0, 1, 0, 0, 0, 0);
				}
				return this._x066f993679e36022;
			}
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0002D0EC File Offset: 0x0002C0EC
		protected internal override void DrawControlClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0002D0F0 File Offset: 0x0002C0F0
		protected internal override void DrawDocumentClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
			using (SolidBrush solidBrush = new SolidBrush(backColor))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0002D134 File Offset: 0x0002C134
		protected internal override Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			return xa811784015ed8842.xcdfce0e0f2641503(graphics, image, this.ImageSize, text, font, base.TextFormat);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0002D14C File Offset: 0x0002C14C
		protected internal override Size MeasureDocumentStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			TextFormatFlags textFormatFlags = base.TextFormat;
			textFormatFlags &= ~TextFormatFlags.NoPrefix;
			int num;
			for (;;)
			{
				if ((state & DrawItemState.Focus) != DrawItemState.Focus)
				{
					goto IL_97;
				}
				IL_53:
				using (Font font2 = new Font(font, FontStyle.Bold))
				{
					num = TextRenderer.MeasureText(graphics, text, font2, new Size(int.MaxValue, int.MaxValue), textFormatFlags).Width;
					goto IL_09;
				}
				continue;
				IL_09:
				num += 24;
				if (-1 == 0)
				{
					goto IL_53;
				}
				if (image == null)
				{
					goto IL_31;
				}
				bool flag = ((uint)num & 0U) == 0U;
				if (flag)
				{
					break;
				}
				IL_97:
				num = TextRenderer.MeasureText(graphics, text, font, new Size(int.MaxValue, int.MaxValue), textFormatFlags).Width;
				goto IL_09;
			}
			num += 20;
			IL_31:
			num += this.DocumentTabExtra;
			return new Size(num, 0);
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0002D238 File Offset: 0x0002C238
		protected internal override void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds)
		{
			xa811784015ed8842.x91433b5e99eb7cac(graphics, container.BackColor);
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0002D248 File Offset: 0x0002C248
		protected internal override Rectangle AdjustDockControlClientBounds(ControlLayoutSystem layoutSystem, DockControl control, Rectangle clientBounds)
		{
			if (layoutSystem is DocumentLayoutSystem)
			{
				clientBounds.Inflate(-4, -4);
				return clientBounds;
			}
			return base.AdjustDockControlClientBounds(layoutSystem, control, clientBounds);
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x0002D268 File Offset: 0x0002C268
		protected internal override int DocumentTabStripSize
		{
			get
			{
				return Control.DefaultFont.Height + 15;
			}
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0002D278 File Offset: 0x0002C278
		protected internal override void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
		{
			this.x9271fbf5eef553db(graphics, bounds, state);
			for (;;)
			{
				if ((state & DrawItemState.Selected) == DrawItemState.Selected)
				{
					bounds.Offset(1, 1);
				}
				switch (buttonType)
				{
				case SandDockButtonType.Close:
					using (Pen pen = new Pen(this.x488edc060a6f4707))
					{
						x9b2777bb8e78938b.xb176aa01ddab9f3e(graphics, bounds, pen);
						return;
					}
					continue;
				case SandDockButtonType.Pin:
				case SandDockButtonType.WindowPosition:
					return;
				case SandDockButtonType.ScrollLeft:
					goto IL_40;
				case SandDockButtonType.ScrollRight:
					goto IL_58;
				case SandDockButtonType.ActiveFiles:
					goto IL_0F;
				}
				goto Block_3;
			}
			IL_0F:
			using (Pen pen2 = new Pen(this.x488edc060a6f4707))
			{
				x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, pen2);
				return;
			}
			return;
			IL_40:
			x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
			return;
			IL_58:
			x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
			return;
			Block_3:;
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x0002D390 File Offset: 0x0002C390
		public override Size TabControlPadding
		{
			get
			{
				return new Size(3, 3);
			}
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0002D39C File Offset: 0x0002C39C
		protected internal override void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds)
		{
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(bounds.X, bounds.Y - 1), new Point(bounds.X, bounds.Bottom), this.xd1edc46cbe592968, this.x43b04232fee73e15))
			{
				graphics.FillRectangle(linearGradientBrush, bounds);
			}
			using (Pen pen = new Pen(this.x994b52371e1ca7a9))
			{
				graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
			}
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0002D46C File Offset: 0x0002C46C
		protected internal override void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			Color x477e9d1180ece = RendererBase.InterpolateColors(backColor, SystemColors.ControlLightLight, 0.78f);
			bool xb0f87b71823b1d4e = (state & DrawItemState.Checked) == DrawItemState.Checked;
			if ((state & DrawItemState.Selected) != DrawItemState.Selected)
			{
				xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, x477e9d1180ece, backColor, SystemBrushes.ControlText, this.xcee7f670c3cc8729, this.x0b2889b8ff5ec580, this.x0e8b6412ec502dbf, false, this.DocumentTabSize, this.DocumentTabExtra, base.TextFormat, xb0f87b71823b1d4e);
			}
			else
			{
				xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, x477e9d1180ece, backColor, SystemBrushes.ControlText, this.x994b52371e1ca7a9, this.x80caa5727f6ffe52, this.x9196c174a89a4ce4, true, this.DocumentTabSize, this.DocumentTabExtra, base.TextFormat, xb0f87b71823b1d4e);
				if (!false)
				{
					return;
				}
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x0002D530 File Offset: 0x0002C530
		protected internal override int DocumentTabSize
		{
			get
			{
				return Control.DefaultFont.Height + 7;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x0002D540 File Offset: 0x0002C540
		protected internal override int DocumentTabExtra
		{
			get
			{
				return 18;
			}
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0002D544 File Offset: 0x0002C544
		public override string ToString()
		{
			return "Office 2003";
		}

		// Token: 0x04000231 RID: 561
		private Color x5bdc84993d5749e9;

		// Token: 0x04000232 RID: 562
		private Color xf6500c4730a3d95a;

		// Token: 0x04000233 RID: 563
		private Color xfc7b03fc2744e317;

		// Token: 0x04000234 RID: 564
		private Color xd1edc46cbe592968;

		// Token: 0x04000235 RID: 565
		private Color x43b04232fee73e15;

		// Token: 0x04000236 RID: 566
		private Color x994b52371e1ca7a9;

		// Token: 0x04000237 RID: 567
		private Color xcee7f670c3cc8729;

		// Token: 0x04000238 RID: 568
		private Color x80caa5727f6ffe52;

		// Token: 0x04000239 RID: 569
		private Color x0b2889b8ff5ec580;

		// Token: 0x0400023A RID: 570
		private Color x9196c174a89a4ce4;

		// Token: 0x0400023B RID: 571
		private Color x0e8b6412ec502dbf;

		// Token: 0x0400023C RID: 572
		private Color x488edc060a6f4707;

		// Token: 0x0400023D RID: 573
		private Color x6ea95002bd1a98a3;

		// Token: 0x0400023E RID: 574
		private Color xef5a1f47abc9b7b1;

		// Token: 0x0400023F RID: 575
		private Color x39abd2ac7b4ba43a;

		// Token: 0x04000240 RID: 576
		private Color x5ab33f59f391d4a9;

		// Token: 0x04000241 RID: 577
		private Color _x273909d58eb80850;

		// Token: 0x04000242 RID: 578
		private Size x95dac044246123ac = new Size(16, 16);

		// Token: 0x04000243 RID: 579
		private BoxModel _x066f993679e36022;

		// Token: 0x04000244 RID: 580
		private BoxModel _x3a1fa93b40743331;
	}
}

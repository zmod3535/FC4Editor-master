using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
	// Token: 0x0200002D RID: 45
	public class EverettRenderer : RendererBase
	{
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x0001E0FC File Offset: 0x0001D0FC
		internal static StringFormat x27e1c82c97265861
		{
			get
			{
				if (EverettRenderer.xdc3f45c33fe25d85 == null)
				{
					do
					{
						EverettRenderer.xdc3f45c33fe25d85 = new StringFormat(StringFormat.GenericDefault);
						EverettRenderer.xdc3f45c33fe25d85.Alignment = StringAlignment.Near;
						EverettRenderer.xdc3f45c33fe25d85.LineAlignment = StringAlignment.Center;
					}
					while (false);
					EverettRenderer.xdc3f45c33fe25d85.Trimming = StringTrimming.EllipsisCharacter;
					EverettRenderer.xdc3f45c33fe25d85.FormatFlags |= StringFormatFlags.NoWrap;
				}
				return EverettRenderer.xdc3f45c33fe25d85;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x0001E160 File Offset: 0x0001D160
		internal static StringFormat xc351c68a86733972
		{
			get
			{
				if (EverettRenderer.x7553dbb15fca5d00 == null)
				{
					EverettRenderer.x7553dbb15fca5d00 = new StringFormat(StringFormat.GenericDefault);
					EverettRenderer.x7553dbb15fca5d00.Alignment = StringAlignment.Near;
					if (!false)
					{
						EverettRenderer.x7553dbb15fca5d00.LineAlignment = StringAlignment.Center;
					}
					EverettRenderer.x7553dbb15fca5d00.Trimming = StringTrimming.EllipsisCharacter;
					EverettRenderer.x7553dbb15fca5d00.FormatFlags |= StringFormatFlags.NoWrap;
					EverettRenderer.x7553dbb15fca5d00.FormatFlags |= StringFormatFlags.DirectionVertical;
				}
				return EverettRenderer.x7553dbb15fca5d00;
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0001E1DC File Offset: 0x0001D1DC
		protected override void GetColorsFromSystem()
		{
			this.x7f2683d69c01d139 = this.x2c04503a704e817c(SystemColors.Control);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0001E1F0 File Offset: 0x0001D1F0
		private Color x2c04503a704e817c(Color xdd0e633cf3dbad19)
		{
			byte b = xdd0e633cf3dbad19.R;
			byte b2;
			bool flag = ((uint)b2 | 4294967294U) == 0U;
			byte b3;
			byte b4;
			if (!flag)
			{
				b3 = xdd0e633cf3dbad19.G;
				b4 = xdd0e633cf3dbad19.B;
				b2 = Math.Max(Math.Max(b, b3), b4);
				if (b2 == 0)
				{
					return Color.FromArgb(35, 35, 35);
				}
			}
			IL_AE:
			byte b5;
			while (b2 > 220)
			{
				flag = (((uint)b | uint.MaxValue) == 0U);
				if (flag)
				{
					if ((uint)b2 > 4294967295U)
					{
						continue;
					}
				}
				else if ((uint)b3 <= 4294967295U)
				{
					goto IL_85;
				}
				if ((uint)b4 > 4294967295U)
				{
					continue;
				}
				IL_85:
				b5 = byte.MaxValue - b2;
				IL_8D:
				byte b6 = b5;
				b += (byte)((double)((float)b6 * ((float)b / (float)b2)) + 0.5);
				b3 += (byte)((double)((float)b6 * ((float)b3 / (float)b2)) + 0.5);
				b4 += (byte)((double)((float)b6 * ((float)b4 / (float)b2)) + 0.5);
				return Color.FromArgb((int)b, (int)b3, (int)b4);
			}
			b5 = 35;
			goto IL_8D;
			goto IL_AE;
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x0001E328 File Offset: 0x0001D328
		// (set) Token: 0x060003BA RID: 954 RVA: 0x0001E330 File Offset: 0x0001D330
		public Color CollapsedTabOutlineColor
		{
			get
			{
				return this.x9c1f2f40026567ee;
			}
			set
			{
				this.x9c1f2f40026567ee = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060003BB RID: 955 RVA: 0x0001E340 File Offset: 0x0001D340
		// (set) Token: 0x060003BC RID: 956 RVA: 0x0001E348 File Offset: 0x0001D348
		public Color BackgroundTabForeColor
		{
			get
			{
				return this.x1da108dbfca32343;
			}
			set
			{
				this.x1da108dbfca32343 = value;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060003BD RID: 957 RVA: 0x0001E354 File Offset: 0x0001D354
		// (set) Token: 0x060003BE RID: 958 RVA: 0x0001E35C File Offset: 0x0001D35C
		public Color HighlightColor
		{
			get
			{
				return this.xfca0e3085d5a7f42;
			}
			set
			{
				this.xfca0e3085d5a7f42 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003BF RID: 959 RVA: 0x0001E36C File Offset: 0x0001D36C
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x0001E374 File Offset: 0x0001D374
		public Color ShadowColor
		{
			get
			{
				return this.x228f9881a1be0e5d;
			}
			set
			{
				this.x228f9881a1be0e5d = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0001E384 File Offset: 0x0001D384
		public Color TabStripBackgroundColor
		{
			get
			{
				return this.x7f2683d69c01d139;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x0001E38C File Offset: 0x0001D38C
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x0001E394 File Offset: 0x0001D394
		public Color InactiveTitleBarColor
		{
			get
			{
				return this.xef5f9f8a08f25e70;
			}
			set
			{
				this.xef5f9f8a08f25e70 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060003C4 RID: 964 RVA: 0x0001E3A4 File Offset: 0x0001D3A4
		// (set) Token: 0x060003C5 RID: 965 RVA: 0x0001E3AC File Offset: 0x0001D3AC
		public Color ActiveTitleBarColor
		{
			get
			{
				return this.x4978f8b41a50b017;
			}
			set
			{
				this.x4978f8b41a50b017 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x0001E3BC File Offset: 0x0001D3BC
		protected internal override TabTextDisplayMode TabTextDisplay
		{
			get
			{
				return TabTextDisplayMode.SelectedTab;
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0001E3C0 File Offset: 0x0001D3C0
		protected internal override Rectangle AdjustDockControlClientBounds(ControlLayoutSystem layoutSystem, DockControl control, Rectangle clientBounds)
		{
			if (layoutSystem is DocumentLayoutSystem)
			{
				clientBounds.Inflate(-2, -2);
				return clientBounds;
			}
			return base.AdjustDockControlClientBounds(layoutSystem, control, clientBounds);
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0001E3E0 File Offset: 0x0001D3E0
		protected internal override BoxModel TitleBarMetrics
		{
			get
			{
				if (this._x6defba3d5d846e0d == null)
				{
					this._x6defba3d5d846e0d = new BoxModel(0, SystemInformation.ToolWindowCaptionHeight + 2, 0, 0, 0, 0, 0, 0, 0, 2);
				}
				return this._x6defba3d5d846e0d;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x0001E418 File Offset: 0x0001D418
		protected internal override BoxModel TabMetrics
		{
			get
			{
				if (this._x3a1fa93b40743331 == null)
				{
					this._x3a1fa93b40743331 = new BoxModel(0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
				}
				return this._x3a1fa93b40743331;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0001E448 File Offset: 0x0001D448
		protected internal override BoxModel TabStripMetrics
		{
			get
			{
				if (this._x066f993679e36022 == null)
				{
					this._x066f993679e36022 = new BoxModel(0, Control.DefaultFont.Height + 9, 4, 0, 5, 1, 0, 2, 0, 0);
				}
				return this._x066f993679e36022;
			}
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0001E484 File Offset: 0x0001D484
		protected internal override void DrawControlClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0001E488 File Offset: 0x0001D488
		protected internal override void DrawDocumentClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
			using (SolidBrush solidBrush = new SolidBrush(backColor))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0001E4CC File Offset: 0x0001D4CC
		protected internal override void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds)
		{
			graphics.FillRectangle(this.x166a89f4cd379ec8, bounds);
			graphics.DrawLine(this.x050be261498a0c97, bounds.X, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060003CE RID: 974 RVA: 0x0001E508 File Offset: 0x0001D508
		public override Size TabControlPadding
		{
			get
			{
				return new Size(3, 3);
			}
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0001E514 File Offset: 0x0001D514
		protected internal override void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds)
		{
			xa811784015ed8842.x91433b5e99eb7cac(graphics, container.BackColor);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0001E524 File Offset: 0x0001D524
		protected internal override Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			int num = (int)Math.Ceiling((double)graphics.MeasureString(text, font, int.MaxValue, this.x2771fbe8bb84042b).Width);
			num += 30;
			return new Size(num, 18);
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x0001E564 File Offset: 0x0001D564
		protected internal override Size MeasureDocumentStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			if ((state & DrawItemState.Focus) == DrawItemState.Focus)
			{
				goto IL_77;
			}
			goto IL_AF;
			IL_0E:
			int num;
			num += this.DocumentTabExtra;
			return new Size(num, 0);
			IL_42:
			num += 2 + this.xe5ad29d0f658e81f * 2 + 2;
			bool flag = ((uint)num | 4U) == 0U;
			if (!flag && image == null)
			{
				if (4 == 0)
				{
					goto IL_77;
				}
				goto IL_0E;
			}
			IL_69:
			num += 20;
			goto IL_0E;
			IL_77:
			using (Font font2 = new Font(font, FontStyle.Bold))
			{
				num = (int)Math.Ceiling((double)graphics.MeasureString(text, font2, 999, this.x2771fbe8bb84042b).Width);
				goto IL_42;
			}
			IL_AF:
			num = (int)Math.Ceiling((double)graphics.MeasureString(text, font, 999, this.x2771fbe8bb84042b).Width);
			if ((uint)num >= 0U)
			{
				goto IL_42;
			}
			goto IL_69;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0001E664 File Offset: 0x0001D664
		protected internal override void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				using (SolidBrush solidBrush = new SolidBrush(backColor))
				{
					graphics.FillRectangle(solidBrush, bounds);
				}
				graphics.DrawLine(this.x050be261498a0c97, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
				graphics.DrawLine(this.x050be261498a0c97, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
				graphics.DrawLine(this.x7a0be2490cda8794, bounds.Right - 1, bounds.Top + 1, bounds.Right - 1, bounds.Bottom - 1);
				goto IL_187;
			}
			if (!drawSeparator)
			{
				goto IL_187;
			}
			graphics.DrawLine(SystemPens.ControlDark, bounds.Right, bounds.Top + 3, bounds.Right, bounds.Bottom - 3);
			if ((drawSeparator ? 1U : 0U) >= 0U)
			{
				goto IL_187;
			}
			IL_11:
			Font font2;
			font2.Dispose();
			return;
			IL_187:
			bounds = contentBounds;
			if (image != null)
			{
				graphics.DrawImage(image, bounds.X + 4, bounds.Y + 2, 16, 16);
				goto IL_EF;
			}
			if (false)
			{
				goto IL_EF;
			}
			IL_BD:
			if (bounds.Width > 8)
			{
				font2 = font;
				bool flag = (drawSeparator ? 1U : 0U) < 0U;
				if (flag || (state & DrawItemState.Focus) == DrawItemState.Focus)
				{
					font2 = new Font(font, FontStyle.Bold);
				}
				while ((state & DrawItemState.Selected) == DrawItemState.Selected)
				{
					using (SolidBrush solidBrush2 = new SolidBrush(foreColor))
					{
						graphics.DrawString(text, font2, solidBrush2, bounds, this.x2771fbe8bb84042b);
						goto IL_1C;
					}
					continue;
					IL_1C:
					if ((state & DrawItemState.Focus) != DrawItemState.Focus)
					{
						return;
					}
					goto IL_11;
				}
				graphics.DrawString(text, font2, this.x54c190ae969c389d, bounds, this.x2771fbe8bb84042b);
				goto IL_1C;
			}
			return;
			IL_EF:
			bounds.X += 20;
			bounds.Width -= 20;
			goto IL_BD;
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060003D3 RID: 979 RVA: 0x0001E8B0 File Offset: 0x0001D8B0
		internal virtual int xe5ad29d0f658e81f
		{
			get
			{
				return 5;
			}
		}

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x0001E8B4 File Offset: 0x0001D8B4
		protected internal override int DocumentTabSize
		{
			get
			{
				return Control.DefaultFont.Height + 6;
			}
		}

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x0001E8C4 File Offset: 0x0001D8C4
		protected internal override int DocumentTabStripSize
		{
			get
			{
				return Control.DefaultFont.Height + 8;
			}
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x0001E8D4 File Offset: 0x0001D8D4
		protected internal override int DocumentTabExtra
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0001E8D8 File Offset: 0x0001D8D8
		public override void StartRenderSession(HotkeyPrefix hotKeys)
		{
			this.x166a89f4cd379ec8 = new SolidBrush(this.x7f2683d69c01d139);
			do
			{
				this.x7a0be2490cda8794 = new Pen(this.x228f9881a1be0e5d);
				if (8 != 0)
				{
					this.x050be261498a0c97 = new Pen(this.xfca0e3085d5a7f42);
					this.x54c190ae969c389d = new SolidBrush(this.x1da108dbfca32343);
					this.xa33e6094d9ed12d6 = new Pen(this.x9c1f2f40026567ee);
					this.x2771fbe8bb84042b = new StringFormat(StringFormat.GenericDefault);
				}
				this.x2771fbe8bb84042b.FormatFlags = StringFormatFlags.NoWrap;
				if (false)
				{
					break;
				}
				this.x2771fbe8bb84042b.Alignment = StringAlignment.Center;
				this.x2771fbe8bb84042b.LineAlignment = StringAlignment.Center;
				this.x2771fbe8bb84042b.HotkeyPrefix = hotKeys;
			}
			while (false);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0001E99C File Offset: 0x0001D99C
		protected internal override void DrawSplitter(Control container, Control control, Graphics graphics, Rectangle bounds, Orientation orientation)
		{
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0001E9A0 File Offset: 0x0001D9A0
		protected internal override void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
		{
			this.x9271fbf5eef553db(graphics, bounds, state);
			for (;;)
			{
				while ((state & DrawItemState.Selected) == DrawItemState.Selected)
				{
					bounds.Offset(1, 1);
					if (!false && !false)
					{
						break;
					}
				}
				switch (buttonType)
				{
				case SandDockButtonType.Close:
					using (Pen pen = new Pen(this.x488edc060a6f4707))
					{
						x9b2777bb8e78938b.xb176aa01ddab9f3e(graphics, bounds, pen);
						return;
					}
					goto IL_4A;
				case SandDockButtonType.Pin:
				case SandDockButtonType.WindowPosition:
					return;
				case SandDockButtonType.ScrollLeft:
					x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
					if (4 != 0)
					{
						return;
					}
					goto IL_4A;
				case SandDockButtonType.ScrollRight:
					goto IL_0F;
				case SandDockButtonType.ActiveFiles:
					goto IL_4A;
				}
				return;
				IL_4A:
				x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, SystemPens.ControlText);
				if (!false)
				{
					return;
				}
			}
			IL_0F:
			x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0001EA80 File Offset: 0x0001DA80
		internal virtual void x9271fbf5eef553db(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51)
		{
			if ((x01b557925841ae51 & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				if (!false)
				{
					goto IL_D1;
				}
				IL_11:
				Pen pen;
				x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
				if (!false)
				{
					return;
				}
				IL_D1:
				Pen pen2;
				while ((x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected)
				{
					pen2 = this.x7a0be2490cda8794;
					if (false)
					{
						goto IL_11;
					}
					if (!false)
					{
						pen = this.x050be261498a0c97;
						IL_5C:
						x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
						x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
						x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
						if (false)
						{
							return;
						}
						goto IL_11;
					}
				}
				pen = this.x7a0be2490cda8794;
				pen2 = this.x050be261498a0c97;
				goto IL_5C;
			}
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0001EB88 File Offset: 0x0001DB88
		protected internal override void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled)
		{
			bounds.Width--;
			bool flag = (focused ? 1U : 0U) + (toggled ? 1U : 0U) > uint.MaxValue;
			if (!flag)
			{
				bounds.Height--;
				if ((toggled ? 1U : 0U) <= 4294967295U)
				{
					this.x9271fbf5eef553db(graphics, bounds, state);
					goto IL_D3;
				}
				goto IL_71;
			}
			IL_5D:
			if ((focused ? 1U : 0U) > 4294967295U)
			{
				goto IL_D3;
			}
			IL_71:
			switch (buttonType)
			{
			case SandDockButtonType.Close:
				x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, focused ? SystemPens.ActiveCaptionText : SystemPens.ControlText);
				return;
			case SandDockButtonType.Pin:
				x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, focused ? SystemPens.ActiveCaptionText : SystemPens.ControlText, toggled);
				return;
			case SandDockButtonType.ScrollLeft:
			case SandDockButtonType.ScrollRight:
				break;
			case SandDockButtonType.WindowPosition:
				x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, focused ? SystemPens.ActiveCaptionText : SystemPens.ControlText);
				break;
			default:
				return;
			}
			return;
			IL_D3:
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				bounds.Offset(1, 1);
				goto IL_5D;
			}
			goto IL_5D;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0001EC80 File Offset: 0x0001DC80
		protected internal override void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset)
		{
			graphics.FillRectangle(this.x166a89f4cd379ec8, bounds);
			graphics.DrawLine(this.x7a0be2490cda8794, bounds.X, bounds.Y, bounds.Right, bounds.Y);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0001ECB8 File Offset: 0x0001DCB8
		protected internal override void DrawTabStripTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				goto IL_240;
			}
			bool flag;
			if (!drawSeparator)
			{
				if ((drawSeparator ? 1U : 0U) < 0U)
				{
					goto IL_25;
				}
				if ((drawSeparator ? 1U : 0U) < 0U)
				{
					goto IL_6D;
				}
				flag = ((drawSeparator ? 1U : 0U) - (drawSeparator ? 1U : 0U) < 0U);
				if (flag)
				{
					goto IL_1A7;
				}
				if (((drawSeparator ? 1U : 0U) & 0U) != 0U)
				{
					goto IL_240;
				}
			}
			else
			{
				graphics.DrawLine(SystemPens.ControlDark, bounds.Right, bounds.Top + 3, bounds.Right, bounds.Bottom - 3);
			}
			for (;;)
			{
				IL_D8:
				if (bounds.Width >= 24)
				{
					graphics.DrawImage(image, new Rectangle(bounds.X + 4, bounds.Y + 2, image.Width, image.Height));
				}
				bounds.X += 23;
				if ((drawSeparator ? 1U : 0U) - (drawSeparator ? 1U : 0U) < 0U)
				{
					goto IL_52;
				}
				bounds.Width -= 25;
				if (((drawSeparator ? 1U : 0U) & 0U) != 0U)
				{
					break;
				}
				if (bounds.Width > 8)
				{
					break;
				}
				flag = ((drawSeparator ? 1U : 0U) > uint.MaxValue);
				if (!flag)
				{
					goto IL_112;
				}
			}
			IL_1E:
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				goto IL_25;
			}
			goto IL_52;
			goto IL_1E;
			IL_112:
			flag = ((drawSeparator ? 1U : 0U) < 0U);
			if (flag)
			{
				goto IL_240;
			}
			return;
			IL_25:
			using (SolidBrush solidBrush = new SolidBrush(foreColor))
			{
				graphics.DrawString(text, font, solidBrush, bounds, EverettRenderer.x27e1c82c97265861);
				return;
			}
			IL_52:
			graphics.DrawString(text, font, this.x54c190ae969c389d, bounds, EverettRenderer.x27e1c82c97265861);
			IL_6D:
			return;
			IL_1A7:
			graphics.DrawLine(this.x050be261498a0c97, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
			graphics.DrawLine(this.x7a0be2490cda8794, bounds.Left, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
			graphics.DrawLine(this.x7a0be2490cda8794, bounds.Right, bounds.Top, bounds.Right, bounds.Bottom - 1);
			goto IL_D8;
			IL_240:
			using (SolidBrush solidBrush2 = new SolidBrush(backColor))
			{
				graphics.FillRectangle(solidBrush2, bounds);
				goto IL_1A7;
			}
			goto IL_D8;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0001EF64 File Offset: 0x0001DF64
		protected internal override void DrawAutoHideBarBackground(Control container, Control autoHideBar, Graphics graphics, Rectangle bounds)
		{
			using (this.x166a89f4cd379ec8 = new SolidBrush(this.x7f2683d69c01d139))
			{
				graphics.FillRectangle(this.x166a89f4cd379ec8, bounds);
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0001EFBC File Offset: 0x0001DFBC
		protected internal override void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool vertical)
		{
			using (SolidBrush solidBrush = new SolidBrush(backColor))
			{
				graphics.FillRectangle(solidBrush, bounds);
				goto IL_204;
			}
			return;
			IL_204:
			if (dockSide == DockSide.Top)
			{
				goto IL_190;
			}
			if (false)
			{
				goto IL_A8;
			}
			if (!false)
			{
				goto IL_1AB;
			}
			IL_4A:
			return;
			IL_A8:
			if (!vertical)
			{
				bounds.Offset(23, 0);
				graphics.DrawString(text, font, this.x54c190ae969c389d, bounds, EverettRenderer.x27e1c82c97265861);
				goto IL_4A;
			}
			bounds.Offset(0, 23);
			if (15 != 0)
			{
				goto IL_101;
			}
			IL_D1:
			if (dockSide != DockSide.Left)
			{
				graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom);
				goto IL_141;
			}
			IL_D5:
			bounds.Inflate(-2, -2);
			if (vertical)
			{
				bounds.Offset(0, 1);
				if (((vertical ? 1U : 0U) & 0U) != 0U)
				{
					goto IL_101;
				}
			}
			else
			{
				bounds.Offset(1, 0);
			}
			graphics.DrawImage(image, new Rectangle(bounds.Left, bounds.Top, image.Width, image.Height));
			if (text.Length == 0)
			{
				goto IL_10C;
			}
			goto IL_A8;
			IL_101:
			graphics.DrawString(text, font, this.x54c190ae969c389d, bounds, EverettRenderer.xc351c68a86733972);
			if (!false)
			{
				return;
			}
			IL_10C:
			return;
			IL_111:
			goto IL_D1;
			IL_141:
			if (false)
			{
				goto IL_D1;
			}
			goto IL_D5;
			IL_190:
			if (dockSide == DockSide.Right)
			{
				if (false)
				{
					goto IL_141;
				}
				if (false)
				{
					if ((vertical ? 1U : 0U) <= 4294967295U)
					{
						goto IL_15E;
					}
					goto IL_1AB;
				}
			}
			else
			{
				graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Right, bounds.Top, bounds.Right, bounds.Bottom);
			}
			if (dockSide == DockSide.Bottom)
			{
				goto IL_D1;
			}
			IL_15E:
			graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom);
			goto IL_111;
			IL_1AB:
			graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
			goto IL_190;
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0001F200 File Offset: 0x0001E200
		protected internal override void DrawTitleBarBackground(Graphics graphics, Rectangle bounds, bool focused)
		{
			if (!focused)
			{
				graphics.FillRectangle(SystemBrushes.Control, bounds);
				goto IL_C8;
			}
			IL_97:
			graphics.FillRectangle(SystemBrushes.ActiveCaption, bounds);
			if ((focused ? 1U : 0U) + (focused ? 1U : 0U) <= 4294967295U)
			{
				return;
			}
			IL_C8:
			graphics.DrawLine(SystemPens.ControlDark, bounds.X + 1, bounds.Y, bounds.Right - 2, bounds.Y);
			graphics.DrawLine(SystemPens.ControlDark, bounds.X + 1, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
			graphics.DrawLine(SystemPens.ControlDark, bounds.X, bounds.Y + 1, bounds.X, bounds.Bottom - 2);
			graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Y + 1, bounds.Right - 1, bounds.Bottom - 2);
			if (false)
			{
				goto IL_97;
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0001F308 File Offset: 0x0001E308
		protected internal override void DrawTitleBarText(Graphics graphics, Rectangle bounds, bool focused, string text, Font font)
		{
			Brush brush = focused ? SystemBrushes.ActiveCaptionText : SystemBrushes.ControlText;
			bounds.Inflate(-3, 0);
			graphics.DrawString(text, font, brush, bounds, EverettRenderer.x27e1c82c97265861);
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0001F348 File Offset: 0x0001E348
		public override void FinishRenderSession()
		{
			this.x166a89f4cd379ec8.Dispose();
			this.x7a0be2490cda8794.Dispose();
			if (!false)
			{
			}
			this.x050be261498a0c97.Dispose();
			this.x54c190ae969c389d.Dispose();
			this.xa33e6094d9ed12d6.Dispose();
			this.x2771fbe8bb84042b.Dispose();
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0001F39C File Offset: 0x0001E39C
		public override string ToString()
		{
			return "Everett";
		}

		// Token: 0x04000136 RID: 310
		private static StringFormat xdc3f45c33fe25d85;

		// Token: 0x04000137 RID: 311
		private static StringFormat x7553dbb15fca5d00;

		// Token: 0x04000138 RID: 312
		private Color xef5f9f8a08f25e70 = SystemColors.InactiveCaption;

		// Token: 0x04000139 RID: 313
		private Color x4978f8b41a50b017 = SystemColors.ActiveCaption;

		// Token: 0x0400013A RID: 314
		private Color x228f9881a1be0e5d = SystemColors.ControlText;

		// Token: 0x0400013B RID: 315
		private Color xfca0e3085d5a7f42 = SystemColors.ControlLightLight;

		// Token: 0x0400013C RID: 316
		private Color x1da108dbfca32343 = SystemColors.ControlDarkDark;

		// Token: 0x0400013D RID: 317
		private Color x9c1f2f40026567ee = SystemColors.ControlDark;

		// Token: 0x0400013E RID: 318
		private Color x488edc060a6f4707 = SystemColors.ControlDarkDark;

		// Token: 0x0400013F RID: 319
		private Color x7f2683d69c01d139;

		// Token: 0x04000140 RID: 320
		private SolidBrush x166a89f4cd379ec8;

		// Token: 0x04000141 RID: 321
		private Pen x7a0be2490cda8794;

		// Token: 0x04000142 RID: 322
		private Pen x050be261498a0c97;

		// Token: 0x04000143 RID: 323
		private Pen xa33e6094d9ed12d6;

		// Token: 0x04000144 RID: 324
		private SolidBrush x54c190ae969c389d;

		// Token: 0x04000145 RID: 325
		private StringFormat x2771fbe8bb84042b;

		// Token: 0x04000146 RID: 326
		private BoxModel _x066f993679e36022;

		// Token: 0x04000147 RID: 327
		private BoxModel _x3a1fa93b40743331;

		// Token: 0x04000148 RID: 328
		private BoxModel _x6defba3d5d846e0d;
	}
}

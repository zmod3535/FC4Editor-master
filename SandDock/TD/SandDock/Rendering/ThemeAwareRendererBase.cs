using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
	// Token: 0x02000028 RID: 40
	public abstract class ThemeAwareRendererBase : RendererBase
	{
		// Token: 0x0600038C RID: 908
		protected abstract void ApplyStandardColors();

		// Token: 0x0600038D RID: 909
		protected abstract void ApplyLunaBlueColors();

		// Token: 0x0600038E RID: 910
		protected abstract void ApplyLunaOliveColors();

		// Token: 0x0600038F RID: 911
		protected abstract void ApplyLunaSilverColors();

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0001C6EC File Offset: 0x0001B6EC
		protected TextFormatFlags TextFormat
		{
			get
			{
				return this.xae3b2752a89e7464;
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0001C6F4 File Offset: 0x0001B6F4
		public override void StartRenderSession(HotkeyPrefix hotKeys)
		{
			this.xae3b2752a89e7464 = (TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPadding);
			if (!false)
			{
				if (!false && hotKeys != HotkeyPrefix.None)
				{
					goto IL_2C;
				}
				this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
			}
			IL_14:
			this.x03bb1ee2adad51ea++;
			if (!false)
			{
				return;
			}
			goto IL_2C;
			goto IL_14;
			IL_2C:
			if (hotKeys != HotkeyPrefix.Hide)
			{
				goto IL_14;
			}
			this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
			goto IL_14;
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0001C75C File Offset: 0x0001B75C
		public override void FinishRenderSession()
		{
			this.x03bb1ee2adad51ea = Math.Max(this.x03bb1ee2adad51ea - 1, 0);
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000393 RID: 915 RVA: 0x0001C774 File Offset: 0x0001B774
		// (set) Token: 0x06000394 RID: 916 RVA: 0x0001C77C File Offset: 0x0001B77C
		public Color LayoutBackgroundColor1
		{
			get
			{
				return this.x433ae1e8829e8c68;
			}
			set
			{
				this.x433ae1e8829e8c68 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000395 RID: 917 RVA: 0x0001C78C File Offset: 0x0001B78C
		// (set) Token: 0x06000396 RID: 918 RVA: 0x0001C794 File Offset: 0x0001B794
		public Color LayoutBackgroundColor2
		{
			get
			{
				return this.x15920bc36c82e681;
			}
			set
			{
				this.x15920bc36c82e681 = value;
				base.CustomColors = true;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000397 RID: 919 RVA: 0x0001C7A4 File Offset: 0x0001B7A4
		// (set) Token: 0x06000398 RID: 920 RVA: 0x0001C7AC File Offset: 0x0001B7AC
		public WindowsColorScheme ColorScheme
		{
			get
			{
				return this.x62a65b2c0f145432;
			}
			set
			{
				this.x62a65b2c0f145432 = value;
				this.GetColorsFromSystem();
			}
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0001C7BC File Offset: 0x0001B7BC
		private void xbff62e1edc3f3404(Control xd3311d815ca25f02, Control x43bec302f92080b9, Graphics x41347a961b838962, Rectangle xda73fcb97c77d998)
		{
			Rectangle clientRectangle = xd3311d815ca25f02.ClientRectangle;
			if (false || clientRectangle.Width > 0)
			{
				Rectangle clientRectangle2 = xd3311d815ca25f02.ClientRectangle;
				if (-2 != 0)
				{
					IL_CD:
					while (clientRectangle2.Height <= 0)
					{
						while (3 == 0)
						{
							if (8 != 0 || !false)
							{
								if (false)
								{
									goto IL_CD;
								}
								if (!false)
								{
									break;
								}
							}
						}
						IL_EC:
						if (!false)
						{
							return;
						}
						goto IL_F6;
						goto IL_EC;
					}
					if (false)
					{
						goto IL_EC;
					}
				}
				IL_A0:
				while (xda73fcb97c77d998.Width > 0)
				{
					while (xda73fcb97c77d998.Height > 0)
					{
						do
						{
							Color layoutBackgroundColor = this.LayoutBackgroundColor1;
							for (;;)
							{
								Color layoutBackgroundColor2 = this.LayoutBackgroundColor2;
								if (-2147483648 == 0)
								{
									goto IL_A0;
								}
								if (false)
								{
									break;
								}
								if (false)
								{
									goto IL_F6;
								}
								Point point = x43bec302f92080b9.PointToClient(xd3311d815ca25f02.PointToScreen(new Point(0, 0)));
								Point point2 = x43bec302f92080b9.PointToClient(xd3311d815ca25f02.PointToScreen(new Point(xd3311d815ca25f02.ClientRectangle.Right, 0)));
								using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point, point2, layoutBackgroundColor, layoutBackgroundColor2))
								{
									x41347a961b838962.FillRectangle(linearGradientBrush, xda73fcb97c77d998);
									return;
								}
							}
						}
						while (2 != 0 && true);
					}
					break;
				}
				return;
				IL_F6:
				goto IL_A0;
			}
			if (false)
			{
				return;
			}
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0001C910 File Offset: 0x0001B910
		protected internal override void DrawAutoHideBarBackground(Control container, Control autoHideBar, Graphics graphics, Rectangle bounds)
		{
			this.xbff62e1edc3f3404(container, autoHideBar, graphics, bounds);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0001C920 File Offset: 0x0001B920
		protected internal override void DrawSplitter(Control container, Control control, Graphics graphics, Rectangle bounds, Orientation orientation)
		{
			if (container != null)
			{
				this.xbff62e1edc3f3404(container, control, graphics, bounds);
			}
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0001C930 File Offset: 0x0001B930
		protected internal override void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset)
		{
			this.xbff62e1edc3f3404(container, control, graphics, bounds);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0001C940 File Offset: 0x0001B940
		protected override void GetColorsFromSystem()
		{
			WindowsColorScheme windowsColorScheme = this.x62a65b2c0f145432;
			string a;
			for (;;)
			{
				string text;
				switch (windowsColorScheme)
				{
				case WindowsColorScheme.Automatic:
					if (WhidbeyRenderer.x7fb2e1ce54a27086() && !false && x60f3af502af1d663.x2e20a402b77c44dc)
					{
						goto IL_B0;
					}
					text = "none";
					goto IL_B5;
				case WindowsColorScheme.Standard:
					this.ApplyStandardColors();
					if (!false)
					{
						goto Block_11;
					}
					goto IL_8C;
				case WindowsColorScheme.LunaBlue:
					goto IL_2B;
				case WindowsColorScheme.LunaOlive:
					goto IL_21;
				case WindowsColorScheme.LunaSilver:
					goto IL_0C;
				}
				goto Block_12;
				IL_8C:
				if (a == "NormalColor")
				{
					goto IL_81;
				}
				if (false)
				{
					goto IL_B0;
				}
				if (2 == 0)
				{
					continue;
				}
				goto IL_115;
				IL_B5:
				string text2 = text;
				if (2147483647 == 0)
				{
					goto Block_7;
				}
				if ((a = text2) == null)
				{
					goto Block_3;
				}
				goto IL_8C;
				IL_B0:
				text = x60f3af502af1d663.x4f15c2ab6fab0941;
				goto IL_B5;
			}
			IL_0C:
			this.ApplyLunaSilverColors();
			IL_12:
			base.GetColorsFromSystem();
			return;
			IL_21:
			this.ApplyLunaOliveColors();
			goto IL_12;
			IL_2B:
			this.ApplyLunaBlueColors();
			goto IL_12;
			IL_33:
			this.ApplyStandardColors();
			if (2 != 0)
			{
				goto IL_12;
			}
			IL_42:
			if (a == "Metallic")
			{
				this.ApplyLunaSilverColors();
				goto IL_12;
			}
			Block_3:
			goto IL_33;
			IL_81:
			this.ApplyLunaBlueColors();
			goto IL_12;
			IL_9B:
			goto IL_33;
			Block_7:
			goto IL_9B;
			Block_11:
			if (3 == 0)
			{
				goto IL_33;
			}
			Block_12:
			goto IL_12;
			IL_115:
			if (a == "HomeStead")
			{
				this.ApplyLunaOliveColors();
				goto IL_12;
			}
			goto IL_42;
		}

		// Token: 0x0400012B RID: 299
		private WindowsColorScheme x62a65b2c0f145432;

		// Token: 0x0400012C RID: 300
		private Color x433ae1e8829e8c68;

		// Token: 0x0400012D RID: 301
		private Color x15920bc36c82e681;

		// Token: 0x0400012E RID: 302
		private int x03bb1ee2adad51ea;

		// Token: 0x0400012F RID: 303
		private TextFormatFlags xae3b2752a89e7464;
	}
}

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using TD.Util;

namespace TD.SandDock
{
	// Token: 0x02000032 RID: 50
	internal class x87cf4de36131799d : Control
	{
		// Token: 0x06000423 RID: 1059 RVA: 0x000212E4 File Offset: 0x000202E4
		public x87cf4de36131799d(x10ac79a4257c7f52 bar)
		{
			if (8 != 0 && !false)
			{
				this.x2ee8392f53a01b93 = bar;
				base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
				base.SetStyle(ControlStyles.Selectable, false);
				this.xac1c850120b1f254 = new xf8f9565783602018(this);
				this.xac1c850120b1f254.xa6e4f463e64a5987 = false;
			}
			this.xac1c850120b1f254.x9b21ee8e7ceaada3 += this.xa3a7472ac4e61f76;
			this.BackColor = SystemColors.Control;
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00021360 File Offset: 0x00020360
		private void x81dc33c66d5e1e33(Point xcb09bd0cee4909a3)
		{
			this.x372569d2ea29984e = new x7fc004d490c8a431(this.x2ee8392f53a01b93, this, xcb09bd0cee4909a3);
			this.x372569d2ea29984e.x868a32060451dd2e += this.xfae511fd7c4fb447;
			this.x372569d2ea29984e.x67ecc0d0e7c9a202 += this.xc555e814c1720baf;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x000213B0 File Offset: 0x000203B0
		private void xd5979b8834306b81()
		{
			this.x372569d2ea29984e.x868a32060451dd2e -= this.xfae511fd7c4fb447;
			this.x372569d2ea29984e.x67ecc0d0e7c9a202 -= this.xc555e814c1720baf;
			this.x372569d2ea29984e = null;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x000213E8 File Offset: 0x000203E8
		private void xfae511fd7c4fb447(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xd5979b8834306b81();
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000213F0 File Offset: 0x000203F0
		private void xc555e814c1720baf(int x0d4b3b88c5b24565)
		{
			this.xd5979b8834306b81();
			this.xca843b3e9a1c605f = x0d4b3b88c5b24565;
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x00021400 File Offset: 0x00020400
		// (set) Token: 0x06000429 RID: 1065 RVA: 0x00021438 File Offset: 0x00020438
		public int xca843b3e9a1c605f
		{
			get
			{
				if (this.x2ee8392f53a01b93.Dock != DockStyle.Left && this.x2ee8392f53a01b93.Dock != DockStyle.Right)
				{
					return this.x21ed2ecc088ef4e4.Height;
				}
				return this.x21ed2ecc088ef4e4.Width;
			}
			set
			{
				Rectangle bounds = base.Bounds;
				bool flag = (uint)value < 0U;
				int num;
				if (!flag)
				{
					for (;;)
					{
						num = value;
						do
						{
							if (!this.x61fa1911d2d31a75)
							{
								for (;;)
								{
									flag = ((uint)value > uint.MaxValue);
									if (flag || ((uint)value | 4294967294U) == 0U)
									{
										break;
									}
									if (!false)
									{
										goto IL_E0;
									}
									if (((uint)num | 4U) != 0U)
									{
										goto IL_87;
									}
								}
							}
							else
							{
								num += 4;
							}
						}
						while (false);
						IL_E0:
						switch (this.x2ee8392f53a01b93.Dock)
						{
						case DockStyle.Top:
							goto IL_87;
						case DockStyle.Bottom:
							goto IL_50;
						case DockStyle.Left:
							goto IL_B8;
						case DockStyle.Right:
							bounds.X = bounds.Right - num;
							bounds.Width = num;
							flag = ((uint)value - (uint)num < 0U);
							if (flag)
							{
								continue;
							}
							goto IL_14C;
						}
						goto IL_104;
						goto IL_E0;
					}
					IL_50:
					bounds.Y = bounds.Bottom - num;
					bounds.Height = num;
					goto IL_1E;
					IL_87:
					bounds.Height = num;
					goto IL_1E;
					IL_B8:
					bounds.Width = num;
					goto IL_1E;
					IL_14C:
					flag = ((uint)num - (uint)num < 0U);
					if (flag)
					{
						return;
					}
				}
				IL_1E:
				base.Bounds = bounds;
				if ((uint)num - (uint)num <= 4294967295U)
				{
					this.x5a9cbf8ad0ee9896.xca843b3e9a1c605f = value;
					return;
				}
				IL_104:
				goto IL_1E;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x000215AC File Offset: 0x000205AC
		public bool x1c3de22188ea5bb2
		{
			get
			{
				return this.x372569d2ea29984e != null;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x000215BC File Offset: 0x000205BC
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x000215C4 File Offset: 0x000205C4
		public ControlLayoutSystem x5a9cbf8ad0ee9896
		{
			get
			{
				return this.x6e150040c8d97700;
			}
			set
			{
				this.x6e150040c8d97700 = value;
				base.PerformLayout();
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x000215D4 File Offset: 0x000205D4
		private bool x61fa1911d2d31a75
		{
			get
			{
				return this.x2ee8392f53a01b93.x460ab163f44a604d.AllowDockContainerResize;
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x000215E8 File Offset: 0x000205E8
		protected override void OnLayout(LayoutEventArgs levent)
		{
			if (this.x6e150040c8d97700 != null)
			{
				this.x21ed2ecc088ef4e4 = base.ClientRectangle;
				if (false)
				{
					goto IL_1D4;
				}
				if (this.x61fa1911d2d31a75)
				{
					goto IL_1D4;
				}
				this.x59f159fe47159543 = Rectangle.Empty;
				IL_31:
				this.x6e150040c8d97700.LayoutCollapsed(this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer, this.x21ed2ecc088ef4e4);
				if (255 != 0)
				{
					base.Invalidate();
				}
				return;
				IL_1D4:
				switch (this.x2ee8392f53a01b93.Dock)
				{
				case DockStyle.Top:
					this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Bottom - 4, this.x21ed2ecc088ef4e4.Width, 4);
					this.x21ed2ecc088ef4e4.Height = this.x21ed2ecc088ef4e4.Height - 4;
					if (4 != 0 && !false)
					{
						goto IL_31;
					}
					goto IL_18D;
				case DockStyle.Bottom:
					this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Y, this.x21ed2ecc088ef4e4.Width, 4);
					if (!false)
					{
						this.x21ed2ecc088ef4e4.Y = this.x21ed2ecc088ef4e4.Y + 4;
						this.x21ed2ecc088ef4e4.Height = this.x21ed2ecc088ef4e4.Height - 4;
						goto IL_31;
					}
					break;
				case DockStyle.Left:
					this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Right - 4, this.x21ed2ecc088ef4e4.Y, 4, this.x21ed2ecc088ef4e4.Height);
					this.x21ed2ecc088ef4e4.Width = this.x21ed2ecc088ef4e4.Width - 4;
					if (!false)
					{
					}
					goto IL_31;
				case DockStyle.Right:
					goto IL_18D;
				}
				goto IL_1F8;
				IL_18D:
				this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Y, 4, this.x21ed2ecc088ef4e4.Height);
				this.x21ed2ecc088ef4e4.X = this.x21ed2ecc088ef4e4.X + 4;
				this.x21ed2ecc088ef4e4.Width = this.x21ed2ecc088ef4e4.Width - 4;
				goto IL_31;
				IL_1F8:
				this.x59f159fe47159543 = Rectangle.Empty;
				goto IL_31;
			}
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00021810 File Offset: 0x00020810
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				IL_15E:
				while (!base.IsDisposed)
				{
					for (;;)
					{
						if (!true)
						{
							goto IL_A3;
						}
						goto IL_99;
						IL_6D:
						this.x5a9cbf8ad0ee9896 = null;
						if (this.xac1c850120b1f254 != null)
						{
							this.xac1c850120b1f254.Dispose();
							goto IL_38;
						}
						if (4 == 0)
						{
							goto IL_50;
						}
						if (!false)
						{
							goto IL_183;
						}
						bool flag = (disposing ? 1U : 0U) - (disposing ? 1U : 0U) < 0U;
						if (flag)
						{
							continue;
						}
						goto IL_15E;
						IL_5A:
						this.x2ee8392f53a01b93.xcdb145600c1b7224(true);
						this.x2ee8392f53a01b93 = null;
						goto IL_6D;
						IL_50:
						if (2147483647 == 0)
						{
							goto IL_99;
						}
						if (!false)
						{
							goto IL_5A;
						}
						goto IL_38;
						IL_12:
						if (this.x372569d2ea29984e != null)
						{
							break;
						}
						if (255 != 0)
						{
							goto IL_21;
						}
						goto IL_50;
						IL_38:
						this.xac1c850120b1f254 = null;
						goto IL_12;
						IL_99:
						if (!base.ContainsFocus)
						{
							goto IL_5A;
						}
						IL_A3:
						if (this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm == null)
						{
							goto IL_5A;
						}
						if (!this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm.IsMdiContainer)
						{
							goto IL_5A;
						}
						if (false)
						{
							goto IL_6D;
						}
						if (this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm.ActiveMdiChild == null)
						{
							goto IL_5A;
						}
						this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm.ActiveControl = this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm.ActiveMdiChild;
						flag = ((disposing ? 1U : 0U) - (disposing ? 1U : 0U) < 0U);
						if (!flag)
						{
							goto IL_50;
						}
						if (((disposing ? 1U : 0U) & 0U) == 0U)
						{
							goto IL_99;
						}
						if (false)
						{
							goto IL_15E;
						}
						flag = ((disposing ? 1U : 0U) > uint.MaxValue);
						if (!flag)
						{
							goto IL_50;
						}
						IL_183:
						goto IL_12;
					}
					this.xd5979b8834306b81();
					break;
				}
			}
			IL_21:
			base.Dispose(disposing);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000219A8 File Offset: 0x000209A8
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			if (this.x6e150040c8d97700 != null)
			{
				this.x6e150040c8d97700.xd541e2fc281b554b();
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x000219C4 File Offset: 0x000209C4
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			if (this.x6e150040c8d97700 != null)
			{
				this.x6e150040c8d97700.xd541e2fc281b554b();
			}
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000219E4 File Offset: 0x000209E4
		private string xa3a7472ac4e61f76(Point xb9c2cfae130d9256)
		{
			if (!this.x21ed2ecc088ef4e4.Contains(xb9c2cfae130d9256) || this.x6e150040c8d97700 == null)
			{
				return "";
			}
			return this.x6e150040c8d97700.xe0e7b93bedab6c05(xb9c2cfae130d9256);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00021A10 File Offset: 0x00020A10
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (-2147483648 == 0)
			{
				goto IL_B4;
			}
			if (this.x59f159fe47159543.Contains(e.X, e.Y))
			{
				goto IL_12C;
			}
			if (!true)
			{
				goto IL_F4;
			}
			goto IL_114;
			IL_68:
			while (base.Capture)
			{
				if (false)
				{
					if (-2 == 0)
					{
						continue;
					}
					if (false)
					{
						if (false)
						{
							break;
						}
						goto IL_B4;
					}
					else
					{
						if (false)
						{
							return;
						}
						goto IL_5E;
					}
				}
				IL_2F:
				if (this.x372569d2ea29984e == null)
				{
					IL_11:
					if (this.x21ed2ecc088ef4e4.Contains(e.X, e.Y))
					{
						if (this.x6e150040c8d97700 == null)
						{
							return;
						}
						this.x6e150040c8d97700.OnMouseMove(e);
						if (255 != 0)
						{
							return;
						}
					}
					if (2 != 0)
					{
						return;
					}
				}
				else
				{
					this.x372569d2ea29984e.OnMouseMove(new Point(e.X, e.Y));
					if (2147483647 == 0)
					{
						goto IL_B4;
					}
					return;
				}
				IL_5E:
				if (!false)
				{
				}
				goto IL_2F;
			}
			goto IL_11;
			IL_B4:
			if (this.x372569d2ea29984e == null)
			{
				Cursor.Current = Cursors.Default;
				goto IL_68;
			}
			goto IL_12C;
			IL_F4:
			Cursor.Current = Cursors.VSplit;
			goto IL_68;
			IL_114:
			goto IL_B4;
			IL_12C:
			if (this.x2ee8392f53a01b93.Dock == DockStyle.Left || this.x2ee8392f53a01b93.Dock == DockStyle.Right)
			{
				goto IL_F4;
			}
			if (false)
			{
				goto IL_114;
			}
			Cursor.Current = Cursors.HSplit;
			goto IL_68;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00021B5C File Offset: 0x00020B5C
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (this.x6e150040c8d97700 != null)
			{
				this.x6e150040c8d97700.OnMouseLeave();
			}
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00021B78 File Offset: 0x00020B78
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			for (;;)
			{
				IL_97:
				if (!false)
				{
					for (;;)
					{
						if (!this.x59f159fe47159543.Contains(e.X, e.Y))
						{
							goto IL_8E;
						}
						if (e.Button == MouseButtons.Left)
						{
							goto IL_A2;
						}
						if (!false)
						{
							goto IL_69;
						}
						IL_62:
						if (-2 == 0)
						{
							continue;
						}
						IL_69:
						if (!this.x21ed2ecc088ef4e4.Contains(e.X, e.Y))
						{
							return;
						}
						if (false)
						{
							if (8 != 0)
							{
								goto IL_62;
							}
							goto IL_62;
						}
						else
						{
							if (-1 == 0)
							{
								goto IL_97;
							}
							if (2 == 0)
							{
								return;
							}
							if (!false)
							{
								break;
							}
						}
						IL_8E:
						goto IL_69;
					}
				}
				if (this.x6e150040c8d97700 != null)
				{
					break;
				}
				if (3 != 0)
				{
					return;
				}
			}
			this.x6e150040c8d97700.OnMouseDown(e);
			return;
			IL_A2:
			this.x81dc33c66d5e1e33(new Point(e.X, e.Y));
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00021C4C File Offset: 0x00020C4C
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			do
			{
				if (this.x372569d2ea29984e != null)
				{
					if (e.Button == MouseButtons.Left)
					{
						goto Block_9;
					}
				}
				for (;;)
				{
					if (!this.x21ed2ecc088ef4e4.Contains(e.X, e.Y))
					{
						goto IL_5A;
					}
					if (this.x6e150040c8d97700 == null)
					{
						return;
					}
					this.x6e150040c8d97700.OnMouseUp(e);
					if (false)
					{
						goto IL_5A;
					}
					if (3 == 0)
					{
						continue;
					}
					IL_15:
					if (true)
					{
						goto IL_23;
					}
					continue;
					IL_1E:
					if (false)
					{
						goto IL_15;
					}
					if (-2147483648 != 0)
					{
						break;
					}
					IL_23:
					if (!false)
					{
						goto Block_4;
					}
					IL_5A:
					goto IL_1E;
				}
			}
			while (-1 == 0);
			Block_4:
			return;
			Block_9:
			this.x372569d2ea29984e.Commit();
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00021CF8 File Offset: 0x00020CF8
		protected override void OnPaint(PaintEventArgs e)
		{
			this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer.StartRenderSession(HotkeyPrefix.None);
			if (!false)
			{
				goto IL_C5;
			}
			IL_1C:
			if (false)
			{
				return;
			}
			IL_22:
			if (this.x61fa1911d2d31a75)
			{
				this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer.DrawSplitter(null, this, e.Graphics, this.x59f159fe47159543, (this.x2ee8392f53a01b93.Dock == DockStyle.Top || this.x2ee8392f53a01b93.Dock == DockStyle.Bottom) ? Orientation.Horizontal : Orientation.Vertical);
			}
			this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer.FinishRenderSession();
			if (!false)
			{
				return;
			}
			IL_C5:
			if (-2 == 0)
			{
				if (false)
				{
					goto IL_1C;
				}
			}
			else if (this.x6e150040c8d97700 == null)
			{
				goto IL_22;
			}
			this.x6e150040c8d97700.x84b6f3c22477dacb(this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer, e.Graphics, this.Font);
			goto IL_22;
		}

		// Token: 0x0400015B RID: 347
		private x10ac79a4257c7f52 x2ee8392f53a01b93;

		// Token: 0x0400015C RID: 348
		private ControlLayoutSystem x6e150040c8d97700;

		// Token: 0x0400015D RID: 349
		private x7fc004d490c8a431 x372569d2ea29984e;

		// Token: 0x0400015E RID: 350
		private Rectangle x21ed2ecc088ef4e4;

		// Token: 0x0400015F RID: 351
		private Rectangle x59f159fe47159543;

		// Token: 0x04000160 RID: 352
		private xf8f9565783602018 xac1c850120b1f254;
	}
}

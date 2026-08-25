using System;
using System.Drawing;
using System.Windows.Forms;
using TD.Util;

namespace TD.SandBar
{
	// Token: 0x02000024 RID: 36
	public partial class PopupMenu : Form
	{
		// Token: 0x06000204 RID: 516 RVA: 0x00009284 File Offset: 0x00008284
		protected internal PopupMenu(MenuItemBase menuItem, IPopupMenuHost host)
		{
			this.x7bf8c4d03998048a = menuItem;
			this.x64f259306803411c = host;
			base.FormBorderStyle = FormBorderStyle.None;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.Manual;
			base.SetStyle(ControlStyles.Selectable, false);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			this.x5d56ae798b9cdf38 = new Timer();
			this.x5d56ae798b9cdf38.Interval = 20;
			this.x5d56ae798b9cdf38.Tick += this.xcaf19fd9570f4eb4;
			this.xf3096a62f62f7b4a = new MenuButtonItem();
			this.xf3096a62f62f7b4a.xb2b69aae23a4ae6d(menuItem);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00009318 File Offset: 0x00008318
		internal void xd95bd0c58a935da0(xf92605a24a69622a xfc6f89c16b215667, Screen x5f4a93c3032a9eb8)
		{
			this.x10d0328f698a7faa = new x1fd873a54f087a8c(this, xfc6f89c16b215667, x5f4a93c3032a9eb8);
			this.x20aee281977480cf();
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00009330 File Offset: 0x00008330
		internal void xb7036c6dfbc891e0(Control x2e56ed5925efe990)
		{
			this.x10d0328f698a7faa = new x4bb39eb6330384f7(this, x2e56ed5925efe990);
			this.xa1808e2c9a448af8 = true;
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			x443cc432acaadb1d.SetParent(base.Handle, x2e56ed5925efe990.Handle);
			this.x20aee281977480cf();
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000936C File Offset: 0x0000836C
		private void x20aee281977480cf()
		{
			foreach (object obj in this.x7bf8c4d03998048a.Items)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
				menuButtonItem.x3780ff57150950cd = (menuButtonItem.ItemImportance == ItemImportance.Low && this.x10d0328f698a7faa.AllowLowImportanceMenuItems);
				this.xc0e29aedef0854d2 = (this.xc0e29aedef0854d2 || menuButtonItem.x3780ff57150950cd);
			}
		}

		// Token: 0x06000208 RID: 520 RVA: 0x00009404 File Offset: 0x00008404
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			throw new InvalidOperationException("SandBar menus cannot receive the focus.");
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000209 RID: 521 RVA: 0x00009418 File Offset: 0x00008418
		internal MenuButtonItem x5683678bceda6657
		{
			get
			{
				return this.xf3096a62f62f7b4a;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600020A RID: 522 RVA: 0x00009420 File Offset: 0x00008420
		private bool xfa312a6593fa5919
		{
			get
			{
				return this.xc0e29aedef0854d2 || this.xa1808e2c9a448af8;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600020B RID: 523 RVA: 0x00009434 File Offset: 0x00008434
		// (set) Token: 0x0600020C RID: 524 RVA: 0x0000943C File Offset: 0x0000843C
		internal bool xd3b329aadd8fdeb3
		{
			get
			{
				return this.xfbb4579b829aef10;
			}
			set
			{
				this.xfbb4579b829aef10 = value;
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00009448 File Offset: 0x00008448
		protected void EnableToolTips()
		{
			this.xac1c850120b1f254 = new xf8f9565783602018(this);
			this.xac1c850120b1f254.xa6e4f463e64a5987 = false;
			this.xac1c850120b1f254.x9b21ee8e7ceaada3 += this.x7770570abeef94ae;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000947C File Offset: 0x0000847C
		internal void xaabd57163b310c49()
		{
			foreach (object obj in this.x7bf8c4d03998048a.Items)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
				if (menuButtonItem.ItemImportance == ItemImportance.Low)
				{
					menuButtonItem.x3780ff57150950cd = false;
				}
			}
			this.xc0e29aedef0854d2 = false;
			this.x10d0328f698a7faa.LowImportanceItemsExpanded();
			this.xcf42ad4a4f3fcbf6();
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600020F RID: 527 RVA: 0x00009508 File Offset: 0x00008508
		protected internal MenuItemBase MenuItem
		{
			get
			{
				return this.x7bf8c4d03998048a;
			}
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00009510 File Offset: 0x00008510
		internal void x35579b297303ed43(TopLevelMenuItemBase.MenuAnimation xae4f5ff1269207fe)
		{
			int num = 0;
			this.x35579b297303ed43(ref num, xae4f5ff1269207fe);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00009528 File Offset: 0x00008528
		internal void x35579b297303ed43(ref int x2286e22de2d4a38e, TopLevelMenuItemBase.MenuAnimation xae4f5ff1269207fe)
		{
			this.x10d0328f698a7faa.Show(ref x2286e22de2d4a38e, xae4f5ff1269207fe);
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.Visible = true;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000095DC File Offset: 0x000085DC
		internal void xcf42ad4a4f3fcbf6()
		{
			this.x9f953666761d03df(this.xf13a675fdb7b229b);
			this.xfb14a9f3dcd92a45();
			base.Invalidate();
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000214 RID: 532 RVA: 0x000095F8 File Offset: 0x000085F8
		protected virtual Size DesiredClientSize
		{
			get
			{
				Size empty = Size.Empty;
				Size sz = Size.Empty;
				using (Graphics graphics = base.CreateGraphics())
				{
					bool flag = true;
					foreach (object obj in this.x7bf8c4d03998048a.Items)
					{
						MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
						if (menuButtonItem.Visible && !menuButtonItem.x3780ff57150950cd)
						{
							sz = x3ddece31da445155.x92a98ee313cca646(graphics, menuButtonItem, this.x64f259306803411c.MenuImageList, this.x64f259306803411c);
							if (sz.Width > empty.Width)
							{
								empty.Width = sz.Width;
							}
							if (menuButtonItem.BeginGroup && !flag)
							{
								empty.Height += 3;
							}
							flag = false;
							empty.Height += sz.Height + 1;
						}
					}
					if (sz != Size.Empty)
					{
						empty.Height--;
					}
				}
				this.xd1a4ac20d7e3fc13 = x3ddece31da445155.x37affa25095b1846(this.x7bf8c4d03998048a.Items, this.x64f259306803411c.MenuImageList);
				if (this.x7bf8c4d03998048a.Parent is xb3f7a6163630a970)
				{
					this.xd1a4ac20d7e3fc13 += 22;
				}
				empty.Width += this.xd1a4ac20d7e3fc13;
				if (this.x7bf8c4d03998048a is ContainerBarTitleBarMenu)
				{
					empty.Width = Math.Max(empty.Width, this.x7bf8c4d03998048a.ButtonBounds.Width);
				}
				return empty;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000215 RID: 533 RVA: 0x000097CC File Offset: 0x000087CC
		private Size x95f43364065e63e8
		{
			get
			{
				Size desiredClientSize = this.DesiredClientSize;
				desiredClientSize.Width += 2;
				desiredClientSize.Height += 4;
				if (this.xfa312a6593fa5919)
				{
					desiredClientSize.Height += 18;
				}
				if (this.xa1808e2c9a448af8 && desiredClientSize.Width < 100)
				{
					desiredClientSize.Width = 100;
				}
				return desiredClientSize;
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00009834 File Offset: 0x00008834
		public virtual MenuButtonItem GetItemAt(Point position)
		{
			foreach (object obj in this.x7bf8c4d03998048a.Items)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
				if (menuButtonItem.Visible && !menuButtonItem.x3780ff57150950cd && menuButtonItem.ButtonBounds.Contains(position))
				{
					return menuButtonItem;
				}
			}
			if (this.xfa312a6593fa5919 && this.xf3096a62f62f7b4a.ButtonBounds.Contains(position))
			{
				return this.xf3096a62f62f7b4a;
			}
			return null;
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000217 RID: 535 RVA: 0x000098E8 File Offset: 0x000088E8
		protected Rectangle ItemDisplayArea
		{
			get
			{
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.Inflate(-1, -2);
				if (this.xdc850c3fee9712fc)
				{
					clientRectangle.Inflate(0, -10);
				}
				return clientRectangle;
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000991C File Offset: 0x0000891C
		protected override void OnResize(EventArgs e)
		{
			if (!this.x833319a7a503e226)
			{
				this.xfb14a9f3dcd92a45();
				base.OnResize(e);
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000219 RID: 537 RVA: 0x00009934 File Offset: 0x00008934
		protected int ScrollOffset
		{
			get
			{
				return this.x200b7f5a9d983ba4;
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000993C File Offset: 0x0000893C
		protected virtual void LayoutChildItems(Graphics graphics, Rectangle itemDisplayArea)
		{
			bool flag = true;
			int num = itemDisplayArea.Top - this.x200b7f5a9d983ba4;
			foreach (object obj in this.x7bf8c4d03998048a.Items)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
				if (menuButtonItem.Visible && !menuButtonItem.x3780ff57150950cd)
				{
					menuButtonItem.x3de314ab70bbd9bf = (menuButtonItem.BeginGroup && !flag);
					if (menuButtonItem.x3de314ab70bbd9bf)
					{
						num += 3;
					}
					flag = false;
					Size size = x3ddece31da445155.x92a98ee313cca646(graphics, menuButtonItem, this.x64f259306803411c.MenuImageList, this.x64f259306803411c);
					Rectangle buttonBounds = itemDisplayArea;
					buttonBounds.Y = num;
					buttonBounds.Height = size.Height + 1;
					menuButtonItem.ApplyLayout(buttonBounds, graphics, this.Host.Flow == ToolBarLayout.Vertical, this.Host.RightToLeft);
					num += buttonBounds.Height;
				}
			}
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00009A58 File Offset: 0x00008A58
		private void xfb14a9f3dcd92a45()
		{
			Size x95f43364065e63e = this.x95f43364065e63e8;
			this.xdc850c3fee9712fc = (base.Height < x95f43364065e63e.Height);
			if (this.xdc850c3fee9712fc)
			{
				this.x648389b128a52ae0 = x95f43364065e63e.Height - base.Height + 20;
				this.xd2e19ddc2c3e7aa1 = base.ClientRectangle;
				this.xd2e19ddc2c3e7aa1.Width = this.xd2e19ddc2c3e7aa1.Width - 1;
				this.xd2e19ddc2c3e7aa1.Inflate(-1, -1);
				this.xd2e19ddc2c3e7aa1.Height = 10;
				this.xe41e3e6eb8fced84 = this.xd2e19ddc2c3e7aa1;
				this.xe41e3e6eb8fced84.Y = base.ClientRectangle.Height - 10 - 1;
			}
			using (Graphics graphics = base.CreateGraphics())
			{
				this.LayoutChildItems(graphics, this.ItemDisplayArea);
				if (this.xfa312a6593fa5919)
				{
					Rectangle itemDisplayArea = this.ItemDisplayArea;
					itemDisplayArea.Y = itemDisplayArea.Bottom - 18 + 1;
					itemDisplayArea.Height = 18;
					this.xf3096a62f62f7b4a.ApplyLayout(itemDisplayArea, graphics, this.Host.Flow == ToolBarLayout.Vertical, this.Host.RightToLeft);
				}
			}
			base.Invalidate();
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00009B98 File Offset: 0x00008B98
		internal void x00a9ccc077fe5b1a(int x23e85093ba3a7d1d)
		{
			int num = this.x7bf8c4d03998048a.Items.IndexOf(this.x7bf8c4d03998048a.xe4f42f0e511fcd41);
			do
			{
				num += x23e85093ba3a7d1d;
				if (num == this.x7bf8c4d03998048a.Items.Count && this.xfa312a6593fa5919)
				{
					num = 0;
					this.xaabd57163b310c49();
				}
				if (num == this.x7bf8c4d03998048a.Items.Count)
				{
					num = 0;
				}
				if (num < 0)
				{
					num = this.x7bf8c4d03998048a.Items.Count - 1;
				}
			}
			while (!this.x7bf8c4d03998048a.Items[num].Visible || this.x7bf8c4d03998048a.Items[num].x3780ff57150950cd);
			this.x7bf8c4d03998048a.xe4f42f0e511fcd41 = this.x7bf8c4d03998048a.Items[num];
			this.x7bf8c4d03998048a.xe4f42f0e511fcd41.OnSelect();
			if (this.xdc850c3fee9712fc)
			{
				if (this.x7bf8c4d03998048a.xe4f42f0e511fcd41.ButtonBounds.Y <= this.xd2e19ddc2c3e7aa1.Bottom)
				{
					this.x200b7f5a9d983ba4 -= this.xd2e19ddc2c3e7aa1.Bottom - this.x7bf8c4d03998048a.xe4f42f0e511fcd41.ButtonBounds.Y + 1;
					this.xfb14a9f3dcd92a45();
				}
				if (this.x7bf8c4d03998048a.xe4f42f0e511fcd41.ButtonBounds.Bottom > this.xe41e3e6eb8fced84.Y)
				{
					this.x200b7f5a9d983ba4 += this.x7bf8c4d03998048a.xe4f42f0e511fcd41.ButtonBounds.Bottom - this.xe41e3e6eb8fced84.Y;
					this.xfb14a9f3dcd92a45();
				}
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00009D3C File Offset: 0x00008D3C
		protected virtual void PaintChildItems(PaintEventArgs e)
		{
			foreach (object obj in this.x7bf8c4d03998048a.Items)
			{
				MenuButtonItem menuButtonItem = (MenuButtonItem)obj;
				if (menuButtonItem.Visible && !menuButtonItem.x3780ff57150950cd)
				{
					if (menuButtonItem.x3de314ab70bbd9bf)
					{
						Rectangle buttonBounds = menuButtonItem.ButtonBounds;
						buttonBounds.Y -= 3;
						this.x64f259306803411c.Renderer.DrawMenuSeparator(e.Graphics, buttonBounds, this.xd1a4ac20d7e3fc13, this.x64f259306803411c.RightToLeft);
					}
					DrawItemState drawItemState = DrawItemState.Default;
					if (this.ShouldHighlightItem(menuButtonItem))
					{
						drawItemState |= DrawItemState.HotLight;
					}
					if (!menuButtonItem.Enabled)
					{
						drawItemState |= DrawItemState.Disabled;
					}
					this.x64f259306803411c.Renderer.DrawMenuItem(e.Graphics, menuButtonItem, this.x64f259306803411c, this.xd1a4ac20d7e3fc13, drawItemState, this.x7bf8c4d03998048a.Parent is xb3f7a6163630a970);
				}
			}
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00009E58 File Offset: 0x00008E58
		protected bool ShouldHighlightItem(MenuButtonItem item)
		{
			return this.x10d0328f698a7faa.ShouldHighlightItem(item);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00009E68 File Offset: 0x00008E68
		protected sealed override void OnPaintBackground(PaintEventArgs pevent)
		{
			Rectangle bounds = base.ClientRectangle;
			if (-2147483648 != 0)
			{
				goto IL_CC;
			}
			IL_11:
			IL_45:
			if (this.x200b7f5a9d983ba4 < this.x648389b128a52ae0)
			{
				if (15 != 0)
				{
					this.x90554b00db0ad926(pevent.Graphics, base.ClientRectangle.Width / 2 - 2, this.xe41e3e6eb8fced84.Top + 3, 1, SystemColors.ControlText);
					return;
				}
				goto IL_1E8;
			}
			else
			{
				this.x90554b00db0ad926(pevent.Graphics, base.ClientRectangle.Width / 2 - 2, this.xe41e3e6eb8fced84.Top + 3, 1, SystemColors.ControlDark);
				if (255 != 0)
				{
					return;
				}
			}
			IL_CC:
			bounds.Width--;
			bounds.Height--;
			MenuProjection menuDirection = MenuProjection.Bottom;
			if (this.x7bf8c4d03998048a is TopLevelMenuItemBase)
			{
				menuDirection = ((TopLevelMenuItemBase)this.x7bf8c4d03998048a).MenuDirection;
			}
			this.x64f259306803411c.Renderer.DrawMenuBackground(pevent.Graphics, bounds, this.xd1a4ac20d7e3fc13, this.x4c9b7a18395fc053, this.x030d4163f566f83d, menuDirection, this.x64f259306803411c.RightToLeft, this.x64f259306803411c.RightAlignMenus);
			Region clip = null;
			if (this.xdc850c3fee9712fc)
			{
				clip = pevent.Graphics.Clip;
				pevent.Graphics.SetClip(this.ItemDisplayArea);
			}
			this.PaintChildItems(pevent);
			if (this.xdc850c3fee9712fc)
			{
				pevent.Graphics.Clip = clip;
			}
			if (!this.xfa312a6593fa5919)
			{
				goto IL_21B;
			}
			DrawItemState drawItemState = DrawItemState.Default;
			if (this.x7bf8c4d03998048a.xe4f42f0e511fcd41 == this.xf3096a62f62f7b4a)
			{
				drawItemState |= DrawItemState.HotLight;
			}
			this.x64f259306803411c.Renderer.DrawMenuItem(pevent.Graphics, this.xf3096a62f62f7b4a, this.x64f259306803411c, this.xd1a4ac20d7e3fc13, drawItemState, false);
			bounds = this.xf3096a62f62f7b4a.ButtonBounds;
			IL_1E8:
			bounds.Y--;
			this.x64f259306803411c.Renderer.DrawMenuActionsButton(pevent.Graphics, bounds, this.xd1a4ac20d7e3fc13, drawItemState, this.xa1808e2c9a448af8);
			IL_21B:
			if (this.xdc850c3fee9712fc)
			{
				if (this.x200b7f5a9d983ba4 > 0)
				{
					this.x90554b00db0ad926(pevent.Graphics, base.ClientRectangle.Width / 2 - 2, this.xd2e19ddc2c3e7aa1.Top + 7, -1, SystemColors.ControlText);
					goto IL_11;
				}
				this.x90554b00db0ad926(pevent.Graphics, base.ClientRectangle.Width / 2 - 2, this.xd2e19ddc2c3e7aa1.Top + 7, -1, SystemColors.ControlDark);
				goto IL_45;
			}
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000A0DC File Offset: 0x000090DC
		private void x90554b00db0ad926(Graphics x41347a961b838962, int x08db3aeabb253cb1, int x1e218ceaee1bb583, int x23e85093ba3a7d1d, Color x6c50a99faab7d741)
		{
			Pen pen = new Pen(x6c50a99faab7d741);
			x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1, x1e218ceaee1bb583, x08db3aeabb253cb1 + 4, x1e218ceaee1bb583);
			x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1 + 1, x1e218ceaee1bb583 + x23e85093ba3a7d1d, x08db3aeabb253cb1 + 3, x1e218ceaee1bb583 + x23e85093ba3a7d1d);
			x41347a961b838962.DrawLine(pen, x08db3aeabb253cb1 + 2, x1e218ceaee1bb583 + x23e85093ba3a7d1d * 2, x08db3aeabb253cb1 + 2, x1e218ceaee1bb583);
			pen.Dispose();
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000221 RID: 545 RVA: 0x0000A130 File Offset: 0x00009130
		protected internal IPopupMenuHost Host
		{
			get
			{
				return this.x64f259306803411c;
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000A138 File Offset: 0x00009138
		private void xc15607e71371da30(Rectangle x172328fce87eba3a, Rectangle xd1d5eece512e296a, out Point xb9c2cfae130d9256, out Size x0ceec69a97f73617)
		{
			if (!this.x64f259306803411c.RightToLeft)
			{
				xb9c2cfae130d9256 = new Point(x172328fce87eba3a.Right, x172328fce87eba3a.Y);
				goto IL_1F4;
			}
			IL_1C0:
			xb9c2cfae130d9256 = new Point(x172328fce87eba3a.X, x172328fce87eba3a.Y);
			IL_1F4:
			Size x95f43364065e63e = this.x95f43364065e63e8;
			int num;
			int num2;
			do
			{
				x0ceec69a97f73617 = x95f43364065e63e;
				num = x172328fce87eba3a.Left - xd1d5eece512e296a.Left;
				num2 = xd1d5eece512e296a.Right - x172328fce87eba3a.Right;
				this.x030d4163f566f83d = x172328fce87eba3a.Height;
				if ((this.x64f259306803411c.RightToLeft && (num >= x95f43364065e63e.Width || num > num2)) || (!this.x64f259306803411c.RightToLeft && num2 < x95f43364065e63e.Width && num > num2))
				{
					xb9c2cfae130d9256 = new Point(x172328fce87eba3a.X - x95f43364065e63e.Width, x172328fce87eba3a.Y);
					if (xb9c2cfae130d9256.X < xd1d5eece512e296a.X)
					{
						x0ceec69a97f73617.Width -= xd1d5eece512e296a.X - xb9c2cfae130d9256.X;
						xb9c2cfae130d9256.X = xd1d5eece512e296a.X;
					}
					((TopLevelMenuItemBase)this.x7bf8c4d03998048a).x9cc73f6a80ed2e5b(MenuProjection.Left);
				}
				else
				{
					xb9c2cfae130d9256 = new Point(x172328fce87eba3a.Right, x172328fce87eba3a.Y);
					if (xb9c2cfae130d9256.X + x0ceec69a97f73617.Width > xd1d5eece512e296a.Right)
					{
						x0ceec69a97f73617.Width = xd1d5eece512e296a.Right - xb9c2cfae130d9256.X;
					}
					((TopLevelMenuItemBase)this.x7bf8c4d03998048a).x9cc73f6a80ed2e5b(MenuProjection.Right);
				}
				if (x0ceec69a97f73617.Height > xd1d5eece512e296a.Height)
				{
					x0ceec69a97f73617.Height = xd1d5eece512e296a.Height;
				}
				if (xb9c2cfae130d9256.Y + x0ceec69a97f73617.Height <= xd1d5eece512e296a.Bottom)
				{
					return;
				}
				this.x4c9b7a18395fc053 = xb9c2cfae130d9256.Y - (xd1d5eece512e296a.Bottom - x0ceec69a97f73617.Height);
			}
			while ((uint)num > 4294967295U);
			xb9c2cfae130d9256.Y = xd1d5eece512e296a.Bottom - x0ceec69a97f73617.Height;
			bool flag = (uint)num2 - (uint)num2 < 0U;
			if (flag)
			{
				goto IL_1C0;
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000A374 File Offset: 0x00009374
		private void x82887ccffb3b9ee9(Rectangle x172328fce87eba3a, Rectangle xd1d5eece512e296a, out Point xb9c2cfae130d9256, out Size x0ceec69a97f73617)
		{
			if (this.x64f259306803411c.RightToLeft || this.x64f259306803411c.RightAlignMenus)
			{
				xb9c2cfae130d9256 = new Point(x172328fce87eba3a.Right + 1, x172328fce87eba3a.Bottom);
			}
			else
			{
				xb9c2cfae130d9256 = new Point(x172328fce87eba3a.X, x172328fce87eba3a.Bottom);
			}
			x0ceec69a97f73617 = this.x95f43364065e63e8;
			int num = xd1d5eece512e296a.Bottom - xb9c2cfae130d9256.Y;
			int num2 = xb9c2cfae130d9256.Y - x172328fce87eba3a.Height - xd1d5eece512e296a.Y;
			this.x030d4163f566f83d = x172328fce87eba3a.Width;
			if (num >= x0ceec69a97f73617.Height)
			{
				this.x7bf8c4d03998048a.x9cc73f6a80ed2e5b(MenuProjection.Bottom);
			}
			else if (num2 > num)
			{
				xb9c2cfae130d9256.Y -= x172328fce87eba3a.Height;
				if (!false && x0ceec69a97f73617.Height > num2)
				{
					x0ceec69a97f73617.Height = num2;
				}
				xb9c2cfae130d9256.Y -= x0ceec69a97f73617.Height;
				if (this.xd3b329aadd8fdeb3)
				{
					xb9c2cfae130d9256.Y++;
				}
				this.x7bf8c4d03998048a.x9cc73f6a80ed2e5b(MenuProjection.Top);
			}
			else
			{
				if (x0ceec69a97f73617.Height > num)
				{
					x0ceec69a97f73617.Height = num;
				}
				this.x7bf8c4d03998048a.x9cc73f6a80ed2e5b(MenuProjection.Bottom);
			}
			if (x0ceec69a97f73617.Width > xd1d5eece512e296a.Width)
			{
				x0ceec69a97f73617.Width = xd1d5eece512e296a.Width;
			}
			if (this.x64f259306803411c.RightToLeft || this.x64f259306803411c.RightAlignMenus)
			{
				xb9c2cfae130d9256.X -= x0ceec69a97f73617.Width;
				if (xb9c2cfae130d9256.X < xd1d5eece512e296a.Left)
				{
					this.x4c9b7a18395fc053 = xd1d5eece512e296a.Left - xb9c2cfae130d9256.X;
					xb9c2cfae130d9256.X = xd1d5eece512e296a.Left;
					return;
				}
			}
			else if (xb9c2cfae130d9256.X + x0ceec69a97f73617.Width > xd1d5eece512e296a.Right)
			{
				this.x4c9b7a18395fc053 = xb9c2cfae130d9256.X - (xd1d5eece512e296a.Right - x0ceec69a97f73617.Width);
				xb9c2cfae130d9256.X = xd1d5eece512e296a.Right - x0ceec69a97f73617.Width;
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000A594 File Offset: 0x00009594
		private void x76c67208bad1c581(Rectangle x172328fce87eba3a, Rectangle xd1d5eece512e296a, out Point xb9c2cfae130d9256, out Size x0ceec69a97f73617)
		{
			if (this.x64f259306803411c.RightToLeft || this.x64f259306803411c.RightAlignMenus)
			{
				xb9c2cfae130d9256 = new Point(x172328fce87eba3a.X, x172328fce87eba3a.Y);
			}
			else
			{
				xb9c2cfae130d9256 = new Point(x172328fce87eba3a.Right, x172328fce87eba3a.Y);
				if (15 == 0)
				{
					return;
				}
			}
			x0ceec69a97f73617 = this.x95f43364065e63e8;
			if (xd1d5eece512e296a.Bottom - xb9c2cfae130d9256.Y < x0ceec69a97f73617.Height)
			{
				xb9c2cfae130d9256.Y = xd1d5eece512e296a.Bottom - x0ceec69a97f73617.Height;
				if (xb9c2cfae130d9256.Y < xd1d5eece512e296a.Y)
				{
					xb9c2cfae130d9256.Y = xd1d5eece512e296a.Y;
					x0ceec69a97f73617.Height = xd1d5eece512e296a.Height;
				}
			}
			if (x0ceec69a97f73617.Width > xd1d5eece512e296a.Width)
			{
				x0ceec69a97f73617.Width = xd1d5eece512e296a.Width;
			}
			if (this.x64f259306803411c.RightToLeft || this.x64f259306803411c.RightAlignMenus)
			{
				xb9c2cfae130d9256.X -= x0ceec69a97f73617.Width;
				if (3 != 0)
				{
					this.x7bf8c4d03998048a.x9cc73f6a80ed2e5b(MenuProjection.Left);
					if (xb9c2cfae130d9256.X < xd1d5eece512e296a.Left)
					{
						xb9c2cfae130d9256.X = xd1d5eece512e296a.Left;
						this.x7bf8c4d03998048a.x9cc73f6a80ed2e5b(MenuProjection.Right);
						return;
					}
					return;
				}
			}
			this.x7bf8c4d03998048a.x9cc73f6a80ed2e5b(MenuProjection.Right);
			if (xb9c2cfae130d9256.X + x0ceec69a97f73617.Width > xd1d5eece512e296a.Right)
			{
				xb9c2cfae130d9256.X = x172328fce87eba3a.X - x0ceec69a97f73617.Width;
				this.x7bf8c4d03998048a.x9cc73f6a80ed2e5b(MenuProjection.Left);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000225 RID: 549 RVA: 0x0000A738 File Offset: 0x00009738
		internal Rectangle x561b187641dfe790
		{
			get
			{
				if (this.xfbb4579b829aef10)
				{
					return this.x10d0328f698a7faa.ModifyParentBounds(new Rectangle(this.x2254fff4234f283d, Size.Empty));
				}
				if (this.x7bf8c4d03998048a.ToolBar != null)
				{
					return this.x10d0328f698a7faa.ModifyParentBounds(new Rectangle(this.x7bf8c4d03998048a.ToolBar.PointToScreen(this.x7bf8c4d03998048a.ButtonBounds.Location), this.x7bf8c4d03998048a.ButtonBounds.Size));
				}
				if (this.x7bf8c4d03998048a.Parent != null && this.x7bf8c4d03998048a.Parent.Popup != null)
				{
					return this.x10d0328f698a7faa.ModifyParentBounds(new Rectangle(this.x7bf8c4d03998048a.Parent.Popup.PointToScreen(this.x7bf8c4d03998048a.ButtonBounds.Location), this.x7bf8c4d03998048a.ButtonBounds.Size));
				}
				return Rectangle.Empty;
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000A830 File Offset: 0x00009830
		internal void x9f953666761d03df(bool xf13a675fdb7b229b, Point x2254fff4234f283d)
		{
			this.x2254fff4234f283d = x2254fff4234f283d;
			this.x9f953666761d03df(xf13a675fdb7b229b);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000A840 File Offset: 0x00009840
		internal void x9f953666761d03df(bool xf13a675fdb7b229b)
		{
			this.xf13a675fdb7b229b = xf13a675fdb7b229b;
			Point location;
			Size size;
			if (xf13a675fdb7b229b)
			{
				this.x76c67208bad1c581(this.x561b187641dfe790, this.x10d0328f698a7faa.ConstraintArea, out location, out size);
			}
			else if (this.x64f259306803411c.Flow == ToolBarLayout.Vertical)
			{
				this.xc15607e71371da30(this.x561b187641dfe790, this.x10d0328f698a7faa.ConstraintArea, out location, out size);
			}
			else
			{
				this.x82887ccffb3b9ee9(this.x561b187641dfe790, this.x10d0328f698a7faa.ConstraintArea, out location, out size);
			}
			base.Bounds = new Rectangle(location, size);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000A8C8 File Offset: 0x000098C8
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (this.xdc850c3fee9712fc && (this.xd2e19ddc2c3e7aa1.Contains(e.X, e.Y) || this.xe41e3e6eb8fced84.Contains(e.X, e.Y)))
			{
				this.Cursor = Cursors.Default;
				this.x5d56ae798b9cdf38.Enabled = true;
				return;
			}
			base.OnMouseMove(e);
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000229 RID: 553 RVA: 0x0000A930 File Offset: 0x00009930
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (this.xa1808e2c9a448af8)
				{
					createParams.Style |= 1073741824;
				}
				else
				{
					createParams.Style |= int.MinValue;
					createParams.ExStyle |= 8;
				}
				return createParams;
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000A984 File Offset: 0x00009984
		private void xcaf19fd9570f4eb4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			bool flag = this.xd2e19ddc2c3e7aa1.Contains(base.PointToClient(Cursor.Position));
			bool flag2 = this.xe41e3e6eb8fced84.Contains(base.PointToClient(Cursor.Position));
			if (flag || flag2)
			{
				int num = this.x200b7f5a9d983ba4;
				if (flag)
				{
					this.x200b7f5a9d983ba4 -= 3;
				}
				else
				{
					this.x200b7f5a9d983ba4 += 3;
				}
				if (this.x200b7f5a9d983ba4 < 0)
				{
					this.x200b7f5a9d983ba4 = 0;
				}
				if (this.x200b7f5a9d983ba4 > this.x648389b128a52ae0)
				{
					this.x200b7f5a9d983ba4 = this.x648389b128a52ae0;
				}
				if (this.x200b7f5a9d983ba4 != num)
				{
					this.xfb14a9f3dcd92a45();
					return;
				}
			}
			else
			{
				this.x5d56ae798b9cdf38.Enabled = false;
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000AA34 File Offset: 0x00009A34
		private string x7770570abeef94ae(Point xb9c2cfae130d9256)
		{
			if (this.xa1808e2c9a448af8)
			{
				return "";
			}
			MenuButtonItem itemAt = this.GetItemAt(xb9c2cfae130d9256);
			if (itemAt != null)
			{
				return itemAt.ToolTipText;
			}
			return "";
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000AA68 File Offset: 0x00009A68
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 33)
			{
				m.Result = new IntPtr(3);
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x040000AD RID: 173
		private const int x40708a05e5b116d8 = 18;

		// Token: 0x040000AE RID: 174
		private const int x0f5244b9714ac63b = 10;

		// Token: 0x040000AF RID: 175
		private MenuItemBase x7bf8c4d03998048a;

		// Token: 0x040000B0 RID: 176
		private IPopupMenuHost x64f259306803411c;

		// Token: 0x040000B1 RID: 177
		private bool xf13a675fdb7b229b;

		// Token: 0x040000B2 RID: 178
		private bool xfbb4579b829aef10;

		// Token: 0x040000B3 RID: 179
		private Point x2254fff4234f283d;

		// Token: 0x040000B4 RID: 180
		internal bool x833319a7a503e226;

		// Token: 0x040000B5 RID: 181
		private int x4c9b7a18395fc053;

		// Token: 0x040000B6 RID: 182
		private int x030d4163f566f83d;

		// Token: 0x040000B7 RID: 183
		private int xd1a4ac20d7e3fc13;

		// Token: 0x040000B8 RID: 184
		private bool xc0e29aedef0854d2;

		// Token: 0x040000BC RID: 188
		private bool xa1808e2c9a448af8;

		// Token: 0x040000BD RID: 189
		private bool xdc850c3fee9712fc;

		// Token: 0x040000BE RID: 190
		private int x648389b128a52ae0;

		// Token: 0x040000BF RID: 191
		private int x200b7f5a9d983ba4;

		// Token: 0x040000C0 RID: 192
		private Rectangle xd2e19ddc2c3e7aa1;

		// Token: 0x040000C1 RID: 193
		private Rectangle xe41e3e6eb8fced84;
	}
}

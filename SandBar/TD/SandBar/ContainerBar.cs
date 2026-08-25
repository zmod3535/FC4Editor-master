using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000018 RID: 24
	[DisplayName("Task Pane")]
	[Designer("TD.SandBar.Design.ContainerBarDesigner, SandBar.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
	public class ContainerBar : ToolBar
	{
		// Token: 0x0600018E RID: 398 RVA: 0x000075DC File Offset: 0x000065DC
		public ContainerBar()
		{
			this.Stretch = true;
			this.Text = "Task Pane";
			this.Dock = DockStyle.Right;
			this.Overflow = ToolBarOverflow.Wrap;
			this.x26e80f23e22a05ae = new x4c834b893c51f017(ToolBarGlyphType.Close);
			this.x26e80f23e22a05ae.SetToolbar(this);
			this.x26e80f23e22a05ae.ToolTipText = "Close";
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000764C File Offset: 0x0000664C
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.TitleBarMenu != null)
			{
				this.TitleBarMenu.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000766C File Offset: 0x0000666C
		internal override void xa2414c47d888068e()
		{
			base.xa2414c47d888068e();
			if (base.ContainsFocus)
			{
				base.Invalidate(this.xb48529af1739dd06);
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00007688 File Offset: 0x00006688
		internal override void x19e788b09b195d4f()
		{
			base.x19e788b09b195d4f();
			if (this.x7b9cf4b15fbbd3e4)
			{
				base.Invalidate(this.xb48529af1739dd06);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000192 RID: 402 RVA: 0x000076A4 File Offset: 0x000066A4
		public override Type[] DesignableTypes
		{
			get
			{
				return new Type[]
				{
					typeof(ButtonItem),
					typeof(LabelItem),
					typeof(DropDownMenuItem)
				};
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000193 RID: 403 RVA: 0x000076E0 File Offset: 0x000066E0
		// (set) Token: 0x06000194 RID: 404 RVA: 0x000076E8 File Offset: 0x000066E8
		[Category("Behavior")]
		[Description("The active ClientPanel within the ContainerBar.")]
		[DefaultValue(typeof(ContainerBarClientPanel), null)]
		public ContainerBarClientPanel SelectedClientPanel
		{
			get
			{
				return this.xf92b822c63d624be;
			}
			set
			{
				if (value != null && value.Parent != this)
				{
					value.Parent = this;
				}
				this.xf92b822c63d624be = value;
				base.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000195 RID: 405 RVA: 0x0000770C File Offset: 0x0000670C
		protected override Size DefaultSize
		{
			get
			{
				return new Size(200, 300);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000196 RID: 406 RVA: 0x00007720 File Offset: 0x00006720
		// (set) Token: 0x06000197 RID: 407 RVA: 0x00007724 File Offset: 0x00006724
		[Browsable(false)]
		[Obsolete("ContainerBars can now support more than one client panel, use the SelectedClientPanel property instead.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ContainerBarClientPanel ClientPanel
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000198 RID: 408 RVA: 0x00007728 File Offset: 0x00006728
		// (set) Token: 0x06000199 RID: 409 RVA: 0x00007730 File Offset: 0x00006730
		[Browsable(false)]
		[Category("Behavior")]
		[DefaultValue(typeof(TopLevelMenuItemBase), null)]
		[Description("Indicates the menu that will be displayed when the user clicks the titlebar.")]
		public ContainerBarTitleBarMenu TitleBarMenu
		{
			get
			{
				return this.xa7b27722818239d5;
			}
			set
			{
				if (this.xa7b27722818239d5 != null)
				{
					this.xa7b27722818239d5.SetToolbar(null);
				}
				if (value != null && value.ToolBar != null)
				{
					throw new InvalidOperationException("The specified item already belongs to a toolbar.");
				}
				this.xa7b27722818239d5 = value;
				if (this.xa7b27722818239d5 != null)
				{
					this.xa7b27722818239d5.SetToolbar(this);
				}
				base.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00007788 File Offset: 0x00006788
		protected override void OnLayout(LayoutEventArgs levent)
		{
			base.OnLayout(levent);
			foreach (object obj in base.Controls)
			{
				Control control = (Control)obj;
				if (control is ContainerBarClientPanel)
				{
					control.Visible = (control == this.SelectedClientPanel);
					control.Bounds = this.x21ed2ecc088ef4e4;
				}
			}
		}

		// Token: 0x0600019B RID: 411 RVA: 0x00007810 File Offset: 0x00006810
		protected override void OnControlAdded(ControlEventArgs e)
		{
			base.OnControlAdded(e);
			if (this.SelectedClientPanel == null && e.Control is ContainerBarClientPanel)
			{
				this.SelectedClientPanel = (ContainerBarClientPanel)e.Control;
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00007840 File Offset: 0x00006840
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			if (this.SelectedClientPanel == e.Control)
			{
				if (base.Controls.Count != 0 && base.Controls[0] is ContainerBarClientPanel)
				{
					this.SelectedClientPanel = (ContainerBarClientPanel)base.Controls[0];
					return;
				}
				this.SelectedClientPanel = null;
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x000078A4 File Offset: 0x000068A4
		internal override Size x3385488b2bb8e38c(int x8a5438a210b3746e, out bool x8e1d21c91e03470f)
		{
			x8e1d21c91e03470f = false;
			if (x8a5438a210b3746e > 32767)
			{
				x8a5438a210b3746e = this.x5cf198ac0488ae74.Width;
			}
			return new Size(Math.Max(x8a5438a210b3746e, this.x5cf198ac0488ae74.Width), this.x5cf198ac0488ae74.Height);
		}

		// Token: 0x0600019E RID: 414 RVA: 0x000078E0 File Offset: 0x000068E0
		private Size xc28a4993a4f3f2fc(IToolBarRenderer x38870620fd380a6b, bool xa092001467a0ab7b)
		{
			Size result;
			using (Graphics graphics = base.CreateGraphics())
			{
				bool flag;
				result = xdf1e331801161ebc.xdd6d4e0a33c8a7db(this, graphics, x38870620fd380a6b, xa092001467a0ab7b, base.Width - 4, out flag);
			}
			return result;
		}

		// Token: 0x0600019F RID: 415 RVA: 0x00007934 File Offset: 0x00006934
		internal override void x1a2b7835c4f6410b(IToolBarRenderer x38870620fd380a6b, bool xa092001467a0ab7b)
		{
			if (base.x73be6e650087b30e)
			{
				return;
			}
			base.x73be6e650087b30e = true;
			bool flag = this.RightToLeft == RightToLeft.Yes && this.AllowRightToLeft;
			Size size = (base.Items.Count == 0) ? Size.Empty : this.xc28a4993a4f3f2fc(x38870620fd380a6b, false);
			Size toolbarSize = size;
			if (size.Height != 0 && size.Width != 0)
			{
				toolbarSize.Width += 8;
			}
			else
			{
				toolbarSize = Size.Empty;
			}
			Rectangle rectangle;
			Rectangle x446b42c2caf105ce;
			x38870620fd380a6b.LayoutContainerBar(base.ClientRectangle, toolbarSize, out this.xb48529af1739dd06, out rectangle, out this.x21ed2ecc088ef4e4, out x446b42c2caf105ce);
			int num;
			bool flag2 = ((uint)num & 0U) == 0U;
			Size toolWindowCaptionButtonSize;
			if (flag2)
			{
				this.x4bc955bd8cfefd39 = rectangle;
				this.x446b42c2caf105ce = x446b42c2caf105ce;
				Rectangle xda73fcb97c77d = rectangle;
				xda73fcb97c77d.Offset(4, 0);
				using (Graphics graphics = base.CreateGraphics())
				{
					xdf1e331801161ebc.xf01c0312483a47c8(this, graphics, xda73fcb97c77d, x38870620fd380a6b, false, flag, false);
				}
				toolWindowCaptionButtonSize = SystemInformation.ToolWindowCaptionButtonSize;
			}
			num = toolWindowCaptionButtonSize.Width - 1;
			int num2 = this.xb48529af1739dd06.Right - num - 3;
			int num3 = this.xb48529af1739dd06.Top + this.xb48529af1739dd06.Height / 2;
			if (false)
			{
				goto IL_2DE;
			}
			if (this.Closable)
			{
				this.x26e80f23e22a05ae.ApplyLayout(new Rectangle(num2, num3 - num / 2, num, num), null, false, false);
				num2 -= num + 1;
				goto IL_119;
			}
			this.x26e80f23e22a05ae.ApplyLayout(Rectangle.Empty, null, false, false);
			goto IL_119;
			IL_2B:
			if (this.TitleBarMenu != null)
			{
				Rectangle buttonBounds = this.x949955e846842e7e;
				buttonBounds.Y = base.ActionsButton.ButtonBounds.Y;
				buttonBounds.Height = base.ActionsButton.ButtonBounds.Height;
				buttonBounds.X--;
				buttonBounds.Width++;
				if ((xa092001467a0ab7b ? 1U : 0U) + (flag ? 1U : 0U) < 0U)
				{
					goto IL_119;
				}
				this.xa7b27722818239d5.ApplyLayout(buttonBounds, null, false, false);
			}
			this.OnLayout(null);
			base.Invalidate();
			base.x73be6e650087b30e = false;
			return;
			IL_119:
			base.ActionsButton.ApplyLayout(new Rectangle(num2, num3 - num / 2, num, num), null, false, false);
			base.ActionsButton.Visible = (this.DrawActionsButton && this.TitleBarMenu == null);
			if (this.DrawActionsButton && this.TitleBarMenu == null)
			{
				num2 -= num + 1;
			}
			this.x949955e846842e7e = this.xb48529af1739dd06;
			this.x949955e846842e7e.Width = num2 - this.x949955e846842e7e.X + num;
			if (x446b42c2caf105ce.Width == 0)
			{
				goto IL_2B;
			}
			this.x949955e846842e7e.X = this.x949955e846842e7e.X + (x446b42c2caf105ce.Width + 2);
			IL_2DE:
			this.x949955e846842e7e.Width = this.x949955e846842e7e.Width - (x446b42c2caf105ce.Width + 2);
			goto IL_2B;
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00007C40 File Offset: 0x00006C40
		protected override void OnItemPush(ToolbarItemBase item, Point position)
		{
			if (item == this.TitleBarMenu)
			{
				this.TitleBarMenu.Show();
				return;
			}
			base.OnItemPush(item, position);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00007C60 File Offset: 0x00006C60
		protected override void OnItemRelease(ToolbarItemBase item, Point position)
		{
			if (item == this.x26e80f23e22a05ae)
			{
				this.OnCloseButtonPressed();
				return;
			}
			base.OnItemRelease(item, position);
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00007C7C File Offset: 0x00006C7C
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			base.WorkingRenderer.StartToolBarRender(this, false, this.RightToLeft == RightToLeft.Yes);
			string text = (this.SelectedClientPanel != null && this.SelectedClientPanel.Text.Length != 0) ? this.SelectedClientPanel.Text : this.Text;
			base.WorkingRenderer.DrawContainerBarText(text, e.Graphics, this.Font, this.x949955e846842e7e);
			if (this.DrawActionsButton && this.TitleBarMenu == null)
			{
				DrawItemState drawItemState = DrawItemState.Default;
				if (base.ActionsButton == base.xe4f42f0e511fcd41)
				{
					drawItemState |= DrawItemState.HotLight;
					if (this.xfa5e20eb950b9ee1 || base.ActionsButton.x785370fd71860ecc)
					{
						drawItemState |= DrawItemState.Selected;
					}
				}
				base.WorkingRenderer.DrawSystemButton(e.Graphics, base.ActionsButton.ButtonBounds, ToolBarGlyphType.Actions, drawItemState, false);
			}
			if (this.TitleBarMenu != null)
			{
				base.WorkingRenderer.DrawSystemButton(e.Graphics, base.ActionsButton.ButtonBounds, ToolBarGlyphType.Actions, DrawItemState.Default, false);
			}
			base.WorkingRenderer.FinishToolBarRender();
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00007D84 File Offset: 0x00006D84
		internal override ToolbarItemBase[] x0366497b06ec1dfe
		{
			get
			{
				if (this.TitleBarMenu != null)
				{
					return new ToolbarItemBase[]
					{
						this.x26e80f23e22a05ae,
						this.xa7b27722818239d5
					};
				}
				if (this.DrawActionsButton)
				{
					return new ToolbarItemBase[]
					{
						base.ActionsButton,
						this.x26e80f23e22a05ae
					};
				}
				return new ToolbarItemBase[]
				{
					this.x26e80f23e22a05ae
				};
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x00007DE8 File Offset: 0x00006DE8
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x00007DEC File Offset: 0x00006DEC
		public override ToolBarLayout Flow
		{
			get
			{
				return ToolBarLayout.Horizontal;
			}
			set
			{
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00007DF0 File Offset: 0x00006DF0
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (base.Resizable && base.Situation != ToolBarSituation.Floating && this.xca8fa35f321fb057().Contains(e.X, e.Y))
			{
				this.x595723733f38c9c1 = new xb5e3ab8b746d6d67(this, new Point(e.X, e.Y));
				return;
			}
			base.OnMouseDown(e);
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00007E50 File Offset: 0x00006E50
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (this.x595723733f38c9c1 != null)
			{
				this.x595723733f38c9c1.x2c5d1da1234c3a6a(new Point(e.X, e.Y));
				return;
			}
			if (!base.Resizable || base.Situation == ToolBarSituation.Floating || !this.xca8fa35f321fb057().Contains(e.X, e.Y))
			{
				base.OnMouseMove(e);
				return;
			}
			if (base.Parent.Dock == DockStyle.Left || base.Parent.Dock == DockStyle.Right)
			{
				Cursor.Current = Cursors.SizeWE;
				return;
			}
			Cursor.Current = Cursors.SizeNS;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00007EE8 File Offset: 0x00006EE8
		private Rectangle xca8fa35f321fb057()
		{
			if (base.Situation != ToolBarSituation.Contained)
			{
				return Rectangle.Empty;
			}
			switch (base.Parent.Dock)
			{
			case DockStyle.Top:
				return new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Bottom - 2, base.ClientRectangle.Width, 2);
			case DockStyle.Bottom:
				return new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y, base.ClientRectangle.Width, 2);
			case DockStyle.Left:
				return new Rectangle(base.ClientRectangle.Right - 2, base.ClientRectangle.Y, 2, base.ClientRectangle.Height);
			case DockStyle.Right:
				return new Rectangle(base.ClientRectangle.X, base.ClientRectangle.Y, 2, base.ClientRectangle.Height);
			default:
				return Rectangle.Empty;
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00008004 File Offset: 0x00007004
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			bool containsFocus = base.ContainsFocus;
			base.WorkingRenderer.DrawContainerBarBackground(this, pevent.Graphics, base.ClientRectangle, this.x21ed2ecc088ef4e4);
			base.WorkingRenderer.DrawContainerBarTitleBarBackground(pevent.Graphics, this.xb48529af1739dd06, containsFocus);
			Rectangle bounds = this.x4bc955bd8cfefd39;
			if (bounds.Height > 0 && bounds.Width > 0)
			{
				base.WorkingRenderer.DrawContainerBarToolBarBackground(pevent.Graphics, bounds);
			}
			this.x7b9cf4b15fbbd3e4 = containsFocus;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00008084 File Offset: 0x00007084
		protected internal override void OnRendererChanged()
		{
			base.OnRendererChanged();
			base.xcf42ad4a4f3fcbf6();
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00008094 File Offset: 0x00007094
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			base.Invalidate(this.xb48529af1739dd06);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x000080AC File Offset: 0x000070AC
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			base.Invalidate(this.xb48529af1739dd06);
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001AD RID: 429 RVA: 0x000080C4 File Offset: 0x000070C4
		// (set) Token: 0x060001AE RID: 430 RVA: 0x000080CC File Offset: 0x000070CC
		public override bool Closable
		{
			get
			{
				return base.Closable;
			}
			set
			{
				base.Closable = value;
				base.xcf42ad4a4f3fcbf6();
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001AF RID: 431 RVA: 0x000080DC File Offset: 0x000070DC
		// (set) Token: 0x060001B0 RID: 432 RVA: 0x000080E4 File Offset: 0x000070E4
		[DefaultValue(typeof(ToolBarOverflow), "Wrap")]
		public override ToolBarOverflow Overflow
		{
			get
			{
				return base.Overflow;
			}
			set
			{
				base.Overflow = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001B1 RID: 433 RVA: 0x000080F0 File Offset: 0x000070F0
		// (set) Token: 0x060001B2 RID: 434 RVA: 0x000080F8 File Offset: 0x000070F8
		[DefaultValue(typeof(DockStyle), "Right")]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001B3 RID: 435 RVA: 0x00008104 File Offset: 0x00007104
		// (set) Token: 0x060001B4 RID: 436 RVA: 0x0000810C File Offset: 0x0000710C
		[DefaultValue("Task Pane")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				base.Invalidate(this.xb48529af1739dd06);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001B5 RID: 437 RVA: 0x00008124 File Offset: 0x00007124
		// (set) Token: 0x060001B6 RID: 438 RVA: 0x0000812C File Offset: 0x0000712C
		[DefaultValue(true)]
		public override bool Stretch
		{
			get
			{
				return base.Stretch;
			}
			set
			{
				base.Stretch = value;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001B7 RID: 439 RVA: 0x00008138 File Offset: 0x00007138
		// (set) Token: 0x060001B8 RID: 440 RVA: 0x00008140 File Offset: 0x00007140
		[DefaultValue(typeof(Size), "200, 284")]
		[Category("Layout")]
		[Description("Indicates the minimum desired size of this container.")]
		public new Size MinimumSize
		{
			get
			{
				return this.x5cf198ac0488ae74;
			}
			set
			{
				this.x5cf198ac0488ae74 = value;
				if (base.Parent is ToolBarContainer)
				{
					((ToolBarContainer)base.Parent).xeea2f63c63de806c();
				}
			}
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x00008168 File Offset: 0x00007168
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 533 && this.x595723733f38c9c1 != null)
			{
				this.x595723733f38c9c1 = null;
			}
			base.WndProc(ref m);
		}

		// Token: 0x0400008F RID: 143
		internal const int x6a79ccebfbd21bec = 2;

		// Token: 0x04000090 RID: 144
		private Size x5cf198ac0488ae74 = new Size(200, 284);

		// Token: 0x04000091 RID: 145
		private Rectangle xb48529af1739dd06;

		// Token: 0x04000092 RID: 146
		private Rectangle x21ed2ecc088ef4e4;

		// Token: 0x04000093 RID: 147
		private Rectangle x949955e846842e7e;

		// Token: 0x04000094 RID: 148
		private ContainerBarClientPanel xf92b822c63d624be;

		// Token: 0x04000095 RID: 149
		private Rectangle x4bc955bd8cfefd39;

		// Token: 0x04000096 RID: 150
		private ButtonItem x26e80f23e22a05ae;

		// Token: 0x04000097 RID: 151
		private ContainerBarTitleBarMenu xa7b27722818239d5;

		// Token: 0x04000098 RID: 152
		private xb5e3ab8b746d6d67 x595723733f38c9c1;

		// Token: 0x04000099 RID: 153
		private bool x7b9cf4b15fbbd3e4;
	}
}

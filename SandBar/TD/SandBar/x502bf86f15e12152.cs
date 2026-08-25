using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200003E RID: 62
	internal partial class x502bf86f15e12152 : x5b55bb129f506dac
	{
		// Token: 0x06000362 RID: 866 RVA: 0x00011074 File Offset: 0x00010074
		public x502bf86f15e12152(ToolBar toolbar, SandBarManager manager, RightToLeft rtl)
		{
			this.x169279a87b6b72b2 = toolbar;
			this._x91f347c6e97f1846 = manager;
			this.x26e80f23e22a05ae = new ButtonItem();
			this.xab98d56e18146fb2 = new ButtonItem();
			this.RightToLeft = rtl;
			base.ShowInTaskbar = false;
			base.FormBorderStyle = FormBorderStyle.None;
			base.StartPosition = FormStartPosition.Manual;
			this.xe9433ca9139ae2b2();
			base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			base.SetStyle(ControlStyles.DoubleBuffer, true);
			base.SetStyle(ControlStyles.ResizeRedraw, true);
			base.Controls.Add(toolbar);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00011104 File Offset: 0x00010104
		internal void xe9433ca9139ae2b2()
		{
			if (this.x169279a87b6b72b2.MinimumFloatingSize == Size.Empty)
			{
				this.MinimumSize = Size.Empty;
			}
			else
			{
				this.MinimumSize = this.x84093c435ab64702(this.x169279a87b6b72b2.MinimumFloatingSize);
			}
			if (this.x169279a87b6b72b2.MaximumFloatingSize == Size.Empty)
			{
				this.MaximumSize = Size.Empty;
				return;
			}
			this.MaximumSize = this.x84093c435ab64702(this.x169279a87b6b72b2.MaximumFloatingSize);
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00011188 File Offset: 0x00010188
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00011190 File Offset: 0x00010190
		public bool x36c9bbcb771daf63
		{
			get
			{
				return this._x03e06b5dc28b3d6b;
			}
			set
			{
				this._x03e06b5dc28b3d6b = value;
			}
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0001119C File Offset: 0x0001019C
		public void xbf87530143e7a46c()
		{
			if (base.Visible)
			{
				this._x03e06b5dc28b3d6b = true;
				base.Hide();
			}
		}

		// Token: 0x06000367 RID: 871 RVA: 0x000111B4 File Offset: 0x000101B4
		public void x4fc163dd620d4398()
		{
			if (this._x03e06b5dc28b3d6b)
			{
				this.x2c6f5ac62ee048e5();
				this._x03e06b5dc28b3d6b = false;
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x000111CC File Offset: 0x000101CC
		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			if (this.x169279a87b6b72b2 != null)
			{
				this.x169279a87b6b72b2.xa2414c47d888068e();
			}
		}

		// Token: 0x06000369 RID: 873 RVA: 0x000111E8 File Offset: 0x000101E8
		protected override void OnDeactivate(EventArgs e)
		{
			base.OnDeactivate(e);
			if (this.x169279a87b6b72b2 != null)
			{
				this.x169279a87b6b72b2.x19e788b09b195d4f();
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00011204 File Offset: 0x00010204
		public SandBarManager x460ab163f44a604d
		{
			get
			{
				return this._x91f347c6e97f1846;
			}
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0001120C File Offset: 0x0001020C
		public void x717b578f97e88385(Size xafc895301c3c68ee)
		{
			Size size = this.x84093c435ab64702(xafc895301c3c68ee);
			base.Size = size;
			x443cc432acaadb1d.SetWindowPos(base.Handle, 0, base.Left, base.Top, size.Width, size.Height, 16);
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00011254 File Offset: 0x00010254
		private Size x84093c435ab64702(Size xafc895301c3c68ee)
		{
			Size result = xafc895301c3c68ee;
			result.Width += SystemInformation.FixedFrameBorderSize.Width * 2;
			result.Height += SystemInformation.FixedFrameBorderSize.Height * 2;
			if (!(this.x169279a87b6b72b2 is ContainerBar))
			{
				result.Height += SystemInformation.ToolWindowCaptionHeight;
			}
			return result;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x000112C0 File Offset: 0x000102C0
		private Rectangle x6627773654799b76(Rectangle x6a6debba49cab515)
		{
			Rectangle result = x6a6debba49cab515;
			result.Inflate(-SystemInformation.FixedFrameBorderSize.Width, -SystemInformation.FixedFrameBorderSize.Height);
			if (!(this.x169279a87b6b72b2 is ContainerBar))
			{
				result.Y += SystemInformation.ToolWindowCaptionButtonSize.Height;
				result.Height -= SystemInformation.ToolWindowCaptionButtonSize.Height;
			}
			return result;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x00011338 File Offset: 0x00010338
		protected override void OnLayout(LayoutEventArgs levent)
		{
			Rectangle bounds = this.x6627773654799b76(base.ClientRectangle);
			this.x169279a87b6b72b2.Bounds = bounds;
			if (this.x169279a87b6b72b2 is ContainerBar)
			{
				((ContainerBar)this.x169279a87b6b72b2).MinimumSize = bounds.Size;
			}
			this.x169279a87b6b72b2.x1a2b7835c4f6410b(this.x169279a87b6b72b2.WorkingRenderer, false);
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0001139C File Offset: 0x0001039C
		public void xcf42ad4a4f3fcbf6()
		{
			int x8a5438a210b3746e = this.x294222ed6113fcbd ? int.MaxValue : this.x169279a87b6b72b2.Width;
			Size size = this.x169279a87b6b72b2.x3385488b2bb8e38c(x8a5438a210b3746e);
			size = this.x84093c435ab64702(size);
			if (size != base.Size)
			{
				base.Size = size;
			}
			else
			{
				base.PerformLayout();
			}
			this.x436f6f3ee14607e0();
			base.Invalidate(true);
		}

		// Token: 0x06000370 RID: 880 RVA: 0x00011404 File Offset: 0x00010404
		private void x436f6f3ee14607e0()
		{
			Rectangle clientRectangle = base.ClientRectangle;
			clientRectangle.Inflate(-SystemInformation.FixedFrameBorderSize.Width, -SystemInformation.FixedFrameBorderSize.Height);
			clientRectangle.Height = SystemInformation.ToolWindowCaptionButtonSize.Height;
			int num = SystemInformation.ToolWindowCaptionButtonSize.Width - 1;
			int num2 = clientRectangle.Right - 2;
			if (this.x169279a87b6b72b2.Closable)
			{
				this.x26e80f23e22a05ae.ApplyLayout(new Rectangle(num2 - num + 1, clientRectangle.Top, num, num), null, false, false);
				num2 -= num + 1;
			}
			else
			{
				this.x26e80f23e22a05ae.ApplyLayout(Rectangle.Empty, null, false, false);
			}
			if (this.x169279a87b6b72b2.DrawActionsButton)
			{
				this.xab98d56e18146fb2.ApplyLayout(new Rectangle(num2 - num + 1, clientRectangle.Top, num, num), null, false, false);
				num2 -= num + 1;
			}
			else
			{
				this.xab98d56e18146fb2.ApplyLayout(Rectangle.Empty, null, false, false);
			}
			clientRectangle.Width -= clientRectangle.Right - num2;
			this.xec187e7c0bfd3340 = clientRectangle;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0001151C File Offset: 0x0001051C
		protected override void OnPaint(PaintEventArgs e)
		{
			this.x460ab163f44a604d.Renderer.StartToolBarRender(this.x169279a87b6b72b2, false, this.x169279a87b6b72b2.RightToLeft == RightToLeft.Yes && this.x169279a87b6b72b2.AllowRightToLeft);
			this.x460ab163f44a604d.Renderer.DrawFloatingFormBackground(e.Graphics, base.ClientRectangle);
			this.x460ab163f44a604d.Renderer.DrawFloatingFormText(this.x169279a87b6b72b2.Text, e.Graphics, this.x169279a87b6b72b2.Font, this.xec187e7c0bfd3340);
			this.x460ab163f44a604d.Renderer.FinishToolBarRender();
			if (this.x169279a87b6b72b2.Closable)
			{
				DrawItemState drawItemState = DrawItemState.Default;
				if (this.x216b0c2912ae7c6a == this.x26e80f23e22a05ae)
				{
					drawItemState |= DrawItemState.HotLight;
					if (this.xfa5e20eb950b9ee1)
					{
						drawItemState |= DrawItemState.Selected;
					}
				}
				this.x460ab163f44a604d.Renderer.DrawSystemButton(e.Graphics, this.x26e80f23e22a05ae.ButtonBounds, ToolBarGlyphType.Close, drawItemState, true);
			}
			if (this.x169279a87b6b72b2.DrawActionsButton)
			{
				DrawItemState drawItemState = DrawItemState.Default;
				if (this.x216b0c2912ae7c6a == this.xab98d56e18146fb2)
				{
					drawItemState |= DrawItemState.HotLight;
					if (this.xfa5e20eb950b9ee1)
					{
						drawItemState |= DrawItemState.Selected;
					}
				}
				this.x460ab163f44a604d.Renderer.DrawSystemButton(e.Graphics, this.xab98d56e18146fb2.ButtonBounds, ToolBarGlyphType.Actions, drawItemState, true);
			}
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00011660 File Offset: 0x00010660
		internal void x1f1ebe887fa99dcd()
		{
			this.x169279a87b6b72b2.x59a14ca9cc50a075.Dispose();
			this.x169279a87b6b72b2.x59a14ca9cc50a075 = null;
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0001168C File Offset: 0x0001068C
		internal void x93dffb29518a0417(MouseEventArgs xfbf34718e704c6bc)
		{
			this.Cursor = Cursors.SizeAll;
			base.Capture = true;
			this.x169279a87b6b72b2.x59a14ca9cc50a075 = new x5c4975da3c2417f1(this.x169279a87b6b72b2, xfbf34718e704c6bc);
		}

		// Token: 0x06000374 RID: 884 RVA: 0x000116B8 File Offset: 0x000106B8
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			this.x1c052ea7408f43d4(new Point(e.X, e.Y));
			if (this.x216b0c2912ae7c6a == this.x26e80f23e22a05ae && this.x169279a87b6b72b2.Closable)
			{
				this.xfa5e20eb950b9ee1 = true;
				this.xf3c64f6d99f327cf(this.x26e80f23e22a05ae);
				return;
			}
			if (this.x216b0c2912ae7c6a == this.xab98d56e18146fb2 && this.x169279a87b6b72b2.DrawActionsButton)
			{
				this.x169279a87b6b72b2.ActionsButton.Show(this, new Point(this.xab98d56e18146fb2.ButtonBounds.X, this.xab98d56e18146fb2.ButtonBounds.Bottom));
				return;
			}
			this.x93dffb29518a0417(e);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00011780 File Offset: 0x00010780
		private void xf3c64f6d99f327cf(ToolbarItemBase x128517d7ded59312)
		{
			Rectangle buttonBounds = x128517d7ded59312.ButtonBounds;
			buttonBounds.Width++;
			buttonBounds.Height++;
			base.Invalidate(buttonBounds);
		}

		// Token: 0x06000376 RID: 886 RVA: 0x000117BC File Offset: 0x000107BC
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (this.x169279a87b6b72b2 == null)
			{
				return;
			}
			if (e.Button == MouseButtons.Right)
			{
				this._x91f347c6e97f1846.ShowContextMenu(this.x169279a87b6b72b2, this, new Point(e.X, e.Y));
				return;
			}
			if (this.x169279a87b6b72b2.Closable && this.xfa5e20eb950b9ee1)
			{
				this.xfa5e20eb950b9ee1 = false;
				this.xf3c64f6d99f327cf(this.x26e80f23e22a05ae);
				if (this.x216b0c2912ae7c6a == this.x26e80f23e22a05ae)
				{
					this.x169279a87b6b72b2.OnCloseButtonPressed();
				}
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0001184C File Offset: 0x0001084C
		private void x1c052ea7408f43d4(Point x13d4cb8d1bd20347)
		{
			ButtonItem buttonItem = null;
			Rectangle buttonBounds = this.x26e80f23e22a05ae.ButtonBounds;
			if (this.x169279a87b6b72b2.Closable && buttonBounds.Contains(x13d4cb8d1bd20347))
			{
				buttonItem = this.x26e80f23e22a05ae;
			}
			if (this.xab98d56e18146fb2.ButtonBounds.Contains(x13d4cb8d1bd20347) && this.x169279a87b6b72b2.DrawActionsButton)
			{
				buttonItem = this.xab98d56e18146fb2;
			}
			if (this.x1f43ebe301d1df45 != buttonItem)
			{
				this.x1f43ebe301d1df45 = buttonItem;
			}
		}

		// Token: 0x06000378 RID: 888 RVA: 0x000118C0 File Offset: 0x000108C0
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this.x169279a87b6b72b2.x59a14ca9cc50a075 != null)
			{
				this.x169279a87b6b72b2.x59a14ca9cc50a075.x1aaaf41037533886(e);
				return;
			}
			this.x1c052ea7408f43d4(new Point(e.X, e.Y));
		}

		// Token: 0x06000379 RID: 889 RVA: 0x00011900 File Offset: 0x00010900
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			this.x436f6f3ee14607e0();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x00011910 File Offset: 0x00010910
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			if (this.x1f43ebe301d1df45 != null)
			{
				this.x1f43ebe301d1df45 = null;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600037B RID: 891 RVA: 0x00011928 File Offset: 0x00010928
		// (set) Token: 0x0600037C RID: 892 RVA: 0x00011930 File Offset: 0x00010930
		private ToolbarItemBase x1f43ebe301d1df45
		{
			get
			{
				return this.x216b0c2912ae7c6a;
			}
			set
			{
				if (this.x216b0c2912ae7c6a != null)
				{
					this.xf3c64f6d99f327cf(this.x216b0c2912ae7c6a);
				}
				this.x216b0c2912ae7c6a = value;
				if (this.x216b0c2912ae7c6a != null)
				{
					this.xf3c64f6d99f327cf(this.x216b0c2912ae7c6a);
				}
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x00011964 File Offset: 0x00010964
		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			if (this.x169279a87b6b72b2.LastFixedContainer == null)
			{
				return;
			}
			this.x169279a87b6b72b2.x59a14ca9cc50a075 = null;
			this.x169279a87b6b72b2.Redock(this.x169279a87b6b72b2.LastFixedContainer);
		}

		// Token: 0x0600037E RID: 894 RVA: 0x000119A0 File Offset: 0x000109A0
		protected override void OnControlRemoved(ControlEventArgs e)
		{
			base.OnControlRemoved(e);
			base.Dispose();
		}

		// Token: 0x06000380 RID: 896 RVA: 0x000119C4 File Offset: 0x000109C4
		private int xaf87aa199634a5fd(Point x9c79b5ad7b769b12)
		{
			if (!this.x169279a87b6b72b2.Resizable)
			{
				if (!false)
				{
					return 1;
				}
			}
			else
			{
				x9c79b5ad7b769b12.Offset(-base.Left, -base.Top);
				if ((x9c79b5ad7b769b12.X < 10 && x9c79b5ad7b769b12.Y <= SystemInformation.FrameBorderSize.Height) || (x9c79b5ad7b769b12.Y < 10 && x9c79b5ad7b769b12.X <= SystemInformation.FrameBorderSize.Width))
				{
					return 13;
				}
				if (x9c79b5ad7b769b12.X > base.Width - 10 && x9c79b5ad7b769b12.Y <= SystemInformation.FrameBorderSize.Height)
				{
					return 14;
				}
				if (x9c79b5ad7b769b12.Y >= 10)
				{
					goto IL_36;
				}
			}
			if (x9c79b5ad7b769b12.X < base.Width - SystemInformation.FrameBorderSize.Width)
			{
				goto IL_36;
			}
			return 14;
			IL_36:
			if (x9c79b5ad7b769b12.Y <= SystemInformation.FrameBorderSize.Height)
			{
				return 12;
			}
			if (x9c79b5ad7b769b12.X < 10)
			{
				if (3 == 0)
				{
					return 15;
				}
				if (x9c79b5ad7b769b12.Y > base.Height - 10)
				{
					return 16;
				}
			}
			if (x9c79b5ad7b769b12.X > base.Width - 10 && x9c79b5ad7b769b12.Y > base.Height - 10)
			{
				return 17;
			}
			if (x9c79b5ad7b769b12.Y < base.Height - SystemInformation.FrameBorderSize.Height)
			{
				if (x9c79b5ad7b769b12.X <= SystemInformation.FrameBorderSize.Width)
				{
					return 10;
				}
				if (x9c79b5ad7b769b12.X >= base.Width - SystemInformation.FrameBorderSize.Width)
				{
					return 11;
				}
				return 1;
			}
			return 15;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x00011B6C File Offset: 0x00010B6C
		private void x15f44af85d6d6eed(ref x502bf86f15e12152.xa47eed6ec2af88ef x30cc7819189f11b6)
		{
			if (this.x169279a87b6b72b2 != null)
			{
				int num;
				if (x30cc7819189f11b6.x08db3aeabb253cb1 == 0 && x30cc7819189f11b6.x1e218ceaee1bb583 == 0 && x30cc7819189f11b6.xdb1e70b17dab62a5 == 0)
				{
					if ((uint)num - (uint)num < 0U)
					{
						goto IL_10E;
					}
					if (x30cc7819189f11b6.xb8619098041280e9 == 0)
					{
						return;
					}
				}
				if (this.x169279a87b6b72b2 is ContainerBar)
				{
					return;
				}
				Rectangle rectangle = this.x6627773654799b76(new Rectangle(0, 0, x30cc7819189f11b6.xdb1e70b17dab62a5, x30cc7819189f11b6.xb8619098041280e9));
				bool flag;
				Size xafc895301c3c68ee = this.x169279a87b6b72b2.x3385488b2bb8e38c(rectangle.Width, out flag);
				Size size = this.x84093c435ab64702(xafc895301c3c68ee);
				this.x294222ed6113fcbd = !flag;
				int num2 = size.Width - x30cc7819189f11b6.xdb1e70b17dab62a5;
				num = size.Height - x30cc7819189f11b6.xb8619098041280e9;
				x30cc7819189f11b6.xdb1e70b17dab62a5 += num2;
				x30cc7819189f11b6.xb8619098041280e9 += num;
				if (this.xfdccfef8be88f394 == 10 || this.xfdccfef8be88f394 == 16 || this.xfdccfef8be88f394 == 13)
				{
					x30cc7819189f11b6.x08db3aeabb253cb1 -= num2;
					return;
				}
				if (this.xfdccfef8be88f394 == 13)
				{
					goto IL_122;
				}
				IL_10E:
				if (this.xfdccfef8be88f394 != 12 && this.xfdccfef8be88f394 != 14)
				{
					return;
				}
				IL_122:
				x30cc7819189f11b6.x1e218ceaee1bb583 -= num;
			}
		}

		// Token: 0x06000382 RID: 898 RVA: 0x00011CAC File Offset: 0x00010CAC
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 533)
			{
				if (this.x169279a87b6b72b2.x59a14ca9cc50a075 != null && !this.x169279a87b6b72b2.x59a14ca9cc50a075.x57ba069a692cbf47)
				{
					this.x1f1ebe887fa99dcd();
				}
			}
			else
			{
				if (m.Msg == 132)
				{
					m.Result = new IntPtr(this.xaf87aa199634a5fd(new Point(m.LParam.ToInt32())));
					return;
				}
				if (m.Msg == 161)
				{
					this.xfdccfef8be88f394 = this.xaf87aa199634a5fd(Cursor.Position);
				}
				else if (m.Msg == 70)
				{
					x502bf86f15e12152.xa47eed6ec2af88ef xa47eed6ec2af88ef = (x502bf86f15e12152.xa47eed6ec2af88ef)Marshal.PtrToStructure(m.LParam, typeof(x502bf86f15e12152.xa47eed6ec2af88ef));
					this.x15f44af85d6d6eed(ref xa47eed6ec2af88ef);
					Marshal.StructureToPtr(xa47eed6ec2af88ef, m.LParam, false);
					m.Result = IntPtr.Zero;
					return;
				}
			}
			base.WndProc(ref m);
		}

		// Token: 0x04000135 RID: 309
		private const int x0f5e12a3f39e3a5d = 132;

		// Token: 0x04000136 RID: 310
		private const int x57a058db997bc8b0 = 0;

		// Token: 0x04000137 RID: 311
		private const int x82457a68f3be01a2 = 12;

		// Token: 0x04000138 RID: 312
		private const int xa482a83c160d1d75 = 13;

		// Token: 0x04000139 RID: 313
		private const int x9c9c12a12b0661fe = 14;

		// Token: 0x0400013A RID: 314
		private const int x5e7af8d0f7c93ee0 = 15;

		// Token: 0x0400013B RID: 315
		private const int x0d55972abb53b6b3 = 16;

		// Token: 0x0400013C RID: 316
		private const int xb5478fefbcf78dda = 17;

		// Token: 0x0400013D RID: 317
		private const int x6b6981f51c2f10ad = 10;

		// Token: 0x0400013E RID: 318
		private const int xdf87e8ef5eb781bb = 11;

		// Token: 0x0400013F RID: 319
		private const int x18507ada08b935bb = 1;

		// Token: 0x04000140 RID: 320
		private const int xc8b80568cb6e0986 = 20;

		// Token: 0x04000141 RID: 321
		private const int x7260e2e8b818e128 = 2;

		// Token: 0x04000142 RID: 322
		private const int x4a87bd1a538749d7 = 70;

		// Token: 0x04000144 RID: 324
		private SandBarManager _x91f347c6e97f1846;

		// Token: 0x04000145 RID: 325
		private bool _x03e06b5dc28b3d6b;

		// Token: 0x04000146 RID: 326
		private bool x294222ed6113fcbd = true;

		// Token: 0x04000147 RID: 327
		private Rectangle xec187e7c0bfd3340;

		// Token: 0x04000148 RID: 328
		private ButtonItem x26e80f23e22a05ae;

		// Token: 0x04000149 RID: 329
		private ButtonItem xab98d56e18146fb2;

		// Token: 0x0400014A RID: 330
		private bool xfa5e20eb950b9ee1;

		// Token: 0x0400014B RID: 331
		private ToolbarItemBase x216b0c2912ae7c6a;

		// Token: 0x0400014C RID: 332
		private int xfdccfef8be88f394;

		// Token: 0x02000052 RID: 82
		private struct xa47eed6ec2af88ef
		{
			// Token: 0x040001B9 RID: 441
			public IntPtr x7cc24662a4086c94;

			// Token: 0x040001BA RID: 442
			public IntPtr x4996629b4ed4e423;

			// Token: 0x040001BB RID: 443
			public int x08db3aeabb253cb1;

			// Token: 0x040001BC RID: 444
			public int x1e218ceaee1bb583;

			// Token: 0x040001BD RID: 445
			public int xdb1e70b17dab62a5;

			// Token: 0x040001BE RID: 446
			public int xb8619098041280e9;

			// Token: 0x040001BF RID: 447
			public int xebf45bdcaa1fd1e1;
		}
	}
}

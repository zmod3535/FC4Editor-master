using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000068 RID: 104
	internal class x209ff4cb51b91bfb : NativeWindow, IDisposable
	{
		// Token: 0x06000525 RID: 1317 RVA: 0x0001BB58 File Offset: 0x0001AB58
		public x209ff4cb51b91bfb(MenuBar menuBar, Control control)
		{
			this.x49a2aa22606cd919 = menuBar;
			this.x43bec302f92080b9 = control;
			control.HandleCreated += this.x59672a586c0a505c;
			control.HandleDestroyed += this.xdd6e9beec00838c6;
			if (control.IsHandleCreated)
			{
				base.AssignHandle(control.Handle);
			}
			if (control is RichTextBox)
			{
				this.x2519a0bd16a79a77 = true;
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0001BBC0 File Offset: 0x0001ABC0
		private void x59672a586c0a505c(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			base.AssignHandle(this.x43bec302f92080b9.Handle);
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0001BBD4 File Offset: 0x0001ABD4
		private void xdd6e9beec00838c6(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.ReleaseHandle();
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0001BBDC File Offset: 0x0001ABDC
		private void xa394326a0108443a(int x130fbcecf32fe781)
		{
			Point empty = Point.Empty;
			empty.X = x443cc432acaadb1d.x0fcc9d0a21bd41f3(x130fbcecf32fe781);
			empty.Y = x443cc432acaadb1d.xefc704ff04352756(x130fbcecf32fe781);
			this.x43bec302f92080b9.BeginInvoke(new x209ff4cb51b91bfb.xb7acd76250612d1f(this.x49a2aa22606cd919.xe9df898cfdc77d97), new object[]
			{
				this.x43bec302f92080b9,
				empty,
				false
			});
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0001BC4C File Offset: 0x0001AC4C
		private void x04bf247d2c8245b6(int x130fbcecf32fe781)
		{
			bool flag = false;
			Point point = new Point(x130fbcecf32fe781);
			if (point.X == -1 || point.X == 65535)
			{
				point.X = this.x43bec302f92080b9.ClientRectangle.Width / 2;
				point.Y = this.x43bec302f92080b9.ClientRectangle.Height / 2;
				flag = true;
			}
			else
			{
				point = this.x43bec302f92080b9.PointToClient(point);
			}
			this.x43bec302f92080b9.BeginInvoke(new x209ff4cb51b91bfb.xb7acd76250612d1f(this.x49a2aa22606cd919.xe9df898cfdc77d97), new object[]
			{
				this.x43bec302f92080b9,
				point,
				flag
			});
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0001BD0C File Offset: 0x0001AD0C
		protected override void WndProc(ref Message m)
		{
			if (this.x2519a0bd16a79a77 && m.Msg == 517)
			{
				this.xa394326a0108443a(m.LParam.ToInt32());
				return;
			}
			if (!this.x2519a0bd16a79a77 && m.Msg == 123)
			{
				this.x04bf247d2c8245b6(m.LParam.ToInt32());
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001BD74 File Offset: 0x0001AD74
		public void Dispose()
		{
			if (base.Handle != IntPtr.Zero)
			{
				this.ReleaseHandle();
			}
			this.x43bec302f92080b9.HandleCreated -= this.x59672a586c0a505c;
			this.x43bec302f92080b9.HandleDestroyed -= this.xdd6e9beec00838c6;
		}

		// Token: 0x04000223 RID: 547
		private MenuBar x49a2aa22606cd919;

		// Token: 0x04000224 RID: 548
		private Control x43bec302f92080b9;

		// Token: 0x04000225 RID: 549
		private bool x2519a0bd16a79a77;

		// Token: 0x02000069 RID: 105
		// (Invoke) Token: 0x0600052D RID: 1325
		private delegate void xb7acd76250612d1f(Control control, Point pos, bool keyboard);
	}
}

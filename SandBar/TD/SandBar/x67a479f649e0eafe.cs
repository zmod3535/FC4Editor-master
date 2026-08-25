using System;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000053 RID: 83
	internal class x67a479f649e0eafe
	{
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060003D8 RID: 984 RVA: 0x00013CD0 File Offset: 0x00012CD0
		// (remove) Token: 0x060003D9 RID: 985 RVA: 0x00013CEC File Offset: 0x00012CEC
		public event EventHandler xcf02ab93209aaa9e;

		// Token: 0x060003DA RID: 986 RVA: 0x00013D08 File Offset: 0x00012D08
		public x67a479f649e0eafe(MenuBar menuBar)
		{
			this.x49a2aa22606cd919 = menuBar;
		}

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060003DB RID: 987 RVA: 0x00013D18 File Offset: 0x00012D18
		// (set) Token: 0x060003DC RID: 988 RVA: 0x00013D20 File Offset: 0x00012D20
		public Form x9b136c277ef34154
		{
			get
			{
				return this.x9492ad63ba3e62cf;
			}
			set
			{
				if (this.x9492ad63ba3e62cf == value)
				{
					return;
				}
				if (this.x9492ad63ba3e62cf != null)
				{
					this.x9492ad63ba3e62cf.ControlAdded -= this.x3b278a0040d16519;
					this.x9492ad63ba3e62cf.ControlRemoved -= this.x70b18ca545adb914;
					this.x836471776e1cf421(null);
				}
				this.x9492ad63ba3e62cf = value;
				if (this.x9492ad63ba3e62cf != null)
				{
					this.x9492ad63ba3e62cf.ControlAdded += this.x3b278a0040d16519;
					this.x9492ad63ba3e62cf.ControlRemoved += this.x70b18ca545adb914;
					MdiClient mdiClient = this.x97a1f755440150e6(this.x9492ad63ba3e62cf);
					if (mdiClient != null)
					{
						this.x836471776e1cf421(mdiClient);
					}
				}
			}
		}

		// Token: 0x060003DD RID: 989 RVA: 0x00013DC8 File Offset: 0x00012DC8
		private MdiClient x97a1f755440150e6(Form xa6607dfd4b3038ad)
		{
			foreach (object obj in xa6607dfd4b3038ad.Controls)
			{
				Control control = (Control)obj;
				if (control is MdiClient)
				{
					return (MdiClient)control;
				}
			}
			return null;
		}

		// Token: 0x060003DE RID: 990 RVA: 0x00013E3C File Offset: 0x00012E3C
		private void x3b278a0040d16519(object xe0292b9ed559da7d, ControlEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Control is MdiClient)
			{
				this.x836471776e1cf421((MdiClient)xfbf34718e704c6bc.Control);
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x00013E5C File Offset: 0x00012E5C
		private void x70b18ca545adb914(object xe0292b9ed559da7d, ControlEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Control is MdiClient)
			{
				this.x836471776e1cf421(null);
				this.OnMdiWindowStateChanged(EventArgs.Empty);
			}
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00013E80 File Offset: 0x00012E80
		private void x836471776e1cf421(MdiClient x93d7a565e3d318bf)
		{
			if (this.x93d7a565e3d318bf == x93d7a565e3d318bf)
			{
				return;
			}
			if (this.x93d7a565e3d318bf != null)
			{
				this.x93d7a565e3d318bf.ControlAdded -= this.x0968aae81e42cf11;
				this.x93d7a565e3d318bf.ControlRemoved -= this.xe0c576278c2874b7;
				this.xdc720352860bcabc.Dispose();
			}
			this.x93d7a565e3d318bf = x93d7a565e3d318bf;
			if (this.x93d7a565e3d318bf != null)
			{
				x93d7a565e3d318bf.ControlAdded += this.x0968aae81e42cf11;
				x93d7a565e3d318bf.ControlRemoved += this.xe0c576278c2874b7;
				this.xdc720352860bcabc = new x67a479f649e0eafe.xd5d9e6b82ea74eaa(x93d7a565e3d318bf);
			}
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00013F18 File Offset: 0x00012F18
		private void x0968aae81e42cf11(object xe0292b9ed559da7d, ControlEventArgs xfbf34718e704c6bc)
		{
			xfbf34718e704c6bc.Control.Resize += this.x260e686aff40d4dd;
			xfbf34718e704c6bc.Control.VisibleChanged += this.x91c9ccf3dfce7612;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x00013F48 File Offset: 0x00012F48
		private void xe0c576278c2874b7(object xe0292b9ed559da7d, ControlEventArgs xfbf34718e704c6bc)
		{
			xfbf34718e704c6bc.Control.Resize -= this.x260e686aff40d4dd;
			xfbf34718e704c6bc.Control.VisibleChanged -= this.x91c9ccf3dfce7612;
			this.OnMdiWindowStateChanged(EventArgs.Empty);
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00013F84 File Offset: 0x00012F84
		private void x260e686aff40d4dd(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.OnMdiWindowStateChanged(EventArgs.Empty);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x00013F94 File Offset: 0x00012F94
		private void x91c9ccf3dfce7612(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.OnMdiWindowStateChanged(EventArgs.Empty);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x00013FA4 File Offset: 0x00012FA4
		protected internal virtual void OnMdiWindowStateChanged(EventArgs e)
		{
			if (this.xcf02ab93209aaa9e != null)
			{
				this.xcf02ab93209aaa9e(this, e);
			}
		}

		// Token: 0x040001C0 RID: 448
		private MenuBar x49a2aa22606cd919;

		// Token: 0x040001C1 RID: 449
		private Form x9492ad63ba3e62cf;

		// Token: 0x040001C2 RID: 450
		private MdiClient x93d7a565e3d318bf;

		// Token: 0x040001C3 RID: 451
		private x67a479f649e0eafe.xd5d9e6b82ea74eaa xdc720352860bcabc;

		// Token: 0x02000054 RID: 84
		private class xd5d9e6b82ea74eaa : NativeWindow, IDisposable
		{
			// Token: 0x060003E6 RID: 998 RVA: 0x00013FBC File Offset: 0x00012FBC
			public xd5d9e6b82ea74eaa(MdiClient mdiClient)
			{
				this.x93d7a565e3d318bf = mdiClient;
				mdiClient.HandleCreated += this.xe4e00374af235952;
				mdiClient.HandleDestroyed += this.x1988177fb9e52f21;
				if (mdiClient.IsHandleCreated)
				{
					base.AssignHandle(mdiClient.Handle);
				}
			}

			// Token: 0x060003E7 RID: 999 RVA: 0x00014010 File Offset: 0x00013010
			protected override void WndProc(ref Message m)
			{
				if (m.Msg == 560)
				{
					return;
				}
				base.WndProc(ref m);
			}

			// Token: 0x060003E8 RID: 1000 RVA: 0x00014028 File Offset: 0x00013028
			private void xe4e00374af235952(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
			{
				base.AssignHandle(this.x93d7a565e3d318bf.Handle);
			}

			// Token: 0x060003E9 RID: 1001 RVA: 0x0001403C File Offset: 0x0001303C
			private void x1988177fb9e52f21(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
			{
				this.ReleaseHandle();
			}

			// Token: 0x060003EA RID: 1002 RVA: 0x00014044 File Offset: 0x00013044
			public void Dispose()
			{
				if (base.Handle != IntPtr.Zero)
				{
					this.ReleaseHandle();
				}
			}

			// Token: 0x040001C5 RID: 453
			private MdiClient x93d7a565e3d318bf;
		}
	}
}

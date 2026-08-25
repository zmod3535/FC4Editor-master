using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x0200003E RID: 62
	internal class x410f3612b9a8f9de : DockContainer
	{
		// Token: 0x06000495 RID: 1173
		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);

		// Token: 0x06000496 RID: 1174
		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x06000497 RID: 1175 RVA: 0x00023928 File Offset: 0x00022928
		public x410f3612b9a8f9de(SandDockManager manager, Guid guid)
		{
			if (!false)
			{
				goto IL_113;
			}
			if (!true)
			{
				goto IL_B1;
			}
			goto IL_D1;
			IL_41:
			if (-1 != 0)
			{
				this.xa6607dfd4b3038ad.Controls.Add(this);
				this.Dock = DockStyle.Fill;
				goto IL_CF;
			}
			goto IL_113;
			IL_B1:
			this.xa6607dfd4b3038ad.Deactivate += base.x19e788b09b195d4f;
			if (true)
			{
				this.xa6607dfd4b3038ad.Closing += this.x9218bee68262250e;
				this.xa6607dfd4b3038ad.DoubleClick += this.xe1f5f125062dc4fb;
				this.LayoutSystem.x7e9646eed248ed11 += this.x8e9e04a70e31e166;
				this.x8e9e04a70e31e166(this.LayoutSystem, EventArgs.Empty);
				this.Manager = manager;
				this.xb51cd75f17ace1ec = guid;
				goto IL_41;
			}
			IL_CF:
			goto IL_110;
			IL_D1:
			throw new ArgumentNullException("manager");
			IL_110:
			if (!false)
			{
				return;
			}
			IL_113:
			if (manager == null)
			{
				goto IL_D1;
			}
			this.xa6607dfd4b3038ad = new xd936980ea1aac341(this);
			this.xa6607dfd4b3038ad.Activated += base.xa2414c47d888068e;
			if (-2147483648 == 0)
			{
				goto IL_41;
			}
			if (2147483647 == 0)
			{
				goto IL_110;
			}
			goto IL_B1;
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x00023A50 File Offset: 0x00022A50
		public Guid x0217cda8370c1f17
		{
			get
			{
				return this.xb51cd75f17ace1ec;
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000499 RID: 1177 RVA: 0x00023A58 File Offset: 0x00022A58
		internal override bool x0c2484ccd29b8358
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x0600049A RID: 1178 RVA: 0x00023A5C File Offset: 0x00022A5C
		// (set) Token: 0x0600049B RID: 1179 RVA: 0x00023A64 File Offset: 0x00022A64
		public override SplitLayoutSystem LayoutSystem
		{
			get
			{
				return base.LayoutSystem;
			}
			set
			{
				this.LayoutSystem.x7e9646eed248ed11 -= this.x8e9e04a70e31e166;
				base.LayoutSystem = value;
				this.LayoutSystem.x7e9646eed248ed11 += this.x8e9e04a70e31e166;
				this.x8e9e04a70e31e166(this.LayoutSystem, EventArgs.Empty);
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x00023AB8 File Offset: 0x00022AB8
		// (set) Token: 0x0600049D RID: 1181 RVA: 0x00023AC0 File Offset: 0x00022AC0
		public override SandDockManager Manager
		{
			get
			{
				return base.Manager;
			}
			set
			{
				if (this.Manager != null)
				{
					goto IL_B1;
				}
				goto IL_9E;
				IL_10:
				if (this.Manager != null)
				{
					if (this.Manager.OwnerForm == null)
					{
						if (false)
						{
							goto IL_B1;
						}
					}
					else
					{
						this.Manager.OwnerForm.AddOwnedForm(this.xa6607dfd4b3038ad);
						if (3 == 0)
						{
							goto IL_8B;
						}
						this.Font = new Font(this.Manager.OwnerForm.Font, this.Manager.OwnerForm.Font.Style);
					}
				}
				return;
				IL_8B:
				if (this.Manager.OwnerForm != null)
				{
					goto IL_B4;
				}
				if (false)
				{
					goto IL_10;
				}
				IL_9E:
				base.Manager = value;
				goto IL_10;
				IL_B1:
				if (!false)
				{
					goto IL_8B;
				}
				IL_B4:
				this.Manager.OwnerForm.RemoveOwnedForm(this.xa6607dfd4b3038ad);
				goto IL_9E;
			}
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x00023BA0 File Offset: 0x00022BA0
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (base.IsDisposed)
				{
					if ((disposing ? 1U : 0U) >= 0U)
					{
						goto IL_25;
					}
				}
				else
				{
					this.LayoutSystem.x7e9646eed248ed11 -= this.x8e9e04a70e31e166;
					this.xa6607dfd4b3038ad.Activated -= base.xa2414c47d888068e;
				}
				this.xa6607dfd4b3038ad.Deactivate -= base.x19e788b09b195d4f;
				this.xa6607dfd4b3038ad.Closing -= this.x9218bee68262250e;
				this.xa6607dfd4b3038ad.DoubleClick -= this.xe1f5f125062dc4fb;
				LayoutUtilities.xa7513d57b4844d46(this);
				this.xa6607dfd4b3038ad.Dispose();
			}
			IL_25:
			base.Dispose(disposing);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00023C70 File Offset: 0x00022C70
		public void x35579b297303ed43()
		{
			this.xa6607dfd4b3038ad.Show();
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00023C80 File Offset: 0x00022C80
		public void x5486e0b5e830d25c()
		{
			this.xa6607dfd4b3038ad.Hide();
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x00023C90 File Offset: 0x00022C90
		public Form xd936980ea1aac341
		{
			get
			{
				return this.xa6607dfd4b3038ad;
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060004A2 RID: 1186 RVA: 0x00023C98 File Offset: 0x00022C98
		public Rectangle x5de6fa99acd93adb
		{
			get
			{
				return this.xa6607dfd4b3038ad.Bounds;
			}
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00023CA8 File Offset: 0x00022CA8
		public void x159713d3b60fae0c(Rectangle xda73fcb97c77d998, bool x789c645a15deb49b, bool x17cc8f73454a0462)
		{
			int num = 0;
			if (!false)
			{
			}
			for (;;)
			{
				if (!x789c645a15deb49b)
				{
					num |= 128;
				}
				else
				{
					num |= 64;
				}
				IL_CA:
				if (x17cc8f73454a0462)
				{
					goto IL_CD;
				}
				num |= 16;
				bool flag = (x17cc8f73454a0462 ? 1U : 0U) - (x17cc8f73454a0462 ? 1U : 0U) > uint.MaxValue;
				if (!flag)
				{
					goto IL_C8;
				}
				IL_FF:
				flag = ((uint)num < 0U);
				if (flag)
				{
					continue;
				}
				if (false)
				{
					break;
				}
				if ((x17cc8f73454a0462 ? 1U : 0U) < 0U)
				{
					goto IL_118;
				}
				IntPtr zero;
				x410f3612b9a8f9de.SetWindowPos(new HandleRef(this, this.xa6607dfd4b3038ad.Handle), new HandleRef(this, zero), xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height, num);
				this.xa6607dfd4b3038ad.Visible = x789c645a15deb49b;
				if (!x789c645a15deb49b)
				{
					break;
				}
				IEnumerator enumerator = this.xa6607dfd4b3038ad.Controls.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						Control control = (Control)obj;
						control.Visible = true;
					}
					break;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (((x17cc8f73454a0462 ? 1U : 0U) & 0U) != 0U || disposable != null)
					{
						disposable.Dispose();
					}
				}
				IL_CD:
				zero = IntPtr.Zero;
				goto IL_FF;
				IL_C8:
				goto IL_CD;
				IL_118:
				goto IL_CA;
			}
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060004A4 RID: 1188 RVA: 0x00023DF8 File Offset: 0x00022DF8
		// (set) Token: 0x060004A5 RID: 1189 RVA: 0x00023E08 File Offset: 0x00022E08
		public Size xb1090c5821a633b5
		{
			get
			{
				return this.xa6607dfd4b3038ad.Size;
			}
			set
			{
				this.xa6607dfd4b3038ad.Size = value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x00023E18 File Offset: 0x00022E18
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x00023E28 File Offset: 0x00022E28
		public Point x12992900724b93dc
		{
			get
			{
				return this.xa6607dfd4b3038ad.Location;
			}
			set
			{
				this.xa6607dfd4b3038ad.Location = value;
			}
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00023E38 File Offset: 0x00022E38
		private void xe20c835979d60df8(DockControl x321bff1c322e5433, DockControl x31b34ee91c89cf69)
		{
			if (x31b34ee91c89cf69 != null)
			{
				this.xa6607dfd4b3038ad.Text = x31b34ee91c89cf69.Text;
				return;
			}
			this.xa6607dfd4b3038ad.Text = "";
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00023E60 File Offset: 0x00022E60
		public void xd1bdd0ee5924b59e()
		{
			this.x8e9e04a70e31e166(null, null);
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00023E6C File Offset: 0x00022E6C
		private void x8e9e04a70e31e166(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x6fd7c9ad69859c3e == null)
			{
				goto IL_2E;
			}
			if (!false)
			{
				if (false)
				{
					return;
				}
				this.x6fd7c9ad69859c3e.xcc55983eb55360ac -= this.xe20c835979d60df8;
				if (-1 == 0)
				{
					goto IL_38;
				}
				goto IL_2E;
			}
			do
			{
				IL_0B:
				this.xa6607dfd4b3038ad.Text = "";
			}
			while (15 == 0);
			this.x6fd7c9ad69859c3e = null;
			return;
			IL_2E:
			if (!base.HasSingleControlLayoutSystem)
			{
				goto IL_0B;
			}
			IL_38:
			this.x6fd7c9ad69859c3e = (ControlLayoutSystem)this.LayoutSystem.LayoutSystems[0];
			this.x6fd7c9ad69859c3e.xcc55983eb55360ac += this.xe20c835979d60df8;
			this.xe20c835979d60df8(null, this.x6fd7c9ad69859c3e.SelectedControl);
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x00023F1C File Offset: 0x00022F1C
		public override bool IsFloating
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00023F20 File Offset: 0x00022F20
		private void x9218bee68262250e(object xe0292b9ed559da7d, CancelEventArgs xfbf34718e704c6bc)
		{
			if (this.x50765ed4559630d6)
			{
				for (;;)
				{
					DockControl[] x9476096be9672d = this.LayoutSystem.x9476096be9672d38;
					DockControl[] array = x9476096be9672d;
					int num = 0;
					if (((uint)num | 4U) == 0U)
					{
						goto IL_4D;
					}
					IL_53:
					int i;
					bool flag;
					if (num >= array.Length)
					{
						DockControl[] array2 = x9476096be9672d;
						i = 0;
						while (i < array2.Length)
						{
							for (;;)
							{
								DockControl dockControl = array2[i];
								if (dockControl.Close())
								{
									break;
								}
								flag = (((uint)i | 4U) == 0U);
								if (!flag)
								{
									goto IL_D8;
								}
								if ((uint)i + (uint)num >= 0U)
								{
									goto Block_7;
								}
							}
							i++;
							continue;
							Block_7:
							if ((uint)num + (uint)i <= 4294967295U)
							{
								goto IL_BC;
							}
							break;
						}
						break;
					}
					goto IL_BC;
					IL_D8:
					flag = ((uint)num - (uint)i > uint.MaxValue);
					if (flag)
					{
						continue;
					}
					goto IL_129;
					IL_BC:
					DockControl dockControl2 = array[num];
					if (((uint)i & 0U) != 0U)
					{
						goto IL_D8;
					}
					if (!dockControl2.AllowClose)
					{
						goto Block_5;
					}
					IL_4D:
					num++;
					goto IL_53;
				}
				IL_48:
				return;
				Block_5:
				xfbf34718e704c6bc.Cancel = true;
				goto IL_48;
				IL_129:
				xfbf34718e704c6bc.Cancel = true;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0002405C File Offset: 0x0002305C
		public DockControl xbe0b15fe97a1ee89
		{
			get
			{
				ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem(this);
				if (false)
				{
					if (!false)
					{
						if (-1 != 0)
						{
							goto IL_30;
						}
					}
				}
				if (controlLayoutSystem == null)
				{
					throw new InvalidOperationException("A docking operation was started while the window hierarchy is in an invalid state.");
				}
				IL_30:
				return controlLayoutSystem.SelectedControl;
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x000240A0 File Offset: 0x000230A0
		private void xe1f5f125062dc4fb(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			Form activeForm = Form.ActiveForm;
			for (;;)
			{
				IL_112:
				Form xd936980ea1aac = this.xd936980ea1aac341;
				DockControl[] x9476096be9672d = this.LayoutSystem.x9476096be9672d38;
				DockControl xbe0b15fe97a1ee = this.xbe0b15fe97a1ee89;
				if (x9476096be9672d[0].MetaData.LastFixedDockSituation == DockSituation.Docked)
				{
					if (!this.LayoutSystem.xe302f2203dc14a18(xbe0b15fe97a1ee.MetaData.LastFixedDockSide))
					{
						return;
					}
				}
				for (;;)
				{
					if (x9476096be9672d[0].MetaData.LastFixedDockSituation == DockSituation.Document)
					{
						if (!this.LayoutSystem.xe302f2203dc14a18(ContainerDockLocation.Center))
						{
							return;
						}
					}
					do
					{
						IL_A9:
						SandDockManager manager = this.Manager;
						if (!false)
						{
							this.LayoutSystem = new SplitLayoutSystem();
							base.Dispose();
						}
						if (xbe0b15fe97a1ee.MetaData.LastFixedDockSituation != DockSituation.Docked)
						{
							goto IL_15;
						}
						if (false)
						{
							goto IL_112;
						}
						if (2147483647 == 0)
						{
							break;
						}
						x9476096be9672d[0].OpenDocked(WindowOpenMethod.OnScreenActivate);
						if (-2 != 0)
						{
							goto Block_5;
						}
					}
					while (2 != 0);
					continue;
					IL_1E:
					DockControl[] array = new DockControl[x9476096be9672d.Length - 1];
					Array.Copy(x9476096be9672d, 1, array, 0, x9476096be9672d.Length - 1);
					x9476096be9672d[0].LayoutSystem.Controls.AddRange(array);
					x9476096be9672d[0].LayoutSystem.SelectedControl = xbe0b15fe97a1ee;
					if (!false)
					{
						goto Block_1;
					}
					goto IL_DC;
					IL_15:
					x9476096be9672d[0].OpenDocument(WindowOpenMethod.OnScreenActivate);
					goto IL_1E;
					Block_5:
					if (false)
					{
						return;
					}
					goto IL_1E;
					IL_DC:
					goto IL_A9;
				}
			}
			Block_1:;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000241DC File Offset: 0x000231DC
		internal void x5b7f6ddd07ded8cd()
		{
			this.xa6607dfd4b3038ad.Activate();
		}

		// Token: 0x0400018C RID: 396
		private const int x339acab5bf3e83ae = 64;

		// Token: 0x0400018D RID: 397
		private const int x77bf04ec211c4a37 = 16;

		// Token: 0x0400018E RID: 398
		private const int xdbb7427772b219d6 = 128;

		// Token: 0x0400018F RID: 399
		private const int x4c4ed64783077b76 = 4;

		// Token: 0x04000190 RID: 400
		private xd936980ea1aac341 xa6607dfd4b3038ad;

		// Token: 0x04000191 RID: 401
		private ControlLayoutSystem x6fd7c9ad69859c3e;

		// Token: 0x04000192 RID: 402
		private bool x50765ed4559630d6 = true;

		// Token: 0x04000193 RID: 403
		private Guid xb51cd75f17ace1ec;
	}
}

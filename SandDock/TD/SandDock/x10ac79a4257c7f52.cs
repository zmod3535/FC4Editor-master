using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x02000008 RID: 8
	internal class x10ac79a4257c7f52 : Control
	{
		// Token: 0x06000049 RID: 73 RVA: 0x0000694C File Offset: 0x0000594C
		public x10ac79a4257c7f52()
		{
			base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			if (2 != 0)
			{
			}
			base.SetStyle(ControlStyles.Selectable, false);
			this.x820c504c9c557c92 = new x10ac79a4257c7f52.x01c0afa1afffb431(this);
			if (2147483647 != 0)
			{
				this.x537a4001020fd4c7 = new Timer();
				this.x537a4001020fd4c7.Interval = SystemInformation.DoubleClickTime;
				this.x537a4001020fd4c7.Tick += this.x79a58a5d2c65c5a4;
				this.x2076b5c9f1eb82ef = new Timer();
				this.x2076b5c9f1eb82ef.Interval = 800;
				this.x2076b5c9f1eb82ef.Tick += this.xeccc53b32ba6b859;
			}
			base.Visible = false;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00006A10 File Offset: 0x00005A10
		public x10ac79a4257c7f52.x01c0afa1afffb431 x7fdaeb05cb5e84f3
		{
			get
			{
				return this.x820c504c9c557c92;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00006A18 File Offset: 0x00005A18
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00006A20 File Offset: 0x00005A20
		public SandDockManager x460ab163f44a604d
		{
			get
			{
				return this.x91f347c6e97f1846;
			}
			set
			{
				if (this.x91f347c6e97f1846 != null)
				{
					this.x91f347c6e97f1846.UnregisterAutoHideBar(this);
				}
				for (;;)
				{
					this.x91f347c6e97f1846 = value;
					if (this.x91f347c6e97f1846 == null)
					{
						break;
					}
					this.x91f347c6e97f1846.RegisterAutoHideBar(this);
					if (4 != 0)
					{
						goto Block_3;
					}
				}
				return;
				Block_3:
				this.x7e9646eed248ed11();
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00006A74 File Offset: 0x00005A74
		private int xf03a14e5f0010fc9
		{
			get
			{
				int val = 16;
				int num = Math.Max(Control.DefaultFont.Height, val);
				return num + 6;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00006A98 File Offset: 0x00005A98
		public Control x87cf4de36131799d
		{
			get
			{
				return this.x5fea292ffeb2c28c;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00006AA0 File Offset: 0x00005AA0
		protected override Size DefaultSize
		{
			get
			{
				return new Size(this.xf03a14e5f0010fc9, this.xf03a14e5f0010fc9);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00006AB4 File Offset: 0x00005AB4
		internal bool x61c108cc44ef385a
		{
			get
			{
				return this.Dock == DockStyle.Left || this.Dock == DockStyle.Right;
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00006ACC File Offset: 0x00005ACC
		internal void x200394302d96eb9b(ControlLayoutSystem x6e150040c8d97700)
		{
			this.x7e9646eed248ed11();
			if (this.x23498f53d87354d4 == x6e150040c8d97700)
			{
				this.x5fea292ffeb2c28c.PerformLayout();
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00006AEC File Offset: 0x00005AEC
		internal void x4481febbc2e58301()
		{
			this.x7e9646eed248ed11();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00006AF4 File Offset: 0x00005AF4
		private void x7e9646eed248ed11()
		{
			int num = 0;
			if (this.x23498f53d87354d4 != null)
			{
				if (!this.x7fdaeb05cb5e84f3.x263d579af1d0d43f(this.x23498f53d87354d4))
				{
					this.xcdb145600c1b7224(true);
				}
			}
			if (this.x460ab163f44a604d != null)
			{
				RendererBase renderer = this.x460ab163f44a604d.Renderer;
				int num2;
				int num4;
				bool flag;
				using (Graphics graphics = base.CreateGraphics())
				{
					foreach (object obj in this.x7fdaeb05cb5e84f3)
					{
						ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)obj;
						num += 3;
						if (!false)
						{
							num2 = 0;
						}
						int num3;
						if (renderer.TabTextDisplay == TabTextDisplayMode.SelectedTab)
						{
							using (IEnumerator enumerator2 = controlLayoutSystem.Controls.GetEnumerator())
							{
								for (;;)
								{
									DockControl dockControl;
									if (enumerator2.MoveNext())
									{
										dockControl = (DockControl)enumerator2.Current;
										goto IL_34E;
									}
									if (((uint)num3 & 0U) != 0U)
									{
										goto IL_2F1;
									}
									break;
									IL_294:
									if (num4 > num2)
									{
										num2 = num4;
										continue;
									}
									continue;
									IL_2AC:
									num4 = (int)Math.Ceiling((double)graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.x27e1c82c97265861).Width);
									goto IL_294;
									IL_34E:
									if (!this.x61c108cc44ef385a)
									{
										goto IL_2AC;
									}
									IL_2F1:
									SizeF sizeF = graphics.MeasureString(dockControl.TabText, this.Font, int.MaxValue, EverettRenderer.xc351c68a86733972);
									if (255 == 0)
									{
										goto IL_34E;
									}
									num4 = (int)Math.Ceiling((double)sizeF.Height);
									if ((uint)num2 >= 0U)
									{
										goto IL_294;
									}
									goto IL_2AC;
								}
								goto IL_42;
							}
							break;
						}
						IL_42:
						foreach (object obj2 in controlLayoutSystem.Controls)
						{
							DockControl dockControl2 = (DockControl)obj2;
							Rectangle x700c42042910e68b = new Rectangle(-1, -1, this.xf03a14e5f0010fc9 - 2, this.xf03a14e5f0010fc9 - 2);
							if ((uint)num + (uint)num3 <= 4294967295U)
							{
								switch (this.Dock)
								{
								case DockStyle.Bottom:
									x700c42042910e68b.Offset(0, 3);
									break;
								case DockStyle.Right:
									x700c42042910e68b.Offset(3, 0);
									break;
								}
								num3 = 7;
								num3 += 16;
								if ((uint)num > 4294967295U)
								{
									goto IL_129;
								}
								if (renderer.TabTextDisplay != TabTextDisplayMode.AllTabs)
								{
									if (controlLayoutSystem.SelectedControl != dockControl2)
									{
										goto IL_B2;
									}
									goto IL_D4;
								}
								else
								{
									if (this.x61c108cc44ef385a)
									{
										goto IL_129;
									}
									flag = ((uint)num2 - (uint)num2 < 0U);
									if (!flag)
									{
										num3 += (int)Math.Ceiling((double)graphics.MeasureString(dockControl2.TabText, this.Font, int.MaxValue, EverettRenderer.x27e1c82c97265861).Width);
									}
								}
								IL_E0:
								num3 += 3;
								goto IL_B2;
								IL_129:
								num3 += (int)Math.Ceiling((double)graphics.MeasureString(dockControl2.TabText, this.Font, int.MaxValue, EverettRenderer.xc351c68a86733972).Height);
								goto IL_E0;
							}
							goto IL_D4;
							IL_B2:
							if (this.x61c108cc44ef385a)
							{
								if (((uint)num2 | 2147483648U) != 0U)
								{
									x700c42042910e68b.Offset(0, num);
								}
								x700c42042910e68b.Height = num3;
								num += num3;
							}
							else
							{
								x700c42042910e68b.Offset(num, 0);
								x700c42042910e68b.Width = num3;
								num += num3;
							}
							dockControl2.x700c42042910e68b = x700c42042910e68b;
							continue;
							IL_D4:
							num3 += num2 + 16;
							goto IL_B2;
						}
						num += 10;
					}
				}
				base.Visible = (this.x7fdaeb05cb5e84f3.Count != 0);
				flag = ((uint)num2 + (uint)num4 > uint.MaxValue);
				if (!flag)
				{
					base.Invalidate();
				}
				return;
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00006F64 File Offset: 0x00005F64
		private DockControl x37c93a224e23ba95(Point x13d4cb8d1bd20347)
		{
			foreach (object obj in this.x7fdaeb05cb5e84f3)
			{
				ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)obj;
				using (IEnumerator enumerator2 = controlLayoutSystem.Controls.GetEnumerator())
				{
					DockControl dockControl;
					Rectangle x700c42042910e68b;
					do
					{
						if (!enumerator2.MoveNext())
						{
							if (!false)
							{
								goto IL_69;
							}
						}
						dockControl = (DockControl)enumerator2.Current;
						x700c42042910e68b = dockControl.x700c42042910e68b;
					}
					while (255 != 0 && !x700c42042910e68b.Contains(x13d4cb8d1bd20347));
					return dockControl;
					IL_69:;
				}
			}
			return null;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00007050 File Offset: 0x00006050
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (this.x460ab163f44a604d != null && this.x460ab163f44a604d.DockSystemContainer != null)
			{
				this.x460ab163f44a604d.Renderer.DrawAutoHideBarBackground(this.x460ab163f44a604d.DockSystemContainer, this, pevent.Graphics, base.ClientRectangle);
				return;
			}
			base.OnPaintBackground(pevent);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000070A8 File Offset: 0x000060A8
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.x460ab163f44a604d != null)
			{
				DockSide dockSide = DockSide.Right;
				if (!false)
				{
					switch (this.Dock)
					{
					case DockStyle.Top:
						dockSide = DockSide.Top;
						if (false)
						{
							goto IL_1AF;
						}
						break;
					case DockStyle.Bottom:
						dockSide = DockSide.Bottom;
						break;
					case DockStyle.Left:
						dockSide = DockSide.Left;
						break;
					}
					this.x460ab163f44a604d.Renderer.StartRenderSession(HotkeyPrefix.None);
					IL_1AF:
					foreach (object obj in this.x7fdaeb05cb5e84f3)
					{
						ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)obj;
						using (IEnumerator enumerator2 = controlLayoutSystem.Controls.GetEnumerator())
						{
							for (;;)
							{
								if (!enumerator2.MoveNext())
								{
									if (!false)
									{
										break;
									}
								}
								DockControl dockControl = (DockControl)enumerator2.Current;
								DrawItemState drawItemState;
								for (;;)
								{
									drawItemState = DrawItemState.Default;
									if (false)
									{
										goto IL_D7;
									}
									if (15 == 0)
									{
										goto IL_E8;
									}
									if (-2 != 0)
									{
										goto IL_D7;
									}
									if (8 != 0)
									{
										goto IL_D1;
									}
									if (2 == 0)
									{
										goto IL_119;
									}
									if (!false)
									{
										goto Block_14;
									}
								}
								IL_49:
								string text;
								this.x460ab163f44a604d.Renderer.DrawCollapsedTab(e.Graphics, dockControl.x700c42042910e68b, dockSide, dockControl.x1999b243e321e38a, text, this.Font, dockControl.BackColor, dockControl.ForeColor, drawItemState, this.x61c108cc44ef385a);
								continue;
								IL_40:
								if (dockControl == controlLayoutSystem.SelectedControl)
								{
									goto IL_49;
								}
								text = "";
								if (-2 == 0)
								{
									goto IL_98;
								}
								goto IL_49;
								Block_14:
								goto IL_40;
								IL_98:
								if (this.x460ab163f44a604d.Renderer.TabTextDisplay == TabTextDisplayMode.SelectedTab)
								{
									goto IL_119;
								}
								goto IL_49;
								IL_E8:
								goto IL_98;
								IL_E0:
								text = dockControl.TabText;
								goto IL_E8;
								IL_D7:
								if (dockControl != controlLayoutSystem.SelectedControl)
								{
									goto IL_E0;
								}
								IL_D1:
								drawItemState |= DrawItemState.Selected;
								goto IL_E0;
								IL_119:
								goto IL_40;
							}
						}
					}
					this.x460ab163f44a604d.Renderer.FinishRenderSession();
					if (false)
					{
						goto IL_1B1;
					}
				}
				return;
			}
			IL_1B1:
			base.OnPaint(e);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000072B8 File Offset: 0x000062B8
		private void x53cde82d34a241f8(x87cf4de36131799d xd70b090e3181abff, Rectangle x0ac6c3cc02709091, Rectangle x0cd0c84a144ffcbc)
		{
			this.x297f71a96c16086c = true;
			try
			{
				float num = (float)(x0cd0c84a144ffcbc.X - x0ac6c3cc02709091.X);
				bool flag;
				do
				{
					IL_14B:
					float num2 = (float)(x0cd0c84a144ffcbc.Y - x0ac6c3cc02709091.Y);
					float num3 = (float)(x0cd0c84a144ffcbc.Width - x0ac6c3cc02709091.Width);
					float num5;
					for (;;)
					{
						float num4 = (float)(x0cd0c84a144ffcbc.Height - x0ac6c3cc02709091.Height);
						int tickCount = Environment.TickCount;
						for (;;)
						{
							float num6;
							float num7;
							float num8;
							float num9;
							if (Environment.TickCount >= tickCount + 100)
							{
								flag = ((uint)tickCount + (uint)num3 > uint.MaxValue);
								if (!flag)
								{
									goto IL_BC;
								}
							}
							else
							{
								num5 = (float)(Environment.TickCount - tickCount) / 100f;
								num6 = (float)x0ac6c3cc02709091.X + num * num5;
								num7 = (float)x0ac6c3cc02709091.Y + num2 * num5;
								num8 = (float)x0ac6c3cc02709091.Width + num3 * num5;
								num9 = (float)x0ac6c3cc02709091.Height + num4 * num5;
								flag = ((uint)num4 > uint.MaxValue);
								if (flag)
								{
									break;
								}
							}
							if (((uint)num2 | 8U) == 0U)
							{
								goto IL_14B;
							}
							Rectangle rectangle = new Rectangle((int)num6, (int)num7, (int)num8, (int)num9);
							xd70b090e3181abff.SetBounds(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, BoundsSpecified.All);
							Application.DoEvents();
							if (xd70b090e3181abff == null)
							{
								goto Block_3;
							}
						}
					}
					Block_3:
					flag = (((uint)num5 & 0U) == 0U);
				}
				while (!flag);
				IL_BC:;
			}
			finally
			{
				this.x297f71a96c16086c = false;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00007464 File Offset: 0x00006464
		public ControlLayoutSystem x23498f53d87354d4
		{
			get
			{
				return this.xdf67155884991aa8;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000059 RID: 89 RVA: 0x0000746C File Offset: 0x0000646C
		// (set) Token: 0x0600005A RID: 90 RVA: 0x0000747C File Offset: 0x0000647C
		public int xca843b3e9a1c605f
		{
			get
			{
				return this.x5fea292ffeb2c28c.xca843b3e9a1c605f;
			}
			set
			{
				if (value != this.x5fea292ffeb2c28c.xca843b3e9a1c605f)
				{
					this.x5fea292ffeb2c28c.xca843b3e9a1c605f = value;
				}
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00007498 File Offset: 0x00006498
		private bool x6991238ec3e25129()
		{
			return !x443cc432acaadb1d.x641f26d1017e3571;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000074A4 File Offset: 0x000064A4
		internal void xcdb145600c1b7224(bool x0b9c38731edfc369)
		{
			if (this.xdf67155884991aa8 == null)
			{
				goto IL_166;
			}
			x87cf4de36131799d x87cf4de36131799d = this.x5fea292ffeb2c28c;
			bool flag = (x0b9c38731edfc369 ? 1U : 0U) + (x0b9c38731edfc369 ? 1U : 0U) < 0U;
			bool flag2;
			if (flag || !x0b9c38731edfc369)
			{
				flag2 = !this.x6991238ec3e25129();
				goto IL_127;
			}
			IL_126:
			flag2 = true;
			IL_127:
			x0b9c38731edfc369 = flag2;
			this.x2076b5c9f1eb82ef.Enabled = false;
			int num;
			if ((uint)num >= 0U && x0b9c38731edfc369)
			{
				goto IL_F1;
			}
			Rectangle x0cd0c84a144ffcbc;
			this.x8012502b8eced8ff(this.xdf67155884991aa8.xca843b3e9a1c605f, out x0cd0c84a144ffcbc);
			x87cf4de36131799d.SuspendLayout();
			this.x53cde82d34a241f8(x87cf4de36131799d, x87cf4de36131799d.Bounds, x0cd0c84a144ffcbc);
			if (3 == 0)
			{
				goto IL_126;
			}
			IL_E6:
			x87cf4de36131799d.ResumeLayout();
			IL_F1:
			ControlLayoutSystem controlLayoutSystem = this.xdf67155884991aa8;
			this.xdf67155884991aa8 = null;
			for (;;)
			{
				Control[] array = new Control[x87cf4de36131799d.Controls.Count];
				x87cf4de36131799d.Controls.CopyTo(array, 0);
				Control[] array2 = array;
				num = 0;
				for (;;)
				{
					if (num >= array2.Length)
					{
						x87cf4de36131799d.Dispose();
						flag = ((uint)num > uint.MaxValue);
						if (flag)
						{
							break;
						}
						if (2 == 0)
						{
							return;
						}
						while (controlLayoutSystem != null)
						{
							if (controlLayoutSystem.SelectedControl != null)
							{
								goto IL_1A;
							}
							flag = (((uint)num | 1U) == 0U);
							if (!flag)
							{
								goto IL_58;
							}
						}
						if (8 != 0)
						{
							goto IL_39;
						}
					}
					else
					{
						Control x43bec302f92080b = array2[num];
						LayoutUtilities.xa7513d57b4844d46(x43bec302f92080b);
						num++;
						if ((x0b9c38731edfc369 ? 1U : 0U) > 4294967295U)
						{
							goto IL_E6;
						}
					}
				}
			}
			IL_1A:
			controlLayoutSystem.SelectedControl.OnAutoHidePopupClosed(EventArgs.Empty);
			return;
			IL_58:
			flag = ((uint)num < 0U);
			if (flag)
			{
				goto IL_166;
			}
			IL_39:
			return;
			IL_166:
			if ((x0b9c38731edfc369 ? 1U : 0U) + (x0b9c38731edfc369 ? 1U : 0U) >= 0U)
			{
				return;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00007670 File Offset: 0x00006670
		internal void xe6ff614263a59ef9(DockControl x43bec302f92080b9, bool x0b9c38731edfc369, bool x17cc8f73454a0462)
		{
			bool flag;
			if (this.xdf67155884991aa8 == x43bec302f92080b9.LayoutSystem)
			{
				flag = ((x0b9c38731edfc369 ? 1U : 0U) > uint.MaxValue);
				if (!flag)
				{
					if (false)
					{
						goto IL_2B;
					}
					if (x43bec302f92080b9.LayoutSystem.SelectedControl != x43bec302f92080b9)
					{
						goto IL_2F8;
					}
				}
				if (x17cc8f73454a0462)
				{
					x43bec302f92080b9.Activate();
				}
				return;
			}
			goto IL_2F8;
			IL_2B:
			if (x43bec302f92080b9.LayoutSystem.SelectedControl != x43bec302f92080b9)
			{
				return;
			}
			try
			{
				if (this.xdf67155884991aa8 == x43bec302f92080b9.LayoutSystem)
				{
					goto IL_296;
				}
				this.xcdb145600c1b7224(true);
				Rectangle rectangle;
				this.x792c0fd4639cad90 = this.x8012502b8eced8ff(x43bec302f92080b9.LayoutSystem.xca843b3e9a1c605f, out rectangle);
				x87cf4de36131799d x87cf4de36131799d = new x87cf4de36131799d(this);
				IEnumerator enumerator = x43bec302f92080b9.LayoutSystem.Controls.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						DockControl dockControl = (DockControl)obj;
						if (dockControl.Parent != null)
						{
							goto IL_1D3;
						}
						IL_1D9:
						dockControl.Parent = x87cf4de36131799d;
						if (!false)
						{
							continue;
						}
						IL_1D3:
						LayoutUtilities.xa7513d57b4844d46(dockControl);
						goto IL_1D9;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					for (;;)
					{
						if (disposable == null)
						{
							goto IL_23A;
						}
						disposable.Dispose();
						if (2 == 0)
						{
							continue;
						}
						IL_23C:
						if ((x0b9c38731edfc369 ? 1U : 0U) > 4294967295U)
						{
							continue;
						}
						if (!false)
						{
							break;
						}
						IL_20E:
						if ((x17cc8f73454a0462 ? 1U : 0U) - (x17cc8f73454a0462 ? 1U : 0U) < 0U)
						{
							goto IL_23C;
						}
						if (!false)
						{
							goto Block_20;
						}
						IL_23A:
						goto IL_20E;
					}
					goto IL_271;
					Block_20:
					flag = ((x0b9c38731edfc369 ? 1U : 0U) + (x0b9c38731edfc369 ? 1U : 0U) < 0U);
					if (flag)
					{
					}
					IL_271:;
				}
				x87cf4de36131799d.x5a9cbf8ad0ee9896 = x43bec302f92080b9.LayoutSystem;
				flag = ((x17cc8f73454a0462 ? 1U : 0U) - (x17cc8f73454a0462 ? 1U : 0U) < 0U);
				if (flag)
				{
					goto IL_296;
				}
				flag = ((x0b9c38731edfc369 ? 1U : 0U) + (x0b9c38731edfc369 ? 1U : 0U) < 0U);
				if (!flag)
				{
					goto IL_143;
				}
				for (;;)
				{
					IL_D0:
					x87cf4de36131799d.Bounds = this.x792c0fd4639cad90;
					x87cf4de36131799d.ResumeLayout();
					if (x87cf4de36131799d.IsDisposed)
					{
						break;
					}
					if (x87cf4de36131799d.Parent == null)
					{
						break;
					}
					this.x5fea292ffeb2c28c = x87cf4de36131799d;
					this.xdf67155884991aa8 = x43bec302f92080b9.LayoutSystem;
					flag = (((x0b9c38731edfc369 ? 1U : 0U) | 3U) == 0U);
					if (!flag)
					{
						goto IL_E4;
					}
				}
				return;
				IL_E4:
				this.x2076b5c9f1eb82ef.Enabled = true;
				x43bec302f92080b9.OnAutoHidePopupOpened(EventArgs.Empty);
				if ((x0b9c38731edfc369 ? 1U : 0U) - (x17cc8f73454a0462 ? 1U : 0U) >= 0U)
				{
					return;
				}
				goto IL_114;
				do
				{
					IL_143:
					x87cf4de36131799d.Visible = false;
					base.Parent.Controls.Add(x87cf4de36131799d);
					flag = (((x0b9c38731edfc369 ? 1U : 0U) & 0U) == 0U);
				}
				while (!flag);
				x87cf4de36131799d.Bounds = this.x792c0fd4639cad90;
				x87cf4de36131799d.SuspendLayout();
				x87cf4de36131799d.Bounds = rectangle;
				x87cf4de36131799d.Visible = true;
				x87cf4de36131799d.BringToFront();
				if (2 != 0)
				{
					flag = ((x0b9c38731edfc369 ? 1U : 0U) + (x17cc8f73454a0462 ? 1U : 0U) > uint.MaxValue);
					if (flag || !x0b9c38731edfc369)
					{
						this.x53cde82d34a241f8(x87cf4de36131799d, rectangle, this.x792c0fd4639cad90);
					}
				}
				IL_114:
				goto IL_D0;
				IL_296:
				if (!false)
				{
					return;
				}
				goto IL_143;
				goto IL_D0;
			}
			finally
			{
				if (x17cc8f73454a0462 && this.x23498f53d87354d4 == x43bec302f92080b9.LayoutSystem)
				{
					x43bec302f92080b9.Activate();
				}
			}
			IL_2F8:
			x0b9c38731edfc369 = (x0b9c38731edfc369 || !this.x6991238ec3e25129());
			x43bec302f92080b9.LayoutSystem.SelectedControl = x43bec302f92080b9;
			flag = ((x0b9c38731edfc369 ? 1U : 0U) < 0U);
			if (!flag)
			{
				goto IL_2B;
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00007A00 File Offset: 0x00006A00
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.xdf67155884991aa8 != null)
			{
				base.BeginInvoke(new x10ac79a4257c7f52.x23dc61b48e59b2f1(this.xcdb145600c1b7224), new object[]
				{
					true
				});
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00007A40 File Offset: 0x00006A40
		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			if (this.xdf67155884991aa8 != null)
			{
				base.BeginInvoke(new x10ac79a4257c7f52.x23dc61b48e59b2f1(this.xcdb145600c1b7224), new object[]
				{
					true
				});
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00007A84 File Offset: 0x00006A84
		private Rectangle x8012502b8eced8ff(int x5614e4ef0596c91d, out Rectangle xd2acd28268ef2513)
		{
			Rectangle bounds = base.Bounds;
			int num;
			switch (this.Dock)
			{
			case DockStyle.Top:
				bounds = new Rectangle(bounds.Left, bounds.Bottom, bounds.Width, 0);
				if ((uint)num <= 4294967295U)
				{
					goto IL_103;
				}
				goto IL_CC;
			case DockStyle.Bottom:
				bounds = new Rectangle(bounds.Left, bounds.Top, bounds.Width, 0);
				goto IL_103;
			case DockStyle.Left:
				IL_167:
				bounds = new Rectangle(bounds.Right, bounds.Top, 0, bounds.Height);
				goto IL_103;
			case DockStyle.Right:
				bounds = new Rectangle(bounds.Left, bounds.Top, 0, bounds.Height);
				goto IL_103;
			default:
				goto IL_103;
			}
			IL_3F:
			bounds.Width = num;
			return bounds;
			IL_9B:
			switch (this.Dock)
			{
			case DockStyle.Top:
				bounds.Height = num;
				return bounds;
			case DockStyle.Bottom:
				bounds.Offset(0, -num);
				bounds.Height = num;
				if ((uint)x5614e4ef0596c91d >= 0U)
				{
					return bounds;
				}
				goto IL_3F;
			case DockStyle.Left:
				goto IL_3F;
			case DockStyle.Right:
				bounds.Offset(-num, 0);
				bounds.Width = num;
				return bounds;
			default:
				return bounds;
			}
			IL_CC:
			num += 4;
			goto IL_9B;
			IL_103:
			xd2acd28268ef2513 = bounds;
			bool flag = true;
			num = x5614e4ef0596c91d;
			if (flag)
			{
				goto IL_CC;
			}
			if (((uint)num & 0U) != 0U)
			{
				goto IL_3F;
			}
			if ((uint)x5614e4ef0596c91d - (uint)num > 4294967295U)
			{
				goto IL_167;
			}
			if ((uint)num + (flag ? 1U : 0U) >= 0U)
			{
				goto IL_9B;
			}
			goto IL_3F;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00007C44 File Offset: 0x00006C44
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			while (!this.x297f71a96c16086c)
			{
				if (!false)
				{
					if (8 == 0)
					{
						continue;
					}
					Point left = new Point(e.X, e.Y);
					if (left != this.xa639e9f791585165)
					{
						this.xa639e9f791585165 = left;
						this.x537a4001020fd4c7.Enabled = false;
						this.x537a4001020fd4c7.Enabled = true;
					}
				}
				return;
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00007CB4 File Offset: 0x00006CB4
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (!this.x297f71a96c16086c)
			{
				DockControl dockControl = this.x37c93a224e23ba95(new Point(e.X, e.Y));
				do
				{
					if (dockControl == null)
					{
						if (!false)
						{
							break;
						}
						if (3 == 0)
						{
							return;
						}
					}
					else
					{
						this.xe6ff614263a59ef9(dockControl, false, true);
					}
				}
				while (false);
				return;
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00007D10 File Offset: 0x00006D10
		protected override void OnDragOver(DragEventArgs drgevent)
		{
			base.OnDragOver(drgevent);
			DockControl dockControl = this.x37c93a224e23ba95(base.PointToClient(new Point(drgevent.X, drgevent.Y)));
			if (dockControl != null)
			{
				this.xe6ff614263a59ef9(dockControl, true, true);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00007D50 File Offset: 0x00006D50
		private void x79a58a5d2c65c5a4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x537a4001020fd4c7.Enabled = false;
			DockControl dockControl;
			if (8 == 0)
			{
				if (4 != 0)
				{
					return;
				}
				goto IL_13;
			}
			else
			{
				if (this.x297f71a96c16086c)
				{
					return;
				}
				dockControl = this.x37c93a224e23ba95(base.PointToClient(Cursor.Position));
				if (false)
				{
					goto IL_30;
				}
			}
			IL_10:
			if (dockControl != null)
			{
				goto IL_30;
			}
			IL_13:
			if (!false)
			{
				return;
			}
			IL_16:
			if (!false)
			{
				return;
			}
			goto IL_10;
			IL_30:
			this.xe6ff614263a59ef9(dockControl, false, false);
			if (2 != 0)
			{
				goto IL_16;
			}
			goto IL_16;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00007DBC File Offset: 0x00006DBC
		private void xeccc53b32ba6b859(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			Rectangle clientRectangle = this.x5fea292ffeb2c28c.ClientRectangle;
			bool flag2;
			for (;;)
			{
				bool flag = clientRectangle.Contains(this.x5fea292ffeb2c28c.PointToClient(Cursor.Position));
				flag2 = base.ClientRectangle.Contains(base.PointToClient(Cursor.Position));
				bool flag3 = (flag ? 1U : 0U) + (flag2 ? 1U : 0U) > uint.MaxValue;
				if (!flag3 && flag)
				{
					goto Block_5;
				}
				if (flag2)
				{
					break;
				}
				if ((flag2 ? 1U : 0U) >= 0U)
				{
					goto IL_6C;
				}
				IL_11:
				if (!this.x5fea292ffeb2c28c.ContainsFocus)
				{
					goto IL_6E;
				}
				flag3 = ((flag2 ? 1U : 0U) - (flag ? 1U : 0U) < 0U);
				if (!flag3)
				{
					break;
				}
				flag3 = ((flag ? 1U : 0U) - (flag ? 1U : 0U) > uint.MaxValue);
				if (!flag3)
				{
					continue;
				}
				IL_6C:
				if (this.x5fea292ffeb2c28c.x1c3de22188ea5bb2)
				{
					break;
				}
				flag3 = ((flag2 ? 1U : 0U) - (flag ? 1U : 0U) > uint.MaxValue);
				if (!flag3)
				{
					goto IL_11;
				}
			}
			return;
			IL_6E:
			this.xcdb145600c1b7224(false);
			return;
			Block_5:
			if (((flag2 ? 1U : 0U) | 4294967294U) != 0U)
			{
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00007EF0 File Offset: 0x00006EF0
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				do
				{
					this.xcdb145600c1b7224(true);
					this.x537a4001020fd4c7.Tick -= this.x79a58a5d2c65c5a4;
					this.x537a4001020fd4c7.Dispose();
				}
				while ((disposing ? 1U : 0U) + (disposing ? 1U : 0U) > 4294967295U);
				this.x537a4001020fd4c7 = null;
				this.x2076b5c9f1eb82ef.Tick -= this.xeccc53b32ba6b859;
				bool flag = (disposing ? 1U : 0U) - (disposing ? 1U : 0U) < 0U;
				if (!flag)
				{
					this.x2076b5c9f1eb82ef.Dispose();
				}
				this.x2076b5c9f1eb82ef = null;
				if (this.x5fea292ffeb2c28c != null)
				{
					this.x5fea292ffeb2c28c.Dispose();
					this.x5fea292ffeb2c28c = null;
				}
				this.x7fdaeb05cb5e84f3.Clear();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00007FD0 File Offset: 0x00006FD0
		public void xbb5f70c792fb9034(Rectangle xda73fcb97c77d998)
		{
			this.x5fea292ffeb2c28c.Invalidate(xda73fcb97c77d998);
		}

		// Token: 0x0400001C RID: 28
		private SandDockManager x91f347c6e97f1846;

		// Token: 0x0400001D RID: 29
		private x10ac79a4257c7f52.x01c0afa1afffb431 x820c504c9c557c92;

		// Token: 0x0400001E RID: 30
		private Timer x537a4001020fd4c7;

		// Token: 0x0400001F RID: 31
		private Timer x2076b5c9f1eb82ef;

		// Token: 0x04000020 RID: 32
		private Point xa639e9f791585165;

		// Token: 0x04000021 RID: 33
		private ControlLayoutSystem xdf67155884991aa8;

		// Token: 0x04000022 RID: 34
		private x87cf4de36131799d x5fea292ffeb2c28c;

		// Token: 0x04000023 RID: 35
		private Rectangle x792c0fd4639cad90;

		// Token: 0x04000024 RID: 36
		private bool x297f71a96c16086c;

		// Token: 0x02000031 RID: 49
		[DefaultMember("Item")]
		internal class x01c0afa1afffb431 : CollectionBase
		{
			// Token: 0x0600041A RID: 1050 RVA: 0x000211C8 File Offset: 0x000201C8
			public x01c0afa1afffb431(x10ac79a4257c7f52 parent)
			{
				this.xb6a159a84cb992d6 = parent;
			}

			// Token: 0x0600041B RID: 1051 RVA: 0x000211D8 File Offset: 0x000201D8
			public bool x263d579af1d0d43f(ControlLayoutSystem x6e150040c8d97700)
			{
				return base.List.Contains(x6e150040c8d97700);
			}

			// Token: 0x0600041C RID: 1052 RVA: 0x000211E8 File Offset: 0x000201E8
			protected override void OnInsertComplete(int index, object value)
			{
				ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)value;
				controlLayoutSystem.xa85d8c17921cc878(this.xb6a159a84cb992d6);
				this.xb6a159a84cb992d6.x7e9646eed248ed11();
			}

			// Token: 0x0600041D RID: 1053 RVA: 0x00021214 File Offset: 0x00020214
			protected override void OnRemoveComplete(int index, object value)
			{
				ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)value;
				controlLayoutSystem.xa85d8c17921cc878(null);
				this.xb6a159a84cb992d6.x7e9646eed248ed11();
			}

			// Token: 0x0600041E RID: 1054 RVA: 0x0002123C File Offset: 0x0002023C
			protected override void OnClearComplete()
			{
				this.xb6a159a84cb992d6.x7e9646eed248ed11();
			}

			// Token: 0x0600041F RID: 1055 RVA: 0x0002124C File Offset: 0x0002024C
			protected override void OnClear()
			{
				foreach (object obj in this)
				{
					ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)obj;
					controlLayoutSystem.xa85d8c17921cc878(null);
				}
			}

			// Token: 0x06000420 RID: 1056 RVA: 0x000212B0 File Offset: 0x000202B0
			public int xd6b6ed77479ef68c(ControlLayoutSystem x6e150040c8d97700)
			{
				return base.List.Add(x6e150040c8d97700);
			}

			// Token: 0x06000421 RID: 1057 RVA: 0x000212C0 File Offset: 0x000202C0
			public void x52b190e626f65140(ControlLayoutSystem x6e150040c8d97700)
			{
				base.List.Remove(x6e150040c8d97700);
			}

			// Token: 0x17000109 RID: 265
			// (get) Token: 0x06000422 RID: 1058 RVA: 0x000212D0 File Offset: 0x000202D0
			public ControlLayoutSystem xe6d4b1b411ed94b5
			{
				get
				{
					return (ControlLayoutSystem)base.List[xc0c4c459c6ccbd00];
				}
			}

			// Token: 0x0400015A RID: 346
			private x10ac79a4257c7f52 xb6a159a84cb992d6;
		}

		// Token: 0x0200005E RID: 94
		// (Invoke) Token: 0x06000531 RID: 1329
		private delegate void x23dc61b48e59b2f1(bool quick);
	}
}

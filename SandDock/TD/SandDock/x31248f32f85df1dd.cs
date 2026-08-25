using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x02000042 RID: 66
	internal class x31248f32f85df1dd : xedb4922162c60d3d
	{
		// Token: 0x060004B8 RID: 1208 RVA: 0x00024704 File Offset: 0x00023704
		public x31248f32f85df1dd(SandDockManager manager, DockContainer container, LayoutSystemBase sourceControlSystem, DockControl sourceControl, int dockedSize, Point startPoint, DockingHints dockingHints) : base(manager, container, sourceControlSystem, sourceControl, dockedSize, startPoint, dockingHints)
		{
			this.x71ba9145749e5eef = new ArrayList();
			do
			{
				if (base.x460ab163f44a604d == null)
				{
					if ((uint)dockedSize >= 0U)
					{
						break;
					}
				}
				else if (base.x460ab163f44a604d.DockSystemContainer == null)
				{
					if (true)
					{
						break;
					}
				}
				else
				{
					this.xcaa196e697d8d7c5();
				}
			}
			while ((uint)dockedSize + (uint)dockedSize < 0U);
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00024788 File Offset: 0x00023788
		private void xcaa196e697d8d7c5()
		{
			this.x6f306c95372dd403 = xedb4922162c60d3d.xc68a4bb946c59a9e(base.x460ab163f44a604d.DockSystemContainer.ClientRectangle, base.x460ab163f44a604d.DockSystemContainer);
			for (;;)
			{
				IL_27A:
				this.x8caac3836061e4ad = xedb4922162c60d3d.xc68a4bb946c59a9e(xedb4922162c60d3d.x41c62f474d3fb367(base.x460ab163f44a604d.DockSystemContainer), base.x460ab163f44a604d.DockSystemContainer);
				while (base.xe302f2203dc14a18(ContainerDockLocation.Top))
				{
					this.x71ba9145749e5eef.Add(new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Top));
					if (true)
					{
						IL_265:
						if (base.xe302f2203dc14a18(ContainerDockLocation.Left))
						{
							this.x71ba9145749e5eef.Add(new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Left));
							goto IL_1DC;
						}
						if (2147483647 != 0)
						{
							goto IL_1DC;
						}
						IL_220:
						this.x71ba9145749e5eef.Add(new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Bottom));
						if (4 == 0)
						{
							goto IL_27A;
						}
						goto IL_2D5;
						IL_1DC:
						if (!base.xe302f2203dc14a18(ContainerDockLocation.Bottom))
						{
							goto IL_1E5;
						}
						goto IL_220;
					}
				}
				goto IL_265;
			}
			IL_1E5:
			if (!base.xe302f2203dc14a18(ContainerDockLocation.Right))
			{
				goto IL_1C6;
			}
			this.x71ba9145749e5eef.Add(new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Right));
			bool flag;
			if (((flag ? 1U : 0U) & 0U) != 0U)
			{
				goto IL_21B;
			}
			goto IL_1C6;
			IL_10A:
			bool flag2 = true;
			IL_111:
			bool flag3 = flag2;
			for (;;)
			{
				if (flag3)
				{
					this.x71ba9145749e5eef.Add(new x31248f32f85df1dd.x23d0185c2770c169(this, this.x8caac3836061e4ad, DockStyle.Fill));
				}
				if (base.x460ab163f44a604d == null)
				{
					break;
				}
				if ((flag ? 1U : 0U) < 0U)
				{
					goto IL_1C6;
				}
				if (base.x460ab163f44a604d.OwnerForm == null)
				{
					if (!false)
					{
						break;
					}
					if ((flag ? 1U : 0U) - (flag3 ? 1U : 0U) <= 4294967295U)
					{
						goto Block_12;
					}
				}
				using (IEnumerator enumerator = this.x71ba9145749e5eef.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						Form ownedForm = (Form)obj;
						base.x460ab163f44a604d.OwnerForm.AddOwnedForm(ownedForm);
					}
					break;
				}
			}
			return;
			Block_12:
			goto IL_17F;
			IL_14D:
			bool flag4 = true;
			IL_14E:
			flag = flag4;
			bool flag5;
			if (flag5)
			{
				flag2 = false;
				goto IL_111;
			}
			if (base.xe302f2203dc14a18(ContainerDockLocation.Center))
			{
				goto IL_10A;
			}
			flag2 = flag;
			goto IL_111;
			IL_153:
			if (base.xe302f2203dc14a18(ContainerDockLocation.Right))
			{
				bool flag6 = ((flag ? 1U : 0U) | 2147483648U) == 0U;
				if (!flag6 && (flag ? 1U : 0U) - (flag5 ? 1U : 0U) <= 4294967295U)
				{
					goto IL_14D;
				}
			}
			if (base.xe302f2203dc14a18(ContainerDockLocation.Top))
			{
				goto IL_14D;
			}
			flag4 = base.xe302f2203dc14a18(ContainerDockLocation.Bottom);
			goto IL_14E;
			IL_17F:
			if (base.xe302f2203dc14a18(ContainerDockLocation.Left))
			{
				goto IL_21B;
			}
			goto IL_153;
			IL_1C6:
			flag5 = (base.xc99dabdb533b119a.Dock == DockStyle.Fill && !base.xc99dabdb533b119a.IsFloating);
			goto IL_17F;
			IL_21B:
			if (false)
			{
				bool flag6 = ((flag ? 1U : 0U) | uint.MaxValue) == 0U;
				if (!flag6)
				{
					goto IL_10A;
				}
			}
			else
			{
				if ((flag5 ? 1U : 0U) >= 0U)
				{
					goto IL_14D;
				}
				goto IL_153;
			}
			return;
			IL_2D5:
			goto IL_1E5;
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00024AAC File Offset: 0x00023AAC
		protected override xedb4922162c60d3d.DockTarget FindDockTarget(Point position)
		{
			xedb4922162c60d3d.DockTarget dockTarget = null;
			for (;;)
			{
				bool flag = this.x6f306c95372dd403.Contains(position);
				bool flag2 = this.x8caac3836061e4ad.Contains(position);
				int num;
				bool flag3;
				object[] array;
				for (;;)
				{
					flag3 = ((uint)num - (flag2 ? 1U : 0U) > uint.MaxValue);
					if (flag3)
					{
						goto IL_44C;
					}
					goto IL_46F;
					IL_420:
					array = this.x71ba9145749e5eef.ToArray();
					if ((flag ? 1U : 0U) >= 0U)
					{
						goto Block_35;
					}
					continue;
					IL_44C:
					if (flag2 == this.x66992a14bbd05efe)
					{
						break;
					}
					if ((uint)num > 4294967295U)
					{
						goto IL_35B;
					}
					if ((uint)num + (flag ? 1U : 0U) <= 4294967295U)
					{
						goto IL_420;
					}
					IL_46F:
					if (flag != this.x347de2b6e474668a)
					{
						goto IL_420;
					}
					goto IL_44C;
				}
				ControlLayoutSystem controlLayoutSystem;
				for (;;)
				{
					IL_2CC:
					controlLayoutSystem = this.x674f2f3b17dc4197(position, out dockTarget);
					if (((uint)num | 2147483648U) == 0U)
					{
						goto IL_160;
					}
					if (controlLayoutSystem != base.xf333586e50dccad2)
					{
						goto IL_242;
					}
					flag3 = ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) < 0U);
					if (flag3)
					{
						goto Block_28;
					}
					if (base.x59ae058c4a0dec87 != null)
					{
						goto IL_242;
					}
					controlLayoutSystem = null;
					flag3 = (((flag2 ? 1U : 0U) & 0U) == 0U);
					if (!flag3)
					{
						goto IL_34E;
					}
					if (!false)
					{
						goto IL_368;
					}
					if (!false)
					{
						goto IL_350;
					}
					if (!false)
					{
						goto IL_301;
					}
				}
				IL_1C4:
				flag3 = ((uint)num - (flag2 ? 1U : 0U) < 0U);
				int num2;
				if (flag3)
				{
					if (-1 == 0)
					{
						goto IL_242;
					}
					continue;
				}
				else
				{
					flag3 = ((uint)num - (uint)num2 < 0U);
					if (flag3)
					{
						break;
					}
					if ((flag ? 1U : 0U) - (flag ? 1U : 0U) >= 0U)
					{
						goto IL_22;
					}
					goto IL_3AF;
				}
				IL_86:
				x31248f32f85df1dd.x23d0185c2770c169 x23d0185c2770c;
				dockTarget = x23d0185c2770c.x22749e65b5253094(position);
				if (false)
				{
					goto IL_1C4;
				}
				if ((uint)num2 - (uint)num2 >= 0U)
				{
					goto IL_46;
				}
				IL_22:
				Rectangle x6ae4612a8469678e;
				if (!x6ae4612a8469678e.Contains(position))
				{
					goto IL_46;
				}
				goto IL_86;
				IL_F1:
				if ((flag2 ? 1U : 0U) + (uint)num2 >= 0U)
				{
					flag3 = ((flag ? 1U : 0U) < 0U);
					if (flag3)
					{
						goto IL_189;
					}
					if (2 == 0)
					{
						goto IL_1C4;
					}
					goto IL_BE;
				}
				IL_138:
				if (dockTarget == null)
				{
					goto IL_160;
				}
				if ((flag ? 1U : 0U) - (uint)num <= 4294967295U)
				{
					goto IL_D8;
				}
				if (((flag ? 1U : 0U) | 4294967295U) != 0U)
				{
					goto IL_F1;
				}
				IL_110:
				Rectangle x6ae4612a8469678e2;
				if (x6ae4612a8469678e2.Contains(position))
				{
					goto IL_138;
				}
				IL_11A:
				goto IL_F1;
				IL_242:
				if (controlLayoutSystem != this.x5d62a4c2b1aa6ba9)
				{
					if (this.xa0a376f49c1ad375 != null)
					{
						this.xa0a376f49c1ad375.x8ffe90e7fbccfccd();
						this.xa0a376f49c1ad375 = null;
					}
					this.x5d62a4c2b1aa6ba9 = controlLayoutSystem;
					if (this.x5d62a4c2b1aa6ba9 != null)
					{
						this.xa0a376f49c1ad375 = new x31248f32f85df1dd.x23d0185c2770c169(this, this.x5d62a4c2b1aa6ba9);
						this.xa0a376f49c1ad375.x35579b297303ed43();
					}
				}
				if (dockTarget == null)
				{
					goto IL_13D;
				}
				if ((uint)num2 + (flag ? 1U : 0U) > 4294967295U)
				{
					goto IL_11A;
				}
				flag3 = (((uint)num2 | 2U) == 0U);
				if (flag3)
				{
					goto IL_296;
				}
				goto IL_189;
				IL_4C:
				object[] array2;
				if (num >= array2.Length)
				{
					break;
				}
				x23d0185c2770c = (x31248f32f85df1dd.x23d0185c2770c169)array2[num];
				if (dockTarget != null)
				{
					goto IL_46;
				}
				x6ae4612a8469678e = x23d0185c2770c.x6ae4612a8469678e;
				if (2 == 0)
				{
					goto IL_138;
				}
				if (!false)
				{
					flag3 = ((flag2 ? 1U : 0U) - (uint)num2 > uint.MaxValue);
					if (!flag3)
					{
						goto IL_22;
					}
					if ((flag ? 1U : 0U) >= 0U)
					{
						goto IL_86;
					}
					goto IL_3D4;
				}
				IL_D8:
				array2 = this.x71ba9145749e5eef.ToArray();
				num = 0;
				goto IL_4C;
				IL_160:
				dockTarget = this.xa0a376f49c1ad375.x22749e65b5253094(position);
				goto IL_D8;
				IL_13D:
				if (this.xa0a376f49c1ad375 != null)
				{
					goto IL_1A3;
				}
				flag3 = ((uint)num2 > uint.MaxValue);
				if (flag3)
				{
					goto IL_110;
				}
				goto IL_D8;
				IL_189:
				if (dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined)
				{
					flag3 = ((flag2 ? 1U : 0U) < 0U);
					if (flag3)
					{
						goto IL_1A3;
					}
					goto IL_13D;
				}
				else
				{
					dockTarget = null;
					if (8 == 0)
					{
						goto IL_242;
					}
					goto IL_296;
				}
				IL_BE:
				goto IL_D8;
				IL_46:
				num++;
				goto IL_4C;
				IL_1A3:
				x6ae4612a8469678e2 = this.xa0a376f49c1ad375.x6ae4612a8469678e;
				goto IL_110;
				IL_368:
				goto IL_242;
				Block_28:
				goto IL_350;
				IL_296:
				goto IL_13D;
				IL_310:
				if (num2 >= array.Length)
				{
					this.x347de2b6e474668a = flag;
					this.x66992a14bbd05efe = flag2;
					goto IL_2CC;
				}
				x31248f32f85df1dd.x23d0185c2770c169 x23d0185c2770c2 = (x31248f32f85df1dd.x23d0185c2770c169)array[num2];
				flag3 = ((flag2 ? 1U : 0U) > uint.MaxValue);
				if (flag3)
				{
					goto IL_3D4;
				}
				if (x23d0185c2770c2.xa9803b9efaf4da87 == DockStyle.Fill)
				{
					goto IL_391;
				}
				goto IL_345;
				Block_35:
				num2 = 0;
				goto IL_310;
				IL_30A:
				num2++;
				goto IL_310;
				IL_3AF:
				x23d0185c2770c2.x35579b297303ed43();
				goto IL_30A;
				IL_3D4:
				flag3 = ((flag2 ? 1U : 0U) + (uint)num2 > uint.MaxValue);
				if (!flag3)
				{
					goto IL_391;
				}
				flag3 = ((uint)num + (flag ? 1U : 0U) > uint.MaxValue);
				if (flag3)
				{
					goto IL_3AF;
				}
				IL_3A1:
				if (!flag2)
				{
					x23d0185c2770c2.x5486e0b5e830d25c();
					goto IL_30A;
				}
				goto IL_3AF;
				IL_391:
				if (flag2 != this.x66992a14bbd05efe)
				{
					goto IL_3A1;
				}
				if (((uint)num2 & 0U) != 0U)
				{
					goto IL_301;
				}
				goto IL_345;
				IL_35B:
				x23d0185c2770c2.x5486e0b5e830d25c();
				goto IL_30A;
				IL_350:
				if (!flag)
				{
					goto IL_35B;
				}
				x23d0185c2770c2.x35579b297303ed43();
				IL_34E:
				goto IL_30A;
				IL_345:
				if (x23d0185c2770c2.xa9803b9efaf4da87 == DockStyle.Fill)
				{
					goto IL_34E;
				}
				IL_301:
				if (flag == this.x347de2b6e474668a)
				{
					goto IL_30A;
				}
				goto IL_350;
			}
			return dockTarget;
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00024F90 File Offset: 0x00023F90
		private ControlLayoutSystem x674f2f3b17dc4197(Point x13d4cb8d1bd20347, out xedb4922162c60d3d.DockTarget x11d58b056c032b03)
		{
			x11d58b056c032b03 = null;
			bool flag;
			ControlLayoutSystem controlLayoutSystem;
			ControlLayoutSystem result;
			for (;;)
			{
				IL_227:
				int i = 1;
				for (;;)
				{
					IL_1E6:
					while (i >= 0)
					{
						flag = Convert.ToBoolean(i);
						int j;
						bool flag2;
						for (;;)
						{
							ControlLayoutSystem[] xcdb018cc067a38ae = base.xcdb018cc067a38ae;
							for (;;)
							{
								IL_19F:
								j = 0;
								for (;;)
								{
									while (j < xcdb018cc067a38ae.Length)
									{
										controlLayoutSystem = xcdb018cc067a38ae[j];
										Rectangle rectangle;
										if (controlLayoutSystem.DockContainer.IsFloating == flag)
										{
											rectangle = new Rectangle(controlLayoutSystem.DockContainer.PointToScreen(controlLayoutSystem.Bounds.Location), controlLayoutSystem.Bounds.Size);
											goto IL_69;
										}
										if (8 == 0 || (uint)i + (uint)j < 0U)
										{
											goto IL_69;
										}
										IL_4B:
										j++;
										continue;
										IL_69:
										if (rectangle.Contains(x13d4cb8d1bd20347))
										{
											goto IL_17D;
										}
										if ((flag ? 1U : 0U) + (flag ? 1U : 0U) > 4294967295U)
										{
											goto IL_19F;
										}
										if (-2147483648 != 0)
										{
											goto IL_4B;
										}
										IL_98:
										if (15 == 0)
										{
											goto IL_A2;
										}
										if ((uint)j + (uint)j <= 4294967295U)
										{
											goto Block_2;
										}
									}
									i--;
									goto IL_98;
								}
							}
							IL_A2:
							flag2 = ((uint)i < 0U);
							if (flag2)
							{
								goto IL_B4;
							}
							flag2 = (((flag ? 1U : 0U) | 2147483648U) == 0U);
							if (!flag2)
							{
								break;
							}
							flag2 = ((uint)i + (flag ? 1U : 0U) > uint.MaxValue);
							if (!flag2)
							{
								goto IL_1E6;
							}
							flag2 = ((flag ? 1U : 0U) - (flag ? 1U : 0U) < 0U);
							if (flag2)
							{
								goto Block_9;
							}
							continue;
							Block_2:
							goto IL_A2;
						}
						IL_20F:
						flag2 = (((uint)j | 1U) == 0U);
						if (flag2)
						{
							goto IL_227;
						}
						flag2 = ((uint)j < 0U);
						if (flag2)
						{
							return result;
						}
						continue;
						IL_17D:
						x11d58b056c032b03 = base.xede53ab1a4b2e20b(controlLayoutSystem.DockContainer, controlLayoutSystem, x13d4cb8d1bd20347, false);
						if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.Undefined)
						{
							goto IL_14D;
						}
						flag2 = (((uint)i | 4U) == 0U);
						if (flag2)
						{
							goto IL_20F;
						}
						goto IL_B4;
						Block_9:
						flag2 = ((flag ? 1U : 0U) < 0U);
						if (flag2)
						{
							goto IL_14D;
						}
						goto IL_17D;
					}
					goto Block_1;
				}
			}
			do
			{
				IL_14D:
				result = controlLayoutSystem;
			}
			while ((flag ? 1U : 0U) + (flag ? 1U : 0U) < 0U);
			return result;
			Block_1:
			return null;
			IL_B4:
			result = null;
			return result;
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000251E0 File Offset: 0x000241E0
		public override void Dispose()
		{
			if (this.xa0a376f49c1ad375 != null)
			{
				this.xa0a376f49c1ad375.x8ffe90e7fbccfccd();
				this.xa0a376f49c1ad375 = null;
			}
			foreach (object obj in this.x71ba9145749e5eef)
			{
				x31248f32f85df1dd.x23d0185c2770c169 x23d0185c2770c = (x31248f32f85df1dd.x23d0185c2770c169)obj;
				x23d0185c2770c.x8ffe90e7fbccfccd();
			}
			this.x71ba9145749e5eef.Clear();
			if (!false)
			{
			}
			base.Dispose();
		}

		// Token: 0x040001A3 RID: 419
		private ControlLayoutSystem x5d62a4c2b1aa6ba9;

		// Token: 0x040001A4 RID: 420
		private x31248f32f85df1dd.x23d0185c2770c169 xa0a376f49c1ad375;

		// Token: 0x040001A5 RID: 421
		private bool x347de2b6e474668a;

		// Token: 0x040001A6 RID: 422
		private bool x66992a14bbd05efe;

		// Token: 0x040001A7 RID: 423
		private Rectangle x6f306c95372dd403;

		// Token: 0x040001A8 RID: 424
		private Rectangle x8caac3836061e4ad;

		// Token: 0x040001A9 RID: 425
		private ArrayList x71ba9145749e5eef;

		// Token: 0x02000043 RID: 67
		private class x23d0185c2770c169 : xd0a1f65420a07725
		{
			// Token: 0x060004BD RID: 1213
			[DllImport("user32.dll")]
			private static extern bool SetWindowPos(HandleRef hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int flags);

			// Token: 0x060004BE RID: 1214 RVA: 0x00025274 File Offset: 0x00024274
			private x23d0185c2770c169()
			{
				do
				{
					base.FormBorderStyle = FormBorderStyle.None;
					base.ShowInTaskbar = false;
					base.StartPosition = FormStartPosition.Manual;
					this.x1700d731d6397130 = new Timer();
					this.x1700d731d6397130.Interval = 50;
					if (-2147483648 != 0)
					{
						this.x1700d731d6397130.Tick += this.xa1ebc192abdef013;
					}
					this.xaf410773a496d7d0 = new Bitmap(88, 88, PixelFormat.Format32bppArgb);
				}
				while (-1 == 0);
			}

			// Token: 0x060004BF RID: 1215 RVA: 0x00025304 File Offset: 0x00024304
			public x23d0185c2770c169(x31248f32f85df1dd manager, Rectangle fc, DockStyle dockStyle) : this()
			{
				this.x91f347c6e97f1846 = manager;
				this.xca9af438b5818619 = dockStyle;
				if (!false)
				{
					switch (dockStyle)
					{
					case DockStyle.Top:
						break;
					case DockStyle.Bottom:
						goto IL_85;
					case DockStyle.Left:
						this.xda73fcb97c77d998 = new Rectangle(fc.X + 15, fc.Y + fc.Height / 2 - 44, 88, 88);
						goto IL_42;
					case DockStyle.Right:
						this.xda73fcb97c77d998 = new Rectangle(fc.Right - 88 - 15, fc.Y + fc.Height / 2 - 44, 88, 88);
						if (4 != 0)
						{
							goto IL_42;
						}
						break;
					case DockStyle.Fill:
						goto IL_0B;
					default:
						goto IL_42;
					}
					this.xda73fcb97c77d998 = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Y + 15, 88, 88);
					if (-2 != 0)
					{
						goto IL_42;
					}
					IL_85:
					this.xda73fcb97c77d998 = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Bottom - 88 - 15, 88, 88);
					goto IL_42;
				}
				if (2 == 0)
				{
					return;
				}
				IL_0B:
				this.xda73fcb97c77d998 = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Y + fc.Height / 2 - 44, 88, 88);
				IL_42:
				this.x912beb3fd0dd9feb();
			}

			// Token: 0x060004C0 RID: 1216 RVA: 0x00025488 File Offset: 0x00024488
			public x23d0185c2770c169(x31248f32f85df1dd manager, ControlLayoutSystem layoutSystem) : this()
			{
				this.x91f347c6e97f1846 = manager;
				this.x6e150040c8d97700 = layoutSystem;
				this.xda73fcb97c77d998 = new Rectangle(layoutSystem.DockContainer.PointToScreen(layoutSystem.Bounds.Location), layoutSystem.Bounds.Size);
				this.xda73fcb97c77d998 = new Rectangle(this.xda73fcb97c77d998.X + this.xda73fcb97c77d998.Width / 2 - 44, this.xda73fcb97c77d998.Y + this.xda73fcb97c77d998.Height / 2 - 44, 88, 88);
				if (!false)
				{
				}
				this.x912beb3fd0dd9feb();
			}

			// Token: 0x17000135 RID: 309
			// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0002552C File Offset: 0x0002452C
			public DockStyle xa9803b9efaf4da87
			{
				get
				{
					return this.xca9af438b5818619;
				}
			}

			// Token: 0x060004C2 RID: 1218 RVA: 0x00025534 File Offset: 0x00024534
			private void x912beb3fd0dd9feb()
			{
				using (Graphics graphics = Graphics.FromImage(this.xaf410773a496d7d0))
				{
					xa811784015ed8842.x91433b5e99eb7cac(graphics, Color.Transparent);
					if (!true)
					{
						goto IL_1C9;
					}
					goto IL_3DB;
					Color highlight;
					Color transparent;
					do
					{
						IL_8D:
						this.x46d7024135bf7082(graphics, (this.x3321191c6256921e && this.xf33779c598cac695 == DockSide.Left) ? highlight : transparent);
					}
					while (-1 == 0);
					IL_6E:
					if (this.xca9af438b5818619 == DockStyle.None)
					{
						goto IL_47;
					}
					if (false)
					{
						if (2 == 0)
						{
							goto IL_BA;
						}
					}
					IL_37:
					if (this.xca9af438b5818619 != DockStyle.Fill)
					{
						if (-1 == 0)
						{
							goto IL_D1;
						}
						goto IL_3F4;
					}
					IL_47:
					this.x6e8df868b7130012(graphics, (this.x3321191c6256921e && this.xf33779c598cac695 == DockSide.None) ? highlight : transparent);
					if (3 != 0)
					{
						goto IL_23C;
					}
					goto IL_37;
					IL_7A:
					if (this.xca9af438b5818619 != DockStyle.None)
					{
						if (this.xca9af438b5818619 != DockStyle.Fill)
						{
							goto IL_BA;
						}
					}
					IL_82:
					goto IL_8D;
					IL_BA:
					if (this.xca9af438b5818619 == DockStyle.Left)
					{
						goto IL_8D;
					}
					goto IL_6E;
					IL_D1:
					if (this.xca9af438b5818619 != DockStyle.Bottom)
					{
						goto IL_7A;
					}
					IL_E9:
					this.x9ceea7a4567f6a5f(graphics, (this.x3321191c6256921e && this.xf33779c598cac695 == DockSide.Bottom) ? highlight : transparent);
					goto IL_7A;
					IL_10C:
					IL_117:
					this.xa1ff3514b97ff955(graphics, (this.x3321191c6256921e && this.xf33779c598cac695 == DockSide.Right) ? highlight : transparent);
					IL_135:
					if (this.xca9af438b5818619 != DockStyle.None && this.xca9af438b5818619 != DockStyle.Fill)
					{
						goto IL_D1;
					}
					goto IL_E9;
					IL_1C9:
					if (this.xca9af438b5818619 == DockStyle.Left)
					{
						using (Image image = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintleft.png")))
						{
							graphics.DrawImageUnscaled(image, 0, 29);
							goto IL_21E;
						}
						goto IL_2AE;
					}
					IL_1D5:
					if (this.xca9af438b5818619 == DockStyle.Right)
					{
						if (false)
						{
							goto IL_10C;
						}
						using (Image image2 = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintright.png")))
						{
							graphics.DrawImageUnscaled(image2, 57, 29);
						}
					}
					IL_21E:
					highlight = SystemColors.Highlight;
					transparent = Color.Transparent;
					if (false)
					{
						goto IL_232;
					}
					if (false)
					{
						goto IL_255;
					}
					if (this.xca9af438b5818619 != DockStyle.None)
					{
						if (!true)
						{
							goto IL_393;
						}
						if (false)
						{
							goto IL_1C9;
						}
						goto IL_232;
					}
					IL_158:
					this.xd349d1e0601e763e(graphics, (this.x3321191c6256921e && this.xf33779c598cac695 == DockSide.Top) ? highlight : transparent);
					IL_189:
					if (this.xca9af438b5818619 == DockStyle.None || this.xca9af438b5818619 == DockStyle.Fill)
					{
						goto IL_117;
					}
					if (this.xca9af438b5818619 == DockStyle.Right)
					{
						goto IL_10C;
					}
					goto IL_135;
					IL_232:
					if (-1 != 0)
					{
						if (this.xca9af438b5818619 == DockStyle.Fill)
						{
							goto IL_158;
						}
						if (this.xca9af438b5818619 != DockStyle.Top)
						{
							goto IL_189;
						}
						goto IL_158;
					}
					IL_23C:
					if (2147483647 == 0)
					{
						goto IL_3DB;
					}
					goto IL_3F4;
					IL_255:
					goto IL_1C9;
					IL_2AE:
					using (Image image3 = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintbottom.png")))
					{
						graphics.DrawImageUnscaled(image3, 29, 57);
						goto IL_21E;
					}
					IL_2ED:
					if (this.xca9af438b5818619 == DockStyle.Bottom)
					{
						goto IL_2AE;
					}
					if (4 != 0)
					{
						goto IL_255;
					}
					goto IL_3CF;
					IL_307:
					if (-1 == 0)
					{
						goto IL_36F;
					}
					IL_30E:
					if (this.xca9af438b5818619 != DockStyle.Top)
					{
						goto IL_2ED;
					}
					using (Image image4 = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghinttop.png")))
					{
						graphics.DrawImageUnscaled(image4, 29, 0);
						goto IL_21E;
					}
					IL_351:
					if (!false)
					{
						goto IL_36F;
					}
					IL_354:
					if (-2147483648 == 0)
					{
						goto IL_3CF;
					}
					if (8 == 0)
					{
						goto IL_1D5;
					}
					if (8 != 0)
					{
						goto IL_307;
					}
					IL_36F:
					if (2 == 0)
					{
						goto IL_354;
					}
					if (false)
					{
						goto IL_2AE;
					}
					if (255 == 0)
					{
						goto IL_307;
					}
					goto IL_30E;
					IL_37B:
					if (this.xca9af438b5818619 != DockStyle.Fill)
					{
						goto IL_351;
					}
					IL_393:
					using (Image image5 = Image.FromStream(typeof(x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintcenter.png")))
					{
						graphics.DrawImageUnscaled(image5, 0, 0);
						goto IL_21E;
					}
					IL_3CA:
					goto IL_354;
					IL_3CF:
					goto IL_37B;
					IL_3DB:
					if (2147483647 == 0)
					{
						goto IL_82;
					}
					if (this.xca9af438b5818619 == DockStyle.None)
					{
						goto IL_393;
					}
					if (false)
					{
						goto IL_1C9;
					}
					if (!false)
					{
						goto IL_37B;
					}
					goto IL_3CA;
					IL_3F4:;
				}
				base.x0ecee64b07d2d5b1(this.xaf410773a496d7d0, byte.MaxValue);
			}

			// Token: 0x060004C3 RID: 1219 RVA: 0x000259E8 File Offset: 0x000249E8
			protected override void Dispose(bool disposing)
			{
				if (disposing)
				{
					this.xaf410773a496d7d0.Dispose();
					this.x1700d731d6397130.Tick -= this.xa1ebc192abdef013;
					this.x1700d731d6397130.Dispose();
				}
				base.Dispose(disposing);
			}

			// Token: 0x060004C4 RID: 1220 RVA: 0x00025A24 File Offset: 0x00024A24
			private xedb4922162c60d3d.DockTarget xd9d182c023a01aa8(Point x6b2bb9f943411698)
			{
				xedb4922162c60d3d.DockTarget dockTarget = null;
				if (!false)
				{
					dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem);
					if (-1 != 0)
					{
						for (;;)
						{
							dockTarget.layoutSystem = this.x6e150040c8d97700;
							dockTarget.dockContainer = this.x6e150040c8d97700.DockContainer;
							if (this.x2e982e5b420711bf(this.x922c86dd03ed0805, x6b2bb9f943411698))
							{
								goto Block_8;
							}
							if (this.x2e982e5b420711bf(this.x71b3d93f18a3424c, x6b2bb9f943411698))
							{
								goto IL_D7;
							}
							if (-2147483648 == 0)
							{
								break;
							}
							if (2 != 0)
							{
								goto Block_7;
							}
						}
						IL_79:
						if (!this.x2e982e5b420711bf(this.xd163ca0298f48d0e, x6b2bb9f943411698))
						{
							while (this.x2e982e5b420711bf(this.xa449c67cf6031591, x6b2bb9f943411698))
							{
								dockTarget.type = xedb4922162c60d3d.DockTargetType.JoinExistingSystem;
								if (3 != 0)
								{
									dockTarget.dockSide = DockSide.None;
									goto IL_2A;
								}
								if (4 == 0)
								{
									goto IL_CB;
								}
							}
							goto IL_23;
						}
						dockTarget.dockSide = DockSide.Left;
						goto IL_2A;
						Block_7:
						if (-2 != 0 && !this.x2e982e5b420711bf(this.xaf8b7fb67e0c3bcb, x6b2bb9f943411698))
						{
							goto IL_79;
						}
						dockTarget.dockSide = DockSide.Bottom;
						goto IL_2A;
						IL_D7:
						dockTarget.dockSide = DockSide.Right;
						goto IL_2A;
						Block_8:;
					}
					IL_CB:
					dockTarget.dockSide = DockSide.Top;
					goto IL_2A;
				}
				IL_23:
				dockTarget.type = xedb4922162c60d3d.DockTargetType.Undefined;
				IL_2A:
				dockTarget.bounds = this.x91f347c6e97f1846.x3102817291e84207(this.x6e150040c8d97700.DockContainer, this.x6e150040c8d97700, dockTarget.dockSide);
				return dockTarget;
			}

			// Token: 0x060004C5 RID: 1221 RVA: 0x00025B58 File Offset: 0x00024B58
			private xedb4922162c60d3d.DockTarget x54f27420b41557c2(Point x6b2bb9f943411698)
			{
				xedb4922162c60d3d.DockTarget dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem);
				if (false)
				{
					goto IL_28C;
				}
				dockTarget.layoutSystem = this.x6e150040c8d97700;
				if (!false)
				{
					dockTarget.dockContainer = ((this.x6e150040c8d97700 != null) ? this.x6e150040c8d97700.DockContainer : null);
					if (!this.x2e982e5b420711bf(this.x922c86dd03ed0805, x6b2bb9f943411698))
					{
						goto IL_1AE;
					}
					goto IL_28C;
				}
				IL_0E:
				if (dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined)
				{
					dockTarget.type = xedb4922162c60d3d.DockTargetType.CreateNewContainer;
					dockTarget.middle = (this.xca9af438b5818619 == DockStyle.Fill);
					dockTarget.bounds = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x91f347c6e97f1846.x257d5a0e25592705(dockTarget.dockLocation, this.x91f347c6e97f1846.xf8ec28822747d4db, dockTarget.middle), this.x91f347c6e97f1846.x460ab163f44a604d.DockSystemContainer);
				}
				return dockTarget;
				IL_12A:
				goto IL_0E;
				IL_1AE:
				if (!this.x2e982e5b420711bf(this.x71b3d93f18a3424c, x6b2bb9f943411698))
				{
					goto IL_158;
				}
				for (;;)
				{
					if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Right))
					{
						if (15 == 0)
						{
							goto IL_1E0;
						}
						goto IL_1FA;
					}
					IL_208:
					while (this.xca9af438b5818619 != DockStyle.Right)
					{
						if (this.xca9af438b5818619 != DockStyle.Fill)
						{
							goto IL_158;
						}
						if (false)
						{
							goto IL_C4;
						}
						if (!false && !false)
						{
							goto IL_1E0;
						}
					}
					IL_1E7:
					dockTarget.dockLocation = ContainerDockLocation.Right;
					dockTarget.dockSide = DockSide.Right;
					if (false)
					{
						continue;
					}
					break;
					IL_1E0:
					if (-1 != 0)
					{
						goto IL_1E7;
					}
					if (false)
					{
						goto IL_208;
					}
				}
				goto IL_0E;
				IL_1FA:
				if (-2147483648 == 0)
				{
					goto IL_258;
				}
				if (15 == 0)
				{
					goto IL_18B;
				}
				goto IL_158;
				IL_07:
				dockTarget.type = xedb4922162c60d3d.DockTargetType.Undefined;
				goto IL_0E;
				IL_9A:
				dockTarget.dockSide = DockSide.None;
				IL_A1:
				goto IL_0E;
				IL_C4:
				dockTarget.dockLocation = ContainerDockLocation.Center;
				if (!false)
				{
					goto IL_9A;
				}
				if (-2147483648 == 0)
				{
				}
				IL_D8:
				goto IL_07;
				IL_DF:
				if (this.x2e982e5b420711bf(this.xd163ca0298f48d0e, x6b2bb9f943411698))
				{
					if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Left))
					{
						if (false)
						{
							goto IL_25D;
						}
					}
					else
					{
						if (this.xca9af438b5818619 == DockStyle.Left)
						{
							goto IL_11C;
						}
						if (false)
						{
							goto IL_158;
						}
						if (!false)
						{
							goto IL_A6;
						}
						goto IL_A1;
					}
				}
				IL_73:
				if (!this.x2e982e5b420711bf(this.xa449c67cf6031591, x6b2bb9f943411698))
				{
					goto IL_07;
				}
				if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Center))
				{
					goto IL_07;
				}
				if (this.xca9af438b5818619 == DockStyle.Fill)
				{
					goto IL_C4;
				}
				if (3 != 0)
				{
					goto IL_D8;
				}
				if (false)
				{
					goto IL_9A;
				}
				IL_A6:
				if (this.xca9af438b5818619 != DockStyle.Fill)
				{
					goto IL_73;
				}
				IL_11C:
				dockTarget.dockLocation = ContainerDockLocation.Left;
				dockTarget.dockSide = DockSide.Left;
				goto IL_12A;
				IL_158:
				if (!this.x2e982e5b420711bf(this.xaf8b7fb67e0c3bcb, x6b2bb9f943411698))
				{
					goto IL_DF;
				}
				goto IL_18B;
				IL_16B:
				dockTarget.dockSide = DockSide.Bottom;
				goto IL_0E;
				IL_18B:
				if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Bottom))
				{
					goto IL_DF;
				}
				if (false)
				{
					goto IL_16B;
				}
				if (2147483647 == 0)
				{
					goto IL_236;
				}
				IL_258:
				if (this.xca9af438b5818619 != DockStyle.Bottom)
				{
					if (this.xca9af438b5818619 != DockStyle.Fill)
					{
						goto IL_DF;
					}
				}
				dockTarget.dockLocation = ContainerDockLocation.Bottom;
				goto IL_16B;
				IL_236:
				goto IL_1AE;
				IL_25D:
				IL_268:
				dockTarget.dockLocation = ContainerDockLocation.Top;
				dockTarget.dockSide = DockSide.Top;
				goto IL_0E;
				IL_28C:
				if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Top))
				{
					goto IL_1AE;
				}
				if (15 == 0)
				{
					goto IL_236;
				}
				if (!false && this.xca9af438b5818619 == DockStyle.Top)
				{
					goto IL_268;
				}
				if (this.xca9af438b5818619 == DockStyle.Fill)
				{
					goto IL_25D;
				}
				goto IL_1AE;
			}

			// Token: 0x060004C6 RID: 1222 RVA: 0x00025E4C File Offset: 0x00024E4C
			public xedb4922162c60d3d.DockTarget x22749e65b5253094(Point x13d4cb8d1bd20347)
			{
				Point x6b2bb9f = base.PointToClient(x13d4cb8d1bd20347);
				xedb4922162c60d3d.DockTarget dockTarget;
				if (this.x6e150040c8d97700 != null)
				{
					dockTarget = this.xd9d182c023a01aa8(x6b2bb9f);
				}
				else
				{
					dockTarget = this.x54f27420b41557c2(x6b2bb9f);
				}
				IL_49:
				bool flag = dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined;
				DockSide dockSide = (dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined) ? this.xf33779c598cac695 : dockTarget.dockSide;
				if (flag != this.x3321191c6256921e)
				{
					goto IL_2A;
				}
				IL_0D:
				if (dockSide == this.xf33779c598cac695)
				{
					return dockTarget;
				}
				IL_2A:
				this.x3321191c6256921e = flag;
				if (-1 == 0)
				{
					goto IL_49;
				}
				do
				{
					this.xf33779c598cac695 = dockSide;
					this.x912beb3fd0dd9feb();
					if (false)
					{
						goto IL_0D;
					}
				}
				while (2 == 0);
				return dockTarget;
			}

			// Token: 0x060004C7 RID: 1223 RVA: 0x00025EF0 File Offset: 0x00024EF0
			private bool x2e982e5b420711bf(Rectangle xe125219852864557, Point x13d4cb8d1bd20347)
			{
				return xe125219852864557.Contains(x13d4cb8d1bd20347);
			}

			// Token: 0x17000136 RID: 310
			// (get) Token: 0x060004C8 RID: 1224 RVA: 0x00025EFC File Offset: 0x00024EFC
			private Rectangle xa449c67cf6031591
			{
				get
				{
					return new Rectangle(28, 28, 32, 32);
				}
			}

			// Token: 0x17000137 RID: 311
			// (get) Token: 0x060004C9 RID: 1225 RVA: 0x00025F0C File Offset: 0x00024F0C
			private Rectangle x922c86dd03ed0805
			{
				get
				{
					return new Rectangle(29, 0, 29, 28);
				}
			}

			// Token: 0x17000138 RID: 312
			// (get) Token: 0x060004CA RID: 1226 RVA: 0x00025F1C File Offset: 0x00024F1C
			private Rectangle x71b3d93f18a3424c
			{
				get
				{
					return new Rectangle(60, 29, 28, 29);
				}
			}

			// Token: 0x17000139 RID: 313
			// (get) Token: 0x060004CB RID: 1227 RVA: 0x00025F2C File Offset: 0x00024F2C
			private Rectangle xaf8b7fb67e0c3bcb
			{
				get
				{
					return new Rectangle(29, 60, 29, 28);
				}
			}

			// Token: 0x1700013A RID: 314
			// (get) Token: 0x060004CC RID: 1228 RVA: 0x00025F3C File Offset: 0x00024F3C
			private Rectangle xd163ca0298f48d0e
			{
				get
				{
					return new Rectangle(0, 29, 28, 29);
				}
			}

			// Token: 0x1700013B RID: 315
			// (get) Token: 0x060004CD RID: 1229 RVA: 0x00025F4C File Offset: 0x00024F4C
			public Rectangle x6ae4612a8469678e
			{
				get
				{
					return this.xda73fcb97c77d998;
				}
			}

			// Token: 0x060004CE RID: 1230 RVA: 0x00025F54 File Offset: 0x00024F54
			private void x6e8df868b7130012(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 22, 29, 29, 22);
					x41347a961b838962.DrawLine(pen, 57, 22, 64, 29);
					x41347a961b838962.DrawLine(pen, 64, 57, 57, 64);
					x41347a961b838962.DrawLine(pen, 29, 64, 22, 57);
				}
			}

			// Token: 0x060004CF RID: 1231 RVA: 0x00025FCC File Offset: 0x00024FCC
			private void x46d7024135bf7082(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 0, 29, 0, 57);
					x41347a961b838962.DrawLine(pen, 0, 57, 23, 57);
					x41347a961b838962.DrawLine(pen, 0, 29, 23, 29);
				}
			}

			// Token: 0x060004D0 RID: 1232 RVA: 0x00026034 File Offset: 0x00025034
			private void x9ceea7a4567f6a5f(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 29, 87, 57, 87);
					x41347a961b838962.DrawLine(pen, 29, 87, 29, 64);
					x41347a961b838962.DrawLine(pen, 57, 87, 57, 64);
				}
			}

			// Token: 0x060004D1 RID: 1233 RVA: 0x000260A0 File Offset: 0x000250A0
			private void xa1ff3514b97ff955(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 87, 29, 87, 57);
					x41347a961b838962.DrawLine(pen, 87, 29, 64, 29);
					x41347a961b838962.DrawLine(pen, 87, 57, 64, 57);
				}
			}

			// Token: 0x060004D2 RID: 1234 RVA: 0x0002610C File Offset: 0x0002510C
			private void xd349d1e0601e763e(Graphics x41347a961b838962, Color x3c4da2980d043c95)
			{
				using (Pen pen = new Pen(x3c4da2980d043c95))
				{
					x41347a961b838962.DrawLine(pen, 29, 0, 57, 0);
					x41347a961b838962.DrawLine(pen, 57, 0, 57, 23);
					x41347a961b838962.DrawLine(pen, 29, 0, 29, 23);
				}
			}

			// Token: 0x060004D3 RID: 1235 RVA: 0x00026174 File Offset: 0x00025174
			public void x8ffe90e7fbccfccd()
			{
				this.x9063896ecf738664 = true;
				this.x5486e0b5e830d25c();
			}

			// Token: 0x060004D4 RID: 1236 RVA: 0x00026184 File Offset: 0x00025184
			public void x5486e0b5e830d25c()
			{
				if (!base.Visible)
				{
					goto IL_62;
				}
				goto IL_66;
				IL_0D:
				return;
				IL_12:
				if (this.x3b280f462145bf12)
				{
					goto IL_0D;
				}
				IL_1A:
				if (!this.x1700d731d6397130.Enabled)
				{
					return;
				}
				goto IL_66;
				IL_62:
				goto IL_12;
				IL_66:
				this.x1a5b1715d3a0d7a6 = Environment.TickCount;
				this.x3b280f462145bf12 = true;
				if (-2 == 0)
				{
					goto IL_12;
				}
				this.x1700d731d6397130.Start();
				if (2 == 0)
				{
					goto IL_1A;
				}
				if (255 == 0)
				{
					if (-2147483648 == 0)
					{
						goto IL_62;
					}
					if (true)
					{
						goto IL_12;
					}
				}
				else if (255 == 0)
				{
					goto IL_12;
				}
			}

			// Token: 0x060004D5 RID: 1237 RVA: 0x00026210 File Offset: 0x00025210
			public void x35579b297303ed43()
			{
				base.x0ecee64b07d2d5b1(this.xaf410773a496d7d0, 0);
				this.x2c6f5ac62ee048e5();
				this.x1a5b1715d3a0d7a6 = Environment.TickCount;
				this.x3b280f462145bf12 = false;
				this.x1700d731d6397130.Start();
			}

			// Token: 0x060004D6 RID: 1238 RVA: 0x00026244 File Offset: 0x00025244
			public void x2c6f5ac62ee048e5()
			{
				x31248f32f85df1dd.x23d0185c2770c169.SetWindowPos(new HandleRef(this, base.Handle), -1, this.xda73fcb97c77d998.X, this.xda73fcb97c77d998.Y, this.xda73fcb97c77d998.Width, this.xda73fcb97c77d998.Height, 80);
			}

			// Token: 0x060004D7 RID: 1239 RVA: 0x00026294 File Offset: 0x00025294
			private void xa1ebc192abdef013(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
			{
				int num = Environment.TickCount - this.x1a5b1715d3a0d7a6;
				if (num <= 200)
				{
					if (2 != 0)
					{
					}
				}
				else
				{
					num = 200;
				}
				double num2 = (double)num / 200.0;
				if (this.x3b280f462145bf12)
				{
					num2 = (1.0 - num2) * 255.0;
				}
				else
				{
					num2 *= 255.0;
				}
				do
				{
					base.x0ecee64b07d2d5b1(this.xaf410773a496d7d0, (byte)num2);
					if (num >= 200)
					{
						goto IL_92;
					}
				}
				while (((uint)num2 & 0U) != 0U);
				IL_36:
				if (255 != 0)
				{
					return;
				}
				IL_40:
				if (!this.x9063896ecf738664)
				{
					if (15 == 0)
					{
						goto IL_36;
					}
					if ((uint)num2 - (uint)num2 >= 0U)
					{
						return;
					}
				}
				base.Dispose();
				return;
				IL_92:
				this.x1700d731d6397130.Stop();
				base.Visible = !this.x3b280f462145bf12;
				goto IL_40;
				goto IL_36;
			}

			// Token: 0x040001AA RID: 426
			private const int xca96dc7024c32126 = 88;

			// Token: 0x040001AB RID: 427
			private const int xc82cb74794544a35 = 88;

			// Token: 0x040001AC RID: 428
			private const int x6b0037d5c155e862 = 200;

			// Token: 0x040001AD RID: 429
			private const int x77bf04ec211c4a37 = 16;

			// Token: 0x040001AE RID: 430
			private const int x339acab5bf3e83ae = 64;

			// Token: 0x040001AF RID: 431
			private x31248f32f85df1dd x91f347c6e97f1846;

			// Token: 0x040001B0 RID: 432
			private ControlLayoutSystem x6e150040c8d97700;

			// Token: 0x040001B1 RID: 433
			private Rectangle xda73fcb97c77d998 = Rectangle.Empty;

			// Token: 0x040001B2 RID: 434
			private DockSide xf33779c598cac695 = DockSide.None;

			// Token: 0x040001B3 RID: 435
			private bool x3321191c6256921e;

			// Token: 0x040001B4 RID: 436
			private Bitmap xaf410773a496d7d0;

			// Token: 0x040001B5 RID: 437
			private bool x3b280f462145bf12;

			// Token: 0x040001B6 RID: 438
			private Timer x1700d731d6397130;

			// Token: 0x040001B7 RID: 439
			private int x1a5b1715d3a0d7a6;

			// Token: 0x040001B8 RID: 440
			private bool x9063896ecf738664;

			// Token: 0x040001B9 RID: 441
			private DockStyle xca9af438b5818619;
		}
	}
}

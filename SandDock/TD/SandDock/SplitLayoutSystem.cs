using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
	// Token: 0x02000012 RID: 18
	[TypeConverter(typeof(x807757bdf074f1b8))]
	public class SplitLayoutSystem : LayoutSystemBase
	{
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000216 RID: 534 RVA: 0x00012B6C File Offset: 0x00011B6C
		// (remove) Token: 0x06000217 RID: 535 RVA: 0x00012B88 File Offset: 0x00011B88
		internal event EventHandler x7e9646eed248ed11;

		// Token: 0x06000218 RID: 536 RVA: 0x00012BA4 File Offset: 0x00011BA4
		public SplitLayoutSystem()
		{
			this.x820c504c9c557c92 = new SplitLayoutSystem.LayoutSystemBaseCollection(this);
			this.x366d4cf7098f9c63 = new ArrayList();
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00012BC4 File Offset: 0x00011BC4
		public SplitLayoutSystem(int desiredWidth, int desiredHeight) : this()
		{
			base.WorkingSize = new SizeF((float)desiredWidth, (float)desiredHeight);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00012BDC File Offset: 0x00011BDC
		[Obsolete("Use the constructor taking a SizeF instead.")]
		public SplitLayoutSystem(int desiredWidth, int desiredHeight, Orientation splitMode, LayoutSystemBase[] layoutSystems) : this(desiredWidth, desiredHeight)
		{
			this.xe36f4efbf268b3f1 = splitMode;
			this.x820c504c9c557c92.AddRange(layoutSystems);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00012BFC File Offset: 0x00011BFC
		public SplitLayoutSystem(SizeF workingSize, Orientation splitMode, LayoutSystemBase[] layoutSystems) : this()
		{
			base.WorkingSize = workingSize;
			this.xe36f4efbf268b3f1 = splitMode;
			this.x820c504c9c557c92.AddRange(layoutSystems);
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x0600021C RID: 540 RVA: 0x00012C20 File Offset: 0x00011C20
		internal override bool x56005f23d6948487
		{
			get
			{
				foreach (object obj in this.LayoutSystems)
				{
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
					if (layoutSystemBase.x56005f23d6948487)
					{
						return true;
					}
				}
				return false;
			}
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00012C94 File Offset: 0x00011C94
		public bool Optimize()
		{
			bool flag2;
			int i;
			bool flag3;
			int num;
			if (this.LayoutSystems.Count == 1)
			{
				bool flag = (flag2 ? 1U : 0U) - (uint)i < 0U;
				SplitLayoutSystem splitLayoutSystem;
				if (flag)
				{
					if ((uint)i - (flag2 ? 1U : 0U) > 4294967295U)
					{
						goto IL_5A;
					}
					flag = ((flag3 ? 1U : 0U) - (flag3 ? 1U : 0U) < 0U);
					if (!flag)
					{
						goto IL_45;
					}
					flag = (((uint)num | 4U) == 0U);
					if (flag)
					{
						goto IL_432;
					}
					goto IL_5D;
				}
				else
				{
					if (!(this.LayoutSystems[0] is SplitLayoutSystem))
					{
						goto IL_10C;
					}
					splitLayoutSystem = (SplitLayoutSystem)this.LayoutSystems[0];
					if (splitLayoutSystem.LayoutSystems.Count != 1)
					{
						return false;
					}
					if ((flag2 ? 1U : 0U) + (flag3 ? 1U : 0U) > 4294967295U)
					{
						goto IL_35C;
					}
					flag = ((uint)i < 0U);
					if (!flag)
					{
						goto IL_45;
					}
				}
				IL_31:
				if ((flag3 ? 1U : 0U) >= 0U)
				{
					return false;
				}
				goto IL_5A;
				IL_45:
				if (splitLayoutSystem.LayoutSystems[0] is SplitLayoutSystem)
				{
					goto IL_5D;
				}
				goto IL_31;
				IL_5A:
				if (false)
				{
					goto IL_45;
				}
				IL_5D:
				if (((SplitLayoutSystem)splitLayoutSystem.LayoutSystems[0]).SplitMode != this.SplitMode)
				{
					return false;
				}
				SplitLayoutSystem splitLayoutSystem2 = (SplitLayoutSystem)splitLayoutSystem.LayoutSystems[0];
				LayoutSystemBase[] array = new LayoutSystemBase[splitLayoutSystem2.LayoutSystems.Count];
				splitLayoutSystem2.LayoutSystems.CopyTo(array, 0);
				splitLayoutSystem2.LayoutSystems.xd7a3953bce504b63 = true;
				splitLayoutSystem2.LayoutSystems.Clear();
				this.LayoutSystems.xd7a3953bce504b63 = true;
				IL_432:
				this.LayoutSystems.Clear();
				this.LayoutSystems.AddRange(array);
				goto IL_344;
			}
			IL_10C:
			IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
			try
			{
				for (;;)
				{
					if (!enumerator.MoveNext())
					{
						goto IL_1C7;
					}
					goto IL_2F2;
					SplitLayoutSystem splitLayoutSystem3;
					for (;;)
					{
						IL_248:
						splitLayoutSystem3.LayoutSystems.Clear();
						if ((flag2 ? 1U : 0U) > 4294967295U)
						{
							goto IL_2F2;
						}
						num = this.LayoutSystems.IndexOf(splitLayoutSystem3);
						this.LayoutSystems.xd7a3953bce504b63 = true;
						this.LayoutSystems.Remove(splitLayoutSystem3);
						LayoutSystemBase[] array2;
						i = array2.Length - 1;
						if ((uint)num + (flag2 ? 1U : 0U) < 0U)
						{
							break;
						}
						while (i >= 0)
						{
							this.LayoutSystems.Insert(num, array2[i]);
							i--;
						}
						this.LayoutSystems.xd7a3953bce504b63 = false;
						bool flag = (flag3 ? 1U : 0U) + (uint)num < 0U;
						if (!flag)
						{
							goto IL_289;
						}
					}
					IL_2B2:
					LayoutSystemBase layoutSystemBase;
					if (!(layoutSystemBase is SplitLayoutSystem))
					{
						continue;
					}
					splitLayoutSystem3 = (SplitLayoutSystem)layoutSystemBase;
					if (splitLayoutSystem3.SplitMode != this.SplitMode)
					{
						flag3 = splitLayoutSystem3.Optimize();
						bool flag = ((uint)i | 15U) == 0U;
						if (!flag && !flag3)
						{
							continue;
						}
						flag2 = true;
						if (!false)
						{
							goto IL_14F;
						}
					}
					else
					{
						LayoutSystemBase[] array2 = new LayoutSystemBase[splitLayoutSystem3.LayoutSystems.Count];
						splitLayoutSystem3.LayoutSystems.CopyTo(array2, 0);
						if (-1 != 0)
						{
							splitLayoutSystem3.LayoutSystems.xd7a3953bce504b63 = true;
							bool flag = (uint)i - (flag3 ? 1U : 0U) < 0U;
							if (flag)
							{
								goto IL_2B0;
							}
							goto IL_248;
						}
					}
					IL_11B:
					if ((uint)num - (uint)i >= 0U)
					{
						break;
					}
					goto IL_248;
					IL_1C7:
					goto IL_11B;
					IL_2F2:
					layoutSystemBase = (LayoutSystemBase)enumerator.Current;
					goto IL_2B2;
				}
				return false;
				IL_14F:
				return flag2;
				IL_289:
				IL_2B0:
				return true;
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				bool flag = (uint)num + (flag3 ? 1U : 0U) > uint.MaxValue;
				if (flag || disposable != null)
				{
					disposable.Dispose();
				}
			}
			IL_344:
			if ((flag2 ? 1U : 0U) + (flag3 ? 1U : 0U) >= 0U)
			{
			}
			IL_35C:
			this.LayoutSystems.xd7a3953bce504b63 = false;
			return true;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00013114 File Offset: 0x00012114
		internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
		{
			base.x46ff430ed3944e0f(x11d58b056c032b03);
			while (255 != 0)
			{
				if (!false)
				{
					goto IL_27B;
				}
				IL_251:
				SandDockManager manager = base.DockContainer.Manager;
				if (!false)
				{
					goto IL_295;
				}
				if (!false)
				{
					continue;
				}
				IL_27B:
				if (x11d58b056c032b03 == null)
				{
					if (!false)
					{
						break;
					}
					if (false)
					{
						break;
					}
					if (2147483647 == 0)
					{
						goto IL_295;
					}
				}
				if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.None)
				{
					if (-1 != 0 && x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.AlreadyActioned)
					{
						x410f3612b9a8f9de x410f3612b9a8f9de = (x410f3612b9a8f9de)base.DockContainer;
						goto IL_251;
					}
				}
				return;
				break;
				IL_295:
				if (2147483647 != 0)
				{
					x410f3612b9a8f9de x410f3612b9a8f9de;
					while (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.Float)
					{
						DockControl[] x9476096be9672d = this.x9476096be9672d38;
						DockControl xbe0b15fe97a1ee = x410f3612b9a8f9de.xbe0b15fe97a1ee89;
						x410f3612b9a8f9de.LayoutSystem = new SplitLayoutSystem();
						x410f3612b9a8f9de.Dispose();
						try
						{
							if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.CreateNewContainer)
							{
								if (!false)
								{
									DockContainer dockContainer = manager.FindDockContainer(x11d58b056c032b03.dockLocation);
									while (!false)
									{
										if (x11d58b056c032b03.dockLocation != ContainerDockLocation.Center)
										{
											goto IL_16E;
										}
										if (true)
										{
											if (dockContainer != null)
											{
												break;
											}
										}
										if (3 != 0)
										{
											if (-2 == 0)
											{
												goto IL_1F5;
											}
											goto IL_16E;
										}
									}
									ControlLayoutSystem layoutSystem = LayoutUtilities.FindControlLayoutSystem(dockContainer);
									this.MoveToLayoutSystem(layoutSystem);
									goto IL_187;
								}
								IL_16E:
								base.x810df8ef88cf4bf2(manager, x11d58b056c032b03.dockLocation, x11d58b056c032b03.middle ? ContainerDockEdge.Inside : ContainerDockEdge.Outside);
								IL_187:;
							}
							else
							{
								if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.JoinExistingSystem)
								{
									goto IL_15B;
								}
								this.MoveToLayoutSystem(x11d58b056c032b03.layoutSystem, x11d58b056c032b03.index);
								if (!false)
								{
									if (!false && false)
									{
										goto IL_15B;
									}
								}
								goto IL_1F5;
								IL_15B:
								while (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.SplitExistingSystem)
								{
									if (x11d58b056c032b03.dockContainer is DocumentContainer)
									{
										ControlLayoutSystem controlLayoutSystem = x11d58b056c032b03.dockContainer.CreateNewLayoutSystem(base.WorkingSize);
										controlLayoutSystem.Controls.AddRange(x9476096be9672d);
										x11d58b056c032b03.layoutSystem.SplitForLayoutSystem(controlLayoutSystem, x11d58b056c032b03.dockSide);
										if (15 == 0)
										{
										}
									}
									else if (this.LayoutSystems.Count == 1 && this.LayoutSystems[0] is ControlLayoutSystem)
									{
										ControlLayoutSystem layoutSystem2 = (ControlLayoutSystem)this.LayoutSystems[0];
										this.LayoutSystems.Remove(layoutSystem2);
										x11d58b056c032b03.layoutSystem.SplitForLayoutSystem(layoutSystem2, x11d58b056c032b03.dockSide);
									}
									else
									{
										x11d58b056c032b03.layoutSystem.SplitForLayoutSystem(this, x11d58b056c032b03.dockSide);
										if (2 == 0)
										{
											continue;
										}
									}
									break;
								}
							}
							IL_1F5:
							return;
						}
						finally
						{
							xbe0b15fe97a1ee.Activate();
						}
					}
					x410f3612b9a8f9de.x159713d3b60fae0c(x11d58b056c032b03.bounds, true, true);
					if (-2 != 0)
					{
						return;
					}
				}
				return;
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000133DC File Offset: 0x000123DC
		public void MoveToLayoutSystem(ControlLayoutSystem layoutSystem)
		{
			this.MoveToLayoutSystem(layoutSystem, 0);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x000133E8 File Offset: 0x000123E8
		public void MoveToLayoutSystem(ControlLayoutSystem layoutSystem, int index)
		{
			DockControl dockControl = null;
			int num;
			bool flag;
			while (this.LayoutSystems.Count == 1)
			{
				if (!(this.LayoutSystems[0] is ControlLayoutSystem))
				{
					goto IL_CA;
				}
				dockControl = ((ControlLayoutSystem)this.LayoutSystems[0]).SelectedControl;
				IL_CC:
				if ((uint)num >= 0U)
				{
					goto IL_A2;
				}
				continue;
				IL_68:
				if (false)
				{
					goto IL_CC;
				}
				if (15 != 0)
				{
					flag = ((uint)index - (uint)index > uint.MaxValue);
					if (flag)
					{
						if ((uint)num + (uint)num >= 0U)
						{
							goto IL_A2;
						}
						goto IL_42;
					}
				}
				if (!false)
				{
					goto IL_35;
				}
				IL_A2:
				flag = (((uint)num & 0U) == 0U);
				if (flag)
				{
					if (((uint)index & 0U) == 0U)
					{
						goto IL_35;
					}
				}
				IL_CA:
				goto IL_68;
				IL_35:
				DockControl[] x9476096be9672d = this.x9476096be9672d38;
				num = x9476096be9672d.Length - 1;
				IL_42:
				for (;;)
				{
					DockControl control;
					if (num < 0)
					{
						if ((uint)index - (uint)num >= 0U)
						{
							break;
						}
					}
					else
					{
						control = x9476096be9672d[num];
					}
					layoutSystem.Controls.Insert(index, control);
					num--;
				}
				if (dockControl != null)
				{
					IL_29:
					layoutSystem.SelectedControl = dockControl;
				}
				return;
			}
			flag = (((uint)num & 0U) == 0U);
			if (flag)
			{
				goto IL_35;
			}
			goto IL_29;
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00013548 File Offset: 0x00012548
		internal override DockControl[] x9476096be9672d38
		{
			get
			{
				ArrayList arrayList = new ArrayList();
				this.xd78391e378ab076b(this, arrayList);
				return (DockControl[])arrayList.ToArray(typeof(DockControl));
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00013578 File Offset: 0x00012578
		private void xd78391e378ab076b(SplitLayoutSystem xb25822984a90695b, ArrayList x8da10969b0e2a75e)
		{
			IEnumerator enumerator = xb25822984a90695b.x820c504c9c557c92.GetEnumerator();
			try
			{
				for (;;)
				{
					LayoutSystemBase layoutSystemBase;
					if (!enumerator.MoveNext())
					{
						if (false)
						{
							goto IL_37;
						}
						goto IL_BF;
					}
					else
					{
						layoutSystemBase = (LayoutSystemBase)enumerator.Current;
						if (-2147483648 == 0)
						{
							break;
						}
						goto IL_C2;
					}
					IL_24:
					if (!(layoutSystemBase is ControlLayoutSystem))
					{
						if (false)
						{
							goto IL_B6;
						}
					}
					else
					{
						foreach (object obj in ((ControlLayoutSystem)layoutSystemBase).Controls)
						{
							DockControl value = (DockControl)obj;
							x8da10969b0e2a75e.Add(value);
						}
					}
					continue;
					IL_37:
					if (3 != 0)
					{
						goto IL_24;
					}
					IL_C4:
					this.xd78391e378ab076b((SplitLayoutSystem)layoutSystemBase, x8da10969b0e2a75e);
					continue;
					IL_D6:
					if (layoutSystemBase is SplitLayoutSystem)
					{
						goto IL_C4;
					}
					if (false)
					{
						goto IL_AA;
					}
					goto IL_B6;
					IL_C2:
					goto IL_D6;
					IL_BF:
					if (false)
					{
						goto IL_C2;
					}
					break;
					IL_AA:
					if (8 == 0)
					{
						goto IL_D6;
					}
					if (!false)
					{
						if (3 != 0)
						{
							goto IL_24;
						}
						goto IL_24;
					}
					IL_B6:
					if (false)
					{
						goto IL_AA;
					}
					if (false)
					{
						goto IL_BF;
					}
					goto IL_37;
				}
			}
			finally
			{
				IDisposable disposable2 = enumerator as IDisposable;
				if (2147483647 == 0 || disposable2 != null)
				{
					disposable2.Dispose();
				}
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000136D0 File Offset: 0x000126D0
		internal void x5a3264f7eba0fe4f(Point x13d4cb8d1bd20347, out LayoutSystemBase xc13a8191724b6d55, out LayoutSystemBase x5aa50bbadb0a1e6c)
		{
			int num = 0;
			IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
			int i;
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
					if (!(layoutSystemBase is ControlLayoutSystem))
					{
						goto IL_20A;
					}
					if (((ControlLayoutSystem)layoutSystemBase).Collapsed)
					{
						continue;
					}
					if ((uint)num - (uint)i > 4294967295U)
					{
						goto IL_148;
					}
					if (false)
					{
						goto IL_212;
					}
					goto IL_20A;
					IL_169:
					bool flag;
					while (x13d4cb8d1bd20347.X >= layoutSystemBase.Bounds.Right)
					{
						flag = ((uint)num - (uint)i < 0U);
						if (!flag && (uint)num + (uint)i <= 4294967295U)
						{
							goto IL_148;
						}
						if ((uint)i - (uint)num >= 0U)
						{
							goto IL_148;
						}
					}
					continue;
					IL_148:
					if (x13d4cb8d1bd20347.X > layoutSystemBase.Bounds.Right + 4)
					{
						continue;
					}
					if (!false)
					{
						goto IL_1D5;
					}
					goto IL_1E9;
					IL_1BA:
					if (this.SplitMode != Orientation.Vertical)
					{
						continue;
					}
					flag = ((uint)i > uint.MaxValue);
					if (flag)
					{
						goto IL_1D5;
					}
					goto IL_169;
					IL_20A:
					if (this.SplitMode == Orientation.Horizontal)
					{
						goto IL_212;
					}
					goto IL_1BA;
					IL_1D5:
					num = this.LayoutSystems.IndexOf(layoutSystemBase);
					break;
					IL_1E9:
					if (x13d4cb8d1bd20347.Y <= layoutSystemBase.Bounds.Bottom + 4)
					{
						goto IL_1D5;
					}
					goto IL_1BA;
					IL_212:
					if (x13d4cb8d1bd20347.Y >= layoutSystemBase.Bounds.Bottom)
					{
						goto IL_1E9;
					}
					if (false)
					{
						goto IL_169;
					}
					goto IL_1BA;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				while (disposable != null)
				{
					disposable.Dispose();
					bool flag = (uint)i + (uint)i > uint.MaxValue;
					if (!flag)
					{
						break;
					}
				}
			}
			xc13a8191724b6d55 = this.LayoutSystems[num];
			x5aa50bbadb0a1e6c = xc13a8191724b6d55;
			i = num + 1;
			IL_43:
			while (i < this.x820c504c9c557c92.Count)
			{
				for (;;)
				{
					if (!(this.x820c504c9c557c92[i] is ControlLayoutSystem))
					{
						bool flag = ((uint)i | 4U) == 0U;
						if (flag)
						{
							goto IL_56;
						}
						break;
					}
					IL_8E:
					while (((ControlLayoutSystem)this.x820c504c9c557c92[i]).Collapsed)
					{
						for (;;)
						{
							for (;;)
							{
								i++;
								if (((uint)num | 4U) != 0U)
								{
									goto IL_43;
								}
								bool flag = (uint)num > uint.MaxValue;
								if (flag)
								{
									goto Block_5;
								}
								if (false)
								{
									goto IL_A8;
								}
								if ((uint)i + (uint)i <= 4294967295U)
								{
								}
							}
						}
						IL_A8:
						Block_5:;
					}
					IL_56:
					if (2 != 0)
					{
						break;
					}
					if ((uint)i - (uint)i > 4294967295U)
					{
						goto IL_8E;
					}
				}
				x5aa50bbadb0a1e6c = this.LayoutSystems[i];
				return;
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000139C8 File Offset: 0x000129C8
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			foreach (object obj in this.x366d4cf7098f9c63)
			{
				Rectangle rectangle = (Rectangle)obj;
				if (false)
				{
					goto IL_F0;
				}
				IL_1B:
				if (!rectangle.Contains(e.X, e.Y))
				{
					continue;
				}
				IL_F0:
				LayoutSystemBase aboveLayout;
				LayoutSystemBase belowLayout;
				this.x5a3264f7eba0fe4f(new Point(e.X, e.Y), out aboveLayout, out belowLayout);
				if (2 != 0)
				{
					if (this.x372569d2ea29984e != null)
					{
						this.x372569d2ea29984e.Dispose();
						if (false)
						{
							goto IL_86;
						}
					}
					DockingHints dockingHints = (base.DockContainer.Manager != null) ? base.DockContainer.Manager.DockingHints : DockingHints.TranslucentFill;
					this.x372569d2ea29984e = new x8e80e1c8bce8caf7(base.DockContainer, this, aboveLayout, belowLayout, new Point(e.X, e.Y), dockingHints);
					if (false)
					{
						goto IL_1B;
					}
					this.x372569d2ea29984e.x868a32060451dd2e += this.xfae511fd7c4fb447;
					IL_86:
					this.x372569d2ea29984e.x67ecc0d0e7c9a202 += this.xc555e814c1720baf;
				}
				break;
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00013B28 File Offset: 0x00012B28
		protected internal override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			while (this.x531514c39973cbc6 == null)
			{
				if (!false || 15 != 0)
				{
					if (this.x372569d2ea29984e != null)
					{
						this.x372569d2ea29984e.Commit();
					}
					return;
				}
			}
			this.x531514c39973cbc6.Commit();
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00013B68 File Offset: 0x00012B68
		internal bool x090b65ef9b096e0b(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
		{
			foreach (object obj in this.x366d4cf7098f9c63)
			{
				while (((Rectangle)obj).Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
				{
					bool flag = true;
					if ((uint)x08db3aeabb253cb1 + (flag ? 1U : 0U) >= 0U)
					{
						bool flag2 = ((uint)x1e218ceaee1bb583 | 4U) == 0U;
						if (flag2)
						{
							goto IL_6A;
						}
						return flag;
					}
				}
				continue;
				IL_6A:
				break;
			}
			return false;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00013C18 File Offset: 0x00012C18
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			bool flag = false;
			for (;;)
			{
				if (-2 != 0)
				{
					if ((flag ? 1U : 0U) + (flag ? 1U : 0U) > 4294967295U)
					{
						return;
					}
					if (-2 == 0)
					{
						if (4 != 0)
						{
							break;
						}
					}
					else
					{
						if (e.Button != MouseButtons.Left)
						{
							goto IL_8D;
						}
						if (this.x531514c39973cbc6 == null)
						{
							goto IL_DB;
						}
						goto IL_E9;
					}
				}
				IL_11:
				base.OnMouseMove(e);
				bool flag2 = ((flag ? 1U : 0U) | 3U) == 0U;
				if (!flag2)
				{
					return;
				}
				if (-1 != 0)
				{
					continue;
				}
				flag2 = ((flag ? 1U : 0U) - (flag ? 1U : 0U) < 0U);
				if (flag2)
				{
					goto IL_75;
				}
				break;
				IL_8D:
				flag = this.x090b65ef9b096e0b(e.X, e.Y);
				if (!flag)
				{
					if (!false)
					{
						Cursor.Current = Cursors.Default;
						goto IL_11;
					}
				}
				else
				{
					if (this.xe36f4efbf268b3f1 == Orientation.Horizontal)
					{
						Cursor.Current = Cursors.HSplit;
						goto IL_14D;
					}
					Cursor.Current = Cursors.VSplit;
					goto IL_11;
				}
				IL_75:
				if ((flag ? 1U : 0U) - (flag ? 1U : 0U) <= 4294967295U)
				{
					goto IL_8D;
				}
				goto IL_DB;
				IL_34:
				goto IL_11;
				IL_14D:
				goto IL_34;
				IL_DB:
				if (this.x372569d2ea29984e == null)
				{
					goto IL_8D;
				}
				break;
			}
			this.x372569d2ea29984e.OnMouseMove(new Point(e.X, e.Y));
			return;
			IL_E9:
			this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000228 RID: 552 RVA: 0x00013D78 File Offset: 0x00012D78
		// (set) Token: 0x06000229 RID: 553 RVA: 0x00013D80 File Offset: 0x00012D80
		[Category("Layout")]
		[Description("Indicates whether this layout is split horizontally or vertically.")]
		[DefaultValue(typeof(Orientation), "Horizontal")]
		public Orientation SplitMode
		{
			get
			{
				return this.xe36f4efbf268b3f1;
			}
			set
			{
				this.xe36f4efbf268b3f1 = value;
				this.x3e0280cae730d1f2();
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00013D90 File Offset: 0x00012D90
		internal override bool x74e31f9641656e0b
		{
			get
			{
				IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
						if (3 == 0)
						{
							bool flag;
							if ((flag ? 1U : 0U) + (flag ? 1U : 0U) <= 4294967295U)
							{
							}
						}
						else if (layoutSystemBase.x74e31f9641656e0b)
						{
							continue;
						}
						return false;
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					do
					{
						for (;;)
						{
							if (disposable == null)
							{
								goto IL_73;
							}
							disposable.Dispose();
							if (2147483647 == 0)
							{
								goto IL_73;
							}
							IL_8B:
							if (-2147483648 != 0)
							{
								break;
							}
							continue;
							IL_73:
							bool flag;
							bool flag2 = (flag ? 1U : 0U) - (flag ? 1U : 0U) < 0U;
							if (flag2)
							{
								goto IL_8B;
							}
							goto IL_9B;
						}
					}
					while (255 == 0);
					IL_9B:;
				}
				return true;
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00013E58 File Offset: 0x00012E58
		internal override bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
		{
			IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
					if (!layoutSystemBase.xe302f2203dc14a18(xb9c2cfae130d9256))
					{
						return false;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (3 == 0 || disposable != null)
				{
					disposable.Dispose();
				}
			}
			return true;
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600022C RID: 556 RVA: 0x00013EF4 File Offset: 0x00012EF4
		internal override bool x2f61709eaa5ebf76
		{
			get
			{
				using (IEnumerator enumerator = this.LayoutSystems.GetEnumerator())
				{
					for (;;)
					{
						LayoutSystemBase layoutSystemBase;
						if (!enumerator.MoveNext())
						{
							if (!false)
							{
								break;
							}
						}
						else
						{
							layoutSystemBase = (LayoutSystemBase)enumerator.Current;
							bool flag2;
							bool flag = (flag2 ? 1U : 0U) - (flag2 ? 1U : 0U) < 0U;
							if (flag)
							{
								goto IL_49;
							}
						}
						if (!layoutSystemBase.x2f61709eaa5ebf76)
						{
							goto IL_49;
						}
					}
					return true;
					IL_49:
					return false;
				}
				return true;
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00013F8C File Offset: 0x00012F8C
		internal void x8e9e04a70e31e166()
		{
			if (base.DockContainer != null)
			{
				base.DockContainer.x7e9646eed248ed11();
			}
			if (this.x7e9646eed248ed11 != null)
			{
				this.x7e9646eed248ed11(this, EventArgs.Empty);
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00013FBC File Offset: 0x00012FBC
		internal void x3e0280cae730d1f2()
		{
			if (base.DockContainer != null)
			{
				if (-2147483648 != 0)
				{
				}
				base.DockContainer.xec9697acef66c1bc(this, base.Bounds);
			}
			if (base.DockContainer != null)
			{
				base.DockContainer.Invalidate(base.Bounds);
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00013FFC File Offset: 0x00012FFC
		internal override void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
		{
			base.x56e964269d48cfcc(x0467b00af7810f0c);
			foreach (object obj in this.LayoutSystems)
			{
				LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
				layoutSystemBase.x56e964269d48cfcc(x0467b00af7810f0c);
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000230 RID: 560 RVA: 0x00014068 File Offset: 0x00013068
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public SplitLayoutSystem.LayoutSystemBaseCollection LayoutSystems
		{
			get
			{
				return this.x820c504c9c557c92;
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00014070 File Offset: 0x00013070
		private LayoutSystemBase[] x10878bfc002a3aaf(out int x10f4d88af727adbc)
		{
			x10f4d88af727adbc = 0;
			LayoutSystemBase[] array = new LayoutSystemBase[this.LayoutSystems.Count];
			using (IEnumerator enumerator = this.LayoutSystems.GetEnumerator())
			{
				IL_23:
				while (enumerator.MoveNext())
				{
					LayoutSystemBase layoutSystemBase;
					for (;;)
					{
						layoutSystemBase = (LayoutSystemBase)enumerator.Current;
						ControlLayoutSystem controlLayoutSystem;
						if (layoutSystemBase is ControlLayoutSystem)
						{
							controlLayoutSystem = (ControlLayoutSystem)layoutSystemBase;
							goto IL_158;
						}
						int num;
						int num2;
						if ((uint)num - (uint)num2 >= 0U && ((uint)num2 | 15U) != 0U)
						{
						}
						IL_A2:
						bool flag;
						while (!(layoutSystemBase is SplitLayoutSystem))
						{
							if ((uint)num2 < 0U)
							{
								goto IL_34;
							}
							if (((uint)num & 0U) == 0U)
							{
								goto IL_EA;
							}
							flag = ((uint)num - (uint)num2 < 0U);
							if (flag)
							{
								if (((uint)num | 4294967295U) == 0U)
								{
									goto IL_158;
								}
							}
						}
						goto IL_CE;
						IL_158:
						if (controlLayoutSystem.Collapsed)
						{
							goto IL_BC;
						}
						IL_136:
						LayoutSystemBase[] array2 = array;
						num = x10f4d88af727adbc++;
						array2[num] = layoutSystemBase;
						flag = ((uint)num > uint.MaxValue);
						if (flag)
						{
							if ((uint)num + (uint)num <= 4294967295U)
							{
								continue;
							}
						}
						else
						{
							if (false)
							{
								goto IL_1AD;
							}
							goto IL_EF;
						}
						IL_BC:
						if (!base.IsInContainer)
						{
							if (!false)
							{
								goto Block_4;
							}
						}
						else
						{
							if (!base.DockContainer.x0c2484ccd29b8358)
							{
								goto IL_136;
							}
							goto IL_23;
						}
						IL_CC:
						goto IL_A2;
						IL_1AD:
						goto IL_CC;
					}
					IL_34:
					SplitLayoutSystem splitLayoutSystem;
					if (splitLayoutSystem.x7ca4fdcb31f9824a())
					{
						LayoutSystemBase[] array3 = array;
						int num2 = x10f4d88af727adbc++;
						array3[num2] = layoutSystemBase;
					}
					Block_4:
					IL_EA:
					IL_EF:
					continue;
					IL_CE:
					splitLayoutSystem = (SplitLayoutSystem)layoutSystemBase;
					goto IL_34;
				}
			}
			return array;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0001426C File Offset: 0x0001326C
		protected internal override void Layout(RendererBase renderer, Graphics graphics, Rectangle bounds, bool floating)
		{
			base.Layout(renderer, graphics, bounds, floating);
			int num;
			bool flag = (uint)num - (uint)num < 0U;
			int num2;
			LayoutSystemBase[] array;
			int num3;
			int i;
			if (!flag)
			{
				array = this.x10878bfc002a3aaf(out num2);
				if (num2 == 0)
				{
					return;
				}
				do
				{
					if (num2 > 1)
					{
						floating = false;
					}
					num3 = ((this.xe36f4efbf268b3f1 == Orientation.Horizontal) ? (bounds.Height - (num2 - 1) * 4) : (bounds.Width - (num2 - 1) * 4));
					flag = (((uint)i | 2147483648U) == 0U);
				}
				while (flag);
			}
			float num4 = 0f;
			int j = 0;
			float num5;
			SizeF[] array2;
			if ((uint)num5 - (floating ? 1U : 0U) >= 0U)
			{
				while (j < num2)
				{
					num4 += ((this.xe36f4efbf268b3f1 == Orientation.Horizontal) ? array[j].WorkingSize.Height : array[j].WorkingSize.Width);
					if ((uint)num >= 0U)
					{
						j++;
					}
				}
				this.x366d4cf7098f9c63.Clear();
				flag = ((uint)num4 > uint.MaxValue);
				if (!flag && num3 <= 0)
				{
					if ((uint)num5 <= 4294967295U)
					{
						return;
					}
					return;
				}
				else
				{
					array2 = new SizeF[num2];
					i = 0;
				}
			}
			while (i < num2)
			{
				array2[i] = array[i].WorkingSize;
				i++;
			}
			int num6;
			if ((float)num3 != num4)
			{
				num5 = (float)num3 - num4;
				num6 = 0;
				goto IL_353;
			}
			goto IL_22C;
			IL_4A:
			return;
			IL_C9:
			int num7;
			int num8;
			int num9;
			array[num7].Layout(renderer, graphics, new Rectangle(num8, bounds.Y, num9, bounds.Height), floating);
			IL_ED:
			num8 += num9 + 4;
			num7++;
			IL_FC:
			if (num7 >= num2)
			{
				goto IL_1DC;
			}
			num9 = ((this.xe36f4efbf268b3f1 != Orientation.Horizontal) ? Convert.ToInt32(array2[num7].Width) : Convert.ToInt32(array2[num7].Height));
			num9 = Math.Max(num9, 4);
			if (this.xe36f4efbf268b3f1 == Orientation.Horizontal)
			{
				flag = (((uint)num & 0U) == 0U);
				if (flag)
				{
					if (((uint)num6 | 3U) == 0U)
					{
						goto IL_249;
					}
					if ((uint)i - (uint)num6 < 0U)
					{
						goto IL_240;
					}
					if (num7 == num2 - 1)
					{
						flag = ((uint)num6 > uint.MaxValue);
						if (flag)
						{
							goto IL_1DC;
						}
						num9 = bounds.Bottom - num8;
					}
					array[num7].Layout(renderer, graphics, new Rectangle(bounds.X, num8, bounds.Width, num9), floating);
					if ((uint)i + (uint)num9 >= 0U)
					{
						goto IL_ED;
					}
					goto IL_3F0;
				}
			}
			else
			{
				if (num7 == num2 - 1)
				{
					num9 = bounds.Right - num8;
					goto IL_C9;
				}
				goto IL_C9;
			}
			IL_2B:
			this.x366d4cf7098f9c63.Add(bounds);
			num++;
			IL_43:
			if (num >= num2 - 1)
			{
				goto IL_4A;
			}
			bounds = array[num].Bounds;
			if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
			{
				bounds.Offset(bounds.Width, 0);
				bounds.Width = 4;
			}
			else
			{
				bounds.Offset(0, bounds.Height);
				bounds.Height = 4;
			}
			goto IL_2B;
			IL_1DC:
			num = 0;
			goto IL_43;
			IL_22C:
			if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
			{
				goto IL_249;
			}
			int num10 = bounds.Y;
			IL_23B:
			num8 = num10;
			num7 = 0;
			IL_240:
			goto IL_FC;
			IL_249:
			num10 = bounds.X;
			goto IL_23B;
			IL_353:
			float num11;
			if (num6 < num2)
			{
				num11 = ((this.xe36f4efbf268b3f1 != Orientation.Horizontal) ? array2[num6].Width : array2[num6].Height);
				goto IL_3F0;
			}
			num4 = 0f;
			flag = ((uint)num9 > uint.MaxValue);
			if (!flag)
			{
				goto IL_3D6;
			}
			IL_38D:
			if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
			{
				flag = ((uint)num3 < 0U);
				if (flag)
				{
					goto IL_3BB;
				}
				array2[num6].Width = num11;
			}
			else
			{
				array2[num6].Height = num11;
			}
			num6++;
			IL_3BB:
			int k;
			flag = ((uint)k + (uint)num8 < 0U);
			if (!flag)
			{
				if ((uint)num7 - (uint)k >= 0U)
				{
					goto IL_353;
				}
				goto IL_4A;
			}
			IL_3D6:
			k = 0;
			while (k < num2)
			{
				num4 += ((this.xe36f4efbf268b3f1 == Orientation.Horizontal) ? array2[k].Height : array2[k].Width);
				k++;
				if ((uint)num9 + (uint)num7 <= 4294967295U)
				{
					flag = ((uint)k - (uint)num7 < 0U);
					if (flag)
					{
						IL_421:
						flag = ((uint)num6 + (uint)i > uint.MaxValue);
						if (flag)
						{
							goto IL_546;
						}
						flag = (((uint)num2 & 0U) == 0U);
						if (!flag)
						{
							break;
						}
						if (false || this.xe36f4efbf268b3f1 == Orientation.Horizontal)
						{
							SizeF[] array3 = array2;
							int num12 = 0;
							array3[num12].Height = array3[num12].Height + num5;
							goto IL_22C;
						}
					}
					else if ((uint)num5 - (uint)num6 >= 0U)
					{
						continue;
					}
					SizeF[] array4 = array2;
					int num13 = 0;
					array4[num13].Width = array4[num13].Width + num5;
					IL_546:
					goto IL_22C;
				}
				goto IL_C9;
			}
			num5 = (float)num3 - num4;
			goto IL_421;
			IL_3F0:
			num11 += num5 * (num11 / num4);
			goto IL_38D;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00014828 File Offset: 0x00013828
		internal override void x84b6f3c22477dacb(RendererBase x38870620fd380a6b, Graphics x41347a961b838962, Font x26094932cf7a9139)
		{
			if (base.DockContainer == null)
			{
				return;
			}
			Control control;
			if (base.DockContainer.Manager == null)
			{
				if (-1 == 0)
				{
					return;
				}
				control = null;
			}
			else
			{
				control = base.DockContainer.Manager.DockSystemContainer;
			}
			Control container = control;
			IEnumerator enumerator = this.x366d4cf7098f9c63.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Rectangle bounds = (Rectangle)obj;
					x38870620fd380a6b.DrawSplitter(container, base.DockContainer, x41347a961b838962, bounds, this.xe36f4efbf268b3f1);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (15 == 0 || disposable != null)
				{
					disposable.Dispose();
				}
			}
			IEnumerator enumerator2 = this.LayoutSystems.GetEnumerator();
			try
			{
				for (;;)
				{
					LayoutSystemBase layoutSystemBase;
					if (!enumerator2.MoveNext())
					{
						if (15 != 0)
						{
							if (8 == 0)
							{
								goto IL_BD;
							}
							if (false)
							{
								goto IL_BD;
							}
							if (false)
							{
								goto IL_AD;
							}
						}
						if (false)
						{
							goto IL_10A;
						}
						if (!true)
						{
							goto IL_13C;
						}
						break;
					}
					else
					{
						layoutSystemBase = (LayoutSystemBase)enumerator2.Current;
						if (-2 == 0)
						{
							goto IL_AD;
						}
						if (!(layoutSystemBase is ControlLayoutSystem))
						{
							goto IL_12C;
						}
						if (255 == 0)
						{
							goto IL_12C;
						}
						goto IL_AD;
					}
					IL_BD:
					if (base.DockContainer.x0c2484ccd29b8358)
					{
						continue;
					}
					goto IL_13C;
					IL_10A:
					x41347a961b838962.SetClip(layoutSystemBase.Bounds);
					layoutSystemBase.x84b6f3c22477dacb(x38870620fd380a6b, x41347a961b838962, x26094932cf7a9139);
					Region clip;
					x41347a961b838962.Clip = clip;
					if (4 != 0 && !false)
					{
						continue;
					}
					if (4 == 0)
					{
						goto IL_AD;
					}
					goto IL_BD;
					IL_12C:
					clip = x41347a961b838962.Clip;
					goto IL_10A;
					IL_AD:
					if (((ControlLayoutSystem)layoutSystemBase).Collapsed)
					{
						goto IL_BD;
					}
					IL_13C:
					goto IL_12C;
				}
			}
			finally
			{
				IDisposable disposable2 = enumerator2 as IDisposable;
				if (false || disposable2 != null)
				{
					disposable2.Dispose();
				}
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x000149E8 File Offset: 0x000139E8
		private void x367ada130c39f434()
		{
			this.x372569d2ea29984e.x868a32060451dd2e -= this.xfae511fd7c4fb447;
			this.x372569d2ea29984e.x67ecc0d0e7c9a202 -= this.xc555e814c1720baf;
			this.x372569d2ea29984e = null;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00014A20 File Offset: 0x00013A20
		private void xfae511fd7c4fb447(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x367ada130c39f434();
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00014A28 File Offset: 0x00013A28
		private void xc555e814c1720baf(LayoutSystemBase xc13a8191724b6d55, LayoutSystemBase x5aa50bbadb0a1e6c, float x5c2440c931f8d932, float x4afa341b2323a009)
		{
			this.x367ada130c39f434();
			if (2147483647 == 0)
			{
				goto IL_9F;
			}
			goto IL_112;
			IL_22:
			return;
			IL_48:
			SizeF workingSize;
			workingSize.Width = x4afa341b2323a009;
			if ((uint)x4afa341b2323a009 - (uint)x5c2440c931f8d932 < 0U)
			{
				goto IL_9F;
			}
			IL_69:
			SizeF workingSize2;
			xc13a8191724b6d55.WorkingSize = workingSize2;
			bool flag = (uint)x4afa341b2323a009 + (uint)x5c2440c931f8d932 < 0U;
			if (!flag)
			{
				flag = ((uint)x5c2440c931f8d932 < 0U);
				if (flag)
				{
					goto IL_FA;
				}
				x5aa50bbadb0a1e6c.WorkingSize = workingSize;
				this.x3e0280cae730d1f2();
				goto IL_22;
			}
			IL_9F:
			if ((uint)x4afa341b2323a009 - (uint)x5c2440c931f8d932 > 4294967295U)
			{
				goto IL_48;
			}
			IL_BA:
			workingSize2 = xc13a8191724b6d55.WorkingSize;
			workingSize = x5aa50bbadb0a1e6c.WorkingSize;
			if (((uint)x4afa341b2323a009 | 4294967294U) == 0U)
			{
				goto IL_22;
			}
			if (this.SplitMode != Orientation.Horizontal)
			{
				workingSize2.Width = x5c2440c931f8d932;
				goto IL_48;
			}
			workingSize2.Height = x5c2440c931f8d932;
			workingSize.Height = x4afa341b2323a009;
			goto IL_69;
			IL_FA:
			flag = ((uint)x5c2440c931f8d932 + (uint)x5c2440c931f8d932 > uint.MaxValue);
			if (!flag)
			{
				return;
			}
			IL_112:
			if (x5c2440c931f8d932 > 0f)
			{
				if (x4afa341b2323a009 <= 0f)
				{
					goto IL_FA;
				}
				goto IL_BA;
			}
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00014B54 File Offset: 0x00013B54
		internal bool x7ca4fdcb31f9824a()
		{
			using (IEnumerator enumerator = this.x820c504c9c557c92.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					bool flag2;
					for (;;)
					{
						LayoutSystemBase layoutSystemBase = (LayoutSystemBase)enumerator.Current;
						if (!(layoutSystemBase is ControlLayoutSystem))
						{
							goto IL_64;
						}
						ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)layoutSystemBase;
						bool flag = (flag2 ? 1U : 0U) > uint.MaxValue;
						if (!flag)
						{
							if (!controlLayoutSystem.Collapsed)
							{
								goto IL_A9;
							}
						}
						if (base.IsInContainer)
						{
							goto IL_B1;
						}
						IL_FB:
						if ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) > 4294967295U)
						{
							continue;
						}
						if ((flag2 ? 1U : 0U) >= 0U)
						{
							break;
						}
						IL_64:
						if (!((SplitLayoutSystem)layoutSystemBase).x7ca4fdcb31f9824a())
						{
							goto Block_6;
						}
						flag2 = true;
						if (-1 == 0)
						{
							goto IL_FB;
						}
						goto IL_78;
					}
					if ((flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) <= 4294967295U)
					{
						continue;
					}
					continue;
					IL_78:
					return flag2;
					Block_6:
					continue;
					IL_B1:
					if (base.DockContainer.x0c2484ccd29b8358)
					{
						continue;
					}
					IL_A9:
					return true;
				}
			}
			return false;
		}

		// Token: 0x0400009B RID: 155
		internal const int x51b0f429bd564626 = 4;

		// Token: 0x0400009C RID: 156
		private SplitLayoutSystem.LayoutSystemBaseCollection x820c504c9c557c92;

		// Token: 0x0400009D RID: 157
		private Orientation xe36f4efbf268b3f1;

		// Token: 0x0400009E RID: 158
		private ArrayList x366d4cf7098f9c63;

		// Token: 0x0400009F RID: 159
		private x8e80e1c8bce8caf7 x372569d2ea29984e;

		// Token: 0x02000013 RID: 19
		public class LayoutSystemBaseCollection : CollectionBase
		{
			// Token: 0x06000238 RID: 568 RVA: 0x00014C98 File Offset: 0x00013C98
			internal LayoutSystemBaseCollection(SplitLayoutSystem parent)
			{
				this.xb6a159a84cb992d6 = parent;
			}

			// Token: 0x06000239 RID: 569 RVA: 0x00014CA8 File Offset: 0x00013CA8
			private void x8e9e04a70e31e166()
			{
				this.xb6a159a84cb992d6.x8e9e04a70e31e166();
			}

			// Token: 0x0600023A RID: 570 RVA: 0x00014CB8 File Offset: 0x00013CB8
			protected override void OnClear()
			{
				base.OnClear();
				IEnumerator enumerator = base.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
						layoutSystemBase.xb6a159a84cb992d6 = null;
						layoutSystemBase.x56e964269d48cfcc(null);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (2 == 0 || disposable != null)
					{
						disposable.Dispose();
					}
				}
			}

			// Token: 0x0600023B RID: 571 RVA: 0x00014D30 File Offset: 0x00013D30
			protected override void OnClearComplete()
			{
				base.OnClearComplete();
				if (!false)
				{
					goto IL_23;
				}
				if (-2 == 0)
				{
					goto IL_23;
				}
				IL_10:
				if (-2147483648 != 0)
				{
					return;
				}
				IL_23:
				if (!this.xd7a3953bce504b63)
				{
					this.x8e9e04a70e31e166();
					goto IL_10;
				}
			}

			// Token: 0x0600023C RID: 572 RVA: 0x00014D60 File Offset: 0x00013D60
			protected override void OnInsertComplete(int index, object value)
			{
				base.OnInsertComplete(index, value);
				if (255 != 0)
				{
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)value;
					layoutSystemBase.xb6a159a84cb992d6 = this.xb6a159a84cb992d6;
					layoutSystemBase.x56e964269d48cfcc(this.xb6a159a84cb992d6.DockContainer);
					if (!this.xd7a3953bce504b63)
					{
						this.x8e9e04a70e31e166();
					}
				}
			}

			// Token: 0x0600023D RID: 573 RVA: 0x00014DB0 File Offset: 0x00013DB0
			protected override void OnRemoveComplete(int index, object value)
			{
				base.OnRemoveComplete(index, value);
				((LayoutSystemBase)value).xb6a159a84cb992d6 = null;
				((LayoutSystemBase)value).x56e964269d48cfcc(null);
				int num;
				bool flag = (uint)num < 0U;
				if (!flag)
				{
					if (this.xd7a3953bce504b63)
					{
						return;
					}
				}
				if (base.Count > 1)
				{
					if (false)
					{
						return;
					}
				}
				else
				{
					while (this.xb6a159a84cb992d6.xb6a159a84cb992d6 != null)
					{
						SplitLayoutSystem splitLayoutSystem = this.xb6a159a84cb992d6.xb6a159a84cb992d6;
						flag = ((uint)num - (uint)num < 0U);
						if (!flag && base.Count != 1)
						{
							flag = ((uint)index - (uint)index > uint.MaxValue);
							if (flag)
							{
								goto IL_CB;
							}
							if ((uint)num - (uint)index >= 0U)
							{
								goto IL_CB;
							}
							continue;
							IL_CB:
							if (((uint)index & 0U) != 0U)
							{
								flag = ((uint)index + (uint)num < 0U);
								if (flag)
								{
									if (15 == 0)
									{
										goto IL_104;
									}
									continue;
								}
							}
							else if (base.Count != 0)
							{
								return;
							}
							splitLayoutSystem.LayoutSystems.Remove(this.xb6a159a84cb992d6);
							return;
						}
						LayoutSystemBase layoutSystem = this[0];
						this.xd7a3953bce504b63 = true;
						IL_104:
						this.Remove(layoutSystem);
						this.xd7a3953bce504b63 = false;
						splitLayoutSystem.LayoutSystems.xd7a3953bce504b63 = true;
						num = splitLayoutSystem.LayoutSystems.IndexOf(this.xb6a159a84cb992d6);
						splitLayoutSystem.LayoutSystems.Remove(this.xb6a159a84cb992d6);
						splitLayoutSystem.LayoutSystems.Insert(num, layoutSystem);
						splitLayoutSystem.LayoutSystems.xd7a3953bce504b63 = false;
						splitLayoutSystem.x8e9e04a70e31e166();
						return;
					}
				}
				this.x8e9e04a70e31e166();
			}

			// Token: 0x0600023E RID: 574 RVA: 0x00014F84 File Offset: 0x00013F84
			public void AddRange(LayoutSystemBase[] layoutSystems)
			{
				this.xd7a3953bce504b63 = true;
				foreach (LayoutSystemBase layoutSystem in layoutSystems)
				{
					this.Add(layoutSystem);
				}
				this.xd7a3953bce504b63 = false;
				this.x8e9e04a70e31e166();
			}

			// Token: 0x0600023F RID: 575 RVA: 0x00014FC8 File Offset: 0x00013FC8
			public int Add(LayoutSystemBase layoutSystem)
			{
				int count = base.Count;
				this.Insert(count, layoutSystem);
				return count;
			}

			// Token: 0x06000240 RID: 576 RVA: 0x00014FE8 File Offset: 0x00013FE8
			public void Insert(int index, LayoutSystemBase layoutSystem)
			{
				if (layoutSystem.xb6a159a84cb992d6 != null)
				{
					throw new ArgumentException("Layout system already has a parent. You must first remove it from its parent.");
				}
				base.List.Insert(index, layoutSystem);
			}

			// Token: 0x1700008E RID: 142
			public LayoutSystemBase this[int index]
			{
				get
				{
					return (LayoutSystemBase)base.List[index];
				}
			}

			// Token: 0x06000242 RID: 578 RVA: 0x00015020 File Offset: 0x00014020
			public void Remove(LayoutSystemBase layoutSystem)
			{
				base.List.Remove(layoutSystem);
			}

			// Token: 0x06000243 RID: 579 RVA: 0x00015030 File Offset: 0x00014030
			public bool Contains(LayoutSystemBase layoutSystem)
			{
				return base.List.Contains(layoutSystem);
			}

			// Token: 0x06000244 RID: 580 RVA: 0x00015040 File Offset: 0x00014040
			public int IndexOf(LayoutSystemBase layoutSystem)
			{
				return base.List.IndexOf(layoutSystem);
			}

			// Token: 0x06000245 RID: 581 RVA: 0x00015050 File Offset: 0x00014050
			public void CopyTo(LayoutSystemBase[] array, int index)
			{
				base.List.CopyTo(array, index);
			}

			// Token: 0x040000A1 RID: 161
			private SplitLayoutSystem xb6a159a84cb992d6;

			// Token: 0x040000A2 RID: 162
			internal bool xd7a3953bce504b63;
		}
	}
}

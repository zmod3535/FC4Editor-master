using System;
using System.Collections;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x0200003A RID: 58
	public sealed class LayoutUtilities
	{
		// Token: 0x06000466 RID: 1126 RVA: 0x00022640 File Offset: 0x00021640
		private LayoutUtilities()
		{
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00022648 File Offset: 0x00021648
		internal static void x3a04ba0cdf69aff2()
		{
			LayoutUtilities.x9b1e2b1c391ceb59++;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00022658 File Offset: 0x00021658
		internal static void x861aa05d0acfeb39()
		{
			if (LayoutUtilities.x9b1e2b1c391ceb59 > 0)
			{
				LayoutUtilities.x9b1e2b1c391ceb59--;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00022670 File Offset: 0x00021670
		internal static bool x12627d27d864cd19
		{
			get
			{
				return LayoutUtilities.x9b1e2b1c391ceb59 > 0;
			}
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0002267C File Offset: 0x0002167C
		internal static DockSituation x8d287cc6f0a2f529(DockContainer xd3311d815ca25f02)
		{
			if (xd3311d815ca25f02 != null)
			{
				if (xd3311d815ca25f02.IsFloating)
				{
					if (!false)
					{
						return DockSituation.Floating;
					}
				}
				else
				{
					if (xd3311d815ca25f02.Dock == DockStyle.Fill)
					{
						return DockSituation.Document;
					}
					if (-2 != 0)
					{
						return DockSituation.Docked;
					}
				}
			}
			return DockSituation.None;
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x000226A8 File Offset: 0x000216A8
		internal static ControlLayoutSystem[] x1494f515233a1246(DockContainer xd3311d815ca25f02)
		{
			ArrayList arrayList = new ArrayList();
			IEnumerator enumerator = xd3311d815ca25f02.x83627743ea4ce5a2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
					if (layoutSystemBase is ControlLayoutSystem)
					{
						arrayList.Add(layoutSystemBase);
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (false || disposable != null)
				{
					disposable.Dispose();
				}
			}
			return (ControlLayoutSystem[])arrayList.ToArray(typeof(ControlLayoutSystem));
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00022738 File Offset: 0x00021738
		internal static ControlLayoutSystem xba5fd484c0e6478b(SandDockManager x91f347c6e97f1846, DockSituation xd39eba9a9a1b028e, x129cb2a2bdfd0ab2 xfffbdea061bfa120)
		{
			DockContainer[] dockContainers;
			int num;
			ControlLayoutSystem[] array;
			int num2;
			DockContainer[] dockContainers2;
			switch (xd39eba9a9a1b028e)
			{
			case DockSituation.Docked:
				dockContainers = x91f347c6e97f1846.GetDockContainers();
				num = 0;
				goto IL_177;
			case DockSituation.Document:
				if (x91f347c6e97f1846.DocumentContainer == null)
				{
					goto IL_1D;
				}
				array = LayoutUtilities.x1494f515233a1246(x91f347c6e97f1846.DocumentContainer);
				if (false)
				{
					goto IL_197;
				}
				num2 = 0;
				goto IL_EE;
			case DockSituation.Floating:
				dockContainers2 = x91f347c6e97f1846.GetDockContainers();
				goto IL_265;
			}
			throw new InvalidOperationException();
			IL_1D:
			return null;
			IL_1F:
			int num3;
			if (num3 >= dockContainers2.Length)
			{
				goto IL_1D;
			}
			DockContainer xd3311d815ca25f = dockContainers2[num3];
			bool flag = (uint)num2 > uint.MaxValue;
			if (flag)
			{
				ControlLayoutSystem result;
				return result;
			}
			ControlLayoutSystem[] array2;
			int num4;
			if (LayoutUtilities.x8d287cc6f0a2f529(xd3311d815ca25f) == xd39eba9a9a1b028e)
			{
				array2 = LayoutUtilities.x1494f515233a1246(xd3311d815ca25f);
				num4 = 0;
				goto IL_86;
			}
			IL_2C:
			num3++;
			goto IL_1F;
			IL_6C:
			ControlLayoutSystem controlLayoutSystem;
			if (controlLayoutSystem.x0217cda8370c1f17 == xfffbdea061bfa120.x703937d70a13725c)
			{
				return controlLayoutSystem;
			}
			IL_80:
			num4++;
			IL_86:
			if (num4 >= array2.Length)
			{
				goto IL_2C;
			}
			controlLayoutSystem = array2[num4];
			goto IL_6C;
			IL_EE:
			ControlLayoutSystem controlLayoutSystem2;
			if (num2 < array.Length)
			{
				controlLayoutSystem2 = array[num2];
				if (-2 == 0)
				{
					goto IL_171;
				}
				goto IL_197;
			}
			IL_F6:
			goto IL_1D;
			IL_171:
			num++;
			IL_177:
			if (num >= dockContainers.Length)
			{
				goto IL_1D;
			}
			DockContainer xd3311d815ca25f2 = dockContainers[num];
			if (LayoutUtilities.x8d287cc6f0a2f529(xd3311d815ca25f2) != xd39eba9a9a1b028e)
			{
				goto IL_171;
			}
			ControlLayoutSystem[] array3;
			int num5;
			if ((uint)num3 <= 4294967295U)
			{
				array3 = LayoutUtilities.x1494f515233a1246(xd3311d815ca25f2);
				num5 = 0;
				if (!false)
				{
					goto IL_1B4;
				}
				flag = ((uint)num + (uint)num4 < 0U);
				if (flag)
				{
					goto IL_6C;
				}
				goto IL_80;
			}
			IL_19B:
			ControlLayoutSystem controlLayoutSystem3;
			if (controlLayoutSystem3.x0217cda8370c1f17 == xfffbdea061bfa120.x703937d70a13725c)
			{
				return controlLayoutSystem3;
			}
			num5++;
			IL_1B4:
			if (num5 < array3.Length)
			{
				controlLayoutSystem3 = array3[num5];
				goto IL_19B;
			}
			flag = (((uint)num4 | 255U) == 0U);
			if (!flag)
			{
				goto IL_171;
			}
			IL_197:
			if (!(controlLayoutSystem2.x0217cda8370c1f17 == xfffbdea061bfa120.x703937d70a13725c))
			{
				num2++;
				goto IL_EE;
			}
			if ((uint)num + (uint)num < 0U)
			{
				goto IL_F6;
			}
			flag = (((uint)num2 | uint.MaxValue) == 0U);
			if (!flag)
			{
				return controlLayoutSystem2;
			}
			IL_265:
			num3 = 0;
			goto IL_1F;
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x000229DC File Offset: 0x000219DC
		internal static int[] x27f6597db2aeb7d7(ControlLayoutSystem x5d3b2a2c534d6d79)
		{
			ArrayList arrayList = new ArrayList();
			do
			{
				for (LayoutSystemBase layoutSystemBase = x5d3b2a2c534d6d79; layoutSystemBase != null; layoutSystemBase = layoutSystemBase.Parent)
				{
					if (layoutSystemBase.Parent != null)
					{
						arrayList.Add(layoutSystemBase.Parent.LayoutSystems.IndexOf(layoutSystemBase));
						if (2147483647 == 0)
						{
							goto IL_55;
						}
					}
				}
			}
			while (15 == 0);
			arrayList.Reverse();
			IL_55:
			return (int[])arrayList.ToArray(typeof(int));
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x00022A54 File Offset: 0x00021A54
		internal static DockStyle xf8330a3964a419ba(ContainerDockLocation x9c911703d455884e)
		{
			if (true)
			{
				switch (x9c911703d455884e)
				{
				case ContainerDockLocation.Left:
					return DockStyle.Left;
				case ContainerDockLocation.Right:
					return DockStyle.Right;
				case ContainerDockLocation.Top:
					return DockStyle.Top;
				case ContainerDockLocation.Bottom:
					return DockStyle.Bottom;
				case ContainerDockLocation.Center:
					break;
				default:
					if (15 != 0)
					{
					}
					break;
				}
				return DockStyle.Fill;
			}
			return DockStyle.Right;
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00022A98 File Offset: 0x00021A98
		internal static ContainerDockLocation x3650f3b579b2b4d2(DockStyle xca9af438b5818619)
		{
			switch (xca9af438b5818619)
			{
			case DockStyle.Top:
				return ContainerDockLocation.Top;
			case DockStyle.Bottom:
				break;
			case DockStyle.Left:
				return ContainerDockLocation.Left;
			case DockStyle.Right:
				return ContainerDockLocation.Right;
			case DockStyle.Fill:
				return ContainerDockLocation.Center;
			default:
				if (4 != 0)
				{
					return ContainerDockLocation.Center;
				}
				break;
			}
			return ContainerDockLocation.Bottom;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00022AD8 File Offset: 0x00021AD8
		public static ControlLayoutSystem FindControlLayoutSystem(DockContainer container)
		{
			foreach (object obj in container.x83627743ea4ce5a2)
			{
				LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
				if (layoutSystemBase is ControlLayoutSystem)
				{
					return (ControlLayoutSystem)layoutSystemBase;
				}
			}
			return null;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x00022B60 File Offset: 0x00021B60
		internal static void xa7513d57b4844d46(Control x43bec302f92080b9)
		{
			if (x43bec302f92080b9.Parent != null)
			{
				if (x43bec302f92080b9.ContainsFocus)
				{
					x43bec302f92080b9.Parent.Focus();
				}
				while (x43bec302f92080b9 is DockControl)
				{
					((DockControl)x43bec302f92080b9).xadad18dc04073a00 = true;
					if (!false)
					{
						IL_EA:
						break;
					}
					if (false)
					{
						return;
					}
				}
				try
				{
					IContainerControl containerControl = x43bec302f92080b9.Parent.GetContainerControl();
					if (-2147483648 == 0)
					{
						goto IL_91;
					}
					if (containerControl == null)
					{
						goto IL_68;
					}
					DockContainer dockContainer = containerControl as DockContainer;
					if (dockContainer == null)
					{
						goto IL_58;
					}
					if (-2 != 0)
					{
						if (dockContainer.x5b1f9c5a8906ff95)
						{
							goto IL_58;
						}
						if (dockContainer.Manager != null)
						{
							goto IL_91;
						}
						goto IL_58;
					}
					else if (false)
					{
						goto IL_7E;
					}
					IL_39:
					if (dockContainer.Manager.OwnerForm == null)
					{
						goto IL_7E;
					}
					IL_46:
					if (dockContainer.Manager.OwnerForm.IsMdiContainer)
					{
						LayoutUtilities.xf96eb78473d85a37(dockContainer, dockContainer.LayoutSystem);
						goto IL_68;
					}
					IL_58:
					if (containerControl.ActiveControl == x43bec302f92080b9)
					{
						containerControl.ActiveControl = null;
					}
					IL_68:
					x43bec302f92080b9.Parent.Controls.Remove(x43bec302f92080b9);
					if (2 == 0)
					{
						goto IL_91;
					}
					return;
					IL_7E:
					goto IL_58;
					IL_91:
					if (255 == 0)
					{
						goto IL_46;
					}
					goto IL_39;
				}
				finally
				{
					if (x43bec302f92080b9 is DockControl)
					{
						((DockControl)x43bec302f92080b9).xadad18dc04073a00 = false;
					}
				}
				goto IL_EA;
			}
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x00022CB0 File Offset: 0x00021CB0
		private static bool xf96eb78473d85a37(DockContainer xd3311d815ca25f02, SplitLayoutSystem xb25822984a90695b)
		{
			foreach (object obj in xb25822984a90695b.LayoutSystems)
			{
				LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
				if (layoutSystemBase is SplitLayoutSystem)
				{
					bool flag = LayoutUtilities.xf96eb78473d85a37(xd3311d815ca25f02, (SplitLayoutSystem)layoutSystemBase);
					bool flag2 = (flag ? 1U : 0U) - (flag ? 1U : 0U) < 0U;
					if (!flag2)
					{
						if (!flag)
						{
							if (!false)
							{
								continue;
							}
							continue;
						}
					}
					return true;
				}
				ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem)layoutSystemBase;
				if (!controlLayoutSystem.Collapsed)
				{
					if (!xd3311d815ca25f02.Controls.Contains(controlLayoutSystem.SelectedControl))
					{
						if (8 != 0)
						{
							continue;
						}
					}
					if (controlLayoutSystem.SelectedControl.Visible)
					{
						if (controlLayoutSystem.SelectedControl.Enabled)
						{
							xd3311d815ca25f02.ActiveControl = controlLayoutSystem.SelectedControl;
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x00022DDC File Offset: 0x00021DDC
		internal static void x4487f2f8917e3fd0(ControlLayoutSystem x6e150040c8d97700)
		{
			DockContainer dockContainer;
			if (x6e150040c8d97700 != null)
			{
				dockContainer = x6e150040c8d97700.DockContainer;
				goto IL_93;
			}
			if (15 != 0)
			{
				throw new ArgumentNullException();
			}
			IL_1F:
			if (!dockContainer.x61d88745bde7a5ec())
			{
				return;
			}
			if (dockContainer is DocumentContainer && dockContainer.Manager != null && dockContainer.Manager.EnableEmptyEnvironment)
			{
				if (false)
				{
					goto IL_4E;
				}
			}
			else
			{
				dockContainer.Dispose();
				if (false)
				{
					goto IL_9B;
				}
				if (false)
				{
					goto IL_4E;
				}
				if (255 == 0)
				{
				}
			}
			return;
			IL_4E:
			goto IL_1F;
			IL_6E:
			if (x6e150040c8d97700.Parent == null)
			{
				return;
			}
			x6e150040c8d97700.Parent.LayoutSystems.Remove(x6e150040c8d97700);
			if (!false)
			{
				if (dockContainer == null)
				{
					return;
				}
				goto IL_1F;
			}
			IL_93:
			if (x6e150040c8d97700.x10ac79a4257c7f52 == null)
			{
				goto IL_6E;
			}
			IL_9B:
			if (x6e150040c8d97700.x10ac79a4257c7f52.x23498f53d87354d4 != x6e150040c8d97700)
			{
				goto IL_6E;
			}
			x6e150040c8d97700.x10ac79a4257c7f52.xcdb145600c1b7224(true);
			goto IL_6E;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x00022EB4 File Offset: 0x00021EB4
		internal static void xf1cbd48a28ce6e74(DockControl x43bec302f92080b9)
		{
			if (x43bec302f92080b9 == null)
			{
				bool containsFocus;
				if ((containsFocus ? 1U : 0U) + (containsFocus ? 1U : 0U) <= 4294967295U)
				{
					throw new ArgumentNullException();
				}
			}
			else
			{
				ControlLayoutSystem layoutSystem = x43bec302f92080b9.LayoutSystem;
				if (layoutSystem != null)
				{
					DockContainer dockContainer = layoutSystem.DockContainer;
					bool containsFocus = x43bec302f92080b9.ContainsFocus;
					if (!containsFocus)
					{
						goto IL_6A;
					}
					if (((containsFocus ? 1U : 0U) & 0U) == 0U)
					{
						Form form = x43bec302f92080b9.FindForm();
						if (form != null)
						{
							form.ActiveControl = null;
							goto IL_6A;
						}
						goto IL_6A;
					}
					IL_0B:
					DockControl dockControl;
					if (dockControl == null)
					{
						return;
					}
					dockControl.x6d1b64d6c637a91d(true);
					return;
					IL_2B:
					goto IL_0B;
					IL_6A:
					layoutSystem.Controls.Remove(x43bec302f92080b9);
					if (layoutSystem.Controls.Count == 0)
					{
						LayoutUtilities.x4487f2f8917e3fd0(layoutSystem);
					}
					if (!containsFocus)
					{
						return;
					}
					if (x43bec302f92080b9.Manager == null)
					{
						if (!false)
						{
							return;
						}
					}
					else
					{
						dockControl = x43bec302f92080b9.Manager.FindMostRecentlyUsedWindow(DockSituation.Document, x43bec302f92080b9);
						if (dockControl == null)
						{
							dockControl = x43bec302f92080b9.Manager.FindMostRecentlyUsedWindow((DockSituation)(-1), x43bec302f92080b9);
						}
					}
					goto IL_2B;
				}
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00022FCC File Offset: 0x00021FCC
		internal static int xc6fb69ef430eaa44(DockContainer x0467b00af7810f0c)
		{
			int num = x0467b00af7810f0c.AllowResize ? 4 : 0;
			return num + LayoutUtilities.xd47535e893e9796b(x0467b00af7810f0c.LayoutSystem, x0467b00af7810f0c.x61c108cc44ef385a ? Orientation.Vertical : Orientation.Horizontal) * 5;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00023004 File Offset: 0x00022004
		private static int xd47535e893e9796b(SplitLayoutSystem x6e150040c8d97700, Orientation xf65758d54b79fc7a)
		{
			int num = 0;
			IEnumerator enumerator = x6e150040c8d97700.LayoutSystems.GetEnumerator();
			bool flag;
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					LayoutSystemBase layoutSystemBase = (LayoutSystemBase)obj;
					SplitLayoutSystem splitLayoutSystem = layoutSystemBase as SplitLayoutSystem;
					if (splitLayoutSystem != null)
					{
						num = Math.Max(num, LayoutUtilities.xd47535e893e9796b(splitLayoutSystem, xf65758d54b79fc7a));
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				flag = (((uint)num | 4294967294U) == 0U);
				if (flag || disposable != null)
				{
					disposable.Dispose();
				}
			}
			int num2 = num;
			flag = (((uint)num2 | uint.MaxValue) == 0U);
			if (!flag)
			{
				if (x6e150040c8d97700.LayoutSystems.Count <= 1)
				{
					if (4 != 0)
					{
						return num2;
					}
				}
			}
			if (x6e150040c8d97700.SplitMode == xf65758d54b79fc7a)
			{
				num2 += x6e150040c8d97700.LayoutSystems.Count - 1;
			}
			return num2;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00023124 File Offset: 0x00022124
		internal static x5678bb8d80c0f12e x4689c8634e31fc55(SandDockManager x91f347c6e97f1846, WindowMetaData xfffbdea061bfa120)
		{
			DockContainer[] dockContainers = x91f347c6e97f1846.GetDockContainers(LayoutUtilities.xf8330a3964a419ba(xfffbdea061bfa120.LastFixedDockSide));
			if (dockContainers.Length == 0)
			{
				DockContainer dockContainer = x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Inside, xfffbdea061bfa120.DockedContentSize);
				return new x5678bb8d80c0f12e(dockContainer.LayoutSystem, 0);
			}
			if (dockContainers.Length < xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e)
			{
				if (-1 == 0)
				{
					if (!false && false)
					{
						goto IL_DE;
					}
					goto IL_5C;
				}
			}
			else if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 < dockContainers.Length && xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 != -1)
			{
				return LayoutUtilities.x2f8f74d308cc9f3f(dockContainers[xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557], xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d);
			}
			if (xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e >= 2)
			{
				goto IL_5C;
			}
			IL_43:
			if (dockContainers.Length != 0)
			{
				return LayoutUtilities.x2f8f74d308cc9f3f(dockContainers[0], xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d);
			}
			DockContainer dockContainer2 = x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Inside, xfffbdea061bfa120.DockedContentSize);
			if (15 != 0)
			{
				return new x5678bb8d80c0f12e(dockContainer2.LayoutSystem, 0);
			}
			IL_5C:
			if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 != 0)
			{
				if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 == xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e - 1)
				{
					DockContainer dockContainer3 = x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Inside, xfffbdea061bfa120.DockedContentSize);
					return new x5678bb8d80c0f12e(dockContainer3.LayoutSystem, 0);
				}
				goto IL_43;
			}
			IL_DE:
			DockContainer dockContainer4 = x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Outside, xfffbdea061bfa120.DockedContentSize);
			return new x5678bb8d80c0f12e(dockContainer4.LayoutSystem, 0);
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x000232A4 File Offset: 0x000222A4
		internal static x5678bb8d80c0f12e x2f8f74d308cc9f3f(DockContainer xd3311d815ca25f02, int[] x27bf3f6bb3609d15)
		{
			SplitLayoutSystem splitLayoutSystem = xd3311d815ca25f02.LayoutSystem;
			int i = 0;
			int num;
			for (;;)
			{
				IL_A5:
				while (i < x27bf3f6bb3609d15.Length)
				{
					num = x27bf3f6bb3609d15[i];
					if (num >= splitLayoutSystem.LayoutSystems.Count)
					{
						goto Block_6;
					}
					SplitLayoutSystem splitLayoutSystem2;
					do
					{
						splitLayoutSystem2 = (splitLayoutSystem.LayoutSystems[num] as SplitLayoutSystem);
						bool flag = ((uint)i & 0U) == 0U;
						if (!flag)
						{
							goto IL_A5;
						}
						if (255 == 0)
						{
							break;
						}
					}
					while (false);
					IL_33:
					if (splitLayoutSystem2 != null)
					{
						splitLayoutSystem = splitLayoutSystem2;
						i++;
						continue;
					}
					goto IL_24;
					goto IL_33;
				}
				break;
			}
			return new x5678bb8d80c0f12e(xd3311d815ca25f02.LayoutSystem, 0);
			IL_24:
			return new x5678bb8d80c0f12e(splitLayoutSystem, num);
			Block_6:
			return new x5678bb8d80c0f12e(splitLayoutSystem, splitLayoutSystem.LayoutSystems.Count);
		}

		// Token: 0x04000180 RID: 384
		private static int x9b1e2b1c391ceb59;
	}
}

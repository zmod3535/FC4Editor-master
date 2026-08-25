using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Divelements.SandDock.Primitives;
using Divelements.SandDock.Resources;

namespace Divelements.SandDock
{
	// Token: 0x02000021 RID: 33
	internal static class xd679d9fc970c8f10
	{
		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600023C RID: 572 RVA: 0x00039660 File Offset: 0x00037A60
		// (set) Token: 0x0600023D RID: 573 RVA: 0x00039668 File Offset: 0x00037A68
		public static bool xd36c48a77e7b0108
		{
			get
			{
				return xd679d9fc970c8f10.xa4add0921d3f24f2;
			}
			set
			{
				xd679d9fc970c8f10.xa4add0921d3f24f2 = value;
			}
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00039670 File Offset: 0x00037A70
		public static void x1bfedb81111c56cf()
		{
			xd679d9fc970c8f10.x784c7f7943f9cb1e++;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00039680 File Offset: 0x00037A80
		public static void x6a0b5cc1ee52d476()
		{
			xd679d9fc970c8f10.x784c7f7943f9cb1e--;
			xd679d9fc970c8f10.x784c7f7943f9cb1e = Math.Max(xd679d9fc970c8f10.x784c7f7943f9cb1e, 0);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000396A0 File Offset: 0x00037AA0
		public static void x68e583994d0940db()
		{
			if (xd679d9fc970c8f10.x784c7f7943f9cb1e > 0)
			{
				throw new InvalidOperationException(Messages.ExceptionLayoutLocked);
			}
		}

		// Token: 0x06000241 RID: 577 RVA: 0x000396B8 File Offset: 0x00037AB8
		private static DockableWindow xdd7aadb2dc51d395(DockSite x7f72cb59f44fe44c, DockableWindow x4f77492f3b12dc83)
		{
			DockableWindow[] allWindows = x7f72cb59f44fe44c.GetAllWindows();
			DateTime[] array = new DateTime[allWindows.Length];
			for (int i = 0; i < allWindows.Length; i++)
			{
				array[i] = allWindows[i].MetaData.LastFocused;
			}
			Array.Sort<DateTime, DockableWindow>(array, allWindows);
			DockableWindow dockableWindow = null;
			DockableWindow dockableWindow2 = null;
			for (int j = allWindows.Length - 1; j >= 0; j--)
			{
				if (allWindows[j] != x4f77492f3b12dc83 && allWindows[j].DockSituation != DockSituation.None)
				{
					if (dockableWindow2 == null && allWindows[j].DockSituation == DockSituation.Document)
					{
						dockableWindow2 = allWindows[j];
					}
					if (dockableWindow == null)
					{
						if ((uint)j - (uint)j < 0U)
						{
							continue;
						}
						dockableWindow = allWindows[j];
					}
				}
			}
			if (x4f77492f3b12dc83.DockSituation == DockSituation.Document && dockableWindow2 != null)
			{
				return dockableWindow2;
			}
			return dockableWindow;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00039778 File Offset: 0x00037B78
		public static void xe3db202f22b97a52(DockableWindow x76b3d9d2638e5ecd)
		{
			xd679d9fc970c8f10.xe3db202f22b97a52(x76b3d9d2638e5ecd, false);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00039784 File Offset: 0x00037B84
		public static void xe3db202f22b97a52(DockableWindow x76b3d9d2638e5ecd, bool x76aa1bcf19e43644)
		{
			xd679d9fc970c8f10.x68e583994d0940db();
			if (x76aa1bcf19e43644 && x76b3d9d2638e5ecd.IsKeyboardFocusWithin && x76b3d9d2638e5ecd.DockSite != null)
			{
				DockableWindow dockableWindow = xd679d9fc970c8f10.xdd7aadb2dc51d395(x76b3d9d2638e5ecd.DockSite, x76b3d9d2638e5ecd);
				if (dockableWindow != null)
				{
					dockableWindow.SelectAndPopup(true);
				}
			}
			WindowGroup windowGroup = x76b3d9d2638e5ecd.Parent as WindowGroup;
			if (windowGroup != null)
			{
				windowGroup.Windows.Remove(x76b3d9d2638e5ecd);
				if (windowGroup.Windows.Count == 0)
				{
					xd679d9fc970c8f10.xaf92e3c82f3efd70(windowGroup);
				}
			}
			MdiContainer mdiContainer = x76b3d9d2638e5ecd.Parent as MdiContainer;
			if (mdiContainer != null)
			{
				mdiContainer.Items.Remove(x76b3d9d2638e5ecd);
			}
			if (x76b3d9d2638e5ecd.Parent != null)
			{
				throw new InvalidOperationException(Messages.ExceptionCannotRemoveDockableWindow);
			}
			x76b3d9d2638e5ecd.RecordMetaData();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00039824 File Offset: 0x00037C24
		public static void xaf92e3c82f3efd70(WindowGroup x2df2648551d39285)
		{
			xd679d9fc970c8f10.x68e583994d0940db();
			SplitContainer splitContainer = x2df2648551d39285.Parent as SplitContainer;
			if (splitContainer != null)
			{
				splitContainer.Children.Remove(x2df2648551d39285);
				if (splitContainer.Children.Count == 1 && splitContainer.Parent is SplitContainer)
				{
					xd679d9fc970c8f10.x6130cec77c7bcd73((SplitContainer)splitContainer.Parent, splitContainer, splitContainer.Children[0]);
					return;
				}
				if (splitContainer.Children.Count == 0)
				{
					xd679d9fc970c8f10.xa0146c9f1fe5c023(splitContainer);
				}
			}
			if (x2df2648551d39285.Parent != null)
			{
				throw new InvalidOperationException(Messages.ExceptionCannotRemoveWindowGroup);
			}
			foreach (DockableWindow dockableWindow in x2df2648551d39285.Windows)
			{
				dockableWindow.RecordMetaData();
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000398FC File Offset: 0x00037CFC
		private static void xa0146c9f1fe5c023(SplitContainer x32a48f2091f0f2d3)
		{
			SplitContainer splitContainer = x32a48f2091f0f2d3.Parent as SplitContainer;
			if (splitContainer != null)
			{
				splitContainer.Children.Remove(x32a48f2091f0f2d3);
				if (splitContainer.Children.Count == 0)
				{
					xd679d9fc970c8f10.xa0146c9f1fe5c023(splitContainer);
				}
			}
			DockSite dockSite = x32a48f2091f0f2d3.Parent as DockSite;
			if (dockSite != null && dockSite.SplitContainers.Contains(x32a48f2091f0f2d3))
			{
				dockSite.SplitContainers.Remove(x32a48f2091f0f2d3);
			}
			DocumentContainer documentContainer = x32a48f2091f0f2d3.Parent as DocumentContainer;
			if (documentContainer != null && documentContainer.Content == x32a48f2091f0f2d3)
			{
				documentContainer.Content = null;
			}
			FloatingWindowAdapter floatingWindowAdapter = x32a48f2091f0f2d3.Parent as FloatingWindowAdapter;
			if (floatingWindowAdapter != null && !floatingWindowAdapter.IsClosing)
			{
				floatingWindowAdapter.Close();
			}
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0003999C File Offset: 0x00037D9C
		private static void x6130cec77c7bcd73(SplitContainer xb6a159a84cb992d6, SplitContainer xde860fba55c41d76, FrameworkElement xa023f9f9059f07e4)
		{
			int index = xb6a159a84cb992d6.Children.IndexOf(xde860fba55c41d76);
			Size workingSize = SplitContainer.GetWorkingSize(xde860fba55c41d76);
			xde860fba55c41d76.Children.Remove(xa023f9f9059f07e4);
			xb6a159a84cb992d6.Children.RemoveAt(index);
			xb6a159a84cb992d6.Children.Insert(index, xa023f9f9059f07e4);
			SplitContainer.SetWorkingSize(xa023f9f9059f07e4, workingSize);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000399EC File Offset: 0x00037DEC
		public static DockSituation xb666df934bf80a36(FrameworkElement x4bbc2c453c470189)
		{
			for (FrameworkElement frameworkElement = x4bbc2c453c470189; frameworkElement != null; frameworkElement = (frameworkElement.Parent as FrameworkElement))
			{
				DockSite dockSite = frameworkElement.Parent as DockSite;
				if (dockSite != null)
				{
					return DockSituation.Docked;
				}
				DocumentContainer documentContainer = frameworkElement.Parent as DocumentContainer;
				if (documentContainer != null)
				{
					return DockSituation.Document;
				}
				if (frameworkElement.Parent is FloatingWindowAdapter)
				{
					return DockSituation.Floating;
				}
			}
			return DockSituation.None;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00039A40 File Offset: 0x00037E40
		public static FloatingWindowAdapter x94eafc5f4a9a0734(FrameworkElement x4bbc2c453c470189)
		{
			for (FrameworkElement frameworkElement = x4bbc2c453c470189; frameworkElement != null; frameworkElement = (frameworkElement.Parent as FrameworkElement))
			{
				FloatingWindowAdapter floatingWindowAdapter = frameworkElement as FloatingWindowAdapter;
				if (floatingWindowAdapter != null)
				{
					return floatingWindowAdapter;
				}
			}
			return null;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00039A70 File Offset: 0x00037E70
		public static WindowGroup x759774c9bc2901ef(DockSite x7f72cb59f44fe44c, DockSituation xd39eba9a9a1b028e, x129cb2a2bdfd0ab2 xfffbdea061bfa120)
		{
			switch (xd39eba9a9a1b028e)
			{
			case DockSituation.Docked:
				using (IEnumerator enumerator = x7f72cb59f44fe44c.SplitContainers.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						SplitContainer xd3311d815ca25f = (SplitContainer)obj;
						foreach (WindowGroup windowGroup in xd679d9fc970c8f10.x386f01b6cc4bfd98(xd3311d815ca25f))
						{
							if (windowGroup.Guid == xfffbdea061bfa120.x1acd7f00f3ce8dea)
							{
								return windowGroup;
							}
						}
					}
					goto IL_10;
				}
				goto IL_18C;
			case DockSituation.Document:
				goto IL_18C;
			case DockSituation.Floating:
			{
				FloatingWindowAdapter[] floatingWindows = x7f72cb59f44fe44c.GetFloatingWindows();
				int j = 0;
				while (j < floatingWindows.Length)
				{
					FloatingWindowAdapter floatingWindowAdapter = floatingWindows[j];
					foreach (WindowGroup windowGroup2 in xd679d9fc970c8f10.x386f01b6cc4bfd98(floatingWindowAdapter.RootContainer))
					{
						if (windowGroup2.Guid == xfffbdea061bfa120.x1acd7f00f3ce8dea)
						{
							return windowGroup2;
						}
					}
					j++;
					int l;
					if (((uint)l & 0U) != 0U)
					{
						goto IL_87;
					}
					int i;
					bool flag = (uint)i - (uint)j < 0U;
					if (flag)
					{
						IL_F3:
						if (((uint)l & 0U) != 0U)
						{
							WindowGroup result;
							return result;
						}
						goto IL_10;
					}
				}
				goto IL_F3;
			}
			}
			throw new InvalidOperationException();
			IL_10:
			return null;
			IL_87:
			SplitContainer splitContainer;
			foreach (WindowGroup windowGroup3 in xd679d9fc970c8f10.x386f01b6cc4bfd98(splitContainer))
			{
				if (windowGroup3.Guid == xfffbdea061bfa120.x1acd7f00f3ce8dea)
				{
					return windowGroup3;
				}
			}
			goto IL_10;
			IL_18C:
			if (x7f72cb59f44fe44c.DocumentContainer == null)
			{
				goto IL_10;
			}
			splitContainer = (x7f72cb59f44fe44c.DocumentContainer.Content as SplitContainer);
			if (splitContainer != null)
			{
				goto IL_87;
			}
			goto IL_10;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00039C68 File Offset: 0x00038068
		public static x5678bb8d80c0f12e x4689c8634e31fc55(DockSite x7f72cb59f44fe44c, WindowMetaData xfffbdea061bfa120)
		{
			SplitContainer[] dockedSplitContainers = x7f72cb59f44fe44c.GetDockedSplitContainers(xfffbdea061bfa120.LastFixedDockSide);
			if (dockedSplitContainers.Length == 0)
			{
				return xd679d9fc970c8f10.x20b8eaf6666d3942(x7f72cb59f44fe44c, xfffbdea061bfa120.LastFixedDockSide, xfffbdea061bfa120.x89d9f6f099893f30, xfffbdea061bfa120.DockedContentSize);
			}
			if (dockedSplitContainers.Length >= xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e)
			{
				return xd679d9fc970c8f10.x4689c8634e31fc55(dockedSplitContainers[xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557], xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d);
			}
			if (xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e >= 2)
			{
				if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 == 0)
				{
					SplitContainer splitContainer = x7f72cb59f44fe44c.CreateDockedSplitContainer(xfffbdea061bfa120.LastFixedDockSide, DockSiteEdge.Outside, xfffbdea061bfa120.DockedContentSize);
					return new x5678bb8d80c0f12e(splitContainer, 0);
				}
				if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 == xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e - 1)
				{
					SplitContainer splitContainer2 = x7f72cb59f44fe44c.CreateDockedSplitContainer(xfffbdea061bfa120.LastFixedDockSide, DockSiteEdge.Inside, xfffbdea061bfa120.DockedContentSize);
					return new x5678bb8d80c0f12e(splitContainer2, 0);
				}
			}
			return xd679d9fc970c8f10.x4689c8634e31fc55(dockedSplitContainers[0], xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d);
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00039D50 File Offset: 0x00038150
		private static x5678bb8d80c0f12e x20b8eaf6666d3942(DockSite x7f72cb59f44fe44c, Dock xf33779c598cac695, xdeadcc9941b6354e[] x25abbc70af3c5c8a, double xd987e7deb2afdfde)
		{
			if (x25abbc70af3c5c8a != null)
			{
				for (int i = 0; i < Math.Min(x25abbc70af3c5c8a.Length, x7f72cb59f44fe44c.SplitContainers.Count); i++)
				{
					if (DockSite.GetDock(x7f72cb59f44fe44c.SplitContainers[i]) != x25abbc70af3c5c8a[i].xec73a4c1711af3d9 && x25abbc70af3c5c8a[i].xec73a4c1711af3d9 == xf33779c598cac695)
					{
						SplitContainer splitContainer = x7f72cb59f44fe44c.CreateDockedSplitContainer(xf33779c598cac695, i, xd987e7deb2afdfde);
						return new x5678bb8d80c0f12e(splitContainer, 0);
					}
				}
			}
			SplitContainer splitContainer2 = x7f72cb59f44fe44c.CreateDockedSplitContainer(xf33779c598cac695, DockSiteEdge.Inside, xd987e7deb2afdfde);
			return new x5678bb8d80c0f12e(splitContainer2, 0);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00039DD0 File Offset: 0x000381D0
		internal static x5678bb8d80c0f12e x4689c8634e31fc55(SplitContainer x32a48f2091f0f2d3, int[] x27bf3f6bb3609d15)
		{
			SplitContainer splitContainer = x32a48f2091f0f2d3;
			int i = 0;
			while (i < x27bf3f6bb3609d15.Length)
			{
				int num = x27bf3f6bb3609d15[i];
				x5678bb8d80c0f12e result;
				if (num >= splitContainer.Children.Count)
				{
					result = new x5678bb8d80c0f12e(splitContainer, splitContainer.Children.Count);
				}
				else
				{
					SplitContainer splitContainer2 = splitContainer.Children[num] as SplitContainer;
					if (splitContainer2 != null)
					{
						splitContainer = splitContainer2;
						i++;
						continue;
					}
					result = new x5678bb8d80c0f12e(splitContainer, num);
				}
				return result;
			}
			return new x5678bb8d80c0f12e(x32a48f2091f0f2d3, 0);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00039E48 File Offset: 0x00038248
		public static SplitContainer x559d974f790f4e87(WindowGroup x2df2648551d39285)
		{
			for (SplitContainer splitContainer = x2df2648551d39285.Parent as SplitContainer; splitContainer != null; splitContainer = (splitContainer.Parent as SplitContainer))
			{
				if (splitContainer.IsRoot)
				{
					return splitContainer;
				}
			}
			return null;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00039E80 File Offset: 0x00038280
		public static SplitContainer x6cbcff1ac3dcacb1(WindowGroup x2df2648551d39285)
		{
			for (SplitContainer splitContainer = x2df2648551d39285.Parent as SplitContainer; splitContainer != null; splitContainer = (splitContainer.Parent as SplitContainer))
			{
				if (splitContainer.IsRoot)
				{
					return splitContainer;
				}
				if (splitContainer.Parent is DocumentContainer)
				{
					return splitContainer;
				}
				if (splitContainer.Parent is FloatingWindowAdapter)
				{
					return splitContainer;
				}
			}
			return null;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00039ED4 File Offset: 0x000382D4
		public static DockableWindow[] x19fa3ae70a75ea3c(SplitContainer xd3311d815ca25f02)
		{
			List<DockableWindow> list = new List<DockableWindow>();
			foreach (WindowGroup windowGroup in xd679d9fc970c8f10.x386f01b6cc4bfd98(xd3311d815ca25f02))
			{
				foreach (DockableWindow item in windowGroup.Windows)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00039F5C File Offset: 0x0003835C
		public static WindowGroup[] x386f01b6cc4bfd98(SplitContainer xd3311d815ca25f02)
		{
			List<WindowGroup> list = new List<WindowGroup>();
			xd679d9fc970c8f10.x017446c3e62ce222(list, xd3311d815ca25f02);
			return list.ToArray();
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00039F7C File Offset: 0x0003837C
		private static void x017446c3e62ce222(List<WindowGroup> x96647f873b270031, SplitContainer x466ac91a54e86c31)
		{
			foreach (object obj in x466ac91a54e86c31.Children)
			{
				FrameworkElement frameworkElement = (FrameworkElement)obj;
				SplitContainer splitContainer = frameworkElement as SplitContainer;
				if (splitContainer != null)
				{
					xd679d9fc970c8f10.x017446c3e62ce222(x96647f873b270031, splitContainer);
				}
				WindowGroup windowGroup = frameworkElement as WindowGroup;
				if (windowGroup != null)
				{
					x96647f873b270031.Add(windowGroup);
				}
			}
		}

		// Token: 0x040000BC RID: 188
		public const int xd36adb2584572647 = 15;

		// Token: 0x040000BD RID: 189
		public const int x7a6fdfa0ceb3b571 = 32;

		// Token: 0x040000BE RID: 190
		public const int x97027cb7c5cafde3 = 28;

		// Token: 0x040000BF RID: 191
		public const int x660a9b15ab8838ce = 20;

		// Token: 0x040000C0 RID: 192
		private static int x784c7f7943f9cb1e;

		// Token: 0x040000C1 RID: 193
		private static bool xa4add0921d3f24f2;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Divelements.SandDock.Primitives;

namespace Divelements.SandDock.InteractiveDocking
{
	// Token: 0x02000039 RID: 57
	public sealed class DockingManager
	{
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x0600035A RID: 858 RVA: 0x0003EE2C File Offset: 0x0003D22C
		// (remove) Token: 0x0600035B RID: 859 RVA: 0x0003EE64 File Offset: 0x0003D264
		public event EventHandler<DockingOperationCompletedEventArgs> DockingOperationCompleted
		{
			add
			{
				EventHandler<DockingOperationCompletedEventArgs> eventHandler = this.x77cc4d5e9b875e63;
				EventHandler<DockingOperationCompletedEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<DockingOperationCompletedEventArgs> value2 = (EventHandler<DockingOperationCompletedEventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<DockingOperationCompletedEventArgs>>(ref this.x77cc4d5e9b875e63, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler<DockingOperationCompletedEventArgs> eventHandler = this.x77cc4d5e9b875e63;
				EventHandler<DockingOperationCompletedEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<DockingOperationCompletedEventArgs> value2 = (EventHandler<DockingOperationCompletedEventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<DockingOperationCompletedEventArgs>>(ref this.x77cc4d5e9b875e63, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x0600035C RID: 860 RVA: 0x0003EE9C File Offset: 0x0003D29C
		// (remove) Token: 0x0600035D RID: 861 RVA: 0x0003EED4 File Offset: 0x0003D2D4
		public event EventHandler<DockingOperationMoveEventArgs> MoveWindow
		{
			add
			{
				EventHandler<DockingOperationMoveEventArgs> eventHandler = this.x04396fbce28e89e9;
				EventHandler<DockingOperationMoveEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<DockingOperationMoveEventArgs> value2 = (EventHandler<DockingOperationMoveEventArgs>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<DockingOperationMoveEventArgs>>(ref this.x04396fbce28e89e9, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler<DockingOperationMoveEventArgs> eventHandler = this.x04396fbce28e89e9;
				EventHandler<DockingOperationMoveEventArgs> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<DockingOperationMoveEventArgs> value2 = (EventHandler<DockingOperationMoveEventArgs>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler<DockingOperationMoveEventArgs>>(ref this.x04396fbce28e89e9, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0003EF0C File Offset: 0x0003D30C
		private DockingManager(DockSite dockSite)
		{
			if (dockSite == null)
			{
				throw new ArgumentNullException("dockSite");
			}
			this.x7f72cb59f44fe44c = dockSite;
			this.x7c92c43084985bae = new DockingRules();
			this.xdcc1c910cea4f0f2 = dockSite.DockingHintDisplayStrategy;
			if (DesignerProperties.GetIsInDesignMode(dockSite))
			{
				this.xdcc1c910cea4f0f2 = DockingHintDisplayStrategy.Adorners;
			}
			this.x59f2d1fbea6a675d = new x053c20cd4405f3ab(dockSite, this.xdcc1c910cea4f0f2, DockingHintType.WindowMiddle, this.x7c92c43084985bae, (dockSite.DocumentContainer != null) ? dockSite.DocumentContainer : dockSite);
			this.x23f56f30b1768080 = new x053c20cd4405f3ab(dockSite, this.xdcc1c910cea4f0f2, DockingHintType.LeftWindowEdge, this.x7c92c43084985bae, dockSite);
			this.xcf41e3cfab06539a = new x053c20cd4405f3ab(dockSite, this.xdcc1c910cea4f0f2, DockingHintType.RightWindowEdge, this.x7c92c43084985bae, dockSite);
			this.x7039a7bd6c85fa61 = new x053c20cd4405f3ab(dockSite, this.xdcc1c910cea4f0f2, DockingHintType.TopWindowEdge, this.x7c92c43084985bae, dockSite);
			this.xa053ccd3e0595cd7 = new x053c20cd4405f3ab(dockSite, this.xdcc1c910cea4f0f2, DockingHintType.BottomWindowEdge, this.x7c92c43084985bae, dockSite);
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0003EFEC File Offset: 0x0003D3EC
		public DockingManager(DockSite dockSite, WindowDragSourceType sourceType, DockableWindow window) : this(dockSite)
		{
			this.x18465aea2e3748d3 = sourceType;
			this.x7c92c43084985bae.AllowDockLeft = true;
			this.x7c92c43084985bae.AllowDockRight = true;
			this.x7c92c43084985bae.AllowDockTop = true;
			this.x7c92c43084985bae.AllowDockBottom = true;
			this.x7c92c43084985bae.AllowTab = true;
			this.x7c92c43084985bae.AllowMerge = true;
			this.x7c92c43084985bae.AllowFloat = false;
			this.x37edfcebcc27afb7 = window;
			this.xca874006c41dfe29 = this.x37edfcebcc27afb7.FloatingSize;
			this.xfd154bcd21f8881e = (WindowGroup)window.Parent;
			this.x77fd0a4ebd4f0488 = true;
			this.x7bff054be1315d44 = true;
			this.x8b4f3cb8df82acea = new PositionPreview();
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0003F0A0 File Offset: 0x0003D4A0
		internal DockingManager(DockSite dockSite, DockableWindow window) : this(dockSite)
		{
			this.x7c92c43084985bae.xd5da23b762ce52a2(new DockingRules[]
			{
				window.DockingRules
			});
			this.x37edfcebcc27afb7 = window;
			this.xca874006c41dfe29 = this.x37edfcebcc27afb7.FloatingSize;
			this.xfd154bcd21f8881e = (WindowGroup)window.Parent;
			this.x18465aea2e3748d3 = WindowDragSourceType.WindowTab;
			this.x8b4f3cb8df82acea = new PositionPreview(window);
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0003F10C File Offset: 0x0003D50C
		internal DockingManager(DockSite dockSite, WindowGroup windowGroup) : this(dockSite)
		{
			DockingRules[] array = new DockingRules[windowGroup.Items.Count];
			for (int i = 0; i < windowGroup.Items.Count; i++)
			{
				array[i] = windowGroup.Items[i].DockingRules;
			}
			this.x7c92c43084985bae.xd5da23b762ce52a2(array);
			if (!dockSite.AllowFloatingGroups && windowGroup.Items.Count > 1)
			{
				this.x7c92c43084985bae.AllowFloat = false;
			}
			this.x37edfcebcc27afb7 = windowGroup.SelectedWindow;
			this.xca874006c41dfe29 = this.x37edfcebcc27afb7.FloatingSize;
			this.xfd154bcd21f8881e = windowGroup;
			this.x18465aea2e3748d3 = WindowDragSourceType.WindowGroupTitleBar;
			this.x8b4f3cb8df82acea = new PositionPreview(windowGroup);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0003F1C0 File Offset: 0x0003D5C0
		internal DockingManager(DockSite dockSite, FloatingWindowAdapter floatingWindow, Point originalDragPoint) : this(dockSite)
		{
			this.xe4aec4924da44627 = originalDragPoint;
			this.x90b7873f2e7e44f6 = floatingWindow;
			List<DockingRules> list = new List<DockingRules>();
			foreach (WindowGroup windowGroup in xd679d9fc970c8f10.x386f01b6cc4bfd98(floatingWindow.RootContainer))
			{
				foreach (DockableWindow dockableWindow in windowGroup.Windows)
				{
					if (this.x37edfcebcc27afb7 == null && dockableWindow.IsSelected)
					{
						this.x37edfcebcc27afb7 = dockableWindow;
						this.xca874006c41dfe29 = this.x37edfcebcc27afb7.FloatingSize;
						this.xfd154bcd21f8881e = (WindowGroup)dockableWindow.Parent;
					}
					list.Add(dockableWindow.DockingRules);
				}
			}
			this.x7c92c43084985bae.xd5da23b762ce52a2(list.ToArray());
			if (dockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.WpfWindow)
			{
				MdiWindowContainer mdiWindowContainer = (MdiWindowContainer)floatingWindow.Parent;
				this.xca874006c41dfe29 = mdiWindowContainer.RenderSize;
				this.x50a7bd075d9a6e31 = new VisualBrush(mdiWindowContainer);
				this.x50a7bd075d9a6e31.Stretch = Stretch.None;
				RenderOptions.SetCachingHint(this.x50a7bd075d9a6e31, CachingHint.Cache);
			}
			this.x18465aea2e3748d3 = WindowDragSourceType.FloatingWindowTitleBar;
			this.x8b4f3cb8df82acea = new PositionPreview(floatingWindow.RootContainer);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0003F314 File Offset: 0x0003D714
		private void x8dbbb2896a8436c0(DockingOperationCompletedEventArgs xfbf34718e704c6bc)
		{
			if (this.x77cc4d5e9b875e63 != null)
			{
				this.x77cc4d5e9b875e63(this, xfbf34718e704c6bc);
			}
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0003F32C File Offset: 0x0003D72C
		private void xad7c5bed217f4380(DockingOperationMoveEventArgs xfbf34718e704c6bc)
		{
			if (this.x04396fbce28e89e9 != null)
			{
				this.x04396fbce28e89e9(this, xfbf34718e704c6bc);
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000365 RID: 869 RVA: 0x0003F344 File Offset: 0x0003D744
		public DockingRules Rules
		{
			get
			{
				return this.x7c92c43084985bae;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0003F34C File Offset: 0x0003D74C
		// (set) Token: 0x06000367 RID: 871 RVA: 0x0003F354 File Offset: 0x0003D754
		private WindowGroup xff42ce14673f2ea6
		{
			get
			{
				return this.x91caa3fef49a06e2;
			}
			set
			{
				if (value != this.x91caa3fef49a06e2)
				{
					if (this.x91caa3fef49a06e2 != null)
					{
						this.x21384c266de47295[this.x91caa3fef49a06e2].x3452082a8fecf97d = false;
					}
					this.x91caa3fef49a06e2 = value;
					if (this.x91caa3fef49a06e2 != null)
					{
						x053c20cd4405f3ab x053c20cd4405f3ab;
						if (!this.x21384c266de47295.TryGetValue(this.x91caa3fef49a06e2, out x053c20cd4405f3ab))
						{
							x053c20cd4405f3ab = new x053c20cd4405f3ab(this.x7f72cb59f44fe44c, this.xdcc1c910cea4f0f2, DockingHintType.WindowGroupMiddle, this.x7c92c43084985bae, this.x91caa3fef49a06e2);
							x053c20cd4405f3ab.xba4e4c184d813a0d = this.x91caa3fef49a06e2;
							x053c20cd4405f3ab.xd6b6ed77479ef68c();
							this.x21384c266de47295[this.x91caa3fef49a06e2] = x053c20cd4405f3ab;
						}
						x053c20cd4405f3ab.x3452082a8fecf97d = true;
					}
				}
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0003F3FC File Offset: 0x0003D7FC
		private bool x56e32cafd2bf10af()
		{
			List<WindowGroup> list = new List<WindowGroup>();
			foreach (DockableWindow dockableWindow in this.x7f72cb59f44fe44c.GetAllWindows())
			{
				if (dockableWindow.DockSituation != DockSituation.None)
				{
					WindowGroup windowGroup = dockableWindow.Parent as WindowGroup;
					if (windowGroup != null && !list.Contains(windowGroup) && this.x2748749aac82fd93(windowGroup))
					{
						list.Add(windowGroup);
					}
				}
			}
			this.x7cb100676a6d35c3 = list.ToArray();
			int[] array = new int[this.x7cb100676a6d35c3.Length];
			for (int j = 0; j < this.x7cb100676a6d35c3.Length; j++)
			{
				array[j] = ((this.x7cb100676a6d35c3[j].SelectedWindow.DockSituation == DockSituation.Floating) ? 0 : 1);
			}
			Array.Sort<int, WindowGroup>(array, this.x7cb100676a6d35c3);
			return true;
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0003F4C4 File Offset: 0x0003D8C4
		private bool x2748749aac82fd93(WindowGroup x2df2648551d39285)
		{
			if (x2df2648551d39285.Items.Count == 0)
			{
				return false;
			}
			if (!x2df2648551d39285.Pinned)
			{
				return false;
			}
			if (this.x18465aea2e3748d3 == WindowDragSourceType.WindowGroupTitleBar && x2df2648551d39285 == this.xfd154bcd21f8881e)
			{
				return false;
			}
			if (this.x18465aea2e3748d3 == WindowDragSourceType.WindowTab && x2df2648551d39285 == this.xfd154bcd21f8881e && this.xfd154bcd21f8881e.Items.Count == 1)
			{
				return false;
			}
			if (this.x18465aea2e3748d3 == WindowDragSourceType.FloatingWindowTitleBar && this.x5a6ed049c00a5fa7(x2df2648551d39285, this.xfd154bcd21f8881e))
			{
				return false;
			}
			if (x2df2648551d39285.SelectedWindow.DockSituation == DockSituation.Docked)
			{
				if (this.x7c92c43084985bae.AllowDockLeft || x2df2648551d39285.SelectedWindow.MetaData.LastFixedDockSide != Dock.Left)
				{
					if (!this.x7c92c43084985bae.AllowDockRight)
					{
						if (x2df2648551d39285.SelectedWindow.MetaData.LastFixedDockSide == Dock.Right)
						{
							return false;
						}
						if (8 == 0)
						{
							goto IL_17;
						}
					}
					if (this.x7c92c43084985bae.AllowDockTop || x2df2648551d39285.SelectedWindow.MetaData.LastFixedDockSide != Dock.Top)
					{
						if (this.x7c92c43084985bae.AllowDockBottom || x2df2648551d39285.SelectedWindow.MetaData.LastFixedDockSide != Dock.Bottom)
						{
							goto IL_34;
						}
					}
				}
				return false;
			}
			IL_17:
			if (x2df2648551d39285.SelectedWindow.DockSituation == DockSituation.Document && !this.x7c92c43084985bae.AllowTab)
			{
				return false;
			}
			IL_34:
			return (this.x37edfcebcc27afb7.DockSituation != DockSituation.Docked || x2df2648551d39285.SelectedWindow.DockSituation != DockSituation.Document) && (this.x37edfcebcc27afb7.DockSituation != DockSituation.Document || x2df2648551d39285.SelectedWindow.DockSituation != DockSituation.Docked || this.x7bff054be1315d44) && (x2df2648551d39285.SelectedWindow.DockSituation != DockSituation.Floating || this.x7f72cb59f44fe44c.AllowFloatingGroups);
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0003F688 File Offset: 0x0003DA88
		private bool x5a6ed049c00a5fa7(WindowGroup x2df2648551d39285, WindowGroup xfd154bcd21f8881e)
		{
			return xd679d9fc970c8f10.x94eafc5f4a9a0734(x2df2648551d39285) == xd679d9fc970c8f10.x94eafc5f4a9a0734(xfd154bcd21f8881e);
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0003F698 File Offset: 0x0003DA98
		private void xeb89af5061730a4a(FrameworkElement x4bbc2c453c470189, Rect xda73fcb97c77d998, x4025ca48d3c65c4e x520d41bf4dc059d1)
		{
			this.x8b4f3cb8df82acea.PreviewType = x520d41bf4dc059d1;
			if ((x520d41bf4dc059d1 == x4025ca48d3c65c4e.x0c60a6a0825c8336 && this.x7f72cb59f44fe44c.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.NativeWindow) || (x520d41bf4dc059d1 != x4025ca48d3c65c4e.x0c60a6a0825c8336 && this.xdcc1c910cea4f0f2 == DockingHintDisplayStrategy.Popups))
			{
				this.xe9dcac0eb8d04300(x4bbc2c453c470189, xda73fcb97c77d998, x520d41bf4dc059d1);
			}
			else
			{
				if (this.x604d606ae0d8a4da != null && this.x604d606ae0d8a4da.AdornedElement != x4bbc2c453c470189)
				{
					this.x3322b9ee1ea9ab48();
				}
				if (this.x96d471a55259a6a5 != null)
				{
					this.x664ce73fb42454c2();
				}
				if (this.x604d606ae0d8a4da == null)
				{
					this.x604d606ae0d8a4da = new PositionPreviewAdorner(x4bbc2c453c470189, this.x8b4f3cb8df82acea);
					this.x604d606ae0d8a4da.Add();
				}
				this.x604d606ae0d8a4da.Bounds = xda73fcb97c77d998;
			}
			if (this.x90b7873f2e7e44f6 != null)
			{
				this.x90b7873f2e7e44f6.SetOpacity(0.2);
			}
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0003F750 File Offset: 0x0003DB50
		private void xe9dcac0eb8d04300(FrameworkElement x4bbc2c453c470189, Rect xda73fcb97c77d998, x4025ca48d3c65c4e x520d41bf4dc059d1)
		{
			if (this.x604d606ae0d8a4da != null)
			{
				this.x3322b9ee1ea9ab48();
			}
			if (this.x96d471a55259a6a5 == null)
			{
				this.x96d471a55259a6a5 = new x1300cf777c4b7322(this.x8b4f3cb8df82acea);
			}
			Point location;
			if (x520d41bf4dc059d1 == x4025ca48d3c65c4e.x0c60a6a0825c8336)
			{
				location = PresentationSource.FromVisual(this.x7f72cb59f44fe44c).CompositionTarget.TransformToDevice.Transform(xda73fcb97c77d998.Location);
			}
			else
			{
				location = x4bbc2c453c470189.PointToScreen(xda73fcb97c77d998.Location);
			}
			this.x96d471a55259a6a5.x47b5c057cc37f4ff(new Rect(location, xda73fcb97c77d998.Size));
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0003F7D4 File Offset: 0x0003DBD4
		private void x664ce73fb42454c2()
		{
			if (this.x96d471a55259a6a5 != null)
			{
				this.x96d471a55259a6a5.x5486e0b5e830d25c();
			}
			if (this.x90b7873f2e7e44f6 != null)
			{
				this.x90b7873f2e7e44f6.SetOpacity(1.0);
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0003F808 File Offset: 0x0003DC08
		private void x3322b9ee1ea9ab48()
		{
			if (this.x604d606ae0d8a4da != null)
			{
				this.x604d606ae0d8a4da.Remove();
				this.x604d606ae0d8a4da = null;
			}
			if (this.x90b7873f2e7e44f6 != null)
			{
				this.x90b7873f2e7e44f6.SetOpacity(1.0);
			}
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0003F840 File Offset: 0x0003DC40
		public bool Start()
		{
			if (this.xa962380f08300c5b)
			{
				return false;
			}
			if (this.x56e32cafd2bf10af())
			{
				if (!this.xfd154bcd21f8881e.CaptureMouse())
				{
					return false;
				}
				Mouse.AddLostMouseCaptureHandler(this.xfd154bcd21f8881e, new MouseEventHandler(this.xeea1635a0ab1285a));
				Mouse.AddMouseMoveHandler(this.xfd154bcd21f8881e, new MouseEventHandler(this.x2c5d1da1234c3a6a));
				Mouse.AddMouseUpHandler(this.xfd154bcd21f8881e, new MouseButtonEventHandler(this.xbf1526c05253a47c));
				this.xf58ff9ce0e24a20c = (Keyboard.FocusedElement as FrameworkElement);
				this.x21384c266de47295 = new Dictionary<WindowGroup, x053c20cd4405f3ab>();
				x053c20cd4405f3ab[] array = new x053c20cd4405f3ab[5];
				array[0] = this.x59f2d1fbea6a675d;
				array[1] = this.x23f56f30b1768080;
				array[2] = this.xcf41e3cfab06539a;
				array[3] = this.x7039a7bd6c85fa61;
				int i;
				if ((uint)i + (uint)i >= 0U)
				{
					array[4] = this.xa053ccd3e0595cd7;
					foreach (x053c20cd4405f3ab x053c20cd4405f3ab in array)
					{
						x053c20cd4405f3ab.xd6b6ed77479ef68c();
					}
					xd679d9fc970c8f10.x1bfedb81111c56cf();
					try
					{
						this.x7f72cb59f44fe44c.OnDockingStarted(new DockingStartedEventArgs(this.x18465aea2e3748d3));
					}
					finally
					{
						xd679d9fc970c8f10.x6a0b5cc1ee52d476();
					}
					this.xa962380f08300c5b = true;
					return true;
				}
			}
			return false;
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000370 RID: 880 RVA: 0x0003F990 File Offset: 0x0003DD90
		// (set) Token: 0x06000371 RID: 881 RVA: 0x0003F998 File Offset: 0x0003DD98
		private FrameworkElement xf58ff9ce0e24a20c
		{
			get
			{
				return this.x9fde6943eed61cee;
			}
			set
			{
				if (value != this.x9fde6943eed61cee)
				{
					if (this.x9fde6943eed61cee != null)
					{
						this.x9fde6943eed61cee.PreviewKeyDown -= this.x776f8978bd67c752;
						this.x9fde6943eed61cee.PreviewKeyUp -= this.x776f8978bd67c752;
					}
					this.x9fde6943eed61cee = value;
					if (this.x9fde6943eed61cee != null)
					{
						this.x9fde6943eed61cee.PreviewKeyDown += this.x776f8978bd67c752;
						this.x9fde6943eed61cee.PreviewKeyUp += this.x776f8978bd67c752;
					}
				}
			}
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0003FA24 File Offset: 0x0003DE24
		private void x776f8978bd67c752(object xe0292b9ed559da7d, KeyEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.Key == Key.LeftCtrl || xfbf34718e704c6bc.Key == Key.RightCtrl)
			{
				xfbf34718e704c6bc.Handled = true;
				this.x2c5d1da1234c3a6a(this.xfd154bcd21f8881e, new MouseEventArgs(Mouse.PrimaryDevice, xfbf34718e704c6bc.Timestamp));
				return;
			}
			if (xfbf34718e704c6bc.Key == Key.Escape)
			{
				xfbf34718e704c6bc.Handled = true;
				this.xac2b8ecd963a9a83();
			}
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0003FA80 File Offset: 0x0003DE80
		private void xac2b8ecd963a9a83()
		{
			if (this.xa962380f08300c5b)
			{
				foreach (x053c20cd4405f3ab x053c20cd4405f3ab in this.x21384c266de47295.Values)
				{
					x053c20cd4405f3ab.x52b190e626f65140();
				}
				x053c20cd4405f3ab[] array = new x053c20cd4405f3ab[5];
				array[0] = this.x59f2d1fbea6a675d;
				array[1] = this.x23f56f30b1768080;
				array[2] = this.xcf41e3cfab06539a;
				do
				{
					array[3] = this.x7039a7bd6c85fa61;
					array[4] = this.xa053ccd3e0595cd7;
				}
				while (false);
				x053c20cd4405f3ab[] array2 = array;
				int i;
				for (i = 0; i < array2.Length; i++)
				{
					x053c20cd4405f3ab x053c20cd4405f3ab2 = array2[i];
					x053c20cd4405f3ab2.x52b190e626f65140();
				}
				this.x3322b9ee1ea9ab48();
				bool flag = (uint)i + (uint)i > uint.MaxValue;
				if (!flag)
				{
					this.x664ce73fb42454c2();
					if (this.x96d471a55259a6a5 != null)
					{
						this.x96d471a55259a6a5.x3607c8ea8b9a05f6();
					}
					Mouse.RemoveLostMouseCaptureHandler(this.xfd154bcd21f8881e, new MouseEventHandler(this.xeea1635a0ab1285a));
					Mouse.RemoveMouseMoveHandler(this.xfd154bcd21f8881e, new MouseEventHandler(this.x2c5d1da1234c3a6a));
					Mouse.RemoveMouseUpHandler(this.xfd154bcd21f8881e, new MouseButtonEventHandler(this.xbf1526c05253a47c));
					this.xf58ff9ce0e24a20c = null;
					this.xfd154bcd21f8881e.ReleaseMouseCapture();
					this.xa962380f08300c5b = false;
					this.x7f72cb59f44fe44c.OnDockingStopped(EventArgs.Empty);
					if (((uint)i & 0U) != 0U)
					{
						return;
					}
				}
				return;
			}
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0003FC0C File Offset: 0x0003E00C
		private void xeea1635a0ab1285a(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			this.xac2b8ecd963a9a83();
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0003FC14 File Offset: 0x0003E014
		private void x2c5d1da1234c3a6a(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			this.x0241a4621c4f15a3(xfbf34718e704c6bc);
			this.xc5a140008c7e32aa(xfbf34718e704c6bc);
			this.x89aeffb9ed58341e();
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0003FC2C File Offset: 0x0003E02C
		private void xbf1526c05253a47c(object xe0292b9ed559da7d, MouseButtonEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.ChangedButton == MouseButton.Left && xfbf34718e704c6bc.ButtonState == MouseButtonState.Released)
			{
				this.xac2b8ecd963a9a83();
				if (this.x98347fb858b62cb0 != null)
				{
					if (!this.x77fd0a4ebd4f0488)
					{
						this.xb70c070873e33f1a();
						this.x37edfcebcc27afb7.SelectAndPopup(true);
					}
					else
					{
						this.x8dbbb2896a8436c0(new DockingOperationCompletedEventArgs(this.x98347fb858b62cb0));
					}
					this.x98347fb858b62cb0 = null;
				}
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0003FC8C File Offset: 0x0003E08C
		private void xb70c070873e33f1a()
		{
			if (this.x18465aea2e3748d3 == WindowDragSourceType.FloatingWindowTitleBar)
			{
				FloatOperation floatOperation = this.x98347fb858b62cb0 as FloatOperation;
				if (floatOperation != null)
				{
					this.x90b7873f2e7e44f6.FloatingLocation = floatOperation.Bounds.Location;
					return;
				}
			}
			FrameworkElement frameworkElement = this.x80ad233b170daa28(this.x98347fb858b62cb0.x279bb9926f160988);
			WindowGroup windowGroup = frameworkElement as WindowGroup;
			if (windowGroup != null)
			{
				this.x98347fb858b62cb0.xb82fe19b24eb0010(windowGroup);
			}
			SplitContainer splitContainer = frameworkElement as SplitContainer;
			if (splitContainer != null)
			{
				this.x98347fb858b62cb0.x84795d7d5447dcfc(splitContainer);
			}
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0003FD0C File Offset: 0x0003E10C
		private FrameworkElement x80ad233b170daa28(DockSituation x0bb106bdd34c41ce)
		{
			WindowGroup windowGroup;
			if (this.x18465aea2e3748d3 == WindowDragSourceType.WindowTab)
			{
				if (this.x37edfcebcc27afb7.IsKeyboardFocusWithin)
				{
					Window window = Window.GetWindow(this.x7f72cb59f44fe44c);
					if (window != null)
					{
						FocusManager.SetFocusedElement(window, null);
					}
					Keyboard.Focus(null);
				}
				xd679d9fc970c8f10.xe3db202f22b97a52(this.x37edfcebcc27afb7);
				windowGroup = new WindowGroup(new DockableWindow[]
				{
					this.x37edfcebcc27afb7
				});
				SplitContainer.SetWorkingSize(windowGroup, SplitContainer.GetWorkingSize(this.xfd154bcd21f8881e));
			}
			else if (this.x18465aea2e3748d3 == WindowDragSourceType.WindowGroupTitleBar)
			{
				if (this.xfd154bcd21f8881e.IsKeyboardFocusWithin)
				{
					Keyboard.Focus(null);
				}
				xd679d9fc970c8f10.xaf92e3c82f3efd70(this.xfd154bcd21f8881e);
				if (-1 != 0)
				{
					return this.xfd154bcd21f8881e;
				}
			}
			else
			{
				if (this.x18465aea2e3748d3 == WindowDragSourceType.FloatingWindowTitleBar)
				{
					if (this.x90b7873f2e7e44f6.IsKeyboardFocusWithin)
					{
						Keyboard.Focus(null);
					}
					SplitContainer splitContainer = new SplitContainer();
					FrameworkElement[] array = new FrameworkElement[this.x90b7873f2e7e44f6.RootContainer.Children.Count];
					this.x90b7873f2e7e44f6.RootContainer.Children.CopyTo(array, 0);
					this.x90b7873f2e7e44f6.RootContainer.Children.Clear();
					foreach (FrameworkElement element in array)
					{
						splitContainer.Children.Add(element);
					}
					this.x90b7873f2e7e44f6.Close();
					return splitContainer;
				}
				throw new NotSupportedException();
			}
			return windowGroup;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0003FE78 File Offset: 0x0003E278
		private void x89aeffb9ed58341e()
		{
			if (this.x98347fb858b62cb0 == null)
			{
				this.x3322b9ee1ea9ab48();
				this.x664ce73fb42454c2();
				return;
			}
			FrameworkElement x4bbc2c453c;
			Rect xda73fcb97c77d;
			x4025ca48d3c65c4e x520d41bf4dc059d;
			if (this.x98347fb858b62cb0.x07fc84161e9632ab(this.x37edfcebcc27afb7, out x4bbc2c453c, out xda73fcb97c77d, out x520d41bf4dc059d))
			{
				this.xeb89af5061730a4a(x4bbc2c453c, xda73fcb97c77d, x520d41bf4dc059d);
				return;
			}
			this.x3322b9ee1ea9ab48();
			this.x664ce73fb42454c2();
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0003FECC File Offset: 0x0003E2CC
		private void xc5a140008c7e32aa(MouseEventArgs xfbf34718e704c6bc)
		{
			DockingOperationBase dockingOperationBase = null;
			if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
			{
				goto IL_D4;
			}
			if (dockingOperationBase == null && this.x23f56f30b1768080.x3452082a8fecf97d)
			{
				dockingOperationBase = this.x23f56f30b1768080.xc5a140008c7e32aa(xfbf34718e704c6bc);
			}
			if (dockingOperationBase == null && this.xcf41e3cfab06539a.x3452082a8fecf97d)
			{
				dockingOperationBase = this.xcf41e3cfab06539a.xc5a140008c7e32aa(xfbf34718e704c6bc);
			}
			if (dockingOperationBase == null && this.x7039a7bd6c85fa61.x3452082a8fecf97d)
			{
				dockingOperationBase = this.x7039a7bd6c85fa61.xc5a140008c7e32aa(xfbf34718e704c6bc);
			}
			if (dockingOperationBase == null && this.xa053ccd3e0595cd7.x3452082a8fecf97d)
			{
				dockingOperationBase = this.xa053ccd3e0595cd7.xc5a140008c7e32aa(xfbf34718e704c6bc);
			}
			if (dockingOperationBase == null)
			{
				if (3 == 0)
				{
					goto IL_DA;
				}
				if (this.x59f2d1fbea6a675d.x3452082a8fecf97d)
				{
					dockingOperationBase = this.x59f2d1fbea6a675d.xc5a140008c7e32aa(xfbf34718e704c6bc);
				}
			}
			if (this.xff42ce14673f2ea6 != null && dockingOperationBase == null)
			{
				dockingOperationBase = this.x21384c266de47295[this.xff42ce14673f2ea6].xc5a140008c7e32aa(xfbf34718e704c6bc);
				goto IL_D4;
			}
			goto IL_D4;
			IL_2B:
			this.x98347fb858b62cb0 = dockingOperationBase;
			return;
			IL_D4:
			if (dockingOperationBase != null)
			{
				goto IL_2B;
			}
			IL_DA:
			if (this.x7c92c43084985bae.AllowFloat && this.x04722f8b1aeb722b)
			{
				Point point = xfbf34718e704c6bc.GetPosition(this.x7f72cb59f44fe44c);
				if (this.x7f72cb59f44fe44c.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.NativeWindow)
				{
					point = this.xa06f3b48a499e906(point);
				}
				if (this.x18465aea2e3748d3 == WindowDragSourceType.FloatingWindowTitleBar)
				{
					point.X -= this.xe4aec4924da44627.X;
					point.Y -= this.xe4aec4924da44627.Y;
				}
				else
				{
					point.X -= this.x37edfcebcc27afb7.FloatingSize.Width / 2.0;
					point.Y -= 5.0;
					if (2147483647 == 0)
					{
						return;
					}
				}
				dockingOperationBase = new FloatOperation(this.x7f72cb59f44fe44c, new Rect(point, this.xca874006c41dfe29), this.x90b7873f2e7e44f6 != null);
				goto IL_2B;
			}
			goto IL_2B;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x000400CC File Offset: 0x0003E4CC
		private Point xa06f3b48a499e906(Point x453900d44acb4365)
		{
			x453900d44acb4365 = this.x7f72cb59f44fe44c.PointToScreen(x453900d44acb4365);
			x453900d44acb4365 = PresentationSource.FromVisual(this.x7f72cb59f44fe44c).CompositionTarget.TransformFromDevice.Transform(x453900d44acb4365);
			return x453900d44acb4365;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00040108 File Offset: 0x0003E508
		private void x0241a4621c4f15a3(MouseEventArgs xfbf34718e704c6bc)
		{
			this.x04722f8b1aeb722b = true;
			if (this.x18465aea2e3748d3 != WindowDragSourceType.WindowTab)
			{
				goto IL_2D8;
			}
			int num = this.xfd154bcd21f8881e.GetInsertionPoint(xfbf34718e704c6bc);
			if (num == -1)
			{
				goto IL_2D8;
			}
			if (this.xfd154bcd21f8881e.Windows.Contains(this.x37edfcebcc27afb7) && this.xfd154bcd21f8881e.Windows.IndexOf(this.x37edfcebcc27afb7) < num)
			{
				num--;
			}
			if (this.xfd154bcd21f8881e.Windows.IndexOf(this.x37edfcebcc27afb7) != num)
			{
				if (this.x77fd0a4ebd4f0488)
				{
					this.xad7c5bed217f4380(new DockingOperationMoveEventArgs(num));
				}
				else
				{
					this.xfd154bcd21f8881e.Windows.Remove(this.x37edfcebcc27afb7);
					this.xfd154bcd21f8881e.Windows.Insert(num, this.x37edfcebcc27afb7);
					this.xfd154bcd21f8881e.SelectedWindow = this.x37edfcebcc27afb7;
				}
			}
			IL_290:
			this.x04722f8b1aeb722b = false;
			IL_2D8:
			if (this.x18465aea2e3748d3 == WindowDragSourceType.WindowGroupTitleBar && this.xfd154bcd21f8881e.IsInTitleBar(xfbf34718e704c6bc))
			{
				this.x04722f8b1aeb722b = false;
			}
			bool flag = this.x04722f8b1aeb722b && new Rect(0.0, 0.0, this.x7f72cb59f44fe44c.RenderSize.Width, this.x7f72cb59f44fe44c.RenderSize.Height).Contains(xfbf34718e704c6bc.GetPosition(this.x7f72cb59f44fe44c));
			this.x23f56f30b1768080.x3452082a8fecf97d = (flag && this.x7c92c43084985bae.AllowDockLeft);
			this.xcf41e3cfab06539a.x3452082a8fecf97d = (flag && this.x7c92c43084985bae.AllowDockRight);
			this.x7039a7bd6c85fa61.x3452082a8fecf97d = (flag && this.x7c92c43084985bae.AllowDockTop);
			this.xa053ccd3e0595cd7.x3452082a8fecf97d = (flag && this.x7c92c43084985bae.AllowDockBottom);
			WindowGroup xff42ce14673f2ea = null;
			WindowGroup[] array = this.x7cb100676a6d35c3;
			int i = 0;
			while (i < array.Length)
			{
				WindowGroup windowGroup = array[i];
				if (this.x04722f8b1aeb722b && new Rect(0.0, 0.0, windowGroup.RenderSize.Width, windowGroup.RenderSize.Height).Contains(xfbf34718e704c6bc.GetPosition(windowGroup)))
				{
					if (!false)
					{
						xff42ce14673f2ea = windowGroup;
						break;
					}
					goto IL_290;
				}
				else
				{
					i++;
				}
			}
			this.xff42ce14673f2ea6 = xff42ce14673f2ea;
			this.x59f2d1fbea6a675d.x3452082a8fecf97d = (this.x04722f8b1aeb722b && this.xff42ce14673f2ea6 == null && this.x37edfcebcc27afb7.DockSituation != DockSituation.Document && this.x7f72cb59f44fe44c.ClientBounds.Contains(xfbf34718e704c6bc.GetPosition(this.x7f72cb59f44fe44c)) && (this.Rules.AllowDockBottom || this.Rules.AllowDockLeft || this.Rules.AllowDockRight || this.Rules.AllowDockTop || this.Rules.AllowTab));
		}

		// Token: 0x04000137 RID: 311
		private DockSite x7f72cb59f44fe44c;

		// Token: 0x04000138 RID: 312
		private bool xa962380f08300c5b;

		// Token: 0x04000139 RID: 313
		private bool x77fd0a4ebd4f0488;

		// Token: 0x0400013A RID: 314
		private DockableWindow x37edfcebcc27afb7;

		// Token: 0x0400013B RID: 315
		private WindowGroup xfd154bcd21f8881e;

		// Token: 0x0400013C RID: 316
		private Point xe4aec4924da44627;

		// Token: 0x0400013D RID: 317
		private WindowDragSourceType x18465aea2e3748d3;

		// Token: 0x0400013E RID: 318
		private FloatingWindowAdapter x90b7873f2e7e44f6;

		// Token: 0x0400013F RID: 319
		private Size xca874006c41dfe29;

		// Token: 0x04000140 RID: 320
		private PositionPreview x8b4f3cb8df82acea;

		// Token: 0x04000141 RID: 321
		private WindowGroup[] x7cb100676a6d35c3;

		// Token: 0x04000142 RID: 322
		private DockingRules x7c92c43084985bae;

		// Token: 0x04000143 RID: 323
		private bool x7bff054be1315d44;

		// Token: 0x04000144 RID: 324
		private DockingOperationBase x98347fb858b62cb0;

		// Token: 0x04000145 RID: 325
		private bool x04722f8b1aeb722b;

		// Token: 0x04000146 RID: 326
		private x053c20cd4405f3ab x59f2d1fbea6a675d;

		// Token: 0x04000147 RID: 327
		private x053c20cd4405f3ab x23f56f30b1768080;

		// Token: 0x04000148 RID: 328
		private x053c20cd4405f3ab xcf41e3cfab06539a;

		// Token: 0x04000149 RID: 329
		private x053c20cd4405f3ab x7039a7bd6c85fa61;

		// Token: 0x0400014A RID: 330
		private x053c20cd4405f3ab xa053ccd3e0595cd7;

		// Token: 0x0400014B RID: 331
		private Dictionary<WindowGroup, x053c20cd4405f3ab> x21384c266de47295;

		// Token: 0x0400014C RID: 332
		private WindowGroup x91caa3fef49a06e2;

		// Token: 0x0400014D RID: 333
		private PositionPreviewAdorner x604d606ae0d8a4da;

		// Token: 0x0400014E RID: 334
		private x1300cf777c4b7322 x96d471a55259a6a5;

		// Token: 0x0400014F RID: 335
		private DockingHintDisplayStrategy xdcc1c910cea4f0f2;

		// Token: 0x04000150 RID: 336
		private VisualBrush x50a7bd075d9a6e31;

		// Token: 0x04000151 RID: 337
		private FrameworkElement x9fde6943eed61cee;

		// Token: 0x04000152 RID: 338
		private EventHandler<DockingOperationCompletedEventArgs> x77cc4d5e9b875e63;

		// Token: 0x04000153 RID: 339
		private EventHandler<DockingOperationMoveEventArgs> x04396fbce28e89e9;
	}
}

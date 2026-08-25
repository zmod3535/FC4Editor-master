using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x0200007A RID: 122
	public class UnpinnedTabStrip : ItemsControl
	{
		// Token: 0x060004E8 RID: 1256 RVA: 0x00048B14 File Offset: 0x00046F14
		static UnpinnedTabStrip()
		{
			UIElement.FocusableProperty.OverrideMetadata(typeof(UnpinnedTabStrip), new FrameworkPropertyMetadata(false));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(UnpinnedTabStrip), new FrameworkPropertyMetadata(typeof(UnpinnedTabStrip)));
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00048B88 File Offset: 0x00046F88
		public UnpinnedTabStrip()
		{
			this.popupTimer = new DispatcherTimer();
			this.popupTimer.Interval = TimeSpan.FromMilliseconds(400.0);
			this.popupTimer.Tick += this.OnPopupTimerTick;
			Binding binding = new Binding("WindowGroup.SelectedWindow.DockSite.OpenWindowsOnDrag");
			binding.Source = this;
			base.SetBinding(UIElement.AllowDropProperty, binding);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00048BF8 File Offset: 0x00046FF8
		protected override void OnDragEnter(DragEventArgs e)
		{
			e.Effects = DragDropEffects.None;
			base.OnDragEnter(e);
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00048C08 File Offset: 0x00047008
		protected override void OnDragOver(DragEventArgs e)
		{
			base.OnDragOver(e);
			if (!e.Handled)
			{
				DockableWindow windowAt = this.GetWindowAt(e.GetPosition(this));
				if (windowAt != null)
				{
					windowAt.SelectAndPopup(true);
					e.Handled = true;
					e.Effects = DragDropEffects.None;
				}
			}
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00048C4C File Offset: 0x0004704C
		private void OnPopupTimerTick(object sender, EventArgs e)
		{
			this.popupTimer.Stop();
			if (this.MouseOverWindow != null)
			{
				UnpinnedTray unpinnedTray = this.FindUnpinnedTray();
				if (unpinnedTray != null && unpinnedTray.DockSite.AllowPopupUnpinnedWindows)
				{
					unpinnedTray.ShowWindow(this.MouseOverWindow, false);
				}
			}
		}

		// Token: 0x060004ED RID: 1261 RVA: 0x00048C90 File Offset: 0x00047090
		private UnpinnedTray FindUnpinnedTray()
		{
			for (FrameworkElement frameworkElement = base.VisualParent as FrameworkElement; frameworkElement != null; frameworkElement = (VisualTreeHelper.GetParent(frameworkElement) as FrameworkElement))
			{
				UnpinnedTray unpinnedTray = frameworkElement as UnpinnedTray;
				if (unpinnedTray != null)
				{
					return unpinnedTray;
				}
			}
			return null;
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x00048CC8 File Offset: 0x000470C8
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return false;
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00048CCC File Offset: 0x000470CC
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x00048CE0 File Offset: 0x000470E0
		public WindowGroup WindowGroup
		{
			get
			{
				return (WindowGroup)base.GetValue(UnpinnedTabStrip.WindowGroupProperty);
			}
			set
			{
				base.SetValue(UnpinnedTabStrip.WindowGroupProperty, value);
			}
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x00048CF0 File Offset: 0x000470F0
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonDown(e);
			HitTestResult hitTestResult = VisualTreeHelper.HitTest(this, e.GetPosition(this));
			if (hitTestResult == null || hitTestResult.VisualHit == null)
			{
				return;
			}
			ContentPresenter contentPresenter = base.ContainerFromElement(hitTestResult.VisualHit) as ContentPresenter;
			DockableWindow dockableWindow = contentPresenter.Content as DockableWindow;
			UnpinnedTray unpinnedTray = this.FindUnpinnedTray();
			if (unpinnedTray != null)
			{
				if (unpinnedTray.DockSite.AllowPopupUnpinnedWindows)
				{
					unpinnedTray.ShowWindow(dockableWindow, true);
					return;
				}
				WindowGroup windowGroup = dockableWindow.Parent as WindowGroup;
				if (windowGroup != null)
				{
					windowGroup.Pinned = true;
					dockableWindow.Open(WindowOpenMethod.OpenSelectActivate);
				}
			}
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x00048D80 File Offset: 0x00047180
		private DockableWindow GetWindowAt(Point position)
		{
			HitTestResult hitTestResult = VisualTreeHelper.HitTest(this, position);
			if (hitTestResult != null)
			{
				ContentPresenter contentPresenter = base.ContainerFromElement(hitTestResult.VisualHit) as ContentPresenter;
				return contentPresenter.Content as DockableWindow;
			}
			return null;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x00048DB8 File Offset: 0x000471B8
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.MouseOverWindow = this.GetWindowAt(e.GetPosition(this));
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x00048DD4 File Offset: 0x000471D4
		protected override void OnMouseLeave(MouseEventArgs e)
		{
			base.OnMouseLeave(e);
			this.MouseOverWindow = null;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x00048DE4 File Offset: 0x000471E4
		protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnItemsChanged(e);
			this.MouseOverWindow = null;
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060004F6 RID: 1270 RVA: 0x00048DF4 File Offset: 0x000471F4
		// (set) Token: 0x060004F7 RID: 1271 RVA: 0x00048DFC File Offset: 0x000471FC
		private DockableWindow MouseOverWindow
		{
			get
			{
				return this.mouseOverWindow;
			}
			set
			{
				if (value != this.mouseOverWindow)
				{
					this.popupTimer.Stop();
					this.mouseOverWindow = value;
					if (this.mouseOverWindow != null)
					{
						this.popupTimer.Start();
					}
				}
			}
		}

		// Token: 0x0400029C RID: 668
		public static readonly DependencyProperty WindowGroupProperty = DependencyProperty.Register("WindowGroup", typeof(WindowGroup), typeof(UnpinnedTabStrip));

		// Token: 0x0400029D RID: 669
		private DockableWindow mouseOverWindow;

		// Token: 0x0400029E RID: 670
		private DispatcherTimer popupTimer;
	}
}

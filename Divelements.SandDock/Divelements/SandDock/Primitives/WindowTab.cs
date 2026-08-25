using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Divelements.SandDock.InteractiveDocking;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000010 RID: 16
	public class WindowTab : Control
	{
		// Token: 0x0600014A RID: 330 RVA: 0x00035864 File Offset: 0x00033C64
		static WindowTab()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowTab), new FrameworkPropertyMetadata(typeof(WindowTab)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(WindowTab), new FrameworkPropertyMetadata(false));
		}

		// Token: 0x0600014B RID: 331 RVA: 0x000358E8 File Offset: 0x00033CE8
		public WindowTab()
		{
			Binding binding = new Binding("Window.DockSite.OpenWindowsOnDrag");
			binding.Source = this;
			base.SetBinding(UIElement.AllowDropProperty, binding);
			binding = new Binding("Window.TabToolTip");
			binding.Source = this;
			base.SetBinding(FrameworkElement.ToolTipProperty, binding);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0003593C File Offset: 0x00033D3C
		protected override void OnDragEnter(DragEventArgs e)
		{
			e.Effects = DragDropEffects.None;
			base.OnDragEnter(e);
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0003594C File Offset: 0x00033D4C
		protected override void OnDragOver(DragEventArgs e)
		{
			base.OnDragOver(e);
			if (!e.Handled && this.Window != null)
			{
				e.Effects = DragDropEffects.None;
				this.Window.SelectAndPopup(false);
				e.Handled = true;
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00035980 File Offset: 0x00033D80
		private void OnWindowShouldActivate(object sender, EventArgs e)
		{
			base.BringIntoView();
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00035988 File Offset: 0x00033D88
		protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
		{
			base.OnMouseRightButtonUp(e);
			if (!e.Handled && this.Window != null)
			{
				e.Handled = true;
				this.Window.ShowContextMenu(this, new Rect(e.GetPosition(this), new Size(0.0, 0.0)));
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x000359E4 File Offset: 0x00033DE4
		protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
		{
			e.Handled = true;
			if (this.Window != null)
			{
				this.Window.SelectAndPopup(true);
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00035A04 File Offset: 0x00033E04
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
			if (e.MiddleButton == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Middle && this.Window != null && this.Window.AllowClose && this.Window.DockSite != null && this.Window.DockSite.AllowMiddleButtonClosure)
			{
				this.Window.Close();
				e.Handled = true;
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00035A74 File Offset: 0x00033E74
		protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
		{
			e.Handled = true;
			if (this.Window != null)
			{
				if (e.ClickCount == 1)
				{
					this.Window.SelectAndPopup(true);
				}
				else if (e.ClickCount == 2)
				{
					this.Window.UserToggleDockFloatingState();
					return;
				}
				this.dragPending = Mouse.Capture(this);
				this.dragStartPoint = e.GetPosition(this);
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00035AD8 File Offset: 0x00033ED8
		protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
		{
			base.OnMouseLeftButtonUp(e);
			if (base.IsMouseCaptured)
			{
				base.ReleaseMouseCapture();
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00035AF0 File Offset: 0x00033EF0
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.LeftButton == MouseButtonState.Pressed && this.dragPending)
			{
				Rect rect = new Rect(this.dragStartPoint, new Size(0.0, 0.0));
				rect.Inflate(SystemParameters.MinimumHorizontalDragDistance, SystemParameters.MinimumVerticalDragDistance);
				if (!rect.Contains(e.GetPosition(this)))
				{
					base.ReleaseMouseCapture();
					if (this.Window.DockSite != null)
					{
						DockingManager dockingManager = new DockingManager(this.Window.DockSite, this.Window);
						dockingManager.Start();
					}
				}
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00035B90 File Offset: 0x00033F90
		protected override void OnLostMouseCapture(MouseEventArgs e)
		{
			base.OnLostMouseCapture(e);
			this.dragPending = false;
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00035BA0 File Offset: 0x00033FA0
		private void OnIsSelectedChanged(object sender, EventArgs e)
		{
			this.UpdateZIndex();
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00035BA8 File Offset: 0x00033FA8
		internal void UpdateZIndex()
		{
			if (this.Window != null && this.Window.IsSelected)
			{
				Panel.SetZIndex(this, 99999);
				return;
			}
			Panel.SetZIndex(this, 0);
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00035BD4 File Offset: 0x00033FD4
		// (set) Token: 0x06000159 RID: 345 RVA: 0x00035BE8 File Offset: 0x00033FE8
		public DockableWindow Window
		{
			get
			{
				return (DockableWindow)base.GetValue(WindowTab.WindowProperty);
			}
			set
			{
				base.SetValue(WindowTab.WindowProperty, value);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00035BF8 File Offset: 0x00033FF8
		private static void OnWindowChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
		{
			WindowTab windowTab = (WindowTab)dp;
			DockableWindow dockableWindow = (DockableWindow)e.OldValue;
			DockableWindow dockableWindow2 = (DockableWindow)e.NewValue;
			if (dockableWindow != null)
			{
				dockableWindow.ShouldActivate -= windowTab.OnWindowShouldActivate;
				TypeDescriptor.GetProperties(dockableWindow)["IsSelected"].RemoveValueChanged(dockableWindow, new EventHandler(windowTab.OnIsSelectedChanged));
			}
			if (dockableWindow2 != null)
			{
				dockableWindow2.ShouldActivate += windowTab.OnWindowShouldActivate;
				TypeDescriptor.GetProperties(dockableWindow2)["IsSelected"].AddValueChanged(dockableWindow2, new EventHandler(windowTab.OnIsSelectedChanged));
			}
			windowTab.UpdateZIndex();
		}

		// Token: 0x0400005D RID: 93
		public static readonly DependencyProperty WindowProperty = DependencyProperty.Register("Window", typeof(DockableWindow), typeof(WindowTab), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(WindowTab.OnWindowChanged)));

		// Token: 0x0400005E RID: 94
		private bool dragPending;

		// Token: 0x0400005F RID: 95
		private Point dragStartPoint;
	}
}

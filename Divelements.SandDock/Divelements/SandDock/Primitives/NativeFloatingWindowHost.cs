using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Interop;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000034 RID: 52
	internal class NativeFloatingWindowHost : Window, x84f4377c0f1291fe
	{
		// Token: 0x14000014 RID: 20
		// (add) Token: 0x06000339 RID: 825 RVA: 0x0003E960 File Offset: 0x0003CD60
		// (remove) Token: 0x0600033A RID: 826 RVA: 0x0003E998 File Offset: 0x0003CD98
		public event EventHandler xa92b80a72ea23242
		{
			add
			{
				EventHandler eventHandler = this.ShowContextMenu;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.ShowContextMenu, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.ShowContextMenu;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.ShowContextMenu, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0003E9D0 File Offset: 0x0003CDD0
		static NativeFloatingWindowHost()
		{
			FrameworkElement.WidthProperty.OverrideMetadata(typeof(NativeFloatingWindowHost), new FrameworkPropertyMetadata(new PropertyChangedCallback(NativeFloatingWindowHost.OnWidthOrHeightChanged)));
			FrameworkElement.HeightProperty.OverrideMetadata(typeof(NativeFloatingWindowHost), new FrameworkPropertyMetadata(new PropertyChangedCallback(NativeFloatingWindowHost.OnWidthOrHeightChanged)));
			Window.ShowInTaskbarProperty.OverrideMetadata(typeof(NativeFloatingWindowHost), new FrameworkPropertyMetadata(false));
			Window.WindowStyleProperty.OverrideMetadata(typeof(NativeFloatingWindowHost), new FrameworkPropertyMetadata(WindowStyle.ToolWindow));
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0003EA68 File Offset: 0x0003CE68
		public NativeFloatingWindowHost(FloatingWindowAdapter floatingWindowAdapter)
		{
			this.floatingWindowAdapter = floatingWindowAdapter;
			Binding binding = new Binding();
			binding.Source = floatingWindowAdapter;
			binding.Path = new PropertyPath("PrimaryWindowGroup.SelectedWindow.Title", new object[0]);
			base.SetBinding(Window.TitleProperty, binding);
			base.Loaded += this.OnLoaded;
			Window window = Window.GetWindow(floatingWindowAdapter.DockSite);
			if (window != null)
			{
				base.Owner = window;
			}
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0003EADC File Offset: 0x0003CEDC
		public void xd0780bfc7027baa6(double x1965e484c4a7c6c6)
		{
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0003EAE0 File Offset: 0x0003CEE0
		public void xe410125f7519de90()
		{
			base.Show();
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0003EAE8 File Offset: 0x0003CEE8
		public void x2cc861f351e226ca(UIElement x4bbc2c453c470189)
		{
			base.Content = x4bbc2c453c470189;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0003EAF4 File Offset: 0x0003CEF4
		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			HwndSource hwndSource = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
			hwndSource.AddHook(new HwndSourceHook(this.WndProc));
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0003EB24 File Offset: 0x0003CF24
		private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			if (msg == 163 && wParam.ToInt32() == 2)
			{
				bool isKeyboardFocusWithin = base.IsKeyboardFocusWithin;
				if (isKeyboardFocusWithin)
				{
					Keyboard.Focus(null);
				}
				base.Hide();
				this.floatingWindowAdapter.ReturnToFixedLocations(isKeyboardFocusWithin);
				handled = true;
			}
			else if (msg == 161 && wParam.ToInt32() == 2)
			{
				base.Activate();
				this.StartInteractiveDock();
				handled = true;
			}
			else if (msg == 164 && wParam.ToInt32() == 2)
			{
				base.ReleaseMouseCapture();
				this.OnShowContextMenu(EventArgs.Empty);
				handled = true;
			}
			return IntPtr.Zero;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0003EBC0 File Offset: 0x0003CFC0
		private void StartInteractiveDock()
		{
			HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
			Point x12992900724b93dc = this.x12992900724b93dc;
			Point cursorPosition = this.GetCursorPosition();
			Point startPoint = new Point(cursorPosition.X - x12992900724b93dc.X, cursorPosition.Y - x12992900724b93dc.Y);
			this.floatingWindowAdapter.StartInteractiveDock(startPoint);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0003EC20 File Offset: 0x0003D020
		private Point GetCursorPosition()
		{
			HwndSource hwndSource = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
			x443cc432acaadb1d.POINT point;
			x443cc432acaadb1d.GetCursorPos(out point);
			Point point2 = new Point((double)point.X, (double)point.Y);
			point2 = hwndSource.CompositionTarget.TransformFromDevice.Transform(point2);
			return point2;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0003EC74 File Offset: 0x0003D074
		private static void OnWidthOrHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			NativeFloatingWindowHost nativeFloatingWindowHost = (NativeFloatingWindowHost)d;
			nativeFloatingWindowHost.floatingWindowAdapter.PropagateFloatingSizeToWindows();
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0003EC94 File Offset: 0x0003D094
		protected virtual void OnShowContextMenu(EventArgs e)
		{
			if (this.ShowContextMenu != null)
			{
				this.ShowContextMenu(this, e);
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0003ECAC File Offset: 0x0003D0AC
		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
			this.floatingWindowAdapter.PropagateFloatingLocationToWindows();
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000347 RID: 839 RVA: 0x0003ECC0 File Offset: 0x0003D0C0
		// (set) Token: 0x06000348 RID: 840 RVA: 0x0003ECD4 File Offset: 0x0003D0D4
		public Size xb1090c5821a633b5
		{
			get
			{
				return new Size(base.Width, base.Height);
			}
			set
			{
				if (value.Width != base.Width)
				{
					base.Width = value.Width;
				}
				if (value.Height != base.Height)
				{
					base.Height = value.Height;
				}
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000349 RID: 841 RVA: 0x0003ED10 File Offset: 0x0003D110
		// (set) Token: 0x0600034A RID: 842 RVA: 0x0003ED24 File Offset: 0x0003D124
		public Point x12992900724b93dc
		{
			get
			{
				return new Point(base.Left, base.Top);
			}
			set
			{
				if (value.X != base.Left || value.Y != base.Top)
				{
					NativeFloatingWindowHost.SetWindowLocation(this, value);
				}
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0003ED4C File Offset: 0x0003D14C
		internal static void SetWindowLocation(Window window, Point location)
		{
			FieldInfo field = typeof(Window).GetField("_updateHwndLocation", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				field.SetValue(window, false);
			}
			window.Left = location.X;
			if (field != null)
			{
				field.SetValue(window, true);
			}
			window.Top = location.Y;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0003EDAC File Offset: 0x0003D1AC
		void x84f4377c0f1291fe.add_Closing(CancelEventHandler A_1)
		{
			base.Closing += A_1;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0003EDB8 File Offset: 0x0003D1B8
		void x84f4377c0f1291fe.remove_Closing(CancelEventHandler A_1)
		{
			base.Closing -= A_1;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0003EDC4 File Offset: 0x0003D1C4
		void x84f4377c0f1291fe.add_Closed(EventHandler A_1)
		{
			base.Closed += A_1;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0003EDD0 File Offset: 0x0003D1D0
		void x84f4377c0f1291fe.remove_Closed(EventHandler A_1)
		{
			base.Closed -= A_1;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0003EDDC File Offset: 0x0003D1DC
		void x84f4377c0f1291fe.Close()
		{
			base.Close();
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0003EDE4 File Offset: 0x0003D1E4
		void x84f4377c0f1291fe.Hide()
		{
			base.Hide();
		}

		// Token: 0x0400012C RID: 300
		private FloatingWindowAdapter floatingWindowAdapter;

		// Token: 0x0400012D RID: 301
		private EventHandler ShowContextMenu;
	}
}

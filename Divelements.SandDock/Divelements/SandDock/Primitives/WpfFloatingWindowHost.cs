using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x0200004F RID: 79
	internal class WpfFloatingWindowHost : MdiWindowContainer, x84f4377c0f1291fe
	{
		// Token: 0x060003EF RID: 1007 RVA: 0x000426C0 File Offset: 0x00040AC0
		static WpfFloatingWindowHost()
		{
			MdiPanel.RestoredSizeProperty.OverrideMetadata(typeof(WpfFloatingWindowHost), new FrameworkPropertyMetadata(new PropertyChangedCallback(WpfFloatingWindowHost.OnRestoredSizeChanged)));
			MdiPanel.NormalPositionProperty.OverrideMetadata(typeof(WpfFloatingWindowHost), new FrameworkPropertyMetadata(new PropertyChangedCallback(WpfFloatingWindowHost.OnNormalPositionChanged)));
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x00042718 File Offset: 0x00040B18
		public WpfFloatingWindowHost(FloatingWindowAdapter floatingWindowAdapter)
		{
			this.floatingWindowAdapter = floatingWindowAdapter;
			base.CanMaximize = false;
			base.CanMinimize = false;
			base.WindowStyle = WindowStyle.ToolWindow;
			base.HasDropShadow = true;
			base.EnableMove = false;
			Binding binding = new Binding();
			binding.Source = floatingWindowAdapter;
			binding.Path = new PropertyPath("PrimaryWindowGroup.SelectedWindow.Title", new object[0]);
			base.SetBinding(MdiWindowContainer.TitleProperty, binding);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00042788 File Offset: 0x00040B88
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			if (this.templateTitleBar != null)
			{
				this.templateTitleBar.MouseLeftButtonDown -= this.OnTitleBarMouseLeftButtonDown;
			}
			this.templateTitleBar = (base.GetTemplateChild("PART_TitleBar") as FrameworkElement);
			if (this.templateTitleBar != null)
			{
				this.templateTitleBar.MouseLeftButtonDown += this.OnTitleBarMouseLeftButtonDown;
			}
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x000427F0 File Offset: 0x00040BF0
		private void OnTitleBarMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 2)
			{
				bool isKeyboardFocusWithin = base.IsKeyboardFocusWithin;
				if (isKeyboardFocusWithin)
				{
					Keyboard.Focus(null);
				}
				this.floatingWindowAdapter.ReturnToFixedLocations(isKeyboardFocusWithin);
				this.x8ffe90e7fbccfccd();
			}
			else
			{
				this.floatingWindowAdapter.StartInteractiveDock(e.GetPosition(this));
			}
			e.Handled = true;
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x00042844 File Offset: 0x00040C44
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x0004284C File Offset: 0x00040C4C
		public Point x12992900724b93dc
		{
			get
			{
				return MdiPanel.GetNormalPosition(this);
			}
			set
			{
				MdiPanel.SetNormalPosition(this, value);
			}
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00042858 File Offset: 0x00040C58
		private static void OnRestoredSizeChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
		{
			WpfFloatingWindowHost wpfFloatingWindowHost = (WpfFloatingWindowHost)element;
			wpfFloatingWindowHost.floatingWindowAdapter.PropagateFloatingSizeToWindows();
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x00042878 File Offset: 0x00040C78
		// (set) Token: 0x060003F7 RID: 1015 RVA: 0x00042880 File Offset: 0x00040C80
		public Size xb1090c5821a633b5
		{
			get
			{
				return MdiPanel.GetRestoredSize(this);
			}
			set
			{
				MdiPanel.SetRestoredSize(this, value);
			}
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0004288C File Offset: 0x00040C8C
		private static void OnNormalPositionChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
		{
			WpfFloatingWindowHost wpfFloatingWindowHost = (WpfFloatingWindowHost)element;
			wpfFloatingWindowHost.floatingWindowAdapter.PropagateFloatingLocationToWindows();
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x000428AC File Offset: 0x00040CAC
		public void x2cc861f351e226ca(UIElement x4bbc2c453c470189)
		{
			base.Content = x4bbc2c453c470189;
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x000428B8 File Offset: 0x00040CB8
		public void xe410125f7519de90()
		{
			this.floatingWindowAdapter.DockSite.WindowPanel.Children.Add(this);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x000428D8 File Offset: 0x00040CD8
		public void x8ffe90e7fbccfccd()
		{
			base.Close();
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x000428E4 File Offset: 0x00040CE4
		public void x5486e0b5e830d25c()
		{
			base.Visibility = Visibility.Collapsed;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x000428F0 File Offset: 0x00040CF0
		public void xd0780bfc7027baa6(double x1965e484c4a7c6c6)
		{
			base.Opacity = x1965e484c4a7c6c6;
		}

		// Token: 0x040001AB RID: 427
		private FloatingWindowAdapter floatingWindowAdapter;

		// Token: 0x040001AC RID: 428
		private FrameworkElement templateTitleBar;
	}
}

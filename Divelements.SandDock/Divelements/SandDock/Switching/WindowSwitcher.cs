using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Divelements.SandDock.Switching
{
	// Token: 0x02000056 RID: 86
	public abstract class WindowSwitcher : DependencyObject
	{
		// Token: 0x06000432 RID: 1074 RVA: 0x000443F4 File Offset: 0x000427F4
		protected WindowSwitcher(DockSite dockSite)
		{
			this.x7f72cb59f44fe44c = dockSite;
			List<DockableWindow> list = new List<DockableWindow>();
			List<DockableWindow> list2 = new List<DockableWindow>();
			List<DockableWindow> list3 = new List<DockableWindow>();
			foreach (DockableWindow dockableWindow in dockSite.GetAllWindows())
			{
				switch (xd679d9fc970c8f10.xb666df934bf80a36(dockableWindow))
				{
				case DockSituation.Docked:
				case DockSituation.Floating:
					list2.Add(dockableWindow);
					list3.Add(dockableWindow);
					break;
				case DockSituation.Document:
					list.Add(dockableWindow);
					list3.Add(dockableWindow);
					break;
				}
			}
			this.x17eeddd9ce647c3f = this.xf37381423b919e7d(list.ToArray());
			this.xae7b918ec6fecb78 = this.xf37381423b919e7d(list2.ToArray());
			this.xd5d01411b7422939 = this.xf37381423b919e7d(list3.ToArray());
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x000444B4 File Offset: 0x000428B4
		public DockSite DockSite
		{
			get
			{
				return this.x7f72cb59f44fe44c;
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000444BC File Offset: 0x000428BC
		private static void xfa576d2d46474a5a(DependencyObject xde5a5bc74acf4615, DependencyPropertyChangedEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.OldValue != null)
			{
				WindowSwitcher.xb61308a2bdf58946((DockableWindow)xfbf34718e704c6bc.OldValue, false);
			}
			if (xfbf34718e704c6bc.NewValue != null)
			{
				WindowSwitcher.xb61308a2bdf58946((DockableWindow)xfbf34718e704c6bc.NewValue, true);
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x000444F4 File Offset: 0x000428F4
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x000444FC File Offset: 0x000428FC
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

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x00044588 File Offset: 0x00042988
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x0004459C File Offset: 0x0004299C
		public DockableWindow PreviewingWindow
		{
			get
			{
				return (DockableWindow)base.GetValue(WindowSwitcher.PreviewingWindowProperty);
			}
			set
			{
				base.SetValue(WindowSwitcher.PreviewingWindowProperty, value);
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x000445AC File Offset: 0x000429AC
		private static void xb61308a2bdf58946(DockableWindow x76b3d9d2638e5ecd, bool xbcea506a33cf9111)
		{
			if (x76b3d9d2638e5ecd == null)
			{
				throw new ArgumentNullException("window");
			}
			x76b3d9d2638e5ecd.SetValue(WindowSwitcher.IsPreviewingPropertyKey, xbcea506a33cf9111);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000445D0 File Offset: 0x000429D0
		public static bool GetIsPreviewing(DockableWindow window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			return (bool)window.GetValue(WindowSwitcher.IsPreviewingProperty);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000445F0 File Offset: 0x000429F0
		private DockableWindow[] xf37381423b919e7d(DockableWindow[] x8fb2a5bf0df0416f)
		{
			DateTime[] array = new DateTime[x8fb2a5bf0df0416f.Length];
			for (int i = 0; i < x8fb2a5bf0df0416f.Length; i++)
			{
				array[i] = x8fb2a5bf0df0416f[i].MetaData.LastFocused;
			}
			Array.Sort<DateTime, DockableWindow>(array, x8fb2a5bf0df0416f);
			Array.Reverse(x8fb2a5bf0df0416f);
			return x8fb2a5bf0df0416f;
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x0004463C File Offset: 0x00042A3C
		public DockableWindow[] AllWindows
		{
			get
			{
				return this.xd5d01411b7422939;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x00044644 File Offset: 0x00042A44
		public DockableWindow[] DocumentWindows
		{
			get
			{
				return this.x17eeddd9ce647c3f;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x0004464C File Offset: 0x00042A4C
		public DockableWindow[] ToolWindows
		{
			get
			{
				return this.xae7b918ec6fecb78;
			}
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00044654 File Offset: 0x00042A54
		internal void x12cb12b5d2cad53d()
		{
			if (this.xaca68f1d554d41ca)
			{
				throw new InvalidOperationException();
			}
			this.CaptureElement = this.DockSite;
			if (this.CaptureElement == null)
			{
				return;
			}
			this.x41377194a117c423 = true;
			this.OnStarted();
			if (!this.x41377194a117c423)
			{
				this.CaptureElement = null;
				return;
			}
			this.x41377194a117c423 = false;
			this.xaca68f1d554d41ca = true;
			this.x37260007207b3fce = Keyboard.FocusedElement;
			this.DockSite.Focusable = true;
			this.DockSite.Focus();
			this.xf58ff9ce0e24a20c = this.DockSite;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x000446E0 File Offset: 0x00042AE0
		private void x4b2024e81568f6a9(object xe0292b9ed559da7d, MouseWheelEventArgs xfbf34718e704c6bc)
		{
			int num = xfbf34718e704c6bc.Delta / -120;
			if (num > 0)
			{
				num = 1;
			}
			else if (num < 0)
			{
				num = -1;
			}
			for (int i = 1; i <= Math.Abs(num); i++)
			{
				if (num > 0)
				{
					this.NextWindow();
				}
				else
				{
					this.PreviousWindow();
				}
			}
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00044728 File Offset: 0x00042B28
		private void x9d7ceda6e59df8ce(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			this.Stop();
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00044730 File Offset: 0x00042B30
		public void Stop()
		{
			if (this.x41377194a117c423)
			{
				this.x41377194a117c423 = false;
				return;
			}
			if (!this.xaca68f1d554d41ca)
			{
				throw new InvalidOperationException();
			}
			this.CaptureElement = null;
			this.xf58ff9ce0e24a20c = null;
			this.DockSite.ClearValue(UIElement.FocusableProperty);
			if (this.x37260007207b3fce != null)
			{
				this.x37260007207b3fce.Focus();
			}
			try
			{
				this.OnStopped();
			}
			finally
			{
				this.xaca68f1d554d41ca = false;
				this.PreviewingWindow = null;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x000447C0 File Offset: 0x00042BC0
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x000447C8 File Offset: 0x00042BC8
		protected UIElement CaptureElement
		{
			get
			{
				return this.xc13d0ca6d2bba1a6;
			}
			set
			{
				if (value != this.xc13d0ca6d2bba1a6)
				{
					if (this.xc13d0ca6d2bba1a6 != null)
					{
						this.xc13d0ca6d2bba1a6.LostMouseCapture -= this.x9d7ceda6e59df8ce;
						this.xc13d0ca6d2bba1a6.MouseWheel -= this.x4b2024e81568f6a9;
						Mouse.RemovePreviewMouseDownOutsideCapturedElementHandler(this.xc13d0ca6d2bba1a6, new MouseButtonEventHandler(this.x2da913c19742e895));
						this.xc13d0ca6d2bba1a6.ReleaseMouseCapture();
					}
					this.xc13d0ca6d2bba1a6 = value;
					if (this.xc13d0ca6d2bba1a6 != null)
					{
						if (!Mouse.Capture(this.xc13d0ca6d2bba1a6, CaptureMode.SubTree))
						{
							this.xc13d0ca6d2bba1a6 = null;
							return;
						}
						this.xc13d0ca6d2bba1a6.LostMouseCapture += this.x9d7ceda6e59df8ce;
						this.xc13d0ca6d2bba1a6.MouseWheel += this.x4b2024e81568f6a9;
						Mouse.AddPreviewMouseDownOutsideCapturedElementHandler(this.xc13d0ca6d2bba1a6, new MouseButtonEventHandler(this.x2da913c19742e895));
					}
				}
			}
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x000448A4 File Offset: 0x00042CA4
		private void x2da913c19742e895(object xe0292b9ed559da7d, MouseButtonEventArgs xfbf34718e704c6bc)
		{
			xfbf34718e704c6bc.Handled = true;
			this.Stop();
		}

		// Token: 0x06000446 RID: 1094
		protected abstract void OnStarted();

		// Token: 0x06000447 RID: 1095
		protected abstract void OnStopped();

		// Token: 0x06000448 RID: 1096
		protected abstract void NextWindow();

		// Token: 0x06000449 RID: 1097
		protected abstract void PreviousWindow();

		// Token: 0x0600044A RID: 1098 RVA: 0x000448B4 File Offset: 0x00042CB4
		protected virtual void ActivateWindow(DockableWindow window)
		{
			window.Open();
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x000448C0 File Offset: 0x00042CC0
		protected virtual void ProcessKeyDownEvent(KeyEventArgs e)
		{
			this.Stop();
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x000448C8 File Offset: 0x00042CC8
		public void Commit()
		{
			if (this.xaca68f1d554d41ca)
			{
				DockableWindow previewingWindow = this.PreviewingWindow;
				this.Stop();
				if (previewingWindow != null)
				{
					this.ActivateWindow(previewingWindow);
				}
			}
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x000448F4 File Offset: 0x00042CF4
		private void x776f8978bd67c752(object xe0292b9ed559da7d, KeyEventArgs xfbf34718e704c6bc)
		{
			if ((xfbf34718e704c6bc.Key == Key.LeftCtrl || xfbf34718e704c6bc.Key == Key.RightCtrl) && xfbf34718e704c6bc.IsUp)
			{
				this.Commit();
			}
			else if (xfbf34718e704c6bc.Key == this.DockSite.WindowSwitchKey)
			{
				if (xfbf34718e704c6bc.IsDown)
				{
					if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
					{
						this.PreviousWindow();
					}
					else
					{
						this.NextWindow();
					}
				}
			}
			else if (xfbf34718e704c6bc.Key != Key.LeftShift && xfbf34718e704c6bc.Key != Key.RightShift && xfbf34718e704c6bc.IsDown)
			{
				this.ProcessKeyDownEvent(xfbf34718e704c6bc);
			}
			xfbf34718e704c6bc.Handled = true;
		}

		// Token: 0x040001BF RID: 447
		public static readonly DependencyPropertyKey IsPreviewingPropertyKey = DependencyProperty.RegisterAttachedReadOnly("IsPreviewing", typeof(bool), typeof(WindowSwitcher), new FrameworkPropertyMetadata(false));

		// Token: 0x040001C0 RID: 448
		public static readonly DependencyProperty IsPreviewingProperty = WindowSwitcher.IsPreviewingPropertyKey.DependencyProperty;

		// Token: 0x040001C1 RID: 449
		public static readonly DependencyProperty PreviewingWindowProperty = DependencyProperty.Register("PreviewingWindow", typeof(DockableWindow), typeof(WindowSwitcher), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(WindowSwitcher.xfa576d2d46474a5a)));

		// Token: 0x040001C2 RID: 450
		private DockSite x7f72cb59f44fe44c;

		// Token: 0x040001C3 RID: 451
		private DockableWindow[] x17eeddd9ce647c3f;

		// Token: 0x040001C4 RID: 452
		private DockableWindow[] xae7b918ec6fecb78;

		// Token: 0x040001C5 RID: 453
		private DockableWindow[] xd5d01411b7422939;

		// Token: 0x040001C6 RID: 454
		private bool xaca68f1d554d41ca;

		// Token: 0x040001C7 RID: 455
		private bool x41377194a117c423;

		// Token: 0x040001C8 RID: 456
		private FrameworkElement x9fde6943eed61cee;

		// Token: 0x040001C9 RID: 457
		private IInputElement x37260007207b3fce;

		// Token: 0x040001CA RID: 458
		private UIElement xc13d0ca6d2bba1a6;
	}
}

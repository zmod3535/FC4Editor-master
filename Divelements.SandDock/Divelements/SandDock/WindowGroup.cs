using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using Divelements.SandDock.InteractiveDocking;
using Divelements.SandDock.Primitives;
using Divelements.SandDock.Resources;

namespace Divelements.SandDock
{
	// Token: 0x0200000E RID: 14
	[TemplatePart(Name = "PART_WindowList", Type = typeof(WindowList))]
	[ContentProperty("Windows")]
	[TemplatePart(Name = "PART_TitleBar", Type = typeof(FrameworkElement))]
	public class WindowGroup : Control
	{
		// Token: 0x06000103 RID: 259 RVA: 0x00034448 File Offset: 0x00032848
		static WindowGroup()
		{
			WindowGroup.ShowTabsProperty = WindowGroup.ShowTabsPropertyKey.DependencyProperty;
			WindowGroup.ShowTitleBarPropertyKey = DependencyProperty.RegisterReadOnly("ShowTitleBar", typeof(bool), typeof(WindowGroup), new FrameworkPropertyMetadata(true));
			WindowGroup.ShowTitleBarProperty = WindowGroup.ShowTitleBarPropertyKey.DependencyProperty;
			WindowGroup.PinnedProperty = DependencyProperty.Register("Pinned", typeof(bool), typeof(WindowGroup), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(WindowGroup.OnPinnedChanged), new CoerceValueCallback(WindowGroup.OnCoercePinned)));
			WindowGroup.AllowCollapsePropertyKey = DependencyProperty.RegisterReadOnly("AllowCollapse", typeof(bool), typeof(WindowGroup), new FrameworkPropertyMetadata(true));
			WindowGroup.AllowCollapseProperty = WindowGroup.AllowCollapsePropertyKey.DependencyProperty;
			WindowGroup.SelectedWindowProperty = DependencyProperty.Register("SelectedWindow", typeof(DockableWindow), typeof(WindowGroup), new FrameworkPropertyMetadata(new PropertyChangedCallback(WindowGroup.OnSelectedWindowChanged)), new ValidateValueCallback(WindowGroup.ValidateSelectedWindow));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowGroup), new FrameworkPropertyMetadata(typeof(WindowGroup)));
			WindowGroup.TrayProperty = DependencyProperty.RegisterAttached("Tray", typeof(UnpinnedTray), typeof(WindowGroup), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(WindowGroup.OnTrayChanged)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(WindowGroup), new FrameworkPropertyMetadata(false));
			WindowGroup.TogglePinCommand = new RoutedCommand("TogglePin", typeof(WindowGroup));
			CommandManager.RegisterClassCommandBinding(typeof(WindowGroup), new CommandBinding(WindowGroup.TogglePinCommand, new ExecutedRoutedEventHandler(WindowGroup.OnCommand), new CanExecuteRoutedEventHandler(WindowGroup.OnCanExecute)));
			CommandManager.RegisterClassCommandBinding(typeof(WindowGroup), new CommandBinding(DockableWindow.WindowOptionsCommand, new ExecutedRoutedEventHandler(WindowGroup.OnCommand), new CanExecuteRoutedEventHandler(WindowGroup.OnCanExecute)));
			CommandManager.RegisterClassInputBinding(typeof(WindowGroup), new InputBinding(DockableWindow.WindowOptionsCommand, new KeyGesture(Key.OemMinus, ModifierKeys.Alt)));
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000346E8 File Offset: 0x00032AE8
		public WindowGroup()
		{
			this.windows = new DockableWindowCollection(this);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000346FC File Offset: 0x00032AFC
		public WindowGroup(DockableWindow[] windows) : this()
		{
			if (windows == null)
			{
				throw new ArgumentNullException("windows");
			}
			foreach (DockableWindow item in windows)
			{
				this.Windows.Add(item);
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00034740 File Offset: 0x00032B40
		internal void FadeIn()
		{
			DoubleAnimation doubleAnimation = new DoubleAnimation(0.0, base.Opacity, new Duration(TimeSpan.FromMilliseconds(300.0)));
			doubleAnimation.FillBehavior = FillBehavior.Stop;
			base.BeginAnimation(UIElement.OpacityProperty, doubleAnimation);
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00034788 File Offset: 0x00032B88
		internal static void SetTray(UIElement element, UnpinnedTray tray)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.SetValue(WindowGroup.TrayProperty, tray);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000347A4 File Offset: 0x00032BA4
		internal static UnpinnedTray GetTray(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (UnpinnedTray)element.GetValue(WindowGroup.TrayProperty);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000347C4 File Offset: 0x00032BC4
		private static object OnCoercePinned(DependencyObject o, object value)
		{
			WindowGroup x4bbc2c453c = (WindowGroup)o;
			if (!xd679d9fc970c8f10.xd36c48a77e7b0108 && xd679d9fc970c8f10.xb666df934bf80a36(x4bbc2c453c) != DockSituation.Docked)
			{
				value = true;
			}
			return value;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000347F4 File Offset: 0x00032BF4
		private static void OnCommand(object sender, ExecutedRoutedEventArgs e)
		{
			WindowGroup windowGroup = (WindowGroup)sender;
			if (e.Command == WindowGroup.TogglePinCommand)
			{
				windowGroup.UserTogglePin();
				return;
			}
			if (e.Command == DockableWindow.WindowOptionsCommand && windowGroup.SelectedWindow != null)
			{
				windowGroup.ShowSelectedWindowContextMenu();
			}
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00034838 File Offset: 0x00032C38
		private void ShowSelectedWindowContextMenu()
		{
			FrameworkElement frameworkElement = base.GetTemplateChild("PART_OptionsButton") as FrameworkElement;
			if (frameworkElement != null)
			{
				this.SelectedWindow.ShowContextMenu(frameworkElement, Rect.Empty);
			}
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0003486C File Offset: 0x00032C6C
		private static void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			WindowGroup windowGroup = (WindowGroup)sender;
			if (e.Command == DockableWindow.WindowOptionsCommand)
			{
				e.CanExecute = true;
				return;
			}
			if (e.Command == WindowGroup.TogglePinCommand)
			{
				e.CanExecute = windowGroup.AllowCollapse;
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000348B0 File Offset: 0x00032CB0
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
			{
				if (e.Key == Key.Prior)
				{
					this.SelectPreviousWindow();
					e.Handled = true;
					return;
				}
				if (e.Key == Key.Next)
				{
					this.SelectNextWindow();
					e.Handled = true;
					return;
				}
			}
			base.OnKeyUp(e);
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00034900 File Offset: 0x00032D00
		private void SelectNextWindow()
		{
			if (this.SelectedWindow != null)
			{
				int num = this.Windows.IndexOf(this.SelectedWindow);
				num++;
				if (num >= this.Items.Count)
				{
					num = 0;
				}
				this.Windows[num].SelectAndPopup(true);
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00034950 File Offset: 0x00032D50
		private void SelectPreviousWindow()
		{
			if (this.SelectedWindow != null)
			{
				int num = this.Windows.IndexOf(this.SelectedWindow);
				num--;
				if (num < 0)
				{
					num = this.Items.Count - 1;
				}
				this.Windows[num].SelectAndPopup(true);
			}
		}

		// Token: 0x06000110 RID: 272 RVA: 0x000349A0 File Offset: 0x00032DA0
		public void SplitForElement(FrameworkElement element, Dock side)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			SplitContainer splitContainer = base.Parent as SplitContainer;
			if (splitContainer == null)
			{
				return;
			}
			int num = splitContainer.Children.IndexOf(this);
			if (side != System.Windows.Controls.Dock.Top)
			{
				if (side != System.Windows.Controls.Dock.Bottom)
				{
					goto IL_13;
				}
			}
			if (splitContainer.SplitterOrientation == Orientation.Horizontal)
			{
				goto IL_23;
			}
			IL_13:
			int num2;
			if ((side != System.Windows.Controls.Dock.Left && side != System.Windows.Controls.Dock.Right) || splitContainer.SplitterOrientation != Orientation.Vertical)
			{
				SplitContainer splitContainer2 = new SplitContainer();
				splitContainer2.SplitterOrientation = ((side == System.Windows.Controls.Dock.Top || side == System.Windows.Controls.Dock.Bottom) ? Orientation.Horizontal : Orientation.Vertical);
				SplitContainer.SetWorkingSize(splitContainer2, SplitContainer.GetWorkingSize(this));
				splitContainer.Children.Remove(this);
				splitContainer.Children.Insert(num, splitContainer2);
				splitContainer2.Children.Add(this);
				num2 = ((side == System.Windows.Controls.Dock.Right || side == System.Windows.Controls.Dock.Bottom) ? 1 : 0);
				splitContainer2.Children.Insert(num2, element);
				return;
			}
			IL_23:
			if (side == System.Windows.Controls.Dock.Right || side == System.Windows.Controls.Dock.Bottom)
			{
				bool flag;
				do
				{
					num++;
					flag = (((uint)num2 & 0U) == 0U);
				}
				while (!flag);
			}
			splitContainer.Children.Insert(num, element);
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00034AA0 File Offset: 0x00032EA0
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00034AB4 File Offset: 0x00032EB4
		[Browsable(false)]
		public bool ShowTitleBar
		{
			get
			{
				return (bool)base.GetValue(WindowGroup.ShowTitleBarProperty);
			}
			internal set
			{
				base.SetValue(WindowGroup.ShowTitleBarPropertyKey, value);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00034AC8 File Offset: 0x00032EC8
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00034ADC File Offset: 0x00032EDC
		[Browsable(false)]
		public bool ShowTabs
		{
			get
			{
				return (bool)base.GetValue(WindowGroup.ShowTabsProperty);
			}
			internal set
			{
				base.SetValue(WindowGroup.ShowTabsPropertyKey, value);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00034AF0 File Offset: 0x00032EF0
		[Obsolete("Use the Windows property instead.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DockableWindowCollection Items
		{
			get
			{
				return this.windows;
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00034AF8 File Offset: 0x00032EF8
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Browsable(false)]
		public DockableWindowCollection Windows
		{
			get
			{
				return this.windows;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00034B00 File Offset: 0x00032F00
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00034B14 File Offset: 0x00032F14
		[Browsable(false)]
		public bool AllowCollapse
		{
			get
			{
				return (bool)base.GetValue(WindowGroup.AllowCollapseProperty);
			}
			private set
			{
				base.SetValue(WindowGroup.AllowCollapsePropertyKey, value);
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00034B28 File Offset: 0x00032F28
		internal void RecordMetaData()
		{
			foreach (DockableWindow dockableWindow in this.Windows)
			{
				dockableWindow.RecordMetaData();
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00034B80 File Offset: 0x00032F80
		internal static void PropagateDockSituationChanged(WindowGroup windowGroup)
		{
			foreach (DockableWindow dockableWindow in windowGroup.Windows)
			{
				dockableWindow.RecordMetaData();
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00034BD8 File Offset: 0x00032FD8
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00034C00 File Offset: 0x00033000
		internal Guid Guid
		{
			get
			{
				if (this.guid == Guid.Empty)
				{
					this.guid = Guid.NewGuid();
				}
				return this.guid;
			}
			set
			{
				this.guid = value;
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00034C0C File Offset: 0x0003300C
		internal int GetInsertionPoint(MouseEventArgs e)
		{
			WindowList windowList = base.GetTemplateChild("PART_WindowList") as WindowList;
			if (windowList != null)
			{
				return windowList.GetInsertionPoint(e);
			}
			return -1;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00034C38 File Offset: 0x00033038
		internal bool IsInTitleBar(MouseEventArgs e)
		{
			FrameworkElement frameworkElement = base.GetTemplateChild("PART_TitleBar") as FrameworkElement;
			return frameworkElement != null && new Rect(new Point(0.0, 0.0), frameworkElement.RenderSize).Contains(e.GetPosition(frameworkElement));
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00034C8C File Offset: 0x0003308C
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			if (this.titleBar != null)
			{
				this.titleBar.PreviewMouseDown -= this.OnTitleBarPreviewMouseDown;
				this.titleBar.MouseLeftButtonDown -= this.OnTitleBarMouseLeftButtonDown;
				this.titleBar.MouseRightButtonUp += this.OnTitleBarMouseRightButtonUp;
			}
			this.titleBar = (base.GetTemplateChild("PART_TitleBar") as FrameworkElement);
			if (this.titleBar != null)
			{
				this.titleBar.PreviewMouseDown += this.OnTitleBarPreviewMouseDown;
				this.titleBar.MouseLeftButtonDown += this.OnTitleBarMouseLeftButtonDown;
				this.titleBar.MouseRightButtonUp += this.OnTitleBarMouseRightButtonUp;
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00034D50 File Offset: 0x00033150
		private void OnTitleBarMouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (this.SelectedWindow != null)
			{
				this.SelectedWindow.ShowContextMenu(this.titleBar, new Rect(e.GetPosition(this.titleBar), new Size(0.0, 0.0)));
				e.Handled = true;
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00034DA8 File Offset: 0x000331A8
		private void UserToggleDockFloatingState()
		{
			DockingRules dockingRules = new DockingRules();
			DockingRules[] array = new DockingRules[this.Items.Count];
			int i;
			for (i = 0; i < this.Items.Count; i++)
			{
				array[i] = this.Items[i].DockingRules;
			}
			dockingRules.xd5da23b762ce52a2(array);
			switch (xd679d9fc970c8f10.xb666df934bf80a36(this))
			{
			case DockSituation.Docked:
			case DockSituation.Document:
				if (!dockingRules.AllowFloat)
				{
					return;
				}
				if (this.Items.Count == 1)
				{
					this.SelectedWindow.Float(WindowOpenMethod.OpenSelectActivate);
				}
				else
				{
					if (this.SelectedWindow.DockSite != null && this.SelectedWindow.DockSite.AllowFloatingGroups)
					{
						this.Float(WindowOpenMethod.OpenSelectActivate);
						return;
					}
					return;
				}
				break;
			case DockSituation.Floating:
			{
				if (this.SelectedWindow.MetaData.LastFixedDockSide != System.Windows.Controls.Dock.Left || !dockingRules.AllowDockLeft)
				{
					if (this.SelectedWindow.MetaData.LastFixedDockSide == System.Windows.Controls.Dock.Right)
					{
						if (2 == 0)
						{
							break;
						}
						if (dockingRules.AllowDockRight)
						{
							goto IL_47;
						}
						if (((uint)i & 0U) != 0U)
						{
							return;
						}
					}
					if ((this.SelectedWindow.MetaData.LastFixedDockSide != System.Windows.Controls.Dock.Top || !dockingRules.AllowDockTop) && (this.SelectedWindow.MetaData.LastFixedDockSide != System.Windows.Controls.Dock.Bottom || !dockingRules.AllowDockBottom))
					{
						return;
					}
				}
				IL_47:
				WindowGroup windowGroup = this;
				DockableWindow dockableWindow = (this.Items.Count == 1) ? this.Items[0] : null;
				this.Dock(WindowOpenMethod.OpenSelectActivate);
				if (dockableWindow != null)
				{
					windowGroup = (WindowGroup)dockableWindow.Parent;
				}
				windowGroup.FadeIn();
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00034F4C File Offset: 0x0003334C
		private void OnTitleBarMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			e.Handled = true;
			if (e.ClickCount == 2)
			{
				this.UserToggleDockFloatingState();
				return;
			}
			if (this.SelectedWindow != null && this.SelectedWindow.DockSite != null)
			{
				DockingManager dockingManager = new DockingManager(this.SelectedWindow.DockSite, this);
				dockingManager.Start();
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00034FA0 File Offset: 0x000333A0
		public void Float(WindowOpenMethod openMethod)
		{
			this.EnsureDockSite();
			this.Float(new Rect(this.SelectedWindow.GetFloatingLocation(), this.SelectedWindow.FloatingSize), openMethod);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00034FCC File Offset: 0x000333CC
		public void Float(Rect bounds, WindowOpenMethod openMethod)
		{
			this.EnsureDockSite();
			if (this.SelectedWindow.DockSituation == DockSituation.Floating)
			{
				return;
			}
			xd679d9fc970c8f10.xaf92e3c82f3efd70(this);
			Window window = Window.GetWindow(this.SelectedWindow.DockSite);
			if (window != null)
			{
				FocusManager.SetFocusedElement(window, null);
			}
			Keyboard.Focus(null);
			FloatingWindowAdapter floatingWindowAdapter = this.SelectedWindow.DockSite.CreateFloatingWindow(Guid.NewGuid());
			floatingWindowAdapter.RootContainer.Children.Add(this);
			floatingWindowAdapter.FloatingLocation = bounds.Location;
			floatingWindowAdapter.FloatingSize = bounds.Size;
			floatingWindowAdapter.Open();
			if (openMethod != WindowOpenMethod.Background)
			{
				base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new EventHandler(this.OnBackgroundSelectAndPopup), openMethod == WindowOpenMethod.OpenSelectActivate, null);
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00035084 File Offset: 0x00033484
		private void OnBackgroundSelectAndPopup(object sender, EventArgs e)
		{
			bool activate = (bool)sender;
			if (this.SelectedWindow != null && this.SelectedWindow.DockSituation == DockSituation.Floating)
			{
				this.SelectedWindow.SelectAndPopup(activate);
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000350BC File Offset: 0x000334BC
		private void EnsureDockSite()
		{
			if (this.SelectedWindow == null || this.SelectedWindow.DockSite == null)
			{
				throw new InvalidOperationException(Messages.ExceptionDockSiteRequired);
			}
			xd679d9fc970c8f10.x68e583994d0940db();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000350E4 File Offset: 0x000334E4
		public void Remove()
		{
			xd679d9fc970c8f10.xaf92e3c82f3efd70(this);
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000350EC File Offset: 0x000334EC
		public void Dock(WindowOpenMethod openMethod)
		{
			this.EnsureDockSite();
			if (xd679d9fc970c8f10.xb666df934bf80a36(this) == DockSituation.Docked)
			{
				return;
			}
			xd679d9fc970c8f10.xaf92e3c82f3efd70(this);
			if (this.Items.Count == 1)
			{
				this.SelectedWindow.Dock(openMethod);
				return;
			}
			x5678bb8d80c0f12e x5678bb8d80c0f12e = xd679d9fc970c8f10.x4689c8634e31fc55(this.SelectedWindow.DockSite, this.SelectedWindow.MetaData);
			SplitContainer.SetWorkingSize(this, this.SelectedWindow.MetaData.xe62a3d24e0fde928.x3a4e0c379519d4a2);
			x5678bb8d80c0f12e.xd301f1060b3751dc.Children.Insert(x5678bb8d80c0f12e.xd1bdf42207dd3638, this);
			if (openMethod != WindowOpenMethod.Background)
			{
				this.SelectedWindow.SelectAndPopup(openMethod == WindowOpenMethod.OpenSelectActivate);
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0003518C File Offset: 0x0003358C
		internal void AddLogicalChild(DockableWindow window)
		{
			base.AddLogicalChild(window);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00035198 File Offset: 0x00033598
		internal void RemoveLogicalChild(DockableWindow window)
		{
			base.RemoveLogicalChild(window);
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600012B RID: 299 RVA: 0x000351A4 File Offset: 0x000335A4
		protected override IEnumerator LogicalChildren
		{
			get
			{
				return this.windows.GetEnumerator();
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000351B4 File Offset: 0x000335B4
		internal void UserTogglePin()
		{
			this.Pinned = !this.Pinned;
			if (!this.Pinned && xd679d9fc970c8f10.xb666df934bf80a36(this) == DockSituation.Docked)
			{
				UnpinnedTray tray = WindowGroup.GetTray(this);
				if (tray != null && tray.DockSite.AllowPopupUnpinnedWindows)
				{
					tray.ShowWindowPreview(this);
				}
				if (this.SelectedWindow != null && this.SelectedWindow.DockSite != null)
				{
					this.SelectedWindow.DockSite.ActivatePrimaryDocument();
				}
			}
			if (this.Pinned && xd679d9fc970c8f10.xb666df934bf80a36(this) == DockSituation.Docked)
			{
				base.UpdateLayout();
				this.FadeIn();
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00035244 File Offset: 0x00033644
		private void OnTitleBarPreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (this.SelectedWindow != null)
			{
				this.SelectedWindow.SelectAndPopup(true);
			}
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0003525C File Offset: 0x0003365C
		private static void OnPinnedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			WindowGroup windowGroup = (WindowGroup)d;
			windowGroup.OnPinnedChanged(e);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00035278 File Offset: 0x00033678
		private void OnPinnedChanged(DependencyPropertyChangedEventArgs e)
		{
			SplitContainer splitContainer = base.Parent as SplitContainer;
			if (splitContainer != null)
			{
				splitContainer.OnDescendantPinnedChanged();
			}
			bool flag = (bool)e.OldValue;
			bool flag2 = (bool)e.NewValue;
			if (this.Tray != null && flag != flag2)
			{
				if (flag2)
				{
					this.Tray.RemoveWindowGroup(this);
					if (splitContainer != null)
					{
						splitContainer.AddVisualChildInternal(this);
						return;
					}
				}
				else
				{
					if (splitContainer != null)
					{
						splitContainer.RemoveVisualChildInternal(this);
					}
					this.Tray.AddWindowGroup(this);
				}
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000352F0 File Offset: 0x000336F0
		private static void OnTrayChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			WindowGroup windowGroup = d as WindowGroup;
			if (windowGroup != null)
			{
				windowGroup.OnTrayChanged(e);
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00035310 File Offset: 0x00033710
		private void OnTrayChanged(DependencyPropertyChangedEventArgs e)
		{
			UnpinnedTray unpinnedTray = (UnpinnedTray)e.OldValue;
			UnpinnedTray unpinnedTray2 = (UnpinnedTray)e.NewValue;
			if (!this.Pinned && unpinnedTray2 != unpinnedTray)
			{
				if (unpinnedTray != null)
				{
					unpinnedTray.RemoveWindowGroup(this);
				}
				if (unpinnedTray2 != null)
				{
					unpinnedTray2.AddWindowGroup(this);
				}
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00035358 File Offset: 0x00033758
		// (set) Token: 0x06000133 RID: 307 RVA: 0x0003536C File Offset: 0x0003376C
		[Category("Common Properties")]
		public bool Pinned
		{
			get
			{
				return (bool)base.GetValue(WindowGroup.PinnedProperty);
			}
			set
			{
				base.SetValue(WindowGroup.PinnedProperty, value);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00035380 File Offset: 0x00033780
		internal UnpinnedTray Tray
		{
			get
			{
				return (UnpinnedTray)base.GetValue(WindowGroup.TrayProperty);
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00035394 File Offset: 0x00033794
		// (set) Token: 0x06000136 RID: 310 RVA: 0x000353A8 File Offset: 0x000337A8
		[Browsable(false)]
		public bool HasSingleItem
		{
			get
			{
				return (bool)base.GetValue(WindowGroup.HasSingleItemProperty);
			}
			private set
			{
				base.SetValue(WindowGroup.HasSingleItemPropertyKey, value);
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000137 RID: 311 RVA: 0x000353BC File Offset: 0x000337BC
		// (set) Token: 0x06000138 RID: 312 RVA: 0x000353C4 File Offset: 0x000337C4
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Use the SelectedWindow property instead.")]
		public object SelectedItem
		{
			get
			{
				return this.SelectedWindow;
			}
			set
			{
				this.SelectedWindow = (value as DockableWindow);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000139 RID: 313 RVA: 0x000353D4 File Offset: 0x000337D4
		// (set) Token: 0x0600013A RID: 314 RVA: 0x000353E8 File Offset: 0x000337E8
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DockableWindow SelectedWindow
		{
			get
			{
				return (DockableWindow)base.GetValue(WindowGroup.SelectedWindowProperty);
			}
			set
			{
				base.SetValue(WindowGroup.SelectedWindowProperty, value);
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x000353F8 File Offset: 0x000337F8
		private static bool ValidateSelectedWindow(object value)
		{
			DockableWindow dockableWindow = (DockableWindow)value;
			return true;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00035404 File Offset: 0x00033804
		private static void OnSelectedWindowChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
		{
			WindowGroup windowGroup = (WindowGroup)element;
			DockableWindow dockableWindow = (DockableWindow)e.OldValue;
			DockableWindow dockableWindow2 = (DockableWindow)e.NewValue;
			if (dockableWindow != null)
			{
				dockableWindow.IsSelected = false;
			}
			if (dockableWindow2 != null)
			{
				dockableWindow2.IsSelected = true;
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00035448 File Offset: 0x00033848
		internal void NotifyChildrenChanged()
		{
			WindowGroup.PropagateDockSituationChanged(this);
			if (this.SelectedWindow == null && this.Windows.Count != 0)
			{
				this.SelectedWindow = this.Windows[0];
			}
			if (this.SelectedWindow != null && !this.Windows.Contains(this.SelectedWindow))
			{
				if (this.Windows.Count != 0)
				{
					this.SelectedWindow = this.Windows[0];
				}
				else
				{
					this.SelectedWindow = null;
				}
			}
			this.HasSingleItem = (this.Windows.Count == 1);
			this.EvaluateAllowCollapse();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x000354E0 File Offset: 0x000338E0
		internal void NotifyChildAllowCollapseChanged()
		{
			this.EvaluateAllowCollapse();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x000354E8 File Offset: 0x000338E8
		private void EvaluateAllowCollapse()
		{
			bool allowCollapse = true;
			foreach (DockableWindow dockableWindow in this.Windows)
			{
				if (!dockableWindow.AllowCollapse)
				{
					allowCollapse = false;
					break;
				}
			}
			this.AllowCollapse = allowCollapse;
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00035550 File Offset: 0x00033950
		internal bool DoAllChildrenAllowMerge()
		{
			foreach (DockableWindow dockableWindow in this.Windows)
			{
				if (!dockableWindow.DockingRules.AllowMerge)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0400004D RID: 77
		internal static readonly DependencyProperty TrayProperty;

		// Token: 0x0400004E RID: 78
		private static readonly DependencyPropertyKey HasSingleItemPropertyKey = DependencyProperty.RegisterReadOnly("HasSingleItem", typeof(bool), typeof(WindowGroup), new FrameworkPropertyMetadata(false));

		// Token: 0x0400004F RID: 79
		public static readonly DependencyProperty HasSingleItemProperty = WindowGroup.HasSingleItemPropertyKey.DependencyProperty;

		// Token: 0x04000050 RID: 80
		public static readonly DependencyProperty ShowTabsProperty;

		// Token: 0x04000051 RID: 81
		private static readonly DependencyPropertyKey ShowTabsPropertyKey = DependencyProperty.RegisterReadOnly("ShowTabs", typeof(bool), typeof(WindowGroup), new FrameworkPropertyMetadata(true));

		// Token: 0x04000052 RID: 82
		public static readonly DependencyProperty ShowTitleBarProperty;

		// Token: 0x04000053 RID: 83
		private static readonly DependencyPropertyKey ShowTitleBarPropertyKey;

		// Token: 0x04000054 RID: 84
		public static readonly DependencyProperty PinnedProperty;

		// Token: 0x04000055 RID: 85
		public static readonly DependencyProperty AllowCollapseProperty;

		// Token: 0x04000056 RID: 86
		private static readonly DependencyPropertyKey AllowCollapsePropertyKey;

		// Token: 0x04000057 RID: 87
		public static readonly DependencyProperty SelectedWindowProperty;

		// Token: 0x04000058 RID: 88
		public static readonly RoutedCommand TogglePinCommand;

		// Token: 0x04000059 RID: 89
		private FrameworkElement titleBar;

		// Token: 0x0400005A RID: 90
		private Guid guid;

		// Token: 0x0400005B RID: 91
		private DockableWindowCollection windows;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Divelements.SandDock.Automation;
using Divelements.SandDock.Primitives;
using Divelements.SandDock.Resources;

namespace Divelements.SandDock
{
	// Token: 0x02000007 RID: 7
	[DefaultProperty("Title")]
	[ContentProperty("Child")]
	public class DockableWindow : Control
	{
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000032 RID: 50 RVA: 0x000311EC File Offset: 0x0002F5EC
		// (remove) Token: 0x06000033 RID: 51 RVA: 0x00031224 File Offset: 0x0002F624
		public event CancelEventHandler Closing;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000034 RID: 52 RVA: 0x0003125C File Offset: 0x0002F65C
		// (remove) Token: 0x06000035 RID: 53 RVA: 0x00031294 File Offset: 0x0002F694
		public event EventHandler Closed;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000036 RID: 54 RVA: 0x000312CC File Offset: 0x0002F6CC
		// (remove) Token: 0x06000037 RID: 55 RVA: 0x00031304 File Offset: 0x0002F704
		public event EventHandler DockSituationChanged;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000038 RID: 56 RVA: 0x0003133C File Offset: 0x0002F73C
		// (remove) Token: 0x06000039 RID: 57 RVA: 0x00031374 File Offset: 0x0002F774
		internal event EventHandler ShouldActivate;

		// Token: 0x0600003A RID: 58 RVA: 0x000313AC File Offset: 0x0002F7AC
		static DockableWindow()
		{
			do
			{
				DockableWindow.OpenCommand = new RoutedCommand("Open", typeof(DockableWindow));
				DockableWindow.WindowOptionsCommand = new RoutedCommand("WindowOptions", typeof(DockableWindow));
				FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DockableWindow), new FrameworkPropertyMetadata(typeof(DockableWindow)));
				KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof(DockableWindow), new FrameworkPropertyMetadata(KeyboardNavigationMode.Cycle));
				KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(DockableWindow), new FrameworkPropertyMetadata(KeyboardNavigationMode.Cycle));
				Control.BackgroundProperty.OverrideMetadata(typeof(DockableWindow), new FrameworkPropertyMetadata(SystemColors.ControlBrush));
				DockableWindow.IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(DockableWindow));
				DockableWindow.TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DockableWindow), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(DockableWindow.OnTitleChanged)));
				DockableWindow.DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(DockableWindow), new FrameworkPropertyMetadata(string.Empty));
				DockableWindow.TabTextProperty = DependencyProperty.Register("TabText", typeof(string), typeof(DockableWindow), new FrameworkPropertyMetadata(string.Empty));
				DockableWindow.ImageProperty = DependencyProperty.Register("Image", typeof(ImageSource), typeof(DockableWindow), new FrameworkPropertyMetadata(new PropertyChangedCallback(DockableWindow.OnImageChanged)));
				DockableWindow.FloatingLocationProperty = DependencyProperty.Register("FloatingLocation", typeof(Point?), typeof(DockableWindow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DockableWindow.OnFloatingLocationChanged)));
				DockableWindow.FloatingSizeProperty = DependencyProperty.Register("FloatingSize", typeof(Size), typeof(DockableWindow), new FrameworkPropertyMetadata(new Size(250.0, 370.0), new PropertyChangedCallback(DockableWindow.OnFloatingSizeChanged)));
				do
				{
					DockableWindow.DockSiteProperty = DependencyProperty.Register("DockSite", typeof(DockSite), typeof(DockableWindow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DockableWindow.OnDockSiteChanged)));
					DockableWindow.ContentSizeProperty = DependencyProperty.Register("ContentSize", typeof(double), typeof(DockableWindow), new FrameworkPropertyMetadata(225.0, new PropertyChangedCallback(DockableWindow.OnContentSizeChanged)), new ValidateValueCallback(DockableWindow.OnValidateContentSize));
					DockableWindow.DockingRulesProperty = DependencyProperty.Register("DockingRules", typeof(DockingRules), typeof(DockableWindow), new FrameworkPropertyMetadata(new DockingRules(true, false, true)), new ValidateValueCallback(DockableWindow.OnValidateDockingRules));
					DockableWindow.DockSituationPropertyKey = DependencyProperty.RegisterAttachedReadOnly("DockSituation", typeof(DockSituation), typeof(DockableWindow), new FrameworkPropertyMetadata(DockSituation.None, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DockableWindow.OnDockSituationChanged)));
					DockableWindow.DockSituationProperty = DockableWindow.DockSituationPropertyKey.DependencyProperty;
				}
				while (false);
				DockableWindow.IsLastActiveWindowPropertyKey = DependencyProperty.RegisterReadOnly("IsLastActiveWindow", typeof(bool), typeof(DockableWindow), new FrameworkPropertyMetadata(false));
				DockableWindow.IsLastActiveWindowProperty = DockableWindow.IsLastActiveWindowPropertyKey.DependencyProperty;
				if (2147483647 != 0)
				{
					DockableWindow.AllowCloseProperty = DependencyProperty.Register("AllowClose", typeof(bool), typeof(DockableWindow), new FrameworkPropertyMetadata(true));
					DockableWindow.ChildProperty = DependencyProperty.Register("Child", typeof(UIElement), typeof(DockableWindow), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DockableWindow.OnChildChanged)));
					DockableWindow.TabForegroundProperty = DependencyProperty.Register("TabForeground", typeof(Brush), typeof(DockableWindow));
					DockableWindow.AllowCollapseProperty = DependencyProperty.Register("AllowCollapse", typeof(bool), typeof(DockableWindow), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(DockableWindow.OnAllowCollapseChanged)));
					DockableWindow.HasLocalImagePropertyKey = DependencyProperty.RegisterReadOnly("HasLocalImage", typeof(bool), typeof(DockableWindow), new FrameworkPropertyMetadata(false));
					DockableWindow.HasLocalImageProperty = DockableWindow.HasLocalImagePropertyKey.DependencyProperty;
				}
				DockableWindow.TabBackgroundProperty = DependencyProperty.Register("TabBackground", typeof(Brush), typeof(DockableWindow), new FrameworkPropertyMetadata(null));
				DockableWindow.LastDockSidePropertyKey = DependencyProperty.RegisterReadOnly("LastDockSide", typeof(Dock), typeof(DockableWindow), new FrameworkPropertyMetadata(System.Windows.Controls.Dock.Right));
				DockableWindow.LastDockSideProperty = DockableWindow.LastDockSidePropertyKey.DependencyProperty;
				DockableWindow.ShowOptionsButtonProperty = DependencyProperty.Register("ShowOptionsButton", typeof(bool), typeof(DockableWindow), new FrameworkPropertyMetadata(true));
				DockableWindow.TabToolTipProperty = DependencyProperty.Register("TabToolTip", typeof(object), typeof(DockableWindow), new FrameworkPropertyMetadata(null));
			}
			while (-1 == 0);
			if (!false)
			{
				CommandManager.RegisterClassCommandBinding(typeof(DockableWindow), new CommandBinding(WindowGroup.TogglePinCommand, new ExecutedRoutedEventHandler(DockableWindow.OnCommand), new CanExecuteRoutedEventHandler(DockableWindow.OnCanExecute)));
				CommandManager.RegisterClassCommandBinding(typeof(DockableWindow), new CommandBinding(DockableWindow.OpenCommand, new ExecutedRoutedEventHandler(DockableWindow.OnCommand), new CanExecuteRoutedEventHandler(DockableWindow.OnCanExecute)));
				CommandManager.RegisterClassCommandBinding(typeof(DockableWindow), new CommandBinding(DockableWindow.CloseCommand, new ExecutedRoutedEventHandler(DockableWindow.OnCommand), new CanExecuteRoutedEventHandler(DockableWindow.OnCanExecute)));
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000319C0 File Offset: 0x0002FDC0
		public DockableWindow()
		{
			this.positionMetaData = new WindowMetaData();
			this.MetaData.LastOpenDockSituation = DockSituation.Docked;
			this.MetaData.LastFixedDockSituation = DockSituation.Docked;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000319EC File Offset: 0x0002FDEC
		public DockableWindow(DockSite dockSite, string title) : this()
		{
			if (dockSite == null)
			{
				throw new ArgumentNullException("dockSite");
			}
			if (title == null)
			{
				throw new ArgumentNullException("title");
			}
			this.DockSite = dockSite;
			this.Title = title;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00031A20 File Offset: 0x0002FE20
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new DockableWindowAutomationPeer(this);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00031A28 File Offset: 0x0002FE28
		public static DockableWindow GetDockableWindow(DependencyObject element)
		{
			for (DependencyObject dependencyObject = element; dependencyObject != null; dependencyObject = VisualTreeHelper.GetParent(dependencyObject))
			{
				DockableWindow dockableWindow = dependencyObject as DockableWindow;
				if (dockableWindow != null)
				{
					return dockableWindow;
				}
			}
			return null;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00031A50 File Offset: 0x0002FE50
		public static DockableWindow FromWindow(DockSite dockSite, Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			UIElement uielement = window.Content as UIElement;
			if (uielement == null)
			{
				throw new InvalidOperationException(Messages.ExceptionWindowHasNoContent);
			}
			window.Content = null;
			DockableWindow dockableWindow = new DockableWindow();
			dockableWindow.DockSite = dockSite;
			dockableWindow.Child = uielement;
			dockableWindow.Close();
			Binding binding = new Binding();
			binding.Path = new PropertyPath(Window.TitleProperty);
			binding.Mode = BindingMode.OneWay;
			binding.Source = window;
			dockableWindow.SetBinding(DockableWindow.TitleProperty, binding);
			return dockableWindow;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00031ADC File Offset: 0x0002FEDC
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseDown(e);
			if (e.ClickCount == 1)
			{
				base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new EventHandler(this.ActivateIfNoFocus), null, null);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00031B0C File Offset: 0x0002FF0C
		private void ActivateIfNoFocus(object sender, EventArgs e)
		{
			if (!base.IsKeyboardFocusWithin && this.DockSituation != DockSituation.None)
			{
				for (Visual visual = Keyboard.FocusedElement as Visual; visual != null; visual = (VisualTreeHelper.GetParent(visual) as Visual))
				{
					if (visual == this)
					{
						return;
					}
					if (visual.GetType().Name == "PopupRoot")
					{
						visual = (((FrameworkElement)visual).Parent as Visual);
					}
					Popup popup = visual as Popup;
					if (popup != null)
					{
						visual = ((popup.PlacementTarget != null) ? popup.PlacementTarget : (popup.Parent as Visual));
						if (visual == null)
						{
							return;
						}
					}
				}
				this.Activate();
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00031BAC File Offset: 0x0002FFAC
		private void OnShouldActivate(EventArgs e)
		{
			if (this.ShouldActivate != null)
			{
				this.ShouldActivate(this, e);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00031BC4 File Offset: 0x0002FFC4
		protected override IEnumerator LogicalChildren
		{
			get
			{
				if (this.Child != null)
				{
					return new UIElement[]
					{
						this.Child
					}.GetEnumerator();
				}
				return null;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00031BF4 File Offset: 0x0002FFF4
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00031C08 File Offset: 0x00030008
		[Browsable(false)]
		public UIElement Child
		{
			get
			{
				return (UIElement)base.GetValue(DockableWindow.ChildProperty);
			}
			set
			{
				base.SetValue(DockableWindow.ChildProperty, value);
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00031C18 File Offset: 0x00030018
		private static void OnChildChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
		{
			DockableWindow dockableWindow = (DockableWindow)dp;
			UIElement uielement = (UIElement)e.OldValue;
			UIElement uielement2 = (UIElement)e.NewValue;
			if (uielement != null)
			{
				dockableWindow.RemoveLogicalChild(uielement);
			}
			if (uielement2 != null)
			{
				dockableWindow.AddLogicalChild(uielement2);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00031C5C File Offset: 0x0003005C
		internal void ShowContextMenu(UIElement placementTarget, Rect placementRectangle)
		{
			if (this.DockSite != null)
			{
				ShowWindowControlsEventArgs showWindowControlsEventArgs = new ShowWindowControlsEventArgs(this, placementTarget, placementRectangle);
				this.DockSite.OnShowWindowControls(showWindowControlsEventArgs);
				if (showWindowControlsEventArgs.ContextMenu != null)
				{
					showWindowControlsEventArgs.ContextMenu.PlacementRectangle = placementRectangle;
					showWindowControlsEventArgs.ContextMenu.PlacementTarget = placementTarget;
					showWindowControlsEventArgs.ContextMenu.Placement = PlacementMode.Bottom;
					showWindowControlsEventArgs.ContextMenu.IsOpen = true;
				}
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00031CC0 File Offset: 0x000300C0
		public override string ToString()
		{
			return base.ToString() + " (\"" + this.Title + "\")";
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00031CE0 File Offset: 0x000300E0
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00031CF4 File Offset: 0x000300F4
		[Browsable(false)]
		public bool IsLastActiveWindow
		{
			get
			{
				return (bool)base.GetValue(DockableWindow.IsLastActiveWindowProperty);
			}
			internal set
			{
				base.SetValue(DockableWindow.IsLastActiveWindowPropertyKey, value);
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00031D08 File Offset: 0x00030108
		private static void OnDockSituationChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			DockableWindow dockableWindow = o as DockableWindow;
			if (dockableWindow != null)
			{
				dockableWindow.RecordMetaData();
				if (!xd679d9fc970c8f10.xd36c48a77e7b0108)
				{
					xd679d9fc970c8f10.x1bfedb81111c56cf();
					try
					{
						dockableWindow.OnDockSituationChanged(EventArgs.Empty);
					}
					finally
					{
						xd679d9fc970c8f10.x6a0b5cc1ee52d476();
					}
				}
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00031D60 File Offset: 0x00030160
		protected internal virtual void OnDockSituationChanged(EventArgs e)
		{
			if (this.DockSituationChanged != null)
			{
				this.DockSituationChanged(this, e);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00031D78 File Offset: 0x00030178
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00031D8C File Offset: 0x0003018C
		[Browsable(false)]
		public Dock LastDockSide
		{
			get
			{
				return (Dock)base.GetValue(DockableWindow.LastDockSideProperty);
			}
			private set
			{
				base.SetValue(DockableWindow.LastDockSidePropertyKey, value);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00031DA0 File Offset: 0x000301A0
		[Browsable(false)]
		public DockSituation DockSituation
		{
			get
			{
				return (DockSituation)base.GetValue(DockableWindow.DockSituationProperty);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00031DB4 File Offset: 0x000301B4
		internal static void SetDockSituation(FrameworkElement element, DockSituation value)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (value == (DockSituation)DockableWindow.DockSituationProperty.DefaultMetadata.DefaultValue)
			{
				element.ClearValue(DockableWindow.DockSituationPropertyKey);
				return;
			}
			element.SetValue(DockableWindow.DockSituationPropertyKey, value);
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00031E04 File Offset: 0x00030204
		private static void OnCommand(object sender, ExecutedRoutedEventArgs e)
		{
			DockableWindow dockableWindow = (DockableWindow)sender;
			if (e.Command == DockableWindow.OpenCommand)
			{
				dockableWindow.Open();
				return;
			}
			if (e.Command == DockableWindow.CloseCommand)
			{
				dockableWindow.Close();
				return;
			}
			if (e.Command == WindowGroup.TogglePinCommand)
			{
				dockableWindow.SelectAndPopup(false);
				WindowGroup windowGroup = dockableWindow.Parent as WindowGroup;
				if (windowGroup != null)
				{
					windowGroup.UserTogglePin();
				}
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00031E6C File Offset: 0x0003026C
		private static void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			DockableWindow dockableWindow = (DockableWindow)sender;
			if (e.Command == DockableWindow.OpenCommand)
			{
				e.CanExecute = true;
			}
			if (e.Command == DockableWindow.CloseCommand)
			{
				e.CanExecute = dockableWindow.AllowClose;
			}
			if (e.Command == WindowGroup.TogglePinCommand)
			{
				e.CanExecute = true;
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00031EC4 File Offset: 0x000302C4
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (this.DockSite != null && e.Key == this.DockSite.WindowSwitchKey && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
			{
				this.DockSite.StartWindowSwitch();
				e.Handled = true;
				return;
			}
			if (e.Key == Key.Escape && this.DockSite != null)
			{
				this.DockSite.ActivatePrimaryDocument();
				e.Handled = true;
				return;
			}
			base.OnKeyDown(e);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00031F38 File Offset: 0x00030338
		protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnIsKeyboardFocusWithinChanged(e);
			if ((bool)e.NewValue)
			{
				this.RegisterActivate();
				return;
			}
			this.RegisterDeactivate();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00031F5C File Offset: 0x0003035C
		private void RegisterDeactivate()
		{
			if (this.DockSite != null && this.DockSite.LastActiveWindow == this)
			{
				this.DockSite.PostEvaluateLastActiveWindow();
			}
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00031F80 File Offset: 0x00030380
		private void RegisterActivate()
		{
			this.MetaData.LastFocused = DateTime.Now;
			if (this.DockSite != null)
			{
				this.DockSite.LastActiveWindow = this;
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00031FA8 File Offset: 0x000303A8
		protected internal virtual void OnClosing(CancelEventArgs e)
		{
			if (this.Closing != null)
			{
				this.Closing(this, e);
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00031FC0 File Offset: 0x000303C0
		protected internal virtual void OnClosed(EventArgs e)
		{
			if (this.Closed != null)
			{
				this.Closed(this, e);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00031FD8 File Offset: 0x000303D8
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00031FEC File Offset: 0x000303EC
		[Category("Docking")]
		public DockingRules DockingRules
		{
			get
			{
				return (DockingRules)base.GetValue(DockableWindow.DockingRulesProperty);
			}
			set
			{
				base.SetValue(DockableWindow.DockingRulesProperty, value);
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00031FFC File Offset: 0x000303FC
		private static bool OnValidateDockingRules(object o)
		{
			DockingRules dockingRules = (DockingRules)o;
			return dockingRules != null;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00032018 File Offset: 0x00030418
		private static bool OnValidateContentSize(object o)
		{
			double num = (double)o;
			return num > 0.0;
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00032038 File Offset: 0x00030438
		private static void OnContentSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0003203C File Offset: 0x0003043C
		private static PopupContainer FindPopupContainer(FrameworkElement element)
		{
			for (FrameworkElement frameworkElement = element; frameworkElement != null; frameworkElement = (VisualTreeHelper.GetParent(frameworkElement) as FrameworkElement))
			{
				PopupContainer popupContainer = frameworkElement as PopupContainer;
				if (popupContainer != null)
				{
					return popupContainer;
				}
			}
			return null;
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600005F RID: 95 RVA: 0x0003206C File Offset: 0x0003046C
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00032080 File Offset: 0x00030480
		[Category("Docking")]
		public double ContentSize
		{
			get
			{
				return (double)base.GetValue(DockableWindow.ContentSizeProperty);
			}
			set
			{
				base.SetValue(DockableWindow.ContentSizeProperty, value);
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00032094 File Offset: 0x00030494
		private static void OnAllowCollapseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DockableWindow dockableWindow = (DockableWindow)d;
			WindowGroup windowGroup = dockableWindow.Parent as WindowGroup;
			if (windowGroup != null)
			{
				windowGroup.NotifyChildAllowCollapseChanged();
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000320C0 File Offset: 0x000304C0
		private static void OnDockSiteChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DockableWindow dockableWindow = d as DockableWindow;
			if (dockableWindow != null)
			{
				DockSite dockSite = (DockSite)e.OldValue;
				DockSite dockSite2 = (DockSite)e.NewValue;
				if (dockSite != null)
				{
					dockSite.UnregisterDockableWindow(dockableWindow);
				}
				if (dockSite2 != null)
				{
					dockSite2.RegisterDockableWindow(dockableWindow);
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00032108 File Offset: 0x00030508
		// (set) Token: 0x06000064 RID: 100 RVA: 0x0003211C File Offset: 0x0003051C
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DockSite DockSite
		{
			get
			{
				return (DockSite)base.GetValue(DockableWindow.DockSiteProperty);
			}
			set
			{
				base.SetValue(DockableWindow.DockSiteProperty, value);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000065 RID: 101 RVA: 0x0003212C File Offset: 0x0003052C
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00032140 File Offset: 0x00030540
		[Category("Docking")]
		public bool AllowClose
		{
			get
			{
				return (bool)base.GetValue(DockableWindow.AllowCloseProperty);
			}
			set
			{
				base.SetValue(DockableWindow.AllowCloseProperty, value);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00032154 File Offset: 0x00030554
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00032168 File Offset: 0x00030568
		[Category("Docking")]
		public bool AllowCollapse
		{
			get
			{
				return (bool)base.GetValue(DockableWindow.AllowCollapseProperty);
			}
			set
			{
				base.SetValue(DockableWindow.AllowCollapseProperty, value);
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0003217C File Offset: 0x0003057C
		internal void RecordMetaData()
		{
			if (this.DockSituation != DockSituation.None)
			{
				this.MetaData.LastOpenDockSituation = this.DockSituation;
			}
			x129cb2a2bdfd0ab2 x129cb2a2bdfd0ab = null;
			switch (this.DockSituation)
			{
			case DockSituation.Docked:
				x129cb2a2bdfd0ab = this.MetaData.xe62a3d24e0fde928;
				this.RecordFixedMetaData();
				break;
			case DockSituation.Document:
				x129cb2a2bdfd0ab = this.MetaData.x25e1dbd0e63329bf;
				this.RecordFixedMetaData();
				break;
			case DockSituation.Floating:
				x129cb2a2bdfd0ab = this.MetaData.xba74b873ae2f845a;
				this.RecordFloatingMetaData();
				break;
			}
			if (x129cb2a2bdfd0ab != null)
			{
				this.RecordSituationMetaData(x129cb2a2bdfd0ab);
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00032208 File Offset: 0x00030608
		private void RecordFloatingMetaData()
		{
			FloatingWindowAdapter floatingWindowAdapter = xd679d9fc970c8f10.x94eafc5f4a9a0734(this);
			if (floatingWindowAdapter != null)
			{
				this.MetaData.xe54c39cad89808e2 = floatingWindowAdapter.Guid;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00032230 File Offset: 0x00030630
		private void RecordSituationMetaData(x129cb2a2bdfd0ab2 metaData)
		{
			WindowGroup windowGroup = base.Parent as WindowGroup;
			if (windowGroup != null)
			{
				metaData.x1acd7f00f3ce8dea = windowGroup.Guid;
				metaData.xeb60189193347805 = windowGroup.Windows.IndexOf(this);
				metaData.x3a4e0c379519d4a2 = SplitContainer.GetWorkingSize(windowGroup);
				metaData.x61743036ad30763d = this.GetWindowGroupSplitPath(windowGroup);
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00032284 File Offset: 0x00030684
		private void RecordFixedMetaData()
		{
			this.MetaData.LastFixedDockSituation = this.DockSituation;
			for (;;)
			{
				if (this.DockSite == null)
				{
					for (FrameworkElement frameworkElement = base.Parent as FrameworkElement; frameworkElement != null; frameworkElement = (frameworkElement.Parent as FrameworkElement))
					{
						DockSite dockSite = frameworkElement as DockSite;
						if (2147483647 == 0)
						{
							goto IL_F6;
						}
						if (dockSite != null)
						{
							this.DockSite = dockSite;
							break;
						}
					}
					goto IL_62;
				}
				goto IL_62;
				IL_15E:
				SplitContainer[] dockedSplitContainers = this.DockSite.GetDockedSplitContainers(this.MetaData.LastFixedDockSide);
				this.MetaData.xe62a3d24e0fde928.xd25c313925dc7d4e = dockedSplitContainers.Length;
				if (false)
				{
					continue;
				}
				SplitContainer splitContainer;
				this.MetaData.xe62a3d24e0fde928.x71a5d248534c8557 = Array.IndexOf<SplitContainer>(dockedSplitContainers, splitContainer);
				int i;
				bool flag = (uint)i - (uint)i > uint.MaxValue;
				if (flag)
				{
					continue;
				}
				break;
				IL_F6:
				xdeadcc9941b6354e[] array;
				while (i < this.DockSite.SplitContainers.Count)
				{
					array[i] = new xdeadcc9941b6354e
					{
						xec73a4c1711af3d9 = DockSite.GetDock(this.DockSite.SplitContainers[i]),
						xd1bdf42207dd3638 = i
					};
					i++;
				}
				this.MetaData.x89d9f6f099893f30 = array;
				goto IL_15E;
				IL_62:
				WindowGroup windowGroup = base.Parent as WindowGroup;
				if (windowGroup == null || this.DockSituation != DockSituation.Docked)
				{
					break;
				}
				splitContainer = xd679d9fc970c8f10.x559d974f790f4e87(windowGroup);
				if (splitContainer == null)
				{
					break;
				}
				this.MetaData.LastFixedDockSide = DockSite.GetDock(splitContainer);
				this.MetaData.DockedContentSize = DockSite.GetContentSize(splitContainer);
				this.LastDockSide = this.MetaData.LastFixedDockSide;
				if (this.DockSite == null)
				{
					break;
				}
				if (splitContainer.Parent == this.DockSite)
				{
					array = new xdeadcc9941b6354e[this.DockSite.SplitContainers.Count];
					i = 0;
					goto IL_F6;
				}
				goto IL_15E;
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00032464 File Offset: 0x00030864
		private int[] GetWindowGroupSplitPath(WindowGroup windowGroup)
		{
			List<int> list = new List<int>();
			for (FrameworkElement frameworkElement = windowGroup; frameworkElement != null; frameworkElement = (frameworkElement.Parent as SplitContainer))
			{
				SplitContainer splitContainer = frameworkElement.Parent as SplitContainer;
				if (splitContainer != null)
				{
					list.Add(splitContainer.Children.IndexOf(frameworkElement));
				}
			}
			list.Reverse();
			return list.ToArray();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000324B8 File Offset: 0x000308B8
		public void UpdateMetaData(Dock dockedPosition)
		{
			if (base.Parent != null)
			{
				throw new InvalidOperationException(Messages.ExceptionCannotUpdateMetaData);
			}
			this.MetaData.LastFixedDockSide = dockedPosition;
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000324DC File Offset: 0x000308DC
		[Browsable(false)]
		public WindowMetaData MetaData
		{
			get
			{
				return this.positionMetaData;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000324E4 File Offset: 0x000308E4
		// (set) Token: 0x06000071 RID: 113 RVA: 0x000324F4 File Offset: 0x000308F4
		[Category("Common Properties")]
		[TypeConverter(typeof(StringConverter))]
		public object TabToolTip
		{
			get
			{
				return base.GetValue(DockableWindow.TabToolTipProperty);
			}
			set
			{
				base.SetValue(DockableWindow.TabToolTipProperty, value);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000072 RID: 114 RVA: 0x00032504 File Offset: 0x00030904
		// (set) Token: 0x06000073 RID: 115 RVA: 0x00032528 File Offset: 0x00030928
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Pinned
		{
			get
			{
				WindowGroup windowGroup = base.Parent as WindowGroup;
				return windowGroup == null || windowGroup.Pinned;
			}
			set
			{
				WindowGroup windowGroup = base.Parent as WindowGroup;
				if (windowGroup != null)
				{
					windowGroup.Pinned = value;
				}
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000074 RID: 116 RVA: 0x0003254C File Offset: 0x0003094C
		// (set) Token: 0x06000075 RID: 117 RVA: 0x00032574 File Offset: 0x00030974
		[Browsable(false)]
		public Guid Guid
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
				if (value == Guid.Empty)
				{
					throw new ArgumentException(Messages.ExceptionEmptyGuid, "value");
				}
				if (this.DockSite != null)
				{
					this.DockSite.UnregisterDockableWindow(this);
				}
				this.guid = value;
				this.hasGuid = true;
				if (this.DockSite != null)
				{
					this.DockSite.RegisterDockableWindow(this);
				}
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000076 RID: 118 RVA: 0x000325D4 File Offset: 0x000309D4
		internal bool HasGuid
		{
			get
			{
				return this.hasGuid;
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000325DC File Offset: 0x000309DC
		private static void OnFloatingSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DockableWindow x4bbc2c453c = d as DockableWindow;
			FloatingWindowAdapter floatingWindowAdapter = xd679d9fc970c8f10.x94eafc5f4a9a0734(x4bbc2c453c);
			if (floatingWindowAdapter != null)
			{
				floatingWindowAdapter.FloatingSize = (Size)e.NewValue;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000078 RID: 120 RVA: 0x0003260C File Offset: 0x00030A0C
		// (set) Token: 0x06000079 RID: 121 RVA: 0x00032620 File Offset: 0x00030A20
		[Category("Docking")]
		public Size FloatingSize
		{
			get
			{
				return (Size)base.GetValue(DockableWindow.FloatingSizeProperty);
			}
			set
			{
				base.SetValue(DockableWindow.FloatingSizeProperty, value);
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00032634 File Offset: 0x00030A34
		private static void OnFloatingLocationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DockableWindow x4bbc2c453c = d as DockableWindow;
			Point? point = (Point?)e.NewValue;
			if (point != null)
			{
				FloatingWindowAdapter floatingWindowAdapter = xd679d9fc970c8f10.x94eafc5f4a9a0734(x4bbc2c453c);
				if (floatingWindowAdapter != null)
				{
					floatingWindowAdapter.FloatingLocation = point.Value;
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00032678 File Offset: 0x00030A78
		// (set) Token: 0x0600007C RID: 124 RVA: 0x0003268C File Offset: 0x00030A8C
		[Category("Docking")]
		public Point? FloatingLocation
		{
			get
			{
				return (Point?)base.GetValue(DockableWindow.FloatingLocationProperty);
			}
			set
			{
				base.SetValue(DockableWindow.FloatingLocationProperty, value);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x000326A0 File Offset: 0x00030AA0
		private static void OnImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DockableWindow dockableWindow = (DockableWindow)d;
			switch (DependencyPropertyHelper.GetValueSource(dockableWindow, DockableWindow.ImageProperty).BaseValueSource)
			{
			case BaseValueSource.Default:
			case BaseValueSource.DefaultStyle:
			case BaseValueSource.DefaultStyleTrigger:
				dockableWindow.HasLocalImage = false;
				return;
			}
			dockableWindow.HasLocalImage = true;
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600007E RID: 126 RVA: 0x000326F4 File Offset: 0x00030AF4
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00032708 File Offset: 0x00030B08
		[Category("Common Properties")]
		public ImageSource Image
		{
			get
			{
				return (ImageSource)base.GetValue(DockableWindow.ImageProperty);
			}
			set
			{
				base.SetValue(DockableWindow.ImageProperty, value);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000080 RID: 128 RVA: 0x00032718 File Offset: 0x00030B18
		// (set) Token: 0x06000081 RID: 129 RVA: 0x0003272C File Offset: 0x00030B2C
		[Category("Appearance")]
		[Bindable(true)]
		private Brush TabBackground
		{
			get
			{
				return (Brush)base.GetValue(DockableWindow.TabBackgroundProperty);
			}
			set
			{
				base.SetValue(DockableWindow.TabBackgroundProperty, value);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000082 RID: 130 RVA: 0x0003273C File Offset: 0x00030B3C
		// (set) Token: 0x06000083 RID: 131 RVA: 0x00032750 File Offset: 0x00030B50
		[Browsable(false)]
		public bool HasLocalImage
		{
			get
			{
				return (bool)base.GetValue(DockableWindow.HasLocalImageProperty);
			}
			private set
			{
				base.SetValue(DockableWindow.HasLocalImagePropertyKey, value);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00032764 File Offset: 0x00030B64
		private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DockableWindow dockableWindow = (DockableWindow)d;
			string y = (string)e.OldValue;
			string tabText = (string)e.NewValue;
			if (StringComparer.CurrentCulture.Compare(dockableWindow.TabText, y) == 0)
			{
				dockableWindow.TabText = tabText;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000327AC File Offset: 0x00030BAC
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000327C0 File Offset: 0x00030BC0
		[Category("Common Properties")]
		public string Title
		{
			get
			{
				return (string)base.GetValue(DockableWindow.TitleProperty);
			}
			set
			{
				base.SetValue(DockableWindow.TitleProperty, value);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000327D0 File Offset: 0x00030BD0
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000327E4 File Offset: 0x00030BE4
		[Category("Text")]
		public string Description
		{
			get
			{
				return (string)base.GetValue(DockableWindow.DescriptionProperty);
			}
			set
			{
				base.SetValue(DockableWindow.DescriptionProperty, value);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000089 RID: 137 RVA: 0x000327F4 File Offset: 0x00030BF4
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00032808 File Offset: 0x00030C08
		[Category("Text")]
		public string TabText
		{
			get
			{
				return (string)base.GetValue(DockableWindow.TabTextProperty);
			}
			set
			{
				base.SetValue(DockableWindow.TabTextProperty, value);
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00032818 File Offset: 0x00030C18
		public bool ShouldSerializeTabText()
		{
			return this.TabText != this.Title;
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600008C RID: 140 RVA: 0x0003282C File Offset: 0x00030C2C
		// (set) Token: 0x0600008D RID: 141 RVA: 0x00032840 File Offset: 0x00030C40
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool IsSelected
		{
			get
			{
				return (bool)base.GetValue(DockableWindow.IsSelectedProperty);
			}
			internal set
			{
				base.SetValue(DockableWindow.IsSelectedProperty, value);
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00032854 File Offset: 0x00030C54
		public bool Close()
		{
			if (base.Parent is MdiContainer)
			{
				MdiContainer mdiContainer = (MdiContainer)base.Parent;
				MdiWindowContainer mdiWindowContainer = mdiContainer.ItemContainerGenerator.ContainerFromItem(this) as MdiWindowContainer;
				return mdiWindowContainer.Close();
			}
			CancelEventArgs cancelEventArgs = new CancelEventArgs();
			this.OnClosing(cancelEventArgs);
			if (cancelEventArgs.Cancel)
			{
				return false;
			}
			xd679d9fc970c8f10.xe3db202f22b97a52(this, true);
			this.OnClosed(EventArgs.Empty);
			if (this.closeMethod == WindowCloseMethod.Detach && this.DockSituation == DockSituation.None)
			{
				this.DockSite = null;
			}
			return true;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000328D8 File Offset: 0x00030CD8
		public void Remove()
		{
			xd679d9fc970c8f10.xe3db202f22b97a52(this);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000328E0 File Offset: 0x00030CE0
		internal void SelectAndPopup(bool activate)
		{
			WindowGroup windowGroup = base.Parent as WindowGroup;
			if (windowGroup != null)
			{
				if (windowGroup.SelectedWindow != this)
				{
					windowGroup.SelectedWindow = this;
					windowGroup.UpdateLayout();
				}
				this.OnShouldActivate(EventArgs.Empty);
				if (!windowGroup.Pinned && windowGroup.Tray != null)
				{
					if (this.DockSite.AllowPopupUnpinnedWindows)
					{
						windowGroup.Tray.ShowWindow(this, activate);
						return;
					}
					windowGroup.Pinned = true;
				}
			}
			if (activate)
			{
				this.Activate();
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0003295C File Offset: 0x00030D5C
		public void OpenBeside(DockableWindow existingWindow, Dock side)
		{
			if (existingWindow == null)
			{
				throw new ArgumentNullException();
			}
			if (existingWindow == this)
			{
				return;
			}
			if (existingWindow.DockSituation == DockSituation.None)
			{
				throw new InvalidOperationException("The specified window is not open.");
			}
			WindowGroup windowGroup = existingWindow.Parent as WindowGroup;
			if (windowGroup == null)
			{
				throw new InvalidOperationException();
			}
			this.Remove();
			windowGroup.SplitForElement(new WindowGroup(new DockableWindow[]
			{
				this
			}), side);
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000329C0 File Offset: 0x00030DC0
		public void OpenWith(DockableWindow existingWindow)
		{
			if (existingWindow == null)
			{
				throw new ArgumentNullException();
			}
			if (existingWindow == this)
			{
				return;
			}
			if (existingWindow.DockSituation == DockSituation.None)
			{
				throw new InvalidOperationException("The specified window is not open.");
			}
			WindowGroup windowGroup = existingWindow.Parent as WindowGroup;
			if (windowGroup == null)
			{
				throw new InvalidOperationException();
			}
			this.Remove();
			windowGroup.Windows.Add(this);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00032A18 File Offset: 0x00030E18
		public bool Open()
		{
			return this.Open(WindowOpenMethod.OpenSelectActivate);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00032A24 File Offset: 0x00030E24
		public bool Open(WindowOpenMethod openMethod)
		{
			this.EnsureDockSite();
			bool result = true;
			if (this.DockSituation == DockSituation.None)
			{
				switch (this.MetaData.LastOpenDockSituation)
				{
				case DockSituation.Docked:
					this.Dock(openMethod);
					return true;
				case DockSituation.Document:
					this.Document(openMethod);
					return true;
				case DockSituation.Floating:
					this.Float(openMethod);
					return true;
				}
			}
			if (openMethod != WindowOpenMethod.Background)
			{
				this.SelectAndPopup(openMethod == WindowOpenMethod.OpenSelectActivate);
			}
			return result;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00032A8C File Offset: 0x00030E8C
		internal bool Activate()
		{
			bool flag = false;
			if (!this.settingFocus)
			{
				this.settingFocus = true;
				try
				{
					if (this.DockSituation == DockSituation.Floating && this.DockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.NativeWindow)
					{
						FloatingWindowAdapter floatingWindowAdapter = xd679d9fc970c8f10.x94eafc5f4a9a0734(this);
						if (floatingWindowAdapter != null)
						{
							floatingWindowAdapter.Activate();
						}
					}
					MdiContainer mdiContainer = base.Parent as MdiContainer;
					if (mdiContainer != null)
					{
						MdiWindowContainer mdiWindowContainer = mdiContainer.ItemContainerGenerator.ContainerFromItem(this) as MdiWindowContainer;
						if (mdiWindowContainer != null)
						{
							MdiPanel mdiPanel = VisualTreeHelper.GetParent(mdiWindowContainer) as MdiPanel;
							if (mdiPanel != null)
							{
								mdiPanel.BringToFront(mdiWindowContainer);
							}
						}
					}
					if (!base.IsKeyboardFocusWithin)
					{
						UIElement uielement = null;
						if (FocusManager.GetIsFocusScope(this))
						{
							uielement = (FocusManager.GetFocusedElement(this) as UIElement);
						}
						if (uielement != null)
						{
							flag = uielement.Focus();
							if ((flag ? 1U : 0U) > 4294967295U)
							{
								goto IL_105;
							}
						}
						if (!flag && this.Child != null)
						{
							flag = this.Child.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
						}
						if (!flag && base.Focusable)
						{
							flag = base.Focus();
						}
					}
					this.RegisterActivate();
					IL_105:;
				}
				finally
				{
					this.settingFocus = false;
				}
			}
			return flag;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00032BC8 File Offset: 0x00030FC8
		internal void UserToggleDockFloatingState()
		{
			switch (this.DockSituation)
			{
			case DockSituation.Docked:
			case DockSituation.Document:
				if (this.DockingRules.AllowFloat)
				{
					this.Float(WindowOpenMethod.OpenSelectActivate);
					return;
				}
				break;
			case DockSituation.Floating:
				if (this.MetaData.LastFixedDockSituation == DockSituation.Docked)
				{
					if ((this.MetaData.LastFixedDockSide == System.Windows.Controls.Dock.Left && this.DockingRules.AllowDockLeft) || (this.MetaData.LastFixedDockSide == System.Windows.Controls.Dock.Right && this.DockingRules.AllowDockRight) || (this.MetaData.LastFixedDockSide == System.Windows.Controls.Dock.Top && this.DockingRules.AllowDockTop) || (this.MetaData.LastFixedDockSide == System.Windows.Controls.Dock.Bottom && this.DockingRules.AllowDockBottom))
					{
						this.Dock(WindowOpenMethod.OpenSelectActivate);
						WindowGroup windowGroup = (WindowGroup)base.Parent;
						windowGroup.FadeIn();
						return;
					}
				}
				else if (this.MetaData.LastFixedDockSituation == DockSituation.Document && this.DockingRules.AllowTab)
				{
					this.Document(WindowOpenMethod.OpenSelectActivate);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00032CC4 File Offset: 0x000310C4
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00032CCC File Offset: 0x000310CC
		[DefaultValue(WindowCloseMethod.Hide)]
		[Category("Docking")]
		public WindowCloseMethod CloseMethod
		{
			get
			{
				return this.closeMethod;
			}
			set
			{
				this.closeMethod = value;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00032CD8 File Offset: 0x000310D8
		public void Dock(WindowOpenMethod openMethod, Dock side)
		{
			this.EnsureDockSite();
			if (this.DockSituation == DockSituation.Docked && this.MetaData.LastFixedDockSide == side)
			{
				return;
			}
			xd679d9fc970c8f10.xe3db202f22b97a52(this);
			this.MetaData.LastFixedDockSide = side;
			this.MetaData.xe62a3d24e0fde928.x1acd7f00f3ce8dea = Guid.Empty;
			this.MetaData.xe62a3d24e0fde928.x61743036ad30763d = new int[0];
			this.Dock(openMethod);
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00032D48 File Offset: 0x00031148
		public void Dock(WindowOpenMethod openMethod)
		{
			this.EnsureDockSite();
			if (this.DockSituation == DockSituation.Docked)
			{
				return;
			}
			xd679d9fc970c8f10.xe3db202f22b97a52(this);
			WindowGroup windowGroup = xd679d9fc970c8f10.x759774c9bc2901ef(this.DockSite, DockSituation.Docked, this.MetaData.xe62a3d24e0fde928);
			if (windowGroup != null)
			{
				windowGroup.Windows.Insert(Math.Min(this.MetaData.xe62a3d24e0fde928.xeb60189193347805, windowGroup.Windows.Count), this);
				if (openMethod != WindowOpenMethod.Background)
				{
					this.SelectAndPopup(openMethod == WindowOpenMethod.OpenSelectActivate);
				}
				return;
			}
			x5678bb8d80c0f12e x5678bb8d80c0f12e = xd679d9fc970c8f10.x4689c8634e31fc55(this.DockSite, this.MetaData);
			windowGroup = x5678bb8d80c0f12e.xd301f1060b3751dc.CreateWindowGroup(new DockableWindow[]
			{
				this
			});
			if (this.MetaData.xe62a3d24e0fde928.x1acd7f00f3ce8dea == Guid.Empty)
			{
				this.MetaData.xe62a3d24e0fde928.x1acd7f00f3ce8dea = Guid.NewGuid();
			}
			windowGroup.Guid = this.MetaData.xe62a3d24e0fde928.x1acd7f00f3ce8dea;
			SplitContainer.SetWorkingSize(windowGroup, this.MetaData.xe62a3d24e0fde928.x3a4e0c379519d4a2);
			x5678bb8d80c0f12e.xd301f1060b3751dc.Children.Insert(x5678bb8d80c0f12e.xd1bdf42207dd3638, windowGroup);
			if (openMethod != WindowOpenMethod.Background)
			{
				this.SelectAndPopup(openMethod == WindowOpenMethod.OpenSelectActivate);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00032E70 File Offset: 0x00031270
		private void EnsureDockSite()
		{
			if (this.DockSite == null)
			{
				throw new InvalidOperationException(Messages.ExceptionDockSiteRequired);
			}
			xd679d9fc970c8f10.x68e583994d0940db();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00032E8C File Offset: 0x0003128C
		internal Point GetFloatingLocation()
		{
			if (this.FloatingLocation != null)
			{
				return this.FloatingLocation.Value;
			}
			this.EnsureDockSite();
			Point point = new Point(this.DockSite.RenderSize.Width / 2.0, this.DockSite.RenderSize.Height / 2.0);
			Point point2;
			if (base.FindCommonVisualAncestor(this.DockSite) != null)
			{
				point2 = base.TransformToVisual(this.DockSite).Transform(new Point(base.RenderSize.Width / 2.0, base.RenderSize.Height / 2.0));
			}
			else
			{
				point2 = point;
			}
			Point point3 = new Point(point2.X - (point2.X - point.X) * 0.3, point2.Y - (point2.Y - point.Y) * 0.3);
			Point point4 = new Point(point3.X - this.FloatingSize.Width / 2.0, point3.Y - this.FloatingSize.Height / 2.0);
			if (this.DockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.NativeWindow)
			{
				Point result = this.DockSite.PointToScreen(point4);
				if (result.Y < 0.0 && result.Y > -this.FloatingSize.Height)
				{
					result.Y = 0.0;
				}
				return result;
			}
			return point4;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0003304C File Offset: 0x0003144C
		public void Float(WindowOpenMethod openMethod)
		{
			this.EnsureDockSite();
			if (true)
			{
				for (;;)
				{
					if (false)
					{
						goto IL_DD;
					}
					if (this.DockSituation == DockSituation.Floating)
					{
						goto Block_9;
					}
					Rect rect = new Rect(this.GetFloatingLocation(), this.FloatingSize);
					xd679d9fc970c8f10.xe3db202f22b97a52(this);
					Window window = Window.GetWindow(this.DockSite);
					if (window != null)
					{
						FocusManager.SetFocusedElement(window, null);
					}
					Keyboard.Focus(null);
					WindowGroup windowGroup = xd679d9fc970c8f10.x759774c9bc2901ef(this.DockSite, DockSituation.Floating, this.MetaData.xba74b873ae2f845a);
					x5678bb8d80c0f12e x5678bb8d80c0f12e;
					if (windowGroup == null)
					{
						FloatingWindowAdapter floatingWindowAdapter = this.DockSite.FindFloatingWindow(this.MetaData.xe54c39cad89808e2);
						if (floatingWindowAdapter == null)
						{
							if (this.MetaData.xe54c39cad89808e2 == Guid.Empty)
							{
								this.MetaData.xe54c39cad89808e2 = Guid.NewGuid();
							}
							floatingWindowAdapter = this.DockSite.CreateFloatingWindow(this.MetaData.xe54c39cad89808e2);
							floatingWindowAdapter.FloatingLocation = rect.Location;
							floatingWindowAdapter.FloatingSize = rect.Size;
							floatingWindowAdapter.Open();
						}
						x5678bb8d80c0f12e = xd679d9fc970c8f10.x4689c8634e31fc55(floatingWindowAdapter.RootContainer, this.MetaData.xba74b873ae2f845a.x61743036ad30763d);
						windowGroup = x5678bb8d80c0f12e.xd301f1060b3751dc.CreateWindowGroup(new DockableWindow[]
						{
							this
						});
						SplitContainer.SetWorkingSize(windowGroup, this.MetaData.xba74b873ae2f845a.x3a4e0c379519d4a2);
						goto IL_DD;
					}
					windowGroup.Windows.Insert(Math.Min(this.MetaData.xba74b873ae2f845a.xeb60189193347805, windowGroup.Windows.Count), this);
					if (openMethod == WindowOpenMethod.Background)
					{
						break;
					}
					this.SelectAndPopup(openMethod == WindowOpenMethod.OpenSelectActivate);
					if (!false)
					{
						break;
					}
					IL_1BC:
					if (!true)
					{
						continue;
					}
					return;
					IL_DD:
					x5678bb8d80c0f12e.xd301f1060b3751dc.Children.Insert(x5678bb8d80c0f12e.xd1bdf42207dd3638, windowGroup);
					if (openMethod == WindowOpenMethod.Background)
					{
						return;
					}
					base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new EventHandler(this.OnBackgroundSelectAndPopup), openMethod == WindowOpenMethod.OpenSelectActivate, null);
					if (false)
					{
						return;
					}
					goto IL_1BC;
				}
				return;
				Block_9:
				if (!false)
				{
					return;
				}
				return;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00033234 File Offset: 0x00031634
		private void OnBackgroundSelectAndPopup(object sender, EventArgs e)
		{
			bool activate = (bool)sender;
			if (this.DockSituation == DockSituation.Floating)
			{
				this.SelectAndPopup(activate);
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00033258 File Offset: 0x00031658
		public void Document(WindowOpenMethod openMethod)
		{
			this.EnsureDockSite();
			if (this.DockSite.DocumentContainer == null)
			{
				throw new InvalidOperationException(Messages.ExceptionDocumentContainerRequired);
			}
			if (this.DockSituation == DockSituation.Document)
			{
				return;
			}
			xd679d9fc970c8f10.xe3db202f22b97a52(this);
			this.DockSite.DocumentContainer.EnsureContent();
			SplitContainer splitContainer = this.DockSite.DocumentContainer.Content as SplitContainer;
			if (splitContainer != null)
			{
				this.DocumentInSplitContainer(splitContainer, openMethod, this.DockSite.DocumentContainer.WindowOpenPosition);
				return;
			}
			MdiContainer mdiContainer = this.DockSite.DocumentContainer.Content as MdiContainer;
			if (mdiContainer != null)
			{
				this.DocumentInMdiContainer(mdiContainer, openMethod);
			}
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000332F8 File Offset: 0x000316F8
		private void DocumentInMdiContainer(MdiContainer mdiContainer, WindowOpenMethod openMethod)
		{
			if (openMethod == WindowOpenMethod.Background)
			{
				mdiContainer.Items.Insert(0, this);
				return;
			}
			mdiContainer.Items.Add(this);
			this.SelectAndPopup(openMethod == WindowOpenMethod.OpenSelectActivate);
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00033324 File Offset: 0x00031724
		private void DocumentInSplitContainer(SplitContainer splitContainer, WindowOpenMethod openMethod, DocumentContainerWindowOpenPosition windowOpenPosition)
		{
			WindowGroup windowGroup = xd679d9fc970c8f10.x759774c9bc2901ef(this.DockSite, DockSituation.Document, this.MetaData.x25e1dbd0e63329bf);
			if (windowGroup != null)
			{
				windowGroup.Windows.Insert(Math.Min(this.MetaData.x25e1dbd0e63329bf.xeb60189193347805, windowGroup.Windows.Count), this);
				if (openMethod != WindowOpenMethod.Background)
				{
					this.SelectAndPopup(openMethod == WindowOpenMethod.OpenSelectActivate);
				}
				return;
			}
			WindowGroup[] array = xd679d9fc970c8f10.x386f01b6cc4bfd98(splitContainer);
			windowGroup = ((array.Length != 0) ? array[0] : null);
			if (windowGroup == null)
			{
				windowGroup = new WindowGroup();
				splitContainer.Children.Add(windowGroup);
			}
			if (windowOpenPosition == DocumentContainerWindowOpenPosition.First)
			{
				windowGroup.Windows.Insert(0, this);
			}
			else
			{
				windowGroup.Windows.Add(this);
			}
			if (openMethod != WindowOpenMethod.Background)
			{
				this.SelectAndPopup(openMethod == WindowOpenMethod.OpenSelectActivate);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x000333DC File Offset: 0x000317DC
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x000333F0 File Offset: 0x000317F0
		public bool ShowOptionsButton
		{
			get
			{
				return (bool)base.GetValue(DockableWindow.ShowOptionsButtonProperty);
			}
			set
			{
				base.SetValue(DockableWindow.ShowOptionsButtonProperty, value);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00033404 File Offset: 0x00031804
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00033418 File Offset: 0x00031818
		[Category("Brushes")]
		public Brush TabForeground
		{
			get
			{
				return (Brush)base.GetValue(DockableWindow.TabForegroundProperty);
			}
			set
			{
				base.SetValue(DockableWindow.TabForegroundProperty, value);
			}
		}

		// Token: 0x04000006 RID: 6
		public static readonly DependencyProperty IsSelectedProperty;

		// Token: 0x04000007 RID: 7
		public static readonly DependencyProperty TitleProperty;

		// Token: 0x04000008 RID: 8
		public static readonly DependencyProperty DescriptionProperty;

		// Token: 0x04000009 RID: 9
		public static readonly DependencyProperty TabTextProperty;

		// Token: 0x0400000A RID: 10
		public static readonly DependencyProperty ImageProperty;

		// Token: 0x0400000B RID: 11
		public static readonly DependencyProperty FloatingLocationProperty;

		// Token: 0x0400000C RID: 12
		public static readonly DependencyProperty FloatingSizeProperty;

		// Token: 0x0400000D RID: 13
		public static readonly DependencyProperty DockSiteProperty;

		// Token: 0x0400000E RID: 14
		public static readonly DependencyProperty ContentSizeProperty;

		// Token: 0x0400000F RID: 15
		public static readonly DependencyProperty DockingRulesProperty;

		// Token: 0x04000010 RID: 16
		public static readonly DependencyProperty DockSituationProperty;

		// Token: 0x04000011 RID: 17
		private static readonly DependencyPropertyKey DockSituationPropertyKey;

		// Token: 0x04000012 RID: 18
		public static readonly DependencyProperty IsLastActiveWindowProperty;

		// Token: 0x04000013 RID: 19
		private static readonly DependencyPropertyKey IsLastActiveWindowPropertyKey;

		// Token: 0x04000014 RID: 20
		public static readonly DependencyProperty AllowCloseProperty;

		// Token: 0x04000015 RID: 21
		public static readonly DependencyProperty ChildProperty;

		// Token: 0x04000016 RID: 22
		public static readonly DependencyProperty TabForegroundProperty;

		// Token: 0x04000017 RID: 23
		public static readonly DependencyProperty AllowCollapseProperty;

		// Token: 0x04000018 RID: 24
		public static readonly DependencyProperty HasLocalImageProperty;

		// Token: 0x04000019 RID: 25
		private static readonly DependencyPropertyKey HasLocalImagePropertyKey;

		// Token: 0x0400001A RID: 26
		public static readonly DependencyProperty TabBackgroundProperty;

		// Token: 0x0400001B RID: 27
		public static readonly DependencyProperty LastDockSideProperty;

		// Token: 0x0400001C RID: 28
		private static readonly DependencyPropertyKey LastDockSidePropertyKey;

		// Token: 0x0400001D RID: 29
		public static readonly DependencyProperty ShowOptionsButtonProperty;

		// Token: 0x0400001E RID: 30
		public static readonly DependencyProperty TabToolTipProperty;

		// Token: 0x0400001F RID: 31
		public static readonly RoutedCommand CloseCommand = new RoutedCommand("Close", typeof(DockableWindow));

		// Token: 0x04000020 RID: 32
		public static readonly RoutedCommand OpenCommand;

		// Token: 0x04000021 RID: 33
		public static readonly RoutedCommand WindowOptionsCommand;

		// Token: 0x04000022 RID: 34
		private WindowCloseMethod closeMethod;

		// Token: 0x04000023 RID: 35
		private bool settingFocus;

		// Token: 0x04000024 RID: 36
		private bool hasGuid;

		// Token: 0x04000025 RID: 37
		private WindowMetaData positionMetaData;

		// Token: 0x04000026 RID: 38
		private Guid guid;
	}
}

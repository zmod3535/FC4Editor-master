using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Divelements.SandDock.Automation;
using Divelements.SandDock.Primitives;
using Divelements.SandDock.Resources;
using Divelements.SandDock.Switching;
using Divelements.Util.Registration;

namespace Divelements.SandDock
{
	// Token: 0x02000012 RID: 18
	[LicenseProvider(typeof(x294bd621a33dc533))]
	[ContentProperty("Child")]
	public class DockSite : Control
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000170 RID: 368 RVA: 0x000365E4 File Offset: 0x000349E4
		// (remove) Token: 0x06000171 RID: 369 RVA: 0x0003661C File Offset: 0x00034A1C
		public event EventHandler LastActiveWindowChanged;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000172 RID: 370 RVA: 0x00036654 File Offset: 0x00034A54
		// (remove) Token: 0x06000173 RID: 371 RVA: 0x0003668C File Offset: 0x00034A8C
		public event EventHandler<LoadWindowEventArgs> LoadWindow;

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000174 RID: 372 RVA: 0x000366C4 File Offset: 0x00034AC4
		// (remove) Token: 0x06000175 RID: 373 RVA: 0x000366FC File Offset: 0x00034AFC
		public event EventHandler<DockingStartedEventArgs> DockingStarted;

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000176 RID: 374 RVA: 0x00036734 File Offset: 0x00034B34
		// (remove) Token: 0x06000177 RID: 375 RVA: 0x0003676C File Offset: 0x00034B6C
		public event EventHandler DockingStopped;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000178 RID: 376 RVA: 0x000367A4 File Offset: 0x00034BA4
		// (remove) Token: 0x06000179 RID: 377 RVA: 0x000367DC File Offset: 0x00034BDC
		public event EventHandler<ShowWindowControlsEventArgs> ShowWindowControls;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x0600017A RID: 378 RVA: 0x00036814 File Offset: 0x00034C14
		// (remove) Token: 0x0600017B RID: 379 RVA: 0x0003684C File Offset: 0x00034C4C
		public event EventHandler<WindowEventArgs> WindowRegistered;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600017C RID: 380 RVA: 0x00036884 File Offset: 0x00034C84
		// (remove) Token: 0x0600017D RID: 381 RVA: 0x000368BC File Offset: 0x00034CBC
		public event EventHandler<WindowEventArgs> WindowUnregistered;

		// Token: 0x0600017E RID: 382 RVA: 0x000368F4 File Offset: 0x00034CF4
		static DockSite()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DockSite), new FrameworkPropertyMetadata(typeof(DockSite)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(DockSite), new FrameworkPropertyMetadata(false));
			FrameworkElement.FocusVisualStyleProperty.OverrideMetadata(typeof(DockSite), new FrameworkPropertyMetadata(null));
			UIElement.ClipToBoundsProperty.OverrideMetadata(typeof(DockSite), new FrameworkPropertyMetadata(true));
			DockSite.DockProperty = DependencyProperty.RegisterAttached("Dock", typeof(Dock), typeof(DockSite), new FrameworkPropertyMetadata(Dock.Right, FrameworkPropertyMetadataOptions.AffectsParentArrange, new PropertyChangedCallback(DockSite.OnDockChanged)));
			DockSite.ContentSizeProperty = DependencyProperty.RegisterAttached("ContentSize", typeof(double), typeof(DockSite), new FrameworkPropertyMetadata(200.0, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(DockSite.OnContentSizeChanged)), new ValidateValueCallback(DockSite.OnValidateContentSize));
			Control.BackgroundProperty.OverrideMetadata(typeof(DockSite), new FrameworkPropertyMetadata(Control.BackgroundProperty.DefaultMetadata.DefaultValue, new PropertyChangedCallback(DockSite.OnBackgroundChanged)));
			DockSite.DocumentContainerProperty = DependencyProperty.Register("DocumentContainer", typeof(DocumentContainer), typeof(DockSite), new FrameworkPropertyMetadata(null));
			DockSite.ManagerProperty = DependencyProperty.Register("Manager", typeof(DockSite), typeof(DockSite), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits));
			DockSite.FullscreenProperty = DependencyProperty.Register("Fullscreen", typeof(bool), typeof(DockSite), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(DockSite.OnFullscreenChanged)));
			DockSite.AnimationTypeProperty = DependencyProperty.Register("AnimationType", typeof(PopupAnimationType), typeof(DockSite), new FrameworkPropertyMetadata(PopupAnimationType.Combined));
			DockSite.PopupShowAnimationTimeProperty = DependencyProperty.Register("PopupShowAnimationTime", typeof(int), typeof(DockSite), new FrameworkPropertyMetadata(200));
			DockSite.PopupHideAnimationTimeProperty = DependencyProperty.Register("PopupHideAnimationTime", typeof(int), typeof(DockSite), new FrameworkPropertyMetadata(350));
			DockSite.LastActiveWindowPropertyKey = DependencyProperty.RegisterReadOnly("LastActiveWindow", typeof(DockableWindow), typeof(DockSite), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DockSite.OnLastActiveWindowChanged)));
			DockSite.LastActiveWindowProperty = DockSite.LastActiveWindowPropertyKey.DependencyProperty;
			DockSite.DockingHintDisplayStrategyProperty = DependencyProperty.Register("DockingHintDisplayStrategy", typeof(DockingHintDisplayStrategy), typeof(DockSite), new FrameworkPropertyMetadata(DockingHintDisplayStrategy.Popups, null, new CoerceValueCallback(DockSite.OnCoerceDockingHintDisplayStrategy)));
			DockSite.FloatingWindowDisplayStrategyProperty = DependencyProperty.Register("FloatingWindowDisplayStrategy", typeof(FloatingWindowDisplayStrategy), typeof(DockSite), new FrameworkPropertyMetadata(FloatingWindowDisplayStrategy.NativeWindow, null, new CoerceValueCallback(DockSite.OnCoerceFloatingWindowDisplayStrategy)));
			DockSite.LanguageStringsProperty = DependencyProperty.Register("LanguageStrings", typeof(SandDockLanguageStrings), typeof(DockSite), new FrameworkPropertyMetadata(new SandDockLanguageStrings()), new ValidateValueCallback(DockSite.OnValidateLanguageStrings));
			DockSite.OpenWindowsOnDragProperty = DependencyProperty.Register("OpenWindowsOnDrag", typeof(bool), typeof(DockSite), new FrameworkPropertyMetadata(false));
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00036C7C File Offset: 0x0003507C
		public DockSite()
		{
			if (!false)
			{
				if (!BrowserInteropHelper.IsBrowserHosted)
				{
					this.license = (LicenseManager.Validate(typeof(DockSite), this) as xbd7c5470fc89975b);
				}
				else if (x294bd621a33dc533.StaticallyActivated)
				{
					this.license = new xbd7c5470fc89975b();
				}
				else
				{
					this.license = new x1d91faf71382de33(false);
				}
				this.windowHierarchyPresenter = new WindowHierarchyPresenter(this);
				this.children = new SplitContainerCollection(this, this.windowHierarchyPresenter);
				this.windows = new Dictionary<Guid, DockableWindow>();
				this.floatingWindows = new Dictionary<Guid, FloatingWindowAdapter>();
			}
			this.background = new Rectangle();
			if (!false)
			{
				do
				{
					base.AddVisualChild(this.background);
					this.layoutPanel = new DockPanel();
					do
					{
						base.AddVisualChild(this.layoutPanel);
						this.leftTray = new UnpinnedTray(this, this.windowHierarchyPresenter.LeftPopupContainer);
						DockSite.SetDock(this.leftTray, Dock.Left);
						DockPanel.SetDock(this.leftTray, Dock.Left);
						this.topTray = new UnpinnedTray(this, this.windowHierarchyPresenter.TopPopupContainer);
						DockSite.SetDock(this.topTray, Dock.Top);
						DockPanel.SetDock(this.topTray, Dock.Top);
						this.rightTray = new UnpinnedTray(this, this.windowHierarchyPresenter.RightPopupContainer);
						DockSite.SetDock(this.rightTray, Dock.Right);
					}
					while (false);
					DockPanel.SetDock(this.rightTray, Dock.Right);
					this.bottomTray = new UnpinnedTray(this, this.windowHierarchyPresenter.BottomPopupContainer);
					DockSite.SetDock(this.bottomTray, Dock.Bottom);
					DockPanel.SetDock(this.bottomTray, Dock.Bottom);
					this.layoutPanel.Children.Add(this.leftTray);
					this.layoutPanel.Children.Add(this.rightTray);
					this.layoutPanel.Children.Add(this.topTray);
					this.layoutPanel.Children.Add(this.bottomTray);
					this.layoutPanel.Children.Add(this.windowHierarchyPresenter);
					this.mdiPanel = new MdiPanel();
					if (255 == 0)
					{
						break;
					}
					base.AddVisualChild(this.mdiPanel);
					base.SetValue(DockSite.ManagerProperty, this);
					DockableWindow.SetDockSituation(this, DockSituation.Docked);
					base.CoerceValue(DockSite.DockingHintDisplayStrategyProperty);
					base.CoerceValue(DockSite.FloatingWindowDisplayStrategyProperty);
				}
				while (15 == 0);
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00036F00 File Offset: 0x00035300
		protected override void OnInitialized(EventArgs e)
		{
			base.OnInitialized(e);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00036F0C File Offset: 0x0003530C
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new DockSiteAutomationPeer(this);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00036F14 File Offset: 0x00035314
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			if (this.license.Evaluation && !this.evaluationWatermarkAdded)
			{
				AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
				if (adornerLayer != null)
				{
					adornerLayer.Add(new EvaluationWatermarkAdorner(this));
				}
				else
				{
					SystemSounds.Asterisk.Play();
				}
				this.evaluationWatermarkAdded = true;
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00036F68 File Offset: 0x00035368
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseDown(e);
			if (this.license.Locked)
			{
				e.Handled = true;
			}
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00036F88 File Offset: 0x00035388
		protected internal virtual void OnShowWindowControls(ShowWindowControlsEventArgs e)
		{
			if (this.ShowWindowControls != null)
			{
				this.ShowWindowControls(this, e);
			}
			if (e.ContextMenu == null && this.UseDefaultWindowContextMenu)
			{
				WindowContextMenu contextMenu = new WindowContextMenu(e.Window);
				e.ContextMenu = contextMenu;
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00036FD0 File Offset: 0x000353D0
		protected internal virtual void OnDockingStarted(DockingStartedEventArgs e)
		{
			if (this.DockingStarted != null)
			{
				this.DockingStarted(this, e);
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00036FE8 File Offset: 0x000353E8
		protected internal virtual void OnDockingStopped(EventArgs e)
		{
			if (this.DockingStopped != null)
			{
				this.DockingStopped(this, e);
			}
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00037000 File Offset: 0x00035400
		public string GetLayout(bool includeDocuments)
		{
			return x245a5abec1c73d3a.x8d5cf4fcf22576e9(this, includeDocuments);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0003700C File Offset: 0x0003540C
		public void SetLayout(string layout)
		{
			if (layout == null)
			{
				throw new ArgumentNullException("layout");
			}
			x245a5abec1c73d3a.x175546c57b76906a(this, layout);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00037024 File Offset: 0x00035424
		internal void PostEvaluateLastActiveWindow()
		{
			base.Dispatcher.BeginInvoke(DispatcherPriority.Send, new DockSite.x3ac7dfafcc420688(delegate()
			{
				if (this.LastActiveWindow != null && this.LastActiveWindow.DockSituation == DockSituation.None)
				{
					this.LastActiveWindow = null;
				}
			}));
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00037040 File Offset: 0x00035440
		protected virtual void OnLastActiveWindowChanged(EventArgs e)
		{
			if (this.LastActiveWindowChanged != null)
			{
				this.LastActiveWindowChanged(this, e);
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00037058 File Offset: 0x00035458
		private static void OnLastActiveWindowChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			DockSite dockSite = (DockSite)o;
			DockableWindow dockableWindow = (DockableWindow)e.OldValue;
			DockableWindow dockableWindow2 = (DockableWindow)e.NewValue;
			if (dockableWindow != null)
			{
				dockableWindow.IsLastActiveWindow = false;
			}
			if (dockableWindow2 != null)
			{
				dockableWindow2.IsLastActiveWindow = true;
			}
			xd679d9fc970c8f10.x1bfedb81111c56cf();
			try
			{
				dockSite.OnLastActiveWindowChanged(EventArgs.Empty);
			}
			finally
			{
				xd679d9fc970c8f10.x6a0b5cc1ee52d476();
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600018C RID: 396 RVA: 0x000370D0 File Offset: 0x000354D0
		// (set) Token: 0x0600018D RID: 397 RVA: 0x000370E4 File Offset: 0x000354E4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Category("Text")]
		public SandDockLanguageStrings LanguageStrings
		{
			get
			{
				return (SandDockLanguageStrings)base.GetValue(DockSite.LanguageStringsProperty);
			}
			set
			{
				base.SetValue(DockSite.LanguageStringsProperty, value);
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000370F4 File Offset: 0x000354F4
		private static bool OnValidateLanguageStrings(object value)
		{
			return value != null;
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600018F RID: 399 RVA: 0x00037100 File Offset: 0x00035500
		// (set) Token: 0x06000190 RID: 400 RVA: 0x00037114 File Offset: 0x00035514
		[Browsable(false)]
		public DockableWindow LastActiveWindow
		{
			get
			{
				return (DockableWindow)base.GetValue(DockSite.LastActiveWindowProperty);
			}
			internal set
			{
				base.SetValue(DockSite.LastActiveWindowPropertyKey, value);
			}
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00037124 File Offset: 0x00035524
		internal void StartWindowSwitch()
		{
			if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
			{
				throw new InvalidOperationException();
			}
			WindowSwitcher windowSwitcher;
			if (this.CustomWindowSwitcherType != null)
			{
				windowSwitcher = (WindowSwitcher)Activator.CreateInstance(this.CustomWindowSwitcherType, new object[]
				{
					this
				});
			}
			else
			{
				switch (this.WindowSwitcherType)
				{
				case WindowSwitcherType.Tab3D:
					windowSwitcher = new x5b48716de9a52566(this);
					goto IL_73;
				case WindowSwitcherType.QuickTabs:
					windowSwitcher = new xc49fa306611edef5(this);
					goto IL_73;
				}
				windowSwitcher = new x5ca7963207d84796(this);
			}
			IL_73:
			windowSwitcher.x12cb12b5d2cad53d();
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000192 RID: 402 RVA: 0x000371AC File Offset: 0x000355AC
		// (set) Token: 0x06000193 RID: 403 RVA: 0x000371B4 File Offset: 0x000355B4
		[Category("Common Properties")]
		public WindowSwitcherType WindowSwitcherType
		{
			get
			{
				return this.windowSwitcherType;
			}
			set
			{
				this.windowSwitcherType = value;
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000194 RID: 404 RVA: 0x000371C0 File Offset: 0x000355C0
		// (set) Token: 0x06000195 RID: 405 RVA: 0x000371C8 File Offset: 0x000355C8
		[Browsable(false)]
		[DefaultValue(true)]
		public bool AllowMiddleButtonClosure
		{
			get
			{
				return this.allowMiddleButtonClosure;
			}
			set
			{
				this.allowMiddleButtonClosure = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000196 RID: 406 RVA: 0x000371D4 File Offset: 0x000355D4
		// (set) Token: 0x06000197 RID: 407 RVA: 0x000371DC File Offset: 0x000355DC
		[DefaultValue(true)]
		[Browsable(false)]
		public bool AllowFloatingGroups
		{
			get
			{
				return this.allowFloatingGroups;
			}
			set
			{
				this.allowFloatingGroups = value;
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000371E8 File Offset: 0x000355E8
		private static void OnContentSizeChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			SplitContainer splitContainer = o as SplitContainer;
			if (splitContainer != null)
			{
				SplitContainer.PropagateDockSituationChanged(splitContainer);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000199 RID: 409 RVA: 0x00037208 File Offset: 0x00035608
		// (set) Token: 0x0600019A RID: 410 RVA: 0x0003721C File Offset: 0x0003561C
		[Category("Animation")]
		public int PopupShowAnimationTime
		{
			get
			{
				return (int)base.GetValue(DockSite.PopupShowAnimationTimeProperty);
			}
			set
			{
				base.SetValue(DockSite.PopupShowAnimationTimeProperty, value);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600019B RID: 411 RVA: 0x00037230 File Offset: 0x00035630
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00037244 File Offset: 0x00035644
		[Category("Animation")]
		public int PopupHideAnimationTime
		{
			get
			{
				return (int)base.GetValue(DockSite.PopupHideAnimationTimeProperty);
			}
			set
			{
				base.SetValue(DockSite.PopupHideAnimationTimeProperty, value);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x0600019D RID: 413 RVA: 0x00037258 File Offset: 0x00035658
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00037260 File Offset: 0x00035660
		[DefaultValue(true)]
		[Browsable(false)]
		public bool AllowPopupUnpinnedWindows
		{
			get
			{
				return this.allowPopupUnpinnedWindows;
			}
			set
			{
				this.allowPopupUnpinnedWindows = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600019F RID: 415 RVA: 0x0003726C File Offset: 0x0003566C
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x00037280 File Offset: 0x00035680
		[Category("Animation")]
		public PopupAnimationType AnimationType
		{
			get
			{
				return (PopupAnimationType)base.GetValue(DockSite.AnimationTypeProperty);
			}
			set
			{
				base.SetValue(DockSite.AnimationTypeProperty, value);
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00037294 File Offset: 0x00035694
		public void ActivatePrimaryDocument()
		{
			Window window = Window.GetWindow(this);
			if (!BrowserInteropHelper.IsBrowserHosted && window != null && !window.Activate())
			{
				return;
			}
			DateTime t = DateTime.MinValue;
			DockableWindow dockableWindow = null;
			foreach (DockableWindow dockableWindow2 in this.GetAllWindows(DockSituation.Document))
			{
				if (dockableWindow2.MetaData.LastFocused > t)
				{
					t = dockableWindow2.MetaData.LastFocused;
					dockableWindow = dockableWindow2;
				}
			}
			if (dockableWindow != null)
			{
				dockableWindow.SelectAndPopup(true);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001A2 RID: 418 RVA: 0x00037310 File Offset: 0x00035710
		internal MdiPanel WindowPanel
		{
			get
			{
				return this.mdiPanel;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x00037318 File Offset: 0x00035718
		// (set) Token: 0x060001A4 RID: 420 RVA: 0x0003732C File Offset: 0x0003572C
		[Category("Common Properties")]
		public bool OpenWindowsOnDrag
		{
			get
			{
				return (bool)base.GetValue(DockSite.OpenWindowsOnDragProperty);
			}
			set
			{
				base.SetValue(DockSite.OpenWindowsOnDragProperty, value);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00037340 File Offset: 0x00035740
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00037354 File Offset: 0x00035754
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DocumentContainer DocumentContainer
		{
			get
			{
				return (DocumentContainer)base.GetValue(DockSite.DocumentContainerProperty);
			}
			set
			{
				base.SetValue(DockSite.DocumentContainerProperty, value);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001A7 RID: 423 RVA: 0x00037364 File Offset: 0x00035764
		internal Key WindowSwitchKey
		{
			get
			{
				if (BrowserInteropHelper.IsBrowserHosted)
				{
					return Key.Q;
				}
				return Key.Tab;
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00037374 File Offset: 0x00035774
		internal FloatingWindowAdapter FindFloatingWindow(Guid guid)
		{
			FloatingWindowAdapter result;
			if (this.floatingWindows.TryGetValue(guid, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00037394 File Offset: 0x00035794
		internal void RegisterFloatingWindow(FloatingWindowAdapter window)
		{
			this.floatingWindows[window.Guid] = window;
			window.Closed += this.OnFloatingWindowClosed;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x000373BC File Offset: 0x000357BC
		internal void UnregisterFloatingWindow(FloatingWindowAdapter window)
		{
			this.floatingWindows.Remove(window.Guid);
			window.Closed -= this.OnFloatingWindowClosed;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000373E4 File Offset: 0x000357E4
		internal void RegisterDockableWindow(DockableWindow window)
		{
			this.windows[window.Guid] = window;
			this.OnWindowRegistered(new WindowEventArgs(window));
			DockSiteAutomationPeer dockSiteAutomationPeer = UIElementAutomationPeer.FromElement(this) as DockSiteAutomationPeer;
			if (dockSiteAutomationPeer != null)
			{
				dockSiteAutomationPeer.ResetChildrenCache();
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00037424 File Offset: 0x00035824
		protected virtual void OnWindowRegistered(WindowEventArgs e)
		{
			if (this.WindowRegistered != null)
			{
				this.WindowRegistered(this, e);
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0003743C File Offset: 0x0003583C
		internal void UnregisterDockableWindow(DockableWindow window)
		{
			if (this.LastActiveWindow == window)
			{
				this.LastActiveWindow = null;
			}
			this.windows.Remove(window.Guid);
			this.OnWindowUnregistered(new WindowEventArgs(window));
			DockSiteAutomationPeer dockSiteAutomationPeer = UIElementAutomationPeer.FromElement(this) as DockSiteAutomationPeer;
			if (dockSiteAutomationPeer != null)
			{
				dockSiteAutomationPeer.ResetChildrenCache();
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0003748C File Offset: 0x0003588C
		protected virtual void OnWindowUnregistered(WindowEventArgs e)
		{
			if (this.WindowUnregistered != null)
			{
				this.WindowUnregistered(this, e);
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000374A4 File Offset: 0x000358A4
		internal FloatingWindowAdapter CreateFloatingWindow(Guid guid)
		{
			FloatingWindowAdapter floatingWindowAdapter = new FloatingWindowAdapter(this, guid);
			this.RegisterFloatingWindow(floatingWindowAdapter);
			floatingWindowAdapter.FontFamily = base.FontFamily;
			floatingWindowAdapter.FontSize = base.FontSize;
			floatingWindowAdapter.FontStyle = base.FontStyle;
			floatingWindowAdapter.FontWeight = base.FontWeight;
			return floatingWindowAdapter;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x000374F4 File Offset: 0x000358F4
		private void OnFloatingWindowClosed(object sender, EventArgs e)
		{
			FloatingWindowAdapter window = (FloatingWindowAdapter)sender;
			this.UnregisterFloatingWindow(window);
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00037510 File Offset: 0x00035910
		public SplitContainer GetDockedSplitContainer(Dock dock)
		{
			foreach (object obj in this.SplitContainers)
			{
				SplitContainer splitContainer = (SplitContainer)obj;
				if (DockSite.GetDock(splitContainer) == dock)
				{
					return splitContainer;
				}
			}
			return null;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00037580 File Offset: 0x00035980
		internal SplitContainer[] GetDockedSplitContainers(Dock dock)
		{
			SplitContainer[] array = new SplitContainer[this.SplitContainers.Count];
			int num = 0;
			for (int i = 0; i < this.SplitContainers.Count; i++)
			{
				if (DockSite.GetDock(this.SplitContainers[i]) == dock)
				{
					array[num++] = this.SplitContainers[i];
				}
			}
			SplitContainer[] array2 = new SplitContainer[num];
			Array.Copy(array, array2, num);
			return array2;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000375F0 File Offset: 0x000359F0
		public SplitContainer CreateDockedSplitContainer(Dock dock, DockSiteEdge edge, double contentSize)
		{
			if (edge == DockSiteEdge.Outside)
			{
				return this.CreateDockedSplitContainer(dock, 0, contentSize);
			}
			return this.CreateDockedSplitContainer(dock, this.SplitContainers.Count, contentSize);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00037614 File Offset: 0x00035A14
		public SplitContainer CreateDockedSplitContainer(Dock dock, int index, double contentSize)
		{
			SplitContainer splitContainer = new SplitContainer();
			DockSite.SetDock(splitContainer, dock);
			DockSite.SetContentSize(splitContainer, contentSize);
			this.SplitContainers.Insert(index, splitContainer);
			return splitContainer;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00037644 File Offset: 0x00035A44
		internal UnpinnedTray GetTray(Dock dock)
		{
			switch (dock)
			{
			case Dock.Left:
				return this.leftTray;
			case Dock.Top:
				return this.topTray;
			default:
				return this.rightTray;
			case Dock.Bottom:
				return this.bottomTray;
			}
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00037684 File Offset: 0x00035A84
		public static double GetContentSize(SplitContainer splitContainer)
		{
			if (splitContainer == null)
			{
				throw new ArgumentNullException("splitContainer");
			}
			return (double)splitContainer.GetValue(DockSite.ContentSizeProperty);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000376A4 File Offset: 0x00035AA4
		public static void SetContentSize(SplitContainer splitContainer, double contentSize)
		{
			if (splitContainer == null)
			{
				throw new ArgumentNullException("splitContainer");
			}
			splitContainer.SetValue(DockSite.ContentSizeProperty, contentSize);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000376C8 File Offset: 0x00035AC8
		private static bool OnValidateContentSize(object value)
		{
			return (double)value > 0.0;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000376DC File Offset: 0x00035ADC
		private static void OnBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DockSite dockSite = (DockSite)d;
			dockSite.background.Fill = (Brush)e.NewValue;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x00037708 File Offset: 0x00035B08
		private static void OnDockChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SplitContainer splitContainer = d as SplitContainer;
			if (splitContainer != null)
			{
				Dock dock = (Dock)e.NewValue;
				if (dock == Dock.Top || dock == Dock.Bottom)
				{
					splitContainer.SetValue(SplitContainer.SplitterOrientationProperty, Orientation.Vertical);
				}
				else
				{
					splitContainer.ClearValue(SplitContainer.SplitterOrientationProperty);
				}
				DockSite dockSite = splitContainer.Parent as DockSite;
				if (dockSite != null)
				{
					WindowGroup.SetTray(splitContainer, dockSite.GetTray(DockSite.GetDock(splitContainer)));
					foreach (object obj in dockSite.SplitContainers)
					{
						SplitContainer splitContainer2 = (SplitContainer)obj;
						splitContainer2.RecordMetaData();
					}
				}
			}
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000377D4 File Offset: 0x00035BD4
		[AttachedPropertyBrowsableForChildren]
		public static Dock GetDock(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (Dock)element.GetValue(DockSite.DockProperty);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000377F4 File Offset: 0x00035BF4
		public static void SetDock(UIElement element, Dock dock)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.SetValue(DockSite.DockProperty, dock);
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00037818 File Offset: 0x00035C18
		public DockableWindow FindWindow(Guid guid)
		{
			DockableWindow result;
			if (this.windows.TryGetValue(guid, out result))
			{
				return result;
			}
			LoadWindowEventArgs loadWindowEventArgs = new LoadWindowEventArgs(guid);
			xd679d9fc970c8f10.x1bfedb81111c56cf();
			try
			{
				this.OnLoadWindow(loadWindowEventArgs);
			}
			finally
			{
				xd679d9fc970c8f10.x6a0b5cc1ee52d476();
			}
			if (loadWindowEventArgs.Window != null)
			{
				loadWindowEventArgs.Window.DockSite = this;
				loadWindowEventArgs.Window.Guid = guid;
				return loadWindowEventArgs.Window;
			}
			return null;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00037898 File Offset: 0x00035C98
		protected virtual void OnLoadWindow(LoadWindowEventArgs e)
		{
			if (this.LoadWindow != null)
			{
				this.LoadWindow(this, e);
			}
		}

		// Token: 0x060001BF RID: 447 RVA: 0x000378B0 File Offset: 0x00035CB0
		public DockableWindow[] GetAllWindows()
		{
			DockableWindow[] array = new DockableWindow[this.windows.Count];
			this.windows.Values.CopyTo(array, 0);
			return array;
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x000378E4 File Offset: 0x00035CE4
		public DockableWindow[] GetAllWindows(DockSituation dockSituation)
		{
			List<DockableWindow> list = new List<DockableWindow>();
			foreach (DockableWindow dockableWindow in this.windows.Values)
			{
				if (dockableWindow.DockSituation == dockSituation)
				{
					list.Add(dockableWindow);
				}
			}
			return list.ToArray();
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00037960 File Offset: 0x00035D60
		internal FloatingWindowAdapter[] GetFloatingWindows()
		{
			FloatingWindowAdapter[] array = new FloatingWindowAdapter[this.floatingWindows.Count];
			this.floatingWindows.Values.CopyTo(array, 0);
			return array;
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x00037994 File Offset: 0x00035D94
		[Browsable(false)]
		public Rect ClientBounds
		{
			get
			{
				Point location = this.windowHierarchyPresenter.TransformToAncestor(this).Transform(this.windowHierarchyPresenter.ClientBounds.Location);
				return new Rect(location, this.windowHierarchyPresenter.ClientBounds.Size);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x000379E0 File Offset: 0x00035DE0
		// (set) Token: 0x060001C4 RID: 452 RVA: 0x000379F4 File Offset: 0x00035DF4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public DockingHintDisplayStrategy DockingHintDisplayStrategy
		{
			get
			{
				return (DockingHintDisplayStrategy)base.GetValue(DockSite.DockingHintDisplayStrategyProperty);
			}
			set
			{
				base.SetValue(DockSite.DockingHintDisplayStrategyProperty, value);
			}
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00037A08 File Offset: 0x00035E08
		private static object OnCoerceDockingHintDisplayStrategy(DependencyObject element, object value)
		{
			if (BrowserInteropHelper.IsBrowserHosted)
			{
				return DockingHintDisplayStrategy.Adorners;
			}
			return value;
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00037A1C File Offset: 0x00035E1C
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x00037A30 File Offset: 0x00035E30
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public FloatingWindowDisplayStrategy FloatingWindowDisplayStrategy
		{
			get
			{
				return (FloatingWindowDisplayStrategy)base.GetValue(DockSite.FloatingWindowDisplayStrategyProperty);
			}
			set
			{
				base.SetValue(DockSite.FloatingWindowDisplayStrategyProperty, value);
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00037A44 File Offset: 0x00035E44
		private static object OnCoerceFloatingWindowDisplayStrategy(DependencyObject element, object value)
		{
			DockSite dockSite = (DockSite)element;
			if (BrowserInteropHelper.IsBrowserHosted)
			{
				return FloatingWindowDisplayStrategy.WpfWindow;
			}
			if (dockSite.floatingWindows.Count != 0)
			{
				return dockSite.FloatingWindowDisplayStrategy;
			}
			return value;
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x00037A80 File Offset: 0x00035E80
		// (set) Token: 0x060001CA RID: 458 RVA: 0x00037A94 File Offset: 0x00035E94
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Fullscreen
		{
			get
			{
				return (bool)base.GetValue(DockSite.FullscreenProperty);
			}
			set
			{
				base.SetValue(DockSite.FullscreenProperty, value);
			}
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00037AA8 File Offset: 0x00035EA8
		private static void OnFullscreenChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
		{
			DockSite dockSite = (DockSite)element;
			dockSite.windowHierarchyPresenter.InvalidateMeasure();
		}

		// Token: 0x060001CC RID: 460 RVA: 0x00037AC8 File Offset: 0x00035EC8
		protected override Size ArrangeOverride(Size arrangeBounds)
		{
			Rect finalRect = new Rect(0.0, 0.0, arrangeBounds.Width, arrangeBounds.Height);
			this.background.Arrange(finalRect);
			this.mdiPanel.Arrange(finalRect);
			finalRect.Offset(base.Padding.Left, base.Padding.Top);
			finalRect.Width = Math.Max(finalRect.Width - (base.Padding.Left + base.Padding.Right), 0.0);
			finalRect.Height = Math.Max(finalRect.Height - (base.Padding.Top + base.Padding.Bottom), 0.0);
			this.layoutPanel.Arrange(finalRect);
			return arrangeBounds;
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001CD RID: 461 RVA: 0x00037BBC File Offset: 0x00035FBC
		protected override IEnumerator LogicalChildren
		{
			get
			{
				UIElement[] array = new UIElement[this.SplitContainers.Count + ((this.Child != null) ? 1 : 0)];
				this.SplitContainers.CopyTo(array, 0);
				if (this.Child != null)
				{
					array[array.Length - 1] = this.Child;
				}
				return array.GetEnumerator();
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00037C10 File Offset: 0x00036010
		protected override Size MeasureOverride(Size constraint)
		{
			this.background.Measure(constraint);
			this.mdiPanel.Measure(constraint);
			constraint.Width -= base.Padding.Left + base.Padding.Right;
			constraint.Height -= base.Padding.Top + base.Padding.Bottom;
			this.layoutPanel.Measure(constraint);
			return new Size(this.layoutPanel.DesiredSize.Width + base.Padding.Left + base.Padding.Right, this.layoutPanel.DesiredSize.Height + base.Padding.Top + base.Padding.Bottom);
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00037D04 File Offset: 0x00036104
		protected override Visual GetVisualChild(int index)
		{
			if (index == 0)
			{
				return this.background;
			}
			if (index == 1)
			{
				return this.layoutPanel;
			}
			if (index == 2)
			{
				return this.mdiPanel;
			}
			throw new ArgumentOutOfRangeException("index");
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x00037D30 File Offset: 0x00036130
		protected override int VisualChildrenCount
		{
			get
			{
				return 3;
			}
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00037D34 File Offset: 0x00036134
		internal void NotifySplitContainersChanged()
		{
			this.windowHierarchyPresenter.InvalidateSplitters();
			foreach (object obj in this.SplitContainers)
			{
				SplitContainer splitContainer = (SplitContainer)obj;
				splitContainer.RecordMetaData();
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x00037DA4 File Offset: 0x000361A4
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x00037DAC File Offset: 0x000361AC
		public UIElement Child
		{
			get
			{
				return this.child;
			}
			set
			{
				if (value != this.child)
				{
					if (this.child != null)
					{
						base.RemoveLogicalChild(this.child);
					}
					this.child = value;
					this.windowHierarchyPresenter.Child = value;
					if (this.child != null)
					{
						base.AddLogicalChild(this.child);
					}
				}
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x00037E00 File Offset: 0x00036200
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x00037E08 File Offset: 0x00036208
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(true)]
		public bool UseDefaultWindowContextMenu
		{
			get
			{
				return this.useDefaultWindowContextMenu;
			}
			set
			{
				this.useDefaultWindowContextMenu = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x00037E14 File Offset: 0x00036214
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x00037E1C File Offset: 0x0003621C
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Type CustomWindowSwitcherType
		{
			get
			{
				return this.customWindowSwitcherType;
			}
			set
			{
				if (value != null && !value.IsSubclassOf(typeof(WindowSwitcher)))
				{
					throw new ArgumentException(Messages.ExceptionInvalidCustomWindowSwitcher, "value");
				}
				if (value != null && value.GetConstructor(new Type[]
				{
					typeof(DockSite)
				}) == null)
				{
					throw new ArgumentException(Messages.ExceptionInvalidCustomWindowSwitcher, "value");
				}
				this.customWindowSwitcherType = value;
			}
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00037E88 File Offset: 0x00036288
		internal void AddLogicalChild(SplitContainer child)
		{
			base.AddLogicalChild(child);
			this.windowHierarchyPresenter.InvalidateMeasure();
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00037E9C File Offset: 0x0003629C
		internal void RemoveLogicalChild(SplitContainer child)
		{
			base.RemoveLogicalChild(child);
			this.windowHierarchyPresenter.InvalidateMeasure();
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00037EB0 File Offset: 0x000362B0
		[Browsable(false)]
		public SplitContainerCollection SplitContainers
		{
			get
			{
				return this.children;
			}
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00037EB8 File Offset: 0x000362B8
		public static void ActivateProduct(string licenseKey)
		{
			x294bd621a33dc533.ActivateProduct(licenseKey);
		}

		// Token: 0x04000069 RID: 105
		public static readonly DependencyProperty DockProperty;

		// Token: 0x0400006A RID: 106
		public static readonly DependencyProperty ContentSizeProperty;

		// Token: 0x0400006B RID: 107
		public static readonly DependencyProperty DocumentContainerProperty;

		// Token: 0x0400006C RID: 108
		internal static readonly DependencyProperty ManagerProperty;

		// Token: 0x0400006D RID: 109
		public static readonly DependencyProperty FullscreenProperty;

		// Token: 0x0400006E RID: 110
		public static readonly DependencyProperty AnimationTypeProperty;

		// Token: 0x0400006F RID: 111
		public static readonly DependencyProperty PopupShowAnimationTimeProperty;

		// Token: 0x04000070 RID: 112
		public static readonly DependencyProperty PopupHideAnimationTimeProperty;

		// Token: 0x04000071 RID: 113
		public static readonly DependencyProperty LastActiveWindowProperty;

		// Token: 0x04000072 RID: 114
		private static readonly DependencyPropertyKey LastActiveWindowPropertyKey;

		// Token: 0x04000073 RID: 115
		public static readonly DependencyProperty DockingHintDisplayStrategyProperty;

		// Token: 0x04000074 RID: 116
		public static readonly DependencyProperty FloatingWindowDisplayStrategyProperty;

		// Token: 0x04000075 RID: 117
		public static readonly DependencyProperty LanguageStringsProperty;

		// Token: 0x04000076 RID: 118
		public static readonly DependencyProperty OpenWindowsOnDragProperty;

		// Token: 0x0400007E RID: 126
		private UIElement child;

		// Token: 0x0400007F RID: 127
		private Rectangle background;

		// Token: 0x04000080 RID: 128
		private UnpinnedTray leftTray;

		// Token: 0x04000081 RID: 129
		private UnpinnedTray topTray;

		// Token: 0x04000082 RID: 130
		private UnpinnedTray rightTray;

		// Token: 0x04000083 RID: 131
		private UnpinnedTray bottomTray;

		// Token: 0x04000084 RID: 132
		private SplitContainerCollection children;

		// Token: 0x04000085 RID: 133
		private Dictionary<Guid, DockableWindow> windows;

		// Token: 0x04000086 RID: 134
		private Dictionary<Guid, FloatingWindowAdapter> floatingWindows;

		// Token: 0x04000087 RID: 135
		private WindowSwitcherType windowSwitcherType = WindowSwitcherType.Tab3D;

		// Token: 0x04000088 RID: 136
		private Type customWindowSwitcherType;

		// Token: 0x04000089 RID: 137
		private bool allowFloatingGroups = true;

		// Token: 0x0400008A RID: 138
		private bool evaluationWatermarkAdded;

		// Token: 0x0400008B RID: 139
		private bool allowPopupUnpinnedWindows = true;

		// Token: 0x0400008C RID: 140
		private bool useDefaultWindowContextMenu = true;

		// Token: 0x0400008D RID: 141
		private bool allowMiddleButtonClosure = true;

		// Token: 0x0400008E RID: 142
		private xbd7c5470fc89975b license;

		// Token: 0x0400008F RID: 143
		private MdiPanel mdiPanel;

		// Token: 0x04000090 RID: 144
		private DockPanel layoutPanel;

		// Token: 0x04000091 RID: 145
		private WindowHierarchyPresenter windowHierarchyPresenter;

		// Token: 0x02000055 RID: 85
		// (Invoke) Token: 0x0600042E RID: 1070
		private delegate void x3ac7dfafcc420688();
	}
}

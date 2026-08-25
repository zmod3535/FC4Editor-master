using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;
using Divelements.SandDock.InteractiveDocking;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000031 RID: 49
	public class FloatingWindowAdapter : ContentControl
	{
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060002F9 RID: 761 RVA: 0x0003D5D4 File Offset: 0x0003B9D4
		// (remove) Token: 0x060002FA RID: 762 RVA: 0x0003D60C File Offset: 0x0003BA0C
		public event EventHandler Closed;

		// Token: 0x060002FB RID: 763 RVA: 0x0003D644 File Offset: 0x0003BA44
		static FloatingWindowAdapter()
		{
			FloatingWindowAdapter.PrimaryWindowGroupPropertyKey = DependencyProperty.RegisterReadOnly("PrimaryWindowGroup", typeof(WindowGroup), typeof(FloatingWindowAdapter), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(FloatingWindowAdapter.OnPrimaryWindowGroupChanged)));
			FloatingWindowAdapter.PrimaryWindowGroupProperty = FloatingWindowAdapter.PrimaryWindowGroupPropertyKey.DependencyProperty;
			FloatingWindowAdapter.WindowTitlePropertyKey = DependencyProperty.RegisterReadOnly("WindowTitle", typeof(string), typeof(FloatingWindowAdapter), new FrameworkPropertyMetadata(null, new CoerceValueCallback(FloatingWindowAdapter.OnCoerceWindowTitle)));
			FloatingWindowAdapter.WindowTitleProperty = FloatingWindowAdapter.WindowTitlePropertyKey.DependencyProperty;
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatingWindowAdapter), new FrameworkPropertyMetadata(typeof(FloatingWindowAdapter)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(FloatingWindowAdapter), new FrameworkPropertyMetadata(false));
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0003D730 File Offset: 0x0003BB30
		internal FloatingWindowAdapter(DockSite dockSite, Guid guid)
		{
			this.dockSite = dockSite;
			this.guid = guid;
			if (dockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.NativeWindow)
			{
				this.host = this.CreateNativeFloatingWindowHost();
			}
			else
			{
				this.host = new WpfFloatingWindowHost(this);
			}
			this.host.xa92b80a72ea23242 += this.OnShowContextMenu;
			this.host.xb451d7f50d849473 += this.OnClosing;
			this.host.x289bf94a509dd84c += this.OnClosed;
			this.host.x2cc861f351e226ca(this);
			if (!false)
			{
				UIElement uielement = this.host as UIElement;
				if (uielement == null)
				{
					goto IL_3E;
				}
				uielement.PreviewMouseMove += this.OnPreviewHostMouseMove;
				IL_2C:
				uielement.PreviewKeyDown += this.OnPreviewHostKeyDown;
				IL_3E:
				this.rootContainer = new SplitContainer();
				this.RootContainer.ChildrenChanged += this.OnRootContainerChildrenChanged;
				base.Content = this.RootContainer;
				if (dockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.WpfWindow)
				{
					this.fadeTimer = new DispatcherTimer();
					this.fadeTimer.Interval = TimeSpan.FromMilliseconds(1000.0);
					this.fadeTimer.Tick += this.OnFadeTimerTick;
				}
				dockSite.DockingStarted += this.OnDockingStarted;
				dockSite.DockingStopped += this.OnDockingStopped;
				DockableWindow.SetDockSituation(this, DockSituation.Floating);
				if (false)
				{
					goto IL_2C;
				}
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0003D8AC File Offset: 0x0003BCAC
		private void OnDockingStopped(object sender, EventArgs e)
		{
			this.dockingInProgress = false;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0003D8B8 File Offset: 0x0003BCB8
		private void OnDockingStarted(object sender, DockingStartedEventArgs e)
		{
			this.dockingInProgress = true;
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0003D8C4 File Offset: 0x0003BCC4
		private x84f4377c0f1291fe CreateNativeFloatingWindowHost()
		{
			return new NativeFloatingWindowHost(this);
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0003D8CC File Offset: 0x0003BCCC
		public void Close()
		{
			this.host.x8ffe90e7fbccfccd();
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0003D8DC File Offset: 0x0003BCDC
		private void OnClosed(object sender, EventArgs e)
		{
			if (this.Closed != null)
			{
				this.Closed(this, e);
			}
			if (this.fadeTimer != null)
			{
				this.fadeTimer.IsEnabled = false;
			}
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0003D908 File Offset: 0x0003BD08
		public void ReturnToFixedLocations(bool restoreFocus)
		{
			DockableWindow primaryWindow = this.GetPrimaryWindow();
			bool flag = (restoreFocus ? 1U : 0U) > uint.MaxValue;
			WindowGroup[] array;
			if (!flag)
			{
				array = xd679d9fc970c8f10.x386f01b6cc4bfd98(this.RootContainer);
				goto IL_C7;
			}
			flag = ((restoreFocus ? 1U : 0U) > uint.MaxValue);
			if (!flag)
			{
				goto IL_C7;
			}
			IL_31:
			WindowGroup windowGroup;
			DockableWindow[] array2 = new DockableWindow[windowGroup.Windows.Count];
			windowGroup.Windows.CopyTo(array2, 0);
			DockableWindow[] array3 = array2;
			int num;
			if ((uint)num <= 4294967295U)
			{
				foreach (DockableWindow dockableWindow in array3)
				{
					xd679d9fc970c8f10.xe3db202f22b97a52(dockableWindow);
					dockableWindow.Document(WindowOpenMethod.OpenSelectActivate);
				}
			}
			IL_90:
			num++;
			IL_96:
			if (num >= array.Length)
			{
				if (primaryWindow != null && restoreFocus)
				{
					base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new EventHandler(this.OnBackgroundActivateWindow), primaryWindow, null);
				}
				return;
			}
			windowGroup = array[num];
			if (windowGroup.SelectedWindow.MetaData.LastFixedDockSituation == DockSituation.Docked)
			{
				WindowGroup windowGroup2 = windowGroup;
				DockableWindow dockableWindow2 = (windowGroup.Items.Count == 1) ? windowGroup.Items[0] : null;
				windowGroup.Dock(WindowOpenMethod.OpenSelectActivate);
				if (dockableWindow2 != null)
				{
					windowGroup2 = (WindowGroup)dockableWindow2.Parent;
				}
				windowGroup2.FadeIn();
				goto IL_90;
			}
			goto IL_31;
			IL_C7:
			num = 0;
			goto IL_96;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0003DA54 File Offset: 0x0003BE54
		private void OnBackgroundActivateWindow(object sender, EventArgs e)
		{
			DockableWindow dockableWindow = (DockableWindow)sender;
			if (dockableWindow.DockSituation != DockSituation.None)
			{
				dockableWindow.SelectAndPopup(true);
			}
		}

		// Token: 0x06000304 RID: 772 RVA: 0x0003DA78 File Offset: 0x0003BE78
		private void OnRootContainerChildrenChanged(object sender, EventArgs e)
		{
			if (this.RootContainer.Children.Count == 1)
			{
				this.PrimaryWindowGroup = (this.RootContainer.Children[0] as WindowGroup);
				return;
			}
			this.PrimaryWindowGroup = null;
		}

		// Token: 0x06000305 RID: 773 RVA: 0x0003DAB4 File Offset: 0x0003BEB4
		private void OnClosing(object sender, CancelEventArgs e)
		{
			foreach (DockableWindow dockableWindow in xd679d9fc970c8f10.x19fa3ae70a75ea3c(this.RootContainer))
			{
				if (!dockableWindow.AllowClose)
				{
					e.Cancel = true;
					return;
				}
			}
			this.isClosing = true;
			try
			{
				foreach (DockableWindow dockableWindow2 in xd679d9fc970c8f10.x19fa3ae70a75ea3c(this.RootContainer))
				{
					if (!dockableWindow2.Close())
					{
						e.Cancel = true;
						break;
					}
				}
			}
			finally
			{
				this.isClosing = false;
			}
		}

		// Token: 0x06000306 RID: 774 RVA: 0x0003DB54 File Offset: 0x0003BF54
		private void OnShowContextMenu(object sender, EventArgs e)
		{
			DockableWindow primaryWindow = this.GetPrimaryWindow();
			if (primaryWindow != null)
			{
				if (this.DockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.WpfWindow)
				{
					primaryWindow.ShowContextMenu(this, new Rect(Mouse.GetPosition(this), new Size(0.0, 0.0)));
					return;
				}
				primaryWindow.ShowContextMenu(null, new Rect(this.GetCursorPosition(), new Size(0.0, 0.0)));
			}
		}

		// Token: 0x06000307 RID: 775 RVA: 0x0003DBCC File Offset: 0x0003BFCC
		private Point GetCursorPosition()
		{
			PresentationSource presentationSource = PresentationSource.FromVisual(this);
			x443cc432acaadb1d.POINT point;
			x443cc432acaadb1d.GetCursorPos(out point);
			Point point2 = new Point((double)point.X, (double)point.Y);
			return presentationSource.CompositionTarget.TransformFromDevice.Transform(point2);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0003DC14 File Offset: 0x0003C014
		private DockableWindow GetPrimaryWindow()
		{
			DockableWindow[] array = xd679d9fc970c8f10.x19fa3ae70a75ea3c(this.RootContainer);
			if (array.Length > 0)
			{
				foreach (DockableWindow dockableWindow in array)
				{
					if (Selector.GetIsSelected(dockableWindow))
					{
						return dockableWindow;
					}
				}
				return array[0];
			}
			return null;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0003DC60 File Offset: 0x0003C060
		internal void StartInteractiveDock(Point startPoint)
		{
			DockingManager dockingManager = new DockingManager(this.DockSite, this, startPoint);
			dockingManager.Start();
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0003DC84 File Offset: 0x0003C084
		private void OnPreviewHostKeyDown(object sender, KeyEventArgs e)
		{
			this.UpdateLastInteraction();
		}

		// Token: 0x0600030B RID: 779 RVA: 0x0003DC8C File Offset: 0x0003C08C
		private void OnPreviewHostMouseMove(object sender, MouseEventArgs e)
		{
			this.UpdateLastInteraction();
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0003DC94 File Offset: 0x0003C094
		private void UpdateLastInteraction()
		{
			this.lastInteraction = Environment.TickCount;
			if (this.dockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.WpfWindow)
			{
				this.UpdateFade();
			}
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0003DCB8 File Offset: 0x0003C0B8
		private void OnFadeTimerTick(object sender, EventArgs e)
		{
			if (this.dockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.WpfWindow)
			{
				this.UpdateFade();
			}
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0003DCD0 File Offset: 0x0003C0D0
		protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnIsKeyboardFocusWithinChanged(e);
			this.UpdateLastInteraction();
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0003DCE0 File Offset: 0x0003C0E0
		private void UpdateFade()
		{
			if (this.dockingInProgress)
			{
				return;
			}
			int num = Math.Max(Environment.TickCount - this.lastInteraction, 0);
			double opacity;
			if (num < FloatingWindowAdapter.FadeThresholdTime || FloatingWindowAdapter.FadeThresholdTime == 0 || base.IsKeyboardFocusWithin)
			{
				opacity = 1.0;
			}
			else if (num < FloatingWindowAdapter.FadeThresholdTime + FloatingWindowAdapter.FadeElapseTime)
			{
				double num2 = (double)(num - FloatingWindowAdapter.FadeThresholdTime) / (double)FloatingWindowAdapter.FadeElapseTime;
				opacity = 1.0 - num2 * 0.85;
			}
			else
			{
				opacity = 0.15000000000000002;
			}
			UIElement uielement = this.host as UIElement;
			if (uielement != null)
			{
				uielement.Opacity = opacity;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000310 RID: 784 RVA: 0x0003DD84 File Offset: 0x0003C184
		// (set) Token: 0x06000311 RID: 785 RVA: 0x0003DD8C File Offset: 0x0003C18C
		public static int FadeThresholdTime
		{
			get
			{
				return FloatingWindowAdapter.fadeThresholdTime;
			}
			set
			{
				value = Math.Max(value, 0);
				FloatingWindowAdapter.fadeThresholdTime = value;
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000312 RID: 786 RVA: 0x0003DDA0 File Offset: 0x0003C1A0
		// (set) Token: 0x06000313 RID: 787 RVA: 0x0003DDA8 File Offset: 0x0003C1A8
		public static int FadeElapseTime
		{
			get
			{
				return FloatingWindowAdapter.fadeElapseTime;
			}
			set
			{
				value = Math.Max(value, 0);
				FloatingWindowAdapter.fadeElapseTime = value;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000314 RID: 788 RVA: 0x0003DDBC File Offset: 0x0003C1BC
		public DockSite DockSite
		{
			get
			{
				return this.dockSite;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0003DDC4 File Offset: 0x0003C1C4
		internal bool IsClosing
		{
			get
			{
				return this.isClosing;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000316 RID: 790 RVA: 0x0003DDCC File Offset: 0x0003C1CC
		// (set) Token: 0x06000317 RID: 791 RVA: 0x0003DDE0 File Offset: 0x0003C1E0
		public string WindowTitle
		{
			get
			{
				return (string)base.GetValue(FloatingWindowAdapter.WindowTitleProperty);
			}
			private set
			{
				base.SetValue(FloatingWindowAdapter.WindowTitlePropertyKey, value);
			}
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0003DDF0 File Offset: 0x0003C1F0
		private static object OnCoerceWindowTitle(DependencyObject element, object value)
		{
			FloatingWindowAdapter floatingWindowAdapter = element as FloatingWindowAdapter;
			if (floatingWindowAdapter.PrimaryWindowGroup != null)
			{
				return floatingWindowAdapter.PrimaryWindowGroup.SelectedWindow.Title;
			}
			return string.Empty;
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000319 RID: 793 RVA: 0x0003DE24 File Offset: 0x0003C224
		// (set) Token: 0x0600031A RID: 794 RVA: 0x0003DE34 File Offset: 0x0003C234
		public Point FloatingLocation
		{
			get
			{
				return this.host.x12992900724b93dc;
			}
			set
			{
				this.host.x12992900724b93dc = value;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600031B RID: 795 RVA: 0x0003DE44 File Offset: 0x0003C244
		// (set) Token: 0x0600031C RID: 796 RVA: 0x0003DE54 File Offset: 0x0003C254
		public Size FloatingSize
		{
			get
			{
				return this.host.xb1090c5821a633b5;
			}
			set
			{
				this.host.xb1090c5821a633b5 = value;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0003DE64 File Offset: 0x0003C264
		public Guid Guid
		{
			get
			{
				return this.guid;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x0600031E RID: 798 RVA: 0x0003DE6C File Offset: 0x0003C26C
		// (set) Token: 0x0600031F RID: 799 RVA: 0x0003DE80 File Offset: 0x0003C280
		public WindowGroup PrimaryWindowGroup
		{
			get
			{
				return (WindowGroup)base.GetValue(FloatingWindowAdapter.PrimaryWindowGroupProperty);
			}
			private set
			{
				base.SetValue(FloatingWindowAdapter.PrimaryWindowGroupPropertyKey, value);
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0003DE90 File Offset: 0x0003C290
		private static void OnPrimaryWindowGroupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			FloatingWindowAdapter floatingWindowAdapter = d as FloatingWindowAdapter;
			if (floatingWindowAdapter != null)
			{
				WindowGroup windowGroup = (WindowGroup)e.OldValue;
				WindowGroup windowGroup2 = (WindowGroup)e.NewValue;
				if (windowGroup != null)
				{
					windowGroup.ShowTitleBar = true;
				}
				if (windowGroup2 != null)
				{
					windowGroup2.ShowTitleBar = false;
				}
				floatingWindowAdapter.CoerceValue(FloatingWindowAdapter.WindowTitleProperty);
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000321 RID: 801 RVA: 0x0003DEE0 File Offset: 0x0003C2E0
		public SplitContainer RootContainer
		{
			get
			{
				return this.rootContainer;
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0003DEE8 File Offset: 0x0003C2E8
		internal void Hide()
		{
			this.host.x5486e0b5e830d25c();
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0003DEF8 File Offset: 0x0003C2F8
		internal void Open()
		{
			this.host.xe410125f7519de90();
			if (this.fadeTimer != null)
			{
				this.fadeTimer.IsEnabled = true;
			}
			this.UpdateLastInteraction();
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0003DF20 File Offset: 0x0003C320
		internal void SetOpacity(double opacity)
		{
			this.host.xd0780bfc7027baa6(opacity);
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0003DF30 File Offset: 0x0003C330
		internal void Activate()
		{
			if (this.host is NativeFloatingWindowHost)
			{
				((Window)this.host).Activate();
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0003DF50 File Offset: 0x0003C350
		internal void PropagateFloatingSizeToWindows()
		{
			Size xb1090c5821a633b = this.host.xb1090c5821a633b5;
			foreach (DockableWindow dockableWindow in xd679d9fc970c8f10.x19fa3ae70a75ea3c(this.RootContainer))
			{
				dockableWindow.FloatingSize = xb1090c5821a633b;
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0003DF90 File Offset: 0x0003C390
		internal void PropagateFloatingLocationToWindows()
		{
			Point x12992900724b93dc = this.host.x12992900724b93dc;
			foreach (DockableWindow dockableWindow in xd679d9fc970c8f10.x19fa3ae70a75ea3c(this.RootContainer))
			{
				dockableWindow.FloatingLocation = new Point?(x12992900724b93dc);
			}
		}

		// Token: 0x04000115 RID: 277
		public static readonly DependencyProperty PrimaryWindowGroupProperty;

		// Token: 0x04000116 RID: 278
		private static readonly DependencyPropertyKey PrimaryWindowGroupPropertyKey;

		// Token: 0x04000117 RID: 279
		public static readonly DependencyProperty WindowTitleProperty;

		// Token: 0x04000118 RID: 280
		private static readonly DependencyPropertyKey WindowTitlePropertyKey;

		// Token: 0x04000119 RID: 281
		private static int fadeThresholdTime = 30000;

		// Token: 0x0400011A RID: 282
		private static int fadeElapseTime = 30000;

		// Token: 0x0400011B RID: 283
		private x84f4377c0f1291fe host;

		// Token: 0x0400011C RID: 284
		private DockSite dockSite;

		// Token: 0x0400011D RID: 285
		private Guid guid;

		// Token: 0x0400011E RID: 286
		private SplitContainer rootContainer;

		// Token: 0x0400011F RID: 287
		private bool isClosing;

		// Token: 0x04000120 RID: 288
		private bool dockingInProgress;

		// Token: 0x04000121 RID: 289
		private DispatcherTimer fadeTimer;

		// Token: 0x04000122 RID: 290
		private int lastInteraction;
	}
}

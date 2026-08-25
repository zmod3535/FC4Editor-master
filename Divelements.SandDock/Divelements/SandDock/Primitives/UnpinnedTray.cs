using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000011 RID: 17
	public class UnpinnedTray : ItemsControl
	{
		// Token: 0x0600015B RID: 347 RVA: 0x00035C9C File Offset: 0x0003409C
		static UnpinnedTray()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(UnpinnedTray), new FrameworkPropertyMetadata(typeof(UnpinnedTray)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(UnpinnedTray), new FrameworkPropertyMetadata(false));
			ItemsControl.ItemsSourceProperty.OverrideMetadata(typeof(UnpinnedTray), new FrameworkPropertyMetadata(null, new CoerceValueCallback(UnpinnedTray.OnCoerceItemsSource)));
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00035D14 File Offset: 0x00034114
		internal UnpinnedTray(DockSite dockSite, PopupContainer popupContainer)
		{
			this.dockSite = dockSite;
			this.popupContainer = popupContainer;
			this.windowGroups = new ObservableCollection<WindowGroup>();
			base.CoerceValue(ItemsControl.ItemsSourceProperty);
			this.hideTimer = new DispatcherTimer();
			this.hideTimer.Interval = TimeSpan.FromMilliseconds(200.0);
			this.hideTimer.Tick += this.OnHideTimerTick;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00035D88 File Offset: 0x00034188
		private static object OnCoerceItemsSource(DependencyObject element, object value)
		{
			UnpinnedTray unpinnedTray = (UnpinnedTray)element;
			return unpinnedTray.WindowGroups;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00035DA4 File Offset: 0x000341A4
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return false;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00035DA8 File Offset: 0x000341A8
		private void OnHideTimerTick(object sender, EventArgs e)
		{
			if (!this.ShowingWindowGroup.IsKeyboardFocusWithin && !base.IsMouseOver && !this.popupContainer.IsMouseOver && (this.ActiveAnimation == null || !this.animationClosing))
			{
				Window window = Window.GetWindow(this);
				if (window == null || window.IsKeyboardFocusWithin)
				{
					this.hideTimer.Stop();
					this.HideWindow(false);
				}
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000160 RID: 352 RVA: 0x00035E0C File Offset: 0x0003420C
		// (set) Token: 0x06000161 RID: 353 RVA: 0x00035E14 File Offset: 0x00034214
		private WindowGroup ShowingWindowGroup
		{
			get
			{
				return this.showingWindowGroup;
			}
			set
			{
				if (value != this.showingWindowGroup)
				{
					if (this.showingWindowGroup != null)
					{
						this.showingWindowGroup.ShowTabs = true;
					}
					this.showingWindowGroup = value;
					this.popupContainer.WindowGroup = this.showingWindowGroup;
					if (this.showingWindowGroup != null)
					{
						this.showingWindowGroup.ShowTabs = false;
						this.popupContainer.Visibility = Visibility.Visible;
						this.popupContainer.UpdateLayout();
						this.hideTimer.Start();
						return;
					}
					this.popupContainer.ClearValue(UIElement.VisibilityProperty);
					this.hideTimer.Stop();
				}
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000162 RID: 354 RVA: 0x00035EAC File Offset: 0x000342AC
		// (set) Token: 0x06000163 RID: 355 RVA: 0x00035EB4 File Offset: 0x000342B4
		private AnimationTimeline ActiveAnimation
		{
			get
			{
				return this.activeAnimation;
			}
			set
			{
				if (value != this.activeAnimation)
				{
					if (this.activeAnimation != null)
					{
						this.activeAnimation.Completed -= this.OnAnimationCompleted;
					}
					this.activeAnimation = value;
					if (this.activeAnimation != null)
					{
						this.activeAnimation.Completed += this.OnAnimationCompleted;
					}
				}
			}
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00035F10 File Offset: 0x00034310
		private void OnAnimationCompleted(object sender, EventArgs e)
		{
			this.ActiveAnimation = null;
			this.popupContainer.RenderTransform = null;
			this.popupContainer.Opacity = 1.0;
			if (this.animationClosing)
			{
				this.HideWindow(true);
			}
			if (this.animationCompletedShowWindow != null)
			{
				DockableWindow window = this.animationCompletedShowWindow;
				this.animationCompletedShowWindow = null;
				this.ShowWindow(window, this.animationCompletedShowWindowActivate);
			}
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00035F78 File Offset: 0x00034378
		internal void ShowWindowPreview(WindowGroup windowGroup)
		{
			if (this.ShowingWindowGroup == null)
			{
				this.ShowingWindowGroup = windowGroup;
				this.HideWindow(false);
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x00035F90 File Offset: 0x00034390
		internal void ShowWindow(DockableWindow window, bool activate)
		{
			WindowGroup windowGroup = window.Parent as WindowGroup;
			if (windowGroup == null || !base.Items.Contains(windowGroup))
			{
				return;
			}
			if (this.ShowingWindowGroup != null && this.ShowingWindowGroup.SelectedWindow == window)
			{
				if (activate)
				{
					window.Activate();
				}
				return;
			}
			if (this.ShowingWindowGroup != null && (this.ActiveAnimation == null || !this.animationClosing))
			{
				this.HideWindow(true);
			}
			if (this.ActiveAnimation != null)
			{
				this.animationCompletedShowWindow = window;
				this.animationCompletedShowWindowActivate = activate;
				return;
			}
			windowGroup.SelectedWindow = window;
			windowGroup.UpdateLayout();
			this.ShowingWindowGroup = windowGroup;
			if (activate)
			{
				window.Activate();
			}
			this.AnimatePopup(false);
		}

		// Token: 0x06000167 RID: 359 RVA: 0x00036038 File Offset: 0x00034438
		internal void HideWindow(bool quick)
		{
			if (this.ShowingWindowGroup != null)
			{
				if (quick)
				{
					this.ShowingWindowGroup = null;
					return;
				}
				this.AnimatePopup(true);
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x00036054 File Offset: 0x00034454
		private void ApplySlideAnimation(bool closing)
		{
			TranslateTransform translateTransform = new TranslateTransform();
			this.popupContainer.RenderTransform = translateTransform;
			switch (DockSite.GetDock(this))
			{
			case Dock.Left:
				if (closing)
				{
					this.ActiveAnimation = new DoubleAnimation(0.0, -LayoutInformation.GetLayoutSlot(this.popupContainer).Width, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupHideAnimationTime)));
				}
				else
				{
					this.ActiveAnimation = new DoubleAnimation(-LayoutInformation.GetLayoutSlot(this.popupContainer).Width, 0.0, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupShowAnimationTime)));
					if (4 == 0)
					{
						break;
					}
				}
				translateTransform.BeginAnimation(TranslateTransform.XProperty, this.ActiveAnimation);
				return;
			case Dock.Top:
				if (closing)
				{
					this.ActiveAnimation = new DoubleAnimation(0.0, -LayoutInformation.GetLayoutSlot(this.popupContainer).Height, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupHideAnimationTime)));
				}
				else
				{
					this.ActiveAnimation = new DoubleAnimation(-LayoutInformation.GetLayoutSlot(this.popupContainer).Height, 0.0, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupShowAnimationTime)));
				}
				translateTransform.BeginAnimation(TranslateTransform.YProperty, this.ActiveAnimation);
				return;
			case Dock.Right:
				if (closing)
				{
					this.ActiveAnimation = new DoubleAnimation(0.0, LayoutInformation.GetLayoutSlot(this.popupContainer).Width, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupHideAnimationTime)));
				}
				else
				{
					this.ActiveAnimation = new DoubleAnimation(LayoutInformation.GetLayoutSlot(this.popupContainer).Width, 0.0, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupShowAnimationTime)));
				}
				translateTransform.BeginAnimation(TranslateTransform.XProperty, this.ActiveAnimation);
				return;
			case Dock.Bottom:
				if (closing)
				{
					this.ActiveAnimation = new DoubleAnimation(0.0, LayoutInformation.GetLayoutSlot(this.popupContainer).Height, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupHideAnimationTime)));
					goto IL_177;
				}
				break;
			default:
				return;
			}
			this.ActiveAnimation = new DoubleAnimation(LayoutInformation.GetLayoutSlot(this.popupContainer).Height, 0.0, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupShowAnimationTime)));
			IL_177:
			translateTransform.BeginAnimation(TranslateTransform.YProperty, this.ActiveAnimation);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x000362F4 File Offset: 0x000346F4
		private void ApplyScaleAnimation(bool closing)
		{
			ScaleTransform scaleTransform = new ScaleTransform();
			this.popupContainer.RenderTransform = scaleTransform;
			if (closing)
			{
				this.ActiveAnimation = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupHideAnimationTime)));
			}
			else
			{
				this.ActiveAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupShowAnimationTime)));
			}
			this.ActiveAnimation.DecelerationRatio = 1.0;
			switch (DockSite.GetDock(this))
			{
			case Dock.Left:
				scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, this.ActiveAnimation);
				return;
			case Dock.Top:
				scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, this.ActiveAnimation);
				return;
			case Dock.Right:
				scaleTransform.CenterX = LayoutInformation.GetLayoutSlot(this.popupContainer).Width;
				scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, this.ActiveAnimation);
				return;
			case Dock.Bottom:
				scaleTransform.CenterY = LayoutInformation.GetLayoutSlot(this.popupContainer).Height;
				scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, this.ActiveAnimation);
				return;
			default:
				return;
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0003642C File Offset: 0x0003482C
		private void ApplyFadeAnimation(bool closing)
		{
			if (closing)
			{
				this.ActiveAnimation = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupHideAnimationTime)));
				this.ActiveAnimation.DecelerationRatio = 1.0;
			}
			else
			{
				this.ActiveAnimation = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromMilliseconds((double)this.dockSite.PopupShowAnimationTime)));
				this.ActiveAnimation.DecelerationRatio = 1.0;
			}
			this.ActiveAnimation.FillBehavior = FillBehavior.Stop;
			this.popupContainer.BeginAnimation(UIElement.OpacityProperty, this.ActiveAnimation);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000364F0 File Offset: 0x000348F0
		private void AnimatePopup(bool closing)
		{
			this.popupContainer.RenderTransform = null;
			this.popupContainer.Opacity = 1.0;
			if (this.dockSite.AnimationType == PopupAnimationType.Slide)
			{
				this.ApplySlideAnimation(closing);
			}
			else if (this.dockSite.AnimationType == PopupAnimationType.Scale)
			{
				this.ApplyScaleAnimation(closing);
			}
			else if (this.dockSite.AnimationType == PopupAnimationType.Fade)
			{
				this.ApplyFadeAnimation(closing);
			}
			else if (this.dockSite.AnimationType == PopupAnimationType.Combined)
			{
				this.ApplySlideAnimation(closing);
				this.ApplyFadeAnimation(closing);
			}
			else
			{
				this.ActiveAnimation = null;
			}
			this.animationClosing = closing;
			if (this.dockSite.AnimationType == PopupAnimationType.None)
			{
				this.OnAnimationCompleted(null, null);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600016C RID: 364 RVA: 0x000365A4 File Offset: 0x000349A4
		internal DockSite DockSite
		{
			get
			{
				return this.dockSite;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600016D RID: 365 RVA: 0x000365AC File Offset: 0x000349AC
		public ObservableCollection<WindowGroup> WindowGroups
		{
			get
			{
				return this.windowGroups;
			}
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000365B4 File Offset: 0x000349B4
		internal void AddWindowGroup(WindowGroup windowGroup)
		{
			this.windowGroups.Add(windowGroup);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000365C4 File Offset: 0x000349C4
		internal void RemoveWindowGroup(WindowGroup windowGroup)
		{
			this.windowGroups.Remove(windowGroup);
			if (this.ShowingWindowGroup == windowGroup)
			{
				this.HideWindow(true);
			}
		}

		// Token: 0x04000060 RID: 96
		private DockSite dockSite;

		// Token: 0x04000061 RID: 97
		private ObservableCollection<WindowGroup> windowGroups;

		// Token: 0x04000062 RID: 98
		private PopupContainer popupContainer;

		// Token: 0x04000063 RID: 99
		private AnimationTimeline activeAnimation;

		// Token: 0x04000064 RID: 100
		private DockableWindow animationCompletedShowWindow;

		// Token: 0x04000065 RID: 101
		private bool animationCompletedShowWindowActivate;

		// Token: 0x04000066 RID: 102
		private bool animationClosing;

		// Token: 0x04000067 RID: 103
		private WindowGroup showingWindowGroup;

		// Token: 0x04000068 RID: 104
		private DispatcherTimer hideTimer;
	}
}

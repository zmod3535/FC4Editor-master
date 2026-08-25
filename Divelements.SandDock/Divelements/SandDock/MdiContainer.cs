using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Divelements.SandDock.Primitives;

namespace Divelements.SandDock
{
	// Token: 0x02000023 RID: 35
	public class MdiContainer : ItemsControl
	{
		// Token: 0x06000261 RID: 609 RVA: 0x0003A160 File Offset: 0x00038560
		static MdiContainer()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MdiContainer), new FrameworkPropertyMetadata(typeof(MdiContainer)));
			ItemsPanelTemplate itemsPanelTemplate = new ItemsPanelTemplate(new FrameworkElementFactory(typeof(MdiPanel)));
			itemsPanelTemplate.Seal();
			ItemsControl.ItemsPanelProperty.OverrideMetadata(typeof(MdiContainer), new FrameworkPropertyMetadata(itemsPanelTemplate));
			UIElement.ClipToBoundsProperty.OverrideMetadata(typeof(MdiContainer), new FrameworkPropertyMetadata(true));
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0003A20C File Offset: 0x0003860C
		// (set) Token: 0x06000264 RID: 612 RVA: 0x0003A214 File Offset: 0x00038614
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

		// Token: 0x06000265 RID: 613 RVA: 0x0003A270 File Offset: 0x00038670
		private void OnAnimationCompleted(object sender, EventArgs e)
		{
			this.CompleteAnimation();
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0003A278 File Offset: 0x00038678
		internal void AnimateWindowStateChange(MdiWindowContainer window, WindowState newState)
		{
			if (this.ActiveAnimation != null)
			{
				this.CompleteAnimation();
			}
			WindowState windowState = MdiPanel.GetWindowState(window);
			if (windowState == newState)
			{
				return;
			}
			this.animatingWindow = window;
			this.animatingWindowState = newState;
			if (this.animationAdorner == null)
			{
				AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
				if (adornerLayer == null)
				{
					this.CompleteAnimation();
					return;
				}
				this.animationAdorner = new MdiContainer.MdiAnimationAdorner(this);
				adornerLayer.Add(this.animationAdorner);
			}
			Rect layoutSlot = LayoutInformation.GetLayoutSlot(window);
			Rect layoutSlot2;
			if (newState == WindowState.Maximized)
			{
				layoutSlot2 = new Rect(0.0, 0.0, base.ActualWidth, base.ActualHeight);
			}
			else
			{
				MdiWindowContainer.EnsureMinimizedPosition(window);
				MdiPanel.SetWindowState(window, newState);
				base.UpdateLayout();
				layoutSlot2 = LayoutInformation.GetLayoutSlot(window);
			}
			MdiPanel.SetWindowState(window, WindowState.Normal);
			do
			{
				this.normalPosition = MdiPanel.GetNormalPosition(window);
				if (2147483647 == 0)
				{
					return;
				}
				MdiPanel.SetNormalPosition(window, new Point(-100000.0, -100000.0));
			}
			while (false);
			if (newState == WindowState.Minimized)
			{
				this.animationAdorner.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(1.0, 0.3, new Duration(TimeSpan.FromMilliseconds(250.0)), FillBehavior.Stop));
			}
			else if (windowState == WindowState.Minimized)
			{
				this.animationAdorner.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(0.3, 1.0, new Duration(TimeSpan.FromMilliseconds(250.0)), FillBehavior.Stop));
			}
			this.ActiveAnimation = new RectAnimation(layoutSlot, layoutSlot2, new Duration(TimeSpan.FromMilliseconds(250.0)));
			VisualBrush visualBrush = new VisualBrush(window);
			visualBrush.AutoLayoutContent = false;
			RenderOptions.SetCachingHint(visualBrush, CachingHint.Cache);
			this.animationAdorner.VisualBrush = visualBrush;
			this.animationAdorner.BeginAnimation(MdiContainer.MdiAnimationAdorner.PreviewBoundsProperty, this.ActiveAnimation);
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0003A454 File Offset: 0x00038854
		private void CompleteAnimation()
		{
			this.ActiveAnimation = null;
			if (this.animationAdorner != null)
			{
				this.animationAdorner.PreviewBounds = Rect.Empty;
				this.animationAdorner.VisualBrush = null;
			}
			MdiPanel.SetNormalPosition(this.animatingWindow, this.normalPosition);
			this.animatingWindow.Visibility = Visibility.Visible;
			MdiPanel.SetWindowState(this.animatingWindow, this.animatingWindowState);
			this.animatingWindow = null;
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0003A4C4 File Offset: 0x000388C4
		public void SetWindowState(DockableWindow window, WindowState state)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			if (window.Child == null)
			{
				throw new InvalidOperationException();
			}
			MdiWindowContainer mdiWindowContainer = (MdiWindowContainer)base.ContainerFromElement(window);
			if (mdiWindowContainer != null)
			{
				MdiPanel.SetWindowState(mdiWindowContainer, state);
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0003A504 File Offset: 0x00038904
		public WindowState GetWindowState(DockableWindow window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			if (window.Child == null)
			{
				throw new InvalidOperationException();
			}
			MdiWindowContainer mdiWindowContainer = (MdiWindowContainer)base.ContainerFromElement(window);
			if (mdiWindowContainer != null)
			{
				return MdiPanel.GetWindowState(mdiWindowContainer);
			}
			return WindowState.Normal;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0003A548 File Offset: 0x00038948
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new MdiWindowContainer();
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0003A550 File Offset: 0x00038950
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return false;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0003A554 File Offset: 0x00038954
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			base.PrepareContainerForItemOverride(element, item);
			MdiWindowContainer mdiWindowContainer = element as MdiWindowContainer;
			DockableWindow dockableWindow = item as DockableWindow;
			if (mdiWindowContainer != null)
			{
				while (dockableWindow != null)
				{
					mdiWindowContainer.Content = dockableWindow;
					if (DependencyPropertyHelper.GetValueSource(dockableWindow, MdiPanel.RestoredSizeProperty).BaseValueSource == BaseValueSource.Default)
					{
						goto IL_350;
					}
					goto IL_276;
					IL_14:
					Binding binding;
					binding.Source = dockableWindow;
					mdiWindowContainer.SetBinding(MdiPanel.ResizeModeProperty, binding);
					binding = new Binding();
					if (false)
					{
						continue;
					}
					binding.Path = new PropertyPath(MdiPanel.WindowStateProperty);
					binding.Mode = BindingMode.OneWay;
					binding.Source = dockableWindow;
					mdiWindowContainer.SetBinding(MdiPanel.WindowStateProperty, binding);
					binding = new Binding();
					binding.Path = new PropertyPath(DockableWindow.TitleProperty);
					binding.Mode = BindingMode.TwoWay;
					binding.Source = dockableWindow;
					mdiWindowContainer.SetBinding(MdiWindowContainer.TitleProperty, binding);
					binding = new Binding();
					binding.Path = new PropertyPath(DockableWindow.ImageProperty);
					binding.Mode = BindingMode.OneWay;
					binding.Source = dockableWindow;
					mdiWindowContainer.SetBinding(MdiWindowContainer.IconProperty, binding);
					dockableWindow.ShouldActivate += this.OnWindowShouldActivate;
					mdiWindowContainer.xb451d7f50d849473 += this.OnWindowContainerClosing;
					mdiWindowContainer.x289bf94a509dd84c += this.OnWindowContainerClosed;
					mdiWindowContainer.xa92b80a72ea23242 += this.OnWindowContainerShowContextMenu;
					if (4 == 0)
					{
						if (false)
						{
							goto IL_225;
						}
						goto IL_2EF;
					}
					else
					{
						if (false)
						{
							goto IL_350;
						}
						break;
					}
					IL_348:
					binding.Mode = BindingMode.OneWay;
					goto IL_14;
					IL_2EF:
					Size size;
					if (size.Width != 0.0 || size.Height != 0.0)
					{
						goto IL_225;
					}
					DocumentContainer documentContainer = base.Parent as DocumentContainer;
					if (documentContainer == null)
					{
						goto IL_225;
					}
					size = new Size(documentContainer.ActualWidth, documentContainer.ActualHeight);
					if (false)
					{
						goto IL_348;
					}
					goto IL_225;
					IL_276:
					if (DependencyPropertyHelper.GetValueSource(dockableWindow, MdiPanel.NormalPositionProperty).BaseValueSource == BaseValueSource.Default)
					{
						mdiWindowContainer.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
						if (base.ActualWidth != 0.0)
						{
							if (this.nextWindowLocation.X + mdiWindowContainer.DesiredSize.Width <= base.ActualWidth)
							{
								if (false)
								{
									goto IL_2ED;
								}
								if (this.nextWindowLocation.Y + mdiWindowContainer.DesiredSize.Height <= base.ActualHeight)
								{
									goto IL_15E;
								}
							}
							this.nextWindowLocation = new Point(0.0, 0.0);
						}
						IL_15E:
						MdiPanel.SetNormalPosition(dockableWindow, this.nextWindowLocation);
						this.nextWindowLocation += new Vector(SystemParameters.CaptionHeight + 4.0, SystemParameters.CaptionHeight + 4.0);
					}
					binding = new Binding();
					binding.Path = new PropertyPath(MdiPanel.NormalPositionProperty);
					binding.Mode = BindingMode.TwoWay;
					binding.Source = dockableWindow;
					mdiWindowContainer.SetBinding(MdiPanel.NormalPositionProperty, binding);
					binding = new Binding();
					binding.Path = new PropertyPath(MdiPanel.RestoredSizeProperty);
					binding.Mode = BindingMode.TwoWay;
					binding.Source = dockableWindow;
					mdiWindowContainer.SetBinding(MdiPanel.RestoredSizeProperty, binding);
					if (-2147483648 == 0)
					{
						goto IL_14;
					}
					binding = new Binding();
					binding.Path = new PropertyPath(MdiPanel.ResizeModeProperty);
					IL_2ED:
					goto IL_348;
					IL_225:
					if (size.Width != 0.0 && size.Height != 0.0)
					{
						MdiPanel.SetRestoredSize(dockableWindow, new Size(size.Width * 0.7, size.Height * 0.6));
						goto IL_276;
					}
					goto IL_276;
					IL_350:
					size = new Size(base.ActualWidth, base.ActualHeight);
					goto IL_2EF;
				}
			}
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0003A900 File Offset: 0x00038D00
		private void OnWindowContainerShowContextMenu(object sender, EventArgs e)
		{
			MdiWindowContainer container = (MdiWindowContainer)sender;
			DockableWindow dockableWindow = base.ItemContainerGenerator.ItemFromContainer(container) as DockableWindow;
			dockableWindow.ShowContextMenu(this, new Rect(Mouse.GetPosition(this), new Size(0.0, 0.0)));
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0003A950 File Offset: 0x00038D50
		private void OnWindowContainerClosing(object sender, CancelEventArgs e)
		{
			MdiWindowContainer container = (MdiWindowContainer)sender;
			DockableWindow dockableWindow = base.ItemContainerGenerator.ItemFromContainer(container) as DockableWindow;
			dockableWindow.OnClosing(e);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0003A980 File Offset: 0x00038D80
		private void OnWindowContainerClosed(object sender, EventArgs e)
		{
			MdiWindowContainer container = (MdiWindowContainer)sender;
			DockableWindow dockableWindow = base.ItemContainerGenerator.ItemFromContainer(container) as DockableWindow;
			dockableWindow.OnClosed(e);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0003A9B0 File Offset: 0x00038DB0
		private void OnWindowShouldActivate(object sender, EventArgs e)
		{
			DockableWindow dockableWindow = (DockableWindow)sender;
			MdiContainer mdiContainer = dockableWindow.Parent as MdiContainer;
			if (mdiContainer != null)
			{
				MdiWindowContainer mdiWindowContainer = mdiContainer.ContainerFromElement(dockableWindow) as MdiWindowContainer;
				if (mdiWindowContainer != null)
				{
					MdiPanel mdiPanel = VisualTreeHelper.GetParent(mdiWindowContainer) as MdiPanel;
					if (mdiPanel != null)
					{
						mdiPanel.BringToFront(mdiWindowContainer);
					}
				}
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000271 RID: 625 RVA: 0x0003A9FC File Offset: 0x00038DFC
		private Panel ItemsHost
		{
			get
			{
				return (Panel)typeof(ItemsControl).GetProperty("ItemsHost", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this, null);
			}
		}

		// Token: 0x040000C4 RID: 196
		private const int ANIMATIONTIME = 250;

		// Token: 0x040000C5 RID: 197
		private Point nextWindowLocation = new Point(0.0, 0.0);

		// Token: 0x040000C6 RID: 198
		private MdiContainer.MdiAnimationAdorner animationAdorner;

		// Token: 0x040000C7 RID: 199
		private AnimationTimeline activeAnimation;

		// Token: 0x040000C8 RID: 200
		private MdiWindowContainer animatingWindow;

		// Token: 0x040000C9 RID: 201
		private WindowState animatingWindowState;

		// Token: 0x040000CA RID: 202
		private Point normalPosition;

		// Token: 0x02000024 RID: 36
		private class MdiAnimationAdorner : Adorner
		{
			// Token: 0x06000272 RID: 626 RVA: 0x0003AA30 File Offset: 0x00038E30
			static MdiAnimationAdorner()
			{
				UIElement.IsHitTestVisibleProperty.OverrideMetadata(typeof(MdiContainer.MdiAnimationAdorner), new FrameworkPropertyMetadata(false));
				MdiContainer.MdiAnimationAdorner.PreviewBoundsProperty = DependencyProperty.Register("PreviewBounds", typeof(Rect), typeof(MdiContainer.MdiAnimationAdorner), new FrameworkPropertyMetadata(Rect.Empty, FrameworkPropertyMetadataOptions.AffectsRender));
			}

			// Token: 0x06000273 RID: 627 RVA: 0x0003AA90 File Offset: 0x00038E90
			public MdiAnimationAdorner(MdiContainer parent) : base(parent)
			{
				this.parent = parent;
			}

			// Token: 0x1700009D RID: 157
			// (get) Token: 0x06000274 RID: 628 RVA: 0x0003AAA0 File Offset: 0x00038EA0
			// (set) Token: 0x06000275 RID: 629 RVA: 0x0003AAB4 File Offset: 0x00038EB4
			public Rect PreviewBounds
			{
				get
				{
					return (Rect)base.GetValue(MdiContainer.MdiAnimationAdorner.PreviewBoundsProperty);
				}
				set
				{
					base.SetValue(MdiContainer.MdiAnimationAdorner.PreviewBoundsProperty, value);
				}
			}

			// Token: 0x1700009E RID: 158
			// (get) Token: 0x06000276 RID: 630 RVA: 0x0003AAC8 File Offset: 0x00038EC8
			// (set) Token: 0x06000277 RID: 631 RVA: 0x0003AAD0 File Offset: 0x00038ED0
			public VisualBrush VisualBrush
			{
				get
				{
					return this.visualBrush;
				}
				set
				{
					this.visualBrush = value;
				}
			}

			// Token: 0x06000278 RID: 632 RVA: 0x0003AADC File Offset: 0x00038EDC
			protected override void OnRender(DrawingContext drawingContext)
			{
				base.OnRender(drawingContext);
				if (this.PreviewBounds != Rect.Empty && this.VisualBrush != null)
				{
					drawingContext.DrawRectangle(this.VisualBrush, null, this.PreviewBounds);
				}
			}

			// Token: 0x040000CB RID: 203
			private MdiContainer parent;

			// Token: 0x040000CC RID: 204
			public static readonly DependencyProperty PreviewBoundsProperty;

			// Token: 0x040000CD RID: 205
			private VisualBrush visualBrush;
		}
	}
}

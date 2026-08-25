using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Divelements.SandDock.Primitives;

namespace Divelements.SandDock.Switching
{
	// Token: 0x02000059 RID: 89
	public class WindowPreview : Control
	{
		// Token: 0x06000461 RID: 1121 RVA: 0x00044F20 File Offset: 0x00043320
		static WindowPreview()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowPreview), new FrameworkPropertyMetadata(typeof(WindowPreview)));
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x00044F7C File Offset: 0x0004337C
		internal WindowPreview(DockableWindow window)
		{
			if (window == null)
			{
				throw new ArgumentNullException("window");
			}
			this.Window = window;
			this.contentPresenter = new ContentPresenter();
			this.CalculateWindowSize();
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x00044FB8 File Offset: 0x000433B8
		private void CalculateWindowSize()
		{
			if (this.Window.DockSituation != DockSituation.Floating)
			{
				goto IL_3C1;
			}
			if (false)
			{
				goto IL_24B;
			}
			goto IL_357;
			IL_18C:
			MdiContainer mdiContainer = this.Window.Parent as MdiContainer;
			if (mdiContainer != null)
			{
				MdiWindowContainer mdiWindowContainer = (MdiWindowContainer)mdiContainer.ContainerFromElement(this.Window);
				Rect layoutSlot = LayoutInformation.GetLayoutSlot(mdiWindowContainer);
				this.windowSize = layoutSlot.Size;
				this.windowPosition = ((UIElement)VisualTreeHelper.GetParent(mdiWindowContainer)).TransformToVisual(this.Window.DockSite).Transform(layoutSlot.TopLeft);
			}
			if (this.windowSize == Size.Empty)
			{
				this.windowSize = this.Window.FloatingSize;
			}
			this.contentPresenter.Width = this.windowSize.Width;
			this.contentPresenter.Height = this.windowSize.Height;
			goto IL_34D;
			IL_24B:
			WindowGroup windowGroup;
			this.windowSize = new Size(windowGroup.ActualWidth, windowGroup.ActualHeight);
			if (windowGroup.FindCommonVisualAncestor(this.Window.DockSite) == null)
			{
				this.windowPosition = this.Window.DockSite.PointFromScreen(windowGroup.PointToScreen(new Point(0.0, 0.0)));
				goto IL_18C;
			}
			this.windowPosition = windowGroup.TransformToVisual(this.Window.DockSite).Transform(new Point(0.0, 0.0));
			goto IL_18C;
			IL_34D:
			if (-2147483648 != 0)
			{
				return;
			}
			IL_357:
			if (this.Window.DockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.WpfWindow)
			{
				FloatingWindowAdapter floatingWindowAdapter = xd679d9fc970c8f10.x94eafc5f4a9a0734(this.Window);
				MdiWindowContainer mdiWindowContainer2 = (MdiWindowContainer)floatingWindowAdapter.Parent;
				this.windowSize = mdiWindowContainer2.RenderSize;
				this.windowPosition = mdiWindowContainer2.TransformToVisual(this.Window.DockSite).Transform(new Point(0.0, 0.0));
			}
			IL_3C1:
			windowGroup = (this.Window.Parent as WindowGroup);
			if (!(this.windowSize == Size.Empty) || windowGroup == null)
			{
				goto IL_18C;
			}
			if (windowGroup.Pinned)
			{
				if (!false)
				{
					goto IL_24B;
				}
			}
			else
			{
				if (windowGroup.Tray == null)
				{
					goto IL_18C;
				}
				switch (DockSite.GetDock(windowGroup.Tray))
				{
				case Dock.Left:
					this.windowSize = new Size(windowGroup.SelectedWindow.ContentSize, windowGroup.Tray.RenderSize.Height);
					if (!true)
					{
						goto IL_34D;
					}
					this.windowPosition = windowGroup.Tray.TransformToVisual(this.Window.DockSite).Transform(new Point(-this.windowSize.Width, 0.0));
					goto IL_18C;
				case Dock.Top:
					this.windowSize = new Size(windowGroup.Tray.RenderSize.Width, windowGroup.SelectedWindow.ContentSize);
					this.windowPosition = windowGroup.Tray.TransformToVisual(this.Window.DockSite).Transform(new Point(0.0, -this.windowSize.Height));
					goto IL_18C;
				case Dock.Right:
					this.windowSize = new Size(windowGroup.SelectedWindow.ContentSize, windowGroup.Tray.RenderSize.Height);
					this.windowPosition = windowGroup.Tray.TransformToVisual(this.Window.DockSite).Transform(new Point(0.0, 0.0));
					goto IL_18C;
				case Dock.Bottom:
					this.windowSize = new Size(windowGroup.Tray.RenderSize.Width, windowGroup.SelectedWindow.ContentSize);
					this.windowPosition = windowGroup.Tray.TransformToVisual(this.Window.DockSite).Transform(new Point(0.0, 0.0));
					goto IL_18C;
				default:
					goto IL_18C;
				}
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x000453C4 File Offset: 0x000437C4
		internal bool HasSwappedContent
		{
			get
			{
				return this.contentPresenter.Content != null;
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x000453D8 File Offset: 0x000437D8
		internal void SetSwappedContent(UIElement content)
		{
			this.contentPresenter.Content = content;
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x000453E8 File Offset: 0x000437E8
		public ContentPresenter SwappedContentPresenter
		{
			get
			{
				return this.contentPresenter;
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x06000467 RID: 1127 RVA: 0x000453F0 File Offset: 0x000437F0
		public Size WindowSize
		{
			get
			{
				return this.windowSize;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x000453F8 File Offset: 0x000437F8
		public Point WindowPosition
		{
			get
			{
				return this.windowPosition;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000469 RID: 1129 RVA: 0x00045400 File Offset: 0x00043800
		// (set) Token: 0x0600046A RID: 1130 RVA: 0x00045414 File Offset: 0x00043814
		public DockableWindow Window
		{
			get
			{
				return (DockableWindow)base.GetValue(WindowPreview.WindowProperty);
			}
			set
			{
				base.SetValue(WindowPreview.WindowProperty, value);
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x0600046B RID: 1131 RVA: 0x00045424 File Offset: 0x00043824
		public WindowPreviewType PreviewType
		{
			get
			{
				if (this.Window.Parent is MdiContainer)
				{
					return WindowPreviewType.OriginalChild;
				}
				if (this.Window.DockSituation == DockSituation.Floating && this.Window.DockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.WpfWindow && this.Window.Parent is WindowGroup && ((WindowGroup)this.Window.Parent).SelectedWindow == this.Window)
				{
					return WindowPreviewType.OriginalWindow;
				}
				if (this.Window.Parent is WindowGroup && ((WindowGroup)this.Window.Parent).SelectedWindow == this.Window && ((WindowGroup)this.Window.Parent).Pinned)
				{
					return WindowPreviewType.OriginalChild;
				}
				return WindowPreviewType.TemporarySwap;
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x000454E0 File Offset: 0x000438E0
		public VisualBrush PreviewBrush
		{
			get
			{
				if (this.visualBrush == null)
				{
					if (this.PreviewType == WindowPreviewType.TemporarySwap || this.PreviewType == WindowPreviewType.OriginalChild)
					{
						this.visualBrush = new VisualBrush(this);
					}
					else
					{
						MdiContainer mdiContainer = this.Window.Parent as MdiContainer;
						if (mdiContainer != null)
						{
							MdiWindowContainer visual = (MdiWindowContainer)ItemsControl.ContainerFromElement(mdiContainer, this.Window);
							this.visualBrush = new VisualBrush(visual);
						}
						if (this.Window.DockSituation == DockSituation.Floating && this.Window.DockSite.FloatingWindowDisplayStrategy == FloatingWindowDisplayStrategy.WpfWindow)
						{
							FloatingWindowAdapter floatingWindowAdapter = xd679d9fc970c8f10.x94eafc5f4a9a0734(this.Window);
							this.visualBrush = new VisualBrush((Visual)floatingWindowAdapter.Parent);
						}
						if (this.visualBrush == null)
						{
							this.visualBrush = new VisualBrush(this.Window);
						}
					}
				}
				return this.visualBrush;
			}
		}

		// Token: 0x040001D3 RID: 467
		public static readonly DependencyProperty WindowProperty = DependencyProperty.Register("Window", typeof(DockableWindow), typeof(WindowPreview), new FrameworkPropertyMetadata(null));

		// Token: 0x040001D4 RID: 468
		private VisualBrush visualBrush;

		// Token: 0x040001D5 RID: 469
		private Size windowSize = Size.Empty;

		// Token: 0x040001D6 RID: 470
		private Point windowPosition;

		// Token: 0x040001D7 RID: 471
		private ContentPresenter contentPresenter;
	}
}

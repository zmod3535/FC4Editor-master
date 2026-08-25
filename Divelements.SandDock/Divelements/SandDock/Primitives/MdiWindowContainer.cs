using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000025 RID: 37
	[TemplatePart(Name = "PART_SystemIcon", Type = typeof(FrameworkElement))]
	[TemplatePart(Name = "PART_MainBorder", Type = typeof(FrameworkElement))]
	[TemplatePart(Name = "PART_TitleBar", Type = typeof(FrameworkElement))]
	public class MdiWindowContainer : ContentControl
	{
		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000279 RID: 633 RVA: 0x0003AB14 File Offset: 0x00038F14
		// (remove) Token: 0x0600027A RID: 634 RVA: 0x0003AB4C File Offset: 0x00038F4C
		public event CancelEventHandler xb451d7f50d849473
		{
			add
			{
				CancelEventHandler cancelEventHandler = this.Closing;
				CancelEventHandler cancelEventHandler2;
				do
				{
					cancelEventHandler2 = cancelEventHandler;
					CancelEventHandler value2 = (CancelEventHandler)Delegate.Combine(cancelEventHandler2, value);
					cancelEventHandler = Interlocked.CompareExchange<CancelEventHandler>(ref this.Closing, value2, cancelEventHandler2);
				}
				while (cancelEventHandler != cancelEventHandler2);
			}
			remove
			{
				CancelEventHandler cancelEventHandler = this.Closing;
				CancelEventHandler cancelEventHandler2;
				do
				{
					cancelEventHandler2 = cancelEventHandler;
					CancelEventHandler value2 = (CancelEventHandler)Delegate.Remove(cancelEventHandler2, value);
					cancelEventHandler = Interlocked.CompareExchange<CancelEventHandler>(ref this.Closing, value2, cancelEventHandler2);
				}
				while (cancelEventHandler != cancelEventHandler2);
			}
		}

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x0600027B RID: 635 RVA: 0x0003AB84 File Offset: 0x00038F84
		// (remove) Token: 0x0600027C RID: 636 RVA: 0x0003ABBC File Offset: 0x00038FBC
		public event EventHandler x289bf94a509dd84c
		{
			add
			{
				EventHandler eventHandler = this.Closed;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.Closed, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.Closed;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.Closed, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
			}
		}

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x0600027D RID: 637 RVA: 0x0003ABF4 File Offset: 0x00038FF4
		// (remove) Token: 0x0600027E RID: 638 RVA: 0x0003AC2C File Offset: 0x0003902C
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

		// Token: 0x0600027F RID: 639 RVA: 0x0003AC64 File Offset: 0x00039064
		static MdiWindowContainer()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(MdiWindowContainer), new FrameworkPropertyMetadata(typeof(MdiWindowContainer)));
			MdiWindowContainer.CanMaximizeProperty = DependencyProperty.Register("CanMaximize", typeof(bool), typeof(MdiWindowContainer), new FrameworkPropertyMetadata(true));
			MdiWindowContainer.CanMinimizeProperty = DependencyProperty.Register("CanMinimize", typeof(bool), typeof(MdiWindowContainer), new FrameworkPropertyMetadata(true));
			MdiWindowContainer.WindowStyleProperty = DependencyProperty.Register("WindowStyle", typeof(WindowStyle), typeof(MdiWindowContainer), new FrameworkPropertyMetadata(WindowStyle.ThreeDBorderWindow), new ValidateValueCallback(MdiWindowContainer.OnValidateWindowStyle));
			MdiWindowContainer.TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MdiWindowContainer), new FrameworkPropertyMetadata(string.Empty));
			MdiWindowContainer.IconProperty = DependencyProperty.Register("Icon", typeof(ImageSource), typeof(MdiWindowContainer), new FrameworkPropertyMetadata(null));
			MdiWindowContainer.HasDropShadowProperty = DependencyProperty.Register("HasDropShadow", typeof(bool), typeof(MdiWindowContainer), new FrameworkPropertyMetadata(false));
			MdiWindowContainer.SetClientSizeProperty = DependencyProperty.Register("SetClientSize", typeof(bool), typeof(MdiWindowContainer), new FrameworkPropertyMetadata(true));
			CommandManager.RegisterClassCommandBinding(typeof(MdiWindowContainer), new CommandBinding(ApplicationCommands.Close, new ExecutedRoutedEventHandler(MdiWindowContainer.OnCommand), new CanExecuteRoutedEventHandler(MdiWindowContainer.OnCanExecute)));
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0003AE20 File Offset: 0x00039220
		private static void OnCommand(object sender, ExecutedRoutedEventArgs e)
		{
			MdiWindowContainer mdiWindowContainer = (MdiWindowContainer)sender;
			if (e.Command == ApplicationCommands.Close)
			{
				mdiWindowContainer.Close();
			}
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0003AE48 File Offset: 0x00039248
		private static void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
		{
			if (e.Command == ApplicationCommands.Close)
			{
				e.CanExecute = true;
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0003AE60 File Offset: 0x00039260
		public bool Close()
		{
			CancelEventArgs cancelEventArgs = new CancelEventArgs();
			this.OnClosing(cancelEventArgs);
			if (cancelEventArgs.Cancel)
			{
				return false;
			}
			MdiContainer mdiContainer = ItemsControl.ItemsControlFromItemContainer(this) as MdiContainer;
			if (mdiContainer != null)
			{
				object obj = mdiContainer.ItemContainerGenerator.ItemFromContainer(this);
				if (obj != null)
				{
					this.OnClosed(EventArgs.Empty);
					mdiContainer.Items.Remove(obj);
					return true;
				}
			}
			MdiPanel mdiPanel = base.VisualParent as MdiPanel;
			if (mdiPanel != null)
			{
				mdiPanel.Children.Remove(this);
				this.OnClosed(EventArgs.Empty);
				return true;
			}
			return false;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0003AEE8 File Offset: 0x000392E8
		protected virtual void OnClosing(CancelEventArgs e)
		{
			if (this.Closing != null)
			{
				this.Closing(this, e);
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0003AF00 File Offset: 0x00039300
		protected virtual void OnClosed(EventArgs e)
		{
			if (this.Closed != null)
			{
				this.Closed(this, e);
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0003AF18 File Offset: 0x00039318
		protected override void OnPreviewMouseDown(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseDown(e);
			MdiPanel mdiPanel = base.VisualParent as MdiPanel;
			if (mdiPanel != null)
			{
				mdiPanel.BringToFront(this);
			}
			if (!base.IsKeyboardFocusWithin)
			{
				this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
			}
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0003AF58 File Offset: 0x00039358
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			for (;;)
			{
				if (this.titleBar != null)
				{
					this.titleBar.MouseLeftButtonDown -= this.OnTitleBarMouseLeftButtonDown;
					this.titleBar.MouseLeftButtonUp -= this.OnTitleBarMouseLeftButtonUp;
					this.titleBar.MouseMove -= this.OnTitleBarMouseMove;
					this.titleBar.LostMouseCapture -= this.OnTitleBarLostMouseCapture;
					this.titleBar.MouseRightButtonUp -= this.OnTitleBarMouseRightButtonUp;
				}
				if (this.mainBorder == null)
				{
					goto IL_264;
				}
				this.mainBorder.MouseMove -= this.OnMainBorderMouseMove;
				this.mainBorder.MouseLeftButtonDown -= this.OnMainBorderMouseLeftButtonDown;
				this.mainBorder.MouseLeftButtonUp -= this.OnMainBorderMouseLeftButtonUp;
				this.mainBorder.LostMouseCapture -= this.OnMainBorderLostMouseCapture;
				if (!false)
				{
					goto IL_264;
				}
				IL_2ED:
				this.systemIcon = (base.GetTemplateChild("PART_SystemIcon") as FrameworkElement);
				this.templateMinimizeButton = (base.GetTemplateChild("PART_MinimizeButton") as ButtonBase);
				this.templateMaximizeButton = (base.GetTemplateChild("PART_MaximizeButton") as ButtonBase);
				if (this.titleBar != null)
				{
					this.titleBar.MouseLeftButtonDown += this.OnTitleBarMouseLeftButtonDown;
					this.titleBar.MouseLeftButtonUp += this.OnTitleBarMouseLeftButtonUp;
					this.titleBar.MouseMove += this.OnTitleBarMouseMove;
					this.titleBar.LostMouseCapture += this.OnTitleBarLostMouseCapture;
					this.titleBar.MouseRightButtonUp += this.OnTitleBarMouseRightButtonUp;
				}
				if (this.mainBorder != null)
				{
					this.mainBorder.MouseMove += this.OnMainBorderMouseMove;
					this.mainBorder.MouseLeftButtonDown += this.OnMainBorderMouseLeftButtonDown;
					this.mainBorder.MouseLeftButtonUp += this.OnMainBorderMouseLeftButtonUp;
					this.mainBorder.LostMouseCapture += this.OnMainBorderLostMouseCapture;
				}
				if (this.systemIcon == null)
				{
					break;
				}
				this.systemIcon.MouseLeftButtonDown += this.OnSystemIconMouseLeftButtonDown;
				if (-2147483648 == 0)
				{
					continue;
				}
				break;
				IL_264:
				if (this.systemIcon != null)
				{
					this.systemIcon.MouseLeftButtonDown -= this.OnSystemIconMouseLeftButtonDown;
				}
				if (this.templateMinimizeButton != null)
				{
					this.templateMinimizeButton.Click -= this.OnMinimizeButtonClick;
				}
				if (this.templateMaximizeButton != null)
				{
					this.templateMaximizeButton.Click -= this.OnMaximizeButtonClick;
				}
				this.titleBar = (base.GetTemplateChild("PART_TitleBar") as FrameworkElement);
				this.mainBorder = (base.GetTemplateChild("PART_MainBorder") as FrameworkElement);
				goto IL_2ED;
			}
			IL_0B:
			if (this.templateMinimizeButton != null)
			{
				this.templateMinimizeButton.Click += this.OnMinimizeButtonClick;
			}
			if (this.templateMaximizeButton != null)
			{
				this.templateMaximizeButton.Click += this.OnMaximizeButtonClick;
			}
			return;
			goto IL_0B;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0003B290 File Offset: 0x00039690
		private void OnMaximizeButtonClick(object sender, RoutedEventArgs e)
		{
			MdiContainer mdiContainer = ItemsControl.ItemsControlFromItemContainer(this) as MdiContainer;
			if (mdiContainer != null)
			{
				if (MdiPanel.GetWindowState(this) == WindowState.Maximized)
				{
					mdiContainer.AnimateWindowStateChange(this, WindowState.Normal);
					return;
				}
				mdiContainer.AnimateWindowStateChange(this, WindowState.Maximized);
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0003B2C8 File Offset: 0x000396C8
		private void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
		{
			MdiContainer mdiContainer = ItemsControl.ItemsControlFromItemContainer(this) as MdiContainer;
			if (mdiContainer != null)
			{
				if (MdiPanel.GetWindowState(this) == WindowState.Minimized)
				{
					mdiContainer.AnimateWindowStateChange(this, WindowState.Normal);
					return;
				}
				mdiContainer.AnimateWindowStateChange(this, WindowState.Minimized);
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0003B300 File Offset: 0x00039700
		protected virtual void OnShowContextMenu(EventArgs e)
		{
			if (this.ShowContextMenu != null)
			{
				this.ShowContextMenu(this, e);
			}
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0003B318 File Offset: 0x00039718
		private void OnTitleBarMouseRightButtonUp(object sender, MouseButtonEventArgs e)
		{
			this.OnShowContextMenu(EventArgs.Empty);
			e.Handled = true;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0003B32C File Offset: 0x0003972C
		private void OnSystemIconMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 2)
			{
				this.Close();
				e.Handled = true;
			}
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0003B348 File Offset: 0x00039748
		private bool CanResizeEdge()
		{
			ResizeMode resizeMode = MdiPanel.GetResizeMode(this);
			return resizeMode == ResizeMode.CanResize || resizeMode == ResizeMode.CanResizeWithGrip;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0003B368 File Offset: 0x00039768
		private void OnMainBorderMouseMove(object sender, MouseEventArgs e)
		{
			if (this.resizeData != null)
			{
				e.Handled = true;
				this.HandleResizeMouseMove(this.PointToParent(e.GetPosition(this)));
				return;
			}
			if (e.OriginalSource != this.mainBorder)
			{
				this.mainBorder.ClearValue(FrameworkElement.CursorProperty);
				return;
			}
			Cursor cursor = this.CursorFromResizeEdge(this.GetMainBorderResizeEdge(e));
			if (cursor == Cursors.Arrow)
			{
				this.mainBorder.ClearValue(FrameworkElement.CursorProperty);
				return;
			}
			this.mainBorder.Cursor = cursor;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0003B3EC File Offset: 0x000397EC
		private Cursor CursorFromResizeEdge(xe189190bd5894d4f resizeEdge)
		{
			switch (resizeEdge)
			{
			default:
				return Cursors.Arrow;
			case xe189190bd5894d4f.xc3ae914e60da748f:
			case xe189190bd5894d4f.xbedfa137d9910ba4:
				return Cursors.SizeNWSE;
			case xe189190bd5894d4f.xe360b1885d8d4a41:
			case xe189190bd5894d4f.x9bcb07e204e30218:
				return Cursors.SizeNS;
			case xe189190bd5894d4f.x46c964a11610fa46:
			case xe189190bd5894d4f.x2ec8395d97ae50dc:
				return Cursors.SizeNESW;
			case xe189190bd5894d4f.x419ba17a5322627b:
			case xe189190bd5894d4f.x72d92bd1aff02e37:
				return Cursors.SizeWE;
			}
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0003B444 File Offset: 0x00039844
		private xe189190bd5894d4f GetTitleBarResizeEdge(MouseEventArgs e)
		{
			if (this.titleBar != null && MdiPanel.GetWindowState(this) == WindowState.Normal && this.CanResizeEdge())
			{
				double num = Math.Min(this.titleBar.ActualWidth / 3.0, 15.0);
				double resizeFrameHorizontalBorderHeight = SystemParameters.ResizeFrameHorizontalBorderHeight;
				Point position = e.GetPosition(this.titleBar);
				Rect rect = new Rect(0.0, 0.0, this.titleBar.ActualWidth, this.titleBar.ActualHeight);
				Rect rect2 = rect;
				rect2.Inflate(-resizeFrameHorizontalBorderHeight, -resizeFrameHorizontalBorderHeight);
				if (rect.Contains(position) && !rect2.Contains(position))
				{
					if (position.X <= resizeFrameHorizontalBorderHeight)
					{
						return xe189190bd5894d4f.xc3ae914e60da748f;
					}
					if (position.X >= rect.Right - resizeFrameHorizontalBorderHeight)
					{
						return xe189190bd5894d4f.x46c964a11610fa46;
					}
					if (position.Y <= resizeFrameHorizontalBorderHeight)
					{
						if (position.X <= num)
						{
							return xe189190bd5894d4f.xc3ae914e60da748f;
						}
						if (position.X >= rect.Right - num)
						{
							return xe189190bd5894d4f.x46c964a11610fa46;
						}
						return xe189190bd5894d4f.xe360b1885d8d4a41;
					}
				}
			}
			return xe189190bd5894d4f.x4d0b9d4447ba7566;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0003B548 File Offset: 0x00039948
		private xe189190bd5894d4f GetMainBorderResizeEdge(MouseEventArgs e)
		{
			if (this.mainBorder != null && MdiPanel.GetWindowState(this) == WindowState.Normal && this.CanResizeEdge())
			{
				double num = Math.Min(this.mainBorder.ActualHeight / 3.0, 15.0);
				double num2 = Math.Min(this.mainBorder.ActualWidth / 3.0, 15.0);
				double resizeFrameHorizontalBorderHeight = SystemParameters.ResizeFrameHorizontalBorderHeight;
				Point position = e.GetPosition(this.mainBorder);
				Rect rect = new Rect(0.0, 0.0, this.mainBorder.ActualWidth, this.mainBorder.ActualHeight);
				Rect rect2 = rect;
				rect2.Inflate(-resizeFrameHorizontalBorderHeight, -resizeFrameHorizontalBorderHeight);
				if (rect.Contains(position) && !rect2.Contains(position))
				{
					if (position.Y >= rect.Height - resizeFrameHorizontalBorderHeight)
					{
						if (position.X >= rect.Width - num2)
						{
							return xe189190bd5894d4f.xbedfa137d9910ba4;
						}
						if (position.X <= num2)
						{
							return xe189190bd5894d4f.x2ec8395d97ae50dc;
						}
						return xe189190bd5894d4f.x9bcb07e204e30218;
					}
					else if (position.X <= resizeFrameHorizontalBorderHeight)
					{
						if (position.Y >= rect.Height - num)
						{
							return xe189190bd5894d4f.x2ec8395d97ae50dc;
						}
						return xe189190bd5894d4f.x72d92bd1aff02e37;
					}
					else if (position.X >= rect.Width - resizeFrameHorizontalBorderHeight)
					{
						if (position.Y >= rect.Height - num)
						{
							return xe189190bd5894d4f.xbedfa137d9910ba4;
						}
						return xe189190bd5894d4f.x419ba17a5322627b;
					}
				}
			}
			return xe189190bd5894d4f.x4d0b9d4447ba7566;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0003B6AC File Offset: 0x00039AAC
		private void OnTitleBarMouseMove(object sender, MouseEventArgs e)
		{
			if (this.resizeData != null)
			{
				this.HandleResizeMouseMove(this.PointToParent(e.GetPosition(this)));
				e.Handled = true;
				return;
			}
			Cursor cursor = this.CursorFromResizeEdge(this.GetTitleBarResizeEdge(e));
			if (cursor == Cursors.Arrow)
			{
				this.titleBar.ClearValue(FrameworkElement.CursorProperty);
			}
			else
			{
				this.titleBar.Cursor = cursor;
			}
			if (this.draggingTitleBar)
			{
				Point point = this.PointToParent(e.GetPosition(this));
				Vector vector = point - this.dragStartPoint;
				if (MdiPanel.GetWindowState(this) == WindowState.Normal)
				{
					MdiPanel.SetNormalPosition(this, MdiPanel.GetNormalPosition(this) + vector);
				}
				else
				{
					MdiPanel.SetMinimizedPosition(this, MdiPanel.GetMinimizedPosition(this) + vector);
				}
				this.dragStartPoint = point;
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0003B768 File Offset: 0x00039B68
		private void OnTitleBarMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 2 && this.CanMaximize)
			{
				this.OnMaximizeButtonClick(null, null);
				e.Handled = true;
				return;
			}
			xe189190bd5894d4f titleBarResizeEdge = this.GetTitleBarResizeEdge(e);
			if (titleBarResizeEdge != xe189190bd5894d4f.x4d0b9d4447ba7566 && this.DragResize(titleBarResizeEdge))
			{
				e.Handled = true;
				return;
			}
			if (this.EnableMove && !this.draggingTitleBar && MdiPanel.GetWindowState(this) != WindowState.Maximized)
			{
				e.Handled = true;
				Rect layoutSlot = LayoutInformation.GetLayoutSlot(this);
				if (MdiPanel.GetWindowState(this) == WindowState.Normal)
				{
					MdiPanel.SetNormalPosition(this, layoutSlot.TopLeft);
				}
				else if (MdiPanel.GetWindowState(this) == WindowState.Minimized)
				{
					MdiPanel.SetMinimizedPosition(this, new Point(layoutSlot.X, layoutSlot.Y));
				}
				this.titleBar.CaptureMouse();
				this.draggingTitleBar = true;
				this.dragStartPoint = this.PointToParent(e.GetPosition(this));
			}
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0003B840 File Offset: 0x00039C40
		private bool DragResize(xe189190bd5894d4f resizeEdge)
		{
			if (resizeEdge == xe189190bd5894d4f.x4d0b9d4447ba7566)
			{
				throw new ArgumentException("resizeEdge");
			}
			if (Mouse.LeftButton != MouseButtonState.Pressed)
			{
				throw new InvalidOperationException();
			}
			if (this.resizeData != null)
			{
				throw new InvalidOperationException();
			}
			switch (resizeEdge)
			{
			case xe189190bd5894d4f.xc3ae914e60da748f:
			case xe189190bd5894d4f.xe360b1885d8d4a41:
			case xe189190bd5894d4f.x46c964a11610fa46:
				if (this.titleBar == null || !this.titleBar.CaptureMouse())
				{
					return false;
				}
				break;
			default:
				if (this.mainBorder == null || !this.mainBorder.CaptureMouse())
				{
					return false;
				}
				break;
			}
			this.resizeData = new MdiWindowContainer.xb03ec0ad616d13fe();
			this.resizeData.x1393f03d25c9c249 = this.PointToParent(Mouse.GetPosition(this));
			this.resizeData.xe189190bd5894d4f = resizeEdge;
			this.resizeData.x80327296a66a3f80 = MdiPanel.GetRestoredSize(this);
			this.resizeData.x91ac1d10bec44e67 = MdiPanel.GetNormalPosition(this);
			return true;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0003B910 File Offset: 0x00039D10
		private void HandleResizeMouseMove(Point position)
		{
			Vector vector = position - this.resizeData.x1393f03d25c9c249;
			Point normalPosition;
			Size value;
			if (!false)
			{
				normalPosition = MdiPanel.GetNormalPosition(this);
				switch (this.resizeData.xe189190bd5894d4f)
				{
				case xe189190bd5894d4f.xc3ae914e60da748f:
					value = new Size(Math.Max(this.resizeData.x80327296a66a3f80.Width - vector.X, 100.0), Math.Max(this.resizeData.x80327296a66a3f80.Height - vector.Y, 0.0));
					normalPosition = new Point(Math.Min(this.resizeData.x91ac1d10bec44e67.X + vector.X, this.resizeData.x91ac1d10bec44e67.X + this.resizeData.x80327296a66a3f80.Width - 100.0), Math.Min(this.resizeData.x91ac1d10bec44e67.Y + vector.Y, this.resizeData.x91ac1d10bec44e67.Y + this.resizeData.x80327296a66a3f80.Height - 0.0));
					break;
				case xe189190bd5894d4f.xe360b1885d8d4a41:
					value = new Size(this.resizeData.x80327296a66a3f80.Width, Math.Max(this.resizeData.x80327296a66a3f80.Height - vector.Y, 0.0));
					normalPosition = new Point(this.resizeData.x91ac1d10bec44e67.X, Math.Min(this.resizeData.x91ac1d10bec44e67.Y + vector.Y, this.resizeData.x91ac1d10bec44e67.Y + this.resizeData.x80327296a66a3f80.Height));
					break;
				case xe189190bd5894d4f.x46c964a11610fa46:
					value = new Size(Math.Max(this.resizeData.x80327296a66a3f80.Width + vector.X, 100.0), Math.Max(this.resizeData.x80327296a66a3f80.Height - vector.Y, 0.0));
					normalPosition = new Point(this.resizeData.x91ac1d10bec44e67.X, Math.Min(this.resizeData.x91ac1d10bec44e67.Y + vector.Y, this.resizeData.x91ac1d10bec44e67.Y + this.resizeData.x80327296a66a3f80.Height - 0.0));
					break;
				default:
					value = new Size(Math.Max(this.resizeData.x80327296a66a3f80.Width + vector.X, 100.0), this.resizeData.x80327296a66a3f80.Height);
					break;
				case xe189190bd5894d4f.xbedfa137d9910ba4:
					value = new Size(Math.Max(this.resizeData.x80327296a66a3f80.Width + vector.X, 100.0), Math.Max(this.resizeData.x80327296a66a3f80.Height + vector.Y, 0.0));
					break;
				case xe189190bd5894d4f.x9bcb07e204e30218:
					value = new Size(this.resizeData.x80327296a66a3f80.Width, Math.Max(this.resizeData.x80327296a66a3f80.Height + vector.Y, 0.0));
					break;
				case xe189190bd5894d4f.x2ec8395d97ae50dc:
					value = new Size(Math.Max(this.resizeData.x80327296a66a3f80.Width - vector.X, 100.0), Math.Max(this.resizeData.x80327296a66a3f80.Height + vector.Y, 0.0));
					normalPosition = new Point(Math.Min(this.resizeData.x91ac1d10bec44e67.X + vector.X, this.resizeData.x91ac1d10bec44e67.X + this.resizeData.x80327296a66a3f80.Width - 100.0), this.resizeData.x91ac1d10bec44e67.Y);
					break;
				case xe189190bd5894d4f.x72d92bd1aff02e37:
					value = new Size(Math.Max(this.resizeData.x80327296a66a3f80.Width - vector.X, 100.0), this.resizeData.x80327296a66a3f80.Height);
					normalPosition = new Point(Math.Min(this.resizeData.x91ac1d10bec44e67.X + vector.X, this.resizeData.x91ac1d10bec44e67.X + this.resizeData.x80327296a66a3f80.Width - 100.0), this.resizeData.x91ac1d10bec44e67.Y);
					break;
				}
			}
			MdiPanel.SetRestoredSize(this, value);
			if (normalPosition != MdiPanel.GetNormalPosition(this))
			{
				MdiPanel.SetNormalPosition(this, normalPosition);
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0003BE04 File Offset: 0x0003A204
		private void OnTitleBarMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (this.resizeData != null)
			{
				this.CancelResize();
			}
			if (this.draggingTitleBar)
			{
				this.CancelDrag();
			}
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0003BE24 File Offset: 0x0003A224
		private void OnTitleBarLostMouseCapture(object sender, MouseEventArgs e)
		{
			if (this.resizeData != null)
			{
				this.CancelResize();
			}
			this.CancelDrag();
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0003BE3C File Offset: 0x0003A23C
		private void OnMainBorderLostMouseCapture(object sender, MouseEventArgs e)
		{
			if (this.resizeData != null)
			{
				this.CancelResize();
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0003BE4C File Offset: 0x0003A24C
		private void OnMainBorderMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (this.resizeData != null)
			{
				this.CancelResize();
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0003BE5C File Offset: 0x0003A25C
		private void OnMainBorderMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			xe189190bd5894d4f mainBorderResizeEdge = this.GetMainBorderResizeEdge(e);
			if (mainBorderResizeEdge != xe189190bd5894d4f.x4d0b9d4447ba7566 && this.DragResize(mainBorderResizeEdge))
			{
				e.Handled = true;
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0003BE84 File Offset: 0x0003A284
		private void CancelResize()
		{
			if (this.resizeData != null)
			{
				if (this.titleBar != null && this.titleBar.IsMouseCaptured)
				{
					this.titleBar.ReleaseMouseCapture();
				}
				else if (this.mainBorder != null && this.mainBorder.IsMouseCaptured)
				{
					this.mainBorder.ReleaseMouseCapture();
				}
				this.resizeData = null;
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0003BEE4 File Offset: 0x0003A2E4
		private void CancelDrag()
		{
			if (this.draggingTitleBar)
			{
				if (this.titleBar.IsMouseCaptured)
				{
					this.titleBar.ReleaseMouseCapture();
				}
				this.draggingTitleBar = false;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0003BF10 File Offset: 0x0003A310
		public void ToggleMaximized()
		{
			if (MdiPanel.GetWindowState(this) == WindowState.Maximized)
			{
				MdiPanel.SetWindowState(this, WindowState.Normal);
				return;
			}
			MdiPanel.SetWindowState(this, WindowState.Maximized);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0003BF2C File Offset: 0x0003A32C
		public void ToggleMinimized()
		{
			if (MdiPanel.GetWindowState(this) == WindowState.Minimized)
			{
				MdiPanel.SetWindowState(this, WindowState.Normal);
				return;
			}
			MdiWindowContainer.EnsureMinimizedPosition(this);
			MdiPanel.SetWindowState(this, WindowState.Minimized);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0003BF4C File Offset: 0x0003A34C
		internal static void EnsureMinimizedPosition(MdiWindowContainer windowContainer)
		{
			if (DependencyPropertyHelper.GetValueSource(windowContainer, MdiPanel.MinimizedPositionProperty).BaseValueSource == BaseValueSource.Default)
			{
				Rect layoutSlot = LayoutInformation.GetLayoutSlot(windowContainer);
				Rect layoutSlot2 = new Rect(0.0, 0.0, 0.0, 0.0);
				FrameworkElement frameworkElement = windowContainer.Content as FrameworkElement;
				if (frameworkElement != null)
				{
					layoutSlot2 = LayoutInformation.GetLayoutSlot(frameworkElement);
				}
				MdiPanel.SetMinimizedPosition(windowContainer, new Point(layoutSlot.X, layoutSlot.Bottom - (layoutSlot.Height - layoutSlot2.Height)));
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0003BFE0 File Offset: 0x0003A3E0
		private Point PointToParent(Point position)
		{
			FrameworkElement frameworkElement = VisualTreeHelper.GetParent(this) as FrameworkElement;
			if (frameworkElement != null)
			{
				return base.TransformToAncestor(frameworkElement).Transform(position);
			}
			return position;
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x0003C00C File Offset: 0x0003A40C
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x0003C020 File Offset: 0x0003A420
		[Category("Appearance")]
		public bool HasDropShadow
		{
			get
			{
				return (bool)base.GetValue(MdiWindowContainer.HasDropShadowProperty);
			}
			set
			{
				base.SetValue(MdiWindowContainer.HasDropShadowProperty, value);
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x0003C034 File Offset: 0x0003A434
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x0003C048 File Offset: 0x0003A448
		[Category("Common Properties")]
		public ImageSource Icon
		{
			get
			{
				return (ImageSource)base.GetValue(MdiWindowContainer.IconProperty);
			}
			set
			{
				base.SetValue(MdiWindowContainer.IconProperty, value);
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x0003C058 File Offset: 0x0003A458
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x0003C060 File Offset: 0x0003A460
		internal bool EnableMove
		{
			get
			{
				return this.enableMove;
			}
			set
			{
				this.enableMove = value;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x0003C06C File Offset: 0x0003A46C
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x0003C080 File Offset: 0x0003A480
		public bool SetClientSize
		{
			get
			{
				return (bool)base.GetValue(MdiWindowContainer.SetClientSizeProperty);
			}
			set
			{
				base.SetValue(MdiWindowContainer.SetClientSizeProperty, value);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x0003C094 File Offset: 0x0003A494
		// (set) Token: 0x060002AA RID: 682 RVA: 0x0003C0A8 File Offset: 0x0003A4A8
		[Category("Common Properties")]
		public string Title
		{
			get
			{
				return (string)base.GetValue(MdiWindowContainer.TitleProperty);
			}
			set
			{
				base.SetValue(MdiWindowContainer.TitleProperty, value);
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0003C0B8 File Offset: 0x0003A4B8
		// (set) Token: 0x060002AC RID: 684 RVA: 0x0003C0CC File Offset: 0x0003A4CC
		[Category("Layout")]
		public bool CanMaximize
		{
			get
			{
				return (bool)base.GetValue(MdiWindowContainer.CanMaximizeProperty);
			}
			set
			{
				base.SetValue(MdiWindowContainer.CanMaximizeProperty, value);
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x060002AD RID: 685 RVA: 0x0003C0E0 File Offset: 0x0003A4E0
		// (set) Token: 0x060002AE RID: 686 RVA: 0x0003C0F4 File Offset: 0x0003A4F4
		[Category("Layout")]
		public bool CanMinimize
		{
			get
			{
				return (bool)base.GetValue(MdiWindowContainer.CanMinimizeProperty);
			}
			set
			{
				base.SetValue(MdiWindowContainer.CanMinimizeProperty, value);
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002AF RID: 687 RVA: 0x0003C108 File Offset: 0x0003A508
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x0003C11C File Offset: 0x0003A51C
		[Category("Appearance")]
		public WindowStyle WindowStyle
		{
			get
			{
				return (WindowStyle)base.GetValue(MdiWindowContainer.WindowStyleProperty);
			}
			set
			{
				base.SetValue(MdiWindowContainer.WindowStyleProperty, value);
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0003C130 File Offset: 0x0003A530
		private static bool OnValidateWindowStyle(object value)
		{
			WindowStyle windowStyle = (WindowStyle)value;
			return windowStyle == WindowStyle.ThreeDBorderWindow || windowStyle == WindowStyle.ToolWindow;
		}

		// Token: 0x040000CE RID: 206
		public static readonly DependencyProperty CanMaximizeProperty;

		// Token: 0x040000CF RID: 207
		public static readonly DependencyProperty CanMinimizeProperty;

		// Token: 0x040000D0 RID: 208
		public static readonly DependencyProperty WindowStyleProperty;

		// Token: 0x040000D1 RID: 209
		public static readonly DependencyProperty TitleProperty;

		// Token: 0x040000D2 RID: 210
		public static readonly DependencyProperty IconProperty;

		// Token: 0x040000D3 RID: 211
		public static readonly DependencyProperty HasDropShadowProperty;

		// Token: 0x040000D4 RID: 212
		public static readonly DependencyProperty SetClientSizeProperty;

		// Token: 0x040000D5 RID: 213
		private FrameworkElement titleBar;

		// Token: 0x040000D6 RID: 214
		private FrameworkElement mainBorder;

		// Token: 0x040000D7 RID: 215
		private FrameworkElement systemIcon;

		// Token: 0x040000D8 RID: 216
		private ButtonBase templateMinimizeButton;

		// Token: 0x040000D9 RID: 217
		private ButtonBase templateMaximizeButton;

		// Token: 0x040000DA RID: 218
		private bool draggingTitleBar;

		// Token: 0x040000DB RID: 219
		private Point dragStartPoint;

		// Token: 0x040000DC RID: 220
		private MdiWindowContainer.xb03ec0ad616d13fe resizeData;

		// Token: 0x040000DD RID: 221
		private bool enableMove = true;

		// Token: 0x040000DE RID: 222
		private CancelEventHandler Closing;

		// Token: 0x040000DF RID: 223
		private EventHandler Closed;

		// Token: 0x040000E0 RID: 224
		private EventHandler ShowContextMenu;

		// Token: 0x02000026 RID: 38
		private class xb03ec0ad616d13fe
		{
			// Token: 0x040000E1 RID: 225
			public xe189190bd5894d4f xe189190bd5894d4f;

			// Token: 0x040000E2 RID: 226
			public Point x1393f03d25c9c249;

			// Token: 0x040000E3 RID: 227
			public Size x80327296a66a3f80;

			// Token: 0x040000E4 RID: 228
			public Point x91ac1d10bec44e67;
		}
	}
}

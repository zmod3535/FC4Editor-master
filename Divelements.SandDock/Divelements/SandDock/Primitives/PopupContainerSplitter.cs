using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000076 RID: 118
	public class PopupContainerSplitter : Thumb
	{
		// Token: 0x060004D7 RID: 1239 RVA: 0x0004857C File Offset: 0x0004697C
		static PopupContainerSplitter()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(PopupContainerSplitter), new FrameworkPropertyMetadata(typeof(PopupContainerSplitter)));
			EventManager.RegisterClassHandler(typeof(PopupContainerSplitter), Thumb.DragStartedEvent, new DragStartedEventHandler(PopupContainerSplitter.OnDragStarted));
			EventManager.RegisterClassHandler(typeof(PopupContainerSplitter), Thumb.DragDeltaEvent, new DragDeltaEventHandler(PopupContainerSplitter.OnDragDelta));
			EventManager.RegisterClassHandler(typeof(PopupContainerSplitter), Thumb.DragCompletedEvent, new DragCompletedEventHandler(PopupContainerSplitter.OnDragCompleted));
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00048614 File Offset: 0x00046A14
		private static void OnDragStarted(object sender, DragStartedEventArgs e)
		{
			(sender as PopupContainerSplitter).OnDragStarted(e);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00048624 File Offset: 0x00046A24
		private static void OnDragDelta(object sender, DragDeltaEventArgs e)
		{
			(sender as PopupContainerSplitter).OnDragDelta(e);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00048634 File Offset: 0x00046A34
		private static void OnDragCompleted(object sender, DragCompletedEventArgs e)
		{
			(sender as PopupContainerSplitter).OnDragCompleted(e);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00048644 File Offset: 0x00046A44
		private void OnDragCompleted(DragCompletedEventArgs e)
		{
			if (this.resizeData != null)
			{
				if (!e.Canceled)
				{
					if (this.resizeData.x0c6349882676bcd6 == Dock.Right)
					{
						this.resizeData.xb424e41094667807.ContentSize -= this.resizeData.xb4186eb3ba442529.OffsetX;
					}
					else if (this.resizeData.x0c6349882676bcd6 == Dock.Left)
					{
						this.resizeData.xb424e41094667807.ContentSize += this.resizeData.xb4186eb3ba442529.OffsetX;
					}
					else if (this.resizeData.x0c6349882676bcd6 == Dock.Top)
					{
						this.resizeData.xb424e41094667807.ContentSize += this.resizeData.xb4186eb3ba442529.OffsetY;
					}
					else if (this.resizeData.x0c6349882676bcd6 == Dock.Bottom)
					{
						this.resizeData.xb424e41094667807.ContentSize -= this.resizeData.xb4186eb3ba442529.OffsetY;
					}
				}
				(VisualTreeHelper.GetParent(this.resizeData.xb4186eb3ba442529) as AdornerLayer).Remove(this.resizeData.xb4186eb3ba442529);
				this.resizeData = null;
			}
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00048770 File Offset: 0x00046B70
		private void OnDragDelta(DragDeltaEventArgs e)
		{
			if (this.resizeData != null)
			{
				double horizontalChange = e.HorizontalChange;
				double verticalChange = e.VerticalChange;
				if (this.resizeData.x0c6349882676bcd6 == Dock.Right || this.resizeData.x0c6349882676bcd6 == Dock.Left)
				{
					this.resizeData.xb4186eb3ba442529.OffsetX = Math.Max(Math.Min(horizontalChange, this.resizeData.xbf668cc6cab48980), this.resizeData.x65922b505b5cb658);
					return;
				}
				this.resizeData.xb4186eb3ba442529.OffsetY = Math.Max(Math.Min(verticalChange, this.resizeData.xbf668cc6cab48980), this.resizeData.x65922b505b5cb658);
			}
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00048814 File Offset: 0x00046C14
		private PopupContainer FindPopupContainer()
		{
			for (FrameworkElement frameworkElement = base.Parent as FrameworkElement; frameworkElement != null; frameworkElement = (VisualTreeHelper.GetParent(frameworkElement) as FrameworkElement))
			{
				PopupContainer popupContainer = frameworkElement as PopupContainer;
				if (popupContainer != null)
				{
					return popupContainer;
				}
			}
			return null;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x0004884C File Offset: 0x00046C4C
		private void OnDragStarted(DragStartedEventArgs e)
		{
			PopupContainer popupContainer = this.FindPopupContainer();
			for (;;)
			{
				AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(popupContainer);
				if (popupContainer != null && popupContainer.WindowGroup != null && popupContainer.WindowGroup.SelectedWindow != null && adornerLayer != null)
				{
					Rect layoutSlot;
					for (;;)
					{
						this.resizeData = new PopupContainerSplitter.xb03ec0ad616d13fe();
						this.resizeData.xb424e41094667807 = popupContainer.WindowGroup.SelectedWindow;
						this.resizeData.x0c6349882676bcd6 = DockPanel.GetDock(popupContainer);
						layoutSlot = LayoutInformation.GetLayoutSlot(popupContainer);
						switch (this.resizeData.x0c6349882676bcd6)
						{
						case Dock.Left:
							goto IL_7E;
						case Dock.Top:
							this.resizeData.x65922b505b5cb658 = 20.0 - this.resizeData.xb424e41094667807.ContentSize;
							if (-2 != 0)
							{
								goto Block_2;
							}
							continue;
						case Dock.Right:
							goto IL_27;
						case Dock.Bottom:
							goto IL_14B;
						}
						break;
					}
					IL_19D:
					this.resizeData.xb4186eb3ba442529 = new SplitPreviewAdorner(this, null);
					adornerLayer.Add(this.resizeData.xb4186eb3ba442529);
					if (-2 == 0)
					{
						continue;
					}
					break;
					goto IL_19D;
					IL_27:
					this.resizeData.xbf668cc6cab48980 = this.resizeData.xb424e41094667807.ContentSize - 28.0;
					this.resizeData.x65922b505b5cb658 = 28.0 + this.resizeData.xb424e41094667807.ContentSize - layoutSlot.Right;
					goto IL_19D;
					IL_7E:
					this.resizeData.x65922b505b5cb658 = 28.0 - this.resizeData.xb424e41094667807.ContentSize;
					this.resizeData.xbf668cc6cab48980 = popupContainer.Parent.ActualWidth - layoutSlot.Left - this.resizeData.xb424e41094667807.ContentSize - 28.0;
					goto IL_19D;
					Block_2:
					this.resizeData.xbf668cc6cab48980 = popupContainer.Parent.ActualHeight - layoutSlot.Top - this.resizeData.xb424e41094667807.ContentSize - 20.0;
					goto IL_19D;
					IL_14B:
					this.resizeData.xbf668cc6cab48980 = this.resizeData.xb424e41094667807.ContentSize - 20.0;
					this.resizeData.x65922b505b5cb658 = 20.0 + this.resizeData.xb424e41094667807.ContentSize - layoutSlot.Bottom;
					goto IL_19D;
				}
				break;
			}
		}

		// Token: 0x04000293 RID: 659
		private PopupContainerSplitter.xb03ec0ad616d13fe resizeData;

		// Token: 0x02000077 RID: 119
		private class xb03ec0ad616d13fe
		{
			// Token: 0x04000294 RID: 660
			public Dock x0c6349882676bcd6;

			// Token: 0x04000295 RID: 661
			public DockableWindow xb424e41094667807;

			// Token: 0x04000296 RID: 662
			public SplitPreviewAdorner xb4186eb3ba442529;

			// Token: 0x04000297 RID: 663
			public double xbf668cc6cab48980;

			// Token: 0x04000298 RID: 664
			public double x65922b505b5cb658;
		}
	}
}

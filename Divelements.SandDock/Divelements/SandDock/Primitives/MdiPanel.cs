using System;
using System.Windows;
using System.Windows.Controls;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000028 RID: 40
	public class MdiPanel : Panel
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x0003C158 File Offset: 0x0003A558
		static MdiPanel()
		{
			MdiPanel.MinimizedPositionProperty = DependencyProperty.RegisterAttached("MinimizedPosition", typeof(Point), typeof(MdiPanel), new FrameworkPropertyMetadata(new Point(0.0, 0.0), FrameworkPropertyMetadataOptions.AffectsParentArrange));
			MdiPanel.ResizeModeProperty = DependencyProperty.RegisterAttached("ResizeMode", typeof(ResizeMode), typeof(MdiPanel), new FrameworkPropertyMetadata(ResizeMode.CanResize));
			MdiPanel.RestoredSizeProperty = DependencyProperty.RegisterAttached("RestoredSize", typeof(Size), typeof(MdiPanel), new FrameworkPropertyMetadata(new Size(400.0, 300.0)));
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0003C298 File Offset: 0x0003A698
		public void BringToFront(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			int num = 0;
			foreach (object obj in base.Children)
			{
				UIElement element2 = (UIElement)obj;
				num = Math.Max(num, Panel.GetZIndex(element2));
			}
			Panel.SetZIndex(element, num + 1);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0003C31C File Offset: 0x0003A71C
		protected override Size ArrangeOverride(Size finalSize)
		{
			foreach (object obj in base.Children)
			{
				UIElement uielement = (UIElement)obj;
				Rect finalRect;
				if (MdiPanel.GetWindowState(uielement) == WindowState.Maximized)
				{
					finalRect = new Rect(0.0, 0.0, finalSize.Width, finalSize.Height);
				}
				else if (MdiPanel.GetWindowState(uielement) == WindowState.Minimized)
				{
					finalRect = new Rect(MdiPanel.GetMinimizedPosition(uielement), uielement.DesiredSize);
				}
				else
				{
					finalRect = new Rect(MdiPanel.GetNormalPosition(uielement), uielement.DesiredSize);
				}
				if (finalRect.X != -100000.0)
				{
					if (finalRect.Right < 10.0)
					{
						finalRect.X = 10.0 - finalRect.Width;
					}
					if (finalRect.Y < 0.0)
					{
						finalRect.Y = 0.0;
					}
					if (finalRect.X > finalSize.Width - 10.0)
					{
						finalRect.X = finalSize.Width - 10.0;
					}
					if (finalRect.Y > finalSize.Height - 10.0)
					{
						finalRect.Y = finalSize.Height - 10.0;
					}
				}
				uielement.Arrange(finalRect);
			}
			return finalSize;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0003C4B0 File Offset: 0x0003A8B0
		protected override Size MeasureOverride(Size availableSize)
		{
			foreach (object obj in base.Children)
			{
				UIElement uielement = (UIElement)obj;
				switch (MdiPanel.GetWindowState(uielement))
				{
				case WindowState.Normal:
					uielement.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
					break;
				case WindowState.Minimized:
					uielement.Measure(availableSize);
					break;
				case WindowState.Maximized:
					uielement.Measure(availableSize);
					break;
				}
			}
			return default(Size);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0003C564 File Offset: 0x0003A964
		public static WindowState GetWindowState(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (WindowState)element.GetValue(MdiPanel.WindowStateProperty);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0003C584 File Offset: 0x0003A984
		public static void SetWindowState(UIElement element, WindowState value)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.SetValue(MdiPanel.WindowStateProperty, value);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0003C5A8 File Offset: 0x0003A9A8
		public static ResizeMode GetResizeMode(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (ResizeMode)element.GetValue(MdiPanel.ResizeModeProperty);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0003C5C8 File Offset: 0x0003A9C8
		public static void SetResizeMode(UIElement element, ResizeMode value)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.SetValue(MdiPanel.ResizeModeProperty, value);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0003C5EC File Offset: 0x0003A9EC
		public static Point GetMinimizedPosition(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (Point)element.GetValue(MdiPanel.MinimizedPositionProperty);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0003C60C File Offset: 0x0003AA0C
		public static void SetMinimizedPosition(UIElement element, Point value)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.SetValue(MdiPanel.MinimizedPositionProperty, value);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0003C630 File Offset: 0x0003AA30
		public static Point GetNormalPosition(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (Point)element.GetValue(MdiPanel.NormalPositionProperty);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0003C650 File Offset: 0x0003AA50
		public static void SetNormalPosition(UIElement element, Point value)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.SetValue(MdiPanel.NormalPositionProperty, value);
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0003C674 File Offset: 0x0003AA74
		public static Size GetRestoredSize(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (Size)element.GetValue(MdiPanel.RestoredSizeProperty);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0003C694 File Offset: 0x0003AA94
		public static void SetRestoredSize(UIElement element, Size value)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.SetValue(MdiPanel.RestoredSizeProperty, value);
		}

		// Token: 0x040000EF RID: 239
		public static readonly DependencyProperty NormalPositionProperty = DependencyProperty.RegisterAttached("NormalPosition", typeof(Point), typeof(MdiPanel), new FrameworkPropertyMetadata(new Point(0.0, 0.0), FrameworkPropertyMetadataOptions.AffectsParentArrange));

		// Token: 0x040000F0 RID: 240
		public static readonly DependencyProperty MinimizedPositionProperty;

		// Token: 0x040000F1 RID: 241
		public static readonly DependencyProperty WindowStateProperty = DependencyProperty.RegisterAttached("WindowState", typeof(WindowState), typeof(MdiPanel), new FrameworkPropertyMetadata(WindowState.Normal, FrameworkPropertyMetadataOptions.AffectsParentArrange));

		// Token: 0x040000F2 RID: 242
		public static readonly DependencyProperty ResizeModeProperty;

		// Token: 0x040000F3 RID: 243
		public static readonly DependencyProperty RestoredSizeProperty;
	}
}

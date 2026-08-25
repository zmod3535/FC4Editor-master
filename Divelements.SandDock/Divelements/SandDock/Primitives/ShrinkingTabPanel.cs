using System;
using System.Windows;
using System.Windows.Controls;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x0200004D RID: 77
	public class ShrinkingTabPanel : Panel
	{
		// Token: 0x060003E4 RID: 996 RVA: 0x000422C4 File Offset: 0x000406C4
		protected override Size MeasureOverride(Size availableSize)
		{
			if (this.Orientation == Orientation.Horizontal && double.IsInfinity(availableSize.Width))
			{
				return new Size(0.0, 0.0);
			}
			if (this.Orientation == Orientation.Vertical && double.IsInfinity(availableSize.Height))
			{
				return new Size(0.0, 0.0);
			}
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 0;
			foreach (object obj in base.Children)
			{
				WindowTab tab = (WindowTab)obj;
				num3 += Math.Max(this.GetWindowTabText(tab).Length, 1);
			}
			foreach (object obj2 in base.InternalChildren)
			{
				WindowTab windowTab = (WindowTab)obj2;
				if (this.Orientation == Orientation.Horizontal)
				{
					windowTab.Measure(new Size((double)Math.Max(this.GetWindowTabText(windowTab).Length, 1) / (double)num3 * availableSize.Width, availableSize.Height));
					num += windowTab.DesiredSize.Width;
					num2 = Math.Max(num2, windowTab.DesiredSize.Height);
				}
				else
				{
					windowTab.Measure(new Size(availableSize.Width, (double)Math.Max(this.GetWindowTabText(windowTab).Length, 1) / (double)num3 * availableSize.Height));
					num += windowTab.DesiredSize.Height;
					num2 = Math.Max(num2, windowTab.DesiredSize.Width);
				}
			}
			if (this.Orientation == Orientation.Horizontal)
			{
				return new Size(num, num2);
			}
			return new Size(num2, num);
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x000424E8 File Offset: 0x000408E8
		protected override Size ArrangeOverride(Size finalSize)
		{
			double num = 0.0;
			foreach (object obj in base.InternalChildren)
			{
				UIElement uielement = (UIElement)obj;
				double num2;
				if (this.Orientation == Orientation.Horizontal)
				{
					num2 = uielement.DesiredSize.Width;
					uielement.Arrange(new Rect(num, 0.0, num2, finalSize.Height));
				}
				else
				{
					num2 = uielement.DesiredSize.Height;
					uielement.Arrange(new Rect(0.0, num, finalSize.Width, num2));
				}
				num += num2;
			}
			return new Size(finalSize.Width, finalSize.Height);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x000425D4 File Offset: 0x000409D4
		private string GetWindowTabText(WindowTab tab)
		{
			if (tab.Window != null)
			{
				return tab.Window.TabText;
			}
			return string.Empty;
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x000425F0 File Offset: 0x000409F0
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x00042604 File Offset: 0x00040A04
		public Orientation Orientation
		{
			get
			{
				return (Orientation)base.GetValue(ShrinkingTabPanel.OrientationProperty);
			}
			set
			{
				base.SetValue(ShrinkingTabPanel.OrientationProperty, value);
			}
		}

		// Token: 0x040001A7 RID: 423
		public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(ShrinkingTabPanel), new FrameworkPropertyMetadata(Orientation.Horizontal, FrameworkPropertyMetadataOptions.AffectsMeasure));
	}
}

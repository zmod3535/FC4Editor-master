using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x0200000F RID: 15
	public class WindowList : ItemsControl
	{
		// Token: 0x06000143 RID: 323 RVA: 0x000355F0 File Offset: 0x000339F0
		protected override bool IsItemItsOwnContainerOverride(object item)
		{
			return item is WindowTab;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000355FC File Offset: 0x000339FC
		protected override DependencyObject GetContainerForItemOverride()
		{
			return new WindowTab();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00035604 File Offset: 0x00033A04
		protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
		{
			WindowTab windowTab = (WindowTab)element;
			DockableWindow window = (DockableWindow)item;
			windowTab.Window = window;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00035628 File Offset: 0x00033A28
		protected override void ClearContainerForItemOverride(DependencyObject element, object item)
		{
			WindowTab windowTab = (WindowTab)element;
			windowTab.Window = null;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00035644 File Offset: 0x00033A44
		internal int GetInsertionPoint(MouseEventArgs e)
		{
			if (base.Items.Count != 0)
			{
				WindowTab reference = (WindowTab)base.ItemContainerGenerator.ContainerFromIndex(0);
				Panel panel = VisualTreeHelper.GetParent(reference) as Panel;
				if (panel != null)
				{
					Orientation orientation = Orientation.Horizontal;
					if (panel is StackPanel)
					{
						orientation = ((StackPanel)panel).Orientation;
					}
					else if (panel is ShrinkingTabPanel)
					{
						orientation = ((ShrinkingTabPanel)panel).Orientation;
					}
					Point position = e.GetPosition(panel);
					if (new Rect(0.0, 0.0, panel.RenderSize.Width, panel.RenderSize.Height).Contains(position))
					{
						int i;
						if ((uint)i - (uint)i >= 0U)
						{
							for (i = 0; i < panel.Children.Count; i++)
							{
								Rect layoutSlot = LayoutInformation.GetLayoutSlot((FrameworkElement)panel.Children[i]);
								if (orientation == Orientation.Horizontal)
								{
									if (position.X >= layoutSlot.Left && position.X < layoutSlot.Left + layoutSlot.Width / 2.0)
									{
										return i;
									}
									if (position.X >= layoutSlot.Left + layoutSlot.Width / 2.0 && position.X < layoutSlot.Right)
									{
										goto IL_A0;
									}
								}
								else
								{
									if (position.Y >= layoutSlot.Top && position.Y < layoutSlot.Top + layoutSlot.Height / 2.0)
									{
										return i;
									}
									if (position.Y >= layoutSlot.Top + layoutSlot.Height / 2.0 && position.Y < layoutSlot.Bottom)
									{
										return i + 1;
									}
								}
							}
							return -1;
						}
						IL_A0:
						return i + 1;
					}
				}
			}
			return -1;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000148 RID: 328 RVA: 0x0003583C File Offset: 0x00033C3C
		// (set) Token: 0x06000149 RID: 329 RVA: 0x00035850 File Offset: 0x00033C50
		public Orientation Orientation
		{
			get
			{
				return (Orientation)base.GetValue(WindowList.OrientationProperty);
			}
			set
			{
				base.SetValue(WindowList.OrientationProperty, value);
			}
		}

		// Token: 0x0400005C RID: 92
		public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation", typeof(Orientation), typeof(WindowList), new FrameworkPropertyMetadata(Orientation.Horizontal));
	}
}

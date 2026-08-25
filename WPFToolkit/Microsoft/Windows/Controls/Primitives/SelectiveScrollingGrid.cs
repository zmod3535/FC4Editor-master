using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Microsoft.Windows.Controls.Primitives
{
	// Token: 0x0200005A RID: 90
	public class SelectiveScrollingGrid : Grid
	{
		// Token: 0x06000714 RID: 1812 RVA: 0x0001DE85 File Offset: 0x0001C085
		public static SelectiveScrollingOrientation GetSelectiveScrollingOrientation(DependencyObject obj)
		{
			return (SelectiveScrollingOrientation)obj.GetValue(SelectiveScrollingGrid.SelectiveScrollingOrientationProperty);
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0001DE97 File Offset: 0x0001C097
		public static void SetSelectiveScrollingOrientation(DependencyObject obj, SelectiveScrollingOrientation value)
		{
			obj.SetValue(SelectiveScrollingGrid.SelectiveScrollingOrientationProperty, value);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0001DEAC File Offset: 0x0001C0AC
		private static void OnSelectiveScrollingOrientationChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			UIElement uielement = d as UIElement;
			SelectiveScrollingOrientation selectiveScrollingOrientation = (SelectiveScrollingOrientation)e.NewValue;
			ScrollViewer scrollViewer = DataGridHelper.FindVisualParent<ScrollViewer>(uielement);
			if (scrollViewer != null && uielement != null)
			{
				Transform renderTransform = uielement.RenderTransform;
				if (renderTransform != null)
				{
					BindingOperations.ClearBinding(renderTransform, TranslateTransform.XProperty);
					BindingOperations.ClearBinding(renderTransform, TranslateTransform.YProperty);
				}
				if (selectiveScrollingOrientation == SelectiveScrollingOrientation.Both)
				{
					uielement.RenderTransform = null;
					return;
				}
				TranslateTransform translateTransform = new TranslateTransform();
				if (selectiveScrollingOrientation != SelectiveScrollingOrientation.Horizontal)
				{
					Binding binding = new Binding("ContentHorizontalOffset");
					binding.Source = scrollViewer;
					BindingOperations.SetBinding(translateTransform, TranslateTransform.XProperty, binding);
				}
				if (selectiveScrollingOrientation != SelectiveScrollingOrientation.Vertical)
				{
					Binding binding2 = new Binding("ContentVerticalOffset");
					binding2.Source = scrollViewer;
					BindingOperations.SetBinding(translateTransform, TranslateTransform.YProperty, binding2);
				}
				uielement.RenderTransform = translateTransform;
			}
		}

		// Token: 0x0400020E RID: 526
		public static readonly DependencyProperty SelectiveScrollingOrientationProperty = DependencyProperty.RegisterAttached("SelectiveScrollingOrientation", typeof(SelectiveScrollingOrientation), typeof(SelectiveScrollingGrid), new FrameworkPropertyMetadata(SelectiveScrollingOrientation.Both, new PropertyChangedCallback(SelectiveScrollingGrid.OnSelectiveScrollingOrientationChanged)));
	}
}

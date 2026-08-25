using System;
using System.Windows;
using System.Windows.Media;

namespace IGE.Helpers
{
	// Token: 0x0200006A RID: 106
	public static class DependencyObjectExtensions
	{
		// Token: 0x0600047F RID: 1151 RVA: 0x00011AB4 File Offset: 0x0000FCB4
		public static T GetVisualParent<T>(this DependencyObject child) where T : Visual
		{
			while (child != null && !(child is T))
			{
				child = VisualTreeHelper.GetParent(child);
			}
			return child as T;
		}
	}
}

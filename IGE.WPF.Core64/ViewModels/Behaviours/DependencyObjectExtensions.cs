using System;
using System.Windows;
using System.Windows.Media;

namespace IGE.ViewModels.Behaviours
{
	// Token: 0x02000394 RID: 916
	public static class DependencyObjectExtensions
	{
		// Token: 0x06001499 RID: 5273 RVA: 0x0002BCF7 File Offset: 0x00029EF7
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

using System;
using System.Windows;
using System.Windows.Controls;

namespace IGE.ViewModels.Behaviours
{
	// Token: 0x020000AB RID: 171
	public static class ListViewEnsureVisible
	{
		// Token: 0x060006E7 RID: 1767 RVA: 0x000192AA File Offset: 0x000174AA
		public static bool GetIsBroughtIntoViewWhenSelected(ListViewItem listViewItem)
		{
			return (bool)listViewItem.GetValue(ListViewEnsureVisible.IsBroughtIntoViewWhenSelectedProperty);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x000192BC File Offset: 0x000174BC
		public static void SetIsBroughtIntoViewWhenSelected(ListViewItem listViewItem, bool value)
		{
			listViewItem.SetValue(ListViewEnsureVisible.IsBroughtIntoViewWhenSelectedProperty, value);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x000192D0 File Offset: 0x000174D0
		private static void OnIsBroughtIntoViewWhenSelectedChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
		{
			ListViewItem listViewItem = depObj as ListViewItem;
			if (listViewItem == null)
			{
				return;
			}
			if (!(e.NewValue is bool))
			{
				return;
			}
			if ((bool)e.NewValue)
			{
				listViewItem.Selected += ListViewEnsureVisible.OnListViewItemSelected;
				return;
			}
			listViewItem.Selected -= ListViewEnsureVisible.OnListViewItemSelected;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0001932C File Offset: 0x0001752C
		private static void OnListViewItemSelected(object sender, RoutedEventArgs e)
		{
			if (!object.ReferenceEquals(sender, e.OriginalSource))
			{
				return;
			}
			ListViewItem listViewItem = e.OriginalSource as ListViewItem;
			if (listViewItem != null)
			{
				listViewItem.BringIntoView();
			}
		}

		// Token: 0x040002BA RID: 698
		public static readonly DependencyProperty IsBroughtIntoViewWhenSelectedProperty = DependencyProperty.RegisterAttached("IsBroughtIntoViewWhenSelected", typeof(bool), typeof(ListViewEnsureVisible), new UIPropertyMetadata(false, new PropertyChangedCallback(ListViewEnsureVisible.OnIsBroughtIntoViewWhenSelectedChanged)));
	}
}

using System;
using System.Windows;
using System.Windows.Controls;

namespace Divelements.SandDock
{
	// Token: 0x0200002E RID: 46
	internal class WindowContextMenu : ContextMenu
	{
		// Token: 0x060002E2 RID: 738 RVA: 0x0003D104 File Offset: 0x0003B504
		public WindowContextMenu(DockableWindow window)
		{
			if (!false)
			{
				this.window = window;
				MenuItem menuItem = new MenuItem();
				menuItem.Header = ((window.CloseMethod == WindowCloseMethod.Detach) ? "Close" : "Hide");
				menuItem.IsEnabled = window.AllowClose;
				menuItem.Click += this.OnCloseMenuClick;
				base.Items.Add(menuItem);
				base.Items.Add(new Separator());
				MenuItem menuItem2 = new MenuItem();
				menuItem2.Header = "Floating";
				if (!false)
				{
				}
				menuItem2.IsChecked = (window.DockSituation == DockSituation.Floating);
				menuItem2.IsEnabled = window.DockingRules.AllowFloat;
				menuItem2.Click += this.OnFloatingMenuClick;
				base.Items.Add(menuItem2);
			}
			MenuItem menuItem3 = new MenuItem();
			menuItem3.Header = "Docked";
			menuItem3.IsChecked = (window.DockSituation == DockSituation.Docked);
			menuItem3.IsEnabled = (window.DockingRules.AllowDockBottom || window.DockingRules.AllowDockLeft || window.DockingRules.AllowDockRight || window.DockingRules.AllowDockTop);
			menuItem3.Click += this.OnDockedMenuClick;
			base.Items.Add(menuItem3);
			MenuItem menuItem4 = new MenuItem();
			menuItem4.Header = "Tabbed Document";
			menuItem4.IsChecked = (window.DockSituation == DockSituation.Document);
			menuItem4.IsEnabled = window.DockingRules.AllowTab;
			menuItem4.Click += this.OnDocumentMenuClick;
			base.Items.Add(menuItem4);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0003D2A8 File Offset: 0x0003B6A8
		private void OnDocumentMenuClick(object sender, RoutedEventArgs e)
		{
			this.window.Document(WindowOpenMethod.OpenSelectActivate);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0003D2B8 File Offset: 0x0003B6B8
		private void OnDockedMenuClick(object sender, RoutedEventArgs e)
		{
			this.window.Dock(WindowOpenMethod.OpenSelectActivate);
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0003D2C8 File Offset: 0x0003B6C8
		private void OnFloatingMenuClick(object sender, RoutedEventArgs e)
		{
			this.window.Float(WindowOpenMethod.OpenSelectActivate);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0003D2D8 File Offset: 0x0003B6D8
		private void OnCloseMenuClick(object sender, RoutedEventArgs e)
		{
			this.window.Close();
		}

		// Token: 0x04000109 RID: 265
		private DockableWindow window;
	}
}

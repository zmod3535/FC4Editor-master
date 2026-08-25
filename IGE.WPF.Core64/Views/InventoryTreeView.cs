using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using IGE.Parameters;

namespace IGE.Views
{
	// Token: 0x020000C6 RID: 198
	public class InventoryTreeView : UserControl, IComponentConnector
	{
		// Token: 0x0600076E RID: 1902 RVA: 0x0001AD23 File Offset: 0x00018F23
		public InventoryTreeView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0001AD34 File Offset: 0x00018F34
		private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			InventoryTreeViewModel inventoryTreeViewModel = (InventoryTreeViewModel)base.DataContext;
			inventoryTreeViewModel.SelectedItem = (InventoryTreeItemViewModel)e.NewValue;
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0001AD60 File Offset: 0x00018F60
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/controls/inventorytreeview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0001AD90 File Offset: 0x00018F90
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId == 1)
			{
				((TreeView)target).SelectedItemChanged += this.TreeView_OnSelectedItemChanged;
				return;
			}
			this._contentLoaded = true;
		}

		// Token: 0x04000302 RID: 770
		private bool _contentLoaded;
	}
}

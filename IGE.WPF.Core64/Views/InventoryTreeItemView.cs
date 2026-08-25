using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x0200009F RID: 159
	public class InventoryTreeItemView : UserControl, IComponentConnector
	{
		// Token: 0x06000680 RID: 1664 RVA: 0x000176D4 File Offset: 0x000158D4
		public InventoryTreeItemView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x000176E4 File Offset: 0x000158E4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/items/inventorytreeitemview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00017714 File Offset: 0x00015914
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400028F RID: 655
		private bool _contentLoaded;
	}
}

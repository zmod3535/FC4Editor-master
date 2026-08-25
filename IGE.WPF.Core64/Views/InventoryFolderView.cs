using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000088 RID: 136
	public class InventoryFolderView : UserControl, IComponentConnector
	{
		// Token: 0x060005A8 RID: 1448 RVA: 0x0001574D File Offset: 0x0001394D
		public InventoryFolderView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0001575C File Offset: 0x0001395C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/items/inventoryfolderview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0001578C File Offset: 0x0001398C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400026C RID: 620
		private bool _contentLoaded;
	}
}

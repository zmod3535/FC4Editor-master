using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000120 RID: 288
	public class InventoryEntryView : UserControl, IComponentConnector
	{
		// Token: 0x06000A0A RID: 2570 RVA: 0x000212A6 File Offset: 0x0001F4A6
		public InventoryEntryView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A0B RID: 2571 RVA: 0x000212B4 File Offset: 0x0001F4B4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/items/inventoryentryview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000A0C RID: 2572 RVA: 0x000212E4 File Offset: 0x0001F4E4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040004CD RID: 1229
		private bool _contentLoaded;
	}
}

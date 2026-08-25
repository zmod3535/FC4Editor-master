using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000B7 RID: 183
	public class EditorObjectView : UserControl, IComponentConnector
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x0001967A File Offset: 0x0001787A
		public EditorObjectView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00019688 File Offset: 0x00017888
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/items/editorobjectview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000196B8 File Offset: 0x000178B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002D8 RID: 728
		private bool _contentLoaded;
	}
}

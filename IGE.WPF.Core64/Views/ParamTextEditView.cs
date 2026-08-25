using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000028 RID: 40
	public class ParamTextEditView : UserControl, IComponentConnector
	{
		// Token: 0x0600011A RID: 282 RVA: 0x0000399C File Offset: 0x00001B9C
		public ParamTextEditView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600011B RID: 283 RVA: 0x000039AC File Offset: 0x00001BAC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/items/paramtexteditview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600011C RID: 284 RVA: 0x000039DC File Offset: 0x00001BDC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000058 RID: 88
		private bool _contentLoaded;
	}
}

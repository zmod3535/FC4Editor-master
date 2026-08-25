using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000D8 RID: 216
	public class ParamTextView : UserControl, IComponentConnector
	{
		// Token: 0x060007E9 RID: 2025 RVA: 0x0001B5C0 File Offset: 0x000197C0
		public ParamTextView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x0001B5D0 File Offset: 0x000197D0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramtextview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0001B600 File Offset: 0x00019800
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003E5 RID: 997
		private bool _contentLoaded;
	}
}

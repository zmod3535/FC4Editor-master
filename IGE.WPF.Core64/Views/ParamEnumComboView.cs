using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x0200012D RID: 301
	public class ParamEnumComboView : UserControl, IComponentConnector
	{
		// Token: 0x06000A80 RID: 2688 RVA: 0x000227E5 File Offset: 0x000209E5
		public ParamEnumComboView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x000227F4 File Offset: 0x000209F4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramenumcomboview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x00022824 File Offset: 0x00020A24
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040004FD RID: 1277
		private bool _contentLoaded;
	}
}

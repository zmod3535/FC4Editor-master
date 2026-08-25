using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000087 RID: 135
	public class ParamCheckButtonView : UserControl, IComponentConnector
	{
		// Token: 0x060005A5 RID: 1445 RVA: 0x00015706 File Offset: 0x00013906
		public ParamCheckButtonView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x00015714 File Offset: 0x00013914
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramcheckbuttonview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00015744 File Offset: 0x00013944
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400026B RID: 619
		private bool _contentLoaded;
	}
}

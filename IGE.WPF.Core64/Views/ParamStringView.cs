using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000A6 RID: 166
	public class ParamStringView : UserControl, IComponentConnector
	{
		// Token: 0x060006BD RID: 1725 RVA: 0x00018845 File Offset: 0x00016A45
		public ParamStringView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00018854 File Offset: 0x00016A54
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramstringview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00018884 File Offset: 0x00016A84
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002B0 RID: 688
		private bool _contentLoaded;
	}
}

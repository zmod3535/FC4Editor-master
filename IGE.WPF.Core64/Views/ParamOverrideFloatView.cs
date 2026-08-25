using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000038 RID: 56
	public class ParamOverrideFloatView : UserControl, IComponentConnector
	{
		// Token: 0x060002B5 RID: 693 RVA: 0x000085A5 File Offset: 0x000067A5
		public ParamOverrideFloatView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x000085B4 File Offset: 0x000067B4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramoverridefloatview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x000085E4 File Offset: 0x000067E4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000111 RID: 273
		private bool _contentLoaded;
	}
}

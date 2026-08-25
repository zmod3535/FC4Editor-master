using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000E0 RID: 224
	public class ParamIntView : UserControl, IComponentConnector
	{
		// Token: 0x06000814 RID: 2068 RVA: 0x0001BDDD File Offset: 0x00019FDD
		public ParamIntView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0001BDEC File Offset: 0x00019FEC
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramintview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0001BE1C File Offset: 0x0001A01C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003EF RID: 1007
		private bool _contentLoaded;
	}
}

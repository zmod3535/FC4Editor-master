using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000E3 RID: 227
	public class ParamEnumButtonView : UserControl, IComponentConnector
	{
		// Token: 0x0600081D RID: 2077 RVA: 0x0001BEE6 File Offset: 0x0001A0E6
		public ParamEnumButtonView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x0001BEF4 File Offset: 0x0001A0F4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramenumbuttonview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x0001BF24 File Offset: 0x0001A124
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003F1 RID: 1009
		private bool _contentLoaded;
	}
}

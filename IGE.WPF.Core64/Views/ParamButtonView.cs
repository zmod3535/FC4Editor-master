using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x0200006C RID: 108
	public class ParamButtonView : UserControl, IComponentConnector
	{
		// Token: 0x06000483 RID: 1155 RVA: 0x00011B1D File Offset: 0x0000FD1D
		public ParamButtonView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x00011B2C File Offset: 0x0000FD2C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/parambuttonview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x00011B5C File Offset: 0x0000FD5C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001FE RID: 510
		private bool _contentLoaded;
	}
}

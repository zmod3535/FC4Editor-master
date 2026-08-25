using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000070 RID: 112
	public class ParamEnumButtonImageTextView : UserControl, IComponentConnector
	{
		// Token: 0x06000497 RID: 1175 RVA: 0x00011FC2 File Offset: 0x000101C2
		public ParamEnumButtonImageTextView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x00011FD0 File Offset: 0x000101D0
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/items/paramenumbuttonimagetextview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00012000 File Offset: 0x00010200
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000202 RID: 514
		private bool _contentLoaded;
	}
}

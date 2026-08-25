using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x0200006D RID: 109
	public class ToolbarActionButton : Button, IComponentConnector
	{
		// Token: 0x06000486 RID: 1158 RVA: 0x00011B65 File Offset: 0x0000FD65
		public ToolbarActionButton()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x00011B74 File Offset: 0x0000FD74
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/toolbars/toolbaractionbutton.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x00011BA4 File Offset: 0x0000FDA4
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001FF RID: 511
		private bool _contentLoaded;
	}
}

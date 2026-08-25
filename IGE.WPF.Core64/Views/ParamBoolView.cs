using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x0200006B RID: 107
	public class ParamBoolView : UserControl, IComponentConnector
	{
		// Token: 0x06000480 RID: 1152 RVA: 0x00011AD6 File Offset: 0x0000FCD6
		public ParamBoolView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x00011AE4 File Offset: 0x0000FCE4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramboolview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x00011B14 File Offset: 0x0000FD14
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040001FD RID: 509
		private bool _contentLoaded;
	}
}

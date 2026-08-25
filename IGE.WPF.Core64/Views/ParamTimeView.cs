using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000017 RID: 23
	public class ParamTimeView : UserControl, IComponentConnector
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x00002EC4 File Offset: 0x000010C4
		public ParamTimeView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00002ED4 File Offset: 0x000010D4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramtimeview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00002F04 File Offset: 0x00001104
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x0400002C RID: 44
		private bool _contentLoaded;
	}
}

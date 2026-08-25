using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000A5 RID: 165
	public class ParamToolView : UserControl, IComponentConnector
	{
		// Token: 0x060006BA RID: 1722 RVA: 0x000187FD File Offset: 0x000169FD
		public ParamToolView()
		{
			this.InitializeComponent();
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x0001880C File Offset: 0x00016A0C
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/base/paramtoolview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x0001883C File Offset: 0x00016A3C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040002AF RID: 687
		private bool _contentLoaded;
	}
}

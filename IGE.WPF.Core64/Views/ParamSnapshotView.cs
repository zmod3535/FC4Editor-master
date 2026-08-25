using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x020000DF RID: 223
	public class ParamSnapshotView : UserControl, IComponentConnector
	{
		// Token: 0x06000811 RID: 2065 RVA: 0x0001BD95 File Offset: 0x00019F95
		public ParamSnapshotView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x0001BDA4 File Offset: 0x00019FA4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/advanced/paramsnapshotview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0001BDD4 File Offset: 0x00019FD4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x040003EE RID: 1006
		private bool _contentLoaded;
	}
}

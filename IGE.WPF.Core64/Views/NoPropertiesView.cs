using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000071 RID: 113
	public class NoPropertiesView : UserControl, IComponentConnector
	{
		// Token: 0x0600049A RID: 1178 RVA: 0x00012009 File Offset: 0x00010209
		public NoPropertiesView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00012018 File Offset: 0x00010218
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/objectproperties/nopropertiesview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00012048 File Offset: 0x00010248
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000203 RID: 515
		private bool _contentLoaded;
	}
}

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x02000029 RID: 41
	public class AmbientPropertiesView : UserControl, IComponentConnector
	{
		// Token: 0x0600011D RID: 285 RVA: 0x000039E5 File Offset: 0x00001BE5
		public AmbientPropertiesView()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000039F4 File Offset: 0x00001BF4
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/objectproperties/ambientpropertiesview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00003A24 File Offset: 0x00001C24
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000059 RID: 89
		private bool _contentLoaded;
	}
}

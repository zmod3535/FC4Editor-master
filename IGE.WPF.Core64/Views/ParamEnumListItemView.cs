using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace IGE.Views
{
	// Token: 0x0200007F RID: 127
	public class ParamEnumListItemView : UserControl, IComponentConnector
	{
		// Token: 0x06000560 RID: 1376 RVA: 0x000146C8 File Offset: 0x000128C8
		public ParamEnumListItemView()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x000146D8 File Offset: 0x000128D8
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this._contentLoaded)
			{
				return;
			}
			this._contentLoaded = true;
			Uri resourceLocator = new Uri("/IGE.WPF.Core64;component/views/parameters/items/paramenumlistitemview.xaml", UriKind.Relative);
			Application.LoadComponent(this, resourceLocator);
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x00014708 File Offset: 0x00012908
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			this._contentLoaded = true;
		}

		// Token: 0x04000243 RID: 579
		private bool _contentLoaded;
	}
}

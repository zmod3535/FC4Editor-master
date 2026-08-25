using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using IGE.Helpers;

namespace IGE.Controls
{
	// Token: 0x02000396 RID: 918
	public partial class SimpleToolbarButton : Button
	{
		// Token: 0x060014A1 RID: 5281 RVA: 0x0002BF19 File Offset: 0x0002A119
		public SimpleToolbarButton()
		{
			this.InitializeComponent();
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x0002BF27 File Offset: 0x0002A127
		public SimpleToolbarButton(string image, string tooltip, ICommand cmd) : this()
		{
			base.ToolTip = tooltip;
			base.Command = cmd;
			this.Img.Source = image.GetImage().Source;
		}
	}
}

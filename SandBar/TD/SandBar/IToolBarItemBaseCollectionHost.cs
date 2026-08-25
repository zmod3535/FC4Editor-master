using System;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000004 RID: 4
	internal interface IToolBarItemBaseCollectionHost
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600000E RID: 14
		ToolbarItemBaseCollection Items { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600000F RID: 15
		Control ControlHost { get; }

		// Token: 0x06000010 RID: 16
		void ChildItemsChanged();
	}
}

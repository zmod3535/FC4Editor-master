using System;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000002 RID: 2
	public interface IPopupMenuHost
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1
		bool RightAlignMenus { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000002 RID: 2
		bool RightToLeft { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000003 RID: 3
		IMenuRenderer Renderer { get; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000004 RID: 4
		ImageList MenuImageList { get; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000005 RID: 5
		ToolBar ToolBar { get; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000006 RID: 6
		ToolBarLayout Flow { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000007 RID: 7
		TopLevelMenuItemBase.MenuAnimation MenuAnimation { get; }
	}
}

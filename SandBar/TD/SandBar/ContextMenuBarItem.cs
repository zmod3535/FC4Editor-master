using System;
using System.ComponentModel;
using TD.SandBar.Design;

namespace TD.SandBar
{
	// Token: 0x02000064 RID: 100
	[Designer(typeof(ContextMenuBarItemDesigner))]
	public class ContextMenuBarItem : MenuBarItem
	{
		// Token: 0x06000501 RID: 1281 RVA: 0x0001B5C8 File Offset: 0x0001A5C8
		public ContextMenuBarItem()
		{
			this.Text = "(context menu)";
			this.Visible = false;
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x0001B5E4 File Offset: 0x0001A5E4
		// (set) Token: 0x06000503 RID: 1283 RVA: 0x0001B5EC File Offset: 0x0001A5EC
		[DefaultValue(false)]
		public override bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				base.Visible = value;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000504 RID: 1284 RVA: 0x0001B5F8 File Offset: 0x0001A5F8
		// (set) Token: 0x06000505 RID: 1285 RVA: 0x0001B600 File Offset: 0x0001A600
		[DefaultValue("(context menu)")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}
	}
}

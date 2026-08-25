using System;
using System.Drawing;

namespace TD.SandDock
{
	// Token: 0x0200000B RID: 11
	public class ShowControlContextMenuEventArgs : DockControlEventArgs
	{
		// Token: 0x060000F7 RID: 247 RVA: 0x0000BCE0 File Offset: 0x0000ACE0
		internal ShowControlContextMenuEventArgs(DockControl dockControl, Point position, ContextMenuContext context) : base(dockControl)
		{
			this.x13d4cb8d1bd20347 = position;
			this.x0f7b23d1c393aed9 = context;
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x0000BD04 File Offset: 0x0000AD04
		public ContextMenuContext Context
		{
			get
			{
				return this.x0f7b23d1c393aed9;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x0000BD0C File Offset: 0x0000AD0C
		public Point Position
		{
			get
			{
				return this.x13d4cb8d1bd20347;
			}
		}

		// Token: 0x04000048 RID: 72
		private Point x13d4cb8d1bd20347 = Point.Empty;

		// Token: 0x04000049 RID: 73
		private ContextMenuContext x0f7b23d1c393aed9;
	}
}

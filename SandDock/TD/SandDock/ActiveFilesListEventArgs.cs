using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000054 RID: 84
	public class ActiveFilesListEventArgs : EventArgs
	{
		// Token: 0x06000500 RID: 1280 RVA: 0x00026778 File Offset: 0x00025778
		internal ActiveFilesListEventArgs(DockControl[] windows, Control control, Point position)
		{
			this.x8fb2a5bf0df0416f = windows;
			this.x43bec302f92080b9 = control;
			this.x13d4cb8d1bd20347 = position;
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x00026798 File Offset: 0x00025798
		public DockControl[] Windows
		{
			get
			{
				return this.x8fb2a5bf0df0416f;
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000502 RID: 1282 RVA: 0x000267A0 File Offset: 0x000257A0
		public Control Control
		{
			get
			{
				return this.x43bec302f92080b9;
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x000267A8 File Offset: 0x000257A8
		public Point Position
		{
			get
			{
				return this.x13d4cb8d1bd20347;
			}
		}

		// Token: 0x040001E8 RID: 488
		private DockControl[] x8fb2a5bf0df0416f;

		// Token: 0x040001E9 RID: 489
		private Control x43bec302f92080b9;

		// Token: 0x040001EA RID: 490
		private Point x13d4cb8d1bd20347;
	}
}

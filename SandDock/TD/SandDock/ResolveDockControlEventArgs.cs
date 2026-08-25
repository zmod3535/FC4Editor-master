using System;

namespace TD.SandDock
{
	// Token: 0x0200005B RID: 91
	public class ResolveDockControlEventArgs : EventArgs
	{
		// Token: 0x0600051F RID: 1311 RVA: 0x00027230 File Offset: 0x00026230
		internal ResolveDockControlEventArgs(Guid guid)
		{
			this.xb51cd75f17ace1ec = guid;
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000520 RID: 1312 RVA: 0x00027240 File Offset: 0x00026240
		public Guid Guid
		{
			get
			{
				return this.xb51cd75f17ace1ec;
			}
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x00027248 File Offset: 0x00026248
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x00027250 File Offset: 0x00026250
		public DockControl DockControl
		{
			get
			{
				return this.x43bec302f92080b9;
			}
			set
			{
				this.x43bec302f92080b9 = value;
			}
		}

		// Token: 0x040001FD RID: 509
		private DockControl x43bec302f92080b9;

		// Token: 0x040001FE RID: 510
		private Guid xb51cd75f17ace1ec;
	}
}

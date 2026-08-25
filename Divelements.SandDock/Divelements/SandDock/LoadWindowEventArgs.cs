using System;

namespace Divelements.SandDock
{
	// Token: 0x02000013 RID: 19
	public class LoadWindowEventArgs : EventArgs
	{
		// Token: 0x060001DD RID: 477 RVA: 0x00037EE0 File Offset: 0x000362E0
		internal LoadWindowEventArgs(Guid guid)
		{
			this.xb51cd75f17ace1ec = guid;
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00037EF0 File Offset: 0x000362F0
		public Guid Guid
		{
			get
			{
				return this.xb51cd75f17ace1ec;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001DF RID: 479 RVA: 0x00037EF8 File Offset: 0x000362F8
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x00037F00 File Offset: 0x00036300
		public DockableWindow Window
		{
			get
			{
				return this.x76b3d9d2638e5ecd;
			}
			set
			{
				this.x76b3d9d2638e5ecd = value;
			}
		}

		// Token: 0x04000092 RID: 146
		private Guid xb51cd75f17ace1ec;

		// Token: 0x04000093 RID: 147
		private DockableWindow x76b3d9d2638e5ecd;
	}
}

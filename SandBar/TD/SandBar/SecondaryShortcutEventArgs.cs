using System;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000056 RID: 86
	public class SecondaryShortcutEventArgs : EventArgs
	{
		// Token: 0x060003FD RID: 1021 RVA: 0x00014794 File Offset: 0x00013794
		internal SecondaryShortcutEventArgs(Keys primaryShortcut)
		{
			this.x167e91b6ef93398c = primaryShortcut;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x000147A4 File Offset: 0x000137A4
		internal SecondaryShortcutEventArgs(Keys primaryShortcut, Keys secondaryShortcut, MenuButtonItem item)
		{
			this.x167e91b6ef93398c = primaryShortcut;
			this.x9fcd3fa8a812c3df = secondaryShortcut;
			this.xccb63ca5f63dc470 = item;
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x000147C4 File Offset: 0x000137C4
		public bool Primary
		{
			get
			{
				return this.x9fcd3fa8a812c3df == Keys.None;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000400 RID: 1024 RVA: 0x000147D0 File Offset: 0x000137D0
		public Keys PrimaryShortcut
		{
			get
			{
				return this.x167e91b6ef93398c;
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x000147D8 File Offset: 0x000137D8
		public Keys SecondaryShortcut
		{
			get
			{
				return this.x9fcd3fa8a812c3df;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x000147E0 File Offset: 0x000137E0
		public MenuButtonItem Item
		{
			get
			{
				return this.xccb63ca5f63dc470;
			}
		}

		// Token: 0x040001CB RID: 459
		private Keys x167e91b6ef93398c;

		// Token: 0x040001CC RID: 460
		private Keys x9fcd3fa8a812c3df;

		// Token: 0x040001CD RID: 461
		private MenuButtonItem xccb63ca5f63dc470;
	}
}

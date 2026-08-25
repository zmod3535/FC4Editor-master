using System;

namespace Divelements.SandGrid
{
	// Token: 0x02000026 RID: 38
	public class GridRowColumnCancelEventArgs : GridRowColumnEventArgs
	{
		// Token: 0x0600041B RID: 1051 RVA: 0x000176D0 File Offset: 0x000166D0
		internal GridRowColumnCancelEventArgs(GridRow row, GridColumn column) : base(row, column)
		{
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x0600041C RID: 1052 RVA: 0x000176DC File Offset: 0x000166DC
		// (set) Token: 0x0600041D RID: 1053 RVA: 0x000176E4 File Offset: 0x000166E4
		public bool Cancel
		{
			get
			{
				return this.x57602a0a0d178a2e;
			}
			set
			{
				this.x57602a0a0d178a2e = value;
			}
		}

		// Token: 0x04000134 RID: 308
		private bool x57602a0a0d178a2e;
	}
}

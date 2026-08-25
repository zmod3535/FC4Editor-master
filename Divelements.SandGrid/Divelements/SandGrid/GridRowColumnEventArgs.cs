using System;

namespace Divelements.SandGrid
{
	// Token: 0x02000027 RID: 39
	public class GridRowColumnEventArgs : GridRowEventArgs
	{
		// Token: 0x0600041E RID: 1054 RVA: 0x000176F0 File Offset: 0x000166F0
		internal GridRowColumnEventArgs(GridRow row, GridColumn column) : base(row)
		{
			this.xe3e287548b3d01f5 = column;
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x00017700 File Offset: 0x00016700
		public GridColumn Column
		{
			get
			{
				return this.xe3e287548b3d01f5;
			}
		}

		// Token: 0x04000135 RID: 309
		private GridColumn xe3e287548b3d01f5;
	}
}

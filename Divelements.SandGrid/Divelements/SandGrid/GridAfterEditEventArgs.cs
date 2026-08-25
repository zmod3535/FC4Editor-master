using System;

namespace Divelements.SandGrid
{
	// Token: 0x0200003E RID: 62
	public class GridAfterEditEventArgs : GridRowColumnCancelEventArgs
	{
		// Token: 0x060004DF RID: 1247 RVA: 0x0001AB1C File Offset: 0x00019B1C
		internal GridAfterEditEventArgs(GridRow row, GridColumn column, IGridCellEditor editor, object value) : base(row, column)
		{
			this.x413fd3ecdf5cf091 = editor;
			this.xbcea506a33cf9111 = value;
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0001AB38 File Offset: 0x00019B38
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x0001AB40 File Offset: 0x00019B40
		public object Value
		{
			get
			{
				return this.xbcea506a33cf9111;
			}
			set
			{
				this.xbcea506a33cf9111 = value;
			}
		}

		// Token: 0x040001A2 RID: 418
		private IGridCellEditor x413fd3ecdf5cf091;

		// Token: 0x040001A3 RID: 419
		private object xbcea506a33cf9111;
	}
}

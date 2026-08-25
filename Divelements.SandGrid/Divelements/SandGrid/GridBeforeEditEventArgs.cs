using System;

namespace Divelements.SandGrid
{
	// Token: 0x0200006B RID: 107
	public class GridBeforeEditEventArgs : GridRowColumnCancelEventArgs
	{
		// Token: 0x06000610 RID: 1552 RVA: 0x0001FF3C File Offset: 0x0001EF3C
		internal GridBeforeEditEventArgs(GridRow row, GridColumn column, IGridCellEditor editor) : base(row, column)
		{
			this.x413fd3ecdf5cf091 = editor;
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x0001FF50 File Offset: 0x0001EF50
		public IGridCellEditor Editor
		{
			get
			{
				return this.x413fd3ecdf5cf091;
			}
		}

		// Token: 0x0400024B RID: 587
		private IGridCellEditor x413fd3ecdf5cf091;
	}
}

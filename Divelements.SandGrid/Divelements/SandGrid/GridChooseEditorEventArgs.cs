using System;

namespace Divelements.SandGrid
{
	// Token: 0x0200006A RID: 106
	public class GridChooseEditorEventArgs : GridRowColumnEventArgs
	{
		// Token: 0x0600060D RID: 1549 RVA: 0x0001FEEC File Offset: 0x0001EEEC
		internal GridChooseEditorEventArgs(GridRow row, GridColumn column) : base(row, column)
		{
			this.xbeb1c4d7553f61e7 = column.EditorType;
		}

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x0001FF04 File Offset: 0x0001EF04
		// (set) Token: 0x0600060F RID: 1551 RVA: 0x0001FF0C File Offset: 0x0001EF0C
		public Type EditorType
		{
			get
			{
				return this.xbeb1c4d7553f61e7;
			}
			set
			{
				if (value != null && value.GetInterface("Divelements.SandGrid.IGridCellEditor") != typeof(IGridCellEditor))
				{
					throw new ArgumentException("value");
				}
				this.xbeb1c4d7553f61e7 = value;
			}
		}

		// Token: 0x0400024A RID: 586
		private Type xbeb1c4d7553f61e7;
	}
}

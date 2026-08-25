using System;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000067 RID: 103
	public class GridColumn<T> : TypedGridColumn
	{
		// Token: 0x060005FE RID: 1534 RVA: 0x0001FE20 File Offset: 0x0001EE20
		public GridColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x0001FE2C File Offset: 0x0001EE2C
		public GridColumn()
		{
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x0001FE34 File Offset: 0x0001EE34
		public override Type DataType
		{
			get
			{
				return typeof(T);
			}
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001FE40 File Offset: 0x0001EE40
		public override GridCell CreateCell()
		{
			return new GridCell<T>();
		}
	}
}

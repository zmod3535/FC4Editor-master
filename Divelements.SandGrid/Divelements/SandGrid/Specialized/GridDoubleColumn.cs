using System;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200008B RID: 139
	public class GridDoubleColumn : TypedGridColumn
	{
		// Token: 0x0600066E RID: 1646 RVA: 0x00021C84 File Offset: 0x00020C84
		public GridDoubleColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x00021C90 File Offset: 0x00020C90
		public GridDoubleColumn()
		{
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x00021C98 File Offset: 0x00020C98
		public override Type DataType
		{
			get
			{
				return typeof(double);
			}
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x00021CA4 File Offset: 0x00020CA4
		public override GridCell CreateCell()
		{
			return new GridDoubleCell();
		}
	}
}

using System;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000091 RID: 145
	public class GridDecimalColumn : TypedGridColumn
	{
		// Token: 0x06000697 RID: 1687 RVA: 0x00022358 File Offset: 0x00021358
		public GridDecimalColumn()
		{
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00022360 File Offset: 0x00021360
		public GridDecimalColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0002236C File Offset: 0x0002136C
		public override GridCell CreateCell()
		{
			return new GridDecimalCell();
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600069A RID: 1690 RVA: 0x00022374 File Offset: 0x00021374
		public override Type DataType
		{
			get
			{
				return typeof(decimal);
			}
		}
	}
}

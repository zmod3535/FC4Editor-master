using System;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000089 RID: 137
	public class GridIntegerColumn : TypedGridColumn
	{
		// Token: 0x06000664 RID: 1636 RVA: 0x00021BC4 File Offset: 0x00020BC4
		public GridIntegerColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00021BD0 File Offset: 0x00020BD0
		public GridIntegerColumn()
		{
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x00021BD8 File Offset: 0x00020BD8
		public override Type DataType
		{
			get
			{
				return typeof(int);
			}
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x00021BE4 File Offset: 0x00020BE4
		public override GridCell CreateCell()
		{
			return new GridIntegerCell();
		}
	}
}

using System;

namespace Divelements.SandGrid
{
	// Token: 0x020000B5 RID: 181
	internal class xc410cede71ea7f97 : GridColumn
	{
		// Token: 0x0600080C RID: 2060 RVA: 0x00026A20 File Offset: 0x00025A20
		public override GridCell CreateCell()
		{
			GridCell gridCell = base.CreateCell();
			gridCell.IsNull = false;
			return gridCell;
		}
	}
}

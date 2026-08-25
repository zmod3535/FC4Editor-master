using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200002D RID: 45
	[Flags]
	internal enum NotificationTarget
	{
		// Token: 0x04000096 RID: 150
		None = 0,
		// Token: 0x04000097 RID: 151
		Cells = 1,
		// Token: 0x04000098 RID: 152
		CellsPresenter = 2,
		// Token: 0x04000099 RID: 153
		Columns = 4,
		// Token: 0x0400009A RID: 154
		ColumnCollection = 8,
		// Token: 0x0400009B RID: 155
		ColumnHeaders = 16,
		// Token: 0x0400009C RID: 156
		ColumnHeadersPresenter = 32,
		// Token: 0x0400009D RID: 157
		DataGrid = 64,
		// Token: 0x0400009E RID: 158
		DetailsPresenter = 128,
		// Token: 0x0400009F RID: 159
		RefreshCellContent = 256,
		// Token: 0x040000A0 RID: 160
		RowHeaders = 512,
		// Token: 0x040000A1 RID: 161
		Rows = 1024,
		// Token: 0x040000A2 RID: 162
		All = 4095
	}
}

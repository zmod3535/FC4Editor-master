using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000026 RID: 38
	public class DataGridRowEventArgs : EventArgs
	{
		// Token: 0x0600022A RID: 554 RVA: 0x00009011 File Offset: 0x00007211
		public DataGridRowEventArgs(DataGridRow row)
		{
			this.Row = row;
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600022B RID: 555 RVA: 0x00009020 File Offset: 0x00007220
		// (set) Token: 0x0600022C RID: 556 RVA: 0x00009028 File Offset: 0x00007228
		public DataGridRow Row { get; private set; }
	}
}

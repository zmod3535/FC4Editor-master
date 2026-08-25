using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200000E RID: 14
	public class DataGridColumnEventArgs : EventArgs
	{
		// Token: 0x06000127 RID: 295 RVA: 0x00005508 File Offset: 0x00003708
		public DataGridColumnEventArgs(DataGridColumn column)
		{
			this._column = column;
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00005517 File Offset: 0x00003717
		public DataGridColumn Column
		{
			get
			{
				return this._column;
			}
		}

		// Token: 0x0400003C RID: 60
		private DataGridColumn _column;
	}
}

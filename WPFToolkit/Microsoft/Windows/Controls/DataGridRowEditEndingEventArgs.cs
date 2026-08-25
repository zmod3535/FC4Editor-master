using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200006D RID: 109
	public class DataGridRowEditEndingEventArgs : EventArgs
	{
		// Token: 0x060007CF RID: 1999 RVA: 0x00022E27 File Offset: 0x00021027
		public DataGridRowEditEndingEventArgs(DataGridRow row, DataGridEditAction editAction)
		{
			this._dataGridRow = row;
			this._editAction = editAction;
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x00022E3D File Offset: 0x0002103D
		// (set) Token: 0x060007D1 RID: 2001 RVA: 0x00022E45 File Offset: 0x00021045
		public bool Cancel
		{
			get
			{
				return this._cancel;
			}
			set
			{
				this._cancel = value;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x00022E4E File Offset: 0x0002104E
		public DataGridRow Row
		{
			get
			{
				return this._dataGridRow;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x00022E56 File Offset: 0x00021056
		public DataGridEditAction EditAction
		{
			get
			{
				return this._editAction;
			}
		}

		// Token: 0x04000279 RID: 633
		private bool _cancel;

		// Token: 0x0400027A RID: 634
		private DataGridRow _dataGridRow;

		// Token: 0x0400027B RID: 635
		private DataGridEditAction _editAction;
	}
}

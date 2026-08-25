using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200003D RID: 61
	public class DataGridSortingEventArgs : DataGridColumnEventArgs
	{
		// Token: 0x060004CC RID: 1228 RVA: 0x0001309C File Offset: 0x0001129C
		public DataGridSortingEventArgs(DataGridColumn column) : base(column)
		{
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x000130A5 File Offset: 0x000112A5
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x000130AD File Offset: 0x000112AD
		public bool Handled
		{
			get
			{
				return this._handled;
			}
			set
			{
				this._handled = value;
			}
		}

		// Token: 0x04000156 RID: 342
		private bool _handled;
	}
}

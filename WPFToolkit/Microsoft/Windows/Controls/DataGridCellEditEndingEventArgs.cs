using System;
using System.Windows;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000056 RID: 86
	public class DataGridCellEditEndingEventArgs : EventArgs
	{
		// Token: 0x060006D0 RID: 1744 RVA: 0x0001BE6F File Offset: 0x0001A06F
		public DataGridCellEditEndingEventArgs(DataGridColumn column, DataGridRow row, FrameworkElement editingElement, DataGridEditAction editAction)
		{
			this._dataGridColumn = column;
			this._dataGridRow = row;
			this._editingElement = editingElement;
			this._editAction = editAction;
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x0001BE94 File Offset: 0x0001A094
		// (set) Token: 0x060006D2 RID: 1746 RVA: 0x0001BE9C File Offset: 0x0001A09C
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

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0001BEA5 File Offset: 0x0001A0A5
		public DataGridColumn Column
		{
			get
			{
				return this._dataGridColumn;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x060006D4 RID: 1748 RVA: 0x0001BEAD File Offset: 0x0001A0AD
		public DataGridRow Row
		{
			get
			{
				return this._dataGridRow;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x060006D5 RID: 1749 RVA: 0x0001BEB5 File Offset: 0x0001A0B5
		public FrameworkElement EditingElement
		{
			get
			{
				return this._editingElement;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x0001BEBD File Offset: 0x0001A0BD
		public DataGridEditAction EditAction
		{
			get
			{
				return this._editAction;
			}
		}

		// Token: 0x040001EC RID: 492
		private bool _cancel;

		// Token: 0x040001ED RID: 493
		private DataGridColumn _dataGridColumn;

		// Token: 0x040001EE RID: 494
		private DataGridRow _dataGridRow;

		// Token: 0x040001EF RID: 495
		private FrameworkElement _editingElement;

		// Token: 0x040001F0 RID: 496
		private DataGridEditAction _editAction;
	}
}

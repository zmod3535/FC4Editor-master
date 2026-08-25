using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200001C RID: 28
	public class DataGridCellClipboardEventArgs : EventArgs
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x0000740C File Offset: 0x0000560C
		public DataGridCellClipboardEventArgs(object item, DataGridColumn column, object content)
		{
			this._item = item;
			this._column = column;
			this._content = content;
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x00007429 File Offset: 0x00005629
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x00007431 File Offset: 0x00005631
		public object Content
		{
			get
			{
				return this._content;
			}
			set
			{
				this._content = value;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000743A File Offset: 0x0000563A
		public object Item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001B9 RID: 441 RVA: 0x00007442 File Offset: 0x00005642
		public DataGridColumn Column
		{
			get
			{
				return this._column;
			}
		}

		// Token: 0x04000075 RID: 117
		private object _content;

		// Token: 0x04000076 RID: 118
		private object _item;

		// Token: 0x04000077 RID: 119
		private DataGridColumn _column;
	}
}

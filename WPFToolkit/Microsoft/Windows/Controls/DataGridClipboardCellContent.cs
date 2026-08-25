using System;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200001B RID: 27
	public struct DataGridClipboardCellContent
	{
		// Token: 0x060001AD RID: 429 RVA: 0x000072CE File Offset: 0x000054CE
		public DataGridClipboardCellContent(object item, DataGridColumn column, object content)
		{
			this._item = item;
			this._column = column;
			this._content = content;
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001AE RID: 430 RVA: 0x000072E5 File Offset: 0x000054E5
		public object Item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001AF RID: 431 RVA: 0x000072ED File Offset: 0x000054ED
		public DataGridColumn Column
		{
			get
			{
				return this._column;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x000072F5 File Offset: 0x000054F5
		public object Content
		{
			get
			{
				return this._content;
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00007300 File Offset: 0x00005500
		public override bool Equals(object data)
		{
			if (data is DataGridClipboardCellContent)
			{
				DataGridClipboardCellContent dataGridClipboardCellContent = (DataGridClipboardCellContent)data;
				return this._column == dataGridClipboardCellContent._column && this._content == dataGridClipboardCellContent._content && this._item == dataGridClipboardCellContent._item;
			}
			return false;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00007350 File Offset: 0x00005550
		public override int GetHashCode()
		{
			return ((this._column == null) ? 0 : this._column.GetHashCode()) ^ ((this._content == null) ? 0 : this._content.GetHashCode()) ^ ((this._item == null) ? 0 : this._item.GetHashCode());
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x000073A1 File Offset: 0x000055A1
		public static bool operator ==(DataGridClipboardCellContent clipboardCellContent1, DataGridClipboardCellContent clipboardCellContent2)
		{
			return clipboardCellContent1._column == clipboardCellContent2._column && clipboardCellContent1._content == clipboardCellContent2._content && clipboardCellContent1._item == clipboardCellContent2._item;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x000073D5 File Offset: 0x000055D5
		public static bool operator !=(DataGridClipboardCellContent clipboardCellContent1, DataGridClipboardCellContent clipboardCellContent2)
		{
			return clipboardCellContent1._column != clipboardCellContent2._column || clipboardCellContent1._content != clipboardCellContent2._content || clipboardCellContent1._item != clipboardCellContent2._item;
		}

		// Token: 0x04000072 RID: 114
		private object _item;

		// Token: 0x04000073 RID: 115
		private DataGridColumn _column;

		// Token: 0x04000074 RID: 116
		private object _content;
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200002E RID: 46
	public class DataGridRowClipboardEventArgs : EventArgs
	{
		// Token: 0x06000277 RID: 631 RVA: 0x00009A15 File Offset: 0x00007C15
		public DataGridRowClipboardEventArgs(object item, int startColumnDisplayIndex, int endColumnDisplayIndex, bool isColumnHeadersRow)
		{
			this._item = item;
			this._startColumnDisplayIndex = startColumnDisplayIndex;
			this._endColumnDisplayIndex = endColumnDisplayIndex;
			this._isColumnHeadersRow = isColumnHeadersRow;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00009A41 File Offset: 0x00007C41
		internal DataGridRowClipboardEventArgs(object item, int startColumnDisplayIndex, int endColumnDisplayIndex, bool isColumnHeadersRow, int rowIndexHint) : this(item, startColumnDisplayIndex, endColumnDisplayIndex, isColumnHeadersRow)
		{
			this._rowIndexHint = rowIndexHint;
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00009A56 File Offset: 0x00007C56
		public object Item
		{
			get
			{
				return this._item;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600027A RID: 634 RVA: 0x00009A5E File Offset: 0x00007C5E
		public List<DataGridClipboardCellContent> ClipboardRowContent
		{
			get
			{
				if (this._clipboardRowContent == null)
				{
					this._clipboardRowContent = new List<DataGridClipboardCellContent>();
				}
				return this._clipboardRowContent;
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00009A7C File Offset: 0x00007C7C
		public string FormatClipboardCellValues(string format)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int count = this.ClipboardRowContent.Count;
			for (int i = 0; i < count; i++)
			{
				ClipboardHelper.FormatCell(this.ClipboardRowContent[i].Content, i == 0, i == count - 1, stringBuilder, format);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600027C RID: 636 RVA: 0x00009AD2 File Offset: 0x00007CD2
		public int StartColumnDisplayIndex
		{
			get
			{
				return this._startColumnDisplayIndex;
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600027D RID: 637 RVA: 0x00009ADA File Offset: 0x00007CDA
		public int EndColumnDisplayIndex
		{
			get
			{
				return this._endColumnDisplayIndex;
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600027E RID: 638 RVA: 0x00009AE2 File Offset: 0x00007CE2
		public bool IsColumnHeadersRow
		{
			get
			{
				return this._isColumnHeadersRow;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00009AEA File Offset: 0x00007CEA
		internal int RowIndexHint
		{
			get
			{
				return this._rowIndexHint;
			}
		}

		// Token: 0x040000A3 RID: 163
		private int _startColumnDisplayIndex;

		// Token: 0x040000A4 RID: 164
		private int _endColumnDisplayIndex;

		// Token: 0x040000A5 RID: 165
		private object _item;

		// Token: 0x040000A6 RID: 166
		private bool _isColumnHeadersRow;

		// Token: 0x040000A7 RID: 167
		private List<DataGridClipboardCellContent> _clipboardRowContent;

		// Token: 0x040000A8 RID: 168
		private int _rowIndexHint = -1;
	}
}

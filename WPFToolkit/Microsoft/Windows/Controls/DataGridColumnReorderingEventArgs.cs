using System;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200000F RID: 15
	public class DataGridColumnReorderingEventArgs : DataGridColumnEventArgs
	{
		// Token: 0x06000129 RID: 297 RVA: 0x0000551F File Offset: 0x0000371F
		public DataGridColumnReorderingEventArgs(DataGridColumn dataGridColumn) : base(dataGridColumn)
		{
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00005528 File Offset: 0x00003728
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00005530 File Offset: 0x00003730
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

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00005539 File Offset: 0x00003739
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00005541 File Offset: 0x00003741
		public Control DropLocationIndicator
		{
			get
			{
				return this._dropLocationIndicator;
			}
			set
			{
				this._dropLocationIndicator = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600012E RID: 302 RVA: 0x0000554A File Offset: 0x0000374A
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00005552 File Offset: 0x00003752
		public Control DragIndicator
		{
			get
			{
				return this._dragIndicator;
			}
			set
			{
				this._dragIndicator = value;
			}
		}

		// Token: 0x0400003D RID: 61
		private bool _cancel;

		// Token: 0x0400003E RID: 62
		private Control _dropLocationIndicator;

		// Token: 0x0400003F RID: 63
		private Control _dragIndicator;
	}
}

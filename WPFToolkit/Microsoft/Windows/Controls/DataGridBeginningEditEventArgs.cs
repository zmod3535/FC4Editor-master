using System;
using System.Windows;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000010 RID: 16
	public class DataGridBeginningEditEventArgs : EventArgs
	{
		// Token: 0x06000130 RID: 304 RVA: 0x0000555B File Offset: 0x0000375B
		public DataGridBeginningEditEventArgs(DataGridColumn column, DataGridRow row, RoutedEventArgs editingEventArgs)
		{
			this._dataGridColumn = column;
			this._dataGridRow = row;
			this._editingEventArgs = editingEventArgs;
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00005578 File Offset: 0x00003778
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00005580 File Offset: 0x00003780
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

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00005589 File Offset: 0x00003789
		public DataGridColumn Column
		{
			get
			{
				return this._dataGridColumn;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00005591 File Offset: 0x00003791
		public DataGridRow Row
		{
			get
			{
				return this._dataGridRow;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00005599 File Offset: 0x00003799
		public RoutedEventArgs EditingEventArgs
		{
			get
			{
				return this._editingEventArgs;
			}
		}

		// Token: 0x04000040 RID: 64
		private bool _cancel;

		// Token: 0x04000041 RID: 65
		private DataGridColumn _dataGridColumn;

		// Token: 0x04000042 RID: 66
		private DataGridRow _dataGridRow;

		// Token: 0x04000043 RID: 67
		private RoutedEventArgs _editingEventArgs;
	}
}

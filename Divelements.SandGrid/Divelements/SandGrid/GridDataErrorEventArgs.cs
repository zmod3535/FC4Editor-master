using System;

namespace Divelements.SandGrid
{
	// Token: 0x02000025 RID: 37
	public class GridDataErrorEventArgs : GridRowColumnCancelEventArgs
	{
		// Token: 0x06000415 RID: 1045 RVA: 0x00017680 File Offset: 0x00016680
		internal GridDataErrorEventArgs(GridRow row, GridColumn column, object value, DataErrorOperation operation, Exception exception) : base(row, column)
		{
			this.xbcea506a33cf9111 = value;
			this.x1437816edeb48c46 = operation;
			this.xc3c70767499bc99a = exception;
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x000176A4 File Offset: 0x000166A4
		public DataErrorOperation Operation
		{
			get
			{
				return this.x1437816edeb48c46;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x000176AC File Offset: 0x000166AC
		public object Value
		{
			get
			{
				return this.xbcea506a33cf9111;
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x000176B4 File Offset: 0x000166B4
		public Exception Exception
		{
			get
			{
				return this.xc3c70767499bc99a;
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x000176BC File Offset: 0x000166BC
		// (set) Token: 0x0600041A RID: 1050 RVA: 0x000176C4 File Offset: 0x000166C4
		public bool ThrowException
		{
			get
			{
				return this.x0f42047ea9506d6f;
			}
			set
			{
				this.x0f42047ea9506d6f = value;
			}
		}

		// Token: 0x04000130 RID: 304
		private object xbcea506a33cf9111;

		// Token: 0x04000131 RID: 305
		private Exception xc3c70767499bc99a;

		// Token: 0x04000132 RID: 306
		private bool x0f42047ea9506d6f;

		// Token: 0x04000133 RID: 307
		private DataErrorOperation x1437816edeb48c46;
	}
}

using System;

namespace Divelements.SandGrid
{
	// Token: 0x02000010 RID: 16
	public class GridRowEventArgs : EventArgs
	{
		// Token: 0x0600023E RID: 574 RVA: 0x0000EDDC File Offset: 0x0000DDDC
		internal GridRowEventArgs(GridRow row)
		{
			this.xa806b754814b9ae0 = row;
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600023F RID: 575 RVA: 0x0000EDEC File Offset: 0x0000DDEC
		public GridRow Row
		{
			get
			{
				return this.xa806b754814b9ae0;
			}
		}

		// Token: 0x04000091 RID: 145
		private GridRow xa806b754814b9ae0;
	}
}

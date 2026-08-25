using System;

namespace IGE
{
	// Token: 0x02000040 RID: 64
	[Serializable]
	public struct RECT
	{
		// Token: 0x06000308 RID: 776 RVA: 0x0000969E File Offset: 0x0000789E
		public RECT(int left, int top, int right, int bottom)
		{
			this.Left = left;
			this.Top = top;
			this.Right = right;
			this.Bottom = bottom;
		}

		// Token: 0x0400013D RID: 317
		public int Left;

		// Token: 0x0400013E RID: 318
		public int Top;

		// Token: 0x0400013F RID: 319
		public int Right;

		// Token: 0x04000140 RID: 320
		public int Bottom;
	}
}

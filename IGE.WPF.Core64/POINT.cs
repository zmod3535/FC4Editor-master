using System;

namespace IGE
{
	// Token: 0x02000041 RID: 65
	[Serializable]
	public struct POINT
	{
		// Token: 0x06000309 RID: 777 RVA: 0x000096BD File Offset: 0x000078BD
		public POINT(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		// Token: 0x04000141 RID: 321
		public int X;

		// Token: 0x04000142 RID: 322
		public int Y;
	}
}

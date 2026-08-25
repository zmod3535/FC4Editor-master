using System;

namespace IGE
{
	// Token: 0x02000042 RID: 66
	[Serializable]
	public struct WINDOWPLACEMENT
	{
		// Token: 0x04000143 RID: 323
		public int length;

		// Token: 0x04000144 RID: 324
		public int flags;

		// Token: 0x04000145 RID: 325
		public int showCmd;

		// Token: 0x04000146 RID: 326
		public POINT minPosition;

		// Token: 0x04000147 RID: 327
		public POINT maxPosition;

		// Token: 0x04000148 RID: 328
		public RECT normalPosition;
	}
}

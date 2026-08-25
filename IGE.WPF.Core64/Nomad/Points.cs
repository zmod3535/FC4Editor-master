using System;

namespace IGE.Nomad
{
	// Token: 0x02000100 RID: 256
	internal struct Points
	{
		// Token: 0x060008FE RID: 2302 RVA: 0x0001E121 File Offset: 0x0001C321
		public Points(IntPtr pointsPtr)
		{
			this.m_pointsPtr = pointsPtr;
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x0001E12A File Offset: 0x0001C32A
		public static Points Create()
		{
			return new Points(Binding.FCE_Core_Points_Create());
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x0001E13B File Offset: 0x0001C33B
		public void Destroy()
		{
			Binding.FCE_Core_Points_Destroy(this.m_pointsPtr);
			this.m_pointsPtr = IntPtr.Zero;
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000901 RID: 2305 RVA: 0x0001E158 File Offset: 0x0001C358
		public IntPtr Pointer
		{
			get
			{
				return this.m_pointsPtr;
			}
		}

		// Token: 0x0400045C RID: 1116
		public static Points Null = new Points(IntPtr.Zero);

		// Token: 0x0400045D RID: 1117
		private IntPtr m_pointsPtr;
	}
}

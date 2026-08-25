using System;

namespace IGE.Nomad
{
	// Token: 0x02000117 RID: 279
	internal class SplineZone : Spline
	{
		// Token: 0x060009C2 RID: 2498 RVA: 0x0002077E File Offset: 0x0001E97E
		public SplineZone(IntPtr ptr) : base(ptr)
		{
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00020787 File Offset: 0x0001E987
		public void Reset()
		{
			Binding.FCE_SplineZone_Reset(this.m_splinePtr);
		}

		// Token: 0x040004A8 RID: 1192
		public new static SplineZone Null = new SplineZone(IntPtr.Zero);
	}
}

using System;

namespace IGE.Nomad
{
	// Token: 0x02000116 RID: 278
	internal class SplineRoad : Spline
	{
		// Token: 0x060009BC RID: 2492 RVA: 0x00020710 File Offset: 0x0001E910
		public SplineRoad(IntPtr ptr) : base(ptr)
		{
		}

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060009BD RID: 2493 RVA: 0x00020719 File Offset: 0x0001E919
		// (set) Token: 0x060009BE RID: 2494 RVA: 0x00020730 File Offset: 0x0001E930
		public SplineInventory.Entry Entry
		{
			get
			{
				return new SplineInventory.Entry(Binding.FCE_SplineRoad_GetEntry(this.m_splinePtr));
			}
			set
			{
				Binding.FCE_SplineRoad_SetEntry(this.m_splinePtr, value.Pointer);
			}
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x00020748 File Offset: 0x0001E948
		// (set) Token: 0x060009C0 RID: 2496 RVA: 0x0002075A File Offset: 0x0001E95A
		public float Width
		{
			get
			{
				return Binding.FCE_SplineRoad_GetWidth(this.m_splinePtr);
			}
			set
			{
				Binding.FCE_SplineRoad_SetWidth(this.m_splinePtr, value);
			}
		}

		// Token: 0x040004A7 RID: 1191
		public new static SplineRoad Null = new SplineRoad(IntPtr.Zero);
	}
}

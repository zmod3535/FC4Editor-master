using System;

namespace IGE.Nomad
{
	// Token: 0x02000115 RID: 277
	internal class Spline : IDisposable
	{
		// Token: 0x060009A7 RID: 2471 RVA: 0x00020500 File Offset: 0x0001E700
		public Spline(IntPtr ptr)
		{
			this.m_splinePtr = ptr;
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0002050F File Offset: 0x0001E70F
		public static Spline Create()
		{
			return new Spline(Binding.FCE_Spline_Create());
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x00020520 File Offset: 0x0001E720
		public void Dispose()
		{
			Binding.FCE_Spline_Destroy(this.m_splinePtr);
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x00020532 File Offset: 0x0001E732
		public void Clear()
		{
			Binding.FCE_Spline_Clear(this.m_splinePtr);
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00020544 File Offset: 0x0001E744
		public void AddPoint(Vec2 point)
		{
			Binding.FCE_Spline_AddPoint(this.m_splinePtr, point.X, point.Y);
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x00020564 File Offset: 0x0001E764
		public void InsertPoint(Vec2 point, int index)
		{
			Binding.FCE_Spline_InsertPoint(this.m_splinePtr, point.X, point.Y, index);
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x00020585 File Offset: 0x0001E785
		public void RemovePoint(int index)
		{
			Binding.FCE_Spline_RemovePoint(this.m_splinePtr, index);
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x00020598 File Offset: 0x0001E798
		public bool RemoveSimilarPoints()
		{
			return Binding.FCE_Spline_RemoveSimilarPoints(this.m_splinePtr);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x000205AA File Offset: 0x0001E7AA
		public bool OptimizePoint(int index)
		{
			return Binding.FCE_Spline_OptimizePoint(this.m_splinePtr, index);
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x000205BD File Offset: 0x0001E7BD
		public int Count
		{
			get
			{
				return Binding.FCE_Spline_GetNumPoints(this.m_splinePtr);
			}
		}

		// Token: 0x17000225 RID: 549
		public Vec2 this[int index]
		{
			get
			{
				Vec2 result = default(Vec2);
				Binding.FCE_Spline_GetPoint(this.m_splinePtr, index, out result.X, out result.Y);
				return result;
			}
			set
			{
				Binding.FCE_Spline_SetPoint(this.m_splinePtr, index, value.X, value.Y);
			}
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x00020626 File Offset: 0x0001E826
		public void UpdateSpline()
		{
			Binding.FCE_Spline_UpdateSpline(this.m_splinePtr);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x00020638 File Offset: 0x0001E838
		public void UpdateSplineHeight()
		{
			Binding.FCE_Spline_UpdateSplineHeight(this.m_splinePtr);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0002064A File Offset: 0x0001E84A
		public void FinalizeSpline()
		{
			Binding.FCE_Spline_FinalizeSpline(this.m_splinePtr);
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0002065C File Offset: 0x0001E85C
		public void Draw(float penWidth, SplineController controller)
		{
			Binding.FCE_Spline_Draw(this.m_splinePtr, penWidth, controller.Pointer);
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x00020678 File Offset: 0x0001E878
		public bool HitTestPoints(Vec2 point, float penWidth, float hitWidth, out int hitIndex, out Vec2 hitPos)
		{
			return Binding.FCE_Spline_HitTestPoints(this.m_splinePtr, point.X, point.Y, penWidth, hitWidth, out hitIndex, out hitPos.X, out hitPos.Y);
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x000206B5 File Offset: 0x0001E8B5
		public bool HitTestSegments(Vec2 center, float radius, out int hitIndex, out Vec2 hitPos)
		{
			return Binding.FCE_Spline_HitTestSegments(this.m_splinePtr, center.X, center.Y, radius, out hitIndex, out hitPos.X, out hitPos.Y);
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x000206E5 File Offset: 0x0001E8E5
		public bool IsValid
		{
			get
			{
				return this.Pointer != IntPtr.Zero;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x000206F7 File Offset: 0x0001E8F7
		public IntPtr Pointer
		{
			get
			{
				return this.m_splinePtr;
			}
		}

		// Token: 0x040004A5 RID: 1189
		public static Spline Null = new Spline(IntPtr.Zero);

		// Token: 0x040004A6 RID: 1190
		protected IntPtr m_splinePtr;
	}
}

using System;

namespace IGE.Nomad
{
	// Token: 0x02000035 RID: 53
	internal struct Gizmo : IDisposable
	{
		// Token: 0x0600029C RID: 668 RVA: 0x00007FC0 File Offset: 0x000061C0
		public Gizmo(IntPtr ptr)
		{
			this.m_gizmoPtr = ptr;
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00007FC9 File Offset: 0x000061C9
		public static Gizmo Create()
		{
			return new Gizmo(Binding.FCE_Gizmo_Create());
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00007FDA File Offset: 0x000061DA
		public void Dispose()
		{
			Binding.FCE_Gizmo_Destroy(this.m_gizmoPtr);
			this.m_gizmoPtr = IntPtr.Zero;
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00007FF8 File Offset: 0x000061F8
		// (set) Token: 0x060002A0 RID: 672 RVA: 0x00008033 File Offset: 0x00006233
		public Vec3 Position
		{
			get
			{
				Vec3 result = default(Vec3);
				Binding.FCE_Gizmo_GetPos(this.m_gizmoPtr, out result.X, out result.Y, out result.Z);
				return result;
			}
			set
			{
				Binding.FCE_Gizmo_SetPos(this.m_gizmoPtr, value.X, value.Y, value.Z);
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x0000805C File Offset: 0x0000625C
		// (set) Token: 0x060002A2 RID: 674 RVA: 0x000080F0 File Offset: 0x000062F0
		public CoordinateSystem Axis
		{
			get
			{
				CoordinateSystem result = default(CoordinateSystem);
				Binding.FCE_Gizmo_GetAxis(this.m_gizmoPtr, out result.axisX.X, out result.axisX.Y, out result.axisX.Z, out result.axisY.X, out result.axisY.Y, out result.axisY.Z, out result.axisZ.X, out result.axisZ.Y, out result.axisZ.Z);
				return result;
			}
			set
			{
				Binding.FCE_Gizmo_SetAxis(this.m_gizmoPtr, value.axisX.X, value.axisX.Y, value.axisX.Z, value.axisY.X, value.axisY.Y, value.axisY.Z, value.axisZ.X, value.axisZ.Y, value.axisZ.Z);
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x00008179 File Offset: 0x00006379
		// (set) Token: 0x060002A4 RID: 676 RVA: 0x0000818B File Offset: 0x0000638B
		public Axis Active
		{
			get
			{
				return (Axis)Binding.FCE_Gizmo_GetActive(this.m_gizmoPtr);
			}
			set
			{
				Binding.FCE_Gizmo_SetActive(this.m_gizmoPtr, (int)value);
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x0000819E File Offset: 0x0000639E
		public void Redraw()
		{
			Binding.FCE_Gizmo_Redraw(this.m_gizmoPtr);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x000081B0 File Offset: 0x000063B0
		public void Hide()
		{
			Binding.FCE_Gizmo_Hide(this.m_gizmoPtr);
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x000081C2 File Offset: 0x000063C2
		// (set) Token: 0x060002A8 RID: 680 RVA: 0x000081D4 File Offset: 0x000063D4
		public bool RotationMode
		{
			get
			{
				return Binding.FCE_Gizmo_IsRotationMode(this.m_gizmoPtr);
			}
			set
			{
				Binding.FCE_Gizmo_SetRotationMode(this.m_gizmoPtr, value);
			}
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x000081E7 File Offset: 0x000063E7
		public void ResetAxes()
		{
			Binding.FCE_Gizmo_ResetAxes(this.m_gizmoPtr);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x000081F9 File Offset: 0x000063F9
		public void EnableAxis(Axis axis, bool flag)
		{
			Binding.FCE_Gizmo_EnableAxis(this.m_gizmoPtr, (int)axis, flag);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0000820D File Offset: 0x0000640D
		public Axis HitTest(Vec3 raySrc, Vec3 rayDir)
		{
			return (Axis)Binding.FCE_Gizmo_HitTest(this.m_gizmoPtr, raySrc.X, raySrc.Y, raySrc.Z, rayDir.X, rayDir.Y, rayDir.Z);
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060002AC RID: 684 RVA: 0x00008249 File Offset: 0x00006449
		public bool IsValid
		{
			get
			{
				return this.m_gizmoPtr != IntPtr.Zero;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060002AD RID: 685 RVA: 0x0000825B File Offset: 0x0000645B
		public IntPtr Pointer
		{
			get
			{
				return this.m_gizmoPtr;
			}
		}

		// Token: 0x0400010A RID: 266
		public static Gizmo Null = new Gizmo(IntPtr.Zero);

		// Token: 0x0400010B RID: 267
		private IntPtr m_gizmoPtr;
	}
}

using System;
using System.Windows;

namespace IGE.Nomad
{
	// Token: 0x02000118 RID: 280
	internal struct SplineController
	{
		// Token: 0x060009C5 RID: 2501 RVA: 0x000207AA File Offset: 0x0001E9AA
		public SplineController(IntPtr ptr)
		{
			this.m_controllerPtr = ptr;
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x000207B3 File Offset: 0x0001E9B3
		public static SplineController Create()
		{
			return new SplineController(Binding.FCE_SplineController_Create());
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x000207C4 File Offset: 0x0001E9C4
		public void Dispose()
		{
			Binding.FCE_SplineController_Destroy(this.m_controllerPtr);
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x000207D6 File Offset: 0x0001E9D6
		public void SetSpline(Spline spline)
		{
			Binding.FCE_SplineController_SetSpline(this.m_controllerPtr, spline.Pointer);
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x000207EE File Offset: 0x0001E9EE
		public void ClearSelection()
		{
			Binding.FCE_SplineController_ClearSelection(this.m_controllerPtr);
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x00020800 File Offset: 0x0001EA00
		public bool IsSelected(int index)
		{
			return Binding.FCE_SplineController_IsSelected(this.m_controllerPtr, index);
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x00020813 File Offset: 0x0001EA13
		public void SetSelected(int index, bool selected)
		{
			Binding.FCE_SplineController_SetSelected(this.m_controllerPtr, index, selected);
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x00020827 File Offset: 0x0001EA27
		public void SelectFromScreenRect(Rect rect, float penWidth, SplineController.SelectMode selectMode)
		{
			Binding.FCE_SplineController_SelectFromScreenRect(this.m_controllerPtr, (float)rect.Left, (float)rect.Top, (float)rect.Right, (float)rect.Bottom, penWidth, (int)selectMode);
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x0002085B File Offset: 0x0001EA5B
		public void MoveSelection(Vec2 delta)
		{
			Binding.FCE_SplineController_MoveSelection(this.m_controllerPtr, delta.X, delta.Y);
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0002087B File Offset: 0x0001EA7B
		public void DeleteSelection()
		{
			Binding.FCE_SplineController_DeleteSelection(this.m_controllerPtr);
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060009CF RID: 2511 RVA: 0x0002088D File Offset: 0x0001EA8D
		public IntPtr Pointer
		{
			get
			{
				return this.m_controllerPtr;
			}
		}

		// Token: 0x040004A9 RID: 1193
		public static SplineController Null = new SplineController(IntPtr.Zero);

		// Token: 0x040004AA RID: 1194
		private readonly IntPtr m_controllerPtr;

		// Token: 0x02000119 RID: 281
		public enum SelectMode
		{
			// Token: 0x040004AC RID: 1196
			Replace,
			// Token: 0x040004AD RID: 1197
			Add,
			// Token: 0x040004AE RID: 1198
			Toggle
		}
	}
}

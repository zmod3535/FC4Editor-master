using System;

namespace IGE.Nomad
{
	// Token: 0x020000DA RID: 218
	internal struct PaintBrush
	{
		// Token: 0x060007F1 RID: 2033 RVA: 0x0001B888 File Offset: 0x00019A88
		public PaintBrush(IntPtr ptr)
		{
			this.m_pointer = ptr;
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0001B891 File Offset: 0x00019A91
		public static PaintBrush Create(bool circle, float radius, float hardness, float opacity, float distortion)
		{
			return new PaintBrush(Binding.FCE_Brush_Create(circle, radius, hardness, opacity, distortion));
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0001B8A8 File Offset: 0x00019AA8
		public void Destroy()
		{
			Binding.FCE_Brush_Destroy(this.m_pointer);
			this.m_pointer = IntPtr.Zero;
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060007F4 RID: 2036 RVA: 0x0001B8C5 File Offset: 0x00019AC5
		public bool IsValid
		{
			get
			{
				return this.m_pointer != IntPtr.Zero;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x0001B8D7 File Offset: 0x00019AD7
		public IntPtr Pointer
		{
			get
			{
				return this.m_pointer;
			}
		}

		// Token: 0x040003E6 RID: 998
		private IntPtr m_pointer;
	}
}

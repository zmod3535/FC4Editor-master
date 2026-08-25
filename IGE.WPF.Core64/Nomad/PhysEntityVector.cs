using System;

namespace IGE.Nomad
{
	// Token: 0x02000127 RID: 295
	internal struct PhysEntityVector : IDisposable
	{
		// Token: 0x06000A58 RID: 2648 RVA: 0x00022115 File Offset: 0x00020315
		public static PhysEntityVector Create()
		{
			return new PhysEntityVector(Binding.FCE_PhysEntityVector_Create());
		}

		// Token: 0x06000A59 RID: 2649 RVA: 0x00022126 File Offset: 0x00020326
		public PhysEntityVector(IntPtr ptr)
		{
			this.m_pointer = ptr;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0002212F File Offset: 0x0002032F
		public void Dispose()
		{
			Binding.FCE_PhysEntityVector_Destroy(this.m_pointer);
			this.m_pointer = IntPtr.Zero;
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x0002214C File Offset: 0x0002034C
		public bool IsValid
		{
			get
			{
				return this.m_pointer != IntPtr.Zero;
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x0002215E File Offset: 0x0002035E
		public IntPtr Pointer
		{
			get
			{
				return this.m_pointer;
			}
		}

		// Token: 0x040004F3 RID: 1267
		public static PhysEntityVector Null = default(PhysEntityVector);

		// Token: 0x040004F4 RID: 1268
		private IntPtr m_pointer;
	}
}

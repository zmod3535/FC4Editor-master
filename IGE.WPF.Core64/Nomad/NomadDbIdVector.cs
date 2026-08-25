using System;

namespace IGE.Nomad
{
	// Token: 0x0200001E RID: 30
	internal struct NomadDbIdVector : IDisposable
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x0000322B File Offset: 0x0000142B
		public static NomadDbIdVector Create()
		{
			return new NomadDbIdVector(Binding.FCE_NomadDbIdVector_Create());
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000323C File Offset: 0x0000143C
		public NomadDbIdVector(IntPtr ptr)
		{
			this.m_pointer = ptr;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00003245 File Offset: 0x00001445
		public void Dispose()
		{
			Binding.FCE_NomadDbIdVector_Destroy(this.m_pointer);
			this.m_pointer = IntPtr.Zero;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00003262 File Offset: 0x00001462
		public bool IsValid
		{
			get
			{
				return this.m_pointer != IntPtr.Zero;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00003274 File Offset: 0x00001474
		public IntPtr Pointer
		{
			get
			{
				return this.m_pointer;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000DD RID: 221 RVA: 0x0000327C File Offset: 0x0000147C
		public uint Count
		{
			get
			{
				return Binding.FCE_NomadDbIdVector_GetCount(this.m_pointer);
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000328E File Offset: 0x0000148E
		public ulong GetAt(uint index)
		{
			return Binding.FCE_NomadDbIdVector_GetAt(this.m_pointer, index);
		}

		// Token: 0x0400003E RID: 62
		public static NomadDbIdVector Null = default(NomadDbIdVector);

		// Token: 0x0400003F RID: 63
		private IntPtr m_pointer;
	}
}

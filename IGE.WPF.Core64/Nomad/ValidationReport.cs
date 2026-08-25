using System;

namespace IGE.Nomad
{
	// Token: 0x020000AD RID: 173
	internal struct ValidationReport
	{
		// Token: 0x060006EF RID: 1775 RVA: 0x000193C4 File Offset: 0x000175C4
		public ValidationReport(IntPtr ptr)
		{
			this.m_pointer = ptr;
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x000193CD File Offset: 0x000175CD
		public void Destroy()
		{
			Binding.FCE_ValidationReport_Destroy(this.m_pointer);
			this.m_pointer = IntPtr.Zero;
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x000193EA File Offset: 0x000175EA
		public int Count
		{
			get
			{
				return Binding.FCE_ValidationReport_GetCount(this.m_pointer);
			}
		}

		// Token: 0x17000199 RID: 409
		public ValidationRecord this[int index]
		{
			get
			{
				return new ValidationRecord(Binding.FCE_ValidationReport_GetRecord(this.m_pointer, index));
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x00019414 File Offset: 0x00017614
		public bool IsValid
		{
			get
			{
				return this.m_pointer != IntPtr.Zero;
			}
		}

		// Token: 0x040002BB RID: 699
		public static ValidationReport Null = new ValidationReport(IntPtr.Zero);

		// Token: 0x040002BC RID: 700
		private IntPtr m_pointer;
	}
}

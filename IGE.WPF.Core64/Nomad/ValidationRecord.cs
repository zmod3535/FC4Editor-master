using System;
using System.Runtime.InteropServices;

namespace IGE.Nomad
{
	// Token: 0x020000AE RID: 174
	internal class ValidationRecord
	{
		// Token: 0x060006F5 RID: 1781 RVA: 0x00019437 File Offset: 0x00017637
		public ValidationRecord(IntPtr ptr)
		{
			this.m_pointer = ptr;
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060006F6 RID: 1782 RVA: 0x00019446 File Offset: 0x00017646
		public ValidationRecord.Severities Severity
		{
			get
			{
				return (ValidationRecord.Severities)Binding.FCE_ValidationRecord_GetSeverity(this.m_pointer);
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x00019458 File Offset: 0x00017658
		public ValidationRecord.Flags Flag
		{
			get
			{
				return (ValidationRecord.Flags)Binding.FCE_ValidationRecord_GetFlags(this.m_pointer);
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060006F8 RID: 1784 RVA: 0x0001946A File Offset: 0x0001766A
		public ValidationRecord.Code ErrorCode
		{
			get
			{
				return (ValidationRecord.Code)Binding.FCE_ValidationRecord_GetErrorCode(this.m_pointer);
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060006F9 RID: 1785 RVA: 0x0001947C File Offset: 0x0001767C
		public string Message
		{
			get
			{
				return Marshal.PtrToStringUni(Binding.FCE_ValidationRecord_GetMessage(this.m_pointer));
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x00019493 File Offset: 0x00017693
		public EditorObject Object
		{
			get
			{
				return new EditorObject(Binding.FCE_ValidationRecord_GetObject(this.m_pointer));
			}
		}

		// Token: 0x040002BD RID: 701
		private IntPtr m_pointer;

		// Token: 0x020000AF RID: 175
		[Flags]
		public enum Severities
		{
			// Token: 0x040002BF RID: 703
			Error = 1,
			// Token: 0x040002C0 RID: 704
			Warning = 2,
			// Token: 0x040002C1 RID: 705
			Comment = 4,
			// Token: 0x040002C2 RID: 706
			Success = 8,
			// Token: 0x040002C3 RID: 707
			All = 15,
			// Token: 0x040002C4 RID: 708
			NoSuccess = 7
		}

		// Token: 0x020000B0 RID: 176
		public enum Flags
		{
			// Token: 0x040002C6 RID: 710
			None,
			// Token: 0x040002C7 RID: 711
			Validation = 32
		}

		// Token: 0x020000B1 RID: 177
		public enum Code
		{
			// Token: 0x040002C9 RID: 713
			SUCCESS,
			// Token: 0x040002CA RID: 714
			WAVE1_EMPTY,
			// Token: 0x040002CB RID: 715
			WAVE2_EMPTY,
			// Token: 0x040002CC RID: 716
			MISSING_GAMEPLAY_OBJ,
			// Token: 0x040002CD RID: 717
			MISSING_SNAPSHOT,
			// Token: 0x040002CE RID: 718
			NAVMESH_ERROR
		}
	}
}

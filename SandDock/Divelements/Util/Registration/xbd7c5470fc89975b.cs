using System;
using System.ComponentModel;

namespace Divelements.Util.Registration
{
	// Token: 0x02000007 RID: 7
	internal class xbd7c5470fc89975b : License
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00006930 File Offset: 0x00005930
		internal xbd7c5470fc89975b()
		{
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00006938 File Offset: 0x00005938
		public virtual bool Evaluation
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000693C File Offset: 0x0000593C
		public virtual bool Locked
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00006940 File Offset: 0x00005940
		public override string LicenseKey
		{
			get
			{
				return "This is a licensed component.";
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00006948 File Offset: 0x00005948
		public override void Dispose()
		{
		}
	}
}

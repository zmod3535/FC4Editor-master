using System;
using System.ComponentModel;

namespace Divelements.Util.Registration
{
	// Token: 0x02000007 RID: 7
	internal class xbd7c5470fc89975b : License
	{
		// Token: 0x06000034 RID: 52 RVA: 0x000050F8 File Offset: 0x000040F8
		internal xbd7c5470fc89975b()
		{
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00005100 File Offset: 0x00004100
		public virtual bool Evaluation
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00005104 File Offset: 0x00004104
		public virtual bool Locked
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00005108 File Offset: 0x00004108
		public override string LicenseKey
		{
			get
			{
				return "This is a licensed component.";
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00005110 File Offset: 0x00004110
		public override void Dispose()
		{
		}
	}
}

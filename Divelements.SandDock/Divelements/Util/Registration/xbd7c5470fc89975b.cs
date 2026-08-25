using System;
using System.ComponentModel;

namespace Divelements.Util.Registration
{
	// Token: 0x02000004 RID: 4
	internal class xbd7c5470fc89975b : License
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00030E58 File Offset: 0x0002F258
		internal xbd7c5470fc89975b()
		{
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00030E60 File Offset: 0x0002F260
		public virtual bool Evaluation
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00030E64 File Offset: 0x0002F264
		public virtual bool Locked
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00030E68 File Offset: 0x0002F268
		public override string LicenseKey
		{
			get
			{
				return "This is a licensed component.";
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00030E70 File Offset: 0x0002F270
		public override void Dispose()
		{
		}
	}
}

using System;

namespace Divelements.SandGrid
{
	// Token: 0x0200006E RID: 110
	public class NameValuePair
	{
		// Token: 0x0600061A RID: 1562 RVA: 0x0001FF58 File Offset: 0x0001EF58
		public NameValuePair(object name, object value)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			this.xc15bd84e01929885 = name;
			this.xbcea506a33cf9111 = value;
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x0001FF8C File Offset: 0x0001EF8C
		public object Name
		{
			get
			{
				return this.xc15bd84e01929885;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600061C RID: 1564 RVA: 0x0001FF94 File Offset: 0x0001EF94
		public object Value
		{
			get
			{
				return this.xbcea506a33cf9111;
			}
		}

		// Token: 0x0400024C RID: 588
		private object xc15bd84e01929885;

		// Token: 0x0400024D RID: 589
		private object xbcea506a33cf9111;
	}
}

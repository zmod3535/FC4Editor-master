using System;

namespace IGE.Parameters
{
	// Token: 0x0200038D RID: 909
	internal class ParamEnumText : ParamEnumBase.Entry
	{
		// Token: 0x0600147F RID: 5247 RVA: 0x0002BA32 File Offset: 0x00029C32
		public ParamEnumText(string display, object value) : base(display, value)
		{
		}

		// Token: 0x06001480 RID: 5248 RVA: 0x0002BA3C File Offset: 0x00029C3C
		public ParamEnumText(object value) : base(value.ToString(), value)
		{
		}
	}
}

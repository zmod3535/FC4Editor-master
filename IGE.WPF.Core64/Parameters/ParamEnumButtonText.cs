using System;

namespace IGE.Parameters
{
	// Token: 0x0200038E RID: 910
	internal class ParamEnumButtonText : ParamEnumBase.Entry
	{
		// Token: 0x06001481 RID: 5249 RVA: 0x0002BA4B File Offset: 0x00029C4B
		public ParamEnumButtonText(string display, object value) : base(display, value)
		{
		}

		// Token: 0x06001482 RID: 5250 RVA: 0x0002BA55 File Offset: 0x00029C55
		public ParamEnumButtonText(object value) : this(value.ToString(), value)
		{
		}
	}
}

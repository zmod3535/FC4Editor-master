using System;

namespace IGE.Parameters
{
	// Token: 0x020000C1 RID: 193
	internal class ParamBool : ValueParameter<bool>
	{
		// Token: 0x06000755 RID: 1877 RVA: 0x0001AA83 File Offset: 0x00018C83
		public ParamBool(string display, ValueParameter<bool>.ValueChangedDelegate evt = null) : base(display, evt)
		{
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0001AA8D File Offset: 0x00018C8D
		public ParamBool(string display, bool value) : base(display, value)
		{
		}
	}
}

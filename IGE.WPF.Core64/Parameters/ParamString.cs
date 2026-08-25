using System;

namespace IGE.Parameters
{
	// Token: 0x02000099 RID: 153
	internal class ParamString : ValueParameter<string>
	{
		// Token: 0x06000665 RID: 1637 RVA: 0x00016882 File Offset: 0x00014A82
		public ParamString(string display, ValueParameter<string>.ValueChangedDelegate evt = null) : base(display, evt)
		{
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0001688C File Offset: 0x00014A8C
		public ParamString(string display, string value) : base(display, value)
		{
		}
	}
}

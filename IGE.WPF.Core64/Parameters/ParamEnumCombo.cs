using System;
using System.Collections.Generic;

namespace IGE.Parameters
{
	// Token: 0x02000012 RID: 18
	internal class ParamEnumCombo : ParamEnumBase
	{
		// Token: 0x06000066 RID: 102 RVA: 0x0000299F File Offset: 0x00000B9F
		public ParamEnumCombo(string display, IEnumerable<ParamEnumBase.Entry> values) : base(display, values)
		{
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000029A9 File Offset: 0x00000BA9
		public ParamEnumCombo(string display, IEnumerable<ParamEnumBase.Entry> values, ParamEnumBase.ValueChangedDelegate del) : base(display, values, del)
		{
		}
	}
}

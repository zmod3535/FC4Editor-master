using System;

namespace IGE.Parameters
{
	// Token: 0x02000389 RID: 905
	internal class ParamTime : ValueParameter<TimeSpan>
	{
		// Token: 0x0600146F RID: 5231 RVA: 0x0002B929 File Offset: 0x00029B29
		public ParamTime(string display, ValueParameter<TimeSpan>.ValueChangedDelegate evt = null) : base(display, evt)
		{
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06001470 RID: 5232 RVA: 0x0002B934 File Offset: 0x00029B34
		// (set) Token: 0x06001471 RID: 5233 RVA: 0x0002B95C File Offset: 0x00029B5C
		public double SliderValue
		{
			get
			{
				return base.Value.TotalSeconds / 3600.0;
			}
			set
			{
				int seconds = (int)(value * 3600.0);
				base.Value = new TimeSpan(0, 0, seconds);
			}
		}
	}
}

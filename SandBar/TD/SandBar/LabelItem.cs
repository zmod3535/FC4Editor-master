using System;
using System.ComponentModel;

namespace TD.SandBar
{
	// Token: 0x02000049 RID: 73
	public class LabelItem : ImageItemBase
	{
		// Token: 0x060003BA RID: 954 RVA: 0x00013124 File Offset: 0x00012124
		public LabelItem()
		{
			this.Text = "Label";
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060003BB RID: 955 RVA: 0x00013138 File Offset: 0x00012138
		// (set) Token: 0x060003BC RID: 956 RVA: 0x00013140 File Offset: 0x00012140
		[DefaultValue("Label")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}
	}
}

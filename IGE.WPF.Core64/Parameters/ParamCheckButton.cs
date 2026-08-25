using System;

namespace IGE.Parameters
{
	// Token: 0x0200009A RID: 154
	internal class ParamCheckButton : ValueParameter<bool>
	{
		// Token: 0x06000667 RID: 1639 RVA: 0x00016896 File Offset: 0x00014A96
		public ParamCheckButton(string display) : base(display, null)
		{
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x000168A0 File Offset: 0x00014AA0
		public ParamCheckButton(string display, bool value) : base(display, value)
		{
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x000168AA File Offset: 0x00014AAA
		// (set) Token: 0x0600066A RID: 1642 RVA: 0x000168B2 File Offset: 0x00014AB2
		public bool IsChecked
		{
			get
			{
				return base.Value;
			}
			set
			{
				base.Value = value;
			}
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x000168E8 File Offset: 0x00014AE8
		public ParamCheckButton(string display, ParamCheckButton.CheckedDelegate check = null, ParamCheckButton.CheckedDelegate uncheck = null) : base(display, null)
		{
			this.Checked = check;
			this.Unchecked = uncheck;
			base.ValueChanged = (ValueParameter<bool>.ValueChangedDelegate)Delegate.Combine(base.ValueChanged, new ValueParameter<bool>.ValueChangedDelegate(delegate(bool value)
			{
				ParamCheckButton.CheckedDelegate checkedDelegate = value ? this.Checked : this.Unchecked;
				if (checkedDelegate == null)
				{
					return;
				}
				checkedDelegate();
			}));
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x00016934 File Offset: 0x00014B34
		// (set) Token: 0x0600066D RID: 1645 RVA: 0x0001693C File Offset: 0x00014B3C
		public ParamCheckButton.CheckedDelegate Checked { get; set; }

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x00016945 File Offset: 0x00014B45
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x0001694D File Offset: 0x00014B4D
		public ParamCheckButton.CheckedDelegate Unchecked { get; set; }

		// Token: 0x0200009B RID: 155
		// (Invoke) Token: 0x06000672 RID: 1650
		public delegate void CheckedDelegate();
	}
}

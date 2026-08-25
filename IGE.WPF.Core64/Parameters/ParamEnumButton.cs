using System;
using System.Collections.Generic;

namespace IGE.Parameters
{
	// Token: 0x02000013 RID: 19
	internal class ParamEnumButton : ParamEnumBase
	{
		// Token: 0x06000068 RID: 104 RVA: 0x000029C4 File Offset: 0x00000BC4
		public ParamEnumButton(string display, IList<ParamEnumBase.Entry> values) : base(display, values)
		{
			foreach (ParamEnumBase.Entry entry in values)
			{
				entry.Activate += delegate(object s, EventArgs ea)
				{
					this.ActivateButton((ParamEnumBase.Entry)s);
				};
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002A28 File Offset: 0x00000C28
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00002A30 File Offset: 0x00000C30
		public new bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
				if (!value || base.SelectedItem == null)
				{
					return;
				}
				base.SelectedItem.IsActive = false;
				this.ActivateButton(base.SelectedItem);
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002A6C File Offset: 0x00000C6C
		public ParamEnumButton(string display, IList<ParamEnumBase.Entry> values, ParamEnumBase.ValueChangedDelegate del) : base(display, values, del)
		{
			foreach (ParamEnumBase.Entry entry in values)
			{
				entry.Activate += delegate(object s, EventArgs ea)
				{
					this.ActivateButton((ParamEnumBase.Entry)s);
				};
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002AD0 File Offset: 0x00000CD0
		public void Reset()
		{
			for (int i = 0; i < base.Values.Count; i++)
			{
				ParamEnumBase.Entry entry = base.Values[i];
				entry.IsActive = false;
			}
			base.SelectedIndex = -1;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002B10 File Offset: 0x00000D10
		private void ActivateButton(ParamEnumBase.Entry sender)
		{
			if (sender != null)
			{
				sender.IsActive = true;
			}
			for (int i = 0; i < base.Values.Count; i++)
			{
				ParamEnumBase.Entry entry = base.Values[i];
				if (entry != sender)
				{
					entry.IsActive = false;
				}
				else
				{
					base.SelectedIndex = i;
				}
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002B5E File Offset: 0x00000D5E
		protected override void RaiseValueChanged()
		{
			this.ActivateButton(base.SelectedItem);
			base.RaiseValueChanged();
		}
	}
}

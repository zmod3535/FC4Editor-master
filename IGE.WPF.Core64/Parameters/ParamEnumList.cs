using System;
using System.Collections.Generic;

namespace IGE.Parameters
{
	// Token: 0x02000010 RID: 16
	internal class ParamEnumList : ParamEnumBase
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600005D RID: 93 RVA: 0x000028F0 File Offset: 0x00000AF0
		// (remove) Token: 0x0600005E RID: 94 RVA: 0x00002928 File Offset: 0x00000B28
		public event ParamEnumList.SelectionDoubleClickHandle OnItemDoubleClicked;

		// Token: 0x0600005F RID: 95 RVA: 0x0000295D File Offset: 0x00000B5D
		public ParamEnumList(string display, IEnumerable<ParamEnumBase.Entry> values) : base(display, values)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00002967 File Offset: 0x00000B67
		public ParamEnumList(string display, IEnumerable<ParamEnumBase.Entry> values, ParamEnumBase.ValueChangedDelegate del) : base(display, values, del)
		{
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00002974 File Offset: 0x00000B74
		public void SelectionDoubleClicked()
		{
			ParamEnumBase.Entry selectedItem = base.SelectedItem;
			if (selectedItem != null && this.OnItemDoubleClicked != null)
			{
				this.OnItemDoubleClicked(selectedItem);
			}
		}

		// Token: 0x02000011 RID: 17
		// (Invoke) Token: 0x06000063 RID: 99
		public delegate void SelectionDoubleClickHandle(object selection);
	}
}

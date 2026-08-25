using System;
using Ubisoft.AttachedCommandBehavior;

namespace IGE.Parameters
{
	// Token: 0x0200038B RID: 907
	internal class ParamTextEdit : ParamText
	{
		// Token: 0x06001477 RID: 5239 RVA: 0x0002B9C8 File Offset: 0x00029BC8
		public ParamTextEdit(string display, string button) : base(display)
		{
			this.ButtonName = button;
			this.ButtonCommand = new SimpleCommand();
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06001478 RID: 5240 RVA: 0x0002B9E3 File Offset: 0x00029BE3
		// (set) Token: 0x06001479 RID: 5241 RVA: 0x0002B9EB File Offset: 0x00029BEB
		public string ButtonName { get; private set; }

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x0600147A RID: 5242 RVA: 0x0002B9F4 File Offset: 0x00029BF4
		// (set) Token: 0x0600147B RID: 5243 RVA: 0x0002B9FC File Offset: 0x00029BFC
		public SimpleCommand ButtonCommand { get; set; }
	}
}

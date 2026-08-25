using System;
using Ubisoft.AttachedCommandBehavior;

namespace IGE.Parameters
{
	// Token: 0x0200006F RID: 111
	internal class ParamButton : SingleParameter
	{
		// Token: 0x06000494 RID: 1172 RVA: 0x00011F9D File Offset: 0x0001019D
		public ParamButton(string display) : base(display)
		{
			this.ButtonCommand = new SimpleCommand();
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x00011FB1 File Offset: 0x000101B1
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x00011FB9 File Offset: 0x000101B9
		public SimpleCommand ButtonCommand { get; set; }
	}
}

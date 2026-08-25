using System;

namespace Divelements.SandGrid
{
	// Token: 0x0200007E RID: 126
	[Flags]
	public enum KeyboardEditMode
	{
		// Token: 0x04000277 RID: 631
		None = 0,
		// Token: 0x04000278 RID: 632
		EditOnKeystroke = 1,
		// Token: 0x04000279 RID: 633
		EditOnF2 = 2,
		// Token: 0x0400027A RID: 634
		EditOnKeystrokeOrF2 = 3
	}
}

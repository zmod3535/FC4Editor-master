using System;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x0200003D RID: 61
	[Flags]
	public enum DrawItemState
	{
		// Token: 0x0400019E RID: 414
		None = 0,
		// Token: 0x0400019F RID: 415
		Selected = 1,
		// Token: 0x040001A0 RID: 416
		Hot = 2,
		// Token: 0x040001A1 RID: 417
		Pushed = 4
	}
}

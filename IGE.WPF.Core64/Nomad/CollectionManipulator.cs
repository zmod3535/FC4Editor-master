using System;

namespace IGE.Nomad
{
	// Token: 0x02000037 RID: 55
	internal class CollectionManipulator
	{
		// Token: 0x060002B2 RID: 690 RVA: 0x0000856F File Offset: 0x0000676F
		public static void Paint(Vec2 center, int id, PaintBrush brush)
		{
			Binding.FCE_Collection_Paint(center.X, center.Y, id, brush.Pointer);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00008591 File Offset: 0x00006791
		public static void Paint_End()
		{
			Binding.FCE_Collection_Paint_End();
		}
	}
}

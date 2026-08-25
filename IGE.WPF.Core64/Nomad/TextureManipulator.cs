using System;

namespace IGE.Nomad
{
	// Token: 0x020000AA RID: 170
	internal class TextureManipulator
	{
		// Token: 0x060006E1 RID: 1761 RVA: 0x00019232 File Offset: 0x00017432
		public static void Paint(Vec2 center, float amount, int id, PaintBrush brush)
		{
			Binding.FCE_Texture_Paint(center.X, center.Y, amount, id, brush.Pointer);
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00019255 File Offset: 0x00017455
		public static void Paint_End()
		{
			Binding.FCE_Texture_Paint_End();
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00019261 File Offset: 0x00017461
		public static void PaintConstraints_Begin(float minHeight, float maxHeight, float heightFuzziness, float minSlope, float maxSlope)
		{
			Binding.FCE_Texture_PaintConstraints_Begin(minHeight, maxHeight, heightFuzziness, minSlope, maxSlope);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00019273 File Offset: 0x00017473
		public static void PaintConstraints(Vec2 center, float amount, int id, PaintBrush brush)
		{
			Binding.FCE_Texture_PaintConstraints(center.X, center.Y, amount, id, brush.Pointer);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00019296 File Offset: 0x00017496
		public static void PaintConstraints_End()
		{
			Binding.FCE_Texture_PaintConstraints_End();
		}
	}
}

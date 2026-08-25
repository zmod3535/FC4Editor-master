using System;

namespace IGE.Nomad
{
	// Token: 0x0200004B RID: 75
	internal class TerrainManipulator
	{
		// Token: 0x0600032E RID: 814 RVA: 0x00009A34 File Offset: 0x00007C34
		public static void Bump(Vec2 center, float amount, PaintBrush brush)
		{
			Binding.FCE_Terrain_Bump(center.X, center.Y, amount, brush.Pointer);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00009A56 File Offset: 0x00007C56
		public static void Bump_End()
		{
			Binding.FCE_Terrain_Bump_End();
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00009A62 File Offset: 0x00007C62
		public static void RaiseLower(Vec2 center, float amount, PaintBrush brush)
		{
			Binding.FCE_Terrain_RaiseLower(center.X, center.Y, amount, brush.Pointer);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00009A84 File Offset: 0x00007C84
		public static void RaiseLower_End()
		{
			Binding.FCE_Terrain_RaiseLower_End();
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00009A90 File Offset: 0x00007C90
		public static void SetHeight(Vec2 center, float height, PaintBrush brush)
		{
			Binding.FCE_Terrain_SetHeight(center.X, center.Y, height, brush.Pointer);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00009AB2 File Offset: 0x00007CB2
		public static void SetHeight_End()
		{
			Binding.FCE_Terrain_SetHeight_End();
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00009ABE File Offset: 0x00007CBE
		public static float GetAverageHeight(Vec2 center, PaintBrush brush)
		{
			return Binding.FCE_Terrain_GetAverageHeight(center.X, center.Y, brush.Pointer);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00009ADF File Offset: 0x00007CDF
		public static void Average(Vec2 center, PaintBrush brush)
		{
			Binding.FCE_Terrain_Average(center.X, center.Y, brush.Pointer);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00009B00 File Offset: 0x00007D00
		public static void Average_End()
		{
			Binding.FCE_Terrain_Average_End();
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00009B0C File Offset: 0x00007D0C
		public static void Grab_Begin(float x, float y, PaintBrush brush)
		{
			Binding.FCE_Terrain_Grab_Begin(x, y, brush.Pointer);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00009B21 File Offset: 0x00007D21
		public static void Grab(float ratio)
		{
			Binding.FCE_Terrain_Grab(ratio);
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00009B2E File Offset: 0x00007D2E
		public static void Grab_End()
		{
			Binding.FCE_Terrain_Grab_End();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00009B3A File Offset: 0x00007D3A
		public static void Smooth(Vec2 center, PaintBrush brush)
		{
			Binding.FCE_Terrain_Smooth(center.X, center.Y, brush.Pointer);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00009B5B File Offset: 0x00007D5B
		public static void Smooth_End()
		{
			Binding.FCE_Terrain_Smooth_End();
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00009B67 File Offset: 0x00007D67
		public static void Ramp(Vec2 ptStart, Vec2 ptEnd, float radius, float hardness)
		{
			Binding.FCE_Terrain_Ramp(ptStart.X, ptStart.Y, ptEnd.X, ptEnd.Y, radius, hardness);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00009B91 File Offset: 0x00007D91
		public static void Terrace(Vec2 center, float height, float falloff, PaintBrush brush)
		{
			Binding.FCE_Terrain_Terrace(center.X, center.Y, height, falloff, brush.Pointer);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00009BB4 File Offset: 0x00007DB4
		public static void Terrace_End()
		{
			Binding.FCE_Terrain_Terrace_End();
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00009BC0 File Offset: 0x00007DC0
		public static void Noise_Begin(int numOctaves, float noiseSize, float persistence, TerrainManipulator.NoiseType noiseType)
		{
			Binding.FCE_Terrain_Noise_Begin(numOctaves, noiseSize, persistence, (int)noiseType);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00009BD0 File Offset: 0x00007DD0
		public static void Noise(Vec2 center, float amount, PaintBrush brush)
		{
			Binding.FCE_Terrain_Noise(center.X, center.Y, amount, brush.Pointer);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00009BF2 File Offset: 0x00007DF2
		public static void Noise_End()
		{
			Binding.FCE_Terrain_Noise_End();
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00009BFE File Offset: 0x00007DFE
		public static void Erosion(Vec2 center, float radius, float density, float deformation, float channelDepth, float randomness)
		{
			Binding.FCE_Terrain_Erosion(center.X, center.Y, radius, density, deformation, channelDepth, randomness);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00009C1F File Offset: 0x00007E1F
		public static void Erosion_End()
		{
			Binding.FCE_Terrain_Erosion_End();
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00009C2B File Offset: 0x00007E2B
		public static void Hole(Win32.Rect rect, bool hole)
		{
			Binding.FCE_Terrain_Hole(rect.left, rect.top, rect.right, rect.bottom, hole);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00009C54 File Offset: 0x00007E54
		public static void Hole_End()
		{
			Binding.FCE_Terrain_Hole_End();
		}

		// Token: 0x0200004C RID: 76
		public enum NoiseType
		{
			// Token: 0x04000155 RID: 341
			Normal,
			// Token: 0x04000156 RID: 342
			Absolute,
			// Token: 0x04000157 RID: 343
			InverseAbsolute
		}
	}
}

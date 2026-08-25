using System;
using System.Windows;
using System.Windows.Media;

namespace IGE.Nomad
{
	// Token: 0x02000034 RID: 52
	internal class Render
	{
		// Token: 0x0600028C RID: 652 RVA: 0x00007A67 File Offset: 0x00005C67
		public static void BeginGroup()
		{
			Binding.FCE_Draw_BeginGroup();
		}

		// Token: 0x0600028D RID: 653 RVA: 0x00007A73 File Offset: 0x00005C73
		public static void EndGroup()
		{
			Binding.FCE_Draw_EndGroup();
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00007A80 File Offset: 0x00005C80
		public static void DrawScreenCircleOutlined(Vec2 center, float z, float radius, float penWidth, Color color)
		{
			Binding.FCE_Draw_ScreenCircleOutlined(center.X, center.Y, z, radius, penWidth, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00007AE0 File Offset: 0x00005CE0
		public static void DrawScreenRectangleOutlined(Rect rect, float z, float penWidth, Color color)
		{
			Size size = rect.Size;
			Vec2 vec = new Vec2(rect.X + size.Width / 2.0, rect.Y + size.Height / 2.0);
			Binding.FCE_Draw_ScreenRectangleOutlined(vec.X, vec.Y, z, (float)size.Width, (float)size.Height, penWidth, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x00007B90 File Offset: 0x00005D90
		public static void DrawQuad(Vec3 center, float width, float height, Color color)
		{
			Binding.FCE_Draw_Quad(center.X, center.Y, center.Z, width, height, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00007BF8 File Offset: 0x00005DF8
		public static void DrawSquare(Vec3 center, float radius, float penWidth, Color color, float zOrder, Color borderColor)
		{
			Binding.FCE_Draw_Square(center.X, center.Y, center.Z, radius, penWidth, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f, zOrder, (float)borderColor.R / 255f, (float)borderColor.G / 255f, (float)borderColor.B / 255f, (float)borderColor.A / 255f);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00007C98 File Offset: 0x00005E98
		public static void DrawTerrainCircle(Vec2 center, float radius, float penWidth, Color color, float zOrder, float zOffset)
		{
			Render.DrawTerrainCircle(center, radius, penWidth, color, zOrder, zOffset, Colors.Black);
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00007CAC File Offset: 0x00005EAC
		public static void DrawTerrainCircle(Vec2 center, float radius, float penWidth, Color color, float zOrder, float zOffset, Color borderColor)
		{
			Binding.FCE_Draw_Terrain_Circle(center.X, center.Y, radius, penWidth, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f, zOrder, zOffset, (float)borderColor.R / 255f, (float)borderColor.G / 255f, (float)borderColor.B / 255f, (float)borderColor.A / 255f);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00007D47 File Offset: 0x00005F47
		public static void DrawTerrainSquare(Vec2 center, float radius, float penWidth, Color color, float zOrder, float zOffset)
		{
			Render.DrawTerrainSquare(center, radius, penWidth, color, zOrder, zOffset, Colors.Black);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00007D5C File Offset: 0x00005F5C
		public static void DrawTerrainSquare(Vec2 center, float radius, float penWidth, Color color, float zOrder, float zOffset, Color borderColor)
		{
			Binding.FCE_Draw_Terrain_Square(center.X, center.Y, radius, penWidth, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f, zOrder, zOffset, (float)borderColor.R / 255f, (float)borderColor.G / 255f, (float)borderColor.B / 255f, (float)borderColor.A / 255f);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00007DF8 File Offset: 0x00005FF8
		public static void DrawArrow(Vec3 center, Vec3 direction, float length, float radius, float headLength, float headRadius, Color color)
		{
			Binding.FCE_Draw_Arrow(center.X, center.Y, center.Z, direction.X, direction.Y, direction.Z, length, radius, headLength, headRadius, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00007E78 File Offset: 0x00006078
		public static void DrawDot(Vec3 center, float radius, Color color, bool back, bool startGroup)
		{
			Binding.FCE_Draw_Dot(center.X, center.Y, center.Z, radius, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, back, startGroup);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00007ED4 File Offset: 0x000060D4
		public static void DrawSegmentedLineSegment(Vec3 p1, Vec3 p2, float penRadius, float penRadius2, Color color, bool back)
		{
			Binding.FCE_Draw_SegmentedLineSegment(p1.X, p1.Y, p1.Z, p2.X, p2.Y, p2.Z, penRadius, penRadius2, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, back);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00007F43 File Offset: 0x00006143
		public static void DrawWireBoxFromBottomZ(Vec3 pos, Vec3 size, float penWidth)
		{
			Binding.FCE_Draw_WireBoxFromBottomZ(pos.X, pos.Y, pos.Z, size.X, size.Y, size.Z, penWidth);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00007F7A File Offset: 0x0000617A
		public static void DrawWireRegionFromTerrain(Points points, float penWidth, Color color)
		{
			Binding.FCE_Draw_WireRegionFromTerrain(points.Pointer, penWidth, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f);
		}
	}
}

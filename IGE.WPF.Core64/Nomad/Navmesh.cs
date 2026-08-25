using System;

namespace IGE.Nomad
{
	// Token: 0x0200010B RID: 267
	internal class Navmesh
	{
		// Token: 0x06000942 RID: 2370 RVA: 0x0001EEF9 File Offset: 0x0001D0F9
		public static void Show(Navmesh.Layer layer)
		{
			Binding.FCE_Navmesh_SetDisplay((int)(layer + 1));
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x0001EF08 File Offset: 0x0001D108
		public static void Hide()
		{
			Binding.FCE_Navmesh_SetDisplay(0);
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x0001EF15 File Offset: 0x0001D115
		public static void RegenerateTileAt(Vec2 pos, bool debugMode)
		{
			Binding.FCE_Navmesh_RegenerateTileAt(pos.X, pos.Y, debugMode);
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x0001EF30 File Offset: 0x0001D130
		public static void ShowActionPoints()
		{
			Binding.FCE_Navmesh_SetAPDisplay(1);
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x0001EF3D File Offset: 0x0001D13D
		public static void HideActionPoints()
		{
			Binding.FCE_Navmesh_SetAPDisplay(0);
		}

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x0001EF4A File Offset: 0x0001D14A
		// (set) Token: 0x06000948 RID: 2376 RVA: 0x0001EF56 File Offset: 0x0001D156
		public static float DebugAlpha
		{
			get
			{
				return Binding.FCE_Navmesh_GetDebugAlpha();
			}
			set
			{
				Binding.FCE_Navmesh_SetDebugAlpha(value);
			}
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x0001EF63 File Offset: 0x0001D163
		public static int PendingTilesCount
		{
			get
			{
				return Binding.FCE_Navmesh_GetPendingTilesCount();
			}
		}

		// Token: 0x0200010C RID: 268
		public enum Layer
		{
			// Token: 0x0400047A RID: 1146
			Character,
			// Token: 0x0400047B RID: 1147
			Vehicle
		}
	}
}

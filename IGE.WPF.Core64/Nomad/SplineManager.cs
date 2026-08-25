using System;

namespace IGE.Nomad
{
	// Token: 0x02000068 RID: 104
	internal static class SplineManager
	{
		// Token: 0x06000475 RID: 1141 RVA: 0x00011A23 File Offset: 0x0000FC23
		public static SplineRoad CreateRoad(int id)
		{
			return new SplineRoad(Binding.FCE_SplineManager_CreateRoad(id));
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00011A35 File Offset: 0x0000FC35
		public static void DestroyRoad(int id)
		{
			Binding.FCE_SplineManager_DestroyRoad(id);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00011A42 File Offset: 0x0000FC42
		public static SplineRoad GetRoadFromId(int id)
		{
			return new SplineRoad(Binding.FCE_SplineManager_GetRoadFromId(id));
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00011A54 File Offset: 0x0000FC54
		public static SplineZone GetPlayableZone()
		{
			return new SplineZone(Binding.FCE_SplineManager_GetPlayableZone());
		}

		// Token: 0x040001FA RID: 506
		public const int MaxRoads = 8;
	}
}

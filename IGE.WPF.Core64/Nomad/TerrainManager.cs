using System;

namespace IGE.Nomad
{
	// Token: 0x02000033 RID: 51
	internal static class TerrainManager
	{
		// Token: 0x0600027F RID: 639 RVA: 0x00007985 File Offset: 0x00005B85
		public static float GetHeightAt(Vec2 point)
		{
			return Binding.FCE_TerrainManager_GetHeightAt(point.X, point.Y);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000799F File Offset: 0x00005B9F
		public static float GetHeightAtWithWater(Vec2 point)
		{
			return Binding.FCE_TerrainManager_GetHeightAtWithWater(point.X, point.Y);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x000079B9 File Offset: 0x00005BB9
		public static TextureInventory.Entry GetTextureEntryFromId(int id)
		{
			return new TextureInventory.Entry(Binding.FCE_TerrainManager_GetTextureEntryFromId(id));
		}

		// Token: 0x06000282 RID: 642 RVA: 0x000079CB File Offset: 0x00005BCB
		public static void AssignTextureId(int id, TextureInventory.Entry entry)
		{
			Binding.FCE_TerrainManager_AssignTextureId(id, entry.Pointer);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x000079DE File Offset: 0x00005BDE
		public static void ClearTextureId(int id)
		{
			Binding.FCE_TerrainManager_ClearTextureId(id);
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000284 RID: 644 RVA: 0x000079EB File Offset: 0x00005BEB
		// (set) Token: 0x06000285 RID: 645 RVA: 0x000079F7 File Offset: 0x00005BF7
		public static float GlobalWaterLevel
		{
			get
			{
				return Binding.FCE_TerrainManager_GetGlobalWaterLevel();
			}
			set
			{
				Binding.FCE_TerrainManager_SetGlobalWaterLevel(value);
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x00007A04 File Offset: 0x00005C04
		public static void SetWaterLevelSector(int sx, int sy, float waterLevel, WaterInventory.Entry entry)
		{
			Binding.FCE_TerrainManager_SetWaterLevelSector(sx, sy, waterLevel, (entry != null) ? entry.Pointer : IntPtr.Zero);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00007A29 File Offset: 0x00005C29
		public static void UpdateWaterLevel()
		{
			Binding.FCE_TerrainManager_UpdateWaterLevel();
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00007A35 File Offset: 0x00005C35
		public static int GetLogicZoneId()
		{
			return Binding.FCE_TerrainManager_GetLogicZoneId();
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00007A41 File Offset: 0x00005C41
		public static void SetLogicZoneId(int id)
		{
			Binding.FCE_TerrainManager_SetLogicZoneId(id);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00007A4E File Offset: 0x00005C4E
		public static int GetSoundRegionId()
		{
			return Binding.FCE_TerrainManager_GetSoundRegionId();
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00007A5A File Offset: 0x00005C5A
		public static void SetSoundRegionId(int id)
		{
			Binding.FCE_TerrainManager_SetSoundRegionId(id);
		}
	}
}

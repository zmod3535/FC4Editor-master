using System;
using System.Collections.Generic;

namespace IGE.Nomad
{
	// Token: 0x020000BE RID: 190
	internal static class MapTags
	{
		// Token: 0x0600073A RID: 1850 RVA: 0x0001A318 File Offset: 0x00018518
		public static void Initialize()
		{
			MapTags.MapTagDictionary = new Dictionary<ulong, MapTag>();
			NomadDbIdVector nomadDbIdVector = NomadDbIdVector.Create();
			if (nomadDbIdVector.IsValid)
			{
				Binding.FCE_MapTag_GetAllDbIds(nomadDbIdVector.Pointer);
				uint count = nomadDbIdVector.Count;
				for (uint num = 0U; num < count; num += 1U)
				{
					ulong at = nomadDbIdVector.GetAt(num);
					List<ulong> list = new List<ulong>();
					NomadDbIdVector nomadDbIdVector2 = NomadDbIdVector.Create();
					if (nomadDbIdVector2.IsValid)
					{
						Binding.FCE_MapTag_GetAvailableGameModes(at, nomadDbIdVector2.Pointer);
						for (uint num2 = 0U; num2 < nomadDbIdVector2.Count; num2 += 1U)
						{
							list.Add(nomadDbIdVector2.GetAt(num2));
						}
						nomadDbIdVector2.Dispose();
					}
					List<ulong> list2 = new List<ulong>();
					NomadDbIdVector nomadDbIdVector3 = NomadDbIdVector.Create();
					if (nomadDbIdVector3.IsValid)
					{
						Binding.FCE_MapTag_GetModifierRefs(at, nomadDbIdVector3.Pointer);
						for (uint num3 = 0U; num3 < nomadDbIdVector3.Count; num3 += 1U)
						{
							list2.Add(nomadDbIdVector3.GetAt(num3));
						}
						nomadDbIdVector3.Dispose();
					}
					List<ulong> list3 = new List<ulong>();
					NomadDbIdVector nomadDbIdVector4 = NomadDbIdVector.Create();
					if (nomadDbIdVector4.IsValid)
					{
						Binding.FCE_MapTag_GetPresetRefs(at, nomadDbIdVector4.Pointer);
						for (uint num4 = 0U; num4 < nomadDbIdVector4.Count; num4 += 1U)
						{
							list3.Add(nomadDbIdVector4.GetAt(num4));
						}
						nomadDbIdVector4.Dispose();
					}
					MapTag mapTag = new MapTag(at, MapTags.GetMapTagName(at), MapTags.GetObjectiveRefId(at), list2, list, list3, MapTags.GetAutoFlag(at), MapTags.GetEnumFlag(at), MapTags.GetEnumDefaultFlag(at), MapTags.GetPriority(at));
					MapTags.MapTagDictionary.Add(at, mapTag);
					if (mapTag.IsEnum && mapTag.IsEnumDefault)
					{
						MapTags.DefaultEnumMapTag = mapTag;
					}
				}
				nomadDbIdVector.Dispose();
			}
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0001A4D8 File Offset: 0x000186D8
		public static List<MapTag> GetEnumMapTags()
		{
			List<MapTag> list = new List<MapTag>();
			foreach (MapTag mapTag in MapTags.MapTagDictionary.Values)
			{
				if (mapTag.IsEnum)
				{
					list.Add(mapTag);
				}
			}
			return list;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0001A540 File Offset: 0x00018740
		public static List<MapTag> GetAutoMapTags()
		{
			List<MapTag> list = new List<MapTag>();
			ulong currentObjectiveType = GameModeManager.GetCurrentObjectiveType();
			foreach (MapTag mapTag in MapTags.MapTagDictionary.Values)
			{
				if (mapTag.IsAuto && !mapTag.IsEnum)
				{
					foreach (GameProperty gameProperty in mapTag.ModifierRefs)
					{
						if (gameProperty != null && gameProperty.ValueType == EPropertyValueType.EPropertyValueType_Bool && gameProperty.CurrentValueBool)
						{
							list.Add(mapTag);
							break;
						}
						if (gameProperty != null && gameProperty.ValueType == EPropertyValueType.EPropertyValueType_Preset && mapTag.PresetIds.Contains(gameProperty.CurrentValuePreset))
						{
							list.Add(mapTag);
							break;
						}
					}
					if (mapTag.Objective != null && mapTag.Objective.Id == currentObjectiveType)
					{
						list.Add(mapTag);
					}
				}
			}
			return list;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0001A658 File Offset: 0x00018858
		public static List<MapTag> GetUserMapTags()
		{
			List<MapTag> list = new List<MapTag>();
			ulong value = 0UL;
			ulong currentObjectiveType = GameModeManager.GetCurrentObjectiveType();
			if (GameModeManager.ObjectiveTypes.ContainsKey(currentObjectiveType))
			{
				ObjectiveType objectiveType = GameModeManager.ObjectiveTypes[currentObjectiveType];
				value = objectiveType.GameMode.Id;
			}
			foreach (MapTag mapTag in MapTags.MapTagDictionary.Values)
			{
				if (!mapTag.IsAuto && !mapTag.IsEnum)
				{
					if (mapTag.GameModes.Count == 0)
					{
						list.Add(mapTag);
					}
					else if (mapTag.GameModes.Contains(value))
					{
						list.Add(mapTag);
					}
				}
			}
			return list;
		}

		// Token: 0x0600073E RID: 1854 RVA: 0x0001A720 File Offset: 0x00018920
		public static MapTag GetCurrentEnumMapTag()
		{
			MapTag result = null;
			NomadDbIdVector nomadDbIdVector = NomadDbIdVector.Create();
			if (nomadDbIdVector.IsValid)
			{
				Binding.FCE_Document_GetMapTags(nomadDbIdVector.Pointer);
				uint count = nomadDbIdVector.Count;
				for (uint num = 0U; num < count; num += 1U)
				{
					MapTag mapTag = null;
					ulong at = nomadDbIdVector.GetAt(num);
					if (MapTags.MapTagDictionary.TryGetValue(at, out mapTag) && mapTag.IsEnum)
					{
						result = mapTag;
					}
				}
				nomadDbIdVector.Dispose();
			}
			return result;
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0001A794 File Offset: 0x00018994
		public static List<MapTag> GetCurrentUserMapTags()
		{
			List<MapTag> list = new List<MapTag>();
			NomadDbIdVector nomadDbIdVector = NomadDbIdVector.Create();
			if (nomadDbIdVector.IsValid)
			{
				Binding.FCE_Document_GetMapTags(nomadDbIdVector.Pointer);
				uint count = nomadDbIdVector.Count;
				for (uint num = 0U; num < count; num += 1U)
				{
					MapTag mapTag = null;
					ulong at = nomadDbIdVector.GetAt(num);
					if (MapTags.MapTagDictionary.TryGetValue(at, out mapTag) && !mapTag.IsAuto && !mapTag.IsEnum)
					{
						list.Add(mapTag);
					}
				}
				nomadDbIdVector.Dispose();
			}
			return list;
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x0001A81C File Offset: 0x00018A1C
		public static void SaveMapTags(MapTag enumTag, List<MapTag> userTags)
		{
			Binding.FCE_Document_ClearMapTags();
			List<MapTag> autoMapTags = MapTags.GetAutoMapTags();
			foreach (MapTag mapTag in autoMapTags)
			{
				Binding.FCE_Document_AppendMapTag(mapTag.Id);
			}
			Binding.FCE_Document_AppendMapTag(enumTag.Id);
			foreach (MapTag mapTag2 in userTags)
			{
				Binding.FCE_Document_AppendMapTag(mapTag2.Id);
			}
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0001A8DC File Offset: 0x00018ADC
		private static string GetMapTagName(ulong maptagDbId)
		{
			return Localizer.LocalizeCommon(Binding.FCE_MapTag_GetDisplayNameId(maptagDbId));
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x0001A8EE File Offset: 0x00018AEE
		private static ulong GetObjectiveRefId(ulong maptagDbId)
		{
			return Binding.FCE_MapTag_GetObjectiveRef(maptagDbId);
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x0001A8FB File Offset: 0x00018AFB
		private static bool GetAutoFlag(ulong maptagDbId)
		{
			return Binding.FCE_MapTag_GetIsAuto(maptagDbId);
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x0001A908 File Offset: 0x00018B08
		private static bool GetEnumFlag(ulong maptagDbId)
		{
			return Binding.FCE_MapTag_GetIsEnum(maptagDbId);
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x0001A915 File Offset: 0x00018B15
		private static bool GetEnumDefaultFlag(ulong maptagDbId)
		{
			return Binding.FCE_MapTag_GetIsEnumDefault(maptagDbId);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0001A922 File Offset: 0x00018B22
		private static uint GetPriority(ulong maptagDbId)
		{
			return Binding.FCE_MapTag_GetPriority(maptagDbId);
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x0001A92F File Offset: 0x00018B2F
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x0001A936 File Offset: 0x00018B36
		public static Dictionary<ulong, MapTag> MapTagDictionary { get; private set; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x0001A93E File Offset: 0x00018B3E
		// (set) Token: 0x0600074A RID: 1866 RVA: 0x0001A945 File Offset: 0x00018B45
		public static MapTag DefaultEnumMapTag { get; private set; }
	}
}

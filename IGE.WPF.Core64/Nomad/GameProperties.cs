using System;
using System.Collections.Generic;

namespace IGE.Nomad
{
	// Token: 0x0200011E RID: 286
	internal static class GameProperties
	{
		// Token: 0x060009F5 RID: 2549 RVA: 0x00020DFC File Offset: 0x0001EFFC
		public static void Initialize()
		{
			GameProperties.GamePropertyList = new List<GameProperty>();
			NomadDbIdVector nomadDbIdVector = NomadDbIdVector.Create();
			if (nomadDbIdVector.IsValid)
			{
				Binding.FCE_GameProperty_GetAllPropertyIds(nomadDbIdVector.Pointer);
				uint count = nomadDbIdVector.Count;
				for (uint num = 0U; num < count; num += 1U)
				{
					ulong at = nomadDbIdVector.GetAt(num);
					List<ulong> list = new List<ulong>();
					NomadDbIdVector nomadDbIdVector2 = NomadDbIdVector.Create();
					if (nomadDbIdVector2.IsValid)
					{
						Binding.FCE_GameProperty_GetSupportedObjectiveDescDbIds(at, nomadDbIdVector2.Pointer);
						for (uint num2 = 0U; num2 < nomadDbIdVector2.Count; num2 += 1U)
						{
							list.Add(nomadDbIdVector2.GetAt(num2));
						}
						nomadDbIdVector2.Dispose();
					}
					EPropertyType propertyType = GameProperties.GetPropertyType(at);
					EPropertyValueType propertyValueType = GameProperties.GetPropertyValueType(at);
					if (propertyValueType == EPropertyValueType.EPropertyValueType_Bool)
					{
						GameProperties.GamePropertyList.Add(new GameProperty(at, GameProperties.GetPropertyEnumId(at), GameProperties.GetPropertyName(at), GameProperties.GetCategoryName(at), propertyType, propertyValueType, list, GameProperties.GetPropertyChildId(at), GameProperties.GetPropertyDefaultBoolean(at)));
					}
					else if (propertyValueType == EPropertyValueType.EPropertyValueType_Numeric)
					{
						GameProperties.GamePropertyList.Add(new GameProperty(at, GameProperties.GetPropertyEnumId(at), GameProperties.GetPropertyName(at), GameProperties.GetCategoryName(at), propertyType, propertyValueType, list, GameProperties.GetPropertyChildId(at), GameProperties.GetPropertyDefaultFloat(at), GameProperties.GetPropertyMinValue(at), GameProperties.GetPropertyMaxValue(at), GameProperties.GetPropertyResolution(at)));
					}
					else if (propertyValueType == EPropertyValueType.EPropertyValueType_Preset)
					{
						List<ulong> list2 = new List<ulong>();
						NomadDbIdVector nomadDbIdVector3 = NomadDbIdVector.Create();
						if (nomadDbIdVector3.IsValid)
						{
							Binding.FCE_GameProperty_GetPropertyPresetIds(at, nomadDbIdVector3.Pointer);
							for (uint num3 = 0U; num3 < nomadDbIdVector3.Count; num3 += 1U)
							{
								list2.Add(nomadDbIdVector3.GetAt(num3));
							}
							nomadDbIdVector3.Dispose();
						}
						GameProperties.GamePropertyList.Add(new GameProperty(at, GameProperties.GetPropertyEnumId(at), GameProperties.GetPropertyName(at), GameProperties.GetCategoryName(at), propertyType, propertyValueType, list, GameProperties.GetPropertyChildId(at), list2, GameProperties.GetPropertyDefaultPresetId(at)));
					}
				}
				nomadDbIdVector.Dispose();
			}
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x00020FE8 File Offset: 0x0001F1E8
		public static void PushToGameModeManager()
		{
			Binding.FCE_GameModeManager_ClearObjectiveSettings();
			foreach (GameProperty gameProperty in GameProperties.GamePropertyList)
			{
				Binding.FCE_GameModeManager_AddObjectiveSetting(gameProperty.PropertyDbId, gameProperty.CurrentValueNumeric, gameProperty.CurrentValueBool, gameProperty.CurrentValuePreset);
			}
		}

		// Token: 0x060009F7 RID: 2551 RVA: 0x00021060 File Offset: 0x0001F260
		public static void PullFromGameModeManager()
		{
			foreach (GameProperty gameProperty in GameProperties.GamePropertyList)
			{
				bool currentValueBool = false;
				float currentValueNumeric = 0f;
				ulong currentValuePreset = 0UL;
				if (Binding.FCE_GameModeManager_GetObjectiveSettingNumeric(gameProperty.PropertyDbId, out currentValueNumeric))
				{
					gameProperty.CurrentValueNumeric = currentValueNumeric;
				}
				else
				{
					gameProperty.CurrentValueNumeric = GameProperties.GetPropertyDefaultFloat(gameProperty.PropertyDbId);
				}
				if (Binding.FCE_GameModeManager_GetObjectiveSettingBool(gameProperty.PropertyDbId, out currentValueBool))
				{
					gameProperty.CurrentValueBool = currentValueBool;
				}
				else
				{
					gameProperty.CurrentValueBool = GameProperties.GetPropertyDefaultBoolean(gameProperty.PropertyDbId);
				}
				if (Binding.FCE_GameModeManager_GetObjectiveSettingPresetDbId(gameProperty.PropertyDbId, out currentValuePreset))
				{
					gameProperty.CurrentValuePreset = currentValuePreset;
				}
				else
				{
					gameProperty.CurrentValuePreset = GameProperties.GetPropertyDefaultPresetId(gameProperty.PropertyDbId);
				}
			}
		}

		// Token: 0x060009F8 RID: 2552 RVA: 0x00021148 File Offset: 0x0001F348
		private static int GetPropertyEnumId(ulong propertyDbId)
		{
			return Binding.FCE_GameProperty_GetPropertyID(propertyDbId);
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00021155 File Offset: 0x0001F355
		private static string GetPropertyName(ulong propertyDbId)
		{
			return Localizer.LocalizeCommon(Binding.FCE_GameProperty_GetPropertyDisplayNameId(propertyDbId));
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00021167 File Offset: 0x0001F367
		private static string GetCategoryName(ulong propertyDbId)
		{
			return Localizer.LocalizeCommon(Binding.FCE_GameProperty_GetPropertyCategoryNameId(propertyDbId));
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00021179 File Offset: 0x0001F379
		private static EPropertyType GetPropertyType(ulong propertyDbId)
		{
			return (EPropertyType)Binding.FCE_GameProperty_GetPropertyType(propertyDbId);
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x00021186 File Offset: 0x0001F386
		private static EPropertyValueType GetPropertyValueType(ulong propertyDbId)
		{
			return (EPropertyValueType)Binding.FCE_GameProperty_GetPropertyValueType(propertyDbId);
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00021193 File Offset: 0x0001F393
		private static ulong GetPropertyChildId(ulong propertyDbId)
		{
			return Binding.FCE_GameProperty_GetPropertyChildID(propertyDbId);
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x000211A0 File Offset: 0x0001F3A0
		private static float GetPropertyMinValue(ulong propertyDbId)
		{
			return Binding.FCE_GameProperty_GetPropertyMinValue(propertyDbId);
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x000211AD File Offset: 0x0001F3AD
		private static float GetPropertyMaxValue(ulong propertyDbId)
		{
			return Binding.FCE_GameProperty_GetPropertyMaxValue(propertyDbId);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x000211BA File Offset: 0x0001F3BA
		private static float GetPropertyResolution(ulong propertyDbId)
		{
			return Binding.FCE_GameProperty_GetPropertyResolution(propertyDbId);
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x000211C7 File Offset: 0x0001F3C7
		private static float GetPropertyDefaultFloat(ulong propertyDbId)
		{
			return Binding.FCE_GameProperty_GetPropertyDefaultFloat(propertyDbId);
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x000211D4 File Offset: 0x0001F3D4
		private static bool GetPropertyDefaultBoolean(ulong propertyDbId)
		{
			return Binding.FCE_GameProperty_GetPropertyDefaultBoolean(propertyDbId);
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x000211E1 File Offset: 0x0001F3E1
		private static ulong GetPropertyDefaultPresetId(ulong propertyDbId)
		{
			return Binding.FCE_GameProperty_GetPropertyDefaultPresetId(propertyDbId);
		}

		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000A04 RID: 2564 RVA: 0x000211EE File Offset: 0x0001F3EE
		// (set) Token: 0x06000A05 RID: 2565 RVA: 0x000211F5 File Offset: 0x0001F3F5
		public static List<GameProperty> GamePropertyList { get; private set; }
	}
}

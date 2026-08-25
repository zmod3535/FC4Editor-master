using System;
using System.Collections.Generic;

namespace IGE.Nomad
{
	// Token: 0x0200001F RID: 31
	internal static class GameModeManager
	{
		// Token: 0x060000E0 RID: 224 RVA: 0x000032B0 File Offset: 0x000014B0
		public static void Initialize()
		{
			GameModeManager.GameMode = new List<GameMode>();
			NomadDbIdVector nomadDbIdVector = NomadDbIdVector.Create();
			if (nomadDbIdVector.IsValid)
			{
				Binding.FCE_GameMode_GetAllGameModeDescDbIds(nomadDbIdVector.Pointer);
				uint count = nomadDbIdVector.Count;
				for (uint num = 0U; num < count; num += 1U)
				{
					ulong at = nomadDbIdVector.GetAt(num);
					List<ObjectiveType> list = new List<ObjectiveType>();
					NomadDbIdVector nomadDbIdVector2 = NomadDbIdVector.Create();
					if (nomadDbIdVector2.IsValid)
					{
						Binding.FCE_GameMode_GetObjectiveDescDbIds(nomadDbIdVector.GetAt(num), nomadDbIdVector2.Pointer);
						uint count2 = nomadDbIdVector2.Count;
						for (uint num2 = 0U; num2 < count2; num2 += 1U)
						{
							ulong at2 = nomadDbIdVector2.GetAt(num2);
							list.Add(new ObjectiveType(at2, GameModeManager.GetObjectiveName(at2), GameModeManager.GetObjectiveDescription(at2)));
						}
						GameModeManager.GameMode.Add(new GameMode(at, GameModeManager.GetGameModeName(at), list));
						nomadDbIdVector2.Dispose();
					}
				}
				GameModeManager.ObjectiveTypes = new Dictionary<ulong, ObjectiveType>();
				foreach (GameMode gameMode in GameModeManager.GameMode)
				{
					foreach (ObjectiveType objectiveType in gameMode.ObjectiveTypes)
					{
						objectiveType.GameMode = gameMode;
						GameModeManager.ObjectiveTypes[objectiveType.Id] = objectiveType;
					}
				}
				nomadDbIdVector.Dispose();
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00003448 File Offset: 0x00001648
		private static string GetGameModeName(ulong gameModeDescDbId)
		{
			return Localizer.LocalizeCommon(Binding.FCE_GameMode_GetGameModeNameId(gameModeDescDbId));
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000345A File Offset: 0x0000165A
		private static string GetObjectiveName(ulong objectiveDescDbId)
		{
			return Localizer.LocalizeCommon(Binding.FCE_GameMode_GetObjectiveNameId(objectiveDescDbId));
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x0000346C File Offset: 0x0000166C
		private static string GetObjectiveDescription(ulong objectiveDescDbId)
		{
			return Localizer.LocalizeCommon(Binding.FCE_GameMode_GetObjectiveDescId(objectiveDescDbId));
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000347E File Offset: 0x0000167E
		private static ObjectiveType GetObjectiveType(ulong objectiveTypeId)
		{
			return GameModeManager.ObjectiveTypes[objectiveTypeId];
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000348B File Offset: 0x0000168B
		public static ulong GetCurrentObjectiveType()
		{
			return Binding.FCE_GameMode_GetCurrentObjectiveDescId();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00003498 File Offset: 0x00001698
		public static void SetCurrentObjectiveType(ulong value)
		{
			Binding.FCE_GameMode_SetCurrentObjectiveDescId(value);
			ObjectiveType objectiveType = GameModeManager.ObjectiveTypes[value];
			GameModeManager.SetCurrentGameModeDescId(objectiveType.GameMode.Id);
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000034CC File Offset: 0x000016CC
		public static ulong GetCurrentGameModeDescId()
		{
			return Binding.FCE_GameMode_GetCurrentGameModeDescId();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000034D8 File Offset: 0x000016D8
		public static void SetCurrentGameModeDescId(ulong value)
		{
			Binding.FCE_GameMode_SetCurrentGameModeDescId(value);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000034E5 File Offset: 0x000016E5
		public static GameModeManager.EMapObjective GetEnumObjectiveType()
		{
			return (GameModeManager.EMapObjective)Binding.FCE_GameMode_GetObjectiveEnumValue();
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000EA RID: 234 RVA: 0x000034F2 File Offset: 0x000016F2
		// (set) Token: 0x060000EB RID: 235 RVA: 0x000034F9 File Offset: 0x000016F9
		public static List<GameMode> GameMode { get; private set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00003501 File Offset: 0x00001701
		// (set) Token: 0x060000ED RID: 237 RVA: 0x00003508 File Offset: 0x00001708
		public static Dictionary<ulong, ObjectiveType> ObjectiveTypes { get; private set; }

		// Token: 0x02000020 RID: 32
		public enum EMapObjective
		{
			// Token: 0x04000043 RID: 67
			EMapObjective_Invalid,
			// Token: 0x04000044 RID: 68
			EMapObjective_Outpost,
			// Token: 0x04000045 RID: 69
			EMapObjective_TerroHunt,
			// Token: 0x04000046 RID: 70
			EMapObjective_Poacher,
			// Token: 0x04000047 RID: 71
			EMapObjective_Extraction,
			// Token: 0x04000048 RID: 72
			EMapObjective_DemonMask,
			// Token: 0x04000049 RID: 73
			EMapObjective_Propaganda,
			// Token: 0x0400004A RID: 74
			EMapObjective_NumObjectives
		}
	}
}

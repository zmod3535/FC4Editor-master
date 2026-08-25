using System;
using System.Windows;

namespace IGE.Nomad
{
	// Token: 0x02000077 RID: 119
	internal class BudgetManager
	{
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x00012A1B File Offset: 0x00010C1B
		public static int MemoryUsage
		{
			get
			{
				return Binding.FCE_BudgetManager_GetMemoryUsage();
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00012A27 File Offset: 0x00010C27
		public static float ObjectUsage
		{
			get
			{
				return Binding.FCE_BudgetManager_GetObjectUsage();
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x00012A33 File Offset: 0x00010C33
		public static float MaxMemoryUsageMB
		{
			get
			{
				return (float)Binding.FCE_BudgetManager_GetMaxMemoryUsageMB();
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x00012A40 File Offset: 0x00010C40
		public static float MaxObjectUsage
		{
			get
			{
				return Binding.FCE_BudgetManager_GetMaxObjectUsage();
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x00012A4C File Offset: 0x00010C4C
		public static float GetWaveValue(int iWave)
		{
			return Binding.FCE_BudgetManager_GetWaveUsage(iWave);
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x00012A59 File Offset: 0x00010C59
		public static float GetMaxWaveValue(int iWave)
		{
			return Binding.FCE_BudgetManager_GetMaxWaveUsage(iWave);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00012A66 File Offset: 0x00010C66
		public static float GetAmbientAI()
		{
			return Binding.FCE_BudgetManager_GetAmbientAI();
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00012A72 File Offset: 0x00010C72
		public static float GetEnemyAI(int iWave)
		{
			return Binding.FCE_BudgetManager_GetEnemyAI(iWave);
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00012A7F File Offset: 0x00010C7F
		public static float Vehicles
		{
			get
			{
				return Binding.FCE_BudgetManager_GetVehicles();
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x00012A8B File Offset: 0x00010C8B
		public static float MaxVehicles
		{
			get
			{
				return Binding.FCE_BudgetManager_GetMaxVehicles();
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00012A97 File Offset: 0x00010C97
		public static bool ValidateObjectsGlobalCost(EditorObjectSelection selection)
		{
			return Binding.FCE_BudgetManager_ValidateObjectsGlobalCost(selection.Pointer);
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00012AAA File Offset: 0x00010CAA
		public static bool ValidateObjectsSectorCost(EditorObjectSelection selection, bool alreadyAdded)
		{
			return Binding.FCE_BudgetManager_ValidateObjectsSectorCost(selection.Pointer, alreadyAdded);
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00012ABE File Offset: 0x00010CBE
		public static bool ValidateAIObjectsUsage(EditorObjectSelection selection)
		{
			return Binding.FCE_BudgetManager_ValidateAIObjectsUsage(selection.Pointer);
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x00012AD1 File Offset: 0x00010CD1
		public static bool ValidatePhysicsObjectsUsage(EditorObjectSelection selection)
		{
			return Binding.FCE_BudgetManager_ValidatePhysicsObjectsUsage(selection.Pointer);
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x00012AE4 File Offset: 0x00010CE4
		public static bool ValidateLightObjectsUsage(EditorObjectSelection selection)
		{
			return Binding.FCE_BudgetManager_ValidateLightObjectsUsage(selection.Pointer);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00012AF7 File Offset: 0x00010CF7
		public static bool ValidateAnimPointsObjectsUsage(EditorObjectSelection selection)
		{
			return Binding.FCE_BudgetManager_ValidateAnimPointsObjectsUsage(selection.Pointer);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00012B0A File Offset: 0x00010D0A
		public static bool ValidateSpawnPointsObjectsUsage(EditorObjectSelection selection)
		{
			return Binding.FCE_BudgetManager_ValidateSpawnPointsObjectsUsage(selection.Pointer);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x00012B1D File Offset: 0x00010D1D
		public static int GetObjectSectorId(EditorObject editorObject)
		{
			return Binding.FCE_BudgetManager_GetObjectSectorId(editorObject.Pointer);
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00012B30 File Offset: 0x00010D30
		public static bool CheckSectorBudget(EditorObjectSelection selection, bool isAlreadyInSectorCost)
		{
			bool result = true;
			if (!BudgetManager.ValidateObjectsSectorCost(selection, isAlreadyInSectorCost))
			{
				if (!BudgetManager.suppressBudgetGridMessageBox)
				{
					MessageBoxResult messageBoxResult = MessageBox.Show(Program.MainWin, Localizer.Localize("WARNING_SECTOR_BUDGET", null), Localizer.LocalizeCommon("MSG_TITLE_WARNING"), MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
					result = (BudgetManager.suppressBudgetGridMessageBox = (messageBoxResult == MessageBoxResult.OK));
					EditorSettings.ShowBudgetGrid = (!BudgetManager.suppressBudgetGridMessageBox || EditorSettings.ShowBudgetGridPcOverride);
				}
				else
				{
					EditorSettings.ShowBudgetGrid = EditorSettings.ShowBudgetGridPcOverride;
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x00012BA0 File Offset: 0x00010DA0
		public static void UpdateBudgetWarningStatus(EditorObjectSelection selection, bool isAlreadyInSectorCost)
		{
			if (!BudgetManager.ValidateObjectsSectorCost(selection, isAlreadyInSectorCost))
			{
				EditorSettings.ShowBudgetGrid = (!BudgetManager.suppressBudgetGridMessageBox || EditorSettings.ShowBudgetGridPcOverride);
			}
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00012BBF File Offset: 0x00010DBF
		public static void ResetBudgetWarningStatus()
		{
			BudgetManager.suppressBudgetGridMessageBox = false;
		}

		// Token: 0x0400021E RID: 542
		private static bool suppressBudgetGridMessageBox;
	}
}

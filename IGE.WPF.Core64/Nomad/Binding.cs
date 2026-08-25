using System;
using System.Runtime.InteropServices;

namespace IGE.Nomad
{
	// Token: 0x0200012E RID: 302
	internal static class Binding
	{
		// Token: 0x06000A83 RID: 2691 RVA: 0x00022830 File Offset: 0x00020A30
		static Binding()
		{
			IntPtr intPtr = Binding.LoadLibrary("FC64.dll");
			if (intPtr == IntPtr.Zero)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (lastWin32Error != 0)
				{
					Console.WriteLine(lastWin32Error);
				}
			}
			Binding.InitDuniaEngine = (Binding._InitDuniaEngine)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(intPtr, "InitDuniaEngine"), typeof(Binding._InitDuniaEngine));
			Binding.TickDuniaEngine = (Binding._TickDuniaEngine)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(intPtr, "TickDuniaEngine"), typeof(Binding._TickDuniaEngine));
			Binding.RunDuniaEngine = (Binding._RunDuniaEngine)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(intPtr, "RunDuniaEngine"), typeof(Binding._RunDuniaEngine));
			Binding.CloseDuniaEngine = (Binding._CloseDuniaEngine)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(intPtr, "CloseDuniaEngine"), typeof(Binding._CloseDuniaEngine));
			Binding.LocalizeText = (Binding._LocalizeText)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(intPtr, "LocalizeText"), typeof(Binding._LocalizeText));
			Binding.LocalizeTextFromLineId = (Binding._LocalizeTextFromLineId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(intPtr, "LocalizeTextFromLineId"), typeof(Binding._LocalizeTextFromLineId));
			Binding.PC_RegisterDeviceNotification = (Binding._PC_RegisterDeviceNotification)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(intPtr, "PC_RegisterDeviceNotification"), typeof(Binding._PC_RegisterDeviceNotification));
			Binding.PC_DeviceChange = (Binding._PC_DeviceChange)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(intPtr, "PC_DeviceChange"), typeof(Binding._PC_DeviceChange));
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x0002299C File Offset: 0x00020B9C
		public static void LoadDll()
		{
			if (Binding._gameDllModule != IntPtr.Zero)
			{
				return;
			}
			Binding._gameDllModule = Binding.LoadLibrary(Binding.gameDll);
			Binding.FCE_Hack_Init = (Binding._FCE_Hack_Init)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Hack_Init"), typeof(Binding._FCE_Hack_Init));
			Binding.FCE_GetProgress = (Binding._FCE_GetProgress)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GetProgress"), typeof(Binding._FCE_GetProgress));
			Binding.FCE_Engine_Reset = (Binding._FCE_Engine_Reset)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_Reset"), typeof(Binding._FCE_Engine_Reset));
			Binding.FCE_Engine_GetPersonalPath = (Binding._FCE_Engine_GetPersonalPath)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_GetPersonalPath"), typeof(Binding._FCE_Engine_GetPersonalPath));
			Binding.FCE_Engine_GetGenericDataPath = (Binding._FCE_Engine_GetGenericDataPath)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_GetGenericDataPath"), typeof(Binding._FCE_Engine_GetGenericDataPath));
			Binding.FCE_Engine_UpdateViewport = (Binding._FCE_Engine_UpdateViewport)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_UpdateViewport"), typeof(Binding._FCE_Engine_UpdateViewport));
			Binding.FCE_Engine_AutoAcquireInput = (Binding._FCE_Engine_AutoAcquireInput)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_AutoAcquireInput"), typeof(Binding._FCE_Engine_AutoAcquireInput));
			Binding.FCE_Engine_IsConsoleOpen = (Binding._FCE_Engine_IsConsoleOpen)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_IsConsoleOpen"), typeof(Binding._FCE_Engine_IsConsoleOpen));
			Binding.FCE_Engine_GetTimeOfDay = (Binding._FCE_Engine_GetTimeOfDay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_GetTimeOfDay"), typeof(Binding._FCE_Engine_GetTimeOfDay));
			Binding.FCE_Engine_SetTimeOfDay = (Binding._FCE_Engine_SetTimeOfDay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_SetTimeOfDay"), typeof(Binding._FCE_Engine_SetTimeOfDay));
			Binding.FCE_Engine_GetCloudTypeCount = (Binding._FCE_Engine_GetCloudTypeCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_GetCloudTypeCount"), typeof(Binding._FCE_Engine_GetCloudTypeCount));
			Binding.FCE_Engine_GetCloudType = (Binding._FCE_Engine_GetCloudType)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_GetCloudType"), typeof(Binding._FCE_Engine_GetCloudType));
			Binding.FCE_Engine_SetCloudType = (Binding._FCE_Engine_SetCloudType)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_SetCloudType"), typeof(Binding._FCE_Engine_SetCloudType));
			Binding.FCE_Engine_IsSnowEnabled = (Binding._FCE_Engine_IsSnowEnabled)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_IsSnowEnabled"), typeof(Binding._FCE_Engine_IsSnowEnabled));
			Binding.FCE_Engine_SetSnowEnabled = (Binding._FCE_Engine_SetSnowEnabled)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_SetSnowEnabled"), typeof(Binding._FCE_Engine_SetSnowEnabled));
			Binding.FCE_Engine_IsBackdropEnabled = (Binding._FCE_Engine_IsBackdropEnabled)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_IsBackdropEnabled"), typeof(Binding._FCE_Engine_IsBackdropEnabled));
			Binding.FCE_Engine_SetBackdropEnabled = (Binding._FCE_Engine_SetBackdropEnabled)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_SetBackdropEnabled"), typeof(Binding._FCE_Engine_SetBackdropEnabled));
			Binding.FCE_Engine_SetSelectedObject = (Binding._FCE_Engine_SetSelectedObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Engine_SetSelectedObject"), typeof(Binding._FCE_Engine_SetSelectedObject));
			Binding.FCE_Core_GetAxisFromAngles = (Binding._FCE_Core_GetAxisFromAngles)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Core_GetAxisFromAngles"), typeof(Binding._FCE_Core_GetAxisFromAngles));
			Binding.FCE_Core_GetAnglesFromAxis = (Binding._FCE_Core_GetAnglesFromAxis)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Core_GetAnglesFromAxis"), typeof(Binding._FCE_Core_GetAnglesFromAxis));
			Binding.FCE_Core_GetAnglesFromDir = (Binding._FCE_Core_GetAnglesFromDir)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Core_GetAnglesFromDir"), typeof(Binding._FCE_Core_GetAnglesFromDir));
			Binding.FCE_Core_Points_Create = (Binding._FCE_Core_Points_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Core_Points_Create"), typeof(Binding._FCE_Core_Points_Create));
			Binding.FCE_Core_Points_Destroy = (Binding._FCE_Core_Points_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Core_Points_Destroy"), typeof(Binding._FCE_Core_Points_Destroy));
			Binding.FCE_Editor_Create = (Binding._FCE_Editor_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_Create"), typeof(Binding._FCE_Editor_Create));
			Binding.FCE_Editor_Destroy = (Binding._FCE_Editor_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_Destroy"), typeof(Binding._FCE_Editor_Destroy));
			Binding.FCE_Editor_IsInitialized = (Binding._FCE_Editor_IsInitialized)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_IsInitialized"), typeof(Binding._FCE_Editor_IsInitialized));
			Binding.FCE_Editor_Update_Callback = (Binding._FCE_Editor_Update_Callback)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_Update_Callback"), typeof(Binding._FCE_Editor_Update_Callback));
			Binding.FCE_Editor_Event_Callback = (Binding._FCE_Editor_Event_Callback)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_Event_Callback"), typeof(Binding._FCE_Editor_Event_Callback));
			Binding.FCE_Editor_LoadCompleted_Callback = (Binding._FCE_Editor_LoadCompleted_Callback)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_LoadCompleted_Callback"), typeof(Binding._FCE_Editor_LoadCompleted_Callback));
			Binding.FCE_Editor_SaveCompleted_Callback = (Binding._FCE_Editor_SaveCompleted_Callback)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_SaveCompleted_Callback"), typeof(Binding._FCE_Editor_SaveCompleted_Callback));
			Binding.FCE_Editor_EnableUI_Callback = (Binding._FCE_Editor_EnableUI_Callback)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_EnableUI_Callback"), typeof(Binding._FCE_Editor_EnableUI_Callback));
			Binding.FCE_Editor_IsLoadPending = (Binding._FCE_Editor_IsLoadPending)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_IsLoadPending"), typeof(Binding._FCE_Editor_IsLoadPending));
			Binding.FCE_Editor_GetFrameTime = (Binding._FCE_Editor_GetFrameTime)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_GetFrameTime"), typeof(Binding._FCE_Editor_GetFrameTime));
			Binding.FCE_Editor_GetScreenPointFromWorldPos = (Binding._FCE_Editor_GetScreenPointFromWorldPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_GetScreenPointFromWorldPos"), typeof(Binding._FCE_Editor_GetScreenPointFromWorldPos));
			Binding.FCE_Editor_GetWorldRayFromScreenPoint = (Binding._FCE_Editor_GetWorldRayFromScreenPoint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_GetWorldRayFromScreenPoint"), typeof(Binding._FCE_Editor_GetWorldRayFromScreenPoint));
			Binding.FCE_Editor_RayCastTerrain = (Binding._FCE_Editor_RayCastTerrain)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_RayCastTerrain"), typeof(Binding._FCE_Editor_RayCastTerrain));
			Binding.FCE_Editor_RayCastPhysics = (Binding._FCE_Editor_RayCastPhysics)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_RayCastPhysics"), typeof(Binding._FCE_Editor_RayCastPhysics));
			Binding.FCE_Editor_RayCastPhysics2 = (Binding._FCE_Editor_RayCastPhysics2)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_RayCastPhysics2"), typeof(Binding._FCE_Editor_RayCastPhysics2));
			Binding.FCE_Editor_ValidateSpawnPoints = (Binding._FCE_Editor_ValidateSpawnPoints)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_ValidateSpawnPoints"), typeof(Binding._FCE_Editor_ValidateSpawnPoints));
			Binding.FCE_Editor_ValidateObjective = (Binding._FCE_Editor_ValidateObjective)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_ValidateObjective"), typeof(Binding._FCE_Editor_ValidateObjective));
			Binding.FCE_Editor_EnterIngame = (Binding._FCE_Editor_EnterIngame)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_EnterIngame"), typeof(Binding._FCE_Editor_EnterIngame));
			Binding.FCE_Editor_ExitIngame = (Binding._FCE_Editor_ExitIngame)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_ExitIngame"), typeof(Binding._FCE_Editor_ExitIngame));
			Binding.FCE_Editor_IsIngame = (Binding._FCE_Editor_IsIngame)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_IsIngame"), typeof(Binding._FCE_Editor_IsIngame));
			Binding.FCE_Editor_MuteSound = (Binding._FCE_Editor_MuteSound)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_MuteSound"), typeof(Binding._FCE_Editor_MuteSound));
			Binding.FCE_Online_GetUplayUserName = (Binding._FCE_Online_GetUplayUserName)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Online_GetUplayUserName"), typeof(Binding._FCE_Online_GetUplayUserName));
			Binding.FCE_Online_GetUplayAccountId = (Binding._FCE_Online_GetUplayAccountId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Online_GetUplayAccountId"), typeof(Binding._FCE_Online_GetUplayAccountId));
			Binding.FCE_GamerProfile_Create = (Binding._FCE_GamerProfile_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GamerProfile_Create"), typeof(Binding._FCE_GamerProfile_Create));
			Binding.FCE_GamerProfile_IsReady = (Binding._FCE_GamerProfile_IsReady)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GamerProfile_IsReady"), typeof(Binding._FCE_GamerProfile_IsReady));
			Binding.FCE_GamerProfile_HasCreationFailed = (Binding._FCE_GamerProfile_HasCreationFailed)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GamerProfile_HasCreationFailed"), typeof(Binding._FCE_GamerProfile_HasCreationFailed));
			Binding.FCE_GamerProfile_UpdateManager = (Binding._FCE_GamerProfile_UpdateManager)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GamerProfile_UpdateManager"), typeof(Binding._FCE_GamerProfile_UpdateManager));
			Binding.FCE_Document_Reset = (Binding._FCE_Document_Reset)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_Reset"), typeof(Binding._FCE_Document_Reset));
			Binding.FCE_Document_LoadPhysical = (Binding._FCE_Document_LoadPhysical)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_LoadPhysical"), typeof(Binding._FCE_Document_LoadPhysical));
			Binding.FCE_Document_Load = (Binding._FCE_Document_Load)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_Load"), typeof(Binding._FCE_Document_Load));
			Binding.FCE_Document_Save = (Binding._FCE_Document_Save)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_Save"), typeof(Binding._FCE_Document_Save));
			Binding.FCE_Document_CheckValidation = (Binding._FCE_Document_CheckValidation)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_CheckValidation"), typeof(Binding._FCE_Document_CheckValidation));
			Binding.FCE_Document_Validate = (Binding._FCE_Document_Validate)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_Validate"), typeof(Binding._FCE_Document_Validate));
			Binding.FCE_Document_GetMapID = (Binding._FCE_Document_GetMapID)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetMapID"), typeof(Binding._FCE_Document_GetMapID));
			Binding.FCE_Document_SetMapID = (Binding._FCE_Document_SetMapID)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_SetMapID"), typeof(Binding._FCE_Document_SetMapID));
			Binding.FCE_Document_GetVersionID = (Binding._FCE_Document_GetVersionID)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetVersionID"), typeof(Binding._FCE_Document_GetVersionID));
			Binding.FCE_Document_GetMapDefaultName = (Binding._FCE_Document_GetMapDefaultName)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetMapDefaultName"), typeof(Binding._FCE_Document_GetMapDefaultName));
			Binding.FCE_Document_GetMapName = (Binding._FCE_Document_GetMapName)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetMapName"), typeof(Binding._FCE_Document_GetMapName));
			Binding.FCE_Document_SetMapName = (Binding._FCE_Document_SetMapName)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_SetMapName"), typeof(Binding._FCE_Document_SetMapName));
			Binding.FCE_Document_GetCreatorName = (Binding._FCE_Document_GetCreatorName)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetCreatorName"), typeof(Binding._FCE_Document_GetCreatorName));
			Binding.FCE_Document_SetCreatorName = (Binding._FCE_Document_SetCreatorName)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_SetCreatorName"), typeof(Binding._FCE_Document_SetCreatorName));
			Binding.FCE_Document_GetAuthorName = (Binding._FCE_Document_GetAuthorName)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetAuthorName"), typeof(Binding._FCE_Document_GetAuthorName));
			Binding.FCE_Document_SetAuthorName = (Binding._FCE_Document_SetAuthorName)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_SetAuthorName"), typeof(Binding._FCE_Document_SetAuthorName));
			Binding.FCE_Document_GetBattlefieldSize = (Binding._FCE_Document_GetBattlefieldSize)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetBattlefieldSize"), typeof(Binding._FCE_Document_GetBattlefieldSize));
			Binding.FCE_Document_SetBattlefieldSize = (Binding._FCE_Document_SetBattlefieldSize)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_SetBattlefieldSize"), typeof(Binding._FCE_Document_SetBattlefieldSize));
			Binding.FCE_Document_GetPlayerSize = (Binding._FCE_Document_GetPlayerSize)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetPlayerSize"), typeof(Binding._FCE_Document_GetPlayerSize));
			Binding.FCE_Document_SetPlayerSize = (Binding._FCE_Document_SetPlayerSize)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_SetPlayerSize"), typeof(Binding._FCE_Document_SetPlayerSize));
			Binding.FCE_Document_IsSnapshotSet = (Binding._FCE_Document_IsSnapshotSet)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_IsSnapshotSet"), typeof(Binding._FCE_Document_IsSnapshotSet));
			Binding.FCE_Document_ClearSnapshot = (Binding._FCE_Document_ClearSnapshot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_ClearSnapshot"), typeof(Binding._FCE_Document_ClearSnapshot));
			Binding.FCE_Document_GetSnapshotPos = (Binding._FCE_Document_GetSnapshotPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetSnapshotPos"), typeof(Binding._FCE_Document_GetSnapshotPos));
			Binding.FCE_Document_SetSnapshotPos = (Binding._FCE_Document_SetSnapshotPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_SetSnapshotPos"), typeof(Binding._FCE_Document_SetSnapshotPos));
			Binding.FCE_Document_GetSnapshotAngle = (Binding._FCE_Document_GetSnapshotAngle)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetSnapshotAngle"), typeof(Binding._FCE_Document_GetSnapshotAngle));
			Binding.FCE_Document_SetSnapshotAngle = (Binding._FCE_Document_SetSnapshotAngle)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_SetSnapshotAngle"), typeof(Binding._FCE_Document_SetSnapshotAngle));
			Binding.FCE_Document_TakeSnapshot = (Binding._FCE_Document_TakeSnapshot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_TakeSnapshot"), typeof(Binding._FCE_Document_TakeSnapshot));
			Binding.FCE_Document_IsNavmeshEnabled = (Binding._FCE_Document_IsNavmeshEnabled)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_IsNavmeshEnabled"), typeof(Binding._FCE_Document_IsNavmeshEnabled));
			Binding.FCE_Document_SetNavmeshEnabled = (Binding._FCE_Document_SetNavmeshEnabled)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_SetNavmeshEnabled"), typeof(Binding._FCE_Document_SetNavmeshEnabled));
			Binding.FCE_Document_FinalizeMap = (Binding._FCE_Document_FinalizeMap)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_FinalizeMap"), typeof(Binding._FCE_Document_FinalizeMap));
			Binding.FCE_Document_Export = (Binding._FCE_Document_Export)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_Export"), typeof(Binding._FCE_Document_Export));
			Binding.FCE_Document_Dump = (Binding._FCE_Document_Dump)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_Dump"), typeof(Binding._FCE_Document_Dump));
			Binding.FCE_Document_ExtractBigFile = (Binding._FCE_Document_ExtractBigFile)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_ExtractBigFile"), typeof(Binding._FCE_Document_ExtractBigFile));
			Binding.FCE_Document_ClearMapTags = (Binding._FCE_Document_ClearMapTags)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_ClearMapTags"), typeof(Binding._FCE_Document_ClearMapTags));
			Binding.FCE_Document_GetMapTags = (Binding._FCE_Document_GetMapTags)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_GetMapTags"), typeof(Binding._FCE_Document_GetMapTags));
			Binding.FCE_Document_AppendMapTag = (Binding._FCE_Document_AppendMapTag)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Document_AppendMapTag"), typeof(Binding._FCE_Document_AppendMapTag));
			Binding.FCE_WaitScreen_Show = (Binding._FCE_WaitScreen_Show)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_WaitScreen_Show"), typeof(Binding._FCE_WaitScreen_Show));
			Binding.FCE_WaitScreen_Hide = (Binding._FCE_WaitScreen_Hide)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_WaitScreen_Hide"), typeof(Binding._FCE_WaitScreen_Hide));
			Binding.FCE_EditorSettings_IsCollectionVisible = (Binding._FCE_EditorSettings_IsCollectionVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsCollectionVisible"), typeof(Binding._FCE_EditorSettings_IsCollectionVisible));
			Binding.FCE_EditorSettings_ShowCollections = (Binding._FCE_EditorSettings_ShowCollections)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowCollections"), typeof(Binding._FCE_EditorSettings_ShowCollections));
			Binding.FCE_EditorSettings_IsFogVisible = (Binding._FCE_EditorSettings_IsFogVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsFogVisible"), typeof(Binding._FCE_EditorSettings_IsFogVisible));
			Binding.FCE_EditorSettings_ShowFog = (Binding._FCE_EditorSettings_ShowFog)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowFog"), typeof(Binding._FCE_EditorSettings_ShowFog));
			Binding.FCE_EditorSettings_IsExposureVisible = (Binding._FCE_EditorSettings_IsExposureVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsExposureVisible"), typeof(Binding._FCE_EditorSettings_IsExposureVisible));
			Binding.FCE_EditorSettings_ShowExposure = (Binding._FCE_EditorSettings_ShowExposure)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowExposure"), typeof(Binding._FCE_EditorSettings_ShowExposure));
			Binding.FCE_EditorSettings_IsShadowVisible = (Binding._FCE_EditorSettings_IsShadowVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsShadowVisible"), typeof(Binding._FCE_EditorSettings_IsShadowVisible));
			Binding.FCE_EditorSettings_ShowShadow = (Binding._FCE_EditorSettings_ShowShadow)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowShadow"), typeof(Binding._FCE_EditorSettings_ShowShadow));
			Binding.FCE_EditorSettings_IsWaterVisible = (Binding._FCE_EditorSettings_IsWaterVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsWaterVisible"), typeof(Binding._FCE_EditorSettings_IsWaterVisible));
			Binding.FCE_EditorSettings_ShowWater = (Binding._FCE_EditorSettings_ShowWater)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowWater"), typeof(Binding._FCE_EditorSettings_ShowWater));
			Binding.FCE_EditorSettings_IsIconsVisible = (Binding._FCE_EditorSettings_IsIconsVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsIconsVisible"), typeof(Binding._FCE_EditorSettings_IsIconsVisible));
			Binding.FCE_EditorSettings_ShowIcons = (Binding._FCE_EditorSettings_ShowIcons)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowIcons"), typeof(Binding._FCE_EditorSettings_ShowIcons));
			Binding.FCE_EditorSettings_IsSoundEnabled = (Binding._FCE_EditorSettings_IsSoundEnabled)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsSoundEnabled"), typeof(Binding._FCE_EditorSettings_IsSoundEnabled));
			Binding.FCE_EditorSettings_SetSoundEnabled = (Binding._FCE_EditorSettings_SetSoundEnabled)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetSoundEnabled"), typeof(Binding._FCE_EditorSettings_SetSoundEnabled));
			Binding.FCE_EditorSettings_IsGridVisible = (Binding._FCE_EditorSettings_IsGridVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsGridVisible"), typeof(Binding._FCE_EditorSettings_IsGridVisible));
			Binding.FCE_EditorSettings_ShowGrid = (Binding._FCE_EditorSettings_ShowGrid)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowGrid"), typeof(Binding._FCE_EditorSettings_ShowGrid));
			Binding.FCE_EditorSettings_GetGridResolution = (Binding._FCE_EditorSettings_GetGridResolution)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_GetGridResolution"), typeof(Binding._FCE_EditorSettings_GetGridResolution));
			Binding.FCE_EditorSettings_SetGridResolution = (Binding._FCE_EditorSettings_SetGridResolution)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetGridResolution"), typeof(Binding._FCE_EditorSettings_SetGridResolution));
			Binding.FCE_EditorSettings_IsBudgetGridVisible = (Binding._FCE_EditorSettings_IsBudgetGridVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsBudgetGridVisible"), typeof(Binding._FCE_EditorSettings_IsBudgetGridVisible));
			Binding.FCE_EditorSettings_ShowBudgetGrid_Callback = (Binding._FCE_EditorSettings_ShowBudgetGrid_Callback)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowBudgetGrid_Callback"), typeof(Binding._FCE_EditorSettings_ShowBudgetGrid_Callback));
			Binding.FCE_EditorSettings_ShowBudgetGrid = (Binding._FCE_EditorSettings_ShowBudgetGrid)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowBudgetGrid"), typeof(Binding._FCE_EditorSettings_ShowBudgetGrid));
			Binding.FCE_EditorSettings_GetBudgetGridResolution = (Binding._FCE_EditorSettings_GetBudgetGridResolution)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_GetBudgetGridResolution"), typeof(Binding._FCE_EditorSettings_GetBudgetGridResolution));
			Binding.FCE_EditorSettings_SetBudgetGridResolution = (Binding._FCE_EditorSettings_SetBudgetGridResolution)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetBudgetGridResolution"), typeof(Binding._FCE_EditorSettings_SetBudgetGridResolution));
			Binding.FCE_EditorSettings_IsNavmeshVisible = (Binding._FCE_EditorSettings_IsNavmeshVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsNavmeshVisible"), typeof(Binding._FCE_EditorSettings_IsNavmeshVisible));
			Binding.FCE_EditorSettings_ShowNavmesh = (Binding._FCE_EditorSettings_ShowNavmesh)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowNavmesh"), typeof(Binding._FCE_EditorSettings_ShowNavmesh));
			Binding.FCE_EditorSettings_HideNavmesh = (Binding._FCE_EditorSettings_HideNavmesh)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_HideNavmesh"), typeof(Binding._FCE_EditorSettings_HideNavmesh));
			Binding.FCE_EditorSettings_GetNavmeshLayer = (Binding._FCE_EditorSettings_GetNavmeshLayer)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_GetNavmeshLayer"), typeof(Binding._FCE_EditorSettings_GetNavmeshLayer));
			Binding.FCE_EditorSettings_IsCoversVisible = (Binding._FCE_EditorSettings_IsCoversVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsCoversVisible"), typeof(Binding._FCE_EditorSettings_IsCoversVisible));
			Binding.FCE_EditorSettings_ShowCovers = (Binding._FCE_EditorSettings_ShowCovers)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowCovers"), typeof(Binding._FCE_EditorSettings_ShowCovers));
			Binding.FCE_EditorSettings_IsInvincible = (Binding._FCE_EditorSettings_IsInvincible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsInvincible"), typeof(Binding._FCE_EditorSettings_IsInvincible));
			Binding.FCE_EditorSettings_SetInvincible = (Binding._FCE_EditorSettings_SetInvincible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetInvincible"), typeof(Binding._FCE_EditorSettings_SetInvincible));
			Binding.FCE_EditorSettings_IsInvisible = (Binding._FCE_EditorSettings_IsInvisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsInvisible"), typeof(Binding._FCE_EditorSettings_IsInvisible));
			Binding.FCE_EditorSettings_SetInvisible = (Binding._FCE_EditorSettings_SetInvisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetInvisible"), typeof(Binding._FCE_EditorSettings_SetInvisible));
			Binding.FCE_EditorSettings_IsSnappingObjectsToTerrain = (Binding._FCE_EditorSettings_IsSnappingObjectsToTerrain)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsSnappingObjectsToTerrain"), typeof(Binding._FCE_EditorSettings_IsSnappingObjectsToTerrain));
			Binding.FCE_EditorSettings_SetSnapObjectsToTerrain = (Binding._FCE_EditorSettings_SetSnapObjectsToTerrain)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetSnapObjectsToTerrain"), typeof(Binding._FCE_EditorSettings_SetSnapObjectsToTerrain));
			Binding.FCE_EditorSettings_IsAutoSnappingObjects = (Binding._FCE_EditorSettings_IsAutoSnappingObjects)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsAutoSnappingObjects"), typeof(Binding._FCE_EditorSettings_IsAutoSnappingObjects));
			Binding.FCE_EditorSettings_SetAutoSnappingObjects = (Binding._FCE_EditorSettings_SetAutoSnappingObjects)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetAutoSnappingObjects"), typeof(Binding._FCE_EditorSettings_SetAutoSnappingObjects));
			Binding.FCE_EditorSettings_IsAutoSnappingObjectsRotation = (Binding._FCE_EditorSettings_IsAutoSnappingObjectsRotation)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsAutoSnappingObjectsRotation"), typeof(Binding._FCE_EditorSettings_IsAutoSnappingObjectsRotation));
			Binding.FCE_EditorSettings_SetAutoSnappingObjectsRotation = (Binding._FCE_EditorSettings_SetAutoSnappingObjectsRotation)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetAutoSnappingObjectsRotation"), typeof(Binding._FCE_EditorSettings_SetAutoSnappingObjectsRotation));
			Binding.FCE_EditorSettings_IsAutoSnappingObjectsTerrain = (Binding._FCE_EditorSettings_IsAutoSnappingObjectsTerrain)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsAutoSnappingObjectsTerrain"), typeof(Binding._FCE_EditorSettings_IsAutoSnappingObjectsTerrain));
			Binding.FCE_EditorSettings_SetAutoSnappingObjectsTerrain = (Binding._FCE_EditorSettings_SetAutoSnappingObjectsTerrain)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetAutoSnappingObjectsTerrain"), typeof(Binding._FCE_EditorSettings_SetAutoSnappingObjectsTerrain));
			Binding.FCE_EditorSettings_IsCameraClippedTerrain = (Binding._FCE_EditorSettings_IsCameraClippedTerrain)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsCameraClippedTerrain"), typeof(Binding._FCE_EditorSettings_IsCameraClippedTerrain));
			Binding.FCE_EditorSettings_SetCameraClipTerrain = (Binding._FCE_EditorSettings_SetCameraClipTerrain)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetCameraClipTerrain"), typeof(Binding._FCE_EditorSettings_SetCameraClipTerrain));
			Binding.FCE_EditorSettings_IsCameraCollision = (Binding._FCE_EditorSettings_IsCameraCollision)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsCameraCollision"), typeof(Binding._FCE_EditorSettings_IsCameraCollision));
			Binding.FCE_EditorSettings_SetCameraCollision = (Binding._FCE_EditorSettings_SetCameraCollision)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetCameraCollision"), typeof(Binding._FCE_EditorSettings_SetCameraCollision));
			Binding.FCE_EditorSettings_GetEngineQuality = (Binding._FCE_EditorSettings_GetEngineQuality)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_GetEngineQuality"), typeof(Binding._FCE_EditorSettings_GetEngineQuality));
			Binding.FCE_EditorSettings_SetEngineQuality = (Binding._FCE_EditorSettings_SetEngineQuality)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetEngineQuality"), typeof(Binding._FCE_EditorSettings_SetEngineQuality));
			Binding.FCE_EditorSettings_IsKillDistanceOverride = (Binding._FCE_EditorSettings_IsKillDistanceOverride)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsKillDistanceOverride"), typeof(Binding._FCE_EditorSettings_IsKillDistanceOverride));
			Binding.FCE_EditorSettings_SetKillDistanceOverride = (Binding._FCE_EditorSettings_SetKillDistanceOverride)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_SetKillDistanceOverride"), typeof(Binding._FCE_EditorSettings_SetKillDistanceOverride));
			Binding.FCE_EditorSettings_IsOcclusionVisible = (Binding._FCE_EditorSettings_IsOcclusionVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_IsOcclusionVisible"), typeof(Binding._FCE_EditorSettings_IsOcclusionVisible));
			Binding.FCE_EditorSettings_ShowOcclusion = (Binding._FCE_EditorSettings_ShowOcclusion)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_EditorSettings_ShowOcclusion"), typeof(Binding._FCE_EditorSettings_ShowOcclusion));
			Binding.FCE_NomadDbIdVector_Create = (Binding._FCE_NomadDbIdVector_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_NomadDbIdVector_Create"), typeof(Binding._FCE_NomadDbIdVector_Create));
			Binding.FCE_NomadDbIdVector_Destroy = (Binding._FCE_NomadDbIdVector_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_NomadDbIdVector_Destroy"), typeof(Binding._FCE_NomadDbIdVector_Destroy));
			Binding.FCE_NomadDbIdVector_GetCount = (Binding._FCE_NomadDbIdVector_GetCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_NomadDbIdVector_GetCount"), typeof(Binding._FCE_NomadDbIdVector_GetCount));
			Binding.FCE_NomadDbIdVector_GetAt = (Binding._FCE_NomadDbIdVector_GetAt)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_NomadDbIdVector_GetAt"), typeof(Binding._FCE_NomadDbIdVector_GetAt));
			Binding.FCE_GameMode_GetAllGameModeDescDbIds = (Binding._FCE_GameMode_GetAllGameModeDescDbIds)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_GetAllGameModeDescDbIds"), typeof(Binding._FCE_GameMode_GetAllGameModeDescDbIds));
			Binding.FCE_GameMode_GetGameModeNameId = (Binding._FCE_GameMode_GetGameModeNameId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_GetGameModeNameId"), typeof(Binding._FCE_GameMode_GetGameModeNameId));
			Binding.FCE_GameMode_GetObjectiveDescDbIds = (Binding._FCE_GameMode_GetObjectiveDescDbIds)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_GetObjectiveDescDbIds"), typeof(Binding._FCE_GameMode_GetObjectiveDescDbIds));
			Binding.FCE_GameMode_GetObjectiveNameId = (Binding._FCE_GameMode_GetObjectiveNameId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_GetObjectiveNameId"), typeof(Binding._FCE_GameMode_GetObjectiveNameId));
			Binding.FCE_GameMode_GetObjectiveDescId = (Binding._FCE_GameMode_GetObjectiveDescId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_GetObjectiveDescId"), typeof(Binding._FCE_GameMode_GetObjectiveDescId));
			Binding.FCE_GameMode_GetCurrentObjectiveDescId = (Binding._FCE_GameMode_GetCurrentObjectiveDescId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_GetCurrentObjectiveDescId"), typeof(Binding._FCE_GameMode_GetCurrentObjectiveDescId));
			Binding.FCE_GameMode_SetCurrentObjectiveDescId = (Binding._FCE_GameMode_SetCurrentObjectiveDescId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_SetCurrentObjectiveDescId"), typeof(Binding._FCE_GameMode_SetCurrentObjectiveDescId));
			Binding.FCE_GameMode_GetCurrentGameModeDescId = (Binding._FCE_GameMode_GetCurrentGameModeDescId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_GetCurrentGameModeDescId"), typeof(Binding._FCE_GameMode_GetCurrentGameModeDescId));
			Binding.FCE_GameMode_SetCurrentGameModeDescId = (Binding._FCE_GameMode_SetCurrentGameModeDescId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_SetCurrentGameModeDescId"), typeof(Binding._FCE_GameMode_SetCurrentGameModeDescId));
			Binding.FCE_GameMode_GetObjectiveEnumValue = (Binding._FCE_GameMode_GetObjectiveEnumValue)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_GetObjectiveEnumValue"), typeof(Binding._FCE_GameMode_GetObjectiveEnumValue));
			Binding.FCE_GameMode_GetAllWildernessDbIds = (Binding._FCE_GameMode_GetAllWildernessDbIds)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_GetAllWildernessDbIds"), typeof(Binding._FCE_GameMode_GetAllWildernessDbIds));
			Binding.FCE_GameMode_WildernessNameId = (Binding._FCE_GameMode_WildernessNameId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_WildernessNameId"), typeof(Binding._FCE_GameMode_WildernessNameId));
			Binding.FCE_GameMode_WildernessScriptPathId = (Binding._FCE_GameMode_WildernessScriptPathId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameMode_WildernessScriptPathId"), typeof(Binding._FCE_GameMode_WildernessScriptPathId));
			Binding.FCE_GameProperty_GetAllPropertyIds = (Binding._FCE_GameProperty_GetAllPropertyIds)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetAllPropertyIds"), typeof(Binding._FCE_GameProperty_GetAllPropertyIds));
			Binding.FCE_GameProperty_GetPropertyID = (Binding._FCE_GameProperty_GetPropertyID)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyID"), typeof(Binding._FCE_GameProperty_GetPropertyID));
			Binding.FCE_GameProperty_GetPropertyType = (Binding._FCE_GameProperty_GetPropertyType)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyType"), typeof(Binding._FCE_GameProperty_GetPropertyType));
			Binding.FCE_GameProperty_GetPropertyValueType = (Binding._FCE_GameProperty_GetPropertyValueType)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyValueType"), typeof(Binding._FCE_GameProperty_GetPropertyValueType));
			Binding.FCE_GameProperty_GetSupportedObjectiveDescDbIds = (Binding._FCE_GameProperty_GetSupportedObjectiveDescDbIds)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetSupportedObjectiveDescDbIds"), typeof(Binding._FCE_GameProperty_GetSupportedObjectiveDescDbIds));
			Binding.FCE_GameProperty_GetPropertyChildID = (Binding._FCE_GameProperty_GetPropertyChildID)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyChildID"), typeof(Binding._FCE_GameProperty_GetPropertyChildID));
			Binding.FCE_GameProperty_GetPropertyMinValue = (Binding._FCE_GameProperty_GetPropertyMinValue)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyMinValue"), typeof(Binding._FCE_GameProperty_GetPropertyMinValue));
			Binding.FCE_GameProperty_GetPropertyMaxValue = (Binding._FCE_GameProperty_GetPropertyMaxValue)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyMaxValue"), typeof(Binding._FCE_GameProperty_GetPropertyMaxValue));
			Binding.FCE_GameProperty_GetPropertyResolution = (Binding._FCE_GameProperty_GetPropertyResolution)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyResolution"), typeof(Binding._FCE_GameProperty_GetPropertyResolution));
			Binding.FCE_GameProperty_GetPropertyDefaultFloat = (Binding._FCE_GameProperty_GetPropertyDefaultFloat)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyDefaultFloat"), typeof(Binding._FCE_GameProperty_GetPropertyDefaultFloat));
			Binding.FCE_GameProperty_GetPropertyDefaultBoolean = (Binding._FCE_GameProperty_GetPropertyDefaultBoolean)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyDefaultBoolean"), typeof(Binding._FCE_GameProperty_GetPropertyDefaultBoolean));
			Binding.FCE_GameProperty_GetPropertyDefaultPresetId = (Binding._FCE_GameProperty_GetPropertyDefaultPresetId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyDefaultPresetId"), typeof(Binding._FCE_GameProperty_GetPropertyDefaultPresetId));
			Binding.FCE_GameProperty_GetPropertyDisplayNameId = (Binding._FCE_GameProperty_GetPropertyDisplayNameId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyDisplayNameId"), typeof(Binding._FCE_GameProperty_GetPropertyDisplayNameId));
			Binding.FCE_GameProperty_GetPropertyCategoryNameId = (Binding._FCE_GameProperty_GetPropertyCategoryNameId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyCategoryNameId"), typeof(Binding._FCE_GameProperty_GetPropertyCategoryNameId));
			Binding.FCE_GameProperty_GetPropertyPresetIds = (Binding._FCE_GameProperty_GetPropertyPresetIds)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyPresetIds"), typeof(Binding._FCE_GameProperty_GetPropertyPresetIds));
			Binding.FCE_GameProperty_GetPropertyPresetDisplayNameId = (Binding._FCE_GameProperty_GetPropertyPresetDisplayNameId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameProperty_GetPropertyPresetDisplayNameId"), typeof(Binding._FCE_GameProperty_GetPropertyPresetDisplayNameId));
			Binding.FCE_MapTag_GetAllDbIds = (Binding._FCE_MapTag_GetAllDbIds)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetAllDbIds"), typeof(Binding._FCE_MapTag_GetAllDbIds));
			Binding.FCE_MapTag_GetDisplayNameId = (Binding._FCE_MapTag_GetDisplayNameId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetDisplayNameId"), typeof(Binding._FCE_MapTag_GetDisplayNameId));
			Binding.FCE_MapTag_GetObjectiveRef = (Binding._FCE_MapTag_GetObjectiveRef)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetObjectiveRef"), typeof(Binding._FCE_MapTag_GetObjectiveRef));
			Binding.FCE_MapTag_GetModifierRefs = (Binding._FCE_MapTag_GetModifierRefs)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetModifierRefs"), typeof(Binding._FCE_MapTag_GetModifierRefs));
			Binding.FCE_MapTag_GetAvailableGameModes = (Binding._FCE_MapTag_GetAvailableGameModes)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetAvailableGameModes"), typeof(Binding._FCE_MapTag_GetAvailableGameModes));
			Binding.FCE_MapTag_GetPresetRefs = (Binding._FCE_MapTag_GetPresetRefs)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetPresetRefs"), typeof(Binding._FCE_MapTag_GetPresetRefs));
			Binding.FCE_MapTag_GetIsAuto = (Binding._FCE_MapTag_GetIsAuto)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetIsAuto"), typeof(Binding._FCE_MapTag_GetIsAuto));
			Binding.FCE_MapTag_GetIsEnum = (Binding._FCE_MapTag_GetIsEnum)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetIsEnum"), typeof(Binding._FCE_MapTag_GetIsEnum));
			Binding.FCE_MapTag_GetIsEnumDefault = (Binding._FCE_MapTag_GetIsEnumDefault)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetIsEnumDefault"), typeof(Binding._FCE_MapTag_GetIsEnumDefault));
			Binding.FCE_MapTag_GetPriority = (Binding._FCE_MapTag_GetPriority)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_MapTag_GetPriority"), typeof(Binding._FCE_MapTag_GetPriority));
			Binding.FCE_PC_KeyboardKeyEvent = (Binding._FCE_PC_KeyboardKeyEvent)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_PC_KeyboardKeyEvent"), typeof(Binding._FCE_PC_KeyboardKeyEvent));
			Binding.FCE_Draw_BeginGroup = (Binding._FCE_Draw_BeginGroup)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_BeginGroup"), typeof(Binding._FCE_Draw_BeginGroup));
			Binding.FCE_Draw_EndGroup = (Binding._FCE_Draw_EndGroup)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_EndGroup"), typeof(Binding._FCE_Draw_EndGroup));
			Binding.FCE_Draw_ScreenCircleOutlined = (Binding._FCE_Draw_ScreenCircleOutlined)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_ScreenCircleOutlined"), typeof(Binding._FCE_Draw_ScreenCircleOutlined));
			Binding.FCE_Draw_ScreenRectangleOutlined = (Binding._FCE_Draw_ScreenRectangleOutlined)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_ScreenRectangleOutlined"), typeof(Binding._FCE_Draw_ScreenRectangleOutlined));
			Binding.FCE_Draw_Quad = (Binding._FCE_Draw_Quad)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_Quad"), typeof(Binding._FCE_Draw_Quad));
			Binding.FCE_Draw_Square = (Binding._FCE_Draw_Square)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_Square"), typeof(Binding._FCE_Draw_Square));
			Binding.FCE_Draw_Terrain_Circle = (Binding._FCE_Draw_Terrain_Circle)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_Terrain_Circle"), typeof(Binding._FCE_Draw_Terrain_Circle));
			Binding.FCE_Draw_Terrain_Square = (Binding._FCE_Draw_Terrain_Square)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_Terrain_Square"), typeof(Binding._FCE_Draw_Terrain_Square));
			Binding.FCE_Draw_Arrow = (Binding._FCE_Draw_Arrow)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_Arrow"), typeof(Binding._FCE_Draw_Arrow));
			Binding.FCE_Draw_Dot = (Binding._FCE_Draw_Dot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_Dot"), typeof(Binding._FCE_Draw_Dot));
			Binding.FCE_Draw_SegmentedLineSegment = (Binding._FCE_Draw_SegmentedLineSegment)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_SegmentedLineSegment"), typeof(Binding._FCE_Draw_SegmentedLineSegment));
			Binding.FCE_Draw_WireBoxFromBottomZ = (Binding._FCE_Draw_WireBoxFromBottomZ)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_WireBoxFromBottomZ"), typeof(Binding._FCE_Draw_WireBoxFromBottomZ));
			Binding.FCE_Draw_WireRegionFromTerrain = (Binding._FCE_Draw_WireRegionFromTerrain)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Draw_WireRegionFromTerrain"), typeof(Binding._FCE_Draw_WireRegionFromTerrain));
			Binding.FCE_Camera_Input_Forward = (Binding._FCE_Camera_Input_Forward)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_Input_Forward"), typeof(Binding._FCE_Camera_Input_Forward));
			Binding.FCE_Camera_Input_Lateral = (Binding._FCE_Camera_Input_Lateral)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_Input_Lateral"), typeof(Binding._FCE_Camera_Input_Lateral));
			Binding.FCE_Camera_GetPos = (Binding._FCE_Camera_GetPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_GetPos"), typeof(Binding._FCE_Camera_GetPos));
			Binding.FCE_Camera_SetPos = (Binding._FCE_Camera_SetPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_SetPos"), typeof(Binding._FCE_Camera_SetPos));
			Binding.FCE_Camera_GetAngles = (Binding._FCE_Camera_GetAngles)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_GetAngles"), typeof(Binding._FCE_Camera_GetAngles));
			Binding.FCE_Camera_SetAngles = (Binding._FCE_Camera_SetAngles)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_SetAngles"), typeof(Binding._FCE_Camera_SetAngles));
			Binding.FCE_Camera_Rotate = (Binding._FCE_Camera_Rotate)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_Rotate"), typeof(Binding._FCE_Camera_Rotate));
			Binding.FCE_Camera_GetFrontVector = (Binding._FCE_Camera_GetFrontVector)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_GetFrontVector"), typeof(Binding._FCE_Camera_GetFrontVector));
			Binding.FCE_Camera_GetRightVector = (Binding._FCE_Camera_GetRightVector)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_GetRightVector"), typeof(Binding._FCE_Camera_GetRightVector));
			Binding.FCE_Camera_GetUpVector = (Binding._FCE_Camera_GetUpVector)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_GetUpVector"), typeof(Binding._FCE_Camera_GetUpVector));
			Binding.FCE_Camera_GetSpeed = (Binding._FCE_Camera_GetSpeed)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_GetSpeed"), typeof(Binding._FCE_Camera_GetSpeed));
			Binding.FCE_Camera_SetSpeed = (Binding._FCE_Camera_SetSpeed)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_SetSpeed"), typeof(Binding._FCE_Camera_SetSpeed));
			Binding.FCE_Camera_SetSpeedFactor = (Binding._FCE_Camera_SetSpeedFactor)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_SetSpeedFactor"), typeof(Binding._FCE_Camera_SetSpeedFactor));
			Binding.FCE_Camera_GetFOV = (Binding._FCE_Camera_GetFOV)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_GetFOV"), typeof(Binding._FCE_Camera_GetFOV));
			Binding.FCE_Camera_AlignToSelection = (Binding._FCE_Camera_AlignToSelection)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_AlignToSelection"), typeof(Binding._FCE_Camera_AlignToSelection));
			Binding.FCE_Camera_AlignToObject = (Binding._FCE_Camera_AlignToObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Camera_AlignToObject"), typeof(Binding._FCE_Camera_AlignToObject));
			Binding.FCE_Brush_Create = (Binding._FCE_Brush_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Brush_Create"), typeof(Binding._FCE_Brush_Create));
			Binding.FCE_Brush_Destroy = (Binding._FCE_Brush_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Brush_Destroy"), typeof(Binding._FCE_Brush_Destroy));
			Binding.FCE_Terrain_Bump = (Binding._FCE_Terrain_Bump)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Bump"), typeof(Binding._FCE_Terrain_Bump));
			Binding.FCE_Terrain_Bump_End = (Binding._FCE_Terrain_Bump_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Bump_End"), typeof(Binding._FCE_Terrain_Bump_End));
			Binding.FCE_Terrain_RaiseLower = (Binding._FCE_Terrain_RaiseLower)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_RaiseLower"), typeof(Binding._FCE_Terrain_RaiseLower));
			Binding.FCE_Terrain_RaiseLower_End = (Binding._FCE_Terrain_RaiseLower_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_RaiseLower_End"), typeof(Binding._FCE_Terrain_RaiseLower_End));
			Binding.FCE_Terrain_SetHeight = (Binding._FCE_Terrain_SetHeight)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_SetHeight"), typeof(Binding._FCE_Terrain_SetHeight));
			Binding.FCE_Terrain_SetHeight_End = (Binding._FCE_Terrain_SetHeight_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_SetHeight_End"), typeof(Binding._FCE_Terrain_SetHeight_End));
			Binding.FCE_Terrain_GetAverageHeight = (Binding._FCE_Terrain_GetAverageHeight)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_GetAverageHeight"), typeof(Binding._FCE_Terrain_GetAverageHeight));
			Binding.FCE_Terrain_Average = (Binding._FCE_Terrain_Average)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Average"), typeof(Binding._FCE_Terrain_Average));
			Binding.FCE_Terrain_Average_End = (Binding._FCE_Terrain_Average_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Average_End"), typeof(Binding._FCE_Terrain_Average_End));
			Binding.FCE_Terrain_Grab_Begin = (Binding._FCE_Terrain_Grab_Begin)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Grab_Begin"), typeof(Binding._FCE_Terrain_Grab_Begin));
			Binding.FCE_Terrain_Grab = (Binding._FCE_Terrain_Grab)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Grab"), typeof(Binding._FCE_Terrain_Grab));
			Binding.FCE_Terrain_Grab_End = (Binding._FCE_Terrain_Grab_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Grab_End"), typeof(Binding._FCE_Terrain_Grab_End));
			Binding.FCE_Terrain_Smooth = (Binding._FCE_Terrain_Smooth)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Smooth"), typeof(Binding._FCE_Terrain_Smooth));
			Binding.FCE_Terrain_Smooth_End = (Binding._FCE_Terrain_Smooth_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Smooth_End"), typeof(Binding._FCE_Terrain_Smooth_End));
			Binding.FCE_Terrain_Ramp = (Binding._FCE_Terrain_Ramp)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Ramp"), typeof(Binding._FCE_Terrain_Ramp));
			Binding.FCE_Terrain_Terrace = (Binding._FCE_Terrain_Terrace)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Terrace"), typeof(Binding._FCE_Terrain_Terrace));
			Binding.FCE_Terrain_Terrace_End = (Binding._FCE_Terrain_Terrace_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Terrace_End"), typeof(Binding._FCE_Terrain_Terrace_End));
			Binding.FCE_Terrain_Noise_Begin = (Binding._FCE_Terrain_Noise_Begin)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Noise_Begin"), typeof(Binding._FCE_Terrain_Noise_Begin));
			Binding.FCE_Terrain_Noise = (Binding._FCE_Terrain_Noise)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Noise"), typeof(Binding._FCE_Terrain_Noise));
			Binding.FCE_Terrain_Noise_End = (Binding._FCE_Terrain_Noise_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Noise_End"), typeof(Binding._FCE_Terrain_Noise_End));
			Binding.FCE_Terrain_Erosion = (Binding._FCE_Terrain_Erosion)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Erosion"), typeof(Binding._FCE_Terrain_Erosion));
			Binding.FCE_Terrain_Erosion_End = (Binding._FCE_Terrain_Erosion_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Erosion_End"), typeof(Binding._FCE_Terrain_Erosion_End));
			Binding.FCE_Terrain_Hole = (Binding._FCE_Terrain_Hole)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Hole"), typeof(Binding._FCE_Terrain_Hole));
			Binding.FCE_Terrain_Hole_End = (Binding._FCE_Terrain_Hole_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Terrain_Hole_End"), typeof(Binding._FCE_Terrain_Hole_End));
			Binding.FCE_Inventory_Entry_IsDirectory = (Binding._FCE_Inventory_Entry_IsDirectory)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Entry_IsDirectory"), typeof(Binding._FCE_Inventory_Entry_IsDirectory));
			Binding.FCE_Inventory_Entry_IsDeleted = (Binding._FCE_Inventory_Entry_IsDeleted)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Entry_IsDeleted"), typeof(Binding._FCE_Inventory_Entry_IsDeleted));
			Binding.FCE_Inventory_Entry_SetDeleted = (Binding._FCE_Inventory_Entry_SetDeleted)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Entry_SetDeleted"), typeof(Binding._FCE_Inventory_Entry_SetDeleted));
			Binding.FCE_Inventory_Entry_ClearChildren = (Binding._FCE_Inventory_Entry_ClearChildren)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Entry_ClearChildren"), typeof(Binding._FCE_Inventory_Entry_ClearChildren));
			Binding.FCE_Inventory_Entry_AddChild = (Binding._FCE_Inventory_Entry_AddChild)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Entry_AddChild"), typeof(Binding._FCE_Inventory_Entry_AddChild));
			Binding.FCE_Inventory_Entry_SetChildIndex = (Binding._FCE_Inventory_Entry_SetChildIndex)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Entry_SetChildIndex"), typeof(Binding._FCE_Inventory_Entry_SetChildIndex));
			Binding.FCE_Inventory_Entry_OpenThumbnailData = (Binding._FCE_Inventory_Entry_OpenThumbnailData)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Entry_OpenThumbnailData"), typeof(Binding._FCE_Inventory_Entry_OpenThumbnailData));
			Binding.FCE_Inventory_Entry_CloseThumbnailData = (Binding._FCE_Inventory_Entry_CloseThumbnailData)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Entry_CloseThumbnailData"), typeof(Binding._FCE_Inventory_Entry_CloseThumbnailData));
			Binding.FCE_Inventory_Object_GetRoot = (Binding._FCE_Inventory_Object_GetRoot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetRoot"), typeof(Binding._FCE_Inventory_Object_GetRoot));
			Binding.FCE_Inventory_Object_CreatePrefabObject = (Binding._FCE_Inventory_Object_CreatePrefabObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_CreatePrefabObject"), typeof(Binding._FCE_Inventory_Object_CreatePrefabObject));
			Binding.FCE_Inventory_Object_CreateDirectory = (Binding._FCE_Inventory_Object_CreateDirectory)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_CreateDirectory"), typeof(Binding._FCE_Inventory_Object_CreateDirectory));
			Binding.FCE_Inventory_Object_CreateFilterDirectory = (Binding._FCE_Inventory_Object_CreateFilterDirectory)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_CreateFilterDirectory"), typeof(Binding._FCE_Inventory_Object_CreateFilterDirectory));
			Binding.FCE_Inventory_Object_DestroyFilterDirectory = (Binding._FCE_Inventory_Object_DestroyFilterDirectory)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_DestroyFilterDirectory"), typeof(Binding._FCE_Inventory_Object_DestroyFilterDirectory));
			Binding.FCE_Inventory_Object_SearchInventoryEntry = (Binding._FCE_Inventory_Object_SearchInventoryEntry)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SearchInventoryEntry"), typeof(Binding._FCE_Inventory_Object_SearchInventoryEntry));
			Binding.FCE_Inventory_Object_GetParent = (Binding._FCE_Inventory_Object_GetParent)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetParent"), typeof(Binding._FCE_Inventory_Object_GetParent));
			Binding.FCE_Inventory_Object_SetParent = (Binding._FCE_Inventory_Object_SetParent)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SetParent"), typeof(Binding._FCE_Inventory_Object_SetParent));
			Binding.FCE_Inventory_Object_IsDirectory = (Binding._FCE_Inventory_Object_IsDirectory)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_IsDirectory"), typeof(Binding._FCE_Inventory_Object_IsDirectory));
			Binding.FCE_Inventory_Object_GetChildCount = (Binding._FCE_Inventory_Object_GetChildCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetChildCount"), typeof(Binding._FCE_Inventory_Object_GetChildCount));
			Binding.FCE_Inventory_Object_GetChild = (Binding._FCE_Inventory_Object_GetChild)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetChild"), typeof(Binding._FCE_Inventory_Object_GetChild));
			Binding.FCE_Inventory_Object_GetId = (Binding._FCE_Inventory_Object_GetId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetId"), typeof(Binding._FCE_Inventory_Object_GetId));
			Binding.FCE_Inventory_Object_GetIdString = (Binding._FCE_Inventory_Object_GetIdString)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetIdString"), typeof(Binding._FCE_Inventory_Object_GetIdString));
			Binding.FCE_Inventory_Object_SetIdString = (Binding._FCE_Inventory_Object_SetIdString)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SetIdString"), typeof(Binding._FCE_Inventory_Object_SetIdString));
			Binding.FCE_Inventory_Object_GetDisplay = (Binding._FCE_Inventory_Object_GetDisplay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetDisplay"), typeof(Binding._FCE_Inventory_Object_GetDisplay));
			Binding.FCE_Inventory_Object_SetDisplay = (Binding._FCE_Inventory_Object_SetDisplay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SetDisplay"), typeof(Binding._FCE_Inventory_Object_SetDisplay));
			Binding.FCE_Inventory_Object_GetTags = (Binding._FCE_Inventory_Object_GetTags)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetTags"), typeof(Binding._FCE_Inventory_Object_GetTags));
			Binding.FCE_Inventory_Object_SetTags = (Binding._FCE_Inventory_Object_SetTags)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SetTags"), typeof(Binding._FCE_Inventory_Object_SetTags));
			Binding.FCE_Inventory_Object_GetSourceType = (Binding._FCE_Inventory_Object_GetSourceType)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetSourceType"), typeof(Binding._FCE_Inventory_Object_GetSourceType));
			Binding.FCE_Inventory_Object_GetBMin = (Binding._FCE_Inventory_Object_GetBMin)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetBMin"), typeof(Binding._FCE_Inventory_Object_GetBMin));
			Binding.FCE_Inventory_Object_GetBMax = (Binding._FCE_Inventory_Object_GetBMax)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetBMax"), typeof(Binding._FCE_Inventory_Object_GetBMax));
			Binding.FCE_Inventory_Object_GetSize = (Binding._FCE_Inventory_Object_GetSize)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetSize"), typeof(Binding._FCE_Inventory_Object_GetSize));
			Binding.FCE_Inventory_Object_IsAI = (Binding._FCE_Inventory_Object_IsAI)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_IsAI"), typeof(Binding._FCE_Inventory_Object_IsAI));
			Binding.FCE_Inventory_Object_IsObjectType = (Binding._FCE_Inventory_Object_IsObjectType)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_IsObjectType"), typeof(Binding._FCE_Inventory_Object_IsObjectType));
			Binding.FCE_Inventory_Object_IsAutoOrientation = (Binding._FCE_Inventory_Object_IsAutoOrientation)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_IsAutoOrientation"), typeof(Binding._FCE_Inventory_Object_IsAutoOrientation));
			Binding.FCE_Inventory_Object_GetZOffset = (Binding._FCE_Inventory_Object_GetZOffset)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetZOffset"), typeof(Binding._FCE_Inventory_Object_GetZOffset));
			Binding.FCE_Inventory_Object_SetZOffset = (Binding._FCE_Inventory_Object_SetZOffset)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SetZOffset"), typeof(Binding._FCE_Inventory_Object_SetZOffset));
			Binding.FCE_Inventory_Object_SaveChanges = (Binding._FCE_Inventory_Object_SaveChanges)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SaveChanges"), typeof(Binding._FCE_Inventory_Object_SaveChanges));
			Binding.FCE_Inventory_Object_ClearPivots = (Binding._FCE_Inventory_Object_ClearPivots)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_ClearPivots"), typeof(Binding._FCE_Inventory_Object_ClearPivots));
			Binding.FCE_Inventory_Object_AddPivot = (Binding._FCE_Inventory_Object_AddPivot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_AddPivot"), typeof(Binding._FCE_Inventory_Object_AddPivot));
			Binding.FCE_Inventory_Object_SetPivot = (Binding._FCE_Inventory_Object_SetPivot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SetPivot"), typeof(Binding._FCE_Inventory_Object_SetPivot));
			Binding.FCE_Inventory_Object_SetPivots = (Binding._FCE_Inventory_Object_SetPivots)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SetPivots"), typeof(Binding._FCE_Inventory_Object_SetPivots));
			Binding.FCE_Inventory_Object_IsAutoPivot = (Binding._FCE_Inventory_Object_IsAutoPivot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_IsAutoPivot"), typeof(Binding._FCE_Inventory_Object_IsAutoPivot));
			Binding.FCE_Inventory_Object_SetAutoPivot = (Binding._FCE_Inventory_Object_SetAutoPivot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_SetAutoPivot"), typeof(Binding._FCE_Inventory_Object_SetAutoPivot));
			Binding.FCE_Inventory_Object_GetPivotCount = (Binding._FCE_Inventory_Object_GetPivotCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetPivotCount"), typeof(Binding._FCE_Inventory_Object_GetPivotCount));
			Binding.FCE_Inventory_Object_HasComponent = (Binding._FCE_Inventory_Object_HasComponent)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_HasComponent"), typeof(Binding._FCE_Inventory_Object_HasComponent));
			Binding.FCE_Inventory_Object_GetArchetypeId = (Binding._FCE_Inventory_Object_GetArchetypeId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetArchetypeId"), typeof(Binding._FCE_Inventory_Object_GetArchetypeId));
			Binding.FCE_Inventory_Object_GetWaveNum = (Binding._FCE_Inventory_Object_GetWaveNum)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_GetWaveNum"), typeof(Binding._FCE_Inventory_Object_GetWaveNum));
			Binding.FCE_Inventory_Object_IsObjectiveGameplayObject = (Binding._FCE_Inventory_Object_IsObjectiveGameplayObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Object_IsObjectiveGameplayObject"), typeof(Binding._FCE_Inventory_Object_IsObjectiveGameplayObject));
			Binding.FCE_Inventory_Collection_GetRoot = (Binding._FCE_Inventory_Collection_GetRoot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Collection_GetRoot"), typeof(Binding._FCE_Inventory_Collection_GetRoot));
			Binding.FCE_Inventory_Collection_GetParent = (Binding._FCE_Inventory_Collection_GetParent)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Collection_GetParent"), typeof(Binding._FCE_Inventory_Collection_GetParent));
			Binding.FCE_Inventory_Collection_GetChildCount = (Binding._FCE_Inventory_Collection_GetChildCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Collection_GetChildCount"), typeof(Binding._FCE_Inventory_Collection_GetChildCount));
			Binding.FCE_Inventory_Collection_GetChild = (Binding._FCE_Inventory_Collection_GetChild)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Collection_GetChild"), typeof(Binding._FCE_Inventory_Collection_GetChild));
			Binding.FCE_Inventory_Collection_GetDisplay = (Binding._FCE_Inventory_Collection_GetDisplay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Collection_GetDisplay"), typeof(Binding._FCE_Inventory_Collection_GetDisplay));
			Binding.FCE_Inventory_Collection_GetBurnProfile = (Binding._FCE_Inventory_Collection_GetBurnProfile)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Collection_GetBurnProfile"), typeof(Binding._FCE_Inventory_Collection_GetBurnProfile));
			Binding.FCE_Inventory_Texture_GetRoot = (Binding._FCE_Inventory_Texture_GetRoot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Texture_GetRoot"), typeof(Binding._FCE_Inventory_Texture_GetRoot));
			Binding.FCE_Inventory_Texture_GetParent = (Binding._FCE_Inventory_Texture_GetParent)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Texture_GetParent"), typeof(Binding._FCE_Inventory_Texture_GetParent));
			Binding.FCE_Inventory_Texture_GetChildCount = (Binding._FCE_Inventory_Texture_GetChildCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Texture_GetChildCount"), typeof(Binding._FCE_Inventory_Texture_GetChildCount));
			Binding.FCE_Inventory_Texture_GetChild = (Binding._FCE_Inventory_Texture_GetChild)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Texture_GetChild"), typeof(Binding._FCE_Inventory_Texture_GetChild));
			Binding.FCE_Inventory_Texture_GetDisplay = (Binding._FCE_Inventory_Texture_GetDisplay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Texture_GetDisplay"), typeof(Binding._FCE_Inventory_Texture_GetDisplay));
			Binding.FCE_Inventory_Water_GetRoot = (Binding._FCE_Inventory_Water_GetRoot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Water_GetRoot"), typeof(Binding._FCE_Inventory_Water_GetRoot));
			Binding.FCE_Inventory_Water_GetParent = (Binding._FCE_Inventory_Water_GetParent)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Water_GetParent"), typeof(Binding._FCE_Inventory_Water_GetParent));
			Binding.FCE_Inventory_Water_GetChildCount = (Binding._FCE_Inventory_Water_GetChildCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Water_GetChildCount"), typeof(Binding._FCE_Inventory_Water_GetChildCount));
			Binding.FCE_Inventory_Water_GetChild = (Binding._FCE_Inventory_Water_GetChild)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Water_GetChild"), typeof(Binding._FCE_Inventory_Water_GetChild));
			Binding.FCE_Inventory_Water_GetDisplay = (Binding._FCE_Inventory_Water_GetDisplay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Water_GetDisplay"), typeof(Binding._FCE_Inventory_Water_GetDisplay));
			Binding.FCE_Inventory_Water_GetFromId = (Binding._FCE_Inventory_Water_GetFromId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Water_GetFromId"), typeof(Binding._FCE_Inventory_Water_GetFromId));
			Binding.FCE_Inventory_Spline_GetRoot = (Binding._FCE_Inventory_Spline_GetRoot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Spline_GetRoot"), typeof(Binding._FCE_Inventory_Spline_GetRoot));
			Binding.FCE_Inventory_Spline_GetParent = (Binding._FCE_Inventory_Spline_GetParent)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Spline_GetParent"), typeof(Binding._FCE_Inventory_Spline_GetParent));
			Binding.FCE_Inventory_Spline_GetChildCount = (Binding._FCE_Inventory_Spline_GetChildCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Spline_GetChildCount"), typeof(Binding._FCE_Inventory_Spline_GetChildCount));
			Binding.FCE_Inventory_Spline_GetChild = (Binding._FCE_Inventory_Spline_GetChild)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Spline_GetChild"), typeof(Binding._FCE_Inventory_Spline_GetChild));
			Binding.FCE_Inventory_Spline_GetDisplay = (Binding._FCE_Inventory_Spline_GetDisplay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Spline_GetDisplay"), typeof(Binding._FCE_Inventory_Spline_GetDisplay));
			Binding.FCE_Inventory_Spline_GetDefaultWidth = (Binding._FCE_Inventory_Spline_GetDefaultWidth)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Spline_GetDefaultWidth"), typeof(Binding._FCE_Inventory_Spline_GetDefaultWidth));
			Binding.FCE_Inventory_Region_GetRoot = (Binding._FCE_Inventory_Region_GetRoot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Region_GetRoot"), typeof(Binding._FCE_Inventory_Region_GetRoot));
			Binding.FCE_Inventory_Region_GetParent = (Binding._FCE_Inventory_Region_GetParent)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Region_GetParent"), typeof(Binding._FCE_Inventory_Region_GetParent));
			Binding.FCE_Inventory_Region_GetChildCount = (Binding._FCE_Inventory_Region_GetChildCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Region_GetChildCount"), typeof(Binding._FCE_Inventory_Region_GetChildCount));
			Binding.FCE_Inventory_Region_GetChild = (Binding._FCE_Inventory_Region_GetChild)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Region_GetChild"), typeof(Binding._FCE_Inventory_Region_GetChild));
			Binding.FCE_Inventory_Region_GetDisplay = (Binding._FCE_Inventory_Region_GetDisplay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Region_GetDisplay"), typeof(Binding._FCE_Inventory_Region_GetDisplay));
			Binding.FCE_Inventory_Region_GetEntryFromId = (Binding._FCE_Inventory_Region_GetEntryFromId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Region_GetEntryFromId"), typeof(Binding._FCE_Inventory_Region_GetEntryFromId));
			Binding.FCE_Inventory_Region_GetDirectoryFromId = (Binding._FCE_Inventory_Region_GetDirectoryFromId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Region_GetDirectoryFromId"), typeof(Binding._FCE_Inventory_Region_GetDirectoryFromId));
			Binding.FCE_Inventory_Region_GetRegionId = (Binding._FCE_Inventory_Region_GetRegionId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Inventory_Region_GetRegionId"), typeof(Binding._FCE_Inventory_Region_GetRegionId));
			Binding.FCE_Object_Create_FromEntry = (Binding._FCE_Object_Create_FromEntry)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_Create_FromEntry"), typeof(Binding._FCE_Object_Create_FromEntry));
			Binding.FCE_Object_Destroy = (Binding._FCE_Object_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_Destroy"), typeof(Binding._FCE_Object_Destroy));
			Binding.FCE_Object_AddRef = (Binding._FCE_Object_AddRef)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_AddRef"), typeof(Binding._FCE_Object_AddRef));
			Binding.FCE_Object_Release = (Binding._FCE_Object_Release)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_Release"), typeof(Binding._FCE_Object_Release));
			Binding.FCE_Object_Clone = (Binding._FCE_Object_Clone)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_Clone"), typeof(Binding._FCE_Object_Clone));
			Binding.FCE_Object_IsLoaded = (Binding._FCE_Object_IsLoaded)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_IsLoaded"), typeof(Binding._FCE_Object_IsLoaded));
			Binding.FCE_Object_GetEntry = (Binding._FCE_Object_GetEntry)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_GetEntry"), typeof(Binding._FCE_Object_GetEntry));
			Binding.FCE_Object_GetPos = (Binding._FCE_Object_GetPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_GetPos"), typeof(Binding._FCE_Object_GetPos));
			Binding.FCE_Object_SetPos = (Binding._FCE_Object_SetPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_SetPos"), typeof(Binding._FCE_Object_SetPos));
			Binding.FCE_Object_GetAngles = (Binding._FCE_Object_GetAngles)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_GetAngles"), typeof(Binding._FCE_Object_GetAngles));
			Binding.FCE_Object_SetAngles = (Binding._FCE_Object_SetAngles)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_SetAngles"), typeof(Binding._FCE_Object_SetAngles));
			Binding.FCE_Object_GetBounds = (Binding._FCE_Object_GetBounds)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_GetBounds"), typeof(Binding._FCE_Object_GetBounds));
			Binding.FCE_Object_IsVisible = (Binding._FCE_Object_IsVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_IsVisible"), typeof(Binding._FCE_Object_IsVisible));
			Binding.FCE_Object_SetVisible = (Binding._FCE_Object_SetVisible)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_SetVisible"), typeof(Binding._FCE_Object_SetVisible));
			Binding.FCE_Object_SetHighlight = (Binding._FCE_Object_SetHighlight)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_SetHighlight"), typeof(Binding._FCE_Object_SetHighlight));
			Binding.FCE_Object_SetFreeze = (Binding._FCE_Object_SetFreeze)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_SetFreeze"), typeof(Binding._FCE_Object_SetFreeze));
			Binding.FCE_Object_DropToGround = (Binding._FCE_Object_DropToGround)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_DropToGround"), typeof(Binding._FCE_Object_DropToGround));
			Binding.FCE_Object_ComputeAutoOrientation = (Binding._FCE_Object_ComputeAutoOrientation)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_ComputeAutoOrientation"), typeof(Binding._FCE_Object_ComputeAutoOrientation));
			Binding.FCE_Object_GetPivot = (Binding._FCE_Object_GetPivot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_GetPivot"), typeof(Binding._FCE_Object_GetPivot));
			Binding.FCE_Object_GetClosestPivot = (Binding._FCE_Object_GetClosestPivot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_GetClosestPivot"), typeof(Binding._FCE_Object_GetClosestPivot));
			Binding.FCE_Object_SnapToClosestObject = (Binding._FCE_Object_SnapToClosestObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_SnapToClosestObject"), typeof(Binding._FCE_Object_SnapToClosestObject));
			Binding.FCE_Object_GetPhysEntities = (Binding._FCE_Object_GetPhysEntities)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Object_GetPhysEntities"), typeof(Binding._FCE_Object_GetPhysEntities));
			Binding.FCE_AI_ShowWaveCallback = (Binding._FCE_AI_ShowWaveCallback)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_ShowWaveCallback"), typeof(Binding._FCE_AI_ShowWaveCallback));
			Binding.FCE_AI_SetEntityToSpawn = (Binding._FCE_AI_SetEntityToSpawn)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_SetEntityToSpawn"), typeof(Binding._FCE_AI_SetEntityToSpawn));
			Binding.FCE_AI_SetWaveTransition = (Binding._FCE_AI_SetWaveTransition)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_SetWaveTransition"), typeof(Binding._FCE_AI_SetWaveTransition));
			Binding.FCE_AI_GetWaveTransition = (Binding._FCE_AI_GetWaveTransition)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_GetWaveTransition"), typeof(Binding._FCE_AI_GetWaveTransition));
			Binding.FCE_AI_SetAmbientProperties = (Binding._FCE_AI_SetAmbientProperties)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_SetAmbientProperties"), typeof(Binding._FCE_AI_SetAmbientProperties));
			Binding.FCE_AI_GetAmbientProperties = (Binding._FCE_AI_GetAmbientProperties)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_GetAmbientProperties"), typeof(Binding._FCE_AI_GetAmbientProperties));
			Binding.FCE_AI_SetSTPProperties = (Binding._FCE_AI_SetSTPProperties)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_SetSTPProperties"), typeof(Binding._FCE_AI_SetSTPProperties));
			Binding.FCE_AI_GetSTPProperties = (Binding._FCE_AI_GetSTPProperties)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_GetSTPProperties"), typeof(Binding._FCE_AI_GetSTPProperties));
			Binding.FCE_AI_SetPatrolProperties = (Binding._FCE_AI_SetPatrolProperties)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_SetPatrolProperties"), typeof(Binding._FCE_AI_SetPatrolProperties));
			Binding.FCE_AI_GetPatrolProperties = (Binding._FCE_AI_GetPatrolProperties)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_GetPatrolProperties"), typeof(Binding._FCE_AI_GetPatrolProperties));
			Binding.FCE_AI_SetAIGroup = (Binding._FCE_AI_SetAIGroup)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_SetAIGroup"), typeof(Binding._FCE_AI_SetAIGroup));
			Binding.FCE_AI_IsValidObjectiveEntity = (Binding._FCE_AI_IsValidObjectiveEntity)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_IsValidObjectiveEntity"), typeof(Binding._FCE_AI_IsValidObjectiveEntity));
			Binding.FCE_AI_ShowWaveOnly = (Binding._FCE_AI_ShowWaveOnly)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_ShowWaveOnly"), typeof(Binding._FCE_AI_ShowWaveOnly));
			Binding.FCE_AI_GetStpUsage = (Binding._FCE_AI_GetStpUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_AI_GetStpUsage"), typeof(Binding._FCE_AI_GetStpUsage));
			Binding.FCE_ObjectManager_GetObjectFromScreenPoint = (Binding._FCE_ObjectManager_GetObjectFromScreenPoint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectManager_GetObjectFromScreenPoint"), typeof(Binding._FCE_ObjectManager_GetObjectFromScreenPoint));
			Binding.FCE_ObjectManager_GetObjectsFromScreenRect = (Binding._FCE_ObjectManager_GetObjectsFromScreenRect)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectManager_GetObjectsFromScreenRect"), typeof(Binding._FCE_ObjectManager_GetObjectsFromScreenRect));
			Binding.FCE_ObjectManager_GetObjectsFromMagicWand = (Binding._FCE_ObjectManager_GetObjectsFromMagicWand)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectManager_GetObjectsFromMagicWand"), typeof(Binding._FCE_ObjectManager_GetObjectsFromMagicWand));
			Binding.FCE_ObjectManager_SetViewportPickingPos = (Binding._FCE_ObjectManager_SetViewportPickingPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectManager_SetViewportPickingPos"), typeof(Binding._FCE_ObjectManager_SetViewportPickingPos));
			Binding.FCE_ObjectManager_UnfreezeObjects = (Binding._FCE_ObjectManager_UnfreezeObjects)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectManager_UnfreezeObjects"), typeof(Binding._FCE_ObjectManager_UnfreezeObjects));
			Binding.FCE_ObjectManager_GetObjectCount = (Binding._FCE_ObjectManager_GetObjectCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectManager_GetObjectCount"), typeof(Binding._FCE_ObjectManager_GetObjectCount));
			Binding.FCE_ObjectManager_GetObject = (Binding._FCE_ObjectManager_GetObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectManager_GetObject"), typeof(Binding._FCE_ObjectManager_GetObject));
			Binding.FCE_ObjectSelection_Create = (Binding._FCE_ObjectSelection_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_Create"), typeof(Binding._FCE_ObjectSelection_Create));
			Binding.FCE_ObjectSelection_Destroy = (Binding._FCE_ObjectSelection_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_Destroy"), typeof(Binding._FCE_ObjectSelection_Destroy));
			Binding.FCE_ObjectSelection_Clear = (Binding._FCE_ObjectSelection_Clear)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_Clear"), typeof(Binding._FCE_ObjectSelection_Clear));
			Binding.FCE_ObjectSelection_Add = (Binding._FCE_ObjectSelection_Add)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_Add"), typeof(Binding._FCE_ObjectSelection_Add));
			Binding.FCE_ObjectSelection_AddSelection = (Binding._FCE_ObjectSelection_AddSelection)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_AddSelection"), typeof(Binding._FCE_ObjectSelection_AddSelection));
			Binding.FCE_ObjectSelection_ToggleObject = (Binding._FCE_ObjectSelection_ToggleObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_ToggleObject"), typeof(Binding._FCE_ObjectSelection_ToggleObject));
			Binding.FCE_ObjectSelection_ToggleSelection = (Binding._FCE_ObjectSelection_ToggleSelection)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_ToggleSelection"), typeof(Binding._FCE_ObjectSelection_ToggleSelection));
			Binding.FCE_ObjectSelection_RemoveObject = (Binding._FCE_ObjectSelection_RemoveObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_RemoveObject"), typeof(Binding._FCE_ObjectSelection_RemoveObject));
			Binding.FCE_ObjectSelection_RemoveSelection = (Binding._FCE_ObjectSelection_RemoveSelection)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_RemoveSelection"), typeof(Binding._FCE_ObjectSelection_RemoveSelection));
			Binding.FCE_ObjectSelection_GetCount = (Binding._FCE_ObjectSelection_GetCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_GetCount"), typeof(Binding._FCE_ObjectSelection_GetCount));
			Binding.FCE_ObjectSelection_Get = (Binding._FCE_ObjectSelection_Get)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_Get"), typeof(Binding._FCE_ObjectSelection_Get));
			Binding.FCE_ObjectSelection_GetValidObjects = (Binding._FCE_ObjectSelection_GetValidObjects)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_GetValidObjects"), typeof(Binding._FCE_ObjectSelection_GetValidObjects));
			Binding.FCE_ObjectSelection_RemoveInvalidObjects = (Binding._FCE_ObjectSelection_RemoveInvalidObjects)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_RemoveInvalidObjects"), typeof(Binding._FCE_ObjectSelection_RemoveInvalidObjects));
			Binding.FCE_ObjectSelection_Clone = (Binding._FCE_ObjectSelection_Clone)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_Clone"), typeof(Binding._FCE_ObjectSelection_Clone));
			Binding.FCE_ObjectSelection_Delete = (Binding._FCE_ObjectSelection_Delete)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_Delete"), typeof(Binding._FCE_ObjectSelection_Delete));
			Binding.FCE_ObjectSelection_GetCenter = (Binding._FCE_ObjectSelection_GetCenter)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_GetCenter"), typeof(Binding._FCE_ObjectSelection_GetCenter));
			Binding.FCE_ObjectSelection_SetCenter = (Binding._FCE_ObjectSelection_SetCenter)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_SetCenter"), typeof(Binding._FCE_ObjectSelection_SetCenter));
			Binding.FCE_ObjectSelection_GetComputeCenter = (Binding._FCE_ObjectSelection_GetComputeCenter)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_GetComputeCenter"), typeof(Binding._FCE_ObjectSelection_GetComputeCenter));
			Binding.FCE_ObjectSelection_ComputeCenter = (Binding._FCE_ObjectSelection_ComputeCenter)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_ComputeCenter"), typeof(Binding._FCE_ObjectSelection_ComputeCenter));
			Binding.FCE_ObjectSelection_GetWorldBounds = (Binding._FCE_ObjectSelection_GetWorldBounds)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_GetWorldBounds"), typeof(Binding._FCE_ObjectSelection_GetWorldBounds));
			Binding.FCE_ObjectSelection_MoveTo = (Binding._FCE_ObjectSelection_MoveTo)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_MoveTo"), typeof(Binding._FCE_ObjectSelection_MoveTo));
			Binding.FCE_ObjectSelection_Rotate = (Binding._FCE_ObjectSelection_Rotate)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_Rotate"), typeof(Binding._FCE_ObjectSelection_Rotate));
			Binding.FCE_ObjectSelection_Rotate3 = (Binding._FCE_ObjectSelection_Rotate3)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_Rotate3"), typeof(Binding._FCE_ObjectSelection_Rotate3));
			Binding.FCE_ObjectSelection_RotateCenter = (Binding._FCE_ObjectSelection_RotateCenter)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_RotateCenter"), typeof(Binding._FCE_ObjectSelection_RotateCenter));
			Binding.FCE_ObjectSelection_RotateLocal3 = (Binding._FCE_ObjectSelection_RotateLocal3)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_RotateLocal3"), typeof(Binding._FCE_ObjectSelection_RotateLocal3));
			Binding.FCE_ObjectSelection_RotateGimbal = (Binding._FCE_ObjectSelection_RotateGimbal)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_RotateGimbal"), typeof(Binding._FCE_ObjectSelection_RotateGimbal));
			Binding.FCE_ObjectSelection_DropToGround = (Binding._FCE_ObjectSelection_DropToGround)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_DropToGround"), typeof(Binding._FCE_ObjectSelection_DropToGround));
			Binding.FCE_ObjectSelection_SnapToPivot = (Binding._FCE_ObjectSelection_SnapToPivot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_SnapToPivot"), typeof(Binding._FCE_ObjectSelection_SnapToPivot));
			Binding.FCE_ObjectSelection_SnapToClosestObjects = (Binding._FCE_ObjectSelection_SnapToClosestObjects)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_SnapToClosestObjects"), typeof(Binding._FCE_ObjectSelection_SnapToClosestObjects));
			Binding.FCE_ObjectSelection_GetPhysEntities = (Binding._FCE_ObjectSelection_GetPhysEntities)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_GetPhysEntities"), typeof(Binding._FCE_ObjectSelection_GetPhysEntities));
			Binding.FCE_ObjectSelection_ClearState = (Binding._FCE_ObjectSelection_ClearState)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_ClearState"), typeof(Binding._FCE_ObjectSelection_ClearState));
			Binding.FCE_ObjectSelection_LoadState = (Binding._FCE_ObjectSelection_LoadState)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_LoadState"), typeof(Binding._FCE_ObjectSelection_LoadState));
			Binding.FCE_ObjectSelection_SaveState = (Binding._FCE_ObjectSelection_SaveState)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_SaveState"), typeof(Binding._FCE_ObjectSelection_SaveState));
			Binding.FCE_ObjectSelection_LoadFromXml = (Binding._FCE_ObjectSelection_LoadFromXml)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_LoadFromXml"), typeof(Binding._FCE_ObjectSelection_LoadFromXml));
			Binding.FCE_ObjectSelection_SaveToXml = (Binding._FCE_ObjectSelection_SaveToXml)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_SaveToXml"), typeof(Binding._FCE_ObjectSelection_SaveToXml));
			Binding.FCE_ObjectSelection_IsAxesXYLocked = (Binding._FCE_ObjectSelection_IsAxesXYLocked)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectSelection_IsAxesXYLocked"), typeof(Binding._FCE_ObjectSelection_IsAxesXYLocked));
			Binding.FCE_ObjectViewer_SetActive = (Binding._FCE_ObjectViewer_SetActive)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectViewer_SetActive"), typeof(Binding._FCE_ObjectViewer_SetActive));
			Binding.FCE_ObjectViewer_SetObject = (Binding._FCE_ObjectViewer_SetObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectViewer_SetObject"), typeof(Binding._FCE_ObjectViewer_SetObject));
			Binding.FCE_ObjectLegoBox_SetActive = (Binding._FCE_ObjectLegoBox_SetActive)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectLegoBox_SetActive"), typeof(Binding._FCE_ObjectLegoBox_SetActive));
			Binding.FCE_ObjectLegoBox_AddEntry = (Binding._FCE_ObjectLegoBox_AddEntry)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectLegoBox_AddEntry"), typeof(Binding._FCE_ObjectLegoBox_AddEntry));
			Binding.FCE_ObjectLegoBox_ClearEntries = (Binding._FCE_ObjectLegoBox_ClearEntries)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectLegoBox_ClearEntries"), typeof(Binding._FCE_ObjectLegoBox_ClearEntries));
			Binding.FCE_ObjectLegoBox_CreateLegoBox = (Binding._FCE_ObjectLegoBox_CreateLegoBox)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectLegoBox_CreateLegoBox"), typeof(Binding._FCE_ObjectLegoBox_CreateLegoBox));
			Binding.FCE_ObjectLegoBox_GetEntryFromScreenPoint = (Binding._FCE_ObjectLegoBox_GetEntryFromScreenPoint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectLegoBox_GetEntryFromScreenPoint"), typeof(Binding._FCE_ObjectLegoBox_GetEntryFromScreenPoint));
			Binding.FCE_ObjectRenderer_Clear = (Binding._FCE_ObjectRenderer_Clear)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectRenderer_Clear"), typeof(Binding._FCE_ObjectRenderer_Clear));
			Binding.FCE_ObjectRenderer_SetActive = (Binding._FCE_ObjectRenderer_SetActive)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectRenderer_SetActive"), typeof(Binding._FCE_ObjectRenderer_SetActive));
			Binding.FCE_ObjectRenderer_RenderObject = (Binding._FCE_ObjectRenderer_RenderObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectRenderer_RenderObject"), typeof(Binding._FCE_ObjectRenderer_RenderObject));
			Binding.FCE_ObjectRenderer_IsSnapshotReady = (Binding._FCE_ObjectRenderer_IsSnapshotReady)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectRenderer_IsSnapshotReady"), typeof(Binding._FCE_ObjectRenderer_IsSnapshotReady));
			Binding.FCE_ObjectRenderer_GetSnapshot = (Binding._FCE_ObjectRenderer_GetSnapshot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectRenderer_GetSnapshot"), typeof(Binding._FCE_ObjectRenderer_GetSnapshot));
			Binding.FCE_ObjectRenderer_GetSnapshotEntry = (Binding._FCE_ObjectRenderer_GetSnapshotEntry)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectRenderer_GetSnapshotEntry"), typeof(Binding._FCE_ObjectRenderer_GetSnapshotEntry));
			Binding.FCE_ObjectRenderer_ClearSnapshot = (Binding._FCE_ObjectRenderer_ClearSnapshot)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectRenderer_ClearSnapshot"), typeof(Binding._FCE_ObjectRenderer_ClearSnapshot));
			Binding.FCE_ObjectRenderer_WritePNG = (Binding._FCE_ObjectRenderer_WritePNG)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectRenderer_WritePNG"), typeof(Binding._FCE_ObjectRenderer_WritePNG));
			Binding.FCE_ObjectRenderer_GenerateThumbnails = (Binding._FCE_ObjectRenderer_GenerateThumbnails)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ObjectRenderer_GenerateThumbnails"), typeof(Binding._FCE_ObjectRenderer_GenerateThumbnails));
			Binding.FCE_CollectionRenderer_GenerateThumbnails = (Binding._FCE_CollectionRenderer_GenerateThumbnails)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_CollectionRenderer_GenerateThumbnails"), typeof(Binding._FCE_CollectionRenderer_GenerateThumbnails));
			Binding.FCE_WaterRenderer_GenerateThumbnails = (Binding._FCE_WaterRenderer_GenerateThumbnails)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_WaterRenderer_GenerateThumbnails"), typeof(Binding._FCE_WaterRenderer_GenerateThumbnails));
			Binding.FCE_Gizmo_Create = (Binding._FCE_Gizmo_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_Create"), typeof(Binding._FCE_Gizmo_Create));
			Binding.FCE_Gizmo_Destroy = (Binding._FCE_Gizmo_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_Destroy"), typeof(Binding._FCE_Gizmo_Destroy));
			Binding.FCE_Gizmo_GetPos = (Binding._FCE_Gizmo_GetPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_GetPos"), typeof(Binding._FCE_Gizmo_GetPos));
			Binding.FCE_Gizmo_SetPos = (Binding._FCE_Gizmo_SetPos)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_SetPos"), typeof(Binding._FCE_Gizmo_SetPos));
			Binding.FCE_Gizmo_GetAxis = (Binding._FCE_Gizmo_GetAxis)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_GetAxis"), typeof(Binding._FCE_Gizmo_GetAxis));
			Binding.FCE_Gizmo_SetAxis = (Binding._FCE_Gizmo_SetAxis)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_SetAxis"), typeof(Binding._FCE_Gizmo_SetAxis));
			Binding.FCE_Gizmo_GetActive = (Binding._FCE_Gizmo_GetActive)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_GetActive"), typeof(Binding._FCE_Gizmo_GetActive));
			Binding.FCE_Gizmo_SetActive = (Binding._FCE_Gizmo_SetActive)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_SetActive"), typeof(Binding._FCE_Gizmo_SetActive));
			Binding.FCE_Gizmo_Redraw = (Binding._FCE_Gizmo_Redraw)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_Redraw"), typeof(Binding._FCE_Gizmo_Redraw));
			Binding.FCE_Gizmo_Hide = (Binding._FCE_Gizmo_Hide)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_Hide"), typeof(Binding._FCE_Gizmo_Hide));
			Binding.FCE_Gizmo_IsRotationMode = (Binding._FCE_Gizmo_IsRotationMode)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_IsRotationMode"), typeof(Binding._FCE_Gizmo_IsRotationMode));
			Binding.FCE_Gizmo_SetRotationMode = (Binding._FCE_Gizmo_SetRotationMode)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_SetRotationMode"), typeof(Binding._FCE_Gizmo_SetRotationMode));
			Binding.FCE_Gizmo_ResetAxes = (Binding._FCE_Gizmo_ResetAxes)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_ResetAxes"), typeof(Binding._FCE_Gizmo_ResetAxes));
			Binding.FCE_Gizmo_EnableAxis = (Binding._FCE_Gizmo_EnableAxis)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_EnableAxis"), typeof(Binding._FCE_Gizmo_EnableAxis));
			Binding.FCE_Gizmo_HitTest = (Binding._FCE_Gizmo_HitTest)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Gizmo_HitTest"), typeof(Binding._FCE_Gizmo_HitTest));
			Binding.FCE_CollectionManager_GetCollectionEntryFromId = (Binding._FCE_CollectionManager_GetCollectionEntryFromId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_CollectionManager_GetCollectionEntryFromId"), typeof(Binding._FCE_CollectionManager_GetCollectionEntryFromId));
			Binding.FCE_CollectionManager_AssignCollectionId = (Binding._FCE_CollectionManager_AssignCollectionId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_CollectionManager_AssignCollectionId"), typeof(Binding._FCE_CollectionManager_AssignCollectionId));
			Binding.FCE_CollectionManager_WriteMaskCircle = (Binding._FCE_CollectionManager_WriteMaskCircle)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_CollectionManager_WriteMaskCircle"), typeof(Binding._FCE_CollectionManager_WriteMaskCircle));
			Binding.FCE_CollectionManager_WriteMaskSquare = (Binding._FCE_CollectionManager_WriteMaskSquare)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_CollectionManager_WriteMaskSquare"), typeof(Binding._FCE_CollectionManager_WriteMaskSquare));
			Binding.FCE_CollectionManager_ClearMaskId = (Binding._FCE_CollectionManager_ClearMaskId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_CollectionManager_ClearMaskId"), typeof(Binding._FCE_CollectionManager_ClearMaskId));
			Binding.FCE_CollectionManager_UpdateCollections = (Binding._FCE_CollectionManager_UpdateCollections)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_CollectionManager_UpdateCollections"), typeof(Binding._FCE_CollectionManager_UpdateCollections));
			Binding.FCE_CollectionManager_ActivatePhysics = (Binding._FCE_CollectionManager_ActivatePhysics)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_CollectionManager_ActivatePhysics"), typeof(Binding._FCE_CollectionManager_ActivatePhysics));
			Binding.FCE_Collection_Paint = (Binding._FCE_Collection_Paint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Collection_Paint"), typeof(Binding._FCE_Collection_Paint));
			Binding.FCE_Collection_Paint_End = (Binding._FCE_Collection_Paint_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Collection_Paint_End"), typeof(Binding._FCE_Collection_Paint_End));
			Binding.FCE_Texture_Paint = (Binding._FCE_Texture_Paint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Texture_Paint"), typeof(Binding._FCE_Texture_Paint));
			Binding.FCE_Texture_Paint_End = (Binding._FCE_Texture_Paint_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Texture_Paint_End"), typeof(Binding._FCE_Texture_Paint_End));
			Binding.FCE_Texture_PaintConstraints_Begin = (Binding._FCE_Texture_PaintConstraints_Begin)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Texture_PaintConstraints_Begin"), typeof(Binding._FCE_Texture_PaintConstraints_Begin));
			Binding.FCE_Texture_PaintConstraints = (Binding._FCE_Texture_PaintConstraints)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Texture_PaintConstraints"), typeof(Binding._FCE_Texture_PaintConstraints));
			Binding.FCE_Texture_PaintConstraints_End = (Binding._FCE_Texture_PaintConstraints_End)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Texture_PaintConstraints_End"), typeof(Binding._FCE_Texture_PaintConstraints_End));
			Binding.FCE_TerrainManager_GetHeightAt = (Binding._FCE_TerrainManager_GetHeightAt)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_GetHeightAt"), typeof(Binding._FCE_TerrainManager_GetHeightAt));
			Binding.FCE_TerrainManager_GetHeightAtWithWater = (Binding._FCE_TerrainManager_GetHeightAtWithWater)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_GetHeightAtWithWater"), typeof(Binding._FCE_TerrainManager_GetHeightAtWithWater));
			Binding.FCE_TerrainManager_GetTextureEntryFromId = (Binding._FCE_TerrainManager_GetTextureEntryFromId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_GetTextureEntryFromId"), typeof(Binding._FCE_TerrainManager_GetTextureEntryFromId));
			Binding.FCE_TerrainManager_AssignTextureId = (Binding._FCE_TerrainManager_AssignTextureId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_AssignTextureId"), typeof(Binding._FCE_TerrainManager_AssignTextureId));
			Binding.FCE_TerrainManager_ClearTextureId = (Binding._FCE_TerrainManager_ClearTextureId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_ClearTextureId"), typeof(Binding._FCE_TerrainManager_ClearTextureId));
			Binding.FCE_TerrainManager_GetGlobalWaterLevel = (Binding._FCE_TerrainManager_GetGlobalWaterLevel)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_GetGlobalWaterLevel"), typeof(Binding._FCE_TerrainManager_GetGlobalWaterLevel));
			Binding.FCE_TerrainManager_SetGlobalWaterLevel = (Binding._FCE_TerrainManager_SetGlobalWaterLevel)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_SetGlobalWaterLevel"), typeof(Binding._FCE_TerrainManager_SetGlobalWaterLevel));
			Binding.FCE_TerrainManager_SetWaterLevelSector = (Binding._FCE_TerrainManager_SetWaterLevelSector)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_SetWaterLevelSector"), typeof(Binding._FCE_TerrainManager_SetWaterLevelSector));
			Binding.FCE_TerrainManager_UpdateWaterLevel = (Binding._FCE_TerrainManager_UpdateWaterLevel)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_UpdateWaterLevel"), typeof(Binding._FCE_TerrainManager_UpdateWaterLevel));
			Binding.FCE_TerrainManager_GetLogicZoneId = (Binding._FCE_TerrainManager_GetLogicZoneId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_GetLogicZoneId"), typeof(Binding._FCE_TerrainManager_GetLogicZoneId));
			Binding.FCE_TerrainManager_SetLogicZoneId = (Binding._FCE_TerrainManager_SetLogicZoneId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_SetLogicZoneId"), typeof(Binding._FCE_TerrainManager_SetLogicZoneId));
			Binding.FCE_TerrainManager_GetSoundRegionId = (Binding._FCE_TerrainManager_GetSoundRegionId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_GetSoundRegionId"), typeof(Binding._FCE_TerrainManager_GetSoundRegionId));
			Binding.FCE_TerrainManager_SetSoundRegionId = (Binding._FCE_TerrainManager_SetSoundRegionId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_TerrainManager_SetSoundRegionId"), typeof(Binding._FCE_TerrainManager_SetSoundRegionId));
			Binding.FCE_UndoManager_GetUndoCount = (Binding._FCE_UndoManager_GetUndoCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_UndoManager_GetUndoCount"), typeof(Binding._FCE_UndoManager_GetUndoCount));
			Binding.FCE_UndoManager_GetRedoCount = (Binding._FCE_UndoManager_GetRedoCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_UndoManager_GetRedoCount"), typeof(Binding._FCE_UndoManager_GetRedoCount));
			Binding.FCE_UndoManager_Undo = (Binding._FCE_UndoManager_Undo)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_UndoManager_Undo"), typeof(Binding._FCE_UndoManager_Undo));
			Binding.FCE_UndoManager_Redo = (Binding._FCE_UndoManager_Redo)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_UndoManager_Redo"), typeof(Binding._FCE_UndoManager_Redo));
			Binding.FCE_UndoManager_RecordUndo = (Binding._FCE_UndoManager_RecordUndo)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_UndoManager_RecordUndo"), typeof(Binding._FCE_UndoManager_RecordUndo));
			Binding.FCE_UndoManager_CommitUndo = (Binding._FCE_UndoManager_CommitUndo)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_UndoManager_CommitUndo"), typeof(Binding._FCE_UndoManager_CommitUndo));
			Binding.FCE_Validation_Objective = (Binding._FCE_Validation_Objective)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Validation_Objective"), typeof(Binding._FCE_Validation_Objective));
			Binding.FCE_Validation_Game = (Binding._FCE_Validation_Game)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Validation_Game"), typeof(Binding._FCE_Validation_Game));
			Binding.FCE_ValidationReport_Destroy = (Binding._FCE_ValidationReport_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ValidationReport_Destroy"), typeof(Binding._FCE_ValidationReport_Destroy));
			Binding.FCE_ValidationReport_GetCount = (Binding._FCE_ValidationReport_GetCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ValidationReport_GetCount"), typeof(Binding._FCE_ValidationReport_GetCount));
			Binding.FCE_ValidationReport_GetRecord = (Binding._FCE_ValidationReport_GetRecord)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ValidationReport_GetRecord"), typeof(Binding._FCE_ValidationReport_GetRecord));
			Binding.FCE_ValidationRecord_GetSeverity = (Binding._FCE_ValidationRecord_GetSeverity)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ValidationRecord_GetSeverity"), typeof(Binding._FCE_ValidationRecord_GetSeverity));
			Binding.FCE_ValidationRecord_GetFlags = (Binding._FCE_ValidationRecord_GetFlags)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ValidationRecord_GetFlags"), typeof(Binding._FCE_ValidationRecord_GetFlags));
			Binding.FCE_ValidationRecord_GetErrorCode = (Binding._FCE_ValidationRecord_GetErrorCode)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ValidationRecord_GetErrorCode"), typeof(Binding._FCE_ValidationRecord_GetErrorCode));
			Binding.FCE_ValidationRecord_GetMessage = (Binding._FCE_ValidationRecord_GetMessage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ValidationRecord_GetMessage"), typeof(Binding._FCE_ValidationRecord_GetMessage));
			Binding.FCE_ValidationRecord_GetObject = (Binding._FCE_ValidationRecord_GetObject)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ValidationRecord_GetObject"), typeof(Binding._FCE_ValidationRecord_GetObject));
			Binding.FCE_Snapshot_Create = (Binding._FCE_Snapshot_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Snapshot_Create"), typeof(Binding._FCE_Snapshot_Create));
			Binding.FCE_Snapshot_Destroy = (Binding._FCE_Snapshot_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Snapshot_Destroy"), typeof(Binding._FCE_Snapshot_Destroy));
			Binding.FCE_Snapshot_GetData = (Binding._FCE_Snapshot_GetData)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Snapshot_GetData"), typeof(Binding._FCE_Snapshot_GetData));
			Binding.FCE_Spline_Create = (Binding._FCE_Spline_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_Create"), typeof(Binding._FCE_Spline_Create));
			Binding.FCE_Spline_Destroy = (Binding._FCE_Spline_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_Destroy"), typeof(Binding._FCE_Spline_Destroy));
			Binding.FCE_Spline_Clear = (Binding._FCE_Spline_Clear)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_Clear"), typeof(Binding._FCE_Spline_Clear));
			Binding.FCE_Spline_AddPoint = (Binding._FCE_Spline_AddPoint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_AddPoint"), typeof(Binding._FCE_Spline_AddPoint));
			Binding.FCE_Spline_InsertPoint = (Binding._FCE_Spline_InsertPoint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_InsertPoint"), typeof(Binding._FCE_Spline_InsertPoint));
			Binding.FCE_Spline_RemovePoint = (Binding._FCE_Spline_RemovePoint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_RemovePoint"), typeof(Binding._FCE_Spline_RemovePoint));
			Binding.FCE_Spline_RemoveSimilarPoints = (Binding._FCE_Spline_RemoveSimilarPoints)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_RemoveSimilarPoints"), typeof(Binding._FCE_Spline_RemoveSimilarPoints));
			Binding.FCE_Spline_OptimizePoint = (Binding._FCE_Spline_OptimizePoint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_OptimizePoint"), typeof(Binding._FCE_Spline_OptimizePoint));
			Binding.FCE_Spline_GetNumPoints = (Binding._FCE_Spline_GetNumPoints)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_GetNumPoints"), typeof(Binding._FCE_Spline_GetNumPoints));
			Binding.FCE_Spline_GetPoint = (Binding._FCE_Spline_GetPoint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_GetPoint"), typeof(Binding._FCE_Spline_GetPoint));
			Binding.FCE_Spline_SetPoint = (Binding._FCE_Spline_SetPoint)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_SetPoint"), typeof(Binding._FCE_Spline_SetPoint));
			Binding.FCE_Spline_UpdateSpline = (Binding._FCE_Spline_UpdateSpline)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_UpdateSpline"), typeof(Binding._FCE_Spline_UpdateSpline));
			Binding.FCE_Spline_UpdateSplineHeight = (Binding._FCE_Spline_UpdateSplineHeight)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_UpdateSplineHeight"), typeof(Binding._FCE_Spline_UpdateSplineHeight));
			Binding.FCE_Spline_FinalizeSpline = (Binding._FCE_Spline_FinalizeSpline)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_FinalizeSpline"), typeof(Binding._FCE_Spline_FinalizeSpline));
			Binding.FCE_Spline_Draw = (Binding._FCE_Spline_Draw)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_Draw"), typeof(Binding._FCE_Spline_Draw));
			Binding.FCE_Spline_HitTestPoints = (Binding._FCE_Spline_HitTestPoints)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_HitTestPoints"), typeof(Binding._FCE_Spline_HitTestPoints));
			Binding.FCE_Spline_HitTestSegments = (Binding._FCE_Spline_HitTestSegments)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Spline_HitTestSegments"), typeof(Binding._FCE_Spline_HitTestSegments));
			Binding.FCE_SplineRoad_GetEntry = (Binding._FCE_SplineRoad_GetEntry)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineRoad_GetEntry"), typeof(Binding._FCE_SplineRoad_GetEntry));
			Binding.FCE_SplineRoad_SetEntry = (Binding._FCE_SplineRoad_SetEntry)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineRoad_SetEntry"), typeof(Binding._FCE_SplineRoad_SetEntry));
			Binding.FCE_SplineRoad_GetWidth = (Binding._FCE_SplineRoad_GetWidth)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineRoad_GetWidth"), typeof(Binding._FCE_SplineRoad_GetWidth));
			Binding.FCE_SplineRoad_SetWidth = (Binding._FCE_SplineRoad_SetWidth)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineRoad_SetWidth"), typeof(Binding._FCE_SplineRoad_SetWidth));
			Binding.FCE_SplineZone_Reset = (Binding._FCE_SplineZone_Reset)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineZone_Reset"), typeof(Binding._FCE_SplineZone_Reset));
			Binding.FCE_SplineController_Create = (Binding._FCE_SplineController_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineController_Create"), typeof(Binding._FCE_SplineController_Create));
			Binding.FCE_SplineController_Destroy = (Binding._FCE_SplineController_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineController_Destroy"), typeof(Binding._FCE_SplineController_Destroy));
			Binding.FCE_SplineController_SetSpline = (Binding._FCE_SplineController_SetSpline)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineController_SetSpline"), typeof(Binding._FCE_SplineController_SetSpline));
			Binding.FCE_SplineController_ClearSelection = (Binding._FCE_SplineController_ClearSelection)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineController_ClearSelection"), typeof(Binding._FCE_SplineController_ClearSelection));
			Binding.FCE_SplineController_IsSelected = (Binding._FCE_SplineController_IsSelected)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineController_IsSelected"), typeof(Binding._FCE_SplineController_IsSelected));
			Binding.FCE_SplineController_SetSelected = (Binding._FCE_SplineController_SetSelected)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineController_SetSelected"), typeof(Binding._FCE_SplineController_SetSelected));
			Binding.FCE_SplineController_SelectFromScreenRect = (Binding._FCE_SplineController_SelectFromScreenRect)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineController_SelectFromScreenRect"), typeof(Binding._FCE_SplineController_SelectFromScreenRect));
			Binding.FCE_SplineController_MoveSelection = (Binding._FCE_SplineController_MoveSelection)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineController_MoveSelection"), typeof(Binding._FCE_SplineController_MoveSelection));
			Binding.FCE_SplineController_DeleteSelection = (Binding._FCE_SplineController_DeleteSelection)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineController_DeleteSelection"), typeof(Binding._FCE_SplineController_DeleteSelection));
			Binding.FCE_SplineManager_CreateRoad = (Binding._FCE_SplineManager_CreateRoad)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineManager_CreateRoad"), typeof(Binding._FCE_SplineManager_CreateRoad));
			Binding.FCE_SplineManager_DestroyRoad = (Binding._FCE_SplineManager_DestroyRoad)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineManager_DestroyRoad"), typeof(Binding._FCE_SplineManager_DestroyRoad));
			Binding.FCE_SplineManager_GetRoadFromId = (Binding._FCE_SplineManager_GetRoadFromId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineManager_GetRoadFromId"), typeof(Binding._FCE_SplineManager_GetRoadFromId));
			Binding.FCE_SplineManager_GetPlayableZone = (Binding._FCE_SplineManager_GetPlayableZone)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_SplineManager_GetPlayableZone"), typeof(Binding._FCE_SplineManager_GetPlayableZone));
			Binding.FCE_PhysEntityVector_Create = (Binding._FCE_PhysEntityVector_Create)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_PhysEntityVector_Create"), typeof(Binding._FCE_PhysEntityVector_Create));
			Binding.FCE_PhysEntityVector_Destroy = (Binding._FCE_PhysEntityVector_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_PhysEntityVector_Destroy"), typeof(Binding._FCE_PhysEntityVector_Destroy));
			Binding.FCE_Wilderness_Desert = (Binding._FCE_Wilderness_Desert)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Wilderness_Desert"), typeof(Binding._FCE_Wilderness_Desert));
			Binding.FCE_Wilderness_Script = (Binding._FCE_Wilderness_Script)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Wilderness_Script"), typeof(Binding._FCE_Wilderness_Script));
			Binding.FCE_Wilderness_ScriptBuffer = (Binding._FCE_Wilderness_ScriptBuffer)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Wilderness_ScriptBuffer"), typeof(Binding._FCE_Wilderness_ScriptBuffer));
			Binding.FCE_Script_GetNumFunctions = (Binding._FCE_Script_GetNumFunctions)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Script_GetNumFunctions"), typeof(Binding._FCE_Script_GetNumFunctions));
			Binding.FCE_Script_GetFunction = (Binding._FCE_Script_GetFunction)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Script_GetFunction"), typeof(Binding._FCE_Script_GetFunction));
			Binding.FCE_ScriptFunction_GetName = (Binding._FCE_ScriptFunction_GetName)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ScriptFunction_GetName"), typeof(Binding._FCE_ScriptFunction_GetName));
			Binding.FCE_ScriptFunction_GetPrototype = (Binding._FCE_ScriptFunction_GetPrototype)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ScriptFunction_GetPrototype"), typeof(Binding._FCE_ScriptFunction_GetPrototype));
			Binding.FCE_ScriptFunction_GetDescription = (Binding._FCE_ScriptFunction_GetDescription)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ScriptFunction_GetDescription"), typeof(Binding._FCE_ScriptFunction_GetDescription));
			Binding.FCE_ImageMap_GetSize = (Binding._FCE_ImageMap_GetSize)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ImageMap_GetSize"), typeof(Binding._FCE_ImageMap_GetSize));
			Binding.FCE_ImageMap_ConvertTo24bit = (Binding._FCE_ImageMap_ConvertTo24bit)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ImageMap_ConvertTo24bit"), typeof(Binding._FCE_ImageMap_ConvertTo24bit));
			Binding.FCE_ImageMap_Clone = (Binding._FCE_ImageMap_Clone)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ImageMap_Clone"), typeof(Binding._FCE_ImageMap_Clone));
			Binding.FCE_ImageMap_Destroy = (Binding._FCE_ImageMap_Destroy)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_ImageMap_Destroy"), typeof(Binding._FCE_ImageMap_Destroy));
			Binding.FCE_BudgetManager_GetMemoryUsage = (Binding._FCE_BudgetManager_GetMemoryUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetMemoryUsage"), typeof(Binding._FCE_BudgetManager_GetMemoryUsage));
			Binding.FCE_BudgetManager_GetMaxMemoryUsageMB = (Binding._FCE_BudgetManager_GetMaxMemoryUsageMB)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetMaxMemoryUsageMB"), typeof(Binding._FCE_BudgetManager_GetMaxMemoryUsageMB));
			Binding.FCE_BudgetManager_GetObjectUsage = (Binding._FCE_BudgetManager_GetObjectUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetObjectUsage"), typeof(Binding._FCE_BudgetManager_GetObjectUsage));
			Binding.FCE_BudgetManager_GetMaxObjectUsage = (Binding._FCE_BudgetManager_GetMaxObjectUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetMaxObjectUsage"), typeof(Binding._FCE_BudgetManager_GetMaxObjectUsage));
			Binding.FCE_BudgetManager_GetWaveUsage = (Binding._FCE_BudgetManager_GetWaveUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetWaveUsage"), typeof(Binding._FCE_BudgetManager_GetWaveUsage));
			Binding.FCE_BudgetManager_GetMaxWaveUsage = (Binding._FCE_BudgetManager_GetMaxWaveUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetMaxWaveUsage"), typeof(Binding._FCE_BudgetManager_GetMaxWaveUsage));
			Binding.FCE_BudgetManager_GetVehicles = (Binding._FCE_BudgetManager_GetVehicles)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetVehicles"), typeof(Binding._FCE_BudgetManager_GetVehicles));
			Binding.FCE_BudgetManager_GetMaxVehicles = (Binding._FCE_BudgetManager_GetMaxVehicles)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetMaxVehicles"), typeof(Binding._FCE_BudgetManager_GetMaxVehicles));
			Binding.FCE_BudgetManager_GetAmbientAI = (Binding._FCE_BudgetManager_GetAmbientAI)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetAmbientAI"), typeof(Binding._FCE_BudgetManager_GetAmbientAI));
			Binding.FCE_BudgetManager_GetEnemyAI = (Binding._FCE_BudgetManager_GetEnemyAI)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetEnemyAI"), typeof(Binding._FCE_BudgetManager_GetEnemyAI));
			Binding.FCE_BudgetManager_ValidateObjectsGlobalCost = (Binding._FCE_BudgetManager_ValidateObjectsGlobalCost)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_ValidateObjectsGlobalCost"), typeof(Binding._FCE_BudgetManager_ValidateObjectsGlobalCost));
			Binding.FCE_BudgetManager_ValidateObjectsSectorCost = (Binding._FCE_BudgetManager_ValidateObjectsSectorCost)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_ValidateObjectsSectorCost"), typeof(Binding._FCE_BudgetManager_ValidateObjectsSectorCost));
			Binding.FCE_BudgetManager_ValidateAIObjectsUsage = (Binding._FCE_BudgetManager_ValidateAIObjectsUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_ValidateAIObjectsUsage"), typeof(Binding._FCE_BudgetManager_ValidateAIObjectsUsage));
			Binding.FCE_BudgetManager_ValidatePhysicsObjectsUsage = (Binding._FCE_BudgetManager_ValidatePhysicsObjectsUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_ValidatePhysicsObjectsUsage"), typeof(Binding._FCE_BudgetManager_ValidatePhysicsObjectsUsage));
			Binding.FCE_BudgetManager_ValidateLightObjectsUsage = (Binding._FCE_BudgetManager_ValidateLightObjectsUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_ValidateLightObjectsUsage"), typeof(Binding._FCE_BudgetManager_ValidateLightObjectsUsage));
			Binding.FCE_BudgetManager_ValidateAnimPointsObjectsUsage = (Binding._FCE_BudgetManager_ValidateAnimPointsObjectsUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_ValidateAnimPointsObjectsUsage"), typeof(Binding._FCE_BudgetManager_ValidateAnimPointsObjectsUsage));
			Binding.FCE_BudgetManager_ValidateSpawnPointsObjectsUsage = (Binding._FCE_BudgetManager_ValidateSpawnPointsObjectsUsage)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_ValidateSpawnPointsObjectsUsage"), typeof(Binding._FCE_BudgetManager_ValidateSpawnPointsObjectsUsage));
			Binding.FCE_BudgetManager_GetObjectSectorId = (Binding._FCE_BudgetManager_GetObjectSectorId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_BudgetManager_GetObjectSectorId"), typeof(Binding._FCE_BudgetManager_GetObjectSectorId));
			Binding.FCE_GameModeManager_ClearObjectiveSettings = (Binding._FCE_GameModeManager_ClearObjectiveSettings)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameModeManager_ClearObjectiveSettings"), typeof(Binding._FCE_GameModeManager_ClearObjectiveSettings));
			Binding.FCE_GameModeManager_AddObjectiveSetting = (Binding._FCE_GameModeManager_AddObjectiveSetting)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameModeManager_AddObjectiveSetting"), typeof(Binding._FCE_GameModeManager_AddObjectiveSetting));
			Binding.FCE_GameModeManager_GetObjectiveSettingBool = (Binding._FCE_GameModeManager_GetObjectiveSettingBool)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameModeManager_GetObjectiveSettingBool"), typeof(Binding._FCE_GameModeManager_GetObjectiveSettingBool));
			Binding.FCE_GameModeManager_GetObjectiveSettingNumeric = (Binding._FCE_GameModeManager_GetObjectiveSettingNumeric)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameModeManager_GetObjectiveSettingNumeric"), typeof(Binding._FCE_GameModeManager_GetObjectiveSettingNumeric));
			Binding.FCE_GameModeManager_GetObjectiveSettingPresetDbId = (Binding._FCE_GameModeManager_GetObjectiveSettingPresetDbId)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_GameModeManager_GetObjectiveSettingPresetDbId"), typeof(Binding._FCE_GameModeManager_GetObjectiveSettingPresetDbId));
			Binding.FCE_Navmesh_SetDisplay = (Binding._FCE_Navmesh_SetDisplay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Navmesh_SetDisplay"), typeof(Binding._FCE_Navmesh_SetDisplay));
			Binding.FCE_Navmesh_RegenerateTileAt = (Binding._FCE_Navmesh_RegenerateTileAt)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Navmesh_RegenerateTileAt"), typeof(Binding._FCE_Navmesh_RegenerateTileAt));
			Binding.FCE_Navmesh_SetAPDisplay = (Binding._FCE_Navmesh_SetAPDisplay)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Navmesh_SetAPDisplay"), typeof(Binding._FCE_Navmesh_SetAPDisplay));
			Binding.FCE_Navmesh_GetDebugAlpha = (Binding._FCE_Navmesh_GetDebugAlpha)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Navmesh_GetDebugAlpha"), typeof(Binding._FCE_Navmesh_GetDebugAlpha));
			Binding.FCE_Navmesh_SetDebugAlpha = (Binding._FCE_Navmesh_SetDebugAlpha)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Navmesh_SetDebugAlpha"), typeof(Binding._FCE_Navmesh_SetDebugAlpha));
			Binding.FCE_Navmesh_GetPendingTilesCount = (Binding._FCE_Navmesh_GetPendingTilesCount)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Navmesh_GetPendingTilesCount"), typeof(Binding._FCE_Navmesh_GetPendingTilesCount));
			Binding.FCE_Navmesh_IsReady = (Binding._FCE_Navmesh_IsReady)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Navmesh_IsReady"), typeof(Binding._FCE_Navmesh_IsReady));
			Binding.FCE_Navmesh_Sync = (Binding._FCE_Navmesh_Sync)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Navmesh_Sync"), typeof(Binding._FCE_Navmesh_Sync));
			Binding.FCE_Navmesh_Validate = (Binding._FCE_Navmesh_Validate)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Navmesh_Validate"), typeof(Binding._FCE_Navmesh_Validate));
			Binding.FCE_Editor_Publish_Map = (Binding._FCE_Editor_Publish_Map)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_Publish_Map"), typeof(Binding._FCE_Editor_Publish_Map));
			Binding.FCE_Editor_PublishComlete_Callback = (Binding._FCE_Editor_PublishComlete_Callback)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_PublishComlete_Callback"), typeof(Binding._FCE_Editor_PublishComlete_Callback));
			Binding.FCE_Editor_Login = (Binding._FCE_Editor_Login)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_Login"), typeof(Binding._FCE_Editor_Login));
			Binding.FCE_Editor_LoginComlete_Callback = (Binding._FCE_Editor_LoginComlete_Callback)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_LoginComlete_Callback"), typeof(Binding._FCE_Editor_LoginComlete_Callback));
			Binding.FCE_Editor_CreateIssue = (Binding._FCE_Editor_CreateIssue)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "FCE_Editor_CreateIssue"), typeof(Binding._FCE_Editor_CreateIssue));
			Binding.IsNvidia = (Binding._IsNvidia)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "IsNvidia"), typeof(Binding._IsNvidia));
			Binding.GetIGESteamCommandLine = (Binding._GetIGESteamCommandLine)Marshal.GetDelegateForFunctionPointer(Binding.GetProcAddress(Binding._gameDllModule, "GetIGESteamCommandLine"), typeof(Binding._GetIGESteamCommandLine));
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x0002819C File Offset: 0x0002639C
		public static void UnloadDll()
		{
			if (Binding._gameDllModule == IntPtr.Zero)
			{
				return;
			}
			Binding.FCE_Hack_Init = null;
			Binding.FCE_GetProgress = null;
			Binding.FCE_Engine_Reset = null;
			Binding.FCE_Engine_GetPersonalPath = null;
			Binding.FCE_Engine_GetGenericDataPath = null;
			Binding.FCE_Engine_UpdateViewport = null;
			Binding.FCE_Engine_AutoAcquireInput = null;
			Binding.FCE_Engine_IsConsoleOpen = null;
			Binding.FCE_Engine_GetTimeOfDay = null;
			Binding.FCE_Engine_SetTimeOfDay = null;
			Binding.FCE_Engine_GetCloudTypeCount = null;
			Binding.FCE_Engine_GetCloudType = null;
			Binding.FCE_Engine_SetCloudType = null;
			Binding.FCE_Engine_IsSnowEnabled = null;
			Binding.FCE_Engine_SetSnowEnabled = null;
			Binding.FCE_Engine_IsBackdropEnabled = null;
			Binding.FCE_Engine_SetBackdropEnabled = null;
			Binding.FCE_Engine_SetSelectedObject = null;
			Binding.FCE_Core_GetAxisFromAngles = null;
			Binding.FCE_Core_GetAnglesFromAxis = null;
			Binding.FCE_Core_GetAnglesFromDir = null;
			Binding.FCE_Core_Points_Create = null;
			Binding.FCE_Core_Points_Destroy = null;
			Binding.FCE_Editor_Create = null;
			Binding.FCE_Editor_Destroy = null;
			Binding.FCE_Editor_IsInitialized = null;
			Binding.FCE_Editor_Update_Callback = null;
			Binding.FCE_Editor_Event_Callback = null;
			Binding.FCE_Editor_LoadCompleted_Callback = null;
			Binding.FCE_Editor_SaveCompleted_Callback = null;
			Binding.FCE_Editor_EnableUI_Callback = null;
			Binding.FCE_Editor_IsLoadPending = null;
			Binding.FCE_Editor_GetFrameTime = null;
			Binding.FCE_Editor_GetScreenPointFromWorldPos = null;
			Binding.FCE_Editor_GetWorldRayFromScreenPoint = null;
			Binding.FCE_Editor_RayCastTerrain = null;
			Binding.FCE_Editor_RayCastPhysics = null;
			Binding.FCE_Editor_RayCastPhysics2 = null;
			Binding.FCE_Editor_ValidateSpawnPoints = null;
			Binding.FCE_Editor_ValidateObjective = null;
			Binding.FCE_Editor_EnterIngame = null;
			Binding.FCE_Editor_ExitIngame = null;
			Binding.FCE_Editor_IsIngame = null;
			Binding.FCE_Editor_MuteSound = null;
			Binding.FCE_Online_GetUplayUserName = null;
			Binding.FCE_Online_GetUplayAccountId = null;
			Binding.FCE_GamerProfile_Create = null;
			Binding.FCE_GamerProfile_IsReady = null;
			Binding.FCE_GamerProfile_HasCreationFailed = null;
			Binding.FCE_GamerProfile_UpdateManager = null;
			Binding.FCE_Document_Reset = null;
			Binding.FCE_Document_LoadPhysical = null;
			Binding.FCE_Document_Load = null;
			Binding.FCE_Document_Save = null;
			Binding.FCE_Document_CheckValidation = null;
			Binding.FCE_Document_Validate = null;
			Binding.FCE_Document_GetMapID = null;
			Binding.FCE_Document_SetMapID = null;
			Binding.FCE_Document_GetVersionID = null;
			Binding.FCE_Document_GetMapDefaultName = null;
			Binding.FCE_Document_GetMapName = null;
			Binding.FCE_Document_SetMapName = null;
			Binding.FCE_Document_GetCreatorName = null;
			Binding.FCE_Document_SetCreatorName = null;
			Binding.FCE_Document_GetAuthorName = null;
			Binding.FCE_Document_SetAuthorName = null;
			Binding.FCE_Document_GetBattlefieldSize = null;
			Binding.FCE_Document_SetBattlefieldSize = null;
			Binding.FCE_Document_GetPlayerSize = null;
			Binding.FCE_Document_SetPlayerSize = null;
			Binding.FCE_Document_IsSnapshotSet = null;
			Binding.FCE_Document_ClearSnapshot = null;
			Binding.FCE_Document_GetSnapshotPos = null;
			Binding.FCE_Document_SetSnapshotPos = null;
			Binding.FCE_Document_GetSnapshotAngle = null;
			Binding.FCE_Document_SetSnapshotAngle = null;
			Binding.FCE_Document_TakeSnapshot = null;
			Binding.FCE_Document_IsNavmeshEnabled = null;
			Binding.FCE_Document_SetNavmeshEnabled = null;
			Binding.FCE_Document_FinalizeMap = null;
			Binding.FCE_Document_Export = null;
			Binding.FCE_Document_Dump = null;
			Binding.FCE_Document_ExtractBigFile = null;
			Binding.FCE_Document_ClearMapTags = null;
			Binding.FCE_Document_GetMapTags = null;
			Binding.FCE_Document_AppendMapTag = null;
			Binding.FCE_WaitScreen_Show = null;
			Binding.FCE_WaitScreen_Hide = null;
			Binding.FCE_EditorSettings_IsCollectionVisible = null;
			Binding.FCE_EditorSettings_ShowCollections = null;
			Binding.FCE_EditorSettings_IsFogVisible = null;
			Binding.FCE_EditorSettings_ShowFog = null;
			Binding.FCE_EditorSettings_IsExposureVisible = null;
			Binding.FCE_EditorSettings_ShowExposure = null;
			Binding.FCE_EditorSettings_IsShadowVisible = null;
			Binding.FCE_EditorSettings_ShowShadow = null;
			Binding.FCE_EditorSettings_IsWaterVisible = null;
			Binding.FCE_EditorSettings_ShowWater = null;
			Binding.FCE_EditorSettings_IsIconsVisible = null;
			Binding.FCE_EditorSettings_ShowIcons = null;
			Binding.FCE_EditorSettings_IsSoundEnabled = null;
			Binding.FCE_EditorSettings_SetSoundEnabled = null;
			Binding.FCE_EditorSettings_IsGridVisible = null;
			Binding.FCE_EditorSettings_ShowGrid = null;
			Binding.FCE_EditorSettings_GetGridResolution = null;
			Binding.FCE_EditorSettings_SetGridResolution = null;
			Binding.FCE_EditorSettings_IsBudgetGridVisible = null;
			Binding.FCE_EditorSettings_ShowBudgetGrid_Callback = null;
			Binding.FCE_EditorSettings_ShowBudgetGrid = null;
			Binding.FCE_EditorSettings_GetBudgetGridResolution = null;
			Binding.FCE_EditorSettings_SetBudgetGridResolution = null;
			Binding.FCE_EditorSettings_IsNavmeshVisible = null;
			Binding.FCE_EditorSettings_ShowNavmesh = null;
			Binding.FCE_EditorSettings_HideNavmesh = null;
			Binding.FCE_EditorSettings_GetNavmeshLayer = null;
			Binding.FCE_EditorSettings_IsCoversVisible = null;
			Binding.FCE_EditorSettings_ShowCovers = null;
			Binding.FCE_EditorSettings_IsInvincible = null;
			Binding.FCE_EditorSettings_SetInvincible = null;
			Binding.FCE_EditorSettings_IsInvisible = null;
			Binding.FCE_EditorSettings_SetInvisible = null;
			Binding.FCE_EditorSettings_IsSnappingObjectsToTerrain = null;
			Binding.FCE_EditorSettings_SetSnapObjectsToTerrain = null;
			Binding.FCE_EditorSettings_IsAutoSnappingObjects = null;
			Binding.FCE_EditorSettings_SetAutoSnappingObjects = null;
			Binding.FCE_EditorSettings_IsAutoSnappingObjectsRotation = null;
			Binding.FCE_EditorSettings_SetAutoSnappingObjectsRotation = null;
			Binding.FCE_EditorSettings_IsAutoSnappingObjectsTerrain = null;
			Binding.FCE_EditorSettings_SetAutoSnappingObjectsTerrain = null;
			Binding.FCE_EditorSettings_IsCameraClippedTerrain = null;
			Binding.FCE_EditorSettings_SetCameraClipTerrain = null;
			Binding.FCE_EditorSettings_IsCameraCollision = null;
			Binding.FCE_EditorSettings_SetCameraCollision = null;
			Binding.FCE_EditorSettings_GetEngineQuality = null;
			Binding.FCE_EditorSettings_SetEngineQuality = null;
			Binding.FCE_EditorSettings_IsKillDistanceOverride = null;
			Binding.FCE_EditorSettings_SetKillDistanceOverride = null;
			Binding.FCE_EditorSettings_IsOcclusionVisible = null;
			Binding.FCE_EditorSettings_ShowOcclusion = null;
			Binding.FCE_NomadDbIdVector_Create = null;
			Binding.FCE_NomadDbIdVector_Destroy = null;
			Binding.FCE_NomadDbIdVector_GetCount = null;
			Binding.FCE_NomadDbIdVector_GetAt = null;
			Binding.FCE_GameMode_GetAllGameModeDescDbIds = null;
			Binding.FCE_GameMode_GetGameModeNameId = null;
			Binding.FCE_GameMode_GetObjectiveDescDbIds = null;
			Binding.FCE_GameMode_GetObjectiveNameId = null;
			Binding.FCE_GameMode_GetObjectiveDescId = null;
			Binding.FCE_GameMode_GetCurrentObjectiveDescId = null;
			Binding.FCE_GameMode_SetCurrentObjectiveDescId = null;
			Binding.FCE_GameMode_GetCurrentGameModeDescId = null;
			Binding.FCE_GameMode_SetCurrentGameModeDescId = null;
			Binding.FCE_GameMode_GetObjectiveEnumValue = null;
			Binding.FCE_GameMode_GetAllWildernessDbIds = null;
			Binding.FCE_GameMode_WildernessNameId = null;
			Binding.FCE_GameMode_WildernessScriptPathId = null;
			Binding.FCE_GameProperty_GetAllPropertyIds = null;
			Binding.FCE_GameProperty_GetPropertyID = null;
			Binding.FCE_GameProperty_GetPropertyType = null;
			Binding.FCE_GameProperty_GetPropertyValueType = null;
			Binding.FCE_GameProperty_GetSupportedObjectiveDescDbIds = null;
			Binding.FCE_GameProperty_GetPropertyChildID = null;
			Binding.FCE_GameProperty_GetPropertyMinValue = null;
			Binding.FCE_GameProperty_GetPropertyMaxValue = null;
			Binding.FCE_GameProperty_GetPropertyResolution = null;
			Binding.FCE_GameProperty_GetPropertyDefaultFloat = null;
			Binding.FCE_GameProperty_GetPropertyDefaultBoolean = null;
			Binding.FCE_GameProperty_GetPropertyDefaultPresetId = null;
			Binding.FCE_GameProperty_GetPropertyDisplayNameId = null;
			Binding.FCE_GameProperty_GetPropertyCategoryNameId = null;
			Binding.FCE_GameProperty_GetPropertyPresetIds = null;
			Binding.FCE_GameProperty_GetPropertyPresetDisplayNameId = null;
			Binding.FCE_MapTag_GetAllDbIds = null;
			Binding.FCE_MapTag_GetDisplayNameId = null;
			Binding.FCE_MapTag_GetObjectiveRef = null;
			Binding.FCE_MapTag_GetModifierRefs = null;
			Binding.FCE_MapTag_GetAvailableGameModes = null;
			Binding.FCE_MapTag_GetPresetRefs = null;
			Binding.FCE_MapTag_GetIsAuto = null;
			Binding.FCE_MapTag_GetIsEnum = null;
			Binding.FCE_MapTag_GetIsEnumDefault = null;
			Binding.FCE_MapTag_GetPriority = null;
			Binding.FCE_PC_KeyboardKeyEvent = null;
			Binding.FCE_Draw_BeginGroup = null;
			Binding.FCE_Draw_EndGroup = null;
			Binding.FCE_Draw_ScreenCircleOutlined = null;
			Binding.FCE_Draw_ScreenRectangleOutlined = null;
			Binding.FCE_Draw_Quad = null;
			Binding.FCE_Draw_Square = null;
			Binding.FCE_Draw_Terrain_Circle = null;
			Binding.FCE_Draw_Terrain_Square = null;
			Binding.FCE_Draw_Arrow = null;
			Binding.FCE_Draw_Dot = null;
			Binding.FCE_Draw_SegmentedLineSegment = null;
			Binding.FCE_Draw_WireBoxFromBottomZ = null;
			Binding.FCE_Draw_WireRegionFromTerrain = null;
			Binding.FCE_Camera_Input_Forward = null;
			Binding.FCE_Camera_Input_Lateral = null;
			Binding.FCE_Camera_GetPos = null;
			Binding.FCE_Camera_SetPos = null;
			Binding.FCE_Camera_GetAngles = null;
			Binding.FCE_Camera_SetAngles = null;
			Binding.FCE_Camera_Rotate = null;
			Binding.FCE_Camera_GetFrontVector = null;
			Binding.FCE_Camera_GetRightVector = null;
			Binding.FCE_Camera_GetUpVector = null;
			Binding.FCE_Camera_GetSpeed = null;
			Binding.FCE_Camera_SetSpeed = null;
			Binding.FCE_Camera_SetSpeedFactor = null;
			Binding.FCE_Camera_GetFOV = null;
			Binding.FCE_Camera_AlignToSelection = null;
			Binding.FCE_Camera_AlignToObject = null;
			Binding.FCE_Brush_Create = null;
			Binding.FCE_Brush_Destroy = null;
			Binding.FCE_Terrain_Bump = null;
			Binding.FCE_Terrain_Bump_End = null;
			Binding.FCE_Terrain_RaiseLower = null;
			Binding.FCE_Terrain_RaiseLower_End = null;
			Binding.FCE_Terrain_SetHeight = null;
			Binding.FCE_Terrain_SetHeight_End = null;
			Binding.FCE_Terrain_GetAverageHeight = null;
			Binding.FCE_Terrain_Average = null;
			Binding.FCE_Terrain_Average_End = null;
			Binding.FCE_Terrain_Grab_Begin = null;
			Binding.FCE_Terrain_Grab = null;
			Binding.FCE_Terrain_Grab_End = null;
			Binding.FCE_Terrain_Smooth = null;
			Binding.FCE_Terrain_Smooth_End = null;
			Binding.FCE_Terrain_Ramp = null;
			Binding.FCE_Terrain_Terrace = null;
			Binding.FCE_Terrain_Terrace_End = null;
			Binding.FCE_Terrain_Noise_Begin = null;
			Binding.FCE_Terrain_Noise = null;
			Binding.FCE_Terrain_Noise_End = null;
			Binding.FCE_Terrain_Erosion = null;
			Binding.FCE_Terrain_Erosion_End = null;
			Binding.FCE_Terrain_Hole = null;
			Binding.FCE_Terrain_Hole_End = null;
			Binding.FCE_Inventory_Entry_IsDirectory = null;
			Binding.FCE_Inventory_Entry_IsDeleted = null;
			Binding.FCE_Inventory_Entry_SetDeleted = null;
			Binding.FCE_Inventory_Entry_ClearChildren = null;
			Binding.FCE_Inventory_Entry_AddChild = null;
			Binding.FCE_Inventory_Entry_SetChildIndex = null;
			Binding.FCE_Inventory_Entry_OpenThumbnailData = null;
			Binding.FCE_Inventory_Entry_CloseThumbnailData = null;
			Binding.FCE_Inventory_Object_GetRoot = null;
			Binding.FCE_Inventory_Object_CreatePrefabObject = null;
			Binding.FCE_Inventory_Object_CreateDirectory = null;
			Binding.FCE_Inventory_Object_CreateFilterDirectory = null;
			Binding.FCE_Inventory_Object_DestroyFilterDirectory = null;
			Binding.FCE_Inventory_Object_SearchInventoryEntry = null;
			Binding.FCE_Inventory_Object_GetParent = null;
			Binding.FCE_Inventory_Object_SetParent = null;
			Binding.FCE_Inventory_Object_IsDirectory = null;
			Binding.FCE_Inventory_Object_GetChildCount = null;
			Binding.FCE_Inventory_Object_GetChild = null;
			Binding.FCE_Inventory_Object_GetId = null;
			Binding.FCE_Inventory_Object_GetIdString = null;
			Binding.FCE_Inventory_Object_SetIdString = null;
			Binding.FCE_Inventory_Object_GetDisplay = null;
			Binding.FCE_Inventory_Object_SetDisplay = null;
			Binding.FCE_Inventory_Object_GetTags = null;
			Binding.FCE_Inventory_Object_SetTags = null;
			Binding.FCE_Inventory_Object_GetSourceType = null;
			Binding.FCE_Inventory_Object_GetBMin = null;
			Binding.FCE_Inventory_Object_GetBMax = null;
			Binding.FCE_Inventory_Object_GetSize = null;
			Binding.FCE_Inventory_Object_IsAI = null;
			Binding.FCE_Inventory_Object_IsObjectType = null;
			Binding.FCE_Inventory_Object_IsAutoOrientation = null;
			Binding.FCE_Inventory_Object_GetZOffset = null;
			Binding.FCE_Inventory_Object_SetZOffset = null;
			Binding.FCE_Inventory_Object_SaveChanges = null;
			Binding.FCE_Inventory_Object_ClearPivots = null;
			Binding.FCE_Inventory_Object_AddPivot = null;
			Binding.FCE_Inventory_Object_SetPivot = null;
			Binding.FCE_Inventory_Object_SetPivots = null;
			Binding.FCE_Inventory_Object_IsAutoPivot = null;
			Binding.FCE_Inventory_Object_SetAutoPivot = null;
			Binding.FCE_Inventory_Object_GetPivotCount = null;
			Binding.FCE_Inventory_Object_HasComponent = null;
			Binding.FCE_Inventory_Object_GetArchetypeId = null;
			Binding.FCE_Inventory_Object_GetWaveNum = null;
			Binding.FCE_Inventory_Object_IsObjectiveGameplayObject = null;
			Binding.FCE_Inventory_Collection_GetRoot = null;
			Binding.FCE_Inventory_Collection_GetParent = null;
			Binding.FCE_Inventory_Collection_GetChildCount = null;
			Binding.FCE_Inventory_Collection_GetChild = null;
			Binding.FCE_Inventory_Collection_GetDisplay = null;
			Binding.FCE_Inventory_Collection_GetBurnProfile = null;
			Binding.FCE_Inventory_Texture_GetRoot = null;
			Binding.FCE_Inventory_Texture_GetParent = null;
			Binding.FCE_Inventory_Texture_GetChildCount = null;
			Binding.FCE_Inventory_Texture_GetChild = null;
			Binding.FCE_Inventory_Texture_GetDisplay = null;
			Binding.FCE_Inventory_Water_GetRoot = null;
			Binding.FCE_Inventory_Water_GetParent = null;
			Binding.FCE_Inventory_Water_GetChildCount = null;
			Binding.FCE_Inventory_Water_GetChild = null;
			Binding.FCE_Inventory_Water_GetDisplay = null;
			Binding.FCE_Inventory_Water_GetFromId = null;
			Binding.FCE_Inventory_Spline_GetRoot = null;
			Binding.FCE_Inventory_Spline_GetParent = null;
			Binding.FCE_Inventory_Spline_GetChildCount = null;
			Binding.FCE_Inventory_Spline_GetChild = null;
			Binding.FCE_Inventory_Spline_GetDisplay = null;
			Binding.FCE_Inventory_Spline_GetDefaultWidth = null;
			Binding.FCE_Inventory_Region_GetRoot = null;
			Binding.FCE_Inventory_Region_GetParent = null;
			Binding.FCE_Inventory_Region_GetChildCount = null;
			Binding.FCE_Inventory_Region_GetChild = null;
			Binding.FCE_Inventory_Region_GetDisplay = null;
			Binding.FCE_Inventory_Region_GetEntryFromId = null;
			Binding.FCE_Inventory_Region_GetDirectoryFromId = null;
			Binding.FCE_Inventory_Region_GetRegionId = null;
			Binding.FCE_Object_Create_FromEntry = null;
			Binding.FCE_Object_Destroy = null;
			Binding.FCE_Object_AddRef = null;
			Binding.FCE_Object_Release = null;
			Binding.FCE_Object_Clone = null;
			Binding.FCE_Object_IsLoaded = null;
			Binding.FCE_Object_GetEntry = null;
			Binding.FCE_Object_GetPos = null;
			Binding.FCE_Object_SetPos = null;
			Binding.FCE_Object_GetAngles = null;
			Binding.FCE_Object_SetAngles = null;
			Binding.FCE_Object_GetBounds = null;
			Binding.FCE_Object_IsVisible = null;
			Binding.FCE_Object_SetVisible = null;
			Binding.FCE_Object_SetHighlight = null;
			Binding.FCE_Object_SetFreeze = null;
			Binding.FCE_Object_DropToGround = null;
			Binding.FCE_Object_ComputeAutoOrientation = null;
			Binding.FCE_Object_GetPivot = null;
			Binding.FCE_Object_GetClosestPivot = null;
			Binding.FCE_Object_SnapToClosestObject = null;
			Binding.FCE_Object_GetPhysEntities = null;
			Binding.FCE_AI_ShowWaveCallback = null;
			Binding.FCE_AI_SetEntityToSpawn = null;
			Binding.FCE_AI_SetWaveTransition = null;
			Binding.FCE_AI_GetWaveTransition = null;
			Binding.FCE_AI_SetAmbientProperties = null;
			Binding.FCE_AI_GetAmbientProperties = null;
			Binding.FCE_AI_SetSTPProperties = null;
			Binding.FCE_AI_GetSTPProperties = null;
			Binding.FCE_AI_SetPatrolProperties = null;
			Binding.FCE_AI_GetPatrolProperties = null;
			Binding.FCE_AI_SetAIGroup = null;
			Binding.FCE_AI_IsValidObjectiveEntity = null;
			Binding.FCE_AI_ShowWaveOnly = null;
			Binding.FCE_AI_GetStpUsage = null;
			Binding.FCE_ObjectManager_GetObjectFromScreenPoint = null;
			Binding.FCE_ObjectManager_GetObjectsFromScreenRect = null;
			Binding.FCE_ObjectManager_GetObjectsFromMagicWand = null;
			Binding.FCE_ObjectManager_SetViewportPickingPos = null;
			Binding.FCE_ObjectManager_UnfreezeObjects = null;
			Binding.FCE_ObjectManager_GetObjectCount = null;
			Binding.FCE_ObjectManager_GetObject = null;
			Binding.FCE_ObjectSelection_Create = null;
			Binding.FCE_ObjectSelection_Destroy = null;
			Binding.FCE_ObjectSelection_Clear = null;
			Binding.FCE_ObjectSelection_Add = null;
			Binding.FCE_ObjectSelection_AddSelection = null;
			Binding.FCE_ObjectSelection_ToggleObject = null;
			Binding.FCE_ObjectSelection_ToggleSelection = null;
			Binding.FCE_ObjectSelection_RemoveObject = null;
			Binding.FCE_ObjectSelection_RemoveSelection = null;
			Binding.FCE_ObjectSelection_GetCount = null;
			Binding.FCE_ObjectSelection_Get = null;
			Binding.FCE_ObjectSelection_GetValidObjects = null;
			Binding.FCE_ObjectSelection_RemoveInvalidObjects = null;
			Binding.FCE_ObjectSelection_Clone = null;
			Binding.FCE_ObjectSelection_Delete = null;
			Binding.FCE_ObjectSelection_GetCenter = null;
			Binding.FCE_ObjectSelection_SetCenter = null;
			Binding.FCE_ObjectSelection_GetComputeCenter = null;
			Binding.FCE_ObjectSelection_ComputeCenter = null;
			Binding.FCE_ObjectSelection_GetWorldBounds = null;
			Binding.FCE_ObjectSelection_MoveTo = null;
			Binding.FCE_ObjectSelection_Rotate = null;
			Binding.FCE_ObjectSelection_Rotate3 = null;
			Binding.FCE_ObjectSelection_RotateCenter = null;
			Binding.FCE_ObjectSelection_RotateLocal3 = null;
			Binding.FCE_ObjectSelection_RotateGimbal = null;
			Binding.FCE_ObjectSelection_DropToGround = null;
			Binding.FCE_ObjectSelection_SnapToPivot = null;
			Binding.FCE_ObjectSelection_SnapToClosestObjects = null;
			Binding.FCE_ObjectSelection_GetPhysEntities = null;
			Binding.FCE_ObjectSelection_ClearState = null;
			Binding.FCE_ObjectSelection_LoadState = null;
			Binding.FCE_ObjectSelection_SaveState = null;
			Binding.FCE_ObjectSelection_LoadFromXml = null;
			Binding.FCE_ObjectSelection_SaveToXml = null;
			Binding.FCE_ObjectSelection_IsAxesXYLocked = null;
			Binding.FCE_ObjectViewer_SetActive = null;
			Binding.FCE_ObjectViewer_SetObject = null;
			Binding.FCE_ObjectLegoBox_SetActive = null;
			Binding.FCE_ObjectLegoBox_AddEntry = null;
			Binding.FCE_ObjectLegoBox_ClearEntries = null;
			Binding.FCE_ObjectLegoBox_CreateLegoBox = null;
			Binding.FCE_ObjectLegoBox_GetEntryFromScreenPoint = null;
			Binding.FCE_ObjectRenderer_Clear = null;
			Binding.FCE_ObjectRenderer_SetActive = null;
			Binding.FCE_ObjectRenderer_RenderObject = null;
			Binding.FCE_ObjectRenderer_IsSnapshotReady = null;
			Binding.FCE_ObjectRenderer_GetSnapshot = null;
			Binding.FCE_ObjectRenderer_GetSnapshotEntry = null;
			Binding.FCE_ObjectRenderer_ClearSnapshot = null;
			Binding.FCE_ObjectRenderer_WritePNG = null;
			Binding.FCE_ObjectRenderer_GenerateThumbnails = null;
			Binding.FCE_CollectionRenderer_GenerateThumbnails = null;
			Binding.FCE_WaterRenderer_GenerateThumbnails = null;
			Binding.FCE_Gizmo_Create = null;
			Binding.FCE_Gizmo_Destroy = null;
			Binding.FCE_Gizmo_GetPos = null;
			Binding.FCE_Gizmo_SetPos = null;
			Binding.FCE_Gizmo_GetAxis = null;
			Binding.FCE_Gizmo_SetAxis = null;
			Binding.FCE_Gizmo_GetActive = null;
			Binding.FCE_Gizmo_SetActive = null;
			Binding.FCE_Gizmo_Redraw = null;
			Binding.FCE_Gizmo_Hide = null;
			Binding.FCE_Gizmo_IsRotationMode = null;
			Binding.FCE_Gizmo_SetRotationMode = null;
			Binding.FCE_Gizmo_ResetAxes = null;
			Binding.FCE_Gizmo_EnableAxis = null;
			Binding.FCE_Gizmo_HitTest = null;
			Binding.FCE_CollectionManager_GetCollectionEntryFromId = null;
			Binding.FCE_CollectionManager_AssignCollectionId = null;
			Binding.FCE_CollectionManager_WriteMaskCircle = null;
			Binding.FCE_CollectionManager_WriteMaskSquare = null;
			Binding.FCE_CollectionManager_ClearMaskId = null;
			Binding.FCE_CollectionManager_UpdateCollections = null;
			Binding.FCE_CollectionManager_ActivatePhysics = null;
			Binding.FCE_Collection_Paint = null;
			Binding.FCE_Collection_Paint_End = null;
			Binding.FCE_Texture_Paint = null;
			Binding.FCE_Texture_Paint_End = null;
			Binding.FCE_Texture_PaintConstraints_Begin = null;
			Binding.FCE_Texture_PaintConstraints = null;
			Binding.FCE_Texture_PaintConstraints_End = null;
			Binding.FCE_TerrainManager_GetHeightAt = null;
			Binding.FCE_TerrainManager_GetHeightAtWithWater = null;
			Binding.FCE_TerrainManager_GetTextureEntryFromId = null;
			Binding.FCE_TerrainManager_AssignTextureId = null;
			Binding.FCE_TerrainManager_ClearTextureId = null;
			Binding.FCE_TerrainManager_GetGlobalWaterLevel = null;
			Binding.FCE_TerrainManager_SetGlobalWaterLevel = null;
			Binding.FCE_TerrainManager_SetWaterLevelSector = null;
			Binding.FCE_TerrainManager_UpdateWaterLevel = null;
			Binding.FCE_TerrainManager_GetLogicZoneId = null;
			Binding.FCE_TerrainManager_SetLogicZoneId = null;
			Binding.FCE_TerrainManager_GetSoundRegionId = null;
			Binding.FCE_TerrainManager_SetSoundRegionId = null;
			Binding.FCE_UndoManager_GetUndoCount = null;
			Binding.FCE_UndoManager_GetRedoCount = null;
			Binding.FCE_UndoManager_Undo = null;
			Binding.FCE_UndoManager_Redo = null;
			Binding.FCE_UndoManager_RecordUndo = null;
			Binding.FCE_UndoManager_CommitUndo = null;
			Binding.FCE_Validation_Objective = null;
			Binding.FCE_Validation_Game = null;
			Binding.FCE_ValidationReport_Destroy = null;
			Binding.FCE_ValidationReport_GetCount = null;
			Binding.FCE_ValidationReport_GetRecord = null;
			Binding.FCE_ValidationRecord_GetSeverity = null;
			Binding.FCE_ValidationRecord_GetFlags = null;
			Binding.FCE_ValidationRecord_GetErrorCode = null;
			Binding.FCE_ValidationRecord_GetMessage = null;
			Binding.FCE_ValidationRecord_GetObject = null;
			Binding.FCE_Snapshot_Create = null;
			Binding.FCE_Snapshot_Destroy = null;
			Binding.FCE_Snapshot_GetData = null;
			Binding.FCE_Spline_Create = null;
			Binding.FCE_Spline_Destroy = null;
			Binding.FCE_Spline_Clear = null;
			Binding.FCE_Spline_AddPoint = null;
			Binding.FCE_Spline_InsertPoint = null;
			Binding.FCE_Spline_RemovePoint = null;
			Binding.FCE_Spline_RemoveSimilarPoints = null;
			Binding.FCE_Spline_OptimizePoint = null;
			Binding.FCE_Spline_GetNumPoints = null;
			Binding.FCE_Spline_GetPoint = null;
			Binding.FCE_Spline_SetPoint = null;
			Binding.FCE_Spline_UpdateSpline = null;
			Binding.FCE_Spline_UpdateSplineHeight = null;
			Binding.FCE_Spline_FinalizeSpline = null;
			Binding.FCE_Spline_Draw = null;
			Binding.FCE_Spline_HitTestPoints = null;
			Binding.FCE_Spline_HitTestSegments = null;
			Binding.FCE_SplineRoad_GetEntry = null;
			Binding.FCE_SplineRoad_SetEntry = null;
			Binding.FCE_SplineRoad_GetWidth = null;
			Binding.FCE_SplineRoad_SetWidth = null;
			Binding.FCE_SplineZone_Reset = null;
			Binding.FCE_SplineController_Create = null;
			Binding.FCE_SplineController_Destroy = null;
			Binding.FCE_SplineController_SetSpline = null;
			Binding.FCE_SplineController_ClearSelection = null;
			Binding.FCE_SplineController_IsSelected = null;
			Binding.FCE_SplineController_SetSelected = null;
			Binding.FCE_SplineController_SelectFromScreenRect = null;
			Binding.FCE_SplineController_MoveSelection = null;
			Binding.FCE_SplineController_DeleteSelection = null;
			Binding.FCE_SplineManager_CreateRoad = null;
			Binding.FCE_SplineManager_DestroyRoad = null;
			Binding.FCE_SplineManager_GetRoadFromId = null;
			Binding.FCE_SplineManager_GetPlayableZone = null;
			Binding.FCE_PhysEntityVector_Create = null;
			Binding.FCE_PhysEntityVector_Destroy = null;
			Binding.FCE_Wilderness_Desert = null;
			Binding.FCE_Wilderness_Script = null;
			Binding.FCE_Wilderness_ScriptBuffer = null;
			Binding.FCE_Script_GetNumFunctions = null;
			Binding.FCE_Script_GetFunction = null;
			Binding.FCE_ScriptFunction_GetName = null;
			Binding.FCE_ScriptFunction_GetPrototype = null;
			Binding.FCE_ScriptFunction_GetDescription = null;
			Binding.FCE_ImageMap_GetSize = null;
			Binding.FCE_ImageMap_ConvertTo24bit = null;
			Binding.FCE_ImageMap_Clone = null;
			Binding.FCE_ImageMap_Destroy = null;
			Binding.FCE_BudgetManager_GetMemoryUsage = null;
			Binding.FCE_BudgetManager_GetMaxMemoryUsageMB = null;
			Binding.FCE_BudgetManager_GetObjectUsage = null;
			Binding.FCE_BudgetManager_GetMaxObjectUsage = null;
			Binding.FCE_BudgetManager_GetWaveUsage = null;
			Binding.FCE_BudgetManager_GetMaxWaveUsage = null;
			Binding.FCE_BudgetManager_GetVehicles = null;
			Binding.FCE_BudgetManager_GetMaxVehicles = null;
			Binding.FCE_BudgetManager_GetAmbientAI = null;
			Binding.FCE_BudgetManager_GetEnemyAI = null;
			Binding.FCE_BudgetManager_ValidateObjectsGlobalCost = null;
			Binding.FCE_BudgetManager_ValidateObjectsSectorCost = null;
			Binding.FCE_BudgetManager_ValidateAIObjectsUsage = null;
			Binding.FCE_BudgetManager_ValidatePhysicsObjectsUsage = null;
			Binding.FCE_BudgetManager_ValidateLightObjectsUsage = null;
			Binding.FCE_BudgetManager_ValidateAnimPointsObjectsUsage = null;
			Binding.FCE_BudgetManager_ValidateSpawnPointsObjectsUsage = null;
			Binding.FCE_BudgetManager_GetObjectSectorId = null;
			Binding.FCE_GameModeManager_ClearObjectiveSettings = null;
			Binding.FCE_GameModeManager_AddObjectiveSetting = null;
			Binding.FCE_GameModeManager_GetObjectiveSettingBool = null;
			Binding.FCE_GameModeManager_GetObjectiveSettingNumeric = null;
			Binding.FCE_GameModeManager_GetObjectiveSettingPresetDbId = null;
			Binding.FCE_Navmesh_SetDisplay = null;
			Binding.FCE_Navmesh_RegenerateTileAt = null;
			Binding.FCE_Navmesh_SetAPDisplay = null;
			Binding.FCE_Navmesh_GetDebugAlpha = null;
			Binding.FCE_Navmesh_SetDebugAlpha = null;
			Binding.FCE_Navmesh_GetPendingTilesCount = null;
			Binding.FCE_Navmesh_IsReady = null;
			Binding.FCE_Navmesh_Sync = null;
			Binding.FCE_Navmesh_Validate = null;
			Binding.FCE_Editor_Publish_Map = null;
			Binding.FCE_Editor_PublishComlete_Callback = null;
			Binding.FCE_Editor_Login = null;
			Binding.FCE_Editor_LoginComlete_Callback = null;
			Binding.FCE_Editor_CreateIssue = null;
			Binding.IsNvidia = null;
			Binding.GetIGESteamCommandLine = null;
			Binding.FreeLibrary(Binding._gameDllModule);
			Binding._gameDllModule = IntPtr.Zero;
		}

		// Token: 0x06000A86 RID: 2694
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr LoadLibrary(string dllname);

		// Token: 0x06000A87 RID: 2695
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
		private static extern void FreeLibrary(IntPtr hModule);

		// Token: 0x06000A88 RID: 2696
		[DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string procname);

		// Token: 0x040004FE RID: 1278
		public const string engineDll = "FC64.dll";

		// Token: 0x040004FF RID: 1279
		public const string outputDir = "output\\";

		// Token: 0x04000500 RID: 1280
		public static string gameDll = "FC64.dll";

		// Token: 0x04000501 RID: 1281
		public static Binding._InitDuniaEngine InitDuniaEngine;

		// Token: 0x04000502 RID: 1282
		public static Binding._TickDuniaEngine TickDuniaEngine;

		// Token: 0x04000503 RID: 1283
		public static Binding._RunDuniaEngine RunDuniaEngine;

		// Token: 0x04000504 RID: 1284
		public static Binding._CloseDuniaEngine CloseDuniaEngine;

		// Token: 0x04000505 RID: 1285
		public static Binding._LoadIGEDll LoadIGEDll = null;

		// Token: 0x04000506 RID: 1286
		public static Binding._UnloadIGEDll UnloadIGEDll = null;

		// Token: 0x04000507 RID: 1287
		public static Binding._LocalizeText LocalizeText;

		// Token: 0x04000508 RID: 1288
		public static Binding._LocalizeTextFromLineId LocalizeTextFromLineId;

		// Token: 0x04000509 RID: 1289
		public static Binding._PC_RegisterDeviceNotification PC_RegisterDeviceNotification;

		// Token: 0x0400050A RID: 1290
		public static Binding._PC_DeviceChange PC_DeviceChange;

		// Token: 0x0400050B RID: 1291
		public static Binding._FCE_Hack_Init FCE_Hack_Init;

		// Token: 0x0400050C RID: 1292
		public static Binding._FCE_GetProgress FCE_GetProgress;

		// Token: 0x0400050D RID: 1293
		public static Binding._FCE_Engine_Reset FCE_Engine_Reset;

		// Token: 0x0400050E RID: 1294
		public static Binding._FCE_Engine_GetPersonalPath FCE_Engine_GetPersonalPath;

		// Token: 0x0400050F RID: 1295
		public static Binding._FCE_Engine_GetGenericDataPath FCE_Engine_GetGenericDataPath;

		// Token: 0x04000510 RID: 1296
		public static Binding._FCE_Engine_UpdateViewport FCE_Engine_UpdateViewport;

		// Token: 0x04000511 RID: 1297
		public static Binding._FCE_Engine_AutoAcquireInput FCE_Engine_AutoAcquireInput;

		// Token: 0x04000512 RID: 1298
		public static Binding._FCE_Engine_IsConsoleOpen FCE_Engine_IsConsoleOpen;

		// Token: 0x04000513 RID: 1299
		public static Binding._FCE_Engine_GetTimeOfDay FCE_Engine_GetTimeOfDay;

		// Token: 0x04000514 RID: 1300
		public static Binding._FCE_Engine_SetTimeOfDay FCE_Engine_SetTimeOfDay;

		// Token: 0x04000515 RID: 1301
		public static Binding._FCE_Engine_GetCloudTypeCount FCE_Engine_GetCloudTypeCount;

		// Token: 0x04000516 RID: 1302
		public static Binding._FCE_Engine_GetCloudType FCE_Engine_GetCloudType;

		// Token: 0x04000517 RID: 1303
		public static Binding._FCE_Engine_SetCloudType FCE_Engine_SetCloudType;

		// Token: 0x04000518 RID: 1304
		public static Binding._FCE_Engine_IsSnowEnabled FCE_Engine_IsSnowEnabled;

		// Token: 0x04000519 RID: 1305
		public static Binding._FCE_Engine_SetSnowEnabled FCE_Engine_SetSnowEnabled;

		// Token: 0x0400051A RID: 1306
		public static Binding._FCE_Engine_IsBackdropEnabled FCE_Engine_IsBackdropEnabled;

		// Token: 0x0400051B RID: 1307
		public static Binding._FCE_Engine_SetBackdropEnabled FCE_Engine_SetBackdropEnabled;

		// Token: 0x0400051C RID: 1308
		public static Binding._FCE_Engine_SetSelectedObject FCE_Engine_SetSelectedObject;

		// Token: 0x0400051D RID: 1309
		public static Binding._FCE_Core_GetAxisFromAngles FCE_Core_GetAxisFromAngles;

		// Token: 0x0400051E RID: 1310
		public static Binding._FCE_Core_GetAnglesFromAxis FCE_Core_GetAnglesFromAxis;

		// Token: 0x0400051F RID: 1311
		public static Binding._FCE_Core_GetAnglesFromDir FCE_Core_GetAnglesFromDir;

		// Token: 0x04000520 RID: 1312
		public static Binding._FCE_Core_Points_Create FCE_Core_Points_Create;

		// Token: 0x04000521 RID: 1313
		public static Binding._FCE_Core_Points_Destroy FCE_Core_Points_Destroy;

		// Token: 0x04000522 RID: 1314
		public static Binding._FCE_Editor_Create FCE_Editor_Create;

		// Token: 0x04000523 RID: 1315
		public static Binding._FCE_Editor_Destroy FCE_Editor_Destroy;

		// Token: 0x04000524 RID: 1316
		public static Binding._FCE_Editor_IsInitialized FCE_Editor_IsInitialized;

		// Token: 0x04000525 RID: 1317
		public static Binding._FCE_Editor_Update_Callback FCE_Editor_Update_Callback;

		// Token: 0x04000526 RID: 1318
		public static Binding._FCE_Editor_Event_Callback FCE_Editor_Event_Callback;

		// Token: 0x04000527 RID: 1319
		public static Binding._FCE_Editor_LoadCompleted_Callback FCE_Editor_LoadCompleted_Callback;

		// Token: 0x04000528 RID: 1320
		public static Binding._FCE_Editor_SaveCompleted_Callback FCE_Editor_SaveCompleted_Callback;

		// Token: 0x04000529 RID: 1321
		public static Binding._FCE_Editor_EnableUI_Callback FCE_Editor_EnableUI_Callback;

		// Token: 0x0400052A RID: 1322
		public static Binding._FCE_Editor_IsLoadPending FCE_Editor_IsLoadPending;

		// Token: 0x0400052B RID: 1323
		public static Binding._FCE_Editor_GetFrameTime FCE_Editor_GetFrameTime;

		// Token: 0x0400052C RID: 1324
		public static Binding._FCE_Editor_GetScreenPointFromWorldPos FCE_Editor_GetScreenPointFromWorldPos;

		// Token: 0x0400052D RID: 1325
		public static Binding._FCE_Editor_GetWorldRayFromScreenPoint FCE_Editor_GetWorldRayFromScreenPoint;

		// Token: 0x0400052E RID: 1326
		public static Binding._FCE_Editor_RayCastTerrain FCE_Editor_RayCastTerrain;

		// Token: 0x0400052F RID: 1327
		public static Binding._FCE_Editor_RayCastPhysics FCE_Editor_RayCastPhysics;

		// Token: 0x04000530 RID: 1328
		public static Binding._FCE_Editor_RayCastPhysics2 FCE_Editor_RayCastPhysics2;

		// Token: 0x04000531 RID: 1329
		public static Binding._FCE_Editor_ValidateSpawnPoints FCE_Editor_ValidateSpawnPoints;

		// Token: 0x04000532 RID: 1330
		public static Binding._FCE_Editor_ValidateObjective FCE_Editor_ValidateObjective;

		// Token: 0x04000533 RID: 1331
		public static Binding._FCE_Editor_EnterIngame FCE_Editor_EnterIngame;

		// Token: 0x04000534 RID: 1332
		public static Binding._FCE_Editor_ExitIngame FCE_Editor_ExitIngame;

		// Token: 0x04000535 RID: 1333
		public static Binding._FCE_Editor_IsIngame FCE_Editor_IsIngame;

		// Token: 0x04000536 RID: 1334
		public static Binding._FCE_Editor_MuteSound FCE_Editor_MuteSound;

		// Token: 0x04000537 RID: 1335
		public static Binding._FCE_Online_GetUplayUserName FCE_Online_GetUplayUserName;

		// Token: 0x04000538 RID: 1336
		public static Binding._FCE_Online_GetUplayAccountId FCE_Online_GetUplayAccountId;

		// Token: 0x04000539 RID: 1337
		public static Binding._FCE_GamerProfile_Create FCE_GamerProfile_Create;

		// Token: 0x0400053A RID: 1338
		public static Binding._FCE_GamerProfile_IsReady FCE_GamerProfile_IsReady;

		// Token: 0x0400053B RID: 1339
		public static Binding._FCE_GamerProfile_HasCreationFailed FCE_GamerProfile_HasCreationFailed;

		// Token: 0x0400053C RID: 1340
		public static Binding._FCE_GamerProfile_UpdateManager FCE_GamerProfile_UpdateManager;

		// Token: 0x0400053D RID: 1341
		public static Binding._FCE_Document_Reset FCE_Document_Reset;

		// Token: 0x0400053E RID: 1342
		public static Binding._FCE_Document_LoadPhysical FCE_Document_LoadPhysical;

		// Token: 0x0400053F RID: 1343
		public static Binding._FCE_Document_Load FCE_Document_Load;

		// Token: 0x04000540 RID: 1344
		public static Binding._FCE_Document_Save FCE_Document_Save;

		// Token: 0x04000541 RID: 1345
		public static Binding._FCE_Document_CheckValidation FCE_Document_CheckValidation;

		// Token: 0x04000542 RID: 1346
		public static Binding._FCE_Document_Validate FCE_Document_Validate;

		// Token: 0x04000543 RID: 1347
		public static Binding._FCE_Document_GetMapID FCE_Document_GetMapID;

		// Token: 0x04000544 RID: 1348
		public static Binding._FCE_Document_SetMapID FCE_Document_SetMapID;

		// Token: 0x04000545 RID: 1349
		public static Binding._FCE_Document_GetVersionID FCE_Document_GetVersionID;

		// Token: 0x04000546 RID: 1350
		public static Binding._FCE_Document_GetMapDefaultName FCE_Document_GetMapDefaultName;

		// Token: 0x04000547 RID: 1351
		public static Binding._FCE_Document_GetMapName FCE_Document_GetMapName;

		// Token: 0x04000548 RID: 1352
		public static Binding._FCE_Document_SetMapName FCE_Document_SetMapName;

		// Token: 0x04000549 RID: 1353
		public static Binding._FCE_Document_GetCreatorName FCE_Document_GetCreatorName;

		// Token: 0x0400054A RID: 1354
		public static Binding._FCE_Document_SetCreatorName FCE_Document_SetCreatorName;

		// Token: 0x0400054B RID: 1355
		public static Binding._FCE_Document_GetAuthorName FCE_Document_GetAuthorName;

		// Token: 0x0400054C RID: 1356
		public static Binding._FCE_Document_SetAuthorName FCE_Document_SetAuthorName;

		// Token: 0x0400054D RID: 1357
		public static Binding._FCE_Document_GetBattlefieldSize FCE_Document_GetBattlefieldSize;

		// Token: 0x0400054E RID: 1358
		public static Binding._FCE_Document_SetBattlefieldSize FCE_Document_SetBattlefieldSize;

		// Token: 0x0400054F RID: 1359
		public static Binding._FCE_Document_GetPlayerSize FCE_Document_GetPlayerSize;

		// Token: 0x04000550 RID: 1360
		public static Binding._FCE_Document_SetPlayerSize FCE_Document_SetPlayerSize;

		// Token: 0x04000551 RID: 1361
		public static Binding._FCE_Document_IsSnapshotSet FCE_Document_IsSnapshotSet;

		// Token: 0x04000552 RID: 1362
		public static Binding._FCE_Document_ClearSnapshot FCE_Document_ClearSnapshot;

		// Token: 0x04000553 RID: 1363
		public static Binding._FCE_Document_GetSnapshotPos FCE_Document_GetSnapshotPos;

		// Token: 0x04000554 RID: 1364
		public static Binding._FCE_Document_SetSnapshotPos FCE_Document_SetSnapshotPos;

		// Token: 0x04000555 RID: 1365
		public static Binding._FCE_Document_GetSnapshotAngle FCE_Document_GetSnapshotAngle;

		// Token: 0x04000556 RID: 1366
		public static Binding._FCE_Document_SetSnapshotAngle FCE_Document_SetSnapshotAngle;

		// Token: 0x04000557 RID: 1367
		public static Binding._FCE_Document_TakeSnapshot FCE_Document_TakeSnapshot;

		// Token: 0x04000558 RID: 1368
		public static Binding._FCE_Document_IsNavmeshEnabled FCE_Document_IsNavmeshEnabled;

		// Token: 0x04000559 RID: 1369
		public static Binding._FCE_Document_SetNavmeshEnabled FCE_Document_SetNavmeshEnabled;

		// Token: 0x0400055A RID: 1370
		public static Binding._FCE_Document_FinalizeMap FCE_Document_FinalizeMap;

		// Token: 0x0400055B RID: 1371
		public static Binding._FCE_Document_Export FCE_Document_Export;

		// Token: 0x0400055C RID: 1372
		public static Binding._FCE_Document_Dump FCE_Document_Dump;

		// Token: 0x0400055D RID: 1373
		public static Binding._FCE_Document_ExtractBigFile FCE_Document_ExtractBigFile;

		// Token: 0x0400055E RID: 1374
		public static Binding._FCE_Document_ClearMapTags FCE_Document_ClearMapTags;

		// Token: 0x0400055F RID: 1375
		public static Binding._FCE_Document_GetMapTags FCE_Document_GetMapTags;

		// Token: 0x04000560 RID: 1376
		public static Binding._FCE_Document_AppendMapTag FCE_Document_AppendMapTag;

		// Token: 0x04000561 RID: 1377
		public static Binding._FCE_WaitScreen_Show FCE_WaitScreen_Show;

		// Token: 0x04000562 RID: 1378
		public static Binding._FCE_WaitScreen_Hide FCE_WaitScreen_Hide;

		// Token: 0x04000563 RID: 1379
		public static Binding._FCE_EditorSettings_IsCollectionVisible FCE_EditorSettings_IsCollectionVisible;

		// Token: 0x04000564 RID: 1380
		public static Binding._FCE_EditorSettings_ShowCollections FCE_EditorSettings_ShowCollections;

		// Token: 0x04000565 RID: 1381
		public static Binding._FCE_EditorSettings_IsFogVisible FCE_EditorSettings_IsFogVisible;

		// Token: 0x04000566 RID: 1382
		public static Binding._FCE_EditorSettings_ShowFog FCE_EditorSettings_ShowFog;

		// Token: 0x04000567 RID: 1383
		public static Binding._FCE_EditorSettings_IsExposureVisible FCE_EditorSettings_IsExposureVisible;

		// Token: 0x04000568 RID: 1384
		public static Binding._FCE_EditorSettings_ShowExposure FCE_EditorSettings_ShowExposure;

		// Token: 0x04000569 RID: 1385
		public static Binding._FCE_EditorSettings_IsShadowVisible FCE_EditorSettings_IsShadowVisible;

		// Token: 0x0400056A RID: 1386
		public static Binding._FCE_EditorSettings_ShowShadow FCE_EditorSettings_ShowShadow;

		// Token: 0x0400056B RID: 1387
		public static Binding._FCE_EditorSettings_IsWaterVisible FCE_EditorSettings_IsWaterVisible;

		// Token: 0x0400056C RID: 1388
		public static Binding._FCE_EditorSettings_ShowWater FCE_EditorSettings_ShowWater;

		// Token: 0x0400056D RID: 1389
		public static Binding._FCE_EditorSettings_IsIconsVisible FCE_EditorSettings_IsIconsVisible;

		// Token: 0x0400056E RID: 1390
		public static Binding._FCE_EditorSettings_ShowIcons FCE_EditorSettings_ShowIcons;

		// Token: 0x0400056F RID: 1391
		public static Binding._FCE_EditorSettings_IsSoundEnabled FCE_EditorSettings_IsSoundEnabled;

		// Token: 0x04000570 RID: 1392
		public static Binding._FCE_EditorSettings_SetSoundEnabled FCE_EditorSettings_SetSoundEnabled;

		// Token: 0x04000571 RID: 1393
		public static Binding._FCE_EditorSettings_IsGridVisible FCE_EditorSettings_IsGridVisible;

		// Token: 0x04000572 RID: 1394
		public static Binding._FCE_EditorSettings_ShowGrid FCE_EditorSettings_ShowGrid;

		// Token: 0x04000573 RID: 1395
		public static Binding._FCE_EditorSettings_GetGridResolution FCE_EditorSettings_GetGridResolution;

		// Token: 0x04000574 RID: 1396
		public static Binding._FCE_EditorSettings_SetGridResolution FCE_EditorSettings_SetGridResolution;

		// Token: 0x04000575 RID: 1397
		public static Binding._FCE_EditorSettings_IsBudgetGridVisible FCE_EditorSettings_IsBudgetGridVisible;

		// Token: 0x04000576 RID: 1398
		public static Binding._FCE_EditorSettings_ShowBudgetGrid_Callback FCE_EditorSettings_ShowBudgetGrid_Callback;

		// Token: 0x04000577 RID: 1399
		public static Binding._FCE_EditorSettings_ShowBudgetGrid FCE_EditorSettings_ShowBudgetGrid;

		// Token: 0x04000578 RID: 1400
		public static Binding._FCE_EditorSettings_GetBudgetGridResolution FCE_EditorSettings_GetBudgetGridResolution;

		// Token: 0x04000579 RID: 1401
		public static Binding._FCE_EditorSettings_SetBudgetGridResolution FCE_EditorSettings_SetBudgetGridResolution;

		// Token: 0x0400057A RID: 1402
		public static Binding._FCE_EditorSettings_IsNavmeshVisible FCE_EditorSettings_IsNavmeshVisible;

		// Token: 0x0400057B RID: 1403
		public static Binding._FCE_EditorSettings_ShowNavmesh FCE_EditorSettings_ShowNavmesh;

		// Token: 0x0400057C RID: 1404
		public static Binding._FCE_EditorSettings_HideNavmesh FCE_EditorSettings_HideNavmesh;

		// Token: 0x0400057D RID: 1405
		public static Binding._FCE_EditorSettings_GetNavmeshLayer FCE_EditorSettings_GetNavmeshLayer;

		// Token: 0x0400057E RID: 1406
		public static Binding._FCE_EditorSettings_IsCoversVisible FCE_EditorSettings_IsCoversVisible;

		// Token: 0x0400057F RID: 1407
		public static Binding._FCE_EditorSettings_ShowCovers FCE_EditorSettings_ShowCovers;

		// Token: 0x04000580 RID: 1408
		public static Binding._FCE_EditorSettings_IsInvincible FCE_EditorSettings_IsInvincible;

		// Token: 0x04000581 RID: 1409
		public static Binding._FCE_EditorSettings_SetInvincible FCE_EditorSettings_SetInvincible;

		// Token: 0x04000582 RID: 1410
		public static Binding._FCE_EditorSettings_IsInvisible FCE_EditorSettings_IsInvisible;

		// Token: 0x04000583 RID: 1411
		public static Binding._FCE_EditorSettings_SetInvisible FCE_EditorSettings_SetInvisible;

		// Token: 0x04000584 RID: 1412
		public static Binding._FCE_EditorSettings_IsSnappingObjectsToTerrain FCE_EditorSettings_IsSnappingObjectsToTerrain;

		// Token: 0x04000585 RID: 1413
		public static Binding._FCE_EditorSettings_SetSnapObjectsToTerrain FCE_EditorSettings_SetSnapObjectsToTerrain;

		// Token: 0x04000586 RID: 1414
		public static Binding._FCE_EditorSettings_IsAutoSnappingObjects FCE_EditorSettings_IsAutoSnappingObjects;

		// Token: 0x04000587 RID: 1415
		public static Binding._FCE_EditorSettings_SetAutoSnappingObjects FCE_EditorSettings_SetAutoSnappingObjects;

		// Token: 0x04000588 RID: 1416
		public static Binding._FCE_EditorSettings_IsAutoSnappingObjectsRotation FCE_EditorSettings_IsAutoSnappingObjectsRotation;

		// Token: 0x04000589 RID: 1417
		public static Binding._FCE_EditorSettings_SetAutoSnappingObjectsRotation FCE_EditorSettings_SetAutoSnappingObjectsRotation;

		// Token: 0x0400058A RID: 1418
		public static Binding._FCE_EditorSettings_IsAutoSnappingObjectsTerrain FCE_EditorSettings_IsAutoSnappingObjectsTerrain;

		// Token: 0x0400058B RID: 1419
		public static Binding._FCE_EditorSettings_SetAutoSnappingObjectsTerrain FCE_EditorSettings_SetAutoSnappingObjectsTerrain;

		// Token: 0x0400058C RID: 1420
		public static Binding._FCE_EditorSettings_IsCameraClippedTerrain FCE_EditorSettings_IsCameraClippedTerrain;

		// Token: 0x0400058D RID: 1421
		public static Binding._FCE_EditorSettings_SetCameraClipTerrain FCE_EditorSettings_SetCameraClipTerrain;

		// Token: 0x0400058E RID: 1422
		public static Binding._FCE_EditorSettings_IsCameraCollision FCE_EditorSettings_IsCameraCollision;

		// Token: 0x0400058F RID: 1423
		public static Binding._FCE_EditorSettings_SetCameraCollision FCE_EditorSettings_SetCameraCollision;

		// Token: 0x04000590 RID: 1424
		public static Binding._FCE_EditorSettings_GetEngineQuality FCE_EditorSettings_GetEngineQuality;

		// Token: 0x04000591 RID: 1425
		public static Binding._FCE_EditorSettings_SetEngineQuality FCE_EditorSettings_SetEngineQuality;

		// Token: 0x04000592 RID: 1426
		public static Binding._FCE_EditorSettings_IsKillDistanceOverride FCE_EditorSettings_IsKillDistanceOverride;

		// Token: 0x04000593 RID: 1427
		public static Binding._FCE_EditorSettings_SetKillDistanceOverride FCE_EditorSettings_SetKillDistanceOverride;

		// Token: 0x04000594 RID: 1428
		public static Binding._FCE_EditorSettings_IsOcclusionVisible FCE_EditorSettings_IsOcclusionVisible;

		// Token: 0x04000595 RID: 1429
		public static Binding._FCE_EditorSettings_ShowOcclusion FCE_EditorSettings_ShowOcclusion;

		// Token: 0x04000596 RID: 1430
		public static Binding._FCE_NomadDbIdVector_Create FCE_NomadDbIdVector_Create;

		// Token: 0x04000597 RID: 1431
		public static Binding._FCE_NomadDbIdVector_Destroy FCE_NomadDbIdVector_Destroy;

		// Token: 0x04000598 RID: 1432
		public static Binding._FCE_NomadDbIdVector_GetCount FCE_NomadDbIdVector_GetCount;

		// Token: 0x04000599 RID: 1433
		public static Binding._FCE_NomadDbIdVector_GetAt FCE_NomadDbIdVector_GetAt;

		// Token: 0x0400059A RID: 1434
		public static Binding._FCE_GameMode_GetAllGameModeDescDbIds FCE_GameMode_GetAllGameModeDescDbIds;

		// Token: 0x0400059B RID: 1435
		public static Binding._FCE_GameMode_GetGameModeNameId FCE_GameMode_GetGameModeNameId;

		// Token: 0x0400059C RID: 1436
		public static Binding._FCE_GameMode_GetObjectiveDescDbIds FCE_GameMode_GetObjectiveDescDbIds;

		// Token: 0x0400059D RID: 1437
		public static Binding._FCE_GameMode_GetObjectiveNameId FCE_GameMode_GetObjectiveNameId;

		// Token: 0x0400059E RID: 1438
		public static Binding._FCE_GameMode_GetObjectiveDescId FCE_GameMode_GetObjectiveDescId;

		// Token: 0x0400059F RID: 1439
		public static Binding._FCE_GameMode_GetCurrentObjectiveDescId FCE_GameMode_GetCurrentObjectiveDescId;

		// Token: 0x040005A0 RID: 1440
		public static Binding._FCE_GameMode_SetCurrentObjectiveDescId FCE_GameMode_SetCurrentObjectiveDescId;

		// Token: 0x040005A1 RID: 1441
		public static Binding._FCE_GameMode_GetCurrentGameModeDescId FCE_GameMode_GetCurrentGameModeDescId;

		// Token: 0x040005A2 RID: 1442
		public static Binding._FCE_GameMode_SetCurrentGameModeDescId FCE_GameMode_SetCurrentGameModeDescId;

		// Token: 0x040005A3 RID: 1443
		public static Binding._FCE_GameMode_GetObjectiveEnumValue FCE_GameMode_GetObjectiveEnumValue;

		// Token: 0x040005A4 RID: 1444
		public static Binding._FCE_GameMode_GetAllWildernessDbIds FCE_GameMode_GetAllWildernessDbIds;

		// Token: 0x040005A5 RID: 1445
		public static Binding._FCE_GameMode_WildernessNameId FCE_GameMode_WildernessNameId;

		// Token: 0x040005A6 RID: 1446
		public static Binding._FCE_GameMode_WildernessScriptPathId FCE_GameMode_WildernessScriptPathId;

		// Token: 0x040005A7 RID: 1447
		public static Binding._FCE_GameProperty_GetAllPropertyIds FCE_GameProperty_GetAllPropertyIds;

		// Token: 0x040005A8 RID: 1448
		public static Binding._FCE_GameProperty_GetPropertyID FCE_GameProperty_GetPropertyID;

		// Token: 0x040005A9 RID: 1449
		public static Binding._FCE_GameProperty_GetPropertyType FCE_GameProperty_GetPropertyType;

		// Token: 0x040005AA RID: 1450
		public static Binding._FCE_GameProperty_GetPropertyValueType FCE_GameProperty_GetPropertyValueType;

		// Token: 0x040005AB RID: 1451
		public static Binding._FCE_GameProperty_GetSupportedObjectiveDescDbIds FCE_GameProperty_GetSupportedObjectiveDescDbIds;

		// Token: 0x040005AC RID: 1452
		public static Binding._FCE_GameProperty_GetPropertyChildID FCE_GameProperty_GetPropertyChildID;

		// Token: 0x040005AD RID: 1453
		public static Binding._FCE_GameProperty_GetPropertyMinValue FCE_GameProperty_GetPropertyMinValue;

		// Token: 0x040005AE RID: 1454
		public static Binding._FCE_GameProperty_GetPropertyMaxValue FCE_GameProperty_GetPropertyMaxValue;

		// Token: 0x040005AF RID: 1455
		public static Binding._FCE_GameProperty_GetPropertyResolution FCE_GameProperty_GetPropertyResolution;

		// Token: 0x040005B0 RID: 1456
		public static Binding._FCE_GameProperty_GetPropertyDefaultFloat FCE_GameProperty_GetPropertyDefaultFloat;

		// Token: 0x040005B1 RID: 1457
		public static Binding._FCE_GameProperty_GetPropertyDefaultBoolean FCE_GameProperty_GetPropertyDefaultBoolean;

		// Token: 0x040005B2 RID: 1458
		public static Binding._FCE_GameProperty_GetPropertyDefaultPresetId FCE_GameProperty_GetPropertyDefaultPresetId;

		// Token: 0x040005B3 RID: 1459
		public static Binding._FCE_GameProperty_GetPropertyDisplayNameId FCE_GameProperty_GetPropertyDisplayNameId;

		// Token: 0x040005B4 RID: 1460
		public static Binding._FCE_GameProperty_GetPropertyCategoryNameId FCE_GameProperty_GetPropertyCategoryNameId;

		// Token: 0x040005B5 RID: 1461
		public static Binding._FCE_GameProperty_GetPropertyPresetIds FCE_GameProperty_GetPropertyPresetIds;

		// Token: 0x040005B6 RID: 1462
		public static Binding._FCE_GameProperty_GetPropertyPresetDisplayNameId FCE_GameProperty_GetPropertyPresetDisplayNameId;

		// Token: 0x040005B7 RID: 1463
		public static Binding._FCE_MapTag_GetAllDbIds FCE_MapTag_GetAllDbIds;

		// Token: 0x040005B8 RID: 1464
		public static Binding._FCE_MapTag_GetDisplayNameId FCE_MapTag_GetDisplayNameId;

		// Token: 0x040005B9 RID: 1465
		public static Binding._FCE_MapTag_GetObjectiveRef FCE_MapTag_GetObjectiveRef;

		// Token: 0x040005BA RID: 1466
		public static Binding._FCE_MapTag_GetModifierRefs FCE_MapTag_GetModifierRefs;

		// Token: 0x040005BB RID: 1467
		public static Binding._FCE_MapTag_GetAvailableGameModes FCE_MapTag_GetAvailableGameModes;

		// Token: 0x040005BC RID: 1468
		public static Binding._FCE_MapTag_GetPresetRefs FCE_MapTag_GetPresetRefs;

		// Token: 0x040005BD RID: 1469
		public static Binding._FCE_MapTag_GetIsAuto FCE_MapTag_GetIsAuto;

		// Token: 0x040005BE RID: 1470
		public static Binding._FCE_MapTag_GetIsEnum FCE_MapTag_GetIsEnum;

		// Token: 0x040005BF RID: 1471
		public static Binding._FCE_MapTag_GetIsEnumDefault FCE_MapTag_GetIsEnumDefault;

		// Token: 0x040005C0 RID: 1472
		public static Binding._FCE_MapTag_GetPriority FCE_MapTag_GetPriority;

		// Token: 0x040005C1 RID: 1473
		public static Binding._FCE_PC_KeyboardKeyEvent FCE_PC_KeyboardKeyEvent;

		// Token: 0x040005C2 RID: 1474
		public static Binding._FCE_Draw_BeginGroup FCE_Draw_BeginGroup;

		// Token: 0x040005C3 RID: 1475
		public static Binding._FCE_Draw_EndGroup FCE_Draw_EndGroup;

		// Token: 0x040005C4 RID: 1476
		public static Binding._FCE_Draw_ScreenCircleOutlined FCE_Draw_ScreenCircleOutlined;

		// Token: 0x040005C5 RID: 1477
		public static Binding._FCE_Draw_ScreenRectangleOutlined FCE_Draw_ScreenRectangleOutlined;

		// Token: 0x040005C6 RID: 1478
		public static Binding._FCE_Draw_Quad FCE_Draw_Quad;

		// Token: 0x040005C7 RID: 1479
		public static Binding._FCE_Draw_Square FCE_Draw_Square;

		// Token: 0x040005C8 RID: 1480
		public static Binding._FCE_Draw_Terrain_Circle FCE_Draw_Terrain_Circle;

		// Token: 0x040005C9 RID: 1481
		public static Binding._FCE_Draw_Terrain_Square FCE_Draw_Terrain_Square;

		// Token: 0x040005CA RID: 1482
		public static Binding._FCE_Draw_Arrow FCE_Draw_Arrow;

		// Token: 0x040005CB RID: 1483
		public static Binding._FCE_Draw_Dot FCE_Draw_Dot;

		// Token: 0x040005CC RID: 1484
		public static Binding._FCE_Draw_SegmentedLineSegment FCE_Draw_SegmentedLineSegment;

		// Token: 0x040005CD RID: 1485
		public static Binding._FCE_Draw_WireBoxFromBottomZ FCE_Draw_WireBoxFromBottomZ;

		// Token: 0x040005CE RID: 1486
		public static Binding._FCE_Draw_WireRegionFromTerrain FCE_Draw_WireRegionFromTerrain;

		// Token: 0x040005CF RID: 1487
		public static Binding._FCE_Camera_Input_Forward FCE_Camera_Input_Forward;

		// Token: 0x040005D0 RID: 1488
		public static Binding._FCE_Camera_Input_Lateral FCE_Camera_Input_Lateral;

		// Token: 0x040005D1 RID: 1489
		public static Binding._FCE_Camera_GetPos FCE_Camera_GetPos;

		// Token: 0x040005D2 RID: 1490
		public static Binding._FCE_Camera_SetPos FCE_Camera_SetPos;

		// Token: 0x040005D3 RID: 1491
		public static Binding._FCE_Camera_GetAngles FCE_Camera_GetAngles;

		// Token: 0x040005D4 RID: 1492
		public static Binding._FCE_Camera_SetAngles FCE_Camera_SetAngles;

		// Token: 0x040005D5 RID: 1493
		public static Binding._FCE_Camera_Rotate FCE_Camera_Rotate;

		// Token: 0x040005D6 RID: 1494
		public static Binding._FCE_Camera_GetFrontVector FCE_Camera_GetFrontVector;

		// Token: 0x040005D7 RID: 1495
		public static Binding._FCE_Camera_GetRightVector FCE_Camera_GetRightVector;

		// Token: 0x040005D8 RID: 1496
		public static Binding._FCE_Camera_GetUpVector FCE_Camera_GetUpVector;

		// Token: 0x040005D9 RID: 1497
		public static Binding._FCE_Camera_GetSpeed FCE_Camera_GetSpeed;

		// Token: 0x040005DA RID: 1498
		public static Binding._FCE_Camera_SetSpeed FCE_Camera_SetSpeed;

		// Token: 0x040005DB RID: 1499
		public static Binding._FCE_Camera_SetSpeedFactor FCE_Camera_SetSpeedFactor;

		// Token: 0x040005DC RID: 1500
		public static Binding._FCE_Camera_GetFOV FCE_Camera_GetFOV;

		// Token: 0x040005DD RID: 1501
		public static Binding._FCE_Camera_AlignToSelection FCE_Camera_AlignToSelection;

		// Token: 0x040005DE RID: 1502
		public static Binding._FCE_Camera_AlignToObject FCE_Camera_AlignToObject;

		// Token: 0x040005DF RID: 1503
		public static Binding._FCE_Brush_Create FCE_Brush_Create;

		// Token: 0x040005E0 RID: 1504
		public static Binding._FCE_Brush_Destroy FCE_Brush_Destroy;

		// Token: 0x040005E1 RID: 1505
		public static Binding._FCE_Terrain_Bump FCE_Terrain_Bump;

		// Token: 0x040005E2 RID: 1506
		public static Binding._FCE_Terrain_Bump_End FCE_Terrain_Bump_End;

		// Token: 0x040005E3 RID: 1507
		public static Binding._FCE_Terrain_RaiseLower FCE_Terrain_RaiseLower;

		// Token: 0x040005E4 RID: 1508
		public static Binding._FCE_Terrain_RaiseLower_End FCE_Terrain_RaiseLower_End;

		// Token: 0x040005E5 RID: 1509
		public static Binding._FCE_Terrain_SetHeight FCE_Terrain_SetHeight;

		// Token: 0x040005E6 RID: 1510
		public static Binding._FCE_Terrain_SetHeight_End FCE_Terrain_SetHeight_End;

		// Token: 0x040005E7 RID: 1511
		public static Binding._FCE_Terrain_GetAverageHeight FCE_Terrain_GetAverageHeight;

		// Token: 0x040005E8 RID: 1512
		public static Binding._FCE_Terrain_Average FCE_Terrain_Average;

		// Token: 0x040005E9 RID: 1513
		public static Binding._FCE_Terrain_Average_End FCE_Terrain_Average_End;

		// Token: 0x040005EA RID: 1514
		public static Binding._FCE_Terrain_Grab_Begin FCE_Terrain_Grab_Begin;

		// Token: 0x040005EB RID: 1515
		public static Binding._FCE_Terrain_Grab FCE_Terrain_Grab;

		// Token: 0x040005EC RID: 1516
		public static Binding._FCE_Terrain_Grab_End FCE_Terrain_Grab_End;

		// Token: 0x040005ED RID: 1517
		public static Binding._FCE_Terrain_Smooth FCE_Terrain_Smooth;

		// Token: 0x040005EE RID: 1518
		public static Binding._FCE_Terrain_Smooth_End FCE_Terrain_Smooth_End;

		// Token: 0x040005EF RID: 1519
		public static Binding._FCE_Terrain_Ramp FCE_Terrain_Ramp;

		// Token: 0x040005F0 RID: 1520
		public static Binding._FCE_Terrain_Terrace FCE_Terrain_Terrace;

		// Token: 0x040005F1 RID: 1521
		public static Binding._FCE_Terrain_Terrace_End FCE_Terrain_Terrace_End;

		// Token: 0x040005F2 RID: 1522
		public static Binding._FCE_Terrain_Noise_Begin FCE_Terrain_Noise_Begin;

		// Token: 0x040005F3 RID: 1523
		public static Binding._FCE_Terrain_Noise FCE_Terrain_Noise;

		// Token: 0x040005F4 RID: 1524
		public static Binding._FCE_Terrain_Noise_End FCE_Terrain_Noise_End;

		// Token: 0x040005F5 RID: 1525
		public static Binding._FCE_Terrain_Erosion FCE_Terrain_Erosion;

		// Token: 0x040005F6 RID: 1526
		public static Binding._FCE_Terrain_Erosion_End FCE_Terrain_Erosion_End;

		// Token: 0x040005F7 RID: 1527
		public static Binding._FCE_Terrain_Hole FCE_Terrain_Hole;

		// Token: 0x040005F8 RID: 1528
		public static Binding._FCE_Terrain_Hole_End FCE_Terrain_Hole_End;

		// Token: 0x040005F9 RID: 1529
		public static Binding._FCE_Inventory_Entry_IsDirectory FCE_Inventory_Entry_IsDirectory;

		// Token: 0x040005FA RID: 1530
		public static Binding._FCE_Inventory_Entry_IsDeleted FCE_Inventory_Entry_IsDeleted;

		// Token: 0x040005FB RID: 1531
		public static Binding._FCE_Inventory_Entry_SetDeleted FCE_Inventory_Entry_SetDeleted;

		// Token: 0x040005FC RID: 1532
		public static Binding._FCE_Inventory_Entry_ClearChildren FCE_Inventory_Entry_ClearChildren;

		// Token: 0x040005FD RID: 1533
		public static Binding._FCE_Inventory_Entry_AddChild FCE_Inventory_Entry_AddChild;

		// Token: 0x040005FE RID: 1534
		public static Binding._FCE_Inventory_Entry_SetChildIndex FCE_Inventory_Entry_SetChildIndex;

		// Token: 0x040005FF RID: 1535
		public static Binding._FCE_Inventory_Entry_OpenThumbnailData FCE_Inventory_Entry_OpenThumbnailData;

		// Token: 0x04000600 RID: 1536
		public static Binding._FCE_Inventory_Entry_CloseThumbnailData FCE_Inventory_Entry_CloseThumbnailData;

		// Token: 0x04000601 RID: 1537
		public static Binding._FCE_Inventory_Object_GetRoot FCE_Inventory_Object_GetRoot;

		// Token: 0x04000602 RID: 1538
		public static Binding._FCE_Inventory_Object_CreatePrefabObject FCE_Inventory_Object_CreatePrefabObject;

		// Token: 0x04000603 RID: 1539
		public static Binding._FCE_Inventory_Object_CreateDirectory FCE_Inventory_Object_CreateDirectory;

		// Token: 0x04000604 RID: 1540
		public static Binding._FCE_Inventory_Object_CreateFilterDirectory FCE_Inventory_Object_CreateFilterDirectory;

		// Token: 0x04000605 RID: 1541
		public static Binding._FCE_Inventory_Object_DestroyFilterDirectory FCE_Inventory_Object_DestroyFilterDirectory;

		// Token: 0x04000606 RID: 1542
		public static Binding._FCE_Inventory_Object_SearchInventoryEntry FCE_Inventory_Object_SearchInventoryEntry;

		// Token: 0x04000607 RID: 1543
		public static Binding._FCE_Inventory_Object_GetParent FCE_Inventory_Object_GetParent;

		// Token: 0x04000608 RID: 1544
		public static Binding._FCE_Inventory_Object_SetParent FCE_Inventory_Object_SetParent;

		// Token: 0x04000609 RID: 1545
		public static Binding._FCE_Inventory_Object_IsDirectory FCE_Inventory_Object_IsDirectory;

		// Token: 0x0400060A RID: 1546
		public static Binding._FCE_Inventory_Object_GetChildCount FCE_Inventory_Object_GetChildCount;

		// Token: 0x0400060B RID: 1547
		public static Binding._FCE_Inventory_Object_GetChild FCE_Inventory_Object_GetChild;

		// Token: 0x0400060C RID: 1548
		public static Binding._FCE_Inventory_Object_GetId FCE_Inventory_Object_GetId;

		// Token: 0x0400060D RID: 1549
		public static Binding._FCE_Inventory_Object_GetIdString FCE_Inventory_Object_GetIdString;

		// Token: 0x0400060E RID: 1550
		public static Binding._FCE_Inventory_Object_SetIdString FCE_Inventory_Object_SetIdString;

		// Token: 0x0400060F RID: 1551
		public static Binding._FCE_Inventory_Object_GetDisplay FCE_Inventory_Object_GetDisplay;

		// Token: 0x04000610 RID: 1552
		public static Binding._FCE_Inventory_Object_SetDisplay FCE_Inventory_Object_SetDisplay;

		// Token: 0x04000611 RID: 1553
		public static Binding._FCE_Inventory_Object_GetTags FCE_Inventory_Object_GetTags;

		// Token: 0x04000612 RID: 1554
		public static Binding._FCE_Inventory_Object_SetTags FCE_Inventory_Object_SetTags;

		// Token: 0x04000613 RID: 1555
		public static Binding._FCE_Inventory_Object_GetSourceType FCE_Inventory_Object_GetSourceType;

		// Token: 0x04000614 RID: 1556
		public static Binding._FCE_Inventory_Object_GetBMin FCE_Inventory_Object_GetBMin;

		// Token: 0x04000615 RID: 1557
		public static Binding._FCE_Inventory_Object_GetBMax FCE_Inventory_Object_GetBMax;

		// Token: 0x04000616 RID: 1558
		public static Binding._FCE_Inventory_Object_GetSize FCE_Inventory_Object_GetSize;

		// Token: 0x04000617 RID: 1559
		public static Binding._FCE_Inventory_Object_IsAI FCE_Inventory_Object_IsAI;

		// Token: 0x04000618 RID: 1560
		public static Binding._FCE_Inventory_Object_IsObjectType FCE_Inventory_Object_IsObjectType;

		// Token: 0x04000619 RID: 1561
		public static Binding._FCE_Inventory_Object_IsAutoOrientation FCE_Inventory_Object_IsAutoOrientation;

		// Token: 0x0400061A RID: 1562
		public static Binding._FCE_Inventory_Object_GetZOffset FCE_Inventory_Object_GetZOffset;

		// Token: 0x0400061B RID: 1563
		public static Binding._FCE_Inventory_Object_SetZOffset FCE_Inventory_Object_SetZOffset;

		// Token: 0x0400061C RID: 1564
		public static Binding._FCE_Inventory_Object_SaveChanges FCE_Inventory_Object_SaveChanges;

		// Token: 0x0400061D RID: 1565
		public static Binding._FCE_Inventory_Object_ClearPivots FCE_Inventory_Object_ClearPivots;

		// Token: 0x0400061E RID: 1566
		public static Binding._FCE_Inventory_Object_AddPivot FCE_Inventory_Object_AddPivot;

		// Token: 0x0400061F RID: 1567
		public static Binding._FCE_Inventory_Object_SetPivot FCE_Inventory_Object_SetPivot;

		// Token: 0x04000620 RID: 1568
		public static Binding._FCE_Inventory_Object_SetPivots FCE_Inventory_Object_SetPivots;

		// Token: 0x04000621 RID: 1569
		public static Binding._FCE_Inventory_Object_IsAutoPivot FCE_Inventory_Object_IsAutoPivot;

		// Token: 0x04000622 RID: 1570
		public static Binding._FCE_Inventory_Object_SetAutoPivot FCE_Inventory_Object_SetAutoPivot;

		// Token: 0x04000623 RID: 1571
		public static Binding._FCE_Inventory_Object_GetPivotCount FCE_Inventory_Object_GetPivotCount;

		// Token: 0x04000624 RID: 1572
		public static Binding._FCE_Inventory_Object_HasComponent FCE_Inventory_Object_HasComponent;

		// Token: 0x04000625 RID: 1573
		public static Binding._FCE_Inventory_Object_GetArchetypeId FCE_Inventory_Object_GetArchetypeId;

		// Token: 0x04000626 RID: 1574
		public static Binding._FCE_Inventory_Object_GetWaveNum FCE_Inventory_Object_GetWaveNum;

		// Token: 0x04000627 RID: 1575
		public static Binding._FCE_Inventory_Object_IsObjectiveGameplayObject FCE_Inventory_Object_IsObjectiveGameplayObject;

		// Token: 0x04000628 RID: 1576
		public static Binding._FCE_Inventory_Collection_GetRoot FCE_Inventory_Collection_GetRoot;

		// Token: 0x04000629 RID: 1577
		public static Binding._FCE_Inventory_Collection_GetParent FCE_Inventory_Collection_GetParent;

		// Token: 0x0400062A RID: 1578
		public static Binding._FCE_Inventory_Collection_GetChildCount FCE_Inventory_Collection_GetChildCount;

		// Token: 0x0400062B RID: 1579
		public static Binding._FCE_Inventory_Collection_GetChild FCE_Inventory_Collection_GetChild;

		// Token: 0x0400062C RID: 1580
		public static Binding._FCE_Inventory_Collection_GetDisplay FCE_Inventory_Collection_GetDisplay;

		// Token: 0x0400062D RID: 1581
		public static Binding._FCE_Inventory_Collection_GetBurnProfile FCE_Inventory_Collection_GetBurnProfile;

		// Token: 0x0400062E RID: 1582
		public static Binding._FCE_Inventory_Texture_GetRoot FCE_Inventory_Texture_GetRoot;

		// Token: 0x0400062F RID: 1583
		public static Binding._FCE_Inventory_Texture_GetParent FCE_Inventory_Texture_GetParent;

		// Token: 0x04000630 RID: 1584
		public static Binding._FCE_Inventory_Texture_GetChildCount FCE_Inventory_Texture_GetChildCount;

		// Token: 0x04000631 RID: 1585
		public static Binding._FCE_Inventory_Texture_GetChild FCE_Inventory_Texture_GetChild;

		// Token: 0x04000632 RID: 1586
		public static Binding._FCE_Inventory_Texture_GetDisplay FCE_Inventory_Texture_GetDisplay;

		// Token: 0x04000633 RID: 1587
		public static Binding._FCE_Inventory_Water_GetRoot FCE_Inventory_Water_GetRoot;

		// Token: 0x04000634 RID: 1588
		public static Binding._FCE_Inventory_Water_GetParent FCE_Inventory_Water_GetParent;

		// Token: 0x04000635 RID: 1589
		public static Binding._FCE_Inventory_Water_GetChildCount FCE_Inventory_Water_GetChildCount;

		// Token: 0x04000636 RID: 1590
		public static Binding._FCE_Inventory_Water_GetChild FCE_Inventory_Water_GetChild;

		// Token: 0x04000637 RID: 1591
		public static Binding._FCE_Inventory_Water_GetDisplay FCE_Inventory_Water_GetDisplay;

		// Token: 0x04000638 RID: 1592
		public static Binding._FCE_Inventory_Water_GetFromId FCE_Inventory_Water_GetFromId;

		// Token: 0x04000639 RID: 1593
		public static Binding._FCE_Inventory_Spline_GetRoot FCE_Inventory_Spline_GetRoot;

		// Token: 0x0400063A RID: 1594
		public static Binding._FCE_Inventory_Spline_GetParent FCE_Inventory_Spline_GetParent;

		// Token: 0x0400063B RID: 1595
		public static Binding._FCE_Inventory_Spline_GetChildCount FCE_Inventory_Spline_GetChildCount;

		// Token: 0x0400063C RID: 1596
		public static Binding._FCE_Inventory_Spline_GetChild FCE_Inventory_Spline_GetChild;

		// Token: 0x0400063D RID: 1597
		public static Binding._FCE_Inventory_Spline_GetDisplay FCE_Inventory_Spline_GetDisplay;

		// Token: 0x0400063E RID: 1598
		public static Binding._FCE_Inventory_Spline_GetDefaultWidth FCE_Inventory_Spline_GetDefaultWidth;

		// Token: 0x0400063F RID: 1599
		public static Binding._FCE_Inventory_Region_GetRoot FCE_Inventory_Region_GetRoot;

		// Token: 0x04000640 RID: 1600
		public static Binding._FCE_Inventory_Region_GetParent FCE_Inventory_Region_GetParent;

		// Token: 0x04000641 RID: 1601
		public static Binding._FCE_Inventory_Region_GetChildCount FCE_Inventory_Region_GetChildCount;

		// Token: 0x04000642 RID: 1602
		public static Binding._FCE_Inventory_Region_GetChild FCE_Inventory_Region_GetChild;

		// Token: 0x04000643 RID: 1603
		public static Binding._FCE_Inventory_Region_GetDisplay FCE_Inventory_Region_GetDisplay;

		// Token: 0x04000644 RID: 1604
		public static Binding._FCE_Inventory_Region_GetEntryFromId FCE_Inventory_Region_GetEntryFromId;

		// Token: 0x04000645 RID: 1605
		public static Binding._FCE_Inventory_Region_GetDirectoryFromId FCE_Inventory_Region_GetDirectoryFromId;

		// Token: 0x04000646 RID: 1606
		public static Binding._FCE_Inventory_Region_GetRegionId FCE_Inventory_Region_GetRegionId;

		// Token: 0x04000647 RID: 1607
		public static Binding._FCE_Object_Create_FromEntry FCE_Object_Create_FromEntry;

		// Token: 0x04000648 RID: 1608
		public static Binding._FCE_Object_Destroy FCE_Object_Destroy;

		// Token: 0x04000649 RID: 1609
		public static Binding._FCE_Object_AddRef FCE_Object_AddRef;

		// Token: 0x0400064A RID: 1610
		public static Binding._FCE_Object_Release FCE_Object_Release;

		// Token: 0x0400064B RID: 1611
		public static Binding._FCE_Object_Clone FCE_Object_Clone;

		// Token: 0x0400064C RID: 1612
		public static Binding._FCE_Object_IsLoaded FCE_Object_IsLoaded;

		// Token: 0x0400064D RID: 1613
		public static Binding._FCE_Object_GetEntry FCE_Object_GetEntry;

		// Token: 0x0400064E RID: 1614
		public static Binding._FCE_Object_GetPos FCE_Object_GetPos;

		// Token: 0x0400064F RID: 1615
		public static Binding._FCE_Object_SetPos FCE_Object_SetPos;

		// Token: 0x04000650 RID: 1616
		public static Binding._FCE_Object_GetAngles FCE_Object_GetAngles;

		// Token: 0x04000651 RID: 1617
		public static Binding._FCE_Object_SetAngles FCE_Object_SetAngles;

		// Token: 0x04000652 RID: 1618
		public static Binding._FCE_Object_GetBounds FCE_Object_GetBounds;

		// Token: 0x04000653 RID: 1619
		public static Binding._FCE_Object_IsVisible FCE_Object_IsVisible;

		// Token: 0x04000654 RID: 1620
		public static Binding._FCE_Object_SetVisible FCE_Object_SetVisible;

		// Token: 0x04000655 RID: 1621
		public static Binding._FCE_Object_SetHighlight FCE_Object_SetHighlight;

		// Token: 0x04000656 RID: 1622
		public static Binding._FCE_Object_SetFreeze FCE_Object_SetFreeze;

		// Token: 0x04000657 RID: 1623
		public static Binding._FCE_Object_DropToGround FCE_Object_DropToGround;

		// Token: 0x04000658 RID: 1624
		public static Binding._FCE_Object_ComputeAutoOrientation FCE_Object_ComputeAutoOrientation;

		// Token: 0x04000659 RID: 1625
		public static Binding._FCE_Object_GetPivot FCE_Object_GetPivot;

		// Token: 0x0400065A RID: 1626
		public static Binding._FCE_Object_GetClosestPivot FCE_Object_GetClosestPivot;

		// Token: 0x0400065B RID: 1627
		public static Binding._FCE_Object_SnapToClosestObject FCE_Object_SnapToClosestObject;

		// Token: 0x0400065C RID: 1628
		public static Binding._FCE_Object_GetPhysEntities FCE_Object_GetPhysEntities;

		// Token: 0x0400065D RID: 1629
		public static Binding._FCE_AI_ShowWaveCallback FCE_AI_ShowWaveCallback;

		// Token: 0x0400065E RID: 1630
		public static Binding._FCE_AI_SetEntityToSpawn FCE_AI_SetEntityToSpawn;

		// Token: 0x0400065F RID: 1631
		public static Binding._FCE_AI_SetWaveTransition FCE_AI_SetWaveTransition;

		// Token: 0x04000660 RID: 1632
		public static Binding._FCE_AI_GetWaveTransition FCE_AI_GetWaveTransition;

		// Token: 0x04000661 RID: 1633
		public static Binding._FCE_AI_SetAmbientProperties FCE_AI_SetAmbientProperties;

		// Token: 0x04000662 RID: 1634
		public static Binding._FCE_AI_GetAmbientProperties FCE_AI_GetAmbientProperties;

		// Token: 0x04000663 RID: 1635
		public static Binding._FCE_AI_SetSTPProperties FCE_AI_SetSTPProperties;

		// Token: 0x04000664 RID: 1636
		public static Binding._FCE_AI_GetSTPProperties FCE_AI_GetSTPProperties;

		// Token: 0x04000665 RID: 1637
		public static Binding._FCE_AI_SetPatrolProperties FCE_AI_SetPatrolProperties;

		// Token: 0x04000666 RID: 1638
		public static Binding._FCE_AI_GetPatrolProperties FCE_AI_GetPatrolProperties;

		// Token: 0x04000667 RID: 1639
		public static Binding._FCE_AI_SetAIGroup FCE_AI_SetAIGroup;

		// Token: 0x04000668 RID: 1640
		public static Binding._FCE_AI_IsValidObjectiveEntity FCE_AI_IsValidObjectiveEntity;

		// Token: 0x04000669 RID: 1641
		public static Binding._FCE_AI_ShowWaveOnly FCE_AI_ShowWaveOnly;

		// Token: 0x0400066A RID: 1642
		public static Binding._FCE_AI_GetStpUsage FCE_AI_GetStpUsage;

		// Token: 0x0400066B RID: 1643
		public static Binding._FCE_ObjectManager_GetObjectFromScreenPoint FCE_ObjectManager_GetObjectFromScreenPoint;

		// Token: 0x0400066C RID: 1644
		public static Binding._FCE_ObjectManager_GetObjectsFromScreenRect FCE_ObjectManager_GetObjectsFromScreenRect;

		// Token: 0x0400066D RID: 1645
		public static Binding._FCE_ObjectManager_GetObjectsFromMagicWand FCE_ObjectManager_GetObjectsFromMagicWand;

		// Token: 0x0400066E RID: 1646
		public static Binding._FCE_ObjectManager_SetViewportPickingPos FCE_ObjectManager_SetViewportPickingPos;

		// Token: 0x0400066F RID: 1647
		public static Binding._FCE_ObjectManager_UnfreezeObjects FCE_ObjectManager_UnfreezeObjects;

		// Token: 0x04000670 RID: 1648
		public static Binding._FCE_ObjectManager_GetObjectCount FCE_ObjectManager_GetObjectCount;

		// Token: 0x04000671 RID: 1649
		public static Binding._FCE_ObjectManager_GetObject FCE_ObjectManager_GetObject;

		// Token: 0x04000672 RID: 1650
		public static Binding._FCE_ObjectSelection_Create FCE_ObjectSelection_Create;

		// Token: 0x04000673 RID: 1651
		public static Binding._FCE_ObjectSelection_Destroy FCE_ObjectSelection_Destroy;

		// Token: 0x04000674 RID: 1652
		public static Binding._FCE_ObjectSelection_Clear FCE_ObjectSelection_Clear;

		// Token: 0x04000675 RID: 1653
		public static Binding._FCE_ObjectSelection_Add FCE_ObjectSelection_Add;

		// Token: 0x04000676 RID: 1654
		public static Binding._FCE_ObjectSelection_AddSelection FCE_ObjectSelection_AddSelection;

		// Token: 0x04000677 RID: 1655
		public static Binding._FCE_ObjectSelection_ToggleObject FCE_ObjectSelection_ToggleObject;

		// Token: 0x04000678 RID: 1656
		public static Binding._FCE_ObjectSelection_ToggleSelection FCE_ObjectSelection_ToggleSelection;

		// Token: 0x04000679 RID: 1657
		public static Binding._FCE_ObjectSelection_RemoveObject FCE_ObjectSelection_RemoveObject;

		// Token: 0x0400067A RID: 1658
		public static Binding._FCE_ObjectSelection_RemoveSelection FCE_ObjectSelection_RemoveSelection;

		// Token: 0x0400067B RID: 1659
		public static Binding._FCE_ObjectSelection_GetCount FCE_ObjectSelection_GetCount;

		// Token: 0x0400067C RID: 1660
		public static Binding._FCE_ObjectSelection_Get FCE_ObjectSelection_Get;

		// Token: 0x0400067D RID: 1661
		public static Binding._FCE_ObjectSelection_GetValidObjects FCE_ObjectSelection_GetValidObjects;

		// Token: 0x0400067E RID: 1662
		public static Binding._FCE_ObjectSelection_RemoveInvalidObjects FCE_ObjectSelection_RemoveInvalidObjects;

		// Token: 0x0400067F RID: 1663
		public static Binding._FCE_ObjectSelection_Clone FCE_ObjectSelection_Clone;

		// Token: 0x04000680 RID: 1664
		public static Binding._FCE_ObjectSelection_Delete FCE_ObjectSelection_Delete;

		// Token: 0x04000681 RID: 1665
		public static Binding._FCE_ObjectSelection_GetCenter FCE_ObjectSelection_GetCenter;

		// Token: 0x04000682 RID: 1666
		public static Binding._FCE_ObjectSelection_SetCenter FCE_ObjectSelection_SetCenter;

		// Token: 0x04000683 RID: 1667
		public static Binding._FCE_ObjectSelection_GetComputeCenter FCE_ObjectSelection_GetComputeCenter;

		// Token: 0x04000684 RID: 1668
		public static Binding._FCE_ObjectSelection_ComputeCenter FCE_ObjectSelection_ComputeCenter;

		// Token: 0x04000685 RID: 1669
		public static Binding._FCE_ObjectSelection_GetWorldBounds FCE_ObjectSelection_GetWorldBounds;

		// Token: 0x04000686 RID: 1670
		public static Binding._FCE_ObjectSelection_MoveTo FCE_ObjectSelection_MoveTo;

		// Token: 0x04000687 RID: 1671
		public static Binding._FCE_ObjectSelection_Rotate FCE_ObjectSelection_Rotate;

		// Token: 0x04000688 RID: 1672
		public static Binding._FCE_ObjectSelection_Rotate3 FCE_ObjectSelection_Rotate3;

		// Token: 0x04000689 RID: 1673
		public static Binding._FCE_ObjectSelection_RotateCenter FCE_ObjectSelection_RotateCenter;

		// Token: 0x0400068A RID: 1674
		public static Binding._FCE_ObjectSelection_RotateLocal3 FCE_ObjectSelection_RotateLocal3;

		// Token: 0x0400068B RID: 1675
		public static Binding._FCE_ObjectSelection_RotateGimbal FCE_ObjectSelection_RotateGimbal;

		// Token: 0x0400068C RID: 1676
		public static Binding._FCE_ObjectSelection_DropToGround FCE_ObjectSelection_DropToGround;

		// Token: 0x0400068D RID: 1677
		public static Binding._FCE_ObjectSelection_SnapToPivot FCE_ObjectSelection_SnapToPivot;

		// Token: 0x0400068E RID: 1678
		public static Binding._FCE_ObjectSelection_SnapToClosestObjects FCE_ObjectSelection_SnapToClosestObjects;

		// Token: 0x0400068F RID: 1679
		public static Binding._FCE_ObjectSelection_GetPhysEntities FCE_ObjectSelection_GetPhysEntities;

		// Token: 0x04000690 RID: 1680
		public static Binding._FCE_ObjectSelection_ClearState FCE_ObjectSelection_ClearState;

		// Token: 0x04000691 RID: 1681
		public static Binding._FCE_ObjectSelection_LoadState FCE_ObjectSelection_LoadState;

		// Token: 0x04000692 RID: 1682
		public static Binding._FCE_ObjectSelection_SaveState FCE_ObjectSelection_SaveState;

		// Token: 0x04000693 RID: 1683
		public static Binding._FCE_ObjectSelection_LoadFromXml FCE_ObjectSelection_LoadFromXml;

		// Token: 0x04000694 RID: 1684
		public static Binding._FCE_ObjectSelection_SaveToXml FCE_ObjectSelection_SaveToXml;

		// Token: 0x04000695 RID: 1685
		public static Binding._FCE_ObjectSelection_IsAxesXYLocked FCE_ObjectSelection_IsAxesXYLocked;

		// Token: 0x04000696 RID: 1686
		public static Binding._FCE_ObjectViewer_SetActive FCE_ObjectViewer_SetActive;

		// Token: 0x04000697 RID: 1687
		public static Binding._FCE_ObjectViewer_SetObject FCE_ObjectViewer_SetObject;

		// Token: 0x04000698 RID: 1688
		public static Binding._FCE_ObjectLegoBox_SetActive FCE_ObjectLegoBox_SetActive;

		// Token: 0x04000699 RID: 1689
		public static Binding._FCE_ObjectLegoBox_AddEntry FCE_ObjectLegoBox_AddEntry;

		// Token: 0x0400069A RID: 1690
		public static Binding._FCE_ObjectLegoBox_ClearEntries FCE_ObjectLegoBox_ClearEntries;

		// Token: 0x0400069B RID: 1691
		public static Binding._FCE_ObjectLegoBox_CreateLegoBox FCE_ObjectLegoBox_CreateLegoBox;

		// Token: 0x0400069C RID: 1692
		public static Binding._FCE_ObjectLegoBox_GetEntryFromScreenPoint FCE_ObjectLegoBox_GetEntryFromScreenPoint;

		// Token: 0x0400069D RID: 1693
		public static Binding._FCE_ObjectRenderer_Clear FCE_ObjectRenderer_Clear;

		// Token: 0x0400069E RID: 1694
		public static Binding._FCE_ObjectRenderer_SetActive FCE_ObjectRenderer_SetActive;

		// Token: 0x0400069F RID: 1695
		public static Binding._FCE_ObjectRenderer_RenderObject FCE_ObjectRenderer_RenderObject;

		// Token: 0x040006A0 RID: 1696
		public static Binding._FCE_ObjectRenderer_IsSnapshotReady FCE_ObjectRenderer_IsSnapshotReady;

		// Token: 0x040006A1 RID: 1697
		public static Binding._FCE_ObjectRenderer_GetSnapshot FCE_ObjectRenderer_GetSnapshot;

		// Token: 0x040006A2 RID: 1698
		public static Binding._FCE_ObjectRenderer_GetSnapshotEntry FCE_ObjectRenderer_GetSnapshotEntry;

		// Token: 0x040006A3 RID: 1699
		public static Binding._FCE_ObjectRenderer_ClearSnapshot FCE_ObjectRenderer_ClearSnapshot;

		// Token: 0x040006A4 RID: 1700
		public static Binding._FCE_ObjectRenderer_WritePNG FCE_ObjectRenderer_WritePNG;

		// Token: 0x040006A5 RID: 1701
		public static Binding._FCE_ObjectRenderer_GenerateThumbnails FCE_ObjectRenderer_GenerateThumbnails;

		// Token: 0x040006A6 RID: 1702
		public static Binding._FCE_CollectionRenderer_GenerateThumbnails FCE_CollectionRenderer_GenerateThumbnails;

		// Token: 0x040006A7 RID: 1703
		public static Binding._FCE_WaterRenderer_GenerateThumbnails FCE_WaterRenderer_GenerateThumbnails;

		// Token: 0x040006A8 RID: 1704
		public static Binding._FCE_Gizmo_Create FCE_Gizmo_Create;

		// Token: 0x040006A9 RID: 1705
		public static Binding._FCE_Gizmo_Destroy FCE_Gizmo_Destroy;

		// Token: 0x040006AA RID: 1706
		public static Binding._FCE_Gizmo_GetPos FCE_Gizmo_GetPos;

		// Token: 0x040006AB RID: 1707
		public static Binding._FCE_Gizmo_SetPos FCE_Gizmo_SetPos;

		// Token: 0x040006AC RID: 1708
		public static Binding._FCE_Gizmo_GetAxis FCE_Gizmo_GetAxis;

		// Token: 0x040006AD RID: 1709
		public static Binding._FCE_Gizmo_SetAxis FCE_Gizmo_SetAxis;

		// Token: 0x040006AE RID: 1710
		public static Binding._FCE_Gizmo_GetActive FCE_Gizmo_GetActive;

		// Token: 0x040006AF RID: 1711
		public static Binding._FCE_Gizmo_SetActive FCE_Gizmo_SetActive;

		// Token: 0x040006B0 RID: 1712
		public static Binding._FCE_Gizmo_Redraw FCE_Gizmo_Redraw;

		// Token: 0x040006B1 RID: 1713
		public static Binding._FCE_Gizmo_Hide FCE_Gizmo_Hide;

		// Token: 0x040006B2 RID: 1714
		public static Binding._FCE_Gizmo_IsRotationMode FCE_Gizmo_IsRotationMode;

		// Token: 0x040006B3 RID: 1715
		public static Binding._FCE_Gizmo_SetRotationMode FCE_Gizmo_SetRotationMode;

		// Token: 0x040006B4 RID: 1716
		public static Binding._FCE_Gizmo_ResetAxes FCE_Gizmo_ResetAxes;

		// Token: 0x040006B5 RID: 1717
		public static Binding._FCE_Gizmo_EnableAxis FCE_Gizmo_EnableAxis;

		// Token: 0x040006B6 RID: 1718
		public static Binding._FCE_Gizmo_HitTest FCE_Gizmo_HitTest;

		// Token: 0x040006B7 RID: 1719
		public static Binding._FCE_CollectionManager_GetCollectionEntryFromId FCE_CollectionManager_GetCollectionEntryFromId;

		// Token: 0x040006B8 RID: 1720
		public static Binding._FCE_CollectionManager_AssignCollectionId FCE_CollectionManager_AssignCollectionId;

		// Token: 0x040006B9 RID: 1721
		public static Binding._FCE_CollectionManager_WriteMaskCircle FCE_CollectionManager_WriteMaskCircle;

		// Token: 0x040006BA RID: 1722
		public static Binding._FCE_CollectionManager_WriteMaskSquare FCE_CollectionManager_WriteMaskSquare;

		// Token: 0x040006BB RID: 1723
		public static Binding._FCE_CollectionManager_ClearMaskId FCE_CollectionManager_ClearMaskId;

		// Token: 0x040006BC RID: 1724
		public static Binding._FCE_CollectionManager_UpdateCollections FCE_CollectionManager_UpdateCollections;

		// Token: 0x040006BD RID: 1725
		public static Binding._FCE_CollectionManager_ActivatePhysics FCE_CollectionManager_ActivatePhysics;

		// Token: 0x040006BE RID: 1726
		public static Binding._FCE_Collection_Paint FCE_Collection_Paint;

		// Token: 0x040006BF RID: 1727
		public static Binding._FCE_Collection_Paint_End FCE_Collection_Paint_End;

		// Token: 0x040006C0 RID: 1728
		public static Binding._FCE_Texture_Paint FCE_Texture_Paint;

		// Token: 0x040006C1 RID: 1729
		public static Binding._FCE_Texture_Paint_End FCE_Texture_Paint_End;

		// Token: 0x040006C2 RID: 1730
		public static Binding._FCE_Texture_PaintConstraints_Begin FCE_Texture_PaintConstraints_Begin;

		// Token: 0x040006C3 RID: 1731
		public static Binding._FCE_Texture_PaintConstraints FCE_Texture_PaintConstraints;

		// Token: 0x040006C4 RID: 1732
		public static Binding._FCE_Texture_PaintConstraints_End FCE_Texture_PaintConstraints_End;

		// Token: 0x040006C5 RID: 1733
		public static Binding._FCE_TerrainManager_GetHeightAt FCE_TerrainManager_GetHeightAt;

		// Token: 0x040006C6 RID: 1734
		public static Binding._FCE_TerrainManager_GetHeightAtWithWater FCE_TerrainManager_GetHeightAtWithWater;

		// Token: 0x040006C7 RID: 1735
		public static Binding._FCE_TerrainManager_GetTextureEntryFromId FCE_TerrainManager_GetTextureEntryFromId;

		// Token: 0x040006C8 RID: 1736
		public static Binding._FCE_TerrainManager_AssignTextureId FCE_TerrainManager_AssignTextureId;

		// Token: 0x040006C9 RID: 1737
		public static Binding._FCE_TerrainManager_ClearTextureId FCE_TerrainManager_ClearTextureId;

		// Token: 0x040006CA RID: 1738
		public static Binding._FCE_TerrainManager_GetGlobalWaterLevel FCE_TerrainManager_GetGlobalWaterLevel;

		// Token: 0x040006CB RID: 1739
		public static Binding._FCE_TerrainManager_SetGlobalWaterLevel FCE_TerrainManager_SetGlobalWaterLevel;

		// Token: 0x040006CC RID: 1740
		public static Binding._FCE_TerrainManager_SetWaterLevelSector FCE_TerrainManager_SetWaterLevelSector;

		// Token: 0x040006CD RID: 1741
		public static Binding._FCE_TerrainManager_UpdateWaterLevel FCE_TerrainManager_UpdateWaterLevel;

		// Token: 0x040006CE RID: 1742
		public static Binding._FCE_TerrainManager_GetLogicZoneId FCE_TerrainManager_GetLogicZoneId;

		// Token: 0x040006CF RID: 1743
		public static Binding._FCE_TerrainManager_SetLogicZoneId FCE_TerrainManager_SetLogicZoneId;

		// Token: 0x040006D0 RID: 1744
		public static Binding._FCE_TerrainManager_GetSoundRegionId FCE_TerrainManager_GetSoundRegionId;

		// Token: 0x040006D1 RID: 1745
		public static Binding._FCE_TerrainManager_SetSoundRegionId FCE_TerrainManager_SetSoundRegionId;

		// Token: 0x040006D2 RID: 1746
		public static Binding._FCE_UndoManager_GetUndoCount FCE_UndoManager_GetUndoCount;

		// Token: 0x040006D3 RID: 1747
		public static Binding._FCE_UndoManager_GetRedoCount FCE_UndoManager_GetRedoCount;

		// Token: 0x040006D4 RID: 1748
		public static Binding._FCE_UndoManager_Undo FCE_UndoManager_Undo;

		// Token: 0x040006D5 RID: 1749
		public static Binding._FCE_UndoManager_Redo FCE_UndoManager_Redo;

		// Token: 0x040006D6 RID: 1750
		public static Binding._FCE_UndoManager_RecordUndo FCE_UndoManager_RecordUndo;

		// Token: 0x040006D7 RID: 1751
		public static Binding._FCE_UndoManager_CommitUndo FCE_UndoManager_CommitUndo;

		// Token: 0x040006D8 RID: 1752
		public static Binding._FCE_Validation_Objective FCE_Validation_Objective;

		// Token: 0x040006D9 RID: 1753
		public static Binding._FCE_Validation_Game FCE_Validation_Game;

		// Token: 0x040006DA RID: 1754
		public static Binding._FCE_ValidationReport_Destroy FCE_ValidationReport_Destroy;

		// Token: 0x040006DB RID: 1755
		public static Binding._FCE_ValidationReport_GetCount FCE_ValidationReport_GetCount;

		// Token: 0x040006DC RID: 1756
		public static Binding._FCE_ValidationReport_GetRecord FCE_ValidationReport_GetRecord;

		// Token: 0x040006DD RID: 1757
		public static Binding._FCE_ValidationRecord_GetSeverity FCE_ValidationRecord_GetSeverity;

		// Token: 0x040006DE RID: 1758
		public static Binding._FCE_ValidationRecord_GetFlags FCE_ValidationRecord_GetFlags;

		// Token: 0x040006DF RID: 1759
		public static Binding._FCE_ValidationRecord_GetErrorCode FCE_ValidationRecord_GetErrorCode;

		// Token: 0x040006E0 RID: 1760
		public static Binding._FCE_ValidationRecord_GetMessage FCE_ValidationRecord_GetMessage;

		// Token: 0x040006E1 RID: 1761
		public static Binding._FCE_ValidationRecord_GetObject FCE_ValidationRecord_GetObject;

		// Token: 0x040006E2 RID: 1762
		public static Binding._FCE_Snapshot_Create FCE_Snapshot_Create;

		// Token: 0x040006E3 RID: 1763
		public static Binding._FCE_Snapshot_Destroy FCE_Snapshot_Destroy;

		// Token: 0x040006E4 RID: 1764
		public static Binding._FCE_Snapshot_GetData FCE_Snapshot_GetData;

		// Token: 0x040006E5 RID: 1765
		public static Binding._FCE_Spline_Create FCE_Spline_Create;

		// Token: 0x040006E6 RID: 1766
		public static Binding._FCE_Spline_Destroy FCE_Spline_Destroy;

		// Token: 0x040006E7 RID: 1767
		public static Binding._FCE_Spline_Clear FCE_Spline_Clear;

		// Token: 0x040006E8 RID: 1768
		public static Binding._FCE_Spline_AddPoint FCE_Spline_AddPoint;

		// Token: 0x040006E9 RID: 1769
		public static Binding._FCE_Spline_InsertPoint FCE_Spline_InsertPoint;

		// Token: 0x040006EA RID: 1770
		public static Binding._FCE_Spline_RemovePoint FCE_Spline_RemovePoint;

		// Token: 0x040006EB RID: 1771
		public static Binding._FCE_Spline_RemoveSimilarPoints FCE_Spline_RemoveSimilarPoints;

		// Token: 0x040006EC RID: 1772
		public static Binding._FCE_Spline_OptimizePoint FCE_Spline_OptimizePoint;

		// Token: 0x040006ED RID: 1773
		public static Binding._FCE_Spline_GetNumPoints FCE_Spline_GetNumPoints;

		// Token: 0x040006EE RID: 1774
		public static Binding._FCE_Spline_GetPoint FCE_Spline_GetPoint;

		// Token: 0x040006EF RID: 1775
		public static Binding._FCE_Spline_SetPoint FCE_Spline_SetPoint;

		// Token: 0x040006F0 RID: 1776
		public static Binding._FCE_Spline_UpdateSpline FCE_Spline_UpdateSpline;

		// Token: 0x040006F1 RID: 1777
		public static Binding._FCE_Spline_UpdateSplineHeight FCE_Spline_UpdateSplineHeight;

		// Token: 0x040006F2 RID: 1778
		public static Binding._FCE_Spline_FinalizeSpline FCE_Spline_FinalizeSpline;

		// Token: 0x040006F3 RID: 1779
		public static Binding._FCE_Spline_Draw FCE_Spline_Draw;

		// Token: 0x040006F4 RID: 1780
		public static Binding._FCE_Spline_HitTestPoints FCE_Spline_HitTestPoints;

		// Token: 0x040006F5 RID: 1781
		public static Binding._FCE_Spline_HitTestSegments FCE_Spline_HitTestSegments;

		// Token: 0x040006F6 RID: 1782
		public static Binding._FCE_SplineRoad_GetEntry FCE_SplineRoad_GetEntry;

		// Token: 0x040006F7 RID: 1783
		public static Binding._FCE_SplineRoad_SetEntry FCE_SplineRoad_SetEntry;

		// Token: 0x040006F8 RID: 1784
		public static Binding._FCE_SplineRoad_GetWidth FCE_SplineRoad_GetWidth;

		// Token: 0x040006F9 RID: 1785
		public static Binding._FCE_SplineRoad_SetWidth FCE_SplineRoad_SetWidth;

		// Token: 0x040006FA RID: 1786
		public static Binding._FCE_SplineZone_Reset FCE_SplineZone_Reset;

		// Token: 0x040006FB RID: 1787
		public static Binding._FCE_SplineController_Create FCE_SplineController_Create;

		// Token: 0x040006FC RID: 1788
		public static Binding._FCE_SplineController_Destroy FCE_SplineController_Destroy;

		// Token: 0x040006FD RID: 1789
		public static Binding._FCE_SplineController_SetSpline FCE_SplineController_SetSpline;

		// Token: 0x040006FE RID: 1790
		public static Binding._FCE_SplineController_ClearSelection FCE_SplineController_ClearSelection;

		// Token: 0x040006FF RID: 1791
		public static Binding._FCE_SplineController_IsSelected FCE_SplineController_IsSelected;

		// Token: 0x04000700 RID: 1792
		public static Binding._FCE_SplineController_SetSelected FCE_SplineController_SetSelected;

		// Token: 0x04000701 RID: 1793
		public static Binding._FCE_SplineController_SelectFromScreenRect FCE_SplineController_SelectFromScreenRect;

		// Token: 0x04000702 RID: 1794
		public static Binding._FCE_SplineController_MoveSelection FCE_SplineController_MoveSelection;

		// Token: 0x04000703 RID: 1795
		public static Binding._FCE_SplineController_DeleteSelection FCE_SplineController_DeleteSelection;

		// Token: 0x04000704 RID: 1796
		public static Binding._FCE_SplineManager_CreateRoad FCE_SplineManager_CreateRoad;

		// Token: 0x04000705 RID: 1797
		public static Binding._FCE_SplineManager_DestroyRoad FCE_SplineManager_DestroyRoad;

		// Token: 0x04000706 RID: 1798
		public static Binding._FCE_SplineManager_GetRoadFromId FCE_SplineManager_GetRoadFromId;

		// Token: 0x04000707 RID: 1799
		public static Binding._FCE_SplineManager_GetPlayableZone FCE_SplineManager_GetPlayableZone;

		// Token: 0x04000708 RID: 1800
		public static Binding._FCE_PhysEntityVector_Create FCE_PhysEntityVector_Create;

		// Token: 0x04000709 RID: 1801
		public static Binding._FCE_PhysEntityVector_Destroy FCE_PhysEntityVector_Destroy;

		// Token: 0x0400070A RID: 1802
		public static Binding._FCE_Wilderness_Desert FCE_Wilderness_Desert;

		// Token: 0x0400070B RID: 1803
		public static Binding._FCE_Wilderness_Script FCE_Wilderness_Script;

		// Token: 0x0400070C RID: 1804
		public static Binding._FCE_Wilderness_ScriptBuffer FCE_Wilderness_ScriptBuffer;

		// Token: 0x0400070D RID: 1805
		public static Binding._FCE_Script_GetNumFunctions FCE_Script_GetNumFunctions;

		// Token: 0x0400070E RID: 1806
		public static Binding._FCE_Script_GetFunction FCE_Script_GetFunction;

		// Token: 0x0400070F RID: 1807
		public static Binding._FCE_ScriptFunction_GetName FCE_ScriptFunction_GetName;

		// Token: 0x04000710 RID: 1808
		public static Binding._FCE_ScriptFunction_GetPrototype FCE_ScriptFunction_GetPrototype;

		// Token: 0x04000711 RID: 1809
		public static Binding._FCE_ScriptFunction_GetDescription FCE_ScriptFunction_GetDescription;

		// Token: 0x04000712 RID: 1810
		public static Binding._FCE_ImageMap_GetSize FCE_ImageMap_GetSize;

		// Token: 0x04000713 RID: 1811
		public static Binding._FCE_ImageMap_ConvertTo24bit FCE_ImageMap_ConvertTo24bit;

		// Token: 0x04000714 RID: 1812
		public static Binding._FCE_ImageMap_Clone FCE_ImageMap_Clone;

		// Token: 0x04000715 RID: 1813
		public static Binding._FCE_ImageMap_Destroy FCE_ImageMap_Destroy;

		// Token: 0x04000716 RID: 1814
		public static Binding._FCE_BudgetManager_GetMemoryUsage FCE_BudgetManager_GetMemoryUsage;

		// Token: 0x04000717 RID: 1815
		public static Binding._FCE_BudgetManager_GetMaxMemoryUsageMB FCE_BudgetManager_GetMaxMemoryUsageMB;

		// Token: 0x04000718 RID: 1816
		public static Binding._FCE_BudgetManager_GetObjectUsage FCE_BudgetManager_GetObjectUsage;

		// Token: 0x04000719 RID: 1817
		public static Binding._FCE_BudgetManager_GetMaxObjectUsage FCE_BudgetManager_GetMaxObjectUsage;

		// Token: 0x0400071A RID: 1818
		public static Binding._FCE_BudgetManager_GetWaveUsage FCE_BudgetManager_GetWaveUsage;

		// Token: 0x0400071B RID: 1819
		public static Binding._FCE_BudgetManager_GetMaxWaveUsage FCE_BudgetManager_GetMaxWaveUsage;

		// Token: 0x0400071C RID: 1820
		public static Binding._FCE_BudgetManager_GetVehicles FCE_BudgetManager_GetVehicles;

		// Token: 0x0400071D RID: 1821
		public static Binding._FCE_BudgetManager_GetMaxVehicles FCE_BudgetManager_GetMaxVehicles;

		// Token: 0x0400071E RID: 1822
		public static Binding._FCE_BudgetManager_GetAmbientAI FCE_BudgetManager_GetAmbientAI;

		// Token: 0x0400071F RID: 1823
		public static Binding._FCE_BudgetManager_GetEnemyAI FCE_BudgetManager_GetEnemyAI;

		// Token: 0x04000720 RID: 1824
		public static Binding._FCE_BudgetManager_ValidateObjectsGlobalCost FCE_BudgetManager_ValidateObjectsGlobalCost;

		// Token: 0x04000721 RID: 1825
		public static Binding._FCE_BudgetManager_ValidateObjectsSectorCost FCE_BudgetManager_ValidateObjectsSectorCost;

		// Token: 0x04000722 RID: 1826
		public static Binding._FCE_BudgetManager_ValidateAIObjectsUsage FCE_BudgetManager_ValidateAIObjectsUsage;

		// Token: 0x04000723 RID: 1827
		public static Binding._FCE_BudgetManager_ValidatePhysicsObjectsUsage FCE_BudgetManager_ValidatePhysicsObjectsUsage;

		// Token: 0x04000724 RID: 1828
		public static Binding._FCE_BudgetManager_ValidateLightObjectsUsage FCE_BudgetManager_ValidateLightObjectsUsage;

		// Token: 0x04000725 RID: 1829
		public static Binding._FCE_BudgetManager_ValidateAnimPointsObjectsUsage FCE_BudgetManager_ValidateAnimPointsObjectsUsage;

		// Token: 0x04000726 RID: 1830
		public static Binding._FCE_BudgetManager_ValidateSpawnPointsObjectsUsage FCE_BudgetManager_ValidateSpawnPointsObjectsUsage;

		// Token: 0x04000727 RID: 1831
		public static Binding._FCE_BudgetManager_GetObjectSectorId FCE_BudgetManager_GetObjectSectorId;

		// Token: 0x04000728 RID: 1832
		public static Binding._FCE_GameModeManager_ClearObjectiveSettings FCE_GameModeManager_ClearObjectiveSettings;

		// Token: 0x04000729 RID: 1833
		public static Binding._FCE_GameModeManager_AddObjectiveSetting FCE_GameModeManager_AddObjectiveSetting;

		// Token: 0x0400072A RID: 1834
		public static Binding._FCE_GameModeManager_GetObjectiveSettingBool FCE_GameModeManager_GetObjectiveSettingBool;

		// Token: 0x0400072B RID: 1835
		public static Binding._FCE_GameModeManager_GetObjectiveSettingNumeric FCE_GameModeManager_GetObjectiveSettingNumeric;

		// Token: 0x0400072C RID: 1836
		public static Binding._FCE_GameModeManager_GetObjectiveSettingPresetDbId FCE_GameModeManager_GetObjectiveSettingPresetDbId;

		// Token: 0x0400072D RID: 1837
		public static Binding._FCE_Navmesh_SetDisplay FCE_Navmesh_SetDisplay;

		// Token: 0x0400072E RID: 1838
		public static Binding._FCE_Navmesh_RegenerateTileAt FCE_Navmesh_RegenerateTileAt;

		// Token: 0x0400072F RID: 1839
		public static Binding._FCE_Navmesh_SetAPDisplay FCE_Navmesh_SetAPDisplay;

		// Token: 0x04000730 RID: 1840
		public static Binding._FCE_Navmesh_GetDebugAlpha FCE_Navmesh_GetDebugAlpha;

		// Token: 0x04000731 RID: 1841
		public static Binding._FCE_Navmesh_SetDebugAlpha FCE_Navmesh_SetDebugAlpha;

		// Token: 0x04000732 RID: 1842
		public static Binding._FCE_Navmesh_GetPendingTilesCount FCE_Navmesh_GetPendingTilesCount;

		// Token: 0x04000733 RID: 1843
		public static Binding._FCE_Navmesh_IsReady FCE_Navmesh_IsReady;

		// Token: 0x04000734 RID: 1844
		public static Binding._FCE_Navmesh_Sync FCE_Navmesh_Sync;

		// Token: 0x04000735 RID: 1845
		public static Binding._FCE_Navmesh_Validate FCE_Navmesh_Validate;

		// Token: 0x04000736 RID: 1846
		public static Binding._FCE_Editor_Publish_Map FCE_Editor_Publish_Map;

		// Token: 0x04000737 RID: 1847
		public static Binding._FCE_Editor_PublishComlete_Callback FCE_Editor_PublishComlete_Callback;

		// Token: 0x04000738 RID: 1848
		public static Binding._FCE_Editor_Login FCE_Editor_Login;

		// Token: 0x04000739 RID: 1849
		public static Binding._FCE_Editor_LoginComlete_Callback FCE_Editor_LoginComlete_Callback;

		// Token: 0x0400073A RID: 1850
		public static Binding._FCE_Editor_CreateIssue FCE_Editor_CreateIssue;

		// Token: 0x0400073B RID: 1851
		public static Binding._IsNvidia IsNvidia;

		// Token: 0x0400073C RID: 1852
		public static Binding._GetIGESteamCommandLine GetIGESteamCommandLine;

		// Token: 0x0400073D RID: 1853
		private static IntPtr _gameDllModule;

		// Token: 0x0200012F RID: 303
		// (Invoke) Token: 0x06000A8A RID: 2698
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _InitDuniaEngine(IntPtr hInstance, IntPtr focusWnd, IntPtr renderWnd, [MarshalAs(UnmanagedType.LPStr)] string cmdLine, [MarshalAs(UnmanagedType.U1)] bool launchGame, [MarshalAs(UnmanagedType.U1)] bool forceGpuSynchronization, Binding.MessagePumpCallback messagePumpCallback);

		// Token: 0x02000130 RID: 304
		// (Invoke) Token: 0x06000A8E RID: 2702
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _TickDuniaEngine();

		// Token: 0x02000131 RID: 305
		// (Invoke) Token: 0x06000A92 RID: 2706
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _RunDuniaEngine();

		// Token: 0x02000132 RID: 306
		// (Invoke) Token: 0x06000A96 RID: 2710
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _CloseDuniaEngine();

		// Token: 0x02000133 RID: 307
		// (Invoke) Token: 0x06000A9A RID: 2714
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _LoadIGEDll();

		// Token: 0x02000134 RID: 308
		// (Invoke) Token: 0x06000A9E RID: 2718
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _UnloadIGEDll();

		// Token: 0x02000135 RID: 309
		// (Invoke) Token: 0x06000AA2 RID: 2722
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _LocalizeText([MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string text);

		// Token: 0x02000136 RID: 310
		// (Invoke) Token: 0x06000AA6 RID: 2726
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _LocalizeTextFromLineId(uint lineId);

		// Token: 0x02000137 RID: 311
		// (Invoke) Token: 0x06000AAA RID: 2730
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _PC_RegisterDeviceNotification(IntPtr hWnd);

		// Token: 0x02000138 RID: 312
		// (Invoke) Token: 0x06000AAE RID: 2734
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _PC_DeviceChange([MarshalAs(UnmanagedType.U8)] long wParam, [MarshalAs(UnmanagedType.U8)] long lParam);

		// Token: 0x02000139 RID: 313
		// (Invoke) Token: 0x06000AB2 RID: 2738
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MessagePumpCallback([MarshalAs(UnmanagedType.U1)] bool deferQuit, [MarshalAs(UnmanagedType.U1)] bool blockRenderer);

		// Token: 0x0200013A RID: 314
		// (Invoke) Token: 0x06000AB6 RID: 2742
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EditorUpdateCallback(float dt);

		// Token: 0x0200013B RID: 315
		// (Invoke) Token: 0x06000ABA RID: 2746
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EditorEventCallback(uint eventType, IntPtr eventPtr);

		// Token: 0x0200013C RID: 316
		// (Invoke) Token: 0x06000ABE RID: 2750
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EditorLoadCompletedCallback([MarshalAs(UnmanagedType.U1)] bool success);

		// Token: 0x0200013D RID: 317
		// (Invoke) Token: 0x06000AC2 RID: 2754
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EditorSaveCompletedCallback([MarshalAs(UnmanagedType.U1)] bool success);

		// Token: 0x0200013E RID: 318
		// (Invoke) Token: 0x06000AC6 RID: 2758
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EditorEnableUICallback([MarshalAs(UnmanagedType.U1)] bool enable);

		// Token: 0x0200013F RID: 319
		// (Invoke) Token: 0x06000ACA RID: 2762
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EditorSettingsShowBudgetGridCallback([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x02000140 RID: 320
		// (Invoke) Token: 0x06000ACE RID: 2766
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ShowWaveCallback(int waveId);

		// Token: 0x02000141 RID: 321
		// (Invoke) Token: 0x06000AD2 RID: 2770
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ScriptMapCallback(int line, IntPtr image);

		// Token: 0x02000142 RID: 322
		// (Invoke) Token: 0x06000AD6 RID: 2774
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ScriptErrorCallback(int line, [MarshalAs(UnmanagedType.LPStr)] string errorMessage);

		// Token: 0x02000143 RID: 323
		// (Invoke) Token: 0x06000ADA RID: 2778
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EditorPublishCompleteCallback([MarshalAs(UnmanagedType.U1)] bool success);

		// Token: 0x02000144 RID: 324
		// (Invoke) Token: 0x06000ADE RID: 2782
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void EditorLoginCompleteCallback([MarshalAs(UnmanagedType.U1)] bool success);

		// Token: 0x02000145 RID: 325
		// (Invoke) Token: 0x06000AE2 RID: 2786
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Hack_Init(IntPtr hEditorModule);

		// Token: 0x02000146 RID: 326
		// (Invoke) Token: 0x06000AE6 RID: 2790
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_GetProgress();

		// Token: 0x02000147 RID: 327
		// (Invoke) Token: 0x06000AEA RID: 2794
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Engine_Reset(IntPtr hMainWnd, IntPtr hViewportWnd, Binding.MessagePumpCallback messagePumpCB);

		// Token: 0x02000148 RID: 328
		// (Invoke) Token: 0x06000AEE RID: 2798
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Engine_GetPersonalPath();

		// Token: 0x02000149 RID: 329
		// (Invoke) Token: 0x06000AF2 RID: 2802
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Engine_GetGenericDataPath();

		// Token: 0x0200014A RID: 330
		// (Invoke) Token: 0x06000AF6 RID: 2806
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Engine_UpdateViewport(int sizeX, int sizeY);

		// Token: 0x0200014B RID: 331
		// (Invoke) Token: 0x06000AFA RID: 2810
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Engine_AutoAcquireInput([MarshalAs(UnmanagedType.U1)] bool autoAcquire);

		// Token: 0x0200014C RID: 332
		// (Invoke) Token: 0x06000AFE RID: 2814
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Engine_IsConsoleOpen();

		// Token: 0x0200014D RID: 333
		// (Invoke) Token: 0x06000B02 RID: 2818
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Engine_GetTimeOfDay(out int hour, out int minute, out int second);

		// Token: 0x0200014E RID: 334
		// (Invoke) Token: 0x06000B06 RID: 2822
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Engine_SetTimeOfDay(int hour, int minute, int second);

		// Token: 0x0200014F RID: 335
		// (Invoke) Token: 0x06000B0A RID: 2826
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Engine_GetCloudTypeCount();

		// Token: 0x02000150 RID: 336
		// (Invoke) Token: 0x06000B0E RID: 2830
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Engine_GetCloudType();

		// Token: 0x02000151 RID: 337
		// (Invoke) Token: 0x06000B12 RID: 2834
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Engine_SetCloudType(int cloudType);

		// Token: 0x02000152 RID: 338
		// (Invoke) Token: 0x06000B16 RID: 2838
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Engine_IsSnowEnabled();

		// Token: 0x02000153 RID: 339
		// (Invoke) Token: 0x06000B1A RID: 2842
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Engine_SetSnowEnabled([MarshalAs(UnmanagedType.U1)] bool snowEnabled);

		// Token: 0x02000154 RID: 340
		// (Invoke) Token: 0x06000B1E RID: 2846
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Engine_IsBackdropEnabled();

		// Token: 0x02000155 RID: 341
		// (Invoke) Token: 0x06000B22 RID: 2850
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Engine_SetBackdropEnabled([MarshalAs(UnmanagedType.U1)] bool backdropEnabled);

		// Token: 0x02000156 RID: 342
		// (Invoke) Token: 0x06000B26 RID: 2854
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Engine_SetSelectedObject(IntPtr _object);

		// Token: 0x02000157 RID: 343
		// (Invoke) Token: 0x06000B2A RID: 2858
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Core_GetAxisFromAngles(float angleX, float angleY, float angleZ, out float x1, out float y1, out float z1, out float x2, out float y2, out float z2, out float x3, out float y3, out float z3);

		// Token: 0x02000158 RID: 344
		// (Invoke) Token: 0x06000B2E RID: 2862
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Core_GetAnglesFromAxis(out float angleX, out float angleY, out float angleZ, float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3);

		// Token: 0x02000159 RID: 345
		// (Invoke) Token: 0x06000B32 RID: 2866
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Core_GetAnglesFromDir(out float angleX, out float angleY, out float angleZ, float x, float y, float z);

		// Token: 0x0200015A RID: 346
		// (Invoke) Token: 0x06000B36 RID: 2870
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Core_Points_Create();

		// Token: 0x0200015B RID: 347
		// (Invoke) Token: 0x06000B3A RID: 2874
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Core_Points_Destroy(IntPtr points);

		// Token: 0x0200015C RID: 348
		// (Invoke) Token: 0x06000B3E RID: 2878
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_Create([MarshalAs(UnmanagedType.U1)] bool pcMode);

		// Token: 0x0200015D RID: 349
		// (Invoke) Token: 0x06000B42 RID: 2882
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_Destroy();

		// Token: 0x0200015E RID: 350
		// (Invoke) Token: 0x06000B46 RID: 2886
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Editor_IsInitialized();

		// Token: 0x0200015F RID: 351
		// (Invoke) Token: 0x06000B4A RID: 2890
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_Update_Callback(Binding.EditorUpdateCallback callback);

		// Token: 0x02000160 RID: 352
		// (Invoke) Token: 0x06000B4E RID: 2894
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_Event_Callback(Binding.EditorEventCallback callback);

		// Token: 0x02000161 RID: 353
		// (Invoke) Token: 0x06000B52 RID: 2898
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_LoadCompleted_Callback(Binding.EditorLoadCompletedCallback callback);

		// Token: 0x02000162 RID: 354
		// (Invoke) Token: 0x06000B56 RID: 2902
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_SaveCompleted_Callback(Binding.EditorSaveCompletedCallback callback);

		// Token: 0x02000163 RID: 355
		// (Invoke) Token: 0x06000B5A RID: 2906
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_EnableUI_Callback(Binding.EditorEnableUICallback callback);

		// Token: 0x02000164 RID: 356
		// (Invoke) Token: 0x06000B5E RID: 2910
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Editor_IsLoadPending();

		// Token: 0x02000165 RID: 357
		// (Invoke) Token: 0x06000B62 RID: 2914
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_Editor_GetFrameTime();

		// Token: 0x02000166 RID: 358
		// (Invoke) Token: 0x06000B66 RID: 2918
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Editor_GetScreenPointFromWorldPos(float worldX, float worldY, float worldZ, out float screenX, out float screenY);

		// Token: 0x02000167 RID: 359
		// (Invoke) Token: 0x06000B6A RID: 2922
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_GetWorldRayFromScreenPoint(float screenX, float screenY, out float raySrcX, out float raySrcY, out float raySrcZ, out float rayDirX, out float rayDirY, out float rayDirZ);

		// Token: 0x02000168 RID: 360
		// (Invoke) Token: 0x06000B6E RID: 2926
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Editor_RayCastTerrain(float raySrcX, float raySrcY, float raySrcZ, float rayDirX, float rayDirY, float rayDirZ, out float hitX, out float hitY, out float hitZ, out float hitDist);

		// Token: 0x02000169 RID: 361
		// (Invoke) Token: 0x06000B72 RID: 2930
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Editor_RayCastPhysics(float raySrcX, float raySrcY, float raySrcZ, float rayDirX, float rayDirY, float rayDirZ, IntPtr ignore, out float hitX, out float hitY, out float hitZ, out float hitDist, out float hitNormX, out float hitNormY, out float hitNormZ);

		// Token: 0x0200016A RID: 362
		// (Invoke) Token: 0x06000B76 RID: 2934
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Editor_RayCastPhysics2(float raySrcX, float raySrcY, float raySrcZ, float rayDirX, float rayDirY, float rayDirZ, IntPtr ignore, out float hitX, out float hitY, out float hitZ, out float hitDist, out float hitNormX, out float hitNormY, out float hitNormZ);

		// Token: 0x0200016B RID: 363
		// (Invoke) Token: 0x06000B7A RID: 2938
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Editor_ValidateSpawnPoints();

		// Token: 0x0200016C RID: 364
		// (Invoke) Token: 0x06000B7E RID: 2942
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Editor_ValidateObjective([MarshalAs(UnmanagedType.U1)] bool checkStandaloneConditions, [MarshalAs(UnmanagedType.U1)] bool checkChildConditions);

		// Token: 0x0200016D RID: 365
		// (Invoke) Token: 0x06000B82 RID: 2946
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_EnterIngame([MarshalAs(UnmanagedType.LPStr)] string gameMode, int playMode);

		// Token: 0x0200016E RID: 366
		// (Invoke) Token: 0x06000B86 RID: 2950
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_ExitIngame();

		// Token: 0x0200016F RID: 367
		// (Invoke) Token: 0x06000B8A RID: 2954
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Editor_IsIngame();

		// Token: 0x02000170 RID: 368
		// (Invoke) Token: 0x06000B8E RID: 2958
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_MuteSound([MarshalAs(UnmanagedType.U1)] bool mute);

		// Token: 0x02000171 RID: 369
		// (Invoke) Token: 0x06000B92 RID: 2962
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Online_GetUplayUserName();

		// Token: 0x02000172 RID: 370
		// (Invoke) Token: 0x06000B96 RID: 2966
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Online_GetUplayAccountId();

		// Token: 0x02000173 RID: 371
		// (Invoke) Token: 0x06000B9A RID: 2970
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GamerProfile_Create();

		// Token: 0x02000174 RID: 372
		// (Invoke) Token: 0x06000B9E RID: 2974
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_GamerProfile_IsReady();

		// Token: 0x02000175 RID: 373
		// (Invoke) Token: 0x06000BA2 RID: 2978
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_GamerProfile_HasCreationFailed();

		// Token: 0x02000176 RID: 374
		// (Invoke) Token: 0x06000BA6 RID: 2982
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GamerProfile_UpdateManager();

		// Token: 0x02000177 RID: 375
		// (Invoke) Token: 0x06000BAA RID: 2986
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_Reset();

		// Token: 0x02000178 RID: 376
		// (Invoke) Token: 0x06000BAE RID: 2990
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Document_LoadPhysical([MarshalAs(UnmanagedType.LPStr)] string mapPath);

		// Token: 0x02000179 RID: 377
		// (Invoke) Token: 0x06000BB2 RID: 2994
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Document_Load(byte[] mapPath, byte[] mapName);

		// Token: 0x0200017A RID: 378
		// (Invoke) Token: 0x06000BB6 RID: 2998
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_Save(byte[] mapPath, byte[] mapName);

		// Token: 0x0200017B RID: 379
		// (Invoke) Token: 0x06000BBA RID: 3002
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Document_CheckValidation([MarshalAs(UnmanagedType.U1)] bool checkStandaloneConditions, [MarshalAs(UnmanagedType.U1)] bool checkChildConditions);

		// Token: 0x0200017C RID: 380
		// (Invoke) Token: 0x06000BBE RID: 3006
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_Validate();

		// Token: 0x0200017D RID: 381
		// (Invoke) Token: 0x06000BC2 RID: 3010
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_GetMapID(out ulong mapIdHigh, out ulong mapIdLow);

		// Token: 0x0200017E RID: 382
		// (Invoke) Token: 0x06000BC6 RID: 3014
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_SetMapID(ulong mapIdHigh, ulong mapIdLow);

		// Token: 0x0200017F RID: 383
		// (Invoke) Token: 0x06000BCA RID: 3018
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_GetVersionID(out ulong mapIdHigh, out ulong mapIdLow);

		// Token: 0x02000180 RID: 384
		// (Invoke) Token: 0x06000BCE RID: 3022
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Document_GetMapDefaultName();

		// Token: 0x02000181 RID: 385
		// (Invoke) Token: 0x06000BD2 RID: 3026
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Document_GetMapName();

		// Token: 0x02000182 RID: 386
		// (Invoke) Token: 0x06000BD6 RID: 3030
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_SetMapName([MarshalAs(UnmanagedType.LPWStr)] string mapName);

		// Token: 0x02000183 RID: 387
		// (Invoke) Token: 0x06000BDA RID: 3034
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Document_GetCreatorName();

		// Token: 0x02000184 RID: 388
		// (Invoke) Token: 0x06000BDE RID: 3038
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_SetCreatorName([MarshalAs(UnmanagedType.LPWStr)] string creatorName);

		// Token: 0x02000185 RID: 389
		// (Invoke) Token: 0x06000BE2 RID: 3042
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Document_GetAuthorName();

		// Token: 0x02000186 RID: 390
		// (Invoke) Token: 0x06000BE6 RID: 3046
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_SetAuthorName([MarshalAs(UnmanagedType.LPWStr)] string authorName);

		// Token: 0x02000187 RID: 391
		// (Invoke) Token: 0x06000BEA RID: 3050
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Document_GetBattlefieldSize();

		// Token: 0x02000188 RID: 392
		// (Invoke) Token: 0x06000BEE RID: 3054
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_SetBattlefieldSize(int size);

		// Token: 0x02000189 RID: 393
		// (Invoke) Token: 0x06000BF2 RID: 3058
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Document_GetPlayerSize();

		// Token: 0x0200018A RID: 394
		// (Invoke) Token: 0x06000BF6 RID: 3062
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_SetPlayerSize(int size);

		// Token: 0x0200018B RID: 395
		// (Invoke) Token: 0x06000BFA RID: 3066
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Document_IsSnapshotSet();

		// Token: 0x0200018C RID: 396
		// (Invoke) Token: 0x06000BFE RID: 3070
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_ClearSnapshot();

		// Token: 0x0200018D RID: 397
		// (Invoke) Token: 0x06000C02 RID: 3074
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_GetSnapshotPos(out float x, out float y, out float z);

		// Token: 0x0200018E RID: 398
		// (Invoke) Token: 0x06000C06 RID: 3078
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_SetSnapshotPos(float x, float y, float z);

		// Token: 0x0200018F RID: 399
		// (Invoke) Token: 0x06000C0A RID: 3082
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_GetSnapshotAngle(out float x, out float y, out float z);

		// Token: 0x02000190 RID: 400
		// (Invoke) Token: 0x06000C0E RID: 3086
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_SetSnapshotAngle(float x, float y, float z);

		// Token: 0x02000191 RID: 401
		// (Invoke) Token: 0x06000C12 RID: 3090
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_TakeSnapshot();

		// Token: 0x02000192 RID: 402
		// (Invoke) Token: 0x06000C16 RID: 3094
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Document_IsNavmeshEnabled();

		// Token: 0x02000193 RID: 403
		// (Invoke) Token: 0x06000C1A RID: 3098
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_SetNavmeshEnabled([MarshalAs(UnmanagedType.U1)] bool value);

		// Token: 0x02000194 RID: 404
		// (Invoke) Token: 0x06000C1E RID: 3102
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_FinalizeMap();

		// Token: 0x02000195 RID: 405
		// (Invoke) Token: 0x06000C22 RID: 3106
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_Export([MarshalAs(UnmanagedType.LPStr)] string mapName, [MarshalAs(UnmanagedType.LPStr)] string exportPath, [MarshalAs(UnmanagedType.U1)] bool toConsole);

		// Token: 0x02000196 RID: 406
		// (Invoke) Token: 0x06000C26 RID: 3110
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_Dump([MarshalAs(UnmanagedType.LPStr)] string mapName, [MarshalAs(UnmanagedType.LPStr)] string dumpPath);

		// Token: 0x02000197 RID: 407
		// (Invoke) Token: 0x06000C2A RID: 3114
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_ExtractBigFile([MarshalAs(UnmanagedType.LPStr)] string mapName, [MarshalAs(UnmanagedType.LPStr)] string bfPath, [MarshalAs(UnmanagedType.LPStr)] string bfName);

		// Token: 0x02000198 RID: 408
		// (Invoke) Token: 0x06000C2E RID: 3118
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_ClearMapTags();

		// Token: 0x02000199 RID: 409
		// (Invoke) Token: 0x06000C32 RID: 3122
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_GetMapTags(IntPtr mapTagDbIdsVector);

		// Token: 0x0200019A RID: 410
		// (Invoke) Token: 0x06000C36 RID: 3126
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Document_AppendMapTag(ulong mapTagId);

		// Token: 0x0200019B RID: 411
		// (Invoke) Token: 0x06000C3A RID: 3130
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_WaitScreen_Show([MarshalAs(UnmanagedType.LPWStr)] string text, [MarshalAs(UnmanagedType.U1)] bool opaque, [MarshalAs(UnmanagedType.U1)] bool saving, [MarshalAs(UnmanagedType.U1)] bool disableUI);

		// Token: 0x0200019C RID: 412
		// (Invoke) Token: 0x06000C3E RID: 3134
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_WaitScreen_Hide();

		// Token: 0x0200019D RID: 413
		// (Invoke) Token: 0x06000C42 RID: 3138
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsCollectionVisible();

		// Token: 0x0200019E RID: 414
		// (Invoke) Token: 0x06000C46 RID: 3142
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowCollections([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x0200019F RID: 415
		// (Invoke) Token: 0x06000C4A RID: 3146
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsFogVisible();

		// Token: 0x020001A0 RID: 416
		// (Invoke) Token: 0x06000C4E RID: 3150
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowFog([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x020001A1 RID: 417
		// (Invoke) Token: 0x06000C52 RID: 3154
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsExposureVisible();

		// Token: 0x020001A2 RID: 418
		// (Invoke) Token: 0x06000C56 RID: 3158
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowExposure([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x020001A3 RID: 419
		// (Invoke) Token: 0x06000C5A RID: 3162
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsShadowVisible();

		// Token: 0x020001A4 RID: 420
		// (Invoke) Token: 0x06000C5E RID: 3166
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowShadow([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x020001A5 RID: 421
		// (Invoke) Token: 0x06000C62 RID: 3170
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsWaterVisible();

		// Token: 0x020001A6 RID: 422
		// (Invoke) Token: 0x06000C66 RID: 3174
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowWater([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x020001A7 RID: 423
		// (Invoke) Token: 0x06000C6A RID: 3178
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsIconsVisible();

		// Token: 0x020001A8 RID: 424
		// (Invoke) Token: 0x06000C6E RID: 3182
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowIcons([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x020001A9 RID: 425
		// (Invoke) Token: 0x06000C72 RID: 3186
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsSoundEnabled();

		// Token: 0x020001AA RID: 426
		// (Invoke) Token: 0x06000C76 RID: 3190
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetSoundEnabled([MarshalAs(UnmanagedType.U1)] bool enabled);

		// Token: 0x020001AB RID: 427
		// (Invoke) Token: 0x06000C7A RID: 3194
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsGridVisible();

		// Token: 0x020001AC RID: 428
		// (Invoke) Token: 0x06000C7E RID: 3198
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowGrid([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x020001AD RID: 429
		// (Invoke) Token: 0x06000C82 RID: 3202
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_EditorSettings_GetGridResolution();

		// Token: 0x020001AE RID: 430
		// (Invoke) Token: 0x06000C86 RID: 3206
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetGridResolution(int resolution);

		// Token: 0x020001AF RID: 431
		// (Invoke) Token: 0x06000C8A RID: 3210
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsBudgetGridVisible();

		// Token: 0x020001B0 RID: 432
		// (Invoke) Token: 0x06000C8E RID: 3214
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowBudgetGrid_Callback(Binding.EditorSettingsShowBudgetGridCallback callback);

		// Token: 0x020001B1 RID: 433
		// (Invoke) Token: 0x06000C92 RID: 3218
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowBudgetGrid([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x020001B2 RID: 434
		// (Invoke) Token: 0x06000C96 RID: 3222
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_EditorSettings_GetBudgetGridResolution();

		// Token: 0x020001B3 RID: 435
		// (Invoke) Token: 0x06000C9A RID: 3226
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetBudgetGridResolution(int resolution);

		// Token: 0x020001B4 RID: 436
		// (Invoke) Token: 0x06000C9E RID: 3230
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsNavmeshVisible();

		// Token: 0x020001B5 RID: 437
		// (Invoke) Token: 0x06000CA2 RID: 3234
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowNavmesh(int layer);

		// Token: 0x020001B6 RID: 438
		// (Invoke) Token: 0x06000CA6 RID: 3238
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_HideNavmesh();

		// Token: 0x020001B7 RID: 439
		// (Invoke) Token: 0x06000CAA RID: 3242
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_EditorSettings_GetNavmeshLayer();

		// Token: 0x020001B8 RID: 440
		// (Invoke) Token: 0x06000CAE RID: 3246
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsCoversVisible();

		// Token: 0x020001B9 RID: 441
		// (Invoke) Token: 0x06000CB2 RID: 3250
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowCovers([MarshalAs(UnmanagedType.U1)] bool show);

		// Token: 0x020001BA RID: 442
		// (Invoke) Token: 0x06000CB6 RID: 3254
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsInvincible();

		// Token: 0x020001BB RID: 443
		// (Invoke) Token: 0x06000CBA RID: 3258
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetInvincible([MarshalAs(UnmanagedType.U1)] bool invincible);

		// Token: 0x020001BC RID: 444
		// (Invoke) Token: 0x06000CBE RID: 3262
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsInvisible();

		// Token: 0x020001BD RID: 445
		// (Invoke) Token: 0x06000CC2 RID: 3266
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetInvisible([MarshalAs(UnmanagedType.U1)] bool invisible);

		// Token: 0x020001BE RID: 446
		// (Invoke) Token: 0x06000CC6 RID: 3270
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsSnappingObjectsToTerrain();

		// Token: 0x020001BF RID: 447
		// (Invoke) Token: 0x06000CCA RID: 3274
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetSnapObjectsToTerrain([MarshalAs(UnmanagedType.U1)] bool snap);

		// Token: 0x020001C0 RID: 448
		// (Invoke) Token: 0x06000CCE RID: 3278
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsAutoSnappingObjects();

		// Token: 0x020001C1 RID: 449
		// (Invoke) Token: 0x06000CD2 RID: 3282
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetAutoSnappingObjects([MarshalAs(UnmanagedType.U1)] bool snap);

		// Token: 0x020001C2 RID: 450
		// (Invoke) Token: 0x06000CD6 RID: 3286
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsAutoSnappingObjectsRotation();

		// Token: 0x020001C3 RID: 451
		// (Invoke) Token: 0x06000CDA RID: 3290
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetAutoSnappingObjectsRotation([MarshalAs(UnmanagedType.U1)] bool snap);

		// Token: 0x020001C4 RID: 452
		// (Invoke) Token: 0x06000CDE RID: 3294
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsAutoSnappingObjectsTerrain();

		// Token: 0x020001C5 RID: 453
		// (Invoke) Token: 0x06000CE2 RID: 3298
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetAutoSnappingObjectsTerrain([MarshalAs(UnmanagedType.U1)] bool snap);

		// Token: 0x020001C6 RID: 454
		// (Invoke) Token: 0x06000CE6 RID: 3302
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsCameraClippedTerrain();

		// Token: 0x020001C7 RID: 455
		// (Invoke) Token: 0x06000CEA RID: 3306
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetCameraClipTerrain([MarshalAs(UnmanagedType.U1)] bool clip);

		// Token: 0x020001C8 RID: 456
		// (Invoke) Token: 0x06000CEE RID: 3310
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsCameraCollision();

		// Token: 0x020001C9 RID: 457
		// (Invoke) Token: 0x06000CF2 RID: 3314
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetCameraCollision([MarshalAs(UnmanagedType.U1)] bool value);

		// Token: 0x020001CA RID: 458
		// (Invoke) Token: 0x06000CF6 RID: 3318
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_EditorSettings_GetEngineQuality();

		// Token: 0x020001CB RID: 459
		// (Invoke) Token: 0x06000CFA RID: 3322
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetEngineQuality(int engineQuality);

		// Token: 0x020001CC RID: 460
		// (Invoke) Token: 0x06000CFE RID: 3326
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsKillDistanceOverride();

		// Token: 0x020001CD RID: 461
		// (Invoke) Token: 0x06000D02 RID: 3330
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_SetKillDistanceOverride([MarshalAs(UnmanagedType.U1)] bool _override);

		// Token: 0x020001CE RID: 462
		// (Invoke) Token: 0x06000D06 RID: 3334
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_EditorSettings_IsOcclusionVisible();

		// Token: 0x020001CF RID: 463
		// (Invoke) Token: 0x06000D0A RID: 3338
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_EditorSettings_ShowOcclusion([MarshalAs(UnmanagedType.U1)] bool _override);

		// Token: 0x020001D0 RID: 464
		// (Invoke) Token: 0x06000D0E RID: 3342
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_NomadDbIdVector_Create();

		// Token: 0x020001D1 RID: 465
		// (Invoke) Token: 0x06000D12 RID: 3346
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_NomadDbIdVector_Destroy(IntPtr vector);

		// Token: 0x020001D2 RID: 466
		// (Invoke) Token: 0x06000D16 RID: 3350
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_NomadDbIdVector_GetCount(IntPtr gameModeDescDbIdsVector);

		// Token: 0x020001D3 RID: 467
		// (Invoke) Token: 0x06000D1A RID: 3354
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate ulong _FCE_NomadDbIdVector_GetAt(IntPtr gameModeDescDbIdsVector, uint index);

		// Token: 0x020001D4 RID: 468
		// (Invoke) Token: 0x06000D1E RID: 3358
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameMode_GetAllGameModeDescDbIds(IntPtr gameModeDescDbIdsVector);

		// Token: 0x020001D5 RID: 469
		// (Invoke) Token: 0x06000D22 RID: 3362
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_GameMode_GetGameModeNameId(ulong gameModeDescDbId);

		// Token: 0x020001D6 RID: 470
		// (Invoke) Token: 0x06000D26 RID: 3366
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameMode_GetObjectiveDescDbIds(ulong gameModeDescDbId, IntPtr objectiveDescDbIdsVector);

		// Token: 0x020001D7 RID: 471
		// (Invoke) Token: 0x06000D2A RID: 3370
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_GameMode_GetObjectiveNameId(ulong objectiveDescDbId);

		// Token: 0x020001D8 RID: 472
		// (Invoke) Token: 0x06000D2E RID: 3374
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_GameMode_GetObjectiveDescId(ulong objectiveDescDbId);

		// Token: 0x020001D9 RID: 473
		// (Invoke) Token: 0x06000D32 RID: 3378
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate ulong _FCE_GameMode_GetCurrentObjectiveDescId();

		// Token: 0x020001DA RID: 474
		// (Invoke) Token: 0x06000D36 RID: 3382
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameMode_SetCurrentObjectiveDescId(ulong objectiveDescDbId);

		// Token: 0x020001DB RID: 475
		// (Invoke) Token: 0x06000D3A RID: 3386
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate ulong _FCE_GameMode_GetCurrentGameModeDescId();

		// Token: 0x020001DC RID: 476
		// (Invoke) Token: 0x06000D3E RID: 3390
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameMode_SetCurrentGameModeDescId(ulong gameModeDescDbId);

		// Token: 0x020001DD RID: 477
		// (Invoke) Token: 0x06000D42 RID: 3394
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate ulong _FCE_GameMode_GetObjectiveEnumValue();

		// Token: 0x020001DE RID: 478
		// (Invoke) Token: 0x06000D46 RID: 3398
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameMode_GetAllWildernessDbIds(IntPtr wildernessDbIdsVector);

		// Token: 0x020001DF RID: 479
		// (Invoke) Token: 0x06000D4A RID: 3402
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_GameMode_WildernessNameId(ulong wildernessDbId);

		// Token: 0x020001E0 RID: 480
		// (Invoke) Token: 0x06000D4E RID: 3406
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_GameMode_WildernessScriptPathId(ulong wildernessDbId);

		// Token: 0x020001E1 RID: 481
		// (Invoke) Token: 0x06000D52 RID: 3410
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameProperty_GetAllPropertyIds(IntPtr objectivePropertyIdsVector);

		// Token: 0x020001E2 RID: 482
		// (Invoke) Token: 0x06000D56 RID: 3414
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_GameProperty_GetPropertyID(ulong propertyId);

		// Token: 0x020001E3 RID: 483
		// (Invoke) Token: 0x06000D5A RID: 3418
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_GameProperty_GetPropertyType(ulong propertyId);

		// Token: 0x020001E4 RID: 484
		// (Invoke) Token: 0x06000D5E RID: 3422
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_GameProperty_GetPropertyValueType(ulong propertyId);

		// Token: 0x020001E5 RID: 485
		// (Invoke) Token: 0x06000D62 RID: 3426
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameProperty_GetSupportedObjectiveDescDbIds(ulong propertyId, IntPtr objectiveDescDbIdsVector);

		// Token: 0x020001E6 RID: 486
		// (Invoke) Token: 0x06000D66 RID: 3430
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate ulong _FCE_GameProperty_GetPropertyChildID(ulong propertyId);

		// Token: 0x020001E7 RID: 487
		// (Invoke) Token: 0x06000D6A RID: 3434
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_GameProperty_GetPropertyMinValue(ulong propertyId);

		// Token: 0x020001E8 RID: 488
		// (Invoke) Token: 0x06000D6E RID: 3438
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_GameProperty_GetPropertyMaxValue(ulong propertyId);

		// Token: 0x020001E9 RID: 489
		// (Invoke) Token: 0x06000D72 RID: 3442
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_GameProperty_GetPropertyResolution(ulong propertyId);

		// Token: 0x020001EA RID: 490
		// (Invoke) Token: 0x06000D76 RID: 3446
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_GameProperty_GetPropertyDefaultFloat(ulong propertyId);

		// Token: 0x020001EB RID: 491
		// (Invoke) Token: 0x06000D7A RID: 3450
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_GameProperty_GetPropertyDefaultBoolean(ulong propertyId);

		// Token: 0x020001EC RID: 492
		// (Invoke) Token: 0x06000D7E RID: 3454
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate ulong _FCE_GameProperty_GetPropertyDefaultPresetId(ulong propertyId);

		// Token: 0x020001ED RID: 493
		// (Invoke) Token: 0x06000D82 RID: 3458
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_GameProperty_GetPropertyDisplayNameId(ulong propertyId);

		// Token: 0x020001EE RID: 494
		// (Invoke) Token: 0x06000D86 RID: 3462
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_GameProperty_GetPropertyCategoryNameId(ulong propertyId);

		// Token: 0x020001EF RID: 495
		// (Invoke) Token: 0x06000D8A RID: 3466
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameProperty_GetPropertyPresetIds(ulong propertyId, IntPtr presetIdsVector);

		// Token: 0x020001F0 RID: 496
		// (Invoke) Token: 0x06000D8E RID: 3470
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_GameProperty_GetPropertyPresetDisplayNameId(ulong presetId);

		// Token: 0x020001F1 RID: 497
		// (Invoke) Token: 0x06000D92 RID: 3474
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_MapTag_GetAllDbIds(IntPtr mapTagIdsVector);

		// Token: 0x020001F2 RID: 498
		// (Invoke) Token: 0x06000D96 RID: 3478
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_MapTag_GetDisplayNameId(ulong mapTagId);

		// Token: 0x020001F3 RID: 499
		// (Invoke) Token: 0x06000D9A RID: 3482
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate ulong _FCE_MapTag_GetObjectiveRef(ulong mapTagId);

		// Token: 0x020001F4 RID: 500
		// (Invoke) Token: 0x06000D9E RID: 3486
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_MapTag_GetModifierRefs(ulong mapTagId, IntPtr modiferDbIdVector);

		// Token: 0x020001F5 RID: 501
		// (Invoke) Token: 0x06000DA2 RID: 3490
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_MapTag_GetAvailableGameModes(ulong mapTagId, IntPtr gameModeDbIdVector);

		// Token: 0x020001F6 RID: 502
		// (Invoke) Token: 0x06000DA6 RID: 3494
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_MapTag_GetPresetRefs(ulong mapTagId, IntPtr presetDbIdVector);

		// Token: 0x020001F7 RID: 503
		// (Invoke) Token: 0x06000DAA RID: 3498
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_MapTag_GetIsAuto(ulong mapTagId);

		// Token: 0x020001F8 RID: 504
		// (Invoke) Token: 0x06000DAE RID: 3502
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_MapTag_GetIsEnum(ulong mapTagId);

		// Token: 0x020001F9 RID: 505
		// (Invoke) Token: 0x06000DB2 RID: 3506
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_MapTag_GetIsEnumDefault(ulong mapTagId);

		// Token: 0x020001FA RID: 506
		// (Invoke) Token: 0x06000DB6 RID: 3510
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_MapTag_GetPriority(ulong mapTagId);

		// Token: 0x020001FB RID: 507
		// (Invoke) Token: 0x06000DBA RID: 3514
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_PC_KeyboardKeyEvent(char param);

		// Token: 0x020001FC RID: 508
		// (Invoke) Token: 0x06000DBE RID: 3518
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_BeginGroup();

		// Token: 0x020001FD RID: 509
		// (Invoke) Token: 0x06000DC2 RID: 3522
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_EndGroup();

		// Token: 0x020001FE RID: 510
		// (Invoke) Token: 0x06000DC6 RID: 3526
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_ScreenCircleOutlined(float x, float y, float z, float radius, float penWidth, float r, float g, float b, float a);

		// Token: 0x020001FF RID: 511
		// (Invoke) Token: 0x06000DCA RID: 3530
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_ScreenRectangleOutlined(float x, float y, float z, float width, float height, float penWidth, float r, float g, float b, float a);

		// Token: 0x02000200 RID: 512
		// (Invoke) Token: 0x06000DCE RID: 3534
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_Quad(float x, float y, float z, float width, float height, float r, float g, float b, float a);

		// Token: 0x02000201 RID: 513
		// (Invoke) Token: 0x06000DD2 RID: 3538
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_Square(float x, float y, float z, float radius, float penWidth, float r, float g, float b, float a, float zOrder, float r2, float g2, float b2, float a2);

		// Token: 0x02000202 RID: 514
		// (Invoke) Token: 0x06000DD6 RID: 3542
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_Terrain_Circle(float x, float y, float radius, float penWidth, float r, float g, float b, float a, float zOrder, float zOffset, float r2, float g2, float b2, float a2);

		// Token: 0x02000203 RID: 515
		// (Invoke) Token: 0x06000DDA RID: 3546
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_Terrain_Square(float x, float y, float radius, float penWidth, float r, float g, float b, float a, float zOrder, float zOffset, float r2, float g2, float b2, float a2);

		// Token: 0x02000204 RID: 516
		// (Invoke) Token: 0x06000DDE RID: 3550
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_Arrow(float x, float y, float z, float dirX, float dirY, float dirZ, float length, float radius, float headLength, float headRadius, float r, float g, float b, float a);

		// Token: 0x02000205 RID: 517
		// (Invoke) Token: 0x06000DE2 RID: 3554
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_Dot(float x, float y, float z, float radius, float r, float g, float b, [MarshalAs(UnmanagedType.U1)] bool renderBack, [MarshalAs(UnmanagedType.U1)] bool startGroup);

		// Token: 0x02000206 RID: 518
		// (Invoke) Token: 0x06000DE6 RID: 3558
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_SegmentedLineSegment(float x1, float y1, float z1, float x2, float y2, float z2, float penRadius, float penRadius2, float r, float g, float b, [MarshalAs(UnmanagedType.U1)] bool back);

		// Token: 0x02000207 RID: 519
		// (Invoke) Token: 0x06000DEA RID: 3562
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_WireBoxFromBottomZ(float x, float y, float z, float sizeX, float sizeY, float sizeZ, float penWidth);

		// Token: 0x02000208 RID: 520
		// (Invoke) Token: 0x06000DEE RID: 3566
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Draw_WireRegionFromTerrain(IntPtr points, float penWidth, float r, float g, float b);

		// Token: 0x02000209 RID: 521
		// (Invoke) Token: 0x06000DF2 RID: 3570
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_Input_Forward(float input);

		// Token: 0x0200020A RID: 522
		// (Invoke) Token: 0x06000DF6 RID: 3574
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_Input_Lateral(float input);

		// Token: 0x0200020B RID: 523
		// (Invoke) Token: 0x06000DFA RID: 3578
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_GetPos(out float x, out float y, out float z);

		// Token: 0x0200020C RID: 524
		// (Invoke) Token: 0x06000DFE RID: 3582
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_SetPos(float x, float y, float z);

		// Token: 0x0200020D RID: 525
		// (Invoke) Token: 0x06000E02 RID: 3586
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_GetAngles(out float x, out float y, out float z);

		// Token: 0x0200020E RID: 526
		// (Invoke) Token: 0x06000E06 RID: 3590
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_SetAngles(float x, float y, float z);

		// Token: 0x0200020F RID: 527
		// (Invoke) Token: 0x06000E0A RID: 3594
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_Rotate(float pitch, float roll, float yaw);

		// Token: 0x02000210 RID: 528
		// (Invoke) Token: 0x06000E0E RID: 3598
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_GetFrontVector(out float x, out float y, out float z);

		// Token: 0x02000211 RID: 529
		// (Invoke) Token: 0x06000E12 RID: 3602
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_GetRightVector(out float x, out float y, out float z);

		// Token: 0x02000212 RID: 530
		// (Invoke) Token: 0x06000E16 RID: 3606
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_GetUpVector(out float x, out float y, out float z);

		// Token: 0x02000213 RID: 531
		// (Invoke) Token: 0x06000E1A RID: 3610
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_Camera_GetSpeed();

		// Token: 0x02000214 RID: 532
		// (Invoke) Token: 0x06000E1E RID: 3614
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_SetSpeed(float input);

		// Token: 0x02000215 RID: 533
		// (Invoke) Token: 0x06000E22 RID: 3618
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_SetSpeedFactor(float factor);

		// Token: 0x02000216 RID: 534
		// (Invoke) Token: 0x06000E26 RID: 3622
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_Camera_GetFOV();

		// Token: 0x02000217 RID: 535
		// (Invoke) Token: 0x06000E2A RID: 3626
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_AlignToSelection(IntPtr selection);

		// Token: 0x02000218 RID: 536
		// (Invoke) Token: 0x06000E2E RID: 3630
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Camera_AlignToObject(IntPtr _object);

		// Token: 0x02000219 RID: 537
		// (Invoke) Token: 0x06000E32 RID: 3634
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Brush_Create([MarshalAs(UnmanagedType.U1)] bool circle, float radius, float hardness, float opacity, float distortion);

		// Token: 0x0200021A RID: 538
		// (Invoke) Token: 0x06000E36 RID: 3638
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Brush_Destroy(IntPtr pBrush);

		// Token: 0x0200021B RID: 539
		// (Invoke) Token: 0x06000E3A RID: 3642
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Bump(float x, float y, float amount, IntPtr pBrush);

		// Token: 0x0200021C RID: 540
		// (Invoke) Token: 0x06000E3E RID: 3646
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Bump_End();

		// Token: 0x0200021D RID: 541
		// (Invoke) Token: 0x06000E42 RID: 3650
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_RaiseLower(float x, float y, float amount, IntPtr pBrush);

		// Token: 0x0200021E RID: 542
		// (Invoke) Token: 0x06000E46 RID: 3654
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_RaiseLower_End();

		// Token: 0x0200021F RID: 543
		// (Invoke) Token: 0x06000E4A RID: 3658
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_SetHeight(float x, float y, float height, IntPtr pBrush);

		// Token: 0x02000220 RID: 544
		// (Invoke) Token: 0x06000E4E RID: 3662
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_SetHeight_End();

		// Token: 0x02000221 RID: 545
		// (Invoke) Token: 0x06000E52 RID: 3666
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_Terrain_GetAverageHeight(float x, float y, IntPtr pBrush);

		// Token: 0x02000222 RID: 546
		// (Invoke) Token: 0x06000E56 RID: 3670
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Average(float x, float y, IntPtr pBrush);

		// Token: 0x02000223 RID: 547
		// (Invoke) Token: 0x06000E5A RID: 3674
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Average_End();

		// Token: 0x02000224 RID: 548
		// (Invoke) Token: 0x06000E5E RID: 3678
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Grab_Begin(float x, float y, IntPtr pBrush);

		// Token: 0x02000225 RID: 549
		// (Invoke) Token: 0x06000E62 RID: 3682
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Grab(float ratio);

		// Token: 0x02000226 RID: 550
		// (Invoke) Token: 0x06000E66 RID: 3686
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Grab_End();

		// Token: 0x02000227 RID: 551
		// (Invoke) Token: 0x06000E6A RID: 3690
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Smooth(float x, float y, IntPtr pBrush);

		// Token: 0x02000228 RID: 552
		// (Invoke) Token: 0x06000E6E RID: 3694
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Smooth_End();

		// Token: 0x02000229 RID: 553
		// (Invoke) Token: 0x06000E72 RID: 3698
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Ramp(float x1, float y1, float x2, float y2, float radius, float hardness);

		// Token: 0x0200022A RID: 554
		// (Invoke) Token: 0x06000E76 RID: 3702
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Terrace(float x, float y, float height, float falloff, IntPtr pBrush);

		// Token: 0x0200022B RID: 555
		// (Invoke) Token: 0x06000E7A RID: 3706
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Terrace_End();

		// Token: 0x0200022C RID: 556
		// (Invoke) Token: 0x06000E7E RID: 3710
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Noise_Begin(int numOctaves, float noiseSize, float persistence, int noiseType);

		// Token: 0x0200022D RID: 557
		// (Invoke) Token: 0x06000E82 RID: 3714
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Noise(float x, float y, float amount, IntPtr pBrush);

		// Token: 0x0200022E RID: 558
		// (Invoke) Token: 0x06000E86 RID: 3718
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Noise_End();

		// Token: 0x0200022F RID: 559
		// (Invoke) Token: 0x06000E8A RID: 3722
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Erosion(float x, float y, float radius, float density, float deformation, float channelDepth, float randomness);

		// Token: 0x02000230 RID: 560
		// (Invoke) Token: 0x06000E8E RID: 3726
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Erosion_End();

		// Token: 0x02000231 RID: 561
		// (Invoke) Token: 0x06000E92 RID: 3730
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Hole(int x1, int y1, int x2, int y2, [MarshalAs(UnmanagedType.U1)] bool hole);

		// Token: 0x02000232 RID: 562
		// (Invoke) Token: 0x06000E96 RID: 3734
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Terrain_Hole_End();

		// Token: 0x02000233 RID: 563
		// (Invoke) Token: 0x06000E9A RID: 3738
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Inventory_Entry_IsDirectory(IntPtr entry);

		// Token: 0x02000234 RID: 564
		// (Invoke) Token: 0x06000E9E RID: 3742
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Inventory_Entry_IsDeleted(IntPtr entry);

		// Token: 0x02000235 RID: 565
		// (Invoke) Token: 0x06000EA2 RID: 3746
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Entry_SetDeleted(IntPtr entry, [MarshalAs(UnmanagedType.U1)] bool value);

		// Token: 0x02000236 RID: 566
		// (Invoke) Token: 0x06000EA6 RID: 3750
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Entry_ClearChildren(IntPtr entry);

		// Token: 0x02000237 RID: 567
		// (Invoke) Token: 0x06000EAA RID: 3754
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Entry_AddChild(IntPtr entry, IntPtr child);

		// Token: 0x02000238 RID: 568
		// (Invoke) Token: 0x06000EAE RID: 3758
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Entry_SetChildIndex(IntPtr directory, IntPtr child, int index);

		// Token: 0x02000239 RID: 569
		// (Invoke) Token: 0x06000EB2 RID: 3762
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Entry_OpenThumbnailData(IntPtr entry, out IntPtr data, out int dataSize);

		// Token: 0x0200023A RID: 570
		// (Invoke) Token: 0x06000EB6 RID: 3766
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Entry_CloseThumbnailData(IntPtr entry, IntPtr data);

		// Token: 0x0200023B RID: 571
		// (Invoke) Token: 0x06000EBA RID: 3770
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Object_GetRoot();

		// Token: 0x0200023C RID: 572
		// (Invoke) Token: 0x06000EBE RID: 3774
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Object_CreatePrefabObject(IntPtr parent, [MarshalAs(UnmanagedType.LPStr)] string id);

		// Token: 0x0200023D RID: 573
		// (Invoke) Token: 0x06000EC2 RID: 3778
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Object_CreateDirectory(IntPtr parent);

		// Token: 0x0200023E RID: 574
		// (Invoke) Token: 0x06000EC6 RID: 3782
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Object_CreateFilterDirectory();

		// Token: 0x0200023F RID: 575
		// (Invoke) Token: 0x06000ECA RID: 3786
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_DestroyFilterDirectory(IntPtr directory);

		// Token: 0x02000240 RID: 576
		// (Invoke) Token: 0x06000ECE RID: 3790
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SearchInventoryEntry(IntPtr entry, [MarshalAs(UnmanagedType.LPWStr)] string criteria, IntPtr resultDirectory);

		// Token: 0x02000241 RID: 577
		// (Invoke) Token: 0x06000ED2 RID: 3794
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Object_GetParent(IntPtr entry);

		// Token: 0x02000242 RID: 578
		// (Invoke) Token: 0x06000ED6 RID: 3798
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SetParent(IntPtr entry, IntPtr parent);

		// Token: 0x02000243 RID: 579
		// (Invoke) Token: 0x06000EDA RID: 3802
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Inventory_Object_IsDirectory(IntPtr entry);

		// Token: 0x02000244 RID: 580
		// (Invoke) Token: 0x06000EDE RID: 3806
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Inventory_Object_GetChildCount(IntPtr entry);

		// Token: 0x02000245 RID: 581
		// (Invoke) Token: 0x06000EE2 RID: 3810
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Object_GetChild(IntPtr entry, int index);

		// Token: 0x02000246 RID: 582
		// (Invoke) Token: 0x06000EE6 RID: 3814
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_Inventory_Object_GetId(IntPtr entry);

		// Token: 0x02000247 RID: 583
		// (Invoke) Token: 0x06000EEA RID: 3818
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Object_GetIdString(IntPtr entry);

		// Token: 0x02000248 RID: 584
		// (Invoke) Token: 0x06000EEE RID: 3822
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SetIdString(IntPtr entry, [MarshalAs(UnmanagedType.LPStr)] string id);

		// Token: 0x02000249 RID: 585
		// (Invoke) Token: 0x06000EF2 RID: 3826
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Object_GetDisplay(IntPtr entry);

		// Token: 0x0200024A RID: 586
		// (Invoke) Token: 0x06000EF6 RID: 3830
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SetDisplay(IntPtr entry, [MarshalAs(UnmanagedType.LPWStr)] string display);

		// Token: 0x0200024B RID: 587
		// (Invoke) Token: 0x06000EFA RID: 3834
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Object_GetTags(IntPtr entry);

		// Token: 0x0200024C RID: 588
		// (Invoke) Token: 0x06000EFE RID: 3838
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SetTags(IntPtr entry, [MarshalAs(UnmanagedType.LPStr)] string tags);

		// Token: 0x0200024D RID: 589
		// (Invoke) Token: 0x06000F02 RID: 3842
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Inventory_Object_GetSourceType(IntPtr entry);

		// Token: 0x0200024E RID: 590
		// (Invoke) Token: 0x06000F06 RID: 3846
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_GetBMin(IntPtr entry, out float bminX, out float bminY, out float bminZ);

		// Token: 0x0200024F RID: 591
		// (Invoke) Token: 0x06000F0A RID: 3850
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_GetBMax(IntPtr entry, out float bmaxX, out float bmaxY, out float bmaxZ);

		// Token: 0x02000250 RID: 592
		// (Invoke) Token: 0x06000F0E RID: 3854
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_GetSize(IntPtr entry, out float sizeX, out float sizeY, out float sizeZ);

		// Token: 0x02000251 RID: 593
		// (Invoke) Token: 0x06000F12 RID: 3858
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Inventory_Object_IsAI(IntPtr entry);

		// Token: 0x02000252 RID: 594
		// (Invoke) Token: 0x06000F16 RID: 3862
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Inventory_Object_IsObjectType(IntPtr entry, int objectType);

		// Token: 0x02000253 RID: 595
		// (Invoke) Token: 0x06000F1A RID: 3866
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Inventory_Object_IsAutoOrientation(IntPtr entry);

		// Token: 0x02000254 RID: 596
		// (Invoke) Token: 0x06000F1E RID: 3870
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_Inventory_Object_GetZOffset(IntPtr entry);

		// Token: 0x02000255 RID: 597
		// (Invoke) Token: 0x06000F22 RID: 3874
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SetZOffset(IntPtr entry, float zOffset);

		// Token: 0x02000256 RID: 598
		// (Invoke) Token: 0x06000F26 RID: 3878
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SaveChanges();

		// Token: 0x02000257 RID: 599
		// (Invoke) Token: 0x06000F2A RID: 3882
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_ClearPivots(IntPtr entry);

		// Token: 0x02000258 RID: 600
		// (Invoke) Token: 0x06000F2E RID: 3886
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_AddPivot(IntPtr entry, float posX, float posY, float posZ, float normX, float normY, float normZ, float normUpX, float normUpY, float normUpZ);

		// Token: 0x02000259 RID: 601
		// (Invoke) Token: 0x06000F32 RID: 3890
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SetPivot(IntPtr entry, int idx, float posX, float posY, float posZ, float normX, float normY, float normZ, float normUpX, float normUpY, float normUpZ);

		// Token: 0x0200025A RID: 602
		// (Invoke) Token: 0x06000F36 RID: 3894
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SetPivots(IntPtr entry, float minX, float maxX, float minY, float maxY);

		// Token: 0x0200025B RID: 603
		// (Invoke) Token: 0x06000F3A RID: 3898
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Inventory_Object_IsAutoPivot(IntPtr entry);

		// Token: 0x0200025C RID: 604
		// (Invoke) Token: 0x06000F3E RID: 3902
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Inventory_Object_SetAutoPivot(IntPtr entry, [MarshalAs(UnmanagedType.U1)] bool autoPivot);

		// Token: 0x0200025D RID: 605
		// (Invoke) Token: 0x06000F42 RID: 3906
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Inventory_Object_GetPivotCount(IntPtr entry);

		// Token: 0x0200025E RID: 606
		// (Invoke) Token: 0x06000F46 RID: 3910
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Inventory_Object_HasComponent(IntPtr entry, [MarshalAs(UnmanagedType.LPStr)] string componentName);

		// Token: 0x0200025F RID: 607
		// (Invoke) Token: 0x06000F4A RID: 3914
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate ulong _FCE_Inventory_Object_GetArchetypeId(IntPtr entry);

		// Token: 0x02000260 RID: 608
		// (Invoke) Token: 0x06000F4E RID: 3918
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_Inventory_Object_GetWaveNum(IntPtr entry);

		// Token: 0x02000261 RID: 609
		// (Invoke) Token: 0x06000F52 RID: 3922
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Inventory_Object_IsObjectiveGameplayObject(IntPtr entry);

		// Token: 0x02000262 RID: 610
		// (Invoke) Token: 0x06000F56 RID: 3926
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Collection_GetRoot();

		// Token: 0x02000263 RID: 611
		// (Invoke) Token: 0x06000F5A RID: 3930
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Collection_GetParent(IntPtr entry);

		// Token: 0x02000264 RID: 612
		// (Invoke) Token: 0x06000F5E RID: 3934
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Inventory_Collection_GetChildCount(IntPtr entry);

		// Token: 0x02000265 RID: 613
		// (Invoke) Token: 0x06000F62 RID: 3938
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Collection_GetChild(IntPtr entry, int index);

		// Token: 0x02000266 RID: 614
		// (Invoke) Token: 0x06000F66 RID: 3942
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Collection_GetDisplay(IntPtr entry);

		// Token: 0x02000267 RID: 615
		// (Invoke) Token: 0x06000F6A RID: 3946
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate uint _FCE_Inventory_Collection_GetBurnProfile(IntPtr entry);

		// Token: 0x02000268 RID: 616
		// (Invoke) Token: 0x06000F6E RID: 3950
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Texture_GetRoot();

		// Token: 0x02000269 RID: 617
		// (Invoke) Token: 0x06000F72 RID: 3954
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Texture_GetParent(IntPtr entry);

		// Token: 0x0200026A RID: 618
		// (Invoke) Token: 0x06000F76 RID: 3958
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Inventory_Texture_GetChildCount(IntPtr entry);

		// Token: 0x0200026B RID: 619
		// (Invoke) Token: 0x06000F7A RID: 3962
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Texture_GetChild(IntPtr entry, int index);

		// Token: 0x0200026C RID: 620
		// (Invoke) Token: 0x06000F7E RID: 3966
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Texture_GetDisplay(IntPtr entry);

		// Token: 0x0200026D RID: 621
		// (Invoke) Token: 0x06000F82 RID: 3970
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Water_GetRoot();

		// Token: 0x0200026E RID: 622
		// (Invoke) Token: 0x06000F86 RID: 3974
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Water_GetParent(IntPtr entry);

		// Token: 0x0200026F RID: 623
		// (Invoke) Token: 0x06000F8A RID: 3978
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Inventory_Water_GetChildCount(IntPtr entry);

		// Token: 0x02000270 RID: 624
		// (Invoke) Token: 0x06000F8E RID: 3982
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Water_GetChild(IntPtr entry, int index);

		// Token: 0x02000271 RID: 625
		// (Invoke) Token: 0x06000F92 RID: 3986
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Water_GetDisplay(IntPtr entry);

		// Token: 0x02000272 RID: 626
		// (Invoke) Token: 0x06000F96 RID: 3990
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Water_GetFromId([MarshalAs(UnmanagedType.LPStr)] string id);

		// Token: 0x02000273 RID: 627
		// (Invoke) Token: 0x06000F9A RID: 3994
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Spline_GetRoot();

		// Token: 0x02000274 RID: 628
		// (Invoke) Token: 0x06000F9E RID: 3998
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Spline_GetParent(IntPtr entry);

		// Token: 0x02000275 RID: 629
		// (Invoke) Token: 0x06000FA2 RID: 4002
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Inventory_Spline_GetChildCount(IntPtr entry);

		// Token: 0x02000276 RID: 630
		// (Invoke) Token: 0x06000FA6 RID: 4006
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Spline_GetChild(IntPtr entry, int index);

		// Token: 0x02000277 RID: 631
		// (Invoke) Token: 0x06000FAA RID: 4010
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Spline_GetDisplay(IntPtr entry);

		// Token: 0x02000278 RID: 632
		// (Invoke) Token: 0x06000FAE RID: 4014
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_Inventory_Spline_GetDefaultWidth(IntPtr entry);

		// Token: 0x02000279 RID: 633
		// (Invoke) Token: 0x06000FB2 RID: 4018
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Region_GetRoot();

		// Token: 0x0200027A RID: 634
		// (Invoke) Token: 0x06000FB6 RID: 4022
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Region_GetParent(IntPtr entry);

		// Token: 0x0200027B RID: 635
		// (Invoke) Token: 0x06000FBA RID: 4026
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Inventory_Region_GetChildCount(IntPtr entry);

		// Token: 0x0200027C RID: 636
		// (Invoke) Token: 0x06000FBE RID: 4030
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Region_GetChild(IntPtr entry, int index);

		// Token: 0x0200027D RID: 637
		// (Invoke) Token: 0x06000FC2 RID: 4034
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Region_GetDisplay(IntPtr entry);

		// Token: 0x0200027E RID: 638
		// (Invoke) Token: 0x06000FC6 RID: 4038
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Region_GetEntryFromId([MarshalAs(UnmanagedType.LPStr)] string id);

		// Token: 0x0200027F RID: 639
		// (Invoke) Token: 0x06000FCA RID: 4042
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Inventory_Region_GetDirectoryFromId([MarshalAs(UnmanagedType.LPStr)] string id);

		// Token: 0x02000280 RID: 640
		// (Invoke) Token: 0x06000FCE RID: 4046
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Inventory_Region_GetRegionId(IntPtr entry);

		// Token: 0x02000281 RID: 641
		// (Invoke) Token: 0x06000FD2 RID: 4050
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Object_Create_FromEntry(IntPtr entry, [MarshalAs(UnmanagedType.U1)] bool altIcon, [MarshalAs(UnmanagedType.U1)] bool managed);

		// Token: 0x02000282 RID: 642
		// (Invoke) Token: 0x06000FD6 RID: 4054
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_Destroy(IntPtr _object);

		// Token: 0x02000283 RID: 643
		// (Invoke) Token: 0x06000FDA RID: 4058
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_AddRef(IntPtr _object);

		// Token: 0x02000284 RID: 644
		// (Invoke) Token: 0x06000FDE RID: 4062
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_Release(IntPtr _object);

		// Token: 0x02000285 RID: 645
		// (Invoke) Token: 0x06000FE2 RID: 4066
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Object_Clone(IntPtr _object);

		// Token: 0x02000286 RID: 646
		// (Invoke) Token: 0x06000FE6 RID: 4070
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Object_IsLoaded(IntPtr _object);

		// Token: 0x02000287 RID: 647
		// (Invoke) Token: 0x06000FEA RID: 4074
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Object_GetEntry(IntPtr _object);

		// Token: 0x02000288 RID: 648
		// (Invoke) Token: 0x06000FEE RID: 4078
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_GetPos(IntPtr _object, out float x, out float y, out float z);

		// Token: 0x02000289 RID: 649
		// (Invoke) Token: 0x06000FF2 RID: 4082
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_SetPos(IntPtr _object, float x, float y, float z);

		// Token: 0x0200028A RID: 650
		// (Invoke) Token: 0x06000FF6 RID: 4086
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_GetAngles(IntPtr _object, out float x, out float y, out float z);

		// Token: 0x0200028B RID: 651
		// (Invoke) Token: 0x06000FFA RID: 4090
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_SetAngles(IntPtr _object, float x, float y, float z);

		// Token: 0x0200028C RID: 652
		// (Invoke) Token: 0x06000FFE RID: 4094
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_GetBounds(IntPtr _object, [MarshalAs(UnmanagedType.U1)] bool world, out float x1, out float y1, out float z1, out float x2, out float y2, out float z2);

		// Token: 0x0200028D RID: 653
		// (Invoke) Token: 0x06001002 RID: 4098
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Object_IsVisible(IntPtr _object);

		// Token: 0x0200028E RID: 654
		// (Invoke) Token: 0x06001006 RID: 4102
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_SetVisible(IntPtr _object, [MarshalAs(UnmanagedType.U1)] bool visible);

		// Token: 0x0200028F RID: 655
		// (Invoke) Token: 0x0600100A RID: 4106
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_SetHighlight(IntPtr _object, [MarshalAs(UnmanagedType.U1)] bool highlight);

		// Token: 0x02000290 RID: 656
		// (Invoke) Token: 0x0600100E RID: 4110
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_SetFreeze(IntPtr _object, [MarshalAs(UnmanagedType.U1)] bool freeze);

		// Token: 0x02000291 RID: 657
		// (Invoke) Token: 0x06001012 RID: 4114
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_DropToGround(IntPtr _object, [MarshalAs(UnmanagedType.U1)] bool physics);

		// Token: 0x02000292 RID: 658
		// (Invoke) Token: 0x06001016 RID: 4118
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_ComputeAutoOrientation(IntPtr _object, ref float x, ref float y, ref float z, out float angleX, out float angleY, out float angleZ, float normX, float normY, float normZ);

		// Token: 0x02000293 RID: 659
		// (Invoke) Token: 0x0600101A RID: 4122
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Object_GetPivot(IntPtr _object, int idx, out float x, out float y, out float z, out float normX, out float normY, out float normZ, out float normUpX, out float normUpY, out float normUpZ);

		// Token: 0x02000294 RID: 660
		// (Invoke) Token: 0x0600101E RID: 4126
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Object_GetClosestPivot(IntPtr _object, float posX, float posY, float posZ, out float pivotX, out float pivotY, out float pivotZ, out float normX, out float normY, out float normZ, out float normUpX, out float normUpY, out float normUpZ, float minDist);

		// Token: 0x02000295 RID: 661
		// (Invoke) Token: 0x06001022 RID: 4130
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_SnapToClosestObject(IntPtr _object);

		// Token: 0x02000296 RID: 662
		// (Invoke) Token: 0x06001026 RID: 4134
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Object_GetPhysEntities(IntPtr _object, IntPtr vector);

		// Token: 0x02000297 RID: 663
		// (Invoke) Token: 0x0600102A RID: 4138
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_ShowWaveCallback(Binding.ShowWaveCallback callback);

		// Token: 0x02000298 RID: 664
		// (Invoke) Token: 0x0600102E RID: 4142
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_SetEntityToSpawn(IntPtr _object, ulong archetype, int waveid);

		// Token: 0x02000299 RID: 665
		// (Invoke) Token: 0x06001032 RID: 4146
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_SetWaveTransition(int waveNumber, float ratio);

		// Token: 0x0200029A RID: 666
		// (Invoke) Token: 0x06001036 RID: 4150
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_AI_GetWaveTransition(int waveNumber);

		// Token: 0x0200029B RID: 667
		// (Invoke) Token: 0x0600103A RID: 4154
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_SetAmbientProperties(IntPtr _object, int spawnStrategy);

		// Token: 0x0200029C RID: 668
		// (Invoke) Token: 0x0600103E RID: 4158
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_GetAmbientProperties(IntPtr _object, out int spawnStrategy);

		// Token: 0x0200029D RID: 669
		// (Invoke) Token: 0x06001042 RID: 4162
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_SetSTPProperties(IntPtr _object, float duration, float cooldown, int factionType);

		// Token: 0x0200029E RID: 670
		// (Invoke) Token: 0x06001046 RID: 4166
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_GetSTPProperties(IntPtr _object, out float duration, out float cooldown, out int factionType);

		// Token: 0x0200029F RID: 671
		// (Invoke) Token: 0x0600104A RID: 4170
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_SetPatrolProperties(IntPtr _object, float cooldown, [MarshalAs(UnmanagedType.U1)] bool loopPatrol, [MarshalAs(UnmanagedType.U1)] bool drawWeapon, int factionType);

		// Token: 0x020002A0 RID: 672
		// (Invoke) Token: 0x0600104E RID: 4174
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_GetPatrolProperties(IntPtr _object, out float cooldown, [MarshalAs(UnmanagedType.U1)] out bool loopPatrol, [MarshalAs(UnmanagedType.U1)] out bool drawWeapon, out int factionType);

		// Token: 0x020002A1 RID: 673
		// (Invoke) Token: 0x06001052 RID: 4178
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_SetAIGroup(IntPtr _object, [MarshalAs(UnmanagedType.LPStr)] string group);

		// Token: 0x020002A2 RID: 674
		// (Invoke) Token: 0x06001056 RID: 4182
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_AI_IsValidObjectiveEntity(IntPtr _object);

		// Token: 0x020002A3 RID: 675
		// (Invoke) Token: 0x0600105A RID: 4186
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_AI_ShowWaveOnly(int waveid);

		// Token: 0x020002A4 RID: 676
		// (Invoke) Token: 0x0600105E RID: 4190
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_AI_GetStpUsage(IntPtr _object);

		// Token: 0x020002A5 RID: 677
		// (Invoke) Token: 0x06001062 RID: 4194
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ObjectManager_GetObjectFromScreenPoint(float x, float y, out float hitX, out float hitY, out float hitZ, [MarshalAs(UnmanagedType.U1)] bool includeFrozen, IntPtr physEntities);

		// Token: 0x020002A6 RID: 678
		// (Invoke) Token: 0x06001066 RID: 4198
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectManager_GetObjectsFromScreenRect(IntPtr selection, float x1, float y1, float x2, float y2, [MarshalAs(UnmanagedType.U1)] bool includeFrozen);

		// Token: 0x020002A7 RID: 679
		// (Invoke) Token: 0x0600106A RID: 4202
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectManager_GetObjectsFromMagicWand(IntPtr selection, IntPtr _object);

		// Token: 0x020002A8 RID: 680
		// (Invoke) Token: 0x0600106E RID: 4206
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectManager_SetViewportPickingPos(float x, float y);

		// Token: 0x020002A9 RID: 681
		// (Invoke) Token: 0x06001072 RID: 4210
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectManager_UnfreezeObjects();

		// Token: 0x020002AA RID: 682
		// (Invoke) Token: 0x06001076 RID: 4214
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_ObjectManager_GetObjectCount();

		// Token: 0x020002AB RID: 683
		// (Invoke) Token: 0x0600107A RID: 4218
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ObjectManager_GetObject(int objectIndex);

		// Token: 0x020002AC RID: 684
		// (Invoke) Token: 0x0600107E RID: 4222
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ObjectSelection_Create();

		// Token: 0x020002AD RID: 685
		// (Invoke) Token: 0x06001082 RID: 4226
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_Destroy(IntPtr selection);

		// Token: 0x020002AE RID: 686
		// (Invoke) Token: 0x06001086 RID: 4230
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_Clear(IntPtr selection);

		// Token: 0x020002AF RID: 687
		// (Invoke) Token: 0x0600108A RID: 4234
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_Add(IntPtr selection, IntPtr _object);

		// Token: 0x020002B0 RID: 688
		// (Invoke) Token: 0x0600108E RID: 4238
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_AddSelection(IntPtr selection, IntPtr otherSelection);

		// Token: 0x020002B1 RID: 689
		// (Invoke) Token: 0x06001092 RID: 4242
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_ToggleObject(IntPtr selection, IntPtr _object);

		// Token: 0x020002B2 RID: 690
		// (Invoke) Token: 0x06001096 RID: 4246
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_ToggleSelection(IntPtr selection, IntPtr selection2);

		// Token: 0x020002B3 RID: 691
		// (Invoke) Token: 0x0600109A RID: 4250
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_RemoveObject(IntPtr selection, IntPtr _object);

		// Token: 0x020002B4 RID: 692
		// (Invoke) Token: 0x0600109E RID: 4254
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_RemoveSelection(IntPtr selection, IntPtr selection2);

		// Token: 0x020002B5 RID: 693
		// (Invoke) Token: 0x060010A2 RID: 4258
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_ObjectSelection_GetCount(IntPtr selection);

		// Token: 0x020002B6 RID: 694
		// (Invoke) Token: 0x060010A6 RID: 4262
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ObjectSelection_Get(IntPtr selection, int index);

		// Token: 0x020002B7 RID: 695
		// (Invoke) Token: 0x060010AA RID: 4266
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_GetValidObjects(IntPtr selection, IntPtr otherSelection);

		// Token: 0x020002B8 RID: 696
		// (Invoke) Token: 0x060010AE RID: 4270
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_RemoveInvalidObjects(IntPtr selection);

		// Token: 0x020002B9 RID: 697
		// (Invoke) Token: 0x060010B2 RID: 4274
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_Clone(IntPtr selection, IntPtr newSelection, [MarshalAs(UnmanagedType.U1)] bool cloneObjects);

		// Token: 0x020002BA RID: 698
		// (Invoke) Token: 0x060010B6 RID: 4278
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_Delete(IntPtr selection);

		// Token: 0x020002BB RID: 699
		// (Invoke) Token: 0x060010BA RID: 4282
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_GetCenter(IntPtr selection, out float x, out float y, out float z);

		// Token: 0x020002BC RID: 700
		// (Invoke) Token: 0x060010BE RID: 4286
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_SetCenter(IntPtr selection, float x, float y, float z);

		// Token: 0x020002BD RID: 701
		// (Invoke) Token: 0x060010C2 RID: 4290
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_GetComputeCenter(IntPtr selection, out float x, out float y, out float z);

		// Token: 0x020002BE RID: 702
		// (Invoke) Token: 0x060010C6 RID: 4294
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_ComputeCenter(IntPtr selection);

		// Token: 0x020002BF RID: 703
		// (Invoke) Token: 0x060010CA RID: 4298
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_GetWorldBounds(IntPtr selection, out float x1, out float y1, out float z1, out float x2, out float y2, out float z2);

		// Token: 0x020002C0 RID: 704
		// (Invoke) Token: 0x060010CE RID: 4302
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_MoveTo(IntPtr selection, float x, float y, float z, int mode);

		// Token: 0x020002C1 RID: 705
		// (Invoke) Token: 0x060010D2 RID: 4306
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_Rotate(IntPtr selection, float angle, float axisX, float axisY, float axisZ, float pivotX, float pivotY, float pivotZ, [MarshalAs(UnmanagedType.U1)] bool affectCenter);

		// Token: 0x020002C2 RID: 706
		// (Invoke) Token: 0x060010D6 RID: 4310
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_Rotate3(IntPtr selection, float angleX, float angleY, float angleZ, float axisX, float axisY, float axisZ, float pivotX, float pivotY, float pivotZ, [MarshalAs(UnmanagedType.U1)] bool affectCenter);

		// Token: 0x020002C3 RID: 707
		// (Invoke) Token: 0x060010DA RID: 4314
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_RotateCenter(IntPtr selection, float angle, float x, float y, float z);

		// Token: 0x020002C4 RID: 708
		// (Invoke) Token: 0x060010DE RID: 4318
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_RotateLocal3(IntPtr selection, float angleX, float angleY, float angleZ);

		// Token: 0x020002C5 RID: 709
		// (Invoke) Token: 0x060010E2 RID: 4322
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_RotateGimbal(IntPtr selection, float x, float y, float z);

		// Token: 0x020002C6 RID: 710
		// (Invoke) Token: 0x060010E6 RID: 4326
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_DropToGround(IntPtr selection, [MarshalAs(UnmanagedType.U1)] bool physics, [MarshalAs(UnmanagedType.U1)] bool group);

		// Token: 0x020002C7 RID: 711
		// (Invoke) Token: 0x060010EA RID: 4330
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_SnapToPivot(IntPtr selection, float sourcePosX, float sourcePosY, float sourcePosZ, float sourceNormX, float sourceNormY, float sourceNormZ, float sourceNormUpX, float sourceNormUpY, float sourceNormUpZ, float targetPosX, float targetPosY, float targetPosZ, float targetNormX, float targetNormY, float targetNormZ, float targetNormUpX, float targetNormUpY, float targetNormUpZ, [MarshalAs(UnmanagedType.U1)] bool preserveOrientation, float snapAngle);

		// Token: 0x020002C8 RID: 712
		// (Invoke) Token: 0x060010EE RID: 4334
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_SnapToClosestObjects(IntPtr selection);

		// Token: 0x020002C9 RID: 713
		// (Invoke) Token: 0x060010F2 RID: 4338
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_GetPhysEntities(IntPtr selection, IntPtr vector);

		// Token: 0x020002CA RID: 714
		// (Invoke) Token: 0x060010F6 RID: 4342
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_ClearState(IntPtr selection);

		// Token: 0x020002CB RID: 715
		// (Invoke) Token: 0x060010FA RID: 4346
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_LoadState(IntPtr selection);

		// Token: 0x020002CC RID: 716
		// (Invoke) Token: 0x060010FE RID: 4350
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectSelection_SaveState(IntPtr selection);

		// Token: 0x020002CD RID: 717
		// (Invoke) Token: 0x06001102 RID: 4354
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_ObjectSelection_LoadFromXml(IntPtr selection, [MarshalAs(UnmanagedType.LPStr)] string xml, [MarshalAs(UnmanagedType.U1)] bool managed, [MarshalAs(UnmanagedType.U1)] bool removeGameplayObjects);

		// Token: 0x020002CE RID: 718
		// (Invoke) Token: 0x06001106 RID: 4358
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public delegate string _FCE_ObjectSelection_SaveToXml(IntPtr selection);

		// Token: 0x020002CF RID: 719
		// (Invoke) Token: 0x0600110A RID: 4362
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_ObjectSelection_IsAxesXYLocked(IntPtr selection);

		// Token: 0x020002D0 RID: 720
		// (Invoke) Token: 0x0600110E RID: 4366
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectViewer_SetActive([MarshalAs(UnmanagedType.U1)] bool active);

		// Token: 0x020002D1 RID: 721
		// (Invoke) Token: 0x06001112 RID: 4370
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectViewer_SetObject(IntPtr _object);

		// Token: 0x020002D2 RID: 722
		// (Invoke) Token: 0x06001116 RID: 4374
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectLegoBox_SetActive([MarshalAs(UnmanagedType.U1)] bool active);

		// Token: 0x020002D3 RID: 723
		// (Invoke) Token: 0x0600111A RID: 4378
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectLegoBox_AddEntry(IntPtr entry);

		// Token: 0x020002D4 RID: 724
		// (Invoke) Token: 0x0600111E RID: 4382
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectLegoBox_ClearEntries();

		// Token: 0x020002D5 RID: 725
		// (Invoke) Token: 0x06001122 RID: 4386
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectLegoBox_CreateLegoBox();

		// Token: 0x020002D6 RID: 726
		// (Invoke) Token: 0x06001126 RID: 4390
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ObjectLegoBox_GetEntryFromScreenPoint(float x, float y);

		// Token: 0x020002D7 RID: 727
		// (Invoke) Token: 0x0600112A RID: 4394
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectRenderer_Clear();

		// Token: 0x020002D8 RID: 728
		// (Invoke) Token: 0x0600112E RID: 4398
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectRenderer_SetActive([MarshalAs(UnmanagedType.U1)] bool active);

		// Token: 0x020002D9 RID: 729
		// (Invoke) Token: 0x06001132 RID: 4402
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectRenderer_RenderObject(IntPtr entry);

		// Token: 0x020002DA RID: 730
		// (Invoke) Token: 0x06001136 RID: 4406
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_ObjectRenderer_IsSnapshotReady();

		// Token: 0x020002DB RID: 731
		// (Invoke) Token: 0x0600113A RID: 4410
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ObjectRenderer_GetSnapshot(out int minX, out int minY, out int maxX, out int maxY);

		// Token: 0x020002DC RID: 732
		// (Invoke) Token: 0x0600113E RID: 4414
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ObjectRenderer_GetSnapshotEntry();

		// Token: 0x020002DD RID: 733
		// (Invoke) Token: 0x06001142 RID: 4418
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectRenderer_ClearSnapshot();

		// Token: 0x020002DE RID: 734
		// (Invoke) Token: 0x06001146 RID: 4422
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectRenderer_WritePNG(IntPtr data, int width, int height, [MarshalAs(UnmanagedType.LPStr)] string filename);

		// Token: 0x020002DF RID: 735
		// (Invoke) Token: 0x0600114A RID: 4426
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ObjectRenderer_GenerateThumbnails();

		// Token: 0x020002E0 RID: 736
		// (Invoke) Token: 0x0600114E RID: 4430
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_CollectionRenderer_GenerateThumbnails();

		// Token: 0x020002E1 RID: 737
		// (Invoke) Token: 0x06001152 RID: 4434
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_WaterRenderer_GenerateThumbnails();

		// Token: 0x020002E2 RID: 738
		// (Invoke) Token: 0x06001156 RID: 4438
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Gizmo_Create();

		// Token: 0x020002E3 RID: 739
		// (Invoke) Token: 0x0600115A RID: 4442
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_Destroy(IntPtr gizmo);

		// Token: 0x020002E4 RID: 740
		// (Invoke) Token: 0x0600115E RID: 4446
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_GetPos(IntPtr gizmo, out float x, out float y, out float z);

		// Token: 0x020002E5 RID: 741
		// (Invoke) Token: 0x06001162 RID: 4450
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_SetPos(IntPtr gizmo, float x, float y, float z);

		// Token: 0x020002E6 RID: 742
		// (Invoke) Token: 0x06001166 RID: 4454
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_GetAxis(IntPtr gizmo, out float x1, out float y1, out float z1, out float x2, out float y2, out float z2, out float x3, out float y3, out float z3);

		// Token: 0x020002E7 RID: 743
		// (Invoke) Token: 0x0600116A RID: 4458
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_SetAxis(IntPtr gizmo, float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3);

		// Token: 0x020002E8 RID: 744
		// (Invoke) Token: 0x0600116E RID: 4462
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Gizmo_GetActive(IntPtr gizmo);

		// Token: 0x020002E9 RID: 745
		// (Invoke) Token: 0x06001172 RID: 4466
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_SetActive(IntPtr gizmo, int axis);

		// Token: 0x020002EA RID: 746
		// (Invoke) Token: 0x06001176 RID: 4470
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_Redraw(IntPtr gizmo);

		// Token: 0x020002EB RID: 747
		// (Invoke) Token: 0x0600117A RID: 4474
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_Hide(IntPtr gizmo);

		// Token: 0x020002EC RID: 748
		// (Invoke) Token: 0x0600117E RID: 4478
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Gizmo_IsRotationMode(IntPtr gizmo);

		// Token: 0x020002ED RID: 749
		// (Invoke) Token: 0x06001182 RID: 4482
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_SetRotationMode(IntPtr gizmo, [MarshalAs(UnmanagedType.U1)] bool value);

		// Token: 0x020002EE RID: 750
		// (Invoke) Token: 0x06001186 RID: 4486
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_ResetAxes(IntPtr gizmo);

		// Token: 0x020002EF RID: 751
		// (Invoke) Token: 0x0600118A RID: 4490
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Gizmo_EnableAxis(IntPtr gizmo, int axis, [MarshalAs(UnmanagedType.U1)] bool flag);

		// Token: 0x020002F0 RID: 752
		// (Invoke) Token: 0x0600118E RID: 4494
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Gizmo_HitTest(IntPtr gizmo, float raySrcX, float raySrcY, float raySrcZ, float rayDirX, float rayDirY, float rayDirZ);

		// Token: 0x020002F1 RID: 753
		// (Invoke) Token: 0x06001192 RID: 4498
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_CollectionManager_GetCollectionEntryFromId(int id);

		// Token: 0x020002F2 RID: 754
		// (Invoke) Token: 0x06001196 RID: 4502
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_CollectionManager_AssignCollectionId(int id, IntPtr entry);

		// Token: 0x020002F3 RID: 755
		// (Invoke) Token: 0x0600119A RID: 4506
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_CollectionManager_WriteMaskCircle(float cx, float cy, float radius, int id, [MarshalAs(UnmanagedType.U1)] bool update);

		// Token: 0x020002F4 RID: 756
		// (Invoke) Token: 0x0600119E RID: 4510
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_CollectionManager_WriteMaskSquare(float cx, float cy, float radius, int id, [MarshalAs(UnmanagedType.U1)] bool update);

		// Token: 0x020002F5 RID: 757
		// (Invoke) Token: 0x060011A2 RID: 4514
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_CollectionManager_ClearMaskId(int id);

		// Token: 0x020002F6 RID: 758
		// (Invoke) Token: 0x060011A6 RID: 4518
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_CollectionManager_UpdateCollections(int x, int y, int w, int h);

		// Token: 0x020002F7 RID: 759
		// (Invoke) Token: 0x060011AA RID: 4522
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_CollectionManager_ActivatePhysics([MarshalAs(UnmanagedType.U1)] bool activate);

		// Token: 0x020002F8 RID: 760
		// (Invoke) Token: 0x060011AE RID: 4526
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Collection_Paint(float x, float y, int id, IntPtr pBrush);

		// Token: 0x020002F9 RID: 761
		// (Invoke) Token: 0x060011B2 RID: 4530
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Collection_Paint_End();

		// Token: 0x020002FA RID: 762
		// (Invoke) Token: 0x060011B6 RID: 4534
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Texture_Paint(float x, float y, float amount, int id, IntPtr pBrush);

		// Token: 0x020002FB RID: 763
		// (Invoke) Token: 0x060011BA RID: 4538
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Texture_Paint_End();

		// Token: 0x020002FC RID: 764
		// (Invoke) Token: 0x060011BE RID: 4542
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Texture_PaintConstraints_Begin(float minHeight, float maxHeight, float heightFuzziness, float minSlope, float maxSlope);

		// Token: 0x020002FD RID: 765
		// (Invoke) Token: 0x060011C2 RID: 4546
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Texture_PaintConstraints(float x, float y, float amount, int id, IntPtr pBrush);

		// Token: 0x020002FE RID: 766
		// (Invoke) Token: 0x060011C6 RID: 4550
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Texture_PaintConstraints_End();

		// Token: 0x020002FF RID: 767
		// (Invoke) Token: 0x060011CA RID: 4554
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_TerrainManager_GetHeightAt(float x, float y);

		// Token: 0x02000300 RID: 768
		// (Invoke) Token: 0x060011CE RID: 4558
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_TerrainManager_GetHeightAtWithWater(float x, float y);

		// Token: 0x02000301 RID: 769
		// (Invoke) Token: 0x060011D2 RID: 4562
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_TerrainManager_GetTextureEntryFromId(int id);

		// Token: 0x02000302 RID: 770
		// (Invoke) Token: 0x060011D6 RID: 4566
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_TerrainManager_AssignTextureId(int id, IntPtr entry);

		// Token: 0x02000303 RID: 771
		// (Invoke) Token: 0x060011DA RID: 4570
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_TerrainManager_ClearTextureId(int id);

		// Token: 0x02000304 RID: 772
		// (Invoke) Token: 0x060011DE RID: 4574
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_TerrainManager_GetGlobalWaterLevel();

		// Token: 0x02000305 RID: 773
		// (Invoke) Token: 0x060011E2 RID: 4578
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_TerrainManager_SetGlobalWaterLevel(float waterLevel);

		// Token: 0x02000306 RID: 774
		// (Invoke) Token: 0x060011E6 RID: 4582
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_TerrainManager_SetWaterLevelSector(int sx, int sy, float waterLevel, IntPtr entry);

		// Token: 0x02000307 RID: 775
		// (Invoke) Token: 0x060011EA RID: 4586
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_TerrainManager_UpdateWaterLevel();

		// Token: 0x02000308 RID: 776
		// (Invoke) Token: 0x060011EE RID: 4590
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_TerrainManager_GetLogicZoneId();

		// Token: 0x02000309 RID: 777
		// (Invoke) Token: 0x060011F2 RID: 4594
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_TerrainManager_SetLogicZoneId(int id);

		// Token: 0x0200030A RID: 778
		// (Invoke) Token: 0x060011F6 RID: 4598
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_TerrainManager_GetSoundRegionId();

		// Token: 0x0200030B RID: 779
		// (Invoke) Token: 0x060011FA RID: 4602
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_TerrainManager_SetSoundRegionId(int id);

		// Token: 0x0200030C RID: 780
		// (Invoke) Token: 0x060011FE RID: 4606
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_UndoManager_GetUndoCount();

		// Token: 0x0200030D RID: 781
		// (Invoke) Token: 0x06001202 RID: 4610
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_UndoManager_GetRedoCount();

		// Token: 0x0200030E RID: 782
		// (Invoke) Token: 0x06001206 RID: 4614
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_UndoManager_Undo();

		// Token: 0x0200030F RID: 783
		// (Invoke) Token: 0x0600120A RID: 4618
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_UndoManager_Redo();

		// Token: 0x02000310 RID: 784
		// (Invoke) Token: 0x0600120E RID: 4622
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_UndoManager_RecordUndo();

		// Token: 0x02000311 RID: 785
		// (Invoke) Token: 0x06001212 RID: 4626
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_UndoManager_CommitUndo();

		// Token: 0x02000312 RID: 786
		// (Invoke) Token: 0x06001216 RID: 4630
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Validation_Objective(ulong objectiveDescId);

		// Token: 0x02000313 RID: 787
		// (Invoke) Token: 0x0600121A RID: 4634
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Validation_Game();

		// Token: 0x02000314 RID: 788
		// (Invoke) Token: 0x0600121E RID: 4638
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ValidationReport_Destroy(IntPtr report);

		// Token: 0x02000315 RID: 789
		// (Invoke) Token: 0x06001222 RID: 4642
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_ValidationReport_GetCount(IntPtr report);

		// Token: 0x02000316 RID: 790
		// (Invoke) Token: 0x06001226 RID: 4646
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ValidationReport_GetRecord(IntPtr report, int index);

		// Token: 0x02000317 RID: 791
		// (Invoke) Token: 0x0600122A RID: 4650
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_ValidationRecord_GetSeverity(IntPtr record);

		// Token: 0x02000318 RID: 792
		// (Invoke) Token: 0x0600122E RID: 4654
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_ValidationRecord_GetFlags(IntPtr record);

		// Token: 0x02000319 RID: 793
		// (Invoke) Token: 0x06001232 RID: 4658
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_ValidationRecord_GetErrorCode(IntPtr record);

		// Token: 0x0200031A RID: 794
		// (Invoke) Token: 0x06001236 RID: 4662
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ValidationRecord_GetMessage(IntPtr record);

		// Token: 0x0200031B RID: 795
		// (Invoke) Token: 0x0600123A RID: 4666
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ValidationRecord_GetObject(IntPtr record);

		// Token: 0x0200031C RID: 796
		// (Invoke) Token: 0x0600123E RID: 4670
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Snapshot_Create();

		// Token: 0x0200031D RID: 797
		// (Invoke) Token: 0x06001242 RID: 4674
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Snapshot_Destroy(IntPtr imageInfo);

		// Token: 0x0200031E RID: 798
		// (Invoke) Token: 0x06001246 RID: 4678
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Snapshot_GetData(IntPtr imageInfo, out IntPtr data, out uint width, out uint height);

		// Token: 0x0200031F RID: 799
		// (Invoke) Token: 0x0600124A RID: 4682
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Spline_Create();

		// Token: 0x02000320 RID: 800
		// (Invoke) Token: 0x0600124E RID: 4686
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_Destroy(IntPtr spline);

		// Token: 0x02000321 RID: 801
		// (Invoke) Token: 0x06001252 RID: 4690
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_Clear(IntPtr spline);

		// Token: 0x02000322 RID: 802
		// (Invoke) Token: 0x06001256 RID: 4694
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_AddPoint(IntPtr spline, float x, float y);

		// Token: 0x02000323 RID: 803
		// (Invoke) Token: 0x0600125A RID: 4698
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_InsertPoint(IntPtr spline, float x, float y, int index);

		// Token: 0x02000324 RID: 804
		// (Invoke) Token: 0x0600125E RID: 4702
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_RemovePoint(IntPtr spline, int index);

		// Token: 0x02000325 RID: 805
		// (Invoke) Token: 0x06001262 RID: 4706
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Spline_RemoveSimilarPoints(IntPtr spline);

		// Token: 0x02000326 RID: 806
		// (Invoke) Token: 0x06001266 RID: 4710
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Spline_OptimizePoint(IntPtr spline, int index);

		// Token: 0x02000327 RID: 807
		// (Invoke) Token: 0x0600126A RID: 4714
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Spline_GetNumPoints(IntPtr spline);

		// Token: 0x02000328 RID: 808
		// (Invoke) Token: 0x0600126E RID: 4718
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_GetPoint(IntPtr spline, int i, out float x, out float y);

		// Token: 0x02000329 RID: 809
		// (Invoke) Token: 0x06001272 RID: 4722
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_SetPoint(IntPtr spline, int i, float x, float y);

		// Token: 0x0200032A RID: 810
		// (Invoke) Token: 0x06001276 RID: 4726
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_UpdateSpline(IntPtr spline);

		// Token: 0x0200032B RID: 811
		// (Invoke) Token: 0x0600127A RID: 4730
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_UpdateSplineHeight(IntPtr spline);

		// Token: 0x0200032C RID: 812
		// (Invoke) Token: 0x0600127E RID: 4734
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_FinalizeSpline(IntPtr spline);

		// Token: 0x0200032D RID: 813
		// (Invoke) Token: 0x06001282 RID: 4738
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Spline_Draw(IntPtr spline, float penWidth, IntPtr controller);

		// Token: 0x0200032E RID: 814
		// (Invoke) Token: 0x06001286 RID: 4742
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Spline_HitTestPoints(IntPtr spline, float x, float y, float penWidth, float hitWidth, out int hitIndex, out float hitX, out float hitY);

		// Token: 0x0200032F RID: 815
		// (Invoke) Token: 0x0600128A RID: 4746
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Spline_HitTestSegments(IntPtr spline, float centerX, float centerY, float radius, out int hitIndex, out float hitX, out float hitY);

		// Token: 0x02000330 RID: 816
		// (Invoke) Token: 0x0600128E RID: 4750
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_SplineRoad_GetEntry(IntPtr spline);

		// Token: 0x02000331 RID: 817
		// (Invoke) Token: 0x06001292 RID: 4754
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineRoad_SetEntry(IntPtr spline, IntPtr entry);

		// Token: 0x02000332 RID: 818
		// (Invoke) Token: 0x06001296 RID: 4758
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_SplineRoad_GetWidth(IntPtr spline);

		// Token: 0x02000333 RID: 819
		// (Invoke) Token: 0x0600129A RID: 4762
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineRoad_SetWidth(IntPtr spline, float width);

		// Token: 0x02000334 RID: 820
		// (Invoke) Token: 0x0600129E RID: 4766
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineZone_Reset(IntPtr zone);

		// Token: 0x02000335 RID: 821
		// (Invoke) Token: 0x060012A2 RID: 4770
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_SplineController_Create();

		// Token: 0x02000336 RID: 822
		// (Invoke) Token: 0x060012A6 RID: 4774
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineController_Destroy(IntPtr controller);

		// Token: 0x02000337 RID: 823
		// (Invoke) Token: 0x060012AA RID: 4778
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineController_SetSpline(IntPtr controller, IntPtr spline);

		// Token: 0x02000338 RID: 824
		// (Invoke) Token: 0x060012AE RID: 4782
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineController_ClearSelection(IntPtr controller);

		// Token: 0x02000339 RID: 825
		// (Invoke) Token: 0x060012B2 RID: 4786
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_SplineController_IsSelected(IntPtr controller, int index);

		// Token: 0x0200033A RID: 826
		// (Invoke) Token: 0x060012B6 RID: 4790
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineController_SetSelected(IntPtr controller, int index, [MarshalAs(UnmanagedType.U1)] bool selected);

		// Token: 0x0200033B RID: 827
		// (Invoke) Token: 0x060012BA RID: 4794
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineController_SelectFromScreenRect(IntPtr controller, float x1, float y1, float x2, float y2, float penWidth, int selectMode);

		// Token: 0x0200033C RID: 828
		// (Invoke) Token: 0x060012BE RID: 4798
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineController_MoveSelection(IntPtr controller, float deltaX, float deltaY);

		// Token: 0x0200033D RID: 829
		// (Invoke) Token: 0x060012C2 RID: 4802
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineController_DeleteSelection(IntPtr controller);

		// Token: 0x0200033E RID: 830
		// (Invoke) Token: 0x060012C6 RID: 4806
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_SplineManager_CreateRoad(int id);

		// Token: 0x0200033F RID: 831
		// (Invoke) Token: 0x060012CA RID: 4810
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_SplineManager_DestroyRoad(int id);

		// Token: 0x02000340 RID: 832
		// (Invoke) Token: 0x060012CE RID: 4814
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_SplineManager_GetRoadFromId(int id);

		// Token: 0x02000341 RID: 833
		// (Invoke) Token: 0x060012D2 RID: 4818
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_SplineManager_GetPlayableZone();

		// Token: 0x02000342 RID: 834
		// (Invoke) Token: 0x060012D6 RID: 4822
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_PhysEntityVector_Create();

		// Token: 0x02000343 RID: 835
		// (Invoke) Token: 0x060012DA RID: 4826
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_PhysEntityVector_Destroy(IntPtr vector);

		// Token: 0x02000344 RID: 836
		// (Invoke) Token: 0x060012DE RID: 4830
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Wilderness_Desert(float gradientWidth, float gradientHeight, float distorsion, float noiseAdd, float blurRadius);

		// Token: 0x02000345 RID: 837
		// (Invoke) Token: 0x060012E2 RID: 4834
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Wilderness_Script([MarshalAs(UnmanagedType.LPStr)] string fileName);

		// Token: 0x02000346 RID: 838
		// (Invoke) Token: 0x060012E6 RID: 4838
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Wilderness_ScriptBuffer([MarshalAs(UnmanagedType.LPStr)] string buffer, int size, Binding.ScriptMapCallback mapCallback, Binding.ScriptErrorCallback errorCallback);

		// Token: 0x02000347 RID: 839
		// (Invoke) Token: 0x060012EA RID: 4842
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Script_GetNumFunctions();

		// Token: 0x02000348 RID: 840
		// (Invoke) Token: 0x060012EE RID: 4846
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_Script_GetFunction(int index);

		// Token: 0x02000349 RID: 841
		// (Invoke) Token: 0x060012F2 RID: 4850
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ScriptFunction_GetName(IntPtr function);

		// Token: 0x0200034A RID: 842
		// (Invoke) Token: 0x060012F6 RID: 4854
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ScriptFunction_GetPrototype(IntPtr function);

		// Token: 0x0200034B RID: 843
		// (Invoke) Token: 0x060012FA RID: 4858
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ScriptFunction_GetDescription(IntPtr function);

		// Token: 0x0200034C RID: 844
		// (Invoke) Token: 0x060012FE RID: 4862
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ImageMap_GetSize(IntPtr map, out int sizeX, out int sizeY);

		// Token: 0x0200034D RID: 845
		// (Invoke) Token: 0x06001302 RID: 4866
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ImageMap_ConvertTo24bit(IntPtr map, IntPtr data, int stride, out float min, out float max);

		// Token: 0x0200034E RID: 846
		// (Invoke) Token: 0x06001306 RID: 4870
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _FCE_ImageMap_Clone(IntPtr map);

		// Token: 0x0200034F RID: 847
		// (Invoke) Token: 0x0600130A RID: 4874
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_ImageMap_Destroy(IntPtr map);

		// Token: 0x02000350 RID: 848
		// (Invoke) Token: 0x0600130E RID: 4878
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_BudgetManager_GetMemoryUsage();

		// Token: 0x02000351 RID: 849
		// (Invoke) Token: 0x06001312 RID: 4882
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_BudgetManager_GetMaxMemoryUsageMB();

		// Token: 0x02000352 RID: 850
		// (Invoke) Token: 0x06001316 RID: 4886
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_BudgetManager_GetObjectUsage();

		// Token: 0x02000353 RID: 851
		// (Invoke) Token: 0x0600131A RID: 4890
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_BudgetManager_GetMaxObjectUsage();

		// Token: 0x02000354 RID: 852
		// (Invoke) Token: 0x0600131E RID: 4894
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_BudgetManager_GetWaveUsage(int iWave);

		// Token: 0x02000355 RID: 853
		// (Invoke) Token: 0x06001322 RID: 4898
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_BudgetManager_GetMaxWaveUsage(int iWave);

		// Token: 0x02000356 RID: 854
		// (Invoke) Token: 0x06001326 RID: 4902
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_BudgetManager_GetVehicles();

		// Token: 0x02000357 RID: 855
		// (Invoke) Token: 0x0600132A RID: 4906
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_BudgetManager_GetMaxVehicles();

		// Token: 0x02000358 RID: 856
		// (Invoke) Token: 0x0600132E RID: 4910
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_BudgetManager_GetAmbientAI();

		// Token: 0x02000359 RID: 857
		// (Invoke) Token: 0x06001332 RID: 4914
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_BudgetManager_GetEnemyAI(int iWave);

		// Token: 0x0200035A RID: 858
		// (Invoke) Token: 0x06001336 RID: 4918
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_BudgetManager_ValidateObjectsGlobalCost(IntPtr selection);

		// Token: 0x0200035B RID: 859
		// (Invoke) Token: 0x0600133A RID: 4922
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_BudgetManager_ValidateObjectsSectorCost(IntPtr selection, [MarshalAs(UnmanagedType.U1)] bool alreadyAdded);

		// Token: 0x0200035C RID: 860
		// (Invoke) Token: 0x0600133E RID: 4926
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_BudgetManager_ValidateAIObjectsUsage(IntPtr selection);

		// Token: 0x0200035D RID: 861
		// (Invoke) Token: 0x06001342 RID: 4930
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_BudgetManager_ValidatePhysicsObjectsUsage(IntPtr selection);

		// Token: 0x0200035E RID: 862
		// (Invoke) Token: 0x06001346 RID: 4934
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_BudgetManager_ValidateLightObjectsUsage(IntPtr selection);

		// Token: 0x0200035F RID: 863
		// (Invoke) Token: 0x0600134A RID: 4938
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_BudgetManager_ValidateAnimPointsObjectsUsage(IntPtr selection);

		// Token: 0x02000360 RID: 864
		// (Invoke) Token: 0x0600134E RID: 4942
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_BudgetManager_ValidateSpawnPointsObjectsUsage(IntPtr selection);

		// Token: 0x02000361 RID: 865
		// (Invoke) Token: 0x06001352 RID: 4946
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_BudgetManager_GetObjectSectorId(IntPtr _object);

		// Token: 0x02000362 RID: 866
		// (Invoke) Token: 0x06001356 RID: 4950
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameModeManager_ClearObjectiveSettings();

		// Token: 0x02000363 RID: 867
		// (Invoke) Token: 0x0600135A RID: 4954
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_GameModeManager_AddObjectiveSetting(ulong objectiveSettingID, float numericValue, [MarshalAs(UnmanagedType.U1)] bool boolValue, ulong presetDbId);

		// Token: 0x02000364 RID: 868
		// (Invoke) Token: 0x0600135E RID: 4958
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_GameModeManager_GetObjectiveSettingBool(ulong objectiveSettingID, [MarshalAs(UnmanagedType.U1)] out bool value);

		// Token: 0x02000365 RID: 869
		// (Invoke) Token: 0x06001362 RID: 4962
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_GameModeManager_GetObjectiveSettingNumeric(ulong objectiveSettingID, out float value);

		// Token: 0x02000366 RID: 870
		// (Invoke) Token: 0x06001366 RID: 4966
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_GameModeManager_GetObjectiveSettingPresetDbId(ulong objectiveSettingID, out ulong value);

		// Token: 0x02000367 RID: 871
		// (Invoke) Token: 0x0600136A RID: 4970
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Navmesh_SetDisplay(int mode);

		// Token: 0x02000368 RID: 872
		// (Invoke) Token: 0x0600136E RID: 4974
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Navmesh_RegenerateTileAt(float cursorX, float cursorY, [MarshalAs(UnmanagedType.U1)] bool debugMode);

		// Token: 0x02000369 RID: 873
		// (Invoke) Token: 0x06001372 RID: 4978
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Navmesh_SetAPDisplay(int mode);

		// Token: 0x0200036A RID: 874
		// (Invoke) Token: 0x06001376 RID: 4982
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float _FCE_Navmesh_GetDebugAlpha();

		// Token: 0x0200036B RID: 875
		// (Invoke) Token: 0x0600137A RID: 4986
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Navmesh_SetDebugAlpha(float value);

		// Token: 0x0200036C RID: 876
		// (Invoke) Token: 0x0600137E RID: 4990
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int _FCE_Navmesh_GetPendingTilesCount();

		// Token: 0x0200036D RID: 877
		// (Invoke) Token: 0x06001382 RID: 4994
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _FCE_Navmesh_IsReady();

		// Token: 0x0200036E RID: 878
		// (Invoke) Token: 0x06001386 RID: 4998
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Navmesh_Sync(int numTiles);

		// Token: 0x0200036F RID: 879
		// (Invoke) Token: 0x0600138A RID: 5002
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Navmesh_Validate();

		// Token: 0x02000370 RID: 880
		// (Invoke) Token: 0x0600138E RID: 5006
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_Publish_Map();

		// Token: 0x02000371 RID: 881
		// (Invoke) Token: 0x06001392 RID: 5010
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_PublishComlete_Callback(Binding.EditorPublishCompleteCallback callback);

		// Token: 0x02000372 RID: 882
		// (Invoke) Token: 0x06001396 RID: 5014
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_Login();

		// Token: 0x02000373 RID: 883
		// (Invoke) Token: 0x0600139A RID: 5018
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_LoginComlete_Callback(Binding.EditorLoginCompleteCallback callback);

		// Token: 0x02000374 RID: 884
		// (Invoke) Token: 0x0600139E RID: 5022
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void _FCE_Editor_CreateIssue();

		// Token: 0x02000375 RID: 885
		// (Invoke) Token: 0x060013A2 RID: 5026
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.U1)]
		public delegate bool _IsNvidia();

		// Token: 0x02000376 RID: 886
		// (Invoke) Token: 0x060013A6 RID: 5030
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr _GetIGESteamCommandLine();
	}
}

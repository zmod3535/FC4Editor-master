using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace IGE.Nomad
{
	// Token: 0x020000E5 RID: 229
	internal class EditorDocument
	{
		// Token: 0x06000825 RID: 2085 RVA: 0x0001C317 File Offset: 0x0001A517
		public static void Reset()
		{
			Binding.FCE_Document_Reset();
			EditorDocument.NavmeshEnabled = true;
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0001C329 File Offset: 0x0001A529
		public static bool LoadPhysical(string path)
		{
			return Binding.FCE_Document_LoadPhysical(path);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0001C338 File Offset: 0x0001A538
		public static bool Load(string fileName, EditorDocument.LoadCompletedCallback callback)
		{
			string s = Path.GetDirectoryName(fileName) + Path.DirectorySeparatorChar;
			string fileName2 = Path.GetFileName(fileName);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			byte[] bytes2 = Encoding.UTF8.GetBytes(fileName2);
			EditorDocument.m_loadCompletedCallback = callback;
			return Binding.FCE_Document_Load(bytes, bytes2);
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0001C38C File Offset: 0x0001A58C
		public static void OnLoadCompleted(bool success)
		{
			if (!success)
			{
				MessageBox.Show(Localizer.Localize("ERROR_LOAD_FAILED", null), Localizer.Localize("ERROR", null), MessageBoxButton.OK, MessageBoxImage.Hand);
				Program.ClearMapPath();
			}
			GameProperties.PullFromGameModeManager();
			if (EditorDocument.m_loadCompletedCallback != null)
			{
				EditorDocument.m_loadCompletedCallback(success);
			}
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x0001C3CC File Offset: 0x0001A5CC
		public static void Save(string fileName, EditorDocument.SaveCompletedCallback callback)
		{
			string s = Path.GetDirectoryName(fileName) + Path.DirectorySeparatorChar;
			string fileName2 = Path.GetFileName(fileName);
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			byte[] bytes2 = Encoding.UTF8.GetBytes(fileName2);
			string text = Marshal.PtrToStringUni(Binding.FCE_Online_GetUplayUserName());
			if (!string.IsNullOrEmpty(text))
			{
				EditorDocument.AuthorName = text;
			}
			EditorDocument.m_saveCompletedCallback = callback;
			GameProperties.PushToGameModeManager();
			Binding.FCE_Document_Save(bytes, bytes2);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0001C446 File Offset: 0x0001A646
		public static void OnSaveCompleted(bool success)
		{
			if (!success)
			{
				MessageBox.Show(Localizer.Localize("ERROR_SAVE_FAILED", null), Localizer.Localize("ERROR", null), MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			if (EditorDocument.m_saveCompletedCallback != null)
			{
				EditorDocument.m_saveCompletedCallback(success);
			}
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0001C47C File Offset: 0x0001A67C
		public static bool CheckValidation(bool checkStandaloneConditions, bool checkChildConditions)
		{
			return Binding.FCE_Document_CheckValidation(checkStandaloneConditions, checkChildConditions);
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0001C48A File Offset: 0x0001A68A
		public static void Login(EditorDocument.LoginCompleteCallback callback)
		{
			EditorDocument.m_loginCompleteCallback = callback;
			Binding.FCE_Editor_Login();
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0001C49C File Offset: 0x0001A69C
		public static void OnLoginCompleted(bool success)
		{
			if (EditorDocument.m_loginCompleteCallback != null)
			{
				EditorDocument.m_loginCompleteCallback(success);
			}
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0001C4B0 File Offset: 0x0001A6B0
		public static void Publish(EditorDocument.PublishCompleteCallback callback)
		{
			EditorDocument.m_publishCompleteCallback = callback;
			Binding.FCE_Editor_Publish_Map();
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x0001C4C2 File Offset: 0x0001A6C2
		public static void OnPublishCompleted(bool success)
		{
			if (EditorDocument.m_publishCompleteCallback != null)
			{
				EditorDocument.m_publishCompleteCallback(success);
			}
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0001C4D6 File Offset: 0x0001A6D6
		public static void Validate()
		{
			Binding.FCE_Document_Validate();
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x0001C4E4 File Offset: 0x0001A6E4
		// (set) Token: 0x06000832 RID: 2098 RVA: 0x0001C540 File Offset: 0x0001A740
		public static Guid MapId
		{
			get
			{
				ulong num;
				ulong num2;
				Binding.FCE_Document_GetMapID(out num, out num2);
				string g = num.ToString("X16") + num2.ToString("X16");
				Guid result = Guid.Empty;
				try
				{
					result = new Guid(g);
				}
				catch (Exception)
				{
				}
				return result;
			}
			set
			{
				string text = value.ToString("N");
				ulong mapIdHigh = Convert.ToUInt64(text.Substring(0, 16), 16);
				ulong mapIdLow = Convert.ToUInt64(text.Substring(16, 16), 16);
				Binding.FCE_Document_SetMapID(mapIdHigh, mapIdLow);
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x0001C58C File Offset: 0x0001A78C
		public static Guid VersionId
		{
			get
			{
				ulong num;
				ulong num2;
				Binding.FCE_Document_GetVersionID(out num, out num2);
				string g = num.ToString("X16") + num2.ToString("X16");
				return new Guid(g);
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000834 RID: 2100 RVA: 0x0001C5CB File Offset: 0x0001A7CB
		public static string DefaultMapName
		{
			get
			{
				return Marshal.PtrToStringUni(Binding.FCE_Document_GetMapDefaultName());
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000835 RID: 2101 RVA: 0x0001C5DC File Offset: 0x0001A7DC
		// (set) Token: 0x06000836 RID: 2102 RVA: 0x0001C5ED File Offset: 0x0001A7ED
		public static string MapName
		{
			get
			{
				return Marshal.PtrToStringUni(Binding.FCE_Document_GetMapName());
			}
			set
			{
				Binding.FCE_Document_SetMapName(value);
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x0001C5FA File Offset: 0x0001A7FA
		// (set) Token: 0x06000838 RID: 2104 RVA: 0x0001C60B File Offset: 0x0001A80B
		public static string CreatorName
		{
			get
			{
				return Marshal.PtrToStringUni(Binding.FCE_Document_GetCreatorName());
			}
			set
			{
				Binding.FCE_Document_SetCreatorName(value);
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x0001C618 File Offset: 0x0001A818
		// (set) Token: 0x0600083A RID: 2106 RVA: 0x0001C629 File Offset: 0x0001A829
		public static string AuthorName
		{
			get
			{
				return Marshal.PtrToStringUni(Binding.FCE_Document_GetAuthorName());
			}
			set
			{
				Binding.FCE_Document_SetAuthorName(value);
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0001C636 File Offset: 0x0001A836
		// (set) Token: 0x0600083C RID: 2108 RVA: 0x0001C642 File Offset: 0x0001A842
		public static EditorDocument.BattlefieldSizes BattlefieldSize
		{
			get
			{
				return (EditorDocument.BattlefieldSizes)Binding.FCE_Document_GetBattlefieldSize();
			}
			set
			{
				Binding.FCE_Document_SetBattlefieldSize((int)value);
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x0001C64F File Offset: 0x0001A84F
		// (set) Token: 0x0600083E RID: 2110 RVA: 0x0001C65B File Offset: 0x0001A85B
		public static EditorDocument.PlayerSizes PlayerSize
		{
			get
			{
				return (EditorDocument.PlayerSizes)Binding.FCE_Document_GetPlayerSize();
			}
			set
			{
				Binding.FCE_Document_SetPlayerSize((int)value);
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x0001C668 File Offset: 0x0001A868
		public static bool IsSnapshotSet
		{
			get
			{
				return Binding.FCE_Document_IsSnapshotSet();
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x0001C674 File Offset: 0x0001A874
		// (set) Token: 0x06000841 RID: 2113 RVA: 0x0001C699 File Offset: 0x0001A899
		public static Vec3 SnapshotPos
		{
			get
			{
				float x;
				float y;
				float z;
				Binding.FCE_Document_GetSnapshotPos(out x, out y, out z);
				return new Vec3(x, y, z);
			}
			set
			{
				Binding.FCE_Document_SetSnapshotPos(value.X, value.Y, value.Z);
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x0001C6BC File Offset: 0x0001A8BC
		// (set) Token: 0x06000843 RID: 2115 RVA: 0x0001C6E1 File Offset: 0x0001A8E1
		public static Vec3 SnapshotAngle
		{
			get
			{
				float x;
				float y;
				float z;
				Binding.FCE_Document_GetSnapshotAngle(out x, out y, out z);
				return new Vec3(x, y, z);
			}
			set
			{
				Binding.FCE_Document_SetSnapshotAngle(value.X, value.Y, value.Z);
			}
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x0001C702 File Offset: 0x0001A902
		public static void ClearSnapshot()
		{
			Binding.FCE_Document_ClearSnapshot();
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0001C70E File Offset: 0x0001A90E
		public static void TakeSnapshot()
		{
			Binding.FCE_Document_TakeSnapshot();
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0001C71A File Offset: 0x0001A91A
		// (set) Token: 0x06000847 RID: 2119 RVA: 0x0001C726 File Offset: 0x0001A926
		public static bool NavmeshEnabled
		{
			get
			{
				return Binding.FCE_Document_IsNavmeshEnabled();
			}
			set
			{
				Binding.FCE_Document_SetNavmeshEnabled(value);
			}
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0001C733 File Offset: 0x0001A933
		public static void FinalizeMap()
		{
			Binding.FCE_Document_FinalizeMap();
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x0001C73F File Offset: 0x0001A93F
		public static void Export(string mapFile, string exportPath, bool toConsole)
		{
			if (!Directory.Exists(exportPath))
			{
				Directory.CreateDirectory(exportPath);
			}
			Binding.FCE_Document_Export(mapFile, exportPath, toConsole);
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0001C75D File Offset: 0x0001A95D
		public static void Dump(string mapFile, string dumpPath)
		{
			Binding.FCE_Document_Dump(mapFile, dumpPath);
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0001C76B File Offset: 0x0001A96B
		public static void ExtractBigFile(string mapFile, string bfPath, string bfName)
		{
			Binding.FCE_Document_ExtractBigFile(mapFile, bfPath, bfName);
		}

		// Token: 0x040003F6 RID: 1014
		private static EditorDocument.LoadCompletedCallback m_loadCompletedCallback;

		// Token: 0x040003F7 RID: 1015
		private static EditorDocument.SaveCompletedCallback m_saveCompletedCallback;

		// Token: 0x040003F8 RID: 1016
		private static EditorDocument.LoginCompleteCallback m_loginCompleteCallback;

		// Token: 0x040003F9 RID: 1017
		private static EditorDocument.PublishCompleteCallback m_publishCompleteCallback;

		// Token: 0x020000E6 RID: 230
		// (Invoke) Token: 0x0600084E RID: 2126
		public delegate void LoadCompletedCallback(bool success);

		// Token: 0x020000E7 RID: 231
		// (Invoke) Token: 0x06000852 RID: 2130
		public delegate void SaveCompletedCallback(bool success);

		// Token: 0x020000E8 RID: 232
		// (Invoke) Token: 0x06000856 RID: 2134
		public delegate void LoginCompleteCallback(bool success);

		// Token: 0x020000E9 RID: 233
		// (Invoke) Token: 0x0600085A RID: 2138
		public delegate void PublishCompleteCallback(bool success);

		// Token: 0x020000EA RID: 234
		public enum BattlefieldSizes
		{
			// Token: 0x040003FB RID: 1019
			Small,
			// Token: 0x040003FC RID: 1020
			Medium,
			// Token: 0x040003FD RID: 1021
			Large
		}

		// Token: 0x020000EB RID: 235
		public enum PlayerSizes
		{
			// Token: 0x040003FF RID: 1023
			Small,
			// Token: 0x04000400 RID: 1024
			Medium,
			// Token: 0x04000401 RID: 1025
			Large,
			// Token: 0x04000402 RID: 1026
			XLarge
		}
	}
}

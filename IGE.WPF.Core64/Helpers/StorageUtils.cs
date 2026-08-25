using System;
using System.IO;
using System.Runtime.InteropServices;
using IGE.Nomad;

namespace IGE.Helpers
{
	// Token: 0x02000084 RID: 132
	public static class StorageUtils
	{
		// Token: 0x06000588 RID: 1416 RVA: 0x00014E04 File Offset: 0x00013004
		public static string GetFullUserMapPath(string filename)
		{
			string text = filename.EndsWith(StorageUtils.Extension) ? filename : (filename + StorageUtils.Extension);
			string text2 = Marshal.PtrToStringUni(Binding.FCE_Online_GetUplayAccountId());
			string result;
			if (!string.IsNullOrEmpty(text2))
			{
				result = Path.Combine(StorageUtils.UserPath, text2, StorageUtils.UserMapsFolder, text);
			}
			else
			{
				result = Path.Combine(StorageUtils.UserPath, StorageUtils.UserMapsFolder, text);
			}
			return result;
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00014E6C File Offset: 0x0001306C
		public static string GetUserMapPath()
		{
			string text = Marshal.PtrToStringUni(Binding.FCE_Online_GetUplayAccountId());
			string result;
			if (!string.IsNullOrEmpty(text))
			{
				result = Path.Combine(StorageUtils.UserPath, text, StorageUtils.UserMapsFolder);
			}
			else
			{
				result = Path.Combine(StorageUtils.UserPath, StorageUtils.UserMapsFolder);
			}
			return result;
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00014EB8 File Offset: 0x000130B8
		public static string GetFullMapPathForConsole(string filename)
		{
			string text = filename.EndsWith(StorageUtils.Extension) ? filename : (filename + StorageUtils.Extension);
			string text2 = Marshal.PtrToStringUni(Binding.FCE_Online_GetUplayAccountId());
			string result;
			if (!string.IsNullOrEmpty(text2))
			{
				result = Path.Combine(StorageUtils.UserPath, text2, StorageUtils.ExportMapsFolder, text);
			}
			else
			{
				result = Path.Combine(StorageUtils.UserPath, StorageUtils.ExportMapsFolder, text);
			}
			return result;
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00014F20 File Offset: 0x00013120
		public static string GetFullDownloadedMapPath(string filename)
		{
			string text = filename.EndsWith(StorageUtils.Extension) ? filename : (filename + StorageUtils.Extension);
			string text2 = Marshal.PtrToStringUni(Binding.FCE_Online_GetUplayAccountId());
			string result;
			if (!string.IsNullOrEmpty(text2))
			{
				result = Path.Combine(StorageUtils.UserPath, text2, StorageUtils.DownloadMapsFolder, text);
			}
			else
			{
				result = Path.Combine(StorageUtils.UserPath, StorageUtils.DownloadMapsFolder, text);
			}
			return result;
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00014F88 File Offset: 0x00013188
		public static string GetDownloadMapPath()
		{
			string text = Marshal.PtrToStringUni(Binding.FCE_Online_GetUplayAccountId());
			string result;
			if (!string.IsNullOrEmpty(text))
			{
				result = Path.Combine(StorageUtils.UserPath, text, StorageUtils.DownloadMapsFolder);
			}
			else
			{
				result = Path.Combine(StorageUtils.UserPath, StorageUtils.DownloadMapsFolder);
			}
			return result;
		}

		// Token: 0x04000252 RID: 594
		public static readonly string Extension = ".fc4map";

		// Token: 0x04000253 RID: 595
		public static readonly string ExtensionFilter = "*.fc4map";

		// Token: 0x04000254 RID: 596
		public static readonly string UserMapsFolder = "user maps";

		// Token: 0x04000255 RID: 597
		public static readonly string ExportMapsFolder = "export maps";

		// Token: 0x04000256 RID: 598
		public static readonly string DownloadMapsFolder = "download maps";

		// Token: 0x04000257 RID: 599
		public static readonly string UserDirectory = "My Games\\Far Cry 4";

		// Token: 0x04000258 RID: 600
		public static readonly string UserPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), StorageUtils.UserDirectory);
	}
}

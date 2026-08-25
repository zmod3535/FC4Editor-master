using System;
using System.Runtime.InteropServices;

namespace IGE.Nomad
{
	// Token: 0x0200037E RID: 894
	internal static class Localizer
	{
		// Token: 0x06001400 RID: 5120 RVA: 0x0002A0B6 File Offset: 0x000282B6
		private static string LocalizeInternal(string section, string key)
		{
			if (!Engine.Initialized)
			{
				return "%" + key;
			}
			return Marshal.PtrToStringUni(Binding.LocalizeText(section, key));
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x0002A0DC File Offset: 0x000282DC
		private static string LocalizeInternal(uint lineId)
		{
			if (!Engine.Initialized)
			{
				return "%" + lineId.ToString();
			}
			return Marshal.PtrToStringUni(Binding.LocalizeTextFromLineId(lineId));
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x0002A107 File Offset: 0x00028307
		public static string Localize(string key, string section = null)
		{
			if (key.StartsWith("*"))
			{
				return null;
			}
			if (!Engine.Initialized)
			{
				return "!DLL_NOT_LOADED";
			}
			return Localizer.LocalizeInternal(section ?? "InGameEditor_PC", key);
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x0002A135 File Offset: 0x00028335
		public static string LocalizeNoUnderscore(string key, string section = null)
		{
			return Localizer.Localize(key, section).Replace("_", "");
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x0002A14D File Offset: 0x0002834D
		public static string LocalizeCommon(string key)
		{
			return Localizer.LocalizeInternal("InGameEditor", key);
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x0002A15A File Offset: 0x0002835A
		public static string LocalizeCommon(uint lineId)
		{
			return Localizer.LocalizeInternal(lineId);
		}
	}
}

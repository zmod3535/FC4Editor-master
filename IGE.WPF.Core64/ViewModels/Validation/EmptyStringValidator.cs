using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Controls;
using IGE.Nomad;

namespace IGE.ViewModels.Validation
{
	// Token: 0x0200001A RID: 26
	public class EmptyStringValidator : ValidationRule
	{
		// Token: 0x060000BD RID: 189 RVA: 0x00002FDC File Offset: 0x000011DC
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string text = value as string;
			if (string.IsNullOrEmpty(text) || text.Trim().Length == 0)
			{
				return new ValidationResult(false, EmptyStringValidator._fieldEmptyMessage);
			}
			if (text.CompareTo(EmptyStringValidator._undefined) == 0 || text.CompareTo(EmptyStringValidator._untitled) == 0 || text.IndexOfAny(Path.GetInvalidFileNameChars()) != -1 || !this.IsASCII(text))
			{
				return new ValidationResult(false, EmptyStringValidator._fieldInvalidTextMessage);
			}
			return new ValidationResult(true, null);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003055 File Offset: 0x00001255
		private bool IsASCII(string text)
		{
			return Encoding.UTF8.GetByteCount(text) == text.Length;
		}

		// Token: 0x04000031 RID: 49
		private static string _undefined = Localizer.Localize("PARAM_UNDEFINED", null);

		// Token: 0x04000032 RID: 50
		private static string _untitled = Localizer.LocalizeCommon("DEFAULT_MAP_NAME");

		// Token: 0x04000033 RID: 51
		private static string _fieldEmptyMessage = Localizer.Localize("DIALOG_VALIDATION_EMPTY_FIELD", "InGameEditor");

		// Token: 0x04000034 RID: 52
		private static string _fieldInvalidTextMessage = Localizer.Localize("DIALOG_VALIDATION_INVALID_TEXT", "InGameEditor");
	}
}

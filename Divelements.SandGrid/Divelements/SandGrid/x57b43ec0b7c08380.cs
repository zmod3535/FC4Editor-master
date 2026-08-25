using System;
using System.ComponentModel;
using System.Globalization;

namespace Divelements.SandGrid
{
	// Token: 0x020000AF RID: 175
	internal class x57b43ec0b7c08380 : TypeConverter
	{
		// Token: 0x060007E1 RID: 2017 RVA: 0x00026550 File Offset: 0x00025550
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0002656C File Offset: 0x0002556C
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				string name = (string)value;
				Type type = typeof(x57b43ec0b7c08380).Assembly.GetType(name);
				if (type != null)
				{
					return type;
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x000265AC File Offset: 0x000255AC
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x000265B0 File Offset: 0x000255B0
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x000265B4 File Offset: 0x000255B4
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new TypeConverter.StandardValuesCollection(new Type[]
			{
				typeof(GridTextBoxEditor),
				typeof(GridComboBoxEditor),
				typeof(GridDateTimeEditor),
				typeof(GridUpDownEditor)
			});
		}
	}
}

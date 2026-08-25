using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x020000B3 RID: 179
	internal class x01480672935e1b10 : ExpandableObjectConverter
	{
		// Token: 0x060007E8 RID: 2024 RVA: 0x00026614 File Offset: 0x00025614
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x00026630 File Offset: 0x00025630
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				if ((string)value == "Windows (Themed)")
				{
					return new WindowsXPRenderer();
				}
				if ((string)value == "Office 2007")
				{
					return new Office2007Renderer();
				}
			}
			return base.ConvertFrom(context, culture, value);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x00026680 File Offset: 0x00025680
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x00026684 File Offset: 0x00025684
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00026688 File Offset: 0x00025688
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new TypeConverter.StandardValuesCollection(new ArrayList
			{
				"Windows (Themed)",
				"Office 2007"
			});
		}
	}
}

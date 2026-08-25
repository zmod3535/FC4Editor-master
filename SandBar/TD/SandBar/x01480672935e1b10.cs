using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace TD.SandBar
{
	// Token: 0x02000074 RID: 116
	internal class x01480672935e1b10 : TypeConverter
	{
		// Token: 0x06000589 RID: 1417 RVA: 0x0001F1A8 File Offset: 0x0001E1A8
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0001F1D0 File Offset: 0x0001E1D0
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				if (value is string)
				{
					return value;
				}
				return value.ToString();
			}
			else
			{
				if (destinationType == typeof(InstanceDescriptor) && value is IToolBarRenderer)
				{
					ConstructorInfo constructor = value.GetType().GetConstructor(Type.EmptyTypes);
					return new InstanceDescriptor(constructor, new object[0], true);
				}
				return base.ConvertTo(context, culture, value, destinationType);
			}
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x0001F23C File Offset: 0x0001E23C
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				string a;
				if ((a = (string)value) != null)
				{
					if (a == "Office 2002")
					{
						return new Office2002Renderer();
					}
					if (a == "Office 2003")
					{
						return new Office2003Renderer();
					}
					if (a == "Whidbey")
					{
						return new WhidbeyRenderer();
					}
					if (a == "Office 2007")
					{
						return new Office2007Renderer();
					}
				}
				return null;
			}
			return base.ConvertFrom(context, culture, value);
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x0001F2B4 File Offset: 0x0001E2B4
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0001F2D0 File Offset: 0x0001E2D0
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0001F2D4 File Offset: 0x0001E2D4
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0001F2D8 File Offset: 0x0001E2D8
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			if (this.x10364107371ea04e == null)
			{
				this.x10364107371ea04e = new TypeConverter.StandardValuesCollection(new string[]
				{
					"Office 2002",
					"Office 2003",
					"Whidbey",
					"Office 2007"
				});
			}
			return this.x10364107371ea04e;
		}

		// Token: 0x0400025B RID: 603
		private TypeConverter.StandardValuesCollection x10364107371ea04e;
	}
}

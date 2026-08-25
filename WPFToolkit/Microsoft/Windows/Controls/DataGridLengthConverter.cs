using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Security;
using MS.Internal;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200006A RID: 106
	public class DataGridLengthConverter : TypeConverter
	{
		// Token: 0x060007BA RID: 1978 RVA: 0x00022824 File Offset: 0x00020A24
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			switch (Type.GetTypeCode(sourceType))
			{
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			case TypeCode.Int64:
			case TypeCode.UInt64:
			case TypeCode.Single:
			case TypeCode.Double:
			case TypeCode.Decimal:
			case TypeCode.String:
				return true;
			}
			return false;
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0002287B File Offset: 0x00020A7B
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || destinationType == typeof(InstanceDescriptor);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0002289C File Offset: 0x00020A9C
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value != null)
			{
				string text = value as string;
				if (text != null)
				{
					return DataGridLengthConverter.ConvertFromString(text, culture);
				}
				double num = Convert.ToDouble(value, culture);
				DataGridLengthUnitType type;
				if (DoubleUtil.IsNaN(num))
				{
					num = 1.0;
					type = DataGridLengthUnitType.Auto;
				}
				else
				{
					type = DataGridLengthUnitType.Pixel;
				}
				if (!double.IsInfinity(num))
				{
					return new DataGridLength(num, type);
				}
			}
			throw base.GetConvertFromException(value);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00022900 File Offset: 0x00020B00
		[SecurityCritical]
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (value != null && value is DataGridLength)
			{
				DataGridLength length = (DataGridLength)value;
				if (destinationType == typeof(string))
				{
					return DataGridLengthConverter.ConvertToString(length, culture);
				}
				if (destinationType == typeof(InstanceDescriptor))
				{
					ConstructorInfo constructor = typeof(DataGridLength).GetConstructor(new Type[]
					{
						typeof(double),
						typeof(DataGridLengthUnitType)
					});
					return new InstanceDescriptor(constructor, new object[]
					{
						length.Value,
						length.UnitType
					});
				}
			}
			throw base.GetConvertToException(value, destinationType);
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x000229C0 File Offset: 0x00020BC0
		internal static string ConvertToString(DataGridLength length, CultureInfo cultureInfo)
		{
			switch (length.UnitType)
			{
			case DataGridLengthUnitType.Auto:
			case DataGridLengthUnitType.SizeToCells:
			case DataGridLengthUnitType.SizeToHeader:
				return length.UnitType.ToString();
			case DataGridLengthUnitType.Star:
				if (!DoubleUtil.IsOne(length.Value))
				{
					return Convert.ToString(length.Value, cultureInfo) + "*";
				}
				return "*";
			}
			return Convert.ToString(length.Value, cultureInfo);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00022A3C File Offset: 0x00020C3C
		private static DataGridLength ConvertFromString(string s, CultureInfo cultureInfo)
		{
			string text = s.Trim().ToLowerInvariant();
			for (int i = 0; i < 3; i++)
			{
				string b = DataGridLengthConverter._unitStrings[i];
				if (text == b)
				{
					return new DataGridLength(1.0, (DataGridLengthUnitType)i);
				}
			}
			double value = 0.0;
			DataGridLengthUnitType dataGridLengthUnitType = DataGridLengthUnitType.Pixel;
			int length = text.Length;
			int num = 0;
			double num2 = 1.0;
			int num3 = DataGridLengthConverter._unitStrings.Length;
			for (int j = 3; j < num3; j++)
			{
				string text2 = DataGridLengthConverter._unitStrings[j];
				if (text.EndsWith(text2, StringComparison.Ordinal))
				{
					num = text2.Length;
					dataGridLengthUnitType = (DataGridLengthUnitType)j;
					break;
				}
			}
			if (num == 0)
			{
				num3 = DataGridLengthConverter._nonStandardUnitStrings.Length;
				for (int k = 0; k < num3; k++)
				{
					string text3 = DataGridLengthConverter._nonStandardUnitStrings[k];
					if (text.EndsWith(text3, StringComparison.Ordinal))
					{
						num = text3.Length;
						num2 = DataGridLengthConverter._pixelUnitFactors[k];
						break;
					}
				}
			}
			if (length == num)
			{
				if (dataGridLengthUnitType == DataGridLengthUnitType.Star)
				{
					value = 1.0;
				}
			}
			else
			{
				string value2 = text.Substring(0, length - num);
				value = Convert.ToDouble(value2, cultureInfo) * num2;
			}
			return new DataGridLength(value, dataGridLengthUnitType);
		}

		// Token: 0x04000274 RID: 628
		private const int NumDescriptiveUnits = 3;

		// Token: 0x04000275 RID: 629
		private static string[] _unitStrings = new string[]
		{
			"auto",
			"px",
			"sizetocells",
			"sizetoheader",
			"*"
		};

		// Token: 0x04000276 RID: 630
		private static string[] _nonStandardUnitStrings = new string[]
		{
			"in",
			"cm",
			"pt"
		};

		// Token: 0x04000277 RID: 631
		private static double[] _pixelUnitFactors = new double[]
		{
			96.0,
			37.79527559055118,
			1.3333333333333333
		};
	}
}

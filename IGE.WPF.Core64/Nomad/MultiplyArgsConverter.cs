using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace IGE.Nomad
{
	// Token: 0x02000107 RID: 263
	public class MultiplyArgsConverter : IMultiValueConverter
	{
		// Token: 0x0600092B RID: 2347 RVA: 0x0001E78C File Offset: 0x0001C98C
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			if (!MultiplyArgsConverter.TypeIsNumerical(targetType))
			{
				return DependencyProperty.UnsetValue;
			}
			return values.Aggregate(1.0, (double acc, object val) => acc * System.Convert.ToDouble(val));
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0001E7EA File Offset: 0x0001C9EA
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			return targetTypes.Select(delegate(Type type)
			{
				if (!type.IsValueType)
				{
					return null;
				}
				return Activator.CreateInstance(type);
			}).ToArray<object>();
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0001E814 File Offset: 0x0001CA14
		private static bool TypeIsNumerical(Type type)
		{
			HashSet<Type> hashSet = new HashSet<Type>
			{
				typeof(short),
				typeof(int),
				typeof(long),
				typeof(float),
				typeof(double)
			};
			return hashSet.Contains(type);
		}
	}
}

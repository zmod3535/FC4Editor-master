using System;
using System.Globalization;
using System.Windows.Data;

namespace IGE.Nomad
{
	// Token: 0x02000106 RID: 262
	public class Vec3ToStrF2 : IValueConverter
	{
		// Token: 0x06000928 RID: 2344 RVA: 0x0001E74C File Offset: 0x0001C94C
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return "Undefined";
			}
			return ((Vec3)value).ToString("F2");
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x0001E775 File Offset: 0x0001C975
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}

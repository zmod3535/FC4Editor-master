using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000049 RID: 73
	[Localizability(LocalizationCategory.NeverLocalize)]
	internal sealed class BooleanToSelectiveScrollingOrientationConverter : IValueConverter
	{
		// Token: 0x060005A0 RID: 1440 RVA: 0x00016404 File Offset: 0x00014604
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool && parameter is SelectiveScrollingOrientation)
			{
				bool flag = (bool)value;
				SelectiveScrollingOrientation selectiveScrollingOrientation = (SelectiveScrollingOrientation)parameter;
				if (flag)
				{
					return selectiveScrollingOrientation;
				}
			}
			return SelectiveScrollingOrientation.Both;
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x0001643F File Offset: 0x0001463F
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace IGE.ViewModels.Behaviours
{
	// Token: 0x0200012A RID: 298
	public class BooleanToVisibilityNoCollapseConverter : IValueConverter
	{
		// Token: 0x06000A6B RID: 2667 RVA: 0x00022593 File Offset: 0x00020793
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((bool)value) ? Visibility.Visible : Visibility.Hidden;
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x000225A6 File Offset: 0x000207A6
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

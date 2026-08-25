using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200002F RID: 47
	[Localizability(LocalizationCategory.NeverLocalize)]
	internal sealed class DataGridHeadersVisibilityToVisibilityConverter : IValueConverter
	{
		// Token: 0x06000280 RID: 640 RVA: 0x00009AF4 File Offset: 0x00007CF4
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = false;
			if (value is DataGridHeadersVisibility && parameter is DataGridHeadersVisibility)
			{
				DataGridHeadersVisibility dataGridHeadersVisibility = (DataGridHeadersVisibility)value;
				DataGridHeadersVisibility dataGridHeadersVisibility2 = (DataGridHeadersVisibility)parameter;
				switch (dataGridHeadersVisibility)
				{
				case DataGridHeadersVisibility.Column:
					flag = (dataGridHeadersVisibility2 == DataGridHeadersVisibility.Column || dataGridHeadersVisibility2 == DataGridHeadersVisibility.None);
					break;
				case DataGridHeadersVisibility.Row:
					flag = (dataGridHeadersVisibility2 == DataGridHeadersVisibility.Row || dataGridHeadersVisibility2 == DataGridHeadersVisibility.None);
					break;
				case DataGridHeadersVisibility.All:
					flag = true;
					break;
				}
			}
			if (targetType == typeof(Visibility))
			{
				return flag ? Visibility.Visible : Visibility.Collapsed;
			}
			return DependencyProperty.UnsetValue;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00009B76 File Offset: 0x00007D76
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200007F RID: 127
	internal static class DateTimeHelper
	{
		// Token: 0x060008DC RID: 2268 RVA: 0x00027EC8 File Offset: 0x000260C8
		public static DateTime? AddDays(DateTime time, int days)
		{
			DateTime? result;
			try
			{
				result = new DateTime?(DateTimeHelper.cal.AddDays(time, days));
			}
			catch (ArgumentException)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00027F08 File Offset: 0x00026108
		public static DateTime? AddMonths(DateTime time, int months)
		{
			DateTime? result;
			try
			{
				result = new DateTime?(DateTimeHelper.cal.AddMonths(time, months));
			}
			catch (ArgumentException)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00027F48 File Offset: 0x00026148
		public static DateTime? AddYears(DateTime time, int years)
		{
			DateTime? result;
			try
			{
				result = new DateTime?(DateTimeHelper.cal.AddYears(time, years));
			}
			catch (ArgumentException)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00027F88 File Offset: 0x00026188
		public static DateTime? SetYear(DateTime date, int year)
		{
			return DateTimeHelper.AddYears(date, year - date.Year);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00027F9C File Offset: 0x0002619C
		public static DateTime? SetYearMonth(DateTime date, DateTime yearMonth)
		{
			DateTime? result = DateTimeHelper.SetYear(date, yearMonth.Year);
			if (result != null)
			{
				result = DateTimeHelper.AddMonths(result.Value, yearMonth.Month - date.Month);
			}
			return result;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00027FE0 File Offset: 0x000261E0
		public static int CompareDays(DateTime dt1, DateTime dt2)
		{
			return DateTime.Compare(DateTimeHelper.DiscardTime(new DateTime?(dt1)).Value, DateTimeHelper.DiscardTime(new DateTime?(dt2)).Value);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00028018 File Offset: 0x00026218
		public static int CompareYearMonth(DateTime dt1, DateTime dt2)
		{
			return (dt1.Year - dt2.Year) * 12 + (dt1.Month - dt2.Month);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0002803C File Offset: 0x0002623C
		public static int DecadeOfDate(DateTime date)
		{
			return date.Year - date.Year % 10;
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00028050 File Offset: 0x00026250
		public static DateTime DiscardDayTime(DateTime d)
		{
			return new DateTime(d.Year, d.Month, 1, 0, 0, 0);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x0002806C File Offset: 0x0002626C
		public static DateTime? DiscardTime(DateTime? d)
		{
			if (d == null)
			{
				return null;
			}
			return new DateTime?(d.Value.Date);
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x000280A0 File Offset: 0x000262A0
		public static int EndOfDecade(DateTime date)
		{
			return DateTimeHelper.DecadeOfDate(date) + 9;
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x000280AB File Offset: 0x000262AB
		public static DateTimeFormatInfo GetCurrentDateFormat()
		{
			return DateTimeHelper.GetDateFormat(CultureInfo.CurrentCulture);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x000280B8 File Offset: 0x000262B8
		internal static CultureInfo GetCulture(FrameworkElement element)
		{
			CultureInfo result;
			if (DependencyPropertyHelper.GetValueSource(element, FrameworkElement.LanguageProperty).BaseValueSource != BaseValueSource.Default)
			{
				result = DateTimeHelper.GetCultureInfo(element);
			}
			else
			{
				result = CultureInfo.CurrentCulture;
			}
			return result;
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x000280EC File Offset: 0x000262EC
		internal static CultureInfo GetCultureInfo(DependencyObject element)
		{
			XmlLanguage xmlLanguage = (XmlLanguage)element.GetValue(FrameworkElement.LanguageProperty);
			CultureInfo result;
			try
			{
				result = xmlLanguage.GetSpecificCulture();
			}
			catch (InvalidOperationException)
			{
				result = CultureInfo.ReadOnly(new CultureInfo("en-us", false));
			}
			return result;
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x00028138 File Offset: 0x00026338
		internal static DateTimeFormatInfo GetDateFormat(CultureInfo culture)
		{
			if (culture.Calendar is GregorianCalendar)
			{
				return culture.DateTimeFormat;
			}
			GregorianCalendar gregorianCalendar = null;
			foreach (Calendar calendar in culture.OptionalCalendars)
			{
				if (calendar is GregorianCalendar)
				{
					if (gregorianCalendar == null)
					{
						gregorianCalendar = (calendar as GregorianCalendar);
					}
					if (((GregorianCalendar)calendar).CalendarType == GregorianCalendarTypes.Localized)
					{
						gregorianCalendar = (calendar as GregorianCalendar);
						break;
					}
				}
			}
			DateTimeFormatInfo dateTimeFormat;
			if (gregorianCalendar == null)
			{
				dateTimeFormat = ((CultureInfo)CultureInfo.InvariantCulture.Clone()).DateTimeFormat;
				dateTimeFormat.Calendar = new GregorianCalendar();
			}
			else
			{
				dateTimeFormat = ((CultureInfo)culture.Clone()).DateTimeFormat;
				dateTimeFormat.Calendar = gregorianCalendar;
			}
			return dateTimeFormat;
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x000281E2 File Offset: 0x000263E2
		public static bool InRange(DateTime date, CalendarDateRange range)
		{
			return DateTimeHelper.InRange(date, range.Start, range.End);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x000281F6 File Offset: 0x000263F6
		public static bool InRange(DateTime date, DateTime start, DateTime end)
		{
			return DateTimeHelper.CompareDays(date, start) > -1 && DateTimeHelper.CompareDays(date, end) < 1;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00028210 File Offset: 0x00026410
		public static string ToDayString(DateTime? date, CultureInfo culture)
		{
			string result = string.Empty;
			DateTimeFormatInfo dateFormat = DateTimeHelper.GetDateFormat(culture);
			if (date != null && dateFormat != null)
			{
				result = date.Value.Day.ToString(dateFormat);
			}
			return result;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00028250 File Offset: 0x00026450
		public static string ToDecadeRangeString(int decade, CultureInfo culture)
		{
			string result = string.Empty;
			DateTimeFormatInfo dateTimeFormat = culture.DateTimeFormat;
			if (dateTimeFormat != null)
			{
				int num = decade + 9;
				result = decade.ToString(dateTimeFormat) + "-" + num.ToString(dateTimeFormat);
			}
			return result;
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00028290 File Offset: 0x00026490
		public static string ToYearMonthPatternString(DateTime? date, CultureInfo culture)
		{
			string result = string.Empty;
			DateTimeFormatInfo dateFormat = DateTimeHelper.GetDateFormat(culture);
			if (date != null && dateFormat != null)
			{
				result = date.Value.ToString(dateFormat.YearMonthPattern, dateFormat);
			}
			return result;
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x000282D0 File Offset: 0x000264D0
		public static string ToYearString(DateTime? date, CultureInfo culture)
		{
			string result = string.Empty;
			DateTimeFormatInfo dateFormat = DateTimeHelper.GetDateFormat(culture);
			if (date != null && dateFormat != null)
			{
				result = date.Value.Year.ToString(dateFormat);
			}
			return result;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00028310 File Offset: 0x00026510
		public static string ToAbbreviatedMonthString(DateTime? date, CultureInfo culture)
		{
			string result = string.Empty;
			DateTimeFormatInfo dateFormat = DateTimeHelper.GetDateFormat(culture);
			if (date != null && dateFormat != null)
			{
				string[] abbreviatedMonthNames = dateFormat.AbbreviatedMonthNames;
				if (abbreviatedMonthNames != null && abbreviatedMonthNames.Length > 0)
				{
					result = abbreviatedMonthNames[(date.Value.Month - 1) % abbreviatedMonthNames.Length];
				}
			}
			return result;
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x00028360 File Offset: 0x00026560
		public static string ToLongDateString(DateTime? date, CultureInfo culture)
		{
			string result = string.Empty;
			DateTimeFormatInfo dateFormat = DateTimeHelper.GetDateFormat(culture);
			if (date != null && dateFormat != null)
			{
				result = date.Value.Date.ToString(dateFormat.LongDatePattern, dateFormat);
			}
			return result;
		}

		// Token: 0x040002BC RID: 700
		private static Calendar cal = new GregorianCalendar();
	}
}

using System;
using System.ComponentModel;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200006F RID: 111
	public sealed class CalendarDateRange : INotifyPropertyChanged
	{
		// Token: 0x060007D4 RID: 2004 RVA: 0x00022E5E File Offset: 0x0002105E
		public CalendarDateRange() : this(DateTime.MinValue, DateTime.MaxValue)
		{
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x00022E70 File Offset: 0x00021070
		public CalendarDateRange(DateTime day) : this(day, day)
		{
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x00022E7A File Offset: 0x0002107A
		public CalendarDateRange(DateTime start, DateTime end)
		{
			this._start = start;
			this._end = end;
		}

		// Token: 0x14000027 RID: 39
		// (add) Token: 0x060007D7 RID: 2007 RVA: 0x00022E90 File Offset: 0x00021090
		// (remove) Token: 0x060007D8 RID: 2008 RVA: 0x00022EA9 File Offset: 0x000210A9
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060007D9 RID: 2009 RVA: 0x00022EC2 File Offset: 0x000210C2
		// (set) Token: 0x060007DA RID: 2010 RVA: 0x00022ED8 File Offset: 0x000210D8
		public DateTime End
		{
			get
			{
				return CalendarDateRange.CoerceEnd(this._start, this._end);
			}
			set
			{
				DateTime dateTime = CalendarDateRange.CoerceEnd(this._start, value);
				if (dateTime != this.End)
				{
					this.OnChanging(new CalendarDateRangeChangingEventArgs(this._start, dateTime));
					this._end = value;
					this.OnPropertyChanged(new PropertyChangedEventArgs("End"));
				}
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x00022F29 File Offset: 0x00021129
		// (set) Token: 0x060007DC RID: 2012 RVA: 0x00022F34 File Offset: 0x00021134
		public DateTime Start
		{
			get
			{
				return this._start;
			}
			set
			{
				if (this._start != value)
				{
					DateTime end = this.End;
					DateTime dateTime = CalendarDateRange.CoerceEnd(value, this._end);
					this.OnChanging(new CalendarDateRangeChangingEventArgs(value, dateTime));
					this._start = value;
					this.OnPropertyChanged(new PropertyChangedEventArgs("Start"));
					if (dateTime != end)
					{
						this.OnPropertyChanged(new PropertyChangedEventArgs("End"));
					}
				}
			}
		}

		// Token: 0x14000028 RID: 40
		// (add) Token: 0x060007DD RID: 2013 RVA: 0x00022FA0 File Offset: 0x000211A0
		// (remove) Token: 0x060007DE RID: 2014 RVA: 0x00022FB9 File Offset: 0x000211B9
		internal event EventHandler<CalendarDateRangeChangingEventArgs> Changing;

		// Token: 0x060007DF RID: 2015 RVA: 0x00022FD2 File Offset: 0x000211D2
		internal bool ContainsAny(CalendarDateRange range)
		{
			return range.End >= this.Start && this.End >= range.Start;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x00022FFC File Offset: 0x000211FC
		private void OnChanging(CalendarDateRangeChangingEventArgs e)
		{
			EventHandler<CalendarDateRangeChangingEventArgs> changing = this.Changing;
			if (changing != null)
			{
				changing(this, e);
			}
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0002301C File Offset: 0x0002121C
		private void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
			{
				propertyChanged(this, e);
			}
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0002303B File Offset: 0x0002123B
		private static DateTime CoerceEnd(DateTime start, DateTime end)
		{
			if (DateTime.Compare(start, end) > 0)
			{
				return start;
			}
			return end;
		}

		// Token: 0x0400027F RID: 639
		private DateTime _end;

		// Token: 0x04000280 RID: 640
		private DateTime _start;
	}
}

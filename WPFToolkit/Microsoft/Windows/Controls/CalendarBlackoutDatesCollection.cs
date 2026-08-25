using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000042 RID: 66
	public sealed class CalendarBlackoutDatesCollection : ObservableCollection<CalendarDateRange>
	{
		// Token: 0x060004DB RID: 1243 RVA: 0x0001325E File Offset: 0x0001145E
		public CalendarBlackoutDatesCollection(Calendar owner)
		{
			this._owner = owner;
			this._dispatcherThread = Thread.CurrentThread;
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00013278 File Offset: 0x00011478
		public void AddDatesInPast()
		{
			base.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Today.AddDays(-1.0)));
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x000132AB File Offset: 0x000114AB
		public bool Contains(DateTime date)
		{
			return null != this.GetContainingDateRange(date);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x000132BC File Offset: 0x000114BC
		public bool Contains(DateTime start, DateTime end)
		{
			int count = base.Count;
			DateTime value;
			DateTime value2;
			if (DateTime.Compare(end, start) > -1)
			{
				value = DateTimeHelper.DiscardTime(new DateTime?(start)).Value;
				value2 = DateTimeHelper.DiscardTime(new DateTime?(end)).Value;
			}
			else
			{
				value = DateTimeHelper.DiscardTime(new DateTime?(end)).Value;
				value2 = DateTimeHelper.DiscardTime(new DateTime?(start)).Value;
			}
			for (int i = 0; i < count; i++)
			{
				if (DateTime.Compare(base[i].Start, value) == 0 && DateTime.Compare(base[i].End, value2) == 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060004DF RID: 1247 RVA: 0x00013368 File Offset: 0x00011568
		public bool ContainsAny(CalendarDateRange range)
		{
			foreach (CalendarDateRange calendarDateRange in this)
			{
				if (calendarDateRange.ContainsAny(range))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060004E0 RID: 1248 RVA: 0x000133BC File Offset: 0x000115BC
		internal DateTime? GetNonBlackoutDate(DateTime? requestedDate, int dayInterval)
		{
			DateTime? result = requestedDate;
			if (requestedDate == null)
			{
				return null;
			}
			CalendarDateRange containingDateRange;
			if ((containingDateRange = this.GetContainingDateRange(result.Value)) == null)
			{
				return requestedDate;
			}
			do
			{
				if (dayInterval > 0)
				{
					result = DateTimeHelper.AddDays(containingDateRange.End, dayInterval);
				}
				else
				{
					result = DateTimeHelper.AddDays(containingDateRange.Start, dayInterval);
				}
			}
			while (result != null && (containingDateRange = this.GetContainingDateRange(result.Value)) != null);
			return result;
		}

		// Token: 0x060004E1 RID: 1249 RVA: 0x00013430 File Offset: 0x00011630
		protected override void ClearItems()
		{
			if (!this.IsValidThread())
			{
				throw new NotSupportedException(SR.Get(SRID.CalendarCollection_MultiThreadedCollectionChangeNotSupported));
			}
			foreach (CalendarDateRange item in base.Items)
			{
				this.UnRegisterItem(item);
			}
			base.ClearItems();
			this._owner.UpdateCellItems();
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x000134A8 File Offset: 0x000116A8
		protected override void InsertItem(int index, CalendarDateRange item)
		{
			if (!this.IsValidThread())
			{
				throw new NotSupportedException(SR.Get(SRID.CalendarCollection_MultiThreadedCollectionChangeNotSupported));
			}
			if (this.IsValid(item))
			{
				this.RegisterItem(item);
				base.InsertItem(index, item);
				this._owner.UpdateCellItems();
				return;
			}
			throw new ArgumentOutOfRangeException(SR.Get(SRID.Calendar_UnSelectableDates));
		}

		// Token: 0x060004E3 RID: 1251 RVA: 0x00013500 File Offset: 0x00011700
		protected override void RemoveItem(int index)
		{
			if (!this.IsValidThread())
			{
				throw new NotSupportedException(SR.Get(SRID.CalendarCollection_MultiThreadedCollectionChangeNotSupported));
			}
			if (index >= 0 && index < base.Count)
			{
				this.UnRegisterItem(base.Items[index]);
			}
			base.RemoveItem(index);
			this._owner.UpdateCellItems();
		}

		// Token: 0x060004E4 RID: 1252 RVA: 0x00013558 File Offset: 0x00011758
		protected override void SetItem(int index, CalendarDateRange item)
		{
			if (!this.IsValidThread())
			{
				throw new NotSupportedException(SR.Get(SRID.CalendarCollection_MultiThreadedCollectionChangeNotSupported));
			}
			if (this.IsValid(item))
			{
				CalendarDateRange item2 = null;
				if (index >= 0 && index < base.Count)
				{
					item2 = base.Items[index];
				}
				base.SetItem(index, item);
				this.UnRegisterItem(item2);
				this.RegisterItem(base.Items[index]);
				this._owner.UpdateCellItems();
				return;
			}
			throw new ArgumentOutOfRangeException(SR.Get(SRID.Calendar_UnSelectableDates));
		}

		// Token: 0x060004E5 RID: 1253 RVA: 0x000135DE File Offset: 0x000117DE
		private void RegisterItem(CalendarDateRange item)
		{
			if (item != null)
			{
				item.Changing += this.Item_Changing;
				item.PropertyChanged += this.Item_PropertyChanged;
			}
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x00013607 File Offset: 0x00011807
		private void UnRegisterItem(CalendarDateRange item)
		{
			if (item != null)
			{
				item.Changing -= this.Item_Changing;
				item.PropertyChanged -= this.Item_PropertyChanged;
			}
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x00013630 File Offset: 0x00011830
		private void Item_Changing(object sender, CalendarDateRangeChangingEventArgs e)
		{
			CalendarDateRange calendarDateRange = sender as CalendarDateRange;
			if (calendarDateRange != null && !this.IsValid(e.Start, e.End))
			{
				throw new ArgumentOutOfRangeException(SR.Get(SRID.Calendar_UnSelectableDates));
			}
		}

		// Token: 0x060004E8 RID: 1256 RVA: 0x0001366B File Offset: 0x0001186B
		private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender is CalendarDateRange)
			{
				this._owner.UpdateCellItems();
			}
		}

		// Token: 0x060004E9 RID: 1257 RVA: 0x00013680 File Offset: 0x00011880
		private bool IsValid(CalendarDateRange item)
		{
			return this.IsValid(item.Start, item.End);
		}

		// Token: 0x060004EA RID: 1258 RVA: 0x00013694 File Offset: 0x00011894
		private bool IsValid(DateTime start, DateTime end)
		{
			foreach (DateTime dateTime in this._owner.SelectedDates)
			{
				object obj = dateTime;
				if (DateTimeHelper.InRange((obj as DateTime?).Value, start, end))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060004EB RID: 1259 RVA: 0x00013708 File Offset: 0x00011908
		private bool IsValidThread()
		{
			return Thread.CurrentThread == this._dispatcherThread;
		}

		// Token: 0x060004EC RID: 1260 RVA: 0x00013718 File Offset: 0x00011918
		private CalendarDateRange GetContainingDateRange(DateTime date)
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (DateTimeHelper.InRange(date, base[i]))
				{
					return base[i];
				}
			}
			return null;
		}

		// Token: 0x04000161 RID: 353
		private Thread _dispatcherThread;

		// Token: 0x04000162 RID: 354
		private Calendar _owner;
	}
}

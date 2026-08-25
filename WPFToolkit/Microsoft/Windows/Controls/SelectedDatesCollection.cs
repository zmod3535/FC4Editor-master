using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000072 RID: 114
	public sealed class SelectedDatesCollection : ObservableCollection<DateTime>
	{
		// Token: 0x06000801 RID: 2049 RVA: 0x00023928 File Offset: 0x00021B28
		public SelectedDatesCollection(Calendar owner)
		{
			this._dispatcherThread = Thread.CurrentThread;
			this._owner = owner;
			this._addedItems = new Collection<DateTime>();
			this._removedItems = new Collection<DateTime>();
		}

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x00023958 File Offset: 0x00021B58
		internal DateTime? MinimumDate
		{
			get
			{
				if (base.Count < 1)
				{
					return null;
				}
				if (this._minimumDate == null)
				{
					DateTime dateTime = base[0];
					foreach (DateTime dateTime2 in this)
					{
						if (DateTime.Compare(dateTime2, dateTime) < 0)
						{
							dateTime = dateTime2;
						}
					}
					this._maximumDate = new DateTime?(dateTime);
				}
				return this._minimumDate;
			}
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x000239E0 File Offset: 0x00021BE0
		internal DateTime? MaximumDate
		{
			get
			{
				if (base.Count < 1)
				{
					return null;
				}
				if (this._maximumDate == null)
				{
					DateTime dateTime = base[0];
					foreach (DateTime dateTime2 in this)
					{
						if (DateTime.Compare(dateTime2, dateTime) > 0)
						{
							dateTime = dateTime2;
						}
					}
					this._maximumDate = new DateTime?(dateTime);
				}
				return this._maximumDate;
			}
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x00023A68 File Offset: 0x00021C68
		public void AddRange(DateTime start, DateTime end)
		{
			this.BeginAddRange();
			if (this._owner.SelectionMode == CalendarSelectionMode.SingleRange && base.Count > 0)
			{
				this.ClearInternal();
			}
			foreach (DateTime item in SelectedDatesCollection.GetDaysInRange(start, end))
			{
				base.Add(item);
			}
			this.EndAddRange();
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00023AE0 File Offset: 0x00021CE0
		protected override void ClearItems()
		{
			if (!this.IsValidThread())
			{
				throw new NotSupportedException(SR.Get(SRID.CalendarCollection_MultiThreadedCollectionChangeNotSupported));
			}
			this._owner.HoverStart = null;
			this.ClearInternal(true);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00023B20 File Offset: 0x00021D20
		protected override void InsertItem(int index, DateTime item)
		{
			if (!this.IsValidThread())
			{
				throw new NotSupportedException(SR.Get(SRID.CalendarCollection_MultiThreadedCollectionChangeNotSupported));
			}
			if (!base.Contains(item))
			{
				Collection<DateTime> collection = new Collection<DateTime>();
				bool flag = this.CheckSelectionMode();
				if (!Calendar.IsValidDateSelection(this._owner, item))
				{
					throw new ArgumentOutOfRangeException(SR.Get(SRID.Calendar_OnSelectedDateChanged_InvalidValue));
				}
				if (flag)
				{
					index = 0;
				}
				base.InsertItem(index, item);
				this.UpdateMinMax(item);
				if (index == 0 && (this._owner.SelectedDate == null || DateTime.Compare(this._owner.SelectedDate.Value, item) != 0))
				{
					this._owner.SelectedDate = new DateTime?(item);
				}
				if (this._isAddingRange)
				{
					this._addedItems.Add(item);
					return;
				}
				collection.Add(item);
				this.RaiseSelectionChanged(this._removedItems, collection);
				this._removedItems.Clear();
				int num = DateTimeHelper.CompareYearMonth(item, this._owner.DisplayDateInternal);
				if (num < 2 && num > -2)
				{
					this._owner.UpdateCellItems();
					return;
				}
			}
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x00023C3C File Offset: 0x00021E3C
		protected override void RemoveItem(int index)
		{
			if (!this.IsValidThread())
			{
				throw new NotSupportedException(SR.Get(SRID.CalendarCollection_MultiThreadedCollectionChangeNotSupported));
			}
			if (index >= base.Count)
			{
				base.RemoveItem(index);
				this.ClearMinMax();
				return;
			}
			Collection<DateTime> addedItems = new Collection<DateTime>();
			Collection<DateTime> collection = new Collection<DateTime>();
			int num = DateTimeHelper.CompareYearMonth(base[index], this._owner.DisplayDateInternal);
			collection.Add(base[index]);
			base.RemoveItem(index);
			this.ClearMinMax();
			if (index == 0)
			{
				if (base.Count > 0)
				{
					this._owner.SelectedDate = new DateTime?(base[0]);
				}
				else
				{
					this._owner.SelectedDate = null;
				}
			}
			this.RaiseSelectionChanged(collection, addedItems);
			if (num < 2 && num > -2)
			{
				this._owner.UpdateCellItems();
			}
		}

		// Token: 0x06000808 RID: 2056 RVA: 0x00023D0C File Offset: 0x00021F0C
		protected override void SetItem(int index, DateTime item)
		{
			if (!this.IsValidThread())
			{
				throw new NotSupportedException(SR.Get(SRID.CalendarCollection_MultiThreadedCollectionChangeNotSupported));
			}
			if (!base.Contains(item))
			{
				Collection<DateTime> collection = new Collection<DateTime>();
				Collection<DateTime> collection2 = new Collection<DateTime>();
				if (index >= base.Count)
				{
					base.SetItem(index, item);
					this.UpdateMinMax(item);
					return;
				}
				if (DateTime.Compare(base[index], item) != 0 && Calendar.IsValidDateSelection(this._owner, item))
				{
					collection2.Add(base[index]);
					base.SetItem(index, item);
					this.UpdateMinMax(item);
					collection.Add(item);
					if (index == 0 && (this._owner.SelectedDate == null || DateTime.Compare(this._owner.SelectedDate.Value, item) != 0))
					{
						this._owner.SelectedDate = new DateTime?(item);
					}
					this.RaiseSelectionChanged(collection2, collection);
					int num = DateTimeHelper.CompareYearMonth(item, this._owner.DisplayDateInternal);
					if (num < 2 && num > -2)
					{
						this._owner.UpdateCellItems();
					}
				}
			}
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x00023E20 File Offset: 0x00022020
		internal void AddRangeInternal(DateTime start, DateTime end)
		{
			this.BeginAddRange();
			DateTime currentDate = start;
			foreach (DateTime dateTime in SelectedDatesCollection.GetDaysInRange(start, end))
			{
				if (Calendar.IsValidDateSelection(this._owner, dateTime))
				{
					base.Add(dateTime);
					currentDate = dateTime;
				}
				else if (this._owner.SelectionMode == CalendarSelectionMode.SingleRange)
				{
					this._owner.CurrentDate = currentDate;
					break;
				}
			}
			this.EndAddRange();
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x00023EB0 File Offset: 0x000220B0
		internal void ClearInternal()
		{
			this.ClearInternal(false);
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x00023EBC File Offset: 0x000220BC
		internal void ClearInternal(bool fireChangeNotification)
		{
			if (base.Count > 0)
			{
				foreach (DateTime item in this)
				{
					this._removedItems.Add(item);
				}
				base.ClearItems();
				this.ClearMinMax();
				if (fireChangeNotification)
				{
					if (this._owner.SelectedDate != null)
					{
						this._owner.SelectedDate = null;
					}
					if (this._removedItems.Count > 0)
					{
						Collection<DateTime> addedItems = new Collection<DateTime>();
						this.RaiseSelectionChanged(this._removedItems, addedItems);
						this._removedItems.Clear();
					}
					this._owner.UpdateCellItems();
				}
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00023F88 File Offset: 0x00022188
		internal void Toggle(DateTime date)
		{
			if (Calendar.IsValidDateSelection(this._owner, date))
			{
				switch (this._owner.SelectionMode)
				{
				case CalendarSelectionMode.SingleDate:
					if (this._owner.SelectedDate == null || DateTimeHelper.CompareDays(this._owner.SelectedDate.Value, date) != 0)
					{
						this._owner.SelectedDate = new DateTime?(date);
						return;
					}
					this._owner.SelectedDate = null;
					return;
				case CalendarSelectionMode.SingleRange:
					break;
				case CalendarSelectionMode.MultipleRange:
					if (!base.Remove(date))
					{
						base.Add(date);
					}
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00024031 File Offset: 0x00022231
		private void RaiseSelectionChanged(IList removedItems, IList addedItems)
		{
			this._owner.OnSelectedDatesCollectionChanged(new CalendarSelectionChangedEventArgs(Calendar.SelectedDatesChangedEvent, removedItems, addedItems));
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0002404A File Offset: 0x0002224A
		private void BeginAddRange()
		{
			this._isAddingRange = true;
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x00024053 File Offset: 0x00022253
		private void EndAddRange()
		{
			this._isAddingRange = false;
			this.RaiseSelectionChanged(this._removedItems, this._addedItems);
			this._removedItems.Clear();
			this._addedItems.Clear();
			this._owner.UpdateCellItems();
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00024090 File Offset: 0x00022290
		private bool CheckSelectionMode()
		{
			if (this._owner.SelectionMode == CalendarSelectionMode.None)
			{
				throw new InvalidOperationException(SR.Get(SRID.Calendar_OnSelectedDateChanged_InvalidOperation));
			}
			if (this._owner.SelectionMode == CalendarSelectionMode.SingleDate && base.Count > 0)
			{
				throw new InvalidOperationException(SR.Get(SRID.Calendar_CheckSelectionMode_InvalidOperation));
			}
			if (this._owner.SelectionMode == CalendarSelectionMode.SingleRange && !this._isAddingRange && base.Count > 0)
			{
				this.ClearInternal();
				return true;
			}
			return false;
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00024109 File Offset: 0x00022309
		private bool IsValidThread()
		{
			return Thread.CurrentThread == this._dispatcherThread;
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00024118 File Offset: 0x00022318
		private void UpdateMinMax(DateTime date)
		{
			if (this._maximumDate == null || date > this._maximumDate.Value)
			{
				this._maximumDate = new DateTime?(date);
			}
			if (this._minimumDate == null || date < this._minimumDate.Value)
			{
				this._minimumDate = new DateTime?(date);
			}
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x0002417D File Offset: 0x0002237D
		private void ClearMinMax()
		{
			this._maximumDate = null;
			this._minimumDate = null;
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x000242F8 File Offset: 0x000224F8
		private static IEnumerable<DateTime> GetDaysInRange(DateTime start, DateTime end)
		{
			int increment = SelectedDatesCollection.GetDirection(start, end);
			DateTime? rangeStart = new DateTime?(start);
			do
			{
				yield return rangeStart.Value;
				rangeStart = DateTimeHelper.AddDays(rangeStart.Value, increment);
			}
			while (rangeStart != null && DateTime.Compare(end, rangeStart.Value) != -increment);
			yield break;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0002431C File Offset: 0x0002251C
		private static int GetDirection(DateTime start, DateTime end)
		{
			if (DateTime.Compare(end, start) < 0)
			{
				return -1;
			}
			return 1;
		}

		// Token: 0x04000286 RID: 646
		private Collection<DateTime> _addedItems;

		// Token: 0x04000287 RID: 647
		private Collection<DateTime> _removedItems;

		// Token: 0x04000288 RID: 648
		private Thread _dispatcherThread;

		// Token: 0x04000289 RID: 649
		private bool _isAddingRange;

		// Token: 0x0400028A RID: 650
		private Calendar _owner;

		// Token: 0x0400028B RID: 651
		private DateTime? _maximumDate;

		// Token: 0x0400028C RID: 652
		private DateTime? _minimumDate;
	}
}

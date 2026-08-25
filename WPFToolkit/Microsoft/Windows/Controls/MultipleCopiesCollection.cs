using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000045 RID: 69
	internal class MultipleCopiesCollection : IList, ICollection, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
	{
		// Token: 0x06000553 RID: 1363 RVA: 0x0001558C File Offset: 0x0001378C
		internal MultipleCopiesCollection(object item, int count)
		{
			this.CopiedItem = item;
			this._count = count;
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x000155A4 File Offset: 0x000137A4
		internal void MirrorCollectionChange(NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				this.Insert(e.NewStartingIndex);
				return;
			case NotifyCollectionChangedAction.Remove:
				this.RemoveAt(e.OldStartingIndex);
				return;
			case NotifyCollectionChangedAction.Replace:
				this.OnReplace(this.CopiedItem, this.CopiedItem, e.NewStartingIndex);
				return;
			case NotifyCollectionChangedAction.Move:
				this.Move(e.OldStartingIndex, e.NewStartingIndex);
				return;
			case NotifyCollectionChangedAction.Reset:
				this.Reset();
				return;
			default:
				return;
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00015620 File Offset: 0x00013820
		internal void SyncToCount(int newCount)
		{
			int repeatCount = this.RepeatCount;
			if (newCount != repeatCount)
			{
				if (newCount > repeatCount)
				{
					this.InsertRange(repeatCount, newCount - repeatCount);
					return;
				}
				int num = repeatCount - newCount;
				this.RemoveRange(repeatCount - num, num);
			}
		}

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000556 RID: 1366 RVA: 0x00015655 File Offset: 0x00013855
		// (set) Token: 0x06000557 RID: 1367 RVA: 0x00015660 File Offset: 0x00013860
		internal object CopiedItem
		{
			get
			{
				return this._item;
			}
			set
			{
				if (value == CollectionView.NewItemPlaceholder)
				{
					value = DataGrid.NewItemPlaceholder;
				}
				if (this._item != value)
				{
					object item = this._item;
					this._item = value;
					this.OnPropertyChanged("Item[]");
					for (int i = 0; i < this._count; i++)
					{
						this.OnReplace(item, this._item, i);
					}
				}
			}
		}

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x000156BD File Offset: 0x000138BD
		// (set) Token: 0x06000559 RID: 1369 RVA: 0x000156C5 File Offset: 0x000138C5
		private int RepeatCount
		{
			get
			{
				return this._count;
			}
			set
			{
				if (this._count != value)
				{
					this._count = value;
					this.OnPropertyChanged("Count");
					this.OnPropertyChanged("Item[]");
				}
			}
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x000156ED File Offset: 0x000138ED
		private void Insert(int index)
		{
			this.RepeatCount++;
			this.OnCollectionChanged(NotifyCollectionChangedAction.Add, this.CopiedItem, index);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0001570C File Offset: 0x0001390C
		private void InsertRange(int index, int count)
		{
			for (int i = 0; i < count; i++)
			{
				this.Insert(index);
				index++;
			}
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x00015731 File Offset: 0x00013931
		private void Move(int oldIndex, int newIndex)
		{
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Move, this.CopiedItem, newIndex, oldIndex));
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x00015747 File Offset: 0x00013947
		private void RemoveAt(int index)
		{
			this.RepeatCount--;
			this.OnCollectionChanged(NotifyCollectionChangedAction.Remove, this.CopiedItem, index);
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00015768 File Offset: 0x00013968
		private void RemoveRange(int index, int count)
		{
			for (int i = 0; i < count; i++)
			{
				this.RemoveAt(index);
			}
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00015788 File Offset: 0x00013988
		private void OnReplace(object oldItem, object newItem, int index)
		{
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItem, oldItem, index));
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00015799 File Offset: 0x00013999
		private void Reset()
		{
			this.RepeatCount = 0;
			this.OnCollectionReset();
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x000157A8 File Offset: 0x000139A8
		public int Add(object value)
		{
			throw new NotSupportedException(SR.Get(SRID.DataGrid_ReadonlyCellsItemsSource));
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x000157B9 File Offset: 0x000139B9
		public void Clear()
		{
			throw new NotSupportedException(SR.Get(SRID.DataGrid_ReadonlyCellsItemsSource));
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x000157CA File Offset: 0x000139CA
		public bool Contains(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return this._item == value;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x000157E3 File Offset: 0x000139E3
		public int IndexOf(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this._item != value)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x000157FF File Offset: 0x000139FF
		public void Insert(int index, object value)
		{
			throw new NotSupportedException(SR.Get(SRID.DataGrid_ReadonlyCellsItemsSource));
		}

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x00015810 File Offset: 0x00013A10
		public bool IsFixedSize
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000567 RID: 1383 RVA: 0x00015813 File Offset: 0x00013A13
		public bool IsReadOnly
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00015816 File Offset: 0x00013A16
		public void Remove(object value)
		{
			throw new NotSupportedException(SR.Get(SRID.DataGrid_ReadonlyCellsItemsSource));
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00015827 File Offset: 0x00013A27
		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException(SR.Get(SRID.DataGrid_ReadonlyCellsItemsSource));
		}

		// Token: 0x1700014B RID: 331
		public object this[int index]
		{
			get
			{
				if (index >= 0 && index < this.RepeatCount)
				{
					return this._item;
				}
				throw new ArgumentOutOfRangeException("index");
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0001585F File Offset: 0x00013A5F
		public void CopyTo(Array array, int index)
		{
			throw new NotSupportedException();
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600056D RID: 1389 RVA: 0x00015866 File Offset: 0x00013A66
		public int Count
		{
			get
			{
				return this.RepeatCount;
			}
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x0001586E File Offset: 0x00013A6E
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600056F RID: 1391 RVA: 0x00015871 File Offset: 0x00013A71
		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x00015874 File Offset: 0x00013A74
		public IEnumerator GetEnumerator()
		{
			return new MultipleCopiesCollection.MultipleCopiesCollectionEnumerator(this);
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000571 RID: 1393 RVA: 0x0001587C File Offset: 0x00013A7C
		// (remove) Token: 0x06000572 RID: 1394 RVA: 0x00015895 File Offset: 0x00013A95
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		// Token: 0x06000573 RID: 1395 RVA: 0x000158AE File Offset: 0x00013AAE
		private void OnCollectionChanged(NotifyCollectionChangedAction action, object item, int index)
		{
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(action, item, index));
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x000158BE File Offset: 0x00013ABE
		private void OnCollectionReset()
		{
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x000158CC File Offset: 0x00013ACC
		private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			if (this.CollectionChanged != null)
			{
				this.CollectionChanged(this, e);
			}
		}

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000576 RID: 1398 RVA: 0x000158E3 File Offset: 0x00013AE3
		// (remove) Token: 0x06000577 RID: 1399 RVA: 0x000158FC File Offset: 0x00013AFC
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x06000578 RID: 1400 RVA: 0x00015915 File Offset: 0x00013B15
		private void OnPropertyChanged(string propertyName)
		{
			this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x00015923 File Offset: 0x00013B23
		private void OnPropertyChanged(PropertyChangedEventArgs e)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, e);
			}
		}

		// Token: 0x0400017F RID: 383
		private const string CountName = "Count";

		// Token: 0x04000180 RID: 384
		private const string IndexerName = "Item[]";

		// Token: 0x04000183 RID: 387
		private object _item;

		// Token: 0x04000184 RID: 388
		private int _count;

		// Token: 0x02000046 RID: 70
		private class MultipleCopiesCollectionEnumerator : IEnumerator
		{
			// Token: 0x0600057A RID: 1402 RVA: 0x0001593A File Offset: 0x00013B3A
			public MultipleCopiesCollectionEnumerator(MultipleCopiesCollection collection)
			{
				this._collection = collection;
				this._item = this._collection.CopiedItem;
				this._count = this._collection.RepeatCount;
				this._current = -1;
			}

			// Token: 0x1700014F RID: 335
			// (get) Token: 0x0600057B RID: 1403 RVA: 0x00015972 File Offset: 0x00013B72
			object IEnumerator.Current
			{
				get
				{
					if (this._current < 0)
					{
						return null;
					}
					if (this._current < this._count)
					{
						return this._item;
					}
					throw new InvalidOperationException();
				}
			}

			// Token: 0x0600057C RID: 1404 RVA: 0x0001599C File Offset: 0x00013B9C
			bool IEnumerator.MoveNext()
			{
				if (!this.IsCollectionUnchanged)
				{
					throw new InvalidOperationException();
				}
				int num = this._current + 1;
				if (num < this._count)
				{
					this._current = num;
					return true;
				}
				return false;
			}

			// Token: 0x0600057D RID: 1405 RVA: 0x000159D3 File Offset: 0x00013BD3
			void IEnumerator.Reset()
			{
				if (this.IsCollectionUnchanged)
				{
					this._current = -1;
					return;
				}
				throw new InvalidOperationException();
			}

			// Token: 0x17000150 RID: 336
			// (get) Token: 0x0600057E RID: 1406 RVA: 0x000159EA File Offset: 0x00013BEA
			private bool IsCollectionUnchanged
			{
				get
				{
					return this._collection.RepeatCount == this._count && this._collection.CopiedItem == this._item;
				}
			}

			// Token: 0x04000185 RID: 389
			private object _item;

			// Token: 0x04000186 RID: 390
			private int _count;

			// Token: 0x04000187 RID: 391
			private int _current;

			// Token: 0x04000188 RID: 392
			private MultipleCopiesCollection _collection;
		}
	}
}

using System;
using System.Collections;
using System.Security.Permissions;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000022 RID: 34
	[HostProtection(SecurityAction.LinkDemand, SharedState = true)]
	internal sealed class WeakHashtable : Hashtable
	{
		// Token: 0x06000218 RID: 536 RVA: 0x00008D9D File Offset: 0x00006F9D
		internal WeakHashtable() : base(WeakHashtable._comparer)
		{
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00008DAA File Offset: 0x00006FAA
		public override void Clear()
		{
			base.Clear();
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00008DB2 File Offset: 0x00006FB2
		public override void Remove(object key)
		{
			base.Remove(key);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00008DBB File Offset: 0x00006FBB
		public void SetWeak(object key, object value)
		{
			this.ScavengeKeys();
			this[new WeakHashtable.EqualityWeakReference(key)] = value;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00008DD0 File Offset: 0x00006FD0
		private void ScavengeKeys()
		{
			int count = this.Count;
			if (count == 0)
			{
				return;
			}
			if (this._lastHashCount == 0)
			{
				this._lastHashCount = count;
				return;
			}
			long totalMemory = GC.GetTotalMemory(false);
			if (this._lastGlobalMem == 0L)
			{
				this._lastGlobalMem = totalMemory;
				return;
			}
			float num = (float)(totalMemory - this._lastGlobalMem) / (float)this._lastGlobalMem;
			float num2 = (float)(count - this._lastHashCount) / (float)this._lastHashCount;
			if (num < 0f && num2 >= 0f)
			{
				ArrayList arrayList = null;
				foreach (object obj in this.Keys)
				{
					WeakHashtable.EqualityWeakReference equalityWeakReference = obj as WeakHashtable.EqualityWeakReference;
					if (equalityWeakReference != null && !equalityWeakReference.IsAlive)
					{
						if (arrayList == null)
						{
							arrayList = new ArrayList();
						}
						arrayList.Add(equalityWeakReference);
					}
				}
				if (arrayList != null)
				{
					foreach (object key in arrayList)
					{
						this.Remove(key);
					}
				}
			}
			this._lastGlobalMem = totalMemory;
			this._lastHashCount = count;
		}

		// Token: 0x04000082 RID: 130
		private static IEqualityComparer _comparer = new WeakHashtable.WeakKeyComparer();

		// Token: 0x04000083 RID: 131
		private long _lastGlobalMem;

		// Token: 0x04000084 RID: 132
		private int _lastHashCount;

		// Token: 0x02000023 RID: 35
		private class WeakKeyComparer : IEqualityComparer
		{
			// Token: 0x0600021E RID: 542 RVA: 0x00008F28 File Offset: 0x00007128
			bool IEqualityComparer.Equals(object x, object y)
			{
				if (x == null)
				{
					return y == null;
				}
				if (y == null || x.GetHashCode() != y.GetHashCode())
				{
					return false;
				}
				WeakHashtable.EqualityWeakReference equalityWeakReference = x as WeakHashtable.EqualityWeakReference;
				WeakHashtable.EqualityWeakReference equalityWeakReference2 = y as WeakHashtable.EqualityWeakReference;
				if (equalityWeakReference != null && equalityWeakReference2 != null && !equalityWeakReference2.IsAlive && !equalityWeakReference.IsAlive)
				{
					return true;
				}
				if (equalityWeakReference != null)
				{
					x = equalityWeakReference.Target;
				}
				if (equalityWeakReference2 != null)
				{
					y = equalityWeakReference2.Target;
				}
				return object.ReferenceEquals(x, y);
			}

			// Token: 0x0600021F RID: 543 RVA: 0x00008F93 File Offset: 0x00007193
			int IEqualityComparer.GetHashCode(object obj)
			{
				return obj.GetHashCode();
			}
		}

		// Token: 0x02000024 RID: 36
		private sealed class EqualityWeakReference
		{
			// Token: 0x06000221 RID: 545 RVA: 0x00008FA3 File Offset: 0x000071A3
			internal EqualityWeakReference(object o)
			{
				this._weakRef = new WeakReference(o);
				this._hashCode = o.GetHashCode();
			}

			// Token: 0x1700009D RID: 157
			// (get) Token: 0x06000222 RID: 546 RVA: 0x00008FC3 File Offset: 0x000071C3
			public bool IsAlive
			{
				get
				{
					return this._weakRef.IsAlive;
				}
			}

			// Token: 0x1700009E RID: 158
			// (get) Token: 0x06000223 RID: 547 RVA: 0x00008FD0 File Offset: 0x000071D0
			public object Target
			{
				get
				{
					return this._weakRef.Target;
				}
			}

			// Token: 0x06000224 RID: 548 RVA: 0x00008FDD File Offset: 0x000071DD
			public override bool Equals(object o)
			{
				return o != null && o.GetHashCode() == this._hashCode && (o == this || object.ReferenceEquals(o, this.Target));
			}

			// Token: 0x06000225 RID: 549 RVA: 0x00009009 File Offset: 0x00007209
			public override int GetHashCode()
			{
				return this._hashCode;
			}

			// Token: 0x04000085 RID: 133
			private int _hashCode;

			// Token: 0x04000086 RID: 134
			private WeakReference _weakRef;
		}
	}
}

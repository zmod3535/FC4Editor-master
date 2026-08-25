using System;
using System.Collections.Generic;
using System.Windows;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200006C RID: 108
	internal class DataGridItemAttachedStorage
	{
		// Token: 0x060007C7 RID: 1991 RVA: 0x00022D38 File Offset: 0x00020F38
		public void SetValue(object item, DependencyProperty property, object value)
		{
			Dictionary<DependencyProperty, object> dictionary = this.EnsureItem(item);
			dictionary[property] = value;
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x00022D58 File Offset: 0x00020F58
		public bool TryGetValue(object item, DependencyProperty property, out object value)
		{
			value = null;
			this.EnsureItemStorageMap();
			Dictionary<DependencyProperty, object> dictionary;
			return this._itemStorageMap.TryGetValue(item, out dictionary) && dictionary.TryGetValue(property, out value);
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00022D88 File Offset: 0x00020F88
		public void ClearValue(object item, DependencyProperty property)
		{
			this.EnsureItemStorageMap();
			Dictionary<DependencyProperty, object> dictionary;
			if (this._itemStorageMap.TryGetValue(item, out dictionary))
			{
				dictionary.Remove(property);
			}
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x00022DB3 File Offset: 0x00020FB3
		public void ClearItem(object item)
		{
			this.EnsureItemStorageMap();
			this._itemStorageMap.Remove(item);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x00022DC8 File Offset: 0x00020FC8
		public void Clear()
		{
			this._itemStorageMap = null;
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00022DD1 File Offset: 0x00020FD1
		private void EnsureItemStorageMap()
		{
			if (this._itemStorageMap == null)
			{
				this._itemStorageMap = new Dictionary<object, Dictionary<DependencyProperty, object>>();
			}
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00022DE8 File Offset: 0x00020FE8
		private Dictionary<DependencyProperty, object> EnsureItem(object item)
		{
			this.EnsureItemStorageMap();
			Dictionary<DependencyProperty, object> dictionary;
			if (!this._itemStorageMap.TryGetValue(item, out dictionary))
			{
				dictionary = new Dictionary<DependencyProperty, object>();
				this._itemStorageMap[item] = dictionary;
			}
			return dictionary;
		}

		// Token: 0x04000278 RID: 632
		private Dictionary<object, Dictionary<DependencyProperty, object>> _itemStorageMap;
	}
}

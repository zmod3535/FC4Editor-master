using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using Divelements.SandDock.Resources;

namespace Divelements.SandDock
{
	// Token: 0x0200000D RID: 13
	public class FrameworkElementCollection : IList, ICollection, IEnumerable
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x00034184 File Offset: 0x00032584
		internal FrameworkElementCollection(SplitContainer parent)
		{
			this.xb6a159a84cb992d6 = parent;
			this.x8a0b266419f09a55 = new List<FrameworkElement>();
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000341A0 File Offset: 0x000325A0
		private void x7b5ed99e08e175f2(FrameworkElement x4bbc2c453c470189)
		{
			if (x4bbc2c453c470189 == null)
			{
				throw new ArgumentNullException("element");
			}
			if (!(x4bbc2c453c470189 is WindowGroup) && !(x4bbc2c453c470189 is SplitContainer))
			{
				throw new ArgumentException(Messages.ExceptionInvalidSplitContainerChild, "element");
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000341D0 File Offset: 0x000325D0
		private void x13a9f992a88fa090()
		{
			this.xb6a159a84cb992d6.NotifyChildrenChanging();
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000341E0 File Offset: 0x000325E0
		private void xe62ba5a5b17eaf07()
		{
			this.xb6a159a84cb992d6.NotifyChildrenChanged();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000341F0 File Offset: 0x000325F0
		private void xbd21b80c1f547dc5(FrameworkElement x4bbc2c453c470189)
		{
			this.xb6a159a84cb992d6.AddLogicalChild(x4bbc2c453c470189);
			bool flag = true;
			WindowGroup windowGroup = x4bbc2c453c470189 as WindowGroup;
			if (windowGroup != null)
			{
				flag = windowGroup.Pinned;
			}
			if (flag)
			{
				this.xb6a159a84cb992d6.AddVisualChildInternal(x4bbc2c453c470189);
			}
			if (windowGroup != null)
			{
				DependencyPropertyHelper.GetValueSource(windowGroup, FrameworkElement.StyleProperty);
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0003423C File Offset: 0x0003263C
		private void x520aa4f2f5eb2b41(FrameworkElement x4bbc2c453c470189)
		{
			this.xb6a159a84cb992d6.RemoveLogicalChild(x4bbc2c453c470189);
			bool flag = true;
			WindowGroup windowGroup = x4bbc2c453c470189 as WindowGroup;
			if (windowGroup != null)
			{
				flag = windowGroup.Pinned;
			}
			if (flag)
			{
				this.xb6a159a84cb992d6.RemoveVisualChildInternal(x4bbc2c453c470189);
			}
			if (windowGroup != null)
			{
				windowGroup.ClearValue(WindowGroup.PinnedProperty);
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00034288 File Offset: 0x00032688
		public void Add(FrameworkElement element)
		{
			this.Insert(this.Count, element);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00034298 File Offset: 0x00032698
		public void Remove(FrameworkElement element)
		{
			this.x13a9f992a88fa090();
			this.x520aa4f2f5eb2b41(element);
			this.x8a0b266419f09a55.Remove(element);
			this.xe62ba5a5b17eaf07();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000342BC File Offset: 0x000326BC
		public void RemoveAt(int index)
		{
			this.Remove(this[index]);
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000342CC File Offset: 0x000326CC
		public void Clear()
		{
			this.x13a9f992a88fa090();
			foreach (object obj in this)
			{
				FrameworkElement x4bbc2c453c = (FrameworkElement)obj;
				this.x520aa4f2f5eb2b41(x4bbc2c453c);
			}
			this.x8a0b266419f09a55.Clear();
			this.xe62ba5a5b17eaf07();
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00034344 File Offset: 0x00032744
		public void Insert(int index, FrameworkElement element)
		{
			this.x7b5ed99e08e175f2(element);
			this.x13a9f992a88fa090();
			this.x8a0b266419f09a55.Insert(index, element);
			this.xbd21b80c1f547dc5(element);
			this.xe62ba5a5b17eaf07();
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00034370 File Offset: 0x00032770
		public void CopyTo(Array array, int index)
		{
			this.x8a0b266419f09a55.CopyTo((FrameworkElement[])array, index);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00034384 File Offset: 0x00032784
		public bool Contains(FrameworkElement element)
		{
			return this.x8a0b266419f09a55.Contains(element);
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00034394 File Offset: 0x00032794
		public int IndexOf(FrameworkElement element)
		{
			return this.x8a0b266419f09a55.IndexOf(element);
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x000343A4 File Offset: 0x000327A4
		public int Count
		{
			get
			{
				return this.x8a0b266419f09a55.Count;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x000343B4 File Offset: 0x000327B4
		public bool IsSynchronized
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x000343B8 File Offset: 0x000327B8
		public object SyncRoot
		{
			get
			{
				return this;
			}
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000343BC File Offset: 0x000327BC
		public IEnumerator GetEnumerator()
		{
			return this.x8a0b266419f09a55.GetEnumerator();
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x000343D0 File Offset: 0x000327D0
		int IList.xae8b83d75f3358b9(object xbcea506a33cf9111)
		{
			this.Add(xbcea506a33cf9111 as FrameworkElement);
			return 0;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000343E0 File Offset: 0x000327E0
		bool IList.x6532c18338cc2620(object xbcea506a33cf9111)
		{
			return this.Contains(xbcea506a33cf9111 as FrameworkElement);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000343F0 File Offset: 0x000327F0
		int IList.x104b91678c6b7dff(object xbcea506a33cf9111)
		{
			return this.IndexOf(xbcea506a33cf9111 as FrameworkElement);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00034400 File Offset: 0x00032800
		void IList.x87c211383e3062d5(int xc0c4c459c6ccbd00, object xbcea506a33cf9111)
		{
			this.Insert(xc0c4c459c6ccbd00, xbcea506a33cf9111 as FrameworkElement);
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00034410 File Offset: 0x00032810
		bool IList.xe4fa55b25bbd2be4
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00034414 File Offset: 0x00032814
		bool IList.xfc2a190cd9d7a9e2
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00034418 File Offset: 0x00032818
		void IList.x7d6f7f540d2a814d(object xbcea506a33cf9111)
		{
			this.Remove(xbcea506a33cf9111 as FrameworkElement);
		}

		// Token: 0x17000043 RID: 67
		object IList.this[int xc0c4c459c6ccbd00]
		{
			get
			{
				return this[xc0c4c459c6ccbd00];
			}
			set
			{
			}
		}

		// Token: 0x17000044 RID: 68
		public FrameworkElement this[int index]
		{
			get
			{
				return this.x8a0b266419f09a55[index];
			}
		}

		// Token: 0x0400004B RID: 75
		private SplitContainer xb6a159a84cb992d6;

		// Token: 0x0400004C RID: 76
		private List<FrameworkElement> x8a0b266419f09a55;
	}
}

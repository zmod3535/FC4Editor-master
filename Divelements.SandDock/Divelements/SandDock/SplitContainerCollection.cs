using System;
using System.Collections;
using System.Windows.Media;

namespace Divelements.SandDock
{
	// Token: 0x02000018 RID: 24
	public class SplitContainerCollection : IList, ICollection, IEnumerable
	{
		// Token: 0x060001EB RID: 491 RVA: 0x00037F88 File Offset: 0x00036388
		internal SplitContainerCollection(DockSite parent, Visual visualParent)
		{
			this.xb6a159a84cb992d6 = parent;
			this.x4764ef3cdb9b6828 = new VisualCollection(visualParent);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00037FA4 File Offset: 0x000363A4
		private void xe62ba5a5b17eaf07()
		{
			this.xb6a159a84cb992d6.InvalidateMeasure();
			this.xb6a159a84cb992d6.NotifySplitContainersChanged();
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00037FBC File Offset: 0x000363BC
		private void xbd21b80c1f547dc5(SplitContainer x32a48f2091f0f2d3)
		{
			this.xb6a159a84cb992d6.AddLogicalChild(x32a48f2091f0f2d3);
			WindowGroup.SetTray(x32a48f2091f0f2d3, this.xb6a159a84cb992d6.GetTray(DockSite.GetDock(x32a48f2091f0f2d3)));
			DockableWindow.SetDockSituation(x32a48f2091f0f2d3, DockSituation.Docked);
			x32a48f2091f0f2d3.IsRoot = true;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00037FF0 File Offset: 0x000363F0
		private void x520aa4f2f5eb2b41(SplitContainer x32a48f2091f0f2d3)
		{
			this.xb6a159a84cb992d6.RemoveLogicalChild(x32a48f2091f0f2d3);
			x32a48f2091f0f2d3.ClearValue(WindowGroup.TrayProperty);
			DockableWindow.SetDockSituation(x32a48f2091f0f2d3, DockSituation.None);
			x32a48f2091f0f2d3.IsRoot = false;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00038018 File Offset: 0x00036418
		public int Add(SplitContainer splitContainer)
		{
			this.xbd21b80c1f547dc5(splitContainer);
			int result = this.x4764ef3cdb9b6828.Add(splitContainer);
			this.xe62ba5a5b17eaf07();
			return result;
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00038040 File Offset: 0x00036440
		public void Remove(SplitContainer splitContainer)
		{
			this.x520aa4f2f5eb2b41(splitContainer);
			this.x4764ef3cdb9b6828.Remove(splitContainer);
			this.xe62ba5a5b17eaf07();
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0003805C File Offset: 0x0003645C
		public void RemoveAt(int index)
		{
			this.x520aa4f2f5eb2b41(this[index]);
			this.x4764ef3cdb9b6828.RemoveAt(index);
			this.xe62ba5a5b17eaf07();
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00038080 File Offset: 0x00036480
		public void Clear()
		{
			foreach (object obj in this)
			{
				SplitContainer x32a48f2091f0f2d = (SplitContainer)obj;
				this.x520aa4f2f5eb2b41(x32a48f2091f0f2d);
			}
			this.x4764ef3cdb9b6828.Clear();
			this.xe62ba5a5b17eaf07();
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x000380F4 File Offset: 0x000364F4
		public void Insert(int index, SplitContainer splitContainer)
		{
			this.xbd21b80c1f547dc5(splitContainer);
			this.x4764ef3cdb9b6828.Insert(index, splitContainer);
			this.xe62ba5a5b17eaf07();
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00038110 File Offset: 0x00036510
		public void CopyTo(Array array, int index)
		{
			this.x4764ef3cdb9b6828.CopyTo(array, index);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00038120 File Offset: 0x00036520
		public bool Contains(SplitContainer splitContainer)
		{
			return this.x4764ef3cdb9b6828.Contains(splitContainer);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00038130 File Offset: 0x00036530
		public int IndexOf(SplitContainer splitContainer)
		{
			return this.x4764ef3cdb9b6828.IndexOf(splitContainer);
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x00038140 File Offset: 0x00036540
		public int Count
		{
			get
			{
				return this.x4764ef3cdb9b6828.Count;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00038150 File Offset: 0x00036550
		public bool IsSynchronized
		{
			get
			{
				return this.x4764ef3cdb9b6828.IsSynchronized;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001F9 RID: 505 RVA: 0x00038160 File Offset: 0x00036560
		public object SyncRoot
		{
			get
			{
				return this.x4764ef3cdb9b6828.SyncRoot;
			}
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00038170 File Offset: 0x00036570
		public IEnumerator GetEnumerator()
		{
			return this.x4764ef3cdb9b6828.GetEnumerator();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00038184 File Offset: 0x00036584
		int IList.xae8b83d75f3358b9(object xbcea506a33cf9111)
		{
			return this.Add(xbcea506a33cf9111 as SplitContainer);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x00038194 File Offset: 0x00036594
		bool IList.x6532c18338cc2620(object xbcea506a33cf9111)
		{
			return this.Contains(xbcea506a33cf9111 as SplitContainer);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x000381A4 File Offset: 0x000365A4
		int IList.x104b91678c6b7dff(object xbcea506a33cf9111)
		{
			return this.IndexOf(xbcea506a33cf9111 as SplitContainer);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x000381B4 File Offset: 0x000365B4
		void IList.x87c211383e3062d5(int xc0c4c459c6ccbd00, object xbcea506a33cf9111)
		{
			this.Insert(xc0c4c459c6ccbd00, xbcea506a33cf9111 as SplitContainer);
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001FF RID: 511 RVA: 0x000381C4 File Offset: 0x000365C4
		bool IList.xe4fa55b25bbd2be4
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000200 RID: 512 RVA: 0x000381C8 File Offset: 0x000365C8
		bool IList.xfc2a190cd9d7a9e2
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000381CC File Offset: 0x000365CC
		void IList.x7d6f7f540d2a814d(object xbcea506a33cf9111)
		{
			this.Remove(xbcea506a33cf9111 as SplitContainer);
		}

		// Token: 0x1700007B RID: 123
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

		// Token: 0x1700007C RID: 124
		public SplitContainer this[int index]
		{
			get
			{
				return this.x4764ef3cdb9b6828[index] as SplitContainer;
			}
		}

		// Token: 0x0400009E RID: 158
		private DockSite xb6a159a84cb992d6;

		// Token: 0x0400009F RID: 159
		private VisualCollection x4764ef3cdb9b6828;
	}
}

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Divelements.SandDock
{
	// Token: 0x0200002F RID: 47
	public class DockingRules
	{
		// Token: 0x060002E7 RID: 743 RVA: 0x0003D2E8 File Offset: 0x0003B6E8
		public DockingRules()
		{
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0003D324 File Offset: 0x0003B724
		public DockingRules(bool allowDock, bool allowTab, bool allowFloat)
		{
			this.AllowDockLeft = allowDock;
			this.AllowDockRight = allowDock;
			this.AllowDockTop = allowDock;
			this.AllowDockBottom = allowDock;
			this.AllowTab = allowTab;
			this.AllowFloat = allowFloat;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0003D394 File Offset: 0x0003B794
		internal void xd5da23b762ce52a2(DockingRules[] x7c92c43084985bae)
		{
			foreach (DockingRules dockingRules in x7c92c43084985bae)
			{
				this.AllowDockLeft = (this.AllowDockLeft && dockingRules.AllowDockLeft);
				this.AllowDockRight = (this.AllowDockRight && dockingRules.AllowDockRight);
				this.AllowDockTop = (this.AllowDockTop && dockingRules.AllowDockTop);
				this.AllowDockBottom = (this.AllowDockBottom && dockingRules.AllowDockBottom);
				this.AllowTab = (this.AllowTab && dockingRules.AllowTab);
				this.AllowFloat = (this.AllowFloat && dockingRules.AllowFloat);
				this.AllowMerge = (this.AllowMerge && dockingRules.AllowMerge);
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002EA RID: 746 RVA: 0x0003D45C File Offset: 0x0003B85C
		// (set) Token: 0x060002EB RID: 747 RVA: 0x0003D464 File Offset: 0x0003B864
		public bool AllowMerge
		{
			get
			{
				return this.xd81a36bac1bd4fad;
			}
			set
			{
				this.xd81a36bac1bd4fad = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002EC RID: 748 RVA: 0x0003D470 File Offset: 0x0003B870
		// (set) Token: 0x060002ED RID: 749 RVA: 0x0003D478 File Offset: 0x0003B878
		public bool AllowDockLeft
		{
			get
			{
				return this.x33b0d41936d07496;
			}
			set
			{
				this.x33b0d41936d07496 = value;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002EE RID: 750 RVA: 0x0003D484 File Offset: 0x0003B884
		// (set) Token: 0x060002EF RID: 751 RVA: 0x0003D48C File Offset: 0x0003B88C
		public bool AllowDockRight
		{
			get
			{
				return this.x608234746b921e23;
			}
			set
			{
				this.x608234746b921e23 = value;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x0003D498 File Offset: 0x0003B898
		// (set) Token: 0x060002F1 RID: 753 RVA: 0x0003D4A0 File Offset: 0x0003B8A0
		public bool AllowDockTop
		{
			get
			{
				return this.x22d61e656653012c;
			}
			set
			{
				this.x22d61e656653012c = value;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x0003D4AC File Offset: 0x0003B8AC
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x0003D4B4 File Offset: 0x0003B8B4
		public bool AllowDockBottom
		{
			get
			{
				return this.xf2ea876cc567e81e;
			}
			set
			{
				this.xf2ea876cc567e81e = value;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x0003D4C0 File Offset: 0x0003B8C0
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x0003D4C8 File Offset: 0x0003B8C8
		public bool AllowTab
		{
			get
			{
				return this.x789b1ef056ebb726;
			}
			set
			{
				this.x789b1ef056ebb726 = value;
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x0003D4D4 File Offset: 0x0003B8D4
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x0003D4DC File Offset: 0x0003B8DC
		public bool AllowFloat
		{
			get
			{
				return this.xadbc8fe70595ade0;
			}
			set
			{
				this.xadbc8fe70595ade0 = value;
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x0003D4E8 File Offset: 0x0003B8E8
		public override string ToString()
		{
			List<string> list = new List<string>();
			if (this.AllowDockTop == this.AllowDockBottom && this.AllowDockBottom == this.AllowDockLeft && this.AllowDockLeft == this.AllowDockRight)
			{
				if (this.AllowDockTop)
				{
					list.Add("Dock");
				}
			}
			else
			{
				if (this.AllowDockTop)
				{
					list.Add("Dock Top");
				}
				if (this.AllowDockLeft)
				{
					list.Add("Dock Left");
				}
				if (this.AllowDockBottom)
				{
					list.Add("Dock Bottom");
				}
				if (this.AllowDockRight)
				{
					list.Add("Dock Right");
				}
			}
			if (this.AllowTab)
			{
				list.Add("Tab");
			}
			if (this.AllowFloat)
			{
				list.Add("Float");
			}
			string separator = CultureInfo.CurrentUICulture.TextInfo.ListSeparator + " ";
			return string.Join(separator, list.ToArray());
		}

		// Token: 0x0400010A RID: 266
		private bool x33b0d41936d07496 = true;

		// Token: 0x0400010B RID: 267
		private bool x608234746b921e23 = true;

		// Token: 0x0400010C RID: 268
		private bool x22d61e656653012c = true;

		// Token: 0x0400010D RID: 269
		private bool xf2ea876cc567e81e = true;

		// Token: 0x0400010E RID: 270
		private bool x789b1ef056ebb726 = true;

		// Token: 0x0400010F RID: 271
		private bool xadbc8fe70595ade0 = true;

		// Token: 0x04000110 RID: 272
		private bool xd81a36bac1bd4fad = true;
	}
}

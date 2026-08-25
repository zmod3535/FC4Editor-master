using System;
using System.ComponentModel;

namespace TD.SandDock
{
	// Token: 0x02000049 RID: 73
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class DockingRules
	{
		// Token: 0x060004E5 RID: 1253 RVA: 0x00026548 File Offset: 0x00025548
		public DockingRules()
		{
		}

		// Token: 0x060004E6 RID: 1254 RVA: 0x0002657C File Offset: 0x0002557C
		public DockingRules(bool allowDock, bool allowTab, bool allowFloat)
		{
			this.AllowDockLeft = allowDock;
			this.AllowDockRight = allowDock;
			do
			{
				this.AllowDockTop = allowDock;
			}
			while (false);
			this.AllowDockBottom = allowDock;
			this.AllowTab = allowTab;
			this.AllowFloat = allowFloat;
		}

		// Token: 0x060004E7 RID: 1255 RVA: 0x000265EC File Offset: 0x000255EC
		internal void xd5da23b762ce52a2(DockingRules[] x7c92c43084985bae)
		{
			if (15 != 0)
			{
				goto IL_A6;
			}
			if (!false)
			{
				goto IL_21;
			}
			IL_0F:
			int num;
			num++;
			IL_13:
			DockingRules dockingRules;
			if (num >= x7c92c43084985bae.Length)
			{
				if (15 == 0)
				{
					goto IL_A6;
				}
				return;
			}
			else
			{
				dockingRules = x7c92c43084985bae[num];
				this.AllowDockLeft = (this.AllowDockLeft && dockingRules.AllowDockLeft);
			}
			IL_21:
			this.AllowDockRight = (this.AllowDockRight && dockingRules.AllowDockRight);
			if (false)
			{
				return;
			}
			IL_3E:
			this.AllowDockTop = (this.AllowDockTop && dockingRules.AllowDockTop);
			this.AllowDockBottom = (this.AllowDockBottom && dockingRules.AllowDockBottom);
			this.AllowTab = (this.AllowTab && dockingRules.AllowTab);
			this.AllowFloat = (this.AllowFloat && dockingRules.AllowFloat);
			goto IL_0F;
			IL_A6:
			num = 0;
			if (!false)
			{
				goto IL_13;
			}
			goto IL_3E;
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x000266CC File Offset: 0x000256CC
		// (set) Token: 0x060004E9 RID: 1257 RVA: 0x000266D4 File Offset: 0x000256D4
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

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x000266E0 File Offset: 0x000256E0
		// (set) Token: 0x060004EB RID: 1259 RVA: 0x000266E8 File Offset: 0x000256E8
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

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x000266F4 File Offset: 0x000256F4
		// (set) Token: 0x060004ED RID: 1261 RVA: 0x000266FC File Offset: 0x000256FC
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

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x00026708 File Offset: 0x00025708
		// (set) Token: 0x060004EF RID: 1263 RVA: 0x00026710 File Offset: 0x00025710
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

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x060004F0 RID: 1264 RVA: 0x0002671C File Offset: 0x0002571C
		// (set) Token: 0x060004F1 RID: 1265 RVA: 0x00026724 File Offset: 0x00025724
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

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x00026730 File Offset: 0x00025730
		// (set) Token: 0x060004F3 RID: 1267 RVA: 0x00026738 File Offset: 0x00025738
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

		// Token: 0x040001C7 RID: 455
		private bool x33b0d41936d07496 = true;

		// Token: 0x040001C8 RID: 456
		private bool x608234746b921e23 = true;

		// Token: 0x040001C9 RID: 457
		private bool x22d61e656653012c = true;

		// Token: 0x040001CA RID: 458
		private bool xf2ea876cc567e81e = true;

		// Token: 0x040001CB RID: 459
		private bool x789b1ef056ebb726 = true;

		// Token: 0x040001CC RID: 460
		private bool xadbc8fe70595ade0 = true;
	}
}

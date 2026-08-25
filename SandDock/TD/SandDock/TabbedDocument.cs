using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x02000060 RID: 96
	public class TabbedDocument : DockControl
	{
		// Token: 0x0600053A RID: 1338 RVA: 0x00027D88 File Offset: 0x00026D88
		public TabbedDocument()
		{
			this.x84eb05aa1ce8e247();
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00027D98 File Offset: 0x00026D98
		public TabbedDocument(SandDockManager manager, Control control, string text) : base(manager, control, text)
		{
			this.x84eb05aa1ce8e247();
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00027DAC File Offset: 0x00026DAC
		private void x84eb05aa1ce8e247()
		{
			if (this.Text.Length == 0)
			{
				this.Text = "Tabbed Document";
			}
			this.CloseAction = DockControlCloseAction.Dispose;
			this.PersistState = false;
			base.SetPositionMetaData(DockSituation.Document);
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00027DDC File Offset: 0x00026DDC
		protected override DockingRules CreateDockingRules()
		{
			return new DockingRules(false, true, false);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00027DE8 File Offset: 0x00026DE8
		public override void Open()
		{
			base.Open(WindowOpenMethod.OnScreenActivate);
		}

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x00027DF4 File Offset: 0x00026DF4
		protected override Size DefaultSize
		{
			get
			{
				return new Size(550, 400);
			}
		}

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x00027E08 File Offset: 0x00026E08
		// (set) Token: 0x06000541 RID: 1345 RVA: 0x00027E10 File Offset: 0x00026E10
		[DefaultValue(typeof(DockControlCloseAction), "Dispose")]
		public override DockControlCloseAction CloseAction
		{
			get
			{
				return base.CloseAction;
			}
			set
			{
				base.CloseAction = value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x00027E1C File Offset: 0x00026E1C
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x00027E24 File Offset: 0x00026E24
		[DefaultValue(false)]
		public override bool PersistState
		{
			get
			{
				return base.PersistState;
			}
			set
			{
				base.PersistState = value;
			}
		}
	}
}

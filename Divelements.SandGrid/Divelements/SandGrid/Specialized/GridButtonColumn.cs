using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000097 RID: 151
	public class GridButtonColumn : GridColumn
	{
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060006D4 RID: 1748 RVA: 0x00022E38 File Offset: 0x00021E38
		// (remove) Token: 0x060006D5 RID: 1749 RVA: 0x00022E54 File Offset: 0x00021E54
		public event EventHandler<GridRowColumnEventArgs> ButtonClicked
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xf7361e7ebc084acc = (EventHandler<GridRowColumnEventArgs>)Delegate.Combine(this.xf7361e7ebc084acc, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xf7361e7ebc084acc = (EventHandler<GridRowColumnEventArgs>)Delegate.Remove(this.xf7361e7ebc084acc, value);
			}
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00022E70 File Offset: 0x00021E70
		public GridButtonColumn(string text, int width) : base(text, width)
		{
			this.CellHorizontalAlignment = StringAlignment.Center;
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00022E84 File Offset: 0x00021E84
		public GridButtonColumn()
		{
			this.CellHorizontalAlignment = StringAlignment.Center;
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00022E94 File Offset: 0x00021E94
		protected internal virtual void OnButtonClicked(GridRowColumnEventArgs e)
		{
			if (this.xf7361e7ebc084acc != null)
			{
				this.xf7361e7ebc084acc(this, e);
			}
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00022EAC File Offset: 0x00021EAC
		public override GridCell CreateCell()
		{
			return new GridButtonCell();
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x00022EB4 File Offset: 0x00021EB4
		// (set) Token: 0x060006DB RID: 1755 RVA: 0x00022EBC File Offset: 0x00021EBC
		[DefaultValue(typeof(StringAlignment), "Center")]
		public override StringAlignment CellHorizontalAlignment
		{
			get
			{
				return base.CellHorizontalAlignment;
			}
			set
			{
				base.CellHorizontalAlignment = value;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x00022EC8 File Offset: 0x00021EC8
		internal override bool xea4c5fde728d3b8e
		{
			get
			{
				return true;
			}
		}

		// Token: 0x040002AD RID: 685
		private EventHandler<GridRowColumnEventArgs> xf7361e7ebc084acc;
	}
}

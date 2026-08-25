using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000099 RID: 153
	public abstract class InteractiveGridCell : GridCell
	{
		// Token: 0x060006E5 RID: 1765 RVA: 0x00023084 File Offset: 0x00022084
		protected override void OnHotChanged()
		{
			base.OnHotChanged();
			if (!base.Hot)
			{
				this.Hover = false;
			}
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x0002309C File Offset: 0x0002209C
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this.DrawButton)
			{
				this.Hover = this.GetButtonBounds().Contains(e.X, e.Y);
			}
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x000230D8 File Offset: 0x000220D8
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.Hover)
			{
				this.Pressed = true;
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x000230F8 File Offset: 0x000220F8
		protected internal override void OnMouseUp(MouseEventArgs e)
		{
			if (this.Pressed)
			{
				this.Pressed = false;
				this.OnClicked();
			}
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00023110 File Offset: 0x00022110
		protected virtual void OnClicked()
		{
			GridButtonColumn gridButtonColumn = base.ParentColumn as GridButtonColumn;
			if (gridButtonColumn != null)
			{
				gridButtonColumn.OnButtonClicked(new GridRowColumnEventArgs(base.ParentRow, base.ParentColumn));
			}
		}

		// Token: 0x060006EA RID: 1770
		protected abstract Rectangle GetButtonBounds();

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x00023144 File Offset: 0x00022144
		// (set) Token: 0x060006EC RID: 1772 RVA: 0x0002314C File Offset: 0x0002214C
		[Description("Indicates whether the button is drawn.")]
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool DrawButton
		{
			get
			{
				return this.x8fce5d890df7b21b;
			}
			set
			{
				if (value != this.x8fce5d890df7b21b)
				{
					this.x8fce5d890df7b21b = value;
					if (!value)
					{
						this.Hover = false;
					}
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x00023170 File Offset: 0x00022170
		// (set) Token: 0x060006EE RID: 1774 RVA: 0x00023178 File Offset: 0x00022178
		[Browsable(false)]
		public bool Hover
		{
			get
			{
				return this.xa411c04e9298113a;
			}
			private set
			{
				if (value != this.Hover)
				{
					this.xa411c04e9298113a = value;
					if (!this.xa411c04e9298113a)
					{
						this.xd35af1b40ce04d50 = false;
					}
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x000231A0 File Offset: 0x000221A0
		// (set) Token: 0x060006F0 RID: 1776 RVA: 0x000231A8 File Offset: 0x000221A8
		[Browsable(false)]
		public bool Pressed
		{
			get
			{
				return this.xd35af1b40ce04d50;
			}
			private set
			{
				if (value != this.Pressed)
				{
					this.xd35af1b40ce04d50 = value;
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x040002AF RID: 687
		private bool xa411c04e9298113a;

		// Token: 0x040002B0 RID: 688
		private bool xd35af1b40ce04d50;

		// Token: 0x040002B1 RID: 689
		private bool x8fce5d890df7b21b = true;
	}
}

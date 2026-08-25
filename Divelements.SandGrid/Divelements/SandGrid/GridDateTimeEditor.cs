using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x0200008E RID: 142
	[ToolboxItem(false)]
	public class GridDateTimeEditor : DateTimePicker, IGridCellEditor
	{
		// Token: 0x06000680 RID: 1664 RVA: 0x0002203C File Offset: 0x0002103C
		public GridDateTimeEditor()
		{
			base.Format = DateTimePickerFormat.Short;
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0002204C File Offset: 0x0002104C
		protected override bool IsInputKey(Keys keyData)
		{
			return ((keyData & Keys.Tab) == Keys.Tab && this.xea3c8343b62caf05 != null && this.xea3c8343b62caf05.SelectionGranularity == SelectionGranularity.Cell) || base.IsInputKey(keyData);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00022078 File Offset: 0x00021078
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (this.xaf05a2aec36f5b1b.FocusedElement != null)
			{
				if (e.KeyCode == Keys.Down && this.xaf05a2aec36f5b1b.x48546f274ac60a66(true, false, true))
				{
					this.xaf05a2aec36f5b1b.FocusedElement.AdvanceFocus(FocusAdvanceDirection.Down);
				}
				if (e.KeyCode == Keys.Up && this.xaf05a2aec36f5b1b.x48546f274ac60a66(true, false, true))
				{
					this.xaf05a2aec36f5b1b.FocusedElement.AdvanceFocus(FocusAdvanceDirection.Up);
				}
				if (e.KeyCode == Keys.Tab && this.xaf05a2aec36f5b1b.x48546f274ac60a66(true, false, true))
				{
					bool flag = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
					this.xaf05a2aec36f5b1b.FocusedElement.AdvanceFocus(flag ? FocusAdvanceDirection.Left : FocusAdvanceDirection.Right);
					GridCell gridCell = this.xaf05a2aec36f5b1b.FocusedElement as GridCell;
					if (gridCell != null)
					{
						this.xaf05a2aec36f5b1b.BeginEdit(gridCell.ParentRow, gridCell.ParentColumn, true);
					}
				}
			}
			base.OnKeyDown(e);
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x00022164 File Offset: 0x00021164
		protected override void OnValueChanged(EventArgs eventargs)
		{
			base.OnValueChanged(eventargs);
			if (!this.xd923a0654aa3a626 && this.xaf05a2aec36f5b1b != null)
			{
				this.xaf05a2aec36f5b1b.EditorDirty = true;
				this.x98c88e18b643e747 = false;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00022190 File Offset: 0x00021190
		BorderStyle IGridCellEditor.x70b35015ecd64e0b
		{
			get
			{
				return BorderStyle.None;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000685 RID: 1669 RVA: 0x00022194 File Offset: 0x00021194
		public int FixedHeight
		{
			get
			{
				return base.PreferredHeight;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000686 RID: 1670 RVA: 0x0002219C File Offset: 0x0002119C
		public Type DesiredType
		{
			get
			{
				return typeof(DateTime);
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x000221A8 File Offset: 0x000211A8
		public void InitializeContext(SandGridBase grid, GridRow row, GridColumn column)
		{
			this.xaf05a2aec36f5b1b = grid;
			this.xea3c8343b62caf05 = row.Grid;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x000221C0 File Offset: 0x000211C0
		public void StartEdit(bool selectAll)
		{
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x000221C4 File Offset: 0x000211C4
		// (set) Token: 0x0600068A RID: 1674 RVA: 0x000221E8 File Offset: 0x000211E8
		public object EditorValue
		{
			get
			{
				if (this.x98c88e18b643e747)
				{
					return this.xea3c8343b62caf05.xb007631a3756fa6f();
				}
				return base.Value;
			}
			set
			{
				this.xd923a0654aa3a626 = true;
				if (value is DateTime)
				{
					base.Value = (DateTime)value;
					this.x98c88e18b643e747 = false;
				}
				else
				{
					this.x98c88e18b643e747 = true;
				}
				this.xd923a0654aa3a626 = false;
			}
		}

		// Token: 0x04000295 RID: 661
		private SandGridBase xaf05a2aec36f5b1b;

		// Token: 0x04000296 RID: 662
		private InnerGrid xea3c8343b62caf05;

		// Token: 0x04000297 RID: 663
		private bool xd923a0654aa3a626;

		// Token: 0x04000298 RID: 664
		private bool x98c88e18b643e747;
	}
}

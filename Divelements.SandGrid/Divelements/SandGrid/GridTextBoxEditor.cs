using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x0200001B RID: 27
	[ToolboxItem(false)]
	public class GridTextBoxEditor : TextBox, IGridCellEditor
	{
		// Token: 0x06000388 RID: 904 RVA: 0x0001527C File Offset: 0x0001427C
		public GridTextBoxEditor()
		{
			this.AutoSize = false;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0001528C File Offset: 0x0001428C
		protected override bool IsInputKey(Keys keyData)
		{
			return ((keyData & Keys.Tab) == Keys.Tab && this.xea3c8343b62caf05 != null && this.xea3c8343b62caf05.SelectionGranularity == SelectionGranularity.Cell) || base.IsInputKey(keyData);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x000152B8 File Offset: 0x000142B8
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			if (!this.xd923a0654aa3a626 && this.xaf05a2aec36f5b1b != null)
			{
				this.xaf05a2aec36f5b1b.EditorDirty = true;
				this.x98c88e18b643e747 = false;
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x000152E4 File Offset: 0x000142E4
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
				if (e.KeyCode != Keys.Right || base.SelectionStart != this.Text.Length)
				{
					goto IL_A4;
				}
				IL_83:
				if (this.xaf05a2aec36f5b1b.x48546f274ac60a66(true, false, true))
				{
					this.xaf05a2aec36f5b1b.FocusedElement.AdvanceFocus(FocusAdvanceDirection.Right);
				}
				IL_A4:
				if (e.KeyCode == Keys.Left && base.SelectionStart == 0 && this.SelectionLength == 0 && this.xaf05a2aec36f5b1b.x48546f274ac60a66(true, false, true))
				{
					this.xaf05a2aec36f5b1b.FocusedElement.AdvanceFocus(FocusAdvanceDirection.Left);
				}
				if (e.KeyCode == Keys.Tab && this.xaf05a2aec36f5b1b.x48546f274ac60a66(true, false, true))
				{
					bool flag = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
					this.xaf05a2aec36f5b1b.FocusedElement.AdvanceFocus(flag ? FocusAdvanceDirection.Left : FocusAdvanceDirection.Right);
					GridCell gridCell = this.xaf05a2aec36f5b1b.FocusedElement as GridCell;
					if (gridCell != null)
					{
						if (-2 == 0)
						{
							goto IL_83;
						}
						this.xaf05a2aec36f5b1b.BeginEdit(gridCell.ParentRow, gridCell.ParentColumn, true);
					}
				}
			}
			base.OnKeyDown(e);
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600038C RID: 908 RVA: 0x00015454 File Offset: 0x00014454
		public int FixedHeight
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00015458 File Offset: 0x00014458
		public Type DesiredType
		{
			get
			{
				return typeof(string);
			}
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00015464 File Offset: 0x00014464
		public void InitializeContext(SandGridBase grid, GridRow row, GridColumn column)
		{
			this.xaf05a2aec36f5b1b = grid;
			this.xea3c8343b62caf05 = row.Grid;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0001547C File Offset: 0x0001447C
		public void StartEdit(bool selectAll)
		{
			if (selectAll)
			{
				base.SelectAll();
				return;
			}
			base.SelectionStart = this.Text.Length;
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0001549C File Offset: 0x0001449C
		// (set) Token: 0x06000391 RID: 913 RVA: 0x000154B8 File Offset: 0x000144B8
		public object EditorValue
		{
			get
			{
				if (this.x98c88e18b643e747)
				{
					return this.xea3c8343b62caf05.xb007631a3756fa6f();
				}
				return this.Text;
			}
			set
			{
				this.xd923a0654aa3a626 = true;
				string text = value as string;
				if (this.xea3c8343b62caf05.xfb724cf23e069ca8(value) || text == null)
				{
					this.Text = "";
					this.x98c88e18b643e747 = true;
				}
				else
				{
					this.Text = text;
					this.x98c88e18b643e747 = false;
				}
				this.xd923a0654aa3a626 = false;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000392 RID: 914 RVA: 0x00015510 File Offset: 0x00014510
		BorderStyle IGridCellEditor.x70b35015ecd64e0b
		{
			get
			{
				return BorderStyle.None;
			}
		}

		// Token: 0x040000F8 RID: 248
		private SandGridBase xaf05a2aec36f5b1b;

		// Token: 0x040000F9 RID: 249
		private InnerGrid xea3c8343b62caf05;

		// Token: 0x040000FA RID: 250
		private bool xd923a0654aa3a626;

		// Token: 0x040000FB RID: 251
		private bool x98c88e18b643e747;
	}
}

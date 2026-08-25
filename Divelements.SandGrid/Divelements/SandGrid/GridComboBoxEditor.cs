using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000095 RID: 149
	[ToolboxItem(false)]
	public class GridComboBoxEditor : ComboBox, IGridCellEditor
	{
		// Token: 0x060006BD RID: 1725 RVA: 0x00022A0C File Offset: 0x00021A0C
		public GridComboBoxEditor()
		{
			base.DropDownStyle = ComboBoxStyle.DropDown;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00022A1C File Offset: 0x00021A1C
		protected override bool IsInputKey(Keys keyData)
		{
			return ((keyData & Keys.Tab) == Keys.Tab && this.xea3c8343b62caf05 != null && this.xea3c8343b62caf05.SelectionGranularity == SelectionGranularity.Cell) || base.IsInputKey(keyData);
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00022A48 File Offset: 0x00021A48
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 522 && !base.DroppedDown)
			{
				return;
			}
			base.WndProc(ref m);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00022A68 File Offset: 0x00021A68
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (this.xaf05a2aec36f5b1b.FocusedElement != null)
			{
				if (e.KeyCode == Keys.Down && this.xaf05a2aec36f5b1b.EndEdit(true, true))
				{
					this.xaf05a2aec36f5b1b.FocusedElement.AdvanceFocus(FocusAdvanceDirection.Down);
				}
				if (e.KeyCode == Keys.Up && this.xaf05a2aec36f5b1b.EndEdit(true, true))
				{
					this.xaf05a2aec36f5b1b.FocusedElement.AdvanceFocus(FocusAdvanceDirection.Up);
				}
				if (e.KeyCode == Keys.Tab && this.xaf05a2aec36f5b1b.EndEdit(true, true))
				{
					bool flag = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
					this.xaf05a2aec36f5b1b.FocusedElement.AdvanceFocus(flag ? FocusAdvanceDirection.Left : FocusAdvanceDirection.Right);
					GridCell gridCell = this.xaf05a2aec36f5b1b.FocusedElement as GridCell;
					if (gridCell != null)
					{
						gridCell.ParentRow.BeginEdit(gridCell.ParentColumn);
					}
				}
			}
			base.OnKeyDown(e);
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00022B4C File Offset: 0x00021B4C
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			if (!this.xd923a0654aa3a626 && this.xaf05a2aec36f5b1b != null)
			{
				this.xaf05a2aec36f5b1b.EditorDirty = true;
				this.x98c88e18b643e747 = false;
			}
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00022B78 File Offset: 0x00021B78
		protected override void OnSelectedValueChanged(EventArgs e)
		{
			base.OnSelectedValueChanged(e);
			if (!this.xd923a0654aa3a626 && this.xaf05a2aec36f5b1b != null)
			{
				this.xaf05a2aec36f5b1b.EditorDirty = true;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x00022BA0 File Offset: 0x00021BA0
		BorderStyle IGridCellEditor.x70b35015ecd64e0b
		{
			get
			{
				return BorderStyle.None;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x00022BA4 File Offset: 0x00021BA4
		public int FixedHeight
		{
			get
			{
				return base.PreferredHeight;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x00022BAC File Offset: 0x00021BAC
		public Type DesiredType
		{
			get
			{
				return typeof(string);
			}
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00022BB8 File Offset: 0x00021BB8
		public void InitializeContext(SandGridBase grid, GridRow row, GridColumn column)
		{
			this.xaf05a2aec36f5b1b = grid;
			this.xea3c8343b62caf05 = row.Grid;
			this.Populate(column.GetSuggestedValues());
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00022BDC File Offset: 0x00021BDC
		public void Populate(NameValuePair[] values)
		{
			base.Items.Clear();
			this.x7382ec8edfd12414 = values;
			if (this.x7382ec8edfd12414 != null)
			{
				foreach (NameValuePair nameValuePair in this.x7382ec8edfd12414)
				{
					base.Items.Add(nameValuePair.Name);
				}
			}
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00022C30 File Offset: 0x00021C30
		public void StartEdit(bool selectAll)
		{
			if (base.DropDownStyle == ComboBoxStyle.DropDown)
			{
				if (selectAll)
				{
					base.SelectAll();
					return;
				}
				base.SelectionStart = this.Text.Length;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x00022C58 File Offset: 0x00021C58
		// (set) Token: 0x060006CA RID: 1738 RVA: 0x00022CC8 File Offset: 0x00021CC8
		public object EditorValue
		{
			get
			{
				if (this.x98c88e18b643e747)
				{
					return this.xea3c8343b62caf05.xb007631a3756fa6f();
				}
				if (this.SelectedIndex == -1)
				{
					return this.Text;
				}
				if (this.x7382ec8edfd12414 != null && this.SelectedIndex < this.x7382ec8edfd12414.Length)
				{
					return this.x7382ec8edfd12414[this.SelectedIndex].Value;
				}
				return base.Items[this.SelectedIndex];
			}
			set
			{
				this.xd923a0654aa3a626 = true;
				string text = value as string;
				if (this.xea3c8343b62caf05.xfb724cf23e069ca8(value) || text == null)
				{
					this.Text = string.Empty;
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

		// Token: 0x040002A5 RID: 677
		private SandGridBase xaf05a2aec36f5b1b;

		// Token: 0x040002A6 RID: 678
		private InnerGrid xea3c8343b62caf05;

		// Token: 0x040002A7 RID: 679
		private bool xd923a0654aa3a626;

		// Token: 0x040002A8 RID: 680
		private bool x98c88e18b643e747;

		// Token: 0x040002A9 RID: 681
		private NameValuePair[] x7382ec8edfd12414;
	}
}

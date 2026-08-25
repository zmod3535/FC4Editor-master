using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Windows.Forms;
using Divelements.SandGrid.Rendering;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x02000011 RID: 17
	[TypeConverter(typeof(x573084d7e82604d4))]
	public class GridRow : FocusableGridElement
	{
		// Token: 0x06000240 RID: 576 RVA: 0x0000EDF4 File Offset: 0x0000DDF4
		public GridRow()
		{
			this.xc1c198fb5a40fecc = new BitArray(32);
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x26d06922b97b4b0f, false);
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x7757e023237c7679, false);
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x389234cc61353606, false);
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x077499efa75bab29, false);
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x149bf25701697822, false);
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x209b579d9584fab7, true);
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.xb9c2fdbad39c60d0, false);
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.xf4e57d58ee4da85f, false);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x0000EE60 File Offset: 0x0000DE60
		public GridRow(string text) : this(text, null)
		{
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000EE6C File Offset: 0x0000DE6C
		public GridRow(string text, Image image) : this()
		{
			GridCell cell = new GridCell(text, image);
			this.Cells.Add(cell);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000EE94 File Offset: 0x0000DE94
		public GridRow(string[] cellText) : this()
		{
			if (cellText == null)
			{
				throw new ArgumentNullException("cellText");
			}
			GridCell[] array = new GridCell[cellText.Length];
			for (int i = 0; i < cellText.Length; i++)
			{
				array[i] = new GridCell(cellText[i]);
			}
			this.Cells.AddRange(array);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000EEE4 File Offset: 0x0000DEE4
		public GridRow(GridCell[] cells) : this()
		{
			if (cells == null)
			{
				throw new ArgumentNullException("cells");
			}
			this.Cells.AddRange(cells);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000EF08 File Offset: 0x0000DF08
		private bool xffcb3098cb15bbec(GridRow.x6e86085849cdace1 x01b557925841ae51)
		{
			return this.xc1c198fb5a40fecc[(int)x01b557925841ae51];
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000EF18 File Offset: 0x0000DF18
		private void x68939192b57c4e95(GridRow.x6e86085849cdace1 x01b557925841ae51, bool xbcea506a33cf9111)
		{
			this.xc1c198fb5a40fecc[(int)x01b557925841ae51] = xbcea506a33cf9111;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x0000EF28 File Offset: 0x0000DF28
		private GridRow x8fbc695e419337cf()
		{
			if (base.Grid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			if (base.Index > 0)
			{
				GridRow xbd1a7bb3c9ba7cff = (this.ParentRow != null) ? this.ParentRow.NestedRows[base.Index - 1] : base.Grid.Rows[base.Index - 1];
				return GridRow.x194adc7ea8a52ece(xbd1a7bb3c9ba7cff);
			}
			if (this.ParentRow != null)
			{
				return this.ParentRow;
			}
			return null;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000EFA8 File Offset: 0x0000DFA8
		internal static GridRow x194adc7ea8a52ece(GridRow xbd1a7bb3c9ba7cff)
		{
			if (xbd1a7bb3c9ba7cff.HasRows && xbd1a7bb3c9ba7cff.Expanded)
			{
				return GridRow.x194adc7ea8a52ece(xbd1a7bb3c9ba7cff.NestedRows[xbd1a7bb3c9ba7cff.NestedRows.Count - 1]);
			}
			return xbd1a7bb3c9ba7cff;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000EFDC File Offset: 0x0000DFDC
		internal GridRow xa4c746a623bbf4f4(bool x6f8284a0946174ac)
		{
			if (base.Grid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			GridRow gridRow = this;
			if (gridRow.HasRows && (!x6f8284a0946174ac || gridRow.Expanded))
			{
				return gridRow.NestedRows[0];
			}
			while (gridRow.ParentRow != null)
			{
				if (gridRow.Index < gridRow.ParentRow.NestedRows.Count - 1)
				{
					return gridRow.ParentRow.NestedRows[gridRow.Index + 1];
				}
				gridRow = gridRow.ParentRow;
			}
			if (gridRow.Index < base.Grid.Rows.Count - 1)
			{
				return base.Grid.Rows[gridRow.Index + 1];
			}
			return null;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000F09C File Offset: 0x0000E09C
		internal GridRow x2cc76ebec5b074e0()
		{
			GridRow gridRow = this;
			while (gridRow != null)
			{
				gridRow = gridRow.xa4c746a623bbf4f4(true);
				if (gridRow != null)
				{
					bool flag = false;
					for (GridRow gridRow2 = gridRow; gridRow2 != null; gridRow2 = gridRow2.ParentRow)
					{
						if (!gridRow2.xe0f8497fba2e6972)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return gridRow;
					}
				}
			}
			return null;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000F0E0 File Offset: 0x0000E0E0
		internal GridRow x92c0e4f64c084ab1()
		{
			GridRow gridRow = this;
			while (gridRow != null)
			{
				gridRow = gridRow.x8fbc695e419337cf();
				if (gridRow != null)
				{
					bool flag = false;
					for (GridRow gridRow2 = gridRow; gridRow2 != null; gridRow2 = gridRow2.ParentRow)
					{
						if (!gridRow2.xe0f8497fba2e6972)
						{
							gridRow = gridRow2;
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						return gridRow;
					}
				}
			}
			return null;
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0000F124 File Offset: 0x0000E124
		internal bool xe0f8497fba2e6972
		{
			get
			{
				return (this.Group == null || this.Group.Expanded) && !this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x26d06922b97b4b0f);
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000F148 File Offset: 0x0000E148
		public void SetFilteredOut(bool value)
		{
			if (value != this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x26d06922b97b4b0f))
			{
				if (value)
				{
					this.x530a591976340ded();
				}
				else if (base.Grid != null)
				{
					base.Grid.x1f12c04eb45e4cc5();
				}
				this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x26d06922b97b4b0f, value);
				if (value)
				{
					this.x0b035f832721de35();
				}
				if (value && base.Grid != null)
				{
					base.Grid.MeasureNeeded();
					return;
				}
				if (!value)
				{
					base.MeasureNeeded();
				}
			}
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000F1B0 File Offset: 0x0000E1B0
		public bool GetFilteredOut()
		{
			return this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x26d06922b97b4b0f);
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000F1BC File Offset: 0x0000E1BC
		public bool BeginEdit()
		{
			if (base.Grid == null || base.Grid.SandGrid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			return this.BeginEdit(base.Grid.PrimaryColumn);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000F1F4 File Offset: 0x0000E1F4
		public bool BeginEdit(GridColumn column)
		{
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			if (base.Grid == null || base.Grid.SandGrid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			return base.Grid.SandGrid.BeginEdit(this, column, true);
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000F248 File Offset: 0x0000E248
		protected internal override void OnEnter()
		{
			base.OnEnter();
			if (base.Grid.xc22134cf4aa6ad3d)
			{
				base.Grid.x0f405f185e70ec01.x02f2c5fc8375d4bf(base.Index);
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000F274 File Offset: 0x0000E274
		protected virtual void OnBeforeExpand(GridRowExpandCollapseEventArgs e)
		{
			if (base.Grid != null && base.Grid.xc22134cf4aa6ad3d && this.ContentsUnknown)
			{
				this.ContentsUnknown = false;
				this.x1ea7b2c9b3c8518f();
			}
			if (base.Grid != null && base.Grid.SandGrid != null)
			{
				base.Grid.SandGrid.OnBeforeExpand(e);
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000F2D4 File Offset: 0x0000E2D4
		private void x1ea7b2c9b3c8518f()
		{
			object[] array;
			string[] array2;
			base.Grid.x0f405f185e70ec01.x86646cc3b2506262(base.Index, out array, out array2);
			for (int i = 0; i < array2.Length; i++)
			{
				NestedGridRow nestedGridRow = new NestedGridRow();
				GridRow.x8d52acf73c77a2b8(base.Grid, nestedGridRow.NestedGrid);
				nestedGridRow.NestedGrid.DataSource = array[i];
				nestedGridRow.Heading = array2[i];
				this.NestedRows.x2252c77099794fa9(nestedGridRow);
			}
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000F344 File Offset: 0x0000E344
		private static void x8d52acf73c77a2b8(InnerGrid xd0eed8a7b5402780, InnerGrid x34f7aaab6f0b47c6)
		{
			x34f7aaab6f0b47c6.SelectionGranularity = xd0eed8a7b5402780.SelectionGranularity;
			x34f7aaab6f0b47c6.ShadeAlternateRows = xd0eed8a7b5402780.ShadeAlternateRows;
			x34f7aaab6f0b47c6.ShowTreeButtons = xd0eed8a7b5402780.ShowTreeButtons;
			x34f7aaab6f0b47c6.ShowTreeLines = xd0eed8a7b5402780.ShowTreeLines;
			x34f7aaab6f0b47c6.GridLines = xd0eed8a7b5402780.GridLines;
			x34f7aaab6f0b47c6.ShowColumnHeaders = xd0eed8a7b5402780.ShowColumnHeaders;
			x34f7aaab6f0b47c6.ShowRowHeaders = xd0eed8a7b5402780.ShowRowHeaders;
			x34f7aaab6f0b47c6.HideSelection = xd0eed8a7b5402780.HideSelection;
			x34f7aaab6f0b47c6.ShowRootLines = xd0eed8a7b5402780.ShowRootLines;
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000F3C0 File Offset: 0x0000E3C0
		internal void x3e3f6c8fa322858b(ExpandCollapseTrigger x195a4b0af9f9e88a)
		{
			GridRowExpandCollapseEventArgs gridRowExpandCollapseEventArgs = new GridRowExpandCollapseEventArgs(this, x195a4b0af9f9e88a);
			this.OnBeforeExpand(gridRowExpandCollapseEventArgs);
			if (!gridRowExpandCollapseEventArgs.Cancel)
			{
				this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x7757e023237c7679, true);
				base.MeasureNeeded();
				this.x530a591976340ded();
				this.OnAfterExpand(new GridRowExpandCollapseEventArgs(this, x195a4b0af9f9e88a));
				if (base.Grid != null && base.Grid.SandGrid != null)
				{
					base.Grid.SandGrid.x5d2e802bd1c8f7d5(this);
				}
			}
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000F42C File Offset: 0x0000E42C
		protected virtual void OnAfterExpand(GridRowExpandCollapseEventArgs e)
		{
			if (base.Grid != null && base.Grid.SandGrid != null)
			{
				base.Grid.SandGrid.OnAfterExpand(e);
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000F454 File Offset: 0x0000E454
		protected virtual void OnBeforeCollapse(GridRowExpandCollapseEventArgs e)
		{
			if (base.Grid != null && base.Grid.SandGrid != null)
			{
				base.Grid.SandGrid.OnBeforeCollapse(e);
			}
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000F47C File Offset: 0x0000E47C
		protected virtual void OnAfterCollapse(GridRowExpandCollapseEventArgs e)
		{
			if (base.Grid != null && base.Grid.SandGrid != null)
			{
				base.Grid.SandGrid.OnAfterCollapse(e);
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000F4A4 File Offset: 0x0000E4A4
		internal void x98ab41ccb801e030(ExpandCollapseTrigger x195a4b0af9f9e88a)
		{
			GridRowExpandCollapseEventArgs gridRowExpandCollapseEventArgs = new GridRowExpandCollapseEventArgs(this, x195a4b0af9f9e88a);
			this.OnBeforeCollapse(gridRowExpandCollapseEventArgs);
			if (!gridRowExpandCollapseEventArgs.Cancel)
			{
				ArrayList arrayList = new ArrayList();
				GridRow gridRow = this;
				while (gridRow != null && (gridRow == this || gridRow.IndentationLevel > this.IndentationLevel))
				{
					arrayList.Add(gridRow);
					gridRow = gridRow.NextVisibleRow;
				}
				foreach (object obj in arrayList)
				{
					GridRow gridRow2 = (GridRow)obj;
					gridRow2.x530a591976340ded();
				}
				this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x7757e023237c7679, false);
				base.MeasureNeeded();
				this.OnAfterCollapse(new GridRowExpandCollapseEventArgs(this, x195a4b0af9f9e88a));
				if (base.Grid != null)
				{
					InnerGrid grid = base.Grid;
					if (this.IsExpansionVisible())
					{
						grid.x5412edcb66c29ec8 = this;
					}
					try
					{
						base.Grid.x614e783eda4ed71f();
						if (this.HasRows)
						{
							foreach (object obj2 in this.NestedRows)
							{
								GridRow gridRow3 = (GridRow)obj2;
								gridRow3.x0b035f832721de35();
							}
						}
						base.Grid.x06727b7d4fe7a302();
					}
					finally
					{
						grid.x5412edcb66c29ec8 = null;
					}
				}
			}
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000F630 File Offset: 0x0000E630
		protected internal override string GetTooltipText(Point position)
		{
			GridColumn columnAt = base.Grid.GetColumnAt(position);
			if (columnAt != null)
			{
				Point point = base.Grid.SandGrid.PointFromGrid(new Point(columnAt.Bounds.X, 0));
				Point point2 = base.Grid.SandGrid.PointFromGrid(new Point(columnAt.Bounds.Right, 0));
				if (point.X < 0 || point2.X > base.Grid.SandGrid.ClientRectangle.Right || columnAt.IsTextOverflowing(this))
				{
					return columnAt.xf69eb59aa621a379(this, this.GetCellValue(columnAt), typeof(string)) as string;
				}
				return string.Empty;
			}
			else
			{
				if (this.HeaderBounds.Contains(position) && base.Grid.xc22134cf4aa6ad3d)
				{
					return base.Grid.x0f405f185e70ec01.x56f6dc80f5dd23e8(base.Index);
				}
				return string.Empty;
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000F738 File Offset: 0x0000E738
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			bool flag = this.HeaderBounds.Contains(e.X, e.Y);
			this.xf4e57d58ee4da85f = flag;
			if (flag && GridElement.x263912479c3c5786 == null)
			{
				if (this.PreviousVisibleRow != null && this.x54eaabec2fd785c7.Contains(e.X, e.Y) && this.PreviousVisibleRow.CanResize())
				{
					Cursor.Current = Cursors.HSplit;
					return;
				}
				if (this.x97c2992f0a853609.Contains(e.X, e.Y) && this.CanResize())
				{
					Cursor.Current = Cursors.HSplit;
				}
			}
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000F7E8 File Offset: 0x0000E7E8
		protected override void OnHotChanged()
		{
			base.OnHotChanged();
			if (!base.Hot)
			{
				this.xf4e57d58ee4da85f = false;
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000F800 File Offset: 0x0000E800
		private void xa68c5feef6d1b80b(MouseEventArgs xfbf34718e704c6bc)
		{
			base.x11f639c5d61688d8(new x0e7ffd31ba56b04f(this, new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y)));
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000F820 File Offset: 0x0000E820
		protected internal virtual bool CanResize()
		{
			return this.Height != 0 && base.Grid != null && base.Grid.AllowRowResize;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000F844 File Offset: 0x0000E844
		protected internal virtual void OnCheckBoxClick(GridRowCheckEventArgs e)
		{
			if (base.Grid != null && base.Grid.SandGrid != null)
			{
				base.Grid.SandGrid.OnBeforeCheck(e);
				if (e.Cancel)
				{
					return;
				}
			}
			this.Checked = !this.Checked;
			if (base.Grid != null && base.Grid.SandGrid != null)
			{
				base.Grid.SandGrid.OnAfterCheck(e);
			}
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000F8B8 File Offset: 0x0000E8B8
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this.xb0b83f15c7318893.Contains(e.X, e.Y))
			{
				if (base.Grid.SandGrid != null && base.Grid.SandGrid.Site != null && base.Grid.SandGrid.Site.DesignMode)
				{
					TypeDescriptor.GetProperties(this)["Expanded"].SetValue(this, !this.Expanded);
				}
				else
				{
					if (this.Expanded)
					{
						this.x98ab41ccb801e030(ExpandCollapseTrigger.ExpandButton);
						return;
					}
					this.x3e3f6c8fa322858b(ExpandCollapseTrigger.ExpandButton);
					return;
				}
			}
			else
			{
				if (e.Button == MouseButtons.Left && base.Grid.CheckBoxes && this.xb889d9c3f565170e.Contains(e.X, e.Y))
				{
					this.OnCheckBoxClick(new GridRowCheckEventArgs(this, CheckTrigger.CheckButton));
					return;
				}
				Rectangle headerBounds;
				if (e.Button == MouseButtons.Left)
				{
					headerBounds = this.HeaderBounds;
					if (-2147483648 == 0)
					{
						return;
					}
					goto IL_129;
				}
				IL_2D:
				base.OnMouseDown(e);
				if (!base.xc82620afa11d4a41)
				{
					return;
				}
				if (e.Button == MouseButtons.Left && base.Grid.RowDragBehavior == RowDragBehavior.ExtendSelection)
				{
					if (base.Grid.AllowMultipleSelection)
					{
						base.x11f639c5d61688d8(new x1297869bdcf7b6a7(this, new Point(e.X, e.Y)));
						return;
					}
					return;
				}
				else
				{
					if (e.Button == MouseButtons.Left && base.Grid.RowDragBehavior == RowDragBehavior.Move)
					{
						if (255 == 0)
						{
							return;
						}
						if (!base.Grid.xc22134cf4aa6ad3d)
						{
							base.x11f639c5d61688d8(new x3068eb9be4cffd01(this, new Point(e.X, e.Y)));
							return;
						}
					}
					if ((e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) || base.Grid.RowDragBehavior != RowDragBehavior.InitiateDragDrop)
					{
						return;
					}
					base.x11f639c5d61688d8(new x40917da28fd6d442(this, new Point(e.X, e.Y)));
					if (!false)
					{
						return;
					}
				}
				IL_129:
				if (!headerBounds.Contains(e.X, e.Y))
				{
					goto IL_2D;
				}
				if (this.x97c2992f0a853609.Contains(e.X, e.Y) && this.CanResize())
				{
					this.xa68c5feef6d1b80b(e);
					return;
				}
				if (this.PreviousVisibleRow == null || !this.x54eaabec2fd785c7.Contains(e.X, e.Y) || !this.PreviousVisibleRow.CanResize())
				{
					goto IL_2D;
				}
				if (true)
				{
					x5d3666f49ba1c366.x76b0eec27bc2d901(this.PreviousVisibleRow);
					this.PreviousVisibleRow.xa68c5feef6d1b80b(e);
					return;
				}
				return;
			}
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000FB80 File Offset: 0x0000EB80
		internal override void x0c44cc8270354ceb(MouseEventArgs xfbf34718e704c6bc)
		{
			GridColumn gridColumn = this.x02563cc724166b66(xfbf34718e704c6bc);
			if (gridColumn != null)
			{
				base.Grid.SandGrid.x4ed3c8af084555d7(this, gridColumn);
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000FBAC File Offset: 0x0000EBAC
		private GridColumn x02563cc724166b66(MouseEventArgs xfbf34718e704c6bc)
		{
			if (base.Grid.RowEditMode == RowEditMode.PrimaryCell)
			{
				return base.Grid.PrimaryColumn;
			}
			foreach (GridColumn gridColumn in base.Grid.Columns.DisplayColumns)
			{
				if (xfbf34718e704c6bc.X >= gridColumn.Bounds.X && xfbf34718e704c6bc.X < gridColumn.Bounds.Right)
				{
					return gridColumn;
				}
			}
			return null;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000FC2C File Offset: 0x0000EC2C
		protected internal override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);
			if (!this.xb0b83f15c7318893.Contains(e.X, e.Y) && !this.HeaderBounds.Contains(e.X, e.Y))
			{
				Rectangle xb889d9c3f565170e = this.xb889d9c3f565170e;
				if (-1 == 0 || xb889d9c3f565170e.Contains(e.X, e.Y))
				{
					return;
				}
				if (this.HasRows || this.ContentsUnknown)
				{
					if (base.Grid.ParentRowDoubleClick != ParentRowDoubleClickBehavior.ExpandCollapse)
					{
						base.Grid.SandGrid.OnRowActivated(new GridRowEventArgs(this));
						return;
					}
					if (this.Expanded)
					{
						this.x98ab41ccb801e030(ExpandCollapseTrigger.DoubleClick);
						return;
					}
					this.x3e3f6c8fa322858b(ExpandCollapseTrigger.DoubleClick);
					return;
				}
				else if (base.Grid.SandGrid.MouseEditing == MouseEditMode.DoubleClick && !base.Grid.SandGrid.EditorActive)
				{
					GridColumn gridColumn = this.x02563cc724166b66(e);
					if (gridColumn != null)
					{
						base.Grid.SandGrid.BeginEdit(this, gridColumn, true);
						return;
					}
				}
				else
				{
					base.Grid.SandGrid.OnRowActivated(new GridRowEventArgs(this));
				}
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000FD48 File Offset: 0x0000ED48
		protected override GridElement GetChildElementAt(Point position)
		{
			if (this.xb0b83f15c7318893.Contains(position) || this.xb889d9c3f565170e.Contains(position))
			{
				return null;
			}
			if (this.HasCells)
			{
				foreach (object obj in this.Cells)
				{
					GridCell gridCell = (GridCell)obj;
					if ((base.Grid.SelectionGranularity == SelectionGranularity.Cell || (gridCell.ParentColumn != null && gridCell.ParentColumn.xea4c5fde728d3b8e)) && gridCell.Bounds.Contains(position) && gridCell.ParentColumn.Visible)
					{
						return gridCell;
					}
				}
			}
			return null;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000FE20 File Offset: 0x0000EE20
		protected override void SelectWithMouseButton(MouseEventArgs e)
		{
			if (base.Grid.SelectionGranularity == SelectionGranularity.Row || this.HeaderBounds.Contains(e.X, e.Y))
			{
				base.SelectWithMouseButton(e);
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000FE60 File Offset: 0x0000EE60
		public override void SelectBlock(FocusableGridElement startElement, FocusableGridElement toElement)
		{
			GridRow gridRow = startElement as GridRow;
			GridRow xa077399e2a = toElement as GridRow;
			if (gridRow != null && toElement != null)
			{
				GridRow.x1aeb71217c698ee3(gridRow, xa077399e2a);
			}
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000FE88 File Offset: 0x0000EE88
		private void xde3931572fde532a(GridRow xbd1a7bb3c9ba7cff, GridRow xa077399e2a038023, bool x9f93ebd2ca5601a2)
		{
			ArrayList arrayList = new ArrayList();
			bool flag = xa077399e2a038023.Bounds.Top > xbd1a7bb3c9ba7cff.Bounds.Top;
			arrayList.Add(xbd1a7bb3c9ba7cff);
			GridRow gridRow = xbd1a7bb3c9ba7cff;
			while (gridRow != xa077399e2a038023)
			{
				gridRow = (gridRow.GetNextElement(flag ? FocusAdvanceDirection.Down : FocusAdvanceDirection.Up) as GridRow);
				if (gridRow == null)
				{
					break;
				}
				arrayList.Add(gridRow);
			}
			xbd1a7bb3c9ba7cff.Grid.x12a83acc7c1ca827(arrayList, x9f93ebd2ca5601a2);
			if (!x9f93ebd2ca5601a2)
			{
				xa077399e2a038023.Selected = true;
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000FF00 File Offset: 0x0000EF00
		internal static GridRow[] x0cec1fc9c22db728(GridRow xbd1a7bb3c9ba7cff, GridRow xa077399e2a038023)
		{
			ArrayList arrayList = new ArrayList();
			bool flag = xa077399e2a038023.Bounds.Top > xbd1a7bb3c9ba7cff.Bounds.Top;
			arrayList.Add(xbd1a7bb3c9ba7cff);
			GridRow gridRow = xbd1a7bb3c9ba7cff;
			while (gridRow != xa077399e2a038023)
			{
				gridRow = (gridRow.GetNextElement(flag ? FocusAdvanceDirection.Down : FocusAdvanceDirection.Up) as GridRow);
				if (gridRow == null)
				{
					break;
				}
				arrayList.Add(gridRow);
			}
			return (GridRow[])arrayList.ToArray(typeof(GridRow));
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000FF78 File Offset: 0x0000EF78
		internal static void x1aeb71217c698ee3(GridRow xbd1a7bb3c9ba7cff, GridRow xa077399e2a038023)
		{
			GridRow[] x6e96c3657c96bbbe = GridRow.x0cec1fc9c22db728(xbd1a7bb3c9ba7cff, xa077399e2a038023);
			xbd1a7bb3c9ba7cff.Grid.x12a83acc7c1ca827(x6e96c3657c96bbbe, true);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000FF9C File Offset: 0x0000EF9C
		protected internal override bool AdvanceFocus(FocusAdvanceDirection direction, FocusAdvanceMethod method, int steps, bool loop)
		{
			bool flag = false;
			for (;;)
			{
				FocusableGridElement focusableGridElement = null;
				if (steps > 0)
				{
					goto IL_19D;
				}
				if (direction == FocusAdvanceDirection.Up)
				{
					focusableGridElement = base.Grid.GetFirstVisibleRow();
				}
				else if (direction == FocusAdvanceDirection.Down)
				{
					focusableGridElement = base.Grid.x92c95e0e04930cdc();
				}
				IL_47:
				if (focusableGridElement == null)
				{
					goto Block_6;
				}
				if (focusableGridElement != this)
				{
					InnerGrid grid = base.Grid;
					grid.x614e783eda4ed71f();
					try
					{
						if (method == FocusAdvanceMethod.IncreaseSelection)
						{
							GridRow gridRow = base.Grid.SandGrid.xf023f44afe4ba919 as GridRow;
							if (gridRow != null)
							{
								if (Math.Abs(gridRow.Bounds.Top - focusableGridElement.Bounds.Top) > 100)
								{
									bool flag2 = focusableGridElement.Bounds.Top > gridRow.Bounds.Top;
									bool flag3 = focusableGridElement.Bounds.Top > base.Bounds.Top;
									this.xde3931572fde532a(this, (GridRow)focusableGridElement, flag2 == flag3);
								}
								else
								{
									base.Grid.SelectedElements.Clear();
									GridRow.x1aeb71217c698ee3(gridRow, (GridRow)focusableGridElement);
								}
							}
							base.Grid.SandGrid.FocusedElement = focusableGridElement;
						}
						else if (method == FocusAdvanceMethod.MoveSelection)
						{
							base.Grid.SelectElement(focusableGridElement);
						}
						else
						{
							base.Grid.SandGrid.FocusedElement = focusableGridElement;
						}
						focusableGridElement.EnsureVisible();
						return true;
					}
					finally
					{
						grid.x06727b7d4fe7a302();
					}
					continue;
				}
				int i;
				if ((uint)steps - (uint)i <= 4294967295U)
				{
					return false;
				}
				IL_19D:
				FocusableGridElement focusableGridElement2 = this;
				for (i = 1; i <= steps; i++)
				{
					focusableGridElement2 = focusableGridElement2.GetNextElement(direction, false, out flag);
					focusableGridElement2 = this.x242b337514d5624c(focusableGridElement2);
					if (flag)
					{
						return false;
					}
					if (focusableGridElement2 == null)
					{
						break;
					}
					focusableGridElement = focusableGridElement2;
				}
				goto IL_47;
			}
			return false;
			Block_6:
			return base.Grid.xc7f76500b5bc2b29(direction);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0001017C File Offset: 0x0000F17C
		public override FocusableGridElement GetNextElement(FocusAdvanceDirection direction, bool loop, out bool layoutAltered)
		{
			layoutAltered = false;
			if (direction == FocusAdvanceDirection.Up)
			{
				return this.PreviousVisibleRow;
			}
			if (direction == FocusAdvanceDirection.Down)
			{
				return this.NextVisibleRow;
			}
			if (direction == FocusAdvanceDirection.Right)
			{
				if (this.HasRows || this.ContentsUnknown)
				{
					if (!this.Expanded)
					{
						this.x3e3f6c8fa322858b(ExpandCollapseTrigger.Keyboard);
						layoutAltered = true;
						return null;
					}
					if (this.HasRows)
					{
						return this.NestedRows[0];
					}
				}
			}
			else if (direction == FocusAdvanceDirection.Left)
			{
				if (this.HasRows && this.Expanded)
				{
					this.x98ab41ccb801e030(ExpandCollapseTrigger.Keyboard);
					layoutAltered = true;
					return null;
				}
				return this.ParentRow;
			}
			return null;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00010208 File Offset: 0x0000F208
		private FocusableGridElement x242b337514d5624c(FocusableGridElement x4bbc2c453c470189)
		{
			return x4bbc2c453c470189;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0001020C File Offset: 0x0000F20C
		internal Rectangle x93b1564fed45c05e()
		{
			if (base.Grid.RowHighlightType == RowHighlightType.PrimaryColumnOnly && base.Grid.SelectionGranularity == SelectionGranularity.Row)
			{
				Rectangle result = this.x0494e81625d97ffc();
				Image cellImage = this.GetCellImage(base.Grid.PrimaryColumn);
				if (cellImage != null)
				{
					int num = cellImage.Width + base.Grid.ImageTextSeparation;
					if (!this.x94975a4c4f1d71c4)
					{
						result.X -= num;
					}
					result.Width += num;
				}
				if (base.Grid.CheckBoxes)
				{
					int num2 = this.x94975a4c4f1d71c4 ? (base.Bounds.Right - this.xb889d9c3f565170e.Right) : (result.X - this.xb889d9c3f565170e.X);
					if (!this.x94975a4c4f1d71c4)
					{
						result.X -= num2;
					}
					result.Width += num2;
				}
				if (base.Grid.ShowTreeButtons && (base.Grid.ShowRootLines || this.IndentationLevel != 0))
				{
					if (!this.x94975a4c4f1d71c4)
					{
						result.X -= 17;
					}
					result.Width += 17;
				}
				return result;
			}
			return base.Bounds;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x00010358 File Offset: 0x0000F358
		public void Remove()
		{
			if (this.ParentRow != null)
			{
				this.ParentRow.NestedRows.Remove(this);
				return;
			}
			if (base.Grid != null)
			{
				base.Grid.Rows.Remove(this);
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00010390 File Offset: 0x0000F390
		public GridRow[] GetDescendants()
		{
			if (!this.HasRows)
			{
				return new GridRow[0];
			}
			ArrayList arrayList = new ArrayList();
			this.xae3d7eb9bcc9d7ce(this, arrayList);
			return (GridRow[])arrayList.ToArray(typeof(GridRow));
		}

		// Token: 0x06000270 RID: 624 RVA: 0x000103D0 File Offset: 0x0000F3D0
		private void xae3d7eb9bcc9d7ce(GridRow xfbf9d376a0c88d8d, ArrayList x2eb5785cf1641b8b)
		{
			foreach (object obj in xfbf9d376a0c88d8d.x2eb5785cf1641b8b)
			{
				GridRow gridRow = (GridRow)obj;
				x2eb5785cf1641b8b.Add(gridRow);
				if (gridRow.HasRows)
				{
					this.xae3d7eb9bcc9d7ce(gridRow, x2eb5785cf1641b8b);
				}
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00010448 File Offset: 0x0000F448
		public virtual object GetCellValue(GridColumn column)
		{
			object result;
			try
			{
				if (column.IsDataBound)
				{
					result = base.Grid.x0f405f185e70ec01.x3f88a25febd23896(column.xafbad39eb3920055, base.Index);
				}
				else if (this.HasCells && this.Cells.IsValidIndex(column.Index))
				{
					result = this.Cells[column.Index].GetValue();
				}
				else
				{
					result = null;
				}
			}
			catch (Exception exception)
			{
				GridDataErrorEventArgs gridDataErrorEventArgs = new GridDataErrorEventArgs(this, column, null, DataErrorOperation.GetCellValue, exception);
				if (base.Grid.SandGrid != null)
				{
					base.Grid.SandGrid.xb550175c839c05f5(gridDataErrorEventArgs);
				}
				if (gridDataErrorEventArgs.ThrowException)
				{
					throw;
				}
				result = null;
			}
			return result;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0001050C File Offset: 0x0000F50C
		public virtual void SetCellValue(GridColumn column, object value)
		{
			try
			{
				if (column.IsDataBound)
				{
					base.Grid.x0f405f185e70ec01.xc7b6e59bfbbe9301(column.xafbad39eb3920055, base.Index, value);
				}
				else
				{
					if (!this.HasCells || !this.Cells.IsValidIndex(column.Index))
					{
						throw new InvalidOperationException("An editor attempted to set a cell value but no cell was present at index " + column.Index + ".");
					}
					this.Cells[column.Index].SetValue(value);
				}
			}
			catch (Exception exception)
			{
				GridDataErrorEventArgs gridDataErrorEventArgs = new GridDataErrorEventArgs(this, column, value, DataErrorOperation.CommitValue, exception);
				if (base.Grid.SandGrid != null)
				{
					base.Grid.SandGrid.xb550175c839c05f5(gridDataErrorEventArgs);
				}
				if (gridDataErrorEventArgs.ThrowException)
				{
					throw;
				}
			}
			if (column.AutoSize == ColumnAutoSizeMode.Contents)
			{
				base.MeasureNeeded();
				return;
			}
			Rectangle bounds = base.Bounds;
			bounds.X = column.Bounds.X;
			bounds.Width = column.Bounds.Width;
			if (bounds.Width > 0 && bounds.Height > 0)
			{
				base.RedrawNeeded(bounds);
			}
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00010648 File Offset: 0x0000F648
		protected internal virtual Image GetCellImage(GridColumn column)
		{
			if (this.HasCells && this.Cells.IsValidIndex(column.Index))
			{
				return this.Cells[column.Index].Image;
			}
			return null;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x00010680 File Offset: 0x0000F680
		protected internal bool NotifyColumnValueChanged(GridColumn column)
		{
			if (base.Grid == null)
			{
				return false;
			}
			if (column == null)
			{
				base.RedrawNeeded();
			}
			if (base.Grid.xc22134cf4aa6ad3d)
			{
				return false;
			}
			GridRowCollection gridRowCollection = (this.ParentRow == null) ? base.Grid.Rows : this.ParentRow.NestedRows;
			if (column == null || gridRowCollection.xa5dcc13c31b2d66e(column))
			{
				gridRowCollection.x392c4e6c2fa28c2b();
				return true;
			}
			return false;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x000106E8 File Offset: 0x0000F6E8
		protected internal virtual void DrawHeader(RenderingContext context, TextFormattingInformation textFormat)
		{
			Divelements.SandGrid.Rendering.DrawItemState drawItemState = Divelements.SandGrid.Rendering.DrawItemState.None;
			if (this.xf4e57d58ee4da85f)
			{
				drawItemState |= Divelements.SandGrid.Rendering.DrawItemState.Hot;
			}
			context.Renderer.DrawRowHeader(context.Graphics, this, this.HeaderBounds, textFormat, drawItemState);
			if (this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.xb9c2fdbad39c60d0))
			{
				context.Renderer.DrawGlyph(context.Graphics, this.HeaderBounds, SandGridGlyphType.EditMode);
			}
			else if (context.RowWithFocus == this)
			{
				context.Renderer.DrawGlyph(context.Graphics, this.HeaderBounds, SandGridGlyphType.CurrentRow);
			}
			if (base.Grid.xc22134cf4aa6ad3d)
			{
				string text = base.Grid.x0f405f185e70ec01.x56f6dc80f5dd23e8(base.Index);
				if (text != null && text.Length != 0)
				{
					context.Renderer.DrawGlyph(context.Graphics, this.HeaderBounds, SandGridGlyphType.Error);
				}
			}
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000107A8 File Offset: 0x0000F7A8
		protected void DrawExpandButton(RenderingContext context)
		{
			if (this.xb0b83f15c7318893 != Rectangle.Empty && this.xb0b83f15c7318893.Right <= base.Grid.PrimaryColumn.Bounds.Right)
			{
				context.Renderer.DrawExpandButton(context.Graphics, this.xb0b83f15c7318893, this.Expanded);
			}
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0001080C File Offset: 0x0000F80C
		internal Rectangle x0d0b65ba2307e88a()
		{
			return this.xb0b83f15c7318893;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00010814 File Offset: 0x0000F814
		protected void DrawCheckBox(RenderingContext context)
		{
			if (this.xb889d9c3f565170e.Right <= base.Grid.PrimaryColumn.Bounds.Right)
			{
				context.Renderer.DrawCheckBox(context.Graphics, this.xb889d9c3f565170e, this.x1374490d077c0d3f);
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00010868 File Offset: 0x0000F868
		protected void DrawCells(RenderingContext context, Rectangle bounds, GridColumn[] columns, TextFormattingInformation[] textFormats)
		{
			int i = 0;
			while (i < columns.Length)
			{
				GridColumn gridColumn = columns[i];
				bool flag;
				if (!base.Selected)
				{
					flag = false;
					goto IL_118;
				}
				if (((uint)i | 4U) != 0U)
				{
					flag = !this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x077499efa75bab29);
					goto IL_118;
				}
				goto IL_139;
				IL_1B:
				bool flag2;
				if (this.HasCells && gridColumn.Index < this.Cells.Count)
				{
					this.Cells[gridColumn.Index].Draw(context, base.Font, flag2, textFormats[i]);
				}
				else
				{
					Rectangle bounds2 = new Rectangle(gridColumn.Bounds.Left, bounds.Top, gridColumn.Bounds.Width, bounds.Height);
					if (gridColumn.IsPrimary)
					{
						bounds2 = this.AdjustForIndentation(bounds2);
					}
					this.DrawVirtualCell(context, gridColumn, this.GetCellValue(gridColumn), base.Font, this.GetCellImage(gridColumn), bounds2, flag2, textFormats[i], SystemColors.WindowText);
				}
				i++;
				continue;
				IL_139:
				if (flag2 && base.Grid.RowHighlightType == RowHighlightType.Partial && gridColumn.DisplayIndex < base.Grid.PrimaryColumn.DisplayIndex)
				{
					flag2 = false;
					goto IL_1B;
				}
				if (flag2 && base.Grid.RowHighlightType == RowHighlightType.None)
				{
					flag2 = false;
					goto IL_1B;
				}
				goto IL_1B;
				IL_118:
				flag2 = flag;
				if (flag2 && base.Grid.RowHighlightType == RowHighlightType.PrimaryColumnOnly && !gridColumn.IsPrimary)
				{
					flag2 = false;
					goto IL_1B;
				}
				goto IL_139;
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000109E8 File Offset: 0x0000F9E8
		protected void DrawGridLines(RenderingContext context, GridColumn[] columns)
		{
			if (base.Grid.GridLines != GridLinesDisplayType.HorizontalOnly)
			{
				foreach (GridColumn gridColumn in columns)
				{
					context.Graphics.DrawLine(context.GridLinePen, gridColumn.Bounds.Right - 1, base.Bounds.Top, gridColumn.Bounds.Right - 1, base.Bounds.Bottom - 1);
				}
			}
			if (base.Grid.GridLines != GridLinesDisplayType.VerticalOnly)
			{
				context.Graphics.DrawLine(context.GridLinePen, base.Bounds.Left, base.Bounds.Bottom - 1, base.Bounds.Right - 1, base.Bounds.Bottom - 1);
				if (this.x149bf25701697822)
				{
					context.Graphics.DrawLine(context.GridLinePen, base.Bounds.Left, base.Bounds.Top - 1, base.Bounds.Right - 1, base.Bounds.Top - 1);
				}
			}
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00010B28 File Offset: 0x0000FB28
		protected internal virtual void DrawRowForeground(RenderingContext context, Rectangle bounds, GridColumn[] columns, TextFormattingInformation[] textFormats)
		{
			if (base.Grid.ShowTreeLines && base.Grid.ShowTreeButtons && base.Grid.PrimaryColumn.Visible)
			{
				this.DrawHierarchyLines(context);
			}
			if (base.Grid.ShowTreeButtons && base.Grid.PrimaryColumn.Visible)
			{
				this.DrawExpandButton(context);
			}
			if (base.Grid.CheckBoxes)
			{
				this.DrawCheckBox(context);
			}
			this.DrawCells(context, bounds, columns, textFormats);
			if (base.Grid.GridLines != GridLinesDisplayType.None)
			{
				this.DrawGridLines(context, columns);
			}
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00010BC4 File Offset: 0x0000FBC4
		protected virtual void DrawVirtualCell(RenderingContext context, GridColumn column, object value, Font font, Image image, Rectangle bounds, bool selected, TextFormattingInformation textFormat, Color foreColor)
		{
			column.DrawCell(context, this, value, font, image, bounds, selected, textFormat, foreColor);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00010BE8 File Offset: 0x0000FBE8
		internal Rectangle xce9e1c7589503f48(GridColumn xe3e287548b3d01f5)
		{
			Rectangle rectangle = new Rectangle(xe3e287548b3d01f5.Bounds.Left, base.Bounds.Top, xe3e287548b3d01f5.Bounds.Width, base.Bounds.Height);
			if (xe3e287548b3d01f5.IsPrimary)
			{
				rectangle = this.AdjustForIndentation(rectangle);
			}
			return rectangle;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00010C48 File Offset: 0x0000FC48
		protected void DrawHierarchyLines(RenderingContext context)
		{
			int num = this.CalculateIndentation() + 8;
			int width = base.Grid.PrimaryColumn.Bounds.Width;
			int num2 = base.Bounds.Top + base.Bounds.Height / 2 - 1;
			using (Pen pen = context.Renderer.CreateTreeHierarchyLinePen())
			{
				if (this.IndentationLevel == 0)
				{
					if (!base.Grid.ShowRootLines)
					{
						goto IL_23E;
					}
				}
				int num3 = this.x94975a4c4f1d71c4 ? (base.Grid.PrimaryColumn.Bounds.Right - num) : (base.Grid.PrimaryColumn.Bounds.Left + num);
				if (this.PreviousVisibleRow != null && num < width)
				{
					context.Graphics.DrawLine(pen, num3, base.Bounds.Top, num3, num2);
				}
				ulong num4 = (ulong)Math.Pow(2.0, (double)this.IndentationLevel);
				if ((this.xc1e8377a82d87d1c & num4) == num4 && num < width)
				{
					context.Graphics.DrawLine(pen, num3, num2, num3, base.Bounds.Bottom);
				}
				if (num + 10 < width)
				{
					if (this.x94975a4c4f1d71c4)
					{
						context.Graphics.DrawLine(pen, num3, num2, num3 - 10, num2);
					}
					else
					{
						context.Graphics.DrawLine(pen, num3, num2, num3 + 10, num2);
					}
				}
				IL_23E:
				num = 8;
				if (((uint)width & 0U) != 0U)
				{
					goto IL_257;
				}
				goto IL_73;
				IL_64:
				int num5;
				if (num5 >= this.IndentationLevel)
				{
					goto IL_272;
				}
				num4 = (ulong)Math.Pow(2.0, (double)num5);
				if ((this.xc1e8377a82d87d1c & num4) == num4 && num < width)
				{
					num3 = (this.x94975a4c4f1d71c4 ? (base.Grid.PrimaryColumn.Bounds.Right - num) : (base.Grid.PrimaryColumn.Bounds.Left + num));
					context.Graphics.DrawLine(pen, num3, base.Bounds.Top, num3, base.Bounds.Bottom - 1);
				}
				num += base.Grid.IndentationSize;
				if (((uint)num5 | 1U) != 0U)
				{
					num5++;
					goto IL_257;
				}
				IL_73:
				num5 = (base.Grid.ShowRootLines ? 0 : 1);
				goto IL_64;
				IL_257:
				bool flag = (uint)width - (uint)width < 0U;
				if (!flag)
				{
					goto IL_64;
				}
				IL_272:;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00010F08 File Offset: 0x0000FF08
		internal Rectangle xb889d9c3f565170e
		{
			get
			{
				if (this.x49924de850b790ef == Rectangle.Empty && base.Grid != null && base.Grid.CheckBoxes)
				{
					int num = this.CalculateIndentation();
					if (base.Grid.ShowTreeButtons && (this.IndentationLevel != 0 || base.Grid.ShowRootLines))
					{
						num += 17;
					}
					num += 2;
					int x = this.x94975a4c4f1d71c4 ? (base.Grid.PrimaryColumn.Bounds.Right - num - 13) : (base.Grid.PrimaryColumn.Bounds.Left + num);
					return new Rectangle(x, base.Bounds.Top + base.Bounds.Height / 2 - 6, 13, 13);
				}
				return this.x49924de850b790ef;
			}
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00010FF0 File Offset: 0x0000FFF0
		protected virtual int CalculateIndentation()
		{
			if (!base.Grid.ShowRootLines)
			{
				return base.Grid.IndentationSize * Math.Max(this.IndentationLevel - 1, 0);
			}
			return base.Grid.IndentationSize * this.IndentationLevel;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0001102C File Offset: 0x0001002C
		public Rectangle AdjustForIndentation(Rectangle bounds)
		{
			if (this.IndentationLevel > 0)
			{
				int num = this.CalculateIndentation();
				if (!this.x94975a4c4f1d71c4)
				{
					bounds.X += num;
				}
				bounds.Width -= num;
			}
			if (base.Grid.ShowTreeButtons && (base.Grid.ShowRootLines || this.IndentationLevel != 0))
			{
				if (!this.x94975a4c4f1d71c4)
				{
					bounds.X += 17;
				}
				bounds.Width -= 17;
			}
			if (base.Grid.CheckBoxes)
			{
				if (!this.x94975a4c4f1d71c4)
				{
					bounds.X += 15;
				}
				bounds.Width -= 15;
			}
			if (bounds.Width < 0)
			{
				bounds.Width = 0;
			}
			return bounds;
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06000282 RID: 642 RVA: 0x00011104 File Offset: 0x00010104
		internal bool x94975a4c4f1d71c4
		{
			get
			{
				return base.Grid != null && base.Grid.RightToLeft;
			}
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0001111C File Offset: 0x0001011C
		protected internal virtual void DrawRowBackground(RenderingContext context)
		{
			Graphics graphics = context.Graphics;
			if (this.IndexInGrid % 2 == 1 && base.Grid.ShadeAlternateRows)
			{
				using (Brush brush = context.Renderer.CreateAlternateRowBackgroundBrush(this, base.Bounds))
				{
					graphics.FillRectangle(brush, base.Bounds);
				}
			}
			if (this.x0813c035d5d658bb(context))
			{
				context.Renderer.DrawSelectionRectangle(graphics, this.x0494e81625d97ffc(), base.Selected, context.ContainsFocus, context.xf58ff9ce0e24a20c == this && context.FocusRectanglesEnabled);
			}
		}

		// Token: 0x06000284 RID: 644 RVA: 0x000111CC File Offset: 0x000101CC
		protected override void LayoutCore(Rectangle bounds)
		{
			this.x903e77999cdb7ffc = Rectangle.Empty;
			this.x457cd1982842ba8b = Rectangle.Empty;
			this.x49924de850b790ef = Rectangle.Empty;
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000111F0 File Offset: 0x000101F0
		internal void xa2a14afe900d2107(ulong xc1e8377a82d87d1c)
		{
			this.xc1e8377a82d87d1c = xc1e8377a82d87d1c;
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000111FC File Offset: 0x000101FC
		protected virtual Rectangle CalculateExpandButtonBounds(GridColumn primaryColumn)
		{
			if (base.Grid.RightToLeft)
			{
				int num = primaryColumn.Bounds.Right;
				num -= this.CalculateIndentation();
				num -= 13;
				return new Rectangle(num, base.Bounds.Top + base.Bounds.Height / 2 - 5, 9, 9);
			}
			int num2 = primaryColumn.Bounds.Left;
			num2 += this.CalculateIndentation();
			num2 += 4;
			return new Rectangle(num2, base.Bounds.Top + base.Bounds.Height / 2 - 5, 9, 9);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x000112AC File Offset: 0x000102AC
		protected internal virtual void LayoutCells(GridColumn[] allColumns, GridColumn[] displayColumns, GridColumn primaryColumn)
		{
			if (!base.Grid.ShowTreeButtons)
			{
				goto IL_118;
			}
			if (true)
			{
				goto IL_DC;
			}
			IL_1A:
			Rectangle bounds = base.Bounds;
			GridCell gridCell = null;
			int i;
			for (i = 0; i < displayColumns.Length; i++)
			{
				GridColumn gridColumn = displayColumns[i];
				if (this.Cells.IsValidIndex(gridColumn.Index))
				{
					GridCell gridCell2 = this.Cells[gridColumn.Index];
					gridCell2.xa08bcba111d8b3e3(gridColumn);
					gridCell2.x036123e44626983b(gridCell);
					if (gridCell != null)
					{
						gridCell.xc60422c171eeceae(gridCell2);
					}
					gridCell = gridCell2;
					gridCell2.xb7ae55095fddecd9(new Rectangle(gridColumn.Bounds.X, bounds.Y, gridColumn.Bounds.Width, bounds.Height));
				}
			}
			if (gridCell == null)
			{
				return;
			}
			gridCell.xc60422c171eeceae(null);
			if (((uint)i & 0U) == 0U)
			{
				return;
			}
			IL_DC:
			if ((this.HasRows || this.ContentsUnknown) && (this.IndentationLevel != 0 || base.Grid.ShowRootLines) && primaryColumn.Visible)
			{
				this.xb0b83f15c7318893 = this.CalculateExpandButtonBounds(primaryColumn);
				goto IL_12A;
			}
			IL_118:
			this.xb0b83f15c7318893 = Rectangle.Empty;
			if (-2147483648 != 0)
			{
			}
			IL_12A:
			if (this.HasCells)
			{
				goto IL_1A;
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x000113F0 File Offset: 0x000103F0
		protected override Size MeasureCore(Graphics graphics, TextFormattingInformation textFormat, bool rtl)
		{
			int num = 0;
			foreach (GridColumn gridColumn in base.Grid.Columns.DisplayColumns)
			{
				TextFormattingInformation textFormattingInformation;
				textFormat = (textFormattingInformation = gridColumn.CreateTextFormat(GridColumnTextFormatType.Cell));
				try
				{
					int num2 = gridColumn.Width - 8;
					Image cellImage = this.GetCellImage(gridColumn);
					if (cellImage != null)
					{
						num2 -= cellImage.Width + base.Grid.ImageTextSeparation;
						num = Math.Max(num, cellImage.Height + 4);
					}
					if (gridColumn.IsPrimary)
					{
						Rectangle bounds = new Rectangle(0, 0, int.MaxValue, 0);
						int num3 = int.MaxValue - this.AdjustForIndentation(bounds).Width;
						num2 -= num3;
					}
					string text = gridColumn.xf69eb59aa621a379(this, this.GetCellValue(gridColumn), typeof(string)) as string;
					num = Math.Max(num, IndependentText.MeasureText(graphics, text, gridColumn.UseCellFont ? base.Font : gridColumn.Font, num2, textFormat).Height);
				}
				finally
				{
					((IDisposable)textFormattingInformation).Dispose();
				}
			}
			if (num > 0)
			{
				num += 4;
			}
			num = Math.Max(num, GridRow.x993356576cc2bf99);
			return new Size(0, num);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00011540 File Offset: 0x00010540
		protected override bool ShouldTriggerMeasure()
		{
			return base.ShouldTriggerMeasure() && this.IsExpansionVisible();
		}

		// Token: 0x0600028A RID: 650 RVA: 0x00011554 File Offset: 0x00010554
		public override string ToString()
		{
			if (base.Grid != null && this.Cells.Count != 0)
			{
				string[] array = new string[this.Cells.Count];
				int count = 0;
				for (int i = 0; i < this.Cells.Count; i++)
				{
					if (this.Cells[i].ParentColumn != null)
					{
						array[count++] = (this.Cells[i].ParentColumn.xf69eb59aa621a379(this, this.GetCellValue(this.Cells[i].ParentColumn), typeof(string)) as string);
					}
				}
				return "GridRow: {" + string.Join(CultureInfo.CurrentCulture.TextInfo.ListSeparator + " ", array, 0, count) + "}";
			}
			if (base.Grid != null && base.Grid.PrimaryColumn != null)
			{
				return "GridRow: {" + base.Grid.PrimaryColumn.xf69eb59aa621a379(this, this.GetCellValue(base.Grid.PrimaryColumn), typeof(string)) + "}";
			}
			return base.ToString();
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00011684 File Offset: 0x00010684
		internal int x803908b707d2788d()
		{
			int num = 0;
			GridRow nextVisibleRow = this.NextVisibleRow;
			while (nextVisibleRow != null && nextVisibleRow.IndentationLevel > this.IndentationLevel)
			{
				num += ((nextVisibleRow.Height == 0) ? nextVisibleRow.x95f43364065e63e8.Height : nextVisibleRow.Height);
				nextVisibleRow = nextVisibleRow.NextVisibleRow;
			}
			return num;
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600028C RID: 652 RVA: 0x000116D8 File Offset: 0x000106D8
		// (set) Token: 0x0600028D RID: 653 RVA: 0x000116E0 File Offset: 0x000106E0
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public CheckState CheckState
		{
			get
			{
				return this.x1374490d077c0d3f;
			}
			set
			{
				if (value != this.x1374490d077c0d3f)
				{
					this.x1374490d077c0d3f = value;
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x0600028E RID: 654 RVA: 0x000116F8 File Offset: 0x000106F8
		// (set) Token: 0x0600028F RID: 655 RVA: 0x00011704 File Offset: 0x00010704
		[Category("Behavior")]
		[Description("Indicates whether the checkbox is checked.")]
		[DefaultValue(false)]
		public bool Checked
		{
			get
			{
				return this.x1374490d077c0d3f == CheckState.Checked;
			}
			set
			{
				this.CheckState = (value ? CheckState.Checked : CheckState.Unchecked);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000290 RID: 656 RVA: 0x00011714 File Offset: 0x00010714
		[Browsable(false)]
		public GridCell FirstVisibleCell
		{
			get
			{
				if (base.Grid == null)
				{
					throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
				}
				if (base.Grid.Columns.DisplayColumns.Length == 0)
				{
					return null;
				}
				int index = base.Grid.Columns.DisplayColumns[0].Index;
				if (this.HasCells && this.Cells.IsValidIndex(index))
				{
					return this.Cells[index];
				}
				return null;
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0001178C File Offset: 0x0001078C
		[Browsable(false)]
		public GridCell LastVisibleCell
		{
			get
			{
				if (base.Grid == null)
				{
					throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
				}
				if (base.Grid.Columns.DisplayColumns.Length == 0)
				{
					return null;
				}
				int index = base.Grid.Columns.DisplayColumns[base.Grid.Columns.DisplayColumns.Length - 1].Index;
				if (this.HasCells && this.Cells.IsValidIndex(index))
				{
					return this.Cells[index];
				}
				return null;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000292 RID: 658 RVA: 0x00011818 File Offset: 0x00010818
		private Rectangle x54eaabec2fd785c7
		{
			get
			{
				Rectangle headerBounds = this.HeaderBounds;
				headerBounds.Height = 3;
				return headerBounds;
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000293 RID: 659 RVA: 0x00011838 File Offset: 0x00010838
		private Rectangle x97c2992f0a853609
		{
			get
			{
				Rectangle headerBounds = this.HeaderBounds;
				headerBounds.Y = headerBounds.Bottom - 3;
				headerBounds.Height = 3;
				return headerBounds;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000294 RID: 660 RVA: 0x00011868 File Offset: 0x00010868
		// (set) Token: 0x06000295 RID: 661 RVA: 0x00011874 File Offset: 0x00010874
		internal bool xf4e57d58ee4da85f
		{
			get
			{
				return this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.xf4e57d58ee4da85f);
			}
			set
			{
				if (value != this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.xf4e57d58ee4da85f))
				{
					this.x68939192b57c4e95(GridRow.x6e86085849cdace1.xf4e57d58ee4da85f, value);
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000296 RID: 662 RVA: 0x00011890 File Offset: 0x00010890
		[Browsable(false)]
		public object DataItem
		{
			get
			{
				if (base.Grid != null && base.Grid.x0f405f185e70ec01 != null)
				{
					return base.Grid.x0f405f185e70ec01.x06ca69422bbb7502[base.Index];
				}
				return null;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000297 RID: 663 RVA: 0x000118C4 File Offset: 0x000108C4
		// (set) Token: 0x06000298 RID: 664 RVA: 0x000118D0 File Offset: 0x000108D0
		[Category("Behavior")]
		[DefaultValue(true)]
		[Description("Indicates whether the contents of the row can be edited.")]
		public virtual bool AllowEditing
		{
			get
			{
				return this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x209b579d9584fab7);
			}
			set
			{
				this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x209b579d9584fab7, value);
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x000118DC File Offset: 0x000108DC
		internal void xa1234ce25f6ce296(bool x8c7b6df56a45ae90)
		{
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x077499efa75bab29, x8c7b6df56a45ae90);
			base.RedrawNeeded();
			if (!x8c7b6df56a45ae90)
			{
				this.x9829fd753544f98c(false);
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x000118F8 File Offset: 0x000108F8
		internal void x9829fd753544f98c(bool x7e2e7dab74ab56c8)
		{
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.xb9c2fdbad39c60d0, x7e2e7dab74ab56c8);
			base.RedrawNeeded();
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600029B RID: 667 RVA: 0x00011908 File Offset: 0x00010908
		[Browsable(false)]
		public bool HasCells
		{
			get
			{
				return this.x77bb6a53fbd162d0 != null && this.x77bb6a53fbd162d0.Count != 0;
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600029C RID: 668 RVA: 0x00011928 File Offset: 0x00010928
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("The cells contained in the row.")]
		[Category("Children")]
		public GridCellCollection Cells
		{
			get
			{
				if (this.x77bb6a53fbd162d0 == null)
				{
					this.x77bb6a53fbd162d0 = new GridCellCollection(this);
				}
				return this.x77bb6a53fbd162d0;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600029D RID: 669 RVA: 0x00011944 File Offset: 0x00010944
		[Browsable(false)]
		public int IndexInGrid
		{
			get
			{
				return this.x41fda6c4e54abab3;
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0001194C File Offset: 0x0001094C
		internal void xbd2f66a95763069d(int x41fda6c4e54abab3)
		{
			this.x41fda6c4e54abab3 = x41fda6c4e54abab3;
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00011958 File Offset: 0x00010958
		[Browsable(false)]
		public GridGroup Group
		{
			get
			{
				return this.xe2c9497bf778cd2b;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00011960 File Offset: 0x00010960
		internal bool x149bf25701697822
		{
			get
			{
				return this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x149bf25701697822);
			}
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0001196C File Offset: 0x0001096C
		internal void x219ece04845720d2(GridGroup xbcea506a33cf9111, bool x10aaa7cdfa38f254)
		{
			this.xe2c9497bf778cd2b = xbcea506a33cf9111;
			this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x149bf25701697822, x10aaa7cdfa38f254);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00011980 File Offset: 0x00010980
		private bool x0813c035d5d658bb(RenderingContext x0f7b23d1c393aed9)
		{
			return (base.Grid.RowHighlightType == RowHighlightType.Partial || base.Grid.RowHighlightType == RowHighlightType.Full) && (base.Selected || base.Grid.SandGrid.FocusedElement == this) && !this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x077499efa75bab29) && !x0f7b23d1c393aed9.HideSelection;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x000119D8 File Offset: 0x000109D8
		internal void x6286548365a5b7f9(Rectangle xda73fcb97c77d998)
		{
			this.x457cd1982842ba8b = xda73fcb97c77d998;
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x000119E4 File Offset: 0x000109E4
		internal Rectangle x0494e81625d97ffc()
		{
			if (this.x457cd1982842ba8b == Rectangle.Empty && base.Grid != null && base.Grid.RowHighlightType != RowHighlightType.None)
			{
				this.x457cd1982842ba8b = base.Bounds;
				if (base.Grid.GridLines == GridLinesDisplayType.Both)
				{
					goto IL_210;
				}
				int num;
				if ((uint)num + (uint)num > 4294967295U)
				{
					goto IL_228;
				}
				if (base.Grid.GridLines == GridLinesDisplayType.HorizontalOnly)
				{
					goto IL_210;
				}
				IL_1A:
				if ((base.Grid.RowHighlightType != RowHighlightType.Partial && base.Grid.RowHighlightType != RowHighlightType.PrimaryColumnOnly) || !base.Grid.PrimaryColumn.Visible)
				{
					goto IL_228;
				}
				num = (this.x94975a4c4f1d71c4 ? (base.Grid.Bounds.Right - base.Grid.PrimaryColumn.Bounds.Right) : (base.Grid.PrimaryColumn.Bounds.Left - base.Grid.Bounds.Left));
				if (base.Grid.ShowRowHeaders)
				{
					num -= base.Grid.RowHeaderSize;
				}
				num += 4;
				if (!this.x94975a4c4f1d71c4)
				{
					this.x457cd1982842ba8b.X = this.x457cd1982842ba8b.X + num;
				}
				this.x457cd1982842ba8b.Width = this.x457cd1982842ba8b.Width - num;
				this.x457cd1982842ba8b = this.AdjustForIndentation(this.x457cd1982842ba8b);
				Image cellImage = this.GetCellImage(base.Grid.PrimaryColumn);
				if (cellImage != null)
				{
					if (!this.x94975a4c4f1d71c4)
					{
						this.x457cd1982842ba8b.X = this.x457cd1982842ba8b.X + (cellImage.Width + base.Grid.ImageTextSeparation);
					}
					this.x457cd1982842ba8b.Width = this.x457cd1982842ba8b.Width - (cellImage.Width + base.Grid.ImageTextSeparation);
				}
				if (base.Grid.RowHighlightType == RowHighlightType.Partial)
				{
					if (!this.x94975a4c4f1d71c4)
					{
						this.x457cd1982842ba8b.X = this.x457cd1982842ba8b.X - 2;
					}
					this.x457cd1982842ba8b.Width = this.x457cd1982842ba8b.Width + 2;
					goto IL_228;
				}
				goto IL_228;
				IL_210:
				this.x457cd1982842ba8b.Height = this.x457cd1982842ba8b.Height - 1;
				goto IL_1A;
			}
			IL_228:
			return this.x457cd1982842ba8b;
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x00011C20 File Offset: 0x00010C20
		[Browsable(false)]
		public Rectangle HeaderBounds
		{
			get
			{
				if (this.x903e77999cdb7ffc == Rectangle.Empty && base.Grid != null && base.Grid.ShowRowHeaders)
				{
					this.x903e77999cdb7ffc = base.Bounds;
					if (base.Grid.RightToLeft)
					{
						this.x903e77999cdb7ffc.X = base.Grid.Bounds.Right - base.Grid.RowHeaderSize;
					}
					else
					{
						this.x903e77999cdb7ffc.X = base.Grid.Bounds.Left;
					}
					this.x903e77999cdb7ffc.Width = base.Grid.RowHeaderSize;
				}
				return this.x903e77999cdb7ffc;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x00011CDC File Offset: 0x00010CDC
		[Browsable(false)]
		public GridRow PreviousVisibleRow
		{
			get
			{
				if (!this.IsExpansionVisible())
				{
					return this.x92c0e4f64c084ab1();
				}
				if (this.xaaea61ee7c2d4f3b == null)
				{
					this.xaaea61ee7c2d4f3b = this.x92c0e4f64c084ab1();
					if (this.xaaea61ee7c2d4f3b != null)
					{
						this.xaaea61ee7c2d4f3b.x147b7c32d0582c7c = this;
					}
				}
				return this.xaaea61ee7c2d4f3b;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x00011D1C File Offset: 0x00010D1C
		[Browsable(false)]
		public GridRow NextVisibleRow
		{
			get
			{
				if (!this.IsExpansionVisible())
				{
					return this.x2cc76ebec5b074e0();
				}
				if (this.x147b7c32d0582c7c == null)
				{
					this.x147b7c32d0582c7c = this.x2cc76ebec5b074e0();
					if (this.x147b7c32d0582c7c != null)
					{
						this.x147b7c32d0582c7c.xaaea61ee7c2d4f3b = this;
					}
				}
				return this.x147b7c32d0582c7c;
			}
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00011D5C File Offset: 0x00010D5C
		private bool ShouldSerializeHeight()
		{
			return this.Height != GridRow.x993356576cc2bf99;
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x00011D70 File Offset: 0x00010D70
		// (set) Token: 0x060002AA RID: 682 RVA: 0x00011D78 File Offset: 0x00010D78
		[Category("Layout")]
		public int Height
		{
			get
			{
				return this.x4d5aabc7a55b12ba;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNegative"), "value");
				}
				this.x4d5aabc7a55b12ba = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002AB RID: 683 RVA: 0x00011DA0 File Offset: 0x00010DA0
		[Browsable(false)]
		public int IndentationLevel
		{
			get
			{
				return this.xac8853fb4b6db488;
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00011DA8 File Offset: 0x00010DA8
		internal void xd4cf973b1f100cf3(int xac8853fb4b6db488)
		{
			this.xac8853fb4b6db488 = xac8853fb4b6db488;
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002AD RID: 685 RVA: 0x00011DB4 File Offset: 0x00010DB4
		internal int x31928485d4f5a3aa
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00011DB8 File Offset: 0x00010DB8
		public bool IsExpansionVisible()
		{
			if (this.ParentRow != null)
			{
				return this.ParentRow.IsExpansionVisible() && this.ParentRow.Expanded && this.ParentRow.xe0f8497fba2e6972;
			}
			if (base.Grid == null)
			{
				return false;
			}
			NestedGridRow nestedGridRow = base.Grid.ParentElement as NestedGridRow;
			if (nestedGridRow != null)
			{
				return nestedGridRow.IsExpansionVisible();
			}
			return this.xe0f8497fba2e6972;
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002AF RID: 687 RVA: 0x00011E20 File Offset: 0x00010E20
		// (set) Token: 0x060002B0 RID: 688 RVA: 0x00011E2C File Offset: 0x00010E2C
		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether the expand button will still be drawn for the row even if there are no child rows.")]
		public bool ContentsUnknown
		{
			get
			{
				return this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x389234cc61353606);
			}
			set
			{
				if (value != this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x389234cc61353606))
				{
					this.x68939192b57c4e95(GridRow.x6e86085849cdace1.x389234cc61353606, value);
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00011E48 File Offset: 0x00010E48
		// (set) Token: 0x060002B2 RID: 690 RVA: 0x00011E54 File Offset: 0x00010E54
		[Category("Layout")]
		[DefaultValue(false)]
		[Description("Indicates whether any child rows of this row are visible.")]
		public bool Expanded
		{
			get
			{
				return this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x7757e023237c7679);
			}
			set
			{
				if (this.xffcb3098cb15bbec(GridRow.x6e86085849cdace1.x7757e023237c7679) != value)
				{
					if (value)
					{
						this.x3e3f6c8fa322858b(ExpandCollapseTrigger.Unknown);
						return;
					}
					this.x98ab41ccb801e030(ExpandCollapseTrigger.Unknown);
				}
			}
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00011E74 File Offset: 0x00010E74
		internal override void x0b035f832721de35()
		{
			if (this.HasRows)
			{
				foreach (object obj in this.NestedRows)
				{
					GridRow gridRow = (GridRow)obj;
					gridRow.x0b035f832721de35();
				}
			}
			if (this.HasCells)
			{
				foreach (object obj2 in this.Cells)
				{
					GridCell gridCell = (GridCell)obj2;
					gridCell.x0b035f832721de35();
				}
			}
			base.x0b035f832721de35();
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002B4 RID: 692 RVA: 0x00011F48 File Offset: 0x00010F48
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Children")]
		[Description("The rows of data that are nested inside this row rather than being direct descendents of the grid.")]
		[Editor(typeof(xf2a94613768c6d30), typeof(UITypeEditor))]
		public GridRowCollection NestedRows
		{
			get
			{
				if (this.x2eb5785cf1641b8b == null)
				{
					this.x2eb5785cf1641b8b = new GridRowCollection(this);
				}
				return this.x2eb5785cf1641b8b;
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002B5 RID: 693 RVA: 0x00011F64 File Offset: 0x00010F64
		[Browsable(false)]
		public bool HasRows
		{
			get
			{
				return this.x2eb5785cf1641b8b != null && this.x2eb5785cf1641b8b.Count != 0;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002B6 RID: 694 RVA: 0x00011F84 File Offset: 0x00010F84
		[Browsable(false)]
		public GridRow ParentRow
		{
			get
			{
				return this.xfbf9d376a0c88d8d;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002B7 RID: 695 RVA: 0x00011F8C File Offset: 0x00010F8C
		public override GridElement ParentElement
		{
			get
			{
				return this.ParentRow;
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00011F94 File Offset: 0x00010F94
		internal void x973e390b09c57b95(GridRow xfbf9d376a0c88d8d)
		{
			this.xfbf9d376a0c88d8d = xfbf9d376a0c88d8d;
			InnerGrid xf57b149cb3f9c03a = (xfbf9d376a0c88d8d != null) ? xfbf9d376a0c88d8d.Grid : base.Grid;
			this.xea1c0bc64ab77594(xf57b149cb3f9c03a);
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00011FC4 File Offset: 0x00010FC4
		internal override void xea1c0bc64ab77594(InnerGrid xf57b149cb3f9c03a)
		{
			if (this.HasRows)
			{
				foreach (object obj in this.NestedRows)
				{
					GridRow gridRow = (GridRow)obj;
					gridRow.xea1c0bc64ab77594(xf57b149cb3f9c03a);
				}
			}
			if (this.HasCells)
			{
				foreach (object obj2 in this.Cells)
				{
					GridCell gridCell = (GridCell)obj2;
					gridCell.xea1c0bc64ab77594(xf57b149cb3f9c03a);
				}
			}
			base.xea1c0bc64ab77594(xf57b149cb3f9c03a);
			this.x219ece04845720d2(null, false);
			this.x41fda6c4e54abab3 = 0;
			this.xac8853fb4b6db488 = 0;
			this.xf4e57d58ee4da85f = false;
			this.x530a591976340ded();
			if (this.HasRows && base.Grid != null)
			{
				this.NestedRows.x392c4e6c2fa28c2b();
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002BA RID: 698 RVA: 0x000120DC File Offset: 0x000110DC
		internal GridRow x9fcc739d9a713387
		{
			get
			{
				return this.x147b7c32d0582c7c;
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002BB RID: 699 RVA: 0x000120E4 File Offset: 0x000110E4
		internal GridRow x57aa0f7994718ad8
		{
			get
			{
				return this.xaaea61ee7c2d4f3b;
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x000120EC File Offset: 0x000110EC
		internal void x530a591976340ded()
		{
			if (this.xaaea61ee7c2d4f3b != null)
			{
				this.xaaea61ee7c2d4f3b.x147b7c32d0582c7c = null;
			}
			if (this.x147b7c32d0582c7c != null)
			{
				this.x147b7c32d0582c7c.xaaea61ee7c2d4f3b = null;
			}
			this.xaaea61ee7c2d4f3b = null;
			this.x147b7c32d0582c7c = null;
		}

		// Token: 0x04000092 RID: 146
		internal const int x2fff9d12561f9820 = 17;

		// Token: 0x04000093 RID: 147
		internal const int x60531785cde7be71 = 3;

		// Token: 0x04000094 RID: 148
		internal const int x1728cb92c0ae62a3 = 13;

		// Token: 0x04000095 RID: 149
		internal static readonly int x993356576cc2bf99 = Control.DefaultFont.Height + 5;

		// Token: 0x04000096 RID: 150
		private int xac8853fb4b6db488;

		// Token: 0x04000097 RID: 151
		private int x41fda6c4e54abab3;

		// Token: 0x04000098 RID: 152
		private int x4d5aabc7a55b12ba = GridRow.x993356576cc2bf99;

		// Token: 0x04000099 RID: 153
		private Rectangle xb0b83f15c7318893;

		// Token: 0x0400009A RID: 154
		private Rectangle x903e77999cdb7ffc;

		// Token: 0x0400009B RID: 155
		private Rectangle x457cd1982842ba8b;

		// Token: 0x0400009C RID: 156
		private Rectangle x49924de850b790ef;

		// Token: 0x0400009D RID: 157
		private GridRow xaaea61ee7c2d4f3b;

		// Token: 0x0400009E RID: 158
		private GridRow x147b7c32d0582c7c;

		// Token: 0x0400009F RID: 159
		private ulong xc1e8377a82d87d1c;

		// Token: 0x040000A0 RID: 160
		private CheckState x1374490d077c0d3f;

		// Token: 0x040000A1 RID: 161
		private BitArray xc1c198fb5a40fecc;

		// Token: 0x040000A2 RID: 162
		private GridGroup xe2c9497bf778cd2b;

		// Token: 0x040000A3 RID: 163
		private GridRow xfbf9d376a0c88d8d;

		// Token: 0x040000A4 RID: 164
		private GridRowCollection x2eb5785cf1641b8b;

		// Token: 0x040000A5 RID: 165
		private GridCellCollection x77bb6a53fbd162d0;

		// Token: 0x0200001F RID: 31
		private enum x6e86085849cdace1
		{
			// Token: 0x0400010F RID: 271
			x26d06922b97b4b0f,
			// Token: 0x04000110 RID: 272
			x7757e023237c7679,
			// Token: 0x04000111 RID: 273
			x389234cc61353606,
			// Token: 0x04000112 RID: 274
			x077499efa75bab29,
			// Token: 0x04000113 RID: 275
			x149bf25701697822,
			// Token: 0x04000114 RID: 276
			x209b579d9584fab7,
			// Token: 0x04000115 RID: 277
			xb9c2fdbad39c60d0,
			// Token: 0x04000116 RID: 278
			xf4e57d58ee4da85f
		}
	}
}

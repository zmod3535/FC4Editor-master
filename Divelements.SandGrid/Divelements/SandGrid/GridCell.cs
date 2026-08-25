using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Divelements.SandGrid.Rendering;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x02000015 RID: 21
	[TypeConverter(typeof(x2e534b8fab38a541))]
	public class GridCell : FocusableGridElement
	{
		// Token: 0x060002CC RID: 716 RVA: 0x00012570 File Offset: 0x00011570
		public GridCell()
		{
		}

		// Token: 0x060002CD RID: 717 RVA: 0x000125A0 File Offset: 0x000115A0
		public GridCell(string text)
		{
			this.Text = text;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x000125D8 File Offset: 0x000115D8
		public GridCell(Image image)
		{
			this.Image = image;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x00012610 File Offset: 0x00011610
		public GridCell(string text, Image image)
		{
			this.Text = text;
			this.Image = image;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x00012650 File Offset: 0x00011650
		public GridCell(string text, Image image, Font font) : this(text, image)
		{
			base.Font = font;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x00012664 File Offset: 0x00011664
		protected internal override void OnEnter()
		{
			if (this.ParentColumn != null)
			{
				this.ParentColumn.RedrawNeeded();
			}
			base.OnEnter();
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x00012680 File Offset: 0x00011680
		protected internal override void OnLeave()
		{
			if (this.ParentColumn != null)
			{
				this.ParentColumn.RedrawNeeded();
			}
			base.OnLeave();
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0001269C File Offset: 0x0001169C
		internal override void x0c44cc8270354ceb(MouseEventArgs xfbf34718e704c6bc)
		{
			base.Grid.SandGrid.x4ed3c8af084555d7(this.ParentRow, this.ParentColumn);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x000126BC File Offset: 0x000116BC
		protected internal virtual void Draw(RenderingContext context, Font rowFont, bool rowSelected, TextFormattingInformation textFormat)
		{
			if (base.Selected)
			{
				rowSelected = true;
			}
			if (this.x154083d58301ef75 != Color.Transparent)
			{
				using (SolidBrush solidBrush = new SolidBrush(this.x154083d58301ef75))
				{
					context.Graphics.FillRectangle(solidBrush, base.Bounds);
				}
			}
			if ((base.Selected || context.xf58ff9ce0e24a20c == this) && !context.HideSelection)
			{
				context.Renderer.DrawSelectionRectangle(context.Graphics, this.SelectionBounds, base.Selected, context.ContainsFocus, context.xf58ff9ce0e24a20c == this && context.FocusRectanglesEnabled);
			}
			this.ParentColumn.DrawCell(context, this.ParentRow, this.GetValue(), base.Font, this.Image, this.ContentBounds, rowSelected, textFormat, this.ForeColor);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000127B0 File Offset: 0x000117B0
		protected override void LayoutCore(Rectangle bounds)
		{
			this.x457cd1982842ba8b = Rectangle.Empty;
			this.x0bd0d09521a6c8ef = Rectangle.Empty;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x000127C8 File Offset: 0x000117C8
		protected override Font GetDefaultFont()
		{
			if (this.ParentRow != null)
			{
				return this.ParentRow.Font;
			}
			return base.GetDefaultFont();
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x000127E4 File Offset: 0x000117E4
		public void Remove()
		{
			if (this.ParentRow != null)
			{
				this.ParentRow.Cells.Remove(this);
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00012800 File Offset: 0x00011800
		public override void SelectBlock(FocusableGridElement startElement, FocusableGridElement toElement)
		{
			GridCell gridCell = startElement as GridCell;
			GridCell gridCell2 = toElement as GridCell;
			if (gridCell != null && gridCell2 != null)
			{
				GridCell.x1aeb71217c698ee3(gridCell, gridCell2);
			}
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00012828 File Offset: 0x00011828
		internal static GridCell[] x38deb49e9be2c379(GridCell x71e60bebf0ded509, GridCell x3ee22bf39f2b9f80)
		{
			ArrayList arrayList = new ArrayList();
			bool flag = x3ee22bf39f2b9f80.Bounds.Top > x71e60bebf0ded509.Bounds.Top;
			GridColumn[] displayColumns = x71e60bebf0ded509.Grid.Columns.DisplayColumns;
			int val = Array.IndexOf<GridColumn>(displayColumns, x71e60bebf0ded509.ParentColumn);
			int val2 = Array.IndexOf<GridColumn>(displayColumns, x3ee22bf39f2b9f80.ParentColumn);
			GridRow gridRow = null;
			while (gridRow != x3ee22bf39f2b9f80.ParentRow)
			{
				gridRow = ((gridRow == null) ? x71e60bebf0ded509.ParentRow : (gridRow.GetNextElement(flag ? FocusAdvanceDirection.Down : FocusAdvanceDirection.Up) as GridRow));
				if (gridRow == null)
				{
					break;
				}
				if (gridRow.HasCells)
				{
					for (int i = Math.Min(val, val2); i <= Math.Max(val, val2); i++)
					{
						int index = displayColumns[i].Index;
						if (gridRow.Cells.IsValidIndex(index))
						{
							arrayList.Add(gridRow.Cells[index]);
						}
					}
				}
			}
			return (GridCell[])arrayList.ToArray(typeof(GridCell));
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00012930 File Offset: 0x00011930
		internal static void x1aeb71217c698ee3(GridCell x71e60bebf0ded509, GridCell x3ee22bf39f2b9f80)
		{
			GridCell[] x6e96c3657c96bbbe = GridCell.x38deb49e9be2c379(x71e60bebf0ded509, x3ee22bf39f2b9f80);
			x71e60bebf0ded509.Grid.x12a83acc7c1ca827(x6e96c3657c96bbbe, true);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00012954 File Offset: 0x00011954
		public void BeginEdit()
		{
			if (base.Grid == null || base.Grid.SandGrid == null || this.ParentRow == null || this.ParentColumn == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			this.ParentRow.BeginEdit(this.ParentColumn);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x000129A8 File Offset: 0x000119A8
		protected internal override bool AdvanceFocus(FocusAdvanceDirection direction, FocusAdvanceMethod method, int steps, bool loop)
		{
			FocusableGridElement focusableGridElement = null;
			if (steps > 0)
			{
				FocusableGridElement focusableGridElement2 = this;
				for (int i = 1; i <= steps; i++)
				{
					bool flag;
					focusableGridElement2 = focusableGridElement2.GetNextElement(direction, loop, out flag);
					if (focusableGridElement2 == null)
					{
						break;
					}
					focusableGridElement = focusableGridElement2;
				}
			}
			else if (direction == FocusAdvanceDirection.Up)
			{
				focusableGridElement = this.ParentRow.FirstVisibleCell;
				direction = FocusAdvanceDirection.Left;
			}
			else if (direction == FocusAdvanceDirection.Down)
			{
				focusableGridElement = this.ParentRow.LastVisibleCell;
				direction = FocusAdvanceDirection.Right;
			}
			if (focusableGridElement == null)
			{
				return base.Grid.xc7f76500b5bc2b29(direction);
			}
			InnerGrid grid = base.Grid;
			grid.x614e783eda4ed71f();
			try
			{
				if (method == FocusAdvanceMethod.IncreaseSelection)
				{
					GridCell gridCell = base.Grid.SandGrid.xf023f44afe4ba919 as GridCell;
					if (gridCell != null)
					{
						base.Grid.SelectedElements.Clear();
						this.SelectBlock(gridCell, focusableGridElement);
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
			}
			finally
			{
				grid.x06727b7d4fe7a302();
			}
			return true;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00012AC0 File Offset: 0x00011AC0
		public override FocusableGridElement GetNextElement(FocusAdvanceDirection direction, bool loop, out bool exposedFurtherElements)
		{
			exposedFurtherElements = false;
			switch (direction)
			{
			case FocusAdvanceDirection.Up:
			case FocusAdvanceDirection.Down:
				return this.x2d260b358118ef01(direction);
			case FocusAdvanceDirection.Left:
			case FocusAdvanceDirection.Right:
				return this.x1debd95cc67f70c6(direction, loop);
			default:
				return null;
			}
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00012AFC File Offset: 0x00011AFC
		private FocusableGridElement x1debd95cc67f70c6(FocusAdvanceDirection x23e85093ba3a7d1d, bool x3c21da9f928aac10)
		{
			if (!x3c21da9f928aac10)
			{
				if (x23e85093ba3a7d1d != FocusAdvanceDirection.Left)
				{
					return this.NextCell;
				}
				return this.PreviousCell;
			}
			else if (x23e85093ba3a7d1d == FocusAdvanceDirection.Left)
			{
				if (this.PreviousCell != null)
				{
					return this.PreviousCell;
				}
				GridRow gridRow = this.ParentRow.GetNextElement(FocusAdvanceDirection.Up) as GridRow;
				if (gridRow != null)
				{
					return gridRow.LastVisibleCell;
				}
				return null;
			}
			else
			{
				if (this.NextCell != null)
				{
					return this.NextCell;
				}
				GridRow gridRow2 = this.ParentRow.GetNextElement(FocusAdvanceDirection.Down) as GridRow;
				if (gridRow2 != null)
				{
					return gridRow2.FirstVisibleCell;
				}
				return null;
			}
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00012B7C File Offset: 0x00011B7C
		private FocusableGridElement x2d260b358118ef01(FocusAdvanceDirection x23e85093ba3a7d1d)
		{
			bool flag;
			GridRow gridRow = this.ParentRow.GetNextElement(x23e85093ba3a7d1d, false, out flag) as GridRow;
			if (gridRow == null || !gridRow.HasCells)
			{
				return gridRow;
			}
			if (gridRow.Cells.IsValidIndex(base.Index))
			{
				return gridRow.Cells[base.Index];
			}
			if (gridRow.Cells.IsValidIndex(base.Grid.Columns.DisplayColumns[base.Grid.Columns.DisplayColumns.Length - 1].Index))
			{
				return gridRow.Cells[base.Grid.Columns.DisplayColumns[base.Grid.Columns.DisplayColumns.Length - 1].Index];
			}
			return gridRow;
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00012C44 File Offset: 0x00011C44
		internal override void xea1c0bc64ab77594(InnerGrid xf57b149cb3f9c03a)
		{
			base.xea1c0bc64ab77594(xf57b149cb3f9c03a);
			this.xf0a8fdf00cbe2562 = null;
			this.xeb6b802d500361c9 = null;
			this.x4000c5d4da39e7e0 = null;
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00012C64 File Offset: 0x00011C64
		protected internal override bool ValueAffectsMeasurement()
		{
			return this.ParentColumn != null && this.ParentColumn.AutoSize == ColumnAutoSizeMode.Contents;
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00012C80 File Offset: 0x00011C80
		protected bool OnValueChanged()
		{
			return this.ParentRow != null && base.Grid != null && this.ParentRow.NotifyColumnValueChanged(this.ParentColumn);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00012CA8 File Offset: 0x00011CA8
		protected internal override string GetTooltipText(Point position)
		{
			return this.ParentRow.GetTooltipText(position);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00012CB8 File Offset: 0x00011CB8
		protected override void SelectWithMouseButton(MouseEventArgs e)
		{
			if (base.Grid.SelectionGranularity == SelectionGranularity.Cell)
			{
				base.SelectWithMouseButton(e);
			}
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00012CD0 File Offset: 0x00011CD0
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00012CDC File Offset: 0x00011CDC
		protected internal override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);
			if (base.Grid.SandGrid.MouseEditing == MouseEditMode.DoubleClick && !base.Grid.SandGrid.EditorActive)
			{
				base.Grid.SandGrid.BeginEdit(this.ParentRow, this.ParentColumn, true);
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00012D34 File Offset: 0x00011D34
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left)
			{
				if (base.Grid.CellDragBehavior == CellDragBehavior.ExtendSelection && base.Grid.AllowMultipleSelection)
				{
					base.x11f639c5d61688d8(new x28c049b557a495a3(this, new Point(e.X, e.Y)));
					return;
				}
				if (base.Grid.CellDragBehavior == CellDragBehavior.InitiateDragDrop)
				{
					base.x11f639c5d61688d8(new x40917da28fd6d442(this, new Point(e.X, e.Y)));
				}
			}
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00012DBC File Offset: 0x00011DBC
		public object GetValue()
		{
			if (base.Grid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			if (this.ParentColumn != null && this.ParentColumn.IsDataBound)
			{
				return base.Grid.x0f405f185e70ec01.x3f88a25febd23896(this.ParentColumn.xafbad39eb3920055, this.ParentRow.Index);
			}
			if (this.IsNull)
			{
				return null;
			}
			return this.GetValueCore();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x00012E30 File Offset: 0x00011E30
		protected virtual object GetValueCore()
		{
			return this.Text;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00012E38 File Offset: 0x00011E38
		public void SetValue(object value)
		{
			if (base.Grid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			if (this.ParentColumn != null && this.ParentColumn.IsDataBound)
			{
				base.Grid.x0f405f185e70ec01.xc7b6e59bfbbe9301(this.ParentColumn.xafbad39eb3920055, this.ParentRow.Index, value);
				return;
			}
			if (value == null)
			{
				this.IsNull = true;
				return;
			}
			this.SetValueCore(value);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00012EAC File Offset: 0x00011EAC
		protected virtual void SetValueCore(object value)
		{
			this.Text = value.ToString();
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002EC RID: 748 RVA: 0x00012EBC File Offset: 0x00011EBC
		// (set) Token: 0x060002ED RID: 749 RVA: 0x00012EC4 File Offset: 0x00011EC4
		[DefaultValue(typeof(Color), "Transparent")]
		[Category("Appearance")]
		[Description("The color with which to draw the background of the cell.")]
		public Color BackColor
		{
			get
			{
				return this.x154083d58301ef75;
			}
			set
			{
				this.x154083d58301ef75 = value;
				base.RedrawNeeded();
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002EE RID: 750 RVA: 0x00012ED4 File Offset: 0x00011ED4
		// (set) Token: 0x060002EF RID: 751 RVA: 0x00012EDC File Offset: 0x00011EDC
		[Description("The color with which to draw text in the cell.")]
		[DefaultValue(typeof(Color), "WindowText")]
		[Category("Appearance")]
		public Color ForeColor
		{
			get
			{
				return this.x93532ca0ace0c1ae;
			}
			set
			{
				this.x93532ca0ace0c1ae = value;
				base.RedrawNeeded();
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002F0 RID: 752 RVA: 0x00012EEC File Offset: 0x00011EEC
		[Browsable(false)]
		public Rectangle SelectionBounds
		{
			get
			{
				if (this.x457cd1982842ba8b == Rectangle.Empty && base.Grid != null)
				{
					this.x457cd1982842ba8b = base.Bounds;
					if (base.Grid.GridLines == GridLinesDisplayType.Both || base.Grid.GridLines == GridLinesDisplayType.VerticalOnly)
					{
						this.x457cd1982842ba8b.Width = this.x457cd1982842ba8b.Width - 1;
					}
					if (base.Grid.GridLines == GridLinesDisplayType.Both || base.Grid.GridLines == GridLinesDisplayType.HorizontalOnly)
					{
						this.x457cd1982842ba8b.Height = this.x457cd1982842ba8b.Height - 1;
					}
					if (base.Grid.PrimaryColumn == this.ParentColumn)
					{
						this.x457cd1982842ba8b = this.ParentRow.AdjustForIndentation(this.x457cd1982842ba8b);
					}
				}
				return this.x457cd1982842ba8b;
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002F1 RID: 753 RVA: 0x00012FB4 File Offset: 0x00011FB4
		[Browsable(false)]
		public Rectangle ContentBounds
		{
			get
			{
				if (this.x0bd0d09521a6c8ef == Rectangle.Empty && base.Grid != null)
				{
					this.x0bd0d09521a6c8ef = base.Bounds;
					if (base.Grid.PrimaryColumn == this.ParentColumn)
					{
						this.x0bd0d09521a6c8ef = this.ParentRow.AdjustForIndentation(this.x0bd0d09521a6c8ef);
					}
				}
				return this.x0bd0d09521a6c8ef;
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00013018 File Offset: 0x00012018
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x00013020 File Offset: 0x00012020
		[Category("Appearance")]
		[AmbientValue(typeof(Image), null)]
		[Description("The image to display in the cell.")]
		[DefaultValue(typeof(Image), null)]
		public virtual Image Image
		{
			get
			{
				return this.xe058541ca798c059;
			}
			set
			{
				if (value != this.xe058541ca798c059)
				{
					bool flag = value == null || this.xe058541ca798c059 == null || value.Size != this.xe058541ca798c059.Size;
					this.xe058541ca798c059 = value;
					if (flag)
					{
						base.MeasureNeeded();
						return;
					}
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x00013074 File Offset: 0x00012074
		public override GridElement ParentElement
		{
			get
			{
				return this.ParentRow;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060002F5 RID: 757 RVA: 0x0001307C File Offset: 0x0001207C
		[Browsable(false)]
		public GridCell PreviousCell
		{
			get
			{
				return this.xf0a8fdf00cbe2562;
			}
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00013084 File Offset: 0x00012084
		internal void x036123e44626983b(GridCell xf0a8fdf00cbe2562)
		{
			this.xf0a8fdf00cbe2562 = xf0a8fdf00cbe2562;
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060002F7 RID: 759 RVA: 0x00013090 File Offset: 0x00012090
		[Browsable(false)]
		public GridCell NextCell
		{
			get
			{
				return this.xeb6b802d500361c9;
			}
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00013098 File Offset: 0x00012098
		internal void xc60422c171eeceae(GridCell xeb6b802d500361c9)
		{
			this.xeb6b802d500361c9 = xeb6b802d500361c9;
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002F9 RID: 761 RVA: 0x000130A4 File Offset: 0x000120A4
		// (set) Token: 0x060002FA RID: 762 RVA: 0x000130AC File Offset: 0x000120AC
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(true)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Data")]
		public bool IsNull
		{
			get
			{
				return this.x98c88e18b643e747;
			}
			set
			{
				if (value != this.x98c88e18b643e747)
				{
					this.x98c88e18b643e747 = value;
					if (this.ValueAffectsMeasurement())
					{
						base.MeasureNeeded();
						return;
					}
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002FB RID: 763 RVA: 0x000130D4 File Offset: 0x000120D4
		// (set) Token: 0x060002FC RID: 764 RVA: 0x000130DC File Offset: 0x000120DC
		[DefaultValue("")]
		[Description("The text in the cell.")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[Category("Data")]
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		public virtual string Text
		{
			get
			{
				return this.xb41faee6912a2313;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				this.IsNull = false;
				if (value != this.xb41faee6912a2313)
				{
					this.xb41faee6912a2313 = value;
					if (this.OnValueChanged())
					{
						return;
					}
					if (this.ValueAffectsMeasurement())
					{
						base.MeasureNeeded();
						return;
					}
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002FD RID: 765 RVA: 0x00013130 File Offset: 0x00012130
		[Browsable(false)]
		public GridColumn ParentColumn
		{
			get
			{
				return this.x4000c5d4da39e7e0;
			}
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00013138 File Offset: 0x00012138
		internal void xa08bcba111d8b3e3(GridColumn x4000c5d4da39e7e0)
		{
			this.x4000c5d4da39e7e0 = x4000c5d4da39e7e0;
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002FF RID: 767 RVA: 0x00013144 File Offset: 0x00012144
		[Browsable(false)]
		public GridRow ParentRow
		{
			get
			{
				return this.xfbf9d376a0c88d8d;
			}
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0001314C File Offset: 0x0001214C
		internal void x973e390b09c57b95(GridRow xfbf9d376a0c88d8d)
		{
			this.xfbf9d376a0c88d8d = xfbf9d376a0c88d8d;
			InnerGrid xf57b149cb3f9c03a = (xfbf9d376a0c88d8d != null) ? xfbf9d376a0c88d8d.Grid : base.Grid;
			this.xea1c0bc64ab77594(xf57b149cb3f9c03a);
		}

		// Token: 0x040000B2 RID: 178
		private GridRow xfbf9d376a0c88d8d;

		// Token: 0x040000B3 RID: 179
		private GridColumn x4000c5d4da39e7e0;

		// Token: 0x040000B4 RID: 180
		private GridCell xf0a8fdf00cbe2562;

		// Token: 0x040000B5 RID: 181
		private GridCell xeb6b802d500361c9;

		// Token: 0x040000B6 RID: 182
		private string xb41faee6912a2313 = string.Empty;

		// Token: 0x040000B7 RID: 183
		private bool x98c88e18b643e747 = true;

		// Token: 0x040000B8 RID: 184
		private Image xe058541ca798c059;

		// Token: 0x040000B9 RID: 185
		private Color x154083d58301ef75 = Color.Transparent;

		// Token: 0x040000BA RID: 186
		private Color x93532ca0ace0c1ae = SystemColors.WindowText;

		// Token: 0x040000BB RID: 187
		private Rectangle x457cd1982842ba8b;

		// Token: 0x040000BC RID: 188
		private Rectangle x0bd0d09521a6c8ef;
	}
}

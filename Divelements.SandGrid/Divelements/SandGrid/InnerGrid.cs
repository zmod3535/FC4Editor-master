using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Divelements.SandGrid.Rendering;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x0200000A RID: 10
	public class InnerGrid : GridElement
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00006170 File Offset: 0x00005170
		public InnerGrid()
		{
			this.xea1c0bc64ab77594(this);
			this.x26c511b92db96554 = new GridColumnCollection(this);
			this.x2eb5785cf1641b8b = new GridRowCollection(this);
			this.x6fa8a9b2a6c7302a = new SelectedElementCollection(this);
			this.x0c750788e1a26805 = new Hashtable();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00006278 File Offset: 0x00005278
		internal InnerGrid(FocusableGridElement parentElement) : this()
		{
			this.x65bb1537d51f4cd7 = parentElement;
			this.FixColumnHeaders = false;
			this.FixRowHeaders = false;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00006298 File Offset: 0x00005298
		internal void xe6725d062dfbcd2c(GridRowEventArgs xfbf34718e704c6bc)
		{
			if (this.SandGrid != null)
			{
				this.SandGrid.OnPopulateVirtualRow(xfbf34718e704c6bc);
			}
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000062B0 File Offset: 0x000052B0
		protected internal virtual void OnDataBindingComplete(ListChangedEventArgs e)
		{
			if (this.SandGrid != null)
			{
				this.SandGrid.OnDataBindingComplete(new DataBindingCompleteEventArgs(this, e));
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000062CC File Offset: 0x000052CC
		private GridRow xf67b988413bdb157()
		{
			return (GridRow)Activator.CreateInstance(this.NewRowType);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x000062E0 File Offset: 0x000052E0
		internal object xb007631a3756fa6f()
		{
			if (this.xebd97955e319d6dc == NullBehavior.NullReference)
			{
				return null;
			}
			return DBNull.Value;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000062F4 File Offset: 0x000052F4
		internal bool xfb724cf23e069ca8(object xbcea506a33cf9111)
		{
			return xbcea506a33cf9111 == null || (this.xebd97955e319d6dc == NullBehavior.DBNull && xbcea506a33cf9111 == DBNull.Value);
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00006310 File Offset: 0x00005310
		protected virtual void OnDataSourceChanged(EventArgs e)
		{
			this.x5a074e2e9b606ead();
			if (this.x0f405f185e70ec01 != null)
			{
				this.OnDataBindingComplete(new ListChangedEventArgs(ListChangedType.Reset, 0));
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00006330 File Offset: 0x00005330
		protected virtual void OnDataMemberChanged(EventArgs e)
		{
			this.x5a074e2e9b606ead();
			if (this.x0f405f185e70ec01 != null)
			{
				this.OnDataBindingComplete(new ListChangedEventArgs(ListChangedType.Reset, 0));
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00006350 File Offset: 0x00005350
		internal void x5a074e2e9b606ead()
		{
			this.Rows.Clear();
			this.x9d24f5984d888978();
			this.xf0cbfe5c1ab718ea();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x0000636C File Offset: 0x0000536C
		internal void xf0cbfe5c1ab718ea()
		{
			if (this.VirtualMode)
			{
				this.Rows.x0d3ed93b62f2f248 = 0;
			}
			else
			{
				this.Rows.Clear();
			}
			if (this.x748aa855543fa4ff == null)
			{
				return;
			}
			IList x06ca69422bbb = this.x748aa855543fa4ff.x06ca69422bbb7502;
			if (this.Columns.Count == 0 || x06ca69422bbb == null || x06ca69422bbb.Count == 0)
			{
				return;
			}
			if (this.VirtualMode)
			{
				this.Rows.x0d3ed93b62f2f248 = x06ca69422bbb.Count;
				return;
			}
			bool flag = this.CreateCells || this.SelectionGranularity == SelectionGranularity.Cell;
			this.xfc83e6121d4d839a(this.Rows, x06ca69422bbb, flag);
			if (this.IsNested)
			{
				this.ShowTreeButtons = this.x748aa855543fa4ff.xa2b5c987a23c14fd;
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00006420 File Offset: 0x00005420
		private void xfc83e6121d4d839a(GridRowCollection x2eb5785cf1641b8b, IList x8a0b266419f09a55, bool xac215e76df268d15)
		{
			GridRow[] array = new GridRow[x8a0b266419f09a55.Count];
			for (int i = 0; i < x8a0b266419f09a55.Count; i++)
			{
				array[i] = this.xc1876ff4ff54c391(xac215e76df268d15);
			}
			x2eb5785cf1641b8b.xc1bf1c083077a548(array);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x0000645C File Offset: 0x0000545C
		internal GridRow xc1876ff4ff54c391()
		{
			return this.xc1876ff4ff54c391(this.SelectionGranularity == SelectionGranularity.Cell);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00006470 File Offset: 0x00005470
		internal GridRow xc1876ff4ff54c391(bool xac215e76df268d15)
		{
			GridRow gridRow = xac215e76df268d15 ? this.NewRow() : this.xf67b988413bdb157();
			gridRow.ContentsUnknown = this.x748aa855543fa4ff.xa2b5c987a23c14fd;
			return gridRow;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x000064A4 File Offset: 0x000054A4
		public GridRow NewRow()
		{
			GridCell[] array = new GridCell[this.Columns.Count];
			for (int i = 0; i < this.Columns.Count; i++)
			{
				array[i] = this.Columns[i].CreateCell();
			}
			GridRow gridRow = (GridRow)Activator.CreateInstance(this.NewRowType);
			gridRow.Cells.AddRange(array);
			return gridRow;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x0000650C File Offset: 0x0000550C
		private void x9d24f5984d888978()
		{
			if (this.AutoGenerateBoundColumns)
			{
				GridColumn[] x00a0ad1e6c95f1c = (this.x748aa855543fa4ff != null) ? this.x748aa855543fa4ff.xae6f26df8c1270e0() : new GridColumn[0];
				this.xe16b680ffd448c44(x00a0ad1e6c95f1c);
				return;
			}
			foreach (object obj in this.Columns)
			{
				GridColumn xe3e287548b3d01f = (GridColumn)obj;
				this.xf7d63e21204b8665(xe3e287548b3d01f);
			}
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000065A0 File Offset: 0x000055A0
		internal void xf7d63e21204b8665(GridColumn xe3e287548b3d01f5)
		{
			if (this.x748aa855543fa4ff == null)
			{
				return;
			}
			int num = this.x748aa855543fa4ff.xadc90428d59a400d(xe3e287548b3d01f5.DataPropertyName);
			if (num == -1)
			{
				xe3e287548b3d01f5.x42d80cc5d994096e(false, 0, null);
				return;
			}
			xe3e287548b3d01f5.x42d80cc5d994096e(true, num, this.x748aa855543fa4ff.x0c3a53005d4854a4(num));
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000065EC File Offset: 0x000055EC
		private void xe16b680ffd448c44(GridColumn[] x00a0ad1e6c95f1c3)
		{
			for (int i = this.Columns.Count - 1; i >= 0; i--)
			{
				GridColumn gridColumn = this.Columns[i];
				if (gridColumn.IsDataBound)
				{
					this.xf7d63e21204b8665(gridColumn);
					if (!gridColumn.IsDataBound)
					{
						this.Columns.RemoveAt(i);
					}
				}
			}
			foreach (GridColumn gridColumn2 in x00a0ad1e6c95f1c3)
			{
				GridColumn gridColumn3 = null;
				foreach (object obj in this.Columns)
				{
					GridColumn gridColumn4 = (GridColumn)obj;
					if (string.Compare(gridColumn4.DataPropertyName, gridColumn2.DataPropertyName, true, CultureInfo.InvariantCulture) == 0)
					{
						gridColumn3 = gridColumn4;
						break;
					}
				}
				if (gridColumn3 == null)
				{
					this.Columns.Add(gridColumn2);
				}
				else
				{
					this.xf7d63e21204b8665(gridColumn3);
				}
			}
		}

		// Token: 0x06000086 RID: 134 RVA: 0x000066F8 File Offset: 0x000056F8
		internal void xf3a047092bd321fb()
		{
			Rectangle bounds = base.Bounds;
			if (!this.IsNested)
			{
				bounds.Width = Math.Max(bounds.Width, this.SandGrid.Width);
			}
			bounds.Height = this.x5d332e6bd470be29;
			if (!this.FixColumnHeaders)
			{
				bounds.Offset(0, -this.SandGrid.VScrollOffset);
			}
			this.SandGrid.Invalidate(bounds);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00006768 File Offset: 0x00005768
		internal void x5e7a70d58e13247a(GridElement x4bbc2c453c470189)
		{
			if (this.SandGrid != null)
			{
				Rectangle bounds = x4bbc2c453c470189.Bounds;
				if (x4bbc2c453c470189 is GridRow && this.ShowRowHeaders)
				{
					if (!this.RightToLeft)
					{
						bounds.X -= this.RowHeaderSize;
					}
					bounds.Width += this.RowHeaderSize;
				}
				if (x4bbc2c453c470189 is GridColumn)
				{
					bounds.Offset(-this.SandGrid.HScrollOffset, 0);
					if (!this.FixColumnHeaders)
					{
						bounds.Offset(0, -this.SandGrid.VScrollOffset);
					}
				}
				else
				{
					bounds.Offset(-this.SandGrid.HScrollOffset, -this.SandGrid.VScrollOffset);
				}
				bounds.Inflate(2, 2);
				this.SandGrid.Invalidate(bounds);
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00006838 File Offset: 0x00005838
		internal void x5e7a70d58e13247a()
		{
			if (this.SandGrid != null)
			{
				this.SandGrid.Invalidate();
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006850 File Offset: 0x00005850
		internal void x5e7a70d58e13247a(Rectangle xda73fcb97c77d998)
		{
			if (this.SandGrid != null)
			{
				xda73fcb97c77d998.Offset(-this.SandGrid.HScrollOffset, -this.SandGrid.VScrollOffset);
				xda73fcb97c77d998.Inflate(2, 2);
				this.SandGrid.Invalidate(xda73fcb97c77d998);
			}
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006890 File Offset: 0x00005890
		protected internal new void MeasureNeeded()
		{
			this.xfd402592e32abf89 = true;
			if (this.x65bb1537d51f4cd7 != null)
			{
				this.x65bb1537d51f4cd7.MeasureNeeded();
				return;
			}
			if (this.xaf05a2aec36f5b1b != null)
			{
				this.xaf05a2aec36f5b1b.x0a85a0778e92d09a();
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000068C0 File Offset: 0x000058C0
		protected virtual void OnBeforeMeasure(Size viewportSize)
		{
			GridColumn[] displayColumns = this.Columns.DisplayColumns;
			viewportSize.Width = Math.Max(viewportSize.Width, 0);
			viewportSize.Height = Math.Max(viewportSize.Height, 0);
			double[] array = new double[displayColumns.Length];
			double num = 0.0;
			double num2 = 0.0;
			int num3 = 0;
			int[] array2;
			for (;;)
			{
				if (num3 >= array.Length)
				{
					double num4;
					if (num2 < (double)viewportSize.Width && num != 0.0)
					{
						num4 = (double)viewportSize.Width - num2;
						for (int i = 0; i < array.Length; i++)
						{
							if (displayColumns[i].AutoSize == ColumnAutoSizeMode.Spring)
							{
								array[i] = array[i] / num * num4;
								displayColumns[i].x339a6432324e0276(array[i], false);
							}
						}
					}
					array2 = new int[array.Length];
					bool flag = (uint)num4 + (uint)num3 > uint.MaxValue;
					int num5;
					if (!flag)
					{
						num5 = -1;
						int num6 = viewportSize.Width;
						for (int j = 0; j < array.Length; j++)
						{
							array2[j] = Convert.ToInt32(array[j]);
							num6 -= array2[j];
							if (displayColumns[j].AutoSize == ColumnAutoSizeMode.Spring)
							{
								num5 = j;
							}
						}
						if (num5 == -1)
						{
							break;
						}
						array2[num5] = Math.Max(array2[num5] + num6, 0);
					}
					if ((uint)num5 - (uint)num2 <= 4294967295U)
					{
						break;
					}
				}
				else if (displayColumns[num3].AutoSize == ColumnAutoSizeMode.Contents)
				{
					int num7 = displayColumns[num3].GetMaximumCellWidth(RowScope.AllRows, displayColumns[num3].AutoSizeIncludeHeader);
					num7 = Math.Max(num7, displayColumns[num3].MinimumWidth);
					displayColumns[num3].x339a6432324e0276((double)num7, true);
				}
				array[num3] = displayColumns[num3].x47ffa6f239bcee85;
				if (displayColumns[num3].AutoSize == ColumnAutoSizeMode.Spring)
				{
					num += array[num3];
				}
				else
				{
					num2 += array[num3];
				}
				num3++;
			}
			for (int k = 0; k < displayColumns.Length; k++)
			{
				displayColumns[k].x339a6432324e0276((double)array2[k], true);
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006AD4 File Offset: 0x00005AD4
		internal Size x2f9881556fe66cc1(Graphics x41347a961b838962, bool x1158f70b6f5fc38e, Size x259e6cf08f9b90c9)
		{
			if (this.x55d7940cc2a8ddcb)
			{
				this.x55d7940cc2a8ddcb = false;
				this.Rows.x7f80f55d120d7028();
			}
			if (this.Columns.Count == 0)
			{
				return Size.Empty;
			}
			int num;
			Size size;
			for (;;)
			{
				IL_19F:
				this.x1b8f3af6e4cefe91();
				this.OnBeforeMeasure(x259e6cf08f9b90c9);
				int num2;
				if (!this.ShowRowHeaders)
				{
					bool flag = (uint)num + (uint)num > uint.MaxValue;
					if (flag)
					{
						break;
					}
					num2 = 0;
				}
				else
				{
					num2 = this.RowHeaderSize;
				}
				num = num2;
				this.xdccb30ad7b37c1d8 = 0;
				for (int i = 0; i < this.Columns.DisplayColumns.Length; i++)
				{
					GridColumn gridColumn = this.Columns.DisplayColumns[i];
					if (gridColumn.x46eefbccf8310105)
					{
						using (TextFormattingInformation xae3b2752a89e = gridColumn.CreateTextFormat(GridColumnTextFormatType.Header))
						{
							gridColumn.x2f9881556fe66cc1(x41347a961b838962, xae3b2752a89e, x1158f70b6f5fc38e);
							goto IL_10;
						}
						IL_187:
						int j;
						bool flag = (uint)i + (uint)j < 0U;
						if (flag)
						{
							goto IL_19F;
						}
						goto IL_1D2;
					}
					IL_10:
					this.xdccb30ad7b37c1d8 = Math.Max(this.xdccb30ad7b37c1d8, gridColumn.x95f43364065e63e8.Height);
					num += gridColumn.x95f43364065e63e8.Width;
				}
				if (!this.ShowColumnHeaders)
				{
					this.xdccb30ad7b37c1d8 = 0;
				}
				TextFormattingInformation[] array = new TextFormattingInformation[this.Columns.DisplayColumns.Length];
				for (int k = 0; k < this.Columns.DisplayColumns.Length; k++)
				{
					array[k] = this.Columns.DisplayColumns[k].CreateTextFormat(GridColumnTextFormatType.Cell);
				}
				if (this.Columns.x4cc5a926eb940d8c && num < x259e6cf08f9b90c9.Width)
				{
					num = x259e6cf08f9b90c9.Width;
				}
				size = this.xaa375228b31c99b9(x41347a961b838962, x1158f70b6f5fc38e);
				num = Math.Max(num, size.Width + (this.ShowRowHeaders ? this.RowHeaderSize : 0));
				for (int j = 0; j < array.Length; j++)
				{
					array[j].Dispose();
				}
				this.xfd402592e32abf89 = false;
				goto IL_187;
			}
			IL_1D2:
			return new Size(num, this.xdccb30ad7b37c1d8 + size.Height);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00006D0C File Offset: 0x00005D0C
		private Size xaa375228b31c99b9(Graphics x41347a961b838962, bool x1158f70b6f5fc38e)
		{
			int num = 0;
			int num2 = 0;
			if (this.VirtualMode)
			{
				return new Size(0, this.VirtualRowSize * this.VirtualRowCount);
			}
			foreach (object obj in this.FlatVisibleRows)
			{
				GridRow gridRow = (GridRow)obj;
				if (gridRow.x149bf25701697822)
				{
					num2 += this.GroupHeadingHeight;
				}
				if (gridRow.Height != 0)
				{
					num2 += gridRow.Height;
				}
				else
				{
					gridRow.x2f9881556fe66cc1(x41347a961b838962, default(TextFormattingInformation), x1158f70b6f5fc38e);
					num2 += gridRow.x95f43364065e63e8.Height;
					num = Math.Max(num, gridRow.x95f43364065e63e8.Width);
				}
			}
			foreach (object obj2 in this.Groups)
			{
				GridGroup gridGroup = (GridGroup)obj2;
				if (!gridGroup.Expanded)
				{
					num2 += this.GroupHeadingHeight;
				}
			}
			return new Size(num, num2);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00006E5C File Offset: 0x00005E5C
		public GridRow GetFirstVisibleRow()
		{
			if (this.Rows.Count == 0)
			{
				return null;
			}
			for (int i = 0; i < this.Rows.Count; i++)
			{
				if (this.Rows[i].xe0f8497fba2e6972)
				{
					return this.Rows[i];
				}
			}
			return null;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00006EB0 File Offset: 0x00005EB0
		internal GridRow x92c95e0e04930cdc()
		{
			if (this.Rows.Count == 0)
			{
				return null;
			}
			for (int i = this.Rows.Count - 1; i >= 0; i--)
			{
				if (this.Rows[i].xe0f8497fba2e6972)
				{
					return GridRow.x194adc7ea8a52ece(this.Rows[i]);
				}
			}
			return null;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00006F0C File Offset: 0x00005F0C
		private int[] x6fb3e855709d3c98()
		{
			GridColumn[] displayColumns = this.Columns.DisplayColumns;
			int[] array = new int[displayColumns.Length];
			for (int i = 0; i < displayColumns.Length; i++)
			{
				array[i] = Convert.ToInt32(displayColumns[i].x47ffa6f239bcee85);
			}
			return array;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006F50 File Offset: 0x00005F50
		internal void xea337a435dab7e27(bool x1158f70b6f5fc38e)
		{
			this.x1158f70b6f5fc38e = x1158f70b6f5fc38e;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00006F5C File Offset: 0x00005F5C
		protected override void LayoutCore(Rectangle bounds)
		{
			int num;
			int[] array;
			if (this.Columns.Count == 0)
			{
				bool flag = (uint)num + (uint)num < 0U;
				if (!flag)
				{
					return;
				}
			}
			else
			{
				array = this.x6fb3e855709d3c98();
			}
			int num2;
			if (!this.RightToLeft)
			{
				if ((uint)num - (uint)num < 0U)
				{
					goto IL_82;
				}
				num2 = bounds.Left + (this.ShowRowHeaders ? this.RowHeaderSize : 0);
			}
			else
			{
				num2 = bounds.Right - (this.ShowRowHeaders ? this.RowHeaderSize : 0);
			}
			num = num2;
			GridColumn gridColumn = null;
			IL_82:
			for (int i = 0; i < this.Columns.DisplayColumns.Length; i++)
			{
				GridColumn gridColumn2 = this.Columns.DisplayColumns[i];
				gridColumn2.x7f6db6e1f780f13e(gridColumn);
				if (gridColumn != null)
				{
					gridColumn.x963a097b6cf9e341(gridColumn2);
				}
				gridColumn = gridColumn2;
				Rectangle xda73fcb97c77d = this.RightToLeft ? new Rectangle(num - array[i], bounds.Top, array[i], this.xdccb30ad7b37c1d8) : new Rectangle(num, bounds.Top, array[i], this.xdccb30ad7b37c1d8);
				gridColumn2.xb7ae55095fddecd9(xda73fcb97c77d);
				if (this.RightToLeft)
				{
					num -= array[i];
				}
				else
				{
					num += array[i];
				}
			}
			if (gridColumn != null)
			{
				gridColumn.x963a097b6cf9e341(null);
			}
			if (this.Rows.Count != 0)
			{
				this.xaf3fc6da08a29f0f(this.x1158f70b6f5fc38e);
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000070BC File Offset: 0x000060BC
		private Rectangle x48db5ea2b2f9d02a()
		{
			int num = this.ShowRowHeaders ? this.RowHeaderSize : 0;
			if (this.RightToLeft)
			{
				return new Rectangle(base.Bounds.Left, base.Bounds.Top + this.xdccb30ad7b37c1d8, base.Bounds.Width - num, base.Bounds.Height - this.xdccb30ad7b37c1d8);
			}
			return new Rectangle(base.Bounds.Left + num, base.Bounds.Top + this.xdccb30ad7b37c1d8, base.Bounds.Width - num, base.Bounds.Height - this.xdccb30ad7b37c1d8);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00007188 File Offset: 0x00006188
		private void x1b8f3af6e4cefe91()
		{
			ulong num = 0UL;
			int num2 = 0;
			StringCollection stringCollection = new StringCollection();
			string[] array = new string[this.x0c750788e1a26805.Keys.Count];
			this.x0c750788e1a26805.Keys.CopyTo(array, 0);
			stringCollection.AddRange(array);
			foreach (string key in stringCollection)
			{
				GridGroup gridGroup = (GridGroup)this.x0c750788e1a26805[key];
				gridGroup.x560d4dfd1783eedd(null, null);
			}
			GridRow gridRow = null;
			this.x40dfb56db6a6a335(this.Rows, 0, this.Columns.xe8ecae63c9eb7749, ref num, ref num2, ref gridRow, stringCollection);
			foreach (string key2 in stringCollection)
			{
				GridGroup gridGroup2 = (GridGroup)this.x0c750788e1a26805[key2];
				gridGroup2.xea1c0bc64ab77594(null);
				gridGroup2.x560d4dfd1783eedd(null, null);
				this.x0c750788e1a26805.Remove(key2);
			}
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000072DC File Offset: 0x000062DC
		private void x40dfb56db6a6a335(GridRowCollection x2eb5785cf1641b8b, int x66bbd7ed8c65740d, GridColumn[] x26c511b92db96554, ref ulong xc1e8377a82d87d1c, ref int x41fda6c4e54abab3, ref GridRow xafdad421dc58a810, StringCollection x5e2402ad9ec300ea)
		{
			bool x07f145bc17390dde = x2eb5785cf1641b8b.x07f145bc17390dde;
			GridColumn gridColumn = x07f145bc17390dde ? this.GroupColumn : null;
			GridGroup gridGroup = null;
			object obj = null;
			xc1e8377a82d87d1c |= (ulong)Math.Pow(2.0, (double)x66bbd7ed8c65740d);
			int num = 0;
			using (IEnumerator enumerator = x2eb5785cf1641b8b.GetEnumerator())
			{
				for (;;)
				{
					if (enumerator.MoveNext())
					{
						goto IL_123;
					}
					bool flag = (uint)num + (uint)x66bbd7ed8c65740d > uint.MaxValue;
					if (!flag)
					{
						goto IL_1C5;
					}
					if (2147483647 == 0)
					{
						goto IL_A8;
					}
					goto IL_123;
					IL_71:
					num++;
					continue;
					IL_A8:
					if (2147483647 == 0)
					{
						continue;
					}
					GridRow gridRow;
					xafdad421dc58a810 = gridRow;
					x41fda6c4e54abab3++;
					if (gridRow.HasRows && gridRow.Expanded)
					{
						this.x40dfb56db6a6a335(gridRow.NestedRows, x66bbd7ed8c65740d + 1, x26c511b92db96554, ref xc1e8377a82d87d1c, ref x41fda6c4e54abab3, ref xafdad421dc58a810, x5e2402ad9ec300ea);
						goto IL_71;
					}
					goto IL_71;
					IL_123:
					gridRow = (GridRow)enumerator.Current;
					if (num == x2eb5785cf1641b8b.Count - 1)
					{
						xc1e8377a82d87d1c &= ~(ulong)Math.Pow(2.0, (double)x66bbd7ed8c65740d);
					}
					string text;
					bool x10aaa7cdfa38f;
					if (x07f145bc17390dde && !gridRow.GetFilteredOut() && !gridColumn.IsSameGroup(gridRow, ref obj, out text))
					{
						gridGroup = (GridGroup)this.x0c750788e1a26805[text];
						if (gridGroup == null)
						{
							gridGroup = new GridGroup(text);
							gridGroup.xea1c0bc64ab77594(this);
							this.x0c750788e1a26805[text] = gridGroup;
						}
						else
						{
							x5e2402ad9ec300ea.Remove(text);
						}
						if (gridGroup.xa19781cfbe8b4961 != null)
						{
							break;
						}
						gridGroup.x560d4dfd1783eedd(gridRow, xafdad421dc58a810);
						x10aaa7cdfa38f = true;
					}
					else
					{
						x10aaa7cdfa38f = false;
					}
					gridRow.x219ece04845720d2(gridGroup, x10aaa7cdfa38f);
					if (!gridRow.GetFilteredOut())
					{
						gridRow.xd4cf973b1f100cf3(x66bbd7ed8c65740d);
						if (this.ShowTreeLines)
						{
							gridRow.xa2a14afe900d2107(xc1e8377a82d87d1c);
						}
						gridRow.xbd2f66a95763069d(x41fda6c4e54abab3);
						goto IL_A8;
					}
					goto IL_71;
				}
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionRowsNotSortedProperlyForGrouping"));
				IL_1C5:;
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000074E4 File Offset: 0x000064E4
		internal void xc78f81acf21786e9(GridRow xa806b754814b9ae0)
		{
			Rectangle rectangle = this.x48db5ea2b2f9d02a();
			NestedGridRow nestedGridRow = xa806b754814b9ae0 as NestedGridRow;
			xa806b754814b9ae0.xb7ae55095fddecd9(new Rectangle(rectangle.Left, rectangle.Top + this.xefee12953e30df70 * xa806b754814b9ae0.Index, rectangle.Width, this.xefee12953e30df70));
			xa806b754814b9ae0.LayoutCells(this.Columns.xe8ecae63c9eb7749, this.Columns.DisplayColumns, this.PrimaryColumn);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00007558 File Offset: 0x00006558
		private void xaf3fc6da08a29f0f(bool x1158f70b6f5fc38e)
		{
			Rectangle xda73fcb97c77d = this.x48db5ea2b2f9d02a();
			if (this.VirtualMode)
			{
				using (IEnumerator enumerator = this.Rows.x4a7996023abdc9e3.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						GridRow gridRow = (GridRow)obj;
						gridRow.xb7ae55095fddecd9(new Rectangle(xda73fcb97c77d.Left, xda73fcb97c77d.Top + this.xefee12953e30df70 * gridRow.Index, xda73fcb97c77d.Width, this.xefee12953e30df70));
						gridRow.LayoutCells(this.Columns.xe8ecae63c9eb7749, this.Columns.DisplayColumns, this.PrimaryColumn);
					}
					return;
				}
			}
			int top = xda73fcb97c77d.Top;
			GridColumn primaryColumn = this.PrimaryColumn;
			this.xd701294cb1e8b65e(x1158f70b6f5fc38e, xda73fcb97c77d, this.Rows, ref top, this.Columns.xe8ecae63c9eb7749, this.Columns.DisplayColumns, primaryColumn);
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00007660 File Offset: 0x00006660
		private void xd701294cb1e8b65e(bool x1158f70b6f5fc38e, Rectangle xda73fcb97c77d998, GridRowCollection x2eb5785cf1641b8b, ref int x1e218ceaee1bb583, GridColumn[] x6b5d35ac2bbc76ff, GridColumn[] xb2cfa94692dcec88, GridColumn xed51a408ad164d62)
		{
			bool x07f145bc17390dde = x2eb5785cf1641b8b.x07f145bc17390dde;
			foreach (object obj in x2eb5785cf1641b8b)
			{
				GridRow gridRow = (GridRow)obj;
				if (x07f145bc17390dde && gridRow.x149bf25701697822)
				{
					Rectangle xda73fcb97c77d999 = new Rectangle(xda73fcb97c77d998.Left, x1e218ceaee1bb583, xda73fcb97c77d998.Width, this.GroupHeadingHeight);
					gridRow.Group.xb7ae55095fddecd9(xda73fcb97c77d999);
					x1e218ceaee1bb583 += xda73fcb97c77d999.Height;
				}
				if (gridRow.xe0f8497fba2e6972)
				{
					if (gridRow.Height == 0)
					{
						int num = (gridRow.x95f43364065e63e8.Width == 0) ? xda73fcb97c77d998.Width : gridRow.x95f43364065e63e8.Width;
						if (this.RightToLeft)
						{
							if (-2147483648 == 0)
							{
								goto IL_16E;
							}
							gridRow.xb7ae55095fddecd9(new Rectangle(xda73fcb97c77d998.Right - num, x1e218ceaee1bb583, num, gridRow.x95f43364065e63e8.Height));
						}
						else
						{
							gridRow.xb7ae55095fddecd9(new Rectangle(xda73fcb97c77d998.Left, x1e218ceaee1bb583, num, gridRow.x95f43364065e63e8.Height));
						}
						x1e218ceaee1bb583 += gridRow.x95f43364065e63e8.Height;
					}
					else
					{
						gridRow.xb7ae55095fddecd9(new Rectangle(xda73fcb97c77d998.Left, x1e218ceaee1bb583, xda73fcb97c77d998.Width, gridRow.Height));
						x1e218ceaee1bb583 += gridRow.Height;
					}
					IL_16E:
					gridRow.LayoutCells(x6b5d35ac2bbc76ff, xb2cfa94692dcec88, xed51a408ad164d62);
					if (gridRow.HasRows && gridRow.Expanded)
					{
						this.xd701294cb1e8b65e(x1158f70b6f5fc38e, xda73fcb97c77d998, gridRow.NestedRows, ref x1e218ceaee1bb583, x6b5d35ac2bbc76ff, xb2cfa94692dcec88, xed51a408ad164d62);
					}
				}
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000782C File Offset: 0x0000682C
		internal void xe38b34b4ef5b24ed(RenderingContext x0f7b23d1c393aed9)
		{
			if (this.Columns.Count != 0 && this.ShowColumnHeaders && this.FixColumnHeaders)
			{
				this.xea9c828ba028b2d7(x0f7b23d1c393aed9);
			}
			if (this.x2e028e8ac31e061f)
			{
				this.SandGrid.Renderer.DrawCorner(x0f7b23d1c393aed9.Graphics, this.x5eaebf6c9f7916f3);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00007884 File Offset: 0x00006884
		private void xea9c828ba028b2d7(RenderingContext x0f7b23d1c393aed9)
		{
			int num = this.RightToLeft ? int.MaxValue : 0;
			this.x86b14c423a0c12f3 = null;
			for (int i = 0; i < x0f7b23d1c393aed9.x29fd0770898d0daa.Length; i++)
			{
				using (TextFormattingInformation textFormat = x0f7b23d1c393aed9.x29fd0770898d0daa[i].CreateTextFormat(GridColumnTextFormatType.Header))
				{
					x0f7b23d1c393aed9.x29fd0770898d0daa[i].DrawHeader(x0f7b23d1c393aed9, textFormat);
				}
				if (this.RightToLeft)
				{
					num = Math.Min(num, x0f7b23d1c393aed9.x29fd0770898d0daa[i].Bounds.Left);
				}
				else
				{
					num = Math.Max(num, x0f7b23d1c393aed9.x29fd0770898d0daa[i].Bounds.Right);
				}
			}
			if (num == 2147483647)
			{
				num = 0;
			}
			if (this.x2e028e8ac31e061f)
			{
				Rectangle bounds = this.RightToLeft ? new Rectangle(base.Bounds.Right - this.RowHeaderSize, base.Bounds.Top, this.RowHeaderSize, this.x5d332e6bd470be29) : new Rectangle(base.Bounds.Left, base.Bounds.Top, this.RowHeaderSize, this.x5d332e6bd470be29);
				this.SandGrid.Renderer.DrawCorner(x0f7b23d1c393aed9.Graphics, bounds);
			}
			if (!x0f7b23d1c393aed9.Printing && -1 != 0)
			{
				Rectangle bounds2;
				if (this.RightToLeft)
				{
					bounds2 = new Rectangle(base.Bounds.Left, base.Bounds.Top, num - base.Bounds.Left, this.x5d332e6bd470be29);
				}
				else if (!this.IsNested)
				{
					bounds2 = new Rectangle(num, base.Bounds.Top, this.SandGrid.HScrollOffset + 2 + this.SandGrid.ClientRectangle.Width - num, this.x5d332e6bd470be29);
				}
				else
				{
					bounds2 = new Rectangle(num, base.Bounds.Top, base.Bounds.Right - num, this.x5d332e6bd470be29);
				}
				if (bounds2.Width > 0)
				{
					x0f7b23d1c393aed9.Renderer.DrawColumnHeader(x0f7b23d1c393aed9.Graphics, null, bounds2, default(TextFormattingInformation), Divelements.SandGrid.Rendering.DrawItemState.None);
				}
				if (this.x86b14c423a0c12f3 != null && !x0f7b23d1c393aed9.Printing)
				{
					this.x86b14c423a0c12f3.xb71ffb553d86d907(x0f7b23d1c393aed9);
					this.x86b14c423a0c12f3 = null;
				}
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007B28 File Offset: 0x00006B28
		internal void xa773e3fe39c24b95(RenderingContext x0f7b23d1c393aed9)
		{
			if (this.Columns.Count != 0 && this.Rows.Count != 0 && this.ShowRowHeaders && this.FixRowHeaders)
			{
				this.x14295bd0cde2ff5d(x0f7b23d1c393aed9, true);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00007B60 File Offset: 0x00006B60
		private bool x2e028e8ac31e061f
		{
			get
			{
				return this.Columns.Count != 0 && this.ShowRowHeaders && (this.FixRowHeaders || this.IsNested) && this.ShowColumnHeaders && (this.FixColumnHeaders || this.IsNested);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00007BAC File Offset: 0x00006BAC
		private Rectangle x5eaebf6c9f7916f3
		{
			get
			{
				if (this.RightToLeft)
				{
					return new Rectangle(base.Bounds.Right - this.RowHeaderSize, base.Bounds.Top, this.RowHeaderSize, this.x5d332e6bd470be29);
				}
				return new Rectangle(base.Bounds.Left, base.Bounds.Top, this.RowHeaderSize, this.x5d332e6bd470be29);
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00007C24 File Offset: 0x00006C24
		internal RenderingContext xd916e3d12d2ec8e1(Graphics x41347a961b838962, bool x21495198a04e77be, int xafa125fec9c28c53, int xf61c42a5d8298218)
		{
			RenderingContext renderingContext;
			if (x21495198a04e77be)
			{
				renderingContext = new RenderingContext(x41347a961b838962, this.SandGrid.Renderer, true, this.SandGrid.Font, false, false, null, null, true, this.SandGrid.Renderer.CreateGridLinePen(), xafa125fec9c28c53, xf61c42a5d8298218);
				renderingContext.x29fd0770898d0daa = this.Columns.DisplayColumns;
			}
			else
			{
				GridRow xda48682af7b = this.SandGrid.xda48682af7b76596;
				GridCell cellWithFocus = this.SandGrid.FocusedElement as GridCell;
				bool hideSelection = this.HideSelection && (this.SandGrid.ActiveGrid != this || !this.SandGrid.Focused);
				renderingContext = new RenderingContext(x41347a961b838962, this.SandGrid.Renderer, false, this.SandGrid.Font, this.SandGrid.Focused && this.SandGrid.ActiveGrid == this, this.SandGrid.x0f67de551fd13731 && this.SandGrid.ActiveGrid == this, xda48682af7b, cellWithFocus, hideSelection, this.SandGrid.Renderer.CreateGridLinePen(), xafa125fec9c28c53, xf61c42a5d8298218);
				renderingContext.x29fd0770898d0daa = new GridColumn[this.VisibleColumnCount];
				for (int i = 0; i < this.VisibleColumnCount; i++)
				{
					renderingContext.x29fd0770898d0daa[i] = this.Columns.DisplayColumns[this.FirstVisibleColumn + i];
				}
			}
			renderingContext.xde71c10cc59cfe08(this.SandGrid.FocusedElement);
			renderingContext.x7b70952c02a0fb86 = new TextFormattingInformation[renderingContext.x29fd0770898d0daa.Length];
			for (int j = 0; j < renderingContext.x7b70952c02a0fb86.Length; j++)
			{
				renderingContext.x7b70952c02a0fb86[j] = renderingContext.x29fd0770898d0daa[j].CreateTextFormat(GridColumnTextFormatType.Cell);
			}
			return renderingContext;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00007DDC File Offset: 0x00006DDC
		internal void xa1c45a8b0a8e79d9(RenderingContext x0f7b23d1c393aed9)
		{
			foreach (TextFormattingInformation textFormattingInformation in x0f7b23d1c393aed9.x7b70952c02a0fb86)
			{
				textFormattingInformation.Dispose();
			}
			x0f7b23d1c393aed9.GridLinePen.Dispose();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00007E20 File Offset: 0x00006E20
		internal x9c22e59a9d485e4d x7f63857195e5d213(RenderingContext x0f7b23d1c393aed9)
		{
			x9c22e59a9d485e4d result = default(x9c22e59a9d485e4d);
			for (;;)
			{
				if (this.IsNested)
				{
					x0f7b23d1c393aed9.Graphics.FillRectangle(SystemBrushes.Window, base.Bounds);
				}
				if (this.Columns.Count == 0)
				{
					break;
				}
				foreach (GridColumn gridColumn in x0f7b23d1c393aed9.x29fd0770898d0daa)
				{
					gridColumn.DrawBackground(x0f7b23d1c393aed9, new Rectangle(gridColumn.Bounds.Left, base.Bounds.Top, gridColumn.Bounds.Width, base.Bounds.Height));
				}
				if (this.Rows.Count != 0)
				{
					result = this.x14295bd0cde2ff5d(x0f7b23d1c393aed9, false);
				}
				foreach (object obj in this.Groups)
				{
					GridGroup gridGroup = (GridGroup)obj;
					if (!gridGroup.Expanded && gridGroup.Bounds.Bottom >= x0f7b23d1c393aed9.x540a99e0b172a09e && gridGroup.Bounds.Top < x0f7b23d1c393aed9.xc59eabb55ae986f8)
					{
						gridGroup.Draw(x0f7b23d1c393aed9);
					}
				}
				if (GridElement.x263912479c3c5786 != null && GridElement.x263912479c3c5786.x03bb6a33fcd217b4 == this)
				{
					x73d5582560af03ef x73d5582560af03ef = GridElement.x263912479c3c5786 as x73d5582560af03ef;
					if (x73d5582560af03ef != null)
					{
						x73d5582560af03ef.x84b6f3c22477dacb(x0f7b23d1c393aed9);
					}
				}
				if (this.ShowColumnHeaders)
				{
					int num;
					if (((uint)num | 255U) == 0U)
					{
						continue;
					}
					if (!this.FixColumnHeaders)
					{
						this.xea9c828ba028b2d7(x0f7b23d1c393aed9);
					}
				}
				if (this.VerticalMarkerPosition != -1)
				{
					Rectangle bounds = base.Bounds;
					if (false)
					{
						break;
					}
					int y = Math.Max(bounds.Top + this.x5d332e6bd470be29, this.SandGrid.VScrollOffset + this.x5d332e6bd470be29);
					int num = Math.Min(base.Bounds.Bottom - 1, this.SandGrid.ClientRectangle.Bottom + this.SandGrid.VScrollOffset);
					using (Pen pen = x0f7b23d1c393aed9.Renderer.CreateResizeHintPen())
					{
						x0f7b23d1c393aed9.Graphics.DrawLine(pen, this.VerticalMarkerPosition, y, this.VerticalMarkerPosition, num);
					}
				}
				if (this.HorizontalMarkerPosition == -1)
				{
					break;
				}
				using (Pen pen2 = x0f7b23d1c393aed9.Renderer.CreateResizeHintPen())
				{
					x0f7b23d1c393aed9.Graphics.DrawLine(pen2, base.Bounds.Left, this.HorizontalMarkerPosition, base.Bounds.Right - 1, this.HorizontalMarkerPosition);
					break;
				}
			}
			return result;
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00008138 File Offset: 0x00007138
		private bool x3ccd9f3d0472952f
		{
			get
			{
				return this.x65bb1537d51f4cd7 == null && !SandGridPrintDocument.x3d11e516f9ed38e7;
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000814C File Offset: 0x0000714C
		private x9c22e59a9d485e4d x14295bd0cde2ff5d(RenderingContext x0f7b23d1c393aed9, bool x48d1c33294a7dd40)
		{
			x9c22e59a9d485e4d result = default(x9c22e59a9d485e4d);
			bool flag2;
			bool flag = (flag2 ? 1U : 0U) + (flag2 ? 1U : 0U) > uint.MaxValue;
			if (!flag)
			{
				goto IL_57;
			}
			IL_20:
			GridRow gridRow;
			result.x78e5b86be0df3240 = gridRow.Bounds.Bottom;
			IL_36:
			int num;
			num++;
			IL_3A:
			if (num >= 2147483647)
			{
				flag = ((flag2 ? 1U : 0U) < 0U);
				if (flag)
				{
					goto IL_57;
				}
			}
			else
			{
				gridRow = ((gridRow == null) ? (this.x3ccd9f3d0472952f ? this.x699c923a60e155ff : this.GetFirstVisibleRow()) : gridRow.NextVisibleRow);
				if (gridRow != null)
				{
					if (gridRow.Bounds.Bottom < x0f7b23d1c393aed9.x540a99e0b172a09e)
					{
						goto IL_36;
					}
					if (gridRow.Bounds.Top > x0f7b23d1c393aed9.xc59eabb55ae986f8)
					{
						if ((flag2 ? 1U : 0U) < 0U)
						{
							goto IL_119;
						}
						if (!gridRow.x149bf25701697822)
						{
							return result;
						}
					}
					if (x48d1c33294a7dd40)
					{
						goto IL_125;
					}
					gridRow.DrawRowBackground(x0f7b23d1c393aed9);
					gridRow.DrawRowForeground(x0f7b23d1c393aed9, gridRow.Bounds, x0f7b23d1c393aed9.x29fd0770898d0daa, x0f7b23d1c393aed9.x7b70952c02a0fb86);
					if (!gridRow.x149bf25701697822)
					{
						goto IL_125;
					}
					IL_119:
					gridRow.Group.Draw(x0f7b23d1c393aed9);
					IL_125:
					if (!flag2 || x0f7b23d1c393aed9.x7b70952c02a0fb86.Length == 0)
					{
						goto IL_20;
					}
					gridRow.DrawHeader(x0f7b23d1c393aed9, x0f7b23d1c393aed9.x7b70952c02a0fb86[0]);
					flag = ((flag2 ? 1U : 0U) + (x48d1c33294a7dd40 ? 1U : 0U) < 0U);
					if (!flag)
					{
						goto IL_20;
					}
				}
			}
			return result;
			IL_57:
			flag2 = (x48d1c33294a7dd40 || (this.ShowRowHeaders && !this.FixRowHeaders));
			gridRow = null;
			num = 0;
			goto IL_3A;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000082C8 File Offset: 0x000072C8
		private void x266134e26f4bcc76(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x5e7a70d58e13247a();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000082D0 File Offset: 0x000072D0
		internal void xd1cd3159d407b7fd(GridColumn xe3e287548b3d01f5)
		{
			this.x5ab08995c9dbf0e5 = xe3e287548b3d01f5;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x000082DC File Offset: 0x000072DC
		public void ClearSort()
		{
			this.SetSort(new GridColumn[0], new ListSortDirection[0]);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000082F0 File Offset: 0x000072F0
		private void x5dc6ef116f899d67()
		{
			if (this.GroupColumn == null && this.SortColumn == null)
			{
				this.ClearSort();
				return;
			}
			if (this.GroupColumn == null && this.SortColumn != null)
			{
				this.SetSort(new GridColumn[]
				{
					this.SortColumn
				}, new ListSortDirection[]
				{
					this.SortDirection
				});
				return;
			}
			if (this.GroupColumn != null && this.SortColumn == null)
			{
				this.SetSort(new GridColumn[]
				{
					this.GroupColumn
				}, new ListSortDirection[]
				{
					this.GroupDirection
				});
				return;
			}
			this.SetSort(new GridColumn[]
			{
				this.GroupColumn,
				this.SortColumn
			}, new ListSortDirection[]
			{
				this.GroupDirection,
				this.SortDirection
			});
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000083C8 File Offset: 0x000073C8
		internal void x08643629319da08d(GridColumn[] x26c511b92db96554, ListSortDirection[] x0835ff38739ed7ac)
		{
			if (x26c511b92db96554.Length != 0)
			{
				if (this.x5ab08995c9dbf0e5 == x26c511b92db96554[0] && x26c511b92db96554.Length >= 2)
				{
					this.xa6eeeb830ab55361 = x26c511b92db96554[1];
					this.x17e0b5e9156e31e3 = x0835ff38739ed7ac[1];
				}
				else
				{
					this.xa6eeeb830ab55361 = x26c511b92db96554[0];
					this.x17e0b5e9156e31e3 = x0835ff38739ed7ac[0];
					if (this.GroupColumn != null && this.GroupColumn != this.SortColumn)
					{
						this.x5ab08995c9dbf0e5 = null;
					}
				}
			}
			else
			{
				this.xa6eeeb830ab55361 = null;
				this.x17e0b5e9156e31e3 = ListSortDirection.Ascending;
				this.x5ab08995c9dbf0e5 = null;
			}
			foreach (object obj in this.Columns)
			{
				GridColumn gridColumn = (GridColumn)obj;
				gridColumn.SetSortIndicator(SortOrder.None);
			}
			for (int i = 0; i < x26c511b92db96554.Length; i++)
			{
				if (x26c511b92db96554[i] != this.GroupColumn || x26c511b92db96554[i] == this.SortColumn)
				{
					x26c511b92db96554[i].SetSortIndicator((x0835ff38739ed7ac[i] == ListSortDirection.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
				}
			}
			if (this.SandGrid != null)
			{
				this.SandGrid.OnSortChanged(new SortColumnsEventArgs(this, x26c511b92db96554, x0835ff38739ed7ac));
			}
			this.x5e7a70d58e13247a();
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000850C File Offset: 0x0000750C
		public void SetSort(GridColumn[] columns, ListSortDirection[] directions)
		{
			if (columns != null)
			{
				if (directions == null)
				{
					throw new ArgumentNullException("directions");
				}
				if (columns.Length != directions.Length)
				{
					throw new ArgumentException("The specified arrays cannot be of differing lengths.", "columns");
				}
				int i;
				for (i = 0; i < columns.Length; i++)
				{
					if (columns[i] == null)
					{
						throw new ArgumentNullException("columns", "The columns array cannot contain a null reference as one of its elements.");
					}
				}
				ArrayList arrayList = new ArrayList();
				int j;
				if ((uint)j >= 0U)
				{
					foreach (GridColumn gridColumn in columns)
					{
						if (arrayList.Contains(gridColumn))
						{
							throw new ArgumentException("The specified array cannot contain a column more than once.", "columns");
						}
						if (this.GroupColumn != gridColumn)
						{
							arrayList.Add(gridColumn);
						}
					}
					bool flag = columns.Length == 0;
					if (this.x0f405f185e70ec01 != null)
					{
						this.Rows.SetSort(null, null);
						if (!flag)
						{
							this.x0f405f185e70ec01.xb81dd0ef5ac562e4(columns, directions);
							return;
						}
					}
					else
					{
						if (!this.VirtualMode)
						{
							if (flag)
							{
								this.Rows.ClearSort();
							}
							else
							{
								this.Rows.SetSort(columns, directions);
							}
						}
						this.x08643629319da08d(columns, directions);
						bool flag2 = (uint)i - (flag ? 1U : 0U) < 0U;
						if (flag2)
						{
							goto IL_CF;
						}
						return;
					}
				}
				this.x0f405f185e70ec01.x7ab1be946f29c2a1();
				return;
			}
			IL_CF:
			throw new ArgumentNullException("columns");
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000866C File Offset: 0x0000766C
		public void DeserializeState(string state)
		{
			this.DeserializeState(state, GridStateSerializationOptions.All);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00008678 File Offset: 0x00007678
		public void DeserializeState(string state, GridStateSerializationOptions options)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(state);
			this.x7b1332849f2ce1eb(xmlDocument, options);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000869C File Offset: 0x0000769C
		private void x7b1332849f2ce1eb(XmlNode xda5bf54deb817e37, GridStateSerializationOptions xdfde339da46db651)
		{
			if (xda5bf54deb817e37 == null)
			{
				throw new ArgumentNullException("node");
			}
			XmlNode xmlNode = xda5bf54deb817e37.SelectSingleNode("/SandGridState/Columns");
			if (xmlNode == null)
			{
				throw new ArgumentException("Invalid XML.", "node");
			}
			int num = int.Parse(xmlNode.Attributes["Count"].Value);
			if (num != this.Columns.Count)
			{
				throw new InvalidOperationException("The supplied state represents a different schema than the one currently loaded.");
			}
			int[] array = new int[num];
			foreach (object obj in xmlNode.ChildNodes)
			{
				XmlNode xmlNode2 = (XmlNode)obj;
				int num2 = int.Parse(xmlNode2.Attributes["Index"].Value);
				int num3 = int.Parse(xmlNode2.Attributes["DisplayIndex"].Value);
				int num4 = int.Parse(xmlNode2.Attributes["Width"].Value);
				bool x6cd50582c82f9b4d = bool.Parse(xmlNode2.Attributes["Visible"].Value);
				GridColumn gridColumn = this.Columns[num2];
				if ((xdfde339da46db651 & GridStateSerializationOptions.Width) == GridStateSerializationOptions.Width)
				{
					gridColumn.x339a6432324e0276((double)num4, false);
				}
				if ((xdfde339da46db651 & GridStateSerializationOptions.Visibility) == GridStateSerializationOptions.Visibility)
				{
					gridColumn.x6cd50582c82f9b4d = x6cd50582c82f9b4d;
				}
				array[num2] = num3;
			}
			if ((xdfde339da46db651 & GridStateSerializationOptions.DisplayIndex) == GridStateSerializationOptions.DisplayIndex)
			{
				this.Columns.SetDisplayIndices(array);
			}
			if ((xdfde339da46db651 & GridStateSerializationOptions.Sort) == GridStateSerializationOptions.Sort)
			{
				int num5 = int.Parse(xmlNode.Attributes["SortColumnIndex"].Value);
				int sortDirection = int.Parse(xmlNode.Attributes["SortDirection"].Value);
				this.SortColumn = ((num5 == -1) ? null : this.Columns[num5]);
				this.SortDirection = (ListSortDirection)sortDirection;
				int num6 = int.Parse(xmlNode.Attributes["GroupColumnIndex"].Value);
				int groupDirection = int.Parse(xmlNode.Attributes["GroupDirection"].Value);
				this.GroupColumn = ((num6 == -1) ? null : this.Columns[num6]);
				this.GroupDirection = (ListSortDirection)groupDirection;
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000088E8 File Offset: 0x000078E8
		public string SerializeState()
		{
			string result;
			using (StringWriter stringWriter = new StringWriter())
			{
				XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
				xmlTextWriter.Formatting = Formatting.Indented;
				xmlTextWriter.WriteStartElement("SandGridState");
				xmlTextWriter.WriteAttributeString("Version", Assembly.GetExecutingAssembly().GetName().Version.ToString());
				xmlTextWriter.WriteStartElement("Columns");
				xmlTextWriter.WriteAttributeString("Count", this.Columns.Count.ToString());
				xmlTextWriter.WriteAttributeString("SortColumnIndex", (this.SortColumn != null) ? this.SortColumn.Index.ToString() : "-1");
				xmlTextWriter.WriteAttributeString("SortDirection", ((int)this.SortDirection).ToString());
				xmlTextWriter.WriteAttributeString("GroupColumnIndex", (this.GroupColumn != null) ? this.GroupColumn.Index.ToString() : "-1");
				xmlTextWriter.WriteAttributeString("GroupDirection", ((int)this.GroupDirection).ToString());
				foreach (object obj in this.Columns)
				{
					GridColumn gridColumn = (GridColumn)obj;
					xmlTextWriter.WriteStartElement("Column");
					xmlTextWriter.WriteAttributeString("Index", gridColumn.Index.ToString());
					xmlTextWriter.WriteAttributeString("DisplayIndex", gridColumn.DisplayIndex.ToString());
					xmlTextWriter.WriteAttributeString("Width", gridColumn.Width.ToString());
					xmlTextWriter.WriteAttributeString("Visible", gridColumn.Visible.ToString());
					xmlTextWriter.WriteEndElement();
				}
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.WriteEndElement();
				xmlTextWriter.Flush();
				xmlTextWriter.Close();
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00008B08 File Offset: 0x00007B08
		public void ExpandAll()
		{
			foreach (object obj in this.FlatVisibleRows)
			{
				GridRow gridRow = (GridRow)obj;
				gridRow.Expanded = true;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00008B70 File Offset: 0x00007B70
		public void CollapseAll()
		{
			foreach (object obj in this.FlatVisibleRows)
			{
				GridRow gridRow = (GridRow)obj;
				gridRow.Expanded = false;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00008BD8 File Offset: 0x00007BD8
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x00008BE0 File Offset: 0x00007BE0
		public Type NewRowType
		{
			get
			{
				return this.x223f7fc46b59a82d;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (!value.IsSubclassOf(typeof(GridRow)) && value != typeof(GridRow))
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionTypeNotGridRow"), "value");
				}
				this.x223f7fc46b59a82d = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00008C38 File Offset: 0x00007C38
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x00008C40 File Offset: 0x00007C40
		public NullBehavior NullBehavior
		{
			get
			{
				return this.xebd97955e319d6dc;
			}
			set
			{
				this.xebd97955e319d6dc = value;
				if (this.x0f405f185e70ec01 != null)
				{
					this.xf0cbfe5c1ab718ea();
				}
				this.MeasureNeeded();
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00008C60 File Offset: 0x00007C60
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00008C68 File Offset: 0x00007C68
		public GroupHeadingClickBehavior GroupHeadingClickBehavior
		{
			get
			{
				return this.x31d0599d6e9c56d2;
			}
			set
			{
				this.x31d0599d6e9c56d2 = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00008C74 File Offset: 0x00007C74
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x00008C7C File Offset: 0x00007C7C
		public bool CheckBoxes
		{
			get
			{
				return this.xc0016e08e2f49f5c;
			}
			set
			{
				if (value != this.xc0016e08e2f49f5c)
				{
					this.xc0016e08e2f49f5c = value;
					this.MeasureNeeded();
				}
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00008C94 File Offset: 0x00007C94
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x00008C9C File Offset: 0x00007C9C
		public CellDragBehavior CellDragBehavior
		{
			get
			{
				return this.x9e1d52787f6ca7f0;
			}
			set
			{
				this.x9e1d52787f6ca7f0 = value;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x00008CA8 File Offset: 0x00007CA8
		internal bool x4f5145fcade014f7
		{
			get
			{
				return this.xfd402592e32abf89;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00008CB0 File Offset: 0x00007CB0
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00008CB8 File Offset: 0x00007CB8
		public string NullRepresentation
		{
			get
			{
				return this.x00345ccabe7db654;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x00345ccabe7db654 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00008CD4 File Offset: 0x00007CD4
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00008CDC File Offset: 0x00007CDC
		public bool HideSelection
		{
			get
			{
				return this.x93ef78fd87a99a3c;
			}
			set
			{
				if (value != this.x93ef78fd87a99a3c)
				{
					this.x93ef78fd87a99a3c = value;
					this.x5e7a70d58e13247a();
				}
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00008CF4 File Offset: 0x00007CF4
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00008CFC File Offset: 0x00007CFC
		public ColumnClickBehavior ColumnClickBehavior
		{
			get
			{
				return this.x1d7947fc05318e62;
			}
			set
			{
				this.x1d7947fc05318e62 = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00008D08 File Offset: 0x00007D08
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00008D10 File Offset: 0x00007D10
		public ListSortDirection GroupDirection
		{
			get
			{
				return this.x69240d1467b772b3;
			}
			set
			{
				if (value != this.x69240d1467b772b3)
				{
					this.x69240d1467b772b3 = value;
					this.x5dc6ef116f899d67();
				}
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00008D28 File Offset: 0x00007D28
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00008D30 File Offset: 0x00007D30
		public ListSortDirection SortDirection
		{
			get
			{
				return this.x17e0b5e9156e31e3;
			}
			set
			{
				if (value != this.x17e0b5e9156e31e3)
				{
					this.x17e0b5e9156e31e3 = value;
					this.x5dc6ef116f899d67();
				}
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00008D48 File Offset: 0x00007D48
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00008D50 File Offset: 0x00007D50
		public GridColumn GroupColumn
		{
			get
			{
				return this.x5ab08995c9dbf0e5;
			}
			set
			{
				if (this.VirtualMode && value != null)
				{
					throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
				}
				if (value != this.x5ab08995c9dbf0e5)
				{
					if (this.x5ab08995c9dbf0e5 != null && this.xa6eeeb830ab55361 == this.x5ab08995c9dbf0e5 && value == null)
					{
						this.xa6eeeb830ab55361 = null;
					}
					this.x5ab08995c9dbf0e5 = value;
					this.x5dc6ef116f899d67();
					this.MeasureNeeded();
				}
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00008DB4 File Offset: 0x00007DB4
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00008DBC File Offset: 0x00007DBC
		public GridColumn SortColumn
		{
			get
			{
				return this.xa6eeeb830ab55361;
			}
			set
			{
				if (value != this.xa6eeeb830ab55361)
				{
					this.xa6eeeb830ab55361 = value;
					this.x5dc6ef116f899d67();
				}
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00008DD4 File Offset: 0x00007DD4
		internal bool xc22134cf4aa6ad3d
		{
			get
			{
				return this.x0f405f185e70ec01 != null;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00008DE4 File Offset: 0x00007DE4
		// (set) Token: 0x060000CA RID: 202 RVA: 0x00008DEC File Offset: 0x00007DEC
		public RowDragBehavior RowDragBehavior
		{
			get
			{
				return this.xe121f8f0a679aa00;
			}
			set
			{
				this.xe121f8f0a679aa00 = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00008DF8 File Offset: 0x00007DF8
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00008E00 File Offset: 0x00007E00
		public bool AllowRowResize
		{
			get
			{
				return this.xe16b60084487a071;
			}
			set
			{
				if (this.VirtualMode && value)
				{
					throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
				}
				this.xe16b60084487a071 = value;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00008E24 File Offset: 0x00007E24
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00008E2C File Offset: 0x00007E2C
		internal GridColumn x86b14c423a0c12f3
		{
			get
			{
				return this.xc24b9a592352c63a;
			}
			set
			{
				this.xc24b9a592352c63a = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00008E38 File Offset: 0x00007E38
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x00008E40 File Offset: 0x00007E40
		public bool AutoGenerateBoundColumns
		{
			get
			{
				return this.x7e619e82acd19e14;
			}
			set
			{
				if (value != this.x7e619e82acd19e14)
				{
					this.x7e619e82acd19e14 = value;
					if (value && this.x748aa855543fa4ff != null)
					{
						this.x5a074e2e9b606ead();
					}
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00008E64 File Offset: 0x00007E64
		public bool IsNested
		{
			get
			{
				return this.x65bb1537d51f4cd7 != null;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00008E74 File Offset: 0x00007E74
		internal xb0065acaf2259df4 x0f405f185e70ec01
		{
			get
			{
				return this.x748aa855543fa4ff;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00008E7C File Offset: 0x00007E7C
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00008E94 File Offset: 0x00007E94
		public object DataSource
		{
			get
			{
				if (this.x748aa855543fa4ff != null)
				{
					return this.x748aa855543fa4ff.x086f935af5565717;
				}
				return null;
			}
			set
			{
				if (value != this.DataSource)
				{
					if (this.x748aa855543fa4ff == null)
					{
						this.x748aa855543fa4ff = new xb0065acaf2259df4(this);
						this.x748aa855543fa4ff.x42d80cc5d994096e(value, this.DataMember);
					}
					else
					{
						this.x748aa855543fa4ff.x42d80cc5d994096e(value, this.DataMember);
						if (value == null)
						{
							this.x748aa855543fa4ff = null;
						}
					}
					this.OnDataSourceChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00008EFC File Offset: 0x00007EFC
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00008F18 File Offset: 0x00007F18
		public string DataMember
		{
			get
			{
				if (this.x748aa855543fa4ff == null)
				{
					return string.Empty;
				}
				return this.x748aa855543fa4ff.x668c3bf9795baea6;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				if (value != this.DataMember)
				{
					if (this.x748aa855543fa4ff == null)
					{
						this.x748aa855543fa4ff = new xb0065acaf2259df4(this);
					}
					this.x748aa855543fa4ff.x42d80cc5d994096e(this.DataSource, value);
					this.OnDataMemberChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00008F70 File Offset: 0x00007F70
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x00008F78 File Offset: 0x00007F78
		public bool HighlightImages
		{
			get
			{
				return this.xb04e597e744e96c5;
			}
			set
			{
				this.xb04e597e744e96c5 = value;
				this.x5e7a70d58e13247a();
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x00008F88 File Offset: 0x00007F88
		// (set) Token: 0x060000DA RID: 218 RVA: 0x00008F90 File Offset: 0x00007F90
		public int GroupHeadingHeight
		{
			get
			{
				return this.x382b7f2aee4f455b;
			}
			set
			{
				this.x382b7f2aee4f455b = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00008FA0 File Offset: 0x00007FA0
		// (set) Token: 0x060000DC RID: 220 RVA: 0x00008FA8 File Offset: 0x00007FA8
		public bool ShadeAlternateRows
		{
			get
			{
				return this.x107271fddfe5cc83;
			}
			set
			{
				this.x107271fddfe5cc83 = value;
				this.x5e7a70d58e13247a();
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00008FB8 File Offset: 0x00007FB8
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00008FC0 File Offset: 0x00007FC0
		public int ImageTextSeparation
		{
			get
			{
				return this.x65fd3bba5ec2c2f5;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNegative"), "value");
				}
				this.x65fd3bba5ec2c2f5 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000DF RID: 223 RVA: 0x00008FE8 File Offset: 0x00007FE8
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00008FF0 File Offset: 0x00007FF0
		public GridLinesDisplayType GridLines
		{
			get
			{
				return this.xd5f57c1fc5acdd8f;
			}
			set
			{
				this.xd5f57c1fc5acdd8f = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00009000 File Offset: 0x00008000
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00009008 File Offset: 0x00008008
		public bool ShowTreeLines
		{
			get
			{
				return this.x8df1e502cdeec0af;
			}
			set
			{
				this.x8df1e502cdeec0af = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00009018 File Offset: 0x00008018
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x00009020 File Offset: 0x00008020
		public bool ShowRootLines
		{
			get
			{
				return this.xff50b018f9a43e18;
			}
			set
			{
				this.xff50b018f9a43e18 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00009030 File Offset: 0x00008030
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00009038 File Offset: 0x00008038
		public bool AllowMultipleSelection
		{
			get
			{
				return this.x271f96fbb8e09dac;
			}
			set
			{
				if (value != this.AllowMultipleSelection)
				{
					this.x271f96fbb8e09dac = value;
					this.x2f3b60e203c4300f();
				}
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00009050 File Offset: 0x00008050
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00009058 File Offset: 0x00008058
		public bool AllowGroupCollapse
		{
			get
			{
				return this.x1485de1a2d21fca1;
			}
			set
			{
				this.x1485de1a2d21fca1 = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00009064 File Offset: 0x00008064
		public IEnumerable Groups
		{
			get
			{
				return this.x0c750788e1a26805.Values;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00009074 File Offset: 0x00008074
		public bool RightToLeft
		{
			get
			{
				return this.x1158f70b6f5fc38e;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000EB RID: 235 RVA: 0x0000907C File Offset: 0x0000807C
		internal GridRow x699c923a60e155ff
		{
			get
			{
				return this.xe3e46143afea2a63;
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00009084 File Offset: 0x00008084
		internal void x377b231caa0f3350(GridRow xbcea506a33cf9111)
		{
			this.xe3e46143afea2a63 = xbcea506a33cf9111;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00009090 File Offset: 0x00008090
		public int VisibleRowCount
		{
			get
			{
				return this.xbd2390ed2cbc98f2;
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00009098 File Offset: 0x00008098
		internal void x12d82f2321e4235a(int xbd2390ed2cbc98f2)
		{
			this.xbd2390ed2cbc98f2 = xbd2390ed2cbc98f2;
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000EF RID: 239 RVA: 0x000090A4 File Offset: 0x000080A4
		public int FirstVisibleColumn
		{
			get
			{
				return this.x41fc7455e9572f5c;
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000090AC File Offset: 0x000080AC
		internal void x7beb0f9731e751f7(int x41fc7455e9572f5c)
		{
			this.x41fc7455e9572f5c = x41fc7455e9572f5c;
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x000090B8 File Offset: 0x000080B8
		public int VisibleColumnCount
		{
			get
			{
				return this.x717defba4f5045d4;
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000090C0 File Offset: 0x000080C0
		internal void x3d8b152ea76101f6(int x717defba4f5045d4)
		{
			this.x717defba4f5045d4 = x717defba4f5045d4;
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x000090CC File Offset: 0x000080CC
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x000090D4 File Offset: 0x000080D4
		public int IndentationSize
		{
			get
			{
				return this.x2b65c600f78c7772;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNegative"), "value");
				}
				this.x2b65c600f78c7772 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x000090FC File Offset: 0x000080FC
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x00009104 File Offset: 0x00008104
		public bool ShowTreeButtons
		{
			get
			{
				return this.x7de6767fe4330081;
			}
			set
			{
				if (this.VirtualMode && value)
				{
					throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
				}
				this.x7de6767fe4330081 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00009130 File Offset: 0x00008130
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x00009138 File Offset: 0x00008138
		public ParentRowDoubleClickBehavior ParentRowDoubleClick
		{
			get
			{
				return this.x89a09ebc2e59f4b9;
			}
			set
			{
				this.x89a09ebc2e59f4b9 = value;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00009144 File Offset: 0x00008144
		// (set) Token: 0x060000FA RID: 250 RVA: 0x00009154 File Offset: 0x00008154
		public GridColumn PrimaryColumn
		{
			get
			{
				return this.Columns.xacc79ca10cb86c1f;
			}
			set
			{
				this.Columns.xacc79ca10cb86c1f = value;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00009164 File Offset: 0x00008164
		// (set) Token: 0x060000FC RID: 252 RVA: 0x0000916C File Offset: 0x0000816C
		public RowHighlightType RowHighlightType
		{
			get
			{
				return this.xb99a4fb8f58ec404;
			}
			set
			{
				this.xb99a4fb8f58ec404 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000FD RID: 253 RVA: 0x0000917C File Offset: 0x0000817C
		internal Size x455ae0624abb5477
		{
			get
			{
				Size empty = Size.Empty;
				if (this.FixColumnHeaders && this.Columns.Count != 0 && this.ShowColumnHeaders)
				{
					empty.Height = this.x5d332e6bd470be29;
				}
				if (this.FixRowHeaders && this.ShowRowHeaders)
				{
					empty.Width = this.RowHeaderSize;
				}
				return empty;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000FE RID: 254 RVA: 0x000091D8 File Offset: 0x000081D8
		// (set) Token: 0x060000FF RID: 255 RVA: 0x000091E0 File Offset: 0x000081E0
		public int VirtualRowSize
		{
			get
			{
				return this.xefee12953e30df70;
			}
			set
			{
				if (value < 1)
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNotPositive"), "value");
				}
				this.xefee12953e30df70 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00009208 File Offset: 0x00008208
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00009218 File Offset: 0x00008218
		public bool VirtualMode
		{
			get
			{
				return this.Rows.x584ba2e98f91dd4d;
			}
			set
			{
				if (value != this.VirtualMode)
				{
					if (value)
					{
						this.ShowTreeButtons = false;
						this.AllowRowResize = false;
						this.GroupColumn = null;
					}
					this.Rows.x584ba2e98f91dd4d = value;
					if (this.xc22134cf4aa6ad3d)
					{
						this.OnDataSourceChanged(EventArgs.Empty);
					}
				}
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00009268 File Offset: 0x00008268
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00009278 File Offset: 0x00008278
		public int VirtualRowCount
		{
			get
			{
				return this.Rows.x0d3ed93b62f2f248;
			}
			set
			{
				if (this.xc22134cf4aa6ad3d)
				{
					throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
				}
				this.Rows.x0d3ed93b62f2f248 = value;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000104 RID: 260 RVA: 0x000092A0 File Offset: 0x000082A0
		// (set) Token: 0x06000105 RID: 261 RVA: 0x000092A8 File Offset: 0x000082A8
		public bool LiveResize
		{
			get
			{
				return this.x8e80951f5e19e22d;
			}
			set
			{
				this.x8e80951f5e19e22d = value;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000106 RID: 262 RVA: 0x000092B4 File Offset: 0x000082B4
		// (set) Token: 0x06000107 RID: 263 RVA: 0x000092BC File Offset: 0x000082BC
		public int VerticalMarkerPosition
		{
			get
			{
				return this.x7e7627de971b386a;
			}
			set
			{
				if (value < -1)
				{
					throw new ArgumentException("value");
				}
				if (value != this.x7e7627de971b386a)
				{
					if (this.x7e7627de971b386a != -1)
					{
						Rectangle xda73fcb97c77d = new Rectangle(this.x7e7627de971b386a - 5, base.Bounds.Top, 10, base.Bounds.Height);
						this.x5e7a70d58e13247a(xda73fcb97c77d);
					}
					this.x7e7627de971b386a = value;
					if (this.x7e7627de971b386a != -1)
					{
						Rectangle xda73fcb97c77d2 = new Rectangle(this.x7e7627de971b386a - 5, base.Bounds.Top, 10, base.Bounds.Height);
						this.x5e7a70d58e13247a(xda73fcb97c77d2);
					}
				}
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00009368 File Offset: 0x00008368
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00009370 File Offset: 0x00008370
		public int HorizontalMarkerPosition
		{
			get
			{
				return this.x569663422655c5fd;
			}
			set
			{
				if (value < -1)
				{
					throw new ArgumentException("value");
				}
				if (value != this.x569663422655c5fd)
				{
					if (this.x569663422655c5fd != -1)
					{
						Rectangle xda73fcb97c77d = new Rectangle(base.Bounds.Left, this.x569663422655c5fd - 5, base.Bounds.Width, 10);
						this.x5e7a70d58e13247a(xda73fcb97c77d);
					}
					this.x569663422655c5fd = value;
					if (this.x569663422655c5fd != -1)
					{
						Rectangle xda73fcb97c77d2 = new Rectangle(base.Bounds.Left, this.x569663422655c5fd - 5, base.Bounds.Width, 10);
						this.x5e7a70d58e13247a(xda73fcb97c77d2);
					}
				}
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600010A RID: 266 RVA: 0x0000941C File Offset: 0x0000841C
		// (set) Token: 0x0600010B RID: 267 RVA: 0x00009424 File Offset: 0x00008424
		public bool CreateCells
		{
			get
			{
				return this.xac215e76df268d15;
			}
			set
			{
				if (value != this.xac215e76df268d15)
				{
					this.xac215e76df268d15 = value;
					if (this.xc22134cf4aa6ad3d)
					{
						this.xf0cbfe5c1ab718ea();
					}
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00009444 File Offset: 0x00008444
		// (set) Token: 0x0600010D RID: 269 RVA: 0x0000944C File Offset: 0x0000844C
		public SelectionGranularity SelectionGranularity
		{
			get
			{
				return this.xc3c8131041d547ef;
			}
			set
			{
				if (value != this.xc3c8131041d547ef)
				{
					if (this.VirtualMode)
					{
						throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionVirtualMode"));
					}
					this.xc3c8131041d547ef = value;
					this.x2f3b60e203c4300f();
					if (this.xc22134cf4aa6ad3d)
					{
						this.xf0cbfe5c1ab718ea();
					}
				}
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600010E RID: 270 RVA: 0x0000948C File Offset: 0x0000848C
		// (set) Token: 0x0600010F RID: 271 RVA: 0x00009494 File Offset: 0x00008494
		public bool FixRowHeaders
		{
			get
			{
				return this.x780402941498bf63;
			}
			set
			{
				if (this.x65bb1537d51f4cd7 != null && value)
				{
					throw new ArgumentException("Headers cannot be fixed in a nested grid.", "value");
				}
				this.x780402941498bf63 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000110 RID: 272 RVA: 0x000094C0 File Offset: 0x000084C0
		// (set) Token: 0x06000111 RID: 273 RVA: 0x000094C8 File Offset: 0x000084C8
		public bool ShowRowHeaders
		{
			get
			{
				return this.x65bc10861281bebb;
			}
			set
			{
				this.x65bc10861281bebb = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000112 RID: 274 RVA: 0x000094D8 File Offset: 0x000084D8
		// (set) Token: 0x06000113 RID: 275 RVA: 0x000094E0 File Offset: 0x000084E0
		public int RowHeaderSize
		{
			get
			{
				return this.xe5d0fc219ae75ca1;
			}
			set
			{
				if (value < 10)
				{
					throw new ArgumentException("The specified value must be greater than or equal to 10.", "value");
				}
				this.xe5d0fc219ae75ca1 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00009504 File Offset: 0x00008504
		// (set) Token: 0x06000115 RID: 277 RVA: 0x0000950C File Offset: 0x0000850C
		public bool FixColumnHeaders
		{
			get
			{
				return this.x6fe255d5549a3d7e;
			}
			set
			{
				if (this.x65bb1537d51f4cd7 != null && value)
				{
					throw new ArgumentException("Headers cannot be fixed in a nested grid.", "value");
				}
				this.x6fe255d5549a3d7e = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00009538 File Offset: 0x00008538
		// (set) Token: 0x06000117 RID: 279 RVA: 0x00009540 File Offset: 0x00008540
		public WhitespaceClickBehavior WhitespaceClickBehavior
		{
			get
			{
				return this.x7294d05980c20aed;
			}
			set
			{
				this.x7294d05980c20aed = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000118 RID: 280 RVA: 0x0000954C File Offset: 0x0000854C
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00009554 File Offset: 0x00008554
		public bool ShowColumnHeaders
		{
			get
			{
				return this.x993c818ed3714592;
			}
			set
			{
				this.x993c818ed3714592 = value;
				this.MeasureNeeded();
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00009564 File Offset: 0x00008564
		internal int x5d332e6bd470be29
		{
			get
			{
				return this.xdccb30ad7b37c1d8;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600011B RID: 283 RVA: 0x0000956C File Offset: 0x0000856C
		public GridColumnCollection Columns
		{
			get
			{
				return this.x26c511b92db96554;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00009574 File Offset: 0x00008574
		public GridRowCollection Rows
		{
			get
			{
				return this.x2eb5785cf1641b8b;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600011D RID: 285 RVA: 0x0000957C File Offset: 0x0000857C
		public IEnumerable FlatVisibleRows
		{
			get
			{
				return new x5e489057b964343a(this);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00009584 File Offset: 0x00008584
		public IEnumerable FlatRows
		{
			get
			{
				return new xef6ea4ade4525df4(this);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600011F RID: 287 RVA: 0x0000958C File Offset: 0x0000858C
		public SandGridBase SandGrid
		{
			get
			{
				return this.xaf05a2aec36f5b1b;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00009594 File Offset: 0x00008594
		public new FocusableGridElement ParentElement
		{
			get
			{
				return this.x65bb1537d51f4cd7;
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0000959C File Offset: 0x0000859C
		internal void x8575a139d5c8689b(SandGridBase xbd37b7a1be4bbca7)
		{
			if (xbd37b7a1be4bbca7 != this.xaf05a2aec36f5b1b)
			{
				if (this.xaf05a2aec36f5b1b != null)
				{
					this.xaf05a2aec36f5b1b.xf7115efe1c1b0dcf(this);
				}
				if (this.xaf05a2aec36f5b1b != null)
				{
					this.xaf05a2aec36f5b1b.GotFocus -= this.xe613f07f2f67863b;
					this.xaf05a2aec36f5b1b.LostFocus -= this.x3e4c8fb5d599d2ac;
					this.xaf05a2aec36f5b1b.BindingContextChanged -= this.x7e6a0adab76bd5f4;
					this.xaf05a2aec36f5b1b.ActiveGridChanged -= this.xfa0b799a85a6dd6d;
				}
				this.xa00f6b773020b855 = false;
				this.xaf05a2aec36f5b1b = xbd37b7a1be4bbca7;
				if (this.xaf05a2aec36f5b1b != null)
				{
					this.xaf05a2aec36f5b1b.GotFocus += this.xe613f07f2f67863b;
					this.xaf05a2aec36f5b1b.LostFocus += this.x3e4c8fb5d599d2ac;
					this.xaf05a2aec36f5b1b.BindingContextChanged += this.x7e6a0adab76bd5f4;
					this.xaf05a2aec36f5b1b.ActiveGridChanged += this.xfa0b799a85a6dd6d;
				}
				if (this.xaf05a2aec36f5b1b != null && this.x748aa855543fa4ff != null)
				{
					this.x7e6a0adab76bd5f4(null, null);
				}
				foreach (object obj in this.Rows)
				{
					GridRow gridRow = (GridRow)obj;
					gridRow.xea1c0bc64ab77594(this);
				}
				foreach (object obj2 in this.Columns)
				{
					GridColumn gridColumn = (GridColumn)obj2;
					gridColumn.xea1c0bc64ab77594(this);
				}
				if (this.xaf05a2aec36f5b1b == null)
				{
					this.x0b035f832721de35();
				}
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00009778 File Offset: 0x00008778
		private void xfa0b799a85a6dd6d(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			bool flag = this.SandGrid.ActiveGrid == this;
			if (flag != this.xa00f6b773020b855)
			{
				if (this.IsNested)
				{
					this.x5e7a70d58e13247a();
				}
				else
				{
					this.xe980d0e8c508a3a2();
				}
				this.xa00f6b773020b855 = flag;
			}
		}

		// Token: 0x06000123 RID: 291 RVA: 0x000097BC File Offset: 0x000087BC
		private void x7e6a0adab76bd5f4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x748aa855543fa4ff != null)
			{
				this.x748aa855543fa4ff.x90b92b9c88622fb5();
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000124 RID: 292 RVA: 0x000097D4 File Offset: 0x000087D4
		public int SelectedElementCount
		{
			get
			{
				return this.x6fa8a9b2a6c7302a.Count;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000125 RID: 293 RVA: 0x000097E4 File Offset: 0x000087E4
		public SelectedElementCollection SelectedElements
		{
			get
			{
				return this.x6fa8a9b2a6c7302a;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000126 RID: 294 RVA: 0x000097EC File Offset: 0x000087EC
		// (set) Token: 0x06000127 RID: 295 RVA: 0x000097F4 File Offset: 0x000087F4
		public RowEditMode RowEditMode
		{
			get
			{
				return this.x7e89e82b77492361;
			}
			set
			{
				this.x7e89e82b77492361 = value;
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00009800 File Offset: 0x00008800
		internal string x9b21ee8e7ceaada3(Point x13d4cb8d1bd20347)
		{
			GridElement gridElement = base.HitTest(x13d4cb8d1bd20347);
			if (gridElement != null)
			{
				return gridElement.GetTooltipText(x13d4cb8d1bd20347);
			}
			return string.Empty;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00009828 File Offset: 0x00008828
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			if (this.x2e028e8ac31e061f && this.x5eaebf6c9f7916f3.Contains(e.X, e.Y))
			{
				this.SelectAll();
				return;
			}
			if (this.WhitespaceClickBehavior == WhitespaceClickBehavior.ClearSelection && (Control.ModifierKeys & Keys.Control) != Keys.Control)
			{
				this.SelectedElements.Clear();
			}
			if (this.AllowMultipleSelection && e.Button == MouseButtons.Left)
			{
				base.x11f639c5d61688d8(new x29a0cbfd700e4b01(this, new Point(e.X, e.Y)));
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000098B8 File Offset: 0x000088B8
		public GridColumn GetColumnAt(Point position)
		{
			if (position.Y >= base.Bounds.Y && position.Y < base.Bounds.Bottom)
			{
				foreach (GridColumn gridColumn in this.Columns.DisplayColumns)
				{
					int num;
					int num2;
					if (this.RightToLeft)
					{
						num = ((gridColumn.NextColumn == null) ? (gridColumn.Bounds.Left - 5) : gridColumn.Bounds.Left);
						num2 = gridColumn.Bounds.Right;
					}
					else
					{
						num = gridColumn.Bounds.Left;
						int num3;
						if (gridColumn.NextColumn != null)
						{
							num3 = gridColumn.Bounds.Right;
						}
						else
						{
							Rectangle bounds = gridColumn.Bounds;
							if (255 == 0)
							{
								break;
							}
							num3 = bounds.Right + 5;
						}
						num2 = num3;
					}
					if (position.X >= num && position.X < num2)
					{
						return gridColumn;
					}
				}
			}
			return null;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000099D0 File Offset: 0x000089D0
		protected override GridElement GetChildElementAt(Point position)
		{
			if (this.ShowColumnHeaders && position.Y >= base.Bounds.Top && position.Y < base.Bounds.Top + this.x5d332e6bd470be29)
			{
				return this.GetColumnAt(position);
			}
			if (this.ShowRowHeaders && ((this.RightToLeft && position.X >= base.Bounds.Right - this.RowHeaderSize && position.X < base.Bounds.Right) || (!this.RightToLeft && position.X >= base.Bounds.Left && position.X < base.Bounds.Left + this.RowHeaderSize)))
			{
				return this.x8259a07be630dfbd(position.X, position.Y);
			}
			if (this.Rows.Count != 0)
			{
				if (this.IsNested)
				{
					using (IEnumerator enumerator = this.FlatVisibleRows.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							GridRow gridRow = (GridRow)obj;
							if (position.Y >= gridRow.Bounds.Y && position.Y < gridRow.Bounds.Bottom)
							{
								if (gridRow.x93b1564fed45c05e().Contains(position))
								{
									return gridRow;
								}
								return null;
							}
						}
						goto IL_A9;
					}
					GridElement result;
					return result;
				}
				int num = position.Y + this.SandGrid.ClientRectangle.Height * 2;
				GridRow gridRow2 = this.SandGrid.x4a12a72ac9e77a57(position.Y);
				while (gridRow2 != null)
				{
					if (position.Y >= gridRow2.Bounds.Y && position.Y < gridRow2.Bounds.Bottom)
					{
						if (gridRow2.x93b1564fed45c05e().Contains(position))
						{
							return gridRow2;
						}
						return null;
					}
					else
					{
						gridRow2 = gridRow2.NextVisibleRow;
						if (gridRow2 != null && gridRow2.Bounds.Top > num)
						{
							break;
						}
					}
				}
			}
			IL_A9:
			foreach (object obj2 in this.Groups)
			{
				GridGroup gridGroup = (GridGroup)obj2;
				if (gridGroup.Bounds.Contains(position.X, position.Y))
				{
					return gridGroup;
				}
			}
			return null;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00009CAC File Offset: 0x00008CAC
		[Obsolete("Use the HitTest method instead.")]
		public GridElement GetElementAt(Point position)
		{
			return base.HitTest(position);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00009CB8 File Offset: 0x00008CB8
		private GridElement x8259a07be630dfbd(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
		{
			foreach (object obj in (this.x3ccd9f3d0472952f ? this.SandGrid.OnscreenRows : this.FlatVisibleRows))
			{
				GridRow gridRow = (GridRow)obj;
				Rectangle bounds = gridRow.Bounds;
				if (x1e218ceaee1bb583 >= bounds.Y && x1e218ceaee1bb583 < bounds.Bottom)
				{
					return gridRow;
				}
			}
			return null;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00009D50 File Offset: 0x00008D50
		private void xe613f07f2f67863b(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xe980d0e8c508a3a2();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00009D58 File Offset: 0x00008D58
		private void x3e4c8fb5d599d2ac(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xe980d0e8c508a3a2();
			if (this.VirtualMode)
			{
				this.Rows.xe508a828c56d322e();
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00009D74 File Offset: 0x00008D74
		private void xe980d0e8c508a3a2()
		{
			if (this.SelectedElementCount != 0 && !this.xfd402592e32abf89)
			{
				Rectangle rect = new Rectangle(this.SandGrid.HScrollOffset, this.SandGrid.VScrollOffset, this.SandGrid.ClientRectangle.Width, this.SandGrid.ClientRectangle.Height);
				foreach (object obj in this.x6fa8a9b2a6c7302a)
				{
					GridElement gridElement = (GridElement)obj;
					if (gridElement.Bounds.IntersectsWith(rect))
					{
						gridElement.RedrawNeeded();
					}
					GridColumn gridColumn = gridElement as GridColumn;
					if (gridColumn != null)
					{
						gridColumn.RedrawNeeded(true);
					}
				}
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00009E5C File Offset: 0x00008E5C
		internal void x614e783eda4ed71f()
		{
			this.x394c56dbbf0c87f6++;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00009E6C File Offset: 0x00008E6C
		internal void x06727b7d4fe7a302()
		{
			this.x394c56dbbf0c87f6--;
			if (this.x394c56dbbf0c87f6 < 0)
			{
				this.x394c56dbbf0c87f6 = 0;
			}
			if (this.x394c56dbbf0c87f6 == 0 && this.xc81d909b289dfbce)
			{
				this.xc81d909b289dfbce = false;
				this.x6d6f7a19a6e74243();
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00009EAC File Offset: 0x00008EAC
		internal void x6d6f7a19a6e74243()
		{
			if (this.x394c56dbbf0c87f6 > 0)
			{
				this.xc81d909b289dfbce = true;
				return;
			}
			if (!this.SandGrid.Disposing)
			{
				this.SandGrid.OnSelectionChanged(new SelectionChangedEventArgs(this));
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00009EE0 File Offset: 0x00008EE0
		private bool x60a91521cca92355(GridElement x4bbc2c453c470189, FocusableGridElement x8c306dea2fef399b)
		{
			bool result = false;
			if (x4bbc2c453c470189.Selected)
			{
				x4bbc2c453c470189.x213abd9ea5eb87d6 = false;
				this.x6fa8a9b2a6c7302a.x52b190e626f65140(x4bbc2c453c470189);
				result = true;
			}
			if (this.SandGrid != null)
			{
				if (x4bbc2c453c470189 == this.SandGrid.x737f7a4b63639f66)
				{
					this.SandGrid.FocusedElement = x8c306dea2fef399b;
				}
				if (x4bbc2c453c470189 == this.SandGrid.x2a10d07d82bcf8e6)
				{
					this.SandGrid.xf023f44afe4ba919 = null;
				}
			}
			return result;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00009F4C File Offset: 0x00008F4C
		internal void x0b035f832721de35()
		{
			foreach (object obj in this.Rows)
			{
				GridRow gridRow = (GridRow)obj;
				gridRow.x0b035f832721de35();
			}
			foreach (object obj2 in this.Columns)
			{
				GridColumn x4bbc2c453c = (GridColumn)obj2;
				this.x2f8a63bfec1c0c0f(x4bbc2c453c);
			}
			this.x2f8a63bfec1c0c0f(this);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000A014 File Offset: 0x00009014
		internal void xf7115efe1c1b0dcf(InnerGrid xf57b149cb3f9c03a)
		{
			if (this.SandGrid != null)
			{
				this.SandGrid.xf7115efe1c1b0dcf(xf57b149cb3f9c03a);
			}
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000A02C File Offset: 0x0000902C
		internal void x60a91521cca92355(GridElement[] x6e96c3657c96bbbe)
		{
			bool flag = false;
			foreach (GridElement x4bbc2c453c in x6e96c3657c96bbbe)
			{
				flag = (flag || this.x60a91521cca92355(x4bbc2c453c, null));
			}
			if (flag)
			{
				this.x6d6f7a19a6e74243();
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000A068 File Offset: 0x00009068
		internal void x2f8a63bfec1c0c0f(GridElement x4bbc2c453c470189)
		{
			x5d3666f49ba1c366.x2f8a63bfec1c0c0f(x4bbc2c453c470189);
			FocusableGridElement focusableGridElement;
			GridRow gridRow;
			GridCell gridCell;
			if (8 != 0)
			{
				focusableGridElement = null;
				gridRow = null;
				GridRow gridRow2 = x4bbc2c453c470189 as GridRow;
				if (gridRow2 != null)
				{
					if (gridRow2.x9fcc739d9a713387 != null && gridRow2.x9fcc739d9a713387.Grid == gridRow2.Grid)
					{
						focusableGridElement = gridRow2.x9fcc739d9a713387;
					}
					else if (gridRow2.x57aa0f7994718ad8 != null && gridRow2.x57aa0f7994718ad8.Grid == gridRow2.Grid)
					{
						focusableGridElement = gridRow2.x57aa0f7994718ad8;
					}
					else if (gridRow2.Group != null && this.GroupHeadingClickBehavior == GroupHeadingClickBehavior.Select)
					{
						focusableGridElement = gridRow2.Group;
					}
					gridRow = gridRow2;
				}
				gridCell = (x4bbc2c453c470189 as GridCell);
				goto IL_144;
			}
			IL_10:
			if (gridCell.NextCell.Grid == gridCell.Grid)
			{
				focusableGridElement = gridCell.NextCell;
				goto IL_4E;
			}
			IL_2C:
			if (gridCell.PreviousCell != null && gridCell.PreviousCell.Grid == gridCell.Grid)
			{
				focusableGridElement = gridCell.PreviousCell;
			}
			IL_4E:
			gridRow = gridCell.ParentRow;
			IL_55:
			if (this.SandGrid != null && this.SandGrid.EditingRow == gridRow)
			{
				this.SandGrid.x48546f274ac60a66(false, true, true);
			}
			if (this.SandGrid != null)
			{
				if (false)
				{
					goto IL_144;
				}
				if (this.SandGrid.EditingColumn == x4bbc2c453c470189)
				{
					this.SandGrid.x48546f274ac60a66(false, true, true);
				}
			}
			if (this.x60a91521cca92355(x4bbc2c453c470189, (this.x5412edcb66c29ec8 != null) ? this.x5412edcb66c29ec8 : focusableGridElement))
			{
				this.x6d6f7a19a6e74243();
				return;
			}
			return;
			IL_144:
			if (gridCell == null)
			{
				goto IL_55;
			}
			if (gridCell.NextCell == null)
			{
				goto IL_2C;
			}
			if (2 != 0)
			{
				goto IL_10;
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000A1D4 File Offset: 0x000091D4
		[Obsolete("Use SelectedElements.Revert instead.")]
		internal void xea3224fd396498d5(GridElement[] x6e96c3657c96bbbe)
		{
			this.x6fa8a9b2a6c7302a.x3522790e002e1ba4(x6e96c3657c96bbbe);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000A1E4 File Offset: 0x000091E4
		public void CopySelectedRowsToClipboard()
		{
			ArrayList arrayList = new ArrayList();
			foreach (object obj in this.x6fa8a9b2a6c7302a)
			{
				GridElement gridElement = (GridElement)obj;
				GridRow gridRow = gridElement as GridRow;
				if (gridRow != null)
				{
					arrayList.Add(gridRow);
				}
			}
			GridRow[] array = (GridRow[])arrayList.ToArray(typeof(GridRow));
			if (array.Length != 0)
			{
				ClipboardOperations.CopyRowsToClipboard(this, array);
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000A284 File Offset: 0x00009284
		public void CopySelectedCellsToClipboard(bool includeColumnHeaders)
		{
			GridCell[] cells = this.SelectedElements.GetCells();
			if (cells.Length != 0)
			{
				ClipboardOperations.CopyCellsToClipboard(this, cells, includeColumnHeaders);
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000A2AC File Offset: 0x000092AC
		internal void x12a83acc7c1ca827(ICollection x6e96c3657c96bbbe, bool x9f93ebd2ca5601a2)
		{
			foreach (object obj in x6e96c3657c96bbbe)
			{
				GridElement gridElement = (GridElement)obj;
				if (x9f93ebd2ca5601a2 && !gridElement.x213abd9ea5eb87d6)
				{
					gridElement.x213abd9ea5eb87d6 = true;
					this.x6fa8a9b2a6c7302a.xd6b6ed77479ef68c(gridElement);
				}
				else if (!x9f93ebd2ca5601a2 && gridElement.x213abd9ea5eb87d6)
				{
					gridElement.x213abd9ea5eb87d6 = false;
					this.x6fa8a9b2a6c7302a.x52b190e626f65140(gridElement);
				}
			}
			this.x6d6f7a19a6e74243();
			this.x5e7a70d58e13247a();
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000A350 File Offset: 0x00009350
		[Obsolete("Use the SelectedElements.GetCells method instead.")]
		public GridCell[] GetSelectedCells()
		{
			return this.SelectedElements.GetCells();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000A360 File Offset: 0x00009360
		public void SelectAll()
		{
			this.x614e783eda4ed71f();
			this.SelectedElements.Clear();
			foreach (object obj in this.FlatVisibleRows)
			{
				GridRow gridRow = (GridRow)obj;
				if (this.SelectionGranularity == SelectionGranularity.Row)
				{
					this.x6fa8a9b2a6c7302a.xd6b6ed77479ef68c(gridRow);
					gridRow.x213abd9ea5eb87d6 = true;
				}
				else if (gridRow.HasCells)
				{
					GridCell gridCell = null;
					for (;;)
					{
						gridCell = ((gridCell == null) ? gridRow.Cells[0] : gridCell.NextCell);
						if (gridCell == null)
						{
							break;
						}
						this.x6fa8a9b2a6c7302a.xd6b6ed77479ef68c(gridCell);
						gridCell.x213abd9ea5eb87d6 = true;
					}
				}
			}
			this.x6d6f7a19a6e74243();
			this.x06727b7d4fe7a302();
			this.x5e7a70d58e13247a();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000A43C File Offset: 0x0000943C
		private void x2f3b60e203c4300f()
		{
			this.SelectedElements.Clear();
			if (this.SandGrid != null && this.SandGrid.x737f7a4b63639f66 != null && this.SandGrid.x737f7a4b63639f66.Grid == this)
			{
				this.SandGrid.FocusedElement = null;
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000A488 File Offset: 0x00009488
		internal bool xc7f76500b5bc2b29(FocusAdvanceDirection x23e85093ba3a7d1d)
		{
			if (this.IsNested && x23e85093ba3a7d1d == FocusAdvanceDirection.Left && this.x65bb1537d51f4cd7 != null)
			{
				FocusableGridElement focusableGridElement = this.x65bb1537d51f4cd7;
				focusableGridElement.Grid.SelectElement(focusableGridElement);
				return true;
			}
			return false;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000A4C0 File Offset: 0x000094C0
		internal FocusableGridElement x297751add55a1707(bool x1c4249117d351a9f)
		{
			if (x1c4249117d351a9f)
			{
				foreach (object obj in this.SelectedElements)
				{
					GridElement gridElement = (GridElement)obj;
					if (gridElement is FocusableGridElement)
					{
						if (this.SelectionGranularity == SelectionGranularity.Row && gridElement is GridRow)
						{
							return (FocusableGridElement)gridElement;
						}
						if (this.SelectionGranularity == SelectionGranularity.Cell && gridElement is GridCell)
						{
							return (FocusableGridElement)gridElement;
						}
					}
				}
			}
			GridRow firstVisibleRow = this.GetFirstVisibleRow();
			if (firstVisibleRow != null)
			{
				if (this.SelectionGranularity == SelectionGranularity.Row)
				{
					return firstVisibleRow;
				}
				foreach (object obj2 in this.FlatVisibleRows)
				{
					GridRow gridRow = (GridRow)obj2;
					if (gridRow.Grid != null && gridRow.HasCells && gridRow.FirstVisibleCell != null && gridRow.FirstVisibleCell.Grid != null)
					{
						return gridRow.FirstVisibleCell;
					}
				}
			}
			return null;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000A608 File Offset: 0x00009608
		public void SelectElement(FocusableGridElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			if (element.Grid != this)
			{
				throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionObjectNotInGrid"), "element");
			}
			this.SelectedElements.Clear();
			if (this.SandGrid != null)
			{
				this.SandGrid.FocusedElement = element;
				if (this.SandGrid.FocusedElement == element)
				{
					element.Selected = true;
					this.SandGrid.xf023f44afe4ba919 = element;
					this.SandGrid.ScrollElementIntoView(element);
				}
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000A690 File Offset: 0x00009690
		[Obsolete("Use SelectedElements.Clear instead.")]
		public void ClearSelection()
		{
			this.x6fa8a9b2a6c7302a.Clear();
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000A6A0 File Offset: 0x000096A0
		internal void xc8a038e04921ee9d(GridElement x4bbc2c453c470189)
		{
			this.x614e783eda4ed71f();
			if (!this.AllowMultipleSelection)
			{
				this.SelectedElements.Clear();
			}
			if (!this.x6fa8a9b2a6c7302a.Contains(x4bbc2c453c470189))
			{
				this.x6fa8a9b2a6c7302a.xd6b6ed77479ef68c(x4bbc2c453c470189);
			}
			this.x6d6f7a19a6e74243();
			this.x06727b7d4fe7a302();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000A6EC File Offset: 0x000096EC
		internal void x18fb6675e951c7a8(GridElement x4bbc2c453c470189)
		{
			if (this.x6fa8a9b2a6c7302a.Contains(x4bbc2c453c470189))
			{
				this.x6fa8a9b2a6c7302a.x52b190e626f65140(x4bbc2c453c470189);
			}
			this.x6d6f7a19a6e74243();
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000A710 File Offset: 0x00009710
		internal GridRow x5813c861bfd97f54()
		{
			if (this.Rows.Count != 0)
			{
				int num = this.SandGrid.VScrollOffset + this.SandGrid.PrimaryGrid.x455ae0624abb5477.Height;
				int num2 = this.SandGrid.VScrollOffset + this.SandGrid.xd84c468937b92bf1.Height;
				GridRow gridRow = null;
				for (;;)
				{
					gridRow = ((gridRow == null) ? this.x699c923a60e155ff : gridRow.NextVisibleRow);
					if (gridRow == null)
					{
						goto IL_95;
					}
					if (gridRow.Bounds.Y >= num)
					{
						break;
					}
					if (gridRow.Bounds.Bottom > num2)
					{
						goto Block_5;
					}
				}
				return gridRow;
				Block_5:
				return null;
			}
			IL_95:
			return null;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000A7B4 File Offset: 0x000097B4
		internal GridRow x7fac5112771770c3()
		{
			int num = this.SandGrid.VScrollOffset + this.SandGrid.xd84c468937b92bf1.Height + this.SandGrid.PrimaryGrid.x455ae0624abb5477.Height;
			GridRow gridRow = this.x5813c861bfd97f54();
			GridRow result = gridRow;
			while (gridRow != null && gridRow.Bounds.Bottom <= num)
			{
				result = gridRow;
				gridRow = gridRow.NextVisibleRow;
			}
			return result;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000A828 File Offset: 0x00009828
		internal void x1f12c04eb45e4cc5()
		{
			this.x55d7940cc2a8ddcb = true;
			this.MeasureNeeded();
		}

		// Token: 0x04000012 RID: 18
		private SandGridBase xaf05a2aec36f5b1b;

		// Token: 0x04000013 RID: 19
		private bool x1158f70b6f5fc38e;

		// Token: 0x04000014 RID: 20
		private bool xfd402592e32abf89;

		// Token: 0x04000015 RID: 21
		private bool x7e619e82acd19e14 = true;

		// Token: 0x04000016 RID: 22
		private bool xa00f6b773020b855;

		// Token: 0x04000017 RID: 23
		private bool xac215e76df268d15;

		// Token: 0x04000018 RID: 24
		private bool x55d7940cc2a8ddcb;

		// Token: 0x04000019 RID: 25
		private FocusableGridElement x65bb1537d51f4cd7;

		// Token: 0x0400001A RID: 26
		private GridLinesDisplayType xd5f57c1fc5acdd8f;

		// Token: 0x0400001B RID: 27
		private string x00345ccabe7db654 = "<NULL>";

		// Token: 0x0400001C RID: 28
		private CellDragBehavior x9e1d52787f6ca7f0 = CellDragBehavior.ExtendSelection;

		// Token: 0x0400001D RID: 29
		private bool xc0016e08e2f49f5c;

		// Token: 0x0400001E RID: 30
		private bool x1485de1a2d21fca1;

		// Token: 0x0400001F RID: 31
		private bool x93ef78fd87a99a3c;

		// Token: 0x04000020 RID: 32
		private GroupHeadingClickBehavior x31d0599d6e9c56d2;

		// Token: 0x04000021 RID: 33
		private NullBehavior xebd97955e319d6dc = NullBehavior.DBNull;

		// Token: 0x04000022 RID: 34
		private RowEditMode x7e89e82b77492361;

		// Token: 0x04000023 RID: 35
		private ParentRowDoubleClickBehavior x89a09ebc2e59f4b9;

		// Token: 0x04000024 RID: 36
		private Type x223f7fc46b59a82d = typeof(GridRow);

		// Token: 0x04000025 RID: 37
		private WhitespaceClickBehavior x7294d05980c20aed = WhitespaceClickBehavior.ClearSelection;

		// Token: 0x04000026 RID: 38
		internal FocusableGridElement x5412edcb66c29ec8;

		// Token: 0x04000027 RID: 39
		private bool x8e80951f5e19e22d = true;

		// Token: 0x04000028 RID: 40
		private GridColumnCollection x26c511b92db96554;

		// Token: 0x04000029 RID: 41
		private bool x993c818ed3714592 = true;

		// Token: 0x0400002A RID: 42
		private bool x6fe255d5549a3d7e = true;

		// Token: 0x0400002B RID: 43
		private int xdccb30ad7b37c1d8;

		// Token: 0x0400002C RID: 44
		private int x7e7627de971b386a = -1;

		// Token: 0x0400002D RID: 45
		private GridColumn x5ab08995c9dbf0e5;

		// Token: 0x0400002E RID: 46
		private GridColumn xa6eeeb830ab55361;

		// Token: 0x0400002F RID: 47
		private ListSortDirection x69240d1467b772b3;

		// Token: 0x04000030 RID: 48
		private ListSortDirection x17e0b5e9156e31e3;

		// Token: 0x04000031 RID: 49
		private ColumnClickBehavior x1d7947fc05318e62 = ColumnClickBehavior.SortAndReorder;

		// Token: 0x04000032 RID: 50
		private GridRowCollection x2eb5785cf1641b8b;

		// Token: 0x04000033 RID: 51
		private bool x65bc10861281bebb;

		// Token: 0x04000034 RID: 52
		private bool x780402941498bf63 = true;

		// Token: 0x04000035 RID: 53
		private bool x8df1e502cdeec0af = true;

		// Token: 0x04000036 RID: 54
		private bool xff50b018f9a43e18 = true;

		// Token: 0x04000037 RID: 55
		private bool x7de6767fe4330081;

		// Token: 0x04000038 RID: 56
		private bool xe16b60084487a071;

		// Token: 0x04000039 RID: 57
		private int xe5d0fc219ae75ca1 = 20;

		// Token: 0x0400003A RID: 58
		private int x569663422655c5fd = -1;

		// Token: 0x0400003B RID: 59
		private RowHighlightType xb99a4fb8f58ec404 = RowHighlightType.Partial;

		// Token: 0x0400003C RID: 60
		private int x2b65c600f78c7772 = 19;

		// Token: 0x0400003D RID: 61
		private int x382b7f2aee4f455b = 40;

		// Token: 0x0400003E RID: 62
		private int xefee12953e30df70 = GridRow.x993356576cc2bf99;

		// Token: 0x0400003F RID: 63
		private RowDragBehavior xe121f8f0a679aa00 = RowDragBehavior.ExtendSelection;

		// Token: 0x04000040 RID: 64
		private Hashtable x0c750788e1a26805;

		// Token: 0x04000041 RID: 65
		private int xbd2390ed2cbc98f2;

		// Token: 0x04000042 RID: 66
		private int x41fc7455e9572f5c;

		// Token: 0x04000043 RID: 67
		private int x717defba4f5045d4;

		// Token: 0x04000044 RID: 68
		private GridRow xe3e46143afea2a63;

		// Token: 0x04000045 RID: 69
		private int x65fd3bba5ec2c2f5 = 3;

		// Token: 0x04000046 RID: 70
		private bool x107271fddfe5cc83;

		// Token: 0x04000047 RID: 71
		private bool xb04e597e744e96c5 = true;

		// Token: 0x04000048 RID: 72
		private GridColumn xc24b9a592352c63a;

		// Token: 0x04000049 RID: 73
		private SelectionGranularity xc3c8131041d547ef;

		// Token: 0x0400004A RID: 74
		private SelectedElementCollection x6fa8a9b2a6c7302a;

		// Token: 0x0400004B RID: 75
		private int x394c56dbbf0c87f6;

		// Token: 0x0400004C RID: 76
		private bool xc81d909b289dfbce;

		// Token: 0x0400004D RID: 77
		private bool x271f96fbb8e09dac = true;

		// Token: 0x0400004E RID: 78
		private xb0065acaf2259df4 x748aa855543fa4ff;
	}
}

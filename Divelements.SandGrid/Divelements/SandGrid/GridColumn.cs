using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Divelements.SandGrid.Design;
using Divelements.SandGrid.Rendering;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x02000016 RID: 22
	[DesignTimeVisible(false)]
	[DefaultProperty("HeaderText")]
	[Designer(typeof(x2ff587247dd094dd))]
	[ToolboxItem(false)]
	public class GridColumn : GridElement, IDisposable, IComponent
	{
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000301 RID: 769 RVA: 0x0001317C File Offset: 0x0001217C
		// (remove) Token: 0x06000302 RID: 770 RVA: 0x00013198 File Offset: 0x00012198
		public event EventHandler Click
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x98992f4120a73bb9 = (EventHandler)Delegate.Combine(this.x98992f4120a73bb9, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x98992f4120a73bb9 = (EventHandler)Delegate.Remove(this.x98992f4120a73bb9, value);
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000303 RID: 771 RVA: 0x000131B4 File Offset: 0x000121B4
		// (remove) Token: 0x06000304 RID: 772 RVA: 0x000131D0 File Offset: 0x000121D0
		public event EventHandler Disposed
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x17d67b299ab2c7c9 = (EventHandler)Delegate.Combine(this.x17d67b299ab2c7c9, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x17d67b299ab2c7c9 = (EventHandler)Delegate.Remove(this.x17d67b299ab2c7c9, value);
			}
		}

		// Token: 0x06000305 RID: 773 RVA: 0x000131EC File Offset: 0x000121EC
		public GridColumn()
		{
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00013294 File Offset: 0x00012294
		public GridColumn(string text) : this()
		{
			this.HeaderText = text;
		}

		// Token: 0x06000307 RID: 775 RVA: 0x000132A4 File Offset: 0x000122A4
		public GridColumn(string text, int width) : this(text)
		{
			this.Width = width;
		}

		// Token: 0x06000308 RID: 776 RVA: 0x000132B4 File Offset: 0x000122B4
		protected internal virtual IComparable GetGroupedValueForSorting(IComparable rawValue)
		{
			return rawValue;
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000132B8 File Offset: 0x000122B8
		protected internal virtual NameValuePair[] GetSuggestedValues()
		{
			return null;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000132BC File Offset: 0x000122BC
		public GridCell[] GetCells()
		{
			if (base.Grid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			ArrayList arrayList = new ArrayList();
			foreach (object obj in base.Grid.FlatVisibleRows)
			{
				GridRow gridRow = (GridRow)obj;
				if (gridRow.HasCells && gridRow.Cells.IsValidIndex(base.Index))
				{
					arrayList.Add(gridRow.Cells[base.Index]);
				}
			}
			return (GridCell[])arrayList.ToArray(typeof(GridCell));
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00013388 File Offset: 0x00012388
		internal static GridColumn[] x7fa2c2f1236c23b2(GridColumn xa7af9f855101dd73, GridColumn x2dfc9e3dbd88f4e5)
		{
			ArrayList arrayList = new ArrayList();
			bool flag = x2dfc9e3dbd88f4e5.Bounds.Left > xa7af9f855101dd73.Bounds.Left;
			GridColumn gridColumn = flag ? xa7af9f855101dd73 : x2dfc9e3dbd88f4e5;
			GridColumn gridColumn2 = flag ? x2dfc9e3dbd88f4e5 : xa7af9f855101dd73;
			arrayList.Add(gridColumn);
			GridColumn gridColumn3 = gridColumn;
			while (gridColumn3 != gridColumn2)
			{
				gridColumn3 = gridColumn3.NextColumn;
				if (gridColumn3 == null)
				{
					break;
				}
				arrayList.Add(gridColumn3);
			}
			return (GridColumn[])arrayList.ToArray(typeof(GridColumn));
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0001340C File Offset: 0x0001240C
		internal object xf69eb59aa621a379(GridRow xa806b754814b9ae0, object xbcea506a33cf9111, Type x742f2122f737ee25)
		{
			try
			{
				if (base.Grid != null && base.Grid.SandGrid != null)
				{
					GridValueTransformingEventArgs gridValueTransformingEventArgs = new GridValueTransformingEventArgs(xa806b754814b9ae0, this, xbcea506a33cf9111, x742f2122f737ee25);
					base.Grid.SandGrid.OnValueFormatting(gridValueTransformingEventArgs);
					if (gridValueTransformingEventArgs.xe35949838fcd5d1e)
					{
						xbcea506a33cf9111 = gridValueTransformingEventArgs.Value;
					}
				}
				if (base.Grid.xfb724cf23e069ca8(xbcea506a33cf9111))
				{
					return base.Grid.NullRepresentation;
				}
				if (x742f2122f737ee25.IsAssignableFrom(xbcea506a33cf9111.GetType()))
				{
					return xbcea506a33cf9111;
				}
				return this.FormatValue(xbcea506a33cf9111, x742f2122f737ee25);
			}
			catch (Exception exception)
			{
				GridDataErrorEventArgs gridDataErrorEventArgs = new GridDataErrorEventArgs(xa806b754814b9ae0, this, xbcea506a33cf9111, DataErrorOperation.Format, exception);
				base.Grid.SandGrid.xb550175c839c05f5(gridDataErrorEventArgs);
				if (gridDataErrorEventArgs.ThrowException)
				{
					throw;
				}
			}
			return xbcea506a33cf9111;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x000134DC File Offset: 0x000124DC
		protected virtual object FormatValue(object originalValue, Type desiredType)
		{
			return this.xb649a1f3d3a53090(originalValue, desiredType);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x000134E8 File Offset: 0x000124E8
		private object xb649a1f3d3a53090(object xbcea506a33cf9111, Type x742f2122f737ee25)
		{
			if (x742f2122f737ee25.IsAssignableFrom(xbcea506a33cf9111.GetType()))
			{
				return xbcea506a33cf9111;
			}
			TypeConverter converter = TypeDescriptor.GetConverter(x742f2122f737ee25);
			if (converter != null && converter.CanConvertFrom(xbcea506a33cf9111.GetType()))
			{
				return converter.ConvertFrom(xbcea506a33cf9111);
			}
			TypeConverter converter2 = TypeDescriptor.GetConverter(xbcea506a33cf9111.GetType());
			if (converter2 != null && converter2.CanConvertTo(x742f2122f737ee25))
			{
				return converter2.ConvertTo(xbcea506a33cf9111, x742f2122f737ee25);
			}
			return xbcea506a33cf9111;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00013548 File Offset: 0x00012548
		internal object x9efd48e8072f42ef(GridRow xa806b754814b9ae0, object xbcea506a33cf9111)
		{
			try
			{
				if (base.Grid != null && base.Grid.SandGrid != null)
				{
					GridValueTransformingEventArgs gridValueTransformingEventArgs = new GridValueTransformingEventArgs(xa806b754814b9ae0, this, xbcea506a33cf9111, this.DataType);
					base.Grid.SandGrid.OnValueParsing(gridValueTransformingEventArgs);
					if (gridValueTransformingEventArgs.xe35949838fcd5d1e)
					{
						xbcea506a33cf9111 = gridValueTransformingEventArgs.Value;
					}
				}
				if (xbcea506a33cf9111 == null)
				{
					return null;
				}
				if (this.DataType.IsAssignableFrom(xbcea506a33cf9111.GetType()))
				{
					return xbcea506a33cf9111;
				}
				return this.ParseValue(xa806b754814b9ae0, xbcea506a33cf9111, this.DataType);
			}
			catch (Exception exception)
			{
				GridDataErrorEventArgs gridDataErrorEventArgs = new GridDataErrorEventArgs(xa806b754814b9ae0, this, xbcea506a33cf9111, DataErrorOperation.Parse, exception);
				base.Grid.SandGrid.xb550175c839c05f5(gridDataErrorEventArgs);
				if (gridDataErrorEventArgs.ThrowException)
				{
					throw;
				}
			}
			return xbcea506a33cf9111;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00013614 File Offset: 0x00012614
		protected virtual object ParseValue(GridRow row, object formattedValue, Type desiredType)
		{
			return this.xb649a1f3d3a53090(formattedValue, desiredType);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00013620 File Offset: 0x00012620
		protected virtual string GetGroupHeadingText(GridRow row)
		{
			return this.xf69eb59aa621a379(row, row.GetCellValue(this), typeof(string)) as string;
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00013640 File Offset: 0x00012640
		protected internal virtual bool IsSameGroup(GridRow row, ref object previousObject, out string newGroupName)
		{
			if (row == null)
			{
				throw new ArgumentNullException("row");
			}
			if (base.Grid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			newGroupName = null;
			string text = previousObject as string;
			string groupHeadingText = this.GetGroupHeadingText(row);
			if (text != null)
			{
				bool flag = groupHeadingText.CompareTo(text) == 0;
				if (!flag)
				{
					previousObject = groupHeadingText;
					newGroupName = groupHeadingText;
				}
				return flag;
			}
			previousObject = groupHeadingText;
			newGroupName = groupHeadingText;
			return false;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x000136A8 File Offset: 0x000126A8
		public void SizeToContents()
		{
			this.SizeToContents(0, true);
		}

		// Token: 0x06000314 RID: 788 RVA: 0x000136B4 File Offset: 0x000126B4
		public void SizeToContents(int minimumSize, bool includeHeader)
		{
			if (minimumSize < 0)
			{
				throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNegative"), "value");
			}
			if (this.AutoSize == ColumnAutoSizeMode.Spring)
			{
				return;
			}
			this.Width = Math.Max(minimumSize, this.GetMaximumCellWidth(RowScope.OnscreenRows, includeHeader));
		}

		// Token: 0x06000315 RID: 789 RVA: 0x000136F0 File Offset: 0x000126F0
		public int GetMaximumCellWidth(RowScope scope, bool includeHeader)
		{
			if (base.Grid == null || base.Grid.SandGrid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			int num = 0;
			using (TextFormattingInformation xf12e60079a6c0aac = this.CreateTextFormat(GridColumnTextFormatType.Cell))
			{
				using (Graphics graphics = base.Grid.SandGrid.CreateGraphics())
				{
					foreach (object obj in ((scope == RowScope.AllRows || base.Grid.IsNested) ? base.Grid.FlatVisibleRows : base.Grid.SandGrid.OnscreenRows))
					{
						GridRow x7108a033166ea18e = (GridRow)obj;
						int val = this.x89c7f17f3be901a8(graphics, x7108a033166ea18e, xf12e60079a6c0aac);
						num = Math.Max(num, val);
					}
					if (includeHeader)
					{
						using (TextFormattingInformation xf12e60079a6c0aac2 = this.CreateTextFormat(GridColumnTextFormatType.Header))
						{
							num = Math.Max(num, this.x682a7b8b7ed09fa7(graphics, xf12e60079a6c0aac2));
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00013864 File Offset: 0x00012864
		private int x682a7b8b7ed09fa7(Graphics x41347a961b838962, TextFormattingInformation xf12e60079a6c0aac)
		{
			int num = IndependentText.MeasureText(x41347a961b838962, this.HeaderText, base.Font, xf12e60079a6c0aac).Width + 8;
			if (this.HeaderImage != null && this.HeaderHorizontalAlignment != StringAlignment.Center)
			{
				num += this.HeaderImage.Width + base.Grid.ImageTextSeparation;
			}
			return num;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000138BC File Offset: 0x000128BC
		private int x89c7f17f3be901a8(Graphics x41347a961b838962, GridRow x7108a033166ea18e, TextFormattingInformation xf12e60079a6c0aac)
		{
			string text = this.xf69eb59aa621a379(x7108a033166ea18e, x7108a033166ea18e.GetCellValue(this), typeof(string)) as string;
			Font font = (x7108a033166ea18e.HasCells && x7108a033166ea18e.Cells.IsValidIndex(base.Index)) ? x7108a033166ea18e.Cells[base.Index].Font : x7108a033166ea18e.Font;
			int num = IndependentText.MeasureText(x41347a961b838962, text, this.UseCellFont ? font : base.Font, xf12e60079a6c0aac).Width + 8;
			Image cellImage = x7108a033166ea18e.GetCellImage(this);
			if (cellImage != null)
			{
				num += cellImage.Width + base.Grid.ImageTextSeparation;
			}
			if (this.IsPrimary)
			{
				Rectangle bounds = new Rectangle(0, 0, int.MaxValue, 0);
				int num2 = int.MaxValue - x7108a033166ea18e.AdjustForIndentation(bounds).Width;
				num += num2;
			}
			return num;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000139A0 File Offset: 0x000129A0
		protected internal override string GetTooltipText(Point position)
		{
			if (this.ToolTip.Length != 0)
			{
				return this.ToolTip;
			}
			if (this.IsTextOverflowing(null))
			{
				return this.HeaderText;
			}
			return string.Empty;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000139CC File Offset: 0x000129CC
		protected internal virtual bool IsTextOverflowing(GridRow row)
		{
			if (base.Grid == null || base.Grid.SandGrid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			bool result = false;
			using (TextFormattingInformation xf12e60079a6c0aac = this.CreateTextFormat((row == null) ? GridColumnTextFormatType.Header : GridColumnTextFormatType.Cell))
			{
				using (Graphics graphics = base.Grid.SandGrid.CreateGraphics())
				{
					if (row == null)
					{
						result = (this.x682a7b8b7ed09fa7(graphics, xf12e60079a6c0aac) > this.Width);
					}
					else
					{
						result = (this.x89c7f17f3be901a8(graphics, row, xf12e60079a6c0aac) > this.Width);
					}
				}
			}
			return result;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00013A98 File Offset: 0x00012A98
		internal override void xea1c0bc64ab77594(InnerGrid xf57b149cb3f9c03a)
		{
			if (base.Grid != null && this.SortOrder != SortOrder.None)
			{
				base.Grid.ClearSort();
			}
			base.xea1c0bc64ab77594(xf57b149cb3f9c03a);
			this.x52d5887fb276a6ba = false;
			this.xf24f9f2ecbfc5620 = null;
			this.x790048e39c67d0fb = null;
			this.xcb8e8afd0ea818cd = 0;
			this.x0be0482b5fb3b33d = SortOrder.None;
			if (xf57b149cb3f9c03a != null && this.x47549aefae74027e.Length != 0)
			{
				xf57b149cb3f9c03a.xf7d63e21204b8665(this);
			}
			if (xf57b149cb3f9c03a != null && xf57b149cb3f9c03a.x0f405f185e70ec01 != null)
			{
				xf57b149cb3f9c03a.x0f405f185e70ec01.xa6889a3f6696d64b();
			}
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00013B18 File Offset: 0x00012B18
		public void ToggleSort()
		{
			if (base.Grid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			if (base.Grid.SortColumn == this)
			{
				base.Grid.SortDirection = ((base.Grid.SortDirection == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending);
				if (base.Grid.GroupColumn == this)
				{
					base.Grid.GroupDirection = base.Grid.SortDirection;
					return;
				}
			}
			else
			{
				base.Grid.SortDirection = ListSortDirection.Ascending;
				base.Grid.SortColumn = this;
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00013BA4 File Offset: 0x00012BA4
		public void ToggleMultiColumnSort()
		{
			if (base.Grid == null)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			GridColumn[] array;
			ListSortDirection[] array2;
			base.Grid.Rows.GetSort(out array, out array2);
			int num = Array.IndexOf<GridColumn>(array, this);
			if (num != -1)
			{
				array2[num] = ((array2[num] == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending);
				base.Grid.SetSort(array, array2);
				return;
			}
			GridColumn[] array3 = new GridColumn[array.Length + 1];
			ListSortDirection[] array4 = new ListSortDirection[array2.Length + 1];
			Array.Copy(array, array3, array.Length);
			Array.Copy(array2, array4, array2.Length);
			array3[array3.Length - 1] = this;
			array4[array4.Length - 1] = ListSortDirection.Ascending;
			base.Grid.SetSort(array3, array4);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00013C50 File Offset: 0x00012C50
		protected internal virtual void OnClick(EventArgs e)
		{
			if (this.x98992f4120a73bb9 != null)
			{
				this.x98992f4120a73bb9(this, e);
			}
			if (this.AutoSortType != ColumnAutoSortType.None)
			{
				if (this.AutoSortType == ColumnAutoSortType.Multiple && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
				{
					this.ToggleMultiColumnSort();
				}
				else
				{
					this.ToggleSort();
				}
			}
			if (base.Grid != null && base.Grid.SandGrid != null)
			{
				base.Grid.SandGrid.OnColumnHeaderClick(new GridColumnEventArgs(this));
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00013CD0 File Offset: 0x00012CD0
		private void xa68c5feef6d1b80b(MouseEventArgs xfbf34718e704c6bc)
		{
			if (this.AutoSize == ColumnAutoSizeMode.Spring)
			{
				bool flag = false;
				for (int i = this.DisplayIndex + 1; i < base.Grid.Columns.DisplayColumns.Length; i++)
				{
					GridColumn gridColumn = base.Grid.Columns.DisplayColumns[i];
					if (gridColumn.AutoSize == ColumnAutoSizeMode.Spring)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return;
				}
			}
			base.x11f639c5d61688d8(new x80261b4fd91026f6(this, new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y)));
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00013D50 File Offset: 0x00012D50
		protected internal override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (3 != 0)
			{
				this.x6afebf16b45c02e0 = new Point(e.X, e.Y);
				if (!this.xd41aaa8eedfc4d64.Contains(e.X, e.Y))
				{
					goto IL_82;
				}
			}
			if (this.CanResize())
			{
				this.xa68c5feef6d1b80b(e);
				return;
			}
			IL_82:
			if (this.PreviousColumn == null)
			{
				goto IL_CB;
			}
			Rectangle x32721c48c6c83db = this.x32721c48c6c83db0;
			IL_91:
			if (x32721c48c6c83db.Contains(e.X, e.Y) && this.PreviousColumn.CanResize())
			{
				x5d3666f49ba1c366.x76b0eec27bc2d901(this.PreviousColumn);
				this.PreviousColumn.xa68c5feef6d1b80b(e);
				return;
			}
			IL_CB:
			if (e.Button == MouseButtons.Left && this.Clickable)
			{
				if (base.Grid.ColumnClickBehavior == ColumnClickBehavior.Select)
				{
					if (!base.Grid.AllowMultipleSelection)
					{
						base.Grid.SelectedElements.Clear();
						base.Selected = true;
						return;
					}
					if (!false)
					{
						base.x11f639c5d61688d8(new x3b1e2f322c5dd3fc(this, new Point(e.X, e.Y)));
						return;
					}
					goto IL_91;
				}
				else
				{
					if (base.Grid.ColumnClickBehavior == ColumnClickBehavior.SortAndReorder)
					{
						base.x11f639c5d61688d8(new x04ffb75ad95b33a7(this, new Point(e.X, e.Y)));
						return;
					}
					if (base.Grid.ColumnClickBehavior == ColumnClickBehavior.InitiateDragDrop)
					{
						base.x11f639c5d61688d8(new x40917da28fd6d442(this, new Point(e.X, e.Y)));
					}
				}
			}
		}

		// Token: 0x06000320 RID: 800 RVA: 0x00013EDC File Offset: 0x00012EDC
		protected internal override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);
			if (this.PreviousColumn != null && this.x32721c48c6c83db0.Contains(e.X, e.Y) && this.PreviousColumn.ResizeBehavior != ElementResizeBehavior.None)
			{
				this.PreviousColumn.SizeToContents(this.PreviousColumn.MinimumWidth, true);
				if (this.PreviousColumn.Grid != null && this.PreviousColumn.Grid.SandGrid != null)
				{
					this.PreviousColumn.Grid.SandGrid.OnColumnResized(new GridColumnEventArgs(this.PreviousColumn));
					return;
				}
			}
			else if (this.ResizeBehavior != ElementResizeBehavior.None && this.xd41aaa8eedfc4d64.Contains(e.X, e.Y))
			{
				this.SizeToContents(this.MinimumWidth, true);
				if (base.Grid != null && base.Grid.SandGrid != null)
				{
					base.Grid.SandGrid.OnColumnResized(new GridColumnEventArgs(this));
				}
			}
		}

		// Token: 0x06000321 RID: 801 RVA: 0x00013FE0 File Offset: 0x00012FE0
		internal void xac8b6c0bf0d842f9(int x54fbdcd9c742ce28)
		{
			int[] array = new int[base.Grid.Columns.Count];
			for (int i = 0; i < base.Grid.Columns.Count; i++)
			{
				array[i] = base.Grid.Columns[i].DisplayIndex;
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] >= x54fbdcd9c742ce28)
				{
					array[j]++;
				}
			}
			array[base.Index] = x54fbdcd9c742ce28;
			base.Grid.Columns.SetDisplayIndices(array);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0001407C File Offset: 0x0001307C
		protected internal virtual bool CanResize()
		{
			return base.Grid != null && this.ResizeBehavior != ElementResizeBehavior.None && this.AutoSize != ColumnAutoSizeMode.Contents;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x000140A0 File Offset: 0x000130A0
		protected internal override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (GridElement.x263912479c3c5786 == null)
			{
				if (this.PreviousColumn != null && this.x32721c48c6c83db0.Contains(e.X, e.Y) && this.PreviousColumn.CanResize())
				{
					Cursor.Current = Cursors.VSplit;
					return;
				}
				if (this.xd41aaa8eedfc4d64.Contains(e.X, e.Y) && this.CanResize())
				{
					Cursor.Current = Cursors.VSplit;
				}
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000324 RID: 804 RVA: 0x00014128 File Offset: 0x00013128
		// (set) Token: 0x06000325 RID: 805 RVA: 0x00014130 File Offset: 0x00013130
		[Category("Behavior")]
		[DefaultValue(0)]
		[Description("Indicates the minimum width to which the user can change the column.")]
		public int MinimumWidth
		{
			get
			{
				return this.x6a4276d77d423aa0;
			}
			set
			{
				this.x6a4276d77d423aa0 = value;
				if (this.AutoSize == ColumnAutoSizeMode.Contents)
				{
					base.MeasureNeeded();
				}
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000326 RID: 806 RVA: 0x00014148 File Offset: 0x00013148
		private bool x94975a4c4f1d71c4
		{
			get
			{
				return base.Grid != null && base.Grid.RightToLeft;
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00014160 File Offset: 0x00013160
		private Rectangle x32721c48c6c83db0
		{
			get
			{
				if (!this.x94975a4c4f1d71c4)
				{
					return this.xf49d4774b267a153;
				}
				return this.x45e941e57a96d27d;
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000328 RID: 808 RVA: 0x00014178 File Offset: 0x00013178
		private Rectangle xd41aaa8eedfc4d64
		{
			get
			{
				if (!this.x94975a4c4f1d71c4)
				{
					return this.x45e941e57a96d27d;
				}
				return this.xf49d4774b267a153;
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00014190 File Offset: 0x00013190
		private Rectangle xf49d4774b267a153
		{
			get
			{
				return new Rectangle(base.Bounds.Left, base.Bounds.Top, 5, base.Bounds.Height);
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600032A RID: 810 RVA: 0x000141D0 File Offset: 0x000131D0
		private Rectangle x45e941e57a96d27d
		{
			get
			{
				return new Rectangle(base.Bounds.Right - 5, base.Bounds.Top, 10, base.Bounds.Height);
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00014210 File Offset: 0x00013210
		private Rectangle x0a594b9d6473ad89(RenderingContext x0f7b23d1c393aed9, Rectangle x64238b90d7eeb2c8, string xb41faee6912a2313, Font x26094932cf7a9139, TextFormattingInformation xae3b2752a89e7464)
		{
			Size size = IndependentText.MeasureText(x0f7b23d1c393aed9.Graphics, xb41faee6912a2313, x26094932cf7a9139, x64238b90d7eeb2c8.Width, xae3b2752a89e7464);
			if (this.x94975a4c4f1d71c4 && size.Width < x64238b90d7eeb2c8.Width)
			{
				x64238b90d7eeb2c8.X = x64238b90d7eeb2c8.Right - size.Width;
			}
			x64238b90d7eeb2c8.Width = Math.Min(x64238b90d7eeb2c8.Width, size.Width);
			x64238b90d7eeb2c8.Inflate(0, -(x64238b90d7eeb2c8.Height - size.Height) / 2);
			x64238b90d7eeb2c8.Inflate(2, 2);
			return x64238b90d7eeb2c8;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x000142A4 File Offset: 0x000132A4
		protected internal virtual void DrawCell(RenderingContext context, GridRow row, object value, Font cellFont, Image image, Rectangle bounds, bool selected, TextFormattingInformation textFormat, Color cellForeColor)
		{
			Font font;
			if (this.UseCellFont)
			{
				font = cellFont;
				goto IL_21E;
			}
			if (!false)
			{
				goto IL_214;
			}
			IL_11:
			string text;
			Font font2;
			if (this.IsPrimary)
			{
				row.x6286548365a5b7f9(this.x0a594b9d6473ad89(context, bounds, text, font2, textFormat));
				if ((selected || context.xf58ff9ce0e24a20c == row) && !context.HideSelection)
				{
					context.Renderer.DrawSelectionRectangle(context.Graphics, row.x0494e81625d97ffc(), selected, context.ContainsFocus, context.xf58ff9ce0e24a20c == row && context.FocusRectanglesEnabled);
					if (((selected ? 1U : 0U) | 1U) == 0U)
					{
						goto IL_22C;
					}
				}
			}
			IL_90:
			Color effectiveForeColor;
			if (bounds.Width > 0 && text != null)
			{
				if (selected)
				{
					IndependentText.DrawText(context.Graphics, text, font2, bounds, textFormat, context.Renderer.GetSelectedTextColor(context.ContainsFocus));
					return;
				}
				IndependentText.DrawText(context.Graphics, text, font2, bounds, textFormat, effectiveForeColor);
				if (false)
				{
					goto IL_214;
				}
			}
			return;
			IL_214:
			font = base.Font;
			IL_21E:
			font2 = font;
			effectiveForeColor = this.GetEffectiveForeColor(cellForeColor);
			bool flag;
			if (selected)
			{
				flag = true;
				goto IL_235;
			}
			IL_22C:
			flag = base.Selected;
			IL_235:
			selected = flag;
			text = (this.xf69eb59aa621a379(row, value, typeof(string)) as string);
			bounds.Inflate(-4, 0);
			if (image != null && bounds.Width >= image.Width && this.CellHorizontalAlignment != StringAlignment.Center)
			{
				bool flag2 = (base.Grid.RightToLeft && this.CellHorizontalAlignment == StringAlignment.Near) || (!base.Grid.RightToLeft && this.CellHorizontalAlignment == StringAlignment.Far);
				Rectangle rect = new Rectangle(bounds.Left, bounds.Top + bounds.Height / 2 - image.Height / 2, image.Width, image.Height);
				if (flag2)
				{
					rect.X = bounds.Right - image.Width;
				}
				if (selected && context.ContainsFocus && base.Grid.HighlightImages)
				{
					using (Image image2 = DrawingMethods.CreateHighlightedImage(image, 0.5f))
					{
						context.Graphics.DrawImage(image2, rect);
						goto IL_1BC;
					}
				}
				context.Graphics.DrawImage(image, rect);
				IL_1BC:
				if (!flag2)
				{
					bounds.X += image.Width + base.Grid.ImageTextSeparation;
				}
				bounds.Width -= image.Width + base.Grid.ImageTextSeparation;
			}
			if (base.Grid.RowHighlightType == RowHighlightType.PrimaryColumnOnly)
			{
				goto IL_11;
			}
			goto IL_90;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00014550 File Offset: 0x00013550
		protected internal virtual void DrawBackground(RenderingContext context, Rectangle bounds)
		{
			if (base.Selected && !context.HideSelection)
			{
				context.Renderer.DrawSelectionRectangle(context.Graphics, bounds, true, context.ContainsFocus, false);
				return;
			}
			if (this.x0be0482b5fb3b33d != SortOrder.None)
			{
				context.Renderer.DrawSortedColumnBackground(context.Graphics, this, bounds);
			}
		}

		// Token: 0x0600032E RID: 814 RVA: 0x000145A4 File Offset: 0x000135A4
		protected internal virtual void DrawHeader(RenderingContext context, TextFormattingInformation textFormat)
		{
			Divelements.SandGrid.Rendering.DrawItemState drawItemState = Divelements.SandGrid.Rendering.DrawItemState.None;
			if (this.Clickable)
			{
				if (base.Hot)
				{
					drawItemState |= Divelements.SandGrid.Rendering.DrawItemState.Hot;
				}
				if (this.x52d5887fb276a6ba)
				{
					drawItemState |= Divelements.SandGrid.Rendering.DrawItemState.Pushed;
				}
			}
			context.Renderer.DrawColumnHeader(context.Graphics, this, base.Bounds, textFormat, drawItemState);
			if (GridElement.x263912479c3c5786 is x04ffb75ad95b33a7 && GridElement.x263912479c3c5786.x2dcc7207ee287dbb == this && base.Grid.VerticalMarkerPosition != -1)
			{
				base.Grid.x86b14c423a0c12f3 = this;
			}
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00014620 File Offset: 0x00013620
		internal void xb71ffb553d86d907(RenderingContext x0f7b23d1c393aed9)
		{
			using (TextFormattingInformation textFormat = this.CreateTextFormat(GridColumnTextFormatType.Header))
			{
				Rectangle bounds = base.Bounds;
				bounds.Offset(base.Grid.SandGrid.PointToClient(Cursor.Position).X - this.x6afebf16b45c02e0.X, 0);
				bounds.Offset(base.Grid.SandGrid.HScrollOffset, 0);
				using (Bitmap bitmap = new Bitmap(base.Bounds.Width, base.Bounds.Height))
				{
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.TranslateTransform((float)(-(float)base.Bounds.X), (float)(-(float)base.Bounds.Y));
						xf4604fd5d5aa5ebd.xf27faba8bf71f5c9(base.Bounds.X, base.Bounds.Y);
						graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
						bool xc50a22da327d908e = IndependentText.xc50a22da327d908e;
						IndependentText.xc50a22da327d908e = true;
						x0f7b23d1c393aed9.Renderer.DrawColumnHeader(graphics, this, base.Bounds, textFormat, Divelements.SandGrid.Rendering.DrawItemState.None);
						IndependentText.xc50a22da327d908e = xc50a22da327d908e;
						xf4604fd5d5aa5ebd.x71d716d9340a225a();
					}
					using (ImageAttributes imageAttributes = new ImageAttributes())
					{
						imageAttributes.SetColorMatrix(new ColorMatrix
						{
							Matrix33 = 0.5f,
							Matrix00 = 0.8f,
							Matrix11 = 0.8f,
							Matrix22 = 0.8f
						});
						x0f7b23d1c393aed9.Graphics.DrawImage(bitmap, bounds, 0, 0, base.Bounds.Width, base.Bounds.Height, GraphicsUnit.Pixel, imageAttributes);
					}
				}
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00014844 File Offset: 0x00013844
		protected internal virtual TextFormattingInformation CreateTextFormat(GridColumnTextFormatType textFormatType)
		{
			return TextFormattingInformation.CreateFormattingInformation(base.Grid.RightToLeft, this.AllowWrap, (textFormatType == GridColumnTextFormatType.Cell) ? this.CellHorizontalAlignment : this.HeaderHorizontalAlignment, (textFormatType == GridColumnTextFormatType.Cell) ? this.CellVerticalAlignment : StringAlignment.Center, this.ClipText);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00014880 File Offset: 0x00013880
		protected override void LayoutCore(Rectangle bounds)
		{
			this.x0961517ffd55017f = bounds;
			this.x0961517ffd55017f.Height = this.x0961517ffd55017f.Height - 2;
			this.x0961517ffd55017f.Inflate(-4, -2);
			this.xfe4205d5dd815113 = Rectangle.Empty;
			if (this.HeaderImage == null)
			{
				goto IL_215;
			}
			if (this.HeaderHorizontalAlignment == StringAlignment.Center && this.HeaderText.Length == 0)
			{
				this.xfe4205d5dd815113 = new Rectangle(this.x0961517ffd55017f.X + this.x0961517ffd55017f.Width / 2 - this.HeaderImage.Width / 2, this.x0961517ffd55017f.Y + this.x0961517ffd55017f.Height / 2 - this.HeaderImage.Height / 2, this.HeaderImage.Width, this.HeaderImage.Height);
				this.x0961517ffd55017f = Rectangle.Empty;
				goto IL_215;
			}
			IL_D7:
			int num = this.HeaderImage.Width + ((this.HeaderText.Length != 0) ? base.Grid.ImageTextSeparation : 0);
			if (this.x0961517ffd55017f.Width >= num)
			{
				if ((this.HeaderHorizontalAlignment == StringAlignment.Near && !base.Grid.RightToLeft) || (this.HeaderHorizontalAlignment == StringAlignment.Far && base.Grid.RightToLeft))
				{
					this.xfe4205d5dd815113 = new Rectangle(this.x0961517ffd55017f.Left, this.x0961517ffd55017f.Top + this.x0961517ffd55017f.Height / 2 - this.HeaderImage.Height / 2, this.HeaderImage.Width, this.HeaderImage.Height);
					this.x0961517ffd55017f.X = this.x0961517ffd55017f.X + num;
				}
				else
				{
					this.xfe4205d5dd815113 = new Rectangle(this.x0961517ffd55017f.Right - this.HeaderImage.Width, this.x0961517ffd55017f.Top + this.x0961517ffd55017f.Height / 2 - this.HeaderImage.Height / 2, this.HeaderImage.Width, this.HeaderImage.Height);
				}
				this.x0961517ffd55017f.Width = this.x0961517ffd55017f.Width - num;
			}
			IL_215:
			if (this.x0961517ffd55017f.Width > 0)
			{
				if (this.x0961517ffd55017f.Height > 0)
				{
					return;
				}
				if (false)
				{
					goto IL_D7;
				}
			}
			this.x0961517ffd55017f = Rectangle.Empty;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x00014AD0 File Offset: 0x00013AD0
		protected override Size MeasureCore(Graphics graphics, TextFormattingInformation textFormat, bool rtl)
		{
			int num = this.Width - 8;
			if (this.HeaderImage != null)
			{
				num -= this.HeaderImage.Width + base.Grid.ImageTextSeparation;
			}
			Size size = IndependentText.MeasureText(graphics, this.HeaderText, base.Font, num, textFormat);
			return new Size(this.Width, size.Height + 4 + 2);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00014B34 File Offset: 0x00013B34
		public virtual GridCell CreateCell()
		{
			return new GridCell();
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00014B3C File Offset: 0x00013B3C
		protected Color GetEffectiveForeColor(Color rowColor)
		{
			if (this.xf8da379cc6c93388 == CellForeColorSource.Column)
			{
				return this.ForeColor;
			}
			if (this.xf8da379cc6c93388 == CellForeColorSource.Grid && base.Grid != null && base.Grid.SandGrid != null)
			{
				return base.Grid.SandGrid.ForeColor;
			}
			return rowColor;
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000335 RID: 821 RVA: 0x00014B8C File Offset: 0x00013B8C
		internal virtual bool xea4c5fde728d3b8e
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000336 RID: 822 RVA: 0x00014B90 File Offset: 0x00013B90
		[Browsable(false)]
		public virtual Type DataType
		{
			get
			{
				if (this.IsDataBound)
				{
					return this.xeface77359be8ccd;
				}
				return typeof(string);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000337 RID: 823 RVA: 0x00014BAC File Offset: 0x00013BAC
		[Browsable(false)]
		public SortOrder SortOrder
		{
			get
			{
				return this.x0be0482b5fb3b33d;
			}
		}

		// Token: 0x06000338 RID: 824 RVA: 0x00014BB4 File Offset: 0x00013BB4
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void SetSortIndicator(SortOrder sortOrder)
		{
			this.x0be0482b5fb3b33d = sortOrder;
			base.RedrawNeeded();
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000339 RID: 825 RVA: 0x00014BC4 File Offset: 0x00013BC4
		// (set) Token: 0x0600033A RID: 826 RVA: 0x00014BCC File Offset: 0x00013BCC
		[Description("Gets or sets the type of editor used to edit values in the column.")]
		[DefaultValue(typeof(GridTextBoxEditor))]
		[TypeConverter(typeof(x57b43ec0b7c08380))]
		[Category("Behavior")]
		public Type EditorType
		{
			get
			{
				return this.xbeb1c4d7553f61e7;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (!value.IsSubclassOf(typeof(Control)) || value.GetInterface("Divelements.SandGrid.IGridCellEditor") != typeof(IGridCellEditor))
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionEditorWrongType"), "value");
				}
				this.xbeb1c4d7553f61e7 = value;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600033B RID: 827 RVA: 0x00014C2C File Offset: 0x00013C2C
		// (set) Token: 0x0600033C RID: 828 RVA: 0x00014C34 File Offset: 0x00013C34
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Indicates whether text in cells is allowed to wrap.")]
		public bool AllowWrap
		{
			get
			{
				return this.xa111e162261991b2;
			}
			set
			{
				this.xa111e162261991b2 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600033D RID: 829 RVA: 0x00014C44 File Offset: 0x00013C44
		// (set) Token: 0x0600033E RID: 830 RVA: 0x00014C4C File Offset: 0x00013C4C
		[Category("Behavior")]
		[DefaultValue(typeof(ColumnAutoSizeMode), "None")]
		[Description("Indicates how the column will automatically size itself.")]
		public ColumnAutoSizeMode AutoSize
		{
			get
			{
				return this.x6b73ba14fabc6cb0;
			}
			set
			{
				if (value != this.x6b73ba14fabc6cb0)
				{
					this.x6b73ba14fabc6cb0 = value;
					if (base.Grid != null)
					{
						base.Grid.Columns.xe3d225b642287874();
					}
				}
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600033F RID: 831 RVA: 0x00014C78 File Offset: 0x00013C78
		// (set) Token: 0x06000340 RID: 832 RVA: 0x00014C80 File Offset: 0x00013C80
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Indicates whether column header text is accounted for when autosizing based on contents.")]
		public bool AutoSizeIncludeHeader
		{
			get
			{
				return this.xd3052160545d046f;
			}
			set
			{
				this.xd3052160545d046f = value;
				if (base.Grid != null)
				{
					base.Grid.Columns.xe3d225b642287874();
				}
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000341 RID: 833 RVA: 0x00014CA4 File Offset: 0x00013CA4
		[Browsable(false)]
		public bool IsPrimary
		{
			get
			{
				return this.x769bd68fb8b619a2;
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00014CAC File Offset: 0x00013CAC
		internal void x826c61806b563083(bool x769bd68fb8b619a2)
		{
			this.x769bd68fb8b619a2 = x769bd68fb8b619a2;
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000343 RID: 835 RVA: 0x00014CB8 File Offset: 0x00013CB8
		// (set) Token: 0x06000344 RID: 836 RVA: 0x00014CC0 File Offset: 0x00013CC0
		[DefaultValue("")]
		[Description("Gets or sets the name of the data source property or database column to which the column is bound.")]
		[Category("Data")]
		[TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		public string DataPropertyName
		{
			get
			{
				return this.x47549aefae74027e;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				if (value != this.x47549aefae74027e)
				{
					this.x47549aefae74027e = value;
					if (base.Grid != null)
					{
						base.Grid.xf7d63e21204b8665(this);
					}
				}
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00014CF8 File Offset: 0x00013CF8
		internal void x42d80cc5d994096e(bool xde7e53ab273d10d4, int xb18727061e7ae069, Type x7474ea63400af254)
		{
			this.xde7e53ab273d10d4 = xde7e53ab273d10d4;
			this.xb18727061e7ae069 = xb18727061e7ae069;
			this.xeface77359be8ccd = x7474ea63400af254;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00014D10 File Offset: 0x00013D10
		protected internal void RedrawNeeded(bool contents)
		{
			if (contents)
			{
				if (base.Grid != null)
				{
					base.Grid.x5e7a70d58e13247a(new Rectangle(base.Bounds.Left, base.Grid.Bounds.Top, base.Bounds.Width, base.Grid.Bounds.Height));
					return;
				}
			}
			else
			{
				base.RedrawNeeded();
			}
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00014D84 File Offset: 0x00013D84
		internal override void xc1a3c3f3ff56b5d0()
		{
			this.RedrawNeeded(true);
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000348 RID: 840 RVA: 0x00014D90 File Offset: 0x00013D90
		internal int xafbad39eb3920055
		{
			get
			{
				return this.xb18727061e7ae069;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000349 RID: 841 RVA: 0x00014D98 File Offset: 0x00013D98
		[Browsable(false)]
		public bool IsDataBound
		{
			get
			{
				return this.xde7e53ab273d10d4;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600034A RID: 842 RVA: 0x00014DA0 File Offset: 0x00013DA0
		// (set) Token: 0x0600034B RID: 843 RVA: 0x00014DA8 File Offset: 0x00013DA8
		[Description("Indicates whether the column is visible.")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool Visible
		{
			get
			{
				return this.x364c1e3b189d47fe;
			}
			set
			{
				if (value != this.x364c1e3b189d47fe)
				{
					this.x364c1e3b189d47fe = value;
					if (base.Grid != null)
					{
						if (!value)
						{
							this.x6b07393102fa412e();
						}
						base.Grid.Columns.xe3d225b642287874();
					}
				}
			}
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00014DDC File Offset: 0x00013DDC
		private void x6b07393102fa412e()
		{
			base.Grid.x60a91521cca92355(this.GetCells());
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600034D RID: 845 RVA: 0x00014DF0 File Offset: 0x00013DF0
		// (set) Token: 0x0600034E RID: 846 RVA: 0x00014DF8 File Offset: 0x00013DF8
		internal bool x6cd50582c82f9b4d
		{
			get
			{
				return this.x364c1e3b189d47fe;
			}
			set
			{
				this.x364c1e3b189d47fe = value;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600034F RID: 847 RVA: 0x00014E04 File Offset: 0x00013E04
		// (set) Token: 0x06000350 RID: 848 RVA: 0x00014E0C File Offset: 0x00013E0C
		[DefaultValue(true)]
		[Description("Indicates whether the contents of the column can be edited.")]
		[Category("Behavior")]
		public bool AllowEditing
		{
			get
			{
				return this.x9b137508136d227b;
			}
			set
			{
				this.x9b137508136d227b = value;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00014E18 File Offset: 0x00013E18
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00014E20 File Offset: 0x00013E20
		[Description("The image to display in the column header.")]
		[AmbientValue(typeof(Image), null)]
		[DefaultValue(typeof(Image), null)]
		[Category("Appearance")]
		public virtual Image HeaderImage
		{
			get
			{
				return this.x963101f67c44464e;
			}
			set
			{
				this.x963101f67c44464e = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00014E30 File Offset: 0x00013E30
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00014E38 File Offset: 0x00013E38
		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether text that cannot be shrunk any further will be clipped.")]
		public bool ClipText
		{
			get
			{
				return this.x8ca4e5394a6baaae;
			}
			set
			{
				this.x8ca4e5394a6baaae = value;
				this.RedrawNeeded(true);
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00014E48 File Offset: 0x00013E48
		// (set) Token: 0x06000356 RID: 854 RVA: 0x00014E50 File Offset: 0x00013E50
		[Description("The color of text drawn under the column.")]
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "WindowText")]
		public Color ForeColor
		{
			get
			{
				return this.x93532ca0ace0c1ae;
			}
			set
			{
				this.x93532ca0ace0c1ae = value;
				if (base.Grid != null)
				{
					Rectangle bounds = base.Grid.Bounds;
					bounds.X = base.Bounds.X;
					bounds.Width = base.Bounds.Width;
					base.Grid.x5e7a70d58e13247a(bounds);
				}
			}
		}

		// Token: 0x06000357 RID: 855 RVA: 0x00014EB0 File Offset: 0x00013EB0
		protected override void OnHotChanged()
		{
			base.OnHotChanged();
			if (!base.Hot)
			{
				this.x52d5887fb276a6ba = false;
			}
			base.RedrawNeeded();
		}

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000358 RID: 856 RVA: 0x00014ED0 File Offset: 0x00013ED0
		// (set) Token: 0x06000359 RID: 857 RVA: 0x00014ED8 File Offset: 0x00013ED8
		internal bool x52d5887fb276a6ba
		{
			get
			{
				return this.x6a99e53258ec763c;
			}
			set
			{
				if (value != this.x6a99e53258ec763c)
				{
					this.x6a99e53258ec763c = value;
					base.RedrawNeeded();
				}
			}
		}

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600035A RID: 858 RVA: 0x00014EF0 File Offset: 0x00013EF0
		[Browsable(false)]
		public int DisplayIndex
		{
			get
			{
				return this.xcb8e8afd0ea818cd;
			}
		}

		// Token: 0x0600035B RID: 859 RVA: 0x00014EF8 File Offset: 0x00013EF8
		internal void xae43282491351f1d(int xcb8e8afd0ea818cd)
		{
			this.xcb8e8afd0ea818cd = xcb8e8afd0ea818cd;
		}

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600035C RID: 860 RVA: 0x00014F04 File Offset: 0x00013F04
		// (set) Token: 0x0600035D RID: 861 RVA: 0x00014F0C File Offset: 0x00013F0C
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public ISite Site
		{
			get
			{
				return this.xdea764d9f1dd2bbd;
			}
			set
			{
				this.xdea764d9f1dd2bbd = value;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600035E RID: 862 RVA: 0x00014F18 File Offset: 0x00013F18
		// (set) Token: 0x0600035F RID: 863 RVA: 0x00014F24 File Offset: 0x00013F24
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete("Use the AutoSortType property instead.")]
		public bool AutoSort
		{
			get
			{
				return this.AutoSortType == ColumnAutoSortType.Single;
			}
			set
			{
				if (value)
				{
					this.AutoSortType = ColumnAutoSortType.Single;
					return;
				}
				this.AutoSortType = ColumnAutoSortType.None;
			}
		}

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000360 RID: 864 RVA: 0x00014F38 File Offset: 0x00013F38
		// (set) Token: 0x06000361 RID: 865 RVA: 0x00014F40 File Offset: 0x00013F40
		[DefaultValue(typeof(ColumnAutoSortType), "Single")]
		[Category("Behavior")]
		[Description("Indicates how the column will automatically sort itself when clicked.")]
		public ColumnAutoSortType AutoSortType
		{
			get
			{
				return this.x36aa40fa8c2ea02f;
			}
			set
			{
				this.x36aa40fa8c2ea02f = value;
			}
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000362 RID: 866 RVA: 0x00014F4C File Offset: 0x00013F4C
		// (set) Token: 0x06000363 RID: 867 RVA: 0x00014F54 File Offset: 0x00013F54
		[Description("Indicates whether the user will be able to reorder columns by dragging the header.")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool AllowReorder
		{
			get
			{
				return this.xb7a02ee3677e67b6;
			}
			set
			{
				this.xb7a02ee3677e67b6 = value;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x06000364 RID: 868 RVA: 0x00014F60 File Offset: 0x00013F60
		// (set) Token: 0x06000365 RID: 869 RVA: 0x00014F68 File Offset: 0x00013F68
		[Description("Indicates whether the column header will be clickable.")]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool Clickable
		{
			get
			{
				return this.x609d08185921925b;
			}
			set
			{
				this.x609d08185921925b = value;
			}
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x06000366 RID: 870 RVA: 0x00014F74 File Offset: 0x00013F74
		// (set) Token: 0x06000367 RID: 871 RVA: 0x00014F7C File Offset: 0x00013F7C
		[DefaultValue(true)]
		[Category("Appearance")]
		[Description("Indicates whether to use the row font or the column font when drawing a cell.")]
		public bool UseCellFont
		{
			get
			{
				return this.xa8c3bfb12df49498;
			}
			set
			{
				this.xa8c3bfb12df49498 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000368 RID: 872 RVA: 0x00014F8C File Offset: 0x00013F8C
		// (set) Token: 0x06000369 RID: 873 RVA: 0x00014F98 File Offset: 0x00013F98
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Use the ForeColorSource property instead.")]
		[Browsable(false)]
		public bool UseCellForeColor
		{
			get
			{
				return this.ForeColorSource == CellForeColorSource.RowCell;
			}
			set
			{
				if (value)
				{
					this.ForeColorSource = CellForeColorSource.RowCell;
					return;
				}
				this.ForeColorSource = CellForeColorSource.Column;
			}
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600036A RID: 874 RVA: 0x00014FAC File Offset: 0x00013FAC
		// (set) Token: 0x0600036B RID: 875 RVA: 0x00014FB4 File Offset: 0x00013FB4
		[Description("Indicates how the foreground color of a cell is determined.")]
		[DefaultValue(typeof(CellForeColorSource), "Column")]
		[Category("Appearance")]
		public virtual CellForeColorSource ForeColorSource
		{
			get
			{
				return this.xf8da379cc6c93388;
			}
			set
			{
				this.xf8da379cc6c93388 = value;
				this.RedrawNeeded(true);
			}
		}

		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600036C RID: 876 RVA: 0x00014FC4 File Offset: 0x00013FC4
		// (set) Token: 0x0600036D RID: 877 RVA: 0x00014FCC File Offset: 0x00013FCC
		[Obsolete("Use the CellHorizontalAlignment or HeaderHorizontalAlignment property instead.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public StringAlignment HorizontalAlignment
		{
			get
			{
				return this.CellHorizontalAlignment;
			}
			set
			{
				this.CellHorizontalAlignment = value;
				this.HeaderHorizontalAlignment = value;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x0600036E RID: 878 RVA: 0x00014FDC File Offset: 0x00013FDC
		// (set) Token: 0x0600036F RID: 879 RVA: 0x00014FE4 File Offset: 0x00013FE4
		[Description("Indicates how the contents of cells are laid out.")]
		[Category("Appearance")]
		[DefaultValue(typeof(StringAlignment), "Near")]
		public virtual StringAlignment CellHorizontalAlignment
		{
			get
			{
				return this.xdb4b6e70a3dfb534;
			}
			set
			{
				this.xdb4b6e70a3dfb534 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000370 RID: 880 RVA: 0x00014FF4 File Offset: 0x00013FF4
		// (set) Token: 0x06000371 RID: 881 RVA: 0x00014FFC File Offset: 0x00013FFC
		[DefaultValue(typeof(StringAlignment), "Center")]
		[Description("Indicates how the contents of cells are laid out.")]
		[Category("Appearance")]
		public virtual StringAlignment CellVerticalAlignment
		{
			get
			{
				return this.xdc46a7254c7770ad;
			}
			set
			{
				this.xdc46a7254c7770ad = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000372 RID: 882 RVA: 0x0001500C File Offset: 0x0001400C
		// (set) Token: 0x06000373 RID: 883 RVA: 0x00015014 File Offset: 0x00014014
		[Description("Indicates how the contents of the header are laid out.")]
		[Category("Appearance")]
		[DefaultValue(typeof(StringAlignment), "Near")]
		public StringAlignment HeaderHorizontalAlignment
		{
			get
			{
				return this.x60282922b0fddc80;
			}
			set
			{
				this.x60282922b0fddc80 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000374 RID: 884 RVA: 0x00015024 File Offset: 0x00014024
		[Browsable(false)]
		public GridColumn PreviousColumn
		{
			get
			{
				return this.xf24f9f2ecbfc5620;
			}
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0001502C File Offset: 0x0001402C
		internal void x7f6db6e1f780f13e(GridColumn xf24f9f2ecbfc5620)
		{
			this.xf24f9f2ecbfc5620 = xf24f9f2ecbfc5620;
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000376 RID: 886 RVA: 0x00015038 File Offset: 0x00014038
		[Browsable(false)]
		public GridColumn NextColumn
		{
			get
			{
				return this.x790048e39c67d0fb;
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00015040 File Offset: 0x00014040
		internal void x963a097b6cf9e341(GridColumn x790048e39c67d0fb)
		{
			this.x790048e39c67d0fb = x790048e39c67d0fb;
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0001504C File Offset: 0x0001404C
		// (set) Token: 0x06000379 RID: 889 RVA: 0x00015054 File Offset: 0x00014054
		[Category("Behavior")]
		[DefaultValue(typeof(ElementResizeBehavior), "MoveFollowingElements")]
		[Description("Indicates how the column is resized by the user.")]
		public ElementResizeBehavior ResizeBehavior
		{
			get
			{
				return this.x9c81d8dc5a224cae;
			}
			set
			{
				this.x9c81d8dc5a224cae = value;
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600037A RID: 890 RVA: 0x00015060 File Offset: 0x00014060
		[Browsable(false)]
		public Rectangle ImageBounds
		{
			get
			{
				return this.xfe4205d5dd815113;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600037B RID: 891 RVA: 0x00015068 File Offset: 0x00014068
		[Browsable(false)]
		public Rectangle TextBounds
		{
			get
			{
				return this.x0961517ffd55017f;
			}
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00015070 File Offset: 0x00014070
		internal void x3066fdb6d954beba(Rectangle xda73fcb97c77d998)
		{
			this.x0961517ffd55017f = xda73fcb97c77d998;
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600037D RID: 893 RVA: 0x0001507C File Offset: 0x0001407C
		// (set) Token: 0x0600037E RID: 894 RVA: 0x00015084 File Offset: 0x00014084
		[Description("The tooltip to show for the column header.")]
		[DefaultValue("")]
		[Category("Appearance")]
		[Localizable(true)]
		public string ToolTip
		{
			get
			{
				return this.x00e3ff1770a00e41;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x00e3ff1770a00e41 = value;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600037F RID: 895 RVA: 0x00015098 File Offset: 0x00014098
		// (set) Token: 0x06000380 RID: 896 RVA: 0x000150A0 File Offset: 0x000140A0
		[DefaultValue("")]
		[Description("The text shown in the column heading.")]
		[Category("Appearance")]
		[Localizable(true)]
		public string HeaderText
		{
			get
			{
				return this.xb41faee6912a2313;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				bool flag = (this.xb41faee6912a2313.Length == 0 && value.Length != 0) || (this.xb41faee6912a2313.Length != 0 && value.Length == 0);
				this.xb41faee6912a2313 = value;
				if (flag || (this.AutoSizeIncludeHeader && this.AutoSize == ColumnAutoSizeMode.Contents))
				{
					base.MeasureNeeded();
				}
				else
				{
					base.RedrawNeeded();
				}
				if (base.Grid != null && base.Grid.SandGrid != null && base.Grid.SandGrid.PrimaryGrid.Columns.Contains(this) && base.Grid.SandGrid.x5142973d45b32e92 != null)
				{
					base.Grid.SandGrid.x5142973d45b32e92.xc00d126d33ba98b1();
				}
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000381 RID: 897 RVA: 0x0001516C File Offset: 0x0001416C
		// (set) Token: 0x06000382 RID: 898 RVA: 0x00015174 File Offset: 0x00014174
		[DefaultValue(100)]
		[Description("The width of the column.")]
		[Category("Appearance")]
		public int Width
		{
			get
			{
				return this.x9b0739496f8b5475;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNegative"), "value");
				}
				this.x9b0739496f8b5475 = value;
				this.x2eda0d551eaf3364 = (double)value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x000151A4 File Offset: 0x000141A4
		internal void x339a6432324e0276(double x9b0739496f8b5475, bool x33b86545ac30fb49)
		{
			if (x9b0739496f8b5475 < 0.0)
			{
				throw new ArgumentException("width");
			}
			this.x9b0739496f8b5475 = Convert.ToInt32(x9b0739496f8b5475);
			this.x2eda0d551eaf3364 = x9b0739496f8b5475;
			if (x33b86545ac30fb49)
			{
				base.x07304fb30d6dc43f(true);
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000384 RID: 900 RVA: 0x000151DC File Offset: 0x000141DC
		internal double x47ffa6f239bcee85
		{
			get
			{
				return this.x2eda0d551eaf3364;
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x000151E4 File Offset: 0x000141E4
		public override string ToString()
		{
			return base.ToString() + " \"" + this.HeaderText + "\"";
		}

		// Token: 0x06000386 RID: 902 RVA: 0x00015204 File Offset: 0x00014204
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (base.Grid != null)
				{
					base.Grid.Columns.Remove(this);
				}
				if (this.Site != null && this.Site.Container != null)
				{
					this.Site.Container.Remove(this);
				}
				if (this.x17d67b299ab2c7c9 != null)
				{
					this.x17d67b299ab2c7c9(this, EventArgs.Empty);
				}
			}
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0001526C File Offset: 0x0001426C
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x040000BD RID: 189
		internal const int x69911ce557980446 = 4;

		// Token: 0x040000BE RID: 190
		internal const int x9077f305c3fd8da1 = 2;

		// Token: 0x040000BF RID: 191
		internal const int x60531785cde7be71 = 5;

		// Token: 0x040000C0 RID: 192
		internal const int x32b83fefbb829416 = 100;

		// Token: 0x040000C1 RID: 193
		private string xb41faee6912a2313 = "";

		// Token: 0x040000C2 RID: 194
		private string x00e3ff1770a00e41 = "";

		// Token: 0x040000C3 RID: 195
		private int x9b0739496f8b5475 = 100;

		// Token: 0x040000C4 RID: 196
		private int xcb8e8afd0ea818cd;

		// Token: 0x040000C5 RID: 197
		private int x6a4276d77d423aa0;

		// Token: 0x040000C6 RID: 198
		private double x2eda0d551eaf3364 = 100.0;

		// Token: 0x040000C7 RID: 199
		private ISite xdea764d9f1dd2bbd;

		// Token: 0x040000C8 RID: 200
		private Color x93532ca0ace0c1ae = SystemColors.WindowText;

		// Token: 0x040000C9 RID: 201
		private Image x963101f67c44464e;

		// Token: 0x040000CA RID: 202
		private bool x9b137508136d227b = true;

		// Token: 0x040000CB RID: 203
		private bool x364c1e3b189d47fe = true;

		// Token: 0x040000CC RID: 204
		private bool x769bd68fb8b619a2;

		// Token: 0x040000CD RID: 205
		private bool xa111e162261991b2;

		// Token: 0x040000CE RID: 206
		private bool x8ca4e5394a6baaae;

		// Token: 0x040000CF RID: 207
		private bool xd3052160545d046f;

		// Token: 0x040000D0 RID: 208
		private ColumnAutoSizeMode x6b73ba14fabc6cb0;

		// Token: 0x040000D1 RID: 209
		private Type xbeb1c4d7553f61e7 = typeof(GridTextBoxEditor);

		// Token: 0x040000D2 RID: 210
		private SortOrder x0be0482b5fb3b33d;

		// Token: 0x040000D3 RID: 211
		private ElementResizeBehavior x9c81d8dc5a224cae = ElementResizeBehavior.MoveFollowingElements;

		// Token: 0x040000D4 RID: 212
		private bool x609d08185921925b = true;

		// Token: 0x040000D5 RID: 213
		private bool xb7a02ee3677e67b6 = true;

		// Token: 0x040000D6 RID: 214
		private Point x6afebf16b45c02e0;

		// Token: 0x040000D7 RID: 215
		private ColumnAutoSortType x36aa40fa8c2ea02f = ColumnAutoSortType.Single;

		// Token: 0x040000D8 RID: 216
		private Rectangle x0961517ffd55017f;

		// Token: 0x040000D9 RID: 217
		private Rectangle xfe4205d5dd815113;

		// Token: 0x040000DA RID: 218
		private GridColumn xf24f9f2ecbfc5620;

		// Token: 0x040000DB RID: 219
		private GridColumn x790048e39c67d0fb;

		// Token: 0x040000DC RID: 220
		private StringAlignment xdb4b6e70a3dfb534;

		// Token: 0x040000DD RID: 221
		private StringAlignment x60282922b0fddc80;

		// Token: 0x040000DE RID: 222
		private StringAlignment xdc46a7254c7770ad = StringAlignment.Center;

		// Token: 0x040000DF RID: 223
		private bool x6a99e53258ec763c;

		// Token: 0x040000E0 RID: 224
		private bool xa8c3bfb12df49498 = true;

		// Token: 0x040000E1 RID: 225
		private CellForeColorSource xf8da379cc6c93388 = CellForeColorSource.Column;

		// Token: 0x040000E2 RID: 226
		private bool xde7e53ab273d10d4;

		// Token: 0x040000E3 RID: 227
		private int xb18727061e7ae069;

		// Token: 0x040000E4 RID: 228
		private Type xeface77359be8ccd;

		// Token: 0x040000E5 RID: 229
		private string x47549aefae74027e = "";

		// Token: 0x040000E6 RID: 230
		private EventHandler x98992f4120a73bb9;

		// Token: 0x040000E7 RID: 231
		private EventHandler x17d67b299ab2c7c9;
	}
}

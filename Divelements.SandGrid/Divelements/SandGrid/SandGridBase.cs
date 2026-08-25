using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Divelements.SandGrid.Rendering;
using Divelements.SandGrid.Resources;
using Divelements.Util.Registration;
using TD.Util;

namespace Divelements.SandGrid
{
	// Token: 0x0200000B RID: 11
	[ComplexBindingProperties("DataSource", "DataMember")]
	[DefaultEvent("SelectionChanged")]
	public abstract class SandGridBase : Control
	{
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000149 RID: 329 RVA: 0x0000A838 File Offset: 0x00009838
		// (remove) Token: 0x0600014A RID: 330 RVA: 0x0000A854 File Offset: 0x00009854
		public event SelectionChangedEventHandler SelectionChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x6d6f7a19a6e74243 = (SelectionChangedEventHandler)Delegate.Combine(this.x6d6f7a19a6e74243, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x6d6f7a19a6e74243 = (SelectionChangedEventHandler)Delegate.Remove(this.x6d6f7a19a6e74243, value);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600014B RID: 331 RVA: 0x0000A870 File Offset: 0x00009870
		// (remove) Token: 0x0600014C RID: 332 RVA: 0x0000A88C File Offset: 0x0000988C
		public event GridRowEventHandler RowActivated
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xad878b8fb06f932a = (GridRowEventHandler)Delegate.Combine(this.xad878b8fb06f932a, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xad878b8fb06f932a = (GridRowEventHandler)Delegate.Remove(this.xad878b8fb06f932a, value);
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600014D RID: 333 RVA: 0x0000A8A8 File Offset: 0x000098A8
		// (remove) Token: 0x0600014E RID: 334 RVA: 0x0000A8C4 File Offset: 0x000098C4
		public event GridBeforeEditEventHandler BeforeEdit
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xefbb6cf42d422ea8 = (GridBeforeEditEventHandler)Delegate.Combine(this.xefbb6cf42d422ea8, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xefbb6cf42d422ea8 = (GridBeforeEditEventHandler)Delegate.Remove(this.xefbb6cf42d422ea8, value);
			}
		}

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600014F RID: 335 RVA: 0x0000A8E0 File Offset: 0x000098E0
		// (remove) Token: 0x06000150 RID: 336 RVA: 0x0000A8FC File Offset: 0x000098FC
		public event GridDataErrorEventHandler DataError
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x8243a49d6586c7c2 = (GridDataErrorEventHandler)Delegate.Combine(this.x8243a49d6586c7c2, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x8243a49d6586c7c2 = (GridDataErrorEventHandler)Delegate.Remove(this.x8243a49d6586c7c2, value);
			}
		}

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x06000151 RID: 337 RVA: 0x0000A918 File Offset: 0x00009918
		// (remove) Token: 0x06000152 RID: 338 RVA: 0x0000A934 File Offset: 0x00009934
		public event EventHandler ActiveGridChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xdee092d4d5407b26 = (EventHandler)Delegate.Combine(this.xdee092d4d5407b26, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xdee092d4d5407b26 = (EventHandler)Delegate.Remove(this.xdee092d4d5407b26, value);
			}
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000153 RID: 339 RVA: 0x0000A950 File Offset: 0x00009950
		// (remove) Token: 0x06000154 RID: 340 RVA: 0x0000A96C File Offset: 0x0000996C
		public event GridValueTransformingEventHandler ValueFormatting
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x8288bc0ac4cb9718 = (GridValueTransformingEventHandler)Delegate.Combine(this.x8288bc0ac4cb9718, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x8288bc0ac4cb9718 = (GridValueTransformingEventHandler)Delegate.Remove(this.x8288bc0ac4cb9718, value);
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000155 RID: 341 RVA: 0x0000A988 File Offset: 0x00009988
		// (remove) Token: 0x06000156 RID: 342 RVA: 0x0000A9A4 File Offset: 0x000099A4
		public event ItemDragEventHandler ItemDrag
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xcd7aaf1cbf93da25 = (ItemDragEventHandler)Delegate.Combine(this.xcd7aaf1cbf93da25, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xcd7aaf1cbf93da25 = (ItemDragEventHandler)Delegate.Remove(this.xcd7aaf1cbf93da25, value);
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000157 RID: 343 RVA: 0x0000A9C0 File Offset: 0x000099C0
		// (remove) Token: 0x06000158 RID: 344 RVA: 0x0000A9DC File Offset: 0x000099DC
		public event GridValueTransformingEventHandler ValueParsing
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xe74f7d8e320e196b = (GridValueTransformingEventHandler)Delegate.Combine(this.xe74f7d8e320e196b, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xe74f7d8e320e196b = (GridValueTransformingEventHandler)Delegate.Remove(this.xe74f7d8e320e196b, value);
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000159 RID: 345 RVA: 0x0000A9F8 File Offset: 0x000099F8
		// (remove) Token: 0x0600015A RID: 346 RVA: 0x0000AA14 File Offset: 0x00009A14
		public event GridAfterEditEventHandler AfterEdit
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xfd4ced7eb24170e8 = (GridAfterEditEventHandler)Delegate.Combine(this.xfd4ced7eb24170e8, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xfd4ced7eb24170e8 = (GridAfterEditEventHandler)Delegate.Remove(this.xfd4ced7eb24170e8, value);
			}
		}

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x0600015B RID: 347 RVA: 0x0000AA30 File Offset: 0x00009A30
		// (remove) Token: 0x0600015C RID: 348 RVA: 0x0000AA4C File Offset: 0x00009A4C
		public event DataBindingCompleteEventHandler DataBindingComplete
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x5b2f9bb641183651 = (DataBindingCompleteEventHandler)Delegate.Combine(this.x5b2f9bb641183651, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x5b2f9bb641183651 = (DataBindingCompleteEventHandler)Delegate.Remove(this.x5b2f9bb641183651, value);
			}
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600015D RID: 349 RVA: 0x0000AA68 File Offset: 0x00009A68
		// (remove) Token: 0x0600015E RID: 350 RVA: 0x0000AA84 File Offset: 0x00009A84
		public event GridChooseEditorEventHandler ChooseEditor
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xf2b83307e5709e2b = (GridChooseEditorEventHandler)Delegate.Combine(this.xf2b83307e5709e2b, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xf2b83307e5709e2b = (GridChooseEditorEventHandler)Delegate.Remove(this.xf2b83307e5709e2b, value);
			}
		}

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600015F RID: 351 RVA: 0x0000AAA0 File Offset: 0x00009AA0
		// (remove) Token: 0x06000160 RID: 352 RVA: 0x0000AABC File Offset: 0x00009ABC
		public event GridEventHandler SortChanged
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xb467fb986553e233 = (GridEventHandler)Delegate.Combine(this.xb467fb986553e233, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xb467fb986553e233 = (GridEventHandler)Delegate.Remove(this.xb467fb986553e233, value);
			}
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000AAD8 File Offset: 0x00009AD8
		protected SandGridBase()
		{
			if (!SystemInformation.TerminalServerSession)
			{
				base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			}
			base.SetStyle(ControlStyles.Selectable, true);
			this.x5a0996f223ed617b = new InnerGrid();
			this.x5a0996f223ed617b.x8575a139d5c8689b(this);
			this.x37d060cd2161032a = this.x5a0996f223ed617b;
			this.BackColor = SystemColors.Window;
			this.ForeColor = SystemColors.WindowText;
			if (!false)
			{
				this.Renderer = new WindowsXPRenderer();
				this.x64a0b0f7c755e76d = new Timer();
				if (2 == 0)
				{
					return;
				}
				this.x64a0b0f7c755e76d.Interval = 1000;
				this.x64a0b0f7c755e76d.Tick += this.x8609e20c55624961;
				this.x3ad0a3b3c3aaa928 = new Timer();
				this.x3ad0a3b3c3aaa928.Interval = 500;
				this.x3ad0a3b3c3aaa928.Tick += this.x37b54de9dfabc7b3;
				this.xc833ec9e4d027a80 = new Timer();
				this.xc833ec9e4d027a80.Interval = 20;
				this.xc833ec9e4d027a80.Tick += this.x7def0400f65c1c4f;
				this.x354fffdee23cf7e8 = new BitArray(10);
			}
			this.x05c32e8c9f289bfd = new xc93e236b29b23436();
			this.x05c32e8c9f289bfd.Visible = false;
			base.Controls.Add(this.x05c32e8c9f289bfd);
			this.xac1c850120b1f254 = new xf8f9565783602018(this);
			this.xac1c850120b1f254.x9ab519b46dd91330 = false;
			this.xac1c850120b1f254.x9b21ee8e7ceaada3 += this.xa3a7472ac4e61f76;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000ACA0 File Offset: 0x00009CA0
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.xb41acd866d5cbca8 = true;
				this.x64a0b0f7c755e76d.Tick -= this.x8609e20c55624961;
				this.x64a0b0f7c755e76d.Dispose();
				this.x3ad0a3b3c3aaa928.Tick -= this.x37b54de9dfabc7b3;
				this.x3ad0a3b3c3aaa928.Dispose();
				this.xc833ec9e4d027a80.Tick -= this.x7def0400f65c1c4f;
				this.xc833ec9e4d027a80.Dispose();
				this.x05c32e8c9f289bfd.Dispose();
				this.xac1c850120b1f254.Dispose();
				this.Rows.Clear();
				GridColumn[] array = new GridColumn[this.PrimaryGrid.Columns.Count];
				this.PrimaryGrid.Columns.CopyTo(array, 0);
				this.PrimaryGrid.Columns.Clear();
				foreach (GridColumn gridColumn in array)
				{
					gridColumn.Dispose();
				}
				this.xeda7dac292b0fea5 = false;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000ADA4 File Offset: 0x00009DA4
		protected internal virtual void OnBeforeExpand(GridRowExpandCollapseEventArgs e)
		{
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000ADA8 File Offset: 0x00009DA8
		protected internal virtual void OnBeforeCollapse(GridRowExpandCollapseEventArgs e)
		{
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000ADAC File Offset: 0x00009DAC
		protected internal virtual void OnSortChanged(GridEventArgs e)
		{
			if (!this.xb41acd866d5cbca8 && this.xb467fb986553e233 != null)
			{
				this.xb467fb986553e233(this, e);
			}
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000ADCC File Offset: 0x00009DCC
		protected internal virtual void OnPopulateVirtualRow(GridRowEventArgs e)
		{
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000ADD0 File Offset: 0x00009DD0
		protected internal virtual void OnRowsMoved(ElementsMovedEventArgs e)
		{
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000ADD4 File Offset: 0x00009DD4
		protected internal virtual void OnColumnResized(GridColumnEventArgs e)
		{
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000ADD8 File Offset: 0x00009DD8
		protected internal virtual void OnColumnsReordered(EventArgs e)
		{
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000ADDC File Offset: 0x00009DDC
		protected internal virtual void OnChooseEditor(GridChooseEditorEventArgs e)
		{
			if (this.xf2b83307e5709e2b != null)
			{
				this.xf2b83307e5709e2b(this, e);
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000ADF4 File Offset: 0x00009DF4
		protected internal virtual void OnDataBindingComplete(DataBindingCompleteEventArgs e)
		{
			if (this.x5b2f9bb641183651 != null)
			{
				this.x5b2f9bb641183651(this, e);
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000AE0C File Offset: 0x00009E0C
		protected internal virtual void OnBeforeCheck(GridRowCheckEventArgs e)
		{
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000AE10 File Offset: 0x00009E10
		protected internal virtual void OnAfterCheck(GridRowCheckEventArgs e)
		{
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000AE14 File Offset: 0x00009E14
		protected virtual void OnAfterEdit(GridAfterEditEventArgs e)
		{
			if (this.xfd4ced7eb24170e8 != null)
			{
				this.xfd4ced7eb24170e8(this, e);
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000AE2C File Offset: 0x00009E2C
		protected internal virtual void OnAfterExpand(GridRowExpandCollapseEventArgs e)
		{
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000AE30 File Offset: 0x00009E30
		protected internal virtual void OnAfterCollapse(GridRowExpandCollapseEventArgs e)
		{
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000AE34 File Offset: 0x00009E34
		protected internal virtual void OnItemDrag(ItemDragEventArgs e)
		{
			if (this.xcd7aaf1cbf93da25 != null)
			{
				this.xcd7aaf1cbf93da25(this, e);
			}
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000AE4C File Offset: 0x00009E4C
		protected internal virtual void OnValueParsing(GridValueTransformingEventArgs e)
		{
			if (this.xe74f7d8e320e196b != null)
			{
				this.xe74f7d8e320e196b(this, e);
			}
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000AE64 File Offset: 0x00009E64
		protected internal virtual void OnValueFormatting(GridValueTransformingEventArgs e)
		{
			if (this.x8288bc0ac4cb9718 != null)
			{
				this.x8288bc0ac4cb9718(this, e);
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000AE7C File Offset: 0x00009E7C
		public GridRow NewRow()
		{
			return this.PrimaryGrid.NewRow();
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000AE8C File Offset: 0x00009E8C
		public GridElement GetElementAt(Point position)
		{
			return this.PrimaryGrid.HitTest(position);
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000AE9C File Offset: 0x00009E9C
		private bool x429e83d68c5ae0cb(x681471a7f6916d5c x01b557925841ae51)
		{
			return this.x354fffdee23cf7e8[(int)x01b557925841ae51];
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000AEAC File Offset: 0x00009EAC
		private void x9fa18ed8ade3e644(x681471a7f6916d5c x01b557925841ae51, bool xbcea506a33cf9111)
		{
			this.x354fffdee23cf7e8[(int)x01b557925841ae51] = xbcea506a33cf9111;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000AEBC File Offset: 0x00009EBC
		private void x7def0400f65c1c4f(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			Rectangle scrollableViewportBounds = this.ScrollableViewportBounds;
			Point point = base.PointToClient(Cursor.Position);
			int num;
			int num2;
			if (point.X < scrollableViewportBounds.X)
			{
				num = point.X - scrollableViewportBounds.X;
			}
			else if (point.X > scrollableViewportBounds.Right)
			{
				num = point.X - scrollableViewportBounds.Right;
				if ((uint)num - (uint)num2 < 0U)
				{
					goto IL_93;
				}
			}
			else
			{
				num = 0;
			}
			if (point.Y < scrollableViewportBounds.Y)
			{
				num2 = point.Y - scrollableViewportBounds.Y;
				goto IL_B7;
			}
			IL_93:
			if (point.Y > scrollableViewportBounds.Bottom)
			{
				num2 = point.Y - scrollableViewportBounds.Bottom;
			}
			else
			{
				num2 = 0;
			}
			IL_B7:
			if (num == 0 && num2 == 0)
			{
				this.xc833ec9e4d027a80.Enabled = false;
				return;
			}
			if (num != 0)
			{
				this.HScrollOffset += num;
			}
			if (num2 != 0)
			{
				this.VScrollOffset += num2;
			}
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000AFB8 File Offset: 0x00009FB8
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.PrimaryGrid.Columns.x4cc5a926eb940d8c || this.StretchPrimaryGrid)
			{
				this.x5eb41fb57154353a();
				return;
			}
			this.xd84c468937b92bf1 = new Size(base.ClientRectangle.Width - this.x5a0996f223ed617b.x455ae0624abb5477.Width, base.ClientRectangle.Height - this.x5a0996f223ed617b.x455ae0624abb5477.Height);
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000B03C File Offset: 0x0000A03C
		private void x80011d23d303e32c()
		{
			this.x8c88fe45c4fcd635 = this.x9ebf40bfdd2119aa.Width - this.x5a0996f223ed617b.x455ae0624abb5477.Width;
			if (this.xcca91a4264df67ff == ScrollOverflowBehavior.AlwaysVisible)
			{
				this.x8c88fe45c4fcd635 += this.xd84c468937b92bf1.Width;
			}
			this.x9ceba890ba6c5ad8 = this.x9ebf40bfdd2119aa.Height - this.x5a0996f223ed617b.x455ae0624abb5477.Height;
			if (this.x3961f7a13b8a640b == ScrollOverflowBehavior.AlwaysVisible)
			{
				this.x9ceba890ba6c5ad8 += this.xd84c468937b92bf1.Height;
			}
			bool flag = this.x8c88fe45c4fcd635 > this.xd84c468937b92bf1.Width;
			bool flag2 = this.x9ceba890ba6c5ad8 > this.xd84c468937b92bf1.Height;
			if (flag != this.x8875b8c88ca272fe || flag2 != this.x5d6aaef53fbe3752)
			{
				this.x8875b8c88ca272fe = flag;
				this.x5d6aaef53fbe3752 = flag2;
				base.UpdateStyles();
			}
			this.x758342b5e6c82828();
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000B13C File Offset: 0x0000A13C
		private void x758342b5e6c82828()
		{
			if (this.x8875b8c88ca272fe)
			{
				x443cc432acaadb1d.SCROLLINFO scrollinfo = default(x443cc432acaadb1d.SCROLLINFO);
				scrollinfo.cbSize = Marshal.SizeOf(typeof(x443cc432acaadb1d.SCROLLINFO));
				scrollinfo.fMask = 7;
				scrollinfo.nMin = 0;
				scrollinfo.nMax = this.x8a4894e09db0940c();
				scrollinfo.nPos = this.x0ea770202eaa7707;
				scrollinfo.nPage = this.xd84c468937b92bf1.Width;
				x443cc432acaadb1d.SetScrollInfo(base.Handle, 0, ref scrollinfo, true);
			}
			if (this.x5d6aaef53fbe3752)
			{
				x443cc432acaadb1d.SCROLLINFO scrollinfo2 = default(x443cc432acaadb1d.SCROLLINFO);
				scrollinfo2.cbSize = Marshal.SizeOf(typeof(x443cc432acaadb1d.SCROLLINFO));
				scrollinfo2.fMask = 7;
				scrollinfo2.nMin = 0;
				scrollinfo2.nMax = this.x1e79425de5ba86e5();
				scrollinfo2.nPos = this.x7de459c2ab15ce67;
				scrollinfo2.nPage = this.xd84c468937b92bf1.Height;
				x443cc432acaadb1d.SetScrollInfo(base.Handle, 1, ref scrollinfo2, true);
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000B234 File Offset: 0x0000A234
		private int x1e79425de5ba86e5()
		{
			int num = this.x9ebf40bfdd2119aa.Height - this.x5a0996f223ed617b.x455ae0624abb5477.Height;
			if (this.VerticalScrollOverflow == ScrollOverflowBehavior.AlwaysVisible)
			{
				num += this.xd84c468937b92bf1.Height - GridRow.x993356576cc2bf99;
			}
			return num;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000B284 File Offset: 0x0000A284
		private int x8a4894e09db0940c()
		{
			int num = this.x9ebf40bfdd2119aa.Width - this.x5a0996f223ed617b.x455ae0624abb5477.Width;
			if (this.HorizontalScrollOverflow == ScrollOverflowBehavior.AlwaysVisible)
			{
				num += this.xd84c468937b92bf1.Width - 100;
			}
			return num;
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x0600017E RID: 382 RVA: 0x0000B2D0 File Offset: 0x0000A2D0
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (this.x8875b8c88ca272fe)
				{
					createParams.Style |= 1048576;
				}
				if (this.x5d6aaef53fbe3752)
				{
					createParams.Style |= 2097152;
				}
				if (this.xacfbd7a08ba56c78 == BorderStyle.Fixed3D)
				{
					createParams.ExStyle |= 512;
				}
				if (this.xacfbd7a08ba56c78 == BorderStyle.FixedSingle)
				{
					createParams.Style |= 8388608;
				}
				return createParams;
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000B350 File Offset: 0x0000A350
		protected override void OnMouseWheel(MouseEventArgs e)
		{
			int num = -e.Delta / 120 * SystemInformation.MouseWheelScrollLines;
			Message message = Message.Create(IntPtr.Zero, 0, (num > 0) ? ((IntPtr)1L) : ((IntPtr)0L), IntPtr.Zero);
			for (int i = 1; i <= Math.Abs(num); i++)
			{
				this.x97eadd3a4d7bef06(ref message);
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000B3AC File Offset: 0x0000A3AC
		private int xefed10d31e756169(int x0d5bdc4abab4c781)
		{
			x443cc432acaadb1d.SCROLLINFO scrollinfo = default(x443cc432acaadb1d.SCROLLINFO);
			scrollinfo.cbSize = Marshal.SizeOf(typeof(x443cc432acaadb1d.SCROLLINFO));
			scrollinfo.fMask = 16;
			x443cc432acaadb1d.GetScrollInfo(base.Handle, x0d5bdc4abab4c781, ref scrollinfo);
			return scrollinfo.nTrackPos;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000B3F8 File Offset: 0x0000A3F8
		private void x97eadd3a4d7bef06(ref Message x6088325dec1baa2a)
		{
			int num = this.x1e79425de5ba86e5();
			if (this.VerticalScrollOverflow != ScrollOverflowBehavior.ShyVisible)
			{
				num -= this.xd84c468937b92bf1.Height;
			}
			num = Math.Max(num, 0);
			switch (x443cc432acaadb1d.x0fcc9d0a21bd41f3((int)x6088325dec1baa2a.WParam))
			{
			case 0:
				this.VScrollOffset = Math.Max(this.VScrollOffset - GridRow.x993356576cc2bf99, 0);
				return;
			case 1:
				this.VScrollOffset = Math.Min(this.VScrollOffset + GridRow.x993356576cc2bf99, num);
				return;
			case 2:
				this.VScrollOffset = Math.Max(this.VScrollOffset - this.xd84c468937b92bf1.Height, 0);
				return;
			case 3:
				this.VScrollOffset = Math.Min(this.VScrollOffset + this.xd84c468937b92bf1.Height, num);
				return;
			case 4:
			case 5:
				this.VScrollOffset = this.xefed10d31e756169(1);
				return;
			case 6:
				this.VScrollOffset = 0;
				return;
			case 7:
				this.VScrollOffset = this.x9ebf40bfdd2119aa.Height - base.Height;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000B50C File Offset: 0x0000A50C
		private void x283139014461e7c6(ref Message x6088325dec1baa2a)
		{
			int num = this.x8a4894e09db0940c();
			if (this.HorizontalScrollOverflow != ScrollOverflowBehavior.ShyVisible)
			{
				num -= this.xd84c468937b92bf1.Width;
			}
			switch (x443cc432acaadb1d.x0fcc9d0a21bd41f3((int)x6088325dec1baa2a.WParam))
			{
			case 0:
				this.HScrollOffset = Math.Max(this.HScrollOffset - 5, 0);
				return;
			case 1:
				this.HScrollOffset = Math.Min(this.HScrollOffset + 5, num);
				return;
			case 2:
				this.HScrollOffset = Math.Max(this.HScrollOffset - this.xd84c468937b92bf1.Width, 0);
				return;
			case 3:
				this.HScrollOffset = Math.Min(this.HScrollOffset + this.xd84c468937b92bf1.Width, num);
				return;
			case 4:
			case 5:
				this.HScrollOffset = this.xefed10d31e756169(0);
				return;
			case 6:
				this.HScrollOffset = 0;
				return;
			case 7:
				this.HScrollOffset = this.x9ebf40bfdd2119aa.Height - base.Height;
				return;
			default:
				return;
			}
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000B610 File Offset: 0x0000A610
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 277)
			{
				this.x97eadd3a4d7bef06(ref m);
				return;
			}
			if (m.Msg == 276)
			{
				this.x283139014461e7c6(ref m);
				return;
			}
			if (m.Msg == 533)
			{
				this.x20304545453d4b87();
				return;
			}
			if (m.Msg == 133)
			{
				base.WndProc(ref m);
				IntPtr windowDC = x443cc432acaadb1d.GetWindowDC(base.Handle);
				try
				{
					x443cc432acaadb1d.RECT rect;
					x443cc432acaadb1d.GetWindowRect(base.Handle, out rect);
					using (Graphics graphics = Graphics.FromHdc(windowDC))
					{
						int num = (this.BorderStyle == BorderStyle.Fixed3D) ? 2 : ((this.BorderStyle == BorderStyle.FixedSingle) ? 1 : 0);
						x443cc432acaadb1d.ExcludeClipRect(windowDC, num, num, rect.Width - num, rect.Height - num);
						if (this.Renderer.DrawGridBorder(graphics, new Rectangle(0, 0, rect.Width, rect.Height)))
						{
							m.Result = IntPtr.Zero;
							return;
						}
					}
				}
				finally
				{
					x443cc432acaadb1d.ReleaseDC(base.Handle, windowDC);
				}
			}
			base.WndProc(ref m);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000B750 File Offset: 0x0000A750
		internal void x5d2e802bd1c8f7d5(GridRow xa806b754814b9ae0)
		{
			if (this.x04dffc71a80ab21f == null)
			{
				this.x04dffc71a80ab21f = xa806b754814b9ae0;
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000B764 File Offset: 0x0000A764
		public void ScrollElementIntoView(GridElement element)
		{
			this.x57078f942655a14e(element, (FocusAdvanceDirection)(-1));
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000B770 File Offset: 0x0000A770
		internal void x57078f942655a14e(GridElement x4bbc2c453c470189, FocusAdvanceDirection x23e85093ba3a7d1d)
		{
			if (x4bbc2c453c470189 == null)
			{
				throw new ArgumentNullException("element");
			}
			this.xdca261d82e245c35();
			this.x57078f942655a14e(x4bbc2c453c470189.Bounds, x23e85093ba3a7d1d);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000B794 File Offset: 0x0000A794
		internal void x57078f942655a14e(Rectangle xda73fcb97c77d998, FocusAdvanceDirection x23e85093ba3a7d1d)
		{
			bool flag = x23e85093ba3a7d1d == (FocusAdvanceDirection)(-1);
			if (this.x8875b8c88ca272fe)
			{
				int horizontalScrollBarHeight = SystemInformation.HorizontalScrollBarHeight;
			}
			if (xda73fcb97c77d998.Top < this.VScrollOffset + this.x5a0996f223ed617b.x455ae0624abb5477.Height && (x23e85093ba3a7d1d == FocusAdvanceDirection.Up || flag))
			{
				this.VScrollOffset = xda73fcb97c77d998.Top - this.x5a0996f223ed617b.x455ae0624abb5477.Height;
			}
			else if (xda73fcb97c77d998.Top != this.VScrollOffset + this.x5a0996f223ed617b.x455ae0624abb5477.Height)
			{
				while (xda73fcb97c77d998.Bottom > this.VScrollOffset + base.ClientRectangle.Height)
				{
					int num;
					if (x23e85093ba3a7d1d != FocusAdvanceDirection.Down)
					{
						if ((flag ? 1U : 0U) - (uint)num < 0U)
						{
							continue;
						}
						if (!flag)
						{
							break;
						}
					}
					num = xda73fcb97c77d998.Bottom - base.ClientRectangle.Height;
					num = Math.Min(num, xda73fcb97c77d998.Top - this.x5a0996f223ed617b.x455ae0624abb5477.Height);
					this.VScrollOffset = num;
					break;
				}
			}
			if (this.x5d6aaef53fbe3752)
			{
				int verticalScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
			}
			if (xda73fcb97c77d998.Left < this.HScrollOffset + (this.PrimaryGrid.RightToLeft ? 0 : this.x5a0996f223ed617b.x455ae0624abb5477.Width) && (x23e85093ba3a7d1d == FocusAdvanceDirection.Left || flag))
			{
				this.HScrollOffset = xda73fcb97c77d998.Left - (this.PrimaryGrid.RightToLeft ? 0 : this.x5a0996f223ed617b.x455ae0624abb5477.Width);
				return;
			}
			if (this.HScrollOffset != xda73fcb97c77d998.Left - this.x5a0996f223ed617b.x455ae0624abb5477.Width)
			{
				if (this.HScrollOffset == xda73fcb97c77d998.Right - base.ClientRectangle.Width)
				{
					return;
				}
				if (xda73fcb97c77d998.Right > this.HScrollOffset + base.ClientRectangle.Width - (this.PrimaryGrid.RightToLeft ? this.PrimaryGrid.x455ae0624abb5477.Width : 0) && (x23e85093ba3a7d1d == FocusAdvanceDirection.Right || flag))
				{
					int num2 = xda73fcb97c77d998.Right - base.ClientRectangle.Width + (this.PrimaryGrid.RightToLeft ? this.PrimaryGrid.x455ae0624abb5477.Width : 0);
					num2 = Math.Min(num2, xda73fcb97c77d998.Left - this.x5a0996f223ed617b.x455ae0624abb5477.Width);
					this.HScrollOffset = num2;
				}
			}
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000BA3C File Offset: 0x0000AA3C
		internal void x0a85a0778e92d09a()
		{
			if (this.xeda7dac292b0fea5)
			{
				return;
			}
			this.xeda7dac292b0fea5 = true;
			if (!base.IsHandleCreated)
			{
				return;
			}
			base.BeginInvoke(new SandGridBase.x9e7d723c7953071c(this.x9a889a728e8f4746));
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000BA6C File Offset: 0x0000AA6C
		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			if (!base.RecreatingHandle)
			{
				this.xdca261d82e245c35();
				return;
			}
			if (this.xeda7dac292b0fea5)
			{
				this.xeda7dac292b0fea5 = false;
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000BA94 File Offset: 0x0000AA94
		private void xdca261d82e245c35()
		{
			if (this.xeda7dac292b0fea5)
			{
				this.x9a889a728e8f4746();
			}
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000BAA4 File Offset: 0x0000AAA4
		private void x5eb41fb57154353a()
		{
			this.xeda7dac292b0fea5 = true;
			this.x9a889a728e8f4746();
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000BAB4 File Offset: 0x0000AAB4
		public void PerformElementLayout()
		{
			this.xdca261d82e245c35();
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000BABC File Offset: 0x0000AABC
		private void x9a889a728e8f4746()
		{
			if (!this.xeda7dac292b0fea5)
			{
				return;
			}
			this.xeda7dac292b0fea5 = false;
			bool x1158f70b6f5fc38e = this.RightToLeft == RightToLeft.Yes;
			this.x73eedfda554ed6f1();
			using (Graphics graphics = base.CreateGraphics())
			{
				Size xd84c468937b92bf = new Size(base.ClientRectangle.Width - this.x5a0996f223ed617b.x455ae0624abb5477.Width, base.ClientRectangle.Height - this.x5a0996f223ed617b.x455ae0624abb5477.Height);
				Size size = this.x5a0996f223ed617b.x2f9881556fe66cc1(graphics, x1158f70b6f5fc38e, xd84c468937b92bf);
				if (this.StretchPrimaryGrid)
				{
					size.Width = Math.Max(size.Width, xd84c468937b92bf.Width + this.x5a0996f223ed617b.x455ae0624abb5477.Width);
					size.Height = Math.Max(size.Height, xd84c468937b92bf.Height + this.x5a0996f223ed617b.x455ae0624abb5477.Height);
				}
				this.x9ebf40bfdd2119aa = new Rectangle(new Point(0, 0), size);
				this.xd84c468937b92bf1 = xd84c468937b92bf;
			}
			this.xcf2cd7970d7b16fc();
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000BBFC File Offset: 0x0000ABFC
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			this.x5eb41fb57154353a();
			base.OnRightToLeftChanged(e);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000BC0C File Offset: 0x0000AC0C
		private void xcf2cd7970d7b16fc()
		{
			if (this.xeda7dac292b0fea5)
			{
				return;
			}
			this.x5a0996f223ed617b.xea337a435dab7e27(this.RightToLeft == RightToLeft.Yes);
			this.x5a0996f223ed617b.xb7ae55095fddecd9(this.x9ebf40bfdd2119aa);
			if (this.x04dffc71a80ab21f != null)
			{
				if (this.x04dffc71a80ab21f.Grid != null && this.x04dffc71a80ab21f.Grid.SandGrid == this && this.x04dffc71a80ab21f.IsExpansionVisible())
				{
					int num = this.x04dffc71a80ab21f.x803908b707d2788d();
					if (this.x04dffc71a80ab21f.Bounds.Bottom + num - this.VScrollOffset > base.ClientRectangle.Bottom)
					{
						int num2 = this.x04dffc71a80ab21f.Bounds.Bottom + num - base.ClientRectangle.Bottom;
						num2 = Math.Min(num2, this.x04dffc71a80ab21f.Bounds.Top - this.x5a0996f223ed617b.x455ae0624abb5477.Height);
						this.VScrollOffset = num2;
					}
				}
				this.x04dffc71a80ab21f = null;
			}
			if (this.EditorActive)
			{
				this.x9a764d3e9df67240();
			}
			this.x589c8b1e5b50eeb2();
			this.xd2533ac399c03a13();
			base.Invalidate();
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000BD48 File Offset: 0x0000AD48
		internal int xc5f5e5bf539faab2(int xf79f95b297b243b5)
		{
			int num = Math.Max(this.x5a0996f223ed617b.Columns.Count / 500, 1);
			bool flag = this.RightToLeft == RightToLeft.Yes;
			if (this.x5a0996f223ed617b.Columns.DisplayColumns.Length == 0)
			{
				return 0;
			}
			GridColumn[] displayColumns = this.x5a0996f223ed617b.Columns.DisplayColumns;
			int num2 = 0;
			int i = 0;
			bool flag2 = (uint)i - (uint)xf79f95b297b243b5 < 0U;
			int result;
			if (!flag2)
			{
				while (i < displayColumns.Length)
				{
					int num3 = flag ? (this.PrimaryGrid.Bounds.Right - displayColumns[i].Bounds.Right) : displayColumns[i].Bounds.Left;
					if (num3 >= xf79f95b297b243b5)
					{
						break;
					}
					num2 = i;
					i += num;
				}
				result = num2;
				for (int j = num2; j < num2 + num; j++)
				{
					int num4 = flag ? (this.PrimaryGrid.Bounds.Right - displayColumns[j].Bounds.Right) : displayColumns[j].Bounds.Left;
					if (num4 >= xf79f95b297b243b5)
					{
						break;
					}
					result = j;
				}
			}
			return result;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000BE84 File Offset: 0x0000AE84
		internal GridRow x4a12a72ac9e77a57(int x77628737d203d4ed)
		{
			if (this.PrimaryGrid.VirtualMode)
			{
				if (2 != 0)
				{
					int num = (x77628737d203d4ed - this.PrimaryGrid.x455ae0624abb5477.Height) / this.PrimaryGrid.VirtualRowSize;
					if (num < 0 && this.Rows.Count != 0)
					{
						return this.Rows[0];
					}
					if (num >= 0 && num < this.Rows.Count)
					{
						return this.Rows[num];
					}
				}
				return null;
			}
			int num2 = Math.Max(this.Rows.Count / 500, 1);
			GridRow gridRow = this.x2202aabeb2ae56b3(x77628737d203d4ed, 0, this.Rows.Count, num2);
			if (gridRow == null)
			{
				gridRow = this.x2202aabeb2ae56b3(x77628737d203d4ed, 0, this.Rows.Count, 1);
			}
			else
			{
				gridRow = this.x2202aabeb2ae56b3(x77628737d203d4ed, gridRow.Index, Math.Min(gridRow.Index + num2, this.Rows.Count), 1);
			}
			if (gridRow != null)
			{
				for (GridRow nextVisibleRow = gridRow.NextVisibleRow; nextVisibleRow != null; nextVisibleRow = nextVisibleRow.NextVisibleRow)
				{
					if (!nextVisibleRow.xe0f8497fba2e6972 || (nextVisibleRow.Bounds.Top >= x77628737d203d4ed && (!nextVisibleRow.x149bf25701697822 || nextVisibleRow.Group.Bounds.Top >= x77628737d203d4ed)))
					{
						break;
					}
					gridRow = nextVisibleRow;
				}
			}
			return gridRow;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000BFE0 File Offset: 0x0000AFE0
		private GridRow x2202aabeb2ae56b3(int x77628737d203d4ed, int x10aaa7cdfa38f254, int xa204492da63d478c, int x5a231e160d743567)
		{
			if (this.Rows.Count == 0)
			{
				return null;
			}
			GridRow firstVisibleRow = this.PrimaryGrid.GetFirstVisibleRow();
			int num;
			if (firstVisibleRow != null)
			{
				num = firstVisibleRow.Index;
			}
			else
			{
				num = -1;
			}
			int num2 = x10aaa7cdfa38f254;
			while (num2 < xa204492da63d478c && this.Rows[num2].xe0f8497fba2e6972 && (this.Rows[num2].Bounds.Top < x77628737d203d4ed || (this.Rows[num2].x149bf25701697822 && this.Rows[num2].Group.Bounds.Top < x77628737d203d4ed)))
			{
				num = num2;
				num2 += x5a231e160d743567;
			}
			if (num != -1)
			{
				return this.Rows[num];
			}
			return null;
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000C09C File Offset: 0x0000B09C
		private void x589c8b1e5b50eeb2()
		{
			this.x5a0996f223ed617b.x377b231caa0f3350(this.x4a12a72ac9e77a57(this.VScrollOffset));
			int num = this.x7de459c2ab15ce67 + base.ClientRectangle.Height;
			int num2 = 0;
			if (this.x5a0996f223ed617b.Rows.Count != 0)
			{
				GridRow gridRow = this.x5a0996f223ed617b.x699c923a60e155ff;
				while (gridRow != null && (gridRow.Bounds.Top < num || (gridRow.x149bf25701697822 && gridRow.Group.Bounds.Top < num)))
				{
					gridRow = gridRow.NextVisibleRow;
					num2++;
				}
			}
			this.x5a0996f223ed617b.x12d82f2321e4235a(num2);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000C144 File Offset: 0x0000B144
		private void xd2533ac399c03a13()
		{
			int num;
			if (this.PrimaryGrid.RightToLeft)
			{
				num = this.x9ebf40bfdd2119aa.Width - this.xd84c468937b92bf1.Width - this.x0ea770202eaa7707;
				if (this.PrimaryGrid.ShowRowHeaders)
				{
					num -= this.PrimaryGrid.RowHeaderSize;
				}
			}
			else
			{
				num = this.x0ea770202eaa7707;
			}
			this.x5a0996f223ed617b.x7beb0f9731e751f7(this.xc5f5e5bf539faab2(num));
			GridColumn[] displayColumns;
			int num2;
			int num3;
			int num4;
			if (4 != 0)
			{
				displayColumns = this.x5a0996f223ed617b.Columns.DisplayColumns;
				num2 = 0;
				if (this.x5a0996f223ed617b.FirstVisibleColumn != -1)
				{
					num3 = (this.PrimaryGrid.RightToLeft ? this.HScrollOffset : (this.HScrollOffset + base.ClientRectangle.Width));
					num4 = this.x5a0996f223ed617b.FirstVisibleColumn;
					goto IL_11D;
				}
				goto IL_124;
			}
			IL_F1:
			if (this.PrimaryGrid.RightToLeft || displayColumns[num4].Bounds.Left >= num3)
			{
				goto IL_124;
			}
			IL_113:
			num2++;
			num4++;
			IL_11D:
			if (num4 < displayColumns.Length)
			{
				if (!this.PrimaryGrid.RightToLeft || displayColumns[num4].Bounds.Right <= num3)
				{
					goto IL_F1;
				}
				goto IL_113;
			}
			IL_124:
			this.x5a0996f223ed617b.x3d8b152ea76101f6(num2);
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000C284 File Offset: 0x0000B284
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			base.OnPaintBackground(pevent);
			if (!base.Enabled)
			{
				DrawingMethods.x91433b5e99eb7cac(pevent.Graphics, SystemColors.Control);
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000C2A8 File Offset: 0x0000B2A8
		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.xeda7dac292b0fea5)
			{
				this.xdca261d82e245c35();
			}
			IndependentText.xc50a22da327d908e = this.UseCompatibleTextRendering;
			RenderingContext x0f7b23d1c393aed = this.x5a0996f223ed617b.xd916e3d12d2ec8e1(e.Graphics, false, this.x7de459c2ab15ce67 + this.PrimaryGrid.x455ae0624abb5477.Height, this.x7de459c2ab15ce67 + this.PrimaryGrid.x455ae0624abb5477.Height + this.xd84c468937b92bf1.Height);
			try
			{
				xf4604fd5d5aa5ebd.x2d90aa1d9008ac09(e.Graphics, this.x0ea770202eaa7707, this.x7de459c2ab15ce67);
				e.Graphics.SetClip(this.ScrollableViewportBounds);
				e.Graphics.TranslateTransform((float)(-(float)this.x0ea770202eaa7707), (float)(-(float)this.x7de459c2ab15ce67));
				this.x5a0996f223ed617b.x7f63857195e5d213(x0f7b23d1c393aed);
				e.Graphics.ResetTransform();
				e.Graphics.ResetClip();
				int num = 0;
				if (this.PrimaryGrid.RightToLeft)
				{
					num = Math.Max(this.x9ebf40bfdd2119aa.Width - this.xd84c468937b92bf1.Width - (this.PrimaryGrid.ShowRowHeaders ? this.PrimaryGrid.RowHeaderSize : 0), 0);
				}
				xf4604fd5d5aa5ebd.x2d90aa1d9008ac09(e.Graphics, num, this.x7de459c2ab15ce67);
				e.Graphics.TranslateTransform((float)(-(float)num), (float)(-(float)this.x7de459c2ab15ce67));
				this.x5a0996f223ed617b.xa773e3fe39c24b95(x0f7b23d1c393aed);
				e.Graphics.ResetTransform();
				xf4604fd5d5aa5ebd.x2d90aa1d9008ac09(e.Graphics, this.x0ea770202eaa7707, 0);
				e.Graphics.TranslateTransform((float)(-(float)this.x0ea770202eaa7707), 0f);
				this.x5a0996f223ed617b.xe38b34b4ef5b24ed(x0f7b23d1c393aed);
				e.Graphics.ResetTransform();
			}
			finally
			{
				this.x5a0996f223ed617b.xa1c45a8b0a8e79d9(x0f7b23d1c393aed);
				xf4604fd5d5aa5ebd.xe1f5bc71fd8a1afa();
			}
			if (this.Rows.Count == 0 && this.EmptyText.Length != 0)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.Offset(this.PrimaryGrid.x455ae0624abb5477.Width, this.PrimaryGrid.x455ae0624abb5477.Height);
				clientRectangle.Width -= this.PrimaryGrid.x455ae0624abb5477.Width;
				clientRectangle.Height -= this.PrimaryGrid.x455ae0624abb5477.Height;
				clientRectangle.Inflate(-5, -5);
				if (clientRectangle.Width > 0 && clientRectangle.Height > 0)
				{
					using (TextFormattingInformation textFormat = TextFormattingInformation.CreateFormattingInformation(this.RightToLeft == RightToLeft.Yes, true, this.EmptyTextHorizontalAlignment, StringAlignment.Near, false))
					{
						IndependentText.DrawText(e.Graphics, this.EmptyText, this.Font, clientRectangle, textFormat, this.EmptyTextForeColor);
					}
				}
			}
			base.OnPaint(e);
			if (this.x266365ea27fa7af8.Evaluation)
			{
				using (StringFormat stringFormat = new StringFormat(StringFormat.GenericTypographic))
				{
					stringFormat.Alignment = StringAlignment.Far;
					stringFormat.LineAlignment = StringAlignment.Far;
					using (Font font = new Font(this.Font.FontFamily, 24f))
					{
						using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(15, SystemColors.WindowText)))
						{
							e.Graphics.DrawString("evaluation", font, solidBrush, base.ClientRectangle, stringFormat);
						}
					}
				}
			}
		}

		// Token: 0x06000197 RID: 407 RVA: 0x0000C694 File Offset: 0x0000B694
		protected override void OnChangeUICues(UICuesEventArgs e)
		{
			base.OnChangeUICues(e);
			if (e.ChangeFocus && this.FocusedElement != null)
			{
				this.FocusedElement.RedrawNeeded();
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000198 RID: 408 RVA: 0x0000C6B8 File Offset: 0x0000B6B8
		// (set) Token: 0x06000199 RID: 409 RVA: 0x0000C6C0 File Offset: 0x0000B6C0
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600019A RID: 410 RVA: 0x0000C6CC File Offset: 0x0000B6CC
		protected override Size DefaultSize
		{
			get
			{
				return new Size(300, 200);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600019B RID: 411 RVA: 0x0000C6E0 File Offset: 0x0000B6E0
		// (set) Token: 0x0600019C RID: 412 RVA: 0x0000C6E8 File Offset: 0x0000B6E8
		[DefaultValue(typeof(Color), "Window")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600019D RID: 413 RVA: 0x0000C6F4 File Offset: 0x0000B6F4
		// (set) Token: 0x0600019E RID: 414 RVA: 0x0000C6FC File Offset: 0x0000B6FC
		[DefaultValue(typeof(Color), "WindowText")]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000C708 File Offset: 0x0000B708
		protected virtual void OnDataError(bool showDialog, GridDataErrorEventArgs e)
		{
			if (this.x8243a49d6586c7c2 == null)
			{
				if (showDialog)
				{
					string text = xf1a67b6a145d2603.x538d63a1354c16f2("MessageUnhandledDataException") + Environment.NewLine + Environment.NewLine + e.Exception.ToString();
					string caption = xf1a67b6a145d2603.x538d63a1354c16f2("MessageUnhandledDataExceptionCaption");
					if (this.RightToLeft == RightToLeft.Yes)
					{
						MessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
						return;
					}
					MessageBox.Show(this, text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			else
			{
				this.x8243a49d6586c7c2(this, e);
			}
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000C788 File Offset: 0x0000B788
		internal void xb550175c839c05f5(GridDataErrorEventArgs xfbf34718e704c6bc)
		{
			this.OnDataError(!base.DesignMode && !this.x429e83d68c5ae0cb(x681471a7f6916d5c.xe044102d7854e9de), xfbf34718e704c6bc);
			if (this.x429e83d68c5ae0cb(x681471a7f6916d5c.x1c8c6a38ce8f20dd))
			{
				xfbf34718e704c6bc.ThrowException = true;
			}
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000C7B8 File Offset: 0x0000B7B8
		protected virtual void OnBeforeEdit(GridBeforeEditEventArgs e)
		{
			if (this.xefbb6cf42d422ea8 != null)
			{
				this.xefbb6cf42d422ea8(this, e);
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000C7D0 File Offset: 0x0000B7D0
		private bool x1cf00982db7e855a(bool xd215838c4358d621)
		{
			if (xd215838c4358d621)
			{
				this.x9fa18ed8ade3e644(x681471a7f6916d5c.xe044102d7854e9de, true);
			}
			this.x9fa18ed8ade3e644(x681471a7f6916d5c.x1c8c6a38ce8f20dd, true);
			try
			{
				object obj = (this.xcc17d608c5279127 as IGridCellEditor).EditorValue;
				GridColumn gridColumn = this.x623b7ba6ec850ac3;
				GridRow gridRow = this.x67740018b77b66d4;
				GridAfterEditEventArgs gridAfterEditEventArgs = new GridAfterEditEventArgs(this.EditingRow, this.EditingColumn, (IGridCellEditor)this.xcc17d608c5279127, obj);
				this.OnAfterEdit(gridAfterEditEventArgs);
				if (gridAfterEditEventArgs.Cancel)
				{
					return true;
				}
				obj = gridAfterEditEventArgs.Value;
				object value;
				try
				{
					value = gridColumn.x9efd48e8072f42ef(gridRow, obj);
				}
				catch
				{
					return xd215838c4358d621;
				}
				try
				{
					gridRow.SetCellValue(gridColumn, value);
				}
				catch
				{
					return xd215838c4358d621;
				}
			}
			finally
			{
				this.x9fa18ed8ade3e644(x681471a7f6916d5c.xe044102d7854e9de, false);
				this.x9fa18ed8ade3e644(x681471a7f6916d5c.x1c8c6a38ce8f20dd, false);
			}
			return true;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000C8D0 File Offset: 0x0000B8D0
		public bool EndEdit(bool commit, bool resetFocus)
		{
			return this.x48546f274ac60a66(commit, false, resetFocus);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000C8DC File Offset: 0x0000B8DC
		internal bool x48546f274ac60a66(bool xe383ba03d1c1a83b, bool xd215838c4358d621, bool xb60ba5e28fcee793)
		{
			if (this.xcc17d608c5279127 == null)
			{
				return true;
			}
			if (this.x429e83d68c5ae0cb(x681471a7f6916d5c.x01a0978cfbd0bcd8) && xe383ba03d1c1a83b)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionReentrancy"));
			}
			this.x9fa18ed8ade3e644(x681471a7f6916d5c.x01a0978cfbd0bcd8, true);
			bool result;
			try
			{
				if (xe383ba03d1c1a83b && this.x7e2e7dab74ab56c8)
				{
					if (!this.x1cf00982db7e855a(xd215838c4358d621))
					{
						return false;
					}
					if (this.xcc17d608c5279127 == null)
					{
						return true;
					}
				}
				xb60ba5e28fcee793 = (xb60ba5e28fcee793 && this.xcc17d608c5279127.Focused);
				base.SetStyle(ControlStyles.Selectable, true);
				this.x883dbe036f218502 = null;
				if (xb60ba5e28fcee793)
				{
					base.Focus();
				}
				this.x05c32e8c9f289bfd.Visible = false;
				this.x8c7b6df56a45ae90 = false;
				this.xcc17d608c5279127.Dispose();
				this.xcc17d608c5279127 = null;
				this.x67740018b77b66d4.xa1234ce25f6ce296(false);
				this.x67740018b77b66d4 = null;
				this.x623b7ba6ec850ac3 = null;
				result = true;
			}
			finally
			{
				this.x9fa18ed8ade3e644(x681471a7f6916d5c.x01a0978cfbd0bcd8, false);
			}
			return result;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000C9DC File Offset: 0x0000B9DC
		public bool BeginEdit(GridRow row, GridColumn column, bool selectAll)
		{
			if (row == null)
			{
				throw new ArgumentNullException("row");
			}
			if (column == null)
			{
				throw new ArgumentNullException("column");
			}
			if (row.Grid != column.Grid)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			if (row.Grid.SandGrid != this)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"));
			}
			if (this.EditorActive)
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionEditorAlreadyActive"));
			}
			GridChooseEditorEventArgs gridChooseEditorEventArgs = new GridChooseEditorEventArgs(row, column);
			this.OnChooseEditor(gridChooseEditorEventArgs);
			Type editorType = gridChooseEditorEventArgs.EditorType;
			if (editorType == null)
			{
				return false;
			}
			if (!row.AllowEditing || !column.AllowEditing || !row.IsExpansionVisible())
			{
				return false;
			}
			if (this.x429e83d68c5ae0cb(x681471a7f6916d5c.xdad91f4ac91bbfc9))
			{
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionReentrancy"));
			}
			this.x9fa18ed8ade3e644(x681471a7f6916d5c.xdad91f4ac91bbfc9, true);
			bool result;
			try
			{
				this.xcc17d608c5279127 = (Control)Activator.CreateInstance(editorType);
				IGridCellEditor gridCellEditor = this.xcc17d608c5279127 as IGridCellEditor;
				GridBeforeEditEventArgs gridBeforeEditEventArgs = new GridBeforeEditEventArgs(row, column, (IGridCellEditor)this.xcc17d608c5279127);
				try
				{
					gridCellEditor.InitializeContext(row.Grid.SandGrid, row, column);
					this.OnBeforeEdit(gridBeforeEditEventArgs);
				}
				catch
				{
					this.xcc17d608c5279127.Dispose();
					this.xcc17d608c5279127 = null;
					throw;
				}
				if (gridBeforeEditEventArgs.Cancel)
				{
					this.xcc17d608c5279127.Dispose();
					if (!false)
					{
						this.xcc17d608c5279127 = null;
						result = false;
					}
				}
				else
				{
					Rectangle xda73fcb97c77d = new Rectangle(column.Bounds.Left, row.Bounds.Top, column.Bounds.Width, row.Bounds.Height);
					this.x57078f942655a14e(xda73fcb97c77d, (FocusAdvanceDirection)(-1));
					this.x9fa18ed8ade3e644(x681471a7f6916d5c.x1c8c6a38ce8f20dd, true);
					object editorValue;
					try
					{
						editorValue = column.xf69eb59aa621a379(row, row.GetCellValue(column), gridCellEditor.DesiredType);
					}
					catch
					{
						return false;
					}
					finally
					{
						this.x9fa18ed8ade3e644(x681471a7f6916d5c.x1c8c6a38ce8f20dd, false);
					}
					do
					{
						gridCellEditor.EditorValue = editorValue;
						this.x67740018b77b66d4 = row;
						this.x623b7ba6ec850ac3 = column;
						this.x67740018b77b66d4.xa1234ce25f6ce296(true);
						this.x8c7b6df56a45ae90 = true;
						this.x7e2e7dab74ab56c8 = false;
						this.x05c32e8c9f289bfd.BorderStyle = gridCellEditor.HostBorderStyle;
						this.x05c32e8c9f289bfd.Controls.Add(this.xcc17d608c5279127);
						this.x9a764d3e9df67240();
						this.x05c32e8c9f289bfd.Visible = true;
						this.xcc17d608c5279127.Focus();
						this.x883dbe036f218502 = this.xcc17d608c5279127;
					}
					while (((selectAll ? 1U : 0U) | 2147483647U) == 0U);
					gridCellEditor.StartEdit(selectAll);
					base.SetStyle(ControlStyles.Selectable, false);
					result = true;
				}
			}
			finally
			{
				this.x9fa18ed8ade3e644(x681471a7f6916d5c.xdad91f4ac91bbfc9, false);
			}
			return result;
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x0000CCE8 File Offset: 0x0000BCE8
		// (set) Token: 0x060001A7 RID: 423 RVA: 0x0000CCF0 File Offset: 0x0000BCF0
		private Control x883dbe036f218502
		{
			get
			{
				return this.xe11e365d7040675d;
			}
			set
			{
				if (value != this.xe11e365d7040675d)
				{
					if (this.xe11e365d7040675d != null)
					{
						this.xe11e365d7040675d.LostFocus -= this.xa9b1a062dfeaab15;
					}
					this.xe11e365d7040675d = value;
					if (this.xe11e365d7040675d != null)
					{
						this.xe11e365d7040675d.LostFocus += this.xa9b1a062dfeaab15;
					}
				}
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000CD4C File Offset: 0x0000BD4C
		private void xa9b1a062dfeaab15(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.CommitOnLoseFocus)
			{
				Control control = Control.FromChildHandle(x443cc432acaadb1d.GetFocus());
				if (SandGridBase.x94d637aaa44dd3ce(this.xcc17d608c5279127, control))
				{
					this.x883dbe036f218502 = control;
					return;
				}
				this.EndEdit(true, false);
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x0000CD8C File Offset: 0x0000BD8C
		private static bool x94d637aaa44dd3ce(Control xb6a159a84cb992d6, Control xde860fba55c41d76)
		{
			for (Control control = xde860fba55c41d76; control != null; control = control.Parent)
			{
				if (control == xb6a159a84cb992d6)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000CDB0 File Offset: 0x0000BDB0
		private void x9a764d3e9df67240()
		{
			Rectangle bounds = this.x67740018b77b66d4.xce9e1c7589503f48(this.x623b7ba6ec850ac3);
			int num;
			int num2;
			if ((uint)num - (uint)num >= 0U)
			{
				Image cellImage = this.x67740018b77b66d4.GetCellImage(this.x623b7ba6ec850ac3);
				if (cellImage != null)
				{
					num = cellImage.Width + this.x67740018b77b66d4.Grid.ImageTextSeparation;
					if (!this.PrimaryGrid.RightToLeft)
					{
						bounds.X += num;
					}
					bounds.Width -= num;
				}
				num2 = (this.xcc17d608c5279127 as IGridCellEditor).FixedHeight;
				if (num2 == 0)
				{
					goto IL_A5;
				}
				switch ((this.xcc17d608c5279127 as IGridCellEditor).HostBorderStyle)
				{
				case BorderStyle.FixedSingle:
					num2++;
					goto IL_9D;
				case BorderStyle.Fixed3D:
					break;
				default:
					goto IL_9D;
				}
			}
			num2 += 2;
			IL_9D:
			bounds.Height = num2;
			IL_A5:
			bounds.Offset(-this.HScrollOffset, -this.VScrollOffset);
			if (this.PrimaryGrid.FixColumnHeaders && this.PrimaryGrid.ShowColumnHeaders && bounds.Y < this.PrimaryGrid.x5d332e6bd470be29)
			{
				bounds.Y = -bounds.Height;
			}
			if (this.PrimaryGrid.FixRowHeaders && this.PrimaryGrid.ShowRowHeaders && bounds.X < this.PrimaryGrid.RowHeaderSize)
			{
				bounds.X = -bounds.Width;
			}
			this.x05c32e8c9f289bfd.Bounds = bounds;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x0000CF38 File Offset: 0x0000BF38
		internal void x4ed3c8af084555d7(GridRow x978c6b33cd28725b, GridColumn xb3bc11429dd30e9f)
		{
			this.x978c6b33cd28725b = x978c6b33cd28725b;
			this.xb3bc11429dd30e9f = xb3bc11429dd30e9f;
			this.x3ad0a3b3c3aaa928.Enabled = false;
			this.x3ad0a3b3c3aaa928.Enabled = true;
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000CF60 File Offset: 0x0000BF60
		internal void x73eedfda554ed6f1()
		{
			this.x3ad0a3b3c3aaa928.Enabled = false;
			this.x978c6b33cd28725b = null;
			this.xb3bc11429dd30e9f = null;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000CF7C File Offset: 0x0000BF7C
		private void x37b54de9dfabc7b3(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			GridRow gridRow = this.x978c6b33cd28725b;
			GridColumn gridColumn = this.xb3bc11429dd30e9f;
			this.x73eedfda554ed6f1();
			if (this.xeda7dac292b0fea5 || !this.Focused)
			{
				return;
			}
			if (this.EditorActive)
			{
				return;
			}
			if (gridRow.Grid == null || gridRow.Grid.SandGrid == null || gridRow.Grid.SandGrid != this)
			{
				return;
			}
			if (gridColumn.Grid == null || gridColumn.Grid.SandGrid == null || gridColumn.Grid.SandGrid != this)
			{
				return;
			}
			this.BeginEdit(gridRow, gridColumn, true);
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000D00C File Offset: 0x0000C00C
		// (set) Token: 0x060001AF RID: 431 RVA: 0x0000D014 File Offset: 0x0000C014
		protected internal KeyboardEditMode KeyboardEditing
		{
			get
			{
				return this.x6cb7f04b203e256c;
			}
			set
			{
				this.x6cb7f04b203e256c = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x0000D020 File Offset: 0x0000C020
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x0000D028 File Offset: 0x0000C028
		protected internal MouseEditMode MouseEditing
		{
			get
			{
				return this.x51dac887be599934;
			}
			set
			{
				this.x51dac887be599934 = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x0000D034 File Offset: 0x0000C034
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x0000D03C File Offset: 0x0000C03C
		[Category("Behavior")]
		[Description("If true, causes the Tab key to have the standard Win32 behavior of moving between controls.")]
		[DefaultValue(false)]
		public bool StandardTab
		{
			get
			{
				return this.x45f8c9cde7f3dad0;
			}
			set
			{
				this.x45f8c9cde7f3dad0 = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000D048 File Offset: 0x0000C048
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x0000D058 File Offset: 0x0000C058
		[Category("Behavior")]
		[Description("Indicates whether checkboxes are present on rows.")]
		[DefaultValue(false)]
		public bool CheckBoxes
		{
			get
			{
				return this.x5a0996f223ed617b.CheckBoxes;
			}
			set
			{
				this.x5a0996f223ed617b.CheckBoxes = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000D068 File Offset: 0x0000C068
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x0000D070 File Offset: 0x0000C070
		[Category("Appearance")]
		[DefaultValue("")]
		[Description("The text to show when there are no items in the grid.")]
		public string EmptyText
		{
			get
			{
				return this.x203ce404ab69af8d;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x203ce404ab69af8d = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000D08C File Offset: 0x0000C08C
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x0000D094 File Offset: 0x0000C094
		[Category("Appearance")]
		[DefaultValue(typeof(Color), "WindowText")]
		[Description("The color of text to show when there are no items in the grid.")]
		public Color EmptyTextForeColor
		{
			get
			{
				return this.xdee25fc69e436817;
			}
			set
			{
				this.xdee25fc69e436817 = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000D0A4 File Offset: 0x0000C0A4
		// (set) Token: 0x060001BB RID: 443 RVA: 0x0000D0AC File Offset: 0x0000C0AC
		[Category("Appearance")]
		[DefaultValue(typeof(StringAlignment), "Near")]
		[Description("The alignment of the text shown when there are no items in the grid.")]
		public StringAlignment EmptyTextHorizontalAlignment
		{
			get
			{
				return this.x66aa295ccf582978;
			}
			set
			{
				this.x66aa295ccf582978 = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0000D0BC File Offset: 0x0000C0BC
		// (set) Token: 0x060001BD RID: 445 RVA: 0x0000D0C4 File Offset: 0x0000C0C4
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool UseCompatibleTextRendering
		{
			get
			{
				return this.xa6d820670c5b3126;
			}
			set
			{
				this.xa6d820670c5b3126 = value;
				this.x5eb41fb57154353a();
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0000D0D4 File Offset: 0x0000C0D4
		// (set) Token: 0x060001BF RID: 447 RVA: 0x0000D0DC File Offset: 0x0000C0DC
		internal Size xd84c468937b92bf1
		{
			get
			{
				return this.x259e6cf08f9b90c9;
			}
			set
			{
				this.x259e6cf08f9b90c9 = value;
				this.x80011d23d303e32c();
				this.VScrollOffset = this.VScrollOffset;
				this.HScrollOffset = this.HScrollOffset;
				this.x589c8b1e5b50eeb2();
				this.xd2533ac399c03a13();
				base.Invalidate();
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000D118 File Offset: 0x0000C118
		[Browsable(false)]
		public InnerGrid ActiveGrid
		{
			get
			{
				return this.x37d060cd2161032a;
			}
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x0000D120 File Offset: 0x0000C120
		internal void x0adf5235abca736b(InnerGrid x37d060cd2161032a)
		{
			if (x37d060cd2161032a == null)
			{
				throw new ArgumentNullException("activeGrid");
			}
			if (x37d060cd2161032a.SandGrid != this)
			{
				throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionObjectNotInGrid"), "activeGrid");
			}
			if (x37d060cd2161032a != this.x37d060cd2161032a)
			{
				this.x37d060cd2161032a = x37d060cd2161032a;
				this.OnActiveGridChanged(EventArgs.Empty);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000D174 File Offset: 0x0000C174
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x0000D17C File Offset: 0x0000C17C
		[Description("Indicates whether the user can start typing to search through rows in the grid.")]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool EnableSearching
		{
			get
			{
				return this.xdf12e581864b002b;
			}
			set
			{
				this.xdf12e581864b002b = value;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000D188 File Offset: 0x0000C188
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000D198 File Offset: 0x0000C198
		[Description("Indicates whether columns corresponding to properties on bound objects will be automatically generated if they do not already exist.")]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool AutoGenerateBoundColumns
		{
			get
			{
				return this.x5a0996f223ed617b.AutoGenerateBoundColumns;
			}
			set
			{
				this.x5a0996f223ed617b.AutoGenerateBoundColumns = value;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x0000D1A8 File Offset: 0x0000C1A8
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x0000D1B8 File Offset: 0x0000C1B8
		[Category("Data")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Description("Gets or sets the data source that the grid is bound to.")]
		[AttributeProvider(typeof(IListSource))]
		[DefaultValue(null)]
		public object DataSource
		{
			get
			{
				return this.x5a0996f223ed617b.DataSource;
			}
			set
			{
				this.x5a0996f223ed617b.DataSource = value;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x0000D1C8 File Offset: 0x0000C1C8
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x0000D1D8 File Offset: 0x0000C1D8
		[Category("Data")]
		[Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[Description("Gets or sets the name of the list or table in the data source that the grid is bound to.")]
		[DefaultValue("")]
		public string DataMember
		{
			get
			{
				return this.x5a0996f223ed617b.DataMember;
			}
			set
			{
				this.x5a0996f223ed617b.DataMember = value;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060001CA RID: 458 RVA: 0x0000D1E8 File Offset: 0x0000C1E8
		[Browsable(false)]
		public GridRow EditingRow
		{
			get
			{
				return this.x67740018b77b66d4;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001CB RID: 459 RVA: 0x0000D1F0 File Offset: 0x0000C1F0
		[Browsable(false)]
		public GridColumn EditingColumn
		{
			get
			{
				return this.x623b7ba6ec850ac3;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001CC RID: 460 RVA: 0x0000D1F8 File Offset: 0x0000C1F8
		// (set) Token: 0x060001CD RID: 461 RVA: 0x0000D200 File Offset: 0x0000C200
		[Category("Appearance")]
		[Description("The renderer in use by the grid.")]
		public ISandGridRenderer Renderer
		{
			get
			{
				return this.x38870620fd380a6b;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (this.x38870620fd380a6b != null)
				{
					this.x38870620fd380a6b.RedrawNeeded -= this.x266134e26f4bcc76;
				}
				this.x38870620fd380a6b = value;
				if (this.x38870620fd380a6b != null)
				{
					this.x38870620fd380a6b.RedrawNeeded += this.x266134e26f4bcc76;
				}
				base.Invalidate();
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000D268 File Offset: 0x0000C268
		private void x266134e26f4bcc76(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			base.Invalidate();
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001CF RID: 463 RVA: 0x0000D270 File Offset: 0x0000C270
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x0000D278 File Offset: 0x0000C278
		[Description("Indicates whether an edit operation should be committed when focus leaves the control.")]
		[Category("Editing")]
		[DefaultValue(false)]
		public bool CommitOnLoseFocus
		{
			get
			{
				return this.x1c4e749f6facc191;
			}
			set
			{
				this.x1c4e749f6facc191 = value;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001D1 RID: 465 RVA: 0x0000D284 File Offset: 0x0000C284
		// (set) Token: 0x060001D2 RID: 466 RVA: 0x0000D28C File Offset: 0x0000C28C
		[DefaultValue(false)]
		[Description("Indicates whether the user can paste data from the clipboard into the grid.")]
		[Category("Editing")]
		public bool AllowPaste
		{
			get
			{
				return this.xc80b7dfbe7643b3a;
			}
			set
			{
				this.xc80b7dfbe7643b3a = value;
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x0000D298 File Offset: 0x0000C298
		[Browsable(false)]
		public bool EditorActive
		{
			get
			{
				return this.x8c7b6df56a45ae90;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x0000D2A0 File Offset: 0x0000C2A0
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x0000D2A8 File Offset: 0x0000C2A8
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool EditorDirty
		{
			get
			{
				return this.x7e2e7dab74ab56c8;
			}
			set
			{
				if (!this.EditorActive)
				{
					throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoEditorActive"));
				}
				this.x7e2e7dab74ab56c8 = value;
				this.x67740018b77b66d4.x9829fd753544f98c(this.EditorDirty);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x0000D2DC File Offset: 0x0000C2DC
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x0000D2EC File Offset: 0x0000C2EC
		[Category("Selection")]
		[DefaultValue(false)]
		[Description("Indicates whether the selection is hidden when the grid does not have focus.")]
		public bool HideSelection
		{
			get
			{
				return this.PrimaryGrid.HideSelection;
			}
			set
			{
				this.PrimaryGrid.HideSelection = value;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x0000D2FC File Offset: 0x0000C2FC
		[Browsable(false)]
		public InnerGrid PrimaryGrid
		{
			get
			{
				return this.x5a0996f223ed617b;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x0000D304 File Offset: 0x0000C304
		// (set) Token: 0x060001DA RID: 474 RVA: 0x0000D30C File Offset: 0x0000C30C
		[DefaultValue(true)]
		[Description("Indicates whether the primary grid is stretched horizontally if needed.")]
		[Category("Layout")]
		public bool StretchPrimaryGrid
		{
			get
			{
				return this.x4146cbcac48d3bf9;
			}
			set
			{
				if (value != this.x4146cbcac48d3bf9)
				{
					this.x4146cbcac48d3bf9 = value;
					this.x0a85a0778e92d09a();
				}
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001DB RID: 475 RVA: 0x0000D324 File Offset: 0x0000C324
		// (set) Token: 0x060001DC RID: 476 RVA: 0x0000D32C File Offset: 0x0000C32C
		[DefaultValue(typeof(BorderStyle), "Fixed3D")]
		[Category("Appearance")]
		[Description("The type of border that is drawn around the control.")]
		public BorderStyle BorderStyle
		{
			get
			{
				return this.xacfbd7a08ba56c78;
			}
			set
			{
				if (value != this.xacfbd7a08ba56c78)
				{
					this.xacfbd7a08ba56c78 = value;
					base.UpdateStyles();
				}
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000D344 File Offset: 0x0000C344
		// (set) Token: 0x060001DE RID: 478 RVA: 0x0000D34C File Offset: 0x0000C34C
		[DefaultValue(typeof(ScrollOverflowBehavior), "NeverVisible")]
		[Browsable(false)]
		public ScrollOverflowBehavior VerticalScrollOverflow
		{
			get
			{
				return this.x3961f7a13b8a640b;
			}
			set
			{
				this.x3961f7a13b8a640b = value;
				this.x80011d23d303e32c();
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001DF RID: 479 RVA: 0x0000D35C File Offset: 0x0000C35C
		// (set) Token: 0x060001E0 RID: 480 RVA: 0x0000D364 File Offset: 0x0000C364
		[Browsable(false)]
		[DefaultValue(typeof(ScrollOverflowBehavior), "NeverVisible")]
		public ScrollOverflowBehavior HorizontalScrollOverflow
		{
			get
			{
				return this.xcca91a4264df67ff;
			}
			set
			{
				this.xcca91a4264df67ff = value;
				this.x80011d23d303e32c();
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x0000D374 File Offset: 0x0000C374
		[Browsable(false)]
		public Rectangle ScrollableViewportBounds
		{
			get
			{
				Rectangle clientRectangle = base.ClientRectangle;
				Size x455ae0624abb = this.x5a0996f223ed617b.x455ae0624abb5477;
				if (!this.PrimaryGrid.RightToLeft)
				{
					clientRectangle.X += x455ae0624abb.Width;
				}
				clientRectangle.Width -= x455ae0624abb.Width;
				clientRectangle.Y += x455ae0624abb.Height;
				clientRectangle.Height -= x455ae0624abb.Height;
				return clientRectangle;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x0000D3F8 File Offset: 0x0000C3F8
		[Browsable(false)]
		public SelectedElementCollection SelectedElements
		{
			get
			{
				return this.x5a0996f223ed617b.SelectedElements;
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x0000D408 File Offset: 0x0000C408
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x0000D410 File Offset: 0x0000C410
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public int VScrollOffset
		{
			get
			{
				return this.x7de459c2ab15ce67;
			}
			set
			{
				this.xdca261d82e245c35();
				int val = Math.Max(this.x1e79425de5ba86e5() - this.xd84c468937b92bf1.Height, 0);
				value = Math.Min(value, val);
				value = Math.Max(value, 0);
				if (value != this.x7de459c2ab15ce67)
				{
					this.x7de459c2ab15ce67 = value;
					if (this.EditorActive)
					{
						this.x9a764d3e9df67240();
					}
					this.x589c8b1e5b50eeb2();
					this.x758342b5e6c82828();
					base.Invalidate();
					this.x07ca1d0413b2172b();
				}
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001E5 RID: 485 RVA: 0x0000D488 File Offset: 0x0000C488
		// (set) Token: 0x060001E6 RID: 486 RVA: 0x0000D490 File Offset: 0x0000C490
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public int HScrollOffset
		{
			get
			{
				return this.x0ea770202eaa7707;
			}
			set
			{
				this.xdca261d82e245c35();
				int val = Math.Max(this.x8a4894e09db0940c() - this.xd84c468937b92bf1.Width, 0);
				value = Math.Min(value, val);
				value = Math.Max(value, 0);
				if (value != this.x0ea770202eaa7707)
				{
					this.x0ea770202eaa7707 = value;
					if (this.EditorActive)
					{
						this.x9a764d3e9df67240();
					}
					this.xd2533ac399c03a13();
					this.x758342b5e6c82828();
					base.Invalidate();
					this.x07ca1d0413b2172b();
				}
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x0000D508 File Offset: 0x0000C508
		private void x07ca1d0413b2172b()
		{
			Point point = base.PointToClient(Cursor.Position);
			MouseEventArgs xfbf34718e704c6bc = new MouseEventArgs(Control.MouseButtons, 0, point.X, point.Y, 0);
			xfbf34718e704c6bc = this.x7354ea3021799205(xfbf34718e704c6bc);
			x5d3666f49ba1c366.x3b699d824d6abf29(this, xfbf34718e704c6bc);
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x0000D54C File Offset: 0x0000C54C
		internal bool x0f67de551fd13731
		{
			get
			{
				return this.xa586690fe7bfedc2 || this.ShowFocusCues;
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001E9 RID: 489 RVA: 0x0000D560 File Offset: 0x0000C560
		// (set) Token: 0x060001EA RID: 490 RVA: 0x0000D570 File Offset: 0x0000C570
		[Description("Indicates whether the user is able to select multiple elements.")]
		[DefaultValue(true)]
		[Category("Selection")]
		public bool AllowMultipleSelection
		{
			get
			{
				return this.PrimaryGrid.AllowMultipleSelection;
			}
			set
			{
				this.PrimaryGrid.AllowMultipleSelection = value;
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001EB RID: 491 RVA: 0x0000D580 File Offset: 0x0000C580
		[Category("Data")]
		[Description("The rows of data contained in the control.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor(typeof(xf2a94613768c6d30), typeof(UITypeEditor))]
		public GridRowCollection Rows
		{
			get
			{
				return this.x5a0996f223ed617b.Rows;
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001EC RID: 492 RVA: 0x0000D590 File Offset: 0x0000C590
		[Browsable(false)]
		public IEnumerable FlatVisibleRows
		{
			get
			{
				return this.x5a0996f223ed617b.FlatVisibleRows;
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001ED RID: 493 RVA: 0x0000D5A0 File Offset: 0x0000C5A0
		[Browsable(false)]
		public IEnumerable FlatRows
		{
			get
			{
				return this.x5a0996f223ed617b.FlatRows;
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001EE RID: 494 RVA: 0x0000D5B0 File Offset: 0x0000C5B0
		[Browsable(false)]
		public IEnumerable OnscreenRows
		{
			get
			{
				return new xcb78343a5ebfa7a3(this.PrimaryGrid, this.VScrollOffset + this.PrimaryGrid.x455ae0624abb5477.Height, this.xd84c468937b92bf1.Height);
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001EF RID: 495 RVA: 0x0000D5F0 File Offset: 0x0000C5F0
		[Browsable(false)]
		public IEnumerable OnscreenColumns
		{
			get
			{
				return new xc5054229b6e2c76c(this.PrimaryGrid, this.HScrollOffset + this.PrimaryGrid.x455ae0624abb5477.Width, this.xd84c468937b92bf1.Width);
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x0000D630 File Offset: 0x0000C630
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x0000D64C File Offset: 0x0000C64C
		internal FocusableGridElement xf023f44afe4ba919
		{
			get
			{
				if (this.xfe52893ab2c061e1 == null)
				{
					this.xfe52893ab2c061e1 = this.FocusedElement;
				}
				return this.xfe52893ab2c061e1;
			}
			set
			{
				this.xfe52893ab2c061e1 = value;
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x0000D658 File Offset: 0x0000C658
		internal GridElement x2a10d07d82bcf8e6
		{
			get
			{
				return this.xfe52893ab2c061e1;
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001F3 RID: 499 RVA: 0x0000D660 File Offset: 0x0000C660
		[Browsable(false)]
		public int SelectedElementCount
		{
			get
			{
				return this.x5a0996f223ed617b.SelectedElementCount;
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x0000D670 File Offset: 0x0000C670
		[Browsable(false)]
		public SandGridPrintDocument PrintDocument
		{
			get
			{
				if (this.x057c142f95f8b1c5 == null)
				{
					this.x057c142f95f8b1c5 = new SandGridPrintDocument(this);
				}
				return this.x057c142f95f8b1c5;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001F5 RID: 501 RVA: 0x0000D68C File Offset: 0x0000C68C
		// (set) Token: 0x060001F6 RID: 502 RVA: 0x0000D694 File Offset: 0x0000C694
		[DefaultValue(true)]
		[Description("Indicates whether tooltips are shown on the control.")]
		[Category("Behavior")]
		public bool Tooltips
		{
			get
			{
				return this.x7487aed20df9e17f;
			}
			set
			{
				this.x7487aed20df9e17f = value;
			}
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000D6A0 File Offset: 0x0000C6A0
		public Point PointToGrid(Point position)
		{
			bool flag = position.X > this.x5a0996f223ed617b.x455ae0624abb5477.Width;
			bool flag2 = position.Y > this.x5a0996f223ed617b.x455ae0624abb5477.Height;
			if (flag && flag2)
			{
				return new Point(position.X + this.HScrollOffset, position.Y + this.VScrollOffset);
			}
			if (flag)
			{
				return new Point(position.X + this.HScrollOffset, position.Y);
			}
			if (flag2)
			{
				return new Point(position.X, position.Y + this.VScrollOffset);
			}
			return position;
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x0000D74C File Offset: 0x0000C74C
		public Point PointFromGrid(Point position)
		{
			return new Point(position.X - this.HScrollOffset, position.Y - this.VScrollOffset);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0000D770 File Offset: 0x0000C770
		private MouseEventArgs x7354ea3021799205(MouseEventArgs xfbf34718e704c6bc)
		{
			int y = this.x3178708748cb3aba ? (xfbf34718e704c6bc.Y + this.x7de459c2ab15ce67) : xfbf34718e704c6bc.Y;
			int num = xfbf34718e704c6bc.X;
			if (this.x8944a87bbc8c2677)
			{
				num += this.x0ea770202eaa7707;
			}
			else if (this.PrimaryGrid.RightToLeft)
			{
				int num2 = Math.Max(this.x9ebf40bfdd2119aa.Width - this.xd84c468937b92bf1.Width - (this.PrimaryGrid.ShowRowHeaders ? this.PrimaryGrid.RowHeaderSize : 0), 0);
				num += num2;
			}
			return new MouseEventArgs(xfbf34718e704c6bc.Button, xfbf34718e704c6bc.Clicks, num, y, 0);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0000D818 File Offset: 0x0000C818
		private void x20304545453d4b87()
		{
			this.xc833ec9e4d027a80.Enabled = false;
			x5d3666f49ba1c366.x4a88bb2da4167d39(this);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0000D82C File Offset: 0x0000C82C
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (this.x266365ea27fa7af8.Locked)
			{
				return;
			}
			x5d3666f49ba1c366.x13ea64a23cc9492a(this, this.x7354ea3021799205(e));
			base.OnMouseUp(e);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000D850 File Offset: 0x0000C850
		private string xa3a7472ac4e61f76(Point xb9c2cfae130d9256)
		{
			if (!this.Tooltips)
			{
				return string.Empty;
			}
			bool flag = xb9c2cfae130d9256.X > this.x5a0996f223ed617b.x455ae0624abb5477.Width;
			bool flag2 = xb9c2cfae130d9256.Y > this.x5a0996f223ed617b.x455ae0624abb5477.Height;
			if (flag)
			{
				xb9c2cfae130d9256.X += this.HScrollOffset;
			}
			if (flag2)
			{
				xb9c2cfae130d9256.Y += this.VScrollOffset;
			}
			return this.x5a0996f223ed617b.x9b21ee8e7ceaada3(xb9c2cfae130d9256);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000D8E0 File Offset: 0x0000C8E0
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (!base.Capture)
			{
				this.x3178708748cb3aba = (e.Y > this.x5a0996f223ed617b.x455ae0624abb5477.Height);
				if (this.PrimaryGrid.RightToLeft)
				{
					this.x8944a87bbc8c2677 = (e.X < base.ClientRectangle.Right - this.x5a0996f223ed617b.x455ae0624abb5477.Width || !this.x3178708748cb3aba);
				}
				else
				{
					this.x8944a87bbc8c2677 = (e.X > this.x5a0996f223ed617b.x455ae0624abb5477.Width);
				}
			}
			if (e.Button == MouseButtons.Left && !this.ScrollableViewportBounds.Contains(e.X, e.Y) && GridElement.x263912479c3c5786 != null && GridElement.x263912479c3c5786.x7e153dc1ab2f9ad3 && !this.xc833ec9e4d027a80.Enabled)
			{
				this.xc833ec9e4d027a80.Enabled = true;
			}
			e = this.x7354ea3021799205(e);
			x5d3666f49ba1c366.x3b699d824d6abf29(this, e);
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000D9F4 File Offset: 0x0000C9F4
		protected override void OnMouseLeave(EventArgs e)
		{
			x5d3666f49ba1c366.xaeb9c29200d2fd71(this);
			base.OnMouseLeave(e);
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0000DA04 File Offset: 0x0000CA04
		protected override void OnDoubleClick(EventArgs e)
		{
			if (this.x266365ea27fa7af8.Locked)
			{
				return;
			}
			this.x73eedfda554ed6f1();
			Point point = base.PointToClient(Cursor.Position);
			MouseEventArgs xfbf34718e704c6bc = this.x7354ea3021799205(new MouseEventArgs(MouseButtons.None, 2, point.X, point.Y, 0));
			if (!x5d3666f49ba1c366.xa96e14d79552a61d(this, xfbf34718e704c6bc))
			{
				base.OnDoubleClick(e);
			}
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0000DA60 File Offset: 0x0000CA60
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (this.x266365ea27fa7af8.Locked)
			{
				return;
			}
			if (this.EditorActive)
			{
				if (!this.x48546f274ac60a66(true, false, false))
				{
					return;
				}
			}
			else
			{
				this.x73eedfda554ed6f1();
			}
			x5d3666f49ba1c366.x35085a23be2a381a(this, this.x7354ea3021799205(e));
			if (!this.Focused && !this.EditorActive)
			{
				base.Focus();
			}
			base.OnMouseDown(e);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000DAC0 File Offset: 0x0000CAC0
		[Obsolete("Use the SelectedElements.GetCells method instead.")]
		public GridCell[] GetSelectedCells()
		{
			return this.x5a0996f223ed617b.GetSelectedCells();
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0000DAD0 File Offset: 0x0000CAD0
		public void SelectElement(FocusableGridElement element)
		{
			this.x5a0996f223ed617b.SelectElement(element);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000DAE0 File Offset: 0x0000CAE0
		public void SelectRow(GridRow row)
		{
			this.x5a0996f223ed617b.SelectElement(row);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0000DAF0 File Offset: 0x0000CAF0
		[Obsolete("Use SelectedElements.Clear instead.")]
		public void ClearSelection()
		{
			this.x5a0996f223ed617b.SelectedElements.Clear();
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0000DB04 File Offset: 0x0000CB04
		internal void xf7115efe1c1b0dcf(InnerGrid xf57b149cb3f9c03a)
		{
			if (this.x737f7a4b63639f66 != null && this.x737f7a4b63639f66.Grid == xf57b149cb3f9c03a)
			{
				NestedGridRow nestedGridRow = xf57b149cb3f9c03a.ParentElement as NestedGridRow;
				if (nestedGridRow != null && nestedGridRow.ParentRow != null && nestedGridRow.ParentRow.Grid != null && nestedGridRow.ParentRow.Grid.SandGrid == this && nestedGridRow.ParentRow.IsExpansionVisible())
				{
					this.FocusedElement = nestedGridRow.ParentRow;
				}
				else
				{
					this.FocusedElement = null;
				}
			}
			if (this.x2a10d07d82bcf8e6 != null && this.x2a10d07d82bcf8e6.Grid == xf57b149cb3f9c03a)
			{
				this.xf023f44afe4ba919 = null;
			}
			if (this.EditorActive && this.x67740018b77b66d4.Grid == xf57b149cb3f9c03a)
			{
				this.x48546f274ac60a66(false, true, true);
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x06000206 RID: 518 RVA: 0x0000DBC0 File Offset: 0x0000CBC0
		// (set) Token: 0x06000207 RID: 519 RVA: 0x0000DBE4 File Offset: 0x0000CBE4
		[DefaultValue(typeof(GridElement), null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public FocusableGridElement FocusedElement
		{
			get
			{
				if (this.x9fde6943eed61cee == null)
				{
					this.FocusedElement = this.PrimaryGrid.x297751add55a1707(false);
				}
				return this.x9fde6943eed61cee;
			}
			set
			{
				if (value != this.x9fde6943eed61cee)
				{
					if (value != null && (value.Grid == null || value.Grid.SandGrid != this))
					{
						throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNoGrid"), "value");
					}
					GridCell gridCell = this.x9fde6943eed61cee as GridCell;
					GridCell gridCell2 = value as GridCell;
					if (this.x9fde6943eed61cee != null)
					{
						this.x9fde6943eed61cee.OnLeave();
						if (gridCell != null && ((gridCell2 != null && gridCell2.ParentRow != gridCell.ParentRow) || gridCell2 == null))
						{
							gridCell.ParentRow.OnLeave();
						}
					}
					this.x9fde6943eed61cee = value;
					if (this.x9fde6943eed61cee != null)
					{
						this.x0adf5235abca736b(this.x9fde6943eed61cee.Grid);
						if (gridCell2 != null && ((gridCell != null && gridCell2.ParentRow != gridCell.ParentRow) || gridCell == null))
						{
							gridCell2.ParentRow.OnEnter();
						}
						this.x9fde6943eed61cee.OnEnter();
					}
				}
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000208 RID: 520 RVA: 0x0000DCC0 File Offset: 0x0000CCC0
		internal FocusableGridElement x737f7a4b63639f66
		{
			get
			{
				return this.x9fde6943eed61cee;
			}
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000DCC8 File Offset: 0x0000CCC8
		protected internal virtual void OnRowActivated(GridRowEventArgs e)
		{
			if (this.xad878b8fb06f932a != null)
			{
				this.xad878b8fb06f932a(this, e);
			}
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000DCE0 File Offset: 0x0000CCE0
		protected internal virtual void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			if (!this.xb41acd866d5cbca8 && this.x6d6f7a19a6e74243 != null)
			{
				this.x6d6f7a19a6e74243(this, e);
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0000DD00 File Offset: 0x0000CD00
		protected internal virtual void OnColumnHeaderClick(GridColumnEventArgs e)
		{
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0000DD04 File Offset: 0x0000CD04
		protected internal virtual void OnActiveGridChanged(EventArgs e)
		{
			if (this.xdee092d4d5407b26 != null)
			{
				this.xdee092d4d5407b26(this, e);
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000DD1C File Offset: 0x0000CD1C
		public void SelectAll()
		{
			this.x5a0996f223ed617b.SelectAll();
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000DD2C File Offset: 0x0000CD2C
		protected override void OnGotFocus(EventArgs e)
		{
			if (this.FocusedElement != null)
			{
				this.FocusedElement.RedrawNeeded();
			}
			base.OnGotFocus(e);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000DD48 File Offset: 0x0000CD48
		protected override void OnLostFocus(EventArgs e)
		{
			this.x73eedfda554ed6f1();
			if (this.FocusedElement != null)
			{
				this.FocusedElement.RedrawNeeded();
			}
			base.OnLostFocus(e);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000DD6C File Offset: 0x0000CD6C
		protected override bool ProcessKeyEventArgs(ref Message m)
		{
			if ((m.Msg == 608 || m.Msg == 256) && !this.EditorActive && (this.KeyboardEditing & KeyboardEditMode.EditOnKeystroke) == KeyboardEditMode.EditOnKeystroke)
			{
				KeyEventArgs xfbf34718e704c6bc = new KeyEventArgs((Keys)((int)m.WParam));
				if ((Control.ModifierKeys & Keys.Control) != Keys.Control && this.xa24c69a8328f0773(xfbf34718e704c6bc) && this.xdaf9db116dc3bfba(true))
				{
					x443cc432acaadb1d.SendMessage(this.xcc17d608c5279127.Handle, m.Msg, m.WParam, m.LParam);
					this.x9fa18ed8ade3e644(x681471a7f6916d5c.xa3365df90d2eaa10, true);
					return true;
				}
			}
			if (this.x429e83d68c5ae0cb(x681471a7f6916d5c.xa3365df90d2eaa10) && (m.Msg == 262 || m.Msg == 258 || m.Msg == 646))
			{
				this.x9fa18ed8ade3e644(x681471a7f6916d5c.xa3365df90d2eaa10, false);
				if (this.EditorActive)
				{
					x443cc432acaadb1d.SendMessage(this.xcc17d608c5279127.Handle, m.Msg, m.WParam, m.LParam);
					return true;
				}
			}
			return base.ProcessKeyEventArgs(ref m);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0000DE7C File Offset: 0x0000CE7C
		private bool xa24c69a8328f0773(KeyEventArgs xfbf34718e704c6bc)
		{
			switch (xfbf34718e704c6bc.KeyCode)
			{
			case Keys.F1:
			case Keys.F2:
			case Keys.F3:
			case Keys.F4:
			case Keys.F5:
			case Keys.F6:
			case Keys.F7:
			case Keys.F8:
			case Keys.F9:
			case Keys.F10:
			case Keys.F11:
			case Keys.F12:
				return false;
			default:
			{
				bool flag = xfbf34718e704c6bc.KeyCode >= Keys.NumPad0 && xfbf34718e704c6bc.KeyCode <= Keys.Divide;
				bool flag2 = xfbf34718e704c6bc.KeyCode >= Keys.OemSemicolon && xfbf34718e704c6bc.KeyCode <= Keys.OemBackslash;
				bool flag3 = xfbf34718e704c6bc.KeyCode == Keys.Space && !xfbf34718e704c6bc.Shift;
				return char.IsLetterOrDigit((char)xfbf34718e704c6bc.KeyCode) || flag || flag2 || flag3;
			}
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0000DF38 File Offset: 0x0000CF38
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool flag = base.ProcessCmdKey(ref msg, keyData);
			if (!flag && keyData == (Keys.ShiftKey | Keys.Space | Keys.Control))
			{
				this.xc6884fa76a019425();
			}
			return flag;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000DF64 File Offset: 0x0000CF64
		protected override bool ProcessDialogKey(Keys keyData)
		{
			return (keyData == (Keys)262250 && this.x779f690913c6321a()) || base.ProcessDialogKey(keyData);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000DF80 File Offset: 0x0000CF80
		protected override bool ProcessKeyPreview(ref Message m)
		{
			Keys keys = (Keys)((int)m.WParam);
			if (keys == Keys.Escape)
			{
				this.xf1af43bae36ec7a3();
			}
			else if (keys == Keys.Return && this.EditorActive)
			{
				if (!this.x429e83d68c5ae0cb(x681471a7f6916d5c.x01a0978cfbd0bcd8))
				{
					this.x48546f274ac60a66(true, false, true);
				}
				return true;
			}
			return base.ProcessKeyPreview(ref m);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000DFD0 File Offset: 0x0000CFD0
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
			{
				return;
			}
			if (e.KeyChar == '-' || e.KeyChar == '+')
			{
				GridRow xda48682af7b = this.xda48682af7b76596;
				if (xda48682af7b != null)
				{
					if (xda48682af7b.Expanded)
					{
						xda48682af7b.x98ab41ccb801e030(ExpandCollapseTrigger.Keyboard);
					}
					else
					{
						xda48682af7b.x3e3f6c8fa322858b(ExpandCollapseTrigger.Keyboard);
					}
				}
			}
			else if (e.KeyChar != '\r' && (e.KeyChar != ' ' || this.x0c5fbff028b27f44.Length != 0) && !this.EditorActive && this.EnableSearching)
			{
				this.xc3aba6e499a38625(e.KeyChar);
			}
			base.OnKeyPress(e);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000E06C File Offset: 0x0000D06C
		private void x8ba849c83c9ae0fa(Keys x83f3ea1d0a03c7e1)
		{
			if (this.FocusedElement != null)
			{
				this.xa586690fe7bfedc2 = true;
				GridRow gridRow = this.FocusedElement as GridRow;
				if (gridRow != null && gridRow.Grid.CheckBoxes)
				{
					gridRow.OnCheckBoxClick(new GridRowCheckEventArgs(gridRow, CheckTrigger.Keyboard));
					return;
				}
				if ((x83f3ea1d0a03c7e1 & Keys.Control) == Keys.Control)
				{
					this.FocusedElement.Selected = !this.FocusedElement.Selected;
					return;
				}
				this.FocusedElement.Selected = true;
			}
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000E0E8 File Offset: 0x0000D0E8
		protected override void OnKeyDown(KeyEventArgs e)
		{
			Keys keys = e.KeyData & Keys.KeyCode;
			if (e.KeyData == (Keys.ShiftKey | Keys.Space | Keys.Control))
			{
				this.xc6884fa76a019425();
			}
			if (keys == Keys.Space)
			{
				this.x8ba849c83c9ae0fa(e.KeyData);
				e.Handled = true;
				return;
			}
			if (keys == Keys.F2)
			{
				this.xfa474f1f032849ed();
			}
			else
			{
				if (keys != Keys.Up)
				{
					if (15 != 0)
					{
						if (keys == Keys.Down || keys == Keys.Left || keys == Keys.Right || keys == Keys.Prior || keys == Keys.Next || keys == Keys.Home || keys == Keys.End || keys == Keys.Tab)
						{
							goto IL_9D;
						}
						if (e.KeyData == (Keys)131137)
						{
							if (this.FocusedElement == null)
							{
								goto IL_69;
							}
						}
						else if (e.KeyData == (Keys)131139)
						{
							if (this.FocusedElement != null)
							{
								if (this.PrimaryGrid.SelectionGranularity == SelectionGranularity.Row)
								{
									this.FocusedElement.Grid.CopySelectedRowsToClipboard();
								}
								else
								{
									this.FocusedElement.Grid.CopySelectedCellsToClipboard(false);
								}
								e.Handled = true;
								return;
							}
							goto IL_69;
						}
						else
						{
							if (e.KeyData == (Keys)131158 && this.AllowPaste && this.FocusedElement != null)
							{
								ClipboardOperations.PasteFromClipboard(this.FocusedElement);
								e.Handled = true;
								return;
							}
							if (keys == Keys.Return)
							{
								this.x3170a7ca47a545a8();
								goto IL_69;
							}
							goto IL_69;
						}
					}
					if (this.FocusedElement.Grid.AllowMultipleSelection)
					{
						this.FocusedElement.Grid.SelectAll();
						e.Handled = true;
						return;
					}
					goto IL_69;
				}
				IL_9D:
				if (this.x2e9aeedb12b9f1fb(keys))
				{
					e.Handled = true;
					return;
				}
			}
			IL_69:
			base.OnKeyDown(e);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x0000E27C File Offset: 0x0000D27C
		private bool xc6884fa76a019425()
		{
			if (this.EditorActive)
			{
				(this.xcc17d608c5279127 as IGridCellEditor).EditorValue = null;
				if (this.EditorActive)
				{
					this.EditorDirty = true;
				}
			}
			return true;
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0000E2A8 File Offset: 0x0000D2A8
		private bool x2e9aeedb12b9f1fb(Keys xba08ce632055a1d9)
		{
			bool flag = false;
			int num;
			bool flag2;
			if ((uint)num + (flag2 ? 1U : 0U) >= 0U)
			{
				bool flag3 = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;
				flag2 = ((Control.ModifierKeys & Keys.Control) == Keys.Control);
				this.xa586690fe7bfedc2 = true;
				if (this.PrimaryGrid.RightToLeft)
				{
					if (xba08ce632055a1d9 == Keys.Left)
					{
						xba08ce632055a1d9 = Keys.Right;
					}
					else if (xba08ce632055a1d9 == Keys.Right)
					{
						xba08ce632055a1d9 = Keys.Left;
					}
				}
				if (this.FocusedElement != null)
				{
					FocusAdvanceDirection focusAdvanceDirection = FocusAdvanceDirection.Up;
					bool flag4;
					if (xba08ce632055a1d9 == Keys.Up || xba08ce632055a1d9 == Keys.Prior || xba08ce632055a1d9 == Keys.Home)
					{
						focusAdvanceDirection = FocusAdvanceDirection.Up;
					}
					else
					{
						if (xba08ce632055a1d9 != Keys.Down)
						{
							while (xba08ce632055a1d9 != Keys.Next && xba08ce632055a1d9 != Keys.End)
							{
								if (xba08ce632055a1d9 == Keys.Left)
								{
									focusAdvanceDirection = FocusAdvanceDirection.Left;
									flag4 = (((flag2 ? 1U : 0U) & 0U) == 0U);
									if (flag4)
									{
										goto IL_127;
									}
								}
								else
								{
									if (xba08ce632055a1d9 == Keys.Right)
									{
										focusAdvanceDirection = FocusAdvanceDirection.Right;
										goto IL_127;
									}
									if (xba08ce632055a1d9 == Keys.Tab)
									{
										flag = true;
										focusAdvanceDirection = (flag3 ? FocusAdvanceDirection.Left : FocusAdvanceDirection.Right);
										flag2 = (flag3 = false);
										goto IL_127;
									}
									goto IL_127;
								}
							}
						}
						focusAdvanceDirection = FocusAdvanceDirection.Down;
					}
					IL_127:
					FocusAdvanceMethod focusAdvanceMethod = FocusAdvanceMethod.MoveSelection;
					if (this.PrimaryGrid.AllowMultipleSelection)
					{
						if (flag3)
						{
							focusAdvanceMethod = FocusAdvanceMethod.IncreaseSelection;
						}
						else if (flag2)
						{
							focusAdvanceMethod = FocusAdvanceMethod.FocusOnly;
						}
					}
					IL_13D:
					int num2 = 1;
					if (xba08ce632055a1d9 == Keys.Prior || xba08ce632055a1d9 == Keys.Next)
					{
						num2 = this.x56bd63f2f75c7c4d(xba08ce632055a1d9 == Keys.Next, ref focusAdvanceDirection);
					}
					else
					{
						if (xba08ce632055a1d9 != Keys.Home)
						{
							if ((uint)num2 - (flag ? 1U : 0U) < 0U)
							{
								goto IL_13D;
							}
							if (xba08ce632055a1d9 != Keys.End)
							{
								goto IL_F0;
							}
						}
						num2 = -1;
					}
					IL_F0:
					bool flag5 = false;
					if (num2 != 0)
					{
						flag5 = this.FocusedElement.AdvanceFocus(focusAdvanceDirection, focusAdvanceMethod, num2, flag);
						if (focusAdvanceMethod == FocusAdvanceMethod.MoveSelection)
						{
							this.xfe52893ab2c061e1 = this.FocusedElement;
						}
					}
					if (flag5)
					{
						return true;
					}
					num = 0;
					FocusAdvanceDirection focusAdvanceDirection2 = focusAdvanceDirection;
					flag4 = ((flag ? 1U : 0U) - (flag3 ? 1U : 0U) < 0U);
					if (!flag4)
					{
						switch (focusAdvanceDirection2)
						{
						case FocusAdvanceDirection.Up:
							if (num2 == 1)
							{
								num = -GridRow.x993356576cc2bf99;
								goto IL_79;
							}
							if (num2 == -1)
							{
								num = -this.VScrollOffset;
								goto IL_79;
							}
							num = -this.xd84c468937b92bf1.Height;
							goto IL_49;
						case FocusAdvanceDirection.Down:
							if (num2 == 1)
							{
								num = GridRow.x993356576cc2bf99;
								goto IL_79;
							}
							if (num2 == -1)
							{
								num = this.x1e79425de5ba86e5();
								goto IL_79;
							}
							num = this.xd84c468937b92bf1.Height;
							goto IL_79;
						default:
							goto IL_79;
						}
					}
					goto IL_127;
				}
				return true;
			}
			IL_49:
			IL_79:
			this.VScrollOffset += num;
			return true;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0000E510 File Offset: 0x0000D510
		private int x56bd63f2f75c7c4d(bool x984399ee4edeb5af, ref FocusAdvanceDirection x23e85093ba3a7d1d)
		{
			GridRow xda48682af7b = this.xda48682af7b76596;
			if (xda48682af7b == null)
			{
				return 0;
			}
			GridRow gridRow = this.xba3a32e29ea5ba20(xda48682af7b, x984399ee4edeb5af);
			if (gridRow == null || gridRow == xda48682af7b)
			{
				return 0;
			}
			x23e85093ba3a7d1d = ((xda48682af7b.Bounds.Y < gridRow.Bounds.Y) ? FocusAdvanceDirection.Down : FocusAdvanceDirection.Up);
			GridRow gridRow2 = xda48682af7b;
			GridRow gridRow3 = gridRow;
			int num = 0;
			GridRow gridRow4 = gridRow2;
			while (gridRow4 != gridRow3 && gridRow4 != null)
			{
				gridRow4 = (GridRow)gridRow4.GetNextElement(x23e85093ba3a7d1d);
				num++;
			}
			return num;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x0000E590 File Offset: 0x0000D590
		private GridRow xba3a32e29ea5ba20(GridRow xc0fdea7a43fe2912, bool x984399ee4edeb5af)
		{
			if (!x984399ee4edeb5af)
			{
				GridRow gridRow = xc0fdea7a43fe2912.Grid.x5813c861bfd97f54();
				if (xc0fdea7a43fe2912 != gridRow)
				{
					return gridRow;
				}
				int num = xc0fdea7a43fe2912.Bounds.Bottom - this.xd84c468937b92bf1.Height + GridRow.x993356576cc2bf99;
				GridRow gridRow2;
				for (;;)
				{
					IL_A4:
					gridRow2 = xc0fdea7a43fe2912;
					GridRow result = null;
					while (gridRow2 != null)
					{
						result = gridRow2;
						if (gridRow2.Bounds.Top <= num && gridRow2 != xc0fdea7a43fe2912)
						{
							return gridRow2;
						}
						gridRow2 = gridRow2.PreviousVisibleRow;
						if (false)
						{
							goto IL_A4;
						}
					}
					return result;
				}
				return gridRow2;
			}
			else
			{
				GridRow gridRow3 = xc0fdea7a43fe2912.Grid.x7fac5112771770c3();
				if (xc0fdea7a43fe2912 != gridRow3)
				{
					return gridRow3;
				}
				int num2 = xc0fdea7a43fe2912.Bounds.Top + this.xd84c468937b92bf1.Height - GridRow.x993356576cc2bf99;
				GridRow gridRow4 = xc0fdea7a43fe2912;
				GridRow result2 = null;
				while (gridRow4 != null)
				{
					result2 = gridRow4;
					if (gridRow4.Bounds.Bottom >= num2 && gridRow4 != xc0fdea7a43fe2912)
					{
						return gridRow4;
					}
					gridRow4 = gridRow4.NextVisibleRow;
				}
				return result2;
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x0000E68C File Offset: 0x0000D68C
		private bool x779f690913c6321a()
		{
			GridRow xda48682af7b = this.xda48682af7b76596;
			if (xda48682af7b == null || (!xda48682af7b.HasRows && !xda48682af7b.ContentsUnknown))
			{
				return false;
			}
			if (!xda48682af7b.Expanded)
			{
				xda48682af7b.x3e3f6c8fa322858b(ExpandCollapseTrigger.Keyboard);
			}
			else
			{
				int num = 0;
				for (;;)
				{
					ArrayList arrayList = new ArrayList();
					this.x2f38eae850bb4c02(xda48682af7b.NestedRows, num, 0, arrayList);
					if (arrayList.Count == 0)
					{
						break;
					}
					if (this.xc13ce947f808e1ab(arrayList))
					{
						using (IEnumerator enumerator = arrayList.GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								GridRow gridRow = (GridRow)obj;
								if (!gridRow.Expanded && (gridRow.HasRows || gridRow.ContentsUnknown))
								{
									gridRow.x3e3f6c8fa322858b(ExpandCollapseTrigger.Keyboard);
								}
							}
							break;
						}
					}
					num++;
				}
			}
			return true;
		}

		// Token: 0x0600021D RID: 541 RVA: 0x0000E770 File Offset: 0x0000D770
		private bool xc13ce947f808e1ab(ICollection x2eb5785cf1641b8b)
		{
			foreach (object obj in x2eb5785cf1641b8b)
			{
				GridRow gridRow = (GridRow)obj;
				if (!gridRow.Expanded && (gridRow.HasRows || gridRow.ContentsUnknown))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0000E7E8 File Offset: 0x0000D7E8
		private void x2f38eae850bb4c02(GridRowCollection x2eb5785cf1641b8b, int x66bbd7ed8c65740d, int x6b468d6a6158972e, ArrayList x6c6319021d523428)
		{
			if (x6b468d6a6158972e == x66bbd7ed8c65740d)
			{
				using (IEnumerator enumerator = x2eb5785cf1641b8b.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						object obj = enumerator.Current;
						GridRow value = (GridRow)obj;
						x6c6319021d523428.Add(value);
					}
					return;
				}
			}
			foreach (object obj2 in x2eb5785cf1641b8b)
			{
				GridRow gridRow = (GridRow)obj2;
				if (gridRow.HasRows)
				{
					this.x2f38eae850bb4c02(gridRow.NestedRows, x66bbd7ed8c65740d, x6b468d6a6158972e + 1, x6c6319021d523428);
				}
				else
				{
					NestedGridRow nestedGridRow = gridRow as NestedGridRow;
					if (nestedGridRow != null)
					{
						this.x2f38eae850bb4c02(nestedGridRow.NestedGrid.Rows, x66bbd7ed8c65740d, x6b468d6a6158972e + 1, x6c6319021d523428);
					}
				}
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000E8E0 File Offset: 0x0000D8E0
		private bool x3170a7ca47a545a8()
		{
			if (this.xf023f44afe4ba919 != null)
			{
				GridRow gridRow = this.xf023f44afe4ba919 as GridRow;
				if (gridRow != null)
				{
					this.OnRowActivated(new GridRowEventArgs(gridRow));
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000E914 File Offset: 0x0000D914
		private bool xfa474f1f032849ed()
		{
			return !this.EditorActive && this.xda48682af7b76596 != null && (this.KeyboardEditing & KeyboardEditMode.EditOnF2) == KeyboardEditMode.EditOnF2 && this.xdaf9db116dc3bfba(true);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000E93C File Offset: 0x0000D93C
		private void xf1af43bae36ec7a3()
		{
			if (this.EditorActive)
			{
				this.x48546f274ac60a66(false, false, true);
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000E950 File Offset: 0x0000D950
		private bool xdaf9db116dc3bfba(bool x7fe3c744bc3a2b2e)
		{
			return this.FocusedElement != null && this.x4b66c6aa52b6a667(this.FocusedElement, x7fe3c744bc3a2b2e);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000E96C File Offset: 0x0000D96C
		private bool x4b66c6aa52b6a667(GridElement x4bbc2c453c470189, bool x7fe3c744bc3a2b2e)
		{
			if (this.EditorActive)
			{
				return false;
			}
			GridRow gridRow;
			GridColumn gridColumn;
			if (x4bbc2c453c470189.Grid.SelectionGranularity == SelectionGranularity.Row)
			{
				gridRow = (x4bbc2c453c470189 as GridRow);
				if (gridRow == null)
				{
					return false;
				}
				gridColumn = this.GetEditedColumnForRow(gridRow);
				if (gridColumn == null)
				{
					return false;
				}
			}
			else
			{
				GridCell gridCell = x4bbc2c453c470189 as GridCell;
				if (gridCell == null)
				{
					return false;
				}
				gridRow = gridCell.ParentRow;
				gridColumn = gridRow.Grid.Columns[gridRow.Cells.IndexOf(gridCell)];
			}
			return this.BeginEdit(gridRow, gridColumn, x7fe3c744bc3a2b2e);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000E9E4 File Offset: 0x0000D9E4
		protected virtual GridColumn GetEditedColumnForRow(GridRow row)
		{
			return row.Grid.PrimaryColumn;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000225 RID: 549 RVA: 0x0000E9F4 File Offset: 0x0000D9F4
		internal GridRow xda48682af7b76596
		{
			get
			{
				if (this.FocusedElement is GridRow)
				{
					return (GridRow)this.FocusedElement;
				}
				if (this.FocusedElement is GridCell)
				{
					return ((GridCell)this.FocusedElement).ParentRow;
				}
				return null;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000226 RID: 550 RVA: 0x0000EA30 File Offset: 0x0000DA30
		internal GridColumn xf280efb186af0af5
		{
			get
			{
				if (this.FocusedElement is GridCell)
				{
					return ((GridCell)this.FocusedElement).ParentColumn;
				}
				return null;
			}
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000EA54 File Offset: 0x0000DA54
		protected override bool IsInputKey(Keys keyData)
		{
			Keys keys = keyData & Keys.KeyCode;
			Keys keys2 = keys;
			if (keys2 == Keys.Tab)
			{
				return this.PrimaryGrid.SelectionGranularity == SelectionGranularity.Cell && !this.StandardTab;
			}
			if (keys2 == Keys.Return)
			{
				return true;
			}
			switch (keys2)
			{
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
				return true;
			default:
				return base.IsInputKey(keyData);
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000EAB8 File Offset: 0x0000DAB8
		protected override bool IsInputChar(char charCode)
		{
			return true;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000EABC File Offset: 0x0000DABC
		private void xc3aba6e499a38625(char x12f11d52c2c4d003)
		{
			this.x0c5fbff028b27f44 += x12f11d52c2c4d003;
			this.x64a0b0f7c755e76d.Enabled = false;
			this.x64a0b0f7c755e76d.Enabled = true;
			if (!this.x7e5e64c4ad8fb23a)
			{
				this.xac0744c2a3f4ba80();
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000EAFC File Offset: 0x0000DAFC
		private bool xc1c2292d9bb13218(string x337e217cb3ba0627, string x0b29d3606ece52c2)
		{
			return x337e217cb3ba0627.Length >= x0b29d3606ece52c2.Length && string.Compare(x337e217cb3ba0627.Substring(0, x0b29d3606ece52c2.Length), x0b29d3606ece52c2, true) == 0;
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000EB28 File Offset: 0x0000DB28
		private void xac0744c2a3f4ba80()
		{
			if (this.Rows.Count == 0 || this.FocusedElement == null)
			{
				return;
			}
			GridRow gridRow = this.FocusedElement as GridRow;
			if (gridRow == null)
			{
				return;
			}
			GridColumn primaryColumn = this.PrimaryGrid.PrimaryColumn;
			if (this.x0c5fbff028b27f44.Length > 1)
			{
				string text = primaryColumn.xf69eb59aa621a379(gridRow, gridRow.GetCellValue(primaryColumn), typeof(string)) as string;
				if (text == null)
				{
					text = "";
				}
				if (this.xc1c2292d9bb13218(text, this.x0c5fbff028b27f44))
				{
					return;
				}
			}
			int indexInGrid = gridRow.IndexInGrid;
			do
			{
				gridRow = gridRow.NextVisibleRow;
				if (gridRow == null)
				{
					gridRow = this.PrimaryGrid.GetFirstVisibleRow();
				}
				string text2 = primaryColumn.xf69eb59aa621a379(gridRow, gridRow.GetCellValue(primaryColumn), typeof(string)) as string;
				if (text2 == null)
				{
					text2 = "";
				}
				if (this.xc1c2292d9bb13218(text2, this.x0c5fbff028b27f44))
				{
					goto Block_10;
				}
			}
			while (gridRow.IndexInGrid != indexInGrid);
			if (!this.x7e5e64c4ad8fb23a)
			{
				x443cc432acaadb1d.MessageBeep(0U);
				this.x7e5e64c4ad8fb23a = true;
			}
			return;
			Block_10:
			this.SelectRow(gridRow);
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000EC3C File Offset: 0x0000DC3C
		private void x8609e20c55624961(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x64a0b0f7c755e76d.Enabled = false;
			this.x7e5e64c4ad8fb23a = false;
			this.x0c5fbff028b27f44 = "";
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000EC5C File Offset: 0x0000DC5C
		public void PageSetup()
		{
			using (PageSetupDialog pageSetupDialog = new PageSetupDialog())
			{
				pageSetupDialog.Document = this.PrintDocument;
				pageSetupDialog.EnableMetric = true;
				if (pageSetupDialog.ShowDialog(this) == DialogResult.Cancel)
				{
				}
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000ECB8 File Offset: 0x0000DCB8
		public void Print(bool showPrintDialog)
		{
			if (showPrintDialog)
			{
				using (PrintDialog printDialog = new PrintDialog())
				{
					printDialog.Document = this.PrintDocument;
					if (printDialog.ShowDialog(this) == DialogResult.Cancel)
					{
						return;
					}
				}
			}
			this.PrintDocument.Print();
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000ED1C File Offset: 0x0000DD1C
		public void PrintPreview()
		{
			using (PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog())
			{
				printPreviewDialog.Document = this.PrintDocument;
				printPreviewDialog.UseAntiAlias = true;
				printPreviewDialog.StartPosition = FormStartPosition.CenterParent;
				printPreviewDialog.Size = new Size(640, 480);
				printPreviewDialog.ShowDialog(this);
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000ED90 File Offset: 0x0000DD90
		public string SerializeState()
		{
			return this.x5a0996f223ed617b.SerializeState();
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000EDA0 File Offset: 0x0000DDA0
		public void DeserializeState(string state)
		{
			this.x5a0996f223ed617b.DeserializeState(state);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000EDB0 File Offset: 0x0000DDB0
		public static void ActivateProduct(string licenseKey)
		{
			x294bd621a33dc533.ActivateProduct(licenseKey);
		}

		// Token: 0x0400004F RID: 79
		private InnerGrid x5a0996f223ed617b;

		// Token: 0x04000050 RID: 80
		private bool xeda7dac292b0fea5;

		// Token: 0x04000051 RID: 81
		private bool xa586690fe7bfedc2;

		// Token: 0x04000052 RID: 82
		private bool xa6d820670c5b3126;

		// Token: 0x04000053 RID: 83
		private bool x7487aed20df9e17f = true;

		// Token: 0x04000054 RID: 84
		private bool xdf12e581864b002b = true;

		// Token: 0x04000055 RID: 85
		private bool x4146cbcac48d3bf9 = true;

		// Token: 0x04000056 RID: 86
		private Rectangle x9ebf40bfdd2119aa;

		// Token: 0x04000057 RID: 87
		private BorderStyle xacfbd7a08ba56c78 = BorderStyle.Fixed3D;

		// Token: 0x04000058 RID: 88
		private BitArray x354fffdee23cf7e8;

		// Token: 0x04000059 RID: 89
		private InnerGrid x37d060cd2161032a;

		// Token: 0x0400005A RID: 90
		private GridRow x04dffc71a80ab21f;

		// Token: 0x0400005B RID: 91
		private ISandGridRenderer x38870620fd380a6b;

		// Token: 0x0400005C RID: 92
		private xf8f9565783602018 xac1c850120b1f254;

		// Token: 0x0400005D RID: 93
		private SandGridPrintDocument x057c142f95f8b1c5;

		// Token: 0x0400005E RID: 94
		private string x203ce404ab69af8d = string.Empty;

		// Token: 0x0400005F RID: 95
		private Color xdee25fc69e436817 = SystemColors.WindowText;

		// Token: 0x04000060 RID: 96
		private StringAlignment x66aa295ccf582978;

		// Token: 0x04000061 RID: 97
		internal bool xb41acd866d5cbca8;

		// Token: 0x04000062 RID: 98
		internal xbd7c5470fc89975b x266365ea27fa7af8;

		// Token: 0x04000063 RID: 99
		internal SortBox x5142973d45b32e92;

		// Token: 0x04000064 RID: 100
		private bool x8875b8c88ca272fe;

		// Token: 0x04000065 RID: 101
		private bool x5d6aaef53fbe3752;

		// Token: 0x04000066 RID: 102
		private int x0ea770202eaa7707;

		// Token: 0x04000067 RID: 103
		private int x7de459c2ab15ce67;

		// Token: 0x04000068 RID: 104
		private int x8c88fe45c4fcd635;

		// Token: 0x04000069 RID: 105
		private int x9ceba890ba6c5ad8;

		// Token: 0x0400006A RID: 106
		private ScrollOverflowBehavior x3961f7a13b8a640b;

		// Token: 0x0400006B RID: 107
		private ScrollOverflowBehavior xcca91a4264df67ff;

		// Token: 0x0400006C RID: 108
		private Timer xc833ec9e4d027a80;

		// Token: 0x0400006D RID: 109
		private Size x259e6cf08f9b90c9;

		// Token: 0x0400006E RID: 110
		private FocusableGridElement xfe52893ab2c061e1;

		// Token: 0x0400006F RID: 111
		private FocusableGridElement x9fde6943eed61cee;

		// Token: 0x04000070 RID: 112
		private string x0c5fbff028b27f44 = string.Empty;

		// Token: 0x04000071 RID: 113
		private Timer x64a0b0f7c755e76d;

		// Token: 0x04000072 RID: 114
		private bool x7e5e64c4ad8fb23a;

		// Token: 0x04000073 RID: 115
		private bool x45f8c9cde7f3dad0;

		// Token: 0x04000074 RID: 116
		private Timer x3ad0a3b3c3aaa928;

		// Token: 0x04000075 RID: 117
		private GridRow x67740018b77b66d4;

		// Token: 0x04000076 RID: 118
		private GridRow x978c6b33cd28725b;

		// Token: 0x04000077 RID: 119
		private GridColumn x623b7ba6ec850ac3;

		// Token: 0x04000078 RID: 120
		private GridColumn xb3bc11429dd30e9f;

		// Token: 0x04000079 RID: 121
		private Control xcc17d608c5279127;

		// Token: 0x0400007A RID: 122
		private Control xe11e365d7040675d;

		// Token: 0x0400007B RID: 123
		private xc93e236b29b23436 x05c32e8c9f289bfd;

		// Token: 0x0400007C RID: 124
		private bool x8c7b6df56a45ae90;

		// Token: 0x0400007D RID: 125
		private bool x7e2e7dab74ab56c8;

		// Token: 0x0400007E RID: 126
		private bool x1c4e749f6facc191;

		// Token: 0x0400007F RID: 127
		private bool xc80b7dfbe7643b3a;

		// Token: 0x04000080 RID: 128
		private KeyboardEditMode x6cb7f04b203e256c;

		// Token: 0x04000081 RID: 129
		private MouseEditMode x51dac887be599934;

		// Token: 0x04000082 RID: 130
		private bool x8944a87bbc8c2677;

		// Token: 0x04000083 RID: 131
		private bool x3178708748cb3aba;

		// Token: 0x04000084 RID: 132
		private SelectionChangedEventHandler x6d6f7a19a6e74243;

		// Token: 0x04000085 RID: 133
		private GridRowEventHandler xad878b8fb06f932a;

		// Token: 0x04000086 RID: 134
		private GridBeforeEditEventHandler xefbb6cf42d422ea8;

		// Token: 0x04000087 RID: 135
		private GridDataErrorEventHandler x8243a49d6586c7c2;

		// Token: 0x04000088 RID: 136
		private EventHandler xdee092d4d5407b26;

		// Token: 0x04000089 RID: 137
		private GridValueTransformingEventHandler x8288bc0ac4cb9718;

		// Token: 0x0400008A RID: 138
		private ItemDragEventHandler xcd7aaf1cbf93da25;

		// Token: 0x0400008B RID: 139
		private GridValueTransformingEventHandler xe74f7d8e320e196b;

		// Token: 0x0400008C RID: 140
		private GridAfterEditEventHandler xfd4ced7eb24170e8;

		// Token: 0x0400008D RID: 141
		private DataBindingCompleteEventHandler x5b2f9bb641183651;

		// Token: 0x0400008E RID: 142
		private GridChooseEditorEventHandler xf2b83307e5709e2b;

		// Token: 0x0400008F RID: 143
		private GridEventHandler xb467fb986553e233;

		// Token: 0x02000069 RID: 105
		// (Invoke) Token: 0x0600060A RID: 1546
		private delegate void x9e7d723c7953071c();
	}
}

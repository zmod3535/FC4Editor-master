using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.CompilerServices;
using Divelements.SandGrid.Design;
using Divelements.Util.Registration;

namespace Divelements.SandGrid
{
	// Token: 0x020000A1 RID: 161
	[LicenseProvider(typeof(x294bd621a33dc533))]
	[DefaultProperty("Columns")]
	[Designer(typeof(x0455fc60011a73cd))]
	[ToolboxBitmap(typeof(SandGrid))]
	public class SandGrid : SandGridBase
	{
		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000736 RID: 1846 RVA: 0x000250FC File Offset: 0x000240FC
		// (remove) Token: 0x06000737 RID: 1847 RVA: 0x00025118 File Offset: 0x00024118
		public event GridColumnEventHandler ColumnHeaderClick
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xad8e7dc2dc882784 = (GridColumnEventHandler)Delegate.Combine(this.xad8e7dc2dc882784, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xad8e7dc2dc882784 = (GridColumnEventHandler)Delegate.Remove(this.xad8e7dc2dc882784, value);
			}
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000738 RID: 1848 RVA: 0x00025134 File Offset: 0x00024134
		// (remove) Token: 0x06000739 RID: 1849 RVA: 0x00025150 File Offset: 0x00024150
		public event GridColumnEventHandler ColumnResized
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xca733367db4deb7d = (GridColumnEventHandler)Delegate.Combine(this.xca733367db4deb7d, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xca733367db4deb7d = (GridColumnEventHandler)Delegate.Remove(this.xca733367db4deb7d, value);
			}
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x0600073A RID: 1850 RVA: 0x0002516C File Offset: 0x0002416C
		// (remove) Token: 0x0600073B RID: 1851 RVA: 0x00025188 File Offset: 0x00024188
		public event GridRowExpandCollapseEventHandler BeforeExpand
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x46778e92d0bf0c7a = (GridRowExpandCollapseEventHandler)Delegate.Combine(this.x46778e92d0bf0c7a, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x46778e92d0bf0c7a = (GridRowExpandCollapseEventHandler)Delegate.Remove(this.x46778e92d0bf0c7a, value);
			}
		}

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x0600073C RID: 1852 RVA: 0x000251A4 File Offset: 0x000241A4
		// (remove) Token: 0x0600073D RID: 1853 RVA: 0x000251C0 File Offset: 0x000241C0
		public event GridRowExpandCollapseEventHandler BeforeCollapse
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x7b30a91924593611 = (GridRowExpandCollapseEventHandler)Delegate.Combine(this.x7b30a91924593611, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x7b30a91924593611 = (GridRowExpandCollapseEventHandler)Delegate.Remove(this.x7b30a91924593611, value);
			}
		}

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x0600073E RID: 1854 RVA: 0x000251DC File Offset: 0x000241DC
		// (remove) Token: 0x0600073F RID: 1855 RVA: 0x000251F8 File Offset: 0x000241F8
		public event GridRowExpandCollapseEventHandler AfterExpand
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x9d7ab1d6b0682a08 = (GridRowExpandCollapseEventHandler)Delegate.Combine(this.x9d7ab1d6b0682a08, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x9d7ab1d6b0682a08 = (GridRowExpandCollapseEventHandler)Delegate.Remove(this.x9d7ab1d6b0682a08, value);
			}
		}

		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000740 RID: 1856 RVA: 0x00025214 File Offset: 0x00024214
		// (remove) Token: 0x06000741 RID: 1857 RVA: 0x00025230 File Offset: 0x00024230
		public event GridRowExpandCollapseEventHandler AfterCollapse
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xc1e8dda2a8d4dd2a = (GridRowExpandCollapseEventHandler)Delegate.Combine(this.xc1e8dda2a8d4dd2a, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xc1e8dda2a8d4dd2a = (GridRowExpandCollapseEventHandler)Delegate.Remove(this.xc1e8dda2a8d4dd2a, value);
			}
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000742 RID: 1858 RVA: 0x0002524C File Offset: 0x0002424C
		// (remove) Token: 0x06000743 RID: 1859 RVA: 0x00025268 File Offset: 0x00024268
		public event GridRowCheckEventHandler BeforeCheck
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xcb3d1e1d62c83071 = (GridRowCheckEventHandler)Delegate.Combine(this.xcb3d1e1d62c83071, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xcb3d1e1d62c83071 = (GridRowCheckEventHandler)Delegate.Remove(this.xcb3d1e1d62c83071, value);
			}
		}

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000744 RID: 1860 RVA: 0x00025284 File Offset: 0x00024284
		// (remove) Token: 0x06000745 RID: 1861 RVA: 0x000252A0 File Offset: 0x000242A0
		public event GridRowCheckEventHandler AfterCheck
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xdc601ca0b0227f66 = (GridRowCheckEventHandler)Delegate.Combine(this.xdc601ca0b0227f66, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xdc601ca0b0227f66 = (GridRowCheckEventHandler)Delegate.Remove(this.xdc601ca0b0227f66, value);
			}
		}

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06000746 RID: 1862 RVA: 0x000252BC File Offset: 0x000242BC
		// (remove) Token: 0x06000747 RID: 1863 RVA: 0x000252D8 File Offset: 0x000242D8
		public event ElementsMovedEventHandler RowsMoved
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x53ab7257ec0b8cc5 = (ElementsMovedEventHandler)Delegate.Combine(this.x53ab7257ec0b8cc5, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x53ab7257ec0b8cc5 = (ElementsMovedEventHandler)Delegate.Remove(this.x53ab7257ec0b8cc5, value);
			}
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000748 RID: 1864 RVA: 0x000252F4 File Offset: 0x000242F4
		// (remove) Token: 0x06000749 RID: 1865 RVA: 0x00025310 File Offset: 0x00024310
		public event GridRowEventHandler PopulateVirtualRow
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.xdae501d522395db7 = (GridRowEventHandler)Delegate.Combine(this.xdae501d522395db7, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.xdae501d522395db7 = (GridRowEventHandler)Delegate.Remove(this.xdae501d522395db7, value);
			}
		}

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x0600074A RID: 1866 RVA: 0x0002532C File Offset: 0x0002432C
		// (remove) Token: 0x0600074B RID: 1867 RVA: 0x00025348 File Offset: 0x00024348
		public event EventHandler ColumnsReordered
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x310eaf8e6d1b03f7 = (EventHandler)Delegate.Combine(this.x310eaf8e6d1b03f7, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x310eaf8e6d1b03f7 = (EventHandler)Delegate.Remove(this.x310eaf8e6d1b03f7, value);
			}
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00025364 File Offset: 0x00024364
		public SandGrid()
		{
			this.x266365ea27fa7af8 = (xbd7c5470fc89975b)LicenseManager.Validate(typeof(SandGrid), this);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00025388 File Offset: 0x00024388
		protected internal override void OnPopulateVirtualRow(GridRowEventArgs e)
		{
			if (this.xdae501d522395db7 != null)
			{
				this.xdae501d522395db7(this, e);
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x000253A0 File Offset: 0x000243A0
		protected internal override void OnRowsMoved(ElementsMovedEventArgs e)
		{
			if (this.x53ab7257ec0b8cc5 != null)
			{
				this.x53ab7257ec0b8cc5(this, e);
			}
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x000253B8 File Offset: 0x000243B8
		protected internal override void OnBeforeCheck(GridRowCheckEventArgs e)
		{
			if (this.xcb3d1e1d62c83071 != null)
			{
				this.xcb3d1e1d62c83071(this, e);
			}
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x000253D0 File Offset: 0x000243D0
		protected internal override void OnAfterCheck(GridRowCheckEventArgs e)
		{
			if (this.xdc601ca0b0227f66 != null)
			{
				this.xdc601ca0b0227f66(this, e);
			}
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x000253E8 File Offset: 0x000243E8
		protected internal override void OnColumnHeaderClick(GridColumnEventArgs e)
		{
			if (this.xad8e7dc2dc882784 != null)
			{
				this.xad8e7dc2dc882784(this, e);
			}
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00025400 File Offset: 0x00024400
		protected internal override void OnColumnResized(GridColumnEventArgs e)
		{
			if (this.xca733367db4deb7d != null)
			{
				this.xca733367db4deb7d(this, e);
			}
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00025418 File Offset: 0x00024418
		protected internal override void OnColumnsReordered(EventArgs e)
		{
			if (this.x310eaf8e6d1b03f7 != null)
			{
				this.x310eaf8e6d1b03f7(this, e);
			}
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00025430 File Offset: 0x00024430
		protected internal override void OnBeforeExpand(GridRowExpandCollapseEventArgs e)
		{
			if (this.x46778e92d0bf0c7a != null)
			{
				this.x46778e92d0bf0c7a(this, e);
			}
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00025448 File Offset: 0x00024448
		protected internal override void OnBeforeCollapse(GridRowExpandCollapseEventArgs e)
		{
			if (this.x7b30a91924593611 != null)
			{
				this.x7b30a91924593611(this, e);
			}
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00025460 File Offset: 0x00024460
		protected internal override void OnAfterExpand(GridRowExpandCollapseEventArgs e)
		{
			if (this.x9d7ab1d6b0682a08 != null)
			{
				this.x9d7ab1d6b0682a08(this, e);
			}
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00025478 File Offset: 0x00024478
		protected internal override void OnAfterCollapse(GridRowExpandCollapseEventArgs e)
		{
			if (this.xc1e8dda2a8d4dd2a != null)
			{
				this.xc1e8dda2a8d4dd2a(this, e);
			}
		}

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x00025490 File Offset: 0x00024490
		[Editor(typeof(xf6e7622ac6314eae), typeof(UITypeEditor))]
		[Category("Data")]
		[Description("The columns into which data in the grid is divided.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public GridColumnCollection Columns
		{
			get
			{
				return base.PrimaryGrid.Columns;
			}
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x000254A0 File Offset: 0x000244A0
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x000254B0 File Offset: 0x000244B0
		[Description("Indicates what happens when the user clicks the mouse in whitespace.")]
		[DefaultValue(typeof(WhitespaceClickBehavior), "ClearSelection")]
		[Category("Selection")]
		public WhitespaceClickBehavior WhitespaceClickBehavior
		{
			get
			{
				return base.PrimaryGrid.WhitespaceClickBehavior;
			}
			set
			{
				base.PrimaryGrid.WhitespaceClickBehavior = value;
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x000254C0 File Offset: 0x000244C0
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x000254D0 File Offset: 0x000244D0
		[Category("Behavior")]
		[Description("Indicates how null values are detected and generated.")]
		[DefaultValue(typeof(NullBehavior), "DBNull")]
		public NullBehavior NullBehavior
		{
			get
			{
				return base.PrimaryGrid.NullBehavior;
			}
			set
			{
				base.PrimaryGrid.NullBehavior = value;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x000254E0 File Offset: 0x000244E0
		// (set) Token: 0x0600075E RID: 1886 RVA: 0x000254F0 File Offset: 0x000244F0
		[Description("Indicates what effect clicking on a group heading will have.")]
		[Category("Sorting and Grouping")]
		[DefaultValue(typeof(GroupHeadingClickBehavior), "None")]
		public GroupHeadingClickBehavior GroupHeadingClickBehavior
		{
			get
			{
				return base.PrimaryGrid.GroupHeadingClickBehavior;
			}
			set
			{
				base.PrimaryGrid.GroupHeadingClickBehavior = value;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00025500 File Offset: 0x00024500
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x00025510 File Offset: 0x00024510
		[Category("Appearance")]
		[Description("Specifies the string used to represent a null value in the grid.")]
		[DefaultValue("<NULL>")]
		public string NullRepresentation
		{
			get
			{
				return base.PrimaryGrid.NullRepresentation;
			}
			set
			{
				base.PrimaryGrid.NullRepresentation = value;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x00025520 File Offset: 0x00024520
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x00025530 File Offset: 0x00024530
		[Category("Behavior")]
		[Description("Specifies the behavior when the user clicks and drags on a cell.")]
		[DefaultValue(typeof(CellDragBehavior), "ExtendSelection")]
		public CellDragBehavior CellDragBehavior
		{
			get
			{
				return base.PrimaryGrid.CellDragBehavior;
			}
			set
			{
				base.PrimaryGrid.CellDragBehavior = value;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x06000763 RID: 1891 RVA: 0x00025540 File Offset: 0x00024540
		// (set) Token: 0x06000764 RID: 1892 RVA: 0x00025550 File Offset: 0x00024550
		[Category("Behavior")]
		[DefaultValue(typeof(ColumnClickBehavior), "SortAndReorder")]
		[Description("Specifies the behavior when the user clicks and drags on a column header.")]
		public ColumnClickBehavior ColumnClickBehavior
		{
			get
			{
				return base.PrimaryGrid.ColumnClickBehavior;
			}
			set
			{
				base.PrimaryGrid.ColumnClickBehavior = value;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x06000765 RID: 1893 RVA: 0x00025560 File Offset: 0x00024560
		// (set) Token: 0x06000766 RID: 1894 RVA: 0x00025570 File Offset: 0x00024570
		[Category("Virtual Mode")]
		[Description("Indicates the size of each row when virtual mode is enabled.")]
		public int VirtualRowSize
		{
			get
			{
				return base.PrimaryGrid.VirtualRowSize;
			}
			set
			{
				base.PrimaryGrid.VirtualRowSize = value;
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00025580 File Offset: 0x00024580
		private bool ShouldSerializeVirtualRowSize()
		{
			return this.VirtualRowSize != GridRow.x993356576cc2bf99;
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000768 RID: 1896 RVA: 0x00025594 File Offset: 0x00024594
		// (set) Token: 0x06000769 RID: 1897 RVA: 0x000255A4 File Offset: 0x000245A4
		[Description("Indicates how many rows are present when virtual mode is enabled.")]
		[Category("Virtual Mode")]
		[DefaultValue(0)]
		public int VirtualRowCount
		{
			get
			{
				return base.PrimaryGrid.VirtualRowCount;
			}
			set
			{
				base.PrimaryGrid.VirtualRowCount = value;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x000255B4 File Offset: 0x000245B4
		// (set) Token: 0x0600076B RID: 1899 RVA: 0x000255C4 File Offset: 0x000245C4
		[Description("If enabled, data is loaded on-demand and discarded when not needed.")]
		[DefaultValue(false)]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Virtual Mode")]
		public bool VirtualMode
		{
			get
			{
				return base.PrimaryGrid.VirtualMode;
			}
			set
			{
				base.PrimaryGrid.VirtualMode = value;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x000255D4 File Offset: 0x000245D4
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x000255E4 File Offset: 0x000245E4
		[Description("Indicates the effect of clicking and dragging on a row.")]
		[Category("Behavior")]
		[DefaultValue(typeof(RowDragBehavior), "ExtendSelection")]
		public RowDragBehavior RowDragBehavior
		{
			get
			{
				return base.PrimaryGrid.RowDragBehavior;
			}
			set
			{
				base.PrimaryGrid.RowDragBehavior = value;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x000255F4 File Offset: 0x000245F4
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x00025604 File Offset: 0x00024604
		[Category("Behavior")]
		[DefaultValue(false)]
		[Description("Indicates whether the user is able to resize rows in the grid.")]
		public bool AllowRowResize
		{
			get
			{
				return base.PrimaryGrid.AllowRowResize;
			}
			set
			{
				base.PrimaryGrid.AllowRowResize = value;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x00025614 File Offset: 0x00024614
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x00025624 File Offset: 0x00024624
		[Category("Selection")]
		[DefaultValue(true)]
		[Description("Indicates whether images in selected columns are drawn highlighted.")]
		public bool HighlightImages
		{
			get
			{
				return base.PrimaryGrid.HighlightImages;
			}
			set
			{
				base.PrimaryGrid.HighlightImages = value;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x00025634 File Offset: 0x00024634
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x0002563C File Offset: 0x0002463C
		[Description("Indicates how key presses can initiate an edit.")]
		[DefaultValue(typeof(KeyboardEditMode), "None")]
		[Category("Editing")]
		public KeyboardEditMode KeyboardEditMode
		{
			get
			{
				return base.KeyboardEditing;
			}
			set
			{
				base.KeyboardEditing = value;
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06000774 RID: 1908 RVA: 0x00025648 File Offset: 0x00024648
		// (set) Token: 0x06000775 RID: 1909 RVA: 0x00025650 File Offset: 0x00024650
		[Category("Editing")]
		[DefaultValue(typeof(MouseEditMode), "None")]
		[Description("Indicates how mouse actions can initiate an edit.")]
		public MouseEditMode MouseEditMode
		{
			get
			{
				return base.MouseEditing;
			}
			set
			{
				base.MouseEditing = value;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000776 RID: 1910 RVA: 0x0002565C File Offset: 0x0002465C
		// (set) Token: 0x06000777 RID: 1911 RVA: 0x0002566C File Offset: 0x0002466C
		[Description("Indicates whether the primary cell or the cell under the mouse cursor is edited on a row edit.")]
		[DefaultValue(typeof(RowEditMode), "PrimaryCell")]
		[Category("Editing")]
		public RowEditMode RowEditMode
		{
			get
			{
				return base.PrimaryGrid.RowEditMode;
			}
			set
			{
				base.PrimaryGrid.RowEditMode = value;
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000778 RID: 1912 RVA: 0x0002567C File Offset: 0x0002467C
		// (set) Token: 0x06000779 RID: 1913 RVA: 0x0002568C File Offset: 0x0002468C
		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether alternate rows are shaded for ease of reading.")]
		public bool ShadeAlternateRows
		{
			get
			{
				return base.PrimaryGrid.ShadeAlternateRows;
			}
			set
			{
				base.PrimaryGrid.ShadeAlternateRows = value;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x0002569C File Offset: 0x0002469C
		// (set) Token: 0x0600077B RID: 1915 RVA: 0x000256AC File Offset: 0x000246AC
		[Description("The separation between the image and text inside cells.")]
		[DefaultValue(3)]
		[Category("Appearance")]
		public int ImageTextSeparation
		{
			get
			{
				return base.PrimaryGrid.ImageTextSeparation;
			}
			set
			{
				base.PrimaryGrid.ImageTextSeparation = value;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x0600077C RID: 1916 RVA: 0x000256BC File Offset: 0x000246BC
		// (set) Token: 0x0600077D RID: 1917 RVA: 0x000256CC File Offset: 0x000246CC
		[Description("Indicates whether an entire row will be highlighted when selected.")]
		[Category("Selection")]
		[DefaultValue(typeof(RowHighlightType), "Partial")]
		public RowHighlightType RowHighlightType
		{
			get
			{
				return base.PrimaryGrid.RowHighlightType;
			}
			set
			{
				base.PrimaryGrid.RowHighlightType = value;
			}
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x000256DC File Offset: 0x000246DC
		// (set) Token: 0x0600077F RID: 1919 RVA: 0x000256E0 File Offset: 0x000246E0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("Use the GroupColumn property instead.")]
		public bool Group
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x000256E4 File Offset: 0x000246E4
		// (set) Token: 0x06000781 RID: 1921 RVA: 0x000256F4 File Offset: 0x000246F4
		[Category("Sorting and Grouping")]
		[DefaultValue(typeof(GridColumn), null)]
		[Description("The column to sort by.")]
		public GridColumn SortColumn
		{
			get
			{
				return base.PrimaryGrid.SortColumn;
			}
			set
			{
				base.PrimaryGrid.SortColumn = value;
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06000782 RID: 1922 RVA: 0x00025704 File Offset: 0x00024704
		// (set) Token: 0x06000783 RID: 1923 RVA: 0x00025714 File Offset: 0x00024714
		[Category("Sorting and Grouping")]
		[DefaultValue(typeof(ListSortDirection), "Ascending")]
		[Description("The type of sorting performed.")]
		public ListSortDirection SortDirection
		{
			get
			{
				return base.PrimaryGrid.SortDirection;
			}
			set
			{
				base.PrimaryGrid.SortDirection = value;
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x00025724 File Offset: 0x00024724
		// (set) Token: 0x06000785 RID: 1925 RVA: 0x00025734 File Offset: 0x00024734
		[Description("The column to group by.")]
		[DefaultValue(typeof(GridColumn), null)]
		[Category("Sorting and Grouping")]
		public GridColumn GroupColumn
		{
			get
			{
				return base.PrimaryGrid.GroupColumn;
			}
			set
			{
				base.PrimaryGrid.GroupColumn = value;
			}
		}

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x00025744 File Offset: 0x00024744
		// (set) Token: 0x06000787 RID: 1927 RVA: 0x00025754 File Offset: 0x00024754
		[Category("Sorting and Grouping")]
		[Description("The type of grouping performed.")]
		[DefaultValue(typeof(ListSortDirection), "Ascending")]
		public ListSortDirection GroupDirection
		{
			get
			{
				return base.PrimaryGrid.GroupDirection;
			}
			set
			{
				base.PrimaryGrid.GroupDirection = value;
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x00025764 File Offset: 0x00024764
		// (set) Token: 0x06000789 RID: 1929 RVA: 0x00025774 File Offset: 0x00024774
		[Category("Appearance")]
		[Description("Indicates how grid lines are displayed in the grid.")]
		[DefaultValue(typeof(GridLinesDisplayType), "None")]
		public GridLinesDisplayType GridLines
		{
			get
			{
				return base.PrimaryGrid.GridLines;
			}
			set
			{
				base.PrimaryGrid.GridLines = value;
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x00025784 File Offset: 0x00024784
		// (set) Token: 0x0600078B RID: 1931 RVA: 0x00025794 File Offset: 0x00024794
		[Category("Sorting and Grouping")]
		[Description("Indicates whether the user is able to collapse groups.")]
		[DefaultValue(false)]
		public bool AllowGroupCollapse
		{
			get
			{
				return base.PrimaryGrid.AllowGroupCollapse;
			}
			set
			{
				base.PrimaryGrid.AllowGroupCollapse = value;
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x000257A4 File Offset: 0x000247A4
		// (set) Token: 0x0600078D RID: 1933 RVA: 0x000257B4 File Offset: 0x000247B4
		[DefaultValue(19)]
		[Description("The amount, in pixels, to indent the contents of the primary column in nested rows.")]
		[Category("Behavior")]
		public int IndentationSize
		{
			get
			{
				return base.PrimaryGrid.IndentationSize;
			}
			set
			{
				base.PrimaryGrid.IndentationSize = value;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x000257C4 File Offset: 0x000247C4
		// (set) Token: 0x0600078F RID: 1935 RVA: 0x000257D4 File Offset: 0x000247D4
		[Description("Indicates whether lines are drawn to show the relationship of indented nodes.")]
		[DefaultValue(true)]
		[Category("Appearance")]
		public bool ShowTreeLines
		{
			get
			{
				return base.PrimaryGrid.ShowTreeLines;
			}
			set
			{
				base.PrimaryGrid.ShowTreeLines = value;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x000257E4 File Offset: 0x000247E4
		// (set) Token: 0x06000791 RID: 1937 RVA: 0x000257F4 File Offset: 0x000247F4
		[DefaultValue(true)]
		[Description("Indicates whether lines and buttons are drawn for the root items.")]
		[Category("Appearance")]
		public bool ShowRootLines
		{
			get
			{
				return base.PrimaryGrid.ShowRootLines;
			}
			set
			{
				base.PrimaryGrid.ShowRootLines = value;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x00025804 File Offset: 0x00024804
		// (set) Token: 0x06000793 RID: 1939 RVA: 0x00025814 File Offset: 0x00024814
		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether the expand button will be displayed for nested rows.")]
		public bool ShowTreeButtons
		{
			get
			{
				return base.PrimaryGrid.ShowTreeButtons;
			}
			set
			{
				base.PrimaryGrid.ShowTreeButtons = value;
			}
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x00025824 File Offset: 0x00024824
		// (set) Token: 0x06000795 RID: 1941 RVA: 0x00025834 File Offset: 0x00024834
		[Category("Selection")]
		[DefaultValue(typeof(SelectionGranularity), "Row")]
		[Description("The scope of selection allowed within the grid.")]
		public SelectionGranularity SelectionGranularity
		{
			get
			{
				return base.PrimaryGrid.SelectionGranularity;
			}
			set
			{
				base.PrimaryGrid.SelectionGranularity = value;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x00025844 File Offset: 0x00024844
		// (set) Token: 0x06000797 RID: 1943 RVA: 0x00025854 File Offset: 0x00024854
		[Category("Data")]
		[Description("The column in which the highlight for a row will start, and that will contain other primary data.")]
		public GridColumn PrimaryColumn
		{
			get
			{
				return base.PrimaryGrid.PrimaryColumn;
			}
			set
			{
				base.PrimaryGrid.PrimaryColumn = value;
			}
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00025864 File Offset: 0x00024864
		private bool ShouldSerializePrimaryColumn()
		{
			return this.PrimaryColumn != null && this.PrimaryColumn.Index != 0;
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000799 RID: 1945 RVA: 0x00025884 File Offset: 0x00024884
		// (set) Token: 0x0600079A RID: 1946 RVA: 0x00025894 File Offset: 0x00024894
		[DefaultValue(true)]
		[Category("Behavior")]
		[Description("Indicates whether a resize operation occurs in real time.")]
		public bool LiveResize
		{
			get
			{
				return base.PrimaryGrid.LiveResize;
			}
			set
			{
				base.PrimaryGrid.LiveResize = value;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x000258A4 File Offset: 0x000248A4
		// (set) Token: 0x0600079C RID: 1948 RVA: 0x000258B4 File Offset: 0x000248B4
		[Description("Indicates the width in pixels of row headers.")]
		[Category("Appearance")]
		[DefaultValue(20)]
		public int RowHeaderSize
		{
			get
			{
				return base.PrimaryGrid.RowHeaderSize;
			}
			set
			{
				base.PrimaryGrid.RowHeaderSize = value;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x000258C4 File Offset: 0x000248C4
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x000258D4 File Offset: 0x000248D4
		[DefaultValue(false)]
		[Category("Appearance")]
		[Description("Indicates whether Row headers are visible.")]
		public bool ShowRowHeaders
		{
			get
			{
				return base.PrimaryGrid.ShowRowHeaders;
			}
			set
			{
				base.PrimaryGrid.ShowRowHeaders = value;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x000258E4 File Offset: 0x000248E4
		// (set) Token: 0x060007A0 RID: 1952 RVA: 0x000258F4 File Offset: 0x000248F4
		[Description("Indicates whether column headers are visible.")]
		[DefaultValue(true)]
		[Category("Appearance")]
		public bool ShowColumnHeaders
		{
			get
			{
				return base.PrimaryGrid.ShowColumnHeaders;
			}
			set
			{
				base.PrimaryGrid.ShowColumnHeaders = value;
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x00025904 File Offset: 0x00024904
		// (set) Token: 0x060007A2 RID: 1954 RVA: 0x00025914 File Offset: 0x00024914
		[Description("Indicates what happens when a parent row is double-clicked.")]
		[DefaultValue(typeof(ParentRowDoubleClickBehavior), "ExpandCollapse")]
		[Category("Behavior")]
		public ParentRowDoubleClickBehavior ParentRowDoubleClick
		{
			get
			{
				return base.PrimaryGrid.ParentRowDoubleClick;
			}
			set
			{
				base.PrimaryGrid.ParentRowDoubleClick = value;
			}
		}

		// Token: 0x040002D1 RID: 721
		private GridColumnEventHandler xad8e7dc2dc882784;

		// Token: 0x040002D2 RID: 722
		private GridColumnEventHandler xca733367db4deb7d;

		// Token: 0x040002D3 RID: 723
		private GridRowExpandCollapseEventHandler x46778e92d0bf0c7a;

		// Token: 0x040002D4 RID: 724
		private GridRowExpandCollapseEventHandler x7b30a91924593611;

		// Token: 0x040002D5 RID: 725
		private GridRowExpandCollapseEventHandler x9d7ab1d6b0682a08;

		// Token: 0x040002D6 RID: 726
		private GridRowExpandCollapseEventHandler xc1e8dda2a8d4dd2a;

		// Token: 0x040002D7 RID: 727
		private GridRowCheckEventHandler xcb3d1e1d62c83071;

		// Token: 0x040002D8 RID: 728
		private GridRowCheckEventHandler xdc601ca0b0227f66;

		// Token: 0x040002D9 RID: 729
		private ElementsMovedEventHandler x53ab7257ec0b8cc5;

		// Token: 0x040002DA RID: 730
		private GridRowEventHandler xdae501d522395db7;

		// Token: 0x040002DB RID: 731
		private EventHandler x310eaf8e6d1b03f7;
	}
}

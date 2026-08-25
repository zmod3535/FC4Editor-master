using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Divelements.SandGrid.Design;
using Divelements.SandGrid.Specialized;
using Divelements.Util.Registration;

namespace Divelements.SandGrid
{
	// Token: 0x020000B4 RID: 180
	[DefaultProperty("Rows")]
	[Designer(typeof(xe72bc7a607f2a484))]
	[LicenseProvider(typeof(x294bd621a33dc533))]
	[ToolboxBitmap(typeof(SandTreeView))]
	public class SandTreeView : SandGridBase
	{
		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060007ED RID: 2029 RVA: 0x000266BC File Offset: 0x000256BC
		// (remove) Token: 0x060007EE RID: 2030 RVA: 0x000266D8 File Offset: 0x000256D8
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

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060007EF RID: 2031 RVA: 0x000266F4 File Offset: 0x000256F4
		// (remove) Token: 0x060007F0 RID: 2032 RVA: 0x00026710 File Offset: 0x00025710
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

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060007F1 RID: 2033 RVA: 0x0002672C File Offset: 0x0002572C
		// (remove) Token: 0x060007F2 RID: 2034 RVA: 0x00026748 File Offset: 0x00025748
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

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060007F3 RID: 2035 RVA: 0x00026764 File Offset: 0x00025764
		// (remove) Token: 0x060007F4 RID: 2036 RVA: 0x00026780 File Offset: 0x00025780
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

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x060007F5 RID: 2037 RVA: 0x0002679C File Offset: 0x0002579C
		// (remove) Token: 0x060007F6 RID: 2038 RVA: 0x000267B8 File Offset: 0x000257B8
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

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x060007F7 RID: 2039 RVA: 0x000267D4 File Offset: 0x000257D4
		// (remove) Token: 0x060007F8 RID: 2040 RVA: 0x000267F0 File Offset: 0x000257F0
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

		// Token: 0x060007F9 RID: 2041 RVA: 0x0002680C File Offset: 0x0002580C
		public SandTreeView()
		{
			this.x266365ea27fa7af8 = (xbd7c5470fc89975b)LicenseManager.Validate(typeof(SandTreeView), this);
			base.PrimaryGrid.WhitespaceClickBehavior = WhitespaceClickBehavior.None;
			base.PrimaryGrid.RowDragBehavior = RowDragBehavior.InitiateDragDrop;
			base.PrimaryGrid.HighlightImages = false;
			base.PrimaryGrid.RowHighlightType = RowHighlightType.PrimaryColumnOnly;
			base.PrimaryGrid.ShowTreeButtons = true;
			base.PrimaryGrid.ShowColumnHeaders = false;
			base.PrimaryGrid.NewRowType = typeof(SingleCellRow);
			GridColumn gridColumn = new xc410cede71ea7f97();
			gridColumn.AutoSize = ColumnAutoSizeMode.Contents;
			base.PrimaryGrid.Columns.Add(gridColumn);
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x000268B8 File Offset: 0x000258B8
		protected internal override void OnBeforeCheck(GridRowCheckEventArgs e)
		{
			if (this.xcb3d1e1d62c83071 != null)
			{
				this.xcb3d1e1d62c83071(this, e);
			}
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x000268D0 File Offset: 0x000258D0
		protected internal override void OnAfterCheck(GridRowCheckEventArgs e)
		{
			if (this.xdc601ca0b0227f66 != null)
			{
				this.xdc601ca0b0227f66(this, e);
			}
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x000268E8 File Offset: 0x000258E8
		protected internal override void OnBeforeExpand(GridRowExpandCollapseEventArgs e)
		{
			if (this.x46778e92d0bf0c7a != null)
			{
				this.x46778e92d0bf0c7a(this, e);
			}
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00026900 File Offset: 0x00025900
		protected internal override void OnBeforeCollapse(GridRowExpandCollapseEventArgs e)
		{
			if (this.x7b30a91924593611 != null)
			{
				this.x7b30a91924593611(this, e);
			}
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00026918 File Offset: 0x00025918
		protected internal override void OnAfterExpand(GridRowExpandCollapseEventArgs e)
		{
			if (this.x9d7ab1d6b0682a08 != null)
			{
				this.x9d7ab1d6b0682a08(this, e);
			}
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00026930 File Offset: 0x00025930
		protected internal override void OnAfterCollapse(GridRowExpandCollapseEventArgs e)
		{
			if (this.xc1e8dda2a8d4dd2a != null)
			{
				this.xc1e8dda2a8d4dd2a(this, e);
			}
		}

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x00026948 File Offset: 0x00025948
		// (set) Token: 0x06000801 RID: 2049 RVA: 0x00026950 File Offset: 0x00025950
		[DefaultValue(false)]
		[Description("Indicates whether the grid is editable.")]
		[Category("Behavior")]
		public bool AllowEdit
		{
			get
			{
				return this.x48fde6ec3ceda3c4;
			}
			set
			{
				this.x48fde6ec3ceda3c4 = value;
				if (this.AllowEdit)
				{
					base.KeyboardEditing = KeyboardEditMode.EditOnF2;
					base.MouseEditing = MouseEditMode.DelayedSingleClick;
					return;
				}
				base.KeyboardEditing = KeyboardEditMode.None;
				base.MouseEditing = MouseEditMode.None;
			}
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x00026980 File Offset: 0x00025980
		// (set) Token: 0x06000803 RID: 2051 RVA: 0x00026990 File Offset: 0x00025990
		[DefaultValue(19)]
		[Category("Behavior")]
		[Description("The amount, in pixels, to indent the contents of the primary column in nested rows.")]
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

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x000269A0 File Offset: 0x000259A0
		// (set) Token: 0x06000805 RID: 2053 RVA: 0x000269B0 File Offset: 0x000259B0
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

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x000269C0 File Offset: 0x000259C0
		// (set) Token: 0x06000807 RID: 2055 RVA: 0x000269D0 File Offset: 0x000259D0
		[Description("Indicates whether lines and buttons are drawn for the root items.")]
		[DefaultValue(true)]
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

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x000269E0 File Offset: 0x000259E0
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x000269F0 File Offset: 0x000259F0
		[DefaultValue(true)]
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

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x00026A00 File Offset: 0x00025A00
		// (set) Token: 0x0600080B RID: 2059 RVA: 0x00026A10 File Offset: 0x00025A10
		[Description("Indicates what happens when a parent row is double-clicked.")]
		[Category("Behavior")]
		[DefaultValue(typeof(ParentRowDoubleClickBehavior), "ExpandCollapse")]
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

		// Token: 0x040002ED RID: 749
		private bool x48fde6ec3ceda3c4;

		// Token: 0x040002EE RID: 750
		private GridRowExpandCollapseEventHandler x46778e92d0bf0c7a;

		// Token: 0x040002EF RID: 751
		private GridRowExpandCollapseEventHandler x7b30a91924593611;

		// Token: 0x040002F0 RID: 752
		private GridRowExpandCollapseEventHandler x9d7ab1d6b0682a08;

		// Token: 0x040002F1 RID: 753
		private GridRowExpandCollapseEventHandler xc1e8dda2a8d4dd2a;

		// Token: 0x040002F2 RID: 754
		private GridRowCheckEventHandler xcb3d1e1d62c83071;

		// Token: 0x040002F3 RID: 755
		private GridRowCheckEventHandler xdc601ca0b0227f66;
	}
}

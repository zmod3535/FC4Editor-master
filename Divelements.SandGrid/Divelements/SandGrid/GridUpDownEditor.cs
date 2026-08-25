using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x020000AE RID: 174
	[ToolboxItem(false)]
	public class GridUpDownEditor : NumericUpDown, IGridCellEditor
	{
		// Token: 0x060007D7 RID: 2007 RVA: 0x000263F0 File Offset: 0x000253F0
		public GridUpDownEditor()
		{
			base.Maximum = 2147483647m;
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00026408 File Offset: 0x00025408
		protected override void OnValueChanged(EventArgs e)
		{
			base.OnValueChanged(e);
			if (!this.xd923a0654aa3a626 && this.xaf05a2aec36f5b1b != null)
			{
				this.xaf05a2aec36f5b1b.EditorDirty = true;
				this.x98c88e18b643e747 = false;
			}
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x00026434 File Offset: 0x00025434
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			if (!this.xd923a0654aa3a626 && this.xaf05a2aec36f5b1b != null)
			{
				this.xaf05a2aec36f5b1b.EditorDirty = true;
				this.x98c88e18b643e747 = false;
			}
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x00026460 File Offset: 0x00025460
		void IGridCellEditor.x9dd3dbefcbe6db7a(SandGridBase x3040c866fac95193, GridRow xa806b754814b9ae0, GridColumn xe3e287548b3d01f5)
		{
			this.xaf05a2aec36f5b1b = x3040c866fac95193;
			this.xea3c8343b62caf05 = xa806b754814b9ae0.Grid;
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00026478 File Offset: 0x00025478
		void IGridCellEditor.x62c1117758181553(bool x7fe3c744bc3a2b2e)
		{
			if (x7fe3c744bc3a2b2e)
			{
				base.Select(0, this.Text.Length);
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x060007DC RID: 2012 RVA: 0x00026490 File Offset: 0x00025490
		// (set) Token: 0x060007DD RID: 2013 RVA: 0x000264B4 File Offset: 0x000254B4
		object IGridCellEditor.xaed44d7389b8f5bf
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
				if (this.xea3c8343b62caf05.xfb724cf23e069ca8(value))
				{
					this.x98c88e18b643e747 = true;
					this.Text = "";
				}
				else
				{
					try
					{
						base.Value = Convert.ToDecimal(value);
						this.x98c88e18b643e747 = false;
					}
					catch
					{
						this.Text = "";
						this.x98c88e18b643e747 = true;
					}
				}
				this.xd923a0654aa3a626 = false;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x060007DE RID: 2014 RVA: 0x00026538 File Offset: 0x00025538
		BorderStyle IGridCellEditor.x70b35015ecd64e0b
		{
			get
			{
				return BorderStyle.None;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x0002653C File Offset: 0x0002553C
		Type IGridCellEditor.xdb3964e08d23d65b
		{
			get
			{
				return typeof(decimal);
			}
		}

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x060007E0 RID: 2016 RVA: 0x00026548 File Offset: 0x00025548
		int IGridCellEditor.xe8076f1bb0b28ea2
		{
			get
			{
				return base.PreferredHeight;
			}
		}

		// Token: 0x040002DD RID: 733
		private SandGridBase xaf05a2aec36f5b1b;

		// Token: 0x040002DE RID: 734
		private InnerGrid xea3c8343b62caf05;

		// Token: 0x040002DF RID: 735
		private bool xd923a0654aa3a626;

		// Token: 0x040002E0 RID: 736
		private bool x98c88e18b643e747;
	}
}

using System;
using System.ComponentModel;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200009E RID: 158
	public class GridFileSizeColumn : GridColumn<long>
	{
		// Token: 0x06000717 RID: 1815 RVA: 0x00023978 File Offset: 0x00022978
		public GridFileSizeColumn()
		{
			base.DataFormatString = "{0:n0} KB";
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x000239F0 File Offset: 0x000229F0
		public GridFileSizeColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00023A60 File Offset: 0x00022A60
		private void xaf6658d63fcb6e74()
		{
			if (base.Grid != null && base.Grid.Rows.xa5dcc13c31b2d66e(this))
			{
				base.Grid.Rows.x392c4e6c2fa28c2b();
			}
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00023A90 File Offset: 0x00022A90
		protected override object FormatValue(object rawValue, Type desiredType)
		{
			if (!(rawValue is long))
			{
				return null;
			}
			long value = (long)rawValue;
			return base.FormatValue((long)Math.Ceiling(value / 1024m), desiredType);
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x00023ADC File Offset: 0x00022ADC
		protected override string GetGroupHeadingText(GridRow row)
		{
			object cellValue = row.GetCellValue(this);
			long num;
			try
			{
				num = Convert.ToInt64(cellValue);
			}
			catch
			{
				return string.Empty;
			}
			if (num == 0L)
			{
				return this.xa8eae4367bb7094f;
			}
			if (num < (long)this.xbfadc657e978e800)
			{
				return this.x0b4d874152a3f7ad;
			}
			if (num < (long)this.x088cf84791b81573)
			{
				return this.x34bfc7ff1fc3e22b;
			}
			if (num < (long)this.x2d069f88a81448c2)
			{
				return this.xc63964fe3fa24c54;
			}
			return this.x31dc650a01bc4594;
		}

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x00023B68 File Offset: 0x00022B68
		// (set) Token: 0x0600071D RID: 1821 RVA: 0x00023B70 File Offset: 0x00022B70
		[DefaultValue(1024)]
		[Category("Grouping")]
		[Description("The threshold at which a value starts being classified as Small.")]
		public int SmallThreshold
		{
			get
			{
				return this.xbfadc657e978e800;
			}
			set
			{
				this.xbfadc657e978e800 = value;
				this.xaf6658d63fcb6e74();
			}
		}

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00023B80 File Offset: 0x00022B80
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x00023B88 File Offset: 0x00022B88
		[Description("The threshold at which a value starts being classified as Medium.")]
		[DefaultValue(131072)]
		[Category("Grouping")]
		public int MediumThreshold
		{
			get
			{
				return this.x088cf84791b81573;
			}
			set
			{
				this.x088cf84791b81573 = value;
				this.xaf6658d63fcb6e74();
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x00023B98 File Offset: 0x00022B98
		// (set) Token: 0x06000721 RID: 1825 RVA: 0x00023BA0 File Offset: 0x00022BA0
		[DefaultValue(1048576)]
		[Category("Grouping")]
		[Description("The threshold at which a value starts being classified as Large.")]
		public int LargeThreshold
		{
			get
			{
				return this.x2d069f88a81448c2;
			}
			set
			{
				this.x2d069f88a81448c2 = value;
				this.xaf6658d63fcb6e74();
			}
		}

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x00023BB0 File Offset: 0x00022BB0
		// (set) Token: 0x06000723 RID: 1827 RVA: 0x00023BB8 File Offset: 0x00022BB8
		[Localizable(true)]
		[Description("The text to display for the Zero group.")]
		[DefaultValue("Zero")]
		[Category("Grouping")]
		public string ZeroText
		{
			get
			{
				return this.xa8eae4367bb7094f;
			}
			set
			{
				this.xa8eae4367bb7094f = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x00023BC8 File Offset: 0x00022BC8
		// (set) Token: 0x06000725 RID: 1829 RVA: 0x00023BD0 File Offset: 0x00022BD0
		[Localizable(true)]
		[DefaultValue("Tiny")]
		[Description("The text to display for the Tiny group.")]
		[Category("Grouping")]
		public string TinyText
		{
			get
			{
				return this.x0b4d874152a3f7ad;
			}
			set
			{
				this.x0b4d874152a3f7ad = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x00023BE0 File Offset: 0x00022BE0
		// (set) Token: 0x06000727 RID: 1831 RVA: 0x00023BE8 File Offset: 0x00022BE8
		[DefaultValue("Small")]
		[Description("The text to display for the Small group.")]
		[Category("Grouping")]
		[Localizable(true)]
		public string SmallText
		{
			get
			{
				return this.x34bfc7ff1fc3e22b;
			}
			set
			{
				this.x34bfc7ff1fc3e22b = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00023BF8 File Offset: 0x00022BF8
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x00023C00 File Offset: 0x00022C00
		[DefaultValue("Medium")]
		[Description("The text to display for the Medium group.")]
		[Category("Grouping")]
		[Localizable(true)]
		public string MediumText
		{
			get
			{
				return this.xc63964fe3fa24c54;
			}
			set
			{
				this.xc63964fe3fa24c54 = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x00023C10 File Offset: 0x00022C10
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x00023C18 File Offset: 0x00022C18
		[Category("Grouping")]
		[Description("The text to display for the Large group.")]
		[Localizable(true)]
		[DefaultValue("Large")]
		public string LargeText
		{
			get
			{
				return this.x31dc650a01bc4594;
			}
			set
			{
				this.x31dc650a01bc4594 = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x040002B8 RID: 696
		private string xa8eae4367bb7094f = "Zero";

		// Token: 0x040002B9 RID: 697
		private string x0b4d874152a3f7ad = "Tiny";

		// Token: 0x040002BA RID: 698
		private string x34bfc7ff1fc3e22b = "Small";

		// Token: 0x040002BB RID: 699
		private string xc63964fe3fa24c54 = "Medium";

		// Token: 0x040002BC RID: 700
		private string x31dc650a01bc4594 = "Large";

		// Token: 0x040002BD RID: 701
		private int xbfadc657e978e800 = 32768;

		// Token: 0x040002BE RID: 702
		private int x088cf84791b81573 = 131072;

		// Token: 0x040002BF RID: 703
		private int x2d069f88a81448c2 = 1048576;
	}
}

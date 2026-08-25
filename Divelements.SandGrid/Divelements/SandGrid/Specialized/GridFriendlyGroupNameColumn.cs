using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing.Design;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200009F RID: 159
	public class GridFriendlyGroupNameColumn : GridIntegerColumn
	{
		// Token: 0x0600072C RID: 1836 RVA: 0x00023C28 File Offset: 0x00022C28
		public GridFriendlyGroupNameColumn()
		{
			this.xf1992da7aa363514 = new StringCollection();
			base.Visible = false;
		}

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x00023C44 File Offset: 0x00022C44
		[Editor("System.Windows.Forms.Design.StringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[Localizable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public StringCollection GroupNames
		{
			get
			{
				return this.xf1992da7aa363514;
			}
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00023C4C File Offset: 0x00022C4C
		protected override string GetGroupHeadingText(GridRow row)
		{
			return this.x10be2c35531edd18(row.GetCellValue(this));
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00023C5C File Offset: 0x00022C5C
		protected override object FormatValue(object value, Type desiredType)
		{
			if (desiredType == typeof(string))
			{
				return this.x10be2c35531edd18(value);
			}
			return base.FormatValue(value, desiredType);
		}

		// Token: 0x06000730 RID: 1840 RVA: 0x00023C7C File Offset: 0x00022C7C
		private string x10be2c35531edd18(object x4149da615f3c2e14)
		{
			if (x4149da615f3c2e14 is int)
			{
				int num = (int)x4149da615f3c2e14;
				if (num >= 0 && num < this.xf1992da7aa363514.Count)
				{
					return this.xf1992da7aa363514[num];
				}
			}
			return string.Empty;
		}

		// Token: 0x040002C0 RID: 704
		private StringCollection xf1992da7aa363514;
	}
}

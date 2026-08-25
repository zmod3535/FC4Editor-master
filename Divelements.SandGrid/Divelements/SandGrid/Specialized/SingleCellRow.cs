using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x020000AD RID: 173
	[TypeConverter(typeof(xd732e68b9b10f6f8))]
	public class SingleCellRow : GridRow
	{
		// Token: 0x060007D1 RID: 2001 RVA: 0x000262EC File Offset: 0x000252EC
		public SingleCellRow()
		{
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x000262F4 File Offset: 0x000252F4
		public SingleCellRow(string text, Image image)
		{
			GridCell gridCell = new GridCell();
			gridCell.Text = text;
			gridCell.Image = image;
			base.Cells.Add(gridCell);
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x060007D3 RID: 2003 RVA: 0x00026328 File Offset: 0x00025328
		// (set) Token: 0x060007D4 RID: 2004 RVA: 0x00026358 File Offset: 0x00025358
		[DefaultValue("")]
		[Localizable(true)]
		[Description("The text in the row.")]
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[Category("Appearance")]
		public string Text
		{
			get
			{
				if (base.Cells.Count != 0)
				{
					return base.Cells[0].Text;
				}
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionSingleCell"));
			}
			set
			{
				if (base.Cells.Count != 0)
				{
					base.Cells[0].Text = value;
					return;
				}
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionSingleCell"));
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x060007D5 RID: 2005 RVA: 0x0002638C File Offset: 0x0002538C
		// (set) Token: 0x060007D6 RID: 2006 RVA: 0x000263BC File Offset: 0x000253BC
		[DefaultValue(typeof(Image), null)]
		[Category("Appearance")]
		[Description("The image to display in the row.")]
		[AmbientValue(typeof(Image), null)]
		public Image Image
		{
			get
			{
				if (base.Cells.Count != 0)
				{
					return base.Cells[0].Image;
				}
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionSingleCell"));
			}
			set
			{
				if (base.Cells.Count != 0)
				{
					base.Cells[0].Image = value;
					return;
				}
				throw new InvalidOperationException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionSingleCell"));
			}
		}
	}
}

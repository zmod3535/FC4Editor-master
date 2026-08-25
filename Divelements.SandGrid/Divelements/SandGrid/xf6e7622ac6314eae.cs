using System;
using System.ComponentModel.Design;
using Divelements.SandGrid.Specialized;

namespace Divelements.SandGrid
{
	// Token: 0x02000088 RID: 136
	internal class xf6e7622ac6314eae : CollectionEditor
	{
		// Token: 0x06000662 RID: 1634 RVA: 0x00021AD8 File Offset: 0x00020AD8
		public xf6e7622ac6314eae(Type type) : base(type)
		{
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x00021AE4 File Offset: 0x00020AE4
		protected override Type[] CreateNewItemTypes()
		{
			return new Type[]
			{
				typeof(GridColumn),
				typeof(GridIntegerColumn),
				typeof(GridDoubleColumn),
				typeof(GridDateTimeColumn),
				typeof(GridBooleanColumn),
				typeof(GridDecimalColumn),
				typeof(GridConditionalImageColumn),
				typeof(GridForeignKeyColumn),
				typeof(GridProgressBarColumn),
				typeof(GridButtonColumn),
				typeof(GridHyperlinkColumn),
				typeof(GridCheckBoxColumn),
				typeof(GridFileSizeColumn),
				typeof(GridImageColumn),
				typeof(GridFriendlyGroupNameColumn)
			};
		}
	}
}

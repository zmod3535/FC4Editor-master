using System;
using System.ComponentModel;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x0200008D RID: 141
	public class GridDateTimeColumn : TypedGridColumn
	{
		// Token: 0x06000678 RID: 1656 RVA: 0x00021D44 File Offset: 0x00020D44
		public GridDateTimeColumn()
		{
			base.DataFormatString = "{0:d}";
			base.EditorType = typeof(GridDateTimeEditor);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x00021D68 File Offset: 0x00020D68
		public GridDateTimeColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x00021D74 File Offset: 0x00020D74
		// (set) Token: 0x0600067B RID: 1659 RVA: 0x00021D7C File Offset: 0x00020D7C
		[DefaultValue(false)]
		[Category("Behavior")]
		[Description("When set to true, enables a secondary sort to be applied after dates in the column have been grouped.")]
		public bool EnableSortWithinGroup
		{
			get
			{
				return this.xd07a7aa0583ada73;
			}
			set
			{
				if (value != this.xd07a7aa0583ada73)
				{
					this.xd07a7aa0583ada73 = value;
					if (base.Grid != null && base.Grid.Rows.xa5dcc13c31b2d66e(this))
					{
						base.Grid.Rows.x392c4e6c2fa28c2b();
					}
				}
			}
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x00021DBC File Offset: 0x00020DBC
		public override GridCell CreateCell()
		{
			return new GridDateTimeCell();
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x00021DC4 File Offset: 0x00020DC4
		public override Type DataType
		{
			get
			{
				return typeof(DateTime);
			}
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x00021DD0 File Offset: 0x00020DD0
		protected internal override IComparable GetGroupedValueForSorting(IComparable rawValue)
		{
			if (!this.EnableSortWithinGroup || !(rawValue is DateTime))
			{
				return rawValue;
			}
			DateTime t = (DateTime)rawValue;
			DateTime t2 = DateTime.Now.Date.AddDays((double)(-(double)DateTime.Now.DayOfWeek));
			if (t >= DateTime.Now.Date + new TimeSpan(2, 0, 0, 0))
			{
				return DateTime.Now.Date + new TimeSpan(2, 0, 0, 0);
			}
			if (t < t2.AddDays(-14.0))
			{
				return t2.AddDays(-15.0);
			}
			if (t < t2.AddDays(-7.0))
			{
				return t2.AddDays(-8.0);
			}
			if (t < t2)
			{
				return t2.AddDays(-1.0);
			}
			return t.Date;
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x00021EEC File Offset: 0x00020EEC
		protected override string GetGroupHeadingText(GridRow row)
		{
			object cellValue = row.GetCellValue(this);
			if (!(cellValue is DateTime))
			{
				return "";
			}
			DateTime t = (DateTime)cellValue;
			DateTime t2 = DateTime.Now.Date.AddDays((double)(-(double)DateTime.Now.DayOfWeek));
			if (t >= DateTime.Now.Date + new TimeSpan(2, 0, 0, 0))
			{
				return SandGridLanguage.FriendlyDates[0];
			}
			if (t >= DateTime.Now.Date + new TimeSpan(1, 0, 0, 0))
			{
				return SandGridLanguage.FriendlyDates[6];
			}
			if (t >= DateTime.Now.Date)
			{
				return SandGridLanguage.FriendlyDates[1];
			}
			if (t >= DateTime.Now.Date - new TimeSpan(1, 0, 0, 0))
			{
				return SandGridLanguage.FriendlyDates[2];
			}
			if (t >= t2)
			{
				return t.ToString("dddd");
			}
			if (t >= t2.AddDays(-7.0))
			{
				return SandGridLanguage.FriendlyDates[3];
			}
			if (t >= t2.AddDays(-14.0))
			{
				return SandGridLanguage.FriendlyDates[4];
			}
			return SandGridLanguage.FriendlyDates[5];
		}

		// Token: 0x04000294 RID: 660
		private bool xd07a7aa0583ada73;
	}
}

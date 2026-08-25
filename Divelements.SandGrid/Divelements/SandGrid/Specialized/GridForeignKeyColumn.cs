using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Divelements.SandGrid.Specialized
{
	// Token: 0x02000094 RID: 148
	public class GridForeignKeyColumn : GridColumn
	{
		// Token: 0x060006AF RID: 1711 RVA: 0x000226B8 File Offset: 0x000216B8
		public GridForeignKeyColumn()
		{
			base.EditorType = typeof(GridComboBoxEditor);
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x00022708 File Offset: 0x00021708
		public GridForeignKeyColumn(string text, int width) : base(text, width)
		{
			base.EditorType = typeof(GridComboBoxEditor);
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0002275C File Offset: 0x0002175C
		protected internal override NameValuePair[] GetSuggestedValues()
		{
			if (base.IsDataBound)
			{
				DataSet dataSet = this.x2ae3b1ddbc17cb11();
				if (dataSet != null)
				{
					DataTable dataTable = dataSet.Tables[this.PrimaryKeyTable];
					if (dataTable != null && dataTable.PrimaryKey != null && dataTable.PrimaryKey.Length == 1)
					{
						DataRow[] array = dataTable.Select(this.FilterExpression, this.SortExpression);
						NameValuePair[] array2 = new NameValuePair[array.Length];
						for (int i = 0; i < array.Length; i++)
						{
							array2[i] = new NameValuePair(array[i][this.ColumnName], array[i][dataTable.PrimaryKey[0]]);
						}
						return array2;
					}
				}
			}
			return base.GetSuggestedValues();
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00022808 File Offset: 0x00021808
		private DataSet x2ae3b1ddbc17cb11()
		{
			if (base.IsDataBound)
			{
				DataView dataView = base.Grid.x0f405f185e70ec01.x06ca69422bbb7502 as DataView;
				if (dataView != null)
				{
					return dataView.Table.DataSet;
				}
				BindingSource bindingSource = base.Grid.x0f405f185e70ec01.x06ca69422bbb7502 as BindingSource;
				if (bindingSource != null)
				{
					dataView = (bindingSource.List as DataView);
					if (dataView != null)
					{
						return dataView.Table.DataSet;
					}
				}
			}
			return null;
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00022878 File Offset: 0x00021878
		protected override object FormatValue(object originalValue, Type desiredType)
		{
			if (base.IsDataBound && desiredType == typeof(string))
			{
				DataSet dataSet = this.x2ae3b1ddbc17cb11();
				if (dataSet != null)
				{
					DataTable dataTable = dataSet.Tables[this.PrimaryKeyTable];
					if (dataTable != null)
					{
						DataRow dataRow = dataTable.Rows.Find(originalValue);
						if (dataRow != null)
						{
							return dataRow[this.ColumnName];
						}
					}
				}
			}
			return base.FormatValue(originalValue, desiredType);
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x000228E0 File Offset: 0x000218E0
		protected override object ParseValue(GridRow row, object formattedValue, Type desiredType)
		{
			if (base.IsDataBound && formattedValue is string)
			{
				DataSet dataSet = this.x2ae3b1ddbc17cb11();
				if (dataSet != null)
				{
					DataTable dataTable = dataSet.Tables[this.PrimaryKeyTable];
					if (dataTable != null && dataTable.PrimaryKey != null && dataTable.PrimaryKey.Length == 1)
					{
						string text = formattedValue as string;
						text = text.Replace("'", "''");
						DataRow[] array = dataTable.Select(this.ColumnName + " = '" + text + "'");
						if (array.Length != 0)
						{
							return array[0][dataTable.PrimaryKey[0]];
						}
					}
				}
			}
			return base.ParseValue(row, formattedValue, desiredType);
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x060006B5 RID: 1717 RVA: 0x0002298C File Offset: 0x0002198C
		// (set) Token: 0x060006B6 RID: 1718 RVA: 0x00022994 File Offset: 0x00021994
		[Category("Data")]
		[DefaultValue("")]
		[Description("The sort expression to apply when selecting valid values for fields.")]
		public string SortExpression
		{
			get
			{
				return this.x590f486d397a6931;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x590f486d397a6931 = value;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x000229A8 File Offset: 0x000219A8
		// (set) Token: 0x060006B8 RID: 1720 RVA: 0x000229B0 File Offset: 0x000219B0
		[Category("Data")]
		[DefaultValue("")]
		[Description("The filter to apply when selecting valid values for fields.")]
		public string FilterExpression
		{
			get
			{
				return this.x58e1a4f75a6a1ca6;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x58e1a4f75a6a1ca6 = value;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x000229C4 File Offset: 0x000219C4
		// (set) Token: 0x060006BA RID: 1722 RVA: 0x000229CC File Offset: 0x000219CC
		[Description("The name of the column whose value should be looked based on a primary key value in this column.")]
		[Category("Data")]
		[DefaultValue("")]
		public string ColumnName
		{
			get
			{
				return this.x59ee5b80c99ccc1a;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x59ee5b80c99ccc1a = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x000229E8 File Offset: 0x000219E8
		// (set) Token: 0x060006BC RID: 1724 RVA: 0x000229F0 File Offset: 0x000219F0
		[DefaultValue("")]
		[Description("The name of the table that holds the primary key.")]
		[Category("Data")]
		public string PrimaryKeyTable
		{
			get
			{
				return this.x8009ebca7654af7f;
			}
			set
			{
				if (value == null)
				{
					value = string.Empty;
				}
				this.x8009ebca7654af7f = value;
				base.RedrawNeeded(true);
			}
		}

		// Token: 0x040002A1 RID: 673
		private string x8009ebca7654af7f = string.Empty;

		// Token: 0x040002A2 RID: 674
		private string x59ee5b80c99ccc1a = string.Empty;

		// Token: 0x040002A3 RID: 675
		private string x58e1a4f75a6a1ca6 = string.Empty;

		// Token: 0x040002A4 RID: 676
		private string x590f486d397a6931 = string.Empty;
	}
}

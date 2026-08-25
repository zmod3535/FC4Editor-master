using System;
using System.Collections;
using System.Reflection;
using System.Text;
using Divelements.SandGrid.Resources;

namespace Divelements.SandGrid
{
	// Token: 0x02000085 RID: 133
	public sealed class DataUtilities
	{
		// Token: 0x0600064F RID: 1615 RVA: 0x00021224 File Offset: 0x00020224
		private DataUtilities()
		{
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0002122C File Offset: 0x0002022C
		public static void BindToClassInstances(SandGridBase grid, ICollection instances, Type gridRowType)
		{
			DataUtilities.BindToClassInstances(grid, instances, gridRowType, null);
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x00021238 File Offset: 0x00020238
		public static void BindToClassInstances(SandGridBase grid, ICollection instances, Type gridRowType, string recursionProperty)
		{
			if (grid == null)
			{
				throw new ArgumentNullException("grid");
			}
			if (instances == null)
			{
				throw new ArgumentNullException("instances");
			}
			if (gridRowType == null)
			{
				throw new ArgumentNullException("gridRowType");
			}
			if (!gridRowType.IsSubclassOf(typeof(GridRow)))
			{
				throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionTypeNotGridRow"), "gridRowType");
			}
			if (instances.Count == 0)
			{
				grid.Rows.Clear();
				return;
			}
			Type type = null;
			IEnumerator enumerator = instances.GetEnumerator();
			if (enumerator.MoveNext())
			{
				type = enumerator.Current.GetType();
			}
			if (enumerator is IDisposable)
			{
				((IDisposable)enumerator).Dispose();
				if (false)
				{
					goto IL_9D;
				}
			}
			if (gridRowType.GetConstructor(new Type[]
			{
				type
			}) == null)
			{
				throw new ArgumentException("The specified type does not have a constructor that accepts an instance of " + type.Name + ".", "gridRowType");
			}
			PropertyInfo propertyInfo = null;
			if (recursionProperty != null && recursionProperty.Length != 0)
			{
				propertyInfo = type.GetProperty(recursionProperty, BindingFlags.Instance | BindingFlags.Public);
				if (propertyInfo == null)
				{
					goto IL_9D;
				}
			}
			grid.Rows.Clear();
			DataUtilities.x4ce31f3ca26b1146(grid.Rows, instances, gridRowType, propertyInfo);
			return;
			IL_9D:
			throw new ArgumentException("The specified property does not exist on the object type.", "recursionProperty");
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0002136C File Offset: 0x0002036C
		private static void x4ce31f3ca26b1146(GridRowCollection x2eb5785cf1641b8b, ICollection x5e10a71d1b600fc4, Type xc653793824036903, PropertyInfo x175b92e995b3d7ad)
		{
			GridRow[] array = new GridRow[x5e10a71d1b600fc4.Count];
			int num = 0;
			foreach (object obj in x5e10a71d1b600fc4)
			{
				GridRow gridRow = (GridRow)Activator.CreateInstance(xc653793824036903, new object[]
				{
					obj
				});
				if (x175b92e995b3d7ad != null)
				{
					ICollection collection = x175b92e995b3d7ad.GetValue(obj, null) as ICollection;
					if (collection != null)
					{
						DataUtilities.x4ce31f3ca26b1146(gridRow.NestedRows, collection, xc653793824036903, x175b92e995b3d7ad);
					}
				}
				array[num++] = gridRow;
			}
			x2eb5785cf1641b8b.AddRange(array);
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x00021424 File Offset: 0x00020424
		[Obsolete("Call ExportToDelimitedText directly instead, passing DelimitedDataExportSettings.Csv.")]
		public static string ExportToCsv(InnerGrid grid)
		{
			return DataUtilities.ExportToDelimitedText(grid, DelimitedDataExportSettings.Csv, true);
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x00021434 File Offset: 0x00020434
		public static string ExportToDelimitedText(InnerGrid grid, DelimitedDataExportSettings settings, bool includeColumnHeaders)
		{
			if (grid == null)
			{
				throw new ArgumentNullException("grid");
			}
			if (settings == null)
			{
				throw new ArgumentNullException("settings");
			}
			StringBuilder stringBuilder = new StringBuilder();
			int i;
			if (includeColumnHeaders)
			{
				int num = 0;
				GridColumn[] displayColumns = grid.Columns.DisplayColumns;
				for (i = 0; i < displayColumns.Length; i++)
				{
					GridColumn gridColumn = displayColumns[i];
					stringBuilder.Append(settings.StringQualifier + gridColumn.HeaderText + settings.StringQualifier);
					num++;
					if (num < grid.Columns.DisplayColumns.Length)
					{
						stringBuilder.Append(settings.Delimiter);
					}
				}
				stringBuilder.Append(Environment.NewLine);
			}
			using (IEnumerator enumerator = grid.FlatVisibleRows.GetEnumerator())
			{
				for (;;)
				{
					GridRow gridRow;
					int num2;
					GridColumn[] displayColumns2;
					if (!enumerator.MoveNext())
					{
						bool flag;
						if ((flag ? 1U : 0U) - (uint)i <= 4294967295U)
						{
							break;
						}
					}
					else
					{
						gridRow = (GridRow)enumerator.Current;
						num2 = 0;
						displayColumns2 = grid.Columns.DisplayColumns;
					}
					foreach (GridColumn gridColumn2 in displayColumns2)
					{
						object cellValue = gridRow.GetCellValue(gridColumn2);
						if (!grid.xfb724cf23e069ca8(cellValue))
						{
							bool flag = settings.UseStringQualifierWhenValueIsString && cellValue is string;
							string text = gridColumn2.xf69eb59aa621a379(gridRow, cellValue, typeof(string)) as string;
							if (text != null)
							{
								if (flag || text.IndexOf(settings.Delimiter) != -1 || text.IndexOf(Environment.NewLine) != -1)
								{
									stringBuilder.Append(settings.StringQualifier + text + settings.StringQualifier);
								}
								else
								{
									stringBuilder.Append(text);
								}
							}
						}
						num2++;
						if (num2 < grid.Columns.DisplayColumns.Length)
						{
							stringBuilder.Append(settings.Delimiter);
						}
					}
					stringBuilder.Append(Environment.NewLine);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x00021668 File Offset: 0x00020668
		public static string ExportToHtml(InnerGrid grid)
		{
			return DataUtilities.ExportToHtml(grid, 1, 2);
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x00021674 File Offset: 0x00020674
		public static string ExportToHtml(InnerGrid grid, int cellSpacing, int cellPadding)
		{
			if (grid == null)
			{
				throw new ArgumentNullException("grid");
			}
			if (cellSpacing < 0)
			{
				throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNegative"), "cellSpacing");
			}
			if (cellPadding < 0)
			{
				throw new ArgumentException(xf1a67b6a145d2603.x538d63a1354c16f2("ExceptionNegative"), "cellPadding");
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat(new object[]
			{
				"<table cellspacing=\"",
				cellSpacing,
				"\" cellpadding=\"",
				cellPadding,
				"\">",
				Environment.NewLine
			}));
			stringBuilder.Append("<tr>");
			foreach (GridColumn gridColumn in grid.Columns.DisplayColumns)
			{
				stringBuilder.Append("<th width=\"" + gridColumn.Width + "\">");
				stringBuilder.Append(gridColumn.HeaderText);
				stringBuilder.Append("</th>");
			}
			stringBuilder.Append("</tr>" + Environment.NewLine);
			foreach (object obj in grid.FlatVisibleRows)
			{
				GridRow gridRow = (GridRow)obj;
				NestedGridRow nestedGridRow = gridRow as NestedGridRow;
				stringBuilder.Append("<tr>");
				int num = gridRow.IndentationLevel * grid.IndentationSize;
				int j;
				if (nestedGridRow != null)
				{
					stringBuilder.Append("<td colspan=\"" + grid.Columns.DisplayColumns.Length + "\"");
					if (num != 0)
					{
						stringBuilder.Append(" style=\"padding-left: " + num + "px\"");
						if ((uint)num + (uint)j < 0U)
						{
							goto IL_125;
						}
					}
					stringBuilder.Append(">" + Environment.NewLine);
					if (nestedGridRow.Heading.Length != 0)
					{
						stringBuilder.Append("<strong>" + nestedGridRow.Heading + "</strong><br />" + Environment.NewLine);
					}
					stringBuilder.Append(DataUtilities.ExportToHtml(nestedGridRow.NestedGrid) + Environment.NewLine);
					stringBuilder.Append("</td>" + Environment.NewLine);
					goto IL_130;
				}
				GridColumn[] displayColumns2 = grid.Columns.DisplayColumns;
				j = 0;
				IL_125:
				while (j < displayColumns2.Length)
				{
					GridColumn gridColumn2 = displayColumns2[j];
					stringBuilder.Append("<td");
					if (num != 0)
					{
						stringBuilder.Append(" style=\"padding-left: " + num + "px\"");
					}
					stringBuilder.Append(">");
					string text = gridColumn2.xf69eb59aa621a379(gridRow, gridRow.GetCellValue(gridColumn2), typeof(string)) as string;
					if (text != null)
					{
						stringBuilder.Append(text);
					}
					stringBuilder.Append("</td>");
					j++;
				}
				IL_130:
				stringBuilder.Append("</tr>" + Environment.NewLine);
			}
			stringBuilder.Append("</table>" + Environment.NewLine);
			return stringBuilder.ToString();
		}
	}
}

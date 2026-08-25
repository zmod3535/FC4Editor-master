using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Divelements.SandGrid
{
	// Token: 0x02000008 RID: 8
	public class ClipboardOperations
	{
		// Token: 0x06000039 RID: 57 RVA: 0x00005114 File Offset: 0x00004114
		private ClipboardOperations()
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0000511C File Offset: 0x0000411C
		public static void PasteFromClipboard(GridElement focusedElement)
		{
			int num;
			bool flag;
			GridCell gridCell;
			string xbcea506a33cf;
			if (focusedElement != null)
			{
				if (focusedElement.Grid != null)
				{
					string[][] array;
					GridCell gridCell2;
					if (focusedElement.Grid.SandGrid == null)
					{
						flag = (((uint)num & 0U) == 0U);
						if (flag)
						{
							goto IL_151;
						}
					}
					else
					{
						GridRow gridRow = focusedElement as GridRow;
						gridCell = (focusedElement as GridCell);
						IDataObject dataObject = Clipboard.GetDataObject();
						if (dataObject == null)
						{
							return;
						}
						if (dataObject.GetDataPresent(DataFormats.CommaSeparatedValue))
						{
							MemoryStream memoryStream = dataObject.GetData(DataFormats.CommaSeparatedValue) as MemoryStream;
							if (memoryStream == null)
							{
								return;
							}
							string xe4aa442e12986e;
							using (StreamReader streamReader = new StreamReader(memoryStream))
							{
								xe4aa442e12986e = streamReader.ReadToEnd();
								goto IL_39;
							}
							goto IL_1BA;
							IL_39:
							array = ClipboardOperations.x044d6c7028785073(xe4aa442e12986e);
							memoryStream.Close();
							if (gridCell != null)
							{
								gridCell2 = gridCell;
								num = 0;
								goto IL_C3;
							}
							return;
						}
						else
						{
							if (!dataObject.GetDataPresent(DataFormats.Text))
							{
								return;
							}
							xbcea506a33cf = (string)dataObject.GetData(DataFormats.Text);
							if (gridRow != null)
							{
								ClipboardOperations.x43b16dbd2792b2ee(gridRow, gridRow.Grid.PrimaryColumn, xbcea506a33cf);
							}
							if (gridCell == null)
							{
								return;
							}
							if (false)
							{
								goto IL_11A;
							}
						}
						IL_1BA:
						goto IL_21;
					}
					IL_64:
					GridRow nextVisibleRow = gridCell2.ParentRow.NextVisibleRow;
					if (nextVisibleRow != null && nextVisibleRow.Cells.IsValidIndex(gridCell2.ParentRow.Cells.IndexOf(gridCell2)))
					{
						gridCell2 = nextVisibleRow.Cells[gridCell2.ParentRow.Cells.IndexOf(gridCell2)];
					}
					else
					{
						gridCell2 = null;
					}
					num++;
					IL_C3:
					if (gridCell2 == null)
					{
						return;
					}
					if (num >= array.Length)
					{
						return;
					}
					ClipboardOperations.x2f7c617b4f8836e0(array[num], gridCell2);
					goto IL_64;
				}
				IL_151:
				throw new InvalidOperationException();
			}
			flag = ((uint)num + (uint)num < 0U);
			if (!flag)
			{
				goto IL_11A;
			}
			IL_21:
			ClipboardOperations.x43b16dbd2792b2ee(gridCell.ParentRow, gridCell.ParentColumn, xbcea506a33cf);
			return;
			IL_11A:
			throw new ArgumentNullException("focusedElement");
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00005304 File Offset: 0x00004304
		private static void x2f7c617b4f8836e0(string[] x4a3f0a05c02f235f, GridCell x71e60bebf0ded509)
		{
			GridCell gridCell = x71e60bebf0ded509;
			int num = 0;
			while (gridCell != null && num < x4a3f0a05c02f235f.Length)
			{
				ClipboardOperations.x43b16dbd2792b2ee(gridCell.ParentRow, gridCell.ParentColumn, x4a3f0a05c02f235f[num]);
				gridCell = gridCell.NextCell;
				num++;
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00005340 File Offset: 0x00004340
		private static string[][] x044d6c7028785073(string xe4aa442e12986e06)
		{
			ArrayList arrayList = new ArrayList();
			StringCollection stringCollection;
			for (;;)
			{
				IL_1AF:
				stringCollection = new StringCollection();
				int i = 0;
				while (i < xe4aa442e12986e06.Length)
				{
					if (xe4aa442e12986e06[i] == '"')
					{
						int num = ClipboardOperations.x7936994f779c9451(xe4aa442e12986e06, i + 1);
						if (num == -1)
						{
							goto IL_14C;
						}
						string value = xe4aa442e12986e06.Substring(i + 1, num - i - 1).Replace("\"\"", "\"");
						stringCollection.Add(value);
						i = xe4aa442e12986e06.IndexOfAny(new char[]
						{
							'\r',
							'\n',
							','
						}, num + 1);
						if (i == -1)
						{
							i = int.MaxValue;
							if (255 == 0)
							{
								goto IL_14C;
							}
						}
						if (i < xe4aa442e12986e06.Length && xe4aa442e12986e06[i] == ',')
						{
							i++;
						}
					}
					else if (xe4aa442e12986e06[i] == '\r' || xe4aa442e12986e06[i] == '\n')
					{
						if (xe4aa442e12986e06[i] == '\r' && xe4aa442e12986e06.Length > i + 1 && xe4aa442e12986e06[i + 1] == '\n')
						{
							i += 2;
						}
						else
						{
							i++;
							int num2;
							bool flag = (uint)num2 + (uint)num2 < 0U;
							if (flag)
							{
								goto IL_1AF;
							}
						}
						string[] array = new string[stringCollection.Count];
						stringCollection.CopyTo(array, 0);
						arrayList.Add(array);
						stringCollection = new StringCollection();
					}
					else
					{
						if (xe4aa442e12986e06[i] == '\0')
						{
							break;
						}
						int num2 = xe4aa442e12986e06.IndexOfAny(new char[]
						{
							'\r',
							'\n',
							','
						}, i);
						if (num2 == -1)
						{
							num2 = xe4aa442e12986e06.Length - i;
						}
						string value2 = xe4aa442e12986e06.Substring(i, num2 - i);
						stringCollection.Add(value2);
						i = num2 + 1;
					}
				}
				break;
			}
			if (stringCollection.Count != 0)
			{
				string[] array2 = new string[stringCollection.Count];
				stringCollection.CopyTo(array2, 0);
				arrayList.Add(array2);
			}
			return (string[][])arrayList.ToArray(typeof(string[]));
			IL_14C:
			return null;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00005524 File Offset: 0x00004524
		private static int x7936994f779c9451(string xcdaeea7afaf570ff, int x10aaa7cdfa38f254)
		{
			for (int i = x10aaa7cdfa38f254; i < xcdaeea7afaf570ff.Length; i += 2)
			{
				i = xcdaeea7afaf570ff.IndexOf("\"", i);
				if (i == -1)
				{
					return -1;
				}
				if (xcdaeea7afaf570ff.Length <= i + 1 || xcdaeea7afaf570ff[i + 1] != '"')
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00005574 File Offset: 0x00004574
		private static void x43b16dbd2792b2ee(GridRow xa806b754814b9ae0, GridColumn xe3e287548b3d01f5, object xbcea506a33cf9111)
		{
			try
			{
				xbcea506a33cf9111 = xe3e287548b3d01f5.x9efd48e8072f42ef(xa806b754814b9ae0, xbcea506a33cf9111);
			}
			catch
			{
				throw;
			}
			try
			{
				xa806b754814b9ae0.SetCellValue(xe3e287548b3d01f5, xbcea506a33cf9111);
			}
			catch
			{
				throw;
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000055D4 File Offset: 0x000045D4
		public static void CopyRowsToClipboard(InnerGrid grid, GridRow[] rows)
		{
			if (grid == null)
			{
				throw new ArgumentNullException("grid");
			}
			if (rows == null)
			{
				throw new ArgumentNullException("rows");
			}
			if (rows.Length == 0)
			{
				throw new ArgumentException("rows");
			}
			DataObject dataObject = new DataObject();
			ClipboardOperations.xef24483f58ad6ffa(dataObject, grid, rows);
			ClipboardOperations.x2d89f878fcca88b9(dataObject, grid, rows);
			Clipboard.Clear();
			Clipboard.SetDataObject(dataObject, true);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00005630 File Offset: 0x00004630
		public static void CopyCellsToClipboard(InnerGrid grid, GridCell[] cells, bool includeHeaders)
		{
			if (grid == null)
			{
				throw new ArgumentNullException("grid");
			}
			if (cells != null)
			{
				if (cells.Length == 0)
				{
					throw new ArgumentException("cells");
				}
				ArrayList arrayList = new ArrayList();
				foreach (GridCell gridCell in cells)
				{
					if (!arrayList.Contains(gridCell.ParentRow))
					{
						arrayList.Add(gridCell.ParentRow);
					}
				}
				GridRow[] array = (GridRow[])arrayList.ToArray(typeof(GridRow));
				int[] array2 = new int[array.Length];
				for (int j = 0; j < array.Length; j++)
				{
					array2[j] = array[j].Index;
				}
				Array.Sort<int, GridRow>(array2, array);
				GridColumn[] displayColumns = grid.Columns.DisplayColumns;
				int num;
				if ((uint)num <= 4294967295U)
				{
					num = int.MaxValue;
					int num2 = int.MinValue;
					foreach (GridCell gridCell2 in cells)
					{
						num = Math.Min(num, Array.IndexOf<GridColumn>(displayColumns, gridCell2.ParentColumn));
						num2 = Math.Max(num2, Array.IndexOf<GridColumn>(displayColumns, gridCell2.ParentColumn));
					}
					if (num == 2147483647 || num2 == -2147483648)
					{
						return;
					}
					DataObject dataObject = new DataObject();
					ClipboardOperations.xb68bf9e18a2c90f8(dataObject, cells, includeHeaders, array, displayColumns, num, num2);
					ClipboardOperations.x133915d9c64531a1(dataObject, cells, includeHeaders, array, displayColumns, num, num2);
					Clipboard.Clear();
					Clipboard.SetDataObject(dataObject, true);
					return;
				}
			}
			throw new ArgumentNullException("cells");
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000057E0 File Offset: 0x000047E0
		private static void xb68bf9e18a2c90f8(DataObject x4a3f0a05c02f235f, GridCell[] x77bb6a53fbd162d0, bool x22bf602079cabb12, GridRow[] x2eb5785cf1641b8b, GridColumn[] xdb79c8329f68bb3c, int xc4cf7599da9c93c4, int xdde8599bc817637e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (;;)
			{
				if (!x22bf602079cabb12)
				{
					goto IL_173;
				}
				int i;
				for (i = xc4cf7599da9c93c4; i <= xdde8599bc817637e; i++)
				{
					GridColumn gridColumn = xdb79c8329f68bb3c[i];
					if (i != xc4cf7599da9c93c4)
					{
						stringBuilder.Append('\t');
					}
					stringBuilder.Append(gridColumn.HeaderText);
				}
				if ((uint)xc4cf7599da9c93c4 + (uint)xdde8599bc817637e <= 4294967295U)
				{
					stringBuilder.Append(Environment.NewLine);
					goto IL_173;
				}
				goto IL_86;
				IL_23:
				int num;
				GridRow gridRow;
				int num2;
				if (num >= x2eb5785cf1641b8b.Length)
				{
					x4a3f0a05c02f235f.SetData(DataFormats.Text, stringBuilder.ToString());
					x4a3f0a05c02f235f.SetData(DataFormats.UnicodeText, stringBuilder.ToString());
					if (((uint)i & 0U) != 0U)
					{
						continue;
					}
					break;
				}
				else
				{
					gridRow = x2eb5785cf1641b8b[num];
					num2 = xc4cf7599da9c93c4;
				}
				IL_FE:
				GridColumn gridColumn2;
				if (num2 > xdde8599bc817637e)
				{
					if (((uint)xdde8599bc817637e & 0U) != 0U)
					{
						continue;
					}
					if (x2eb5785cf1641b8b.Length > 1)
					{
						stringBuilder.Append(Environment.NewLine);
					}
					num++;
					goto IL_23;
				}
				else
				{
					gridColumn2 = xdb79c8329f68bb3c[num2];
					if (num2 != xc4cf7599da9c93c4)
					{
						goto IL_86;
					}
				}
				IL_8F:
				ArrayList arrayList;
				if (gridRow.HasCells && gridRow.Cells.IsValidIndex(gridColumn2.Index) && arrayList.Contains(gridRow.Cells[gridColumn2.Index]))
				{
					string text = gridColumn2.xf69eb59aa621a379(gridRow, gridRow.GetCellValue(gridColumn2), typeof(string)) as string;
					if (text != null)
					{
						stringBuilder.Append(text);
					}
				}
				num2++;
				goto IL_FE;
				IL_173:
				arrayList = new ArrayList(x77bb6a53fbd162d0);
				num = 0;
				goto IL_23;
				IL_86:
				stringBuilder.Append('\t');
				goto IL_8F;
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00005978 File Offset: 0x00004978
		private static void x133915d9c64531a1(DataObject x4a3f0a05c02f235f, GridCell[] x77bb6a53fbd162d0, bool x22bf602079cabb12, GridRow[] x2eb5785cf1641b8b, GridColumn[] xdb79c8329f68bb3c, int xc4cf7599da9c93c4, int xdde8599bc817637e)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num;
			if (-2 != 0)
			{
				if (x22bf602079cabb12)
				{
					int i;
					if (((uint)i | 4294967295U) != 0U)
					{
						num = xc4cf7599da9c93c4;
					}
					goto IL_119;
				}
				goto IL_12A;
			}
			IL_FB:
			if (num != xc4cf7599da9c93c4)
			{
				stringBuilder.Append(',');
			}
			GridColumn gridColumn;
			ClipboardOperations.x6a4d2fcc0aef1e1d(stringBuilder, gridColumn.HeaderText);
			num++;
			IL_119:
			if (num > xdde8599bc817637e)
			{
				stringBuilder.Append(Environment.NewLine);
			}
			else
			{
				gridColumn = xdb79c8329f68bb3c[num];
				bool flag = ((uint)xc4cf7599da9c93c4 | 3U) == 0U;
				if (flag)
				{
					return;
				}
				goto IL_FB;
			}
			IL_12A:
			ArrayList arrayList = new ArrayList(x77bb6a53fbd162d0);
			foreach (GridRow gridRow in x2eb5785cf1641b8b)
			{
				for (int i = xc4cf7599da9c93c4; i <= xdde8599bc817637e; i++)
				{
					GridColumn gridColumn2 = xdb79c8329f68bb3c[i];
					if (i != xc4cf7599da9c93c4)
					{
						stringBuilder.Append(',');
					}
					if (gridRow.HasCells && gridRow.Cells.IsValidIndex(gridColumn2.Index) && arrayList.Contains(gridRow.Cells[gridColumn2.Index]))
					{
						string text = gridColumn2.xf69eb59aa621a379(gridRow, gridRow.GetCellValue(gridColumn2), typeof(string)) as string;
						if (text != null)
						{
							ClipboardOperations.x6a4d2fcc0aef1e1d(stringBuilder, text);
						}
					}
				}
				if (x2eb5785cf1641b8b.Length > 1)
				{
					stringBuilder.Append(Environment.NewLine);
				}
			}
			byte[] bytes = Encoding.Default.GetBytes(stringBuilder.ToString() + "\0");
			MemoryStream data = new MemoryStream(bytes);
			x4a3f0a05c02f235f.SetData(DataFormats.CommaSeparatedValue, data);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00005B14 File Offset: 0x00004B14
		private static void x6a4d2fcc0aef1e1d(StringBuilder xb41faee6912a2313, string xbcea506a33cf9111)
		{
			if (xbcea506a33cf9111.IndexOfAny(new char[]
			{
				',',
				'"',
				'\r',
				'\n'
			}) != -1)
			{
				xb41faee6912a2313.Append("\"");
				if (xbcea506a33cf9111.IndexOf('"') != -1)
				{
					xb41faee6912a2313.Append(xbcea506a33cf9111.Replace("\"", "\"\""));
				}
				else
				{
					xb41faee6912a2313.Append(xbcea506a33cf9111);
				}
				xb41faee6912a2313.Append("\"");
				return;
			}
			xb41faee6912a2313.Append(xbcea506a33cf9111);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00005B88 File Offset: 0x00004B88
		private static void x2d89f878fcca88b9(DataObject x4a3f0a05c02f235f, InnerGrid x3040c866fac95193, GridRow[] x2eb5785cf1641b8b)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (GridRow gridRow in x2eb5785cf1641b8b)
			{
				bool flag = true;
				GridColumn[] displayColumns = x3040c866fac95193.Columns.DisplayColumns;
				for (int j = 0; j < displayColumns.Length; j++)
				{
					GridColumn gridColumn = displayColumns[j];
					string text = gridColumn.xf69eb59aa621a379(gridRow, gridRow.GetCellValue(gridColumn), typeof(string)) as string;
					if (!flag)
					{
						stringBuilder.Append(',');
					}
					if (text != null)
					{
						ClipboardOperations.x6a4d2fcc0aef1e1d(stringBuilder, text);
					}
					flag = false;
					bool flag2 = ((uint)j & 0U) == 0U;
					if (flag2)
					{
					}
				}
				if (x2eb5785cf1641b8b.Length > 1)
				{
					stringBuilder.Append(Environment.NewLine);
				}
			}
			byte[] bytes = Encoding.Default.GetBytes(stringBuilder.ToString() + "\0");
			MemoryStream data = new MemoryStream(bytes);
			x4a3f0a05c02f235f.SetData(DataFormats.CommaSeparatedValue, data);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00005C7C File Offset: 0x00004C7C
		private static void xef24483f58ad6ffa(DataObject x4a3f0a05c02f235f, InnerGrid x3040c866fac95193, GridRow[] x2eb5785cf1641b8b)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int i = 0;
			IL_98:
			while (i < x2eb5785cf1641b8b.Length)
			{
				GridRow gridRow = x2eb5785cf1641b8b[i];
				bool flag = true;
				foreach (GridColumn gridColumn in x3040c866fac95193.Columns.DisplayColumns)
				{
					string text = gridColumn.xf69eb59aa621a379(gridRow, gridRow.GetCellValue(gridColumn), typeof(string)) as string;
					if (!flag)
					{
						if (-2147483648 == 0)
						{
							IL_86:
							stringBuilder.Append(Environment.NewLine);
							IL_92:
							i++;
							goto IL_98;
						}
						stringBuilder.Append('\t');
					}
					if (text != null)
					{
						stringBuilder.Append(text);
					}
					flag = false;
				}
				if (x2eb5785cf1641b8b.Length > 1)
				{
					goto IL_86;
				}
				goto IL_92;
			}
			x4a3f0a05c02f235f.SetData(DataFormats.Text, stringBuilder.ToString());
			x4a3f0a05c02f235f.SetData(DataFormats.UnicodeText, stringBuilder.ToString());
		}
	}
}

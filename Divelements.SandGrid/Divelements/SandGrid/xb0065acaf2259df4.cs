using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Divelements.SandGrid.Specialized;

namespace Divelements.SandGrid
{
	// Token: 0x02000029 RID: 41
	internal class xb0065acaf2259df4
	{
		// Token: 0x06000420 RID: 1056 RVA: 0x00017708 File Offset: 0x00016708
		public xb0065acaf2259df4(InnerGrid dataHost)
		{
			this.xf57b149cb3f9c03a = dataHost;
			this.x354fffdee23cf7e8 = new BitArray(10);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00017730 File Offset: 0x00016730
		private bool x429e83d68c5ae0cb(x681471a7f6916d5c x01b557925841ae51)
		{
			return this.x354fffdee23cf7e8[(int)x01b557925841ae51];
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00017740 File Offset: 0x00016740
		private void x9fa18ed8ade3e644(x681471a7f6916d5c x01b557925841ae51, bool xbcea506a33cf9111)
		{
			this.x354fffdee23cf7e8[(int)x01b557925841ae51] = xbcea506a33cf9111;
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00017750 File Offset: 0x00016750
		public GridColumn[] xae6f26df8c1270e0()
		{
			if (this.xe11545499171cc05 == null || this.xe11545499171cc05.Count == 0)
			{
				return new GridColumn[0];
			}
			ArrayList arrayList = new ArrayList();
			int i = 0;
			while (i < this.xe11545499171cc05.Count)
			{
				if (!typeof(IList).IsAssignableFrom(this.xe11545499171cc05[i].PropertyType))
				{
					goto IL_74;
				}
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(Image));
				if (converter.CanConvertFrom(this.xe11545499171cc05[i].PropertyType))
				{
					goto IL_74;
				}
				IL_DB:
				i++;
				continue;
				IL_74:
				PropertyDescriptor propertyDescriptor = this.xe11545499171cc05[i];
				GridColumn gridColumn = xb0065acaf2259df4.xa73745579909aebc(propertyDescriptor.PropertyType);
				gridColumn.x42d80cc5d994096e(true, i, this.xe11545499171cc05[i].PropertyType);
				gridColumn.DataPropertyName = propertyDescriptor.Name;
				gridColumn.HeaderText = propertyDescriptor.DisplayName;
				gridColumn.AllowEditing = !propertyDescriptor.IsReadOnly;
				arrayList.Add(gridColumn);
				goto IL_DB;
			}
			return (GridColumn[])arrayList.ToArray(typeof(GridColumn));
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00017864 File Offset: 0x00016864
		public TypeConverter xf8b6ecd6a6a34579(int x259eacb52ad8ded8)
		{
			return this.xe11545499171cc05[x259eacb52ad8ded8].Converter;
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00017878 File Offset: 0x00016878
		public Type x0c3a53005d4854a4(int x259eacb52ad8ded8)
		{
			return this.xe11545499171cc05[x259eacb52ad8ded8].PropertyType;
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0001788C File Offset: 0x0001688C
		public int xadc90428d59a400d(string xc3513c7f2bbafa84)
		{
			if (this.xe11545499171cc05 == null)
			{
				return -1;
			}
			for (int i = 0; i < this.xe11545499171cc05.Count; i++)
			{
				if (string.Compare(xc3513c7f2bbafa84, this.xe11545499171cc05[i].Name, true, CultureInfo.InvariantCulture) == 0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000178DC File Offset: 0x000168DC
		private static GridColumn xa73745579909aebc(Type x43163d22e8cd5a71)
		{
			if (x43163d22e8cd5a71 == typeof(byte[]))
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(Image));
				if (converter != null && converter.CanConvertFrom(x43163d22e8cd5a71))
				{
					return new GridImageColumn();
				}
			}
			if (typeof(Image).IsAssignableFrom(x43163d22e8cd5a71))
			{
				return new GridImageColumn();
			}
			if (x43163d22e8cd5a71 == typeof(bool))
			{
				return new GridBooleanColumn();
			}
			if (x43163d22e8cd5a71 == typeof(string))
			{
				return new GridColumn();
			}
			Type type = typeof(GridColumn<>).MakeGenericType(new Type[]
			{
				x43163d22e8cd5a71
			});
			return (GridColumn)Activator.CreateInstance(type);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00017980 File Offset: 0x00016980
		private void xf4c5d8845e2b38f5()
		{
			this.x42d80cc5d994096e(this.xef1769c4fe6ae4ca, this.x7fc8a9e04ee0e25b);
			this.xf57b149cb3f9c03a.x5a074e2e9b606ead();
			this.xf57b149cb3f9c03a.OnDataBindingComplete(new ListChangedEventArgs(ListChangedType.Reset, 0));
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000179B4 File Offset: 0x000169B4
		private void xdf4cbb4766eefe9c(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xf4c5d8845e2b38f5();
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x000179BC File Offset: 0x000169BC
		public void x42d80cc5d994096e(object xef1769c4fe6ae4ca, string x7fc8a9e04ee0e25b)
		{
			if (this.x429e83d68c5ae0cb(x681471a7f6916d5c.x748c99c08cdf7cb1))
			{
				return;
			}
			ISupportInitializeNotification supportInitializeNotification = this.xef1769c4fe6ae4ca as ISupportInitializeNotification;
			if (supportInitializeNotification != null && this.x429e83d68c5ae0cb(x681471a7f6916d5c.x1caecae1cd14857d))
			{
				supportInitializeNotification.Initialized -= this.xdf4cbb4766eefe9c;
				this.x9fa18ed8ade3e644(x681471a7f6916d5c.x1caecae1cd14857d, false);
			}
			this.x7feb058387e449e5();
			this.xef1769c4fe6ae4ca = xef1769c4fe6ae4ca;
			this.x7fc8a9e04ee0e25b = x7fc8a9e04ee0e25b;
			this.xe11545499171cc05 = null;
			this.x579c568e894f03f6 = null;
			this.x9fa18ed8ade3e644(x681471a7f6916d5c.x748c99c08cdf7cb1, true);
			try
			{
				if (this.xf57b149cb3f9c03a.SandGrid != null && this.xf57b149cb3f9c03a.SandGrid.BindingContext != null && xef1769c4fe6ae4ca != null)
				{
					supportInitializeNotification = (xef1769c4fe6ae4ca as ISupportInitializeNotification);
					if (supportInitializeNotification != null && !supportInitializeNotification.IsInitialized)
					{
						supportInitializeNotification.Initialized += this.xdf4cbb4766eefe9c;
						this.x9fa18ed8ade3e644(x681471a7f6916d5c.x1caecae1cd14857d, true);
						this.x579c568e894f03f6 = null;
					}
					else
					{
						this.x579c568e894f03f6 = (this.xf57b149cb3f9c03a.SandGrid.BindingContext[xef1769c4fe6ae4ca, x7fc8a9e04ee0e25b] as CurrencyManager);
					}
					this.xbae1c7043dde0825();
					if (this.x579c568e894f03f6 != null)
					{
						this.xe11545499171cc05 = this.x579c568e894f03f6.GetItemProperties();
					}
					else
					{
						this.xe11545499171cc05 = null;
					}
					this.x00b98fa9977bae33 = this.xa4139ab68433daf6();
				}
			}
			finally
			{
				this.x9fa18ed8ade3e644(x681471a7f6916d5c.x748c99c08cdf7cb1, false);
			}
			this.xa6889a3f6696d64b();
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00017B14 File Offset: 0x00016B14
		private void x7feb058387e449e5()
		{
			if (this.x579c568e894f03f6 != null)
			{
				this.x579c568e894f03f6.PositionChanged -= this.x88226dc18055c7b8;
			}
			IBindingList bindingList = this.x06ca69422bbb7502 as IBindingList;
			if (bindingList != null)
			{
				bindingList.ListChanged -= this.xbe8e2f54f81f18a9;
			}
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00017B64 File Offset: 0x00016B64
		private void xbae1c7043dde0825()
		{
			if (this.x579c568e894f03f6 != null)
			{
				this.x579c568e894f03f6.PositionChanged += this.x88226dc18055c7b8;
			}
			IBindingList bindingList = this.x06ca69422bbb7502 as IBindingList;
			if (bindingList != null)
			{
				bindingList.ListChanged += this.xbe8e2f54f81f18a9;
			}
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00017BB4 File Offset: 0x00016BB4
		internal void xa6889a3f6696d64b()
		{
			GridColumn[] array = new GridColumn[0];
			ListSortDirection[] array2 = new ListSortDirection[0];
			IBindingListView bindingListView = this.x06ca69422bbb7502 as IBindingListView;
			if (!false)
			{
				if (bindingListView != null && bindingListView.IsSorted)
				{
					array = new GridColumn[bindingListView.SortDescriptions.Count];
					array2 = new ListSortDirection[bindingListView.SortDescriptions.Count];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = this.x49e173e3e30c5f1a(this.xe11545499171cc05.IndexOf(bindingListView.SortDescriptions[i].PropertyDescriptor));
						array2[i] = bindingListView.SortDescriptions[i].SortDirection;
					}
				}
				IBindingList bindingList = this.x06ca69422bbb7502 as IBindingList;
				int j;
				do
				{
					if (array.Length == 0 && bindingList != null && bindingList.SupportsSorting && bindingList.IsSorted)
					{
						array = new GridColumn[]
						{
							this.x49e173e3e30c5f1a(this.xe11545499171cc05.IndexOf(bindingList.SortProperty))
						};
						array2 = new ListSortDirection[]
						{
							bindingList.SortDirection
						};
					}
					j = 0;
				}
				while (false);
				while (j < array.Length)
				{
					if (array[j] == null)
					{
						return;
					}
					j++;
				}
				this.xf57b149cb3f9c03a.x08643629319da08d(array, array2);
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x00017D04 File Offset: 0x00016D04
		private GridColumn x49e173e3e30c5f1a(int xb18727061e7ae069)
		{
			foreach (object obj in this.xf57b149cb3f9c03a.Columns)
			{
				GridColumn gridColumn = (GridColumn)obj;
				if (gridColumn.IsDataBound && gridColumn.xafbad39eb3920055 == xb18727061e7ae069)
				{
					return gridColumn;
				}
			}
			return null;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x00017D80 File Offset: 0x00016D80
		private void x63db33f637044f88(ListChangedEventArgs xfbf34718e704c6bc)
		{
			if (xfbf34718e704c6bc.ListChangedType != ListChangedType.ItemAdded)
			{
				goto IL_171;
			}
			IL_153:
			if (this.x06ca69422bbb7502.Count == this.xf57b149cb3f9c03a.Rows.Count)
			{
				return;
			}
			IL_171:
			if (this.xf57b149cb3f9c03a.VirtualMode)
			{
				switch (xfbf34718e704c6bc.ListChangedType)
				{
				case ListChangedType.Reset:
					this.xf57b149cb3f9c03a.xf0cbfe5c1ab718ea();
					this.xa6889a3f6696d64b();
					return;
				case ListChangedType.ItemAdded:
				case ListChangedType.ItemDeleted:
				case ListChangedType.ItemMoved:
					this.xf57b149cb3f9c03a.xf0cbfe5c1ab718ea();
					return;
				case ListChangedType.ItemChanged:
					if (this.xf57b149cb3f9c03a.Rows.IsValidIndex(xfbf34718e704c6bc.NewIndex))
					{
						GridRow gridRow = this.xf57b149cb3f9c03a.Rows[xfbf34718e704c6bc.NewIndex];
						gridRow.NotifyColumnValueChanged(null);
						return;
					}
					this.xf4c5d8845e2b38f5();
					return;
				case ListChangedType.PropertyDescriptorAdded:
				case ListChangedType.PropertyDescriptorDeleted:
				case ListChangedType.PropertyDescriptorChanged:
					this.x78f9f6030602620b();
					break;
				default:
					return;
				}
			}
			else
			{
				switch (xfbf34718e704c6bc.ListChangedType)
				{
				case ListChangedType.Reset:
					this.xf57b149cb3f9c03a.xf0cbfe5c1ab718ea();
					this.xa6889a3f6696d64b();
					return;
				case ListChangedType.ItemAdded:
					this.xf57b149cb3f9c03a.Rows.xb062e1da35ea3cf6(xfbf34718e704c6bc.NewIndex, this.xf57b149cb3f9c03a.xc1876ff4ff54c391());
					return;
				case ListChangedType.ItemDeleted:
					if (this.xf57b149cb3f9c03a.Rows.IsValidIndex(xfbf34718e704c6bc.NewIndex))
					{
						this.xf57b149cb3f9c03a.Rows.RemoveAt(xfbf34718e704c6bc.NewIndex);
						return;
					}
					this.xf4c5d8845e2b38f5();
					return;
				case ListChangedType.ItemMoved:
					this.x97c1189733637e41(xfbf34718e704c6bc.OldIndex, xfbf34718e704c6bc.NewIndex);
					return;
				case ListChangedType.ItemChanged:
					if (this.xf57b149cb3f9c03a.Rows.IsValidIndex(xfbf34718e704c6bc.NewIndex))
					{
						GridRow gridRow2 = this.xf57b149cb3f9c03a.Rows[xfbf34718e704c6bc.NewIndex];
						gridRow2.NotifyColumnValueChanged(null);
						return;
					}
					this.xf4c5d8845e2b38f5();
					if (!false)
					{
						if (false)
						{
							goto IL_153;
						}
						return;
					}
					break;
				case ListChangedType.PropertyDescriptorAdded:
				case ListChangedType.PropertyDescriptorDeleted:
				case ListChangedType.PropertyDescriptorChanged:
					this.x78f9f6030602620b();
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00017F58 File Offset: 0x00016F58
		private void x97c1189733637e41(int x3bbf353579eaf143, int x873721d4383ca28a)
		{
			GridRow xa806b754814b9ae = this.xf57b149cb3f9c03a.Rows[x3bbf353579eaf143];
			if (x873721d4383ca28a > x3bbf353579eaf143)
			{
				x873721d4383ca28a--;
			}
			this.xf57b149cb3f9c03a.Rows.x2df8a9784bb2fcd6(xa806b754814b9ae, x873721d4383ca28a);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00017F94 File Offset: 0x00016F94
		private void x78f9f6030602620b()
		{
			this.xf4c5d8845e2b38f5();
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00017F9C File Offset: 0x00016F9C
		private void xbe8e2f54f81f18a9(object xe0292b9ed559da7d, ListChangedEventArgs xfbf34718e704c6bc)
		{
			if (this.x429e83d68c5ae0cb(x681471a7f6916d5c.x78b163e20598ad5f))
			{
				return;
			}
			this.x9fa18ed8ade3e644(x681471a7f6916d5c.x78b163e20598ad5f, true);
			try
			{
				this.x63db33f637044f88(xfbf34718e704c6bc);
			}
			finally
			{
				this.x9fa18ed8ade3e644(x681471a7f6916d5c.x78b163e20598ad5f, false);
			}
			this.xf57b149cb3f9c03a.OnDataBindingComplete(xfbf34718e704c6bc);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x00017FF8 File Offset: 0x00016FF8
		private void x88226dc18055c7b8(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.xf57b149cb3f9c03a.SandGrid.ActiveGrid == this.xf57b149cb3f9c03a)
			{
				GridRow xda48682af7b = this.xf57b149cb3f9c03a.SandGrid.xda48682af7b76596;
				if ((xda48682af7b == null || xda48682af7b.Index != this.x579c568e894f03f6.Position) && this.xf57b149cb3f9c03a.Rows.IsValidIndex(this.x579c568e894f03f6.Position))
				{
					GridCell gridCell = this.xf57b149cb3f9c03a.SandGrid.FocusedElement as GridCell;
					int num = -1;
					if (gridCell != null)
					{
						num = gridCell.Index;
					}
					GridRow gridRow = this.xf57b149cb3f9c03a.Rows[this.x579c568e894f03f6.Position];
					if (this.xf57b149cb3f9c03a.SelectionGranularity == SelectionGranularity.Cell)
					{
						if (num != -1 && gridRow.Cells.IsValidIndex(num))
						{
							this.xf57b149cb3f9c03a.SelectElement(gridRow.Cells[num]);
							return;
						}
						if (gridRow.FirstVisibleCell != null)
						{
							this.xf57b149cb3f9c03a.SelectElement(gridRow.FirstVisibleCell);
							return;
						}
					}
					else if (this.xf57b149cb3f9c03a.SelectionGranularity == SelectionGranularity.Row)
					{
						this.xf57b149cb3f9c03a.SelectElement(gridRow);
					}
				}
			}
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x00018114 File Offset: 0x00017114
		public void x02f2c5fc8375d4bf(int x13d4cb8d1bd20347)
		{
			this.x579c568e894f03f6.Position = x13d4cb8d1bd20347;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00018124 File Offset: 0x00017124
		public void x90b92b9c88622fb5()
		{
			if (!this.x429e83d68c5ae0cb(x681471a7f6916d5c.x748c99c08cdf7cb1))
			{
				this.x42d80cc5d994096e(this.x086f935af5565717, this.x668c3bf9795baea6);
				this.xf57b149cb3f9c03a.x5a074e2e9b606ead();
				this.xf57b149cb3f9c03a.OnDataBindingComplete(new ListChangedEventArgs(ListChangedType.Reset, 0));
			}
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00018160 File Offset: 0x00017160
		private bool xa4139ab68433daf6()
		{
			ITypedList typedList = this.x06ca69422bbb7502 as ITypedList;
			if (this.xe11545499171cc05 == null || typedList == null)
			{
				return false;
			}
			foreach (object obj in this.xe11545499171cc05)
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
				if (typedList != null)
				{
					try
					{
						string listName = typedList.GetListName(new PropertyDescriptor[]
						{
							propertyDescriptor
						});
						if (listName != null && listName.Length != 0)
						{
							return true;
						}
					}
					catch
					{
					}
				}
			}
			return false;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00018228 File Offset: 0x00017228
		public void x86646cc3b2506262(int xe4d28a4eae65d0c7, out object[] x86c857e265fa5d6c, out string[] x964e81e83076d578)
		{
			x86c857e265fa5d6c = new object[0];
			x964e81e83076d578 = new string[0];
			object component = this.x06ca69422bbb7502[xe4d28a4eae65d0c7];
			ITypedList typedList = this.x06ca69422bbb7502 as ITypedList;
			if (this.xe11545499171cc05 == null || typedList == null)
			{
				return;
			}
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			foreach (object obj in this.xe11545499171cc05)
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
				string listName = typedList.GetListName(new PropertyDescriptor[]
				{
					propertyDescriptor
				});
				if (listName != null && listName.Length != 0)
				{
					IList list = propertyDescriptor.GetValue(component) as IList;
					if (list != null)
					{
						arrayList2.Add(listName);
						arrayList.Add(list);
					}
				}
			}
			x86c857e265fa5d6c = arrayList.ToArray();
			x964e81e83076d578 = (string[])arrayList2.ToArray(typeof(string));
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00018338 File Offset: 0x00017338
		public string x56f6dc80f5dd23e8(int xe4d28a4eae65d0c7)
		{
			IDataErrorInfo dataErrorInfo = this.x06ca69422bbb7502[xe4d28a4eae65d0c7] as IDataErrorInfo;
			if (dataErrorInfo != null)
			{
				return dataErrorInfo.Error;
			}
			return string.Empty;
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00018368 File Offset: 0x00017368
		public string x56f6dc80f5dd23e8(int xb18727061e7ae069, int xe4d28a4eae65d0c7)
		{
			IDataErrorInfo dataErrorInfo = this.x06ca69422bbb7502[xe4d28a4eae65d0c7] as IDataErrorInfo;
			if (dataErrorInfo != null)
			{
				return dataErrorInfo[this.xe11545499171cc05[xb18727061e7ae069].Name];
			}
			return string.Empty;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000183A8 File Offset: 0x000173A8
		public object x3f88a25febd23896(int xb18727061e7ae069, int xe4d28a4eae65d0c7)
		{
			return this.xe11545499171cc05[xb18727061e7ae069].GetValue(this.x06ca69422bbb7502[xe4d28a4eae65d0c7]);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000183C8 File Offset: 0x000173C8
		public void x7ab1be946f29c2a1()
		{
			IBindingList bindingList = this.x06ca69422bbb7502 as IBindingList;
			if (bindingList != null && bindingList.SupportsSorting)
			{
				bindingList.RemoveSort();
			}
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x000183F4 File Offset: 0x000173F4
		public void xb81dd0ef5ac562e4(GridColumn[] x26c511b92db96554, ListSortDirection[] x0835ff38739ed7ac)
		{
			if (x26c511b92db96554.Length == 0)
			{
				return;
			}
			IBindingListView bindingListView = this.x06ca69422bbb7502 as IBindingListView;
			if (bindingListView != null && bindingListView.SupportsAdvancedSorting)
			{
				ListSortDescription[] array = new ListSortDescription[x26c511b92db96554.Length];
				for (int i = 0; i < x26c511b92db96554.Length; i++)
				{
					array[i] = new ListSortDescription(this.xe11545499171cc05[x26c511b92db96554[i].xafbad39eb3920055], x0835ff38739ed7ac[i]);
				}
				bindingListView.ApplySort(new ListSortDescriptionCollection(array));
				return;
			}
			IBindingList bindingList = this.x06ca69422bbb7502 as IBindingList;
			if (bindingList != null && bindingList.SupportsSorting)
			{
				bindingList.ApplySort(this.xe11545499171cc05[x26c511b92db96554[0].xafbad39eb3920055], x0835ff38739ed7ac[0]);
			}
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00018494 File Offset: 0x00017494
		private void xc7b6e59bfbbe9301(int xb18727061e7ae069, object xd7e84317d05d9347, object xbcea506a33cf9111)
		{
			this.xe11545499171cc05[xb18727061e7ae069].SetValue(xd7e84317d05d9347, xbcea506a33cf9111);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000184AC File Offset: 0x000174AC
		public void xc7b6e59bfbbe9301(int xb18727061e7ae069, int xe4d28a4eae65d0c7, object xbcea506a33cf9111)
		{
			this.xc7b6e59bfbbe9301(xb18727061e7ae069, this.x06ca69422bbb7502[xe4d28a4eae65d0c7], xbcea506a33cf9111);
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x000184C4 File Offset: 0x000174C4
		public bool xa2b5c987a23c14fd
		{
			get
			{
				return this.x00b98fa9977bae33;
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x000184CC File Offset: 0x000174CC
		public IList x06ca69422bbb7502
		{
			get
			{
				if (this.x579c568e894f03f6 != null)
				{
					return this.x579c568e894f03f6.List;
				}
				return null;
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x000184E4 File Offset: 0x000174E4
		public object x086f935af5565717
		{
			get
			{
				return this.xef1769c4fe6ae4ca;
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x000184EC File Offset: 0x000174EC
		public string x668c3bf9795baea6
		{
			get
			{
				return this.x7fc8a9e04ee0e25b;
			}
		}

		// Token: 0x0400013B RID: 315
		private InnerGrid xf57b149cb3f9c03a;

		// Token: 0x0400013C RID: 316
		private PropertyDescriptorCollection xe11545499171cc05;

		// Token: 0x0400013D RID: 317
		private object xef1769c4fe6ae4ca;

		// Token: 0x0400013E RID: 318
		private string x7fc8a9e04ee0e25b = "";

		// Token: 0x0400013F RID: 319
		private CurrencyManager x579c568e894f03f6;

		// Token: 0x04000140 RID: 320
		private BitArray x354fffdee23cf7e8;

		// Token: 0x04000141 RID: 321
		private bool x00b98fa9977bae33;
	}
}

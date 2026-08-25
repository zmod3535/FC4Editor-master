using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000036 RID: 54
	public class DataGridTemplateColumn : DataGridColumn
	{
		// Token: 0x060002D7 RID: 727 RVA: 0x0000AD94 File Offset: 0x00008F94
		static DataGridTemplateColumn()
		{
			DataGridColumn.CanUserSortProperty.OverrideMetadata(typeof(DataGridTemplateColumn), new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGridTemplateColumn.OnCoerceTemplateColumnCanUserSort)));
			DataGridColumn.SortMemberPathProperty.OverrideMetadata(typeof(DataGridTemplateColumn), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridTemplateColumn.OnTemplateColumnSortMemberPathChanged)));
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000AEC0 File Offset: 0x000090C0
		private static void OnTemplateColumnSortMemberPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DataGridTemplateColumn dataGridTemplateColumn = (DataGridTemplateColumn)d;
			dataGridTemplateColumn.CoerceValue(DataGridColumn.CanUserSortProperty);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000AEE0 File Offset: 0x000090E0
		private static object OnCoerceTemplateColumnCanUserSort(DependencyObject d, object baseValue)
		{
			DataGridTemplateColumn dataGridTemplateColumn = (DataGridTemplateColumn)d;
			if (string.IsNullOrEmpty(dataGridTemplateColumn.SortMemberPath))
			{
				return false;
			}
			return DataGridColumn.OnCoerceCanUserSort(d, baseValue);
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060002DA RID: 730 RVA: 0x0000AF0F File Offset: 0x0000910F
		// (set) Token: 0x060002DB RID: 731 RVA: 0x0000AF21 File Offset: 0x00009121
		public DataTemplate CellTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(DataGridTemplateColumn.CellTemplateProperty);
			}
			set
			{
				base.SetValue(DataGridTemplateColumn.CellTemplateProperty, value);
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000AF2F File Offset: 0x0000912F
		// (set) Token: 0x060002DD RID: 733 RVA: 0x0000AF41 File Offset: 0x00009141
		public DataTemplateSelector CellTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(DataGridTemplateColumn.CellTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(DataGridTemplateColumn.CellTemplateSelectorProperty, value);
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000AF4F File Offset: 0x0000914F
		// (set) Token: 0x060002DF RID: 735 RVA: 0x0000AF61 File Offset: 0x00009161
		public DataTemplate CellEditingTemplate
		{
			get
			{
				return (DataTemplate)base.GetValue(DataGridTemplateColumn.CellEditingTemplateProperty);
			}
			set
			{
				base.SetValue(DataGridTemplateColumn.CellEditingTemplateProperty, value);
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000AF6F File Offset: 0x0000916F
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x0000AF81 File Offset: 0x00009181
		public DataTemplateSelector CellEditingTemplateSelector
		{
			get
			{
				return (DataTemplateSelector)base.GetValue(DataGridTemplateColumn.CellEditingTemplateSelectorProperty);
			}
			set
			{
				base.SetValue(DataGridTemplateColumn.CellEditingTemplateSelectorProperty, value);
			}
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000AF90 File Offset: 0x00009190
		private DataTemplate ChooseCellTemplate(bool isEditing)
		{
			DataTemplate dataTemplate = null;
			if (isEditing)
			{
				dataTemplate = this.CellEditingTemplate;
			}
			if (dataTemplate == null)
			{
				dataTemplate = this.CellTemplate;
			}
			return dataTemplate;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000AFB4 File Offset: 0x000091B4
		private DataTemplateSelector ChooseCellTemplateSelector(bool isEditing)
		{
			DataTemplateSelector dataTemplateSelector = null;
			if (isEditing)
			{
				dataTemplateSelector = this.CellEditingTemplateSelector;
			}
			if (dataTemplateSelector == null)
			{
				dataTemplateSelector = this.CellTemplateSelector;
			}
			return dataTemplateSelector;
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000AFD8 File Offset: 0x000091D8
		private FrameworkElement LoadTemplateContent(bool isEditing, object dataItem, DataGridCell cell)
		{
			DataTemplate dataTemplate = this.ChooseCellTemplate(isEditing);
			DataTemplateSelector dataTemplateSelector = this.ChooseCellTemplateSelector(isEditing);
			if (dataTemplate != null || dataTemplateSelector != null)
			{
				ContentPresenter contentPresenter = new ContentPresenter();
				BindingOperations.SetBinding(contentPresenter, ContentPresenter.ContentProperty, new Binding());
				contentPresenter.ContentTemplate = dataTemplate;
				contentPresenter.ContentTemplateSelector = dataTemplateSelector;
				return contentPresenter;
			}
			return null;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000B023 File Offset: 0x00009223
		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			return this.LoadTemplateContent(false, dataItem, cell);
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000B02E File Offset: 0x0000922E
		protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
		{
			return this.LoadTemplateContent(true, dataItem, cell);
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000B03C File Offset: 0x0000923C
		protected internal override void RefreshCellContent(FrameworkElement element, string propertyName)
		{
			DataGridCell dataGridCell = element as DataGridCell;
			if (dataGridCell != null)
			{
				bool isEditing = dataGridCell.IsEditing;
				if ((!isEditing && (string.Compare(propertyName, "CellTemplate", StringComparison.Ordinal) == 0 || string.Compare(propertyName, "CellTemplateSelector", StringComparison.Ordinal) == 0)) || (isEditing && (string.Compare(propertyName, "CellEditingTemplate", StringComparison.Ordinal) == 0 || string.Compare(propertyName, "CellEditingTemplateSelector", StringComparison.Ordinal) == 0)))
				{
					dataGridCell.BuildVisualTree();
					return;
				}
			}
			base.RefreshCellContent(element, propertyName);
		}

		// Token: 0x040000CD RID: 205
		public static readonly DependencyProperty CellTemplateProperty = DependencyProperty.Register("CellTemplate", typeof(DataTemplate), typeof(DataGridTemplateColumn), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x040000CE RID: 206
		public static readonly DependencyProperty CellTemplateSelectorProperty = DependencyProperty.Register("CellTemplateSelector", typeof(DataTemplateSelector), typeof(DataGridTemplateColumn), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x040000CF RID: 207
		public static readonly DependencyProperty CellEditingTemplateProperty = DependencyProperty.Register("CellEditingTemplate", typeof(DataTemplate), typeof(DataGridTemplateColumn), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x040000D0 RID: 208
		public static readonly DependencyProperty CellEditingTemplateSelectorProperty = DependencyProperty.Register("CellEditingTemplateSelector", typeof(DataTemplateSelector), typeof(DataGridTemplateColumn), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));
	}
}

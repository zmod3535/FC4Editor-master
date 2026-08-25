using System;
using System.Windows;
using System.Windows.Data;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000009 RID: 9
	public abstract class DataGridBoundColumn : DataGridColumn
	{
		// Token: 0x060000C6 RID: 198 RVA: 0x000041D4 File Offset: 0x000023D4
		static DataGridBoundColumn()
		{
			DataGridColumn.SortMemberPathProperty.OverrideMetadata(typeof(DataGridBoundColumn), new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGridBoundColumn.OnCoerceSortMemberPath)));
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004274 File Offset: 0x00002474
		private static object OnCoerceSortMemberPath(DependencyObject d, object baseValue)
		{
			DataGridBoundColumn dataGridBoundColumn = (DataGridBoundColumn)d;
			string text = (string)baseValue;
			if (string.IsNullOrEmpty(text))
			{
				text = DataGridHelper.GetPathFromBinding(dataGridBoundColumn.Binding as Binding);
			}
			return text;
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x000042A9 File Offset: 0x000024A9
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x000042D4 File Offset: 0x000024D4
		public virtual BindingBase Binding
		{
			get
			{
				if (!this._bindingEnsured)
				{
					if (!base.IsReadOnly)
					{
						DataGridHelper.EnsureTwoWayIfNotOneWay(this._binding);
					}
					this._bindingEnsured = true;
				}
				return this._binding;
			}
			set
			{
				if (this._binding != value)
				{
					BindingBase binding = this._binding;
					this._binding = value;
					base.CoerceValue(DataGridColumn.IsReadOnlyProperty);
					base.CoerceValue(DataGridColumn.SortMemberPathProperty);
					this._bindingEnsured = false;
					this.OnBindingChanged(binding, this._binding);
				}
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004322 File Offset: 0x00002522
		protected override bool OnCoerceIsReadOnly(bool baseValue)
		{
			return DataGridHelper.IsOneWay(this._binding) || base.OnCoerceIsReadOnly(baseValue);
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000433A File Offset: 0x0000253A
		protected virtual void OnBindingChanged(BindingBase oldBinding, BindingBase newBinding)
		{
			base.NotifyPropertyChanged("Binding");
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00004348 File Offset: 0x00002548
		internal void ApplyBinding(DependencyObject target, DependencyProperty property)
		{
			BindingBase binding = this.Binding;
			if (binding != null)
			{
				BindingOperations.SetBinding(target, property, binding);
				return;
			}
			BindingOperations.ClearBinding(target, property);
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00004370 File Offset: 0x00002570
		// (set) Token: 0x060000CE RID: 206 RVA: 0x00004382 File Offset: 0x00002582
		public Style ElementStyle
		{
			get
			{
				return (Style)base.GetValue(DataGridBoundColumn.ElementStyleProperty);
			}
			set
			{
				base.SetValue(DataGridBoundColumn.ElementStyleProperty, value);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00004390 File Offset: 0x00002590
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x000043A2 File Offset: 0x000025A2
		public Style EditingElementStyle
		{
			get
			{
				return (Style)base.GetValue(DataGridBoundColumn.EditingElementStyleProperty);
			}
			set
			{
				base.SetValue(DataGridBoundColumn.EditingElementStyleProperty, value);
			}
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000043B0 File Offset: 0x000025B0
		internal void ApplyStyle(bool isEditing, bool defaultToElementStyle, FrameworkElement element)
		{
			Style style = this.PickStyle(isEditing, defaultToElementStyle);
			if (style != null)
			{
				element.Style = style;
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000043D0 File Offset: 0x000025D0
		private Style PickStyle(bool isEditing, bool defaultToElementStyle)
		{
			Style style = isEditing ? this.EditingElementStyle : this.ElementStyle;
			if (isEditing && defaultToElementStyle && style == null)
			{
				style = this.ElementStyle;
			}
			return style;
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00004400 File Offset: 0x00002600
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x00004412 File Offset: 0x00002612
		public override BindingBase ClipboardContentBinding
		{
			get
			{
				return base.ClipboardContentBinding ?? this.Binding;
			}
			set
			{
				base.ClipboardContentBinding = value;
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000441C File Offset: 0x0000261C
		protected internal override void RefreshCellContent(FrameworkElement element, string propertyName)
		{
			DataGridCell dataGridCell = element as DataGridCell;
			if (dataGridCell != null)
			{
				bool isEditing = dataGridCell.IsEditing;
				if (string.Compare(propertyName, "Binding", StringComparison.Ordinal) == 0 || (string.Compare(propertyName, "ElementStyle", StringComparison.Ordinal) == 0 && !isEditing) || (string.Compare(propertyName, "EditingElementStyle", StringComparison.Ordinal) == 0 && isEditing))
				{
					dataGridCell.BuildVisualTree();
					return;
				}
			}
			base.RefreshCellContent(element, propertyName);
		}

		// Token: 0x0400002A RID: 42
		public static readonly DependencyProperty ElementStyleProperty = DependencyProperty.Register("ElementStyle", typeof(Style), typeof(DataGridBoundColumn), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x0400002B RID: 43
		public static readonly DependencyProperty EditingElementStyleProperty = DependencyProperty.Register("EditingElementStyle", typeof(Style), typeof(DataGridBoundColumn), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x0400002C RID: 44
		private BindingBase _binding;

		// Token: 0x0400002D RID: 45
		private bool _bindingEnsured = true;
	}
}

using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200000C RID: 12
	public class DataGridComboBoxColumn : DataGridColumn
	{
		// Token: 0x060000FA RID: 250 RVA: 0x00004BE4 File Offset: 0x00002DE4
		static DataGridComboBoxColumn()
		{
			DataGridColumn.SortMemberPathProperty.OverrideMetadata(typeof(DataGridComboBoxColumn), new FrameworkPropertyMetadata(null, new CoerceValueCallback(DataGridComboBoxColumn.OnCoerceSortMemberPath)));
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004CE8 File Offset: 0x00002EE8
		private static object OnCoerceSortMemberPath(DependencyObject d, object baseValue)
		{
			DataGridComboBoxColumn dataGridComboBoxColumn = (DataGridComboBoxColumn)d;
			string text = (string)baseValue;
			if (string.IsNullOrEmpty(text))
			{
				text = DataGridHelper.GetPathFromBinding(dataGridComboBoxColumn.EffectiveBinding as Binding);
			}
			return text;
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00004D1D File Offset: 0x00002F1D
		private BindingBase EffectiveBinding
		{
			get
			{
				if (this.SelectedItemBinding != null)
				{
					return this.SelectedItemBinding;
				}
				if (this.SelectedValueBinding != null)
				{
					return this.SelectedValueBinding;
				}
				return this.TextBinding;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00004D43 File Offset: 0x00002F43
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00004D70 File Offset: 0x00002F70
		public virtual BindingBase SelectedValueBinding
		{
			get
			{
				if (!this._selectedValueBindingEnsured)
				{
					if (!base.IsReadOnly)
					{
						DataGridHelper.EnsureTwoWayIfNotOneWay(this._selectedValueBinding);
					}
					this._selectedValueBindingEnsured = true;
				}
				return this._selectedValueBinding;
			}
			set
			{
				if (this._selectedValueBinding != value)
				{
					BindingBase selectedValueBinding = this._selectedValueBinding;
					this._selectedValueBinding = value;
					base.CoerceValue(DataGridColumn.IsReadOnlyProperty);
					base.CoerceValue(DataGridColumn.SortMemberPathProperty);
					this._selectedValueBindingEnsured = false;
					this.OnSelectedValueBindingChanged(selectedValueBinding, this._selectedValueBinding);
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00004DBE File Offset: 0x00002FBE
		protected override bool OnCoerceIsReadOnly(bool baseValue)
		{
			return DataGridHelper.IsOneWay(this.EffectiveBinding) || base.OnCoerceIsReadOnly(baseValue);
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00004DD6 File Offset: 0x00002FD6
		// (set) Token: 0x06000101 RID: 257 RVA: 0x00004E00 File Offset: 0x00003000
		public virtual BindingBase SelectedItemBinding
		{
			get
			{
				if (!this._selectedItemBindingEnsured)
				{
					if (!base.IsReadOnly)
					{
						DataGridHelper.EnsureTwoWayIfNotOneWay(this._selectedItemBinding);
					}
					this._selectedItemBindingEnsured = true;
				}
				return this._selectedItemBinding;
			}
			set
			{
				if (this._selectedItemBinding != value)
				{
					BindingBase selectedItemBinding = this._selectedItemBinding;
					this._selectedItemBinding = value;
					base.CoerceValue(DataGridColumn.IsReadOnlyProperty);
					base.CoerceValue(DataGridColumn.SortMemberPathProperty);
					this._selectedItemBindingEnsured = false;
					this.OnSelectedItemBindingChanged(selectedItemBinding, this._selectedItemBinding);
				}
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00004E4E File Offset: 0x0000304E
		// (set) Token: 0x06000103 RID: 259 RVA: 0x00004E78 File Offset: 0x00003078
		public virtual BindingBase TextBinding
		{
			get
			{
				if (!this._textBindingEnsured)
				{
					if (!base.IsReadOnly)
					{
						DataGridHelper.EnsureTwoWayIfNotOneWay(this._textBinding);
					}
					this._textBindingEnsured = true;
				}
				return this._textBinding;
			}
			set
			{
				if (this._textBinding != value)
				{
					BindingBase textBinding = this._textBinding;
					this._textBinding = value;
					base.CoerceValue(DataGridColumn.IsReadOnlyProperty);
					base.CoerceValue(DataGridColumn.SortMemberPathProperty);
					this._textBindingEnsured = false;
					this.OnTextBindingChanged(textBinding, this._textBinding);
				}
			}
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00004EC6 File Offset: 0x000030C6
		protected virtual void OnSelectedValueBindingChanged(BindingBase oldBinding, BindingBase newBinding)
		{
			base.NotifyPropertyChanged("SelectedValueBinding");
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00004ED3 File Offset: 0x000030D3
		protected virtual void OnSelectedItemBindingChanged(BindingBase oldBinding, BindingBase newBinding)
		{
			base.NotifyPropertyChanged("SelectedItemBinding");
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00004EE0 File Offset: 0x000030E0
		protected virtual void OnTextBindingChanged(BindingBase oldBinding, BindingBase newBinding)
		{
			base.NotifyPropertyChanged("TextBinding");
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00004EF0 File Offset: 0x000030F0
		public static Style DefaultElementStyle
		{
			get
			{
				if (DataGridComboBoxColumn._defaultElementStyle == null)
				{
					Style style = new Style(typeof(ComboBox));
					style.Setters.Add(new Setter(Selector.IsSynchronizedWithCurrentItemProperty, false));
					style.Seal();
					DataGridComboBoxColumn._defaultElementStyle = style;
				}
				return DataGridComboBoxColumn._defaultElementStyle;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00004F40 File Offset: 0x00003140
		public static Style DefaultEditingElementStyle
		{
			get
			{
				return DataGridComboBoxColumn.DefaultElementStyle;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00004F47 File Offset: 0x00003147
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00004F59 File Offset: 0x00003159
		public Style ElementStyle
		{
			get
			{
				return (Style)base.GetValue(DataGridComboBoxColumn.ElementStyleProperty);
			}
			set
			{
				base.SetValue(DataGridComboBoxColumn.ElementStyleProperty, value);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00004F67 File Offset: 0x00003167
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00004F79 File Offset: 0x00003179
		public Style EditingElementStyle
		{
			get
			{
				return (Style)base.GetValue(DataGridComboBoxColumn.EditingElementStyleProperty);
			}
			set
			{
				base.SetValue(DataGridComboBoxColumn.EditingElementStyleProperty, value);
			}
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00004F88 File Offset: 0x00003188
		private void ApplyStyle(bool isEditing, bool defaultToElementStyle, FrameworkElement element)
		{
			Style style = this.PickStyle(isEditing, defaultToElementStyle);
			if (style != null)
			{
				element.Style = style;
			}
		}

		// Token: 0x0600010E RID: 270 RVA: 0x00004FA8 File Offset: 0x000031A8
		internal void ApplyStyle(bool isEditing, bool defaultToElementStyle, FrameworkContentElement element)
		{
			Style style = this.PickStyle(isEditing, defaultToElementStyle);
			if (style != null)
			{
				element.Style = style;
			}
		}

		// Token: 0x0600010F RID: 271 RVA: 0x00004FC8 File Offset: 0x000031C8
		private Style PickStyle(bool isEditing, bool defaultToElementStyle)
		{
			Style style = isEditing ? this.EditingElementStyle : this.ElementStyle;
			if (isEditing && defaultToElementStyle && style == null)
			{
				style = this.ElementStyle;
			}
			return style;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00004FF8 File Offset: 0x000031F8
		private static void ApplyBinding(BindingBase binding, DependencyObject target, DependencyProperty property)
		{
			if (binding != null)
			{
				BindingOperations.SetBinding(target, property, binding);
				return;
			}
			BindingOperations.ClearBinding(target, property);
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000111 RID: 273 RVA: 0x0000500E File Offset: 0x0000320E
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00005020 File Offset: 0x00003220
		public override BindingBase ClipboardContentBinding
		{
			get
			{
				return base.ClipboardContentBinding ?? this.EffectiveBinding;
			}
			set
			{
				base.ClipboardContentBinding = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00005029 File Offset: 0x00003229
		// (set) Token: 0x06000114 RID: 276 RVA: 0x0000503B File Offset: 0x0000323B
		public IEnumerable ItemsSource
		{
			get
			{
				return (IEnumerable)base.GetValue(DataGridComboBoxColumn.ItemsSourceProperty);
			}
			set
			{
				base.SetValue(DataGridComboBoxColumn.ItemsSourceProperty, value);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00005049 File Offset: 0x00003249
		// (set) Token: 0x06000116 RID: 278 RVA: 0x0000505B File Offset: 0x0000325B
		public string DisplayMemberPath
		{
			get
			{
				return (string)base.GetValue(DataGridComboBoxColumn.DisplayMemberPathProperty);
			}
			set
			{
				base.SetValue(DataGridComboBoxColumn.DisplayMemberPathProperty, value);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00005069 File Offset: 0x00003269
		// (set) Token: 0x06000118 RID: 280 RVA: 0x0000507B File Offset: 0x0000327B
		public string SelectedValuePath
		{
			get
			{
				return (string)base.GetValue(DataGridComboBoxColumn.SelectedValuePathProperty);
			}
			set
			{
				base.SetValue(DataGridComboBoxColumn.SelectedValuePathProperty, value);
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000508C File Offset: 0x0000328C
		protected internal override void RefreshCellContent(FrameworkElement element, string propertyName)
		{
			DataGridCell dataGridCell = element as DataGridCell;
			if (dataGridCell == null)
			{
				base.RefreshCellContent(element, propertyName);
				return;
			}
			bool isEditing = dataGridCell.IsEditing;
			if ((string.Compare(propertyName, "ElementStyle", StringComparison.Ordinal) == 0 && !isEditing) || (string.Compare(propertyName, "EditingElementStyle", StringComparison.Ordinal) == 0 && isEditing))
			{
				dataGridCell.BuildVisualTree();
				return;
			}
			ComboBox comboBox = dataGridCell.Content as ComboBox;
			switch (propertyName)
			{
			case "SelectedItemBinding":
				DataGridComboBoxColumn.ApplyBinding(this.SelectedItemBinding, comboBox, Selector.SelectedItemProperty);
				return;
			case "SelectedValueBinding":
				DataGridComboBoxColumn.ApplyBinding(this.SelectedValueBinding, comboBox, Selector.SelectedValueProperty);
				return;
			case "TextBinding":
				DataGridComboBoxColumn.ApplyBinding(this.TextBinding, comboBox, ComboBox.TextProperty);
				return;
			case "SelectedValuePath":
				DataGridHelper.SyncColumnProperty(this, comboBox, Selector.SelectedValuePathProperty, DataGridComboBoxColumn.SelectedValuePathProperty);
				return;
			case "DisplayMemberPath":
				DataGridHelper.SyncColumnProperty(this, comboBox, ItemsControl.DisplayMemberPathProperty, DataGridComboBoxColumn.DisplayMemberPathProperty);
				return;
			case "ItemsSource":
				DataGridHelper.SyncColumnProperty(this, comboBox, ItemsControl.ItemsSourceProperty, DataGridComboBoxColumn.ItemsSourceProperty);
				return;
			}
			base.RefreshCellContent(element, propertyName);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x000051FA File Offset: 0x000033FA
		private object GetComboBoxSelectionValue(ComboBox comboBox)
		{
			if (this.SelectedItemBinding != null)
			{
				return comboBox.SelectedItem;
			}
			if (this.SelectedValueBinding != null)
			{
				return comboBox.SelectedValue;
			}
			return comboBox.Text;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005220 File Offset: 0x00003420
		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			DataGridComboBoxColumn.TextBlockComboBox textBlockComboBox = new DataGridComboBoxColumn.TextBlockComboBox();
			this.ApplyStyle(false, false, textBlockComboBox);
			this.ApplyColumnProperties(textBlockComboBox);
			return textBlockComboBox;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00005244 File Offset: 0x00003444
		protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
		{
			ComboBox comboBox = new ComboBox();
			this.ApplyStyle(true, false, comboBox);
			this.ApplyColumnProperties(comboBox);
			return comboBox;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x00005268 File Offset: 0x00003468
		private void ApplyColumnProperties(ComboBox comboBox)
		{
			DataGridComboBoxColumn.ApplyBinding(this.SelectedItemBinding, comboBox, Selector.SelectedItemProperty);
			DataGridComboBoxColumn.ApplyBinding(this.SelectedValueBinding, comboBox, Selector.SelectedValueProperty);
			DataGridComboBoxColumn.ApplyBinding(this.TextBinding, comboBox, ComboBox.TextProperty);
			DataGridHelper.SyncColumnProperty(this, comboBox, Selector.SelectedValuePathProperty, DataGridComboBoxColumn.SelectedValuePathProperty);
			DataGridHelper.SyncColumnProperty(this, comboBox, ItemsControl.DisplayMemberPathProperty, DataGridComboBoxColumn.DisplayMemberPathProperty);
			DataGridHelper.SyncColumnProperty(this, comboBox, ItemsControl.ItemsSourceProperty, DataGridComboBoxColumn.ItemsSourceProperty);
		}

		// Token: 0x0600011E RID: 286 RVA: 0x000052DC File Offset: 0x000034DC
		protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
		{
			ComboBox comboBox = editingElement as ComboBox;
			if (comboBox != null)
			{
				comboBox.Focus();
				object comboBoxSelectionValue = this.GetComboBoxSelectionValue(comboBox);
				if (DataGridComboBoxColumn.IsComboBoxOpeningInputEvent(editingEventArgs))
				{
					comboBox.IsDropDownOpen = true;
				}
				return comboBoxSelectionValue;
			}
			return null;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00005314 File Offset: 0x00003514
		protected override bool CommitCellEdit(FrameworkElement editingElement)
		{
			ComboBox comboBox = editingElement as ComboBox;
			if (comboBox != null)
			{
				DataGridHelper.UpdateSource(comboBox, Selector.SelectedValueProperty);
				DataGridHelper.UpdateSource(comboBox, Selector.SelectedItemProperty);
				DataGridHelper.UpdateSource(comboBox, ComboBox.TextProperty);
				return !Validation.GetHasError(comboBox);
			}
			return true;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00005358 File Offset: 0x00003558
		protected override void CancelCellEdit(FrameworkElement editingElement, object uneditedValue)
		{
			ComboBox comboBox = editingElement as ComboBox;
			if (comboBox != null)
			{
				DataGridHelper.UpdateTarget(comboBox, Selector.SelectedValueProperty);
				DataGridHelper.UpdateTarget(comboBox, Selector.SelectedItemProperty);
				DataGridHelper.UpdateTarget(comboBox, ComboBox.TextProperty);
			}
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00005390 File Offset: 0x00003590
		internal override void OnInput(InputEventArgs e)
		{
			if (DataGridComboBoxColumn.IsComboBoxOpeningInputEvent(e))
			{
				base.BeginEdit(e);
			}
		}

		// Token: 0x06000122 RID: 290 RVA: 0x000053A4 File Offset: 0x000035A4
		private static bool IsComboBoxOpeningInputEvent(RoutedEventArgs e)
		{
			KeyEventArgs keyEventArgs = e as KeyEventArgs;
			if (keyEventArgs != null && (byte)(keyEventArgs.KeyStates & KeyStates.Down) == 1)
			{
				bool flag = (keyEventArgs.KeyboardDevice.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt;
				Key key = keyEventArgs.Key;
				if (key == Key.System)
				{
					key = keyEventArgs.SystemKey;
				}
				return (key == Key.F4 && !flag) || ((key == Key.Up || key == Key.Down) && flag);
			}
			return false;
		}

		// Token: 0x04000030 RID: 48
		public static readonly DependencyProperty ElementStyleProperty = DataGridBoundColumn.ElementStyleProperty.AddOwner(typeof(DataGridComboBoxColumn), new FrameworkPropertyMetadata(DataGridComboBoxColumn.DefaultElementStyle));

		// Token: 0x04000031 RID: 49
		public static readonly DependencyProperty EditingElementStyleProperty = DataGridBoundColumn.EditingElementStyleProperty.AddOwner(typeof(DataGridComboBoxColumn), new FrameworkPropertyMetadata(DataGridComboBoxColumn.DefaultEditingElementStyle));

		// Token: 0x04000032 RID: 50
		public static readonly DependencyProperty ItemsSourceProperty = ItemsControl.ItemsSourceProperty.AddOwner(typeof(DataGridComboBoxColumn), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x04000033 RID: 51
		public static readonly DependencyProperty DisplayMemberPathProperty = ItemsControl.DisplayMemberPathProperty.AddOwner(typeof(DataGridComboBoxColumn), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x04000034 RID: 52
		public static readonly DependencyProperty SelectedValuePathProperty = Selector.SelectedValuePathProperty.AddOwner(typeof(DataGridComboBoxColumn), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x04000035 RID: 53
		private static Style _defaultElementStyle;

		// Token: 0x04000036 RID: 54
		private BindingBase _selectedValueBinding;

		// Token: 0x04000037 RID: 55
		private BindingBase _selectedItemBinding;

		// Token: 0x04000038 RID: 56
		private BindingBase _textBinding;

		// Token: 0x04000039 RID: 57
		private bool _selectedValueBindingEnsured = true;

		// Token: 0x0400003A RID: 58
		private bool _selectedItemBindingEnsured = true;

		// Token: 0x0400003B RID: 59
		private bool _textBindingEnsured = true;

		// Token: 0x0200000D RID: 13
		internal class TextBlockComboBox : ComboBox
		{
			// Token: 0x06000124 RID: 292 RVA: 0x00005424 File Offset: 0x00003624
			static TextBlockComboBox()
			{
				FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DataGridComboBoxColumn.TextBlockComboBox), new FrameworkPropertyMetadata(typeof(DataGridComboBoxColumn.TextBlockComboBox)));
				KeyboardNavigation.IsTabStopProperty.OverrideMetadata(typeof(DataGridComboBoxColumn.TextBlockComboBox), new FrameworkPropertyMetadata(false));
				FrameworkElement.DataContextProperty.OverrideMetadata(typeof(DataGridComboBoxColumn.TextBlockComboBox), new FrameworkPropertyMetadata(new PropertyChangedCallback(DataGridComboBoxColumn.TextBlockComboBox.OnDataContextPropertyChanged)));
			}

			// Token: 0x06000125 RID: 293 RVA: 0x00005498 File Offset: 0x00003698
			private static void OnDataContextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
			{
				DataGridComboBoxColumn.TextBlockComboBox textBlockComboBox = (DataGridComboBoxColumn.TextBlockComboBox)d;
				bool flag = DependencyPropertyHelper.GetValueSource(textBlockComboBox, Selector.SelectedItemProperty).BaseValueSource == BaseValueSource.Local;
				if (flag)
				{
					BindingBase bindingBase = BindingOperations.GetBindingBase(textBlockComboBox, Selector.SelectedItemProperty);
					if (bindingBase != null)
					{
						textBlockComboBox.ClearValue(Selector.SelectedItemProperty);
						DataGridComboBoxColumn.ApplyBinding(bindingBase, textBlockComboBox, Selector.SelectedItemProperty);
						return;
					}
				}
				else
				{
					textBlockComboBox.SelectedItem = null;
					textBlockComboBox.ClearValue(Selector.SelectedItemProperty);
				}
			}
		}
	}
}

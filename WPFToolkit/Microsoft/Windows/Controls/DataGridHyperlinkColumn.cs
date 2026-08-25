using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200000A RID: 10
	public class DataGridHyperlinkColumn : DataGridBoundColumn
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x00004488 File Offset: 0x00002688
		static DataGridHyperlinkColumn()
		{
			DataGridBoundColumn.ElementStyleProperty.OverrideMetadata(typeof(DataGridHyperlinkColumn), new FrameworkPropertyMetadata(DataGridHyperlinkColumn.DefaultElementStyle));
			DataGridBoundColumn.EditingElementStyleProperty.OverrideMetadata(typeof(DataGridHyperlinkColumn), new FrameworkPropertyMetadata(DataGridHyperlinkColumn.DefaultEditingElementStyle));
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x000044FC File Offset: 0x000026FC
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x0000450E File Offset: 0x0000270E
		public string TargetName
		{
			get
			{
				return (string)base.GetValue(DataGridHyperlinkColumn.TargetNameProperty);
			}
			set
			{
				base.SetValue(DataGridHyperlinkColumn.TargetNameProperty, value);
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000DA RID: 218 RVA: 0x0000451C File Offset: 0x0000271C
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00004524 File Offset: 0x00002724
		public BindingBase ContentBinding
		{
			get
			{
				return this._contentBinding;
			}
			set
			{
				if (this._contentBinding != value)
				{
					BindingBase contentBinding = this._contentBinding;
					this._contentBinding = value;
					this.OnContentBindingChanged(contentBinding, value);
				}
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004550 File Offset: 0x00002750
		protected virtual void OnContentBindingChanged(BindingBase oldBinding, BindingBase newBinding)
		{
			base.NotifyPropertyChanged("ContentBinding");
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000455D File Offset: 0x0000275D
		private void ApplyContentBinding(DependencyObject target, DependencyProperty property)
		{
			if (this.ContentBinding != null)
			{
				BindingOperations.SetBinding(target, property, this.ContentBinding);
				return;
			}
			if (this.Binding != null)
			{
				BindingOperations.SetBinding(target, property, this.Binding);
				return;
			}
			BindingOperations.ClearBinding(target, property);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00004594 File Offset: 0x00002794
		protected internal override void RefreshCellContent(FrameworkElement element, string propertyName)
		{
			DataGridCell dataGridCell = element as DataGridCell;
			if (dataGridCell != null && !dataGridCell.IsEditing)
			{
				if (string.Compare(propertyName, "ContentBinding", StringComparison.Ordinal) == 0)
				{
					dataGridCell.BuildVisualTree();
					return;
				}
				if (string.Compare(propertyName, "TargetName", StringComparison.Ordinal) == 0)
				{
					TextBlock textBlock = dataGridCell.Content as TextBlock;
					if (textBlock != null && textBlock.Inlines.Count > 0)
					{
						Hyperlink hyperlink = textBlock.Inlines.FirstInline as Hyperlink;
						if (hyperlink != null)
						{
							hyperlink.TargetName = this.TargetName;
							return;
						}
					}
				}
			}
			else
			{
				base.RefreshCellContent(element, propertyName);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000DF RID: 223 RVA: 0x0000461C File Offset: 0x0000281C
		public static Style DefaultElementStyle
		{
			get
			{
				return DataGridTextColumn.DefaultElementStyle;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00004623 File Offset: 0x00002823
		public static Style DefaultEditingElementStyle
		{
			get
			{
				return DataGridTextColumn.DefaultEditingElementStyle;
			}
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000462C File Offset: 0x0000282C
		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			TextBlock textBlock = new TextBlock();
			Hyperlink hyperlink = new Hyperlink();
			InlineUIContainer inlineUIContainer = new InlineUIContainer();
			ContentPresenter contentPresenter = new ContentPresenter();
			textBlock.Inlines.Add(hyperlink);
			hyperlink.Inlines.Add(inlineUIContainer);
			inlineUIContainer.Child = contentPresenter;
			hyperlink.TargetName = this.TargetName;
			base.ApplyStyle(false, false, textBlock);
			base.ApplyBinding(hyperlink, Hyperlink.NavigateUriProperty);
			this.ApplyContentBinding(contentPresenter, ContentPresenter.ContentProperty);
			return textBlock;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x000046A0 File Offset: 0x000028A0
		protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
		{
			TextBox textBox = new TextBox();
			base.ApplyStyle(true, false, textBox);
			base.ApplyBinding(textBox, TextBox.TextProperty);
			return textBox;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000046CC File Offset: 0x000028CC
		protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
		{
			TextBox textBox = editingElement as TextBox;
			if (textBox != null)
			{
				textBox.Focus();
				string text = textBox.Text;
				TextCompositionEventArgs textCompositionEventArgs = editingEventArgs as TextCompositionEventArgs;
				if (textCompositionEventArgs != null)
				{
					string text2 = textCompositionEventArgs.Text;
					textBox.Text = text2;
					textBox.Select(text2.Length, 0);
				}
				else
				{
					textBox.SelectAll();
				}
				return text;
			}
			return null;
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00004724 File Offset: 0x00002924
		protected override bool CommitCellEdit(FrameworkElement editingElement)
		{
			TextBox textBox = editingElement as TextBox;
			if (textBox != null)
			{
				DataGridHelper.UpdateSource(textBox, TextBox.TextProperty);
				return !Validation.GetHasError(textBox);
			}
			return true;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00004754 File Offset: 0x00002954
		protected override void CancelCellEdit(FrameworkElement editingElement, object uneditedValue)
		{
			TextBox textBox = editingElement as TextBox;
			if (textBox != null)
			{
				DataGridHelper.UpdateTarget(textBox, TextBox.TextProperty);
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00004776 File Offset: 0x00002976
		internal override void OnInput(InputEventArgs e)
		{
			if (DataGridHelper.HasNonEscapeCharacters(e as TextCompositionEventArgs))
			{
				base.BeginEdit(e);
			}
		}

		// Token: 0x0400002E RID: 46
		public static readonly DependencyProperty TargetNameProperty = Hyperlink.TargetNameProperty.AddOwner(typeof(DataGridHyperlinkColumn), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x0400002F RID: 47
		private BindingBase _contentBinding;
	}
}

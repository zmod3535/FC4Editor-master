using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000078 RID: 120
	public class DataGridTextColumn : DataGridBoundColumn
	{
		// Token: 0x06000899 RID: 2201 RVA: 0x000271AC File Offset: 0x000253AC
		static DataGridTextColumn()
		{
			DataGridBoundColumn.ElementStyleProperty.OverrideMetadata(typeof(DataGridTextColumn), new FrameworkPropertyMetadata(DataGridTextColumn.DefaultElementStyle));
			DataGridBoundColumn.EditingElementStyleProperty.OverrideMetadata(typeof(DataGridTextColumn), new FrameworkPropertyMetadata(DataGridTextColumn.DefaultEditingElementStyle));
		}

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x0600089A RID: 2202 RVA: 0x000272FC File Offset: 0x000254FC
		public static Style DefaultElementStyle
		{
			get
			{
				if (DataGridTextColumn._defaultElementStyle == null)
				{
					Style style = new Style(typeof(TextBlock));
					style.Setters.Add(new Setter(FrameworkElement.MarginProperty, new Thickness(2.0, 0.0, 2.0, 0.0)));
					style.Seal();
					DataGridTextColumn._defaultElementStyle = style;
				}
				return DataGridTextColumn._defaultElementStyle;
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x00027374 File Offset: 0x00025574
		public static Style DefaultEditingElementStyle
		{
			get
			{
				if (DataGridTextColumn._defaultEditingElementStyle == null)
				{
					Style style = new Style(typeof(TextBox));
					style.Setters.Add(new Setter(Control.BorderThicknessProperty, new Thickness(0.0)));
					style.Setters.Add(new Setter(Control.PaddingProperty, new Thickness(0.0)));
					style.Seal();
					DataGridTextColumn._defaultEditingElementStyle = style;
				}
				return DataGridTextColumn._defaultEditingElementStyle;
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x000273FC File Offset: 0x000255FC
		protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
		{
			TextBlock textBlock = new TextBlock();
			this.SyncProperties(textBlock);
			base.ApplyStyle(false, false, textBlock);
			base.ApplyBinding(textBlock, TextBlock.TextProperty);
			return textBlock;
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0002742C File Offset: 0x0002562C
		protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
		{
			TextBox textBox = new TextBox();
			this.SyncProperties(textBox);
			base.ApplyStyle(true, false, textBox);
			base.ApplyBinding(textBox, TextBox.TextProperty);
			return textBox;
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0002745C File Offset: 0x0002565C
		private void SyncProperties(FrameworkElement e)
		{
			DataGridHelper.SyncColumnProperty(this, e, TextElement.FontFamilyProperty, DataGridTextColumn.FontFamilyProperty);
			DataGridHelper.SyncColumnProperty(this, e, TextElement.FontSizeProperty, DataGridTextColumn.FontSizeProperty);
			DataGridHelper.SyncColumnProperty(this, e, TextElement.FontStyleProperty, DataGridTextColumn.FontStyleProperty);
			DataGridHelper.SyncColumnProperty(this, e, TextElement.FontWeightProperty, DataGridTextColumn.FontWeightProperty);
			DataGridHelper.SyncColumnProperty(this, e, TextElement.ForegroundProperty, DataGridTextColumn.ForegroundProperty);
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x000274C0 File Offset: 0x000256C0
		protected internal override void RefreshCellContent(FrameworkElement element, string propertyName)
		{
			DataGridCell dataGridCell = element as DataGridCell;
			if (dataGridCell != null)
			{
				FrameworkElement frameworkElement = dataGridCell.Content as FrameworkElement;
				if (frameworkElement != null && propertyName != null)
				{
					if (!(propertyName == "FontFamily"))
					{
						if (!(propertyName == "FontSize"))
						{
							if (!(propertyName == "FontStyle"))
							{
								if (!(propertyName == "FontWeight"))
								{
									if (propertyName == "Foreground")
									{
										DataGridHelper.SyncColumnProperty(this, frameworkElement, TextElement.ForegroundProperty, DataGridTextColumn.ForegroundProperty);
									}
								}
								else
								{
									DataGridHelper.SyncColumnProperty(this, frameworkElement, TextElement.FontWeightProperty, DataGridTextColumn.FontWeightProperty);
								}
							}
							else
							{
								DataGridHelper.SyncColumnProperty(this, frameworkElement, TextElement.FontStyleProperty, DataGridTextColumn.FontStyleProperty);
							}
						}
						else
						{
							DataGridHelper.SyncColumnProperty(this, frameworkElement, TextElement.FontSizeProperty, DataGridTextColumn.FontSizeProperty);
						}
					}
					else
					{
						DataGridHelper.SyncColumnProperty(this, frameworkElement, TextElement.FontFamilyProperty, DataGridTextColumn.FontFamilyProperty);
					}
				}
			}
			base.RefreshCellContent(element, propertyName);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x0002759C File Offset: 0x0002579C
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
					MouseButtonEventArgs mouseButtonEventArgs = editingEventArgs as MouseButtonEventArgs;
					if (mouseButtonEventArgs == null || !DataGridTextColumn.PlaceCaretOnTextBox(textBox, Mouse.GetPosition(textBox)))
					{
						textBox.SelectAll();
					}
				}
				return text;
			}
			return null;
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0002760C File Offset: 0x0002580C
		private static bool PlaceCaretOnTextBox(TextBox textBox, Point position)
		{
			int characterIndexFromPoint = textBox.GetCharacterIndexFromPoint(position, false);
			if (characterIndexFromPoint >= 0)
			{
				textBox.Select(characterIndexFromPoint, 0);
				return true;
			}
			return false;
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x00027634 File Offset: 0x00025834
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

		// Token: 0x060008A3 RID: 2211 RVA: 0x00027664 File Offset: 0x00025864
		protected override void CancelCellEdit(FrameworkElement editingElement, object uneditedValue)
		{
			TextBox textBox = editingElement as TextBox;
			if (textBox != null)
			{
				DataGridHelper.UpdateTarget(textBox, TextBox.TextProperty);
			}
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00027686 File Offset: 0x00025886
		internal override void OnInput(InputEventArgs e)
		{
			if (DataGridHelper.HasNonEscapeCharacters(e as TextCompositionEventArgs))
			{
				base.BeginEdit(e);
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x0002769C File Offset: 0x0002589C
		// (set) Token: 0x060008A6 RID: 2214 RVA: 0x000276AE File Offset: 0x000258AE
		public FontFamily FontFamily
		{
			get
			{
				return (FontFamily)base.GetValue(DataGridTextColumn.FontFamilyProperty);
			}
			set
			{
				base.SetValue(DataGridTextColumn.FontFamilyProperty, value);
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x000276BC File Offset: 0x000258BC
		// (set) Token: 0x060008A8 RID: 2216 RVA: 0x000276CE File Offset: 0x000258CE
		[Localizability(LocalizationCategory.None)]
		[TypeConverter(typeof(FontSizeConverter))]
		public double FontSize
		{
			get
			{
				return (double)base.GetValue(DataGridTextColumn.FontSizeProperty);
			}
			set
			{
				base.SetValue(DataGridTextColumn.FontSizeProperty, value);
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060008A9 RID: 2217 RVA: 0x000276E1 File Offset: 0x000258E1
		// (set) Token: 0x060008AA RID: 2218 RVA: 0x000276F3 File Offset: 0x000258F3
		public FontStyle FontStyle
		{
			get
			{
				return (FontStyle)base.GetValue(DataGridTextColumn.FontStyleProperty);
			}
			set
			{
				base.SetValue(DataGridTextColumn.FontStyleProperty, value);
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060008AB RID: 2219 RVA: 0x00027706 File Offset: 0x00025906
		// (set) Token: 0x060008AC RID: 2220 RVA: 0x00027718 File Offset: 0x00025918
		public FontWeight FontWeight
		{
			get
			{
				return (FontWeight)base.GetValue(DataGridTextColumn.FontWeightProperty);
			}
			set
			{
				base.SetValue(DataGridTextColumn.FontWeightProperty, value);
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060008AD RID: 2221 RVA: 0x0002772B File Offset: 0x0002592B
		// (set) Token: 0x060008AE RID: 2222 RVA: 0x0002773D File Offset: 0x0002593D
		public Brush Foreground
		{
			get
			{
				return (Brush)base.GetValue(DataGridTextColumn.ForegroundProperty);
			}
			set
			{
				base.SetValue(DataGridTextColumn.ForegroundProperty, value);
			}
		}

		// Token: 0x040002A5 RID: 677
		public static readonly DependencyProperty FontFamilyProperty = TextElement.FontFamilyProperty.AddOwner(typeof(DataGridTextColumn), new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x040002A6 RID: 678
		public static readonly DependencyProperty FontSizeProperty = TextElement.FontSizeProperty.AddOwner(typeof(DataGridTextColumn), new FrameworkPropertyMetadata(SystemFonts.MessageFontSize, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x040002A7 RID: 679
		public static readonly DependencyProperty FontStyleProperty = TextElement.FontStyleProperty.AddOwner(typeof(DataGridTextColumn), new FrameworkPropertyMetadata(SystemFonts.MessageFontStyle, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x040002A8 RID: 680
		public static readonly DependencyProperty FontWeightProperty = TextElement.FontWeightProperty.AddOwner(typeof(DataGridTextColumn), new FrameworkPropertyMetadata(SystemFonts.MessageFontWeight, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x040002A9 RID: 681
		public static readonly DependencyProperty ForegroundProperty = TextElement.ForegroundProperty.AddOwner(typeof(DataGridTextColumn), new FrameworkPropertyMetadata(SystemColors.ControlTextBrush, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(DataGridColumn.NotifyPropertyChangeForRefreshContent)));

		// Token: 0x040002AA RID: 682
		private static Style _defaultElementStyle;

		// Token: 0x040002AB RID: 683
		private static Style _defaultEditingElementStyle;
	}
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Microsoft.Windows.Controls.Primitives
{
	// Token: 0x02000077 RID: 119
	[System.Windows.TemplateVisualState(Name = "Watermarked", GroupName = "WatermarkStates")]
	[System.Windows.TemplateVisualState(Name = "Unwatermarked", GroupName = "WatermarkStates")]
	[TemplatePart(Name = "Watermark", Type = typeof(ContentControl))]
	[System.Windows.TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "MouseOver", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "Unfocused", GroupName = "FocusStates")]
	[System.Windows.TemplateVisualState(Name = "Focused", GroupName = "FocusStates")]
	public sealed class DatePickerTextBox : TextBox
	{
		// Token: 0x06000888 RID: 2184 RVA: 0x00026E60 File Offset: 0x00025060
		static DatePickerTextBox()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DatePickerTextBox), new FrameworkPropertyMetadata(typeof(DatePickerTextBox)));
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00026EC4 File Offset: 0x000250C4
		public DatePickerTextBox()
		{
			this.Watermark = SR.Get(SRID.DatePickerTextBox_DefaultWatermarkText);
			base.Loaded += this.OnLoaded;
			base.IsEnabledChanged += this.OnDatePickerTextBoxIsEnabledChanged;
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x00026F00 File Offset: 0x00025100
		// (set) Token: 0x0600088B RID: 2187 RVA: 0x00026F0D File Offset: 0x0002510D
		internal object Watermark
		{
			get
			{
				return base.GetValue(DatePickerTextBox.WatermarkProperty);
			}
			set
			{
				base.SetValue(DatePickerTextBox.WatermarkProperty, value);
			}
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00026F1B File Offset: 0x0002511B
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.elementContent = this.ExtractTemplatePart<ContentControl>("Watermark");
			this.OnWatermarkChanged();
			this.ChangeVisualState(false);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00026F41 File Offset: 0x00025141
		protected override void OnGotFocus(RoutedEventArgs e)
		{
			base.OnGotFocus(e);
			if (base.IsEnabled)
			{
				if (!string.IsNullOrEmpty(base.Text))
				{
					base.Select(0, base.Text.Length);
				}
				this.ChangeVisualState(true);
			}
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00026F78 File Offset: 0x00025178
		protected override void OnLostFocus(RoutedEventArgs e)
		{
			base.OnLostFocus(e);
			this.ChangeVisualState(true);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00026F88 File Offset: 0x00025188
		protected override void OnMouseEnter(MouseEventArgs e)
		{
			base.OnMouseEnter(e);
			this.isHovered = true;
			if (!base.IsFocused)
			{
				this.ChangeVisualState(true);
			}
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00026FA7 File Offset: 0x000251A7
		protected override void OnMouseLeave(MouseEventArgs e)
		{
			base.OnMouseLeave(e);
			this.isHovered = false;
			if (!base.IsFocused)
			{
				this.ChangeVisualState(true);
			}
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00026FC6 File Offset: 0x000251C6
		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			base.OnTextChanged(e);
			this.ChangeVisualState(true);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00026FD6 File Offset: 0x000251D6
		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			base.ApplyTemplate();
			this.ChangeVisualState(false);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00026FE8 File Offset: 0x000251E8
		private void ChangeVisualState(bool useTransitions)
		{
			if (!base.IsEnabled)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Disabled",
					"Normal"
				});
			}
			else if (this.isHovered)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"MouseOver",
					"Normal"
				});
			}
			else
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Normal"
				});
			}
			if (base.IsFocused && base.IsEnabled)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Focused",
					"Unfocused"
				});
			}
			else
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Unfocused"
				});
			}
			if (this.Watermark != null && string.IsNullOrEmpty(base.Text))
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Watermarked",
					"Unwatermarked"
				});
				return;
			}
			VisualStates.GoToState(this, useTransitions, new string[]
			{
				"Unwatermarked"
			});
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x000270FC File Offset: 0x000252FC
		private T ExtractTemplatePart<T>(string partName) where T : DependencyObject
		{
			DependencyObject templateChild = base.GetTemplateChild(partName);
			return DatePickerTextBox.ExtractTemplatePart<T>(partName, templateChild);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00027118 File Offset: 0x00025318
		private static T ExtractTemplatePart<T>(string partName, DependencyObject obj) where T : DependencyObject
		{
			return obj as T;
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00027128 File Offset: 0x00025328
		private void OnDatePickerTextBoxIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			bool flag = (bool)e.NewValue;
			base.IsReadOnly = !flag;
			this.ChangeVisualState(true);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00027154 File Offset: 0x00025354
		private void OnWatermarkChanged()
		{
			if (this.elementContent != null)
			{
				Control control = this.Watermark as Control;
				if (control != null)
				{
					control.IsTabStop = false;
					control.IsHitTestVisible = false;
				}
			}
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00027188 File Offset: 0x00025388
		private static void OnWatermarkPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			DatePickerTextBox datePickerTextBox = sender as DatePickerTextBox;
			datePickerTextBox.OnWatermarkChanged();
			datePickerTextBox.ChangeVisualState(true);
		}

		// Token: 0x040002A1 RID: 673
		private const string ElementContentName = "Watermark";

		// Token: 0x040002A2 RID: 674
		private ContentControl elementContent;

		// Token: 0x040002A3 RID: 675
		private bool isHovered;

		// Token: 0x040002A4 RID: 676
		internal static readonly DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark", typeof(object), typeof(DatePickerTextBox), new PropertyMetadata(new PropertyChangedCallback(DatePickerTextBox.OnWatermarkPropertyChanged)));
	}
}

using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IGE.ViewModels.Behaviours
{
	// Token: 0x020000A1 RID: 161
	public static class MaskBehaviour
	{
		// Token: 0x0600069A RID: 1690 RVA: 0x00017F49 File Offset: 0x00016149
		public static string GetMask(TextBox textBox)
		{
			if (textBox == null)
			{
				throw new ArgumentNullException("textBox");
			}
			return textBox.GetValue(MaskBehaviour.MaskProperty) as string;
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00017F69 File Offset: 0x00016169
		public static void SetMask(TextBox textBox, string mask)
		{
			if (textBox == null)
			{
				throw new ArgumentNullException("textBox");
			}
			textBox.SetValue(MaskBehaviour.MaskProperty, mask);
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00017F85 File Offset: 0x00016185
		public static Regex GetMaskExpression(TextBox textBox)
		{
			if (textBox == null)
			{
				throw new ArgumentNullException("textBox");
			}
			return textBox.GetValue(MaskBehaviour.MaskExpressionProperty) as Regex;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00017FA5 File Offset: 0x000161A5
		private static void SetMaskExpression(TextBox textBox, Regex regex)
		{
			textBox.SetValue(MaskBehaviour._maskExpressionPropertyKey, regex);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00017FB4 File Offset: 0x000161B4
		private static void OnMaskChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			TextBox textBox = dependencyObject as TextBox;
			string text = e.NewValue as string;
			textBox.PreviewTextInput -= MaskBehaviour.textBox_PreviewTextInput;
			textBox.PreviewKeyDown -= MaskBehaviour.textBox_PreviewKeyDown;
			DataObject.RemovePastingHandler(textBox, new DataObjectPastingEventHandler(MaskBehaviour.Pasting));
			DataObject.RemoveCopyingHandler(textBox, new DataObjectCopyingEventHandler(MaskBehaviour.NoDragCopy));
			CommandManager.RemovePreviewExecutedHandler(textBox, new ExecutedRoutedEventHandler(MaskBehaviour.NoCutting));
			if (text == null)
			{
				textBox.ClearValue(MaskBehaviour.MaskProperty);
				textBox.ClearValue(MaskBehaviour.MaskExpressionProperty);
				return;
			}
			textBox.SetValue(MaskBehaviour.MaskProperty, text);
			MaskBehaviour.SetMaskExpression(textBox, new Regex(text, RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace));
			textBox.PreviewTextInput += MaskBehaviour.textBox_PreviewTextInput;
			textBox.PreviewKeyDown += MaskBehaviour.textBox_PreviewKeyDown;
			DataObject.AddPastingHandler(textBox, new DataObjectPastingEventHandler(MaskBehaviour.Pasting));
			DataObject.AddCopyingHandler(textBox, new DataObjectCopyingEventHandler(MaskBehaviour.NoDragCopy));
			CommandManager.AddPreviewExecutedHandler(textBox, new ExecutedRoutedEventHandler(MaskBehaviour.NoCutting));
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x000180BD File Offset: 0x000162BD
		private static void NoCutting(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Command == ApplicationCommands.Cut)
			{
				e.Handled = true;
			}
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x000180D3 File Offset: 0x000162D3
		private static void NoDragCopy(object sender, DataObjectCopyingEventArgs e)
		{
			if (e.IsDragDrop)
			{
				e.CancelCommand();
			}
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x000180E4 File Offset: 0x000162E4
		private static void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			Regex maskExpression = MaskBehaviour.GetMaskExpression(textBox);
			if (maskExpression == null)
			{
				return;
			}
			string proposedText = MaskBehaviour.GetProposedText(textBox, e.Text);
			if (!maskExpression.IsMatch(proposedText))
			{
				e.Handled = true;
			}
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00018120 File Offset: 0x00016320
		private static void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			Regex maskExpression = MaskBehaviour.GetMaskExpression(textBox);
			if (maskExpression == null)
			{
				return;
			}
			string text = null;
			if (e.Key == Key.Space)
			{
				text = MaskBehaviour.GetProposedText(textBox, " ");
			}
			else if (e.Key == Key.Back)
			{
				text = MaskBehaviour.GetProposedTextBackspace(textBox);
			}
			if (text != null && text != string.Empty && !maskExpression.IsMatch(text))
			{
				e.Handled = true;
			}
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0001818C File Offset: 0x0001638C
		private static void Pasting(object sender, DataObjectPastingEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			Regex maskExpression = MaskBehaviour.GetMaskExpression(textBox);
			if (maskExpression == null)
			{
				return;
			}
			if (e.DataObject.GetDataPresent(typeof(string)))
			{
				string newText = e.DataObject.GetData(typeof(string)) as string;
				string proposedText = MaskBehaviour.GetProposedText(textBox, newText);
				if (!maskExpression.IsMatch(proposedText))
				{
					e.CancelCommand();
					return;
				}
			}
			else
			{
				e.CancelCommand();
			}
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x000181FC File Offset: 0x000163FC
		private static string GetProposedTextBackspace(TextBox textBox)
		{
			string text = MaskBehaviour.GetTextWithSelectionRemoved(textBox);
			if (textBox.SelectionStart > 0 && textBox.SelectionLength == 0)
			{
				text = text.Remove(textBox.SelectionStart - 1, 1);
			}
			return text;
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00018234 File Offset: 0x00016434
		private static string GetProposedText(TextBox textBox, string newText)
		{
			string textWithSelectionRemoved = MaskBehaviour.GetTextWithSelectionRemoved(textBox);
			return textWithSelectionRemoved.Insert(textBox.CaretIndex, newText);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00018258 File Offset: 0x00016458
		private static string GetTextWithSelectionRemoved(TextBox textBox)
		{
			string text = textBox.Text;
			if (textBox.SelectionStart != -1)
			{
				text = text.Remove(textBox.SelectionStart, textBox.SelectionLength);
			}
			return text;
		}

		// Token: 0x040002A6 RID: 678
		private static readonly DependencyPropertyKey _maskExpressionPropertyKey = DependencyProperty.RegisterAttachedReadOnly("MaskExpression", typeof(Regex), typeof(MaskBehaviour), new FrameworkPropertyMetadata());

		// Token: 0x040002A7 RID: 679
		public static readonly DependencyProperty MaskProperty = DependencyProperty.RegisterAttached("Mask", typeof(string), typeof(MaskBehaviour), new FrameworkPropertyMetadata(new PropertyChangedCallback(MaskBehaviour.OnMaskChanged)));

		// Token: 0x040002A8 RID: 680
		public static readonly DependencyProperty MaskExpressionProperty = MaskBehaviour._maskExpressionPropertyKey.DependencyProperty;
	}
}

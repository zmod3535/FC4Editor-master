using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace IGE.Controls
{
	// Token: 0x020000A3 RID: 163
	public class BindableRichTextBox : RichTextBox
	{
		// Token: 0x1700018A RID: 394
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x0001867B File Offset: 0x0001687B
		// (set) Token: 0x060006B1 RID: 1713 RVA: 0x0001868D File Offset: 0x0001688D
		public new FlowDocument Document
		{
			get
			{
				return (FlowDocument)base.GetValue(BindableRichTextBox.DocumentProperty);
			}
			set
			{
				base.SetValue(BindableRichTextBox.DocumentProperty, value);
			}
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0001869C File Offset: 0x0001689C
		public static void OnDocumentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{
			RichTextBox richTextBox = (RichTextBox)obj;
			richTextBox.Document = (FlowDocument)args.NewValue;
		}

		// Token: 0x040002AA RID: 682
		public static readonly DependencyProperty DocumentProperty = DependencyProperty.Register("Document", typeof(FlowDocument), typeof(BindableRichTextBox), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(BindableRichTextBox.OnDocumentChanged)));
	}
}

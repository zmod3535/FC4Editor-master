using System;
using System.Windows;
using System.Windows.Controls;

namespace Divelements.SandDock.Primitives
{
	// Token: 0x02000064 RID: 100
	public class SystemCaptionButton : Button
	{
		// Token: 0x060004B1 RID: 1201 RVA: 0x00047684 File Offset: 0x00045A84
		static SystemCaptionButton()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SystemCaptionButton), new FrameworkPropertyMetadata(typeof(SystemCaptionButton)));
			UIElement.FocusableProperty.OverrideMetadata(typeof(SystemCaptionButton), new FrameworkPropertyMetadata(false));
			Control.HorizontalContentAlignmentProperty.OverrideMetadata(typeof(SystemCaptionButton), new FrameworkPropertyMetadata(HorizontalAlignment.Center));
			Control.VerticalContentAlignmentProperty.OverrideMetadata(typeof(SystemCaptionButton), new FrameworkPropertyMetadata(VerticalAlignment.Center));
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060004B3 RID: 1203 RVA: 0x00047750 File Offset: 0x00045B50
		// (set) Token: 0x060004B4 RID: 1204 RVA: 0x00047764 File Offset: 0x00045B64
		public CornerRadius CornerRadius
		{
			get
			{
				return (CornerRadius)base.GetValue(SystemCaptionButton.CornerRadiusProperty);
			}
			set
			{
				base.SetValue(SystemCaptionButton.CornerRadiusProperty, value);
			}
		}

		// Token: 0x0400020C RID: 524
		public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(SystemCaptionButton), new FrameworkPropertyMetadata(default(CornerRadius)));
	}
}

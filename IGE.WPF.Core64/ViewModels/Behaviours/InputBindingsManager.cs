using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace IGE.ViewModels.Behaviours
{
	// Token: 0x020000BF RID: 191
	public static class InputBindingsManager
	{
		// Token: 0x0600074C RID: 1868 RVA: 0x0001A984 File Offset: 0x00018B84
		public static void SetUpdatePropertySourceWhenEnterPressed(DependencyObject dp, DependencyProperty value)
		{
			dp.SetValue(InputBindingsManager.UpdatePropertySourceWhenEnterPressedProperty, value);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x0001A992 File Offset: 0x00018B92
		public static DependencyProperty GetUpdatePropertySourceWhenEnterPressed(DependencyObject dp)
		{
			return (DependencyProperty)dp.GetValue(InputBindingsManager.UpdatePropertySourceWhenEnterPressedProperty);
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0001A9A4 File Offset: 0x00018BA4
		private static void OnUpdatePropertySourceWhenEnterPressedPropertyChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
		{
			UIElement uielement = dp as UIElement;
			if (uielement == null)
			{
				return;
			}
			if (e.OldValue != null)
			{
				uielement.PreviewKeyDown -= InputBindingsManager.HandlePreviewKeyDown;
			}
			if (e.NewValue != null)
			{
				uielement.PreviewKeyDown += InputBindingsManager.HandlePreviewKeyDown;
			}
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0001A9F2 File Offset: 0x00018BF2
		private static void HandlePreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				InputBindingsManager.DoUpdateSource(e.Source);
			}
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0001AA08 File Offset: 0x00018C08
		private static void DoUpdateSource(object source)
		{
			DependencyProperty updatePropertySourceWhenEnterPressed = InputBindingsManager.GetUpdatePropertySourceWhenEnterPressed(source as DependencyObject);
			if (updatePropertySourceWhenEnterPressed == null)
			{
				return;
			}
			UIElement uielement = source as UIElement;
			if (uielement == null)
			{
				return;
			}
			BindingExpression bindingExpression = BindingOperations.GetBindingExpression(uielement, updatePropertySourceWhenEnterPressed);
			if (bindingExpression != null)
			{
				bindingExpression.UpdateSource();
			}
		}

		// Token: 0x040002F8 RID: 760
		public static readonly DependencyProperty UpdatePropertySourceWhenEnterPressedProperty = DependencyProperty.RegisterAttached("UpdatePropertySourceWhenEnterPressed", typeof(DependencyProperty), typeof(InputBindingsManager), new PropertyMetadata(null, new PropertyChangedCallback(InputBindingsManager.OnUpdatePropertySourceWhenEnterPressedPropertyChanged)));
	}
}

using System;
using System.Windows;
using System.Windows.Controls;

namespace IGE.ViewModels.Behaviours
{
	// Token: 0x02000393 RID: 915
	public class ComboBoxItemTemplateChooser : DataTemplateSelector
	{
		// Token: 0x06001492 RID: 5266 RVA: 0x0002BC12 File Offset: 0x00029E12
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static DataTemplate GetSelectedTemplate(ComboBox obj)
		{
			return (DataTemplate)obj.GetValue(ComboBoxItemTemplateChooser.SelectedTemplateProperty);
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x0002BC24 File Offset: 0x00029E24
		public static void SetSelectedTemplate(ComboBox obj, DataTemplate value)
		{
			obj.SetValue(ComboBoxItemTemplateChooser.SelectedTemplateProperty, value);
		}

		// Token: 0x06001494 RID: 5268 RVA: 0x0002BC32 File Offset: 0x00029E32
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static DataTemplate GetDropDownTemplate(ComboBox obj)
		{
			return (DataTemplate)obj.GetValue(ComboBoxItemTemplateChooser.DropDownTemplateProperty);
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x0002BC44 File Offset: 0x00029E44
		public static void SetDropDownTemplate(ComboBox obj, DataTemplate value)
		{
			obj.SetValue(ComboBoxItemTemplateChooser.DropDownTemplateProperty, value);
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x0002BC54 File Offset: 0x00029E54
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			ComboBoxItem visualParent = container.GetVisualParent<ComboBoxItem>();
			ComboBox obj;
			if (visualParent == null)
			{
				obj = container.GetVisualParent<ComboBox>();
				return ComboBoxItemTemplateChooser.GetSelectedTemplate(obj);
			}
			obj = (ItemsControl.ItemsControlFromItemContainer(visualParent) as ComboBox);
			return ComboBoxItemTemplateChooser.GetDropDownTemplate(obj);
		}

		// Token: 0x04000788 RID: 1928
		public static DependencyProperty SelectedTemplateProperty = DependencyProperty.RegisterAttached("SelectedTemplate", typeof(DataTemplate), typeof(ComboBoxItemTemplateChooser), new UIPropertyMetadata(null));

		// Token: 0x04000789 RID: 1929
		public static DependencyProperty DropDownTemplateProperty = DependencyProperty.RegisterAttached("DropDownTemplate", typeof(DataTemplate), typeof(ComboBoxItemTemplateChooser), new UIPropertyMetadata(null));
	}
}

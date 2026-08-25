using System;
using System.Windows;
using System.Windows.Controls;

namespace IGE.Helpers
{
	// Token: 0x02000069 RID: 105
	public class ComboBoxItemTemplateSelector : DataTemplateSelector
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x00011A65 File Offset: 0x0000FC65
		// (set) Token: 0x0600047A RID: 1146 RVA: 0x00011A6D File Offset: 0x0000FC6D
		public DataTemplate SelectedTemplate { get; set; }

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x00011A76 File Offset: 0x0000FC76
		// (set) Token: 0x0600047C RID: 1148 RVA: 0x00011A7E File Offset: 0x0000FC7E
		public DataTemplate DropDownTemplate { get; set; }

		// Token: 0x0600047D RID: 1149 RVA: 0x00011A88 File Offset: 0x0000FC88
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (container.GetVisualParent<ComboBoxItem>() == null)
			{
				return this.SelectedTemplate;
			}
			return this.DropDownTemplate;
		}
	}
}

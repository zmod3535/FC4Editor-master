using System;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200006B RID: 107
	public class ListBoxItemBehavior : ControlBehavior
	{
		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x00022C05 File Offset: 0x00020E05
		protected internal override Type TargetType
		{
			get
			{
				return typeof(ListBoxItem);
			}
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00022C14 File Offset: 0x00020E14
		protected override void OnAttach(Control control)
		{
			base.OnAttach(control);
			ListBoxItem instance = (ListBoxItem)control;
			Type typeFromHandle = typeof(ListBoxItem);
			VisualStateBehavior.AddValueChanged(UIElement.IsMouseOverProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.AddValueChanged(ListBoxItem.IsSelectedProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00022C70 File Offset: 0x00020E70
		protected override void OnDetach(Control control)
		{
			base.OnDetach(control);
			ListBoxItem instance = (ListBoxItem)control;
			Type typeFromHandle = typeof(ListBoxItem);
			VisualStateBehavior.RemoveValueChanged(UIElement.IsMouseOverProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.RemoveValueChanged(ListBoxItem.IsSelectedProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00022CCC File Offset: 0x00020ECC
		protected override void UpdateState(Control control, bool useTransitions)
		{
			ListBoxItem listBoxItem = (ListBoxItem)control;
			if (listBoxItem.IsMouseOver)
			{
				System.Windows.VisualStateManager.GoToState(listBoxItem, "MouseOver", useTransitions);
			}
			else
			{
				System.Windows.VisualStateManager.GoToState(listBoxItem, "Normal", useTransitions);
			}
			if (listBoxItem.IsSelected)
			{
				System.Windows.VisualStateManager.GoToState(listBoxItem, "Selected", useTransitions);
			}
			else
			{
				System.Windows.VisualStateManager.GoToState(listBoxItem, "Unselected", useTransitions);
			}
			base.UpdateState(control, useTransitions);
		}
	}
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200004C RID: 76
	public class ButtonBaseBehavior : ControlBehavior
	{
		// Token: 0x1700016F RID: 367
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x0001805E File Offset: 0x0001625E
		protected internal override Type TargetType
		{
			get
			{
				return typeof(ButtonBase);
			}
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0001806C File Offset: 0x0001626C
		protected override void OnAttach(Control control)
		{
			base.OnAttach(control);
			ButtonBase instance = (ButtonBase)control;
			Type typeFromHandle = typeof(ButtonBase);
			VisualStateBehavior.AddValueChanged(UIElement.IsMouseOverProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.AddValueChanged(UIElement.IsEnabledProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.AddValueChanged(ButtonBase.IsPressedProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x000180E0 File Offset: 0x000162E0
		protected override void OnDetach(Control control)
		{
			base.OnDetach(control);
			ButtonBase instance = (ButtonBase)control;
			Type typeFromHandle = typeof(ButtonBase);
			VisualStateBehavior.RemoveValueChanged(UIElement.IsMouseOverProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.RemoveValueChanged(UIElement.IsEnabledProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.RemoveValueChanged(ButtonBase.IsPressedProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00018154 File Offset: 0x00016354
		protected override void UpdateState(Control control, bool useTransitions)
		{
			ButtonBase buttonBase = (ButtonBase)control;
			if (!buttonBase.IsEnabled)
			{
				System.Windows.VisualStateManager.GoToState(buttonBase, "Disabled", useTransitions);
			}
			else if (buttonBase.IsPressed)
			{
				System.Windows.VisualStateManager.GoToState(buttonBase, "Pressed", useTransitions);
			}
			else if (buttonBase.IsMouseOver)
			{
				System.Windows.VisualStateManager.GoToState(buttonBase, "MouseOver", useTransitions);
			}
			else
			{
				System.Windows.VisualStateManager.GoToState(buttonBase, "Normal", useTransitions);
			}
			base.UpdateState(control, useTransitions);
		}
	}
}

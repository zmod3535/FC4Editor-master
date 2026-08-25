using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200007C RID: 124
	public class ToggleButtonBehavior : ButtonBaseBehavior
	{
		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x0002795E File Offset: 0x00025B5E
		protected internal override Type TargetType
		{
			get
			{
				return typeof(ToggleButton);
			}
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0002796C File Offset: 0x00025B6C
		protected override void OnAttach(Control control)
		{
			base.OnAttach(control);
			ToggleButton instance = (ToggleButton)control;
			Type typeFromHandle = typeof(ToggleButton);
			VisualStateBehavior.AddValueChanged(ToggleButton.IsCheckedProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x000279AC File Offset: 0x00025BAC
		protected override void OnDetach(Control control)
		{
			base.OnDetach(control);
			ToggleButton instance = (ToggleButton)control;
			Type typeFromHandle = typeof(ToggleButton);
			VisualStateBehavior.RemoveValueChanged(ToggleButton.IsCheckedProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x000279EC File Offset: 0x00025BEC
		protected override void UpdateState(Control control, bool useTransitions)
		{
			ToggleButton toggleButton = (ToggleButton)control;
			if (toggleButton.IsChecked == null)
			{
				System.Windows.VisualStateManager.GoToState(toggleButton, "Indeterminate", useTransitions);
			}
			else if (toggleButton.IsChecked.Value)
			{
				System.Windows.VisualStateManager.GoToState(toggleButton, "Checked", useTransitions);
			}
			else
			{
				System.Windows.VisualStateManager.GoToState(toggleButton, "Unchecked", useTransitions);
			}
			base.UpdateState(control, useTransitions);
		}
	}
}

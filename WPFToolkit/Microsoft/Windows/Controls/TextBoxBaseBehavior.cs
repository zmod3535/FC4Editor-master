using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000005 RID: 5
	public class TextBoxBaseBehavior : ControlBehavior
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000020 RID: 32 RVA: 0x000024E3 File Offset: 0x000006E3
		protected internal override Type TargetType
		{
			get
			{
				return typeof(TextBoxBase);
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000024F0 File Offset: 0x000006F0
		protected override void OnAttach(Control control)
		{
			base.OnAttach(control);
			TextBoxBase instance = (TextBoxBase)control;
			Type typeFromHandle = typeof(TextBoxBase);
			VisualStateBehavior.AddValueChanged(UIElement.IsMouseOverProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.AddValueChanged(UIElement.IsEnabledProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.AddValueChanged(TextBoxBase.IsReadOnlyProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002564 File Offset: 0x00000764
		protected override void OnDetach(Control control)
		{
			base.OnDetach(control);
			TextBoxBase instance = (TextBoxBase)control;
			Type typeFromHandle = typeof(TextBoxBase);
			VisualStateBehavior.RemoveValueChanged(UIElement.IsMouseOverProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.RemoveValueChanged(UIElement.IsEnabledProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
			VisualStateBehavior.RemoveValueChanged(TextBoxBase.IsReadOnlyProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000025D8 File Offset: 0x000007D8
		protected override void UpdateState(Control control, bool useTransitions)
		{
			TextBoxBase textBoxBase = (TextBoxBase)control;
			if (!textBoxBase.IsEnabled)
			{
				System.Windows.VisualStateManager.GoToState(textBoxBase, "Disabled", useTransitions);
			}
			else if (textBoxBase.IsReadOnly)
			{
				System.Windows.VisualStateManager.GoToState(textBoxBase, "ReadOnly", useTransitions);
			}
			else if (textBoxBase.IsMouseOver)
			{
				System.Windows.VisualStateManager.GoToState(textBoxBase, "MouseOver", useTransitions);
			}
			else
			{
				System.Windows.VisualStateManager.GoToState(textBoxBase, "Normal", useTransitions);
			}
			base.UpdateState(control, useTransitions);
		}
	}
}

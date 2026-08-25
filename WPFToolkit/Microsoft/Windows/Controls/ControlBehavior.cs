using System;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000004 RID: 4
	public class ControlBehavior : VisualStateBehavior
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000023DC File Offset: 0x000005DC
		protected internal override Type TargetType
		{
			get
			{
				return typeof(Control);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002404 File Offset: 0x00000604
		protected override void OnAttach(Control control)
		{
			control.Loaded += delegate(object sender, RoutedEventArgs e)
			{
				this.UpdateState(control, false);
			};
			VisualStateBehavior.AddValueChanged(UIElement.IsKeyboardFocusWithinProperty, typeof(Control), control, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002464 File Offset: 0x00000664
		protected override void OnDetach(Control control)
		{
			VisualStateBehavior.RemoveValueChanged(UIElement.IsKeyboardFocusWithinProperty, typeof(Control), control, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000248C File Offset: 0x0000068C
		protected override void UpdateStateHandler(object o, EventArgs e)
		{
			Control control = o as Control;
			if (control == null)
			{
				throw new InvalidOperationException("This should never be used on anything other than a control.");
			}
			this.UpdateState(control, true);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024B6 File Offset: 0x000006B6
		protected override void UpdateState(Control control, bool useTransitions)
		{
			if (control.IsKeyboardFocusWithin)
			{
				System.Windows.VisualStateManager.GoToState(control, "Focused", useTransitions);
				return;
			}
			System.Windows.VisualStateManager.GoToState(control, "Unfocused", useTransitions);
		}
	}
}

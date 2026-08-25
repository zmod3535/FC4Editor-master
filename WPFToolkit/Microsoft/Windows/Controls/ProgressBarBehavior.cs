using System;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200007D RID: 125
	public class ProgressBarBehavior : ControlBehavior
	{
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060008CA RID: 2250 RVA: 0x00027A5B File Offset: 0x00025C5B
		protected internal override Type TargetType
		{
			get
			{
				return typeof(ProgressBar);
			}
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00027A68 File Offset: 0x00025C68
		protected override void OnAttach(Control control)
		{
			base.OnAttach(control);
			ProgressBar instance = (ProgressBar)control;
			Type typeFromHandle = typeof(ProgressBar);
			VisualStateBehavior.AddValueChanged(ProgressBar.IsIndeterminateProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00027AA8 File Offset: 0x00025CA8
		protected override void OnDetach(Control control)
		{
			base.OnDetach(control);
			ProgressBar instance = (ProgressBar)control;
			Type typeFromHandle = typeof(ProgressBar);
			VisualStateBehavior.RemoveValueChanged(ProgressBar.IsIndeterminateProperty, typeFromHandle, instance, new EventHandler(this.UpdateStateHandler));
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00027AE8 File Offset: 0x00025CE8
		protected override void UpdateState(Control control, bool useTransitions)
		{
			ProgressBar progressBar = (ProgressBar)control;
			if (!progressBar.IsIndeterminate)
			{
				System.Windows.VisualStateManager.GoToState(progressBar, "Determinate", useTransitions);
			}
			else
			{
				System.Windows.VisualStateManager.GoToState(progressBar, "Indeterminate", useTransitions);
			}
			base.UpdateState(control, useTransitions);
		}
	}
}

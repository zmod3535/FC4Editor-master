using System;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200002B RID: 43
	internal class VisualStateBehaviorFactory : TypeHandlerFactory<VisualStateBehavior>
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000265 RID: 613 RVA: 0x000098B2 File Offset: 0x00007AB2
		internal static VisualStateBehaviorFactory Instance
		{
			get
			{
				if (VisualStateBehaviorFactory._instance == null)
				{
					VisualStateBehaviorFactory._instance = new VisualStateBehaviorFactory();
				}
				return VisualStateBehaviorFactory._instance;
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000098CA File Offset: 0x00007ACA
		private VisualStateBehaviorFactory()
		{
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000098D4 File Offset: 0x00007AD4
		internal static void AttachBehavior(Control control)
		{
			if (DependencyPropertyHelper.GetValueSource(control, VisualStateBehavior.VisualStateBehaviorProperty).BaseValueSource == BaseValueSource.Default)
			{
				if (!VisualStateBehaviorFactory._registeredKnownTypes)
				{
					VisualStateBehaviorFactory._registeredKnownTypes = true;
					VisualStateBehaviorFactory.RegisterControlBehavior(new ButtonBaseBehavior());
					VisualStateBehaviorFactory.RegisterControlBehavior(new ToggleButtonBehavior());
					VisualStateBehaviorFactory.RegisterControlBehavior(new ListBoxItemBehavior());
					VisualStateBehaviorFactory.RegisterControlBehavior(new TextBoxBaseBehavior());
					VisualStateBehaviorFactory.RegisterControlBehavior(new ProgressBarBehavior());
				}
				VisualStateBehavior handler = VisualStateBehaviorFactory.Instance.GetHandler(control.GetType());
				if (handler != null)
				{
					VisualStateBehavior.SetVisualStateBehavior(control, handler);
				}
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x00009951 File Offset: 0x00007B51
		internal static void RegisterControlBehavior(VisualStateBehavior behavior)
		{
			VisualStateBehaviorFactory.Instance.RegisterHandler(behavior);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000995E File Offset: 0x00007B5E
		protected override Type GetBaseType(VisualStateBehavior behavior)
		{
			return behavior.TargetType;
		}

		// Token: 0x04000093 RID: 147
		[ThreadStatic]
		private static VisualStateBehaviorFactory _instance;

		// Token: 0x04000094 RID: 148
		[ThreadStatic]
		private static bool _registeredKnownTypes;
	}
}

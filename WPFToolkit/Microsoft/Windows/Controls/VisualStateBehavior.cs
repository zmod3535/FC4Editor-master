using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000003 RID: 3
	public abstract class VisualStateBehavior
	{
		// Token: 0x06000007 RID: 7 RVA: 0x0000212E File Offset: 0x0000032E
		public static VisualStateBehavior GetVisualStateBehavior(DependencyObject obj)
		{
			return (VisualStateBehavior)obj.GetValue(VisualStateBehavior.VisualStateBehaviorProperty);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002140 File Offset: 0x00000340
		public static void SetVisualStateBehavior(DependencyObject obj, VisualStateBehavior value)
		{
			obj.SetValue(VisualStateBehavior.VisualStateBehaviorProperty, value);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002150 File Offset: 0x00000350
		private static void OnVisualStateBehaviorChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			Control control = sender as Control;
			if (control != null)
			{
				VisualStateBehavior visualStateBehavior = (VisualStateBehavior)e.NewValue;
				if (visualStateBehavior != null)
				{
					visualStateBehavior.Attach(control);
				}
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002180 File Offset: 0x00000380
		private void Attach(Control control)
		{
			if (VisualStateBehavior.GetIsVisualStateBehaviorAttached(control))
			{
				throw new InvalidOperationException("VisualStateBehavior is already attached.");
			}
			VisualStateBehavior.SetIsVisualStateBehaviorAttached(control, true);
			this.OnAttach(control);
			control.Unloaded += this.DetachHandler;
			control.Loaded -= this.AttachHandler;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000021D4 File Offset: 0x000003D4
		private void Detach(Control control)
		{
			if (!VisualStateBehavior.GetIsVisualStateBehaviorAttached(control))
			{
				throw new InvalidOperationException("VisualStateBehavior is not attached.");
			}
			VisualStateBehavior.SetIsVisualStateBehaviorAttached(control, false);
			this.OnDetach(control);
			control.Loaded += this.AttachHandler;
			control.Unloaded -= this.DetachHandler;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002226 File Offset: 0x00000426
		private static bool GetIsVisualStateBehaviorAttached(DependencyObject obj)
		{
			return (bool)obj.GetValue(VisualStateBehavior.IsVisualStateBehaviorAttachedProperty);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002238 File Offset: 0x00000438
		private static void SetIsVisualStateBehaviorAttached(DependencyObject obj, bool value)
		{
			obj.SetValue(VisualStateBehavior.IsVisualStateBehaviorAttachedProperty, value);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000224B File Offset: 0x0000044B
		public static void RegisterBehavior(VisualStateBehavior behavior)
		{
			VisualStateBehaviorFactory.RegisterControlBehavior(behavior);
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000F RID: 15
		protected internal abstract Type TargetType { get; }

		// Token: 0x06000010 RID: 16
		protected abstract void OnAttach(Control control);

		// Token: 0x06000011 RID: 17
		protected abstract void OnDetach(Control control);

		// Token: 0x06000012 RID: 18
		protected abstract void UpdateStateHandler(object o, EventArgs e);

		// Token: 0x06000013 RID: 19 RVA: 0x00002254 File Offset: 0x00000454
		private void DetachHandler(object sender, RoutedEventArgs e)
		{
			Control control = sender as Control;
			if (control == null)
			{
				throw new InvalidOperationException("This Handler should only be on a control.");
			}
			this.Detach(control);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002280 File Offset: 0x00000480
		private void AttachHandler(object sender, RoutedEventArgs e)
		{
			Control control = sender as Control;
			if (control == null)
			{
				throw new InvalidOperationException("This Handler should only be on a control.");
			}
			this.Attach(control);
		}

		// Token: 0x06000015 RID: 21
		protected abstract void UpdateState(Control control, bool useTransitions);

		// Token: 0x06000016 RID: 22 RVA: 0x000022AC File Offset: 0x000004AC
		protected static bool AddValueChanged(DependencyProperty dp, Type targetType, object instance, EventHandler handler)
		{
			if (dp == null)
			{
				throw new ArgumentNullException("dp");
			}
			if (targetType == null)
			{
				throw new ArgumentNullException("targetType");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(dp, targetType);
			if (dependencyPropertyDescriptor != null)
			{
				dependencyPropertyDescriptor.AddValueChanged(instance, handler);
				return true;
			}
			return false;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002308 File Offset: 0x00000508
		protected static bool RemoveValueChanged(DependencyProperty dp, Type targetType, object instance, EventHandler handler)
		{
			if (dp == null)
			{
				throw new ArgumentNullException("dp");
			}
			if (targetType == null)
			{
				throw new ArgumentNullException("targetType");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(dp, targetType);
			if (dependencyPropertyDescriptor != null)
			{
				dependencyPropertyDescriptor.RemoveValueChanged(instance, handler);
				return true;
			}
			return false;
		}

		// Token: 0x04000003 RID: 3
		public static readonly DependencyProperty VisualStateBehaviorProperty = DependencyProperty.RegisterAttached("VisualStateBehavior", typeof(VisualStateBehavior), typeof(VisualStateBehavior), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(VisualStateBehavior.OnVisualStateBehaviorChanged)));

		// Token: 0x04000004 RID: 4
		private static readonly DependencyProperty IsVisualStateBehaviorAttachedProperty = DependencyProperty.RegisterAttached("IsVisualStateBehaviorAttached", typeof(bool), typeof(VisualStateBehavior), new FrameworkPropertyMetadata(false));
	}
}

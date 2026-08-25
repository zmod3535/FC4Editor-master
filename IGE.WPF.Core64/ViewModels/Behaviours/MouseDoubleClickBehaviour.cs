using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IGE.ViewModels.Behaviours
{
	// Token: 0x02000392 RID: 914
	public class MouseDoubleClickBehaviour
	{
		// Token: 0x0600148B RID: 5259 RVA: 0x0002BADF File Offset: 0x00029CDF
		public static void SetCommand(DependencyObject target, ICommand value)
		{
			target.SetValue(MouseDoubleClickBehaviour.CommandProperty, value);
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x0002BAED File Offset: 0x00029CED
		public static void SetCommandParameter(DependencyObject target, object value)
		{
			target.SetValue(MouseDoubleClickBehaviour.CommandParameterProperty, value);
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0002BAFB File Offset: 0x00029CFB
		public static object GetCommandParameter(DependencyObject target)
		{
			return target.GetValue(MouseDoubleClickBehaviour.CommandParameterProperty);
		}

		// Token: 0x0600148E RID: 5262 RVA: 0x0002BB08 File Offset: 0x00029D08
		private static void CommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
		{
			Control control = target as Control;
			if (control != null)
			{
				if (e.NewValue != null && e.OldValue == null)
				{
					control.MouseDoubleClick += new MouseButtonEventHandler(MouseDoubleClickBehaviour.OnMouseDoubleClick);
					return;
				}
				if (e.NewValue == null && e.OldValue != null)
				{
					control.MouseDoubleClick -= new MouseButtonEventHandler(MouseDoubleClickBehaviour.OnMouseDoubleClick);
				}
			}
		}

		// Token: 0x0600148F RID: 5263 RVA: 0x0002BB68 File Offset: 0x00029D68
		private static void OnMouseDoubleClick(object sender, RoutedEventArgs e)
		{
			Control control = sender as Control;
			ICommand command = (ICommand)control.GetValue(MouseDoubleClickBehaviour.CommandProperty);
			object value = control.GetValue(MouseDoubleClickBehaviour.CommandParameterProperty);
			command.Execute(value);
		}

		// Token: 0x04000786 RID: 1926
		public static DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(MouseDoubleClickBehaviour), new UIPropertyMetadata(new PropertyChangedCallback(MouseDoubleClickBehaviour.CommandChanged)));

		// Token: 0x04000787 RID: 1927
		public static DependencyProperty CommandParameterProperty = DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(MouseDoubleClickBehaviour), new UIPropertyMetadata(null));
	}
}

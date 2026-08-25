using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Windows.Automation.Peers;

namespace Microsoft.Windows.Controls.Primitives
{
	// Token: 0x02000053 RID: 83
	[System.Windows.TemplateVisualState(Name = "Inactive", GroupName = "ActiveStates")]
	[System.Windows.TemplateVisualState(Name = "Active", GroupName = "ActiveStates")]
	[System.Windows.TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "MouseOver", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "Pressed", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "Unselected", GroupName = "SelectionStates")]
	[System.Windows.TemplateVisualState(Name = "Selected", GroupName = "SelectionStates")]
	[System.Windows.TemplateVisualState(Name = "CalendarButtonUnfocused", GroupName = "CalendarButtonFocusStates")]
	[System.Windows.TemplateVisualState(Name = "CalendarButtonFocused", GroupName = "CalendarButtonFocusStates")]
	public sealed class CalendarButton : Button
	{
		// Token: 0x060006A7 RID: 1703 RVA: 0x0001B7A8 File Offset: 0x000199A8
		static CalendarButton()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarButton), new FrameworkPropertyMetadata(typeof(CalendarButton)));
			ContentControl.ContentProperty.OverrideMetadata(typeof(CalendarButton), new FrameworkPropertyMetadata(null, new CoerceValueCallback(CalendarButton.OnCoerceContent)));
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x0001B89C File Offset: 0x00019A9C
		public CalendarButton()
		{
			base.Loaded += delegate(object A_1, RoutedEventArgs A_2)
			{
				this.ChangeVisualState(false);
			};
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060006A9 RID: 1705 RVA: 0x0001B8C8 File Offset: 0x00019AC8
		// (set) Token: 0x060006AA RID: 1706 RVA: 0x0001B8DA File Offset: 0x00019ADA
		public bool HasSelectedDays
		{
			get
			{
				return (bool)base.GetValue(CalendarButton.HasSelectedDaysProperty);
			}
			internal set
			{
				base.SetValue(CalendarButton.HasSelectedDaysPropertyKey, value);
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060006AB RID: 1707 RVA: 0x0001B8ED File Offset: 0x00019AED
		// (set) Token: 0x060006AC RID: 1708 RVA: 0x0001B8FF File Offset: 0x00019AFF
		public bool IsInactive
		{
			get
			{
				return (bool)base.GetValue(CalendarButton.IsInactiveProperty);
			}
			internal set
			{
				base.SetValue(CalendarButton.IsInactivePropertyKey, value);
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060006AD RID: 1709 RVA: 0x0001B912 File Offset: 0x00019B12
		// (set) Token: 0x060006AE RID: 1710 RVA: 0x0001B91A File Offset: 0x00019B1A
		internal Calendar Owner { get; set; }

		// Token: 0x060006AF RID: 1711 RVA: 0x0001B923 File Offset: 0x00019B23
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.ChangeVisualState(false);
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0001B932 File Offset: 0x00019B32
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new Microsoft.Windows.Automation.Peers.CalendarButtonAutomationPeer(this);
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0001B93A File Offset: 0x00019B3A
		protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
		{
			this.ChangeVisualState(true);
			base.OnGotKeyboardFocus(e);
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x0001B94A File Offset: 0x00019B4A
		protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
		{
			this.ChangeVisualState(true);
			base.OnLostKeyboardFocus(e);
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0001B95A File Offset: 0x00019B5A
		internal void SetContentInternal(string value)
		{
			if (BindingOperations.GetBindingExpressionBase(this, ContentControl.ContentProperty) != null)
			{
				base.Content = value;
				return;
			}
			this._shouldCoerceContent = true;
			this._coercedContent = value;
			base.CoerceValue(ContentControl.ContentProperty);
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0001B98C File Offset: 0x00019B8C
		private void ChangeVisualState(bool useTransitions)
		{
			if (this.HasSelectedDays)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Selected",
					"Unselected"
				});
			}
			else
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Unselected"
				});
			}
			if (this.IsInactive)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Inactive"
				});
			}
			else
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Active",
					"Inactive"
				});
			}
			if (base.IsKeyboardFocused)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"CalendarButtonFocused",
					"CalendarButtonUnfocused"
				});
				return;
			}
			System.Windows.VisualStateManager.GoToState(this, "CalendarButtonUnfocused", useTransitions);
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0001BA54 File Offset: 0x00019C54
		private static void OnVisualStatePropertyChanged(DependencyObject dObject, DependencyPropertyChangedEventArgs e)
		{
			CalendarButton calendarButton = dObject as CalendarButton;
			if (calendarButton != null && !object.Equals(e.OldValue, e.NewValue))
			{
				calendarButton.ChangeVisualState(true);
			}
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x0001BA88 File Offset: 0x00019C88
		private static object OnCoerceContent(DependencyObject sender, object baseValue)
		{
			CalendarButton calendarButton = (CalendarButton)sender;
			if (calendarButton._shouldCoerceContent)
			{
				calendarButton._shouldCoerceContent = false;
				return calendarButton._coercedContent;
			}
			return baseValue;
		}

		// Token: 0x040001E2 RID: 482
		private bool _shouldCoerceContent;

		// Token: 0x040001E3 RID: 483
		private object _coercedContent;

		// Token: 0x040001E4 RID: 484
		internal static readonly DependencyPropertyKey HasSelectedDaysPropertyKey = DependencyProperty.RegisterReadOnly("HasSelectedDays", typeof(bool), typeof(CalendarButton), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(CalendarButton.OnVisualStatePropertyChanged)));

		// Token: 0x040001E5 RID: 485
		public static readonly DependencyProperty HasSelectedDaysProperty = CalendarButton.HasSelectedDaysPropertyKey.DependencyProperty;

		// Token: 0x040001E6 RID: 486
		internal static readonly DependencyPropertyKey IsInactivePropertyKey = DependencyProperty.RegisterReadOnly("IsInactive", typeof(bool), typeof(CalendarButton), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(CalendarButton.OnVisualStatePropertyChanged)));

		// Token: 0x040001E7 RID: 487
		public static readonly DependencyProperty IsInactiveProperty = CalendarButton.IsInactivePropertyKey.DependencyProperty;
	}
}

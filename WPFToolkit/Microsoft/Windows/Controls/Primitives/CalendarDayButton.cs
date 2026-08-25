using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Windows.Automation.Peers;

namespace Microsoft.Windows.Controls.Primitives
{
	// Token: 0x02000034 RID: 52
	[System.Windows.TemplateVisualState(Name = "Active", GroupName = "ActiveStates")]
	[System.Windows.TemplateVisualState(Name = "Selected", GroupName = "SelectionStates")]
	[System.Windows.TemplateVisualState(Name = "CalendarButtonUnfocused", GroupName = "CalendarButtonFocusStates")]
	[System.Windows.TemplateVisualState(Name = "CalendarButtonFocused", GroupName = "CalendarButtonFocusStates")]
	[System.Windows.TemplateVisualState(Name = "Inactive", GroupName = "ActiveStates")]
	[System.Windows.TemplateVisualState(Name = "MouseOver", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "Unselected", GroupName = "SelectionStates")]
	[System.Windows.TemplateVisualState(Name = "Today", GroupName = "DayStates")]
	[System.Windows.TemplateVisualState(Name = "NormalDay", GroupName = "BlackoutDayStates")]
	[System.Windows.TemplateVisualState(Name = "BlackoutDay", GroupName = "BlackoutDayStates")]
	[System.Windows.TemplateVisualState(Name = "RegularDay", GroupName = "DayStates")]
	[System.Windows.TemplateVisualState(Name = "Pressed", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
	public sealed class CalendarDayButton : Button
	{
		// Token: 0x060002C1 RID: 705 RVA: 0x0000A8CC File Offset: 0x00008ACC
		static CalendarDayButton()
		{
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarDayButton), new FrameworkPropertyMetadata(typeof(CalendarDayButton)));
			ContentControl.ContentProperty.OverrideMetadata(typeof(CalendarDayButton), new FrameworkPropertyMetadata(null, new CoerceValueCallback(CalendarDayButton.OnCoerceContent)));
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x0000AA98 File Offset: 0x00008C98
		public CalendarDayButton()
		{
			base.Loaded += delegate(object A_1, RoutedEventArgs A_2)
			{
				this.ChangeVisualState(false);
			};
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060002C3 RID: 707 RVA: 0x0000AAC4 File Offset: 0x00008CC4
		public bool IsToday
		{
			get
			{
				return (bool)base.GetValue(CalendarDayButton.IsTodayProperty);
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x0000AAD6 File Offset: 0x00008CD6
		public bool IsSelected
		{
			get
			{
				return (bool)base.GetValue(CalendarDayButton.IsSelectedProperty);
			}
		}

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x0000AAE8 File Offset: 0x00008CE8
		public bool IsInactive
		{
			get
			{
				return (bool)base.GetValue(CalendarDayButton.IsInactiveProperty);
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060002C6 RID: 710 RVA: 0x0000AAFA File Offset: 0x00008CFA
		public bool IsBlackedOut
		{
			get
			{
				return (bool)base.GetValue(CalendarDayButton.IsBlackedOutProperty);
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060002C7 RID: 711 RVA: 0x0000AB0C File Offset: 0x00008D0C
		public bool IsHighlighted
		{
			get
			{
				return (bool)base.GetValue(CalendarDayButton.IsHighlightedProperty);
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x0000AB1E File Offset: 0x00008D1E
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x0000AB26 File Offset: 0x00008D26
		internal Calendar Owner { get; set; }

		// Token: 0x060002CA RID: 714 RVA: 0x0000AB2F File Offset: 0x00008D2F
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			this.ChangeVisualState(false);
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000AB3E File Offset: 0x00008D3E
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new CalendarDayButtonAutomationPeer(this);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000AB46 File Offset: 0x00008D46
		protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
		{
			this.ChangeVisualState(true);
			base.OnGotKeyboardFocus(e);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000AB56 File Offset: 0x00008D56
		protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
		{
			this.ChangeVisualState(true);
			base.OnLostKeyboardFocus(e);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000AB68 File Offset: 0x00008D68
		internal void ChangeVisualState(bool useTransitions)
		{
			if (base.IsEnabled)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Normal"
				});
			}
			else
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Disabled"
				});
			}
			if (this.IsSelected || this.IsHighlighted)
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
			if (!this.IsInactive)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Active",
					"Inactive"
				});
			}
			else
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Inactive"
				});
			}
			if (this.IsToday && this.Owner != null && this.Owner.IsTodayHighlighted)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"Today",
					"RegularDay"
				});
			}
			else
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"RegularDay"
				});
			}
			if (this.IsBlackedOut)
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"BlackoutDay",
					"NormalDay"
				});
			}
			else
			{
				VisualStates.GoToState(this, useTransitions, new string[]
				{
					"NormalDay"
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

		// Token: 0x060002CF RID: 719 RVA: 0x0000AD18 File Offset: 0x00008F18
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

		// Token: 0x060002D0 RID: 720 RVA: 0x0000AD48 File Offset: 0x00008F48
		private static void OnVisualStatePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			CalendarDayButton calendarDayButton = sender as CalendarDayButton;
			if (calendarDayButton != null)
			{
				calendarDayButton.ChangeVisualState(true);
			}
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000AD68 File Offset: 0x00008F68
		private static object OnCoerceContent(DependencyObject sender, object baseValue)
		{
			CalendarDayButton calendarDayButton = (CalendarDayButton)sender;
			if (calendarDayButton._shouldCoerceContent)
			{
				calendarDayButton._shouldCoerceContent = false;
				return calendarDayButton._coercedContent;
			}
			return baseValue;
		}

		// Token: 0x040000B9 RID: 185
		private const int DEFAULTCONTENT = 1;

		// Token: 0x040000BA RID: 186
		internal const string StateToday = "Today";

		// Token: 0x040000BB RID: 187
		internal const string StateRegularDay = "RegularDay";

		// Token: 0x040000BC RID: 188
		internal const string GroupDay = "DayStates";

		// Token: 0x040000BD RID: 189
		internal const string StateBlackoutDay = "BlackoutDay";

		// Token: 0x040000BE RID: 190
		internal const string StateNormalDay = "NormalDay";

		// Token: 0x040000BF RID: 191
		internal const string GroupBlackout = "BlackoutDayStates";

		// Token: 0x040000C0 RID: 192
		private bool _shouldCoerceContent;

		// Token: 0x040000C1 RID: 193
		private object _coercedContent;

		// Token: 0x040000C2 RID: 194
		internal static readonly DependencyPropertyKey IsTodayPropertyKey = DependencyProperty.RegisterReadOnly("IsToday", typeof(bool), typeof(CalendarDayButton), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(CalendarDayButton.OnVisualStatePropertyChanged)));

		// Token: 0x040000C3 RID: 195
		public static readonly DependencyProperty IsTodayProperty = CalendarDayButton.IsTodayPropertyKey.DependencyProperty;

		// Token: 0x040000C4 RID: 196
		internal static readonly DependencyPropertyKey IsSelectedPropertyKey = DependencyProperty.RegisterReadOnly("IsSelected", typeof(bool), typeof(CalendarDayButton), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(CalendarDayButton.OnVisualStatePropertyChanged)));

		// Token: 0x040000C5 RID: 197
		public static readonly DependencyProperty IsSelectedProperty = CalendarDayButton.IsSelectedPropertyKey.DependencyProperty;

		// Token: 0x040000C6 RID: 198
		internal static readonly DependencyPropertyKey IsInactivePropertyKey = DependencyProperty.RegisterReadOnly("IsInactive", typeof(bool), typeof(CalendarDayButton), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(CalendarDayButton.OnVisualStatePropertyChanged)));

		// Token: 0x040000C7 RID: 199
		public static readonly DependencyProperty IsInactiveProperty = CalendarDayButton.IsInactivePropertyKey.DependencyProperty;

		// Token: 0x040000C8 RID: 200
		internal static readonly DependencyPropertyKey IsBlackedOutPropertyKey = DependencyProperty.RegisterReadOnly("IsBlackedOut", typeof(bool), typeof(CalendarDayButton), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(CalendarDayButton.OnVisualStatePropertyChanged)));

		// Token: 0x040000C9 RID: 201
		public static readonly DependencyProperty IsBlackedOutProperty = CalendarDayButton.IsBlackedOutPropertyKey.DependencyProperty;

		// Token: 0x040000CA RID: 202
		internal static readonly DependencyPropertyKey IsHighlightedPropertyKey = DependencyProperty.RegisterReadOnly("IsHighlighted", typeof(bool), typeof(CalendarDayButton), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(CalendarDayButton.OnVisualStatePropertyChanged)));

		// Token: 0x040000CB RID: 203
		public static readonly DependencyProperty IsHighlightedProperty = CalendarDayButton.IsHighlightedPropertyKey.DependencyProperty;
	}
}

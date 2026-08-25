using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Windows.Automation.Peers;
using Microsoft.Windows.Controls.Primitives;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000044 RID: 68
	[TemplatePart(Name = "PART_Root", Type = typeof(Grid))]
	[TemplatePart(Name = "PART_Popup", Type = typeof(Popup))]
	[System.Windows.TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
	[System.Windows.TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
	[TemplatePart(Name = "PART_TextBox", Type = typeof(Microsoft.Windows.Controls.Primitives.DatePickerTextBox))]
	[TemplatePart(Name = "PART_Button", Type = typeof(Button))]
	public class DatePicker : Control
	{
		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000501 RID: 1281 RVA: 0x00013DBB File Offset: 0x00011FBB
		// (remove) Token: 0x06000502 RID: 1282 RVA: 0x00013DD4 File Offset: 0x00011FD4
		public event RoutedEventHandler CalendarClosed;

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000503 RID: 1283 RVA: 0x00013DED File Offset: 0x00011FED
		// (remove) Token: 0x06000504 RID: 1284 RVA: 0x00013E06 File Offset: 0x00012006
		public event RoutedEventHandler CalendarOpened;

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000505 RID: 1285 RVA: 0x00013E1F File Offset: 0x0001201F
		// (remove) Token: 0x06000506 RID: 1286 RVA: 0x00013E38 File Offset: 0x00012038
		public event EventHandler<DatePickerDateValidationErrorEventArgs> DateValidationError;

		// Token: 0x1400001E RID: 30
		// (add) Token: 0x06000507 RID: 1287 RVA: 0x00013E51 File Offset: 0x00012051
		// (remove) Token: 0x06000508 RID: 1288 RVA: 0x00013E5F File Offset: 0x0001205F
		public event EventHandler<SelectionChangedEventArgs> SelectedDateChanged
		{
			add
			{
				base.AddHandler(DatePicker.SelectedDateChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(DatePicker.SelectedDateChangedEvent, value);
			}
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x00013E70 File Offset: 0x00012070
		static DatePicker()
		{
			DatePicker.SelectedDateChangedEvent = EventManager.RegisterRoutedEvent("SelectedDateChanged", RoutingStrategy.Direct, typeof(EventHandler<SelectionChangedEventArgs>), typeof(DatePicker));
			DatePicker.CalendarStyleProperty = DependencyProperty.Register("CalendarStyle", typeof(Style), typeof(DatePicker));
			DatePicker.DisplayDateProperty = DependencyProperty.Register("DisplayDate", typeof(DateTime), typeof(DatePicker), new FrameworkPropertyMetadata(DateTime.Now, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, new CoerceValueCallback(DatePicker.CoerceDisplayDate)));
			DatePicker.DisplayDateEndProperty = DependencyProperty.Register("DisplayDateEnd", typeof(DateTime?), typeof(DatePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(DatePicker.OnDisplayDateEndChanged), new CoerceValueCallback(DatePicker.CoerceDisplayDateEnd)));
			DatePicker.DisplayDateStartProperty = DependencyProperty.Register("DisplayDateStart", typeof(DateTime?), typeof(DatePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(DatePicker.OnDisplayDateStartChanged), new CoerceValueCallback(DatePicker.CoerceDisplayDateStart)));
			DatePicker.FirstDayOfWeekProperty = DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(DatePicker), null, new ValidateValueCallback(Microsoft.Windows.Controls.Calendar.IsValidFirstDayOfWeek));
			DatePicker.IsDropDownOpenProperty = DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(DatePicker), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(DatePicker.OnIsDropDownOpenChanged), new CoerceValueCallback(DatePicker.OnCoerceIsDropDownOpen)));
			DatePicker.IsTodayHighlightedProperty = DependencyProperty.Register("IsTodayHighlighted", typeof(bool), typeof(DatePicker));
			DatePicker.SelectedDateProperty = DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(DatePicker), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(DatePicker.OnSelectedDateChanged), new CoerceValueCallback(DatePicker.CoerceSelectedDate)));
			DatePicker.SelectedDateFormatProperty = DependencyProperty.Register("SelectedDateFormat", typeof(DatePickerFormat), typeof(DatePicker), new FrameworkPropertyMetadata(DatePickerFormat.Long, new PropertyChangedCallback(DatePicker.OnSelectedDateFormatChanged)), new ValidateValueCallback(DatePicker.IsValidSelectedDateFormat));
			DatePicker.TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(DatePicker), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(DatePicker.OnTextChanged), new CoerceValueCallback(DatePicker.OnCoerceText)));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(DatePicker), new FrameworkPropertyMetadata(typeof(DatePicker)));
			EventManager.RegisterClassHandler(typeof(DatePicker), UIElement.GotFocusEvent, new RoutedEventHandler(DatePicker.OnGotFocus));
			KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(DatePicker), new FrameworkPropertyMetadata(KeyboardNavigationMode.Once));
			KeyboardNavigation.IsTabStopProperty.OverrideMetadata(typeof(DatePicker), new FrameworkPropertyMetadata(false));
			UIElement.IsEnabledProperty.OverrideMetadata(typeof(DatePicker), new UIPropertyMetadata(new PropertyChangedCallback(DatePicker.OnIsEnabledChanged)));
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x000141A9 File Offset: 0x000123A9
		public DatePicker()
		{
			this.InitializeCalendar();
			this._defaultText = string.Empty;
			this.FirstDayOfWeek = DateTimeHelper.GetCurrentDateFormat().FirstDayOfWeek;
			this.DisplayDate = DateTime.Today;
		}

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x000141DD File Offset: 0x000123DD
		public CalendarBlackoutDatesCollection BlackoutDates
		{
			get
			{
				return this._calendar.BlackoutDates;
			}
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x000141EA File Offset: 0x000123EA
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x000141FC File Offset: 0x000123FC
		public Style CalendarStyle
		{
			get
			{
				return (Style)base.GetValue(DatePicker.CalendarStyleProperty);
			}
			set
			{
				base.SetValue(DatePicker.CalendarStyleProperty, value);
			}
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x0001420A File Offset: 0x0001240A
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x0001421C File Offset: 0x0001241C
		public DateTime DisplayDate
		{
			get
			{
				return (DateTime)base.GetValue(DatePicker.DisplayDateProperty);
			}
			set
			{
				base.SetValue(DatePicker.DisplayDateProperty, value);
			}
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x00014230 File Offset: 0x00012430
		private static object CoerceDisplayDate(DependencyObject d, object value)
		{
			DatePicker datePicker = d as DatePicker;
			datePicker._calendar.DisplayDate = (DateTime)value;
			return datePicker._calendar.DisplayDate;
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x00014265 File Offset: 0x00012465
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x00014277 File Offset: 0x00012477
		public DateTime? DisplayDateEnd
		{
			get
			{
				return (DateTime?)base.GetValue(DatePicker.DisplayDateEndProperty);
			}
			set
			{
				base.SetValue(DatePicker.DisplayDateEndProperty, value);
			}
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0001428C File Offset: 0x0001248C
		private static void OnDisplayDateEndChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DatePicker datePicker = d as DatePicker;
			datePicker.CoerceValue(DatePicker.DisplayDateProperty);
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x000142AC File Offset: 0x000124AC
		private static object CoerceDisplayDateEnd(DependencyObject d, object value)
		{
			DatePicker datePicker = d as DatePicker;
			datePicker._calendar.DisplayDateEnd = (DateTime?)value;
			return datePicker._calendar.DisplayDateEnd;
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x000142E1 File Offset: 0x000124E1
		// (set) Token: 0x06000516 RID: 1302 RVA: 0x000142F3 File Offset: 0x000124F3
		public DateTime? DisplayDateStart
		{
			get
			{
				return (DateTime?)base.GetValue(DatePicker.DisplayDateStartProperty);
			}
			set
			{
				base.SetValue(DatePicker.DisplayDateStartProperty, value);
			}
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x00014308 File Offset: 0x00012508
		private static void OnDisplayDateStartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DatePicker datePicker = d as DatePicker;
			datePicker.CoerceValue(DatePicker.DisplayDateEndProperty);
			datePicker.CoerceValue(DatePicker.DisplayDateProperty);
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x00014334 File Offset: 0x00012534
		private static object CoerceDisplayDateStart(DependencyObject d, object value)
		{
			DatePicker datePicker = d as DatePicker;
			datePicker._calendar.DisplayDateStart = (DateTime?)value;
			return datePicker._calendar.DisplayDateStart;
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x00014369 File Offset: 0x00012569
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x0001437B File Offset: 0x0001257B
		public DayOfWeek FirstDayOfWeek
		{
			get
			{
				return (DayOfWeek)base.GetValue(DatePicker.FirstDayOfWeekProperty);
			}
			set
			{
				base.SetValue(DatePicker.FirstDayOfWeekProperty, value);
			}
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0001438E File Offset: 0x0001258E
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x000143A0 File Offset: 0x000125A0
		public bool IsDropDownOpen
		{
			get
			{
				return (bool)base.GetValue(DatePicker.IsDropDownOpenProperty);
			}
			set
			{
				base.SetValue(DatePicker.IsDropDownOpenProperty, value);
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x000143B4 File Offset: 0x000125B4
		private static object OnCoerceIsDropDownOpen(DependencyObject d, object baseValue)
		{
			DatePicker datePicker = d as DatePicker;
			if (!datePicker.IsEnabled)
			{
				return false;
			}
			return baseValue;
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x000143F4 File Offset: 0x000125F4
		private static void OnIsDropDownOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DatePicker dp = d as DatePicker;
			bool flag = (bool)e.NewValue;
			if (dp._popUp != null && dp._popUp.IsOpen != flag)
			{
				dp._popUp.IsOpen = flag;
				if (flag)
				{
					dp._originalSelectedDate = dp.SelectedDate;
					dp.Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(delegate()
					{
						dp._calendar.Focus();
					}));
				}
			}
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x00014490 File Offset: 0x00012690
		private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DatePicker datePicker = d as DatePicker;
			datePicker.CoerceValue(DatePicker.IsDropDownOpenProperty);
			DatePicker.OnVisualStatePropertyChanged(datePicker);
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x000144B5 File Offset: 0x000126B5
		private static void OnVisualStatePropertyChanged(DatePicker dp)
		{
			if (!Validation.GetHasError(dp))
			{
				System.Windows.VisualStateManager.GoToState(dp, "Valid", true);
				return;
			}
			if (dp.IsKeyboardFocused)
			{
				System.Windows.VisualStateManager.GoToState(dp, "InvalidFocused", true);
				return;
			}
			System.Windows.VisualStateManager.GoToState(dp, "InvalidUnfocused", true);
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x000144F0 File Offset: 0x000126F0
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x00014502 File Offset: 0x00012702
		public bool IsTodayHighlighted
		{
			get
			{
				return (bool)base.GetValue(DatePicker.IsTodayHighlightedProperty);
			}
			set
			{
				base.SetValue(DatePicker.IsTodayHighlightedProperty, value);
			}
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000523 RID: 1315 RVA: 0x00014515 File Offset: 0x00012715
		// (set) Token: 0x06000524 RID: 1316 RVA: 0x00014527 File Offset: 0x00012727
		public DateTime? SelectedDate
		{
			get
			{
				return (DateTime?)base.GetValue(DatePicker.SelectedDateProperty);
			}
			set
			{
				base.SetValue(DatePicker.SelectedDateProperty, value);
			}
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0001453C File Offset: 0x0001273C
		private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DatePicker datePicker = d as DatePicker;
			Collection<DateTime> collection = new Collection<DateTime>();
			Collection<DateTime> collection2 = new Collection<DateTime>();
			datePicker.CoerceValue(DatePicker.DisplayDateStartProperty);
			datePicker.CoerceValue(DatePicker.DisplayDateEndProperty);
			datePicker.CoerceValue(DatePicker.DisplayDateProperty);
			DateTime? dateTime = (DateTime?)e.NewValue;
			DateTime? dateTime2 = (DateTime?)e.OldValue;
			if (datePicker.SelectedDate != null)
			{
				DateTime value = datePicker.SelectedDate.Value;
				datePicker.SetTextInternal(datePicker.DateTimeToString(value));
				if ((value.Month != datePicker.DisplayDate.Month || value.Year != datePicker.DisplayDate.Year) && !datePicker._calendar.DatePickerDisplayDateFlag)
				{
					datePicker.DisplayDate = value;
				}
				datePicker._calendar.DatePickerDisplayDateFlag = false;
			}
			else
			{
				datePicker.SetWaterMarkText();
			}
			if (dateTime != null)
			{
				collection.Add(dateTime.Value);
			}
			if (dateTime2 != null)
			{
				collection2.Add(dateTime2.Value);
			}
			datePicker.OnSelectedDateChanged(new CalendarSelectionChangedEventArgs(DatePicker.SelectedDateChangedEvent, collection2, collection));
			Microsoft.Windows.Automation.Peers.DatePickerAutomationPeer datePickerAutomationPeer = UIElementAutomationPeer.FromElement(datePicker) as Microsoft.Windows.Automation.Peers.DatePickerAutomationPeer;
			if (datePickerAutomationPeer != null)
			{
				string newValue = (dateTime != null) ? datePicker.DateTimeToString(dateTime.Value) : "";
				string oldValue = (dateTime2 != null) ? datePicker.DateTimeToString(dateTime2.Value) : "";
				datePickerAutomationPeer.RaiseValuePropertyChangedEvent(oldValue, newValue);
			}
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x000146BC File Offset: 0x000128BC
		private static object CoerceSelectedDate(DependencyObject d, object value)
		{
			DatePicker datePicker = d as DatePicker;
			datePicker._calendar.SelectedDate = (DateTime?)value;
			return datePicker._calendar.SelectedDate;
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x000146F1 File Offset: 0x000128F1
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x00014703 File Offset: 0x00012903
		public DatePickerFormat SelectedDateFormat
		{
			get
			{
				return (DatePickerFormat)base.GetValue(DatePicker.SelectedDateFormatProperty);
			}
			set
			{
				base.SetValue(DatePicker.SelectedDateFormatProperty, value);
			}
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x00014718 File Offset: 0x00012918
		private static void OnSelectedDateFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DatePicker datePicker = d as DatePicker;
			if (datePicker._textBox != null)
			{
				if (string.IsNullOrEmpty(datePicker._textBox.Text))
				{
					datePicker.SetWaterMarkText();
					return;
				}
				DateTime? dateTime = datePicker.ParseText(datePicker._textBox.Text);
				if (dateTime != null)
				{
					datePicker.SetTextInternal(datePicker.DateTimeToString(dateTime.Value));
				}
			}
		}

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x0001477B File Offset: 0x0001297B
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x0001478D File Offset: 0x0001298D
		public string Text
		{
			get
			{
				return (string)base.GetValue(DatePicker.TextProperty);
			}
			set
			{
				base.SetValue(DatePicker.TextProperty, value);
			}
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0001479C File Offset: 0x0001299C
		private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			DatePicker datePicker = d as DatePicker;
			if (!datePicker.IsHandlerSuspended(DatePicker.TextProperty))
			{
				string text = e.NewValue as string;
				if (text != null)
				{
					if (datePicker._textBox != null)
					{
						datePicker._textBox.Text = text;
					}
					else
					{
						datePicker._defaultText = text;
					}
					datePicker.SetSelectedDate();
					return;
				}
				datePicker.SetValueNoCallback(DatePicker.SelectedDateProperty, null);
			}
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00014800 File Offset: 0x00012A00
		private static object OnCoerceText(DependencyObject dObject, object baseValue)
		{
			DatePicker datePicker = (DatePicker)dObject;
			if (datePicker._shouldCoerceText)
			{
				datePicker._shouldCoerceText = false;
				return datePicker._coercedTextValue;
			}
			return baseValue;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0001482B File Offset: 0x00012A2B
		private void SetTextInternal(string value)
		{
			if (BindingOperations.GetBindingExpressionBase(this, DatePicker.TextProperty) != null)
			{
				this.Text = value;
				return;
			}
			this._shouldCoerceText = true;
			this._coercedTextValue = value;
			base.CoerceValue(DatePicker.TextProperty);
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0001485C File Offset: 0x00012A5C
		public override void OnApplyTemplate()
		{
			if (this._popUp != null)
			{
				this._popUp.RemoveHandler(UIElement.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(this.PopUp_PreviewMouseLeftButtonDown));
				this._popUp.Opened -= this.PopUp_Opened;
				this._popUp.Closed -= this.PopUp_Closed;
				this._popUp.Child = null;
			}
			if (this._dropDownButton != null)
			{
				this._dropDownButton.Click -= this.DropDownButton_Click;
				this._dropDownButton.RemoveHandler(UIElement.MouseLeaveEvent, new MouseEventHandler(this.DropDownButton_MouseLeave));
			}
			if (this._textBox != null)
			{
				this._textBox.RemoveHandler(UIElement.KeyDownEvent, new KeyEventHandler(this.TextBox_KeyDown));
				this._textBox.RemoveHandler(TextBoxBase.TextChangedEvent, new TextChangedEventHandler(this.TextBox_TextChanged));
				this._textBox.RemoveHandler(UIElement.LostFocusEvent, new RoutedEventHandler(this.TextBox_LostFocus));
			}
			base.OnApplyTemplate();
			this._popUp = (base.GetTemplateChild("PART_Popup") as Popup);
			if (this._popUp != null)
			{
				this._popUp.AddHandler(UIElement.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(this.PopUp_PreviewMouseLeftButtonDown));
				this._popUp.Opened += this.PopUp_Opened;
				this._popUp.Closed += this.PopUp_Closed;
				this._popUp.Child = this._calendar;
				if (this.IsDropDownOpen)
				{
					this._popUp.IsOpen = true;
				}
			}
			this._dropDownButton = (base.GetTemplateChild("PART_Button") as Button);
			if (this._dropDownButton != null)
			{
				this._dropDownButton.Click += this.DropDownButton_Click;
				this._dropDownButton.AddHandler(UIElement.MouseLeaveEvent, new MouseEventHandler(this.DropDownButton_MouseLeave), true);
				if (this._dropDownButton.Content == null)
				{
					this._dropDownButton.Content = SR.Get(SRID.DatePicker_DropDownButtonName);
				}
			}
			this._textBox = (base.GetTemplateChild("PART_TextBox") as Microsoft.Windows.Controls.Primitives.DatePickerTextBox);
			this.UpdateDisabledVisual();
			if (this.SelectedDate == null)
			{
				this.SetWaterMarkText();
			}
			if (this._textBox != null)
			{
				this._textBox.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(this.TextBox_KeyDown), true);
				this._textBox.AddHandler(TextBoxBase.TextChangedEvent, new TextChangedEventHandler(this.TextBox_TextChanged), true);
				this._textBox.AddHandler(UIElement.LostFocusEvent, new RoutedEventHandler(this.TextBox_LostFocus), true);
				if (this.SelectedDate == null)
				{
					if (!string.IsNullOrEmpty(this._defaultText))
					{
						this._textBox.Text = this._defaultText;
						this.SetSelectedDate();
						return;
					}
				}
				else
				{
					this._textBox.Text = this.DateTimeToString(this.SelectedDate.Value);
				}
			}
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00014B50 File Offset: 0x00012D50
		public override string ToString()
		{
			if (this.SelectedDate != null)
			{
				return this.SelectedDate.Value.ToString(DateTimeHelper.GetDateFormat(DateTimeHelper.GetCulture(this)));
			}
			return string.Empty;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00014B94 File Offset: 0x00012D94
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new Microsoft.Windows.Automation.Peers.DatePickerAutomationPeer(this);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00014B9C File Offset: 0x00012D9C
		protected virtual void OnCalendarClosed(RoutedEventArgs e)
		{
			RoutedEventHandler calendarClosed = this.CalendarClosed;
			if (calendarClosed != null)
			{
				calendarClosed(this, e);
			}
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00014BBC File Offset: 0x00012DBC
		protected virtual void OnCalendarOpened(RoutedEventArgs e)
		{
			RoutedEventHandler calendarOpened = this.CalendarOpened;
			if (calendarOpened != null)
			{
				calendarOpened(this, e);
			}
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00014BDB File Offset: 0x00012DDB
		protected virtual void OnSelectedDateChanged(SelectionChangedEventArgs e)
		{
			base.RaiseEvent(e);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00014BE4 File Offset: 0x00012DE4
		protected virtual void OnDateValidationError(DatePickerDateValidationErrorEventArgs e)
		{
			EventHandler<DatePickerDateValidationErrorEventArgs> dateValidationError = this.DateValidationError;
			if (dateValidationError != null)
			{
				dateValidationError(this, e);
			}
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x00014C04 File Offset: 0x00012E04
		private static void OnGotFocus(object sender, RoutedEventArgs e)
		{
			DatePicker datePicker = (DatePicker)sender;
			if (!e.Handled && datePicker._textBox != null)
			{
				if (e.OriginalSource == datePicker)
				{
					datePicker._textBox.Focus();
					e.Handled = true;
					return;
				}
				if (e.OriginalSource == datePicker._textBox)
				{
					datePicker._textBox.SelectAll();
					e.Handled = true;
				}
			}
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00014C68 File Offset: 0x00012E68
		private void SetValueNoCallback(DependencyProperty property, object value)
		{
			this.SetIsHandlerSuspended(property, true);
			try
			{
				base.SetValue(property, value);
			}
			finally
			{
				this.SetIsHandlerSuspended(property, false);
			}
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00014CA0 File Offset: 0x00012EA0
		private bool IsHandlerSuspended(DependencyProperty property)
		{
			return this._isHandlerSuspended != null && this._isHandlerSuspended.ContainsKey(property);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00014CB8 File Offset: 0x00012EB8
		private void SetIsHandlerSuspended(DependencyProperty property, bool value)
		{
			if (value)
			{
				if (this._isHandlerSuspended == null)
				{
					this._isHandlerSuspended = new Dictionary<DependencyProperty, bool>(2);
				}
				this._isHandlerSuspended[property] = true;
				return;
			}
			if (this._isHandlerSuspended != null)
			{
				this._isHandlerSuspended.Remove(property);
			}
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00014CF4 File Offset: 0x00012EF4
		private void PopUp_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Popup popup = sender as Popup;
			if (popup != null && !popup.StaysOpen && this._dropDownButton != null && this._dropDownButton.InputHitTest(e.GetPosition(this._dropDownButton)) != null)
			{
				this._disablePopupReopen = true;
			}
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00014D3C File Offset: 0x00012F3C
		private void PopUp_Opened(object sender, EventArgs e)
		{
			if (!this.IsDropDownOpen)
			{
				this.IsDropDownOpen = true;
			}
			if (this._calendar != null)
			{
				this._calendar.DisplayMode = CalendarMode.Month;
				this._calendar.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
			}
			this.OnCalendarOpened(new RoutedEventArgs());
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00014D89 File Offset: 0x00012F89
		private void PopUp_Closed(object sender, EventArgs e)
		{
			if (this.IsDropDownOpen)
			{
				this.IsDropDownOpen = false;
			}
			if (this._calendar.IsKeyboardFocusWithin)
			{
				this.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
			}
			this.OnCalendarClosed(new RoutedEventArgs());
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00014DBF File Offset: 0x00012FBF
		private void Calendar_DayButtonMouseUp(object sender, MouseButtonEventArgs e)
		{
			this.IsDropDownOpen = false;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00014DC8 File Offset: 0x00012FC8
		private void Calendar_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
		{
			if (e.AddedDate != this.DisplayDate)
			{
				base.SetValue(DatePicker.DisplayDateProperty, e.AddedDate.Value);
			}
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x00014E1C File Offset: 0x0001301C
		private void CalendarDayOrMonthButton_PreviewKeyDown(object sender, RoutedEventArgs e)
		{
			Microsoft.Windows.Controls.Calendar calendar = sender as Microsoft.Windows.Controls.Calendar;
			KeyEventArgs keyEventArgs = (KeyEventArgs)e;
			if (keyEventArgs.Key == Key.Escape || ((keyEventArgs.Key == Key.Return || keyEventArgs.Key == Key.Space) && calendar.DisplayMode == CalendarMode.Month))
			{
				this.IsDropDownOpen = false;
				if (keyEventArgs.Key == Key.Escape)
				{
					this.SelectedDate = this._originalSelectedDate;
				}
			}
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00014E7C File Offset: 0x0001307C
		private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count > 0 && this.SelectedDate != null && DateTime.Compare((DateTime)e.AddedItems[0], this.SelectedDate.Value) != 0)
			{
				this.SelectedDate = (DateTime?)e.AddedItems[0];
				return;
			}
			if (e.AddedItems.Count == 0)
			{
				this.SelectedDate = null;
				return;
			}
			if (this.SelectedDate == null && e.AddedItems.Count > 0)
			{
				this.SelectedDate = (DateTime?)e.AddedItems[0];
			}
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x00014F38 File Offset: 0x00013138
		private string DateTimeToString(DateTime d)
		{
			DateTimeFormatInfo dateFormat = DateTimeHelper.GetDateFormat(DateTimeHelper.GetCulture(this));
			switch (this.SelectedDateFormat)
			{
			case DatePickerFormat.Long:
				return string.Format(CultureInfo.CurrentCulture, d.ToString(dateFormat.LongDatePattern, dateFormat), new object[0]);
			case DatePickerFormat.Short:
				return string.Format(CultureInfo.CurrentCulture, d.ToString(dateFormat.ShortDatePattern, dateFormat), new object[0]);
			default:
				return null;
			}
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00014FA8 File Offset: 0x000131A8
		private static DateTime DiscardDayTime(DateTime d)
		{
			int year = d.Year;
			int month = d.Month;
			DateTime result = new DateTime(year, month, 1, 0, 0, 0);
			return result;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00014FD4 File Offset: 0x000131D4
		private static DateTime? DiscardTime(DateTime? d)
		{
			if (d == null)
			{
				return null;
			}
			DateTime value = d.Value;
			int year = value.Year;
			int month = value.Month;
			int day = value.Day;
			DateTime value2 = new DateTime(year, month, day, 0, 0, 0);
			return new DateTime?(value2);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x00015029 File Offset: 0x00013229
		private void DropDownButton_Click(object sender, RoutedEventArgs e)
		{
			this.TogglePopUp();
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x00015031 File Offset: 0x00013231
		private void DropDownButton_MouseLeave(object sender, MouseEventArgs e)
		{
			this._disablePopupReopen = false;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0001503A File Offset: 0x0001323A
		private void TogglePopUp()
		{
			if (this.IsDropDownOpen)
			{
				this.IsDropDownOpen = false;
				return;
			}
			if (this._disablePopupReopen)
			{
				this._disablePopupReopen = false;
				return;
			}
			this.SetSelectedDate();
			this.IsDropDownOpen = true;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0001506C File Offset: 0x0001326C
		private void InitializeCalendar()
		{
			this._calendar = new Microsoft.Windows.Controls.Calendar();
			this._calendar.DayButtonMouseUp += this.Calendar_DayButtonMouseUp;
			this._calendar.DisplayDateChanged += this.Calendar_DisplayDateChanged;
			this._calendar.SelectedDatesChanged += this.Calendar_SelectedDatesChanged;
			this._calendar.DayOrMonthPreviewKeyDown += this.CalendarDayOrMonthButton_PreviewKeyDown;
			this._calendar.HorizontalAlignment = HorizontalAlignment.Left;
			this._calendar.VerticalAlignment = VerticalAlignment.Top;
			this._calendar.SelectionMode = CalendarSelectionMode.SingleDate;
			this._calendar.SetBinding(Control.ForegroundProperty, this.GetDatePickerBinding(Control.ForegroundProperty));
			this._calendar.SetBinding(FrameworkElement.StyleProperty, this.GetDatePickerBinding(DatePicker.CalendarStyleProperty));
			this._calendar.SetBinding(Microsoft.Windows.Controls.Calendar.IsTodayHighlightedProperty, this.GetDatePickerBinding(DatePicker.IsTodayHighlightedProperty));
			this._calendar.SetBinding(Microsoft.Windows.Controls.Calendar.FirstDayOfWeekProperty, this.GetDatePickerBinding(DatePicker.FirstDayOfWeekProperty));
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00015174 File Offset: 0x00013374
		private BindingBase GetDatePickerBinding(DependencyProperty property)
		{
			return new Binding(property.Name)
			{
				Source = this
			};
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00015198 File Offset: 0x00013398
		private static bool IsValidSelectedDateFormat(object value)
		{
			DatePickerFormat datePickerFormat = (DatePickerFormat)value;
			return datePickerFormat == DatePickerFormat.Long || datePickerFormat == DatePickerFormat.Short;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x000151B8 File Offset: 0x000133B8
		private DateTime? ParseText(string text)
		{
			try
			{
				DateTime dateTime = DateTime.Parse(text, DateTimeHelper.GetDateFormat(DateTimeHelper.GetCulture(this)));
				if (Microsoft.Windows.Controls.Calendar.IsValidDateSelection(this._calendar, dateTime))
				{
					return new DateTime?(dateTime);
				}
				DatePickerDateValidationErrorEventArgs datePickerDateValidationErrorEventArgs = new DatePickerDateValidationErrorEventArgs(new ArgumentOutOfRangeException("text", SR.Get(SRID.Calendar_OnSelectedDateChanged_InvalidValue)), text);
				this.OnDateValidationError(datePickerDateValidationErrorEventArgs);
				if (datePickerDateValidationErrorEventArgs.ThrowException)
				{
					throw datePickerDateValidationErrorEventArgs.Exception;
				}
			}
			catch (FormatException exception)
			{
				DatePickerDateValidationErrorEventArgs datePickerDateValidationErrorEventArgs2 = new DatePickerDateValidationErrorEventArgs(exception, text);
				this.OnDateValidationError(datePickerDateValidationErrorEventArgs2);
				if (datePickerDateValidationErrorEventArgs2.ThrowException && datePickerDateValidationErrorEventArgs2.Exception != null)
				{
					throw datePickerDateValidationErrorEventArgs2.Exception;
				}
			}
			return null;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00015270 File Offset: 0x00013470
		private bool ProcessDatePickerKey(KeyEventArgs e)
		{
			Key key = e.Key;
			if (key != Key.Return)
			{
				if (key == Key.System)
				{
					Key systemKey = e.SystemKey;
					if (systemKey == Key.Down && (Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
					{
						this.TogglePopUp();
						return true;
					}
				}
				return false;
			}
			this.SetSelectedDate();
			return true;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x000152B8 File Offset: 0x000134B8
		private void SetSelectedDate()
		{
			if (this._textBox != null)
			{
				if (!string.IsNullOrEmpty(this._textBox.Text))
				{
					string text = this._textBox.Text;
					if (this.SelectedDate != null)
					{
						string a = this.DateTimeToString(this.SelectedDate.Value);
						if (a == text)
						{
							return;
						}
					}
					DateTime? dateTime = this.SetTextBoxValue(text);
					if (!this.SelectedDate.Equals(dateTime))
					{
						this.SelectedDate = dateTime;
						this.DisplayDate = dateTime.Value;
						return;
					}
				}
				else if (this.SelectedDate != null)
				{
					this.SelectedDate = null;
					return;
				}
			}
			else
			{
				DateTime? dateTime2 = this.SetTextBoxValue(this._defaultText);
				if (!this.SelectedDate.Equals(dateTime2))
				{
					this.SelectedDate = dateTime2;
				}
			}
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x000153AC File Offset: 0x000135AC
		private DateTime? SetTextBoxValue(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				base.SetValue(DatePicker.TextProperty, s);
				return this.SelectedDate;
			}
			DateTime? result = this.ParseText(s);
			if (result != null)
			{
				base.SetValue(DatePicker.TextProperty, this.DateTimeToString(result.Value));
				return result;
			}
			if (this.SelectedDate != null)
			{
				string value = this.DateTimeToString(this.SelectedDate.Value);
				base.SetValue(DatePicker.TextProperty, value);
				return this.SelectedDate;
			}
			this.SetWaterMarkText();
			return null;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00015448 File Offset: 0x00013648
		private void SetWaterMarkText()
		{
			if (this._textBox != null)
			{
				DateTimeFormatInfo dateFormat = DateTimeHelper.GetDateFormat(DateTimeHelper.GetCulture(this));
				this.SetTextInternal(string.Empty);
				this._defaultText = string.Empty;
				switch (this.SelectedDateFormat)
				{
				case DatePickerFormat.Long:
					this._textBox.Watermark = string.Format(CultureInfo.CurrentCulture, SR.Get(SRID.DatePicker_WatermarkText), new object[]
					{
						dateFormat.LongDatePattern.ToString()
					});
					return;
				case DatePickerFormat.Short:
					this._textBox.Watermark = string.Format(CultureInfo.CurrentCulture, SR.Get(SRID.DatePicker_WatermarkText), new object[]
					{
						dateFormat.ShortDatePattern.ToString()
					});
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00015503 File Offset: 0x00013703
		private void TextBox_LostFocus(object sender, RoutedEventArgs e)
		{
			this.SetSelectedDate();
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0001550B File Offset: 0x0001370B
		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = (this.ProcessDatePickerKey(e) || e.Handled);
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00015525 File Offset: 0x00013725
		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			this.SetValueNoCallback(DatePicker.TextProperty, this._textBox.Text);
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00015540 File Offset: 0x00013740
		private void UpdateDisabledVisual()
		{
			if (!base.IsEnabled)
			{
				VisualStates.GoToState(this, true, new string[]
				{
					"Disabled",
					"Normal"
				});
				return;
			}
			VisualStates.GoToState(this, true, new string[]
			{
				"Normal"
			});
		}

		// Token: 0x04000163 RID: 355
		private const string ElementRoot = "PART_Root";

		// Token: 0x04000164 RID: 356
		private const string ElementTextBox = "PART_TextBox";

		// Token: 0x04000165 RID: 357
		private const string ElementButton = "PART_Button";

		// Token: 0x04000166 RID: 358
		private const string ElementPopup = "PART_Popup";

		// Token: 0x04000167 RID: 359
		private Microsoft.Windows.Controls.Calendar _calendar;

		// Token: 0x04000168 RID: 360
		private string _defaultText;

		// Token: 0x04000169 RID: 361
		private ButtonBase _dropDownButton;

		// Token: 0x0400016A RID: 362
		private Popup _popUp;

		// Token: 0x0400016B RID: 363
		private bool _disablePopupReopen;

		// Token: 0x0400016C RID: 364
		private bool _shouldCoerceText;

		// Token: 0x0400016D RID: 365
		private string _coercedTextValue;

		// Token: 0x0400016E RID: 366
		private Microsoft.Windows.Controls.Primitives.DatePickerTextBox _textBox;

		// Token: 0x0400016F RID: 367
		private IDictionary<DependencyProperty, bool> _isHandlerSuspended;

		// Token: 0x04000170 RID: 368
		private DateTime? _originalSelectedDate;

		// Token: 0x04000175 RID: 373
		public static readonly DependencyProperty CalendarStyleProperty;

		// Token: 0x04000176 RID: 374
		public static readonly DependencyProperty DisplayDateProperty;

		// Token: 0x04000177 RID: 375
		public static readonly DependencyProperty DisplayDateEndProperty;

		// Token: 0x04000178 RID: 376
		public static readonly DependencyProperty DisplayDateStartProperty;

		// Token: 0x04000179 RID: 377
		public static readonly DependencyProperty FirstDayOfWeekProperty;

		// Token: 0x0400017A RID: 378
		public static readonly DependencyProperty IsDropDownOpenProperty;

		// Token: 0x0400017B RID: 379
		public static readonly DependencyProperty IsTodayHighlightedProperty;

		// Token: 0x0400017C RID: 380
		public static readonly DependencyProperty SelectedDateProperty;

		// Token: 0x0400017D RID: 381
		public static readonly DependencyProperty SelectedDateFormatProperty;

		// Token: 0x0400017E RID: 382
		public static readonly DependencyProperty TextProperty;
	}
}

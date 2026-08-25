using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Windows.Automation.Peers;
using Microsoft.Windows.Controls.Primitives;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200004B RID: 75
	[TemplatePart(Name = "PART_CalendarItem", Type = typeof(CalendarItem))]
	[TemplatePart(Name = "PART_Root", Type = typeof(Panel))]
	public class Calendar : Control
	{
		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060005A3 RID: 1443 RVA: 0x0001644E File Offset: 0x0001464E
		// (remove) Token: 0x060005A4 RID: 1444 RVA: 0x0001645C File Offset: 0x0001465C
		public event EventHandler<SelectionChangedEventArgs> SelectedDatesChanged
		{
			add
			{
				base.AddHandler(Calendar.SelectedDatesChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(Calendar.SelectedDatesChangedEvent, value);
			}
		}

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060005A5 RID: 1445 RVA: 0x0001646A File Offset: 0x0001466A
		// (remove) Token: 0x060005A6 RID: 1446 RVA: 0x00016483 File Offset: 0x00014683
		public event EventHandler<CalendarDateChangedEventArgs> DisplayDateChanged;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060005A7 RID: 1447 RVA: 0x0001649C File Offset: 0x0001469C
		// (remove) Token: 0x060005A8 RID: 1448 RVA: 0x000164B5 File Offset: 0x000146B5
		public event EventHandler<CalendarModeChangedEventArgs> DisplayModeChanged;

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x060005A9 RID: 1449 RVA: 0x000164CE File Offset: 0x000146CE
		// (remove) Token: 0x060005AA RID: 1450 RVA: 0x000164E7 File Offset: 0x000146E7
		public event EventHandler<EventArgs> SelectionModeChanged;

		// Token: 0x060005AB RID: 1451 RVA: 0x00016500 File Offset: 0x00014700
		static Calendar()
		{
			Calendar.SelectedDatesChangedEvent = EventManager.RegisterRoutedEvent("SelectedDatesChanged", RoutingStrategy.Direct, typeof(EventHandler<SelectionChangedEventArgs>), typeof(Calendar));
			Calendar.CalendarButtonStyleProperty = DependencyProperty.Register("CalendarButtonStyle", typeof(Style), typeof(Calendar));
			Calendar.CalendarDayButtonStyleProperty = DependencyProperty.Register("CalendarDayButtonStyle", typeof(Style), typeof(Calendar));
			Calendar.CalendarItemStyleProperty = DependencyProperty.Register("CalendarItemStyle", typeof(Style), typeof(Calendar));
			Calendar.DisplayDateProperty = DependencyProperty.Register("DisplayDate", typeof(DateTime), typeof(Calendar), new FrameworkPropertyMetadata(DateTime.MinValue, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Calendar.OnDisplayDateChanged), new CoerceValueCallback(Calendar.CoerceDisplayDate)));
			Calendar.DisplayDateEndProperty = DependencyProperty.Register("DisplayDateEnd", typeof(DateTime?), typeof(Calendar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Calendar.OnDisplayDateEndChanged), new CoerceValueCallback(Calendar.CoerceDisplayDateEnd)));
			Calendar.DisplayDateStartProperty = DependencyProperty.Register("DisplayDateStart", typeof(DateTime?), typeof(Calendar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Calendar.OnDisplayDateStartChanged), new CoerceValueCallback(Calendar.CoerceDisplayDateStart)));
			Calendar.DisplayModeProperty = DependencyProperty.Register("DisplayMode", typeof(CalendarMode), typeof(Calendar), new FrameworkPropertyMetadata(CalendarMode.Month, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Calendar.OnDisplayModePropertyChanged)), new ValidateValueCallback(Calendar.IsValidDisplayMode));
			Calendar.FirstDayOfWeekProperty = DependencyProperty.Register("FirstDayOfWeek", typeof(DayOfWeek), typeof(Calendar), new FrameworkPropertyMetadata(DateTimeHelper.GetCurrentDateFormat().FirstDayOfWeek, new PropertyChangedCallback(Calendar.OnFirstDayOfWeekChanged)), new ValidateValueCallback(Calendar.IsValidFirstDayOfWeek));
			Calendar.IsTodayHighlightedProperty = DependencyProperty.Register("IsTodayHighlighted", typeof(bool), typeof(Calendar), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(Calendar.OnIsTodayHighlightedChanged)));
			Calendar.SelectedDateProperty = DependencyProperty.Register("SelectedDate", typeof(DateTime?), typeof(Calendar), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Calendar.OnSelectedDateChanged)));
			Calendar.SelectionModeProperty = DependencyProperty.Register("SelectionMode", typeof(CalendarSelectionMode), typeof(Calendar), new FrameworkPropertyMetadata(CalendarSelectionMode.SingleDate, new PropertyChangedCallback(Calendar.OnSelectionModeChanged)), new ValidateValueCallback(Calendar.IsValidSelectionMode));
			FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(Calendar), new FrameworkPropertyMetadata(typeof(Calendar)));
			KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(Calendar), new FrameworkPropertyMetadata(KeyboardNavigationMode.Once));
			KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof(Calendar), new FrameworkPropertyMetadata(KeyboardNavigationMode.Contained));
			EventManager.RegisterClassHandler(typeof(Calendar), UIElement.GotFocusEvent, new RoutedEventHandler(Calendar.OnGotFocus));
			FrameworkElement.LanguageProperty.OverrideMetadata(typeof(Calendar), new FrameworkPropertyMetadata(new PropertyChangedCallback(Calendar.OnLanguageChanged)));
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0001686F File Offset: 0x00014A6F
		public Calendar()
		{
			this._blackoutDates = new CalendarBlackoutDatesCollection(this);
			this._selectedDates = new SelectedDatesCollection(this);
			this.DisplayDate = DateTime.Today;
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060005AD RID: 1453 RVA: 0x0001689A File Offset: 0x00014A9A
		public CalendarBlackoutDatesCollection BlackoutDates
		{
			get
			{
				return this._blackoutDates;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x000168A2 File Offset: 0x00014AA2
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x000168B4 File Offset: 0x00014AB4
		public Style CalendarButtonStyle
		{
			get
			{
				return (Style)base.GetValue(Calendar.CalendarButtonStyleProperty);
			}
			set
			{
				base.SetValue(Calendar.CalendarButtonStyleProperty, value);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x000168C2 File Offset: 0x00014AC2
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x000168D4 File Offset: 0x00014AD4
		public Style CalendarDayButtonStyle
		{
			get
			{
				return (Style)base.GetValue(Calendar.CalendarDayButtonStyleProperty);
			}
			set
			{
				base.SetValue(Calendar.CalendarDayButtonStyleProperty, value);
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060005B2 RID: 1458 RVA: 0x000168E2 File Offset: 0x00014AE2
		// (set) Token: 0x060005B3 RID: 1459 RVA: 0x000168F4 File Offset: 0x00014AF4
		public Style CalendarItemStyle
		{
			get
			{
				return (Style)base.GetValue(Calendar.CalendarItemStyleProperty);
			}
			set
			{
				base.SetValue(Calendar.CalendarItemStyleProperty, value);
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00016902 File Offset: 0x00014B02
		// (set) Token: 0x060005B5 RID: 1461 RVA: 0x00016914 File Offset: 0x00014B14
		public DateTime DisplayDate
		{
			get
			{
				return (DateTime)base.GetValue(Calendar.DisplayDateProperty);
			}
			set
			{
				base.SetValue(Calendar.DisplayDateProperty, value);
			}
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x00016928 File Offset: 0x00014B28
		private static void OnDisplayDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = d as Calendar;
			calendar.DisplayDateInternal = DateTimeHelper.DiscardDayTime((DateTime)e.NewValue);
			calendar.UpdateCellItems();
			calendar.OnDisplayDateChanged(new CalendarDateChangedEventArgs(new DateTime?((DateTime)e.OldValue), new DateTime?((DateTime)e.NewValue)));
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x00016988 File Offset: 0x00014B88
		private static object CoerceDisplayDate(DependencyObject d, object value)
		{
			Calendar calendar = d as Calendar;
			DateTime t = (DateTime)value;
			if (calendar.DisplayDateStart != null && t < calendar.DisplayDateStart.Value)
			{
				value = calendar.DisplayDateStart.Value;
			}
			else if (calendar.DisplayDateEnd != null && t > calendar.DisplayDateEnd.Value)
			{
				value = calendar.DisplayDateEnd.Value;
			}
			return value;
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x00016A20 File Offset: 0x00014C20
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x00016A32 File Offset: 0x00014C32
		public DateTime? DisplayDateEnd
		{
			get
			{
				return (DateTime?)base.GetValue(Calendar.DisplayDateEndProperty);
			}
			set
			{
				base.SetValue(Calendar.DisplayDateEndProperty, value);
			}
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00016A48 File Offset: 0x00014C48
		private static void OnDisplayDateEndChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = d as Calendar;
			calendar.CoerceValue(Calendar.DisplayDateProperty);
			calendar.UpdateCellItems();
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00016A70 File Offset: 0x00014C70
		private static object CoerceDisplayDateEnd(DependencyObject d, object value)
		{
			Calendar calendar = d as Calendar;
			DateTime? dateTime = (DateTime?)value;
			if (dateTime != null)
			{
				if (calendar.DisplayDateStart != null && dateTime.Value < calendar.DisplayDateStart.Value)
				{
					value = calendar.DisplayDateStart;
				}
				DateTime? maximumDate = calendar.SelectedDates.MaximumDate;
				if (maximumDate != null && dateTime.Value < maximumDate.Value)
				{
					value = maximumDate;
				}
			}
			return value;
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x00016B01 File Offset: 0x00014D01
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x00016B13 File Offset: 0x00014D13
		public DateTime? DisplayDateStart
		{
			get
			{
				return (DateTime?)base.GetValue(Calendar.DisplayDateStartProperty);
			}
			set
			{
				base.SetValue(Calendar.DisplayDateStartProperty, value);
			}
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x00016B28 File Offset: 0x00014D28
		private static void OnDisplayDateStartChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = d as Calendar;
			calendar.CoerceValue(Calendar.DisplayDateEndProperty);
			calendar.CoerceValue(Calendar.DisplayDateProperty);
			calendar.UpdateCellItems();
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00016B58 File Offset: 0x00014D58
		private static object CoerceDisplayDateStart(DependencyObject d, object value)
		{
			Calendar calendar = d as Calendar;
			DateTime? dateTime = (DateTime?)value;
			if (dateTime != null)
			{
				DateTime? minimumDate = calendar.SelectedDates.MinimumDate;
				if (minimumDate != null && dateTime.Value > minimumDate.Value)
				{
					value = minimumDate;
				}
			}
			return value;
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00016BAF File Offset: 0x00014DAF
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x00016BC1 File Offset: 0x00014DC1
		public CalendarMode DisplayMode
		{
			get
			{
				return (CalendarMode)base.GetValue(Calendar.DisplayModeProperty);
			}
			set
			{
				base.SetValue(Calendar.DisplayModeProperty, value);
			}
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00016BD4 File Offset: 0x00014DD4
		private static void OnDisplayModePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = d as Calendar;
			CalendarMode newMode = (CalendarMode)e.NewValue;
			CalendarMode calendarMode = (CalendarMode)e.OldValue;
			CalendarItem monthControl = calendar.MonthControl;
			switch (newMode)
			{
			case CalendarMode.Month:
				if (calendarMode == CalendarMode.Year || calendarMode == CalendarMode.Decade)
				{
					calendar.HoverStart = (calendar.HoverEnd = null);
					calendar.CurrentDate = calendar.DisplayDate;
				}
				calendar.UpdateCellItems();
				break;
			case CalendarMode.Year:
			case CalendarMode.Decade:
				if (calendarMode == CalendarMode.Month)
				{
					calendar.DisplayDate = calendar.CurrentDate;
				}
				calendar.UpdateCellItems();
				break;
			}
			calendar.OnDisplayModeChanged(new CalendarModeChangedEventArgs((CalendarMode)e.OldValue, newMode));
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x00016C83 File Offset: 0x00014E83
		// (set) Token: 0x060005C4 RID: 1476 RVA: 0x00016C95 File Offset: 0x00014E95
		public DayOfWeek FirstDayOfWeek
		{
			get
			{
				return (DayOfWeek)base.GetValue(Calendar.FirstDayOfWeekProperty);
			}
			set
			{
				base.SetValue(Calendar.FirstDayOfWeekProperty, value);
			}
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00016CA8 File Offset: 0x00014EA8
		private static void OnFirstDayOfWeekChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = d as Calendar;
			calendar.UpdateCellItems();
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00016CC2 File Offset: 0x00014EC2
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x00016CD4 File Offset: 0x00014ED4
		public bool IsTodayHighlighted
		{
			get
			{
				return (bool)base.GetValue(Calendar.IsTodayHighlightedProperty);
			}
			set
			{
				base.SetValue(Calendar.IsTodayHighlightedProperty, value);
			}
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00016CE8 File Offset: 0x00014EE8
		private static void OnIsTodayHighlightedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = d as Calendar;
			int num = DateTimeHelper.CompareYearMonth(calendar.DisplayDateInternal, DateTime.Today);
			if (num > -2 && num < 2)
			{
				calendar.UpdateCellItems();
			}
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00016D1C File Offset: 0x00014F1C
		private static void OnLanguageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = d as Calendar;
			if (DependencyPropertyHelper.GetValueSource(d, Calendar.FirstDayOfWeekProperty).BaseValueSource == BaseValueSource.Default)
			{
				calendar.CoerceValue(Calendar.FirstDayOfWeekProperty);
				calendar.UpdateCellItems();
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x00016D57 File Offset: 0x00014F57
		// (set) Token: 0x060005CB RID: 1483 RVA: 0x00016D69 File Offset: 0x00014F69
		public DateTime? SelectedDate
		{
			get
			{
				return (DateTime?)base.GetValue(Calendar.SelectedDateProperty);
			}
			set
			{
				base.SetValue(Calendar.SelectedDateProperty, value);
			}
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00016D7C File Offset: 0x00014F7C
		private static void OnSelectedDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = d as Calendar;
			if (calendar.SelectionMode == CalendarSelectionMode.None && e.NewValue != null)
			{
				throw new InvalidOperationException(SR.Get(SRID.Calendar_OnSelectedDateChanged_InvalidOperation));
			}
			DateTime? dateTime = (DateTime?)e.NewValue;
			if (!Calendar.IsValidDateSelection(calendar, dateTime))
			{
				throw new ArgumentOutOfRangeException("d", SR.Get(SRID.Calendar_OnSelectedDateChanged_InvalidValue));
			}
			if (dateTime == null)
			{
				calendar.SelectedDates.ClearInternal(true);
			}
			else if (dateTime != null && (calendar.SelectedDates.Count <= 0 || !(calendar.SelectedDates[0] == dateTime.Value)))
			{
				calendar.SelectedDates.ClearInternal();
				calendar.SelectedDates.Add(dateTime.Value);
			}
			if (calendar.SelectionMode == CalendarSelectionMode.SingleDate)
			{
				if (dateTime != null)
				{
					calendar.CurrentDate = dateTime.Value;
				}
				calendar.UpdateCellItems();
				return;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x00016E72 File Offset: 0x00015072
		public SelectedDatesCollection SelectedDates
		{
			get
			{
				return this._selectedDates;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060005CE RID: 1486 RVA: 0x00016E7A File Offset: 0x0001507A
		// (set) Token: 0x060005CF RID: 1487 RVA: 0x00016E8C File Offset: 0x0001508C
		public CalendarSelectionMode SelectionMode
		{
			get
			{
				return (CalendarSelectionMode)base.GetValue(Calendar.SelectionModeProperty);
			}
			set
			{
				base.SetValue(Calendar.SelectionModeProperty, value);
			}
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00016EA0 File Offset: 0x000150A0
		private static void OnSelectionModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Calendar calendar = d as Calendar;
			calendar.HoverStart = (calendar.HoverEnd = null);
			calendar.SelectedDates.ClearInternal(true);
			calendar.OnSelectionModeChanged(EventArgs.Empty);
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x060005D1 RID: 1489 RVA: 0x00016EE3 File Offset: 0x000150E3
		// (remove) Token: 0x060005D2 RID: 1490 RVA: 0x00016EFC File Offset: 0x000150FC
		internal event MouseButtonEventHandler DayButtonMouseUp;

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x060005D3 RID: 1491 RVA: 0x00016F15 File Offset: 0x00015115
		// (remove) Token: 0x060005D4 RID: 1492 RVA: 0x00016F2E File Offset: 0x0001512E
		internal event RoutedEventHandler DayOrMonthPreviewKeyDown;

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x00016F47 File Offset: 0x00015147
		// (set) Token: 0x060005D6 RID: 1494 RVA: 0x00016F4F File Offset: 0x0001514F
		internal bool DatePickerDisplayDateFlag { get; set; }

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x00016F58 File Offset: 0x00015158
		// (set) Token: 0x060005D8 RID: 1496 RVA: 0x00016F60 File Offset: 0x00015160
		internal DateTime DisplayDateInternal { get; private set; }

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x00016F6C File Offset: 0x0001516C
		internal DateTime DisplayDateEndInternal
		{
			get
			{
				return this.DisplayDateEnd.GetValueOrDefault(DateTime.MaxValue);
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060005DA RID: 1498 RVA: 0x00016F8C File Offset: 0x0001518C
		internal DateTime DisplayDateStartInternal
		{
			get
			{
				return this.DisplayDateStart.GetValueOrDefault(DateTime.MinValue);
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x00016FAC File Offset: 0x000151AC
		// (set) Token: 0x060005DC RID: 1500 RVA: 0x00016FBF File Offset: 0x000151BF
		internal DateTime CurrentDate
		{
			get
			{
				return this._currentDate.GetValueOrDefault(this.DisplayDateInternal);
			}
			set
			{
				this._currentDate = new DateTime?(value);
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x00016FD0 File Offset: 0x000151D0
		// (set) Token: 0x060005DE RID: 1502 RVA: 0x00016FF6 File Offset: 0x000151F6
		internal DateTime? HoverStart
		{
			get
			{
				if (this.SelectionMode != CalendarSelectionMode.None)
				{
					return this._hoverStart;
				}
				return null;
			}
			set
			{
				this._hoverStart = value;
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x00017000 File Offset: 0x00015200
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x00017026 File Offset: 0x00015226
		internal DateTime? HoverEnd
		{
			get
			{
				if (this.SelectionMode != CalendarSelectionMode.None)
				{
					return this._hoverEnd;
				}
				return null;
			}
			set
			{
				this._hoverEnd = value;
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060005E1 RID: 1505 RVA: 0x0001702F File Offset: 0x0001522F
		internal CalendarItem MonthControl
		{
			get
			{
				return this._monthControl;
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x00017037 File Offset: 0x00015237
		internal DateTime DisplayMonth
		{
			get
			{
				return DateTimeHelper.DiscardDayTime(this.DisplayDate);
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x00017044 File Offset: 0x00015244
		internal DateTime DisplayYear
		{
			get
			{
				return new DateTime(this.DisplayDate.Year, 1, 1);
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00017066 File Offset: 0x00015266
		private bool IsRightToLeft
		{
			get
			{
				return base.FlowDirection == FlowDirection.RightToLeft;
			}
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00017074 File Offset: 0x00015274
		public override void OnApplyTemplate()
		{
			if (this._monthControl != null)
			{
				this._monthControl.Owner = null;
			}
			base.OnApplyTemplate();
			this._monthControl = (base.GetTemplateChild("PART_CalendarItem") as CalendarItem);
			if (this._monthControl != null)
			{
				this._monthControl.Owner = this;
			}
			this.CurrentDate = this.DisplayDate;
			this.UpdateCellItems();
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x000170D8 File Offset: 0x000152D8
		public override string ToString()
		{
			if (this.SelectedDate != null)
			{
				return this.SelectedDate.Value.ToString(DateTimeHelper.GetDateFormat(DateTimeHelper.GetCulture(this)));
			}
			return string.Empty;
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0001711C File Offset: 0x0001531C
		protected virtual void OnSelectedDatesChanged(SelectionChangedEventArgs e)
		{
			base.RaiseEvent(e);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x00017128 File Offset: 0x00015328
		protected virtual void OnDisplayDateChanged(CalendarDateChangedEventArgs e)
		{
			EventHandler<CalendarDateChangedEventArgs> displayDateChanged = this.DisplayDateChanged;
			if (displayDateChanged != null)
			{
				displayDateChanged(this, e);
			}
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x00017148 File Offset: 0x00015348
		protected virtual void OnDisplayModeChanged(CalendarModeChangedEventArgs e)
		{
			EventHandler<CalendarModeChangedEventArgs> displayModeChanged = this.DisplayModeChanged;
			if (displayModeChanged != null)
			{
				displayModeChanged(this, e);
			}
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x00017168 File Offset: 0x00015368
		protected virtual void OnSelectionModeChanged(EventArgs e)
		{
			EventHandler<EventArgs> selectionModeChanged = this.SelectionModeChanged;
			if (selectionModeChanged != null)
			{
				selectionModeChanged(this, e);
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x00017187 File Offset: 0x00015387
		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new Microsoft.Windows.Automation.Peers.CalendarAutomationPeer(this);
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0001718F File Offset: 0x0001538F
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (!e.Handled)
			{
				e.Handled = this.ProcessCalendarKey(e);
			}
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x000171A6 File Offset: 0x000153A6
		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (!e.Handled && (e.Key == Key.LeftShift || e.Key == Key.RightShift))
			{
				this.ProcessShiftKeyUp();
			}
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x000171CC File Offset: 0x000153CC
		internal CalendarDayButton FindDayButtonFromDay(DateTime day)
		{
			if (this.MonthControl != null)
			{
				foreach (CalendarDayButton calendarDayButton in this.MonthControl.GetCalendarDayButtons())
				{
					if (calendarDayButton.DataContext is DateTime && DateTimeHelper.CompareDays((DateTime)calendarDayButton.DataContext, day) == 0)
					{
						return calendarDayButton;
					}
				}
			}
			return null;
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x00017248 File Offset: 0x00015448
		internal static bool IsValidDateSelection(Calendar cal, object value)
		{
			return value == null || !cal.BlackoutDates.Contains((DateTime)value);
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00017264 File Offset: 0x00015464
		internal void OnDayButtonMouseUp(MouseButtonEventArgs e)
		{
			MouseButtonEventHandler dayButtonMouseUp = this.DayButtonMouseUp;
			if (dayButtonMouseUp != null)
			{
				dayButtonMouseUp(this, e);
			}
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x00017284 File Offset: 0x00015484
		internal void OnDayOrMonthPreviewKeyDown(RoutedEventArgs e)
		{
			RoutedEventHandler dayOrMonthPreviewKeyDown = this.DayOrMonthPreviewKeyDown;
			if (dayOrMonthPreviewKeyDown != null)
			{
				dayOrMonthPreviewKeyDown(this, e);
			}
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x000172A3 File Offset: 0x000154A3
		internal void OnDayClick(DateTime selectedDate)
		{
			if (this.SelectionMode == CalendarSelectionMode.None)
			{
				this.CurrentDate = selectedDate;
			}
			if (DateTimeHelper.CompareYearMonth(selectedDate, this.DisplayDateInternal) != 0)
			{
				this.MoveDisplayTo(new DateTime?(selectedDate));
				return;
			}
			this.UpdateCellItems();
			this.FocusDate(selectedDate);
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x000172E0 File Offset: 0x000154E0
		internal void OnCalendarButtonPressed(CalendarButton b, bool switchDisplayMode)
		{
			if (b.DataContext is DateTime)
			{
				DateTime yearMonth = (DateTime)b.DataContext;
				DateTime? dateTime = null;
				CalendarMode displayMode = CalendarMode.Month;
				switch (this.DisplayMode)
				{
				case CalendarMode.Year:
					dateTime = DateTimeHelper.SetYearMonth(this.DisplayDate, yearMonth);
					displayMode = CalendarMode.Month;
					break;
				case CalendarMode.Decade:
					dateTime = DateTimeHelper.SetYear(this.DisplayDate, yearMonth.Year);
					displayMode = CalendarMode.Year;
					break;
				}
				if (dateTime != null)
				{
					this.DisplayDate = dateTime.Value;
					if (switchDisplayMode)
					{
						this.DisplayMode = displayMode;
						this.FocusDate((this.DisplayMode == CalendarMode.Month) ? this.CurrentDate : this.DisplayDate);
					}
				}
			}
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00017390 File Offset: 0x00015590
		private DateTime? GetDateOffset(DateTime date, int offset, CalendarMode displayMode)
		{
			DateTime? result = null;
			switch (displayMode)
			{
			case CalendarMode.Month:
				result = DateTimeHelper.AddMonths(date, offset);
				break;
			case CalendarMode.Year:
				result = DateTimeHelper.AddYears(date, offset);
				break;
			case CalendarMode.Decade:
				result = DateTimeHelper.AddYears(this.DisplayDate, offset * 10);
				break;
			}
			return result;
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x000173E0 File Offset: 0x000155E0
		private void MoveDisplayTo(DateTime? date)
		{
			if (date != null)
			{
				DateTime date2 = date.Value.Date;
				switch (this.DisplayMode)
				{
				case CalendarMode.Month:
					this.DisplayDate = DateTimeHelper.DiscardDayTime(date2);
					this.CurrentDate = date2;
					this.UpdateCellItems();
					break;
				case CalendarMode.Year:
				case CalendarMode.Decade:
					this.DisplayDate = date2;
					this.UpdateCellItems();
					break;
				}
				this.FocusDate(date2);
			}
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00017450 File Offset: 0x00015650
		internal void OnNextClick()
		{
			DateTime? dateOffset = this.GetDateOffset(this.DisplayDate, 1, this.DisplayMode);
			if (dateOffset != null)
			{
				this.MoveDisplayTo(new DateTime?(DateTimeHelper.DiscardDayTime(dateOffset.Value)));
			}
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x00017494 File Offset: 0x00015694
		internal void OnPreviousClick()
		{
			DateTime? dateOffset = this.GetDateOffset(this.DisplayDate, -1, this.DisplayMode);
			if (dateOffset != null)
			{
				this.MoveDisplayTo(new DateTime?(DateTimeHelper.DiscardDayTime(dateOffset.Value)));
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x000174D8 File Offset: 0x000156D8
		internal void OnSelectedDatesCollectionChanged(SelectionChangedEventArgs e)
		{
			if (Calendar.IsSelectionChanged(e))
			{
				if (AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementSelected) || AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementAddedToSelection) || AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection))
				{
					Microsoft.Windows.Automation.Peers.CalendarAutomationPeer calendarAutomationPeer = UIElementAutomationPeer.FromElement(this) as Microsoft.Windows.Automation.Peers.CalendarAutomationPeer;
					if (calendarAutomationPeer != null)
					{
						calendarAutomationPeer.RaiseSelectionEvents(e);
					}
				}
				this.CoerceFromSelection();
				this.OnSelectedDatesChanged(e);
			}
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00017528 File Offset: 0x00015728
		internal void UpdateCellItems()
		{
			CalendarItem monthControl = this.MonthControl;
			if (monthControl != null)
			{
				switch (this.DisplayMode)
				{
				case CalendarMode.Month:
					monthControl.UpdateMonthMode();
					return;
				case CalendarMode.Year:
					monthControl.UpdateYearMode();
					return;
				case CalendarMode.Decade:
					monthControl.UpdateDecadeMode();
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x0001756D File Offset: 0x0001576D
		private void CoerceFromSelection()
		{
			base.CoerceValue(Calendar.DisplayDateStartProperty);
			base.CoerceValue(Calendar.DisplayDateEndProperty);
			base.CoerceValue(Calendar.DisplayDateProperty);
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00017590 File Offset: 0x00015790
		private void AddKeyboardSelection()
		{
			if (this.HoverStart != null)
			{
				this.SelectedDates.ClearInternal();
				this.SelectedDates.AddRange(this.HoverStart.Value, this.CurrentDate);
			}
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x000175D8 File Offset: 0x000157D8
		private static bool IsSelectionChanged(SelectionChangedEventArgs e)
		{
			if (e.AddedItems.Count != e.RemovedItems.Count)
			{
				return true;
			}
			foreach (object obj in e.AddedItems)
			{
				DateTime dateTime = (DateTime)obj;
				if (!e.RemovedItems.Contains(dateTime))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00017660 File Offset: 0x00015860
		private static bool IsValidDisplayMode(object value)
		{
			CalendarMode calendarMode = (CalendarMode)value;
			return calendarMode == CalendarMode.Month || calendarMode == CalendarMode.Year || calendarMode == CalendarMode.Decade;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00017684 File Offset: 0x00015884
		internal static bool IsValidFirstDayOfWeek(object value)
		{
			DayOfWeek dayOfWeek = (DayOfWeek)value;
			return dayOfWeek == DayOfWeek.Sunday || dayOfWeek == DayOfWeek.Monday || dayOfWeek == DayOfWeek.Tuesday || dayOfWeek == DayOfWeek.Wednesday || dayOfWeek == DayOfWeek.Thursday || dayOfWeek == DayOfWeek.Friday || dayOfWeek == DayOfWeek.Saturday;
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x000176B8 File Offset: 0x000158B8
		private static bool IsValidKeyboardSelection(Calendar cal, object value)
		{
			return value == null || (!cal.BlackoutDates.Contains((DateTime)value) && DateTime.Compare((DateTime)value, cal.DisplayDateStartInternal) >= 0 && DateTime.Compare((DateTime)value, cal.DisplayDateEndInternal) <= 0);
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0001770C File Offset: 0x0001590C
		private static bool IsValidSelectionMode(object value)
		{
			CalendarSelectionMode calendarSelectionMode = (CalendarSelectionMode)value;
			return calendarSelectionMode == CalendarSelectionMode.SingleDate || calendarSelectionMode == CalendarSelectionMode.SingleRange || calendarSelectionMode == CalendarSelectionMode.MultipleRange || calendarSelectionMode == CalendarSelectionMode.None;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x00017731 File Offset: 0x00015931
		private void OnSelectedMonthChanged(DateTime? selectedMonth)
		{
			if (selectedMonth != null)
			{
				this.DisplayDate = selectedMonth.Value;
				this.UpdateCellItems();
				this.FocusDate(selectedMonth.Value);
			}
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x0001775C File Offset: 0x0001595C
		private void OnSelectedYearChanged(DateTime? selectedYear)
		{
			if (selectedYear != null)
			{
				this.DisplayDate = selectedYear.Value;
				this.UpdateCellItems();
				this.FocusDate(selectedYear.Value);
			}
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00017787 File Offset: 0x00015987
		internal void FocusDate(DateTime date)
		{
			if (this.MonthControl != null)
			{
				this.MonthControl.FocusDate(date);
			}
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x000177A0 File Offset: 0x000159A0
		private static void OnGotFocus(object sender, RoutedEventArgs e)
		{
			Calendar calendar = (Calendar)sender;
			if (!e.Handled && e.OriginalSource == calendar)
			{
				if (calendar.SelectedDate != null && DateTimeHelper.CompareYearMonth(calendar.SelectedDate.Value, calendar.DisplayDateInternal) == 0)
				{
					calendar.FocusDate(calendar.SelectedDate.Value);
				}
				else
				{
					calendar.FocusDate(calendar.DisplayDate);
				}
				e.Handled = true;
			}
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0001781C File Offset: 0x00015A1C
		private bool ProcessCalendarKey(KeyEventArgs e)
		{
			if (this.DisplayMode == CalendarMode.Month)
			{
				CalendarDayButton calendarDayButton = (this.MonthControl != null) ? this.MonthControl.GetCalendarDayButton(this.CurrentDate) : null;
				if (DateTimeHelper.CompareYearMonth(this.CurrentDate, this.DisplayDateInternal) != 0 && calendarDayButton != null && !calendarDayButton.IsInactive)
				{
					return false;
				}
			}
			bool ctrl;
			bool shift;
			KeyboardHelper.GetMetaKeyState(out ctrl, out shift);
			Key key = e.Key;
			if (key != Key.Return)
			{
				switch (key)
				{
				case Key.Space:
					break;
				case Key.Prior:
					this.ProcessPageUpKey(shift);
					return true;
				case Key.Next:
					this.ProcessPageDownKey(shift);
					return true;
				case Key.End:
					this.ProcessEndKey(shift);
					return true;
				case Key.Home:
					this.ProcessHomeKey(shift);
					return true;
				case Key.Left:
					this.ProcessLeftKey(shift);
					return true;
				case Key.Up:
					this.ProcessUpKey(ctrl, shift);
					return true;
				case Key.Right:
					this.ProcessRightKey(shift);
					return true;
				case Key.Down:
					this.ProcessDownKey(ctrl, shift);
					return true;
				default:
					return false;
				}
			}
			return this.ProcessEnterKey();
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00017904 File Offset: 0x00015B04
		private void ProcessDownKey(bool ctrl, bool shift)
		{
			switch (this.DisplayMode)
			{
			case CalendarMode.Month:
				if (!ctrl || shift)
				{
					DateTime? nonBlackoutDate = this._blackoutDates.GetNonBlackoutDate(DateTimeHelper.AddDays(this.CurrentDate, 7), 1);
					this.ProcessSelection(shift, nonBlackoutDate);
					return;
				}
				break;
			case CalendarMode.Year:
			{
				if (ctrl)
				{
					this.DisplayMode = CalendarMode.Month;
					this.FocusDate(this.DisplayDate);
					return;
				}
				DateTime? selectedMonth = DateTimeHelper.AddMonths(this.DisplayDate, 4);
				this.OnSelectedMonthChanged(selectedMonth);
				return;
			}
			case CalendarMode.Decade:
			{
				if (ctrl)
				{
					this.DisplayMode = CalendarMode.Year;
					this.FocusDate(this.DisplayDate);
					return;
				}
				DateTime? selectedYear = DateTimeHelper.AddYears(this.DisplayDate, 4);
				this.OnSelectedYearChanged(selectedYear);
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000179AC File Offset: 0x00015BAC
		private void ProcessEndKey(bool shift)
		{
			switch (this.DisplayMode)
			{
			case CalendarMode.Month:
			{
				DateTime displayDate = this.DisplayDate;
				DateTime? lastSelectedDate = new DateTime?(new DateTime(this.DisplayDateInternal.Year, this.DisplayDateInternal.Month, 1));
				if (DateTimeHelper.CompareYearMonth(DateTime.MaxValue, lastSelectedDate.Value) > 0)
				{
					lastSelectedDate = new DateTime?(DateTimeHelper.AddMonths(lastSelectedDate.Value, 1).Value);
					lastSelectedDate = new DateTime?(DateTimeHelper.AddDays(lastSelectedDate.Value, -1).Value);
				}
				else
				{
					lastSelectedDate = new DateTime?(DateTime.MaxValue);
				}
				this.ProcessSelection(shift, lastSelectedDate);
				return;
			}
			case CalendarMode.Year:
			{
				DateTime value = new DateTime(this.DisplayDate.Year, 12, 1);
				this.OnSelectedMonthChanged(new DateTime?(value));
				return;
			}
			case CalendarMode.Decade:
			{
				DateTime? selectedYear = new DateTime?(new DateTime(DateTimeHelper.EndOfDecade(this.DisplayDate), 1, 1));
				this.OnSelectedYearChanged(selectedYear);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x00017AB0 File Offset: 0x00015CB0
		private bool ProcessEnterKey()
		{
			switch (this.DisplayMode)
			{
			case CalendarMode.Year:
				this.DisplayMode = CalendarMode.Month;
				this.FocusDate(this.DisplayDate);
				return true;
			case CalendarMode.Decade:
				this.DisplayMode = CalendarMode.Year;
				this.FocusDate(this.DisplayDate);
				return true;
			default:
				return false;
			}
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00017B04 File Offset: 0x00015D04
		private void ProcessHomeKey(bool shift)
		{
			switch (this.DisplayMode)
			{
			case CalendarMode.Month:
			{
				DateTime? lastSelectedDate = new DateTime?(new DateTime(this.DisplayDateInternal.Year, this.DisplayDateInternal.Month, 1));
				this.ProcessSelection(shift, lastSelectedDate);
				return;
			}
			case CalendarMode.Year:
			{
				DateTime value = new DateTime(this.DisplayDate.Year, 1, 1);
				this.OnSelectedMonthChanged(new DateTime?(value));
				return;
			}
			case CalendarMode.Decade:
			{
				DateTime? selectedYear = new DateTime?(new DateTime(DateTimeHelper.DecadeOfDate(this.DisplayDate), 1, 1));
				this.OnSelectedYearChanged(selectedYear);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x00017BA4 File Offset: 0x00015DA4
		private void ProcessLeftKey(bool shift)
		{
			int num = (!this.IsRightToLeft) ? -1 : 1;
			switch (this.DisplayMode)
			{
			case CalendarMode.Month:
			{
				DateTime? nonBlackoutDate = this._blackoutDates.GetNonBlackoutDate(DateTimeHelper.AddDays(this.CurrentDate, num), num);
				this.ProcessSelection(shift, nonBlackoutDate);
				return;
			}
			case CalendarMode.Year:
			{
				DateTime? selectedMonth = DateTimeHelper.AddMonths(this.DisplayDate, num);
				this.OnSelectedMonthChanged(selectedMonth);
				return;
			}
			case CalendarMode.Decade:
			{
				DateTime? selectedYear = DateTimeHelper.AddYears(this.DisplayDate, num);
				this.OnSelectedYearChanged(selectedYear);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00017C28 File Offset: 0x00015E28
		private void ProcessPageDownKey(bool shift)
		{
			switch (this.DisplayMode)
			{
			case CalendarMode.Month:
			{
				DateTime? nonBlackoutDate = this._blackoutDates.GetNonBlackoutDate(DateTimeHelper.AddMonths(this.CurrentDate, 1), 1);
				this.ProcessSelection(shift, nonBlackoutDate);
				return;
			}
			case CalendarMode.Year:
			{
				DateTime? selectedMonth = DateTimeHelper.AddYears(this.DisplayDate, 1);
				this.OnSelectedMonthChanged(selectedMonth);
				return;
			}
			case CalendarMode.Decade:
			{
				DateTime? selectedYear = DateTimeHelper.AddYears(this.DisplayDate, 10);
				this.OnSelectedYearChanged(selectedYear);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00017C9C File Offset: 0x00015E9C
		private void ProcessPageUpKey(bool shift)
		{
			switch (this.DisplayMode)
			{
			case CalendarMode.Month:
			{
				DateTime? nonBlackoutDate = this._blackoutDates.GetNonBlackoutDate(DateTimeHelper.AddMonths(this.CurrentDate, -1), -1);
				this.ProcessSelection(shift, nonBlackoutDate);
				return;
			}
			case CalendarMode.Year:
			{
				DateTime? selectedMonth = DateTimeHelper.AddYears(this.DisplayDate, -1);
				this.OnSelectedMonthChanged(selectedMonth);
				return;
			}
			case CalendarMode.Decade:
			{
				DateTime? selectedYear = DateTimeHelper.AddYears(this.DisplayDate, -10);
				this.OnSelectedYearChanged(selectedYear);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00017D10 File Offset: 0x00015F10
		private void ProcessRightKey(bool shift)
		{
			int num = (!this.IsRightToLeft) ? 1 : -1;
			switch (this.DisplayMode)
			{
			case CalendarMode.Month:
			{
				DateTime? nonBlackoutDate = this._blackoutDates.GetNonBlackoutDate(DateTimeHelper.AddDays(this.CurrentDate, num), num);
				this.ProcessSelection(shift, nonBlackoutDate);
				return;
			}
			case CalendarMode.Year:
			{
				DateTime? selectedMonth = DateTimeHelper.AddMonths(this.DisplayDate, num);
				this.OnSelectedMonthChanged(selectedMonth);
				return;
			}
			case CalendarMode.Decade:
			{
				DateTime? selectedYear = DateTimeHelper.AddYears(this.DisplayDate, num);
				this.OnSelectedYearChanged(selectedYear);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x00017D94 File Offset: 0x00015F94
		private void ProcessSelection(bool shift, DateTime? lastSelectedDate)
		{
			if (this.SelectionMode == CalendarSelectionMode.None && lastSelectedDate != null)
			{
				this.OnDayClick(lastSelectedDate.Value);
				return;
			}
			if (lastSelectedDate != null && Calendar.IsValidKeyboardSelection(this, lastSelectedDate.Value))
			{
				if (this.SelectionMode == CalendarSelectionMode.SingleRange || this.SelectionMode == CalendarSelectionMode.MultipleRange)
				{
					this.SelectedDates.ClearInternal();
					if (shift)
					{
						this._isShiftPressed = true;
						if (this.HoverStart == null)
						{
							this.HoverStart = (this.HoverEnd = new DateTime?(this.CurrentDate));
						}
						CalendarDateRange range;
						if (DateTime.Compare(this.HoverStart.Value, lastSelectedDate.Value) < 0)
						{
							range = new CalendarDateRange(this.HoverStart.Value, lastSelectedDate.Value);
						}
						else
						{
							range = new CalendarDateRange(lastSelectedDate.Value, this.HoverStart.Value);
						}
						if (!this.BlackoutDates.ContainsAny(range))
						{
							this._currentDate = lastSelectedDate;
							this.HoverEnd = lastSelectedDate;
						}
						this.OnDayClick(this.CurrentDate);
					}
					else
					{
						this.HoverStart = (this.HoverEnd = new DateTime?(this.CurrentDate = lastSelectedDate.Value));
						this.AddKeyboardSelection();
						this.OnDayClick(lastSelectedDate.Value);
					}
				}
				else
				{
					this.CurrentDate = lastSelectedDate.Value;
					this.HoverStart = (this.HoverEnd = null);
					if (this.SelectedDates.Count > 0)
					{
						this.SelectedDates[0] = lastSelectedDate.Value;
					}
					else
					{
						this.SelectedDates.Add(lastSelectedDate.Value);
					}
					this.OnDayClick(lastSelectedDate.Value);
				}
				this.UpdateCellItems();
			}
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00017F6C File Offset: 0x0001616C
		private void ProcessShiftKeyUp()
		{
			if (this._isShiftPressed && (this.SelectionMode == CalendarSelectionMode.SingleRange || this.SelectionMode == CalendarSelectionMode.MultipleRange))
			{
				this.AddKeyboardSelection();
				this._isShiftPressed = false;
				this.HoverStart = (this.HoverEnd = null);
			}
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00017FB8 File Offset: 0x000161B8
		private void ProcessUpKey(bool ctrl, bool shift)
		{
			switch (this.DisplayMode)
			{
			case CalendarMode.Month:
			{
				if (ctrl)
				{
					this.DisplayMode = CalendarMode.Year;
					this.FocusDate(this.DisplayDate);
					return;
				}
				DateTime? nonBlackoutDate = this._blackoutDates.GetNonBlackoutDate(DateTimeHelper.AddDays(this.CurrentDate, -7), -1);
				this.ProcessSelection(shift, nonBlackoutDate);
				return;
			}
			case CalendarMode.Year:
			{
				if (ctrl)
				{
					this.DisplayMode = CalendarMode.Decade;
					this.FocusDate(this.DisplayDate);
					return;
				}
				DateTime? selectedMonth = DateTimeHelper.AddMonths(this.DisplayDate, -4);
				this.OnSelectedMonthChanged(selectedMonth);
				return;
			}
			case CalendarMode.Decade:
				if (!ctrl)
				{
					DateTime? selectedYear = DateTimeHelper.AddYears(this.DisplayDate, -4);
					this.OnSelectedYearChanged(selectedYear);
				}
				return;
			default:
				return;
			}
		}

		// Token: 0x04000194 RID: 404
		private const string ElementRoot = "PART_Root";

		// Token: 0x04000195 RID: 405
		private const string ElementMonth = "PART_CalendarItem";

		// Token: 0x04000196 RID: 406
		private const int COLS = 7;

		// Token: 0x04000197 RID: 407
		private const int ROWS = 7;

		// Token: 0x04000198 RID: 408
		private const int YEAR_ROWS = 3;

		// Token: 0x04000199 RID: 409
		private const int YEAR_COLS = 4;

		// Token: 0x0400019A RID: 410
		private const int YEARS_PER_DECADE = 10;

		// Token: 0x0400019B RID: 411
		private DateTime? _hoverStart;

		// Token: 0x0400019C RID: 412
		private DateTime? _hoverEnd;

		// Token: 0x0400019D RID: 413
		private bool _isShiftPressed;

		// Token: 0x0400019E RID: 414
		private DateTime? _currentDate;

		// Token: 0x0400019F RID: 415
		private CalendarItem _monthControl;

		// Token: 0x040001A0 RID: 416
		private CalendarBlackoutDatesCollection _blackoutDates;

		// Token: 0x040001A1 RID: 417
		private SelectedDatesCollection _selectedDates;

		// Token: 0x040001A6 RID: 422
		public static readonly DependencyProperty CalendarButtonStyleProperty;

		// Token: 0x040001A7 RID: 423
		public static readonly DependencyProperty CalendarDayButtonStyleProperty;

		// Token: 0x040001A8 RID: 424
		public static readonly DependencyProperty CalendarItemStyleProperty;

		// Token: 0x040001A9 RID: 425
		public static readonly DependencyProperty DisplayDateProperty;

		// Token: 0x040001AA RID: 426
		public static readonly DependencyProperty DisplayDateEndProperty;

		// Token: 0x040001AB RID: 427
		public static readonly DependencyProperty DisplayDateStartProperty;

		// Token: 0x040001AC RID: 428
		public static readonly DependencyProperty DisplayModeProperty;

		// Token: 0x040001AD RID: 429
		public static readonly DependencyProperty FirstDayOfWeekProperty;

		// Token: 0x040001AE RID: 430
		public static readonly DependencyProperty IsTodayHighlightedProperty;

		// Token: 0x040001AF RID: 431
		public static readonly DependencyProperty SelectedDateProperty;

		// Token: 0x040001B0 RID: 432
		public static readonly DependencyProperty SelectionModeProperty;
	}
}

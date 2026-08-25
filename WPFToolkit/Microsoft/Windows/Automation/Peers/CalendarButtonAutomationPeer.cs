using System;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x02000065 RID: 101
	public sealed class CalendarButtonAutomationPeer : ButtonAutomationPeer, IGridItemProvider, ISelectionItemProvider
	{
		// Token: 0x06000792 RID: 1938 RVA: 0x000223D0 File Offset: 0x000205D0
		public CalendarButtonAutomationPeer(CalendarButton owner) : base(owner)
		{
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x000223D9 File Offset: 0x000205D9
		private Microsoft.Windows.Controls.Calendar OwningCalendar
		{
			get
			{
				return this.OwningCalendarButton.Owner;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x000223E8 File Offset: 0x000205E8
		private IRawElementProviderSimple OwningCalendarAutomationPeer
		{
			get
			{
				if (this.OwningCalendar != null)
				{
					AutomationPeer automationPeer = UIElementAutomationPeer.CreatePeerForElement(this.OwningCalendar);
					if (automationPeer != null)
					{
						return base.ProviderFromPeer(automationPeer);
					}
				}
				return null;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x06000795 RID: 1941 RVA: 0x00022415 File Offset: 0x00020615
		private CalendarButton OwningCalendarButton
		{
			get
			{
				return base.Owner as CalendarButton;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000796 RID: 1942 RVA: 0x00022424 File Offset: 0x00020624
		private DateTime? Date
		{
			get
			{
				if (this.OwningCalendarButton != null && this.OwningCalendarButton.DataContext is DateTime)
				{
					return (DateTime?)this.OwningCalendarButton.DataContext;
				}
				return null;
			}
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x00022468 File Offset: 0x00020668
		public override object GetPattern(PatternInterface patternInterface)
		{
			object result;
			if (patternInterface == PatternInterface.GridItem || patternInterface == PatternInterface.SelectionItem)
			{
				if (this.OwningCalendar != null && this.OwningCalendar.MonthControl != null && this.OwningCalendarButton != null)
				{
					result = this;
				}
				else
				{
					result = base.GetPattern(patternInterface);
				}
			}
			else
			{
				result = base.GetPattern(patternInterface);
			}
			return result;
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x000224B6 File Offset: 0x000206B6
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Button;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x000224B9 File Offset: 0x000206B9
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x000224CB File Offset: 0x000206CB
		protected override string GetLocalizedControlTypeCore()
		{
			return SR.Get(SRID.CalendarAutomationPeer_CalendarButtonLocalizedControlType);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x000224D8 File Offset: 0x000206D8
		protected override string GetHelpTextCore()
		{
			DateTime? date = this.Date;
			if (date == null)
			{
				return base.GetHelpTextCore();
			}
			return DateTimeHelper.ToLongDateString(date, DateTimeHelper.GetCulture(this.OwningCalendarButton));
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x00022510 File Offset: 0x00020710
		protected override string GetNameCore()
		{
			DateTime? date = this.Date;
			if (date == null)
			{
				return base.GetNameCore();
			}
			if (this.OwningCalendar.DisplayMode == Microsoft.Windows.Controls.CalendarMode.Decade)
			{
				return DateTimeHelper.ToYearString(date, DateTimeHelper.GetCulture(this.OwningCalendarButton));
			}
			return DateTimeHelper.ToYearMonthPatternString(date, DateTimeHelper.GetCulture(this.OwningCalendarButton));
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x00022565 File Offset: 0x00020765
		int IGridItemProvider.Column
		{
			get
			{
				return (int)this.OwningCalendarButton.GetValue(Grid.ColumnProperty);
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x0002257C File Offset: 0x0002077C
		int IGridItemProvider.ColumnSpan
		{
			get
			{
				return (int)this.OwningCalendarButton.GetValue(Grid.ColumnSpanProperty);
			}
		}

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x00022593 File Offset: 0x00020793
		IRawElementProviderSimple IGridItemProvider.ContainingGrid
		{
			get
			{
				return this.OwningCalendarAutomationPeer;
			}
		}

		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x0002259B File Offset: 0x0002079B
		int IGridItemProvider.Row
		{
			get
			{
				return (int)this.OwningCalendarButton.GetValue(Grid.RowSpanProperty);
			}
		}

		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x000225B2 File Offset: 0x000207B2
		int IGridItemProvider.RowSpan
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x000225B5 File Offset: 0x000207B5
		bool ISelectionItemProvider.IsSelected
		{
			get
			{
				return this.OwningCalendarButton.IsFocused;
			}
		}

		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x000225C2 File Offset: 0x000207C2
		IRawElementProviderSimple ISelectionItemProvider.SelectionContainer
		{
			get
			{
				return this.OwningCalendarAutomationPeer;
			}
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x000225CA File Offset: 0x000207CA
		void ISelectionItemProvider.AddToSelection()
		{
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x000225CC File Offset: 0x000207CC
		void ISelectionItemProvider.RemoveFromSelection()
		{
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x000225CE File Offset: 0x000207CE
		void ISelectionItemProvider.Select()
		{
			if (this.OwningCalendarButton.IsEnabled)
			{
				this.OwningCalendarButton.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
				return;
			}
			throw new ElementNotEnabledException();
		}
	}
}

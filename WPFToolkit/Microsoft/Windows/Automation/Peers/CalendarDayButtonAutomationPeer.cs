using System;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x02000054 RID: 84
	public sealed class CalendarDayButtonAutomationPeer : ButtonAutomationPeer, ISelectionItemProvider, ITableItemProvider, IGridItemProvider
	{
		// Token: 0x060006B8 RID: 1720 RVA: 0x0001BAB3 File Offset: 0x00019CB3
		public CalendarDayButtonAutomationPeer(CalendarDayButton owner) : base(owner)
		{
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060006B9 RID: 1721 RVA: 0x0001BABC File Offset: 0x00019CBC
		private Microsoft.Windows.Controls.Calendar OwningCalendar
		{
			get
			{
				return this.OwningCalendarDayButton.Owner;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060006BA RID: 1722 RVA: 0x0001BACC File Offset: 0x00019CCC
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

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060006BB RID: 1723 RVA: 0x0001BAF9 File Offset: 0x00019CF9
		private CalendarDayButton OwningCalendarDayButton
		{
			get
			{
				return base.Owner as CalendarDayButton;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x0001BB08 File Offset: 0x00019D08
		private DateTime? Date
		{
			get
			{
				if (this.OwningCalendarDayButton != null && this.OwningCalendarDayButton.DataContext is DateTime)
				{
					return (DateTime?)this.OwningCalendarDayButton.DataContext;
				}
				return null;
			}
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0001BB4C File Offset: 0x00019D4C
		public override object GetPattern(PatternInterface patternInterface)
		{
			object result;
			if (patternInterface == PatternInterface.GridItem || patternInterface == PatternInterface.SelectionItem || patternInterface == PatternInterface.TableItem)
			{
				if (this.OwningCalendar != null && this.OwningCalendarDayButton != null)
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

		// Token: 0x060006BE RID: 1726 RVA: 0x0001BB92 File Offset: 0x00019D92
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Button;
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x0001BB95 File Offset: 0x00019D95
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0001BBA8 File Offset: 0x00019DA8
		protected override string GetHelpTextCore()
		{
			if (this.Date == null)
			{
				return base.GetHelpTextCore();
			}
			string text = DateTimeHelper.ToLongDateString(this.Date, DateTimeHelper.GetCulture(this.OwningCalendarDayButton));
			if (this.OwningCalendarDayButton.IsBlackedOut)
			{
				return string.Format(DateTimeHelper.GetCurrentDateFormat(), SR.Get(SRID.CalendarAutomationPeer_BlackoutDayHelpText), new object[]
				{
					text
				});
			}
			return text;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0001BC12 File Offset: 0x00019E12
		protected override string GetLocalizedControlTypeCore()
		{
			return SR.Get(SRID.CalendarAutomationPeer_DayButtonLocalizedControlType);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x0001BC20 File Offset: 0x00019E20
		protected override string GetNameCore()
		{
			if (this.Date == null)
			{
				return base.GetNameCore();
			}
			return DateTimeHelper.ToLongDateString(this.Date, DateTimeHelper.GetCulture(this.OwningCalendarDayButton));
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x0001BC5A File Offset: 0x00019E5A
		int IGridItemProvider.Column
		{
			get
			{
				return (int)this.OwningCalendarDayButton.GetValue(Grid.ColumnProperty);
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x0001BC71 File Offset: 0x00019E71
		int IGridItemProvider.ColumnSpan
		{
			get
			{
				return (int)this.OwningCalendarDayButton.GetValue(Grid.ColumnSpanProperty);
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x0001BC88 File Offset: 0x00019E88
		IRawElementProviderSimple IGridItemProvider.ContainingGrid
		{
			get
			{
				return this.OwningCalendarAutomationPeer;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060006C6 RID: 1734 RVA: 0x0001BC90 File Offset: 0x00019E90
		int IGridItemProvider.Row
		{
			get
			{
				return (int)this.OwningCalendarDayButton.GetValue(Grid.RowProperty) - 1;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060006C7 RID: 1735 RVA: 0x0001BCA9 File Offset: 0x00019EA9
		int IGridItemProvider.RowSpan
		{
			get
			{
				return (int)this.OwningCalendarDayButton.GetValue(Grid.RowSpanProperty);
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060006C8 RID: 1736 RVA: 0x0001BCC0 File Offset: 0x00019EC0
		bool ISelectionItemProvider.IsSelected
		{
			get
			{
				return this.OwningCalendarDayButton.IsSelected;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x060006C9 RID: 1737 RVA: 0x0001BCCD File Offset: 0x00019ECD
		IRawElementProviderSimple ISelectionItemProvider.SelectionContainer
		{
			get
			{
				return this.OwningCalendarAutomationPeer;
			}
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x0001BCD8 File Offset: 0x00019ED8
		void ISelectionItemProvider.AddToSelection()
		{
			if (((ISelectionItemProvider)this).IsSelected)
			{
				return;
			}
			if (this.EnsureSelection() && this.OwningCalendarDayButton.DataContext is DateTime)
			{
				if (this.OwningCalendar.SelectionMode == Microsoft.Windows.Controls.CalendarSelectionMode.SingleDate)
				{
					this.OwningCalendar.SelectedDate = new DateTime?((DateTime)this.OwningCalendarDayButton.DataContext);
					return;
				}
				this.OwningCalendar.SelectedDates.Add((DateTime)this.OwningCalendarDayButton.DataContext);
			}
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0001BD56 File Offset: 0x00019F56
		void ISelectionItemProvider.RemoveFromSelection()
		{
			if (!((ISelectionItemProvider)this).IsSelected)
			{
				return;
			}
			if (this.OwningCalendarDayButton.DataContext is DateTime)
			{
				this.OwningCalendar.SelectedDates.Remove((DateTime)this.OwningCalendarDayButton.DataContext);
			}
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0001BD94 File Offset: 0x00019F94
		void ISelectionItemProvider.Select()
		{
			if (this.EnsureSelection())
			{
				this.OwningCalendar.SelectedDates.Clear();
				if (this.OwningCalendarDayButton.DataContext is DateTime)
				{
					this.OwningCalendar.SelectedDates.Add((DateTime)this.OwningCalendarDayButton.DataContext);
				}
			}
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x0001BDEC File Offset: 0x00019FEC
		IRawElementProviderSimple[] ITableItemProvider.GetColumnHeaderItems()
		{
			if (this.OwningCalendar != null && this.OwningCalendarAutomationPeer != null)
			{
				IRawElementProviderSimple[] columnHeaders = ((ITableProvider)UIElementAutomationPeer.CreatePeerForElement(this.OwningCalendar)).GetColumnHeaders();
				if (columnHeaders != null)
				{
					int column = ((IGridItemProvider)this).Column;
					return new IRawElementProviderSimple[]
					{
						columnHeaders[column]
					};
				}
			}
			return null;
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x0001BE39 File Offset: 0x0001A039
		IRawElementProviderSimple[] ITableItemProvider.GetRowHeaderItems()
		{
			return null;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0001BE3C File Offset: 0x0001A03C
		private bool EnsureSelection()
		{
			if (!this.OwningCalendarDayButton.IsEnabled)
			{
				throw new ElementNotEnabledException();
			}
			return !this.OwningCalendarDayButton.IsBlackedOut && this.OwningCalendar.SelectionMode != Microsoft.Windows.Controls.CalendarSelectionMode.None;
		}
	}
}

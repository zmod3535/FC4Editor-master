using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x02000043 RID: 67
	public sealed class CalendarAutomationPeer : FrameworkElementAutomationPeer, IMultipleViewProvider, ISelectionProvider, ITableProvider, IGridProvider
	{
		// Token: 0x060004ED RID: 1261 RVA: 0x0001374E File Offset: 0x0001194E
		public CalendarAutomationPeer(Microsoft.Windows.Controls.Calendar owner) : base(owner)
		{
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060004EE RID: 1262 RVA: 0x00013757 File Offset: 0x00011957
		private Microsoft.Windows.Controls.Calendar OwningCalendar
		{
			get
			{
				return base.Owner as Microsoft.Windows.Controls.Calendar;
			}
		}

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00013764 File Offset: 0x00011964
		private Grid OwningGrid
		{
			get
			{
				if (this.OwningCalendar == null || this.OwningCalendar.MonthControl == null)
				{
					return null;
				}
				if (this.OwningCalendar.DisplayMode == Microsoft.Windows.Controls.CalendarMode.Month)
				{
					return this.OwningCalendar.MonthControl.MonthView;
				}
				return this.OwningCalendar.MonthControl.YearView;
			}
		}

		// Token: 0x060004F0 RID: 1264 RVA: 0x000137B8 File Offset: 0x000119B8
		public override object GetPattern(PatternInterface patternInterface)
		{
			if (patternInterface != PatternInterface.Selection)
			{
				switch (patternInterface)
				{
				case PatternInterface.Grid:
				case PatternInterface.MultipleView:
					break;
				case PatternInterface.GridItem:
					goto IL_29;
				default:
					if (patternInterface != PatternInterface.Table)
					{
						goto IL_29;
					}
					break;
				}
			}
			if (this.OwningGrid != null)
			{
				return this;
			}
			IL_29:
			return base.GetPattern(patternInterface);
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x000137F5 File Offset: 0x000119F5
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Calendar;
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x000137F8 File Offset: 0x000119F8
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0001380C File Offset: 0x00011A0C
		internal void RaiseSelectionEvents(SelectionChangedEventArgs e)
		{
			int count = this.OwningCalendar.SelectedDates.Count;
			int count2 = e.AddedItems.Count;
			if (AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementSelected) && count == 1 && count2 == 1)
			{
				CalendarDayButton calendarDayButton = this.OwningCalendar.FindDayButtonFromDay((DateTime)e.AddedItems[0]);
				if (calendarDayButton != null)
				{
					AutomationPeer automationPeer = UIElementAutomationPeer.FromElement(calendarDayButton);
					if (automationPeer != null)
					{
						automationPeer.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementSelected);
						return;
					}
				}
			}
			else
			{
				if (AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementAddedToSelection))
				{
					foreach (object obj in e.AddedItems)
					{
						DateTime day = (DateTime)obj;
						CalendarDayButton calendarDayButton2 = this.OwningCalendar.FindDayButtonFromDay(day);
						if (calendarDayButton2 != null)
						{
							AutomationPeer automationPeer2 = UIElementAutomationPeer.FromElement(calendarDayButton2);
							if (automationPeer2 != null)
							{
								automationPeer2.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementAddedToSelection);
							}
						}
					}
				}
				if (AutomationPeer.ListenerExists(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection))
				{
					foreach (object obj2 in e.RemovedItems)
					{
						DateTime day2 = (DateTime)obj2;
						CalendarDayButton calendarDayButton3 = this.OwningCalendar.FindDayButtonFromDay(day2);
						if (calendarDayButton3 != null)
						{
							AutomationPeer automationPeer3 = UIElementAutomationPeer.FromElement(calendarDayButton3);
							if (automationPeer3 != null)
							{
								automationPeer3.RaiseAutomationEvent(AutomationEvents.SelectionItemPatternOnElementRemovedFromSelection);
							}
						}
					}
				}
			}
		}

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060004F4 RID: 1268 RVA: 0x00013974 File Offset: 0x00011B74
		int IGridProvider.ColumnCount
		{
			get
			{
				if (this.OwningGrid != null)
				{
					return this.OwningGrid.ColumnDefinitions.Count;
				}
				return 0;
			}
		}

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x00013990 File Offset: 0x00011B90
		int IGridProvider.RowCount
		{
			get
			{
				if (this.OwningGrid == null)
				{
					return 0;
				}
				if (this.OwningCalendar.DisplayMode == Microsoft.Windows.Controls.CalendarMode.Month)
				{
					return Math.Max(0, this.OwningGrid.RowDefinitions.Count - 1);
				}
				return this.OwningGrid.RowDefinitions.Count;
			}
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x000139E0 File Offset: 0x00011BE0
		IRawElementProviderSimple IGridProvider.GetItem(int row, int column)
		{
			if (this.OwningCalendar.DisplayMode == Microsoft.Windows.Controls.CalendarMode.Month)
			{
				row++;
			}
			if (this.OwningGrid != null && row >= 0 && row < this.OwningGrid.RowDefinitions.Count && column >= 0 && column < this.OwningGrid.ColumnDefinitions.Count)
			{
				foreach (object obj in this.OwningGrid.Children)
				{
					UIElement uielement = (UIElement)obj;
					int num = (int)uielement.GetValue(Grid.RowProperty);
					int num2 = (int)uielement.GetValue(Grid.ColumnProperty);
					if (num == row && num2 == column)
					{
						AutomationPeer automationPeer = UIElementAutomationPeer.CreatePeerForElement(uielement);
						if (automationPeer != null)
						{
							return base.ProviderFromPeer(automationPeer);
						}
					}
				}
			}
			return null;
		}

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x00013AD8 File Offset: 0x00011CD8
		int IMultipleViewProvider.CurrentView
		{
			get
			{
				return (int)this.OwningCalendar.DisplayMode;
			}
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00013AE8 File Offset: 0x00011CE8
		int[] IMultipleViewProvider.GetSupportedViews()
		{
			return new int[]
			{
				0,
				1,
				2
			};
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x00013B0C File Offset: 0x00011D0C
		string IMultipleViewProvider.GetViewName(int viewId)
		{
			switch (viewId)
			{
			case 0:
				return SR.Get(SRID.CalendarAutomationPeer_MonthMode);
			case 1:
				return SR.Get(SRID.CalendarAutomationPeer_YearMode);
			case 2:
				return SR.Get(SRID.CalendarAutomationPeer_DecadeMode);
			default:
				return string.Empty;
			}
		}

		// Token: 0x060004FA RID: 1274 RVA: 0x00013B55 File Offset: 0x00011D55
		void IMultipleViewProvider.SetCurrentView(int viewId)
		{
			this.OwningCalendar.DisplayMode = (Microsoft.Windows.Controls.CalendarMode)viewId;
		}

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x00013B63 File Offset: 0x00011D63
		bool ISelectionProvider.CanSelectMultiple
		{
			get
			{
				return this.OwningCalendar.SelectionMode == Microsoft.Windows.Controls.CalendarSelectionMode.SingleRange || this.OwningCalendar.SelectionMode == Microsoft.Windows.Controls.CalendarSelectionMode.MultipleRange;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x060004FC RID: 1276 RVA: 0x00013B83 File Offset: 0x00011D83
		bool ISelectionProvider.IsSelectionRequired
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x00013B88 File Offset: 0x00011D88
		IRawElementProviderSimple[] ISelectionProvider.GetSelection()
		{
			List<IRawElementProviderSimple> list = new List<IRawElementProviderSimple>();
			if (this.OwningGrid != null)
			{
				if (this.OwningCalendar.DisplayMode == Microsoft.Windows.Controls.CalendarMode.Month && this.OwningCalendar.SelectedDates != null && this.OwningCalendar.SelectedDates.Count != 0)
				{
					using (IEnumerator enumerator = this.OwningGrid.Children.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							UIElement uielement = (UIElement)obj;
							int num = (int)uielement.GetValue(Grid.RowProperty);
							if (num != 0)
							{
								CalendarDayButton calendarDayButton = uielement as CalendarDayButton;
								if (calendarDayButton != null && calendarDayButton.IsSelected)
								{
									AutomationPeer automationPeer = UIElementAutomationPeer.CreatePeerForElement(calendarDayButton);
									if (automationPeer != null)
									{
										list.Add(base.ProviderFromPeer(automationPeer));
									}
								}
							}
						}
						goto IL_13F;
					}
				}
				foreach (object obj2 in this.OwningGrid.Children)
				{
					UIElement uielement2 = (UIElement)obj2;
					CalendarButton calendarButton = uielement2 as CalendarButton;
					if (calendarButton != null && calendarButton.IsFocused)
					{
						AutomationPeer automationPeer2 = UIElementAutomationPeer.CreatePeerForElement(calendarButton);
						if (automationPeer2 != null)
						{
							list.Add(base.ProviderFromPeer(automationPeer2));
							break;
						}
						break;
					}
				}
				IL_13F:
				if (list.Count > 0)
				{
					return list.ToArray();
				}
			}
			return null;
		}

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x060004FE RID: 1278 RVA: 0x00013D04 File Offset: 0x00011F04
		RowOrColumnMajor ITableProvider.RowOrColumnMajor
		{
			get
			{
				return RowOrColumnMajor.RowMajor;
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x00013D08 File Offset: 0x00011F08
		IRawElementProviderSimple[] ITableProvider.GetColumnHeaders()
		{
			if (this.OwningCalendar.DisplayMode == Microsoft.Windows.Controls.CalendarMode.Month)
			{
				List<IRawElementProviderSimple> list = new List<IRawElementProviderSimple>();
				foreach (object obj in this.OwningGrid.Children)
				{
					UIElement uielement = (UIElement)obj;
					if ((int)uielement.GetValue(Grid.RowProperty) == 0)
					{
						AutomationPeer automationPeer = UIElementAutomationPeer.CreatePeerForElement(uielement);
						if (automationPeer != null)
						{
							list.Add(base.ProviderFromPeer(automationPeer));
						}
					}
				}
				if (list.Count > 0)
				{
					return list.ToArray();
				}
			}
			return null;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x00013DB8 File Offset: 0x00011FB8
		IRawElementProviderSimple[] ITableProvider.GetRowHeaders()
		{
			return null;
		}
	}
}

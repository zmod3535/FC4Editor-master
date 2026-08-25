using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using MS.Internal;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x02000040 RID: 64
	public sealed class DataGridRowAutomationPeer : FrameworkElementAutomationPeer
	{
		// Token: 0x060004CF RID: 1231 RVA: 0x000130B6 File Offset: 0x000112B6
		public DataGridRowAutomationPeer(DataGridRow owner) : base(owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			this.UpdateEventSource();
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x000130D3 File Offset: 0x000112D3
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.DataItem;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x000130D7 File Offset: 0x000112D7
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x000130EC File Offset: 0x000112EC
		protected override List<AutomationPeer> GetChildrenCore()
		{
			List<AutomationPeer> list = new List<AutomationPeer>(3);
			AutomationPeer rowHeaderAutomationPeer = this.RowHeaderAutomationPeer;
			if (rowHeaderAutomationPeer != null)
			{
				list.Add(rowHeaderAutomationPeer);
			}
			DataGridItemAutomationPeer dataGridItemAutomationPeer = base.EventsSource as DataGridItemAutomationPeer;
			if (dataGridItemAutomationPeer != null)
			{
				list.AddRange(dataGridItemAutomationPeer.GetCellItemPeers());
			}
			AutomationPeer detailsPresenterAutomationPeer = this.DetailsPresenterAutomationPeer;
			if (detailsPresenterAutomationPeer != null)
			{
				list.Add(detailsPresenterAutomationPeer);
			}
			return list;
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x00013140 File Offset: 0x00011340
		protected override bool IsOffscreenCore()
		{
			if (!base.Owner.IsVisible)
			{
				return true;
			}
			Rect rect = DataGridAutomationPeer.CalculateVisibleBoundingRect(base.Owner);
			return DoubleUtil.AreClose(rect, Rect.Empty) || DoubleUtil.AreClose(rect.Height, 0.0) || DoubleUtil.AreClose(rect.Width, 0.0);
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x000131A4 File Offset: 0x000113A4
		internal AutomationPeer RowHeaderAutomationPeer
		{
			get
			{
				DataGridRowHeader rowHeader = this.OwningDataGridRow.RowHeader;
				if (rowHeader != null)
				{
					return UIElementAutomationPeer.CreatePeerForElement(rowHeader);
				}
				return null;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x000131C8 File Offset: 0x000113C8
		private AutomationPeer DetailsPresenterAutomationPeer
		{
			get
			{
				DataGridDetailsPresenter detailsPresenter = this.OwningDataGridRow.DetailsPresenter;
				if (detailsPresenter != null)
				{
					return UIElementAutomationPeer.CreatePeerForElement(detailsPresenter);
				}
				return null;
			}
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000131EC File Offset: 0x000113EC
		internal void UpdateEventSource()
		{
			DataGrid dataGridOwner = this.OwningDataGridRow.DataGridOwner;
			if (dataGridOwner != null)
			{
				DataGridAutomationPeer dataGridAutomationPeer = UIElementAutomationPeer.CreatePeerForElement(dataGridOwner) as DataGridAutomationPeer;
				if (dataGridAutomationPeer != null)
				{
					AutomationPeer orCreateItemPeer = dataGridAutomationPeer.GetOrCreateItemPeer(this.OwningDataGridRow.Item);
					if (orCreateItemPeer != null)
					{
						base.EventsSource = orCreateItemPeer;
					}
				}
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00013233 File Offset: 0x00011433
		private DataGridRow OwningDataGridRow
		{
			get
			{
				return (DataGridRow)base.Owner;
			}
		}
	}
}

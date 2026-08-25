using System;
using System.Windows;
using System.Windows.Automation.Peers;
using Microsoft.Windows.Controls;
using MS.Internal;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x0200003C RID: 60
	public sealed class DataGridCellAutomationPeer : FrameworkElementAutomationPeer
	{
		// Token: 0x060004C7 RID: 1223 RVA: 0x00012FAA File Offset: 0x000111AA
		public DataGridCellAutomationPeer(DataGridCell owner) : base(owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			this.UpdateEventSource();
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00012FC7 File Offset: 0x000111C7
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Custom;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00012FCB File Offset: 0x000111CB
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x00012FE0 File Offset: 0x000111E0
		protected override bool IsOffscreenCore()
		{
			if (!base.Owner.IsVisible)
			{
				return true;
			}
			Rect rect = DataGridAutomationPeer.CalculateVisibleBoundingRect(base.Owner);
			return DoubleUtil.AreClose(rect, Rect.Empty) || DoubleUtil.AreClose(rect.Height, 0.0) || DoubleUtil.AreClose(rect.Width, 0.0);
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00013044 File Offset: 0x00011244
		private void UpdateEventSource()
		{
			DataGridCell dataGridCell = (DataGridCell)base.Owner;
			DataGrid dataGridOwner = dataGridCell.DataGridOwner;
			if (dataGridOwner != null)
			{
				DataGridAutomationPeer dataGridAutomationPeer = UIElementAutomationPeer.CreatePeerForElement(dataGridOwner) as DataGridAutomationPeer;
				if (dataGridAutomationPeer != null)
				{
					DataGridItemAutomationPeer orCreateItemPeer = dataGridAutomationPeer.GetOrCreateItemPeer(dataGridCell.DataContext);
					if (orCreateItemPeer != null)
					{
						DataGridCellItemAutomationPeer orCreateCellItemPeer = orCreateItemPeer.GetOrCreateCellItemPeer(dataGridCell.Column);
						base.EventsSource = orCreateCellItemPeer;
					}
				}
			}
		}
	}
}

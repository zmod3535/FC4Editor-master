using System;
using System.Windows;
using System.Windows.Automation.Peers;
using Microsoft.Windows.Controls.Primitives;
using MS.Internal;

namespace Microsoft.Windows.Automation.Peers
{
	// Token: 0x02000033 RID: 51
	public sealed class DataGridRowHeaderAutomationPeer : ButtonBaseAutomationPeer
	{
		// Token: 0x060002BC RID: 700 RVA: 0x0000A846 File Offset: 0x00008A46
		public DataGridRowHeaderAutomationPeer(DataGridRowHeader owner) : base(owner)
		{
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000A84F File Offset: 0x00008A4F
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.HeaderItem;
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000A853 File Offset: 0x00008A53
		protected override string GetClassNameCore()
		{
			return base.Owner.GetType().Name;
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000A865 File Offset: 0x00008A65
		protected override bool IsContentElementCore()
		{
			return false;
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000A868 File Offset: 0x00008A68
		protected override bool IsOffscreenCore()
		{
			if (!base.Owner.IsVisible)
			{
				return true;
			}
			Rect rect = DataGridAutomationPeer.CalculateVisibleBoundingRect(base.Owner);
			return DoubleUtil.AreClose(rect, Rect.Empty) || DoubleUtil.AreClose(rect.Height, 0.0) || DoubleUtil.AreClose(rect.Width, 0.0);
		}
	}
}

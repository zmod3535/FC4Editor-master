using System;
using System.Collections.Generic;
using System.Windows.Automation.Peers;

namespace Divelements.SandDock.Automation
{
	// Token: 0x02000053 RID: 83
	internal class DockSiteAutomationPeer : FrameworkElementAutomationPeer
	{
		// Token: 0x0600040C RID: 1036 RVA: 0x00042A78 File Offset: 0x00040E78
		internal DockSiteAutomationPeer(DockSite dockSite) : base(dockSite)
		{
			this.dockSite = dockSite;
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00042A88 File Offset: 0x00040E88
		protected override string GetClassNameCore()
		{
			return "DockSite";
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x00042A90 File Offset: 0x00040E90
		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Group;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x00042A94 File Offset: 0x00040E94
		protected override List<AutomationPeer> GetChildrenCore()
		{
			DockableWindow[] allWindows = this.dockSite.GetAllWindows();
			List<AutomationPeer> list = new List<AutomationPeer>(allWindows.Length);
			for (int i = 0; i < allWindows.Length; i++)
			{
				AutomationPeer automationPeer = UIElementAutomationPeer.FromElement(allWindows[i]);
				if (automationPeer == null)
				{
					automationPeer = UIElementAutomationPeer.CreatePeerForElement(allWindows[i]);
				}
				list.Add(automationPeer);
			}
			return list;
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x00042AE4 File Offset: 0x00040EE4
		protected override void SetFocusCore()
		{
			this.dockSite.ActivatePrimaryDocument();
		}

		// Token: 0x040001BD RID: 445
		private DockSite dockSite;
	}
}

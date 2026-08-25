using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace TD.SandBar.Design
{
	// Token: 0x0200000F RID: 15
	internal class ControlContainerItemDesigner : ToolBarItemBaseDesigner
	{
		// Token: 0x06000132 RID: 306 RVA: 0x00006394 File Offset: 0x00005394
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			string systemVersion = RuntimeEnvironment.GetSystemVersion();
			if (systemVersion == "v1.0.3705" || systemVersion == "v2.0.50727")
			{
				((ControlContainerItem)component).ContainedControl.Enabled = false;
			}
		}
	}
}

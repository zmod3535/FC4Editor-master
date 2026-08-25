using System;
using Ubisoft.ApplicationModel.ContextCommands;

namespace IGE.Tools
{
	// Token: 0x020000C0 RID: 192
	internal class ToolAction : ToolBase
	{
		// Token: 0x06000751 RID: 1873 RVA: 0x0001AA41 File Offset: 0x00018C41
		public ToolAction(string displayName, string imageFilename) : base(displayName, imageFilename)
		{
			this.ButtonCommand = new SimpleCommand();
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x0001AA56 File Offset: 0x00018C56
		// (set) Token: 0x06000753 RID: 1875 RVA: 0x0001AA5E File Offset: 0x00018C5E
		public SimpleCommand ButtonCommand { get; set; }

		// Token: 0x06000754 RID: 1876 RVA: 0x0001AA67 File Offset: 0x00018C67
		public void Fire()
		{
			if (this.ButtonCommand.CanExecute(null))
			{
				this.ButtonCommand.Execute(null);
			}
		}
	}
}

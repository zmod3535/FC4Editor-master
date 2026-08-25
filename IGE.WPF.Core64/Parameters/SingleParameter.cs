using System;

namespace IGE.Parameters
{
	// Token: 0x02000003 RID: 3
	internal abstract class SingleParameter : Parameter
	{
		// Token: 0x06000006 RID: 6 RVA: 0x000020AB File Offset: 0x000002AB
		public SingleParameter(string displayName)
		{
			this.DisplayName = displayName;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020BA File Offset: 0x000002BA
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020C2 File Offset: 0x000002C2
		public string ToolTip
		{
			get
			{
				return this._tooltip;
			}
			set
			{
				if (this._tooltip == value)
				{
					return;
				}
				this._tooltip = value;
				base.RaisePropertyChanged("ToolTip");
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020E5 File Offset: 0x000002E5
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000020ED File Offset: 0x000002ED
		public string DisplayName
		{
			get
			{
				return this._displayName;
			}
			set
			{
				if (this._displayName == value)
				{
					return;
				}
				this._displayName = value;
				base.RaisePropertyChanged("DisplayName");
			}
		}

		// Token: 0x04000003 RID: 3
		private string _tooltip;

		// Token: 0x04000004 RID: 4
		private string _displayName;
	}
}

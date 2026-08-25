using System;
using System.Collections.Generic;
using System.ComponentModel;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000066 RID: 102
	internal class ToolObjectModeToggle : Tool
	{
		// Token: 0x0600046B RID: 1131 RVA: 0x0001196B File Offset: 0x0000FB6B
		public ToolObjectModeToggle(string title, string icon, ToolObject tool, ToolObject.Mode mode, ToolObjectModeToggle.ActivateDelegate activate) : base(title, icon)
		{
			this._toolObject = tool;
			this._toolObjectMode = mode;
			this._activate = activate;
			this._toolObjectMode.PropertyChanged += this.toolObjectMode_PropertyChanged;
		}

		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x000119A3 File Offset: 0x0000FBA3
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x000119AB File Offset: 0x0000FBAB
		public override bool IsActive
		{
			get
			{
				return this._isActive;
			}
			set
			{
				if (this._isActive == value)
				{
					return;
				}
				this._isActive = value;
				if (this._isActive && this._activate != null)
				{
					this._activate();
				}
				base.RaisePropertyChanged("IsActive");
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x000119E4 File Offset: 0x0000FBE4
		private void toolObjectMode_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsActive")
			{
				this.IsActive = this._toolObjectMode.IsActive;
			}
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x00011A09 File Offset: 0x0000FC09
		public override string GetContextHelp()
		{
			return this._toolObject.GetContextHelp();
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x00011A16 File Offset: 0x0000FC16
		protected override IEnumerable<Parameter> GetParameters()
		{
			return this._toolObject.GetParametersInternal();
		}

		// Token: 0x040001F6 RID: 502
		private ToolObjectModeToggle.ActivateDelegate _activate;

		// Token: 0x040001F7 RID: 503
		private ToolObject _toolObject;

		// Token: 0x040001F8 RID: 504
		private ToolObject.Mode _toolObjectMode;

		// Token: 0x040001F9 RID: 505
		private bool _isActive;

		// Token: 0x02000067 RID: 103
		// (Invoke) Token: 0x06000472 RID: 1138
		public delegate void ActivateDelegate();
	}
}

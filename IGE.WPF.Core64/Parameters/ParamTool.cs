using System;
using IGE.Tools;

namespace IGE.Parameters
{
	// Token: 0x020000A9 RID: 169
	internal class ParamTool : Parameter
	{
		// Token: 0x060006DE RID: 1758 RVA: 0x000191FD File Offset: 0x000173FD
		public ParamTool(ToolObject.Mode tool)
		{
			this.Tool = tool;
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x0001920C File Offset: 0x0001740C
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x00019214 File Offset: 0x00017414
		public ToolObject.Mode Tool
		{
			get
			{
				return this._tool;
			}
			set
			{
				if (this._tool == value)
				{
					return;
				}
				this._tool = value;
				base.RaisePropertyChanged("Tool");
			}
		}

		// Token: 0x040002B9 RID: 697
		private ToolObject.Mode _tool;
	}
}

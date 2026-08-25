using System;
using IGE.Nomad;
using Ubisoft;

namespace IGE.ViewModels
{
	// Token: 0x02000074 RID: 116
	internal class ObjectPropertiesViewModel : ViewModel
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x000126AC File Offset: 0x000108AC
		internal ObjectPropertiesViewModel(EditorObject obj)
		{
			this.selection = obj;
		}

		// Token: 0x04000211 RID: 529
		protected EditorObject selection;
	}
}

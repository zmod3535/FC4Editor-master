using System;
using System.Windows.Input;
using System.Windows.Media;
using IGE.Nomad;
using Ubisoft;

namespace IGE.Parameters
{
	// Token: 0x020000C5 RID: 197
	internal class EditorObjectViewModel : ViewModel
	{
		// Token: 0x06000768 RID: 1896 RVA: 0x0001ACD7 File Offset: 0x00018ED7
		public EditorObjectViewModel(EditorObject model)
		{
			this._model = model;
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x0001ACE6 File Offset: 0x00018EE6
		public EditorObject Model
		{
			get
			{
				return this._model;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x0600076A RID: 1898 RVA: 0x0001ACEE File Offset: 0x00018EEE
		public ImageSource Image
		{
			get
			{
				return this._model.Entry.Icon;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x0001AD00 File Offset: 0x00018F00
		public string DisplayName
		{
			get
			{
				return this._model.Entry.DisplayName;
			}
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x0600076C RID: 1900 RVA: 0x0001AD12 File Offset: 0x00018F12
		// (set) Token: 0x0600076D RID: 1901 RVA: 0x0001AD1A File Offset: 0x00018F1A
		public ICommand OnDoubleClick { get; set; }

		// Token: 0x04000300 RID: 768
		private EditorObject _model;
	}
}

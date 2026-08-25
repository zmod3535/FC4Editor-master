using System;
using System.IO;
using System.Windows.Media.Imaging;
using IGE.Nomad;
using IGE.Views;
using Ubisoft.ApplicationModel.ContextCommands;

namespace IGE.Parameters
{
	// Token: 0x02000073 RID: 115
	internal class ParamWaterMaterial : SingleParameter
	{
		// Token: 0x060004AA RID: 1194 RVA: 0x00012524 File Offset: 0x00010724
		public ParamWaterMaterial() : base(null)
		{
			SimpleCommand simpleCommand = new SimpleCommand();
			simpleCommand.ExecuteDelegate = delegate(object o)
			{
				this.RaiseAssign();
			};
			this.CommandAssign = simpleCommand;
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0001255E File Offset: 0x0001075E
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x00012566 File Offset: 0x00010766
		public WaterInventory.Entry Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
				base.RaisePropertyChanged("Value");
				base.RaisePropertyChanged("WaterMaterial");
				this.UpdateImage();
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060004AD RID: 1197 RVA: 0x0001258B File Offset: 0x0001078B
		public string WaterMaterial
		{
			get
			{
				if (!(this.Value == null))
				{
					return this.Value.DisplayName;
				}
				return Localizer.Localize("PARAM_OBJECT_BROWSER_NONE", null);
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x000125B2 File Offset: 0x000107B2
		// (set) Token: 0x060004AF RID: 1199 RVA: 0x000125BA File Offset: 0x000107BA
		public SimpleCommand CommandAssign { get; set; }

		// Token: 0x060004B0 RID: 1200 RVA: 0x000125C4 File Offset: 0x000107C4
		private void RaiseAssign()
		{
			PromptInventoryListView promptInventoryListView = new PromptInventoryListView(WaterInventory.Instance.Root, false, "")
			{
				Owner = Program.MainWin
			};
			if (promptInventoryListView.ShowDialog() == true)
			{
				this.Value = (promptInventoryListView.Result as WaterInventory.Entry);
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060004B1 RID: 1201 RVA: 0x00012621 File Offset: 0x00010821
		// (set) Token: 0x060004B2 RID: 1202 RVA: 0x00012629 File Offset: 0x00010829
		public BitmapFrame Bitmap
		{
			get
			{
				return this._bitmap;
			}
			set
			{
				this._bitmap = value;
				base.RaisePropertyChanged("Bitmap");
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00012640 File Offset: 0x00010840
		private void UpdateImage()
		{
			if (this.Value == null || !this.Value.IsValid)
			{
				this.Bitmap = null;
				return;
			}
			using (MemoryStream thumbnailData = this.Value.GetThumbnailData())
			{
				this.Bitmap = ((thumbnailData == null) ? null : BitmapFrame.Create(thumbnailData, BitmapCreateOptions.None, BitmapCacheOption.OnLoad));
			}
		}

		// Token: 0x0400020E RID: 526
		private WaterInventory.Entry _value;

		// Token: 0x0400020F RID: 527
		private BitmapFrame _bitmap;
	}
}

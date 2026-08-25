using System;
using System.Windows;
using System.Windows.Media;
using IGE.Helpers;
using IGE.Nomad;
using Ubisoft;

namespace IGE.Parameters
{
	// Token: 0x02000026 RID: 38
	internal class InventoryEntryViewModel : ViewModel
	{
		// Token: 0x0600010E RID: 270 RVA: 0x0000381A File Offset: 0x00001A1A
		public InventoryEntryViewModel(Inventory.Entry model)
		{
			this.Model = model;
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00003829 File Offset: 0x00001A29
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00003831 File Offset: 0x00001A31
		public Inventory.Entry Model { get; private set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000111 RID: 273 RVA: 0x0000383A File Offset: 0x00001A3A
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00003866 File Offset: 0x00001A66
		public ImageSource Image
		{
			get
			{
				if (this._image == null)
				{
					this._image = this.Model.Icon;
					ThumbnailLoader.Instance.ResolveThumbnail(this);
				}
				return this._image;
			}
			set
			{
				this._image = value;
				base.RaisePropertyChanged("Image");
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000113 RID: 275 RVA: 0x0000387A File Offset: 0x00001A7A
		public string Text
		{
			get
			{
				return this.Model.DisplayName;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00003888 File Offset: 0x00001A88
		public string SizeText
		{
			get
			{
				if (this.Model.IsDirectory)
				{
					return null;
				}
				Vec3 size = ((ObjectInventory.Entry)this.Model).Size;
				return string.Concat(new string[]
				{
					size.X.ToString("F1"),
					" x ",
					size.Y.ToString("F1"),
					" x ",
					size.Z.ToString("F1"),
					" m"
				});
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00003916 File Offset: 0x00001B16
		public Visibility HeightVisible
		{
			get
			{
				if (this.Height != null)
				{
					return Visibility.Visible;
				}
				return Visibility.Hidden;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00003924 File Offset: 0x00001B24
		public string Height
		{
			get
			{
				if (this.Model.IsDirectory)
				{
					return null;
				}
				if (!(this.Model is ObjectInventory.Entry))
				{
					return null;
				}
				return ((ObjectInventory.Entry)this.Model).Size.Y.ToString("F1") + "m";
			}
		}

		// Token: 0x04000055 RID: 85
		private ImageSource _image;
	}
}

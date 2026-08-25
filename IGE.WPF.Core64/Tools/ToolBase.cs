using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using IGE.Helpers;
using Ubisoft;

namespace IGE.Tools
{
	// Token: 0x02000039 RID: 57
	internal abstract class ToolBase : ViewModel
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x000085ED File Offset: 0x000067ED
		protected ToolBase(string displayName, string imageFilename)
		{
			this.Enabled = true;
			this.DisplayName = displayName;
			this.ImageFilename = imageFilename;
			this.Shortcut = Key.None;
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x00008611 File Offset: 0x00006811
		// (set) Token: 0x060002BA RID: 698 RVA: 0x00008619 File Offset: 0x00006819
		public bool Enabled
		{
			get
			{
				return this._enabled;
			}
			set
			{
				if (this._enabled == value)
				{
					return;
				}
				this._enabled = value;
				base.RaisePropertyChanged("Enabled");
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00008637 File Offset: 0x00006837
		public void UpdateIcon(string imageFilename)
		{
			this.ImageFilename = imageFilename;
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002BC RID: 700 RVA: 0x00008640 File Offset: 0x00006840
		// (set) Token: 0x060002BD RID: 701 RVA: 0x00008648 File Offset: 0x00006848
		public string ImageFilename
		{
			get
			{
				return this._imageFilename;
			}
			private set
			{
				if (this._imageFilename == value)
				{
					return;
				}
				this._imageFilename = value;
				this.ImageSource = value.GetImageSource();
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060002BE RID: 702 RVA: 0x0000866C File Offset: 0x0000686C
		// (set) Token: 0x060002BF RID: 703 RVA: 0x00008674 File Offset: 0x00006874
		public ImageSource ImageSource
		{
			get
			{
				return this._imageSource;
			}
			private set
			{
				this._imageSource = value;
				base.RaisePropertyChanged("ImageSource");
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060002C0 RID: 704 RVA: 0x00008688 File Offset: 0x00006888
		// (set) Token: 0x060002C1 RID: 705 RVA: 0x00008690 File Offset: 0x00006890
		public string DisplayName
		{
			get
			{
				return this._displayName;
			}
			private set
			{
				if (this._displayName == value)
				{
					return;
				}
				this._displayName = value;
				base.RaisePropertyChanged("DisplayName");
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060002C2 RID: 706 RVA: 0x000086B3 File Offset: 0x000068B3
		// (set) Token: 0x060002C3 RID: 707 RVA: 0x000086BB File Offset: 0x000068BB
		public Visibility HeaderVisible
		{
			get
			{
				return this._headerVisible;
			}
			set
			{
				if (this._headerVisible == value)
				{
					return;
				}
				this._headerVisible = value;
				base.RaisePropertyChanged("HeaderVisible");
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060002C4 RID: 708 RVA: 0x000086D9 File Offset: 0x000068D9
		public string ToolTip
		{
			get
			{
				if (this.Shortcut != Key.None)
				{
					return this.DisplayName + " (" + this.Shortcut.ToTooltipString() + ")";
				}
				return this.DisplayName;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060002C5 RID: 709 RVA: 0x0000870A File Offset: 0x0000690A
		// (set) Token: 0x060002C6 RID: 710 RVA: 0x00008712 File Offset: 0x00006912
		public Key Shortcut { get; set; }

		// Token: 0x04000112 RID: 274
		private bool _enabled;

		// Token: 0x04000113 RID: 275
		private string _imageFilename;

		// Token: 0x04000114 RID: 276
		private ImageSource _imageSource;

		// Token: 0x04000115 RID: 277
		private string _displayName;

		// Token: 0x04000116 RID: 278
		private Visibility _headerVisible;
	}
}

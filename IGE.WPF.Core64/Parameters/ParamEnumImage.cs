using System;
using System.Windows.Media;

namespace IGE.Parameters
{
	// Token: 0x0200038C RID: 908
	internal abstract class ParamEnumImage : ParamEnumBase.Entry
	{
		// Token: 0x0600147C RID: 5244 RVA: 0x0002BA05 File Offset: 0x00029C05
		protected ParamEnumImage(string display, ImageSource image, object value) : base(display, value)
		{
			this.Image = image;
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x0600147D RID: 5245 RVA: 0x0002BA16 File Offset: 0x00029C16
		// (set) Token: 0x0600147E RID: 5246 RVA: 0x0002BA1E File Offset: 0x00029C1E
		public ImageSource Image
		{
			get
			{
				return this._image;
			}
			set
			{
				this._image = value;
				base.RaisePropertyChanged("Image");
			}
		}

		// Token: 0x04000785 RID: 1925
		private ImageSource _image;
	}
}

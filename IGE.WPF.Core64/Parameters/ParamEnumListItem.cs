using System;
using System.Windows.Media;
using IGE.Helpers;

namespace IGE.Parameters
{
	// Token: 0x02000391 RID: 913
	internal class ParamEnumListItem : ParamEnumImage
	{
		// Token: 0x06001489 RID: 5257 RVA: 0x0002BAC4 File Offset: 0x00029CC4
		public ParamEnumListItem(string display, ImageSource image, object value) : base(display, image, value)
		{
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x0002BACF File Offset: 0x00029CCF
		public ParamEnumListItem(string display, string image, object value) : this(display, image.GetImageSource(), value)
		{
		}
	}
}

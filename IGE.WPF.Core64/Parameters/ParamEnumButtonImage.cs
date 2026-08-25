using System;
using System.Windows.Media;
using IGE.Helpers;
using IGE.Tools;

namespace IGE.Parameters
{
	// Token: 0x0200038F RID: 911
	internal class ParamEnumButtonImage : ParamEnumImage
	{
		// Token: 0x06001483 RID: 5251 RVA: 0x0002BA64 File Offset: 0x00029C64
		public ParamEnumButtonImage(string display, ImageSource image, object value) : base(display, image, value)
		{
		}

		// Token: 0x06001484 RID: 5252 RVA: 0x0002BA6F File Offset: 0x00029C6F
		public ParamEnumButtonImage(string display, string image, object value) : base(display, image.GetImageSource(), value)
		{
		}

		// Token: 0x06001485 RID: 5253 RVA: 0x0002BA7F File Offset: 0x00029C7F
		public ParamEnumButtonImage(Tool tool) : base(tool.DisplayName, tool.ImageSource, tool)
		{
		}
	}
}

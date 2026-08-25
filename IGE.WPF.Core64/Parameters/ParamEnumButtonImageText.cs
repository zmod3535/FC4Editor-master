using System;
using System.Windows.Media;
using IGE.Helpers;
using IGE.Tools;

namespace IGE.Parameters
{
	// Token: 0x02000390 RID: 912
	internal class ParamEnumButtonImageText : ParamEnumImage
	{
		// Token: 0x06001486 RID: 5254 RVA: 0x0002BA94 File Offset: 0x00029C94
		public ParamEnumButtonImageText(string display, ImageSource image, object value) : base(display, image, value)
		{
		}

		// Token: 0x06001487 RID: 5255 RVA: 0x0002BA9F File Offset: 0x00029C9F
		public ParamEnumButtonImageText(string display, string image, object value) : base(display, image.GetImageSource(), value)
		{
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x0002BAAF File Offset: 0x00029CAF
		public ParamEnumButtonImageText(Tool tool) : base(tool.DisplayName, tool.ImageSource, tool)
		{
		}
	}
}

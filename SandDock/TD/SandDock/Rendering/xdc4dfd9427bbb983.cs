using System;
using System.Collections;
using System.ComponentModel;

namespace TD.SandDock.Rendering
{
	// Token: 0x02000072 RID: 114
	internal class xdc4dfd9427bbb983 : x9c9262004128fe00
	{
		// Token: 0x06000697 RID: 1687 RVA: 0x00031130 File Offset: 0x00030130
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add("Everett");
			arrayList.Add("Office 2003");
			arrayList.Add("Whidbey");
			arrayList.Add("Milborne");
			do
			{
				arrayList.Add("Office 2007");
			}
			while (false);
			return new TypeConverter.StandardValuesCollection(arrayList);
		}
	}
}

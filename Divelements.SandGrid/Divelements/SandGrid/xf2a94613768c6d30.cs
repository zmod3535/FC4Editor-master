using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Divelements.SandGrid
{
	// Token: 0x02000087 RID: 135
	internal class xf2a94613768c6d30 : CollectionEditor
	{
		// Token: 0x0600065F RID: 1631 RVA: 0x00021A54 File Offset: 0x00020A54
		public xf2a94613768c6d30(Type type) : base(type)
		{
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00021A60 File Offset: 0x00020A60
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context.Instance is SandGridBase)
			{
				this.xf57b149cb3f9c03a = ((SandGridBase)context.Instance).PrimaryGrid;
			}
			else if (context.Instance is GridRow)
			{
				this.xf57b149cb3f9c03a = ((GridRow)context.Instance).Grid;
			}
			object result = base.EditValue(context, provider, value);
			this.xf57b149cb3f9c03a = null;
			return result;
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x00021AC8 File Offset: 0x00020AC8
		protected override object CreateInstance(Type itemType)
		{
			return this.xf57b149cb3f9c03a.NewRow();
		}

		// Token: 0x04000291 RID: 657
		private InnerGrid xf57b149cb3f9c03a;
	}
}

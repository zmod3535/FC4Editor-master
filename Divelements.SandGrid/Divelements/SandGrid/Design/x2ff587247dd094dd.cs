using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Divelements.SandGrid.Design
{
	// Token: 0x020000A6 RID: 166
	internal class x2ff587247dd094dd : ComponentDesigner
	{
		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x00025924 File Offset: 0x00024924
		private GridColumn GridColumn
		{
			get
			{
				return base.Component as GridColumn;
			}
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00025934 File Offset: 0x00024934
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			this.Visible = this.GridColumn.Visible;
			this.GridColumn.Visible = true;
		}

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x0002595C File Offset: 0x0002495C
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x00025974 File Offset: 0x00024974
		public bool Visible
		{
			get
			{
				return (bool)base.ShadowProperties["Visible"];
			}
			set
			{
				base.ShadowProperties["Visible"] = value;
			}
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0002598C File Offset: 0x0002498C
		protected override void PreFilterProperties(IDictionary properties)
		{
			base.PreFilterProperties(properties);
			properties["Visible"] = TypeDescriptor.CreateProperty(typeof(x2ff587247dd094dd), (PropertyDescriptor)properties["Visible"], new Attribute[0]);
		}
	}
}

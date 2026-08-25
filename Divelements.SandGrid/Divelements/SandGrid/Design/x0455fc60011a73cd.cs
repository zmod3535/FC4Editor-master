using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Divelements.SandGrid.Design
{
	// Token: 0x020000A8 RID: 168
	internal class x0455fc60011a73cd : xe72bc7a607f2a484, IServiceProvider
	{
		// Token: 0x060007BD RID: 1981 RVA: 0x00025ADC File Offset: 0x00024ADC
		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
		}

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x00025AE8 File Offset: 0x00024AE8
		public override DesignerVerbCollection Verbs
		{
			get
			{
				if (this.xf83003a7726fe74e == null)
				{
					DesignerVerb designerVerb = new DesignerVerb("Configure Grid", new EventHandler(this.x22043b3aa0c015bb));
					this.xf83003a7726fe74e = new DesignerVerbCollection(new DesignerVerb[]
					{
						designerVerb
					});
				}
				return this.xf83003a7726fe74e;
			}
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00025B34 File Offset: 0x00024B34
		private void x22043b3aa0c015bb(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			IUIService iuiservice = (IUIService)this.GetService(typeof(IUIService));
			using (xa99da2aabc9421ba xa99da2aabc9421ba = new xa99da2aabc9421ba(this.xbd3e0f549461827f.Site, this.xbd3e0f549461827f))
			{
				xa99da2aabc9421ba.ShowDialog(iuiservice.GetDialogOwnerWindow());
			}
		}

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060007C0 RID: 1984 RVA: 0x00025BA4 File Offset: 0x00024BA4
		private SandGrid xbd3e0f549461827f
		{
			get
			{
				return this.Control as SandGrid;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x060007C1 RID: 1985 RVA: 0x00025BB4 File Offset: 0x00024BB4
		public override ICollection AssociatedComponents
		{
			get
			{
				ArrayList arrayList = new ArrayList(base.AssociatedComponents);
				arrayList.AddRange(this.xbd3e0f549461827f.Columns);
				return arrayList;
			}
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00025BE0 File Offset: 0x00024BE0
		object IServiceProvider.xd41a0854cc1b2791(Type x96168bd31f23b747)
		{
			return this.GetService(x96168bd31f23b747);
		}

		// Token: 0x040002DC RID: 732
		private DesignerVerbCollection xf83003a7726fe74e;
	}
}

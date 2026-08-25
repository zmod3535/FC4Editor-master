using System;
using System.ComponentModel;
using System.Drawing;

namespace TD.SandBar
{
	// Token: 0x02000048 RID: 72
	public class StatusBarItem : LabelItem
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x00013058 File Offset: 0x00012058
		public StatusBarItem()
		{
			this.MinimumSize = 100;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x00013070 File Offset: 0x00012070
		internal override ToolbarItemBase.ItemPadding CreateDefaultPadding()
		{
			return new ToolbarItemBase.ItemPadding(this, 0, 1, 0, 1);
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0001307C File Offset: 0x0001207C
		protected internal override void ApplyLayout(Rectangle buttonBounds, Graphics graphics, bool vertical, bool rightToLeft)
		{
			base.ApplyLayout(buttonBounds, graphics, vertical, rightToLeft);
			Rectangle buttonInnerBounds = base.ButtonInnerBounds;
			if (this.ShowBorder)
			{
				buttonInnerBounds.Inflate(-1, -1);
			}
			if (vertical)
			{
				buttonInnerBounds.Inflate(0, -2);
			}
			else
			{
				buttonInnerBounds.Inflate(-2, 0);
			}
			base.LayoutImageAndText(buttonInnerBounds, vertical, rightToLeft);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x000130D0 File Offset: 0x000120D0
		public override ToolbarItemBase CloneItem()
		{
			StatusBarItem statusBarItem = (StatusBarItem)base.CloneItem();
			statusBarItem.ShowBorder = this.ShowBorder;
			return statusBarItem;
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x000130F8 File Offset: 0x000120F8
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x00013100 File Offset: 0x00012100
		[DefaultValue(100)]
		public override int MinimumSize
		{
			get
			{
				return base.MinimumSize;
			}
			set
			{
				base.MinimumSize = value;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x0001310C File Offset: 0x0001210C
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x00013114 File Offset: 0x00012114
		[Category("Appearance")]
		[Description("Indicates whether a border is drawn around the item.")]
		[DefaultValue(true)]
		public bool ShowBorder
		{
			get
			{
				return this.x14153082e2f91015;
			}
			set
			{
				this.x14153082e2f91015 = value;
				this.Invalidate();
			}
		}

		// Token: 0x040001A0 RID: 416
		private bool x14153082e2f91015 = true;
	}
}

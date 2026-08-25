using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200004A RID: 74
	public class DropDownMenuItem : TopLevelMenuItemBase
	{
		// Token: 0x060003BE RID: 958 RVA: 0x00013154 File Offset: 0x00012154
		protected internal override void ApplyLayout(Rectangle buttonBounds, Graphics graphics, bool vertical, bool rightToLeft)
		{
			base.ApplyLayout(buttonBounds, graphics, vertical, rightToLeft);
			Rectangle buttonInnerBounds = base.ButtonInnerBounds;
			buttonInnerBounds.Width -= 11;
			base.LayoutImageAndText(buttonInnerBounds, vertical, rightToLeft);
		}

		// Token: 0x060003BF RID: 959 RVA: 0x00013190 File Offset: 0x00012190
		public override ToolbarItemBase CloneItem()
		{
			DropDownMenuItem dropDownMenuItem = (DropDownMenuItem)base.CloneItem();
			dropDownMenuItem.MenuImageList = this.MenuImageList;
			return dropDownMenuItem;
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060003C0 RID: 960 RVA: 0x000131B8 File Offset: 0x000121B8
		// (set) Token: 0x060003C1 RID: 961 RVA: 0x000131C0 File Offset: 0x000121C0
		[DefaultValue(typeof(ImageList), null)]
		[Description("If specified, any submenus of this item will use this imagelist instead of the one belonging to the parent toolbar.")]
		[Category("Appearance")]
		public ImageList MenuImageList
		{
			get
			{
				return this._x2e27fb48bc60f1b7;
			}
			set
			{
				this._x2e27fb48bc60f1b7 = value;
			}
		}

		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060003C2 RID: 962 RVA: 0x000131CC File Offset: 0x000121CC
		// (set) Token: 0x060003C3 RID: 963 RVA: 0x000131D4 File Offset: 0x000121D4
		[Browsable(true)]
		public override string ToolTipText
		{
			get
			{
				return base.ToolTipText;
			}
			set
			{
				base.ToolTipText = value;
			}
		}

		// Token: 0x040001A1 RID: 417
		private ImageList _x2e27fb48bc60f1b7;
	}
}

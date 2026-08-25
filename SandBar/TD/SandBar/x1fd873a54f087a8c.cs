using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x0200006A RID: 106
	internal class x1fd873a54f087a8c : xaa20bb2d964a49fc
	{
		// Token: 0x06000530 RID: 1328 RVA: 0x0001BDC8 File Offset: 0x0001ADC8
		public x1fd873a54f087a8c(PopupMenu popupMenu, xf92605a24a69622a menuLooper, Screen screen) : base(popupMenu)
		{
			this.xfc6f89c16b215667 = menuLooper;
			this.x5f4a93c3032a9eb8 = screen;
			popupMenu.Move += this.xed1070c4442bd8ee;
			popupMenu.Resize += this.xbf89d87c09da11b1;
			popupMenu.MouseMove += this.x2c5d1da1234c3a6a;
			popupMenu.MouseUp += this.xbf1526c05253a47c;
			popupMenu.MouseDown += this.x2e2bbfe11746fd86;
			popupMenu.MouseLeave += this.xe511536603cc1651;
			this.xb2bcfbfd73a5f38b = new Timer();
			this.xb2bcfbfd73a5f38b.Tick += this.xa3b1c7498a61c714;
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0001BE78 File Offset: 0x0001AE78
		public override void Dispose()
		{
			this.xe2b8dd9f5802cf66();
			if (this.x156805b91c062619 != null)
			{
				this.x156805b91c062619.Tick -= this.x5f0024858b8c9dc8;
				this.x156805b91c062619.Dispose();
				this.x156805b91c062619 = null;
			}
			if (this.xb2bcfbfd73a5f38b != null)
			{
				this.xb2bcfbfd73a5f38b.Tick -= this.xa3b1c7498a61c714;
				this.xb2bcfbfd73a5f38b.Dispose();
				this.xb2bcfbfd73a5f38b = null;
			}
			base.Dispose();
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0001BEF4 File Offset: 0x0001AEF4
		protected internal override void LowImportanceItemsExpanded()
		{
			this.xfc6f89c16b215667.xb8440663279d3c82();
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0001BF04 File Offset: 0x0001AF04
		protected internal override bool AllowLowImportanceMenuItems
		{
			get
			{
				return this.xfc6f89c16b215667.x35065c826a7c41d7;
			}
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0001BF14 File Offset: 0x0001AF14
		private void x158cb90086c6646b()
		{
			this.xe2b8dd9f5802cf66();
			if (OSFeature.Feature.IsPresent(OSFeature.LayeredWindows))
			{
				this.x8ae0b63321e44ce3 = new ArrayList();
				if (base.xebcaeeeb5a07df77.MenuItem is TopLevelMenuItemBase)
				{
					Rectangle x561b187641dfe = base.xebcaeeeb5a07df77.x561b187641dfe790;
					switch (((TopLevelMenuItemBase)base.xebcaeeeb5a07df77.MenuItem).MenuDirection)
					{
					case MenuProjection.Top:
						this.xd87ac14a035f81ce();
						this.xd7958967e5961bd9();
						return;
					case MenuProjection.Bottom:
						this.xd87ac14a035f81ce();
						if (x561b187641dfe.Width != 0)
						{
							x8d92ef71874aef72 x8d92ef71874aef = new x8d92ef71874aef72(base.xebcaeeeb5a07df77.Host.Renderer.ShadowColor, false, false);
							x8d92ef71874aef.x47b5c057cc37f4ff(new Rectangle(x561b187641dfe.Right + 1, x561b187641dfe.Top + 4, 4, x561b187641dfe.Height - 4));
							this.x8ae0b63321e44ce3.Add(x8d92ef71874aef);
							return;
						}
						break;
					case MenuProjection.Left:
						break;
					case MenuProjection.Right:
						this.xd87ac14a035f81ce();
						if (x561b187641dfe.Width != 0)
						{
							x8d92ef71874aef72 x8d92ef71874aef = new x8d92ef71874aef72(base.xebcaeeeb5a07df77.Host.Renderer.ShadowColor, true, true);
							x8d92ef71874aef.x47b5c057cc37f4ff(new Rectangle(x561b187641dfe.Left + 4, x561b187641dfe.Bottom + 1, x561b187641dfe.Width - 3, 4));
							this.x8ae0b63321e44ce3.Add(x8d92ef71874aef);
							return;
						}
						break;
					default:
						return;
					}
				}
				else
				{
					this.xd87ac14a035f81ce();
				}
			}
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0001C06C File Offset: 0x0001B06C
		private void xd7958967e5961bd9()
		{
			if (base.xebcaeeeb5a07df77.x561b187641dfe790.Width != 0)
			{
				x8d92ef71874aef72 x8d92ef71874aef = new x8d92ef71874aef72(base.xebcaeeeb5a07df77.Host.Renderer.ShadowColor, false, true);
				x8d92ef71874aef.x47b5c057cc37f4ff(new Rectangle(base.xebcaeeeb5a07df77.x561b187641dfe790.Right + 1, base.xebcaeeeb5a07df77.x561b187641dfe790.Top, 4, base.xebcaeeeb5a07df77.x561b187641dfe790.Height + 4));
				this.x8ae0b63321e44ce3.Add(x8d92ef71874aef);
				x8d92ef71874aef = new x8d92ef71874aef72(base.xebcaeeeb5a07df77.Host.Renderer.ShadowColor, true, true);
				x8d92ef71874aef.x47b5c057cc37f4ff(new Rectangle(base.xebcaeeeb5a07df77.x561b187641dfe790.Left + 4, base.xebcaeeeb5a07df77.x561b187641dfe790.Bottom + 1, base.xebcaeeeb5a07df77.x561b187641dfe790.Width - 3, 4));
				this.x8ae0b63321e44ce3.Add(x8d92ef71874aef);
			}
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0001C180 File Offset: 0x0001B180
		private void xd87ac14a035f81ce()
		{
			Rectangle bounds = base.xebcaeeeb5a07df77.Bounds;
			x8d92ef71874aef72 x8d92ef71874aef = new x8d92ef71874aef72(base.xebcaeeeb5a07df77.Host.Renderer.ShadowColor, false, true);
			x8d92ef71874aef.x47b5c057cc37f4ff(new Rectangle(bounds.Right, bounds.Top + 4, 4, bounds.Height));
			this.x8ae0b63321e44ce3.Add(x8d92ef71874aef);
			x8d92ef71874aef = new x8d92ef71874aef72(base.xebcaeeeb5a07df77.Host.Renderer.ShadowColor, true, true);
			x8d92ef71874aef.x47b5c057cc37f4ff(new Rectangle(bounds.Left + 4, bounds.Bottom, bounds.Width - 4, 4));
			this.x8ae0b63321e44ce3.Add(x8d92ef71874aef);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0001C238 File Offset: 0x0001B238
		private void xe2b8dd9f5802cf66()
		{
			if (this.x8ae0b63321e44ce3 != null)
			{
				foreach (object obj in this.x8ae0b63321e44ce3)
				{
					x8d92ef71874aef72 x8d92ef71874aef = (x8d92ef71874aef72)obj;
					x8d92ef71874aef.Close();
				}
				this.x8ae0b63321e44ce3.Clear();
				this.x8ae0b63321e44ce3 = null;
			}
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0001C2B8 File Offset: 0x0001B2B8
		private void xed1070c4442bd8ee(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x8ae0b63321e44ce3 != null)
			{
				this.x158cb90086c6646b();
			}
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001C2C8 File Offset: 0x0001B2C8
		private void xbf89d87c09da11b1(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			if (this.x8ae0b63321e44ce3 != null)
			{
				this.x158cb90086c6646b();
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0001C2D8 File Offset: 0x0001B2D8
		protected internal override Rectangle ConstraintArea
		{
			get
			{
				return this.x5f4a93c3032a9eb8.Bounds;
			}
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0001C2E8 File Offset: 0x0001B2E8
		protected internal override void Show(ref int maximumMenuCount, TopLevelMenuItemBase.MenuAnimation desiredAnimation)
		{
			if (desiredAnimation != TopLevelMenuItemBase.MenuAnimation.None)
			{
				int num = 0;
				for (MenuItemBase menuItemBase = base.xebcaeeeb5a07df77.MenuItem; menuItemBase != null; menuItemBase = menuItemBase.Parent)
				{
					num++;
				}
				TopLevelMenuItemBase.MenuAnimation x95be56bdc2cd6bd = TopLevelMenuItemBase.MenuAnimation.None;
				if (num > maximumMenuCount)
				{
					maximumMenuCount = num;
					x95be56bdc2cd6bd = desiredAnimation;
				}
				xd552f4634d304df2.xf0e1044ac09df441(base.xebcaeeeb5a07df77, x95be56bdc2cd6bd);
			}
			x443cc432acaadb1d.SetWindowPos(base.xebcaeeeb5a07df77.Handle, 0, 0, 0, 0, 0, 87);
			if (OSFeature.Feature.IsPresent(OSFeature.LayeredWindows))
			{
				this.x156805b91c062619 = new Timer();
				this.x156805b91c062619.Interval = 40;
				this.x156805b91c062619.Enabled = true;
				this.x156805b91c062619.Tick += this.x5f0024858b8c9dc8;
			}
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0001C394 File Offset: 0x0001B394
		private void x5f0024858b8c9dc8(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.x156805b91c062619.Enabled = false;
			this.x158cb90086c6646b();
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0001C3A8 File Offset: 0x0001B3A8
		protected internal override bool ShouldHighlightItem(MenuButtonItem item)
		{
			return base.xebcaeeeb5a07df77.MenuItem.xe4f42f0e511fcd41 == item;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0001C3C0 File Offset: 0x0001B3C0
		private void xa3de7534958fb9e1(MenuItemBase x7bf8c4d03998048a)
		{
			this.xb2bcfbfd73a5f38b.Interval = this.xfc6f89c16b215667.xe1721ea98058f5f1;
			if (x7bf8c4d03998048a == base.xebcaeeeb5a07df77.x5683678bceda6657)
			{
				this.xb2bcfbfd73a5f38b.Interval += 200;
			}
			this.xb2bcfbfd73a5f38b.Enabled = false;
			this.xb2bcfbfd73a5f38b.Enabled = true;
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001C420 File Offset: 0x0001B420
		private void x2c5d1da1234c3a6a(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			MenuButtonItem menuButtonItem = base.xebcaeeeb5a07df77.GetItemAt(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
			x1fd873a54f087a8c.x9a1c0a729e17e6f1 = base.xebcaeeeb5a07df77.MenuItem;
			this.xa3de7534958fb9e1(menuButtonItem);
			if (menuButtonItem != null && !menuButtonItem.Enabled)
			{
				menuButtonItem = null;
			}
			bool flag = base.xebcaeeeb5a07df77.MenuItem.xe4f42f0e511fcd41 == menuButtonItem;
			base.xebcaeeeb5a07df77.MenuItem.xe4f42f0e511fcd41 = menuButtonItem;
			if (menuButtonItem != null && !flag)
			{
				menuButtonItem.OnSelect();
			}
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001C4A0 File Offset: 0x0001B4A0
		private void xbf1526c05253a47c(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			MenuButtonItem itemAt = base.xebcaeeeb5a07df77.GetItemAt(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
			if (itemAt == base.xebcaeeeb5a07df77.x5683678bceda6657)
			{
				base.xebcaeeeb5a07df77.xaabd57163b310c49();
				return;
			}
			if (itemAt != null && !itemAt.HasVisibleSubitems() && itemAt.Enabled && itemAt.Visible && !itemAt.x3780ff57150950cd)
			{
				this.xfc6f89c16b215667.xeb711626eeda8972 = new x72ff29faed0885ea(x72ff29faed0885ea.MenuCommandType.Execute, itemAt);
			}
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0001C51C File Offset: 0x0001B51C
		private void xa3b1c7498a61c714(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			this.xb2bcfbfd73a5f38b.Enabled = false;
			if (x1fd873a54f087a8c.x9a1c0a729e17e6f1.Popup == null)
			{
				return;
			}
			if (x1fd873a54f087a8c.x9a1c0a729e17e6f1.xe4f42f0e511fcd41 == x1fd873a54f087a8c.x9a1c0a729e17e6f1.Popup.x5683678bceda6657)
			{
				x1fd873a54f087a8c.x9a1c0a729e17e6f1.Popup.xaabd57163b310c49();
				return;
			}
			if (x1fd873a54f087a8c.x9a1c0a729e17e6f1.xe4f42f0e511fcd41 != null)
			{
				this.xfc6f89c16b215667.x75622bee932c5a3d(x1fd873a54f087a8c.x9a1c0a729e17e6f1.xe4f42f0e511fcd41, false);
				return;
			}
			this.xfc6f89c16b215667.x75622bee932c5a3d(x1fd873a54f087a8c.x9a1c0a729e17e6f1, false);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001C5A4 File Offset: 0x0001B5A4
		private void xe511536603cc1651(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			base.xebcaeeeb5a07df77.MenuItem.xe4f42f0e511fcd41 = null;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001C5B8 File Offset: 0x0001B5B8
		private void x2e2bbfe11746fd86(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
		{
			base.xebcaeeeb5a07df77.Capture = false;
			MenuButtonItem itemAt = base.xebcaeeeb5a07df77.GetItemAt(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
			if (itemAt == null)
			{
				this.xfc6f89c16b215667.x75622bee932c5a3d(base.xebcaeeeb5a07df77.MenuItem, false);
				return;
			}
			if (itemAt.Popup != null || itemAt == base.xebcaeeeb5a07df77.x5683678bceda6657)
			{
				return;
			}
			this.xfc6f89c16b215667.x75622bee932c5a3d(itemAt, false);
		}

		// Token: 0x04000226 RID: 550
		private xf92605a24a69622a xfc6f89c16b215667;

		// Token: 0x04000227 RID: 551
		private Screen x5f4a93c3032a9eb8;

		// Token: 0x04000228 RID: 552
		private static MenuItemBase x9a1c0a729e17e6f1;

		// Token: 0x04000229 RID: 553
		private Timer xb2bcfbfd73a5f38b;

		// Token: 0x0400022A RID: 554
		private ArrayList x8ae0b63321e44ce3;

		// Token: 0x0400022B RID: 555
		private Timer x156805b91c062619;
	}
}

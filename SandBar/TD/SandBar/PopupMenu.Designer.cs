namespace TD.SandBar
{
	// Token: 0x02000024 RID: 36
	public partial class PopupMenu : global::System.Windows.Forms.Form
	{
		// Token: 0x06000212 RID: 530 RVA: 0x0000954C File Offset: 0x0000854C
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.x10d0328f698a7faa.Dispose();
				if (this.xac1c850120b1f254 != null)
				{
					this.xac1c850120b1f254.x9b21ee8e7ceaada3 -= new global::TD.Util.xf8f9565783602018.x58986a4a0b75e5b5(this.x7770570abeef94ae);
					this.xac1c850120b1f254.Dispose();
					this.xac1c850120b1f254 = null;
				}
				this.x5d56ae798b9cdf38.Tick -= new global::System.EventHandler(this.xcaf19fd9570f4eb4);
				this.x5d56ae798b9cdf38.Dispose();
				this.x5d56ae798b9cdf38 = null;
				this.xf3096a62f62f7b4a.Dispose();
				this.xf3096a62f62f7b4a = null;
			}
			base.Dispose(disposing);
		}

		// Token: 0x040000B9 RID: 185
		private global::TD.SandBar.MenuButtonItem xf3096a62f62f7b4a;

		// Token: 0x040000BA RID: 186
		private global::TD.Util.xf8f9565783602018 xac1c850120b1f254;

		// Token: 0x040000BB RID: 187
		private global::TD.SandBar.xaa20bb2d964a49fc x10d0328f698a7faa;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.Timer x5d56ae798b9cdf38;
	}
}

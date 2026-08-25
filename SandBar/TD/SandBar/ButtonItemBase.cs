using System;
using System.Collections;
using System.ComponentModel;

namespace TD.SandBar
{
	// Token: 0x0200001B RID: 27
	public abstract class ButtonItemBase : ImageItemBase
	{
		// Token: 0x060001C3 RID: 451 RVA: 0x00008300 File Offset: 0x00007300
		internal ButtonItemBase()
		{
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00008308 File Offset: 0x00007308
		protected internal override void OnActivate()
		{
			if (this.AutoToggle == AutoToggleType.Single)
			{
				this.Checked = !this.Checked;
			}
			else if (this.AutoToggle == AutoToggleType.Radio)
			{
				this.x688980bf791587f1();
			}
			base.OnActivate();
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000833C File Offset: 0x0000733C
		private void x688980bf791587f1()
		{
			this.Checked = true;
			if (base.ToolBar != null)
			{
				ArrayList arrayList = new ArrayList();
				int num = base.ToolBar.Items.IndexOf(this);
				if (!this.BeginGroup)
				{
					for (int i = num - 1; i >= 0; i--)
					{
						arrayList.Add(base.ToolBar.Items[i]);
						if (base.ToolBar.Items[i].BeginGroup)
						{
							break;
						}
					}
				}
				int num2 = num + 1;
				while (num2 < base.ToolBar.Items.Count && !base.ToolBar.Items[num2].BeginGroup)
				{
					arrayList.Add(base.ToolBar.Items[num2]);
					num2++;
				}
				foreach (object obj in arrayList)
				{
					ToolbarItemBase toolbarItemBase = (ToolbarItemBase)obj;
					ButtonItemBase buttonItemBase = toolbarItemBase as ButtonItemBase;
					if (buttonItemBase != null)
					{
						buttonItemBase.Checked = false;
					}
				}
			}
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00008470 File Offset: 0x00007470
		public override ToolbarItemBase CloneItem()
		{
			ButtonItemBase buttonItemBase = (ButtonItemBase)base.CloneItem();
			buttonItemBase.Checked = this.Checked;
			return buttonItemBase;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00008498 File Offset: 0x00007498
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x000084A0 File Offset: 0x000074A0
		[Description("Indicates how the button will automatically toggle itself and its neighbours.")]
		[Category("Behavior")]
		[DefaultValue(typeof(AutoToggleType), "None")]
		public AutoToggleType AutoToggle
		{
			get
			{
				return this.x6e44400231fc19ed;
			}
			set
			{
				this.x6e44400231fc19ed = value;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x000084AC File Offset: 0x000074AC
		// (set) Token: 0x060001CA RID: 458 RVA: 0x000084B4 File Offset: 0x000074B4
		[Description("Indicates whether the item is in a checked, or toggled, state.")]
		[Category("Appearance")]
		[DefaultValue(false)]
		public virtual bool Checked
		{
			get
			{
				return this._x07d4c1c683eae0fd;
			}
			set
			{
				if (value != this._x07d4c1c683eae0fd)
				{
					this._x07d4c1c683eae0fd = value;
					this.Invalidate();
				}
			}
		}

		// Token: 0x0400009B RID: 155
		private bool _x07d4c1c683eae0fd;

		// Token: 0x0400009C RID: 156
		private AutoToggleType x6e44400231fc19ed;
	}
}

using System;
using IGE.Nomad;
using IGE.Parameters;
using Ubisoft;

namespace IGE.ViewModels
{
	// Token: 0x020000ED RID: 237
	internal class PromptInventoryListViewModel : ViewModel
	{
		// Token: 0x06000864 RID: 2148 RVA: 0x0001C888 File Offset: 0x0001AA88
		public PromptInventoryListViewModel()
		{
			this.ObjectSelector = new ObjectSelectorViewModel();
			this.ObjectSelector.ValueChanged += delegate(object o, EventArgs a)
			{
				this.RaiseValueChanged();
			};
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x0001C8C4 File Offset: 0x0001AAC4
		// (set) Token: 0x06000866 RID: 2150 RVA: 0x0001C8D1 File Offset: 0x0001AAD1
		public string DisplayName
		{
			get
			{
				return this.ObjectSelector.DisplayName;
			}
			set
			{
				this.ObjectSelector.DisplayName = value;
			}
		}

		// Token: 0x170001E3 RID: 483
		// (set) Token: 0x06000867 RID: 2151 RVA: 0x0001C8DF File Offset: 0x0001AADF
		public Inventory.Entry Root
		{
			set
			{
				this.ObjectSelector.Root = value;
			}
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000868 RID: 2152 RVA: 0x0001C8F0 File Offset: 0x0001AAF0
		// (remove) Token: 0x06000869 RID: 2153 RVA: 0x0001C928 File Offset: 0x0001AB28
		public event EventHandler ValueChanged;

		// Token: 0x0600086A RID: 2154 RVA: 0x0001C960 File Offset: 0x0001AB60
		private void RaiseValueChanged()
		{
			EventHandler valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged(this, EventArgs.Empty);
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x0001C983 File Offset: 0x0001AB83
		// (set) Token: 0x0600086C RID: 2156 RVA: 0x0001C990 File Offset: 0x0001AB90
		public Inventory.Entry Value
		{
			get
			{
				return this.ObjectSelector.Value;
			}
			set
			{
				this.ObjectSelector.Value = value;
			}
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x0001C99E File Offset: 0x0001AB9E
		// (set) Token: 0x0600086E RID: 2158 RVA: 0x0001C9A6 File Offset: 0x0001ABA6
		public ObjectSelectorViewModel ObjectSelector { get; private set; }
	}
}

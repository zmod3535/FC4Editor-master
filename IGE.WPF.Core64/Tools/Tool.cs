using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IGE.Parameters;
using IGE.ViewModels;

namespace IGE.Tools
{
	// Token: 0x0200003A RID: 58
	internal abstract class Tool : ToolBase
	{
		// Token: 0x060002C7 RID: 711 RVA: 0x0000871B File Offset: 0x0000691B
		protected Tool(string displayName, string imageFilename) : base(displayName, imageFilename)
		{
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060002C8 RID: 712 RVA: 0x00008725 File Offset: 0x00006925
		// (set) Token: 0x060002C9 RID: 713 RVA: 0x0000872D File Offset: 0x0000692D
		public MainWindowViewModel Parent { get; set; }

		// Token: 0x060002CA RID: 714 RVA: 0x00008736 File Offset: 0x00006936
		public virtual void Initialize()
		{
			this.Parameters = new ObservableCollection<Parameter>(this.GetParameters());
		}

		// Token: 0x060002CB RID: 715
		public abstract string GetContextHelp();

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060002CC RID: 716 RVA: 0x00008749 File Offset: 0x00006949
		// (set) Token: 0x060002CD RID: 717 RVA: 0x00008751 File Offset: 0x00006951
		public virtual bool IsActive
		{
			get
			{
				return this._isActive;
			}
			set
			{
				if (this._isActive == value)
				{
					return;
				}
				this._isActive = value;
				base.RaisePropertyChanged("IsActive");
				if (this._isActive)
				{
					this.RaiseActivate();
				}
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060002CE RID: 718 RVA: 0x0000877D File Offset: 0x0000697D
		// (set) Token: 0x060002CF RID: 719 RVA: 0x00008785 File Offset: 0x00006985
		public ObservableCollection<Parameter> Parameters
		{
			get
			{
				return this._parameters;
			}
			protected set
			{
				this._parameters = value;
				base.RaisePropertyChanged("Parameters");
			}
		}

		// Token: 0x060002D0 RID: 720
		protected abstract IEnumerable<Parameter> GetParameters();

		// Token: 0x060002D1 RID: 721 RVA: 0x00008799 File Offset: 0x00006999
		public virtual void Activate()
		{
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000879B File Offset: 0x0000699B
		public virtual void Deactivate()
		{
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000879D File Offset: 0x0000699D
		public virtual void Refresh()
		{
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000879F File Offset: 0x0000699F
		public virtual void OnSwitchFrom(ToolBase prevTool)
		{
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x000087A1 File Offset: 0x000069A1
		public virtual void OnSwitchTo(ToolBase nextTool)
		{
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x000087A3 File Offset: 0x000069A3
		public virtual void UpdateTool(float dt)
		{
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060002D7 RID: 727 RVA: 0x000087A8 File Offset: 0x000069A8
		// (remove) Token: 0x060002D8 RID: 728 RVA: 0x000087E0 File Offset: 0x000069E0
		public event EventHandler ActivateEvent;

		// Token: 0x060002D9 RID: 729 RVA: 0x00008818 File Offset: 0x00006A18
		protected void RaiseActivate()
		{
			EventHandler activateEvent = this.ActivateEvent;
			if (activateEvent != null)
			{
				activateEvent(this, EventArgs.Empty);
			}
		}

		// Token: 0x04000118 RID: 280
		private bool _isActive;

		// Token: 0x04000119 RID: 281
		private ObservableCollection<Parameter> _parameters;
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using IGE.Nomad;
using IGE.Parameters;
using Ubisoft;

namespace IGE.ViewModels
{
	// Token: 0x020000BC RID: 188
	internal class BudgetsViewModel : ViewModel
	{
		// Token: 0x06000726 RID: 1830 RVA: 0x00019CF8 File Offset: 0x00017EF8
		internal BudgetsViewModel()
		{
			this.SetUpParams();
			BudgetManager.ResetBudgetWarningStatus();
			this._showWaveCallback = new Binding.ShowWaveCallback(this.OnShowWaveOnly);
			Binding.FCE_AI_ShowWaveCallback(this._showWaveCallback);
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x00019D64 File Offset: 0x00017F64
		public void SetUpParams()
		{
			this._groupParams.Clear();
			this.parameters.Clear();
			this._waveBars.Clear();
			for (int i = 0; i < 5; i++)
			{
				ParamBudgetBar item = new ParamBudgetBar(string.Format("{0} {1}", Localizer.LocalizeCommon("BUDGETS_WAVE"), i + 1), false, false);
				this.parameters.Add(item);
				this._waveBars.Add(item);
			}
			ParamGroup item2 = new ParamGroup(Localizer.LocalizeCommon("BUDGETS_AI"), this.parameters);
			this._groupParams.Add(item2);
			this.parameters.Clear();
			this._objectsBar = new ParamBudgetBar(Localizer.LocalizeCommon("BUDGETS_OBJECTS"), false, false);
			this.parameters.Add(this._objectsBar);
			ParamGroup item3 = new ParamGroup(Localizer.LocalizeCommon("BUDGETS_OTHER"), this.parameters);
			this._groupParams.Add(item3);
			this.Parameters = new ObservableCollection<Parameter>(this.GetParameters());
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00019E62 File Offset: 0x00018062
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x00019E6A File Offset: 0x0001806A
		public ObservableCollection<Parameter> Parameters
		{
			get
			{
				return this._parameters;
			}
			set
			{
				this._parameters = value;
				base.RaisePropertyChanged("Parameters");
			}
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0001A010 File Offset: 0x00018210
		protected IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in this._groupParams)
			{
				yield return param;
			}
			yield break;
		}

		// Token: 0x0600072B RID: 1835 RVA: 0x0001A030 File Offset: 0x00018230
		public void UpdateBudgets(float dt)
		{
			this._budgetUpdateDt += dt;
			if (this._budgetUpdateDt < 0.1f)
			{
				return;
			}
			this._budgetUpdateDt = 0f;
			float objectUsage = BudgetManager.ObjectUsage;
			if (Math.Abs(this._prevObjValue - objectUsage) > 0.1f)
			{
				this._objectsBar.SetInfo(objectUsage, BudgetManager.MaxObjectUsage, 0f);
			}
			int num = 0;
			foreach (ParamBudgetBar paramBudgetBar in this._waveBars)
			{
				paramBudgetBar.SetInfo(BudgetManager.GetWaveValue(num), BudgetManager.GetMaxWaveValue(num), BudgetManager.GetAmbientAI() + BudgetManager.Vehicles);
				num++;
			}
		}

		// Token: 0x0600072C RID: 1836 RVA: 0x0001A0F8 File Offset: 0x000182F8
		private void OnShowWaveOnly(int waveId)
		{
			for (int i = 0; i < this._waveBars.Count; i++)
			{
				if (i == waveId || waveId < 0)
				{
					this._waveBars[i].Visible = Visibility.Visible;
				}
				else
				{
					this._waveBars[i].Visible = Visibility.Collapsed;
				}
			}
		}

		// Token: 0x040002E1 RID: 737
		private List<ParamGroup> _groupParams = new List<ParamGroup>();

		// Token: 0x040002E2 RID: 738
		private List<Parameter> parameters = new List<Parameter>();

		// Token: 0x040002E3 RID: 739
		private ParamBudgetBar _objectsBar;

		// Token: 0x040002E4 RID: 740
		private List<ParamBudgetBar> _waveBars = new List<ParamBudgetBar>();

		// Token: 0x040002E5 RID: 741
		private float _budgetUpdateDt;

		// Token: 0x040002E6 RID: 742
		private Binding.ShowWaveCallback _showWaveCallback;

		// Token: 0x040002E7 RID: 743
		private float _prevObjValue = -1f;

		// Token: 0x040002E8 RID: 744
		private ObservableCollection<Parameter> _parameters;
	}
}

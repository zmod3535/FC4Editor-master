using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000388 RID: 904
	internal class ToolRoad : ToolSpline
	{
		// Token: 0x06001462 RID: 5218 RVA: 0x0002B4EC File Offset: 0x000296EC
		public ToolRoad() : base(Localizer.Localize("TOOL_ROADS", null), "toolbar/objects/Spline.png")
		{
			bool enableChange = true;
			bool showFolders = false;
			this._paramRoad = new ParamSlotListViewModel(Localizer.Localize("PARAM_ROADS", null), SplineInventory.Instance.Root, 8, false, enableChange, showFolders);
			this._paramRoad.ValueChanged += delegate(object s, EventArgs ea)
			{
				this.spline_ValueChanged();
			};
			this._paramRoad.SlotChanged += delegate(object s, EventArgs ea)
			{
				this.OnAssignSlot(ea);
			};
			this._paramRoadWidth = new ParamFloat(Localizer.Localize("PARAM_ROAD_WIDTH", null), 1f, 8f, 0.1f, new ValueParameter<float>.ValueChangedDelegate(this.SetRoadWidth));
			this._paramRoadWidth.Value = 4f;
		}

		// Token: 0x06001463 RID: 5219 RVA: 0x0002B6D4 File Offset: 0x000298D4
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this._paramEditTool;
			yield return this._paramRoadWidth;
			yield return this._paramRoad;
			yield break;
		}

		// Token: 0x06001464 RID: 5220 RVA: 0x0002B6F1 File Offset: 0x000298F1
		public override Parameter GetMainParameter()
		{
			return this._paramRoad;
		}

		// Token: 0x06001465 RID: 5221 RVA: 0x0002B6F9 File Offset: 0x000298F9
		public override string GetContextHelp()
		{
			return Localizer.LocalizeCommon("HELP_TOOL_ROAD") + "\r\n\r\n" + base.GetSplineHelp();
		}

		// Token: 0x06001466 RID: 5222 RVA: 0x0002B718 File Offset: 0x00029918
		private void OnAssignSlot(EventArgs ea)
		{
			ParamSlotListViewModel.EntryChangeEventArgs entryChangeEventArgs = (ParamSlotListViewModel.EntryChangeEventArgs)ea;
			bool flag = entryChangeEventArgs.Entry == null || !entryChangeEventArgs.Entry.IsValid;
			if (flag)
			{
				SplineManager.DestroyRoad(entryChangeEventArgs.Id);
			}
			else
			{
				bool flag2 = false;
				SplineRoad splineRoad = SplineManager.GetRoadFromId(entryChangeEventArgs.Id);
				if (!splineRoad.IsValid)
				{
					splineRoad = SplineManager.CreateRoad(entryChangeEventArgs.Id);
					flag2 = true;
				}
				SplineInventory.Entry entry = (SplineInventory.Entry)entryChangeEventArgs.Entry;
				splineRoad.Entry = entry;
				splineRoad.Width = entry.DefaultWidth;
				splineRoad.UpdateSpline();
				if (flag2)
				{
					this._paint.IsActive = true;
				}
			}
			this.UpdateSplineList(flag ? -1 : entryChangeEventArgs.Id);
			this.UpdateSelectedSpline();
		}

		// Token: 0x06001467 RID: 5223 RVA: 0x0002B7CF File Offset: 0x000299CF
		private void spline_ValueChanged()
		{
			this.UpdateSelectedSpline();
		}

		// Token: 0x06001468 RID: 5224 RVA: 0x0002B7D7 File Offset: 0x000299D7
		private void SetRoadWidth(float value)
		{
			if (this.m_splineRoad != null && this.m_splineRoad.IsValid)
			{
				this.m_splineRoad.Width = value;
				this.m_splineRoad.UpdateSpline();
			}
		}

		// Token: 0x06001469 RID: 5225 RVA: 0x0002B805 File Offset: 0x00029A05
		private void UpdateSelectedSpline()
		{
			this.SetSplineRoad((this._paramRoad.Value != -1) ? SplineManager.GetRoadFromId(this._paramRoad.Value) : SplineRoad.Null);
		}

		// Token: 0x0600146A RID: 5226 RVA: 0x0002B834 File Offset: 0x00029A34
		private void SetSplineRoad(SplineRoad splineRoad)
		{
			this.m_splineRoad = splineRoad;
			base.SetSpline(splineRoad);
			this._paramRoadWidth.Enabled = this.m_splineRoad.IsValid;
			if (this.m_splineRoad.IsValid)
			{
				this._paramRoadWidth.Value = this.m_splineRoad.Width;
			}
		}

		// Token: 0x0600146B RID: 5227 RVA: 0x0002B888 File Offset: 0x00029A88
		public override void Activate()
		{
			base.Activate();
			this.UpdateSelectedSpline();
			this.UpdateSplineList(-1);
		}

		// Token: 0x0600146C RID: 5228 RVA: 0x0002B8A0 File Offset: 0x00029AA0
		private void UpdateSplineList(int selection)
		{
			ObservableCollection<ParamSlotItemViewModel> observableCollection = new ObservableCollection<ParamSlotItemViewModel>();
			for (int i = 0; i < this._paramRoad.SlotCount; i++)
			{
				SplineRoad roadFromId = SplineManager.GetRoadFromId(i);
				if (roadFromId.IsValid)
				{
					observableCollection.Add(new ParamSlotItemViewModel(roadFromId.Entry, i));
				}
			}
			this._paramRoad.Items = observableCollection;
			if (selection >= 0 && selection < this._paramRoad.Items.Count)
			{
				this._paramRoad.SelectedItem = this._paramRoad.Items[selection];
			}
		}

		// Token: 0x0400077F RID: 1919
		private readonly ParamSlotListViewModel _paramRoad;

		// Token: 0x04000780 RID: 1920
		private readonly ParamFloat _paramRoadWidth;

		// Token: 0x04000781 RID: 1921
		private SplineRoad m_splineRoad;
	}
}

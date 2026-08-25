using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x0200003D RID: 61
	internal class ToolEnvironment : Tool
	{
		// Token: 0x060002EC RID: 748 RVA: 0x00008F14 File Offset: 0x00007114
		public ToolEnvironment() : base(Localizer.Localize("TOOL_ENVIRONMENT", null), "toolbar/miscellaneous/Environment.png")
		{
			this._paramTime = new ParamTime(Localizer.Localize("PARAM_TIME", null), delegate(TimeSpan value)
			{
				Engine.TimeOfDay = value;
			});
			this._paramCloudType = new ParamFloat(Localizer.Localize("PARAM_CLOUD_TYPE", null), 0f, (float)(Engine.CloudTypeCount - 1), 1f, delegate(float value)
			{
				Engine.CloudType = (int)Math.Round((double)value);
			})
			{
				Value = 0f
			};
			this._paramWaterLevel = new ParamFloat(Localizer.Localize("PARAM_WATER_LEVEL", null), 0f, 500f, 0.1f, delegate(float value)
			{
				TerrainManager.GlobalWaterLevel = value;
			})
			{
				Value = 0f
			};
			this._paramSnow = new ParamBool(Localizer.LocalizeCommon("PARAM_ENABLE_SNOW"), delegate(bool value)
			{
				Engine.SnowEnabled = value;
			})
			{
				Value = false
			};
			this._paramBackdrop = new ParamBool(Localizer.LocalizeCommon("PARAM_ENABLE_BACKDROP"), delegate(bool value)
			{
				Engine.BackdropEnabled = value;
			})
			{
				Value = false
			};
			this._paramLogicZone = new ParamEnumCombo(Localizer.LocalizeCommon("PARAM_AMBIENT_LIGHTING"), null, new ParamEnumBase.ValueChangedDelegate(this.LogicZoneChangedDelegate));
			this._paramSoundRegion = new ParamEnumCombo(Localizer.LocalizeCommon("PARAM_AMBIENT_SOUND"), null, new ParamEnumBase.ValueChangedDelegate(this.SoundRegionChangedDelegate));
			this._paramLogicZone.Values = new ObservableCollection<ParamEnumBase.Entry>(this.GetRegionEntries("LogicZones"));
			this._paramSoundRegion.Values = new ObservableCollection<ParamEnumBase.Entry>(this.GetRegionEntries("SoundRegions"));
		}

		// Token: 0x060002ED RID: 749 RVA: 0x000092B4 File Offset: 0x000074B4
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this._paramTime;
			yield return this._paramCloudType;
			yield return this._paramWaterLevel;
			yield return this._paramSnow;
			yield return this._paramBackdrop;
			yield return this._paramLogicZone;
			yield return this._paramSoundRegion;
			yield break;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x000092D1 File Offset: 0x000074D1
		public Parameter GetMainParameter()
		{
			return null;
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000092D4 File Offset: 0x000074D4
		public override string GetContextHelp()
		{
			return Localizer.LocalizeCommon("HELP_TOOL_ENVIRONMENT");
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000092E0 File Offset: 0x000074E0
		public override void Activate()
		{
			this._paramTime.Value = Engine.TimeOfDay;
			this._paramCloudType.Value = (float)Engine.CloudType;
			this._paramSnow.Value = Engine.SnowEnabled;
			this._paramBackdrop.Value = Engine.BackdropEnabled;
			this._paramWaterLevel.Value = TerrainManager.GlobalWaterLevel;
			int num = 0;
			int logicZoneId = TerrainManager.GetLogicZoneId();
			foreach (ParamEnumBase.Entry entry in this._paramLogicZone.Values)
			{
				if ((int)entry.Value == logicZoneId)
				{
					this._paramLogicZone.SelectedIndex = num;
					break;
				}
				num++;
			}
			num = 0;
			int soundRegionId = TerrainManager.GetSoundRegionId();
			foreach (ParamEnumBase.Entry entry2 in this._paramSoundRegion.Values)
			{
				if ((int)entry2.Value == soundRegionId)
				{
					this._paramSoundRegion.SelectedIndex = num;
					break;
				}
				num++;
			}
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00009414 File Offset: 0x00007614
		public override void Deactivate()
		{
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00009416 File Offset: 0x00007616
		public void OnSwitchFrom(Tool prevTool)
		{
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00009418 File Offset: 0x00007618
		public void OnSwitchTo(Tool nextTool)
		{
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x0000941C File Offset: 0x0000761C
		private IEnumerable<ParamEnumBase.Entry> GetRegionEntries(string regionType)
		{
			List<ParamEnumBase.Entry> list = new List<ParamEnumBase.Entry>();
			RegionInventory.Entry directoryFromId = RegionInventory.Instance.GetDirectoryFromId(regionType);
			if (directoryFromId != null)
			{
				foreach (RegionInventory.Entry entry in directoryFromId.Children)
				{
					ParamEnumText item = new ParamEnumText(entry.DisplayName, entry.RegionId);
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00009489 File Offset: 0x00007689
		private void LogicZoneChangedDelegate(object sender, object oldValue, object newValue)
		{
			TerrainManager.SetLogicZoneId((int)this._paramLogicZone.SelectedItem.Value);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x000094A5 File Offset: 0x000076A5
		private void SoundRegionChangedDelegate(object sender, object oldValue, object newValue)
		{
			TerrainManager.SetSoundRegionId((int)this._paramSoundRegion.SelectedItem.Value);
		}

		// Token: 0x04000128 RID: 296
		private readonly ParamTime _paramTime;

		// Token: 0x04000129 RID: 297
		private readonly ParamFloat _paramCloudType;

		// Token: 0x0400012A RID: 298
		private readonly ParamFloat _paramWaterLevel;

		// Token: 0x0400012B RID: 299
		private readonly ParamBool _paramSnow;

		// Token: 0x0400012C RID: 300
		private readonly ParamBool _paramBackdrop;

		// Token: 0x0400012D RID: 301
		private readonly ParamEnumCombo _paramLogicZone;

		// Token: 0x0400012E RID: 302
		private readonly ParamEnumCombo _paramSoundRegion;
	}
}

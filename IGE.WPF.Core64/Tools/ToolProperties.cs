using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x0200003B RID: 59
	internal class ToolProperties : Tool
	{
		// Token: 0x060002DA RID: 730 RVA: 0x00008850 File Offset: 0x00006A50
		public ToolProperties() : base(Localizer.Localize("TOOL_PROPERTIES", null), "toolbar/main/Properties.png")
		{
			this._paramMapName = new ParamText(Localizer.Localize("PARAM_MAP_NAME", null));
			this._paramSnapshot = new ParamSnapshot();
			string button = Localizer.LocalizeCommon(260109U);
			this._paramObjective = new ParamTextEdit(Localizer.LocalizeCommon("PARAM_MAP_OBJECTIVE"), button);
			this._paramObjective.ButtonCommand.ExecuteDelegate = delegate(object o)
			{
				if (this.OnMapModeChange != null)
				{
					this.OnMapModeChange();
				}
			};
			this._paramBalanceTag = new ParamEnumCombo(Localizer.LocalizeCommon("PARAM_BALANCE_TAG"), null);
			this._paramUserTag = new ParamEnumCombo(Localizer.LocalizeCommon("PARAM_USER_TAG"), null);
			this._paramCreatorName = new ParamText(Localizer.Localize("PARAM_MAP_CREATOR", null));
			this._paramAuthorName = new ParamText(Localizer.Localize("PARAM_MAP_AUTHOR", null));
			this._nullEntry = new ParamEnumText(this._nullTag.DisplayName, this._nullTag);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00008B10 File Offset: 0x00006D10
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this._paramMapName;
			yield return this._paramSnapshot;
			yield return this._paramObjective;
			yield return this._paramBalanceTag;
			yield return this._paramUserTag;
			yield return this._paramCreatorName;
			yield return this._paramAuthorName;
			yield break;
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00008B2D File Offset: 0x00006D2D
		public override string GetContextHelp()
		{
			if (string.IsNullOrEmpty(this._helpString))
			{
				this._helpString = string.Format("{0}\r\n\r\n{1}", Localizer.LocalizeCommon("HELP_TOPIC_PROPERTIES"), Localizer.LocalizeCommon("HELP_TOOL_SNAPSHOT"));
			}
			return this._helpString;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00008B66 File Offset: 0x00006D66
		private static bool ConfirmMapIdChange()
		{
			return MessageBox.Show(Program.MainWin, Localizer.Localize("MSG_WARNING_MAPID_CHANGE", null), Localizer.Localize("WARNING", null), MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No) == MessageBoxResult.Yes;
		}

		// Token: 0x060002DE RID: 734 RVA: 0x00008B8F File Offset: 0x00006D8F
		public override void Activate()
		{
			this._paramSnapshot.UpdateSnapshot();
			this.Refresh();
			this.SetupBalanceTagParam();
			this.SetupUserTagParams();
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00008BAE File Offset: 0x00006DAE
		public override void Deactivate()
		{
			this.SaveTags();
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00008BB8 File Offset: 0x00006DB8
		public override void Refresh()
		{
			string arg = string.IsNullOrEmpty(EditorDocument.MapName) ? Localizer.Localize("DEFAULT_MAP_NAME", null) : EditorDocument.MapName;
			string arg2 = string.IsNullOrEmpty(EditorDocument.CreatorName) ? Localizer.Localize("PARAM_UNDEFINED", null) : EditorDocument.CreatorName;
			string arg3 = string.IsNullOrEmpty(EditorDocument.AuthorName) ? Localizer.Localize("PARAM_UNDEFINED", null) : EditorDocument.AuthorName;
			this._paramMapName.DisplayName = string.Format("{0}: {1}", Localizer.Localize("PARAM_MAP_NAME", null), arg);
			this._paramCreatorName.DisplayName = string.Format("{0}: {1}", Localizer.Localize("PARAM_MAP_CREATOR", null), arg2);
			this._paramAuthorName.DisplayName = string.Format("{0}: {1}", Localizer.Localize("PARAM_MAP_AUTHOR", null), arg3);
			ulong currentObjectiveType = GameModeManager.GetCurrentObjectiveType();
			ObjectiveType objectiveType = GameModeManager.ObjectiveTypes[currentObjectiveType];
			string name = objectiveType.Name;
			this._paramObjective.DisplayName = string.Format("{0}: {1}", Localizer.LocalizeCommon("PARAM_MAP_OBJECTIVE"), name);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00008CC4 File Offset: 0x00006EC4
		public void SaveTags()
		{
			MapTag mapTag = this._paramBalanceTag.Value as MapTag;
			mapTag = ((mapTag == null) ? MapTags.DefaultEnumMapTag : mapTag);
			List<MapTag> list = new List<MapTag>();
			MapTag mapTag2 = this._paramUserTag.Value as MapTag;
			if (mapTag2 != null && mapTag2 != this._nullTag)
			{
				list.Add(mapTag2);
			}
			MapTags.SaveMapTags(mapTag, list);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x00008D20 File Offset: 0x00006F20
		private void SetupBalanceTagParam()
		{
			if (this._paramBalanceTag.Values == null)
			{
				this._paramBalanceTag.Values = new ObservableCollection<ParamEnumBase.Entry>(this.GetEnumTags());
			}
			MapTag mapTag = MapTags.GetCurrentEnumMapTag();
			if (mapTag == null)
			{
				mapTag = MapTags.DefaultEnumMapTag;
			}
			this._paramBalanceTag.Value = mapTag;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00008D6C File Offset: 0x00006F6C
		private void SetupUserTagParams()
		{
			List<MapTag> currentUserMapTags = MapTags.GetCurrentUserMapTags();
			if (this._paramUserTag.Values == null)
			{
				this._paramUserTag.Values = new ObservableCollection<ParamEnumBase.Entry>(this.GetUserTags());
			}
			this._paramUserTag.Value = ((currentUserMapTags.Count > 0) ? currentUserMapTags[0] : this._nullEntry.Value);
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00008DCC File Offset: 0x00006FCC
		private IEnumerable<ParamEnumBase.Entry> GetEnumTags()
		{
			List<ParamEnumBase.Entry> list = new List<ParamEnumBase.Entry>();
			List<MapTag> enumMapTags = MapTags.GetEnumMapTags();
			foreach (MapTag mapTag in enumMapTags)
			{
				ParamEnumText item = new ParamEnumText(mapTag.DisplayName, mapTag);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x00008E4C File Offset: 0x0000704C
		private IEnumerable<ParamEnumBase.Entry> GetUserTags()
		{
			List<ParamEnumBase.Entry> list = new List<ParamEnumBase.Entry>();
			list.Add(this._nullEntry);
			List<MapTag> userMapTags = MapTags.GetUserMapTags();
			userMapTags.Sort((MapTag lhs, MapTag rhs) => lhs.DisplayName.CompareTo(rhs.DisplayName));
			foreach (MapTag mapTag in userMapTags)
			{
				ParamEnumText item = new ParamEnumText(mapTag.DisplayName, mapTag);
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0400011C RID: 284
		public ToolProperties.MapModeChange OnMapModeChange;

		// Token: 0x0400011D RID: 285
		private readonly ParamText _paramMapName;

		// Token: 0x0400011E RID: 286
		private readonly ParamSnapshot _paramSnapshot;

		// Token: 0x0400011F RID: 287
		private readonly ParamTextEdit _paramObjective;

		// Token: 0x04000120 RID: 288
		private readonly ParamEnumCombo _paramBalanceTag;

		// Token: 0x04000121 RID: 289
		private readonly ParamEnumCombo _paramUserTag;

		// Token: 0x04000122 RID: 290
		private readonly ParamText _paramCreatorName;

		// Token: 0x04000123 RID: 291
		private readonly ParamText _paramAuthorName;

		// Token: 0x04000124 RID: 292
		private string _helpString;

		// Token: 0x04000125 RID: 293
		private MapTag _nullTag = MapTag.NullTag;

		// Token: 0x04000126 RID: 294
		private ParamEnumText _nullEntry;

		// Token: 0x0200003C RID: 60
		// (Invoke) Token: 0x060002E9 RID: 745
		public delegate void MapModeChange();
	}
}

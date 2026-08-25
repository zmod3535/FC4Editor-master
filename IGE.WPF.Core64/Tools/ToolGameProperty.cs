using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x020000BB RID: 187
	internal class ToolGameProperty : Tool
	{
		// Token: 0x0600071E RID: 1822 RVA: 0x000198B6 File Offset: 0x00017AB6
		public ToolGameProperty() : base(Localizer.Localize("TOOL_GAMEPLAY_MODIFIER", null), "toolbar/gameplay/modifiers.png")
		{
			this._helpLocalisationString = Localizer.Localize("HELP_TOOL_GAMEPLAY_MODIFIER", null);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x00019A88 File Offset: 0x00017C88
		protected override IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in this._groupParams)
			{
				yield return param;
			}
			yield break;
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x00019AA5 File Offset: 0x00017CA5
		public Parameter GetMainParameter()
		{
			return null;
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x00019AA8 File Offset: 0x00017CA8
		public override string GetContextHelp()
		{
			return this._helpLocalisationString;
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x00019AB0 File Offset: 0x00017CB0
		public override void Activate()
		{
			ulong currentObjectiveType = GameModeManager.GetCurrentObjectiveType();
			if (currentObjectiveType != 0UL || this.m_currentObjectiveId != currentObjectiveType)
			{
				this._params.Clear();
				this._groupParams.Clear();
				this.m_currentObjectiveId = currentObjectiveType;
				ObjectiveType objectiveType = null;
				try
				{
					objectiveType = GameModeManager.ObjectiveTypes[this.m_currentObjectiveId];
				}
				catch
				{
					return;
				}
				GamePropertyFilter gamePropertyFilter = new GamePropertyFilter(objectiveType);
				foreach (GameProperty gameProperty in GameProperties.GamePropertyList)
				{
					if (gameProperty.PropertyType == EPropertyType.EPropertyType_Modifier && gamePropertyFilter.Validate(gameProperty))
					{
						List<Parameter> list = null;
						if (!this._params.TryGetValue(gameProperty.CategoryName, out list))
						{
							list = new List<Parameter>();
							this._params.Add(gameProperty.CategoryName, list);
							ParamGroup item = new ParamGroup(gameProperty.CategoryName, null);
							this._groupParams.Add(item);
						}
						if (gameProperty.ValueType == EPropertyValueType.EPropertyValueType_Bool)
						{
							if (gameProperty.Child != null)
							{
								list.Add(gameProperty.CreateOverrideFloat());
							}
							else
							{
								list.Add(gameProperty.CreateBool());
							}
						}
						else if (gameProperty.ValueType == EPropertyValueType.EPropertyValueType_Numeric)
						{
							list.Add(gameProperty.CreateFloat());
						}
						else if (gameProperty.ValueType == EPropertyValueType.EPropertyValueType_Preset)
						{
							list.Add(gameProperty.CreateEnumCombo());
						}
					}
				}
				foreach (string text in this._params.Keys)
				{
					List<Parameter> list2 = this._params[text];
					ParamGroup paramGroup = null;
					foreach (ParamGroup paramGroup2 in this._groupParams)
					{
						if (paramGroup2.GroupName == text)
						{
							paramGroup = paramGroup2;
							break;
						}
					}
					if (paramGroup != null)
					{
						paramGroup.Parameters = new ObservableCollection<Parameter>(list2);
					}
				}
				base.Parameters = new ObservableCollection<Parameter>(this.GetParameters());
			}
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x00019CF0 File Offset: 0x00017EF0
		public override void Deactivate()
		{
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x00019CF2 File Offset: 0x00017EF2
		public override void OnSwitchFrom(ToolBase prevTool)
		{
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x00019CF4 File Offset: 0x00017EF4
		public override void OnSwitchTo(ToolBase nextTool)
		{
		}

		// Token: 0x040002DD RID: 733
		private string _helpLocalisationString;

		// Token: 0x040002DE RID: 734
		protected List<ParamGroup> _groupParams = new List<ParamGroup>();

		// Token: 0x040002DF RID: 735
		private Dictionary<string, List<Parameter>> _params = new Dictionary<string, List<Parameter>>();

		// Token: 0x040002E0 RID: 736
		private ulong m_currentObjectiveId;
	}
}

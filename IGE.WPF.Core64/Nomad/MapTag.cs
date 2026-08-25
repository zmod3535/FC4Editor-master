using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace IGE.Nomad
{
	// Token: 0x020000BD RID: 189
	internal class MapTag
	{
		// Token: 0x0600072D RID: 1837 RVA: 0x0001A14C File Offset: 0x0001834C
		public MapTag(ulong id, string displayName, ulong objectiveId, List<ulong> modifierIds, List<ulong> gameModes, List<ulong> presetIds, bool auto, bool enumeration, bool enumDefault, uint priority)
		{
			this._id = id;
			this._displayName = displayName;
			this._objectiveId = objectiveId;
			this._modifierIds = modifierIds;
			this._gameModes = gameModes;
			this._presetIds = presetIds;
			this._auto = auto;
			this._enum = enumeration;
			this._enumDefault = enumDefault;
			this._priority = priority;
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x0001A1B7 File Offset: 0x000183B7
		public ulong Id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x0001A1BF File Offset: 0x000183BF
		public string DisplayName
		{
			get
			{
				return this._displayName;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x0001A1C8 File Offset: 0x000183C8
		public ObjectiveType Objective
		{
			get
			{
				if (this._objective == null && this._objectiveId != 0UL && GameModeManager.ObjectiveTypes.ContainsKey(this._objectiveId))
				{
					this._objective = GameModeManager.ObjectiveTypes[this._objectiveId];
				}
				return this._objective;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000731 RID: 1841 RVA: 0x0001A218 File Offset: 0x00018418
		public List<GameProperty> ModifierRefs
		{
			get
			{
				if (this._modifierIds.Count != 0 && this._modifiers.Count == 0)
				{
					foreach (GameProperty gameProperty in GameProperties.GamePropertyList)
					{
						if (this._modifierIds.Contains(gameProperty.PropertyDbId))
						{
							this._modifiers.Add(gameProperty);
						}
					}
				}
				return this._modifiers;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000732 RID: 1842 RVA: 0x0001A2A4 File Offset: 0x000184A4
		public ReadOnlyCollection<ulong> GameModes
		{
			get
			{
				return this._gameModes.AsReadOnly();
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x0001A2B1 File Offset: 0x000184B1
		public List<ulong> PresetIds
		{
			get
			{
				return this._presetIds;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x0001A2B9 File Offset: 0x000184B9
		public bool IsAuto
		{
			get
			{
				return this._auto;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000735 RID: 1845 RVA: 0x0001A2C1 File Offset: 0x000184C1
		public bool IsEnum
		{
			get
			{
				return this._enum;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x0001A2C9 File Offset: 0x000184C9
		public bool IsEnumDefault
		{
			get
			{
				return this._enumDefault;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x0001A2D1 File Offset: 0x000184D1
		public uint Priority
		{
			get
			{
				return this._priority;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000738 RID: 1848 RVA: 0x0001A2D9 File Offset: 0x000184D9
		public static MapTag NullTag
		{
			get
			{
				return MapTag._nullTag;
			}
		}

		// Token: 0x040002E9 RID: 745
		private ulong _id;

		// Token: 0x040002EA RID: 746
		private string _displayName;

		// Token: 0x040002EB RID: 747
		private ulong _objectiveId;

		// Token: 0x040002EC RID: 748
		private ObjectiveType _objective;

		// Token: 0x040002ED RID: 749
		private List<ulong> _modifierIds;

		// Token: 0x040002EE RID: 750
		private List<GameProperty> _modifiers = new List<GameProperty>();

		// Token: 0x040002EF RID: 751
		private List<ulong> _gameModes;

		// Token: 0x040002F0 RID: 752
		private List<ulong> _presetIds;

		// Token: 0x040002F1 RID: 753
		private bool _auto;

		// Token: 0x040002F2 RID: 754
		private bool _enum;

		// Token: 0x040002F3 RID: 755
		private bool _enumDefault;

		// Token: 0x040002F4 RID: 756
		private uint _priority;

		// Token: 0x040002F5 RID: 757
		private static readonly MapTag _nullTag = new MapTag(0UL, Localizer.LocalizeCommon("NOT_AVAILABLE"), 0UL, new List<ulong>(), new List<ulong>(), new List<ulong>(), false, false, false, 0U);
	}
}

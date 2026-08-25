using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using IGE.Parameters;

namespace IGE.Nomad
{
	// Token: 0x0200011C RID: 284
	internal class GameProperty
	{
		// Token: 0x060009D1 RID: 2513 RVA: 0x000208A8 File Offset: 0x0001EAA8
		public GameProperty(ulong propertyDbId, int propertyEnumId, string dispName, string categoryName, EPropertyType propertyType, EPropertyValueType propertyValueType, List<ulong> supportedObjectives, ulong childId, bool currValueBool)
		{
			this._propertyDbId = propertyDbId;
			this._propertyId = propertyEnumId;
			this._displayName = dispName;
			this._categoryName = categoryName;
			this._propertyType = propertyType;
			this._valueType = propertyValueType;
			this._supportedObjectives = supportedObjectives;
			this._childId = childId;
			this._minValue = 0f;
			this._maxValue = 1f;
			this._resolution = 1f;
			this._currentValueBool = currValueBool;
			this._currentValueNumeric = 0f;
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0002092C File Offset: 0x0001EB2C
		public GameProperty(ulong propertyDbId, int propertyEnumId, string dispName, string categoryName, EPropertyType propertyType, EPropertyValueType propertyValueType, List<ulong> supportedObjectives, ulong childId, float currValueNumeric, float minValue, float maxValue, float resolution)
		{
			this._propertyDbId = propertyDbId;
			this._propertyId = propertyEnumId;
			this._displayName = dispName;
			this._categoryName = categoryName;
			this._propertyType = propertyType;
			this._valueType = propertyValueType;
			this._supportedObjectives = supportedObjectives;
			this._childId = childId;
			this._minValue = minValue;
			this._maxValue = maxValue;
			this._resolution = resolution;
			this._currentValueBool = false;
			this._currentValueNumeric = currValueNumeric;
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x000209A4 File Offset: 0x0001EBA4
		public GameProperty(ulong propertyDbId, int propertyEnumId, string dispName, string categoryName, EPropertyType propertyType, EPropertyValueType propertyValueType, List<ulong> supportedObjectives, ulong childId, List<ulong> presetDbIds, ulong presetDefaultId)
		{
			this._propertyDbId = propertyDbId;
			this._propertyId = propertyEnumId;
			this._displayName = dispName;
			this._categoryName = categoryName;
			this._propertyType = propertyType;
			this._valueType = propertyValueType;
			this._supportedObjectives = supportedObjectives;
			this._childId = childId;
			this._minValue = 0f;
			this._maxValue = 0f;
			this._resolution = 1f;
			this._currentValueBool = false;
			this._currentValueNumeric = 0f;
			this._presetDbIds = presetDbIds;
			this._currentValuePreset = presetDefaultId;
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060009D4 RID: 2516 RVA: 0x00020A37 File Offset: 0x0001EC37
		public ulong PropertyDbId
		{
			get
			{
				return this._propertyDbId;
			}
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x060009D5 RID: 2517 RVA: 0x00020A3F File Offset: 0x0001EC3F
		public int PropertyId
		{
			get
			{
				return this._propertyId;
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x060009D6 RID: 2518 RVA: 0x00020A47 File Offset: 0x0001EC47
		public string DisplayName
		{
			get
			{
				return this._displayName;
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x060009D7 RID: 2519 RVA: 0x00020A4F File Offset: 0x0001EC4F
		public string CategoryName
		{
			get
			{
				return this._categoryName;
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x00020A57 File Offset: 0x0001EC57
		public EPropertyType PropertyType
		{
			get
			{
				return this._propertyType;
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x00020A5F File Offset: 0x0001EC5F
		public ulong ChildId
		{
			get
			{
				return this._childId;
			}
		}

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x00020A67 File Offset: 0x0001EC67
		public EPropertyValueType ValueType
		{
			get
			{
				return this._valueType;
			}
		}

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x00020A6F File Offset: 0x0001EC6F
		public ReadOnlyCollection<ulong> SupportedObjectives
		{
			get
			{
				return this._supportedObjectives.AsReadOnly();
			}
		}

		// Token: 0x17000233 RID: 563
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x00020A7C File Offset: 0x0001EC7C
		public float MinValue
		{
			get
			{
				return this._minValue;
			}
		}

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x00020A84 File Offset: 0x0001EC84
		public float MaxValue
		{
			get
			{
				return this._maxValue;
			}
		}

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060009DE RID: 2526 RVA: 0x00020A8C File Offset: 0x0001EC8C
		public float Resolution
		{
			get
			{
				return this._resolution;
			}
		}

		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060009DF RID: 2527 RVA: 0x00020A94 File Offset: 0x0001EC94
		// (set) Token: 0x060009E0 RID: 2528 RVA: 0x00020A9C File Offset: 0x0001EC9C
		public bool CurrentValueBool
		{
			get
			{
				return this._currentValueBool;
			}
			set
			{
				this._currentValueBool = value;
			}
		}

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060009E1 RID: 2529 RVA: 0x00020AA5 File Offset: 0x0001ECA5
		// (set) Token: 0x060009E2 RID: 2530 RVA: 0x00020AAD File Offset: 0x0001ECAD
		public float CurrentValueNumeric
		{
			get
			{
				return this._currentValueNumeric;
			}
			set
			{
				this._currentValueNumeric = value;
			}
		}

		// Token: 0x17000238 RID: 568
		// (get) Token: 0x060009E3 RID: 2531 RVA: 0x00020AB8 File Offset: 0x0001ECB8
		public GameProperty Child
		{
			get
			{
				if (!this._isChildSet)
				{
					this._isChildSet = true;
					if (this._childId != 0UL)
					{
						foreach (GameProperty gameProperty in GameProperties.GamePropertyList)
						{
							if (gameProperty._propertyDbId == this._childId)
							{
								this._child = gameProperty;
								break;
							}
						}
					}
				}
				return this._child;
			}
		}

		// Token: 0x17000239 RID: 569
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x00020B3C File Offset: 0x0001ED3C
		public List<ulong> PresetDbIds
		{
			get
			{
				return this._presetDbIds;
			}
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x00020B44 File Offset: 0x0001ED44
		// (set) Token: 0x060009E6 RID: 2534 RVA: 0x00020B4C File Offset: 0x0001ED4C
		public ulong CurrentValuePreset
		{
			get
			{
				return this._currentValuePreset;
			}
			set
			{
				this._currentValuePreset = value;
			}
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x00020B60 File Offset: 0x0001ED60
		public ParamBool CreateBool()
		{
			this.Param = new ParamBool(this.DisplayName, delegate(bool value)
			{
				this.CurrentValueBool = value;
			})
			{
				Value = this.CurrentValueBool
			};
			return this.Param as ParamBool;
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x00020BB8 File Offset: 0x0001EDB8
		public SingleParameter CreateFloat()
		{
			if (this.Resolution == 1f)
			{
				this.Param = new ParamInt(this.DisplayName, (int)this.MinValue, (int)this.MaxValue, delegate(int value)
				{
					this.CurrentValueNumeric = (float)value;
				})
				{
					Value = (int)this.CurrentValueNumeric
				};
			}
			else
			{
				this.Param = new ParamFloat(this.DisplayName, this.MinValue, this.MaxValue, this.Resolution, delegate(float value)
				{
					this.CurrentValueNumeric = value;
				})
				{
					Value = this.CurrentValueNumeric
				};
			}
			return this.Param as SingleParameter;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x00020C7C File Offset: 0x0001EE7C
		public ParamOverrideFloat CreateOverrideFloat()
		{
			this.Param = new ParamOverrideFloat(this.DisplayName, this.Child.MinValue, this.Child.MaxValue, this.Child.Resolution, delegate(float value)
			{
				this.Child.CurrentValueNumeric = value;
			}, delegate(bool value)
			{
				this.CurrentValueBool = value;
			})
			{
				Value = this.Child.CurrentValueNumeric,
				Override = this.CurrentValueBool
			};
			return this.Param as ParamOverrideFloat;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x00020D0C File Offset: 0x0001EF0C
		public ParamEnumCombo CreateEnumCombo()
		{
			List<ParamEnumText> list = new List<ParamEnumText>();
			foreach (ulong num in this.PresetDbIds)
			{
				uint lineId = Binding.FCE_GameProperty_GetPropertyPresetDisplayNameId(num);
				list.Add(new ParamEnumText(Localizer.LocalizeCommon(lineId), num));
			}
			this.Param = new ParamEnumCombo(this.DisplayName, list, delegate(object sender, object oldValue, object newValue)
			{
				this.CurrentValuePreset = (ulong)newValue;
			})
			{
				Value = this.CurrentValuePreset
			};
			return this.Param as ParamEnumCombo;
		}

		// Token: 0x1700023B RID: 571
		// (get) Token: 0x060009EB RID: 2539 RVA: 0x00020DC4 File Offset: 0x0001EFC4
		// (set) Token: 0x060009EC RID: 2540 RVA: 0x00020DCC File Offset: 0x0001EFCC
		public object Param { get; private set; }

		// Token: 0x040004B8 RID: 1208
		private ulong _propertyDbId;

		// Token: 0x040004B9 RID: 1209
		private int _propertyId;

		// Token: 0x040004BA RID: 1210
		private string _displayName;

		// Token: 0x040004BB RID: 1211
		private string _categoryName;

		// Token: 0x040004BC RID: 1212
		private EPropertyType _propertyType;

		// Token: 0x040004BD RID: 1213
		private ulong _childId;

		// Token: 0x040004BE RID: 1214
		private EPropertyValueType _valueType;

		// Token: 0x040004BF RID: 1215
		private List<ulong> _supportedObjectives;

		// Token: 0x040004C0 RID: 1216
		private float _minValue;

		// Token: 0x040004C1 RID: 1217
		private float _maxValue;

		// Token: 0x040004C2 RID: 1218
		private float _resolution;

		// Token: 0x040004C3 RID: 1219
		private bool _currentValueBool;

		// Token: 0x040004C4 RID: 1220
		private float _currentValueNumeric;

		// Token: 0x040004C5 RID: 1221
		private bool _isChildSet;

		// Token: 0x040004C6 RID: 1222
		private GameProperty _child;

		// Token: 0x040004C7 RID: 1223
		private List<ulong> _presetDbIds;

		// Token: 0x040004C8 RID: 1224
		private ulong _currentValuePreset;
	}
}

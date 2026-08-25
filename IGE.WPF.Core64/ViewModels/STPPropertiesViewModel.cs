using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.ViewModels
{
	// Token: 0x02000075 RID: 117
	internal class STPPropertiesViewModel : ObjectPropertiesViewModel
	{
		// Token: 0x060004B6 RID: 1206 RVA: 0x000126DC File Offset: 0x000108DC
		internal STPPropertiesViewModel(EditorObject obj) : base(obj)
		{
			this.UsedByAITypeOptions = new ObservableCollection<STPPropertiesViewModel.AITypeOption>
			{
				new STPPropertiesViewModel.AITypeOption(ObjectType.eEnemy, Localizer.LocalizeCommon("OBJ_PROPERTIES_ENEMIES")),
				new STPPropertiesViewModel.AITypeOption(ObjectType.eAlly, Localizer.LocalizeCommon("OBJ_PROPERTIES_ALLIES")),
				new STPPropertiesViewModel.AITypeOption(ObjectType.eEnemy | ObjectType.eAlly, Localizer.LocalizeCommon("OBJ_PROPERTIES_BOTH"))
			};
			this.AITypeVisibility = (obj.Entry.IsSTPAnimal ? Visibility.Collapsed : Visibility.Visible);
			int aiType;
			float num;
			float num2;
			Binding.FCE_AI_GetSTPProperties(this.selection.Pointer, out num, out num2, out aiType);
			bool flag = false;
			if (num == 0f)
			{
				num = 30f;
				flag = true;
			}
			if (num2 == 0f)
			{
				num2 = 30f;
				flag = true;
			}
			if (flag)
			{
				Binding.FCE_AI_SetSTPProperties(this.selection.Pointer, num, num2, aiType);
			}
			this.TargetedTime = (int)num;
			this.CooldownTime = (int)num2;
			this.UsedByAIType = (from x in this.UsedByAITypeOptions
			where x.Value == (ObjectType)aiType
			select x).Single<STPPropertiesViewModel.AITypeOption>();
			base.PropertyChanged += delegate(object o, PropertyChangedEventArgs e)
			{
				this.UpdateSTPProperties();
			};
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x00012822 File Offset: 0x00010A22
		private void UpdateSTPProperties()
		{
			Binding.FCE_AI_SetSTPProperties(this.selection.Pointer, (float)this.TargetedTime, (float)this.CooldownTime, (int)this.UsedByAIType.Value);
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x00012852 File Offset: 0x00010A52
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x0001285A File Offset: 0x00010A5A
		public int CooldownTime
		{
			get
			{
				return this._cooldownTime;
			}
			set
			{
				if (this._cooldownTime == value)
				{
					return;
				}
				this._cooldownTime = value;
				this.CooldownTimeText = this._cooldownTime.ToString();
				base.RaisePropertyChanged("CooldownTime");
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x00012889 File Offset: 0x00010A89
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x00012891 File Offset: 0x00010A91
		public int TargetedTime
		{
			get
			{
				return this._targetedTime;
			}
			set
			{
				if (this._targetedTime == value)
				{
					return;
				}
				this._targetedTime = value;
				this.TargetedTimeText = this._targetedTime.ToString();
				base.RaisePropertyChanged("TargetedTime");
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x000128C0 File Offset: 0x00010AC0
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x000128C8 File Offset: 0x00010AC8
		public string CooldownTimeText
		{
			get
			{
				return this._cooldownTimeText;
			}
			set
			{
				if (this._cooldownTimeText == value)
				{
					return;
				}
				int cooldownTime = this.CheckBounds(int.Parse(value));
				this._cooldownTimeText = cooldownTime.ToString();
				this.CooldownTime = cooldownTime;
				base.RaisePropertyChanged("CooldownTimeText");
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x00012910 File Offset: 0x00010B10
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x00012918 File Offset: 0x00010B18
		public string TargetedTimeText
		{
			get
			{
				return this._targetedTimeText;
			}
			set
			{
				if (this._targetedTimeText == value)
				{
					return;
				}
				int targetedTime = this.CheckBounds(int.Parse(value));
				this._targetedTimeText = targetedTime.ToString();
				this.TargetedTime = targetedTime;
				base.RaisePropertyChanged("TargetedTimeText");
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060004C0 RID: 1216 RVA: 0x00012960 File Offset: 0x00010B60
		// (set) Token: 0x060004C1 RID: 1217 RVA: 0x00012968 File Offset: 0x00010B68
		public STPPropertiesViewModel.AITypeOption UsedByAIType
		{
			get
			{
				return this._usedByAIType;
			}
			set
			{
				this._usedByAIType = value;
				base.RaisePropertyChanged("UsedByAIType");
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060004C2 RID: 1218 RVA: 0x0001297C File Offset: 0x00010B7C
		// (set) Token: 0x060004C3 RID: 1219 RVA: 0x00012984 File Offset: 0x00010B84
		public Visibility AITypeVisibility
		{
			get
			{
				return this._aiTypeVisibility;
			}
			set
			{
				this._aiTypeVisibility = value;
				base.RaisePropertyChanged("AITypeVisibility");
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x00012998 File Offset: 0x00010B98
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x000129A0 File Offset: 0x00010BA0
		public ObservableCollection<STPPropertiesViewModel.AITypeOption> UsedByAITypeOptions
		{
			get
			{
				return this._usedByAITypeOptions;
			}
			set
			{
				this._usedByAITypeOptions = value;
				base.RaisePropertyChanged("UsedByAITypeOptions");
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x000129B4 File Offset: 0x00010BB4
		// (set) Token: 0x060004C7 RID: 1223 RVA: 0x000129BC File Offset: 0x00010BBC
		public ObservableCollection<SingleParameter> Parameters
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

		// Token: 0x060004C8 RID: 1224 RVA: 0x000129D0 File Offset: 0x00010BD0
		private int CheckBounds(int value)
		{
			if (value > this.timerMax)
			{
				value = this.timerMax;
			}
			if (value < this.timerMin)
			{
				value = this.timerMin;
			}
			return value;
		}

		// Token: 0x04000212 RID: 530
		private int timerMin = 1;

		// Token: 0x04000213 RID: 531
		private int timerMax = 3600;

		// Token: 0x04000214 RID: 532
		private int _cooldownTime;

		// Token: 0x04000215 RID: 533
		private int _targetedTime;

		// Token: 0x04000216 RID: 534
		private string _cooldownTimeText;

		// Token: 0x04000217 RID: 535
		private string _targetedTimeText;

		// Token: 0x04000218 RID: 536
		private STPPropertiesViewModel.AITypeOption _usedByAIType;

		// Token: 0x04000219 RID: 537
		private Visibility _aiTypeVisibility;

		// Token: 0x0400021A RID: 538
		private ObservableCollection<STPPropertiesViewModel.AITypeOption> _usedByAITypeOptions;

		// Token: 0x0400021B RID: 539
		private ObservableCollection<SingleParameter> _parameters;

		// Token: 0x02000076 RID: 118
		internal class AITypeOption
		{
			// Token: 0x060004CA RID: 1226 RVA: 0x000129F5 File Offset: 0x00010BF5
			public AITypeOption(ObjectType value, string display)
			{
				this._value = value;
				this._display = display;
			}

			// Token: 0x170000EF RID: 239
			// (get) Token: 0x060004CB RID: 1227 RVA: 0x00012A0B File Offset: 0x00010C0B
			public string Display
			{
				get
				{
					return this._display;
				}
			}

			// Token: 0x170000F0 RID: 240
			// (get) Token: 0x060004CC RID: 1228 RVA: 0x00012A13 File Offset: 0x00010C13
			public ObjectType Value
			{
				get
				{
					return this._value;
				}
			}

			// Token: 0x0400021C RID: 540
			private string _display;

			// Token: 0x0400021D RID: 541
			private ObjectType _value;
		}
	}
}

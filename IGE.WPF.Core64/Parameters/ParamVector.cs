using System;
using IGE.Nomad;

namespace IGE.Parameters
{
	// Token: 0x020000C3 RID: 195
	internal class ParamVector : SingleParameter
	{
		// Token: 0x06000757 RID: 1879 RVA: 0x0001AA97 File Offset: 0x00018C97
		public ParamVector(string display, Vec3 value, ParamVectorUIType uiType) : base(display)
		{
			this._uiType = uiType;
			this.X = value.X;
			this.Y = value.Y;
			this.Z = value.Z;
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0001AACE File Offset: 0x00018CCE
		public ParamVector(string display, ParamVectorUIType uiType, ParamVector.ValueChangedDelegate del) : base(display)
		{
			this._value = default(Vec3);
			this._uiType = uiType;
			this.ValueChanged = (ParamVector.ValueChangedDelegate)Delegate.Combine(this.ValueChanged, del);
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x0001AB01 File Offset: 0x00018D01
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x0001AB09 File Offset: 0x00018D09
		public Vec3 Value
		{
			get
			{
				return this._value;
			}
			set
			{
				if (this._value == value)
				{
					return;
				}
				this._value = value;
				base.RaisePropertyChanged("X");
				base.RaisePropertyChanged("Y");
				base.RaisePropertyChanged("Z");
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600075B RID: 1883 RVA: 0x0001AB42 File Offset: 0x00018D42
		// (set) Token: 0x0600075C RID: 1884 RVA: 0x0001AB6C File Offset: 0x00018D6C
		public float X
		{
			get
			{
				if (this._uiType != ParamVectorUIType.Angles)
				{
					return this._value.X;
				}
				return MathUtils.Rad2Deg(this._value.X);
			}
			set
			{
				float num = (this._uiType == ParamVectorUIType.Angles) ? MathUtils.Deg2Rad(value) : value;
				if (this._value.X == num)
				{
					return;
				}
				this._value.X = num;
				base.RaisePropertyChanged("X");
				this.RaiseValueChanged();
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x0001ABB8 File Offset: 0x00018DB8
		// (set) Token: 0x0600075E RID: 1886 RVA: 0x0001ABE0 File Offset: 0x00018DE0
		public float Y
		{
			get
			{
				if (this._uiType != ParamVectorUIType.Angles)
				{
					return this._value.Y;
				}
				return MathUtils.Rad2Deg(this._value.Y);
			}
			set
			{
				float num = (this._uiType == ParamVectorUIType.Angles) ? MathUtils.Deg2Rad(value) : value;
				if (this._value.Y == num)
				{
					return;
				}
				this._value.Y = num;
				base.RaisePropertyChanged("Y");
				this.RaiseValueChanged();
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x0001AC2C File Offset: 0x00018E2C
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x0001AC54 File Offset: 0x00018E54
		public float Z
		{
			get
			{
				if (this._uiType != ParamVectorUIType.Angles)
				{
					return this._value.Z;
				}
				return MathUtils.Rad2Deg(this._value.Z);
			}
			set
			{
				float num = (this._uiType == ParamVectorUIType.Angles) ? MathUtils.Deg2Rad(value) : value;
				if (this._value.Z == num)
				{
					return;
				}
				this._value.Z = num;
				base.RaisePropertyChanged("Z");
				this.RaiseValueChanged();
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x0001ACA0 File Offset: 0x00018EA0
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x0001ACA8 File Offset: 0x00018EA8
		public ParamVector.ValueChangedDelegate ValueChanged { get; set; }

		// Token: 0x06000763 RID: 1891 RVA: 0x0001ACB4 File Offset: 0x00018EB4
		private void RaiseValueChanged()
		{
			ParamVector.ValueChangedDelegate valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged(this.Value);
			}
		}

		// Token: 0x040002FD RID: 765
		private ParamVectorUIType _uiType;

		// Token: 0x040002FE RID: 766
		private Vec3 _value;

		// Token: 0x020000C4 RID: 196
		// (Invoke) Token: 0x06000765 RID: 1893
		public delegate void ValueChangedDelegate(Vec3 value);
	}
}

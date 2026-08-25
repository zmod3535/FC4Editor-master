using System;

namespace IGE.Parameters
{
	// Token: 0x02000004 RID: 4
	internal abstract class ValueParameter<T> : SingleParameter
	{
		// Token: 0x0600000B RID: 11 RVA: 0x00002110 File Offset: 0x00000310
		protected ValueParameter(string display, ValueParameter<T>.ValueChangedDelegate evt = null) : base(display)
		{
			if (evt == null)
			{
				return;
			}
			this.ValueChanged = (ValueParameter<T>.ValueChangedDelegate)Delegate.Combine(this.ValueChanged, evt);
			this._forcePropertyChanged = true;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000213B File Offset: 0x0000033B
		protected ValueParameter(string display, T value) : base(display)
		{
			this.Value = value;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000214B File Offset: 0x0000034B
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002153 File Offset: 0x00000353
		public ValueParameter<T>.ValueChangedDelegate ValueChanged { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000215C File Offset: 0x0000035C
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002164 File Offset: 0x00000364
		public T Value
		{
			get
			{
				return this._value;
			}
			set
			{
				if ((value == null && this._value == null) || (this._value != null && value != null && this._value.Equals(value)))
				{
					if (this._forcePropertyChanged)
					{
						this.RaiseValueChanged();
						this._forcePropertyChanged = false;
					}
					return;
				}
				if (this.IsValid(value))
				{
					this._forcePropertyChanged = false;
					this._value = value;
					this.RaiseValueChanged();
				}
				base.RaisePropertyChanged("Value");
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000021F2 File Offset: 0x000003F2
		protected virtual bool IsValid(T value)
		{
			return true;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000021F8 File Offset: 0x000003F8
		private void RaiseValueChanged()
		{
			ValueParameter<T>.ValueChangedDelegate valueChanged = this.ValueChanged;
			if (valueChanged != null)
			{
				valueChanged(this.Value);
			}
		}

		// Token: 0x04000005 RID: 5
		private T _value;

		// Token: 0x04000006 RID: 6
		private bool _forcePropertyChanged;

		// Token: 0x02000005 RID: 5
		// (Invoke) Token: 0x06000014 RID: 20
		public delegate void ValueChangedDelegate(T value);
	}
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace IGE.Parameters
{
	// Token: 0x0200000D RID: 13
	internal abstract class ParamEnumBase : SingleParameter
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002584 File Offset: 0x00000784
		protected ParamEnumBase(string display, IEnumerable<ParamEnumBase.Entry> values) : base(display)
		{
			this.Values = ((values == null) ? null : new ObservableCollection<ParamEnumBase.Entry>(values));
			this.LabelVisibility = (string.IsNullOrEmpty(display) ? Visibility.Collapsed : Visibility.Visible);
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000025BF File Offset: 0x000007BF
		protected ParamEnumBase(string display, IEnumerable<ParamEnumBase.Entry> values, ParamEnumBase.ValueChangedDelegate del) : this(display, values)
		{
			this._valueChangedDelegate = (ParamEnumBase.ValueChangedDelegate)Delegate.Combine(this._valueChangedDelegate, del);
			this.LabelVisibility = (string.IsNullOrEmpty(display) ? Visibility.Collapsed : Visibility.Visible);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000025F2 File Offset: 0x000007F2
		// (set) Token: 0x06000040 RID: 64 RVA: 0x000025FA File Offset: 0x000007FA
		private ParamEnumBase.ValueChangedDelegate _valueChangedDelegate { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002603 File Offset: 0x00000803
		// (set) Token: 0x06000042 RID: 66 RVA: 0x0000260B File Offset: 0x0000080B
		public ObservableCollection<ParamEnumBase.Entry> Values
		{
			get
			{
				return this._values;
			}
			set
			{
				this._values = value;
				this._oldSelectedIndex = -1;
				this._selectedIndex = -1;
				base.RaisePropertyChanged("Values");
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000043 RID: 67 RVA: 0x0000262D File Offset: 0x0000082D
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00002635 File Offset: 0x00000835
		public int SelectedIndex
		{
			get
			{
				return this._selectedIndex;
			}
			set
			{
				if (this._selectedIndex == value)
				{
					return;
				}
				this._oldSelectedIndex = this._selectedIndex;
				this._selectedIndex = value;
				base.RaisePropertyChanged("SelectedIndex");
				this.RaiseValueChanged();
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002668 File Offset: 0x00000868
		protected virtual void RaiseValueChanged()
		{
			object oldValue = (this._oldSelectedIndex < 0) ? null : this.Values[this._oldSelectedIndex].Value;
			object newValue = (this.SelectedItem != null) ? this.SelectedItem.Value : null;
			if (this._valueChangedDelegate != null)
			{
				this._valueChangedDelegate(this, oldValue, newValue);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000026C5 File Offset: 0x000008C5
		public ParamEnumBase.Entry SelectedItem
		{
			get
			{
				if (this.SelectedIndex >= 0)
				{
					return this.Values[this.SelectedIndex];
				}
				return null;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000026E3 File Offset: 0x000008E3
		// (set) Token: 0x06000048 RID: 72 RVA: 0x000026FC File Offset: 0x000008FC
		public object Value
		{
			get
			{
				if (this.SelectedItem == null)
				{
					return null;
				}
				return this.SelectedItem.Value;
			}
			set
			{
				for (int i = 0; i < this.Values.Count; i++)
				{
					if (this.Values[i].Value.Equals(value))
					{
						this.SelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002740 File Offset: 0x00000940
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00002748 File Offset: 0x00000948
		public Visibility LabelVisibility
		{
			get
			{
				return this._labelVisibility;
			}
			set
			{
				if (this._labelVisibility == value)
				{
					return;
				}
				this._labelVisibility = value;
				base.RaisePropertyChanged("LabelVisibility");
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00002766 File Offset: 0x00000966
		public void SetEntryVisibility(int index, bool flag)
		{
			if (index >= 0 && index < this.Values.Count)
			{
				this.Values[index].EntryVisible = flag;
			}
		}

		// Token: 0x04000014 RID: 20
		private ObservableCollection<ParamEnumBase.Entry> _values;

		// Token: 0x04000015 RID: 21
		private int _oldSelectedIndex = -1;

		// Token: 0x04000016 RID: 22
		private int _selectedIndex = -1;

		// Token: 0x04000017 RID: 23
		private Visibility _labelVisibility;

		// Token: 0x0200000E RID: 14
		public abstract class Entry : Parameter
		{
			// Token: 0x0600004C RID: 76 RVA: 0x0000278C File Offset: 0x0000098C
			protected Entry(string display, object value)
			{
				this.DisplayName = display;
				this.Value = value;
				this.EntryVisible = true;
			}

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600004D RID: 77 RVA: 0x000027A9 File Offset: 0x000009A9
			// (set) Token: 0x0600004E RID: 78 RVA: 0x000027B1 File Offset: 0x000009B1
			public bool IsActive
			{
				get
				{
					return this._isActive;
				}
				set
				{
					if (this._isActive == value)
					{
						return;
					}
					this._isActive = value;
					base.RaisePropertyChanged("IsActive");
					if (this._isActive)
					{
						this.RaiseActivate();
					}
				}
			}

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x0600004F RID: 79 RVA: 0x000027DD File Offset: 0x000009DD
			// (set) Token: 0x06000050 RID: 80 RVA: 0x000027E5 File Offset: 0x000009E5
			public object Value
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
					base.RaisePropertyChanged("Value");
				}
			}

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000051 RID: 81 RVA: 0x00002803 File Offset: 0x00000A03
			// (set) Token: 0x06000052 RID: 82 RVA: 0x0000280B File Offset: 0x00000A0B
			public string DisplayName
			{
				get
				{
					return this._display;
				}
				set
				{
					if (this._display == value)
					{
						return;
					}
					this._display = value;
					base.RaisePropertyChanged("DisplayName");
				}
			}

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000053 RID: 83 RVA: 0x0000282E File Offset: 0x00000A2E
			// (set) Token: 0x06000054 RID: 84 RVA: 0x00002836 File Offset: 0x00000A36
			public bool EntryVisible
			{
				get
				{
					return this._entryVisible;
				}
				set
				{
					if (this._entryVisible == value)
					{
						return;
					}
					this._entryVisible = value;
					base.RaisePropertyChanged("EntryVisible");
				}
			}

			// Token: 0x14000002 RID: 2
			// (add) Token: 0x06000055 RID: 85 RVA: 0x00002854 File Offset: 0x00000A54
			// (remove) Token: 0x06000056 RID: 86 RVA: 0x0000288C File Offset: 0x00000A8C
			public event EventHandler Activate;

			// Token: 0x06000057 RID: 87 RVA: 0x000028C4 File Offset: 0x00000AC4
			private void RaiseActivate()
			{
				EventHandler activate = this.Activate;
				if (activate != null)
				{
					activate(this, EventArgs.Empty);
				}
			}

			// Token: 0x06000058 RID: 88 RVA: 0x000028E7 File Offset: 0x00000AE7
			public override string ToString()
			{
				return this.DisplayName;
			}

			// Token: 0x04000019 RID: 25
			private bool _isActive;

			// Token: 0x0400001A RID: 26
			private object _value;

			// Token: 0x0400001B RID: 27
			private string _display;

			// Token: 0x0400001C RID: 28
			private bool _entryVisible;
		}

		// Token: 0x0200000F RID: 15
		// (Invoke) Token: 0x0600005A RID: 90
		public delegate void ValueChangedDelegate(object sender, object oldValue, object newValue);
	}
}

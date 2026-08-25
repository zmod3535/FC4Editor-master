using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.ViewModels
{
	// Token: 0x02000081 RID: 129
	internal class AmbientPropertiesViewModel : ObjectPropertiesViewModel
	{
		// Token: 0x0600057B RID: 1403 RVA: 0x00014C9C File Offset: 0x00012E9C
		internal AmbientPropertiesViewModel(EditorObject obj) : base(obj)
		{
			this.SpawnOption = new AmbientPropertiesViewModel.AmbientSpawnOption(0, Localizer.Localize("SPAWN_OPTION_0", null));
			this.SpawnOptions = new ObservableCollection<AmbientPropertiesViewModel.AmbientSpawnOption>
			{
				this.SpawnOption,
				new AmbientPropertiesViewModel.AmbientSpawnOption(1, Localizer.Localize("SPAWN_OPTION_1", null)),
				new AmbientPropertiesViewModel.AmbientSpawnOption(2, Localizer.Localize("SPAWN_OPTION_2", null))
			};
			int num;
			Binding.FCE_AI_GetAmbientProperties(this.selection.Pointer, out num);
			base.PropertyChanged += delegate(object o, PropertyChangedEventArgs e)
			{
				this.UpdateAmbientProperties();
			};
			if (num < this.SpawnOptions.Count)
			{
				this.SpawnOption = this.SpawnOptions[num];
			}
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00014D5E File Offset: 0x00012F5E
		private void UpdateAmbientProperties()
		{
			Binding.FCE_AI_SetAmbientProperties(this.selection.Pointer, this.SpawnOption.Value);
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x00014D80 File Offset: 0x00012F80
		// (set) Token: 0x0600057E RID: 1406 RVA: 0x00014D88 File Offset: 0x00012F88
		public ObservableCollection<AmbientPropertiesViewModel.AmbientSpawnOption> SpawnOptions
		{
			get
			{
				return this._spawnOptions;
			}
			set
			{
				this._spawnOptions = value;
				base.RaisePropertyChanged("SpawnOptions");
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x00014D9C File Offset: 0x00012F9C
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x00014DA4 File Offset: 0x00012FA4
		public AmbientPropertiesViewModel.AmbientSpawnOption SpawnOption
		{
			get
			{
				return this._spawnOption;
			}
			set
			{
				this._spawnOption = value;
				base.RaisePropertyChanged("SpawnOption");
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x00014DB8 File Offset: 0x00012FB8
		// (set) Token: 0x06000582 RID: 1410 RVA: 0x00014DC0 File Offset: 0x00012FC0
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

		// Token: 0x0400024D RID: 589
		private ObservableCollection<AmbientPropertiesViewModel.AmbientSpawnOption> _spawnOptions;

		// Token: 0x0400024E RID: 590
		private AmbientPropertiesViewModel.AmbientSpawnOption _spawnOption;

		// Token: 0x0400024F RID: 591
		private ObservableCollection<SingleParameter> _parameters;

		// Token: 0x02000082 RID: 130
		internal class AmbientSpawnOption
		{
			// Token: 0x06000584 RID: 1412 RVA: 0x00014DD4 File Offset: 0x00012FD4
			public AmbientSpawnOption(int value, string display)
			{
				this._value = value;
				this._display = display;
			}

			// Token: 0x17000121 RID: 289
			// (get) Token: 0x06000585 RID: 1413 RVA: 0x00014DEA File Offset: 0x00012FEA
			public string Display
			{
				get
				{
					return this._display;
				}
			}

			// Token: 0x17000122 RID: 290
			// (get) Token: 0x06000586 RID: 1414 RVA: 0x00014DF2 File Offset: 0x00012FF2
			public int Value
			{
				get
				{
					return this._value;
				}
			}

			// Token: 0x04000250 RID: 592
			private string _display;

			// Token: 0x04000251 RID: 593
			private int _value;
		}
	}
}

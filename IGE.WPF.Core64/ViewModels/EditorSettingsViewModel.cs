using System;
using System.Collections.ObjectModel;
using System.Linq;
using IGE.Nomad;
using IGE.Parameters;
using Ubisoft;

namespace IGE.ViewModels
{
	// Token: 0x020000A0 RID: 160
	internal class EditorSettingsViewModel : ViewModel
	{
		// Token: 0x06000683 RID: 1667 RVA: 0x000177F8 File Offset: 0x000159F8
		internal EditorSettingsViewModel()
		{
			ParamBool paramAutoSnappingObjectsRotation = new ParamBool(Localizer.LocalizeCommon("SETTINGS_AUTO_SNAP_OBJECTS_ROTATION"), delegate(bool value)
			{
				EditorSettings.AutoSnappingObjectsRotation = value;
			})
			{
				Value = EditorSettings.AutoSnappingObjectsRotation
			};
			ParamEnumButton paramGridResolution = new ParamEnumButton(Localizer.LocalizeCommon("SETTINGS_SHOW_GRID_RESOLUTION"), new ParamEnumButtonText[]
			{
				new ParamEnumButtonText(16),
				new ParamEnumButtonText(32),
				new ParamEnumButtonText(64),
				new ParamEnumButtonText(128)
			}, delegate(object sender, object oldValue, object newValue)
			{
				EditorSettings.GridResolution = (int)newValue;
			})
			{
				Value = EditorSettings.GridResolution
			};
			this._showBudgetGridCallback = new Binding.EditorSettingsShowBudgetGridCallback(this.OnShowBudgetGrid);
			this._paramShowBudgetGrid = new ParamBool(Localizer.LocalizeCommon("SETTINGS_SHOW_BUDGET_GRID"), delegate(bool value)
			{
				EditorSettings.ShowBudgetGrid = value;
			})
			{
				Value = EditorSettings.ShowBudgetGrid
			};
			Binding.FCE_EditorSettings_ShowBudgetGrid_Callback(this._showBudgetGridCallback);
			ParamEnumButtonText nvidia = new ParamEnumButtonText("NVIDIA", EditorSettings.QualityLevel.Nvidia);
			ParamEnumButtonText[] array = new ParamEnumButtonText[]
			{
				new ParamEnumButtonText(Localizer.Localize("OPTIONS_CONTROLS_PC_LOW", "Video"), EditorSettings.QualityLevel.Low),
				new ParamEnumButtonText(Localizer.Localize("OPTIONS_CONTROLS_PC_MEDIUM", "Video"), EditorSettings.QualityLevel.Medium),
				new ParamEnumButtonText(Localizer.Localize("OPTIONS_CONTROLS_PC_HIGH", "Video"), EditorSettings.QualityLevel.High),
				new ParamEnumButtonText(Localizer.Localize("OPTIONS_CONTROLS_PC_VERY_HIGH", "Video"), EditorSettings.QualityLevel.VeryHigh),
				new ParamEnumButtonText(Localizer.Localize("OPTIONS_CONTROLS_PC_ULTRA", "Video"), EditorSettings.QualityLevel.UltraHigh),
				nvidia,
				new ParamEnumButtonText(Localizer.Localize("OPTIONS_CONTROLS_PC_CUSTOM", "Video"), EditorSettings.QualityLevel.Custom)
			};
			if (!EditorSettings.IsNvidia)
			{
				array = (from val in array
				where val != nvidia
				select val).ToArray<ParamEnumButtonText>();
			}
			this._paramEngineQuality = new ParamEnumCombo(Localizer.Localize("SETTINGS_ENGINE_QUALITY", null), array, delegate(object sender, object oldValue, object newValue)
			{
				EditorSettings.EngineQuality = (EditorSettings.QualityLevel)newValue;
			})
			{
				Value = EditorSettings.EngineQuality
			};
			ObservableCollection<SingleParameter> observableCollection = new ObservableCollection<SingleParameter>();
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_SHOW_FOG"), delegate(bool value)
			{
				EditorSettings.ShowFog = value;
			})
			{
				Value = EditorSettings.ShowFog
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_SHOW_SHADOWS"), delegate(bool value)
			{
				EditorSettings.ShowShadow = value;
			})
			{
				Value = EditorSettings.ShowShadow
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_SHOW_WATER"), delegate(bool value)
			{
				EditorSettings.ShowWater = value;
			})
			{
				Value = EditorSettings.ShowWater
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_SHOW_COLLECTIONS"), delegate(bool value)
			{
				EditorSettings.ShowCollections = value;
			})
			{
				Value = EditorSettings.ShowCollections
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_SHOW_ICONS"), delegate(bool value)
			{
				EditorSettings.ShowIcons = value;
			})
			{
				Value = EditorSettings.ShowIcons
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_ENABLE_SOUND"), delegate(bool value)
			{
				EditorSettings.SoundEnabled = value;
			})
			{
				Value = EditorSettings.SoundEnabled
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_SHOW_GRID"), delegate(bool value)
			{
				EditorSettings.ShowGrid = value;
				paramGridResolution.Enabled = value;
			})
			{
				Value = EditorSettings.ShowGrid
			});
			observableCollection.Add(paramGridResolution);
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_SHOW_OCCLUSION"), delegate(bool value)
			{
				EditorSettings.IsOcclusionVisible = value;
			})
			{
				Value = EditorSettings.IsOcclusionVisible
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_INVINCIBILITY"), delegate(bool value)
			{
				EditorSettings.Invincible = value;
			})
			{
				Value = EditorSettings.Invincible
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_INVISIBILITY"), delegate(bool value)
			{
				EditorSettings.Invisible = value;
			})
			{
				Value = EditorSettings.Invisible
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_SNAP_TO_TERRAIN"), delegate(bool value)
			{
				EditorSettings.SnapObjectsToTerrain = value;
			})
			{
				Value = EditorSettings.SnapObjectsToTerrain
			});
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_AUTO_SNAP_OBJECTS"), delegate(bool value)
			{
				EditorSettings.AutoSnappingObjects = value;
				paramAutoSnappingObjectsRotation.Enabled = value;
			})
			{
				Value = EditorSettings.AutoSnappingObjects
			});
			observableCollection.Add(paramAutoSnappingObjectsRotation);
			observableCollection.Add(this._paramShowBudgetGrid);
			observableCollection.Add(new ParamBool(Localizer.LocalizeCommon("SETTINGS_AUTO_SNAP_OBJECTS_TERRAIN"), delegate(bool value)
			{
				EditorSettings.AutoSnappingObjectsTerrain = value;
			})
			{
				Value = EditorSettings.AutoSnappingObjectsTerrain
			});
			observableCollection.Add(new ParamBool(Localizer.Localize("SETTINGS_INVERT_MOUSE_VIEW", null), delegate(bool value)
			{
				EditorSettings.InvertMouseView = value;
			})
			{
				Value = EditorSettings.InvertMouseView
			});
			observableCollection.Add(new ParamBool(Localizer.Localize("SETTINGS_INVERT_MOUSE_PAN", null), delegate(bool value)
			{
				EditorSettings.InvertMousePan = value;
			})
			{
				Value = EditorSettings.InvertMousePan
			});
			observableCollection.Add(this._paramEngineQuality);
			observableCollection.Add(new ParamBool(Localizer.Localize("SETTINGS_KILL_DISTANCE_OVERRIDE", null), delegate(bool value)
			{
				EditorSettings.KillDistanceOverride = value;
			})
			{
				Value = EditorSettings.KillDistanceOverride
			});
			this.Parameters = observableCollection;
			Program.ExitedInGame += this.Program_ExitedInGame;
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00017F08 File Offset: 0x00016108
		// (set) Token: 0x06000685 RID: 1669 RVA: 0x00017F10 File Offset: 0x00016110
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

		// Token: 0x06000686 RID: 1670 RVA: 0x00017F24 File Offset: 0x00016124
		private void OnShowBudgetGrid(bool show)
		{
			this._paramShowBudgetGrid.Value = show;
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00017F32 File Offset: 0x00016132
		private void Program_ExitedInGame(object sender, EventArgs e)
		{
			this._paramEngineQuality.Value = EditorSettings.EngineQuality;
		}

		// Token: 0x04000290 RID: 656
		private ParamBool _paramShowBudgetGrid;

		// Token: 0x04000291 RID: 657
		private Binding.EditorSettingsShowBudgetGridCallback _showBudgetGridCallback;

		// Token: 0x04000292 RID: 658
		private ParamEnumCombo _paramEngineQuality;

		// Token: 0x04000293 RID: 659
		private ObservableCollection<SingleParameter> _parameters;
	}
}

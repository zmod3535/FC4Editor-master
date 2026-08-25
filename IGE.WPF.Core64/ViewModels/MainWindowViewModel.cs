using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Divelements.SandDock;
using IGE.Controls;
using IGE.Helpers;
using IGE.Nomad;
using IGE.Tools;
using IGE.UI;
using IGE.Views;
using Ubisoft;
using Ubisoft.ApplicationModel.ContextCommands;

namespace IGE.ViewModels
{
	// Token: 0x0200002D RID: 45
	internal class MainWindowViewModel : ViewModel, IInputSink
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00003BF2 File Offset: 0x00001DF2
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00003BFA File Offset: 0x00001DFA
		public ObservableCollection<object> ToolsMain
		{
			get
			{
				return this._toolsMain;
			}
			private set
			{
				this._toolsMain = value;
				base.RaisePropertyChanged("ToolsMain");
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00003C0E File Offset: 0x00001E0E
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00003C16 File Offset: 0x00001E16
		public ObservableCollection<ToolBase> ToolsTerrain
		{
			get
			{
				return this._toolsTerrain;
			}
			private set
			{
				this._toolsTerrain = value;
				base.RaisePropertyChanged("ToolsTerrain");
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00003C2A File Offset: 0x00001E2A
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00003C32 File Offset: 0x00001E32
		public ObservableCollection<object> ToolsObjects
		{
			get
			{
				return this._toolsObjects;
			}
			private set
			{
				this._toolsObjects = value;
				base.RaisePropertyChanged("ToolsObjects");
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00003C46 File Offset: 0x00001E46
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00003C4E File Offset: 0x00001E4E
		public ObservableCollection<ToolBase> ToolsMap
		{
			get
			{
				return this._toolsMap;
			}
			private set
			{
				this._toolsMap = value;
				base.RaisePropertyChanged("ToolsMap");
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00003C62 File Offset: 0x00001E62
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00003C6C File Offset: 0x00001E6C
		public Tool ActiveTool
		{
			get
			{
				return this._activeTool;
			}
			set
			{
				if (this._activeTool == value)
				{
					return;
				}
				if (this._activeTool != null)
				{
					this._activeTool.IsActive = false;
					this._activeTool.Deactivate();
					this._activeTool.OnSwitchTo(value);
					if (this._activeTool is IInputSink)
					{
						Editor.PopInput((IInputSink)this._activeTool);
					}
				}
				Tool activeTool = this._activeTool;
				this._activeTool = value;
				base.RaisePropertyChanged("ActiveTool");
				if (this._activeTool != null)
				{
					if (this._activeTool is IInputSink)
					{
						Editor.PushInput((IInputSink)this._activeTool);
					}
					this._activeTool.Activate();
					if (this._activeTool != null)
					{
						this._activeTool.OnSwitchFrom(activeTool);
					}
				}
				this.UpdateCurrentTool();
			}
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00003EA4 File Offset: 0x000020A4
		private void CreateTools()
		{
			this._toolProperties = new ToolProperties();
			this._toolProperties.OnMapModeChange = new ToolProperties.MapModeChange(this.EditMapMode);
			this._toolValidation = new ToolValidation();
			this._toolValidation.RequestWaveTool1 = delegate()
			{
				this.ToggleObjectToolMode(this._spawnerToggle);
				this._toolObject.ToolSpawnerMode.SetWave(1);
			};
			this._toolValidation.RequestWaveTool2 = delegate()
			{
				this.ToggleObjectToolMode(this._spawnerToggle);
				this._toolObject.ToolSpawnerMode.SetWave(2);
			};
			this._toolValidation.RequestAddToolGameplayObjects = delegate()
			{
				this.ToggleObjectToolMode(this._addToggle);
				this._toolObject.ToolAddMode.Category = ToolObject.AddMode.CategoryIDs.CAT_GAMEPLAYOBJECTS;
			};
			this._toolValidation.RequestToolProperties = delegate()
			{
				this.ActivateTool(this._toolProperties);
			};
			this._toolGameProp = new ToolGameProperty
			{
				Shortcut = Key.M
			};
			this._toolEnv = new ToolEnvironment
			{
				Shortcut = Key.D8
			};
			this._toolPlayableZone = new ToolPlayableZone
			{
				Shortcut = Key.D9
			};
			this._toolBump = new ToolTerrainBump
			{
				Shortcut = Key.F1
			};
			this._toolRaise = new ToolTerrainRaiseLower
			{
				Shortcut = Key.F2
			};
			this._toolFlatten = new ToolTerrainFlatten
			{
				Shortcut = Key.F3
			};
			this._toolRamp = new ToolTerrainRamp
			{
				Shortcut = Key.F4
			};
			this._toolSet2Height = new ToolTerrainSetHeight
			{
				Shortcut = Key.F5
			};
			this._toolSmooth = new ToolTerrainSmooth
			{
				Shortcut = Key.F6
			};
			this._toolNoise = new ToolTerrainNoise
			{
				Shortcut = Key.F7
			};
			this._toolErosion = new ToolTerrainErosion
			{
				Shortcut = Key.F8
			};
			this._toolHole = new ToolTerrainHole
			{
				Shortcut = Key.F9
			};
			this._toolWaterLayer = new ToolWater
			{
				Shortcut = Key.F10
			};
			this._toolTexture = new ToolTexture
			{
				Shortcut = Key.F11
			};
			this._toolCollection = new ToolCollection
			{
				Shortcut = Key.D0
			};
			this._toolRoads = new ToolRoad
			{
				Shortcut = Key.OemMinus
			};
			this._toolObject = new ToolObject();
			this._selectToggle = new ToolObjectModeToggle(Localizer.Localize("TOOL_OBJECT_MODE_SELECT", null), "tools/objects/Tool_Select.png", this._toolObject, this._toolObject.ToolSelectMode, delegate()
			{
				this.ToggleObjectToolMode(this._selectToggle);
				this._toolObject.SwitchMode(this._toolObject.ToolSelectMode);
			})
			{
				Shortcut = Key.D1
			};
			this._moveToggle = new ToolObjectModeToggle(Localizer.Localize("TOOL_OBJECT_MODE_MOVE", null), "tools/objects/Tool_Move.png", this._toolObject, this._toolObject.ToolMoveMode, delegate()
			{
				this.ToggleObjectToolMode(this._moveToggle);
				this._toolObject.SwitchMode(this._toolObject.ToolMoveMode);
			})
			{
				Shortcut = Key.D2
			};
			this._rotateToggle = new ToolObjectModeToggle(Localizer.Localize("TOOL_OBJECT_MODE_ROTATE", null), "tools/objects/Tool_Rotate.png", this._toolObject, this._toolObject.ToolRotateMode, delegate()
			{
				this.ToggleObjectToolMode(this._rotateToggle);
				this._toolObject.SwitchMode(this._toolObject.ToolRotateMode);
			})
			{
				Shortcut = Key.D3
			};
			this._snapToggle = new ToolObjectModeToggle(Localizer.Localize("TOOL_OBJECT_MODE_SNAP", null), "tools/objects/Tool_Link.png", this._toolObject, this._toolObject.ToolSnapMode, delegate()
			{
				this.ToggleObjectToolMode(this._snapToggle);
				this._toolObject.SwitchMode(this._toolObject.ToolSnapMode);
			})
			{
				Shortcut = Key.D4
			};
			this._addToggle = new ToolObjectModeToggle(Localizer.Localize("TOOL_OBJECT_MODE_ADD", null), "tools/objects/Object_Add.png", this._toolObject, this._toolObject.ToolAddMode, delegate()
			{
				this.ToggleObjectToolMode(this._addToggle);
				this._toolObject.SwitchMode(this._toolObject.ToolAddMode);
			})
			{
				Shortcut = Key.D5
			};
			this._spawnerToggle = new ToolObjectModeToggle(Localizer.LocalizeCommon("TOOL_OBJECT_MODE_SPAWNER"), "tools/objects/Tool_Spawners.png", this._toolObject, this._toolObject.ToolSpawnerMode, delegate()
			{
				this.ToggleObjectToolMode(this._spawnerToggle);
				this._toolObject.SwitchMode(this._toolObject.ToolSpawnerMode);
				this.SetUpBudgetsWindow();
			})
			{
				Shortcut = Key.D6
			};
			this._toolNavmesh = new ToolNavmesh
			{
				Shortcut = Key.D7
			};
			this.ToolsMain = new ObservableCollection<object>
			{
				new SimpleToolbarButton("toolbar/main/NewDocumentHS.png", Localizer.LocalizeNoUnderscore("MENUITEM_FILE_NEW_MAP", null), this.NewMapCommand),
				new SimpleToolbarButton("toolbar/main/openHS.png", Localizer.LocalizeNoUnderscore("MENUITEM_FILE_LOAD_MAP", null), this.LoadMapCommand),
				new SimpleToolbarButton("toolbar/main/saveHS.png", Localizer.LocalizeNoUnderscore("MENUITEM_FILE_SAVE_MAP", null), this.SaveMapCommand),
				new Separator(),
				new SimpleToolbarButton("toolbar/main/Edit_UndoHS.png", Localizer.LocalizeNoUnderscore("MENUITEM_EDIT_UNDO", null), this.UndoCommand),
				new SimpleToolbarButton("toolbar/main/Edit_RedoHS.png", Localizer.LocalizeNoUnderscore("MENUITEM_EDIT_REDO", null), this.RedoCommand),
				new Separator(),
				new SimpleToolbarButton("toolbar/main/play_icon.png", Localizer.LocalizeNoUnderscore("MENUITEM_GAME_PLAY_INGAME", null), this.PlayIngameCommand),
				new Separator(),
				this._toolValidation,
				this._toolProperties,
				this._toolGameProp
			};
			this.ToolsMap = new ObservableCollection<ToolBase>
			{
				this._toolPlayableZone,
				this._toolEnv
			};
			this.ToolsTerrain = new ObservableCollection<ToolBase>
			{
				this._toolBump,
				this._toolRaise,
				this._toolFlatten,
				this._toolRamp,
				this._toolSet2Height,
				this._toolSmooth,
				this._toolNoise,
				this._toolErosion,
				this._toolHole,
				this._toolWaterLayer,
				this._toolTexture,
				this._toolCollection,
				this._toolRoads
			};
			this.ToolsObjects = new ObservableCollection<object>
			{
				this._selectToggle,
				this._moveToggle,
				this._rotateToggle,
				this._snapToggle,
				this._addToggle,
				new Separator(),
				this._spawnerToggle,
				this._toolNavmesh
			};
			List<object> list = new List<object>();
			list.AddRange(this.ToolsMain);
			list.AddRange(this.ToolsMap);
			list.AddRange(this.ToolsTerrain);
			list.AddRange(this.ToolsObjects);
			foreach (object obj in list)
			{
				ToolBase toolBase = obj as ToolBase;
				if (toolBase != null)
				{
					if (toolBase.Shortcut != Key.None)
					{
						this._toolShortcuts[toolBase.Shortcut] = toolBase;
					}
					Tool tool = obj as Tool;
					ToolObjectModeToggle toolObjectModeToggle = obj as ToolObjectModeToggle;
					if (tool != null || toolObjectModeToggle != null)
					{
						if (toolObjectModeToggle != null)
						{
							this._toolObjectModes.Add(toolObjectModeToggle);
							toolObjectModeToggle.Parent = this;
							toolObjectModeToggle.Initialize();
							toolObjectModeToggle.ActivateEvent += delegate(object s, EventArgs ea)
							{
								this.ToggleObjectToolMode((Tool)s);
							};
						}
						else if (tool != null)
						{
							this._tools.Add(tool);
							tool.Parent = this;
							tool.Initialize();
							tool.ActivateEvent += delegate(object s, EventArgs ea)
							{
								this.ActivateTool((Tool)s);
							};
						}
					}
				}
			}
			this._tools.Add(this._toolObject);
			this._toolObject.Parent = this;
			this._toolObject.HeaderVisible = Visibility.Collapsed;
			this._toolObject.Initialize();
			this._toolObject.ActivateEvent += delegate(object s, EventArgs ea)
			{
				this.ActivateTool((Tool)s);
			};
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00004674 File Offset: 0x00002874
		public void ActivateTool(Tool tool)
		{
			if (!Program.MainWin.DockToolParameters.IsVisible)
			{
				Program.MainWin.DockToolParameters.Open();
			}
			if (this.ActiveTool != tool)
			{
				if (this.ActiveTool != null)
				{
					this.ActiveTool.IsActive = false;
					if (this.ActiveTool == this._toolObject)
					{
						foreach (Tool tool2 in this._toolObjectModes)
						{
							tool2.IsActive = false;
						}
					}
				}
				tool.IsActive = true;
				this.ActiveTool = tool;
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00004724 File Offset: 0x00002924
		public void ToggleObjectToolMode(Tool tool)
		{
			this.ActivateTool(this._toolObject);
			if (this._activeToolObjectMode != tool)
			{
				if (tool != null && !Program.MainWin.DockToolParameters.IsVisible)
				{
					Program.MainWin.DockToolParameters.Open();
				}
				if (this._activeToolObjectMode != null)
				{
					this._activeToolObjectMode.IsActive = false;
				}
				this._activeToolObjectMode = tool;
				tool.IsActive = true;
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000478C File Offset: 0x0000298C
		public MainWindowViewModel()
		{
			this.NoInit = false;
			this.Loaded = false;
			this._hourglass = "hourglass.png".GetImageSource();
			this.CreateCommands();
			CameraSpeedItem cameraSpeedItem = new CameraSpeedItem(16f, false);
			this.CameraSpeed = new ObservableCollection<CameraSpeedItem>
			{
				new CameraSpeedItem(2f, false),
				new CameraSpeedItem(4f, false),
				new CameraSpeedItem(8f, false),
				cameraSpeedItem,
				new CameraSpeedItem(32f, false),
				new CameraSpeedItem(64f, false),
				new CameraSpeedItem(-1f, true)
			};
			this.CurrentSpeed = cameraSpeedItem;
			this._shortcutCommands = new Dictionary<MainWindowViewModel.ShortKey, ICommand>
			{
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.N),
					this.NewMapCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.O),
					this.LoadMapCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.S),
					this.SaveMapCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control | ModifierKeys.Shift, Key.S),
					this.SaveMapAsCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.Q),
					this.CloseCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.Z),
					this.UndoCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control | ModifierKeys.Shift, Key.Z),
					this.RedoCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.C),
					this.CopyCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.V),
					this.PasteCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.E),
					this.ExploreIngameCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.P),
					this.PlayIngameCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.None, Key.Up),
					this.CameraSpeedUpCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.None, Key.Down),
					this.CameraSpeedDownCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.None, Key.N),
					this.ToggleNavmeshCommand
				},
				{
					new MainWindowViewModel.ShortKey(ModifierKeys.Control, Key.J),
					this.CreateIssueCommand
				}
			};
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000145 RID: 325 RVA: 0x000049BC File Offset: 0x00002BBC
		// (set) Token: 0x06000146 RID: 326 RVA: 0x000049C4 File Offset: 0x00002BC4
		public CameraSpeedItem CurrentSpeed
		{
			get
			{
				return this._currentSpeed;
			}
			set
			{
				this._currentSpeed = value;
				if (Editor.IsActive)
				{
					Camera.Speed = value.Value;
				}
				base.RaisePropertyChanged("CurrentSpeed");
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000147 RID: 327 RVA: 0x000049EA File Offset: 0x00002BEA
		// (set) Token: 0x06000148 RID: 328 RVA: 0x000049F2 File Offset: 0x00002BF2
		public ObservableCollection<CameraSpeedItem> CameraSpeed
		{
			get
			{
				return this._cameraSpeed;
			}
			set
			{
				this._cameraSpeed = value;
				base.RaisePropertyChanged("CameraSpeed");
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00004A08 File Offset: 0x00002C08
		public bool SelectCustomCameraSpeed(object cameraSpeed)
		{
			CameraSpeedItem cameraSpeedItem = cameraSpeed as CameraSpeedItem;
			bool flag = true;
			if (cameraSpeedItem.Custom)
			{
				Prompt prompt = new Prompt(Localizer.Localize("EDITOR_CAMERA_SPEED_PROMPT", null), Localizer.Localize("EDITOR_CAMERA_SPEED_PROMPT_TITLE", null))
				{
					Owner = Program.MainWin,
					Validation = Prompt.GetFloatValidation(0.001f, 64f)
				};
				if (prompt.ShowDialog() == true)
				{
					cameraSpeedItem.Value = float.Parse(prompt.Input);
				}
				else
				{
					flag = false;
				}
			}
			if (flag)
			{
				this.CurrentSpeed = cameraSpeedItem;
			}
			return cameraSpeedItem.Custom && flag;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00004AAC File Offset: 0x00002CAC
		private bool PromptSave(EditorDocument.SaveCompletedCallback callback)
		{
			MessageBoxResult messageBoxResult = MessageBox.Show(Program.MainWin, Localizer.Localize("EDITOR_CHANGE_MAP_PROMPT", null), Localizer.Localize("EDITOR_CONFIRMATION", null), MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);
			MessageBoxResult messageBoxResult2 = messageBoxResult;
			if (messageBoxResult2 == MessageBoxResult.Cancel)
			{
				return false;
			}
			switch (messageBoxResult2)
			{
			case MessageBoxResult.Yes:
				this.SaveMap(false, true, callback);
				return false;
			case MessageBoxResult.No:
				return true;
			default:
				return false;
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00004B12 File Offset: 0x00002D12
		private bool NewMap()
		{
			if (!this.PromptSave(delegate(bool success)
			{
				if (success)
				{
					this.NewMapInternal();
				}
			}))
			{
				return false;
			}
			this.NewMapInternal();
			return true;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00004B34 File Offset: 0x00002D34
		private bool NewMapInternal()
		{
			this._toolObject.SetNoGameplayClipboard(true);
			NewMapDialog newMapDialog = new NewMapDialog();
			newMapDialog.ShowDialog();
			if (newMapDialog.DialogResult != true)
			{
				return false;
			}
			Binding.FCE_WaitScreen_Show(Localizer.LocalizeCommon("UPDATESCREEN_GENERATING_WILDERNESS"), true, false, true);
			Binding.FCE_GameModeManager_ClearObjectiveSettings();
			GameProperties.PullFromGameModeManager();
			this.ActiveTool = null;
			EditorDocument.Reset();
			this.InitNewMap(newMapDialog.SelectedObjective, newMapDialog.SelectedTerrain);
			this._isDownloadedMap = false;
			this._documentPath = null;
			this.UpdateTitleBar();
			this.EditorSettings = new EditorSettingsViewModel();
			this.ObjectProperties = new NoPropertiesViewModel(null);
			this.Budgets = new BudgetsViewModel();
			Binding.FCE_WaitScreen_Hide();
			this.ToggleObjectToolMode(this._selectToggle);
			return true;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00004C0C File Offset: 0x00002E0C
		private void UpdateToolsForMode(UpdateModeSource updateSource = UpdateModeSource.Default)
		{
			GameModeManager.EMapObjective enumObjectiveType = GameModeManager.GetEnumObjectiveType();
			if (enumObjectiveType == GameModeManager.EMapObjective.EMapObjective_Poacher)
			{
				this._spawnerToggle.UpdateIcon("tools/objects/AI_animal.png");
			}
			else
			{
				this._spawnerToggle.UpdateIcon("tools/objects/Tool_Spawners.png");
			}
			this._toolObject.UpdateForMode(updateSource);
			this.UpdateTitleBar();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00004C57 File Offset: 0x00002E57
		private void NewMapPostLoad(ulong objectiveId, ulong terrainId)
		{
			Binding.FCE_WaitScreen_Show(Localizer.LocalizeCommon("UPDATESCREEN_GENERATING_WILDERNESS"), true, false, true);
			this.InitNewMap(objectiveId, terrainId);
			this._documentPath = null;
			Binding.FCE_WaitScreen_Hide();
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00004C8C File Offset: 0x00002E8C
		private void InitNewMap(ulong objectiveId, ulong terrainId)
		{
			EditorDocument.CreatorName = Marshal.PtrToStringUni(Binding.FCE_Online_GetUplayUserName());
			string scriptName = "ingameeditor\\wilderness\\empty.lua";
			if (WildernessInventory.Instance.Entries.ContainsKey(terrainId))
			{
				scriptName = WildernessInventory.Instance.Entries[terrainId].ScriptFilename;
			}
			Wilderness.RunScript(scriptName);
			GameModeManager.SetCurrentObjectiveType(objectiveId);
			this.MapPostLoad();
			this.UpdateToolsForMode(UpdateModeSource.Default);
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00004D01 File Offset: 0x00002F01
		private void LoadMap(string fileName)
		{
			if (!this.PromptSave(delegate(bool success)
			{
				if (success)
				{
					this.LoadMapInternal(null);
				}
			}))
			{
				return;
			}
			this.LoadMapInternal(fileName);
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00004D48 File Offset: 0x00002F48
		private bool LoadMapInternal(string fileName)
		{
			if (fileName == null)
			{
				OpenDialog openDialog = new OpenDialog();
				openDialog.ShowDialog();
				if (openDialog.DialogResult != true)
				{
					return false;
				}
				fileName = (openDialog.IsDownloadedMap ? StorageUtils.GetFullDownloadedMapPath(openDialog.FileName) : StorageUtils.GetFullUserMapPath(openDialog.FileName));
				this._isDownloadedMap = openDialog.IsDownloadedMap;
			}
			this._documentPath = fileName;
			this.ActiveTool = null;
			EditorDocument.Load(this._documentPath, delegate(bool success)
			{
				this.EditorSettings = new EditorSettingsViewModel();
				this.ObjectProperties = null;
				this.Budgets = new BudgetsViewModel();
				this.UpdateToolsForMode(UpdateModeSource.MapLoad);
			});
			EditorDocument.NavmeshEnabled = true;
			this.UpdateTitleBar();
			this.MapPostLoad();
			this.ToggleObjectToolMode(this._selectToggle);
			return true;
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00004DFC File Offset: 0x00002FFC
		private bool SaveMap(bool saveAs, bool silent, EditorDocument.SaveCompletedCallback callback)
		{
			if (!EditorDocument.CheckValidation(true, false))
			{
				if (MessageBox.Show(Program.MainWin, Localizer.Localize("ERROR_VALIDATION_FAILED", null), Localizer.Localize("ERROR", null), MessageBoxButton.YesNo, MessageBoxImage.Hand) == MessageBoxResult.No)
				{
					return false;
				}
			}
			else
			{
				if (!Binding.FCE_Navmesh_IsReady())
				{
					Binding.FCE_WaitScreen_Show(Localizer.LocalizeCommon(57536U), true, true, true);
					Binding.FCE_Navmesh_Sync(-1);
					Binding.FCE_WaitScreen_Hide();
				}
				if (!EditorDocument.CheckValidation(false, true) && MessageBox.Show(Program.MainWin, Localizer.Localize("ERROR_VALIDATION_FAILED", null), Localizer.Localize("ERROR", null), MessageBoxButton.YesNo, MessageBoxImage.Hand) == MessageBoxResult.No)
				{
					return false;
				}
			}
			if (this._isDownloadedMap && !saveAs)
			{
				MessageBox.Show(Program.MainWin, Localizer.Localize("DOWNLOADED_MAP_PROMPT", null), Localizer.Localize("EDITOR_NAME", null), MessageBoxButton.OK, MessageBoxImage.Asterisk);
			}
			if (this.ActiveTool == this._toolValidation)
			{
				this.ActiveTool = null;
			}
			string documentPath = this._documentPath;
			if (saveAs || this._documentPath == null || (this._isDownloadedMap && !saveAs))
			{
				SaveAsDialog saveAsDialog = new SaveAsDialog();
				saveAsDialog.MapName = (string.IsNullOrEmpty(EditorDocument.MapName) ? string.Empty : EditorDocument.MapName);
				saveAsDialog.ShowDialog();
				if (saveAsDialog.DialogResult != true)
				{
					return false;
				}
				documentPath = StorageUtils.GetFullUserMapPath(saveAsDialog.MapName);
				EditorDocument.MapName = saveAsDialog.MapName;
			}
			this._toolProperties.SaveTags();
			if (saveAs)
			{
				EditorDocument.MapId = Guid.NewGuid();
			}
			this._documentPath = documentPath;
			this._isDownloadedMap = false;
			if (File.Exists(this._documentPath) && !this.CanWriteToFile(this._documentPath))
			{
				MessageBox.Show(Program.MainWin, Localizer.LocalizeCommon(353757U), Localizer.LocalizeCommon(347972U), MessageBoxButton.OK, MessageBoxImage.Hand);
				return false;
			}
			EditorDocument.Save(this._documentPath, callback);
			this.UpdateTitleBar();
			if (this.ActiveTool != null)
			{
				this.ActiveTool.Refresh();
			}
			return true;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00004FF4 File Offset: 0x000031F4
		private bool CanWriteToFile(string filePath)
		{
			FileSecurity accessControl = File.GetAccessControl(filePath);
			bool flag;
			if (accessControl == null)
			{
				flag = false;
			}
			else
			{
				AuthorizationRuleCollection accessRules = accessControl.GetAccessRules(true, true, typeof(SecurityIdentifier));
				if (accessRules == null)
				{
					flag = false;
				}
				else
				{
					WindowsPrincipal windowsPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
					bool flag2 = false;
					bool flag3 = false;
					bool flag4 = false;
					bool flag5 = false;
					foreach (object obj in accessRules)
					{
						FileSystemAccessRule fileSystemAccessRule = (FileSystemAccessRule)obj;
						if (fileSystemAccessRule.IdentityReference.Value.StartsWith("S-1-"))
						{
							SecurityIdentifier sid = new SecurityIdentifier(fileSystemAccessRule.IdentityReference.Value);
							if (!windowsPrincipal.IsInRole(sid))
							{
								continue;
							}
						}
						else if (!windowsPrincipal.IsInRole(fileSystemAccessRule.IdentityReference.Value))
						{
							continue;
						}
						if ((FileSystemRights.Write & fileSystemAccessRule.FileSystemRights) == FileSystemRights.Write)
						{
							if (fileSystemAccessRule.AccessControlType == AccessControlType.Allow)
							{
								flag2 = true;
							}
							else if (fileSystemAccessRule.AccessControlType == AccessControlType.Deny)
							{
								flag3 = true;
							}
						}
						if ((FileSystemRights.WriteAttributes & fileSystemAccessRule.FileSystemRights) == FileSystemRights.WriteAttributes)
						{
							if (fileSystemAccessRule.AccessControlType == AccessControlType.Allow)
							{
								flag4 = true;
							}
							else if (fileSystemAccessRule.AccessControlType == AccessControlType.Deny)
							{
								flag5 = true;
							}
						}
					}
					flag = (flag2 && !flag3 && flag4 && !flag5);
					if (flag)
					{
						FileAttributes fileAttributes = File.GetAttributes(filePath);
						if ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
						{
							fileAttributes &= ~FileAttributes.ReadOnly;
							File.SetAttributes(filePath, fileAttributes);
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000517C File Offset: 0x0000337C
		private void ExportMap(bool bigEndian)
		{
			OpenDialog openDialog = new OpenDialog();
			openDialog.ShowDialog();
			if (openDialog.DialogResult != true)
			{
				return;
			}
			SaveAsDialog saveAsDialog = new SaveAsDialog
			{
				ForUserData = false
			};
			saveAsDialog.ShowDialog();
			if (saveAsDialog.DialogResult != true)
			{
				return;
			}
			string mapFile = openDialog.IsDownloadedMap ? StorageUtils.GetFullDownloadedMapPath(openDialog.FileName) : StorageUtils.GetFullUserMapPath(openDialog.FileName);
			string fullMapPathForConsole = StorageUtils.GetFullMapPathForConsole(saveAsDialog.MapName);
			EditorDocument.Export(mapFile, fullMapPathForConsole, bigEndian);
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00005228 File Offset: 0x00003428
		private void RenameMap()
		{
			if (string.IsNullOrEmpty(EditorDocument.MapName) || EditorDocument.MapName == EditorDocument.DefaultMapName)
			{
				this.SaveMap(true, false, null);
				return;
			}
			SaveAsDialog saveAsDialog = new SaveAsDialog();
			saveAsDialog.MapName = EditorDocument.MapName;
			saveAsDialog.Title = Localizer.Localize("MP_ClassCustom_Rename", "ClassCustomization");
			saveAsDialog.RenameMode = true;
			saveAsDialog.ShowDialog();
			if (saveAsDialog.DialogResult != true)
			{
				return;
			}
			string fullUserMapPath = StorageUtils.GetFullUserMapPath(saveAsDialog.MapName);
			if (!string.IsNullOrEmpty(this._documentPath))
			{
				try
				{
					File.Move(this._documentPath, fullUserMapPath);
				}
				catch (IOException)
				{
					MessageBox.Show(Localizer.Localize("MSG_DESC_SAVE_ERROR", "InGameEditor"), Localizer.Localize("ERROR", null), MessageBoxButton.OK, MessageBoxImage.Hand);
					return;
				}
			}
			EditorDocument.MapName = saveAsDialog.MapName;
			EditorDocument.MapId = Guid.NewGuid();
			this._documentPath = fullUserMapPath;
			this.UpdateTitleBar();
			EditorDocument.Save(this._documentPath, null);
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000533C File Offset: 0x0000353C
		private void PublishMap()
		{
			if (!EditorDocument.CheckValidation(true, false))
			{
				MessageBox.Show(Localizer.Localize("ERROR_INVALIDMAP_NOPUBLISH", "Notifications"), Localizer.Localize("ERROR", null), MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			this.SaveMap(false, false, new EditorDocument.SaveCompletedCallback(this.PublishMapSaveComplete));
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000538C File Offset: 0x0000358C
		private void PublishMapSaveComplete(bool success)
		{
			if (!success)
			{
				MessageBox.Show(Localizer.Localize("MSG_DESC_SAVE_ERROR", "InGameEditor"), Localizer.Localize("ERROR", null), MessageBoxButton.OK, MessageBoxImage.Hand);
				return;
			}
			MessageBoxResult messageBoxResult = MessageBox.Show(Program.MainWin, Localizer.Localize("MP_UGC_Moderation_Illicit_Content", "Notifications"), Localizer.Localize("EDITOR_NAME", null), MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
			if (messageBoxResult == MessageBoxResult.No)
			{
				return;
			}
			EditorDocument.Login(new EditorDocument.LoginCompleteCallback(this.PublishMapLoginComplete));
		}

		// Token: 0x06000158 RID: 344 RVA: 0x000053FE File Offset: 0x000035FE
		private void PublishMapLoginComplete(bool success)
		{
			if (!success)
			{
				MessageBox.Show(Program.MainWin, Localizer.Localize("PC_PLAYERSTATUS_UPLAYDOWN", "PC"), Localizer.Localize("EDITOR_NAME", null), MessageBoxButton.OK, MessageBoxImage.Exclamation);
				return;
			}
			EditorDocument.Publish(new EditorDocument.PublishCompleteCallback(this.PublishMapComleteAll));
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00005440 File Offset: 0x00003640
		private void PublishMapComleteAll(bool success)
		{
			MessageBox.Show(Program.MainWin, Localizer.Localize(success ? "MP_MyMaps_Tab_Title_Published" : "MP_MyMaps_Status_Not_Published", "MyMaps"), Localizer.Localize("EDITOR_NAME", null), MessageBoxButton.OK, MessageBoxImage.Exclamation);
			if (!success)
			{
				this.SaveMap(false, true, null);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000548C File Offset: 0x0000368C
		private void EditMapMode()
		{
			EditMapDialog editMapDialog = new EditMapDialog(GameModeManager.GetCurrentObjectiveType());
			editMapDialog.ShowDialog();
			if (editMapDialog.DialogResult != true)
			{
				return;
			}
			GameModeManager.SetCurrentObjectiveType(editMapDialog.SelectedObjective);
			this.ActiveTool.Refresh();
			this.UpdateToolsForMode(UpdateModeSource.Default);
			this.SaveMap(true, false, null);
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000054F2 File Offset: 0x000036F2
		private void MapPostLoad()
		{
			if (!Editor.ContainsInput(this))
			{
				Editor.PushInput(this);
			}
			Clipboard.Clear();
		}

		// Token: 0x0600015C RID: 348 RVA: 0x00005507 File Offset: 0x00003707
		private void CopySelection()
		{
			this._toolObject.SetNoGameplayClipboard(false);
			this._toolObject.CopyToClipboard();
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00005520 File Offset: 0x00003720
		private void PasteSelection()
		{
			this.ActivateTool(this._toolObject);
			this._toolObject.PasteFromClipboard();
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00005539 File Offset: 0x00003739
		private bool CanCopy()
		{
			return this._toolObject != null && this.ActiveTool == this._toolObject && this._toolObject.CanCopy();
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000555E File Offset: 0x0000375E
		private bool CanPaste()
		{
			return this._toolObject != null && this._toolObject.CanPaste();
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00005575 File Offset: 0x00003775
		public void ActivateToolValidation()
		{
			this._toolValidation.IsActive = true;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005583 File Offset: 0x00003783
		private static void RaiseClose()
		{
			Program.MainWin.Close();
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000558F File Offset: 0x0000378F
		private static void CreateIssue()
		{
			Binding.FCE_Editor_CreateIssue();
		}

		// Token: 0x06000163 RID: 355 RVA: 0x000055B4 File Offset: 0x000037B4
		internal bool CloseWindow()
		{
			if (Editor.IsIngame)
			{
				Editor.ExitIngame();
			}
			if (!this.CloseSaveConfirmed && !this.PromptSave(delegate(bool success)
			{
				if (!success)
				{
					return;
				}
				this.CloseSaveConfirmed = true;
				Application.Current.Shutdown();
			}))
			{
				return false;
			}
			ThumbnailLoader.Instance.Shutdown();
			Application.Current.Shutdown();
			return true;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00005600 File Offset: 0x00003800
		private void BackupLayout()
		{
			this._defaultWinPos = Program.MainWin.GetPlacement();
			this._defaultLayout = Program.MainWin.MainDockSite.GetLayout(false);
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00005628 File Offset: 0x00003828
		private void RestoreLayout()
		{
			Program.MainWin.SetPlacement(this._defaultWinPos);
			try
			{
				Program.MainWin.MainDockSite.SetLayout(this._defaultLayout);
			}
			catch
			{
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000166 RID: 358 RVA: 0x00005670 File Offset: 0x00003870
		// (set) Token: 0x06000167 RID: 359 RVA: 0x00005678 File Offset: 0x00003878
		public float FPS
		{
			get
			{
				return this._fps;
			}
			set
			{
				if (this._fps == value)
				{
					return;
				}
				this._fps = value;
				base.RaisePropertyChanged("FPS");
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00005696 File Offset: 0x00003896
		// (set) Token: 0x06000169 RID: 361 RVA: 0x000056A0 File Offset: 0x000038A0
		public Vec3? CursorPosition
		{
			get
			{
				return this._cursorPosition;
			}
			set
			{
				if (this._cursorPosition == value)
				{
					return;
				}
				this._cursorPosition = value;
				base.RaisePropertyChanged("CursorPosition");
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600016A RID: 362 RVA: 0x000056FD File Offset: 0x000038FD
		// (set) Token: 0x0600016B RID: 363 RVA: 0x00005705 File Offset: 0x00003905
		public string TitleBar
		{
			get
			{
				return this._titleBar;
			}
			set
			{
				if (this._titleBar == value)
				{
					return;
				}
				this._titleBar = value;
				base.RaisePropertyChanged("TitleBar");
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00005728 File Offset: 0x00003928
		// (set) Token: 0x0600016D RID: 365 RVA: 0x00005730 File Offset: 0x00003930
		public bool Loaded { get; private set; }

		// Token: 0x0600016E RID: 366 RVA: 0x0000573C File Offset: 0x0000393C
		public bool PostLoad(ulong objectiveId, ulong terrainId, string mapName)
		{
			this._bootObjectiveId = objectiveId;
			this._bootTerrainId = terrainId;
			this._bootMapName = mapName;
			bool flag = true;
			this.BackupLayout();
			Program.MainWin.LoadSettings();
			GameModeManager.Initialize();
			GameProperties.Initialize();
			MapTags.Initialize();
			this.CreateTools();
			ToolObject.OnSelectionChanged = (SelectionChangedHandler)Delegate.Combine(ToolObject.OnSelectionChanged, new SelectionChangedHandler(this.SelectionChanged));
			ToolObject.OnNewInstanceCreated = (Action)Delegate.Combine(ToolObject.OnNewInstanceCreated, new Action(this.InstanceCreated));
			this.MainMenu = new MainMenu();
			this.MainToolBarTray = new MainToolBarTray();
			this.EnableShortcuts = true;
			Camera.Speed = this.CurrentSpeed.Value;
			this.EditorSettings = new EditorSettingsViewModel();
			this.ObjectProperties = null;
			this.TitleBar = Localizer.Localize("EDITOR_NAME", null);
			this.UpdateTitleBar();
			this.UpdateCurrentTool();
			Program.MainWin.DockToolParameters.Title = Localizer.Localize("DOCK_TOOL_PARAMETERS", null);
			Program.MainWin.DockContextHelp.Title = Localizer.Localize("DOCK_CONTEXT_HELP", null);
			Program.MainWin.DockEditorSettings.Title = Localizer.Localize("DOCK_EDITOR_SETTINGS", null);
			Program.MainWin.DockObjectProperties.Title = Localizer.Localize("DOCK_OBJECT_PROPERTIES", null);
			Program.MainWin.DockBudgets.Title = Localizer.Localize("MENUITEM_BUDGET", null);
			this.Budgets = new BudgetsViewModel();
			this.Loaded = flag;
			return flag;
		}

		// Token: 0x0600016F RID: 367 RVA: 0x000058C8 File Offset: 0x00003AC8
		public void UiPostLoad()
		{
			Program.MainWin.Activate();
			if (this.NoInit)
			{
				return;
			}
			if (this._bootObjectiveId != 0UL && this._bootTerrainId != 0UL)
			{
				this.NewMapPostLoad(this._bootObjectiveId, this._bootTerrainId);
			}
			else if (this._bootMapName != null)
			{
				this.LoadMapInternal(this._bootMapName);
			}
			else
			{
				bool flag = false;
				while (!flag)
				{
					InitDialog initDialog = new InitDialog();
					InitDialog initDialog2 = initDialog;
					InitDialog.ActionEntry actionEntry = new InitDialog.ActionEntry();
					actionEntry.Content = Localizer.Localize("STARTUP_NEW_MAP", "InGameEditor");
					actionEntry.Action = (() => this.NewMapInternal());
					initDialog2.AppendAction(actionEntry);
					InitDialog initDialog3 = initDialog;
					InitDialog.ActionEntry actionEntry2 = new InitDialog.ActionEntry();
					actionEntry2.Content = Localizer.Localize("Open_Map_Header", "PopUp");
					actionEntry2.Action = (() => this.LoadMapInternal(null));
					initDialog3.AppendAction(actionEntry2);
					initDialog.ShowDialog();
					if (initDialog.DialogResult != true)
					{
						break;
					}
					InitDialog.ActionEntry selectedAction = initDialog.SelectedAction;
					flag = selectedAction.Action();
				}
				if (!flag)
				{
					this.Loaded = false;
					Program.MainWin.Close();
					return;
				}
			}
			ViewportControl viewport = Program.MainWin.Viewport;
			viewport.ViewportDoubleClicked = (Action)Delegate.Combine(viewport.ViewportDoubleClicked, new Action(this.OnViewportDoubleClicked));
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00005A40 File Offset: 0x00003C40
		private void SelectionChanged(EditorObjectSelection selection)
		{
			if (selection.Count != 1)
			{
				Binding.FCE_Engine_SetSelectedObject(IntPtr.Zero);
				this.ObjectProperties = new NoPropertiesViewModel(null);
				return;
			}
			Binding.FCE_Engine_SetSelectedObject(selection[0].Pointer);
			bool flag;
			if (GameModeManager.GetEnumObjectiveType() == GameModeManager.EMapObjective.EMapObjective_Poacher)
			{
				flag = (selection[0].Entry.IsEnemy || selection[0].Entry.IsAlly);
			}
			else
			{
				flag = (selection[0].Entry.IsAnimal || selection[0].Entry.IsAlly);
			}
			if (flag)
			{
				if (Program.MainWin.DockObjectProperties.DockSituation == DockSituation.Docked && Program.MainWin.DockObjectProperties.Pinned)
				{
					Program.MainWin.DockObjectProperties.Open();
				}
				this.ObjectProperties = new AmbientPropertiesViewModel(selection[0]);
			}
			else if (selection[0].Entry.IsSTP)
			{
				if (Program.MainWin.DockObjectProperties.DockSituation == DockSituation.Docked && Program.MainWin.DockObjectProperties.Pinned)
				{
					Program.MainWin.DockObjectProperties.Open();
				}
				this.ObjectProperties = new STPPropertiesViewModel(selection[0]);
			}
			else
			{
				this.ObjectProperties = new NoPropertiesViewModel(null);
			}
			Program.MainWin.Viewport.Focus();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00005BB0 File Offset: 0x00003DB0
		private void InstanceCreated()
		{
			if (Program.MainWin.DockBudgets.DockSituation == DockSituation.Docked && Program.MainWin.DockBudgets.Pinned)
			{
				Program.MainWin.DockBudgets.Open();
			}
			Program.MainWin.Viewport.Focus();
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000172 RID: 370 RVA: 0x00005C00 File Offset: 0x00003E00
		// (set) Token: 0x06000173 RID: 371 RVA: 0x00005C08 File Offset: 0x00003E08
		public EditorSettingsViewModel EditorSettings
		{
			get
			{
				return this._editorSettings;
			}
			private set
			{
				this._editorSettings = value;
				base.RaisePropertyChanged("EditorSettings");
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00005C1C File Offset: 0x00003E1C
		// (set) Token: 0x06000175 RID: 373 RVA: 0x00005C24 File Offset: 0x00003E24
		public ObjectPropertiesViewModel ObjectProperties
		{
			get
			{
				return this._objectProperties;
			}
			private set
			{
				this._objectProperties = value;
				base.RaisePropertyChanged("ObjectProperties");
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00005C38 File Offset: 0x00003E38
		// (set) Token: 0x06000177 RID: 375 RVA: 0x00005C40 File Offset: 0x00003E40
		public BudgetsViewModel Budgets
		{
			get
			{
				return this._budgets;
			}
			private set
			{
				this._budgets = value;
				base.RaisePropertyChanged("Budgets");
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x00005C54 File Offset: 0x00003E54
		public void SetUpBudgetsWindow()
		{
			Program.MainWin.DockBudgets.Dock(WindowOpenMethod.Background);
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000179 RID: 377 RVA: 0x00005C66 File Offset: 0x00003E66
		// (set) Token: 0x0600017A RID: 378 RVA: 0x00005C6E File Offset: 0x00003E6E
		public MainMenu MainMenu
		{
			get
			{
				return this._mainMenu;
			}
			set
			{
				this._mainMenu = value;
				base.RaisePropertyChanged("MainMenu");
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00005C82 File Offset: 0x00003E82
		// (set) Token: 0x0600017C RID: 380 RVA: 0x00005C8A File Offset: 0x00003E8A
		public MainToolBarTray MainToolBarTray
		{
			get
			{
				return this._mainToolBarTray;
			}
			set
			{
				this._mainToolBarTray = value;
				base.RaisePropertyChanged("MainToolBarTray");
			}
		}

		// Token: 0x17000068 RID: 104
		// (set) Token: 0x0600017D RID: 381 RVA: 0x00005C9E File Offset: 0x00003E9E
		public string ContextHelp
		{
			set
			{
				this.SetRichText(value);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00005CA7 File Offset: 0x00003EA7
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00005CAF File Offset: 0x00003EAF
		public FlowDocument RichContextHelpDocument
		{
			get
			{
				return this._richContextHelpDocument;
			}
			set
			{
				this._richContextHelpDocument = value;
				base.RaisePropertyChanged("RichContextHelpDocument");
			}
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00005CC4 File Offset: 0x00003EC4
		private void SetRichText(string value)
		{
			Run run = new Run(value);
			Paragraph item = new Paragraph(run);
			while (run != null)
			{
				string text = run.Text;
				int num = text.IndexOf('{', 0);
				if (num < 0)
				{
					break;
				}
				int num2 = text.IndexOf('}', num + 1);
				if (num2 < 0)
				{
					break;
				}
				string str = text.Substring(num + 1, num2 - num - 1);
				Image image = ("PCButton/" + str + ".png").GetImage();
				if (image != null)
				{
					image.Stretch = Stretch.Uniform;
					image.Height = 25.0;
					image.Margin = new Thickness(0.0, 2.0, 0.0, 2.0);
				}
				string text2 = run.Text.Substring(0, num);
				Run run2 = new Run(text2)
				{
					BaselineAlignment = BaselineAlignment.Center
				};
				run.ContentStart.Paragraph.Inlines.InsertBefore(run, run2);
				Run run3 = null;
				if (num2 + 1 < run.Text.Length)
				{
					string text3 = run.Text.Substring(num2 + 1);
					run3 = new Run(text3)
					{
						BaselineAlignment = BaselineAlignment.Center
					};
					run.ContentStart.Paragraph.Inlines.InsertAfter(run2, run3);
				}
				if (image == null)
				{
					Run newItem = new Run("{" + str + "}")
					{
						BaselineAlignment = BaselineAlignment.Center,
						Foreground = Brushes.Red,
						FontWeight = FontWeights.Bold
					};
					run2.ContentStart.Paragraph.Inlines.InsertAfter(run2, newItem);
				}
				else
				{
					run2.ContentStart.Paragraph.Inlines.InsertAfter(run2, new InlineUIContainer(image));
				}
				run.ContentStart.Paragraph.Inlines.Remove(run);
				run = run3;
			}
			this.RichContextHelpDocument = new FlowDocument
			{
				Blocks = 
				{
					item
				}
			};
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00005ECC File Offset: 0x000040CC
		private void UpdateCurrentTool()
		{
			this.ContextHelp = ((this.ActiveTool == null) ? Localizer.Localize("HELP_WELCOME", null) : this.ActiveTool.GetContextHelp());
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00005EF4 File Offset: 0x000040F4
		private void SetTitleBar(string title)
		{
			this.TitleBar = Localizer.Localize("EDITOR_NAME", null) + " - " + title;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00005F12 File Offset: 0x00004112
		private void UpdateTitleBar()
		{
			this.SetTitleBar(string.IsNullOrEmpty(EditorDocument.MapName) ? Localizer.Localize("EDITOR_UNTITLED", null) : EditorDocument.MapName);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00005F38 File Offset: 0x00004138
		public void Update(float dt)
		{
			this._lastUpdate += dt;
			this.CanCopyFlag = this.CanCopy();
			this.CanPasteFlag = this.CanPaste();
			if (this._lastUpdate >= 0.25f)
			{
				this._lastUpdate = 0f;
				this.UpdateValues(dt);
				MainWindowViewModel.StatusBarMode mode = MainWindowViewModel.StatusBarMode.None;
				if (Editor.IsIngame)
				{
					mode = MainWindowViewModel.StatusBarMode.Ingame;
				}
				else if (Navmesh.PendingTilesCount > 0)
				{
					mode = MainWindowViewModel.StatusBarMode.Navmesh;
				}
				else if (Editor.IsLoadPending)
				{
					mode = MainWindowViewModel.StatusBarMode.Loading;
				}
				this.UpdateStatusBar(mode);
			}
			if (this.ActiveTool != null)
			{
				this.ActiveTool.UpdateTool(dt);
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00005FC8 File Offset: 0x000041C8
		private void UpdateStatusBar(MainWindowViewModel.StatusBarMode mode)
		{
			if (mode == MainWindowViewModel.StatusBarMode.None)
			{
				if (this._statusBarMode != MainWindowViewModel.StatusBarMode.None)
				{
					this.StatusIcon = null;
					this.StatusText = Localizer.Localize("EDITOR_STATUS_READY", null);
					this.StatusBackground = new SolidColorBrush(SystemColors.ControlColor);
					this.StatusColor = new SolidColorBrush(SystemColors.ControlTextColor);
				}
			}
			else if (mode == MainWindowViewModel.StatusBarMode.Loading)
			{
				if (this._statusBarMode != MainWindowViewModel.StatusBarMode.Loading)
				{
					this.StatusIcon = this._hourglass;
					if (Engine.Initialized)
					{
						this.StatusText = Localizer.Localize("EDITOR_STATUS_LOADING", null);
					}
					this.StatusBackground = new SolidColorBrush(Colors.LightCoral);
					this.StatusColor = new SolidColorBrush(Colors.Black);
				}
			}
			else if (mode == MainWindowViewModel.StatusBarMode.Navmesh)
			{
				if (this._statusBarMode != MainWindowViewModel.StatusBarMode.Navmesh)
				{
					this.StatusIcon = this._hourglass;
					this.StatusText = string.Format("Generating {0} navmesh tiles...", Navmesh.PendingTilesCount);
					this.StatusBackground = new SolidColorBrush(Colors.LightCoral);
					this.StatusColor = new SolidColorBrush(Colors.Black);
				}
			}
			else if (mode == MainWindowViewModel.StatusBarMode.Ingame && this._statusBarMode != MainWindowViewModel.StatusBarMode.Ingame)
			{
				this.StatusIcon = null;
				if (Editor.CurrentPlayMode == Editor.PlayMode.Play)
				{
					this.StatusText = Localizer.Localize("EDITOR_STATUS_INGAME", null);
				}
				else
				{
					this.StatusText = Localizer.Localize("EDITOR_STATUS_EXPLORE", null);
				}
				this.StatusBackground = new SolidColorBrush(Color.FromArgb(byte.MaxValue, 32, 32, 32));
				this.StatusColor = new SolidColorBrush(Colors.GhostWhite);
			}
			this._statusBarMode = mode;
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000186 RID: 390 RVA: 0x00006143 File Offset: 0x00004343
		// (set) Token: 0x06000187 RID: 391 RVA: 0x0000614B File Offset: 0x0000434B
		public ImageSource StatusIcon
		{
			get
			{
				return this._statusIcon;
			}
			set
			{
				this._statusIcon = value;
				base.RaisePropertyChanged("StatusIcon");
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000188 RID: 392 RVA: 0x0000615F File Offset: 0x0000435F
		// (set) Token: 0x06000189 RID: 393 RVA: 0x00006167 File Offset: 0x00004367
		public string StatusText
		{
			get
			{
				return this._statusText;
			}
			set
			{
				this._statusText = value;
				base.RaisePropertyChanged("StatusText");
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600018A RID: 394 RVA: 0x0000617B File Offset: 0x0000437B
		// (set) Token: 0x0600018B RID: 395 RVA: 0x00006183 File Offset: 0x00004383
		public Brush StatusColor
		{
			get
			{
				return this._statusColor;
			}
			set
			{
				this._statusColor = value;
				base.RaisePropertyChanged("StatusColor");
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600018C RID: 396 RVA: 0x00006197 File Offset: 0x00004397
		// (set) Token: 0x0600018D RID: 397 RVA: 0x0000619F File Offset: 0x0000439F
		public Brush StatusBackground
		{
			get
			{
				return this._statusBackground;
			}
			set
			{
				this._statusBackground = value;
				base.RaisePropertyChanged("StatusBackground");
			}
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000061B4 File Offset: 0x000043B4
		private void UpdateValues(float dt)
		{
			BudgetsViewModel budgets = this.Budgets;
			if (budgets != null)
			{
				budgets.UpdateBudgets(dt);
			}
			this.FPS = 1f / Editor.FrameTime;
			Vec3 vec;
			bool flag = this._cursorPhysics ? Editor.RayCastPhysicsFromMouse(out vec) : Editor.RayCastTerrainFromMouse(out vec);
			if (this._currentCursorValid != flag || vec != this._currentCursorPos)
			{
				this._currentCursorPos = vec;
				this._currentCursorValid = flag;
				if (flag)
				{
					this.CursorPosition = new Vec3?(vec);
				}
				else
				{
					this.CursorPosition = null;
				}
			}
			this.CameraPosition = Camera.Position;
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600018F RID: 399 RVA: 0x0000624C File Offset: 0x0000444C
		// (set) Token: 0x06000190 RID: 400 RVA: 0x00006254 File Offset: 0x00004454
		public bool CursorPhysics
		{
			get
			{
				return this._cursorPhysics;
			}
			set
			{
				this._cursorPhysics = value;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000191 RID: 401 RVA: 0x0000625D File Offset: 0x0000445D
		// (set) Token: 0x06000192 RID: 402 RVA: 0x00006265 File Offset: 0x00004465
		public Vec3 CameraPosition
		{
			get
			{
				return this._cameraPosition;
			}
			set
			{
				if (this._cameraPosition == value)
				{
					return;
				}
				this._cameraPosition = value;
				base.RaisePropertyChanged("CameraPosition");
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000193 RID: 403 RVA: 0x00006288 File Offset: 0x00004488
		// (set) Token: 0x06000194 RID: 404 RVA: 0x00006290 File Offset: 0x00004490
		public bool EnableShortcuts { private get; set; }

		// Token: 0x06000195 RID: 405 RVA: 0x00006299 File Offset: 0x00004499
		public void ClearMapPath()
		{
			this._documentPath = null;
			this.UpdateTitleBar();
		}

		// Token: 0x06000196 RID: 406 RVA: 0x000062A8 File Offset: 0x000044A8
		public void OnInputAcquire()
		{
		}

		// Token: 0x06000197 RID: 407 RVA: 0x000062AA File Offset: 0x000044AA
		public void OnInputRelease()
		{
		}

		// Token: 0x06000198 RID: 408 RVA: 0x000062AC File Offset: 0x000044AC
		public bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			return false;
		}

		// Token: 0x06000199 RID: 409 RVA: 0x000062B0 File Offset: 0x000044B0
		public bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			if (keyEvent == Editor.KeyEvent.KeyUp)
			{
				Key keyCode = keyEventArgs.KeyCode;
				if (keyCode == Key.Escape)
				{
					this.ActiveTool = null;
					return true;
				}
				if (this.EnableShortcuts)
				{
					ToolBase toolBase;
					if (this._toolShortcuts.TryGetValue(keyEventArgs.KeyCode, out toolBase))
					{
						if (toolBase is ToolObjectModeToggle)
						{
							((Tool)toolBase).IsActive = true;
						}
						else if (toolBase is Tool)
						{
							this.ActivateTool((Tool)toolBase);
						}
						else if (toolBase is ToolAction)
						{
							((ToolAction)toolBase).Fire();
						}
						return true;
					}
					MainWindowViewModel.ShortKey key = new MainWindowViewModel.ShortKey(Keyboard.Modifiers, keyEventArgs.KeyCode);
					if (this._shortcutCommands.ContainsKey(key))
					{
						ICommand command = this._shortcutCommands[key];
						if (command.CanExecute(null))
						{
							command.Execute(null);
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600019A RID: 410 RVA: 0x00006378 File Offset: 0x00004578
		public void OnEditorEvent(uint eventType, IntPtr eventPtr)
		{
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600019B RID: 411 RVA: 0x0000637A File Offset: 0x0000457A
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00006382 File Offset: 0x00004582
		public bool CloseSaveConfirmed { get; set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600019D RID: 413 RVA: 0x0000638B File Offset: 0x0000458B
		// (set) Token: 0x0600019E RID: 414 RVA: 0x00006399 File Offset: 0x00004599
		public bool IsIngameUi
		{
			get
			{
				return this.UiVisibility != Visibility.Visible;
			}
			set
			{
				if (value)
				{
					this.ActiveTool = null;
				}
				this.EnableIngameUi(value);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600019F RID: 415 RVA: 0x000063AC File Offset: 0x000045AC
		// (set) Token: 0x060001A0 RID: 416 RVA: 0x000063B4 File Offset: 0x000045B4
		public bool IsUiEnabled
		{
			get
			{
				return this._isUiEnabled;
			}
			set
			{
				if (this._isUiEnabled == value)
				{
					return;
				}
				this._isUiEnabled = value;
				base.RaisePropertyChanged("IsUiEnabled");
				if (this._isUiEnabled)
				{
					Program.MainWin.GameViewport.Focus();
				}
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x000063EA File Offset: 0x000045EA
		// (set) Token: 0x060001A2 RID: 418 RVA: 0x000063F2 File Offset: 0x000045F2
		public bool NoInit { get; set; }

		// Token: 0x060001A3 RID: 419 RVA: 0x000063FC File Offset: 0x000045FC
		private void EnableIngameUi(bool enable)
		{
			Program.MainWin.GameViewport.CaptureMouse = enable;
			this.UiVisibility = (enable ? Visibility.Collapsed : Visibility.Visible);
			if (enable)
			{
				Program.MainWin.SaveSettings();
				this._toolParametersOpened = (Program.MainWin.DockToolParameters.DockSituation != DockSituation.None);
				this._contextHelpOpened = (Program.MainWin.DockContextHelp.DockSituation != DockSituation.None);
				this._editorSettingsOpened = (Program.MainWin.DockEditorSettings.DockSituation != DockSituation.None);
				this._budgetsOpened = (Program.MainWin.DockBudgets.DockSituation != DockSituation.None);
				this._objectPropsOpened = (Program.MainWin.DockObjectProperties.DockSituation != DockSituation.None);
				Program.MainWin.DockToolParameters.Close();
				Program.MainWin.DockContextHelp.Close();
				Program.MainWin.DockEditorSettings.Close();
				Program.MainWin.DockBudgets.Close();
				Program.MainWin.DockObjectProperties.Close();
				return;
			}
			if (this._toolParametersOpened)
			{
				Program.MainWin.DockToolParameters.Open();
			}
			if (this._objectPropsOpened)
			{
				Program.MainWin.DockObjectProperties.Open();
			}
			if (this._budgetsOpened)
			{
				Program.MainWin.DockBudgets.Open();
			}
			if (this._contextHelpOpened)
			{
				Program.MainWin.DockContextHelp.Open();
			}
			if (this._editorSettingsOpened)
			{
				Program.MainWin.DockEditorSettings.Open();
			}
			Program.MainWin.LoadSettings();
			Program.MainWin.Viewport.Focus();
			this.ToggleObjectToolMode(this._selectToggle);
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060001A4 RID: 420 RVA: 0x000065AC File Offset: 0x000047AC
		// (set) Token: 0x060001A5 RID: 421 RVA: 0x000065B4 File Offset: 0x000047B4
		public Visibility UiVisibility
		{
			get
			{
				return this._uiVisibility;
			}
			set
			{
				if (this._uiVisibility == value)
				{
					return;
				}
				this._uiVisibility = value;
				base.RaisePropertyChanged("UiVisibility");
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060001A6 RID: 422 RVA: 0x000065D2 File Offset: 0x000047D2
		public string ImagesDictionary
		{
			get
			{
				return "/" + Program.AssemblyName + ";component/ResourceDictionary/Images.xaml";
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x000065E8 File Offset: 0x000047E8
		private void OnViewportDoubleClicked()
		{
			if (!Editor.IsIngame && ((this.ActiveTool == this._toolObject && !this._toolObject.IsInventoryObjectSelected) || this.ActiveTool == this._toolValidation || this.ActiveTool == this._toolProperties || this.ActiveTool == this._toolGameProp || this.ActiveTool == this._toolNavmesh || this.ActiveTool == this._toolEnv || this.ActiveTool == null))
			{
				this.ToggleObjectToolMode(this._selectToggle);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001A8 RID: 424 RVA: 0x00006671 File Offset: 0x00004871
		// (set) Token: 0x060001A9 RID: 425 RVA: 0x00006679 File Offset: 0x00004879
		public ICommand NewMapCommand { get; private set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00006682 File Offset: 0x00004882
		// (set) Token: 0x060001AB RID: 427 RVA: 0x0000668A File Offset: 0x0000488A
		public ICommand LoadMapCommand { get; private set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001AC RID: 428 RVA: 0x00006693 File Offset: 0x00004893
		// (set) Token: 0x060001AD RID: 429 RVA: 0x0000669B File Offset: 0x0000489B
		public ICommand SaveMapCommand { get; private set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001AE RID: 430 RVA: 0x000066A4 File Offset: 0x000048A4
		// (set) Token: 0x060001AF RID: 431 RVA: 0x000066AC File Offset: 0x000048AC
		public ICommand SaveMapAsCommand { get; private set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001B0 RID: 432 RVA: 0x000066B5 File Offset: 0x000048B5
		// (set) Token: 0x060001B1 RID: 433 RVA: 0x000066BD File Offset: 0x000048BD
		public ICommand ExportBEMapCommand { get; private set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001B2 RID: 434 RVA: 0x000066C6 File Offset: 0x000048C6
		// (set) Token: 0x060001B3 RID: 435 RVA: 0x000066CE File Offset: 0x000048CE
		public ICommand ExportLEMapCommand { get; private set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x000066D7 File Offset: 0x000048D7
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x000066DF File Offset: 0x000048DF
		public ICommand ValidateCommand { get; private set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x000066E8 File Offset: 0x000048E8
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x000066F0 File Offset: 0x000048F0
		public ICommand PublishCommand { get; private set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x000066F9 File Offset: 0x000048F9
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x00006701 File Offset: 0x00004901
		public ICommand RenameCommand { get; private set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000670A File Offset: 0x0000490A
		// (set) Token: 0x060001BB RID: 443 RVA: 0x00006712 File Offset: 0x00004912
		public ICommand CloseCommand { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0000671B File Offset: 0x0000491B
		// (set) Token: 0x060001BD RID: 445 RVA: 0x00006723 File Offset: 0x00004923
		public ICommand UndoCommand { get; private set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0000672C File Offset: 0x0000492C
		// (set) Token: 0x060001BF RID: 447 RVA: 0x00006734 File Offset: 0x00004934
		public ICommand RedoCommand { get; private set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000673D File Offset: 0x0000493D
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x00006745 File Offset: 0x00004945
		public ICommand CopyCommand { get; private set; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000674E File Offset: 0x0000494E
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x00006756 File Offset: 0x00004956
		public ICommand PasteCommand { get; private set; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x0000675F File Offset: 0x0000495F
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x00006767 File Offset: 0x00004967
		public ICommand MapPropsCommand { get; private set; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x060001C6 RID: 454 RVA: 0x00006770 File Offset: 0x00004970
		// (set) Token: 0x060001C7 RID: 455 RVA: 0x00006778 File Offset: 0x00004978
		public ICommand ToolParametersCommand { get; private set; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x060001C8 RID: 456 RVA: 0x00006781 File Offset: 0x00004981
		// (set) Token: 0x060001C9 RID: 457 RVA: 0x00006789 File Offset: 0x00004989
		public ICommand EditorSettingsCommand { get; private set; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x060001CA RID: 458 RVA: 0x00006792 File Offset: 0x00004992
		// (set) Token: 0x060001CB RID: 459 RVA: 0x0000679A File Offset: 0x0000499A
		public ICommand EditorObjectsCommand { get; private set; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x060001CC RID: 460 RVA: 0x000067A3 File Offset: 0x000049A3
		// (set) Token: 0x060001CD RID: 461 RVA: 0x000067AB File Offset: 0x000049AB
		public ICommand BudgetMenuCommand { get; private set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060001CE RID: 462 RVA: 0x000067B4 File Offset: 0x000049B4
		// (set) Token: 0x060001CF RID: 463 RVA: 0x000067BC File Offset: 0x000049BC
		public ICommand ContextHelpCommand { get; private set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x000067C5 File Offset: 0x000049C5
		// (set) Token: 0x060001D1 RID: 465 RVA: 0x000067CD File Offset: 0x000049CD
		public ICommand ResetLayoutCommand { get; private set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x000067D6 File Offset: 0x000049D6
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x000067DE File Offset: 0x000049DE
		public ICommand PlayIngameCommand { get; private set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x000067E7 File Offset: 0x000049E7
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x000067EF File Offset: 0x000049EF
		public ICommand ExploreIngameCommand { get; private set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x000067F8 File Offset: 0x000049F8
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x00006800 File Offset: 0x00004A00
		public ICommand ToolBumpCommand { get; private set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00006809 File Offset: 0x00004A09
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x00006811 File Offset: 0x00004A11
		public ICommand ToolRaiseCommand { get; private set; }

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001DA RID: 474 RVA: 0x0000681A File Offset: 0x00004A1A
		// (set) Token: 0x060001DB RID: 475 RVA: 0x00006822 File Offset: 0x00004A22
		public ICommand ToolFlattenCommand { get; private set; }

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060001DC RID: 476 RVA: 0x0000682B File Offset: 0x00004A2B
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00006833 File Offset: 0x00004A33
		public ICommand ToolSet2HeightCommand { get; private set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060001DE RID: 478 RVA: 0x0000683C File Offset: 0x00004A3C
		// (set) Token: 0x060001DF RID: 479 RVA: 0x00006844 File Offset: 0x00004A44
		public ICommand ToolSmoothCommand { get; private set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x0000684D File Offset: 0x00004A4D
		// (set) Token: 0x060001E1 RID: 481 RVA: 0x00006855 File Offset: 0x00004A55
		public ICommand ToolRampCommand { get; private set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x0000685E File Offset: 0x00004A5E
		// (set) Token: 0x060001E3 RID: 483 RVA: 0x00006866 File Offset: 0x00004A66
		public ICommand ToolNoiseCommand { get; private set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x060001E4 RID: 484 RVA: 0x0000686F File Offset: 0x00004A6F
		// (set) Token: 0x060001E5 RID: 485 RVA: 0x00006877 File Offset: 0x00004A77
		public ICommand ToolErosionCommand { get; private set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x060001E6 RID: 486 RVA: 0x00006880 File Offset: 0x00004A80
		// (set) Token: 0x060001E7 RID: 487 RVA: 0x00006888 File Offset: 0x00004A88
		public ICommand ToolHoleCommand { get; private set; }

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x060001E8 RID: 488 RVA: 0x00006891 File Offset: 0x00004A91
		// (set) Token: 0x060001E9 RID: 489 RVA: 0x00006899 File Offset: 0x00004A99
		public ICommand ToolWaterLayerCommand { get; private set; }

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060001EA RID: 490 RVA: 0x000068A2 File Offset: 0x00004AA2
		// (set) Token: 0x060001EB RID: 491 RVA: 0x000068AA File Offset: 0x00004AAA
		public ICommand ToolTextureCommand { get; private set; }

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060001EC RID: 492 RVA: 0x000068B3 File Offset: 0x00004AB3
		// (set) Token: 0x060001ED RID: 493 RVA: 0x000068BB File Offset: 0x00004ABB
		public ICommand ToolCollectionCommand { get; private set; }

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060001EE RID: 494 RVA: 0x000068C4 File Offset: 0x00004AC4
		// (set) Token: 0x060001EF RID: 495 RVA: 0x000068CC File Offset: 0x00004ACC
		public ICommand ToolRoadsCommand { get; private set; }

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x000068D5 File Offset: 0x00004AD5
		// (set) Token: 0x060001F1 RID: 497 RVA: 0x000068DD File Offset: 0x00004ADD
		public ICommand ToolPlayableZoneCommand { get; private set; }

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x000068E6 File Offset: 0x00004AE6
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x000068EE File Offset: 0x00004AEE
		public ICommand ToolEnviromentCommand { get; private set; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x000068F7 File Offset: 0x00004AF7
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x000068FF File Offset: 0x00004AFF
		public ICommand ToolModifiersCommand { get; private set; }

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x00006908 File Offset: 0x00004B08
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x00006910 File Offset: 0x00004B10
		public ICommand ToolSelectCommand { get; private set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00006919 File Offset: 0x00004B19
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x00006921 File Offset: 0x00004B21
		public ICommand ToolMoveCommand { get; private set; }

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060001FA RID: 506 RVA: 0x0000692A File Offset: 0x00004B2A
		// (set) Token: 0x060001FB RID: 507 RVA: 0x00006932 File Offset: 0x00004B32
		public ICommand ToolRotateCommand { get; private set; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060001FC RID: 508 RVA: 0x0000693B File Offset: 0x00004B3B
		// (set) Token: 0x060001FD RID: 509 RVA: 0x00006943 File Offset: 0x00004B43
		public ICommand ToolSnapCommand { get; private set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060001FE RID: 510 RVA: 0x0000694C File Offset: 0x00004B4C
		// (set) Token: 0x060001FF RID: 511 RVA: 0x00006954 File Offset: 0x00004B54
		public ICommand ToolAddCommand { get; private set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000200 RID: 512 RVA: 0x0000695D File Offset: 0x00004B5D
		// (set) Token: 0x06000201 RID: 513 RVA: 0x00006965 File Offset: 0x00004B65
		public ICommand ToolEntityCommand { get; private set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000202 RID: 514 RVA: 0x0000696E File Offset: 0x00004B6E
		// (set) Token: 0x06000203 RID: 515 RVA: 0x00006976 File Offset: 0x00004B76
		public ICommand ToolSpawnerCommand { get; private set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000697F File Offset: 0x00004B7F
		// (set) Token: 0x06000205 RID: 517 RVA: 0x00006987 File Offset: 0x00004B87
		public ICommand ToolStpCommand { get; private set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000206 RID: 518 RVA: 0x00006990 File Offset: 0x00004B90
		// (set) Token: 0x06000207 RID: 519 RVA: 0x00006998 File Offset: 0x00004B98
		public ICommand ToolNavmeshCommand { get; private set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000208 RID: 520 RVA: 0x000069A1 File Offset: 0x00004BA1
		// (set) Token: 0x06000209 RID: 521 RVA: 0x000069A9 File Offset: 0x00004BA9
		public ICommand AboutCommand { get; private set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600020A RID: 522 RVA: 0x000069B2 File Offset: 0x00004BB2
		// (set) Token: 0x0600020B RID: 523 RVA: 0x000069BA File Offset: 0x00004BBA
		public ICommand VisitWebsiteCommand { get; private set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600020C RID: 524 RVA: 0x000069C3 File Offset: 0x00004BC3
		// (set) Token: 0x0600020D RID: 525 RVA: 0x000069CB File Offset: 0x00004BCB
		public ICommand CameraSpeedUpCommand { get; private set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600020E RID: 526 RVA: 0x000069D4 File Offset: 0x00004BD4
		// (set) Token: 0x0600020F RID: 527 RVA: 0x000069DC File Offset: 0x00004BDC
		public ICommand CameraSpeedDownCommand { get; private set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000210 RID: 528 RVA: 0x000069E5 File Offset: 0x00004BE5
		// (set) Token: 0x06000211 RID: 529 RVA: 0x000069ED File Offset: 0x00004BED
		public ICommand ToggleNavmeshCommand { get; private set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000212 RID: 530 RVA: 0x000069F6 File Offset: 0x00004BF6
		// (set) Token: 0x06000213 RID: 531 RVA: 0x000069FE File Offset: 0x00004BFE
		public ICommand CreateIssueCommand { get; private set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000214 RID: 532 RVA: 0x00006A07 File Offset: 0x00004C07
		// (set) Token: 0x06000215 RID: 533 RVA: 0x00006A0F File Offset: 0x00004C0F
		public bool CanCopyFlag
		{
			get
			{
				return this._canCopyFlag;
			}
			set
			{
				if (this._canCopyFlag == value)
				{
					return;
				}
				this._canCopyFlag = value;
				base.RaisePropertyChanged("CanCopyFlag");
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000216 RID: 534 RVA: 0x00006A2D File Offset: 0x00004C2D
		// (set) Token: 0x06000217 RID: 535 RVA: 0x00006A35 File Offset: 0x00004C35
		public bool CanPasteFlag
		{
			get
			{
				return this._canPasteFlag;
			}
			set
			{
				if (this._canPasteFlag == value)
				{
					return;
				}
				this._canPasteFlag = value;
				base.RaisePropertyChanged("CanPasteFlag");
			}
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00006D38 File Offset: 0x00004F38
		private void CreateCommands()
		{
			this.NewMapCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.NewMap();
				}
			};
			this.LoadMapCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.LoadMap(null);
				}
			};
			this.SaveMapCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.SaveMap(false, false, null);
				}
			};
			this.SaveMapAsCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.SaveMap(true, false, null);
				}
			};
			this.ExportBEMapCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ExportMap(true);
				}
			};
			this.ExportLEMapCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ExportMap(false);
				}
			};
			this.ValidateCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolValidation);
				}
			};
			this.PublishCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.PublishMap();
				}
			};
			this.RenameCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.RenameMap();
				}
			};
			SimpleCommand simpleCommand = new SimpleCommand();
			simpleCommand.ExecuteDelegate = delegate(object o)
			{
				MainWindowViewModel.RaiseClose();
			};
			this.CloseCommand = simpleCommand;
			SimpleCommand simpleCommand2 = new SimpleCommand();
			simpleCommand2.ExecuteDelegate = delegate(object o)
			{
				UndoManager.Undo();
			};
			simpleCommand2.CanExecuteDelegate = ((object o) => UndoManager.UndoCount > 0);
			this.UndoCommand = simpleCommand2;
			SimpleCommand simpleCommand3 = new SimpleCommand();
			simpleCommand3.ExecuteDelegate = delegate(object o)
			{
				UndoManager.Redo();
			};
			simpleCommand3.CanExecuteDelegate = ((object o) => UndoManager.RedoCount > 0);
			this.RedoCommand = simpleCommand3;
			this.CopyCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.CopySelection();
				}
			};
			this.PasteCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.PasteSelection();
				}
			};
			this.MapPropsCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolProperties);
				}
			};
			SimpleCommand simpleCommand4 = new SimpleCommand();
			simpleCommand4.ExecuteDelegate = delegate(object o)
			{
				Program.MainWin.DockToolParameters.Open();
			};
			this.ToolParametersCommand = simpleCommand4;
			SimpleCommand simpleCommand5 = new SimpleCommand();
			simpleCommand5.ExecuteDelegate = delegate(object o)
			{
				Program.MainWin.DockEditorSettings.Open();
			};
			this.EditorSettingsCommand = simpleCommand5;
			SimpleCommand simpleCommand6 = new SimpleCommand();
			simpleCommand6.ExecuteDelegate = delegate(object o)
			{
				Program.MainWin.DockObjectProperties.Open();
			};
			this.EditorObjectsCommand = simpleCommand6;
			SimpleCommand simpleCommand7 = new SimpleCommand();
			simpleCommand7.ExecuteDelegate = delegate(object o)
			{
				Program.MainWin.DockBudgets.Open();
			};
			this.BudgetMenuCommand = simpleCommand7;
			SimpleCommand simpleCommand8 = new SimpleCommand();
			simpleCommand8.ExecuteDelegate = delegate(object o)
			{
				Program.MainWin.DockContextHelp.Open();
			};
			this.ContextHelpCommand = simpleCommand8;
			this.ResetLayoutCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.RestoreLayout();
				},
				CanExecuteDelegate = ((object o) => this._defaultLayout != null)
			};
			SimpleCommand simpleCommand9 = new SimpleCommand();
			simpleCommand9.ExecuteDelegate = delegate(object o)
			{
				Editor.EnterIngame("FCXEditor", Editor.PlayMode.Play);
			};
			this.PlayIngameCommand = simpleCommand9;
			SimpleCommand simpleCommand10 = new SimpleCommand();
			simpleCommand10.ExecuteDelegate = delegate(object o)
			{
				Editor.EnterIngame("FCXEditor", Editor.PlayMode.Explore);
			};
			this.ExploreIngameCommand = simpleCommand10;
			this.ToolBumpCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolBump);
				}
			};
			this.ToolRaiseCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolRaise);
				}
			};
			this.ToolFlattenCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolFlatten);
				}
			};
			this.ToolSet2HeightCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolSet2Height);
				}
			};
			this.ToolSmoothCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolSmooth);
				}
			};
			this.ToolRampCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolRamp);
				}
			};
			this.ToolNoiseCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolNoise);
				}
			};
			this.ToolErosionCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolErosion);
				}
			};
			this.ToolHoleCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolHole);
				}
			};
			this.ToolWaterLayerCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolWaterLayer);
				}
			};
			this.ToolTextureCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolTexture);
				}
			};
			this.ToolCollectionCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolCollection);
				}
			};
			this.ToolRoadsCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolRoads);
				}
			};
			this.ToolPlayableZoneCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolPlayableZone);
				}
			};
			this.ToolEnviromentCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolEnv);
				}
			};
			this.ToolModifiersCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolGameProp);
				}
			};
			this.ToolSelectCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ToggleObjectToolMode(this._selectToggle);
				}
			};
			this.ToolMoveCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ToggleObjectToolMode(this._moveToggle);
				}
			};
			this.ToolRotateCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ToggleObjectToolMode(this._rotateToggle);
				}
			};
			this.ToolSnapCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ToggleObjectToolMode(this._snapToggle);
				}
			};
			this.ToolAddCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ToggleObjectToolMode(this._addToggle);
				}
			};
			this.ToolSpawnerCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ToggleObjectToolMode(this._spawnerToggle);
				}
			};
			this.ToolNavmeshCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this.ActivateTool(this._toolNavmesh);
				}
			};
			SimpleCommand simpleCommand11 = new SimpleCommand();
			simpleCommand11.ExecuteDelegate = delegate(object o)
			{
				Editor.Viewport.CameraSpeedUp();
			};
			this.CameraSpeedUpCommand = simpleCommand11;
			SimpleCommand simpleCommand12 = new SimpleCommand();
			simpleCommand12.ExecuteDelegate = delegate(object o)
			{
				Editor.Viewport.CameraSpeedDown();
			};
			this.CameraSpeedDownCommand = simpleCommand12;
			this.ToggleNavmeshCommand = new SimpleCommand
			{
				ExecuteDelegate = delegate(object o)
				{
					this._toolNavmesh.ToggleNavmesh();
				}
			};
			SimpleCommand simpleCommand13 = new SimpleCommand();
			simpleCommand13.ExecuteDelegate = delegate(object o)
			{
				MainWindowViewModel.CreateIssue();
			};
			this.CreateIssueCommand = simpleCommand13;
			SimpleCommand simpleCommand14 = new SimpleCommand();
			simpleCommand14.ExecuteDelegate = delegate(object o)
			{
				AboutWindow aboutWindow = new AboutWindow(true);
				aboutWindow.ShowDialog();
			};
			this.AboutCommand = simpleCommand14;
			SimpleCommand simpleCommand15 = new SimpleCommand();
			simpleCommand15.ExecuteDelegate = delegate(object o)
			{
				try
				{
					Process.Start("http://www.farcrygame.com");
				}
				catch (Exception)
				{
				}
			};
			this.VisitWebsiteCommand = simpleCommand15;
		}

		// Token: 0x04000060 RID: 96
		private ToolProperties _toolProperties;

		// Token: 0x04000061 RID: 97
		private ToolValidation _toolValidation;

		// Token: 0x04000062 RID: 98
		private ToolGameProperty _toolGameProp;

		// Token: 0x04000063 RID: 99
		private ToolPlayableZone _toolPlayableZone;

		// Token: 0x04000064 RID: 100
		private ToolEnvironment _toolEnv;

		// Token: 0x04000065 RID: 101
		private ToolTerrainBump _toolBump;

		// Token: 0x04000066 RID: 102
		private ToolTerrainRaiseLower _toolRaise;

		// Token: 0x04000067 RID: 103
		private ToolTerrainFlatten _toolFlatten;

		// Token: 0x04000068 RID: 104
		private ToolTerrainRamp _toolRamp;

		// Token: 0x04000069 RID: 105
		private ToolTerrainSetHeight _toolSet2Height;

		// Token: 0x0400006A RID: 106
		private ToolTerrainSmooth _toolSmooth;

		// Token: 0x0400006B RID: 107
		private ToolTerrainNoise _toolNoise;

		// Token: 0x0400006C RID: 108
		private ToolTerrainErosion _toolErosion;

		// Token: 0x0400006D RID: 109
		private ToolTerrainHole _toolHole;

		// Token: 0x0400006E RID: 110
		private ToolWater _toolWaterLayer;

		// Token: 0x0400006F RID: 111
		private ToolTexture _toolTexture;

		// Token: 0x04000070 RID: 112
		private ToolCollection _toolCollection;

		// Token: 0x04000071 RID: 113
		private ToolRoad _toolRoads;

		// Token: 0x04000072 RID: 114
		private ToolObject _toolObject;

		// Token: 0x04000073 RID: 115
		private ToolObjectModeToggle _selectToggle;

		// Token: 0x04000074 RID: 116
		private ToolObjectModeToggle _moveToggle;

		// Token: 0x04000075 RID: 117
		private ToolObjectModeToggle _rotateToggle;

		// Token: 0x04000076 RID: 118
		private ToolObjectModeToggle _snapToggle;

		// Token: 0x04000077 RID: 119
		private ToolObjectModeToggle _addToggle;

		// Token: 0x04000078 RID: 120
		private ToolObjectModeToggle _spawnerToggle;

		// Token: 0x04000079 RID: 121
		private ToolNavmesh _toolNavmesh;

		// Token: 0x0400007A RID: 122
		private readonly List<Tool> _tools = new List<Tool>();

		// Token: 0x0400007B RID: 123
		private readonly List<Tool> _toolObjectModes = new List<Tool>();

		// Token: 0x0400007C RID: 124
		private readonly Dictionary<Key, ToolBase> _toolShortcuts = new Dictionary<Key, ToolBase>();

		// Token: 0x0400007D RID: 125
		private ObservableCollection<object> _toolsMain;

		// Token: 0x0400007E RID: 126
		private ObservableCollection<ToolBase> _toolsTerrain;

		// Token: 0x0400007F RID: 127
		private ObservableCollection<object> _toolsObjects;

		// Token: 0x04000080 RID: 128
		private ObservableCollection<ToolBase> _toolsMap;

		// Token: 0x04000081 RID: 129
		private Tool _activeToolObjectMode;

		// Token: 0x04000082 RID: 130
		private Tool _activeTool;

		// Token: 0x04000083 RID: 131
		private readonly Dictionary<MainWindowViewModel.ShortKey, ICommand> _shortcutCommands;

		// Token: 0x04000084 RID: 132
		private CameraSpeedItem _currentSpeed;

		// Token: 0x04000085 RID: 133
		private ObservableCollection<CameraSpeedItem> _cameraSpeed;

		// Token: 0x04000086 RID: 134
		private string _defaultWinPos;

		// Token: 0x04000087 RID: 135
		private string _defaultLayout;

		// Token: 0x04000088 RID: 136
		private float _fps;

		// Token: 0x04000089 RID: 137
		private Vec3? _cursorPosition;

		// Token: 0x0400008A RID: 138
		private string _titleBar = "";

		// Token: 0x0400008B RID: 139
		private ulong _bootObjectiveId;

		// Token: 0x0400008C RID: 140
		private ulong _bootTerrainId;

		// Token: 0x0400008D RID: 141
		private string _bootMapName;

		// Token: 0x0400008E RID: 142
		private EditorSettingsViewModel _editorSettings;

		// Token: 0x0400008F RID: 143
		private ObjectPropertiesViewModel _objectProperties;

		// Token: 0x04000090 RID: 144
		private BudgetsViewModel _budgets;

		// Token: 0x04000091 RID: 145
		private MainMenu _mainMenu;

		// Token: 0x04000092 RID: 146
		private MainToolBarTray _mainToolBarTray;

		// Token: 0x04000093 RID: 147
		private FlowDocument _richContextHelpDocument;

		// Token: 0x04000094 RID: 148
		private bool _isDownloadedMap;

		// Token: 0x04000095 RID: 149
		private string _documentPath;

		// Token: 0x04000096 RID: 150
		private float _lastUpdate;

		// Token: 0x04000097 RID: 151
		private MainWindowViewModel.StatusBarMode _statusBarMode;

		// Token: 0x04000098 RID: 152
		private readonly ImageSource _hourglass;

		// Token: 0x04000099 RID: 153
		private ImageSource _statusIcon;

		// Token: 0x0400009A RID: 154
		private string _statusText;

		// Token: 0x0400009B RID: 155
		private Brush _statusColor;

		// Token: 0x0400009C RID: 156
		private Brush _statusBackground;

		// Token: 0x0400009D RID: 157
		private bool _cursorPhysics = true;

		// Token: 0x0400009E RID: 158
		private bool _currentCursorValid;

		// Token: 0x0400009F RID: 159
		private Vec3 _currentCursorPos;

		// Token: 0x040000A0 RID: 160
		private Vec3 _cameraPosition;

		// Token: 0x040000A1 RID: 161
		private bool _isUiEnabled;

		// Token: 0x040000A2 RID: 162
		private bool _toolParametersOpened;

		// Token: 0x040000A3 RID: 163
		private bool _contextHelpOpened;

		// Token: 0x040000A4 RID: 164
		private bool _editorSettingsOpened;

		// Token: 0x040000A5 RID: 165
		private bool _budgetsOpened;

		// Token: 0x040000A6 RID: 166
		private bool _objectPropsOpened;

		// Token: 0x040000A7 RID: 167
		private Visibility _uiVisibility;

		// Token: 0x040000A8 RID: 168
		private bool _canCopyFlag;

		// Token: 0x040000A9 RID: 169
		private bool _canPasteFlag;

		// Token: 0x0200002E RID: 46
		private struct ShortKey
		{
			// Token: 0x06000263 RID: 611 RVA: 0x0000757B File Offset: 0x0000577B
			public ShortKey(ModifierKeys m, Key k)
			{
				this._modifiers = m;
				this._key = k;
			}

			// Token: 0x040000F5 RID: 245
			private ModifierKeys _modifiers;

			// Token: 0x040000F6 RID: 246
			private Key _key;
		}

		// Token: 0x0200002F RID: 47
		private enum StatusBarMode
		{
			// Token: 0x040000F8 RID: 248
			None,
			// Token: 0x040000F9 RID: 249
			Loading,
			// Token: 0x040000FA RID: 250
			Navmesh,
			// Token: 0x040000FB RID: 251
			Ingame
		}
	}
}

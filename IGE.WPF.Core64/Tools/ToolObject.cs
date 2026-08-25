using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using IGE.Helpers;
using IGE.Nomad;
using IGE.Parameters;
using IGE.ViewModels;

namespace IGE.Tools
{
	// Token: 0x02000052 RID: 82
	internal class ToolObject : Tool, IInputSink
	{
		// Token: 0x0600037A RID: 890 RVA: 0x0000AE90 File Offset: 0x00009090
		public ToolObject() : base(Localizer.Localize("TOOL_OBJECT", null), "toolbar/objects/Object_Edit.png")
		{
			this._selectMode = new ToolObject.SelectMode(this);
			this._moveMode = new ToolObject.MoveMode(this);
			this._rotateMode = new ToolObject.RotateMode(this);
			this._snapMode = new ToolObject.SnapMode(this);
			this._addMode = new ToolObject.AddMode(this);
			this._spawnerMode = new ToolObject.SpawnerMode(this);
			string display = Localizer.Localize("PARAM_AXIS_TYPE", null);
			ParamEnumButtonText[] array = new ParamEnumButtonText[2];
			ParamEnumButtonText paramEnumButtonText = array[0] = new ParamEnumButtonText(Localizer.Localize("PARAM_AXIS_LOCAL", null), AxisType.Local);
			array[1] = new ParamEnumButtonText(Localizer.Localize("PARAM_AXIS_WORLD", null), AxisType.World);
			this._paramAxisType = new ParamEnumButton(display, array, delegate(object sender, object oldValue, object newValue)
			{
				this.axisType_ValueChanged((AxisType)newValue);
			});
			this._actionCopyClipboard.ButtonCommand.ExecuteDelegate = delegate(object o)
			{
				this.CopyToClipboard();
			};
			this._actionPasteFromClipboard.ButtonCommand.CanExecuteDelegate = ((object o) => this.CanPaste());
			this._actionPasteFromClipboard.ButtonCommand.ExecuteDelegate = delegate(object o)
			{
				this.PasteFromClipboard();
			};
			this._actionDelete.ButtonCommand.ExecuteDelegate = delegate(object o)
			{
				this.action_Delete();
			};
			this._actionFreeze.ButtonCommand.ExecuteDelegate = delegate(object o)
			{
				this.action_Freeze();
			};
			this._actionUnfreeze.ButtonCommand.ExecuteDelegate = delegate(object o)
			{
				this.action_Unfreeze();
			};
			this._actionGotoObject.ButtonCommand.ExecuteDelegate = delegate(object o)
			{
				this.action_GotoObject();
			};
			this._paramObjectSelection.SelectionChanged += delegate(object sender, EventArgs args)
			{
				this.action_SelectionValueChanged();
			};
			this._paramObjectSelection.OnDoubleClick.ExecuteDelegate = delegate(object o)
			{
				this.action_ItenDoubleClicked(o);
			};
			this._selectMode.Initialize();
			this._moveMode.Initialize();
			this._rotateMode.Initialize();
			this._snapMode.Initialize();
			this._addMode.Initialize();
			this._spawnerMode.Initialize();
			paramEnumButtonText.IsActive = true;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000B2BC File Offset: 0x000094BC
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this._currentTool;
			yield break;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000B2D9 File Offset: 0x000094D9
		internal IEnumerable<Parameter> GetParametersInternal()
		{
			return this.GetParameters();
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000B2E1 File Offset: 0x000094E1
		public override string GetContextHelp()
		{
			if (this.CurrentMode != null)
			{
				return this.CurrentMode.GetContextHelp();
			}
			return "";
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000B2FC File Offset: 0x000094FC
		private void UpdateParams()
		{
			bool enabled = this._selection.Count > 0;
			this._actionCopyClipboard.Enabled = this.CanCopy();
			this._actionDelete.Enabled = enabled;
			this._actionFreeze.Enabled = enabled;
			this._textSelected.DisplayName = this._selection.Count + " " + ((this._selection.Count > 1) ? Localizer.Localize("PARAM_OBJECTS_SELECTED_COUNT", null) : Localizer.Localize("PARAM_OBJECT_SELECTED_COUNT", null));
			this._paramObjectSelection.ObjectSelection = this._selection;
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0000B39D File Offset: 0x0000959D
		public void UpdateForMode(UpdateModeSource updateSource)
		{
			this._addMode.UpdateForMode(updateSource);
			this._spawnerMode.UpdateForMode(updateSource);
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000B3B7 File Offset: 0x000095B7
		private void ClearMode()
		{
			this.CurrentMode.IsActive = false;
			this.CurrentMode.Deactivate();
			Editor.PopInput(this.CurrentMode);
			this.CurrentMode = null;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000B3E2 File Offset: 0x000095E2
		private void SetMode(ToolObject.Mode mode)
		{
			Editor.PushInput(mode);
			this.CurrentMode = mode;
			this.CurrentMode.IsActive = true;
			mode.Activate();
			base.Parent.ContextHelp = this.GetContextHelp();
			mode.AfterActivate();
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000382 RID: 898 RVA: 0x0000B41A File Offset: 0x0000961A
		// (set) Token: 0x06000383 RID: 899 RVA: 0x0000B427 File Offset: 0x00009627
		private ToolObject.Mode CurrentMode
		{
			get
			{
				return this._currentTool.Tool;
			}
			set
			{
				this._currentTool.Tool = value;
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x0000B435 File Offset: 0x00009635
		public void SwitchMode(ToolObject.Mode mode)
		{
			if (mode == this.CurrentMode)
			{
				return;
			}
			if (this.CurrentMode != null)
			{
				this.ClearMode();
			}
			if (mode != null)
			{
				this.SetMode(mode);
			}
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000B459 File Offset: 0x00009659
		private void axisType_ValueChanged(AxisType value)
		{
			this.UpdateSelection(false, true);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0000B463 File Offset: 0x00009663
		private void action_Delete()
		{
			this.DeleteSelection();
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000B46C File Offset: 0x0000966C
		private void action_Freeze()
		{
			for (int i = 0; i < this._selection.Count; i++)
			{
				EditorObject editorObject = this._selection[i];
				editorObject.Frozen = true;
			}
			this.ClearSelection();
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000B4A9 File Offset: 0x000096A9
		private void action_Unfreeze()
		{
			ObjectManager.UnfreezeObjects();
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000B4B0 File Offset: 0x000096B0
		private void action_GotoObject()
		{
			if (this._paramObjectSelection.EditorObject == null || !this._paramObjectSelection.EditorObject.IsValid)
			{
				return;
			}
			ObjectInventory.Entry entry = this._paramObjectSelection.EditorObject.Entry;
			GameModeManager.EMapObjective enumObjectiveType = GameModeManager.GetEnumObjectiveType();
			if ((entry.IsAnimal && enumObjectiveType == GameModeManager.EMapObjective.EMapObjective_Poacher) || (entry.IsEnemy && enumObjectiveType != GameModeManager.EMapObjective.EMapObjective_Poacher) || entry.IsSpawner)
			{
				this.SwitchMode(this._spawnerMode);
				this._spawnerMode.SetGotoObject(entry);
				return;
			}
			this.SwitchMode(this._addMode);
			this._addMode.SetGotoObject(entry);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000B54B File Offset: 0x0000974B
		private void action_SelectionValueChanged()
		{
			this.UpdateGotoObject();
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000B554 File Offset: 0x00009754
		private void action_ItenDoubleClicked(object selectedItem)
		{
			EditorObjectViewModel editorObjectViewModel = selectedItem as EditorObjectViewModel;
			if (editorObjectViewModel != null)
			{
				EditorObject model = editorObjectViewModel.Model;
				this.ClearSelection();
				EditorObjectSelection selection = EditorObjectSelection.Create();
				this.SelectObject(selection, model);
				this.SetSelection(selection, model, true);
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600038C RID: 908 RVA: 0x0000B58F File Offset: 0x0000978F
		internal ToolObject.SelectMode ToolSelectMode
		{
			get
			{
				return this._selectMode;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0000B597 File Offset: 0x00009797
		internal ToolObject.MoveMode ToolMoveMode
		{
			get
			{
				return this._moveMode;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600038E RID: 910 RVA: 0x0000B59F File Offset: 0x0000979F
		internal ToolObject.RotateMode ToolRotateMode
		{
			get
			{
				return this._rotateMode;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600038F RID: 911 RVA: 0x0000B5A7 File Offset: 0x000097A7
		internal ToolObject.SnapMode ToolSnapMode
		{
			get
			{
				return this._snapMode;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0000B5AF File Offset: 0x000097AF
		internal ToolObject.AddMode ToolAddMode
		{
			get
			{
				return this._addMode;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000391 RID: 913 RVA: 0x0000B5B7 File Offset: 0x000097B7
		internal ToolObject.SpawnerMode ToolSpawnerMode
		{
			get
			{
				return this._spawnerMode;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000392 RID: 914 RVA: 0x0000B5C0 File Offset: 0x000097C0
		public bool IsInventoryObjectSelected
		{
			get
			{
				bool result = false;
				if (this.CurrentMode == this._addMode)
				{
					result = this._addMode.IsInventoryObjectSelected;
				}
				else if (this.CurrentMode == this._spawnerMode)
				{
					result = this._spawnerMode.IsInventoryObjectSelected;
				}
				return result;
			}
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000B606 File Offset: 0x00009806
		public override void Activate()
		{
			this.CreateSelection();
			this.SwitchMode(this._addMode);
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0000B61A File Offset: 0x0000981A
		public override void Deactivate()
		{
			this.SwitchMode(null);
			this.DestroySelection();
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000B629 File Offset: 0x00009829
		public override void OnSwitchFrom(ToolBase prevTool)
		{
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0000B62B File Offset: 0x0000982B
		public override void OnSwitchTo(ToolBase nextTool)
		{
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0000B62D File Offset: 0x0000982D
		public void OnInputAcquire()
		{
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000B62F File Offset: 0x0000982F
		public void OnInputRelease()
		{
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000B634 File Offset: 0x00009834
		public bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			switch (mouseEvent)
			{
			case Editor.MouseEvent.MouseDown:
			{
				bool flag = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
				if (flag && this.CurrentMode is ToolObject.AddMode)
				{
					this._localRotate = true;
					Editor.Viewport.CaptureMouse = true;
				}
				break;
			}
			case Editor.MouseEvent.MouseUp:
				if (this._localRotate)
				{
					this._localRotate = false;
					Editor.Viewport.CaptureMouse = false;
				}
				break;
			case Editor.MouseEvent.MouseMove:
				this.TestGizmo();
				break;
			case Editor.MouseEvent.MouseMoveDelta:
				if (this._selection.Count > 0 && this._localRotate)
				{
					float num = 0.025f * (float)mouseEventArgs.X;
					this._selection.LoadState();
					this._selection.RotateCenter(num, new Vec3(0f, 0f, 1f));
					this.CurrentMode.OnRotateSelection(num);
					this._selection.SaveState();
					this._selection.SnapToClosestObjects();
				}
				break;
			}
			return false;
		}

		// Token: 0x0600039A RID: 922 RVA: 0x0000B738 File Offset: 0x00009938
		public bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			if (keyEvent == Editor.KeyEvent.KeyUp)
			{
				Key keyCode = keyEventArgs.KeyCode;
				if (keyCode != Key.Escape)
				{
					if (keyCode == Key.Delete)
					{
						if (!this._addMode.IsNewObjectMode)
						{
							this.DeleteSelection();
						}
						return true;
					}
				}
				else if (this._selection.Count > 0)
				{
					this.ClearSelection();
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0000B788 File Offset: 0x00009988
		public void OnEditorEvent(uint eventType, IntPtr eventPtr)
		{
			if (eventType == EditorEventUndo.TypeId)
			{
				this.ClearSelectionState();
				this._selection.RemoveInvalidObjects();
				this._selection.ComputeCenter();
				this.UpdateSelectionState();
				this.UpdateSelection(false, true);
			}
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0000B7BC File Offset: 0x000099BC
		public void Update(float dt)
		{
			if (this._gizmo.IsValid)
			{
				this.UpdateGizmo();
				if (this._gizmoEnabled)
				{
					this._gizmo.Redraw();
				}
				else
				{
					this._gizmo.Hide();
				}
			}
			if (this._paramUseSelectionCenter.Value)
			{
				AABB worldBounds = this._selection.WorldBounds;
				Vec3 length = worldBounds.Length;
				Vec3 pos = worldBounds.min + length * 0.5f;
				pos.Z = worldBounds.min.Z;
				Render.DrawWireBoxFromBottomZ(pos, length, 0.005f);
			}
		}

		// Token: 0x0600039D RID: 925 RVA: 0x0000B854 File Offset: 0x00009A54
		public void CopyToClipboard()
		{
			ToolObject.NomadXmlObject nomadXmlObject = new ToolObject.NomadXmlObject();
			nomadXmlObject.NomadObj = this._selection.SaveToXml();
			DataObject dataObject = new DataObject();
			dataObject.SetData("NomadXmlObject", nomadXmlObject);
			Clipboard.SetDataObject(dataObject);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x0000B890 File Offset: 0x00009A90
		public void SetNoGameplayClipboard(bool value)
		{
			this._noGameplayObject = value;
		}

		// Token: 0x0600039F RID: 927 RVA: 0x0000B89C File Offset: 0x00009A9C
		public void PasteFromClipboard()
		{
			if (this.CanPaste())
			{
				DataObject dataObject = (DataObject)Clipboard.GetDataObject();
				ToolObject.NomadXmlObject nomadXmlObject = dataObject.GetData("NomadXmlObject") as ToolObject.NomadXmlObject;
				if (nomadXmlObject != null)
				{
					this.SwitchMode(this._addMode);
					if (this._selection.Count > 0)
					{
						this.DestroySelectionObjects();
						this.ClearSelection();
					}
					EditorObjectSelection editorObjectSelection = EditorObjectSelection.Create();
					editorObjectSelection.LoadFromXml(nomadXmlObject.NomadObj, true, this._noGameplayObject);
					editorObjectSelection.RotateCenter(0f, new Vec3(0f, 0f, 1f));
					editorObjectSelection.SaveState();
					Vec3 raySrc;
					Vec3 rayDir;
					Editor.GetWorldRayFromScreenPoint(Editor.Viewport.NormalizedMousePos, out raySrc, out rayDir);
					Vec3 pos;
					float num;
					Vec3 normal;
					if (Editor.RayCastPhysics(raySrc, rayDir, editorObjectSelection, out pos, out num, out normal))
					{
						editorObjectSelection.LoadState();
						foreach (EditorObject editorObject in this._selection.GetObjects())
						{
							if (editorObject.Entry.AutoOrientation)
							{
								Vec3 angles;
								editorObject.ComputeAutoOrientation(ref pos, out angles, normal);
								editorObject.Angles = angles;
							}
						}
						editorObjectSelection.MoveTo(pos, EditorObjectSelection.MoveMode.MoveNormal);
						editorObjectSelection.SnapToClosestObjects();
					}
					if (editorObjectSelection.Count > 0)
					{
						foreach (EditorObject editorObject2 in editorObjectSelection.GetObjects())
						{
							editorObject2.Visible = true;
							editorObject2.HighlightState = true;
						}
					}
					editorObjectSelection.SaveState();
					this._addMode.SetNewObject(editorObjectSelection);
				}
			}
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0000BA4C File Offset: 0x00009C4C
		public bool CanCopy()
		{
			return this.CurrentMode == this._selectMode && this._selection.IsValid && this._selection.Count > 0;
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0000BA79 File Offset: 0x00009C79
		public bool CanPaste()
		{
			return Clipboard.ContainsData("NomadXmlObject");
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0000BA85 File Offset: 0x00009C85
		private void CreateSelection()
		{
			this._selection = EditorObjectSelection.Create();
			this.UpdateSelection(false, true);
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0000BA9A File Offset: 0x00009C9A
		private void DestroySelection()
		{
			this.ClearSelection();
			this._selection.Dispose();
			this._paramObjectSelection.ObjectSelection = this._selection;
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0000BAC0 File Offset: 0x00009CC0
		private void DestroySelectionObjects()
		{
			foreach (EditorObject editorObject in this._selection.GetObjects())
			{
				editorObject.Destroy();
			}
			this.ClearSelection();
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0000BB18 File Offset: 0x00009D18
		private void ClearSelectionState()
		{
			for (int i = 0; i < this._selection.Count; i++)
			{
				EditorObject editorObject = this._selection[i];
				editorObject.HighlightState = false;
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000BB50 File Offset: 0x00009D50
		private void UpdateSelectionState()
		{
			for (int i = 0; i < this._selection.Count; i++)
			{
				EditorObject editorObject = this._selection[i];
				editorObject.HighlightState = true;
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000BB87 File Offset: 0x00009D87
		private void ClearSelection()
		{
			this.ClearSelectionState();
			this.ClearGizmo();
			this._selection.Clear();
			this.UpdateSelection(false, true);
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000BBA8 File Offset: 0x00009DA8
		public void SetSelection(EditorObjectSelection selection, EditorObject gizmoObject, bool notify = true)
		{
			this.ClearSelectionState();
			this._selection.Dispose();
			this._selection = selection;
			this._selection.ComputeCenter();
			if (!this._selection.Contains(gizmoObject))
			{
				gizmoObject = EditorObject.Null;
			}
			if (!gizmoObject.IsValid && this._selection.Count > 0)
			{
				gizmoObject = this._selection[0];
			}
			if (gizmoObject.IsValid)
			{
				this.SetupGizmo(gizmoObject);
			}
			else
			{
				this.ClearGizmo();
			}
			this.UpdateSelectionState();
			this.UpdateSelection(false, true);
			this.UpdateGizmoAxes();
			if (notify)
			{
				ToolObject.OnSelectionChanged(selection);
			}
			this._paramObjectSelection.SelectedObject = this._paramObjectSelection.Items.FirstOrDefault<EditorObjectViewModel>();
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0000BC68 File Offset: 0x00009E68
		private void UpdateGotoObject()
		{
			bool flag = this._paramObjectSelection.EditorObject != null && this._paramObjectSelection.EditorObject.IsValid && this._paramObjectSelection.EditorObject.Entry != null;
			this._actionGotoObject.Enabled = (this._selection.Count > 0 && this._paramObjectSelection.SelectedObject != null && flag);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000BCDE File Offset: 0x00009EDE
		private void UpdateSelection(bool updateCenter = false, bool selectionChanged = true)
		{
			if (updateCenter)
			{
				this._selection.ComputeCenter();
			}
			this.UpdateGizmo();
			if (selectionChanged)
			{
				this.UpdateParams();
			}
			if (this.CurrentMode != null)
			{
				this.CurrentMode.UpdateParams();
			}
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000BD10 File Offset: 0x00009F10
		private void DeleteSelection()
		{
			if (this._selection.Count == 0)
			{
				return;
			}
			BudgetManager.UpdateBudgetWarningStatus(this._selection, true);
			UndoManager.RecordUndo();
			this._selection.Delete();
			UndoManager.CommitUndo();
			this.UpdateSelection(false, true);
		}

		// Token: 0x060003AC RID: 940 RVA: 0x0000BD4C File Offset: 0x00009F4C
		private void SelectObject(EditorObjectSelection selection, EditorObject obj)
		{
			bool flag = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
			if (!Keyboard.IsKeyDown(Key.LeftShift))
			{
				Keyboard.IsKeyDown(Key.RightShift);
			}
			bool flag2 = Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt);
			if (this._paramMagicWand.Value)
			{
				using (EditorObjectSelection selection2 = EditorObjectSelection.Create())
				{
					ObjectManager.GetObjectsFromMagicWand(selection2, obj);
					if (flag)
					{
						selection.ToggleSelection(selection2);
					}
					else if (flag2)
					{
						selection.RemoveSelection(selection2);
					}
					else
					{
						selection.AddSelection(selection2);
					}
				}
				return;
			}
			if (flag)
			{
				selection.ToggleObject(obj);
				return;
			}
			if (flag2)
			{
				selection.RemoveObject(obj);
				return;
			}
			selection.AddObject(obj);
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060003AD RID: 941 RVA: 0x0000BE10 File Offset: 0x0000A010
		public EditorObjectSelection Selection
		{
			get
			{
				return this._selection;
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0000BE18 File Offset: 0x0000A018
		private void ClearGizmo()
		{
			if (this._gizmo.IsValid)
			{
				this._gizmo.Dispose();
				this._gizmo = Gizmo.Null;
			}
			this._gizmoObject = EditorObject.Null;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000BE48 File Offset: 0x0000A048
		private void SetupGizmo(EditorObject gizmoObject)
		{
			this.ClearGizmo();
			this._gizmo = Gizmo.Create();
			this._gizmo.RotationMode = this._gizmoRotationMode;
			this._gizmoObject = gizmoObject;
			this.UpdateGizmo();
			this.TestGizmo();
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000BE80 File Offset: 0x0000A080
		private void UpdateGizmo()
		{
			if (!this._gizmo.IsValid)
			{
				return;
			}
			if (this._selection.Count == 0)
			{
				this.ClearGizmo();
				return;
			}
			if (!this._paramUseSelectionCenter.Value)
			{
				CoordinateSystem coordinateSystem = CoordinateSystem.FromAngles(this._gizmoObject.Angles);
				this._gizmo.Axis = (((AxisType)this._paramAxisType.Value == AxisType.World) ? CoordinateSystem.Standard : coordinateSystem);
				this._gizmo.Position = this._gizmoObject.Position;
				return;
			}
			this._gizmo.Axis = CoordinateSystem.Standard;
			this._gizmo.Position = this._selection.GetComputeCenter();
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000BF30 File Offset: 0x0000A130
		private void TestGizmo()
		{
			if (this._gizmo.IsValid && this._gizmoEnabled)
			{
				Vec3 raySrc;
				Vec3 rayDir;
				Editor.GetWorldRayFromScreenPoint(Editor.Viewport.NormalizedMousePos, out raySrc, out rayDir);
				Axis axis = this._gizmo.HitTest(raySrc, rayDir);
				this._gizmo.Active = axis;
				this._gizmoActive = (axis != Axis.None);
				return;
			}
			this._gizmoActive = false;
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x0000BF94 File Offset: 0x0000A194
		private void EnableGizmo(bool enable)
		{
			this._gizmoEnabled = enable;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000BF9D File Offset: 0x0000A19D
		private void SetGizmoRotationMode(bool enable)
		{
			this._gizmoRotationMode = enable;
			if (this._gizmo.IsValid)
			{
				this._gizmo.RotationMode = enable;
				this.UpdateGizmoAxes();
			}
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000BFC8 File Offset: 0x0000A1C8
		private void UpdateGizmoAxes()
		{
			if (this._gizmo.IsValid)
			{
				this._gizmo.ResetAxes();
				if (this._gizmo.RotationMode && this._selection.IsAxesXYLocked())
				{
					this._gizmo.EnableAxis(Axis.XY, false);
				}
			}
		}

		// Token: 0x04000176 RID: 374
		private readonly ParamText _textSelected = new ParamText("");

		// Token: 0x04000177 RID: 375
		private readonly ParamBool _paramUseSelectionCenter = new ParamBool(Localizer.LocalizeCommon("PARAM_OBJECT_SELECTION_USE_CENTER"), false);

		// Token: 0x04000178 RID: 376
		private readonly ParamBool _paramMagicWand = new ParamBool(Localizer.Localize("PARAM_OBJECT_MAGIC_WAND", null), false);

		// Token: 0x04000179 RID: 377
		private readonly ParamEnumButton _paramAxisType;

		// Token: 0x0400017A RID: 378
		private readonly ParamButton _actionCopyClipboard = new ParamButton(Localizer.Localize("PARAM_SELECTION_COPY_CLIPBOARD", null));

		// Token: 0x0400017B RID: 379
		private readonly ParamButton _actionPasteFromClipboard = new ParamButton(Localizer.Localize("PARAM_SELECTION_PASTE_CLIPBOARD", null));

		// Token: 0x0400017C RID: 380
		private readonly ParamButton _actionDelete = new ParamButton(Localizer.Localize("PARAM_SELECTION_DELETE", null));

		// Token: 0x0400017D RID: 381
		private readonly ParamButton _actionFreeze = new ParamButton(Localizer.Localize("PARAM_SELECTION_FREEZE", null));

		// Token: 0x0400017E RID: 382
		private readonly ParamButton _actionUnfreeze = new ParamButton(Localizer.Localize("PARAM_SELECTION_UNFREEZE", null));

		// Token: 0x0400017F RID: 383
		private readonly ParamObjectSelection _paramObjectSelection = new ParamObjectSelection(Localizer.Localize("PARAM_OBJECT_SELECTION", null));

		// Token: 0x04000180 RID: 384
		private readonly ParamButton _actionGotoObject = new ParamButton(Localizer.Localize("PARAM_GOTO_OBJECT", null));

		// Token: 0x04000181 RID: 385
		private bool _localRotate;

		// Token: 0x04000182 RID: 386
		private readonly ToolObject.SelectMode _selectMode;

		// Token: 0x04000183 RID: 387
		private readonly ToolObject.MoveMode _moveMode;

		// Token: 0x04000184 RID: 388
		private readonly ToolObject.RotateMode _rotateMode;

		// Token: 0x04000185 RID: 389
		private readonly ToolObject.SnapMode _snapMode;

		// Token: 0x04000186 RID: 390
		private readonly ToolObject.AddMode _addMode;

		// Token: 0x04000187 RID: 391
		private ToolObject.SpawnerMode _spawnerMode;

		// Token: 0x04000188 RID: 392
		private readonly ParamTool _currentTool = new ParamTool(null);

		// Token: 0x04000189 RID: 393
		public static SelectionChangedHandler OnSelectionChanged;

		// Token: 0x0400018A RID: 394
		public static Action OnNewInstanceCreated;

		// Token: 0x0400018B RID: 395
		private bool _noGameplayObject;

		// Token: 0x0400018C RID: 396
		private EditorObjectSelection _selection;

		// Token: 0x0400018D RID: 397
		private Gizmo _gizmo;

		// Token: 0x0400018E RID: 398
		private bool _gizmoActive;

		// Token: 0x0400018F RID: 399
		private EditorObject _gizmoObject;

		// Token: 0x04000190 RID: 400
		private bool _gizmoEnabled;

		// Token: 0x04000191 RID: 401
		private bool _gizmoRotationMode;

		// Token: 0x02000053 RID: 83
		public abstract class Mode : Tool, IInputSink
		{
			// Token: 0x060003BF RID: 959 RVA: 0x0000C014 File Offset: 0x0000A214
			protected Mode(string displayName, string imageFilename, ToolObject context) : base(displayName, imageFilename)
			{
				this._context = context;
			}

			// Token: 0x060003C0 RID: 960 RVA: 0x0000C0D0 File Offset: 0x0000A2D0
			protected override IEnumerable<Parameter> GetParameters()
			{
				yield break;
			}

			// Token: 0x060003C1 RID: 961 RVA: 0x0000C0ED File Offset: 0x0000A2ED
			public virtual void UpdateParams()
			{
			}

			// Token: 0x060003C2 RID: 962 RVA: 0x0000C0EF File Offset: 0x0000A2EF
			public virtual void AfterActivate()
			{
			}

			// Token: 0x060003C3 RID: 963 RVA: 0x0000C0F1 File Offset: 0x0000A2F1
			public virtual void OnInputAcquire()
			{
			}

			// Token: 0x060003C4 RID: 964 RVA: 0x0000C0F3 File Offset: 0x0000A2F3
			public virtual void OnInputRelease()
			{
			}

			// Token: 0x060003C5 RID: 965 RVA: 0x0000C0F5 File Offset: 0x0000A2F5
			public virtual bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				return false;
			}

			// Token: 0x060003C6 RID: 966 RVA: 0x0000C0F8 File Offset: 0x0000A2F8
			public virtual bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
			{
				return false;
			}

			// Token: 0x060003C7 RID: 967 RVA: 0x0000C0FB File Offset: 0x0000A2FB
			public virtual void OnEditorEvent(uint eventType, IntPtr eventPtr)
			{
			}

			// Token: 0x060003C8 RID: 968 RVA: 0x0000C0FD File Offset: 0x0000A2FD
			public virtual void OnRotateSelection(float value)
			{
			}

			// Token: 0x060003C9 RID: 969 RVA: 0x0000C0FF File Offset: 0x0000A2FF
			public virtual void Update(float dt)
			{
			}

			// Token: 0x04000192 RID: 402
			protected ToolObject _context;
		}

		// Token: 0x02000054 RID: 84
		public class SnapMode : ToolObject.Mode
		{
			// Token: 0x060003CA RID: 970 RVA: 0x0000C104 File Offset: 0x0000A304
			public SnapMode(ToolObject context) : base(Localizer.Localize("TOOL_OBJECT_MODE_SNAP", null) + " (4)", "tools/objects/Tool_Link.png", context)
			{
				this._paramUseSnapAngle = new ParamBool(Localizer.Localize("PARAM_USE_SNAP_ANGLES", null), new ValueParameter<bool>.ValueChangedDelegate(this.SetUseSnapAngle));
				this._paramPreserveOrientation = new ParamBool(Localizer.Localize("PARAM_PRESERVE_ORIENTATION", null), new ValueParameter<bool>.ValueChangedDelegate(this.SetPreserveOrientation));
				string display = Localizer.Localize("PARAM_SNAP_ANGLE", null);
				ParamEnumButtonText[] array = new ParamEnumButtonText[5];
				array[0] = new ParamEnumButtonText(5f);
				array[1] = new ParamEnumButtonText(10f);
				array[2] = new ParamEnumButtonText(20f);
				array[3] = new ParamEnumButtonText(45f);
				ParamEnumButtonText paramEnumButtonText = array[4] = new ParamEnumButtonText(90f);
				this._paramSnapAngle = new ParamEnumButton(display, array);
				string display2 = Localizer.Localize("PARAM_ANGLE_DIRECTION", null);
				ParamEnumButtonText[] array2 = new ParamEnumButtonText[2];
				array2[0] = new ParamEnumButtonText(RotationDirection.CW);
				ParamEnumButtonText paramEnumButtonText2 = array2[1] = new ParamEnumButtonText(RotationDirection.CCW);
				this._paramAngleDir = new ParamEnumButton(display2, array2);
				paramEnumButtonText.IsActive = true;
				paramEnumButtonText2.IsActive = true;
				this._paramUseSnapAngle.Value = false;
				this._paramPreserveOrientation.Value = false;
			}

			// Token: 0x060003CB RID: 971 RVA: 0x0000C252 File Offset: 0x0000A452
			public override string GetContextHelp()
			{
				return Localizer.LocalizeCommon("HELP_TOOL_SNAPOBJECT") + "\r\n\r\n" + Localizer.Localize("HELP_TOOL_SNAPOBJECT", null);
			}

			// Token: 0x060003CC RID: 972 RVA: 0x0000C464 File Offset: 0x0000A664
			protected override IEnumerable<Parameter> GetParameters()
			{
				yield return this._context._textSelected;
				yield return this._paramUseSnapAngle;
				yield return this._paramSnapAngle;
				yield return this._paramAngleDir;
				yield return this._paramPreserveOrientation;
				yield return this._context._actionDelete;
				yield return this._context._paramObjectSelection;
				yield return this._context._actionGotoObject;
				yield break;
			}

			// Token: 0x060003CD RID: 973 RVA: 0x0000C484 File Offset: 0x0000A684
			private void SetPreserveOrientation(bool set)
			{
				this._paramUseSnapAngle.Enabled = !set;
				this._paramSnapAngle.Enabled = (!set && this._paramUseSnapAngle.Value);
				this._paramAngleDir.Enabled = (!set && this._paramUseSnapAngle.Value);
			}

			// Token: 0x060003CE RID: 974 RVA: 0x0000C4D8 File Offset: 0x0000A6D8
			private void SetUseSnapAngle(bool set)
			{
				this._paramSnapAngle.Enabled = (!this._paramPreserveOrientation.Value && set);
				this._paramAngleDir.Enabled = (!this._paramPreserveOrientation.Value && set);
			}

			// Token: 0x060003CF RID: 975 RVA: 0x0000C514 File Offset: 0x0000A714
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				if (mouseEvent == Editor.MouseEvent.MouseDown)
				{
					ToolObject.SnapAction snapAction = new ToolObject.SnapAction(this._context)
					{
						PreserveOrientation = this._paramPreserveOrientation.Value
					};
					if (this._paramUseSnapAngle.Value)
					{
						snapAction.AngleSnap = MathUtils.Deg2Rad(((RotationDirection)this._paramAngleDir.Value == RotationDirection.CCW) ? ((float)this._paramSnapAngle.Value) : (-(float)this._paramSnapAngle.Value));
					}
					if (!snapAction.Start())
					{
						ToolObject.SelectAction selectAction = new ToolObject.SelectAction(this._context);
						selectAction.Start();
					}
				}
				return false;
			}

			// Token: 0x04000193 RID: 403
			private readonly ParamBool _paramUseSnapAngle;

			// Token: 0x04000194 RID: 404
			private readonly ParamEnumButton _paramSnapAngle;

			// Token: 0x04000195 RID: 405
			private readonly ParamEnumButton _paramAngleDir;

			// Token: 0x04000196 RID: 406
			private readonly ParamBool _paramPreserveOrientation;
		}

		// Token: 0x02000055 RID: 85
		public class MoveMode : ToolObject.Mode
		{
			// Token: 0x060003D0 RID: 976 RVA: 0x0000C5C8 File Offset: 0x0000A7C8
			public MoveMode(ToolObject context) : base(Localizer.Localize("TOOL_OBJECT_MODE_MOVE", null) + " (2)", "tools/objects/Tool_Move.png", context)
			{
				this._paramPosition = new ParamVector(Localizer.Localize("PARAM_POSITION", null), ParamVectorUIType.Position, new ParamVector.ValueChangedDelegate(this.position_ValueChanged));
				this._paramSnap = new ParamBool(Localizer.Localize("PARAM_USE_SNAP_GRID", null), new ValueParameter<bool>.ValueChangedDelegate(this.SetSnap));
				this._paramSnapObjectSize = new ParamBool(Localizer.Localize("PARAM_SNAP_OBJECT_SIZE", null), new ValueParameter<bool>.ValueChangedDelegate(this.SetSnapObjectSize));
				this._paramUseGizmos = new ParamBool(Localizer.Localize("PARAM_USE_GIZMO", null), delegate(bool value)
				{
					this._context.EnableGizmo(value);
				});
				this._paramSnap.Value = false;
				this._paramSnapObjectSize.Value = false;
				this._paramUseGizmos.Value = true;
				this._actionAlignToObject = new ParamCheckButton(Localizer.Localize("PARAM_ALIGN_TO_OBJECT", null));
				this._actionDropToPhysics.ButtonCommand.ExecuteDelegate = delegate(object o)
				{
					this.action_DropToPhysics();
				};
			}

			// Token: 0x060003D1 RID: 977 RVA: 0x0000C73C File Offset: 0x0000A93C
			public override string GetContextHelp()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(Localizer.Localize("HELP_CONTROLS_ROTATE_MOVEOBJECT", null)).Append("\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_DELETE_OBJECT", null)).Append("\r\n");
				stringBuilder.Append("\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_TOOL_MOVEOBJECT", null)).Append("\r\n\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_GROUP_SELECTION", null)).Append("\r\n\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_NEIGHBORHOOD_SELECTION", null)).Append("\r\n\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_AXIS_TYPE", null));
				return stringBuilder.ToString();
			}

			// Token: 0x060003D2 RID: 978 RVA: 0x0000CAE4 File Offset: 0x0000ACE4
			protected override IEnumerable<Parameter> GetParameters()
			{
				yield return this._context._textSelected;
				yield return this._context._paramUseSelectionCenter;
				yield return this._context._paramMagicWand;
				yield return this._context._paramAxisType;
				yield return this._paramPosition;
				yield return this._paramSnap;
				yield return this._paramSnapSize;
				yield return this._paramSnapObjectSize;
				yield return this._paramUseGizmos;
				yield return this._actionAlignToObject;
				yield return this._actionDropToPhysics;
				yield return this._context._actionDelete;
				yield return this._context._paramObjectSelection;
				yield return this._context._actionGotoObject;
				yield break;
			}

			// Token: 0x060003D3 RID: 979 RVA: 0x0000CB04 File Offset: 0x0000AD04
			public override void UpdateParams()
			{
				if ((AxisType)this._context._paramAxisType.Value == AxisType.World && this._context._selection.Count > 0)
				{
					this._paramPosition.Value = this._context._selection.Center;
				}
				else
				{
					this._paramPosition.Value = default(Vec3);
				}
				bool enabled = this._context._selection.Count > 0;
				this._actionAlignToObject.Enabled = enabled;
				this._actionDropToPhysics.Enabled = enabled;
			}

			// Token: 0x060003D4 RID: 980 RVA: 0x0000CB9C File Offset: 0x0000AD9C
			private void position_ValueChanged(Vec3 value)
			{
				if (this._context._selection.Count == 0)
				{
					return;
				}
				UndoManager.RecordUndo();
				this._context._selection.ComputeCenter();
				switch ((AxisType)this._context._paramAxisType.Value)
				{
				case AxisType.Local:
					if (this._context._selection.Count == 1)
					{
						this._context._selection.MoveTo(this._context._selection.Center + CoordinateSystem.FromAngles(this._context._selection[0].Angles).ConvertToWorld(value), EditorObjectSelection.MoveMode.MoveNormal);
					}
					else
					{
						this._context._selection.MoveTo(this._context._selection.Center + value, EditorObjectSelection.MoveMode.MoveNormal);
					}
					this._paramPosition.Value = default(Vec3);
					break;
				case AxisType.World:
					this._context._selection.MoveTo(value, EditorObjectSelection.MoveMode.MoveNormal);
					break;
				}
				UndoManager.CommitUndo();
				this._context.UpdateSelection(false, false);
			}

			// Token: 0x060003D5 RID: 981 RVA: 0x0000CCBD File Offset: 0x0000AEBD
			private void SetSnap(bool value)
			{
				this._paramSnapSize.Enabled = (value && !this._paramSnapObjectSize.Value);
				this._paramSnapObjectSize.Enabled = value;
			}

			// Token: 0x060003D6 RID: 982 RVA: 0x0000CCEA File Offset: 0x0000AEEA
			private void SetSnapObjectSize(bool value)
			{
				this._paramSnapSize.Enabled = (this._paramSnap.Value && !value);
			}

			// Token: 0x060003D7 RID: 983 RVA: 0x0000CD0C File Offset: 0x0000AF0C
			private void AlignSelection(Vec3 position, Vec3 angles)
			{
				int num = (this._context._gizmoObject != null) ? this._context._selection.IndexOf(this._context._gizmoObject) : 0;
				num = ((num >= 0) ? num : 0);
				Vec3 angles2 = this._context.Selection[num].Angles;
				this._context.Selection.Rotate(angles.X - angles2.X, CoordinateSystem.FromAngles(this._context.Selection[num].Angles).ConvertToWorld(new Vec3(1f, 0f, 0f)), this._context.Selection[num].Position, false);
				this._context.Selection.Rotate(angles.Y - angles2.Y, CoordinateSystem.FromAngles(this._context.Selection[num].Angles).ConvertToWorld(new Vec3(0f, 1f, 0f)), this._context.Selection[num].Position, false);
				this._context.Selection.Rotate(angles.Z - angles2.Z, CoordinateSystem.FromAngles(this._context.Selection[num].Angles).ConvertToWorld(new Vec3(0f, 0f, 1f)), this._context.Selection[num].Position, false);
				Vec3 position2 = this._context.Selection[num].Position;
				this._context.Selection[num].Position = position;
				for (int i = 0; i < this._context.Selection.Count; i++)
				{
					if (i != num)
					{
						this._context.Selection[i].Position = position - (position2 - this._context.Selection[i].Position);
					}
				}
			}

			// Token: 0x060003D8 RID: 984 RVA: 0x0000CF78 File Offset: 0x0000B178
			private bool OnAlignToObjectMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				switch (mouseEvent)
				{
				case Editor.MouseEvent.MouseUp:
					if (this._context._selection.Count != 0)
					{
						int num = (this._context._gizmoObject != null) ? this._context._selection.IndexOf(this._context._gizmoObject) : 0;
						num = ((num >= 0) ? num : 0);
						Vec3 position = this._context._selection[num].Position;
						Vec3 angles = this._context._selection[num].Angles;
						this._context._selection.LoadState();
						UndoManager.RecordUndo();
						this.AlignSelection(position, angles);
						UndoManager.CommitUndo();
						this._context._selection.SaveState();
						this._actionAlignToObject.IsChecked = false;
					}
					break;
				case Editor.MouseEvent.MouseMove:
				{
					this._context._selection.LoadState();
					Vec3 vec;
					Vec3 vec2;
					Editor.GetWorldRayFromScreenPoint(Editor.Viewport.NormalizedMousePos, out vec, out vec2);
					Vec3 vec3;
					EditorObject objectFromScreenPoint = ObjectManager.GetObjectFromScreenPoint(Editor.Viewport.NormalizedMousePos, out vec3, false, this._context._selection);
					if (objectFromScreenPoint.IsValid)
					{
						this.AlignSelection(objectFromScreenPoint.Position, objectFromScreenPoint.Angles);
					}
					break;
				}
				}
				return false;
			}

			// Token: 0x060003D9 RID: 985 RVA: 0x0000D0C8 File Offset: 0x0000B2C8
			private void action_DropToPhysics()
			{
				UndoManager.RecordUndo();
				this._context._selection.DropToGround(true, this._context._paramUseSelectionCenter.Value);
				UndoManager.CommitUndo();
				this._context.UpdateSelection(false, true);
			}

			// Token: 0x060003DA RID: 986 RVA: 0x0000D102 File Offset: 0x0000B302
			public override void Activate()
			{
				this._context.EnableGizmo(this._paramUseGizmos.Value);
				this._context.SetGizmoRotationMode(false);
				this.UpdateParams();
			}

			// Token: 0x060003DB RID: 987 RVA: 0x0000D12C File Offset: 0x0000B32C
			public override void Deactivate()
			{
				this._context.EnableGizmo(false);
				this._actionAlignToObject.IsChecked = false;
			}

			// Token: 0x060003DC RID: 988 RVA: 0x0000D148 File Offset: 0x0000B348
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				if (this._actionAlignToObject.IsChecked)
				{
					return this.OnAlignToObjectMouseEvent(mouseEvent, mouseEventArgs);
				}
				if (mouseEvent == Editor.MouseEvent.MouseDown)
				{
					if (this._context._gizmoActive)
					{
						UndoManager.RecordUndo();
						if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
						{
							if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
							{
								EditorObjectSelection editorObjectSelection = EditorObjectSelection.Create();
								this._context._selection.Clone(editorObjectSelection, true);
								int num = this._context._selection.IndexOf(this._context._gizmoObject);
								this._context.SetSelection(editorObjectSelection, (num != -1) ? editorObjectSelection[num] : EditorObject.Null, true);
							}
							ToolObject.MoveAction moveAction = new ToolObject.MoveAction(this._context);
							if (this._paramSnap.Value)
							{
								if (this._paramSnapObjectSize.Value && this._context._gizmoObject.IsValid)
								{
									moveAction.SetSnap(this._context._gizmoObject);
								}
								else
								{
									moveAction.SetSnap(this._paramSnapSize.Value);
								}
							}
							moveAction.Start(this._context._gizmo.Position);
						}
						else
						{
							ToolObject.RotateAction rotateAction = new ToolObject.RotateAction(this._context);
							Vec3 rotationAxis = default(Vec3);
							switch (this._context._gizmo.Active)
							{
							case Axis.X:
								rotationAxis = this._context._gizmo.Axis.axisX;
								break;
							case Axis.Y:
								rotationAxis = this._context._gizmo.Axis.axisY;
								break;
							case Axis.Z:
								rotationAxis = this._context._gizmo.Axis.axisZ;
								break;
							}
							rotateAction.Start(this._context._gizmo.Position, rotationAxis);
						}
					}
					else
					{
						UndoManager.RecordUndo();
						bool flag = true;
						Vec3 vec;
						EditorObject objectFromScreenPoint = ObjectManager.GetObjectFromScreenPoint(Editor.Viewport.NormalizedMousePos, out vec);
						if (objectFromScreenPoint.IsValid)
						{
							if (!this._context._selection.Contains(objectFromScreenPoint))
							{
								EditorObjectSelection editorObjectSelection2 = EditorObjectSelection.Create();
								if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
								{
									this._context._selection.Clone(editorObjectSelection2, false);
								}
								this._context.SelectObject(editorObjectSelection2, objectFromScreenPoint);
								this._context.SetSelection(editorObjectSelection2, objectFromScreenPoint, true);
							}
							else
							{
								this._context.SetupGizmo(objectFromScreenPoint);
							}
							EditorObjectPivot editorObjectPivot;
							Vec3 position;
							if (this._paramGrabAnchor.Value && objectFromScreenPoint.GetClosestPivot(vec, out editorObjectPivot, (objectFromScreenPoint.Position - vec).Length * 1.1f))
							{
								position = editorObjectPivot.position;
							}
							else
							{
								position = objectFromScreenPoint.Position;
							}
							ToolObject.MovePhysicsAction movePhysicsAction = new ToolObject.MovePhysicsAction(this._context);
							movePhysicsAction.Start(position);
							flag = false;
						}
						if (flag)
						{
							ToolObject.SelectAction selectAction = new ToolObject.SelectAction(this._context);
							selectAction.Start();
						}
					}
				}
				return false;
			}

			// Token: 0x060003DD RID: 989 RVA: 0x0000D450 File Offset: 0x0000B650
			public override bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
			{
				switch (keyEvent)
				{
				case Editor.KeyEvent.KeyDown:
				{
					Key keyCode = keyEventArgs.KeyCode;
					switch (keyCode)
					{
					case Key.Left:
					case Key.Up:
					case Key.Right:
					case Key.Down:
						this._keyStart = keyEventArgs.KeyCode;
						if (!this._keyMoving)
						{
							this._keyMoving = true;
							UndoManager.RecordUndo();
						}
						break;
					default:
						switch (keyCode)
						{
						case Key.LeftCtrl:
						case Key.RightCtrl:
							this._context.SetGizmoRotationMode(true);
							break;
						}
						break;
					}
					break;
				}
				case Editor.KeyEvent.KeyChar:
					if (this._keyMoving && keyEventArgs.KeyCode == this._keyStart && this._context._gizmo.IsValid)
					{
						Vec3 vec = default(Vec3);
						Vec3 vec2 = default(Vec3);
						switch (this._keyStart)
						{
						case Key.Left:
							if (!keyEventArgs.Control)
							{
								vec.X = -1f;
							}
							else
							{
								vec2.Z = -1f;
							}
							break;
						case Key.Up:
							if (!keyEventArgs.Control)
							{
								vec.Y = 1f;
							}
							else
							{
								vec.Z = 1f;
							}
							break;
						case Key.Right:
							if (!keyEventArgs.Control)
							{
								vec.X = 1f;
							}
							else
							{
								vec2.Z = 1f;
							}
							break;
						case Key.Down:
							if (!keyEventArgs.Control)
							{
								vec.Y = -1f;
							}
							else
							{
								vec.Z = -1f;
							}
							break;
						}
						CoordinateSystem axis = Camera.Axis;
						CoordinateSystem axis2 = this._context._gizmo.Axis;
						float value = Vec3.Dot(axis2.axisX, axis.axisX);
						float value2 = Vec3.Dot(axis2.axisY, axis.axisX);
						Vec3 vec3;
						if (Math.Abs(value) > Math.Abs(value2))
						{
							vec3 = axis2.axisX * vec.X * (float)Math.Sign(value) + axis2.axisY * vec.Y * (float)Math.Sign(Vec3.Dot(axis2.axisY, axis.axisZ));
						}
						else
						{
							vec3 = axis2.axisY * vec.X * (float)Math.Sign(value2) + axis2.axisX * vec.Y * (float)Math.Sign(Vec3.Dot(axis2.axisX, axis.axisZ));
						}
						vec3 += axis2.axisZ * vec.Z * (float)Math.Sign(Vec3.Dot(axis2.axisZ, axis.axisZ));
						if (keyEventArgs.Shift)
						{
							vec3 *= 0.0025f;
							vec2 *= MathUtils.Deg2Rad(0.25f);
						}
						else
						{
							vec3 *= 0.01f;
							vec2 *= MathUtils.Deg2Rad(1f);
						}
						this._context._selection.Center = this._context._gizmo.Position;
						this._context._selection.MoveTo(this._context._gizmo.Position + vec3, EditorObjectSelection.MoveMode.MoveNormal);
						this._context._selection.Rotate(vec2, axis2.ToAngles(), this._context._gizmo.Position, false);
					}
					break;
				case Editor.KeyEvent.KeyUp:
					if (this._keyMoving && keyEventArgs.KeyCode == this._keyStart)
					{
						UndoManager.CommitUndo();
						this._keyMoving = false;
					}
					if (keyEventArgs.KeyCode == Key.LeftCtrl || keyEventArgs.KeyCode == Key.RightCtrl)
					{
						this._context.SetGizmoRotationMode(false);
					}
					break;
				}
				return false;
			}

			// Token: 0x04000197 RID: 407
			private readonly ParamVector _paramPosition;

			// Token: 0x04000198 RID: 408
			private readonly ParamBool _paramSnap;

			// Token: 0x04000199 RID: 409
			private readonly ParamFloat _paramSnapSize = new ParamFloat(Localizer.Localize("PARAM_SNAP_GRID_SIZE", null), 1f, 1f, 16f, 0.25f);

			// Token: 0x0400019A RID: 410
			private readonly ParamBool _paramSnapObjectSize;

			// Token: 0x0400019B RID: 411
			private readonly ParamBool _paramUseGizmos;

			// Token: 0x0400019C RID: 412
			private readonly ParamBool _paramGrabAnchor = new ParamBool(Localizer.Localize("PARAM_GRAB_ANCHOR", null), false);

			// Token: 0x0400019D RID: 413
			private readonly ParamCheckButton _actionAlignToObject;

			// Token: 0x0400019E RID: 414
			private readonly ParamButton _actionDropToPhysics = new ParamButton(Localizer.Localize("PARAM_SELECTION_DROP", null));

			// Token: 0x0400019F RID: 415
			private Key _keyStart;

			// Token: 0x040001A0 RID: 416
			private bool _keyMoving;
		}

		// Token: 0x02000056 RID: 86
		[Serializable]
		private class NomadXmlObject
		{
			// Token: 0x040001A1 RID: 417
			public string NomadObj;
		}

		// Token: 0x02000057 RID: 87
		public struct SpawnTransition
		{
			// Token: 0x060003E1 RID: 993 RVA: 0x0000D81C File Offset: 0x0000BA1C
			public SpawnTransition(int spawnTransitionType)
			{
				this.transitionType = spawnTransitionType;
				switch (this.transitionType)
				{
				case 0:
					this.ratio = 0.01f;
					return;
				case 1:
					this.ratio = 0.25f;
					return;
				case 2:
					this.ratio = 0.5f;
					return;
				case 3:
					this.ratio = 0.75f;
					return;
				case 4:
					this.ratio = 0f;
					return;
				default:
					Trace.Assert(false, "Invalid ratio for the wave spawner");
					this.ratio = 1f;
					return;
				}
			}

			// Token: 0x060003E2 RID: 994 RVA: 0x0000D8A8 File Offset: 0x0000BAA8
			public override string ToString()
			{
				string result;
				switch (this.transitionType)
				{
				case 0:
					result = Localizer.LocalizeCommon("TOOL_OBJECT_MODE_SPAWNER_TRANSTYPE_0");
					break;
				case 1:
					result = Localizer.LocalizeCommon("TOOL_OBJECT_MODE_SPAWNER_TRANSTYPE_2");
					break;
				case 2:
					result = Localizer.LocalizeCommon("TOOL_OBJECT_MODE_SPAWNER_TRANSTYPE_3");
					break;
				case 3:
					result = Localizer.LocalizeCommon("TOOL_OBJECT_MODE_SPAWNER_TRANSTYPE_4");
					break;
				case 4:
					result = Localizer.LocalizeCommon(284728U);
					break;
				default:
					result = "What a terrible error";
					break;
				}
				return result;
			}

			// Token: 0x170000D8 RID: 216
			// (get) Token: 0x060003E3 RID: 995 RVA: 0x0000D920 File Offset: 0x0000BB20
			public float Ratio
			{
				get
				{
					return this.ratio;
				}
			}

			// Token: 0x040001A2 RID: 418
			private int transitionType;

			// Token: 0x040001A3 RID: 419
			private float ratio;
		}

		// Token: 0x02000058 RID: 88
		public class AddMode : ToolObject.Mode
		{
			// Token: 0x060003E4 RID: 996 RVA: 0x0000D938 File Offset: 0x0000BB38
			public AddMode(ToolObject context) : base(Localizer.Localize("TOOL_OBJECT_MODE_ADD", null) + " (5)", "tools/objects/Object_Add.png", context)
			{
				this.InitParamObject();
				this.InitFilterFuncs();
				this.m_paramEnumButton = new ParamEnumButton("", new ParamEnumButtonImageText[]
				{
					new ParamEnumButtonImageText(Localizer.LocalizeCommon("TOOL_OBJECT_MODE_ADD_CAT_OBJECTS"), "tools/objects/Object_Add.png", ToolObject.AddMode.CategoryIDs.CAT_OBJECTS),
					new ParamEnumButtonImageText(Localizer.LocalizeCommon("TOOL_OBJECT_MODE_ADD_CAT_GAMEPLAYOBJECTS"), "tools/objects/Add_gameplay_object.png", ToolObject.AddMode.CategoryIDs.CAT_GAMEPLAYOBJECTS),
					this.m_paramEnumButtonNpc = new ParamEnumButtonImageText(Localizer.LocalizeCommon("TOOL_OBJECT_MODE_ADD_CAT_NPC"), "tools/objects/Ambient_AI_animals_and_allies.png", ToolObject.AddMode.CategoryIDs.CAT_NPC),
					new ParamEnumButtonImageText(Localizer.LocalizeCommon("TOOL_OBJECT_MODE_ADD_CAT_STPS"), "tools/objects/Tool_STP.png", ToolObject.AddMode.CategoryIDs.CAT_STPS)
				}, delegate(object sender, object oldValue, object newValue)
				{
					this.Category = (ToolObject.AddMode.CategoryIDs)newValue;
				})
				{
					SelectedIndex = 0,
					Value = 0
				};
				this.Category = ToolObject.AddMode.CategoryIDs.CAT_OBJECTS;
			}

			// Token: 0x060003E5 RID: 997 RVA: 0x0000DA7C File Offset: 0x0000BC7C
			protected AddMode(string name, string icon, ToolObject context) : base(name, icon, context)
			{
			}

			// Token: 0x060003E6 RID: 998 RVA: 0x0000DAE0 File Offset: 0x0000BCE0
			private void InitParamObject()
			{
				this.m_paramObject = new ParamInventoryObject(Localizer.Localize("PARAM_OBJECT_BROWSER", null), new Func<Inventory.Entry, bool>(this.FilterObjectEntities), true);
				this.m_paramObject.ValueChanged += delegate(object o, EventArgs ea)
				{
					this.SetNewObject();
				};
			}

			// Token: 0x060003E7 RID: 999 RVA: 0x0000DB1C File Offset: 0x0000BD1C
			public override string GetContextHelp()
			{
				return Localizer.Localize("HELP_TOOL_ADDOBJECT", null);
			}

			// Token: 0x060003E8 RID: 1000 RVA: 0x0000DC4C File Offset: 0x0000BE4C
			protected override IEnumerable<Parameter> GetParameters()
			{
				yield return this.m_paramEnumButton;
				yield return this.m_paramBatchAdd;
				yield return this.m_paramObject;
				yield break;
			}

			// Token: 0x170000D9 RID: 217
			// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0000DC69 File Offset: 0x0000BE69
			// (set) Token: 0x060003EA RID: 1002 RVA: 0x0000DC74 File Offset: 0x0000BE74
			public ToolObject.AddMode.CategoryIDs Category
			{
				get
				{
					return this._category;
				}
				set
				{
					if (value >= ToolObject.AddMode.CategoryIDs.CAT_MAXCNT)
					{
						value = ToolObject.AddMode.CategoryIDs.CAT_OBJECTS;
					}
					if (value == ToolObject.AddMode.CategoryIDs.CAT_STPS)
					{
						this.m_paramObject.UnsupportedAIVisibility = Visibility.Visible;
						this.m_paramObject.EntitySizeVisibility = Visibility.Collapsed;
					}
					else
					{
						this.m_paramObject.UnsupportedAIVisibility = Visibility.Collapsed;
						this.m_paramObject.EntitySizeVisibility = Visibility.Visible;
					}
					if (this.m_paramEnumButton != null && this.m_paramEnumButton.Value != null && value != (ToolObject.AddMode.CategoryIDs)this.m_paramEnumButton.Value)
					{
						this.m_paramEnumButton.Value = value;
					}
					this.StoreCurrentFolder(this._category);
					this.m_paramObject.Filter = this.m_filterFuncs[(int)value];
					this.RestoreCurrentFolder(value);
					this._category = value;
				}
			}

			// Token: 0x060003EB RID: 1003 RVA: 0x0000DD24 File Offset: 0x0000BF24
			private void RestoreCurrentFolder(ToolObject.AddMode.CategoryIDs category)
			{
				string text = this.m_lastSelectedFolder[(int)category];
				if (!string.IsNullOrEmpty(text))
				{
					this.m_paramObject.SelectFolderByName(text);
					return;
				}
				this.m_paramObject.SelectDefaultFolder();
			}

			// Token: 0x060003EC RID: 1004 RVA: 0x0000DD5A File Offset: 0x0000BF5A
			private void StoreCurrentFolder(ToolObject.AddMode.CategoryIDs category)
			{
				if (this.m_paramObject.ObjectSelector.SelectedFolder != null)
				{
					this.m_lastSelectedFolder[(int)category] = this.m_paramObject.ObjectSelector.SelectedFolder.Model.DisplayName;
				}
			}

			// Token: 0x060003ED RID: 1005 RVA: 0x0000DD90 File Offset: 0x0000BF90
			protected void InitFilterFuncs()
			{
				this.m_filterFuncs = new Func<Inventory.Entry, bool>[4];
				this.m_filterFuncs[0] = new Func<Inventory.Entry, bool>(this.FilterObjectEntities);
				this.m_filterFuncs[1] = new Func<Inventory.Entry, bool>(this.FilterAmbientEntities);
				this.m_filterFuncs[2] = new Func<Inventory.Entry, bool>(this.FilterSTPEntities);
				this.m_filterFuncs[3] = new Func<Inventory.Entry, bool>(this.FilterGameplayObjectsEntities);
			}

			// Token: 0x060003EE RID: 1006 RVA: 0x0000DDF9 File Offset: 0x0000BFF9
			private bool FilterGameplayObjectsEntities(Inventory.Entry e)
			{
				return GameModeManager.GetEnumObjectiveType() != GameModeManager.EMapObjective.EMapObjective_Invalid && !e.IsDirectory && !e.IsToolsOnly && e.IsObjectiveGameplay;
			}

			// Token: 0x060003EF RID: 1007 RVA: 0x0000DE20 File Offset: 0x0000C020
			private bool FilterAmbientEntities(Inventory.Entry e)
			{
				GameModeManager.EMapObjective enumObjectiveType = GameModeManager.GetEnumObjectiveType();
				if (enumObjectiveType == GameModeManager.EMapObjective.EMapObjective_Invalid || e.IsDirectory || e.IsToolsOnly)
				{
					return false;
				}
				switch (enumObjectiveType)
				{
				case GameModeManager.EMapObjective.EMapObjective_Outpost:
				case GameModeManager.EMapObjective.EMapObjective_TerroHunt:
				case GameModeManager.EMapObjective.EMapObjective_Extraction:
					if ((e.IsAnimal || e.IsAlly) && !e.IsEnemy && !e.IsSpawner)
					{
						return true;
					}
					break;
				case GameModeManager.EMapObjective.EMapObjective_Poacher:
					if ((e.IsEnemy || e.IsAlly) && !e.IsAnimal && !e.IsSpawner)
					{
						return true;
					}
					break;
				default:
					return false;
				}
				return false;
			}

			// Token: 0x060003F0 RID: 1008 RVA: 0x0000DEAB File Offset: 0x0000C0AB
			private bool FilterSTPEntities(Inventory.Entry e)
			{
				return GameModeManager.GetEnumObjectiveType() != GameModeManager.EMapObjective.EMapObjective_Invalid && !e.IsDirectory && !e.IsToolsOnly && e.IsSTP;
			}

			// Token: 0x060003F1 RID: 1009 RVA: 0x0000DED4 File Offset: 0x0000C0D4
			private bool FilterObjectEntities(Inventory.Entry e)
			{
				return GameModeManager.GetEnumObjectiveType() != GameModeManager.EMapObjective.EMapObjective_Invalid && !e.IsDirectory && !e.IsSTP && !e.IsAlly && !e.IsEnemy && !e.IsAnimal && !e.IsGameplay && !e.IsToolsOnly;
			}

			// Token: 0x060003F2 RID: 1010 RVA: 0x0000DF24 File Offset: 0x0000C124
			public virtual void SetGotoObject(ObjectInventory.Entry entry)
			{
				if (!entry.IsValid)
				{
					return;
				}
				int num = 0;
				foreach (Func<Inventory.Entry, bool> func in this.m_filterFuncs)
				{
					if (func(entry))
					{
						this.m_paramEnumButton.Value = num;
						this.Category = (ToolObject.AddMode.CategoryIDs)num;
						this.m_paramObject.Value = entry;
						this.SetNewObject();
						break;
					}
					num++;
				}
			}

			// Token: 0x060003F3 RID: 1011 RVA: 0x0000DF8E File Offset: 0x0000C18E
			public override void Activate()
			{
				this._context.ClearSelection();
				this.m_paramObject.UpdateFilter();
				this.m_newObjectAngle = 0f;
				this.ClearObjectParam();
				this.SetNewObject();
				this.RestoreCurrentFolder(this._category);
			}

			// Token: 0x060003F4 RID: 1012 RVA: 0x0000DFCC File Offset: 0x0000C1CC
			public virtual void UpdateForMode(UpdateModeSource updateSource)
			{
				GameModeManager.EMapObjective enumObjectiveType = GameModeManager.GetEnumObjectiveType();
				GameModeManager.EMapObjective emapObjective = enumObjectiveType;
				if (emapObjective == GameModeManager.EMapObjective.EMapObjective_Poacher)
				{
					this.m_paramEnumButtonNpc.Image = "tools/objects/Ambient_AI_enemies_and_allies_option1.png".GetImageSource();
					return;
				}
				this.m_paramEnumButtonNpc.Image = "tools/objects/Ambient_AI_animals_and_allies.png".GetImageSource();
			}

			// Token: 0x060003F5 RID: 1013 RVA: 0x0000E010 File Offset: 0x0000C210
			public override void Deactivate()
			{
				this.StoreCurrentFolder(this._category);
				this.ClearObjectParam();
				ObjectRenderer.Clear();
				this._context.ClearSelection();
			}

			// Token: 0x060003F6 RID: 1014 RVA: 0x0000E0A4 File Offset: 0x0000C2A4
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				switch (mouseEvent)
				{
				case Editor.MouseEvent.MouseDown:
				{
					bool flag = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
					if (this.m_newObjectValid || flag)
					{
						return false;
					}
					Vec3 vec;
					EditorObject objectFromScreenPoint = ObjectManager.GetObjectFromScreenPoint(Editor.Viewport.NormalizedMousePos, out vec);
					if (objectFromScreenPoint.IsValid)
					{
						EventHandler handler = null;
						handler = delegate(object s, EventArgs args)
						{
							this._context.ToolSelectMode.ActivateEvent -= handler;
							this._context.ToolSelectMode.OnMouseEvent(mouseEvent, mouseEventArgs);
						};
						this._context.ToolSelectMode.ActivateEvent += handler;
						this._context.SwitchMode(this._context.ToolSelectMode);
						return false;
					}
					return false;
				}
				case Editor.MouseEvent.MouseUp:
					break;
				case Editor.MouseEvent.MouseMove:
				{
					if (this._context._selection.Count <= 0)
					{
						return false;
					}
					this.m_newObjectValid = false;
					Vec3 raySrc;
					Vec3 rayDir;
					Editor.GetWorldRayFromScreenPoint(Editor.Viewport.NormalizedMousePos, out raySrc, out rayDir);
					Vec3 pos;
					float num;
					Vec3 normal;
					if (Editor.RayCastPhysics(raySrc, rayDir, this._context._selection, out pos, out num, out normal))
					{
						this._context._selection.LoadState();
						foreach (EditorObject editorObject in this._context._selection.GetObjects())
						{
							if (editorObject.Entry.AutoOrientation)
							{
								Vec3 angles;
								editorObject.ComputeAutoOrientation(ref pos, out angles, normal);
								editorObject.Angles = angles;
							}
						}
						this._context._selection.MoveTo(pos, EditorObjectSelection.MoveMode.MoveNormal);
						this._context._selection.SaveState();
						this._context._selection.SnapToClosestObjects();
						this.m_newObjectValid = true;
					}
					using (IEnumerator<EditorObject> enumerator2 = this._context._selection.GetObjects().GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							EditorObject editorObject2 = enumerator2.Current;
							editorObject2.Visible = this.m_newObjectValid;
						}
						return false;
					}
					break;
				}
				default:
					return false;
				}
				if (this.m_newObjectValid && !Editor.Viewport.CaptureMouse)
				{
					bool flag2;
					if (!BudgetManager.ValidateObjectsGlobalCost(this._context._selection))
					{
						if (this.m_showGlobalBudgetWarning)
						{
							MessageBoxResult messageBoxResult = MessageBox.Show(Program.MainWin, Localizer.Localize("WARNING_GLOBAL_BUDGET", null), Localizer.LocalizeCommon("MSG_TITLE_WARNING"), MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
							this.m_showGlobalBudgetWarning = (messageBoxResult != MessageBoxResult.OK);
							flag2 = (messageBoxResult != MessageBoxResult.OK);
						}
					}
					else
					{
						this.m_showGlobalBudgetWarning = true;
					}
					flag2 = !BudgetManager.CheckSectorBudget(this._context._selection, false);
					if (!BudgetManager.ValidateAIObjectsUsage(this._context._selection))
					{
						if (this.m_showAIBudgetWarning)
						{
							MessageBoxResult messageBoxResult2 = MessageBox.Show(Program.MainWin, Localizer.Localize("WARNING_AI_BUDGET", null), Localizer.LocalizeCommon("MSG_TITLE_WARNING"), MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
							this.m_showAIBudgetWarning = (messageBoxResult2 != MessageBoxResult.OK);
							flag2 = (messageBoxResult2 != MessageBoxResult.OK);
						}
					}
					else
					{
						this.m_showAIBudgetWarning = true;
					}
					if (!BudgetManager.ValidatePhysicsObjectsUsage(this._context._selection))
					{
						if (this.m_showPhysicsBudgetWarning)
						{
							MessageBoxResult messageBoxResult3 = MessageBox.Show(Program.MainWin, Localizer.Localize("WARNING_PHYSICAL_OBJECTS", null), Localizer.LocalizeCommon("MSG_TITLE_WARNING"), MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
							this.m_showPhysicsBudgetWarning = (messageBoxResult3 != MessageBoxResult.OK);
							flag2 = (messageBoxResult3 != MessageBoxResult.OK);
						}
					}
					else
					{
						this.m_showPhysicsBudgetWarning = true;
					}
					if (!BudgetManager.ValidateLightObjectsUsage(this._context._selection))
					{
						if (this.m_showLightsBudgetWarning)
						{
							MessageBoxResult messageBoxResult4 = MessageBox.Show(Program.MainWin, Localizer.Localize("WARNING_LIGHT_BUDGET", null), Localizer.LocalizeCommon("MSG_TITLE_WARNING"), MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
							this.m_showLightsBudgetWarning = (messageBoxResult4 != MessageBoxResult.OK);
							flag2 = (messageBoxResult4 != MessageBoxResult.OK);
						}
					}
					else
					{
						this.m_showLightsBudgetWarning = true;
					}
					if (!BudgetManager.ValidateAnimPointsObjectsUsage(this._context._selection))
					{
						if (this.m_showAnimPointsBudgetWarning)
						{
							MessageBoxResult messageBoxResult5 = MessageBox.Show(Program.MainWin, Localizer.Localize("WARNING_ANIM_POINTS_BUDGET", null), Localizer.LocalizeCommon("MSG_TITLE_WARNING"), MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
							this.m_showAnimPointsBudgetWarning = (messageBoxResult5 != MessageBoxResult.OK);
							flag2 = (messageBoxResult5 != MessageBoxResult.OK);
						}
					}
					else
					{
						this.m_showAnimPointsBudgetWarning = true;
					}
					if (!BudgetManager.ValidateSpawnPointsObjectsUsage(this._context._selection))
					{
						MessageBox.Show(Program.MainWin, Localizer.Localize("ERROR_PLAYERSPAWNPOINT_BUDGET", null), Localizer.LocalizeCommon("MSG_TITLE_ERROR"), MessageBoxButton.OK, MessageBoxImage.Hand);
						flag2 = true;
					}
					if (!flag2)
					{
						UndoManager.RecordUndo();
						this.PlaceInventoryObject();
						UndoManager.CommitUndo();
						if (!this.m_paramBatchAdd.Value)
						{
							this.ClearObjectParam();
							this.m_paramObject.Value = null;
						}
					}
				}
				return false;
			}

			// Token: 0x060003F7 RID: 1015 RVA: 0x0000E560 File Offset: 0x0000C760
			public override bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
			{
				bool flag = this._context._selection.Count > 0;
				if (keyEvent == Editor.KeyEvent.KeyUp && keyEventArgs.KeyCode == Key.Escape && flag)
				{
					this.ClearObjectParam();
					this.m_paramObject.ObjectSelector.SelectedItem = null;
					return true;
				}
				return keyEvent == Editor.KeyEvent.KeyUp && keyEventArgs.KeyCode == Key.Delete && flag;
			}

			// Token: 0x060003F8 RID: 1016 RVA: 0x0000E5BC File Offset: 0x0000C7BC
			public override void OnRotateSelection(float value)
			{
				this.m_newObjectAngle += value;
			}

			// Token: 0x060003F9 RID: 1017 RVA: 0x0000E5CC File Offset: 0x0000C7CC
			public override void Update(float dt)
			{
				if (this.m_newObjectPending)
				{
					bool flag = true;
					foreach (EditorObject editorObject in this._context._selection.GetObjects())
					{
						if (!editorObject.IsLoaded)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						this.m_newObjectPending = false;
					}
				}
				this.UpdateNewObject();
			}

			// Token: 0x060003FA RID: 1018 RVA: 0x0000E644 File Offset: 0x0000C844
			protected virtual void PlaceInventoryObject()
			{
				EditorObjectSelection newSelection = EditorObjectSelection.Create();
				this._context._selection.Clone(newSelection, true);
				newSelection.Dispose();
				ToolObject.OnNewInstanceCreated();
			}

			// Token: 0x060003FB RID: 1019 RVA: 0x0000E67A File Offset: 0x0000C87A
			protected void ClearNewObject()
			{
				if (this._context._selection.Count > 0)
				{
					this._context.DestroySelectionObjects();
					this.m_newObjectPending = false;
					this.m_newObjectValid = false;
				}
			}

			// Token: 0x060003FC RID: 1020 RVA: 0x0000E6A8 File Offset: 0x0000C8A8
			public void SetNewObject(EditorObjectSelection selection)
			{
				this.ClearNewObject();
				this.m_newObjectPending = true;
				this.m_newObjectValid = false;
				selection.RotateCenter(this.m_newObjectAngle, new Vec3(0f, 0f, 1f));
				foreach (EditorObject editorObject in selection.GetObjects())
				{
					editorObject.Visible = false;
				}
				this._context.SetSelection(selection, EditorObject.Null, false);
				this._context._selection.SaveState();
				if (this._context._selection.IsValid && !this._context._gizmoEnabled)
				{
					this._context._gizmoEnabled = true;
				}
				this.UpdateNewObject();
			}

			// Token: 0x060003FD RID: 1021 RVA: 0x0000E780 File Offset: 0x0000C980
			protected void SetNewObject()
			{
				if (this.m_paramObject.SelectedItem == null)
				{
					this.ClearNewObject();
					return;
				}
				EditorObjectSelection newObject = EditorObjectSelection.Create();
				if (this.m_paramObject.Value != null && !this.m_paramObject.Value.IsDirectory)
				{
					EditorObject obj = EditorObject.CreateFromEntry(this.m_paramObject.Value, this.Category == ToolObject.AddMode.CategoryIDs.CAT_NPC, false);
					newObject.AddObject(obj);
				}
				this.SetNewObject(newObject);
			}

			// Token: 0x060003FE RID: 1022 RVA: 0x0000E7FC File Offset: 0x0000C9FC
			private void UpdateNewObject()
			{
				if (this._context._selection.Count == 0)
				{
					return;
				}
				foreach (EditorObject editorObject in this._context._selection.GetObjects())
				{
					if (!Editor.Viewport.MouseOver)
					{
						editorObject.Visible = false;
					}
					editorObject.HighlightState = true;
				}
			}

			// Token: 0x060003FF RID: 1023 RVA: 0x0000E87C File Offset: 0x0000CA7C
			private void ClearObjectParam()
			{
				this.ClearNewObject();
				if (this.m_paramObject.Value != null && !this.m_paramObject.Value.IsDirectory)
				{
					this.m_paramObject.Value = (ObjectInventory.Entry)this.m_paramObject.Value.Parent;
				}
			}

			// Token: 0x170000DA RID: 218
			// (get) Token: 0x06000400 RID: 1024 RVA: 0x0000E8D4 File Offset: 0x0000CAD4
			public bool IsInventoryObjectSelected
			{
				get
				{
					return this.m_paramObject.Value != null && !this.m_paramObject.Value.IsDirectory;
				}
			}

			// Token: 0x170000DB RID: 219
			// (get) Token: 0x06000401 RID: 1025 RVA: 0x0000E8FE File Offset: 0x0000CAFE
			public bool IsNewObjectMode
			{
				get
				{
					return this.m_newObjectPending || this.m_newObjectValid;
				}
			}

			// Token: 0x040001A4 RID: 420
			protected ParamEnumButton m_paramEnumButton;

			// Token: 0x040001A5 RID: 421
			protected ParamEnumButtonImageText m_paramEnumButtonNpc;

			// Token: 0x040001A6 RID: 422
			protected ParamBool m_paramBatchAdd = new ParamBool(Localizer.Localize("PARAM_BATCH_ADD", null), false);

			// Token: 0x040001A7 RID: 423
			protected ParamInventoryObject m_paramObject;

			// Token: 0x040001A8 RID: 424
			protected Func<Inventory.Entry, bool>[] m_filterFuncs;

			// Token: 0x040001A9 RID: 425
			protected string[] m_lastSelectedFolder = new string[4];

			// Token: 0x040001AA RID: 426
			protected bool m_showGlobalBudgetWarning = true;

			// Token: 0x040001AB RID: 427
			protected bool m_showAIBudgetWarning = true;

			// Token: 0x040001AC RID: 428
			protected bool m_showPhysicsBudgetWarning = true;

			// Token: 0x040001AD RID: 429
			protected bool m_showLightsBudgetWarning = true;

			// Token: 0x040001AE RID: 430
			protected bool m_showAnimPointsBudgetWarning = true;

			// Token: 0x040001AF RID: 431
			private ToolObject.AddMode.CategoryIDs _category;

			// Token: 0x040001B0 RID: 432
			protected bool m_newObjectPending;

			// Token: 0x040001B1 RID: 433
			protected bool m_newObjectValid;

			// Token: 0x040001B2 RID: 434
			protected float m_newObjectAngle;

			// Token: 0x02000059 RID: 89
			public enum CategoryIDs
			{
				// Token: 0x040001B4 RID: 436
				CAT_OBJECTS,
				// Token: 0x040001B5 RID: 437
				CAT_NPC,
				// Token: 0x040001B6 RID: 438
				CAT_STPS,
				// Token: 0x040001B7 RID: 439
				CAT_GAMEPLAYOBJECTS,
				// Token: 0x040001B8 RID: 440
				CAT_MAXCNT
			}
		}

		// Token: 0x0200005A RID: 90
		public class SpawnerMode : ToolObject.AddMode
		{
			// Token: 0x06000404 RID: 1028 RVA: 0x0000E958 File Offset: 0x0000CB58
			public SpawnerMode(ToolObject context) : base(Localizer.LocalizeCommon("TOOL_OBJECT_MODE_SPAWNER") + " (6)", "tools/objects/Tool_Spawners.png", context)
			{
				this.m_paramObject = new ParamInventoryObject(Localizer.Localize("PARAM_OBJECT_BROWSER", null), new Func<Inventory.Entry, bool>(this.FilterSpawnerEntities), false);
				this.m_paramObject.ValueChanged += delegate(object o, EventArgs ea)
				{
					base.SetNewObject();
				};
				GameModeManager.EMapObjective enumObjectiveType = GameModeManager.GetEnumObjectiveType();
				string locKey = "AItool_Enemy_";
				if (enumObjectiveType == GameModeManager.EMapObjective.EMapObjective_Poacher)
				{
					base.UpdateIcon("tools/objects/AI_animal.png");
					locKey = "AItool_Animal_";
				}
				else
				{
					base.UpdateIcon("tools/objects/Tool_Spawners.png");
					if (enumObjectiveType == GameModeManager.EMapObjective.EMapObjective_Outpost)
					{
						locKey = "AItool_Reinforcement";
					}
					else
					{
						locKey = "AItool_Enemy_";
					}
				}
				this._waveNum = ToolObject.SpawnerMode.waveOne;
				this._showWaves = ToolObject.SpawnerMode.waveAll;
				this._transition = new ToolObject.SpawnTransition(0);
				this._waveNumParam = new ParamEnumCombo(Localizer.LocalizeCommon("TOOL_OBJECT_MODE_SPAWNER_WAVE"), from x in Enumerable.Range(ToolObject.SpawnerMode.waveOne, ToolObject.SpawnerMode.waveCount)
				select new ParamEnumText(Localizer.LocalizeCommon(string.Format("{0}{1}", locKey, x)), x), new ParamEnumBase.ValueChangedDelegate(this.EditWavesChange));
				ParamEnumText item = new ParamEnumText(Localizer.LocalizeCommon(ToolObject.SpawnerMode.textAll), ToolObject.SpawnerMode.waveAll);
				List<ParamEnumText> list = new List<ParamEnumText>
				{
					item
				};
				list = list.Concat((from x in Enumerable.Range(ToolObject.SpawnerMode.waveOne, ToolObject.SpawnerMode.waveCount)
				select new ParamEnumText(x)).ToList<ParamEnumText>()).ToList<ParamEnumText>();
				this._showWavesParam = new ParamEnumCombo(Localizer.LocalizeCommon("TOOL_OBJECT_MODE_SPAWNER_SHOWWAVE"), list, new ParamEnumBase.ValueChangedDelegate(this.ShowWavesChange));
				List<ParamEnumText> list2 = new List<ParamEnumText>();
				for (int i = 0; i < ToolObject.SpawnerMode.transitionCount; i++)
				{
					list2.Add(new ParamEnumText(new ToolObject.SpawnTransition(i)));
				}
				this._transitionParam = new ParamEnumCombo(Localizer.LocalizeCommon("TOOL_OBJECT_MODE_SPAWNER_TRANSITIONTYPE"), list2, new ParamEnumBase.ValueChangedDelegate(this.TriggerWavesChange));
				this._transitionParam.SetEntryVisibility(ToolObject.SpawnerMode.transitionCount - 1, false);
				this.m_paramObject.Filter = new Func<Inventory.Entry, bool>(this.FilterSpawnerEntities);
				this._transitionParam.SelectedIndex = 0;
				this._transitionParam.Enabled = false;
			}

			// Token: 0x06000405 RID: 1029 RVA: 0x0000EBB8 File Offset: 0x0000CDB8
			public override void UpdateForMode(UpdateModeSource updateSource)
			{
				GameModeManager.EMapObjective enumObjectiveType = GameModeManager.GetEnumObjectiveType();
				string arg;
				if (enumObjectiveType == GameModeManager.EMapObjective.EMapObjective_Poacher)
				{
					base.UpdateIcon("tools/objects/AI_animal.png");
					arg = "AItool_Animal_";
				}
				else if (enumObjectiveType == GameModeManager.EMapObjective.EMapObjective_Outpost)
				{
					base.UpdateIcon("tools/objects/Tool_Spawners.png");
					arg = "AItool_Reinforcement";
				}
				else
				{
					base.UpdateIcon("tools/objects/Tool_Spawners.png");
					arg = "AItool_Enemy_";
				}
				foreach (ParamEnumBase.Entry entry in this._waveNumParam.Values)
				{
					entry.DisplayName = Localizer.LocalizeCommon(string.Format("{0}{1}", arg, entry.Value));
				}
				this._waveNumParam.SelectedIndex = 0;
				this._transitionParam.SelectedIndex = 0;
				if (updateSource == UpdateModeSource.Default)
				{
					Binding.FCE_AI_SetWaveTransition(1, 0.01f);
					Binding.FCE_AI_SetWaveTransition(2, (enumObjectiveType == GameModeManager.EMapObjective.EMapObjective_Outpost) ? 0f : 0.01f);
					Binding.FCE_AI_SetWaveTransition(3, 0.01f);
					Binding.FCE_AI_SetWaveTransition(4, 0.01f);
					Binding.FCE_AI_SetWaveTransition(5, 0.01f);
				}
			}

			// Token: 0x06000406 RID: 1030 RVA: 0x0000ECE0 File Offset: 0x0000CEE0
			private bool FilterSpawnerEntities(Inventory.Entry e)
			{
				return this.FilterSpawnerEntities(e, this._waveNum);
			}

			// Token: 0x06000407 RID: 1031 RVA: 0x0000ECF0 File Offset: 0x0000CEF0
			private bool FilterSpawnerEntities(Inventory.Entry e, int waveNum)
			{
				GameModeManager.EMapObjective enumObjectiveType = GameModeManager.GetEnumObjectiveType();
				if (enumObjectiveType == GameModeManager.EMapObjective.EMapObjective_Invalid || e.IsDirectory || e.IsAmbientOnly || e.IsToolsOnly)
				{
					return false;
				}
				bool flag = false;
				switch (enumObjectiveType)
				{
				case GameModeManager.EMapObjective.EMapObjective_Outpost:
				case GameModeManager.EMapObjective.EMapObjective_TerroHunt:
				case GameModeManager.EMapObjective.EMapObjective_Extraction:
					if (e.IsEnemy)
					{
						flag = true;
					}
					break;
				case GameModeManager.EMapObjective.EMapObjective_Poacher:
					if (e.IsAnimal)
					{
						flag = true;
					}
					break;
				default:
					flag = false;
					break;
				}
				if (!flag)
				{
					return false;
				}
				bool isSpawner = e.IsSpawner;
				return (waveNum == 1 && !isSpawner) | (isSpawner && e.WaveNum == waveNum - 1);
			}

			// Token: 0x06000408 RID: 1032 RVA: 0x0000ED81 File Offset: 0x0000CF81
			protected override void PlaceInventoryObject()
			{
				base.PlaceInventoryObject();
			}

			// Token: 0x06000409 RID: 1033 RVA: 0x0000ED8C File Offset: 0x0000CF8C
			private void EditWavesChange(object sender, object oldValue, object newValue)
			{
				bool enabled = this._transitionParam.Enabled;
				if (this._waveNum != (int)newValue)
				{
					this._waveNum = (int)newValue;
					this.m_paramObject.ObjectSelector.Root = ObjectInventory.Instance.Root;
					this.m_paramObject.ObjectSelector.FilterInventory();
				}
				if ((int)newValue == 1)
				{
					this._transitionParam.Visible = Visibility.Collapsed;
					this._transitionParam.Enabled = false;
					this._transitionParam.SetEntryVisibility(4, false);
				}
				else if (GameModeManager.GetEnumObjectiveType() == GameModeManager.EMapObjective.EMapObjective_Outpost && (int)newValue == 2)
				{
					this._transitionParam.SetEntryVisibility(ToolObject.SpawnerMode.transitionCount - 1, true);
					this._transitionParam.SelectedIndex = ToolObject.SpawnerMode.transitionCount - 1;
					this._transitionParam.Visible = Visibility.Visible;
					this._transitionParam.Enabled = false;
				}
				else
				{
					this._transitionParam.Visible = Visibility.Visible;
					this._transitionParam.Enabled = true;
					this._transitionParam.SetEntryVisibility(4, false);
				}
				if (this._transitionParam.Enabled)
				{
					float obj = Binding.FCE_AI_GetWaveTransition((int)this._waveNumParam.SelectedItem.Value);
					int num = 0;
					if (this._transitionParam.Enabled)
					{
						foreach (ParamEnumBase.Entry entry in this._transitionParam.Values)
						{
							ParamEnumText paramEnumText = (ParamEnumText)entry;
							if (((ToolObject.SpawnTransition)paramEnumText.Value).Ratio.Equals(obj))
							{
								if (this._transitionParam.SelectedIndex != num)
								{
									this._transitionParam.SelectedIndex = num;
									break;
								}
								break;
							}
							else
							{
								num++;
							}
						}
					}
				}
			}

			// Token: 0x0600040A RID: 1034 RVA: 0x0000EF50 File Offset: 0x0000D150
			public void SetWave(int waveId)
			{
				this._waveNumParam.Value = waveId;
			}

			// Token: 0x0600040B RID: 1035 RVA: 0x0000EF64 File Offset: 0x0000D164
			private void ShowWavesChange(object sender, object oldValue, object newValue)
			{
				this._showWaves = (int)newValue;
				int num = (int)newValue;
				if (num > 0)
				{
					num--;
				}
				Binding.FCE_AI_ShowWaveOnly(num);
			}

			// Token: 0x0600040C RID: 1036 RVA: 0x0000EF9C File Offset: 0x0000D19C
			private void TriggerWavesChange(object sender, object oldValue, object newValue)
			{
				this._transition = (ToolObject.SpawnTransition)newValue;
				if (this._waveNumParam.SelectedItem != null)
				{
					Binding.FCE_AI_SetWaveTransition((int)this._waveNumParam.SelectedItem.Value, this._transition.Ratio);
				}
			}

			// Token: 0x0600040D RID: 1037 RVA: 0x0000EFEC File Offset: 0x0000D1EC
			public override string GetContextHelp()
			{
				return Localizer.LocalizeCommon("HELP_TOOL_ADD_AI");
			}

			// Token: 0x0600040E RID: 1038 RVA: 0x0000F214 File Offset: 0x0000D414
			protected override IEnumerable<Parameter> GetParameters()
			{
				yield return this._waveNumParam;
				yield return this._showWavesParam;
				yield return this._transitionParam;
				foreach (Parameter f in base.GetParameters())
				{
					yield return f;
				}
				yield break;
			}

			// Token: 0x0600040F RID: 1039 RVA: 0x0000F234 File Offset: 0x0000D434
			public override void Activate()
			{
				base.Activate();
				this._waveNumParam.Value = this._waveNum;
				this._showWavesParam.Value = this._showWaves;
				this._transitionParam.Value = this._transition;
			}

			// Token: 0x06000410 RID: 1040 RVA: 0x0000F284 File Offset: 0x0000D484
			public override void SetGotoObject(ObjectInventory.Entry entry)
			{
				if (!entry.IsValid)
				{
					return;
				}
				if (this.FilterSpawnerEntities(entry, entry.WaveNum + 1))
				{
					this._waveNumParam.Value = entry.WaveNum + 1;
					this.m_paramObject.Value = entry;
					base.SetNewObject();
				}
			}

			// Token: 0x040001B9 RID: 441
			public static readonly int waveCount = 5;

			// Token: 0x040001BA RID: 442
			public static readonly int waveOne = 1;

			// Token: 0x040001BB RID: 443
			public static readonly int waveAll = -1;

			// Token: 0x040001BC RID: 444
			public static readonly int transitionCount = 5;

			// Token: 0x040001BD RID: 445
			private static readonly uint textAll = 148277U;

			// Token: 0x040001BE RID: 446
			private int _waveNum;

			// Token: 0x040001BF RID: 447
			private object _showWaves;

			// Token: 0x040001C0 RID: 448
			private ToolObject.SpawnTransition _transition;

			// Token: 0x040001C1 RID: 449
			private ParamEnumCombo _waveNumParam;

			// Token: 0x040001C2 RID: 450
			private ParamEnumCombo _transitionParam;

			// Token: 0x040001C3 RID: 451
			private ParamEnumCombo _showWavesParam;
		}

		// Token: 0x0200005B RID: 91
		public class RotateMode : ToolObject.Mode
		{
			// Token: 0x06000415 RID: 1045 RVA: 0x0000F318 File Offset: 0x0000D518
			public RotateMode(ToolObject context) : base(Localizer.Localize("TOOL_OBJECT_MODE_ROTATE", null) + " (3)", "tools/objects/Tool_Rotate.png", context)
			{
				this._paramRotation = new ParamVector(Localizer.Localize("PARAM_ROTATION", null), ParamVectorUIType.Angles, new ParamVector.ValueChangedDelegate(this.SetRotation));
				string display = Localizer.Localize("PARAM_SNAP_ANGLE", null);
				ParamEnumButtonText[] array = new ParamEnumButtonText[5];
				array[0] = new ParamEnumButtonText("5", 5f);
				array[1] = new ParamEnumButtonText("10", 10f);
				array[2] = new ParamEnumButtonText("20", 20f);
				array[3] = new ParamEnumButtonText("45", 45f);
				ParamEnumButtonText paramEnumButtonText = array[4] = new ParamEnumButtonText("90", 90f);
				this._paramSnapSize = new ParamEnumButton(display, array);
				this._paramSnap = new ParamBool(Localizer.Localize("PARAM_USE_SNAP_ANGLES", null), delegate(bool value)
				{
					this._paramSnapSize.Enabled = value;
				});
				this._actionResetAngles.ButtonCommand.ExecuteDelegate = delegate(object o)
				{
					this.ResetAngles();
				};
				paramEnumButtonText.IsActive = true;
				this._paramSnap.Value = false;
			}

			// Token: 0x06000416 RID: 1046 RVA: 0x0000F474 File Offset: 0x0000D674
			public override string GetContextHelp()
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(Localizer.Localize("HELP_CONTROLS_ROTATE_MOVEOBJECT", null)).Append("\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_DELETE_OBJECT", null)).Append("\r\n");
				stringBuilder.Append("\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_TOOL_ROTATEOBJECT", null)).Append("\r\n\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_GROUP_SELECTION", null)).Append("\r\n\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_NEIGHBORHOOD_SELECTION", null)).Append("\r\n\r\n");
				stringBuilder.Append(Localizer.Localize("HELP_AXIS_TYPE", null));
				return stringBuilder.ToString();
			}

			// Token: 0x06000417 RID: 1047 RVA: 0x0000F780 File Offset: 0x0000D980
			protected override IEnumerable<Parameter> GetParameters()
			{
				yield return this._context._textSelected;
				yield return this._context._paramUseSelectionCenter;
				yield return this._context._paramMagicWand;
				yield return this._paramRotation;
				yield return this._paramSnap;
				yield return this._paramSnapSize;
				yield return this._actionResetAngles;
				yield return this._context._actionDelete;
				yield return this._context._paramObjectSelection;
				yield return this._context._actionGotoObject;
				yield break;
			}

			// Token: 0x06000418 RID: 1048 RVA: 0x0000F7A0 File Offset: 0x0000D9A0
			private void SetRotation(Vec3 value)
			{
				if (this._context._selection.Count == 0)
				{
					return;
				}
				UndoManager.RecordUndo();
				if (!this._context._paramUseSelectionCenter.Value)
				{
					if (this._context._selection.Count == 1)
					{
						this._context._selection.Rotate(value, this._context._selection[0].Angles, this._context._selection[0].Position, false);
					}
					else
					{
						this._context._selection.RotateLocal(value);
					}
					this._paramRotation.Value = default(Vec3);
				}
				else
				{
					this._context._selection.ComputeCenter();
					this._context._selection.Rotate(this._paramRotation.Value, new Vec3(0f, 0f, 0f), this._context._selection.Center, false);
				}
				UndoManager.CommitUndo();
				this._context.UpdateSelection(false, false);
			}

			// Token: 0x06000419 RID: 1049 RVA: 0x0000F8B4 File Offset: 0x0000DAB4
			private void ResetAngles()
			{
				foreach (EditorObject editorObject in this._context._selection.GetObjects())
				{
					editorObject.Angles = new Vec3(0f, 0f, editorObject.Angles.Z);
				}
				this._context.UpdateSelection(false, false);
			}

			// Token: 0x0600041A RID: 1050 RVA: 0x0000F934 File Offset: 0x0000DB34
			public override void Activate()
			{
				this._context.EnableGizmo(true);
				this._context.SetGizmoRotationMode(true);
				this.UpdateParams();
			}

			// Token: 0x0600041B RID: 1051 RVA: 0x0000F954 File Offset: 0x0000DB54
			public override void Deactivate()
			{
				this._context.SetGizmoRotationMode(false);
				this._context.EnableGizmo(false);
			}

			// Token: 0x0600041C RID: 1052 RVA: 0x0000F970 File Offset: 0x0000DB70
			public override void UpdateParams()
			{
				bool enabled = this._context._selection.Count > 0;
				this._actionResetAngles.Enabled = enabled;
			}

			// Token: 0x0600041D RID: 1053 RVA: 0x0000F9A0 File Offset: 0x0000DBA0
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				if (mouseEvent == Editor.MouseEvent.MouseDown)
				{
					if (this._context._gizmoActive)
					{
						if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
						{
							Vec3 position = this._context._gizmo.Position;
							Vec3 rotationAxis = default(Vec3);
							switch (this._context._gizmo.Active)
							{
							case Axis.X:
								rotationAxis = this._context._gizmo.Axis.axisX;
								break;
							case Axis.Y:
								rotationAxis = this._context._gizmo.Axis.axisY;
								break;
							case Axis.Z:
								rotationAxis = this._context._gizmo.Axis.axisZ;
								break;
							}
							ToolObject.RotateAction rotateAction = new ToolObject.RotateAction(this._context);
							if (this._paramSnap.Value)
							{
								rotateAction.SetSnap((float)this._paramSnapSize.Value);
							}
							rotateAction.Start(position, rotationAxis);
						}
						else
						{
							ToolObject.MoveAction moveAction = new ToolObject.MoveAction(this._context);
							if (this._paramSnap.Value)
							{
								if (this._paramSnap.Value && this._context._gizmoObject.IsValid)
								{
									moveAction.SetSnap(this._context._gizmoObject);
								}
								else
								{
									moveAction.SetSnap((float)this._paramSnapSize.Value);
								}
							}
							moveAction.Start(this._context._gizmo.Position);
						}
					}
					else
					{
						Vec3 pos;
						EditorObject objectFromScreenPoint = ObjectManager.GetObjectFromScreenPoint(Editor.Viewport.NormalizedMousePos, out pos);
						if (objectFromScreenPoint.IsValid)
						{
							if (!this._context._selection.Contains(objectFromScreenPoint))
							{
								EditorObjectSelection editorObjectSelection = EditorObjectSelection.Create();
								if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
								{
									this._context._selection.Clone(editorObjectSelection, false);
								}
								this._context.SelectObject(editorObjectSelection, objectFromScreenPoint);
								this._context.SetSelection(editorObjectSelection, objectFromScreenPoint, true);
							}
							else
							{
								this._context.SetupGizmo(objectFromScreenPoint);
							}
							this._context.UpdateGizmoAxes();
							EditorObjectPivot editorObjectPivot;
							Vec3 rotationPivot = objectFromScreenPoint.GetClosestPivot(pos, out editorObjectPivot) ? editorObjectPivot.position : objectFromScreenPoint.Position;
							Vec3 rotationAxis2 = new Vec3(0f, 0f, 1f);
							ToolObject.RotateAction rotateAction2 = new ToolObject.RotateAction(this._context);
							if (this._paramSnap.Value)
							{
								rotateAction2.SetSnap((float)this._paramSnapSize.Value);
							}
							rotateAction2.Start(rotationPivot, rotationAxis2);
						}
						else
						{
							ToolObject.SelectAction selectAction = new ToolObject.SelectAction(this._context);
							selectAction.Start();
						}
					}
				}
				return false;
			}

			// Token: 0x0600041E RID: 1054 RVA: 0x0000FC48 File Offset: 0x0000DE48
			public override bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
			{
				switch (keyEvent)
				{
				case Editor.KeyEvent.KeyDown:
				{
					Key keyCode = keyEventArgs.KeyCode;
					switch (keyCode)
					{
					case Key.Left:
					case Key.Up:
					case Key.Right:
					case Key.Down:
						this._keyStart = keyEventArgs.KeyCode;
						if (!this._keyMoving)
						{
							this._keyMoving = true;
							UndoManager.RecordUndo();
						}
						break;
					default:
						switch (keyCode)
						{
						case Key.LeftCtrl:
						case Key.RightCtrl:
							this._context.SetGizmoRotationMode(false);
							break;
						}
						break;
					}
					break;
				}
				case Editor.KeyEvent.KeyChar:
					if (this._keyMoving && keyEventArgs.KeyCode == this._keyStart && this._context._gizmo.IsValid)
					{
						Vec3 vec = default(Vec3);
						switch (this._keyStart)
						{
						case Key.Left:
							if (!keyEventArgs.Control)
							{
								vec.Z = -1f;
							}
							else
							{
								vec.Y = -1f;
							}
							break;
						case Key.Up:
							if (!keyEventArgs.Control)
							{
								vec.Z = -1f;
							}
							else
							{
								vec.X = -1f;
							}
							break;
						case Key.Right:
							if (!keyEventArgs.Control)
							{
								vec.Z = 1f;
							}
							else
							{
								vec.Y = 1f;
							}
							break;
						case Key.Down:
							if (!keyEventArgs.Control)
							{
								vec.Z = 1f;
							}
							else
							{
								vec.X = 1f;
							}
							break;
						}
						CoordinateSystem axis = this._context._gizmo.Axis;
						if (keyEventArgs.Shift)
						{
							vec *= MathUtils.Deg2Rad(0.25f);
						}
						else
						{
							vec *= MathUtils.Deg2Rad(1f);
						}
						this._context._selection.Rotate(vec, axis.ToAngles(), this._context._gizmo.Position, false);
					}
					break;
				case Editor.KeyEvent.KeyUp:
					if (this._keyMoving && keyEventArgs.KeyCode == this._keyStart)
					{
						UndoManager.CommitUndo();
						this._keyMoving = false;
					}
					if (keyEventArgs.KeyCode == Key.LeftCtrl || keyEventArgs.KeyCode == Key.RightCtrl)
					{
						this._context.SetGizmoRotationMode(true);
					}
					break;
				}
				return false;
			}

			// Token: 0x040001C5 RID: 453
			private readonly ParamVector _paramRotation;

			// Token: 0x040001C6 RID: 454
			private readonly ParamBool _paramSnap;

			// Token: 0x040001C7 RID: 455
			private readonly ParamEnumButton _paramSnapSize;

			// Token: 0x040001C8 RID: 456
			private readonly ParamButton _actionResetAngles = new ParamButton(Localizer.Localize("PARAM_RESET_TILT", null));

			// Token: 0x040001C9 RID: 457
			private Key _keyStart;

			// Token: 0x040001CA RID: 458
			private bool _keyMoving;
		}

		// Token: 0x0200005C RID: 92
		public class SelectMode : ToolObject.Mode
		{
			// Token: 0x06000421 RID: 1057 RVA: 0x0000FE76 File Offset: 0x0000E076
			public SelectMode(ToolObject context) : base(Localizer.Localize("TOOL_OBJECT_MODE_SELECT", null) + " (1)", "tools/objects/Tool_Select.png", context)
			{
			}

			// Token: 0x06000422 RID: 1058 RVA: 0x0000FE9C File Offset: 0x0000E09C
			public override string GetContextHelp()
			{
				return string.Concat(new string[]
				{
					Localizer.Localize("HELP_CONTROLS_SELECTOBJECT", null),
					"\r\n",
					Localizer.Localize("HELP_DELETE_OBJECT", null),
					"\r\n\r\n",
					Localizer.Localize("HELP_TOOL_SELECTOBJECT", null),
					"\r\n\r\n",
					Localizer.Localize("HELP_GROUP_SELECTION", null),
					"\r\n\r\n",
					Localizer.Localize("HELP_NEIGHBORHOOD_SELECTION", null)
				});
			}

			// Token: 0x06000423 RID: 1059 RVA: 0x0001017C File Offset: 0x0000E37C
			protected override IEnumerable<Parameter> GetParameters()
			{
				yield return this._context._textSelected;
				yield return this._context._paramUseSelectionCenter;
				yield return this._context._paramMagicWand;
				yield return this._context._actionCopyClipboard;
				yield return this._context._actionPasteFromClipboard;
				yield return this._context._actionDelete;
				yield return this._context._actionFreeze;
				yield return this._context._actionUnfreeze;
				yield return this._context._paramObjectSelection;
				yield return this._context._actionGotoObject;
				yield break;
			}

			// Token: 0x06000424 RID: 1060 RVA: 0x0001019C File Offset: 0x0000E39C
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				if (mouseEvent == Editor.MouseEvent.MouseDown)
				{
					if (this._context._gizmoActive && this._context._gizmo.IsValid && this._context._gizmo.Active != Axis.None)
					{
						if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl) && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
						{
							EditorObjectSelection editorObjectSelection = EditorObjectSelection.Create();
							this._context._selection.Clone(editorObjectSelection, true);
							int num = this._context._selection.IndexOf(this._context._gizmoObject);
							this._context.SetSelection(editorObjectSelection, (num != -1) ? editorObjectSelection[num] : EditorObject.Null, true);
						}
						ToolObject.MoveAction moveAction = new ToolObject.MoveAction(this._context);
						moveAction.Start(this._context._gizmo.Position);
					}
					else
					{
						ToolObject.SelectAction selectAction = new ToolObject.SelectAction(this._context);
						selectAction.Start();
					}
				}
				return false;
			}

			// Token: 0x06000425 RID: 1061 RVA: 0x0001029A File Offset: 0x0000E49A
			public override void Activate()
			{
				base.Activate();
				this._context.SetGizmoRotationMode(false);
				this._context.UpdateGotoObject();
			}
		}

		// Token: 0x0200005E RID: 94
		private class SelectAction : InputBase
		{
			// Token: 0x0600042F RID: 1071 RVA: 0x000102EB File Offset: 0x0000E4EB
			public SelectAction(ToolObject context)
			{
				this._context = context;
			}

			// Token: 0x06000430 RID: 1072 RVA: 0x000102FA File Offset: 0x0000E4FA
			public bool Start()
			{
				this._dragStart = Editor.Viewport.NormalizedMousePos;
				base.AcquireInput();
				return true;
			}

			// Token: 0x06000431 RID: 1073 RVA: 0x00010314 File Offset: 0x0000E514
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				if (mouseEvent == Editor.MouseEvent.MouseUp)
				{
					bool flag = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
					bool flag2 = Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt);
					bool flag3 = Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift);
					EditorObjectSelection editorObjectSelection = EditorObjectSelection.Create();
					if (flag || flag3 || flag2)
					{
						this._context._selection.Clone(editorObjectSelection, false);
					}
					EditorObject gizmoObject = EditorObject.Null;
					Rect dragRectangle = this.DragRectangle;
					if (this.IsDragRectangle(dragRectangle))
					{
						EditorObjectSelection selection;
						if (flag || flag2)
						{
							selection = EditorObjectSelection.Create();
						}
						else
						{
							selection = editorObjectSelection;
						}
						ObjectManager.GetObjectsFromScreenRect(selection, this.DragRectangle);
						if (flag)
						{
							editorObjectSelection.ToggleSelection(selection);
							selection.Dispose();
						}
						else if (flag2)
						{
							editorObjectSelection.RemoveSelection(selection);
							selection.Dispose();
						}
						if (editorObjectSelection.Count > 0 && !this._context._gizmoEnabled)
						{
							this._context.EnableGizmo(true);
						}
					}
					else
					{
						Vec3 vec;
						EditorObject objectFromScreenPoint = ObjectManager.GetObjectFromScreenPoint(Editor.Viewport.NormalizedMousePos, out vec);
						if (objectFromScreenPoint.IsValid)
						{
							this._context.SelectObject(editorObjectSelection, objectFromScreenPoint);
							gizmoObject = objectFromScreenPoint;
							if (!this._context._gizmoEnabled)
							{
								this._context.EnableGizmo(true);
							}
						}
					}
					this._context.SetSelection(editorObjectSelection, gizmoObject, true);
					base.ReleaseInput();
				}
				return false;
			}

			// Token: 0x06000432 RID: 1074 RVA: 0x00010468 File Offset: 0x0000E668
			public override void Update(float dt)
			{
				Rect dragRectangle = this.DragRectangle;
				if (this.IsDragRectangle(dragRectangle))
				{
					Render.DrawScreenRectangleOutlined(dragRectangle, 1f, 0.00125f, Colors.White);
				}
			}

			// Token: 0x170000DC RID: 220
			// (get) Token: 0x06000433 RID: 1075 RVA: 0x0001049C File Offset: 0x0000E69C
			private Rect DragRectangle
			{
				get
				{
					Vec2 dragStart = this._dragStart;
					Vec2 normalizedMousePos = Editor.Viewport.NormalizedMousePos;
					Vec2 vec = new Vec2(Math.Min(dragStart.X, normalizedMousePos.X), Math.Min(dragStart.Y, normalizedMousePos.Y));
					Vec2 vec2 = new Vec2(Math.Max(dragStart.X, normalizedMousePos.X), Math.Max(dragStart.Y, normalizedMousePos.Y));
					return new Rect((double)vec.X, (double)vec.Y, (double)(vec2.X - vec.X), (double)(vec2.Y - vec.Y));
				}
			}

			// Token: 0x06000434 RID: 1076 RVA: 0x0001054C File Offset: 0x0000E74C
			private bool IsDragRectangle(Rect rect)
			{
				return rect.Size.Width > 0.009999999776482582 && rect.Size.Height > 0.009999999776482582;
			}

			// Token: 0x040001CB RID: 459
			private readonly ToolObject _context;

			// Token: 0x040001CC RID: 460
			private Vec2 _dragStart;
		}

		// Token: 0x0200005F RID: 95
		private class MoveAction : InputBase
		{
			// Token: 0x06000435 RID: 1077 RVA: 0x0001058F File Offset: 0x0000E78F
			public MoveAction(ToolObject context)
			{
				this._context = context;
			}

			// Token: 0x06000436 RID: 1078 RVA: 0x000105A9 File Offset: 0x0000E7A9
			public void ClearSnap()
			{
				this.m_snap = false;
				this.m_snapObject = EditorObject.Null;
			}

			// Token: 0x06000437 RID: 1079 RVA: 0x000105BD File Offset: 0x0000E7BD
			public void SetSnap(float snapSize)
			{
				this.m_snap = true;
				this.m_snapSize = snapSize;
				this.m_snapObject = EditorObject.Null;
			}

			// Token: 0x06000438 RID: 1080 RVA: 0x000105D8 File Offset: 0x0000E7D8
			public void SetSnap(EditorObject snapObject)
			{
				this.m_snap = true;
				this.m_snapObject = snapObject;
			}

			// Token: 0x06000439 RID: 1081 RVA: 0x000105E8 File Offset: 0x0000E7E8
			public bool Start(Vec3 pivot)
			{
				this.m_refGizmo = this._context._gizmo;
				this.m_gizmoHelper.InitVirtualPlane(this.m_refGizmo.Position, this.m_refGizmo.Axis, this.m_refGizmo.Active);
				if (!this.m_gizmoHelper.GetVirtualPos(out this.m_virtualStart))
				{
					return false;
				}
				this.m_pivot = pivot;
				this.m_startPosition = pivot;
				base.AcquireInput();
				this._context._selection.SaveState();
				return true;
			}

			// Token: 0x0600043A RID: 1082 RVA: 0x0001066C File Offset: 0x0000E86C
			public override void OnInputAcquire()
			{
				this._context._selection.Center = this.m_pivot;
				this._context.UpdateSelection(false, true);
				UndoManager.RecordUndo();
			}

			// Token: 0x0600043B RID: 1083 RVA: 0x00010696 File Offset: 0x0000E896
			public override void OnInputRelease()
			{
				UndoManager.CommitUndo();
				this._context.UpdateSelection(true, true);
			}

			// Token: 0x0600043C RID: 1084 RVA: 0x000106AC File Offset: 0x0000E8AC
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				switch (mouseEvent)
				{
				case Editor.MouseEvent.MouseUp:
					base.ReleaseInput();
					if (!BudgetManager.CheckSectorBudget(this._context._selection, true))
					{
						UndoManager.Undo();
					}
					break;
				case Editor.MouseEvent.MouseMove:
				{
					Vec3 v;
					if (this.m_gizmoHelper.GetVirtualPos(out v))
					{
						Vec3 vec = v - this.m_virtualStart;
						if (this.m_snap)
						{
							vec = this.m_refGizmo.Axis.ConvertFromWorld(vec);
							if (!this.m_snapObject.IsValid)
							{
								vec.Snap(this.m_snapSize);
							}
							else if (this.m_snapObject.IsLoaded)
							{
								vec.Snap(this.m_snapObject.LocalBounds.Length);
							}
							else
							{
								vec = new Vec3(0f, 0f, 0f);
							}
							vec = this.m_refGizmo.Axis.ConvertToWorld(vec);
						}
						Vec3 vec2 = this.m_startPosition + vec;
						this._context._selection.LoadState();
						this._context._selection.MoveTo(vec2, EditorObjectSelection.MoveMode.MoveNormal);
						this._context._selection.SnapToClosestObjects();
						this.m_pivot = vec2;
						this._context.UpdateSelection(false, false);
					}
					break;
				}
				}
				return false;
			}

			// Token: 0x040001CD RID: 461
			private ToolObject _context;

			// Token: 0x040001CE RID: 462
			private Vec3 m_startPosition;

			// Token: 0x040001CF RID: 463
			private Vec3 m_virtualStart;

			// Token: 0x040001D0 RID: 464
			private Vec3 m_pivot;

			// Token: 0x040001D1 RID: 465
			private Gizmo m_refGizmo;

			// Token: 0x040001D2 RID: 466
			private GizmoHelper m_gizmoHelper = new GizmoHelper();

			// Token: 0x040001D3 RID: 467
			private bool m_snap;

			// Token: 0x040001D4 RID: 468
			private float m_snapSize;

			// Token: 0x040001D5 RID: 469
			private EditorObject m_snapObject;
		}

		// Token: 0x02000060 RID: 96
		private class RotateAction : InputBase
		{
			// Token: 0x0600043D RID: 1085 RVA: 0x000107F6 File Offset: 0x0000E9F6
			public RotateAction(ToolObject context)
			{
				this._context = context;
			}

			// Token: 0x0600043E RID: 1086 RVA: 0x00010805 File Offset: 0x0000EA05
			public void ClearSnap()
			{
				this._snap = false;
			}

			// Token: 0x0600043F RID: 1087 RVA: 0x0001080E File Offset: 0x0000EA0E
			public void SetSnap(float snapSize)
			{
				this._snap = true;
				this._snapSize = snapSize;
			}

			// Token: 0x06000440 RID: 1088 RVA: 0x0001081E File Offset: 0x0000EA1E
			public bool Start(Vec3 rotationPivot, Vec3 rotationAxis)
			{
				this._rotationPivot = rotationPivot;
				this._rotationAxis = rotationAxis;
				base.AcquireInput();
				this._context._selection.SaveState();
				return true;
			}

			// Token: 0x06000441 RID: 1089 RVA: 0x00010845 File Offset: 0x0000EA45
			public override void OnInputAcquire()
			{
				UndoManager.RecordUndo();
				Editor.Viewport.CaptureMouse = true;
			}

			// Token: 0x06000442 RID: 1090 RVA: 0x00010857 File Offset: 0x0000EA57
			public override void OnInputRelease()
			{
				Editor.Viewport.CaptureMouse = false;
				UndoManager.CommitUndo();
			}

			// Token: 0x06000443 RID: 1091 RVA: 0x0001086C File Offset: 0x0000EA6C
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				switch (mouseEvent)
				{
				case Editor.MouseEvent.MouseUp:
					base.ReleaseInput();
					if (!BudgetManager.CheckSectorBudget(this._context._selection, true))
					{
						UndoManager.Undo();
					}
					break;
				case Editor.MouseEvent.MouseMoveDelta:
				{
					Vec3 rotationAxis = this._rotationAxis;
					Vec2 xz = Camera.Axis.ConvertFromWorld(rotationAxis).XZ;
					xz.Normalize();
					xz.Rotate90CW();
					Vec2 v = new Vec2((float)mouseEventArgs.X, (float)(-(float)mouseEventArgs.Y));
					float num = Vec2.Dot(xz, v);
					float angle;
					if (!this._snap)
					{
						angle = num * 0.025f;
					}
					else
					{
						this._rotationDelta += num;
						float num2 = (float)Math.IEEERemainder((double)this._rotationDelta, 25.0);
						angle = (this._rotationDelta - num2) / 25f * MathUtils.Deg2Rad(this._snapSize);
						this._rotationDelta = num2;
					}
					this._context._selection.LoadState();
					switch ((AxisType)this._context._paramAxisType.Value)
					{
					case AxisType.Local:
						this._context._selection.Rotate(angle, rotationAxis, this._rotationPivot, false);
						break;
					case AxisType.World:
						if (this._context._selection.Count > 1)
						{
							this._context._selection.RotateCenter(angle, rotationAxis);
						}
						else
						{
							this._context._selection.Rotate(angle, rotationAxis, this._rotationPivot, false);
						}
						break;
					}
					this._context._selection.SaveState();
					this._context._selection.SnapToClosestObjects();
					this._context.UpdateSelection(false, false);
					break;
				}
				}
				return false;
			}

			// Token: 0x040001D6 RID: 470
			private readonly ToolObject _context;

			// Token: 0x040001D7 RID: 471
			private Vec3 _rotationPivot;

			// Token: 0x040001D8 RID: 472
			private Vec3 _rotationAxis;

			// Token: 0x040001D9 RID: 473
			private float _rotationDelta;

			// Token: 0x040001DA RID: 474
			private bool _snap;

			// Token: 0x040001DB RID: 475
			private float _snapSize;
		}

		// Token: 0x02000061 RID: 97
		private class MovePhysicsAction : InputBase
		{
			// Token: 0x06000444 RID: 1092 RVA: 0x00010A27 File Offset: 0x0000EC27
			public MovePhysicsAction(ToolObject context)
			{
				this._context = context;
			}

			// Token: 0x06000445 RID: 1093 RVA: 0x00010A38 File Offset: 0x0000EC38
			public virtual bool Start(Vec3 pivot)
			{
				this._pivot = pivot;
				this._delayedMove = true;
				Win32.GetCursorPos(out this._delayedMoveStart);
				if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
				{
					this._localRotate = true;
					Editor.Viewport.CaptureMouse = true;
				}
				base.AcquireInput();
				this._context._selection.SaveState();
				return true;
			}

			// Token: 0x06000446 RID: 1094 RVA: 0x00010A9A File Offset: 0x0000EC9A
			public override void OnInputAcquire()
			{
				Editor.Viewport.CaptureWheel = true;
				this._context._selection.Center = this._pivot;
				this._context.UpdateSelection(false, true);
				UndoManager.RecordUndo();
			}

			// Token: 0x06000447 RID: 1095 RVA: 0x00010ACF File Offset: 0x0000ECCF
			public override void OnInputRelease()
			{
				Editor.Viewport.CaptureWheel = false;
				this.SetLocalRotate(false);
				UndoManager.CommitUndo();
				this._context.UpdateSelection(true, true);
			}

			// Token: 0x06000448 RID: 1096 RVA: 0x00010AF8 File Offset: 0x0000ECF8
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				switch (mouseEvent)
				{
				case Editor.MouseEvent.MouseUp:
					base.ReleaseInput();
					break;
				case Editor.MouseEvent.MouseMove:
				{
					if (this._delayedMove)
					{
						Win32.Point point = default(Win32.Point);
						bool cursorPos = Win32.GetCursorPos(out point);
						if (cursorPos && Math.Abs(this._delayedMoveStart.x - point.x) < 2 && Math.Abs(this._delayedMoveStart.y - point.y) < 2)
						{
							break;
						}
						if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
						{
							EditorObjectSelection editorObjectSelection = EditorObjectSelection.Create();
							this._context._selection.Clone(editorObjectSelection, true);
							int num = this._context._selection.IndexOf(this._context._gizmoObject);
							this._context.SetSelection(editorObjectSelection, (num != -1) ? editorObjectSelection[num] : EditorObject.Null, true);
						}
						Vec2 normalizedMousePos;
						if (Editor.GetScreenPointFromWorldPos(this._pivot, out normalizedMousePos))
						{
							Editor.Viewport.NormalizedMousePos = normalizedMousePos;
						}
						this._delayedMove = false;
					}
					Vec3 raySrc;
					Vec3 rayDir;
					Editor.GetWorldRayFromScreenPoint(Editor.Viewport.NormalizedMousePos, out raySrc, out rayDir);
					Vec3 vec;
					float num2;
					Vec3 normal;
					if (Editor.RayCastPhysics(raySrc, rayDir, this._context._selection, out vec, out num2, out normal))
					{
						this._context._selection.Center = this._pivot;
						this._context._selection.LoadState();
						if (this._context._selection.Count == 1)
						{
							EditorObject editorObject = this._context._selection[0];
							if (editorObject.Entry.AutoOrientation)
							{
								Vec3 angles;
								editorObject.ComputeAutoOrientation(ref vec, out angles, normal);
								editorObject.Angles = angles;
							}
						}
						this._context._selection.MoveTo(vec, EditorObjectSelection.MoveMode.MoveNormal);
						this._context._selection.SnapToClosestObjects();
						this._pivot = vec;
						this._context.UpdateSelection(false, false);
					}
					break;
				}
				case Editor.MouseEvent.MouseMoveDelta:
					this._context._selection.LoadState();
					this._context._selection.RotateCenter(0.025f * (float)mouseEventArgs.X, new Vec3(0f, 0f, 1f));
					this._context._selection.SaveState();
					this._context._selection.SnapToClosestObjects();
					break;
				case Editor.MouseEvent.MouseWheel:
				{
					this._context._selection.LoadState();
					Vec3 center = this._context._selection.Center;
					center.Z += (float)((0.3f * (float)mouseEventArgs.Delta > 0f) ? 1 : -1);
					this._context._selection.MoveTo(center, EditorObjectSelection.MoveMode.MoveNormal);
					this._context._selection.SaveState();
					break;
				}
				}
				return false;
			}

			// Token: 0x06000449 RID: 1097 RVA: 0x00010DBC File Offset: 0x0000EFBC
			public override bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
			{
				switch (keyEvent)
				{
				case Editor.KeyEvent.KeyDown:
					if (keyEventArgs.KeyCode == Key.LeftCtrl || keyEventArgs.KeyCode == Key.RightCtrl)
					{
						this.SetLocalRotate(true);
						return true;
					}
					break;
				case Editor.KeyEvent.KeyUp:
					if (keyEventArgs.KeyCode == Key.LeftCtrl || keyEventArgs.KeyCode == Key.RightCtrl)
					{
						this.SetLocalRotate(false);
						return true;
					}
					break;
				}
				return false;
			}

			// Token: 0x0600044A RID: 1098 RVA: 0x00010E1C File Offset: 0x0000F01C
			private void SetLocalRotate(bool localRotate)
			{
				if (this._localRotate == localRotate)
				{
					return;
				}
				if (localRotate)
				{
					this._context._selection.LoadState();
					this._localRotate = true;
					Editor.Viewport.CaptureMouse = true;
					return;
				}
				this._context._selection.SaveState();
				this._localRotate = false;
				Editor.Viewport.CaptureMouse = false;
			}

			// Token: 0x040001DC RID: 476
			private ToolObject _context;

			// Token: 0x040001DD RID: 477
			private bool _delayedMove;

			// Token: 0x040001DE RID: 478
			private Win32.Point _delayedMoveStart;

			// Token: 0x040001DF RID: 479
			private bool _localRotate;

			// Token: 0x040001E0 RID: 480
			private Vec3 _pivot;
		}

		// Token: 0x02000062 RID: 98
		private class SnapAction : InputBase
		{
			// Token: 0x0600044B RID: 1099 RVA: 0x00010E7B File Offset: 0x0000F07B
			public SnapAction(ToolObject context)
			{
				this._context = context;
			}

			// Token: 0x0600044C RID: 1100 RVA: 0x00010E8C File Offset: 0x0000F08C
			public bool Start()
			{
				Vec3 pos;
				this._source = ObjectManager.GetObjectFromScreenPoint(Editor.Viewport.NormalizedMousePos, out pos);
				if (!this._source.IsValid)
				{
					return false;
				}
				if (!this._source.GetClosestPivot(pos, out this._sourcePivot))
				{
					return false;
				}
				if (!this._context._selection.Contains(this._source))
				{
					EditorObjectSelection editorObjectSelection = EditorObjectSelection.Create();
					if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
					{
						this._context._selection.Clone(editorObjectSelection, false);
					}
					this._context.SelectObject(editorObjectSelection, this._source);
					this._context.SetSelection(editorObjectSelection, this._source, true);
				}
				base.AcquireInput();
				return true;
			}

			// Token: 0x0600044D RID: 1101 RVA: 0x00010F44 File Offset: 0x0000F144
			public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
			{
				switch (mouseEvent)
				{
				case Editor.MouseEvent.MouseUp:
				{
					Vec3 pos;
					EditorObject objectFromScreenPoint = ObjectManager.GetObjectFromScreenPoint(Editor.Viewport.NormalizedMousePos, out pos, false, this._source);
					if (objectFromScreenPoint.IsValid && objectFromScreenPoint.GetClosestPivot(pos, out this._targetPivot))
					{
						UndoManager.RecordUndo();
						this._context._selection.Center = this._sourcePivot.position;
						this._context._selection.SnapToPivot(this._sourcePivot, this._targetPivot, this.PreserveOrientation, this._angle);
						UndoManager.CommitUndo();
					}
					base.ReleaseInput();
					if (!BudgetManager.CheckSectorBudget(this._context._selection, true))
					{
						UndoManager.Undo();
					}
					break;
				}
				case Editor.MouseEvent.MouseMove:
				{
					Vec3 pos2;
					this._target = ObjectManager.GetObjectFromScreenPoint(Editor.Viewport.NormalizedMousePos, out pos2, false, this._source);
					if (this._target.IsValid)
					{
						this._target.GetClosestPivot(pos2, out this._targetPivot);
					}
					break;
				}
				}
				return false;
			}

			// Token: 0x0600044E RID: 1102 RVA: 0x0001104C File Offset: 0x0000F24C
			public override void Update(float dt)
			{
				bool flag = false;
				bool flag2 = false;
				Vec2 center = default(Vec2);
				Vec2 center2 = default(Vec2);
				if (this._source != null && this._source.IsValid)
				{
					flag = Editor.GetScreenPointFromWorldPos(this._sourcePivot.position, out center);
				}
				if (this._target != null && this._target.IsValid)
				{
					flag2 = Editor.GetScreenPointFromWorldPos(this._targetPivot.position, out center2);
				}
				if (flag)
				{
					Render.DrawScreenCircleOutlined(center, 0f, 0.0005f, 0.001f, Colors.Red);
				}
				if (flag2)
				{
					Render.DrawScreenCircleOutlined(center2, 0f, 0.0005f, 0.001f, Colors.Yellow);
				}
			}

			// Token: 0x170000DD RID: 221
			// (get) Token: 0x0600044F RID: 1103 RVA: 0x00011103 File Offset: 0x0000F303
			// (set) Token: 0x06000450 RID: 1104 RVA: 0x0001110B File Offset: 0x0000F30B
			public bool PreserveOrientation
			{
				get
				{
					return this._preserveOrientation;
				}
				set
				{
					this._preserveOrientation = value;
				}
			}

			// Token: 0x170000DE RID: 222
			// (get) Token: 0x06000451 RID: 1105 RVA: 0x00011114 File Offset: 0x0000F314
			// (set) Token: 0x06000452 RID: 1106 RVA: 0x0001111C File Offset: 0x0000F31C
			public float AngleSnap
			{
				get
				{
					return this._angle;
				}
				set
				{
					this._angle = value;
				}
			}

			// Token: 0x040001E1 RID: 481
			private readonly ToolObject _context;

			// Token: 0x040001E2 RID: 482
			private bool _preserveOrientation;

			// Token: 0x040001E3 RID: 483
			private float _angle;

			// Token: 0x040001E4 RID: 484
			private EditorObject _source;

			// Token: 0x040001E5 RID: 485
			private EditorObjectPivot _sourcePivot;

			// Token: 0x040001E6 RID: 486
			private EditorObject _target;

			// Token: 0x040001E7 RID: 487
			private EditorObjectPivot _targetPivot;
		}
	}
}

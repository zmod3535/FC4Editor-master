using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000080 RID: 128
	internal class ToolNavmesh : Tool, IInputSink
	{
		// Token: 0x06000563 RID: 1379 RVA: 0x00014738 File Offset: 0x00012938
		public ToolNavmesh() : base(Localizer.Localize("TOOL_NAVMESH", null), "toolbar/miscellaneous/Navmesh.png")
		{
			this._paramLayer = new ParamEnumButton(Localizer.Localize("PARAM_NAVMESH_LAYER", null), new ParamEnumButtonImage[]
			{
				new ParamEnumButtonImage(Localizer.Localize("PARAM_CHARACTER", null), "tools/aiData/Character.png", Navmesh.Layer.Character),
				new ParamEnumButtonImage(Localizer.Localize("PARAM_VEHICLE", null), "tools/aiData/Vehicle.png", Navmesh.Layer.Vehicle)
			}, delegate(object sender, object oldValue, object newValue)
			{
				this.paramLayer_ValueChanged();
			});
			this._displayNavmesh = new ParamBool(Localizer.Localize("PARAM_DISPLAY_NAVMESH", null), delegate(bool value)
			{
				this.UpdateDisplay();
			});
			this._displayActionPoints = new ParamBool(Localizer.Localize("PARAM_DISPLAY_ACTIONPOINTS", null), delegate(bool value)
			{
				this.UpdateDisplay();
			});
			this._displayAlpha = new ParamFloat(Localizer.Localize("PARAM_TRANSPARENCY", null), 0f, 1f, 0.01f, delegate(float value)
			{
				Navmesh.DebugAlpha = 1f - value;
			});
			this._regenerateTile = new ParamCheckButton("Regenerate tile", new ParamCheckButton.CheckedDelegate(this.regenerateTile_Activate), new ParamCheckButton.CheckedDelegate(this.regenerateTile_Deactivate));
			this._displayNavmesh.Value = false;
			this._displayActionPoints.Value = false;
			this._displayAlpha.Value = 0.7f;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x000149F4 File Offset: 0x00012BF4
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this._paramLayer;
			yield return this._displayNavmesh;
			yield return this._displayActionPoints;
			yield return this._displayAlpha;
			yield break;
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00014A11 File Offset: 0x00012C11
		public Parameter GetMainParameter()
		{
			return null;
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x00014A14 File Offset: 0x00012C14
		public override string GetContextHelp()
		{
			return Localizer.LocalizeCommon("HELP_SETTINGS_SHOW_NAVMESH") + "\r\n\r\n" + Localizer.LocalizeCommon("HELP_SETTINGS_SHOW_COVERS");
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x00014A34 File Offset: 0x00012C34
		private void UpdateDisplay()
		{
			if (this._displayNavmesh.Value)
			{
				Navmesh.Layer layer = (this._paramLayer.Value != null) ? ((Navmesh.Layer)this._paramLayer.Value) : EditorSettings.NavmeshLayer;
				EditorSettings.ShowNavmesh(layer);
			}
			else
			{
				EditorSettings.HideNavmesh();
			}
			EditorSettings.ShowCovers = this._displayActionPoints.Value;
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00014A90 File Offset: 0x00012C90
		public override void Activate()
		{
			if (!EditorDocument.NavmeshEnabled)
			{
				if (MessageBox.Show(Program.MainWin, Localizer.Localize("EDITOR_NAVMESH_PROMPT", null), Localizer.Localize("EDITOR_CONFIRMATION", null), MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
				{
					base.Parent.ActiveTool = null;
					return;
				}
				EditorDocument.NavmeshEnabled = true;
			}
			this._displayAlpha.Value = 1f - Navmesh.DebugAlpha;
			this._displayNavmesh.Value = EditorSettings.IsNavmeshVisible;
			this._paramLayer.Value = EditorSettings.NavmeshLayer;
			this._displayActionPoints.Value = EditorSettings.ShowCovers;
			this.UpdateDisplay();
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x00014B30 File Offset: 0x00012D30
		public override void Deactivate()
		{
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00014B32 File Offset: 0x00012D32
		public void OnSwitchFrom(Tool prevTool)
		{
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00014B34 File Offset: 0x00012D34
		public void OnSwitchTo(Tool nextTool)
		{
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x00014B36 File Offset: 0x00012D36
		private void paramLayer_ValueChanged()
		{
			this.UpdateDisplay();
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x00014B3E File Offset: 0x00012D3E
		private void regenerateTile_Activate()
		{
			this._regenerating = true;
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x00014B47 File Offset: 0x00012D47
		private void regenerateTile_Deactivate()
		{
			this._regenerating = false;
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00014B50 File Offset: 0x00012D50
		public void OnInputAcquire()
		{
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x00014B52 File Offset: 0x00012D52
		public void OnInputRelease()
		{
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00014B54 File Offset: 0x00012D54
		public bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			switch (mouseEvent)
			{
			case Editor.MouseEvent.MouseUp:
				if (mouseEventArgs.Button == MouseButton.Left && this._cursorValid)
				{
					Navmesh.RegenerateTileAt(this._cursorPos.XY, true);
					this._regenerateTile.IsChecked = false;
				}
				break;
			case Editor.MouseEvent.MouseMove:
				this._cursorValid = Editor.RayCastTerrainFromMouse(out this._cursorPos);
				break;
			}
			return false;
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x00014BB6 File Offset: 0x00012DB6
		public bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			return false;
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x00014BB9 File Offset: 0x00012DB9
		public void OnEditorEvent(uint eventType, IntPtr eventPtr)
		{
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00014BBC File Offset: 0x00012DBC
		private static Vec3 GetTileCenter(Vec3 cursorPos)
		{
			return new Vec3
			{
				X = cursorPos.X + 4f - cursorPos.X % 8f,
				Y = cursorPos.Y + 4f - cursorPos.Y % 8f,
				Z = cursorPos.Z
			};
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00014C28 File Offset: 0x00012E28
		public void Update(float dt)
		{
			if (this._regenerating && this._cursorValid)
			{
				Render.DrawTerrainSquare(ToolNavmesh.GetTileCenter(this._cursorPos).XY, 4f, 0.5f, Colors.DarkGreen, 0.01f, 0.31f);
			}
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x00014C76 File Offset: 0x00012E76
		public void ToggleNavmesh()
		{
			this._displayNavmesh.Value = !this._displayNavmesh.Value;
		}

		// Token: 0x04000244 RID: 580
		private readonly ParamEnumButton _paramLayer;

		// Token: 0x04000245 RID: 581
		private readonly ParamBool _displayNavmesh;

		// Token: 0x04000246 RID: 582
		private readonly ParamBool _displayActionPoints;

		// Token: 0x04000247 RID: 583
		private readonly ParamFloat _displayAlpha;

		// Token: 0x04000248 RID: 584
		private readonly ParamCheckButton _regenerateTile;

		// Token: 0x04000249 RID: 585
		private bool _regenerating;

		// Token: 0x0400024A RID: 586
		private bool _cursorValid;

		// Token: 0x0400024B RID: 587
		private Vec3 _cursorPos;
	}
}

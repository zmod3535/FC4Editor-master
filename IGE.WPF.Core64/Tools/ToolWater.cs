using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000065 RID: 101
	internal class ToolWater : Tool, IInputSink
	{
		// Token: 0x0600045C RID: 1116 RVA: 0x000114A8 File Offset: 0x0000F6A8
		public ToolWater() : base(Localizer.Localize("TOOL_WATER", null), "toolbar/terrain/water.png")
		{
			this.m_paramWaterMaterial.Value = WaterInventory.Instance.GetFromId("Lake_Ref_Small");
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x00011618 File Offset: 0x0000F818
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this.m_paramWaterLevel;
			yield return this.m_paramWaterMaterial;
			yield break;
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x00011635 File Offset: 0x0000F835
		public Parameter GetMainParameter()
		{
			return null;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x00011638 File Offset: 0x0000F838
		public override string GetContextHelp()
		{
			return Localizer.Localize("HELP_CONTROLS_WATER", null) + "\r\n\r\n" + Localizer.LocalizeCommon("HELP_TOOL_WATER");
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x00011659 File Offset: 0x0000F859
		public void OnSwitchFrom(Tool prevTool)
		{
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0001165B File Offset: 0x0000F85B
		public void OnSwitchTo(Tool nextTool)
		{
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0001165D File Offset: 0x0000F85D
		public void OnInputAcquire()
		{
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0001165F File Offset: 0x0000F85F
		public void OnInputRelease()
		{
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x00011664 File Offset: 0x0000F864
		private void OnMouseMove(Editor.MouseEventArgs mouseEventArgs)
		{
			this.m_cursorValid = Editor.RayCastTerrainFromMouse(out this.m_cursorPos);
			if (this.m_cursorValid)
			{
				this.m_cursorSX = (int)(this.m_cursorPos.X / 64f);
				this.m_cursorSY = (int)(this.m_cursorPos.Y / 64f);
				if (this.m_painting)
				{
					bool flag = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
					TerrainManager.SetWaterLevelSector(this.m_cursorSX, this.m_cursorSY, flag ? 0f : this.m_paramWaterLevel.Value, this.m_paramWaterMaterial.Value);
					TerrainManager.UpdateWaterLevel();
				}
			}
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x00011710 File Offset: 0x0000F910
		public bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			switch (mouseEvent)
			{
			case Editor.MouseEvent.MouseDown:
				if (mouseEventArgs.Button == MouseButton.Left)
				{
					this.m_painting = true;
					UndoManager.RecordUndo();
					this.OnMouseMove(mouseEventArgs);
				}
				break;
			case Editor.MouseEvent.MouseUp:
				if (this.m_painting)
				{
					this.m_painting = false;
					UndoManager.CommitUndo();
				}
				break;
			case Editor.MouseEvent.MouseMove:
				this.OnMouseMove(mouseEventArgs);
				break;
			}
			return false;
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0001176E File Offset: 0x0000F96E
		public bool OnKeyEvent(Editor.KeyEvent keyEvent, Editor.KeyEventArgs keyEventArgs)
		{
			return false;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x00011771 File Offset: 0x0000F971
		public void OnEditorEvent(uint eventType, IntPtr eventPtr)
		{
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x00011774 File Offset: 0x0000F974
		private void DrawSource(Vec3 cursorCenter)
		{
			bool flag = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
			Color color = flag ? Colors.Black : Colors.White;
			Color borderColor = flag ? Colors.White : Colors.Black;
			float length = (Camera.Position - cursorCenter).Length;
			Render.DrawTerrainSquare(cursorCenter.XY, 32f, length * 0.02f, color, 0.01f, 0.31f, borderColor);
			Render.DrawTerrainCircle(cursorCenter.XY, length * 0.0075f, length * 0.015f, color, 0f, 0f, borderColor);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x00011814 File Offset: 0x0000FA14
		private void DrawTarget(Vec3 cursorTarget)
		{
			float length = (Camera.Position - cursorTarget).Length;
			if (!this.m_painting)
			{
				Color turquoise = Colors.Turquoise;
				turquoise.A = 24;
				Render.DrawQuad(cursorTarget, 64f, 64f, turquoise);
			}
			Render.DrawSquare(cursorTarget, 32f, length * 0.02f, Colors.DarkGreen, 0f, Colors.Black);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x00011880 File Offset: 0x0000FA80
		public void Update(float dt)
		{
			if (this.m_cursorValid)
			{
				Vec3 vec = new Vec3((float)(this.m_cursorSX * 64 + 32), (float)(this.m_cursorSY * 64 + 32), 0f);
				vec.Z = TerrainManager.GetHeightAtWithWater(vec.XY);
				Vec3 vec2 = new Vec3(vec.X, vec.Y, this.m_paramWaterLevel.Value);
				float num = Vec3.Dot(vec - Camera.Position, Camera.FrontVector);
				float num2 = Vec3.Dot(vec2 - Camera.Position, Camera.FrontVector);
				bool flag = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);
				if (num > num2)
				{
					this.DrawSource(vec);
					if (!flag && !this.m_painting)
					{
						this.DrawTarget(vec2);
						return;
					}
				}
				else
				{
					if (!flag && !this.m_painting)
					{
						this.DrawTarget(vec2);
					}
					this.DrawSource(vec);
				}
			}
		}

		// Token: 0x040001EF RID: 495
		private ParamFloat m_paramWaterLevel = new ParamFloat(Localizer.Localize("PARAM_WATER_LEVEL", null), 60f, 0f, 500f, 0.1f);

		// Token: 0x040001F0 RID: 496
		private ParamWaterMaterial m_paramWaterMaterial = new ParamWaterMaterial();

		// Token: 0x040001F1 RID: 497
		private bool m_painting;

		// Token: 0x040001F2 RID: 498
		private bool m_cursorValid;

		// Token: 0x040001F3 RID: 499
		private Vec3 m_cursorPos;

		// Token: 0x040001F4 RID: 500
		private int m_cursorSX;

		// Token: 0x040001F5 RID: 501
		private int m_cursorSY;
	}
}

using System;
using System.Collections.Generic;
using System.Windows.Input;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000128 RID: 296
	internal class ToolTerrainSetHeight : ToolPaint
	{
		// Token: 0x06000A5E RID: 2654 RVA: 0x00022174 File Offset: 0x00020374
		public ToolTerrainSetHeight() : base(Localizer.Localize("TOOL_TERRAIN_SET_HEIGHT", null), "toolbar/terrain/TerrainEdit_SetHeight.png")
		{
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x000223D0 File Offset: 0x000205D0
		protected override IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in base._GetParameters())
			{
				yield return param;
			}
			yield return this.m_strength;
			yield return this.m_height;
			yield break;
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x000223F0 File Offset: 0x000205F0
		public override string GetContextHelp()
		{
			return string.Concat(new string[]
			{
				Localizer.Localize("HELP_PICK_HEIGHT", null),
				"\r\n",
				base.GetShortcutContextHelp(),
				"\r\n\r\n",
				Localizer.LocalizeCommon("HELP_TOOL_SETHEIGHT")
			});
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x00022440 File Offset: 0x00020640
		public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
			{
				this.m_picking = false;
				return base.OnMouseEvent(mouseEvent, mouseEventArgs);
			}
			switch (mouseEvent)
			{
			case Editor.MouseEvent.MouseDown:
				if (!this.m_picking)
				{
					this.m_picking = true;
					this.UpdatePicking();
				}
				break;
			case Editor.MouseEvent.MouseUp:
				this.m_picking = false;
				break;
			case Editor.MouseEvent.MouseMove:
				if (this.m_picking)
				{
					this.UpdatePicking();
				}
				break;
			}
			return false;
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x000224B4 File Offset: 0x000206B4
		protected override void OnBeginPaint()
		{
			base.OnBeginPaint();
			this.m_opacity.Value = this.m_strength.Value;
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x000224D4 File Offset: 0x000206D4
		protected override void OnPaint(float dt, Vec2 pos)
		{
			base.OnPaint(dt, pos);
			float value = this.m_height.Value;
			TerrainManipulator.SetHeight(pos, value, this.m_brush);
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x00022502 File Offset: 0x00020702
		protected override void OnEndPaint()
		{
			base.OnEndPaint();
			TerrainManipulator.SetHeight_End();
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0002250F File Offset: 0x0002070F
		public override void Update(float dt)
		{
			if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
			{
				base.Update(dt);
			}
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0002252A File Offset: 0x0002072A
		private void UpdatePicking()
		{
			this.m_height.Value = this.m_cursorPos.Z;
		}

		// Token: 0x040004F5 RID: 1269
		private bool m_picking;

		// Token: 0x040004F6 RID: 1270
		private ParamFloat m_height = new ParamFloat(Localizer.Localize("PARAM_HEIGHT", null), 60f, 0f, 500f, 0.01f);

		// Token: 0x040004F7 RID: 1271
		private ParamFloat m_strength = new ParamFloat(Localizer.Localize("PARAM_SPEED", null), 0.75f, 0f, 1f, 0.01f);
	}
}

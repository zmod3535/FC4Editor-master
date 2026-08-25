using System;
using System.Collections.Generic;
using System.Windows.Media;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x020000DB RID: 219
	internal class ToolTerrainRamp : ToolPaint
	{
		// Token: 0x060007F6 RID: 2038 RVA: 0x0001B8DF File Offset: 0x00019ADF
		public ToolTerrainRamp() : base(Localizer.Localize("TOOL_TERRAIN_RAMP", null), "toolbar/terrain/TerrainEdit_Ramp.png")
		{
			this.m_square.Enabled = false;
			this.m_distortion.Enabled = false;
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x0001BA0C File Offset: 0x00019C0C
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this.m_radius;
			yield return this.m_hardness;
			yield break;
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0001BA2C File Offset: 0x00019C2C
		public override string GetContextHelp()
		{
			return string.Concat(new string[]
			{
				Localizer.Localize("HELP_CONTROLS_RAMP", null),
				"\r\n",
				base.GetShortcutContextHelp(),
				"\r\n\r\n",
				Localizer.LocalizeCommon("HELP_TOOL_RAMP")
			});
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x0001BA7C File Offset: 0x00019C7C
		public override bool OnMouseEvent(Editor.MouseEvent mouseEvent, Editor.MouseEventArgs mouseEventArgs)
		{
			if (mouseEvent == Editor.MouseEvent.MouseUp && this.m_painting == ToolPaint.PaintingMode.None)
			{
				Vec3 vec;
				if (!this.m_rampStarted)
				{
					this.m_rampStarted = Editor.RayCastTerrainFromMouse(out this.m_rampStart);
				}
				else if (Editor.RayCastTerrainFromMouse(out vec))
				{
					UndoManager.RecordUndo();
					TerrainManipulator.Ramp(this.m_rampStart.XY, vec.XY, this.m_radius.Value, this.m_hardness.Value);
					UndoManager.CommitUndo();
					this.m_rampStarted = false;
				}
			}
			return base.OnMouseEvent(mouseEvent, mouseEventArgs);
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x0001BB01 File Offset: 0x00019D01
		protected override void OnBeginPaint()
		{
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x0001BB04 File Offset: 0x00019D04
		public override void Update(float dt)
		{
			if (this.m_rampStarted)
			{
				float length = (Camera.Position - this.m_rampStart).Length;
				Render.DrawTerrainCircle(this.m_rampStart.XY, this.m_radius.Value, length * 0.01f, Colors.OrangeRed, -0.001f, 0f);
				Render.DrawTerrainCircle(this.m_rampStart.XY, length * 0.00375f, length * 0.0075f, Colors.OrangeRed, -0.001f, 0f);
			}
			base.Update(dt);
		}

		// Token: 0x040003E7 RID: 999
		private Vec3 m_rampStart;

		// Token: 0x040003E8 RID: 1000
		private bool m_rampStarted;
	}
}

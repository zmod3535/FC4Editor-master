using System;
using System.Collections.Generic;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x0200037F RID: 895
	internal class ToolTerrainFlatten : ToolPaint
	{
		// Token: 0x06001406 RID: 5126 RVA: 0x0002A162 File Offset: 0x00028362
		public ToolTerrainFlatten() : base(Localizer.Localize("TOOL_TERRAIN_FLATTEN", null), "toolbar/terrain/TerrainEdit_Flatten.png")
		{
			this.m_opacity.Value = 0.75f;
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x0002A348 File Offset: 0x00028548
		protected override IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in base._GetParameters())
			{
				yield return param;
			}
			yield return this.m_opacity;
			yield break;
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x0002A368 File Offset: 0x00028568
		public override string GetContextHelp()
		{
			return string.Concat(new string[]
			{
				base.GetPaintContextHelp(),
				"\r\n",
				base.GetShortcutContextHelp(),
				"\r\n\r\n",
				Localizer.LocalizeCommon("HELP_TOOL_FLATTEN")
			});
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x0002A3B1 File Offset: 0x000285B1
		protected override void OnBeginPaint()
		{
			base.OnBeginPaint();
			this.m_height = TerrainManipulator.GetAverageHeight(this.m_cursorPos.XY, this.m_brush);
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x0002A3D5 File Offset: 0x000285D5
		protected override void OnPaint(float dt, Vec2 pos)
		{
			base.OnPaint(dt, pos);
			if (this.m_painting == ToolPaint.PaintingMode.Plus)
			{
				TerrainManipulator.SetHeight(pos, this.m_height, this.m_brush);
				return;
			}
			TerrainManipulator.Average(pos, this.m_brush);
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x0002A407 File Offset: 0x00028607
		protected override void OnEndPaint()
		{
			base.OnEndPaint();
			if (this.m_painting == ToolPaint.PaintingMode.Plus)
			{
				TerrainManipulator.SetHeight_End();
				return;
			}
			TerrainManipulator.Average_End();
		}

		// Token: 0x04000760 RID: 1888
		private float m_height;
	}
}

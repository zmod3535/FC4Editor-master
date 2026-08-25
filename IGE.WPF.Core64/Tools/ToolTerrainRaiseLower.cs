using System;
using System.Collections.Generic;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000109 RID: 265
	internal class ToolTerrainRaiseLower : ToolPaint
	{
		// Token: 0x06000938 RID: 2360 RVA: 0x0001EBF0 File Offset: 0x0001CDF0
		public ToolTerrainRaiseLower() : base(Localizer.Localize("TOOL_TERRAIN_RAISE_LOWER", null), "toolbar/terrain/TerrainEdit_RaiseLower.png")
		{
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x0001EDFC File Offset: 0x0001CFFC
		protected override IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in base._GetParameters())
			{
				yield return param;
			}
			yield return this.m_height;
			yield break;
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0001EE1C File Offset: 0x0001D01C
		public override string GetContextHelp()
		{
			return string.Concat(new string[]
			{
				base.GetPaintContextHelp(),
				"\r\n",
				base.GetShortcutContextHelp(),
				"\r\n\r\n",
				Localizer.LocalizeCommon("HELP_TOOL_RAISELOWER")
			});
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x0001EE68 File Offset: 0x0001D068
		protected override void OnPaint(float dt, Vec2 pos)
		{
			base.OnPaint(dt, pos);
			float value = this.m_height.Value;
			TerrainManipulator.RaiseLower(pos, (this.m_painting == ToolPaint.PaintingMode.Plus) ? value : (-value), this.m_brush);
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0001EEA3 File Offset: 0x0001D0A3
		protected override void OnEndPaint()
		{
			base.OnEndPaint();
			TerrainManipulator.RaiseLower_End();
		}

		// Token: 0x04000476 RID: 1142
		private ParamFloat m_height = new ParamFloat(Localizer.Localize("PARAM_HEIGHT", null), 5f, -32f, 32f, 0.01f);
	}
}

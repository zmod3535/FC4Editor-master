using System;
using System.Collections.Generic;
using System.Text;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x020000D9 RID: 217
	internal class ToolTerrainSmooth : ToolPaint
	{
		// Token: 0x060007EC RID: 2028 RVA: 0x0001B609 File Offset: 0x00019809
		public ToolTerrainSmooth() : base(Localizer.Localize("TOOL_TERRAIN_SMOOTH", null), "toolbar/terrain/TerrainEdit_Smooth.png")
		{
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0001B7E0 File Offset: 0x000199E0
		protected override IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in base._GetParameters())
			{
				yield return param;
			}
			yield return this.m_opacity;
			yield break;
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0001B800 File Offset: 0x00019A00
		public override string GetContextHelp()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.GetPaintNoReverseContextHelp()).Append("\r\n");
			stringBuilder.Append(base.GetShortcutContextHelp()).Append("\r\n");
			stringBuilder.Append("\r\n");
			stringBuilder.Append(Localizer.Localize("HELP_TOOL_SMOOTH", null));
			return stringBuilder.ToString();
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0001B865 File Offset: 0x00019A65
		protected override void OnPaint(float dt, Vec2 pos)
		{
			base.OnPaint(dt, pos);
			TerrainManipulator.Smooth(pos, this.m_brush);
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0001B87B File Offset: 0x00019A7B
		protected override void OnEndPaint()
		{
			base.OnEndPaint();
			TerrainManipulator.Smooth_End();
		}
	}
}

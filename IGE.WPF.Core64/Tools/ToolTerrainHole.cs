using System;
using System.Collections.Generic;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x02000380 RID: 896
	internal class ToolTerrainHole : ToolPaintStrict
	{
		// Token: 0x0600140C RID: 5132 RVA: 0x0002A434 File Offset: 0x00028634
		public ToolTerrainHole() : base(Localizer.Localize("TOOL_TERRAIN_HOLE", null), "toolbar/terrain/Hole.png")
		{
			List<ParamEnumText> values = new List<ParamEnumText>
			{
				new ParamEnumText(Localizer.LocalizeCommon("TOOLCONTROL_HOLE_ADD"), true),
				new ParamEnumText(Localizer.LocalizeCommon("TOOLCONTROL_HOLE_REMOVE"), false)
			};
			this._holeParam = new ParamEnumCombo(Localizer.Localize("PARAM_HOLE", null), values, delegate(object sender, object oldValue, object newValue)
			{
				this._makeHole = (bool)newValue;
			});
			this._holeParam.SelectedIndex = 0;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x0002A690 File Offset: 0x00028890
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this._holeParam;
			foreach (Parameter param in base._GetParameters())
			{
				yield return param;
			}
			yield break;
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x0002A6AD File Offset: 0x000288AD
		public override SingleParameter GetMainParameter()
		{
			return null;
		}

		// Token: 0x0600140F RID: 5135 RVA: 0x0002A6B0 File Offset: 0x000288B0
		public override string GetContextHelp()
		{
			return string.Concat(new string[]
			{
				Localizer.Localize("HELP_PAINT", null),
				"\r\n",
				Localizer.Localize("HELP_SHORTCUT", null),
				"\r\n\r\n",
				Localizer.LocalizeCommon("HELP_TOOL_HOLE")
			});
		}

		// Token: 0x06001410 RID: 5136 RVA: 0x0002A703 File Offset: 0x00028903
		protected override void OnPaint()
		{
			base.OnPaint();
			TerrainManipulator.Hole(this._snappedRect, (this._painting == ToolPaintStrict.PaintingMode.Plus) ? this._makeHole : (!this._makeHole));
		}

		// Token: 0x04000761 RID: 1889
		private bool _makeHole = true;

		// Token: 0x04000762 RID: 1890
		private ParamEnumCombo _holeParam;
	}
}

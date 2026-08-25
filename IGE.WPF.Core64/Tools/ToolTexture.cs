using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x020000A7 RID: 167
	internal class ToolTexture : ToolPaint
	{
		// Token: 0x060006C0 RID: 1728 RVA: 0x00018898 File Offset: 0x00016A98
		public ToolTexture()
		{
			int slotCount = 4;
			bool keepFirst = true;
			bool enableChange = true;
			bool showFolders = false;
			this._paramTexture = new ParamSlotListViewModel(Localizer.Localize("PARAM_TEXTURES", null), TextureInventory.Instance.Root, slotCount, keepFirst, enableChange, showFolders);
			this._paramStrength = new ParamFloat(Localizer.Localize("PARAM_SPEED", null), 0.5f, 0f, 1f, 0.01f);
			this._paramMinHeight = new ParamFloat(Localizer.Localize("PARAM_ALTITUDE_MIN", null), 0f, 0f, 255f, 0.01f);
			this._paramMaxHeight = new ParamFloat(Localizer.Localize("PARAM_ALTITUDE_MAX", null), 255f, 0f, 255f, 0.01f);
			this._paramHeightFuzziness = new ParamFloat(Localizer.Localize("PARAM_ALTITUDE_FUZZINESS", null), 0f, 0f, 32f, 0.01f);
			this._paramMinSlope = new ParamFloat(Localizer.Localize("PARAM_SLOPE_MIN", null), 0f, 0f, 90f, 0.01f);
			this._paramMaxSlope = new ParamFloat(Localizer.Localize("PARAM_SLOPE_MAX", null), 90f, 0f, 90f, 0.01f);
			base..ctor(Localizer.Localize("TOOL_TEXTURE", null), "toolbar/terrain/Texture.png");
			this._paramConstraints = new ParamBool(Localizer.Localize("PARAM_CONSTRAINTS", null), new ValueParameter<bool>.ValueChangedDelegate(this.SetConstraints))
			{
				Value = false
			};
			this._paramTexture.SlotChanged += delegate(object s, EventArgs ea)
			{
				this.OnAssignSlot(ea);
			};
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x00018D18 File Offset: 0x00016F18
		protected override IEnumerable<Parameter> GetParameters()
		{
			foreach (Parameter param in base._GetParameters())
			{
				yield return param;
			}
			yield return this._paramStrength;
			yield return this._paramTexture;
			yield return this._paramConstraints;
			yield return this._paramMinHeight;
			yield return this._paramMaxHeight;
			yield return this._paramHeightFuzziness;
			yield return this._paramMinSlope;
			yield return this._paramMaxSlope;
			yield break;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x00018D35 File Offset: 0x00016F35
		public override SingleParameter GetMainParameter()
		{
			return this._paramTexture;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00018D40 File Offset: 0x00016F40
		public override string GetContextHelp()
		{
			return string.Concat(new string[]
			{
				base.GetPaintContextHelp(),
				"\r\n",
				base.GetShortcutContextHelp(),
				"\r\n\r\n",
				Localizer.LocalizeCommon("HELP_TOOL_TEXTURE")
			});
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00018D8C File Offset: 0x00016F8C
		private void OnAssignSlot(EventArgs ea)
		{
			ParamSlotListViewModel.EntryChangeEventArgs entryChangeEventArgs = (ParamSlotListViewModel.EntryChangeEventArgs)ea;
			bool flag = entryChangeEventArgs.Entry == null || !entryChangeEventArgs.Entry.IsValid;
			if (flag)
			{
				TerrainManager.ClearTextureId(entryChangeEventArgs.Id);
				TerrainManager.AssignTextureId(entryChangeEventArgs.Id, TextureInventory.Entry.Null);
			}
			else
			{
				TerrainManager.AssignTextureId(entryChangeEventArgs.Id, (TextureInventory.Entry)entryChangeEventArgs.Entry);
			}
			this.UpdateTextureList(flag ? -1 : entryChangeEventArgs.Id);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00018E08 File Offset: 0x00017008
		private void SetConstraints(bool value)
		{
			Parameter paramMinHeight = this._paramMinHeight;
			Parameter paramMaxHeight = this._paramMaxHeight;
			Parameter paramHeightFuzziness = this._paramHeightFuzziness;
			Parameter paramMinSlope = this._paramMinSlope;
			this._paramMaxSlope.Enabled = value;
			paramMinSlope.Enabled = value;
			paramHeightFuzziness.Enabled = value;
			paramMaxHeight.Enabled = value;
			paramMinHeight.Enabled = value;
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00018E59 File Offset: 0x00017059
		public override void Activate()
		{
			base.Activate();
			this.UpdateTextureList(-1);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00018E68 File Offset: 0x00017068
		protected override void OnBeginPaint()
		{
			base.OnBeginPaint();
			if (this._paramConstraints.Value)
			{
				TextureManipulator.PaintConstraints_Begin(this._paramMinHeight.Value, this._paramMaxHeight.Value, this._paramHeightFuzziness.Value, this._paramMinSlope.Value, this._paramMaxSlope.Value);
			}
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00018EC4 File Offset: 0x000170C4
		protected override void OnPaint(float dt, Vec2 pos)
		{
			base.OnPaint(dt, pos);
			int num = (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) ? 0 : this._paramTexture.Value;
			if (num == -1)
			{
				return;
			}
			TextureInventory.Entry textureEntryFromId = TerrainManager.GetTextureEntryFromId(num);
			if (!textureEntryFromId.IsValid)
			{
				return;
			}
			if (!this._paramConstraints.Value)
			{
				TextureManipulator.Paint(pos, this._paramStrength.Value * 512f * dt, num, this.m_brush);
				return;
			}
			TextureManipulator.PaintConstraints(pos, this._paramStrength.Value * 512f * dt, num, this.m_brush);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00018F5D File Offset: 0x0001715D
		protected override void OnEndPaint()
		{
			base.OnEndPaint();
			if (!this._paramConstraints.Value)
			{
				TextureManipulator.Paint_End();
				return;
			}
			TextureManipulator.PaintConstraints_End();
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00018F80 File Offset: 0x00017180
		private void UpdateTextureList(int selection)
		{
			ObservableCollection<ParamSlotItemViewModel> observableCollection = new ObservableCollection<ParamSlotItemViewModel>();
			for (int i = 0; i < this._paramTexture.SlotCount; i++)
			{
				TextureInventory.Entry textureEntryFromId = TerrainManager.GetTextureEntryFromId(i);
				if (textureEntryFromId.IsValid)
				{
					observableCollection.Add(new ParamSlotItemViewModel(textureEntryFromId, i));
				}
			}
			this._paramTexture.Items = observableCollection;
			if (selection >= 0 && selection < this._paramTexture.Items.Count)
			{
				this._paramTexture.SelectedItem = this._paramTexture.Items[selection];
			}
		}

		// Token: 0x040002B1 RID: 689
		private readonly ParamSlotListViewModel _paramTexture;

		// Token: 0x040002B2 RID: 690
		private readonly ParamBool _paramConstraints;

		// Token: 0x040002B3 RID: 691
		private readonly ParamFloat _paramStrength;

		// Token: 0x040002B4 RID: 692
		private readonly ParamFloat _paramMinHeight;

		// Token: 0x040002B5 RID: 693
		private readonly ParamFloat _paramMaxHeight;

		// Token: 0x040002B6 RID: 694
		private readonly ParamFloat _paramHeightFuzziness;

		// Token: 0x040002B7 RID: 695
		private readonly ParamFloat _paramMinSlope;

		// Token: 0x040002B8 RID: 696
		private readonly ParamFloat _paramMaxSlope;
	}
}

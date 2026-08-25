using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using IGE.Nomad;
using IGE.Parameters;

namespace IGE.Tools
{
	// Token: 0x0200006E RID: 110
	internal class ToolCollection : ToolPaint
	{
		// Token: 0x06000489 RID: 1161 RVA: 0x00011BB8 File Offset: 0x0000FDB8
		public ToolCollection()
		{
			int slotCount = 8;
			bool enableChange = true;
			this._paramCollection = new ParamSlotListViewModel(Localizer.Localize("PARAM_COLLECTIONS", null), CollectionInventory.Instance.Root, slotCount, false, enableChange, true);
			base..ctor(Localizer.Localize("TOOL_COLLECTIONS", null), "toolbar/objects/Collection.png");
			this._paramCollection.SlotChanged += delegate(object s, EventArgs ea)
			{
				this.OnAssignSlot(ea);
			};
			this._paramCollection.ValueChanged += this.paramCollection_ValueChanged;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00011D58 File Offset: 0x0000FF58
		protected override IEnumerable<Parameter> GetParameters()
		{
			yield return this.m_square;
			yield return this.m_radius;
			yield return this._paramCollection;
			yield break;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x00011D75 File Offset: 0x0000FF75
		public override SingleParameter GetMainParameter()
		{
			return this._paramCollection;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x00011D80 File Offset: 0x0000FF80
		public override string GetContextHelp()
		{
			return string.Concat(new string[]
			{
				base.GetPaintContextHelp(),
				"\r\n",
				base.GetShortcutContextHelp(),
				"\r\n\r\n",
				Localizer.LocalizeCommon("HELP_TOOL_COLLECTION")
			});
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00011DCC File Offset: 0x0000FFCC
		private void OnAssignSlot(EventArgs ea)
		{
			ParamSlotListViewModel.EntryChangeEventArgs entryChangeEventArgs = (ParamSlotListViewModel.EntryChangeEventArgs)ea;
			bool flag = entryChangeEventArgs.Entry == null || !entryChangeEventArgs.Entry.IsValid;
			if (flag)
			{
				CollectionManager.ClearMaskId(entryChangeEventArgs.Id);
				CollectionManager.AssignCollectionId(entryChangeEventArgs.Id, CollectionInventory.Entry.Null);
			}
			else
			{
				CollectionManager.AssignCollectionId(entryChangeEventArgs.Id, (CollectionInventory.Entry)entryChangeEventArgs.Entry);
			}
			this.UpdateCollection(flag ? -1 : entryChangeEventArgs.Id);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00011E48 File Offset: 0x00010048
		private void paramCollection_ValueChanged(object sender, EventArgs e)
		{
			this.m_cursorEnabled = true;
			int value = this._paramCollection.Value;
			if (value == -1 || value == CollectionManager.EmptyCollectionId)
			{
				this.m_cursorEnabled = false;
			}
			CollectionInventory.Entry collectionEntryFromId = CollectionManager.GetCollectionEntryFromId(value);
			if (!collectionEntryFromId.IsValid)
			{
				this.m_cursorEnabled = false;
			}
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x00011E91 File Offset: 0x00010091
		public override void Activate()
		{
			base.Activate();
			this.UpdateCollection(-1);
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x00011EA0 File Offset: 0x000100A0
		protected override void OnPaint(float dt, Vec2 pos)
		{
			base.OnPaint(dt, pos);
			int num;
			if (!Keyboard.IsKeyDown(Key.LeftCtrl) && !Keyboard.IsKeyDown(Key.RightCtrl))
			{
				num = this._paramCollection.Value;
				if (num == -1)
				{
					return;
				}
				CollectionInventory.Entry collectionEntryFromId = CollectionManager.GetCollectionEntryFromId(num);
				if (!collectionEntryFromId.IsValid)
				{
					return;
				}
			}
			else
			{
				num = CollectionManager.EmptyCollectionId;
			}
			CollectionManipulator.Paint(pos, num, this.m_brush);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x00011EFB File Offset: 0x000100FB
		protected override void OnEndPaint()
		{
			base.OnEndPaint();
			CollectionManipulator.Paint_End();
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x00011F08 File Offset: 0x00010108
		private void UpdateCollection(int selection)
		{
			ObservableCollection<ParamSlotItemViewModel> observableCollection = new ObservableCollection<ParamSlotItemViewModel>();
			for (int i = 0; i < this._paramCollection.SlotCount; i++)
			{
				CollectionInventory.Entry collectionEntryFromId = CollectionManager.GetCollectionEntryFromId(i);
				if (collectionEntryFromId.IsValid)
				{
					observableCollection.Add(new ParamSlotItemViewModel(collectionEntryFromId, i));
				}
			}
			this._paramCollection.Items = observableCollection;
			this.m_cursorEnabled = (selection >= 0 && selection < this._paramCollection.Items.Count);
			if (this.m_cursorEnabled)
			{
				this._paramCollection.SelectedItem = this._paramCollection.Items[selection];
			}
		}

		// Token: 0x04000200 RID: 512
		private readonly ParamSlotListViewModel _paramCollection;
	}
}

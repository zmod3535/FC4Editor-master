using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace IGE.Nomad
{
	// Token: 0x02000049 RID: 73
	internal class WildernessInventory
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00009960 File Offset: 0x00007B60
		public static WildernessInventory Instance
		{
			get
			{
				return WildernessInventory._instance;
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00009968 File Offset: 0x00007B68
		public void Initialize()
		{
			NomadDbIdVector nomadDbIdVector = NomadDbIdVector.Create();
			if (!nomadDbIdVector.IsValid)
			{
				return;
			}
			Binding.FCE_GameMode_GetAllWildernessDbIds(nomadDbIdVector.Pointer);
			this.Entries = new Dictionary<ulong, WildernessInventory.Entry>();
			for (uint num = 0U; num < nomadDbIdVector.Count; num += 1U)
			{
				ulong at = nomadDbIdVector.GetAt(num);
				this.Entries[at] = new WildernessInventory.Entry
				{
					DbId = at,
					LocId = Binding.FCE_GameMode_WildernessNameId(at),
					ScriptFilename = Marshal.PtrToStringAnsi(Binding.FCE_GameMode_WildernessScriptPathId(at))
				};
			}
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000329 RID: 809 RVA: 0x00009A02 File Offset: 0x00007C02
		// (set) Token: 0x0600032A RID: 810 RVA: 0x00009A0A File Offset: 0x00007C0A
		public Dictionary<ulong, WildernessInventory.Entry> Entries { get; private set; }

		// Token: 0x0400014F RID: 335
		private static readonly WildernessInventory _instance = new WildernessInventory();

		// Token: 0x0200004A RID: 74
		public struct Entry
		{
			// Token: 0x0600032D RID: 813 RVA: 0x00009A27 File Offset: 0x00007C27
			public override string ToString()
			{
				return Localizer.LocalizeCommon(this.LocId);
			}

			// Token: 0x04000151 RID: 337
			public string ScriptFilename;

			// Token: 0x04000152 RID: 338
			public uint LocId;

			// Token: 0x04000153 RID: 339
			public ulong DbId;
		}
	}
}

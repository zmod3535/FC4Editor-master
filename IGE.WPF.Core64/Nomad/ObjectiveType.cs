using System;

namespace IGE.Nomad
{
	// Token: 0x0200001D RID: 29
	public class ObjectiveType
	{
		// Token: 0x060000CE RID: 206 RVA: 0x000031AD File Offset: 0x000013AD
		public ObjectiveType(ulong id, string name, string description)
		{
			this.Id = id;
			this.Name = name;
			this.Description = description;
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000CF RID: 207 RVA: 0x000031CA File Offset: 0x000013CA
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x000031D2 File Offset: 0x000013D2
		public GameMode GameMode { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x000031DB File Offset: 0x000013DB
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x000031E3 File Offset: 0x000013E3
		public ulong Id { get; private set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x000031EC File Offset: 0x000013EC
		public string FullName
		{
			get
			{
				return this.GameMode.Name + " - " + this.Name;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x00003209 File Offset: 0x00001409
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x00003211 File Offset: 0x00001411
		public string Name { get; private set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x0000321A File Offset: 0x0000141A
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00003222 File Offset: 0x00001422
		public string Description { get; private set; }
	}
}

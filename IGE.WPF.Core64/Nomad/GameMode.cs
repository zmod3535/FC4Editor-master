using System;
using System.Collections.Generic;

namespace IGE.Nomad
{
	// Token: 0x0200001C RID: 28
	public class GameMode
	{
		// Token: 0x060000C8 RID: 200 RVA: 0x00003166 File Offset: 0x00001366
		public GameMode(ulong dbId, string name, List<ObjectiveType> objectiveTypes)
		{
			this._id = dbId;
			this.Name = name;
			this.ObjectiveTypes = objectiveTypes;
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00003183 File Offset: 0x00001383
		public ulong Id
		{
			get
			{
				return this._id;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000CA RID: 202 RVA: 0x0000318B File Offset: 0x0000138B
		// (set) Token: 0x060000CB RID: 203 RVA: 0x00003193 File Offset: 0x00001393
		public string Name { get; private set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000CC RID: 204 RVA: 0x0000319C File Offset: 0x0000139C
		// (set) Token: 0x060000CD RID: 205 RVA: 0x000031A4 File Offset: 0x000013A4
		public List<ObjectiveType> ObjectiveTypes { get; private set; }

		// Token: 0x04000037 RID: 55
		private ulong _id;
	}
}

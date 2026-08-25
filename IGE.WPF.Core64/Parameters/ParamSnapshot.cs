using System;
using System.Windows.Media;
using IGE.Helpers;
using IGE.Nomad;
using Ubisoft.ApplicationModel.ContextCommands;

namespace IGE.Parameters
{
	// Token: 0x02000114 RID: 276
	internal class ParamSnapshot : SingleParameter
	{
		// Token: 0x06000998 RID: 2456 RVA: 0x000203B0 File Offset: 0x0001E5B0
		public ParamSnapshot() : base(Localizer.Localize("PARAM_SNAPSHOT", null))
		{
			SimpleCommand simpleCommand = new SimpleCommand();
			simpleCommand.ExecuteDelegate = delegate(object o)
			{
				this.RaiseSet();
			};
			this.CommandSet = simpleCommand;
			SimpleCommand simpleCommand2 = new SimpleCommand();
			simpleCommand2.ExecuteDelegate = delegate(object o)
			{
				this.RaiseGoto();
			};
			simpleCommand2.CanExecuteDelegate = ((object o) => this.HasSnapShot);
			this.CommandGoto = simpleCommand2;
			this.UpdateSnapshot();
		}

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x06000999 RID: 2457 RVA: 0x0002043D File Offset: 0x0001E63D
		// (set) Token: 0x0600099A RID: 2458 RVA: 0x00020445 File Offset: 0x0001E645
		public ImageSource SnapshotImage
		{
			get
			{
				return this._snapshotImage;
			}
			set
			{
				this._snapshotImage = value;
				base.RaisePropertyChanged("SnapshotImage");
			}
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0002045C File Offset: 0x0001E65C
		internal void UpdateSnapshot()
		{
			this.HasSnapShot = EditorDocument.IsSnapshotSet;
			ImageSource imageSource = Snapshot.GetImage();
			if (imageSource == null)
			{
				imageSource = "emptySnapshot.png".GetImageSource();
			}
			this.SnapshotImage = imageSource;
		}

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x0002048F File Offset: 0x0001E68F
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x00020497 File Offset: 0x0001E697
		public bool HasSnapShot { get; private set; }

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x000204A0 File Offset: 0x0001E6A0
		// (set) Token: 0x0600099F RID: 2463 RVA: 0x000204A8 File Offset: 0x0001E6A8
		public SimpleCommand CommandSet { get; set; }

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060009A0 RID: 2464 RVA: 0x000204B1 File Offset: 0x0001E6B1
		// (set) Token: 0x060009A1 RID: 2465 RVA: 0x000204B9 File Offset: 0x0001E6B9
		public SimpleCommand CommandGoto { get; set; }

		// Token: 0x060009A2 RID: 2466 RVA: 0x000204C2 File Offset: 0x0001E6C2
		private void RaiseSet()
		{
			EditorDocument.SnapshotPos = Camera.Position;
			EditorDocument.SnapshotAngle = Camera.Angles;
			EditorDocument.TakeSnapshot();
			this.UpdateSnapshot();
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x000204E3 File Offset: 0x0001E6E3
		private void RaiseGoto()
		{
			if (EditorDocument.IsSnapshotSet)
			{
				Camera.Position = EditorDocument.SnapshotPos;
				Camera.Angles = EditorDocument.SnapshotAngle;
			}
		}

		// Token: 0x040004A1 RID: 1185
		private ImageSource _snapshotImage;
	}
}

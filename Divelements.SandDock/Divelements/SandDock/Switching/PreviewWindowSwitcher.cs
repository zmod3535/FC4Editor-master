using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Divelements.SandDock.Switching
{
	// Token: 0x02000058 RID: 88
	public abstract class PreviewWindowSwitcher : WindowSwitcher
	{
		// Token: 0x06000454 RID: 1108 RVA: 0x00044B88 File Offset: 0x00042F88
		protected PreviewWindowSwitcher(DockSite dockSite) : base(dockSite)
		{
			this.x83ac54397dbba9fc = new Dictionary<DockableWindow, UIElement>();
			this.xcf146fdc1ccb529b = new DispatcherTimer(DispatcherPriority.Background);
			this.xcf146fdc1ccb529b.Interval = TimeSpan.FromMilliseconds(250.0);
			this.xcf146fdc1ccb529b.Tick += this.x0ba2690442684636;
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x00044BE4 File Offset: 0x00042FE4
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x00044BEC File Offset: 0x00042FEC
		public PreviewWindowLoadMode PreviewLoadMode
		{
			get
			{
				return this.x18834b0301a09365;
			}
			set
			{
				this.x18834b0301a09365 = value;
			}
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x00044BF8 File Offset: 0x00042FF8
		private void x0ba2690442684636(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
		{
			bool flag = false;
			int num = 0;
			int num2 = 1;
			for (int i = 0; i < this.x7799d9ebf5587fb9.Length; i++)
			{
				int num3 = i;
				if (!this.x7799d9ebf5587fb9[num3].HasSwappedContent && this.x7799d9ebf5587fb9[num3].PreviewType == WindowPreviewType.TemporarySwap)
				{
					this.xe1faf1e1fbab3e70(this.x7799d9ebf5587fb9[num3]);
					flag = true;
					num++;
					if (num == num2)
					{
						break;
					}
				}
			}
			if (!flag)
			{
				this.xcf146fdc1ccb529b.Stop();
			}
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x00044C6C File Offset: 0x0004306C
		private void xe1faf1e1fbab3e70(WindowPreview xaa4b3160a90957ee)
		{
			if (this.x83ac54397dbba9fc[xaa4b3160a90957ee.Window] == null)
			{
				xaa4b3160a90957ee.SetSwappedContent(new Rectangle());
				return;
			}
			UIElement swappedContent = this.x83ac54397dbba9fc[xaa4b3160a90957ee.Window];
			xaa4b3160a90957ee.Window.Child = null;
			xaa4b3160a90957ee.SetSwappedContent(swappedContent);
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x00044CC0 File Offset: 0x000430C0
		protected sealed override void OnStarted()
		{
			if (base.DockSite.DocumentContainer == null)
			{
				base.Stop();
				return;
			}
			DockableWindow[] array = PreviewWindowSwitcher.DocumentsOnly ? base.DocumentWindows : base.AllWindows;
			if (array.Length < 2)
			{
				base.Stop();
				return;
			}
			this.x7799d9ebf5587fb9 = new WindowPreview[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.x83ac54397dbba9fc[array[i]] = array[i].Child;
				this.x7799d9ebf5587fb9[i] = new WindowPreview(array[i]);
			}
			DateTime[] array2 = new DateTime[this.x7799d9ebf5587fb9.Length];
			int j;
			for (j = 0; j < this.x7799d9ebf5587fb9.Length; j++)
			{
				array2[j] = this.x7799d9ebf5587fb9[j].Window.MetaData.LastFocused;
			}
			Array.Sort<DateTime, WindowPreview>(array2, this.x7799d9ebf5587fb9);
			if (this.PreviewLoadMode == PreviewWindowLoadMode.Delayed)
			{
				this.xcf146fdc1ccb529b.Start();
				if ((uint)j + (uint)j >= 0U)
				{
				}
			}
			else
			{
				foreach (WindowPreview windowPreview in this.WindowPreviews)
				{
					if (windowPreview.PreviewType == WindowPreviewType.TemporarySwap)
					{
						this.xe1faf1e1fbab3e70(windowPreview);
					}
				}
			}
			base.DockSite.DocumentContainer.Visibility = Visibility.Hidden;
			this.OnStartedPreviewing();
		}

		// Token: 0x0600045A RID: 1114
		protected abstract void OnStartedPreviewing();

		// Token: 0x0600045B RID: 1115 RVA: 0x00044E20 File Offset: 0x00043220
		protected sealed override void OnStopped()
		{
			this.xcf146fdc1ccb529b.Stop();
			foreach (WindowPreview windowPreview in this.x7799d9ebf5587fb9)
			{
				if (windowPreview.HasSwappedContent)
				{
					windowPreview.SetSwappedContent(null);
				}
			}
			this.x7799d9ebf5587fb9 = null;
			foreach (KeyValuePair<DockableWindow, UIElement> keyValuePair in this.x83ac54397dbba9fc)
			{
				if (keyValuePair.Key.Child != keyValuePair.Value)
				{
					keyValuePair.Key.Child = keyValuePair.Value;
				}
			}
			this.x83ac54397dbba9fc.Clear();
			base.DockSite.DocumentContainer.Visibility = Visibility.Visible;
			this.OnStoppedPreviewing();
		}

		// Token: 0x0600045C RID: 1116
		protected abstract void OnStoppedPreviewing();

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x00044F00 File Offset: 0x00043300
		public WindowPreview[] WindowPreviews
		{
			get
			{
				return this.x7799d9ebf5587fb9;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600045E RID: 1118 RVA: 0x00044F08 File Offset: 0x00043308
		// (set) Token: 0x0600045F RID: 1119 RVA: 0x00044F10 File Offset: 0x00043310
		public static bool DocumentsOnly
		{
			get
			{
				return PreviewWindowSwitcher.xc2b6f6b31799c837;
			}
			set
			{
				PreviewWindowSwitcher.xc2b6f6b31799c837 = value;
			}
		}

		// Token: 0x040001CE RID: 462
		private static bool xc2b6f6b31799c837 = true;

		// Token: 0x040001CF RID: 463
		private Dictionary<DockableWindow, UIElement> x83ac54397dbba9fc;

		// Token: 0x040001D0 RID: 464
		private DispatcherTimer xcf146fdc1ccb529b;

		// Token: 0x040001D1 RID: 465
		private WindowPreview[] x7799d9ebf5587fb9;

		// Token: 0x040001D2 RID: 466
		private PreviewWindowLoadMode x18834b0301a09365;
	}
}

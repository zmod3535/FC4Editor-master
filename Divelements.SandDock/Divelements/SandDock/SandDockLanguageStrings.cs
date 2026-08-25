using System;
using System.ComponentModel;
using System.Threading;

namespace Divelements.SandDock
{
	// Token: 0x02000052 RID: 82
	public sealed class SandDockLanguageStrings : INotifyPropertyChanged
	{
		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060003FE RID: 1022 RVA: 0x000428FC File Offset: 0x00040CFC
		// (remove) Token: 0x060003FF RID: 1023 RVA: 0x00042934 File Offset: 0x00040D34
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.x0ad6cb77c00e4e89;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.x0ad6cb77c00e4e89, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.x0ad6cb77c00e4e89;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.x0ad6cb77c00e4e89, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x000429AC File Offset: 0x00040DAC
		private void x255a9125fad2d9bb(PropertyChangedEventArgs xfbf34718e704c6bc)
		{
			if (this.x0ad6cb77c00e4e89 != null)
			{
				this.x0ad6cb77c00e4e89(this, xfbf34718e704c6bc);
			}
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000402 RID: 1026 RVA: 0x000429C4 File Offset: 0x00040DC4
		// (set) Token: 0x06000403 RID: 1027 RVA: 0x000429CC File Offset: 0x00040DCC
		public string WindowOptions
		{
			get
			{
				return this.x2908b439c5ffa349;
			}
			set
			{
				this.x2908b439c5ffa349 = value;
				this.x255a9125fad2d9bb(new PropertyChangedEventArgs("WindowOptions"));
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x000429E8 File Offset: 0x00040DE8
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x000429F0 File Offset: 0x00040DF0
		public string AutoHide
		{
			get
			{
				return this.xe2ea1c1fa25bb57d;
			}
			set
			{
				this.xe2ea1c1fa25bb57d = value;
				this.x255a9125fad2d9bb(new PropertyChangedEventArgs("AutoHide"));
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x00042A0C File Offset: 0x00040E0C
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x00042A14 File Offset: 0x00040E14
		public string Close
		{
			get
			{
				return this.xeb1688f3c25edfc6;
			}
			set
			{
				this.xeb1688f3c25edfc6 = value;
				this.x255a9125fad2d9bb(new PropertyChangedEventArgs("Close"));
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x00042A30 File Offset: 0x00040E30
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x00042A38 File Offset: 0x00040E38
		public string ActiveToolWindows
		{
			get
			{
				return this.x5e2dfcc99bf912ce;
			}
			set
			{
				this.x5e2dfcc99bf912ce = value;
				this.x255a9125fad2d9bb(new PropertyChangedEventArgs("ActiveToolWindows"));
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x00042A54 File Offset: 0x00040E54
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x00042A5C File Offset: 0x00040E5C
		public string ActiveFiles
		{
			get
			{
				return this.x6462941db2c8e593;
			}
			set
			{
				this.x6462941db2c8e593 = value;
				this.x255a9125fad2d9bb(new PropertyChangedEventArgs("ActiveFiles"));
			}
		}

		// Token: 0x040001B7 RID: 439
		private string x5e2dfcc99bf912ce = "Active Tool Windows";

		// Token: 0x040001B8 RID: 440
		private string x6462941db2c8e593 = "Active Files";

		// Token: 0x040001B9 RID: 441
		private string xeb1688f3c25edfc6 = "Close";

		// Token: 0x040001BA RID: 442
		private string xe2ea1c1fa25bb57d = "Auto Hide";

		// Token: 0x040001BB RID: 443
		private string x2908b439c5ffa349 = "Window Options";

		// Token: 0x040001BC RID: 444
		private PropertyChangedEventHandler x0ad6cb77c00e4e89;
	}
}

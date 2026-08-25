using System;
using System.Windows;

namespace Divelements.SandDock.Rendering
{
	// Token: 0x02000073 RID: 115
	public class ThemeDictionaryManager : ResourceDictionary
	{
		// Token: 0x060004BB RID: 1211 RVA: 0x000478B0 File Offset: 0x00045CB0
		public ThemeDictionaryManager()
		{
			x17a4a3c1cfdeaf47.x9834ddb0e0bd5996.xa354c277cf832fca(this);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000478C4 File Offset: 0x00045CC4
		internal void Populate()
		{
			base.MergedDictionaries.Clear();
			if (!false)
			{
				switch (x17a4a3c1cfdeaf47.x9834ddb0e0bd5996.x3dabda6865ed239d)
				{
				case StandardTheme.VisualStudio2005:
					switch (this.Type)
					{
					case ThemeDictionaryType.Generic:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Whidbey/Theme.xaml"));
						return;
					case ThemeDictionaryType.LunaBlue:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Whidbey/LunaBlue.xaml"));
						return;
					case ThemeDictionaryType.LunaSilver:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Whidbey/LunaSilver.xaml"));
						return;
					case ThemeDictionaryType.LunaOlive:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Whidbey/LunaOlive.xaml"));
						return;
					case ThemeDictionaryType.Aero:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Whidbey/Aero.xaml"));
						return;
					default:
						return;
					}
					break;
				case StandardTheme.VisualStudio2008:
					switch (this.Type)
					{
					case ThemeDictionaryType.Generic:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Orcas/Theme.xaml"));
						return;
					case ThemeDictionaryType.LunaBlue:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Orcas/LunaBlue.xaml"));
						return;
					case ThemeDictionaryType.LunaSilver:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Orcas/LunaSilver.xaml"));
						return;
					case ThemeDictionaryType.LunaOlive:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Orcas/LunaOlive.xaml"));
						if (-2 != 0)
						{
							return;
						}
						break;
					case ThemeDictionaryType.Aero:
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Orcas/Aero.xaml"));
						return;
					default:
						return;
					}
					break;
				case StandardTheme.Office2007:
					for (;;)
					{
						ThemeDictionaryType themeDictionaryType = this.Type;
						if (themeDictionaryType != ThemeDictionaryType.Generic)
						{
							break;
						}
						base.MergedDictionaries.Add(this.CreateResourceDictionary("/Divelements.SandDock;component/Rendering/Office2007/Theme.xaml"));
						if (!false)
						{
							goto Block_2;
						}
					}
					return;
					Block_2:
					break;
				default:
					return;
				}
				return;
			}
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00047A60 File Offset: 0x00045E60
		private ResourceDictionary CreateResourceDictionary(string uri)
		{
			return new ResourceDictionary
			{
				Source = new Uri(uri, UriKind.Relative)
			};
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060004BE RID: 1214 RVA: 0x00047A84 File Offset: 0x00045E84
		// (set) Token: 0x060004BF RID: 1215 RVA: 0x00047A8C File Offset: 0x00045E8C
		public ThemeDictionaryType Type
		{
			get
			{
				return this.type;
			}
			set
			{
				if (value != this.type)
				{
					this.type = value;
					this.Populate();
				}
			}
		}

		// Token: 0x0400028C RID: 652
		private ThemeDictionaryType type;
	}
}

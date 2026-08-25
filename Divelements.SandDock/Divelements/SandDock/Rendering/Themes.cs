using System;
using System.Windows;
using System.Windows.Interop;
using Divelements.SandDock.Rendering.Office2007;

namespace Divelements.SandDock.Rendering
{
	// Token: 0x02000074 RID: 116
	public static class Themes
	{
		// Token: 0x060004C1 RID: 1217 RVA: 0x00047AD8 File Offset: 0x00045ED8
		public static void ClearThemes()
		{
			for (int i = Application.Current.Resources.MergedDictionaries.Count - 1; i >= 0; i--)
			{
				if (Application.Current.Resources.MergedDictionaries[i].Source != null && Application.Current.Resources.MergedDictionaries[i].Source.ToString().IndexOf("SandDock") != -1)
				{
					Application.Current.Resources.MergedDictionaries.RemoveAt(i);
				}
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00047B6C File Offset: 0x00045F6C
		public static void SetOffice2007Theme(Office2007ColorScheme colorScheme)
		{
			Themes.ClearThemes();
			bool isBrowserHosted = BrowserInteropHelper.IsBrowserHosted;
			ResourceDictionary resourceDictionary = new ResourceDictionary();
			resourceDictionary.Source = new Uri("/Divelements.SandDock;component/Rendering/Office2007/Theme.xaml", UriKind.Relative);
			Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
			resourceDictionary = null;
			switch (colorScheme)
			{
			case Office2007ColorScheme.Silver:
				resourceDictionary = new ResourceDictionary();
				resourceDictionary.Source = new Uri("/Divelements.SandDock;component/Rendering/Office2007/Silver.xaml", UriKind.Relative);
				break;
			case Office2007ColorScheme.Black:
				resourceDictionary = new ResourceDictionary();
				resourceDictionary.Source = new Uri("/Divelements.SandDock;component/Rendering/Office2007/Black.xaml", UriKind.Relative);
				break;
			}
			if (resourceDictionary != null)
			{
				Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
			}
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00047C10 File Offset: 0x00046010
		public static void SetVisualStudio2005Theme()
		{
			x17a4a3c1cfdeaf47.x9834ddb0e0bd5996.x3dabda6865ed239d = StandardTheme.VisualStudio2005;
			Themes.ClearThemes();
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00047C24 File Offset: 0x00046024
		public static void SetVisualStudio2008Theme()
		{
			x17a4a3c1cfdeaf47.x9834ddb0e0bd5996.x3dabda6865ed239d = StandardTheme.VisualStudio2008;
			Themes.ClearThemes();
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00047C38 File Offset: 0x00046038
		[AttachedPropertyBrowsableForChildren]
		public static bool GetIsHighContrast(UIElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return (bool)element.GetValue(Themes.IsHighContrastProperty);
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00047C58 File Offset: 0x00046058
		public static void SetIsHighContrast(UIElement element, bool value)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			element.SetValue(Themes.IsHighContrastProperty, value);
		}

		// Token: 0x0400028D RID: 653
		public static readonly DependencyProperty IsHighContrastProperty = DependencyProperty.RegisterAttached("IsHighContrast", typeof(bool), typeof(Themes), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
	}
}

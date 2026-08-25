using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace IGE.Helpers
{
	// Token: 0x020000A2 RID: 162
	public static class Extentions
	{
		// Token: 0x060006A8 RID: 1704 RVA: 0x00018304 File Offset: 0x00016504
		public static Image GetImage(this string filename)
		{
			ImageSource imageSource = filename.GetImageSource();
			if (imageSource == null)
			{
				return null;
			}
			return new Image
			{
				Source = imageSource,
				Stretch = Stretch.None
			};
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00018332 File Offset: 0x00016532
		public static ImageSource GetImageSource(this string filename)
		{
			if (!Extentions.ResourceExists("img/" + filename))
			{
				return null;
			}
			return new ImageSourceConverter().ConvertFrom("pack://application:,,,/" + Program.AssemblyName + ";component/img/" + filename) as ImageSource;
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x0001836C File Offset: 0x0001656C
		public static bool ResourceExists(string resourcePath)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			return Extentions.ResourceExists(executingAssembly, resourcePath.ToLower());
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x0001838B File Offset: 0x0001658B
		public static bool ResourceExists(Assembly assembly, string resourcePath)
		{
			return Extentions.GetResourcePaths(assembly).Contains(resourcePath);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00018608 File Offset: 0x00016808
		public static IEnumerable<object> GetResourcePaths(Assembly assembly)
		{
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;
			string resourceName = assembly.GetName().Name + ".g";
			ResourceManager resourceManager = new ResourceManager(resourceName, assembly);
			try
			{
				ResourceSet resourceSet = resourceManager.GetResourceSet(culture, true, true);
				foreach (object obj in resourceSet)
				{
					DictionaryEntry resource = (DictionaryEntry)obj;
					DictionaryEntry dictionaryEntry = resource;
					yield return dictionaryEntry.Key.ToString().ToLower();
				}
			}
			finally
			{
				resourceManager.ReleaseAllResources();
			}
			yield break;
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00018628 File Offset: 0x00016828
		public static char ToChar(this Key key)
		{
			int uCode = KeyInterop.VirtualKeyFromKey(key);
			return Convert.ToChar(Win32.MapVirtualKey(uCode, 2));
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00018648 File Offset: 0x00016848
		public static string ToTooltipString(this Key key)
		{
			if (key >= Key.Oem1)
			{
				return new string(key.ToChar(), 1);
			}
			return Extentions.keyConverter.ConvertToString(key);
		}

		// Token: 0x040002A9 RID: 681
		private static KeyConverter keyConverter = new KeyConverter();
	}
}

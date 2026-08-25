using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Xml;

namespace TD.SandDock
{
	// Token: 0x0200005C RID: 92
	internal class x245a5abec1c73d3a
	{
		// Token: 0x06000523 RID: 1315 RVA: 0x0002725C File Offset: 0x0002625C
		internal static void x0a680eda7ec8bd81(SandDockManager x91f347c6e97f1846, XmlNode x8a5ce9fbef4b9a09)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(long));
			for (;;)
			{
				if (!false)
				{
					goto IL_427;
				}
				goto IL_1B3;
				DockControl dockControl;
				TypeConverter converter2;
				TypeConverter converter3;
				ContainerDockLocation containerDockLocation;
				for (;;)
				{
					IL_258:
					dockControl.FloatingLocation = (Point)converter2.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["FloatingLocation"].Value);
					dockControl.FloatingSize = (Size)converter3.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["FloatingSize"].Value);
					if (x8a5ce9fbef4b9a09.Attributes["LastOpenDockSituation"] != null)
					{
						dockControl.MetaData.xb0e0bc77d88737a8((DockSituation)Enum.Parse(typeof(DockSituation), x8a5ce9fbef4b9a09.Attributes["LastOpenDockSituation"].Value));
						goto IL_235;
					}
					IL_20B:
					if (x8a5ce9fbef4b9a09.Attributes["LastFixedDockSituation"] != null)
					{
						dockControl.MetaData.x0ba17c4cff658fcf((DockSituation)Enum.Parse(typeof(DockSituation), x8a5ce9fbef4b9a09.Attributes["LastFixedDockSituation"].Value));
						goto IL_112;
					}
					if (15 != 0)
					{
						goto IL_112;
					}
					IL_183:
					containerDockLocation = (ContainerDockLocation)Enum.Parse(typeof(ContainerDockLocation), x8a5ce9fbef4b9a09.Attributes["LastFixedDockLocation"].Value);
					if (!Enum.IsDefined(typeof(ContainerDockLocation), containerDockLocation))
					{
						goto IL_1B0;
					}
					if (2 != 0)
					{
						goto IL_169;
					}
					if (false)
					{
						if (false)
						{
							goto IL_235;
						}
						continue;
					}
					IL_112:
					if (x8a5ce9fbef4b9a09.Attributes["LastFixedDockLocation"] == null)
					{
						break;
					}
					goto IL_183;
					IL_235:
					if (-2 != 0)
					{
						goto IL_20B;
					}
					goto IL_427;
				}
				if (false || !true)
				{
					goto IL_12E;
				}
				goto IL_EC;
				IL_1B0:
				containerDockLocation = ContainerDockLocation.Right;
				goto IL_1B3;
				IL_427:
				TypeConverter converter4 = TypeDescriptor.GetConverter(typeof(int));
				converter3 = TypeDescriptor.GetConverter(typeof(Size));
				converter2 = TypeDescriptor.GetConverter(typeof(Point));
				if (-1 != 0)
				{
					dockControl = x91f347c6e97f1846.FindControl(new Guid(x8a5ce9fbef4b9a09.Attributes["Guid"].Value));
					if (dockControl == null)
					{
						return;
					}
				}
				if (x8a5ce9fbef4b9a09.Attributes["LastFocused"] != null)
				{
					dockControl.MetaData.x15481da58c59597a(DateTime.FromFileTime((long)converter.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["LastFocused"].Value)));
					if (-2 == 0)
					{
						goto IL_258;
					}
					if (false)
					{
						continue;
					}
				}
				IL_2FD:
				if (x8a5ce9fbef4b9a09.Attributes["DockedSize"] != null)
				{
					dockControl.MetaData.x3ef4455ea4965093((int)converter4.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["DockedSize"].Value));
				}
				while (x8a5ce9fbef4b9a09.Attributes["PopupSize"] != null)
				{
					dockControl.PopupSize = (int)converter4.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["PopupSize"].Value);
					if (!false)
					{
						break;
					}
				}
				goto IL_258;
				IL_353:
				goto IL_2FD;
				IL_FE:
				if (x8a5ce9fbef4b9a09.Attributes["LastDockContainerCount"] != null)
				{
					dockControl.MetaData.xe62a3d24e0fde928.xd25c313925dc7d4e = (int)converter4.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["LastDockContainerCount"].Value);
				}
				if (x8a5ce9fbef4b9a09.Attributes["LastDockContainerIndex"] != null)
				{
					dockControl.MetaData.xe62a3d24e0fde928.x71a5d248534c8557 = (int)converter4.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["LastDockContainerIndex"].Value);
				}
				x245a5abec1c73d3a.xac29055e1acf1a28(dockControl, x8a5ce9fbef4b9a09, dockControl.MetaData.xe62a3d24e0fde928, "Docked");
				x245a5abec1c73d3a.xac29055e1acf1a28(dockControl, x8a5ce9fbef4b9a09, dockControl.MetaData.x25e1dbd0e63329bf, "Document");
				x245a5abec1c73d3a.xac29055e1acf1a28(dockControl, x8a5ce9fbef4b9a09, dockControl.MetaData.xba74b873ae2f845a, "Floating");
				if (false)
				{
					goto IL_353;
				}
				break;
				IL_EC:
				if (x8a5ce9fbef4b9a09.Attributes["LastFloatingWindowGuid"] == null)
				{
					goto IL_FE;
				}
				IL_12E:
				dockControl.MetaData.x87f4a9b62a380563(new Guid(x8a5ce9fbef4b9a09.Attributes["LastFloatingWindowGuid"].Value));
				goto IL_FE;
				IL_169:
				dockControl.MetaData.xfca44c52f41f0e26(containerDockLocation);
				goto IL_EC;
				IL_1B3:
				goto IL_169;
			}
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x000276D4 File Offset: 0x000266D4
		private static void xac29055e1acf1a28(DockControl x76b3d9d2638e5ecd, XmlNode xeaa9dbf1fba9aca8, x129cb2a2bdfd0ab2 x592a8acce305e2d8, string x05bcae9c376a7a50)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			for (;;)
			{
				IL_148:
				do
				{
					if (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WorkingSize"] == null)
					{
						if (!false)
						{
							break;
						}
					}
					else
					{
						x592a8acce305e2d8.x3a4e0c379519d4a2 = SandDockManager.ConvertStringToSizeF(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WorkingSize"].Value);
						if (255 == 0)
						{
							continue;
						}
					}
				}
				while (false);
				IL_9C:
				if (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WindowGroupGuid"] == null)
				{
					if (3 == 0)
					{
						goto IL_E4;
					}
				}
				else
				{
					x592a8acce305e2d8.x703937d70a13725c = new Guid(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WindowGroupGuid"].Value);
				}
				IL_BB:
				if (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "IndexInWindowGroup"] != null)
				{
					x592a8acce305e2d8.x8c8f170696764fac = (int)converter.ConvertFromString(null, CultureInfo.InvariantCulture, xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "IndexInWindowGroup"].Value);
				}
				while (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "SplitPath"] != null)
				{
					if (true)
					{
						if (false)
						{
							goto IL_9A;
						}
						if (2 != 0)
						{
							x592a8acce305e2d8.x61743036ad30763d = x245a5abec1c73d3a.xad77aeacfb4bb694(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "SplitPath"].Value);
							if (false)
							{
								goto IL_9A;
							}
						}
						if (-1 == 0)
						{
							goto IL_148;
						}
						break;
					}
				}
				break;
				IL_9A:
				goto IL_BB;
				IL_E4:
				goto IL_9C;
				goto IL_E4;
			}
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x00027854 File Offset: 0x00026854
		private static int[] xad77aeacfb4bb694(string xc077f627453a9374)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			string[] array;
			int i;
			if (2147483647 != 0)
			{
				array = xc077f627453a9374.Split(new char[]
				{
					'|'
				});
				if ((uint)i < 0U)
				{
					goto IL_22;
				}
			}
			int[] array2 = new int[array.Length];
			i = 0;
			IL_22:
			while (i < array.Length)
			{
				array2[i] = (int)converter.ConvertFromString(null, CultureInfo.InvariantCulture, array[i]);
				i++;
			}
			return array2;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x000278D4 File Offset: 0x000268D4
		internal static void x4229d31a884b2577(DockControl x76b3d9d2638e5ecd, XmlTextWriter xbdfb620b7167944b)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(long));
			TypeConverter converter2;
			TypeConverter converter3;
			TypeConverter converter4;
			if (!false)
			{
				converter2 = TypeDescriptor.GetConverter(typeof(int));
				converter3 = TypeDescriptor.GetConverter(typeof(Size));
				converter4 = TypeDescriptor.GetConverter(typeof(Point));
				do
				{
					xbdfb620b7167944b.WriteStartElement("Window");
					xbdfb620b7167944b.WriteAttributeString("Guid", x76b3d9d2638e5ecd.Guid.ToString());
					xbdfb620b7167944b.WriteAttributeString("LastFocused", converter.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.MetaData.LastFocused.ToFileTime()));
					xbdfb620b7167944b.WriteAttributeString("DockedSize", converter2.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.MetaData.DockedContentSize));
					xbdfb620b7167944b.WriteAttributeString("PopupSize", converter2.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.PopupSize));
				}
				while (false);
			}
			for (;;)
			{
				xbdfb620b7167944b.WriteAttributeString("FloatingLocation", converter4.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.FloatingLocation));
				if (15 != 0)
				{
					goto IL_F3;
				}
				IL_AA:
				xbdfb620b7167944b.WriteAttributeString("LastDockContainerIndex", converter2.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928.x71a5d248534c8557));
				x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928, "Docked");
				if (!false)
				{
					x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.x25e1dbd0e63329bf, "Document");
					x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.xba74b873ae2f845a, "Floating");
					xbdfb620b7167944b.WriteEndElement();
					if (false)
					{
						continue;
					}
					break;
				}
				IL_F3:
				xbdfb620b7167944b.WriteAttributeString("FloatingSize", converter3.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.FloatingSize));
				xbdfb620b7167944b.WriteAttributeString("LastOpenDockSituation", x76b3d9d2638e5ecd.MetaData.LastOpenDockSituation.ToString());
				xbdfb620b7167944b.WriteAttributeString("LastFixedDockSituation", x76b3d9d2638e5ecd.MetaData.LastFixedDockSituation.ToString());
				if (4 != 0)
				{
					xbdfb620b7167944b.WriteAttributeString("LastFixedDockLocation", x76b3d9d2638e5ecd.MetaData.LastFixedDockSide.ToString());
				}
				xbdfb620b7167944b.WriteAttributeString("LastFloatingWindowGuid", x76b3d9d2638e5ecd.MetaData.LastFloatingWindowGuid.ToString());
				xbdfb620b7167944b.WriteAttributeString("LastDockContainerCount", converter2.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928.xd25c313925dc7d4e));
				goto IL_AA;
			}
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00027B90 File Offset: 0x00026B90
		private static void x47161f81513f1258(DockControl x76b3d9d2638e5ecd, XmlTextWriter xbdfb620b7167944b, x129cb2a2bdfd0ab2 x592a8acce305e2d8, string x05bcae9c376a7a50)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "WorkingSize", SandDockManager.ConvertSizeFToString(x592a8acce305e2d8.x3a4e0c379519d4a2));
			xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "WindowGroupGuid", x592a8acce305e2d8.x703937d70a13725c.ToString());
			xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "IndexInWindowGroup", converter.ConvertToString(null, CultureInfo.InvariantCulture, x592a8acce305e2d8.x8c8f170696764fac));
			xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "SplitPath", x245a5abec1c73d3a.x8c8bb4495a487cc5(x592a8acce305e2d8.x61743036ad30763d));
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00027C34 File Offset: 0x00026C34
		private static string x8c8bb4495a487cc5(int[] x6a80d3cc98596663)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			string[] array = new string[x6a80d3cc98596663.Length];
			int i = 0;
			while (i < x6a80d3cc98596663.Length)
			{
				array[i] = converter.ConvertToString(null, CultureInfo.InvariantCulture, x6a80d3cc98596663[i]);
				do
				{
					i++;
				}
				while ((uint)i < 0U);
			}
			return string.Join("|", array);
		}
	}
}

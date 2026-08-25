using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Xml;
using Divelements.SandDock.Primitives;

namespace Divelements.SandDock
{
	// Token: 0x02000054 RID: 84
	internal static class x245a5abec1c73d3a
	{
		// Token: 0x06000411 RID: 1041 RVA: 0x00042AF4 File Offset: 0x00040EF4
		public static void x175546c57b76906a(DockSite x7f72cb59f44fe44c, string x2612f62f94df47de)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(bool));
			for (;;)
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(x2612f62f94df47de);
				XmlNode xmlNode = xmlDocument.SelectSingleNode("SandDockLayout");
				if (xmlNode == null)
				{
					break;
				}
				bool flag = (bool)converter.ConvertFromString(null, CultureInfo.InvariantCulture, xmlNode.Attributes["IncludeDocuments"].Value);
				x245a5abec1c73d3a.x66c2033a1a9de673(x7f72cb59f44fe44c, flag);
				foreach (DockableWindow dockableWindow in x7f72cb59f44fe44c.GetAllWindows())
				{
					if (dockableWindow.Parent != null && (flag || dockableWindow.DockSituation != DockSituation.Document))
					{
						goto IL_214;
					}
				}
				xd679d9fc970c8f10.xd36c48a77e7b0108 = true;
				try
				{
					foreach (object obj in xmlNode.SelectNodes("Window"))
					{
						XmlNode x8a5ce9fbef4b9a = (XmlNode)obj;
						x245a5abec1c73d3a.x0a680eda7ec8bd81(x7f72cb59f44fe44c, x8a5ce9fbef4b9a);
					}
					foreach (object obj2 in xmlNode.SelectNodes("DockedSplitContainer"))
					{
						XmlNode xda5bf54deb817e = (XmlNode)obj2;
						SplitContainer splitContainer = x245a5abec1c73d3a.xd04c36c37a8f99ab(x7f72cb59f44fe44c, xda5bf54deb817e);
						x7f72cb59f44fe44c.SplitContainers.Add(splitContainer);
					}
					foreach (WindowGroup windowGroup in x245a5abec1c73d3a.xcc464d673988ae9f)
					{
						windowGroup.Pinned = false;
					}
					x245a5abec1c73d3a.xcc464d673988ae9f.Clear();
					x245a5abec1c73d3a.x33e6978bca2ab42c(x7f72cb59f44fe44c, xmlNode);
					if (flag && x7f72cb59f44fe44c.DocumentContainer != null)
					{
						XmlNode xmlNode2 = xmlNode.SelectSingleNode("DocumentSplitContainer");
						SplitContainer splitContainer2 = x7f72cb59f44fe44c.DocumentContainer.Content as SplitContainer;
						if (splitContainer2 != null && xmlNode2 != null)
						{
							x245a5abec1c73d3a.x78ff24b8edaa847d(x7f72cb59f44fe44c, splitContainer2, xmlNode2);
						}
					}
				}
				finally
				{
					xd679d9fc970c8f10.xd36c48a77e7b0108 = false;
				}
				foreach (DockableWindow dockableWindow2 in x7f72cb59f44fe44c.GetAllWindows())
				{
					dockableWindow2.OnDockSituationChanged(EventArgs.Empty);
				}
				if (-1 != 0)
				{
					return;
				}
			}
			return;
			IL_214:
			throw new InvalidOperationException();
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00042D9C File Offset: 0x0004119C
		private static void x33e6978bca2ab42c(DockSite x7f72cb59f44fe44c, XmlNode xff3bcf24bc2dff3f)
		{
			foreach (object obj in xff3bcf24bc2dff3f.SelectNodes("FloatingWindow"))
			{
				XmlNode xda5bf54deb817e = (XmlNode)obj;
				FloatingWindowAdapter floatingWindowAdapter = x245a5abec1c73d3a.xf52ad05830f9e775(x7f72cb59f44fe44c, xda5bf54deb817e);
				if (xd679d9fc970c8f10.x19fa3ae70a75ea3c(floatingWindowAdapter.RootContainer).Length != 0)
				{
					floatingWindowAdapter.Open();
				}
			}
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x00042E1C File Offset: 0x0004121C
		private static void x78ff24b8edaa847d(DockSite x7f72cb59f44fe44c, SplitContainer x32a48f2091f0f2d3, XmlNode xda5bf54deb817e37)
		{
			x245a5abec1c73d3a.x777159d109746247(x7f72cb59f44fe44c, x32a48f2091f0f2d3, xda5bf54deb817e37);
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x00042E28 File Offset: 0x00041228
		private static FloatingWindowAdapter xf52ad05830f9e775(DockSite x7f72cb59f44fe44c, XmlNode xda5bf54deb817e37)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(Point));
			Guid guid = new Guid(xda5bf54deb817e37.Attributes["Guid"].Value);
			FloatingWindowAdapter floatingWindowAdapter = x7f72cb59f44fe44c.CreateFloatingWindow(guid);
			floatingWindowAdapter.FloatingLocation = (Point)converter2.ConvertFromString(null, CultureInfo.InvariantCulture, xda5bf54deb817e37.Attributes["Location"].Value);
			floatingWindowAdapter.FloatingSize = new Size(0.0, 0.0)
			{
				Width = (double)converter.ConvertFromString(null, CultureInfo.InvariantCulture, xda5bf54deb817e37.Attributes["Width"].Value),
				Height = (double)converter.ConvertFromString(null, CultureInfo.InvariantCulture, xda5bf54deb817e37.Attributes["Height"].Value)
			};
			x245a5abec1c73d3a.x777159d109746247(x7f72cb59f44fe44c, floatingWindowAdapter.RootContainer, xda5bf54deb817e37);
			return floatingWindowAdapter;
		}

		// Token: 0x06000415 RID: 1045 RVA: 0x00042F30 File Offset: 0x00041330
		private static WindowGroup x399868a2610dcb1f(DockSite x7f72cb59f44fe44c, XmlNode xda5bf54deb817e37)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(bool));
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(Size));
			WindowGroup windowGroup = new WindowGroup();
			SplitContainer.SetWorkingSize(windowGroup, (Size)converter2.ConvertFromString(null, CultureInfo.InvariantCulture, xda5bf54deb817e37.Attributes["WorkingSize"].Value));
			if (!(bool)converter.ConvertFromString(null, CultureInfo.InvariantCulture, xda5bf54deb817e37.Attributes["Pinned"].Value))
			{
				x245a5abec1c73d3a.xcc464d673988ae9f.Add(windowGroup);
			}
			if (xda5bf54deb817e37.Attributes["Guid"] != null)
			{
				windowGroup.Guid = new Guid(xda5bf54deb817e37.Attributes["Guid"].Value);
			}
			foreach (object obj in xda5bf54deb817e37.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.NodeType == XmlNodeType.Element && xmlNode.Name == "Window")
				{
					DockableWindow dockableWindow = x7f72cb59f44fe44c.FindWindow(new Guid(xmlNode.Attributes["Guid"].Value));
					if (dockableWindow != null)
					{
						windowGroup.Windows.Add(dockableWindow);
					}
				}
			}
			DockableWindow dockableWindow2 = x7f72cb59f44fe44c.FindWindow(new Guid(xda5bf54deb817e37.Attributes["SelectedWindow"].Value));
			if (dockableWindow2 != null && windowGroup.Windows.Contains(dockableWindow2))
			{
				windowGroup.SelectedWindow = dockableWindow2;
			}
			return windowGroup;
		}

		// Token: 0x06000416 RID: 1046 RVA: 0x000430E0 File Offset: 0x000414E0
		private static SplitContainer xd04c36c37a8f99ab(DockSite x7f72cb59f44fe44c, XmlNode xda5bf54deb817e37)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
			SplitContainer splitContainer = new SplitContainer();
			DockSite.SetDock(splitContainer, (Dock)Enum.Parse(typeof(Dock), xda5bf54deb817e37.Attributes["Dock"].Value));
			DockSite.SetContentSize(splitContainer, (double)converter.ConvertFromString(null, CultureInfo.InvariantCulture, xda5bf54deb817e37.Attributes["ContentSize"].Value));
			splitContainer.SplitterOrientation = (Orientation)Enum.Parse(typeof(Orientation), xda5bf54deb817e37.Attributes["SplitterOrientation"].Value);
			x245a5abec1c73d3a.x777159d109746247(x7f72cb59f44fe44c, splitContainer, xda5bf54deb817e37);
			return splitContainer;
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00043198 File Offset: 0x00041598
		private static SplitContainer xc35be7f034ef4922(DockSite x7f72cb59f44fe44c, XmlNode xda5bf54deb817e37)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(Size));
			SplitContainer splitContainer = new SplitContainer();
			SplitContainer.SetWorkingSize(splitContainer, (Size)converter.ConvertFromString(null, CultureInfo.InvariantCulture, xda5bf54deb817e37.Attributes["WorkingSize"].Value));
			splitContainer.SplitterOrientation = (Orientation)Enum.Parse(typeof(Orientation), xda5bf54deb817e37.Attributes["SplitterOrientation"].Value);
			x245a5abec1c73d3a.x777159d109746247(x7f72cb59f44fe44c, splitContainer, xda5bf54deb817e37);
			return splitContainer;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00043220 File Offset: 0x00041620
		private static void x777159d109746247(DockSite x7f72cb59f44fe44c, SplitContainer x32a48f2091f0f2d3, XmlNode x8b2c3c076d5a7daf)
		{
			foreach (object obj in x8b2c3c076d5a7daf.ChildNodes)
			{
				XmlNode xmlNode = (XmlNode)obj;
				string name;
				if (xmlNode.NodeType == XmlNodeType.Element && (name = xmlNode.Name) != null)
				{
					if (!(name == "SplitContainer"))
					{
						if (name == "WindowGroup")
						{
							WindowGroup windowGroup = x245a5abec1c73d3a.x399868a2610dcb1f(x7f72cb59f44fe44c, xmlNode);
							if (windowGroup.Items.Count != 0)
							{
								x32a48f2091f0f2d3.Children.Add(windowGroup);
							}
						}
					}
					else
					{
						SplitContainer splitContainer = x245a5abec1c73d3a.xc35be7f034ef4922(x7f72cb59f44fe44c, xmlNode);
						if (splitContainer.Children.Count != 0)
						{
							x32a48f2091f0f2d3.Children.Add(splitContainer);
						}
					}
				}
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x00043300 File Offset: 0x00041700
		private static void x0a680eda7ec8bd81(DockSite x7f72cb59f44fe44c, XmlNode x8a5ce9fbef4b9a09)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(long));
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(int));
			TypeConverter converter3 = TypeDescriptor.GetConverter(typeof(double));
			TypeConverter converter4 = TypeDescriptor.GetConverter(typeof(Size));
			TypeConverter converter5 = TypeDescriptor.GetConverter(typeof(Point));
			DockableWindow dockableWindow;
			if (3 != 0)
			{
				dockableWindow = x7f72cb59f44fe44c.FindWindow(new Guid(x8a5ce9fbef4b9a09.Attributes["Guid"].Value));
				if (dockableWindow == null)
				{
					return;
				}
				if (x8a5ce9fbef4b9a09.Attributes["ContentSize"] != null)
				{
					dockableWindow.ContentSize = (double)converter3.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["ContentSize"].Value);
				}
				dockableWindow.MetaData.LastFocused = DateTime.FromBinary((long)converter.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["LastFocused"].Value));
			}
			dockableWindow.MetaData.DockedContentSize = (double)converter3.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["DockedContentSize"].Value);
			dockableWindow.MetaData.LastOpenDockSituation = (DockSituation)Enum.Parse(typeof(DockSituation), x8a5ce9fbef4b9a09.Attributes["LastOpenDockSituation"].Value);
			dockableWindow.MetaData.LastFixedDockSituation = (DockSituation)Enum.Parse(typeof(DockSituation), x8a5ce9fbef4b9a09.Attributes["LastFixedDockSituation"].Value);
			dockableWindow.MetaData.LastFixedDockSide = (Dock)Enum.Parse(typeof(Dock), x8a5ce9fbef4b9a09.Attributes["DockedPosition"].Value);
			dockableWindow.MetaData.xe54c39cad89808e2 = new Guid(x8a5ce9fbef4b9a09.Attributes["LastFloatingWindowGuid"].Value);
			dockableWindow.FloatingLocation = ((x8a5ce9fbef4b9a09.Attributes["FloatingLocation"].Value.Length != 0) ? new Point?((Point)converter5.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["FloatingLocation"].Value)) : null);
			dockableWindow.FloatingSize = (Size)converter4.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["FloatingSize"].Value);
			if (x8a5ce9fbef4b9a09.Attributes["LastDockContainerCount"] != null)
			{
				dockableWindow.MetaData.xe62a3d24e0fde928.xd25c313925dc7d4e = (int)converter2.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["LastDockContainerCount"].Value);
			}
			if (x8a5ce9fbef4b9a09.Attributes["LastDockContainerIndex"] != null)
			{
				dockableWindow.MetaData.xe62a3d24e0fde928.x71a5d248534c8557 = (int)converter2.ConvertFromString(null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["LastDockContainerIndex"].Value);
			}
			x245a5abec1c73d3a.xac29055e1acf1a28(dockableWindow, x8a5ce9fbef4b9a09, dockableWindow.MetaData.xe62a3d24e0fde928, "Docked");
			x245a5abec1c73d3a.xac29055e1acf1a28(dockableWindow, x8a5ce9fbef4b9a09, dockableWindow.MetaData.x25e1dbd0e63329bf, "Document");
			x245a5abec1c73d3a.xac29055e1acf1a28(dockableWindow, x8a5ce9fbef4b9a09, dockableWindow.MetaData.xba74b873ae2f845a, "Floating");
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00043670 File Offset: 0x00041A70
		private static void xac29055e1acf1a28(DockableWindow x76b3d9d2638e5ecd, XmlNode xeaa9dbf1fba9aca8, x129cb2a2bdfd0ab2 x592a8acce305e2d8, string x05bcae9c376a7a50)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(Size));
			x592a8acce305e2d8.x3a4e0c379519d4a2 = (Size)converter2.ConvertFromString(null, CultureInfo.InvariantCulture, xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WorkingSize"].Value);
			x592a8acce305e2d8.x1acd7f00f3ce8dea = new Guid(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WindowGroupGuid"].Value);
			x592a8acce305e2d8.xeb60189193347805 = (int)converter.ConvertFromString(null, CultureInfo.InvariantCulture, xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "IndexInWindowGroup"].Value);
			x592a8acce305e2d8.x61743036ad30763d = x245a5abec1c73d3a.xad77aeacfb4bb694(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "SplitPath"].Value);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00043750 File Offset: 0x00041B50
		private static int[] xad77aeacfb4bb694(string xc077f627453a9374)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			if (xc077f627453a9374.Length == 0)
			{
				return new int[0];
			}
			string[] array = xc077f627453a9374.Split(new char[]
			{
				'|'
			});
			int[] array2 = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = (int)converter.ConvertFromString(null, CultureInfo.InvariantCulture, array[i]);
			}
			return array2;
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x000437C4 File Offset: 0x00041BC4
		public static void x66c2033a1a9de673(DockSite x7f72cb59f44fe44c, bool x0354f623dcdbfd0b)
		{
			SplitContainer[] array = new SplitContainer[x7f72cb59f44fe44c.SplitContainers.Count];
			x7f72cb59f44fe44c.SplitContainers.CopyTo(array, 0);
			x7f72cb59f44fe44c.SplitContainers.Clear();
			SplitContainer[] array2;
			do
			{
				array2 = array;
			}
			while (false);
			foreach (SplitContainer xd3311d815ca25f in array2)
			{
				foreach (DockableWindow x76b3d9d2638e5ecd in xd679d9fc970c8f10.x19fa3ae70a75ea3c(xd3311d815ca25f))
				{
					xd679d9fc970c8f10.xe3db202f22b97a52(x76b3d9d2638e5ecd);
				}
			}
			x245a5abec1c73d3a.x1706199f7db83f91(x7f72cb59f44fe44c);
			if (x0354f623dcdbfd0b && x7f72cb59f44fe44c.DocumentContainer != null)
			{
				SplitContainer splitContainer = x7f72cb59f44fe44c.DocumentContainer.Content as SplitContainer;
				if (splitContainer != null)
				{
					DockableWindow[] array4 = xd679d9fc970c8f10.x19fa3ae70a75ea3c(splitContainer);
					splitContainer.Children.Clear();
					foreach (DockableWindow x76b3d9d2638e5ecd2 in array4)
					{
						xd679d9fc970c8f10.xe3db202f22b97a52(x76b3d9d2638e5ecd2);
					}
				}
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x000438AC File Offset: 0x00041CAC
		private static void x1706199f7db83f91(DockSite x7f72cb59f44fe44c)
		{
			FloatingWindowAdapter[] floatingWindows = x7f72cb59f44fe44c.GetFloatingWindows();
			foreach (FloatingWindowAdapter floatingWindowAdapter in floatingWindows)
			{
				floatingWindowAdapter.Hide();
				DockableWindow[] array2 = xd679d9fc970c8f10.x19fa3ae70a75ea3c(floatingWindowAdapter.RootContainer);
				floatingWindowAdapter.RootContainer.Children.Clear();
				foreach (DockableWindow x76b3d9d2638e5ecd in array2)
				{
					xd679d9fc970c8f10.xe3db202f22b97a52(x76b3d9d2638e5ecd);
				}
				floatingWindowAdapter.Close();
			}
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00043928 File Offset: 0x00041D28
		public static string x8d5cf4fcf22576e9(DockSite x7f72cb59f44fe44c, bool x0354f623dcdbfd0b)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(bool));
			string result;
			using (StringWriter stringWriter = new StringWriter())
			{
				using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
				{
					xmlTextWriter.Formatting = Formatting.Indented;
					xmlTextWriter.WriteStartDocument();
					xmlTextWriter.WriteStartElement("SandDockLayout");
					if (!BrowserInteropHelper.IsBrowserHosted)
					{
						xmlTextWriter.WriteAttributeString("Version", typeof(x245a5abec1c73d3a).Assembly.GetName().Version.ToString());
					}
					xmlTextWriter.WriteAttributeString("IncludeDocuments", converter.ConvertToString(null, CultureInfo.InvariantCulture, x0354f623dcdbfd0b));
					DockableWindow[] allWindows = x7f72cb59f44fe44c.GetAllWindows();
					int num = 0;
					SplitContainer splitContainer2;
					for (;;)
					{
						DockableWindow dockableWindow;
						if (num >= allWindows.Length)
						{
							foreach (object obj in x7f72cb59f44fe44c.SplitContainers)
							{
								SplitContainer splitContainer = (SplitContainer)obj;
								if (x245a5abec1c73d3a.xcf324f013237ce9a(splitContainer))
								{
									x245a5abec1c73d3a.xa53993a452bf4eba(splitContainer, xmlTextWriter);
								}
							}
							x245a5abec1c73d3a.x5651d5c997d9832e(x7f72cb59f44fe44c, xmlTextWriter);
							if (!x0354f623dcdbfd0b || x7f72cb59f44fe44c.DocumentContainer == null)
							{
								goto IL_153;
							}
							splitContainer2 = (x7f72cb59f44fe44c.DocumentContainer.Content as SplitContainer);
							if (splitContainer2 == null)
							{
								goto IL_153;
							}
							if (4 != 0)
							{
								break;
							}
							goto IL_B6;
						}
						else
						{
							dockableWindow = allWindows[num];
							if (x245a5abec1c73d3a.x569baefcaa407a6b(dockableWindow) && (x0354f623dcdbfd0b || dockableWindow.DockSituation != DockSituation.Document))
							{
								goto IL_B6;
							}
						}
						IL_BD:
						num++;
						continue;
						IL_B6:
						x245a5abec1c73d3a.x4229d31a884b2577(dockableWindow, xmlTextWriter);
						goto IL_BD;
					}
					x245a5abec1c73d3a.x904da9c3ef099705(splitContainer2, xmlTextWriter);
					IL_153:
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndDocument();
				}
				result = stringWriter.ToString();
			}
			return result;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00043B04 File Offset: 0x00041F04
		private static void x5651d5c997d9832e(DockSite x7f72cb59f44fe44c, XmlTextWriter x536ee0b561cc97c2)
		{
			foreach (FloatingWindowAdapter floatingWindowAdapter in x7f72cb59f44fe44c.GetFloatingWindows())
			{
				if (x245a5abec1c73d3a.xcf324f013237ce9a(floatingWindowAdapter.RootContainer))
				{
					x245a5abec1c73d3a.x197813d3b1ab5507(floatingWindowAdapter, x536ee0b561cc97c2);
				}
			}
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00043B40 File Offset: 0x00041F40
		private static void x904da9c3ef099705(SplitContainer x32a48f2091f0f2d3, XmlTextWriter xbdfb620b7167944b)
		{
			xbdfb620b7167944b.WriteStartElement("DocumentSplitContainer");
			x245a5abec1c73d3a.x1be2df41c4226337(x32a48f2091f0f2d3, xbdfb620b7167944b);
			xbdfb620b7167944b.WriteEndElement();
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00043B5C File Offset: 0x00041F5C
		private static void x197813d3b1ab5507(FloatingWindowAdapter x3db253e15383fe11, XmlTextWriter xbdfb620b7167944b)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(Point));
			xbdfb620b7167944b.WriteStartElement("FloatingWindow");
			xbdfb620b7167944b.WriteAttributeString("Location", converter2.ConvertToString(null, CultureInfo.InvariantCulture, x3db253e15383fe11.FloatingLocation));
			xbdfb620b7167944b.WriteAttributeString("Width", converter.ConvertToString(null, CultureInfo.InvariantCulture, x3db253e15383fe11.FloatingSize.Width));
			xbdfb620b7167944b.WriteAttributeString("Height", converter.ConvertToString(null, CultureInfo.InvariantCulture, x3db253e15383fe11.FloatingSize.Height));
			xbdfb620b7167944b.WriteAttributeString("Guid", x3db253e15383fe11.Guid.ToString());
			x245a5abec1c73d3a.x1be2df41c4226337(x3db253e15383fe11.RootContainer, xbdfb620b7167944b);
			xbdfb620b7167944b.WriteEndElement();
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00043C3C File Offset: 0x0004203C
		private static void xd01cb2985eabf02d(WindowGroup x2df2648551d39285, XmlTextWriter xbdfb620b7167944b)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(bool));
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(Size));
			xbdfb620b7167944b.WriteStartElement("WindowGroup");
			xbdfb620b7167944b.WriteAttributeString("WorkingSize", converter2.ConvertToString(null, CultureInfo.InvariantCulture, SplitContainer.GetWorkingSize(x2df2648551d39285)));
			xbdfb620b7167944b.WriteAttributeString("Pinned", converter.ConvertToString(null, CultureInfo.InvariantCulture, x2df2648551d39285.Pinned));
			xbdfb620b7167944b.WriteAttributeString("SelectedWindow", x2df2648551d39285.SelectedWindow.Guid.ToString());
			xbdfb620b7167944b.WriteAttributeString("Guid", x2df2648551d39285.Guid.ToString());
			foreach (DockableWindow dockableWindow in x2df2648551d39285.Windows)
			{
				if (x245a5abec1c73d3a.x569baefcaa407a6b(dockableWindow))
				{
					xbdfb620b7167944b.WriteStartElement("Window");
					xbdfb620b7167944b.WriteAttributeString("Guid", dockableWindow.Guid.ToString());
					xbdfb620b7167944b.WriteEndElement();
				}
			}
			xbdfb620b7167944b.WriteEndElement();
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00043D88 File Offset: 0x00042188
		private static void xa53993a452bf4eba(SplitContainer xd399f5c958d9baf2, XmlTextWriter xbdfb620b7167944b)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
			xbdfb620b7167944b.WriteStartElement("DockedSplitContainer");
			xbdfb620b7167944b.WriteAttributeString("Dock", DockSite.GetDock(xd399f5c958d9baf2).ToString());
			xbdfb620b7167944b.WriteAttributeString("ContentSize", converter.ConvertToString(null, CultureInfo.InvariantCulture, DockSite.GetContentSize(xd399f5c958d9baf2)));
			xbdfb620b7167944b.WriteAttributeString("SplitterOrientation", xd399f5c958d9baf2.SplitterOrientation.ToString());
			x245a5abec1c73d3a.x1be2df41c4226337(xd399f5c958d9baf2, xbdfb620b7167944b);
			xbdfb620b7167944b.WriteEndElement();
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00043E18 File Offset: 0x00042218
		private static void x9ed331b683fee4a5(SplitContainer x32a48f2091f0f2d3, XmlTextWriter xbdfb620b7167944b)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(Size));
			xbdfb620b7167944b.WriteStartElement("SplitContainer");
			xbdfb620b7167944b.WriteAttributeString("WorkingSize", converter.ConvertToString(null, CultureInfo.InvariantCulture, SplitContainer.GetWorkingSize(x32a48f2091f0f2d3)));
			xbdfb620b7167944b.WriteAttributeString("SplitterOrientation", x32a48f2091f0f2d3.SplitterOrientation.ToString());
			x245a5abec1c73d3a.x1be2df41c4226337(x32a48f2091f0f2d3, xbdfb620b7167944b);
			xbdfb620b7167944b.WriteEndElement();
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00043E8C File Offset: 0x0004228C
		private static void x1be2df41c4226337(SplitContainer x32a48f2091f0f2d3, XmlTextWriter xbdfb620b7167944b)
		{
			foreach (object obj in x32a48f2091f0f2d3.Children)
			{
				FrameworkElement frameworkElement = (FrameworkElement)obj;
				SplitContainer splitContainer = frameworkElement as SplitContainer;
				if (splitContainer != null && x245a5abec1c73d3a.xcf324f013237ce9a(splitContainer))
				{
					x245a5abec1c73d3a.x9ed331b683fee4a5(splitContainer, xbdfb620b7167944b);
				}
				WindowGroup windowGroup = frameworkElement as WindowGroup;
				if (windowGroup != null && x245a5abec1c73d3a.xcf324f013237ce9a(windowGroup))
				{
					x245a5abec1c73d3a.xd01cb2985eabf02d(windowGroup, xbdfb620b7167944b);
				}
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00043F20 File Offset: 0x00042320
		private static void x4229d31a884b2577(DockableWindow x76b3d9d2638e5ecd, XmlTextWriter xbdfb620b7167944b)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(long));
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(int));
			TypeConverter converter3 = TypeDescriptor.GetConverter(typeof(double));
			TypeConverter converter4 = TypeDescriptor.GetConverter(typeof(Size));
			TypeConverter converter5 = TypeDescriptor.GetConverter(typeof(Point));
			bool hasGuid = x76b3d9d2638e5ecd.HasGuid;
			xbdfb620b7167944b.WriteStartElement("Window");
			xbdfb620b7167944b.WriteAttributeString("Guid", x76b3d9d2638e5ecd.Guid.ToString());
			xbdfb620b7167944b.WriteAttributeString("ContentSize", converter3.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.ContentSize));
			xbdfb620b7167944b.WriteAttributeString("LastFocused", converter.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.MetaData.LastFocused.ToBinary()));
			xbdfb620b7167944b.WriteAttributeString("DockedContentSize", converter3.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.MetaData.DockedContentSize));
			xbdfb620b7167944b.WriteAttributeString("LastOpenDockSituation", x76b3d9d2638e5ecd.MetaData.LastOpenDockSituation.ToString());
			xbdfb620b7167944b.WriteAttributeString("LastFixedDockSituation", x76b3d9d2638e5ecd.MetaData.LastFixedDockSituation.ToString());
			xbdfb620b7167944b.WriteAttributeString("DockedPosition", x76b3d9d2638e5ecd.MetaData.LastFixedDockSide.ToString());
			xbdfb620b7167944b.WriteAttributeString("LastFloatingWindowGuid", x76b3d9d2638e5ecd.MetaData.xe54c39cad89808e2.ToString());
			xbdfb620b7167944b.WriteAttributeString("FloatingLocation", (x76b3d9d2638e5ecd.FloatingLocation != null) ? converter5.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.FloatingLocation) : string.Empty);
			xbdfb620b7167944b.WriteAttributeString("FloatingSize", converter4.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.FloatingSize));
			xbdfb620b7167944b.WriteAttributeString("LastDockContainerCount", converter2.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928.xd25c313925dc7d4e));
			xbdfb620b7167944b.WriteAttributeString("LastDockContainerIndex", converter2.ConvertToString(null, CultureInfo.InvariantCulture, x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928.x71a5d248534c8557));
			x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928, "Docked");
			x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.x25e1dbd0e63329bf, "Document");
			x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.xba74b873ae2f845a, "Floating");
			xbdfb620b7167944b.WriteEndElement();
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000441B0 File Offset: 0x000425B0
		private static void x47161f81513f1258(DockableWindow x76b3d9d2638e5ecd, XmlTextWriter xbdfb620b7167944b, x129cb2a2bdfd0ab2 x592a8acce305e2d8, string x05bcae9c376a7a50)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(Size));
			xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "WorkingSize", converter2.ConvertToString(null, CultureInfo.InvariantCulture, x592a8acce305e2d8.x3a4e0c379519d4a2));
			xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "WindowGroupGuid", x592a8acce305e2d8.x1acd7f00f3ce8dea.ToString());
			xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "IndexInWindowGroup", converter.ConvertToString(null, CultureInfo.InvariantCulture, x592a8acce305e2d8.xeb60189193347805));
			xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "SplitPath", x245a5abec1c73d3a.x8c8bb4495a487cc5(x592a8acce305e2d8.x61743036ad30763d));
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x00044270 File Offset: 0x00042670
		private static string x8c8bb4495a487cc5(int[] x6a80d3cc98596663)
		{
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			string[] array = new string[x6a80d3cc98596663.Length];
			for (int i = 0; i < x6a80d3cc98596663.Length; i++)
			{
				array[i] = converter.ConvertToString(null, CultureInfo.InvariantCulture, x6a80d3cc98596663[i]);
			}
			return string.Join("|", array);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000442C8 File Offset: 0x000426C8
		private static bool xcf324f013237ce9a(WindowGroup x2df2648551d39285)
		{
			foreach (DockableWindow x76b3d9d2638e5ecd in x2df2648551d39285.Windows)
			{
				if (x245a5abec1c73d3a.x569baefcaa407a6b(x76b3d9d2638e5ecd))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0004432C File Offset: 0x0004272C
		private static bool xcf324f013237ce9a(SplitContainer x32a48f2091f0f2d3)
		{
			foreach (DockableWindow x76b3d9d2638e5ecd in xd679d9fc970c8f10.x19fa3ae70a75ea3c(x32a48f2091f0f2d3))
			{
				if (x245a5abec1c73d3a.x569baefcaa407a6b(x76b3d9d2638e5ecd))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00044364 File Offset: 0x00042764
		private static bool x569baefcaa407a6b(DockableWindow x76b3d9d2638e5ecd)
		{
			return true;
		}

		// Token: 0x040001BE RID: 446
		private static List<WindowGroup> xcc464d673988ae9f = new List<WindowGroup>();
	}
}

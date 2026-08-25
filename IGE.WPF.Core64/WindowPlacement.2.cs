using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using System.Xml;
using System.Xml.Serialization;

namespace IGE
{
	// Token: 0x02000043 RID: 67
	public static class WindowPlacement
	{
		// Token: 0x0600030A RID: 778
		[DllImport("user32.dll")]
		private static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

		// Token: 0x0600030B RID: 779
		[DllImport("user32.dll")]
		private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

		// Token: 0x0600030C RID: 780 RVA: 0x000096D0 File Offset: 0x000078D0
		public static void SetPlacement(IntPtr windowHandle, string placementXml)
		{
			if (string.IsNullOrEmpty(placementXml))
			{
				return;
			}
			byte[] bytes = WindowPlacement.encoding.GetBytes(placementXml);
			try
			{
				WINDOWPLACEMENT windowplacement;
				using (MemoryStream memoryStream = new MemoryStream(bytes))
				{
					windowplacement = (WINDOWPLACEMENT)WindowPlacement.serializer.Deserialize(memoryStream);
				}
				windowplacement.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
				windowplacement.flags = 0;
				windowplacement.showCmd = ((windowplacement.showCmd == 2) ? 1 : windowplacement.showCmd);
				WindowPlacement.SetWindowPlacement(windowHandle, ref windowplacement);
			}
			catch (InvalidOperationException)
			{
			}
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000977C File Offset: 0x0000797C
		public static string GetPlacement(IntPtr windowHandle)
		{
			WINDOWPLACEMENT windowplacement = default(WINDOWPLACEMENT);
			WindowPlacement.GetWindowPlacement(windowHandle, out windowplacement);
			string @string;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8))
				{
					WindowPlacement.serializer.Serialize(xmlTextWriter, windowplacement);
					byte[] bytes = memoryStream.ToArray();
					@string = WindowPlacement.encoding.GetString(bytes);
				}
			}
			return @string;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00009808 File Offset: 0x00007A08
		public static void SetPlacement(this Window window, string placementXml)
		{
			WindowPlacement.SetPlacement(new WindowInteropHelper(window).Handle, placementXml);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000981B File Offset: 0x00007A1B
		public static string GetPlacement(this Window window)
		{
			return WindowPlacement.GetPlacement(new WindowInteropHelper(window).Handle);
		}

		// Token: 0x04000149 RID: 329
		private const int SW_SHOWNORMAL = 1;

		// Token: 0x0400014A RID: 330
		private const int SW_SHOWMINIMIZED = 2;

		// Token: 0x0400014B RID: 331
		private static Encoding encoding = new UTF8Encoding();

		// Token: 0x0400014C RID: 332
		private static XmlSerializer serializer = new XmlSerializer(typeof(WINDOWPLACEMENT));
	}
}

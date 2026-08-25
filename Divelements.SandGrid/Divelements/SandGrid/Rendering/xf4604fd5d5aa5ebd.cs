using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x0200004E RID: 78
	internal class xf4604fd5d5aa5ebd
	{
		// Token: 0x06000522 RID: 1314
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int DrawText(IntPtr hdc, string lpStr, int nCount, ref Rectangle lpRect, int wFormat);

		// Token: 0x06000523 RID: 1315
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int DrawTextEx(IntPtr hdc, string lpStr, int nCount, ref Rectangle lpRect, int wFormat, int paramss);

		// Token: 0x06000524 RID: 1316
		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr CreateFontIndirect([MarshalAs(UnmanagedType.AsAny)] [In] [Out] object lplf);

		// Token: 0x06000525 RID: 1317
		[DllImport("gdi32.dll")]
		private static extern bool DeleteObject(HandleRef hObject);

		// Token: 0x06000526 RID: 1318
		[DllImport("gdi32.dll")]
		private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x06000527 RID: 1319
		[DllImport("gdi32.dll")]
		private static extern int SetBkMode(IntPtr hdc, int iBkMode);

		// Token: 0x06000528 RID: 1320
		[DllImport("gdi32.dll")]
		private static extern uint SetTextColor(IntPtr hdc, int crColor);

		// Token: 0x06000529 RID: 1321 RVA: 0x0001AEBC File Offset: 0x00019EBC
		public static void xf27faba8bf71f5c9(int x4b2316bbfb8c0813, int x3f841024dc87f837)
		{
			xf4604fd5d5aa5ebd.x51d02fb10da4fb34 = xf4604fd5d5aa5ebd.x3758cf4ee715d797;
			xf4604fd5d5aa5ebd.x72657afc457dafe2 = xf4604fd5d5aa5ebd.x6842879318972d9e;
			xf4604fd5d5aa5ebd.x3758cf4ee715d797 = x4b2316bbfb8c0813;
			xf4604fd5d5aa5ebd.x6842879318972d9e = x3f841024dc87f837;
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0001AEE0 File Offset: 0x00019EE0
		public static void x71d716d9340a225a()
		{
			xf4604fd5d5aa5ebd.x3758cf4ee715d797 = xf4604fd5d5aa5ebd.x51d02fb10da4fb34;
			xf4604fd5d5aa5ebd.x6842879318972d9e = xf4604fd5d5aa5ebd.x72657afc457dafe2;
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0001AEF8 File Offset: 0x00019EF8
		public static void x2d90aa1d9008ac09(Graphics x41347a961b838962, int x4b2316bbfb8c0813, int x3f841024dc87f837)
		{
			xf4604fd5d5aa5ebd.x488120fcd42cfc3d = (int)x41347a961b838962.DpiY;
			xf4604fd5d5aa5ebd.x3758cf4ee715d797 = x4b2316bbfb8c0813;
			xf4604fd5d5aa5ebd.x6842879318972d9e = x3f841024dc87f837;
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0001AF14 File Offset: 0x00019F14
		public static void xe1f5bc71fd8a1afa()
		{
			foreach (object obj in xf4604fd5d5aa5ebd.x9cf1c8c9cded4c65.Values)
			{
				xf4604fd5d5aa5ebd.xc75b97bf3cb8b4e2 xc75b97bf3cb8b4e = (xf4604fd5d5aa5ebd.xc75b97bf3cb8b4e2)obj;
				xc75b97bf3cb8b4e.Dispose();
			}
			xf4604fd5d5aa5ebd.x9cf1c8c9cded4c65.Clear();
			xf4604fd5d5aa5ebd.x3758cf4ee715d797 = 0;
			xf4604fd5d5aa5ebd.x6842879318972d9e = 0;
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0001AF94 File Offset: 0x00019F94
		public static void xc9f808b2238be32a(Graphics x41347a961b838962, string xb41faee6912a2313, Font x26094932cf7a9139, Rectangle xda73fcb97c77d998, TextFormatFlags xebf45bdcaa1fd1e1, Color x6c50a99faab7d741)
		{
			IntPtr hdc = x41347a961b838962.GetHdc();
			xf4604fd5d5aa5ebd.SetBkMode(hdc, 1);
			xf4604fd5d5aa5ebd.SetTextColor(hdc, ColorTranslator.ToWin32(x6c50a99faab7d741));
			xf4604fd5d5aa5ebd.xc75b97bf3cb8b4e2 xc75b97bf3cb8b4e = xf4604fd5d5aa5ebd.xf46336e555240752(x26094932cf7a9139, xf4604fd5d5aa5ebd.x488120fcd42cfc3d);
			xf4604fd5d5aa5ebd.SelectObject(hdc, xc75b97bf3cb8b4e.x7efbe0a2dc0d335f);
			xda73fcb97c77d998.Offset(-xf4604fd5d5aa5ebd.x3758cf4ee715d797, -xf4604fd5d5aa5ebd.x6842879318972d9e);
			xda73fcb97c77d998.Width += xda73fcb97c77d998.X;
			xda73fcb97c77d998.Height += xda73fcb97c77d998.Y;
			if ((xebf45bdcaa1fd1e1 & TextFormatFlags.VerticalCenter) == TextFormatFlags.VerticalCenter && (xebf45bdcaa1fd1e1 & TextFormatFlags.SingleLine) != TextFormatFlags.SingleLine)
			{
				Rectangle rectangle = xda73fcb97c77d998;
				int num = xf4604fd5d5aa5ebd.DrawTextEx(hdc, xb41faee6912a2313, xb41faee6912a2313.Length, ref rectangle, (int)(xebf45bdcaa1fd1e1 | (TextFormatFlags)1024), 0);
				if (num < xda73fcb97c77d998.Height - xda73fcb97c77d998.Y)
				{
					xda73fcb97c77d998.Y += (xda73fcb97c77d998.Height - xda73fcb97c77d998.Y) / 2 - num / 2;
				}
			}
			xf4604fd5d5aa5ebd.DrawText(hdc, xb41faee6912a2313, xb41faee6912a2313.Length, ref xda73fcb97c77d998, (int)xebf45bdcaa1fd1e1);
			x41347a961b838962.ReleaseHdc(hdc);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0001B090 File Offset: 0x0001A090
		private static xf4604fd5d5aa5ebd.xc75b97bf3cb8b4e2 xf46336e555240752(Font x26094932cf7a9139, int x488120fcd42cfc3d)
		{
			xf4604fd5d5aa5ebd.xc75b97bf3cb8b4e2 xc75b97bf3cb8b4e = (xf4604fd5d5aa5ebd.xc75b97bf3cb8b4e2)xf4604fd5d5aa5ebd.x9cf1c8c9cded4c65[x26094932cf7a9139];
			if (xc75b97bf3cb8b4e != null)
			{
				return xc75b97bf3cb8b4e;
			}
			xc75b97bf3cb8b4e = xf4604fd5d5aa5ebd.xc75b97bf3cb8b4e2.xb9c8a8c323f85bb9(x26094932cf7a9139, x488120fcd42cfc3d);
			xf4604fd5d5aa5ebd.x9cf1c8c9cded4c65[x26094932cf7a9139] = xc75b97bf3cb8b4e;
			return xc75b97bf3cb8b4e;
		}

		// Token: 0x040001C3 RID: 451
		private static Hashtable x9cf1c8c9cded4c65 = new Hashtable();

		// Token: 0x040001C4 RID: 452
		private static int x3758cf4ee715d797;

		// Token: 0x040001C5 RID: 453
		private static int x6842879318972d9e;

		// Token: 0x040001C6 RID: 454
		private static int x488120fcd42cfc3d;

		// Token: 0x040001C7 RID: 455
		private static int x51d02fb10da4fb34;

		// Token: 0x040001C8 RID: 456
		private static int x72657afc457dafe2;

		// Token: 0x0200004F RID: 79
		private class xc75b97bf3cb8b4e2 : IDisposable
		{
			// Token: 0x06000531 RID: 1329 RVA: 0x0001B0DC File Offset: 0x0001A0DC
			public xc75b97bf3cb8b4e2(string familyName, float size, FontStyle style, byte charSet, int dpiY)
			{
				this.xa34fb636c21d7ae5 = default(xf4604fd5d5aa5ebd.xec6fd8141c5aa2df);
				int num = (int)Math.Ceiling((double)((float)dpiY * size / 72f));
				this.xa34fb636c21d7ae5.x2d7d0af5e89ed4c3 = -num;
				this.xa34fb636c21d7ae5.x1535bb3bbe793344 = familyName;
				this.xa34fb636c21d7ae5.x37d300c88d2225cd = charSet;
				this.xa34fb636c21d7ae5.xd299990210c7e6d9 = 4;
				this.xa34fb636c21d7ae5.x6337df81402a9068 = 0;
				this.xa34fb636c21d7ae5.xcca376b5d8d20f63 = (((style & FontStyle.Bold) == FontStyle.Bold) ? 700 : 400);
				this.xa34fb636c21d7ae5.x5dcebf562a97ada0 = (((style & FontStyle.Italic) == FontStyle.Italic) ? 1 : 0);
				this.xa34fb636c21d7ae5.x756f72350dc4a82a = (((style & FontStyle.Underline) == FontStyle.Underline) ? 1 : 0);
				this.xa34fb636c21d7ae5.x99c78693def8f1a9 = (((style & FontStyle.Strikeout) == FontStyle.Strikeout) ? 1 : 0);
				this.x181c5936b621697a = xf4604fd5d5aa5ebd.CreateFontIndirect(this.xa34fb636c21d7ae5);
			}

			// Token: 0x06000532 RID: 1330 RVA: 0x0001B1C0 File Offset: 0x0001A1C0
			public static xf4604fd5d5aa5ebd.xc75b97bf3cb8b4e2 xb9c8a8c323f85bb9(Font x26094932cf7a9139, int x488120fcd42cfc3d)
			{
				string text = x26094932cf7a9139.FontFamily.Name;
				if (text.StartsWith("@"))
				{
					text = text.Substring(1);
				}
				return new xf4604fd5d5aa5ebd.xc75b97bf3cb8b4e2(text, x26094932cf7a9139.SizeInPoints, x26094932cf7a9139.Style, x26094932cf7a9139.GdiCharSet, x488120fcd42cfc3d);
			}

			// Token: 0x1700014A RID: 330
			// (get) Token: 0x06000533 RID: 1331 RVA: 0x0001B208 File Offset: 0x0001A208
			public IntPtr x7efbe0a2dc0d335f
			{
				get
				{
					return this.x181c5936b621697a;
				}
			}

			// Token: 0x06000534 RID: 1332 RVA: 0x0001B210 File Offset: 0x0001A210
			public void Dispose()
			{
				xf4604fd5d5aa5ebd.DeleteObject(new HandleRef(this, this.x181c5936b621697a));
			}

			// Token: 0x040001C9 RID: 457
			private xf4604fd5d5aa5ebd.xec6fd8141c5aa2df xa34fb636c21d7ae5;

			// Token: 0x040001CA RID: 458
			private IntPtr x181c5936b621697a;
		}

		// Token: 0x02000050 RID: 80
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private struct xec6fd8141c5aa2df
		{
			// Token: 0x040001CB RID: 459
			public int x2d7d0af5e89ed4c3;

			// Token: 0x040001CC RID: 460
			public int x38f68e1ecef00e14;

			// Token: 0x040001CD RID: 461
			public int xc731ad0995ff4803;

			// Token: 0x040001CE RID: 462
			public int xba1f845c7d069e92;

			// Token: 0x040001CF RID: 463
			public int xcca376b5d8d20f63;

			// Token: 0x040001D0 RID: 464
			public byte x5dcebf562a97ada0;

			// Token: 0x040001D1 RID: 465
			public byte x756f72350dc4a82a;

			// Token: 0x040001D2 RID: 466
			public byte x99c78693def8f1a9;

			// Token: 0x040001D3 RID: 467
			public byte x37d300c88d2225cd;

			// Token: 0x040001D4 RID: 468
			public byte xd299990210c7e6d9;

			// Token: 0x040001D5 RID: 469
			public byte x17b85bea39260524;

			// Token: 0x040001D6 RID: 470
			public byte x6337df81402a9068;

			// Token: 0x040001D7 RID: 471
			public byte xf39965c1dd63f2a8;

			// Token: 0x040001D8 RID: 472
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string x1535bb3bbe793344;
		}
	}
}

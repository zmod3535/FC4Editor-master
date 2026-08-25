using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace IGE
{
	// Token: 0x020000C8 RID: 200
	internal class Win32
	{
		// Token: 0x06000778 RID: 1912
		[DllImport("kernel32.dll")]
		public static extern void RtlMoveMemory(IntPtr dest, IntPtr src, int size);

		// Token: 0x06000779 RID: 1913
		[DllImport("kernel32.dll")]
		public static extern void GetPrivateProfileStringW([MarshalAs(UnmanagedType.LPWStr)] string lpAppName, [MarshalAs(UnmanagedType.LPWStr)] string lpKeyName, [MarshalAs(UnmanagedType.LPWStr)] string lpDefault, IntPtr lpReturnedString, int nSize, [MarshalAs(UnmanagedType.LPWStr)] string lpFileName);

		// Token: 0x0600077A RID: 1914
		[DllImport("User32.dll")]
		public static extern bool SetCursorPos(int x, int y);

		// Token: 0x0600077B RID: 1915
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetCursorPos(out Win32.Point lpPoint);

		// Token: 0x0600077C RID: 1916 RVA: 0x0001AE6C File Offset: 0x0001906C
		public static void GetPrivateProfileStringW(string lpAppName, string lpKeyName, string lpDefault, out string lpReturnedString, string lpFileName)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(514);
			Win32.GetPrivateProfileStringW(lpAppName, lpKeyName, lpDefault, intPtr, 256, lpFileName);
			lpReturnedString = Marshal.PtrToStringUni(intPtr);
			Marshal.FreeHGlobal(intPtr);
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x0001AEA2 File Offset: 0x000190A2
		public static int LoWord(int dw)
		{
			return dw & 65535;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x0001AEAB File Offset: 0x000190AB
		public static int HiWord(int dw)
		{
			return dw >> 16;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0001AEB1 File Offset: 0x000190B1
		public static int MakeLong(int lw, int hw)
		{
			return (lw & 65535) | (hw & 65535) << 16;
		}

		// Token: 0x06000780 RID: 1920
		[DllImport("user32.dll")]
		public static extern bool GetMessage(out Win32.Message msg, IntPtr hWnd, int wMsgFilterMin, int wMsgFilterMax);

		// Token: 0x06000781 RID: 1921
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

		// Token: 0x06000782 RID: 1922
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Win32.Rect lParam);

		// Token: 0x06000783 RID: 1923
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref Win32.COPYDATASTRUCT lParam);

		// Token: 0x06000784 RID: 1924
		[DllImport("user32.dll")]
		public static extern bool PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);

		// Token: 0x06000785 RID: 1925
		[DllImport("user32.dll")]
		public static extern bool TranslateMessage(ref Win32.Message msg);

		// Token: 0x06000786 RID: 1926
		[DllImport("user32.dll")]
		public static extern bool DispatchMessage(ref Win32.Message msg);

		// Token: 0x06000787 RID: 1927
		[DllImport("user32.dll")]
		public static extern bool IsChild(IntPtr hWndParent, IntPtr hWnd);

		// Token: 0x06000788 RID: 1928
		[DllImport("user32.dll")]
		public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, ref Win32.Point pt, int cPoints);

		// Token: 0x06000789 RID: 1929
		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x0600078A RID: 1930
		[DllImport("user32.dll")]
		public static extern IntPtr GetActiveWindow();

		// Token: 0x0600078B RID: 1931
		[DllImport("user32.dll")]
		public static extern IntPtr GetParent(IntPtr hWnd);

		// Token: 0x0600078C RID: 1932
		[DllImport("user32.dll")]
		public static extern bool IsWindowEnabled(IntPtr hWnd);

		// Token: 0x0600078D RID: 1933
		[DllImport("user32.dll")]
		public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, int flags);

		// Token: 0x0600078E RID: 1934
		[DllImport("user32.dll")]
		public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

		// Token: 0x0600078F RID: 1935
		[DllImport("user32.dll")]
		public static extern uint SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

		// Token: 0x06000790 RID: 1936
		[DllImport("user32.dll")]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		// Token: 0x06000791 RID: 1937
		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06000792 RID: 1938
		[DllImport("user32.dll")]
		public static extern int EnumWindows(Win32.EnumWindowsProc ewp, IntPtr lParam);

		// Token: 0x06000793 RID: 1939
		[DllImport("user32.dll")]
		public static extern IntPtr GetProp(IntPtr hWnd, string lpString);

		// Token: 0x06000794 RID: 1940
		[DllImport("user32.dll")]
		public static extern bool SetProp(IntPtr hWnd, string lpString, IntPtr hData);

		// Token: 0x06000795 RID: 1941
		[DllImport("user32.dll")]
		public static extern IntPtr RemoveProp(IntPtr hWnd, string lpString);

		// Token: 0x06000796 RID: 1942
		[DllImport("user32.dll")]
		public static extern IntPtr GetCapture();

		// Token: 0x06000797 RID: 1943
		[DllImport("user32.dll")]
		public static extern void SetCapture(IntPtr hWnd);

		// Token: 0x06000798 RID: 1944
		[DllImport("user32.dll")]
		public static extern void ReleaseCapture();

		// Token: 0x06000799 RID: 1945 RVA: 0x0001AEC5 File Offset: 0x000190C5
		public static void SetRedraw(Control control, bool redraw)
		{
			Win32.SendMessage(control.Handle, 11, redraw ? 1 : 0, 0);
		}

		// Token: 0x0600079A RID: 1946
		[DllImport("user32.dll")]
		public static extern ushort GetKeyState(int nVirtKey);

		// Token: 0x0600079B RID: 1947 RVA: 0x0001AEDD File Offset: 0x000190DD
		public static bool IsKeyDown(int nVirtKey)
		{
			return (Win32.GetKeyState(nVirtKey) & 32768) != 0;
		}

		// Token: 0x0600079C RID: 1948
		[DllImport("user32.dll")]
		public static extern IntPtr GetKeyboardLayout(int idThread);

		// Token: 0x0600079D RID: 1949
		[DllImport("user32.dll")]
		public static extern int MapVirtualKey(int uCode, int uMapType);

		// Token: 0x0600079E RID: 1950
		[DllImport("user32.dll")]
		public static extern int MapVirtualKeyEx(int uCode, int uMapType, IntPtr dwhkl);

		// Token: 0x0600079F RID: 1951
		[DllImport("user32.dll")]
		public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

		// Token: 0x060007A0 RID: 1952
		[DllImport("user32.dll")]
		public static extern bool DestroyCaret();

		// Token: 0x060007A1 RID: 1953
		[DllImport("user32.dll")]
		public static extern bool ShowCaret(IntPtr hWnd);

		// Token: 0x060007A2 RID: 1954
		[DllImport("user32.dll")]
		public static extern bool HideCaret(IntPtr hWnd);

		// Token: 0x060007A3 RID: 1955
		[DllImport("user32.dll")]
		public static extern void GetCaretPos(out Win32.Point pt);

		// Token: 0x060007A4 RID: 1956
		[DllImport("user32.dll")]
		public static extern bool SetCaretPos(int x, int y);

		// Token: 0x060007A5 RID: 1957
		[DllImport("user32.dll")]
		public static extern int GetScrollInfo(IntPtr hWnd, int nBar, [In] Win32.ScrollInfo scrollInfo);

		// Token: 0x060007A6 RID: 1958
		[DllImport("user32.dll")]
		public static extern int SetScrollInfo(IntPtr hWnd, int nBar, [In] Win32.ScrollInfo scrollInfo, bool bRedraw);

		// Token: 0x060007A7 RID: 1959
		[DllImport("user32.dll")]
		public static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

		// Token: 0x060007A8 RID: 1960
		[DllImport("user32.dll")]
		public static extern int ScrollWindowEx(IntPtr hWnd, int dx, int dy, ref Win32.Rect prcScroll, ref Win32.Rect prcClip, IntPtr hrgnUpdate, IntPtr prcUpdate, int flags);

		// Token: 0x060007A9 RID: 1961
		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hWnd);

		// Token: 0x060007AA RID: 1962
		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		// Token: 0x060007AB RID: 1963
		[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawTextExW")]
		public static extern int DrawTextEx(IntPtr hdc, string lpchText, int cchText, ref Win32.Rect lprc, uint dwDTFormat, [In] [Out] Win32.DrawTextParams lpDTParams);

		// Token: 0x060007AC RID: 1964
		[DllImport("user32.dll")]
		public static extern int FillRect(IntPtr hDC, ref Win32.Rect lprc, IntPtr hbr);

		// Token: 0x060007AD RID: 1965
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		// Token: 0x060007AE RID: 1966
		[DllImport("gdi32.dll")]
		public static extern bool DeleteDC(IntPtr hdc);

		// Token: 0x060007AF RID: 1967
		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);

		// Token: 0x060007B0 RID: 1968
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, uint crColor);

		// Token: 0x060007B1 RID: 1969
		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateSolidBrush(int crColor);

		// Token: 0x060007B2 RID: 1970
		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		// Token: 0x060007B3 RID: 1971
		[DllImport("gdi32.dll")]
		public static extern int SetTextColor(IntPtr hdc, int crColor);

		// Token: 0x060007B4 RID: 1972
		[DllImport("gdi32.dll")]
		public static extern int SetBkColor(IntPtr hdc, int crColor);

		// Token: 0x060007B5 RID: 1973
		[DllImport("gdi32.dll")]
		public static extern bool GetCharABCWidths(IntPtr hdc, uint uFirstChar, uint uLastChar, [Out] Win32.ABC[] lpabc);

		// Token: 0x060007B6 RID: 1974
		[DllImport("gdi32.dll")]
		public static extern bool GetTextExtentExPoint(IntPtr hdc, string lpszStr, int cchString, int nMaxExtent, out int lpnFit, IntPtr alpDx, out Win32.Size lpSize);

		// Token: 0x060007B7 RID: 1975
		[DllImport("gdi32.dll")]
		public static extern bool GetTextMetrics(IntPtr hdc, out Win32.TextMetric lptm);

		// Token: 0x060007B8 RID: 1976
		[DllImport("user32.dll")]
		public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Win32.Point pptDst, ref Win32.Size psize, IntPtr hdcSrc, ref Win32.Point pptSrc, int crKey, ref Win32.BlendFunction pblend, int dwFlags);

		// Token: 0x060007B9 RID: 1977 RVA: 0x0001AEF4 File Offset: 0x000190F4
		public static void UpdateLayeredWindowHelper(Control control, Bitmap bmp)
		{
			IntPtr dc = Win32.GetDC(IntPtr.Zero);
			Win32.Point point = new Win32.Point(control.Left, control.Top);
			Win32.Size size = new Win32.Size(bmp.Width, bmp.Height);
			IntPtr intPtr = Win32.CreateCompatibleDC(IntPtr.Zero);
			IntPtr hbitmap = bmp.GetHbitmap(Color.Black);
			Win32.SelectObject(intPtr, hbitmap);
			Win32.Point point2 = new Win32.Point(0, 0);
			Win32.BlendFunction blendFunction = default(Win32.BlendFunction);
			blendFunction.BlendOp = 0;
			blendFunction.BlendFlags = 0;
			blendFunction.SourceConstantAlpha = byte.MaxValue;
			blendFunction.AlphaFormat = 1;
			Win32.UpdateLayeredWindow(control.Handle, dc, ref point, ref size, intPtr, ref point2, 0, ref blendFunction, 2);
			Win32.DeleteObject(hbitmap);
			Win32.DeleteDC(intPtr);
			Win32.ReleaseDC(IntPtr.Zero, dc);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0001AFCC File Offset: 0x000191CC
		public static string GetUserNameEx(Win32.EXTENDED_NAME_FORMAT NameFormat)
		{
			string result = null;
			IntPtr intPtr = Marshal.AllocHGlobal(512);
			uint num = 256U;
			bool flag = Win32.GetUserNameExW(NameFormat, intPtr, ref num) != 0;
			if (flag)
			{
				result = Marshal.PtrToStringUni(intPtr);
			}
			Marshal.FreeHGlobal(intPtr);
			return result;
		}

		// Token: 0x060007BB RID: 1979
		[DllImport("secur32.dll")]
		public static extern int GetUserNameExW(Win32.EXTENDED_NAME_FORMAT NameFormat, IntPtr lpNameBuffer, ref uint nSize);

		// Token: 0x04000305 RID: 773
		public const int CS_DROPSHADOW = 131072;

		// Token: 0x04000306 RID: 774
		public const int WM_SETREDRAW = 11;

		// Token: 0x04000307 RID: 775
		public const int WM_ERASEBKGND = 20;

		// Token: 0x04000308 RID: 776
		public const int WM_COPYDATA = 74;

		// Token: 0x04000309 RID: 777
		public const int WM_NOTIFY = 78;

		// Token: 0x0400030A RID: 778
		public const int WM_NCACTIVATE = 134;

		// Token: 0x0400030B RID: 779
		public const int WM_GETDLGCODE = 135;

		// Token: 0x0400030C RID: 780
		public const int WM_NCMOUSEMOVE = 160;

		// Token: 0x0400030D RID: 781
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x0400030E RID: 782
		public const int WM_NCLBUTTONUP = 162;

		// Token: 0x0400030F RID: 783
		public const int WM_NCLBUTTONDBLCLK = 163;

		// Token: 0x04000310 RID: 784
		public const int WM_NCRBUTTONDOWN = 164;

		// Token: 0x04000311 RID: 785
		public const int WM_NCRBUTTONUP = 165;

		// Token: 0x04000312 RID: 786
		public const int WM_NCRBUTTONDBLCLK = 166;

		// Token: 0x04000313 RID: 787
		public const int WM_NCMBUTTONDOWN = 167;

		// Token: 0x04000314 RID: 788
		public const int WM_NCMBUTTONUP = 168;

		// Token: 0x04000315 RID: 789
		public const int WM_NCMBUTTONDBLCLK = 169;

		// Token: 0x04000316 RID: 790
		public const int WM_NCXBUTTONDOWN = 171;

		// Token: 0x04000317 RID: 791
		public const int WM_NCXBUTTONUP = 172;

		// Token: 0x04000318 RID: 792
		public const int WM_NCXBUTTONDBLCLK = 173;

		// Token: 0x04000319 RID: 793
		public const int WM_KEYDOWN = 256;

		// Token: 0x0400031A RID: 794
		public const int WM_KEYUP = 257;

		// Token: 0x0400031B RID: 795
		public const int WM_CHAR = 258;

		// Token: 0x0400031C RID: 796
		public const int WM_DEADCHAR = 259;

		// Token: 0x0400031D RID: 797
		public const int WM_SYSKEYDOWN = 260;

		// Token: 0x0400031E RID: 798
		public const int WM_SYSKEYUP = 261;

		// Token: 0x0400031F RID: 799
		public const int WM_SYSCHAR = 262;

		// Token: 0x04000320 RID: 800
		public const int WM_SYSDEADCHAR = 263;

		// Token: 0x04000321 RID: 801
		public const int WM_COMMAND = 273;

		// Token: 0x04000322 RID: 802
		public const int WM_HSCROLL = 276;

		// Token: 0x04000323 RID: 803
		public const int WM_VSCROLL = 277;

		// Token: 0x04000324 RID: 804
		public const int WM_MOUSEMOVE = 512;

		// Token: 0x04000325 RID: 805
		public const int WM_LBUTTONDOWN = 513;

		// Token: 0x04000326 RID: 806
		public const int WM_LBUTTONUP = 514;

		// Token: 0x04000327 RID: 807
		public const int WM_LBUTTONDBLCLK = 515;

		// Token: 0x04000328 RID: 808
		public const int WM_RBUTTONDOWN = 516;

		// Token: 0x04000329 RID: 809
		public const int WM_RBUTTONUP = 517;

		// Token: 0x0400032A RID: 810
		public const int WM_RBUTTONDBLCLK = 518;

		// Token: 0x0400032B RID: 811
		public const int WM_MBUTTONDOWN = 519;

		// Token: 0x0400032C RID: 812
		public const int WM_MBUTTONUP = 520;

		// Token: 0x0400032D RID: 813
		public const int WM_MBUTTONDBLCLK = 521;

		// Token: 0x0400032E RID: 814
		public const int WM_MOUSEWHEEL = 522;

		// Token: 0x0400032F RID: 815
		public const int WM_XBUTTONDOWN = 523;

		// Token: 0x04000330 RID: 816
		public const int WM_XBUTTONUP = 524;

		// Token: 0x04000331 RID: 817
		public const int WM_XBUTTONDBLCLK = 525;

		// Token: 0x04000332 RID: 818
		public const int WM_USER = 1024;

		// Token: 0x04000333 RID: 819
		public const int WF_REFLECT = 8192;

		// Token: 0x04000334 RID: 820
		public const int WM_REFLECT_NOTIFY = 8270;

		// Token: 0x04000335 RID: 821
		public const int WS_HSCROLL = 1048576;

		// Token: 0x04000336 RID: 822
		public const int WS_VSCROLL = 2097152;

		// Token: 0x04000337 RID: 823
		public const int WS_POPUP = -2147483648;

		// Token: 0x04000338 RID: 824
		public const int WS_EX_TOPMOST = 8;

		// Token: 0x04000339 RID: 825
		public const int WS_EX_TRANSPARENT = 32;

		// Token: 0x0400033A RID: 826
		public const int WS_EX_CLIENTEDGE = 512;

		// Token: 0x0400033B RID: 827
		public const int WS_EX_LAYERED = 524288;

		// Token: 0x0400033C RID: 828
		public const int WS_EX_NOACTIVATE = 134217728;

		// Token: 0x0400033D RID: 829
		public const int DLGC_WANTALLKEYS = 4;

		// Token: 0x0400033E RID: 830
		public const int TBS_ENABLESELRANGE = 32;

		// Token: 0x0400033F RID: 831
		public const int TBM_SETSEL = 1034;

		// Token: 0x04000340 RID: 832
		public const int TBM_SETSELSTART = 1035;

		// Token: 0x04000341 RID: 833
		public const int TBM_SETSELEND = 1036;

		// Token: 0x04000342 RID: 834
		public const int TBM_GETCHANNELRECT = 1050;

		// Token: 0x04000343 RID: 835
		public const int LVS_EX_BORDERSELECT = 32768;

		// Token: 0x04000344 RID: 836
		public const int LVM_FIRST = 4096;

		// Token: 0x04000345 RID: 837
		public const int LVM_GETITEMSPACING = 4147;

		// Token: 0x04000346 RID: 838
		public const int LVM_SETICONSPACING = 4149;

		// Token: 0x04000347 RID: 839
		public const int LVM_SETEXTENDEDLISTVIEWSTYLE = 4150;

		// Token: 0x04000348 RID: 840
		public const int LVN_FIRST = -100;

		// Token: 0x04000349 RID: 841
		public const int LVN_BEGINSCROLL = -180;

		// Token: 0x0400034A RID: 842
		public const int LVN_ENDSCROLL = -181;

		// Token: 0x0400034B RID: 843
		public const int TV_FIRST = 4352;

		// Token: 0x0400034C RID: 844
		public const int TVM_SETINSERTMARK = 4378;

		// Token: 0x0400034D RID: 845
		public const int SW_SHOWNA = 8;

		// Token: 0x0400034E RID: 846
		public const int VK_CTRL = 17;

		// Token: 0x0400034F RID: 847
		public const int VK_LEFT = 37;

		// Token: 0x04000350 RID: 848
		public const int VK_UP = 38;

		// Token: 0x04000351 RID: 849
		public const int VK_RIGHT = 39;

		// Token: 0x04000352 RID: 850
		public const int VK_DOWN = 40;

		// Token: 0x04000353 RID: 851
		public const int VK_LSHIFT = 160;

		// Token: 0x04000354 RID: 852
		public const int VK_RSHIFT = 161;

		// Token: 0x04000355 RID: 853
		public const int CBN_DROPDOWN = 7;

		// Token: 0x04000356 RID: 854
		public const int CBN_CLOSEUP = 8;

		// Token: 0x04000357 RID: 855
		public const int RDW_INVALIDATE = 1;

		// Token: 0x04000358 RID: 856
		public const int RDW_FRAME = 1024;

		// Token: 0x04000359 RID: 857
		public const int GWL_STYLE = -16;

		// Token: 0x0400035A RID: 858
		public const int GWL_EXSTYLE = -20;

		// Token: 0x0400035B RID: 859
		public const int SWP_NOSIZE = 1;

		// Token: 0x0400035C RID: 860
		public const int SWP_NOMOVE = 2;

		// Token: 0x0400035D RID: 861
		public const int SWP_NOZORDER = 4;

		// Token: 0x0400035E RID: 862
		public const int SWP_FRAMECHANGED = 32;

		// Token: 0x0400035F RID: 863
		public const int MAPVK_VK_TO_CHAR = 2;

		// Token: 0x04000360 RID: 864
		public const int SB_HORZ = 0;

		// Token: 0x04000361 RID: 865
		public const int SB_VERT = 1;

		// Token: 0x04000362 RID: 866
		public const int SB_CTL = 2;

		// Token: 0x04000363 RID: 867
		public const int SB_LINEUP = 0;

		// Token: 0x04000364 RID: 868
		public const int SB_LINEDOWN = 1;

		// Token: 0x04000365 RID: 869
		public const int SB_PAGEUP = 2;

		// Token: 0x04000366 RID: 870
		public const int SB_PAGEDOWN = 3;

		// Token: 0x04000367 RID: 871
		public const int SB_THUMBPOSITION = 4;

		// Token: 0x04000368 RID: 872
		public const int SB_THUMBTRACK = 5;

		// Token: 0x04000369 RID: 873
		public const int SB_TOP = 6;

		// Token: 0x0400036A RID: 874
		public const int SB_BOTTOM = 7;

		// Token: 0x0400036B RID: 875
		public const int SB_ENDSCROLL = 8;

		// Token: 0x0400036C RID: 876
		public const int SIF_RANGE = 1;

		// Token: 0x0400036D RID: 877
		public const int SIF_PAGE = 2;

		// Token: 0x0400036E RID: 878
		public const int SIF_POS = 4;

		// Token: 0x0400036F RID: 879
		public const int SIF_DISABLENOSCROLL = 8;

		// Token: 0x04000370 RID: 880
		public const int SIF_TRACKPOS = 16;

		// Token: 0x04000371 RID: 881
		public const int SIF_ALL = 31;

		// Token: 0x04000372 RID: 882
		public const int SW_INVALIDATE = 2;

		// Token: 0x04000373 RID: 883
		public const int DT_TOP = 0;

		// Token: 0x04000374 RID: 884
		public const int DT_LEFT = 0;

		// Token: 0x04000375 RID: 885
		public const int DT_CENTER = 1;

		// Token: 0x04000376 RID: 886
		public const int DT_RIGHT = 2;

		// Token: 0x04000377 RID: 887
		public const int DT_VCENTER = 4;

		// Token: 0x04000378 RID: 888
		public const int DT_BOTTOM = 8;

		// Token: 0x04000379 RID: 889
		public const int DT_WORDBREAK = 16;

		// Token: 0x0400037A RID: 890
		public const int DT_SINGLELINE = 32;

		// Token: 0x0400037B RID: 891
		public const int DT_EXPANDTABS = 64;

		// Token: 0x0400037C RID: 892
		public const int DT_TABSTOP = 128;

		// Token: 0x0400037D RID: 893
		public const int DT_NOCLIP = 256;

		// Token: 0x0400037E RID: 894
		public const int DT_EXTERNALLEADING = 512;

		// Token: 0x0400037F RID: 895
		public const int DT_CALCRECT = 1024;

		// Token: 0x04000380 RID: 896
		public const int DT_NOPREFIX = 2048;

		// Token: 0x04000381 RID: 897
		public const int DT_INTERNAL = 4096;

		// Token: 0x04000382 RID: 898
		public const int PS_SOLID = 0;

		// Token: 0x04000383 RID: 899
		public const int PS_DASH = 1;

		// Token: 0x04000384 RID: 900
		public const int PS_DOT = 2;

		// Token: 0x04000385 RID: 901
		public const int PS_DASHDOT = 3;

		// Token: 0x04000386 RID: 902
		public const int PS_DASHDOTDOT = 4;

		// Token: 0x04000387 RID: 903
		public const int PS_NULL = 5;

		// Token: 0x04000388 RID: 904
		public const int PS_INSIDEFRAME = 6;

		// Token: 0x04000389 RID: 905
		public const byte AC_SRC_OVER = 0;

		// Token: 0x0400038A RID: 906
		public const byte AC_SRC_ALPHA = 1;

		// Token: 0x0400038B RID: 907
		public const int ULW_COLORKEY = 1;

		// Token: 0x0400038C RID: 908
		public const int ULW_ALPHA = 2;

		// Token: 0x0400038D RID: 909
		public const int ULW_OPAQUE = 4;

		// Token: 0x020000C9 RID: 201
		public struct Point
		{
			// Token: 0x060007BD RID: 1981 RVA: 0x0001B015 File Offset: 0x00019215
			public Point(int x, int y)
			{
				this.x = x;
				this.y = y;
			}

			// Token: 0x0400038E RID: 910
			public int x;

			// Token: 0x0400038F RID: 911
			public int y;
		}

		// Token: 0x020000CA RID: 202
		public struct Size
		{
			// Token: 0x060007BE RID: 1982 RVA: 0x0001B025 File Offset: 0x00019225
			public Size(int cx, int cy)
			{
				this.cx = cx;
				this.cy = cy;
			}

			// Token: 0x04000390 RID: 912
			public int cx;

			// Token: 0x04000391 RID: 913
			public int cy;
		}

		// Token: 0x020000CB RID: 203
		public struct Rect
		{
			// Token: 0x060007BF RID: 1983 RVA: 0x0001B035 File Offset: 0x00019235
			public Rect(int left, int top, int width, int height)
			{
				this.left = left;
				this.top = top;
				this.right = left + width;
				this.bottom = top + height;
			}

			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x060007C0 RID: 1984 RVA: 0x0001B058 File Offset: 0x00019258
			public int Width
			{
				get
				{
					return this.right - this.left;
				}
			}

			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x060007C1 RID: 1985 RVA: 0x0001B067 File Offset: 0x00019267
			public int Height
			{
				get
				{
					return this.bottom - this.top;
				}
			}

			// Token: 0x04000392 RID: 914
			public int left;

			// Token: 0x04000393 RID: 915
			public int top;

			// Token: 0x04000394 RID: 916
			public int right;

			// Token: 0x04000395 RID: 917
			public int bottom;
		}

		// Token: 0x020000CC RID: 204
		public struct Message
		{
			// Token: 0x04000396 RID: 918
			public IntPtr hWnd;

			// Token: 0x04000397 RID: 919
			public int message;

			// Token: 0x04000398 RID: 920
			public IntPtr wParam;

			// Token: 0x04000399 RID: 921
			public IntPtr lParam;

			// Token: 0x0400039A RID: 922
			public int time;

			// Token: 0x0400039B RID: 923
			public Win32.Point pt;
		}

		// Token: 0x020000CD RID: 205
		public struct COPYDATASTRUCT
		{
			// Token: 0x0400039C RID: 924
			public IntPtr dwData;

			// Token: 0x0400039D RID: 925
			public int cbData;

			// Token: 0x0400039E RID: 926
			public IntPtr lpData;
		}

		// Token: 0x020000CE RID: 206
		public struct NMHDR
		{
			// Token: 0x0400039F RID: 927
			public IntPtr hwndFrom;

			// Token: 0x040003A0 RID: 928
			public IntPtr idFrom;

			// Token: 0x040003A1 RID: 929
			public int code;
		}

		// Token: 0x020000CF RID: 207
		// (Invoke) Token: 0x060007C3 RID: 1987
		public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

		// Token: 0x020000D0 RID: 208
		[StructLayout(LayoutKind.Sequential)]
		public class ScrollInfo
		{
			// Token: 0x040003A2 RID: 930
			public int cbSize = Marshal.SizeOf(typeof(Win32.ScrollInfo));

			// Token: 0x040003A3 RID: 931
			public int fMask;

			// Token: 0x040003A4 RID: 932
			public int nMin;

			// Token: 0x040003A5 RID: 933
			public int nMax;

			// Token: 0x040003A6 RID: 934
			public int nPage;

			// Token: 0x040003A7 RID: 935
			public int nPos;

			// Token: 0x040003A8 RID: 936
			public int nTrackPos;
		}

		// Token: 0x020000D1 RID: 209
		[StructLayout(LayoutKind.Sequential)]
		public class DrawTextParams
		{
			// Token: 0x040003A9 RID: 937
			public int cbSize = Marshal.SizeOf(typeof(Win32.DrawTextParams));

			// Token: 0x040003AA RID: 938
			public int iTabLength;

			// Token: 0x040003AB RID: 939
			public int iLeftMargin;

			// Token: 0x040003AC RID: 940
			public int iRightMargin;

			// Token: 0x040003AD RID: 941
			public uint uiLengthDrawn;
		}

		// Token: 0x020000D2 RID: 210
		public struct ABC
		{
			// Token: 0x040003AE RID: 942
			public int A;

			// Token: 0x040003AF RID: 943
			public int B;

			// Token: 0x040003B0 RID: 944
			public int C;
		}

		// Token: 0x020000D3 RID: 211
		public struct TextMetric
		{
			// Token: 0x040003B1 RID: 945
			public int tmHeight;

			// Token: 0x040003B2 RID: 946
			public int tmAscent;

			// Token: 0x040003B3 RID: 947
			public int tmDescent;

			// Token: 0x040003B4 RID: 948
			public int tmInternalLeading;

			// Token: 0x040003B5 RID: 949
			public int tmExternalLeading;

			// Token: 0x040003B6 RID: 950
			public int tmAveCharWidth;

			// Token: 0x040003B7 RID: 951
			public int tmMaxCharWidth;

			// Token: 0x040003B8 RID: 952
			public int tmWeight;

			// Token: 0x040003B9 RID: 953
			public int tmOverhang;

			// Token: 0x040003BA RID: 954
			public int tmDigitizedAspectX;

			// Token: 0x040003BB RID: 955
			public int tmDigitizedAspectY;

			// Token: 0x040003BC RID: 956
			public char tmFirstChar;

			// Token: 0x040003BD RID: 957
			public char tmLastChar;

			// Token: 0x040003BE RID: 958
			public char tmDefaultChar;

			// Token: 0x040003BF RID: 959
			public char tmBreakChar;

			// Token: 0x040003C0 RID: 960
			public byte tmItalic;

			// Token: 0x040003C1 RID: 961
			public byte tmUnderlined;

			// Token: 0x040003C2 RID: 962
			public byte tmStruckOut;

			// Token: 0x040003C3 RID: 963
			public byte tmPitchAndFamily;

			// Token: 0x040003C4 RID: 964
			public byte tmCharSet;
		}

		// Token: 0x020000D4 RID: 212
		public struct BlendFunction
		{
			// Token: 0x040003C5 RID: 965
			public byte BlendOp;

			// Token: 0x040003C6 RID: 966
			public byte BlendFlags;

			// Token: 0x040003C7 RID: 967
			public byte SourceConstantAlpha;

			// Token: 0x040003C8 RID: 968
			public byte AlphaFormat;
		}

		// Token: 0x020000D5 RID: 213
		public enum EXTENDED_NAME_FORMAT
		{
			// Token: 0x040003CA RID: 970
			NameUnknown,
			// Token: 0x040003CB RID: 971
			NameFullyQualifiedDN,
			// Token: 0x040003CC RID: 972
			NameSamCompatible,
			// Token: 0x040003CD RID: 973
			NameDisplay,
			// Token: 0x040003CE RID: 974
			NameUniqueId = 6,
			// Token: 0x040003CF RID: 975
			NameCanonical,
			// Token: 0x040003D0 RID: 976
			NameUserPrincipal,
			// Token: 0x040003D1 RID: 977
			NameCanonicalEx,
			// Token: 0x040003D2 RID: 978
			NameServicePrincipal,
			// Token: 0x040003D3 RID: 979
			NameDnsDomain = 12
		}
	}
}

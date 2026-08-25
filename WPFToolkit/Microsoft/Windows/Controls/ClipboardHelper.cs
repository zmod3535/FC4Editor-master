using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;

namespace Microsoft.Windows.Controls
{
	// Token: 0x02000051 RID: 81
	internal static class ClipboardHelper
	{
		// Token: 0x060006A3 RID: 1699 RVA: 0x0001B444 File Offset: 0x00019644
		internal static void FormatCell(object cellValue, bool firstCell, bool lastCell, StringBuilder sb, string format)
		{
			bool flag = string.Equals(format, DataFormats.CommaSeparatedValue, StringComparison.OrdinalIgnoreCase);
			if (!flag && !string.Equals(format, DataFormats.Text, StringComparison.OrdinalIgnoreCase) && !string.Equals(format, DataFormats.UnicodeText, StringComparison.OrdinalIgnoreCase))
			{
				if (string.Equals(format, DataFormats.Html, StringComparison.OrdinalIgnoreCase))
				{
					if (firstCell)
					{
						sb.Append("<TR>");
					}
					sb.Append("<TD>");
					if (cellValue != null)
					{
						ClipboardHelper.FormatPlainTextAsHtml(cellValue.ToString(), new StringWriter(sb, CultureInfo.CurrentCulture));
					}
					else
					{
						sb.Append("&nbsp;");
					}
					sb.Append("</TD>");
					if (lastCell)
					{
						sb.Append("</TR>");
					}
				}
				return;
			}
			if (cellValue != null)
			{
				bool flag2 = false;
				int length = sb.Length;
				ClipboardHelper.FormatPlainText(cellValue.ToString(), flag, new StringWriter(sb, CultureInfo.CurrentCulture), ref flag2);
				if (flag2)
				{
					sb.Insert(length, '"');
				}
			}
			if (lastCell)
			{
				sb.Append('\r');
				sb.Append('\n');
				return;
			}
			sb.Append(flag ? ',' : '\t');
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0001B548 File Offset: 0x00019748
		internal static void GetClipboardContentForHtml(StringBuilder content)
		{
			content.Insert(0, "<TABLE>");
			content.Append("</TABLE>");
			int num = 135 + content.Length;
			int num2 = num + 36;
			string value = string.Format(CultureInfo.InvariantCulture, "Version:1.0\r\nStartHTML:00000097\r\nEndHTML:{0}\r\nStartFragment:00000133\r\nEndFragment:{1}\r\n", new object[]
			{
				num2.ToString("00000000", CultureInfo.InvariantCulture),
				num.ToString("00000000", CultureInfo.InvariantCulture)
			}) + "<HTML>\r\n<BODY>\r\n<!--StartFragment-->";
			content.Insert(0, value);
			content.Append("\r\n<!--EndFragment-->\r\n</BODY>\r\n</HTML>");
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0001B5E0 File Offset: 0x000197E0
		private static void FormatPlainText(string s, bool csv, TextWriter output, ref bool escapeApplied)
		{
			if (s != null)
			{
				int length = s.Length;
				for (int i = 0; i < length; i++)
				{
					char c = s[i];
					char c2 = c;
					if (c2 != '\t')
					{
						if (c2 != '"')
						{
							if (c2 != ',')
							{
								output.Write(c);
							}
							else
							{
								if (csv)
								{
									escapeApplied = true;
								}
								output.Write(',');
							}
						}
						else if (csv)
						{
							output.Write("\"\"");
							escapeApplied = true;
						}
						else
						{
							output.Write('"');
						}
					}
					else if (!csv)
					{
						output.Write(' ');
					}
					else
					{
						output.Write('\t');
					}
				}
				if (escapeApplied)
				{
					output.Write('"');
				}
			}
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x0001B678 File Offset: 0x00019878
		private static void FormatPlainTextAsHtml(string s, TextWriter output)
		{
			if (s == null)
			{
				return;
			}
			int length = s.Length;
			char c = '\0';
			int i = 0;
			while (i < length)
			{
				char c2 = s[i];
				char c3 = c2;
				if (c3 <= '\r')
				{
					if (c3 != '\n')
					{
						if (c3 != '\r')
						{
							goto IL_D2;
						}
					}
					else
					{
						output.Write("<br>");
					}
				}
				else
				{
					switch (c3)
					{
					case ' ':
						if (c == ' ')
						{
							output.Write("&nbsp;");
						}
						else
						{
							output.Write(c2);
						}
						break;
					case '!':
						goto IL_D2;
					case '"':
						output.Write("&quot;");
						break;
					default:
						if (c3 != '&')
						{
							switch (c3)
							{
							case '<':
								output.Write("&lt;");
								break;
							case '=':
								goto IL_D2;
							case '>':
								output.Write("&gt;");
								break;
							default:
								goto IL_D2;
							}
						}
						else
						{
							output.Write("&amp;");
						}
						break;
					}
				}
				IL_113:
				c = c2;
				i++;
				continue;
				IL_D2:
				if (c2 >= '\u00a0' && c2 < 'Ā')
				{
					output.Write("&#");
					int num = (int)c2;
					output.Write(num.ToString(NumberFormatInfo.InvariantInfo));
					output.Write(';');
					goto IL_113;
				}
				output.Write(c2);
				goto IL_113;
			}
		}

		// Token: 0x040001DA RID: 474
		private const string DATAGRIDVIEW_htmlPrefix = "Version:1.0\r\nStartHTML:00000097\r\nEndHTML:{0}\r\nStartFragment:00000133\r\nEndFragment:{1}\r\n";

		// Token: 0x040001DB RID: 475
		private const string DATAGRIDVIEW_htmlStartFragment = "<HTML>\r\n<BODY>\r\n<!--StartFragment-->";

		// Token: 0x040001DC RID: 476
		private const string DATAGRIDVIEW_htmlEndFragment = "\r\n<!--EndFragment-->\r\n</BODY>\r\n</HTML>";
	}
}

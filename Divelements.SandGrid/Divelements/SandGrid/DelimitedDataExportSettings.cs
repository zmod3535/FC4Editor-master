using System;

namespace Divelements.SandGrid
{
	// Token: 0x02000086 RID: 134
	public class DelimitedDataExportSettings
	{
		// Token: 0x06000657 RID: 1623 RVA: 0x000219E0 File Offset: 0x000209E0
		static DelimitedDataExportSettings()
		{
			DelimitedDataExportSettings.Csv.x4c3e8680a15658ef = ',';
			DelimitedDataExportSettings.Csv.xce547b5922bc2f8c = '"';
			DelimitedDataExportSettings.Csv.xfcc98f16cf821a87 = false;
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x00021A18 File Offset: 0x00020A18
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x00021A20 File Offset: 0x00020A20
		public char Delimiter
		{
			get
			{
				return this.x4c3e8680a15658ef;
			}
			set
			{
				this.x4c3e8680a15658ef = value;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x00021A2C File Offset: 0x00020A2C
		// (set) Token: 0x0600065C RID: 1628 RVA: 0x00021A34 File Offset: 0x00020A34
		public char StringQualifier
		{
			get
			{
				return this.xce547b5922bc2f8c;
			}
			set
			{
				this.xce547b5922bc2f8c = value;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x00021A40 File Offset: 0x00020A40
		// (set) Token: 0x0600065E RID: 1630 RVA: 0x00021A48 File Offset: 0x00020A48
		public bool UseStringQualifierWhenValueIsString
		{
			get
			{
				return this.xfcc98f16cf821a87;
			}
			set
			{
				this.xfcc98f16cf821a87 = value;
			}
		}

		// Token: 0x0400028D RID: 653
		public static readonly DelimitedDataExportSettings Csv = new DelimitedDataExportSettings();

		// Token: 0x0400028E RID: 654
		private char x4c3e8680a15658ef;

		// Token: 0x0400028F RID: 655
		private char xce547b5922bc2f8c;

		// Token: 0x04000290 RID: 656
		private bool xfcc98f16cf821a87;
	}
}

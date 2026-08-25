using System;
using System.ComponentModel;

namespace Divelements.SandGrid
{
	// Token: 0x0200002C RID: 44
	public abstract class TypedGridColumn : GridColumn
	{
		// Token: 0x06000449 RID: 1097 RVA: 0x00018748 File Offset: 0x00017748
		public TypedGridColumn(string text, int width) : base(text, width)
		{
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00018760 File Offset: 0x00017760
		public TypedGridColumn()
		{
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00018774 File Offset: 0x00017774
		protected override object FormatValue(object value, Type desiredType)
		{
			if (value == null)
			{
				return base.Grid.NullRepresentation;
			}
			if (desiredType == typeof(string))
			{
				return string.Format(this.DataFormatString, value);
			}
			return base.FormatValue(value, desiredType);
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x0600044C RID: 1100 RVA: 0x000187A8 File Offset: 0x000177A8
		public string DataTypeName
		{
			get
			{
				return this.DataType.Name;
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x000187B8 File Offset: 0x000177B8
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x000187C0 File Offset: 0x000177C0
		[Description("The string with which to format data in cells.")]
		[DefaultValue("{0}")]
		[Category("Appearance")]
		public string DataFormatString
		{
			get
			{
				return this.x4d98b9df58e0ca87;
			}
			set
			{
				this.x4d98b9df58e0ca87 = value;
				base.MeasureNeeded();
			}
		}

		// Token: 0x0400014C RID: 332
		private string x4d98b9df58e0ca87 = "{0}";
	}
}

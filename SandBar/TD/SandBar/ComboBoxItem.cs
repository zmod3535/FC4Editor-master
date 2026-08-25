using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;

namespace TD.SandBar
{
	// Token: 0x02000066 RID: 102
	[ToolboxItem(false)]
	[TypeConverter(typeof(xe82e926721c67317))]
	public class ComboBoxItem : ControlContainerItem
	{
		// Token: 0x06000508 RID: 1288 RVA: 0x0001B618 File Offset: 0x0001A618
		public ComboBoxItem() : base(new FlatComboBox())
		{
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0001B628 File Offset: 0x0001A628
		protected ComboBoxItem(ComboBox comboBox) : base(comboBox)
		{
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0001B634 File Offset: 0x0001A634
		public override ToolbarItemBase CloneItem()
		{
			ComboBoxItem comboBoxItem = (ComboBoxItem)base.CloneItem();
			comboBoxItem.DefaultText = this.DefaultText;
			comboBoxItem.DropDownStyle = this.DropDownStyle;
			return comboBoxItem;
		}

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600050B RID: 1291 RVA: 0x0001B668 File Offset: 0x0001A668
		public ComboBox ComboBox
		{
			get
			{
				return (ComboBox)base.ContainedControl;
			}
		}

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x0001B678 File Offset: 0x0001A678
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x0001B6A0 File Offset: 0x0001A6A0
		[Localizable(true)]
		[DefaultValue("")]
		[Category("Appearance")]
		[Description("Provides a textual hint as to the type of data to enter, before any is entered.")]
		public string DefaultText
		{
			get
			{
				FlatComboBox flatComboBox = this.ComboBox as FlatComboBox;
				if (flatComboBox != null)
				{
					return flatComboBox.DefaultText;
				}
				return string.Empty;
			}
			set
			{
				FlatComboBox flatComboBox = this.ComboBox as FlatComboBox;
				if (flatComboBox != null)
				{
					flatComboBox.DefaultText = value;
				}
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x0001B6C4 File Offset: 0x0001A6C4
		[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, Custom=null", typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Data")]
		[Description("The items in the combo box.")]
		public ComboBox.ObjectCollection Items
		{
			get
			{
				return this.ComboBox.Items;
			}
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600050F RID: 1295 RVA: 0x0001B6D4 File Offset: 0x0001A6D4
		// (set) Token: 0x06000510 RID: 1296 RVA: 0x0001B6E4 File Offset: 0x0001A6E4
		[DefaultValue(typeof(ComboBoxStyle), "DropDown")]
		[Description("Controls the appearance and functionality of the combo box.")]
		[Category("Appearance")]
		public ComboBoxStyle DropDownStyle
		{
			get
			{
				return this.ComboBox.DropDownStyle;
			}
			set
			{
				if (value == ComboBoxStyle.Simple)
				{
					throw new ArgumentException("This style is not supported for a hosted combo box.");
				}
				this.ComboBox.DropDownStyle = value;
			}
		}
	}
}

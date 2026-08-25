using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using Divelements.SandGrid.Specialized;

namespace Divelements.SandGrid
{
	// Token: 0x020000AC RID: 172
	internal class xd732e68b9b10f6f8 : TypeConverter
	{
		// Token: 0x060007CE RID: 1998 RVA: 0x00026168 File Offset: 0x00025168
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00026184 File Offset: 0x00025184
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != typeof(InstanceDescriptor) || !(value is GridRow))
			{
				return base.ConvertTo(context, culture, value, destinationType);
			}
			SingleCellRow singleCellRow = (SingleCellRow)value;
			bool flag = singleCellRow.NestedRows.Count != 0;
			bool flag2 = false;
			foreach (object obj in TypeDescriptor.GetProperties(value))
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
				if (propertyDescriptor.ShouldSerializeValue(value) && propertyDescriptor.SerializationVisibility == DesignerSerializationVisibility.Visible && propertyDescriptor.Name != "Text" && propertyDescriptor.Name != "Image")
				{
					flag2 = true;
				}
			}
			ConstructorInfo constructor = singleCellRow.GetType().GetConstructor(new Type[]
			{
				typeof(string),
				typeof(Image)
			});
			if (!flag && !flag2 && constructor != null)
			{
				return new InstanceDescriptor(constructor, new object[]
				{
					singleCellRow.Text,
					singleCellRow.Image
				}, true);
			}
			return new InstanceDescriptor(singleCellRow.GetType().GetConstructor(Type.EmptyTypes), new object[0], false);
		}
	}
}

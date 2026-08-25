using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Divelements.SandGrid
{
	// Token: 0x020000AB RID: 171
	internal class x573084d7e82604d4 : TypeConverter
	{
		// Token: 0x060007CB RID: 1995 RVA: 0x00025FC0 File Offset: 0x00024FC0
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00025FDC File Offset: 0x00024FDC
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != typeof(InstanceDescriptor) || !(value is GridRow))
			{
				return base.ConvertTo(context, culture, value, destinationType);
			}
			GridRow gridRow = (GridRow)value;
			bool flag = gridRow.Cells.Count != 0;
			bool flag2 = gridRow.NestedRows.Count != 0;
			bool flag3 = false;
			foreach (object obj in TypeDescriptor.GetProperties(value))
			{
				PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
				if (propertyDescriptor.ShouldSerializeValue(value) && propertyDescriptor.SerializationVisibility == DesignerSerializationVisibility.Visible)
				{
					flag3 = true;
				}
			}
			ConstructorInfo constructor = gridRow.GetType().GetConstructor(new Type[]
			{
				typeof(GridCell[])
			});
			if (!flag2 && !flag3 && flag && constructor != null)
			{
				GridCell[] array = new GridCell[gridRow.Cells.Count];
				gridRow.Cells.CopyTo(array, 0);
				return new InstanceDescriptor(constructor, new object[]
				{
					array
				}, true);
			}
			if (!flag2 && !flag3 && !flag)
			{
				return new InstanceDescriptor(typeof(GridRow).GetConstructor(Type.EmptyTypes), new object[0], true);
			}
			return new InstanceDescriptor(gridRow.GetType().GetConstructor(Type.EmptyTypes), new object[0], false);
		}
	}
}

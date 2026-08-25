using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Divelements.SandGrid
{
	// Token: 0x020000A9 RID: 169
	internal class x933c789ad966b48f : TypeConverter
	{
		// Token: 0x060007C4 RID: 1988 RVA: 0x00025BF4 File Offset: 0x00024BF4
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00025C10 File Offset: 0x00024C10
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != typeof(InstanceDescriptor) || !(value is GridCell))
			{
				return base.ConvertTo(context, culture, value, destinationType);
			}
			GridCell gridCell = (GridCell)value;
			Type type = value.GetType();
			Type propertyType = type.GetProperty("Value", BindingFlags.Instance | BindingFlags.Public).PropertyType;
			if (x933c789ad966b48f.CellHasNonDefaultProperties(gridCell))
			{
				return new InstanceDescriptor(type.GetConstructor(new Type[0]), new object[0], false);
			}
			if (gridCell.IsNull)
			{
				return new InstanceDescriptor(type.GetConstructor(new Type[0]), new object[0]);
			}
			object value2 = value.GetType().GetProperty("Value", BindingFlags.Instance | BindingFlags.Public).GetValue(value, null);
			return new InstanceDescriptor(type.GetConstructor(new Type[]
			{
				propertyType
			}), new object[]
			{
				value2
			});
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00025CEC File Offset: 0x00024CEC
		internal static bool CellHasNonDefaultProperties(GridCell cell)
		{
			return cell.ShouldSerializeFont() || cell.ForeColor != SystemColors.WindowText || cell.Image != null;
		}
	}
}

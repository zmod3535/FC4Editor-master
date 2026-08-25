using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace TD.SandDock
{
	// Token: 0x0200006A RID: 106
	internal class x807757bdf074f1b8 : TypeConverter
	{
		// Token: 0x060005E0 RID: 1504 RVA: 0x0002BFE8 File Offset: 0x0002AFE8
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0002C004 File Offset: 0x0002B004
		private Type MakeArrayType(Type firstType)
		{
			return firstType.Assembly.GetType(firstType.FullName + "[]");
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0002C024 File Offset: 0x0002B024
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != null)
			{
				if (destinationType == typeof(InstanceDescriptor))
				{
					if (false)
					{
						goto IL_10D;
					}
					IL_24:
					Type type;
					if (value.GetType().Name == "SplitLayoutSystem")
					{
						type = value.GetType();
						goto IL_10D;
					}
					IL_B7:
					if (false)
					{
						goto IL_15C;
					}
					goto IL_17A;
					IL_10D:
					Type baseType = type.BaseType;
					MemberInfo constructor = type.GetConstructor(new Type[]
					{
						typeof(SizeF),
						typeof(Orientation),
						this.MakeArrayType(baseType)
					});
					PropertyInfo property = type.GetProperty("LayoutSystems", BindingFlags.Instance | BindingFlags.Public);
					ICollection collection = (ICollection)property.GetValue(value, null);
					object[] array = (object[])Activator.CreateInstance(this.MakeArrayType(baseType), new object[]
					{
						collection.Count
					});
					collection.CopyTo(array, 0);
					if (false)
					{
						goto IL_15C;
					}
					if (15 == 0)
					{
						goto IL_24;
					}
					PropertyInfo property2 = type.GetProperty("WorkingSize", BindingFlags.Instance | BindingFlags.Public);
					SizeF sizeF = (SizeF)property2.GetValue(value, null);
					PropertyInfo property3 = type.GetProperty("SplitMode", BindingFlags.Instance | BindingFlags.Public);
					Orientation orientation = (Orientation)property3.GetValue(value, null);
					if (false)
					{
						goto IL_B7;
					}
					return new InstanceDescriptor(constructor, new object[]
					{
						sizeF,
						orientation,
						array
					});
				}
				IL_17A:
				return base.ConvertTo(context, culture, value, destinationType);
			}
			IL_15C:
			throw new ArgumentNullException();
		}
	}
}

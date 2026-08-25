using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Divelements.SandGrid
{
	// Token: 0x020000AA RID: 170
	internal class x2e534b8fab38a541 : TypeConverter
	{
		// Token: 0x060007C8 RID: 1992 RVA: 0x00025D20 File Offset: 0x00024D20
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00025D3C File Offset: 0x00024D3C
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				bool flag2;
				bool flag3;
				bool flag = (flag2 ? 1U : 0U) - (flag3 ? 1U : 0U) < 0U;
				if (!flag)
				{
					if (!(value is GridCell))
					{
						goto IL_246;
					}
					GridCell gridCell = (GridCell)value;
					bool flag4;
					ConstructorInfo constructor;
					ConstructorInfo constructor2;
					ConstructorInfo constructor3;
					do
					{
						flag4 = false;
						flag3 = false;
						flag2 = false;
						foreach (object obj in TypeDescriptor.GetProperties(value))
						{
							PropertyDescriptor propertyDescriptor = (PropertyDescriptor)obj;
							if (propertyDescriptor.ShouldSerializeValue(value) && propertyDescriptor.SerializationVisibility == DesignerSerializationVisibility.Visible)
							{
								string name;
								if ((name = propertyDescriptor.Name) != null)
								{
									if (name == "Text")
									{
										flag4 = true;
										continue;
									}
									if (name == "Image")
									{
										flag3 = true;
										continue;
									}
								}
								flag2 = true;
							}
						}
						constructor = gridCell.GetType().GetConstructor(new Type[]
						{
							typeof(string)
						});
						constructor2 = gridCell.GetType().GetConstructor(new Type[]
						{
							typeof(Image)
						});
						constructor3 = gridCell.GetType().GetConstructor(new Type[]
						{
							typeof(string),
							typeof(Image)
						});
						if (!flag4 || !flag3)
						{
							goto IL_1F5;
						}
					}
					while (((flag4 ? 1U : 0U) | 2U) == 0U);
					if (!flag2 && constructor3 != null)
					{
						return new InstanceDescriptor(constructor3, new object[]
						{
							gridCell.Text,
							gridCell.Image
						});
					}
					IL_1F5:
					if (!flag4 && flag3 && !flag2 && constructor2 != null)
					{
						return new InstanceDescriptor(constructor2, new object[]
						{
							gridCell.Image
						});
					}
					if (flag4 && !flag3 && !flag2 && constructor != null)
					{
						if (-2 != 0)
						{
							return new InstanceDescriptor(constructor, new object[]
							{
								gridCell.Text
							});
						}
					}
					else if (flag4 || flag3)
					{
						goto IL_29;
					}
					if (!flag2)
					{
						return new InstanceDescriptor(value.GetType().GetConstructor(Type.EmptyTypes), new object[0], true);
					}
				}
				IL_29:
				return new InstanceDescriptor(value.GetType().GetConstructor(Type.EmptyTypes), new object[0], false);
			}
			IL_246:
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace TD.SandDock
{
	// Token: 0x02000069 RID: 105
	internal class x44c2ba9761cb4dd2 : TypeConverter
	{
		// Token: 0x060005DC RID: 1500 RVA: 0x0002BD84 File Offset: 0x0002AD84
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x0002BDA0 File Offset: 0x0002ADA0
		private Type MakeArrayType(Type firstType)
		{
			return firstType.Assembly.GetType(firstType.FullName + "[]");
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0002BDC0 File Offset: 0x0002ADC0
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != null)
			{
				for (;;)
				{
					IL_8E:
					if (destinationType == typeof(InstanceDescriptor))
					{
						goto IL_41;
					}
					if (4 != 0)
					{
						goto Block_9;
					}
					goto IL_0C;
					do
					{
						IL_19D:
						Type type = value.GetType();
						type.Assembly.GetType("TD.SandDock.LayoutSystemBase");
						Type type2 = type.Assembly.GetType("TD.SandDock.DockControl");
						if (-1 != 0)
						{
							goto Block_14;
						}
						if (4 != 0)
						{
							goto IL_8E;
						}
						if (-2 == 0)
						{
							goto IL_5D;
						}
					}
					while (false);
					IL_41:
					if (!(value.GetType().Name == "ControlLayoutSystem"))
					{
						goto IL_0C;
					}
					goto IL_19D;
					IL_5D:
					if (-1 == 0)
					{
						goto IL_41;
					}
					if (!false)
					{
						goto IL_18;
					}
					IL_0C:
					if (4 == 0)
					{
						goto IL_5D;
					}
					IL_18:
					if (value.GetType().Name == "DocumentLayoutSystem")
					{
						goto IL_19D;
					}
					if (2147483647 != 0)
					{
						goto IL_AB;
					}
					if (false)
					{
						goto IL_5D;
					}
					break;
				}
				IL_66:
				ConstructorInfo constructor;
				SizeF sizeF;
				object[] array;
				object value2;
				return new InstanceDescriptor(constructor, new object[]
				{
					sizeF,
					array,
					value2
				});
				Block_9:
				goto IL_205;
				IL_AB:
				if (false)
				{
					goto IL_1D6;
				}
				goto IL_205;
				Block_14:
				PropertyInfo property3;
				for (;;)
				{
					Type type;
					Type type2;
					ICollection collection;
					if (!false)
					{
						constructor = type.GetConstructor(new Type[]
						{
							typeof(SizeF),
							this.MakeArrayType(type2),
							type2
						});
						PropertyInfo property = type.GetProperty("Controls", BindingFlags.Instance | BindingFlags.Public);
						collection = (ICollection)property.GetValue(value, null);
					}
					array = (object[])Activator.CreateInstance(this.MakeArrayType(type2), new object[]
					{
						collection.Count
					});
					collection.CopyTo(array, 0);
					PropertyInfo property2 = type.GetProperty("WorkingSize", BindingFlags.Instance | BindingFlags.Public);
					if (255 != 0)
					{
						if (false)
						{
							break;
						}
						sizeF = (SizeF)property2.GetValue(value, null);
						property3 = type.GetProperty("SelectedControl", BindingFlags.Instance | BindingFlags.Public);
						if (2147483647 != 0)
						{
							break;
						}
						if (15 != 0)
						{
							goto IL_1D6;
						}
					}
				}
				value2 = property3.GetValue(value, null);
				goto IL_66;
				IL_205:
				return base.ConvertTo(context, culture, value, destinationType);
			}
			IL_1D6:
			throw new ArgumentNullException();
		}
	}
}

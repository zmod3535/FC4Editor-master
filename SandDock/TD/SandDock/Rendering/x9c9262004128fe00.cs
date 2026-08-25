using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace TD.SandDock.Rendering
{
	// Token: 0x02000071 RID: 113
	internal class x9c9262004128fe00 : TypeConverter
	{
		// Token: 0x0600068F RID: 1679 RVA: 0x00030F1C File Offset: 0x0002FF1C
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				if (2 != 0)
				{
				}
				return true;
			}
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00030F4C File Offset: 0x0002FF4C
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				if (!(value is string))
				{
					return value.ToString();
				}
				return value;
			}
			else
			{
				if (destinationType != typeof(InstanceDescriptor))
				{
					return base.ConvertTo(context, culture, value, destinationType);
				}
				ConstructorInfo constructor = value.GetType().GetConstructor(Type.EmptyTypes);
				return new InstanceDescriptor(constructor, new object[0], true);
			}
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00030FB8 File Offset: 0x0002FFB8
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				string a;
				if ((a = (string)value) != null)
				{
					IL_7B:
					while (!(a == "Everett"))
					{
						while (!(a == "Office 2003"))
						{
							if (a == "Whidbey")
							{
								return new WhidbeyRenderer();
							}
							if (!false)
							{
								if (a == "Milborne")
								{
									return new MilborneRenderer();
								}
								if (a == "Office 2007")
								{
									return new Office2007Renderer();
								}
								goto IL_20;
							}
							else if (false)
							{
								goto IL_7B;
							}
						}
						return new Office2003Renderer();
					}
					return new EverettRenderer();
				}
				IL_20:
				return null;
			}
			return base.ConvertFrom(context, culture, value);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00031068 File Offset: 0x00030068
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00031084 File Offset: 0x00030084
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00031088 File Offset: 0x00030088
		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0003108C File Offset: 0x0003008C
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			ArrayList arrayList = new ArrayList();
			for (;;)
			{
				if (context == null)
				{
					goto IL_2B;
				}
				if (-2147483648 != 0)
				{
					goto IL_71;
				}
				goto IL_52;
				IL_64:
				if (false)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				goto IL_71;
				IL_2B:
				arrayList.Add("Everett");
				arrayList.Add("Office 2003");
				goto IL_64;
				IL_55:
				if (2147483647 != 0)
				{
					goto IL_2B;
				}
				goto IL_45;
				IL_52:
				if (false || false)
				{
					goto IL_55;
				}
				if (false)
				{
					goto IL_64;
				}
				goto IL_2B;
				IL_45:
				if (!(context.Instance is DockContainer))
				{
					goto IL_52;
				}
				IL_74:
				arrayList.Add("(default)");
				goto IL_55;
				IL_71:
				if (false)
				{
					goto IL_74;
				}
				goto IL_45;
			}
			arrayList.Add("Whidbey");
			arrayList.Add("Office 2007");
			return new TypeConverter.StandardValuesCollection(arrayList);
		}
	}
}

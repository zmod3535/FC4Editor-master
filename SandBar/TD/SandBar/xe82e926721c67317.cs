using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace TD.SandBar
{
	// Token: 0x02000071 RID: 113
	internal class xe82e926721c67317 : TypeConverter
	{
		// Token: 0x06000576 RID: 1398 RVA: 0x0001E358 File Offset: 0x0001D358
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0001E374 File Offset: 0x0001D374
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(InstanceDescriptor))
			{
				ConstructorInfo constructor = value.GetType().GetConstructor(Type.EmptyTypes);
				return new InstanceDescriptor(constructor, null, false);
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}

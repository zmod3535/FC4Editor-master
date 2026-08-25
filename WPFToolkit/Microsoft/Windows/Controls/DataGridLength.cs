using System;
using System.ComponentModel;
using System.Globalization;
using MS.Internal;

namespace Microsoft.Windows.Controls
{
	// Token: 0x0200005C RID: 92
	[TypeConverter(typeof(DataGridLengthConverter))]
	public struct DataGridLength : IEquatable<DataGridLength>
	{
		// Token: 0x06000720 RID: 1824 RVA: 0x0001DFFE File Offset: 0x0001C1FE
		public DataGridLength(double pixels)
		{
			this = new DataGridLength(pixels, DataGridLengthUnitType.Pixel);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0001E008 File Offset: 0x0001C208
		public DataGridLength(double value, DataGridLengthUnitType type)
		{
			this = new DataGridLength(value, type, (type == DataGridLengthUnitType.Pixel) ? value : double.NaN, (type == DataGridLengthUnitType.Pixel) ? value : double.NaN);
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0001E034 File Offset: 0x0001C234
		public DataGridLength(double value, DataGridLengthUnitType type, double desiredValue, double displayValue)
		{
			if (DoubleUtil.IsNaN(value) || double.IsInfinity(value))
			{
				throw new ArgumentException(SR.Get(SRID.DataGridLength_Infinity), "value");
			}
			if (type != DataGridLengthUnitType.Auto && type != DataGridLengthUnitType.Pixel && type != DataGridLengthUnitType.Star && type != DataGridLengthUnitType.SizeToCells && type != DataGridLengthUnitType.SizeToHeader)
			{
				throw new ArgumentException(SR.Get(SRID.DataGridLength_InvalidType), "type");
			}
			if (double.IsInfinity(desiredValue))
			{
				throw new ArgumentException(SR.Get(SRID.DataGridLength_Infinity), "desiredValue");
			}
			if (double.IsInfinity(displayValue))
			{
				throw new ArgumentException(SR.Get(SRID.DataGridLength_Infinity), "displayValue");
			}
			this._unitValue = ((type == DataGridLengthUnitType.Auto) ? 1.0 : value);
			this._unitType = type;
			this._desiredValue = desiredValue;
			this._displayValue = displayValue;
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0001E0F4 File Offset: 0x0001C2F4
		public static bool operator ==(DataGridLength gl1, DataGridLength gl2)
		{
			return gl1.UnitType == gl2.UnitType && gl1.Value == gl2.Value && gl1.DesiredValue == gl2.DesiredValue && gl1.DisplayValue == gl2.DisplayValue;
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0001E144 File Offset: 0x0001C344
		public static bool operator !=(DataGridLength gl1, DataGridLength gl2)
		{
			return gl1.UnitType != gl2.UnitType || gl1.Value != gl2.Value || gl1.DesiredValue != gl2.DesiredValue || gl1.DisplayValue != gl2.DisplayValue;
		}

		// Token: 0x06000725 RID: 1829 RVA: 0x0001E198 File Offset: 0x0001C398
		public override bool Equals(object obj)
		{
			if (obj is DataGridLength)
			{
				DataGridLength gl = (DataGridLength)obj;
				return this == gl;
			}
			return false;
		}

		// Token: 0x06000726 RID: 1830 RVA: 0x0001E1C2 File Offset: 0x0001C3C2
		public bool Equals(DataGridLength other)
		{
			return this == other;
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0001E1D0 File Offset: 0x0001C3D0
		public override int GetHashCode()
		{
			return (int)((int)this._unitValue + this._unitType + (int)this._desiredValue + (int)this._displayValue);
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x0001E1F0 File Offset: 0x0001C3F0
		public bool IsAbsolute
		{
			get
			{
				return this._unitType == DataGridLengthUnitType.Pixel;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x0001E1FB File Offset: 0x0001C3FB
		public bool IsAuto
		{
			get
			{
				return this._unitType == DataGridLengthUnitType.Auto;
			}
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x0001E206 File Offset: 0x0001C406
		public bool IsStar
		{
			get
			{
				return this._unitType == DataGridLengthUnitType.Star;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x0600072B RID: 1835 RVA: 0x0001E211 File Offset: 0x0001C411
		public bool IsSizeToCells
		{
			get
			{
				return this._unitType == DataGridLengthUnitType.SizeToCells;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600072C RID: 1836 RVA: 0x0001E21C File Offset: 0x0001C41C
		public bool IsSizeToHeader
		{
			get
			{
				return this._unitType == DataGridLengthUnitType.SizeToHeader;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x0001E227 File Offset: 0x0001C427
		public double Value
		{
			get
			{
				if (this._unitType != DataGridLengthUnitType.Auto)
				{
					return this._unitValue;
				}
				return 1.0;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600072E RID: 1838 RVA: 0x0001E241 File Offset: 0x0001C441
		public DataGridLengthUnitType UnitType
		{
			get
			{
				return this._unitType;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x0001E249 File Offset: 0x0001C449
		public double DesiredValue
		{
			get
			{
				return this._desiredValue;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x06000730 RID: 1840 RVA: 0x0001E251 File Offset: 0x0001C451
		public double DisplayValue
		{
			get
			{
				return this._displayValue;
			}
		}

		// Token: 0x06000731 RID: 1841 RVA: 0x0001E259 File Offset: 0x0001C459
		public override string ToString()
		{
			return DataGridLengthConverter.ConvertToString(this, CultureInfo.InvariantCulture);
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000732 RID: 1842 RVA: 0x0001E26B File Offset: 0x0001C46B
		public static DataGridLength Auto
		{
			get
			{
				return DataGridLength._auto;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000733 RID: 1843 RVA: 0x0001E272 File Offset: 0x0001C472
		public static DataGridLength SizeToCells
		{
			get
			{
				return DataGridLength._sizeToCells;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x0001E279 File Offset: 0x0001C479
		public static DataGridLength SizeToHeader
		{
			get
			{
				return DataGridLength._sizeToHeader;
			}
		}

		// Token: 0x06000735 RID: 1845 RVA: 0x0001E280 File Offset: 0x0001C480
		public static implicit operator DataGridLength(double value)
		{
			return new DataGridLength(value);
		}

		// Token: 0x04000212 RID: 530
		private const double AutoValue = 1.0;

		// Token: 0x04000213 RID: 531
		private double _unitValue;

		// Token: 0x04000214 RID: 532
		private DataGridLengthUnitType _unitType;

		// Token: 0x04000215 RID: 533
		private double _desiredValue;

		// Token: 0x04000216 RID: 534
		private double _displayValue;

		// Token: 0x04000217 RID: 535
		private static readonly DataGridLength _auto = new DataGridLength(1.0, DataGridLengthUnitType.Auto, 0.0, 0.0);

		// Token: 0x04000218 RID: 536
		private static readonly DataGridLength _sizeToCells = new DataGridLength(1.0, DataGridLengthUnitType.SizeToCells, 0.0, 0.0);

		// Token: 0x04000219 RID: 537
		private static readonly DataGridLength _sizeToHeader = new DataGridLength(1.0, DataGridLengthUnitType.SizeToHeader, 0.0, 0.0);
	}
}

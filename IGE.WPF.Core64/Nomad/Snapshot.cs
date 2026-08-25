using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace IGE.Nomad
{
	// Token: 0x02000103 RID: 259
	internal struct Snapshot
	{
		// Token: 0x0600091B RID: 2331 RVA: 0x0001E4A0 File Offset: 0x0001C6A0
		public static BitmapSource GetImage()
		{
			BitmapSource result = null;
			if (EditorDocument.IsSnapshotSet)
			{
				IntPtr imageInfo = Binding.FCE_Snapshot_Create();
				IntPtr intPtr;
				uint num;
				uint num2;
				Binding.FCE_Snapshot_GetData(imageInfo, out intPtr, out num, out num2);
				if (intPtr != IntPtr.Zero && num > 0U && num2 > 0U)
				{
					result = BitmapSource.Create((int)num, (int)num2, 96.0, 96.0, PixelFormats.Bgra32, null, intPtr, (int)(4U * num * num2), (int)(4U * num));
				}
				Binding.FCE_Snapshot_Destroy(imageInfo);
			}
			return result;
		}
	}
}

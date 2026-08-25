using System;

namespace TD.SandBar
{
	// Token: 0x0200004E RID: 78
	internal class xd552f4634d304df2
	{
		// Token: 0x060003CD RID: 973 RVA: 0x00013B0C File Offset: 0x00012B0C
		public static void xf0e1044ac09df441(PopupMenu xcbf78b15dd820156, TopLevelMenuItemBase.MenuAnimation x95be56bdc2cd6bd1)
		{
			xcbf78b15dd820156.x833319a7a503e226 = true;
			switch (x95be56bdc2cd6bd1)
			{
			case TopLevelMenuItemBase.MenuAnimation.Fade:
				xd552f4634d304df2.xc1b495afa7d510a4(xcbf78b15dd820156);
				break;
			case TopLevelMenuItemBase.MenuAnimation.Slide:
			case TopLevelMenuItemBase.MenuAnimation.Unfold:
				xd552f4634d304df2.x17d08bd5d321e952(xcbf78b15dd820156, x95be56bdc2cd6bd1 == TopLevelMenuItemBase.MenuAnimation.Unfold);
				break;
			}
			xcbf78b15dd820156.x833319a7a503e226 = false;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00013B58 File Offset: 0x00012B58
		private static void x17d08bd5d321e952(PopupMenu xcbf78b15dd820156, bool x6f2dcd0e9ffe2394)
		{
			x443cc432acaadb1d.AnimateWindowFlags animateWindowFlags = x443cc432acaadb1d.AnimateWindowFlags.AW_SLIDE;
			switch (xcbf78b15dd820156.MenuItem.MenuDirection)
			{
			case MenuProjection.Top:
				animateWindowFlags |= x443cc432acaadb1d.AnimateWindowFlags.AW_VER_NEGATIVE;
				if (x6f2dcd0e9ffe2394)
				{
					animateWindowFlags |= (xcbf78b15dd820156.Host.RightToLeft ? x443cc432acaadb1d.AnimateWindowFlags.AW_HOR_NEGATIVE : x443cc432acaadb1d.AnimateWindowFlags.AW_HOR_POSITIVE);
					goto IL_7C;
				}
				goto IL_7C;
			case MenuProjection.Left:
				animateWindowFlags |= x443cc432acaadb1d.AnimateWindowFlags.AW_HOR_NEGATIVE;
				if (x6f2dcd0e9ffe2394)
				{
					animateWindowFlags |= x443cc432acaadb1d.AnimateWindowFlags.AW_VER_POSITIVE;
					goto IL_7C;
				}
				goto IL_7C;
			case MenuProjection.Right:
				animateWindowFlags |= x443cc432acaadb1d.AnimateWindowFlags.AW_HOR_POSITIVE;
				if (x6f2dcd0e9ffe2394)
				{
					animateWindowFlags |= x443cc432acaadb1d.AnimateWindowFlags.AW_VER_POSITIVE;
					goto IL_7C;
				}
				goto IL_7C;
			}
			animateWindowFlags |= x443cc432acaadb1d.AnimateWindowFlags.AW_VER_POSITIVE;
			if (x6f2dcd0e9ffe2394)
			{
				animateWindowFlags |= (xcbf78b15dd820156.Host.RightToLeft ? x443cc432acaadb1d.AnimateWindowFlags.AW_HOR_NEGATIVE : x443cc432acaadb1d.AnimateWindowFlags.AW_HOR_POSITIVE);
			}
			IL_7C:
			x443cc432acaadb1d.AnimateWindow(xcbf78b15dd820156.Handle, 200, animateWindowFlags);
		}

		// Token: 0x060003CF RID: 975 RVA: 0x00013BF4 File Offset: 0x00012BF4
		private static void xc1b495afa7d510a4(PopupMenu xcbf78b15dd820156)
		{
			x443cc432acaadb1d.AnimateWindowFlags flags = x443cc432acaadb1d.AnimateWindowFlags.AW_BLEND;
			x443cc432acaadb1d.AnimateWindow(xcbf78b15dd820156.Handle, 200, flags);
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00013C1C File Offset: 0x00012C1C
		public static TopLevelMenuItemBase.MenuAnimation x26618c6ae8a848ca(TopLevelMenuItemBase.MenuAnimation xae4f5ff1269207fe, bool x18e9566618ba9e93)
		{
			if (x18e9566618ba9e93)
			{
				return TopLevelMenuItemBase.MenuAnimation.None;
			}
			if (xae4f5ff1269207fe != TopLevelMenuItemBase.MenuAnimation.System)
			{
				return xae4f5ff1269207fe;
			}
			int num = 0;
			x443cc432acaadb1d.SystemParametersInfo(4098, 0, ref num, 0);
			if (num == 0)
			{
				return TopLevelMenuItemBase.MenuAnimation.None;
			}
			int num2 = 0;
			x443cc432acaadb1d.SystemParametersInfo(4114, 0, ref num2, 0);
			if (num2 != 1)
			{
				return TopLevelMenuItemBase.MenuAnimation.Slide;
			}
			return TopLevelMenuItemBase.MenuAnimation.Fade;
		}
	}
}

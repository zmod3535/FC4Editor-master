using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
	// Token: 0x0200006D RID: 109
	public class Office2007Renderer : RendererBase
	{
		// Token: 0x06000625 RID: 1573 RVA: 0x0002D54C File Offset: 0x0002C54C
		public Office2007Renderer(Office2007ColorScheme colorScheme)
		{
			this.ColorScheme = colorScheme;
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0002D564 File Offset: 0x0002C564
		public Office2007Renderer() : this(Office2007ColorScheme.Blue)
		{
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x0002D570 File Offset: 0x0002C570
		// (set) Token: 0x06000628 RID: 1576 RVA: 0x0002D578 File Offset: 0x0002C578
		public ColorBlend DocumentSelectedTabBackground
		{
			get
			{
				return this.x55f5ad59d4c9fe0a;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x55f5ad59d4c9fe0a = value;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x0002D590 File Offset: 0x0002C590
		// (set) Token: 0x0600062A RID: 1578 RVA: 0x0002D598 File Offset: 0x0002C598
		public ColorBlend DocumentHotTabBackground
		{
			get
			{
				return this.x642be9cb364d5c7e;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x642be9cb364d5c7e = value;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x0002D5B0 File Offset: 0x0002C5B0
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x0002D5B8 File Offset: 0x0002C5B8
		public ColorBlend DocumentNormalTabBackground
		{
			get
			{
				return this.x854213a69311962a;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x854213a69311962a = value;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x0002D5D0 File Offset: 0x0002C5D0
		// (set) Token: 0x0600062E RID: 1582 RVA: 0x0002D5D8 File Offset: 0x0002C5D8
		public Color DocumentHotTabInnerBorder
		{
			get
			{
				return this.x216af2b9aa27b602;
			}
			set
			{
				this.x216af2b9aa27b602 = value;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x0002D5E4 File Offset: 0x0002C5E4
		// (set) Token: 0x06000630 RID: 1584 RVA: 0x0002D5EC File Offset: 0x0002C5EC
		public Color DocumentSelectedTabOuterBorder
		{
			get
			{
				return this.xac76de21a6c85f45;
			}
			set
			{
				this.xac76de21a6c85f45 = value;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x0002D5F8 File Offset: 0x0002C5F8
		// (set) Token: 0x06000632 RID: 1586 RVA: 0x0002D600 File Offset: 0x0002C600
		public Color DocumentSelectedTabInnerBorder
		{
			get
			{
				return this.xeedeb7a1ef6db2c5;
			}
			set
			{
				this.xeedeb7a1ef6db2c5 = value;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x0002D60C File Offset: 0x0002C60C
		// (set) Token: 0x06000634 RID: 1588 RVA: 0x0002D614 File Offset: 0x0002C614
		public Color DocumentHotTabOuterBorder
		{
			get
			{
				return this.xe339b39f12fe3a06;
			}
			set
			{
				this.xe339b39f12fe3a06 = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000635 RID: 1589 RVA: 0x0002D620 File Offset: 0x0002C620
		// (set) Token: 0x06000636 RID: 1590 RVA: 0x0002D628 File Offset: 0x0002C628
		public Color DocumentNormalTabInnerBorder
		{
			get
			{
				return this.x4457bc20e07c5384;
			}
			set
			{
				this.x4457bc20e07c5384 = value;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x0002D634 File Offset: 0x0002C634
		// (set) Token: 0x06000638 RID: 1592 RVA: 0x0002D63C File Offset: 0x0002C63C
		public Color DocumentNormalTabOuterBorder
		{
			get
			{
				return this.x5581066ec159efc6;
			}
			set
			{
				this.x5581066ec159efc6 = value;
			}
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x0002D648 File Offset: 0x0002C648
		// (set) Token: 0x0600063A RID: 1594 RVA: 0x0002D650 File Offset: 0x0002C650
		public Color DocumentStripBorder
		{
			get
			{
				return this.x9185f4f5b194140e;
			}
			set
			{
				this.x9185f4f5b194140e = value;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x0002D65C File Offset: 0x0002C65C
		// (set) Token: 0x0600063C RID: 1596 RVA: 0x0002D664 File Offset: 0x0002C664
		public ColorBlend DocumentContainerBackground
		{
			get
			{
				return this.xf62715f1e5e2cfba;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.xf62715f1e5e2cfba = value;
			}
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x0002D67C File Offset: 0x0002C67C
		// (set) Token: 0x0600063E RID: 1598 RVA: 0x0002D684 File Offset: 0x0002C684
		public ColorBlend CollapsedTabVerticalBackground
		{
			get
			{
				return this.x928270a1d0f072fb;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x928270a1d0f072fb = value;
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x0002D69C File Offset: 0x0002C69C
		// (set) Token: 0x06000640 RID: 1600 RVA: 0x0002D6A4 File Offset: 0x0002C6A4
		public ColorBlend CollapsedTabHorizontalBackground
		{
			get
			{
				return this.xf320905c8fa15baa;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.xf320905c8fa15baa = value;
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x0002D6BC File Offset: 0x0002C6BC
		// (set) Token: 0x06000642 RID: 1602 RVA: 0x0002D6C4 File Offset: 0x0002C6C4
		public Color CollapsedTabBorder
		{
			get
			{
				return this.x4c4dd6a647f58188;
			}
			set
			{
				this.x4c4dd6a647f58188 = value;
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x0002D6D0 File Offset: 0x0002C6D0
		// (set) Token: 0x06000644 RID: 1604 RVA: 0x0002D6D8 File Offset: 0x0002C6D8
		public ColorBlend ButtonHotBackground
		{
			get
			{
				return this.xea896c10e961df63;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.xea896c10e961df63 = value;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x0002D6F0 File Offset: 0x0002C6F0
		// (set) Token: 0x06000646 RID: 1606 RVA: 0x0002D6F8 File Offset: 0x0002C6F8
		public ColorBlend ButtonHotInnerBorder
		{
			get
			{
				return this.x267ad4ea8c519e4c;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x267ad4ea8c519e4c = value;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x0002D710 File Offset: 0x0002C710
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x0002D718 File Offset: 0x0002C718
		public ColorBlend ButtonHotOuterBorder
		{
			get
			{
				return this.x34b837871ba5992c;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x34b837871ba5992c = value;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x0002D730 File Offset: 0x0002C730
		// (set) Token: 0x0600064A RID: 1610 RVA: 0x0002D738 File Offset: 0x0002C738
		public ColorBlend ButtonPressedBackground
		{
			get
			{
				return this.x2f53a4063520f7b7;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x2f53a4063520f7b7 = value;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x0002D750 File Offset: 0x0002C750
		// (set) Token: 0x0600064C RID: 1612 RVA: 0x0002D758 File Offset: 0x0002C758
		public ColorBlend ButtonPressedInnerBorder
		{
			get
			{
				return this.xf654cd91b245064f;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.xf654cd91b245064f = value;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x0002D770 File Offset: 0x0002C770
		// (set) Token: 0x0600064E RID: 1614 RVA: 0x0002D778 File Offset: 0x0002C778
		public ColorBlend ButtonPressedOuterBorder
		{
			get
			{
				return this.xaeb413d4d357001d;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.xaeb413d4d357001d = value;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x0002D790 File Offset: 0x0002C790
		// (set) Token: 0x06000650 RID: 1616 RVA: 0x0002D798 File Offset: 0x0002C798
		public ColorBlend TabStripSelectedTabBorder
		{
			get
			{
				return this.xe127097a0a7bcea3;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.xe127097a0a7bcea3 = value;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x0002D7B0 File Offset: 0x0002C7B0
		// (set) Token: 0x06000652 RID: 1618 RVA: 0x0002D7B8 File Offset: 0x0002C7B8
		public ColorBlend TabStripSelectedTabBackground
		{
			get
			{
				return this.x7d4e8244c07128f3;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x7d4e8244c07128f3 = value;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x0002D7D0 File Offset: 0x0002C7D0
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x0002D7D8 File Offset: 0x0002C7D8
		public ColorBlend InactiveTitleBarBackground
		{
			get
			{
				return this.x6d145d34f6cf6305;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x6d145d34f6cf6305 = value;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x0002D7F0 File Offset: 0x0002C7F0
		// (set) Token: 0x06000656 RID: 1622 RVA: 0x0002D7F8 File Offset: 0x0002C7F8
		public ColorBlend ActiveTitleBarBackground
		{
			get
			{
				return this.x4603d08f845b431d;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.x4603d08f845b431d = value;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x0002D810 File Offset: 0x0002C810
		// (set) Token: 0x06000658 RID: 1624 RVA: 0x0002D818 File Offset: 0x0002C818
		public Color TabStripNormalTabForeground
		{
			get
			{
				return this.x311be0ac2a7ad6f7;
			}
			set
			{
				this.x311be0ac2a7ad6f7 = value;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x0002D824 File Offset: 0x0002C824
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x0002D82C File Offset: 0x0002C82C
		public Color TabStripInnerBorder
		{
			get
			{
				return this.xd86b7ed9f7ac5bcf;
			}
			set
			{
				this.xd86b7ed9f7ac5bcf = value;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x0002D838 File Offset: 0x0002C838
		// (set) Token: 0x0600065C RID: 1628 RVA: 0x0002D840 File Offset: 0x0002C840
		public Color TabStripOuterBorder
		{
			get
			{
				return this.xf03842e8454f12ef;
			}
			set
			{
				this.xf03842e8454f12ef = value;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x0002D84C File Offset: 0x0002C84C
		// (set) Token: 0x0600065E RID: 1630 RVA: 0x0002D854 File Offset: 0x0002C854
		public Color Background
		{
			get
			{
				return this.x21357dc320fa442f;
			}
			set
			{
				this.x21357dc320fa442f = value;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x0002D860 File Offset: 0x0002C860
		// (set) Token: 0x06000660 RID: 1632 RVA: 0x0002D868 File Offset: 0x0002C868
		public Color DockedWindowOuterBorder
		{
			get
			{
				return this.xf78d540f2ad4eefe;
			}
			set
			{
				this.xf78d540f2ad4eefe = value;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000661 RID: 1633 RVA: 0x0002D874 File Offset: 0x0002C874
		// (set) Token: 0x06000662 RID: 1634 RVA: 0x0002D87C File Offset: 0x0002C87C
		public Color DockedWindowInnerBorder
		{
			get
			{
				return this.x2a8ba610037adcf2;
			}
			set
			{
				this.x2a8ba610037adcf2 = value;
			}
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0002D888 File Offset: 0x0002C888
		private void x50aa48875b838a15()
		{
			this.x3a1fa93b40743331 = null;
			this.xc742aa5a0f350e7f = null;
			this.x6defba3d5d846e0d = null;
		}

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x0002D8A0 File Offset: 0x0002C8A0
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x0002D8A8 File Offset: 0x0002C8A8
		public override Size ImageSize
		{
			get
			{
				return base.ImageSize;
			}
			set
			{
				this.x50aa48875b838a15();
				base.ImageSize = value;
			}
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x0002D8B8 File Offset: 0x0002C8B8
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x0002D8C0 File Offset: 0x0002C8C0
		public Office2007ColorScheme ColorScheme
		{
			get
			{
				return this.x62a65b2c0f145432;
			}
			set
			{
				if (value != this.x62a65b2c0f145432)
				{
					if (!false)
					{
						this.x62a65b2c0f145432 = value;
						switch (this.x62a65b2c0f145432)
						{
						case Office2007ColorScheme.Blue:
							this.x02fed0907aa1493f();
							return;
						case Office2007ColorScheme.Silver:
							this.x6138edaa8ff675bc();
							return;
						case Office2007ColorScheme.Black:
							this.xfd737a986158d659();
							break;
						default:
							if (-1 != 0)
							{
								return;
							}
							break;
						}
					}
					return;
				}
			}
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0002D91C File Offset: 0x0002C91C
		private ColorBlend x427b83330cc91391(float[] x1692a49b2cba9274, Color[] xa70c7ccd3278240f)
		{
			ColorBlend colorBlend = new ColorBlend(x1692a49b2cba9274.Length);
			for (int i = 0; i < x1692a49b2cba9274.Length; i++)
			{
				do
				{
					colorBlend.Positions[i] = x1692a49b2cba9274[i];
					colorBlend.Colors[i] = xa70c7ccd3278240f[i];
				}
				while (4 == 0);
			}
			return colorBlend;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0002D978 File Offset: 0x0002C978
		private LinearGradientBrush xb9d757f2231cc2a8(Rectangle xda73fcb97c77d998, ColorBlend xdf5de570fec6a668, LinearGradientMode xa4aa8b4150b11435)
		{
			return new LinearGradientBrush(xda73fcb97c77d998, Color.Black, Color.White, xa4aa8b4150b11435)
			{
				InterpolationColors = xdf5de570fec6a668
			};
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0002D9A0 File Offset: 0x0002C9A0
		private void x02fed0907aa1493f()
		{
			this.Background = ColorTranslator.FromHtml("#BFDBFF");
			this.DockedWindowOuterBorder = ColorTranslator.FromHtml("#7596BF");
			if (2 != 0)
			{
				this.DockedWindowInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
				for (;;)
				{
					this.InactiveTitleBarBackground = this.x427b83330cc91391(new float[]
					{
						0f,
						0.35f,
						0.35f,
						1f
					}, new Color[]
					{
						ColorTranslator.FromHtml("#E4EBF6"),
						ColorTranslator.FromHtml("#D9E7F9"),
						ColorTranslator.FromHtml("#CADEF7"),
						ColorTranslator.FromHtml("#DBF4FE")
					});
					this.ActiveTitleBarBackground = this.x427b83330cc91391(new float[]
					{
						0f,
						0.7f,
						0.7f,
						1f
					}, new Color[]
					{
						ColorTranslator.FromHtml("#FFFCDA"),
						ColorTranslator.FromHtml("#FFE790"),
						ColorTranslator.FromHtml("#FFD74C"),
						ColorTranslator.FromHtml("#FFD346")
					});
					this.TabStripOuterBorder = ColorTranslator.FromHtml("#7596BF");
					this.TabStripInnerBorder = ColorTranslator.FromHtml("#E7EFF8");
					if (-2 != 0)
					{
						goto IL_79D;
					}
				}
			}
			IL_32C:
			this.CollapsedTabHorizontalBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.3f,
				0.3f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#F7FBFF"),
				ColorTranslator.FromHtml("#EEF5FB"),
				ColorTranslator.FromHtml("#E1EAF6"),
				ColorTranslator.FromHtml("#F7FBFF")
			});
			if (2 == 0)
			{
				goto IL_3B9;
			}
			this.CollapsedTabVerticalBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.3f,
				0.3f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#F7FBFF"),
				ColorTranslator.FromHtml("#EEF5FB"),
				ColorTranslator.FromHtml("#E1EAF6"),
				ColorTranslator.FromHtml("#F7FBFF")
			});
			if (255 != 0)
			{
				this.DocumentContainerBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.7f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#A3C2EA"),
					ColorTranslator.FromHtml("#567DB0"),
					ColorTranslator.FromHtml("#6591CD")
				});
				this.DocumentStripBorder = ColorTranslator.FromHtml("#678CBD");
				if (!false)
				{
					this.DocumentNormalTabOuterBorder = ColorTranslator.FromHtml("#6593CF");
					goto IL_3B9;
				}
				goto IL_79D;
			}
			IL_12A:
			this.DocumentHotTabOuterBorder = ColorTranslator.FromHtml("#6593CF");
			this.DocumentHotTabInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
			this.DocumentHotTabBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#E1EEFF"),
				ColorTranslator.FromHtml("#D7E8FF"),
				ColorTranslator.FromHtml("#AED2FF"),
				ColorTranslator.FromHtml("#BEDAFF")
			});
			this.DocumentSelectedTabOuterBorder = ColorTranslator.FromHtml("#95774A");
			if (!false)
			{
				if (false)
				{
					goto IL_70C;
				}
				this.DocumentSelectedTabInnerBorder = ColorTranslator.FromHtml("#CDB69C");
				this.DocumentSelectedTabBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.25f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#FFD19C"),
					ColorTranslator.FromHtml("#FFDBB3"),
					ColorTranslator.FromHtml("#FFFFFE")
				});
			}
			return;
			IL_3B9:
			this.DocumentNormalTabInnerBorder = ColorTranslator.FromHtml("#E3EFFF");
			if (false)
			{
				goto IL_502;
			}
			if (!false)
			{
				this.DocumentNormalTabBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.5f,
					0.5f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#BEDAFF"),
					ColorTranslator.FromHtml("#AED2FF"),
					ColorTranslator.FromHtml("#8FBCF6"),
					ColorTranslator.FromHtml("#98C4FD")
				});
				goto IL_12A;
			}
			return;
			IL_502:
			this.TabStripSelectedTabBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				0.3f,
				0.7f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#E1EAF6"),
				ColorTranslator.FromHtml("#CDFBFF"),
				ColorTranslator.FromHtml("#D0FBFF"),
				ColorTranslator.FromHtml("#F4F9FF")
			});
			this.TabStripNormalTabForeground = ColorTranslator.FromHtml("#15428B");
			this.ButtonHotOuterBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#DBCE99"),
				ColorTranslator.FromHtml("#B9A074"),
				ColorTranslator.FromHtml("#CBC3AA")
			});
			this.ButtonHotInnerBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#FFFFFB"),
				ColorTranslator.FromHtml("#FFF9E3"),
				ColorTranslator.FromHtml("#FFF2C9"),
				ColorTranslator.FromHtml("#FFFCDF")
			});
			this.ButtonHotBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#FFFCE6"),
				ColorTranslator.FromHtml("#FFECA3"),
				ColorTranslator.FromHtml("#FFD844"),
				ColorTranslator.FromHtml("#FFE47F")
			});
			IL_70C:
			this.ButtonPressedOuterBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#7B6645"),
				ColorTranslator.FromHtml("#7B6645")
			});
			this.ButtonPressedInnerBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				0.1f,
				0.6f,
				0.6f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#B2855C"),
				ColorTranslator.FromHtml("#F1B072"),
				ColorTranslator.FromHtml("#F1963B"),
				ColorTranslator.FromHtml("#ED7804"),
				ColorTranslator.FromHtml("#FDAD03")
			});
			this.ButtonPressedBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#F3A570"),
				ColorTranslator.FromHtml("#E57840"),
				ColorTranslator.FromHtml("#DE550A"),
				ColorTranslator.FromHtml("#FEA14E")
			});
			this.CollapsedTabBorder = ColorTranslator.FromHtml("#7596BF");
			goto IL_32C;
			IL_79D:
			this.TabStripSelectedTabBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.3f,
				0.3f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#F7FBFF"),
				ColorTranslator.FromHtml("#EEF5FB"),
				ColorTranslator.FromHtml("#E1EAF6"),
				ColorTranslator.FromHtml("#F7FBFF")
			});
			goto IL_502;
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x0002E2FC File Offset: 0x0002D2FC
		private void xfd737a986158d659()
		{
			this.Background = ColorTranslator.FromHtml("#535353");
			if (true)
			{
				this.DockedWindowOuterBorder = ColorTranslator.FromHtml("#8C8E8F");
				this.DockedWindowInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
				goto IL_82B;
			}
			do
			{
				IL_2BC:
				this.ButtonPressedBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.5f,
					0.5f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#F3A570"),
					ColorTranslator.FromHtml("#E57840"),
					ColorTranslator.FromHtml("#DE550A"),
					ColorTranslator.FromHtml("#FEA14E")
				});
				this.CollapsedTabBorder = ColorTranslator.FromHtml("#BEBEBE");
				if (false)
				{
					return;
				}
				do
				{
					this.CollapsedTabHorizontalBackground = this.x427b83330cc91391(new float[]
					{
						0f,
						0.3f,
						0.3f,
						1f
					}, new Color[]
					{
						ColorTranslator.FromHtml("#F0F0F0"),
						ColorTranslator.FromHtml("#E3E6E9"),
						ColorTranslator.FromHtml("#D6D9DE"),
						ColorTranslator.FromHtml("#F0F1F2")
					});
					this.CollapsedTabVerticalBackground = this.x427b83330cc91391(new float[]
					{
						0f,
						0.3f,
						0.3f,
						1f
					}, new Color[]
					{
						ColorTranslator.FromHtml("#F0F0F0"),
						ColorTranslator.FromHtml("#E3E6E9"),
						ColorTranslator.FromHtml("#D6D9DE"),
						ColorTranslator.FromHtml("#F0F1F2")
					});
				}
				while (15 == 0);
				if (false)
				{
					break;
				}
				this.DocumentContainerBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.7f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#4F4F4F"),
					ColorTranslator.FromHtml("#3B3B3B"),
					ColorTranslator.FromHtml("#0A0A0A")
				});
			}
			while (-1 == 0);
			this.DocumentStripBorder = ColorTranslator.FromHtml("#000000");
			this.DocumentNormalTabOuterBorder = ColorTranslator.FromHtml("#9199A4");
			if (4 != 0)
			{
				this.DocumentNormalTabInnerBorder = ColorTranslator.FromHtml("#F0F1F2");
				if (3 != 0)
				{
					this.DocumentNormalTabBackground = this.x427b83330cc91391(new float[]
					{
						0f,
						0.5f,
						0.5f,
						1f
					}, new Color[]
					{
						ColorTranslator.FromHtml("#DBDEE1"),
						ColorTranslator.FromHtml("#D3D6DB"),
						ColorTranslator.FromHtml("#BCC1C8"),
						ColorTranslator.FromHtml("#C5C9CF")
					});
					goto IL_150;
				}
				if (2147483647 != 0)
				{
					goto IL_82B;
				}
				if (4 == 0)
				{
					goto IL_493;
				}
				goto IL_716;
			}
			IL_C2:
			this.DocumentSelectedTabInnerBorder = ColorTranslator.FromHtml("#CDB69C");
			this.DocumentSelectedTabBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.25f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#FFD19C"),
				ColorTranslator.FromHtml("#FFDBB3"),
				ColorTranslator.FromHtml("#FFFFFE")
			});
			if (4 != 0)
			{
				return;
			}
			IL_150:
			this.DocumentHotTabOuterBorder = ColorTranslator.FromHtml("#616A76");
			if (255 != 0)
			{
				this.DocumentHotTabInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
				if (15 != 0)
				{
					this.DocumentHotTabBackground = this.x427b83330cc91391(new float[]
					{
						0f,
						0.5f,
						0.5f,
						1f
					}, new Color[]
					{
						ColorTranslator.FromHtml("#F2F2F3"),
						ColorTranslator.FromHtml("#F8F8F9"),
						ColorTranslator.FromHtml("#D3D6DB"),
						ColorTranslator.FromHtml("#DBDEE1")
					});
					this.DocumentSelectedTabOuterBorder = ColorTranslator.FromHtml("#3D3D3D");
					goto IL_C2;
				}
				goto IL_677;
			}
			return;
			IL_493:
			this.TabStripNormalTabForeground = ColorTranslator.FromHtml("#FFFFFF");
			this.ButtonHotOuterBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#DBCE99"),
				ColorTranslator.FromHtml("#B9A074"),
				ColorTranslator.FromHtml("#CBC3AA")
			});
			this.ButtonHotInnerBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#FFFFFB"),
				ColorTranslator.FromHtml("#FFF9E3"),
				ColorTranslator.FromHtml("#FFF2C9"),
				ColorTranslator.FromHtml("#FFFCDF")
			});
			this.ButtonHotBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#FFFCE6"),
				ColorTranslator.FromHtml("#FFECA3"),
				ColorTranslator.FromHtml("#FFD844"),
				ColorTranslator.FromHtml("#FFE47F")
			});
			this.ButtonPressedOuterBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#7B6645"),
				ColorTranslator.FromHtml("#7B6645")
			});
			IL_677:
			this.ButtonPressedInnerBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				0.1f,
				0.6f,
				0.6f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#B2855C"),
				ColorTranslator.FromHtml("#F1B072"),
				ColorTranslator.FromHtml("#F1963B"),
				ColorTranslator.FromHtml("#ED7804"),
				ColorTranslator.FromHtml("#FDAD03")
			});
			if (false)
			{
				goto IL_82B;
			}
			goto IL_93B;
			IL_716:
			this.TabStripInnerBorder = ColorTranslator.FromHtml("#D7DADF");
			this.TabStripSelectedTabBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.3f,
				0.3f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#F0F0F0"),
				ColorTranslator.FromHtml("#E3E6E9"),
				ColorTranslator.FromHtml("#D6D9DE"),
				ColorTranslator.FromHtml("#F0F1F2")
			});
			this.TabStripSelectedTabBorder = this.x427b83330cc91391(new float[]
			{
				0f,
				0.3f,
				0.7f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#D5DBDC"),
				ColorTranslator.FromHtml("#B8F6FC"),
				ColorTranslator.FromHtml("#B7F7FD"),
				ColorTranslator.FromHtml("#E8EDEF")
			});
			goto IL_493;
			IL_82B:
			this.InactiveTitleBarBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.35f,
				0.35f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#D7DADF"),
				ColorTranslator.FromHtml("#C1C6CF"),
				ColorTranslator.FromHtml("#B4BBC5"),
				ColorTranslator.FromHtml("#EBEBEB")
			});
			this.ActiveTitleBarBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.7f,
				0.7f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#FFFCDA"),
				ColorTranslator.FromHtml("#FFE790"),
				ColorTranslator.FromHtml("#FFD74C"),
				ColorTranslator.FromHtml("#FFD346")
			});
			this.TabStripOuterBorder = ColorTranslator.FromHtml("#BEBEBE");
			if (!false)
			{
				goto IL_716;
			}
			IL_93B:
			goto IL_2BC;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0002EC84 File Offset: 0x0002DC84
		private void x6138edaa8ff675bc()
		{
			this.Background = ColorTranslator.FromHtml("#D0D4DD");
			while (!false)
			{
				if (15 != 0)
				{
					this.DockedWindowOuterBorder = ColorTranslator.FromHtml("#BDBFC1");
					this.DockedWindowInnerBorder = ColorTranslator.FromHtml("#FFFFFF");
					this.InactiveTitleBarBackground = this.x427b83330cc91391(new float[]
					{
						0f,
						0.35f,
						0.35f,
						1f
					}, new Color[]
					{
						ColorTranslator.FromHtml("#F2F4F8"),
						ColorTranslator.FromHtml("#E1E6EE"),
						ColorTranslator.FromHtml("#D5DBE7"),
						ColorTranslator.FromHtml("#F9F9F9")
					});
					do
					{
						this.ActiveTitleBarBackground = this.x427b83330cc91391(new float[]
						{
							0f,
							0.7f,
							0.7f,
							1f
						}, new Color[]
						{
							ColorTranslator.FromHtml("#FFFCDA"),
							ColorTranslator.FromHtml("#FFE790"),
							ColorTranslator.FromHtml("#FFD74C"),
							ColorTranslator.FromHtml("#FFD346")
						});
						this.TabStripOuterBorder = ColorTranslator.FromHtml("#838383");
						this.TabStripInnerBorder = ColorTranslator.FromHtml("#F2F4F8");
						this.TabStripSelectedTabBackground = this.x427b83330cc91391(new float[]
						{
							0f,
							0.3f,
							0.3f,
							1f
						}, new Color[]
						{
							ColorTranslator.FromHtml("#FFFFFF"),
							ColorTranslator.FromHtml("#F7F6F8"),
							ColorTranslator.FromHtml("#EEF1F5"),
							ColorTranslator.FromHtml("#F2F7F9")
						});
						this.TabStripSelectedTabBorder = this.x427b83330cc91391(new float[]
						{
							0f,
							0.3f,
							0.7f,
							1f
						}, new Color[]
						{
							ColorTranslator.FromHtml("#EAEFF5"),
							ColorTranslator.FromHtml("#C1FAFF"),
							ColorTranslator.FromHtml("#C6FAFF"),
							ColorTranslator.FromHtml("#ECFAFB")
						});
						this.TabStripNormalTabForeground = ColorTranslator.FromHtml("#4C535C");
						if (!false)
						{
						}
						this.ButtonHotOuterBorder = this.x427b83330cc91391(new float[]
						{
							0f,
							0.5f,
							1f
						}, new Color[]
						{
							ColorTranslator.FromHtml("#DBCE99"),
							ColorTranslator.FromHtml("#B9A074"),
							ColorTranslator.FromHtml("#CBC3AA")
						});
						if (-1 == 0)
						{
							goto IL_7EA;
						}
					}
					while (-1 == 0);
					this.ButtonHotInnerBorder = this.x427b83330cc91391(new float[]
					{
						0f,
						0.5f,
						0.5f,
						1f
					}, new Color[]
					{
						ColorTranslator.FromHtml("#FFFFFB"),
						ColorTranslator.FromHtml("#FFF9E3"),
						ColorTranslator.FromHtml("#FFF2C9"),
						ColorTranslator.FromHtml("#FFFCDF")
					});
					this.ButtonHotBackground = this.x427b83330cc91391(new float[]
					{
						0f,
						0.5f,
						0.5f,
						1f
					}, new Color[]
					{
						ColorTranslator.FromHtml("#FFFCE6"),
						ColorTranslator.FromHtml("#FFECA3"),
						ColorTranslator.FromHtml("#FFD844"),
						ColorTranslator.FromHtml("#FFE47F")
					});
					goto IL_3B9;
				}
				goto IL_3B9;
				IL_7EA:
				if (3 == 0)
				{
					continue;
				}
				if (2147483647 == 0)
				{
					return;
				}
				this.CollapsedTabHorizontalBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.3f,
					0.3f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#FFFFFF"),
					ColorTranslator.FromHtml("#F7F6F8"),
					ColorTranslator.FromHtml("#EEF1F5"),
					ColorTranslator.FromHtml("#F2F7F9")
				});
				this.CollapsedTabVerticalBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.3f,
					0.3f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#FFFFFF"),
					ColorTranslator.FromHtml("#F7F6F8"),
					ColorTranslator.FromHtml("#EEF1F5"),
					ColorTranslator.FromHtml("#F2F7F9")
				});
				this.DocumentContainerBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.7f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#CCCFD8"),
					ColorTranslator.FromHtml("#BDC0C9"),
					ColorTranslator.FromHtml("#9B9FA6")
				});
				IL_153:
				if (!false)
				{
					this.DocumentStripBorder = ColorTranslator.FromHtml("#858585");
					this.DocumentNormalTabOuterBorder = ColorTranslator.FromHtml("#6F7074");
				}
				this.DocumentNormalTabInnerBorder = ColorTranslator.FromHtml("#EDF3F4");
				break;
				IL_3B9:
				this.ButtonPressedOuterBorder = this.x427b83330cc91391(new float[]
				{
					0f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#7B6645"),
					ColorTranslator.FromHtml("#7B6645")
				});
				this.ButtonPressedInnerBorder = this.x427b83330cc91391(new float[]
				{
					0f,
					0.1f,
					0.6f,
					0.6f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#B2855C"),
					ColorTranslator.FromHtml("#F1B072"),
					ColorTranslator.FromHtml("#F1963B"),
					ColorTranslator.FromHtml("#ED7804"),
					ColorTranslator.FromHtml("#FDAD03")
				});
				this.ButtonPressedBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.5f,
					0.5f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#F3A570"),
					ColorTranslator.FromHtml("#E57840"),
					ColorTranslator.FromHtml("#DE550A"),
					ColorTranslator.FromHtml("#FEA14E")
				});
				this.CollapsedTabBorder = ColorTranslator.FromHtml("#838383");
				goto IL_7EA;
			}
			this.DocumentNormalTabBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#DCE0E5"),
				ColorTranslator.FromHtml("#D8DDE2"),
				ColorTranslator.FromHtml("#B5BAC3"),
				ColorTranslator.FromHtml("#C6CBD1")
			});
			this.DocumentHotTabOuterBorder = ColorTranslator.FromHtml("#6F7074");
			this.DocumentHotTabInnerBorder = ColorTranslator.FromHtml("#EDF3F4");
			if (15 == 0)
			{
				goto IL_153;
			}
			this.DocumentHotTabBackground = this.x427b83330cc91391(new float[]
			{
				0f,
				0.5f,
				0.5f,
				1f
			}, new Color[]
			{
				ColorTranslator.FromHtml("#FBFBFB"),
				ColorTranslator.FromHtml("#F1F1F2"),
				ColorTranslator.FromHtml("#CFD3D6"),
				ColorTranslator.FromHtml("#DEE0E3")
			});
			this.DocumentSelectedTabOuterBorder = ColorTranslator.FromHtml("#95774A");
			if (4 != 0)
			{
				this.DocumentSelectedTabInnerBorder = ColorTranslator.FromHtml("#CDB69C");
				this.DocumentSelectedTabBackground = this.x427b83330cc91391(new float[]
				{
					0f,
					0.25f,
					1f
				}, new Color[]
				{
					ColorTranslator.FromHtml("#FFD19C"),
					ColorTranslator.FromHtml("#FFDBB3"),
					ColorTranslator.FromHtml("#FFFFFE")
				});
			}
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0002F5EC File Offset: 0x0002E5EC
		public override string ToString()
		{
			return "Office 2007";
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x0002F5F4 File Offset: 0x0002E5F4
		protected TextFormatFlags TextFormat
		{
			get
			{
				return this.xae3b2752a89e7464;
			}
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0002F5FC File Offset: 0x0002E5FC
		public override void StartRenderSession(HotkeyPrefix hotKeys)
		{
			this.xae3b2752a89e7464 = (TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPadding);
			if (-2 == 0 || hotKeys == HotkeyPrefix.None)
			{
				this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
				if (!false)
				{
					goto IL_28;
				}
			}
			if (hotKeys == HotkeyPrefix.Hide)
			{
				this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
			}
			IL_28:
			this.x03bb1ee2adad51ea++;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0002F660 File Offset: 0x0002E660
		public override void FinishRenderSession()
		{
			this.x03bb1ee2adad51ea = Math.Max(this.x03bb1ee2adad51ea - 1, 0);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0002F678 File Offset: 0x0002E678
		protected internal override void DrawControlClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
			using (Pen pen = new Pen(this.DockedWindowOuterBorder))
			{
				graphics.DrawLine(pen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
				graphics.DrawLine(pen, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
				graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
			}
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0002F730 File Offset: 0x0002E730
		protected internal override void DrawAutoHideBarBackground(Control container, Control autoHideBar, Graphics graphics, Rectangle bounds)
		{
			using (SolidBrush solidBrush = new SolidBrush(this.Background))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0002F77C File Offset: 0x0002E77C
		protected internal override void DrawDockContainerBackground(Graphics graphics, DockContainer container, Rectangle bounds)
		{
			if (bounds.Width > 0)
			{
				if (-1 != 0)
				{
					if (bounds.Height <= 0)
					{
						return;
					}
					if (false)
					{
						goto IL_59;
					}
					goto IL_42;
				}
				IL_17:
				xa811784015ed8842.x91433b5e99eb7cac(graphics, this.Background);
				if (-2147483648 != 0)
				{
					return;
				}
				if (255 != 0)
				{
					goto IL_7E;
				}
				IL_42:
				if (!(container is DocumentContainer))
				{
					goto IL_17;
				}
				IL_59:
				using (Brush brush = this.xb9d757f2231cc2a8(bounds, this.DocumentContainerBackground, LinearGradientMode.Vertical))
				{
					graphics.FillRectangle(brush, bounds);
					return;
				}
				IL_7E:
				goto IL_17;
			}
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0002F830 File Offset: 0x0002E830
		protected internal override void DrawSplitter(Control container, Control control, Graphics graphics, Rectangle bounds, Orientation orientation)
		{
			if (!(control is DocumentContainer))
			{
				using (SolidBrush solidBrush = new SolidBrush(this.Background))
				{
					graphics.FillRectangle(solidBrush, bounds);
				}
			}
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0002F884 File Offset: 0x0002E884
		protected internal override void DrawTitleBarBackground(Graphics graphics, Rectangle bounds, bool focused)
		{
			using (Pen pen = new Pen(this.DockedWindowOuterBorder))
			{
				graphics.DrawLines(pen, new Point[]
				{
					new Point(bounds.X, bounds.Bottom - 1),
					new Point(bounds.X, bounds.Y + 1),
					new Point(bounds.X + 1, bounds.Y),
					new Point(bounds.Right - 2, bounds.Y),
					new Point(bounds.Right - 1, bounds.Y + 1),
					new Point(bounds.Right - 1, bounds.Bottom - 1)
				});
				goto IL_245;
			}
			IL_F9:
			if (bounds.Height > 0)
			{
				using (LinearGradientBrush linearGradientBrush = this.xb9d757f2231cc2a8(bounds, focused ? this.ActiveTitleBarBackground : this.InactiveTitleBarBackground, LinearGradientMode.Vertical))
				{
					graphics.FillRectangle(linearGradientBrush, bounds);
					goto IL_112;
				}
				goto IL_236;
			}
			IL_112:
			using (Pen pen2 = new Pen(this.DockedWindowInnerBorder))
			{
				graphics.DrawLines(pen2, new Point[]
				{
					new Point(bounds.X, bounds.Bottom - 1),
					new Point(bounds.X, bounds.Y),
					new Point(bounds.Right - 1, bounds.Y),
					new Point(bounds.Right - 1, bounds.Bottom - 1)
				});
				return;
			}
			IL_1DE:
			if (2147483647 != 0)
			{
			}
			goto IL_112;
			IL_236:
			if (bounds.Width <= 0)
			{
				goto IL_1DE;
			}
			goto IL_F9;
			IL_245:
			bounds.X++;
			bounds.Y++;
			bounds.Width -= 2;
			bounds.Height--;
			goto IL_236;
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0002FB5C File Offset: 0x0002EB5C
		protected internal override void DrawTitleBarText(Graphics graphics, Rectangle bounds, bool focused, string text, Font font)
		{
			bounds.Inflate(-3, 0);
			TextFormatFlags textFormatFlags = this.TextFormat;
			textFormatFlags |= TextFormatFlags.NoPrefix;
			bounds.X += 3;
			TextRenderer.DrawText(graphics, text, font, bounds, focused ? Color.Black : Color.Black, textFormatFlags);
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0002FBAC File Offset: 0x0002EBAC
		protected internal override void DrawTabStripBackground(Control container, Control control, Graphics graphics, Rectangle bounds, int selectedTabOffset)
		{
			using (SolidBrush solidBrush = new SolidBrush(this.Background))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			using (Pen pen = new Pen(this.TabStripInnerBorder))
			{
				graphics.DrawLine(pen, bounds.X, bounds.Top + 1, bounds.Right - 1, bounds.Top + 1);
			}
			using (Pen pen2 = new Pen(this.TabStripOuterBorder))
			{
				graphics.DrawLine(pen2, bounds.X, bounds.Top + 2, bounds.Right - 1, bounds.Top + 2);
			}
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0002FCA8 File Offset: 0x0002ECA8
		protected internal override void DrawTabStripTab(Graphics graphics, Rectangle bounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			bounds.Y += 2;
			bounds.Height -= 2;
			if ((state & DrawItemState.Selected) == DrawItemState.Selected)
			{
				using (LinearGradientBrush linearGradientBrush = this.xb9d757f2231cc2a8(bounds, this.TabStripSelectedTabBackground, LinearGradientMode.Vertical))
				{
					xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, linearGradientBrush, SystemColors.ControlText, this.TabStripOuterBorder, state, this.TextFormat);
					return;
				}
			}
			xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, this.TabStripNormalTabForeground, this.TabStripOuterBorder, state, this.TextFormat);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0002FD80 File Offset: 0x0002ED80
		protected internal override void DrawTitleBarButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state, bool focused, bool toggled)
		{
			this.x9271fbf5eef553db(graphics, bounds, state, focused);
			using (Pen pen = (!focused) ? new Pen(Color.Black) : new Pen(Color.Black))
			{
				switch (buttonType)
				{
				case SandDockButtonType.Close:
					x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, pen);
					break;
				case SandDockButtonType.Pin:
					x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, pen, toggled);
					break;
				case SandDockButtonType.WindowPosition:
					x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, pen);
					break;
				}
			}
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0002FE20 File Offset: 0x0002EE20
		private void x9271fbf5eef553db(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, DrawItemState x01b557925841ae51, bool xb0f87b71823b1d4e)
		{
			if ((x01b557925841ae51 & DrawItemState.HotLight) == DrawItemState.HotLight)
			{
				bool flag = (x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected;
				using (Brush brush = this.xb9d757f2231cc2a8(xda73fcb97c77d998, flag ? this.ButtonPressedOuterBorder : this.ButtonHotOuterBorder, LinearGradientMode.Vertical))
				{
					using (Pen pen = new Pen(brush))
					{
						x41347a961b838962.DrawPolygon(pen, new Point[]
						{
							new Point(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y),
							new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Y),
							new Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Y + 1),
							new Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 2),
							new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 1),
							new Point(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Bottom - 1),
							new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Bottom - 2),
							new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Y + 1)
						});
					}
				}
				using (Brush brush2 = this.xb9d757f2231cc2a8(xda73fcb97c77d998, flag ? this.ButtonPressedInnerBorder : this.ButtonHotInnerBorder, LinearGradientMode.Vertical))
				{
					using (Pen pen2 = new Pen(brush2))
					{
						x41347a961b838962.DrawRectangle(pen2, xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y + 1, xda73fcb97c77d998.Width - 3, xda73fcb97c77d998.Height - 3);
					}
				}
				using (Brush brush3 = this.xb9d757f2231cc2a8(xda73fcb97c77d998, flag ? this.ButtonPressedBackground : this.ButtonHotBackground, LinearGradientMode.Vertical))
				{
					x41347a961b838962.FillRectangle(brush3, xda73fcb97c77d998.X + 2, xda73fcb97c77d998.Y + 2, xda73fcb97c77d998.Width - 4, xda73fcb97c77d998.Height - 4);
				}
			}
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x000300DC File Offset: 0x0002F0DC
		protected internal override void DrawCollapsedTab(Graphics graphics, Rectangle bounds, DockSide dockSide, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool vertical)
		{
			using (Brush brush = this.xb9d757f2231cc2a8(bounds, vertical ? this.CollapsedTabVerticalBackground : this.CollapsedTabHorizontalBackground, vertical ? LinearGradientMode.Horizontal : LinearGradientMode.Vertical))
			{
				if (dockSide == DockSide.Left || dockSide == DockSide.Right)
				{
					using (Image image2 = new Bitmap(image))
					{
						image2.RotateFlip(RotateFlipType.Rotate90FlipNone);
						xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image2, text, font, brush, Brushes.Black, this.CollapsedTabBorder, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
						goto IL_8A;
					}
				}
				xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, brush, Brushes.Black, this.CollapsedTabBorder, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
				IL_8A:;
			}
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600067C RID: 1660 RVA: 0x000301B4 File Offset: 0x0002F1B4
		protected internal override BoxModel TabMetrics
		{
			get
			{
				if (this.x3a1fa93b40743331 == null)
				{
					this.x3a1fa93b40743331 = new BoxModel(0, 0, 0, 0, 0, 0, 0, 0, -1, 0);
				}
				return this.x3a1fa93b40743331;
			}
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x000301E4 File Offset: 0x0002F1E4
		protected internal override BoxModel TabStripMetrics
		{
			get
			{
				if (this.xc742aa5a0f350e7f == null)
				{
					int height = Control.DefaultFont.Height;
					int num = Math.Max(height, this.ImageSize.Height);
					this.xc742aa5a0f350e7f = new BoxModel(0, num + 8, 0, 0, 0, 1, 0, 0, 0, 0);
				}
				return this.xc742aa5a0f350e7f;
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x00030238 File Offset: 0x0002F238
		protected internal override TabTextDisplayMode TabTextDisplay
		{
			get
			{
				return TabTextDisplayMode.AllTabs;
			}
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x0003023C File Offset: 0x0002F23C
		protected internal override BoxModel TitleBarMetrics
		{
			get
			{
				if (this.x6defba3d5d846e0d == null)
				{
					this.x6defba3d5d846e0d = new BoxModel(0, Control.DefaultFont.Height + 8, 0, 0, 0, 0, 0, 0, 0, 0);
				}
				return this.x6defba3d5d846e0d;
			}
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00030278 File Offset: 0x0002F278
		protected internal override void DrawDocumentStripBackground(Graphics graphics, Rectangle bounds)
		{
			if (bounds.Width > 0)
			{
				if (!false)
				{
					goto IL_52;
				}
				IL_0D:
				using (Pen pen = new Pen(this.DocumentStripBorder))
				{
					graphics.DrawLine(pen, bounds.X, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
					return;
				}
				IL_52:
				if (bounds.Height > 0)
				{
					goto IL_0D;
				}
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x00030304 File Offset: 0x0002F304
		protected internal override int DocumentTabStripSize
		{
			get
			{
				int num = Math.Max(Control.DefaultFont.Height, this.ImageSize.Height);
				return num + 7;
			}
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x00030334 File Offset: 0x0002F334
		protected internal override int DocumentTabSize
		{
			get
			{
				int num = Math.Max(Control.DefaultFont.Height, this.ImageSize.Height);
				return num + 5;
			}
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x00030364 File Offset: 0x0002F364
		protected internal override int DocumentTabExtra
		{
			get
			{
				return this.ImageSize.Width;
			}
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x00030380 File Offset: 0x0002F380
		protected internal override void DrawDocumentStripTab(Graphics graphics, Rectangle bounds, Rectangle contentBounds, Image image, string text, Font font, Color backColor, Color foreColor, DrawItemState state, bool drawSeparator)
		{
			if (bounds.Width > 0 && bounds.Height > 0)
			{
				if ((drawSeparator ? 1U : 0U) + (drawSeparator ? 1U : 0U) >= 0U)
				{
					goto IL_178;
				}
				goto IL_D2;
				ColorBlend xdf5de570fec6a;
				bool flag;
				do
				{
					IL_8B:
					xdf5de570fec6a = this.DocumentNormalTabBackground;
					if (false)
					{
						goto IL_178;
					}
				}
				while ((drawSeparator ? 1U : 0U) + (flag ? 1U : 0U) < 0U);
				bool flag2;
				if (-1 == 0)
				{
					flag2 = ((flag ? 1U : 0U) > uint.MaxValue);
					if (flag2)
					{
						goto IL_C9;
					}
					goto IL_E2;
				}
				IL_12:
				Color color;
				Color color2;
				using (Brush brush = this.xb9d757f2231cc2a8(bounds, xdf5de570fec6a, LinearGradientMode.Vertical))
				{
					using (Pen pen = new Pen(color))
					{
						using (Pen pen2 = new Pen(color2))
						{
							this.xf8aac789a7846004(graphics, bounds, contentBounds, image, text, font, backColor, pen, pen2, brush, state, flag, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat);
						}
					}
					return;
				}
				goto IL_8B;
				IL_C9:
				if ((state & DrawItemState.HotLight) == DrawItemState.HotLight)
				{
					goto IL_E2;
				}
				IL_D2:
				color = this.DocumentNormalTabOuterBorder;
				color2 = this.DocumentNormalTabInnerBorder;
				goto IL_8B;
				IL_E2:
				color = this.DocumentHotTabOuterBorder;
				color2 = this.DocumentHotTabInnerBorder;
				xdf5de570fec6a = this.DocumentHotTabBackground;
				goto IL_12;
				IL_178:
				flag = ((state & DrawItemState.Checked) == DrawItemState.Checked);
				if ((state & DrawItemState.Selected) != DrawItemState.Selected)
				{
					goto IL_C9;
				}
				flag2 = ((drawSeparator ? 1U : 0U) > uint.MaxValue);
				if (!flag2)
				{
					color = this.DocumentSelectedTabOuterBorder;
					color2 = this.DocumentSelectedTabInnerBorder;
					xdf5de570fec6a = this.DocumentSelectedTabBackground;
					goto IL_12;
				}
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x00030560 File Offset: 0x0002F560
		private void xf8aac789a7846004(Graphics x41347a961b838962, Rectangle xda73fcb97c77d998, Rectangle x0bd0d09521a6c8ef, Image xe058541ca798c059, string xb41faee6912a2313, Font x26094932cf7a9139, Color xe8029028206f7f99, Pen x19577c9fba5c0e47, Pen x7df20da36ed57a6a, Brush x6f967439eb9e4ffb, DrawItemState x01b557925841ae51, bool xb0f87b71823b1d4e, int x6843d1739e949b3a, int xbd5e294caed74c4d, TextFormatFlags xae3b2752a89e7464)
		{
			if ((x01b557925841ae51 & DrawItemState.Selected) == DrawItemState.Selected)
			{
				xda73fcb97c77d998.Height++;
				do
				{
					x6843d1739e949b3a++;
				}
				while (-2147483648 == 0);
			}
			x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Left + 1, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2);
			x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 2);
			if ((xb0f87b71823b1d4e ? 1U : 0U) - (uint)x6843d1739e949b3a < 0U)
			{
				goto IL_1DF;
			}
			Point[] array;
			if ((xb0f87b71823b1d4e ? 1U : 0U) - (uint)x6843d1739e949b3a <= 4294967295U)
			{
				x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 1);
				x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top);
				x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2);
				do
				{
					x41347a961b838962.DrawLine(x19577c9fba5c0e47, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 2);
					x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3);
					x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 3);
					x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 2);
					x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 4, xda73fcb97c77d998.Top + 1);
					x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
					x41347a961b838962.DrawLine(x7df20da36ed57a6a, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 2);
					if ((uint)xbd5e294caed74c4d + (xb0f87b71823b1d4e ? 1U : 0U) > 4294967295U)
					{
						goto IL_240;
					}
				}
				while (false);
				array = new Point[5];
				array[0] = new Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 1);
				goto IL_240;
			}
			IL_1D3:
			x41347a961b838962.FillPolygon(x6f967439eb9e4ffb, array);
			xda73fcb97c77d998 = x0bd0d09521a6c8ef;
			IL_1DF:
			xda73fcb97c77d998.X += xbd5e294caed74c4d;
			bool flag = (uint)x6843d1739e949b3a < 0U;
			if (flag)
			{
				goto IL_F0;
			}
			xda73fcb97c77d998.Width -= xbd5e294caed74c4d;
			goto IL_C3;
			IL_A9:
			if (xda73fcb97c77d998.Width <= 8)
			{
				goto IL_562;
			}
			xae3b2752a89e7464 |= TextFormatFlags.HorizontalCenter;
			if (!false)
			{
				flag = (((uint)x6843d1739e949b3a | 2147483648U) == 0U);
				if (flag)
				{
					goto IL_F0;
				}
				xae3b2752a89e7464 &= (TextFormatFlags)(-1);
				if (false)
				{
					goto IL_562;
				}
				if ((xb0f87b71823b1d4e ? 1U : 0U) - (uint)x6843d1739e949b3a <= 4294967295U)
				{
					TextRenderer.DrawText(x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, xda73fcb97c77d998, SystemColors.ControlText, xae3b2752a89e7464);
					goto IL_6E;
				}
				return;
			}
			IL_2F:
			Rectangle rectangle;
			rectangle.Height += 2;
			rectangle.X++;
			rectangle.Width--;
			ControlPaint.DrawFocusRectangle(x41347a961b838962, rectangle);
			return;
			IL_6E:
			if (xb0f87b71823b1d4e)
			{
				goto IL_577;
			}
			return;
			IL_562:
			flag = ((xb0f87b71823b1d4e ? 1U : 0U) < 0U);
			if (!flag)
			{
				goto IL_6E;
			}
			IL_577:
			if (((uint)x6843d1739e949b3a & 0U) == 0U)
			{
				rectangle = xda73fcb97c77d998;
				rectangle.Inflate(-2, -2);
				if ((xb0f87b71823b1d4e ? 1U : 0U) <= 4294967295U)
				{
					goto IL_2F;
				}
				goto IL_240;
			}
			return;
			IL_C3:
			if (xe058541ca798c059 == null)
			{
				goto IL_A9;
			}
			IL_F0:
			x41347a961b838962.DrawImage(xe058541ca798c059, xda73fcb97c77d998.X + 4, xda73fcb97c77d998.Y + 2, this.ImageSize.Width, this.ImageSize.Height);
			xda73fcb97c77d998.X += this.ImageSize.Width + 4;
			xda73fcb97c77d998.Width -= this.ImageSize.Width + 4;
			if (8 == 0)
			{
				goto IL_C3;
			}
			goto IL_A9;
			IL_240:
			array[1] = new Point(xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 4);
			array[2] = new Point(xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 2);
			array[3] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
			array[4] = new Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 1);
			goto IL_1D3;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00030AFC File Offset: 0x0002FAFC
		protected internal override Size MeasureTabStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			return xa811784015ed8842.xcdfce0e0f2641503(graphics, image, this.ImageSize, text, font, this.TextFormat);
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00030B14 File Offset: 0x0002FB14
		protected internal override Size MeasureDocumentStripTab(Graphics graphics, Image image, string text, Font font, DrawItemState state)
		{
			TextFormatFlags textFormatFlags = this.TextFormat;
			textFormatFlags &= ~TextFormatFlags.NoPrefix;
			int num;
			using (Font font2 = new Font(font, FontStyle.Bold))
			{
				num = TextRenderer.MeasureText(graphics, text, font2, new Size(int.MaxValue, int.MaxValue), textFormatFlags).Width;
			}
			for (;;)
			{
				num += 14;
				if (15 != 0)
				{
					goto IL_38;
				}
				IL_09:
				num += this.ImageSize.Width + 4;
				if (false)
				{
					continue;
				}
				bool flag = (uint)num - (uint)num < 0U;
				if (!flag)
				{
					break;
				}
				IL_38:
				if (image == null)
				{
					break;
				}
				goto IL_09;
			}
			num += this.DocumentTabExtra;
			return new Size(num, 0);
		}

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x00030BDC File Offset: 0x0002FBDC
		public override Size TabControlPadding
		{
			get
			{
				return new Size(3, 3);
			}
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00030BE8 File Offset: 0x0002FBE8
		protected internal override void DrawDocumentStripButton(Graphics graphics, Rectangle bounds, SandDockButtonType buttonType, DrawItemState state)
		{
			this.x9271fbf5eef553db(graphics, bounds, state, true);
			switch (buttonType)
			{
			case SandDockButtonType.Close:
				x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, SystemPens.ControlText);
				return;
			case SandDockButtonType.Pin:
			case SandDockButtonType.WindowPosition:
				return;
			case SandDockButtonType.ScrollLeft:
				break;
			case SandDockButtonType.ScrollRight:
				goto IL_64;
			case SandDockButtonType.ActiveFiles:
				bounds.Inflate(1, 1);
				bounds.X--;
				if (!false)
				{
					x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, SystemPens.ControlText);
					return;
				}
				break;
			default:
				if (8 != 0)
				{
					return;
				}
				goto IL_64;
			}
			x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
			if (4 != 0)
			{
				return;
			}
			return;
			IL_64:
			x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00030CA0 File Offset: 0x0002FCA0
		protected internal override void DrawDocumentClientBackground(Graphics graphics, Rectangle bounds, Color backColor)
		{
			using (SolidBrush solidBrush = new SolidBrush(backColor))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			using (Pen pen = new Pen(this.DocumentStripBorder))
			{
				graphics.DrawLines(pen, new Point[]
				{
					new Point(bounds.X, bounds.Y),
					new Point(bounds.X, bounds.Bottom - 1),
					new Point(bounds.Right - 1, bounds.Bottom - 1),
					new Point(bounds.Right - 1, bounds.Y)
				});
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00030DA8 File Offset: 0x0002FDA8
		protected internal override Rectangle AdjustDockControlClientBounds(ControlLayoutSystem layoutSystem, DockControl control, Rectangle clientBounds)
		{
			if (layoutSystem is DocumentLayoutSystem)
			{
				clientBounds.X++;
				clientBounds.Width -= 2;
				clientBounds.Height--;
				return clientBounds;
			}
			return base.AdjustDockControlClientBounds(layoutSystem, control, clientBounds);
		}

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x00030DF8 File Offset: 0x0002FDF8
		public override bool ShouldDrawControlBorder
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00030DFC File Offset: 0x0002FDFC
		public override void DrawTabControlBackground(Graphics graphics, Rectangle bounds, Color backColor, bool client)
		{
			if (!client)
			{
				using (SolidBrush solidBrush = new SolidBrush(backColor))
				{
					graphics.FillRectangle(solidBrush, bounds);
				}
				using (Pen pen = new Pen(this.DocumentStripBorder))
				{
					graphics.DrawLines(pen, new Point[]
					{
						new Point(bounds.X, bounds.Y),
						new Point(bounds.X, bounds.Bottom - 1),
						new Point(bounds.Right - 1, bounds.Bottom - 1),
						new Point(bounds.Right - 1, bounds.Y)
					});
				}
			}
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00030F0C File Offset: 0x0002FF0C
		public override void ModifyDefaultWindowColors(DockControl window, ref Color backColor, ref Color borderColor)
		{
			borderColor = this.DockedWindowOuterBorder;
		}

		// Token: 0x04000245 RID: 581
		private Color x21357dc320fa442f;

		// Token: 0x04000246 RID: 582
		private Color xf78d540f2ad4eefe;

		// Token: 0x04000247 RID: 583
		private Color x2a8ba610037adcf2;

		// Token: 0x04000248 RID: 584
		private Color xf03842e8454f12ef;

		// Token: 0x04000249 RID: 585
		private Color xd86b7ed9f7ac5bcf;

		// Token: 0x0400024A RID: 586
		private Color x311be0ac2a7ad6f7;

		// Token: 0x0400024B RID: 587
		private Color x4c4dd6a647f58188;

		// Token: 0x0400024C RID: 588
		private Color x9185f4f5b194140e;

		// Token: 0x0400024D RID: 589
		private Color x5581066ec159efc6;

		// Token: 0x0400024E RID: 590
		private Color x4457bc20e07c5384;

		// Token: 0x0400024F RID: 591
		private Color xe339b39f12fe3a06;

		// Token: 0x04000250 RID: 592
		private Color x216af2b9aa27b602;

		// Token: 0x04000251 RID: 593
		private Color xac76de21a6c85f45;

		// Token: 0x04000252 RID: 594
		private Color xeedeb7a1ef6db2c5;

		// Token: 0x04000253 RID: 595
		private ColorBlend x4603d08f845b431d;

		// Token: 0x04000254 RID: 596
		private ColorBlend x6d145d34f6cf6305;

		// Token: 0x04000255 RID: 597
		private ColorBlend x7d4e8244c07128f3;

		// Token: 0x04000256 RID: 598
		private ColorBlend xe127097a0a7bcea3;

		// Token: 0x04000257 RID: 599
		private ColorBlend x34b837871ba5992c;

		// Token: 0x04000258 RID: 600
		private ColorBlend x267ad4ea8c519e4c;

		// Token: 0x04000259 RID: 601
		private ColorBlend xea896c10e961df63;

		// Token: 0x0400025A RID: 602
		private ColorBlend xaeb413d4d357001d;

		// Token: 0x0400025B RID: 603
		private ColorBlend xf654cd91b245064f;

		// Token: 0x0400025C RID: 604
		private ColorBlend x2f53a4063520f7b7;

		// Token: 0x0400025D RID: 605
		private ColorBlend xf320905c8fa15baa;

		// Token: 0x0400025E RID: 606
		private ColorBlend x928270a1d0f072fb;

		// Token: 0x0400025F RID: 607
		private ColorBlend xf62715f1e5e2cfba;

		// Token: 0x04000260 RID: 608
		private ColorBlend x854213a69311962a;

		// Token: 0x04000261 RID: 609
		private ColorBlend x642be9cb364d5c7e;

		// Token: 0x04000262 RID: 610
		private ColorBlend x55f5ad59d4c9fe0a;

		// Token: 0x04000263 RID: 611
		private Office2007ColorScheme x62a65b2c0f145432 = (Office2007ColorScheme)(-1);

		// Token: 0x04000264 RID: 612
		private BoxModel x3a1fa93b40743331;

		// Token: 0x04000265 RID: 613
		private BoxModel xc742aa5a0f350e7f;

		// Token: 0x04000266 RID: 614
		private BoxModel x6defba3d5d846e0d;

		// Token: 0x04000267 RID: 615
		private int x03bb1ee2adad51ea;

		// Token: 0x04000268 RID: 616
		private TextFormatFlags xae3b2752a89e7464;
	}
}

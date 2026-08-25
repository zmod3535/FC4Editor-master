using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Divelements.SandGrid.Rendering
{
	// Token: 0x0200005C RID: 92
	public class Office2007Renderer : ISandGridRenderer
	{
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x0600055F RID: 1375 RVA: 0x0001C26C File Offset: 0x0001B26C
		// (remove) Token: 0x06000560 RID: 1376 RVA: 0x0001C288 File Offset: 0x0001B288
		public event EventHandler RedrawNeeded
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				this.x5e7a70d58e13247a = (EventHandler)Delegate.Combine(this.x5e7a70d58e13247a, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				this.x5e7a70d58e13247a = (EventHandler)Delegate.Remove(this.x5e7a70d58e13247a, value);
			}
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0001C2A4 File Offset: 0x0001B2A4
		public Office2007Renderer()
		{
			this.ColorScheme = Office2007ColorScheme.Blue;
		}

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000562 RID: 1378 RVA: 0x0001C2C8 File Offset: 0x0001B2C8
		// (set) Token: 0x06000563 RID: 1379 RVA: 0x0001C2D0 File Offset: 0x0001B2D0
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color RowHeaderCurrentBorderColor
		{
			get
			{
				return this.xe14524446c5db6c4;
			}
			set
			{
				this.xe14524446c5db6c4 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x0001C2E4 File Offset: 0x0001B2E4
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x0001C2EC File Offset: 0x0001B2EC
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color RowHeaderCurrentBackgroundColor
		{
			get
			{
				return this.xf9c68aa7e6f8675b;
			}
			set
			{
				this.xf9c68aa7e6f8675b = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x0001C300 File Offset: 0x0001B300
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x0001C308 File Offset: 0x0001B308
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color GroupHeaderTextColor
		{
			get
			{
				return this.xd17c882aa378b7de;
			}
			set
			{
				this.xd17c882aa378b7de = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x0001C31C File Offset: 0x0001B31C
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x0001C324 File Offset: 0x0001B324
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color GroupHeaderGlyphColor
		{
			get
			{
				return this.x1faec58713e797e9;
			}
			set
			{
				this.x1faec58713e797e9 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x0001C338 File Offset: 0x0001B338
		// (set) Token: 0x0600056B RID: 1387 RVA: 0x0001C340 File Offset: 0x0001B340
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color GroupHeaderDividerColor
		{
			get
			{
				return this.x1c87970653553277;
			}
			set
			{
				this.x1c87970653553277 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x0001C354 File Offset: 0x0001B354
		// (set) Token: 0x0600056D RID: 1389 RVA: 0x0001C35C File Offset: 0x0001B35C
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color GroupHeaderHighlightColor
		{
			get
			{
				return this.x23f8c528d8372ea4;
			}
			set
			{
				this.x23f8c528d8372ea4 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600056E RID: 1390 RVA: 0x0001C370 File Offset: 0x0001B370
		// (set) Token: 0x0600056F RID: 1391 RVA: 0x0001C378 File Offset: 0x0001B378
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color GroupHeaderShadowColor
		{
			get
			{
				return this.x447d2008d9c0a14a;
			}
			set
			{
				this.x447d2008d9c0a14a = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000570 RID: 1392 RVA: 0x0001C38C File Offset: 0x0001B38C
		// (set) Token: 0x06000571 RID: 1393 RVA: 0x0001C394 File Offset: 0x0001B394
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color GroupHeaderHotBackgroundColor1
		{
			get
			{
				return this.x633077f4e131f59c;
			}
			set
			{
				this.x633077f4e131f59c = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000572 RID: 1394 RVA: 0x0001C3A8 File Offset: 0x0001B3A8
		// (set) Token: 0x06000573 RID: 1395 RVA: 0x0001C3B0 File Offset: 0x0001B3B0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color GroupHeaderHotBackgroundColor2
		{
			get
			{
				return this.x89197013acca3dca;
			}
			set
			{
				this.x89197013acca3dca = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000574 RID: 1396 RVA: 0x0001C3C4 File Offset: 0x0001B3C4
		// (set) Token: 0x06000575 RID: 1397 RVA: 0x0001C3CC File Offset: 0x0001B3CC
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color GroupHeaderNormalBackgroundColor1
		{
			get
			{
				return this.x7b13f9061235e3c5;
			}
			set
			{
				this.x7b13f9061235e3c5 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000576 RID: 1398 RVA: 0x0001C3E0 File Offset: 0x0001B3E0
		// (set) Token: 0x06000577 RID: 1399 RVA: 0x0001C3E8 File Offset: 0x0001B3E8
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color GroupHeaderNormalBackgroundColor2
		{
			get
			{
				return this.x3a56fc7b53ec6368;
			}
			set
			{
				this.x3a56fc7b53ec6368 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x0001C3FC File Offset: 0x0001B3FC
		// (set) Token: 0x06000579 RID: 1401 RVA: 0x0001C404 File Offset: 0x0001B404
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color AlternateRowBackgroundColor
		{
			get
			{
				return this.x163e7df4fee4bb56;
			}
			set
			{
				this.x163e7df4fee4bb56 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0001C418 File Offset: 0x0001B418
		// (set) Token: 0x0600057B RID: 1403 RVA: 0x0001C420 File Offset: 0x0001B420
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color ColumnHeaderHotBorderColor
		{
			get
			{
				return this.x48476da2f66b8fbc;
			}
			set
			{
				this.x48476da2f66b8fbc = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600057C RID: 1404 RVA: 0x0001C434 File Offset: 0x0001B434
		// (set) Token: 0x0600057D RID: 1405 RVA: 0x0001C43C File Offset: 0x0001B43C
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color RowHeaderNormalBorderColor
		{
			get
			{
				return this.xb8b65e16c1ede3ad;
			}
			set
			{
				this.xb8b65e16c1ede3ad = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000160 RID: 352
		// (get) Token: 0x0600057E RID: 1406 RVA: 0x0001C450 File Offset: 0x0001B450
		// (set) Token: 0x0600057F RID: 1407 RVA: 0x0001C458 File Offset: 0x0001B458
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color RowHeaderHotBorderColor
		{
			get
			{
				return this.xc94f4cb44dd95fe8;
			}
			set
			{
				this.xc94f4cb44dd95fe8 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06000580 RID: 1408 RVA: 0x0001C46C File Offset: 0x0001B46C
		// (set) Token: 0x06000581 RID: 1409 RVA: 0x0001C474 File Offset: 0x0001B474
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color RowHeaderHotBackgroundColor
		{
			get
			{
				return this.x725cf8a1f751cfc6;
			}
			set
			{
				this.x725cf8a1f751cfc6 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x0001C488 File Offset: 0x0001B488
		// (set) Token: 0x06000583 RID: 1411 RVA: 0x0001C490 File Offset: 0x0001B490
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color RowHeaderNormalBackgroundColor
		{
			get
			{
				return this.xc1cd15c3abb9387d;
			}
			set
			{
				this.xc1cd15c3abb9387d = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x0001C4A4 File Offset: 0x0001B4A4
		// (set) Token: 0x06000585 RID: 1413 RVA: 0x0001C4AC File Offset: 0x0001B4AC
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color ColumnHeaderHotBackgroundColor2
		{
			get
			{
				return this.x39701e57bb3ae4c2;
			}
			set
			{
				this.x39701e57bb3ae4c2 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x0001C4C0 File Offset: 0x0001B4C0
		// (set) Token: 0x06000587 RID: 1415 RVA: 0x0001C4C8 File Offset: 0x0001B4C8
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color ColumnHeaderHotBackgroundColor1
		{
			get
			{
				return this.x74e99381f240b01e;
			}
			set
			{
				this.x74e99381f240b01e = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x0001C4DC File Offset: 0x0001B4DC
		// (set) Token: 0x06000589 RID: 1417 RVA: 0x0001C4E4 File Offset: 0x0001B4E4
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color ColumnHeaderNormalBorderColor
		{
			get
			{
				return this.xd59160d3a6a4dcab;
			}
			set
			{
				this.xd59160d3a6a4dcab = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x0600058A RID: 1418 RVA: 0x0001C4F8 File Offset: 0x0001B4F8
		// (set) Token: 0x0600058B RID: 1419 RVA: 0x0001C500 File Offset: 0x0001B500
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color ColumnHeaderNormalBackgroundColor2
		{
			get
			{
				return this.x36c3c9abc1ae7d73;
			}
			set
			{
				this.x36c3c9abc1ae7d73 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x0001C514 File Offset: 0x0001B514
		// (set) Token: 0x0600058D RID: 1421 RVA: 0x0001C51C File Offset: 0x0001B51C
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color ColumnHeaderNormalBackgroundColor1
		{
			get
			{
				return this.x7d3322d4cf65c759;
			}
			set
			{
				this.x7d3322d4cf65c759 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x0600058E RID: 1422 RVA: 0x0001C530 File Offset: 0x0001B530
		// (set) Token: 0x0600058F RID: 1423 RVA: 0x0001C538 File Offset: 0x0001B538
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color ColumnHeaderCurrentBorderColor
		{
			get
			{
				return this.xc5dba97deb5a0809;
			}
			set
			{
				this.xc5dba97deb5a0809 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x0001C54C File Offset: 0x0001B54C
		// (set) Token: 0x06000591 RID: 1425 RVA: 0x0001C554 File Offset: 0x0001B554
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color ColumnHeaderCurrentBackgroundColor2
		{
			get
			{
				return this.xaf0d35c621caeda8;
			}
			set
			{
				this.xaf0d35c621caeda8 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x06000592 RID: 1426 RVA: 0x0001C568 File Offset: 0x0001B568
		// (set) Token: 0x06000593 RID: 1427 RVA: 0x0001C570 File Offset: 0x0001B570
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color ColumnHeaderCurrentBackgroundColor1
		{
			get
			{
				return this.xc9a32f8ab3af9bda;
			}
			set
			{
				this.xc9a32f8ab3af9bda = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x06000594 RID: 1428 RVA: 0x0001C584 File Offset: 0x0001B584
		// (set) Token: 0x06000595 RID: 1429 RVA: 0x0001C58C File Offset: 0x0001B58C
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color SelectionUnfocusedBackgroundColor
		{
			get
			{
				return this.x90d5feec11e1056b;
			}
			set
			{
				this.x90d5feec11e1056b = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x06000596 RID: 1430 RVA: 0x0001C5A0 File Offset: 0x0001B5A0
		// (set) Token: 0x06000597 RID: 1431 RVA: 0x0001C5A8 File Offset: 0x0001B5A8
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color SelectionFocusedBackgroundColor
		{
			get
			{
				return this.x1f8082dd5747ff1b;
			}
			set
			{
				this.x1f8082dd5747ff1b = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x0001C5BC File Offset: 0x0001B5BC
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x0001C5C4 File Offset: 0x0001B5C4
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Color SelectionUnfocusedForegroundColor
		{
			get
			{
				return this.x1225ae3a9a2de58d;
			}
			set
			{
				this.x1225ae3a9a2de58d = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0001C5D8 File Offset: 0x0001B5D8
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x0001C5E0 File Offset: 0x0001B5E0
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color SelectionFocusedForegroundColor
		{
			get
			{
				return this.x71cf5537386d2d31;
			}
			set
			{
				this.x71cf5537386d2d31 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x0001C5F4 File Offset: 0x0001B5F4
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x0001C5FC File Offset: 0x0001B5FC
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color GridLineColor
		{
			get
			{
				return this.x57dd8cbd69f9704d;
			}
			set
			{
				this.x57dd8cbd69f9704d = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x0001C610 File Offset: 0x0001B610
		public override string ToString()
		{
			return "Office 2007";
		}

		// Token: 0x17000170 RID: 368
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0001C618 File Offset: 0x0001B618
		// (set) Token: 0x060005A0 RID: 1440 RVA: 0x0001C620 File Offset: 0x0001B620
		[DefaultValue(true)]
		[Description("Indicates whether drop shadows are drawn.")]
		public bool DrawShadows
		{
			get
			{
				return this.x15edd106dba2f3b0;
			}
			set
			{
				this.x15edd106dba2f3b0 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0001C634 File Offset: 0x0001B634
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x0001C63C File Offset: 0x0001B63C
		[Description("Indicates when the backgrounds of columns are shaded.")]
		[DefaultValue(typeof(ColumnShadeType), "SortOnly")]
		public ColumnShadeType ColumnShade
		{
			get
			{
				return this.x7508f055717dd2c8;
			}
			set
			{
				this.x7508f055717dd2c8 = value;
				this.OnRedrawNeeded(EventArgs.Empty);
			}
		}

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0001C650 File Offset: 0x0001B650
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x0001C658 File Offset: 0x0001B658
		[DefaultValue(typeof(Office2007ColorScheme), "Blue")]
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
					this.x62a65b2c0f145432 = value;
					this.xc3a1927482d5da47();
					this.OnRedrawNeeded(EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060005A5 RID: 1445 RVA: 0x0001C67C File Offset: 0x0001B67C
		// (set) Token: 0x060005A6 RID: 1446 RVA: 0x0001C684 File Offset: 0x0001B684
		[DefaultValue(typeof(Office2007ColumnHeaderStyle), "Excel")]
		public Office2007ColumnHeaderStyle ColumnHeaderStyle
		{
			get
			{
				return this.x633fa6d139f34c16;
			}
			set
			{
				if (value != this.x633fa6d139f34c16)
				{
					this.x633fa6d139f34c16 = value;
					this.xc3a1927482d5da47();
					this.OnRedrawNeeded(EventArgs.Empty);
				}
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060005A7 RID: 1447 RVA: 0x0001C6A8 File Offset: 0x0001B6A8
		// (set) Token: 0x060005A8 RID: 1448 RVA: 0x0001C6B0 File Offset: 0x0001B6B0
		[DefaultValue(typeof(Office2007GroupHeaderStyle), "Divider")]
		public Office2007GroupHeaderStyle GroupHeaderStyle
		{
			get
			{
				return this.x1f5c00ac423c687a;
			}
			set
			{
				if (value != this.x1f5c00ac423c687a)
				{
					this.x1f5c00ac423c687a = value;
					this.xc3a1927482d5da47();
					this.OnRedrawNeeded(EventArgs.Empty);
				}
			}
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0001C6D4 File Offset: 0x0001B6D4
		private void xc3a1927482d5da47()
		{
			Office2007ColorScheme colorScheme = this.ColorScheme;
			for (;;)
			{
				switch (colorScheme)
				{
				case Office2007ColorScheme.Blue:
					this.x57dd8cbd69f9704d = ColorTranslator.FromHtml("#E3EFFF");
					this.x1f8082dd5747ff1b = ColorTranslator.FromHtml("#B3C8E8");
					this.x90d5feec11e1056b = ColorTranslator.FromHtml("#E6E6DF");
					this.x71cf5537386d2d31 = SystemColors.WindowText;
					this.x1225ae3a9a2de58d = SystemColors.WindowText;
					if (this.ColumnHeaderStyle == Office2007ColumnHeaderStyle.Excel)
					{
						if (4 == 0)
						{
							return;
						}
						this.x7d3322d4cf65c759 = ColorTranslator.FromHtml("#F9FCFD");
						this.x36c3c9abc1ae7d73 = ColorTranslator.FromHtml("#D4DCE9");
						this.xd59160d3a6a4dcab = ColorTranslator.FromHtml("#9EB6CE");
						this.x74e99381f240b01e = ColorTranslator.FromHtml("#DFE2E4");
						this.x39701e57bb3ae4c2 = ColorTranslator.FromHtml("#BDC6D2");
						this.x48476da2f66b8fbc = ColorTranslator.FromHtml("#879FB7");
						this.xc9a32f8ab3af9bda = ColorTranslator.FromHtml("#F9D99F");
						this.xaf0d35c621caeda8 = ColorTranslator.FromHtml("#F2C260");
						this.xc5dba97deb5a0809 = ColorTranslator.FromHtml("#F29536");
					}
					else
					{
						this.x7d3322d4cf65c759 = (this.x74e99381f240b01e = (this.xc9a32f8ab3af9bda = ColorTranslator.FromHtml("#FFFFFF")));
						this.x36c3c9abc1ae7d73 = (this.x39701e57bb3ae4c2 = (this.xaf0d35c621caeda8 = ColorTranslator.FromHtml("#C4DDFF")));
						if (3 == 0)
						{
							goto IL_307;
						}
						this.xd59160d3a6a4dcab = (this.x48476da2f66b8fbc = (this.xc5dba97deb5a0809 = ColorTranslator.FromHtml("#6593CF")));
					}
					this.x163e7df4fee4bb56 = ColorTranslator.FromHtml("#F4F4F4");
					if (this.GroupHeaderStyle == Office2007GroupHeaderStyle.Divider)
					{
						goto Block_8;
					}
					this.xd17c882aa378b7de = ColorTranslator.FromHtml("#15428B");
					if (false)
					{
						continue;
					}
					goto IL_82B;
				case Office2007ColorScheme.Black:
					this.x57dd8cbd69f9704d = ColorTranslator.FromHtml("#DDE0E3");
					this.x1f8082dd5747ff1b = ColorTranslator.FromHtml("#B3C8E8");
					this.x90d5feec11e1056b = ColorTranslator.FromHtml("#E6E6DF");
					this.x71cf5537386d2d31 = SystemColors.WindowText;
					this.x1225ae3a9a2de58d = SystemColors.WindowText;
					if (this.ColumnHeaderStyle == Office2007ColumnHeaderStyle.Excel)
					{
						goto IL_480;
					}
					this.x7d3322d4cf65c759 = (this.x74e99381f240b01e = (this.xc9a32f8ab3af9bda = ColorTranslator.FromHtml("#FFFFFF")));
					this.x36c3c9abc1ae7d73 = (this.x39701e57bb3ae4c2 = (this.xaf0d35c621caeda8 = ColorTranslator.FromHtml("#D4D7DB")));
					if (!false)
					{
						goto Block_5;
					}
					goto IL_149;
				case Office2007ColorScheme.Silver:
					this.x57dd8cbd69f9704d = ColorTranslator.FromHtml("#EAE9E1");
					this.x1f8082dd5747ff1b = ColorTranslator.FromHtml("#B3C8E8");
					this.x90d5feec11e1056b = ColorTranslator.FromHtml("#E6E6DF");
					this.x71cf5537386d2d31 = SystemColors.WindowText;
					this.x1225ae3a9a2de58d = SystemColors.WindowText;
					if (this.ColumnHeaderStyle == Office2007ColumnHeaderStyle.Excel)
					{
						goto IL_307;
					}
					this.x7d3322d4cf65c759 = (this.x74e99381f240b01e = (this.xc9a32f8ab3af9bda = ColorTranslator.FromHtml("#FFFFFF")));
					this.x36c3c9abc1ae7d73 = (this.x39701e57bb3ae4c2 = (this.xaf0d35c621caeda8 = ColorTranslator.FromHtml("#D4D7DB")));
					this.xd59160d3a6a4dcab = (this.x48476da2f66b8fbc = (this.xc5dba97deb5a0809 = ColorTranslator.FromHtml("#6F7074")));
					goto IL_139;
				}
				return;
				IL_149:
				if (this.GroupHeaderStyle == Office2007GroupHeaderStyle.Divider)
				{
					this.xd17c882aa378b7de = ColorTranslator.FromHtml("#706F91");
					if (2147483647 != 0)
					{
						this.x1c87970653553277 = ColorTranslator.FromHtml("#A5A4BD");
						goto IL_0C;
					}
				}
				else
				{
					this.xd17c882aa378b7de = ColorTranslator.FromHtml("#15428B");
					this.x1c87970653553277 = ColorTranslator.FromHtml("#6F7074");
					this.x7b13f9061235e3c5 = ColorTranslator.FromHtml("#D5DBE7");
					this.x3a56fc7b53ec6368 = ColorTranslator.FromHtml("#F3F5F5");
					this.x633077f4e131f59c = ColorTranslator.FromHtml("#E7EAEE");
					this.x89197013acca3dca = ColorTranslator.FromHtml("#FFFFFF");
					this.x1faec58713e797e9 = ColorTranslator.FromHtml("#656870");
					this.x23f8c528d8372ea4 = ColorTranslator.FromHtml("#FFFFFF");
					this.x447d2008d9c0a14a = ColorTranslator.FromHtml("#C5C7C7");
					if (false)
					{
						goto IL_629;
					}
					if (-1 == 0)
					{
						continue;
					}
					goto IL_0C;
				}
				IL_66:
				this.xe14524446c5db6c4 = ColorTranslator.FromHtml("#D4763D");
				if (3 == 0)
				{
					continue;
				}
				return;
				IL_0C:
				this.xc1cd15c3abb9387d = ColorTranslator.FromHtml("#E7E7E7");
				this.xb8b65e16c1ede3ad = ColorTranslator.FromHtml("#909192");
				this.x725cf8a1f751cfc6 = ColorTranslator.FromHtml("#B8BFC4");
				this.xc94f4cb44dd95fe8 = ColorTranslator.FromHtml("#9DA3A9");
				this.xf9c68aa7e6f8675b = ColorTranslator.FromHtml("#F5C795");
				if (2147483647 != 0)
				{
					goto IL_66;
				}
				goto IL_480;
				IL_139:
				this.x163e7df4fee4bb56 = ColorTranslator.FromHtml("#F4F4F4");
				goto IL_149;
				IL_307:
				this.x7d3322d4cf65c759 = ColorTranslator.FromHtml("#F1F3F3");
				this.x36c3c9abc1ae7d73 = ColorTranslator.FromHtml("#C8C9CA");
				this.xd59160d3a6a4dcab = ColorTranslator.FromHtml("#909192");
				this.x74e99381f240b01e = ColorTranslator.FromHtml("#D0D0D0");
				this.x39701e57bb3ae4c2 = ColorTranslator.FromHtml("#A6A6A6");
				this.x48476da2f66b8fbc = ColorTranslator.FromHtml("#9DA3A9");
				this.xc9a32f8ab3af9bda = ColorTranslator.FromHtml("#FFCC99");
				this.xaf0d35c621caeda8 = ColorTranslator.FromHtml("#FF9C69");
				this.xc5dba97deb5a0809 = ColorTranslator.FromHtml("#D4763D");
				goto IL_139;
			}
			IL_382:
			this.x163e7df4fee4bb56 = ColorTranslator.FromHtml("#F4F4F4");
			if (this.GroupHeaderStyle == Office2007GroupHeaderStyle.Divider)
			{
				this.xd17c882aa378b7de = ColorTranslator.FromHtml("#616A76");
				this.x1c87970653553277 = ColorTranslator.FromHtml("#9199A4");
			}
			else
			{
				this.xd17c882aa378b7de = ColorTranslator.FromHtml("#000000");
				this.x1c87970653553277 = ColorTranslator.FromHtml("#A7ADB6");
				this.x7b13f9061235e3c5 = ColorTranslator.FromHtml("#DDE0E3");
				this.x3a56fc7b53ec6368 = ColorTranslator.FromHtml("#F0F1F2");
				this.x633077f4e131f59c = ColorTranslator.FromHtml("#E8EAEC");
				this.x89197013acca3dca = ColorTranslator.FromHtml("#FFFFFF");
				this.x1faec58713e797e9 = ColorTranslator.FromHtml("#313431");
				this.x23f8c528d8372ea4 = ColorTranslator.FromHtml("#FFFFFF");
				this.x447d2008d9c0a14a = ColorTranslator.FromHtml("#C7CBD1");
			}
			this.xc1cd15c3abb9387d = ColorTranslator.FromHtml("#EDEDED");
			this.xb8b65e16c1ede3ad = ColorTranslator.FromHtml("#B6B6B6");
			this.x725cf8a1f751cfc6 = ColorTranslator.FromHtml("#F1C05C");
			this.xc94f4cb44dd95fe8 = ColorTranslator.FromHtml("#B6B6B6");
			this.xf9c68aa7e6f8675b = ColorTranslator.FromHtml("#FFD58D");
			this.xe14524446c5db6c4 = ColorTranslator.FromHtml("#F29536");
			return;
			IL_480:
			this.x7d3322d4cf65c759 = ColorTranslator.FromHtml("#F8F8F8");
			this.x36c3c9abc1ae7d73 = ColorTranslator.FromHtml("#DFDFDF");
			this.xd59160d3a6a4dcab = ColorTranslator.FromHtml("#B6B6B6");
			this.x74e99381f240b01e = ColorTranslator.FromHtml("#E0E0E0");
			this.x39701e57bb3ae4c2 = ColorTranslator.FromHtml("#C4C4C4");
			this.x48476da2f66b8fbc = ColorTranslator.FromHtml("#B6B6B6");
			this.xc9a32f8ab3af9bda = ColorTranslator.FromHtml("#F9D99F");
			this.xaf0d35c621caeda8 = ColorTranslator.FromHtml("#F2C260");
			this.xc5dba97deb5a0809 = ColorTranslator.FromHtml("#F29536");
			goto IL_382;
			Block_5:
			this.xd59160d3a6a4dcab = (this.x48476da2f66b8fbc = (this.xc5dba97deb5a0809 = ColorTranslator.FromHtml("#4C535C")));
			goto IL_382;
			IL_5CC:
			this.xc1cd15c3abb9387d = ColorTranslator.FromHtml("#E4ECF7");
			this.xb8b65e16c1ede3ad = ColorTranslator.FromHtml("#9EB6CE");
			this.x725cf8a1f751cfc6 = ColorTranslator.FromHtml("#BBC4D1");
			this.xc94f4cb44dd95fe8 = ColorTranslator.FromHtml("#879FB7");
			this.xf9c68aa7e6f8675b = ColorTranslator.FromHtml("#FFD58D");
			this.xe14524446c5db6c4 = ColorTranslator.FromHtml("#F29536");
			return;
			IL_629:
			this.x1c87970653553277 = ColorTranslator.FromHtml("#6593CF");
			this.x7b13f9061235e3c5 = ColorTranslator.FromHtml("#D6E8FF");
			this.x3a56fc7b53ec6368 = ColorTranslator.FromHtml("#E2EEFF");
			this.x633077f4e131f59c = ColorTranslator.FromHtml("#E3EFFF");
			this.x89197013acca3dca = ColorTranslator.FromHtml("#FFFFFF");
			this.x1faec58713e797e9 = ColorTranslator.FromHtml("#567DB1");
			this.x23f8c528d8372ea4 = ColorTranslator.FromHtml("#FFFFFF");
			this.x447d2008d9c0a14a = ColorTranslator.FromHtml("#ADD1FF");
			goto IL_5CC;
			Block_8:
			this.xd17c882aa378b7de = ColorTranslator.FromHtml("#3764A0");
			this.x1c87970653553277 = ColorTranslator.FromHtml("#6F9DD9");
			goto IL_5CC;
			IL_82B:
			goto IL_629;
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0001CF18 File Offset: 0x0001BF18
		protected virtual void OnRedrawNeeded(EventArgs e)
		{
			if (this.x5e7a70d58e13247a != null)
			{
				this.x5e7a70d58e13247a(this, e);
			}
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0001CF30 File Offset: 0x0001BF30
		public virtual void DrawColumnHeader(Graphics graphics, GridColumn column, Rectangle bounds, TextFormattingInformation textFormat, DrawItemState state)
		{
			Color color;
			Color color2;
			Color color3;
			if (column != null && column.Grid.SandGrid != null && column.Grid.SandGrid.xf280efb186af0af5 == column)
			{
				color = this.xc9a32f8ab3af9bda;
				color2 = this.xaf0d35c621caeda8;
				color3 = this.xc5dba97deb5a0809;
			}
			else if ((state & DrawItemState.Hot) == DrawItemState.Hot)
			{
				color = this.x74e99381f240b01e;
				color2 = this.x39701e57bb3ae4c2;
				color3 = this.x48476da2f66b8fbc;
			}
			else
			{
				color = this.x7d3322d4cf65c759;
				color2 = this.x36c3c9abc1ae7d73;
				color3 = this.xd59160d3a6a4dcab;
			}
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(bounds.Left, bounds.Top - 1), new Point(bounds.Left, bounds.Bottom), color, color2))
			{
				graphics.FillRectangle(linearGradientBrush, bounds);
			}
			using (Pen pen = new Pen(color3))
			{
				graphics.DrawLine(pen, bounds.X, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
				graphics.DrawLine(pen, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
			}
			if (column != null)
			{
				bounds = column.TextBounds;
				if (bounds.Width >= 6)
				{
					if ((state & DrawItemState.Pushed) == DrawItemState.Pushed)
					{
						bounds.Offset(1, 1);
					}
					IndependentText.DrawText(graphics, column.HeaderText, column.Font, bounds, textFormat, SystemColors.ControlText, SystemBrushes.ControlText);
				}
				if (column.HeaderImage != null && column.ImageBounds != Rectangle.Empty)
				{
					bounds = column.ImageBounds;
					if ((state & DrawItemState.Pushed) == DrawItemState.Pushed)
					{
						bounds.Offset(1, 1);
					}
					graphics.DrawImage(column.HeaderImage, bounds);
				}
				if (column.SortOrder != SortOrder.None)
				{
					SmoothingMode smoothingMode = graphics.SmoothingMode;
					graphics.SmoothingMode = SmoothingMode.AntiAlias;
					int num = ((column.HeaderHorizontalAlignment == StringAlignment.Far && !column.Grid.RightToLeft) || (column.HeaderHorizontalAlignment == StringAlignment.Near && column.Grid.RightToLeft)) ? column.TextBounds.Left : (column.TextBounds.Right - 7);
					if (num < column.TextBounds.Right - 5 && num >= column.TextBounds.Left)
					{
						Point point = new Point(num + 4, column.Bounds.Top + 4);
						Point point2 = new Point(num + 4, column.Bounds.Bottom - 5);
						Point pt = (column.SortOrder == SortOrder.Descending) ? point : point2;
						Point pt2 = (column.SortOrder == SortOrder.Descending) ? point2 : point;
						using (Pen pen2 = this.x1935640251735a20(Color.White, 2.5f))
						{
							graphics.DrawLine(pen2, pt, pt2);
						}
						using (Pen pen3 = this.x1935640251735a20(Color.Black, 1f))
						{
							graphics.DrawLine(pen3, pt, pt2);
						}
					}
					graphics.SmoothingMode = smoothingMode;
				}
			}
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x0001D2F4 File Offset: 0x0001C2F4
		private Pen x1935640251735a20(Color x6c50a99faab7d741, float x36b678ec7f34e1b6)
		{
			return new Pen(x6c50a99faab7d741, x36b678ec7f34e1b6)
			{
				EndCap = LineCap.ArrowAnchor
			};
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0001D314 File Offset: 0x0001C314
		public virtual void DrawRowHeader(Graphics graphics, GridRow row, Rectangle bounds, TextFormattingInformation textFormat, DrawItemState state)
		{
			bool flag = (state & DrawItemState.Hot) == DrawItemState.Hot;
			bool flag2 = row != null && row.Grid.SandGrid != null && row.Grid.SandGrid.xda48682af7b76596 == row;
			Color color = flag ? this.x725cf8a1f751cfc6 : this.xc1cd15c3abb9387d;
			if (flag2)
			{
				color = this.xf9c68aa7e6f8675b;
			}
			using (SolidBrush solidBrush = new SolidBrush(color))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			Color color2 = flag ? this.xc94f4cb44dd95fe8 : this.xb8b65e16c1ede3ad;
			if (flag2)
			{
				color2 = this.xe14524446c5db6c4;
			}
			using (Pen pen = new Pen(color2))
			{
				graphics.DrawLine(pen, bounds.Right - 1, bounds.Y, bounds.Right - 1, bounds.Bottom - 1);
				graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
				if (flag2)
				{
					graphics.DrawLine(pen, bounds.Left, bounds.Y - 1, bounds.Right - 1, bounds.Y - 1);
				}
			}
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0001D474 File Offset: 0x0001C474
		public virtual void DrawExpandButton(Graphics graphics, Rectangle bounds, bool expanded)
		{
			if (expanded)
			{
				graphics.DrawImageUnscaled(Office2007Renderer.xe6f4b92cdeb7842c, bounds.Left, bounds.Top);
				return;
			}
			graphics.DrawImageUnscaled(Office2007Renderer.x049829b2565ec461, bounds.Left, bounds.Top);
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x0001D4AC File Offset: 0x0001C4AC
		public virtual void DrawRubberBandSelection(Graphics graphics, Rectangle bounds)
		{
			using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(70, this.SelectionFocusedBackgroundColor)))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
			using (Pen pen = new Pen(this.SelectionFocusedBackgroundColor))
			{
				graphics.DrawRectangle(pen, bounds);
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x0001D534 File Offset: 0x0001C534
		public virtual void DrawSelectionRectangle(Graphics graphics, Rectangle bounds, bool selected, bool focused, bool focusRectangle)
		{
			Color window = SystemColors.Window;
			if (selected)
			{
				Brush brush;
				if (focused)
				{
					brush = new SolidBrush(this.x1f8082dd5747ff1b);
					window = this.x1f8082dd5747ff1b;
				}
				else
				{
					brush = new SolidBrush(this.x90d5feec11e1056b);
					window = this.x90d5feec11e1056b;
				}
				graphics.FillRectangle(brush, bounds);
				brush.Dispose();
			}
			if (focused && focusRectangle)
			{
				ControlPaint.DrawFocusRectangle(graphics, bounds, window, window);
			}
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0001D598 File Offset: 0x0001C598
		public virtual Pen CreateTreeHierarchyLinePen()
		{
			return new Pen(SystemColors.GrayText)
			{
				DashStyle = DashStyle.Dot
			};
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0001D5B8 File Offset: 0x0001C5B8
		public virtual Pen CreateGridLinePen()
		{
			return new Pen(this.x57dd8cbd69f9704d);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x0001D5C8 File Offset: 0x0001C5C8
		public virtual Pen CreateResizeHintPen()
		{
			return new Pen(Color.FromArgb(200, SystemColors.WindowText), 2f);
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x0001D5E4 File Offset: 0x0001C5E4
		public virtual Brush CreateAlternateRowBackgroundBrush(GridRow row, Rectangle bounds)
		{
			return new SolidBrush(this.x163e7df4fee4bb56);
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0001D5F4 File Offset: 0x0001C5F4
		public virtual void DrawSortedColumnBackground(Graphics graphics, GridColumn column, Rectangle bounds)
		{
			if (SystemInformation.HighContrast)
			{
				return;
			}
			if (this.ColumnShade == ColumnShadeType.None)
			{
				return;
			}
			if (this.ColumnShade == ColumnShadeType.SortOnly && column.Grid.GroupColumn != null)
			{
				return;
			}
			Color color = DrawingMethods.InterpolateColors(SystemColors.Control, SystemColors.Window, 0.77f);
			using (SolidBrush solidBrush = new SolidBrush(color))
			{
				graphics.FillRectangle(solidBrush, bounds);
			}
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0001D678 File Offset: 0x0001C678
		public virtual void DrawGroupHeading(Graphics graphics, GridGroup group, Rectangle bounds, Font font, DrawItemState state, GridColumn[] columns, TextFormattingInformation[] textFormats)
		{
			using (TextFormattingInformation xae3b2752a89e = TextFormattingInformation.CreateFormattingInformation(group.Grid.RightToLeft, false, StringAlignment.Near, StringAlignment.Center, false))
			{
				if (this.GroupHeaderStyle == Office2007GroupHeaderStyle.Divider)
				{
					this.xc35de1b60d89fb2f(graphics, group, bounds, font, xae3b2752a89e);
				}
				else
				{
					this.x026107d7b560dce1(graphics, group, bounds, font, state, xae3b2752a89e);
				}
			}
		}

		// Token: 0x060005B7 RID: 1463 RVA: 0x0001D6EC File Offset: 0x0001C6EC
		private void x026107d7b560dce1(Graphics x41347a961b838962, GridGroup xe2c9497bf778cd2b, Rectangle xda73fcb97c77d998, Font x26094932cf7a9139, DrawItemState x01b557925841ae51, TextFormattingInformation xae3b2752a89e7464)
		{
			if (xda73fcb97c77d998.Y == 0)
			{
				xda73fcb97c77d998.Y--;
				xda73fcb97c77d998.Height++;
			}
			bool flag = (x01b557925841ae51 & DrawItemState.Hot) == DrawItemState.Hot;
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, flag ? this.x633077f4e131f59c : this.x7b13f9061235e3c5, flag ? this.x89197013acca3dca : this.x3a56fc7b53ec6368, LinearGradientMode.Horizontal))
			{
				Blend blend = new Blend(3);
				blend.Positions[0] = 0f;
				blend.Factors[0] = 0f;
				blend.Positions[1] = 0.5f;
				blend.Factors[1] = 1f;
				blend.Positions[2] = 1f;
				blend.Factors[2] = 0f;
				linearGradientBrush.Blend = blend;
				x41347a961b838962.FillRectangle(linearGradientBrush, xda73fcb97c77d998);
			}
			using (Pen pen = new Pen(this.x1c87970653553277))
			{
				x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Y);
			}
			using (Pen pen2 = new Pen(this.x23f8c528d8372ea4))
			{
				x41347a961b838962.DrawLines(pen2, new Point[]
				{
					new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Bottom - 2),
					new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Y + 1),
					new Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Y + 1)
				});
			}
			using (Pen pen3 = new Pen(this.x447d2008d9c0a14a))
			{
				x41347a961b838962.DrawLine(pen3, xda73fcb97c77d998.X, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1);
			}
			xda73fcb97c77d998.Inflate(-9, -1);
			xda73fcb97c77d998.Width -= 7;
			using (Font font = new Font(x26094932cf7a9139, FontStyle.Bold))
			{
				IndependentText.DrawText(x41347a961b838962, xe2c9497bf778cd2b.Text, font, xda73fcb97c77d998, xae3b2752a89e7464, this.xd17c882aa378b7de);
			}
			if (xe2c9497bf778cd2b.Grid.AllowGroupCollapse)
			{
				xda73fcb97c77d998.X = xda73fcb97c77d998.Right + 2;
				xda73fcb97c77d998.Width = 7;
				xda73fcb97c77d998.Y = xda73fcb97c77d998.Y + xda73fcb97c77d998.Height / 2 - 4;
				xda73fcb97c77d998.Height = 8;
				using (Pen pen4 = new Pen(this.x1faec58713e797e9))
				{
					if (xe2c9497bf778cd2b.Expanded)
					{
						x41347a961b838962.DrawLines(pen4, new Point[]
						{
							new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Y + 3),
							new Point(xda73fcb97c77d998.X + 3, xda73fcb97c77d998.Y),
							new Point(xda73fcb97c77d998.X + 6, xda73fcb97c77d998.Y + 3)
						});
						x41347a961b838962.DrawLines(pen4, new Point[]
						{
							new Point(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y + 3),
							new Point(xda73fcb97c77d998.X + 3, xda73fcb97c77d998.Y + 1),
							new Point(xda73fcb97c77d998.X + 5, xda73fcb97c77d998.Y + 3)
						});
						x41347a961b838962.DrawLines(pen4, new Point[]
						{
							new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Y + 7),
							new Point(xda73fcb97c77d998.X + 3, xda73fcb97c77d998.Y + 4),
							new Point(xda73fcb97c77d998.X + 6, xda73fcb97c77d998.Y + 7)
						});
						x41347a961b838962.DrawLines(pen4, new Point[]
						{
							new Point(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y + 7),
							new Point(xda73fcb97c77d998.X + 3, xda73fcb97c77d998.Y + 5),
							new Point(xda73fcb97c77d998.X + 5, xda73fcb97c77d998.Y + 7)
						});
					}
					else
					{
						x41347a961b838962.DrawLines(pen4, new Point[]
						{
							new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Y),
							new Point(xda73fcb97c77d998.X + 3, xda73fcb97c77d998.Y + 3),
							new Point(xda73fcb97c77d998.X + 6, xda73fcb97c77d998.Y)
						});
						x41347a961b838962.DrawLines(pen4, new Point[]
						{
							new Point(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y),
							new Point(xda73fcb97c77d998.X + 3, xda73fcb97c77d998.Y + 2),
							new Point(xda73fcb97c77d998.X + 5, xda73fcb97c77d998.Y)
						});
						x41347a961b838962.DrawLines(pen4, new Point[]
						{
							new Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Y + 4),
							new Point(xda73fcb97c77d998.X + 3, xda73fcb97c77d998.Y + 7),
							new Point(xda73fcb97c77d998.X + 6, xda73fcb97c77d998.Y + 4)
						});
						x41347a961b838962.DrawLines(pen4, new Point[]
						{
							new Point(xda73fcb97c77d998.X + 1, xda73fcb97c77d998.Y + 4),
							new Point(xda73fcb97c77d998.X + 3, xda73fcb97c77d998.Y + 6),
							new Point(xda73fcb97c77d998.X + 5, xda73fcb97c77d998.Y + 4)
						});
					}
				}
			}
		}

		// Token: 0x060005B8 RID: 1464 RVA: 0x0001DE08 File Offset: 0x0001CE08
		private void xc35de1b60d89fb2f(Graphics x41347a961b838962, GridGroup xe2c9497bf778cd2b, Rectangle xda73fcb97c77d998, Font x26094932cf7a9139, TextFormattingInformation xae3b2752a89e7464)
		{
			if (xe2c9497bf778cd2b.Grid.AllowGroupCollapse)
			{
				if (xe2c9497bf778cd2b.Expanded)
				{
					x41347a961b838962.DrawImageUnscaled(Office2007Renderer.x5e0d9f3980adaa5d, xe2c9497bf778cd2b.ExpandButtonBounds);
				}
				else
				{
					x41347a961b838962.DrawImageUnscaled(Office2007Renderer.x184a7c40e4cd7db4, xe2c9497bf778cd2b.ExpandButtonBounds);
				}
			}
			using (Font font = new Font(x26094932cf7a9139, FontStyle.Bold))
			{
				int num = (int)((double)xda73fcb97c77d998.Height * 0.26);
				Rectangle bounds = new Rectangle(xda73fcb97c77d998.Left + 20, xda73fcb97c77d998.Top + num, xda73fcb97c77d998.Width - 20, xda73fcb97c77d998.Height - num);
				IndependentText.DrawText(x41347a961b838962, xe2c9497bf778cd2b.Text, font, bounds, xae3b2752a89e7464, xe2c9497bf778cd2b.Selected ? SystemColors.WindowText : this.xd17c882aa378b7de);
				Rectangle rect = new Rectangle(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 3, xda73fcb97c77d998.Width, 2);
				using (SolidBrush solidBrush = new SolidBrush(this.x1c87970653553277))
				{
					x41347a961b838962.FillRectangle(solidBrush, rect);
				}
			}
		}

		// Token: 0x060005B9 RID: 1465 RVA: 0x0001DF40 File Offset: 0x0001CF40
		public virtual Rectangle CalculateGroupHeadingExpandButtonBounds(GridGroup group)
		{
			if (this.GroupHeaderStyle == Office2007GroupHeaderStyle.Divider)
			{
				Rectangle bounds = group.Bounds;
				bounds.X += 2;
				bounds.Y = bounds.Bottom - 11 - 9;
				bounds.Size = new Size(11, 11);
				return bounds;
			}
			return group.Bounds;
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x0001DF98 File Offset: 0x0001CF98
		public virtual void DrawNestedGridBorder(Graphics graphics, InnerGrid grid, Rectangle gridBounds)
		{
			Rectangle rectangle = gridBounds;
			bool terminalServerSession = SystemInformation.TerminalServerSession;
			if (this.x15edd106dba2f3b0 && !SystemInformation.HighContrast && !terminalServerSession)
			{
				rectangle.Offset(1, 1);
				rectangle.Inflate(-2, -2);
				DrawingMethods.DrawDropShadow(graphics, rectangle, 5, (grid.SandGrid.ActiveGrid == grid) ? SystemColors.Highlight : Color.Black);
				return;
			}
			rectangle.Offset(-1, -1);
			rectangle.Width++;
			rectangle.Height++;
			graphics.DrawRectangle(SystemPens.ControlDark, rectangle);
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x0001E02C File Offset: 0x0001D02C
		public bool DrawGridBorder(Graphics graphics, Rectangle bounds)
		{
			if (this.x2bac484d59d27d03)
			{
				VisualStyleElement normal = VisualStyleElement.TextBox.TextEdit.Normal;
				VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(normal);
				visualStyleRenderer.DrawBackground(graphics, bounds);
				return true;
			}
			return false;
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x0001E05C File Offset: 0x0001D05C
		private bool x2bac484d59d27d03
		{
			get
			{
				VisualStyleElement normal = VisualStyleElement.TextBox.TextEdit.Normal;
				return Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(normal);
			}
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0001E080 File Offset: 0x0001D080
		public virtual void DrawGlyph(Graphics graphics, Rectangle bounds, SandGridGlyphType glyphType)
		{
			switch (glyphType)
			{
			case SandGridGlyphType.EditMode:
				graphics.DrawImage(Office2007Renderer.x3bdc93f4d0202b0e, bounds.X + bounds.Width / 2 - Office2007Renderer.x3bdc93f4d0202b0e.Width / 2, bounds.Y + bounds.Height / 2 - Office2007Renderer.x3bdc93f4d0202b0e.Height / 2);
				return;
			case SandGridGlyphType.CurrentRow:
				break;
			case SandGridGlyphType.Error:
				graphics.DrawImage(Office2007Renderer.xef0187f549dd9707, bounds.X + bounds.Width / 2 - Office2007Renderer.xef0187f549dd9707.Width / 2, bounds.Y + bounds.Height / 2 - Office2007Renderer.xef0187f549dd9707.Height / 2);
				break;
			default:
				return;
			}
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x0001E134 File Offset: 0x0001D134
		public virtual void DrawCorner(Graphics graphics, Rectangle bounds)
		{
			using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new Point(bounds.X, bounds.Y), new Point(bounds.Right, bounds.Bottom), this.x7d3322d4cf65c759, this.x36c3c9abc1ae7d73))
			{
				graphics.FillRectangle(linearGradientBrush, bounds);
			}
			using (Pen pen = new Pen(this.xd59160d3a6a4dcab))
			{
				graphics.DrawLine(pen, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
			}
			using (Pen pen2 = new Pen(this.xb8b65e16c1ede3ad))
			{
				graphics.DrawLine(pen2, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
			}
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x0001E25C File Offset: 0x0001D25C
		public virtual void DrawCheckBox(Graphics graphics, Rectangle bounds, CheckState checkState)
		{
			VisualStyleElement element = VisualStyleElement.Button.CheckBox.UncheckedNormal;
			int num;
			for (;;)
			{
				IL_102:
				if (checkState == CheckState.Checked)
				{
					element = VisualStyleElement.Button.CheckBox.CheckedNormal;
				}
				if (checkState == CheckState.Indeterminate)
				{
					element = VisualStyleElement.Button.CheckBox.MixedNormal;
				}
				if (Application.RenderWithVisualStyles && VisualStyleRenderer.IsElementDefined(element))
				{
					break;
				}
				bounds.Width -= 2;
				bounds.Height -= 2;
				using (Pen pen = new Pen(SystemColors.WindowText, 2f))
				{
					graphics.DrawRectangle(pen, bounds);
				}
				if (checkState == CheckState.Checked)
				{
					goto Block_9;
				}
				while (checkState == CheckState.Indeterminate)
				{
					if ((uint)num >= 0U)
					{
						bounds.Inflate(-3, -3);
						using (SolidBrush solidBrush = new SolidBrush(SystemColors.GrayText))
						{
							graphics.FillRectangle(solidBrush, bounds);
							break;
						}
						goto IL_102;
					}
				}
				return;
			}
			VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(element);
			visualStyleRenderer.DrawBackground(graphics, bounds);
			return;
			Block_9:
			num = bounds.X + bounds.Width / 2;
			int num2 = bounds.Y + bounds.Height / 2;
			Point[] points = new Point[]
			{
				new Point(num - 3, num2 - 2),
				new Point(num - 1, num2 + 1),
				new Point(num + 4, num2 - 4),
				new Point(num + 4, num2 - 1),
				new Point(num - 1, num2 + 4),
				new Point(num - 3, num2 + 1)
			};
			graphics.FillPolygon(SystemBrushes.WindowText, points);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x0001E450 File Offset: 0x0001D450
		public virtual void DrawProgressBar(Graphics graphics, Rectangle bounds, int minimum, int maximum, int value)
		{
			float num = ((float)value - (float)minimum) / (float)(maximum - minimum);
			if (ProgressBarRenderer.IsSupported)
			{
				ProgressBarRenderer.DrawHorizontalBar(graphics, bounds);
				bounds.Inflate(-ProgressBarRenderer.ChunkSpaceThickness * 2, -ProgressBarRenderer.ChunkThickness / 2);
				bounds.Width = Convert.ToInt32((float)bounds.Width * num);
				ProgressBarRenderer.DrawHorizontalChunks(graphics, bounds);
				return;
			}
			graphics.FillRectangle(SystemBrushes.Window, bounds);
			int width = (int)((float)bounds.Width * num);
			graphics.FillRectangle(SystemBrushes.Highlight, bounds.X, bounds.Y, width, bounds.Height);
			graphics.DrawRectangle(SystemPens.ControlText, bounds);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x0001E4F4 File Offset: 0x0001D4F4
		public virtual Color GetSelectedTextColor(bool focused)
		{
			if (focused)
			{
				return this.x71cf5537386d2d31;
			}
			return this.x1225ae3a9a2de58d;
		}

		// Token: 0x040001FA RID: 506
		private static Image xe6f4b92cdeb7842c = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.o2k7-expanded.png"));

		// Token: 0x040001FB RID: 507
		private static Image x049829b2565ec461 = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.o2k7-collapsed.png"));

		// Token: 0x040001FC RID: 508
		private static Image x5e0d9f3980adaa5d = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.o2k7-expanded-large.png"));

		// Token: 0x040001FD RID: 509
		private static Image x184a7c40e4cd7db4 = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.o2k7-collapsed-large.png"));

		// Token: 0x040001FE RID: 510
		private static Image x3bdc93f4d0202b0e = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.pencil.gif"));

		// Token: 0x040001FF RID: 511
		private static Image xef0187f549dd9707 = Image.FromStream(typeof(WindowsXPRenderer).Assembly.GetManifestResourceStream("Divelements.SandGrid.Resources.error.png"));

		// Token: 0x04000200 RID: 512
		private Color x57dd8cbd69f9704d;

		// Token: 0x04000201 RID: 513
		private Color x1f8082dd5747ff1b;

		// Token: 0x04000202 RID: 514
		private Color x90d5feec11e1056b;

		// Token: 0x04000203 RID: 515
		private Color x71cf5537386d2d31;

		// Token: 0x04000204 RID: 516
		private Color x1225ae3a9a2de58d;

		// Token: 0x04000205 RID: 517
		private Color x7d3322d4cf65c759;

		// Token: 0x04000206 RID: 518
		private Color x36c3c9abc1ae7d73;

		// Token: 0x04000207 RID: 519
		private Color xd59160d3a6a4dcab;

		// Token: 0x04000208 RID: 520
		private Color x74e99381f240b01e;

		// Token: 0x04000209 RID: 521
		private Color x39701e57bb3ae4c2;

		// Token: 0x0400020A RID: 522
		private Color x48476da2f66b8fbc;

		// Token: 0x0400020B RID: 523
		private Color xc9a32f8ab3af9bda;

		// Token: 0x0400020C RID: 524
		private Color xaf0d35c621caeda8;

		// Token: 0x0400020D RID: 525
		private Color xc5dba97deb5a0809;

		// Token: 0x0400020E RID: 526
		private Color x163e7df4fee4bb56;

		// Token: 0x0400020F RID: 527
		private Color xd17c882aa378b7de;

		// Token: 0x04000210 RID: 528
		private Color x1c87970653553277;

		// Token: 0x04000211 RID: 529
		private Color x23f8c528d8372ea4;

		// Token: 0x04000212 RID: 530
		private Color x447d2008d9c0a14a;

		// Token: 0x04000213 RID: 531
		private Color x1faec58713e797e9;

		// Token: 0x04000214 RID: 532
		private Color x7b13f9061235e3c5;

		// Token: 0x04000215 RID: 533
		private Color x3a56fc7b53ec6368;

		// Token: 0x04000216 RID: 534
		private Color x633077f4e131f59c;

		// Token: 0x04000217 RID: 535
		private Color x89197013acca3dca;

		// Token: 0x04000218 RID: 536
		private Color xc1cd15c3abb9387d;

		// Token: 0x04000219 RID: 537
		private Color xb8b65e16c1ede3ad;

		// Token: 0x0400021A RID: 538
		private Color x725cf8a1f751cfc6;

		// Token: 0x0400021B RID: 539
		private Color xc94f4cb44dd95fe8;

		// Token: 0x0400021C RID: 540
		private Color xf9c68aa7e6f8675b;

		// Token: 0x0400021D RID: 541
		private Color xe14524446c5db6c4;

		// Token: 0x0400021E RID: 542
		private Office2007ColorScheme x62a65b2c0f145432 = (Office2007ColorScheme)(-1);

		// Token: 0x0400021F RID: 543
		private Office2007ColumnHeaderStyle x633fa6d139f34c16;

		// Token: 0x04000220 RID: 544
		private Office2007GroupHeaderStyle x1f5c00ac423c687a;

		// Token: 0x04000221 RID: 545
		private ColumnShadeType x7508f055717dd2c8 = ColumnShadeType.SortOnly;

		// Token: 0x04000222 RID: 546
		private bool x15edd106dba2f3b0 = true;

		// Token: 0x04000223 RID: 547
		private EventHandler x5e7a70d58e13247a;
	}
}

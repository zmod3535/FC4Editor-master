using System;
using System.IO;
using System.Reflection;
using System.Xml;
using Ubisoft;

namespace IGE.ViewModels
{
	// Token: 0x02000104 RID: 260
	public class AboutWindowViewModel : ViewModel
	{
		// Token: 0x0600091C RID: 2332 RVA: 0x0001E520 File Offset: 0x0001C720
		public AboutWindowViewModel()
		{
			string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().FullName);
			string text;
			Win32.GetPrivateProfileStringW("FC2_INIT", "language", "english", out text, directoryName);
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml("<?xml version=\"1.0\" encoding=\"utf-16\"?><IGESplashLoc><english><string enum=\"LOADING_GAMEFILE\" value=\"Loading...\" /><string enum=\"EDITOR_NAME\" value=\"FarCry®4 Map Editor\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. All Rights Reserved. Far\u00a0Cry®, Ubisoft and the Ubisoft logo are trademarks of Ubisoft Entertainment in the US and/or other countries. Based on Crytek's original Far\u00a0Cry® directed by Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Loading FarCry®4 Map Editor...\" /></english><french><string enum=\"LOADING_GAMEFILE\" value=\"Chargement...\" /><string enum=\"EDITOR_NAME\" value=\"FarCry®4 Éditeur de cartes\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Tous droits réservés. Far Cry®, Ubisoft et le logo Ubisoft sont des marques commerciales aux États-Unis et/ou dans d'autres pays. Basé sur le jeu original Far Cry® de Crytek dirigé par Cevat Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Chargement de l'Éditeur de cartes de FarCry®4...\" /></french><czech><string enum=\"LOADING_GAMEFILE\" value=\"Nahrávání...\" /><string enum=\"EDITOR_NAME\" value=\"Editor map FarCry®4\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Všechna práva vyhrazena. Far\u00a0Cry®, Ubisoft a logo Ubisoft jsou registrované obchodní známky spolecnosti Ubisoft Entertainment ve Spojených státech a/nebo dalších zemích. Založeno na originálním Far\u00a0Cry® spolecnosti Crytek, jehož výrobu vedl Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Nacítání editoru map FarCry®4...\" /></czech><german><string enum=\"LOADING_GAMEFILE\" value=\"Lädt...\" /><string enum=\"EDITOR_NAME\" value=\"FarCry®4 Karten-Editor\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Alle Rechte vorbehalten. Far\u00a0Cry®, Ubisoft und das Ubisoft-Logo sind Warenzeichen von Ubisoft Entertainment in den USA und/oder anderen Ländern. Basiert auf dem originalen Far\u00a0Cry® von Crytek, unter Regie von Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"FarCry®4 Karten-Editor wird geladen...\" /></german><hungarian><string enum=\"LOADING_GAMEFILE\" value=\"Töltés...\" /><string enum=\"EDITOR_NAME\" value=\"FarCry®4 térképszerkeszto\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Minden jog nfenntartva. A Far\u00a0Cry, A Ubisoft és a Ubisoft embléma a Ubisoft Entertainment védjegyei ez Egyesült Államokban és/vagy más országokban. Acrytek eredtei Far\u00a0Cry® játéka alapján rendezte Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"A FarCry® 2 térképszerkeszto betöltése...\" /></hungarian><italian><string enum=\"LOADING_GAMEFILE\" value=\"Caricamento...\" /><string enum=\"EDITOR_NAME\" value=\"Editor mappa FarCry®4\" /> <string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Tutti i diritti riservati. Far\u00a0Cry®, Ubisoft e il logo Ubisoft sono marchi di Ubisoft Entertainment negli Stati Uniti e/o negli altri paesi. Basato sull'originale Crytek's Far\u00a0Cry® diretto da Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Caricamento dell'editor mappe di FarCry®4 in corso...\" /></italian><polish><string enum=\"LOADING_GAMEFILE\" value=\"Wczytuje...\" /><string enum=\"EDITOR_NAME\" value=\"Edytor map FarCry®4\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Wszelkie prawa zastrzezone. Far\u00a0Cry®, Ubisoft i logotyp Ubisoftu sa znakami handlowymi Ubisoft Entertainment na terenie USA i/lub innych krajów. Oparto na pierwszej wersji Far Cry® firmy Crytek pod kierownictwem Cevata\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Wczytywanie Edytora Map FarCry®4...\" /></polish><spanish><string enum=\"LOADING_GAMEFILE\" value=\"Cargando...\" /><string enum=\"EDITOR_NAME\" value=\"Editor de mapas de FarCry®4\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Todos los derechos reservados. Far\u00a0Cry®, Ubisoft y el logotipo de Ubisoft son marcas comerciales de Ubisoft Entertainment en Estados Unidos y en otros países. Basado en el juego original Far\u00a0Cry®, de Crytek, dirigido por Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Cargando editor de mapas de FarCry®4...\" /></spanish></IGESplashLoc>");
			XmlElement documentElement = xmlDocument.DocumentElement;
			XmlNodeList elementsByTagName = documentElement.GetElementsByTagName(text);
			foreach (object obj in elementsByTagName)
			{
				XmlNode xmlNode = (XmlNode)obj;
				if (xmlNode.Name == text)
				{
					XmlElement xmlElement = (XmlElement)xmlNode;
					foreach (object obj2 in xmlElement.ChildNodes)
					{
						XmlNode xmlNode2 = (XmlNode)obj2;
						string value = xmlNode2.Attributes["enum"].Value;
						string value2 = xmlNode2.Attributes["value"].Value;
						string a;
						if ((a = value) != null)
						{
							if (!(a == "LOADING_GAMEFILE"))
							{
								if (!(a == "EDITOR_NAME"))
								{
									if (a == "TEXT_LEGAL")
									{
										this.Copyright = value2;
									}
								}
								else
								{
									this.EditorTitle = value2;
								}
							}
							else
							{
								this.LoadingText = value2;
							}
						}
					}
				}
			}
		}

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x0001E6B4 File Offset: 0x0001C8B4
		// (set) Token: 0x0600091E RID: 2334 RVA: 0x0001E6BC File Offset: 0x0001C8BC
		public string AboutTitle
		{
			get
			{
				return this._aboutTitle;
			}
			set
			{
				this._aboutTitle = value;
				base.RaisePropertyChanged("AboutTitle");
			}
		}

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x0001E6D0 File Offset: 0x0001C8D0
		// (set) Token: 0x06000920 RID: 2336 RVA: 0x0001E6D8 File Offset: 0x0001C8D8
		public string EditorTitle
		{
			get
			{
				return this._editorTitle;
			}
			set
			{
				this._editorTitle = value;
				base.RaisePropertyChanged("EditorTitle");
			}
		}

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x06000921 RID: 2337 RVA: 0x0001E6EC File Offset: 0x0001C8EC
		// (set) Token: 0x06000922 RID: 2338 RVA: 0x0001E6F4 File Offset: 0x0001C8F4
		public string Copyright
		{
			get
			{
				return this._copyright;
			}
			set
			{
				this._copyright = value;
				base.RaisePropertyChanged("Copyright");
			}
		}

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x0001E708 File Offset: 0x0001C908
		// (set) Token: 0x06000924 RID: 2340 RVA: 0x0001E710 File Offset: 0x0001C910
		public string LoadingText
		{
			get
			{
				return this._loadingText;
			}
			set
			{
				this._loadingText = value;
				base.RaisePropertyChanged("LoadingText");
			}
		}

		// Token: 0x0400046D RID: 1133
		private const string SplashLocalization = "<?xml version=\"1.0\" encoding=\"utf-16\"?><IGESplashLoc><english><string enum=\"LOADING_GAMEFILE\" value=\"Loading...\" /><string enum=\"EDITOR_NAME\" value=\"FarCry®4 Map Editor\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. All Rights Reserved. Far\u00a0Cry®, Ubisoft and the Ubisoft logo are trademarks of Ubisoft Entertainment in the US and/or other countries. Based on Crytek's original Far\u00a0Cry® directed by Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Loading FarCry®4 Map Editor...\" /></english><french><string enum=\"LOADING_GAMEFILE\" value=\"Chargement...\" /><string enum=\"EDITOR_NAME\" value=\"FarCry®4 Éditeur de cartes\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Tous droits réservés. Far Cry®, Ubisoft et le logo Ubisoft sont des marques commerciales aux États-Unis et/ou dans d'autres pays. Basé sur le jeu original Far Cry® de Crytek dirigé par Cevat Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Chargement de l'Éditeur de cartes de FarCry®4...\" /></french><czech><string enum=\"LOADING_GAMEFILE\" value=\"Nahrávání...\" /><string enum=\"EDITOR_NAME\" value=\"Editor map FarCry®4\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Všechna práva vyhrazena. Far\u00a0Cry®, Ubisoft a logo Ubisoft jsou registrované obchodní známky spolecnosti Ubisoft Entertainment ve Spojených státech a/nebo dalších zemích. Založeno na originálním Far\u00a0Cry® spolecnosti Crytek, jehož výrobu vedl Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Nacítání editoru map FarCry®4...\" /></czech><german><string enum=\"LOADING_GAMEFILE\" value=\"Lädt...\" /><string enum=\"EDITOR_NAME\" value=\"FarCry®4 Karten-Editor\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Alle Rechte vorbehalten. Far\u00a0Cry®, Ubisoft und das Ubisoft-Logo sind Warenzeichen von Ubisoft Entertainment in den USA und/oder anderen Ländern. Basiert auf dem originalen Far\u00a0Cry® von Crytek, unter Regie von Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"FarCry®4 Karten-Editor wird geladen...\" /></german><hungarian><string enum=\"LOADING_GAMEFILE\" value=\"Töltés...\" /><string enum=\"EDITOR_NAME\" value=\"FarCry®4 térképszerkeszto\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Minden jog nfenntartva. A Far\u00a0Cry, A Ubisoft és a Ubisoft embléma a Ubisoft Entertainment védjegyei ez Egyesült Államokban és/vagy más országokban. Acrytek eredtei Far\u00a0Cry® játéka alapján rendezte Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"A FarCry® 2 térképszerkeszto betöltése...\" /></hungarian><italian><string enum=\"LOADING_GAMEFILE\" value=\"Caricamento...\" /><string enum=\"EDITOR_NAME\" value=\"Editor mappa FarCry®4\" /> <string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Tutti i diritti riservati. Far\u00a0Cry®, Ubisoft e il logo Ubisoft sono marchi di Ubisoft Entertainment negli Stati Uniti e/o negli altri paesi. Basato sull'originale Crytek's Far\u00a0Cry® diretto da Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Caricamento dell'editor mappe di FarCry®4 in corso...\" /></italian><polish><string enum=\"LOADING_GAMEFILE\" value=\"Wczytuje...\" /><string enum=\"EDITOR_NAME\" value=\"Edytor map FarCry®4\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Wszelkie prawa zastrzezone. Far\u00a0Cry®, Ubisoft i logotyp Ubisoftu sa znakami handlowymi Ubisoft Entertainment na terenie USA i/lub innych krajów. Oparto na pierwszej wersji Far Cry® firmy Crytek pod kierownictwem Cevata\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Wczytywanie Edytora Map FarCry®4...\" /></polish><spanish><string enum=\"LOADING_GAMEFILE\" value=\"Cargando...\" /><string enum=\"EDITOR_NAME\" value=\"Editor de mapas de FarCry®4\" /><string enum=\"TEXT_LEGAL\" value=\"© 2014 Ubisoft Entertainment. Todos los derechos reservados. Far\u00a0Cry®, Ubisoft y el logotipo de Ubisoft son marcas comerciales de Ubisoft Entertainment en Estados Unidos y en otros países. Basado en el juego original Far\u00a0Cry®, de Crytek, dirigido por Cevat\u00a0Yerli.\" /><string enum=\"LOADING_TITLE\" value=\"Cargando editor de mapas de FarCry®4...\" /></spanish></IGESplashLoc>";

		// Token: 0x0400046E RID: 1134
		private string _aboutTitle;

		// Token: 0x0400046F RID: 1135
		private string _editorTitle;

		// Token: 0x04000470 RID: 1136
		private string _copyright;

		// Token: 0x04000471 RID: 1137
		private string _loadingText;
	}
}

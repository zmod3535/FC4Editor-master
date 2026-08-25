using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using IGE.Nomad;

namespace IGE.Controls
{
	// Token: 0x0200012B RID: 299
	public partial class Prompt : Window
	{
		// Token: 0x06000A6E RID: 2670 RVA: 0x000225B5 File Offset: 0x000207B5
		public Prompt()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x000225C3 File Offset: 0x000207C3
		public Prompt(string prompt) : this()
		{
			this.TxtPrompt.Text = prompt;
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x000225D7 File Offset: 0x000207D7
		public Prompt(string prompt, string title) : this(prompt)
		{
			base.Title = title;
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000A71 RID: 2673 RVA: 0x000225E7 File Offset: 0x000207E7
		// (set) Token: 0x06000A72 RID: 2674 RVA: 0x000225F4 File Offset: 0x000207F4
		public string Input
		{
			get
			{
				return this.TxtInput.Text;
			}
			set
			{
				this.TxtInput.Text = value;
			}
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x00022602 File Offset: 0x00020802
		private void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
			this.CloseIfValid();
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0002260A File Offset: 0x0002080A
		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			base.DialogResult = new bool?(false);
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x00022618 File Offset: 0x00020818
		private void TxtInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				this.CloseIfValid();
			}
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0002262C File Offset: 0x0002082C
		private void CloseIfValid()
		{
			string messageBoxText;
			if (this.Validation != null && !this.Validation(this.TxtInput.Text, out messageBoxText))
			{
				MessageBox.Show(this, messageBoxText);
				return;
			}
			base.DialogResult = new bool?(true);
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000A77 RID: 2679 RVA: 0x00022670 File Offset: 0x00020870
		// (set) Token: 0x06000A78 RID: 2680 RVA: 0x00022678 File Offset: 0x00020878
		public Prompt.ValidationDelegate Validation { get; set; }

		// Token: 0x06000A79 RID: 2681 RVA: 0x000226F4 File Offset: 0x000208F4
		public static Prompt.ValidationDelegate GetFloatValidation(float min, float max)
		{
			return delegate(string input, out string message)
			{
				message = null;
				float num;
				if (!float.TryParse(input, out num))
				{
					message = Localizer.Localize("PROMPT_NOT_A_NUMBER", null);
					return false;
				}
				if (num < min || num > max)
				{
					message = string.Format(Localizer.Localize("PROMPT_NUMBER_NOT_IN_RANGE", null), min, max);
					return false;
				}
				return true;
			};
		}

		// Token: 0x0200012C RID: 300
		// (Invoke) Token: 0x06000A7D RID: 2685
		public delegate bool ValidationDelegate(string input, out string message);
	}
}

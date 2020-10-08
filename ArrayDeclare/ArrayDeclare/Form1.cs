using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayDeclare
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnGen_Click(object sender, EventArgs e)
		{
			var input = txtInput.Text.Split(':');
			string valName = input[0].Trim();
			string aryType = input[1].Contains("\"") ? "string" : "int";

			var arys = input[1].Split('\n')
				.Where(x => !string.IsNullOrWhiteSpace(x))
				.Select(x => x.Replace("[", "{").Replace("]", "}"))
				.Select(x => x[0] + $"new {aryType}[] " + x.Substring(1));

			txtResult.Text = $"var {valName} = new {aryType}[][]\n{ string.Join("\n", arys).Trim() };";
		}
	}
}

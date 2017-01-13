
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Statistik
{
	public partial class NewItemName : Form
	{
		public NewItemName()
		{
			InitializeComponent();
			ActiveControl = txtName;
		}
		void btnCancel_Click (object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
		void btnCreate_Click (object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}
		void NewItemName_FormClosing (object sender, FormClosingEventArgs e)
		{
			if(txtName.Text.Length == 0)
			{
				DialogResult a = MessageBox.Show("No name is given. Cancel new statisticsitem?", "No name", MessageBoxButtons.YesNo);
				if (a == DialogResult.No)
				{
					e.Cancel = true;
				} else {
					DialogResult = DialogResult.Cancel;
				}
			}
		}
		public string getName()
		{
			return txtName.Text;
		}
	}
}

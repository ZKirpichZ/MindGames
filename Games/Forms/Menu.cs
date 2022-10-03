using Games.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games.Forms.Training;

namespace Games
{
	public partial class Menu : Form
	{
		public Menu()
		{
			InitializeComponent();
		}

		private void BtnStart_Click(object sender, EventArgs e)
		{
			RegName RegForm = new RegName();
			RegForm.Show();
			this.Hide();
			RegForm.Location = this.Location;
		}

		

        private void BtnExit_Click(object sender, EventArgs e)
        {
			this.Close();
		}

       

        private void BtnStart_MouseEnter(object sender, EventArgs e)
        {
			BtnStart.BackColor = Color.FromArgb(64,64,64);
		}

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
			BtnExit.BackColor = Color.FromArgb(64, 64, 64);
		}

        private void BtnStart_MouseLeave(object sender, EventArgs e)
        {
			BtnStart.BackColor = Color.FromArgb(32, 32, 32);
		}

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
			BtnExit.BackColor = Color.FromArgb(32, 32, 32);
		}

      

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
			Environment.Exit(0);
		}
    }
}

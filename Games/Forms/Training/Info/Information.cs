using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games.Forms.Training.Info
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }
        private Point MouseHook;
        

        private void panel1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

    
    }
}

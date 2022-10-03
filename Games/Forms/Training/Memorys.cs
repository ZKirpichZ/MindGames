using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games.Forms.Training.Info;
namespace Games.Forms.Training
{
    public partial class Memorys : Form
    {
        public Memorys()
        {
            InitializeComponent();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Memorina memorinaForm = new Memorina();
            memorinaForm.Show();
            memorinaForm.Location = this.Location;
            this.Hide();
            
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(64, 64, 64);

        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(32, 32, 32);

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
         
            this.Close();
           
        }

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel2, e);
        }
        public void ColorBorders(Panel panels, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panels.ClientRectangle,
               Color.White, 2, ButtonBorderStyle.Solid,
               Color.White, 2, ButtonBorderStyle.Solid,
               Color.White, 2, ButtonBorderStyle.Solid,
               Color.White, 2, ButtonBorderStyle.Solid);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel1, e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel3, e);
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            
            NumberMemory NumForm = new NumberMemory();
            NumForm.Show();
            NumForm.Location = this.Location;
            this.Hide();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void Memorys_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox4, "Информация");
            ToolTip s = new ToolTip();
            s.SetToolTip(pictureBox7, "Информация");
   
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Меморина «Картинки»";
            infoForm.label2.Text = " «Меморина» - игра в которой нужно переворачивать закрытые карточки, искать на обратной стороне одинаковые картинки и составлять из них пары. Эта игра прекрасно тренирует память и внимание!";
            infoForm.Location = this.Location;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Меморина «Цифры»";
            infoForm.label2.Text = "Усложненная вариация игры «Меморины». Переворачивайте закрытые карточки с помощью мышки, находите одинаковые цифры и составляйте из них пары. Игра тренирует кратковременная память и наблюдательность.";
            infoForm.Location = this.Location;
        }

     

        private void panel3_Click(object sender, EventArgs e)
        {
            Rating RaitForm = new Rating();
            RaitForm.Show();
            RaitForm.Location = this.Location;
            this.Hide();
        }

        private void Memorys_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main mainForm = new Main();
            
            mainForm.Show();
            mainForm.Location = this.Location;
        }
    }
}

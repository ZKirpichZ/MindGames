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
using Games.Forms.Training.Info;

namespace Games.Forms
{
    public partial class Main : Form
    {
       

       public Main()
        {
            InitializeComponent();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {

            panel1.BackColor = Color.FromArgb(64, 64, 64);


        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(32, 32, 32);

        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(64, 64, 64);


        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(32, 32, 32);

        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(64, 64, 64);

        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(32, 32, 32);

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Attentions memForm = new Attentions();
            
            this.Hide();
            memForm.Show();
            memForm.Location = this.Location;

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Memorys memoryForm = new Memorys();
         
            this.Hide();
            memoryForm.Show();
            memoryForm.Location = this.Location;

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Mind mindForm = new Mind();
            this.Hide();
            mindForm.Show();
            mindForm.Location = this.Location;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void BtnStart_MouseEnter(object sender, EventArgs e)
        {
            BtnStart.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void BtnStart_MouseLeave(object sender, EventArgs e)
        {
            BtnStart.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Память";
            infoForm.label2.Text = "Память — одно из свойств нервной системы, заключающееся " +
                "в способности какое-то время сохранять информацию о событиях внешнего мира " +
                "и реакциях организма на эти события, а также многократно воспроизводить и изменять эту информацию.";
            infoForm.Location = this.Location;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Концентрация внимания";
            infoForm.label2.Text = "Концентрация внимания — это свойство внимания, которое представляет собой удержание информации о каком-либо объекте в кратковременной памяти. Человека с нарушением этой функции называют рассеянным.";
            infoForm.Location = this.Location;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Логическое мышление";
            infoForm.label2.Text = "Логическое мышление – это мыслительный процесс, при котором человек использует логические понятия и конструкции, которому свойственна доказательность, рассудительность, и целью которого является получение обоснованного вывода из имеющихся предпосылок.";
            infoForm.Location = this.Location;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel1, e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel2, e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel3,e);
        }

        public void ColorBorders(Panel panels, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panels.ClientRectangle,
               Color.White, 2, ButtonBorderStyle.Solid,
               Color.White, 2, ButtonBorderStyle.Solid,
               Color.White, 2, ButtonBorderStyle.Solid,
               Color.White, 2, ButtonBorderStyle.Solid);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox4, "Информация");
            ToolTip s = new ToolTip();
            s.SetToolTip(pictureBox5, "Информация");
            ToolTip p = new ToolTip();
            p.SetToolTip(pictureBox6, "Информация");

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            RegName RegForm = new RegName();
            RegForm.Show();
            RegForm.Location = this.Location;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel4, e);
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Rating RaitForm = new Rating();
            RaitForm.Show();
            RaitForm.Location = this.Location;
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel5, e);
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(32, 32, 32);
        }
    }
}

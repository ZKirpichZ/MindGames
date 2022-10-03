using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games.Forms;
using Games.Forms.Training.Info;

namespace Games.Forms.Training
{
    

    public partial class Attentions : Form
    {
        public Attentions()
        {
            InitializeComponent();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            TableShulte ts = new TableShulte();
            ts.Show();
            this.Hide();
            ts.Location = this.Location;
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

        private void panel1_Click(object sender, EventArgs e)
        {
       
            LeftUpRightDown LURD = new LeftUpRightDown();
            LURD.Show();
            LURD.Location = this.Location;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel1, e);
        }

        public void ColorBorders(Panel panels, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panels.ClientRectangle,
               Color.White, 2, ButtonBorderStyle.Solid,
               Color.White, 2, ButtonBorderStyle.Solid,
               Color.White, 2, ButtonBorderStyle.Solid,
               Color.White, 2, ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel3, e);
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(64,64,64);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Таблица Шульте";
            infoForm.label2.Font = new Font("Candara Light", 24);

            infoForm.label2.Text = "Таблица Шульте - таблица случайно расположенных чисел. Числа требуется собирать по порядку от 1 до 25. " +
                "Таблицу Шульте необходимо проходить смотря строго в центр таблицы. " +
                "Игра в большей степени развивает концентрацию внимания и периферийное зрение. Что способствует развитию скорочтения.";
            infoForm.Location = this.Location;
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Направления";
            infoForm.label2.Text = "Направления - игра в которой требуется в течение 60 секунд нажимать в ту сторону, в которую смотрит стрелка. Результатом будет количество правильно и неправильно выбранных направлений. Игра очень сильно развивает концентрацию внимания. Облегченная версия, игры «Самолетик».";
            infoForm.Location = this.Location;
        }

        private void Attentions_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main mainForm = new Main();
            mainForm.Show();
            mainForm.Location = this.Location;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Rating RaitForm = new Rating();
            RaitForm.Show();
            RaitForm.Location = this.Location;
            this.Hide();
        }

        private void Attentions_Load(object sender, EventArgs e)
        {
        
            ToolTip s = new ToolTip();
            s.SetToolTip(pictureBox5, "Информация");
            ToolTip p = new ToolTip();
            p.SetToolTip(pictureBox7, "Информация");
        }
    }
}

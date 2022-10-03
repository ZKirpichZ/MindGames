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

namespace Games.Forms.Training
{
    public partial class Mind : Form
    {
        public Mind()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void panel2_Click(object sender, EventArgs e)
        {
           
            fifteen game2 = new fifteen();
            game2.Show();
            game2.Location = this.Location;
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

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
            
            BtnExit.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
           
            panel1.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
           
            Math MathForm = new Math();
            MathForm.Show();
            MathForm.Location = this.Location;
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ColorBorders(panel1, e);
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

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label2.Font = new Font("Candara Light", 24);
            infoForm.label1.Text = "Пятнашки 3x3";
            infoForm.label2.Text = "Игра представляет собою графическую вариацию игры 'Пятнашки'. Вам нужно собрать исходную картинку, перемещая плитки (части этой картинки) за минимально возможное количество шагов за данный случай. Для перемещения плитки нажмите на неё. Исходная картинка представлена справа. " +
                "Игра развивает логическое мышление, усидчивость, логику и способности к анализу.";
            infoForm.Location = this.Location;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label2.Font = new Font("Candara Light", 22);
            infoForm.label1.Text = "Устный счет";
            infoForm.label2.Text = "Устный счет - это игра, в которой вам нужно выбрать правильный вариант ответа из четырех имеющихся. После ста очков игра становится намного сложнее." +
                " Устные вычисления развивают в человеке память, культуру мысли, ее четкость, ясность и быстроту, сообразительность, умение отыскивать наиболее рациональные пути для решения поставленной цели, уверенность в своих силах.";
            infoForm.Location = this.Location;
        }

        private void Mind_FormClosed(object sender, FormClosedEventArgs e)
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

        private void Mind_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox4, "Информация");
            ToolTip s = new ToolTip();
            s.SetToolTip(pictureBox7, "Информация");
      
        }
    }
}

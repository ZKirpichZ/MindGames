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
using System.Data.OleDb;
namespace Games.Forms.Training
{
    public partial class LeftUpRightDown : Form
    {

        List<Bitmap> PictureList = new List<Bitmap>();
        int s;
        Random r = new Random();
        int x = 4;
        float c = 0;
        float g = 0;
        int y;
        float re = 0;
        float ac = 0;
        int z;
        int score = 0;
        

        public LeftUpRightDown()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s--;
            if (s == 0)
            {
                timer1.Stop();
                exit_Information1.Enabled = true;
                re = 60 / (c + g);
                ac = c / (c + g);
                var result = RJMessageBox.Show("Поздравляем! \n Вы набрали " + score + " очков!", "Результат");
                longLabelGames1.Text = "Реакция: " + re.ToString() + '\n' + "Точность: " + ac.ToString();
                longLabelGames1.Visible = true;
                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0;Data Source=bd.mdb");
                string Names = RegName.NameRegD;
                OleDbDataAdapter dad = new OleDbDataAdapter($"INSERT INTO[Направления]([Имя игрока], [Счет]) VALUES('" + Names + "','" + score + "')", con);
                DataTable bes = new DataTable();
                dad.Fill(bes);

            }
            Countdown.Text = s.ToString();
        }


        public void Check(int y)
        {
            PictureList.AddRange(new Bitmap[] { Properties.Resources._1, Properties.Resources._2, Properties.Resources._3, Properties.Resources._4 });
            if (s != 0)
            {
                if (x % 4 == y)
                {
                    c++;
                    score += 10;

                }
                else
                {
                    g++;
                    score -= 5;
                }
                LabelRight.Text = c.ToString();
                LabelWrong.Text = g.ToString();
                ScoreViev.Text = score.ToString(); 
                do
                {
                    x = r.Next(1, 5);
                } while (x == z);
                z = x;
                pictureBox1.Image = PictureList[x-1];
                
            }

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            
           
            

            switch (keyData)
            {


                
                case Keys.Left: 
                    y = 2;
                    Check(y);
                    return true;

                case Keys.Right: 
                    y = 0;
                    Check(y);
                    return true;
                case Keys.Up:
                    y = 3;
                    Check(y);
                    return true;
                case Keys.Down:
                    y = 1;
                    Check(y);
                    return true;



            }

         


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void exit_Information1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            longLabelGames1.Visible = false;
            score = 0;
            s = 60;
            timer1.Start();
            z = 3;
            x = 3;
            c = 0;
            g = 0;
            LabelWrong.Text = "0";
            LabelRight.Text = "0";
            
        }

        private void exit_Information1_MouseEnter(object sender, EventArgs e)
        {
            exit_Information1.BackColor = Color.FromArgb(64,64,64);
        }

        private void exit_Information1_MouseLeave(object sender, EventArgs e)
        {
            exit_Information1.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            button.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            button.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Направления";
            infoForm.label2.Text = "Направления - игра в которой требуется в течение 60 секунд нажимать в ту сторону, в которую смотрит стрелка. Результатом будет количество правильно и неправильно выбранных направлений. Игра очень сильно развивает концентрацию внимания. Облегченная версия, игры «Самолетик».";
            infoForm.Location = this.Location;
        }

        private void LeftUpRightDown_FormClosed(object sender, FormClosedEventArgs e)
        {
            Attentions ATTForm = new Attentions();
            ATTForm.Show();
            ATTForm.Location = this.Location;
        }

    
    }
}

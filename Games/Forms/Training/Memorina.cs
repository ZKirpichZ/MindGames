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
using Games.Forms;

namespace Games.Forms.Training
{
    public partial class Memorina : Form
    {

        bool allowClick = false;
        PictureBox firstGuess;
        Random rnd = new Random();
        Timer clickTimer = new Timer();
        int time = 60;
        Timer timer = new Timer {  Interval = 1000};

        public Memorina()
        {
            InitializeComponent();
        }

        private PictureBox[] pictureBoxes
        {
            get
            { return Controls.OfType<PictureBox>().ToArray();}
        }

        private static IEnumerable<Image> images
        {
            get
            {
                return new Image[]
                {
                    Properties.Resources._11,
                    Properties.Resources._12,
                    Properties.Resources._13,
                    Properties.Resources._14,
                    Properties.Resources._15,
                    Properties.Resources._16,
                    Properties.Resources._17,
                    Properties.Resources._18,

                };
            }
        }

        private void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    var result = RJMessageBox.Show("Время вышло!", "Результат");
                    ResetImages();
                }

               
                label1.Text = "00: " + time.ToString();
            };
        }

        private void ResetImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Tag = null;
                pic.Visible = true;
            }

            HideImages();
            setRandomImages();
            time = 60;
            timer.Start();
        }

        private void HideImages()
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Image = Properties.Resources.question;
            }
        }

        private PictureBox getFreeSlot()
        {
            int num;
            do
            {
                num = rnd.Next(0, pictureBoxes.Count());
            }
            while (pictureBoxes[num].Tag != null);
            return pictureBoxes[num];
        }

        private void setRandomImages()
        {
            foreach (var image in images)
            {
                getFreeSlot().Tag = image;
                getFreeSlot().Tag = image;
            }
        }

        private void ClickTimer_Tick (object sender, EventArgs e)
        {
            HideImages();
            allowClick = true;
            clickTimer.Stop();
        }

        private void clickImage(object sender, EventArgs e)
        {
            if (!allowClick) return;
            var pic = (PictureBox)sender;
            if (firstGuess == null)
            {
                firstGuess = pic;
                pic.Image = (Image)pic.Tag;
                return;
            }

            pic.Image = (Image)pic.Tag;

            if (pic.Image == firstGuess.Image && pic != firstGuess)
            {
                pic.Visible = firstGuess.Visible = false;
                {
                    firstGuess = pic;
                }
                HideImages();
            }
            else
            {
                allowClick = false;
                clickTimer.Start();
            }

            firstGuess = null;
            if (pictureBoxes.Any(p => p.Visible)) return;
            timer.Stop();
            var result = RJMessageBox.Show("У тебя осталось " + (label1.Text).Substring((label1.Text).IndexOf(":", 0)) + " секунд(ы)", "Результат");
            button1.Enabled = true;
            OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0;Data Source=bd.mdb");

            string Names = RegName.NameRegD;
            OleDbDataAdapter dad = new OleDbDataAdapter($"INSERT INTO[Меморина]([Имя игрока], [Оставшееся время]) VALUES('" + Names + "', '" + (label1.Text).Substring((label1.Text).IndexOf("", 0)) + " сек.')", con);
            DataTable bes = new DataTable();
            dad.Fill(bes);
        }

        private void startGame(object sender, EventArgs e)
        {
            if (time == 60)
            {
                allowClick = true;
                time = 60;
                setRandomImages();
                HideImages();
                startGameTimer();
                clickTimer.Interval = 500;
                clickTimer.Tick += ClickTimer_Tick;
                button1.Enabled = false;
            }
            else
            {
                
                ResetImages();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        { 
            this.Close();
           
        }

        private void Memorina_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
            Memorys memyForm = new Memorys();
            memyForm.Show();
            memyForm.Location = this.Location;
            this.Hide();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(64,64,64);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Меморина «Картинки»";
            infoForm.label2.Text = " «Меморина» - игра в которой нужно переворачивать закрытые карточки, искать на обратной стороне одинаковые картинки и составлять из них пары. Эта игра прекрасно тренирует память и внимание!";
            infoForm.Location = this.Location;
        }
    }
}

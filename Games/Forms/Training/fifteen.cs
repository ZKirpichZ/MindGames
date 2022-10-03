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
    public partial class fifteen : Form
    {
        int inv = 0;
        int inNullSliceIndex, inmoves = 0;
        List<Bitmap> lstOriginalPictureList = new List<Bitmap>();
        System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

        public fifteen()
        {
            InitializeComponent();
            lstOriginalPictureList.AddRange(new Bitmap[] { Properties.Resources.s1, Properties.Resources.s2, Properties.Resources.s3, Properties.Resources.s4, Properties.Resources.s5, Properties.Resources.s6, Properties.Resources.s7, Properties.Resources.s8, Properties.Resources.s9, Properties.Resources.gg });
            lblMovesMade.Text += inmoves;
        }

        void Shuffle()
        {
           
            inv = 0;
            do
            {
                int j;
                List<int> Indexes = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9 });
                Random r = new Random();
                for (int i = 0; i < 9; i++)
                {
                    j = Indexes[r.Next(0, Indexes.Count -1)];
                    Indexes.Remove((j));
                    
                    for (int q = 0; q < Indexes.Count; q++)
                    {
                        if (j > Indexes[q]) ++inv;
                    }

                    




                    ((PictureBox)gbPuzzleBox.Controls[i]).Image = lstOriginalPictureList[j];
                    if (j == 9) inNullSliceIndex = i;
                }
                
             
            } while (CheckWin());
            
            if (inv % 2 != 0) Shuffle();
        }







        private void SwitchPictureBox(object sender, EventArgs e)
        {

            int inPictureBoxIndex = gbPuzzleBox.Controls.IndexOf(sender as Control);
            if (inNullSliceIndex != inPictureBoxIndex)
            {
                List<int> FourBrothers = new List<int>(new int[] { ((inPictureBoxIndex % 3 == 0) ? -1 : inPictureBoxIndex - 1), inPictureBoxIndex - 3, (inPictureBoxIndex % 3 == 2) ? -1 : inPictureBoxIndex + 1, inPictureBoxIndex + 3 });
                if (FourBrothers.Contains(inNullSliceIndex))
                {
                    ((PictureBox)gbPuzzleBox.Controls[inNullSliceIndex]).Image = ((PictureBox)gbPuzzleBox.Controls[inPictureBoxIndex]).Image;
                    ((PictureBox)gbPuzzleBox.Controls[inPictureBoxIndex]).Image = lstOriginalPictureList[9];
                    inNullSliceIndex = inPictureBoxIndex;
                    lblMovesMade.Text = "Ход: " + (++inmoves);
                    if (CheckWin())
                    {

                        (gbPuzzleBox.Controls[8] as PictureBox).Image = lstOriginalPictureList[8];
                        var result = RJMessageBox.Show("Поздравляем! \n Вы прошли! \n Общее количество ходов: " + inmoves, "Результат");
                        OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0;Data Source=bd.mdb");
                        string Names = RegName.NameRegD;
                        OleDbDataAdapter dad = new OleDbDataAdapter($"INSERT INTO[Пятнашки]([Имя игрока], [Количество ходов]) VALUES('" + Names + "','" + inmoves + "')", con);
                        DataTable bes = new DataTable();
                        dad.Fill(bes);
                        inmoves = 0;
                        lblMovesMade.Text = "Ход: 0";


                        Shuffle();
                    }
                }
            }
        }

        bool CheckWin()
        {
            int i;
            for (i = 0; i < 8; i++)
            {
                if ((gbPuzzleBox.Controls[i] as PictureBox).Image != lstOriginalPictureList[i]) break;
            }
            if (i == 8) return true;
            else return false;
        }

        private void btnQuit_Click_1(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.FromArgb(64,64,64);
        }

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(32, 32, 32);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label2.Font = new Font("Candara Light", 24);
            infoForm.label1.Text = "Пятнашки 3x3";
            infoForm.label2.Text = "Игра представляет собою графическую вариацию игры 'Пятнашки'. Вам нужно собрать исходную картинку, перемещая плитки (части этой картинки) за минимально возможное количество шагов за данный случай. Для перемещения плитки нажмите на неё. Исходная картинка представлена справа. " +
                "Игра развивает логическое мышление, усидчивость, логику и способности к анализу.";
            infoForm.Location = this.Location;
        }

        private void fifteen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mind mindForm = new Mind();
            mindForm.Show();
            mindForm.Location = this.Location;
        }

        private void BtnShuffle_Click_1(object sender, EventArgs e)
        {
            lblMovesMade.Visible = true;
            Shuffle();
            timer.Reset();
            inmoves = 0;
            lblMovesMade.Text = "Ход: 0";

        }
    }
}

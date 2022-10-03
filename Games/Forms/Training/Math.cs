using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Games.Forms.Training.Info;
using System.Data.OleDb;
using System.Data;
namespace Games.Forms.Training
{
    public partial class Math : Form
    {
        private static Random random = new Random();
        private static int Score = 0;
        private static int Answer;
        private static List<Button> btns;
        private static int Timer = 10;
      

        public Math()
        {
            InitializeComponent();
        }

        private void Math_Load(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            btns = new List<Button>() { btn1, btn2, btn3, btn4 };
            NewGame();
            Timer = 10;
            timer1.Start();
            Score = 0;
        }

        private void NewGame()
        {
            int num1 = random.Next(1, 100);
            int num2 = random.Next(1, 100);

            int r = random.Next(1, 5);
            if (r == 1)
            {   
                if (Score >= 100)
                {
                    num1 = random.Next(1, 200);
                    num2 = random.Next(1, 200);
                }
                else if (Score < 100)
                {
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);
                }
                
                SetlblGame(num1, num2, "+");
                Answer = num1 + num2;
            }
            else if (r == 2)
            {

                if (Score >= 100)
                {
                    num1 = random.Next(1, 200);
                    num2 = random.Next(1, 200);
                }
                else if (Score < 100)
                {
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);
                }

                
                SetlblGame(num1, num2, "-");
                Answer = num1 - num2;
            }
            else if (r == 3)
            {
                if (Score >= 100)
                {
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 60);
                }
                else if (Score < 100)
                {
                    num1 = random.Next(1, 50);
                    num2 = random.Next(1, 30);
                }

               
                SetlblGame(num1, num2, "*");
                Answer = num1 * num2;
            }
            else if (r == 4)
            {

                if (Score >= 100)
                {
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 20);
                }
                else if (Score < 100)
                {
                    num1 = random.Next(1, 50);
                    num2 = random.Next(1, 10);
                }


                int b = num1 * num2;
                num1 = b;

                SetlblGame(num1, num2, "/");
                Answer =  num1 / num2;
            }
            
            SetBtns();
            Timer = 10;
            lblTimer.Text = Timer.ToString();
            
        }


        public void SetBtns()
        {
            
            foreach (var btn in btns)
            {
                btn.Text = "";
            }
            btns[random.Next(0, 3)].Text = Answer.ToString();
            int el = random.Next(1, 4);
            foreach (var btn in btns)
            {

                if (btn.Text != Answer.ToString())
                {
                    if (el == 1)
                    {
                        if (Score >= 100)
                        {
                            btn.Text = (random.Next(1, 200) + random.Next(1, 200)).ToString();
                        }
                        else if (Score < 100)
                        {
                            btn.Text = (random.Next(1, 100) + random.Next(1, 100)).ToString();
                        }

                       
                    }
                    else if (el == 2)
                    {
                        if (Score >= 100)
                        {
                            btn.Text = (random.Next(1, 200) - random.Next(1, 200)).ToString();
                        }
                        else if (Score < 100)
                        {
                            btn.Text = (random.Next(1, 100) - random.Next(1, 100)).ToString();
                        }

                        
                    }
                    else if (el == 3)
                    {
                        if (Score >= 100)
                        {
                            btn.Text = (random.Next(1, 100) * random.Next(1, 60)).ToString();
                        }
                        else if (Score < 100)
                        {
                            btn.Text = (random.Next(1, 50) * random.Next(1, 30)).ToString();
                        }

                       
                    }
                  
                }

            }


        }


        public void SetlblGame(int num1, int num2, string opr)
        {

            lblGame.Text = num1.ToString() + $" {opr} " + num2.ToString() + " = ?";
           

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            CheckButton(btn1);
           
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            CheckButton(btn2);
            

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            CheckButton(btn3);
            

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            CheckButton(btn4);
            
        }

        private void CheckButton(Button btn)
        {
            if (btn.Text == Answer.ToString())
            {
                Win();
            }
            else
            {
                Lost();
            }
        }

        private void Win()
        {
            Score += 10;
            SetlblScore();
            NewGame();
        }

        private void Lost()
        {
            timer1.Stop();
            lblTimer.Text = "0";
            var result = RJMessageBox.Show($"Поздравляем! \n Вы набрали = {Score} очков.", "Результат");
            OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0;Data Source=bd.mdb");
            string Names = RegName.NameRegD;
            OleDbDataAdapter dad = new OleDbDataAdapter($"INSERT INTO[Устный счет]([Имя игрока], [Счет]) VALUES('" + Names + "','" + Score + "')", con);
            DataTable bes = new DataTable();
            dad.Fill(bes);
            lblScore.Text = "Очки: 0";
            lblGame.Text = "";
            foreach (var btn in btns)
            {
                btn.Text = "";
            }
            

        }

        

        private void SetlblScore()
        {
            lblScore.Text = $"Очки: {Score}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Timer >= 0)
            {
                lblTimer.Text = Timer.ToString();
            }
            Timer--;
            if (Timer == -1)
            {
                Lost();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void BtnExit_MouseEnter(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void BtnExit_MouseLeave(object sender, EventArgs e)
        {
            BtnExit.BackColor = Color.FromArgb(32,32,32);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(32, 32, 32);
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

        private void Math_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mind mindForm = new Mind();
            mindForm.Show();
            mindForm.Location = this.Location;
        }
    }
}

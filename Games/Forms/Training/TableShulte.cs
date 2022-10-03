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
    public partial class TableShulte : Form
    {


        private Random random = new Random();
        private int[] Randomer = new int[25];

        private int glob = default;
        private int timeLeft = 0;
        private int level = 0;

        public TableShulte()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += ShowTimer;
        }
        
       

        private void start()
        {
            panel1.Visible = true;
            timeLeft = 0;
            glob = 1;
            level = timeLeft;

            SelectText();

            
            timer1.Start();
        }

        private void SelectText()
        {
            for (int i = 0; i < Randomer.Length; ++i)
            {
                int j = random.Next(0, 16) % (i + 1);
                Randomer[i] = Randomer[j];
                Randomer[j] = i + 1;
            }
            Randomer.Select(i => new { I = i, sort = Guid.NewGuid() }).OrderBy(i => i.sort).Select(i => i.I);

            int a = 0;
            foreach (Control Cont in panel1.Controls)
            {
                Cont.Visible = true;
                Cont.Text = Randomer[a].ToString();
                a++;
            }
        }

        void ShowTimer(object vObject, EventArgs e)
        {
            if (timeLeft >= 0)
            {
                ++timeLeft;
                Times.Text = $"Время: {timeLeft.ToString()} сек.";
            }
        }

        private void Winer(DialogResult result)
        {
            if (result == DialogResult.OK)
            {
                
                panel1.Visible = true;
                Times.Text = $"Время: {0} сек.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Button btn = (Button)sender;
            if (glob == int.Parse(btn.Text))
            {
                glob++;
                btn.Visible = false;
            }
            if (glob == 26)
            {
                timer1.Stop();
               
                var result = RJMessageBox.Show($"Время: {(timeLeft)} сек", "Результат");
                Winer(result);
                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0;Data Source=bd.mdb");
                string Names = RegName.NameRegD;
                OleDbDataAdapter dad = new OleDbDataAdapter($"INSERT INTO[Таблица Шульте]([Имя игрока], [Время]) VALUES('" + Names + "','" + timeLeft + " сек.')", con);
                DataTable bes = new DataTable();
                dad.Fill(bes);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            start();
        }

    

        private void StartButton_MouseEnter(object sender, EventArgs e)
        {
            StartButton.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void StartButton_MouseLeave(object sender, EventArgs e)
        {
            StartButton.BackColor = Color.FromArgb(32,32,32);
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

        private void TableShulte_FormClosed(object sender, FormClosedEventArgs e)
        {
            Attentions AttForm = new Attentions();
            AttForm.Show();
            AttForm.Location = this.Location;
        }
    }
}

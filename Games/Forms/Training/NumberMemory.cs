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
    public partial class NumberMemory : Form
    {

        private int rows;
        private int columns;
        private Card[,] cards;
        private Card pickedCard;
        private Card secondPickedCard;
        private bool isEnabled = false;

        private int cardsMatched;
        private int totalCards;
        int x;
        int time = 0;
        string dif;
        
        


        public NumberMemory()
        {
            InitializeComponent();
        }

        private void StartNewGame(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;


            ConstructGameTable(Card.PrepareCardValues(rows, columns));
        }

        private void ConstructGameTable(int[,] cardValues)
        {
            gameTable.Controls.Clear();
            gameTable.RowStyles.Clear();
            gameTable.ColumnStyles.Clear();

            gameTable.RowCount = rows;
            float rowHeightPercentage = 100 / rows;
            for (int row = 0; row < rows; row++)
                gameTable.RowStyles.Add(new RowStyle(SizeType.Percent, rowHeightPercentage));


            float columnWidthPercentage = 100 / columns;
            gameTable.ColumnCount = columns;
            for (int column = 0; column < columns; column++)
                gameTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnWidthPercentage));


            cards = new Card[rows, columns];
            int cardWidth = gameTable.Size.Width / columns,
                cardHeight = gameTable.Size.Height / rows;
            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                {
                    Card card = new Card(cardWidth, cardHeight, cardValues[row, column]);
                    cards[row, column] = card;
                    card.Click += HandleCardClick;
                    gameTable.Controls.Add(card.Button, column, row);
                }

            cardsMatched = 0;
            totalCards = rows * columns;
            isEnabled = true;
        }

        private void HandleCardClick(object sender, Card card)
        {
            if (!isEnabled)
                return;

            if (pickedCard != null)
            {
                if (pickedCard.Value == card.Value)
                {
                   
                    pickedCard.Show();
                    card.Show();
                    pickedCard = null;
                    cardsMatched += 2;
                    CheckWinCondition();
                }
                else
                {
                    
                    card.Peek();
                    isEnabled = false;
                    secondPickedCard = card;
                    hideCardsTimer.Enabled = true;
                }
            }
            else
            {
                pickedCard = card;
                card.Peek();
            }
        }

        public void CheckWinCondition()
        {
            if (cardsMatched == totalCards)
            {
                isEnabled = false;
                timer1.Stop();
                var result = RJMessageBox.Show($"Сложность: {dif} \n Время: {time} сек.", "Результат");
                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0;Data Source=bd.mdb");
                string Names = RegName.NameRegD;
                OleDbDataAdapter dad = new OleDbDataAdapter($"INSERT INTO[ЧислаМемо]([Имя игрока], [Сложность], [Время]) VALUES('" + Names + "','"+ dif + "','" + time + "')", con);
                DataTable bes = new DataTable();
                dad.Fill(bes);

            }
        }




        private void hideCardsTimer_Tick(object sender, EventArgs e)
        {
            hideCardsTimer.Enabled = false;
            pickedCard.Hide();
            secondPickedCard.Hide();
            pickedCard = null;
            secondPickedCard = null;

            isEnabled = true;
        }

        public void Clears()
        {
            gameTable.Controls.Clear();
            gameTable.RowStyles.Clear();
            gameTable.ColumnStyles.Clear();
            timer1.Stop();
            time = 0;
            label3.Text = (time).ToString() + " сек.";
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Clears();
            x = 4;
            dif = radioButton2.Text;
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Clears();
            x = 6;
            dif = radioButton3.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Clears();
            x = 8;
            dif = radioButton4.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Clears();
            x = 10;
            dif = radioButton5.Text;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Information infoForm = new Information();
            infoForm.Show();
            infoForm.label1.Text = "Меморина «Цифры»";
            infoForm.label2.Text = "Усложненная вариация игры «Меморины». Переворачивайте закрытые карточки с помощью мышки, находите одинаковые цифры и составляйте из них пары. Игра тренирует кратковременная память и наблюдательность.";
            infoForm.Location = this.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clears();
            timer1.Start();
            StartNewGame(x, x);
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (time >= 0)
            {
                label3.Text = (++time).ToString() + " сек.";
            }
            
        }

        private void NumberMemory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Memorys memyForm = new Memorys();
            memyForm.Show();
            memyForm.Location = this.Location;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;

namespace Games.Forms.Training
{
    public enum CardState
    {
        Guessed,
        Hidden,
        Peeking
    }

    class Card
    {
        public Button Button { get; private set; }
        public CardState State { get; private set; }
        public int Value { get; private set; }
        public event EventHandler<Card> Click;

        public Card(int cardWidth, int cardHeight, int cardValue)
        {
            Button = new Button();
            Button.Text = "?";
            Button.Size = new Size(cardWidth, cardHeight);
            Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            Button.Font = new Font("Candara Light", 16, FontStyle.Bold);
            Button.TabStop = false;
            Button.Click += Button_Click;
            Button.BackColor = Color.Black;
            Button.ForeColor = Color.White;
            

            Value = cardValue;

            State = CardState.Hidden;
        }

        public void Peek()
        {
            State = CardState.Peeking;
            Button.Enabled = false;
            Button.ForeColor = Color.White;
            Button.Text = Value.ToString();
            Button.BackColor = Color.White;

        }

        public void Show()
        {
            State = CardState.Guessed;
            Button.Enabled = false;
            Button.ForeColor = Color.White;
            Button.Text = Value.ToString();
            Button.BackColor = Color.Green;
            Button.Hide();
            Button.FlatAppearance.BorderSize = 1;

        }

        public void Hide()
        {
            State = CardState.Hidden;
            Button.Enabled = true;

            Button.Text = "?";
            Button.BackColor = Color.Black;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Click?.Invoke(sender, this);
        }

        public static int[,] PrepareCardValues(int rows, int columns)
        {
            int[,] cardValues = new int[rows, columns];

            int[] values = new int[rows * columns];
            for (int i = 0; i < values.Length; i += 2)
            {
                values[i] = i + 1;
                values[i + 1] = i + 1;
            }
            Random rnd = new Random();
            int[] shuffledValues = values.OrderBy(x => rnd.Next()).ToArray();

            int j = 0;
            for (int row = 0; row < rows; row++)
                for (int column = 0; column < columns; column++)
                {
                    cardValues[row, column] = shuffledValues[j++];
                }

            return cardValues;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games.Forms.Controles;

namespace Games.Forms.Training.Info
{
    public partial class Rating : Form
    {
        Query controller;
        string Names = RegName.NameRegD;
        public Rating()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
            
        }

        private void Rating_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdateMem();
            dataGridView2.DataSource = controller.UpdateMems(Names);
            label3.Text = "Количество результатов: " + dataGridView2.RowCount.ToString();
            dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Descending);
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
            try
            {
                label4.Text = "Лучший результат: " + dataGridView2.Rows[0].Cells[1].Value.ToString();
            }
            catch (System.ArgumentOutOfRangeException)
            {
                label4.Text = "Лучший результат: Нет";
            }
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";



        }

    



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Меморина «Картинки»")
            {
                dataGridView1.DataSource = controller.UpdateMem();
                dataGridView2.DataSource = controller.UpdateMems(Names);
                dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Descending);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);

                try
                {
                    label4.Text = "Лучший результат: " + dataGridView2.Rows[0].Cells[1].Value.ToString();
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    label4.Text = "Лучший результат: Нет";
                }
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";




            }
            else if (comboBox1.Text == "Меморина «Цифры»") 
            {
                dataGridView1.DataSource = controller.UpdateNumMemo();
                dataGridView2.DataSource = controller.UpdateNumMemos(Names);
                dataGridView2.Sort(dataGridView2.Columns[2], ListSortDirection.Ascending);
                dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);

                try
                {
                    label4.Text = "Лучший результат (3x3): " + dataGridView2.Rows[0].Cells[2].Value.ToString() + " сек.";
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    label4.Text = "Лучший результат (3x3): Нет";
                }

            if (dataGridView2.Rows.Count == 0)
                {
                    label5.Text = "Лучший результат (6x6): Нет";
                    label6.Text = "Лучший результат (8x8): Нет";
                    label7.Text = "Лучший результат (10x10): Нет";
                }


                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Средний (6x6)")
                    {
                        label5.Text = "Лучший результат (6x6): " + dataGridView2.Rows[i].Cells[2].Value.ToString() + " сек.";
                        break;
                    }
                
                     
                }

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Эксперт (10x10)")
                    {
                        label7.Text = "Лучший результат (10x10): " + dataGridView2.Rows[i].Cells[2].Value.ToString() + " сек.";
                        break;
                    }
                   
                }
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Тяжелый (8x8)")
                    {
                        label6.Text = "Лучший результат (8x8): " + dataGridView2.Rows[i].Cells[2].Value.ToString() + " сек.";
                        break;
                    }

                }



            }
            else if (comboBox1.Text == "Таблица Шульте")
            {
                dataGridView1.DataSource = controller.UpdateTable();
                dataGridView2.DataSource = controller.UpdateTables(Names);
                dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Ascending);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
              

                try
                {
                    label4.Text = "Лучший результат: " + dataGridView2.Rows[0].Cells[1].Value.ToString();
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    label4.Text = "Лучший результат: Нет";
                }
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
            }
            else if (comboBox1.Text == "Направления")
            {
                dataGridView1.DataSource = controller.UpdateUP();
                dataGridView2.DataSource = controller.UpdateUPS(Names);
                dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Descending);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
            

                try
                {
                    label4.Text = "Лучший результат: " + dataGridView2.Rows[0].Cells[1].Value.ToString() + " очков";
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    label4.Text = "Лучший результат: Нет";
                }
                label5.Text = "";
                label7.Text = "";
                label6.Text = "";
            }
            else if (comboBox1.Text == "Пятнашки 3x3")
            {
                dataGridView1.DataSource = controller.UpdateFiv();
                dataGridView2.DataSource = controller.UpdateFivs(Names);
                dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Ascending);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

                try
                {
                    label4.Text = "Лучший результат: " + dataGridView2.Rows[0].Cells[1].Value.ToString();
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    label4.Text = "Лучший результат: Нет";
                }
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
            }
            else if (comboBox1.Text == "Устный счет")
            {
                dataGridView1.DataSource = controller.UpdateMath();
                dataGridView2.DataSource = controller.UpdateMaths(Names);
                dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Descending);
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Descending);
   

                try
                {
                    label4.Text = "Лучший результат: " + dataGridView2.Rows[0].Cells[1].Value.ToString() + " очков";
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    label4.Text = "Лучший результат: Нет";
                }
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
            }
            label3.Text = "Количество результатов: " + dataGridView2.RowCount.ToString();
          


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rating_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main mindForm = new Main();
          
            mindForm.Show();
            mindForm.Location = this.Location;

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Games.Forms.Controles;
using Games.Forms;
namespace Games.Forms.Training
{
    public partial class RegName : Form
    {
        Query controller;
        public static string NameRegD;

        public RegName()
        {
            InitializeComponent();


            controller = new Query(ConnectionString.ConnStr);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (LogBox.Text != "" && PassBox.Text != "") { 
                OleDbConnection con = new OleDbConnection(@"Provider = Microsoft.Jet.OLEDB.4.0;Data Source=bd.mdb");
                if (button1.Text == "Войти") { 
                    OleDbDataAdapter ada = new OleDbDataAdapter("Select Count(*) From Registration where [Login] = '" + LogBox.Text + "' and [Password] = '" + PassBox.Text + "'", con);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        
                        this.Hide();
                        Main MainForm = new Main();
                        MainForm.Location = this.Location;
                        MainForm.Show();
                        var result = RJMessageBox.Show($"Добро пожаловать, {LogBox.Text}!", "Авторизация");
                        NameRegD = LogBox.Text;

                    }
                    else
                    {
                        var result = RJMessageBox.Show("Проверьте логин и пароль!", "Авторизация");
                    }
             
                }
                else
                {
                    OleDbDataAdapter ada = new OleDbDataAdapter("Select Count(*) From Registration where [Login] = '" + LogBox.Text + "' and [Password] = '" + PassBox.Text + "'", con);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        var result = RJMessageBox.Show("Игрок уже зарегистрирован!", "Регистрация");
                    }
                    else
                    {
                        if (controller.checkUser(LogBox.Text) == false)
                        {
                            OleDbDataAdapter dad = new OleDbDataAdapter($"INSERT INTO[Registration]([Login], [Password]) VALUES('" + LogBox.Text + "', '" + PassBox.Text + "')", con);
                            DataTable bes = new DataTable();
                            dad.Fill(bes);
                            var result = RJMessageBox.Show("Вы были зарегистрированы!", "Регистрация");
     
                        }
                        
                        
                    }
                }
            }
            else
            {
                var result = RJMessageBox.Show("Одно или несколько полей пусты!", "");
           
            }
        }



        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Войти")
            {
                this.Text = "Регистрация";
                button1.Text = "Регистрировать";
                var result = RJMessageBox.Show("Режим регистрации!", "Регистрация");
            }
            else
            {
                this.Text = "Авторизация";
                button1.Text = "Войти";
                var result = RJMessageBox.Show("Режим авторизация!", "Авторизация");
            }
        }

    

    

        private void RegName_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu MenForm = new Menu();
            MenForm.Show();
            MenForm.Location = this.Location;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                PassBox.PasswordChar = '\0';
            }
            else
            {
                PassBox.PasswordChar = '*';
            }

        }
    }
}

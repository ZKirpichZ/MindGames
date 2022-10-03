using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace Games.Forms.Controles


{


    internal class Query
    {

        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter dataAdapter;
        DataTable bufferTable1;
        DataTable bufferTable2;
        DataTable bufferTable3;
        DataTable bufferTable4;
        DataTable bufferTable5;
        DataTable bufferTable6;
        DataTable bufferTable11;
        DataTable bufferTable22;
        DataTable bufferTable33;
        DataTable bufferTable44;
        DataTable bufferTable55;
        DataTable bufferTable66;
        public Query(string Conn)
        {
            connection = new OleDbConnection(Conn);
            bufferTable1 = new DataTable();
            bufferTable2 = new DataTable();
            bufferTable3 = new DataTable();
            bufferTable4 = new DataTable();
            bufferTable5 = new DataTable();
            bufferTable6 = new DataTable();
            bufferTable11 = new DataTable();
            bufferTable22 = new DataTable();
            bufferTable33 = new DataTable();
            bufferTable44 = new DataTable();
            bufferTable55 = new DataTable();
            bufferTable66 = new DataTable();
        }


        public Boolean checkUser(string login)
        {
            connection.Open();
            try
            {

                command = new OleDbCommand("SELECT Login FROM Registration WHERE Login = @login", connection);
                command.Parameters.Add("@login", OleDbType.VarChar).Value = login;
                if (Convert.ToString(command.ExecuteScalar()) == login)
                {
                    var result = RJMessageBox.Show("Такой пользователь уже существует", "Ошибка");
                    connection.Close();
                    return true;


                }
                else { connection.Close(); return false; }

            }
            catch (Exception e)
            {
                var result = RJMessageBox.Show("Ошибка при работе с БД: " + e.Message, "Ошибка");
                connection.Close();
                return true;


            }

        }

        public DataTable UpdateMem()
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter("Select [Имя игрока],max([Оставшееся время]) as [Оставшееся время] FROM [Меморина] GROUP BY [Имя игрока]", connection);
            bufferTable1.Clear();
            dataAdapter.Fill(bufferTable1);
            connection.Close();
            return bufferTable1;
        }
        public DataTable UpdateMems(string name)
        {
            
            connection.Open();
            dataAdapter = new OleDbDataAdapter($"Select * FROM [Меморина] Where [Имя игрока] = '{name}'", connection);
            bufferTable11.Clear();
            dataAdapter.Fill(bufferTable11);
            connection.Close();
            return bufferTable11;
        }





        public DataTable UpdateUP()
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter("Select [Имя игрока],max([Счет]) as [Счет] FROM [Направления] GROUP BY [Имя игрока]", connection);
            bufferTable2.Clear();
            dataAdapter.Fill(bufferTable2);
            connection.Close();
            return bufferTable2;
        }
        public DataTable UpdateUPS(string name)
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter($"Select * FROM [Направления] Where [Имя игрока] = '{name}'", connection);
            bufferTable22.Clear();
            dataAdapter.Fill(bufferTable22);
            connection.Close();
            return bufferTable22;
        }





        public DataTable UpdateFiv()
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter("Select [Имя игрока],MIN([Количество ходов]) AS [Количество ходов] FROM [Пятнашки] GROUP BY [Имя игрока]", connection);
            bufferTable3.Clear();
            dataAdapter.Fill(bufferTable3);
            connection.Close();
            return bufferTable3;
        }
        public DataTable UpdateFivs(string name)
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter($"Select * FROM [Пятнашки] Where [Имя игрока] = '{name}'", connection);
            bufferTable33.Clear();
            dataAdapter.Fill(bufferTable33);
            connection.Close();
            return bufferTable33;
        }








        public DataTable UpdateTable()
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter("Select [Имя игрока],MIN([Время]) AS Время FROM [Таблица Шульте] GROUP BY [Имя игрока]", connection);
            bufferTable4.Clear();
            dataAdapter.Fill(bufferTable4);
            connection.Close();
            return bufferTable4;
        }

        public DataTable UpdateTables(string name)
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter($"Select * FROM [Таблица Шульте] Where [Имя игрока] = '{name}'", connection);
            bufferTable44.Clear();
            dataAdapter.Fill(bufferTable44);
            connection.Close();
            return bufferTable44;
        }






        public DataTable UpdateMath()
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter("Select [Имя игрока], MAX([Счет]) as [Счет] FROM [Устный счет] GROUP BY [Имя игрока]", connection);
            bufferTable5.Clear();
            dataAdapter.Fill(bufferTable5);
            connection.Close();
            return bufferTable5;
        }
        public DataTable UpdateMaths(string name)
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter($"Select * FROM [Устный счет] Where [Имя игрока] = '{name}'", connection);
            bufferTable55.Clear();
            dataAdapter.Fill(bufferTable55);
            connection.Close();
            return bufferTable55;
        }









        public DataTable UpdateNumMemo()
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter("Select [Имя игрока],[Сложность],MIN([Время]) AS Время FROM [ЧислаМемо] GROUP BY [Имя игрока],[Сложность]", connection);
            bufferTable6.Clear();
            dataAdapter.Fill(bufferTable6);
            connection.Close();
            return bufferTable6;
        }

        public DataTable UpdateNumMemos(string name)
        {

            connection.Open();
            dataAdapter = new OleDbDataAdapter($"Select * FROM [ЧислаМемо] Where [Имя игрока] = '{name}'", connection);
            bufferTable66.Clear();
            dataAdapter.Fill(bufferTable66);
            connection.Close();
            return bufferTable66;
        }




    }
}

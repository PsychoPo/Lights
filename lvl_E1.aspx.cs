using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Threading;
using System.Reflection.Emit;
using System.Reflection;
using System.Diagnostics;

namespace Lights
{
    
    public partial class lvl_E1 : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = null;
        SqlCommand edit_command;
        //private DateTime startTime; // Начальное время
        string[,] array = new string[3, 3];
        int[,] true_array = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        int IDa = Var.ID_a;
        int IDe = Var.ID_e;
        string finish = "";
        string check_finish = "";
        int P_i = 0;
        int P_j = 0;
        int P_pos = 0;

        string[] check_L = new string[4] { "23", "34", "14", "12" };
        string[] check_I = new string[4] { "1", "2", "1", "2" };
        string[] check_T = new string[4] { "234", "134", "124", "123" };
        string[] check_RGBY = new string[4] { "3", "4", "1", "2" };

        protected bool check()
        {
            char zero = '0';

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j].ElementAt(0) == 'P' || array[i, j].ElementAt(0) == 'R' || array[i, j].ElementAt(0) == 'G' || array[i, j].ElementAt(0) == 'B' || array[i, j].ElementAt(0) == 'Y')
                        check_finish += array[i, j].ElementAt(0);
                    else check_finish += array[i, j].ElementAt(array[i, j].Length-1);
                }

            for (int i = 0; i < finish.Length; i++)
            {
                if (finish.ElementAt(i) == '0')
                    check_finish = check_finish.Remove(i, 1).Insert(i, zero.ToString());
            }

            if (check_finish == finish)
                return true;
            else return false;
        }

        protected void light(int p_i, int p_j, int pos, bool mas)
        {
            int i_now = p_i;
            int j_now = p_j;
            int pos_now = pos;
            int check_pos = 0;
            bool stop = false;
            bool start = false;

            while (!stop)
            {
                if (!start)
                {
                    if (!mas)
                    {
                        true_array = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
                        true_array[p_i, p_j] = 1;
                    }
                    switch (pos)
                    {
                        case 1:
                            {
                                if (i_now > 0)
                                {
                                    i_now--;
                                    check_pos = 0;
                                }
                                else stop = true;
                                break;
                            }
                        case 2:
                            {
                                if (j_now < 2)
                                {
                                    j_now++;
                                    check_pos = 1;
                                }
                                else stop = true;
                                break;
                            }
                        case 3:
                            {
                                if (i_now < 2)
                                {
                                    i_now++;
                                    check_pos = 2;
                                }
                                else stop = true;
                                break;
                            }
                        case 4:
                            {
                                if (j_now > 0)
                                {
                                    j_now--;
                                    check_pos = 3;
                                }
                                else stop = true;
                                break;
                            }
                    }
                    start = true;
                    goto First;
                }
                int temp_pos = Convert.ToInt32(array[i_now, j_now].ElementAt(array[i_now, j_now].Length - 1)) - 48;
                switch (array[i_now, j_now].ElementAt(0))
                {
                    case 'I':
                        {
                            switch (temp_pos)
                            {
                                case 1:
                                    {
                                        if (i_now > 0)
                                        {
                                            if (true_array[i_now - 1, j_now] == 0)
                                            {
                                                i_now--;
                                                check_pos = 0;
                                            }
                                            else
                                            {
                                                if (i_now < 2)
                                                {
                                                    i_now++;
                                                    check_pos = 2;
                                                }
                                                else stop = true;
                                            }
                                        }
                                        else stop = true;
                                        break;
                                    }
                                case 2:
                                    {
                                        if (j_now > 0)
                                        {
                                            if (true_array[i_now, j_now - 1] == 0)
                                            {
                                                j_now--;
                                                check_pos = 3;
                                            }
                                            else
                                            {
                                                if (j_now < 2)
                                                {
                                                    j_now++;
                                                    check_pos = 1;
                                                }
                                                else stop = true;
                                            }
                                        }
                                        else stop = true;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 'L':
                        {
                            switch (temp_pos)
                            {
                                case 1:
                                    {
                                        if (i_now > 0)
                                        {
                                            if (j_now < 2)
                                            {
                                                if (true_array[i_now, j_now + 1] == 0)
                                                {
                                                    j_now++;
                                                    check_pos = 1;
                                                }
                                                else
                                                {
                                                    i_now--;
                                                    check_pos = 0;
                                                }
                                                
                                            }
                                            else stop = true;
                                        }
                                        else stop = true;
                                        break;
                                    }
                                case 2:
                                    {
                                        if (i_now < 2)
                                        {
                                            if (j_now < 2)
                                            {
                                                if (true_array[i_now, j_now + 1] == 0)
                                                {
                                                    j_now++;
                                                    check_pos = 1;
                                                }
                                                else
                                                {
                                                    i_now++;
                                                    check_pos = 2;
                                                }
                                                
                                            }
                                            else stop = true;
                                        }
                                        else stop = true;
                                        break;
                                    }
                                case 3:
                                    {
                                        if (i_now < 2)
                                        {
                                            if (j_now > 0)
                                            {
                                                if (true_array[i_now, j_now - 1] == 0)
                                                {
                                                    j_now--;
                                                    check_pos = 3;
                                                }
                                                else
                                                {
                                                    i_now++;
                                                    check_pos = 2;
                                                }
                                            }
                                            else stop = true;
                                        }
                                        else stop = true;
                                        break;
                                    }
                                case 4:
                                    {
                                        if (i_now > 0)
                                        {
                                            if (j_now > 0)
                                            {
                                                if (true_array[i_now, j_now - 1] == 0)
                                                {
                                                    j_now--;
                                                    check_pos = 3;
                                                }
                                                else
                                                {
                                                    i_now--;
                                                    check_pos = 0;
                                                }
                                            }
                                            else stop = true;
                                        }
                                        else stop = true;
                                        break;
                                    }
                                default:
                                    {
                                        stop = true;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 'T':
                        {
                            switch (temp_pos)
                            {
                                case 1:
                                    {
                                        if (i_now > 0)
                                        {
                                            if (j_now == 0)
                                            {
                                                if (true_array[i_now, j_now + 1] == 1)
                                                    light(i_now, j_now, 1, true);
                                                else
                                                    light(i_now, j_now, 2, true);
                                            }
                                            else if (j_now < 2)
                                            {
                                                if (true_array[i_now, j_now + 1] == 1)
                                                {
                                                    light(i_now, j_now, 1, true);
                                                    light(i_now, j_now, 4, true);
                                                }
                                                else if (true_array[i_now, j_now - 1] == 1)
                                                {
                                                    light(i_now, j_now, 1, true);
                                                    light(i_now, j_now, 2, true);
                                                }
                                                else
                                                {
                                                    light(i_now, j_now, 2, true);
                                                    light(i_now, j_now, 4, true);
                                                }
                                            }
                                            else
                                            {
                                                if (true_array[i_now, j_now - 1] == 1)
                                                    light(i_now, j_now, 1, true);
                                                else
                                                    light(i_now, j_now, 4, true);
                                            }
                                        }
                                        else
                                        {
                                            if (j_now > 0 && j_now < 2)
                                            {
                                                if (true_array[i_now, j_now + 1] == 1)
                                                    light(i_now, j_now, 4, true);
                                                else
                                                    light(i_now, j_now, 2, true);
                                            }
                                            else
                                                stop = true;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        if (j_now < 2)
                                        {
                                            if (i_now == 0)
                                            {
                                                if (true_array[i_now, j_now + 1] == 1)
                                                    light(i_now, j_now, 3, true);
                                                else
                                                    light(i_now, j_now, 2, true);
                                            }
                                            else if (i_now < 2)
                                            {
                                                if (true_array[i_now, j_now + 1] == 1)
                                                {
                                                    light(i_now, j_now, 1, true);
                                                    light(i_now, j_now, 3, true);
                                                }
                                                else if (true_array[i_now - 1, j_now] == 1)
                                                {
                                                    light(i_now, j_now, 2, true);
                                                    light(i_now, j_now, 3, true);
                                                }
                                                else
                                                {
                                                    light(i_now, j_now, 1, true);
                                                    light(i_now, j_now, 2, true);
                                                }
                                            }
                                            else
                                            {
                                                if (true_array[i_now, j_now + 1] == 1)
                                                    light(i_now, j_now, 1, true);
                                                else
                                                    light(i_now, j_now, 2, true);
                                            }
                                        }
                                        else
                                        {
                                            if (i_now > 0 && i_now < 2)
                                            {
                                                if (true_array[i_now + 1, j_now] == 1)
                                                    light(i_now, j_now, 1, true);
                                                else
                                                    light(i_now, j_now, 3, true);
                                            }
                                            else
                                                stop = true;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        if (i_now < 2)
                                        {
                                            if (j_now == 0)
                                            {
                                                if (true_array[i_now, j_now + 1] == 1)
                                                    light(i_now, j_now, 3, true);
                                                else
                                                    light(i_now, j_now, 2, true);
                                            }
                                            else if (j_now < 2)
                                            {
                                                if (true_array[i_now, j_now + 1] == 1)
                                                {
                                                    light(i_now, j_now, 3, true);
                                                    light(i_now, j_now, 4, true);
                                                }
                                                else if (true_array[i_now, j_now - 1] == 1)
                                                {
                                                    light(i_now, j_now, 2, true);
                                                    light(i_now, j_now, 3, true);
                                                }
                                                else
                                                {
                                                    light(i_now, j_now, 2, true);
                                                    light(i_now, j_now, 4, true);
                                                }
                                            }
                                            else
                                            {
                                                if (true_array[i_now, j_now - 1] == 1)
                                                    light(i_now, j_now, 3, true);
                                                else
                                                    light(i_now, j_now, 4, true);
                                            }
                                        }
                                        else
                                        {
                                            if (j_now > 0 && j_now < 2)
                                            {
                                                if (true_array[i_now, j_now + 1] == 1)
                                                    light(i_now, j_now, 4, true);
                                                else
                                                    light(i_now, j_now, 2, true);
                                            }
                                            else
                                                stop = true;
                                        }
                                        break;
                                    }
                                case 4:
                                    {
                                        if (j_now > 0)
                                        {
                                            if (i_now == 0)
                                            {
                                                if (true_array[i_now, j_now - 1] == 1)
                                                    light(i_now, j_now, 3, true);
                                                else
                                                    light(i_now, j_now, 4, true);
                                            }
                                            else if (i_now < 2)
                                            {
                                                if (true_array[i_now, j_now - 1] == 1)
                                                {
                                                    light(i_now, j_now, 1, true);
                                                    light(i_now, j_now, 3, true);
                                                }
                                                else if (true_array[i_now - 1, j_now] == 1)
                                                {
                                                    light(i_now, j_now, 3, true);
                                                    light(i_now, j_now, 4, true);
                                                }
                                                else
                                                {
                                                    light(i_now, j_now, 1, true);
                                                    light(i_now, j_now, 4, true);
                                                }
                                            }
                                            else
                                            {
                                                if (true_array[i_now, j_now - 1] == 1)
                                                    light(i_now, j_now, 1, true);
                                                else
                                                    light(i_now, j_now, 4, true);
                                            }
                                        }
                                        else
                                        {
                                            if (i_now > 0 && i_now < 2)
                                            {
                                                if (true_array[i_now + 1, j_now] == 1)
                                                    light(i_now, j_now, 1, true);
                                                else
                                                    light(i_now, j_now, 3, true);
                                            }
                                            else
                                                stop = true;
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        stop = true;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 'X':
                        {
                            light(i_now, i_now, 1, true);
                            light(i_now, i_now, 2, true);
                            light(i_now, i_now, 3, true);
                            light(i_now, i_now, 4, true);
                            break;
                        }
                }
                First:
                    pos_now = Convert.ToInt32(array[i_now, j_now].ElementAt(array[i_now, j_now].Length - 1)) - 48;
                    switch (array[i_now, j_now].ElementAt(0))
                    {
                        case 'I':
                            {
                                if (check_I[check_pos].IndexOf(pos_now.ToString().ElementAt(0)) != -1 && true_array[i_now, j_now] == 0)
                                    true_array[i_now, j_now] = 1;
                                else
                                    stop = true;
                                break;
                            }
                        case 'L':
                            {
                                if (check_L[check_pos].IndexOf(pos_now.ToString().ElementAt(0)) != -1 && true_array[i_now, j_now] == 0)
                                    true_array[i_now, j_now] = 1;
                                else
                                    stop = true;
                                break;
                            }
                        case 'T':
                            {
                                if (check_T[check_pos].IndexOf(pos_now.ToString().ElementAt(0)) != -1 && true_array[i_now, j_now] == 0)
                                    true_array[i_now, j_now] = 1;
                                else
                                    stop = true;
                                break;
                            }
                        case 'X':
                            {
                                true_array[i_now, j_now] = 1;
                                break;
                            }
                        case char c when c == 'R' || c == 'G' || c == 'B' || c == 'Y':
                            {
                                if (check_RGBY[check_pos].IndexOf(pos_now.ToString().ElementAt(0)) != -1 && true_array[i_now, j_now] == 0)
                                    true_array[i_now, j_now] = 1;
                                stop = true;
                                break;
                            }
                    }
            }

            generate(ImageButton1, array[0, 0], true_array[0, 0]);
            generate(ImageButton2, array[0, 1], true_array[0, 1]);
            generate(ImageButton3, array[0, 2], true_array[0, 2]);
            generate(ImageButton4, array[1, 0], true_array[1, 0]);
            generate(ImageButton5, array[1, 1], true_array[1, 1]);
            generate(ImageButton6, array[1, 2], true_array[1, 2]);
            generate(ImageButton7, array[2, 0], true_array[2, 0]);
            generate(ImageButton8, array[2, 1], true_array[2, 1]);
            generate(ImageButton9, array[2, 2], true_array[2, 2]);
        }
        protected void generate(ImageButton button, string str, int mode)
        {
            string im_url = "~/Images/";
            im_url += str;
            if (str.ElementAt(0) != 'P')
            {
                if (mode == 0)
                    im_url += "_off";
                else im_url += "_on";
            }
            im_url += ".png";
            button.ImageUrl = im_url;

            if (str.IndexOf('P') != -1 || str.IndexOf('R') != -1 || str.IndexOf('G') != -1 || str.IndexOf('B') != -1 || str.IndexOf('Y') != -1 || str.IndexOf('X') != -1)
                button.Enabled = false;
        }
        protected void connect()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LightDB"].ConnectionString);
            sqlConnection.Open();
            int IDs = 1;

            string tmp_query = String.Format("SELECT COUNT(IDs) FROM sessions_3x3");
            SqlCommand tmp_command = new SqlCommand(tmp_query, sqlConnection);
            SqlDataReader read = tmp_command.ExecuteReader();
            read.Read();
            int count = read.GetInt32(0);
            read.Close();
            if (count != 0)
            {
                tmp_query = String.Format("SELECT MAX(IDs) FROM sessions_3x3");
                tmp_command = new SqlCommand(tmp_query, sqlConnection);
                read = tmp_command.ExecuteReader();
                read.Read();
                IDataRecord record = read;
                IDs = Convert.ToInt32(record[0]) + 1;
                read.Close();
            }

            string test_query = String.Format("SELECT COUNT(IDa) FROM sessions_3x3 WHERE IDa = '{0}'", IDa);
            SqlCommand test = new SqlCommand(test_query, sqlConnection);
            read = test.ExecuteReader();
            read.Read();
            int t = read.GetInt32(0);
            read.Close();
            if (t == 0)
            {
                Var.StartTime = DateTime.Now;
                Var.Stop = false;
                /*TimeSpan elapsedTime = TimeSpan.FromTicks(Var.StartTime.Ticks);
                Label2.Text = string.Format("{0:00}:{1:00}:{2:00}", elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds);*/
                
                string query = String.Format("SELECT * FROM Easy WHERE IDe = '{0}'", IDe);
                SqlCommand command = new SqlCommand(query, sqlConnection);
                if (sqlConnection.State == ConnectionState.Open)
                {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    IDataRecord dataRecord = reader;

                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                        {
                            string code = String.Format("{0}", dataRecord[(3 * i + j) + 1]);
                            int index = code.IndexOf(' ');
                            if (index != -1)
                                code = code.Remove(index, 1);
                            array[i, j] = code;
                            if (code.ElementAt(0) == 'P')
                            {
                                true_array[i, j] = 1;
                                P_i = i;
                                P_j = j;
                                P_pos = Convert.ToInt32(code.ElementAt(1)) - 48;
                            }
                        }
                    finish = String.Format("{0}", dataRecord[10]);
                    reader.Close();
                }

                string edit_query = "INSERT INTO sessions_3x3 (IDs, IDa, x11, x12, x13, x21, x22, x23, x31, x32, x33, finish) " +
                                    "VALUES (@IDs, @IDa, @x11, @x12, @x13, @x21, @x22, @x23, @x31, @x32, @x33, @finish)";
                edit_command = new SqlCommand(edit_query, sqlConnection);

                edit_command.Parameters.AddWithValue("@IDs", IDs);
                edit_command.Parameters.AddWithValue("@IDa", IDa);
                edit_command.Parameters.AddWithValue("@x11", array[0, 0]);
                edit_command.Parameters.AddWithValue("@x12", array[0, 1]);
                edit_command.Parameters.AddWithValue("@x13", array[0, 2]);
                edit_command.Parameters.AddWithValue("@x21", array[1, 0]);
                edit_command.Parameters.AddWithValue("@x22", array[1, 1]);
                edit_command.Parameters.AddWithValue("@x23", array[1, 2]);
                edit_command.Parameters.AddWithValue("@x31", array[2, 0]);
                edit_command.Parameters.AddWithValue("@x32", array[2, 1]);
                edit_command.Parameters.AddWithValue("@x33", array[2, 2]);
                edit_command.Parameters.AddWithValue("@finish", finish);
                edit_command.ExecuteNonQuery();
            }
            else
            {
                string query = String.Format("SELECT * FROM sessions_3x3 WHERE IDa = '{0}'", IDa);
                SqlCommand command = new SqlCommand(query, sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                IDataRecord dataRecord = reader;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                    {
                        string code = String.Format("{0}", dataRecord[(3 * i + j) + 2]);
                        int index = code.IndexOf(' ');
                        if (index != -1)
                            code = code.Remove(index, 1);
                        array[i, j] = code;
                        if (code.ElementAt(0) == 'P')
                        {
                            P_i = i;
                            P_j = j;
                            P_pos = Convert.ToInt32(code.ElementAt(1)) - 48;
                        }
                    }
                finish = String.Format("{0}", dataRecord[11]);

                reader.Close();
            }
        }
        protected void Timer_Tick(object sender, EventArgs e)
        //Обработчик события Tick, которое посылает Timer.
        {
            // Вычисление времени, прошедшего с начала отсчета
            TimeSpan elapsedTime = DateTime.Now - Var.StartTime;

            // Отображение времени на странице
            label_time.Text = string.Format("{0:00}:{1:00}:{2:00}", elapsedTime.Hours, elapsedTime.Minutes, elapsedTime.Seconds); ;
        }
        protected void result()
        {
            string script = "<script type='text/javascript'>openModal();</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "openModal", script);
            label_result.Text = label_time.Text;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            connect();
            light(P_i, P_j, P_pos, false);
            if (Var.Stop)
            {
                string script = "<script type='text/javascript'>openModal();</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "openModal", script);
                label_result.Text = label_time.Text;
            }
            else
                timer.Enabled = true;


            /*string script1 = "<script type='text/javascript'>openModal();</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "openModal", script1);*/
        }

        protected void ImageButton_Click(object sender, ImageClickEventArgs e)
        {
            string index = ((ImageButton)sender).ID;
            int ind = Convert.ToInt32(index.ElementAt(index.Length-1)) - 49;
            int i = ind / 3;
            int j = ind - 3 * i;

            char type = array[i, j].ElementAt(0);
            int old_pos = Convert.ToInt32(array[i, j].ElementAt(array[i, j].Length-1)) - 48;
            int pos = old_pos + 1;
            if (type == 'I')
            {
                if (pos == 3)
                    pos = 1;
            }
            else if (pos == 5)
                pos = 1;

            array[i, j] = array[i, j].Replace(old_pos.ToString(), pos.ToString());
            string code = "x" + (i + 1).ToString() + (j + 1).ToString();
            string edit_query = String.Format("UPDATE sessions_3x3 SET " + code + " = '{0}' WHERE IDa = '{1}'", array[i, j], IDa);
            edit_command = new SqlCommand(edit_query, sqlConnection);
            edit_command.ExecuteNonQuery();

            light(P_i, P_j, P_pos, false);

            if (check()) //Вот вэтом месте добавить вывод контейнера (диалогового окна) с кнопками и результатом!!!
            {
                timer.Enabled = false;
                Var.Stop = true;
                string script = "<script type='text/javascript'>pageLoad();</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "pageLoad", script);
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            string delete_query = String.Format("DELETE FROM sessions_3x3 WHERE IDa = '{0}'", IDa);
            SqlCommand delete = new SqlCommand(delete_query, sqlConnection);
            delete.ExecuteNonQuery();
            Response.Redirect("~/levels");
        }

        protected void remove_Click(object sender, EventArgs e)
        {
            string delete_query = String.Format("DELETE FROM sessions_3x3 WHERE IDa = '{0}'", IDa);
            SqlCommand delete = new SqlCommand(delete_query, sqlConnection);
            delete.ExecuteNonQuery();
            Response.Redirect(Request.RawUrl);
            string script = "<script type='text/javascript'>closeModal();</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "closeModal", script);
        }
    }
}
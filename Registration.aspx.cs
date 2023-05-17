//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace autorization
{
    public partial class Registration : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = null;
        IDataRecord dataRecord;
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LightDB"].ConnectionString);
            sqlConnection.Open();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Autorization");
        }
            protected void Button1_Click1(object sender, EventArgs e)
        {
            if(TextBox1.Text == "")
            {
                Label1.Text = "Введите логин";
                Label1.BackColor = Color.Red;
                return;
            }
            if (TextBox2.Text == "" || TextBox4.Text == "")
            {
                Label1.Text = "Введите пароль";
                Label1.BackColor = Color.Red;
                return;
            }
            if (TextBox2.Text != TextBox4.Text)
            {
                Label1.Text = "Пароли не совпадают";
                Label1.BackColor = Color.Red;
                return;
            }
            if (isLoginExists())
                return;

            string loginField = TextBox1.Text;
            string passField = TextBox2.Text;
            string query = String.Format("SELECT MAX(IDa) FROM account");
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader read = command.ExecuteReader();
            read.Read();
            dataRecord = read;
            int ID = Convert.ToInt32(dataRecord[0]) + 1;
            read.Close();

            string test_query = String.Format("INSERT INTO account (IDa, aLogin, aPassword) VALUES ('{0}', '{1}', '{2}')", ID, loginField, passField);
            SqlCommand test = new SqlCommand(test_query, sqlConnection);
            test.ExecuteNonQuery();
            query = String.Format("SELECT * FROM account WHERE aLogin = '{0}'", loginField);
            command = new SqlCommand(query, sqlConnection);
            read = command.ExecuteReader();
            read.Read();
            dataRecord = read;
            Lights.Var.ID_a = Convert.ToInt32(dataRecord[0]);
            read.Close();
            Response.Redirect("~/levels");
        }
        public bool isLoginExists()
        {
            string loginField = TextBox1.Text;
            string query = String.Format("SELECT COUNT(IDa) FROM account WHERE aLogin = '{0}'", loginField);
            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader read = command.ExecuteReader();
            read.Read();
            int t = read.GetInt32(0);
            read.Close();
            if (t > 0)
            {
                Label1.Text = "Такой логин уже занят";
                Label1.BackColor = Color.Red;
                return true;
            }
            else
                return false;
        }

    }
}
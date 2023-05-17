using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
//using MySql.Data.MySqlClient;
using System.Drawing;
using System.Data.Common;
using System.Runtime.Remoting.Messaging;

namespace autorization
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LightDB"].ConnectionString);
            sqlConnection.Open();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registration");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            string loginField = TextBox1.Text;
            string passField = TextBox2.Text;

            string test_query = String.Format("SELECT * FROM account WHERE aLogin = '{0}' AND aPassword = '{1}'", loginField, passField);
            SqlCommand test = new SqlCommand(test_query, sqlConnection);
            SqlDataReader read = test.ExecuteReader();
            read.Read();
            IDataRecord dataRecord = read;
            int t = read.GetInt32(0);
            if (t > 0)
            {
                Lights.Var.ID_a = Convert.ToInt32(dataRecord[0]);
                Response.Redirect("~/levels");
            }
            else
            {
                Label1.Text = "Неправильно введен логин или пароль";
                Label1.BackColor = Color.Red;
            }
            read.Close();
        }
    }
}
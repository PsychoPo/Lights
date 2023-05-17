using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Lights
{
    public partial class levels : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LightDB"].ConnectionString);

            sqlConnection.Open();
            /*if (sqlConnection.State == ConnectionState.Open)
                TextBox1.Text = "Подключение установлено";*/
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Var.ID_e = 1;
            Response.Redirect("~/lvl_E1");
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Var.ID_e = 2;
            Response.Redirect("~/lvl_E1");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            Var.ID_e = 3;
            Response.Redirect("~/lvl_E1");
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Autorization");
        }
    }
}
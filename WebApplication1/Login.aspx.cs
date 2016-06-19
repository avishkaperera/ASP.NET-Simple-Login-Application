using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoLoginApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Validateuser(object sender, EventArgs e)
        {
            int userId = 0;
            string cs = "Data Source=.;Initial Catalog=TestDB;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("validate_user",con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username",txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                }
                switch(userId)
                {
                    case -1:
                        lblError.Text = "Username and/ or Password is invalid";
                        break;
                    case -2:
                        lblError.Text = "Account has not been activated";
                        break;
                    default:
                        FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, chkRemember.Checked);                        
                        break;
                }
            }
        }
    }
}
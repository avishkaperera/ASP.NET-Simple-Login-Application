using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoLoginApplication
{
    public partial class Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string cs = "Data Source=.;Initial Catalog=TestDB;Integrated Security=True";
                string activationCode = !string.IsNullOrEmpty(Request.QueryString["uid"]) ? Request.QueryString["uid"] : Guid.Empty.ToString();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("delete from UserActivation where ActivationCode=@code",con))
                    {
                        cmd.Parameters.AddWithValue("@code",activationCode);
                        con.Open();
                        if(cmd.ExecuteNonQuery() == 1)
                        {
                            Literal1.Text = "Activation Successfull";
                        }
                        else
                        {
                            Literal1.Text = "Invalid Activation Code";
                        }
                    }
                }
            }
        }
    }
}
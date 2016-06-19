using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoLoginApplication
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int userId = 0;
                string cs = "Data Source=.;Initial Catalog=TestDB;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand("insert_user"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                switch (userId)
                {
                    case -1:
                        Label1.Text = "Username already exists";
                        break;
                    case -2:
                        Label1.Text = "Email already exists";
                        break;
                    default:                                   
                        SendActivationEmail(userId);             
                        break;
                }
            }
        }

        private void SendActivationEmail(int userId)
        {
            
            string cs = "Data Source=.;Initial Catalog=TestDB;Integrated Security=True";
            string activationCode = Guid.NewGuid().ToString();
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("insert into UserActivation values (@UserId,@ActCode)",con))
                {
                    cmd.Parameters.AddWithValue("@UserId",userId);
                    cmd.Parameters.AddWithValue("@ActCode",activationCode);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            using (MailMessage mail = new MailMessage("myEmail@email.com", txtEmail.Text))
            {
                mail.Subject = "Activate Account";
                string body = "Hello "+txtUsername.Text.Trim()+", ";
                body += "<br/><br/><a href='"+Request.Url.AbsoluteUri.Replace("Register.aspx", "Activation.aspx?uid=" + activationCode + "'>Click here to activate your account</a>");
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "server address";
                smtp.EnableSsl = true;
                NetworkCredential credentials = new NetworkCredential("myUsername", "myPassword");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credentials;
                smtp.Port = 587;
                smtp.Send(mail);                
            }
        }
    }
}
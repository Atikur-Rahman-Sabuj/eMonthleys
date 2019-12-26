using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                txtUserId.Focus();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Customer c = new Customer();
                string PasswordHash = Encryption.EncryptPassword(txtUserId.Text.ToLower(), txtPassword.Text.ToLower());
                c = Customer.Login(txtUserId.Text.ToLower(), PasswordHash);
                if (c == null)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Email address and/or password incorrect.');", true);
                    FormsAuthentication.SignOut();
                    Session.Abandon();
                }
                else
                {
                    Session["User"] = c;
                    Session["CustomerId"] = c.Id;
                    Session["UserName"] = c.FirstName;
                    Session["CustomerType"] = c.CustomerType;
                    Session["Role"] = c.UserType;
                    //FormsAuthentication.Initialize();
                    FormsAuthentication.SetAuthCookie(c.Email, false);
                    //CreateAuthTicket(txtUserId.Text.ToLower(), c.UserType);
                    Response.Redirect("~/account/myaccount.aspx?CustomerId=" + c.Id);
                    //Response.Redirect("~/thanks.aspx");
                }
            }
        }

        private void CreateAuthTicket(string userName, string Role)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(20), false, Role);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            authCookie.Secure = FormsAuthentication.RequireSSL;
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }
    }
}
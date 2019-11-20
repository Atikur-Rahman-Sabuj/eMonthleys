using System;
using System.Web.UI;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class ChangePassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnChangePwd_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Customer usr = (Customer)Session["User"];
                string CurrentPass = Encryption.EncryptPassword(usr.Email.ToLower(), txtOldPassword.Text.ToLower());
                if (CurrentPass != usr.Password)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Current password incorrect!');", true);
                }
                else
                {
                    string NewHashed = Encryption.EncryptPassword(usr.Email.ToLower(), txtNewPassword.Text.ToLower());
                    usr.Password = NewHashed;
                    if (Customer.UpdateCustomerPassword(usr.Id, NewHashed))
                    {
                        Session["User"] = usr;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Your password has been changed.');", true);
                        Response.Redirect("~/account/myaccount.aspx");
                    }
                }

            }
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Password could not be changed.');", true);
        }
    }
}
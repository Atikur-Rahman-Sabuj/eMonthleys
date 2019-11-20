using System;
using System.Web.UI;
using System.Text;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class PasswordHelp : Page
    {
        protected void CaptchaValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            // validate the Captcha to check we're not dealing with a bot
            args.IsValid = PasswordHelpCaptcha.Validate(args.Value.Trim());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordHelpCaptcha.UserInputID = CaptchaCode.ClientID;
        }

        protected void BtnHelp_Click(object sender, EventArgs e)
        {
            Validate("vgHelp");
            if (Page.IsValid)
            {
                if (Customer.LoginExists(txtUserId.Text.ToLower()))
                {
                    Customer usr = Customer.GetCustomerDetails(txtUserId.Text.ToLower());
                    string tmpPass = Encryption.GetRandomPassword().ToLower();
                    string hashed = Encryption.EncryptPassword(txtUserId.Text.ToLower(), tmpPass);

                    try
                    {
                        if (Customer.UpdateCustomerPassword(usr.Id, hashed))
                        {
                            StringBuilder msg = new StringBuilder();
                            msg.Append("<p>Hi " + usr.FirstName + ",</p>");
                            msg.Append("<p>Here is you new temporary password.</p>");
                            msg.Append("<strong>" + tmpPass + "</strong>");
                            msg.Append("<p>Thanks,<br>You eMonthlies supprt team</p>");
                            if (Mailer.SendMail2Client(usr.Email, msg.ToString(), "You request to reset your Password.") == false)
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Your password was reset but an email with the temporary password could not be sent to the provided email address.');", true);
                            else
                                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", " alert('Your new temporary password will be sent to you to the email address on file shortly.');", true);
                            Response.Redirect("~/account/login.aspx");
                        }
                    }
                    catch
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Password reset failed!\nPlease try again or contact us if password help fails again.');", true);
                    }
                    finally
                    {
                        CaptchaCode.Text = null;
                    }
                }
                else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Sorry, we did not find an account that matches your email address.');", true);
            }
            else
            {
                CaptchaCode.Text = null;
            }
        }
    }
}
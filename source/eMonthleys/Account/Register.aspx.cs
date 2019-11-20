using System;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterCaptcha.UserInputID = CaptchaCode.ClientID;
            Form.DefaultButton = BtnCreateUser.UniqueID;
        }

        protected void CaptchaValidator_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            // validate the Captcha to check we're not dealing with a bot
            args.IsValid = RegisterCaptcha.Validate(args.Value.Trim());
        }

        protected void BtnCreateUser_Click(object sender, EventArgs e)
        {
            Validate("vgRegister");
            if (Page.IsValid)
            {
                if (LoginExists(TxtEmail.Text.ToLower()))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Sorry, a customer with this email address already exists.');", true);
                    TxtEmail.Focus();
                    return;
                }
                Customer c = new Customer
                {
                    CustomerType = RblCustomerType.SelectedValue,
                    Email = TxtEmail.Text.ToLower(),
                    Password = Encryption.EncryptPassword(TxtEmail.Text.ToLower(), txtPassword.Text.ToLower()),
                    Company = Server.HtmlEncode(txtCompany.Text),
                    FirstName = Server.HtmlEncode(txtFirstName.Text),
                    LastName = Server.HtmlEncode(txtLastName.Text),
                    Address1 = Server.HtmlEncode(txtAddress1.Text),
                    Address2 = Server.HtmlEncode(txtAddress2.Text),
                    StreetNo = Convert.ToInt32(txtStreetNo.Text),
                    StreetNoSuffix = txtStreetNoSuffix.Text,
                    City = txtCity.Text,
                    ZIP = txtZip.Text,
                    State = ddlState.SelectedValue,
                    Country = ddlCountry.SelectedValue,
                    POBox = txtPobox.Text,
                    Phone = txtPhone.Text,
                    CellPhone = txtCellPhone.Text,
                    UserType = "customer",
                    Active = true
                };

                try
                {
                    int CustomerId = Customer.InsertNewCustomer(c);
                    if (CustomerId > 0)
                    {
                        c.Id = CustomerId;
                        Session["User"] = c;
                        Session["CustomerId"] = CustomerId;
                        Session["UserName"] = c.FirstName;
                        Session["CustomerType"] = c.CustomerType;
                        Session["Role"] = c.UserType;
                        StringBuilder msg = new StringBuilder();
                        msg.Append("<p>Hi Sam,</p>");
                        msg.Append("<p>A new customer has registerd and is pending review.</p>");
                        msg.Append("Customer name: " + c.FirstName + " " + c.LastName);
                        if (Mailer.SendRequest(msg.ToString(), "New customer signup") == false)
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", " alert('Your registration was successful but the administrator could not be notified at this time.');", true);
                        FormsAuthentication.Initialize();
                        FormsAuthentication.SetAuthCookie(c.Email, true);
                        Response.Redirect("~/thanks.aspx");
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Registration failed!\nPlease try again or contact us if registration fails again.');", true);
                }
                finally
                {
                    CaptchaCode.Text = null;
                }
            }
            else
            {
                CaptchaCode.Text = null;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Registration failed!\nPlease try again or contact us if registration fails again.');", true);
            }
        }

        protected void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            if (LoginExists(TxtEmail.Text.ToLower()))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Sorry, a customer with this email address already exists.');", true);
                TxtEmail.Focus();
                return;
            }             
        }

        private bool LoginExists(string email)
        {
            if (Customer.LoginExists(email) == true)
            {
                return true;
            }
            else
                return false;
        }

        protected void RblCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RblCustomerType.SelectedIndex == 1)
            {
                pnlCompanyName.Enabled = false;
                //rfvCompany.Enabled = false;
                //rfvCompany.Visible = false;
            }
            else
            {
                pnlCompanyName.Enabled = true;
                //rfvCompany.Enabled = true;
                //rfvCompany.Visible = true;
            }
        }
    }
}
using System;
using System.Web.UI;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class NewCustomer : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Form.DefaultButton = BtnCreateUser.UniqueID;
        }

        protected void BtnCreateUser_Click(object sender, EventArgs e)
        {
            Validate("vgRegister");
            if (Page.IsValid)
            {
                Customer c = new Customer();
                c.CustomerType = RblCustomerType.SelectedValue;
                c.Email = TxtEmail.Text.ToLower();
                c.Password = Encryption.EncryptPassword(TxtEmail.Text.ToLower(), txtPassword.Text.ToLower());
                c.Company = Server.HtmlEncode(txtCompany.Text);
                c.FirstName = Server.HtmlEncode(txtFirstName.Text);
                c.LastName = Server.HtmlEncode(txtLastName.Text);
                c.Address1 = Server.HtmlEncode(txtAddress1.Text);
                c.Address2 = Server.HtmlEncode(txtAddress2.Text);
                c.StreetNo = Convert.ToInt32(txtStreetNo.Text);
                c.StreetNoSuffix = txtStreetNoSuffix.Text;
                c.City = txtCity.Text;
                c.ZIP = txtZip.Text;
                c.State = ddlState.SelectedValue;
                c.Country = ddlCountry.SelectedValue;
                c.POBox = txtPobox.Text;
                c.Phone = txtPhone.Text;
                c.CellPhone = txtCellPhone.Text;
                c.UserType = "customer";
                c.Active = true;
                try
                {
                    int CustomerId = Customer.InsertNewCustomer(c);
                    if (CustomerId > 0)
                    {
                        c.Id = CustomerId;
                        Session["NewCustomerId"] = CustomerId;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", " alert('The new customer has been added.');", true);
                        Response.Redirect("~/admin/customers.aspx");
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('New customer could not be added.');", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Registration failed!\nPlease try again or contact us if registration fails again.');", true);
        }

        protected void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            if (Customer.LoginExists(TxtEmail.Text.ToLower()) == true)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Sorry, a customer with this email address already exists.');", true);
                TxtEmail.Focus();
            }
        }

        protected void RblCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RblCustomerType.SelectedIndex == 1)
            {
                pnlCompanyName.Enabled = false;
            }
            else
            {
                pnlCompanyName.Enabled = true;
            }
        }
    }
}
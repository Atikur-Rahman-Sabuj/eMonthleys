using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class Customers : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void gvCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Customer clnt = Customer.GetCustomerDetails(Convert.ToInt32(e.CommandArgument));
            Session["SelectedCustomer"] = clnt;
            switch (e.CommandName)
            {
                case "Select":
                    LoadCustomerData(Convert.ToInt32(e.CommandArgument));
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$('#myModal').modal('show');", true);
                    break;
                case "Activate":
                    Customer c = Customer.GetCustomerDetails(Convert.ToInt32(e.CommandArgument));
                    if (Customer.ActivateUser(Convert.ToInt32(e.CommandArgument)))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('The customer #" + e.CommandArgument + " has been activated.');", true);
                        gvCustomers.DataBind();
                        NotifyCustomer(c);
                    }
                    else
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Failed activating customer #" + e.CommandArgument + ".');", true);
                    break;

                case "Deactivate":
                    if (Customer.DeactivateUser(Convert.ToInt32(e.CommandArgument)))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('The customer #" + e.CommandArgument + " has been deactivated.');", true);
                        gvCustomers.DataBind();
                    }
                    else
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Failed deaktivating customer #" + e.CommandArgument + ".');", true);
                    break;
                case "NewAd":
                    Response.Redirect("~/account/advertise.aspx?Customer=" + clnt.Id);
                    break;
                case "NewItem":
                    Response.Redirect("~/account/addvehicle.aspx?Customer=" + clnt.Id);
                    break;
                default:
                    break;
            }
        }

        protected void NotifyCustomer(Customer c)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<p>Hi " + c.FirstName + ",</p>");
            msg.Append("<p>Your account for emonthlies has been approved.</p>");
            msg.Append("<p>Thanks,<br />emonthlies</p>");
            if (Mailer.SendMail2Client(c.Email, msg.ToString(), "Log in approved") == false)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "info", " alert('Customer could not be notified.');", true);
        }

        protected void LoadCustomerData(int Id)
        {
            TextInfo tc = new CultureInfo("en-CA", false).TextInfo;
            Customer c = Customer.GetCustomerDetails(Id);
            txtCustomerType.Text = tc.ToTitleCase(c.CustomerType);
            txtCustomerName.Text = c.FirstName + " " + c.LastName;
            txtCompany.Text = c.Company;
            txtAddress.Text = c.StreetNo + " " + c.Address1 + "<br />" + c.City + ", " + c.State + " " + c.ZIP;
            txtPhone.Text = c.Phone + ", " + c.CellPhone;
            TxtEmail.Text = c.Email;
        }

        protected void gvCustomers_DataBinding(object sender, EventArgs e)
        {
            switch (ddlStatus.SelectedIndex)
            {
                case 0:
                    gvCustomers.Columns[11].Visible = true;
                    gvCustomers.Columns[12].Visible = false;
                    break;
                case 1:
                    gvCustomers.Columns[11].Visible = false;
                    gvCustomers.Columns[12].Visible = true;
                    break;
            }
        }

        protected void gvCustomers_DataBound(object sender, EventArgs e)
        {
            if (gvCustomers.Rows.Count > 0)
            {
                gvCustomers.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = gvCustomers.HeaderRow.Cells;
                for (int i = 0; i < cells.Count; i++)
                {
                    if (i == 0)
                    {
                        cells[i].Attributes.Add("class", "footable-visible footable-first-column");
                        cells[i].Attributes.Add("data-toggle", "true");
                    }
                    else
                    {
                        cells[i].Attributes.Add("class", "footable-visible");
                        cells[i].Attributes.Add("data-hide", "phone,tablet");
                        cells[i].Attributes.Add("style", "display: table-cell;");
                    }
                    if (i == cells.Count - 1)
                    {
                        cells[i].Attributes.Add("class", "footable-visible footable-last-column");
                        cells[i].Attributes.Add("data-hide", "phone,tablet");
                        cells[i].Attributes.Add("style", "display: table-cell;");
                    }
                }
            }
        }
    }
}
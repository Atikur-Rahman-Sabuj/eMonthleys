using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using eMonthleys.BLL;
using eMonthleys.Utils;
using System.Reflection;

namespace eMonthleys
{
    public partial class Ads : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCustomersAd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "on":
                    if (CustomerAd.SetActiveStatus(Convert.ToInt32(e.CommandArgument), true))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('The ad #" + e.CommandArgument + " has been activated.');", true);
                        gvCustomersAds.DataBind();
                    }
                    else
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Failed activating ad #" + e.CommandArgument + ".');", true);
                    break;

                case "off":
                    if (CustomerAd.SetActiveStatus(Convert.ToInt32(e.CommandArgument), false))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('The ad #" + e.CommandArgument + " has been deactivated.');", true);
                        gvCustomersAds.DataBind();
                    }
                    else
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Failed deaktivating ad #" + e.CommandArgument + ".');", true);
                    break;
                case "Review":
                    CustomerAd imgs = CustomerAd.GetCustomerAdDetails(Convert.ToInt32(e.CommandArgument));
                    if (imgs != null)
                    {
                        PropertyInfo[] props = imgs.GetType().GetProperties();
                        foreach (PropertyInfo p in props)
                        {
                            if (p.Name.Contains("Img"))
                            {
                                object img = p.GetValue(imgs, null);
                                if (img.ToString() != "")
                                {
                                    HtmlAnchor lnk = new HtmlAnchor();
                                    lnk.HRef = img.ToString();
                                    lnk.Attributes.Add("class", "fancybox-effects-a");
                                    lnk.InnerHtml = "<img src='/thumbnail.ashx?pic=" + img + "&size=80' class='thumb' alt='' />";
                                    plhImages.Controls.Add(lnk);
                                }
                            }
                        }
                        ltlAdDetails.Text = imgs.AdDetails;
                        if (imgs.URL != "")
                            txtUrl.Text = string.Concat("<a href='", imgs.URL, ", target='_blank'>", imgs.URL, "</a>");
                        hfAdId.Value = e.CommandArgument.ToString();
                        hfCustomerId.Value = imgs.CustomerId.ToString();
                    }
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$('#myModal').modal('show');", true);
                    break;
                default:
                    break;
            }
        }

        protected string SetPaypal(object dr)
        {
            string paypalstate = string.Empty;
            if (!DBNull.Value.Equals(DataBinder.Eval(dr, "PayPalState")))
            {
                paypalstate = DataBinder.Eval(dr, "PayPalState").ToString();
                if (paypalstate.Equals("SUCCESS"))
                    paypalstate = "Paid";
                else
                    paypalstate = "Unpaid";
            }
            return paypalstate;
        }


        protected void NotifyCustomer(int CustomerId, int AdId)
        {
            Customer customer = Customer.GetCustomerDetails(CustomerId);
            StringBuilder msg = new StringBuilder();
            msg.Append("<p>Hi " + customer.FirstName + ",</p>");
            msg.Append("<p>Your ad on emonthlies has been approved and expires in 30 days.");
            msg.Append("<p>Thanks for your patronage,<br />emonthlies</p>");
            if (Mailer.SendMail2Client(customer.Email, msg.ToString(), "Ad approved") == false)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "info", " alert('Customer could not be notified.');", true);
        }

        protected void gvCustomersAds_DataBinding(object sender, EventArgs e)
        {
            switch (ddlStatus.SelectedIndex)
            {
                case 1:
                    gvCustomersAds.Columns[8].Visible = false;
                    gvCustomersAds.Columns[9].Visible = false;
                    break;
                case 0:
                    gvCustomersAds.Columns[8].Visible = false;
                    gvCustomersAds.Columns[9].Visible = true;
                    break;
            }
        }

        protected void gvCustomersAds_DataBound(object sender, EventArgs e)
        {
            if (gvCustomersAds.Rows.Count > 0)
            {
                gvCustomersAds.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = gvCustomersAds.HeaderRow.Cells;
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

        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            if (CustomerAd.SetActiveStatus(Convert.ToInt32(hfAdId.Value), true))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('The ad #" + hfAdId.Value + " has been activated.');", true);
                NotifyCustomer(Convert.ToInt32(hfCustomerId.Value), Convert.ToInt32(hfAdId.Value));
            }
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Failed activating ad #" + hfAdId.Value + ".');", true);
            gvCustomersAds.DataBind();
        }

        protected void BtnDecline_Click(object sender, EventArgs e)
        {
            if (CustomerAd.DeclineAd(Convert.ToInt32(hfAdId.Value)))
                AdDeclined(Convert.ToInt32(hfCustomerId.Value), Convert.ToInt32(hfAdId.Value));
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Failed declining ad #" + hfAdId.Value + ".');", true);
            gvCustomersAds.DataBind();
        }

        protected void AdDeclined(int CustomerId, int AdId)
        {
            Customer customer = Customer.GetCustomerDetails(CustomerId);
            StringBuilder msg = new StringBuilder();
            msg.Append("<p>Hi " + customer.FirstName + ",</p>");
            msg.Append("<p>Your ad has been declined as it does not comply with emonthlies' advertising policies.");
            msg.Append("<br />Your payment will be refunded.");
            msg.Append("<p>Thanks for your patronage,<br />emonthlies</p>");
            if (Mailer.SendMail2Client(customer.Email, msg.ToString(), "Ad declined") == false)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "info", " alert('Customer could not be notified.');", true);
        }

    }
}
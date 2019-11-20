using System;
using System.Web;
using System.Web.UI;
using System.Text;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class ReviewVehicle : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NotifyCustomer(int CustomerId, int VehicleId, int FinId)
        {
            Customer c = Customer.GetCustomerDetails(CustomerId);
            CustomerVehicleInfo v = CustomerVehicleInfo.GetCustomerVehicleInfoDetails(VehicleId, FinId, false);
            StringBuilder msg = new StringBuilder();
            string lnk = string.Concat("<a href='https://www.emonthlies.com/VehicleDetails.aspx?id=", VehicleId, "'>Click here</a> to view your ad.");
            msg.Append("<p>Hi " + c.FirstName + ",</p>");
            msg.Append(string.Concat("<p>This is to confirm that your listing for: ", v.ModelYear, " ", v.Manufacturer, " ", v.Model, " has been approved.</p>"));
            msg.Append("<p>This posting is valid only for 90 days. ");
            msg.Append("If you wish to extend your ad you will have to repost.</p>");
            msg.Append(lnk);
            if (Mailer.SendMail2Client(c.Email, msg.ToString(), "Vehicle listing approved") == false)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "info", " alert('Customer could not be notified.');", true);
        }

        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            string[] args = Request.QueryString["id"].Split(',');
            int VehicleId = Convert.ToInt32(args[0]);
            int FinId = Convert.ToInt32(args[1]);

            if (CustomerVehicleInfo.SetApprovedStatus(VehicleId, FinId, true))
            {
                Financial.ChangeAdStatus(FinId, VehicleId, true);
                NotifyCustomer(Convert.ToInt32(Session["Seller"].ToString()), VehicleId, FinId);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('The vehicle posting #" + Request.QueryString["id"] + " has been approved.');", true);
                Response.Redirect("~/admin/vehicles.aspx");
            }
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Failed activating vehicle #" + Request.QueryString["id"] + ".');", true);
        }

        protected void BtnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/vehicles.aspx");
        }

        protected void BtnDecline_Click(object sender, EventArgs e)
        {
            CustomerVehicleInfo v = Session["CurrentVehicle"] as CustomerVehicleInfo;
            VehiclesBilling vb = VehiclesBilling.GetVehiclesBillingDetails(v.BillingId);
            vb.AdsRemaining += 1;
            if (CustomerVehicleInfo.DeclineItem(Convert.ToInt32(Request.QueryString["id"])))
            {
                bool remainingUpdated = VehiclesBilling.UpdateBilling(vb);
                AdDeclined(Convert.ToInt32(Session["Seller"].ToString()), v);
                Response.Redirect("~/admin/vehicles.aspx");
            }
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Failed declining ad #" + Request.QueryString["id"] + ".');", true);
        }

        protected void AdDeclined(int CustomerId, CustomerVehicleInfo v)
        {
            Customer customer = Customer.GetCustomerDetails(CustomerId);
            VehiclesBilling vb = VehiclesBilling.GetVehiclesBillingDetails(v.BillingId);
            StringBuilder msg = new StringBuilder();
            msg.Append(string.Concat("<p>RE: Your ad for ", v.ModelYear, " ", v.Manufacturer, " ", v.Model, "</p>"));
            msg.Append("<p>Hi " + customer.FirstName + ",</p>");
            msg.Append("<p>Your ad has not been placed. It does not comply with emonthlies' advertising policies.</p>");
            if (vb.PromoCode == "")
            {
                msg.Append(string.Concat("You have ", vb.AdsRemaining, " out of ", vb.AdsBought, " ads remaining in your account."));
            }
            msg.Append("<p>Thanks for your patronage,<br />emonthlies</p>");
            if (Mailer.SendMail2Client(customer.Email, msg.ToString(), "Ad info") == false)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "info", " alert('Customer could not be notified.');", true);
        }

        protected void BtnRepost_Click(object sender, EventArgs e)
        {
            string[] args = Request.QueryString["id"].Split(',');
            int VehicleId = Convert.ToInt32(args[0]);
            int FinId = Convert.ToInt32(args[1]);
            Financial f = Financial.GetFinancialDetailsByVehicleId(VehicleId, FinId);
            f.Id = 0;
            if (hfPayCycle.Value == Constants.emConstants.PaymentBiWeekly)
            {
                f.PaymentCycle = Constants.emConstants.PaymentBiWeekly;
            }
            else if (hfPayCycle.Value == Constants.emConstants.PaymentMonthly)
            {
                f.PaymentCycle = Constants.emConstants.PaymentMonthly;
            }
            f.PaymentWithTax = Convert.ToDouble(txtBiWeeklyPayment.Text);
            int fid = Financial.InsertNewFinancialDetails(f);
            if (fid > 0)
            {
                f.Id = fid;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", " alert('Reposted this vehicle with bi-weekly/monthly payment cycle.');", true);
                var nv = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                nv.Set("id", string.Concat(VehicleId, ",", fid));
                string url = Request.Url.AbsolutePath;
                Response.Redirect(url + "?" + nv);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Vehicle could not be reposted with bi-weekly/monthly payment cycle.');", true);
            }
        }
    }
}
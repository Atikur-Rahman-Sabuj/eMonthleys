using eMonthleys.BLL;
using System;
using System.Web;
using System.Web.UI;

namespace eMonthleys.Account
{
    public partial class viewmycarad : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("myaccount.aspx");
        }

        protected void BtnModify_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Concat("ModifyVehicle.aspx?id=", Request.QueryString["id"]));
        }

        protected void BtnRepost_Click(object sender, EventArgs e)
        {
            string[] args = Request.QueryString["id"].Split(',');
            int VehicleId = Convert.ToInt32(args[0]);
            int FinId = Convert.ToInt32(args[1]);
            //CustomerVehicleInfo.UpdateExpiry(DateTime.Now.AddMonths(3), VehicleId.ToString());             
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
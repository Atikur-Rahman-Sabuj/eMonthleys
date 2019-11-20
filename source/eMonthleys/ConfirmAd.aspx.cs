using System;
using eMonthleys.BLL;

namespace eMonthleys
{
    public partial class ConfirmAd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["item"])
            {
                case "ad":
                    if (Convert.ToInt32(Request.QueryString["id"]) > 0)
                    {
                        if (CustomerAd.Confirm(Convert.ToInt32(Request.QueryString["id"])))
                            lblThanks.Text = "Thanks for confirming your ad with us. Please allow 12 - 24 hours for your ad to be approved.";
                    }
                    break;
                case "car":
                    if (Convert.ToInt32(Request.QueryString["id"]) > 0)
                    {
                        if (CustomerVehicleInfo.Confirm(Convert.ToInt32(Request.QueryString["id"])))
                        {
                            lblThanks.Text = @"Thanks for confirming your vehicle ad with us. Please allow 12 - 24 hours for your ad to be approved. ";
                        }
                    }
                    break;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using eMonthleys.BLL;
using eMonthleys.DAL;

namespace eMonthleys
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            fillGrid();  
            FillYears(ddlYearLowerBound, 1965, 2045);
            FillYears(ddlYearUpperBound, 1965, 2050);
        }

        private void fillGrid()
        {
            List<iSearch> searchresutls = (List<iSearch>)Session["SearchResults"];
            gvResult.DataSource = searchresutls;
            gvResult.DataBind();
            if (searchresutls != null)
            {
                var rsltCount = String.Empty;
                var result = (from s in searchresutls
                              select s).ToList();
                if (result != null)
                {
                    string totalCars = (result.Count == 1) ? string.Concat(result.Count, " vehicle") : string.Concat(result.Count, " vehicles");
                    rsltCount = @"<div class='bold'><p>" + totalCars + " matched your search criteria.</p></div>";
                    ltlCount.Text = rsltCount;
                }
            }
        }

        private void FillYears(ListControl ddl, int ddlmin, int ddlmax)
        {
            for (var i = ddlmin; i < ddlmax; i++)
            {
                var item = new ListItem(i.ToString());
                ddl.Items.Add(item);
            }
        }

        protected string getVehicleData(object dr)
        {
            var igvRow = (iSearch)dr;



            //var gvRow = (Search)dr;
            var gvRow = Search.GetOneSearch(igvRow);
            var imgs = VehicleImage.SelectByVehicleId(gvRow.VehicleId);
            string imgDiv = @"<div class='srimg border-grey'><div class='status'>";
            if (gvRow.VehicleCondition.Equals("used"))
            {
                imgDiv += @"<p><span>Pre-Owned</span></p>";
            }
            else
            {
                imgDiv += @"<p><span>New</span></p>";
            }
            imgDiv += @"</div><div class='img-rounded centered'><img id='imgDetail' src='";
            if (imgs != null)
            {
                imgDiv += @"/thumbnail.ashx?pic=" + imgs.Img1 + "&size=150'";
            }
            else
            {
                imgDiv += @"'/images/cargrey.png'";
            }

            imgDiv += @" alt='generic car image' />";
            if (!string.IsNullOrEmpty(gvRow.Status))
            {
                imgDiv += @"<p class='sold'><span>" + gvRow.Status + "</span></p>";
            }
            imgDiv += @"</div></div>";

            string vehData = @"<div class='srdetail'>";
            string heading = gvRow.ModelYear.ToString();

            if (gvRow.Manufacturer == "Other")
                heading += " " + gvRow.MakeOther;
            else
                heading += " " + gvRow.Manufacturer;
            if (gvRow.Model == "Other")
                heading += " " + gvRow.ModelOther;
            else
                heading += " " + gvRow.Model;
            if (gvRow.ModelTrim == "Other")
                heading += " " + gvRow.OtherTrim;
            else
                heading += " " + gvRow.ModelTrim;
            vehData += @"<strong>" + heading + "</strong><div>Id# " + gvRow.VehicleId;
            vehData += @"</div>City: " + gvRow.City;
            if (gvRow.VehicleCondition.Equals("used"))
            {
                var cfl = string.Empty;
                switch (gvRow.LeaseOrFinance)
                {
                    case "f":
                        cfl = "Finance";
                        break;
                    case "l":
                        cfl = "Lease";
                        break;
                    case "c":
                        cfl = "Cash price";
                        break;
                    default:
                        break;
                }
                vehData += @"<div>Finance or Lease: " + cfl + "</div>";
            }
            vehData += @"<div class='bold'>Purchase price: " + gvRow.PurchasePrice.ToString(@"$#,##0.00;($#,##0.00\)") + "</div>";
            if (gvRow.LeaseOrFinance.Equals("f") || gvRow.LeaseOrFinance.Equals("l"))
            {
                vehData += @"<div class='bold'>Payment cycle: " + gvRow.PaymentCycle + "</div>";
                vehData += @"<div class='bold'>Payment: " + gvRow.PaymentWithTax.ToString(@"$#,##0.00;($#,##0.00\)") + "</div>";
                vehData += @"<div>Term of loan: " + gvRow.LeaseTerm + "</div>";
                if (gvRow.LeaseOrFinance.Equals("l"))
                {
                    if (gvRow.VehicleCondition.Equals("used"))
                    {
                        vehData += @"<div>Odometer reading: " + gvRow.CurrentMileage.ToString("N0") + " Km</div>";
                    }
                    vehData += @"<div>Free km's per year: " + gvRow.KmAllowance.ToString("N0") + "</div>";
                }
                else
                {
                    if (gvRow.VehicleCondition.Equals("used"))
                    {
                        vehData += @"<div>Odometer reading: " + gvRow.CurrentMileage.ToString("N0") + " Km</div>";
                    }
                }
            }
            else if (gvRow.LeaseOrFinance.Equals("c"))
            {
                if (gvRow.CurrentMileage > 1)
                {
                    vehData += @"<div class='bold'>Odometer reading: " + gvRow.CurrentMileage.ToString("N0") + " Km</div>";
                }
            }
            vehData += @"</div><div class='sraction'>";
            if (gvRow.CustomerType.Equals("private"))
            {
                vehData += @"Private sales";
            }
            else
            {
                vehData += Server.HtmlDecode(gvRow.Company);
            }
            vehData += @"<p>" + Server.HtmlDecode(gvRow.Comments) + "</p>";
            vehData += @"<div class='centered'><a id='BtnShowDetails' class='btn btn-primary'";
            vehData += @"href ='/VehicleDetails.aspx?id=" + gvRow.VehicleId + "&fid=" + gvRow.FinId + "'>Details</a></div></div><div class='clear'></div>";
            return imgDiv + vehData + "<br/><hr class='hred' />";
        }

        protected void rblFinancial_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rblFinancial.SelectedIndex)
            {
                case 0:
                case 1:
                    ddlCashpriceLB.ClearSelection();
                    ddlCashpriceUB.ClearSelection();
                    pnlFinaning.Enabled = true;
                    pnlFinaning.Visible = true;
                    pnlCashPay.Enabled = false;
                    pnlCashPay.Visible = false;
                    //ddlPayCycle.Enabled = true;
                    //ddlPaymentLowerBound.Enabled = true;
                    //ddlPaymentUpperBound.Enabled = true;
                    //ddlRemMonthsLB.Enabled = true;
                    //ddlRemMonthsUB.Enabled = true;
                    break;
                case 2:
                    ddlPaymentLowerBound.ClearSelection();
                    ddlPaymentUpperBound.ClearSelection();
                    ddlRemMonthsLB.ClearSelection();
                    ddlRemMonthsUB.ClearSelection();
                    ddlPayCycle.ClearSelection();
                    pnlFinaning.Enabled = false;
                    pnlFinaning.Visible = false;
                    pnlCashPay.Enabled = true;
                    pnlCashPay.Visible = true;
                    //ddlPayCycle.Enabled = false;
                    //ddlPaymentLowerBound.Enabled = false;
                    //ddlPaymentUpperBound.Enabled = false;
                    //ddlRemMonthsLB.Enabled = false;
                    //ddlRemMonthsUB.Enabled = false;
                    break;
                default:
                    pnlCashPay.Enabled = false;
                    pnlCashPay.Visible = false;
                    pnlFinaning.Enabled = false;
                    pnlFinaning.Visible = false;
                    //ddlPayCycle.Enabled = true;
                    //ddlPaymentLowerBound.Enabled = true;
                    //ddlPaymentUpperBound.Enabled = true;
                    //ddlRemMonthsLB.Enabled = true;
                    //ddlRemMonthsUB.Enabled = true;
                    break;
            }
        }

        protected void gvResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvResult.PageIndex = e.NewPageIndex;
            List<iSearch> searchresutls = (List<iSearch>)Session["SearchResults"];
            gvResult.DataSource = searchresutls;
            gvResult.DataBind();
        }

        protected void BtnSortSearch_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                pnlResults.Visible = false;
                pnlResults.Enabled = false;
                pnlFineResults.Visible = true;
                pnlFineResults.Enabled = true;
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('No search criteria selected.');", true);
            }
        }
    }
}
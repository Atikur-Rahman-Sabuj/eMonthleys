using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using eMonthleys.Utils;
using eMonthleys.BLL;
using eMonthleys.DAL;

namespace eMonthleys
{
    public partial class SearchVehicles : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string wp = "";                       
            string connector = " AND ";


            // 1. Payment budget
            double paymentlow = 0.0;
            double pricelow = 0.0;

            if(ddlPaymentLowerBound.SelectedIndex > 0)
            {
                if(ddlPaymentLowerBound.SelectedItem.Text.Contains("+"))
                {
                    paymentlow = Convert.ToDouble(ddlPaymentLowerBound.SelectedItem.Text.Substring(0, ddlPaymentLowerBound.SelectedItem.Text.Length - 1));
                }
                else
                {
                    paymentlow = Convert.ToDouble(ddlPaymentLowerBound.SelectedItem.Text);
                }
            }

            if(ddlPriceLow.SelectedIndex > 0)
            {
                if (ddlPriceLow.SelectedItem.Text.Contains("+"))
                {
                    pricelow = Convert.ToDouble(ddlPriceLow.SelectedItem.Text.Substring(0, ddlPriceLow.SelectedItem.Text.Length - 1));
                }
                else
                {
                    pricelow = Convert.ToDouble(ddlPriceLow.SelectedItem.Text);
                }
            }

            string budget;
            if (ddlPaymentLowerBound.SelectedIndex > 0 && ddlPaymentUpperBound.SelectedIndex > 0)
            {
                budget = string.Concat(" paymentWithTax >= ", paymentlow, " AND ",
                    "paymentWithTax <= ", Convert.ToDouble(ddlPaymentUpperBound.SelectedValue), " AND LeaseOrFinance IN ('f', 'l')");
                wp += string.Concat(connector, budget);
            }
            else if (ddlPaymentLowerBound.SelectedIndex <= 0 && ddlPaymentUpperBound.SelectedIndex > 0)
            {
                budget = string.Concat(" paymentWithTax <= ", Convert.ToDouble(ddlPaymentUpperBound.SelectedValue), " AND LeaseOrFinance IN ('f', 'l')");
                wp += string.Concat(connector, budget);
            }
            else if (ddlPaymentLowerBound.SelectedIndex > 0 && ddlPaymentUpperBound.SelectedIndex <= 0)
            {
                budget = string.Concat(" paymentWithTax >= ", paymentlow, " AND LeaseOrFinance IN ('f', 'l')");
                wp += string.Concat(connector, budget);
            }
            else if (ddlPriceLow.SelectedIndex > 0 && ddlPriceHigh.SelectedIndex > 0)
            {
                budget = string.Concat(" purchaseprice >= ", pricelow, " AND ",
                    "purchaseprice <= ", Convert.ToDouble(ddlPriceHigh.SelectedValue));
                wp += string.Concat(connector, budget);
            }
            else if (ddlPriceLow.SelectedIndex <= 0 && ddlPriceHigh.SelectedIndex > 0)
            {
                budget = string.Concat(" purchaseprice <= ", Convert.ToDouble(ddlPriceHigh.SelectedIndex));
                wp += string.Concat(connector, budget);
            }
            else if (ddlPriceLow.SelectedIndex > 0 && ddlPriceHigh.SelectedIndex <= 0)
            {
                budget = string.Concat(" purchaseprice >= ", pricelow);
                wp += string.Concat(connector, budget);
            }

            // 2. Vehicle Styles
            string sVehicleStyles = " vehiclecategoryid in (";
            bool b = false;
            foreach (ListItem item in cbxvType.Items)
            {
                if (item.Selected)
                {
                    sVehicleStyles = sVehicleStyles + item.Value + ",";
                    b = true;

                }
            }
            if (b)
            {
                sVehicleStyles = Helpers.LeftString(sVehicleStyles, sVehicleStyles.Length - 1) + ")";
                b = false;
                wp = wp + connector + sVehicleStyles;
                connector = " AND ";
            }
            else
                sVehicleStyles = "";


            // 3. Manufacturer
            string sManufactures = " manufacturer in (";
            List<string> makes = new List<string>();
            foreach (ListItem item in lbxMakes.Items)
            {
                if (item.Selected)
                    makes.Add("'" + item.Value + "'");
            }
            if (makes.Count > 0)
            {
                sManufactures += String.Join(",", makes) + ")";
                wp = wp + connector + sManufactures;
                connector = " AND ";
            }
            else
                sManufactures = "";

            // 4. State
            string sState;

            if (ddlState.SelectedIndex > 0)
            {
                sState = string.Concat(" province = '", ddlState.SelectedValue, "' ");
                wp = wp + connector + sState;
                connector = " AND ";
            }

            //if (txtCity.Text != "")
            //{
            //    wp += string.Concat(connector, "LOWER(city) = '", txtCity.Text.ToLower(), "'");
            //    connector = " AND ";
            //}

            //ToDo: Atikur Rahman Sabuj: This is the initial code comment this if using improved code
            List<Search> CustomerVehicles = new List<Search>();
            CustomerVehicles = Search.GetAllSearch(wp);
            Session["SearchResults"] = CustomerVehicles;


            //ToDo: Atikur Rahman Sabuj: Use this code to improve website speed this code doesn't process the search result all at once
            //List<iSearch> customerVehicles = new List<iSearch>();
            //customerVehicles = SearchBase.Instance.SelectAll(wp);
            //Session["SearchResults"] = customerVehicles;


            Response.Redirect("~/SearchResults.aspx");
        }
    }
}

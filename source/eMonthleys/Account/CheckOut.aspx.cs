using System;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Text;
using eMonthleys.BLL;
using eMonthleys.Utils;
using PayPal.PayPalAPIInterfaceService.Model;

namespace eMonthleys
{
    public partial class CheckOut : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Keys.Count > 0)
            {
                if (Request.QueryString["promo"] != null)
                {
                    if (Request.QueryString["promo"] == "1" && Request.QueryString["adtype"] == "Private")
                    {
                        CustomerVehicleInfo vi = (CustomerVehicleInfo)Session["VehicleInfo"];
                        VehiclesBilling vb = Session["VehicleBilling"] as VehiclesBilling;
                        if (CustomerVehicleInfo.UpdateBillingId(vi.Id, vb.Id))
                        {
                            NotifyCustomer(vi.Id, Request.QueryString["item"], 0.99, "1", "");
                            NotifyAdmin(Request.QueryString["item"], 0, "1", "");
                        }
                        else
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('An error occurred');", true);
                    }
                }

                if (!IsPostBack)
                {
                    BindYear();
                    switch (Request.QueryString["item"])
                    {
                        case "ad":
                            switch (Request.QueryString["size"])
                            {
                                case "L":
                                    lblItem.Text = "Large Ad (rotating banner)";
                                    txtPayment.Text = "199.00";
                                    break;
                                case "S":
                                    lblItem.Text = "Small Ad (rotating images)";
                                    txtPayment.Text = "99.00";
                                    break;
                            }
                            break;
                        case "car":

                            switch (Request.QueryString["size"])
                            {
                                case "1":
                                    lblItem.Text = "1 vehicle";
                                    switch (Request.QueryString["adtype"])
                                    {
                                        case "Business":
                                            txtPayment.Text = "9.99";
                                            break;
                                        case "Private":
                                            txtPayment.Text = "0.99";
                                            break;
                                    }
                                    break;
                                case "8":
                                    lblItem.Text = "8 vehicles";
                                    txtPayment.Text = "49.99";
                                    break;
                                case "20":
                                    lblItem.Text = "20 vehicles";
                                    txtPayment.Text = "99.99";
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        private void BindYear()
        {
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear; i <  currentYear + 10; i++)
            {
                ddlExpYear.Items.Add(i.ToString());
            }
        }

        protected void BtnPayNow_Click(object sender, EventArgs e)
        {
            Customer c = (Customer)Session["User"] as Customer;
            CreditCardDetailsType creditCard = new CreditCardDetailsType();
            switch (rblCardType.SelectedValue)
            {
                case "visa":
                    creditCard.CreditCardType = CreditCardTypeType.VISA;
                    break;
                case "mastercard":
                    creditCard.CreditCardType = CreditCardTypeType.MASTERCARD;
                    break;
                //case "discover":
                //    creditCard.CreditCardType = CreditCardTypeType.DISCOVER;
                //    break;
                //case "amex":
                //    creditCard.CreditCardType = CreditCardTypeType.AMEX;
                //    break;
            }
            creditCard.CreditCardNumber = txtCardNumber.Text;
            creditCard.ExpMonth = Convert.ToInt16(ddlMonthExp.SelectedValue);
            creditCard.ExpYear = Convert.ToInt16(ddlExpYear.SelectedValue);

            AddressType adrs = new AddressType
            {
                Street1 = txtAddress.Text,
                StateOrProvince = ddlState.SelectedValue,
                PostalCode = txtPostalCode.Text,
                CityName = txtCity.Text
            };

            PayerInfoType cardOwner = new PayerInfoType
            {
                Payer = c.Email
            };
            switch (ddlCountry.SelectedValue)
            {
                case "CA":
                    cardOwner.PayerCountry = CountryCodeType.CA;
                    adrs.Country = CountryCodeType.CA;
                    break;
                case "US":
                    cardOwner.PayerCountry = CountryCodeType.US;
                    adrs.Country = CountryCodeType.US;
                    break;
            }
            cardOwner.Address = adrs;

            PersonNameType payer = new PersonNameType
            {
                FirstName = txtFirstNameOnCard.Text.ToUpper(),
                LastName = txtLastNameOnCard.Text.ToUpper()
            };

            cardOwner.PayerName = payer;
            creditCard.CardOwner = cardOwner;

            switch (Request.QueryString["item"])
            {
                case "ad":
                    switch (Request.QueryString["size"])
                    {
                        case "L":
                            Session["AdType"] = "Business Ad Large";
                            GetPaid("ad", "Large Ad (rotating banner)", "199", creditCard);
                            break;
                        case "S":
                            Session["AdType"] = "Business Ad Small";
                            GetPaid("ad", "Small Ad (rotating images)", "99", creditCard);
                            break;
                    }
                    break;
                case "car":
                    string amount = string.Empty;
                    switch (Request.QueryString["adtype"])
                    {
                        case "Business":
                            Session["AdType"] = "Dealership item sales ad";
                            amount = "9.99";
                            break;
                        case "Private":
                            Session["AdType"] = "Private item sales ad";
                            amount = "0.99";
                            break;
                    }
                    switch (Request.QueryString["size"])
                    {
                        case "1":
                            GetPaid("car", "1 vehicle", amount, creditCard);
                            break;
                        case "8":
                            GetPaid("car", "8 vehicles", "49.99", creditCard);
                            break;
                        case "20":
                            GetPaid("car", "20 vehicles", "99.99", creditCard);
                            break;
                    }
                    break;
            }
        }

        protected void GetPaid(string itemType, string aditem, string amnt, CreditCardDetailsType cc)
        {
            HttpContext CurrContext = HttpContext.Current;
            //amnt = "1.00";
            try
            {
                DoDirectPaymentResponseType reply = DirectPayment.DoDirectPaymentAPIOperation(cc, amnt);
                Session["Reply"] = reply;
                Session["PaymentInfo"] = cc;
                if (reply.Ack.ToString().Trim().ToUpper().Equals("SUCCESS"))
                {
                    switch (itemType)
                    {
                        case "car":
                            VehiclesBilling vb = Session["VehicleBilling"] as VehiclesBilling;
                            vb.PayPalId = reply.TransactionID;
                            vb.PayPalState = reply.Ack.ToString();
                            vb.CreateTime = Convert.ToDateTime(reply.Timestamp);
                            if (VehiclesBilling.PaidInFull(vb))
                            {
                                CustomerVehicleInfo.UpdateBillingId(Convert.ToInt32(Session["VehicleId"]), vb.Id);
                                NotifyCustomer(Convert.ToInt32(Session["VehicleId"]), itemType, vb.Payment, "0", reply.TransactionID);
                                NotifyAdmin(Request.QueryString["item"], vb.Payment, "0", reply.TransactionID);
                            }
                            break;
                        case "ad":
                            AdsBilling ad = new AdsBilling
                            {
                                CustomerId = Convert.ToInt32(Session["CustomerId"]),
                                AdId = Convert.ToInt32(Request.QueryString["id"]),
                                Payment = Convert.ToDouble(amnt),
                                PayPalId = reply.TransactionID,
                                PayPalState = reply.Ack.ToString(),
                                CreateTime = Convert.ToDateTime(reply.Timestamp)
                            };
                            if (AdsBilling.InsertNewBilling(ad))
                            {
                                CustomerAd.PaidInFull(ad.AdId);
                                NotifyCustomer(ad.AdId, itemType, ad.Payment, "0", reply.TransactionID);
                                NotifyAdmin(Request.QueryString["item"], ad.Payment, "0", reply.TransactionID);
                            }
                            break;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Transaction failed, please check your credit card information and try again.');", true);
                    //Server.Transfer("~/account/PaymentResponse.aspx");
                }
            }
            catch (WebException ex)
            {
                CurrContext.Items.Add("Error", ex.Message);
                ErrorHandler.writeExceptionToLogFile(ex);
            }
        }

        private void NotifyAdmin(string item, double payment, string promo, string replyid)
        {
            Customer c = (Customer)Session["User"];
            StringBuilder msg = new StringBuilder();
            msg.Append("<p>Hi Sam,</p>");
            string subjectline = string.Empty;
            switch (item)
            {
                case "car":
                    msg.Append("<p>A new vehicle has been posted and is pending approval.</p>");
                    if (c.CustomerType == "Business")
                        subjectline = "Paid business vehicle ad";
                    else
                        subjectline = "Paid private ad";
                    break;
                case "ad":
                    subjectline = "Paid business ad";
                    msg.Append("<p>A new ad has been posted and is pending approval.</p>");
                    break;
            }
            msg.Append(string.Concat("Customer name: ", c.FirstName, " ", c.LastName));
            if (promo == "1")
            {
                subjectline = "Free private ad";
            }
            else
            {
                msg.Append(string.Concat("<p>A payment of ", string.Format("{0:c}", payment), " has been made via PayPal.</p>"));
                msg.Append(string.Concat("<p>Paypal reference id: <strong>", replyid, "</strong></p>"));
            }
            if (Mailer.SendRequest(msg.ToString(), subjectline) == false)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", " alert('Your ad was posted successfully but the administrator could not be notified at this time. The approval may take upto 24 hours.');", true);
            else
            {
                if (promo != "1")
                    Server.Transfer("~/account/PaymentResponse.aspx");
                else
                    Response.Redirect("~/account/completed.aspx");
            }
        }

        protected void NotifyCustomer(int itemId, string item, double payment, string promo, string replyid)
        {
            Customer c = (Customer)Session["User"];
            StringBuilder msg = new StringBuilder();

            msg.Append(string.Concat("<p>Hi ", c.FirstName, ",</p>"));
            msg.Append("<p>Thanks for placing an ad with emonthlies.com. Just one more step to verify your ad. ");
            msg.Append(string.Concat("<a href='https://www.emonthlies.com/confirmad.aspx?item=", item, "&id=", itemId, "'>"));
            msg.Append("Confirm your ad</a>. We will approve your ad in 12 - 24 hours.</p>");
            if (promo != "1")
            {
                CreditCardDetailsType cc = (CreditCardDetailsType)Session["PaymentInfo"] as CreditCardDetailsType;
                string credit_card_type =  cc.CreditCardType.Value.ToString();
                string credit_card_number = cc.CreditCardNumber;
                msg.Append(string.Concat("<p>Your ", credit_card_type, " ending with ", credit_card_number.Remove(0, credit_card_number.Length - 4), " will be charged the amount of "));
                msg.Append("<p>" + payment.ToString(@"$#,##0.00") + "</p>");
                msg.Append(string.Concat("<p>Pleaes keep the payment id <strong>", replyid, "</strong> for reference.</p>"));
            }
            else
                msg.Append("<p>This ad is a free promotional ad.</p>");
            if (item == "car")
            {
                msg.Append("<p>This posting is valid for 90 days and will automatically discontinue. ");
            }
            else
            {
                msg.Append("<p>This ad is valid for 30 days and will automatically discontinue. ");
            }
            msg.Append("<p>Thanks for your business,<br />Your emonthlies sales team</p>");

            if (Mailer.SendMail2Client(c.Email, msg.ToString(), "Confirm your ad") == false)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "info", " alert('We could not send you an email to verify your ad at this time.');", true);
        }
    }
}
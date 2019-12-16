using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.Configuration;
using eImage = System.Drawing.Image;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class AddVehicle : Page
    {
        private Customer Usr
        {
            get
            {
                if (Request.QueryString.Keys.Count > 0)
                    return (Customer)Session["SelectedCustomer"];
                else
                    return (Customer)Session["User"];
            }
        }

        private bool IsPromo
        {
            get
            {
                if (DateTime.Now < DateTime.ParseExact(WebConfigurationManager.AppSettings["PromoExpiry"], "MM/dd/yyyy", CultureInfo.CurrentCulture))
                    return true;
                else
                    return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["adsRemaining"] = false;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$( '#tabs' ).tabs({ disabled: [1, 2] });", true);
                //FillYearsDdl();
                VehiclesBilling CurrentBilling = new VehiclesBilling();
                if (Usr.CustomerType == "Business")
                {
                    CurrentBilling = VehiclesBilling.RemainingVehicleAdsBillingDetails(Usr.Id);
                    if (CurrentBilling != null)
                    {
                        Session["CurrentBilling"] = CurrentBilling;
                        if (CurrentBilling.AdsRemaining > 0)
                            Session["adsRemaining"] = true;

                        ltlRemaining.Text = string.Concat("<p class='text-info bold'>You have ", CurrentBilling.AdsRemaining, " out of ", CurrentBilling.AdsBought, " ads remaining.</p>");
                    }
                    else
                        ltlRemaining.Text = string.Empty;
                }
            }
        }

        private void FillYearsDdl()
        {
            for (int i = 2000; i <= DateTime.Now.Year + 5; i++)
            {
                ddlYear.Items.Add(i.ToString());
            }
            ddlYear.Items.Insert(0, "Please select");
        }

        protected void BtnSaveVehicle_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string[] cYears = { DateTime.Now.Year.ToString(), (DateTime.Now.Year + 1).ToString() };
                CustomerVehicleInfo vi = new CustomerVehicleInfo();
                DateTime AdExpiry = DateTime.Now.AddMonths(1); //new DateTime(DateTime.Now.Month==12?DateTime.Now.Year+1:DateTime.Now.Year, DateTime.Now.Month==12?1:DateTime.Now.Month+1, DateTime.Now.Day);
                vi.Id = 0;
                vi.Seller = Usr.Id;
                vi.VehicleCondition = rblCondition.SelectedValue;
                vi.VehicleCategoryId = Convert.ToInt16(rblVehicleType.SelectedValue);
                vi.ModelYear = Convert.ToInt16(ddlYear.SelectedValue);
                if (DdlMakes.SelectedItem.Text.Equals("Other"))
                {
                    vi.Manufacturer = "Other";
                    vi.OtherMake = TxtMakeOther.Text;
                    vi.Model = "Other";
                    vi.OtherModel = TxtModelOther.Text;
                    vi.ModelTrim = 60931;
                    vi.OtherTrim = TxtModelTrim.Text;
                }
                else
                {
                    vi.Manufacturer = DdlMakes.SelectedValue;
                    vi.OtherMake = string.Empty;
                }
                if (DdlModel.Enabled)
                    if (DdlModel.SelectedItem.Text.Equals("Other"))
                    {
                        vi.Model = "Other";
                        vi.OtherModel = TxtModelOther.Text;
                        vi.ModelTrim = 60931;
                        vi.OtherTrim = TxtModelTrim.Text;
                    }
                    else
                    {
                        vi.Model = DdlModel.SelectedValue;
                        vi.OtherModel = string.Empty;
                    }
                if (DdlTrim.Enabled)
                {
                    vi.ModelTrim = Convert.ToInt32(DdlTrim.SelectedValue);
                    vi.OtherTrim = string.Empty;
                    if (DdlTrim.SelectedItem.Text.Equals("Other"))
                    {
                        vi.OtherTrim = TxtModelTrim.Text;
                    }
                }
                else
                {
                    vi.ModelTrim = 60931;
                    vi.OtherTrim = string.Empty;
                }
                vi.ExteriorColor = ddlBodyColour.SelectedValue;
                vi.InteriorColor = ddlInteriorColour.SelectedValue;
                vi.CurrentMileage = Convert.ToInt32(txtMileage.Text);
                vi.FuelType = ddlFuel.SelectedValue;
                vi.Transmission = ddlTransmission.SelectedValue;
                vi.Wheels = ddlWheels.SelectedValue;
                vi.ChromeWheels = cbxChrome.Checked;
                vi.Tires = ddlTires.SelectedValue;
                vi.ExtraWinterTires = cbxWinterTires.Checked;
                vi.Expires = AdExpiry;
                //if (cYears.Contains(ddlYear.SelectedItem.Text))
                //{
                //    vi.Expires = DateTime.Now.AddYears(1);
                //}
                //else
                //{
                //    vi.Expires = DateTime.Now.AddMonths(3);
                //}
                vi.Comments = Server.HtmlEncode(txtComments.Text);
                //if (Session["Role"].ToString() == "admin")
                //{
                vi.Approved = true;
                vi.Confirmed = true;
                //}
                //else
                //{
                //    vi.Approved = true;
                //    vi.Confirmed = false;
                //}
                vi.Displacement = txtDisplacement.Text;
                vi.Updated = DateTime.Now;

                Session["VehicleInfo"] = vi;
                Session["VehicleFeatures"] = GetFeatures();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$( '#tabs' ).tabs({ active: 1 });$( '#tabs' ).tabs('enable', 1);$( '#tabs' ).tabs({ disabled: [2] });", true);
            }
        }

        protected void BtnSubmitLease_Click(object sender, EventArgs e)
        {
            Financial ltd = new Financial();
            if (Page.IsValid)
            {
                ltd.Id = 0;
                ltd.LeaseOrFinance = rblLeaseOrFinance.SelectedValue;
                ltd.VehicleId = 0;
                ltd.PaymentCycle = ddlPayCycle.SelectedValue;
                ltd.PaymentWithTax = Helpers.ConvertNullDblToZero(txtMonthlyWithTax.Text);
                ltd.OriginalDown = Helpers.ConvertNullDblToZero(txtOriginalDown.Text);
                ltd.SecurityDeposit = Helpers.ConvertNullDblToZero(txtSecurityDeposit.Text);
                ltd.PoEndOfLease = ddlPurchaseOpEndOfLease.SelectedValue;
                ltd.KmAllowance = Helpers.ConvertNullInt64ToZero(txtKmAllowance.Text);
                ltd.ExcessKmCharge = Helpers.ConvertNullDblToZero(txtExcessKmCharge.Text);
                ltd.LeaseTerm = Helpers.ConvertNullIntToZero(txtOriginalLeaseTerm.Text);
                ltd.LeaseExpiry = (string.IsNullOrEmpty(txtLeaseExpiry.Text)) ? null : Helpers.ExtractNullableDateTimeFromString(txtLeaseExpiry.Text);
                ltd.BuyBack = Helpers.ConvertNullDblToZero(txtBuyBack.Text);
                ltd.Balloon = Helpers.ConvertNullDblToZero(txtBalloon.Text);
                ltd.PurchasePrice = Helpers.ConvertNullDblToZero(txtPurchasePrice.Text);                
                if (ltd.LeaseOrFinance != "c")
                {
                    ltd.Summary = Server.HtmlEncode(txtSummary.Text);
                }
                else
                {
                    ltd.Summary = string.Empty;
                }
                ltd.Comments = string.Empty;
                ltd.AdStatus = true;
                Session["FinancialInfo"] = ltd;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$( '#tabs' ).tabs({ active: 2 });$( '#tabs' ).tabs('enable', 2);", true);
            }
        }

        protected string ImageErr()
        {
            string[] allowedExtension = { ".jpeg", ".jpg", ".png", ".gif" };
            string[] videoExtensions = { ".avi", ".mov", ".wmv", ".mp4", ".mpg" };
            HttpFileCollection files = Request.Files;
            int videoIndex = 20;
            string rc = string.Empty;

            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    if (i < videoIndex)
                    {
                        if (files[i].FileName != "")
                            if (!allowedExtension.Contains(Path.GetExtension(files[i].FileName)))
                                rc += "<li>Image file #" + (i + 1) + " is not an allowed file format.</li>";
                    }
                    else
                    {
                        if (files[i].FileName != "")
                            if (!videoExtensions.Contains(Path.GetExtension(files[i].FileName)))
                                rc += "<li>Video file is not an allowed file format.</li>";
                    }
                }
            }
            return rc;
        }

        protected void BtnSaveImages_Click(object sender, EventArgs e)
        {
            string err = ImageErr();
            if (err != string.Empty)
            {
                pnlErr.Visible = true;
                lblErr.Text = "<ul>" + err + "</ul><p>Please upload files with correct file-formats.</p>";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Complete", "$( '#tabs' ).tabs({ active: 2 });", true);
                return;
            }
            HttpFileCollection files = Request.Files;
            CustomerVehicleInfo vi = (CustomerVehicleInfo)Session["VehicleInfo"];
            List<VehicleFeatures> vf = (List<VehicleFeatures>)Session["VehicleFeatures"];
            Financial fin = (Financial)Session["FinancialInfo"];
            VehicleImage imgs = new VehicleImage();
            int VehicleId = CustomerVehicleInfo.InsertNewCustomerVehicleInfo(vi);
            //Customer usr = (Customer)Session["User"];
            string path = Usr.Id + "_v" + VehicleId;
            bool featuresok;
            string[] allowedExtension = { ".jpeg", ".jpg", ".png", ".gif" };
            string[] videoExtensions = { ".avi", ".mov", ".wmv", ".mp4", ".mpg" };
#pragma warning disable CS0219 // Variable is assigned but its value is never used
            bool biWeeklyPosted = false;
#pragma warning restore CS0219 // Variable is assigned but its value is never used

            if (VehicleId > 0)
            {
                vi.Id = VehicleId;
                Session["VehicleInfo"] = vi;
                Session["VehicleId"] = VehicleId;
                featuresok = InsertFeatures(vf, VehicleId);
                if (!featuresok)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Error adding vehicle features.');", true);
                    return;
                }
                fin.VehicleId = VehicleId;
                int fid = Financial.InsertNewFinancialDetails(fin);
                if ( fid > 0)
                {
                    if (pnlBiWeekly.Visible)
                    {
                        fin.Id = 0;
                        fin.PaymentCycle = "Bi-weekly";
                        fin.PaymentWithTax = Convert.ToDouble(txtBiWeeklyWithTax.Text);
                        int bwfid = Financial.InsertNewFinancialDetails(fin);
                        if (bwfid > 0)
                        {
                            biWeeklyPosted = true;
                        }
                    }
                    imgs.VehicleId = VehicleId;
                    imgs.ImgPath = path;
                    if (FileUpload1.HasFile)
                        imgs.Img1 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload1.PostedFile.FileName));
                    if (FileUpload2.HasFile)
                        imgs.Img2 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload2.PostedFile.FileName)); ;
                    if (FileUpload3.HasFile)
                        imgs.Img3 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload3.PostedFile.FileName)); ;
                    if (FileUpload4.HasFile)
                        imgs.Img4 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload4.PostedFile.FileName)); ;
                    if (FileUpload5.HasFile)
                        imgs.Img5 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload5.PostedFile.FileName)); ;
                    if (FileUpload6.HasFile)
                        imgs.Img6 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload6.PostedFile.FileName)); ;
                    if (FileUpload7.HasFile)
                        imgs.Img7 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload7.PostedFile.FileName)); ;
                    if (FileUpload8.HasFile)
                        imgs.Img8 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload8.PostedFile.FileName)); ;
                    if (FileUpload10.HasFile)
                        imgs.Img9 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload10.PostedFile.FileName)); ;
                    if (FileUpload11.HasFile)
                        imgs.Img10 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload11.PostedFile.FileName)); ;
                    if (FileUpload12.HasFile)
                        imgs.Img11 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload12.PostedFile.FileName)); ;
                    if (FileUpload13.HasFile)
                        imgs.Img12 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload13.PostedFile.FileName)); ;
                    if (FileUpload14.HasFile)
                        imgs.Img13 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload14.PostedFile.FileName)); ;
                    if (FileUpload15.HasFile)
                        imgs.Img14 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload15.PostedFile.FileName)); ;
                    if (FileUpload16.HasFile)
                        imgs.Img15 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload16.PostedFile.FileName)); ;
                    if (FileUpload17.HasFile)
                        imgs.Img16 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload17.PostedFile.FileName)); ;
                    if (FileUpload18.HasFile)
                        imgs.Img17 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload18.PostedFile.FileName)); ;
                    if (FileUpload19.HasFile)
                        imgs.Img18 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload19.PostedFile.FileName)); ;
                    if (FileUpload20.HasFile)
                        imgs.Img19 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload20.PostedFile.FileName)); ;
                    if (FileUpload21.HasFile)
                        imgs.Img20 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload21.PostedFile.FileName)); ;
                    
                    if (ddlVideoSource.SelectedIndex == 1)
                    {
                        if (FileUpload9.HasFile)
                        {
                            imgs.Video = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload9.PostedFile.FileName));
                            imgs.VideoFormat = FileUpload9.PostedFile.ContentType;
                        }
                    }
                    Session["Images"] = imgs;

                    bool filesuploaded = false;
                    try
                    {
                        if (files.Count > 0)
                        {
                            Directory.SetCurrentDirectory(Server.MapPath("~/imgs"));
                            if (!Directory.Exists(path))
                                Directory.CreateDirectory(path);
                            for (var i = 0; i < files.Count; i++)
                            {
                                if (files[i].FileName == "")
                                    continue;
                                if (allowedExtension.Contains(Path.GetExtension(files[i].FileName)))
                                {
                                    HttpPostedFile pf = files[i];
                                    string filetoput = Server.MapPath("~/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(files[i].FileName)));
                                    SaveFile(pf, filetoput);
                                }
                            }
                        }
                        filesuploaded = VehicleImage.InsertNewVehicleImage(imgs);
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.writeExceptionToLogFile(ex);
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Pictures could not be uploaded.');", true);
                        filesuploaded = false;
                    }
                    if (filesuploaded)
                    {
                        VehiclesBilling vb = Session["CurrentBilling"] as VehiclesBilling;
                        pnlDetails.Visible = false;
                        if (Session["Role"].ToString() == "admin")
                        {
                            DoCheckout();
                        }
                        else
                        {
                            if (Usr.CustomerType == "Business")
                            {
                                if ((bool)Session["adsRemaining"] == false)
                                    pnlCheckout.Visible = true;
                                else
                                {
                                    pnlCheckout.Visible = false;
                                    vb.AdsRemaining -= 1;
                                    if (VehiclesBilling.UpdateBilling(vb))
                                    {
                                        if (CustomerVehicleInfo.UpdateBillingId(vi.Id, vb.Id))
                                        {
                                            NotifyAdmin(Usr);
                                            NotifyCustomer(Usr, vb, VehicleId);
                                            ltlRemaining.Text = string.Concat("<p class='text-info bold'>You have ", vb.AdsRemaining, " out of ", vb.AdsBought, " ads remaining.</p>");
                                            Response.Redirect("~/account/myaccount.aspx");
                                        }
                                        else
                                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('An error occurred');", true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SaveFile(HttpPostedFile file, string path)
        {
            Int32 fileLength = file.ContentLength;
            string fileName = file.FileName;
            byte[] buffer = new byte[fileLength];
            file.InputStream.Read(buffer, 0, fileLength);

            using (FileStream newFile = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                newFile.Write(buffer, 0, buffer.Length);
            }
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            DoCheckout();
        }

        private void DoCheckout()
        {
            CustomerVehicleInfo vi = (CustomerVehicleInfo)Session["VehicleInfo"];
            List<VehicleFeatures> vf = (List<VehicleFeatures>)Session["VehicleFeatures"];
            Financial fin = (Financial)Session["FinancialInfo"];
            //Customer usr = (Customer)Session["User"];
            VehiclesBilling vb = new VehiclesBilling
            {
                CustomerId = Usr.Id
            };
            if (Session["Role"].ToString() == "admin")
            {
                vb.Payment = 0.99;
                vb.AdsBought = 1;
            }
            else
            {
                if (Usr.CustomerType == "Business")
                {
                    vb.AdsBought = Convert.ToInt16(rblPricing.SelectedValue);
                    switch (rblPricing.SelectedValue)
                    {
                        case "1":
                            vb.Payment = 19.99;
                            break;
                        case "8":
                            vb.Payment = 89.99;
                            vb.AdsRemaining = 7;
                            break;
                        case "20":
                            vb.Payment = 199.99;
                            vb.AdsRemaining = 19;
                            break;
                    }
                }
                else
                {
                    vb.Payment = 0.99;
                    vb.AdsBought = 1;
                }
            }
            vb.PromoCode = string.Empty;
            int billingId = VehiclesBilling.InsertNewBilling(vb);
            vb.Id = billingId;
            if (billingId > 0)
            {
                Session["VehicleBilling"] = vb;
                if (Session["Role"].ToString() == "admin")
                {
                    UpdateBillingAdmin(vi.Id);
                    Response.Redirect("~/admin/vehicles.aspx");
                }
                else
                {
                    Response.Redirect("CheckOut.aspx?item=car&size=" + vb.AdsBought + "&adtype=" + Usr.CustomerType + "&promo=" + BoolToInt(IsPromo) + "&id=" + billingId);
                }
            }
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Failed inserting billing informtation.');", true);
        }

        private int BoolToInt(bool item)
        {
            if (item == true)
                return 1;
            else
                return 0;
        }

        private void UpdateBillingAdmin(int VehicleId)
        {
            VehiclesBilling vb = Session["VehicleBilling"] as VehiclesBilling;
            vb.PayPalId = "Ad by admin";
            vb.PayPalState = "SUCCESS";
            vb.CreateTime = DateTime.Now;
            if (VehiclesBilling.PaidInFull(vb))
            {
                if (CustomerVehicleInfo.UpdateBillingId(VehicleId, vb.Id))
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", " alert('You have completed posting a vehicle/item ad for a customer.');", true);
            }
        }

        private void NotifyAdmin(Customer c)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("<p>Hi Sam,</p>");
            msg.Append("<p>A new vehicle has been posted and is pending approval.</p>");
            msg.Append("Customer name: " + c.FirstName + " " + c.LastName);
            if (Mailer.SendRequest(msg.ToString(), "New vehilcel listing") == false)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", " alert('Your vehicle was posted successfully but the administrator could not be notified at this time.\nThe approval may take upto 48 hours.');", true);
        }

        protected void NotifyCustomer(Customer c, VehiclesBilling vb, int itemId)
        {
            StringBuilder msg = new StringBuilder();

            int remaininAds = vb.AdsBought - vb.AdsRemaining;

            msg.Append(string.Concat("<p>Hi ", c.FirstName, ",</p>"));
            msg.Append("<p>Thanks for placing an ad with emonthlies.com. Just one more step to verify your ad. ");
            msg.Append(string.Concat("<a href='https://www.emonthlies.com/confirmad.aspx?item=car", "&id=", itemId, "'>"));
            msg.Append("Confirm your ad</a>. We will approve your ad in 12 - 24 hours.</p>");
            msg.Append(string.Concat("<p>You have used ", remaininAds, " ads out of ", vb.AdsBought, " purchased.</p>"));
            msg.Append("<p>This posting is valid for 90 days and will automatically discontinue. ");
            msg.Append("<p>Thanks for your business,<br />Your emonthlies sales team</p>");
            if (Mailer.SendMail2Client(c.Email, msg.ToString(), "Confirm your ad") == false)
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "info", " alert('We could not send you an email to verify your ad at this time.');", true);
        }

        private List<VehicleFeatures> GetFeatures()
        {
            List<VehicleFeatures> Features = new List<VehicleFeatures>();
            foreach (Control c in pnlFeatures.Controls)
            {
                if (c is DropDownList)
                {
                    DropDownList ddl = (DropDownList)c;
                    VehicleFeatures ddlFeature = new VehicleFeatures
                    {
                        FeatureId = Convert.ToInt16(ddl.SelectedValue)
                    };
                    Features.Add(ddlFeature);
                }
                if (c is CheckBoxList)
                {
                    CheckBoxList cbx = (CheckBoxList)c;
                    foreach (ListItem item in cbx.Items)
                    {
                        if (item.Selected)
                        {
                            VehicleFeatures cbxFeature = new VehicleFeatures
                            {
                                FeatureId = Convert.ToInt16(item.Value)
                            };
                            Features.Add(cbxFeature);
                        }
                    }
                }
            }
            return Features;
        }

        protected bool InsertFeatures(List<VehicleFeatures> Features, int VehicleId)
        {
            if (Features.Count > 0)
                return VehicleFeatures.InsertNewVehicleFeatures(Features, VehicleId);
            else
                return false;
        }

        protected void BtnCancel1_Click(object sender, EventArgs e)
        {
            ClearSession();
            Response.Redirect("~/Account/myaccount.aspx");
        }

        protected void DdlVideoSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlVideoSource.SelectedIndex)
            {
                case 1:
                    pnlUpload.Visible = true;
                    pnlUpload.Enabled = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$( '#tabs' ).tabs({ active: 2 });", true);
                    break;
                case 2:
                    pnlUpload.Visible = false;
                    pnlUpload.Enabled = false;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$( '#tabs' ).tabs({ active: 2 });", true);
                    break;
                case 0:
                    pnlUpload.Visible = false;
                    pnlUpload.Enabled = false;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$( '#tabs' ).tabs({ active: 2 });", true);
                    break;
            }
        }

        protected void DdlMakes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlMakes.SelectedItem.Text.Equals("Other"))
            {
                RfvMakeOther.Enabled = true;
                TxtMakeOther.Enabled = true;
                TxtMakeOther.Visible = true;
                DdlModel.Enabled = false;
                RfvModel.Enabled = false;
                RfvModelOther.Enabled = true;
                TxtModelOther.Enabled = true;
                TxtModelOther.Visible = true;
                SetTrim();
            }
            else
            {
                RfvMakeOther.Enabled = false;
                TxtMakeOther.Enabled = false;
                TxtMakeOther.Visible = false;
                DdlModel.Enabled = true;
                RfvModel.Enabled = true;
                RfvModelOther.Enabled = false;
                TxtModelOther.Enabled = false;
                TxtModelOther.Visible = false;
                SetTrim();
            }
        }

        protected void SetTrim()
        {
            DdlTrim.Enabled = true;
            RfvTrim.Enabled = true;
            RfvTrim.Visible = true;
            RfvTxtTrim.Enabled = false;
            TxtModelTrim.Enabled = false;
            TxtModelTrim.Visible = false;
        }

        protected void DdlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlModel.SelectedItem.Text.Equals("Other"))
            {
                RfvModelOther.Enabled = true;
                TxtModelOther.Enabled = true;
                TxtModelOther.Visible = true;
                //DdlTrim.Enabled = false;
                //RfvTrim.Enabled = false;
                SetTrim();
            }
            else
            {
                RfvModelOther.Enabled = false;
                TxtModelOther.Enabled = false;
                TxtModelOther.Visible = false;
                //DdlTrim.Enabled = true;
                //RfvTrim.Enabled = true;
                SetTrim();
            }
        }

        protected void BtnCancelCheckout_Click(object sender, EventArgs e)
        {
            CustomerVehicleInfo vi = (CustomerVehicleInfo)Session["VehicleInfo"];
            List<VehicleFeatures> vf = (List<VehicleFeatures>)Session["VehicleFeatures"];
            Financial fin = (Financial)Session["FinancialInfo"];

            //Delete all entries
            bool vehicleDelete = CustomerVehicleInfo.Delete(vi.Id);
            bool featuresDelete = VehicleFeatures.DeleteVehicleFeatures(vi.Id);
            bool financialDelete = Financial.DeleteRecord(fin.Id, vi.Id);
            ClearSession();
            Response.Redirect("~/Account/myaccount.aspx");
        }

        private void ClearSession()
        {
            Session["VehicleInfo"] = null;
            Session["VehicleFeatures"] = null;
            Session["FinancialInfo"] = null;
        }

        protected void DdlTrim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlTrim.SelectedItem.Text.Equals("Other"))
            {
                RfvTxtTrim.Enabled = true;
                TxtModelTrim.Enabled = true;
                TxtModelTrim.Visible = true;
            }
            else
            {
                RfvTxtTrim.Enabled = false;
                TxtModelTrim.Enabled = false;
                TxtModelTrim.Visible = false;
            }
        }

        protected void RblLeaseOrFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentSummary = "On approved credit only.Prices and payments are estimates Only.Dealer may charge additional fees. Licence plates are extra.";
            switch (rblLeaseOrFinance.SelectedIndex)
            {
                case 0:
                    pnlFinancialInfo.Enabled = true;
                    rfvPayCycle.Enabled = true;
                    rfvMonthly.Enabled = true;
                    txtLeaseExpiry.Enabled = true;
                    txtKmAllowance.Enabled = true;
                    txtExcessKmCharge.Enabled = true;
                    txtBalloon.Enabled = false;
                    txtBalloon.Text = string.Empty;
                    txtBuyBack.Enabled = true;
                    txtSecurityDeposit.Enabled = true;
                    rfvLeaseExp.Enabled = true;
                    ddlPurchaseOpEndOfLease.Enabled = true;
                    lfcNote.Text = "On Approved Credit";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$( '#tabs' ).tabs({ active: 1 });$( '#tabs' ).tabs('enable', 1);$( '#tabs' ).tabs({ disabled: [2] });", true);
                    break;
                case 1:
                    pnlFinancialInfo.Enabled = true;
                    rfvPayCycle.Enabled = true;
                    rfvMonthly.Enabled = true;
                    txtLeaseExpiry.Enabled = false;
                    txtLeaseExpiry.Text = string.Empty;
                    txtKmAllowance.Enabled = false;
                    txtKmAllowance.Text = string.Empty;
                    txtExcessKmCharge.Enabled = false;
                    txtExcessKmCharge.Text = string.Empty;
                    txtSecurityDeposit.Enabled = false;
                    txtBalloon.Enabled = true;
                    txtBuyBack.Enabled = false;
                    txtBuyBack.Text = string.Empty;
                    rfvLeaseExp.Enabled = false;
                    ddlPurchaseOpEndOfLease.Enabled = false;
                    lfcNote.Text = "On Approved Credit";
                    txtSummary.Text = currentSummary;
                    ddlPurchaseOpEndOfLease.ClearSelection();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$( '#tabs' ).tabs({ active: 1 });$( '#tabs' ).tabs('enable', 1);$( '#tabs' ).tabs({ disabled: [2] });", true);
                    break;
                case 2:
                    pnlFinancialInfo.Enabled = false;
                    rfvPayCycle.Enabled = false;
                    rfvMonthly.Enabled = false;
                    ddlPurchaseOpEndOfLease.ClearSelection();
                    txtLeaseExpiry.Enabled = false;
                    txtLeaseExpiry.Text = string.Empty;
                    txtKmAllowance.Text = string.Empty;
                    txtBalloon.Text = string.Empty;
                    txtBuyBack.Text = string.Empty;
                    rfvLeaseExp.Enabled = false;
                    txtExcessKmCharge.Text = string.Empty;
                    lfcNote.Text = "Include Local Taxes";
                    txtSummary.Text = "Prices are estimates only. Dealer may charge additional fees. License plates and registration is extra.";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "$( '#tabs' ).tabs({ active: 1 });$( '#tabs' ).tabs('enable', 1);$( '#tabs' ).tabs({ disabled: [2] });", true);
                    break;
                default:
                    lfcNote.Text = string.Empty;
                    break;
            }
        }

        protected void OdsModels_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (DdlMakes.SelectedItem.Text.Equals("Other"))
                e.Cancel = true;

        }

        protected void OdsTrims_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (DdlModel.Items.Count > 0)
            {
                if (DdlModel.SelectedItem.Text.Equals("Other"))
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        }

        protected void DdlPayCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPayCycle.SelectedItem.Text == "Monthly")
            {
                pnlBiWeekly.Enabled = true;
                pnlBiWeekly.Visible = true;
            }
            else
            {
                pnlBiWeekly.Enabled = false;
                pnlBiWeekly.Visible = false;
            }
        }
    }
}
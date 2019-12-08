using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Reflection;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class ModifyVehicle : Page
    {
        private string[] args = HttpContext.Current.Request.QueryString["id"].Split(',');
        private int VehicleId
        {
            get
            {
                return Convert.ToInt32(args[0]);
            }
        }
        private int FinId
        {
            get
            {
                return Convert.ToInt32(args[1]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadVehicleData(VehicleId, FinId);
            }
        }

        protected void BindModelDdl(string make, string model, string other)
        {
            List<ModelLookup> models = ModelLookup.GetAllModelsLookup(make);
            DdlModel.DataSource = models;
            DdlModel.DataBind();
            if (model != "")
            {
                if (models.Select(m => m.Model).ToString() == model)
                {
                    DdlModel.SelectedValue = model;
                }
                if (model == "Other")
                {
                    RfvModelOther.Enabled = true;
                    RfvModelOther.Visible = true;
                    TxtModelOther.Enabled = true;
                    TxtModelOther.Visible = true;
                    TxtModelOther.Text = other;
                }
            }
        }

        protected void BindTrim(string make, string model, string trim)
        {
            List<ModelTrimLookup> trims = ModelTrimLookup.GetAllModelTrimLookup(model, make);
            DdlTrim.DataSource = trims;
            DdlTrim.DataBind();
            if (trims == null)
            {
                DdlTrim.Enabled = false;
                RfvTxtTrim.Enabled = true;
                TxtModelTrim.Enabled = true;
                TxtModelTrim.Visible = true;
                TxtModelTrim.Text = string.Empty;
            }
            else
            {
                if (trim != "")
                {
                    DdlTrim.Enabled = true;
                    DdlTrim.SelectedValue = trim;
                    RfvTxtTrim.Enabled = false;
                    TxtModelTrim.Enabled = false;
                    TxtModelTrim.Visible = false;
                }
                else
                {
                    RfvTxtTrim.Enabled = false;
                    TxtModelTrim.Enabled = false;
                    TxtModelTrim.Visible = false;
                }
            }
        }

        protected void BindFeatures()
        {
            List<Vehiclefeaturelookup> features = Vehiclefeaturelookup.GetAllVehiclefeaturelookup();

            var ac = from s in features
                     where s.FeatureType == "Heating and air conditioning" && s.ListType == "ddl"
                     select s;
            ddlAirConditioning.DataSource = ac;
            ddlAirConditioning.DataBind();
            ddlAirConditioning.ClearSelection();

            var pf = from s in features
                     where s.FeatureType == "Power features" && s.ListType == "cbl"
                     select s;
            cblPowerFeatures.DataSource = pf;
            cblPowerFeatures.DataBind();
            cblPowerFeatures.ClearSelection();

            var seatingDdl = from s in features
                             where s.FeatureType == "Seating" && s.ListType == "ddl"
                             select s;
            ddlSeating.DataSource = seatingDdl;
            ddlSeating.DataBind();
            ddlSeating.ClearSelection();

            var seatingCbl = from s in features
                             where s.FeatureType == "Seating" && s.ListType == "cbl"
                             select s;
            cblSeating.DataSource = seatingCbl;
            cblSeating.DataBind();
            cblSeating.ClearSelection();

            var audioDdl = from s in features
                           where s.FeatureType == "Audio and video features" && s.ListType == "ddl"
                           select s;
            ddlAudioVideoFeatures.DataSource = audioDdl;
            ddlAudioVideoFeatures.DataBind();
            ddlAudioVideoFeatures.ClearSelection();

            var audioCbl = from s in features
                           where s.FeatureType == "Audio and video features" && s.ListType == "cbl"
                           select s;
            cblAudioVideoFeatures.DataSource = audioCbl;
            cblAudioVideoFeatures.DataBind();
            cblAudioVideoFeatures.ClearSelection();

            var safetyDdl = from s in features
                            where s.FeatureType == "Safety and security features" && s.ListType == "ddl"
                            select s;
            ddlSafetySecurityFeatures.DataSource = safetyDdl;
            ddlSafetySecurityFeatures.DataBind();
            ddlSafetySecurityFeatures.ClearSelection();

            var safetyCbl = from s in features
                            where s.FeatureType == "Safety and security features" && s.ListType == "cbl"
                            select s;
            cblSafetySecurityFeatures.DataSource = safetyCbl;
            cblSafetySecurityFeatures.DataBind();
            cblSafetySecurityFeatures.ClearSelection();

            var convCbl = from s in features
                          where s.FeatureType == "Convenience features" && s.ListType == "cbl"
                          select s;
            cblConvenienceFeatures.DataSource = convCbl;
            cblConvenienceFeatures.DataBind();
            cblConvenienceFeatures.ClearSelection();

            var warrantyDdl = from s in features
                              where s.FeatureType == "Warranties and insurance" && s.ListType == "ddl"
                              select s;
            ddlWarrantiesInsurance.DataSource = warrantyDdl;
            ddlWarrantiesInsurance.DataBind();
            ddlWarrantiesInsurance.ClearSelection();

            var warrantyCbl = from s in features
                              where s.FeatureType == "Warranties and insurance" && s.ListType == "cbl"
                              select s;
            cblWarrantiesInsurance.DataSource = warrantyCbl;
            cblWarrantiesInsurance.DataBind();
            cblWarrantiesInsurance.ClearSelection();

            var SUVCbl = from s in features
                         where s.FeatureType == "Pickups - SUV - Vans" && s.ListType == "cbl"
                         select s;
            cblPickupsSUVVans.DataSource = SUVCbl;
            cblPickupsSUVVans.DataBind();
            cblPickupsSUVVans.ClearSelection();

            var aftermarketCbl = from s in features
                                 where s.FeatureType == "Aftermarket accessories" && s.ListType == "cbl"
                                 select s;
            cblAftermarketAccessories.DataSource = aftermarketCbl;
            cblAftermarketAccessories.DataBind();
            cblAftermarketAccessories.ClearSelection();
        }

        protected void LoadVehicleData(int VehicleId, int FinId)
        {
            int[] cars = { 22, 23, 26, 27, 30, 34, 35, 38 };
            int[] suvs = { 25, 32, 36 };
            int[] trucks = { 24, 28, 37 };
            string selectedVtype = string.Empty;

            if (Request.QueryString["update"] != null)
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Success", "alert('Picture/video files updated.');", true);

            CustomerVehicleInfo vehicle = CustomerVehicleInfo.GetCustomerVehicleInfoDetails(VehicleId, FinId, false);
            if (vehicle != null)
            {
                BindFeatures();
                if (cars.Contains(vehicle.VehicleCategoryId))
                {
                    selectedVtype = "22";
                }
                else if (suvs.Contains(vehicle.VehicleCategoryId))
                {
                    selectedVtype = "25";
                }
                else if (trucks.Contains(vehicle.VehicleCategoryId))
                {
                    selectedVtype = "24";
                }
                else
                {
                    selectedVtype = vehicle.VehicleCategoryId.ToString();
                }
                rblCondition.SelectedValue = vehicle.VehicleCondition;
                rblVehicleType.SelectedValue = selectedVtype;
                ddlYear.SelectedValue = vehicle.ModelYear.ToString();
                DdlMakes.SelectedValue = vehicle.Manufacturer;
                if (vehicle.Manufacturer.Equals("Other"))
                {
                    TxtMakeOther.Enabled = true;
                    TxtMakeOther.Visible = true;
                    TxtMakeOther.Text = vehicle.OtherMake;
                    RfvMakeOther.Enabled = true;
                    RfvMakeOther.Visible = true;
                }
                else
                {
                    TxtMakeOther.Enabled = false;
                    TxtMakeOther.Visible = false;
                    RfvMakeOther.Enabled = false;
                    RfvMakeOther.Visible = false;
                }
                BindModelDdl(vehicle.Manufacturer, vehicle.Model, vehicle.OtherModel);
                DdlModel.SelectedValue = vehicle.Model;
                BindTrim(vehicle.Manufacturer, vehicle.Model, vehicle.ModelTrim.ToString());
                if (vehicle.Model == "Other")
                {
                    TxtModelOther.Enabled = true;
                    TxtModelOther.Visible = true;
                    TxtModelOther.Text = vehicle.OtherModel;
                    TxtModelTrim.Visible = true;
                    TxtModelTrim.Enabled = true;
                    //TxtModelTrim.Visible = true;
                    //TxtModelTrim.Text = vehicle.OtherTrim;
                }
                else
                {
                    TxtModelOther.Enabled = false;
                    TxtModelOther.Visible = false;
                    TxtModelTrim.Visible = false;
                    TxtModelTrim.Enabled = false;
                    DdlTrim.SelectedValue = vehicle.ModelTrim.ToString();
                }
                if (DdlTrim.SelectedValue == "60931")
                {
                    RfvTrim.Enabled = true;
                    RfvTrim.Visible = true;
                    TxtModelTrim.Enabled = true;
                    TxtModelTrim.Visible = true;
                    TxtModelTrim.Text = vehicle.OtherTrim;
                    RfvTxtTrim.Enabled = true;
                    RfvTxtTrim.Visible = true;
                }
                else
                {
                    RfvTrim.Enabled = false;
                    RfvTrim.Visible = false;
                    RfvTxtTrim.Enabled = false;
                    RfvTxtTrim.Visible = false;
                    TxtModelTrim.Text = string.Empty;
                    TxtModelTrim.Enabled = false;
                    TxtModelTrim.Visible = false;
                }
                RfvModelOther.Enabled = false;
                RfvModelOther.Visible = false;
                txtDisplacement.Text = vehicle.Displacement;
                ddlBodyColour.SelectedValue = vehicle.ExteriorColor;
                ddlInteriorColour.Enabled = true;
                rfvInterior.Enabled = false;
                ddlInteriorColour.SelectedValue = vehicle.InteriorColor;
                ddlFuel.SelectedValue = vehicle.FuelType;
                txtMileage.Text = vehicle.CurrentMileage.ToString();
                ddlTransmission.SelectedValue = vehicle.Transmission;
                ddlWheels.SelectedValue = vehicle.Wheels;
                cbxChrome.Checked = vehicle.ChromeWheels;
                ddlTires.SelectedValue = vehicle.Tires;
                cbxWinterTires.Checked = vehicle.ExtraWinterTires;

                List<VehicleFeatures> vf = VehicleFeatures.SelectAllByVehicleId(vehicle.Id);
                foreach (VehicleFeatures feature in vf)
                {
                    foreach (Control c in pnlFeatures.Controls)
                    {
                        if (c is DropDownList)
                        {
                            DropDownList ddl = (DropDownList)c;

                            foreach (ListItem item in ddl.Items)
                            {
                                if (item.Value == feature.FeatureId.ToString())
                                {
                                    item.Selected = true;
                                    continue;
                                }
                            }
                        }
                        if (c is CheckBoxList)
                        {
                            CheckBoxList cbx = (CheckBoxList)c;
                            foreach (ListItem item in cbx.Items)
                            {
                                if (item.Value == feature.FeatureId.ToString())
                                    item.Selected = true;
                            }
                        }
                    }
                }
                txtComments.Text = vehicle.Comments;
                Session["AdExpiry"] = vehicle.Expires;

                Financial ltd = Financial.GetFinancialDetailsByVehicleId(vehicle.Id, FinId);
                Session["LeaseId"] = ltd.Id;
                rblLeaseOrFinance.SelectedValue = ltd.LeaseOrFinance;
                switch (ltd.LeaseOrFinance)
                {
                    case "l":
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
                        ddlPurchaseOpEndOfLease.Enabled = true;
                        break;
                    case "f":
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
                        ddlPurchaseOpEndOfLease.Enabled = false;
                        ddlPurchaseOpEndOfLease.ClearSelection();
                        break;
                    case "c":
                        pnlFinancialInfo.Enabled = false;
                        rfvPayCycle.Enabled = false;
                        rfvMonthly.Enabled = false;
                        ddlPurchaseOpEndOfLease.ClearSelection();
                        txtLeaseExpiry.Text = string.Empty;
                        txtKmAllowance.Text = string.Empty;
                        txtBalloon.Text = string.Empty;
                        txtBuyBack.Text = string.Empty;
                        txtExcessKmCharge.Text = string.Empty;
                        break;
                }

                ddlPayCycle.SelectedValue = ltd.PaymentCycle;
                txtMonthlyWithTax.Text = ltd.PaymentWithTax.ToString();
                txtOriginalDown.Text = ltd.OriginalDown.ToString();
                txtSecurityDeposit.Text = ltd.SecurityDeposit.ToString();
                ddlPurchaseOpEndOfLease.SelectedValue = ltd.PoEndOfLease;
                txtKmAllowance.Text = ltd.KmAllowance.ToString();
                txtExcessKmCharge.Text = ltd.ExcessKmCharge.ToString();
                txtOriginalLeaseTerm.Text = ltd.LeaseTerm.ToString();
                txtLeaseExpiry.Text = (ltd.LeaseExpiry == null) ? "" : ltd.LeaseExpiry.ToString();
                txtBuyBack.Text = ltd.BuyBack.ToString();
                txtBalloon.Text = ltd.Balloon.ToString();
                txtPurchasePrice.Text = ltd.PurchasePrice.ToString();
                txtSummary.Text = Server.HtmlDecode(ltd.Summary);

                VehicleImage imgs = VehicleImage.SelectByVehicleId(vehicle.Id);
                Session["imgs"] = imgs;
                PlaceImages(imgs);
            }
        }

        protected void PlaceImages(VehicleImage imgs)
        {
            if (imgs != null)
            {
                plhImages.Controls.Clear();
                PropertyInfo[] props = imgs.GetType().GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.Contains("Img") && !p.Name.Contains("Path"))
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
                if (!string.IsNullOrEmpty(imgs.Video))
                {
                    pnlVideo.Visible = true;
                    //vSrc.Src = imgs.Video;
                    HtmlImage pix = new HtmlImage();
                    pix.Src = "/images/video-play.png";
                    pix.Attributes.Add("class", "thumb link");
                    pix.Attributes.Add("onclick", "$('#myModal').modal('show');");

                    plhImages.Controls.Add(pix);

                    vSrc.Attributes.Add("src", imgs.Video);
                    vSrc.Attributes.Add("type", imgs.VideoFormat);
                }
                else
                {
                    pnlVideo.Visible = false;
                }
            }
        }

        protected void BtnSaveVehicle_Click(object sender, EventArgs e)
        {
            string[] cYears = { DateTime.Now.Year.ToString(), (DateTime.Now.Year + 1).ToString() };
            if (Page.IsValid)
            {
                Customer usr = (Customer)Session["User"];
                CustomerVehicleInfo vi = new CustomerVehicleInfo();
                DateTime AdExpiry = new DateTime(DateTime.Now.Year, 12, 31); //(DateTime)Session["AdExpiry"];
                vi.Id = VehicleId;
                vi.Seller = usr.Id;
                vi.VehicleCondition = rblCondition.SelectedValue;
                vi.ModelYear = Convert.ToInt16(ddlYear.SelectedValue);
                vi.VehicleCategoryId = Convert.ToInt16(rblVehicleType.SelectedValue);
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
                    vi.ModelTrim = 60931;
                vi.ExteriorColor = ddlBodyColour.SelectedValue;
                vi.InteriorColor = ddlInteriorColour.SelectedValue;
                vi.FuelType = ddlFuel.SelectedValue;
                vi.Transmission = ddlTransmission.SelectedValue;
                vi.CurrentMileage = Convert.ToInt32(txtMileage.Text);
                vi.Wheels = ddlWheels.SelectedValue;
                vi.ChromeWheels = cbxChrome.Checked;
                vi.Tires = ddlTires.SelectedValue;
                vi.ExtraWinterTires = cbxWinterTires.Checked;
                vi.Expires = AdExpiry;
                //if (cYears.Contains(vi.ModelYear.ToString()) && AdExpiry > DateTime.Now.AddMonths(3))
                //{
                //    vi.Expires = AdExpiry;
                //}
                //else
                //{
                //    vi.Expires = DateTime.Now.AddMonths(3);
                //}
                vi.Comments = Server.HtmlEncode(txtComments.Text);
                vi.Displacement = txtDisplacement.Text;
                vi.Updated = DateTime.Now;
                Session["VehicleInfo"] = vi;
                Session["VehicleId"] = vi.Id;
                Session["VehicleFeatures"] = GetFeatures();
                bool saveVI = CustomerVehicleInfo.UpdateCustomerVehicleInfo(vi);
                if (saveVI)
                {
                    if (VehicleFeatures.DeleteVehicleFeatures(vi.Id))
                    {
                        if (VehicleFeatures.InsertNewVehicleFeatures(GetFeatures(), vi.Id))
                        {
                            LoadVehicleData(vi.Id, FinId);
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Next", "$('#vtabs li:eq(1) a').tab('show'); alert('Vehicle information updated.');", true);
                        }
                        else
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Update failed.'); $('#vtabs li:eq(0) a').tab('show');", true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Update failed.'); $('#vtabs li:eq(0) a').tab('show');", true);
                }
            }
        }

        protected void BtnSubmitLease_Click(object sender, EventArgs e)
        {
            Financial ltd = new Financial();
            if (Page.IsValid)
            {
                ltd.Id = FinId;
                ltd.LeaseOrFinance = rblLeaseOrFinance.SelectedValue;
                ltd.VehicleId = VehicleId;
                //ltd.LienHolder = txtLienholder.Text;
                ltd.PaymentCycle = ddlPayCycle.SelectedValue;
                ltd.PaymentWithTax = Convert.ToDouble(txtMonthlyWithTax.Text);
                ltd.OriginalDown = Convert.ToDouble(txtOriginalDown.Text);
                ltd.SecurityDeposit = Convert.ToDouble(txtSecurityDeposit.Text);
                ltd.PoEndOfLease = ddlPurchaseOpEndOfLease.SelectedValue;
                ltd.KmAllowance = Convert.ToInt32(txtKmAllowance.Text);
                ltd.ExcessKmCharge = Convert.ToDouble(txtExcessKmCharge.Text);
                ltd.LeaseTerm = Convert.ToInt16(txtOriginalLeaseTerm.Text);
                ltd.LeaseExpiry = (string.IsNullOrEmpty(txtLeaseExpiry.Text)) ? null : Helpers.ExtractNullableDateTimeFromString(txtLeaseExpiry.Text);
                ltd.BuyBack = Convert.ToDouble(txtBuyBack.Text);
                ltd.Balloon = Convert.ToDouble(txtBalloon.Text);
                ltd.PurchasePrice = Convert.ToDouble(txtPurchasePrice.Text);
                ltd.Summary = Server.HtmlEncode(txtSummary.Text);
                ltd.Comments = Server.HtmlEncode(txtComments.Text);
                Session["LeaseInfo"] = ltd;
                if (Financial.UpdateFinancialDetails(ltd))
                {
                    LoadVehicleData(VehicleId, FinId);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Next", "$('#vtabs li:eq(2) a').tab('show'); alert('Financial data updated.');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Update failed.'); $('#vtabs li:eq(1) a').tab('show');", true);
            }
        }

        protected void BtnSaveImages_Click(object sender, EventArgs e)
        {
            string err = ImageErr();
            if (err != string.Empty)
            {
                pnlErr.Visible = true;
                lblErr.Text = "<ul>" + err + "</ul><p>Please upload files with correct file-formats.</p>";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Next", "$('#vtabs li:eq(2) a').tab('show');", true);
                return;
            }

            HttpFileCollection files = Request.Files;
            VehicleImage imgs = (VehicleImage)Session["imgs"];
            if (FileUpload1.HasFile)
            {
                imgs.Img1 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload1.PostedFile.FileName));
            }
            if (FileUpload2.HasFile)
                imgs.Img2 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload2.PostedFile.FileName)); ;
            if (FileUpload3.HasFile)
                imgs.Img3 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload3.PostedFile.FileName)); ;
            if (FileUpload4.HasFile)
                imgs.Img4 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload4.PostedFile.FileName)); ;
            if (FileUpload5.HasFile)
                imgs.Img5 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload5.PostedFile.FileName)); ;
            if (FileUpload6.HasFile)
                imgs.Img6 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload6.PostedFile.FileName)); ;
            if (FileUpload7.HasFile)
                imgs.Img7 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload7.PostedFile.FileName)); ;
            if (FileUpload8.HasFile)
                imgs.Img8 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload8.PostedFile.FileName)); ;

            if (FileUpload10.HasFile)
                imgs.Img9 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload10.PostedFile.FileName)); ;
            if (FileUpload11.HasFile)
                imgs.Img10 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload11.PostedFile.FileName)); ;
            if (FileUpload12.HasFile)
                imgs.Img11 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload12.PostedFile.FileName)); ;
            if (FileUpload13.HasFile)
                imgs.Img12 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload13.PostedFile.FileName)); ;
            if (FileUpload14.HasFile)
                imgs.Img13 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload14.PostedFile.FileName)); ;
            if (FileUpload15.HasFile)
                imgs.Img14 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload15.PostedFile.FileName)); ;
            if (FileUpload16.HasFile)
                imgs.Img15 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload16.PostedFile.FileName)); ;
            if (FileUpload17.HasFile)
                imgs.Img16 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload17.PostedFile.FileName)); ;
            if (FileUpload18.HasFile)
                imgs.Img17 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload18.PostedFile.FileName)); ;
            if (FileUpload19.HasFile)
                imgs.Img18 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload19.PostedFile.FileName)); ;
            if (FileUpload20.HasFile)
                imgs.Img19 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload20.PostedFile.FileName)); ;
            if (FileUpload21.HasFile)
                imgs.Img20 = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload21.PostedFile.FileName)); ;



            switch (ddlVideoSource.SelectedIndex)
            {
                case 1:
                    if (FileUpload9.HasFile)
                    {
                        imgs.Video = @"/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload9.PostedFile.FileName));
                        imgs.VideoFormat = FileUpload9.PostedFile.ContentType;
                    }
                    break;
                    //case 2:
                    //    imgs.YouTubeLink = txtYouTubeLink.Text;
                    //    break;
            }
            Session["Images"] = imgs;

            try
            {
                if (files.Count > 0)
                {
                    Directory.SetCurrentDirectory(Server.MapPath("~/imgs"));
                    if (!Directory.Exists(imgs.ImgPath))
                        Directory.CreateDirectory(imgs.ImgPath);
                    for (int i = 0; i < files.Count; i++)
                    {
                        if (files[i].FileName != "")
                        {
                            HttpPostedFile pf = files[i];
                            string filetoput = Server.MapPath("~/imgs/" + imgs.ImgPath + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(files[i].FileName)));
                            SaveFile(pf, filetoput);
                        }
                        //else
                        //{
                        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Success", "alert('Picture/video files updated.');", true);
                        //}
                    }
                }
                if (VehicleImage.UpdateVehicleImage(imgs))
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "alert('Picture/video files updated.'); self.location='/account/myaccount.aspx';", true);
            }
            catch (Exception ex)
            {
                ErrorHandler.writeExceptionToLogFile(ex);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Pictures could not be uploaded.');", true);
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

        private List<VehicleFeatures> GetFeatures()
        {
            List<VehicleFeatures> Features = new List<VehicleFeatures>();
            foreach (Control c in pnlFeatures.Controls)
            {
                if (c is DropDownList)
                {
                    DropDownList ddl = (DropDownList)c;
                    VehicleFeatures ddlFeature = new VehicleFeatures();
                    ddlFeature.FeatureId = Convert.ToInt16(ddl.SelectedValue);
                    Features.Add(ddlFeature);
                }
                if (c is CheckBoxList)
                {
                    CheckBoxList cbx = (CheckBoxList)c;
                    foreach (ListItem item in cbx.Items)
                    {
                        if (item.Selected)
                        {
                            VehicleFeatures cbxFeature = new VehicleFeatures();
                            cbxFeature.FeatureId = Convert.ToInt16(item.Value);
                            Features.Add(cbxFeature);
                        }
                    }
                }
            }
            return Features;
        }

        protected void ddlVideoSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlVideoSource.SelectedIndex)
            {
                case 1:
                    pnlUpload.Visible = true;
                    pnlUpload.Enabled = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Next", "$('#vtabs li:eq(2) a').tab('show');", true);
                    break;
                case 2:
                    pnlUpload.Visible = false;
                    pnlUpload.Enabled = false;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Next", "$('#vtabs li:eq(2) a').tab('show');", true);
                    break;
                case 0:
                    pnlUpload.Visible = false;
                    pnlUpload.Enabled = false;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Next", "$('#vtabs li:eq(2) a').tab('show');", true);
                    break;
            }
        }

        protected void SetTrim()
        {
            DdlTrim.Enabled = true;
            RfvTrim.Enabled = true;
            RfvTxtTrim.Enabled = false;
            TxtModelTrim.Enabled = false;
            TxtModelTrim.Visible = false;
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
                BindModelDdl(DdlMakes.SelectedValue, DdlModel.SelectedValue, string.Empty);
                SetTrim();
            }
        }

        protected void DdlModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlModel.SelectedItem.Text.Equals("Other"))
            {
                RfvModelOther.Enabled = true;
                TxtModelOther.Enabled = true;
                TxtModelOther.Visible = true;
                DdlTrim.Enabled = false;
                RfvTrim.Enabled = false;
                SetTrim();
            }
            else
            {
                RfvModelOther.Enabled = false;
                TxtModelOther.Enabled = false;
                TxtModelOther.Visible = false;
                SetTrim();
                BindTrim(DdlMakes.SelectedValue, DdlModel.SelectedValue, string.Empty);
            }
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

        protected void BtnCancel1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/account/myaccount.aspx");
        }

        protected void rblLeaseOrFinance_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                    txtBuyBack.Enabled = true;
                    ddlPurchaseOpEndOfLease.Enabled = true;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Next", "$('#vtabs li:eq(1) a').tab('show');", true);
                    break;
                case 1:
                    pnlFinancialInfo.Enabled = true;
                    rfvPayCycle.Enabled = true;
                    rfvMonthly.Enabled = true;
                    txtLeaseExpiry.Enabled = false;
                    txtKmAllowance.Enabled = false;
                    txtExcessKmCharge.Enabled = false;
                    txtBalloon.Enabled = true;
                    txtBuyBack.Enabled = false;
                    ddlPurchaseOpEndOfLease.Enabled = false;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Next", "$('#vtabs li:eq(1) a').tab('show');", true);
                    break;
                case 2:
                    pnlFinancialInfo.Enabled = false;
                    rfvPayCycle.Enabled = false;
                    rfvMonthly.Enabled = false;
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Next", "$('#vtabs li:eq(1) a').tab('show');", true);
                    break;
            }
        }

        protected void DdlTrim_DataBound(object sender, EventArgs e)
        {
            if (DdlTrim.Items.Count <= 0)
            {
                RfvTxtTrim.Enabled = true;
                TxtModelTrim.Enabled = true;
                TxtModelTrim.Visible = true;
                TxtModelTrim.Text = string.Empty;
            }
            else
            {
                RfvTxtTrim.Enabled = false;
                TxtModelTrim.Enabled = false;
                TxtModelTrim.Visible = false;
            }
        }
    }
}
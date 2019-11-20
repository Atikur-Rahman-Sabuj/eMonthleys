using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using eMonthleys.BLL;
using eMonthleys.Utils;
using System.Linq;

namespace eMonthleys
{
    public partial class Vehicles : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnEditVehicles_Click(object sender, EventArgs e)
        {
            // Seite aufrufen mit ID
            // Response.Redirect("~/account/ModifyCustomer.aspx");

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
                if (trim != string.Empty)
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


        protected void GvVehicles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }
            string[] args = e.CommandArgument.ToString().Split(',');
            int VehicleId = Convert.ToInt32(args[0]);
            int FinId = Convert.ToInt32(args[1]);
            //string declined = args[2];

            switch (e.CommandName)
            {
                case "Activate":
                    Response.Redirect("~/admin/reviewvehicle.aspx?id=" + e.CommandArgument);
                    break;
                case "Deactivate":
                    if (CustomerVehicleInfo.SetApprovedStatus(VehicleId, FinId, false))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('The ad #" + VehicleId + " has been deactivated.');", true);
                        GvVehicles.DataBind();
                    }
                    else
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Failed deleteing ad #" + VehicleId + ".');", true);
                    break;
                case "Repost":
                    lblVehicleId.Text = e.CommandArgument.ToString();

                    CustomerVehicleInfo cvi = CustomerVehicleInfo.GetCustomerVehicleInfoDetails(VehicleId, FinId, false);
                    Financial f = Financial.GetFinancialDetailsByVehicleId(VehicleId, FinId);

                    int[] cars = { 22, 23, 26, 27, 30, 34, 35, 38 };
                    int[] suvs = { 25, 32, 36 };
                    int[] trucks = { 24, 28, 37 };
                    string selectedVtype = string.Empty;

                    if (cars.Contains(cvi.VehicleCategoryId))
                    {
                        selectedVtype = "22";
                    }
                    else if (suvs.Contains(cvi.VehicleCategoryId))
                    {
                        selectedVtype = "25";
                    }
                    else if (trucks.Contains(cvi.VehicleCategoryId))
                    {
                        selectedVtype = "24";
                    }

                    BindModelDdl(cvi.Manufacturer, cvi.Model, cvi.OtherModel);
                    rblVehicleType.SelectedValue = selectedVtype;
                    ddlYear.SelectedValue = cvi.ModelYear.ToString();
                    DdlMakes.SelectedValue = cvi.Manufacturer;
                    if (cvi.Manufacturer.Equals("Other"))
                    {
                        TxtMakeOther.Enabled = true;
                        TxtMakeOther.Visible = true;
                        TxtMakeOther.Text = cvi.OtherMake;
                    }
                    DdlModel.SelectedValue = cvi.Model;
                    if (cvi.Model == "Other")
                    {
                        TxtModelOther.Enabled = true;
                        TxtModelOther.Visible = true;
                        TxtModelTrim.Visible = true;
                        TxtModelTrim.Enabled = true;
                        TxtModelTrim.Text = cvi.OtherTrim;
                        DdlTrim.Enabled = false;
                        DdlTrim.Visible = false;
                    }
                    else
                    {
                        TxtModelTrim.Visible = false;
                        TxtModelTrim.Enabled = false;
                        DdlTrim.Enabled = true;
                        DdlTrim.Visible = true;
                        BindTrim(cvi.Manufacturer, cvi.Model, cvi.ModelTrim.ToString());
                        DdlTrim.SelectedValue = cvi.ModelTrim.ToString();
                    }
                    txtPurchasePrice.Text = f.PurchasePrice.ToString();
                    ddlPayCycle.SelectedValue = f.PaymentCycle;
                    txtMonthlyWithTax.Text = f.PaymentWithTax.ToString();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", " $('#myModal').modal('show');", true);
                    break;

                default:
                    break;
            }
        }

        protected string GetVehicleInfo(object dr)
        {
            string brand = DataBinder.Eval(dr, "ModelYear").ToString();
            string mtrim = string.Empty;
            if (DataBinder.Eval(dr, "Manufacturer").ToString() == "Other")
                brand += string.Concat(" ", DataBinder.Eval(dr, "OtherMake").ToString(), " ", DataBinder.Eval(dr, "OtherModel").ToString());
            else
                brand += string.Concat(" ", DataBinder.Eval(dr, "Manufacturer").ToString());
            if (DataBinder.Eval(dr, "Model").ToString() == "Other")
                brand += string.Concat(" ", DataBinder.Eval(dr, "OtherModel").ToString());
            else
                brand += string.Concat(" ", DataBinder.Eval(dr, "Model").ToString());
            if (DataBinder.Eval(dr, "ModelTrimValue").ToString() == "Other")
                mtrim += DataBinder.Eval(dr, "OtherTrim").ToString();
            else
                mtrim += DataBinder.Eval(dr, "ModelTrimValue").ToString();

            return string.Concat(brand, " ", mtrim);
        }

        protected string GetCategory(object dr)
        {
            int categoryId = Convert.ToInt16(DataBinder.Eval(dr, "VehicleCategoryId").ToString());
            Vehiclecategories vc = Vehiclecategories.GetVehicleCategoryDetails(categoryId);
            return vc.Name;
        }

        //protected string GetTrim(object dr)
        //{
        //    string mtrim = string.Empty;
        //    if (DataBinder.Eval(dr, "ModelTrimValue").ToString() == "Other")
        //        mtrim += DataBinder.Eval(dr, "OtherTrim").ToString();
        //    else
        //        mtrim += DataBinder.Eval(dr, "ModelTrimValue").ToString();
        //    return mtrim;
        //}
        protected string GetVendor(object dr)
        {
            Customer vendor = Customer.GetCustomerDetails(Convert.ToInt32(DataBinder.Eval(dr, "Seller")));
            string Seller = string.Empty;
            if (vendor.Company != "")
                Seller = vendor.Company;
            else
                Seller = string.Concat(vendor.FirstName, " ", vendor.LastName);
            return Seller;
        }

        protected string GetPrice(object dr)
        {
            Financial car = Financial.GetFinancialDetailsByVehicleId(Convert.ToInt32(DataBinder.Eval(dr, "Id")), Convert.ToInt32(DataBinder.Eval(dr, "FinId")));
            string price = string.Empty;
            price = car.PurchasePrice.ToString(@"$#,##0.00;($#,##0.00\)");
            return price;
        }

        protected void GvVehicles_DataBound(object sender, EventArgs e)
        {
            if (GvVehicles.Rows.Count > 0)
            {
                GvVehicles.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = GvVehicles.HeaderRow.Cells;
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
                switch (ddlStatus.SelectedIndex)
                {
                    case 0:
                    case 1:
                        GvVehicles.Columns[7].Visible = false;
                        break;
                    case 2:
                    case 3:
                    case 5:
                        GvVehicles.Columns[8].Visible = true;
                        GvVehicles.Columns[7].Visible = true;
                        break;
                    case 4:
                        GvVehicles.Columns[8].Visible = false;
                        GvVehicles.Columns[7].Visible = false;
                        break;
                }
            }
        }

        protected void BtnUpdateCar_Click(object sender, EventArgs e)
        {
            CustomerVehicleInfo cvi = new CustomerVehicleInfo();
            Financial f = new Financial();

            cvi.Id = Convert.ToInt32(lblVehicleId.Text);
            cvi.VehicleCategoryId = Convert.ToInt16(rblVehicleType.SelectedValue);
            cvi.ModelYear = Convert.ToInt16(ddlYear.SelectedValue);
            cvi.Manufacturer = DdlMakes.SelectedValue;
            cvi.Model = DdlModel.SelectedValue;
            cvi.Expires = DateTime.Now.AddMonths(3);
            f.VehicleId = cvi.Id;
            f.PurchasePrice = Helpers.ConvertNullDblToZero(txtPurchasePrice.Text);
            f.PaymentCycle = ddlPayCycle.SelectedValue;
            f.PaymentWithTax = Convert.ToDouble(txtMonthlyWithTax.Text);
            if (DdlTrim.Enabled)
            {
                cvi.ModelTrim = Convert.ToInt32(DdlTrim.SelectedValue);
                cvi.OtherTrim = string.Empty;
                if (DdlTrim.SelectedItem.Text.Equals("Other"))
                {
                    cvi.OtherTrim = TxtModelTrim.Text;
                }
            }
            else
                cvi.ModelTrim = 60931;
            if (CustomerVehicleInfo.RepostSelectedVehicle(cvi))
            {
                if (Financial.UpdatePrice(f))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('The ad #" + cvi.Id + " has been reposted.');", true);
                    GvVehicles.DataBind();
                }
            }
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Failed reposting ad #" + cvi.Id + ".');", true);
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
            }
            else
            {
                DdlTrim.Enabled = true;
                RfvTrim.Enabled = true;
                RfvModelOther.Enabled = false;
                TxtModelOther.Enabled = false;
                TxtModelOther.Visible = false;
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
                BindTrim(DdlMakes.SelectedValue, DdlModel.SelectedValue, string.Empty);
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

        protected void OdsCustomersInfo_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null && e.ReturnValue != null)
            {
                e.AffectedRows = ((List<CustomerVehicleInfo>)e.ReturnValue).Count;
                lblCount.Text = e.AffectedRows + " vehicle(s) found.";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using eMonthleys.BLL;
using System.Linq;

namespace eMonthleys
{
    public partial class MyVehicles : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindGrid();
            //}
        }

        protected void GvMyVehicles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }
            string[] args = e.CommandArgument.ToString().Split(',');
            int VehicleId = Convert.ToInt32(args[0]);
            int FinId = Convert.ToInt32(args[1]);

            switch (e.CommandName)
            {
                case "Edit":
                    Response.Redirect("viewmycarad.aspx?id=" + e.CommandArgument);
                    break;
                case "Remove":
                    VehicleImage imgs = VehicleImage.SelectByVehicleId(VehicleId);
                    if (imgs != null)
                    {
                        if (Directory.Exists(Server.MapPath(imgs.ImgPath)))
                            Directory.Delete(Server.MapPath(imgs.ImgPath));
                    }
                    if (CustomerVehicleInfo.Delete(VehicleId))
                    {
                        GvMyVehicles.DataBind();
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Your vehicle #" + e.CommandArgument + " has been deleted.');", true);
                    }

                    else
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Failed deleteing vehicle #" + e.CommandArgument + ".');", true);
                    break;
                case "Sold":
                    ChangeStatus(FinId, VehicleId, "Sold");
                    break;
                case "SoldButMore":
                    ChangeStatus(FinId, VehicleId, "Sold but more");
                    break;
                default:
                    break;
            }
        }

        protected void ChangeStatus(int Id, int VehicleId, string Status)
        {
            if (Financial.ChangeStatus(Id, VehicleId, Status))
                GvMyVehicles.DataBind();
        }

        protected string GetItemId(object item)
        {
            return string.Concat(DataBinder.Eval(item, "Id"), ",", DataBinder.Eval(item, "FinId"));
        }

        protected string GetCategory(object dr)
        {
            int categoryId = Convert.ToInt16(DataBinder.Eval(dr, "VehicleCategoryId").ToString());
            int[] cars = { 22, 23, 26, 27, 30, 34, 35, 38 };
            int[] suvs = { 25, 32, 36 };
            int[] trucks = { 24, 28, 37 };
            string img = string.Empty;

            if (cars.Contains(categoryId))
            {
                img = "<img src='/images/sedan-icon.png' /> Cars/Sports cars";
            }
            else if (suvs.Contains(categoryId))
            {
                img = "<img src='/images/SUV-icon.png' /> SUV's";
            }
            else if (trucks.Contains(categoryId))
            {
                img = "<img src='/images/truck-icon.png' /> Trucks";
            }
            else if (categoryId == 29)
            {
                img = "<img src='/images/minivan-icon.png' /> Vans";
            }
            else if (categoryId == 31)
            {
                img = "<img src='/images/cabriolet-icon.png' /> Convertibles";
            }
            else if (categoryId == 39)
            {
                img = "<img src='/images/collector-icon.png' /> Collector cars";
            }

            return img;
        }

        protected string GetVehicleInfo(object dr)
        {
            string brand = DataBinder.Eval(dr, "ModelYear").ToString();
            if (DataBinder.Eval(dr, "Manufacturer").ToString() == "Other")
                brand += string.Concat(" ", DataBinder.Eval(dr, "OtherMake").ToString(), " ", DataBinder.Eval(dr, "OtherModel").ToString());
            else
            {
                brand += string.Concat(" ", DataBinder.Eval(dr, "Manufacturer").ToString());
                if (DataBinder.Eval(dr, "Model").ToString() == "Other")
                    brand += string.Concat(" ", DataBinder.Eval(dr, "OtherModel").ToString());
                else
                    brand += string.Concat(" ", DataBinder.Eval(dr, "Model").ToString());
            }
            string mtrim = string.Empty;
            if (DataBinder.Eval(dr, "ModelTrimValue").ToString() == "Other")
                mtrim += DataBinder.Eval(dr, "OtherTrim").ToString();
            else
                mtrim += DataBinder.Eval(dr, "ModelTrimValue").ToString();
            return string.Concat(brand, " ", mtrim);
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

        protected string GetApprovedText(object item)
        {
            if (DataBinder.Eval(item, "Approved").ToString() == "True")
                return "Yes";
            else
                return "No";
        }

        protected void GvMyVehicles_DataBound(object sender, EventArgs e)
        {
            if (GvMyVehicles.Rows.Count > 0)
            {                
                //GvMyVehicles.Columns[8].Visible = false;
                GvMyVehicles.HeaderRow.TableSection = TableRowSection.TableHeader;
                TableCellCollection cells = GvMyVehicles.HeaderRow.Cells;
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

        protected void GvMyVehicles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Session["CustomerType"].ToString() == "Business")
                {
                    GvMyVehicles.Columns[8].Visible = true;
                    CustomerVehicleInfo c = e.Row.DataItem as CustomerVehicleInfo;
                    ImageButton BtnModify = e.Row.FindControl("BtnModify") as ImageButton;
                    ImageButton BtnSold = e.Row.FindControl("BtnSold") as ImageButton;
                    ImageButton BtnSoldb = e.Row.FindControl("BtnSoldMore") as ImageButton;
                    Label soldLabel = e.Row.FindControl("lblItemSold") as Label;
                    switch (c.Status)
                    {
                        case "Sold":
                            BtnModify.Visible = false;
                            BtnSold.Visible = false;
                            BtnSoldb.Visible = false;
                            soldLabel.Visible = true;
                            break;
                        case "BtnSoldMore":
                            BtnModify.Visible = true;
                            BtnSold.Visible = true;
                            BtnSoldb.Visible = false;
                            soldLabel.Visible = false;
                            break;
                        case "":
                            BtnModify.Visible = true;
                            BtnSold.Visible = true;
                            BtnSoldb.Visible = true;
                            soldLabel.Visible = false;
                            break;

                    }
                }
                else
                {
                    GvMyVehicles.Columns[9].Visible = false;
                }
            }
        }

        protected void GvMyVehicles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvMyVehicles.PageIndex = e.NewPageIndex;
            GvMyVehicles.DataBind();
        }

        protected void OdsCustomerVehicles_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if(e.Exception == null && e.ReturnValue != null)
            {
                e.AffectedRows = ((List<CustomerVehicleInfo>)e.ReturnValue).Count;
                lblCount.Text = e.AffectedRows + " vehicle(s) found.";
            }
        }
    }
}
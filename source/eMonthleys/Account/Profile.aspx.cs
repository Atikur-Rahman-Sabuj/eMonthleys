using System;
using System.Web.UI;
using eMonthleys.BLL;

namespace eMonthleys
{
    public partial class Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadProfileData(Convert.ToInt32(Session["CustomerId"]));
            Form.DefaultButton = BtnModifyUser.UniqueID;
        }
        protected void TxtEmail_TextChanged(object sender, EventArgs e)
        {
        }

        protected void LoadProfileData(int customerid)
        {
            Customer profile = Customer.GetCustomerDetails(customerid);
            if (profile != null)
            {
                RblCustomerType.SelectedValue = profile.CustomerType;
                RblCustomerType.Enabled = false;
                lblEmail.Text = profile.Email;
                txtCompany.Text = profile.Company;
                txtFirstName.Text = profile.FirstName;
                txtLastName.Text = profile.LastName;
                txtStreetNo.Text = profile.StreetNo.ToString();
                txtStreetNoSuffix.Text = profile.StreetNoSuffix;
                txtAddress1.Text = profile.Address1;
                txtAddress2.Text = profile.Address2;
                txtPobox.Text = profile.POBox;
                txtCity.Text = profile.City;
                ddlState.SelectedValue = profile.State;
                txtZip.Text = profile.ZIP;
                ddlCountry.SelectedValue = profile.Country;
                txtPhone.Text = profile.Phone;
                txtCellPhone.Text = profile.CellPhone;
            }
        }
        protected void BtnModifyCustomer_Click(object sender, EventArgs e)
        {
         if (Page.IsValid)
            {
                Customer c = new Customer();
                c.Id = Convert.ToInt32(Session["CustomerId"]);
                c.CustomerType = RblCustomerType.SelectedValue;
                c.Company = Server.HtmlEncode(txtCompany.Text);
                c.FirstName = Server.HtmlEncode(txtFirstName.Text);
                c.LastName = Server.HtmlEncode(txtLastName.Text);
                c.Address1 = Server.HtmlEncode(txtAddress1.Text);
                c.Address2 = Server.HtmlEncode(txtAddress2.Text);
                c.StreetNo = Convert.ToInt32(txtStreetNo.Text);
                c.StreetNoSuffix = txtStreetNoSuffix.Text;
                c.City = txtCity.Text;
                c.ZIP = txtZip.Text;
                c.State = ddlState.SelectedValue;
                c.Country = ddlCountry.SelectedValue;
                c.POBox = txtPobox.Text;
                c.Phone = txtPhone.Text;
                c.CellPhone = txtCellPhone.Text;
                c.UserType = "customer";
                try
                {
                    if (Customer.UpdateCustomer(c))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "alert('Your profile has been modified.');", true);
                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Modification failed!\nPlease try again or contact us if modification fails again.');", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", " alert('Modification failed!\nPlease try again or contact us if Modification fails again.');", true);
        }
        


        //rblCondition.SelectedValue = profile..VehicleCondition;
        //ddlVehicleType.SelectedValue = vehicle.VehicleCategoryId.ToString();
        //ddlYear.SelectedValue = vehicle.ModelYear.ToString();
        //DdlMakes.SelectedValue = vehicle.Manufacturer;
        ////DdlModel.SelectedValue = vehicle.Model;
        ////DdlTrim.SelectedValue = vehicle.ModelTrim.ToString();
        //ddlBodyColour.SelectedValue = vehicle.ExteriorColor;
        //ddlInteriorColour.SelectedValue = vehicle.InteriorColor;
        //txtEngineSize.Text = vehicle.Engine.ToString();
        //txtCylinder.Text = vehicle.Cylinder.ToString();
        //txtMileage.Text = vehicle.CurrentMileage.ToString();
        //ddlTransmission.SelectedValue = vehicle.Transmission;
        //ddlWheels.SelectedValue = vehicle.Wheels;
        //cbxChrome.Checked = vehicle.ChromeWheels;
        //cbxExtraWinter.Checked = vehicle.WinterWheels;
        //ddlTires.SelectedValue = vehicle.Tires;


    }   
}
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using eMonthleys.BLL;
using eMonthleys.Utils;

namespace eMonthleys
{
    public partial class advertise : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private string err { get; set; }
        private Customer usr
        {
            get
            {
                if (Request.QueryString.Keys.Count > 0)
                    return (Customer)Session["SelectedCustomer"];
                else
                    return (Customer)Session["User"];
            }
        }

        private int filesuploaded { get; set; }

        protected string ImageErr(string imgSize)
        {
            var maxWidth = 250;
            HttpFileCollection files = Request.Files;
            var rc = string.Empty;

            if (imgSize == "L")
                maxWidth = 1130;
            if (files.Count <= 0) return rc;
            for (var i = 0; i < files.Count; i++)
            {
                if (files[i].InputStream.Length <= 0) continue;
                var pic = System.Drawing.Image.FromStream(files[i].InputStream);
                if (pic.Width <= maxWidth) continue;
                if (pic.Height > 200)
                {
                    rc += "<li>Image file #" + (i + 1) + " exceeds " + maxWidth + "px * 200px (height * width).</li>";
                }
            }
            return rc;
        }

        protected void BtnSaveAd_Click(object sender, EventArgs e)
        {
            string err = ImageErr(rblAdFormat.SelectedValue);
            if (err != string.Empty)
            {
                pnlErr.Visible = true;
                ltlErr.Text = "<ul>" + err + "</ul><p>Please upload files of correct sizes.</p>";
                return;
            }
            CustomerAd ad = new CustomerAd();
            int CustomerId = usr.Id;
            string path = "c" + CustomerId + "_ads";
            HttpFileCollection files = Request.Files;
            string[] allowedExtension = { ".jpeg", ".jpg", ".png", ".gif" };

            ad.AdType = rblAdFormat.SelectedValue;
            ad.AdDetails = txtAdDetails.Text;
            if (FileUpload1.HasFile)
                ad.Img1 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload1.PostedFile.FileName));
            if (FileUpload2.HasFile)
                ad.Img2 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload2.PostedFile.FileName)); ;
            if (FileUpload3.HasFile)
                ad.Img3 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload3.PostedFile.FileName)); ;
            if (FileUpload4.HasFile)
                ad.Img4 = @"/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload4.PostedFile.FileName)); ;

            ad.CustomerId = CustomerId;
            ad.Expires = DateTime.Now.AddMonths(1);
            if (Session["Role"].ToString() == "admin")
            {
                ad.Active = true;
                ad.Paid = true;
                ad.Confirmed = true;
            }
            else
            {
                ad.Active = false;
                ad.Paid = false;
                ad.Confirmed = false;
            }
            ad.URL = (txtUrl.Text == string.Empty) ? string.Empty : txtUrl.Text;
            Session["ad"] = ad;

            filesuploaded = 0;
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
                            break;
                        if (allowedExtension.Contains(Path.GetExtension(files[i].FileName)))
                        {
                            HttpPostedFile pf = files[i];
                            string filetoput = Server.MapPath("~/imgs/" + path + "/" + Helpers.RemoveInvalidChars(Path.GetFileName(files[i].FileName)));
                            pf.SaveAs(filetoput);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", "alert('One or more images are of incorrect File format.');", true);
                            return;
                        }
                    }
                }
                filesuploaded = CustomerAd.InsertNewAd(ad);
            }
            catch (Exception ex)
            {
                ErrorHandler.writeExceptionToLogFile(ex);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Ad could not be uploaded.');", true);
                filesuploaded = 0;
            }
            if (filesuploaded > 0)
            {
                Session["adId"] = filesuploaded;
                Session["adSize"] = rblAdFormat.SelectedValue;
                if (err == string.Empty)
                    if (Session["Role"].ToString() == "admin")
                    {
                        double amnt = 99;
                        if (rblAdFormat.SelectedValue == "L")
                            amnt = 199;
                        UpdateAdBillingAdmin(amnt);
                        Response.Redirect("~/admin/ads.aspx");
                    }
                    else
                        Response.Redirect("CheckOut.aspx?item=ad&size=" + rblAdFormat.SelectedValue + "&id=" + filesuploaded + "&promo=0");
                else
                {
                    pnlErr.Visible = true;
                    ltlErr.Text = "<ul>" + err + "</ul><p>The images have been uploaded but you cannot continue until you edit the images to correct the size.</p>";
                }
            }
        }

        private void UpdateAdBillingAdmin(double amnt)
        {
            AdsBilling ad = new AdsBilling();
            ad.CustomerId = usr.Id;
            ad.AdId = filesuploaded;
            ad.Payment = amnt;
            ad.PayPalId = "BizAd by admin";
            ad.PayPalState = "SUCCESS";
            ad.CreateTime = DateTime.Now;
            if (AdsBilling.InsertNewBilling(ad))
            {
                CustomerAd.PaidInFull(ad.AdId);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Success", " alert('Business ad completed.');", true);
            }
        }

    }
}

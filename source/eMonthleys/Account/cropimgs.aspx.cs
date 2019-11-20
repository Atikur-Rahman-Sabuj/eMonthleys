using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Drawing;
using eImage = System.Drawing.Image;
using System.IO;
using Imazen.Crop;
using eMonthleys.BLL;
using ImageResizer;


namespace eMonthleys
{
    public partial class cropimgs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadImages();
        }

        protected void SetCrop(CropImage ci)
        {
            switch (Request.QueryString["size"].ToString())
            {
                case "S":
                    ci.W = 250;
                    ci.MaxSize = "250,200";
                    ci.MinSize = "250,200";
                    break;
                case "L":
                    ci.W = 1130;
                    ci.MaxSize = "1130,200";
                    ci.MinSize = "1130,200";
                    break;
            }
        }

        protected void LoadImages()
        {
            ltlErr.Text = Session["ImgSizeErr"].ToString();
            CustomerAd adImgs = (CustomerAd)Session["ad"];
            if (adImgs != null)
            {
                if (adImgs.Img1 != "")
                {
                    pnlCrop1.Visible = true;
                    Image1.ImageUrl = adImgs.Img1;
                    SetCrop(CropImage1);
                }
                else
                    pnlCrop1.Visible = false;
                if (adImgs.Img2 != "")
                {
                    pnlCrop2.Visible = true;
                    Image2.ImageUrl = adImgs.Img2;
                    SetCrop(CropImage2);
                }
                else
                    pnlCrop2.Visible = false;
                if (adImgs.Img3 != "")
                {
                    pnlCrop3.Visible = true;
                    Image3.ImageUrl = adImgs.Img3;
                    SetCrop(CropImage3);
                }
                else
                    pnlCrop3.Visible = false;
                if (adImgs.Img4 != "")
                {
                    pnlCrop4.Visible = true;
                    Image4.ImageUrl = adImgs.Img4;
                    SetCrop(CropImage4);
                }
                else
                    pnlCrop4.Visible = false;
            }
        }

        protected void btnCrop_Click(object sender, EventArgs e)
        {
            CropImage ci = this.FindControl(((Button)sender).ID.Replace("Button", "CropImage")) as CropImage;

            //Save an copy of the file with Crop()
            string fname = ci.CroppedUrl.Substring(0, ci.CroppedUrl.LastIndexOf("?"));
            string fileext = fname.Substring(fname.LastIndexOf("."));

            ci.Crop(Server.MapPath(fname), false);
            File.Copy(MapPath(fname), Server.MapPath("~/imgs/lastcropped" + fileext), true);

            //Show the image using the CroppedUrl property
            //result.ImageUrl = "/imgs/lastcropped" + fileext;
            //result.Visible = true;

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "ImgRefresh('/imgs/lastcropped" + fileext + "');", true);

            //Tell user about it
            message.Text = "Crop successful.";
            cropped.NavigateUrl = "/imgs/lastcropped" + fileext;
            cropped.Text = "View cropped image.";
            btnCheckout.Enabled = true;
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Info", "RefreshParent('" + Session["adSize"].ToString().Replace("\n", "") + "'," + Session["adId"].ToString() + ");", true);
        }
    }
}
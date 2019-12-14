using eMonthleys.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMonthleys.admin
{
    public partial class coverpicture : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnSave_Click(object sender, EventArgs e)
        {
            string image="";
            if (FileUpload1.HasFile)
                image = @"/images/cover/"+ Helpers.RemoveInvalidChars(Path.GetFileName(FileUpload1.PostedFile.FileName));

            Directory.SetCurrentDirectory(Server.MapPath("~/images"));
            if (!Directory.Exists("cover"))
                Directory.CreateDirectory("cover");

            if (image == "")
                return;
            string[] allowedExtension = {".png" };
            if (allowedExtension.Contains(Path.GetExtension(image)))
            {
                try
                {
                    HttpFileCollection files = Request.Files;
                    HttpPostedFile pf = files[0];
                    string filetoput = Server.MapPath("~/images/cover/image" + Path.GetExtension(image));
                    SaveFile(pf, filetoput);
                }
                catch (Exception ex)
                {
                    ErrorHandler.writeExceptionToLogFile(ex);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Error", "alert('Pictures could not be uploaded.');", true);
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
    }
}
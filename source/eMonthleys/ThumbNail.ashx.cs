using System;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace eMonthleys
{
    /// <summary>
    /// Summary description for ThumbNail
    /// </summary>
    public class ThumbNail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string pic = context.Request.QueryString["pic"];
            if (!File.Exists(HttpContext.Current.Server.MapPath(pic)))
                pic = @"\images\cargrey.png";
            int imgSize = Convert.ToInt16(context.Request.QueryString["size"]);
            int imgHeight = 100;
            Stream strm;

            context.Request.ContentType = "image/jpeg";
            if (imgSize > 100)
                strm = ResizeImage(pic, new Size(imgSize, imgHeight), true);
            else
                strm = ResizeImage(pic, new Size(imgSize, imgSize), true);
            byte[] buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);

            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
        }

        private MemoryStream ResizeImage(string img, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            Image image = null;
            if (File.Exists(HttpContext.Current.Server.MapPath(img)))
                image = Image.FromFile(HttpContext.Current.Server.MapPath(img));
            else
                return null;
            if (preserveAspectRatio)
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;
                float percentWidth = (float)size.Width / (float)originalWidth;
                float percentHeight = (float)size.Height / (float)originalHeight;
                float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = Convert.ToInt32(originalWidth * percent);
                newHeight = Convert.ToInt32(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (Graphics graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            MemoryStream ms = new MemoryStream(imageToByteArray(newImage));
            return ms;
        }

        private byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
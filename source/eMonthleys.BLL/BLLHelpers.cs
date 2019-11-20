using System.Configuration;

namespace eMonthleys.BLL
{
    public class BLLHelpers
    {
        public static string GetImagesBasePath()
        {
            return ConfigurationManager.AppSettings["ImagesBasePath"];
        }

    }
}

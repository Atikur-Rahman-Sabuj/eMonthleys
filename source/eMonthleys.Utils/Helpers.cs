using System;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web;

namespace eMonthleys.Utils
{
    public class Helpers
    {
        public static string GetConnectionString()
        {
            string cs = Encryption.Decrypt(WebConfigurationManager.ConnectionStrings["eMonthly"].ToString());
            return cs.Replace("\0", "");
        }

        #region Authentication

        public static bool IsInRole(string[] roles, string role)
        {
            bool found = false;

            foreach (string item in roles)
                if (item == role) found = true;

            return found;
        }

        public static string ExtractUserRolesFromUserData(string userData)
        {
            string userName = ExtractUserNameFromUserData(userData);
            string userRoles = userData.Replace(userName, "");
            userRoles = userRoles.Remove(userRoles.Length - 1);
            return userRoles;
        }

        public static string FormatRolesAsString(string[] roles)
        {
            string stringRoles = "";

            if (roles != null)
            {
                if (roles.Length > 0)
                {
                    for (int x = 0; x <= roles.Length - 1; x++)
                    {
                        stringRoles += roles[x] + ";";
                    }
                }
            }
            else
                stringRoles = ";";

            return stringRoles;
        }

        public static string[] GetRolesArrayFromString(string roles)
        {
            if (roles != null)
                return roles.Split(';');
            else
                return null;
        }

        public static string ExtractUserNameFromUserData(string userData)
        {
            string[] rolesOnly = userData.Split(';');
            string userName = rolesOnly[rolesOnly.Length - 1];
            return userName;
        }

        #endregion

        #region Convert Methods

        public static string ConvertBoolToString(bool b)
        {
            if (b)
                return "True";
            else
                return "False";
        }

        public static bool ConvertStringToBool(string s)
        {
            if (s.ToLower().Equals("true"))
                return true;
            else
                return false;
        }

        public static DateTime ConvertStringToDateTime(string s)
        {
            DateTime d;
            if (DateTime.TryParse(s, out d))
                return d;
            else
                return DateTime.MaxValue;
        }

        public static int ConvertStringToInt(string s)
        {
            int i;
            if (int.TryParse(s, out i))
                return i;
            else
                return 0;
        }

        public static bool ConvertObjectToBool(object b)
        {
            bool ret = false;
            bool success = bool.TryParse(b.ToString(), out ret);

            if (success)
                return ret;
            else
                return false;
        }

        public static string ConvertNullToBlank(object o)
        {
            if (o == null)
                return "";
            else
                return o.ToString();
        }

        public static string ConvertDbNullToBlank(object o)
        {
            if (o == DBNull.Value)
                return "";
            else
                return o.ToString();
        }

        #endregion

        #region String Functions

        public static bool IsBlankField(string b)
        {
            if (b.Trim() == "" || b == null)
                return true;
            else
                return false;
        }

        public static DateTime? ExtractNullableDateTimeFromString(string d)
        {
            DateTime validDate;
            if (DateTime.TryParse(d, out validDate))
                return validDate;
            else
                return null;
        }

        public static int ConvertNullIntToZero(object o)
        {
            if (o.Equals(DBNull.Value))
                return 0;
            else
            {
                int integer;
                int outInt = 0;

                if (int.TryParse(o.ToString(), out integer))
                {
                    outInt = integer;
                }

                return outInt;
            }
        }

        public static int ConvertNullInt64ToZero(object o)
        {
            if (o.Equals(DBNull.Value))
                return 0;
            else
            {
                int integer;
                int outInt64 = 0;

                if (int.TryParse(o.ToString(), out integer))
                {
                    outInt64 = integer;
                }

                return outInt64;
            }
        }

        public static double ConvertNullDblToZero(object o)
        {
            if (o.Equals(DBNull.Value))
                return 0;
            else
            {
                double dbl;
                double outDbl = 0;

                if (double.TryParse(o.ToString(), out dbl))
                {
                    outDbl = dbl;
                }

                return outDbl;
            }
        }

        public static string ReplaceEscapeEnterWithBR(object o)
        {
            if (o.Equals(DBNull.Value))
                return string.Empty;
            else
                return ((string)o).Replace(Environment.NewLine, "<br />");
        }

        public static String ConvertToTitleCase(string input)
        {
            string strTitleCase = input.Substring(0, 1).ToUpper();
            input = input.Substring(1).ToLower();
            string strPrev = "";


            for (int iIndex = 0; iIndex < input.Length; iIndex++)
            {
                if (iIndex > 1)
                {
                    strPrev = input.Substring(iIndex - 1, 1);
                }
                if (strPrev.Equals(" ") ||

                    strPrev.Equals("\t") ||
                    strPrev.Equals("\n") ||
                    strPrev.Equals("."))
                {
                    strTitleCase += input.Substring(iIndex, 1).ToUpper();
                }
                else
                {
                    strTitleCase += input.Substring(iIndex, 1);
                }
            }
            return strTitleCase;
        }

        public static string RightString(string input, int length)
        {
            string result = input.Substring(input.Length - length, length);

            return result;
        }

        public static string LeftString(string input, int length)
        {
            string result = input.Substring(0, length);

            return result;
        }

        public static string DisplayBlankFieldAsDash(object o)
        {
            if (o.Equals(DBNull.Value) || o.Equals(""))
                return "-";
            else
                return o.ToString();
        }

        #endregion

        #region Miscellaneous

        public static DropDownList InsertBlankItemToDropDownList(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            return ddl;
        }

        public static bool CheckImageExtension(string ext)
        {
            bool b = false;

            string[] allowedExtensions = new string[] { "jpg", "gif", "png", "jpeg" };

            foreach (string extension in allowedExtensions)
            {
                if (ext.Contains(extension))
                {
                    b = true;
                    break;
                }
            }

            return b;
        }

        public static DateTime? CheckNullableDate(object o)
        {
            DateTime date;
            DateTime? outDate = null;

            if (DateTime.TryParse(o.ToString(), out date))
            {
                outDate = date;
            }

            return outDate;
        }

        public static object ChangeNullToDbNullValue(object o)
        {
            if (o == null)
                return DBNull.Value;
            else
                return o;
        }

        public static bool isMobileBrowser()
        {
            //GETS THE CURRENT USER CONTEXT
            HttpContext context = HttpContext.Current;

            //FIRST TRY BUILT IN ASP.NT CHECK
            if (context.Request.Browser.IsMobileDevice)
            {
                return true;
            }
            //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER
            if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
            {
                return true;
            }
            //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP
            if (context.Request.ServerVariables["HTTP_ACCEPT"] != null &&
                context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
            {
                return true;
            }
            //AND FINALLY CHECK THE HTTP_USER_AGENT 
            //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING
            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                //Create a list of all mobile types
                string[] mobiles =
                    new[]
                {
                    "midp", "j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", 
                    "240x320", "opwv", "chtml",
                    "pda", "windows ce", "mmp/", 
                    "blackberry", "mib/", "symbian", 
                    "wireless", "nokia", "hand", "mobi",
                    "phone", "cdm", "up.b", "audio", 
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                    "NEC", "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", 
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone"
                };

                //Loop through each item in the list created above 
                //and check if the header contains that text
                foreach (string s in mobiles)
                {
                    if (context.Request.ServerVariables["HTTP_USER_AGENT"].
                                                        ToLower().Contains(s.ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static Bitmap ScaleImage(System.Drawing.Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = Convert.ToInt32(image.Width * ratio);
            var newHeight = Convert.ToInt32(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        public static string RemoveInvalidChars(string input)
        {
            string pattern = "[\\~#%&*{}/:<>?|\"-]";
            string replacement = "";

            Regex regEx = new Regex(pattern);
            string sanitized = Regex.Replace(regEx.Replace(input, replacement), @"\s+", "");
            return sanitized;
        }

        #endregion
    }
}

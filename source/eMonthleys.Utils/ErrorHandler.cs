using System;
using System.IO;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web;

namespace eMonthleys.Utils
{
    public class ErrorHandler
    {
        static string strYear = DateTime.Now.Year.ToString();
        static string strMonth = DateTime.Now.Month.ToString();
        static string strDay = DateTime.Now.Day.ToString();
        static string strLogFileName = strYear + strMonth + strDay;
        static string logPath = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["LogFolder"]);

        public static void writeSQLExceptionToLogFile(SqlException sqlEx)
        {
            string strLogMessage = string.Empty;

            StreamWriter swLog = new StreamWriter(logPath + strLogFileName + ".txt", true);

            strLogMessage = ((((((("Message: " + sqlEx.Message) + Environment.NewLine + "Exception: " +
                sqlEx.Errors) + Environment.NewLine + "Number: " + sqlEx.Number) +
                Environment.NewLine + "Source: " + sqlEx.Source) + Environment.NewLine + "Line Number: " +
                sqlEx.Number) + Environment.NewLine + "Stack Trace: " + sqlEx.StackTrace) +
                Environment.NewLine + "Target Site: " + sqlEx.TargetSite) + Environment.NewLine;

            swLog.WriteLine((Environment.NewLine + "***** START OF SQL EXCEPTION MESSAGE ON " + DateTime.Now + " *****") +
                Environment.NewLine);
            swLog.WriteLine(strLogMessage);
            swLog.WriteLine(Convert.ToString(System.Drawing.Drawing2D.DashStyle.Custom));
            swLog.WriteLine(Environment.NewLine + "***** END OF SQL EXCEPTION *****" + Environment.NewLine);
            swLog.Flush();
            swLog.Close();
        }

        public static void writeExceptionToLogFile(Exception ex)
        {
            string strLogMessage = string.Empty;

            StreamWriter swLog = new StreamWriter(logPath + strLogFileName + ".txt", true);

            strLogMessage = (((("Message: " + ex.Message) + Environment.NewLine + "Source: " + ex.Source) +
                Environment.NewLine + "Target Site: " + ex.TargetSite) + Environment.NewLine + "Stack Trace: " +
                ex.StackTrace) + Environment.NewLine;

            swLog.WriteLine((Environment.NewLine + "***** START OF EXCEPTION MESSAGE ON " + DateTime.Now + " *****") +
                Environment.NewLine);
            swLog.WriteLine(strLogMessage);
            swLog.WriteLine(Convert.ToString(System.Drawing.Drawing2D.DashStyle.Custom));
            swLog.WriteLine(Environment.NewLine + "***** END OF EXCEPTION MESSAGE *****" + Environment.NewLine);
            swLog.Flush();
            swLog.Close();
        }
    }
}

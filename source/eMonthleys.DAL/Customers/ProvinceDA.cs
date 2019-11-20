using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public class ProvinceDA : ProvinceBase
    {
        public override List<iProvince> SelectAll(string Country)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [cc]
                          ,[psc]
                          ,[province]
                      FROM [dbo].[prov]";
                if (Country != null)
                    q += " WHERE [cc] = '" + Country + "'";
                q += @" ORDER BY [province]";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetProvinceCollectionFromReader(reader);
                    else
                        return null;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return null;
                }
            }
        }

        public override iProvince Select(string ProvinceCode)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [cc]
                          ,[psc]
                          ,[province]
                      FROM [dbo].[prov]
                      WHERE [psc] = @psc";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@psc", SqlDbType.VarChar).Value = ProvinceCode;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetProvinceFromReader(reader, true);
                    else
                        return null;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return null;
                }
            }
        }
    }
}

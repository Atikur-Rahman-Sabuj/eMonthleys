using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public class FeaturesByVehicleDA : FeaturesByVehicleBase
    {
        public override List<iFeaturesByVehicle> SelectAll(int VehicleId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[feature]
                          ,[featuretype]
                      FROM [dbo].[viewFeatures]
                      WHERE [id] = @VId
                      ORDER BY [featuretype], [feature]";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VId", SqlDbType.Int).Value = VehicleId;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetFeaturesByVehicleCollectionFromReader(reader);
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

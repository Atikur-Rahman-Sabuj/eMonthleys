using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{

    class VehicleFeaturesDA : VehicleFeaturesBase   
    {
        public override bool Insert(List<iVehicleFeatures> Features)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                SqlCommand cmd = new SqlCommand(q, conn);

                q = @"INSERT INTO vehiclefeatures (vehicleid,featureid) ";
                for (int i = 0; i < Features.Count; i++ )
                {
                    q += "SELECT @pVehicleId" + i + ", @pFeatureId" + i + " ";
                    cmd.Parameters.AddWithValue("@pVehicleId" + i, Features[i].VehicleId);
                    cmd.Parameters.AddWithValue("@pFeatureId" + i, Features[i].FeatureId);
                    if (Features.Count - 1 != i)
                        q += "UNION ALL ";
                }
                q += ";";
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;

                try
                {
                    conn.Open();
                    int rc = ExecuteNonQuery(cmd);
                    return (rc == 1);
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return false;
                }
            }
        }
        public override bool Update(iVehicleFeatures Feature)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"UPDATE vehiclefeatures SET 
                    vehicleid = @pVehicleId,
                    featureid = @pFeatureId 
                    WHERE id = @pid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pVehicleId", SqlDbType.Int).Value = Feature.VehicleId;
                cmd.Parameters.Add("@pFeatureId", SqlDbType.Int).Value = Feature.FeatureId;

                try
                {
                    conn.Open();
                    int rc = ExecuteNonQuery(cmd);
                    return (rc == 1);
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return false;
                }
            }
        }
        public override bool Delete(int VehicleId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    DELETE FROM vehiclefeatures
                    WHERE vehicleid = @VehicleId";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VehicleId", SqlDbType.Int).Value = VehicleId;

                try
                {
                    conn.Open();

                    int ret = ExecuteNonQuery(cmd);
                    return (ret == 1);
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return false;
                }
            }
        }
       
        public override List<iVehicleFeatures> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[vehicleid]
                          ,[featureid]
                    FROM [dbo].[vehiclefeatures]";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetVehicleFeaturesCollectionFromReader(reader);
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

        public override iVehicleFeatures Select(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[vehicleid]
                          ,[featureid]
                      FROM [dbo].[vehiclefeatures]
                      WHERE [id] = @cid";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetVehicleFeaturesFromReader(reader, true);
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

        public override List<iVehicleFeatures> SelectAllByVehicleId(int VehicleId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[vehicleid]
                          ,[featureid]
                    FROM [dbo].[vehiclefeatures]
                    WHERE [vehicleid] = @pVehicleId";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pVehicleId", SqlDbType.Int).Value = VehicleId;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetVehicleFeaturesCollectionFromReader(reader);
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

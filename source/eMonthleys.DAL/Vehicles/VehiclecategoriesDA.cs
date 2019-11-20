using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    class VehiclecategoriesDA : VehiclecategoriesBase
    {
        public override bool Insert(iVehiclecategories c)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                SqlCommand cmd = new SqlCommand(q, conn);

                q = @"INSERT INTO vehiclecategories (name, vtype) VALUES ( @pName, @pVtype)";

                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = c.Name;
                cmd.Parameters.Add("@pVtype", SqlDbType.VarChar).Value = c.VehicleType;
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
        public override bool Update(iVehiclecategories c)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"UPDATE vehiclecategories SET 
                    name = @pName,
                    vtype = pVtype 
                    WHERE id = @pid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = c.Name;
                cmd.Parameters.Add("@pVtype", SqlDbType.VarChar).Value = c.VehicleType;
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
        public override bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    DELETE FROM vehiclecategories
                    WHERE id = @cid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;

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
        public override List<iVehiclecategories> SelectAll(string VehicleType)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[name]
                          ,[vtype]
                      FROM [dbo].[vehiclecategories]";
                if (VehicleType != null)
                      q += " WHERE [vtype] = '" + VehicleType + "'";
                q += @" ORDER BY [vtype], [name]";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetVehiclecategoriesCollectionFromReader(reader);
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

        public override iVehiclecategories Select(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[name]
                          ,[vtype]
                    FROM [dbo].[vehiclecategories]
                    WHERE [id] = @cid";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetVehiclecategoriesFromReader(reader, true);
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

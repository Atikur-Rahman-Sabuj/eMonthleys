using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
	public class VehiclefeaturelookupDA : VehiclefeaturelookupBase
	{
		public override bool Insert(iVehiclefeaturelookup c)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{

				string q = string.Empty;
				SqlCommand cmd = new SqlCommand(q, conn);

				q = @"INSERT INTO vehfeaturelookup (feature) VALUES ( @pFeature)";

				cmd.CommandText = q;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.Add("@pFeature", SqlDbType.VarChar).Value = c.Feature;
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
		public override bool Update(iVehiclefeaturelookup c)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string q = string.Empty;

				q = @"UPDATE vehfeaturelookup SET 
					feature = @pFeature 
					WHERE id = @pid";


				SqlCommand cmd = new SqlCommand(q, conn);
				cmd.CommandText = q;
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.Add("@pFeature", SqlDbType.Int).Value = c.Feature;
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
					DELETE FROM vehfeaturelookup
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
		public override List<iVehiclefeaturelookup> SelectAll()
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string q = string.Empty;

				q = @"
					SELECT [id]
						,[feature]
						,[featuretype]
						,[listtype]
					FROM [dbo].[vehfeaturelookup]";
				SqlCommand cmd = new SqlCommand(q, conn);
				cmd.CommandType = CommandType.Text;
				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
					if (reader.HasRows)
						return GetVehiclefeaturelookupCollectionFromReader(reader);
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

		public override iVehiclefeaturelookup Select(int id)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string q = string.Empty;

				q = @"
					SELECT [id]
						  ,[feature]
					FROM [dbo].[vehfeaturelookup]
					WHERE [id] = @cid";
				SqlCommand cmd = new SqlCommand(q, conn);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
					if (reader.HasRows)
						return GetVehiclefeaturelookupFromReader(reader, true);
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

	public class FeatureLookupDA : FeatureLookupBase
	{
		public override List<iFeatureLookup> SelectAll(string FeatureType, string Listtype)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string q = string.Empty;

				q = @"
					SELECT [id]
						  ,[feature]
					  FROM [dbo].[vehfeaturelookup]
					  WHERE [featuretype] = @FeatureType
					  AND [listtype] = @ListType";

				SqlCommand cmd = new SqlCommand(q, conn);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.Add("@FeatureType", SqlDbType.VarChar).Value = FeatureType;                
				cmd.Parameters.Add("@ListType", SqlDbType.VarChar).Value = Listtype;
				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
					if (reader.HasRows)
						return GetFeatureLookupCollectionFromReader(reader);
					
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

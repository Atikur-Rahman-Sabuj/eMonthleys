using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
	public class ModelYearLookupDA : ModelYearLookupBase
	{
		public override List<iModelYearLookup> SelectAll()
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string q = string.Empty;

				q = @"
					SELECT [model_year]
					  FROM [dbo].[view_model_names]
					  GROUP BY [model_year]
					  ORDER BY [model_year] DESC";

				SqlCommand cmd = new SqlCommand(q, conn);
				cmd.CommandType = CommandType.Text;
				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
					if (reader.HasRows)
						return GetModelYearLookupCollectionFromReader(reader);
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

	public class MakeLookupDA : MakeLookupBase
	{
		public override List<iMakeLookup> SelectAll()
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string q = string.Empty;

				q = @"
					SELECT [model_make_display] 
					  FROM [dbo].[view_model_names] 
					  WHERE [model_make_display] IS NOT NULL 
					  GROUP BY [model_make_display] 
					  ORDER BY [model_make_display]";

				SqlCommand cmd = new SqlCommand(q, conn);
				cmd.CommandType = CommandType.Text;
				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
					if (reader.HasRows)
						return GetMakeLookupCollectionFromReader(reader);
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

	public class ModelLookupDA : ModelLookupBase
	{
		public override List<iModelLookup> SelectAll(string Make)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string q = string.Empty;

				q = @"
					SELECT [model_name]
					  FROM [dbo].[View_Model_Names]
					  WHERE [model_make_display] = @Manufacturer
					  GROUP BY [model_name]";

				SqlCommand cmd = new SqlCommand(q, conn);
				cmd.CommandType = CommandType.Text;
				//cmd.Parameters.Add("@ModelYear", SqlDbType.Int).Value = Convert.ToInt16(ModelYear);
				cmd.Parameters.Add("@Manufacturer", SqlDbType.VarChar).Value = Make;
				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
					if (reader.HasRows)
						return GetModelLookupCollectionFromReader(reader);
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

	public class ModelTrimLookupDA : ModelTrimLookupBase
	{
		public override List<iModelTrimLookup> SelectAll(string ModelName, string Manufacturer)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string q = string.Empty;

				q = @"
					SELECT [model_id]
						  ,[model_trim]
					  FROM [dbo].[View_Model_Names]
					  WHERE [model_make_display] = @Manufacturer
					  AND [model_name] = @ModelName
					  AND [model_trim] IS NOT NULL
					  ORDER BY [model_trim]";

				SqlCommand cmd = new SqlCommand(q, conn);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.Add("@Manufacturer", SqlDbType.VarChar).Value = Manufacturer;
				cmd.Parameters.Add("@ModelName", SqlDbType.VarChar).Value = ModelName;
				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
					if (reader.HasRows)
						return GetModelTrimLookupCollectionFromReader(reader);
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

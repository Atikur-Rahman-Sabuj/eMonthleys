using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
	public class AdsAdminDA : AdsAdminBase
	{
		public override List<iAdsAdmin> SelectAllByStatus(bool Status)
		{
			using (SqlConnection conn = new SqlConnection(ConnectionString))
			{
				string q = string.Empty;

				q = @"
					SELECT a.[id]
						  ,a.[customerid]
						  ,c.[company]
						  ,c.[firstname]
						  ,c.[lastname]
						  ,a.[adtype]
						  ,a.[addetails]
						  ,a.[img1]
						  ,a.[img2]
						  ,a.[img3]
						  ,a.[img4]
						  ,a.[expires]
						  ,a.[paid]
						  ,a.[active]
						  ,a.[confirmed]
						  ,b.[paypalid]
						  ,b.[ppstate]
						  ,b.[create_time]
						  ,a.[declined]
					  FROM [dbo].[customerads] a
					  INNER JOIN [dbo].[customers] c ON a.[customerid] = c.[id]
					  INNER JOIN [dbo].[billing_ads] b ON a.[id] = b.[adid]
					  WHERE a.[active] = @Status AND a.[declined] = 0
					  ORDER BY a.[customerid],a.[expires]";
				SqlCommand cmd = new SqlCommand(q, conn);
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
					if (reader.HasRows)
						return GetCustomerAdsCollectionFromReader(reader);
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

        public override List<iAdsAdmin> SelectAllDeclined()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
					SELECT a.[id]
						  ,a.[customerid]
						  ,c.[company]
						  ,c.[firstname]
						  ,c.[lastname]
						  ,a.[adtype]
						  ,a.[addetails]
						  ,a.[img1]
						  ,a.[img2]
						  ,a.[img3]
						  ,a.[img4]
						  ,a.[expires]
						  ,a.[paid]
						  ,a.[active]
						  ,a.[confirmed]
						  ,b.[paypalid]
						  ,b.[ppstate]
						  ,b.[create_time]
						  ,a.[declined]
					  FROM [dbo].[customerads] a
					  INNER JOIN [dbo].[customers] c ON a.[customerid] = c.[id]
					  INNER JOIN [dbo].[billing_ads] b ON a.[id] = b.[adid]
					  WHERE a.[declined] = 1
					  ORDER BY a.[customerid],a.[expires]";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetCustomerAdsCollectionFromReader(reader);
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

        public override bool DeclineAd(int Id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
					UPDATE [dbo].[customerads] 
                      SET [declined] = @Decline
					  WHERE [id] = @Id";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Decline", SqlDbType.Bit).Value = true;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
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
	}
}

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public class BillingAdsDA : BillingAdsBase
    {
        public override bool Insert(iBillingAds ba)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                SqlCommand cmd = new SqlCommand(q, conn);

                q = @"
                    INSERT INTO [dbo].[billing_ads]
                                ([customerid]
                                ,[adid]
                                ,[payment]
                                ,[paypalid]
                                ,[ppstate]
                                ,[create_time])
                            VALUES
                                (@pCustomerid
                                ,@pAdId
                                ,@pCost
                                ,@pPayPalId
                                ,@pState
                                ,@pTime)";

                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pCustomerid", SqlDbType.Int).Value = ba.CustomerId;
                cmd.Parameters.Add("@pAdId", SqlDbType.Int).Value = ba.AdId;
                cmd.Parameters.Add("@pCost", SqlDbType.Money).Value = ba.Payment;
                cmd.Parameters.Add("@pPayPalId", SqlDbType.VarChar).Value = ba.PayPalId;
                cmd.Parameters.Add("@pState", SqlDbType.VarChar).Value = ba.PayPalState;
                cmd.Parameters.Add("@pTime", SqlDbType.DateTime).Value = ba.CreateTime;

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

        public override bool Update(iBillingAds ba)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[billing_ads]
                       SET [customerid] = @pCustomerid
                          ,[adid] = @pAdId
                          ,[payment] = @pCost
                     WHERE id = @pid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = ba.Id;
                cmd.Parameters.Add("@pCustomerid", SqlDbType.Int).Value = ba.CustomerId;
                cmd.Parameters.Add("@pAdId", SqlDbType.Int).Value = ba.AdId;
                cmd.Parameters.Add("@pCost", SqlDbType.Money).Value = ba.Payment;
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
                    DELETE FROM [dbo].[billing_ads]
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
        public override List<iBillingAds> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[customerid]
                          ,[adid]
                          ,[payment]
                          ,[paypalid]
                          ,[ppstate]
                          ,[create_time]
                      FROM [dbo].[billing_ads]";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetAdBillingCollectionFromReader(reader);
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
        public override iBillingAds Select(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[customerid]
                          ,[adid]
                          ,[payment]
                          ,[paypalid]
                          ,[ppstate]
                          ,[create_time]
                      FROM [dbo].[billing_ads]
                      WHERE [id] = @cid";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetAdBillingFromReader(reader, true);
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

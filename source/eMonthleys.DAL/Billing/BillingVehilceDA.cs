using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public class BillingVehilceDA : BillingVehicleBase
    {
        public override int Insert(iBillingVehicle bv)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                SqlCommand cmd = new SqlCommand(q, conn);

                q = @"
                    INSERT INTO [dbo].[billingvehicles]
                                ([customerid]
                                ,[adsbought]
                                ,[adsremaining]
                                ,[payment]
                                ,[promocode])
                            VALUES
                                (@pCustomerid
                                ,@pBought
                                ,@pRemaining
                                ,@pCost
                                ,@Promo);
                                SELECT SCOPE_IDENTITY()";

                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pCustomerid", SqlDbType.Int).Value = bv.CustomerId;
                cmd.Parameters.Add("@pBought", SqlDbType.Int).Value = bv.AdsBought;
                cmd.Parameters.Add("@pRemaining", SqlDbType.Int).Value = bv.AdsRemaining;
                cmd.Parameters.Add("@pCost", SqlDbType.Money).Value = bv.Payment;
                cmd.Parameters.Add("@Promo", SqlDbType.VarChar).Value = bv.PromoCode;

                try
                {
                    conn.Open();
                    int rc = Convert.ToInt32(ExecuteScalar(cmd));
                    return rc;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return 0;
                }
            }
        }

        public override bool UpdateRemaining(iBillingVehicle bv)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[billingvehicles]
                       SET [adsremaining] = @pRemaining
                     WHERE id = @pBillId";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pBillId", SqlDbType.Int).Value = bv.Id;
                cmd.Parameters.Add("@pRemaining", SqlDbType.Int).Value = bv.AdsRemaining;
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

        public override bool PaidInFull(iBillingVehicle v)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[billingvehicles]
                       SET [paypalid] = @ppId,
                           [ppstate] = @ppState,
                           [create_time] = @PaymentDate
                     WHERE id = @pBillId";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ppId", SqlDbType.VarChar).Value = v.PayPalId;
                cmd.Parameters.Add("@ppState", SqlDbType.VarChar).Value = v.PayPalState;
                cmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime).Value = v.CreateTime;
                cmd.Parameters.Add("@pBillId", SqlDbType.Int).Value = v.Id;
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
                    DELETE FROM [dbo].[billingvehicles]
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
        public override List<iBillingVehicle> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[customerid]
                          ,[adsbought]
                          ,[adsremaining]
                          ,[payment]
                          ,[promocode]
                          ,[paypalid]
                          ,[ppstate]
                          ,[create_time]
                      FROM [dbo].[billingvehicles]";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetVehicleBillingCollectionFromReader(reader);
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
        public override iBillingVehicle Select(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[customerid]
                          ,[adsbought]
                          ,[adsremaining]
                          ,[payment]
                          ,[promocode]
                          ,[paypalid]
                          ,[ppstate]
                          ,[create_time]
                      FROM [dbo].[billingvehicles]
                      WHERE [id] = @cid";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetVehicleBillingFromReader(reader, true);
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

        public override iBillingVehicle SelectIfRemaining(int CutomerId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[customerid]
                          ,[adsbought]
                          ,[adsremaining]
                          ,[payment]
                          ,[promocode]
                          ,[paypalid]
                          ,[ppstate]
                          ,[create_time]
                      FROM [dbo].[billingvehicles]
                      WHERE [customerid] = @cid
                      AND [adsremaining] <> 0";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = CutomerId;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetVehicleBillingFromReader(reader, true);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    class FinanceDA : FinanceBase
    {
        public override int Insert(iFinanceDetails f)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                q = @"
                    INSERT INTO [dbo].[financialdetails]
                               ([leaseorfinance]
                               ,[vehicleid]
                               ,[paymentcycle]
                               ,[paymentwithtax]
                               ,[originaldown]
                               ,[securitydeposit]
                               ,[poendoflease]
                               ,[kmallowance]
                               ,[excesskmcharge]
                               ,[leaseterm]
                               ,[leaseexpiry]
                               ,[buyback]
                               ,[balloon]
                               ,[purchaseprice]
                               ,[summary]
                               ,[comments]
                               ,[adstatus])
                         VALUES
                               (@pLeaseOrFinance
                               ,@pVehicleid
                               ,@pPayCycle
                               ,@pPaymentWithTax
                               ,@pOriginalDown
                               ,@pSecurityDeposit
                               ,@pPoendOfLease
                               ,@pKmAllowance
                               ,@pExcessKMcharge
                               ,@pLeaseterm
                               ,@pLeaseExpiry
                               ,@pBuyback
                               ,@pBalloon
                               ,@pPurchsePrice
                               ,@pSummary
                               ,@pComments
                               ,@pAdStatus);
                                SELECT SCOPE_IDENTITY()";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandText = q,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@pLeaseOrFinance", SqlDbType.VarChar).Value = f.LeaseOrFinance;
                cmd.Parameters.Add("@pVehicleid", SqlDbType.Int).Value = f.VehicleId;
                cmd.Parameters.Add("@pPayCycle", SqlDbType.VarChar).Value = f.PaymentCycle ?? string.Empty;
                cmd.Parameters.Add("@pPaymentWithTax", SqlDbType.Money).Value = f.PaymentWithTax;
                cmd.Parameters.Add("@pOriginalDown", SqlDbType.Money).Value = f.OriginalDown;
                cmd.Parameters.Add("@pSecurityDeposit", SqlDbType.Money).Value =f.SecurityDeposit;
                cmd.Parameters.Add("@pPoendOfLease", SqlDbType.VarChar).Value = f.PoEndOfLease ?? string.Empty;
                cmd.Parameters.Add("@pKmAllowance", SqlDbType.Int).Value = f.KmAllowance;
                cmd.Parameters.Add("@pExcessKMcharge", SqlDbType.Money).Value = f.ExcessKmCharge;
                cmd.Parameters.Add("@pLeaseterm", SqlDbType.Int).Value = f.LeaseTerm;
                cmd.Parameters.Add("@pLeaseExpiry", SqlDbType.Date).Value = ((object)f.LeaseExpiry) ?? DBNull.Value;
                cmd.Parameters.Add("@pBuyback", SqlDbType.Money).Value = f.BuyBack;
                cmd.Parameters.Add("@pBalloon", SqlDbType.Money).Value = f.Balloon;
                cmd.Parameters.Add("@pPurchsePrice", SqlDbType.Money).Value = f.PurchasePrice;
                cmd.Parameters.Add("@pSummary", SqlDbType.Text).Value = f.Summary;
                cmd.Parameters.Add("@pComments", SqlDbType.Text).Value = f.Comments;
                cmd.Parameters.Add("@pAdStatus", SqlDbType.Bit).Value = f.AdStatus;
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
                finally
                {
                    conn.Close();
                }
            }
        }
        public override bool Update(iFinanceDetails f)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                q = @"
                    UPDATE [dbo].[financialdetails]
                        SET [leaseorfinance] = @pLeaseOrFinance
                            ,[vehicleid] = @pVehicleid
                            ,[paymentcycle] = @pPayCycle
                            ,[paymentwithtax] = @pPaymentWithTax
                            ,[originaldown] = @pOriginalDown
                            ,[securitydeposit] = @pSecurityDeposit
                            ,[poendoflease] = @pPoendOfLease
                            ,[kmallowance] = @pKmAllowance
                            ,[excesskmcharge] = @pExcessKMcharge
                            ,[leaseterm] = @pLeaseterm
                            ,[leaseexpiry] = @pLeaseExpiry
                            ,[buyback] = @pBuyback
                            ,[balloon] = @pBalloon
                            ,[purchaseprice] = @pPurchsePrice
                            ,[summary] = @pSummary
                            ,[comments] = @pComments
                        WHERE [id] = @pid";


                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandText = q,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = f.Id;
                cmd.Parameters.Add("@pLeaseOrFinance", SqlDbType.VarChar).Value = f.LeaseOrFinance;
                cmd.Parameters.Add("@pVehicleid", SqlDbType.Int).Value = f.VehicleId;
                cmd.Parameters.Add("@pPayCycle", SqlDbType.VarChar).Value = f.PaymentCycle;
                cmd.Parameters.Add("@pPaymentWithTax", SqlDbType.Money).Value = f.PaymentWithTax;
                cmd.Parameters.Add("@pOriginalDown", SqlDbType.Money).Value = f.OriginalDown;
                cmd.Parameters.Add("@pSecurityDeposit", SqlDbType.Money).Value = f.SecurityDeposit;
                cmd.Parameters.Add("@pPoendOfLease", SqlDbType.VarChar).Value = f.PoEndOfLease;
                cmd.Parameters.Add("@pKmAllowance", SqlDbType.Int).Value = f.KmAllowance;
                cmd.Parameters.Add("@pExcessKMcharge", SqlDbType.Money).Value = f.ExcessKmCharge;
                cmd.Parameters.Add("@pLeaseterm", SqlDbType.Int).Value = f.LeaseTerm;
                cmd.Parameters.Add("@pLeaseExpiry", SqlDbType.Date).Value = ((object)f.LeaseExpiry) ?? DBNull.Value;
                cmd.Parameters.Add("@pBuyback", SqlDbType.Money).Value = f.BuyBack;
                cmd.Parameters.Add("@pBalloon", SqlDbType.Money).Value = f.Balloon;
                cmd.Parameters.Add("@pPurchsePrice", SqlDbType.Money).Value = f.PurchasePrice;
                cmd.Parameters.Add("@pSummary", SqlDbType.Text).Value = f.Summary;
                cmd.Parameters.Add("@pComments", SqlDbType.Text).Value = f.Comments;
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
                finally
                {
                    conn.Close();
                }
            }
        }

        public override bool Delete(int Id, int VehicleId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    DELETE FROM financialdetails 
                    WHERE [id] = @cid AND [vehicleid] = @vid";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@vid", SqlDbType.Int).Value = VehicleId;

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

        public override bool ChangeStatus(int Id, int VehicleId, string Status)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[financialdetails]
                    SET [status] = @pStatus
                    WHERE [id] = @pId AND [vehicleid] = @vid";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@pId", SqlDbType.Int).Value = Id;
                cmd.Parameters.Add("@pStatus", SqlDbType.VarChar).Value = Status;
                cmd.Parameters.Add("@vid", SqlDbType.Int).Value = VehicleId;

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

        public override List<iFinanceDetails> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[leaseorfinance]
                          ,[vehicleid]
                          ,[paymentcycle]
                          ,[paymentwithtax]
                          ,[originaldown]
                          ,[securitydeposit]
                          ,[poendoflease]
                          ,[kmallowance]
                          ,[excesskmcharge]
                          ,[leaseterm]
                          ,[leaseexpiry]
                          ,[buyback]
                          ,[balloon]
                          ,[purchaseprice]
                          ,[summary]
                          ,[comments]
                          ,[status]
                          ,[adstatus]
                      FROM [dbo].[financialdetails]";
                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetFinancialDetailsCollectionFromReader(reader);
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

        public override iFinanceDetails Select(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[leaseorfinance]
                          ,[vehicleid]
                          ,[paymentcycle]
                          ,[paymentwithtax]
                          ,[originaldown]
                          ,[securitydeposit]
                          ,[poendoflease]
                          ,[kmallowance]
                          ,[excesskmcharge]
                          ,[leaseterm]
                          ,[leaseexpiry]
                          ,[buyback]
                          ,[balloon]
                          ,[purchaseprice]
                          ,[summary]
                          ,[comments]
                          ,[status]
                          ,[adstatus]
                      FROM [dbo].[financialdetails]
                      WHERE [id] = @cid";
                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetFinancialDetailsFromReader(reader, true);
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

        public override iFinanceDetails SelectByVehicleId(int VehicleId, int FinId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[leaseorfinance]
                          ,[vehicleid]
                          ,[paymentcycle]
                          ,[paymentwithtax]
                          ,[originaldown]
                          ,[securitydeposit]
                          ,[poendoflease]
                          ,[kmallowance]
                          ,[excesskmcharge]
                          ,[leaseterm]
                          ,[leaseexpiry]
                          ,[buyback]
                          ,[balloon]
                          ,[purchaseprice]
                          ,[summary]
                          ,[comments]
                          ,[status]
                          ,[adstatus]
                      FROM [dbo].[financialdetails]
                      WHERE [id] = @pFinId AND [vehicleid] = @pVehicleId";
                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@pVehicleId", VehicleId);
                cmd.Parameters.AddWithValue("@pFinId", FinId);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetFinancialDetailsFromReader(reader, true);
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

        public override bool UpdatePrice(iFinanceDetails f)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[financialdetails]
                    SET [purchaseprice] = @Price
                    WHERE [vehicleid] = @pId";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@Price", f.PurchasePrice);
                cmd.Parameters.AddWithValue("@pId", f.VehicleId);

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

        public override bool UpdateAdStatus(int Id, int VehicleId, bool AdStatus)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE[dbo].[financialdetails]
                    SET[adstatus] = @AdStatus
                    WHERE [id] = @vId AND [vehicleid] = @vId";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@AdStatus", AdStatus);
                cmd.Parameters.AddWithValue("@pId", Id);
                cmd.Parameters.AddWithValue("@vId", VehicleId);

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

        public override List<string> CheckPayCycle(int VehicleId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                q = @"
                    SELECT [paymentcycle]
                    FROM [dbo].[financialdetails]
                    WHERE [vehicleid] = @pId";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@pId", VehicleId);
                List<string> paycycles = new List<string>();
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                    {
                        return GetFinancialPaymentCycleCollectionFromReader(reader);
                    }
                    else
                    {
                        return null;
                    }
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

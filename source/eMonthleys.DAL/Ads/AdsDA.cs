using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public class AdsDA : AdsBase
    {
        public override int Insert(iCustomerAds c)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                SqlCommand cmd = new SqlCommand(q, conn);

                q = @"INSERT INTO customerads (customerid,
                    adtype,
                    addetails,
                    img1,
                    img2,
                    img3,
                    img4,
                    expires,
                    paid,
                    active,
                    confirmed,
                    url) 
                VALUES (@pCustomerid,
                    @pAdtype,
                    @pAddetails,
                    @pImg1,
                    @pImg2,
                    @pImg3,
                    @pImg4,
                    @pExpires,
                    @pPaid,
                    @pActive,
                    @pConfirmed,
                    @pUrl);
                    SELECT SCOPE_IDENTITY();";

                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pCustomerid", SqlDbType.Int).Value = c.CustomerId;
                cmd.Parameters.Add("@pAdtype", SqlDbType.VarChar).Value = c.AdType;
                cmd.Parameters.Add("@pAddetails", SqlDbType.VarChar).Value = c.AdDetails;
                if (c.Img1 != null)
                    cmd.Parameters.Add("@pImg1", SqlDbType.VarChar).Value = c.Img1;
                else
                    cmd.Parameters.Add("@pImg1", SqlDbType.VarChar).Value = DBNull.Value;
                if (c.Img2 != null)
                    cmd.Parameters.Add("@pImg2", SqlDbType.VarChar).Value = c.Img2;
                else
                    cmd.Parameters.Add("@pImg2", SqlDbType.VarChar).Value = DBNull.Value;
                if (c.Img3 != null)
                    cmd.Parameters.Add("@pImg3", SqlDbType.VarChar).Value = c.Img3;
                else
                    cmd.Parameters.Add("@pImg3", SqlDbType.VarChar).Value = DBNull.Value;
                if (c.Img4 != null)
                    cmd.Parameters.Add("@pImg4", SqlDbType.VarChar).Value = c.Img4;
                else
                    cmd.Parameters.Add("@pImg4", SqlDbType.VarChar).Value = DBNull.Value;
                cmd.Parameters.Add("@pExpires", SqlDbType.DateTime).Value = c.Expires;
                cmd.Parameters.Add("@pPaid", SqlDbType.Bit).Value = c.Paid;
                cmd.Parameters.Add("@pActive", SqlDbType.Bit).Value = c.Active;
                cmd.Parameters.Add("@pConfirmed", SqlDbType.Bit).Value = c.Confirmed;
                cmd.Parameters.Add("@pUrl", SqlDbType.VarChar).Value = c.URL;
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

        public override bool Update(iCustomerAds c)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"UPDATE customerads SET 
                    customerid = @pCustomerid,
                    adtype = @pAdtype,
                    addetails = @pAddetails,
                    img1 = @pImg1,
                    img2 = @pImg2,
                    img3 = @pImg3,
                    img4 = @pImg4,
                    expires = @pExpires,
                    paid = @ePaid,
                    active = @pActive,
                    confirmed = @pConfirmed,
                    url = @pUrl 
                    WHERE id = @pid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pCustomerid", SqlDbType.Int).Value = c.CustomerId;
                cmd.Parameters.Add("@pAdtype", SqlDbType.VarChar).Value = c.AdType;
                cmd.Parameters.Add("@pAddetails", SqlDbType.VarChar).Value = c.AdDetails;
                if (c.Img1 != null)
                    cmd.Parameters.Add("@pImg1", SqlDbType.VarChar).Value = c.Img1;
                else
                    cmd.Parameters.Add("@pImg1", SqlDbType.VarChar).Value = DBNull.Value;
                if (c.Img2 != null)
                    cmd.Parameters.Add("@pImg2", SqlDbType.VarChar).Value = c.Img2;
                else
                    cmd.Parameters.Add("@pImg2", SqlDbType.VarChar).Value = DBNull.Value;
                if (c.Img3 != null)
                    cmd.Parameters.Add("@pImg3", SqlDbType.VarChar).Value = c.Img3;
                else
                    cmd.Parameters.Add("@pImg3", SqlDbType.VarChar).Value = DBNull.Value;
                if (c.Img4 != null)
                    cmd.Parameters.Add("@pImg4", SqlDbType.VarChar).Value = c.Img4;
                else
                    cmd.Parameters.Add("@pImg4", SqlDbType.VarChar).Value = DBNull.Value;
                cmd.Parameters.Add("@pExpires", SqlDbType.DateTime).Value = c.Expires;
                cmd.Parameters.Add("@pPaid", SqlDbType.Bit).Value = c.Paid;
                cmd.Parameters.Add("@pActive", SqlDbType.Bit).Value = c.Active;
                cmd.Parameters.Add("@pConfirmed", SqlDbType.Bit).Value = c.Confirmed;
                cmd.Parameters.Add("@pUrl", SqlDbType.VarChar).Value = c.URL;
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

        public override bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    DELETE FROM customerads
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

        public override bool PaidInFull(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE customerads
                    SET paid = 1
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

        public override bool ConfirmAd(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE customerads
                    SET confirmed = 1
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

        public override bool SetActiveStatus(int AdId, bool Status)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"UPDATE [dbo].[customerads]
                       SET [active] = @Status,
                           [declined] = 0
                     WHERE [id] = @AdId";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdId", SqlDbType.Int).Value = AdId;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
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

        public override List<iCustomerAds> SelectAllByType(string AdType)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                     SELECT TOP 3 *
                      FROM [dbo].[customerads]
                      WHERE [adtype] = @AdType
                      AND [active] = 1 AND [confirmed] = 1 AND [declined] = 0
                      ORDER BY NEWID()";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@AdType", SqlDbType.VarChar).Value = AdType;
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

        public override List<iCustomerAds> Select6SmallAdsRandom()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                     SELECT TOP 6 
                           [id]
                          ,[customerid]
                          ,[adtype]
                          ,[addetails]
                          ,[img1]
                          ,[img2]
                          ,[img3]
                          ,[img4]
                          ,[expires]
                          ,[paid]
                          ,[active]
                          ,[confirmed]
                          ,[url]
                          ,[declined]
                      FROM [dbo].[customerads]
                      WHERE [adtype] = 'S'
                      AND [active] = 1 AND [confirmed] = 1 AND [declined] = 0
                      ORDER BY RAND((1000*id)*DATEPART(millisecond, GETDATE()))";
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

        public override iCustomerAds SelectRandomLarge()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                     SELECT TOP 1 
                           [id]
                          ,[customerid]
                          ,[adtype]
                          ,[addetails]
                          ,[img1]
                          ,[img2]
                          ,[img3]
                          ,[img4]
                          ,[expires]
                          ,[paid]
                          ,[active]
                          ,[confirmed]
                          ,[url]
                          ,[declined]
                      FROM [dbo].[customerads]
                      WHERE [adtype] = 'L'
                      AND [active] = 1 AND [confirmed] = 1 AND [declined] = 0
                      ORDER BY RAND((1000*id)*DATEPART(millisecond, GETDATE()))";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetCustomerAdsFromReader(reader, true);
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

        public override iCustomerAds SelectRandomSmall()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                     SELECT TOP 1 
                           [id]
                          ,[customerid]
                          ,[adtype]
                          ,[addetails]
                          ,[img1]
                          ,[img2]
                          ,[img3]
                          ,[img4]
                          ,[expires]
                          ,[paid]
                          ,[active]
                          ,[confirmed]
                          ,[url]
                          ,[declined]
                      FROM [dbo].[customerads]
                      WHERE [adtype] = 'S'
                      AND [active] = 1 AND [confirmed] = 1 AND [declined] = 0
                      ORDER BY RAND((1000*id)*DATEPART(millisecond, GETDATE()))";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetCustomerAdsFromReader(reader, true);
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

        public override List<iCustomerAds> SelectAllByStatus(bool Status)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                        ,[customerid]
                        ,[adtype]
                        ,[addetails]
                        ,[img1]
                        ,[img2]
                        ,[img3]
                        ,[img4]
                        ,[expires]
                        ,[paid]
                        ,[active]
                        ,[confirmed]
                        ,[url]
                        ,[declined]
                    FROM [dbo].[customerads]
                    WHERE [active] = @Status
                    ORDER BY [customerid],[expires]";
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

        public override List<iCustomerAds> SelectAllByCustomerId( int CustomerId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                      SELECT [id]
                            ,[customerid]
                            ,[adtype]
                            ,[addetails]
                            ,[img1]
                            ,[img2]
                            ,[img3]
                            ,[img4]
                            ,[expires]
                            ,[paid]
                            ,[active]
                            ,[confirmed]
                            ,[url]
                            ,[declined]
                        FROM [dbo].[customerads]
                        WHERE [customerid] = @CustomerId AND [declined] = 0";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@CustomerId", SqlDbType.Int).Value = CustomerId;
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

  
        public override iCustomerAds Select(int AdId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                     SELECT [id]
                           ,[customerid]
                           ,[adtype]
                           ,[addetails]
                           ,[img1]
                           ,[img2]
                           ,[img3]
                           ,[img4]
                           ,[expires]
                           ,[paid]
                           ,[active]
                           ,[confirmed]
                           ,[url]
                           ,[declined]
                      FROM [dbo].[customerads]
                      WHERE [id] = @adid";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@adid", SqlDbType.Int).Value = AdId;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetCustomerAdsFromReader(reader, true);
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

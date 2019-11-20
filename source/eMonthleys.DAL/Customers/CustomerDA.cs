using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public class CustomerDA : CustomerBase
    {
        public override int Insert(iCustomer c)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                q = @"
                    INSERT INTO [dbo].[customers]
                                ([customertype]
                                ,[email]
                                ,[password]
                                ,[company]
                                ,[firstname]
                                ,[lastname]
                                ,[streetno]
                                ,[streetnosuffix]
                                ,[address1]
                                ,[address2]
                                ,[pobox]
                                ,[city]
                                ,[province]
                                ,[zip]
                                ,[country]
                                ,[phone]
                                ,[cellphone]
                                ,[usertype]
                                ,[active]
                                )
                        VALUES (
                                @pCustomerType, 
                                @pEmail, 
                                @pPwd, 
                                @pComp, 
                                @pFname, 
                                @pLname, 
                                @pStrNo, 
                                @pStrSfx, 
                                @pAddress1, 
                                @pAddress2, 
                                @pPOBOX, 
                                @pCity,
                                @pState, 
                                @pZIP, 
                                @pCountry, 
                                @pPhone, 
                                @pCell, 
                                @pUType,
                                @pActive
                                );
                                SELECT SCOPE_IDENTITY()";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pCustomerType", SqlDbType.VarChar).Value = c.CustomerType;
                cmd.Parameters.Add("@pEmail", SqlDbType.VarChar).Value = c.Email;
                cmd.Parameters.Add("@pPwd", SqlDbType.VarChar).Value = c.Password;
                cmd.Parameters.Add("@pComp", SqlDbType.VarChar).Value = c.Company;
                cmd.Parameters.Add("@pFname", SqlDbType.VarChar).Value = c.FirstName;
                cmd.Parameters.Add("@pLname", SqlDbType.VarChar).Value = c.LastName;
                cmd.Parameters.Add("@pStrNo", SqlDbType.Int).Value = c.StreetNo;
                cmd.Parameters.Add("@pStrSfx", SqlDbType.VarChar).Value = c.StreetNoSuffix;
                cmd.Parameters.Add("@pAddress1", SqlDbType.VarChar).Value = c.Address1;
                cmd.Parameters.Add("@pAddress2", SqlDbType.VarChar).Value = c.Address2;
                cmd.Parameters.Add("@pPOBOX", SqlDbType.VarChar).Value = c.POBox;
                cmd.Parameters.Add("@pCity", SqlDbType.VarChar).Value = c.City;
                cmd.Parameters.Add("@pState", SqlDbType.VarChar).Value = c.State;
                cmd.Parameters.Add("@pZIP", SqlDbType.VarChar).Value = c.ZIP;
                cmd.Parameters.Add("@pCountry", SqlDbType.VarChar).Value = c.Country;
                cmd.Parameters.Add("@pPhone", SqlDbType.VarChar).Value = c.Phone;
                cmd.Parameters.Add("@pCell", SqlDbType.VarChar).Value = c.CellPhone;
                cmd.Parameters.Add("@pUType", SqlDbType.VarChar).Value = c.UserType;
                cmd.Parameters.Add("@pActive", SqlDbType.Bit).Value = c.Active;
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

        public override bool Update(iCustomer c)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                q = @"
                    UPDATE [dbo].[customers]
                        SET [company] =  @pCompany
                            ,[firstname] = @pfname
                            ,[lastname] = @plname
                            ,[streetno] = @pstrno
                            ,[streetnosuffix] = @pstnsfx
                            ,[address1] = @padrs1
                            ,[address2] = @padrs2
                            ,[pobox] = @ppobox
                            ,[city] = @pcity
                            ,[province] = @pstate
                            ,[zip] = @pzip
                            ,[country] = @pcountry
                            ,[phone] = @pphone
                            ,[cellphone] = @pcell
                        WHERE [id] = @pid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = c.Id;
                cmd.Parameters.Add("@pCompany", SqlDbType.VarChar).Value = c.Company;
                cmd.Parameters.Add("@pfname", SqlDbType.VarChar).Value = c.FirstName;
                cmd.Parameters.Add("@plname", SqlDbType.VarChar).Value = c.LastName;
                cmd.Parameters.Add("@pstrno", SqlDbType.Int).Value = c.StreetNo;
                cmd.Parameters.Add("@pstnsfx", SqlDbType.VarChar).Value = c.StreetNoSuffix;
                cmd.Parameters.Add("@padrs1", SqlDbType.VarChar).Value = c.Address1;
                cmd.Parameters.Add("@padrs2", SqlDbType.VarChar).Value = c.Address2;
                cmd.Parameters.Add("@ppobox", SqlDbType.VarChar).Value = c.POBox;
                cmd.Parameters.Add("@pcity", SqlDbType.VarChar).Value = c.City;
                cmd.Parameters.Add("@pstate", SqlDbType.VarChar).Value = c.State;
                cmd.Parameters.Add("@pzip", SqlDbType.VarChar).Value = c.ZIP;
                cmd.Parameters.Add("@pcountry", SqlDbType.VarChar).Value = c.Country;
                cmd.Parameters.Add("@pphone", SqlDbType.VarChar).Value = c.Phone;
                cmd.Parameters.Add("@pcell", SqlDbType.VarChar).Value = c.CellPhone;
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

        public override bool UpdatePassword(int CustomerId, string password)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                q = @"UPDATE [dbo].[customers] SET
                    [password] = @Password 
                    WHERE [id] = @pCustomerId
                    AND [active] = 1";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pCustomerId", SqlDbType.Int).Value = CustomerId;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
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
                    DELETE FROM customers
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

        public override List<iCustomer> SelectAll(bool Status)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[customertype]
                          ,[email]
                          ,[password]
                          ,[company]
                          ,[firstname]
                          ,[lastname]
                          ,[streetno]
                          ,[streetnosuffix]
                          ,[address1]
                          ,[address2]
                          ,[pobox]
                          ,[city]
                          ,[province]
                          ,[zip]
                          ,[country]
                          ,[phone]
                          ,[cellphone]
                          ,[usertype]
                          ,[active]
                          ,[dateadded]
                      FROM [dbo].[customers]
                      WHERE [usertype] = 'customer' 
                      AND [active] = @Status
                      ORDER BY [lastname], [firstname]";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetCustomerCollectionFromReader(reader);
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

        public override iCustomer Login(string Email, string Password)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[customertype]
                          ,[email]
                          ,[password]
                          ,[company]
                          ,[firstname]
                          ,[lastname]
                          ,[streetno]
                          ,[streetnosuffix]
                          ,[address1]
                          ,[address2]
                          ,[pobox]
                          ,[city]
                          ,[province]
                          ,[zip]
                          ,[country]
                          ,[phone]
                          ,[cellphone]
                          ,[usertype]
                          ,[active]
                          ,[dateadded]
                        FROM [dbo].[customers]
                        WHERE LOWER([email]) = @Email
                        AND [password] = @Password
                        AND [active] = 1";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetCustomerFromReader(reader, true);
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

        public override iCustomer Select(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[customertype]
                          ,[email]
                          ,[password]
                          ,[company]
                          ,[firstname]
                          ,[lastname]
                          ,[streetno]
                          ,[streetnosuffix]
                          ,[address1]
                          ,[address2]
                          ,[pobox]
                          ,[city]
                          ,[province]
                          ,[zip]
                          ,[country]
                          ,[phone]
                          ,[cellphone]
                          ,[usertype]
                          ,[active]
                          ,[dateadded]
                        FROM [dbo].[customers]
                        WHERE [id] = @cid";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetCustomerFromReader(reader, true);
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

        public override iCustomer Select(string Email)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                          ,[customertype]
                          ,[email]
                          ,[password]
                          ,[company]
                          ,[firstname]
                          ,[lastname]
                          ,[streetno]
                          ,[streetnosuffix]
                          ,[address1]
                          ,[address2]
                          ,[pobox]
                          ,[city]
                          ,[province]
                          ,[zip]
                          ,[country]
                          ,[phone]
                          ,[cellphone]
                          ,[usertype]
                          ,[active]
                          ,[dateadded]
                        FROM [dbo].[customers]
                        WHERE LOWER([email]) = @cEmail";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cEmail", SqlDbType.VarChar).Value = Email;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetCustomerFromReader(reader, true);
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

        public override bool LoginExists(string Email)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [email]
                        FROM [dbo].[customers]
                        WHERE LOWER([email]) = @Email";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return true;
                    else
                        return false;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return false;
                }
            }
        }

        public override bool ActivateUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                q = @"UPDATE customers SET
                    active = 1 
                    WHERE id = @pid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = id;
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

        public override bool DeactivateUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                q = @"UPDATE customers SET
                    active = 0 
                    WHERE id = @pid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = id;
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
    }
}

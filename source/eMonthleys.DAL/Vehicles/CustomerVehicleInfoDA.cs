using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    class CustomerVehicleInfoDA : CustomerVehicleInfoBase
    {

        //my custom method
        public override bool  ManipulateDatbase(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@query, conn);
                try
                {
                    conn.Open();
                    Convert.ToInt32(ExecuteScalar(cmd));
                    return true;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return false;
                }
            }
        }
        public override int Insert(iCustomerVehicleInfo vi)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                SqlCommand cmd = new SqlCommand(q, conn);
                q = @"INSERT INTO [dbo].[customervehicleinfo]
                   ([seller]
                   ,[condition]
                   ,[modelyear]
                   ,[manufacturer]
                   ,[othermake]
                   ,[vehiclecategoryid]
                   ,[model]
                   ,[othermodel]
                   ,[modeltrim]
                   ,[othertrim]
                   ,[exteriorcolor]
                   ,[interiorcolor]
                   ,[transmission]
                   ,[fueltype]
                   ,[currentmileage]
                   ,[wheels]
                   ,[chromewheels]
                   ,[tires]
                   ,[wintertires]
                   ,[expires]
                   ,[comments]
                   ,[approved]
                   ,[confirmed]
                   ,[displacement]
                   ,[updated]
                    )
                VALUES
                   (@pSeller
                   ,@pCondition
                   ,@pModelYear
                   ,@pManufacturer
                   ,@pOtherMake
                   ,@pVehiclecategoryId
                   ,@pModel
                   ,@pOtherModel
                   ,@pModelTrim
                   ,@pOtherTrim
                   ,@pExteriorcolor
                   ,@pInteriorcolor
                   ,@pTransmission
                   ,@pFueltype
                   ,@pCurrentmileage
                   ,@pWheels
                   ,@pChromeWheels
                   ,@pTires
                   ,@pExtraWinterTires
                   ,@pExpires
                   ,@pComments
                   ,@pApproved
                   ,@pConfirmed
                   ,@Displacement
                   ,@Updated
                   );
                    SELECT SCOPE_IDENTITY()";

                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pSeller", SqlDbType.Int).Value = vi.Seller;
                cmd.Parameters.Add("@pCondition", SqlDbType.VarChar).Value = vi.VehicleCondition;
                cmd.Parameters.Add("@pModelYear", SqlDbType.SmallInt).Value = vi.ModelYear;
                cmd.Parameters.Add("@pManufacturer", SqlDbType.VarChar).Value = vi.Manufacturer;
                cmd.Parameters.Add("@pOtherMake", SqlDbType.VarChar).Value = vi.OtherMake;
                cmd.Parameters.Add("@pVehiclecategoryId", SqlDbType.Int).Value = vi.VehicleCategoryId;
                cmd.Parameters.Add("@pModel", SqlDbType.VarChar).Value = vi.Model;
                cmd.Parameters.Add("@pOtherModel", SqlDbType.VarChar).Value = vi.OtherModel;
                cmd.Parameters.Add("@pModelTrim", SqlDbType.Int).Value = vi.ModelTrim;
                cmd.Parameters.Add("@pOtherTrim", SqlDbType.VarChar).Value = vi.OtherTrim;
                cmd.Parameters.Add("@pExteriorcolor", SqlDbType.VarChar).Value = vi.ExteriorColor;
                cmd.Parameters.Add("@pInteriorcolor", SqlDbType.VarChar).Value = vi.InteriorColor;
                cmd.Parameters.Add("@pTransmission", SqlDbType.VarChar).Value = vi.Transmission;
                cmd.Parameters.Add("@pFueltype", SqlDbType.VarChar).Value = vi.FuelType;
                cmd.Parameters.Add("@pCurrentmileage", SqlDbType.Int).Value = vi.CurrentMileage;
                cmd.Parameters.Add("@pWheels", SqlDbType.VarChar).Value = vi.Wheels;
                cmd.Parameters.Add("@pChromeWheels", SqlDbType.Bit).Value = vi.ChromeWheels;
                cmd.Parameters.Add("@pTires", SqlDbType.VarChar).Value = vi.Tires;
                cmd.Parameters.Add("@pExtraWinterTires", SqlDbType.Bit).Value = vi.ExtraWinterTires;
                cmd.Parameters.Add("@pExpires", SqlDbType.DateTime).Value = vi.Expires;
                cmd.Parameters.Add("@pComments", SqlDbType.Text).Value = vi.Comments;
                cmd.Parameters.Add("@pApproved", SqlDbType.Bit).Value = vi.Approved;
                cmd.Parameters.Add("@pConfirmed", SqlDbType.Bit).Value = vi.Confirmed;
                cmd.Parameters.Add("@Displacement", SqlDbType.VarChar).Value = vi.Displacement;
                cmd.Parameters.Add("@Updated", SqlDbType.Date).Value = vi.Updated;
                try
                {
                    conn.Open();
                    var rc = Convert.ToInt32(ExecuteScalar(cmd));
                    return rc;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return 0;
                }
            }

        }
        public override bool Update(iCustomerVehicleInfo vi)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                q = @"UPDATE [dbo].[customervehicleinfo]
                       SET [seller] = @pSeller
                          ,[condition] = @pCondition
                          ,[modelyear] = @pModelYear
                          ,[manufacturer] = @pManufacturer
                          ,[othermake] = @pOtherMake
                          ,[vehiclecategoryid] = @pVehiclecategoryId
                          ,[model] = @pModel
                          ,[othermodel] = @pOtherModel
                          ,[modeltrim] = @pModelTrim
                          ,[othertrim] = @pOtherTrim
                          ,[exteriorcolor] = @pExteriorcolor
                          ,[interiorcolor] = @pInteriorcolor
                          ,[transmission] = @pTransmission
                          ,[fueltype] = @pFueltype
                          ,[currentmileage] = @pCurrentmileage
                          ,[wheels] = @pWheels
                          ,[chromewheels] = @pChromeWheels
                          ,[tires] = @pTires
                          ,[wintertires] = @pExtraWinterTires
                          ,[expires] = @pExpires 
                          ,[comments] = @pComments 
                          ,[displacement] = @Displacement
                          ,[updated] = @Updated
                       WHERE id = @pid";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandText = q,
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = vi.Id;
                cmd.Parameters.Add("@pSeller", SqlDbType.Int).Value = vi.Seller;
                cmd.Parameters.Add("@pCondition", SqlDbType.VarChar).Value = vi.VehicleCondition;
                cmd.Parameters.Add("@pModelYear", SqlDbType.SmallInt).Value = vi.ModelYear;
                cmd.Parameters.Add("@pManufacturer", SqlDbType.VarChar).Value = vi.Manufacturer;
                cmd.Parameters.Add("@pOtherMake", SqlDbType.VarChar).Value = vi.OtherMake;
                cmd.Parameters.Add("@pVehiclecategoryId", SqlDbType.Int).Value = vi.VehicleCategoryId;
                cmd.Parameters.Add("@pModel", SqlDbType.VarChar).Value = vi.Model;
                cmd.Parameters.Add("@pOtherModel", SqlDbType.VarChar).Value = vi.OtherModel;
                cmd.Parameters.Add("@pModelTrim", SqlDbType.Int).Value = vi.ModelTrim;
                cmd.Parameters.Add("@pOtherTrim", SqlDbType.VarChar).Value = vi.OtherTrim;
                cmd.Parameters.Add("@pExteriorcolor", SqlDbType.VarChar).Value = vi.ExteriorColor;
                cmd.Parameters.Add("@pInteriorcolor", SqlDbType.VarChar).Value = vi.InteriorColor;
                cmd.Parameters.Add("@pTransmission", SqlDbType.VarChar).Value = vi.Transmission;
                cmd.Parameters.Add("@pFueltype", SqlDbType.VarChar).Value = vi.FuelType;
                cmd.Parameters.Add("@pCurrentmileage", SqlDbType.Int).Value = vi.CurrentMileage;
                cmd.Parameters.Add("@pWheels", SqlDbType.VarChar).Value = vi.Wheels;
                cmd.Parameters.Add("@pChromeWheels", SqlDbType.Bit).Value = vi.ChromeWheels;
                cmd.Parameters.Add("@pTires", SqlDbType.VarChar).Value = vi.Tires;
                cmd.Parameters.Add("@pExtraWinterTires", SqlDbType.Bit).Value = vi.ExtraWinterTires;
                cmd.Parameters.Add("@pExpires", SqlDbType.DateTime).Value = vi.Expires;
                cmd.Parameters.Add("@pComments", SqlDbType.Text).Value = vi.Comments;
                cmd.Parameters.Add("@Displacement", SqlDbType.VarChar).Value = vi.Displacement;
                cmd.Parameters.Add("@Updated", SqlDbType.Date).Value = vi.Updated;
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
                    DELETE FROM [dbo].[customervehicleinfo]
                    WHERE [id] = @cid";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = VehicleId;

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

        public override bool Confirm(int VehicleId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[customervehicleinfo]
                    SET [confirmed] = @Confirmed
                    WHERE [id] = @VehicleId";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@VehicleId", SqlDbType.Int).Value = VehicleId;
                cmd.Parameters.Add("@Confirmed", SqlDbType.Bit).Value = true;

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

        public override bool UpdateBillingId(int VehicleId, int BillingID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[customervehicleinfo]
                    SET [billingid] = @BillId
                    WHERE [id] = @VehicleId";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillingID;
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

        public override bool DeclineItem(int VehicleId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[customervehicleinfo]
                    SET [declined] = @Declined
                    WHERE [id] = @VehicleId";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@Declined", SqlDbType.Bit).Value = true;
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

        public override bool SetApprovedStatus(int VehicleId, int FinId, bool Status)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[customervehicleinfo]
                    SET [approved] = @Status
                    WHERE [id] = @VehicleId; 
                    UPDATE [dbo].[financialdetails]
                    SET [adstatus] = @Status
                    WHERE [id] = @Fid";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@VehicleId", SqlDbType.Int).Value = VehicleId;
                cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = Status;
                cmd.Parameters.Add("@Fid", SqlDbType.Int).Value = FinId;

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

        public override bool RepostSelectedVehicle(iCustomerVehicleInfo c)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[customervehicleinfo]
                    SET [modelyear] = @ModelYear,
                        [vehiclecategoryid] = @VehicleCategory,
                        [manufacturer] = @Manufacturer,
                        [model] = @Model,
                        [modeltrim] = @ModelTrim,
                        [expires] = @vExpires,
                        [updated] = @vUpdated
                    WHERE [id] = @VehicleId";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@ModelYear", c.ModelYear);
                cmd.Parameters.AddWithValue("@VehicleCategory", c.VehicleCategoryId);
                cmd.Parameters.AddWithValue("@Manufacturer", c.Manufacturer);
                cmd.Parameters.AddWithValue("@Model", c.Model);
                cmd.Parameters.AddWithValue("@ModelTrim", c.ModelTrim);
                cmd.Parameters.AddWithValue("@VehicleId", c.Id);
                cmd.Parameters.AddWithValue("@vExpires", c.Expires);
                cmd.Parameters.AddWithValue("@vUpdated", c.Updated);

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

        public override List<iCustomerVehicleInfo> SelectAll(string Status)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;
                bool status = false;

                q = @"
                    SELECT a.[id]
                        ,a.[seller]
                        ,a.[condition]
                        ,a.[modelyear]
                        ,a.[manufacturer]
                        ,a.[othermake]
                        ,a.[vehiclecategoryid]
                        ,a.[model]
                        ,a.[othermodel]
                        ,a.[modeltrim]
                        ,a.[othertrim]
                        ,b.[model_trim]
                        ,a.[exteriorcolor]
                        ,a.[interiorcolor]
                        ,a.[transmission]
                        ,a.[fueltype]
                        ,a.[currentmileage]
                        ,a.[wheels]
                        ,a.[chromewheels]
                        ,a.[tires]
                        ,a.[wintertires]
                        ,a.[expires]
                        ,a.[comments]
                        ,a.[entrydate]
                        ,a.[approved]
                        ,a.[confirmed]
                        ,f.[status]
                        ,a.[declined]
                        ,a.[billingid]
                        ,a.[displacement]
                        ,f.[id] AS finid
                        ,f.[paymentcycle]
                        ,f.[adstatus]
                        ,a.[updated]
                    FROM [dbo].[customervehicleinfo] a
                    INNER JOIN [dbo].[VehicleModelYear] b ON a.[modeltrim] = b.[model_id]
                    INNER JOIN [dbo].[financialdetails] f ON a.[id] = f.[vehicleid]";
                string vCondition = "new";
                if (Status != "")
                {
                    q += @" WHERE a.[approved] = @Status AND a.[declined] = 0 ";
                    switch (Status)
                    {
                        case "approvedNew":
                            status = true;
                            break;
                        case "approvedUsed":
                            status = true;
                            vCondition = "used";
                            break;
                        case "pendingNew":
                            status = false;
                            break;
                        case "pendingUsed":
                            status = false;
                            vCondition = "used";
                            break;
                        case "expired":
                            status = true;
                            break;
                    }
                }
                if (Status == "expired")
                {
                    q += @"AND a.[expires] < DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0) ";
                }
                else
                {
                    q += @"AND a.[condition] = @vCondition AND a.[expires] >= DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0) ";
                }
                q += @"ORDER BY a.[id] DESC, a.[expires] ASC";
                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                if (Status != "")
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }
                if (Status != "expired")
                {
                    cmd.Parameters.AddWithValue("@vCondition", vCondition);
                }
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetVehicleInfoCollectionFromReader(reader);
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

        public override List<iCustomerVehicleInfo> SelectAllIncomplete()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT a.[id]
                        ,a.[seller]
                        ,a.[condition]
                        ,a.[modelyear]
                        ,a.[manufacturer]
                        ,a.[othermake]
                        ,a.[vehiclecategoryid]
                        ,a.[model]
                        ,a.[othermodel]
                        ,a.[modeltrim]
                        ,a.[othertrim]
                        ,b.[model_trim]
                        ,a.[exteriorcolor]
                        ,a.[interiorcolor]
                        ,a.[engine]
                        ,a.[cylinder]
                        ,a.[transmission]
                        ,a.[fueltype]
                        ,a.[currentmileage]
                        ,a.[wheels]
                        ,a.[chromewheels]
                        ,a.[tires]
                        ,a.[wintertires]
                        ,a.[expires]
                        ,a.[comments]
                        ,a.[entrydate]
                        ,a.[approved]
                        ,a.[confirmed]
                        ,f.[status]
                        ,f.[adstatus]
                        ,a.[declined]
                        ,a.[billingid]
                        ,a.[displacement]
                        ,a.[updated]
                    FROM [dbo].[customervehicleinfo] a
                    INNER JOIN [dbo].[VehicleModelYear] b ON a.[modeltrim] = b.[model_id]
                    FULL OUTER JOIN [dbo].[financialdetails] f ON a.[id] = f.[vehicleid] 
                    WHERE f.[vehicleid] IS NULL";
                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetVehicleInfoCollectionFromReader(reader);
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

        public override List<iCustomerVehicleInfo> SelectAllByCustomerId(int CustomerId, string Condition)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT a.[id]
                        ,a.[seller]
                        ,a.[condition]
                        ,a.[modelyear]
                        ,a.[manufacturer]
                        ,a.[othermake]
                        ,a.[vehiclecategoryid]
                        ,a.[model]
                        ,a.[othermodel]
                        ,a.[modeltrim]
                        ,a.[othertrim]
                        ,b.[model_trim]
                        ,a.[exteriorcolor]
                        ,a.[interiorcolor]
                        ,a.[transmission]
                        ,a.[fueltype]
                        ,a.[currentmileage]
                        ,a.[wheels]
                        ,a.[chromewheels]
                        ,a.[tires]
                        ,a.[wintertires]
                        ,a.[expires]
                        ,a.[comments]
                        ,a.[entrydate]
                        ,a.[approved]
                        ,a.[confirmed]
                        ,f.[status]
                        ,a.[declined]
                        ,a.[billingid]
                        ,a.[displacement]
                        ,f.[id] AS finid
                        ,f.[paymentcycle]
                        ,f.[adstatus]
                        ,a.[updated]
                    FROM [dbo].[customervehicleinfo] a
                    INNER JOIN [dbo].[VehicleModelYear] b ON a.[modeltrim] = b.[model_id]
                    INNER JOIN [dbo].[financialdetails] f ON a.[id] = f.[vehicleid] ";
                if (Condition == "expired")
                {
                    q += @"WHERE a.[seller] = @CustomerId AND a.[declined] = 0 AND a.[expires] < DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0) ";
                }
                else
                {
                    q += @"WHERE a.[seller] = @CustomerId AND a.[declined] = 0 AND a.[condition] = @vCondition AND a.[expires] >= DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0) ";
                }
                q += @"ORDER BY a.[id] DESC, a.[expires] ASC";
                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
                if (Condition != "expired")
                {
                    cmd.Parameters.AddWithValue("@vCondition", Condition);
                }
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return GetVehicleInfoCollectionFromReader(reader);
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

        public override iCustomerVehicleInfo Select(int VehicleId, int FinId, bool declined = false)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT a.[id]
                        ,a.[seller]
                        ,a.[condition]
                        ,a.[modelyear]
                        ,a.[manufacturer]
                        ,a.[othermake]
                        ,a.[vehiclecategoryid]
                        ,a.[model]
                        ,a.[othermodel]
                        ,a.[modeltrim]
                        ,a.[othertrim]
                        ,b.[model_trim]
                        ,a.[exteriorcolor]
                        ,a.[interiorcolor]
                        ,a.[transmission]
                        ,a.[fueltype]
                        ,a.[currentmileage]
                        ,a.[wheels]
                        ,a.[chromewheels]
                        ,a.[tires]
                        ,a.[wintertires]
                        ,a.[expires]
                        ,a.[comments]
                        ,a.[entrydate]
                        ,a.[approved]
                        ,a.[confirmed]
                        ,f.[status]
                        ,a.[declined]
                        ,a.[billingid]
                        ,a.[displacement]
                        ,f.[id] AS finid
                        ,f.[paymentcycle]
                        ,f.[adstatus]
                        ,a.[updated]
                    FROM [dbo].[customervehicleinfo] a
                    INNER JOIN [dbo].[VehicleModelYear] b ON a.[modeltrim] = b.[model_id]
                    INNER JOIN [dbo].[financialdetails] f ON a.[id] = f.[vehicleid]
                    WHERE a.[id] = @VehicleId AND a.[declined] = @Declined
                        AND f.[id] = @FinId";
                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.Add("@VehicleId", SqlDbType.Int).Value = VehicleId;
                cmd.Parameters.Add("@FinId", SqlDbType.Int).Value = FinId;
                cmd.Parameters.Add("@Declined", SqlDbType.Bit).Value = declined;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        return GetVehicleInfoFromReader(reader, true);
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

        public override List<iCustomerVehicleInfo> SelectAllDeclined()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT a.[id]
                        ,a.[seller]
                        ,a.[condition]
                        ,a.[modelyear]
                        ,a.[manufacturer]
                        ,a.[othermake]
                        ,a.[vehiclecategoryid]
                        ,a.[model]
                        ,a.[othermodel]
                        ,a.[modeltrim]
                        ,a.[othertrim]
                        ,b.[model_trim]
                        ,a.[exteriorcolor]
                        ,a.[interiorcolor]
                        ,a.[transmission]
                        ,a.[fueltype]
                        ,a.[currentmileage]
                        ,a.[wheels]
                        ,a.[chromewheels]
                        ,a.[tires]
                        ,a.[wintertires]
                        ,a.[expires]
                        ,a.[comments]
                        ,a.[entrydate]
                        ,a.[approved]
                        ,a.[confirmed]
                        ,f.[status]
                        ,a.[declined]
                        ,a.[billingid]
                        ,a.[displacement]
                        ,f.[id] AS finid
                        ,f.[paymentcycle]
                        ,f.[adstatus]
                        ,a.[updated]
                    FROM [dbo].[customervehicleinfo] a
                    INNER JOIN [dbo].[VehicleModelYear] b ON a.[modeltrim] = b.[model_id]
                    INNER JOIN [dbo].[financialdetails] f ON a.[id] = f.[vehicleid]
                    WHERE a.[declined] = 1";
                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetVehicleInfoCollectionFromReader(reader);
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

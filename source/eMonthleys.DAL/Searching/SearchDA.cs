using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public class SearchDA : SearchBase
    {
        public override List<iSearch> SelectAll(string WherePath)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [customertype]
                          ,[email]
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
                          ,[seller]
                          ,[condition]
                          ,[modelyear]
                          ,[manufacturer]
                          ,[othermake]
                          ,[model]
                          ,[othermodel]
                          ,[model_trim]
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
                          ,[comments]
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
                          ,[financeinfo]
                          ,[status]
                          ,[declined]
                          ,[displacement]
                          ,[finid]
                          ,[vehcategory]
                          ,[adstatus]
                      FROM [dbo].[searchview]
                      WHERE [active] = 1 AND [approved] = 1 AND [adstatus] = 1 AND [confirmed] = 1 AND [declined] = 0 AND [expires] >= DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0) ";
                q += WherePath + @"ORDER BY CONVERT(DATETIME,[expires],101) DESC, [vehicleid] DESC, [finid] DESC";

                //cmd.Parameters.Add("@WherePath", SqlDbType.VarChar).Value = WherePath;
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(q, conn)
                    {
                        CommandType = CommandType.Text
                    };
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetSearchCollectionFromReader(reader);

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

        public override List<iSearch> SelectByVehicleId(int VehicleId, int FdId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [customertype]
                          ,[email]
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
                          ,[seller]
                          ,[condition]
                          ,[modelyear]
                          ,[manufacturer]
                          ,[othermake]
                          ,[model]
                          ,[othermodel]
                          ,[model_trim]
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
                          ,[comments]
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
                          ,[financeinfo]
                          ,[status]
                          ,[declined]
                          ,[displacement]
                          ,[finid]
                          ,[vehcategory]
                          ,[adstatus]
                      FROM [dbo].[searchview]
                      WHERE [vehicleid] = @VehicleId AND [active] = 1 AND [approved] = 1 AND [declined] = 0 
                            AND [expires] >= DATEADD(day, DATEDIFF(day, 0, GETDATE()), 0) AND [confirmed] = 1";

                SqlCommand cmd = new SqlCommand(q, conn)
                {
                    CommandType = CommandType.Text
                };
                cmd.Parameters.AddWithValue("@VehicleId", VehicleId);
                cmd.Parameters.AddWithValue("@FdId", FdId);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetSearchCollectionFromReader(reader);

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

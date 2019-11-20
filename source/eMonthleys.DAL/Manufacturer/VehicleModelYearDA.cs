using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public class VehicleModelYearDA : VehicleModelYearBase
    {
        public override bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    DELETE FROM [dbo].[VehicleModelYear]
                    WHERE [id] = @cid";

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

        public override List<iVehicleModelYear> SelectAll()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [model_id]
                          ,[model_make_id]
                          ,[model_name]
                          ,[model_trim]
                          ,[model_year]
                          ,[model_body_style]
                          ,[model_engine_position]
                          ,[model_engine_cc]
                          ,[model_engine_num_cyl]
                          ,[model_engine_type]
                          ,[mode_engine_valves_per_cyl]
                          ,[model_engine_power_ps]
                          ,[model_engine_power_rpm]
                          ,[model_engine_torque_nm]
                          ,[model_engine_torque_rpm]
                          ,[model_engine_bore_mm]
                          ,[model_engine_stroke_mm]
                          ,[model_engine_compression]
                          ,[model_engine_fuel]
                          ,[model_top_speed_kph]
                          ,[model_0_to_100_kph]
                          ,[model_drive]
                          ,[model_transmission_type]
                          ,[model_seats]
                          ,[model_doors]
                          ,[model_weight_kg]
                          ,[model_length_mm]
                          ,[model_width_mm]
                          ,[model_height_mm]
                          ,[model_wheelbase]
                          ,[model_lkm_hwy]
                          ,[model_lkm_mixed]
                          ,[model_lkm_city]
                          ,[model_fuel_cap_l]
                          ,[model_sold_in_us]
                          ,[model_co2]
                          ,[model_make_display]
                      FROM [emonthleysdb].[dbo].[VehicleModelYear]
                      WHERE [model_sold_in_us] = 1";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                    if (reader.HasRows)
                        return GetVehicleModelYearCollectionFromReader(reader);
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

        public override iVehicleModelYear Select(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [model_id]
                          ,[model_make_id]
                          ,[model_name]
                          ,[model_trim]
                          ,[model_year]
                          ,[model_body_style]
                          ,[model_engine_position]
                          ,[model_engine_cc]
                          ,[model_engine_num_cyl]
                          ,[model_engine_type]
                          ,[mode_engine_valves_per_cyl]
                          ,[model_engine_power_ps]
                          ,[model_engine_power_rpm]
                          ,[model_engine_torque_nm]
                          ,[model_engine_torque_rpm]
                          ,[model_engine_bore_mm]
                          ,[model_engine_stroke_mm]
                          ,[model_engine_compression]
                          ,[model_engine_fuel]
                          ,[model_top_speed_kph]
                          ,[model_0_to_100_kph]
                          ,[model_drive]
                          ,[model_transmission_type]
                          ,[model_seats]
                          ,[model_doors]
                          ,[model_weight_kg]
                          ,[model_length_mm]
                          ,[model_width_mm]
                          ,[model_height_mm]
                          ,[model_wheelbase]
                          ,[model_lkm_hwy]
                          ,[model_lkm_mixed]
                          ,[model_lkm_city]
                          ,[model_fuel_cap_l]
                          ,[model_sold_in_us]
                          ,[model_co2]
                          ,[model_make_display]
                      FROM [dbo].[VehicleModelYear]
                      WHERE [model_sold_in_us] = 1 AND [model_id] = @cid";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetVehicleModelYearFromReader(reader, true);
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

using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class VehicleModelYearBase : DataAccess
    {
        static private VehicleModelYearBase _instance = null;

        static public VehicleModelYearBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (VehicleModelYearBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.VehicleModelYearDA"));
                return _instance;
            }
        }

        public VehicleModelYearBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract bool Delete(int id);
        public abstract List<iVehicleModelYear> SelectAll();
        public abstract iVehicleModelYear Select(int id);

        protected virtual iVehicleModelYear GetVehicleModelYearFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iVehicleModelYear VehicleModelYear = new iVehicleModelYear(
                Convert.ToInt32(reader["model_id"]),
                Helpers.ConvertNullToBlank(reader["model_make_id"]),
                Helpers.ConvertNullToBlank(reader["model_name"]),
                Helpers.ConvertNullToBlank(reader["model_trim"]),
                Convert.ToInt16(reader["model_year"]),
                Helpers.ConvertNullToBlank(reader["model_body_style"]),
                Helpers.ConvertNullToBlank(reader["model_engine_position"]),
                Helpers.ConvertNullIntToZero(reader["model_engine_cc"]),
                Helpers.ConvertNullIntToZero(reader["model_engine_num_cyl"]),
                Helpers.ConvertNullToBlank(reader["model_engine_type"]),
                Helpers.ConvertNullToBlank(reader["mode_engine_valves_per_cyl"]),
                Helpers.ConvertNullToBlank(reader["model_engine_power_ps"]),
                Helpers.ConvertNullToBlank(reader["model_engine_power_rpm"]),
                Helpers.ConvertNullToBlank(reader["model_engine_torque_nm"]),
                Helpers.ConvertNullToBlank(reader["model_engine_torque_rpm"]),
                Helpers.ConvertNullToBlank(reader["model_engine_bore_mm"]),
                Helpers.ConvertNullToBlank(reader["model_engine_stroke_mm"]),
                Helpers.ConvertNullToBlank(reader["model_engine_compression"]),
                Helpers.ConvertNullToBlank(reader["model_engine_fuel"]),
                Helpers.ConvertNullToBlank(reader["model_top_speed_kph"]),
                Helpers.ConvertNullToBlank(reader["model_0_to_100_kph"]),
                Helpers.ConvertNullToBlank(reader["model_drive"]),
                Helpers.ConvertNullToBlank(reader["model_transmission_type"]),
                Helpers.ConvertNullToBlank(reader["model_seats"]),
                Helpers.ConvertNullToBlank(reader["model_doors"]),
                Helpers.ConvertNullIntToZero(reader["model_weight_kg"]),
                Helpers.ConvertNullIntToZero(reader["model_length_mm"]),
                Helpers.ConvertNullIntToZero(reader["model_width_mm"]),
                Helpers.ConvertNullIntToZero(reader["model_height_mm"]),
                Helpers.ConvertNullIntToZero(reader["model_wheelbase"]),
                Helpers.ConvertNullToBlank(reader["model_lkm_hwy"]),
                Helpers.ConvertNullToBlank(reader["model_lkm_mixed"]),
                Helpers.ConvertNullToBlank(reader["model_lkm_city"]),
                Helpers.ConvertNullToBlank(reader["model_fuel_cap_l"]),
                Helpers.ConvertNullIntToZero(reader["model_sold_in_us"]),
                Helpers.ConvertNullToBlank(reader["model_co2"]),
                Helpers.ConvertNullToBlank(reader["model_make_display"])
                );
            return VehicleModelYear;
        }

        protected virtual List<iVehicleModelYear> GetVehicleModelYearCollectionFromReader(IDataReader reader)
        {
            List<iVehicleModelYear> VehicleModelYears = new List<iVehicleModelYear>();
            while (reader.Read())
                VehicleModelYears.Add(GetVehicleModelYearFromReader(reader, false));
            return VehicleModelYears;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class CustomerVehicleInfoBase : DataAccess
    {
        static private CustomerVehicleInfoBase _instance = null;

        static public CustomerVehicleInfoBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (CustomerVehicleInfoBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.CustomerVehicleInfoDA"));
                return _instance;
            }
        }

        public CustomerVehicleInfoBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract bool ManipulateDatbase(string query);

        public abstract int Insert(iCustomerVehicleInfo c);
        public abstract bool Update(iCustomerVehicleInfo c);
        public abstract bool Delete(int VehicleId);
        public abstract bool Confirm(int VehicleId);
        public abstract bool UpdateBillingId(int VehicleId, int BillingID);
        public abstract bool DeclineItem(int VehicleId);
        public abstract bool SetApprovedStatus(int VehicleId, int FinId, bool Status);
        public abstract bool RepostSelectedVehicle(iCustomerVehicleInfo c);
        public abstract List<iCustomerVehicleInfo> SelectAll(string Status);
        public abstract List<iCustomerVehicleInfo> SelectAllIncomplete();
        public abstract List<iCustomerVehicleInfo> SelectAllByCustomerId(int CustomerId, string Condition);
        public abstract iCustomerVehicleInfo Select(int id, int finid, bool declined);
        public abstract List<iCustomerVehicleInfo> SelectAllDeclined();

        protected virtual iCustomerVehicleInfo GetVehicleInfoFromReader(SqlDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iCustomerVehicleInfo vehicleinfo = new iCustomerVehicleInfo(
                Convert.ToInt32(reader["id"]),
                Convert.ToInt32(reader["seller"]),
                reader["condition"].ToString(),
                Convert.ToInt16(reader["modelyear"]),
                reader["manufacturer"].ToString(),
                Helpers.ConvertNullToBlank(reader["othermake"].ToString()),
                Convert.ToInt16(reader["vehiclecategoryid"]),
                reader["model"].ToString(),
                Helpers.ConvertNullToBlank(reader["othermodel"].ToString()),
                Convert.ToInt32(reader["modeltrim"]),
                Helpers.ConvertNullToBlank(reader["othertrim"]),
                reader["model_trim"].ToString(),
                reader["exteriorcolor"].ToString(),
                reader["interiorcolor"].ToString(),
                reader["transmission"].ToString(),
                reader["fueltype"].ToString(),
                Convert.ToInt32(reader["currentmileage"]),
                reader["wheels"].ToString(),
                Convert.ToBoolean(reader["chromewheels"]),
                reader["tires"].ToString(),
                Convert.ToBoolean(reader["wintertires"]),
                Convert.ToDateTime(reader["expires"]),
                Helpers.ConvertNullToBlank(reader["comments"]),
                Convert.ToDateTime(reader["entrydate"]),
                Convert.ToBoolean(reader["approved"]),
                Convert.ToBoolean(reader["confirmed"]),
                Helpers.ConvertDbNullToBlank(reader["status"]),
                Convert.ToBoolean(reader["declined"]),
                Helpers.ConvertNullInt64ToZero(reader["billingid"]),
                Helpers.ConvertDbNullToBlank(reader["displacement"]),
                Convert.ToInt32(reader["finid"]),
                Helpers.ConvertNullToBlank(reader["paymentcycle"].ToString()),
                Convert.ToDateTime(reader["updated"]),
                Convert.ToBoolean(reader["adstatus"])
                );

            return vehicleinfo;
        }

        protected virtual List<iCustomerVehicleInfo> GetVehicleInfoCollectionFromReader(SqlDataReader reader)
        {
            List<iCustomerVehicleInfo> vehicleinfos = new List<iCustomerVehicleInfo>();
            while (reader.Read())
            {
                vehicleinfos.Add(GetVehicleInfoFromReader(reader, false));
            }
            reader.Close();

            return vehicleinfos;
        }
    }

}

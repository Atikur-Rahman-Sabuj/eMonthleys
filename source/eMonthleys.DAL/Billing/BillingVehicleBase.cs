using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class BillingVehicleBase : DataAccess
    {
        static private BillingVehicleBase _instance = null;

        static public BillingVehicleBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (BillingVehicleBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.BillingVehilceDA"));
                return _instance;
            }
        }
        
        public BillingVehicleBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract int Insert(iBillingVehicle c);
        public abstract bool UpdateRemaining(iBillingVehicle c);
        public abstract bool Delete(int id);
        public abstract bool PaidInFull(iBillingVehicle v);
        public abstract List<iBillingVehicle> SelectAll();
        public abstract iBillingVehicle Select(int id);
        public abstract iBillingVehicle SelectIfRemaining(int CutomerId);

        protected virtual iBillingVehicle GetVehicleBillingFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iBillingVehicle billing = new iBillingVehicle(
                Convert.ToInt32(reader["id"]),
                Convert.ToInt32(reader["customerid"]),
                Convert.ToInt16(reader["adsbought"]),
                Convert.ToInt16(reader["adsremaining"]),
                Convert.ToDouble(reader["payment"]),
                Helpers.ConvertNullToBlank(reader["promocode"]),
                Helpers.ConvertNullToBlank(reader["paypalid"]),
                Helpers.ConvertNullToBlank(reader["ppstate"]),
                Helpers.CheckNullableDate(reader["create_time"])
                );
            return billing;
        }

        protected virtual List<iBillingVehicle> GetVehicleBillingCollectionFromReader(IDataReader reader)
        {
            List<iBillingVehicle> billing = new List<iBillingVehicle>();
            while (reader.Read())
                billing.Add(GetVehicleBillingFromReader(reader, false));
            return billing;
        }
    }
}

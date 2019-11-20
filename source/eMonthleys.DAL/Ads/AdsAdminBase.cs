using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class AdsAdminBase : DataAccess
    {
        static private AdsAdminBase _instance = null;

        static public AdsAdminBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (AdsAdminBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.AdsAdminDA"));
                return _instance;
            }
        }

        public AdsAdminBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract List<iAdsAdmin> SelectAllByStatus(bool Status);
        public abstract List<iAdsAdmin> SelectAllDeclined();
        public abstract bool DeclineAd(int Id);

        protected virtual iAdsAdmin GetCustomerAdsFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iAdsAdmin customerAd = new iAdsAdmin(
                Convert.ToInt32(reader["id"]),
                Convert.ToInt32(reader["customerid"]),
                reader["company"].ToString(),
                reader["firstname"].ToString(),
                reader["lastname"].ToString(),
                reader["adtype"].ToString(),
                reader["addetails"].ToString(),
                reader["img1"].ToString(),
                reader["img2"].ToString(),
                reader["img3"].ToString(),
                reader["img4"].ToString(),
                Convert.ToDateTime(reader["expires"]),
                Convert.ToBoolean(reader["paid"]),
                Convert.ToBoolean(reader["active"]),
                Convert.ToBoolean(reader["confirmed"]),
                reader["paypalid"].ToString(),
                reader["ppstate"].ToString(),
                Convert.ToDateTime(reader["create_time"]),
                Convert.ToBoolean(reader["declined"])
                );
            return customerAd;
        }

        protected virtual List<iAdsAdmin> GetCustomerAdsCollectionFromReader(IDataReader reader)
        {
            List<iAdsAdmin> customerAds = new List<iAdsAdmin>();
            while (reader.Read())
                customerAds.Add(GetCustomerAdsFromReader(reader, false));
            return customerAds;
        }
    }
}

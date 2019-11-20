using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class BillingAdsBase : DataAccess
    {
         static private BillingAdsBase _instance = null;

        static public BillingAdsBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (BillingAdsBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.BillingAdsDA"));
                return _instance;
            }
        }
        
        public BillingAdsBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract bool Insert(iBillingAds c);
        public abstract bool Update(iBillingAds c);
        public abstract bool Delete(int id);
        public abstract List<iBillingAds> SelectAll();
        public abstract iBillingAds Select(int id);

        protected virtual iBillingAds GetAdBillingFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iBillingAds billing = new iBillingAds(
                Convert.ToInt32(reader["id"]),
                Convert.ToInt32(reader["customerid"]),
                Convert.ToInt32(reader["adid"]),
                Convert.ToDouble(reader["payment"]),
                reader["paypalid"].ToString(),
                reader["ppstate"].ToString(),
                Helpers.CheckNullableDate(reader["create_time"])
                );
            return billing;
        }

        protected virtual List<iBillingAds> GetAdBillingCollectionFromReader(IDataReader reader)
        {
            List<iBillingAds> billing = new List<iBillingAds>();
            while (reader.Read())
                billing.Add(GetAdBillingFromReader(reader, false));
            return billing;
        }
   }
}

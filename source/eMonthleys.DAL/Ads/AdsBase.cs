using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;


namespace eMonthleys.DAL
{
    public abstract  class AdsBase : DataAccess
    {
        static private AdsBase _instance = null;

        static public AdsBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (AdsBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.AdsDA"));
                return _instance;
            }
        }
        
        public AdsBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract int Insert(iCustomerAds c);
        public abstract bool Update(iCustomerAds c);
        public abstract bool Delete(int id);
        public abstract bool PaidInFull(int id);
        public abstract bool ConfirmAd(int id);
        public abstract bool SetActiveStatus(int AdId, bool Status);
        public abstract List<iCustomerAds> SelectAllByType(string AdType);
        public abstract List<iCustomerAds> Select6SmallAdsRandom();
        public abstract List<iCustomerAds> SelectAllByStatus(bool Status);
        public abstract List<iCustomerAds> SelectAllByCustomerId(int CustomerId);
        public abstract iCustomerAds Select(int AdId);
        public abstract iCustomerAds SelectRandomLarge();
        public abstract iCustomerAds SelectRandomSmall();
        public abstract bool DeclineAd(int Id);

        protected virtual iCustomerAds GetCustomerAdsFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iCustomerAds customerAd = new iCustomerAds(
                Convert.ToInt32(reader["id"]),
                Convert.ToInt32(reader["customerid"]),
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
                reader["url"].ToString(),
                Convert.ToBoolean(reader["declined"])
                );
            return customerAd;
        }

        protected virtual List<iCustomerAds> GetCustomerAdsCollectionFromReader(IDataReader reader)
        {
            List<iCustomerAds> customerAds = new List<iCustomerAds>();
            while (reader.Read())
                customerAds.Add(GetCustomerAdsFromReader(reader, false));
            return customerAds;
        }
    }
}

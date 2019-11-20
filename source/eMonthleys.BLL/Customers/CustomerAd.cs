using System;
using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class CustomerAd : BaseBLL
    {
        # region Constructors
        // zu finden im Interface

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string AdType { get; set; }
        public string AdDetails { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public DateTime Expires { get; set; }
        public bool Paid { get; set; }
        public bool Active { get; set; }
        public bool Confirmed { get; set; }
        public string URL { get; set; }
        public bool Declined { get; set; }

        public CustomerAd() { }

        public CustomerAd(int id, int customerid,
            string adtype, string addetails, string img1, string img2, string img3, string img4,
            DateTime expires, bool paid, bool active, bool confirmed, string url, bool decline)
        {
            Id = id;
            CustomerId = customerid;
            AdType = adtype;
            AdDetails = addetails;
            Img1 = img1;
            Img2 = img2;
            Img3 = img3;
            Img4 = img4;
            Expires = expires;
            Paid = paid;
            Active = active;
            Confirmed = confirmed;
            URL = url;
            Declined = decline;
        }
        # endregion

        # region Private Methods

        private static CustomerAd GetCustomerAdsValuesFromiCustomerAds(iCustomerAds record)
        {
            if (record == null)
                return null;
            else
            {
                return new CustomerAd(
                    record.Id,
                    record.CustomerId,
                    record.AdType,
                    record.AdDetails,
                    record.Img1,
                    record.Img2,
                    record.Img3,
                    record.Img4,
                    record.Expires,
                    record.Paid,
                    record.Active,
                    record.Confirmed,
                    record.URL,
                    record.Declined
                    );
            }
        }

        private static List<CustomerAd> GetCustomerAdsListFromiCustomerAds(List<iCustomerAds> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<CustomerAd> c = new List<CustomerAd>();
                foreach (iCustomerAds record in recordset)
                    c.Add(GetCustomerAdsValuesFromiCustomerAds(record));
                return c;
            }
        }
        # endregion

        # region Public Methods
        public static List<CustomerAd> GetAllCustomersAdsByType(string AdType)
        {
            List<CustomerAd> customerads = null;
            customerads = GetCustomerAdsListFromiCustomerAds(AdsBase.Instance.SelectAllByType(AdType));
            return customerads;
        }

        public static List<CustomerAd> Get6SmallAdsRandom()
        {
            List<CustomerAd> customerads = null;
            customerads = GetCustomerAdsListFromiCustomerAds(AdsBase.Instance.Select6SmallAdsRandom());
            return customerads;
        }

        public static CustomerAd GetRandomLargeCustomersAd()
        {
            CustomerAd ad = GetCustomerAdsValuesFromiCustomerAds(AdsBase.Instance.SelectRandomLarge());
            return ad;
        }

        public static List<CustomerAd> GetAllCustomersAdsByCustomer(int CustomerId)
        {
            List<CustomerAd> customerads = null;
            customerads = GetCustomerAdsListFromiCustomerAds(AdsBase.Instance.SelectAllByCustomerId(CustomerId));
            return customerads;
        }

        public static CustomerAd GetRandomSmallCustomersAd()
        {
            CustomerAd ca = GetCustomerAdsValuesFromiCustomerAds(AdsBase.Instance.SelectRandomSmall());
            return ca;
        }

        public static List<CustomerAd> GetAllCustomersAdsByStatus(string Status)
        {
            bool status = false;
            switch (Status)
            {
                case "off":
                    status = false;
                    break;
                case "on":
                    status = true;
                    break;
            }
            List<CustomerAd> customerads = null;
            customerads = GetCustomerAdsListFromiCustomerAds(AdsBase.Instance.SelectAllByStatus(status));
            return customerads;
        }


        public static CustomerAd GetCustomerAdDetails(int id)
        {
            CustomerAd c = GetCustomerAdsValuesFromiCustomerAds(AdsBase.Instance.Select(id));
            return c;
        }

        public static int InsertNewAd(CustomerAd ad)
        {
            iCustomerAds c = new iCustomerAds(
              0,
              ad.CustomerId,
              ad.AdType,
              ad.AdDetails,
              ad.Img1,
              ad.Img2,
              ad.Img3,
              ad.Img4,
              ad.Expires,
              ad.Paid,
              ad.Active,
              ad.Confirmed,
              ad.URL,
              ad.Declined
              );
            return AdsBase.Instance.Insert(c);
        }

        public static bool UpdateAd(CustomerAd ad)
        {
            iCustomerAds c = new iCustomerAds(
              ad.Id,
              ad.CustomerId,
              ad.AdType,
              ad.AdDetails,
              ad.Img1,
              ad.Img2,
              ad.Img3,
              ad.Img4,
              ad.Expires,
              ad.Paid,
              ad.Active,
              ad.Confirmed,
              ad.URL,
              ad.Declined
              );
            return AdsBase.Instance.Update(c);
        }

        public static bool SetActiveStatus(int AdId, bool Status)
        {
            return AdsBase.Instance.SetActiveStatus(AdId, Status);
        }

        public static bool Delete(int AdId)
        {
            return AdsBase.Instance.Delete(AdId);
        }

        public static bool PaidInFull(int AdId)
        {
            return AdsBase.Instance.PaidInFull(AdId);
        }

        public static bool Confirm(int AdId)
        {
            return AdsBase.Instance.ConfirmAd(AdId);
        }

        public static bool DeclineAd(int Id)
        {
            return AdsBase.Instance.DeclineAd(Id);
        }
        # endregion

    }
}

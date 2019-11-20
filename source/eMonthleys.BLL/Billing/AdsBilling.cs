using System;
using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class AdsBilling
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AdId { get; set; }
        public double Payment { get; set; }
        public string PayPalId { get; set; }
        public string PayPalState { get; set; }
        public DateTime ?CreateTime { get; set; }

        public AdsBilling() { }

        public AdsBilling(int id, int customer, int adid, double cost, string ppid, string ppst, DateTime ?added)
        {
            Id = id;
            CustomerId = customer;
            AdId = adid;
            Payment = cost;
            PayPalId = ppid;
            PayPalState = ppst;
            CreateTime = added;
        }

        # region Private Methods
        private static AdsBilling GetAdsBillingValuesFromiBillingAds(iBillingAds record)
        {
            if (record == null)
                return null;
            else
            {
                return new AdsBilling(
                    record.Id,
                    record.CustomerId,
                    record.AdId,
                    record.Payment,
                    record.PayPalId,
                    record.PayPalState,
                    record.CreateTime
                    );
            }
        }

        private static List<AdsBilling> GetAdsBillingListFromiBillingAds(List<iBillingAds> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<AdsBilling> bv = new List<AdsBilling>();
                foreach (iBillingAds record in recordset)
                    bv.Add(GetAdsBillingValuesFromiBillingAds(record));
                return bv;
            }
        }
        # endregion

        # region Public Methods
        public static List<AdsBilling> GetAllAdsBilling()
        {
            List<AdsBilling> AdsBilling = null;
            AdsBilling = GetAdsBillingListFromiBillingAds(BillingAdsBase.Instance.SelectAll());
            return AdsBilling;
        }

        public static AdsBilling GetAdsBillingDetails(int id)
        {
            AdsBilling bv = null;
            bv = GetAdsBillingValuesFromiBillingAds(BillingAdsBase.Instance.Select(id));
            return bv;
        }

        public static bool InsertNewBilling(AdsBilling ad)
        {
            iBillingAds bv = new iBillingAds(
              0,
              ad.CustomerId,
              ad.AdId,
              ad.Payment,
              ad.PayPalId,
              ad.PayPalState,
              ad.CreateTime
              );
            return BillingAdsBase.Instance.Insert(bv);
        }

        public static bool UpdateBilling(AdsBilling ad)
        {
            iBillingAds bv = new iBillingAds(
              ad.Id,
              ad.CustomerId,
              ad.AdId,
              ad.Payment,
              ad.PayPalId,
              ad.PayPalState,
              ad.CreateTime
              );
            return BillingAdsBase.Instance.Update(bv);
        }
        # endregion
    }
}

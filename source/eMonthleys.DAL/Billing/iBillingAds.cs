using System;

namespace eMonthleys.DAL
{
    public class iBillingAds
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AdId { get; set; }
        public double Payment { get; set; }
        public string PayPalId { get; set; }
        public string PayPalState { get; set; }
        public DateTime ?CreateTime { get; set; }

        public iBillingAds() { }

        public iBillingAds(int id, int customer, int adid, double cost, string ppid, string ppst, DateTime ?added)
        {
            Id = id;
            CustomerId = customer;
            AdId = adid;
            Payment = cost;
            PayPalId = ppid;
            PayPalState = ppst;
            CreateTime = added;
        }
    }
}

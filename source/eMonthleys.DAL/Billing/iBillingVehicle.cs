using System;

namespace eMonthleys.DAL
{
    public class iBillingVehicle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AdsBought { get; set; }
        public int AdsRemaining { get; set; }
        public double Payment { get; set; }
        public string PromoCode { get; set; }
        public string PayPalId { get; set; }
        public string PayPalState { get; set; }
        public DateTime? CreateTime { get; set; }

        public iBillingVehicle() { }

        public iBillingVehicle(int id, int customer, int bought, int remaining, double cost, string promo, 
            string ppid, string ppstate, DateTime? paid)
        {
            Id = id;
            CustomerId = customer;
            AdsBought = bought;
            AdsRemaining = remaining;
            Payment = cost;
            PromoCode = promo;
            PayPalId = ppid;
            PayPalState = ppstate;
            CreateTime = paid;
        }
    }
}

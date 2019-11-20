using System;
using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class VehiclesBilling
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

        public VehiclesBilling() { }

        public VehiclesBilling(int id, int customer, int bought, int remaining, double cost, string promo,
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

        # region Private Methods
        private static VehiclesBilling GetVehiclesBillingValuesFromiBillingVehicle(iBillingVehicle record)
        {
            if (record == null)
                return null;
            else
            {
                return new VehiclesBilling(
                    record.Id,
                    record.CustomerId,
                    record.AdsBought,
                    record.AdsRemaining,
                    record.Payment,
                    record.PromoCode,
                    record.PayPalId,
                    record.PayPalState,
                    record.CreateTime
                    );
            }
        }

        private static List<VehiclesBilling> GetVehiclesBillingListFromiBillingVehicle(List<iBillingVehicle> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<VehiclesBilling> bv = new List<VehiclesBilling>();
                foreach (iBillingVehicle record in recordset)
                    bv.Add(GetVehiclesBillingValuesFromiBillingVehicle(record));
                return bv;
            }
        }
        # endregion

        # region Public Methods
        public static List<VehiclesBilling> GetAllVehiclesBilling()
        {
            List<VehiclesBilling> VehiclesBilling = null;
            VehiclesBilling = GetVehiclesBillingListFromiBillingVehicle(BillingVehicleBase.Instance.SelectAll());
            return VehiclesBilling;
        }

        public static VehiclesBilling GetVehiclesBillingDetails(int id)
        {
            VehiclesBilling bv = null;
            bv = GetVehiclesBillingValuesFromiBillingVehicle(BillingVehicleBase.Instance.Select(id));
            return bv;
        }

        public static VehiclesBilling RemainingVehicleAdsBillingDetails(int CustomerId)
        {
            VehiclesBilling bv = null;
            bv = GetVehiclesBillingValuesFromiBillingVehicle(BillingVehicleBase.Instance.SelectIfRemaining(CustomerId));
            return bv;
        }

        public static int InsertNewBilling(VehiclesBilling billing)
        {
            iBillingVehicle bv = new iBillingVehicle(
              0,
              billing.CustomerId,
              billing.AdsBought,
              billing.AdsRemaining,
              billing.Payment,
              billing.PromoCode,
              billing.PayPalId,
              billing.PayPalState,
              billing.CreateTime
              );
            return BillingVehicleBase.Instance.Insert(bv);
        }

        public static bool UpdateBilling(VehiclesBilling billing)
        {
            iBillingVehicle bv = new iBillingVehicle(
                billing.Id,
                billing.CustomerId,
                billing.AdsBought,
                billing.AdsRemaining,
                billing.Payment,
                billing.PromoCode,
                billing.PayPalId,
                billing.PayPalState,
                billing.CreateTime
                );
            return BillingVehicleBase.Instance.UpdateRemaining(bv);
        }

        public static bool PaidInFull(VehiclesBilling Billing)
        {
            iBillingVehicle bv = new iBillingVehicle(
                Billing.Id,
                Billing.CustomerId,
                Billing.AdsBought,
                Billing.AdsRemaining,
                Billing.Payment,
                Billing.PromoCode,
                Billing.PayPalId,
                Billing.PayPalState,
                Billing.CreateTime
                );
            return BillingVehicleBase.Instance.PaidInFull(bv);
        }
        # endregion
    }
}

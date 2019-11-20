using System;

namespace eMonthleys.DAL
{
    public class iFinanceDetails
    {
        public int Id { get; set; }
        public string LeaseOrFinance { get; set; }
        public int VehicleId { get; set; }
        public string PaymentCycle { get; set; }
        public double PaymentWithTax { get; set; }
        public double OriginalDown { get; set; }
        public double SecurityDeposit { get; set; }
        public string PoEndOfLease { get; set; }
        public int KmAllowance { get; set; }
        public double ExcessKmCharge { get; set; }
        public int LeaseTerm { get; set; }
        public DateTime? LeaseExpiry { get; set; }
        public double BuyBack { get; set; }
        public double Balloon { get; set; }
        public double PurchasePrice { get; set; }
        public string Summary { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public bool AdStatus { get; set; }

        public iFinanceDetails() { }

        public iFinanceDetails(int id,
            string leaseorfinance,
            int vehicleid,
            string paymentcycle,
            double paymentwithtax,
            double originaldown,
            double securitydeposit,
            string poendoflease,
            int kmallowance,
            double excesskmcharge,
            int originalleaseterm,
            DateTime? leaseexpiry,
            double buyback,
            double balloon,
            double purchaseprice,
            string summary,
            string comments,
            string status,
            bool adstatus
            )
        {
            Id = id;
            LeaseOrFinance = leaseorfinance;
            VehicleId = vehicleid;
            PaymentCycle = paymentcycle;
            PaymentWithTax = paymentwithtax;
            OriginalDown = originaldown;
            SecurityDeposit = securitydeposit;
            PoEndOfLease = poendoflease;
            KmAllowance = kmallowance;
            ExcessKmCharge = excesskmcharge;
            LeaseTerm = originalleaseterm;
            LeaseExpiry = leaseexpiry;
            BuyBack = buyback;
            Balloon = balloon;
            PurchasePrice = purchaseprice;
            Summary = summary;
            Comments = comments;
            Status = status;
            AdStatus = adstatus;
        }

    }
}

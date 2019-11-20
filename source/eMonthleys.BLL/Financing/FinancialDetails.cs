using System;
using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class Financial : BaseBLL
    {
        # region Constructors
        // zu finden im Interface
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

        public Financial() { }

        public Financial(int id,
            string leaseorfinance,
            int vehicleid,
            string paycycle,
            double paymentwithtax,
            double originaldown,
            double securitydeposit,
            string poendoflease,
            int kmallowance,
            double excesskmcharge,
            int leaseterm,
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
            PaymentCycle = paycycle;
            PaymentWithTax = paymentwithtax;
            OriginalDown = originaldown;
            SecurityDeposit = securitydeposit;
            PoEndOfLease = poendoflease;
            KmAllowance = kmallowance;
            ExcessKmCharge = excesskmcharge;
            LeaseTerm = leaseterm;
            LeaseExpiry = leaseexpiry;
            BuyBack = buyback;
            Balloon = balloon;
            PurchasePrice = purchaseprice;
            Summary = summary;
            Comments = comments;
            Status = status;
            AdStatus = adstatus;
        }
        # endregion

        # region Private Methods
        private static Financial GetFinancialDetailsValuesFromiFinanceDetails(iFinanceDetails record)
        {
            if (record == null)
                return null;
            else
            {
                return new Financial(
                    record.Id,
                    record.LeaseOrFinance,
                    record.VehicleId,
                    record.PaymentCycle,
                    record.PaymentWithTax,
                    record.OriginalDown,
                    record.SecurityDeposit,
                    record.PoEndOfLease,
                    record.KmAllowance,
                    record.ExcessKmCharge,
                    record.LeaseTerm,
                    record.LeaseExpiry,
                    record.BuyBack,
                    record.Balloon,
                    record.PurchasePrice,
                    record.Summary,
                    record.Comments,
                    record.Status,
                    record.AdStatus
                    );
            }
        }

        private static List<Financial> GetFinancialDetailsListFromiFinanceDetails(List<iFinanceDetails> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<Financial> c = new List<Financial>();
                foreach (iFinanceDetails record in recordset)
                    c.Add(GetFinancialDetailsValuesFromiFinanceDetails(record));
                return c;
            }
        }
        # endregion

        # region Public Methods
        public static List<Financial> GetAllFinancialDetails()
        {
            List<Financial> LeaseTakeoverDetails = null;
            LeaseTakeoverDetails = GetFinancialDetailsListFromiFinanceDetails(FinanceBase.Instance.SelectAll());
            return LeaseTakeoverDetails;
        }

        public static Financial GetFinancialDetails(int id)
        {
            Financial c = null;
            c = GetFinancialDetailsValuesFromiFinanceDetails(FinanceBase.Instance.Select(id));
            return c;
        }

        public static Financial GetFinancialDetailsByVehicleId(int VehicleId, int FinId)
        {
            Financial fd = null;
            fd = GetFinancialDetailsValuesFromiFinanceDetails(FinanceBase.Instance.SelectByVehicleId(VehicleId, FinId));
            return fd;
        }

        public static int InsertNewFinancialDetails(Financial fin)
        {
            iFinanceDetails c = new iFinanceDetails(
                0,
                fin.LeaseOrFinance,
                fin.VehicleId,
                fin.PaymentCycle,
                fin.PaymentWithTax,
                fin.OriginalDown,
                fin.SecurityDeposit,
                fin.PoEndOfLease,
                fin.KmAllowance,
                fin.ExcessKmCharge,
                fin.LeaseTerm,
                fin.LeaseExpiry,
                fin.BuyBack,
                fin.Balloon,
                fin.PurchasePrice,
                fin.Summary,
                fin.Comments,
                fin.Status,
                fin.AdStatus
                );
            return FinanceBase.Instance.Insert(c);
        }

        public static bool UpdateFinancialDetails(Financial fin)
        {
            iFinanceDetails f = new iFinanceDetails(
                fin.Id,
                fin.LeaseOrFinance,
                fin.VehicleId,
                fin.PaymentCycle,
                fin.PaymentWithTax,
                fin.OriginalDown,
                fin.SecurityDeposit,
                fin.PoEndOfLease,
                fin.KmAllowance,
                fin.ExcessKmCharge,
                fin.LeaseTerm,
                fin.LeaseExpiry,
                fin.BuyBack,
                fin.Balloon,
                fin.PurchasePrice,
                fin.Summary,
                fin.Comments,
                fin.Status,
                fin.AdStatus
                );
            return FinanceBase.Instance.Update(f);
        }

        public static bool UpdatePrice(Financial fin)
        {
            iFinanceDetails f = new iFinanceDetails(
                fin.Id,
                fin.LeaseOrFinance,
                fin.VehicleId,
                fin.PaymentCycle,
                fin.PaymentWithTax,
                fin.OriginalDown,
                fin.SecurityDeposit,
                fin.PoEndOfLease,
                fin.KmAllowance,
                fin.ExcessKmCharge,
                fin.LeaseTerm,
                fin.LeaseExpiry,
                fin.BuyBack,
                fin.Balloon,
                fin.PurchasePrice,
                fin.Summary,
                fin.Comments,
                fin.Status,
                fin.AdStatus
                );
            return FinanceBase.Instance.UpdatePrice(f);
        }

        public static bool DeleteRecord(int Id, int VehicleId)
        {
            return FinanceBase.Instance.Delete(Id, VehicleId);
        }

        public static bool ChangeStatus(int Id, int VehicleId, string Status)
        {
            return FinanceBase.Instance.ChangeStatus(Id, VehicleId, Status);
        }

        public static bool ChangeAdStatus(int Id, int VehicleId, bool AdStatus)
        {
            return FinanceBase.Instance.UpdateAdStatus(Id, VehicleId, AdStatus);
        }

        public static List<string> CheckPayCycle(int VehicleId)
        {
            return FinanceBase.Instance.CheckPayCycle(VehicleId);
        }
        # endregion

    }
}

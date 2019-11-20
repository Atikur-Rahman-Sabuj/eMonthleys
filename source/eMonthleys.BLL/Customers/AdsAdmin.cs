using System;
using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class AdsAdmin : BaseBLL
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
        public string PayPalId { get; set; }
        public string PayPalState { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool Declined { get; set; }

        public AdsAdmin() { }

        public AdsAdmin(int id, int customerid, string company, string firstname, string lastname,
            string adtype, string addetails, string img1, string img2, string img3, string img4,
            DateTime expires, bool paid, bool active, bool confirmed, string paypalid, string ppstate, DateTime added, bool decline)
        {
            Id = id;
            CustomerId = customerid;
            Company = company;
            FirstName = firstname;
            LastName = lastname;
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
            PayPalId = paypalid;
            PayPalState = ppstate;
            PaymentDate = added;
            Declined = decline;
        }

        # region Private Methods

        private static AdsAdmin GetAdsAdminValuesFromiAdsAdmin(iAdsAdmin record)
        {
            if (record == null)
                return null;
            else
            {
                return new AdsAdmin(
                    record.Id,
                    record.CustomerId,
                    record.Company,
                    record.FirstName,
                    record.LastName,
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
                    record.PayPalId,
                    record.PayPalState,
                    record.PaymentDate,
                    record.Declined
                    );
            }
        }

        private static List<AdsAdmin> GetAdsAdminListFromiAdsAdmin(List<iAdsAdmin> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<AdsAdmin> c = new List<AdsAdmin>();
                foreach (iAdsAdmin record in recordset)
                    c.Add(GetAdsAdminValuesFromiAdsAdmin(record));
                return c;
            }
        }
        # endregion

        #region Public Methods

        public static List<AdsAdmin> GetAllCustomersAdsByStatus(string Status)
        {
            bool status = false;
            List<AdsAdmin> ads = new List<AdsAdmin>();
            switch (Status)
            {
                case "off":
                    status = false;
                    ads = GetAdsAdminListFromiAdsAdmin(AdsAdminBase.Instance.SelectAllByStatus(status));
                    break;
                case "on":
                    status = true;
                    ads = GetAdsAdminListFromiAdsAdmin(AdsAdminBase.Instance.SelectAllByStatus(status));
                    break;
                case "declined":
                    ads = GetAdsAdminListFromiAdsAdmin(AdsAdminBase.Instance.SelectAllDeclined());
                    break;
            }
            
            return ads;
        }

        #endregion
    }
}

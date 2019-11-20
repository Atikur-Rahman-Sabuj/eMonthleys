using System;


namespace eMonthleys.DAL
{
    public class iSearch
    {
        //customers
        public string CustomerType { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StreetNo { get; set; }
        public string StreetNoSuffix { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string POBox { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }

        //customervehicleinfo
        public int Seller { get; set; }
        public string VehicleCondition { get; set; }
        public Int16 ModelYear { get; set; }
        public string Manufacturer { get; set; }
        public string MakeOther { get; set; }
        public int VehicleCategory { get; set; }
        public string Model { get; set; }
        public string ModelOther { get; set; }
        public string ModelTrim { get; set; }
        public string OtherTrim { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string Transmission { get; set; }
        public string FuelType { get; set; }
        public int CurrentMileage { get; set; }
        public string Wheels { get; set; }
        public bool ChromeWheels { get; set; }
        public string Tires { get; set; }
        public bool ExtraWinterTires { get; set; }
        public string Comments { get; set; }
        public string Displacement { get; set; }

        //financial details
        public string LeaseOrFinance { get; set; }
        public int VehicleId { get; set; }
        public string PaymentCycle { get; set; }
        public double PaymentWithTax { get; set; }
        public double OriginalDown { get; set; }
        public double SecurityDeposit { get; set; }
        public double PoEndOfLease { get; set; }
        public int KmAllowance { get; set; }
        public double ExcessKmCharge { get; set; }
        public int LeaseTerm { get; set; }
        public DateTime? LeaseExpiry { get; set; }
        public double BuyBack { get; set; }
        public double Balloon { get; set; }
        public double PurchasePrice { get; set; }
        public string Summary { get; set; }
        public string FinanceInfo { get; set; }
        public string Status { get; set; }
        public int finid { get; set; }
        public bool AdStatus { get; set; }

        public iSearch() { }

        public iSearch(
            //customers
            string customertype,
            string email,
            string company,
            string firstname,
            string lastname,
            int streetno,
            string streetNosuffix,
            string address1,
            string address2,
            string pobox,
            string city,
            string state,
            string zip,
            string country,
            string phone,
            string cellphone,

            //customervehicleinfo
            int seller,
            string vehiclecondition,
            Int16 modelyear,
            string manufacturer,
            string makeother,
            int vehiclecategory,
            string model,
            string modelother,
            string modeltrim,
            string othertrim,
            string exteriorcolor,
            string interiorcolor,
            string transmission,
            string fueltype,
            int currentmileage,
            string wheels,
            bool chromewheels,
            string tires,
            bool extrawintertires,
            string comments,
            string displacement,

            //leasetakeoverdetails
            string leaseorfinance,
            int vehicleid,
            string paymentcycle,
            double paymentwithtax,
            double originaldown,
            double securitydeposit,
            double poendoflease,
            int kmallowance,
            double excesskmcharge,
            int leaseterm,
            DateTime? leaseexpiry,
            double buyback,
            double balloon,
            double purchaseprice,
            string summary,
            string financeinfo,
            string status,
            int finId,
            bool adstatus
            )
        {
            //customers
            CustomerType = customertype;
            Email = email;
            Company = company;
            FirstName = firstname;
            LastName = lastname;
            StreetNo = streetno;
            StreetNoSuffix = streetNosuffix;
            Address1 = address1;
            Address2 = address2;
            POBox = pobox;
            City = city;
            State = state;
            ZIP = zip;
            Country = country;
            Phone = phone;
            CellPhone = cellphone;

            //customervehicleinfo
            Seller = seller;
            VehicleCondition = vehiclecondition;
            ModelYear = modelyear;
            Manufacturer = manufacturer;
            MakeOther = makeother;
            VehicleCategory = vehiclecategory;
            Model = model;
            ModelOther = modelother;
            ModelTrim = modeltrim;
            OtherTrim = othertrim;
            ExteriorColor = exteriorcolor;
            InteriorColor = interiorcolor;
            Transmission = transmission;
            CurrentMileage = currentmileage;
            Wheels = wheels;
            ChromeWheels = chromewheels;
            Tires = tires;
            ExtraWinterTires = extrawintertires;
            FuelType = fueltype;
            Comments = comments;
            Displacement = displacement;

            //leasetakeoverdetails
            LeaseOrFinance = leaseorfinance;
            VehicleId = vehicleid;
            PaymentCycle = paymentcycle;
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
            FinanceInfo = financeinfo;
            Status = status;
            finid = finId;
            AdStatus = adstatus;
        }
    }
}

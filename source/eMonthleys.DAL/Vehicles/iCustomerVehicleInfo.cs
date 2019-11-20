using System;

namespace eMonthleys.DAL
{
    public class iCustomerVehicleInfo
    {
        public int Id {get; set; }
        public int Seller { get; set; }
        public string VehicleCondition { get; set; }
        public Int16 ModelYear {get; set; }
        public string Manufacturer {get; set; }
        public string OtherMake { get; set; }
        public int VehicleCategoryId {get; set; }
        public string  Model {get; set; }
        public string OtherModel { get; set; }
        public int ModelTrim { get; set; }
        public string OtherTrim { get; set; }
        public string ModelTrimValue { get; set; }
        public string ExteriorColor {get; set; }
        public string InteriorColor {get; set; }
        public string Transmission {get; set; }
        public string FuelType { get; set; }
        public int CurrentMileage {get; set; }
        public string Wheels { get; set; }
        public bool ChromeWheels { get; set; }
        public string Tires { get; set; }
        public bool ExtraWinterTires { get; set; }
        public DateTime Expires {get; set; }
        public string Comments { get; set; }
        public DateTime Entrydate { get; set; }
        public bool Approved { get; set; }
        public bool Confirmed { get; set; }
        public string Status { get; set; }
        public bool Declined { get; set; }
        public int BillingId { get; set; }
        public string Displacement { get; set; }
        public int FinId { get; set; }
        public string PaymentCycle { get; set; }
        public DateTime Updated { get; set; }
        public bool AdStatus { get; set; }

        public iCustomerVehicleInfo() { }

        public iCustomerVehicleInfo(int id, int seller, string vehicleCondition, short modelYear, string manufacturer, string otherMake, 
            int vehicleCategoryId, string model, string otherModel, int modelTrim, string otherTrim, string modelTrimValue, string exteriorColor, 
            string interiorColor, string transmission, string fuelType, int currentMileage, string wheels, bool chromeWheels, string tires, 
            bool extraWinterTires, DateTime expires, string comments, DateTime entrydate, bool approved, bool confirmed, string status, bool declined, 
            int billingId, string displacement, int finId, string paymentCycle, DateTime updated, bool adStatus)
        {
            Id = id;
            Seller = seller;
            VehicleCondition = vehicleCondition;
            ModelYear = modelYear;
            Manufacturer = manufacturer;
            OtherMake = otherMake;
            VehicleCategoryId = vehicleCategoryId;
            Model = model;
            OtherModel = otherModel;
            ModelTrim = modelTrim;
            OtherTrim = otherTrim;
            ModelTrimValue = modelTrimValue;
            ExteriorColor = exteriorColor;
            InteriorColor = interiorColor;
            Transmission = transmission;
            FuelType = fuelType;
            CurrentMileage = currentMileage;
            Wheels = wheels;
            ChromeWheels = chromeWheels;
            Tires = tires;
            ExtraWinterTires = extraWinterTires;
            Expires = expires;
            Comments = comments;
            Entrydate = entrydate;
            Approved = approved;
            Confirmed = confirmed;
            Status = status;
            Declined = declined;
            BillingId = billingId;
            Displacement = displacement;
            FinId = finId;
            PaymentCycle = paymentCycle;
            Updated = updated;
            AdStatus = adStatus;
        }
    }
}

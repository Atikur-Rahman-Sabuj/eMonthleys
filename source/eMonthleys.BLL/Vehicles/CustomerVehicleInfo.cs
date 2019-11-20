using System;
using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    [Serializable]
    public class CustomerVehicleInfo : BaseBLL
    {
        # region Constructors
        // zu finden im Interface
        public int Id { get; set; }
        public int Seller { get; set; }
        public string VehicleCondition { get; set; }
        public Int16 ModelYear { get; set; }
        public string Manufacturer { get; set; }
        public string OtherMake { get; set; }
        public int VehicleCategoryId { get; set; }
        public string Model { get; set; }
        public string OtherModel { get; set; }
        public int ModelTrim { get; set; }
        public string OtherTrim { get; set; }
        public string ModelTrimValue { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public string Transmission { get; set; }
        public string FuelType { get; set; }
        public int CurrentMileage { get; set; }
        public string Wheels { get; set; }
        public bool ChromeWheels { get; set; }
        public string Tires { get; set; }
        public bool ExtraWinterTires { get; set; }
        public DateTime Expires { get; set; }
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

        public CustomerVehicleInfo() { }

        public CustomerVehicleInfo(int id, int seller, string vehicleCondition, short modelYear, string manufacturer, string otherMake, int vehicleCategoryId, 
            string model, string otherModel, int modelTrim, string otherTrim, string modelTrimValue, string exteriorColor, string interiorColor, string transmission, 
            string fuelType, int currentMileage, string wheels, bool chromeWheels, string tires, bool extraWinterTires, DateTime expires, string comments, 
            DateTime entrydate, bool approved, bool confirmed, string status, bool declined, int billingId, string displacement, int finId, string paymentCycle, 
            DateTime updated, bool adStatus)
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

        #endregion

        #region Private Methods

        private static CustomerVehicleInfo GetCustomerVehicleInfoValuesFromiCustomerVehicleInfo(iCustomerVehicleInfo record)
        {
            if (record == null)
                return null;
            else
            {
                return new CustomerVehicleInfo(
                    record.Id,
                    record.Seller,
                    record.VehicleCondition,
                    record.ModelYear,
                    record.Manufacturer,
                    record.OtherMake,
                    record.VehicleCategoryId,
                    record.Model,
                    record.OtherModel,
                    record.ModelTrim,
                    record.OtherTrim,
                    record.ModelTrimValue,
                    record.ExteriorColor,
                    record.InteriorColor,
                    record.Transmission,
                    record.FuelType,
                    record.CurrentMileage,
                    record.Wheels,
                    record.ChromeWheels,
                    record.Tires,
                    record.ExtraWinterTires,
                    record.Expires,
                    record.Comments,
                    record.Entrydate,
                    record.Approved,
                    record.Confirmed,
                    record.Status,
                    record.Declined,
                    record.BillingId,
                    record.Displacement,
                    record.FinId,
                    record.PaymentCycle,
                    record.Updated,
                    record.AdStatus
                    );
            }
        }

        private static List<CustomerVehicleInfo> GetCustomerVehicleInfoListFromiCustomerVehicleInfo(List<iCustomerVehicleInfo> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<CustomerVehicleInfo> c = new List<CustomerVehicleInfo>();
                foreach (iCustomerVehicleInfo record in recordset)
                    c.Add(GetCustomerVehicleInfoValuesFromiCustomerVehicleInfo(record));
                return c;
            }
        }

        #endregion

        #region public methods

        public static List<CustomerVehicleInfo> GetAllCustomerVehicleInfo(string Status)
        {
            string status;
            if (Status.Length > 0)            
                status = Status;            
            else
            {
                status = "";
            }   

            List<CustomerVehicleInfo> c = null;
            if(Status == "declined")
                c = GetCustomerVehicleInfoListFromiCustomerVehicleInfo(CustomerVehicleInfoBase.Instance.SelectAllDeclined());
            else
                c = GetCustomerVehicleInfoListFromiCustomerVehicleInfo(CustomerVehicleInfoBase.Instance.SelectAll(status));
            return c;
        }

        public static List<CustomerVehicleInfo> GetAllIncomplete()
        {
            List<CustomerVehicleInfo> c = GetCustomerVehicleInfoListFromiCustomerVehicleInfo(CustomerVehicleInfoBase.Instance.SelectAllIncomplete());
            return c;
        }

        public static List<CustomerVehicleInfo> GetAllCustomerVehicleInfoByCustomerId(string CustomerId, string Condition)
        {
            List<CustomerVehicleInfo> c =  GetCustomerVehicleInfoListFromiCustomerVehicleInfo(CustomerVehicleInfoBase.Instance.SelectAllByCustomerId(Convert.ToInt32(CustomerId), Condition));
            return c;
        }

        public static CustomerVehicleInfo GetCustomerVehicleInfoDetails(int id, int finid, bool declined)
        {
            CustomerVehicleInfo c = null;
            c = GetCustomerVehicleInfoValuesFromiCustomerVehicleInfo(CustomerVehicleInfoBase.Instance.Select(id, finid, declined));
            return c;
        }

        public static int InsertNewCustomerVehicleInfo(CustomerVehicleInfo vi)
        {
            iCustomerVehicleInfo iVi = new iCustomerVehicleInfo(
                vi.Id,
                vi.Seller,
                vi.VehicleCondition,
                vi.ModelYear,
                vi.Manufacturer,
                vi.OtherMake,
                vi.VehicleCategoryId,
                vi.Model,
                vi.OtherModel,
                vi.ModelTrim,
                vi.OtherTrim,
                vi.ModelTrimValue,
                vi.ExteriorColor,
                vi.InteriorColor,
                vi.Transmission,
                vi.FuelType,
                vi.CurrentMileage,
                vi.Wheels,
                vi.ChromeWheels,
                vi.Tires,
                vi.ExtraWinterTires,
                vi.Expires,
                vi.Comments,
                vi.Entrydate,
                vi.Approved,
                vi.Confirmed,
                vi.Status,
                vi.Declined,
                vi.BillingId,
                vi.Displacement,
                vi.FinId,
                vi.PaymentCycle,
                vi.Updated,
                vi.AdStatus
                );
            return CustomerVehicleInfoBase.Instance.Insert(iVi);
        }

        public static bool UpdateCustomerVehicleInfo(CustomerVehicleInfo vi)
        {
            iCustomerVehicleInfo iVi = new iCustomerVehicleInfo(
                vi.Id,
                vi.Seller,
                vi.VehicleCondition,
                vi.ModelYear,
                vi.Manufacturer,
                vi.OtherMake,
                vi.VehicleCategoryId,
                vi.Model,
                vi.OtherModel,
                vi.ModelTrim,
                vi.OtherTrim,
                vi.ModelTrimValue,
                vi.ExteriorColor,
                vi.InteriorColor,
                vi.Transmission,
                vi.FuelType,
                vi.CurrentMileage,
                vi.Wheels,
                vi.ChromeWheels,
                vi.Tires,
                vi.ExtraWinterTires,
                vi.Expires,
                vi.Comments,
                vi.Entrydate,
                vi.Approved,
                vi.Confirmed,
                vi.Status,
                vi.Declined,
                vi.BillingId,
                vi.Displacement,
                vi.FinId,
                vi.PaymentCycle,
                vi.Updated,
                vi.AdStatus
                );
            return CustomerVehicleInfoBase.Instance.Update(iVi);
        }

        public static bool Delete(int Id)
        {
            return CustomerVehicleInfoBase.Instance.Delete(Id);
        }

        public static bool SetApprovedStatus(int VehicleId, int FinId, bool Status)
        {
            return CustomerVehicleInfoBase.Instance.SetApprovedStatus(VehicleId, FinId, Status);
        }

        public static bool RepostSelectedVehicle(CustomerVehicleInfo vi)
        {
            iCustomerVehicleInfo iVi = new iCustomerVehicleInfo(
                vi.Id,
                vi.Seller,
                vi.VehicleCondition,
                vi.ModelYear,
                vi.Manufacturer,
                vi.OtherMake,
                vi.VehicleCategoryId,
                vi.Model,
                vi.OtherModel,
                vi.ModelTrim,
                vi.OtherTrim,
                vi.ModelTrimValue,
                vi.ExteriorColor,
                vi.InteriorColor,
                vi.Transmission,
                vi.FuelType,
                vi.CurrentMileage,
                vi.Wheels,
                vi.ChromeWheels,
                vi.Tires,
                vi.ExtraWinterTires,
                vi.Expires,
                vi.Comments,
                vi.Entrydate,
                vi.Approved,
                vi.Confirmed,
                vi.Status,
                vi.Declined,
                vi.BillingId,
                vi.Displacement,
                vi.FinId,
                vi.PaymentCycle,
                vi.Updated,
                vi.AdStatus
                );
            return CustomerVehicleInfoBase.Instance.RepostSelectedVehicle(iVi);
        }

        public static bool Confirm(int VehicleId)
        {
            return CustomerVehicleInfoBase.Instance.Confirm(VehicleId);
        }

        public static bool UpdateBillingId(int VehicleId, int BillingId)
        {
            return CustomerVehicleInfoBase.Instance.UpdateBillingId(VehicleId, BillingId);
        }

        public static bool DeclineItem(int VehicleId)
        {
            return CustomerVehicleInfoBase.Instance.DeclineItem(VehicleId);
        }

        #endregion
    }
}

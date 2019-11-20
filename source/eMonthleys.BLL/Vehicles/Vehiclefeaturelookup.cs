using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class Vehiclefeaturelookup : BaseBLL
    {
        # region Constructors
        // zu finden im Interface
        public int Id { get; set; }
        public string Feature { get; set; }
        public string FeatureType { get; set; }
        public string ListType { get; set; }

        public Vehiclefeaturelookup() { }

        public Vehiclefeaturelookup(int id, string feature, string featuretype, string listtype)
        {
            Id = id;
            Feature = feature;
            FeatureType = featuretype;
            ListType = listtype;
        }
        # endregion

        #region Private Methods

        private static Vehiclefeaturelookup GetVehiclefeaturelookupValuesFromiVehiclefeaturelookup(iVehiclefeaturelookup record)
        {
            if (record == null)
                return null;
            else
            {
                return new Vehiclefeaturelookup(
                    record.Id,
                    record.Feature,                   
                    record. FeatureType,    
                    record.ListType
                    );
            }
        }

        private static List<Vehiclefeaturelookup> GetVehiclefeaturelookupListFromiVehiclefeaturelookup(List<iVehiclefeaturelookup> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<Vehiclefeaturelookup> c = new List<Vehiclefeaturelookup>();
                foreach (iVehiclefeaturelookup record in recordset)
                    c.Add(GetVehiclefeaturelookupValuesFromiVehiclefeaturelookup(record));
                return c;
            }
        }

        #endregion

        #region public methods

        public static List<Vehiclefeaturelookup> GetAllVehiclefeaturelookup()
        {
            List<Vehiclefeaturelookup> c = GetVehiclefeaturelookupListFromiVehiclefeaturelookup(VehiclefeaturelookupBase.Instance.SelectAll());
            return c;
        }

        public static Vehiclefeaturelookup GetVehiclefeaturelookupDetails(int id)
        {
            Vehiclefeaturelookup c = GetVehiclefeaturelookupValuesFromiVehiclefeaturelookup(VehiclefeaturelookupBase.Instance.Select(id));
            return c;
        }

        public static bool InsertNewVehiclefeaturelookup(
            string feature, string featuretype, string listtype)
        {
            iVehiclefeaturelookup c = new iVehiclefeaturelookup(
                0,
                feature,
                featuretype,
                listtype
                );
            return VehiclefeaturelookupBase.Instance.Insert(c);
        }

        public static bool UpdateVehiclefeaturelookup(
            int id,
            string feature,
            string featuretype,
            string listtype
            )
        {
            iVehiclefeaturelookup c = new iVehiclefeaturelookup(
                id,
                feature, 
                featuretype,
                listtype
                );
            return VehiclefeaturelookupBase.Instance.Update(c);
        }
        #endregion
    }
    public class FeatureLookup : BaseBLL
    {
        public int Id { get; set; }
        public string Feature{ get; set; }

        public FeatureLookup() { }

        public FeatureLookup(int id, string feature)
        {
            Id = id;
            Feature = feature;
        }

        private static FeatureLookup GetFeatureLookupValuesFromiFeatureLookup(iFeatureLookup record)
        {
            if (record == null)
                return null;
            else
            {
                return new FeatureLookup(
                    record.Id,
                    record.Feature
                    );
            }
        }

        private static List<FeatureLookup> GetFeatureLookupListFromiFeatureLookup(List<iFeatureLookup> recordset, string ListType)
        {
            if (recordset == null)
                return null;
            else
            {
                List<FeatureLookup> f = new List<FeatureLookup>();
                foreach (iFeatureLookup record in recordset)
                    f.Add(GetFeatureLookupValuesFromiFeatureLookup(record));
                if (ListType == "ddl")
                {
                    FeatureLookup fl = new FeatureLookup(0, "Please select");
                    f.Insert(0, fl);
                }
                return f;
            }
        }

        public static List<FeatureLookup> GetAllFeatureLookup(string FeatureType, string Listtype)
        {
            List<FeatureLookup> FeatrueLookups = null;
            FeatrueLookups = GetFeatureLookupListFromiFeatureLookup(FeatureLookupBase.Instance.SelectAll(FeatureType, Listtype), Listtype);
            return FeatrueLookups;
        }    
    }
 
}

using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class FeaturesOfVehicle
    {
        public int VehicleId { get; set; }
        public string Feature { get; set; }
        public string FeatureType { get; set; }


        public FeaturesOfVehicle() { }

        public FeaturesOfVehicle(int id, string feature, string featuretype)
        {
            VehicleId = id;
            Feature = feature;
            FeatureType = featuretype;
        }

        #region Private Methods

        private static FeaturesOfVehicle GetFeaturesOfVehicleValuesFromiFeaturesByVehicle(iFeaturesByVehicle record)
        {
            if (record == null)
                return null;
            else
            {
                return new FeaturesOfVehicle(
                    record.VehicleId,
                    record.Feature,
                    record.FeatureType
                    );
            }
        }

        private static List<FeaturesOfVehicle> GetFeaturesOfVehicleListFromiFeaturesByVehicle(List<iFeaturesByVehicle> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<FeaturesOfVehicle> c = new List<FeaturesOfVehicle>();
                foreach (iFeaturesByVehicle record in recordset)
                    c.Add(GetFeaturesOfVehicleValuesFromiFeaturesByVehicle(record));
                return c;
            }
        }

        #endregion

        public static List<FeaturesOfVehicle> GetAllFeaturesOfVehicle(int VehicleId)
        {
            List<FeaturesOfVehicle> vf = null;
            vf = GetFeaturesOfVehicleListFromiFeaturesByVehicle(FeaturesByVehicleBase.Instance.SelectAll(VehicleId));
            return vf;
        }
    }
}

using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class VehicleFeatures : BaseBLL
    {
        # region Constructors
        // zu finden im Interface
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }


        public VehicleFeatures() { }

        public VehicleFeatures(int id, int vehicleid,
        int featureid)
        {
            Id = id;
            VehicleId = vehicleid;
            FeatureId = featureid;
        }
        # endregion

        #region Private Methods

        private static VehicleFeatures GetVehicleFeaturesValuesFromiVehicleFeatures(iVehicleFeatures record)
        {
            if (record == null)
                return null;
            else
            {
                return new VehicleFeatures(
                    record.Id,
                    record.VehicleId,
                    record.FeatureId
                    );
            }
        }

        private static List<VehicleFeatures> GetVehicleFeaturesListFromiVehicleFeatures(List<iVehicleFeatures> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<VehicleFeatures> c = new List<VehicleFeatures>();
                foreach (iVehicleFeatures record in recordset)
                    c.Add(GetVehicleFeaturesValuesFromiVehicleFeatures(record));
                return c;
            }
        }

        private static iVehicleFeatures Feature2iFeature(VehicleFeatures vf, int VehicleId)
        {
            iVehicleFeatures ivf = new iVehicleFeatures(
                vf.Id,
                VehicleId,
                vf.FeatureId
                );
            return ivf;
        }
        private static List<iVehicleFeatures> Features2iFeatures(List<VehicleFeatures> vf, int VehicleId)
        {
            List<iVehicleFeatures> ivf = new List<iVehicleFeatures>();
            foreach(VehicleFeatures f in vf)
            {
                ivf.Add(Feature2iFeature(f, VehicleId));
            }
            return ivf;
        }

        #endregion

        #region public methods

        public static List<VehicleFeatures> GetAllVehicleFeatures()
        {
            List<VehicleFeatures> c = null;
            c = GetVehicleFeaturesListFromiVehicleFeatures(VehicleFeaturesBase.Instance.SelectAll());
            return c;
        }

        public static VehicleFeatures GetVehicleFeaturesDetails(int id)
        {
            VehicleFeatures c = null;
            c = GetVehicleFeaturesValuesFromiVehicleFeatures(VehicleFeaturesBase.Instance.Select(id));
            return c;
        }

        public static List<VehicleFeatures> SelectAllByVehicleId(int VehicleId)
        {
            List<VehicleFeatures> c = null;
            c = GetVehicleFeaturesListFromiVehicleFeatures(VehicleFeaturesBase.Instance.SelectAllByVehicleId(VehicleId));
            return c;
        }

        public static bool InsertNewVehicleFeatures(List<VehicleFeatures> Features, int VehicleId)
        {
            List<iVehicleFeatures> flist = Features2iFeatures(Features, VehicleId);
            return VehicleFeaturesBase.Instance.Insert(flist);
        }

        public static bool UpdateVehicleFeatures(
            int id,
            int vehicleid,
            int featureid
            )
        {
            iVehicleFeatures c = new iVehicleFeatures(
                id,
                vehicleid,
                featureid
                );
            return VehicleFeaturesBase.Instance.Update(c);
        }

        public static bool DeleteVehicleFeatures(int VehilceId)
        {
            return VehicleFeaturesBase.Instance.Delete(VehilceId);
        }

        #endregion
    }
}

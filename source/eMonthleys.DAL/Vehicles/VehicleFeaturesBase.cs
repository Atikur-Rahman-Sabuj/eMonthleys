using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class VehicleFeaturesBase : DataAccess
    {
        static private VehicleFeaturesBase _instance = null;

        static public VehicleFeaturesBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (VehicleFeaturesBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.VehicleFeaturesDA"));
                return _instance;
            }
        }

        public VehicleFeaturesBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract bool Insert(List<iVehicleFeatures> Features);
        public abstract bool Update(iVehicleFeatures Feature);
        public abstract bool Delete(int id);
        public abstract List<iVehicleFeatures> SelectAll();
        public abstract iVehicleFeatures Select(int VehicleId);
        public abstract List<iVehicleFeatures> SelectAllByVehicleId(int VehicleId);

        protected virtual iVehicleFeatures GetVehicleFeaturesFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iVehicleFeatures vehiclefeature = new iVehicleFeatures(
                Convert.ToInt32(reader["id"]),
                Convert.ToInt32(reader["vehicleid"]),
                Convert.ToInt16(reader["featureid"])
                );
            return vehiclefeature;
        }

        protected virtual List<iVehicleFeatures> GetVehicleFeaturesCollectionFromReader(IDataReader reader)
        {
            List<iVehicleFeatures> vehiclefeatures = new List<iVehicleFeatures>();
            while (reader.Read())
                vehiclefeatures.Add(GetVehicleFeaturesFromReader(reader, false));
            return vehiclefeatures;
        }
    }

}

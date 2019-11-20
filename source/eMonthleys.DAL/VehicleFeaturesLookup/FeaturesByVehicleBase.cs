using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class FeaturesByVehicleBase : DataAccess
    {
        static private FeaturesByVehicleBase _instance = null;

        static public FeaturesByVehicleBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (FeaturesByVehicleBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.FeaturesByVehicleDA"));
                return _instance;
            }
        }

        public FeaturesByVehicleBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract List<iFeaturesByVehicle> SelectAll(int VehicleId);

        protected virtual iFeaturesByVehicle GetFeaturesByVehicleFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iFeaturesByVehicle vehiclefeature = new iFeaturesByVehicle(
                Convert.ToInt32(reader["id"]),
                reader["feature"].ToString(),
                reader["featuretype"].ToString()
                );
            return vehiclefeature;
        }

        protected virtual List<iFeaturesByVehicle> GetFeaturesByVehicleCollectionFromReader(IDataReader reader)
        {
            List<iFeaturesByVehicle> vehiclefeatures = new List<iFeaturesByVehicle>();
            while (reader.Read())
                vehiclefeatures.Add(GetFeaturesByVehicleFromReader(reader, false));
            return vehiclefeatures;
        }
    }
}

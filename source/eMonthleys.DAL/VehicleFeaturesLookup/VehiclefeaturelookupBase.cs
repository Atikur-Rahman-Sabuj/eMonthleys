using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{   /// <summary>
    ///Insert, Update, Delete, SelectAll, Select(int id) lookup base on Vehiclefeature
    /// </summary>
    public abstract class VehiclefeaturelookupBase : DataAccess
    {
        static private VehiclefeaturelookupBase _instance = null;

        static public VehiclefeaturelookupBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (VehiclefeaturelookupBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.VehiclefeaturelookupDA"));
                return _instance;
            }
        }

        public VehiclefeaturelookupBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract bool Insert(iVehiclefeaturelookup c);
        public abstract bool Update(iVehiclefeaturelookup c);
        public abstract bool Delete(int id);
        public abstract List<iVehiclefeaturelookup> SelectAll();
        public abstract iVehiclefeaturelookup Select(int id);

        protected virtual iVehiclefeaturelookup GetVehiclefeaturelookupFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iVehiclefeaturelookup vehiclefeaturelookup = new iVehiclefeaturelookup(
                Convert.ToInt32(reader["id"]),
                reader["feature"].ToString(),
                reader["featuretype"].ToString(),
                reader["listtype"].ToString()
                );
            return vehiclefeaturelookup;
        }

        protected virtual List<iVehiclefeaturelookup> GetVehiclefeaturelookupCollectionFromReader(IDataReader reader)
        {
            List<iVehiclefeaturelookup> vehiclefeaturelookups = new List<iVehiclefeaturelookup>();
            while (reader.Read())
                vehiclefeaturelookups.Add(GetVehiclefeaturelookupFromReader(reader, false));
            return vehiclefeaturelookups;
        }
    }

    /// <summary>
    ///Alle features lookup base on Vehiclefeature, SelectAll(string FeatureType, string Listtype) 
    /// </summary>
    public abstract class FeatureLookupBase : DataAccess
    {
        static private FeatureLookupBase _instance = null;

        static public FeatureLookupBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (FeatureLookupBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.FeatureLookupDA"));
                return _instance;
            }
        }

        public FeatureLookupBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract List<iFeatureLookup> SelectAll(string FeatureType, string Listtype);

        protected virtual iFeatureLookup GetFeatureLookupFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iFeatureLookup Trims = new iFeatureLookup(
                Convert.ToInt16(reader["id"]),
                reader["feature"].ToString()
                );
            return Trims;
        }
        protected virtual List<iFeatureLookup> GetFeatureLookupCollectionFromReader(IDataReader reader)
        {
            List<iFeatureLookup> Features = new List<iFeatureLookup>();
            while (reader.Read())
                Features.Add(GetFeatureLookupFromReader(reader, false));
            return Features;
        }
    }
}

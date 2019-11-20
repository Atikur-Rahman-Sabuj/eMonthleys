using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class VehiclecategoriesBase : DataAccess
    {
        static private VehiclecategoriesBase _instance = null;

        static public VehiclecategoriesBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (VehiclecategoriesBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.VehiclecategoriesDA"));
                return _instance;
            }
        }

        public VehiclecategoriesBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract bool Insert(iVehiclecategories c);
        public abstract bool Update(iVehiclecategories c);
        public abstract bool Delete(int id);       
        public abstract List<iVehiclecategories> SelectAll(string VehicleType);
        public abstract iVehiclecategories Select(int id);

        protected virtual iVehiclecategories GetVehiclecategoriesFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iVehiclecategories vehiclecategories = new iVehiclecategories(
                Convert.ToInt32(reader["id"]),
                reader["name"].ToString(),
                reader["vtype"].ToString()
                );
            return vehiclecategories;
        }

        protected virtual List<iVehiclecategories> GetVehiclecategoriesCollectionFromReader(IDataReader reader)
        {
            List<iVehiclecategories> vehiclecategories = new List<iVehiclecategories>();
            while (reader.Read())
                vehiclecategories.Add(GetVehiclecategoriesFromReader(reader, false));
            return vehiclecategories;
        }
    }
 
}

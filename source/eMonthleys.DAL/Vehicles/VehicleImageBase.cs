using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class VehicleImageBase : DataAccess
    {
        static private VehicleImageBase _instance = null;

        static public VehicleImageBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (VehicleImageBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.VehicleImageDA"));
                return _instance;
            }
        }

        public VehicleImageBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract bool Insert(iVehicleImage c);
        public abstract bool Update(iVehicleImage c);
        public abstract bool Delete(int id);
        public abstract iVehicleImage SelectByVehicleId(int VehicleId);
        public abstract iVehicleImage Select(int id);

        protected virtual iVehicleImage GetVehicleImageFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iVehicleImage vehicleimage = new iVehicleImage(
                Convert.ToInt32(reader["id"]),
                Convert.ToInt32(reader["vehicleid"]),
                Helpers.ConvertNullToBlank(reader["path"]),
                Helpers.ConvertNullToBlank(reader["image1"]),
                Helpers.ConvertNullToBlank(reader["image2"]),
                Helpers.ConvertNullToBlank(reader["image3"]),
                Helpers.ConvertNullToBlank(reader["image4"]),
                Helpers.ConvertNullToBlank(reader["image5"]),
                Helpers.ConvertNullToBlank(reader["image6"]),
                Helpers.ConvertNullToBlank(reader["image7"]),
                Helpers.ConvertNullToBlank(reader["image8"]),
                Helpers.ConvertNullToBlank(reader["video"]),
                Helpers.ConvertNullToBlank(reader["youtubelink"]),
                Helpers.ConvertNullToBlank(reader["videoformat"])
                );
            return vehicleimage;
        }

        protected virtual List<iVehicleImage> GetVehicleImageCollectionFromReader(IDataReader reader)
        {
            List<iVehicleImage> vehicleimages = new List<iVehicleImage>();
            while (reader.Read())
                vehicleimages.Add(GetVehicleImageFromReader(reader, false));
            return vehicleimages;
        }
    }

}

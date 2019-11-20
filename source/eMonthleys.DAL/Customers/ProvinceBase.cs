using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class ProvinceBase : DataAccess
    {
        static private ProvinceBase _instance = null;

        static public ProvinceBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ProvinceBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.ProvinceDA"));
                return _instance;
            }
        }

        public ProvinceBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        #region Abstract methods

        public abstract List<iProvince> SelectAll(string Country);
        public abstract iProvince Select(string ProvinceCode);

        #endregion

        protected virtual iProvince GetProvinceFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iProvince province = new iProvince(
                reader["cc"].ToString(),
                reader["psc"].ToString(),
                reader["province"].ToString()
                );
            return province;
        }

        protected virtual List<iProvince> GetProvinceCollectionFromReader(IDataReader reader)
        {
            List<iProvince> states = new List<iProvince>();
            while (reader.Read())
                states.Add(GetProvinceFromReader(reader, false));
            return states;
        }

    }
}

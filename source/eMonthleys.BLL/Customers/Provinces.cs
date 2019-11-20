using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class Provinces
    {
        public string CountryCode { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceStateName { get; set; }

        public Provinces() { }

        public Provinces(string cc, string psc, string name)
        {
            CountryCode = cc;
            ProvinceCode = psc;
            ProvinceStateName = name;
        }

        #region Private Methods

        private static Provinces GetProvinceValuesFromiProvince(iProvince record)
        {
            if (record == null)
                return null;
            else
            {
                return new Provinces(
                    record.CountryCode,
                    record.ProvinceCode,
                    record.ProvinceStateName
                    );
            }
        }

        private static List<Provinces> GetProvinceListFromiProvince(List<iProvince> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<Provinces> c = new List<Provinces>();
                foreach (iProvince record in recordset)
                    c.Add(GetProvinceValuesFromiProvince(record));
                return c;
            }
        }

        #endregion

        #region public methods

        public static List<Provinces> GetAllProvinces(string Country)
        {
            List<Provinces> Provinces = null;
            Provinces = GetProvinceListFromiProvince(ProvinceBase.Instance.SelectAll(Country));
            Provinces p = new Provinces("", "", "Please select...");
            Provinces.Insert(0, p);
            return Provinces;
        }

        public static Provinces GetProvinceDetails(string ProvinceCode)
        {
            Provinces c = null;
            c = GetProvinceValuesFromiProvince(ProvinceBase.Instance.Select(ProvinceCode));
            return c;
        }

        #endregion
    }
}

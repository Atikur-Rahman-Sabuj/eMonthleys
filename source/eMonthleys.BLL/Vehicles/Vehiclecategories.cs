using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class Vehiclecategories : BaseBLL
    {
        # region Constructors
        // zu finden im Interface
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleType { get; set; }

        public Vehiclecategories() { }

        public Vehiclecategories(int id, string name, string vtype)
        {
            Id = id;
            Name = name;
            VehicleType = vtype;
        }

        # endregion

        #region Private Methods

        private static Vehiclecategories GetVehiclecategoriesValuesFromiVehiclecategories(iVehiclecategories record)
        {
            if (record == null)
                return null;
            else
            {
                return new Vehiclecategories(
                    record.Id,
                    record.Name,
                    record.VehicleType
                    );
            }
        }

        private static List<Vehiclecategories> GetVehiclecategoriesListFromiVehiclecategories(List<iVehiclecategories> recordset, string ListType)
        {
            if (recordset == null)
                return null;
            else
            {
                List<Vehiclecategories> c = new List<Vehiclecategories>();
                foreach (iVehiclecategories record in recordset)
                    c.Add(GetVehiclecategoriesValuesFromiVehiclecategories(record));
                if (ListType == "ddl")
                {
                    Vehiclecategories first = new Vehiclecategories(0,"Please select","");
                    c.Insert(0, first);
                }
                return c;
            }
        }

        #endregion

        #region public methods

        public static List<Vehiclecategories> GetAllVehiclecategories(string VehicleType, string ListType)
        {
            List<Vehiclecategories> vehiclecategories = null;
            vehiclecategories = GetVehiclecategoriesListFromiVehiclecategories(VehiclecategoriesBase.Instance.SelectAll(VehicleType), ListType);
            return vehiclecategories;
        }

        public static Vehiclecategories GetVehicleCategoryDetails(int id)
        {
            Vehiclecategories vc = GetVehiclecategoriesValuesFromiVehiclecategories(VehiclecategoriesBase.Instance.Select(id));
            return vc;
        }

        public static bool InsertNewCategory(string name, string vtype)
        {
            iVehiclecategories c = new iVehiclecategories(
                0,
                name,
                vtype
                );
            return VehiclecategoriesBase.Instance.Insert(c);
        }

        public static bool UpdateCategory(int id, string name, string vtype)
        {
            iVehiclecategories c = new iVehiclecategories(
                id,
                name,
                vtype
                );
            return VehiclecategoriesBase.Instance.Update(c);
        }

        #endregion

    }
}

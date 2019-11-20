using System;
using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class ModelYearLookup : BaseBLL
    {
        public string ModelYear { get; set; }

        public ModelYearLookup() { }

        public ModelYearLookup(string mYear)
        {
            ModelYear = mYear;
        }

        private static ModelYearLookup GetModelYearLookupValuesFromiModelYearLookup(iModelYearLookup record)
        {
            if (record == null)
                return null;
            else
            {
                return new ModelYearLookup(
                    record.ModelYear
                    );
            }
        }

        private static List<ModelYearLookup> GetModelYearLookupListFromiModelYearLookup(List<iModelYearLookup> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<ModelYearLookup> y = new List<ModelYearLookup>();
                ModelYearLookup first = new ModelYearLookup("Please select");
                List<ModelYearLookup> added = new List<ModelYearLookup>();

                foreach (iModelYearLookup record in recordset)
                    y.Add(GetModelYearLookupValuesFromiModelYearLookup(record));
                int currentyear = Convert.ToInt16(y[0].ModelYear);
                for (int i = 0; i < 10; i++)
                {
                    ModelYearLookup addedyear = new ModelYearLookup((currentyear + i+1).ToString());
                    y.Insert(0, addedyear);
                }
                y.Insert(0, first);
                return y;
            }
        }

        public static List<ModelYearLookup> GetAllModelYearLookup()
        {
            List<ModelYearLookup> Years = null;
            Years = GetModelYearLookupListFromiModelYearLookup(ModelYearLookupBase.Instance.SelectAll());
            return Years;
        }
    }

    public class MakeLookup : BaseBLL
    {
        public string Make { get; set; }

        public MakeLookup() { }

        public MakeLookup(string make)
        {
            Make = make;
        }

        private static MakeLookup GetMakeLookupValuesFromiMakeLookup(iMakeLookup record)
        {
            if (record == null)
                return null;
            else
            {
                return new MakeLookup(
                    record.Make
                    );
            }
        }

        private static List<MakeLookup> GetMakeLookupListFromiMakeLookup(List<iMakeLookup> recordset, string ListType)
        {
            if (recordset == null)
                //return null;
                return new List<MakeLookup>();
            else
            {
                List<MakeLookup> m = new List<MakeLookup>();
                foreach (iMakeLookup record in recordset)
                    m.Add(GetMakeLookupValuesFromiMakeLookup(record));
                if (ListType == "ddl")
                {
                    MakeLookup first = new MakeLookup("Please select");
                    m.Insert(0, first);
                }
                return m;
            }
        }

        public static List<MakeLookup> GetAllMakeLookup(string ListType)
        {
            List<MakeLookup> MakeLookups = null;
            MakeLookup other = new MakeLookup("Other");
            MakeLookups = GetMakeLookupListFromiMakeLookup(MakeLookupBase.Instance.SelectAll(), ListType);
            MakeLookups.Add(other);
            return MakeLookups;
        }
    }

    public class ModelLookup : BaseBLL
    {
        public string Model { get; set; }

        public ModelLookup() { }

        public ModelLookup(string Model)
        {
            this.Model = Model;
        }

        private static ModelLookup GetModelLookupValuesFromiModelLookup(iModelLookup record)
        {
            if (record == null)
                return null;
            else
            {
                return new ModelLookup(
                    record.ModelName
                    );
            }
        }

        private static List<ModelLookup> GetModelLookupListFromiModelLookup(List<iModelLookup> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<ModelLookup> m = new List<ModelLookup>();
                ModelLookup first = new ModelLookup("Please select");
                ModelLookup other = new ModelLookup("Other");
                foreach (iModelLookup record in recordset)
                    m.Add(GetModelLookupValuesFromiModelLookup(record));
                m.Insert(0, first);
                m.Add(other);
                return m;
            }
        }

        public static List<ModelLookup> GetAllModelsLookup(string Manufacturer)
        {
            List<ModelLookup> ModelLookups = null;          
            ModelLookups = GetModelLookupListFromiModelLookup(ModelLookupBase.Instance.SelectAll(Manufacturer));
            return ModelLookups;
        }
    }

    public class ModelTrimLookup : BaseBLL
    {
        public int ModelId { get; set; }
        public string ModelTrim { get; set; }

        public ModelTrimLookup() { }

        public ModelTrimLookup(int id, string ModelTrim)
        {
            ModelId = id;
            this.ModelTrim = ModelTrim;
        }

        private static ModelTrimLookup GetModelTrimLookupValuesFromiModelTrimLookup(iModelTrimLookup record)
        {
            if (record == null)
                return null;
            else
            {
                return new ModelTrimLookup(
                    record.ModelId,
                    record.ModelTrim
                    );
            }
        }

        private static List<ModelTrimLookup> GetModelTrimLookupListFromiModelTrimLookup(List<iModelTrimLookup> recordset)
        {
            List<ModelTrimLookup> mt = new List<ModelTrimLookup>();
            ModelTrimLookup first = new ModelTrimLookup(0, "Please select");
            ModelTrimLookup other = new ModelTrimLookup(60931, "Other");
            if (recordset != null)
            {
                foreach (iModelTrimLookup record in recordset)
                    mt.Add(GetModelTrimLookupValuesFromiModelTrimLookup(record));
            }
            mt.Insert(0, first);
            mt.Add(other);
            return mt;
        }

        public static List<ModelTrimLookup> GetAllModelTrimLookup(string ModelName, string Manufacturer)
        {
            if (Manufacturer == "Please select")
                return null;
            else
            {
                List<ModelTrimLookup> ModelTrimLookups = null;
                ModelTrimLookups = GetModelTrimLookupListFromiModelTrimLookup(ModelTrimLookupBase.Instance.SelectAll(ModelName, Manufacturer));
                return ModelTrimLookups;
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    /// <summary>
    /// Model year lookup class
    /// </summary>
    public abstract class ModelYearLookupBase : DataAccess
    {
        static private ModelYearLookupBase _instance = null;

        static public ModelYearLookupBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ModelYearLookupBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.ModelYearLookupDA"));
                return _instance;
            }
        }

        public ModelYearLookupBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract List<iModelYearLookup> SelectAll();

        protected virtual iModelYearLookup GetModelYearLookupFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iModelYearLookup makes = new iModelYearLookup(
               reader["model_year"].ToString()
                );
            return makes;
        }
        protected virtual List<iModelYearLookup> GetModelYearLookupCollectionFromReader(IDataReader reader)
        {
            List<iModelYearLookup> years = new List<iModelYearLookup>();
            while (reader.Read())
                years.Add(GetModelYearLookupFromReader(reader, false));
            return years;
        }
    }

    /// <summary>
    /// Manufacturer lookup class based on model year
    /// </summary>
    public abstract class MakeLookupBase : DataAccess
    {
        static private MakeLookupBase _instance = null;

        static public MakeLookupBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (MakeLookupBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.MakeLookupDA"));
                return _instance;
            }
        }

        public MakeLookupBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract List<iMakeLookup> SelectAll();

        protected virtual iMakeLookup GetMakeLookupFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iMakeLookup makes = new iMakeLookup(
               reader["model_make_display"].ToString()
                );
            return makes;
        }
        protected virtual List<iMakeLookup> GetMakeLookupCollectionFromReader(IDataReader reader)
        {
            List<iMakeLookup> makes = new List<iMakeLookup>();
            while (reader.Read())
                makes.Add(GetMakeLookupFromReader(reader, false));
            return makes;
        }
    }

    /// <summary>
    /// Model lookup class based on manufacturer and model year
    /// </summary>
    public abstract class ModelLookupBase : DataAccess
    {
        static private ModelLookupBase _instance = null;

        static public ModelLookupBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ModelLookupBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.ModelLookupDA"));
                return _instance;
            }
        }

        public ModelLookupBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract List<iModelLookup> SelectAll(string Make);

        protected virtual iModelLookup GetModelLookupFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iModelLookup Models = new iModelLookup(
               reader["model_name"].ToString()
                );
            return Models;
        }
        protected virtual List<iModelLookup> GetModelLookupCollectionFromReader(IDataReader reader)
        {
            List<iModelLookup> Models = new List<iModelLookup>();
            while (reader.Read())
                Models.Add(GetModelLookupFromReader(reader, false));
            return Models;
        }
    }

    /// <summary>
    /// Model Trim lookup base on manufacturer, model and year
    /// </summary>
    public abstract class ModelTrimLookupBase : DataAccess
    {
        static private ModelTrimLookupBase _instance = null;

        static public ModelTrimLookupBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (ModelTrimLookupBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.ModelTrimLookupDA"));
                return _instance;
            }
        }

        public ModelTrimLookupBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract List<iModelTrimLookup> SelectAll(string ModelName, string Manufacturer);

        protected virtual iModelTrimLookup GetModelTrimLookupFromReader(SqlDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iModelTrimLookup Trims = new iModelTrimLookup(
                Convert.ToInt32(reader["model_id"]),
                Helpers.ConvertNullToBlank(reader["model_trim"])
                );
            return Trims;
        }
        protected virtual List<iModelTrimLookup> GetModelTrimLookupCollectionFromReader(SqlDataReader reader)
        {
            List<iModelTrimLookup> Trims = new List<iModelTrimLookup>();
            while (reader.Read())
            {
                Trims.Add(GetModelTrimLookupFromReader(reader, false));
            }

            return Trims;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class SearchBase : DataAccess
    {
        static private SearchBase _instance = null;

        static public SearchBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (SearchBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.SearchDA"));
                return _instance;
            }
        }

        public SearchBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract List<iSearch> SelectAll(string WherePath);
        public abstract List<iSearch> SelectByVehicleId(int VehicleId, int FinId);

        protected virtual iSearch GetSearchFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iSearch Search = new iSearch(               
                //customers
                reader["customertype"].ToString(),
                reader["email"].ToString(), 
                Helpers.ConvertNullToBlank(reader["company"].ToString()),
                reader["firstname"].ToString(),
                reader["lastname"].ToString(),
                Convert.ToInt32(reader["streetno"]),
                Helpers.ConvertNullToBlank(reader["streetnosuffix"].ToString()),
                reader["address1"].ToString(),
                Helpers.ConvertNullToBlank(reader["address2"].ToString()),
                Helpers.ConvertNullToBlank(reader["pobox"].ToString()),
                reader["city"].ToString(),
                reader["province"].ToString(),
                reader["zip"].ToString(),
                reader["country"].ToString(),
                reader["phone"].ToString(),
                Helpers.ConvertNullToBlank(reader["cellphone"].ToString()),
        
                //customervehicleinfo                
                Convert.ToInt32(reader["seller"]),
                reader["condition"].ToString(),
                Convert.ToInt16(reader["modelyear"]),
                reader["manufacturer"].ToString(),
                Helpers.ConvertDbNullToBlank(reader["othermake"].ToString()),
                Convert.ToInt16(reader["vehcategory"]),
                reader["model"].ToString(),
                Helpers.ConvertDbNullToBlank(reader["othermodel"].ToString()),
                reader["model_trim"].ToString(),
                Helpers.ConvertDbNullToBlank(reader["othertrim"].ToString()),
                reader["exteriorcolor"].ToString(),
                reader["interiorcolor"].ToString(),
                reader["transmission"].ToString(),
                reader["fueltype"].ToString(),
                Convert.ToInt32(reader["currentmileage"]),
                reader["wheels"].ToString(),
                Convert.ToBoolean(reader["chromewheels"]),
                reader["tires"].ToString(),
                Convert.ToBoolean(reader["wintertires"]),
                Helpers.ConvertNullToBlank(reader["comments"]),
                Helpers.ConvertNullToBlank(reader["displacement"]),

                //FinancialDetails                
                reader["leaseorfinance"].ToString(),
                Helpers.ConvertNullInt64ToZero(reader["vehicleid"]),
                reader["paymentcycle"].ToString(),
                Helpers.ConvertNullDblToZero(reader["paymentwithtax"]),
                Helpers.ConvertNullDblToZero(reader["originaldown"]),
                Helpers.ConvertNullDblToZero(reader["securitydeposit"]),
                Helpers.ConvertNullDblToZero(reader["poendoflease"]),
                Helpers.ConvertNullInt64ToZero(reader["kmallowance"]),
                Helpers.ConvertNullDblToZero(reader["excesskmcharge"]),
                Helpers.ConvertNullIntToZero(reader["leaseterm"]),
                Helpers.CheckNullableDate(reader["leaseexpiry"]),
                Helpers.ConvertNullDblToZero(reader["buyback"]),
                Helpers.ConvertNullDblToZero(reader["balloon"]),
                Helpers.ConvertNullDblToZero(reader["purchaseprice"]),
                Helpers.ConvertNullToBlank(reader["summary"].ToString()),
                Helpers.ConvertNullToBlank(reader["financeinfo"].ToString()),
                Helpers.ConvertNullToBlank(reader["status"].ToString()),
                Convert.ToInt32(reader["finid"]),
                Convert.ToBoolean(reader["adstatus"])
                );
             return Search;                  
        }
        protected virtual List<iSearch> GetSearchCollectionFromReader(IDataReader reader)
        {
            List<iSearch> search = new List<iSearch>();
            while (reader.Read())
                search.Add(GetSearchFromReader(reader, false));
            return search;
        }
    }
}

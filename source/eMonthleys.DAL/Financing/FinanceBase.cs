using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class FinanceBase  : DataAccess
    {
        static private FinanceBase _instance = null;

        static public FinanceBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (FinanceBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.FinanceDA"));
                return _instance;
            }
        }
        
        public FinanceBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract int Insert(iFinanceDetails c);
        public abstract bool Update(iFinanceDetails c);
        public abstract bool UpdatePrice(iFinanceDetails f);
        public abstract bool UpdateAdStatus(int Id, int VehicleId, bool AdStatus);
        public abstract bool Delete(int Id, int VehicleId);
        public abstract List<string> CheckPayCycle(int VehicleId);
        public abstract bool ChangeStatus(int id, int VehicleId, string Status);
        public abstract List<iFinanceDetails> SelectAll();
        public abstract iFinanceDetails Select(int Id);
        public abstract iFinanceDetails SelectByVehicleId(int VehicleId, int FinId);

        protected virtual iFinanceDetails GetFinancialDetailsFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iFinanceDetails financedetail = new iFinanceDetails(
                Helpers.ConvertNullInt64ToZero(reader["id"]),
                reader["leaseorfinance"].ToString(),
                Helpers.ConvertNullInt64ToZero(reader["vehicleid"]),
                reader["paymentcycle"].ToString(),
                Helpers.ConvertNullDblToZero(reader["paymentwithtax"]),
                Helpers.ConvertNullDblToZero(reader["originaldown"]),
                Helpers.ConvertNullDblToZero(reader["securitydeposit"]),
                Helpers.ConvertNullToBlank(reader["poendoflease"]),
                Helpers.ConvertNullInt64ToZero(reader["kmallowance"]),
                Helpers.ConvertNullDblToZero(reader["excesskmcharge"]),
                Helpers.ConvertNullIntToZero(reader["leaseterm"]),
                Helpers.CheckNullableDate(reader["leaseexpiry"]),
                Helpers.ConvertNullDblToZero(reader["buyback"]),
                Helpers.ConvertNullDblToZero(reader["balloon"]),
                Helpers.ConvertNullDblToZero(reader["purchaseprice"]),
                Helpers.ConvertNullToBlank(reader["summary"].ToString()),
                Helpers.ConvertNullToBlank(reader["comments"].ToString()),
                Helpers.ConvertNullToBlank(reader["status"].ToString()),
                Convert.ToBoolean(reader["adstatus"])
                );
            return financedetail;
        }

        protected virtual List<iFinanceDetails> GetFinancialDetailsCollectionFromReader(IDataReader reader)
        {
            List<iFinanceDetails> financialdetails = new List<iFinanceDetails>();
            while (reader.Read())
            {
                financialdetails.Add(GetFinancialDetailsFromReader(reader, false));
            }
            return financialdetails;
        }

        protected virtual List<string> GetFinancialPaymentCycleCollectionFromReader(IDataReader reader)
        {
            List<string> payCycles = new List<string>();
            while (reader.Read())
            {
                payCycles.Add(reader["paymentcycle"].ToString());
            }
            return payCycles;
        }
    }
}

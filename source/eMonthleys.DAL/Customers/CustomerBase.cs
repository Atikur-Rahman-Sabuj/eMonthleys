using System;
using System.Collections.Generic;
using System.Data;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    public abstract class CustomerBase : DataAccess
    {
        static private CustomerBase _instance = null;

        static public CustomerBase Instance
        {
            get
            {
                if (_instance == null)
                    _instance = (CustomerBase)Activator.CreateInstance(Type.GetType("eMonthleys.DAL.CustomerDA"));
                return _instance;
            }
        }

        public CustomerBase()
        {
            ConnectionString = Helpers.GetConnectionString();
        }

        public abstract int Insert(iCustomer c);
        public abstract bool Update(iCustomer c);
        public abstract bool Delete(int id);
        public abstract bool UpdatePassword(int id, string password);
        public abstract List<iCustomer> SelectAll(bool Status);
        public abstract iCustomer Select(int id);
        public abstract iCustomer Select(string Email);
        public abstract iCustomer Login(string Email, string Password);
        public abstract bool LoginExists(string Email);
        public abstract bool ActivateUser(int id);
        public abstract bool DeactivateUser(int id);

        protected virtual iCustomer GetCustomerFromReader(IDataReader reader, bool singleRecord)
        {
            if (singleRecord)
                reader.Read();
            iCustomer customer = new iCustomer(
                Convert.ToInt32(reader["id"]),
                reader["customertype"].ToString(),
                reader["email"].ToString(),
                reader["password"].ToString(),
                reader["company"].ToString(),
                reader["firstname"].ToString(),
                reader["lastname"].ToString(),
                Convert.ToInt32(reader["streetno"]),
                reader["streetnosuffix"].ToString(),
                reader["address1"].ToString(),
                reader["address2"].ToString(),
                reader["pobox"].ToString(),
                reader["city"].ToString(),
                reader["province"].ToString(),
                reader["zip"].ToString(),
                reader["country"].ToString(),
                reader["phone"].ToString(),
                reader["cellphone"].ToString(),
                reader["usertype"].ToString(),
                Convert.ToBoolean(reader["active"]),
                Convert.ToDateTime(reader["dateadded"])
                );
            return customer;
        }

        protected virtual List<iCustomer> GetCustomerCollectionFromReader(IDataReader reader)
        {
            List<iCustomer> customers = new List<iCustomer>();
            while (reader.Read())
                customers.Add(GetCustomerFromReader(reader, false));
            return customers;
        }
    }
}

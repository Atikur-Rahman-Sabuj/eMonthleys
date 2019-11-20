using System;
using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class Customer : BaseBLL
    {
        #region Constructors

        public int Id { get; set; }
        public string CustomerType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StreetNo { get; set; }
        public string StreetNoSuffix { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string POBox { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZIP { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public string UserType { get; set; }
        public bool Active { get; set; }
        public DateTime DateAdded { get; set; }

        public Customer() { }

        public Customer(int id, string customertype, string email, string password, string company, string fname, string lname, int streetno, string strnosfx,
            string address1, string address2, string pobox, string city, string prov, string zip, string country, string phone, string cellp, 
            string usertype, bool active, DateTime dateadded)
        {
            Id = id;
            CustomerType = customertype;
            Email = email;
            Password = password;
            Company = company;
            FirstName = fname;
            LastName = lname;
            StreetNo = streetno;
            StreetNoSuffix = strnosfx;
            Address1 = address1;
            Address2 = address2;
            POBox = pobox;
            City = city;
            State = prov;
            ZIP = zip;
            Country = country;
            Phone = phone;
            CellPhone = cellp;
            UserType = usertype;
            Active = active;
            DateAdded = dateadded;
        }

        #endregion

        #region Private Methods

        private static Customer GetCustomerValuesFromiCustomer(iCustomer record)
        {
            if (record == null)
                return null;
            else
            {
                return new Customer(
                    record.Id,
                    record.CustomerType,
                    record.Email,
                    record.Password,
                    record.Company,
                    record.FirstName,
                    record.LastName,
                    record.StreetNo,
                    record.StreetNoSuffix,
                    record.Address1,
                    record.Address2,
                    record.POBox,
                    record.City,
                    record.State,
                    record.ZIP,
                    record.Country,
                    record.Phone,
                    record.CellPhone,
                    record.UserType,
                    record.Active,
                    record.DateAdded
                    );
            }
        }

        private static List<Customer> GetCustomerListFromiCustomer(List<iCustomer> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<Customer> c = new List<Customer>();
                foreach (iCustomer record in recordset)
                    c.Add(GetCustomerValuesFromiCustomer(record));
                return c;
            }
        }

        #endregion

        #region public methods

        public static List<Customer> GetAllCustomers(string Status)
        {
            bool status = false;
            switch (Status)
            {
                case "new" :
                    status = false;
                    break;
                case "existing" :
                    status = true;
                    break;
            }
            List<Customer> customers = null;
            customers = GetCustomerListFromiCustomer(CustomerBase.Instance.SelectAll(status));
            return customers;
        }

        public static Customer GetCustomerDetails(int id)
        {
            Customer c = GetCustomerValuesFromiCustomer(CustomerBase.Instance.Select(id));
            return c;
        }

        public static Customer GetCustomerDetails(string Email)
        {
            Customer c = GetCustomerValuesFromiCustomer(CustomerBase.Instance.Select(Email));
            return c;
        }

        public static Customer Login(string Email, string Password)
        {
            Customer c = GetCustomerValuesFromiCustomer(CustomerBase.Instance.Login(Email, Password));
            return c;
        }

        public static int InsertNewCustomer(Customer user)
        {
            iCustomer c = new iCustomer(
                0,
                user.CustomerType,
                user.Email,
                user.Password,
                user.Company,
                user.FirstName,
                user.LastName,
                user.StreetNo,
                user.StreetNoSuffix,
                user.Address1,
                user.Address2,
                user.POBox,
                user.City,
                user.State,
                user.ZIP,
                user.Country,
                user.Phone,
                user.CellPhone,
                user.UserType,
                user.Active,
                user.DateAdded
                );
            return CustomerBase.Instance.Insert(c);
        }

        public static bool UpdateCustomer(Customer user)
        {
            iCustomer c = new iCustomer(
                user.Id,
                user.CustomerType,
                user.Email,
                user.Password,
                user.Company,
                user.FirstName,
                user.LastName,
                user.StreetNo,
                user.StreetNoSuffix,
                user.Address1,
                user.Address2,
                user.POBox,
                user.City,
                user.State,
                user.ZIP,
                user.Country,
                user.Phone,
                user.CellPhone,
                user.UserType,
                user.Active,
                user.DateAdded
                );
            return CustomerBase.Instance.Update(c);
        }

        public static bool UpdateCustomerPassword(
            int id,
            string password
            )
        {
            return CustomerBase.Instance.UpdatePassword(id, password);
        }

        public static bool LoginExists(string Email)
        {
            return CustomerBase.Instance.LoginExists(Email);
        }

        public static bool ActivateUser(int Id)
        {
            return CustomerBase.Instance.ActivateUser(Id);
        }

        public static bool DeactivateUser(int Id)
        {
            return CustomerBase.Instance.DeactivateUser(Id);
        }

        #endregion
    }
}

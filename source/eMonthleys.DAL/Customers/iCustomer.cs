using System;

namespace eMonthleys.DAL
{
    public class iCustomer
    {
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

        public iCustomer() { }

        public iCustomer(int id, string customertype, string email, string password, string company, string fname, string lname, int streetno, string strnosfx,
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
    }
}

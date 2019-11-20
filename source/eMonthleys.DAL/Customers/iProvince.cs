namespace eMonthleys.DAL
{
    public class iProvince
    {
        public string CountryCode { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceStateName { get; set; }

        public iProvince() { }

        public iProvince(string cc, string psc, string name)
        {
            CountryCode = cc;
            ProvinceCode = psc;
            ProvinceStateName = name;
        }
    }
}

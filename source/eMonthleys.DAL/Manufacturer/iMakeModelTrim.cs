namespace eMonthleys.DAL
{
    public class iModelYearLookup
    {
        public string ModelYear { get; set; }

        public iModelYearLookup() { }

        public iModelYearLookup(string myear)
        {
            ModelYear = myear;
        }
    }

    public class iMakeLookup
    {
        public string Make { get; set; }

        public iMakeLookup() { }

        public iMakeLookup(string make)
        {
            Make = make;
        }
    }

    public class iModelLookup
    {
        public string ModelName { get; set; }

        public iModelLookup() { }

        public iModelLookup(string name)
        {
            ModelName = name;
        }
    }

    public class iModelTrimLookup
    {
        public int ModelId { get; set; }
        public string ModelTrim { get; set; }

        public iModelTrimLookup() { }

        public iModelTrimLookup(int id, string mtrim)
        {
            ModelId = id;
            ModelTrim = mtrim;
        }
    }
}

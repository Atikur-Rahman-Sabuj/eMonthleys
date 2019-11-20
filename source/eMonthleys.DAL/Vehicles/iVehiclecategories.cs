namespace eMonthleys.DAL
{
    public class iVehiclecategories 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VehicleType { get; set; }

        public iVehiclecategories() { }
        public iVehiclecategories(int id, string name, string vtype)
        {
            Id = id;
            Name = name;
            VehicleType = vtype;
        }

    }
}

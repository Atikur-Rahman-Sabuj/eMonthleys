namespace eMonthleys.DAL
{
    public class iVehicleFeatures 
    {
        public int Id {get; set; }
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }


        public iVehicleFeatures() { }

        public iVehicleFeatures(int id, int vehicleid,
            int featureid)
        {
            Id = id;
            VehicleId = vehicleid;
            FeatureId = featureid;
        }
    }
}

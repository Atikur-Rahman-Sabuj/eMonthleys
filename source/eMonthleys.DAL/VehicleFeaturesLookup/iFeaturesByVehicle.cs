namespace eMonthleys.DAL
{
    public class iFeaturesByVehicle
    {
        public int VehicleId { get; set; }
        public string Feature { get; set; }
        public string FeatureType { get; set; }


        public iFeaturesByVehicle() { }

        public iFeaturesByVehicle(int id, string feature, string featuretype)
        {
            VehicleId = id;
            Feature = feature;
            FeatureType = featuretype;
        }
    }
}

namespace eMonthleys.DAL
{
   public class iVehiclefeaturelookup 
    {
        public int Id { get; set; }
        public string Feature { get; set; }
        public string FeatureType { get; set; }
        public string ListType { get; set; }


        public iVehiclefeaturelookup() { }

        public iVehiclefeaturelookup(int id, string feature, string featuretype, string listtype)
        {
            Id = id;
            Feature = feature;
            FeatureType = featuretype;
            ListType = listtype;

        }
    }

   public class iFeatureLookup
   {
       public int Id { get; set; }
       public string Feature { get; set; }

       public iFeatureLookup() { }

       public iFeatureLookup(int id, string feature)
       {
           Id = id;
           Feature = feature;
       }
   }
}

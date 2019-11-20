namespace eMonthleys.DAL
{
    public class iVehicleImage 
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string ImgPath { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string Img5{ get; set; }
        public string Img6 { get; set; }
        public string Img7 { get; set; }
        public string Img8 { get; set; }
        public string Video { get; set; }
        public string YouTubeLink { get; set; }
        public string VideoFormat { get; set; }

        public iVehicleImage() { }

        public iVehicleImage(
            int id, 
            int vehicleid,
            string imgpath,
            string img1,
            string img2,
            string img3,
            string img4,
            string img5,
            string img6,
            string img7,
            string img8,
            string video, 
            string youtube,
            string videoformat
            )
        {
            Id = id;
            VehicleId = vehicleid;
            ImgPath = imgpath;
            Img1 = img1;
            Img2 = img2;
            Img3 = img3;
            Img4 = img4;
            Img5 = img5;
            Img6 = img6;
            Img7 = img7;
            Img8 = img8;
            Video = video;
            YouTubeLink = youtube;
            VideoFormat = videoformat;
        }
    }
}

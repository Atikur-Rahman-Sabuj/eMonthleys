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
        public string Img9 { get; set; }
        public string Img10 { get; set; }
        public string Img11 { get; set; }
        public string Img12 { get; set; }
        public string Img13 { get; set; }
        public string Img14 { get; set; }
        public string Img15 { get; set; }
        public string Img16 { get; set; }
        public string Img17 { get; set; }
        public string Img18 { get; set; }
        public string Img19 { get; set; }
        public string Img20 { get; set; }
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
            string img9,
            string img10,
            string img11,
            string img12,
            string img13,
            string img14,
            string img15,
            string img16,
            string img17,
            string img18,
            string img19,
            string img20,
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
            Img9 = img9;
            Img10 = img10;
            Img11 = img11;
            Img12 = img12;
            Img13 = img13;
            Img14 = img14;
            Img15 = img15;
            Img16 = img16;
            Img17 = img17;
            Img18 = img18;
            Img19 = img19;
            Img20 = img20;
            Video = video;
            YouTubeLink = youtube;
            VideoFormat = videoformat;
        }
    }
}

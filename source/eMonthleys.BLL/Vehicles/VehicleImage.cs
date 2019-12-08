using System.Collections.Generic;
using eMonthleys.DAL;

namespace eMonthleys.BLL
{
    public class VehicleImage : BaseBLL
    {
        # region Constructors
        // zu finden im Interface
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string ImgPath { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string Img5 { get; set; }
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

        public VehicleImage() { }

        public VehicleImage(
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
        # endregion

        #region Private Methods

        private static VehicleImage GetVehicleImageValuesFromiVehicleImage(iVehicleImage record)
        {
            if (record == null)
                return null;
            else
            {
                return new VehicleImage(
                    record.Id,
                    record.VehicleId,
                    record.ImgPath,
                    record.Img1,
                    record.Img2,
                    record.Img3,
                    record.Img4,
                    record.Img5,
                    record.Img6,
                    record.Img7,
                    record.Img8,
                    record.Img9,
                    record.Img10,
                    record.Img11,
                    record.Img12,
                    record.Img13,
                    record.Img14,
                    record.Img15,
                    record.Img16,
                    record.Img17,
                    record.Img18,
                    record.Img19,
                    record.Img20,
                    record.Video,
                    record.YouTubeLink,
                    record.VideoFormat
                    );
            }
        }

        private static List<VehicleImage> GetVehicleImageListFromiVehicleImage(List<iVehicleImage> recordset)
        {
            if (recordset == null)
                return null;
            else
            {
                List<VehicleImage> c = new List<VehicleImage>();
                foreach (iVehicleImage record in recordset)
                    c.Add(GetVehicleImageValuesFromiVehicleImage(record));
                return c;
            }
        }

        #endregion

        #region public methods

        public static VehicleImage SelectByVehicleId(int VehicleId)
        {
            VehicleImage vi = GetVehicleImageValuesFromiVehicleImage(VehicleImageBase.Instance.SelectByVehicleId(VehicleId));
            return vi;
        }

        public static VehicleImage SelectByRecordId(int id)
        {
            VehicleImage vi = GetVehicleImageValuesFromiVehicleImage(VehicleImageBase.Instance.Select(id));
            return vi;
        }

        public static bool InsertNewVehicleImage(VehicleImage vi)
        {
            iVehicleImage i = new iVehicleImage(
                0,
                vi.VehicleId,
                vi.ImgPath,
                vi.Img1,
                vi.Img2,
                vi.Img3,
                vi.Img4,
                vi.Img5,
                vi.Img6,
                vi.Img7,
                vi.Img8,
                vi.Img9,
                vi.Img10,
                vi.Img11,
                vi.Img12,
                vi.Img13,
                vi.Img14,
                vi.Img15,
                vi.Img16,
                vi.Img17,
                vi.Img18,
                vi.Img19,
                vi.Img20,
                vi.Video,
                vi.YouTubeLink,
                vi.VideoFormat
                );
            return VehicleImageBase.Instance.Insert(i);
        }

        public static bool UpdateVehicleImage(VehicleImage vi)
        {
            iVehicleImage i = new iVehicleImage(
                vi.Id,
                vi.VehicleId,
                vi.ImgPath,
                vi.Img1,
                vi.Img2,
                vi.Img3,
                vi.Img4,
                vi.Img5,
                vi.Img6,
                vi.Img7,
                vi.Img8,
                vi.Img9,
                vi.Img10,
                vi.Img11,
                vi.Img12,
                vi.Img13,
                vi.Img14,
                vi.Img15,
                vi.Img16,
                vi.Img17,
                vi.Img18,
                vi.Img19,
                vi.Img20,
                vi.Video,
                vi.YouTubeLink,
                vi.VideoFormat
                );
            return VehicleImageBase.Instance.Update(i);
        }

        #endregion

    }
}


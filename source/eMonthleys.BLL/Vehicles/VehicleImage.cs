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
                vi.Video,
                vi.YouTubeLink,
                vi.VideoFormat
                );
            return VehicleImageBase.Instance.Update(i);
        }

        #endregion

    }
}


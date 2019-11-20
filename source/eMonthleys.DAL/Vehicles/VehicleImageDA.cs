using System;
using System.Data;
using System.Data.SqlClient;
using eMonthleys.Utils;

namespace eMonthleys.DAL
{
    class VehicleImageDA : VehicleImageBase
    {
        public override bool Insert(iVehicleImage vi)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                SqlCommand cmd = new SqlCommand(q, conn);

                q = @"
                    INSERT INTO [dbo].[vehicleimages]
                    ([vehicleid]
                    ,[path]
                    ,[image1]
                    ,[image2]
                    ,[image3]
                    ,[image4]
                    ,[image5]
                    ,[image6]
                    ,[image7]
                    ,[image8]
                    ,[video]
                    ,[youtubelink]
                    ,[videoformat])
                VALUES
                    (@pVehicleId
                    ,@pPath
                    ,@pImage1
                    ,@pImage2
                    ,@pImage3
                    ,@pImage4
                    ,@pImage5
                    ,@pImage6
                    ,@pImage7
                    ,@pImage8
                    ,@pVideo
                    ,@pYouTube
                    ,@pFormat)";

                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pVehicleId", SqlDbType.Int).Value = vi.VehicleId;
                cmd.Parameters.Add("@pPath", SqlDbType.VarChar).Value = vi.ImgPath;
                if (vi.Img1 != null)
                    cmd.Parameters.Add("@pImage1", SqlDbType.VarChar).Value = vi.Img1;
                else
                    cmd.Parameters.Add("@pImage1", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img2 != null)
                    cmd.Parameters.Add("@pImage2", SqlDbType.VarChar).Value = vi.Img2;
                else
                    cmd.Parameters.Add("@pImage2", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img3 != null)
                    cmd.Parameters.Add("@pImage3", SqlDbType.VarChar).Value = vi.Img3;
                else
                    cmd.Parameters.Add("@pImage3", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img4 != null)
                    cmd.Parameters.Add("@pImage4", SqlDbType.VarChar).Value = vi.Img4;
                else
                    cmd.Parameters.Add("@pImage4", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img5 != null)
                    cmd.Parameters.Add("@pImage5", SqlDbType.VarChar).Value = vi.Img5;
                else
                    cmd.Parameters.Add("@pImage5", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img6 != null)
                    cmd.Parameters.Add("@pImage6", SqlDbType.VarChar).Value = vi.Img6;
                else
                    cmd.Parameters.Add("@pImage6", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img7 != null)
                    cmd.Parameters.Add("@pImage7", SqlDbType.VarChar).Value = vi.Img7;
                else
                    cmd.Parameters.Add("@pImage7", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img8 != null)
                    cmd.Parameters.Add("@pImage8", SqlDbType.VarChar).Value = vi.Img8;
                else
                    cmd.Parameters.Add("@pImage8", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Video != null)
                    cmd.Parameters.Add("@pVideo", SqlDbType.VarChar).Value = vi.Video;
                else
                    cmd.Parameters.Add("@pVideo", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.YouTubeLink != null)
                    cmd.Parameters.Add("@pYouTube", SqlDbType.VarChar).Value = vi.YouTubeLink;
                else
                    cmd.Parameters.Add("@pYouTube", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.VideoFormat != null)
                    cmd.Parameters.Add("@pFormat", SqlDbType.VarChar).Value = vi.VideoFormat;
                else
                    cmd.Parameters.Add("@pFormat", SqlDbType.VarChar).Value = DBNull.Value;

                try
                {
                    conn.Open();
                    int rc = ExecuteNonQuery(cmd);
                    return (rc == 1);
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return false;
                }
            }

        }
        public override bool Update(iVehicleImage vi)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    UPDATE [dbo].[vehicleimages]
                       SET [path] = @pPath
                          ,[image1] = @pImage1
                          ,[image2] = @pImage2
                          ,[image3] = @pImage3
                          ,[image4] = @pImage4
                          ,[image5] = @pImage5
                          ,[image6] = @pImage6
                          ,[image7] = @pImage7
                          ,[image8] = @pImage8
                          ,[video] = @pVideo
                          ,[youtubelink] = @pYouTube
                          ,[videoformat] = @pFormat
                     WHERE [id] = @pid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandText = q;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@pid", SqlDbType.Int).Value = vi.Id;
                cmd.Parameters.Add("@pPath", SqlDbType.VarChar).Value = vi.ImgPath;
                if (vi.Img1 != null)
                    cmd.Parameters.Add("@pImage1", SqlDbType.VarChar).Value = vi.Img1;
                else
                    cmd.Parameters.Add("@pImage1", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img2 != null)
                    cmd.Parameters.Add("@pImage2", SqlDbType.VarChar).Value = vi.Img2;
                else
                    cmd.Parameters.Add("@pImage2", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img3 != null)
                    cmd.Parameters.Add("@pImage3", SqlDbType.VarChar).Value = vi.Img3;
                else
                    cmd.Parameters.Add("@pImage3", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img4 != null)
                    cmd.Parameters.Add("@pImage4", SqlDbType.VarChar).Value = vi.Img4;
                else
                    cmd.Parameters.Add("@pImage4", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img5 != null)
                    cmd.Parameters.Add("@pImage5", SqlDbType.VarChar).Value = vi.Img5;
                else
                    cmd.Parameters.Add("@pImage5", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img6 != null)
                    cmd.Parameters.Add("@pImage6", SqlDbType.VarChar).Value = vi.Img6;
                else
                    cmd.Parameters.Add("@pImage6", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img7 != null)
                    cmd.Parameters.Add("@pImage7", SqlDbType.VarChar).Value = vi.Img7;
                else
                    cmd.Parameters.Add("@pImage7", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Img8 != null)
                    cmd.Parameters.Add("@pImage8", SqlDbType.VarChar).Value = vi.Img8;
                else
                    cmd.Parameters.Add("@pImage8", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.Video != null)
                    cmd.Parameters.Add("@pVideo", SqlDbType.VarChar).Value = vi.Video;
                else
                    cmd.Parameters.Add("@pVideo", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.YouTubeLink != null)
                    cmd.Parameters.Add("@pYouTube", SqlDbType.VarChar).Value = vi.YouTubeLink;
                else
                    cmd.Parameters.Add("@pYouTube", SqlDbType.VarChar).Value = DBNull.Value;
                if (vi.VideoFormat != null)
                    cmd.Parameters.Add("@pFormat", SqlDbType.VarChar).Value = vi.VideoFormat;
                else
                    cmd.Parameters.Add("@pFormat", SqlDbType.VarChar).Value = DBNull.Value;

                try
                {
                    conn.Open();
                    int rc = ExecuteNonQuery(cmd);
                    return (rc == 1);
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return false;
                }
            }
        }
        public override bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    DELETE FROM [dbo].[vehicleimages]
                          WHERE [id] = @cid";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;

                try
                {
                    conn.Open();

                    int ret = ExecuteNonQuery(cmd);
                    return (ret == 1);
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return false;
                }
            }
        }
        public override iVehicleImage SelectByVehicleId(int VehicleId)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                            ,[vehicleid]
                            ,[path]
                            ,[image1]
                            ,[image2]
                            ,[image3]
                            ,[image4]
                            ,[image5]
                            ,[image6]
                            ,[image7]
                            ,[image8]
                            ,[video]
                            ,[youtubelink]
                            ,[videoformat]
                    FROM [dbo].[vehicleimages]
                    WHERE [vehicleid] = @VehicleId";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@VehicleId", SqlDbType.Int).Value = VehicleId;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetVehicleImageFromReader(reader, true);
                    else
                        return null;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return null;
                }
            }
        }

        public override iVehicleImage Select(int Id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string q = string.Empty;

                q = @"
                    SELECT [id]
                            ,[vehicleid]
                            ,[path]
                            ,[image1]
                            ,[image2]
                            ,[image3]
                            ,[image4]
                            ,[image5]
                            ,[image6]
                            ,[image7]
                            ,[image8]
                            ,[video]
                            ,[youtubelink]
                            ,[videoformat]
                      FROM [dbo].[vehicleimages]
                      WHERE [id] = @cid";
                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@cid", SqlDbType.Int).Value = Id;
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                    if (reader.HasRows)
                        return GetVehicleImageFromReader(reader, true);
                    else
                        return null;
                }
                catch (SqlException ex)
                {
                    ErrorHandler.writeSQLExceptionToLogFile(ex);
                    return null;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POC.PageElements
{
    public class Video
    {
        public string AdSetCode { get; set; }
        public string Alignment { get; set; }
        public int AutoPlay { get; set; }
        public string Description { get; set; }
        public bool DisableAdPreRoll { get; set; }
        public string EmbedCode { get; set; }
        public int Height { get; set; }
        public int Loop { get; set; }
        public bool MaintainAspectRatio { get; set; }
        public string OoyalaId { get; set; }
        public int Order { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
        public int Transparency { get; set; }
        public int VideoLength { get; set; }
        public int Width { get; set; }
        public string Type { get; set; }

        public Video(IDataReader reader)
        {
            try
            {
                this.AdSetCode = DBUtil.Convert<string>(reader["adset_code"]);
                this.Alignment = DBUtil.Convert<string>(reader["alignment"]);
                this.AutoPlay = DBUtil.Convert<byte>(reader["autoplay"]);
                this.Description = DBUtil.Convert<string>(reader["description"]);
                this.DisableAdPreRoll = DBUtil.Convert<bool>(reader["disable_ad_preroll"]);
                this.EmbedCode = DBUtil.Convert<string>(reader["embed_code"]);
                this.Height = DBUtil.Convert<short>(reader["height"]);
                this.Loop = DBUtil.Convert<byte>(reader["loop"]);
                this.MaintainAspectRatio = true;
                this.OoyalaId = DBUtil.Convert<string>(reader["ooyala_id"]);
                this.Order = DBUtil.Convert<int>(reader["order"]);
                this.ThumbnailUrl = DBUtil.Convert<string>(reader["thumbnail_url"]);
                this.Title = DBUtil.Convert<string>(reader["title"]);
                this.Transparency = DBUtil.Convert<byte>(reader["video_wmode_id"]);
                this.VideoLength = DBUtil.Convert<int>(reader["video_length_ms"]);
                this.Width = DBUtil.Convert<short>(reader["width"]);
                this.Type = "Video";
            }
            catch (Exception ex)
            {
                throw new Exception("Error with video");
            }
        }
    }
}

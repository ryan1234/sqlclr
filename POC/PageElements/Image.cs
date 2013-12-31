using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POC.PageElements
{
    public class Image
    {
        public string Alignment { get; set; }
        public string AltText { get; set; }
        public string Caption { get; set; }
        public long FileMasterId { get; set; }
        public string FileName { get; set; }
        public string ImageSize { get; set; }
        public int Order { get; set; }
        public bool ShowInGallery { get; set; }
        public string TextWrap { get; set; }
        public string Type { get; set; }

        public Image(IDataReader reader)
        {
            try
            {
                this.Alignment = DBUtil.Convert<string>(reader["alignment"]);
                this.AltText = DBUtil.Convert<string>(reader["alt_text"]);
                this.Caption = DBUtil.Convert<string>(reader["caption"]);
                this.FileMasterId = DBUtil.Convert<long>(reader["file_master_id"]);
                this.FileName = DBUtil.Convert<string>(reader["name"]);
                this.ImageSize = DBUtil.Convert<string>(reader["size"]);
                this.Order = DBUtil.Convert<int>(reader["order"]);
                this.ShowInGallery = DBUtil.Convert<bool>(reader["show_in_gallery"]);
                this.TextWrap = DBUtil.Convert<string>(reader["text_wrap_type"]);
                this.Type = "Image";
            }
            catch (Exception ex)
            {
                throw new Exception("Error with image!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POC.PageElements
{
    public class ImageGroup
    {
        public int Id { get; set; }
        public string Alignment { get; set; }
        public List<Image> Images { get; set; }
        public int ImagesPerLine { get; set; }
        public int Order { get; set; }
        public string TextWrap { get; set; }
        public string Type { get; set; }

        public ImageGroup(IDataReader reader)
        {
            try
            {
                this.Id = DBUtil.Convert<int>(reader["cms_image_group_id"]);
                this.Alignment = DBUtil.Convert<string>(reader["alignment"]);
                this.ImagesPerLine = DBUtil.Convert<short>(reader["images_per_line"]);
                this.Order = DBUtil.Convert<int>(reader["order"]);
                this.TextWrap = DBUtil.Convert<string>(reader["text_wrap_type"]);
                this.Type = "ImageGroup";
            }
            catch (Exception ex)
            {
                throw new Exception("Error with image group!");
            }
        }
    }
}

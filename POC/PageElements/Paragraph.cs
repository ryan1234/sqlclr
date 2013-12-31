using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POC.PageElements
{
    public class Paragraph
    {
        public int Id { get; set; }
        public Image Image { get; set; }
        public int Order { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }

        public Paragraph(IDataReader reader)
        {
            try
            {
                this.Id = DBUtil.Convert<int>(reader["paragraph_id"]);
                this.Order = DBUtil.Convert<int>(reader["order"]);
                this.Text = DBUtil.Convert<string>(reader["text"]);
                this.Type = "Paragraph";
            }
            catch (Exception ex)
            {
                throw new Exception("Error with paragraph " + reader["paragraph_id"] + " " + ex.StackTrace);
            }
        }
    }
}

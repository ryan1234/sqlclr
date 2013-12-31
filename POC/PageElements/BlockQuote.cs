using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POC.PageElements
{
    public class BlockQuote
    {
        public string Alignment { get; set; }
        public int Order { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }

        public BlockQuote(IDataReader reader)
        {
            try
            {
                this.Alignment = DBUtil.Convert<string>(reader["alignment"]);
                this.Order = DBUtil.Convert<int>(reader["order"]);
                this.Text = DBUtil.Convert<string>(reader["quote_text"]);
                this.Type = "BlockQuote";
            }
            catch (Exception ex)
            {
                throw new Exception("Error with block quote.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POC.PageElements
{
    public class Table
    {
        public int Order { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }

        public Table(IDataReader reader)
        {
            try
            {
                this.Order = DBUtil.Convert<int>(reader["order"]);
                this.Text = DBUtil.Convert<string>(reader["table_data"]).ToString().Trim();
                this.Type = "Table";
            }
            catch (Exception ex)
            {
                throw new Exception("Error with table " + reader["inline_table_id"]);
            }
        }
    }
}

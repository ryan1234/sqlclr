using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace POC
{
    public class Page
    {
        public int? Id { get; set; }
        public string MetaDescription { get; set; }
        public List<string> MetaKeywords { get; set; }
        public string MetaTitle { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public List<Object> PageElements { get; set; }
        public string Sponsor { get; set; }

        public Page(IDataReader reader)
        {
            try
            {
                this.Id = DBUtil.Convert<int?>(reader["page_id"]);
                this.MetaDescription = DBUtil.Convert<string>(reader["seo_meta_description"]);

                string metaKeywords = DBUtil.Convert<string>(reader["seo_meta_keywords"]) ?? "";
                this.MetaKeywords = (metaKeywords.Contains(',')) ? metaKeywords.Split(',').Select(s => s.Trim()).ToList() : new List<string>() { metaKeywords };

                this.MetaTitle = DBUtil.Convert<string>(reader["seo_meta_title"]);
                this.Name = DBUtil.Convert<string>(reader["page_name"]);
                this.Order = DBUtil.Convert<int>(reader["page_order"]);
                this.Sponsor = DBUtil.Convert<string>(reader["sponsor_name"]);

                this.PageElements = new List<object>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error with article " + reader["article_id"] + " " + ex.StackTrace);
            }
        }
    }
}

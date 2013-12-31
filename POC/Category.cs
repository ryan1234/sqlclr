using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POC
{
    public class Category
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Alias { get; set; }
        public int ParentId { get; set; }
        public string FullPath { get; set; }
        public int SiteId { get; set; }
        public int ArticleCount { get; set; }
        public bool HasChildren { get; set; }

        public Category(IDataReader reader)
        {
            this.Id = DBUtil.Convert<int>(reader["cms_category_id"]);
            this.CategoryId = this.Id;
            this.Name = DBUtil.Convert<string>(reader["name"]);
            this.Alias = DBUtil.Convert<string>(reader["category_alias"]);
            this.ParentId = DBUtil.Convert<int>(reader["cms_category_id_parent"]);
            this.FullPath = DBUtil.Convert<string>(reader["full_path"]);
            this.SiteId = DBUtil.Convert<int>(reader["entity_id_website"]);
        }
    }
}

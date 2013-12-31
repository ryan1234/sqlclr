using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POC
{
    public class Contributor
    {
        public string Bio { get; set; }
        public string DisplayName { get; set; }
        public bool EnableBioPage { get; set; }
        public long FileMasterId { get; set; }
        public string FirstName { get; set; }
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string LastName { get; set; }
        public List<SocialLink> SocialLinks { get; set; }

        public Contributor(IDataReader reader)
        {
            this.Bio = DBUtil.Convert<string>(reader["text_bio"]) ?? "";
            this.DisplayName = DBUtil.Convert<string>(reader["name_display"]);
            this.EnableBioPage = DBUtil.Convert<bool>(reader["enable_on_bio_page"]);
            this.FileMasterId = DBUtil.Convert<long>(reader["pic_file_master_id"]);
            this.FirstName = DBUtil.Convert<string>(reader["name_first"]) ?? "";
            this.Id = DBUtil.Convert<int>(reader["contributor_id"]);
            this.JobTitle = DBUtil.Convert<string>(reader["job_title"]) ?? "";
            this.LastName = DBUtil.Convert<string>(reader["name_last"]) ?? "";
        }
    }
}

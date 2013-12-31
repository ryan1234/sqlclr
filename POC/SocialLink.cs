using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace POC
{
    public class SocialLink
    {
        public int Id { get; set; }
        public string LinkType { get; set; }
        public string LinkUrl { get; set; }

        public SocialLink(IDataReader reader)
        {
            this.Id = DBUtil.Convert<int>(reader["contributor_social_link_id"]);
            this.LinkType = GetSocialLinkType(DBUtil.Convert<short>(reader["social_link_type_id"]));
            this.LinkUrl = DBUtil.Convert<string>(reader["social_link"]);
        }

        private string GetSocialLinkType(int i)
        {
            switch (i)
            {
                case 1: return "Twitter";
                case 2: return "Facebook";
                case 3: return "Google+";
                case 4: return "RSS";
                case 5: return "Tumblr";
                case 6: return "Email";
                case 7: return "LinkedIn";
                case 8: return "Personal Site";
                default: return string.Empty;
            }
        }
    }
}

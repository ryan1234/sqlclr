using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace POC
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Slug { get; set; }
        public string PromoTitle { get; set; }
        public string PromoTeaserSmall { get; set; }
        public string PromoTeaser { get; set; }
        public List<string> Keywords { get; set; }
        public string MetaTitle { get; set; }
        public List<string> MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public int WebsiteId { get; set; }
        public string PublicationDate { get; set; }
        public string PrintCoverDate { get; set; }
        public string ReleaseDate { get; set; }
        public int EventYear { get; set; }
        public string EventLocation { get; set; }
        public string ArticleType { get; set; }
        public bool WebExclusive { get; set; }
        public string Url { get; set; }
        public int ArticleId { get; set; }
        public List<Contributor> Contributors { get; set; }
        public List<Category> Categories { get; set; }
        public List<RelatedArticle> RelatedArticles { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        //public List<HeaderImage> HeaderImages { get; set; }
        public List<Page> Pages { get; set; }
        public List<string> Tags { get; set; }

        public Article(IDataReader reader)
        {
            try
            {
                this.Id = DBUtil.Convert<int>(reader["article_id"]);
                this.Title = DBUtil.Convert<string>(reader["title"]);
                this.SubTitle = DBUtil.Convert<string>(reader["subtitle"]);
                this.Slug = DBUtil.Convert<string>(reader["slug"]);
                this.PromoTitle = DBUtil.Convert<string>(reader["promo_title"]);
                this.PromoTeaserSmall = DBUtil.Convert<string>(reader["promo_teaser"]);
                this.PromoTeaser = DBUtil.Convert<string>(reader["promo_teaser_large"]);

                string keywords = DBUtil.Convert<string>(reader["keywords"]) ?? "";
                this.Keywords = (keywords.Contains(',')) ? keywords.Split(',').Select(s => s.Trim()).ToList() : new List<string>() { keywords };

                this.MetaTitle = DBUtil.Convert<string>(reader["seo_meta_title"]);

                string metaKeywords = DBUtil.Convert<string>(reader["seo_meta_keywords"]) ?? "";
                this.MetaKeywords = (metaKeywords.Contains(',')) ? metaKeywords.Split(',').Select(s => s.Trim()).ToList() : new List<string>() { metaKeywords };

                this.MetaDescription = DBUtil.Convert<string>(reader["seo_meta_description"]);
                this.WebsiteId = DBUtil.Convert<int>(reader["entity_id_website"]);
                this.PublicationDate = FormatJSONDate(DBUtil.Convert<DateTime>(reader["publication_date"]));
                this.PrintCoverDate = FormatJSONDate(DBUtil.Convert<DateTime>(reader["print_cover_date"]));
                this.ReleaseDate = FormatJSONDate(DBUtil.Convert<DateTime>(reader["release_date"]));
                this.EventYear = DBUtil.Convert<short>(reader["event_year"]);
                this.EventLocation = DBUtil.Convert<string>(reader["event_location"]) ?? "";
                this.ArticleType = DBUtil.Convert<string>(reader["genre"]) ?? "";
                this.WebExclusive = DBUtil.Convert<bool>(reader["web_exclusive"]);
                this.Url = string.Format("/{0}/index.html", this.Slug);
                this.ArticleId = this.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error with article " + reader["article_id"] + " " + ex.StackTrace);
            }
        }

        public string FormatJSONDate(DateTime d)
        {
            // ISO 8601
            if (d.Year == 1900)
            {
                return "1900-01-01T00:00:00.000Z";
            }

            return string.Format("{0}T{1}.000Z", d.ToString("yyyy-MM-dd"), d.ToString("HH:mm:ss"));
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

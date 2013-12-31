using System.Collections.Generic;
using System.Data;
using Microsoft.SqlServer.Server;
using POC;
using POC.PageElements;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void StoredProcedure1()
    {
        Builder builder = new Builder();
        var articles = builder.Build<Article>("exec usp_get_articles");

        foreach (var article in articles)
        {
            article.Contributors = builder.Build<Contributor>("exec usp_get_article_contributors " + article.ArticleId);
            foreach (var contributor in article.Contributors)
            {
                contributor.SocialLinks = builder.Build<SocialLink>("select * from contributor_social_link where contributor_id = " + contributor.Id);
            }

            article.Categories = builder.Build<Category>("exec usp_get_article_categories " + article.ArticleId);

            article.Pages = builder.Build<Page>("exec usp_get_article_pages " + article.ArticleId);
            foreach (var page in article.Pages)
            {
                var paragraphs = builder.Build<Paragraph>("exec usp_get_paragraphs " + page.Id);
                foreach (var paragraph in paragraphs)
                {
                    var images = builder.Build<Image>("exec usp_get_paragraph_image " + paragraph.Id);
                    paragraph.Image = (images.Count > 0) ? images.ToArray()[0] : null;
                    page.PageElements.Add(paragraph);
                }


                var tables = builder.Build<Table>("exec usp_get_tables " + page.Id);
                foreach (var table in tables)
                {
                    page.PageElements.Add(table);
                }


                var imageGroups = builder.Build<ImageGroup>("exec usp_get_image_groups " + page.Id);
                foreach (var imageGroup in imageGroups)
                {
                    var images = builder.Build<Image>("exec usp_get_image_group_images " + imageGroup.Id);
                    imageGroup.Images = (images.Count > 0) ? images : new List<Image>();
                    page.PageElements.Add(imageGroup);
                }


                var inlineImages = builder.Build<Image>("exec usp_get_inline_images " + page.Id);
                foreach (var inlineImage in inlineImages)
                {
                    page.PageElements.Add(inlineImage);
                }


                var videos = builder.Build<Video>("exec usp_get_videos " + page.Id);
                foreach (var video in videos)
                {
                    page.PageElements.Add(video);
                }


                var blockQuotes = builder.Build<BlockQuote>("exec usp_get_block_quotes " + page.Id);
                foreach (var blockQuote in blockQuotes)
                {
                    page.PageElements.Add(blockQuote);
                }
            }
        }



        SqlPipe sp;
        sp = SqlContext.Pipe;

        var dataRecord = new SqlDataRecord(
            new SqlMetaData("id", SqlDbType.Int),
            new SqlMetaData("json", SqlDbType.Text));
        sp.SendResultsStart(dataRecord);

        foreach (var article in articles)
        {
            dataRecord.SetInt32(0, article.Id);
            dataRecord.SetString(1, article.ToString());
            sp.SendResultsRow(dataRecord);
        }

        sp.SendResultsEnd();
    }
};

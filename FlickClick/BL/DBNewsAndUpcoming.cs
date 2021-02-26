using FlickClick.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.BL
{
    public class DBNewsAndUpcoming
    {
        public NewsAndUpcomingModel NewsAndUpcoming(DBConnector db)
        {
            NewsAndUpcomingModel naum = new NewsAndUpcomingModel();
            List<NewsModel> News = new List<NewsModel>();
            List<PreviewMovieModel> ComingSoon = new List<PreviewMovieModel>();

            string query = @"SELECT * FROM news ORDER BY postDate DESC LIMIT 2";
            DataTable dtable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                NewsModel nw = new NewsModel();
                nw.ID = (int)dtable.Rows[i]["ID"];
                nw.title = dtable.Rows[i]["title"].ToString();
                nw.text = dtable.Rows[i]["text"].ToString();
                nw.postDate = (DateTime)dtable.Rows[i]["postDate"];
                News.Add(nw);
            }

            query = @"SELECT * FROM movies WHERE ComingSoon='1' ORDER BY releaseDate LIMIT 2";
            dtable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                PreviewMovieModel pmm = new PreviewMovieModel();
                pmm.movieID = (int)dtable.Rows[i]["movieId"];
                pmm.title = dtable.Rows[i]["title"].ToString();
                pmm.releaseDate = (DateTime)dtable.Rows[i]["releaseDate"];
                pmm.description = dtable.Rows[i]["description"].ToString();
                pmm.picturePath = dtable.Rows[i]["picturePath"].ToString();
                ComingSoon.Add(pmm);
            }

            naum.News = News;
            naum.ComingSoon = ComingSoon;


            return naum;
        }
    }
}

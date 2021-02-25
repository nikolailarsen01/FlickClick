using FlickClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.BL
{
    public class DBNews
    {
        public List<NewsModel> GetAll(DBConnector db)
        {
            List<NewsModel> newsList = new List<NewsModel>();
            string query = "SELECT * FROM news";
            DataTable dTable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                NewsModel news = new NewsModel();
                news.ID = (int)dTable.Rows[i]["ID"];
                news.title = dTable.Rows[i]["title"].ToString();
                news.text = dTable.Rows[i]["text"].ToString();
                news.postDate = (DateTime)dTable.Rows[i]["postDate"];
                newsList.Add(news);
            }
            return newsList;
        }
        public NewsModel GetOne(DBConnector db, int id)
        {
            NewsModel news = new NewsModel();
            string query = "SELECT * FROM news WHERE ID=@ID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@ID", id);
            DataTable dTable = db.SqlSelectQuery(cmd);
            news.ID = (int)dTable.Rows[0]["ID"];
            news.title = dTable.Rows[0]["title"].ToString();
            news.text = dTable.Rows[0]["text"].ToString();
            news.postDate = (DateTime)dTable.Rows[0]["postDate"];
            return news;
        }
        public void Insert(DBConnector db, NewsModel news)
        {
            string query = "INSERT INTO `news` (`title`, `text`, `postDate`)" +
                "VALUES (@title, @text, @postDate)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@title", news.title);
            cmd.Parameters.AddWithValue("@text", news.text);
            cmd.Parameters.AddWithValue("@postDate", DateTime.Now.ToString("yyyy-MM-dd"));
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void Update(DBConnector db, NewsModel news)
        {
            string query = "UPDATE `news` SET title=@title, text=@text WHERE ID=@ID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@title", news.title);
            cmd.Parameters.AddWithValue("@text", news.text);
            cmd.Parameters.AddWithValue("@ID", news.ID);
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void Delete(DBConnector db, int id)
        {
            string query = "DELETE FROM `news` WHERE ID=@ID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@ID", id);
            db.sqlDeleteQuery(cmd);
        }
    }
}

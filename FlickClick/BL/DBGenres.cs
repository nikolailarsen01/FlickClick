using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FlickClick.Models;
using MySql.Data.MySqlClient;

namespace FlickClick.BL
{
    public class DBGenres
    {
        public List<GenreModel> GetAll(DBConnector db)
        {
            List<GenreModel> genres = new List<GenreModel>();
            string query = "SELECT * FROM genres";
            DataTable dTable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                GenreModel genre = new GenreModel();
                genre.genreID = (int)dTable.Rows[i]["genreID"];
                genre.genreName = dTable.Rows[i]["genreName"].ToString();
                genres.Add(genre);
            }
            return genres;
        }
        public GenreModel GetOne(DBConnector db, int id)
        {
            GenreModel genre = new GenreModel();
            string query = "SELECT * FROM genres WHERE genreID=@genreID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@genreID", id);
            DataTable dTable = db.SqlSelectQuery(cmd);
            genre.genreID = (int)dTable.Rows[0]["genreID"];
            genre.genreName = dTable.Rows[0]["genreName"].ToString();
            return genre;
        }
        public void Insert(DBConnector db, GenreModel genre)
        {
            string query = "INSERT INTO `genres` (`genreName`)" +
                "VALUES (@genreName)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@genreName", genre.genreName);
            db.sqlUpdateOrAddQuery(cmd);
        }
        public void Update(DBConnector db, GenreModel genre)
        {
            string query = "UPDATE `genres` SET genreName=@genreName WHERE genreID=@genreID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@genreName", genre.genreName);
            cmd.Parameters.AddWithValue("@genreID", genre.genreID);
            db.sqlUpdateOrAddQuery(cmd);
        }
        public void Delete(DBConnector db, int id)
        {
            string query = "DELETE FROM `genres` WHERE genreID=@genreID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@genreID", id);
            db.sqlDeleteQuery(cmd);
        }
    }
}

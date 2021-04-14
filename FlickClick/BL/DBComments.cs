using FlickClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.BL
{
    public class DBComments
    {
        public List<CommentModel> GetAll(DBConnector db)
        {
            List<CommentModel> comments = new List<CommentModel>();
            string query = "SELECT comments.*, commentjunction.movieID, emailusers.email, movies.title FROM `comments` " +
                "INNER JOIN commentjunction ON comments.commentID = commentjunction.commentID " +
                "INNER JOIN movies ON commentjunction.movieID = movies.movieID " +
                "INNER JOIN emailusers ON comments.userID = emailusers.userID";
            DataTable dTable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                CommentModel comment = new CommentModel();
                comment.ID = (int)dTable.Rows[i]["commentID"];
                comment.userID = (int)dTable.Rows[i]["userID"];
                comment.username = dTable.Rows[i]["email"].ToString();
                comment.dateTime = (DateTime)dTable.Rows[i]["postDate"];
                comment.comment = dTable.Rows[i]["text"].ToString();
                comment.movieID = (int)dTable.Rows[i]["movieID"];
                comments.Add(comment);
            }
            return comments;
        }
        public CommentModel GetOne(DBConnector db, int id)
        {
            CommentModel comment = new CommentModel();
            string query = "SELECT comments.*, commentjunction.movieID, emailusers.email, movies.title FROM `comments` " +
                "INNER JOIN commentjunction ON comments.commentID = commentjunction.commentID " +
                "INNER JOIN movies ON commentjunction.movieID = movies.movieID " +
                "INNER JOIN emailusers ON comments.userID = emailusers.userID " +
                "WHERE commentID=@commentID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@commentID", id);
            DataTable dTable = db.SqlSelectQuery(cmd);
            comment.ID = (int)dTable.Rows[0]["commentID"];
            comment.userID = (int)dTable.Rows[0]["userID"];
            comment.username = dTable.Rows[0]["email"].ToString();
            comment.dateTime = (DateTime)dTable.Rows[0]["postDate"];
            comment.comment = dTable.Rows[0]["text"].ToString();
            comment.movieID = (int)dTable.Rows[0]["movieID"];
            return comment;
        }
        public void Delete(DBConnector db, int id)
        {
            string query = "DELETE FROM comments WHERE commentID=@commentID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@commentID", id);
            db.sqlDeleteQuery(cmd);
        }
    }
}

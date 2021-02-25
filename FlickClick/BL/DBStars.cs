using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FlickClick.Models;
using MySql.Data.MySqlClient;

namespace FlickClick.BL
{
    public class DBStars
    {
        public List<StarModel> GetAll(DBConnector db)
        {
            List<StarModel> stars = new List<StarModel>();
            string query = "SELECT * FROM stars";
            DataTable dTable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                StarModel star = new StarModel();
                star.starID = (int)dTable.Rows[i]["starID"];
                star.firstName = dTable.Rows[i]["firstName"].ToString();
                star.lastName = dTable.Rows[i]["lastName"].ToString();
                star.dateOfBirth = (DateTime)dTable.Rows[i]["dateOfBirth"];
                stars.Add(star);
            }
            return stars;
        }
        public StarModel GetOne(DBConnector db, int id)
        {
            StarModel star = new StarModel();
            string query = "SELECT * FROM stars WHERE starID=@starID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@starID", id);
            DataTable dTable = db.SqlSelectQuery(cmd);
            star.starID = (int)dTable.Rows[0]["starID"];
            star.firstName = dTable.Rows[0]["firstName"].ToString();
            star.lastName = dTable.Rows[0]["lastName"].ToString();
            star.dateOfBirth = (DateTime)dTable.Rows[0]["dateOfBirth"];
            return star;
        }
        public void Insert(DBConnector db, StarModel star)
        {
            string query = "INSERT INTO `stars` (`firstName`, `lastName`, `dateOfBirth`)" +
                "VALUES (@firstName, @lastName, @dateOfBirth)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@firstName", star.firstName);
            cmd.Parameters.AddWithValue("@lastName", star.lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", star.dateOfBirth.ToString("yyyy-MM-dd"));
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void Update(DBConnector db, StarModel star)
        {
            string query = "UPDATE `stars` SET firstName=@firstName, lastName=@lastName, dateOfBirth=@dateOfBirth WHERE starID=@starID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@firstName", star.firstName);
            cmd.Parameters.AddWithValue("@lastName", star.lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", star.dateOfBirth.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@starID", star.starID);
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void Delete(DBConnector db, int id)
        {
            string query = "DELETE FROM `stars` WHERE starID=@starID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@starID", id);
            db.sqlDeleteQuery(cmd);
        }
    }
}

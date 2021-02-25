using FlickClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FlickClick
{
    public class DBDirectors
    {
        public List<DirectorModel> getDirectors(DBConnector db)
        {
            List<DirectorModel> directors = new List<DirectorModel>();
            string query = "SELECT * FROM directors WHERE NOT directorID=1";
            DataTable dtable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DirectorModel director = new DirectorModel();
                director.directorID = (int)dtable.Rows[i]["directorID"];
                director.firstName = dtable.Rows[i]["firstName"].ToString();
                director.lastName = dtable.Rows[i]["lastName"].ToString();
                director.dateOfBirth = (DateTime)dtable.Rows[i]["dateOfBirth"];
                directors.Add(director);
            }
            return directors;
        }
        public DirectorModel GetOne(DBConnector db, int id)
        {
            DirectorModel dirMod = new DirectorModel();
            string query = "SELECT * FROM directors WHERE directorID=@directorID AND NOT directorID=1";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@directorID", id);
            DataTable dTable = db.SqlSelectQuery(cmd);
            dirMod.directorID = (int)dTable.Rows[0]["directorID"];
            dirMod.firstName = dTable.Rows[0]["firstName"].ToString();
            dirMod.lastName = dTable.Rows[0]["lastName"].ToString();
            dirMod.dateOfBirth = (DateTime)dTable.Rows[0]["dateOfBirth"];
            return dirMod;
        }
        public void Insert(DBConnector db, DirectorModel dirMod)
        {
            string query = "INSERT INTO `directors` (`firstName`, `lastName`, `dateOfBirth`) " +
                "VALUES (@firstName, @lastName, @dateOfBirth)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@firstName", dirMod.firstName);
            cmd.Parameters.AddWithValue("@lastName", dirMod.lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", dirMod.dateOfBirth.ToString("yyyy-MM-dd"));
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void Update(DBConnector db, DirectorModel dirMod)
        {
            string query = "UPDATE `directors` SET firstName=@firstName, lastName=@lastName, dateOfBirth=@dateOfBirth WHERE directorID=@directorID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@firstName", dirMod.firstName);
            cmd.Parameters.AddWithValue("@lastName", dirMod.lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", dirMod.dateOfBirth.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@directorID", dirMod.directorID);
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void Delete(DBConnector db, int id)
        {
            string query = "UPDATE `movies` SET directorID=1 WHERE directorID=@directorID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@directorID", id);
            db.sqlDeleteQuery(cmd);

            query = "DELETE FROM `directors` WHERE directorID=@directorID";
            cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@directorID", id);
            db.sqlDeleteQuery(cmd);
        }
    }
}

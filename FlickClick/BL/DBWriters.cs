using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FlickClick.Models;
using MySql.Data.MySqlClient;

namespace FlickClick.BL
{
    public class DBWriters
    {
        public List<WriterModel> GetAll(DBConnector db)
        {
            List<WriterModel> writers = new List<WriterModel>();
            string query = "SELECT * FROM writers";
            DataTable dTable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                WriterModel writer = new WriterModel();
                writer.writerID = (int)dTable.Rows[i]["writerID"];
                writer.firstName = dTable.Rows[i]["firstName"].ToString();
                writer.lastName = dTable.Rows[i]["lastName"].ToString();
                writer.dateOfBirth = (DateTime)dTable.Rows[i]["dateOfBirth"];
                writers.Add(writer);
            }
            return writers;
        }
        public WriterModel GetOne(DBConnector db, int id)
        {
            WriterModel writer = new WriterModel();
            string query = "SELECT * FROM writers WHERE writerID=@writerID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@writerID", id);
            DataTable dTable = db.SqlSelectQuery(cmd);
            writer.writerID = (int)dTable.Rows[0]["writerID"];
            writer.firstName = dTable.Rows[0]["firstName"].ToString();
            writer.lastName = dTable.Rows[0]["lastName"].ToString();
            writer.dateOfBirth = (DateTime)dTable.Rows[0]["dateOfBirth"];
            return writer;
        }
        public void Insert(DBConnector db, WriterModel writer)
        {
            string query = "INSERT INTO `writers` (`firstName`, `lastName`, `dateOfBirth`)" +
                "VALUES (@firstName, @lastName, @dateOfBirth)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@firstName", writer.firstName);
            cmd.Parameters.AddWithValue("@lastName", writer.lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", writer.dateOfBirth.ToString("yyyy-MM-dd"));
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void Update(DBConnector db, WriterModel writer)
        {
            string query = "UPDATE `writers` SET firstName=@firstName, lastName=@lastName, dateOfBirth=@dateOfBirth WHERE writerID=@writerID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@firstName", writer.firstName);
            cmd.Parameters.AddWithValue("@lastName", writer.lastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", writer.dateOfBirth.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@writerID", writer.writerID);
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void Delete(DBConnector db, int id)
        {
            string query = "DELETE FROM `writers` WHERE writerID=@writerID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@writerID", id);
            db.sqlDeleteQuery(cmd);
        }
    }
}

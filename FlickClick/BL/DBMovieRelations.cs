using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.BL
{
    public class DBMovieRelations
    {
        public List<int> GetIDs(DBConnector db, int movieID, string name)
        {
            List<int> IDs = new List<int>();
            string query = "SELECT DISTINCT "+name+"ID FROM "+name+"junction WHERE movieID=@movieID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("movieID", movieID);
            DataTable dTable = db.SqlSelectQuery(cmd);
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                IDs.Add((int)dTable.Rows[i][name+"ID"]);
            }
            return IDs;
        }
        public void Save(DBConnector db, int id, int movieID, string table, string column)
        {
            string query = "INSERT INTO "+table+" (`movieID`, `"+column+"`) VALUES (@movieID, @id)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@movieID", movieID);
            cmd.Parameters.AddWithValue("@id", id);
            db.sqlUpdateOrAddQuery(cmd);
        }
        public void Delete(DBConnector db, int id, int movieID, string table, string column)
        {
            string query = "DELETE FROM " + table + " WHERE movieID=@movieID AND " + column + "=@id";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@movieID", movieID);
            cmd.Parameters.AddWithValue("@id", id);
            db.sqlDeleteQuery(cmd);
        }

    }
}

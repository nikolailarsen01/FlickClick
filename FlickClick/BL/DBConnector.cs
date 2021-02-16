using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace FlickClick
{
    public class DBConnector
    {
        private string connectionString;
        private MySqlConnection connection;
        public DBConnector()
        {
            connectionString = "server=localhost;userid=root;database=steensoft_dk_flickclick;";
        }
        ~DBConnector() { }

        public bool makeConnection()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection.Ping();
        }
        public DataTable sqlSelectQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter dtb = new MySqlDataAdapter();
            dtb.SelectCommand = command;
            DataTable dtable = new DataTable();
            dtb.Fill(dtable);

            return dtable;
        }
        public void sqlUpdateQuery(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void closeConnection()
        {
            connection.Close();
        }
    }
}

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
            connectionString = "server=localhost;userid=normal;password=Normal123;database=steensoft_dk_flickclick;";
            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        ~DBConnector() { }

        public bool makeConnection()
        {
            return connection.Ping();
        }
        public DataTable sqlSelectQueryOld(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter dtb = new MySqlDataAdapter();
            dtb.SelectCommand = command;
            DataTable dtable = new DataTable();
            dtb.Fill(dtable);

            return dtable;
        }
        public DataTable SqlSelectQuery(MySqlCommand cmd)
        {
            cmd.Connection = connection;
            MySqlDataAdapter dap = new MySqlDataAdapter();
            dap.SelectCommand = cmd;
            DataTable dtb = new DataTable();
            dap.Fill(dtb);
            return dtb;
        }
        public void sqlUpdateOrAddQuery(MySqlCommand cmd)
        {
            cmd.Connection = connection;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void sqlDeleteQuery(MySqlCommand cmd)
        {
            cmd.Connection = connection;
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
        public void closeConnection()
        {
            connection.Close();
        }
    }
}

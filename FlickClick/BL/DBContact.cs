using FlickClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FlickClick.BL
{
    public class DBContact
    {
        public List<ContactModel> GetAll(DBConnector db)
        {
            List<ContactModel> contacts = new List<ContactModel>();
            string query = "SELECT * FROM contact";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            DataTable dTable = db.SqlSelectQuery(cmd);
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                ContactModel contact = new ContactModel();
                contact.ID = (int)dTable.Rows[i]["ID"];
                contact.contactName = dTable.Rows[i]["contactName"].ToString();
                contact.contactMail = dTable.Rows[i]["contactMail"].ToString();
                contact.message = dTable.Rows[i]["message"].ToString();
                contacts.Add(contact);
            }
            return contacts;
        }
        public ContactModel GetOne(DBConnector db, int id)
        {
            ContactModel contact = new ContactModel();
            string query = "SELECT * FROM contact WHERE ID=@ID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@ID", id);
            DataTable dTable = db.SqlSelectQuery(cmd);
            contact.ID = (int)dTable.Rows[0]["ID"];
            contact.contactName = dTable.Rows[0]["contactName"].ToString();
            contact.contactMail = dTable.Rows[0]["contactMail"].ToString();
            contact.message = dTable.Rows[0]["message"].ToString();
            return contact;
        }
        public void Insert(DBConnector db, ContactModel contact)
        {
            string query = "INSERT INTO `contact` (`contactName`, `contactMail`, `message`)" +
                "VALUES (@contactName, @contactMail, @message)";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@contactName", contact.contactName);
            cmd.Parameters.AddWithValue("@contactMail", contact.contactMail);
            cmd.Parameters.AddWithValue("@message", contact.message);
            db.sqlUpdateOrInsertQuery(cmd);
        }
        public void Delete(DBConnector db, int id)
        {
            string query = "DELETE FROM `contact` WHERE ID=@ID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@ID", id);
            db.sqlDeleteQuery(cmd);
        }
    }
}

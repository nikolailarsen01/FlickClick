using FlickClick.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick.BL
{
    public class DBUser
    {
        public string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
        public string HashPassword(string password, string salt)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(salt + password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        public string GetSalt(DBConnector db, string email, string tableName)
        {
            //Table name is either user or admin
            string query = "SELECT * FROM email"+tableName+"s WHERE email=@email";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@email", email);
            DataTable dTable = db.SqlSelectQuery(cmd);
            if (dTable.Rows.Count > 0)
            {
                int ID = (int)dTable.Rows[0][ tableName+ "ID"];
                MySqlDataAdapter dtb = new MySqlDataAdapter();
                query = "SELECT passwordSalt FROM "+tableName+"s WHERE "+tableName+"ID=@ID";
                cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@ID", ID);
                dTable = db.SqlSelectQuery(cmd);
                if (dTable.Rows.Count > 0)
                {
                    return dTable.Rows[0]["passwordSalt"].ToString();
                }
                else return "empty";
            }
            else return "empty";
        }
        public Tuple<UserModel, bool> CheckUserLogin(DBConnector db, string email, string password)
        {
            UserModel user = new UserModel();
            string query = "SELECT * FROM emailusers WHERE email=@email";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@email", email);
            DataTable dTable = db.SqlSelectQuery(cmd);
            if (dTable.Rows.Count > 0)
            {
                int userID = (int)dTable.Rows[0]["userID"];
                MySqlDataAdapter dtb = new MySqlDataAdapter();
                query = "SELECT userID, firstnames.firstName FROM users INNER JOIN firstnames ON users.firstNameID = firstnames.firstNameID WHERE userID=@userID AND password=@password";
                cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@password", password);
                dTable = db.SqlSelectQuery(cmd);
                if (dTable.Rows.Count > 0)
                {
                    user.userID = (int)dTable.Rows[0]["userID"];
                    user.firstName = dTable.Rows[0]["firstName"].ToString();

                    return Tuple.Create(user, true);
                }
                else return Tuple.Create(user, false);
            }
            else return Tuple.Create(user, false);
        }
        public Tuple<List<string>, bool> CheckAdminLogin(DBConnector db, string email, string password)
        {
            List<string> output = new List<string>();
            string query = "SELECT * FROM emailadmins WHERE email=@email";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@email", email);
            DataTable dTable = db.SqlSelectQuery(cmd);
            if (dTable.Rows.Count > 0)
            {
                int userID = (int)dTable.Rows[0]["adminID"];
                output.Add(dTable.Rows[0]["email"].ToString());
                MySqlDataAdapter dtb = new MySqlDataAdapter();
                query = "SELECT * FROM admins WHERE adminID=@adminID AND password=@password";
                cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@adminID", userID);
                cmd.Parameters.AddWithValue("@password", password);
                dTable = db.SqlSelectQuery(cmd);
                if (dTable.Rows.Count > 0)
                {
                    output.Add(dTable.Rows[0]["adminID"].ToString());

                    return Tuple.Create(output, true);
                }
                else return Tuple.Create(output, false);
            }
            else return Tuple.Create(output, false);
        }
        public Tuple<UserModel, bool> CheckUserRegister(DBConnector db, UserModel user)
        {
            int postalCodeID = 0;
            int streetNameID = 0;

            int addressID = 0;
            int firstNameID = 0;
            int lastNameID = 0;

            string query = "SELECT * FROM citycodes WHERE postalCode=@postalCode";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@postalCode", user.postalCode);
            DataTable dTable = db.SqlSelectQuery(cmd);
            if (dTable.Rows.Count > 0)
            {
                postalCodeID = (int)dTable.Rows[0]["cityID"];
            }
            else
            {
                query = "INSERT INTO `citycodes`(`postalCode`) VALUES (@postalCode)";
                cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@postalCode", user.postalCode);
                db.sqlUpdateOrInsertQuery(cmd);
                postalCodeID = Convert.ToInt32(cmd.LastInsertedId);
            }

            //streetName
            
            query = "SELECT * FROM streetnames WHERE streetName=@streetName";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@streetName", user.streetName);
            dTable = db.SqlSelectQuery(cmd);
            if (dTable.Rows.Count > 0)
            {
                streetNameID = (int)dTable.Rows[0]["streetID"];
            }
            else
            {
                query = "INSERT INTO `streetnames`(`streetName`) VALUES (@streetName)";
                cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@streetName", user.streetName);
                db.sqlUpdateOrInsertQuery(cmd);
                streetNameID = Convert.ToInt32(cmd.LastInsertedId);
            }

            //Address
            query = "SELECT * FROM addressjunction WHERE cityID=@postalCodeID AND streetID=@streetNameID AND houseNumber=@houseNumber";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@postalCodeID", postalCodeID);
            cmd.Parameters.AddWithValue("@streetNameID", streetNameID);
            cmd.Parameters.AddWithValue("@houseNumber", user.houseNumber);
            dTable = db.SqlSelectQuery(cmd);
            if (dTable.Rows.Count > 0)
            {
                addressID = (int)dTable.Rows[0]["ID"];
            }
            else
            {
                query = "INSERT INTO `addressjunction`(`cityID`, `streetID`, `houseNumber`) VALUES (@postalCodeID, @streetNameID, @houseNumber)";
                cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@postalCodeID", postalCodeID);
                cmd.Parameters.AddWithValue("@streetNameID", streetNameID);
                cmd.Parameters.AddWithValue("@houseNumber", user.houseNumber);
                db.sqlUpdateOrInsertQuery(cmd);
                addressID = Convert.ToInt32(cmd.LastInsertedId);
            }

            //firstName
            query = "SELECT * FROM firstnames WHERE firstName=@firstName";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@firstName", user.firstName);
            dTable = db.SqlSelectQuery(cmd);
            if (dTable.Rows.Count > 0)
            {
                firstNameID = (int)dTable.Rows[0]["firstNameID"];
            }
            else
            {
                query = "INSERT INTO `firstnames`(`firstName`) VALUES (@firstName)";
                cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@firstName", user.firstName);
                db.sqlUpdateOrInsertQuery(cmd);
                firstNameID = Convert.ToInt32(cmd.LastInsertedId);
            }

            //lastName
            query = "SELECT * FROM lastnames WHERE lastName=@lastName";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@lastName", user.lastName);
            dTable = db.SqlSelectQuery(cmd);
            if (dTable.Rows.Count > 0)
            {
                lastNameID = (int)dTable.Rows[0]["lastNameID"];
            }
            else
            {
                query = "INSERT INTO `lastnames`(`lastName`) VALUES (@lastName)";
                cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@lastName", user.lastName);
                db.sqlUpdateOrInsertQuery(cmd);
                lastNameID = Convert.ToInt32(cmd.LastInsertedId);
            }
            //user insert
            query = "SELECT * FROM emailusers WHERE email=@email";
            cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@email", user.email);
            dTable = db.SqlSelectQuery(cmd);
            if (dTable.Rows.Count > 0)
            {
                return Tuple.Create(user, false);
            }
            else
            {
                query = "INSERT INTO `users`(`firstNameID`, `lastNameID`, `addressID`, `password`, `passwordSalt`, `phoneNumber`, `userSince`)" +
                " VALUES (@firstNameID, @lastNameID, @addressID, @password, @passwordSalt, @phoneNumber, @userSince)";
                cmd = new MySqlCommand(query);
                String salt = GenerateSalt();
                cmd.Parameters.AddWithValue("@firstNameID", firstNameID);
                cmd.Parameters.AddWithValue("@lastNameID", lastNameID);
                cmd.Parameters.AddWithValue("@addressID", addressID);
                cmd.Parameters.AddWithValue("@password", HashPassword(user.password, salt));
                cmd.Parameters.AddWithValue("@passwordSalt", salt);
                cmd.Parameters.AddWithValue("@phoneNumber", user.phoneNumber);
                cmd.Parameters.AddWithValue("@userSince", DateTime.Now.ToString("yyyy-MM-dd"));
                db.sqlUpdateOrInsertQuery(cmd);

                int userID = Convert.ToInt32(cmd.LastInsertedId);
                query = "INSERT INTO `emailusers` (`userID`, `email`) VALUES (@userID, @email)";
                cmd = new MySqlCommand(query);
                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@email", user.email);
                db.sqlUpdateOrInsertQuery(cmd);
                return Tuple.Create(user, true);
            }
        }
    }
}

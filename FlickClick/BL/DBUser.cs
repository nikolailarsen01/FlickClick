using FlickClick.Models;
using Microsoft.AspNetCore.Hosting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick.BL
{
    public class DBUser
    {
        private readonly IWebHostEnvironment rootPath;
        public DBUser() { }
        public DBUser(IWebHostEnvironment env)
        {
            rootPath = env;
        }
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
        public async Task<Tuple<UserModel, bool>> CheckUserRegisterAsync(DBConnector db, UserModel user)
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
                string profilePicPath = SaveAndGetPicPath(user);
                query = "INSERT INTO `users`(`firstNameID`, `lastNameID`, `addressID`, `password`, `passwordSalt`, `phoneNumber`, `profilePicPath`, `userSince`)" +
                " VALUES (@firstNameID, @lastNameID, @addressID, @password, @passwordSalt, @phoneNumber, @profilePicPath, @userSince)";
                cmd = new MySqlCommand(query);
                String salt = GenerateSalt();
                cmd.Parameters.AddWithValue("@firstNameID", firstNameID);
                cmd.Parameters.AddWithValue("@lastNameID", lastNameID);
                cmd.Parameters.AddWithValue("@addressID", addressID);
                cmd.Parameters.AddWithValue("@password", HashPassword(user.password, salt));
                cmd.Parameters.AddWithValue("@passwordSalt", salt);
                cmd.Parameters.AddWithValue("@phoneNumber", user.phoneNumber);
                cmd.Parameters.AddWithValue("@profilePicPath", profilePicPath);
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
        private string SaveAndGetPicPath(UserModel user)
        {
            //Fix strings
            string rawRootPath = rootPath.WebRootPath;
            string wwwRootPath = "";
            foreach (char c in rawRootPath)
            {
                if (c.ToString() == "\u005C")
                {
                    wwwRootPath += "/";
                }
                else wwwRootPath += c.ToString();
            }
            string fileName = "";
            foreach (char c in user.email)
            {
                if (c == '@') fileName += "at";
                else fileName += c.ToString();
            }
            string extension = Path.GetExtension(user.profilePic.FileName);
            string profilePicPath = "/assets/profile-pictures/" + fileName + extension;
            string path = Path.Combine(wwwRootPath + profilePicPath);
            saveProfilePicAsync(user, path);
            return profilePicPath;
        }
        private async void saveProfilePicAsync(UserModel user, string path)
        {
            //Save picture
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await user.profilePic.CopyToAsync(fileStream);
            }
        }
        public List<UserModel> GetAll(DBConnector db)
        {
            List<UserModel> userList = new List<UserModel>();
            string query = "SELECT users.userID, firstnames.firstName, lastnames.lastName, emailusers.email, citycodes.postalCode, streetnames.streetName, addressjunction.houseNumber, phoneNumber, profilePicPath, userSince FROM `users` INNER JOIN firstnames ON users.firstNameID = firstnames.firstNameID INNER JOIN lastnames ON users.lastNameID = lastnames.lastNameID INNER JOIN addressjunction ON users.addressID = addressjunction.ID INNER JOIN citycodes ON addressjunction.cityID = citycodes.cityID INNER JOIN streetnames ON addressjunction.streetID = streetnames.streetID INNER JOIN emailusers ON users.userID = emailusers.userID";
            DataTable dTable = db.sqlSelectQueryOld(query);
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                UserModel um = new UserModel();
                um.userID = (int)dTable.Rows[i]["userID"];
                um.firstName = dTable.Rows[i]["firstName"].ToString();
                um.lastName = dTable.Rows[i]["lastName"].ToString();
                um.email = dTable.Rows[i]["email"].ToString();
                um.postalCode = (int)dTable.Rows[i]["postalCode"];
                um.streetName = dTable.Rows[i]["streetName"].ToString();
                um.houseNumber = dTable.Rows[i]["houseNumber"].ToString();
                um.phoneNumber = Convert.ToInt32(dTable.Rows[i]["phoneNumber"]);
                um.profilePicPath = dTable.Rows[i]["profilePicPath"].ToString();
                um.userSince = (DateTime)dTable.Rows[i]["userSince"];
                userList.Add(um);
            }
            return userList;
        }
        public UserModel GetOne(DBConnector db, int id)
        {
            UserModel um = new UserModel();
            string query = "SELECT users.userID, firstnames.firstName, lastnames.lastName, emailusers.email, citycodes.postalCode, streetnames.streetName, addressjunction.houseNumber, phoneNumber, profilePicPath, userSince FROM `users` INNER JOIN firstnames ON users.firstNameID = firstnames.firstNameID INNER JOIN lastnames ON users.lastNameID = lastnames.lastNameID INNER JOIN addressjunction ON users.addressID = addressjunction.ID INNER JOIN citycodes ON addressjunction.cityID = citycodes.cityID INNER JOIN streetnames ON addressjunction.streetID = streetnames.streetID INNER JOIN emailusers ON users.userID = emailusers.userID WHERE users.userID=@userID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.Parameters.AddWithValue("@userID", id);
            DataTable dTable = db.SqlSelectQuery(cmd);
            um.userID = (int)dTable.Rows[0]["userID"];
            um.firstName = dTable.Rows[0]["firstName"].ToString();
            um.lastName = dTable.Rows[0]["lastName"].ToString();
            um.email = dTable.Rows[0]["email"].ToString();
            um.postalCode = (int)dTable.Rows[0]["postalCode"];
            um.streetName = dTable.Rows[0]["streetName"].ToString();
            um.houseNumber = dTable.Rows[0]["houseNumber"].ToString();
            um.phoneNumber = Convert.ToInt32(dTable.Rows[0]["phoneNumber"]);
            um.profilePicPath = dTable.Rows[0]["profilePicPath"].ToString();
            um.userSince = (DateTime)dTable.Rows[0]["userSince"];
            return um;
        }
        public void Delete(DBConnector db, int id)
        {
            string query = "DELETE FROM `emailusers` WHERE userID=@userID";
            MySqlCommand cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userID", id);
            db.sqlDeleteQuery(cmd);
            query = "DELETE FROM `users` WHERE userID=@userID";
            cmd = new MySqlCommand(query);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userID", id);
            db.sqlDeleteQuery(cmd);
        }
    }
}

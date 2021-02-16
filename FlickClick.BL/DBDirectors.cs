using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FlickClick.BL
{
    public class DBDirectors
    {
        public List<DirectorModel> getDirectors(DBConnector db)
        {
            List<DirectorModel> directors = new List<DirectorModel>();
            string query = "SELECT * FROM directors";
            DataTable dtable = db.sqlSelectQuery(query);
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
    }
}

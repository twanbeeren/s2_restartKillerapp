using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL.SQLContexts
{
    class SQLContext : ISQLContext
    {
        private static string connecstring = string.Empty;
        public bool Login(string name, string password)
        {
            int UserExist;
            using (SqlConnection conn = new SqlConnection(connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("s2_killerapp_Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_Username", name);
                    cmd.Parameters.AddWithValue("in_Password", password);
                    cmd.ExecuteNonQuery();
                    UserExist = Convert.ToInt32(cmd.ExecuteScalar());
                }
                conn.Close();
            }

            if (UserExist == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetMovies()
        {
            throw new NotImplementedException();
        }
        public List<Cinema> GetCinemas()
        {
            throw new NotImplementedException();
        }

        public List<Show> GetShows(int movieId)
        {
            throw new NotImplementedException();
        }

    }
}

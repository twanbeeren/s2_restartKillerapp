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
        private static string connecstring = "Data Source=(localdb)/MSSQLLocalDB;Initial Catalog = CinemaApp; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public bool Login(string email, string password)
        {
            int UserExist;
            using (SqlConnection conn = new SqlConnection(connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_Email", email);
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
        public User GetUser(string email)
        {
            User user = new User();
            using (SqlConnection conn = new SqlConnection(connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_Email", email);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return user;
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

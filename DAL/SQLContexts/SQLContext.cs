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

        private static string connecstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = CinemaApp; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Login(string email, string password)
        {
            int UserExist = 0;
            using (SqlConnection conn = new SqlConnection(connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_Email", email);
                    cmd.Parameters.AddWithValue("in_Password", password);
                    UserExist = (int)cmd.ExecuteScalar();
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
        public void Register(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.Register", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_Name", user.Name);
                        cmd.Parameters.AddWithValue("in_Password", user.Password);
                        cmd.Parameters.AddWithValue("in_Email", user.Email);
                        cmd.Parameters.AddWithValue("in_Age", user.Age);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public User GetUser(string email)
        {
            User user = null;
            using (SqlConnection conn = new SqlConnection(connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_Email", email);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string password = reader.GetString(2);
                            int age = reader.GetInt32(4);
                            bool admin = reader.GetBoolean(5);
                            user = new User(id, name, password, email, age, admin);
                        }
                    }
                }

                conn.Close();
            }
            return user;
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Movies", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string password = reader.GetString(2);
                            int age = reader.GetInt32(4);
                            bool admin = reader.GetBoolean(5);
                        }
                    }
                }

                conn.Close();
            }

            return movies;
        }
        public List<Cinema> GetCinemas()
        {
            throw new NotImplementedException();
        }

        public List<Show> GetShows(int movieId)
        {
            throw new NotImplementedException();
        }

        //Admin function
        public void MakeShow(Show show)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.MakeShow", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_MovieHallId", show.MovieHall.Id);
                        cmd.Parameters.AddWithValue("in_MovieId", show.Movie.Id);
                        cmd.Parameters.AddWithValue("in_Date", show.Date);
                        cmd.Parameters.AddWithValue("in_ShowDuration", show.ShowDuration);
                        cmd.Parameters.AddWithValue("in_Price", show.Price);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}

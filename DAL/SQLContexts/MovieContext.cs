using DataInterfaces.Interfaces;
using Models;
using Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.SQLContexts
{
    class MovieContext : IMovieContext
    {
        public Movie GetMovieOnId(int movieId)
        {
            Movie movie = null;
            using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetMovieOnId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_Id", movieId);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            Genre genre = (Genre)Enum.ToObject(typeof(Genre), reader.GetInt32(2));
                            DateTime date = reader.GetDateTime(3);
                            AgeRestriction ageRestriction = (AgeRestriction)Enum.ToObject(typeof(AgeRestriction), reader.GetInt32(4));
                            int duration = reader.GetInt32(5);
                            //string img_URL = reader.GetString(6);
                            movie = new Movie(id, name, genre, date, ageRestriction, duration);
                        }
                    }
                }

                conn.Close();
            }

            return movie;
        }

        public List<Movie> GetMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetMovies", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            Genre genre = (Genre)Enum.ToObject(typeof(Genre), reader.GetInt32(2));
                            DateTime date = reader.GetDateTime(3);
                            AgeRestriction agerestriction = (AgeRestriction)Enum.ToObject(typeof(AgeRestriction), reader.GetInt32(2));
                            int duration = reader.GetInt32(5);
                            //string img_url = reader.GetString(6);
                            Movie movie = new Movie(id, name, genre, date, agerestriction, duration);
                            movies.Add(movie);
                        }
                    }
                }

                conn.Close();
            }

            return movies;
        }
    }
}

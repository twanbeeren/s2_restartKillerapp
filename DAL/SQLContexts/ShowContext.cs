using DataInterfaces.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.SQLContexts
{
    class ShowContext : IShowContext
    {
        IMovieHallContext movieHallContext = new MovieHallContext();
        IMovieContext movieContext = new MovieContext();
        public Show GetShowOnId(int showId)
        {
            Show show = null;
            using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetShowOnId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_Id", showId);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int movieHallId = reader.GetInt32(1);
                            int movieId = reader.GetInt32(2);
                            DateTime date = reader.GetDateTime(3);
                            int showDuration = reader.GetInt32(4);
                            double price = reader.GetDouble(5);

                            MovieHall movieHall = movieHallContext.GetMovieHallOnId(movieHallId);
                            Movie movie = movieContext.GetMovieOnId(movieId);
                            show = new Show(movieHall, movie, date, price);
                        }
                    }
                }

                conn.Close();
            }

            return show;
        }

        public List<Show> GetShows(int movieId, int cinemaId)
        {
            List<Show> shows = new List<Show>();
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.GetShowsOnId", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_MovieId", movieId);
                        cmd.Parameters.AddWithValue("in_CinemaId", cinemaId);
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int showId = reader.GetInt32(0);
                                int movieHallId = reader.GetInt32(1);
                                DateTime date = reader.GetDateTime(2);
                                double price = reader.GetDouble(3);
                                MovieHall movieHall = new MovieHall();
                                Movie movie = new Movie();
                                movieHall = movieHallContext.GetMovieHallOnId(movieHallId);
                                movie = movieContext.GetMovieOnId(movieId);
                                Show show = new Show(showId, movieHall, movie, date, price);
                                shows.Add(show);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return shows;
        }

    }
}

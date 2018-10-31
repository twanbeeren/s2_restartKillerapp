using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Models.Enumerations;

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
            try
            {
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
            }
            catch(Exception)
            {
                return null;
            }
            return user;
        }
        public Cinema GetCinemaOnId(int cinemaId)
        {
            Cinema cinema = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.GetCinemaOnId", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_Id", cinemaId);
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string company = reader.GetString(2);
                                string place = reader.GetString(3);
                                cinema = new Cinema(id, name, company, place);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cinema;
        }
        public MovieHall GetMovieHallOnId(int moviehallId)
        {
            MovieHall movieHall = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.GetMovieHallOnId", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_Id", moviehallId);
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                int cinemaId = reader.GetInt32(1);
                                int hallNumber = reader.GetInt32(2);
                                //When I make Rows these two values are needed
                                int maxRow = reader.GetInt32(3);
                                int maxChairsInRow = reader.GetInt32(4);
                                int capacity = reader.GetInt32(5);
                                Cinema cinema = new Cinema();
                                cinema = this.GetCinemaOnId(cinemaId);
                                movieHall = new MovieHall(id, cinema, hallNumber, capacity);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return movieHall;
        }
        public Movie GetMovieOnId(int movieId)
        {
            Movie movie = null;
            using (SqlConnection conn = new SqlConnection(connecstring))
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
            using (SqlConnection conn = new SqlConnection(connecstring))
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
        public List<Cinema> GetCinemas()
        {
            List<Cinema> cinemas = new List<Cinema>();
            using (SqlConnection conn = new SqlConnection(connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetCinemas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string company = reader.GetString(2);
                            string place = reader.GetString(3);
                        }
                    }
                }

                conn.Close();
            }
            return cinemas;
        }

        public List<Show> GetShows(int movieId, int cinemaId)
        {
            List<Show> shows = new List<Show>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connecstring))
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
                                movieHall = this.GetMovieHallOnId(movieHallId);
                                movie = this.GetMovieOnId(movieId);
                                Show show = new Show(movieHall, movie, date, price);
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

        //Admin function
        public void CreateShow(Show show)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.CreateShow", conn))
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
        public void CreateCinema(Cinema cinema)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.CreateCinema", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_Name", cinema.Name);
                        cmd.Parameters.AddWithValue("in_Company", cinema.Company);
                        cmd.Parameters.AddWithValue("in_Place", cinema.Place);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataInterfaces.Interfaces;
using Models;

namespace DAL.SQLContexts
{
    class MovieHallContext : IMovieHallContext
    {
        ICinemaContext cinemaContext = new CinemaContext();
        public MovieHall GetMovieHallOnId(int moviehallId)
        {
            MovieHall movieHall = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
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
                                cinema = cinemaContext.GetCinemaOnId(cinemaId);
                                movieHall = new MovieHall(id, cinema, hallNumber, capacity);
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
            return movieHall;
        }


    }
}

using DataInterfaces.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.SQLContexts
{
    class CinemaContext : ICinemaContext
    {
        public List<Cinema> GetCinemas()
        {
            List<Cinema> cinemas = new List<Cinema>();
            using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
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
                            Cinema cinema = new Cinema(id, name, company, place);
                            cinemas.Add(cinema);
                        }
                    }
                }

                conn.Close();
            }
            return cinemas;
        }

        public Cinema GetCinemaOnId(int cinemaId)
        {
            Cinema cinema = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
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
    }
}

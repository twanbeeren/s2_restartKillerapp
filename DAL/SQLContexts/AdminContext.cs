using DataInterfaces.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.SQLContexts
{
    public class AdminContext : IAdminContext
    {
        public void CreateShow(Show show)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.CreateShow", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_MovieHallId", show.MovieHall.Id);
                        cmd.Parameters.AddWithValue("in_MovieId", (object)show.Movie.Id);
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
                using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
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

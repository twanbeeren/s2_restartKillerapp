using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataInterfaces.Interfaces;
using Models;

namespace DAL.SQLContexts
{
    public class UserContext : IUserContext
    {
        private static string connecstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = CinemaApp; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool Login(string email, string password)
        {
            int UserExist = 0;
            using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
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
                using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
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
                using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
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
            catch (Exception)
            {
                return null;
            }
            return user;
        }
        public User GetUserOnId(int userId)
        {
            User user = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.GetUserOnId", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_Id", userId);
                        cmd.ExecuteNonQuery();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string password = reader.GetString(2);
                                string email = reader.GetString(3);
                                int age = reader.GetInt32(4);
                                bool admin = reader.GetBoolean(5);
                                user = new User(id, name, password, email, age, admin);
                            }
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception)
            {
                return null;
            }
            return user;
        }
    }
}
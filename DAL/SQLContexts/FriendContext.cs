using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Models;
using DataInterfaces.Interfaces;

namespace DAL.SQLContexts
{
    class FriendContext : IFriendContext
    {
        
        public List<User> GetFriends(int userId)
        {
            IUserContext UserContext = new UserContext();
            List<User> friends = new List<User>();
            using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetFriends", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_Id", userId);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int friendId = reader.GetInt32(0);
                            
                            User user = UserContext.GetUserOnId(friendId);
                            friends.Add(user);
                        }
                    }
                }

                conn.Close();
            }

            return friends;
        }
        public List<User> GetFriendRequests(int userId)
        {
            IUserContext UserContext = new UserContext();
            List<User> friendRequests = new List<User>();
            using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetFriendRequests", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_Id", userId);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int friendId = reader.GetInt32(0);
                            User user = UserContext.GetUserOnId(friendId);
                            friendRequests.Add(user);
                        }
                    }
                }

                conn.Close();
            }

            return friendRequests;
        }
        public List<User> GetUsersOnSearch(string searchTerm)
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.GetUsersOnSearch", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("in_SearchTerm", searchTerm);
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string email = reader.GetString(2);
                            string password = reader.GetString(2);
                            int age = reader.GetInt32(4);
                            bool admin = reader.GetBoolean(5);
                            User user = new User(id, name, password, email, age, admin);
                            users.Add(user);
                        }
                    }
                }

                conn.Close();
            }

            return users;
        }
        public void SendFriendInvite(int currentUserId, int userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(DatabaseString.Connecstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.InviteFriend", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_User1Id", currentUserId);
                        cmd.Parameters.AddWithValue("in_User2Id", userId);
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

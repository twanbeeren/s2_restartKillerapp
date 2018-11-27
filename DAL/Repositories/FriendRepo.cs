using DAL.SQLContexts;
using DataInterfaces.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class FriendRepo
    {
        private readonly IFriendContext Context = new FriendContext();

        public List<User> GetFriends(int userId) => Context.GetFriends(userId);
        public List<User> GetUsersOnSearch(string searchTerm) => Context.GetUsersOnSearch(searchTerm);
        public List<User> GetFriendRequests(int userId) => Context.GetFriendRequests(userId);
        public void SendFriendInvite(int currentUserId, int userId) => Context.SendFriendInvite(currentUserId, userId);

        public void AcceptFriendInvite(int currentUserId, int userId)
        {
            throw new NotImplementedException();
        }

        public void DenyFriendInvite(int currentUserId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}

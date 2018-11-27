using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class FriendLogic
    {
        private readonly FriendRepo repo = new FriendRepo();
        public List<User> GetFriends(int userId) => repo.GetFriends(userId);
        public List<User> GetFriendRequests(int userId) => repo.GetFriendRequests(userId);
        public List<User> GetUsersOnSearch(string searchTerm) => repo.GetUsersOnSearch(searchTerm);
        public void SendFriendInvite(int currentUserId, int userId) => repo.SendFriendInvite(currentUserId, userId);
        public void AcceptFriendInvite(int currentUserId, int userId) => repo.AcceptFriendInvite(currentUserId, userId);
        public void DenyFriendInvite(int currentUserId, int userId) => repo.DenyFriendInvite(currentUserId, userId);
    }
}

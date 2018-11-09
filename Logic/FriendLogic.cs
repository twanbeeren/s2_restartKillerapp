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
        public List<User> GetUsersOnSearch(string searchTerm) => repo.GetUsersOnSearch(searchTerm);
        public void SendFriendInvite(int user1Id, int user2Id) => repo.SendFriendInvite(user1Id, user2Id);
    }
}

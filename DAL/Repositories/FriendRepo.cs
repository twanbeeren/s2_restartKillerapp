using DAL.SQLContexts;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class FriendRepo
    {
        private readonly IFriendContext friendContext = new FriendContext();

        public List<User> GetFriends(int userId) => friendContext.GetFriends(userId);
        public List<User> GetUsersOnSearch(string searchTerm) => friendContext.GetUsersOnSearch(searchTerm);
        public void SendFriendInvite(int user1Id, int user2Id) => friendContext.SendFriendInvite(user1Id, user2Id);
    }
}

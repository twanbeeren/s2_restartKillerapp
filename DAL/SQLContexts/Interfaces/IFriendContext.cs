using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLContexts
{
    interface IFriendContext
    {
        List<User> GetFriends(int userId);
        void SendFriendInvite(int user1Id, int user2Id);
        List<User> GetUsersOnSearch(string searchTerm);
    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataInterfaces.Interfaces
{
    public interface IFriendContext
    {
        List<User> GetFriends(int userId);
        void SendFriendInvite(int currentUserId, int userId);
        List<User> GetUsersOnSearch(string searchTerm);
        List<User> GetFriendRequests(int userId);
    }
}

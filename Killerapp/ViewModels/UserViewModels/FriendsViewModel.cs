using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Killerapp.ViewModels.UserViewModels
{
    public class FriendsViewModel
    {
        public User CurrentUser { get; set; }
        public List<User> Users { get; set; }
        public List<User> Friends { get; set; }
        public string SearchTerm { get; set; }
        public int AddFriendId { get; set; }
    }
}

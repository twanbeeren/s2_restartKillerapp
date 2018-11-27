using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Killerapp.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using Logic;

namespace Killerapp.Controllers
{
    public class FriendController : Controller
    {
        UserLogic userLogic = new UserLogic();
        FriendLogic friendLogic = new FriendLogic();

        public IActionResult Index()
        {
            FriendsViewModel model = new FriendsViewModel();
            int userId = HttpContext.Session.GetInt32("Id").GetValueOrDefault(0);
            model.CurrentUser = userLogic.GetUserOnId(userId);
            model.Friends = friendLogic.GetFriends(userId);
            model.FriendRequests = friendLogic.GetFriendRequests(userId);
            return View(model);
        }
        
        [Route("api/searchusers")]
        [HttpGet]
        public JsonResult SearchUsers(string searchTerm)
        {
            List<User> users = friendLogic.GetUsersOnSearch(searchTerm);
            return Json(users);
            
        }

        [Route("api/sendinvite")]
        [HttpPost]
        public IActionResult SendFriendInvite(int currentUserId, int userId)
        {
            friendLogic.SendFriendInvite(currentUserId, userId);
            return RedirectToAction("Index");
        }

        [Route("api/acceptinvite")]
        public IActionResult AcceptFriendInvite(int currentUserId, int userId)
        {
            friendLogic.AcceptFriendInvite(currentUserId, userId);
            return RedirectToAction("Index");
        }

        [Route("api/denyinvite")]
        public IActionResult DenyFriendInvite(int currentUserId, int userId)
        {
            friendLogic.DenyFriendInvite(currentUserId, userId);
            return RedirectToAction("Index");
        }
    }
}
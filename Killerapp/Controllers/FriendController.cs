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
            return View(model);
        }

        //this method should be called with an AJAX call and return a JSON object
        [HttpGet]
        public JsonResult SearchUsers(FriendsViewModel model)
        {
            List<User> users = friendLogic.GetUsersOnSearch(model.SearchTerm);
            return Json(users);
            
        }

        [HttpPost]
        public IActionResult SendFriendInvite(FriendsViewModel model)
        {
            friendLogic.SendFriendInvite(model.CurrentUser.Id, model.AddFriendId);
            return RedirectToAction("Index");
        }
    }
}
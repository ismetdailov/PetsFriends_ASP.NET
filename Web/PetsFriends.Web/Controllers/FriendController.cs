
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetsFriends.Data.Common.Repositories;
using PetsFriends.Data.Models;
using PetsFriends.Services.Data;
using PetsFriends.Web.ViewModels.Friend;
using PetsFriends.Web.ViewModels.Home;
using System.Linq;
using System.Threading.Tasks;

namespace PetsFriends.Web.Controllers
{
    public class FriendController : BaseController
    {
        private readonly IFriendService friendService;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public FriendController(IFriendService friendService, IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.friendService = friendService;
            this.usersRepository = usersRepository;
        }

        [Authorize]
        public IActionResult FindFriends()
        {

            if (!this.User.Identity.IsAuthenticated)
            {

                return this.RedirectToAction("Index");
            }
            var view = new PostListViewModel
            {
                Friends = this.friendService.GetAllUsers<FindFriendViewModel>()
            };

            return this.View(view);
        }
        //[Authorize]
        //[HttpPost]
        //public IActionResult FindFriends()
        //{

        //}
    }
}

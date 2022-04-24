
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsFriends.Data.Common.Repositories;
using PetsFriends.Data.Models;
using PetsFriends.Services.Data;
using PetsFriends.Web.ViewModels.Friend;
using PetsFriends.Web.ViewModels.Home;
using PetsFriends.Web.ViewModels.Profile;
using System.Linq;
using System.Threading.Tasks;

namespace PetsFriends.Web.Controllers
{
    public class FriendController : BaseController
    {
        private readonly IFriendService friendService;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public FriendController(IFriendService friendService, IDeletableEntityRepository<ApplicationUser> usersRepository, UserManager<ApplicationUser> userManager)
        {
            this.friendService = friendService;
            this.usersRepository = usersRepository;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> FindFriends()
        {
            var user = await this.userManager.GetUserAsync(this.User);


            if (!this.User.Identity.IsAuthenticated)
            {

                return this.RedirectToAction("Index");
            }
            var view = new PostListViewModel
            {
                Friends = await this.friendService.GetAllUsers<UserByIdViewMoodel>(user.Id),
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

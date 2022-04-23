using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsFriends.Data.Common.Repositories;
using PetsFriends.Data.Models;
using PetsFriends.Services.Data;
using PetsFriends.Web.ViewModels.Home;
using PetsFriends.Web.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsFriends.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfileService profileService;
        private readonly IPostService postService;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ProfileController(UserManager<ApplicationUser> userManager,IProfileService profileService, IPostService postService, IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.userManager = userManager;
            this.profileService = profileService;
            this.postService = postService;
            this.usersRepository = usersRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyProfile()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MyProfile(MyImagesInputModel createInput)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createInput);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.profileService.UploadProfileOrCoverImage(createInput, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(createInput);
            }
            this.TempData["Message"] = "You share your picture successfully";
            return this.RedirectToAction("MyProfile");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> _InfiniteScrollPostsPartial(string sortOrder, string searchString, int firstItem = 0)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var posts = postService.GetAllPosts<PostListViewModel>().ToList().Skip(firstItem).Take(5);
            if (posts.Count() == 0) return StatusCode(204);

            return this.View(posts);
        }

    }
}

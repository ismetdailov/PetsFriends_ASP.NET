using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public ProfileController(UserManager<ApplicationUser> userManager,IProfileService profileService, IPostService postService)
        {
            this.userManager = userManager;
            this.profileService = profileService;
            this.postService = postService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyProfile()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
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
            //return this.View("Index2");
        }
        //[Authorize]
        //[HttpGet]
        //public IActionResult MyProfile (string sortOrder, string searchString, int firstItem = 0)
        //{
        //    List<PostListViewModel> testData = new List<PostListViewModel>();


        //    var viewModel = new PostListViewModel
        //    {
        //        Posts = this.postService.GetAllPosts<IndexPostsViewModel>(),
        //    };
        //    // Generate test data
            

        //    // Sort and filter test data
        //    IEnumerable<PostListViewModel> query;
           

        //    // Extract a portion of data
        //   var model = viewModel.Posts.ToList().Skip(firstItem).Take(5).ToList();
        //    if (model.Count() == 0) return StatusCode(204);  // 204 := "No Content"
        //    return this.PartialView(viewModel);
        //}
    }
}

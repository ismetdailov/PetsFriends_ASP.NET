using System.Diagnostics;

using PetsFriends.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using PetsFriends.Web.ViewModels.Post;
using Microsoft.AspNetCore.Identity;
using PetsFriends.Data.Models;
using PetsFriends.Services.Data;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using PetsFriends.Web.ViewModels.Home;
using PetsFriends.Services.Mapping;

namespace PetsFriends.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPostService postService;

        public HomeController(UserManager<ApplicationUser> userManager, IPostService postService)
        {
            this.userManager = userManager;
            this.postService = postService;
        }
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index2");
            }

            return this.View();
        }
        [HttpGet]
        public IActionResult Index2()
        {
            var viewModel = new PostListViewModel
            {
                Posts = this.postService.GetAllPosts<IndexPostsViewModel>(),
            };

            return this.View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Index2(CreatePostInputModel createInput)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(createInput);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            try
            {
                await this.postService.CreateAsync(createInput, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(createInput);
            }

            this.TempData["Message"] = "You share your post successfully";
            return this.RedirectToAction("Index2");
            //return this.View("Index2");

        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

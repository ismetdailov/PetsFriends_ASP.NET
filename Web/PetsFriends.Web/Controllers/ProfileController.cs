namespace PetsFriends.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PetsFriends.Data.Common.Repositories;
    using PetsFriends.Data.Models;
    using PetsFriends.Services.Data;
    using PetsFriends.Web.ViewModels.Home;
    using PetsFriends.Web.ViewModels.Profile;

    public class ProfileController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfileService profileService;
        private readonly IPostService postService;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public ProfileController(UserManager<ApplicationUser> userManager, IProfileService profileService, IPostService postService, IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.userManager = userManager;
            this.profileService = profileService;
            this.postService = postService;
            this.usersRepository = usersRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var viewModel = new PostListViewModel
            {
                Posts = this.postService.GetMyPosts<IndexPostsViewModel>(user.Id),
                User = user,
                ProfilePicture = this.profileService.TakeProfilePicture(user.Id),
                CoverPictureLeft = this.profileService.TakeCoverPictureLeft(user.Id),
                CoverPictureRight = this.profileService.TakeCoverPictureRight(user.Id),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MyProfile(PostListViewModel createInput)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (createInput.ContentPost != null || createInput.Pictures != null)
            {
                try
                {
                    await this.postService.CreateAsync(createInput, user.Id);
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError(string.Empty, ex.Message);
                    return this.View(createInput);
                }

                return this.RedirectToAction("MyProfile");
            }
            else if (createInput.MyImagesInputModels != null)
            {
                try
                {
                    await this.profileService.UploadProfileOrCoverImage(createInput.MyImagesInputModels, user.Id);
                }
                catch (Exception ex)
                {
                    this.ModelState.AddModelError(string.Empty, ex.Message);
                    return this.View(createInput);
                }

                return this.RedirectToAction("MyProfile");
            }

            return this.View(createInput);
        }

        [Authorize]
        public async Task<IActionResult> USerById(string id)
        {
            var user = await this.userManager.FindByNameAsync(id);
            var users = this.profileService.GetById<UserByIdViewMoodel>(id);
            //var users = this.profileService.GetUserById<UserByIdViewMoodel>(id);
            var postsOnUSer = new PostListViewModel
            {
                Posts = this.postService.GetMyPosts<IndexPostsViewModel>(user.Id),
            };

            users.PostsListModel = postsOnUSer;
            return this.View(users);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddInformation()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddInformation(InfoAboutPetInputModel createInput)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            try
            {
                await this.profileService.AddInformationAboutPet(createInput, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(createInput);
            }

            return this.RedirectToAction("MyProfile");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InfiniteScrollPostsPartial(string sortOrder, string searchString, int firstItem = 0)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var posts = this.postService.GetAllPosts<PostListViewModel>().ToList().Skip(firstItem).Take(5);
            if (posts.Count() == 0)
            {
                return this.StatusCode(204);
            }

            return this.View(posts);
        }
    }
}

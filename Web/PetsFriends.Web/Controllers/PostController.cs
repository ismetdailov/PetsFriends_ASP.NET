namespace PetsFriends.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PetsFriends.Data.Models;
    using PetsFriends.Services.Data;
    using PetsFriends.Web.ViewModels.Home;

    public class PostController : BaseController
    {
        private readonly IPostService postService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostController(IPostService postService, UserManager<ApplicationUser> userManager)
        {
            this.postService = postService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Like(int postId, string petId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            petId = user.Id;
            await this.postService.LikePost(postId, petId);
            if (this.RedirectToActionPreserveMethod().ActionName == "MyProffile")
            {
                return this.RedirectToAction("MyProfile", "Profile");
            }

            return this.RedirectToAction("Index2", "Home");
        }

        public async Task<IActionResult> Delete(IndexPostsViewModel indexPostsView)
        {
            await this.postService.DeleteAsync(indexPostsView.Id);
            return this.RedirectToAction("MyProfile", "Profile");
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsFriends.Data.Models;
using PetsFriends.Services.Data;
using System.Threading.Tasks;

namespace PetsFriends.Web.Controllers
{
    public class PostController : Controller
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
            await this.postService.LikePost(postId,petId);

            return this.RedirectToAction("Index2", "Home");
        }
    }
}

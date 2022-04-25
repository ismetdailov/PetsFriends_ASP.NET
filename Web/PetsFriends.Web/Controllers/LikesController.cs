using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsFriends.Data.Models;
using PetsFriends.Services.Data;
using PetsFriends.Web.ViewModels.Home;
using System.Threading.Tasks;

namespace PetsFriends.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikesController : BaseController
    {
        private readonly IPostService postService;
        private readonly UserManager<ApplicationUser> userManager;

        public LikesController(IPostService postService, UserManager<ApplicationUser> userManager)
        {
            this.postService = postService;
            this.userManager = userManager;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<PostListViewModel>> Like(int postId, string petId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            petId = user.Id;
           var likes = this.postService.LikePost(postId, petId);
            var posts = this.postService.GetAllPosts<IndexPostsViewModel>();
            var model = new PostListViewModel();
          model.Posts = this.postService.GetAllPosts<IndexPostsViewModel>();
            return  new PostListViewModel { Posts = posts};
        }
    }
}

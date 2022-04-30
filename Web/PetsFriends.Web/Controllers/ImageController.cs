namespace PetsFriends.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PetsFriends.Services.Data;
    using PetsFriends.Web.ViewModels.Image;

    public class ImageController : BaseController
    {
        private readonly IPictureService pictureService;

        public ImageController(IPictureService pictureService)
        {
            this.pictureService = pictureService;
        }

        [Authorize]
        public IActionResult ImageById(string id)
        {
            var images = this.pictureService.GetById<ImageByIdViewModel>(id);

            return this.View(images);
        }
    }
}

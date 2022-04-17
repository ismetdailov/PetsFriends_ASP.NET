using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsFriends.Data.Models;
using PetsFriends.Services.Data;
using PetsFriends.Web.ViewModels.Profile;
using System;
using System.Threading.Tasks;

namespace PetsFriends.Web.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfileService profileService;

        public ProfileController(UserManager<ApplicationUser> userManager,IProfileService profileService)
        {
            this.userManager = userManager;
            this.profileService = profileService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult MyProfile()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> MyProfile(ProfileAndCoverPicturesInputModel createInput)
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
    }
}

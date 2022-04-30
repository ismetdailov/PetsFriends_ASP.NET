namespace PetsFriends.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using PetsFriends.Data.Models;
    using PetsFriends.Services.Data;
    using PetsFriends.Web.ViewModels.Search;

    public class SearchController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ISearchService searchService;

        public SearchController(UserManager<ApplicationUser> userManager, ISearchService searchService)
        {
            this.userManager = userManager;
            this.searchService = searchService;
        }

        public async Task<IActionResult> Search(SearchListViewModel searchViewModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var res = this.searchService.SearchAsync(searchViewModel, user.Id);

            if (!this.ModelState.IsValid)
            {
                return this.View(searchViewModel);
            }

            try
            {
                await this.searchService.SearchAsync(searchViewModel, user.Id);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(searchViewModel);
            }

            return this.RedirectToAction("Index2", "Home", res);
        }
    }
}

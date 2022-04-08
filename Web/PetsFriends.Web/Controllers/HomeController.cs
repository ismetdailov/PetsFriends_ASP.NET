using System.Diagnostics;

using PetsFriends.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace PetsFriends.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("Index2");
            }

            return this.View();
        }

        public IActionResult Index2()
        {

            return this.View();
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

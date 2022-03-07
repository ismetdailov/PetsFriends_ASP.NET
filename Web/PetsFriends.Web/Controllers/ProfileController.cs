using Microsoft.AspNetCore.Mvc;

namespace PetsFriends.Web.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetsFriends.Web.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize]
        public IActionResult MyProfile()
        {
            return View();
        }
    }
}

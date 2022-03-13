using Microsoft.AspNetCore.Mvc;

namespace PetsFriends.Web.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Messages()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetsFriends.Web.Controllers
{
    public class MessagesController : BaseController
    {
        [Authorize]
        public IActionResult Messages()
        {
            return View();
        }
    }
}

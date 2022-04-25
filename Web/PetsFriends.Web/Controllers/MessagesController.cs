using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetsFriends.Data.Models;
using PetsFriends.Web.Hub.Services.Data;
using PetsFriends.Web.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetsFriends.Web.Controllers
{
    public class MessagesController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHubService hubService;

        public MessagesController(UserManager<ApplicationUser> userManager, IHubService hubService)
        {
            this.userManager = userManager;
            this.hubService = hubService;
        }
        [Authorize]
        //public IActionResult Messages()
        //{
        //    return View();
        //}
        public async Task<IActionResult> Messages()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var messageViewModel = new MessageViewModel
            {
                SenderPet = await this.userManager.GetUserAsync(this.HttpContext.User),
                ReciverPet = await this.userManager.FindByNameAsync(user.UserName),
                Messages = await this.hubService.AllMessages(),
                IsSeen = false,
            };
            return this.View(messageViewModel);
        }
        //public async IActionResult SendMessage()
        //{

        //    return this.View();
        //}
        [HttpPost]
        [Route("MessageChat/With/{toUsername?}/SendMessage")]
        public async Task<IActionResult> SendMessage(MessageViewModel messageViewModel)
        {
            try
            {
             this.hubService.SendMessageUser(messageViewModel);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(messageViewModel);
            }
            return this.View();

        }
        //[Authorize]
        //[HttpPost]
        //[Route("MessageChat/With/{toUsername?}/SendMessage")]
        //public async Task<IActionResult> SendMessage(MessageViewModel messageViewModel)
        //{
        //    var user = await this.userManager.GetUserAsync(this.User);
        //    var mdell = this.hubService.SendMessageToUser(messageViewModel);

        //    return new JsonResult(mdell);

        //}
        [HttpPost]
        [Route("MessageChat/With/{toUsername?}/Send")]
        public async Task<IActionResult> Send(string toUsername, string fromUsername, string message)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            var result = await this.hubService.SendMessageToUser(toUsername, fromUsername, message);

            return new JsonResult(result);
        }
    }
}

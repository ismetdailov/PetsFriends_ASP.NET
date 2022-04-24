namespace PetsFriends.Web.Hub
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using PetsFriends.Data.Models;
    using PetsFriends.Services.Data;
    using PetsFriends.Web.Hub.Services.Data;
    using PetsFriends.Web.ViewModels.Message;
    using System.Threading.Tasks;

    public class MessageChat : Hub
    {
        private readonly IHubService hubService;

        public MessageChat(IHubService hubService)
        {
            this.hubService = hubService;
        }

        //public async Task SendMessage(MessageViewModel messageViewModel)
        //{
        //    await this.hubService.SendMessageToUser(messageViewModel);
        //}
        public async Task SendMessage(string fromUsername, string toUsername, string message)
        {
            await this.hubService.SendMessageToUser(fromUsername, toUsername, message);
        }
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Messages { PetId = this.Context.User.Identity.Name, Content = message, });
        }

    }
}

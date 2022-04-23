namespace PetsFriends.Web.Hub
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using PetsFriends.Services.Data;
    using PetsFriends.Web.ViewModels.Message;
    using System.Threading.Tasks;

    public class MessageChat : Hub
    {
        private readonly IHubService hubService;

        public MessageChat(IHubService hubService)
        {
            this.hubService = hubService;
        }

        public async Task SendMessage(MessageViewModel messageViewModel)
        {
            await this.hubService.SendMessageToUser(messageViewModel);
        }

    }
}

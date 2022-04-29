namespace PetsFriends.Web.Hub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Ganss.XSS;
    using Microsoft.AspNetCore.SignalR;
    using PetsFriends.Data.Common.Repositories;
    using PetsFriends.Data.Models;
    using PetsFriends.Web.Hub;
    using PetsFriends.Web.ViewModels.Message;

    public class HubService : IHubService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Messages> messageRepository;
        private readonly IHubContext<MessageChat> hubContext;

        public HubService()
        {
        }

        public HubService(IDeletableEntityRepository<ApplicationUser> usersRepository, IDeletableEntityRepository<Messages> messageRepository, IHubContext<MessageChat> hubContext)
        {
            this.usersRepository = usersRepository;
            this.messageRepository = messageRepository;
            this.hubContext = hubContext;
        }

        public async Task<ICollection<Messages>> AllMessages()
        {

            return messageRepository.AllAsNoTracking().Take(100).OrderByDescending(x => x.SendedOn).Take(100).ToList();
        }

        public async Task SendMessageUser(MessageViewModel messageViewModel)
        {
            var fromUser = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == messageViewModel.SenderPet.UserName);
            var fromUserId = fromUser.Id;
            var fromUserProfileImage = fromUser.ProfilePictures.FirstOrDefault();

            var toUser = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == messageViewModel.ReciverPet.Id);
            var toUserId = fromUser.Id;
            var toUserProfileImage = fromUser.ProfilePictures.FirstOrDefault();


            var newMessage = new Messages
            {
                Pet = fromUser,
                SendedOn = DateTime.UtcNow,
                ReciverPet = toUser,
                Content = new HtmlSanitizer().Sanitize(messageViewModel.MessageText.Trim()),
            };
            await this.messageRepository.AddAsync(newMessage);

            await this.messageRepository.SaveChangesAsync();
            await this.hubContext.Clients.User(toUserId).SendAsync("ReceiveMessage", messageViewModel.SenderPet.UserName, messageViewModel.ReciverPet.UserName, new HtmlSanitizer().Sanitize(messageViewModel.MessageText.Trim()));

        }

        public async Task<string> SendMessageToUser(string fromUsername, string toUsername, string message)
        {
            var fromUser = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == fromUsername);
            var fromUserId = fromUser.Id;
            var fromUserProfileImage = fromUser.ProfilePictures.FirstOrDefault();

            var toUser = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == toUsername);
            var toUserId = fromUser.Id;
            var toUserProfileImage = fromUser.ProfilePictures.FirstOrDefault();


            var newMessage = new Messages
            {
                Pet = fromUser,
                SendedOn = DateTime.UtcNow,
                ReciverPet = toUser,
                Content = new HtmlSanitizer().Sanitize(message.Trim()),
            };
            this.messageRepository.AddAsync(newMessage);

            this.messageRepository.SaveChangesAsync();
            this.hubContext.Clients.User(toUserId).SendAsync("ReceiveMessage", fromUsername, toUsername, new HtmlSanitizer().Sanitize(message.Trim()));
            return toUserId;
        }
    }
}

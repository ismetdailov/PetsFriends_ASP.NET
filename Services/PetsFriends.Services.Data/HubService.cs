namespace PetsFriends.Services.Data
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
    using PetsFriends.Web.ViewModels.Message;

    public class HubService : IHubService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Messages> messageRepository;

        public HubService(IDeletableEntityRepository<ApplicationUser> usersRepository, IDeletableEntityRepository<Messages> messageRepository)
        {
            this.usersRepository = usersRepository;
            this.messageRepository = messageRepository;
        }

        public async Task SendMessageToUser(MessageViewModel messageViewModel)
        {
            var fromUser = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == messageViewModel.SenderId);
            var fromUserId = fromUser.Id;
            var fromUserProfileImage = fromUser.ProfilePictures.FirstOrDefault();

            var toUser = this.usersRepository.AllAsNoTracking().FirstOrDefault(x => x.Id == messageViewModel.PetReciverId);
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
        }
    }
}

namespace PetsFriends.Web.Hub.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Data.Models;
    using PetsFriends.Web.ViewModels.Message;

    public interface IHubService
    {
        Task SendMessageUser(MessageViewModel messageViewModel);

        Task<string> SendMessageToUser(string fromUsername, string toUsername, string message);

        ICollection<Messages> AllMessages();
    }
}

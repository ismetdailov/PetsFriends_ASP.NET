using PetsFriends.Data.Models;
using PetsFriends.Web.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Web.Hub.Services.Data
{
    public interface IHubService
    {
        Task SendMessageUser(MessageViewModel messageViewModel);
        Task<string> SendMessageToUser(string fromUsername, string toUsername, string message);
        Task<ICollection<Messages>> AllMessages();
    }
}

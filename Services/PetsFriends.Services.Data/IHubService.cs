using PetsFriends.Web.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Services.Data
{
    public interface IHubService
    {
        Task SendMessageToUser(MessageViewModel messageViewModel);
    }
}

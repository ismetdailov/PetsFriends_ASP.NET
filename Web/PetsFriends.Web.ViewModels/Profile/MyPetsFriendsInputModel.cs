using PetsFriends.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace PetsFriends.Web.ViewModels.Profile
{
    public class MyPetsFriendsInputModel
    {

        public string PetFriendId { get; set; }

        public ICollection<ApplicationUser> PetFriend { get; set; }
    }
}

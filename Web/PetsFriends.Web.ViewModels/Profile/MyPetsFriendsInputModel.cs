namespace PetsFriends.Web.ViewModels.Profile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Data.Models;

    public class MyPetsFriendsInputModel
    {
        public string PetFriendId { get; set; }

        public ICollection<ApplicationUser> PetFriend { get; set; }
    }
}

namespace PetsFriends.Data.Models
{
    using System.Collections.Generic;

    using PetsFriends.Data.Common.Models;

    public class Friend : BaseDeletableModel<int>
    {

        public string Username { get; set; }

        public string Image { get; set; }

        public string ProfileUrl { get; set; }


        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

    }
}

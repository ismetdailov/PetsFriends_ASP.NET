namespace PetsFriends.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using PetsFriends.Data.Common.Models;

    public class Friend : BaseDeletableModel<string>
    {
        public Friend()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string PetFriendId { get; set; }

        public virtual ApplicationUser PetFriend { get; set; }
    }
}

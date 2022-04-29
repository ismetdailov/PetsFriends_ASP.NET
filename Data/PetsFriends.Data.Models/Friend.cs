using PetsFriends.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Data.Models
{
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

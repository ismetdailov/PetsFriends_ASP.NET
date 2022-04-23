using PetsFriends.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Data.Models
{
    public class UserMessages : BaseDeletableModel<int>
    {
        public UserMessages()
        {
            this.Messages = new HashSet<Messages>();
        }
        public string PetId { get; set; }

        public ApplicationUser Pet { get; set; }

        public int MessageId { get; set; } 
        public Messages Message { get; set; }
        public ICollection<Messages> Messages { get; set; }
    }
}

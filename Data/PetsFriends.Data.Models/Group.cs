using PetsFriends.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Data.Models
{
    public class Group : BaseDeletableModel<int>
    {
        public Group()
        {
            this.Messages = new HashSet<Messages>();
            this.GroupOnUsers = new HashSet<GroupOnUser>();
        }

        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<GroupOnUser> GroupOnUsers { get; set; }

        public ICollection<Messages> Messages { get; set; }
    }
}

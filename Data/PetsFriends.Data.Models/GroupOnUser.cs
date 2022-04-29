using PetsFriends.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Data.Models
{
    public class GroupOnUser
    {
        [ForeignKey(nameof(Group))]
        public int GroupIdId { get; set; }

        public Group Group { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string PetId { get; set; }

        public ApplicationUser Pet { get; set; }
    }
}

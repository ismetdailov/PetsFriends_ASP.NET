using PetsFriends.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Data.Models
{
    public class CoverPictureLeft : BaseDeletableModel<int>
    {
        public byte[] Bytes { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

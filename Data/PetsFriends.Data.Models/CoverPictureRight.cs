using PetsFriends.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetsFriends.Data.Models
{
    public class CoverPictureRight : BaseDeletableModel<string>
    {
        public CoverPictureRight()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public byte[] Bytes { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
